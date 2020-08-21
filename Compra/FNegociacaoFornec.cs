using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Compra
{
    public partial class TFNegociacaoFornec : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Sigla_unidade
        { get; set; }

        public bool St_alterar
        { get; set; }

        public bool St_detalhe
        { get; set; }

        public CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem rNegItem
        {
            get
            {
                if (bsItemNegociacao.Current != null)
                    return bsItemNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem;
                else
                    return null;
            }
            set
            {
                bsItemNegociacao.Add(value);
            }
        }

        public TFNegociacaoFornec()
        {
            InitializeComponent();

            this.St_alterar = false;
            this.St_detalhe = false;
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
        }

        private void BuscarEnd()
        {
            if (cd_fornecedor.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'"+cd_fornecedor.Text.Trim()+"'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    cd_endfornecedor.Text = obj.ToString();
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BuscarVendasMes()
        {
            bsVendasMes.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().SelectVendasMes(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'"+cd_produto.Text.Trim()+"'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(c.ST_Complementar, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'N'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(c.ST_Devolucao, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'N'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(c.ST_GeraEstoque, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, 12);
        }

        private void BuscarPrecoVenda()
        {
            bsPrecoVenda.DataSource = CamadaNegocio.Estoque.TCN_ConsultaProdutos.buscaConsultaPreco(string.Empty, 
                                                                                                    cd_produto.Text, 
                                                                                                    string.Empty, 
                                                                                                    string.Empty);
        }

        private decimal CalcularMediaVendas()
        {
            if ((bsVendasMes.Count < 1) && (cd_produto.Text.Trim() != string.Empty))
                this.BuscarVendasMes();
            if (bsVendasMes.Count > 0)
                return (bsVendasMes.DataSource as CamadaDados.Faturamento.NotaFiscal.TListVendasMes).Take(Convert.ToInt32(qtd_meses.Value)).Average(p => p.Quantidade);
            else
                return decimal.Zero;
        }

        private void BuscarComprasFornec()
        {
            if((cd_produto.Text.Trim() != string.Empty) &&
                (cd_fornecedor.Text.Trim() != string.Empty) &&
                bsUltimasComprasFornec.Count.Equals(0))
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
                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
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
            if(bsUltimasComprasFornec.Count > 0)
                vl_ultimacompraforn.Value = (bsUltimasComprasFornec.DataSource as CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras)[0].Vl_UnitCustoNota;
        }

        private void BuscarComprasConc()
        {
            if((cd_fornecedor.Text.Trim() != string.Empty) &&
                (cd_produto.Text.Trim() != string.Empty) &&
                bsUltimasComprasConc.Count.Equals(0))
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
                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
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
                vl_ultimacompraconc.Value = (bsUltimasComprasConc.DataSource as CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras)[0].Vl_UnitCustoNota;
        }

        private void BuscarNegociacaoFornec()
        {
            if((cd_fornecedor.Text.Trim() != string.Empty) && bsNegociacaoFornec.Count.Equals(0))
                bsNegociacaoFornec.DataSource = new CamadaDados.Compra.Lancamento.TCD_NegociacaoItem().Select(
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
                                                                vNM_Campo = "d.cd_produto",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "isnull(d.st_registro, 'A')",
                                                                vOperador = "<>",
                                                                vVL_Busca = "'C'"
                                                            }
                                                        }, 12, string.Empty, "d.dt_negociacao desc");
        }

        private void BuscarNegociacaoConc()
        {
            if((cd_fornecedor.Text.Trim() != string.Empty) && bsNegociacaoConc.Count.Equals(0))
                bsNegociacaoConc.DataSource = new CamadaDados.Compra.Lancamento.TCD_NegociacaoItem().Select(
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
                            vNM_Campo = "d.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(d.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 12, string.Empty, "d.dt_negociacao desc");
        }

        private void BuscarDetEstoque()
        {
            if (cd_produto.Text.Trim() != string.Empty)
            {
                DataTable tb_det = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintetico(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                        }
                    }, "a.Vl_Medio, a.Tot_Saldo", string.Empty);
                if(tb_det != null)
                    if (tb_det.Rows.Count > 0)
                    {
                        qtd_saldoestoque.Value = Convert.ToDecimal(tb_det.Rows[0]["tot_saldo"].ToString());
                        vl_customedio.Value = Convert.ToDecimal(tb_det.Rows[0]["vl_medio"].ToString());
                    }
            }
        }

        private void PageAtiva()
        {
                this.BuscarComprasFornec();
                this.BuscarComprasConc();
                this.BuscarNegociacaoFornec();
                this.BuscarNegociacaoConc();
        }

        private void InserirPrazoEntrega()
        {
            if(bsItemNegociacao.Current != null)
                using (TFLanPrazoEntrega fPrazo = new TFLanPrazoEntrega())
                {
                    if(fPrazo.ShowDialog() == DialogResult.OK)
                        if (fPrazo.rPrazo != null)
                        {
                            (bsItemNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).lPrazoEntrega.Add(fPrazo.rPrazo);
                            bsItemNegociacao.ResetCurrentItem();
                        }
                }
        }

        private void DeletarPrazoEntrega()
        {
            if(bsItemNegociacao.Current != null)
                if(bsPrazoEntrega.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsItemNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).lPrazoEntregaDel.Add(
                            bsPrazoEntrega.Current as CamadaDados.Compra.Lancamento.TRegistro_PrazoEntrega);
                        bsPrazoEntrega.RemoveCurrent();
                    }
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor " +
                            "       and x.cd_grupo = '" + cd_grupo.Text.Trim() + "')";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, vParam);
            this.BuscarEnd();
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarNegociacaoFornec();
            this.BuscarNegociacaoConc();
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_X_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor " +
                            "       and x.cd_grupo = '" + cd_grupo.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEnd();
            this.BuscarComprasFornec();
            this.BuscarComprasConc();
            this.BuscarNegociacaoFornec();
            this.BuscarNegociacaoConc();
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

        private void TFNegociacaoFornec_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Utils.ShapeGrid.RestoreShape(this, gPrazoEntrega);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault7);
            pMediaVendas.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pContatos.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (this.St_detalhe)
            {
                BB_Gravar.Visible = false;
                pDados.HabilitarControls(false, TTpModo.tm_Standby);
                ds_observacao.Enabled = false;
                TS_ItensPedido.Enabled = false;
            }
            else
            {
                pDados.set_FormatZero();
                cd_grupo.Text = this.Cd_grupo;
                ds_grupo.Text = this.Ds_grupo;
                cd_produto.Text = this.Cd_produto;
                ds_produto.Text = this.Ds_produto;
                sigla_unidade.Text = this.Sigla_unidade;
                this.BuscarDetEstoque();
                this.BuscarVendasMes();
                this.BuscarPrecoVenda();
                mediavendas.Value = this.CalcularMediaVendas();
                this.BuscarComprasFornec();
                this.BuscarComprasConc();
                this.BuscarNegociacaoFornec();
                this.BuscarNegociacaoConc();
                if (this.St_alterar)
                {
                    cd_fornecedor.Enabled = false;
                    bb_fornecedor.Enabled = false;
                    cd_condpgto.Focus();
                }
                else
                {
                    bsItemNegociacao.AddNew();
                    cd_fornecedor.Focus();
                }
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
        
        private void qtd_meses_ValueChanged(object sender, EventArgs e)
        {
            mediavendas.Value = this.CalcularMediaVendas();
        }

        private void bb_contato_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Contato|Nome Contato|200;" +
                              "a.Email|Email|200;" +
                              "a.Fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'"+cd_fornecedor.Text.Trim()+"';"+
                            "a.tp_contato|=|'C'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nm_vendedor, email_vendedor },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor(),
                                                        vParam);
            if (linha != null)
                fonefax.Text = linha["fone"].ToString();
        }

        private void TFNegociacaoFornec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F10) && tcAux.SelectedTab.Equals(tpPrazoEntrega))
                this.InserirPrazoEntrega();
            else if (e.KeyCode.Equals(Keys.F12) && tcAux.SelectedTab.Equals(tpPrazoEntrega))
                this.DeletarPrazoEntrega();
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Descrição Moeda|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.DeletarPrazoEntrega();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirPrazoEntrega();
        }

        private void gPrazoEntrega_DoubleClick(object sender, EventArgs e)
        {
            if(bsPrazoEntrega.Current != null)
                using (TFLanPrazoEntrega fPrazo = new TFLanPrazoEntrega())
                {
                    fPrazo.St_detalhe = true;
                    fPrazo.rPrazo = bsPrazoEntrega.Current as CamadaDados.Compra.Lancamento.TRegistro_PrazoEntrega;
                    fPrazo.ShowDialog();
                }
        }

        private void bb_endfornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_endfornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endfornecedor.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endfornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void TFNegociacaoFornec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
            Utils.ShapeGrid.SaveShape(this, gPrazoEntrega);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault7);
        }
    }
}
