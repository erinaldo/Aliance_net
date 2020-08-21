using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFaturamento_Impostos
    {
        public static TList_RegLanFaturamento_Impostos Busca(string vCD_Empresa,
                                                      string vNR_LanctoFiscal,
                                                      string vID_NFItem,
                                                      string vCD_Imposto,
                                                      int vTop,
                                                      string vNM_Campo,
                                                      TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_LanctoFiscal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_NFItem.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_NFItem";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_NFItem;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Imposto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Imposto";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Imposto;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_LanFaturamento_Impostos qtb_lanimposto = new TCD_LanFaturamento_Impostos();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_lanimposto.CriarBanco_Dados(false);
                    pode_liberar = true;
                }
                else
                    qtb_lanimposto.Banco_Dados = banco;
                return qtb_lanimposto.Select(vBusca, 0, "");
            }
            finally
            {
                if (pode_liberar)
                    qtb_lanimposto.deletarBanco_Dados();
            }
        }

        public static string GravarFatImpostos(TList_RegLanFaturamento_Impostos val, TObjetoBanco banco)
        {
            string retorno = "";
            if (val != null)
            {
                for (int i = 0; i < val.Count; i++)
                    retorno += GravarFatImpostos(val[i], banco);
            }
            return retorno;
        }

        public static string GravarFatImpostos(TRegistro_LanFaturamento_Impostos val, TObjetoBanco banco)
        {
            TCD_LanFaturamento_Impostos qtb_fatimposto = new TCD_LanFaturamento_Impostos();
            qtb_fatimposto.Banco_Dados = banco;
            return qtb_fatimposto.GravarFatImpostos(val); 
        }

        public static string DeletarFatImpostos(TRegistro_LanFaturamento_Impostos val, TObjetoBanco banco)
        {
            TCD_LanFaturamento_Impostos qtb_fatimposto = new TCD_LanFaturamento_Impostos();
            qtb_fatimposto.Banco_Dados = banco;
            return qtb_fatimposto.DeletaFatImpostos(val);
        }
    }
}
