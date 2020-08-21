using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Balanca.Cadastros
{
    public partial class TFCadTpDesdobroEspecial : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpDesdobroEspecial()
        {
            InitializeComponent();
            this.DTS = bsTpDesdobroEspecial;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PESO BRUTO", "B"));
            cbx.Add(new Utils.TDataCombo("PESO LIQUIDO", "L"));
            tp_pesodesdobro.DataSource = cbx;
            tp_pesodesdobro.DisplayMember = "Display";
            tp_pesodesdobro.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_desdobro.Focused)
                    (bsTpDesdobroEspecial.Current as CamadaDados.Balanca.Cadastros.TRegistro_TpDesdobroEspecial).Pc_desdobro = pc_desdobro.Value;
                return CamadaNegocio.Balanca.Cadastros.TCN_TpDesdobroEspecial.Gravar(bsTpDesdobroEspecial.Current as CamadaDados.Balanca.Cadastros.TRegistro_TpDesdobroEspecial, null);
            }
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial lista =
                CamadaNegocio.Balanca.Cadastros.TCN_TpDesdobroEspecial.Buscar(id_tpdesdobro.Text,
                                                                              ds_tpdesdobro.Text,
                                                                              null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpDesdobroEspecial.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsTpDesdobroEspecial.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsTpDesdobroEspecial.AddNew();
            base.afterNovo();
            if (!id_tpdesdobro.Focus())
                ds_tpdesdobro.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_tpdesdobro.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpDesdobroEspecial.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                CamadaNegocio.Balanca.Cadastros.TCN_TpDesdobroEspecial.Excluir((bsTpDesdobroEspecial.Current as CamadaDados.Balanca.Cadastros.TRegistro_TpDesdobroEspecial), null);
                pDados.LimparRegistro();
            }
        }

        private void gTpDesdobro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpDesdobro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpDesdobroEspecial.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Balanca.Cadastros.TRegistro_TpDesdobroEspecial());
            CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpDesdobro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpDesdobro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial(lP.Find(gTpDesdobro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpDesdobro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial(lP.Find(gTpDesdobro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpDesdobro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpDesdobroEspecial.List as CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial).Sort(lComparer);
            bsTpDesdobroEspecial.ResetBindings(false);
            gTpDesdobro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
