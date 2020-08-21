using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadRegiaoVenda
    {
        public static TList_CadRegiaoVenda Busca(decimal vID_Regiao,
                                                 string vNM_Regiao)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Regiao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Regiao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Regiao.ToString();
            }

            if (vNM_Regiao.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Regiao";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNM_Regiao + "%')";
            }
            TCD_CadRegiaoVenda id = new TCD_CadRegiaoVenda();
            return id.Select(vBusca, 0, "");
        }

        public static string GravaRegiaoVenda(TRegistro_CadRegiaoVenda val)
        {
            TCD_CadRegiaoVenda id = new TCD_CadRegiaoVenda();
            return id.Grava(val);
        }

        public static void DeletaRegiaoVenda(TRegistro_CadRegiaoVenda val)
        {
            TCD_CadRegiaoVenda id = new TCD_CadRegiaoVenda();
            id.Deleta(val);
        }
    }
}
