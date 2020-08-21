using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locacao
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
            str.Append("220000:NULL:NULL:NULL:Locacao|");

            //OPÇÕES DO MENU DE LANÇAMENTO
            str.Append("220100:220000:LOCL01:Locacao.TFLocacao:Lançamento - Locação|");
            str.Append("220200:220000:LOCL02:Locacao.TFLanLocacao:Expedição - Locação|");
            str.Append("220300:220000:LOCL03:Locacao.TFPainelExpedicao:Painel Expedição|");
            str.Append("220400:220000:LOCL04:Locacao.TFHistoricoPatrimonio:Histórico - Patrimonio|");
            str.Append("220500:220000:LOCL05:Locacao.TFLanLocTerceiro:Locação Terceiro|");
            str.Append("220600:220000:LOCL06:Locacao.TFLanAbastItens:Abastecimento Patrimonio|");
            str.Append("220700:220000:LOCL07:Locacao.TFLanLeituraEndereco:Leitura Endereços|");
            str.Append("220800:220000:LOCL08:Locacao.TFLanRetirada:Retiradas Valores|");
            str.Append("220900:220000:LOCL09:Locacao.TFLocManutencao:Manutenção|");

            //MENU CADASTRO
            str.Append("225000:220000:NULL:NULL:Cadastros|");

            //FILHO DO MENU CADASTRO
            str.Append("225100:225000:LOCC01:Locacao.Cadastros.TFCadTabPreco:Cadastro de Tabela Preço|");
            str.Append("225200:225000:LOCC02:Locacao.Cadastros.TFCadPrecoItem:Cadastro de Preços|");
            str.Append("225300:225000:LOCC03:Locacao.Cadastros.TFCFGLocacao:Configuração - Locação|");

            return str.ToString();
        }
    }
}
