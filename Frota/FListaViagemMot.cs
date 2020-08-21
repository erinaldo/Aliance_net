using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFListaViagemMot : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_motorista
        { get; set; }

        public List<CamadaDados.Frota.TRegistro_Viagem> lViagem
        {
            get
            {
                if (bsViagem.Count > 0)
                    return (bsViagem.List as CamadaDados.Frota.TList_Viagem).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaViagemMot()
        {
            InitializeComponent();
        }

        public void AfterBusca()
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];

            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";

            filtro[1].vNM_Campo = "a.cd_motorista";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";

            filtro[2].vNM_Campo = "isnull(a.st_viagem, 'A')";
            filtro[2].vOperador = "in";
            filtro[2].vVL_Busca = "('E', 'F')";

            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from tb_frt_acerto_x_viagem x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_viagem = a.id_viagem)";

            if (!string.IsNullOrEmpty(IdViagem.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = IdViagem.Text;
            }

            if (!string.IsNullOrEmpty(DsViagem.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = DsViagem.Text;
            }

            if (!string.IsNullOrEmpty(Placa.Text.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(c.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Text.Replace("-", string.Empty).Trim() + "'";
            }

            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_viagem" + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_viagem" + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }

            bsViagem.DataSource = new CamadaDados.Frota.TCD_Viagem().Select(filtro, 0, string.Empty);
        }

        private void TFListaViagemMot_Load(object sender, EventArgs e)
        {
            AfterBusca();
        }

        private void gViagem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).St_processar =
                    !(bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).St_processar;
                bsViagem.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsViagem.Count > 0)
            {
                (bsViagem.List as CamadaDados.Frota.TList_Viagem).ForEach(p => p.St_processar = cbTodos.Checked);
                bsViagem.ResetBindings(true);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaViagemMot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gViagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gViagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsViagem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_Viagem());
            CamadaDados.Frota.TList_Viagem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_Viagem(lP.Find(gViagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gViagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_Viagem(lP.Find(gViagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gViagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsViagem.List as CamadaDados.Frota.TList_Viagem).Sort(lComparer);
            bsViagem.ResetBindings(false);
            gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            AfterBusca();
        }

        private void Placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
    }
}
