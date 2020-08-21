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
    public partial class TFDuplicatasPerdidas : Form
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

        public TFDuplicatasPerdidas()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar clifor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Tp_Dup.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo duplicata.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tp_Dup.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[6];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            //Clifor
            filtro[1].vNM_Campo = "a.cd_clifor";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            //Tipo Duplicata
            filtro[2].vNM_Campo = "a.tp_duplicata";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + Tp_Dup.Text.Trim() + "'";
            //Duplicata Ativa
            filtro[3].vNM_Campo = "isnull(dup.st_registro, 'A')";
            filtro[3].vOperador = "<>";
            filtro[3].vVL_Busca = "'C'";
            //Parcela com saldo a liquidar
            filtro[4].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[4].vOperador = "in";
            filtro[4].vVL_Busca = "('A', 'P')";
            //Parcelas Vencidas
            filtro[5].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))";
            filtro[5].vOperador = "<";
            filtro[5].vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))";
            
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(filtro, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            //Totalizar dados parcelas
            Tot_Parcelas.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_parcela);
            Tot_Liquidado.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.Vl_liquidado);
            Tot_Atual.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p => p.cVl_atual);
        }

        private void TFDuplicatasPerdidas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
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

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar =
                    !(bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar;
                bsParcelas.ResetCurrentItem();
                tot_processar.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcelas.ResetBindings(true);
                tot_processar.Value = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual);
            }
        }

        private void TFDuplicatasPerdidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFDuplicatasPerdidas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }
    }
}
