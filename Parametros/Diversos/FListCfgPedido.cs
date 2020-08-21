using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFListCfgPedido : Form
    {
        public string Login
        {get;set;}
        public List<CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido> lPedido
        {
            get
            {
                if(bsTpPedido.Count > 0)
                    return (bsTpPedido.DataSource as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).FindAll(p=> p.St_processar);
                else
                    return null;
            }
        }

        public TFListCfgPedido()
        {
            InitializeComponent();
        }

        private void TFListCfgPedido_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTpPedido.DataSource = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_DIV_Usuario_X_CFGPedido x " +
                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                        "and x.login = '" + Login.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListCfgPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTpPedido.Count > 0)
            {
                (bsTpPedido.DataSource as CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTpPedido.ResetBindings(true);
            }
        }

        private void gTpPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTpPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).St_processar =
                    !(bsTpPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).St_processar;
                bsTpPedido.ResetCurrentItem();
            }
        }
    }
}
