using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaNegocio.Servicos;
using CamadaDados.Servicos;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Estoque.Cadastros;

namespace Servicos
{
    public partial class TFLan_Pecas_Ordem_Servico : Form
    {
        public string CD_Empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string CD_TabelaPreco
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public bool St_garantia
        { get; set; }
        public bool St_alterar
        { get; set; }
        public bool pSt_servico
        { get; set; }
        public string Cd_tecnico
        { get; set; }
        public string Nm_tecnico
        { get; set; }
        public bool St_consumoInterno
        { get; set; }
        public bool St_acrescbasedesc { get; set; }
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

        private bool St_obrigaCusto = false;

        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = null;

        public TFLan_Pecas_Ordem_Servico()
        {
            InitializeComponent();
            CD_Empresa = string.Empty;
            CD_TabelaPreco = string.Empty;
            St_garantia = false;
            St_alterar = false;
        }

        private void afterGrava()
        {
            if (pnl_Pecas.validarCampoObrigatorio())
            {
                if (St_obrigaCusto && !pSt_servico && vl_custo.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar custo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_custo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CD_Produto.Text) &&
                    string.IsNullOrEmpty(DS_Produto.Text))
                {
                    MessageBox.Show("Obrigatorio informar peça/serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Focus();
                    return;
                }               
                if ((!st_servico.Checked) &&
                    (!string.IsNullOrEmpty(CD_Produto.Text)) &&
                    string.IsNullOrEmpty(CD_Local.Text) && !St_consumoInterno)
                {
                    MessageBox.Show("Obrigatorio informar local armazenagem da peça.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Local.Focus();
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void ConsultaPreco()
        {
            rProg = null;

            if ((CD_Produto.Text.Trim() != string.Empty) && (CD_Empresa.Trim() != string.Empty) && (CD_TabelaPreco.Trim() != string.Empty) && !St_consumoInterno)
            {
                if (!string.IsNullOrEmpty(Cd_clifor))
                {
                    //Verificar se existe programacao especial de venda
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
                //Buscar Valor de Venda
                Vl_Unitario.Value = St_alterar ? Vl_Unitario.Value : TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                //Buscar custo produto
                vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa, CD_Produto.Text, null);
                vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                Vl_Unitario.Enabled = CD_TabelaPreco.Trim().Equals(string.Empty) ||
                                        Vl_Unitario.Value.Equals(decimal.Zero) ||
                                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                     "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                     null);
            }
            else
            {
                //Buscar Almoxarifado
                CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                    new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().Select(
                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                        "where x.id_almox = a.id_almox " +
                                                        "and x.cd_empresa = '" + CD_Empresa.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
                if (lAlmox.Count > 0)
                {
                    //Buscar Vl.Custo Almoxarifado
                    Vl_Unitario.Value = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(CD_Empresa,
                                                                                                             lAlmox[0].Id_almoxString,
                                                                                                             CD_Produto.Text,
                                                                                                             null);
                }
                Vl_Unitario.Enabled = Vl_Unitario.Value.Equals(decimal.Zero);
            }
        }

        private decimal CalcularDescEspecial()
        {
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((BS_Pecas.List as TList_LanServicosPecas).
                    Where(p => p.Cd_produto.Equals((BS_Pecas.Current as TRegistro_LanServicosPecas).Cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Math.Round(Quantidade.Value * rProg.Valor, 2);
                        else
                            return Math.Round(((Quantidade.Value * Vl_Unitario.Value) + (St_acrescbasedesc ? vl_acrescimo.Value : decimal.Zero)) * rProg.Valor / 100, 2);
                    }
                    else
                        return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Quantidade.Value * rProg.Valor, 2);
                    else
                        return Math.Round(((Quantidade.Value * Vl_Unitario.Value) + (St_acrescbasedesc ? vl_acrescimo.Value : decimal.Zero)) * rProg.Valor / 100, 2);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private void NovoProduto()
        {
            using (Proc_Commoditties.TFAtualizaCadProduto fAtualiza = new Proc_Commoditties.TFAtualizaCadProduto())
            {
                fAtualiza.Text = "Novo Cadastro Produto";
                fAtualiza.Cd_empresa = CD_Empresa;
                fAtualiza.Cd_tabelapreco = CD_TabelaPreco;
                fAtualiza.pSt_servico = pSt_servico;
                if (fAtualiza.ShowDialog() == DialogResult.OK)
                    if (fAtualiza.rProd != null)
                        try
                        {
                            TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                            MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CD_Produto.Text = fAtualiza.rProd.CD_Produto;
                            CD_Produto_Leave(this, new EventArgs());
                            ConsultaPreco();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BuscarProduto()
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "isnull(e.ST_Servico, 'N')";
            filtro[0].vOperador = pSt_servico ? "=" : "<>";
            filtro[0].vVL_Busca = "'S'";
            if (St_consumoInterno)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(e.ST_consumointerno, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            TRegistro_CadProduto rProd = null;

            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   CD_Empresa,
                                                   Nm_empresa,
                                                   CD_TabelaPreco,
                                                   new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                   filtro);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(CD_Produto.Text,
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
                TList_CadProduto lProd = new TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }

            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
                sigla_unidade.Text = rProd.Sigla_unidade;
                DS_Observacao.Text = rProd.DS_Tecnica;
                st_kit.Checked = rProd.St_composto;
                if ((!st_servico.Checked))
                {
                    //Buscar local armazenagem
                    object obj = new TCD_CadLocalArm().BuscarEscalar(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_empresa_x_localarm x " +
                                                    "where x.cd_local = a.cd_local " +
                                                    "and x.cd_empresa = '" + CD_Empresa.Trim() + "')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_localarm_x_produto x " +
                                                    "where x.cd_local = a.cd_local " +
                                                    "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')"
                                    }
                                }, "a.cd_local");
                    if (obj != null)
                    {
                        CD_Local.Text = obj.ToString();
                        CD_Local_Leave(this, new EventArgs());
                        Quantidade.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(CD_Local.Text))
                            CD_Local.Focus();
                        else
                            Quantidade.Focus();
                    }
                }
                if (st_kit.Checked)
                {
                    Height = 900;
                    Quantidade.Value = 1;
                    try
                    {
                        (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS =
                            TCN_LanServicoPecas.MontarFichaTecOS(CD_Produto.Text,
                                                                 CD_Empresa,
                                                                 Quantidade.Value,
                                                                 null);
                        BS_Pecas.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                {
                    Height = 456;
                    (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS.Clear();
                    BS_Pecas.ResetCurrentItem();
                }
            }
            ConsultaPreco();
        }

        private void InserirItemFicha()
        {
            if (BS_Pecas.Current != null)
            {
                TpBusca[] filtro = new TpBusca[2];
                filtro[0].vNM_Campo = "isnull(e.ST_Servico, 'N')";
                filtro[0].vOperador = pSt_servico ? "=" : "<>";
                filtro[0].vVL_Busca = "'S'";

                filtro[1].vNM_Campo = "isnull(e.ST_Composto, 'N')";
                filtro[1].vOperador = "<>";
                filtro[1].vVL_Busca = "'S'";

                TRegistro_CadProduto rProd = null;

                //Buscar Produto
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                             CD_Empresa,
                                                             Nm_empresa,
                                                             CD_TabelaPreco,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             filtro);
                
                if (rProd != null)
                {
                    decimal qtd = 1;
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Vl_default = 0;
                        fQtde.Ds_label = "Quantidade";
                        if (fQtde.ShowDialog() == DialogResult.OK)
                            qtd = fQtde.Quantidade;
                    }
                    (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Add(
                        new TRegistro_FichaTecOS()
                        {
                            Cd_item = rProd.CD_Produto,
                            Ds_item = rProd.DS_Produto,
                            Quantidade = qtd
                        });
                    if (Vl_Unitario.Enabled)
                    {
                        Vl_Unitario.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal);
                        vl_custo.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_TotCusto);
                    }
                    vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                    tot_itensFichaTec.Text = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    BS_Pecas.ResetCurrentItem();
                }
            }
        }

        private void AlterarItemFicha()
        {
            if (bsFichaTecOS.Current != null)
            {
                decimal qtd = (bsFichaTecOS.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Quantidade;
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Casas_decimais = 2;
                    fQtde.Vl_default = qtd;
                    fQtde.Ds_label = "Quantidade";
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        (bsFichaTecOS.Current as CamadaDados.Servicos.TRegistro_FichaTecOS).Quantidade = fQtde.Quantidade;
                        if (Vl_Unitario.Enabled)
                        {
                            Vl_Unitario.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal);
                            vl_custo.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_TotCusto);
                        }
                        vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                        tot_itensFichaTec.Text = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal).
                            ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    }
                    BS_Pecas.ResetCurrentItem();
                }     
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItemFicha()
        {
            if (bsFichaTecOS.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOSDel.Add(
                        bsFichaTecOS.Current as CamadaDados.Servicos.TRegistro_FichaTecOS);
                    bsFichaTecOS.RemoveCurrent();
                    if (Vl_Unitario.Enabled)
                    {
                        Vl_Unitario.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal);
                        vl_custo.Value = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_TotCusto);
                    }
                    vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                    tot_itensFichaTec.Text = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLan_Pecas_Ordem_Servico_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pnl_Pecas.set_FormatZero();
            Icon = ResourcesUtils.TecnoAliance_ICO;
            Height = 456;
            St_obrigaCusto = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_OBRIGAR_CUSTO_UNIT_ORC",
                                                                         null).Equals(true);
            if (!St_alterar)
                BS_Pecas.AddNew();
            else
            {
                if (rpeca.lFichaTecOS.Count > 0)
                {
                    Height = 600;
                    (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS.ForEach(p =>
                    {
                        p.Vl_unitario = TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, p.Cd_item, CD_TabelaPreco, null);

                    });
                    if (Vl_Unitario.Enabled)
                    {
                        Vl_Unitario.Value = (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal);
                        vl_custo.Value = (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_TotCusto);
                    }
                    vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
                    tot_itensFichaTec.Text = (BS_Pecas.Current as TRegistro_LanServicosPecas).lFichaTecOS.Sum(p => p.Vl_Subtotal).
                        ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
                if(rpeca.Vl_acrescimo > decimal.Zero && rpeca.Pc_acrescimo.Equals(decimal.Zero))
                    rpeca.Pc_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(rpeca.Vl_acrescimo, 100), rpeca.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                if(rpeca.Vl_desconto > decimal.Zero && rpeca.Pc_desconto.Equals(decimal.Zero))
                    rpeca.Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(rpeca.Vl_desconto, 100), rpeca.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                BS_Pecas.DataSource = rpeca;
                CD_Produto.Enabled = false;
                DS_Produto.Enabled = false;
                CD_Local.Enabled = !pSt_servico && !St_consumoInterno;
                BB_Local.Enabled = !pSt_servico && !St_consumoInterno;
                ID_Tecnico.Enabled = pSt_servico;
                BB_Tecnico.Enabled = pSt_servico;
                if(!string.IsNullOrEmpty(Cd_clifor))
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(CD_Empresa,
                                                                                                         Cd_clifor,
                                                                                                         CD_Produto.Text,
                                                                                                         CD_TabelaPreco,
                                                                                                         null);
            }
            if (!St_alterar)
            {
                ID_Tecnico.Text = Cd_tecnico;
                DS_Funcao.Text = Nm_tecnico;
            }
            vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && St_obrigaCusto;
            Vl_Unitario.Enabled = string.IsNullOrEmpty(CD_TabelaPreco) ||
                                   CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                                "PERMITIR INFORMAR PREÇO VENDA",
                                                                                                null);
            
            vl_custo.Visible = St_obrigaCusto;
            lbCusto.Visible = St_obrigaCusto;
            CD_Local.Enabled = !pSt_servico;
            BB_Local.Enabled = !pSt_servico;
            st_servico.Checked = pSt_servico;
            if (pSt_servico)
                BB_NovoProduto.Text = "(F8)\r\nServiço";
            if (St_consumoInterno)
            {
                CD_Local.Enabled = false;
                BB_Local.Enabled = false;
            }
        }

        private void TFLan_Pecas_Ordem_Servico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
                NovoProduto();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItemFicha();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
                "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                              "(exists(select 1 from tb_est_codbarra x " +
                              "         where x.cd_produto = a.cd_produto " +
                              "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                              "isnull(a.st_registro, 'A')|<>|'C'" +
                              "         and e.ST_Servico = " + (pSt_servico ? "'S'" : "'N'");
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, sigla_unidade },
                                                            new TCD_CadProduto());
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                DS_Produto.Enabled = false;
                ConsultaPreco();
            }
            else
            {
                DS_Produto.Enabled = true;
                DS_Produto.Focus();
            }
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca("", CD_Produto.Text);

            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa), "isnull(a.st_registro, 'A')|<>|'C'");

