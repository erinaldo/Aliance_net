using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca;

namespace CamadaNegocio.Mudanca
{
    public class TCN_LanServicosMud
    {
        public static TList_LanServicosMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Id_servico,
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
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Id_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_servico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_servico;
            }
            return new TCD_LanServicosMud(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanServicosMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicosMud qtb_servico = new TCD_LanServicosMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                string retorno = qtb_servico.Gravar(val);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar serviços: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanServicosMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicosMud qtb_servico = new TCD_LanServicosMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                qtb_servico.Excluir(val);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return val.Id_servicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir serviços: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }
    }
}
