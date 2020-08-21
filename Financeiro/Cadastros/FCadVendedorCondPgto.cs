using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCadVendedorCondPgto : Form
    {
        public string Cd_vendedor
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto rvend;
        public CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto rVend
        {
            get
            {
                if (bsVendCond.Current != null)
                    return bsVendCond.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto;
                else
                    return null;
            }
            set { rvend = value; }
        }

        public TFCadVendedorCondPgto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_basecalccomissao.Focused)
                    (bsVendCond.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto).Pc_basecalc_comissao = pc_basecalccomissao.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFCadVendedorCondPgto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rvend != null)
            {
                bsVendCond.DataSource = new CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_CondPgto() { rvend };
                cd_condpgto.Enabled = false;
                bb_condpgto.Enabled = false;
                pc_basecalccomissao.Focus();
            }
            else
            {
                bsVendCond.AddNew();
                (bsVendCond.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto).Cd_vendedor = Cd_vendedor;
            }
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Codigo|80";
            string vParam = "|not exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                            "               where x.cd_condpgto = a.cd_condpgto " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + ";" +
                            "|not exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                            "               where x.cd_condpgto = a.cd_condpgto " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadVendedorCondPgto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
