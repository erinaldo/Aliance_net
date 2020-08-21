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
    public partial class TFDescontoVendedor : Form
    {
        public string Cd_vendedor
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor rdesc;
        public CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor rDesc
        {
            get
            {
                if (bsDescontoVendedor.Current != null)
                    return bsDescontoVendedor.Current as CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor;
                else return null;
            }
            set { rdesc = value; }
        }

        public TFDescontoVendedor()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx.Add(new Utils.TDataCombo("VALOR", "V"));
            tp_desconto.DataSource = cbx;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pc_max_desconto.Focused)
            {
                (bsDescontoVendedor.Current as CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor).Pc_max_desconto = pc_max_desconto.Value;
                bsDescontoVendedor.ResetCurrentItem();
            }
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFDescontoVendedor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rdesc != null)
            {
                bsDescontoVendedor.DataSource = new CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor() { rdesc };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else bsDescontoVendedor.AddNew();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                             new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                              new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|80";
            string vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                            "               where x.cd_tabelapreco = a.cd_tabelapreco " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), vParam);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                            "               where x.cd_tabelapreco = a.cd_tabelapreco " +
                            "               and x.cd_vendedor = '" + Cd_vendedor.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDescontoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
