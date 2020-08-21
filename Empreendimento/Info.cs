using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empreendimento
{
    public class TInfo
    {
        static public string pub;
        public string getInfoMenu()
        {
            StringBuilder str;
            str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("230000:NULL:NULL:NULL:Empreendimento|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("230100:230000:EMP01:Empreendimento.TFLan_Orcamento:Orçamento Empreendimento|");
            str.Append("230200:230000:EMP02:Empreendimento.FLanProjeto:Projeto Empreendimento|");
            str.Append("230300:230000:EMP03:Empreendimento.FOrcExecucao:Orçamento Execução|");
            str.Append("230400:230000:EMP04:Empreendimento.TFRequisitarCompra:Requisições de Compra|");

            //MENU CADASTROS
            str.Append("235000:230000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            
            str.Append("235200:235000:EMPC02:Empreendimento.Cadastro.TFCadCFGEmpreendimento:Cadastro Cfg. Empreendimento|");
            str.Append("235300:235000:EMPC03:Empreendimento.Cadastro.FCadEncargosFolha:Cadastro de Encargo folha|");
            str.Append("235400:235000:EMPC04:Empreendimento.Cadastro.FCadAtividade:Cadastro de atividades|");
            str.Append("235500:235000:EMPC05:Empreendimento.Cadastro.FCadDespesa:Cadastro de despesas|"); 
            str.Append("235600:235000:EMPC06:Empreendimento.Cadastro.FCadRequisito:Cadastro de requisitos|"); 

            return str.ToString();
        }

        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}
