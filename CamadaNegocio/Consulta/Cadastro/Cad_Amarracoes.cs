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
    public class TCN_Cad_Amarracoes
    {
        public static TList_Cad_Amarracoes Busca(decimal vID_Amarracao, string vID_Consulta)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Amarracao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_amarracoes";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Amarracao.ToString() + "'";
            }
            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
            }
            
            TCD_Cad_Amarracoes cd = new TCD_Cad_Amarracoes();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaAmarracoes(TRegistro_Cad_Amarracoes val)
        {
            TCD_Cad_Amarracoes cd = new TCD_Cad_Amarracoes();
            return cd.Grava(val);

        }

        public static string DeletaAmarracoes(TRegistro_Cad_Amarracoes val)
        {
            TCD_Cad_Amarracoes CD = new TCD_Cad_Amarracoes();
            return CD.Deleta(val);
        }

        public static string AlterarTodosStatus(TRegistro_Cad_Amarracoes val)
        {
            TCD_Cad_Amarracoes CD = new TCD_Cad_Amarracoes();
            return CD.AlteraTodosStatus(val);
        }
    }
}
