using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadLocalArm
    {
        public static TList_CadLocalArm Busca( string vCD_Local,
                                               string vDS_Local,
                                               string vTp_Local,
                                               string vST_Registro,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Local))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Local.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDS_Local))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Local";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Local.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(vTp_Local))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Local";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_Local.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
            }
            return new TCD_CadLocalArm(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadLocalArm val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLocalArm cd = new TCD_CadLocalArm();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Cd_local = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_CD_LOCAL");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Cd_local;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar local armazenagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadLocalArm val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLocalArm cd = new TCD_CadLocalArm();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Verificar se existe amarracao para o local
                if (new TCD_CadLocalArm_X_Empresa(cd.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_local",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_local.Trim() + "'"
                        }
                    }, "1") != null)
                {
                    val.St_registro = "C";
                    cd.Gravar(val);
                }
                else
                    cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Cd_local;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir local armazenagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
     }
}