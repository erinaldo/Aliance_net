using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consulta
{
    public class TInfo
    {
        public static string pub;

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
            str.Append("150000:NULL:NULL:NULL:Consulta|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("150100:150000:CONLAN:Consulta.TFLanConsulta:Lançamento de Consultas|");
            str.Append("150110:150000:CENREL:Consulta.TFLan_CentralRelatorios:Central Relatorios|");
            //str.Append("150200:150000:CONLRE:Consulta.TFLan_Relatorio:Lançamento de Relatório|");
            str.Append("150300:150000:CONHOM:Consulta.TFLan_Homologacao:Homologação de RDC|");
            str.Append("150400:150000:CONGDR:Consulta.TFDownload_Relatorio:Gerenciador de Download de Relatórios|");
            str.Append("150500:150000:CONLRE:Consulta.TFLan_Report:Cadastro de Relatorio|"); 
            str.Append("150600:150000:CONEDT:Consulta.TFSqlEditor:Editor de SQL|"); 

            //MENU CADASTROS
            str.Append("155000:150000:NULL:NULL:Cadastro|");
            //FILHOS DO MENU CADASTROS
            str.Append("155100:155000:CONC01:Consulta.Cadastro.TFCad_Operador:Cadastro de Operador|");
            str.Append("155200:155000:CONC02:Consulta.Cadastro.TFCad_TipoAmarracao:Tipo Amarração|");
            str.Append("155300:155000:CONC03:Consulta.Cadastro.TFCad_ParamClasse:Cadastro Parâmetros de Classes|");
            str.Append("155400:155000:CONC04:Consulta.Cadastro.TFCad_AcessoVisa:Cadastro Acesso BI|");
            str.Append("155500:155000:CONC05:Consulta.Cadastro.TFCfgVendasUF:Configuração Vendas UF|"); 

            return str.ToString();
        }
    }
}
