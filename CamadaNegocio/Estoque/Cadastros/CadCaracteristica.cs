using System;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    #region Classe Caracteristica

    public class TCN_Caracteristica
    {
        public static TList_Caracteristica Buscar(string Id_caracteristica,
                                                  string Ds_caracteristica,
                                                  int vTop,
                                                  string vNm_campo,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caracteristica.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caracteristica";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caracteristica;
            }
            if (!string.IsNullOrEmpty(Ds_caracteristica.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_caracteristica";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Ds_caracteristica.Trim() + "'";
            }

            return new TCD_Caracteristica(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCaracteristica(TRegistro_Caracteristica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caracteristica qtb_caracteristica = new TCD_Caracteristica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caracteristica.CriarBanco_Dados(true);
                else
                    qtb_caracteristica.Banco_Dados = banco;
                string retorno = qtb_caracteristica.Gravar(val);
                if (st_transacao)
                    qtb_caracteristica.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caracteristica.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar caracteristica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caracteristica.deletarBanco_Dados();
            }
        }

        public static string ExcluirCaracteristica(TRegistro_Caracteristica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caracteristica qtb_caracteristica = new TCD_Caracteristica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caracteristica.CriarBanco_Dados(true);
                else
                    qtb_caracteristica.Banco_Dados = banco;
                qtb_caracteristica.Excluir(val);
                if (st_transacao)
                    qtb_caracteristica.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caracteristica.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir caracteristica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caracteristica.deletarBanco_Dados();
            }
        }
    }

    #endregion

    #region Classe Valor Caracteristica
    public class TCN_ValorCaracteristica
    {
        public static TList_ValorCaracteristica Buscar(string Id_caracteristica,
                                                       string Id_item,
                                                       string Valor,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caracteristica.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caracteristica";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caracteristica;
            }
            if (!string.IsNullOrEmpty(Id_item.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Valor.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Valor.Trim() + "'";
            }
            return new TCD_ValorCaracteristica(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_ValorCaracteristica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ValorCaracteristica qtb_valor = new TCD_ValorCaracteristica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_valor.CriarBanco_Dados(true);
                else
                    qtb_valor.Banco_Dados = banco;
                string retorno = qtb_valor.Gravar(val);
                if (st_transacao)
                    qtb_valor.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_valor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_valor.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ValorCaracteristica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ValorCaracteristica qtb_valor = new TCD_ValorCaracteristica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_valor.CriarBanco_Dados(true);
                else
                    qtb_valor.Banco_Dados = banco;
                qtb_valor.Excluir(val);
                if (st_transacao)
                    qtb_valor.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_valor.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_valor.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
