using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using System;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFAltEndEntrega : Form
    {
        public CamadaDados.Locacao.TRegistro_Locacao Locacao { get; set; }

        public TFAltEndEntrega()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pEndereco.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void Cep_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Cep.Text.SoNumero())))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(Cep.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            Ds_end.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            CD_Cidade.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            Bairro.Text = valida.bairro;
                        CD_Cidade_Leave(this, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void BB_Cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade(), string.Empty);
        }

        private void CD_Cidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_Cidade.Text + "'",
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFAltEndEntrega_Load(object sender, EventArgs e)
        {
            bsLocacao.DataSource = new CamadaDados.Locacao.TList_Locacao { Locacao };
        }

        private void TFAltEndEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
