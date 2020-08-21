using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro.Relatorio
{
    public partial class TFRelMovimentoCaixa : Form
    {
        private bool Altera_Relatorio = false;

        public TFRelMovimentoCaixa()
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
                Utils.TpBusca[] filtro = new Utils.TpBusca[6];
                //Data Inicial
                filtro[0].vNM_Campo = "d.dt_lancto";
                filtro[0].vOperador = ">=";
                filtro[0].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                //Data Final
                filtro[1].vNM_Campo = "d.dt_lancto";
                filtro[1].vOperador = "<=";
                filtro[1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
                //Conta Gerencial
                filtro[2].vNM_Campo = "d.cd_contager";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'" + cd_ContaGer.Text.Trim() + "'";
                //Duplicata Ativa
                filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[3].vOperador = "<>";
                filtro[3].vVL_Busca = "'C'";
                //Caixa Ativa
                filtro[4].vNM_Campo = "isnull(d.st_estorno, 'N')";
                filtro[4].vOperador = "<>";
                filtro[4].vVL_Busca = "'S'";
                //Valor a pagar ou valor a receber tem que ser maior que zero
                filtro[5].vNM_Campo = string.Empty;
                filtro[5].vOperador = string.Empty;
                filtro[5].vVL_Busca = "(((case when f.TP_MOV = 'P' then ISNULL(c.VL_Liquidacao_padrao, 0) - " +
                                      "     							  ISNULL(c.Vl_DescontoBonus, 0) " +
                                      "						              else 0 end) > 0) or " +
                                      "((case when f.TP_MOV = 'R' then ISNULL(c.VL_Liquidacao_padrao, 0) - " +
                                      "							ISNULL(c.Vl_DescontoBonus, 0) " +
                                      "						else 0 end) > 0))";
                if (cd_Empresa.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "d.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_Empresa.Text.Trim() + "'";
                }
                if (clbTpDocto.Vl_Busca.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Tp_Docto";
                    filtro[filtro.Length - 1].vOperador = "not in";
                    filtro[filtro.Length - 1].vVL_Busca = "(" + clbTpDocto.Vl_Busca.Trim() + ")";
                }
                //Buscar registros de caixa
                BindingSource bs_regcaixa = new BindingSource();
                bs_regcaixa.DataSource = new CamadaDados.Financeiro.Caixa.TCD_RelMovCaixaTpDocto().Buscar(filtro, string.Empty, "d.dt_lancto asc");
                //Buscar Saldo Anterior Caixa
                filtro = new Utils.TpBusca[4];
                //Menor que a data inicial
                filtro[0].vNM_Campo = "d.dt_lancto";
                filtro[0].vOperador = "<";
                filtro[0].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                //Conta Gerencial
                filtro[1].vNM_Campo = "d.cd_contager";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + cd_ContaGer.Text.Trim() + "'";
                //Duplicata Ativa
                filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                //Caixa ativo
                filtro[3].vNM_Campo = "isnull(d.st_estorno, 'A')";
                filtro[3].vOperador = "<>";
                filtro[3].vVL_Busca = "'S'";
                if (cd_Empresa.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "d.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_Empresa.Text.Trim() + "'";
                }
                if (clbTpDocto.Vl_Busca.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Tp_Docto";
                    filtro[filtro.Length - 1].vOperador = "not in";
                    filtro[filtro.Length - 1].vVL_Busca = "(" + clbTpDocto.Vl_Busca.Trim() + ")";
                }
                object obj = new CamadaDados.Financeiro.Caixa.TCD_RelMovCaixaTpDocto().BuscarEscalar(filtro,
                    "sum((case when f.TP_MOV = 'R' then ISNULL(c.VL_Liquidacao_padrao, 0) + " +
                    "											ISNULL(c.Vl_JuroAcrescimo, 0) - " +
                    "											ISNULL(c.Vl_DescontoBonus, 0) " +
                    "										else 0 end) - " +
                    "(case when f.TP_MOV = 'P' then ISNULL(c.VL_Liquidacao_padrao, 0) + " +
                    "										  ISNULL(c.Vl_JuroAcrescimo, 0) - " +
                    "										  ISNULL(c.Vl_DescontoBonus, 0) " +
                    "									 else 0 end)) ");
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bs_regcaixa;
                    Rel.Nome_Relatorio = "REST_LiqTpDocto";
                    Rel.NM_Classe = "REST_LiqTpDocto";
                    Rel.Modulo = string.Empty;
                    if(obj != null)
                        try
                        {
                            Rel.Parametros_Relatorio.Add("SALDOANTERIOR", Convert.ToDecimal(obj.ToString()));
                        }
                        catch { }
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LIQUIDAÇÕES POR TIPO DE DOCUMENTO";

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
                                           "RELATORIO LIQUIDAÇÕES POR TIPO DE DOCUMENTO",
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
                                               "RELATORIO LIQUIDAÇÕES POR TIPO DE DOCUMENTO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void TFRelMovimentoCaixa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar Tipo de Documento
            clbTpDocto.Display = "DS_TPDocto";
            clbTpDocto.Value = "TP_Docto";
            clbTpDocto.Tabela = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup().Buscar(null, 0);
        }

        private void TFRelMovimentoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (cd_ContaGer.Text != "")
                vParam += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = '" + cd_ContaGer.Text + "' and k.cd_Empresa = a.cd_empresa )";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam); 
        }

        private void cd_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (cd_ContaGer.Text != "")
                vColunas += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = '" + cd_ContaGer.Text + "' and k.cd_Empresa = a.cd_empresa )";

            UtilPesquisa.EDIT_LEAVE(vColunas,
                                    new Componentes.EditDefault[] { cd_Empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";

            string vCond = "";
            if (cd_Empresa.Text != "")
                vCond = "|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_Empresa.Text + "' )|";


            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ContaGer, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void cd_ContaGer_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_ContaGer|=|'" + cd_ContaGer.Text + "'";

            if (cd_Empresa.Text != "")
                vColunas += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_Empresa.Text + "')|";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_ContaGer, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }
    }
}
