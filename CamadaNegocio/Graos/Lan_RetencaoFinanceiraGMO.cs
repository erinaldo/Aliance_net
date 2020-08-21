
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;
using BancoDados;
using Utils;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;

namespace CamadaNegocio.Graos
{
   public class TCN_Lan_RetencaoFinanceiraGMO
    {
       public static TList_Lan_RetencaoFinanceiraGMO Buscar(string vId_LanctoGMO,
                                                            string vCd_ContaGer,
                                                            string vCd_LanctoCaixa,
                                                            string vNr_Lancto,
                                                            string vId_Liquid,
                                                            string vCd_Parcela,
                                                            string vCd_Empresa,
                                                            TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];

           if (!string.IsNullOrEmpty(vId_LanctoGMO))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lanctoGMO";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vId_LanctoGMO;
           }
           if (!string.IsNullOrEmpty(vCd_ContaGer))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contaGer";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_ContaGer.Trim() + "'";
           }
           if (!string.IsNullOrEmpty(vCd_LanctoCaixa))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_LanctoCaixa";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vCd_LanctoCaixa;
           }
           if (!string.IsNullOrEmpty(vNr_Lancto))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_lancto";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vNr_Lancto;
           }
           if (!string.IsNullOrEmpty(vId_Liquid))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_Liquid";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vId_Liquid;
           }
           if (!string.IsNullOrEmpty(vCd_Parcela))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_Parcela";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vCd_Parcela;
           }
           if (!string.IsNullOrEmpty(vCd_Empresa))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_Empresa";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Empresa.Trim() + "'";
           }

           return new TCD_Lan_RetencaoFinanceiraGMO(banco).Select(vBusca, 0, string.Empty);
       }

       public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDuplicata(string Id_lanctoGMO,
                                                                                            TObjetoBanco banco)
       {
           return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_gro_retencaofinanceiraGMO x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.id_lanctoGMO = " + Id_lanctoGMO + ")"
                    }
                }, 0, string.Empty);
       }

       public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixa(string Id_lanctoGMO,
                                                                             TObjetoBanco banco)
       {
           return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(banco).Select(
               new TpBusca[]
               {
                   new TpBusca()
                   {
                       vNM_Campo = string.Empty,
                       vOperador = "exists",
                       vVL_Busca = "(select 1 from tb_gro_retencaofinanceiraGMO x " +
                                   "where x.cd_contager = a.cd_contager " + 
                                   "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                   "and x.id_lanctoGMO = " + Id_lanctoGMO + ")"
                   }
               }, 0, string.Empty);
       }

       public static string Gravar(TRegistro_Lan_RetencaoFinanceiraGMO val, TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_Lan_RetencaoFinanceiraGMO cd = new TCD_Lan_RetencaoFinanceiraGMO();
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               string retorno = cd.GravaRetencaoFinanceiraGMO(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return retorno;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar retenção: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }

       public static string Deletar(TRegistro_Lan_RetencaoFinanceiraGMO val, TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_Lan_RetencaoFinanceiraGMO cd = new TCD_Lan_RetencaoFinanceiraGMO();
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               cd.DeletarRetencaoFinanceiraGMO(val);
               //Excluir Royalties GMO
               TCN_LanRoyaltiesGMO.Buscar(val.Id_LanctoGMO.ToString(), 
                                          string.Empty, 
                                          string.Empty, 
                                          string.Empty, 
                                          string.Empty, 
                                          string.Empty, 
                                          string.Empty,
                                          cd.Banco_Dados).ForEach(p=> TCN_LanRoyaltiesGMO.DeletarLanRoyaltiesGMO(p, cd.Banco_Dados));
               //Estornar caixa
               CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_ContaGer,
                                                                val.Cd_LanctoCaixa.ToString(),
                                                                val.Cd_Empresa,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                decimal.Zero,
                                                                decimal.Zero,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                false,
                                                                string.Empty,
                                                                decimal.Zero,
                                                                false,
                                                                cd.Banco_Dados).ForEach(p => TCN_LanCaixa.EstornarCaixa(p, null, cd.Banco_Dados));
               //Estornar liquidacao
               TCN_LanLiquidacao.Busca(val.Cd_Empresa, 
                                       val.Nr_Lancto.Value, 
                                       val.Cd_Parcela.Value, 
                                       Convert.ToInt16(val.Id_Liquid), 
                                       val.Cd_ContaGer,
                                       decimal.Zero, 
                                       decimal.Zero, 
                                       decimal.Zero,
                                       decimal.Zero,
                                       decimal.Zero,
                                       decimal.Zero,
                                       decimal.Zero,
                                       false, 
                                       string.Empty, 
                                       0, 
                                       string.Empty, 
                                       cd.Banco_Dados).ForEach(p=> TCN_LanLiquidacao.CancelarLiquidacao(p, null, cd.Banco_Dados));

               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return "OK";
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir retenção: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }

       public static string Deletar(string cd_empresa,
                                    string nr_lanctoDuplicata,
                                    string id_liquidacao,
                                    string cd_parcela,
                                    TObjetoBanco banco)
       {
           TList_Lan_RetencaoFinanceiraGMO lRetGmo = Buscar(string.Empty, 
                                                            string.Empty, 
                                                            string.Empty, 
                                                            nr_lanctoDuplicata, 
                                                            id_liquidacao,
                                                            cd_parcela, 
                                                            cd_empresa, 
                                                            banco);
           
           
           if (lRetGmo.Count > 0)
               Deletar(lRetGmo[0], banco);
           return "OK";
       }
    }
}
