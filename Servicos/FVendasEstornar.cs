using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFVendasEstornar : Form
    {
        public bool St_consulta
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda
        {
            get
            {
                if (bsVenda.Current != null)
                    return bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida;
                else return null;
            }
        }

        public TFVendasEstornar()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFVendasEstornar_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (St_consulta)
            {
                barraMenu.Visible = false;
                this.Text = "Vendas Caixa";
            }
            bsVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "exists(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                        "       inner join tb_pdv_caixa y " +
                                                        "       on x.id_caixa = y.id_caixa " +
                                                        "       where x.cd_empresa = a.cd_empresa " +
                                                        "       and x.id_cupom = a.id_cupom " +
                                                        "       and isnull(y.st_registro, 'A') = 'A' " +
                                                        "       and y.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "exists(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                        "       inner join tb_pdv_caixa y " +
                                                        "       on x.id_caixa = y.id_caixa " +
                                                        "       where x.cd_empresa = a.cd_empresa " +
                                                        "       and x.id_vendarapida = a.id_vendarapida " +
                                                        "       and isnull(y.st_registro, 'A') = 'A' " +
                                                        "       and y.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        }
                                    }, 0, string.Empty, string.Empty);
        }
    }
}
