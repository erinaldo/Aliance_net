using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compra
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

            StringBuilder str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("100000:NULL:NULL:NULL:Compras|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("100100:100000:CMPNEG:Compra.TFLanNegociacao:Negociação de Compras|");
            str.Append("100700:100000:CMPREQ:Compra.TFLanRequisicao:Requisição de Compras|");
            str.Append("100800:100000:CMPAPR:Compra.TFLanAprovacaoCompra: Aprovar Compras|");
            str.Append("100900:100000:CMPCOT:Compra.TFLanCotacao:Cotação de Preços|");
            str.Append("101000:100000:CMPORC:Compra.TFLanOrdemCompra:Ordem de Compra|");
            
            //MENU CADASTROS
            str.Append("105000:100000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("105100:105000:CMPC01:Compra.Cadastros.TFCadUsuarioCompra:Usuário de Compras|");
            str.Append("105200:105000:CMPC02:Compra.Cadastros.TFCadTpRequisicao:Tipo Requisição|");
            str.Append("105300:105000:CMPC03:Compra.Cadastros.TFCadFornecedor_X_GrupoItem:Fornecedor X Grupo Produto|");
            str.Append("105400:105000:CMPC04:Compra.Cadastros.TFCadCFGCompra:Configurações Compras|");

            return str.ToString();
        }
    }
}
