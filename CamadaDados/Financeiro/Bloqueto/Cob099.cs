using System;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco099
    {
        const string CodigoBanco = "099";
        const string NomeBanco = "UNIPRIME";

        public string GetNomeBanco()
        {
            return NomeBanco;
        }

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantialIndicacao: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edNotaSeguro: return "03";
                case TEspecieDocumento.edCosseguros: return "04";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edLetraCambio: return "10";
                case TEspecieDocumento.edNotaDebito: return "11";
                case TEspecieDocumento.edDuplicataServicoIndicacao: return "12";
                default: return "99";
            }
        }

        public string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "02": return "ENTRADA CONFIRMADA";
                case "03": return "ENTRADA REJEITADA";
                case "06": return "LIQUIDAÇÃO NORMAL";
                case "09": return "BAIXA AUTOMATICA VIA ARQUIVO";
                case "10": return "BAIXADO CONFORME INSTRUÇÕES AGÊNCIA";
                case "11": return "EM SER - ARQUIVO DE TITULOS PENDENTES";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "VENCIMENTO ALTERADO";
                case "15": return "LIQUIDAÇÃO EM CARTÓRIO";
                case "16": return "TITULO PAGO EM CHEQUE";
                case "17": return "LIQUIDAÇÃO APÓS BAIXA OU TITULO NÃO REGISTRADO";
                case "18": return "ACERTO DE DEPOSITARIA";
                case "19": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE SUSTAÇÃO DE PROTESTO";
                case "21": return "ACERTO DE CONTROLE DO PARTICIPANTE";
                case "23": return "ENTRADA DE TITULO EM CARTORIO";
                case "24": return "ENTRADA REJEITADA POR CEP IRREGULAR";
                case "27": return "BAIXA REJEITADA";
                case "28": return "DEBITO DE TARIFAS/CUSTAS";
                case "30": return "AUTERAÇÃO DE OUTROS DADOS REJEITADOS";
                case "32": return "INSTRUÇÃO REJEITADA";
                case "33": return "CONFIRMAÇÃO PEDIDO ALTERAÇÃO OUTROS DADOS";
                case "34": return "RETIRADO DE CARTÓRIO E MANUTENÇÃO CARTEIRA";
                case "35": return "DESAGENDAMENTO DO DEBITO AUTOMATICO";
                case "68": return "ACERTO DOS DADOS DO RATEIO DE CRÉDITO";
                case "69": return "CANCELAMENTO DOS DADOS DO RATEIO";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string ocorrencia, string codigo)
        {
            if (ocorrencia.Trim().ToUpper().Equals("02"))
                switch (codigo)
                {
                    case "00": return "OCORRENCIA ACEITA";
                    case "01": return "CODIGO DO BANCO INVALIDO";
                    case "17": return "DATA DE VENCIMENTO ANTERIOR A DATA DE EMISSÃO";
                    case "21": return "ESPECIE DO TITULO INVALIDO";
                    case "24": return "DATA DA EMISSÃO INVALIDA";
                    case "38": return "PRAZO PARA PROTESTO INVALIDO";
                    case "39": return "PEDIDO PARA PROTESTO NÃO PERMITIDO PARA TITULO";
                    case "43": return "PRAZO PARA BAIXA E DEVOLUÇÃO INVALIDO";
                    case "45": return "NOME DO SACADO INVALIDO";
                    case "46": return "TIPO INSCRIÇÃO DO SACADO INVALIDO";
                    case "47": return "ENDEREÇO DO SACADO NÃO INFORMADO";
                    case "48": return "CEP IRREGULAR";
                    case "50": return "CEP REFERENTE A BANCO CORRESPONDENTE";
                    case "53": return "Nº INSCRIÇÃO DO SACADOR/AVALISTA INVALIDO";
                    case "54": return "SACADOR/AVALISTA NÃO INFORMADO";
                    case "67": return "DEBITO AUTOMATICO AGENDADO";
                    case "68": return "DEBITO NÃO AGENDADO - ERRO NOS DADOS DE REMESSA";
                    case "69": return "DEBITO NÃO AGENDADO - SACADO NÃO CONSTA NO CADASTRO DE AUTORIZANTE";
                    case "70": return "DEBITO NÃO AGENDADO - CEDENTE NÃO AUTORIZADO PELO SACADO";
                    case "71": return "DEBITO NÃO AGENDADO - CEDENTE NÃO PARTICIPA DA MODALIDADE DE DÉB. AUTOMATICO";
                    case "72": return "DEBITO NÃO AGENDADO - CODIGO DE MOEDA DIFERENTE DE R$";
                    case "73": return "DEBITO NÃO AGENDADO - DATA DE VENCIMENTO INVALIDA";
                    case "75": return "DEBITO NÃO AGENDADO - TIPO DO NUMERO DE INSCRIÇÃO DO SACADO DEBITADO INVALIDO";
                    case "86": return "SEU NUMERO DO DOCUMENTO INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("03"))
                switch (codigo)
                {
                    case "02": return "CODIGO DO REGISTRO DETALHE INVALIDO";
                    case "03": return "CODIGO DA OCORRENCIA INVALIDA";
                    case "04": return "CODIGO DA OCORRENCIA NÃO PERMITIDA PARA A CARTEIRA";
                    case "05": return "CODIGO DE OCORRENCIA NÃO NUMERICO";
                    case "07": return "AGENCIA/CONTA/DIGITO INVALIDO";
                    case "08": return "NOSSO NUMERO INVALIDO";
                    case "09": return "NOSSO NUMERO DUPLICADO";
                    case "10": return "CARTEIRA INVALIDA";
                    case "16": return "DATA DE VENCIMENTO INVALIDA";
                    case "18": return "VENCIMENTO FORA DO PRAZO DE OPERAÇÃO";
                    case "20": return "VALOR DO TITULO INVALIDO";
                    case "21": return "ESPECIE DO TITULO INVALIDA";
                    case "22": return "ESPECIE NÃO PERMITIDA PARA A CARTEIRA";
                    case "24": return "DATA DE EMISSÃO INVALIDA";
                    case "38": return "PRAZO PARA PROTESTO INVALIDO";
                    case "44": return "AGENCIA DO CEDENTE NÃO PREVISTA";
                    case "50": return "CEP IRREGULAR - BANCO CORRESPONDENTE";
                    case "63": return "ENTRADA PARA TITULO JA CADASTRADO";
                    case "68": return "DEBITO NÃO AGENDADO - ERRO NOS DADOS DE REMESSA";
                    case "69": return "DEBITO NÃO AGENDADO - SACADO NÃO CONSTA NO CADASTRO DE AUTORIZANTE";
                    case "70": return "DEBITO NÃO AGENDADO - CEDENTE NÃO AUTORIZADO PELO SACADO";
                    case "71": return "DEBITO NÃO AGENDADO - CEDENTE NÃO PARTICIPA DO DEBITO AUTOMATICO";
                    case "72": return "DEBITO NÃO AGENDADO - CODIGO DE MOEDA DIFERENTE DE R$";
                    case "73": return "DEBITO NÃO AGENDADO - DATA DE VENCIMENTO INVALIDA";
                    case "74": return "DEBITO NÃO AGENDADO - CONFORME SEU PEDIDO, TITULO NÃO REGISTRADO";
                    case "75": return "DEBITO NÃO AGENDADO - TIPO DE NUMERO DE INSCRIÇÃO DO DEBITADO INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("06"))
                switch (codigo)
                {
                    case "00": return "TITULO PAGO COM DINHEIRO";
                    case "15": return "TITULO PAGO COM CHEQUE";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("09"))
                switch (codigo)
                {
                    case "10": return "BAIXA COMANDADA PELO CLIENTE";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("10"))
                switch (codigo)
                {
                    case "00": return "BAIXADO CONFORME INSTRUÇÕES DA AGENCIA";
                    case "14": return "TITUTLO PROTESTADO";
                    case "15": return "TITULO EXCLUIDO";
                    case "16": return "TITULO BAIXADO PELO BANCO POR DECURSO PRAZO";
                    case "20": return "TITULO BAIXADO E TRANSFERIDO PARA DESCONTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("15"))
                switch (codigo)
                {
                    case "00": return "TITULO PAGO COM DINHEIRO";
                    case "15": return "TITULO PAGO COM CHEQUE";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("17"))
                switch (codigo)
                {
                    case "00": return "TITULO PAGO COM DINHEIRO";
                    case "15": return "TITULO PAGO COM CHEQUE";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("24"))
                switch (codigo)
                {
                    case "48": return "CEP INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("27"))
                switch (codigo)
                {
                    case "04": return "CODIGO DE OCORRENCIA NÃO PERMITIDO PARA A CARTEIRA";
                    case "07": return "AGENCIA/CONTA/DIGITO INVALIDOS";
                    case "08": return "NOSSO NUMERO INVALIDO";
                    case "10": return "CARTEIRA INVALIDA";
                    case "15": return "CARTEIRA/AGENCIA/CONTA/NOSSO NUMERO INVALIDOS";
                    case "40": return "TITULO COM ORDEM DE PROTESTO EMITIDO";
                    case "42": return "CODIGO PARA BAIXA/DEVOLUÇÃO VIA TELEBRADESCO INVALIDO";
                    case "60": return "MOVIMENTO PARA TITULO NÃO CADASTRADO";
                    case "77": return "TRANSFERENCIA PARA DESCONTO NÃO PERMITIDO PARA A CARTEIRA";
                    case "85": return "TITULO COM PAGAMENTO VINCULADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("28"))
                switch (codigo)
                {
                    case "03": return "TARIFA DE SUSTAÇÃO";
                    case "04": return "TARIFA DE PROTESTO";
                    case "08": return "CUSTAS DE PROTESTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("30"))
                switch (codigo)
                {
                    case "01": return "CODIGO DO BANCO INVALIDO";
                    case "04": return "CODIGO DE OCORRENCIA NÃO PERMITIDO PARA A CARTEIRA";
                    case "05": return "CODIGO DA OCORRENCIA NÃO NUMERICO";
                    case "08": return "NOSSO NUMERO INVALIDO";
                    case "15": return "CARACTERISTICA DA COBRANÇA IMCOPATIVEL";
                    case "16": return "DATA DE VENCIMENTO INVALIDA";
                    case "17": return "DATA DE VENCIMENTO ANTERIOR A DATA DE EMISSÃO";
                    case "18": return "VENCIMENTO FORA DO PRAZO DE OPERAÇÃO";
                    case "24": return "DATA DE EMISSÃO INVALIDA";
                    case "29": return "VALOR DO DESCONTO MAIOR/IGUAL AO VALOR DO TITULO";
                    case "30": return "DESCONTO A CONCEDER NÃO CONFERE";
                    case "31": return "CONCESSÃO DE DESCONTO JA EXISTENTE";
                    case "33": return "VALOR DO ABATIMENTO INVALIDO";
                    case "34": return "VALOR DO ABATIMENTO MAIOR/IGUAL AO VALOR DO TITULO";
                    case "38": return "PRAZO PARA PROTESTO INVALIDO";
                    case "39": return "PEDIDO DE PROTESTO NÃO PERMITIDO PARA O TITULO";
                    case "40": return "TITULO COM ORDEM DE PROTESTO EMITIDO";
                    case "42": return "CODIGO PARA BAIXA/DEVOLUÇÃO INVALIDO";
                    case "60": return "MOVIMENTO PARA TITULO NÃO CADASTRADO";
                    case "85": return "TITULO COM PAGAMENTO VINCULADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("32"))
                switch (codigo)
                {
                    case "01": return "CODIGO DO BANCO INVALIDO";
                    case "02": return "CODIGO DO REGISTRO DETALHE INVALIDO";
                    case "04": return "CODIGO DE OCORRENCIA NÃO PERMITIDO PARA A CARTEIRA";
                    case "05": return "CODIGO DE OCORRENCIA NÃO NUMERICO";
                    case "07": return "AGENCIA/CONTA/DIGITO INVALIDOS";
                    case "08": return "NOSSO NUMERO INVALIDO";
                    case "10": return "CARTEIRA INVALIDA";
                    case "15": return "CARACTERISTICAS DA COBRANÇA INCOMPATIVEIS";
                    case "16": return "DATA DE VENCIMENTO INVALIDA";
                    case "17": return "DATA DE VENCIMENTO ANTERIOR A DATA DE EMISSÃO";
                    case "18": return "VENCIMENTO FORA DO PRAZO DE OPERAÇÃO";
                    case "20": return "VALOR DO TITULO INVALIDO";
                    case "21": return "ESPECIE DO TITULO INVALIDA";
                    case "22": return "ESPECIE NÃO PERMITIDA PARA A CARTEIRA";
                    case "24": return "DATA DE EMISSÃO INVALIDA";
                    case "28": return "CODIGO DE DESCONTO VIA TELEBRADESCO INVALIDO";
                    case "29": return "VALOR DO DESCONTO MAIOR/IGUAL AO VALOR DO TITULO";
                    case "30": return "DESCONTO A CONCEDER NÃO CONFERE";
                    case "31": return "CONCESSÃO DE DESCONTO - JA EXISTE DESCONTO ANTERIOR";
                    case "33": return "VALOR DO ABATIMENTO INVALIDO";
                    case "34": return "VALOR DO ABATIMENTO MAIOR/IGUAL AO VALOR DO TITULO";
                    case "36": return "CONCESSÃO ABATIMENTO - JA EXISTE ABATIMENTO ANTERIOR";
                    case "38": return "PRAZO PARA PROTESTO INVALIDO";
                    case "39": return "PEDIDO DE PROTESTO NÃO PERMITIDO PARA O TITULO";
                    case "40": return "TITULO COM ORDEM DE PROTESTO EMITIDO";
                    case "41": return "PEDIDO DE CANCELAMENTO/SUSTAÇÃO PARA TITULO SEM INSTRUÇÃO DE PROTESTO";
                    case "42": return "CODIGO PARA BAIXA/DEVOLUÇÃO INVALIDO";
                    case "45": return "NOME DO SACADO NÃO INFORMADO";
                    case "46": return "TIPO INSCRIÇÃO DO SACADO INVALIDO";
                    case "47": return "ENDEREÇO DO SACADO NÃO INFORMADO";
                    case "48": return "CEP INVALIDO";
                    case "50": return "CEP REFERENTE A UM BANCO CORRESPONDENTE";
                    case "53": return "TIPO DE INSCRIÇÃO DO SACADOR AVALISTA INVALIDO";
                    case "60": return "MOVIMENTO PARA TITULO NÃO CADASTRADO";
                    case "85": return "TITULO COM PAGAMENTO VINCULADO";
                    case "86": return "SEU NUMERO INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("35"))
                switch (codigo)
                {
                    case "81": return "TENTATIVAS ESGOTADAS, BAIXADO";
                    case "82": return "TENTATIVAS ESGOTADAS, PENDENTE";
                    default: return string.Empty;
                }
            else return string.Empty;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            return ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim().PadLeft(4, '0') +
                   ATitulo.Carteira.Trim().PadLeft(2, '0') +
                   ATitulo.Nosso_numero.Trim().PadLeft(11, '0') +
                   ATitulo.Cedente.ContaBancaria.NumeroConta.Trim().PadLeft(7, '0') +
                   "0";
        }

        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            return (vNossoNumero + 1).ToString().PadLeft(11, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            int digito_nossonumero = Estruturas.Mod11(ATitulo.Carteira.Trim() + ATitulo.Nosso_numero.Trim(), 7, true, 0);
            if (digito_nossonumero.Equals(1))
                return "P";
            else if (digito_nossonumero.Equals(0))
                return "0";
            else return (11 - digito_nossonumero).ToString();
        }

        public decimal TratarInstrucaoRemessa(string val)
        {
            switch (val)
            {
                case "RT": { return 1; }
                case "PB": { return 2; }
                case "CA": { return 4; }
                case "CB": { return 5; }
                case "AV": { return 6; }
                case "PT": { return 9; }
                case "OO": { return 31; }
                default: return decimal.Zero;
            }
        }

        private void GerarRemessaCNAB400(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;

            #region Registro Header
            //Identificacao do Header 001-001
            registros.Append("0");
            //Identificacao do arquivo remessa 002-002
            registros.Append("1");
            //Literal REMESSA 003-009
            registros.Append("REMESSA".FormatStringDireita(7, ' '));
            //Codigo servico cobranca 010-011
            registros.Append("01");
            //Literal COBRANCA 012-026
            registros.Append("COBRANCA".FormatStringDireita(15, ' '));
            //Codigo cedente 027-046
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(20, '0'));
            //Nome Empresa 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.FormatStringDireita(30, ' '));
            //Numero Banco Camara Compensacao 077-079
            registros.Append(CodigoBanco.Trim());
            //Nome Banco Extenso 080-094
            registros.Append(NomeBanco.FormatStringDireita(15, ' '));
            //Data Arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Brancos 101-108
            registros.Append("".FormatStringDireita(8, ' '));
            //Identificacao sistema 109-110
            registros.Append("MX");
            //Sequencial do arquivo 111-117
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(7, '0'));
            //Brancos 118-394
            registros.Append("".FormatStringDireita(277, ' '));
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
                //Agencia do Debito 002-006
                registros.Append("00000");
                //Digito Agencia Debito 007-007
                registros.Append(" ");
                //Razao Conta Corrente Sacado 008-012
                registros.Append("00000");
                //Numero Conta Corrente Sacado 013-019
                registros.Append("0000000");
                //Digito Conta Sacado 020-020
                registros.Append(" ");
                //Zero 021-021
                registros.Append("0");
                //Cobrança Registrado 022-024
                registros.Append("009");
                //Zero 025-025
                registros.Append("0");
                //Agencia 026-029
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Conta Corrente 030-036
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(7, '0'));
                //Digito da conta 037-037
                registros.Append(p.Cedente.ContaBancaria.DigitoConta.FormatStringEsquerda(1, '0'));
                //Controle Participante 038-062
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(25, '0'));
                //Codigo Banco 063-065
                registros.Append("000");

                if ((p.Pc_multa > decimal.Zero) && p.Tp_multa.Trim().ToUpper().Equals("P"))
                {
                    //Multa 066-066
                    registros.Append("2");
                    //Percentual Multa 067-070
                    registros.Append(p.Pc_multa.ToString().SoNumero().FormatStringEsquerda(4, '0'));
                }
                else
                    //Zeros 066-070
                    registros.Append("00000");
                //Nosso Numero 071-081
                registros.Append(p.Nosso_numero.FormatStringEsquerda(11, '0'));
                //Digito Nosso Numero 082-082
                registros.Append(CalcularDigitoNossoNumero(p));
                //Valor Desconto/Abatimento dia 083-092
                registros.Append(string.Empty.FormatStringEsquerda(10, '0'));
                //Condicao Emissao 093-093
                registros.Append("2");//Cliente emite e o banco somente processa
                //Ident. se emite boleto para debito automatico 094-094
                registros.Append(" ");
                //Identificao operacao banco 095-104
                registros.Append("".FormatStringDireita(10, ' '));
                //Indicador rateio credito 105-105
                registros.Append(" ");
                //Endereco para aviso debito automatico 106-106
                registros.Append("2");
                //Brancos 107-108
                registros.Append("  ");
                //Identificacao Ocorrencia 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Numero documento 111-120
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(10, '0'));
                //Data Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor Titulo 127-139
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Banco encarregado cobranca 140-142
                registros.Append("000");
                //Agencia Depositaria 143-147
                registros.Append("00000");
                //Especie Titulo 148-149
                registros.Append(ConverterEspecieDoc(p.Especie_documento));
                //Identificacao 150-150
                registros.Append(p.Aceite_SN);
                //Data Emissao Titulo 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Instrucao 1 157-158
                registros.Append(p.St_protestarauto ? "06" : "00");
                //Instrucao 2 159-160
                registros.Append(p.Nr_diasprotestar > decimal.Zero ? p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "00");
                //Valor cobrado dias atrazo 161-173
                registros.Append((p.Tp_jurodia.Trim().Equals("P") ? Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100), 2, MidpointRounding.AwayFromZero) : p.Pc_jurodia).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Data limite desconto 174-179
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                //Valor desconto 180-192
                registros.Append((p.Tp_desconto.Trim().Equals("P") ? Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100), 2, MidpointRounding.AwayFromZero) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Valor IOF 193-205
                registros.Append(decimal.Zero.ToString().FormatStringEsquerda(13, '0'));
                //Valor Abatimento 206-218
                registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Tipo Inscricao Sacado 219-220
                registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "01" : "02");
                //Numero Inscricao Sacado 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome Sacado 235-274
                registros.Append(p.Sacado.Nome.RemoverCaracteres().FormatStringDireita(40, ' '));
                //Endereco Sacado 275-314
                registros.Append((p.Sacado.Endereco.Rua.RemoverCaracteres().Trim() + p.Sacado.Endereco.Numero.RemoverCaracteres().Trim()).FormatStringDireita(40, ' '));
                //Mensagem 1 315-326
                registros.Append(string.Empty.FormatStringDireita(12, ' '));
                //CEP 327-331
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().Length.Equals(8) ? p.Sacado.Endereco.CEP.SoNumero().Substring(0, 5) : "     ");
                //Sufixo CEP 332-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().Length.Equals(8) ? p.Sacado.Endereco.CEP.SoNumero().Substring(5, 3) : "   ");
                //Bairro do Pagador 335-354
                registros.Append(p.Sacado.Endereco.Bairro.FormatStringDireita(20, ' '));
                //Cidade do Pagador 355-392
                registros.Append(p.Sacado.Endereco.Cidade.FormatStringDireita(38, ' '));
                //UF Pagador 393-394
                registros.Append(p.Sacado.Endereco.Estado.FormatStringDireita(2, ' '));
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

        public void GerarRemessa(blCobranca ACobranca, string Path_remessa)  //{Gerar arquivo remessa para enviar ao banco}
        {
            StringBuilder Remessa = new StringBuilder();
            switch (ACobranca.LayoutArquivo)
            {
                case TLayoutArquivo.laCNAB240:
                    throw new Exception("Layout CNAB240 não suportado pelo Aliance.NET.");
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
            object obj = new TCD_LoteRemessa().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + ACobranca.Titulos[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_contager",
                                    vOperador = "=",
                                    vVL_Busca = "'" + ACobranca.Titulos[0].Cd_contager.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lote)))",
                                    vOperador = "=",
                                    vVL_Busca = "'" + ACobranca.DataArquivo.ToString("yyyyMMdd") + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                }
                            }, "count(*)");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path_remessa +
                                                                          "CB" + //Cobranca Bradesco
                                                                          ACobranca.DataArquivo.Day.FormatStringEsquerda(2, '0') +
                                                                          ACobranca.DataArquivo.Month.FormatStringEsquerda(2, '0') +
                                                                          (obj == null ? "01" : decimal.Parse(obj.ToString() + 1).FormatStringEsquerda(2, '0')) +
                                                                          ".REM"))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }

        private bool LerRetornoCNAB400(blCobranca ACobranca, string[] Retorno)
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
                ACodigoCedente = Convert.ToInt32(Retorno[NumeroRegistro].Substring(26, 20)).ToString();

                if (Retorno[NumeroRegistro].Substring(94, 6).PadLeft(6, '0') != "000000")
                    ACobranca.DataArquivo = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(98, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(96, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(94, 2)));
                else
                    ACobranca.DataArquivo = DateTime.Now;

                //{Lê os registros DETALHE}
                //{Processa até o penúltimo registro porque o último contém apenas o TRAILLER}
                for (NumeroRegistro = 1; NumeroRegistro <= (Retorno.Length - 2); NumeroRegistro++)
                {
                    //{Confirmar se o tipo do registro é 1}
                    if (Retorno[NumeroRegistro].Substring(0, 1) != "1")
                        continue; //{Não processa o registro atual}
                    //Dados Titulo
                    ATitulo = new blTitulo();
                    ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                    ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                    //Nosso numero
                    ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(70, 11);
                    //Ocorrencia
                    ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(108, 2);
                    //Descricao ocorrencia
                    ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia);
                    //Data ocorrencia
                    if (Retorno[NumeroRegistro].Substring(110, 6).PadLeft(6, '0') != "000000")
                        ATitulo.Dt_ocorrencia = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(114, 2)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(112, 2)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(110, 2)));
                    else
                        ATitulo.Dt_ocorrencia = DateTime.Now;
                    //Data vencimento
                    if (Retorno[NumeroRegistro].Substring(146, 6).PadLeft(6, '0') != "000000")
                        ATitulo.Dt_vencimento = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(150, 2)),
                                                                Convert.ToInt32(Retorno[NumeroRegistro].Substring(148, 2)),
                                                                Convert.ToInt32(Retorno[NumeroRegistro].Substring(146, 2)));
                    else
                        ATitulo.Dt_vencimento = null;
                    //Valor titulo
                    if (Retorno[NumeroRegistro].Substring(152, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(152, 13)) / 100;
                    else
                        ATitulo.Vl_documento = decimal.Zero;
                    //Valor despesas
                    if (Retorno[NumeroRegistro].Substring(175, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(175, 13)) / 100;
                    else
                        ATitulo.Vl_despesa_cobranca = decimal.Zero;
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
                    //Outros creditos
                    if (Retorno[NumeroRegistro].Substring(279, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.vl_outros_creditos = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(279, 13)) / 100;
                    else
                        ATitulo.vl_outros_creditos = decimal.Zero;
                    //Motivo ocorrencia
                    string codigo = Retorno[NumeroRegistro].Substring(318, 10);
                    if (!string.IsNullOrEmpty(codigo))
                    {
                        if (codigo.Substring(0, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(0, 2)) + "|";
                        if (codigo.Substring(2, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(2, 2)) + "|";
                        if (codigo.Substring(4, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(4, 2)) + "|";
                        if (codigo.Substring(6, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(6, 2)) + "|";
                        if (codigo.Substring(8, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(8, 2)) + "|";
                    }
                    if (!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                        if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                            ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                    //Data credito
                    if (Retorno[NumeroRegistro].Substring(295, 6).Trim().PadLeft(6, '0') != "000000")
                    {
                        ATitulo.Dt_credito = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(299, 2)),
                                                           Convert.ToInt32(Retorno[NumeroRegistro].Substring(297, 2)),
                                                           Convert.ToInt32(Retorno[NumeroRegistro].Substring(295, 2)));
                        ATitulo.Dt_creditotaxa = ATitulo.Dt_credito;
                    }
                    else
                    {
                        ATitulo.Dt_credito = DateTime.Now;
                        ATitulo.Dt_creditotaxa = ATitulo.Dt_credito;
                    }
                    //Inserir titulo na lista
                    ACobranca.Titulos.Add(ATitulo);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool LerRetorno(blCobranca ACobranca, string[] arq)
        {
            try
            {
                if (arq.Length <= 0)
                    throw new Exception("O retorno está vazio. Não há dados para processar");

                switch (ACobranca.LayoutArquivo)
                {

                    case TLayoutArquivo.laCNAB240:
                        throw new Exception("Layout CNAB240 não suportado pelo Aliance.NET.");
                    case TLayoutArquivo.laCNAB400:
                        return LerRetornoCNAB400(ACobranca, arq);
                    default:
                        throw new Exception("Tamanho de registro inválido: " + arq[0].Length);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