            if ((!string.IsNullOrEmpty(CD_Empresa)) && (!string.IsNullOrEmpty(CD_Produto.Text)) && (!string.IsNullOrEmpty(CD_Local.Text)))
                saldo_local.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam,
                                    new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa));

            if ((!string.IsNullOrEmpty(CD_Empresa)) && (!string.IsNullOrEmpty(CD_Produto.Text)) && (!string.IsNullOrEmpty(CD_Local.Text)))
                saldo_local.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa, CD_Produto.Text, CD_Local.Text, null);
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            Sub_Total.Value = Quantidade.Value * Vl_Unitario.Value;
            VL_Desconto.Value = CalcularDescEspecial();
            VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            if (Sub_Total.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = Math.Round(decimal.Divide(decimal.Multiply(VL_Desconto.Value, 100), Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
                pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_acrescimo.Value, 100), Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
            }
            if (St_consumoInterno)
            {
                //Buscar Almoxarifado
                object obj =
                    new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().BuscarEscalar(
                         new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                        "where x.id_almox = a.id_almox " +
                                                        "and x.cd_empresa = '" + CD_Empresa.Trim() + "')"
                                        }
                                    }, "a.id_almox");
                if (obj == null && string.IsNullOrEmpty(obj.ToString()))
                    throw new Exception("Não existe almoxarifado cadastrado para empresa " + CD_Empresa.Trim());
                //Buscar Saldo Almoxarifado
                decimal saldo = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(CD_Empresa,
                                                                                                         obj.ToString(),
                                                                                                         CD_Produto.Text,
                                                                                                         null);
                if (saldo < Quantidade.Value)
                {
                    MessageBox.Show("Não existe saldo suficiente para gravar movimentação.\r\n" +
                         "Item: " + CD_Produto.Text.Trim() + "\r\n" +
                         "Saldo Atual: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                         "Qtde Requerida: " + Quantidade.Value.ToString("N3", new System.Globalization.CultureInfo("pt-BR")), "Mensagem",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quantidade.Value = saldo;
                    Quantidade.Focus();
                }
            }
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            Sub_Total.Value = Quantidade.Value * Vl_Unitario.Value;
            VL_Desconto.Value = CalcularDescEspecial();
            VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            if (Sub_Total.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = Math.Round(decimal.Divide(decimal.Multiply(VL_Desconto.Value, 100), Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
                pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_acrescimo.Value, 100), Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
            }
        }

        private void Pc_DescontoItem_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                VL_Desconto.Value = Math.Round(decimal.Divide(decimal.Multiply(Pc_DescontoItem.Value, St_acrescbasedesc ? Sub_Total.Value + vl_acrescimo.Value : Sub_Total.Value), 100), 2, MidpointRounding.AwayFromZero);
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void VL_Desconto_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                Pc_DescontoItem.Value = Math.Round(decimal.Divide(decimal.Multiply(VL_Desconto.Value, 100), St_acrescbasedesc ? Sub_Total.Value + vl_acrescimo.Value : Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void CD_Local_EnabledChanged(object sender, EventArgs e)
        {
            if (!CD_Local.Enabled)
            {
                CD_Local.Clear();
                DS_Local.Clear();
            }
        }

        private void bb_novoproduto_Click(object sender, EventArgs e)
        {
            NovoProduto();
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                BuscarProduto();
                CD_Local.Focus();
            }
        }

        private void ID_Tecnico_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + ID_Tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'",
                                                   new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao },
                                                   new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Tecnico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao }, "isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'");
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                vl_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(pc_acrescimo.Value, Sub_Total.Value), 100), 2, MidpointRounding.AwayFromZero);
                if (St_acrescbasedesc && Pc_DescontoItem.Value > decimal.Zero)
                    VL_Desconto.Value = Math.Round(decimal.Multiply(Sub_Total.Value + vl_acrescimo.Value, decimal.Divide(Pc_DescontoItem.Value, 100)), 2, MidpointRounding.AwayFromZero);
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void vl_acrescimo_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
            {
                pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_acrescimo.Value, 100), Sub_Total.Value), 5, MidpointRounding.AwayFromZero);
                if (St_acrescbasedesc && Pc_DescontoItem.Value > decimal.Zero)
                    VL_Desconto.Value = Math.Round(decimal.Multiply(Sub_Total.Value + vl_acrescimo.Value, decimal.Divide(Pc_DescontoItem.Value, 100)), 2, MidpointRounding.AwayFromZero);
                VL_Total.Value = Sub_Total.Value - VL_Desconto.Value + vl_acrescimo.Value;
            }
        }

        private void bb_inserirficha_Click(object sender, EventArgs e)
        {
            InserirItemFicha();
        }

        private void bb_alterarficha_Click(object sender, EventArgs e)
        {
            AlterarItemFicha();
        }

        private void bb_excluirficha_Click(object sender, EventArgs e)
        {
            ExcluirItemFicha();
        }
    }
}
