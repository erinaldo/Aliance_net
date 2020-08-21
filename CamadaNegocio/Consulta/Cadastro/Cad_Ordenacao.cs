/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Ordenacao
    {
        public static TList_Cad_Ordenacao Busca(decimal vID_Ordenacao, string vID_Consulta, string vNM_Tabela)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Ordenacao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_Ordenacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Ordenacao.ToString() + "'";
            }
            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
            }
            if (vNM_Tabela.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Tabela";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_Tabela + "%'";
            }

            TCD_Cad_Ordenacao cd = new TCD_Cad_Ordenacao();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaOrdenacao(TRegistro_Cad_Ordenacao val)
        {
            TCD_Cad_Ordenacao cd = new TCD_Cad_Ordenacao();
            return cd.Grava(val);

        }

        public static string DeletaOrdenacao(TRegistro_Cad_Ordenacao val)
        {
            TCD_Cad_Ordenacao CD = new TCD_Cad_Ordenacao();
            return CD.Deleta(val);
        }
    }
}
