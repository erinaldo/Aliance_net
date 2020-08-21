using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using CamadaDados.ConfigGer;

namespace CamadaNegocio.ConfigGer
{
    public class TCN_CadParamGer_X_Empresa
    {
        public static TList_RegParamGer_X_Empresa Busca(string vID_Parametro,
                                              string vCD_Empresa,
                                              int vTop,
                                              string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if ((vID_Parametro.Trim() != "")&&(vID_Parametro.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Parametro";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Parametro;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_ParamGer_X_Empresa qtb_param = new TCD_ParamGer_X_Empresa();
            return qtb_param.Select(vBusca, vTop, vNM_Campo);
        }

        public static TList_RegParamGer BuscarParamGer(string vCd_empresa,
                                                       string vDs_parametro,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "";
                filtro[0].vVL_Busca = "(select 1 from tb_cfg_paramger_x_empresa x " +
                                      "where x.id_parametro = A.id_parametro " +
                                      "and x.cd_empresa = '" + vCd_empresa + "')";
                filtro[0].vOperador = "EXISTS";
                if (!string.IsNullOrEmpty(vDs_parametro))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "DS_Parametro";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vDs_parametro.Trim().Replace("'", "''") + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                return new TCD_ParamGer(banco).Select(filtro, vTop, vNm_campo);
            }
            else
                return new TList_RegParamGer();
        }

        public static CamadaDados.Financeiro.Cadastros.TList_Moeda BuscarMoedaPadrao(string vCd_empresa, BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                TList_RegParamGer lParametros = BuscarParamGer(vCd_empresa, "CD_MOEDA_PADRAO", 1, string.Empty, banco);
                if (lParametros.Count > 0)
                {
                    return Financeiro.Cadastros.TCN_CadMoeda.Buscar(lParametros[0].Vl_string.Trim(),
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    1,
                                                                    string.Empty,
                                                                    banco);
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static string GravaParamGer_X_Empresa(TRegistro_ParamGer_X_Empresa val)
        {
            TCD_ParamGer_X_Empresa qtb_param = new TCD_ParamGer_X_Empresa();
            return qtb_param.GravarParamGer(val);
        }

        public static string DeletaParamGer(TRegistro_ParamGer_X_Empresa val)
        {
            TCD_ParamGer_X_Empresa qtb_param = new TCD_ParamGer_X_Empresa();
            return qtb_param.DeletarParamGer(val);
        }
    }
}
