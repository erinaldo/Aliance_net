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

namespace PDV
{
    public partial class TFChequePDV : Form
    {
        public List<TRegistro_LanTitulo> lCheque
        {
            get
            {
                if (bsTitulos.Count > 0)
                    return (bsTitulos.DataSource as TList_RegLanTitulo).FindAll(p => p.St_conciliar);
                else
                    return null;
            }
        }

        public string Id_caixa
        { get; set; }

        public TFChequePDV()
        {
            InitializeComponent();
        }

        private void BB_Localizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bsTitulos.Count; i++)
                if ((bsTitulos[i] as TRegistro_LanTitulo).Nr_cheque.Trim().ToUpper().Equals(nr_cheque.Text.Trim().ToUpper()))
                    bsTitulos.Position = i;
        }

        private void TFChequePDV_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gTitulos);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTitulos.DataSource = new TCD_LanTitulo().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_titulo",
                        vOperador = "=",
                        vVL_Busca = "'R'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isNull(a.Status_Compensado, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'N'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                    "inner join tb_pdv_cupom_x_movcaixa y " +
                                    "on x.cd_contager = y.cd_contager " +
                                    "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " + 
                                    "and y.id_caixa = " + Id_caixa + ")or " +
                                    "exists(select 1 from tb_fin_titulo_x_caixa x " +
                                    "inner join tb_fin_liquidacao y " +
                                    "on x.cd_contager = y.cd_contager " +
                                    "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                    "inner join tb_pdv_caixa_x_liquidacao z " +
                                    "on y.cd_empresa = z.cd_empresa " +
                                    "and y.nr_lancto = z.nr_lancto " +
                                    "and y.cd_parcela = z.cd_parcela " +
                                    "and y.id_liquid = z.id_liquid " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and z.id_caixa = " + Id_caixa + ")or " +
                                    "exists (select 1 from TB_FIN_Titulo_X_Caixa x " +
                                    "inner join TB_FIN_Adiantamento_X_Caixa z " +
                                    "on z.CD_ContaGer = x.CD_ContaGer " +
                                    "and z.CD_LanctoCaixa = x.CD_LanctoCaixa " +
                                    "inner join TB_FIN_Adiantamento adto " +
                                    "on adto.Id_Adto = z.Id_Adto " +
                                    "where x.CD_Empresa = a.cd_empresa " +
                                    "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
                                    "and x.CD_Banco = a.cd_banco " +
                                    "and adto.ID_CaixaPDV = " + Id_caixa + " ) or " +
                                    "exists(select 1 from TB_PDV_TrocaEspecie x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.id_caixa = " + Id_caixa + ") "
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "not exists",
                        vVL_Busca = "(select 1 from tb_pdv_retirada_x_cheque x " + 
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque)"
                    }
                }, 0, string.Empty, string.Empty);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbMarcarTodos_Click(object sender, EventArgs e)
        {
            if (bsTitulos.Count > 0)
            {
                (bsTitulos.DataSource as TList_RegLanTitulo).ForEach(p => p.St_conciliar = cbMarcarTodos.Checked);
                bsTitulos.ResetBindings(true);
            }
        }

        private void gTitulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTitulos.Current as TRegistro_LanTitulo).St_conciliar =
                    !(bsTitulos.Current as TRegistro_LanTitulo).St_conciliar;
                bsTitulos.ResetCurrentItem();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFChequePDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F5))
            {
                for (int i = 0; i < bsTitulos.Count; i++)
                    if ((bsTitulos[i] as TRegistro_LanTitulo).Nr_cheque.Trim().ToUpper().Equals(nr_cheque.Text.Trim().ToUpper()))
                        bsTitulos.Position = i;
            }
        }

        private void TFChequePDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gTitulos);
        }
    }
}
