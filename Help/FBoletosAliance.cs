using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help
{
    public partial class TFBoletosAliance : Form
    {
        public List<CamadaDados.Financeiro.Bloqueto.blTitulo> lTitulos
        { get; set; }

        public TFBoletosAliance()
        {
            InitializeComponent();
        }

        private void afterPrint()
        {
            if (bsTitulo.Current != null)
            {
                CamadaDados.Financeiro.Bloqueto.blTitulo titulo =
                    ServiceRest.DataService.BuscarTitulo((bsTitulo.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_empresa,
                                                         Convert.ToInt32((bsTitulo.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Nr_lancto.Value).ToString(),
                                                         Convert.ToInt32((bsTitulo.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_parcela.Value).ToString(),
                                                         Convert.ToInt32((bsTitulo.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Id_cobranca.Value).ToString());
                if (titulo != null)
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = titulo.Cd_sacado;
                        fImp.pMensagem = "BLOQUETO Nº" + titulo.Nosso_numero.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                new CamadaDados.Financeiro.Bloqueto.blListaTitulo { titulo },
                                                                                fImp.pSt_imprimir,
                                                                                fImp.pSt_visualizar,
                                                                                fImp.pSt_enviaremail,
                                                                                fImp.pSt_exportPdf,
                                                                                fImp.Path_exportPdf,
                                                                                fImp.pDestinatarios,
                                                                                "BLOQUETO Nº " + titulo.Nosso_numero.Trim(),
                                                                                fImp.pDs_mensagem,
                                                                                false);
                    }
                else MessageBox.Show("Serviço não retornou boleto para impressão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TFBoletosAliance_Load(object sender, EventArgs e)
        {
            bsTitulo.DataSource = lTitulos;
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void pFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFBoletosAliance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
        }
    }
}
