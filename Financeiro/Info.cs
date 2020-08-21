using System;
using System.Collections.Generic;
using System.Text;

namespace Financeiro
{
    public class TInfo
    {
        public static string pub;

        public string getInfoMenu()
        {
            StringBuilder str = new StringBuilder();
            //ID_MENU:ID_RAIZ:CD_MODULO:NM_CLASSE:DESCRICAO CLASSE

            //MENU RAIZ
            str.Append("050000:NULL:NULL:NULL:Financeiro|");

            //OPCOES DE MENU LANCAMENTO
            str.Append("050200:050000:FINADT:Financeiro.TFConsulta_Adiantamento:Adiantamentos Cliente/Fornecedor|");
            str.Append("050300:050000:FINBLQ:Financeiro.TFConsultaBloquetos:BLOQUETOS de Cobrança|");
            str.Append("050400:050000:FINCCO:Financeiro.TFConsultaCaixa:Contas Correntes (CAIXA / BANCOS)|");
            str.Append("050500:050000:FINCER:Financeiro.TFConsultaTitulo:Cheques Emitidos/Recebidos|");
            str.Append("050600:050000:NULL:NULL:-|");
            str.Append("050700:050000:FINBLQ:Financeiro.TFLanContas:Contas a Pagar/Receber|");
            str.Append("050710:050000:FINAVL:Financeiro.TFLanDuplicata:Provisão Duplicatas|");
            str.Append("050800:050000:FINBLQ:Financeiro.TFLanLiquidacao:Liquidação de Duplicatas|");
            str.Append("050900:050000:NULL:NULL:-|");
            str.Append("051100:050000:FINCRE:Financeiro.TFConsultaLiberarCredito:Controle Crédito Clientes|");
            str.Append("051300:050000:FINREC:Financeiro.TFLan_ReciboAvulso:Lançamento Avulso de Recibos|");
            str.Append("051400:050000:FINEMP:Financeiro.TFLanEmpreendimentos:Controle de Empreendimentos|");
            str.Append("051600:050000:FINCTR:Financeiro.TFConsultaFaturaCartao:Fatura Cartão Credito/Debito|");
            str.Append("051700:050000:FINFLH:Financeiro.TFConsultaFolhaPgto:Financeiro Folha Pagamento|");
            str.Append("051800:050000:FINEMP:Financeiro.TFConsultaEmprestimos:Emprestimos Recebidos/Concedidos|");
            str.Append("051900:050000:FINCTF:Financeiro.TFLanContratoFin:Lançamento de Contrato Financeiro|");
            str.Append("052000:050000:FINVIA:Financeiro.TFLanViagem:Viagens|");
            str.Append("052100:050000:FINPRE:Financeiro.TFLanCartaoPrePago:Cartão Pré-Pago|");
            str.Append("052200:050000:FINADT:Financeiro.TFAuditFinanc:Auditar Financeiro|");

            //MENU CENTRO DE RESULTADO
            str.Append("051200:050000:NULL:NULL:Centro Resultado|");
            str.Append("051201:051200:FINPCR:Financeiro.TFLan_PrevisaoCentroResultado:Previsão Centro Resultado|");
            str.Append("051202:051200:FINCCR:Financeiro.TFConsultaCentroResultado:Consulta Centro Resultado|");

            //MENU CADASTROS
            str.Append("055000:050000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("055100:055000:FINC01:Financeiro.Cadastros.TFCadBanco:Bancos|");
            str.Append("055300:055000:FINC03:Financeiro.Cadastros.FCadCFGBanco:Configuração de Bancos|");
            str.Append("055400:055000:FINC04:Financeiro.Cadastros.TFCadCidade:Cidades Brasileiras|");
            str.Append("055500:055000:FINC05:Financeiro.Cadastros.TFCadUF:UF - Unidade Federal|");
            str.Append("055600:055000:FINC06:Financeiro.Cadastros.TFCadClifor:Clientes / Fornecedores (CLIFOR)|");
            str.Append("055700:055000:FINC07:Financeiro.Cadastros.TFCad_CondPGTO:Condições de Pagamento|");
            str.Append("055800:055000:FINC08:Financeiro.Cadastros.TFCadConfigAdto:Configuração de ADIANTAMENTO|");
            str.Append("055900:055000:FINC09:Financeiro.Cadastros.TFCadContaGer:Contas Gerenciais |");
            str.Append("056000:055000:FINC10:Financeiro.Cadastros.TFCadContaGer_X_Empresa:Conta Corrente X Empresa|");
            str.Append("056100:055000:FINC11:Financeiro.Cadastros.TFCadCotacaoMoeda:Cotação de Moeda|");
            str.Append("056400:055000:FINC14:Financeiro.Cadastros.TFCadGrupoCF:Custo Fixo|");
            str.Append("056500:055000:FINC15:Financeiro.Cadastros.TFCadCentroResultado:Centro Resultado|");
            str.Append("056600:055000:FINC16:Financeiro.Cadastros.TFCad_Historico:Históricos de Operações|");
            str.Append("056700:055000:FINC17:Financeiro.Cadastros.TFCadJuro:Juros|");
            str.Append("056800:055000:FINC18:Financeiro.Cadastros.TFCadMoeda:Moedas|");
            str.Append("056900:055000:FINC19:Financeiro.Cadastros.TFCadPortador:Portador|");
            str.Append("057000:055000:FINC20:Financeiro.Cadastros.TFCadPortadorXJuro:Portador X Juro|");
            str.Append("057100:055000:FINC21:Financeiro.Cadastros.TFCadTPDocto_Dup:Tipo de Documento|");
            str.Append("057200:055000:FINC22:Financeiro.Cadastros.TFCadTPDuplicata:Tipo de DUPLICATA|");
            str.Append("057300:055000:FINC23:Financeiro.Cadastros.TFCadMaquinaCartao:Máquina Cartão|");
            str.Append("057400:055000:FINC24:Financeiro.Cadastros.TFCad_RamoAtividade:Ramos de Atividade|");
            str.Append("057500:055000:FINC25:Financeiro.Cadastros.TFCadPais:País|");
            str.Append("057600:055000:FINC26:Financeiro.Cadastros.TFCadCategoriaCliFor:Categoria CliFor|");
            str.Append("057800:055000:FINC39:Financeiro.Cadastros.TFCadDRE:Cadastro - DRE|");
            str.Append("057900:055000:FINC30:Financeiro.Cadastros.TFCadCFGDescCheque:Configuração de Cheques|");
            str.Append("058000:055000:FINC31:Financeiro.Cadastros.TFCadBandeiraCartao:Bandeira Cartão|");
            str.Append("058100:055000:FINC32:Financeiro.Cadastros.TFCadCartaoCredito:Cartão|");
            str.Append("058200:055000:FINC33:Financeiro.Cadastros.TFCadMotivoInativo:Motivo Inativo|");
            str.Append("058300:055000:FINC34:Financeiro.Cadastros.TFCadCfgFolhaPagamento:Configuração Financeira Folha Pagamento|");
            str.Append("058400:055000:FINC35:Financeiro.Cadastros.TFCadCFGFaturaCartao:Configuração Fatura Cartão|");
            str.Append("058500:055000:FINC36:Financeiro.Cadastros.TFCadCfgEmprestimos:Configuração Empréstimos|");
            str.Append("058600:055000:FINC37:Financeiro.Cadastros.TFPracaCobranca:Praça Cobrança|");
            str.Append("058700:055000:FINC38:Financeiro.Cadastros.TFCad_TaxaBandeira:Cadastro Taxa Bandeira Cartão|");
            str.Append("058800:055000:FINC39:Financeiro.Cadastros.TFCadCFGContratoFin:Configuração Contrato Financeiro|");
            str.Append("058900:055000:FINC40:Financeiro.Cadastros.TFCadTpData:Tipo de Data|");

            //MENU RELATORIOS
            str.Append("059000:050000:NULL:NULL:Relatorios|");
            str.Append("059900:059000:FINR99:Financeiro.Relatorio.TFRelMovimentoCaixa:Relatório Liquidações por Tipo de Documento|");
            str.Append("059901:059000:FIN901:Financeiro.Relatorio.TFRel_SaldoSinteticoContaGer:Relatório de Saldo Contas Gerenciais|");
            str.Append("059902:059000:FIN902:Financeiro.Relatorio.TFRel_DupLiquidada:Relatório de Duplicatas Liquidadas|");
            str.Append("059903:059000:FIN903:Financeiro.Relatorio.TFRel_SaldoContasGerenciais:Relatório Saldo de Contas Gerenciais|");
            str.Append("059904:059000:FIN904:Financeiro.Relatorio.TFRelPortadoresReceber:Relatório de Portadores à  Receber|");
            str.Append("059905:059000:FIN905:Financeiro.Relatorio.TFRelCentroResultado:Relatório Centro Resultado por Período|");
            
            return str.ToString();
        }
        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}
