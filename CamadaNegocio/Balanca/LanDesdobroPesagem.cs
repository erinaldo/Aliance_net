using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_DesdobroPesagem
    {
        public static TList_DesdobroPesagem Buscar(string Cd_empresa_orig,
                                                   string Tp_pesagem_orig,
                                                   string Id_ticket_orig,
                                                   string Cd_empresa_dest,
                                                   string Tp_pesagem_dest,
                                                   string Id_ticket_dest,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa_orig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa_orig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa_orig.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_pesagem_orig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem_orig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem_orig.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket_orig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket_orig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket_orig;
            }
            if (!string.IsNullOrEmpty(Cd_empresa_dest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa_dest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa_dest.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_pesagem_dest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem_dest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem_dest.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket_dest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket_dest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket_dest;
            }
            return new TCD_DesdobroPesagem(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanPesagemGraos BuscarTicketOrig(string Cd_empresa_dest,
                                                                string Tp_pesagem_dest,
                                                                string Id_ticket_dest,
                                                                BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanPesagemGraos(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_bal_desdobropesagem x " +
                                    "where x.cd_empresa_orig = a.cd_empresa " +
                                    "and x.tp_pesagem_orig = a.tp_pesagem " +
                                    "and x.id_ticket_orig = a.id_ticket " +
                                    "and x.cd_empresa_dest = '" + Cd_empresa_dest.Trim() + "' " +
                                    "and x.tp_pesagem_dest = '" + Tp_pesagem_dest.Trim() + "' " +
                                    "and x.id_ticket_dest = " + Id_ticket_dest + ")"
                    }
                }, string.Empty, string.Empty, 0, string.Empty);
        }

        public static TList_RegLanPesagemGraos BuscarTicketDest(string Cd_empresa_orig,
                                                                string Tp_pesagem_orig,
                                                                string Id_ticket_orig,
                                                                BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanPesagemGraos(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_bal_desdobropesagem x " +
                                    "where x.cd_empresa_dest = a.cd_empresa " +
                                    "and x.tp_pesagem_dest = a.tp_pesagem " +
                                    "and x.id_ticket_dest = a.id_ticket " +
                                    "and x.cd_empresa_orig = '" + Cd_empresa_orig.Trim() + "' " +
                                    "and x.tp_pesagem_orig = '" + Tp_pesagem_orig.Trim() + "' " +
                                    "and x.id_ticket_orig = " + Id_ticket_orig + ")"
                    }
                }, string.Empty, string.Empty, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DesdobroPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroPesagem qtb_desdobro = new TCD_DesdobroPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                string retorno = qtb_desdobro.Gravar(val);
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DesdobroPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroPesagem qtb_desdobro = new TCD_DesdobroPesagem();
            try
            {
                if(banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                qtb_desdobro.Excluir(val);
                if(st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensDesdobro
    {
        public static TList_ItensDesdobro Buscar(string Cd_empresa,
                                                   string Tp_pesagem,
                                                   string Id_ticket,
                                                   string Id_desdobro,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Id_desdobro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_desdobro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_desdobro;
            }
 
            return new TCD_ItensDesdobro(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensDesdobro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDesdobro qtb_desdobro = new TCD_ItensDesdobro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                val.Id_desdobrostr = CamadaDados.TDataQuery.getPubVariavel(qtb_desdobro.Gravar(val), "@P_ID_DESDOBRO");
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return val.Id_desdobrostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensDesdobro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDesdobro qtb_desdobro = new TCD_ItensDesdobro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                qtb_desdobro.Excluir(val);
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }
    }
}
