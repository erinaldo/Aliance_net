using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using System.ComponentModel;
using CamadaDados.Financeiro.Bloqueto;

namespace Financeiro
{
    public partial class TFLocalizarBloquetos : Form
    {
        public List<CamadaDados.Financeiro.Bloqueto.blTitulo> lBloquetos
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pId_Config
        { get; set; }
        public string pDs_config
        { get; set; }
        public bool St_remessa
        { get; set; }
        public string Tp_instrucao
        { get; set; }

        public TFLocalizarBloquetos()
        {
            InitializeComponent();
            Tp_instrucao = string.Empty;
        }

        private void afterBusca()
        {
            if (cbTpDuplicata.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar tipo de duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTpDuplicata.Focus();
                return;
            }
            if (St_remessa)
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[7];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_Empresa.Text.Trim() + "'";
                filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'A'";
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "exists";
                filtro[2].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.tp_duplicata = '" + cbTpDuplicata.SelectedValue.ToString().Trim() + "')";
                filtro[3].vNM_Campo = string.Empty;
                filtro[3].vOperador = Tp_instrucao.Trim().ToUpper().Equals("RT") ? "not exists" : "exists";
                filtro[3].vVL_Busca = "(select 1 from tb_cob_loteremessa_x_titulo x " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.nr_lancto = a.nr_lancto " +
                                      "and x.cd_parcela = a.cd_parcela " +
                                      "and x.id_cobranca = a.id_cobranca)";
                filtro[4].vNM_Campo = "a.tp_cobranca";
                filtro[4].vOperador = "=";
                filtro[4].vVL_Busca = "'CR'";
                filtro[5].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[5].vOperador = "<>";
                filtro[5].vVL_Busca = "'C'";
                filtro[6].vNM_Campo = "f.ID_Config";
                filtro[6].vOperador = "=";
                filtro[6].vVL_Busca = pId_Config;
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_clifor = '" + cd_clifor.Text.Trim() + "')";
                }
                if (VL_Inicial.Value > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.Vl_Parcela_Padrao";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = VL_Inicial.Value.ToString(new System.Globalization.CultureInfo("en-US"));
                }
                if (VL_Final.Value > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.Vl_Parcela_Padrao";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = VL_Final.Value.ToString(new System.Globalization.CultureInfo("en-US"));
                }
                if (DT_Inicial.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.DT_EmissaoBloqueto" :
                        RB_Vencimento.Checked ? "b.DT_Vencto" : "a.DT_Credito";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US"), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                    filtro[filtro.Length - 1].vOperador = ">=";
                }
                if (DT_Final.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.DT_EmissaoBloqueto" :
                        RB_Vencimento.Checked ? "b.DT_Vencto" : "a.DT_Credito";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US"), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
                    filtro[filtro.Length - 1].vOperador = "<=";
                }
                if (!string.IsNullOrEmpty(nr_docto.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "c.nr_docto";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'%" + nr_docto.Text.Trim() + "%'";
                }
                dsBloqueto.DataSource = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(filtro, 0, string.Empty);
            }
            else
                dsBloqueto.DataSource = CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(cd_Empresa.Text,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            VL_Inicial.Value,
                                                                                            VL_Final.Value,
                                                                                            rgData.NM_Valor,
                                                                                            DT_Inicial.Text,
                                                                                            DT_Final.Text,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            "'A'",
                                                                                            cd_clifor.Text,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            cbTpDuplicata.SelectedValue.ToString(),
                                                                                            string.Empty,
                                                                                            id_config.Text,
                                                                                            false,
                                                                                            0,
                                                                                            null);
        }

        private void afterGrava()
        {
            if(dsBloqueto.Count > 0)
                lBloquetos = (dsBloqueto.DataSource as CamadaDados.Financeiro.Bloqueto.blListaTitulo).FindAll(p => p.St_descontar.Equals(true));
            DialogResult = DialogResult.OK;
        }

        private void TFLocalizarBloquetos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBloqueto);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_Empresa.Text = pCd_empresa.Trim();
            nm_empresa.Text = pNm_empresa.Trim();
            id_config.Text = pId_Config;
            ds_config.Text = pDs_config;
            cbTpDuplicata.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            }
                                        }, 0, string.Empty);
            cbTpDuplicata.DisplayMember = "DS_TpDuplicata";
            cbTpDuplicata.ValueMember = "TP_Duplicata";
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'", new Componentes.EditDefault[] { cd_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gBloqueto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_descontar =
                    !(dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_descontar;
                dsBloqueto.ResetCurrentItem();
                vl_total_titulo.Value = (dsBloqueto.DataSource as CamadaDados.Financeiro.Bloqueto.blListaTitulo).Where(p => p.St_descontar).Sum(p => p.Vl_atual);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLocalizarBloquetos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void cbMarcarTodos_Click(object sender, EventArgs e)
        {
            if (dsBloqueto.Count > 0)
            {
                (dsBloqueto.DataSource as CamadaDados.Financeiro.Bloqueto.blListaTitulo).ForEach(p => p.St_descontar = cbMarcarTodos.Checked);
                dsBloqueto.ResetBindings(true);
                vl_total_titulo.Value = (dsBloqueto.DataSource as CamadaDados.Financeiro.Bloqueto.blListaTitulo).Where(p => p.St_descontar).Sum(p => p.Vl_atual);
            }
        }

        private void TFLocalizarBloquetos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBloqueto);
        }

        private void gBloqueto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBloqueto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (dsBloqueto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new blTitulo());
            blListaTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new blListaTitulo(lP.Find(gBloqueto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBloqueto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new blListaTitulo(lP.Find(gBloqueto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBloqueto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (dsBloqueto.List as blListaTitulo).Sort(lComparer);
            dsBloqueto.ResetBindings(false);
            gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
