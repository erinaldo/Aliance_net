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
    public partial class TFListEmpresas : Form
    {
        public string Login
        { get; set; }

        public List<CamadaDados.Diversos.TRegistro_CadEmpresa> lEmpresa
        {
            get
            {
                if (bsEmpresa.Count > 0)
                    return (bsEmpresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListEmpresas()
        {
            InitializeComponent();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsEmpresa.Count > 0)
            {
                (bsEmpresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).ForEach(p => p.St_processar = cbTodos.Checked);
                bsEmpresa.ResetBindings(true);
            }
        }

        private void gEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).St_processar =
                    !(bsEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).St_processar;
                bsEmpresa.ResetCurrentItem();
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

        private void TFListEmpresas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.login = '" + Login.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
        }

        private void TFListEmpresas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
