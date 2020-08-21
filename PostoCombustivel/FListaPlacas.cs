using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaPlacas : Form
    {
        public string Placa
        {
            get
            {
                if (bsConvPlaca.Count > 0)
                    if ((bsConvPlaca.List as CamadaDados.PostoCombustivel.TList_Convenio_Placa).Exists(p => p.St_processar))
                        return (bsConvPlaca.List as CamadaDados.PostoCombustivel.TList_Convenio_Placa).Find(p => p.St_processar).Placa;
                    else
                        return string.Empty;
                else
                    return string.Empty;
            }
        }

        public CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor rConvCli
        { get; set; }

        public TFListaPlacas()
        {
            InitializeComponent();
        }

        private void gPlaca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsConvPlaca.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa).St_processar)
                    (bsConvPlaca.List as CamadaDados.PostoCombustivel.TList_Convenio_Placa).ForEach(p => p.St_processar = false);
                (bsConvPlaca.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa).St_processar =
                    !(bsConvPlaca.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Placa).St_processar;
                bsConvPlaca.ResetCurrentItem();
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

        private void TFListaPlacas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFListaPlacas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPlaca);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rConvCli != null)
                bsConvPlaca.DataSource = CamadaNegocio.PostoCombustivel.TCN_Convenio_Placa.Buscar(rConvCli.Id_conveniostr,
                                                                                                  rConvCli.Cd_empresa,
                                                                                                  rConvCli.Cd_clifor,
                                                                                                  rConvCli.Cd_endereco,
                                                                                                  rConvCli.Cd_produto,
                                                                                                  null);
        }

        private void TFListaPlacas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPlaca);
        }
    }
}
