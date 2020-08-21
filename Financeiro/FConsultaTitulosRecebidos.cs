using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Titulo;

namespace Financeiro
{
    public partial class TFConsultaTitulosRecebidos : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Id_caixaPDV
        { get; set; }
        public decimal Vl_conciliar
        { get; set; }

        public List<TRegistro_LanTitulo> lChRepasse
        {
            get
            {
                if (bsTitulos.Count > 0)
                    return (bsTitulos.List as TList_RegLanTitulo).FindAll(p => p.St_conciliar);
                else
                    return null;
            }
        }

        public TFConsultaTitulosRecebidos()
        {
            InitializeComponent();
        }

        private void TFConsultaTitulosRecebidos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTitulos);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            Vl_SD_Conciliar.Value = Vl_conciliar;
            TpBusca[] filtro = null;
            if (string.IsNullOrEmpty(Id_caixaPDV))
            {
                filtro = new TpBusca[4];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                //Conta
                filtro[1].vNM_Campo = "a.cd_contager";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
                //Recebidos
                filtro[2].vNM_Campo = "a.tp_titulo";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'R'";
                //Compensar
                filtro[3].vNM_Campo = "isnull(a.status_compensado, 'N')";
                filtro[3].vOperador = "=";
                filtro[3].vVL_Busca = "'N'";
            }
            else
            {
                filtro = new TpBusca[2];
                filtro[0].vNM_Campo = string.Empty;
                filtro[0].vOperador = string.Empty;
                filtro[0].vVL_Busca = "exists(select 1 from tb_fin_titulo_x_caixa x " +
                                      "inner join tb_pdv_cupom_x_movcaixa y " +
                                      "on x.cd_contager = y.cd_contager " +
                                      "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.cd_banco = a.cd_banco " +
                                      "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                      "and y.id_caixa = " + Id_caixaPDV + ") or " +
                                      "exists(select 1 from TB_PDV_TrocaEspecie x " +
                                      "where x.CD_Empresa = a.cd_empresa " +
                                      "and x.CD_Banco = a.cd_banco " +
                                      "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
                                      "and x.ID_Caixa = " + Id_caixaPDV + ")";
                filtro[1].vNM_Campo = string.Empty;
                filtro[1].vOperador = "not exists";
                filtro[1].vVL_Busca = "(select 1 from tb_pdv_trocoCH x " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.cd_banco = a.cd_banco " +
                                      "and x.nr_lanctocheque = a.nr_lanctocheque)";
            }

            bsTitulos.DataSource = new TCD_LanTitulo().Select(filtro, 0, string.Empty, string.Empty);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFConsultaTitulosRecebidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F5))
                BB_Localizar_Click(this, new EventArgs());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gTitulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTitulos.Current as TRegistro_LanTitulo).St_conciliar = !(bsTitulos.Current as TRegistro_LanTitulo).St_conciliar;
                Vl_TotalTitulo.Value = (bsTitulos.List as TList_RegLanTitulo).Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
                bsTitulos.ResetCurrentItem();
            }
        }

        private void Vl_SD_Conciliar_ValueChanged(object sender, EventArgs e)
        {
            Vl_Saldo.Value = Vl_SD_Conciliar.Value - Vl_TotalTitulo.Value;
        }

        private void Vl_TotalTitulo_ValueChanged(object sender, EventArgs e)
        {
            Vl_Saldo.Value = Vl_SD_Conciliar.Value - Vl_TotalTitulo.Value;
        }

        private void BB_Localizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bsTitulos.Count; i++)
                if ((bsTitulos[i] as TRegistro_LanTitulo).Nr_cheque.Trim().ToUpper().Equals(nr_cheque.Text.Trim().ToUpper()))
                    bsTitulos.Position = i;
        }

        private void TFConsultaTitulosRecebidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTitulos);
        }

        private void gTitulos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTitulos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTitulos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanTitulo());
            TList_RegLanTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTitulos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTitulos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanTitulo(lP.Find(gTitulos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTitulos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanTitulo(lP.Find(gTitulos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTitulos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTitulos.List as TList_RegLanTitulo).Sort(lComparer);
            bsTitulos.ResetBindings(false);
            gTitulos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
