using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFListaMDFeEnviar : Form
    {
        public string Cd_empresa
        { get; set; }
        public List<CamadaDados.Frota.TRegistro_MDFe> lMDFe
        {
            get
            {
                if (bsMDFe.Count > 0)
                    return (bsMDFe.List as CamadaDados.Frota.TList_MDFe).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaMDFeEnviar()
        {
            InitializeComponent();
        }

        private void TFListaMDFeEnviar_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsMDFe.DataSource = CamadaNegocio.Frota.TCN_MDFe.Buscar(Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    "'A'",
                                                                    "N",
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
        }

        private void gMDFe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsMDFe.Current as CamadaDados.Frota.TRegistro_MDFe).St_processar =
                    !(bsMDFe.Current as CamadaDados.Frota.TRegistro_MDFe).St_processar;
                bsMDFe.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsMDFe.Count > 0)
            {
                (bsMDFe.List as CamadaDados.Frota.TList_MDFe).ForEach(p => p.St_processar = cbTodos.Checked);
                bsMDFe.ResetBindings(true);
            }
        }
    }
}
