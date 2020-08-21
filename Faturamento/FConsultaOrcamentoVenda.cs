using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;


namespace Faturamento
{
    public partial class FConsultaOrcamentoVenda : Form
    {
        public FConsultaOrcamentoVenda()
        {
            InitializeComponent();
        }

        private void FConsultaOrcamentoVenda_Load(object sender, EventArgs e)
        {

        }
        public string nr_orcamento = string.Empty;

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_vendedor }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_vendedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void afterbusca()
        {
            bsOrcamento.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(nr_orc.Text,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        cd_vendedor.Text,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        nm_clifor.Text,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        DT_Inicial.Text,
                                                                                        DT_Final.Text,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        "'AB', 'AR'",
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,
                                                                                        false,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,
                                                                                        false,
                                                                                        null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();

        }
        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens =
                      CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                      (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                      false,
                      false,
                      null);
            }
            bsOrcamento.ResetCurrentItem();
        }

        private void FConsultaOrcamentoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
            {
                afterbusca(); 
            }else if (e.KeyCode.Equals(Keys.F4))
            {
                BB_Novo_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F6))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            if(bsOrcamento.Current != null)
                if(MessageBox.Show("N° Orçamento selecionado "+ (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr
                    + "\n Deseja continuar?","Mensagem",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bool a = false;
                    bsOrcamento.ResetCurrentItem();
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                    {
                        if (string.IsNullOrEmpty(p.Cd_produto))
                        {
                            a = true;
                            return;
                        }
                    });
                    if (a)
                    { 
                        MessageBox.Show("Orçamento possui produto não cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    nr_orcamento = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr;
                    this.DialogResult = DialogResult.OK;
                }
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
                if(string.IsNullOrEmpty((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto))
                    using(Proc_Commoditties.TFProdutoResumido prod = new Proc_Commoditties.TFProdutoResumido())
                    {
                        CamadaDados.Estoque.Cadastros.TRegistro_CadProduto a = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                        a.DS_Produto = (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_produto;
                        prod.Produto = a;
                        if(prod.ShowDialog() == DialogResult.OK)
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(prod.Produto, null);
                            //(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Vl_unitario = prod.Produto.vl_unitario;
                            (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto = prod.Produto.CD_Produto;
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Gravar((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item), null);
                            bsItens.ResetCurrentItem();
                        }

                    }

        }
    }
}
