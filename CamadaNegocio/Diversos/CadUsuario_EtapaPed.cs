using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario_EtapaPed
    {
        public static CamadaDados.Faturamento.Cadastros.TList_CadEtapa Busca(string Login,
                                                   string ID_Etapa,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "login";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(ID_Etapa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ID_Etapa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ID_Etapa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_CadUsuario_EtapaPed(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa val,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_EtapaPed qtb_grupo = new TCD_CadUsuario_EtapaPed();
            try
            {
                if (banco == null)
                    st_transacao = qtb_grupo.CriarBanco_Dados(true);
                else
                    qtb_grupo.Banco_Dados = banco;
                string retorno = qtb_grupo.GravaEtapaPed(val);
                if (st_transacao)
                    qtb_grupo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_grupo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Etapa usuario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_grupo.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa val,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_EtapaPed qtb_grupo = new TCD_CadUsuario_EtapaPed();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_grupo.CriarBanco_Dados(true);
                else
                    qtb_grupo.Banco_Dados = banco;
                qtb_grupo.DeletaEtapaPed(val);
                if (st_transacao)
                    qtb_grupo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_grupo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Etapa usuario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_grupo.deletarBanco_Dados();
            }
        }
    }
}
