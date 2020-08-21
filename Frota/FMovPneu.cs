using CamadaDados.Frota;
using CamadaDados.Frota.Cadastros;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FormBusca;
using Utils;

namespace Frota
{
    public partial class TFMovPneu : Form
    {
        public string pCd_empresa = string.Empty;
        public string pId_pneu = string.Empty;
        public string pId_veiculo = string.Empty;
        private string pId_veiculoDestino = string.Empty;

        public TFMovPneu()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void LimparSelecao()
        {
            (bsPneu.DataSource as TList_LanPneu).ForEach(p => p.St_processar = false);
            bsPneu.ResetBindings(true);
            pId_pneu = string.Empty;
        }

        private void afterBusca()
        {
            //Buscar pneus disponiveis para reliazar a movimentação caso haja veiculo
            if (!string.IsNullOrEmpty(pCd_empresa) && !string.IsNullOrEmpty(pId_veiculo))
            {
                bsPneu.DataSource = new TCD_LanPneu().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FRT_MovPneu x " +
                                         "where a.cd_empresa = x.cd_empresa " +
                                         "and a.id_pneu = x.id_pneu " +
                                         "and isnull(x.st_rodando, 'N') = 'S' " +
                                         "and x.cd_empresa = '" + pCd_empresa.Trim() + "'" +
                                         "and x.id_veiculo = " + pId_veiculo + ") "
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'R'"
                        }
                    }, 0, string.Empty);
            }

            //Para pneus que estão no almoxarifado
            else
            {
                bsPneu.DataSource = new TCD_LanPneu().Select(
                   new Utils.TpBusca[]
                   {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + pCd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                   }, 0, string.Empty);
            }
            bsPneu.ResetCurrentItem();
            bsPneu_PositionChanged(this, new EventArgs());

            //Selecionar o pneu informado na listagem 
            if (bsPneu.Count > 0 && !string.IsNullOrEmpty(pId_pneu))
            {
                try
                {
                    DataGridViewRow linha = gPneu.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pId_pneustr"].Value.ToString().Contains(pId_pneu)).First();
                    if (linha != null)
                    {
                        gPneu.Rows[linha.Index].Selected = true;
                        bsPneu.Position = linha.Index;
                        bsPneu.ResetCurrentItem();
                    }
                }
                catch { }
            }

            FixarVeiculoExecucaoTroca();
            BuscarRodadoVeiculo();
        }

        /*
        private int InformarHodometro(string title, decimal Vl_default = 0)
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Ds_label = "Hodometro " + title.Trim();
                fQtde.Vl_default = Vl_default;
                fQtde.Vl_Minimo = fQtde.Vl_default;
                fQtde.Casas_decimais = 0;
                fQtde.St_permitirValorZero = false;
                if (fQtde.ShowDialog() == DialogResult.OK)
                    return Convert.ToInt32(fQtde.Quantidade);
                else
                {
                    MessageBox.Show("Obrigatório informar hodometro para " + title.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
        }
        */

        private string BuscarVeiculo(bool st_destino)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.placa|Placa|80;" +
                              "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                 new TCD_CadVeiculo(),
                vParam);
            if (linha != null)
            {
                if (st_destino)
                    veiculoDestino.Text = linha["placa"].ToString();
                else
                    filtroVeiculo.Text = linha["placa"].ToString();
                return linha["id_veiculo"].ToString();
            }
            else
                return string.Empty;
        }

        private void BuscarRodadoVeiculo()
        {
            if (!string.IsNullOrEmpty(pId_veiculoDestino))
            {
                bsRodado.Clear();
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", pId_veiculoDestino);
                TRegistro_CadVeiculo _CadVeiculoDestino = new TCD_CadVeiculo().Select(tpBuscas, 1, string.Empty)[0];
                TList_CadVeiculo _CadVeiculos = null;
                if (string.IsNullOrEmpty(_CadVeiculoDestino.Id_veiculo_principalstr))
                {
                    tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo_principal", pId_veiculoDestino);
                    _CadVeiculos = new TCD_CadVeiculo().Select(tpBuscas, 0, string.Empty);
                    _CadVeiculos.Add(_CadVeiculoDestino);
                    _CadVeiculos.ForEach(c =>
                    {
                        tpBuscas = new TpBusca[0];
                        Estruturas.CriarParametro(ref tpBuscas, "b.id_veiculo", c.Id_veiculostr);
                        TList_Rodado _Rodados = new TCD_Rodado().SelectRodadoComVeiculo(tpBuscas, 0, string.Empty);
                        _Rodados.ForEach(p =>
                        {
                            var lPneu = new TCD_LanPneu().Select(
                                   new Utils.TpBusca[]
                                   {
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = string.Empty,
                                             vOperador = "exists",
                                             vVL_Busca = "(select 1 from TB_FRT_MovPneu x " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.id_pneu = a.id_pneu " +
                                                          "and x.st_rodando = 'S' " +
                                                         "and x.id_rodado =  " + p.Id_rodadostr +
                                                         "and x.cd_empresa = '" + pCd_empresa.Trim() + "'" +
                                                         "and x.id_veiculo = " + c.Id_veiculostr + ") "
                                         }
                                   }, 1, string.Empty);
                            if (lPneu.Count > 0)
                            {
                                p.Nr_serie = lPneu[0].Nr_serie;
                                p.Id_pneu = lPneu[0].Id_pneustr;
                                p.Cd_produto = lPneu[0].Cd_produto;
                            }
                        });
                        _Rodados.ForEach(r => { bsRodado.Add(r); });
                    });
                }
                else
                {
                    tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", _CadVeiculoDestino.Id_veiculo_principalstr);
                    _CadVeiculos = new TCD_CadVeiculo().Select(tpBuscas, 0, string.Empty);
                    _CadVeiculos.Add(_CadVeiculoDestino);
                    _CadVeiculos.ForEach(c =>
                    {
                        TList_Rodado _Rodados = new TCD_Rodado().SelectRodadoComVeiculo(new Utils.TpBusca[]
                                                                                        {
                                                                                            new Utils.TpBusca()
                                                                                            {
                                                                                                vNM_Campo = string.Empty,
                                                                                                vOperador = "exists",
                                                                                                vVL_Busca = "(select 1 from TB_FRT_RodadoVeic x " +
                                                                                                            "where x.id_rodado = a.id_rodado " +
                                                                                                            "and x.id_veiculo = " + c.Id_veiculostr + ") "
                                                                                            },
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = "b.id_veiculo",
                                                                                                vOperador = "=",
                                                                                                vVL_Busca = c.Id_veiculostr
                                                                                            }
                                                                                         }, 0, string.Empty);
                        _Rodados.ForEach(p =>
                        {
                            var lPneu = new TCD_LanPneu().Select(
                                   new Utils.TpBusca[]
                                   {
                                         new Utils.TpBusca()
                                         {
                                             vNM_Campo = string.Empty,
                                             vOperador = "exists",
                                             vVL_Busca = "(select 1 from TB_FRT_MovPneu x " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.id_pneu = a.id_pneu " +
                                                          "and x.st_rodando = 'S' " +
                                                         "and x.id_rodado =  " + p.Id_rodadostr +
                                                         "and x.cd_empresa = '" + pCd_empresa.Trim() + "'" +
                                                         "and x.id_veiculo = " + c.Id_veiculostr + ") "
                                         }
                                   }, 1, string.Empty);
                            if (lPneu.Count > 0)
                            {
                                p.Nr_serie = lPneu[0].Nr_serie;
                                p.Id_pneu = lPneu[0].Id_pneustr;
                                p.Cd_produto = lPneu[0].Cd_produto;
                            }
                        });
                        _Rodados.ForEach(r => { bsRodado.Add(r); });
                    });
                }

                bsRodado.ResetBindings(true);
            }
        }

        private void afterGrava()
        {
            if (bsPneu.Current == null || bsRodado.Current == null)
            {
                MessageBox.Show("Para finalizar está operação é obrigatório selecionar origem e destino de movimentação.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((bsPneu.Current as TRegistro_LanPneu).Id_pneustr.Trim().Equals((bsRodado.Current as TRegistro_Rodado).Id_pneu.ToString().Trim()))
            {
                MessageBox.Show("O pneu informado na origem é o mesmo do destino. Não é possível realizar a movimentação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                CamadaNegocio.Frota.TCN_MovPneu.GravarTrocaPneu((bsPneu.Current as TRegistro_LanPneu),
                                                                (bsRodado.Current as TRegistro_Rodado),
                                                                pId_veiculo,
                                                                (bsRodado.Current as TRegistro_Rodado).Id_veiculostr,
                                                                null,
                                                                HodometroOrigem: Convert.ToInt32(Ed_HodoInicial.Text.Trim()),
                                                                HodometroDestino: Convert.ToInt32(Ed_HodoFinal.Text.Trim()),
                                                                ProfundidadeOrigem: Convert.ToDecimal(Ed_Profundidade.Text.Trim()),
                                                                ProfundidadeDestino: Convert.ToDecimal(Ed_ProfundidadeDestino.Text.Trim()));
                MessageBox.Show("Troca de Pneu efetuada com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparSelecao();
                afterBusca();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FixarVeiculoExecucaoTroca()
        {
            try
            {
                filtroVeiculo.Text = string.IsNullOrEmpty((bsPneu.Current as TRegistro_LanPneu).Placa) ?
                    (bsPneu.Current as TRegistro_LanPneu).Status :
                    (bsPneu.Current as TRegistro_LanPneu).Placa;
            }
            catch { }
        }

        private void TFMovPneu_Load(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFMovPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
        }

        private void bsPneu_PositionChanged(object sender, EventArgs e)
        {
            if (bsPneu.Current != null)
            {
                pneuSelecionado.Text = (bsPneu.Current as TRegistro_LanPneu).Nr_serie;
                rodadoAtual.Text = !string.IsNullOrEmpty((bsPneu.Current as TRegistro_LanPneu).Ds_rodado) ?
                                   (bsPneu.Current as TRegistro_LanPneu).Ds_rodado : "PNEU NÃO ESTÁ RODANDO";
                FixarVeiculoExecucaoTroca();

                //Buscar hodometro incial caso seja rodando
                if ((bsPneu.Current as TRegistro_LanPneu).Status.Equals("RODANDO"))
                {
                    object hodoInicial = new TCD_MovPneu().BuscarEscalar(new TpBusca[]
                                                             {
                                                                 new TpBusca()
                                                                 {
                                                                     vNM_Campo = "a.id_pneu",
                                                                     vOperador = "=",
                                                                     vVL_Busca = (bsPneu.Current as TRegistro_LanPneu).Id_pneustr
                                                                 },
                                                                 new TpBusca()
                                                                 {
                                                                     vNM_Campo = "a.id_veiculo",
                                                                     vOperador = "=",
                                                                     vVL_Busca = (bsPneu.Current as TRegistro_LanPneu).Id_veiculo.ToString()
                                                                 },
                                                                 new TpBusca()
                                                                 {
                                                                     vNM_Campo = "a.id_rodado",
                                                                     vOperador = "=",
                                                                     vVL_Busca = (bsPneu.Current as TRegistro_LanPneu).Id_rodado.ToString()
                                                                 }
                                                             }, "a.hodometro");
                    if (hodoInicial != null && !string.IsNullOrEmpty(hodoInicial.ToString()))
                        (bsPneu.Current as TRegistro_LanPneu).HodometroInicial = Convert.ToInt32(hodoInicial.ToString());
                }
            }
        }

        private void veiculoDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pId_veiculoDestino = BuscarVeiculo(true);
                BuscarRodadoVeiculo();
            }
        }

        private void filtroVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pId_veiculo = BuscarVeiculo(false);
                afterBusca();
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void gPneu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ALMOXARIFADO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RODANDO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("MANUTENÇÃO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void bsPneu_CurrentChanged(object sender, EventArgs e)
        {
            if (bsPneu.Current == null)
                return;

            if ((bsPneu.Current as TRegistro_LanPneu).Status.Equals("ALMOXARIFADO"))
                Ed_HodoInicial.Enabled = false;
            else
                Ed_HodoInicial.Enabled = true;
        }

        private void veiculoDestino_TextChanged(object sender, EventArgs e)
        {
            if (veiculoDestino.Text.Replace("-", "").Trim().Length.Equals(7))
            {
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "replace(a.placa, '-', '')", "'" + veiculoDestino.Text.Replace("-", "").Trim() + "'");
                object obj = new TCD_CadVeiculo().BuscarEscalar(tpBuscas, "a.id_veiculo");
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                {
                    pId_veiculoDestino = obj.ToString();
                    BuscarRodadoVeiculo();
                }
                else
                {
                    pId_veiculoDestino = string.Empty;
                    pId_veiculoDestino = BuscarVeiculo(true);
                    BuscarRodadoVeiculo();
                }
            }
            else
                bsRodado.Clear();
        }

        private void filtroVeiculo_TextChanged(object sender, EventArgs e)
        {
            if (filtroVeiculo.Text.Replace("-", "").Trim().Length.Equals(7))
            {
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "replace(a.placa, '-', '')", "'" + filtroVeiculo.Text.Replace("-", "").Trim() + "'");
                object obj = new TCD_CadVeiculo().BuscarEscalar(tpBuscas, "a.id_veiculo");
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                {
                    pId_veiculo = obj.ToString();
                    afterBusca();
                }
                else
                    pId_veiculo = BuscarVeiculo(false);
            }
        }

        private void bsRodado_CurrentChanged(object sender, EventArgs e)
        {
            if (bsRodado.Current == null)
                return;

            if (!string.IsNullOrEmpty((bsRodado.Current as TRegistro_Rodado).Id_pneu))
                Ed_ProfundidadeDestino.Enabled = true;
            else
                Ed_ProfundidadeDestino.Enabled = false;
        }
    }
}
