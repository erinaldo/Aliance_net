using System;
using Utils;
using CamadaDados.Contabil.Cadastro;

namespace CamadaNegocio.Contabil.Cadastro
{
    public class TCN_PlanoContas
    {
        public static TList_CadPlanoContas Buscar(string Cd_conta_ctb,
                                                  string Ds_conta_ctb,
                                                  string Tp_conta,
                                                  string Cd_conta_pai,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_conta_ctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta_ctb;
            }
            if (!string.IsNullOrEmpty(Ds_conta_ctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_contactb";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_conta_ctb.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Tp_conta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_conta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_conta.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta_pai))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctbpai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta_pai;
            }
            return new TCD_CadPlanoContas(banco).Select(filtro, 0, string.Empty, "a.cd_classificacao asc"); 
        }

        public static string Gravar(TRegistro_CadPlanoContas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPlanoContas qtb_plan = new TCD_CadPlanoContas();
            try
            {
                if(banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                string retorno = qtb_plan.Grava(val);
                if(st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " +ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadPlanoContas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPlanoContas qtb_plan = new TCD_CadPlanoContas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                //Verificar se conta possui movimentação
                if (new CamadaDados.Contabil.TCD_LanctosCTB(qtb_plan.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "a.cd_conta_ctb",
                            vOperador = "like",
                            vVL_Busca = "'" + val.Cd_conta_ctbstr + "%'"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir conta contabil com movimento.");
                qtb_plan.Deleta(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static void MoverRegistros(TRegistro_CadPlanoContas rOrig, TRegistro_CadPlanoContas rDest, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPlanoContas qtb_itens = new TCD_CadPlanoContas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                qtb_itens.executarSql("update tb_ctb_planocontas set cd_classificacao = '" + rDest.Cd_classificacao.Trim() + "' " +
                                      ",dt_alt = getdate() where cd_conta_ctb = " + rOrig.Cd_conta_ctbstr + "\r\n" +
                                      "update tb_ctb_planocontas set cd_classificacao = '" + rOrig.Cd_classificacao.Trim() + "' " +
                                      ",dt_alt = getdate() where cd_conta_ctb = " + rDest.Cd_conta_ctbstr, null);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro mover registros: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void AplicarContaReferencial(TRegistro_CadPlanoContas rConta,
                                                   TRegistro_PlanoReferencial rRef,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPlanoContas qtb_plano = new TCD_CadPlanoContas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plano.CriarBanco_Dados(true);
                else qtb_plano.Banco_Dados = banco;
                //Buscar Contas Contabeis
                qtb_plano.Select(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_classificacao",
                        vOperador = "like",
                        vVL_Busca = "'" + rConta.Cd_classificacao.Trim() + "%'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_conta",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 0, string.Empty, string.Empty).ForEach(p =>
                    {
                        p.Tp_contasped = rRef.Natureza.FormatStringEsquerda(2, '0');
                        p.Cd_referencia = rRef.Cd_referencia;
                        qtb_plano.Grava(p);
                    });
                if (st_transacao)
                    qtb_plano.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plano.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plano.deletarBanco_Dados();
            }
        }

        public static string CalcularClassif(string Cd_contapai, BancoDados.TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(Cd_contapai))
            {
                object obj = new TCD_CadPlanoContas().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_conta_ctbpai", vOperador = "is", vVL_Busca = "null" } }, "max(a.cd_classificacao)");
                if (obj != null)
                    return (Convert.ToInt32(obj.ToString()) + 1).ToString();
                else return "1";
            }
            else
            {
                object obj = new TCD_CadPlanoContas().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_conta_ctbpai", vOperador = "=", vVL_Busca = Cd_contapai } }, "max(a.cd_classificacao)");
                if(obj == null)
                {
                    obj = new TCD_CadPlanoContas().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_conta_ctb", vOperador = "=", vVL_Busca = Cd_contapai } }, "a.cd_classificacao");
                    if (obj.ToString().Split(new char[] { '.' }).Length.Equals(4))
                        return obj.ToString() + ".01";
                    else if (obj.ToString().Split(new char[] { '.' }).Length.Equals(5))
                        return obj.ToString() + ".001";
                    else return obj.ToString() + ".1";
                }
                else
                {
                    if (obj.ToString().Split(new char[] { '.' }).Length.Equals(2))
                        return obj.ToString().Substring(0, 2) + (Convert.ToInt32(obj.ToString().Substring(2, 1)) + 1).ToString();
                    else if (obj.ToString().Split(new char[] { '.' }).Length.Equals(3))
                        return obj.ToString().Substring(0, 4) + (Convert.ToInt32(obj.ToString().Substring(4, 1)) + 1).ToString();
                    else if (obj.ToString().Split(new char[] { '.' }).Length.Equals(4))
                        return obj.ToString().Substring(0, 6) + (Convert.ToInt32(obj.ToString().Substring(6, 2)) + 1).FormatStringEsquerda(2, '0');
                    else return obj.ToString().Substring(0, 9) + (Convert.ToInt32(obj.ToString().Substring(9, 3)) + 1).FormatStringEsquerda(3, '0');
                }
            }
        }
    }   
}
