using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using System.IO;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco104
    {
        const string CodigoBanco = "104";
        const string NomeBanco = "Caixa Economica Federal";

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantil: return "02";
                case TEspecieDocumento.edNotaPromissoria: return "12";
                case TEspecieDocumento.edDuplicataServico: return "04";
                case TEspecieDocumento.edNotaSeguro: return "16";
                case TEspecieDocumento.edLetraCambio: return "07";
                default: return "99";
            }
        }

        public string GetNomeBanco() //{Retorna o nome do banco}        
        {
            return NomeBanco;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            string clivre = ATitulo.Cedente.CodigoCedente.Trim() + //Codigo do Cedente
                            ATitulo.Cedente.DigitoCodigoCedente.Trim() + //Digito do Cedente
                            ATitulo.Nosso_numero.Substring(2, 3) +
                            ATitulo.Nosso_numero.Substring(0, 1) +
                            ATitulo.Nosso_numero.Substring(5, 3) +
                            ATitulo.Nosso_numero.Substring(1, 1) +
                            ATitulo.Nosso_numero.Substring(8, 9);
            return clivre + Utils.Estruturas.Mod11(clivre, 9, false, 0).ToString();
        }

        public string CalcularNossoNumero(string Carteira, decimal vNossoNumero)
        {
            return Carteira.Trim() + (vNossoNumero + 1).ToString().PadLeft(15, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Utils.Estruturas.Mod11(ATitulo.Nosso_numero, 9, false, 0).ToString();
        }

        public decimal TratarInstrucaoRemessa(string val)
        {
            switch (val)
            {
                case "RT": { return 1; }//Entrada de Titulo
                case "PB": { return 2; }//Pedido de Baixa
                case "AV": { return 6; }//Alterar Vencimento
                default: return decimal.Zero;
            }
        }

        public string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "01": return "SOLICITAÇÃO DE IMPRESSÃO DE TITULOS CONFIRMADA";
                case "02": return "ENTRADA CONFIRMADA";
                case "03": return "ENTRADA REJEITADA";
                case "04": return "TRANSFERÊNCIA DE CARTEIRA/ENTRADA";
                case "05": return "TRANSFERÊNCIA DE CARTEIRA/BAIXA";
                case "06": return "LIQUIDAÇÃO";
                case "07": return "CONFIRMAÇÃO DE RECEBIMENTO DE INSTRUÇÃO DE DESCONTO";
                case "08": return "CONFIRMAÇÃO DE RECEBIMENTO DE INSTRUÇÃO DE CANCELAMENTO DE DESCONTO";
                case "09": return "BAIXA";
                case "12": return "CONFIRMAÇÃO DE RECEBIMENTO INSTRUÇÃO DE ABATIMENTO";
                case "13": return "CONFIRMAÇÃO DE RECEBIMENTO INSTRUÇÃO DE CANCELAMENTO ABATIMENTO";
                case "14": return "CONFIRMAÇÃO DE RECEBIMENTO INSTRUÇÃO ALTERAÇÃO VENCIMENTO";
                case "19": return "CONFIRMAÇÃO DE RECEBIMENTO INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMAÇÃO DE RECEBIMENTO INSTRUÇÃO DE SUSTAÇÃO/CANCELAMENTO DE PROTESTO";
                case "23": return "REMESSA A CARTÓRIO";
                case "24": return "RETIRADA DE CARTÓRIO";
                case "25": return "PROTESTADO E BAIXADO";
                case "26": return "INSTRUÇÃO REJEITADA";
                case "27": return "CONFIRMAÇÃO DO PEDIDO DE ALTERAÇÃO DE OUTROS DADOS";
                case "28": return "DEBITO DE TARIFAS/CUSTAS";
                case "30": return "ALTERAÇÃO DE DADOS REJEITADAS";
                case "35": return "CONFIRMAÇÃO DE INCLUSÃO BANCO DO SACADO";
                case "36": return "CONFIRMAÇÃO DE ALTERAÇÃO BANCO DE SACADO";
                case "37": return "CONFIRMAÇÃO DE EXCLUSÃO BANCO DE SACADO";
                case "38": return "EMISSÃO DE BLOQUETOS DE BANCO DE SACADO";
                case "39": return "MANUTENÇÃO DE SACADO REJEITADA";
                case "40": return "ENTRADA DE TITULO VIA BANCO DE SACADO REJEITADA";
                case "41": return "MANUTENÇÃO DE BANCO DE SACADO REJEITADA";
                case "44": return "ESTORNO DE BAIXA/LIQUIDAÇÃO";
                case "45": return "ALTERAÇÃO DE DADOS";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string Cd_ocorrencia, string codigo)
        {
            if (Cd_ocorrencia.Trim().Equals("02") ||
                Cd_ocorrencia.Trim().Equals("03") ||
                Cd_ocorrencia.Trim().Equals("26") ||
                Cd_ocorrencia.Trim().Equals("30"))
                switch (codigo)
                {
                    case "AA": return "Cód Desconto Preenchido, Obrig Data e Valor/Perc";
                    case "AB": return "Cod Desconto Obrigatório p/ Cód Mov = 7";
                    case "AC": return "Forma de Cadastramento Inválida";
                    case "AD": return "Data de Desconto deve estar em Ordem Crescente";
                    case "AE": return "Data de Desconto é Posterior a Data de Vencimento";
                    case "AF": return "Título não está com situação Em Aberto";
                    case "AG": return "Título já está Vencido / Vencendo";
                    case "AH": return "Não existe desconto a ser cancelado";
                    case "AI": return "Data solicitada p/ Prot/Dev é anterior a data atual";
                    case "AJ": return "Código do Sacado Inválido";
                    case "AK": return "Número da Parcela Invalida ou Fora de Sequencia";
                    case "AL": return "Estorno de Envio Não Permitido";
                    case "AM": return "Nosso Numero Fora de Sequencia";
                    case "VA": return "Arq.Ret.Inexis. P/ Redisp. Nesta Dt/Nro";
                    case "VB": return "Registro Duplicado";
                    case "VC": return "Cedente deve ser padrão CNAB240";
                    case "VD": return "Ident. Banco Sacado Inválida";
                    case "VE": return "Num Docto Cobr Inválido";
                    case "VF": return "Vlr/Perc a ser concedido inválido";
                    case "VG": return "Data de Inscrição Inválida";
                    case "VH": return "Data Movto Inválida";
                    case "VI": return "Data Inicial Inválida";
                    case "VJ": return "Data Final Inválida";
                    case "VK": return "Banco de Sacado já cadastrado";
                    case "VL": return "Cedente não cadastrado";
                    case "VM": return "Número de Lote Duplicado";
                    case "VN": return "Forma de Emissão de Bloqueto Inválida";
                    case "VO": return "Forma Entrega Bloqueto Inválida p/ Emissão via Banco";
                    case "VP": return "Forma Entrega Bloqueto Invalida p/ Emissão via Cedente";
                    case "VQ": return "Opção para Endosso Inválida";
                    case "VR": return "Tipo de Juros ao Mês Inválido";
                    case "VS": return "Percentual de Juros ao Mês Inválido";
                    case "VT": return "Percentual / Valor de Desconto Inválido";
                    case "VU": return "Prazo de Desconto Inválido";
                    case "VV": return "Preencher Somente Percentual ou Valor";
                    case "VW": return "Prazo de Multa Invalido";
                    case "VX": return "Perc. Desconto tem que estar em ordem decrescente";
                    case "VY": return "Valor Desconto tem que estar em ordem descrescente";
                    case "VZ": return "Dias/Data desconto tem que estar em ordem decrescente";
                    case "WA": return "Vlr Contr p/ aquisição de Bens Inválid";
                    case "WB": return "Vlr Contr p/ Fundo de Reserva Inválid";
                    case "WC": return "Vlr Rend. Aplicações Financ Inválido";
                    case "WD": return "Valor Multa/Juros Monetarios Inválido";
                    case "WE": return "Valor Premios de Seguro Inválido";
                    case "WF": return "Valor Custas Judiciais Inválido";
                    case "WG": return "Valor Reembolso de Despesas Inválido";
                    case "WH": return "Valor Outros Inválido";
                    case "WI": return "Valor de Aquisição de Bens Inválido";
                    case "WJ": return "Valor Devolvido ao Consorciado Inválido";
                    case "WK": return "Vlr Desp. Registro de Contrato Inválido";
                    case "WL": return "Valor de Rendimentos Pagos Inválido";
                    case "WM": return "Data de Descrição Inválida";
                    case "WN": return "Valor do Seguro Inválido";
                    case "WO": return "Data de Vencimento Inválida";
                    case "WP": return "Data de Nascimento Inválida";
                    case "WQ": return "CPF/CNPJ do Aluno Inválido";
                    case "WR": return "Data de Avaliação Inválida";
                    case "WS": return "CPF/CNPJ do Locatario Inválido";
                    case "WT": return "Literal da Remessa Inválida";
                    case "WU": return "Tipo de Registro Inválido";
                    case "WV": return "Modelo Inválido";
                    case "WW": return "Código do Banco de Sacados Inválido";
                    case "WX": return "Banco de Sacados não Cadastrado";
                    case "WY": return "Qtde dias para Protesto tem que estar entre 2 e 90";
                    case "WZ": return "Não existem Sacados para este Banco";
                    case "XA": return "Preço Unitario do Produto Inválido";
                    case "XB": return "Preço Total do Produto Inválido";
                    case "XC": return "Valor Atual do Bem Inválido";
                    case "XD": return "Quantidade de Bens Entregues Inválido";
                    case "XE": return "Quantidade de Bens Distribuidos Inválido";
                    case "XF": return "Quantidade de Bens não Distribuidos Inválido";
                    case "XG": return "Número da Próxima Assembléia Inválido";
                    case "XH": return "Horario da Próxima Assembléia Inválido";
                    case "XI": return "Data da Próxima Assembléia Inválida";
                    case "XJ": return "Número de Ativos Inválido";
                    case "XK": return "Número de Desistentes Excluidos Inválido";
                    case "XL": return "Número de Quitados Inválido";
                    case "XM": return "Número de Contemplados Inválido";
                    case "XN": return "Número de não Contemplados Inválido";
                    case "XO": return "Data da Última Assembléia Inválida";
                    case "XP": return "Quantidade de Prestações Inválida";
                    case "XQ": return "Data de Vencimento da Parcela Inválida";
                    case "XR": return "Valor da Amortização Inválida";
                    case "XS": return "Código do Personalizado Inválido";
                    case "XT": return "Valor da Contribuição Inválida";
                    case "XU": return "Percentual da Contribuição Inválido";
                    case "XV": return "Valor do Fundo de Reserva Inválido";
                    case "XW": return "Número Parcela Inválido ou Fora de Sequência";
                    case "XX": return "Percentual Fundo de Reserva Inválido";
                    case "XY": return "Prz Desc/Multa Preenchido, Obrigat.Perc. ou Valor";
                    case "XZ": return "Valor Taxa de Administração Inválida";
                    case "YA": return "Data de Juros Inválida ou Não Informada";
                    case "YB": return "Data Desconto Inválida ou Não Informada";
                    case "YC": return "E-mail Inválido";
                    case "YD": return "Código de Ocorrência Inválido";
                    case "YE": return "Sacado já Cadastrado (Banco de Sacados)";
                    case "YF": return "Sacado não Cadastrado (Banco de Sacados)";
                    case "YG": return "Remessa Sem Registro Tipo 9";
                    case "YH": return "Identificação da Solicitação Inválida";
                    case "YI": return "Quantidade Bloquetos Solicitada Inválida";
                    case "YJ": return "railler do Arquivo não Encontrado";
                    case "YK": return "Tipo Inscrição do Responsable Inválido";
                    case "YL": return "Número Inscrição do Responsable Inválido";
                    case "YM": return "Ajuste de Vencimento Inválido";
                    case "YN": return "Ajuste de Emissão Inválido";
                    case "YO": return "Código de Modelo Inválido";
                    case "YP": return "Vía de Entrega Inválido";
                    case "YQ": return "Espécie Banco de Sacado Inválido";
                    case "YR": return "Aceite Banco de Sacado Inválido";
                    case "YS": return "acado já Cadastrado";
                    case "YT": return "Sacado não Cadastrado";
                    case "YU": return "Número do Telefone Inválido";
                    case "YV": return "CNPJ do Condomínio Inválido";
                    case "YW": return "Indicador de Registro de Título Inválido";
                    case "YX": return "Valor da Nota Inválido";
                    case "YY": return "Qtde de dias para Devolução tem que estar entre 5 e 120";
                    case "YZ": return "Quantidade de Produtos Inválida";
                    case "ZA": return "Perc. Taxa de Administração Inválido";
                    case "ZB": return "Valor do Seguro Inválido";
                    case "ZC": return "Percentual do Seguro Inválido";
                    case "ZD": return "Valor da Diferença da Parcela Inválido";
                    case "ZE": return "Perc. Da Diferença da Parcela Inválido";
                    case "ZF": return "Valor Reajuste do Saldo de Caixa Inválido";
                    case "ZG": return "Perc. Reajuste do Saldo de Caixa Inválido";
                    case "ZH": return "Valor Total a Pagar Inválido";
                    case "ZI": return "Percentual ao Total a Pagar Inválido";
                    case "ZJ": return "Valor de Outros Acréscimos Inválido";
                    case "ZK": return "Perc. De Outros Acréscimos Inválido";
                    case "ZL": return "Valor de Outras Deduções Inválido";
                    case "ZM": return "Perc. De Outras Deduções Inválido";
                    case "ZN": return "Valor da Contribuição Inválida";
                    case "ZO": return "Percentual da Contribuição Inválida";
                    case "ZP": return "Valor de Juros/Multa Inválido";
                    case "ZQ": return "Percentual de Juros/Multa Inválido";
                    case "ZR": return "Valor Cobrado Inválido";
                    case "ZS": return "Percentual Cobrado Inválido";
                    case "ZT": return "Valor Disponibilizado em Caixa Inválido";
                    case "ZU": return "Valor Depósito Bancario Inválido";
                    case "ZV": return "Valor Aplicações Financieras Inválido";
                    case "ZW": return "Data/Valor Preenchidos, Obrigatório Dódigo Desconto";
                    case "ZX": return "Valor Cheques em Cobrança Inválido";
                    case "ZY": return "Desconto c/ valor Fixo, Obrigatório Valor do Título";
                    case "ZZ": return "Código Movimento Inválido p/ Segmento Y8";
                    case "01": return "Código do Banco Inválido";
                    case "02": return "Código do Registro Inválido";
                    case "03": return "Código do Segmento Inválido";
                    case "04": return "Código do Movimento não Permitido p/ Carteira";
                    case "05": return "Código do Movimento Inválido";
                    case "06": return "Tipo Número Inscrição Cedente Inválido";
                    case "07": return "Agencia/Conta/DV Inválidos";
                    case "08": return "Nosso Número Inválido";
                    case "09": return "Nosso Número Duplicado";
                    case "10": return "Carteira Inválida";
                    case "11": return "Data de Geração Inválida";
                    case "12": return "Tipo de Documento Inválido";
                    case "13": return "Identif. Da Emissão do Bloqueto Inválida";
                    case "14": return "Identif. Da Distribuição do Bloqueto Inválida";
                    case "15": return "Características Cobrança Incompatíveis";
                    case "16": return "Data de Vencimento Inválida";
                    case "17": return "Data de Vencimento Anterior a Data de Emissão";
                    case "18": return "Vencimento fora do prazo de operação";
                    case "19": return "Título a Cargo de Bco Correspondentes c/ Vencto Inferior a XX Dias";
                    case "20": return "Valor do Título Inválido";
                    case "21": return "Espécie do Título Inválida";
                    case "22": return "Espécie do Título Não Permitida para a Carteira";
                    case "23": return "Aceite Inválido";
                    case "24": return "Data da Emissão Inválida";
                    case "25": return "Data da Emissão Posterior a Data de Entrada";
                    case "26": return "Código de Juros de Mora Inválido";
                    case "27": return "Valor/Taxa de Juros de Mora Inválido";
                    case "28": return "Código do Desconto Inválido";
                    case "29": return "Valor do Desconto Maior ou Igual ao Valor do Título";
                    case "30": return "Desconto a Conceder Não Confere";
                    case "31": return "Concessão de Desconto - Já Existe Desconto Anterior";
                    case "32": return "Valor do IOF Inválido";
                    case "33": return "Valor do Abatimento Inválido";
                    case "34": return "Valor do Abatimento Maior ou Igual ao Valor do Título";
                    case "35": return "Valor Abatimento a Conceder Não Confere";
                    case "36": return "Concessão de Abatimento - Já Existe Abatimento Anterior";
                    case "37": return "Código para Protesto Inválido";
                    case "38": return "Prazo para Protesto Inválido";
                    case "39": return "Pedido de Protesto Não Permitido para o Título";
                    case "40": return "Título com Ordem de Protesto Emitida";
                    case "41": return "Pedido Cancelamento/Sustação p/ Títulos sem Instrução Protesto";
                    case "42": return "Código para Baixa/Devolução Inválido";
                    case "43": return "Prazo para Baixa/Devolução Inválido";
                    case "44": return "Código da Moeda Inválido";
                    case "45": return "Nome do Sacado Não Informado";
                    case "46": return "Tipo/Número de Inscrição do Sacado Inválidos";
                    case "47": return "Endereço do Sacado Não Informado";
                    case "48": return "CEP Inválido";
                    case "49": return "CEP Sem Praça de Cobrança (Não Localizado)";
                    case "50": return "CEP Referente a um Banco  Correspondente";
                    case "51": return "CEP incompatível com a Unidade da Federação";
                    case "52": return "Unidade da Federação Inválida";
                    case "53": return "Tipo/Número de Inscrição do Sacador/Avalista Inválidos";
                    case "54": return "Sacador/Avalista Não Informado";
                    case "55": return "Nosso número no Banco Correspondente Não Informado";
                    case "56": return "Código do Banco Correspondente Não Informado";
                    case "57": return "Código da Multa Inválido";
                    case "58": return "Data da Multa Inválida";
                    case "59": return "Valor/Percentual da Multa Inválido";
                    case "60": return "Movimento para Título Não Cadastrado";
                    case "61": return "Alteração da Agência Cobradora/DV Inválida";
                    case "62": return "Tipo de Impressão Inválido";
                    case "63": return "Entrada para Título já Cadastrado";
                    case "64": return "Entrada Inválida para Cobrança Caucionada";
                    case "65": return "CEP do Sacado não encontrado";
                    case "66": return "Agencia Cobradora não encontrada";
                    case "67": return "Agencia Cedente não encontrada";
                    case "68": return "Movimentação inválida para título";
                    case "69": return "Alteração de dados inválida";
                    case "70": return "Apelido do cliente não cadastrado";
                    case "71": return "Erro na composição do arquivo";
                    case "72": return "Lote de serviço inválido";
                    case "73": return "Código do Cedente inválido";
                    case "74": return "Cedente não pertencente a Cobrança Eletrônica";
                    case "75": return "Nome da Empresa inválido";
                    case "76": return "Nome do Banco inválido";
                    case "77": return "Código da Remessa inválido";
                    case "78": return "Data/Hora Geração do arquivo inválida";
                    case "79": return "Número Sequencial do arquivo inválido";
                    case "80": return "Versão do Lay out do arquivo inválido";
                    case "81": return "Literal REMESSA-TESTE - Válido só p/ fase testes";
                    case "82": return "Literal REMESSA-TESTE - Obrigatório p/ fase testes";
                    case "83": return "Tp Número Inscrição Empresa inválido";
                    case "84": return "Tipo de Operação inválido";
                    case "85": return "Tipo de serviço inválido";
                    case "86": return "Forma de lançamento inválido";
                    case "87": return "Número da remessa inválido";
                    case "88": return "Número da remessa menor/igual remessa anterior";
                    case "89": return "Lote de serviço divergente";
                    case "90": return "Número sequencial do registro inválido";
                    case "91": return "Erro seq de segmento do registro detalhe";
                    case "92": return "Cod movto divergente entre grupo de segm";
                    case "93": return "Qtde registros no lote inválido";
                    case "94": return "Qtde registros no lote divergente";
                    case "95": return "Qtde lotes no arquivo inválido";
                    case "96": return "Qtde lotes no arquivo divergente";
                    case "97": return "Qtde registros no arquivo inválido";
                    case "98": return "Qtde registros no arquivo divergente";
                    case "99": return "Código de DDD inválido";
                    default: return string.Empty;
                }
            else if (Cd_ocorrencia.Trim().Equals("28"))
                switch (codigo)
                {
                    case "01": return "Tarifa de Emissão de Extrato de Posição";
                    case "02": return "Tarifa de Manutenção de Título Vencido";
                    case "03": return "Tarifa de Sustação";
                    case "04": return "Tarifa de Protesto";
                    case "05": return "Tarifa de Outras Instruções";
                    case "06": return "Tarifa de Outras Ocorrências";
                    case "07": return "Tarifa de Envio de Duplicata ao Sacado";
                    case "08": return "Custas de Protesto";
                    case "09": return "Custas de Sustação de Protesto";
                    case "10": return "Custas de Cartório Distribuidor";
                    case "11": return "Custas de Edital";
                    case "12": return "Redisponibilização de Arquivo Retorno Eletrônico";
                    case "13": return "Tarifa Sobre Registro Cobrada na Baixa/Liquidação";
                    case "14": return "Tarifa Sobre Reapresentação Automática";
                    case "15": return "Banco de Sacados";
                    case "16": return "Tarifa Sobre Informações Via Fax";
                    case "17": return "Entrega Aviso Disp Bloqueto via e-amail ao sacado (s/ emissão Bloqueto)";
                    case "18": return "Emissão de Bloqueto Pré-impresso CAIXA matricial";
                    case "19": return "Emissão de Bloqueto Pré-impresso CAIXA A4";
                    case "20": return "Emissão de Bloqueto Padrão CAIXA";
                    case "21": return "Emissão de Bloqueto/Carnê";
                    case "31": return "Emissão de Aviso de Vencido";
                    case "42": return "Alteração cadastral de dados do título - sem emissão de aviso";
                    case "45": return "Emissão de 2ª via de Bloqueto Cobrança Registrada";
                    default: return string.Empty;
                }
            else if (Cd_ocorrencia.Trim().Equals("06") ||
                Cd_ocorrencia.Trim().Equals("09") ||
                Cd_ocorrencia.Trim().Equals("17"))
                switch (codigo)
                {
                    case "02": return "Casa Lotérica";
                    case "03": return "Agências CAIXA";
                    case "04": return "Compensação Eletrônica";
                    case "05": return "Compensação Convencional";
                    case "06": return "Internet Banking";
                    case "07": return "Correspondente Bancário";
                    case "08": return "Em Cartório";
                    case "09": return "Comandada Banco";
                    case "10": return "Comandada Cliente via Arquivo";
                    case "11": return "Comandada Cliente On-line";
                    case "12": return "Decurso Prazo - Cliente";
                    case "13": return "Decurso Prazo - Banco";
                    case "14": return "Protestado";
                    default: return string.Empty;
                }
            else return string.Empty;
        }

        public void FormatarBoleto(blTitulo ATitulo, string AAgenciaCodigoCedente, string ANossoNumero, string ACarteira, string AEspecieDocumento) //{Define o formato como alguns valores serão apresentados no boleto }
        {
            AAgenciaCodigoCedente = ATitulo.Cedente.ContaBancaria.CodigoAgencia.PadLeft(4, '0') +
                                    ATitulo.Cedente.CodigoCedente.PadLeft(11, '0') + '.' +
                                    ATitulo.Cedente.DigitoCodigoCedente;
            ANossoNumero = ATitulo.Nosso_numero.PadLeft(10, '0') + "." + ATitulo.Digito_nossonumero;
            ACarteira = ATitulo.Carteira.PadRight(2, ' ');
            switch (ATitulo.Especie_documento)
            {
                case TEspecieDocumento.edApoliceSeguro: AEspecieDocumento = "AP"; break;
                case TEspecieDocumento.edCheque: AEspecieDocumento = "CH"; break;
                case TEspecieDocumento.edDuplicataMercantil: AEspecieDocumento = "DM"; break;
                case TEspecieDocumento.edDuplicataMercantialIndicacao: AEspecieDocumento = "DMI"; break;
                case TEspecieDocumento.edDuplicataRural: AEspecieDocumento = "DR"; break;
                case TEspecieDocumento.edDuplicataServico: AEspecieDocumento = "DS"; break;
                case TEspecieDocumento.edDuplicataServicoIndicacao: AEspecieDocumento = "DSI"; break;
                case TEspecieDocumento.edFatura: AEspecieDocumento = "FAT"; break;
                case TEspecieDocumento.edLetraCambio: AEspecieDocumento = "LC"; break;
                case TEspecieDocumento.edMensalidadeEscolar: AEspecieDocumento = "ME"; break;
                case TEspecieDocumento.edNotaCreditoComercial: AEspecieDocumento = "NCC"; break;
                case TEspecieDocumento.edNotaCreditoExportacao: AEspecieDocumento = "NCE"; break;
                case TEspecieDocumento.edNotaCreditoIndustrial: AEspecieDocumento = "NCI"; break;
                case TEspecieDocumento.edNotaCreditoRural: AEspecieDocumento = "NCR"; break;
                case TEspecieDocumento.edNotaDebito: AEspecieDocumento = "ND"; break;
                case TEspecieDocumento.edNotaPromissoria: AEspecieDocumento = "NP"; break;
                case TEspecieDocumento.edNotaPromissoriaRural: AEspecieDocumento = "NPR"; break;
                case TEspecieDocumento.edNotaSeguro: AEspecieDocumento = "NS"; break;
                case TEspecieDocumento.edParcelaConsorcio: AEspecieDocumento = "PC"; break;
                case TEspecieDocumento.edRecibo: AEspecieDocumento = "RC"; break;
                case TEspecieDocumento.edTriplicataMercantil: AEspecieDocumento = "TM"; break;
                case TEspecieDocumento.edTriplicataServico: AEspecieDocumento = "TS"; break;
                default: AEspecieDocumento = ""; break;
            }
        }

        private void GerarRemessaCNAB240(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;
            int tot_reglote = 0;

            #region Registro Header Arquivo
            //Codigo do banco 001-003
            registros.Append(CodigoBanco);
            //Lote Servico 004-007
            registros.Append("0000");
            //Tipo Registro 008-008
            registros.Append("0");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Tipo Inscrição Empresa 018-018
            registros.Append(aCobranca.Titulos[0].Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "2" : "1");
            //CNPJ Empresa 019-032
            registros.Append(aCobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
            //Uso Caixa 033-052
            registros.Append("".FormatStringEsquerda(20, '0'));
            //Agencia 053-057
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito Agencia 058-058
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.Trim());
            //Codigo Cedente 059-064
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
            //Uso Caixa 065-072
            registros.Append("".FormatStringEsquerda(8, '0'));
            //Nome Cedente 073-102
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Nome Banco 103-132
            registros.Append(NomeBanco.ToUpper().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Brancos 133-142
            registros.Append("".FormatStringDireita(10, ' '));
            //Codigo Remessa 143-143
            registros.Append("1");
            //Data Arquivo 144-151
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyyyy"));
            //Hora Arquivo 152-157
            registros.Append(aCobranca.DataArquivo.ToString("HHmmss"));
            //Sequencial Arquivo 158-163
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(6, '0'));
            //Layout Arquivo 164-166
            registros.Append("050");
            //Densidade 167-171
            registros.Append("".FormatStringEsquerda(5, '0'));
            //Brancos 172-191
            registros.Append("".FormatStringDireita(20, ' '));
            //Reservado Empresa 192-211
            registros.Append("REMESSA-PRODUCAO".FormatStringDireita(20, ' '));
            //Versão Aplicativo Caixa 212-215
            registros.Append("".FormatStringDireita(4, ' '));
            //Reservado Caixa 216-240
            registros.Append("".FormatStringDireita(25, ' '));
            tot_registros++;

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Header Lote
            registros = new StringBuilder();
            //Codigo Banco 001-003
            registros.Append(CodigoBanco.Trim());
            //Lote Servico 004-007
            registros.Append("0001");
            //Tipo Servico 008-008
            registros.Append("1");
            //Tipo Operação 009-009
            registros.Append("R");//R-Remessa T-Retorno
            //Tipo Servico 010-011
            registros.Append(aCobranca.Titulos[0].Tp_cobranca.Trim().ToUpper().Equals("CR") ? "01" : "02");
            //Febraban 012-013
            registros.Append("00");
            //Layout Lote 014-016
            registros.Append("030");
            //Brancos 017-017
            registros.Append(" ");
            //Tipo Insc. Empresa 018-018
            registros.Append(aCobranca.Titulos[0].Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "2" : "1");
            //CNPJ Empresa 019-033
            registros.Append(aCobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
            //Codigo Cedente 034-039
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
            //Uso Caixa 040-053
            registros.Append("".FormatStringEsquerda(14, '0'));
            //Agencia 054-058
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito Agencia 059-059
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.Trim());
            //Codigo Cedente 060-065
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
            //Codigo Modelo Personalizado 066-072
            registros.Append("".FormatStringEsquerda(7, '0'));
            //Uso Caixa 073-073
            registros.Append("0");
            //Nome Empresa 074-103
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.ToUpper().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Informaçoes 104-183
            registros.Append("".FormatStringDireita(80, ' '));
            //Numero Arquivo 184-191
            registros.Append(aCobranca.SequencialArq.ToString().FormatStringEsquerda(8, '0'));
            //Data Arquivo 192-199
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyyyy"));
            //Data Credito 200-207
            registros.Append("00000000");
            //Brancos 208-240
            registros.Append("".FormatStringDireita(33, ' '));

            tot_registros++;
            tot_reglote++;
            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            aCobranca.Titulos.ForEach(p =>
            {
                #region Segmento P
                registros = new StringBuilder();
                //Codigo Banco 001-003
                registros.Append(CodigoBanco);
                //Lote Servico 004-007
                registros.Append("0001");
                //Tipo Servico 008-008
                registros.Append("3");
                //Numero Registro Lote 009-013
                registros.Append((tot_reglote++).ToString().FormatStringEsquerda(5, '0'));
                //Segmento 014-014
                registros.Append("P");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo Movimento Remessa 016-017
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Agencia 018-022
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
                //Digito Agencia 023-023
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia.Trim());
                //Codigo Cedente 024-029
                registros.Append(p.Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
                //Uso Caixa 030-040
                registros.Append("".FormatStringEsquerda(11, '0'));
                //Carteira 041-042
                registros.Append(p.Carteira.Trim());//14-Titulo Registrado emissão Cedente
                //Nosso Numero 043-057
                registros.Append(p.Nosso_numero.FormatStringEsquerda(15, '0'));
                //Carteira 058-058
                registros.Append("1");//1-Cobrança Simples 2-Cobrança Caucionada 3-Cobrança Descontada
                //Cadastramento 059-059
                registros.Append(p.Tp_cobranca.Trim().ToUpper().Equals("CR") ? "1" : "2");
                //Tipo Documento 060-060
                registros.Append("2");
                //Emissão Boleto 061-061
                registros.Append("2");//Cliente Emite
                //Distribuição 062-062
                registros.Append("0");//Postagem pelo cedente
                //Numero Documento 063-073
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(11, ' '));
                //Brancos 074-077
                registros.Append("".FormatStringDireita(4, ' '));
                //Vencimento 078-085
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor Nominal 086-100
                registros.Append(p.Vl_documento.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(15, '0'));
                //Agencia Cobrança 101-105
                registros.Append("".FormatStringEsquerda(5, '0'));
                //Digito Agencia 106-106
                registros.Append("0");
                //Especie Titulo 107-108
                registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                //Aceite 109-109
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "A" : "N");
                //Data Emissao 110-117
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyyyy"));
                //Codigo Juros 118-118
                registros.Append(p.Pc_jurodia.Equals(decimal.Zero) ? "3" : p.Tp_jurodia.Trim().ToUpper().Equals("V") ? "1" : "2");//1-Valor por dia 2-Taxa Mensal 3-Isento
                //Data Juros 119-126
                registros.Append(p.Pc_jurodia > decimal.Zero ? p.Dt_vencimento.Value.AddDays(1).ToString("ddMMyyyy") : "00000000");
                //Juros Mora 127-141
                registros.Append(p.Tp_jurodia.Trim().ToUpper().Equals("V") ?
                    Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100), 2).SoNumero().FormatStringEsquerda(15, '0') :
                    (p.Pc_jurodia * 30).SoNumero().FormatStringEsquerda(15, '0'));
                //Codigo Desconto 142-142
                registros.Append(p.Pc_desconto.Equals(decimal.Zero) ? "0" : p.Tp_desconto.Trim().ToUpper().Equals("V") ? "1" : "2");//0-Sem Desconto 1-Valor 2-Percentual
                //Data Desconto 143-150
                registros.Append(p.Dt_vencimento.Value.AddDays(p.Nr_diasdesconto > decimal.Zero ? Convert.ToDouble(p.Nr_diasdesconto) * -1 : -1).ToString("ddMMyyyy"));
                //Valor Desconto 151-165
                registros.Append(p.Pc_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(15, '0'));
                //valor IOF 166-180
                registros.Append("".FormatStringEsquerda(15, '0'));
                //valor abatimento 181-195
                registros.Append("".FormatStringEsquerda(15, '0'));
                //Identificação Titulo 196-220
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(25, ' '));
                //Codigo Protesto 221-221
                registros.Append(p.St_protestarauto ? "1" : "3");//1-Protestar 3-Não protestar
                //Prazo Protesto 222-223
                registros.Append(p.St_protestarauto ? p.Nr_diasprotestar < 2 ? "02" : p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "00");
                //Codigo Baixa 224-224
                registros.Append("1"); //1-Baixar/Devolver 2-Não Baixar/Não Devolver
                //Prazo Baixa 225-227
                registros.Append("120");
                //Codigo Moeda 228-229
                registros.Append("09");
                //Uso Caixa 230-239
                registros.Append("".FormatStringEsquerda(10, '0'));
                //Brancos 240-240
                registros.Append(" ");

                tot_registros++;

                Remessa.AppendLine(registros.ToString());
                #endregion

                #region Segmento Q
                registros = new StringBuilder();
                //Codigo Banco 001-003
                registros.Append(CodigoBanco);
                //Lote Serviço 004-007
                registros.Append("0001");
                //Tipo Registro 008-008
                registros.Append("3");
                //Sequencial Registro Lote 009-013
                registros.Append((tot_reglote++).ToString().FormatStringEsquerda(5, '0'));
                //Segmento 014-014
                registros.Append("Q");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo Remessa 016-017
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Tipo Inscrição 018-018
                registros.Append(p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaJuridica ? "2" : p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "0");
                //CNPJ CPF Sacado 019-033
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome Sacado 034-073
                registros.Append(p.Sacado.Nome.Trim().RemoverCaracteres().FormatStringDireita(40, ' '));
                //Endereco Sacado 074-113
                registros.Append((p.Sacado.Endereco.Rua.Trim().RemoverCaracteres() + "," + p.Sacado.Endereco.Numero.Trim().RemoverCaracteres()).FormatStringDireita(40, ' '));
                //Bairro Sacado 114-128
                registros.Append(p.Sacado.Endereco.Bairro.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                //CEP Sacado 129-136
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, ' '));
                //Cidade Sacado 137-151
                registros.Append(p.Sacado.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                //UF Sacado 152-153
                registros.Append(p.Sacado.Endereco.Estado.Trim().RemoverCaracteres().FormatStringDireita(2, ' '));
                //Tipo Insc. Avalista 154-154
                registros.Append(p.Avalista.TipoInscricao == TTipoInscricao.tiPessoaJuridica ? "2" : p.Avalista.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "0");
                //Inscrição Avalista 155-169
                registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome Avalista 170-209
                registros.Append(p.Avalista.Nome.Trim().RemoverCaracteres().FormatStringDireita(40, ' '));
                //Banco Correspondente 210-212
                registros.Append("   ");
                //Nosso Num. Correspondente 213-232
                registros.Append("".FormatStringDireita(20, ' '));
                //Brancos 233-240
                registros.Append("".FormatStringDireita(8, ' '));

                tot_registros++;

                Remessa.AppendLine(registros.ToString());
                #endregion
            });
            #endregion

            #region Registro Trailer Lote
            registros = new StringBuilder();
            //Banco 001-003
            registros.Append(CodigoBanco);
            //Lote Servico 004-007
            registros.Append("0001");
            //Tipo Registro 008-008
            registros.Append("5");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Qtd Registros Lote 018-023
            registros.Append((++tot_reglote).ToString().FormatStringEsquerda(6, '0'));
            //Qtd Titulos Simples 024-029
            registros.Append(aCobranca.Titulos.Count.ToString().FormatStringEsquerda(6, '0'));
            //Vl titulos simples 030-046
            registros.Append(aCobranca.Titulos.Sum(p => p.Vl_documento).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(17, '0'));
            //Qtd Titulos Caucionado 047-052
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Vl Titulos Caucionado 053-069
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Qtd Titulos Descontados 070-075
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Vl Titulos Descontados 076-092
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Brancos 093-240
            registros.Append("".FormatStringDireita(148, ' '));

            tot_registros++;
            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Trailer Arquivo
            registros = new StringBuilder();
            //Codigo Banco 001-003
            registros.Append(CodigoBanco.Trim());
            //Lote Servico 004-007
            registros.Append("9999");
            //Tipo Registro 008-008
            registros.Append("9");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Qtde Lotes 018-023
            registros.Append("1".FormatStringEsquerda(6, '0'));
            //Qtde Registros 024-029
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));
            //Brancos 030-240
            registros.Append("".FormatStringDireita(211, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }
        
        private void GerarRemessaCNAB400(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;

            #region Registro Header
            //Codigo do registro 001-001
            registros.Append("0");
            //Codigo da remessa 002-002
            registros.Append("1");
            //Literal REMESSA 003-009
            registros.Append("REMESSA".FormatStringDireita(7, ' '));//Se for homologação<REM.TST>, senão REMESSA
            //Codigo servico cobranca 010-011
            registros.Append("01");
            //Literal servico 012-026
            registros.Append("COBRANCA".FormatStringDireita(15, ' '));
            //Codigo agencia 027-030
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Codigo cedente 031-036
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
            //Uso exclusivo caixa 037-046
            registros.Append("".FormatStringDireita(10, ' '));
            //Nome empresa 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.ToUpper().Trim().FormatStringDireita(30, ' '));
            //Codigo banco 077-079
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.Banco.Codigo.FormatStringEsquerda(3, '0'));
            //Nome banco 080-094
            registros.Append("C ECON FEDERAL ");
            //Data remessa 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Uso exclusivo caixa 101-389
            registros.Append("".FormatStringDireita(289, ' '));
            //Brancos 390-394
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(5, '0'));
            //Sequencial do registro
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            aCobranca.Titulos.ForEach(p =>
            {
                #region Detalhe do titulo
                registros = new StringBuilder();
                //Identificao registro 001-001
                registros.Append("1");
                //Tipo Inscrição Empresa 002-003
                registros.Append("02");//01-CPF 02-CNPJ
                //Numero Inscrição Empresa 004-017
                registros.Append(p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Agencia 018-021
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Codigo Cedente 022-027
                registros.Append(p.Cedente.CodigoCedente.FormatStringEsquerda(6, '0'));
                //Identificação Emissao Boleto 028-028
                registros.Append("2");//1-Banco Emite 2-Cliente Emite
                //Identificação entrega/distribuição do bloqueto 029-029
                registros.Append("0");//0-Postagem pelo beneficiario 1-pagador via correio 2-beneficiario via agencia caixa 3-pagador via e-mail
                //Taxa permanencia 030-031
                registros.Append("00");//Acata comissão por dia
                //Identificação titulo na Empresa 032-056
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(25, ' '));
                //Modalidade Identificação 057-058
                registros.Append(p.Tp_cobranca.Trim().ToUpper().Equals("CR") ? "14" : "24");//14-Com Registro 24-Sem Registro
                //Nosso Numero 059-073
                registros.Append(p.Nosso_numero.FormatStringEsquerda(15, '0'));
                //Campos brancos 074-076
                registros.Append("".FormatStringDireita(3, ' '));
                //Mensagem ser impressa no boleto 077-106
                registros.Append("".FormatStringDireita(30, ' '));
                //Carteira 107-108
                registros.Append(p.Carteira.FormatStringEsquerda(2, '0'));//01-Cobranca com registro 02-Cobranca sem registro
                //Identificacao tipo ocorrencia 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Numero documento cobranca(seu numero)111-120
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(10, ' '));
                //Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor Nominal 127-139
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Codigo do banco 140-142
                registros.Append(p.Cedente.ContaBancaria.Banco.Codigo.FormatStringEsquerda(3, '0'));
                //Agencia encarregada cobranca 143-147
                registros.Append("00000");
                //Especie do titulo 148-149
                registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                //Identificacao titulo Aceite/Não Aceite 150-150
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "A" : "N");
                //Data Emissao 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Primeira instrução cobranca 157-158
                registros.Append(p.St_protestadobool ? "01" : "02");//01-Protestar dias corridos 02-Devolver(nao protestar)
                //Segunda instrução cobrança 159-160
                registros.Append("00");
                //Juros mora por dia/valor 161-173
                registros.Append(Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100), 2).SoNumero().FormatStringEsquerda(13, '0'));
                //Data limite concessão desconto 174-179
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                //Valor desconto 180-192
                registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Valor IOF 193-205
                registros.Append(decimal.Zero.ToString().FormatStringDireita(13, '0'));
                //Valor abatimento 206-218
                registros.Append(decimal.Zero.ToString().FormatStringDireita(13, '0'));
                //Identificador do tipo inscrição pagador 219-220
                registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "02" : "01");
                //CNPJ/CPF do Pagador 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome do Pagador 235-274
                registros.Append(p.Sacado.Nome.ToUpper().Trim().FormatStringDireita(40, ' '));
                //Endereco do Pagador 275-314
                registros.Append((p.Sacado.Endereco.Rua.Trim() + ", " + p.Sacado.Endereco.Numero).Trim().FormatStringDireita(40, ' '));
                //Bairro do Pagador 315-326
                registros.Append(p.Sacado.Endereco.Bairro.Trim().FormatStringDireita(12, ' '));
                //CEP Pagador 327-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                //Cidade do Pagador 335-349
                registros.Append(p.Sacado.Endereco.Cidade.Trim().FormatStringDireita(15, ' '));
                //UF do Pagador 350-351
                registros.Append(p.Sacado.Endereco.Estado.Trim().FormatStringDireita(2, ' '));
                //Data pagamento multa 352-357
                registros.Append(p.Pc_multa > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasmulta)).ToString("ddMMyy") : "000000");
                //Valor da multa 358-367
                registros.Append((p.Tp_multa.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_multa), 100) : p.Pc_multa).ToString().SoNumero().FormatStringEsquerda(10, '0'));
                //Nome Sacador Avalista 368-389
                registros.Append(p.Avalista.Nome.Trim().FormatStringDireita(22, ' '));
                //Terceira Instrução Cobranca 390-391
                registros.Append("00");
                //Numero Dias Protesto 392-393
                registros.Append(p.St_protestadobool ? p.Nr_diasprotestar < 2 ? "02" : p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "15");
                //Codigo Moeda 394-394
                registros.Append("1");
                //sequencial do registro 395-400
                registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                Remessa.AppendLine(registros.ToString());
                #endregion
            });
            #endregion

            #region Trailer
            registros = new StringBuilder();
            //Identificacao registro 001-001
            registros.Append("9");
            //Identificacao remessa 002-394
            registros.Append(string.Empty.FormatStringDireita(393, ' '));
            //Sequencial registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }

        private bool LerRetornoCNAB240( blCobranca ACobranca, string[] Retorno)
        {
            int NumeroRegistro = 0;
            blTitulo ATitulo = null;
            try
            {
               if (Retorno[NumeroRegistro].Substring(0, 3) != CodigoBanco)
                   throw new Exception("Este não é um retorno de cobrança do banco "+CodigoBanco+" "+NomeBanco);

               if  (Retorno[NumeroRegistro].ToString().Substring(7,1) != "0")
                   throw new Exception("Este não é um registro HEADER válido para arquivo de retorno de cobrança com layout CNAB240");

               NumeroRegistro = 1;

               //{Lê registro HEADER DE LOTE}
               //{Verifica se é um lote de retorno de cobrança}

               if (Retorno[NumeroRegistro].Substring(8,3) != "T01" &&
                   Retorno[NumeroRegistro].Substring(8,3) != "T02")
                   throw new Exception("Este não é um lote de retorno de cobrança");

               if (Retorno[NumeroRegistro].Substring(191, 8).PadLeft(8, '0') != "00000000")
                   ACobranca.DataArquivo = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(195, 4)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(193, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(191, 2)));
               else
                   ACobranca.DataArquivo = DateTime.Now;

               if (Retorno[NumeroRegistro].Substring(183,8).PadLeft(8,'0') != "00000000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(183,8));
               else
                    ACobranca.SequencialArq = 0;

               //{Lê os registros DETALHE}

               NumeroRegistro++;
               //{Lê até o antepenúltimo registro porque o penúltimo contém apenas o TRAILER DO LOTE e o último contém apenas o TRAILER DO ARQUIVO}

               while (NumeroRegistro < (Retorno.Length - 2))
               {                        
                   //{Registro detalhe com tipo de segmento = T}
                    if (Retorno[NumeroRegistro].Substring(13,1).Equals("T"))
                    {
                       //{Dados do titulo}
                        ATitulo = new blTitulo();
                        //Codigo Banco
                        ATitulo.Cedente.ContaBancaria.Banco.Codigo = Retorno[NumeroRegistro].Substring(0, 3);
                        //Codigo Cedente
                        ATitulo.Cedente.CodigoCedente = Retorno[NumeroRegistro].Substring(23, 6);
                        //Nosso Numero
                        ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(39, 17);
                        //Numero Documento
                        ATitulo.NumeroDocumento = Retorno[NumeroRegistro].Substring(58, 11);
                        //Data de vencimento
                        if (Retorno[NumeroRegistro].Substring(73, 8) != "00000000")
                            ATitulo.Dt_vencimento = DateTime.Parse(Retorno[NumeroRegistro].Substring(73, 2) + "/" +
                                                                   Retorno[NumeroRegistro].Substring(75, 2) + "/" +
                                                                   Retorno[NumeroRegistro].Substring(77, 4));
                        else
                            ATitulo.Dt_vencimento = DateTime.Now;
                        //Valor Tarifas
                        if (Retorno[NumeroRegistro].Substring(198, 15).PadLeft(15, '0') != "000000000000000")
                            ATitulo.Vl_despesa_cobranca = decimal.Divide(Convert.ToDecimal(Retorno[NumeroRegistro].Substring(198, 15)), 100);
                        else ATitulo.Vl_despesa_cobranca = decimal.Zero;
                        //Ocorrencia
                        ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(15,2);
                        //Descrição Ocorrencia
                        ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia);
                        //Motivo Ocorrencia
                        string codigo = Retorno[NumeroRegistro].Substring(213, 10);
                        if (codigo.Substring(0, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(0, 2)) + "|";
                        if (codigo.Substring(2, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(2, 2)) + "|";
                        if (codigo.Substring(4, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(4, 2)) + "|";
                        if (codigo.Substring(6, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(6, 2)) + "|";
                        if (codigo.Substring(8, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(8, 2));
                        if (!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                            if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                                ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                       NumeroRegistro ++;
                    }
                   
                    //{Registro detalhe com tipo de segmento = U}
                    if (Retorno[NumeroRegistro].Substring(13,1) == "U")
                    {
                        //Valor do Titulo
                        if (Retorno[NumeroRegistro].Substring(77, 15).PadLeft(15, '0') != "000000000000000")
                            ATitulo.Vl_documento = (Convert.ToDecimal(Retorno[NumeroRegistro].Substring(77, 15))) / 100;
                        else ATitulo.Vl_documento = decimal.Zero;
                        //Acrescimos
                       if ( Retorno[NumeroRegistro].Substring(17,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.Vl_morajuros =  Convert.ToDecimal(Retorno[NumeroRegistro].Substring(17,15))/100;
                       else
                           ATitulo.Vl_morajuros = decimal.Zero;
                        //Descontos
                       if ( Retorno[NumeroRegistro].Substring(32,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.Vl_desconto = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(32,15))/100;
                       else
                           ATitulo.Vl_desconto = decimal.Zero;
                        //Abatimento
                       if (Retorno[NumeroRegistro].Substring(47,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.Vl_abatimento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(47,15)) / 100;
                       else
                           ATitulo.Vl_abatimento = decimal.Zero;
                        //IOF
                       if ( Retorno[NumeroRegistro].Substring(62,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.Vl_iof = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(62,15))/100;
                       else
                           ATitulo.Vl_iof = decimal.Zero;
                        //Outras Despesas
                       if ( Retorno[NumeroRegistro].Substring(107,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.Vl_outras_despesas =  Convert.ToDecimal(Retorno[NumeroRegistro].Substring(107,15)) / 100;
                       else
                           ATitulo.Vl_outras_despesas = decimal.Zero;
                        //Outros Creditos
                       if ( Retorno[NumeroRegistro].Substring(122,15).PadLeft(15,'0') != "000000000000000")
                           ATitulo.vl_outros_creditos = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(122,15)) / 100;
                       else
                           ATitulo.vl_outros_creditos = decimal.Zero;
                        //Data Ocorrencia
                       if ( Retorno[NumeroRegistro].Substring(137,8).PadLeft(8,'0') != "00000000")
                       {
                            ATitulo.Dt_ocorrencia = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(141,4)),
                                                                 Convert.ToInt32(Retorno[NumeroRegistro].Substring(139,2)),
                                                                 Convert.ToInt32(Retorno[NumeroRegistro].Substring(137,2)));
                       }
                       else
                          ATitulo.Dt_ocorrencia = DateTime.Now;
                       //Data Credito
                       if ( Retorno[NumeroRegistro].Substring(145,8).PadLeft(8,'0') != "00000000")
                       {
                           ATitulo.Dt_credito = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(149, 4)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(147, 2)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(145, 2)));
                       }
                       else
                         ATitulo.Dt_credito = DateTime.Now;
                       //Data Debito Tarifa
                       if (Retorno[NumeroRegistro].Substring(157, 8).PadLeft(8, '0') != "00000000")
                       {
                           ATitulo.Dt_creditotaxa = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(161, 4)),
                                                                 Convert.ToInt32(Retorno[NumeroRegistro].Substring(159, 2)),
                                                                 Convert.ToInt32(Retorno[NumeroRegistro].Substring(157, 2)));
                       }
                       else
                           ATitulo.Dt_credito = DateTime.Now; 

                       NumeroRegistro ++;
                    } 
                    //{Insere o título}
                    ACobranca.Titulos.Add(ATitulo);
               }
               return true;
            }
            catch(Exception ex)
            {
               throw new Exception(ex.Message);
            }            
        }
        
        private bool LerRetornoCNAB400( blCobranca ACobranca, string[] Retorno)
        {
            string ACodigoBanco;
            string ACodigoCedente;
            int NumeroRegistro = 0;
            blTitulo ATitulo = null;
            try
            {
                //{ Lê registro HEADER}
                ACodigoBanco = Retorno[NumeroRegistro].Substring(76, 3);
                if (ACodigoBanco != CodigoBanco)
                    throw new Exception("Este não é um retorno de cobrança do banco " + CodigoBanco + " " + NomeBanco);
                //Buscar codigo cedente
                ACodigoCedente = Retorno[NumeroRegistro].Substring(30, 6);

                if (Retorno[NumeroRegistro].Substring(94, 6).PadLeft(6, '0') != "000000")
                    ACobranca.DataArquivo = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(98, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(96, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(94, 2)));
                else
                    ACobranca.DataArquivo = DateTime.Now;

                if (Retorno[NumeroRegistro].Substring(389, 5).PadLeft(5, '0') != "00000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(389, 5));
                else
                    ACobranca.SequencialArq = 0;

                //{Lê os registros DETALHE}
                //{Processa até o penúltimo registro porque o último contém apenas o TRAILLER}
                for (NumeroRegistro = 1; NumeroRegistro <= (Retorno.Length - 2); NumeroRegistro++)
                {
                    //{Confirmar se o tipo do registro é 1}
                    if (Retorno[NumeroRegistro].Substring(0, 1) != "1")
                        continue; //{Não processa o registro atual}
                    //Tipo de cobranca
                    string tp_cobranca = Retorno[NumeroRegistro].Substring(13, 1);
                    if (Retorno[NumeroRegistro].Substring(108, 2).Equals("28")) //Tarifa de cobranca
                    {
                        if (Retorno[NumeroRegistro].Substring(318, 2).Equals("B3")) //Tarifa de entrada de titulo
                        {
                            blTitulo rTitulo = ACobranca.Titulos.Find(p => p.Nosso_numero.Trim().Equals(Retorno[NumeroRegistro].Substring(47, 9)));
                            if (rTitulo != null)
                            {
                                rTitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(175, 13)) / 100;
                                if (Retorno[NumeroRegistro].Substring(328, 8).PadLeft(8, '0') != "00000000")
                                    rTitulo.Dt_creditotaxa = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(328, 4)),
                                                                          Convert.ToInt32(Retorno[NumeroRegistro].Substring(332, 2)),
                                                                          Convert.ToInt32(Retorno[NumeroRegistro].Substring(334, 2)));
                                else
                                    rTitulo.Dt_creditotaxa = DateTime.Now;
                            }
                        }
                    }
                    else
                    {
                        ATitulo = new blTitulo();
                        ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                        ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                        //Nosso numero
                        ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(56, 17);
                        //Ocorrencia
                        ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(108, 2);
                        //Descricao ocorrencia
                        ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia);
                        //Data ocorrencia
                        if (Retorno[NumeroRegistro].Substring(110, 6).PadLeft(6, '0') != "000000")
                            if (Convert.ToInt32((Retorno[NumeroRegistro].Substring(114, 2))) <= 69)
                            {
                                ATitulo.Dt_ocorrencia = new DateTime(Convert.ToInt32("20" + Retorno[NumeroRegistro].Substring(114, 2)),
                                                                     Convert.ToInt32(Retorno[NumeroRegistro].Substring(112, 2)),
                                                                     Convert.ToInt32(Retorno[NumeroRegistro].Substring(110, 2)));
                            }
                            else
                                ATitulo.Dt_ocorrencia = new DateTime(Convert.ToInt32("19" + Retorno[NumeroRegistro].Substring(114, 2)),
                                                                       Convert.ToInt32(Retorno[NumeroRegistro].Substring(112, 2)),
                                                                       Convert.ToInt32(Retorno[NumeroRegistro].Substring(110, 2)));
                        else
                            ATitulo.Dt_ocorrencia = DateTime.Now;
                        //Valor titulo
                        if (Retorno[NumeroRegistro].Substring(152, 13).PadLeft(13, '0') != "0000000000000")
                            ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(152, 13)) / 100;
                        else
                            ATitulo.Vl_documento = decimal.Zero;
                        //if (tp_cobranca.Trim().ToUpper().Equals("A"))//Registro
                        //{
                        //    //Valor despesas
                        //    if (Retorno[NumeroRegistro].Substring(175, 13).PadLeft(13, '0') != "0000000000000")
                        //        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(175, 13)) / 100;
                        //    else
                        //        ATitulo.Vl_despesa_cobranca = decimal.Zero;
                        //}
                        //Abatimento
                        if (Retorno[NumeroRegistro].Substring(227, 13).PadLeft(13, '0') != "0000000000000")
                            ATitulo.Vl_abatimento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(227, 13)) / 100;
                        else
                            ATitulo.Vl_abatimento = decimal.Zero;
                        //Desconto
                        if (Retorno[NumeroRegistro].Substring(240, 13).PadLeft(13, '0') != "0000000000000")
                            ATitulo.Vl_desconto = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(240, 13)) / 100;
                        else
                            ATitulo.Vl_desconto = decimal.Zero;
                        //Juro
                        if (Retorno[NumeroRegistro].Substring(266, 13).PadLeft(13, '0') != "0000000000000")
                            ATitulo.Vl_morajuros = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(266, 13)) / 100;
                        else
                            ATitulo.Vl_morajuros = decimal.Zero;
                        //Motivo ocorrencia
                        string codigo = Retorno[NumeroRegistro].Substring(79, 3);
                        if (codigo.Substring(0, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(0, 2)) + "|";
                        if (codigo.Substring(2, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(2, 2)) + "|";
                        if (codigo.Substring(4, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(4, 2)) + "|";
                        if (codigo.Substring(6, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(6, 2)) + "|";
                        if (codigo.Substring(8, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(8, 2));
                        if (!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                            if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                                ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                        //Data credito
                        if (Retorno[NumeroRegistro].Substring(293, 6).Trim().PadLeft(6, '0') != "000000")
                            if (Convert.ToInt32((Retorno[NumeroRegistro].Substring(297, 2))) <= 69)
                            {
                                ATitulo.Dt_credito = new DateTime(Convert.ToInt32("20" + Retorno[NumeroRegistro].Substring(297, 2)),
                                                                     Convert.ToInt32(Retorno[NumeroRegistro].Substring(295, 2)),
                                                                     Convert.ToInt32(Retorno[NumeroRegistro].Substring(293, 2)));
                            }
                            else
                                ATitulo.Dt_credito = new DateTime(Convert.ToInt32("19" + Retorno[NumeroRegistro].Substring(297, 2)),
                                                                       Convert.ToInt32(Retorno[NumeroRegistro].Substring(295, 2)),
                                                                       Convert.ToInt32(Retorno[NumeroRegistro].Substring(293, 2)));
                        else
                            ATitulo.Dt_credito = DateTime.Now;
                        //Inserir titulo na lista
                        ACobranca.Titulos.Add(ATitulo);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public bool LerRetorno(blCobranca ACobranca, string[] arq)  //{Lê o arquivo retorno recebido do banco}
        {
            try
            {
                if (arq.Length <= 0)
                    throw new Exception("O retorno está vazio. Não há dados para processar");

                switch (ACobranca.LayoutArquivo)
                {

                    case TLayoutArquivo.laCNAB240:
                            return LerRetornoCNAB240(ACobranca, arq);
                    case TLayoutArquivo.laCNAB400:
                            return LerRetornoCNAB400(ACobranca, arq);
                    default:
                            throw new Exception("Tamanho de registro inválido: " + arq[0].Length);                            
                }
            }
            catch(Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }            
        }

        public void GerarRemessa(blCobranca ACobranca, string Path_remessa)  //{Gerar arquivo remessa para enviar ao banco}
        {
            StringBuilder Remessa = new StringBuilder();
            switch (ACobranca.LayoutArquivo)
            {
                case TLayoutArquivo.laCNAB240:
                    {
                        GerarRemessaCNAB240(ACobranca, Remessa);
                        break;
                    }
                case TLayoutArquivo.laCNAB400:
                    {
                        GerarRemessaCNAB400(ACobranca, Remessa);
                        break;
                    }
            }
            //Salvar arquivo de remessa na pasta configurada
            if (!System.IO.Directory.Exists(Path_remessa))
                throw new Exception("Path salvar arquivo remessa invalido.");
            if (Path_remessa.Substring(Path_remessa.Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                Path_remessa += System.IO.Path.DirectorySeparatorChar.ToString();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path_remessa +
                                                                          "E" +
                                                                          ACobranca.DataArquivo.Day.FormatStringEsquerda(2, '0') +
                                                                          ACobranca.SequencialArq.ToString().FormatStringEsquerda(6, '0') +
                                                                          ".REM"))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
