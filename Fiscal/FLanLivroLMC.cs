using System;
using System.Linq;
using System.Windows.Forms;

namespace Fiscal
{
    public partial class TFLanLivroLMC : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanLivroLMC()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar empresa para gerar livro LMC.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbCombustivel.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar combustivel para gerar livro LMC.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCombustivel.Focus();
                return;
            }
            //Buscar medicao fisica dos tanques
            bsMedicaoTanque.DataSource = new CamadaDados.Fiscal.LMC.TCD_AfericaoTanque().Select(cbEmpresa.SelectedValue.ToString(),
                                                                                                cbCombustivel.SelectedValue.ToString(),
                                                                                                dt_emissao.Value);
            //Buscar Volume recebido
            bsVolumeRecebido.DataSource = new CamadaDados.Fiscal.LMC.TCD_VolumeRecebido().Select(cbEmpresa.SelectedValue.ToString(),
                                                                                                 cbCombustivel.SelectedValue.ToString(),
                                                                                                 string.Empty,
                                                                                                 dt_emissao.Value);
            //Buscar volume vendido
            bsVolumeVendas.DataSource = new CamadaDados.Fiscal.LMC.TCD_VolumeVendido().Select(cbEmpresa.SelectedValue.ToString(),
                                                                                              cbCombustivel.SelectedValue.ToString(),
                                                                                              dt_emissao.Value);
            //Buscar Fechamento Fisico
            bsFechamento.DataSource = new CamadaDados.Fiscal.LMC.TCD_FechamentoFisico().Select(cbEmpresa.SelectedValue.ToString(),
                                                                                               cbCombustivel.SelectedValue.ToString(),
                                                                                               dt_emissao.Value);
            //Totalizar
            tot_abertura.Value = (bsMedicaoTanque.DataSource as CamadaDados.Fiscal.LMC.TList_AfericaoTanque).Sum(p => p.Qtd_combustivel);
            tot_recebido.Value = (bsVolumeRecebido.DataSource as CamadaDados.Fiscal.LMC.TList_VolumeRecebido).Sum(p => p.Qtd_combustivel);
            tot_disponivel.Value = tot_abertura.Value + tot_recebido.Value;
            tot_venda.Value = (bsVolumeVendas.DataSource as CamadaDados.Fiscal.LMC.TList_VolumeVendido).Sum(p => p.Qtd_vendas);
            tot_estoquecontabil.Value = tot_disponivel.Value - tot_venda.Value;
            tot_estfisico.Value = (bsFechamento.DataSource as CamadaDados.Fiscal.LMC.TList_FechamentoFisico).Sum(p => p.Qtd_combustivel);
            tot_perdaganho.Value = tot_estfisico.Value - tot_estoquecontabil.Value;
            tot_vlvenda.Value = (bsVolumeVendas.DataSource as CamadaDados.Fiscal.LMC.TList_VolumeVendido).Sum(p => p.Vl_venda);
            tot_vlacumulado.Value = Convert.ToDecimal(new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cbCombustivel.SelectedValue.ToString() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_afericao, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.DT_Abastecimento",
                                                vOperador = ">=",
                                                vVL_Busca = "'" +  string.Format(new System.Globalization.CultureInfo("en-US", true), new DateTime(dt_emissao.Value.Year, dt_emissao.Value.Month, 1).ToString("yyyyMMdd")) + " 00:00:00'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.DT_Abastecimento",
                                                vOperador = "<=",
                                                vVL_Busca = "'" +  string.Format(new System.Globalization.CultureInfo("en-US", true), dt_emissao.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                                            }
                                        }, "isnull(sum(isnull(a.vl_subtotal, 0)), 0)"));
            if((tot_estfisico.Value > decimal.Zero) &&
                (tot_estoquecontabil.Value > decimal.Zero))
                pc_perdaganho.Value = tot_perdaganho.Value < 0 ? Math.Abs(((tot_estfisico.Value * 100) / tot_estoquecontabil.Value) - 100) :
                                        Math.Abs(((tot_estoquecontabil.Value * 100) / tot_estfisico.Value) - 100);
        }

        private void afterPrint()
        {
            if (bsFechamento.Current == null)
            {
                MessageBox.Show("Obrigatorio informar estoque de fechamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsVolumeVendas.List as CamadaDados.Fiscal.LMC.TList_VolumeVendido).Exists(p => p.Qtd_fechamento.Equals(decimal.Zero)))
            {
                MessageBox.Show("Existe bico sem encerrante de fechamento informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool st_imprimir = true;
            if (pc_perdaganho.Value > Convert.ToDecimal(0.6))
            {
                st_imprimir = MessageBox.Show("Percentual perda/ganho acima do indice tolerado (0.6%).\r\n" +
                                                "Deseja imprimir LMC mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                 MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            }
            if (st_imprimir)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                BindingSource bs = new BindingSource();
                bs.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa };
                Relatorio.DTS_Relatorio = bs;
                //Relatorio.Adiciona_DataSource("ABERTURA", bsMedicaoTanque);
                Relatorio.Adiciona_DataSource("RECEBIDO", bsVolumeRecebido);
                Relatorio.Adiciona_DataSource("VENDAS", bsVolumeVendas);
                //Relatorio.Adiciona_DataSource("FECHAMENTO", bsFechamento);
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor " +
                                                "and x.cd_endereco = a.cd_endereco " +
                                                "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString() + "')"
                                }
                            }, "a.insc_estadual");
                Relatorio.Parametros_Relatorio.Add("INSC_ESTADUAL", obj != null ? obj.ToString() : string.Empty);
                Relatorio.Parametros_Relatorio.Add("NR_PAGINA", nr_pagina.Value.ToString().PadLeft(4, '0'));
                Relatorio.Parametros_Relatorio.Add("DT_EMISSAO", dt_emissao.Value);
                Relatorio.Parametros_Relatorio.Add("PRODUTO", (cbCombustivel.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "-" + (cbCombustivel.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto.Trim());
                Relatorio.Parametros_Relatorio.Add("VL_VENDA", tot_vlvenda.Value);
                Relatorio.Parametros_Relatorio.Add("VL_MES", tot_vlacumulado.Value);
                Relatorio.Parametros_Relatorio.Add("TOT_FECHAMENTO", tot_estfisico.Value);
                Relatorio.Parametros_Relatorio.Add("TOT_ABERTURA", tot_abertura.Value);
                Relatorio.Parametros_Relatorio.Add("TOT_DISPONIVEL", tot_disponivel.Value);
                //Buscar Observação
                obj = new CamadaDados.PostoCombustivel.TCD_MovLMC().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca{ vNM_Campo = "a.CD_Empresa", vOperador = "=", vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'" },
                        new Utils.TpBusca{ vNM_Campo = "a.CD_Produto", vOperador = "=", vVL_Busca = "'" + (cbCombustivel.SelectedItem as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'" },
                        new Utils.TpBusca{ vNM_Campo = string.Empty, vOperador = "exists", vVL_Busca = "(select 1 from tb_pdc_lmc x where x.cd_empresa = a.cd_empresa and x.id_lmc = a.id_lmc and convert(datetime, floor(convert(decimal(30,10), x.dt_emissao))) = '" + dt_emissao.Value.ToString("yyyyMMdd") + "')" }
                    }, "a.Obs");
                Relatorio.Parametros_Relatorio.Add("OBS", obj?.ToString());
                //Parametros de abertura
                if (bsMedicaoTanque.Count > 0)
                    for (int i = 0; i < bsMedicaoTanque.Count; i++)
                        if (i < 8)
                        {
                            Relatorio.Parametros_Relatorio.Add("TQAB" + (i + 1).ToString(), (bsMedicaoTanque[i] as CamadaDados.Fiscal.LMC.TRegistro_AfericaoTanque).Id_tanque.Value.ToString());
                            Relatorio.Parametros_Relatorio.Add("VOLAB" + (i + 1).ToString(), (bsMedicaoTanque[i] as CamadaDados.Fiscal.LMC.TRegistro_AfericaoTanque).Qtd_combustivel);
                        }
                        else
                            break;
                //Parametros de Fechamento
                if (bsFechamento.Count > 0)
                    for (int i = 0; i < bsFechamento.Count; i++)
                        if (i < 8)
                        {
                            Relatorio.Parametros_Relatorio.Add("TQFE" + (i + 1).ToString(), (bsFechamento[i] as CamadaDados.Fiscal.LMC.TRegistro_FechamentoFisico).Id_tanque.Value.ToString());
                            Relatorio.Parametros_Relatorio.Add("VOLFE" + (i + 1).ToString(), (bsFechamento[i] as CamadaDados.Fiscal.LMC.TRegistro_FechamentoFisico).Qtd_combustivel);
                        }
                        else
                            break;
                Relatorio.Ident = "FREL_LIVROLMC";

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "LIVRO MOVIMENTAÇÃO COMBUSTIVEL";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio("LMC",
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "LMC",
                                                    fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void PrintTermoLMC(string Termo)
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(cbCombustivel.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar combustivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCombustivel.Focus();
                return;
            }
            using (TFTermoLMC fTermo = new TFTermoLMC())
            {
                fTermo.dt_ref = dt_emissao.Value;
                fTermo.Cd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                fTermo.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                fTermo.Cd_produto = cbCombustivel.SelectedValue.ToString();
                if (fTermo.ShowDialog() == DialogResult.OK)
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "REL_LMC_ABERTURA";
                    Relatorio.NM_Classe = "REL_LMC_ABERTURA";
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                    Relatorio.Ident = "REL_LMC_ABERTURA";

                    BindingSource bs = new BindingSource();
                    bs.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(fTermo.pCd_empresa, string.Empty, string.Empty, null);
                    Relatorio.DTS_Relatorio = bs;

                    Relatorio.Parametros_Relatorio.Add("DT_LMC", fTermo.pDt_ref);
                    Relatorio.Parametros_Relatorio.Add("NR_ORDEM", fTermo.Nr_ordem);
                    Relatorio.Parametros_Relatorio.Add("DS_TERMO", Termo);
                    Relatorio.Parametros_Relatorio.Add("QTD_PAGINAS", fTermo.Qtd_paginas);
                    string ds_produto = string.Empty;
                    string cd_comb = string.Empty;
                    string virg = string.Empty;
                    if (fTermo.lProd != null)
                        fTermo.lProd.ForEach(p => 
                            {
                                cd_comb += virg + "'" + p.CD_Produto.Trim() + "'";
                                ds_produto += p.DS_Produto.Trim() + "\r\n";
                                virg = ",";
                            });
                    Relatorio.Parametros_Relatorio.Add("DS_COMBUSTIVEL", ds_produto);
                    //Buscar fornecedor
                    object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fTermo.pCd_empresa.Trim() + "'"
                                        }
                                    }, "c.nm_clifor");
                    Relatorio.Parametros_Relatorio.Add("NM_FORNECEDOR", obj == null ? "BANDEIRA BRANCA" : obj.ToString());
                    Utils.TpBusca[] filtro = new Utils.TpBusca[2];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + fTermo.pCd_empresa.Trim() + "'";
                    filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
                    filtro[1].vOperador = "<>";
                    filtro[1].vVL_Busca = "'C'";
                    if(!string.IsNullOrEmpty(cd_comb))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                        filtro[filtro.Length - 1].vOperador = "in";
                        filtro[filtro.Length - 1].vVL_Busca = "(" + cd_comb.Trim() + ")";
                    }
                    Relatorio.Parametros_Relatorio.Add("CAPACIDADE_TANQUE", new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().Select(filtro, 0, string.Empty).Sum(p=> p.Capacidadetanque));
                    obj = new CamadaDados.Diversos.TCD_SociosEmpresa().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bs.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_responsavel, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "c.nm_clifor");
                    Relatorio.Parametros_Relatorio.Add("NM_RESPONSAVEL", obj != null ? obj.ToString() : string.Empty);

                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pMensagem = "TERMO " + Termo.Trim() + " LMC";
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio("TERMO " + Termo.Trim() + " LMC",
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        "TERMO " + Termo.Trim() + " LMC",
                                                        fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }
                }
            }
        }      
        
        private void TFLanLivroLMC_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, gTanque);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
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
            cbCombustivel.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(e.st_lubrificante, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
            cbCombustivel.DisplayMember = "DS_Produto";
            cbCombustivel.ValueMember = "CD_Produto";
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFLanLivroLMC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void tsmAbertura_Click(object sender, EventArgs e)
        {
            PrintTermoLMC("ABERTURA");
        }

        private void tsmEncerramento_Click(object sender, EventArgs e)
        {
            PrintTermoLMC("ENCERRAMENTO");
        }

        private void tsbMedicao_Click(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbCombustivel.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar combustivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCombustivel.Focus();
                return;
            }
            if (bsMedicaoTanque.Count > 0)
            {
                //Buscar medicao Tanque
                CamadaDados.PostoCombustivel.TList_MedicaoTanque lMed =
                    new CamadaDados.PostoCombustivel.TCD_MedicaoTanque().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_tanque",
                            vOperador = "=",
                            vVL_Busca = (bsMedicaoTanque.Current as CamadaDados.Fiscal.LMC.TRegistro_AfericaoTanque).Id_tanque.Value.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "((CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), DT_Medicao))) = '" + dt_emissao.Value.ToString("yyyyMMdd") + "' and TP_Medicao = 'A') or " +
                                        "(CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), DT_Medicao))) = '" + dt_emissao.Value.AddDays(-1).ToString("yyyyMMdd") + "' and TP_Medicao = 'F'))"
                        }
                    }, 1, string.Empty);
                if(lMed.Count > 0)
                    using (PostoCombustivel.TFMedicaoTanque fMed = new PostoCombustivel.TFMedicaoTanque())
                    {
                        fMed.rMedicao = lMed[0];
                        if(fMed.ShowDialog() == DialogResult.OK)
                            if(fMed.rMedicao != null)
                                try
                                {
                                    CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMed.rMedicao, null);
                                    MessageBox.Show("Medição tanque alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
            else
                using (PostoCombustivel.TFMedicaoTanque fMed = new PostoCombustivel.TFMedicaoTanque())
                {
                    fMed.Cd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    fMed.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa; 
                    fMed.Dt_lmc = dt_emissao.Value;
                    fMed.Cd_combustivel = cbCombustivel.SelectedValue.ToString();
                    fMed.St_abertura = true;
                    if(fMed.ShowDialog() == DialogResult.OK)
                        if(fMed.rMedicao != null)
                            try
                            {
                                CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMed.rMedicao, null);
                                MessageBox.Show("Medição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void tsbConciliacao_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbCombustivel.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar combustivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCombustivel.Focus();
                return;
            }
            if (bsFechamento.Count > 0)
            {
                //Buscar medicao Tanque
                CamadaDados.PostoCombustivel.TList_MedicaoTanque lMed =
                    new CamadaDados.PostoCombustivel.TCD_MedicaoTanque().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_tanque",
                            vOperador = "=",
                            vVL_Busca = (bsFechamento.Current as CamadaDados.Fiscal.LMC.TRegistro_FechamentoFisico).Id_tanque.Value.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "((CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), DT_Medicao))) = '" + dt_emissao.Value.ToString("yyyyMMdd") + "' and TP_Medicao = 'F') or " +
                                        "(CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), DT_Medicao))) = '" + dt_emissao.Value.AddDays(1).ToString("yyyyMMdd") + "' and TP_Medicao = 'A'))"
                        }
                    }, 1, string.Empty);
                if (lMed.Count > 0)
                    using (PostoCombustivel.TFMedicaoTanque fMed = new PostoCombustivel.TFMedicaoTanque())
                    {
                        fMed.rMedicao = lMed[0];
                        if (fMed.ShowDialog() == DialogResult.OK)
                            if (fMed.rMedicao != null)
                                try 
                                {
                                    if (new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fMed.rMedicao.Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_afericaoajustaest, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "1") != null)
                                    {
                                        decimal estoque = decimal.Zero;
                                        decimal vlmedio = decimal.Zero;
                                        //busca local de armazenamento do combustivel do tanque
                                        object ob = new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_tanque",
                                        vOperador = "=",
                                        vVL_Busca = fMed.rMedicao.Id_tanquestr
                                    }
                                            }, "a.cd_local");
                                        // busca a qtd de estoque
                                        if (ob != null)
                                            estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(fMed.rMedicao.Cd_funcionario,
                                                                                                             fMed.rMedicao.Cd_combustivel,
                                                                                                             ob.ToString(), null);
                                        if (fMed.rMedicao.Qtd_combustivel != estoque)
                                            if (MessageBox.Show("Saldo estoque fisico diferente da medição do tanque.\r\n" +
                                                               $"Saldo fisico atual:{estoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                               $"Quantidade Medição:{fMed.rMedicao.Qtd_combustivel.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                               (estoque > fMed.rMedicao.Qtd_combustivel ? "Saida:" + (estoque - fMed.rMedicao.Qtd_combustivel).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) :
                                                               "Entrada:" + (fMed.rMedicao.Qtd_combustivel - estoque).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))) + "\r\n" +
                                                               "Ajustar saldo estoque fisico?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                            {
                                                //busca vl medio
                                                vlmedio = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(fMed.rMedicao.Cd_empresa,
                                                                                                                       fMed.rMedicao.Cd_combustivel,
                                                                                                                       null);
                                                fMed.rMedicao.rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                                                fMed.rMedicao.rEstoque.Cd_empresa = fMed.rMedicao.Cd_empresa;
                                                fMed.rMedicao.rEstoque.Cd_produto = fMed.rMedicao.Cd_combustivel;
                                                fMed.rMedicao.rEstoque.Vl_medioestoque = vlmedio;
                                                fMed.rMedicao.rEstoque.Cd_local = ob.ToString();
                                                fMed.rMedicao.rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                                                fMed.rMedicao.rEstoque.St_registro = "A";
                                                fMed.rMedicao.rEstoque.Tp_lancto = "M";
                                                if (estoque < fMed.rMedicao.Qtd_combustivel)
                                                {
                                                    fMed.rMedicao.rEstoque.Tp_movimento = "E";
                                                    fMed.rMedicao.rEstoque.Qtd_entrada = Math.Round(fMed.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero);
                                                    fMed.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(fMed.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                                }
                                                else
                                                {
                                                    fMed.rMedicao.rEstoque.Tp_movimento = "S";
                                                    fMed.rMedicao.rEstoque.Qtd_saida = Math.Round(estoque - fMed.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero);
                                                    fMed.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(estoque - fMed.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                                }
                                                fMed.rMedicao.rEstoque.Vl_unitario = vlmedio;
                                            }
                                    }
                                    CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMed.rMedicao, null);
                                    MessageBox.Show("Medição tanque alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
            
        }

        private void tsbAbertura_Click(object sender, EventArgs e)
        {
            if(bsVolumeVendas.Current != null)
                if ((bsVolumeVendas.Current as CamadaDados.Fiscal.LMC.TRegistro_VolumeVendido).Qtd_abertura > decimal.Zero)
                {
                    MessageBox.Show("Bico ja possui volume de abertura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            using (PostoCombustivel.TFEncerranteBico fEnc = new PostoCombustivel.TFEncerranteBico())
            {
                fEnc.Dt_encerrante = dt_emissao.Value;
                fEnc.Id_bico = bsVolumeVendas.Current != null ? (bsVolumeVendas.Current as CamadaDados.Fiscal.LMC.TRegistro_VolumeVendido).Id_bico.Value.ToString() : string.Empty;
                if (string.IsNullOrEmpty(fEnc.Id_bico) && (bsMedicaoTanque.Current != null))
                {
                    fEnc.Cd_empresa = cbEmpresa.SelectedValue.ToString();
                    fEnc.Id_tanque = (bsMedicaoTanque.Current as CamadaDados.Fiscal.LMC.TRegistro_AfericaoTanque).Id_tanque.Value.ToString();
                }
                if(fEnc.ShowDialog() == DialogResult.OK)
                    if(fEnc.rEncerrante != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(fEnc.rEncerrante, null);
                            MessageBox.Show("Encerrante gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void tsbFechamento_Click(object sender, EventArgs e)
        {
            if (bsVolumeVendas.Current != null)
                if ((bsVolumeVendas.Current as CamadaDados.Fiscal.LMC.TRegistro_VolumeVendido).Qtd_fechamento > decimal.Zero)
                {
                    MessageBox.Show("Bico ja possui volume de fechamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            using (PostoCombustivel.TFEncerranteBico fEnc = new PostoCombustivel.TFEncerranteBico())
            {
                fEnc.Dt_encerrante = dt_emissao.Value;
                fEnc.Id_bico = bsVolumeVendas.Current != null ? (bsVolumeVendas.Current as CamadaDados.Fiscal.LMC.TRegistro_VolumeVendido).Id_bico.Value.ToString() : string.Empty;
                if (string.IsNullOrEmpty(fEnc.Id_bico) && (bsMedicaoTanque.Current != null))
                {
                    fEnc.Cd_empresa = cbEmpresa.SelectedValue.ToString();
                    fEnc.Id_tanque = (bsMedicaoTanque.Current as CamadaDados.Fiscal.LMC.TRegistro_AfericaoTanque).Id_tanque.Value.ToString();
                }
                if (fEnc.ShowDialog() == DialogResult.OK)
                    if (fEnc.rEncerrante != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(fEnc.rEncerrante, null);
                            MessageBox.Show("Encerrante gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanLivroLMC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, gTanque);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
        }

        private void dt_emissao_ValueChanged(object sender, EventArgs e)
        {
            nr_pagina.Value = (dt_emissao.Value.Day + 1);
        }

        private void gerarLMCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            using (PostoCombustivel.TFLMCe fLMC = new PostoCombustivel.TFLMCe())
            {
                fLMC.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                fLMC.pDt_emissao = dt_emissao.Value.ToString("dd/MM/yyyy");
                if (fLMC.ShowDialog() == DialogResult.OK)
                    if (fLMC.rLMC != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_LMC.Gravar(fLMC.rLMC, null);
                            if (MessageBox.Show("LMC-e gravado com sucesso.\r\nDeseja enviar para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(fLMC.rLMC.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                                if (lCfg.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe configuração para enviar LMC-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                string msg = string.Empty;

                                if (PostoCombustivel.LMC.TLMC.GerarXMLLMC(fLMC.rLMC, lCfg[0], ref msg))
                                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    using (PostoCombustivel.TFLoteLMCe fLote = new PostoCombustivel.TFLoteLMCe())
                                    {
                                        fLote.ShowDialog();
                                    }
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void consultarLoteLMCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PostoCombustivel.TFLoteLMCe fLote = new PostoCombustivel.TFLoteLMCe())
            {
                fLote.ShowDialog();
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbCombustivel.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar combustivel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCombustivel.Focus();
                return;
            }
            using (PostoCombustivel.TFMedicaoTanque fMed = new PostoCombustivel.TFMedicaoTanque())
            {
                fMed.Cd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                fMed.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                fMed.Dt_lmc = dt_emissao.Value;
                fMed.Cd_combustivel = cbCombustivel.SelectedValue.ToString();
                fMed.St_abertura = false;
                if (fMed.ShowDialog() == DialogResult.OK)
                    if (fMed.rMedicao != null)
                        try
                        {
                            if (new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fMed.rMedicao.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_afericaoajustaest, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null)
                            {
                                decimal estoque = decimal.Zero;
                                decimal vlmedio = decimal.Zero;
                                //busca local de armazenamento do combustivel do tanque
                                object ob = new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_tanque",
                                        vOperador = "=",
                                        vVL_Busca = fMed.rMedicao.Id_tanquestr
                                    }
                                    }, "a.cd_local");
                                // busca a qtd de estoque
                                if (ob != null)
                                    estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(fMed.rMedicao.Cd_funcionario,
                                                                                                     fMed.rMedicao.Cd_combustivel,
                                                                                                     ob.ToString(), null);
                                if (fMed.rMedicao.Qtd_combustivel != estoque)
                                    if (MessageBox.Show("Saldo estoque fisico diferente da medição do tanque.\r\n" +
                                                       $"Saldo fisico atual:{estoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                       $"Quantidade Medição:{fMed.rMedicao.Qtd_combustivel.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))}\r\n" +
                                                       (estoque > fMed.rMedicao.Qtd_combustivel ? "Saida:" + (estoque - fMed.rMedicao.Qtd_combustivel).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) :
                                                       "Entrada:" + (fMed.rMedicao.Qtd_combustivel - estoque).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true))) + "\r\n" +
                                                       "Ajustar saldo estoque fisico?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        //busca vl medio
                                        vlmedio = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(fMed.rMedicao.Cd_empresa,
                                                                                                               fMed.rMedicao.Cd_combustivel,
                                                                                                               null);
                                        fMed.rMedicao.rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                                        fMed.rMedicao.rEstoque.Cd_empresa = fMed.rMedicao.Cd_empresa;
                                        fMed.rMedicao.rEstoque.Cd_produto = fMed.rMedicao.Cd_combustivel;
                                        fMed.rMedicao.rEstoque.Vl_medioestoque = vlmedio;
                                        fMed.rMedicao.rEstoque.Cd_local = ob.ToString();
                                        fMed.rMedicao.rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                                        fMed.rMedicao.rEstoque.St_registro = "A";
                                        fMed.rMedicao.rEstoque.Tp_lancto = "M";
                                        if (estoque < fMed.rMedicao.Qtd_combustivel)
                                        {
                                            fMed.rMedicao.rEstoque.Tp_movimento = "E";
                                            fMed.rMedicao.rEstoque.Qtd_entrada = Math.Round(fMed.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero);
                                            fMed.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(fMed.rMedicao.Qtd_combustivel - estoque, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                        }
                                        else
                                        {
                                            fMed.rMedicao.rEstoque.Tp_movimento = "S";
                                            fMed.rMedicao.rEstoque.Qtd_saida = Math.Round(estoque - fMed.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero);
                                            fMed.rMedicao.rEstoque.Vl_subtotal = Math.Round(Math.Round(estoque - fMed.rMedicao.Qtd_combustivel, 3, MidpointRounding.AwayFromZero) * vlmedio, 2, MidpointRounding.AwayFromZero);
                                        }
                                        fMed.rMedicao.rEstoque.Vl_unitario = vlmedio;
                                    }
                            }
                            CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(fMed.rMedicao, null);
                            MessageBox.Show("Medição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
