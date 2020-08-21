using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota.Cadastros;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_CfgMDFe
    {
        public static TList_CfgMDFe Buscar(string Cd_empresa,
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
            return new TCD_CfgMDFe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgMDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgMDFe qtb_cfg = new TCD_CfgMDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                string ret = qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgMDFe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgMDFe qtb_cfg = new TCD_CfgMDFe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
