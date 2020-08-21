using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NFES;
using Utils;

namespace CamadaNegocio.Faturamento.NFES
{
    #region Lote RPS
    public class TCN_LoteRPS
    {
        public static TList_LoteRPS Buscar(string Id_lote,
                                           string Cd_empresa,
                                           string Nr_notafiscal,
                                           string Cd_clifor,
                                           string Dt_ini,
                                           string Dt_fin,
                                           string Nr_protocolo,
                                           string Tp_ambiente,
                                           string St_lote,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
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
            if (!string.IsNullOrEmpty(Nr_notafiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_LoteRPS_X_NFES x " +
                                                      "inner join TB_FAT_NotaFiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and y.nr_notafiscal = " + Nr_notafiscal + ")";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_LoteRPS_X_NFES x " +
                                                      "inner join TB_FAT_NotaFiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lote = a.id_lote " +
                                                      "and y.cd_clifor = '" + Cd_clifor.Trim()+ "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(Nr_protocolo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_protocolo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nr_protocolo.Trim() + "'%)";
            }
            if (!string.IsNullOrEmpty(Tp_ambiente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_ambiente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_ambiente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_lote";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_lote.Trim() + ")";
            }

            return new TCD_LoteRPS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteRPS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS qtb_lote = new TCD_LoteRPS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_lote.Gravar(val), "@P_ID_LOTE"));
                //Gravar Notas Fiscais do Lote
                val.lNfes.ForEach(p =>
                    {
                        TCN_LoteRPS_X_NFES.Gravar(new TRegistro_LoteRPS_X_NFES()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nr_lanctofiscal = p.Nr_lanctofiscal,
                            Id_lote = val.Id_lote
                        }, qtb_lote.Banco_Dados);
                    });
                //Gravar Mensagem Lote
                val.lMsgRPS.ForEach(p =>
                    {
                        p.Id_lote = val.Id_lote;
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_MsgRetornoRPS.Gravar(p, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote RPS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteRPS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS qtb_lote = new TCD_LoteRPS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.lMsgRPS.ForEach(p=> TCN_MsgRetornoRPS.Excluir(p, qtb_lote.Banco_Dados));
                val.lNfes.ForEach(p=> TCN_LoteRPS_X_NFES.Excluir(
                    new TRegistro_LoteRPS_X_NFES()
                    {
                        Id_lote = val.Id_lote,
                        Cd_empresa = p.Cd_empresa,
                        Nr_lanctofiscal = p.Nr_lanctofiscal
                    }, qtb_lote.Banco_Dados));
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote RPS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ReabrirLoteRPS(TRegistro_LoteRPS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS qtb_lote = new TCD_LoteRPS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                Excluir(val, qtb_lote.Banco_Dados);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reabrir lote RPS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Lote RPS X NFES
    public class TCN_LoteRPS_X_NFES
    {
        public static TList_LoteRPS_X_NFES Buscar(string Id_lote,
                                                  string Cd_empresa,
                                                  string Nr_lanctofiscal,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
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
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }

            return new TCD_LoteRPS_X_NFES(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento BuscarNfes(string Id_lote,
                                                                                            string Cd_empresa,
                                                                                            BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_loterps_x_nfes x "+
                                    "where x.cd_empresa = a.cd_empresa "+
                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                    "and x.id_lote = " + Id_lote + " " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "')"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteRPS_X_NFES val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS_X_NFES qtb_lote = new TCD_LoteRPS_X_NFES();
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
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteRPS_X_NFES val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS_X_NFES qtb_lote = new TCD_LoteRPS_X_NFES();
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
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void CorrigirNumeroNFSe(TRegistro_LoteRPS_X_NFES val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRPS_X_NFES qtb_lote = new TCD_LoteRPS_X_NFES();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                if (val.Nr_notafiscal.HasValue && val.Nr_nfse.HasValue)
                    if (val.Nr_notafiscal.Value != val.Nr_nfse.Value)
                    {
                        //Verificar se existe NF-e utilizando numero nota
                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lFat =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(val.Cd_empresa,
                                                                                          val.Nr_nfse.Value.ToString(),
                                                                                          val.Nr_serie,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
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
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          qtb_lote.Banco_Dados);
                        if (lFat.Count > 0)
                        {
                            if (lFat[0].St_registro.Trim().ToUpper().Equals("C"))
                                throw new Exception("Nº de NFS-e <" + val.Nr_nfse.Value.ToString() + "> já esta em uso no sistema.");
                            else if (new TCD_LoteRPS(qtb_lote.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.st_lote",
                                        vOperador = "=",
                                        vVL_Busca = "3"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_LoteRPS_X_NFES x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_lote = a.id_lote " +
                                                    "and x.cd_empresa = '" + lFat[0].Cd_empresa.Trim() + "' " +
                                                    "and x.nr_lanctofiscal = " + lFat[0].Nr_lanctofiscalstr + ")"
                                    }
                                }, "1") != null)
                                throw new Exception("Nº de NFS-e <" + val.Nr_nfse.Value.ToString() + "> já esta em uso no sistema.");
                            else CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lFat[0], qtb_lote.Banco_Dados);
                        }
                        //Buscar Nota Fiscal para alterar numero
                        lFat =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(val.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          val.Nr_lanctofiscal.Value.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          "A",
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
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          qtb_lote.Banco_Dados);
                        if (lFat.Count > 0)
                        {
                            lFat[0].Nr_notafiscal = val.Nr_nfse;
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.AlterarFaturamento(lFat[0], qtb_lote.Banco_Dados);
                            //Buscar sequencia NFSe
                            CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                new CamadaDados.Faturamento.Cadastros.TCD_CadSequenciaNF(qtb_lote.Banco_Dados).Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lFat[0].Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.nr_serie",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lFat[0].Nr_serie.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_modelo",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lFat[0].Cd_modelo.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
                            if (lSeq.Count > 0)
                                if (lSeq[0].Seq_NotaFiscal < val.Nr_nfse.Value)
                                {
                                    lSeq[0].Seq_NotaFiscal = val.Nr_nfse.Value;
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], qtb_lote.Banco_Dados);
                                }
                            //Se possuir duplicata alterar Nº Docto
                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_lote.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.Nr_LanctoDuplicata = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                            "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal + ") "
                                            }
                                    }, 1, string.Empty);
                            if (lDup.Count > 0)
                                qtb_lote.executarSql("update TB_FIN_Duplicata set Nr_docto = '" + val.Nr_nfse.Value.ToString() + "' " +
                                                     "where cd_empresa = '" + lDup[0].Cd_empresa.Trim() + "' " + 
                                                     "and nr_lancto = " + lDup[0].Nr_lancto.ToString(), null);
                        }
                    }
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro corrigir numero NFS-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Mensagem Lote RPS
    public class TCN_MsgRetornoRPS
    {
        public static TList_MsgRetornoRPS Buscar(string Id_lote,
                                                 string Cd_empresa,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
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
            return new TCD_MsgRetornoRPS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MsgRetornoRPS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MsgRetornoRPS qtb_msg = new TCD_MsgRetornoRPS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_msg.CriarBanco_Dados(true);
                else
                    qtb_msg.Banco_Dados = banco;
                val.Id_mensagem = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_msg.Gravar(val), "@P_ID_MENSAGEM"));
                if (st_transacao)
                    qtb_msg.Banco_Dados.Commit_Tran();
                return val.Id_mensagem.HasValue ? val.Id_mensagem.Value.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_msg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_msg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MsgRetornoRPS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MsgRetornoRPS qtb_msg = new TCD_MsgRetornoRPS();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_msg.CriarBanco_Dados(true);
                else
                    qtb_msg.Banco_Dados = banco;
                qtb_msg.Excluir(val);
                if (st_transacao)
                    qtb_msg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_msg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_msg.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
