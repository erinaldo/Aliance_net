using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;

namespace Financeiro.Relatorio
{
    public partial class TFRel_SaldoContasGerenciais : Form
    {
        private bool Altera_Relatorio = false;

        public TFRel_SaldoContasGerenciais()
        {
            InitializeComponent();
        }

        private void LimparRegistro()
        {
            pDados.LimparRegistro();
        }

        private void GerarRelatorio()
        {
            if (pDados.validarCampoObrigatorio())
            {
                //Buscar Saldo Contas Gerenciais
                BindingSource bsSaldo = new BindingSource();
                bsSaldo.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().SelectSaldoContas(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(a.ST_ContaCompensacao, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ST_ContaCartao",
                            vOperador = "=",
                            vVL_Busca = "1",
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ST_ContaCF",
                            vOperador = "=",
                            vVL_Busca = "1"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                        "where x.cd_contager = a.cd_contager " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                        }
                    }, 0, string.Empty, Convert.ToDateTime(new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1)).ToString("yyyyMMdd"));
                if (bsSaldo.Current != null)
                    (bsSaldo.Current as CamadaDados.Financeiro.Cadastros.TRegistro_SaldoContas).DataConsulta =
                        Convert.ToDateTime(new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1)).ToString("dd/MM/yyyy");

                //Buscar Contas Pagar/Receber Realizadas e Previstas no Mês informado
                BindingSource bsDup = new BindingSource();
                string dt_ini = Convert.ToDateTime(new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1)).ToString("yyyyMMdd");
                string dt_fin = Convert.ToDateTime(new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month), 23, 59, 59)).ToString("yyyyMMdd");
                bsDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarRelContasPagarReceberMes(cd_Empresa.Text, dt_ini, dt_fin);

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIN";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO SALDO DAS CONTAS GERENCIAIS";
                    Rel.Adiciona_DataSource("SALDOCONTASGERECIAIS", bsSaldo);
                    Rel.Adiciona_DataSource("CONTAS", bsDup);
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
                                           "RELATORIO SALDO DAS CONTAS GERENCIAIS",
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
                                                    "RELATORIO SALDO DAS CONTAS GERENCIAIS",
                                                    fImp.pDs_mensagem);
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                        , new Componentes.EditDefault[] { cd_Empresa }
                        , new TCD_CadEmpresa(),
                        "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                        "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_Empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_Empresa }, new TCD_CadEmpresa());
        }

        private void TFRel_SaldoContasGerenciais_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.LimparRegistro();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.GerarRelatorio();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFRel_SaldoContasGerenciais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.LimparRegistro();
            else if (e.KeyCode.Equals(Keys.F8))
                this.GerarRelatorio();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
