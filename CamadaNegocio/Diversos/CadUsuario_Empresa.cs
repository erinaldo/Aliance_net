using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario_Empresa
    {
        public static TList_CadUsuario_Empresa Busca(string vCD_Empresa, 
                                                     string vLogin, 
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_EMPRESA";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vLogin))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.LOGIN";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vLogin.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
                        
            return new TCD_CadUsuario_Empresa(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadUsuario_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_Empresa qtb_emp = new TCD_CadUsuario_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                string retorno = qtb_emp.GravaUsuarioEmpresa(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadUsuario_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_Empresa qtb_emp = new TCD_CadUsuario_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                qtb_emp.DeletarUsuarioEmpresa(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
}
