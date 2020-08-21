using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.IO;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco001
    {
        const string CodigoBanco = "001";
        const string NomeBanco = "Banco do Brasil";

        public string GetNomeBanco()
        {
            return NomeBanco;//Retorna o nome do banco
        }

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantil: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edNotaSeguro: return "03";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edLetraCambio: return "08";
                case TEspecieDocumento.edNotaDebito: return "13";
                case TEspecieDocumento.edDuplicataServicoIndicacao: return "12";
                default: return string.Empty;
            }
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
                default: return decimal.Zero;
            }
        }

        public string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "02": return "CONFIRMAÇÃO ENTRADA DE TITULO";
                case "03": return "COMANDO RECUSADO";
                case "05": return "LIQUIDAÇÃO SEM REGISTRO";
                case "06": return "LIQUIDAÇÃO NORMAL";
                case "07": return "LIQUIDAÇÃO POR CONTA/PARCIAL";
                case "08": return "LIQUIDAÇÃO POR SALDO";
                case "09": return "BAIXA DE TITULO";
                case "10": return "BAIXA SOLICITADA";
                case "11": return "TITULO EM SER";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "VENCIMENTO ALTERADO";
                case "15": return "LIQUIDAÇÃO EM CARTÓRIO";
                case "16": return "CONFIRMAÇÃO DE ALTERAÇÃO DE JUROS DE MORA";
                case "19": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE PROTESTO";
                case "20": return "DÉBITO EM CONTA";
                case "21": return "ALTERAÇÃO DO NOME DO SACADO";
                case "22": return "ALTERAÇÃO DO ENDEREÇO DO SACADO";
                case "23": return "INDICAÇÃO DE ENCAMINHAMENTO A CARTORIO";
                case "24": return "SUSTAR PROTESTO";
                case "25": return "DISPENSAR JUROS DE MORA";
                case "26": return "ALTERAÇÃO DO NUMERO DO TITULO DADO PELO CEDENTE";
                case "28": return "MANUTENÇÃO DE TITULO VENCIDO";
                case "31": return "CONCEDER DESCONTO";
                case "32": return "NÃO CONCEDER DESCONTO";
                case "33": return "RETIFICAR DESCONTO";
                case "34": return "ALTERAR DATA PARA DESCONTO";
                case "35": return "COBRAR MULTA";
                case "36": return "DISPENSAR MULTA";
                case "37": return "DISPENSAR INDEXADOR";
                case "38": return "DISPENSAR PRAZO LIMITE PARA RECEBIMENTO";
                case "39": return "ALTERAR PRAZO LIMITE PARA RECEBIMENTO";
                case "41": return "ALTERAÇÃO DO NUMERO DO CONTROLE DO PARTICIPANTE";
                case "42": return "ALTERAÇÃO DO NUMERO DO DOCUMENTO DO SACADO";
                case "44": return "TITULO PAGO COM CHEQUE DEVOLVIDO";
                case "46": return "TITULO PAGO COM CHEQUE, AGUARDANDO COMPENSAÇÃO";
                case "72": return "ALTERAÇÃO DE TIPO DE COBRANÇA";
                case "73": return "CONFIRMAÇÃO DE INSTRUÇÃO DE PARAMETRO DE PAGAMENTO PARCIAL";
                case "96": return "DESPESAS DE PROTESTO";
                case "97": return "DESPESAS DE SUSTAÇÃO DE PROTESTO";
                case "98": return "DEBITO DE CUSTAS ANTECIPADAS";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string ocorrencia, string codigo)
        {
            if (ocorrencia.Trim().ToUpper().Equals("03"))
                switch (codigo)
                {
                    case "01": return "IDENTIFICAÇÃO INVALIDA";
                    case "02": return "VARIAÇÃO DA CARTEIRA INVALIDA";
                    case "03": return "VALOR DOS JUROS POR UM DIA INVALIDO";
                    case "04": return "VALOR DO DESCONTO INVALIDO";
                    case "05": return "ESPECIE DE TITULO INVALIDA PARA CARTEIRA";
                    case "06": return "ESPECIE DE VALOR INVARIAVEL INVALIDO";
                    case "07": return "PREFIXO DA AGENCIA USUARIA INVALIDA";
                    case "08": return "VALOR DO TITULO INVALIDO";
                    case "09": return "DATA DE VENCIMENTO INVALIDA";
                    case "10": return "FORA DO PRAZO/SO ADMISSIVEL NA CARTEIRA";
                    case "11": return "INEXISTENCIA DE MARGEM PARA DESCONTO";
                    case "12": return "O BANCO NÃO TEM AGENCIA NA PRAÇA DO SACADO";
                    case "13": return "RAZÕES CADASTRAIS";
                    case "14": return "SACADO INTERLIGADO COM O SACADOR";
                    case "15": return "TITULO SACADO CONTRA ORGÃO DO PODER PUBLICO";
                    case "16": return "TITULO PREENCHIDO DE FORMA IRREGULAR";
                    case "17": return "TITULO RASURADO";
                    case "18": return "ENDEREÇO DO SACADO NÃO LOCALIZADO OU INCOMPLETO";
                    case "19": return "CODIGO DO CEDENTE INVALIDO";
                    case "20": return "NOME/ENDEREÇO DO CLIENTE NÃO INFORMADO";
                    case "21": return "CARTEIRA INVALIDA";
                    case "22": return "QUANTIDADE DE VALOR VARIAVEL INVALIDA";
                    case "23": return "FAIXA NOSSO-NUMERO EXCEDIDA";
                    case "24": return "VALOR DO ABATIMENTO INVALIDO";
                    case "25": return "NOVO NUMERO DO TITULO DADO PELO CEDENTE INVALIDO";
                    case "26": return "VALOR DO IOF DO SEGURO INVALIDO";
                    case "27": return "NOME DO SACADO/CEDENTE INVALIDO";
                    case "28": return "DATA DO NOVO VENCIMENTO INVALIDA";
                    case "29": return "ENDEREÇO NÃO INFORMADO";
                    case "30": return "REGISTRO DE TITULO JA LIQUIDADO";
                    case "31": return "NUMERO DO BORDERO INVALIDO";
                    case "32": return "NOME DA PESSOA AUTORIZADA INVALIDA";
                    case "33": return "NOSSO NUMERO JA EXISTENTE";
                    case "34": return "NUMERO DA PRESTAÇÃO DO CONTRATO INVALIDO";
                    case "35": return "PERCENTUAL DE DESCONTO INVALIDO";
                    case "36": return "DIAS PARA FICHAMENTO DE PROTESTO INVALIDO";
                    case "37": return "DATA DE EMISSÃO DO TITULO INVALIDA";
                    case "38": return "DATA DO VENCIMENTO ANTERIOR A DATA DE EMISSÃO DO TITULO";
                    case "39": return "COMANDO DE ALTERAÇÃO INDEVIDO PARA A CARTEIRA";
                    case "40": return "TIPO DE MOEDA INVALIDO";
                    case "41": return "ABATIMENTO NÃO PERMITIDO";
                    case "42": return "CEP/UF INVALIDO";
                    case "43": return "CODIGO DE UNIDADE VARIAVEL INCOMPATIVEL COM A DATA DE EMISSÃO DO TITULO";
                    case "44": return "DADOS PARA DEBITO AO SACADO INVALIDO";
                    case "45": return "CARTEIRA/VARIAÇÃO ENCERRADA";
                    case "46": return "CONVENIO ENCERRADO";
                    case "47": return "TITULO TEM VALOR DIVERSO DO INFORMADO";
                    case "48": return "MOTIVO DE BAIXA INVALIDO PARA A CARTEIRA";
                    case "49": return "ABATIMENTO A CANCELAR NÃO CONSTA NO TITULO";
                    case "50": return "COMANDO INCOMPATIVEL COM A CARTEIRA";
                    case "51": return "CODIGO DO CONVENENTE INVALIDO";
                    case "52": return "ABATIMENTO IGUAL O MAIOR QUE O VALOR DO TITULO";
                    case "53": return "TITULO JA SE ENCONTRA NA SITUAÇÃO PRETENDIDA";
                    case "54": return "TITULO FORA DO PRAZO ADMITIDO PARA A CONTA 1";
                    case "55": return "NOVO VENCIMENTO FORA DOS LIMITES DA CARTEIRA";
                    case "56": return "TITULO NÃO PERTENCE AO CONVENENTE";
                    case "57": return "VARIAÇÃO INCOMPATIVEL COM A CARTEIRA";
                    case "58": return "IMPOSSIVEL A VARIAÇÃO UNICA PARA A CARTEIRA INDICADA";
                    case "59": return "TITULO VENCIDO EM TRANSFERENCIA PARA A CARTEIRA 51";
                    case "60": return "TITULO COM PRAZO SUPERIOR A 179 DIAS EM VARIAÇÃO UNICA NA CARTEIRA 51";
                    case "61": return "TITULO JA FOI FICHADO PARA PROTESTO";
                    case "62": return "ALTERAÇÃO DA SITUAÇÃO DE DEBITO INVALIDA PARA O CODIGO DE RESPONSABILIDADE";
                    case "63": return "DV DO NOSSO NUMERO INVALIDO";
                    case "64": return "TITULO NÃO PASSIVEL DE DEBITO/BAIXA";
                    case "65": return "TITULO COM ORDEM DE NÃO PROTESTAR";
                    case "66": return "CPF/CNPJ DO SACADO INVALIDO";
                    case "67": return "TITULO/CARNE REJEITADO";
                    case "69": return "VALOR/PERCENTUAL DE JUROS INVALIDOS";
                    case "70": return "TITULO JA SE ENCONTRA ISENTO DE JUROS";
                    case "71": return "CODIGO DE JUROS INVALIDOS";
                    case "72": return "PREFIXO DA AGENCIA COBRADORA INVALIDO";
                    case "73": return "NUMERO DO CONTROLE DO PARTICIPANTE INVALIDO";
                    case "74": return "CLIENTE NÃO CADASTRADO NO CIOPE";
                    case "75": return "QTDE DE DIAS DO PRAZO LIMITE PARA RECEBIMENTO DE TITULO VENCIDO INVALIDO";
                    case "76": return "TITULO EXCLUIDO AUTOMATICAMENTE POR DECURSO DE PRAZO CIOPE";
                    case "77": return "TITULO VENCIDO TRANSFERIDO PARA CONTA 1";
                    case "80": return "NOSSO NUMERO INVALIDO";
                    case "81": return "DATA PARA CONSESSÃO DO DESCONTO INVALIDA";
                    case "82": return "CEP DO SACADO INVALIDO";
                    case "83": return "CARTEIRA/VARIAÇÃO NÃO LOCALIZADA NO CEDENTE";
                    case "84": return "TITULO NÃO LOCALIZADO NA EXISTENCIA";
                    case "99": return "OUTROS MOTIVOS";
                    default: return string.Empty;
                }
            else return string.Empty;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            if (!string.IsNullOrEmpty(ATitulo.Cd_bancocorrespondente))
                return "000000" +//Zeros
                       ATitulo.Nosso_numero.Trim().FormatStringEsquerda(17, '0') + //Nosso numero sem DV
                       ATitulo.Carteiracorrespondente.Trim().FormatStringDireita(2, ' ');//Carteira
            else if (ATitulo.Cedente.CodigoCedente.Trim().Length.Equals(4))
                return ATitulo.Nosso_numero.FormatStringEsquerda(11, '0') +
                        ATitulo.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0') +
                        ATitulo.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0') +
                        ATitulo.Carteira.FormatStringEsquerda(2, '0');
            else if (ATitulo.Cedente.CodigoCedente.Trim().Length.Equals(6))
                return ATitulo.Nosso_numero.FormatStringEsquerda(11, '0') +
                        ATitulo.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0') +
                        ATitulo.Cedente.ContaBancaria.NumeroConta.Trim().FormatStringEsquerda(8, '0') +
                        ATitulo.Carteira.FormatStringEsquerda(2, '0');
            else if (ATitulo.Cedente.CodigoCedente.Trim().Length.Equals(7))
                return ATitulo.Nosso_numero.FormatStringEsquerda(17, '0') +
                        ATitulo.Carteira.FormatStringEsquerda(2, '0');
            else
                return string.Empty;

        }

        public string CalcularNossoNumero(decimal vNossoNumero, string ConvenioCobranca, string CodigoCedente)
        {
            if (!string.IsNullOrEmpty(ConvenioCobranca))
                return ConvenioCobranca.Trim() + (vNossoNumero + 1).ToString().Trim().FormatStringEsquerda(ConvenioCobranca.Trim().Length.Equals(4) ? 7 :
                                                                                                          ConvenioCobranca.Trim().Length.Equals(6) ? 5 : 7, '0');
            else if (CodigoCedente.Trim().Length.Equals(4))
                return CodigoCedente.Trim() + (vNossoNumero + 1).FormatStringEsquerda(7, '0');
            else if (CodigoCedente.Trim().Length.Equals(6))
                return CodigoCedente.Trim() + (vNossoNumero + 1).FormatStringEsquerda(5, '0');
            else if (CodigoCedente.Trim().Length.Equals(7))
                return CodigoCedente.Trim() + (vNossoNumero + 1).FormatStringEsquerda(10, '0');
            else return string.Empty;
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Utils.Estruturas.Mod11(Utils.Estruturas.StrTam(ATitulo.Nosso_numero.Trim(), "0", false, 15), 9, false, 0).ToString();
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

        private void GerarRemessaCNAB400(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;

            #region Registro Header
            //Identificacao do Header 001-001
            registros.Append("0");
            //Tipo de operação 002-002
            registros.Append("1");
            //Identificação por extenso do tipo de operação 003-009 <Para homologacao informar (TESTE)
            registros.Append("REMESSA".FormatStringDireita(7, ' '));
            //Identificação tipo serviço 010-011
            registros.Append("01");
            //Literal COBRANCA 012-019
            registros.Append("COBRANCA");
            //Complemento Registro 020-026
            registros.Append("".FormatStringDireita(7, ' '));
            //Numero Agencia 027-030
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Digito da Agencia 031-031
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.FormatStringDireita(1, ' '));
            //Numero Conta 032-039
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0'));
            //Digito da Conta 040-040
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta.FormatStringDireita(1, ' '));
            //Complemento 041-046
            registros.Append("000000");
            //Nome Cedente 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Identificacao Banco 077-094
            registros.Append("001BANCODOBRASIL".FormatStringDireita(18, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Sequencial da Remessa 101-107
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(7, '0'));
            //Complemento 108-129
            registros.Append("".FormatStringDireita(22, ' '));
            //Numero convenio lider 130-136
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(7, '0'));
            //Complemento 137-394
            registros.Append("".FormatStringDireita(258, ' '));
            //Sequencial do registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            aCobranca.Titulos.ForEach(p =>
            {
                #region Detalhe do titulo
                registros = new StringBuilder();
                //Identificao Registro 001-001
                registros.Append("7");
                //Tipo inscricao cedente 002-003
                registros.Append(p.Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //Numero CPF/CNPJ 004-017
                registros.Append(p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Prefixo Agencia 018-021
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Digito Agencia 022-022
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia.FormatStringDireita(1, ' '));
                //Numero Conta 023-030
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0'));
                //Digito Conta 031-031
                registros.Append(p.Cedente.ContaBancaria.DigitoConta.FormatStringDireita(1, ' '));
                //Codigo Cedente 032-038
                registros.Append(p.Cedente.CodigoCedente.FormatStringEsquerda(7, '0'));
                //Controle Empresa 039-063
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(25, ' '));
                //Nosso Numero 064-080
                registros.Append(p.Nosso_numero.FormatStringEsquerda(17, '0'));
                //Numero Prestacao 081-082
                registros.Append("00");
                //Grupo Valor 083-084
                registros.Append("00");
                //Complemento 085-087
                registros.Append("   ");
                //Indicativo de Mensagem ou Sacador/Avalista 088-088
                registros.Append(" ");
                //Complento 089-091
                registros.Append("   ");
                //Variacao Carteira 092-094
                registros.Append(p.Modalidade.FormatStringEsquerda(3, '0'));
                //Conta Caução 095-095
                registros.Append("0");
                //Numero Bordero 096-101
                registros.Append("000000");
                //Tipo Cobranca 102-106
                registros.Append("     ");
                //Carteira Cobranca 107-108
                registros.Append(p.Carteira.FormatStringEsquerda(2, '0'));
                //Comando 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Seu Numero 111-120
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(10, ' '));
                //Data Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor Titulo 127-139
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Numero Banco 140-142
                registros.Append(p.Cd_banco.FormatStringEsquerda(3, '0'));
                //Agencia Cobradora 143-146
                registros.Append("0000");
                //Digito agencia cobradora 147-147
                registros.Append(" ");
                //Especie Titulo 148-149
                registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                //Aceite 150-150
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "A" : "N");
                //Data emissao 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Instrucao Codificada 157-158
                registros.Append(p.St_protestarauto ? "06" : "00");
                //Instrucao Codificada 159-160
                registros.Append(p.Pc_jurodia > decimal.Zero ? "01" : "00");
                //Juros Mora 161-173
                if (p.Pc_jurodia > decimal.Zero)
                {
                    if (p.Tp_jurodia.Trim().ToUpper().Equals("V"))
                        throw new Exception("Modalidade de cobrança não permite informar juro em VALOR.");
                    registros.Append(Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100), 2).SoNumero().FormatStringEsquerda(13, '0'));
                }
                else registros.Append("".FormatStringEsquerda(13, '0'));
                if (p.Pc_desconto > decimal.Zero)
                {
                    //Data Limite Desconto 174-179
                    registros.Append(p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy"));
                    //Valor Desconto 180-192
                    registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                }
                else
                {
                    //Data Limite Desconto 174-179
                    registros.Append("".FormatStringEsquerda(6, '0'));
                    //Valor Desconto 180-192
                    registros.Append("".FormatStringEsquerda(13, '0'));
                }
                //Valor IOF 193-205
                registros.Append("".FormatStringEsquerda(13, '0'));
                //Valor Abatimento 206-218
                registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Tipo Inscricao Sacado 219-220
                registros.Append(p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //CPF/CNPJ Sacado 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome Sacado 235-271
                registros.Append(p.Sacado.Nome.RemoverCaracteres().FormatStringDireita(37, ' '));
                //Complemento 272-274
                registros.Append("   ");
                //Endereco Sacado 275-314
                registros.Append((p.Sacado.Endereco.Rua.Trim() + ", " + p.Sacado.Endereco.Numero.Trim()).RemoverCaracteres().FormatStringDireita(40, ' '));
                //Bairro Sacado 315-326
                registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().FormatStringDireita(12, ' '));
                //CEP Sacado 327-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                //Cidade Sacado 335-349
                registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().FormatStringDireita(15, ' '));
                //UF Sacado 350-351
                registros.Append(p.Sacado.Endereco.Estado.RemoverCaracteres().FormatStringDireita(2, ' '));
                //Mensagem ou Sacador Avalista 352-391
                registros.Append("".FormatStringDireita(40, ' '));
                //Dias Protesto 392-393
                registros.Append(p.St_protestarauto ? p.Nr_diasprotestar < 6 ? "06" : p.Nr_diasprotestar.SoNumero().FormatStringEsquerda(2, '0') : "00");
                //Complemento 394-394
                registros.Append(" ");
                //sequencial do registro 395-400
                registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                Remessa.AppendLine(registros.ToString());
                #endregion

                #region Opcional Multa
                if (p.Pc_multa > decimal.Zero)
                {
                    registros = new StringBuilder();
                    //Identificacao do registro 001-001
                    registros.Append("5");
                    //Tipo Servico 002-003
                    registros.Append("99");
                    //Codigo Multa 004-004
                    registros.Append(p.Tp_multa.Trim().ToUpper().Equals("V") ? "1" : "2");//1-Valor 2-Percentual
                    //Data inicio multa 005-010
                    registros.Append(p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasmulta)).ToString("ddMMyy"));
                    //Valor/Percentual Multa 011-022
                    registros.Append(p.Pc_multa.SoNumero().FormatStringEsquerda(12, '0'));
                    //Brancos 023-394
                    registros.Append("".FormatStringDireita(372, ' '));
                    //sequencial do registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                    Remessa.AppendLine(registros.ToString());
                }
                #endregion
            });
            #endregion

            #region Trailer
            registros = new StringBuilder();
            //Identificacao registro 001-001
            registros.Append("9");
            //Complemento 002-394
            registros.Append(string.Empty.FormatStringDireita(393, ' '));
            //Sequencial registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }

        private void GerarRemessaCNAB240(blCobranca ACobranca, StringBuilder Remessa)
        {
            
            StringBuilder Registro = new StringBuilder();
            int NumeroRegistro = 0;
            int NumeroLote = 1;


            if (ACobranca.Titulos.Count < 1)
                throw new Exception("Não há títulos para gerar remessa");

            #region REGISTRO READER DO ARQUIVO

            Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0')); //{1 a 3 - Código do banco}
            Registro.Append("0000"); //{4 a 7 - Lote de serviço}
            Registro.Append("0");    //{8 - Tipo de registro - Registro header de arquivo}
            Registro.Append("".FormatStringDireita(9, ' '));  // {9 a 17 - Uso exclusivo FEBRABAN/CNAB}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "2");
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0')); //{19 a 32 - Número de inscrição do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.CodigoCedente.Trim().FormatStringEsquerda(9, '0') +
                            "0014" + ACobranca.Titulos[NumeroRegistro].Carteira.FormatStringEsquerda(2, '0') + "019" + "  ");//{33 a 52 - Código do convênio no banco}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia.Trim().FormatStringEsquerda(5, '0')); //{53 a 57 - Código da agência do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia.Trim().FormatStringEsquerda(1, '0')); //{58 - Dígito do código da agência do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta.Trim().FormatStringEsquerda(12, '0'));  //{59 a 70 - Código da conta corrente vinculada à cobrança / não é o número da conta corrente comum}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta.Trim().FormatStringEsquerda(1, '0'));   //{71 - Dígito da conta corrente vinculada à cobrança}
            Registro.Append(" "); //{72 - Dígito verificador da agência / conta do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));                       //{73 a 102 - Nome do cedente}
            Registro.Append("BANCO DO BRASIL S.A".FormatStringDireita(30, ' '));                                             //{103 a 132 - Nome do banco}
            Registro.Append("".FormatStringDireita(10, ' '));                                    //{133 a 142 - Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("1");                                                //{143 - Código de Remessa (1) / Retorno (2)}
            Registro.Append(ACobranca.DataArquivo.ToString("ddmmyyyy"));         //{144 a 151 - Data do de geração do arquivo}
            Registro.Append(ACobranca.DataArquivo.ToString("hhmmss"));           //{152 a 157 - Hora de geração do arquivo}
            Registro.Append(ACobranca.SequencialArq.ToString().Trim().FormatStringEsquerda(6, '0'));  //{158 a 163 Número seqüencial do arquivo}
            Registro.Append("030");               //; {164 a 166 - Número da versão do layout do arquivo}
            Registro.Append("".FormatStringEsquerda(5, '0'));   //{167 a 171 - Densidade de gravação do arquivo (BPI)}
            Registro.Append("".FormatStringDireita(20, ' '));  //{172 a 191 - Uso reservado do banco}
            Registro.Append("".FormatStringDireita(20, ' '));                //{192 a 211 - Deverá conter a literal REMESSA-TESTE para fase de testes}
            Registro.Append("".FormatStringDireita(11, ' '));                  //{212 a 240 - Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("CSP"); //CSP
            Registro.Append("".FormatStringEsquerda(3, '0')); //Uso VANS
            Registro.Append("  "); //Tipo Servico
            Registro.Append("".FormatStringDireita(10, ' '));//Titulo em Carteira Cobranca
            Remessa.AppendLine(Registro.ToString());

            Registro.Remove(0, Registro.Length);  //limpar registro
            #endregion

            #region GERAR REGISTRO HEADER DO LOTE

            Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0'));  //{1a 3 - Código do banco}
            Registro.Append(NumeroLote.ToString().Trim().FormatStringEsquerda(4, '0')); //{4 a 7 - Número do lote de serviço}
            Registro.Append("1");                        //{8 - Tipo do registro - Registro header de lote}
            Registro.Append("R");  //{9 - Tipo de operação: R (Remessa) ou T (Retorno)}
            Registro.Append("01");  //{10 a 11 - Tipo de serviço: 01 (Cobrança)}
            Registro.Append("  ");   //{12 a 13 - Forma de lançamento: preencher com ZEROS no caso de cobrança}
            Registro.Append("020");  //{14 a 16 - Número da versão do layout do lote}
            Registro.Append(" ");    //{17 - Uso exclusivo FEBRABAN/CNAB}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "2"); //{18 - Tipo de inscrição do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));  //{19 a 33 - Número de inscrição do cedente}

            //{CÓDIGO DO CONVÊNIO = AGÊNCIA + NÚMERO CONVÊNIO + DV}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.CodigoCedente.Trim().FormatStringEsquerda(9, '0') + "0014" +
                            ACobranca.Titulos[NumeroRegistro].Carteira.FormatStringEsquerda(2, '0') + "019" + "  ");              //{34 a 53 - Código do convênio no banco}

            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia.Trim().FormatStringEsquerda(5, '0')); //{54 a 58 - Código da agência do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia.Trim().FormatStringEsquerda(1, '0')); //{59 - Dígito da agência do cedente}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta.Trim().FormatStringEsquerda(12, '0'));  //{60 a 71 - Número da conta vinculada à cobrança / não é o número da conta corrente comum}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta.Trim().FormatStringEsquerda(1, '0'));   //{72 - Dígito do código do cedente no banco}
            Registro.Append(" "); //{73 - Dígito verificador da agência / conta}
            Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));       //{74 a 103 - Nome do cedente}
            Registro.Append("".FormatStringDireita(40, ' ')); //{104 a 143 - Mensagem 1 para todos os boletos do lote}
            Registro.Append("".FormatStringDireita(40, ' ')); //{144 a 183 - Mensagem 2 para todos os boletos do lote}
            Registro.Append(ACobranca.SequencialArq.ToString().FormatStringEsquerda(8, '0')); //{184 a 191 - Número do arquivo}
            Registro.Append(ACobranca.DataArquivo.ToString("ddmmyyyy")); //{192 a 199 - Data de geração do arquivo}
            Registro.Append("".FormatStringEsquerda(8, '0')); //{200 a 207 - Data do crédito - Informar somente para arquivo retorno
            Registro.Append("".FormatStringDireita(33, ' '));    // {208 a 240 - Uso exclusivo FEBRABAN/CNAB}

            Remessa.AppendLine(Registro.ToString());

            Registro.Remove(0, Registro.Length);  //limpar registro
            #endregion

            #region GERAR TODOS OS REGISTROS DETALHE DA REMESSA
            while (NumeroRegistro <= (ACobranca.Titulos.Count - 1))
            {
                if (CodigoBanco.Trim().FormatStringEsquerda(3, '0') != ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.Banco.Codigo.Trim().FormatStringEsquerda(3, '0'))
                    throw new Exception("O título (Nosso Número: " + ACobranca.Titulos[NumeroRegistro].Nosso_numero + ") não pertence ao banco " + CodigoBanco + " " + NomeBanco);

                #region SEGMENTO P
                Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0'));           //{1 a 3 - Código do banco}
                Registro.Append(NumeroLote.ToString().Trim().FormatStringEsquerda(4, '0')); // {4 a 7 - Número do lote}
                Registro.Append("3"); //{8 - Tipo do registro: Registro detalhe}
                Registro.Append((2 * NumeroRegistro + 1).ToString().Trim().FormatStringEsquerda(5, '0')); //{9 a 13 - Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)}
                Registro.Append("P"); //{14 - Código do segmento do registro detalhe}
                Registro.Append(" ");  //{15 - Uso exclusivo FEBRABAN/CNAB: Branco}
                Registro.Append(ACobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));//{16 a 17 - Código de movimento}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia.Trim().FormatStringEsquerda(5, '0')); //{18 a 22 - Agência mantenedora da conta}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia.Trim().FormatStringEsquerda(1, '0')); //{23 - Dígito verificador da agência}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta.Trim().FormatStringEsquerda(12, '0'));  //{24 a 35 - Número da conta vinculada à cobrança / não é o número da conta corrente comum}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta.Trim().FormatStringEsquerda(1, '0'));   //{36 - Dígito da conta vinculada à cobrança}
                Registro.Append(" "); //{37 - Dígito verificador da agência / conta}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Nosso_numero.Trim().FormatStringDireita(20, ' ')); //{47 a 57 - Nosso número - identificação do título no banco}
                Registro.Append("7"); //{58 - Cobrança Simples}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Tp_cobranca.Trim().ToUpper().Equals("CR") ? "1" : "2"); //{59 - Forma de cadastramento do título no banco: com cadastramento}
                Registro.Append(" "); //{60 - Tipo de documento: Escritural}
                Registro.Append("  "); //{61 a 62 - Quem emite e quem distribui o boleto?}
                Registro.Append((ACobranca.Titulos[NumeroRegistro].Nr_lancto.ToString() + ACobranca.Titulos[NumeroRegistro].Cd_parcela.ToString() + ACobranca.Titulos[NumeroRegistro].Id_cobranca.ToString()).FormatStringEsquerda(15, '0')); //{63 a 73 - Número que identifica o título na empresa}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Dt_vencimento.Value.ToString("ddMMyyyy")); // {78 a 85 - Data de vencimento do título}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Vl_documento.ToString().SoNumero().FormatStringEsquerda(15, '0'));    //{86 a 100 - Valor nominal do título}
                Registro.Append("00000"); //{101 a 105 - Agência cobradora. Deixar zerado. A Caixa determinará automaticamente pelo CEP do sacado}
                Registro.Append(" ");      //{106 - Dígito da agência cobradora}
                switch (ACobranca.Titulos[NumeroRegistro].Especie_documento) //{107 a 108 - Espécie do documento}
                {
                    case TEspecieDocumento.edApoliceSeguro: Registro.Append("20"); break;   //{AP  APÓLICE DE SEGURO}
                    case TEspecieDocumento.edCheque: Registro.Append("01"); break;   //{CH  CHEQUE}
                    case TEspecieDocumento.edDuplicataMercantil: Registro.Append("02"); break;   //{DM  DUPLICATA MERCANTIL}
                    case TEspecieDocumento.edDuplicataMercantialIndicacao: Registro.Append("03"); break;   //{DMI DUPLICATA MERCANTIL P/ INDICAÇÃO}
                    case TEspecieDocumento.edDuplicataRural: Registro.Append("06"); break;   //{DR  DUPLICATA RURAL}
                    case TEspecieDocumento.edDuplicataServico: Registro.Append("04"); break;   //{DS  DUPLICATA DE SERVIÇO}
                    case TEspecieDocumento.edDuplicataServicoIndicacao: Registro.Append("05"); break;   //{DSI DUPLICATA DE SERVIÇO P/ INDICAÇÃO}
                    case TEspecieDocumento.edFatura: Registro.Append("18"); break;   //{FAT FATURA}
                    case TEspecieDocumento.edLetraCambio: Registro.Append("07"); break;   //{LC  LETRA DE CÂMBIO}
                    case TEspecieDocumento.edMensalidadeEscolar: Registro.Append("21"); break;   //{ME  MENSALIDADE ESCOLAR}
                    case TEspecieDocumento.edNotaCreditoComercial: Registro.Append("08"); break;   //{NCC NOTA DE CRÉDITO COMERCIAL}
                    case TEspecieDocumento.edNotaCreditoExportacao: Registro.Append("09"); break;   //{NCE NOTA DE CRÉDITO A EXPORTAÇÃO}
                    case TEspecieDocumento.edNotaCreditoIndustrial: Registro.Append("10"); break;   //{NCI NOTA DE CRÉDITO INDUSTRIAL}
                    case TEspecieDocumento.edNotaCreditoRural: Registro.Append("11"); break;   //{NCR NOTA DE CRÉDITO RURAL}
                    case TEspecieDocumento.edNotaDebito: Registro.Append("19"); break;   //{ND  NOTA DE DÉBITO}
                    case TEspecieDocumento.edNotaPromissoria: Registro.Append("12"); break;   //{NP  NOTA PROMISSÓRIA}
                    case TEspecieDocumento.edNotaPromissoriaRural: Registro.Append("13"); break;   //{NPR NOTA PROMISSÓRIA RURAL}
                    case TEspecieDocumento.edNotaSeguro: Registro.Append("16"); break;   //{NS  NOTA DE SEGURO}
                    case TEspecieDocumento.edParcelaConsorcio: Registro.Append("22"); break;   //{PC  PARCELA DE CONSORCIO}
                    case TEspecieDocumento.edRecibo: Registro.Append("17"); break;   // {RC  RECIBO}
                    case TEspecieDocumento.edTriplicataMercantil: Registro.Append("14"); break;   //{TM  TRIPLICATA MERCANTIL}
                    case TEspecieDocumento.edTriplicataServico: Registro.Append("15"); break;   //{TS  TRIPLICATA DE SERVIÇO}
                    default: Registro.Append("99"); break; //{OUTROS}
                }
                switch (ACobranca.Titulos[NumeroRegistro].Aceite_documento) // {109 - Identificação de título Aceito / Não aceito}
                {
                    case TAceiteDocumento.adSim: Registro.Append("A"); break;
                    case TAceiteDocumento.adNao: Registro.Append("N"); break;
                }
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Dt_emissaobloqueto.Value.ToString("ddMMyyyy")); //{110 a 117 - Data da emissão do documento}
                if ((ACobranca.Titulos[NumeroRegistro].Vl_morajuros > 0))
                {
                    Registro.Append("1"); //{118 - Código de juros de mora: Valor por dia}
                    Registro.Append("".FormatStringEsquerda(8, '0'));    //{119 a 126 - Data a partir da qual serão cobrados juros}
                    Registro.Append((ACobranca.Titulos[NumeroRegistro].Vl_morajuros * 100).ToString("000000000000000")); //{127 a 141 - Valor de juros de mora por dia}
                }
                else
                {
                    Registro.Append("0");                //{118 - Código de juros de mora: Nao a juros}
                    Registro.Append("".FormatStringEsquerda(8, '0'));  //{119 a 126 - Data a partir da qual serão cobrados juros}
                    Registro.Append("".FormatStringEsquerda(15, '0')); //{127 a 141 - Valor de juros de mora por dia}
                }


                if (ACobranca.Titulos[NumeroRegistro].Vl_desconto > 0)
                {
                    Registro.Append("1"); //{142 - Código de desconto: Valor fixo até a data informada}
                    if (ACobranca.Titulos[NumeroRegistro].Nr_diasdesconto > decimal.Zero)
                        Registro.Append(Convert.ToDateTime(ACobranca.Titulos[NumeroRegistro].Dt_vencimento.Value.AddDays(Convert.ToDouble(ACobranca.Titulos[NumeroRegistro].Nr_diasdesconto) * -1)).ToString("ddmmyyyy")); //{143 a 150 - Data do desconto}
                    else
                        Registro.Append(Convert.ToDateTime(ACobranca.Titulos[NumeroRegistro].Dt_vencimento).ToString("ddmmyyyy")); //{143 a 150 - se não houver desconto, deve ser informada a mesma data do vencimento}
                    Registro.Append((ACobranca.Titulos[NumeroRegistro].Vl_desconto * 100).ToString("000000000000000")); //{151 a 165 - Valor do desconto por dia}
                }
                else
                {
                    Registro.Append("0"); //{142 - Código de desconto: Sem desconto}
                    Registro.Append("".FormatStringEsquerda(8, '0')); //{143 a 150 - se não houver desconto, deve ser informada a mesma data do vencimento}
                    Registro.Append("".FormatStringEsquerda(15, '0'));    // {151 a 165 - Valor do desconto por dia}
                }
                Registro.Append((ACobranca.Titulos[NumeroRegistro].Vl_iof * 100).ToString("000000000000000"));         //{166 a 180 - Valor do IOF a ser recolhido}
                Registro.Append((ACobranca.Titulos[NumeroRegistro].Vl_abatimento * 100).ToString("000000000000000"));  //{181 a 195 - Valor do abatimento}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].NumeroDocumento.FormatStringDireita(25, ' ')); //{196 a 220 - Identificação do título na empresa}


                if ((ACobranca.Titulos[NumeroRegistro].Dt_protesto != null) && (ACobranca.Titulos[NumeroRegistro].Dt_protesto > ACobranca.Titulos[NumeroRegistro].Dt_vencimento))
                {
                    Registro.Append("1"); //{221 - Código de protesto: Protestar em XX dias corridos}
                    Registro.Append((ACobranca.Titulos[NumeroRegistro].Dt_protesto.Value.Date.Subtract(ACobranca.Titulos[NumeroRegistro].Dt_vencimento.Value.Date).Days).ToString().FormatStringEsquerda(2, '0')); //{222 a 223 - Prazo para protesto (em dias corridos)}
                }
                else
                {
                    Registro.Append("3");               //{221 - Código de protesto: Não protestar}
                    Registro.Append("".FormatStringEsquerda(2, '0')); //{222 a 223 - Prazo para protesto (em dias corridos)}
                }

                if ((ACobranca.Titulos[NumeroRegistro].Dt_baixa != null) && (ACobranca.Titulos[NumeroRegistro].Dt_baixa.Value.Date > ACobranca.Titulos[NumeroRegistro].Dt_vencimento.Value.Date))
                {
                    Registro.Append("1"); //{224 - Código para baixa/devolução: Baixar/devolver}
                    Registro.Append((ACobranca.Titulos[NumeroRegistro].Dt_baixa.Value.Date.Subtract(ACobranca.Titulos[NumeroRegistro].Dt_vencimento.Value.Date).Days).ToString().FormatStringEsquerda(3, '0'));  //{225 a 227 - Prazo para baixa/devolução (em dias corridos)}
                }
                else
                {
                    Registro.Append("2"); //{224 - Código para baixa/devolução: Não baixar/não devolver}
                    Registro.Append("".FormatStringEsquerda(3, '0')); //{Prazo para baixa/devolução (225 a 227 - em dias corridos)}
                }

                Registro.Append("09"); //{228 a 229 - Código da moeda: Real}
                Registro.Append("".FormatStringDireita(10, ' ')); //{230 a 239 - Uso exclusivo FEBRABAN/CNAB}
                Registro.Append(" ");  // {240 - Uso exclusivo FEBRABAN/CNAB}
                Remessa.AppendLine(Registro.ToString());

                Registro.Remove(0, Registro.Length);  //limpar registro
                #endregion

                #region SEGMENTO Q
                Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0')); //{Código do banco}
                Registro.Append(NumeroLote.ToString().Trim().FormatStringEsquerda(4, '0')); //{Número do lote}
                Registro.Append("3");  // {Tipo do registro: Registro detalhe}
                Registro.Append((2 * NumeroRegistro + 2).ToString().FormatStringEsquerda(5, '0')); //{Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)}
                Registro.Append("Q");  // {Código do segmento do registro detalhe}
                Registro.Append(" ");  // {Uso exclusivo FEBRABAN/CNAB: Branco}
                Registro.Append(ACobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //{Dados do sacado}
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "2");
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.Nome.RemoverCaracteres().FormatStringDireita(40, ' '));
                Registro.Append((ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Rua + " " +
                             ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Numero + " " +
                             ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Complemento).RemoverCaracteres().FormatStringDireita(40, ' '));
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Bairro.RemoverCaracteres().FormatStringDireita(15, ' '));
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Cidade.RemoverCaracteres().FormatStringDireita(15, ' '));
                Registro.Append(ACobranca.Titulos[NumeroRegistro].Sacado.Endereco.Estado.FormatStringDireita(2, ' '));
                //{Dados do sacador/avalista}
                Registro.Append("0");     //{Tipo de inscrição: Não informado}
                Registro.Append("".FormatStringEsquerda(15, '0'));  //{Número de inscrição}
                Registro.Append("".FormatStringDireita(40, ' '));  //{Nome do sacador/avalista}

                Registro.Append("".FormatStringDireita(3, ' '));  //{Uso exclusivo FEBRABAN/CNAB}
                Registro.Append("".FormatStringDireita(20, ' ')); //{Uso exclusivo FEBRABAN/CNAB}
                Registro.Append("".FormatStringDireita(8, ' ')); //{Uso exclusivo FEBRABAN/CNAB}

                Remessa.AppendLine(Registro.ToString());
                #endregion

                NumeroRegistro += 1;
            }
            #endregion

            Registro.Remove(0, Registro.Length);  //limpar registro

            #region REGISTRO TRAILER DO LOTE
            Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0')); //{Código do banco}
            Registro.Append(NumeroLote.ToString().Trim().FormatStringEsquerda(4, '0')); // {Número do lote}
            Registro.Append("5"); // {Tipo do registro: Registro trailer do lote}
            Registro.Append("".FormatStringDireita(9, ' ')); //{Uso exclusivo FEBRABAN/CNAB}
            //{Quantidade de registros do lote, incluindo header e trailer do lote.
            // Até este momento Remessa contém:
            // 1 registro header de arquivo - É preciso excluí-lo desta contagem
            // 1 registro header de lote
            // Diversos registros detalhe
            // Falta incluir 1 registro trailer de lote
            // Ou seja Quantidade = Remessa.Count - 1 header de arquivo + 1 trailer de lote = Remessa.Count}

            Registro.Append(Remessa.Length.ToString().Trim().FormatStringEsquerda(6, '0'));
            //{Totalização da cobrança simples - Só é usado no arquivo retorno}
            Registro.Append("".FormatStringEsquerda(6, '0')); //{Quantidade títulos em cobrança}
            Registro.Append("".FormatStringEsquerda(17, '0')); //{Valor dos títulos em carteiras}
            //{Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("".FormatStringDireita(23, ' ')); //{Uso exclusivo FEBRABAN/CNAB}
            //{Totalização da cobrança caucionada - Só é usado no arquivo retorno}
            Registro.Append("".FormatStringEsquerda(6, '0')); //{Quantidade títulos em cobrança}
            Registro.Append("".FormatStringEsquerda(17, '0')); //{Valor dos títulos em carteiras}
            //{Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("".FormatStringEsquerda(31, ' '));   //{Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("".FormatStringEsquerda(117, ' '));  //{Uso exclusivo FEBRABAN/CNAB}

            Remessa.AppendLine(Registro.ToString());

            Registro.Remove(0, Registro.Length);  //limpar registro
            #endregion

            #region GERAR REGISTRO TRAILER DO ARQUIVO
            Registro.Append(CodigoBanco.Trim().FormatStringEsquerda(3, '0')); //{Código do banco}
            Registro.Append("9999"); //{Lote de serviço}
            Registro.Append("9"); //{Tipo do registro: Registro trailer do arquivo}
            Registro.Append("".FormatStringEsquerda(9, ' ')); //{Uso exclusivo FEBRABAN/CNAB}
            Registro.Append(NumeroLote.ToString().Trim().FormatStringEsquerda(6, '0')); //{Quantidade de lotes do arquivo}
            Registro.Append((Remessa.Length + 1).ToString().Trim().FormatStringEsquerda(6, '0')); //{Quantidade de registros do arquivo, inclusive este registro que está sendo criado agora}
            Registro.Append("".FormatStringDireita(6, ' ')); //{Uso exclusivo FEBRABAN/CNAB}
            Registro.Append("".FormatStringDireita(205, ' ')); //{Uso exclusivo FEBRABAN/CNAB}

            Remessa.AppendLine(Registro.ToString());
            #endregion
        }

        private bool LerRetornoCNAB240(blCobranca ACobranca, string[] Retorno)
        {
            string ACodigoBanco = string.Empty;
            string ANomeCedente = string.Empty;
            string ATipoInscricao = string.Empty;
            string ANumeroCPFCGC = string.Empty;
            string ACodigoCedente = string.Empty;
            string ADigitoCodigoCedente = string.Empty;
            string ACodigoAgencia = string.Empty;
            string ADigitoCodigoAgencia = string.Empty;
            string ANumeroConta = string.Empty;
            string ADigitoNumeroConta = string.Empty;

            int NumeroRegistro = 0;
            blTitulo ATitulo = null;
            try
            {
                //{ Lê registro HEADER}
                ACodigoBanco = Retorno[NumeroRegistro].Substring(0, 3).FormatStringEsquerda(3, '0');
                if (ACodigoBanco.Trim() != CodigoBanco.Trim())
                    throw new Exception("Este não é um retorno de cobrança do banco " + CodigoBanco.Trim() + " " + NomeBanco.Trim());
                if (Retorno[NumeroRegistro].Substring(7, 1).Trim() != "0")
                    throw new Exception("Este não é um registro HEADER válido para arquivo de retorno de cobrança com layout CNAB240");
                //{Dados do cedente do título}
                ATipoInscricao = Retorno[NumeroRegistro].Substring(17, 1);
                ANumeroCPFCGC = Retorno[NumeroRegistro].Substring(18, 14);
                ACodigoAgencia = Retorno[NumeroRegistro].Substring(52, 5);
                ADigitoCodigoAgencia = Retorno[NumeroRegistro].Substring(57, 1);
                ANumeroConta = Retorno[NumeroRegistro].Substring(58, 12);
                ADigitoNumeroConta = Retorno[NumeroRegistro].Substring(70, 1);
                ACodigoCedente = Retorno[NumeroRegistro].Substring(32, 20);
                ANomeCedente = Retorno[NumeroRegistro].Substring(72, 30);
                //Data geracao do arquivo retorno
                if(Retorno[NumeroRegistro].Substring(143, 8).FormatStringEsquerda(8, '0') != "00000000")
                    ACobranca.DataArquivo = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(147, 4)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(145, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(143, 2)));
                else
                    ACobranca.DataArquivo = DateTime.Now;
                //Numero do arquivo retorno
                if(Retorno[NumeroRegistro].Substring(157, 6).FormatStringEsquerda(6, '0') != "000000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(157, 6));
                else
                    ACobranca.SequencialArq = 0;

                NumeroRegistro = 1;

                //{Lê registro HEADER DE LOTE}
                //{Verifica se é um lote de retorno de cobrança}

                if (Retorno[NumeroRegistro].Substring(8, 3) != "T98")
                    throw new Exception("Este não é um lote de retorno de cobrança");
                //{Lê os registros DETALHE}

               NumeroRegistro++;
               //{Lê até o antepenúltimo registro porque o penúltimo contém apenas o TRAILER DO LOTE e o último contém apenas o TRAILER DO ARQUIVO}

               while (NumeroRegistro < (Retorno.Length - 2))
               {
                   //{Registro detalhe com tipo de segmento = J}
                   if(Retorno[NumeroRegistro].Substring(13, 1).Trim().Equals("J"))
                   {
                       //{Dados do titulo}
                       ATitulo = new blTitulo();
                       ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(202, 20);
                       //{Dados do cedente do título}
                       if(ATipoInscricao.Trim().Equals("1"))
                           ATitulo.Cedente.TipoInscricao = TTipoInscricao.tiPessoaFisica;
                       else if(ATipoInscricao.Trim().Equals("2"))
                           ATitulo.Cedente.TipoInscricao = TTipoInscricao.tiPessoaJuridica;
                       else
                           ATitulo.Cedente.TipoInscricao = TTipoInscricao.tiOutro;
                       ATitulo.Cedente.NumeroCPFCNPJ = ANumeroCPFCGC;
                       ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                       ATitulo.Cedente.DigitoCodigoCedente = ADigitoCodigoCedente;
                       ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                       ATitulo.Cedente.ContaBancaria.CodigoAgencia = ACodigoAgencia;
                       ATitulo.Cedente.ContaBancaria.DigitoAgencia = ADigitoCodigoAgencia;
                       ATitulo.Cedente.ContaBancaria.NumeroConta = ANumeroConta;
                       ATitulo.Cedente.ContaBancaria.DigitoConta = ADigitoNumeroConta;                                 
                       ATitulo.Cedente.Nome = ANomeCedente;
                       //Data Vencimento
                       if(Retorno[NumeroRegistro].Substring(91, 8).FormatStringEsquerda(8, '0') != "00000000")
                           ATitulo.Dt_vencimento = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(95, 4)),
                                                                Convert.ToInt32(Retorno[NumeroRegistro].Substring(93, 2)),
                                                                Convert.ToInt32(Retorno[NumeroRegistro].Substring(91, 1)));
                       else
                           ATitulo.Dt_vencimento = DateTime.Now;
                       //valor do titulo
                       if(Retorno[NumeroRegistro].Substring(99, 13).FormatStringEsquerda(13, '0') != "0000000000000")
                           ATitulo.Vl_documento = (Convert.ToDecimal(Retorno[NumeroRegistro].Substring(99,13))) / 100;
                       else
                           ATitulo.Vl_documento = decimal.Zero;
                       //Valor desconto + abatimento
                       if(Retorno[NumeroRegistro].Substring(114, 13).FormatStringEsquerda(13, '0') != "0000000000000")
                           ATitulo.Vl_desconto = (Convert.ToDecimal(Retorno[NumeroRegistro].Substring(114,13))) / 100;
                       else
                           ATitulo.Vl_desconto = decimal.Zero;
                       //Valor da Mora + Multa
                       if(Retorno[NumeroRegistro].Substring(129, 13).FormatStringEsquerda(13, '0') != "0000000000000")
                           ATitulo.Vl_morajuros = (Convert.ToDecimal(Retorno[NumeroRegistro].Substring(129,13))) / 100;
                       else
                           ATitulo.Vl_morajuros = decimal.Zero;
                       //Data do credito
                       if(Retorno[NumeroRegistro].Substring(144, 8).FormatStringEsquerda(8, '0') != "00000000")
                           ATitulo.Dt_credito = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(148, 4)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(146, 2)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(144, 2)));
                       else
                           ATitulo.Dt_credito = DateTime.Now;
                       NumeroRegistro++;
                       ACobranca.Titulos.Add(ATitulo);
                   }
               }
               return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ler arquivo retorno: " + ex.Message.Trim());
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
                ACodigoCedente = Convert.ToInt32(Retorno[NumeroRegistro].Substring(149, 7)).ToString();

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
                    //{Confirmar se o tipo do registro é 7}
                    if (Retorno[NumeroRegistro].Substring(0, 1) != "7")
                        continue; //{Não processa o registro atual}
                    //Dados Titulo
                    ATitulo = new blTitulo();
                    ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                    ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                    //Nosso numero
                    ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(63, 17);
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
                    if (Retorno[NumeroRegistro].Substring(181, 7).PadLeft(7, '0') != "0000000")
                        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(181, 7)) / 100;
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
                    string codigo = Retorno[NumeroRegistro].Substring(86, 2);
                    if (!string.IsNullOrEmpty(codigo) && codigo.Trim() != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(ATitulo.Cd_ocorrencia, codigo.Substring(0, 2)) + "|";
                    if (!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                        if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                            ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                    //Data credito
                    if (Retorno[NumeroRegistro].Substring(175, 6).Trim().PadLeft(6, '0') != "000000")
                    {
                        ATitulo.Dt_credito = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(179, 2)),
                                                           Convert.ToInt32(Retorno[NumeroRegistro].Substring(177, 2)),
                                                           Convert.ToInt32(Retorno[NumeroRegistro].Substring(175, 2)));
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

        public bool LerRetorno(blCobranca ACobranca, string[] arq)  //{Lê o arquivo retorno recebido do banco}
        {
            try
            {
                if (arq.Length <= 0)
                    throw new Exception("Arquivo retorno vazio. Não há dados para processar.");
                switch (ACobranca.LayoutArquivo)
                {
                    case TLayoutArquivo.laCNAB240:
                        return this.LerRetornoCNAB240(ACobranca, arq);
                    case TLayoutArquivo.laCNAB400:
                        return this.LerRetornoCNAB400(ACobranca, arq);
                    default: throw new Exception("Tamanho de registro invalido: " + arq.Length.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ler arquivo retorno: " + ex.Message.Trim());
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
            using (StreamWriter sw = new StreamWriter(Path_remessa + "C" + DateTime.Now.ToString("ddMMyy") + ".TXT"))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
