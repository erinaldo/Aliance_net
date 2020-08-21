using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormRelPadrao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Empreendimento
{
    public partial class FOrcExecucao : Form
    {
        private bool Altera_Relatorio;
        private TList_RegLanFaturamento lanFat = new TList_RegLanFaturamento();
        public string vCd_Local { get; set; } = string.Empty;
        private CamadaDados.Estoque.Cadastros.TList_CadProduto lProduto = new CamadaDados.Estoque.Cadastros.TList_CadProduto();
        public FOrcExecucao()
        {
            InitializeComponent();
        }
        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
             
            if (cbexec.Checked)
                status += "'E'";
            else if (cbfim.Checked)
                status += "'F'";
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_orcamento.Text.Trim();
            }
            if (!string.IsNullOrEmpty(nr_projeto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_projeto.Text;
            }
            if (!string.IsNullOrEmpty(nr_versao.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_versao.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(status))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + status + ")";
            }
            if (!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'", ">=");
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'", "<=");

            bsOrcamento.DataSource = new TCD_Orcamento().Select(filtro, 100, string.Empty);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();
            if (bsOrcamento.Current != null)
            {
                bsCFGEmpreendimento.DataSource = TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);
                vCd_Local = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).cd_local;
            }
            bsCFGEmpreendimento.ResetCurrentItem();
        }

        private void calculaunidades()
        {
            decimal valor = decimal.Zero;
            CamadaDados.Estoque.Cadastros.TList_CadUnidade unidade = CamadaNegocio.Estoque.Cadastros.TCN_CadUnidade.Busca(string.Empty, "HORAS", string.Empty, null);
            if (unidade.Count > 0)
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Id_unidadestr))
                    {
                        valor = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(p.Id_unidadestr, unidade[0].CD_Unidade, Math.Round(p.vl_unitario, 2, MidpointRounding.AwayFromZero), 2, null);
                        p.Vl_horas150 = decimal.Multiply(valor, Convert.ToDecimal("2,5"));
                        p.vl_horas100 = decimal.Multiply(valor, 2);
                        p.vl_horas50 = decimal.Multiply(valor, Convert.ToDecimal("1,5"));
                        p.vl_horas20 = decimal.Multiply(valor, Convert.ToDecimal("1,2"));
                    }
                });
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
            TotalizarOrcamento();
        }
        private decimal BuscarSaldoLocal(string pCd_empresa, string pCd_produto)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty((bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }
        private void ValidaItensSemSaldo()
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                int contador = 0;
                decimal saldo = decimal.Zero;
                lProduto.Clear();
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha.ForEach(f =>
                    {
                        saldo = BuscarSaldoLocal((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, f.Cd_produto);
                        if (saldo.Equals(decimal.Zero))
                        {
                            contador++;
                            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto prod = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                            prod.CD_Produto = f.Cd_produto;
                            lProduto.Add(prod);
                        }
                    });
                });
                if (contador <= 0)
                {
                    bbItensSemSaldo.Visible = false;
                }
                else
                {
                    if (contador > 1)
                    {
                        bbItensSemSaldo.Text = contador + ": produtos sem saldo em estoque";
                    }
                    else if (contador == 1)
                        bbItensSemSaldo.Text = "1: produto sem saldo em estoque";
                    bbItensSemSaldo.Visible = true;
                }
            }
        }

        private void TotalizarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                //Limpar Itens
                tot_itenspc.Value = decimal.Zero;
                tot_despesaspc.Value = decimal.Zero;
                tot_maodeobrapc.Value = decimal.Zero;
                vl_servico_exec.Value = decimal.Zero;
                vl_servico_pc.Value = decimal.Zero;
                TList_FichaTec ficha = new TList_FichaTec();
                ficha = TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.ToString(),
                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orc.Value.ToString(),
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaoOrc.Value.ToString(), string.Empty, string.Empty, string.Empty, null);
                //Itens
                TList_CadCFGEmpreendimento cfg = TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);


                TList_FichaTec fichfaturada = new TList_FichaTec();
                TList_FichaTec fichaafaturar = new TList_FichaTec();
                decimal t = decimal.Zero;
                decimal direto = decimal.Zero;
                if (cfg[0].tp_precoitem.Equals("0"))
                {
                    ficha.Where(p=> !p.St_addremessabool).ToList().ForEach(p =>
                    {
                        if (!p.St_fatdiretobool)
                        {
                            if (decimal.Subtract(p.Quantidade, p.Qtd_faturada) > decimal.Zero)
                            {
                                decimal total = decimal.Multiply(CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, null), p.Quantidade - p.Qtd_faturada);
                                if (total == decimal.Zero)
                                    total = decimal.Multiply(p.Vl_unitario, decimal.Subtract(p.Quantidade, p.Qtd_faturada));
                                t += total;

                            }
                            if (p.Qtd_faturada > decimal.Zero)
                            {
                                object obj = new TCD_LanFaturamento_Item().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vOperador = "exists(select 1 from TB_EMP_NFRemessa x where x.Nr_LanctoFiscal = a.Nr_LanctoFiscal and x.ID_NFItem = a.ID_NFItem " +
                                                    "and x.CD_Empresa = a.CD_Empresa and x.ID_Orcamento = "+(bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr+
                                                    " and x.NR_Versao = "+(bsOrcamento.Current as TRegistro_Orcamento).Nr_versao+
                                                    ")"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = p.Cd_produto
                                    }
                                }, "a.vl_unitario");
                                if (obj != null)
                                {
                                    decimal total = Convert.ToDecimal(obj.ToString()) * p.Qtd_faturada;
                                    t += total;
                                }
                                else
                                    MessageBox.Show("Erro de calculo produto: " + p.Cd_produto + " Sem valor");
                            }
                        }else
                        { 
                           // decimal.Subtract(p.Quantidade, p.Qtd_faturada)
                            if (decimal.Subtract(p.Quantidade, p.Qtd_faturada) > decimal.Zero)
                            {
                                decimal total = decimal.Multiply(CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, null), p.Quantidade - p.Qtd_faturada );
                                if (total == decimal.Zero)
                                    total = decimal.Multiply(p.Vl_unitario, decimal.Subtract(p.Quantidade, p.Qtd_faturada));
                                direto += total;

                            }
                            if (p.Qtd_faturada > decimal.Zero)
                            {
                                object obj = new TCD_CadFatDiretoItem().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "B.id_orcamento",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_orcamentostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "B.nr_versao",
                                        vOperador = "=",
                                        vVL_Busca = p.Nr_versaostr
                                    },
                                    new TpBusca() 
                                    { 
                                        vNM_Campo = "B.cd_produto", 
                                        vOperador = "=", 
                                        vVL_Busca = p.Cd_produto 
                                    } 
                                }, "B.vl_unitario"); 
                                if (obj != null) 
                                { 
                                    decimal total = Convert.ToDecimal(obj.ToString()) * p.Qtd_faturada; 
                                    direto += total; 
                                }  
                            } 
                        } 
                    }); 
                     
                } 
                else 
                    ficha.Where(p => !p.St_addremessabool).ToList().ForEach(p => t += decimal.Multiply(p.Vl_unitario, p.Quantidade)); 
                tot_itens.Value = t; 
                tot_exec_direto.Value = direto;
                //Buscar Qtd.Itens Executada 
                decimal ItensDirExec = decimal.Zero;
                if (bsFatDireto.Current != null)
                    (bsFatDireto.List as TList_CadFatDireto).ForEach(o =>
                    {
                        o.lFatDireto_Item.ForEach(p =>
                        {
                            ItensDirExec += p.vl_subtotal;
                        });
                    });
                //Buscar valor executado
                object objX = new TCD_LanFaturamento_Item().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(nf.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_EMP_NFRemessa x " +
                                                    "inner join TB_EMP_FichaTec y " +
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.id_orcamento = y.id_orcamento " +
                                                    "and x.nr_versao = y.nr_versao " +
                                                    "and x.id_atividade = y.id_atividade " +
                                                    "and x.id_registro = y.id_registro " +
                                                    "and x.id_ficha = y.id_ficha " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                    "and x.id_nfitem = a.id_nfitem " +
                                                    "and x.cd_empresa = '" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "' " +
                                                    "and x.id_orcamento = " + (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr + " " +
                                                    "and x.nr_versao = " + (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr + ")"
                                    }
                                }, "isnull(sum(isnull(a.Vl_SubTotal, 0)), 0)");
                tot_itensexec.Value = objX == null ? decimal.Zero : decimal.Parse(objX.ToString());
                if ( ItensDirExec == decimal.Zero ? false : !string.IsNullOrEmpty(ItensDirExec.ToString()))
                { 
                    tot_iten_dir.Value = Convert.ToDecimal(ItensDirExec.ToString());
                }
                else
                    tot_iten_dir.Value = decimal.Zero;
                if (tot_itens.Value != decimal.Zero)
                {
                    if (tot_itens.Value < tot_itensexec.Value)
                        tot_itenspc.Value = decimal.Zero;
                    else//100 - (tot_itensexec.Value / (tot_itens.Value / 100)
                        if (tot_itensexec.Value > decimal.Zero)
                        tot_itenspc.Value = decimal.Divide(decimal.Multiply(tot_itensexec.Value, 100),tot_itens.Value);
                    else
                        tot_itenspc.Value = decimal.Zero;
                }
                if (tot_exec_direto.Value != decimal.Zero)
                {
                    if (tot_exec_direto.Value < tot_iten_dir.Value)
                        tot_pcexecdireto.Value = decimal.Zero;
                    else
                        if (tot_exec_direto.Value > decimal.Zero)
                        tot_pcexecdireto.Value = decimal.Divide(decimal.Multiply(100, tot_iten_dir.Value), tot_exec_direto.Value);
                    else
                        tot_pcexecdireto.Value = decimal.Zero;
                }
                //Despesas
                object objd = new TCD_Despesas().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'" },
                                    new TpBusca { vNM_Campo = "a.id_orcamento", vOperador = "=", vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr },
                                    new TpBusca { vNM_Campo = "a.nr_versao", vOperador = "=", vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr },
                                    new TpBusca { vNM_Campo = "isnull(a.st_addexec, 'N')", vOperador = "<>", vVL_Busca = "'S'" }
                                }, "isnull(sum(a.Vl_SubTotal), 0)");
                tot_despesas.Value = decimal.Parse(objd?.ToString());          
                tot_despesasexec.Value = (bsExecDespesa.DataSource as TList_ExecDespesas).Sum(p => p.vl_executado);
                if (tot_despesas.Value != decimal.Zero)
                {
                    if (tot_despesas.Value < tot_despesasexec.Value)
                        tot_despesaspc.Value = decimal.Zero;
                    else
                    if (decimal.Zero != tot_despesasexec.Value)
                        tot_despesaspc.Value = decimal.Divide( decimal.Multiply(tot_despesasexec.Value, 100), tot_despesas.Value);
                    else
                        tot_despesaspc.Value = decimal.Zero;
                }
                //Mão de Obra
                tot_maodeobra.Value = (bsOrcamento.Current as TRegistro_Orcamento).custo_folha;
                decimal total_maodeobraexecutada = decimal.Zero;
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.ForEach(p =>
                {
                    total_maodeobraexecutada +=
                    (p.vl_unitario * p.qtd_executada) +
                    (p.vl_horas50 * p.qtd_exec_50) +
                    (p.vl_horas100 * p.qtd_exec_100) +
                    (p.Vl_horas150 * p.Qtd_exec_150) +
                    (p.vl_horas20 * p.qtd_exec_20);
                });
                decimal vl_total_servico = decimal.Zero;

                decimal teste2 = decimal.Zero;
                TList_FatOrcamento fatorc = new TList_FatOrcamento();
                fatorc = TCN_FatOrcamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                 (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                 (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, null);
                fatorc.ForEach(p =>
                {
                    vl_total_servico += p.vl_total_servico_nota;
                    teste2 += p.vl_totalnota;
                });

                vl_servico.Value = (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento;
                vl_servico_exec.Value = vl_total_servico;
                if (vl_total_servico != decimal.Zero)
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento >= vl_total_servico)
                        vl_servico_pc.Value = decimal.Divide(decimal.Multiply(vl_servico_exec.Value, 100), vl_servico.Value);
                }

                //teste1 é o valor com retencao
                if (teste2 < vl_total_servico)
                {
                    decimal teste1 = decimal.Zero;
                    teste1 = decimal.Divide(decimal.Divide(decimal.Multiply(100, teste2), vl_total_servico), 100);
                    vl_servico_2.Value = decimal.Multiply((bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento, teste1);
                    vl_servico_exec_2.Value = teste2;
                    panel_2.Visible = true;
                }
                else
                {
                    panel_2.Visible = false;    
                }

                tot_maodeobraexec.Value = total_maodeobraexecutada;
                if (tot_maodeobra.Value != decimal.Zero)
                {
                    if (tot_maodeobra.Value < tot_maodeobraexec.Value)
                        tot_maodeobrapc.Value = decimal.Zero;
                    else
                        if (tot_maodeobraexec.Value > decimal.Zero)
                        tot_maodeobrapc.Value = decimal.Divide(decimal.Multiply(tot_maodeobraexec.Value, 100), tot_maodeobra.Value);
                    else
                        tot_maodeobrapc.Value = decimal.Zero;
                }
            }
        }
        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                bsFatDireto.DataSource = TCN_CadFatDireto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                 (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                 string.Empty,
                                                                 (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
                (bsFatDireto.DataSource as TList_CadFatDireto).ForEach(p =>
                {
                    p.lFatDireto_Item = TCN_CadFatDiretoItem.Buscar(
                                                                                    p.cd_empresa,
                                                                                    p.Id_orcamentostr,
                                                                                    string.Empty, //(bsOrcamento.Current as TRegistro_Orcamento).id_projeto,
                                                                                    p.Nr_versaostr,
                                                                                    p.Cd_clifor,
                                                                                    p.Id_faturamentostr,
                                                                                    string.Empty, string.Empty, string.Empty, string.Empty, null
                                                                                    );

                });

                bsFatDireto_PositionChanged(this, new EventArgs());
                bsFatDireto.ResetCurrentItem();

                bsRemessa.DataSource = TCN_RemessaNf.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                                        string.Empty, string.Empty, null);
                (bsRemessa.List as TList_RemessaNf).ForEach(p =>
                { 
                    p.lItens = TCN_LanFaturamento_Item.Busca(
                    p.Cd_empresa,
                    p.nr_lanctofiscal, string.Empty, null);
                });
                bsRemessa_PositionChanged(this, new EventArgs());
                bsRemessa.ResetCurrentItem();

                bsExecDespesa.DataSource = TCN_ExecDespesas.Buscar(
                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                    cd_clifor.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
                bsExecDespesa.ResetCurrentItem();

                bsFatOrcamento.DataSource = TCN_FatOrcamento.Buscar(
                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                    null);
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra =
                    TCN_CadMaoObra.Busca((bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                               string.Empty,
                                                                               null);
                calculaunidades();
                //Totalizar Orçamento
                TotalizarOrcamento();
                bsFatOrcamento_PositionChanged(this, new EventArgs());
                bsFatOrcamento.ResetCurrentItem();

            }
        }

        private void bsFatDireto_PositionChanged(object sender, EventArgs e)
        {
            if (bsFatDireto.Current != null)
            {
                (bsFatDireto.Current as TRegistro_CadFatDireto).lFatDireto_Item = TCN_CadFatDiretoItem.Buscar(
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                                    string.Empty, //(bsOrcamento.Current as TRegistro_Orcamento).id_projeto,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                    (bsFatDireto.Current as TRegistro_CadFatDireto).Id_faturamentostr,
                                                                                    string.Empty, string.Empty, string.Empty, string.Empty, null
                                                                                    );

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current) != null)
            { 
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    if (MessageBox.Show("Deseja finalizar o orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "F";
                            CamadaNegocio.Empreendimento.TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                            // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.LimparFiltros();
                            cd_empresa.Text = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            id_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;

                            this.afterBusca();
                            MessageBox.Show("Projeto está finalizado.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Não pode evoluir este orçamento! deve ser negociado.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TotalizarOrcamento();
        }

        private void bbbOrcamento_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    using (TFLan_EvoluirOrcamento orc = new TFLan_EvoluirOrcamento())
                    {
                        orc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                        if (orc.ShowDialog() == DialogResult.OK)
                            try
                            {
                                TCN_Orcamento.Evoluir(orc.rOrcamento, null);
                                MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //cbEmOrcamento.Checked = true;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                    MessageBox.Show("Apenas Orçamento em execução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TotalizarOrcamento();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|" + cd_empresa.Text.Trim() + "", new Componentes.EditDefault[] { cd_empresa });
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|" + cd_clifor.Text.Trim() + "",
              new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                    return;
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    object valor = new TCD_FichaTec().BuscarEscalar(new TpBusca[]{
                                                                    new TpBusca(){
                                                                        vNM_Campo =  "a.nr_versao",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                                                                    },
                                                                    new TpBusca(){
                                                                        vNM_Campo = "a.id_orcamento",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                                                    }
                                                                    }, "sum(isnull(a.quantidade - a.qtd_faturada,0)) as total_afaturar");
                    if (!string.IsNullOrEmpty(valor.ToString()))
                    {
                        if (Convert.ToDecimal(valor) > 0)
                        {

                            using (FItensRemessa itensRemessa = new FItensRemessa())
                            {
                                itensRemessa.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                                itensRemessa.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                itensRemessa.vCD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                itensRemessa.vID_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                itensRemessa.vSt_fatdireto = "S";
                                itensRemessa.vTp_Fat = "Normal";
                                itensRemessa.vCd_Local = vCd_Local;

                                if (itensRemessa.ShowDialog() == DialogResult.OK)
                                {
                                    afterBusca();
                                    tabControl1.SelectedTab = tpItens;
                                    tabControl2.SelectedTab = tpRemessa;
                                    MessageBox.Show("Remessa gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }

                        }
                    }
                    else
                        MessageBox.Show("Empreendimento não existe saldo a faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Remessa apenas de orçamento em execução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TotalizarOrcamento();
        }

        private void bsRemessa_PositionChanged(object sender, EventArgs e)
        {
            if (bsRemessa.Current != null)
            {
                lanFat = new TCD_LanFaturamento().Select(
                    new TpBusca[] {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctofiscal",
                            vOperador = "=",
                            vVL_Busca = (bsRemessa.Current as TRegistro_RemessaNf).nr_lanctofiscal
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_Empresa",
                            vOperador = "=",
                            vVL_Busca = (bsRemessa.Current as TRegistro_RemessaNf).Cd_empresa
                        }
                    }, 1, string.Empty);


                TpBusca[] filtro = new TpBusca[0]; 
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + (bsRemessa.Current as TRegistro_RemessaNf).Cd_empresa + "'";
                
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + (bsRemessa.Current as TRegistro_RemessaNf).Id_orcamento + "'";

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + (bsRemessa.Current as TRegistro_RemessaNf).Nr_versao + "'";
                

                (bsRemessa.Current as TRegistro_RemessaNf).lItensremessa = new TCD_RemessaNf().SelectItens(filtro,0,string.Empty);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                    return;
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    using (Cadastro.FFatDireto direto = new Cadastro.FFatDireto())
                    {
                        direto.vCD_Clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                        direto.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                        direto.vID_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                        direto.vCD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        direto.vCd_Local = vCd_Local;
                        direto.vSt_fatdireto = "N";
                        if (direto.ShowDialog() == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tpItens;
                            tabControl2.SelectedTab = tpTerceiro;
                            MessageBox.Show("Remessa de terceiro gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        afterBusca();
                    }
                }
                else
                    MessageBox.Show("Remessa apenas de orçamento em execução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Selecione um orçamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TotalizarOrcamento();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PrintDespesa()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                    BindingSource BinExec = new BindingSource();
                    BinExec.DataSource = CamadaNegocio.Empreendimento.TCN_ExecDespesas.Buscar(
                        orcamento.Cd_empresa, orcamento.Id_orcamentostr, orcamento.Nr_versaostr,
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      false,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      1,
                                                                      null);

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                    orcamento.Cd_endereco,
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
                                                                    1,
                                                                    null);

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
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

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               orcamento.Cd_clifor,
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

                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");

                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Orcamento lista = new TList_Orcamento();
                    lista.Add(orcamento);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista;
                    bsOrcamento.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.Adiciona_DataSource("MAOOBRAEXEC", BinExec);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_EmpExecDespesa";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = orcamento.Cd_clifor;
                            fImp.pCd_representante = orcamento.Cd_vendedor;
                            fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
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

        private void PrintMaoObra()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                {
                    TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                    BindingSource BinExec = new BindingSource();
                    BinExec.DataSource = TCN_ExecCadMaoObra.Busca(
                        string.Empty, orcamento.Id_orcamentostr, orcamento.Nr_versaostr, orcamento.Cd_empresa, string.Empty, null);

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      false,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      1,
                                                                      null);

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                    orcamento.Cd_endereco,
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
                                                                    1,
                                                                    null);

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
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

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               orcamento.Cd_clifor,
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

                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");

                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Orcamento lista = new TList_Orcamento();
                    lista.Add(orcamento);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista;
                    bsOrcamento.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.Adiciona_DataSource("MAOOBRAEXEC", BinExec);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_EmpExecMaoDeObra";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = orcamento.Cd_clifor;
                            fImp.pCd_representante = orcamento.Cd_vendedor;
                            fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
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
        private void FOrcExecucao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bbItensSemSaldo.Visible = false;

            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROJETO", null))
                toolStripButton1.Visible = true;
        }
        private void afterPrint()
        {
            if (bsRemessa.Current != null)
            {
                TRegistro_LanFaturamento fat = TCN_LanFaturamento.BuscarNF(
                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                    (bsRemessa.Current as TRegistro_RemessaNf).nr_lanctofiscal.ToString(), null);

                if ((fat).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (fat).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (fat).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (fat).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((fat).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((fat).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (fat).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (fat).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((fat).Cd_empresa,
                                                                           (fat).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (fat).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
            }
        }
        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
            {
                MessageBox.Show("Selecione um projeto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                return;
            TList_CadCFGEmpreendimento cfg = TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);

            CamadaDados.Estoque.Cadastros.TList_CadProduto produto = new CamadaDados.Estoque.Cadastros.TList_CadProduto();
            produto = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca(cfg[0].cd_servico, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1, string.Empty, string.Empty, null);
            TRegistro_FichaTec item = null;


            if (!string.IsNullOrEmpty(cfg[0].cd_servico))
            {
                item = new TRegistro_FichaTec();
                item.Cd_produto = produto[0].CD_Produto;
                item.Ds_produto = produto[0].DS_Produto;
                item.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                item.Quantidade = 1;
            }
            //   decimal valor_execucao = decimal.Zero;
            TRegistro_FatOrcamento fatorc = new TRegistro_FatOrcamento();
            using (FFatOrcamento fat = new FFatOrcamento())
            {
                fat.rOrc = (bsOrcamento.Current as TRegistro_Orcamento);
                fat.rlFicha = item;
                fat.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                fat.vCd_tbpreco = cfg[0].Cd_tabelapreco;

                if (fat.ShowDialog() == DialogResult.OK)
                {
                    item = fat.rlFicha;
                    fatorc = fat.rFatOrc;
                    fatorc.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fatorc.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                    fatorc.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao; 
                    try
                    {
                        if (item != new TRegistro_FichaTec())
                        {
                            TList_FichaTec lficha = new TList_FichaTec() { item };

                            //Verificar se existe configuracao fiscal para servico
                            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPedFiscal =
                                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_CFGPedido x " +
                                                        "where a.cfg_pedido = x.cfg_pedido " +
                                                        "and isnull(x.st_servico, 'N') = 'S') "
                                        }
                                    }, 1, string.Empty);
                            if (lCfgPedFiscal.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe configuração fiscal para Serviço!",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                string moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, null);
                                if (string.IsNullOrEmpty(moeda))
                                    throw new Exception("Não existe moeda padrão configurada para a empresa " + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa);
                                //Gravar Pedidov
                                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                                rPed.CD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                rPed.CD_Clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                                rPed.CD_Endereco = (bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco;
                                rPed.TP_Movimento = lCfgPedFiscal[0].Tp_movimento;
                                rPed.Cd_moeda = moeda;
                                rPed.Cd_moeda = moeda;
                                rPed.CFG_Pedido = lCfgPedFiscal[0].Cfg_pedido;  //Pedido de saida
                                rPed.ST_Pedido = "F"; //Pedido fechado
                                rPed.ST_Registro = "F"; //Pedido fechado
                                rPed.Cd_municipioexecservico = fatorc.Cd_municipioexec;
                                lficha.ForEach(p =>
                                {
                                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item rItem = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                                    rItem.St_servico = true;
                                    rItem.Cd_Empresa = item.Cd_empresa;
                                    rItem.Cd_produto = item.Cd_produto;
                                    //rItem.Cd_local = projeto.Cd_local;
                                    //pega cd condfiscal do produto
                                    rItem.ImpostosItens.Concat(p.lImpostos);
                                    object cd_cfiscal = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(new TpBusca[]{
                                                                                                                    new TpBusca(){
                                                                                                                        vNM_Campo = "a.cd_produto",
                                                                                                                        vOperador = "=",
                                                                                                                        vVL_Busca = item.Cd_produto
                                                                                                                    }
                                                                                                                    }, "d.cd_condfiscal_produto");



                                    //buscar cdunidade
                                    CamadaDados.Estoque.Cadastros.TList_CadUnidade cd_unidade = CamadaNegocio.Estoque.Cadastros.TCN_CadUnidade.Busca(string.Empty, string.Empty, item.Sg_unidade, null);
                                    rItem.Cd_unidade_est = cd_unidade[0].CD_Unidade;
                                    rItem.Cd_unidade_valor = cd_unidade[0].CD_Unidade;
                                    rItem.Cd_condfiscal_produto = cd_cfiscal != null ? cd_cfiscal.ToString() : string.Empty;
                                    //rItem.Cd_unidade = item.Cd_unidade;
                                    rItem.Cd_local = cfg[0].cd_local;
                                    //rItem.Cd_unidEst = item.Cd_unidade;
                                    rItem.Quantidade = item.Quantidade;
                                    rItem.Vl_subtotal = item.Quantidade * item.Vl_unitario;
                                    rItem.Vl_unitario = item.Vl_unitario;
                                    //rItem.Pc_imposto_Aprox = item.Pc_aprox_imposto;

                                    rPed.Pedido_Itens.Add(rItem);
                                });

                                rPed.CD_CondPGTO = (bsOrcamento.Current as TRegistro_Orcamento).cd_condpgto;
                                TRegistro_LanFaturamento rNf =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturarServicoEmpreendimento((bsOrcamento.Current as TRegistro_Orcamento),
                                                                                                                    rPed,
                                                                                                                    cfg,
                                                                                                                    lficha,
                                                                                                                    lCfgPedFiscal[0].Cfg_pedido,
                                                                                                                    false,
                                                                                                                    decimal.Zero);

                               // rNf.Cd_condpgto = (bsOrcamento.Current as TRegistro_Orcamento).cd_condpgto;
                                TCN_LanFaturamento.GravarFaturamento(rNf, null, null);

                                TRegistro_LanFaturamento rNfs = TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa, rNf.Nr_lanctofiscalstr, null);
                                
                                fatorc.nr_lanctostr = rNfs.Nr_lanctofiscalstr;
                                fatorc.vl_executado = item.Vl_Executado;

                                TCN_FatOrcamento.Gravar(fatorc, null);
                                if (MessageBox.Show("Gravado com sucesso\n Deseja enviar NFS-e agora?", "Pergunta", MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    try
                                    {
                                        NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                        MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Busca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        // Busca();
                                    }
                                //vCd_Historico = fDup.vCd_historico;
                            }
                            afterBusca();
                            tabControl1.SelectedTab = tpServico;

                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void FOrcExecucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            if (e.KeyCode.Equals(Keys.F9))
                this.toolStripButton2_Click(this,new EventArgs());
            if (e.KeyCode.Equals(Keys.F11))
                this.bbbOrcamento_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.P) && e.Control) 
                Altera_Relatorio = true;
        }

        private void bbItensSemSaldo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            afterPrint();
        }
        private void print()
        {
            if (bsRemessa.Current != null)
            {
                

                if ((lanFat[0]).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (lanFat[0]).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (lanFat[0]).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (lanFat[0]).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (lanFat[0]).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    //{
                    //    MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    //if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    //{
                    //    MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (lanFat[0]).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (lanFat[0]).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((lanFat[0]).Cd_empresa,
                                                                           (lanFat[0]).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (lanFat[0]).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
            }
        }
        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                       bool St_imprimir,
                                       bool St_visualizar,
                                       bool St_enviaremail,
                                       List<string> Destinatarios,
                                       string Titulo,
                                       string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }
        private void Imprime_Danfe()
        {
            FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((lanFat[0]).Cd_empresa,
                                                                        (lanFat[0]).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(x=> x.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(x=> x.Vl_icms + x.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(x=> x.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(x=> x.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(x=> x.Vl_ICMSST + x.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
            //Buscar financeiro da DANFE
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + (lanFat[0]).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (lanFat[0]).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                lParc =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (lanFat[0]).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (lanFat[0]).Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count == 0)
                {
                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                    lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (lanFat[0]).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (lanFat[0]).Nr_lanctofiscal + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
            }
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (lanFat[0]).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                return;
            using (FExecucaoDespesas exec = new FExecucaoDespesas())
            {
                exec.vId_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                exec.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                exec.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                if (exec.ShowDialog() == DialogResult.OK)
                {
                    this.afterBusca();
                    tabControl1.SelectedTab = tpDespesas;

                }


            }
            TotalizarOrcamento();
        }

        private void bsFatOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if(bsFatOrcamento.Current != null)
            {
                (bsFatOrcamento.Current as TRegistro_FatOrcamento).lItens =
                    TCN_LanFaturamento_Item.Busca(
                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                        (bsFatOrcamento.Current as TRegistro_FatOrcamento).nr_lancto.ToString(),
                        string.Empty,
                        null);
                bsFatOrcamento.ResetCurrentItem();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (bsFatOrcamento.Current != null)
            {
                TRegistro_LanFaturamento fat = TCN_LanFaturamento.BuscarNF(
                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                        (bsFatOrcamento.Current as TRegistro_FatOrcamento).nr_lancto.ToString(), null);
                if (string.IsNullOrEmpty(fat.Nr_protocolo))
                {
                    MessageBox.Show("Não é permitido imprimir NFS-e sem Nº DE AUTENTIÇÃO.\r\n" +
                                    "Clique no botão <Consultar Autenticação NFS-e> para obter o Nº AUTENTICAÇÃO.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                fat.ItensNota =
                        TCN_LanFaturamento_Item.Busca(fat.Cd_empresa,
                                                                                            fat.Nr_lanctofiscal.ToString(),
                                                                                            string.Empty,
                                                                                            null);
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {

                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;

                    BindingSource BinDadosNFSE = new BindingSource();
                    BinDadosNFSE.DataSource = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento() { fat };

                    Rel.DTS_Relatorio = BinDadosNFSE;
                    fat.rClifor =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(fat.Cd_clifor, null);

                    fat.rClifor.lEndereco =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fat.Cd_clifor,
                                                                                  fat.Cd_endereco,
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
                    fat.rEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(fat.Cd_empresa, string.Empty, string.Empty, null)[0];
                    Rel.Parametros_Relatorio.Add("TOT_ISS", fat.ItensNota.Sum(p => p.Vl_iss));
                    Rel.Parametros_Relatorio.Add("TOT_ISS_RET", fat.ItensNota.Sum(p => p.Vl_issretido));
                    Rel.Parametros_Relatorio.Add("TOT_COFINS_RET", fat.ItensNota.Sum(p => p.Vl_retidoCofins));
                    Rel.Parametros_Relatorio.Add("TOT_PIS_RET", fat.ItensNota.Sum(p => p.Vl_retidoPIS));
                    Rel.Parametros_Relatorio.Add("TOT_IRRF_RET", fat.ItensNota.Sum(p => p.Vl_retidoIRRF));
                    Rel.Parametros_Relatorio.Add("TOT_CSLL_RET", fat.ItensNota.Sum(p => p.Vl_retidoCSLL));
                    Rel.Parametros_Relatorio.Add("TOT_INSS_RET", fat.ItensNota.Sum(p => p.Vl_retidoINSS));
                    Rel.Parametros_Relatorio.Add("TP_NATUREZAOPERACAOISS", fat.ItensNota[0].Tp_naturezaOperacaoISS);
                    Rel.Nome_Relatorio = "TFLanConsultaNFe";
                    Rel.NM_Classe = "TFLanConsultaNFe";
                    Rel.Modulo = "FAT";
                    Rel.Ident = "TFLanFaturamento_NFSE";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = fat.Cd_clifor;
                    fImp.pMensagem = "NFSE";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "NFSE",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "NFSE",
                                           fImp.pDs_mensagem);
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
                using (FRequisicaoCompra comp = new FRequisicaoCompra())
            {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                        return;
                    //Buscar Atividades
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                        TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                    {
                        TpBusca[] filtro = new TpBusca[0];
                        if (!string.IsNullOrEmpty(p.Cd_empresa))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = "'" + p.Cd_empresa.Trim() + "'";
                        }
                        if (!string.IsNullOrEmpty(p.Id_orcamentostr))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = p.Id_orcamentostr;
                        }
                        if (!string.IsNullOrEmpty(p.Nr_versaostr))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = p.Nr_versaostr;
                        }
                        if (!string.IsNullOrEmpty(p.Id_projetostr))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = p.Id_projetostr;
                        }
                        if (!string.IsNullOrEmpty(p.Id_registrostr))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.Id_Registro";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = p.Id_registrostr;
                        } 

                        Array.Resize(ref filtro, filtro.Length + 1); 
                        filtro[filtro.Length - 1].vOperador = "not exists ";
                        filtro[filtro.Length - 1].vVL_Busca = " (select 1 from TB_EMP_CompraEmpreendimento x " +
                                                              "where a.id_orcamento = x.id_orcamento and a.nr_versao = x.nr_versao " + 
                                                              "and a.ID_Atividade = x.ID_Atividade and a.ID_Ficha = x.ID_Ficha " + 
                                                              "and a.ID_Registro = x.ID_Registro and a.cd_empresa = x.cd_empresa) ";



                        p.lFicha = new TCD_FichaTec().Select(filtro, 0, string.Empty);
                    });




                    bsOrcamento.ResetCurrentItem();
                

                comp.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                if (comp.ShowDialog() == DialogResult.OK)
                {

                        //(bsOrcamento.Current as TRegistro_Orcamento) = comp.rOrcamento;
                        //(bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                        TList_FichaTec list = new TList_FichaTec();
                        comp.objetoItens.lFicha.ForEach(p =>
                        {
                            if (p.st_agregar)
                                list.Add(p);
                        });

                    CamadaNegocio.Empreendimento.TCN_Orcamento.GravarOrcReq((bsOrcamento.Current as TRegistro_Orcamento), list, null);

                    //MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.LimparFiltros();
                    //cbHomologacao.Checked = true;
                    this.afterBusca();
                    MessageBox.Show("Requisições lançadas.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null) return;
            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("F"))
                return;
            using (FListMaoDeObra list = new FListMaoDeObra())
            {
                list.rOrc = (bsOrcamento.Current as TRegistro_Orcamento);
                list.ShowDialog();
            }
            afterBusca();
            TotalizarOrcamento();
        }

        private void bbFat_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.PrintMaoObra();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.PrintDespesa();
        }

        private void dataGridDefault3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                { 
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = dataGridDefault3.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    } 
                }
        }

        private void cbexec_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexec.Checked)
                cbfim.Checked = false;
        }

        private void cbfim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfim.Checked)
                cbexec.Checked = false;
        }

        private void tot_despesas_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
