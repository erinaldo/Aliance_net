using System;
using CamadaDados.Almoxarifado;
using Utils;
using BancoDados;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_CadAlmox_X_Empresa
    {
        public static TList_CadAlmox_X_Empresa Busca(string vId_almox,
                                                    string vCd_empresa,
                                                    TObjetoBanco banco)
        {
            TpBusca[] vBusca = new Utils.TpBusca[0];

            if (!string.IsNullOrEmpty(vId_almox))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_almox";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_almox;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_CadAlmox_X_Empresa cd = new TCD_CadAlmox_X_Empresa();
            return new TCD_CadAlmox_X_Empresa(banco).Select(vBusca, 0, string.Empty);
        }


        public static string Gravar(TRegistro_CadAlmox_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAlmox_X_Empresa qtb_almox_empresa = new TCD_CadAlmox_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_almox_empresa.CriarBanco_Dados(true);
                else
                    qtb_almox_empresa.Banco_Dados = banco;
                string retorno = qtb_almox_empresa.Gravar(val);
                if (st_transacao)
                    qtb_almox_empresa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_almox_empresa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao gravar : " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_almox_empresa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadAlmox_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAlmox_X_Empresa qtb_almox_empresa = new TCD_CadAlmox_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_almox_empresa.CriarBanco_Dados(true);
                else
                    qtb_almox_empresa.Banco_Dados = banco;
                qtb_almox_empresa.Excluir(val);
                if (st_transacao)
                    qtb_almox_empresa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_almox_empresa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao excluir: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_almox_empresa.deletarBanco_Dados();
            }
        }
    }
}
