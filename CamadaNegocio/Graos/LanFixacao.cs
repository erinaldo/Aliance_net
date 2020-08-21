using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;
using CamadaNegocio.Estoque;
using CamadaNegocio.Faturamento.NotaFiscal;

namespace CamadaNegocio.Graos
{
    public class TCN_LanFixacao
    {
        public static TList_LanFixacao Buscar(string Id_fixacao,
                                              string Dt_fixacao,
                                              decimal Ps_fixado_total,
                                              decimal Vl_unitario,
                                              decimal Vl_totalliquido,
                                              string Ds_observacao,
                                              string Nr_contrato,
                                              string Cd_produto,
                                              int vTop,
                                              string vNm_campo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_fixacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fixacao;
            }
            if ((!string.IsNullOrEmpty(Dt_fixacao)) && (Dt_fixacao.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fixacao).ToString("yyyyMMdd")) + "'";
            }
            if (Ps_fixado_total > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ps_fixado_total";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Ps_fixado_total.ToString();
            }
            if (Vl_unitario > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_unitario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_unitario.ToString();
            }
            if (Vl_totalliquido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_totalliquido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_totalliquido.ToString();
            }
            if (!string.IsNullOrEmpty(Ds_observacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }

            return new TCD_LanFixacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarFixacao(TRegistro_LanFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFixacao qtb_fixacao = new TCD_LanFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fixacao.CriarBanco_Dados(true);
                else
                    qtb_fixacao.Banco_Dados = banco;
                //Gravar fixacao
                string retorno = qtb_fixacao.Gravar(val);
                val.Id_fixacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_FIXACAO"));
                //Gravar Fixacao X Contrato
                TCN_Fixacao_X_Contrato.Gravar(new TRegistro_Fixacao_X_Contrato()
                {
                    Id_fixacao = val.Id_fixacao,
                    Nr_contrato = val.Nr_contrato,
                }, qtb_fixacao.Banco_Dados);
                //Gravar nota fiscal de complemento
                val.lFixacaonf.ForEach(p=>
                    {
                        if (p.rNfComplemento != null)
                        {
                            TCN_LanFaturamento.GravarFaturamento(p.rNfComplemento, null, qtb_fixacao.Banco_Dados);
                            //Gravar Fixacao NF Complemento
                            TRegistro_Fixacao_NF rFComp = new TRegistro_Fixacao_NF();
                            rFComp.Id_fixacao = val.Id_fixacao;
                            rFComp.Id_fixacaonf = null;
                            rFComp.Cd_empresa = p.rNfComplemento.Cd_empresa;
                            rFComp.Nr_lanctofiscal = p.rNfComplemento.Nr_lanctofiscal;
                            rFComp.Id_nfitem = p.rNfComplemento.ItensNota[0].Id_nfitem;
                            rFComp.Qtd_fixacao = p.Qtd_fixacao;
                            rFComp.Vl_complemento = decimal.Zero;
                            rFComp.Vl_devolucao = decimal.Zero;
                            rFComp.Vl_fixacao = p.Vl_fixacao;
                            rFComp.Tp_nota = "C";
                            TCN_Fixacao_NF.GravarFixacaoNf(rFComp, qtb_fixacao.Banco_Dados);
                        }
                        //Gravar Fixacao NF Pauta
                        p.Tp_nota = "P";
                        p.Id_fixacao = val.Id_fixacao;
                        TCN_Fixacao_NF.GravarFixacaoNf(p, qtb_fixacao.Banco_Dados);
                    });
                //Gravar Nota Fiscal de Devolucao
                if(val.rNfDev != null)
                {
                    TCN_LanFaturamento.GravarFaturamento(val.rNfDev, null, qtb_fixacao.Banco_Dados);
                    TRegistro_Fixacao_NF rFDev = new TRegistro_Fixacao_NF();
                    rFDev.Id_fixacao = val.Id_fixacao;
                    rFDev.Id_fixacaonf = null;
                    rFDev.Cd_empresa = val.rNfDev.Cd_empresa;
                    rFDev.Nr_lanctofiscal = val.rNfDev.Nr_lanctofiscal;
                    rFDev.Id_nfitem = val.rNfDev.ItensNota[0].Id_nfitem;
                    rFDev.Qtd_fixacao = val.lFixacaonf.Where(p=> p.Vl_devolucao > decimal.Zero).Sum(p=> p.Qtd_fixacao);
                    rFDev.Vl_complemento = decimal.Zero;
                    rFDev.Vl_devolucao = decimal.Zero;
                    rFDev.Vl_fixacao = val.lFixacaonf.Where(p=> p.Vl_devolucao > decimal.Zero).Sum(p=> p.Vl_fixacao);
                    rFDev.Tp_nota = "D";
                    //Gravar Fixacao NF Devolucao
                    TCN_Fixacao_NF.GravarFixacaoNf(rFDev, qtb_fixacao.Banco_Dados);
                    val.lFixacaonf.ForEach(p =>
                     {
                         //Gravar Fixacao NF Pauta
                         p.Tp_nota = "P";
                         p.Id_fixacao = val.Id_fixacao;
                         TCN_Fixacao_NF.GravarFixacaoNf(p, qtb_fixacao.Banco_Dados);
                     });
                }
                //Gravar Financeiro Fixacao
                if (val.rDup != null)
                {
                    val.rDup.Nr_docto = "RAP" + val.Id_fixacao.Value.ToString();
                    Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_fixacao.Banco_Dados);
                    //Gravar Fixacao X Duplicata
                    TCN_Fixacao_X_Duplicata.Gravar(new TRegistro_Fixacao_X_Duplicata()
                    {
                        Id_fixacao = val.Id_fixacao,
                        Cd_empresa = val.rDup.Cd_empresa,
                        Nr_lancto = val.rDup.Nr_lancto
                    }, qtb_fixacao.Banco_Dados);
                    if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CONTROLAR_GMO", val.rDup.Cd_empresa, qtb_fixacao.Banco_Dados).Trim().ToUpper().Equals("S"))
                    {
                        val.lFixacaonf.Where(p => p.Vl_complemento > decimal.Zero).ToList().ForEach(p =>
                               {
                                //Gravar Retencao GMO
                                TRegistro_SaldoNFGMO rSaldoNf = new TRegistro_SaldoNFGMO();
                                   rSaldoNf.Cd_empresa = val.rDup.Cd_empresa;
                                   rSaldoNf.Nr_lanctoduplicata = val.rDup.Nr_lancto;
                                   rSaldoNf.Dt_saient = val.rDup.Dt_emissao;
                                   rSaldoNf.Nr_lanctofiscal = p.rNfComplemento.Nr_lanctofiscal;
                                   rSaldoNf.Id_nfitem = p.rNfComplemento.ItensNota[0].Id_nfitem;
                                   if (val.Qtd_gmo_declarado > decimal.Zero)
                                    //Liquidar duplicata retendo os Royalties
                                    TCN_LanRoyaltiesGMO.liquidaDuplicatas(rSaldoNf,
                                                                             new TRegistro_SaldoContratoGMO()
                                                                             {
                                                                                 Cd_produto = val.Cd_produto,
                                                                                 Nr_contrato = val.Nr_contrato,
                                                                                 Tp_gmo = "D"
                                                                             },
                                                                             val.Vl_royalties_declarado,
                                                                             val.Qtd_gmo_declarado,
                                                                             qtb_fixacao.Banco_Dados);
                                   if (val.Qtd_gmo_testado > decimal.Zero)
                                    //Liquidar duplicata retendo os Royalties
                                    TCN_LanRoyaltiesGMO.liquidaDuplicatas(rSaldoNf,
                                                                             new TRegistro_SaldoContratoGMO()
                                                                             {
                                                                                 Cd_produto = val.Cd_produto,
                                                                                 Nr_contrato = val.Nr_contrato,
                                                                                 Tp_gmo = "T"
                                                                             },
                                                                             val.Vl_royalties_testado,
                                                                             val.Qtd_gmo_testado,
                                                                             qtb_fixacao.Banco_Dados);
                               });
                        if (val.rNfDev != null)
                        {
                            //Gravar Retencao GMO
                            TRegistro_SaldoNFGMO rSaldoNf = new TRegistro_SaldoNFGMO();
                            rSaldoNf.Cd_empresa = val.rDup.Cd_empresa;
                            rSaldoNf.Nr_lanctoduplicata = val.rDup.Nr_lancto;
                            rSaldoNf.Dt_saient = val.rDup.Dt_emissao;
                            rSaldoNf.Nr_lanctofiscal = val.rNfDev.Nr_lanctofiscal;
                            rSaldoNf.Id_nfitem = val.rNfDev.ItensNota[0].Id_nfitem;
                            if (val.Qtd_gmo_declarado > decimal.Zero)
                                //Liquidar duplicata retendo os Royalties
                                TCN_LanRoyaltiesGMO.liquidaDuplicatas(rSaldoNf,
                                                                      new TRegistro_SaldoContratoGMO()
                                                                      {
                                                                          Cd_produto = val.Cd_produto,
                                                                          Nr_contrato = val.Nr_contrato,
                                                                          Tp_gmo = "D"
                                                                      },
                                                                      val.Vl_royalties_declarado,
                                                                      val.Qtd_gmo_declarado,
                                                                      qtb_fixacao.Banco_Dados);
                            if (val.Qtd_gmo_testado > decimal.Zero)
                                //Liquidar duplicata retendo os Royalties
                                TCN_LanRoyaltiesGMO.liquidaDuplicatas(rSaldoNf,
                                                                      new TRegistro_SaldoContratoGMO()
                                                                      {
                                                                          Cd_produto = val.Cd_produto,
                                                                          Nr_contrato = val.Nr_contrato,
                                                                          Tp_gmo = "T"
                                                                      },
                                                                      val.Vl_royalties_testado,
                                                                      val.Qtd_gmo_testado,
                                                                      qtb_fixacao.Banco_Dados);
                        }
                    }
                }
                if (st_transacao)
                    qtb_fixacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fixacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fixação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fixacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanFixacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFixacao qtb_fixacao = new TCD_LanFixacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fixacao.CriarBanco_Dados(true);
                else
                    qtb_fixacao.Banco_Dados = banco;
                
                //Cancelar NF de Fixacao
                TCN_Fixacao_NF.Buscar(string.Empty,
                                      val.Id_fixacao.Value.ToString(),
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      decimal.Zero,
                                      decimal.Zero,
                                      0,
                                      string.Empty,
                                      qtb_fixacao.Banco_Dados).ForEach(p =>
                                        {
                                            if (!p.Tp_nota.Trim().ToUpper().Equals("P"))//Nota de Complemento/Devolucao
                                                TCN_LanFaturamento.CancelarFaturamento(
                                                    TCN_LanFaturamento.BuscarNF(p.Cd_empresa,
                                                                                p.Nr_lanctofiscal.ToString(),
                                                                                qtb_fixacao.Banco_Dados), 
                                                    qtb_fixacao.Banco_Dados);
                                        });
                //Cancelar Duplicata
                val.lDupFixacao.ForEach(p =>
                    {
                        //Excluir Fixacao X Duplicata
                        TList_Fixacao_X_Duplicata lFDup = TCN_Fixacao_X_Duplicata.Buscar(val.Id_fixacao.Value.ToString(),
                                                                                         p.Cd_empresa,
                                                                                         p.Nr_lancto.ToString(),
                                                                                         qtb_fixacao.Banco_Dados);
                        if(lFDup.Count > 0)
                            TCN_Fixacao_X_Duplicata.Excluir(lFDup[0], qtb_fixacao.Banco_Dados);

                        //Cancelar Duplicata
                        Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_fixacao.Banco_Dados);
                    });              
                //Cancelar Fixacao
                val.St_registro = "C";
                qtb_fixacao.Gravar(val);
                if (st_transacao)
                    qtb_fixacao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fixacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar fixação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fixacao.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Fixacao_X_Contrato
    {
        public static TList_Fixacao_X_Contrato Buscar(string Nr_contrato,
                                                      string Id_fixacao,
                                                      int vTop,
                                                      string vNm_campo,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Id_fixacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fixacao;
            }

            return new TCD_Fixacao_X_Contrato(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_Fixacao_X_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_X_Contrato qtb_fix = new TCD_Fixacao_X_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fix.CriarBanco_Dados(true);
                else
                    qtb_fix.Banco_Dados = banco;
                //Gravar fixacao x pedido
                string retorno = qtb_fix.Gravar(val);
                if (st_transacao)
                    qtb_fix.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fix.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fix.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Fixacao_X_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_X_Contrato qtb_fix = new TCD_Fixacao_X_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fix.CriarBanco_Dados(true);
                else
                    qtb_fix.Banco_Dados = banco;
                //Deletar fixacao x pedido
                qtb_fix.Excluir(val);
                if (st_transacao)
                    qtb_fix.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fix.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fix.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Fixacao_NF
    {
        public static TList_Fixacao_NF Buscar(string Id_fixacaonf,
                                              string Id_fixacao,
                                              string Cd_empresa,
                                              string Nr_lanctofiscal,
                                              string Id_nfitem,
                                              decimal Qtd_fixacao,
                                              decimal Vl_fixacao,
                                              int vTop,
                                              string vNm_campo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_fixacaonf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fixacaonf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fixacaonf;
            }
            if (!string.IsNullOrEmpty(Id_fixacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fixacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            if (Qtd_fixacao > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qtd_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Qtd_fixacao.ToString();
            }
            if (Vl_fixacao > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_fixacao.ToString();
            }
            
            return new TCD_Fixacao_NF(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarFixacaoNf(TRegistro_Fixacao_NF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_NF qtb_fixacaonf = new TCD_Fixacao_NF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fixacaonf.CriarBanco_Dados(true);
                else
                    qtb_fixacaonf.Banco_Dados = banco;
                //Gravar fixacao Nf
                string retorno = qtb_fixacaonf.Gravar(val);
                if (st_transacao)
                    qtb_fixacaonf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fixacaonf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim()); 
            }
        }

        public static string DeletarFixacaoNf(TRegistro_Fixacao_NF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_NF qtb_fixacaonf = new TCD_Fixacao_NF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fixacaonf.CriarBanco_Dados(true);
                else
                    qtb_fixacaonf.Banco_Dados = banco;
                qtb_fixacaonf.Excluir(val);
                if (st_transacao)
                    qtb_fixacaonf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fixacaonf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fixacaonf.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Fixacao_X_Duplicata
    {
        public static TList_Fixacao_X_Duplicata Buscar(string Id_fixacao,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_fixacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fixacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fixacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }

            return new TCD_Fixacao_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_fixacao,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_gro_fixacao_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.id_fixacao = " + Id_fixacao + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Fixacao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_X_Duplicata qtb_fix = new TCD_Fixacao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fix.CriarBanco_Dados(true);
                else
                    qtb_fix.Banco_Dados = banco;
                string retorno = qtb_fix.Gravar(val);
                if (st_transacao)
                    qtb_fix.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fix.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fix.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Fixacao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fixacao_X_Duplicata qtb_fix = new TCD_Fixacao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fix.CriarBanco_Dados(true);
                else
                    qtb_fix.Banco_Dados = banco;
                qtb_fix.Excluir(val);
                if (st_transacao)
                    qtb_fix.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fix.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fix.deletarBanco_Dados();
            }
        }
    }
}
