using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fazenda.Cadastros
{
    public partial class TFCadTalhao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTalhao()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("INATIVO", "I"));
            st_registro.DataSource = cbx;
            st_registro.ValueMember = "Value";
            st_registro.DisplayMember = "Display";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (area_talhao.Value > (area_producao.Value - area_dividida.Value))
                {
                    MessageBox.Show("Area talhão não pode ser maior que saldo disponivel da area de produção para dividir.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    area_talhao.Focus();
                    return string.Empty;
                }
                if (area_talhao.Focused)
                    (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes).Area_talhao =
                        area_talhao.Value;
                return CamadaNegocio.Fazenda.Cadastros.TCN_Talhoes.Gravar(bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fazenda.Cadastros.TList_Talhoes lista =
                CamadaNegocio.Fazenda.Cadastros.TCN_Talhoes.Buscar(cd_fazenda.Text,
                                                                   id_area.Text,
                                                                   id_talhao.Text,
                                                                   ds_talhao.Text,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTalhoes.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTalhoes.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsTalhoes.AddNew();
                base.afterNovo();
                cd_fazenda.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTalhoes.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_fazenda.Enabled = false;
            bb_area.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_talhao.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fazenda.Cadastros.TCN_Talhoes.Excluir(
                        bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes, null);
                    bsTalhoes.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadTalhao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTalhoes);
            pDados.set_FormatZero();
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Fazenda|150;" +
                              "a.cd_fazenda|Cd. Fazenda|80;" +
                              "c.Sigla_Unidade|UND|80";
            string vParam = "isnull(b.st_registro, 'A')|<>|'C'";
            if (!string.IsNullOrEmpty(id_area.Text))
                vParam += ";|exists|(select 1 from tb_faz_area x " +
                          "         where x.cd_fazenda = a.cd_fazenda " +
                          "         and x.id_area = " + id_area.Text + ")";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                    new CamadaDados.Fazenda.Cadastros.TCD_Fazenda(), vParam);
            if ((linha != null) && (bsTalhoes.Current != null))
            {
                (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsTalhoes.ResetCurrentItem();
            }
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "isnull(b.st_registro, 'A')|<>|'C'";
            if (!string.IsNullOrEmpty(id_area.Text))
                vParam += ";|exists|(select 1 from tb_faz_area x " +
                          "         where x.cd_fazenda = a.cd_fazenda " +
                          "         and x.id_area = " + id_area.Text + ")";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                new CamadaDados.Fazenda.Cadastros.TCD_Fazenda());
            if ((linha != null) && (bsTalhoes.Current != null))
            {
                (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsTalhoes.ResetCurrentItem();
            }
        }

        private void bb_area_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_area|Area|200;" +
                              "a.id_area|Id. Area|80;" +
                              "a.area_producao|Area Produção|80";
            string vParam = "isnull(a.st_registro, 'A')|=|'A'";
            if (!string.IsNullOrEmpty(cd_fazenda.Text))
                vParam += ";a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_area, ds_area },
                                                                new CamadaDados.Fazenda.Cadastros.TCD_Area(), vParam);
            if ((linha != null) && (bsTalhoes.Current != null))
            {
                (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes).Area_producao =
                    decimal.Parse(linha["area_producao"].ToString());
                bsTalhoes.ResetCurrentItem();
            }
        }

        private void id_area_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_area|=|" + id_area.Text;
            if (!string.IsNullOrEmpty(cd_fazenda.Text))
                vParam += ";a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_area, ds_area },
                                                                new CamadaDados.Fazenda.Cadastros.TCD_Area());
            if ((linha != null) && (bsTalhoes.Current != null))
            {
                (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes).Area_producao =
                    decimal.Parse(linha["area_producao"].ToString());
                bsTalhoes.ResetCurrentItem();
            }
        }

        private void area_talhao_Leave(object sender, EventArgs e)
        {
            if (area_talhao.Value > (area_producao.Value - area_dividida.Value))
            {
                MessageBox.Show("Area talhão não pode ser maior que saldo disponivel da area de produção para dividir.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                area_talhao.Focus();
                return;
            }
        }

        private void gTalhoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("INATIVO"))
                        gTalhoes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gTalhoes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gTalhoes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTalhoes.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTalhoes.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Fazenda.Cadastros.TRegistro_Talhoes());
            CamadaDados.Fazenda.Cadastros.TList_Talhoes lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTalhoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTalhoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Talhoes(lP.Find(gTalhoes.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTalhoes.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Fazenda.Cadastros.TList_Talhoes(lP.Find(gTalhoes.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTalhoes.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTalhoes.List as CamadaDados.Fazenda.Cadastros.TList_Talhoes).Sort(lComparer);
            bsTalhoes.ResetBindings(false);
            gTalhoes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadTalhao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTalhoes);
        }
    }
}
