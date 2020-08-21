using System;
using System.Collections.Generic;
using System.Text;

namespace Faturamento
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
            str.Append("030000:NULL:NULL:NULL:Faturamento|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("030100:030000:FATORC:Faturamento.TFLan_Orcamento:Orçamentos de Venda|");
            str.Append("030110:030000:FATOR1:Faturamento.TFConsultaOrcamentoProjeto:Orçamentos de Projetos|");
            str.Append("030120:030000:FATOR2:Faturamento.TFLan_Proposta:Lançamento de Propostas|");
            str.Append("030200:030000:FATPED:Faturamento.TFLan_Pedido:Lançamento de Pedidos|");
            str.Append("030210:030000:FATPEC:Faturamento.TFLanPedidoECommerce:Pedidos E-Commerce|");
            str.Append("030300:030000:FATNFF:Faturamento.TFLanFaturamento:Emissão de Notas Fiscais / NFe|");
            str.Append("030301:030000:FATNFE:Faturamento.TFImportarXMLNFe:Importar NFe Entrada|");
            str.Append("030400:030000:FATCOM:Faturamento.TFLanComissao:Fechamento Comissão|");
            str.Append("030500:030000:FATODE:Faturamento.TFLanOrdemCarregamento:Ordem de Carregamento|");
            str.Append("030600:030000:FATOEX:Faturamento.TFLanExpedicao:Ordem de Expedição|");
            str.Append("030900:030000:FATCTR:Faturamento.TFLan_ConhecimentoFrete:Conhecimento Frete|");
            str.Append("031000:030000:FATCON:Faturamento.TFLan_ConferenciaPedido:Conferência de Pedidos|");
            str.Append("031100:030000:FATORA:Faturamento.FOrcAuditoria:Auditoria do orçamento|");

            str.Append("032000:030000:NULL:NULL:Frente Caixa|");
            str.Append("032100:032000:FATCXO:Faturamento.TFLanCaixaPDV:Caixa Operacional|");
            str.Append("032200:032000:FATPDV:Faturamento.TFLanFrenteCaixa:Frente Caixa|");
            str.Append("032220:032000:FATPRV:Faturamento.TFLanPreVenda:Pré Venda|");
            str.Append("032300:032000:FATCVE:Faturamento.TFConsultaFrenteCaixa:Consulta - Venda Frente Caixa|");
            str.Append("032400:032000:FATCCF:Faturamento.TFConsultaNFCe:Consulta - NFC-e|");
            str.Append("032500:032000:FATCRC:Faturamento.TFLanCreditoClifor:Credito Cliente|");
            str.Append("032700:032000:FATDVR:Faturamento.TFLanDevolucaoVenda:Consulta - Devolução Venda|");
            str.Append("032800:032000:FATCNC:Faturamento.TFLanContingenciaNFCeOFF:Contingência NFCe OFFLine|");

            str.Append("033000:030000:FATPRO:Faturamento.TFLanPromocoes:Promoções Venda|");
            str.Append("033100:030000:FATPON:Faturamento.TFConsultaPontosFidelidade:Controle Fidelização Clientes|");
            str.Append("034000:030000:FATCOV:Faturamento.TFLanCompraAvulsa:Romaneio de Compra|");
            str.Append("034100:030000:FATPRV:Faturamento.TFLanProgEspecialVenda:Programação Especial Venda|");
            str.Append("034200:030000:FATLOC:Faturamento.TFLanLocacao:Controle Locação|");
            str.Append("034300:030000:FATCON:Faturamento.TFLanCondicional:Consulta Condicional|");
            str.Append("034400:030000:FATENT:Faturamento.TFLanCargaEntrega:Gerenciamento de Cargas e Entregas|");
            str.Append("034500:030000:FATLOT:Faturamento.TFLanLotesAnvisa:Consulta - Lotes Anvisa|");
            str.Append("034600:030000:FATMET:Faturamento.Cadastros.TFMetaVendedor:Meta Vendedor|");
            str.Append("034700:030000:FATCON:Faturamento.TFConsultaNFeDest:Consulta NFe dos Destinatários|");
            str.Append("034800:030000:FATCAV:Faturamento.TFLanCargaAvulsa:Carga Avulsa|");
            str.Append("034900:030000:FATIVE:Faturamento.TFIntegraVendasExterna:Central Vendas Externa|");
            str.Append("034901:030000:FATQUE:Faturamento.TFLanPosVenda:Pós-Venda|");

            //MENU CADASTROS    
            str.Append("035000:030000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("035200:035000:FATC02:Faturamento.Cadastros.TFCadCFGPedido:Configuração de Pedidos|");
            str.Append("035300:035000:FATC03:Faturamento.Cadastros.TFCadCFGPedidoFiscal:Configuração FISCAL de Pedidos|");
            str.Append("035400:035000:FATC04:Faturamento.Cadastros.TFCadModeloNF:Modelo de Notas Fiscais|");
            str.Append("035500:035000:FATC05:Faturamento.Cadastros.TFCad_SerieNF:Série de Notas Fiscais|");
            str.Append("035600:035000:FATC06:Faturamento.Cadastros.TFCadVendedor:Cadastro Vendedores|");
            str.Append("035700:035000:FATC07:Faturamento.Cadastros.TFCadVendedor_X_RegiaoVenda:Vendedores X Região|");
            str.Append("035900:035000:FATC09:Faturamento.Cadastros.TFCadCFGImpNF:Configuração Impressão Nota Fiscal|");
            str.Append("036100:035000:FATC10:Faturamento.Cadastros.TFCad_CFGNfe:Configuração NF-e|");
            str.Append("036200:035000:FATC11:Faturamento.Cadastros.TFCadCFGOrcamento:Configuração Orçamento|");
            str.Append("036300:035000:FATC12:Faturamento.Cadastros.TFCadPontoVenda:PDV - Ponto de Venda|");
            str.Append("036400:035000:FATC13:Faturamento.Cadastros.TFCadCFGCupomFiscal:Configuração Frente Caixa|");
            str.Append("036600:035000:FATC15:Faturamento.Cadastros.TFCadCfgCompraAvulsa:Configuração Romaneio Compra|");
            str.Append("036700:035000:FATC16:Faturamento.Cadastros.TFCadCFGLocacao:Configuração de Locação|");
            str.Append("036800:035000:FATC17:Faturamento.Cadastros.TFCadEvento:Evento NF-e|");
            str.Append("036900:035000:FATC18:Faturamento.Cadastros.FCadCFGComissao:Configuração Comissão|");
            str.Append("036910:035000:FATC19:Faturamento.Cadastros.TFProgFidelidade:Programar Fidelização Cliente|");
            str.Append("036920:035000:FATC20:Faturamento.Cadastros.TFCadEtapa:Cadastro etapa|");
            str.Append("036930:035000:FATC21:Faturamento.Cadastros.TFCadQuestionario:Cadastro Questionário|");
            str.Append("037000:035000:FATC22:Faturamento.TFLanNFWizard:Configuração de pedidos e movimentação|");

            return str.ToString();
        }
        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}
