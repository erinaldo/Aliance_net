using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public class TCN_LoteCTe
    {
        public static TList_LoteCTe Buscar(string Cd_empresa,
                                           string Id_lote,
                                           string Dt_ini,
                                           string Dt_fin,
                                           string Tp_ambiente,
                                           string Nr_ctrc,
                                           string Cd_destinatario,
                                           string vOrder,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_recebimento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_recebimento)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Tp_ambiente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_ambiente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_ambiente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_ctrc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                      "inner join tb_ctr_conhecimentofrete y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctoctr = y.nr_lanctoctr " +
                                                      "where a.id_lote = x.id_lote " +
                                                      " and  y.nr_ctrc = " + Nr_ctrc + ")";
            }
            if (!string.IsNullOrEmpty(Cd_destinatario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                      "inner join tb_ctr_conhecimentofrete y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctoctr = y.nr_lanctoctr " +
                                                      "where a.id_lote = x.id_lote " +
                                                      "and y.cd_destinatario = '" + Cd_destinatario.Trim() + "')";
            }
            return new TCD_LoteCTe(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static string Gravar(TRegistro_LoteCTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCTe qtb_lote = new TCD_LoteCTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.Id_lotestr = CamadaDados.TDataQuery.getPubVariavel(qtb_lote.Gravar(val), "@P_ID_LOTE");
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteCTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCTe qtb_lote = new TCD_LoteCTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Lote_X_CTe
    {
        public static TList_Lote_X_CTe Buscar(string Cd_empresa,
                                              string Id_lote,
                                              string Nr_lanctoCTR,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Nr_lanctoCTR))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lanctoCTR";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoCTR;
            }
            return new TCD_Lote_X_CTe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lote_X_CTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_CTe qtb_lote = new TCD_Lote_X_CTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lote_X_CTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_CTe qtb_lote = new TCD_Lote_X_CTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ReabrirCteProcessar(TRegistro_Lote_X_CTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_CTe qtb_cte = new TCD_Lote_X_CTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else
                    qtb_cte.Banco_Dados = banco;
                qtb_cte.Excluir(val);
                //Verificar se existe mais alguma nota amarrada ao lote
                object obj = new TCD_Lote_X_CTe(qtb_cte.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_lote",
                                        vOperador = "=",
                                        vVL_Busca = val.Id_lote.ToString()
                                    }
                                }, "1");
                if (obj == null)
                    TCN_LoteCTe.Excluir(new TRegistro_LoteCTe()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_lote = val.Id_lote
                    }, qtb_cte.Banco_Dados);
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reabrir CTe processar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }

        public static void AtualizarDadosCTe(string Cd_empresa,
                                             string Id_lote,
                                             string Nr_lanctoCTR,
                                             string cStat,
                                             string xMotivo,
                                             string dhRecbto,
                                             string nProt,
                                             string digVal,
                                             string verAplic,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_CTe qtb_cte = new TCD_Lote_X_CTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else qtb_cte.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_EMPRESA", Cd_empresa);
                hs.Add("@P_LOTE", Id_lote);
                hs.Add("@P_LANCTOCTR", Nr_lanctoCTR);
                hs.Add("@P_DT_PROC", DateTime.Parse(dhRecbto));
                hs.Add("@P_STAT", cStat);
                hs.Add("@P_MOTIVO", xMotivo);
                hs.Add("@P_NPROT", nProt);
                hs.Add("@P_DIGVAL", digVal);
                hs.Add("@P_VERAPLIC", verAplic);

                qtb_cte.executarSql("update tb_ctr_lotecte set status = 104, ds_mensagem = 'Lote processado', DT_Recebimento = @P_DT_PROC, dt_alt = getdate() " +
                                     "where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE\r\n" +
                                     "update TB_CTR_Lote_X_CTe set status = @P_STAT, ds_mensagem = @P_MOTIVO, " +
                                     "dt_processamento = @P_DT_PROC, nr_protocolo = @P_NPROT, digval = @P_DIGVAL, veraplic = @P_VERAPLIC, " +
                                     "dt_alt = getdate() where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE and nr_lanctoCTR = @P_LANCTOCTR", hs);
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar dados CT-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }
    }
}
