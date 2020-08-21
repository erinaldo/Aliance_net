using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fazenda
{
    public class TInfo
    {
        public static string pub;

        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("060000:NULL:NULL:NULL:Fazenda|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("060100:060000:FAZL01:Fazenda.TFLanPlantio:Lançamento de Plantio|");
            
            //MENU CADASTROS
            str.Append("065000:060000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("065100:065000:FAZC01:Fazenda.Cadastros.TFCadFazenda:Fazenda|");
            str.Append("065200:065000:FAZC02:Fazenda.Cadastros.FCadAreaFazenda:Area Fazenda|");
            str.Append("065300:065000:FAZC03:Fazenda.Cadastros.TFCadTalhao:Talhões Fazenda|");
            str.Append("065400:065000:FAZC04:Fazenda.Cadastros.TFCadCultura:Cultura|");
            str.Append("065500:065000:FAZC05:Fazenda.Cadastros.TFCad_Equipamento:Maquinas/Implementos|");
            str.Append("065600:065000:FAZC06:Fazenda.Cadastros.TFCad_Atividade:Atividades Fazenda|");

            return str.ToString();
        }

        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}
