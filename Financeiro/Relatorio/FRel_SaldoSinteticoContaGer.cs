using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Relatorio
{
    public partial class TFRel_SaldoSinteticoContaGer : Form
    {
        private bool Altera_Relatorio = false;

        public TFRel_SaldoSinteticoContaGer()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            this.pDados.LimparRegistro();
        }

        private void afterPrint()
        {
            if (pDados.validarCampoObrigatorio())
            {
                //Montar filtros da consulta
                BindingSource bs_saldo = new BindingSource();
                if (!string.IsNullOrEmpty(clbContaGer.Vl_Busca))
                    bs_saldo.DataSource = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().RelSinteticoContaGer(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_contager",
                                vOperador = "in",
                                vVL_Busca = "(" + clbContaGer.Vl_Busca.Trim() + ")"
                            }
                        });
                else if (!cbContaProvisao.Checked)
                    bs_saldo.DataSource = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().RelSinteticoContaGer(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'N'"
                            }
                        });
                else
                    bs_saldo.DataSource = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().RelSinteticoContaGer(null);
                
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bs_saldo;
                    Rel.Nome_Relatorio = "REST_SALDOSINTETICOCONTAS";
                    Rel.NM_Classe = "REST_SALDOSINTETICOCONTAS";
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO SALDO SINTETICO CONTAS GERENCIAIS";
                    Rel.Parametros_Relatorio.Add("CD_MOEDA_PADRAO", cd_moeda_padrao.Text);
                    Rel.Parametros_Relatorio.Add("DS_MOEDA_PADRAO", ds_moeda_padrao.Text);
                    Rel.Parametros_Relatorio.Add("SIGLA_MOEDA_PADRAO", sigla_moeda_padrao.Text);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "RELATORIO SALDO SINTETICO CONTAS GERENCIAIS",
                                                    fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO SALDO SINTETICO CONTAS GERENCIAIS",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void BuscarContaGer()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(cd_Empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                      "where x.cd_contager = a.cd_contager " +
                                      "and x.cd_empresa = '" + cd_Empresa.Text.Trim() + "')";
            }
            if (!cbContaProvisao.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_contacompensacao, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'N'";
            }
            clbContaGer.Tabela = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().Buscar(filtro, 0);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
            clbContaGer.Items.Clear();
            this.BuscarContaGer();
        }

        private void cd_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas,
                                    new Componentes.EditDefault[] { cd_Empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            clbContaGer.Items.Clear();
            this.BuscarContaGer();
        }

        private void TFRel_SaldoSinteticoContaGer_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            clbContaGer.Display = "DS_ContaGer";
            clbContaGer.Value = "CD_ContaGer";
            //Buscar Moeda Padrao
            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadMoeda.Buscar(CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("CD_MOEDA_PADRAO", null),
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1,
                                                                       string.Empty,
                                                                       null);
            if (lMoeda.Count > 0)
            {
                cd_moeda_padrao.Text = lMoeda[0].Cd_moeda;
                ds_moeda_padrao.Text = lMoeda[0].Ds_moeda_singular;
                sigla_moeda_padrao.Text = lMoeda[0].Sigla;
            }

            BuscarContaGer();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRel_SaldoSinteticoContaGer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbContaProvisao_CheckStateChanged(object sender, EventArgs e)
        {
            clbContaGer.Items.Clear();
            this.BuscarContaGer();
        }

        private void cbMarcaDesmarca_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbContaGer.Items.Count; i++)
                clbContaGer.SetItemChecked(i, cbMarcaDesmarca.Checked);
        }
    }
}
