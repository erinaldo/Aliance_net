using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabil.Relatorio
{
    public partial class TFRel_DRE : Form
    {
        private bool Altera_relatorio = false;

        public TFRel_DRE()
        {
            InitializeComponent();
        }

        private void afterPrint()
        {
            if (string.IsNullOrEmpty(cbAno.Text))
            {
                MessageBox.Show("Obrigatorio informar ano Exercicio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbAno.Focus();
                return;
            }
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbDRE.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar DRE.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BindingSource bs_dre = new BindingSource();
            bs_dre.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.GerarDRE(cbEmpresa.SelectedValue.ToString(),
                                                                                cbDRE.SelectedValue.ToString(),
                                                                                decimal.Parse(cbAno.Text));
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_relatorio;
                Rel.DTS_Relatorio = bs_dre;
                Rel.Nome_Relatorio = "REL_CTB_DRE";
                Rel.NM_Classe = "REL_CTB_DRE";
                Rel.Modulo = "CTB";

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);

                Rel.Adiciona_DataSource("EMPRESA", BinEmpresa);

                Rel.Parametros_Relatorio.Add("EXERCICIO", cbAno.Text);
                Rel.Parametros_Relatorio.Add("EXERCICIO_ANT", decimal.Parse(cbAno.Text) - 1);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DRE - DEMONSTRATIVO RESULTADO EXERCICIO";

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
                                       "RELATORIO DRE - DEMONSTRATIVO RESULTADO EXERCICIO",
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
                                           "RELATORIO DRE - DEMONSTRATIVO RESULTADO EXERCICIO",
                                           fImp.pDs_mensagem);
            }
        }

        private void TFRel_DRE_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Preencher lista empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Buscar(
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
                                    }, 0);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            //Preencher Lista DRE
            cbDRE.DataSource = new CamadaDados.Contabil.Cadastro.TCD_CTD_DRE().Select(null, 0, string.Empty, string.Empty);
            cbDRE.DisplayMember = "DS_DRE";
            cbDRE.ValueMember = "ID_DRE";
            //Preencher Lista Ano
            for (int i = -10; i <= 0; i++)
                cbAno.Items.Insert(0,DateTime.Now.AddYears(i).Year.ToString());
            if(cbEmpresa.Items.Count > 0)
                cbAno.SelectedIndex = 1;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRel_DRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_relatorio = true;
            }
        }
    }
}
