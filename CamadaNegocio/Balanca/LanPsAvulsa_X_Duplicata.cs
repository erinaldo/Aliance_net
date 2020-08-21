using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_PsAvulsa_X_Duplicata
    {
        public static TList_PsAvulsa_X_Duplicata Buscar(string Cd_empresa,
                                                        string Id_ticket,
                                                        string Nr_lancto,
                                                        string Tp_pesagem,
                                                        short vTop,
                                                        string vNm_campo,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Id_ticket.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (Nr_lancto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (Tp_pesagem.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            return new TCD_PsAvulsa_X_Duplicata(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanParcela Buscar(string Cd_empresa,
                                                                                  string Id_ticket,
                                                                                  string Tp_pesagem,
                                                                                  BancoDados.TObjetoBanco banco)
        {
            if ((Cd_empresa.Trim() != string.Empty) && (Id_ticket.Trim() != string.Empty) && (Tp_pesagem.Trim() != string.Empty))
                return new CamadaDados.Financeiro.Duplicata.TCD_LanParcela(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_bal_psavulsa_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + Cd_empresa.Trim()+"' " +
                                        "and x.id_ticket = " + Id_ticket + " " +
                                        "and x.tp_pesagem = '" + Tp_pesagem.Trim() + "')"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(d.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            else
                return new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
        }

        public static string GravarPsAvulsa_X_Duplicata(TRegistro_PsAvulsa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PsAvulsa_X_Duplicata qtb_ps = new TCD_PsAvulsa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ps.CriarBanco_Dados(true);
                else
                    qtb_ps.Banco_Dados = banco;
                string retorno = qtb_ps.GravarPsAvulsa_X_Duplicata(val);
                if (st_transacao)
                    qtb_ps.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ps.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar duplicata pesagem avulsa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ps.deletarBanco_Dados();
            }
        }

        public static string DeletarPsAvulsa_X_Duplicata(TRegistro_PsAvulsa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PsAvulsa_X_Duplicata qtb_ps = new TCD_PsAvulsa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ps.CriarBanco_Dados(true);
                else
                    qtb_ps.Banco_Dados = banco;
                qtb_ps.DeletarPsAvulsa_X_Duplicata(val);
                if (st_transacao)
                    qtb_ps.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ps.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar duplicata pesagem avulsa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ps.deletarBanco_Dados();
            }
        }
    }
}
