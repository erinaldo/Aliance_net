using System;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaMotorista : Form
    {
        public CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor rConvCli
        { get; set; }

        public CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista rConvMot
        {
            get
            {
                if (bsConvenioMot.Count > 0)
                    if ((bsConvenioMot.List as CamadaDados.PostoCombustivel.TList_convenio_Motorista).Exists(p => p.St_processar))
                        return (bsConvenioMot.List as CamadaDados.PostoCombustivel.TList_convenio_Motorista).Find(p => p.St_processar);
                    else
                        return null;
                else
                    return null;
            }
        }

        public TFListaMotorista()
        {
            InitializeComponent();
        }

        private void TFListaMotorista_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsConvenioMot.DataSource = CamadaNegocio.PostoCombustivel.TCN_Motorista_Convenio.Buscar(rConvCli.Id_conveniostr,
                                                                                                    rConvCli.Cd_empresa,
                                                                                                    rConvCli.Cd_clifor,
                                                                                                    rConvCli.Cd_endereco,
                                                                                                    rConvCli.Cd_produto,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaMotorista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gMotorista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsConvenioMot.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista).St_processar)
                    (bsConvenioMot.List as CamadaDados.PostoCombustivel.TList_convenio_Motorista).ForEach(p => p.St_processar = false);
                (bsConvenioMot.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista).St_processar =
                    !(bsConvenioMot.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Motorista).St_processar;
                bsConvenioMot.ResetCurrentItem();
            }
        }
    }
}
