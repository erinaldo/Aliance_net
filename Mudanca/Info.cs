using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mudanca
{
    public class TInfo
    {
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }

        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("210000:NULL:NULL:NULL:Mudanca|");

            //OPÇÕES DO MENU DE LANÇAMENTO
            str.Append("210100:210000:MUDL01:Mudanca.TFLanMudanca:Lançamentos de Mudanças|");
            str.Append("210200:210000:MUDL02:Mudanca.TFLanGuardaVolume:Lançamento de Guarda Volume|");
            str.Append("210300:210000:MUDL03:Mudanca.TFPainelMudanca:Painel Mudança|");

            //MENU CADASTRO
            str.Append("215000:210000:NULL:NULL:Cadastros|");

            //FILHO DO MENU CADASTRO
            str.Append("215100:215000:MUDC01:Mudanca.Cadastros.TFCadServicos:Cadastro - Serviços|");
            str.Append("215200:215000:MUDC02:Mudanca.Cadastros.TFCadItens:Cadastro - Itens|");
            str.Append("215300:215000:MUDC03:Mudanca.Cadastros.TFCFGMudanca:Configuração de Mudança|");



            return str.ToString();
        }
    }
}
