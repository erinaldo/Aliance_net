using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil.Cadastro;

namespace CamadaNegocio.Contabil.Cadastro
{
    public class TCN_Cad_CTB_ParamZeramento
    {
        public static TList_Cad_CTB_ParamZeramento Buscar(string CD_Empresa,
                                                          string CD_CReceitas,
                                                          string CD_CDespesas,
                                                          string CD_CLucro,
                                                          string CD_CCusto,
                                                          string Cd_resultado,
                                                          string CD_CResultadoL,
                                                          string Cd_resultadoP,
                                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_Empresa;
            }
            if (!string.IsNullOrEmpty(CD_CReceitas))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaReceitas";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_CReceitas;
            }
            if (!string.IsNullOrEmpty(CD_CDespesas))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaDespesas";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_CDespesas;
            }
            if (!string.IsNullOrEmpty(CD_CLucro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaLucro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_CLucro;
            }
            if (!string.IsNullOrEmpty(CD_CCusto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaCusto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_CCusto;
            }
            if (!string.IsNullOrEmpty(Cd_resultado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Referencia";
                filtro[filtro.Length - 1].vOperador = "=";
                //filtro[filtro.Length - 1].vVL_Busca = 
            }
            if (!string.IsNullOrEmpty(CD_CResultadoL))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaResultadoL";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_CResultadoL;
            }
            return new TCD_Cad_CTB_ParamZeramento(banco).Select(filtro, 0, string.Empty, "b.cd_empresa asc");
        }

        public static string Gravar(TRegistro_Cad_CTB_ParamZeramento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_CTB_ParamZeramento qtb_plan = new TCD_Cad_CTB_ParamZeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                string retorno = qtb_plan.Gravar(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cad_CTB_ParamZeramento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_CTB_ParamZeramento qtb_plan = new TCD_Cad_CTB_ParamZeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                qtb_plan.Excluir(val);
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
    
    }
}
