using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using Utils;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Estoque.Cadastros
{
    public partial class TFCad_TpProduto_X_Clifor : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_TpProduto_X_Clifor()
        {
            InitializeComponent();
            DTS = BS_CadTpProduto_X_Clifor;
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
                return TCN_CadTpProduto_X_Clifor.Grava_CadTpProduto_X_Clifor(BS_CadTpProduto_X_Clifor.Current as TRegistro_CadTpProduto_X_Clifor);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadTpProduto_X_Clifor lista = TCN_CadTpProduto_X_Clifor.Busca(CD_Clifor.Text, TP_Produto.Text);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadTpProduto_X_Clifor.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadTpProduto_X_Clifor.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadTpProduto_X_Clifor.AddNew();
                base.afterNovo();
                CD_Clifor.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadTpProduto_X_Clifor.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_TPProduto.Enabled = false;
            BB_Clifor.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (G_TpProduto_X_Clifor.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTpProduto_X_Clifor.Deleta_CadTpProduto_X_Clifor(BS_CadTpProduto_X_Clifor.Current as TRegistro_CadTpProduto_X_Clifor);
                        BS_CadTpProduto_X_Clifor.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                    new TCD_CadClifor());
        }

        private void CD_Clifor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TP_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void BB_TPProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "Tp_Produto|Cód. Tipo Produto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Produto, DS_TPProduto },
                                    new TCD_CadTpProduto(), "");
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = TP_Produto.NM_CampoBusca + "|=|'" + TP_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Produto, DS_TPProduto },
                                    new TCD_CadTpProduto());
        }

        private void TFCad_TpProduto_X_Clifor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, G_TpProduto_X_Clifor);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_TpProduto_X_Clifor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, G_TpProduto_X_Clifor);
        }
    }
}