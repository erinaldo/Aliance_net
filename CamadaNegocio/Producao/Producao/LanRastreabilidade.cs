using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    #region Rastreabilidade
    public class TCN_Rastreabilidade
    {
        public static TList_Rastreabilidade Buscar(string Id_lote,
                                                 string Cd_empresa,
                                                 string Cd_clifor,
                                                 string Cd_produto,
                                                 string Nr_lote,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_lote.Trim() + "'";
            }

            return new TCD_Rastreabilidade(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Rastreabilidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rastreabilidade qtb_ordem = new TCD_Rastreabilidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Gravar Nº Lote
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ordem.Gravar(val), "@P_ID_LOTE"));
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Nº Lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Rastreabilidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rastreabilidade qtb_ordem = new TCD_Rastreabilidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Nº Série: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Mov Rastreabilidade
    public class TCN_MovRastreabilidade
    {
        public static TList_MovRastreabilidade Buscar(string Id_lote,
                                                 string Cd_empresa,
                                                 string Cd_produto,
                                                 string Id_mov,
                                                 string Nr_lanctofiscal,
                                                 string Tp_Mov,
                                                 string Id_ordem,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mov;
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Tp_Mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_Mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_Mov.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_PRD_OrdemProducao_X_Apontamento x " +
                                                      "where a.id_apontamento = x.id_apontamento " +
                                                      "and x.id_ordem = " + Id_ordem + ") ";
            }

            return new TCD_MovRastreabilidade(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovRastreabilidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovRastreabilidade qtb_ordem = new TCD_MovRastreabilidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Gravar Mov Rastreabilidade
                val.Id_mov = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ordem.Gravar(val), "@P_ID_MOV"));
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovRastreabilidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovRastreabilidade qtb_ordem = new TCD_MovRastreabilidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
