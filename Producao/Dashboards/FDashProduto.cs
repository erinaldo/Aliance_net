using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Producao.Dashboard;
using CamadaDados.Producao.Dashboard;

namespace Producao.Dashboards
{
    public partial class TFDashProduto : Form
    {
        public TFDashProduto()
        {
            InitializeComponent();
        }

        private void TFDashProduto_Load(object sender, EventArgs e)
        {
            pFiltro.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbTabPreco.DataSource = CamadaNegocio.Diversos.TCN_CadTbPreco.Busca(string.Empty, string.Empty, string.Empty);
            cbTabPreco.DisplayMember = "DS_TabelaPreco";
            cbTabPreco.ValueMember = "Cd_tabelaPreco";
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                            "isnull(e.st_industrializado, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam,
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_industrializado, 'N')|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, vParam);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo|150;a.cd_grupo|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            CamadaDados.Producao.Dashboard.TList_DashProduto lProdutos = TCN_DashProduto.Buscar(cbEmpresa.SelectedValue.ToString(), cbTabPreco.SelectedValue.ToString(), string.Empty, string.Empty, null);
            if (lProdutos.Count > 0)
            {
                TotalCMP.Value = lProdutos.Sum(p => p.Cmp);
                DespFixa.Value = lProdutos[0].Cf;
                DespVariavel.Value = lProdutos[0].Cv;

                if (TotalCMP.Value > 0)
                {
                    lProdutos.ForEach(p =>
                    {
                        p.Markup = (DespFixa.Value + DespVariavel.Value) / TotalCMP.Value;
                    });
                }
            }

