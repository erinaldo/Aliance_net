using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadParamSys
    {
        public static TList_CadParamSys Busca(string nm_campo, 
                                              string st_auto, 
                                              decimal tamanho,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (nm_campo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "nm_campo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nm_campo.Replace("'", "''") + "'";
                vBusca[vBusca.Length - 1].vOperador = " like ";
            }
            if (st_auto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "st_auto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + st_auto +"'";
                vBusca[vBusca.Length - 1].vOperador = " = ";
            }
            if (tamanho >  0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "Tamanho";
                vBusca[vBusca.Length - 1].vVL_Busca = "'"+ tamanho + "'";
                vBusca[vBusca.Length - 1].vOperador = " = ";
            }
            return new TCD_CadParamSys(banco).Select(vBusca, 0, "");
        }

        public static bool St_AutoInc(string Nm_campo)
        {
            if (!string.IsNullOrEmpty(Nm_campo))
            {
                object obj = new TCD_CadParamSys().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nm_campo",
                            vOperador = "=",
                            vVL_Busca = "'" + Nm_campo.Trim() + "'"
                        }
                    }, "a.ST_Auto");
                return (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("1"));
            }
            else
                return false;
        }

        public static string GravaParam(TRegistro_CadParamSys val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadParamSys param = new TCD_CadParamSys();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = param.CriarBanco_Dados(true);
                else
                    param.Banco_Dados = banco;
                string retorno = param.gravarParam(val);
                if (st_transacao)
                    param.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    param.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Parametro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    param.deletarBanco_Dados();
            }
        }

        public static string DeletaParam(TRegistro_CadParamSys val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadParamSys param = new TCD_CadParamSys();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = param.CriarBanco_Dados(true);
                else
                    param.Banco_Dados = banco;
                param.deletarParam(val);
                if (st_transacao)
                    param.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    param.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Parametro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    param.deletarBanco_Dados();
            }
        }
    }
}
