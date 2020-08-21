using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Help
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
            str.Append("200000:NULL:NULL:NULL:Help Desk|");
            //MENU CADASTROS
            str.Append("205000:200000:NULL:NULL:Cadastros|");

            //OPCOES DE MENU CADASTROS
            str.Append("205100:205000:HELP01:Help.Help_Operador.Cadastros.TFLanClientesHelp:Cadastro -  Clientes e Usuários - Help Desk|");
            str.Append("205110:205000:HELP02:Help.Help_Operador.Cadastros.TFCadSetor:Cadastro de Setor|");

            return str.ToString();
        }

    }
}
