using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_Sessao
    {
        public static TList_Sessao Buscar(string Id_pdv,
                                          string Id_sessao,
                                          string Login,
                                          string Tp_data,
                                          string Dt_ini,
                                          string Dt_fin,
                                          string St_registro,
                                          int vTop,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(Id_sessao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_sessao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_sessao;
            }
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_fechamento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(Dt_fin))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_fechamento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Sessao(banco).Select(filtro, vTop, string.Empty);
        }

        public static string Gravar(TRegistro_Sessao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Sessao qtb_sessao = new TCD_Sessao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_sessao.CriarBanco_Dados(true);
                else
                    qtb_sessao.Banco_Dados = banco;
                //Gravar sessao
                val.Id_sessaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_sessao.Gravar(val), "@P_ID_SESSAO");
                if (st_transacao)
                    qtb_sessao.Banco_Dados.Commit_Tran();
                return val.Id_sessaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_sessao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar sessão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_sessao.deletarBanco_Dados();
            }
        }

        public static string AbrirSessao(TRegistro_Sessao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Sessao qtb_sessao = new TCD_Sessao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_sessao.CriarBanco_Dados(true);
                else
                    qtb_sessao.Banco_Dados = banco;
                //Verificar se existe sessao aberta para o usuario
                if (qtb_sessao.BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_pdv",
                                        vOperador = "=",
                                        vVL_Busca = val.Id_pdvstr
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.login",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Login.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'F'"
                                    }
                                }, "1") != null)
                    throw new Exception("Usuario ja possui sessão aberta no pdv Nº" + val.Id_pdvstr);
                val.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                val.St_registro = "A";
                val.Id_sessaostr = Gravar(val, qtb_sessao.Banco_Dados);
                if (st_transacao)
                    qtb_sessao.Banco_Dados.Commit_Tran();
                return val.Id_sessaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_sessao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro abrir sessao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_sessao.deletarBanco_Dados();
            }
        }

        public static void EncerrarSessao(TRegistro_Sessao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Sessao qtb_sessao = new TCD_Sessao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_sessao.CriarBanco_Dados(true);
                else
                    qtb_sessao.Banco_Dados = banco;
                val.Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                val.St_registro = "F";
                Gravar(val, qtb_sessao.Banco_Dados);
                if (st_transacao)
                    qtb_sessao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_sessao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar sessao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_sessao.deletarBanco_Dados();
            }
        }
    }
}
