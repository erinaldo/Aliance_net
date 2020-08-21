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
    public partial class TFCustoProdComposto : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }

        public TFCustoProdComposto()
        {
            InitializeComponent();
        }

        private void Calcular()
        {
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
             CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(Cd_produto,
                                                                        string.Empty,
                                                                        null);
            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(CD_Empresa.Text, cd_tabelapreco.Text, lFicha, null);
            bsFichaTec.DataSource = lFicha;
            vl_custototal.Value = lFicha.Sum(p => p.Vl_subtotalservico);
            tot_precovenda.Value = lFicha.Sum(p => p.Vl_precovendatotal);
            if (tot_precovenda.Value > decimal.Zero)
                pc_lucro.Value = vl_custototal.Value * 100 / tot_precovenda.Value;
            else
                pc_lucro.Value = pc_lucro.Minimum;
        }

        private void TFCustoProdComposto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_produto.Text = Cd_produto;
            ds_produto.Text = Ds_produto;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                        new Componentes.EditDefault[] { CD_Empresa, nm_empresa });
        }

        private void bb_calcula_Click(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void TFCustoProdComposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F9))
                this.Calcular();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
            
        }

        private void TFCustoProdComposto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
