using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCad_LocalArm_X_Produto : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_LocalArm_X_Produto()
        {
            InitializeComponent();
            DTS = BS_CadLocalArm_X_Produto;
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
                return TCN_CadLocalArm_X_Produto.Grava_CadLocalArm_X_Produto(BS_CadLocalArm_X_Produto.Current as TRegistro_CadLocalArm_X_Produto);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadLocalArm_X_Produto lista = TCN_CadLocalArm_X_Produto.Busca(CD_Local.Text, CD_Produto.Text);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadLocalArm_X_Produto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadLocalArm_X_Produto.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadLocalArm_X_Produto.AddNew();
                base.afterNovo();
                if (!CD_Local.Focus())
                    CD_Produto.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadLocalArm_X_Produto.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            BB_Local.Enabled = false;
            BB_Produto.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if (g_CadLocalArm_X_Produto.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadLocalArm_X_Produto.Deleta_CadLocalArm_X_Produto(BS_CadLocalArm_X_Produto.Current as TRegistro_CadLocalArm_X_Produto);
                        BS_CadLocalArm_X_Produto.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Local Armazenagem|350;" +
                              "CD_Local|Cód. Local|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_local|=|'" + CD_Local.Text + "';" +
                               "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm());
        }
       
        private void BB_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto },"");
        }
       
        private void CD_PRODUTO_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                    new TCD_CadProduto());
        }

        private void CD_Local_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void CD_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void TFCad_LocalArm_X_Produto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_CadLocalArm_X_Produto);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_LocalArm_X_Produto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_CadLocalArm_X_Produto);
        }
    }
}