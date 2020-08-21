using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class FCadAreaFazenda : FormCadPadrao.FFormCadPadrao
    {
        public FCadAreaFazenda()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVA", "A"));
            cbx.Add(new Utils.TDataCombo("INATIVA", "I"));
            cbx.Add(new Utils.TDataCombo("ARRENDADA", "R"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (area_pastagem.Focused)
                    (bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area).Area_pastagem =
                        area_pastagem.Value;
                if (area_preservacao.Focused)
                    (bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area).Area_preservacao =
                        area_preservacao.Value;
                if (area_producao.Focused)
                    (bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area).Area_producao =
                        area_producao.Value;
                return CamadaNegocio.Fazenda.Cadastros.TCN_Area.Gravar(bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Area lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Area.Buscar(cd_fazenda.Text,
                                                                string.Empty,
                                                                ds_area.Text,
                                                                null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsArea.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsArea.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsArea.AddNew();
                base.afterNovo();
                cd_fazenda.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsArea.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_fazenda.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_area.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Area.Excluir(
                        bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area, null);
                    bsArea.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Fazenda|150;" +
                              "a.cd_fazenda|Cd. Fazenda|80;" +
                              "c.Sigla_Unidade|UND|80";
            string vParam = "isnull(b.st_registro, 'A')|<>|'C'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                    new CamadaDados.Fazenda.Cadastros.TCD_Fazenda(), vParam);
            if ((linha != null) && (bsArea.Current != null))
            {
                (bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsArea.ResetCurrentItem();
            }
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "isnull(b.st_registro, 'A')|<>|'C'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                new CamadaDados.Fazenda.Cadastros.TCD_Fazenda());
            if ((linha != null) && (bsArea.Current != null))
            {
                (bsArea.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Area).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsArea.ResetCurrentItem();
            }
        }

        private void FCadAreaFazenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gArea);
            this.pDados.set_FormatZero();
        }

        private void gArea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("INATIVA"))
                        gArea.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ARRENDADA"))
                        gArea.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gArea.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gArea_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gArea.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsArea.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fazenda.Cadastros.TRegistro_Area());
            CamadaDados.Fazenda.Cadastros.TList_Area lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gArea.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gArea.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Area(lP.Find(gArea.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gArea.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Area(lP.Find(gArea.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gArea.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsArea.List as CamadaDados.Fazenda.Cadastros.TList_Area).Sort(lComparer);
            bsArea.ResetBindings(false);
            gArea.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void FCadAreaFazenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gArea);
        }
    }
}