            ///sumarry
            ///Todos produtos vendidos no mes anterior
            ///busca feita para calculo do custo total (cmv) de cada produto
            CamadaDados.Producao.Dashboard.TList_DashProduto _DashProdutos = new CamadaDados.Producao.Dashboard.TCD_DashProduto().quantidadeProdutoVendido();
            //Atribuição da quantidade vendida de cada produto
            lProdutos.ForEach(p =>
            {
                object obj = _DashProdutos.FindAll(c => c.Cd_produto.Equals(p.Cd_produto)).Sum(c => c.QuantidadeVendida);
                if (obj != null && Convert.ToDecimal(obj.ToString()) > 0)
                    p.QuantidadeVendida = Convert.ToDecimal(obj.ToString());
            });

            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()) && !string.IsNullOrEmpty(cd_grupo.Text.Trim()))
                bsProduto.DataSource = lProdutos.FindAll(p => p.Cd_produto.Equals(cd_produto.Text.Trim()) && p.Cd_grupo.Equals(cd_grupo.Text.Trim()));
            else if (!string.IsNullOrEmpty(cd_produto.Text.Trim()) && string.IsNullOrEmpty(cd_grupo.Text.Trim()))
                bsProduto.DataSource = lProdutos.FindAll(p => p.Cd_produto.Equals(cd_produto.Text.Trim()));
            else if (string.IsNullOrEmpty(cd_produto.Text.Trim()) && !string.IsNullOrEmpty(cd_grupo.Text.Trim()))
                bsProduto.DataSource = lProdutos.FindAll(p => p.Cd_grupo.Equals(cd_grupo.Text.Trim()));
            else
                bsProduto.DataSource = lProdutos;

            //Apenas produtos vendidos
            (bsProduto.DataSource as IEnumerable<CamadaDados.Producao.Dashboard.TRegistro_DashProduto>).ToList().RemoveAll(p => p.QuantidadeVendida.Equals(0));

            //Calculo do ponto de equilibrio em quantidade
            ///sumarry
            ///Ponto de Equilíbrio é a igualdade (equilíbrio) entre os custos/ despesas fixas e variáveis e o valor das vendas dos produtos ou serviços.
            ///Margem de Contribuição é o valor que cada produto ou serviço contribui para o pagamento dos custos e despesas fixas.
            ///Para calculo do ponto, deve distribuir o custo fixo pela proporção de venda de cada produto.
            ///propVendaPorProduto (Proporção de (quantidade vendida) por produto) 
            decimal quantTotalVendida = _DashProdutos.Sum(p => p.QuantidadeVendida);
            (bsProduto.DataSource as IEnumerable<CamadaDados.Producao.Dashboard.TRegistro_DashProduto>).ToList().ForEach(p =>
            {
                if (quantTotalVendida > 0)
                {
                    decimal propVendaPorProduto = ((p.QuantidadeVendida * 100) / quantTotalVendida);
                    if (p.MargContrEmValor > 0)
                    {
                        decimal custoFixoPorProduto = (DespFixa.Value * (propVendaPorProduto / 100));
                        p.PontoEquilibrio = custoFixoPorProduto / p.MargContrEmValor;
                    }
                }
            });

            editFloat1.Value = (bsProduto.DataSource as IEnumerable<TRegistro_DashProduto>).ToList().Sum(p => p.teste);
            if (Utils.Parametros.pubLogin.Equals("MASTER"))
                editFloat1.Visible = true;

            bsProduto.ResetBindings(true);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TpBusca[] tpBuscas = new TpBusca[0];
            if (tabControl1.SelectedIndex.Equals(1) && bsProduto.Current != null)
            {
                Estruturas.CriarParametro(ref tpBuscas, "a.cd_produto", (bsProduto.Current as TRegistro_DashProduto).Cd_produto);
                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", cbEmpresa.SelectedValue.ToString());
                Estruturas.CriarParametro(ref tpBuscas, "isnull(vr.ST_Registro, 'A')", "'C'", "<>");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(month, vr.dt_emissao)", "datepart(month, dateadd(month, -1, getdate())) ");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(year, vr.dt_emissao)", "datepart(year, getdate()) ");
                bsVendaRapidaItem.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(tpBuscas, 0, string.Empty, string.Empty);

                tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "b.cd_produto", (bsProduto.Current as TRegistro_DashProduto).Cd_produto);
                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", cbEmpresa.SelectedValue.ToString());
                Estruturas.CriarParametro(ref tpBuscas, "datepart(month, a.dt_emissao)", "datepart(month, dateadd(month, -1, getdate())) ");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(year, a.dt_emissao)", "datepart(year, getdate()) ");
                Estruturas.CriarParametro(ref tpBuscas, "isnull(a.ST_Registro, 'A')", "'C'", "<>");
                Estruturas.CriarParametro(ref tpBuscas, "a.Tp_Movimento", "'S'");
                Estruturas.CriarParametro(ref tpBuscas, "ISNULL(e.ST_Devolucao, 'N')", "'S'", "<>");
                Estruturas.CriarParametro(ref tpBuscas, "ISNULL(e.ST_Complementar, 'N')", "'S'", "<>");
                bsNotaFiscalItem.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(tpBuscas, 0);

            }
            else if (tabControl1.SelectedIndex.Equals(2))
            {
                tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "ISNULL(a.ST_Registro, 'C')", "'A'");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(month, a.dt_emissao)", "datepart(month, dateadd(month, -1, getdate()))");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(year, a.dt_emissao)", "datepart(year, getdate())");
                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", cbEmpresa.SelectedValue.ToString());
                Estruturas.CriarParametro(ref tpBuscas, string.Empty, "(select * from tb_fin_grupocf gf where ISNULL(gf.tp_custo, null) = 'F' and gf.cd_grupocf = HDup.cd_grupocf)", "exists");
                bsDespesaFixa.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(tpBuscas, 0, string.Empty);
            }
            else if (tabControl1.SelectedIndex.Equals(3))
            {
                tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "ISNULL(a.ST_Registro, 'C')", "'A'");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(month, a.dt_emissao)", "datepart(month, dateadd(month, -1, getdate()))");
                Estruturas.CriarParametro(ref tpBuscas, "datepart(year, a.dt_emissao)", "datepart(year, getdate())");
                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", cbEmpresa.SelectedValue.ToString());
                Estruturas.CriarParametro(ref tpBuscas, string.Empty, "(select * from tb_fin_grupocf gf where ISNULL(gf.tp_custo, null) = 'V' and gf.cd_grupocf = HDup.cd_grupocf)", "exists");
                bsDespesaVariavel.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(tpBuscas, 0, string.Empty);
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
