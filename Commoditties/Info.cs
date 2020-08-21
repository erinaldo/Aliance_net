using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commoditties
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
            str.Append("140000:NULL:NULL:NULL:Commoditties|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("140100:140000:GROCTR:Commoditties.TFLan_Contratos:Lançamento de Contratos|");
            str.Append("140101:140000:GROEMB:Commoditties.TFLanEmbalagem:Controle de Embalagens|");
            str.Append("140103:140000:GROIND:Commoditties.TFLanIndiceDesconto:Indices Descontos|");
            str.Append("140200:140000:GROAPL:Commoditties.TFLanAplicacaoPedido:Aplicação de Pedidos/Contratos de Pesagens|");
            str.Append("140300:140000:GROAPL:Commoditties.TFLan_TaxaDeposito:Lançamento e Apuração de Taxas de Depósito|");
            str.Append("140301:140000:GROAUT:Commoditties.TFLan_AutorizRetDeposito:Autorização Retirada Produto|");
            str.Append("140400:140000:GROC09:Commoditties.TFLan_TransfContratos:Transferência de Contratos|");
            str.Append("140500:140000:GROCON:Commoditties.TFLan_Adto:Lançamento de Adiantamento em Contratos|");
            str.Append("140600:140000:GROC06:Commoditties.TFLan_Fixacao:Fixação de Contratos|");
            str.Append("140700:140000:GROCO7:Commoditties.TFCon_Historico_Contrato:Consulta de Histórico de Contratos|");
            str.Append("140800:140000:GROCO8:Commoditties.TFLan_FechamentoOperacao:Fechamento de Operações|");
            str.Append("140900:140000:GROCO9:Commoditties.TFLanRoyaltiesGMO:Controle GMO|");
            str.Append("141000:140000:GROC10:Commoditties.TFConsultaEstoque:Consulta Estoque de Produtos|");

            //MENU CADASTROS
            str.Append("145000:140000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("145100:145000:GROC01:Commoditties.Cadastros.TFCad_Amostra:Tipo de Amostra de Classificação|");
            str.Append("145200:145000:GROC02:Commoditties.Cadastros.TFCad_Desconto:Tabela de Desconto|");
            str.Append("145300:145000:GROC03:Commoditties.Cadastros.TFCad_Safra:Safra|");
            str.Append("145500:145000:GROC05:Commoditties.Cadastros.TFCadDescontoXProduto:Desconto X Produto|");
            str.Append("145900:145000:GROC08:Commoditties.Cadastros.TFCadTaxaDeposito:Taxa Depósito|");
            str.Append("146300:145000:GROC12:Commoditties.Cadastros.TFCad_Headge:Headges de Contratos|");
            str.Append("146400:145000:GROC13:Commoditties.Cadastros.TFCad_ParamoGMO:Parâmetros GMO|");
            str.Append("146500:145000:GROC14:Commoditties.Cadastros.TFCadMetodoAnalise:Metodo Analise|");
            str.Append("146600:145000:GROC15:Commoditties.Cadastros.TFCadCFGTaxa:Configuração de Taxas Depósito|");

            return str.ToString();
        }
    }
}
