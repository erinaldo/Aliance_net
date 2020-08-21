using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Cadastros;
using Utils;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Plantio
    {
        public static TList_Plantio Buscar(string Id_plantio,
                                           string Cd_produto,
                                           string Id_Cultura,
                                           string Anosafra,
                                           string Cd_fazenda,
                                           string Id_area,
                                           string Id_talhao,
                                           string Tp_data,
                                           string Dt_ini,
                                           string Dt_fin,
                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_plantio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_plantio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_plantio;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_cultura x " +
                                                      "where x.id_cultura = a.id_cultura " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_Cultura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cultura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_Cultura;
            }
            if (!string.IsNullOrEmpty(Anosafra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.anosafra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Anosafra.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_plantio_x_talhoes x " +
                                                      "where x.id_plantio = a.id_plantio " +
                                                      "and x.cd_fazenda = '" + Cd_fazenda.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_plantio_x_talhoes x " +
                                                      "where x.id_plantio = a.id_plantio " +
                                                      "and x.id_area = " + Id_area + ")";
            }
            if (!string.IsNullOrEmpty(Id_talhao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_faz_plantio_x_talhoes x " +
                                                      "where x.id_plantio = a.id_plantio " +
                                                      "and x.id_talhao = " + Id_talhao + ")";
            }
            if (!string.IsNullOrEmpty(Dt_ini.Replace("/", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_iniplantio" : "a.dt_finplantio") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.Replace("/", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_iniplantio" : "a.dt_finplantio") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_Plantio(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Plantio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Plantio qtb_plantio = new TCD_Plantio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plantio.CriarBanco_Dados(true);
                else
                    qtb_plantio.Banco_Dados = banco;
                val.Id_plantiostr = CamadaDados.TDataQuery.getPubVariavel(qtb_plantio.Gravar(val), "@P_ID_PLANTIO");
                //Excluir talhoes
                val.lTalhoesPlantioDel.ForEach(p => TCN_Plantio_X_Talhoes.Excluir(p, qtb_plantio.Banco_Dados));
                //Gravar talhoes
                val.lTalhoesPlantio.ForEach(p =>
                    {
                        p.Id_plantio = val.Id_plantio;
                        TCN_Plantio_X_Talhoes.Gravar(p, qtb_plantio.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_plantio.Banco_Dados.Commit_Tran();
                return val.Id_plantiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plantio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar plantio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plantio.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Plantio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Plantio qtb_plantio = new TCD_Plantio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plantio.CriarBanco_Dados(true);
                else
                    qtb_plantio.Banco_Dados = banco;
                val.lTalhoesPlantio.ForEach(p => TCN_Plantio_X_Talhoes.Excluir(p, qtb_plantio.Banco_Dados));
                val.lTalhoesPlantioDel.ForEach(p => TCN_Plantio_X_Talhoes.Excluir(p, qtb_plantio.Banco_Dados));
                qtb_plantio.Excluir(val);
                if (st_transacao)
                    qtb_plantio.Banco_Dados.Commit_Tran();
                return val.Id_plantiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plantio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir plantio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plantio.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Plantio_X_Talhoes
    {
        public static TList_Plantio_X_Talhoes Buscar(string Id_plantio,
                                                     string Cd_fazenda,
                                                     string Id_area,
                                                     string Id_talhao,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_plantio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_plantio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_plantio;
            }
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_area";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_area;
            }
            if (!string.IsNullOrEmpty(Id_talhao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_talhao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_talhao;
            }
            return new TCD_Plantio_X_Talhoes(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Plantio_X_Talhoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Plantio_X_Talhoes qtb_plantio = new TCD_Plantio_X_Talhoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plantio.CriarBanco_Dados(true);
                else
                    qtb_plantio.Banco_Dados = banco;
                string retorno = qtb_plantio.Gravar(val);
                if (st_transacao)
                    qtb_plantio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plantio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar talhões plantio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plantio.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Plantio_X_Talhoes val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Plantio_X_Talhoes qtb_plantio = new TCD_Plantio_X_Talhoes();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plantio.CriarBanco_Dados(true);
                else
                    qtb_plantio.Banco_Dados = banco;
                qtb_plantio.Excluir(val);
                if (st_transacao)
                    qtb_plantio.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plantio.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir talhões plantio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plantio.deletarBanco_Dados();
            }
        }
    }
}
