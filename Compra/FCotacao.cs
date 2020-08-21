using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FormBusca;
using Utils;
using System.Linq;

namespace Compra
{
    public partial class TFCotacao : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Qtd_requisitada
        { get; set; }
        public string pCd_fornecedor
        { get; set; }
        public string pCd_empresa
        { get; set; }

        public List<CamadaDados.Compra.Lancamento.TRegistro_Requisicao> lRequisicao
        {
            get
            {
                if (bsRequisicao.Count > 0)
                    return (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).FindAll(p=> p.St_integrar);
                else
                    return null;
            }
        }

        public TFCotacao()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMITENTE", "0"));
            cbx.Add(new Utils.TDataCombo("DESTINATARIO", "1"));
            cbx.Add(new Utils.TDataCombo("TERCEIRO", "2"));
            cbx.Add(new Utils.TDataCombo("SEM FRETE", "9"));

            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Qtd_requisitada = decimal.Zero;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (!(bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).Exists(p => p.St_integrar))
                {
                    MessageBox.Show("Obrigatório lançar cotações!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(cd_fornecedor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_fornecedor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(cd_endfornecedor.Text))
                    {
                        cd_endfornecedor.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endfornecedor.Text = List_Endereco[0].Ds_endereco.Trim();
                    }
                }
            }
        }

        private void Busca_Contato_Clifor()
        {
            if (!string.IsNullOrEmpty(cd_fornecedor.Text))
            {
                //Buscar Contato Fornecedor
                CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor List_Contato =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                   cd_fornecedor.Text,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   string.Empty,
                                                                                   0,
                                                                                   null);
                if (List_Contato.Count == 1)
                {
                    nm_vendedor.Text = List_Contato[0].Nm_Contato;
                    email_vendedor.Text = List_Contato[0].Email;
                    fonefax.Text = List_Contato[0].Fone;
                }
            }
        }

        private void Busca_Endereco_Transportadora()
        {
            if (cd_transportadora.Text != "")
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_transportadora.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(cd_endtransportadora.Text))
                    {
                        cd_endtransportadora.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endtransportadora.Text = List_Endereco[0].Ds_endereco.Trim();
                    }
                }
            }
        }

        private void BuscarComprasFornec()
        {
            if ((bsRequisicao.Current != null) &&
                (cd_fornecedor.Text.Trim() != string.Empty))
                bsUltimasComprasFornec.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "b.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_fornecedor.Text.Trim() + "'"
                        }
                    }, 12);
            if (bsUltimasComprasFornec.Count > 0)
                vl_ultimaCompraForn.Text =
                 (bsUltimasComprasFornec.DataSource as CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras)[0].Vl_UnitCustoNota.ToString("N2",
                    new System.Globalization.CultureInfo("pt-BR"));
            else
                vl_ultimaCompraForn.Text = "0,00";
        }

        private void BuscarComprasConc()
        {
            if ((cd_fornecedor.Text.Trim() != string.Empty) &&
                ((bsRequisicao.Current != null)))
                bsUltimasComprasConc.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "b.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "<>",
                            vVL_Busca = "'" + cd_fornecedor.Text.Trim() + "'"
                        }
                    }, 12);
            if (bsUltimasComprasConc.Count > 0)
                vl_ultimaCompraConc.Text =
                 (bsUltimasComprasConc.DataSource as CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras)[0].Vl_UnitCustoNota.ToString("N2",
                    new System.Globalization.CultureInfo("pt-BR"));
            else
                vl_ultimaCompraConc.Text = "0,00";
        }

        private void BuscarCotacaoFornec()
        {
            if ((cd_fornecedor.Text.Trim() != string.Empty) && (bsRequisicao.Current != null))
                bsCotacaoFornec.DataSource = new CamadaDados.Compra.Lancamento.TCD_Cotacao().Select(
                                                       new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_fornecedor",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_fornecedor.Text.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "f.cd_produto",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                vOperador = "<>",
                                                                vVL_Busca = "'R'"
                                                            }
                                                        }, 12, string.Empty);
        }

        private void BuscarCotacaoConc()
        {
            if ((cd_fornecedor.Text.Trim() != string.Empty) && (bsRequisicao.Current != null))
                bsCotacaoConc.DataSource = new CamadaDados.Compra.Lancamento.TCD_Cotacao().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_fornecedor",
                            vOperador = "<>",
                            vVL_Busca = "'" + cd_fornecedor.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "f.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'R'"
                        }
                    }, 12, string.Empty);
        }

        private void BuscarRequisicoes()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text) &&
                !string.IsNullOrEmpty(cd_fornecedor.Text))
            {
                bsRequisicao.DataSource =
                    new CamadaDados.Compra.Lancamento.TCD_Requisicao().Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                        "inner join TB_EST_Produto y " +
                                        "on x.cd_grupo = y.cd_grupo " +
                                        "where y.cd_produto = a.cd_produto " +
                                        "and x.CD_Clifor = '" + cd_fornecedor.Text.Trim() + "'" +
                                        "and a.cd_empresa = '" + cd_empresa.Text.Trim() + "'" +
                                        "and a.ST_Requisicao in ('AC', 'RN')) "
                        }
                    }, 0, string.Empty, string.Empty);
            }
        }

        private void BuscarMoedaPadrao()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar Moeda Padrao
                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(cd_empresa.Text, null);
                if (tabela != null)
                    if (tabela.Count > 0)
                    {
                        (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Cd_moeda = tabela[0].Cd_moeda;
                        (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Ds_moeda = tabela[0].Ds_moeda_singular;
                    }
                    else
                    {
                        (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Cd_moeda = string.Empty;
                        (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Ds_moeda = string.Empty;
                    }
                else
                {
                    (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Cd_moeda = string.Empty;
                    (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Ds_moeda = string.Empty;
                }
            }
        }

        private void TotalCotacoes()
        {
            if (bsRequisicao.Count > 0)
            {
                tot_qtdAtendida.Text = (bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Sum(p => p.Qtd_atendida).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                tot_subtotalAtendida.Text = (bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Sum(p => p.SubTotalAtendido).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void TFCotacao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsCotacao.AddNew();
            if (!string.IsNullOrEmpty(pCd_fornecedor))
            {
                cd_empresa.Text = pCd_empresa;
                cd_fornecedor.Text = pCd_fornecedor;
                cd_empresa_Leave(this, new EventArgs());
                cd_fornecedor_Leave(this, new EventArgs());
                nm_vendedor.Focus();
            }
            else
                cd_fornecedor.Focus();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                         , new CamadaDados.Diversos.TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
            this.BuscarMoedaPadrao();
            this.BuscarRequisicoes();
            this.TotalCotacoes();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
             , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            this.BuscarMoedaPadrao();
            this.BuscarRequisicoes();
            this.TotalCotacoes();
        }

        private void bb_contato_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Contato|Nome Contato|200;" +
                              "a.Email|Email|200;" +
                              "a.Fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "a.tp_contato|=|'C'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nm_vendedor, email_vendedor },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor(),
                                                        vParam);
            if (linha != null)
                fonefax.Text = linha["fone"].ToString();
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, vParam);
            this.Busca_Endereco_Clifor();
            this.Busca_Contato_Clifor();
            this.BuscarRequisicoes();
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarCotacaoFornec();
            this.BuscarCotacaoConc();
            this.TotalCotacoes();
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_X_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
            this.Busca_Contato_Clifor();
            this.BuscarRequisicoes(); 
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarCotacaoFornec();
            this.BuscarCotacaoConc();
            this.TotalCotacoes();
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100;" +
                "a.cd_transportador|Cd. Tranportadora|80;" +
                "transp.nm_clifor|Transportadora|200;" +
                "a.cd_endereco_transp|Cd. Transportadora|80;" +
                "endTransp.ds_endereco|Endereco Transportadora|200"
                , new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
            this.Busca_Endereco_Transportadora();
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Transportadora();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCotacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_endtransportadora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_endtransportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endtransportadora.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endtransportadora, ds_endtransportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_endfornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endfornecedor, ds_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_endfornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endfornecedor.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endfornecedor, ds_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarCotacaoFornec();
            this.BuscarCotacaoConc();
            this.TotalCotacoes();
        }

        private void gRequisicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar =
                    !(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar;
                //Informar Quantidade e Vl.Seguro
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar)
                {
                    using (TFItensValCotacao fValor = new TFItensValCotacao())
                    {
                        fValor.pQTD_requisitada = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Quantidade;
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero && fValor.Vl_unitCotado > decimal.Zero)
                            {
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Add(
                                    bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao);
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Qtd_atendida = fValor.Quantidade;
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_unitCotacao = fValor.Vl_unitCotado;
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_ipi = fValor.Vl_ipi;
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_icmssubst = fValor.Vl_icmssubst;
                                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Pc_icms = fValor.Pc_icms;
                            }
                    }
                    if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count > 0)
                    {
                        if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Qtd_atendida.Equals(decimal.Zero) &&
                            (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_unitCotacao.Equals(decimal.Zero))
                            (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar = false;
                    }
                    else
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar = false;

                    bsRequisicao.ResetCurrentItem();
                }
                else
                {
                    if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count > 0)
                    {
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Qtd_atendida = decimal.Zero;
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_unitCotacao = decimal.Zero;
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_ipi = decimal.Zero;
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Vl_icmssubst = decimal.Zero;
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Pc_icms = decimal.Zero;
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Remove(
                                    bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao);
                    }
                    bsRequisicao.ResetCurrentItem();
                }
                this.TotalCotacoes();
            }
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarCotacaoFornec();
            this.BuscarCotacaoConc();
            this.TotalCotacoes();
        }
    }
}
