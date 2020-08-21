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
    public partial class TFRel_DiarioContabil : Form
    {
        private bool Altera_relatorio = false;

        public TFRel_DiarioContabil()
        {
            InitializeComponent();
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
            BindingSource bs_diario = new BindingSource();
            bs_diario.DataSource = new CamadaDados.Contabil.TCD_LanctosCTB().SelectDiarioContabil(cbEmpresa.SelectedValue.ToString(),
                                                                                                  DateTime.Parse(dt_ini.Text),
                                                                                                  DateTime.Parse(dt_fin.Text));
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_relatorio;
                Rel.DTS_Relatorio = bs_diario;
                Rel.Nome_Relatorio = "REL_CTB_DIARIOCONTABIL";
                Rel.NM_Classe = "REL_CTB_DIARIOCONTABIL";
                Rel.Modulo = "CTB";
                Rel.Parametros_Relatorio.Add("DT_INI", dt_ini.Text);
                Rel.Parametros_Relatorio.Add("DT_FIN", dt_fin.Text);
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DIÁRIO CONTABIL";

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
                                       "RELATORIO DIÁRIO CONTABIL",
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
                                           "RELATORIO DIÁRIO CONTABIL",
                                           fImp.pDs_mensagem);
            }
        }

        private void TFRel_DiarioContabil_Load(object sender, EventArgs e)
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
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRel_DiarioContabil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
