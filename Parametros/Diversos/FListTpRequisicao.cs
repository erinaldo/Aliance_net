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
    public partial class TFListTpRequisicao : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Compra.TRegistro_TpRequisicao> lTpRequisicao
        {
            get
            {
                if (bsTpRequisicao.Count > 0)
                    return (bsTpRequisicao.List as CamadaDados.Compra.TList_TpRequisicao).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListTpRequisicao()
        {
            InitializeComponent();
        }

        private void TFListTpRequisicao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTpRequisicao.DataSource = new CamadaDados.Compra.TCD_TpRequisicao().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_tprequisicao x " +
                                                            "where x.id_tprequisicao = a.id_tprequisicao "+
                                                            "and x.login = '" + Login.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListTpRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTpRequisicao.Count > 0)
            {
                (bsTpRequisicao.List as CamadaDados.Compra.TList_TpRequisicao).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTpRequisicao.ResetBindings(true);
            }
        }

        private void gTpRequisicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao).St_processar =
                    !(bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao).St_processar;
                bsTpRequisicao.ResetCurrentItem();
            }
        }
    }
}
