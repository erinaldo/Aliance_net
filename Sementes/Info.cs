using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sementes
{
    public class TInfo
    {
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("160000:NULL:NULL:NULL:Sementes|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("160100:160000:SEMMOV:Sementes.TFLan_LoteSemente:Controle de Lotes de Sementes|");

            //OPCOES DE CADASTRO
            str.Append("161100:160000:NULL:NULL:Cadastro|");
            str.Append("161110:161100:SEMTPA:Sementes.Cadastros.TFCad_TipoAnalise:Tipo de Analise|");

            return str.ToString();
        }
        static public string pub;
        public void setPub(string vPub)
        {
            pub = vPub;
        }

    }
}
