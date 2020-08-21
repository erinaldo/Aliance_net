using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using Utils;
using FormBusca;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadSecao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadSecao()
        {
            InitializeComponent();
            DTS = BS_CadSecao;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadSecao.Gravar(BS_CadSecao.Current as TRegistro_CadSecao, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadSecao lista = TCN_CadSecao.Busca(Id_Rua.Text, 
                                                      id_secao.Text,
                                                      ds_secao.Text,
                                                      null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadSecao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadSecao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadSecao.RemoveCurrent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_secao.Focus();
            bb_Rua.Enabled = false;
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadSecao.AddNew();
            base.afterNovo();
            Id_Rua.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadSecao.Excluir(BS_CadSecao.Current as TRegistro_CadSecao, null);
                    BS_CadSecao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void bb_Rua_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_rua|Nome Rua|150;id_rua|Código Rua|80"
             , new Componentes.EditDefault[] { Id_Rua, Ds_Rua }, new TCD_CadRua(), null);
        }

        private void Id_Rua_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_rua|=|'" + Id_Rua.Text + "'"
                 , new Componentes.EditDefault[] { Id_Rua, Ds_Rua }, new TCD_CadRua());
        }

        private void gSecao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gSecao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadSecao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_CadSecao());
            CamadaDados.Almoxarifado.TList_CadSecao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gSecao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gSecao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadSecao(lP.Find(gSecao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gSecao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadSecao(lP.Find(gSecao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gSecao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadSecao.List as CamadaDados.Almoxarifado.TList_CadSecao).Sort(lComparer);
            BS_CadSecao.ResetBindings(false);
            gSecao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadSecao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gSecao);
        }

        private void TFCadSecao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gSecao);
        }
    }
   
}
