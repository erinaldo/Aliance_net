using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFFechamentoCaixaPDV : Form
    {
        public string Id_caixa
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa rFechamento
        {
            get
            {
                if (bsFechamento.Current != null)
                    return bsFechamento.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa;
                else
                    return null;
            }
        }
        public TFFechamentoCaixaPDV()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_auditado.Focused)
                    (bsFechamento.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).Vl_auditado = vl_auditado.Value;
                if (vl_fechamento.Focused)
                    (bsFechamento.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).Vl_fechamento = vl_fechamento.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFFechamentoCaixaPDV_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsFechamento.AddNew();
            (bsFechamento.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).Id_caixastr = Id_caixa;

        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            string vParam = "tp_portadorpdv|=|'A';" +
                            "isnull(st_devcredito, 'N')|<>|'S';" +
                            "isnull(st_cartafrete, 'N')|<>|'S';" +
                            "isnull(st_entregafutura, 'N')|<>|'S';" +
                            "|not exists|(select 1 from tb_pdv_fechamentocaixa x " +
                            "               where x.cd_portador = a.cd_portador " +
                            "               and isnull(x.st_registro, 'A') <> 'C' " +
                            "               and x.id_caixa = " + Id_caixa + ")";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "tp_portadorpdv|=|'A';" +
                            "isnull(st_devcredito, 'N')|<>|'S';" +
                            "isnull(st_cartafrete, 'N')|<>|'S';" +
                            "isnull(st_entregafutura, 'N')|<>|'S';" +
                            "|not exists|(select 1 from tb_pdv_fechamentocaixa x " +
                            "               where x.cd_portador = a.cd_portador " +
                            "               and isnull(x.st_registro, 'A') <> 'C' " +
                            "               and x.id_caixa = " + Id_caixa + ")";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFFechamentoCaixaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
