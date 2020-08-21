using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Servicos;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;

namespace Servicos
{
    public partial class TFServicosSalao : Form
    {
        public string CD_Empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string CD_TabelaPreco
        { get; set; }
        public string Cd_clifor
        { get; set; }

        private TRegistro_LanServicosPecas rpeca;
        public TRegistro_LanServicosPecas rPeca
        {
            get
            {
                if (BS_Pecas.Current != null)
                    return (BS_Pecas.Current as TRegistro_LanServicosPecas);
                else
                    return null;
            }
            set { rpeca = value; }
        }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = null;

        public TFServicosSalao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pnl_Pecas.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(CD_Produto.Text) &&
                string.IsNullOrEmpty(DS_Produto.Text))
                {
                    MessageBox.Show("Obrigatorio informar peça/serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ConsultaPreco()
        {
            rProg = null;
            if ((CD_Produto.Text.Trim() != string.Empty) && (CD_Empresa.Trim() != string.Empty) && (CD_TabelaPreco.Trim() != string.Empty))
            {
                if (!string.IsNullOrEmpty(Cd_clifor))
                {
                    //Vefiricar se existe programacao especial de venda
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa,
                                                                                                         Cd_clifor,
                                                                                                         CD_Produto.Text,
                                                                                                         CD_TabelaPreco,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                        {
                            Vl_Unitario.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa,
                                                                                                                 CD_Produto.Text,
                                                                                                                 null);
                            Vl_Unitario.Enabled = CD_TabelaPreco.Trim().Equals(string.Empty) || Vl_Unitario.Value.Equals(decimal.Zero);
                            return;
                        }
                }
                Vl_Unitario.Value = TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
                Vl_Unitario.Enabled = CD_TabelaPreco.Trim().Equals(string.Empty) || Vl_Unitario.Value.Equals(decimal.Zero);
            }
        }

        private decimal CalcularDescEspecial()
        {
            if (rProg != null)
                if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(1 * rProg.Valor, 2);
                    else
                        return Math.Round((1 * Vl_Unitario.Value) * rProg.Valor / 100, 2);
                }
                else return decimal.Zero;
            else return decimal.Zero;
        }

        private void BuscarProduto()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(e.ST_Servico, 'N')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'S'";

            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;

            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             CD_TabelaPreco,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             CD_TabelaPreco,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
            else
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vOperador = "<>";
                filtro[filtro.Length - 2].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                                      "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }

            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                DS_Observacao.Text = rProd.DS_Tecnica;
            }
            this.ConsultaPreco();
        }

        private void TFServicosSalao_Load(object sender, EventArgs e)
        {
            pnl_Pecas.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rpeca == null)
            {
                BS_Pecas.AddNew();
                (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade = 1;
            }
            else
            {
                if (rpeca.Vl_acrescimo > decimal.Zero && rpeca.Pc_acrescimo.Equals(decimal.Zero))
                    rpeca.Pc_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(rpeca.Vl_acrescimo, 100), rpeca.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                if (rpeca.Vl_desconto > decimal.Zero && rpeca.Pc_desconto.Equals(decimal.Zero))
                    rpeca.Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(rpeca.Vl_desconto, 100), rpeca.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                BS_Pecas.DataSource = rpeca;
                CD_Produto.Enabled = false;
                DS_Produto.Enabled = false;
                if (!string.IsNullOrEmpty(Cd_clifor))
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa,
                                                                                                         Cd_clifor,
                                                                                                         CD_Produto.Text,
                                                                                                         CD_TabelaPreco,
                                                                                                         null);
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            this.BuscarProduto();
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            VL_Desconto.Value = this.CalcularDescEspecial();
            VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
            if (Vl_Unitario.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = Math.Round(decimal.Divide(decimal.Multiply(VL_Desconto.Value, 100), Vl_Unitario.Value), 5, MidpointRounding.AwayFromZero);
                pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_acrescimo.Value, 100), Vl_Unitario.Value), 5, MidpointRounding.AwayFromZero);
            }
        }

        private void Pc_DescontoItem_Leave(object sender, EventArgs e)
        {
            if (Vl_Unitario.Value > decimal.Zero)
            {
                VL_Desconto.Value = Math.Round(decimal.Divide(decimal.Multiply(Pc_DescontoItem.Value, Vl_Unitario.Value), 100), 2, MidpointRounding.AwayFromZero);
                VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void VL_Desconto_Leave(object sender, EventArgs e)
        {
            if (Vl_Unitario.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = Math.Round(decimal.Divide(decimal.Multiply(VL_Desconto.Value, 100), Vl_Unitario.Value), 5, MidpointRounding.AwayFromZero);
                VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void ID_Tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + ID_Tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                   new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao },
                                                   new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            if (Vl_Unitario.Value > decimal.Zero)
            {
                vl_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(pc_acrescimo.Value, Vl_Unitario.Value), 100), 2, MidpointRounding.AwayFromZero);
                VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void vl_acrescimo_Leave(object sender, EventArgs e)
        {
            if (Vl_Unitario.Value > decimal.Zero)
            {
                pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_acrescimo.Value, 100), Vl_Unitario.Value), 5, MidpointRounding.AwayFromZero);
                VL_Total.Value = Vl_Unitario.Value - VL_Desconto.Value + vl_acrescimo.Value;
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

        private void TFServicosSalao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                ID_Tecnico.Focus();
        }
    }
}
