using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFLerEncerrante : Form
    {
        public System.Net.Sockets.TcpClient tcpClient;
        public System.IO.BinaryWriter escreve;
        public System.IO.BinaryReader le;

        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto rCfgPosto
        { get; set; }

        public TFLerEncerrante()
        {
            InitializeComponent();
        }

        public string SendLan(string comando)
        {
            string rta = string.Empty;
            if (tcpClient.Connected)
            {
                escreve.Write(comando);
                escreve.Flush();
                if (comando.Trim() != "(&I)")
                    rta = ReceiveLanData();
            }
            return rta;
        }

        private string ReceiveLanData()
        {
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            le.Read(buffer, 0, tcpClient.ReceiveBufferSize);
            return Encoding.ASCII.GetString(buffer);
        }

        private void LerEncerrante()
        {
            if (bsBico.Count > 0)
            {
                (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).FindAll(p => p.St_processar).ForEach(p =>
                    {
                        if (tcpClient == null)
                            p.Qtd_encerrante = TAutomacao.LerEncerranteBico(rCfgPosto.Tp_concentrador, p.Enderecofisicobico, "L");
                        else
                        {
                            string comando = "&T" + p.Enderecofisicobico.Trim() + "L";
                            comando = "(" + comando + TCompanytec.CalcularChecksum(comando) + ")";
                            string ret = this.SendLan(comando);
                            if (!string.IsNullOrEmpty(ret))
                                if (ret.Trim().Length.Equals(16))
                                    p.Qtd_encerrante = decimal.Parse(comando.Substring(5, 8)) / 100;
                        }
                    });

                bsBico.ResetBindings(true);
            }
        }

        private void ProcessarEncerrante()
        {
            if(bsBico.Count > 0)
                try
                {
                    //Verificar se tem configuracao de tipo de encerrante para a empresa
                    object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                    }
                                }, "isnull(a.tp_leituraencerrantebico, 'A')");
                    string tp_encerrante = obj == null ? "A" : obj.ToString();
                    List<CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba> lEncerrante =
                        (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).FindAll(p => p.St_processar);
                    if (lEncerrante.Count > 0)
                    {
                        //Verificar se existe abastecida para a data atual
                        if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.dt_abastecimento",
                                vOperador = "between",
                                vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "' and '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + " 23:59:59'"
                            }
                        }, "1") != null)
                        {
                            if (MessageBox.Show("Existe abastecida para a data atual. Deseja processar encerrante mesmo assim?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.ProcessarEncerrante(lEncerrante, rCfgPosto.Cd_empresa, tp_encerrante, null);
                                MessageBox.Show("Encerrantes processados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.ProcessarEncerrante(lEncerrante, tp_encerrante, rCfgPosto.Cd_empresa, null);
                            MessageBox.Show("Encerrantes processados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLerEncerrante_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBico);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar bicos para alterar preco
            bsBico.DataSource = CamadaNegocio.PostoCombustivel.Cadastros.TCN_BicoBomba.Buscar(string.Empty,
                                                                                              string.Empty,
                                                                                              rCfgPosto.Cd_empresa,
                                                                                              string.Empty,
                                                                                              "'A'",
                                                                                              null);
        }

        private void st_marcar_Click(object sender, EventArgs e)
        {
            if (bsBico.Count > 0)
            {
                (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).ForEach(p => p.St_processar = st_marcar.Checked);
                bsBico.ResetBindings(true);
            }
        }

        private void gBico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar =
                    !(bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).St_processar;
                bsBico.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.LerEncerrante();
        }

        private void TFLerEncerrante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.LerEncerrante();
            else if (e.KeyCode.Equals(Keys.F4))
                this.ProcessarEncerrante();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.ProcessarEncerrante();
        }

        private void gBico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba());
            CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBico.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).Sort(lComparer);
            bsBico.ResetBindings(false);
            gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLerEncerrante_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBico);
        }
    }
}
