using System;
using System.Collections.Generic;
using System.Text;

namespace Balanca
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
            str.Append("010000:NULL:NULL:NULL:Balanças|");
            //OPCOES DE MENU LANCAMENTO
            str.Append("010200:010000:BALPES:Balanca.TFLanPesagemGraos:Pesagens de Veículos|");
            str.Append("010300:010000:BALCLA:Balanca.Classificacao.TFCla_Cereais_Origem:Classificação de Cereais|");
            str.Append("010400:010000:BALLOT:Balanca.FLan_Formacao_Rastreabilidade:Lote de Rastreabilidade|");
            str.Append("010500:010000:BALBSA:Balanca.TFLanPesagemAvulsa:Pesagem Avulsa|");
            str.Append("010600:010000:BALPRD:Balanca.Classificacao.TFProdutoDerivado:Produtos Derivados|");
            str.Append("010700:010000:BALDIV:Balanca.TFLanPesagemDiversas:Pesagem Cargas Diversas|");
            str.Append("010800:010000:BALMNT:Balanca.TFLanMonitorBalanca:Monitor Balança|");
            

            //MENU CADASTROS
            str.Append("015000:010000:NULL:NULL:Cadastros|");            
            //FILHOS DO MENU CADASTROS
            str.Append("015100:015000:BALC01:Balanca.Cadastros.TFCadTransp_X_Veiculo:Transportadora X Veículos|");
            str.Append("015200:015000:BALC02:Balanca.Cadastros.TFCadTpPesagem:Tipo de Pesagem|");
            str.Append("015300:015000:BALC03:Balanca.Cadastros.TFCadCFGFinPsAvulsa:Configuração Financeira Pesagem Avulsa|");
            str.Append("015400:015000:BALC04:Balanca.Cadastros.TFCadTpDesdobroEspecial:Tipo Desdobro Especial|");

            //MENU RELATORIOS
            str.Append("019000:010000:NULL:NULL:Relatorios|");

            return str.ToString();
        }
    }
}
