using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario_Grupo
    {
        public static TList_CadUsuario_Grupo Busca(string LoginGrp, 
                                                   string LoginUsr,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(LoginGrp))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "logingrp";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + LoginGrp.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(LoginUsr))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "loginusr";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + LoginUsr.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_CadUsuario_Grupo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadUsuario_Grupo val,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_Grupo qtb_grupo = new TCD_CadUsuario_Grupo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_grupo.CriarBanco_Dados(true);
                else
                    qtb_grupo.Banco_Dados = banco;
                string retorno = qtb_grupo.GravaUserGrupo(val);
                if (st_transacao)
                    qtb_grupo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_grupo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar grupo usuario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_grupo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadUsuario_Grupo val,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_Grupo qtb_grupo = new TCD_CadUsuario_Grupo();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_grupo.CriarBanco_Dados(true);
                else
                    qtb_grupo.Banco_Dados = banco;
                qtb_grupo.DeletaUserGrupo(val);
                if (st_transacao)
                    qtb_grupo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_grupo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir grupo usuario: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_grupo.deletarBanco_Dados();
            }
        }
    }
}
