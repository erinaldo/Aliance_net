using System.Windows.Forms;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFPatrimonio : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio rpatrimonio;
        public CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio rPatrimonio
        {
            get
            {
                if (bsPatrimonio.Current != null)
                    return bsPatrimonio.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio;
                else
                    return null;
            }
            set { rpatrimonio = value; }
        }

        public TFPatrimonio()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("HORAS", "0"));
            cbx2.Add(new TDataCombo("DIAS", "1"));
            cbx2.Add(new TDataCombo("MÊS", "2"));
            cbx2.Add(new TDataCombo("ANO", "3"));
            TP_VidaUtil.DataSource = cbx2;
            TP_VidaUtil.ValueMember = "Value";
            TP_VidaUtil.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void BB_Empresa_Click(object sender, System.EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, System.EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void TFPatrimonio_Load(object sender, System.EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rpatrimonio != null)
                bsPatrimonio.DataSource = new CamadaDados.Estoque.Cadastros.TList_CadPatrimonio { rpatrimonio };
            else bsPatrimonio.AddNew();
        }

        private void BB_Cancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, System.EventArgs e)
        {
            afterGrava();
        }

        private void TFPatrimonio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
