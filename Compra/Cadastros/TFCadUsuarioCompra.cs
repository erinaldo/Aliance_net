using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Compra;
using CamadaNegocio.Compra;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Diversos;
using System.Collections;

namespace Compra.Cadastros
{
    public partial class TFCadUsuarioCompra : FormCadPadrao.FFormCadPadrao
    {
        public TFCadUsuarioCompra()

        {
            
            InitializeComponent();
            DTS = bs_userCompra;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bs_userCompra.AddNew();
                base.afterNovo();                
                cd_clifor_cmp.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bs_userCompra.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                tp_usuario.Focus();
        }

        public override void excluirRegistro()
        {
            if (bs_userCompra.DataSource != null)
            {
                try
                {
                    if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    {
                        if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            TCN_CadUsuarioCompra.DeletaUsuarioCompra(bs_userCompra.Current as TRegistro_CadUsuarioCompra, null);
                            bs_userCompra.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Não existem itens cadastrados", "Mensagem");
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return TCN_CadUsuarioCompra.GravaUsuarioCompra(bs_userCompra.Current as TRegistro_CadUsuarioCompra, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadUsuarioCompra lista = TCN_CadUsuarioCompra.Busca(cd_clifor_cmp.Text, login.Text, false, false, false, false, 0, string.Empty, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bs_userCompra.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bs_userCompra.Clear();
                return lista.Count;
            }
            else return 0;

        }

        private void bb_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_cmp, ds_clifor_cmp }, "a.st_funcionarios|=|'S'");
        }

        private void cd_clifor_cmp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor_cmp.Text + "';a.st_funcionarios|=|'S'", new Componentes.EditDefault[] { cd_clifor_cmp, ds_clifor_cmp }
                ,new TCD_CadClifor());
        }

        private void bb_login_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("login|Login|80;Nome_usuario|Nome Login|350",
                new Componentes.EditDefault[] { login, ds_login}, new TCD_CadUsuario(), "");

        }

        private void login_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("login|=|'" + login.Text + "'", new Componentes.EditDefault[] { login, ds_login}
                , new TCD_CadUsuario());
        }

        private void TFCadUsuarioCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPesquisa);
            pFlag.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void gPesquisa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPesquisa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bs_userCompra.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadUsuarioCompra());
            TList_CadUsuarioCompra lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPesquisa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPesquisa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadUsuarioCompra(lP.Find(gPesquisa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPesquisa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadUsuarioCompra(lP.Find(gPesquisa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPesquisa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bs_userCompra.List as TList_CadUsuarioCompra).Sort(lComparer);
            bs_userCompra.ResetBindings(false);
            gPesquisa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadUsuarioCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPesquisa);
        }
    }
}
