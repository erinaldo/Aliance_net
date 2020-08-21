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
            str.Append("050300:050000:FINBLQ:Financeiro.TFConsultaBloquetos:BLOQUETOS de Cobran�a|");
            str.Append("050400:050000:FINCCO:Financeiro.TFConsultaCaixa:Contas Correntes (CAIXA / BANCOS)|");
            str.Append("050500:050000:FINCER:Financeiro.TFConsultaTitulo:Cheques Emitidos/Recebidos|");
            str.Append("050600:050000:NULL:NULL:-|");
            str.Append("050700:050000:FINBLQ:Financeiro.TFLanContas:Contas a Pagar/Receber|");
            str.Append("050710:050000:FINAVL:Financeiro.TFLanDuplicata:Provis�o Duplicatas|");
            str.Append("050800:050000:FINBLQ:Financeiro.TFLanLiquidacao:Liquida��o de Duplicatas|");
            str.Append("050900:050000:NULL:NULL:-|");
            str.Append("051100:050000:FINCRE:Financeiro.TFConsultaLiberarCredito:Controle Cr�dito Clientes|");
            str.Append("051300:050000:FINREC:Financeiro.TFLan_ReciboAvulso:Lan�amento Avulso de Recibos|");
            str.Append("051400:050000:FINEMP:Financeiro.TFLanEmpreendimentos:Controle de Empreendimentos|");
            str.Append("051600:050000:FINCTR:Financeiro.TFConsultaFaturaCartao:Fatura Cart�o Credito/Debito|");
            str.Append("051700:050000:FINFLH:Financeiro.TFConsultaFolhaPgto:Financeiro Folha Pagamento|");
            str.Append("051800:050000:FINEMP:Financeiro.TFConsultaEmprestimos:Emprestimos Recebidos/Concedidos|");
            str.Append("051900:050000:FINCTF:Financeiro.TFLanContratoFin:Lan�amento de Contrato Financeiro|");
            str.Append("052000:050000:FINVIA:Financeiro.TFLanViagem:Viagens|");
            str.Append("052100:050000:FINPRE:Financeiro.TFLanCartaoPrePago:Cart�o Pr�-Pago|");
            str.Append("052200:050000:FINADT:Financeiro.TFAuditFinanc:Auditar Financeiro|");

            //MENU CENTRO DE RESULTADO
            str.Append("051200:050000:NULL:NULL:Centro Resultado|");
            str.Append("051201:051200:FINPCR:Financeiro.TFLan_PrevisaoCentroResultado:Previs�o Centro Resultado|");
            str.Append("051202:051200:FINCCR:Financeiro.TFConsultaCentroResultado:Consulta Centro Resultado|");

            //MENU CADASTROS
            str.Append("055000:050000:NULL:NULL:Cadastros|");
            //FILHOS DO MENU CADASTROS
            str.Append("055100:055000:FINC01:Financeiro.Cadastros.TFCadBanco:Bancos|");
            str.Append("055300:055000:FINC03:Financeiro.Cadastros.FCadCFGBanco:Configura��o de Bancos|");
            str.Append("055400:055000:FINC04:Financeiro.Cadastros.TFCadCidade:Cidades Brasileiras|");
            str.Append("055500:055000:FINC05:Financeiro.Cadastros.TFCadUF:UF - Unidade Federal|");
            str.Append("055600:055000:FINC06:Financeiro.Cadastros.TFCadClifor:Clientes / Fornecedores (CLIFOR)|");
            str.Append("055700:055000:FINC07:Financeiro.Cadastros.TFCad_CondPGTO:Condi��es de Pagamento|");
            str.Append("055800:055000:FINC08:Financeiro.Cadastros.TFCadConfigAdto:Configura��o de ADIANTAMENTO|");
            str.Append("055900:055000:FINC09:Financeiro.Cadastros.TFCadContaGer:Contas Gerenciais |");
            str.Append("056000:055000:FINC10:Financeiro.Cadastros.TFCadContaGer_X_Empresa:Conta Corrente X Empresa|");
            str.Append("056100:055000:FINC11:Financeiro.Cadastros.TFCadCotacaoMoeda:Cota��o de Moeda|");
            str.Append("056400:055000:FINC14:Financeiro.Cadastros.TFCadGrupoCF:Custo Fixo|");
            str.Append("056500:055000:FINC15:Financeiro.Cadastros.TFCadCentroResultado:Centro Resultado|");
            str.Append("056600:055000:FINC16:Financeiro.Cadastros.TFCad_Historico:Hist�ricos de Opera��es|");
            str.Append("056700:055000:FINC17:Financeiro.Cadastros.TFCadJuro:Juros|");
            str.Append("056800:055000:FINC18:Financeiro.Cadastros.TFCadMoeda:Moedas|");
            str.Append("056900:055000:FINC19:Financeiro.Cadastros.TFCadPortador:Portador|");
            str.Append("057000:055000:FINC20:Financeiro.Cadastros.TFCadPortadorXJuro:Portador X Juro|");
            str.Append("057100:055000:FINC21:Financeiro.Cadastros.TFCadTPDocto_Dup:Tipo de Documento|");
            str.Append("057200:055000:FINC22:Financeiro.Cadastros.TFCadTPDuplicata:Tipo de DUPLICATA|");
            str.Append("057300:055000:FINC23:Financeiro.Cadastros.TFCadMaquinaCartao:M�quina Cart�o|");
            str.Append("057400:055000:FINC24:Financeiro.Cadastros.TFCad_RamoAtividade:Ramos de Atividade|");
            str.Append("057500:055000:FINC25:Financeiro.Cadastros.TFCadPais:Pa�s|");
            str.Append("057600:055000:FINC26:Financeiro.Cadastros.TFCadCategoriaCliFor:Categoria CliFor|");
            str.Append("057800:055000:FINC39:Financeiro.Cadastros.TFCadDRE:Cadastro - DRE|");
            str.Append("057900:055000:FINC30:Financeiro.Cadastros.TFCadCFGDescCheque:Configura��o de Cheques|");
            str.Append("058000:055000:FINC31:Financeiro.Cadastros.TFCadBandeiraCartao:Bandeira Cart�o|");
            str.Append("058100:055000:FINC32:Financeiro.Cadastros.TFCadCartaoCredito:Cart�o|");
            str.Append("058200:055000:FINC33:Financeiro.Cadastros.TFCadMotivoInativo:Motivo Inativo|");
            str.Append("058300:055000:FINC34:Financeiro.Cadastros.TFCadCfgFolhaPagamento:Configura��o Financeira Folha Pagamento|");
            str.Append("058400:055000:FINC35:Financeiro.Cadastros.TFCadCFGFaturaCartao:Configura��o Fatura Cart�o|");
            str.Append("058500:055000:FINC36:Financeiro.Cadastros.TFCadCfgEmprestimos:Configura��o Empr�stimos|");
            str.Append("058600:055000:FINC37:Financeiro.Cadastros.TFPracaCobranca:Pra�a Cobran�a|");
            str.Append("058700:055000:FINC38:Financeiro.Cadastros.TFCad_TaxaBandeira:Cadastro Taxa Bandeira Cart�o|");
            str.Append("058800:055000:FINC39:Financeiro.Cadastros.TFCadCFGContratoFin:Configura��o Contrato Financeiro|");
            str.Append("058900:055000:FINC40:Financeiro.Cadastros.TFCadTpData:Tipo de Data|");

            //MENU RELATORIOS
            str.Append("059000:050000:NULL:NULL:Relatorios|");
            str.Append("059900:059000:FINR99:Financeiro.Relatorio.TFRelMovimentoCaixa:Relat�rio Liquida��es por Tipo de Documento|");
            str.Append("059901:059000:FIN901:Financeiro.Relatorio.TFRel_SaldoSinteticoContaGer:Relat�rio de Saldo Contas Gerenciais|");
            str.Append("059902:059000:FIN902:Financeiro.Relatorio.TFRel_DupLiquidada:Relat�rio de Duplicatas Liquidadas|");
            str.Append("059903:059000:FIN903:Financeiro.Relatorio.TFRel_SaldoContasGerenciais:Relat�rio Saldo de Contas Gerenciais|");
            str.Append("059904:059000:FIN904:Financeiro.Relatorio.TFRelPortadoresReceber:Relat�rio de Portadores �  Receber|");
            str.Append("059905:059000:FIN905:Financeiro.Relatorio.TFRelCentroResultado:Relat�rio Centro Resultado por Per�odo|");
            
            return str.ToString();
        }
        public void setPub(string vPub)
        {
            pub = vPub;
        }
    }
}
