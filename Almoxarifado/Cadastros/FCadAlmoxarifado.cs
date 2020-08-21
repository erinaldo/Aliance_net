using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Estoque;
using Utils;
using FormBusca;
using CamadaDados.Estoque.Cadastros;


namespace Almoxarifado.Cadastros
{
    public partial class TFCadAlmoxarifado : FormCadPadrao.FFormCadPadrao
    {
        public TFCadAlmoxarifado()
        {
            InitializeComponent();
            DTS = BS_CadAlmoxarifado;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadAlmoxarifado.RemoveCurrent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadAlmoxarifado.AddNew();
            base.afterNovo();
            id_almoxarif.Focus();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadAlmoxarifado.Gravar(BS_CadAlmoxarifado.Current as TRegistro_CadAlmoxarifado, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadAlmoxarifado lista = TCN_CadAlmoxarifado.Busca(id_almoxarif.Text, 
                                                                    Nm_Almox.Text,
                                                                    null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadAlmoxarifado.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadAlmoxarifado.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadAlmoxarifado.Excluir(BS_CadAlmoxarifado.Current as TRegistro_CadAlmoxarifado, null);
                    BS_CadAlmoxarifado.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void gAlmoxarif_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAlmoxarif.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadAlmoxarifado.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_CadAlmoxarifado());
            CamadaDados.Almoxarifado.TList_CadAlmoxarifado lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAlmoxarif.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAlmoxarif.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadAlmoxarifado(lP.Find(gAlmoxarif.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAlmoxarif.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_CadAlmoxarifado(lP.Find(gAlmoxarif.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAlmoxarif.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadAlmoxarifado.List as CamadaDados.Almoxarifado.TList_CadAlmoxarifado).Sort(lComparer);
            BS_CadAlmoxarifado.ResetBindings(false);
            gAlmoxarif.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
