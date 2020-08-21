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
    public partial class TFVendedorTabPreco : Form
    {
        public string Cd_vendedor
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco rvend;
        public CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco rVend
        {
            get
            {
                if (bsVendTab.Current != null)
                    return bsVendTab.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco;
                else
                    return null;
            }
            set { rvend = value; }
        }

        public TFVendedorTabPreco()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (pc_comissao.Focused)
                    (bsVendTab.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco).Pc_comissao = pc_comissao.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFVendedorTabPreco_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rvend != null)
            {
                bsVendTab.DataSource = new CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_TabelaPreco() { rvend };
                cd_tabelapreco.Enabled = false;
                bb_tabelapreco.Enabled = false;
                pc_comissao.Focus();
            }
            else
            {
                bsVendTab.AddNew();
                (bsVendTab.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco).Cd_vendedor = Cd_vendedor;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFVendedorTabPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|80";
            string vParam = "|not exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                            "               where x.cd_tabelapreco = a.cd_tabelapreco " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), vParam);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "';"+
                            "|not exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                            "               where x.cd_tabelapreco = a.cd_tabelapreco " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }
    }
}
