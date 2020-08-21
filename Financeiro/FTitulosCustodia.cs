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
    public partial class TFTitulosCustodia : Form
    {
        public string Cd_empresa
        { get; set; }

        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lChCustodia
        {
            get
            {
                if (bsTitulos.Count > 0)
                    return (bsTitulos.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).FindAll(p => p.St_conciliar);
                else
                    return null;
            }
        }

        public TFTitulosCustodia()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            filtro[1].vNM_Campo = "a.tp_titulo";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'R'";
            filtro[2].vNM_Campo = "isnull(a.status_compensado, 'N')";
            filtro[2].vOperador = "in";
            filtro[2].vVL_Busca = "('N', 'V')";
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from tb_fin_titulo_x_lotecustodia x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque)";
            if (!string.IsNullOrEmpty(cd_banco.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_banco.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nomeclifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nomeclifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + nomeclifor.Text.Trim() + "%'";
            }
            if (DT_Inicial.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
            }
            if (DT_Final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd") + "'";
            }
            bsTitulos.DataSource =
                new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(filtro, 0, string.Empty, "a.nr_cheque");
        }

        private void TotalizarCh()
        {
            if (bsTitulos.Count > 0)
                vl_tot_custodiar.Value = (bsTitulos.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
        }

        private void bb_banco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_banco|Banco|200;"+
                              "a.cd_banco|Cd. Banco|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void TFTitulosCustodia_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTitulos);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = this.Cd_empresa;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbMarcarTodos_Click(object sender, EventArgs e)
        {
            if (bsTitulos.Count > 0)
            {
                (bsTitulos.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).ForEach(p => p.St_conciliar = cbMarcarTodos.Checked);
                bsTitulos.ResetBindings(true);
                this.TotalizarCh();
            }
        }

        private void gTitulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsTitulos.Current != null))
            {
                (bsTitulos.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_conciliar =
                    !(bsTitulos.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_conciliar;
                bsTitulos.ResetCurrentItem();
                this.TotalizarCh();
            }
        }

        private void TFTitulosCustodia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFTitulosCustodia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTitulos);
        }
    }
}
