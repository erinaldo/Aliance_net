using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using CamadaDados.Fazenda.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_CadAtividadeCCusto
    {
        public static TList_CadAtividadeCCusto busca(string ID_Atividade, string CD_CCusto)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (ID_Atividade.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Atividade";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ID_Atividade + "'";
                vBusca[vBusca.Length - 1].vOperador = " = ";
            }
            if (CD_CCusto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CCusto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_CCusto + "'";
                vBusca[vBusca.Length - 1].vOperador = " = ";
            }

            return new TCD_CadAtividadeCCusto().Select(vBusca, 0, "");

        }
        public static string gravarAtividade(TRegistro_CadAtividadeCCusto val)
        {
            TCD_CadAtividadeCCusto atde = new TCD_CadAtividadeCCusto();
            return atde.gravarAtividade(val);
        }
        public static string deletarAtividade(TRegistro_CadAtividadeCCusto val)
        {
            TCD_CadAtividadeCCusto atde = new TCD_CadAtividadeCCusto();
            return atde.deletarAtividade(val);
        }
    }
}
