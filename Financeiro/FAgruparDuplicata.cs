using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFAgruparDuplicata : Form
    {
        public List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParcela
        {
            get
            {
                if (bsParcelas.Count > 0)
                    return (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public decimal pVl_juro
        { get { return vl_juro.Value; } }
        public decimal pVl_desconto
        { get { return vl_desconto.Value; } }
        public bool vPorCategoria
        { get { return ID_CategoriaClifor.Enabled; } }

        public TFAgruparDuplicata()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (vl_desconto.Value >= tot_agrupar.Value)
            {
                MessageBox.Show("Valor desconto não pode ser maior que total agrupar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Tp_Dup.Text))
            {
                MessageBox.Show("Obrigatório informar tipo duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tp_Dup.Focus();
                return;
            }
            if (ID_CategoriaClifor.Enabled.Equals(false) && string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            //Tipo Duplicata
            filtro[1].vNM_Campo = "a.tp_duplicata";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Tp_Dup.Text.Trim() + "'";
            //Duplicata Ativa
            filtro[2].vNM_Campo = "isnull(dup.st_registro, 'A')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'C'";
            //Parcela com saldo a liquidar
            filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[3].vOperador = "in";
            filtro[3].vVL_Busca = "('A', 'P')";
            //Não buscar duplicata que possuem boletos com remessa processada
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vOperador = "not exists";
            filtro[4].vVL_Busca = "(select 1 from TB_COB_LoteRemessa_X_Titulo x " +
                                  "inner join TB_COB_LoteRemessa y " +
                                  "on x.id_lote = y.id_lote " +
                                  "inner join TB_COB_Titulo z " +
                                  "on x.cd_empresa = z.cd_empresa " +
                                  "and x.nr_lancto = z.nr_lancto " +
                                  "and x.cd_parcela = z.cd_parcela " +
                                  "and x.id_cobranca = z.id_cobranca " +
                                  "and isnull(z.st_registro, 'A') <> 'C' " +
                                  "where a.cd_empresa = x.cd_empresa " +
                                  "and a.nr_lancto = x.nr_lancto " +
                                  "and a.cd_parcela = x.cd_parcela " +
                                  "and isnull(y.ST_Registro, 'A') = 'P') ";
            if (DT_Inicial.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (DT_Final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            //Clifor
            if (!string.IsNullOrEmpty(CD_Clifor.Text.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            }
            //Por categoria de clifor
            if (!string.IsNullOrEmpty(ID_CategoriaClifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.id_categoriaclifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + ID_CategoriaClifor.Text.Trim() + "'";
            }


            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(filtro, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            //Totalizar dados parcelas
            Tot_Parcelas.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_parcela);
            Tot_Liquidado.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_liquidado);
            Tot_Atual.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.cVl_atual);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFAgruparDuplicata_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAgruparDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcelas.ResetBindings(true);
                tot_agrupar.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
            }
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar =
                    !(bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar;
                bsParcelas.ResetCurrentItem();
                tot_agrupar.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
            }
        }

        private void BB_Dup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Desc. Duplicata|200;" +
                              "a.tp_duplicata|Tp. Duplicata|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Tp_Dup },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), string.Empty);
        }

        private void Tp_Dup_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + Tp_Dup.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Tp_Dup },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void gParcelas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gParcelas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsParcelas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela());
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sort(lComparer);
            bsParcelas.ResetBindings(false);
            gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFAgruparDuplicata_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }

        private void BB_CategoriaClifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_CategoriaClifor|Categoria Clifor|200;a.ID_CategoriaClifor|Cód. Categoria Clifor|100",
                new Componentes.EditDefault[] { ID_CategoriaClifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void ID_CategoriaClifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + ID_CategoriaClifor.Text.Trim() + "'",
              new Componentes.EditDefault[] { ID_CategoriaClifor },
              new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void CD_Empresa_TextChanged(object sender, EventArgs e)
        {
            //Validar se permitir agrupamento por categoria
            if (!string.IsNullOrEmpty(CD_Empresa.Text.Trim()))
            {
                object rVl_bool = new CamadaDados.ConfigGer.TCD_ParamGer_X_Empresa().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "b.ds_parametro",
                        vOperador = "=",
                        vVL_Busca = "'ST_PERMITIRAGRUPFINCLIFORDIF'"
                    },
                    new Utils.TpBusca()
                    { vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    }
                }, "b.vl_bool");
                if (rVl_bool != null && rVl_bool.Equals("S")) ID_CategoriaClifor.Enabled = BB_CategoriaClifor.Enabled = true;
                else ID_CategoriaClifor.Enabled = BB_CategoriaClifor.Enabled = false;
            }
        }
    }
}
