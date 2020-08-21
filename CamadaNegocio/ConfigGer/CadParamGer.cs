using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.ConfigGer;

namespace CamadaNegocio.ConfigGer
{
    public class TCN_CadParamGer
    {
        private static bool ParamExisteBanco(TList_RegParamGer list, string param)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].Ds_parametro.ToUpper().Trim().Equals(param.ToUpper().Trim()))
                    return true;
            return false;
        }

        public static ArrayList BuscaParametros(bool filtrar)
        {
            TList_RegParamGer lista = Busca(0, 
                                            string.Empty, 
                                            string.Empty, 
                                            string.Empty, 
                                            0, 
                                            string.Empty,
                                            null);
            string[] param = ParamGer.paramGer.Split(new char[] { '|' });
            if(param.Length > 0)
            {
                ArrayList cBox = new ArrayList();
                for (int i = 0; i < param.Length; i++)
                {
                    if (filtrar)
                    {
                        if (!(ParamExisteBanco(lista, param[i])))
                            cBox.Add(new TDataCombo(param[i], param[i]));
                    }
                    else
                        cBox.Add(new TDataCombo(param[i], param[i]));
                }
                return cBox;
            }
            return null;
        }

        public static TList_RegParamGer Busca(int vID_Parametro,
                                              string vDS_Parametro,
                                              string vDS_Finalidade,
                                              string vTP_Dado,
                                              int vTop,
                                              string vNM_Campo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Parametro > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ID_Parametro";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Parametro.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vDS_Parametro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Parametro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Parametro+ "'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (vDS_Finalidade.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Finalidade";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Finalidade + "'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (vTP_Dado.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "TP_Dado";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Dado + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_ParamGer(banco).Select(vBusca, vTop, vNM_Campo);
        }

        public static TList_RegParamGer BuscarParametros(string Ds_parametro, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "ds_parametro";
            filtro[0].vOperador = "in";
            filtro[0].vVL_Busca = "(" + Ds_parametro.Trim() + ")";
            TList_RegParamGer retorno = new TCD_ParamGer(banco).Select(filtro, 0, string.Empty);
            if (retorno.Count < 1)
                retorno.Add(new TRegistro_ParamGer());
            return retorno;
        }

        public static string BuscaVlString(string vDS_Parametro,
                                           BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(vDS_Parametro))
            {
                object obj = new TCD_ParamGer(banco).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "DS_Parametro",
                            vOperador = "=",
                            vVL_Busca = "'" + vDS_Parametro.Trim() + "'"
                        }
                    }, "Vl_String");
                return obj == null ? string.Empty : obj.ToString();
            }
            else
                return string.Empty;
        }

        public static string BuscaVlString(string vDS_Parametro, string vCD_Terminal, BancoDados.TObjetoBanco banco)
        {
            if (vDS_Parametro.Trim() != "")
            {
                TpBusca[] vBusca = new TpBusca[2];
                vBusca[0].vNM_Campo = "DS_Parametro";
                vBusca[0].vOperador = "=";
                vBusca[0].vVL_Busca = "'" + vDS_Parametro + "'";

                vBusca[1].vNM_Campo = "";
                vBusca[1].vOperador = "";
                vBusca[1].vVL_Busca = "exists(select 1 from TB_CFG_ParamGer_X_Terminal b where b.id_parametro = a.id_parametro and b.cd_terminal = '" + vCD_Terminal + "')";

                object obj = new TCD_ParamGer(banco).BuscarEscalar(vBusca, "Vl_String");
                return obj != null ? obj.ToString() : string.Empty;
            }
            else
                return string.Empty;
        }

        public static byte[] BuscaVlImagem(string vDS_Parametro, string vCD_Empresa, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vDS_Parametro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Parametro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Parametro.Trim() + "'";

            }

            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "exists(select 1 from TB_CFG_ParamGer_X_Empresa b " +
                                                      "where b.id_parametro = a.id_parametro " +
                                                      "and b.cd_empresa = '" + vCD_Empresa.Trim() + "')";

            }

            TList_RegParamGer Lista_Imagem = new TCD_ParamGer(banco).Select(vBusca, 0, string.Empty);
            if (Lista_Imagem.Count > 0)
                return Lista_Imagem[0].Img;
            else
                return null;
        }

        public static string BuscaVL_String_Empresa(string vDS_Parametro, string vCD_Empresa, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vDS_Parametro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Parametro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Parametro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "exists(select 1 from TB_CFG_ParamGer_X_Empresa b " +
                                                      "where b.id_parametro = a.id_parametro " +
                                                      "and b.cd_empresa = '" + vCD_Empresa.Trim() + "')";
            }
            TList_RegParamGer Lista = new TCD_ParamGer(banco).Select(vBusca, 0, string.Empty);
            if (Lista.Count > 0)
                return Lista[0].Vl_string.Trim();
            else
                return string.Empty;
        }

        public static string BuscaVL_String_Empresa(string vDS_Parametro, string vCD_Empresa)
        {
            return BuscaVL_String_Empresa(vDS_Parametro, vCD_Empresa, null);
        }

        public static string BuscaVL_Bool(string vDS_Parametro, string vCD_Empresa, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vDS_Parametro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Parametro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Parametro + "'";

            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "exists(select 1 from TB_CFG_ParamGer_X_Empresa b where b.id_parametro = a.id_parametro and b.cd_empresa = '" + vCD_Empresa + "')";

            }

            TList_RegParamGer Lista = new TCD_ParamGer(banco).Select(vBusca, 0, string.Empty);
            if (Lista.Count > 0)
                return Lista[0].VL_Bool_String.Trim();
            else
                return "N";
        }

        public static bool BuscaVl_BoolTerminal(string Ds_parametro, string Cd_terminal, BancoDados.TObjetoBanco banco)
        {
            object obj = new TCD_ParamGer(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.DS_Parametro",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Ds_parametro.Trim().ToUpper() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cfg_paramger_x_terminal x "+
                                                "where x.id_parametro = a.id_parametro "+
                                                "and x.cd_terminal = '" + Cd_terminal.Trim() + "')"
                                }
                            }, "Vl_Bool");
            return obj == null ? false : obj.ToString().Trim().Equals("S");
        }   

        public static DateTime? BuscaVlData(string vDS_Parametro, BancoDados.TObjetoBanco banco)
        {
            if (vDS_Parametro.Trim() != "")
            {
                TpBusca[] vBusca = new TpBusca[1];
                vBusca[0].vNM_Campo = "DS_Parametro";
                vBusca[0].vVL_Busca = "'" + vDS_Parametro + "'";
                vBusca[0].vOperador = "=";
                object obj = new TCD_ParamGer(banco).BuscarEscalar(vBusca, "Vl_Data");
                if (obj != null)
                    try
                    {
                        return Convert.ToDateTime(obj.ToString());
                    }
                    catch
                    {
                        return null;
                    }
                else
                    return null;
            }
            else
                return null;
        }

        public static decimal BuscaVlNumerico(string vDS_Parametro, BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(vDS_Parametro))
            {
                object obj = new TCD_ParamGer(banco).BuscarEscalar(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "ds_parametro",
                            vOperador = "=",
                            vVL_Busca = "'" + vDS_Parametro.Trim() + "'"
                        }
                    }, "Vl_Numerico");
                return obj == null ? decimal.Zero : Convert.ToDecimal(obj.ToString());
            }
            else
                return decimal.Zero;
        }

        public static decimal BuscaVlNumerico(string vDS_Parametro, string vCD_Terminal, BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(vDS_Parametro))
            {
                object obj = new TCD_ParamGer(banco).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "ds_parametro",
                            vOperador = "=",
                            vVL_Busca = "'" + vDS_Parametro.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cfg_paramger_x_terminal x " +
                                        "where x.id_parametro = a.id_parametro " +
                                        "and x.cd_terminal = '" + vCD_Terminal.Trim() + "')"
                        }
                    }, "Vl_Numerico");
                return obj == null ? decimal.Zero : Convert.ToDecimal(obj.ToString());
            }
            else
                return decimal.Zero;
        }

        public static decimal VlNumericoEmpresa(string Ds_parametro,
                                                string Cd_empresa,
                                                BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(Ds_parametro))
            {
                object obj = new TCD_ParamGer(banco).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "ds_parametro",
                            vOperador = "=",
                            vVL_Busca = "'" + Ds_parametro.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cfg_paramger_x_empresa x " +
                                        "where x.id_parametro = a.id_parametro " +
                                        "and x.cd_empresa = '" + Cd_empresa.Trim() + "')"
                        }
                    }, "Vl_Numerico");
                return obj == null ? decimal.Zero : Convert.ToDecimal(obj.ToString());
            }
            else
                return decimal.Zero;
        }

        public static bool BuscaVlBool(string vDS_Parametro, BancoDados.TObjetoBanco banco)
        {
            if (vDS_Parametro.Trim() != "")
            {
                TpBusca[] vBusca = new TpBusca[1];
                vBusca[0].vNM_Campo = "DS_Parametro";
                vBusca[0].vVL_Busca = "'" + vDS_Parametro + "'";
                vBusca[0].vOperador = "=";
                object obj = new TCD_ParamGer(banco).BuscarEscalar(vBusca, "Vl_Bool");
                if (obj != null)
                    return obj.ToString().Trim().Equals("S");
                else
                    return false;
            }
            else
                return false; ;
        }
        
        public static string GravaParamGer(TRegistro_ParamGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParamGer qtb_param = new TCD_ParamGer();
            try
            {
                if (banco == null)
                    st_transacao = qtb_param.CriarBanco_Dados(true);
                else
                    qtb_param.Banco_Dados = banco;
                string retorno = qtb_param.GravarParamGer(val);
                if (st_transacao)
                    qtb_param.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_param.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_param.deletarBanco_Dados();
            }
        }

        public static string DeletaParamGer(TRegistro_ParamGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParamGer qtb_param = new TCD_ParamGer();
            try
            {
                if (banco == null)
                    st_transacao = qtb_param.CriarBanco_Dados(true);
                else
                    qtb_param.Banco_Dados = banco;
                qtb_param.DeletarParamGer(val);
                if (st_transacao)
                    qtb_param.Banco_Dados.Commit_Tran();
                return val.Id_parametro.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_param.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_param.deletarBanco_Dados();
            }
        }
    }
}
