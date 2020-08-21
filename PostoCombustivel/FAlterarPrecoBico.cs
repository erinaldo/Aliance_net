using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFAlterarPrecoBico : Form
    {
        public System.Net.Sockets.TcpClient tcpClient;
        public System.IO.BinaryWriter escreve;
        public System.IO.BinaryReader le;

        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto rCfgPosto { get; set; }

        public TFAlterarPrecoBico()
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

        private void AlterarPreco()
        {
            if (bsBico.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba> lista =
                    (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).FindAll(p => p.St_processar);
                if ((lista.Count > 0) &&
                    (vl_preco.Value != decimal.Zero))
                {
                    string aux = string.Empty;
                    string virg = string.Empty;
                    lista.ForEach(p =>
                    {
                        if (tcpClient == null)
                        {
                            if (TAutomacao.AlteraPrecoUnitBico(rCfgPosto.Tp_concentrador, p.Enderecofisicobico, vl_preco.Value))
                            {
                                aux += virg + p.Ds_label;
                                virg = ",";
                            }
                        }
                        else
                        {
                            string comando = "&U" + p.Enderecofisicobico.Trim() + "00" + vl_preco.Value.ToString("N3", new System.Globalization.CultureInfo("pt-BR")).SoNumero();
                            comando = "(" + comando + TCompanytec.CalcularChecksum(comando) + ")";
                            string ret = this.SendLan(comando);
                            if ((!ret.Trim().Equals("(U?t)")) && (!ret.Trim().Equals("(U?b)")))
                            {
                                aux += virg + p.Ds_label;
                                virg = ",";
                            }
                        }
                    });
                    if (!string.IsNullOrEmpty(aux))
                        MessageBox.Show("Preço unitario dos seguintes bicos foram alterados com sucesso.\r\n" +
                                        "Bicos: " + aux.Trim() + "\r\n" +
                                        "O valor no display da bomba sera atualizado na proxima abastecida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BloquearBico()
        {
            if (bsBico.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba> lista =
                    (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).FindAll(p => p.St_processar);
                if (lista.Count > 0)
                {
                    string aux = string.Empty;
                    string virg = string.Empty;
                    lista.ForEach(p =>
                    {
                        if (tcpClient == null)
                        {
                            if (TAutomacao.BloquearBico(rCfgPosto.Tp_concentrador, p.Enderecofisicobico))
                            {
                                aux += virg + p.Enderecofisicobico;
                                virg = ",";
                            }
                        }
                        else
                        {
                            string comando = "&M" + p.Enderecofisicobico.Trim() + "B";
                            comando = "(" + comando + TCompanytec.CalcularChecksum(comando) + ")";
                            string ret = this.SendLan(comando);
                            if (comando.Length != 5 ? false : comando.Substring(2, 2).Equals(p.Enderecofisicobico.Trim()))
                            {
                                aux += virg + p.Enderecofisicobico;
                                virg = ",";
                            }
                        }
                    });
                    if (!string.IsNullOrEmpty(aux))
                        MessageBox.Show("Os seguintes bicos foram bloqueados com sucesso.\r\n" +
                                        "Bicos: " + aux.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LiberarBico()
        {
            if (bsBico.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba> lista =
                    (bsBico.DataSource as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).FindAll(p => p.St_processar);
                if (lista.Count > 0)
                {
                    string aux = string.Empty;
                    string virg = string.Empty;
                    lista.ForEach(p =>
                    {
                        if (tcpClient == null)
                        {
                            if (TAutomacao.LiberarBico(rCfgPosto.Tp_concentrador, p.Enderecofisicobico))
                            {
                                aux += virg + p.Enderecofisicobico;
                                virg = ",";
                            }
                        }
                        else
                        {
                            string comando = "&M" + p.Enderecofisicobico.Trim() + "L";
                            comando = "(" + comando + TCompanytec.CalcularChecksum(comando) + ")";
                            string ret = this.SendLan(comando);
                            if (comando.Length != 5 ? false : comando.Substring(2, 2).Equals(p.Enderecofisicobico.Trim()))
                            {
                                aux += virg + p.Enderecofisicobico;
                                virg = ",";
                            }
                        }
                    });
                    if (!string.IsNullOrEmpty(aux))
                        MessageBox.Show("Os seguintes bicos foram liberados com sucesso.\r\n" +
                                        "Bicos: " + aux.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TFAlterarPrecoBico_Load(object sender, EventArgs e)
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

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.AlterarPreco();
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

        private void st_marcar_Click(object sender, EventArgs e)
        {
            if (bsBico.Count > 0)
            {
                (bsBico.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).ForEach(p => p.St_processar = st_marcar.Checked);
                bsBico.ResetBindings(true);
            }
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

        private void TFAlterarPrecoBico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBico);
        }

        private void bb_bloquear_Click(object sender, EventArgs e)
        {
            this.BloquearBico();
        }

        private void bb_liberar_Click(object sender, EventArgs e)
        {
            this.LiberarBico();
        }
    }
}
