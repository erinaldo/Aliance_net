using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Contabil.Relatorio
{
    public partial class TFRel_RazaoContabil : Form
    {
        private bool Altera_relatorio = false;

        public TFRel_RazaoContabil()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            dt_ini.Clear();
            dt_fin.Clear();
            cd_contactb.Clear();
            dt_ini.Focus();
        }

        private void afterPrint()
        {
            if (string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ini.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_fin.Focus();
                return;
            }
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BindingSource bs_razao = new BindingSource();
            bs_razao.DataSource = new CamadaDados.Contabil.TCD_LanctosCTB().SelectRazaoContabil(cbEmpresa.SelectedValue.ToString(), 
                                                                                                cd_contactb.Text, 
                                                                                                string.Empty,
                                                                                                DateTime.Parse(dt_ini.Text), 
                                                                                                DateTime.Parse(dt_fin.Text));
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_relatorio;
                Rel.DTS_Relatorio = bs_razao;
                Rel.Nome_Relatorio = "REL_CTB_RAZAOCONTABIL";
                Rel.NM_Classe = "REL_CTB_RAZAOCONTABIL";
                Rel.Modulo = "CTB";

                BindingSource bsEmpresa = new BindingSource();
                bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa() { cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa };
                Rel.Adiciona_DataSource("DS_EMPRESA", bsEmpresa);

                Rel.Parametros_Relatorio.Add("DT_INI", dt_ini.Text);
                Rel.Parametros_Relatorio.Add("DT_FIN", dt_fin.Text);
                Rel.Parametros_Relatorio.Add("TERMO_ABERTURA", st_termoabertura.Checked ? "S" : "N");
                Rel.Parametros_Relatorio.Add("TERMO_ENCERRAMENTO", st_termoencerramento.Checked ? "S" : "N");
                Rel.Parametros_Relatorio.Add("NR_LIVRO", nr_livro.Text);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO RAZÃO CONTABIL";

                if (Altera_relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO RAZÃO CONTABIL",
                                       fImp.pDs_mensagem);
                    Altera_relatorio = false;
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
                                           "RELATORIO RAZÃO CONTABIL",
                                           fImp.pDs_mensagem);
            }
        }

        private void TFRel_RazaoContabil_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Preencher lista empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbEmpresa.SelectedIndex = 0;
        }

        private void bb_contactb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                cd_contactb.Text = string.IsNullOrEmpty(cd_contactb.Text) ? rConta.Cd_conta_ctbstr.Trim() : cd_contactb.Text.Trim() + "," + rConta.Cd_conta_ctbstr.Trim();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.LimparFiltros();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRel_RazaoContabil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.LimparFiltros();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
