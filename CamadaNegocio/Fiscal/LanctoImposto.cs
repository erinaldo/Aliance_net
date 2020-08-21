using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_LanctoImposto
    {
        public static TList_LanctoImposto Buscar(string id_lancto,
                                                 string cd_imposto,
                                                 string cd_empresa,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 string Id_lotefis,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_lancto;
            }
            if (!string.IsNullOrEmpty(cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_imposto;
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_empresa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(Id_lotefis))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotefis";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lotefis;
            }

            return new TCD_LanctoImposto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanctoImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctoImposto qtb_lancto = new TCD_LanctoImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lancto.CriarBanco_Dados(true);
                else
                    qtb_lancto.Banco_Dados = banco;
                //Verificar se nao existe lote fiscal para a data, o imposto e a empresa
                if (TCN_LoteImposto.VerificarLoteImposto(val.Cd_empresa, val.Cd_impostostr, val.Dt_lanctostr, qtb_lancto.Banco_Dados))
                    throw new Exception("Imposto ja se encontra processado para a data: " + val.Dt_lanctostr.Trim());
                string retorno = qtb_lancto.Gravar(val);
                if (st_transacao)
                    qtb_lancto.Banco_Dados.Commit_Tran();

                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lancto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar imposto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lancto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanctoImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctoImposto qtb_lancto = new TCD_LanctoImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lancto.CriarBanco_Dados(true);
                else
                    qtb_lancto.Banco_Dados = banco;
                //Verificar se nao existe lote fiscal para a data, o imposto e a empresa
                if (TCN_LoteImposto.VerificarLoteImposto(val.Cd_empresa, val.Cd_impostostr, val.Dt_lanctostr, qtb_lancto.Banco_Dados))
                    throw new Exception("Imposto ja se encontra processado para a data: " + val.Dt_lanctostr.Trim());
                qtb_lancto.Excluir(val);
                if (st_transacao)
                    qtb_lancto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lancto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir imposto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lancto.deletarBanco_Dados();
            }
        }

        public static void Processar(TRegistro_LanctoImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctoImposto qtb_lancto = new TCD_LanctoImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lancto.CriarBanco_Dados(true);
                else
                    qtb_lancto.Banco_Dados = banco;
                qtb_lancto.Gravar(val);
                if (st_transacao)
                    qtb_lancto.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lancto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar fiscal avulso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lancto.deletarBanco_Dados();
            }
        }
    }
}
