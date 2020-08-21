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
    public class TCN_Cad_Campo_Amarracao
    {
        public static TList_Cad_Campo_Amarracao Busca(decimal vID_Campo_Amarracao, string vID_Consulta, decimal vID_Tipo_Amarracao, decimal vID_Amarracoes)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Campo_Amarracao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_campo_amarracao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Campo_Amarracao.ToString() + "'";
            }
            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.id_consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
            }
            if (vID_Tipo_Amarracao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.id_tipo_amarracao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Tipo_Amarracao.ToString() + "'";
            }
            if (vID_Amarracoes > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_amarracoes";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Amarracoes.ToString() + "'";
            }
            

            TCD_Cad_Campo_Amarracao cd = new TCD_Cad_Campo_Amarracao();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaCampoAmarracao(TRegistro_Cad_Campo_Amarracao val)
        {
            TCD_Cad_Campo_Amarracao cd = new TCD_Cad_Campo_Amarracao();
            return cd.Grava(val);

        }

        public static string DeletaCampoAmarracao(TRegistro_Cad_Campo_Amarracao val)
        {
            TCD_Cad_Campo_Amarracao CD = new TCD_Cad_Campo_Amarracao();
            return CD.Deleta(val);
        }
    }
}
