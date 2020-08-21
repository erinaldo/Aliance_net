using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Graos
{
    public class TCN_FatQuebraTec
    {
        public static CamadaDados.Graos.TList_FatQuebraTec Buscar(string Id_lantaxa,
                                                                  string Cd_empresa,
                                                                  string Nr_lanctofiscal,
                                                                  string Id_nfitem,
                                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lantaxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lantaxa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lantaxa;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            return new CamadaDados.Graos.TCD_FatQuebraTec(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Graos.TRegistro_FatQuebraTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Graos.TCD_FatQuebraTec qtb_fat = new CamadaDados.Graos.TCD_FatQuebraTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                string retorno = qtb_fat.Gravar(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Graos.TRegistro_FatQuebraTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Graos.TCD_FatQuebraTec qtb_fat = new CamadaDados.Graos.TCD_FatQuebraTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                qtb_fat.Excluir(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }
    }
}
