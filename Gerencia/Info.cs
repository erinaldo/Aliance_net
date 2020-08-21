using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerencia
{
    public class TInfo
    {
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("170000:NULL:NULL:NULL:Gerencial|");
            //FINANCEIRO
            str.Append("170200:170000:NULL:NULL:Financeiro|");
            str.Append("170230:170200:GERMPF:Gerencia.Financeiro.TFConsultaMapaFinanceiro:Mapa Financeiro|");
            //POSTOS COMBUSTIVEL
            str.Append("170900:170000:NULL:NULL:Postos Combustivel|");
            str.Append("170901:170900:GERPD1:Gerencia.Posto_Combustivel.TFPainelOnLine:Painel OnLine|");
            str.Append("170902:170900:GERPD2:Gerencia.Posto_Combustivel.TFPainelGerencial:Painel Gerencial|");

            return str.ToString();
        }
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }

    }
}
