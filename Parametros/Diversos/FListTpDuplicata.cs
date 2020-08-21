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
    public partial class TFListTpDuplicata : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadTpDuplicata> lTpDuplicata
        {
            get
            {
                if (bsTpDuplicata.Count > 0)
                    return (bsTpDuplicata.List as CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListTpDuplicata()
        {
            InitializeComponent();
        }

        private void gTpDuplicata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTpDuplicata.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadTpDuplicata).St_processar =
                    !(bsTpDuplicata.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadTpDuplicata).St_processar;
                bsTpDuplicata.ResetCurrentItem();
            }
        }

        private void TFListTpDuplicata_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTpDuplicata.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                                            "where x.tp_duplicata = a.tp_duplicata " +
                                                            "and x.login = '" + Login.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTpDuplicata.Count > 0)
            {
                (bsTpDuplicata.List as CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTpDuplicata.ResetBindings(true);
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

        private void TFListTpDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
