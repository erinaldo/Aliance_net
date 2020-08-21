using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    #region Intervencao Tecnica
    public class TCN_IntervencaoTecnica
    {
        public static TList_IntervencaoTecnica Buscar(string Id_intervencao,
                                                      string Id_bomba,
                                                      string Cd_empresa,
                                                      string Cd_cliforintervencao,
                                                      string Nr_intervencao,
                                                      string Ds_motivo,
                                                      string Nm_tecnico,
                                                      string Dt_ini,
                                                      string Dt_fin,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_intervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_intervencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_intervencao;
            }
            if (!string.IsNullOrEmpty(Id_bomba))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bomba";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bomba;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cliforintervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cliforintervencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cliforintervencao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_intervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_intervencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_intervencao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_motivo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_motivo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_motivo.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Nm_tecnico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_tecnico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_tecnico.Trim() + "%')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_intervencao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_intervencao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            return new TCD_IntervencaoTecnica(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_IntervencaoTecnica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_IntervencaoTecnica qtb_inter = new TCD_IntervencaoTecnica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inter.CriarBanco_Dados(true);
                else
                    qtb_inter.Banco_Dados = banco;
                val.Id_intervencaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_inter.Gravar(val), "@P_ID_INTERVENCAO");
                //Gravar encerrante bico
                val.lBico.ForEach(p => TCN_Intervencao_X_Encerrante.Gravar(
                    new TRegistro_Intervencao_X_Encerrante()
                    {
                        Id_encerrantestr = TCN_EncerranteBico.Gravar(new TRegistro_EncerranteBico()
                        {
                            Id_bico = p.Id_bico,
                            Dt_encerrante = val.Dt_intervencao,
                            Tp_encerrante = "I",
                            Qtd_encerrante = p.Qtd_encerrante
                        }, qtb_inter.Banco_Dados),
                        Id_intervencao = val.Id_intervencao
                    }, qtb_inter.Banco_Dados));
                if (st_transacao)
                    qtb_inter.Banco_Dados.Commit_Tran();
                return val.Id_intervencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inter.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar intervenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inter.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_IntervencaoTecnica val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_IntervencaoTecnica qtb_inter = new TCD_IntervencaoTecnica();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inter.CriarBanco_Dados(true);
                else
                    qtb_inter.Banco_Dados = banco;
                //Excluir intervencao
                qtb_inter.Excluir(val);
                if (st_transacao)
                    qtb_inter.Banco_Dados.Commit_Tran();
                return val.Id_intervencaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inter.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir intervenção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inter.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Intervencao X Encerrante
    public class TCN_Intervencao_X_Encerrante
    {
        public static TList_Intervencao_X_Encerrante Buscar(string Id_intervencao,
                                                            string Id_encerrante,
                                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_intervencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_intervencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_intervencao;
            }
            if (!string.IsNullOrEmpty(Id_encerrante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_encerrante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_encerrante;
            }
            
            return new TCD_Intervencao_X_Encerrante(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Intervencao_X_Encerrante val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Intervencao_X_Encerrante qtb_int = new TCD_Intervencao_X_Encerrante();
            try
            {
                if (banco == null)
                    st_transacao = qtb_int.CriarBanco_Dados(true);
                else
                    qtb_int.Banco_Dados = banco;
                string retorno = qtb_int.Gravar(val);
                if (st_transacao)
                    qtb_int.Banco_Dados.Commit_Tran();
                return retorno;

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_int.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_int.deletarBanco_Dados();
            }
        }

        public static string Exclui(TRegistro_Intervencao_X_Encerrante val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Intervencao_X_Encerrante qtb_int = new TCD_Intervencao_X_Encerrante();
            try
            {
                if (banco == null)
                    st_transacao = qtb_int.CriarBanco_Dados(true);
                else
                    qtb_int.Banco_Dados = banco;
                qtb_int.Excluir(val);
                if (st_transacao)
                    qtb_int.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_int.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_int.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
