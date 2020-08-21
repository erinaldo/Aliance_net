using CamadaDados.PostoCombustivel.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessaVendaCombustivel
    {
        public static CamadaDados.Faturamento.PDV.TRegistro_VendaRapida 
            ProcessarVendaCombustivel(List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda,
                                      List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItemConv,
                                      CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg,
                                      CamadaDados.PostoCombustivel.TRegistro_Convenio rConvenio,
                                      List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lCred,
                                      string Id_pdv,
                                      string Id_sessao,
                                      string Id_caixa,
                                      string LoginPDV,
                                      string Cd_operador)
        {
            CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
            rCupom.Cd_clifor = rConvenio != null ? rConvenio.lClifor[0].Cd_clifor : string.IsNullOrEmpty(lVenda[0].Cd_clifor) ? rCfg.Cd_clifor : lVenda[0].Cd_clifor;
            rCupom.Nm_clifor = rConvenio != null ? rConvenio.lClifor[0].Nm_clifor : string.IsNullOrEmpty(lVenda[0].Nm_clifor) ? rCfg.Nm_clifor : lVenda[0].Nm_clifor;
            rCupom.Nr_cgccpf = rConvenio != null ? rConvenio.lClifor[0].Nr_cgc_cpf : string.Empty;
            rCupom.Cd_endereco = rConvenio != null ? rConvenio.lClifor[0].Cd_endereco : string.Empty;
            rCupom.Cd_empresa = lVenda[0].Cd_empresa;
            rCupom.Cd_vend = Cd_operador;
            rCupom.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rCupom.Id_pdvstr = Id_pdv;
            rCupom.Id_sessaostr = Id_sessao;
            rCupom.St_registro = "A";
            //Adicionar item conveniencia
            lItemConv.ForEach(p => rCupom.lItem.Add(p));
            //Adicionar item combustivel
            lVenda.ForEach(p =>
            {
                //Criar item venda combustivel
                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item rItem = 
                new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                rItem.Cd_empresa = p.Cd_empresa;
                rItem.Cd_local = p.Cd_local;
                rItem.Ds_local = p.Ds_local;
                rItem.Cd_produto = p.Cd_produto;
                rItem.Ds_produto = p.Ds_produto;
                rItem.Cd_unidade = p.Cd_unidade;
                rItem.Ds_unidade = p.Ds_unidade;
                rItem.Sigla_unidade = p.Sigla_unidade;
                rItem.Cd_condfiscal_produto = p.Cd_condfiscal_produto;
                rItem.Cd_grupo = p.Cd_grupo;
                rItem.Cd_vendedor = rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).CD_vendedor;
                rItem.Nm_vendedor = rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Nm_vendedor;
                rItem.Quantidade = p.Volumeabastecido;
                if (rConvenio != null)
                {
                    string tp_acresdesc = string.IsNullOrWhiteSpace(rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Tp_acresdesc) ? rConvenio.Tp_acresdesc : rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Tp_acresdesc;
                    string tp_desconto = string.IsNullOrWhiteSpace(rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Tp_desconto) ? rConvenio.Tp_desconto : rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Tp_desconto;
                    decimal? vl_desc = rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Desconto > decimal.Zero ? rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))?.Desconto : rConvenio.Desconto;
                    if (rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_unitario > decimal.Zero)
                    {
                        rItem.Vl_unitario = rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_unitario;
                        rItem.Vl_subtotal = p.Volumeabastecido * rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_unitario;
                    }
                    else if (vl_desc > decimal.Zero && rConvenio.St_descvlunitbool)
                    {
                        //Verificar se convenio utiliza preco ANP
                        if (rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Tp_preco.Trim().ToUpper().Equals("A"))
                        {
                            //Buscar Preco ANP
                            rItem.Vl_unitario = CamadaNegocio.PostoCombustivel.Cadastros.TCN_PrecoANP.BuscarPrecoANP(p.Cd_produto, null);
                            if (rItem.Vl_unitario.Equals(decimal.Zero))
                                throw new Exception("Não existe preço ANP cadastrado para o combustivel " + p.Cd_produto.Trim() + ".");
                        }
                        else if (rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Tp_preco.Trim().ToUpper().Equals("C"))
                        {
                            //Preco de Custo
                            rItem.Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, null);
                            if (rItem.Vl_unitario.Equals(decimal.Zero))
                                throw new Exception("Não existe Valor Custo para o combustivel " + p.Cd_produto.Trim() + ".");
                        }
                        else
                            rItem.Vl_unitario = p.Vl_unitario;
                        rItem.Vl_unitario = tp_acresdesc.Trim().ToUpper().Equals("A") ?
                                                tp_desconto.Trim().ToUpper().Equals("V") ?
                                                    rItem.Vl_unitario + vl_desc.Value :
                                                    rItem.Vl_unitario + (rItem.Vl_unitario * Math.Round(vl_desc.Value / 100, 2)) :
                                                tp_desconto.Trim().ToUpper().Equals("V") ?
                                                    rItem.Vl_unitario - vl_desc.Value :
                                                    rItem.Vl_unitario - (rItem.Vl_unitario * Math.Round(vl_desc.Value / 100, 2));
                        rItem.Vl_subtotal = p.Volumeabastecido * rItem.Vl_unitario;
                    }
                    else
                    {
                        //Verificar se convenio utiliza preco ANP
                        if (rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Tp_preco.Trim().ToUpper().Equals("A"))
                        {
                            //Buscar Preco ANP
                            rItem.Vl_unitario = CamadaNegocio.PostoCombustivel.Cadastros.TCN_PrecoANP.BuscarPrecoANP(p.Cd_produto, null);
                            if (rItem.Vl_unitario.Equals(decimal.Zero))
                                throw new Exception("Não existe preço ANP cadastrado para o combustivel " + p.Cd_produto.Trim() + ".");
                            rItem.Vl_subtotal = rItem.Quantidade * rItem.Vl_unitario;
                        }
                        else if (rConvenio.lClifor.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Tp_preco.Trim().ToUpper().Equals("C"))
                        {
                            //Buscar Preco Custo
                            rItem.Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, null);
                            if (rItem.Vl_unitario.Equals(decimal.Zero))
                                throw new Exception("Não existe Valor Custo para o combustivel " + p.Cd_produto.Trim() + ".");
                            rItem.Vl_subtotal = rItem.Quantidade * rItem.Vl_unitario;
                        }
                        else
                        {
                            rItem.Vl_unitario = p.Vl_unitario;
                            rItem.Vl_subtotal = p.Vl_subtotal;
                        }
                        if (tp_acresdesc.Trim().ToUpper().Equals("A"))
                            rItem.Vl_acrescimo = tp_desconto.Trim().ToUpper().Equals("V") ?
                                Math.Round(vl_desc.Value * p.Volumeabastecido, 2) : Math.Round(rItem.Vl_subtotal * (vl_desc.Value / 100), 2);
                        else
                            rItem.Vl_desconto = tp_desconto.Trim().ToUpper().Equals("V") ?
                                Math.Round(vl_desc.Value * p.Volumeabastecido, 2) : Math.Round(rItem.Vl_subtotal * (vl_desc.Value / 100), 2);
                    }
                }
                rItem.St_registro = "A";
                rItem.rVendaCombustivel = p;
                //Adicionar item ao cupom
                rCupom.lItem.Add(rItem);
            });
            if (rConvenio != null)
            {
                decimal vl_cred = decimal.Zero;
                if (lCred != null)
                {
                    //Buscar portador devolucao de credito 
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lPort =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "tp_portadorpdv",
                                        vOperador = "in",
                                        vVL_Busca = "('A', 'P')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, 0, string.Empty, string.Empty);
                    if (lPort.Count.Equals(0))
                        throw new Exception("Não existe portador configurado para devolução de credito.");
                    lPort[0].lCred = lCred;
                    vl_cred = lCred.Sum(p => p.Vl_processar);
                    lPort[0].Vl_pagtoPDV = vl_cred;
                    rCupom.lPortador.Add(lPort[0]);
                }
                //Verificar se o valor receber e maior que saldo credito utilizar
                if (rCupom.lItem.Sum(p => p.Vl_subtotalliquido) > vl_cred)
                {
                    if (string.IsNullOrEmpty(rConvenio.Cd_portador))
                    {
                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                        {
                            fFechar.Text = "FINALIZAR VENDA POSTO COMBUSTIVEL";
                            fFechar.Id_caixaPDV = Id_caixa;   
                            fFechar.rCupom = rCupom;
                            fFechar.pCd_empresa = rCupom.Cd_empresa;
                            fFechar.pCd_clifor = rCupom.Cd_clifor;
                            fFechar.pNm_clifor = rCupom.Nm_clifor;
                            fFechar.pCd_operador = rCupom.Cd_vend;
                            fFechar.rCfg = rCfg;
                            fFechar.pVl_receber = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                            fFechar.LoginPDV = LoginPDV;
                            fFechar.st_convenio = true;
                            if (fFechar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                if (fFechar.lPortador != null)
                                    fFechar.lPortador.FindAll(p=> p.Vl_pagtoPDV > decimal.Zero).ForEach(p => rCupom.lPortador.Add(p));
                                else
                                    throw new Exception("Obrigatorio informar portador para fechar venda.");
                            else
                                throw new Exception("Obrigatorio informar portador para fechar venda.");
                        }
                    }
                    else
                    {
                        //Buscar registro portador
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador rPortador =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(rConvenio.Cd_portador,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      false,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null)[0];
                        //Verificar se o portador e duplicata
                        if (rPortador.Tp_portadorpdv.Trim().ToUpper().Equals("P"))
                        {
                            if (rConvenio.Qtd_duppendente > decimal.Zero)
                            {
                                //Buscar duplicatas em aberto para o cliente
                                object tot = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                                                new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "dup.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rConvenio.lClifor[0].Cd_clifor + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "t.tp_mov",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                }
                                            }, "count(*)");
                                if (tot != null)
                                    if (decimal.Parse(tot.ToString()) >= rConvenio.Qtd_duppendente)
                                        throw new Exception("Convenio permite somente " + rConvenio.Qtd_duppendente.ToString() + " duplicatas pendentes.\r\n" +
                                                            "Quantidade atual de duplicatas em aberto: " + tot.ToString());
                            }
                            //Gerar duplicata
                            CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                            rDup.Cd_empresa = rCupom.Cd_empresa;
                            rDup.Cd_clifor = rConvenio.lClifor[0].Cd_clifor;
                            rDup.Cd_endereco = rConvenio.lClifor[0].Cd_endereco;
                            rDup.Tp_duplicata = rConvenio.Tp_duplicata;
                            if (rConvenio.lClifor[0].Id_config.HasValue || rConvenio.Id_config_boleto.HasValue)
                                rDup.Id_configBoleto = rConvenio.lClifor[0].Id_config.HasValue ? rConvenio.lClifor[0].Id_config : rConvenio.Id_config_boleto;
                            rDup.Tp_docto = rConvenio.Tp_docto;
                            rDup.Cd_condpgto = rConvenio.Cd_condpgto;
                            //Buscar dados condicao pagamento
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rConvenio.Cd_condpgto,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          decimal.Zero,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          null)[0];
                            rDup.St_comentrada = rCond.St_comentrada;
                            //Buscar dados juro
                            rDup.Cd_juro = rCond.Cd_juro;
                            rDup.Tp_juro = rCond.Tp_juro;
                            rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                            rDup.Qt_parcelas = rCond.Qt_parcelas;
                            rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                            rDup.St_venctoferiado = rCond.St_venctoemferiado;
                            rDup.Cd_moeda = rCond.Cd_moeda;
                            //Buscar historico duplicata
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().BuscarEscalar(
                                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_duplicata",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rConvenio.Tp_duplicata + "'"
                                            }
                                        }, "a.cd_historico_dup");
                            rDup.Cd_historico = obj != null ? obj.ToString() : string.Empty;
                            rDup.Complhistorico = "RECEBIMENTO VENDA COMBUSTIVEL";
                            rDup.Nr_docto = rCupom.Id_vendarapidastr;
                            rDup.Dt_emissao = rCupom.Dt_emissao;
                            rDup.Vl_documento = rCupom.lItem.Sum(v => v.Vl_subtotalliquido) - vl_cred;
                            rDup.Vl_documento_padrao = rDup.Vl_documento;
                            //Calcular parcela
                            if (!string.IsNullOrEmpty(rConvenio.Periodofatura))
                            {
                                CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela reg_parcela = new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela();
                                reg_parcela.St_CalcVl_Parcela = true;
                                reg_parcela.Cd_empresa = rDup.Cd_empresa;
                                reg_parcela.Nr_lancto = rDup.Nr_lancto;
                                reg_parcela.Cd_parcela = 1;
                                reg_parcela.Vl_atual = rDup.Vl_documento;
                                reg_parcela.Vl_parcela = rDup.Vl_documento;
                                reg_parcela.cVl_atual = rDup.Vl_documento;
                                if (rConvenio.Periodofatura.Trim().ToUpper().Equals("S"))//Semanal
                                {
                                    if (rConvenio.Diasemana.Equals(decimal.Zero))//Segunda
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(1))//Terca
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(2))//Quarta
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(3))//Quinta
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(4))//Sexta
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(5))//Sabado
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                    else if (rConvenio.Diasemana.Equals(6))//Domingo
                                    {
                                        if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(7);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(6);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(5);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(4);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(3);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(2);
                                        else if (rDup.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                            reg_parcela.Dt_vencto = rDup.Dt_emissao.Value.AddDays(1);
                                    }
                                }
                                else if (rConvenio.Periodofatura.Trim().ToUpper().Equals("Q"))//Quinzenal
                                {
                                    if ((rDup.Dt_emissao.Value.Day >= 1) &&
                                        (rDup.Dt_emissao.Value.Day <= 15))
                                        reg_parcela.Dt_vencto = new DateTime(rDup.Dt_emissao.Value.Year, rDup.Dt_emissao.Value.Month, 16);
                                    else
                                        reg_parcela.Dt_vencto = new DateTime(rDup.Dt_emissao.Value.AddMonths(1).Year,
                                                                             rDup.Dt_emissao.Value.AddMonths(1).Month,
                                                                             1);
                                }
                                else//Mensal
                                {
                                    // obtém a quantidade de dias MÊS e ANO selecionados
                                    System.Globalization.Calendar c = new System.Globalization.GregorianCalendar();
                                    int daysMonth = c.GetDaysInMonth(rDup.Dt_emissao.Value.AddMonths(1).Year, rDup.Dt_emissao.Value.AddMonths(1).Month);
                                    //Dia vencimento parametro convenio
                                    int diavencto = rConvenio.Diavencto > decimal.Zero ? Convert.ToInt32(rConvenio.Diavencto) : 1;
                                    reg_parcela.Dt_vencto = new DateTime(rDup.Dt_emissao.Value.AddMonths(1).Year,
                                                                         rDup.Dt_emissao.Value.AddMonths(1).Month,
                                                                         daysMonth > diavencto ? diavencto : daysMonth);
                                }
                                if (rConvenio.St_utilizardiascondpgtobool &&
                                    (rCond.Qt_diasdesdobro > decimal.Zero))
                                    reg_parcela.Dt_vencto = reg_parcela.Dt_vencto.Value.AddDays(Convert.ToInt32(rCond.Qt_diasdesdobro));
                                rDup.Parcelas.Add(reg_parcela);
                            }
                            else if (rConvenio.Diavencto > decimal.Zero)
                            {
                                if (rConvenio.DiaFechamentoFat > decimal.Zero)
                                {
                                    CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela reg_parcela = new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela();
                                    reg_parcela.St_CalcVl_Parcela = true;
                                    reg_parcela.Cd_empresa = rDup.Cd_empresa;
                                    reg_parcela.Nr_lancto = rDup.Nr_lancto;
                                    reg_parcela.Cd_parcela = 1;
                                    reg_parcela.Vl_atual = rDup.Vl_documento;
                                    reg_parcela.Vl_parcela = rDup.Vl_documento;
                                    reg_parcela.cVl_atual = rDup.Vl_documento;
                                    if ((rDup.Dt_emissao.Value.Day > rConvenio.DiaFechamentoFat) ||
                                        (rConvenio.DiaFechamentoFat > rConvenio.Diavencto))
                                    {
                                        int ano = rDup.Dt_emissao.Value.AddMonths(1).Year;
                                        int mes = rDup.Dt_emissao.Value.AddMonths(1).Month;
                                        int dia = DateTime.DaysInMonth(ano, mes) < rConvenio.Diavencto ? DateTime.DaysInMonth(ano, mes) : Convert.ToInt32(rConvenio.Diavencto);
                                        reg_parcela.Dt_vencto = new DateTime(ano, mes, dia);
                                    }
                                    else
                                    {
                                        int dia = DateTime.DaysInMonth(rDup.Dt_emissao.Value.Year, rDup.Dt_emissao.Value.Month) < rConvenio.Diavencto ?
                                            DateTime.DaysInMonth(rDup.Dt_emissao.Value.Year, rDup.Dt_emissao.Value.Month) : Convert.ToInt32(rConvenio.Diavencto);
                                        reg_parcela.Dt_vencto = new DateTime(rDup.Dt_emissao.Value.Year, rDup.Dt_emissao.Value.Month, dia);
                                    }
                                    rDup.Parcelas.Add(reg_parcela);
                                }
                                else
                                {
                                    CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela reg_parcela = new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela();
                                    reg_parcela.St_CalcVl_Parcela = true;
                                    reg_parcela.Cd_empresa = rDup.Cd_empresa;
                                    reg_parcela.Nr_lancto = rDup.Nr_lancto;
                                    reg_parcela.Cd_parcela = 1;
                                    reg_parcela.Vl_atual = rDup.Vl_documento;
                                    reg_parcela.Vl_parcela = rDup.Vl_documento;
                                    reg_parcela.cVl_atual = rDup.Vl_documento;
                                    int ano = rDup.Dt_emissao.Value.AddMonths(1).Year;
                                    int mes = rDup.Dt_emissao.Value.AddMonths(1).Month;
                                    int dia = DateTime.DaysInMonth(ano, mes) < rConvenio.Diavencto ? DateTime.DaysInMonth(ano, mes) : Convert.ToInt32(rConvenio.Diavencto);
                                    reg_parcela.Dt_vencto = new DateTime(ano, mes, dia);
                                    rDup.Parcelas.Add(reg_parcela);
                                }
                            }
                            else
                                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(rDup, null);
                            rDup.DupCotacao = new CamadaDados.Financeiro.Duplicata.TRegistro_DuplicataCotacao()
                            {
                                Cd_empresa = rDup.Cd_empresa,
                                Cd_moeda = rDup.Cd_moeda,
                                Cd_moedaresult = rDup.Cd_moeda,
                                Dt_cotacao = rDup.Dt_emissao,
                                Login = Utils.Parametros.pubLogin,
                                Operador = "*",
                                Vl_cotacao = 1
                            };
                            //Verificar credito
                            CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                                new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                            if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rDup.Cd_clifor,
                                                                                                              rDup.Parcelas.Sum(p => p.Vl_parcela),
                                                                                                              true,
                                                                                                              ref rDados,
                                                                                                              null))
                                using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                                {
                                    fBloq.rDados = rDados;
                                    fBloq.Vl_fatura = rDup.Parcelas.Sum(p => p.Vl_parcela);
                                    fBloq.ShowDialog();
                                    if (!fBloq.St_desbloqueado)
                                        throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                                }

                            rPortador.Vl_pagtoPDV = rDup.Vl_documento;
                            rPortador.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata() { rDup };
                        }
                        else if (rPortador.St_cartaocreditobool)//Cartao Credito/Debito
                        {
                            using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                            {
                                if (fD_C.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    //Buscar dados fatura cartao credito
                                    using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                    {
                                        fCartao.pCd_empresa = rCupom.Cd_empresa;
                                        fCartao.D_C = fD_C.D_C;
                                        fCartao.Vl_saldofaturar = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                        if (fCartao.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                        {
                                            rPortador.lFatura = fCartao.lFatura;
                                            rPortador.Vl_pagtoPDV = fCartao.lFatura.Sum(p => p.Vl_fatura);
                                            if (fCartao.lFatura.Sum(p => p.Vl_fatura) >= fCartao.Vl_saldofaturar)
                                            {
                                                rPortador.Vl_trocoPDV = Math.Abs(fCartao.Vl_saldofaturar - fCartao.lFatura.Sum(p => p.Vl_fatura));
                                                if (rPortador.Vl_trocoPDV > decimal.Zero)
                                                {
                                                    using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                                    {
                                                        fTroco.Cd_empresa = rCupom.Cd_empresa;
                                                        fTroco.Id_caixaPDV = Id_caixa;
                                                        fTroco.Vl_troco = rPortador.Vl_trocoPDV;
                                                        fTroco.Cd_historioTroco = rCfg.Cd_historico_troco;
                                                        fTroco.Ds_historicoTroco = rCfg.Ds_historico_troco;
                                                        fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPDV, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                        if (fTroco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                        {
                                                            if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                            {
                                                                rPortador.Vl_credTroco = fTroco.Vl_trocoCredito;
                                                                rPortador.St_gerarCredito = true;
                                                            }
                                                            if (fTroco.lChRepasse != null)
                                                                fTroco.lChRepasse.ForEach(p => rPortador.lChTroco.Add(p));
                                                            if (fTroco.lChTroco != null)
                                                                fTroco.lChTroco.ForEach(p => rPortador.lChTroco.Add(p));
                                                            if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                                rPortador.Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                                            else rPortador.Vl_trocoPDV = decimal.Zero;
                                                        }
                                                        else
                                                            throw new Exception("Obrigatorio identificar tipo TROCO.");
                                                    }
                                                }
                                            }
                                            else
                                                using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                                {
                                                    fFechar.Text = "FINALIZAR VENDA POSTO COMBUSTIVEL";
                                                    fFechar.Id_caixaPDV = Id_caixa;
                                                    fFechar.rCupom = rCupom;
                                                    fFechar.pCd_empresa = rCupom.Cd_empresa;
                                                    fFechar.pCd_clifor = rCupom.Cd_clifor;
                                                    fFechar.pNm_clifor = rCupom.Nm_clifor;
                                                    fFechar.pCd_operador = Cd_operador;
                                                    fFechar.rCfg = rCfg;
                                                    fFechar.pVl_receber = fCartao.Vl_saldofaturar - fCartao.lFatura.Sum(p => p.Vl_fatura);
                                                    fFechar.LoginPDV = LoginPDV;
                                                    if (fFechar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                        if (fFechar.lPortador != null)
                                                            fFechar.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero).ForEach(p => rCupom.lPortador.Add(p));
                                                        else
                                                            throw new Exception("Obrigatorio informar portador para fechar venda.");
                                                    else
                                                        throw new Exception("Obrigatorio informar portador para fechar venda.");
                                                }
                                        }
                                        else
                                            throw new Exception("Fatura não foi informada... Recebimento não será efetivado!");
                                    }
                                }
                                else throw new Exception("Fatura não foi informada... Recebimento não será efetivado!");
                            }
                        }
                        else if (rPortador.St_controletitulobool)//Cheque
                        {
                            //Verificar credito
                            CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                                new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                            if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rCupom.Cd_clifor,
                                                                                                              rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred,
                                                                                                              false,
                                                                                                              ref rDados,
                                                                                                              null))
                                using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                                {
                                    fBloq.rDados = rDados;
                                    fBloq.Vl_fatura = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                    fBloq.ShowDialog();
                                    if (!fBloq.St_desbloqueado)
                                        throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                                }
                            using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                            {
                                fListaCheques.Tp_mov = "R";
                                fListaCheques.Cd_empresa = rCupom.Cd_empresa;
                                //Buscar Config PDV Empresa
                                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCupom.Cd_empresa, null);
                                if (lCfg.Count > 0)
                                {
                                    fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                                    fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                                }
                                fListaCheques.Cd_clifor = rCupom.Cd_clifor;
                                fListaCheques.Cd_historico = rCfg.Cd_historicocaixa;
                                fListaCheques.Ds_historico = rCfg.Ds_historicocaixa;
                                fListaCheques.Cd_portador = rPortador.Cd_portador;
                                fListaCheques.Ds_portador = rPortador.Ds_portador;
                                fListaCheques.Nm_clifor = rCupom.Nm_clifor;
                                fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                                fListaCheques.Vl_totaltitulo = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                if (fListaCheques.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rPortador.lCheque = fListaCheques.lCheques;
                                    rPortador.Vl_pagtoPDV = fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                                    if (fListaCheques.lCheques.Sum(p => p.Vl_titulo) >= fListaCheques.Vl_totaltitulo)
                                    {
                                        rPortador.Vl_trocoPDV = Math.Abs(fListaCheques.Vl_totaltitulo - fListaCheques.lCheques.Sum(p => p.Vl_titulo));
                                        if (rPortador.Vl_trocoPDV > decimal.Zero)
                                            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                            {
                                                fTroco.Cd_empresa = rCupom.Cd_empresa;
                                                fTroco.Id_caixaPDV = Id_caixa;
                                                fTroco.Vl_troco = rPortador.Vl_trocoPDV;
                                                fTroco.Cd_historioTroco = rCfg.Cd_historico_troco;
                                                fTroco.Ds_historicoTroco = rCfg.Ds_historico_troco;
                                                fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPDV, "PERMITIR GERAR CREDITO NO TROCO", null);
                                                if (fTroco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                    {
                                                        rPortador.Vl_credTroco = fTroco.Vl_trocoCredito;
                                                        rPortador.St_gerarCredito = true;
                                                    }
                                                    if (fTroco.lChRepasse != null)
                                                        fTroco.lChRepasse.ForEach(p => rPortador.lChTroco.Add(p));
                                                    if (fTroco.lChTroco != null)
                                                        fTroco.lChTroco.ForEach(p => rPortador.lChTroco.Add(p));
                                                    if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                        rPortador.Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                                    else rPortador.Vl_trocoPDV = decimal.Zero;
                                                }
                                                else
                                                    throw new Exception("Obrigatorio identificar tipo TROCO.");
                                            }
                                    }
                                    else
                                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                        {
                                            fFechar.Text = "FINALIZAR VENDA POSTO COMBUSTIVEL";
                                            fFechar.Id_caixaPDV = Id_caixa;
                                            fFechar.rCupom = rCupom;
                                            fFechar.pCd_empresa = rCupom.Cd_empresa;
                                            fFechar.pCd_clifor = rCupom.Cd_clifor;
                                            fFechar.pNm_clifor = rCupom.Nm_clifor;
                                            fFechar.pCd_operador = Cd_operador;
                                            fFechar.rCfg = rCfg;
                                            fFechar.pVl_receber = fListaCheques.Vl_totaltitulo - fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                                            fFechar.LoginPDV = LoginPDV;
                                            if (fFechar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                if (fFechar.lPortador != null)
                                                    fFechar.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero).ForEach(p => rCupom.lPortador.Add(p));
                                                else
                                                    throw new Exception("Obrigatorio informar portador para fechar venda.");
                                            else
                                                throw new Exception("Obrigatorio informar portador para fechar venda.");
                                        }
                                }
                                else
                                    throw new Exception("Cheque não foi lançado... Recebimento não será efetivado! ");
                            }
                        }
                        else if (rPortador.St_cartafretebool)//Carta Frete
                        {
                            using (PDV.TFLanListaCartaFrete fCf = new PDV.TFLanListaCartaFrete())
                            {
                                //Buscar dados condicao pagamento
                                CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond = null;
                                if (!string.IsNullOrEmpty(rConvenio.Cd_condpgto))
                                    rCond = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rConvenio.Cd_condpgto,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      1,
                                                                                                      string.Empty,
                                                                                                      null)[0];
                                //Calcular data vencimento
                                DateTime? dt_vencto = null;
                                if (!string.IsNullOrEmpty(rConvenio.Periodofatura))
                                {
                                    if (rConvenio.Periodofatura.Trim().ToUpper().Equals("S"))//Semanal
                                    {
                                        if (rConvenio.Diasemana.Equals(decimal.Zero))//Segunda
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(1))//Terca
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(2))//Quarta
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(3))//Quinta
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(4))//Sexta
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(5))//Sabado
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                        else if (rConvenio.Diasemana.Equals(6))//Domingo
                                        {
                                            if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SUNDAY"))//Domingo
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(7);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("MONDAY"))//Segunda
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(6);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("TUESDAY"))//Terca
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(5);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("WEDNESDAY"))//Quarta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(4);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("THURSDAY"))//Quinta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(3);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("FRIDAY"))//Sexta
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(2);
                                            else if (rCupom.Dt_emissao.Value.DayOfWeek.ToString().Trim().ToUpper().Equals("SATURDAY"))//Sabado
                                                dt_vencto = rCupom.Dt_emissao.Value.AddDays(1);
                                        }
                                    }
                                    else if (rConvenio.Periodofatura.Trim().ToUpper().Equals("Q"))//Quinzenal
                                    {
                                        if ((rCupom.Dt_emissao.Value.Day >= 1) &&
                                            (rCupom.Dt_emissao.Value.Day <= 15))
                                            dt_vencto = new DateTime(rCupom.Dt_emissao.Value.Year, rCupom.Dt_emissao.Value.Month, 16);
                                        else
                                            dt_vencto = new DateTime(rCupom.Dt_emissao.Value.AddMonths(1).Year,
                                                                     rCupom.Dt_emissao.Value.AddMonths(1).Month,
                                                                     1);
                                    }
                                    else//Mensal
                                        dt_vencto = new DateTime(rCupom.Dt_emissao.Value.AddMonths(1).Year,
                                                                 rCupom.Dt_emissao.Value.AddMonths(1).Month,
                                                                 rConvenio.Diavencto > decimal.Zero ? Convert.ToInt32(rConvenio.Diavencto) : 1);
                                    if (rConvenio.St_utilizardiascondpgtobool &&
                                        (rCond == null ? false : rCond.Qt_diasdesdobro > decimal.Zero))
                                        dt_vencto = dt_vencto.Value.AddDays(Convert.ToInt32(rCond.Qt_diasdesdobro));
                                }
                                else if (rConvenio.Diavencto > decimal.Zero)
                                {
                                    if (rConvenio.DiaFechamentoFat > decimal.Zero)
                                    {
                                        if ((rCupom.Dt_emissao.Value.Day > rConvenio.DiaFechamentoFat) ||
                                            (rConvenio.DiaFechamentoFat > rConvenio.Diavencto))
                                        {
                                            int ano = rCupom.Dt_emissao.Value.AddMonths(1).Year;
                                            int mes = rCupom.Dt_emissao.Value.AddMonths(1).Month;
                                            int dia = DateTime.DaysInMonth(ano, mes) < rConvenio.Diavencto ? DateTime.DaysInMonth(ano, mes) : Convert.ToInt32(rConvenio.Diavencto);
                                            dt_vencto = new DateTime(ano, mes, dia);
                                        }
                                        else
                                        {
                                            int dia = DateTime.DaysInMonth(rCupom.Dt_emissao.Value.Year, rCupom.Dt_emissao.Value.Month) < rConvenio.Diavencto ?
                                                DateTime.DaysInMonth(rCupom.Dt_emissao.Value.Year, rCupom.Dt_emissao.Value.Month) : Convert.ToInt32(rConvenio.Diavencto);
                                            dt_vencto = new DateTime(rCupom.Dt_emissao.Value.Year, rCupom.Dt_emissao.Value.Month, dia);
                                        }
                                    }
                                    else
                                    {
                                        int ano = rCupom.Dt_emissao.Value.AddMonths(1).Year;
                                        int mes = rCupom.Dt_emissao.Value.AddMonths(1).Month;
                                        int dia = DateTime.DaysInMonth(ano, mes) < rConvenio.Diavencto ? DateTime.DaysInMonth(ano, mes) : Convert.ToInt32(rConvenio.Diavencto);
                                        dt_vencto = new DateTime(ano, mes, dia);
                                    }
                                }
                                fCf.Dt_vencimento = dt_vencto;
                                fCf.Cd_empresa = rCupom.Cd_empresa;
                                fCf.Nm_empresa = rCupom.Nm_empresa;
                                fCf.Vl_totaltitulo = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                if (fCf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rPortador.lCartaFrete = fCf.lCarta;
                                    rPortador.Vl_pagtoPDV = fCf.lCarta.Sum(p => p.Vl_documento);
                                    if (fCf.lCarta.Sum(p => p.Vl_documento) >= fCf.Vl_totaltitulo)
                                    {
                                        rPortador.Vl_trocoPDV = Math.Abs(fCf.Vl_totaltitulo - fCf.lCarta.Sum(p => p.Vl_documento));
                                        if (rPortador.Vl_trocoPDV > decimal.Zero)
                                            using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                            {
                                                fTroco.Cd_empresa = rCupom.Cd_empresa;
                                                fTroco.Id_caixaPDV = Id_caixa;
                                                fTroco.St_desativarCred = true;
                                                fTroco.Vl_troco = rPortador.Vl_trocoPDV;
                                                fTroco.Cd_historioTroco = rCfg.Cd_historico_troco;
                                                fTroco.Ds_historicoTroco = rCfg.Ds_historico_troco;
                                                if (fTroco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                    {
                                                        rPortador.Vl_credTroco = fTroco.Vl_trocoCredito;
                                                        rPortador.St_gerarCredito = true;
                                                    }
                                                    if (fTroco.lChRepasse != null)
                                                        fTroco.lChRepasse.ForEach(p => rPortador.lChTroco.Add(p));
                                                    if (fTroco.lChTroco != null)
                                                        fTroco.lChTroco.ForEach(p => rPortador.lChTroco.Add(p));
                                                    if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                        rPortador.Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                                    else rPortador.Vl_trocoPDV = decimal.Zero;
                                                }
                                                else
                                                    throw new Exception("Obrigatorio identificar tipo TROCO.");
                                            }
                                    }
                                    else
                                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                        {
                                            fFechar.Text = "FINALIZAR VENDA POSTO COMBUSTIVEL";
                                            fFechar.Id_caixaPDV = Id_caixa;
                                            fFechar.rCupom = rCupom;
                                            fFechar.pCd_empresa = rCupom.Cd_empresa;
                                            fFechar.pCd_clifor = rCupom.Cd_clifor;
                                            fFechar.pNm_clifor = rCupom.Nm_clifor;
                                            fFechar.pCd_operador = Cd_operador;
                                            fFechar.rCfg = rCfg;
                                            fFechar.pVl_receber = fCf.Vl_totaltitulo - fCf.lCarta.Sum(p => p.Vl_documento);
                                            fFechar.LoginPDV = LoginPDV;
                                            if (fFechar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                if (fFechar.lPortador != null)
                                                    fFechar.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero).ForEach(p => rCupom.lPortador.Add(p));
                                                else
                                                    throw new Exception("Obrigatorio informar portador para fechar venda.");
                                            else
                                                throw new Exception("Obrigatorio informar portador para fechar venda.");
                                        }
                                }
                                else
                                    throw new Exception("Obrigatorio informar carta frete.");
                            }
                        }
                        else//Dinheiro
                        {
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Casas_decimais = 2;
                                fQtde.Vl_Minimo = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                fQtde.Vl_default = rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                fQtde.Ds_label = "Valor Receber";
                                if (fQtde.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rPortador.Vl_pagtoPDV = fQtde.Quantidade;
                                    rPortador.Vl_trocoPDV = fQtde.Quantidade - rCupom.lItem.Sum(p => p.Vl_subtotalliquido) - vl_cred;
                                    if (rPortador.Vl_trocoPDV > decimal.Zero)
                                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                        {
                                            fTroco.Cd_empresa = rCupom.Cd_empresa;
                                            fTroco.Id_caixaPDV = Id_caixa;
                                            fTroco.Vl_troco = rPortador.Vl_trocoPDV;
                                            fTroco.Cd_historioTroco = rCfg.Cd_historico_troco;
                                            fTroco.Ds_historicoTroco = rCfg.Ds_historico_troco;
                                            fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPDV, "PERMITIR GERAR CREDITO NO TROCO", null);
                                            if (fTroco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            {
                                                if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                {
                                                    rPortador.Vl_credTroco = fTroco.Vl_trocoCredito;
                                                    rPortador.St_gerarCredito = true;
                                                }
                                                if (fTroco.lChRepasse != null)
                                                    fTroco.lChRepasse.ForEach(p => rPortador.lChTroco.Add(p));
                                                if (fTroco.lChTroco != null)
                                                    fTroco.lChTroco.ForEach(p => rPortador.lChTroco.Add(p));
                                                if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                    rPortador.Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                                else rPortador.Vl_trocoPDV = decimal.Zero;
                                            }
                                            else
                                                throw new Exception("Obrigatorio identificar tipo TROCO.");
                                        }
                                }
                                else throw new Exception("Obrigatório informar valor recebido para fechar venda.");
                            }
                        }
                        //Adicionar portador a lista de recebimento do cupom
                        rCupom.lPortador.Add(rPortador);
                    }
                }
            }
            return rCupom;
        }

        public static void ProcessarEmpConcedido(CamadaDados.Faturamento.PDV.TRegistro_EmprestimoConcedido val,
                                                 TRegistro_CfgPosto rCfg)
        {
            if (string.IsNullOrEmpty(rCfg.Tp_duplicataemp) || string.IsNullOrEmpty(rCfg.Cd_condpgto))
                throw new Exception("Falta configuração para processar emprestimo concedido.\r\n" +
                                    "Caminho: Posto Combustivel->Cadastros->Configuração Posto");
            //Gerar duplicata
            CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
            rDup.Cd_empresa = val.Cd_empresa;
            rDup.Cd_clifor = val.Cd_clifor;
            //Buscar endereco cliente
            object end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                                }
                            }, "a.cd_endereco");
            if (end != null)
                rDup.Cd_endereco = end.ToString();
            rDup.Tp_duplicata = rCfg.Tp_duplicataemp;
            rDup.Tp_docto = rCfg.Tp_doctoemp;
            rDup.Cd_condpgto = rCfg.Cd_condpgto;
            //Buscar dados condicao pagamento
            CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rCfg.Cd_condpgto,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          decimal.Zero,
                                                                          decimal.Zero,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          1,
                                                                          string.Empty,
                                                                          null)[0];
            rDup.St_comentrada = rCond.St_comentrada;
            //Buscar dados juro
            rDup.Cd_juro = rCond.Cd_juro;
            rDup.Tp_juro = rCond.Tp_juro;
            rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
            rDup.Qt_parcelas = rCond.Qt_parcelas;
            rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
            rDup.St_venctoferiado = rCond.St_venctoemferiado;
            rDup.Cd_moeda = rCond.Cd_moeda;
            //Buscar historico duplicata
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().BuscarEscalar(
                            new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_duplicata",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfg.Tp_duplicataemp + "'"
                                        }
                                    }, "a.cd_historico_dup");
            rDup.Cd_historico = obj != null ? obj.ToString() : string.Empty;
            rDup.Complhistorico = "EMPRESTIMO CONCEDIDO";
            rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rDup.Vl_documento = val.Vl_emprestimo;
            rDup.Vl_documento_padrao = val.Vl_emprestimo;
            //Calcular parcela
            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(rDup, null);
            rDup.DupCotacao = new CamadaDados.Financeiro.Duplicata.TRegistro_DuplicataCotacao()
            {
                Cd_empresa = rDup.Cd_empresa,
                Cd_moeda = rDup.Cd_moeda,
                Cd_moedaresult = rDup.Cd_moeda,
                Dt_cotacao = rDup.Dt_emissao,
                Login = Utils.Parametros.pubLogin,
                Operador = "*",
                Vl_cotacao = 1
            };
            //Verificar credito
            CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
            if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rDup.Cd_clifor,
                                                                                                rDup.Parcelas.Sum(p => p.Vl_parcela),
                                                                                                true,
                                                                                                ref rDados,
                                                                                                null))
                using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                {
                    fBloq.rDados = rDados;
                    fBloq.Vl_fatura = rDup.Parcelas.Sum(p => p.Vl_parcela);
                    fBloq.ShowDialog();
                    if (!fBloq.St_desbloqueado)
                        throw new Exception("Não é permitido realizar venda para cliente com restrição crédito.");
                }

            val.rDup = rDup;
        }
    }
}
