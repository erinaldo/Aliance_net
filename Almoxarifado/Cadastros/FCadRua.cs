using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using Utils;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadRua : FormCadPadrao.FFormCadPadrao
    {
        public TFCadRua()
        {
            InitializeComponent();
            DTS = BS_CadRua;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!ID_Rua.Focus())
                    Ds_Rua.Focus();
            }
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadRua.RemoveCurrent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value,this.vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadRua.AddNew();
                base.afterNovo();
                if (!ID_Rua.Focus())
                    Ds_Rua.Focus();
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadRua.Gravar(BS_CadRua.Current as TRegistro_CadRua, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadRua lista = TCN_CadRua.Busca(ID_Rua.Text, Ds_Rua.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadRua.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadRua.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterExclui()
        {
            base.afterExclui();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadRua.Excluir(BS_CadRua.Current as TRegistro_CadRua, null);
                    BS_CadRua.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }

        private void gRua_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRua.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadRua.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_CadRua());
            CamadaDados.Almoxarifado.TList_CadRua lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRua.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRua.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadRua(lP.Find(gRua.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRua.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadRua(lP.Find(gRua.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRua.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadRua.List as CamadaDados.Almoxarifado.TList_CadRua).Sort(lComparer);
            BS_CadRua.ResetBindings(false);
            gRua.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}

