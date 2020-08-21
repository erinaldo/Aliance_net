using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using Utils;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_CFG
    {

        public static TList_CFG Buscar(string Cd_empresa,
                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_CFG(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cfg val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFG qtb_orc = new TCD_CFG();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.cd_empresa.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre cfg: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Cfg val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFG qtb_orc = new TCD_CFG();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre cfg: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
