using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFLiquidarContasPagar : Form
    {
        private int countComissao = 0;
        private string Nome = string.Empty;
        public TFLiquidarContasPagar()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 20) * 1;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 20) * 1;
        }

        private void ValidarCampos()
        {
            bb_contager.Enabled = !ProgressBar.Visible;
            cd_contager.Enabled = !ProgressBar.Visible;
            CD_Portador.Enabled = !ProgressBar.Visible;
            BB_Portador.Enabled = !ProgressBar.Visible;
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue != null && ProgressBar.Visible == false)
            {
                TpBusca[] vBusca = new TpBusca[6];
                //Duplicata cancelada
                vBusca[0].vNM_Campo = "isnull(dup.st_registro, 'A')";
                vBusca[0].vOperador = "<>";
                vBusca[0].vVL_Busca = "'C'";
                //Verificar se usuario tem acesso a empresa
                vBusca[1].vNM_Campo = string.Empty;
                vBusca[1].vOperador = "exists";
                vBusca[1].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Empresa x " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "') ";
                //Verificar se ussuario tem acesso a TP.Duplicata
                vBusca[2].vNM_Campo = string.Empty;
                vBusca[2].vOperador = "exists";
                vBusca[2].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                        "where x.tp_duplicata = a.tp_duplicata " +
                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
                //Retirar da busca parcelas agrupadas e liquidadas
                vBusca[3].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[3].vOperador = "<>";
                vBusca[3].vVL_Busca = "'G'";
                vBusca[4].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[4].vOperador = "<>";
                vBusca[4].vVL_Busca = "'L'";
                //Tipo Movimento
                vBusca[5].vNM_Campo = "a.tp_mov";
                vBusca[5].vOperador = "=";
                vBusca[5].vVL_Busca = "'P'";
                if (!string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
                    Utils.Estruturas.CriarParametro(ref vBusca, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'");
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                    Utils.Estruturas.CriarParametro(ref vBusca, "a.cd_clifor", "'" + CD_Clifor.Text.Trim() + "'");
                if (!string.IsNullOrEmpty(DT_Inicial.Text) && DT_Inicial.Text.Trim() != "/  /")
                    Utils.Estruturas.CriarParametro(ref vBusca, "a.DT_Vencto", "'" + DT_Inicial.Data.ToString("yyyyMMdd") + " 00:00'", ">=");
                if (!string.IsNullOrEmpty(DT_Final.Text) && DT_Final.Text.Trim() != "/  /")
                    Utils.Estruturas.CriarParametro(ref vBusca, "a.DT_Vencto", "'" + DT_Final.Data.ToString("yyyyMMdd") + " 23:59'", "<=");
                bsParcelas.DataSource = new TCD_LanParcela().Select(vBusca, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                SomarCamposParcelas();
            }
        }

        private void afterGrava()
        {
            if (ProgressBar.Visible == false)
            {
                if (string.IsNullOrEmpty(cd_contager.Text))
                {
                    MessageBox.Show("Obrigatório informar Conta Gerencial!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_contager.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CD_Portador.Text))
                {
                    MessageBox.Show("Obrigatório informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Portador.Focus();
                    return;
                }
                if(string.IsNullOrWhiteSpace(dt_liquidacao.Text.SoNumero()))
                {
                    MessageBox.Show("Obrigatório informar data liquidação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_liquidacao.Focus();
                    return;
                }
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void afterLiquidar()
        {
            if (bsParcelas.Current != null)
            {
                if ((bsParcelas.DataSource as TList_RegLanParcela).Exists(p => p.St_processar))
                {
                    try
                    {
                        //Gravar liquidacao
                        countComissao = int.Parse((bsParcelas.DataSource as TList_RegLanParcela)
                                       .FindAll(x => x.St_processar).Count.ToString());
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.LiquidarListaContasPagar(bsParcelas.DataSource as TList_RegLanParcela,
                                                                                                      cd_contager.Text,
                                                                                                      CD_Portador.Text,
                                                                                                      DateTime.Parse(dt_liquidacao.Text),
                                                                                                      ref backgroundWorker1,
                                                                                                      ref Nome,
                                                                                                      null);
                        backgroundWorker1.ReportProgress(countComissao);
                        MessageBox.Show("Parcelas liquidadas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Selecione uma parcela para liquidar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SomarVlSelecionado()
        {
            if (bsParcelas.Count > 0)
                soma_atual_p.Value = (bsParcelas.DataSource as TList_RegLanParcela).FindAll(p => p.St_processar && p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.cVl_atual);
        }

        private void SomarCamposParcelas()
        {
            //Pagar
            Tot_Parcelas.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_parcela_padrao);
            Tot_Atual.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.cVl_atual);
        }

        private void TFLiquidarContasPagar_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor }, new TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, String.Empty);
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                if (ProgressBar.Visible == true)
                {
                    MessageBox.Show("Existe um processo de liquidação em andamento aguarde a finalização!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (e.ColumnIndex == 0)
                {
                    (bsParcelas.Current as TRegistro_LanParcela).St_processar =
                        !(bsParcelas.Current as TRegistro_LanParcela).St_processar;
                    SomarVlSelecionado();
                }
                else if ((e.ColumnIndex == 2) && (bsParcelas.Current as TRegistro_LanParcela).St_agrupador.Trim().ToUpper().Equals("S"))
                    using (TFListaParcelasAgrupadas fLista = new TFListaParcelasAgrupadas())
                    {
                        fLista.Cd_empresa = (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa;
                        fLista.Nr_lancto = (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr;
                        fLista.ShowDialog();
                    }
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                if (ProgressBar.Visible == true)
                {
                    MessageBox.Show("Existe um processo de liquidação em andamento aguarde a finalização!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsParcelas.DataSource as TList_RegLanParcela).ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcelas.ResetBindings(true);
                SomarVlSelecionado();
            }
        }

        private void bb_LIQUIDAR_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "'; " +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (!string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "where x.cd_contager = a.cd_contager " +
                          "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (!string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
                vParamFixo += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
        }

        private void BB_Portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Portador|350;" +
                              "CD_Portador|Cód. Portador|100";
            string vParam = "isnull(a.ST_CartaFrete, 'N')|=| 'N';" +
                              "isnull(a.st_cartaocredito, 1)|=|1;" +
                              "isnull(a.ST_TituloTerceiro, 'N')|=|'N';" +
                              "isnull(a.ST_controletitulo, 'N')|=|'N';" +
                              "isnull(a.ST_DevCredito, 'N')|=|'N';" +
                              "isnull(a.ST_EntregaFutura, 'N')|=|'N';" +
                              "isnull(a.tp_portadorpdv, 'A')|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Portador, DS_Portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Portador|=|'" + CD_Portador.Text + "';" +
                              "isnull(a.ST_CartaFrete, 'N')|=|'N';" +
                              "isnull(a.st_cartaocredito, 1)|=|1;" +
                              "isnull(a.ST_TituloTerceiro, 'N')|=|'N';" +
                              "isnull(a.ST_controletitulo, 'N')|=|'N';" +
                              "isnull(a.ST_DevCredito, 'N')|=|'N';" +
                              "isnull(a.ST_EntregaFutura, 'N')|=|'N';" +
                              "isnull(a.tp_portadorpdv, 'A')|=|'A'";
            DataRow reg = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Portador, DS_Portador },
                               new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void TFLiquidarContasPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            afterLiquidar();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Visible = true;
            lbCompletar.Visible = true;
            ValidarCampos();
            decimal cem = 100;
            if (Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0) <= 100)
            {
                ProgressBar.Value = int.Parse(Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0).ToString());
                lbCompletar.Text = int.Parse(Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0).ToString()) + "% " + Nome;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visible = false;
            lbCompletar.Visible = false;
            afterBusca();
            ValidarCampos();
        }

        private void TFLiquidarContasPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProgressBar.Visible == true)
            {
                MessageBox.Show("Existe um processo de liquidação em andamento aguarde a finalização!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }
    }
}
