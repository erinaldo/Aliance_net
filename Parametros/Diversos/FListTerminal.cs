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
    public partial class TFListTerminal : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Diversos.TRegistro_CadTerminal> lTerminal
        {
            get 
            {
                if (bsTerminal.Count > 0)
                    return (bsTerminal.DataSource as CamadaDados.Diversos.TList_CadTerminal).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListTerminal()
        {
            InitializeComponent();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTerminal.Count > 0)
            {
                (bsTerminal.DataSource as CamadaDados.Diversos.TList_CadTerminal).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTerminal.ResetBindings(true);
            }
        }

        private void TFListTerminal_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTerminal.DataSource = new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_terminal x " +
                                                        "where x.cd_terminal = a.cd_terminal " +
                                                        "and x.login = '" + Login.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
        }

        private void gTerminal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTerminal.Current as CamadaDados.Diversos.TRegistro_CadTerminal).St_processar =
                    !(bsTerminal.Current as CamadaDados.Diversos.TRegistro_CadTerminal).St_processar;
                bsTerminal.ResetCurrentItem();
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

        private void TFListTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
