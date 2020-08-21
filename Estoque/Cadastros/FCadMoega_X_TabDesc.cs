using System;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;
using FormBusca;
using CamadaDados.Graos;

namespace Estoque.Cadastros
{
    public partial class TFCadMoega_X_TabDesc : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMoega_X_TabDesc()
        {
            InitializeComponent();
            DTS = BS_CadMoega_X_TabDesc;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadMoega_X_TabDesc.Grava_CadMoega_X_TabDesc(BS_CadMoega_X_TabDesc.Current as TRegistro_CadMoega_X_TabDesc);
            else return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadMoega_X_TabDesc lista = TCN_CadMoega_X_TabDesc.Busca(CD_Moega.Text,
                                                                          CD_TabelaDesconto.Text,
                                                                          string.Empty);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadMoega_X_TabDesc.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadMoega_X_TabDesc.Clear();
                return lista.Count;
            }
            else return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadMoega_X_TabDesc.AddNew();
                base.afterNovo();
                if (!CD_Moega.Focus())
                    CD_TabelaDesconto.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadMoega_X_TabDesc.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_Moega.Enabled = false;
            BB_TabelaDesconto.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (g_FCadMoega_X_Tab_Desconto.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadMoega_X_TabDesc.Deleta_CadMoega_X_TabDesc(BS_CadMoega_X_TabDesc.Current as TRegistro_CadMoega_X_TabDesc);
                        BS_CadMoega_X_TabDesc.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_Moega_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moega|Descrição da Moega|350;" +
                              "CD_Moega|Cód. Moega|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega },
                                    new TCD_CadMoega(), "");
        }

        private void CD_Moega_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_Moega.NM_CampoBusca + "|=|'" + CD_Moega.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moega, DS_Moega },
                                    new TCD_CadMoega());
        }

        private void BB_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Descrição Tabela de Desconto|350;" +
                              "CD_TabelaDesconto|Cód. Tabela de Desconto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, DS_TabelaDesconto },
                                    new TCD_CadDesconto(), "");
        }

        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_TabelaDesconto.NM_CampoBusca + "|=|'" + CD_TabelaDesconto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_TabelaDesconto, DS_TabelaDesconto },
                                    new TCD_CadDesconto());
        }

        private void CD_Moega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void CD_TabelaDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TFCadMoega_X_TabDesc_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_FCadMoega_X_Tab_Desconto);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadMoega_X_TabDesc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_FCadMoega_X_Tab_Desconto);
        }
    }
}