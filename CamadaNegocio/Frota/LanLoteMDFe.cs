using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_LoteMDFe
    {
        public static TList_LoteMDFe Buscar(string Cd_empresa,
                                            string Id_lote,
                                            string Nr_mdfe,
                                            string Nr_cte,
                                            string Nr_notafiscal,
                                            string Dt_ini,
                                            string Dt_fin,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
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
            if (!string.IsNullOrEmpty(Nr_mdfe))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_mdfe x " +
                                                      "inner join tb_ctr_mdfe y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_mdfe = y.id_mdfe " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and y.nr_mdfe = " + Nr_mdfe + ")";
            }
            if (!string.IsNullOrEmpty(Nr_cte))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_mdfe x " +
                                                      "inner join tb_ctr_mdfe_documentos y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_mdfe = y.id_mdfe " +
                                                      "inner join tb_ctr_conhecimentofrete z " +
                                                      "on y.cd_empresa = z.cd_empresa " +
                                                      "and y.nr_lanctoctr = z.nr_lanctoctr " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and z.nr_ctrc = " + Nr_cte + ")";
            }
            if (!string.IsNullOrEmpty(Nr_notafiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_mdfe x " +
                                                      "inner jon tb_ctr_mdfe_documentos y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_mdfe = y.id_mdfe " +
                                                      "inner join tb_fat_notafiscal z " +
                                                      "on y.cd_empresa = z.cd_empresa " +
                                                      "and y.nr_lanctofiscal = z.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and z.nr_notafiscal = " + Nr_notafiscal + ")";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dhRecbto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dhRecbto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_LoteMDFe(banco).Select(filtro, 0, string.Empty, "a.id_lote desc");
        }

        public static string Gravar(TRegistro_LoteMDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteMDFe qtb_lote = new TCD_LoteMDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
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

        public static string Excluir(TRegistro_LoteMDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteMDFe qtb_lote = new TCD_LoteMDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
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

    public class TCN_Lote_X_MDFe
    {
        public static TList_Lote_X_MDFe Buscar(string Cd_empresa,
                                               string Id_lote,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
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
            return new TCD_Lote_X_MDFe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lote_X_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_MDFe qtb_lote = new TCD_Lote_X_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                string ret = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lote_X_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_MDFe qtb_lote = new TCD_Lote_X_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ReabrirMDFeProcessar(TRegistro_Lote_X_MDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_MDFe qtb_nfe = new TCD_Lote_X_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nfe.CriarBanco_Dados(true);
                else
                    qtb_nfe.Banco_Dados = banco;
                qtb_nfe.Excluir(val);
                //Verificar se existe mais alguma MDF-e amarrada ao lote
                object obj = qtb_nfe.BuscarEscalar(
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
                    TCN_LoteMDFe.Excluir(new TRegistro_LoteMDFe()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_lote = val.Id_lote
                    }, qtb_nfe.Banco_Dados);
                if (st_transacao)
                    qtb_nfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reabrir MDF-e processar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nfe.deletarBanco_Dados();
            }
        }

        public static void AtualizarDadosMDFe(string Cd_empresa,
                                              string Id_lote,
                                              string Id_mdfe,
                                              string cStat,
                                              string xMotivo,
                                              string dhRecbto,
                                              string nProt,
                                              string digVal,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_MDFe qtb_mdfe = new TCD_Lote_X_MDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mdfe.CriarBanco_Dados(true);
                else qtb_mdfe.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_EMPRESA", Cd_empresa);
                hs.Add("@P_LOTE", Id_lote);
                hs.Add("@P_ID_MDFE", Id_mdfe);
                hs.Add("@P_DT_PROC", DateTime.Parse(dhRecbto));
                hs.Add("@P_STAT", cStat);
                hs.Add("@P_MOTIVO", xMotivo);
                hs.Add("@P_NPROT", nProt);
                hs.Add("@P_DIGVAL", digVal);

                qtb_mdfe.executarSql("update tb_ctr_loteMDFe set cStat = '104', xMotivo = 'Arquivo processado', dhRecbto = @P_DT_PROC, dt_alt = getdate() " +
                                     "where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE\r\n" +
                                     "update TB_CTR_Lote_X_MDFe set cStat = @P_STAT, xMotivo = @P_MOTIVO, " +
                                     "dhRecbto = @P_DT_PROC, nProt = @P_NPROT, digval = @P_DIGVAL, " +
                                     "dt_alt = getdate() where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE and id_mdfe = @P_ID_MDFE", hs);
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mdfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar dados MDF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mdfe.deletarBanco_Dados();
            }
        }
    }
}
