using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Bloqueto
{
    #region Lote Remessa
    public class TCN_LoteRemessa
    {
        public static TList_LoteRemessa Buscar(string Id_lote,
                                               string Id_config,
                                               string Nosso_numero,
                                               string St_registro,
                                               string Dt_ini,
                                               string Dt_fin,
                                               bool St_rejeitados,
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
            if (!string.IsNullOrEmpty(Id_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_config";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_config;
            }
            if (!string.IsNullOrEmpty(Nosso_numero))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cob_loteremessa_x_titulo x " +
                                                      "inner join tb_cob_titulo y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lancto = y.nr_lancto " +
                                                      "and x.cd_parcela = y.cd_parcela " +
                                                      "and x.id_cobranca = y.id_cobranca " +
                                                      "where x.id_lote = a.id_lote " +
                                                      "and y.nossonumero like '%" + Nosso_numero.Trim() + "%')";
            }
            if (St_rejeitados)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cob_loteremessa_x_titulo x " +
                                                      "where x.id_lote = a.id_lote " +
                                                      "and x.st_loteremessa = 'R')";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            return new TCD_LoteRemessa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteRemessa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa qtb_lote = new TCD_LoteRemessa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_lote.Gravar(val), "@P_ID_LOTE"));
                //Excluir titulos do lote
                val.lTitulosDel.ForEach(p => TCN_LoteRemessa_X_Titulo.Excluir(
                    new TRegistro_LoteRemessa_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = val.Id_lote,
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados));
                //Incluir titulo lote
                val.lTitulos.ForEach(p => TCN_LoteRemessa_X_Titulo.Gravar(
                    new TRegistro_LoteRemessa_X_Titulo()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_parcela = p.Cd_parcela,
                        Id_cobranca = p.Id_cobranca,
                        Id_lote = val.Id_lote,
                        Nr_lancto = p.Nr_lancto
                    }, qtb_lote.Banco_Dados));
                    
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote remessa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteRemessa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa qtb_lote = new TCD_LoteRemessa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote remessa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ProcessarRemessa(TRegistro_LoteRemessa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa qtb_lote = new TCD_LoteRemessa();
            try
            {
                if(banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                if(val.lTitulos.Count < 1)
                    throw new Exception("Lote não possui titulos para gerar arquivo remessa.");
                TList_CadCFGBanco lCfgBanco = TCN_CadCFGBanco.Buscar(string.Empty,
                                                                     val.lTitulos[0].Cd_banco, 
                                                                     val.Cd_empresa, 
                                                                     val.lTitulos[0].Cedente.CodigoCedente, 
                                                                     "CR",
                                                                     val.Cd_contager, 
                                                                     "A",
                                                                     string.Empty,
                                                                     1, 
                                                                     qtb_lote.Banco_Dados);
                if(lCfgBanco.Count < 1)
                    throw new Exception("Não existe configuração para emissão de bloquetos para o banco: " + val.lTitulos[0].Cd_banco);
                //Criar registro cobranca
                blCobranca rCobranca = new blCobranca();
                if(val.Nr_arqRemessa > decimal.Zero)
                    rCobranca.SequencialArq = val.Nr_arqRemessa;
                else
                {
                    //Sequencial do Arquivo
                    object obj = new TCD_LoteRemessa(qtb_lote.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_config",
                                            vOperador = "=",
                                            vVL_Busca = lCfgBanco[0].Id_configstr
                                        }
                                    }, "isnull(max(a.nr_arqremessa), 0)");
                    rCobranca.SequencialArq = obj == null ? 1 : decimal.Parse(obj.ToString()) + 1;
                    val.Nr_arqRemessa = rCobranca.SequencialArq;
                }
                rCobranca.Cd_instrucao = blCobranca.TratarInstrucaoRemessa(val.lTitulos[0].Cd_banco, val.Tp_instrucao);
                rCobranca.DataArquivo = CamadaDados.UtilData.Data_Servidor(qtb_lote.Banco_Dados);
                rCobranca.LayoutArquivo = lCfgBanco[0].Tp_layoutremessa.Trim().Equals("2") ? TLayoutArquivo.laCNAB240 : lCfgBanco[0].Tp_layoutremessa.Trim().Equals("4") ? TLayoutArquivo.laCNAB400 : TLayoutArquivo.laOutro;
                rCobranca.TipoMovimento = TTipoMovimento.tmRemessa;
                rCobranca.Cd_bancocorrespondente = lCfgBanco[0].Cd_bancocorrespondente;
                rCobranca.Titulos = val.lTitulos;
                if (rCobranca.GerarRemessa(val.lTitulos[0].Cd_banco, val.Path_remessa))
                {
                    val.St_registro = "P";//Processado
                    val.Dt_lote = rCobranca.DataArquivo;
                    Gravar(val, qtb_lote.Banco_Dados);
                }
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar arquivo remessa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void AlterarSeqRemessa(TRegistro_LoteRemessa val, decimal Nr_seq, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa qtb_lote = new TCD_LoteRemessa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                val.Nr_arqRemessa = Nr_seq;
                qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar sequencial remessa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Lote Remessa X Titulo
    public class TCN_LoteRemessa_X_Titulo
    {
        public static TList_LoteRemessa_X_Titulo Buscar(string Id_lote,
                                                        string Cd_empresa,
                                                        string Nr_lancto,
                                                        string Cd_parcela,
                                                        string Id_cobranca,
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
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            if (!string.IsNullOrEmpty(Id_cobranca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cobranca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cobranca;
            }
            return new TCD_LoteRemessa_X_Titulo(banco).Select(filtro, 0, string.Empty);
        }

        public static blListaTitulo BuscarTitulos(string Id_lote,
                                                  BancoDados.TObjetoBanco banco)
        {
            return new TCD_Titulo(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_cob_loteremessa_x_titulo x "+
                                    "where x.cd_empresa = a.cd_empresa "+
                                    "and x.nr_lancto = a.nr_lancto "+
                                    "and x.cd_parcela = a.cd_parcela "+
                                    "and x.id_cobranca = a.id_cobranca "+
                                    "and x.id_lote = " + Id_lote + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteRemessa_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa_X_Titulo qtb_lote = new TCD_LoteRemessa_X_Titulo();
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
                throw new Exception("Erro gravar titulo remessa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteRemessa_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteRemessa_X_Titulo qtb_lote = new TCD_LoteRemessa_X_Titulo();
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
                throw new Exception("Erro excluir titulo lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
