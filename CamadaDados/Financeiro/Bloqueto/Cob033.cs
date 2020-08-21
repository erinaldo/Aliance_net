using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.IO;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco033
    {
        const string CodigoBanco = "033";
        const string NomeBanco = "SANTANDER";

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantialIndicacao: return "01";
                case TEspecieDocumento.edDuplicataMercantil: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edNotaSeguro: return "03";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edLetraCambio: return "07";
                default: return "99";
            }
        }

        public string GetNomeBanco()
        {
            return NomeBanco;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        { return "9" + ATitulo.Cedente.CodigoCedente.Trim() + "00000" + ATitulo.Nosso_numero + ATitulo.Digito_NossoNumero + "0" + ATitulo.Modalidade; }

        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            return (vNossoNumero + 1).ToString().PadLeft(7, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            int digito_nossonumero = Estruturas.Mod11(ATitulo.Nosso_numero.Trim(), 9, true, 0);
            if (digito_nossonumero.Equals(0) || digito_nossonumero.Equals(1))
                return "0";
            else if (digito_nossonumero.Equals(00))
                return "1";
            else return (11 - digito_nossonumero).ToString();
        }

        public string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "01": return "TÍTULO NÃO EXISTE";
                case "02": return "ENTRADA TÍT.CONFIRMADA";
                case "03": return "ENTRADA TÍT.REJEITADA";
                case "06": return "LIQUIDAÇÃO";
                case "07": return "LIQUIDAÇÃO POR CONTA";
                case "08": return "LIQUIDAÇÃO POR SALDO";
                case "09": return "BAIXA AUTOMÁTICA";
                case "10": return "TÍT.BAIX.CONF.INSTRUÇÃO";
                case "11": return "EM SER";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "ALTERAÇÃO DE VENCIMENTO";
                case "15": return "CONFIRMAÇÃO DE PROTESTO";
                case "16": return "TÍT.JÁ BAIXADO / LIQUIDADO";
                case "17": return "LIQUIDADO EM CARTÓRIO";
                case "21": return "TÍT.ENVIADO A CARTÓRIO";
                case "22": return "TÍT.RETIRADO DE CARTÓRIO";
                case "24": return "CUSTAS DE CARTÓRIO";
                case "25": return "PROTESTAR TÍTULO";
                case "26": return "SUSTAR PROTESTO";
                case "35": return "TÍTULO DDA RECONHECIDO PELO PAGADOR";
                case "36": return "TÍTULO DDA NÃO RECONHECIDO PELO PAGADOR";
                case "37": return "TÍTULO DDA RECUSADO PELA CIP";
                case "38": return "RECEBIMENTO DA INSTRUÇÃO NÃO PROTESTAR";
                case "39": return "ESPÉCIE DE TÍTULO NÃO PERMITE A INSTRUÇÃO";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string ocorrencia, string codigo)
        {
            if (ocorrencia.Trim().ToUpper().Equals("01"))
                switch (codigo)
                {
                    case "004": return "CONTA COBRANCA NAO NUMERICA";
                    case "017": return "CODIGO DA AGENCIA COBRADORA NAO NUMERICA";
                    case "042": return "CONTA COBRANCA INVALIDA";
                    case "142": return "NUM.AG.CEDENTE/DIG.NAO NUMERICO";
                    case "143": return "NUM. CONTA CEDENTE/DIG. NAO NUMERICO";
                    case "371": return "TITULO REJEITADO - OPERACAO DE DESCONTO";
                    case "372": return "TIT. REJEITADO - HORARIO LIMITE OP DESCONTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("02"))
                switch (codigo)
                {
                    case "010": return "CODIGO PRIMEIRA INSTRUCAO NAO NUMERICA";
                    case "011": return "CODIGO SEGUNDA INSTRUCAO NAO NUMERICA";
                    case "019": return "NUMERO DO CEP NAO NUMERICO";
                    case "038": return "MOVIMENTO EXCLUIDO POR SOLICITACAO";
                    case "065": return "PEDIDO SUSTACAO JA SOLICITADO";
                    case "067": return "CLIENTE NAO TRANSMITE REG. DE OCORRENCIA";
                    case "077": return "DESC. POR ANTEC. MAIOR/IGUAL VLR TITULO";
                    case "125": return "COMPLEMENTO DA INSTRUCAO NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("04"))
                switch (codigo)
                {
                    case "039": return "PERFIL NAO ACEITA TITULO EM BCO CORRESP";
                    case "040": return "COBR RAPIDA NAO ACEITA-SE BCO CORRESP";
                    case "059": return "INSTRUCAO ACEITA SO P/ COBRANCA SIMPLES";
                    case "069": return "PRODUTO DIFERENTE DE COBRANCA SIMPLES";
                    case "170": return "FORMA DE CADASTRAMENTO 2 INV.P.CART.5";
                    case "201": return "ALT.DO CONTR.PARTICIPANTEINVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("05"))
                switch (codigo)
                {
                    case "070": return "DATA PRORROGACAO MENOR OUE DATA VENCTO";
                    case "071": return "DATA ANTECIPACAO MAIOR OUE DATA VENCTO";
                    case "072": return "DATA DOCUMENTO SUPERIOR A DATA INSTRUCAO";
                    case "088": return "DATA INSTRUCAO INVALIDA";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("06"))
                switch (codigo)
                {
                    case "018": return "VALOR DO IOC NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("07"))
                switch (codigo)
                {
                    case "026": return "CODIGO BANCO COBRADOR INVALIDO";
                    case "041": return "AGENCIA COBRADORA NAO ENCONTRADA";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("08"))
                switch (codigo)
                {
                    case "130": return "FORMA DE CADASTRAMENTO NAO NUMERICA";
                    case "131": return "FORMA DE CADASTRAMENTO INVALIDA";
                    case "132": return "FORMA CADAST. 2 INVALIDA PARA CARTEIRA 3";
                    case "133": return "FORMA CADAST. 2 INVALIDA PARA CARTEIRA 4";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("09"))
                switch (codigo)
                {
                    case "136": return "CODIGO BCO NA COMPENSACAO NAO NUMERICO";
                    case "137": return "CODIGO BCO NA COMPENSACAO INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("10"))
                switch (codigo)
                {
                    case "140": return "COD. SEOUEC.DO REG. DETALHE INVALIDO";
                    case "141": return "NUM. SEO. REG. DO LOTE NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("11"))
                switch (codigo)
                {
                    case "138": return "NUM. LOTE REMESSA(DETALHE) NAO NUMERICO";
                    case "139": return "TIPO DE REGISTRO INVALIDO";
                    case "164": return "NUMERO DO PLANO NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("12"))
                switch (codigo)
                {
                    case "202": return "ALT. DO SEU NUMERO INVALIDA";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("26"))
                switch (codigo)
                {
                    case "022": return "CODIGO OCORRENCIA INVALIDO";
                    case "134": return "CODIGO DO MOV. REMESSA NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("28"))
                switch (codigo)
                {
                    case "001": return "NOSSO NUMERO NAO NUMERICO";
                    case "050": return "NUMERO DO TITULO IGUAL A ZERO";
                    case "051": return "TITULO NAO ENCONTRADO";
                    case "092": return "NOSSO NUMERO JA CADASTRADO";
                    case "099": return "REGISTRO DUPLICADO NO MOVIMENTO DIARIO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().ToUpper().Equals("31"))
                switch(codigo)
                {
                    case "005": return "CODIGO DA CARTEIRA NAO NUMERICO";
                    case "006": return "CODIGO DA CARTEIRA INVALIDO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().ToUpper().Equals("32"))
                switch(codigo)
                {
                    case "003": return "DATA VENCIMENTO NAO NUMERICA";
                    case "016": return "DATA DE VENCIMENTO INVALIDA";
                    case "030": return "DT VENC MENOR DE 15 DIAS DA DT PROCES";
                    case "068": return "TIPO DE VENCIMENTO INVALIDO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().Equals("34"))
                switch(codigo)
                {
                    case "012": return "VALOR DO TITULO EM OUTRA UNIDADE";
                    case "013": return "VALOR DO TITULO NAO NUMERICO";
                    case "093": return "VALOR DO TITULO NAO INFORMADO";
                    case "094": return "VALOR TIT. EM OUTRA MOEDA NAO INFORMADO";
                    case "095": return "PERFIL NAO ACEITA VALOR TITULO ZERADO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().Equals("36"))
                switch(codigo)
                {
                    case "007": return "ESPECIE DO DOCUMENTO INVALIDA";
                    case "060": return "ESPECIE DOCUMENTO NAO PROTESTAVEL";
                    case "097": return "ESPECIE DOCTO NAO PERMITE IOC ZERADO";
                    case "129": return "ESPEC DE DOCUMENTO NAO NUMERICA";
                    case "144": return "TIPO DE DOCUMENTO NAO NUMERICO";
                    case "145": return "TIPO DE DOCUMENTO INVALIDO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().Equals("39"))
                switch (codigo)
                {
                    case "015": return "DATA EMISSAO NAO NUMERICA";
                    case "098": return "DATA EMISSAO INVALIDA";
                    case "100": return "DATA EMISSAO MAIOR OUE A DATA VENCIMENTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("41"))
                switch (codigo)
                {
                    case "149": return "CODIGO DE MORA INVALIDO";
                    case "150": return "CODIGO DE MORA NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("42"))
                switch (codigo)
                {
                    case "014": return "VALOR DE MORA NAO NUMERICO";
                    case "029": return "VALOR DE MORA INVALIDO";
                    case "109": return "VALOR MORA TEM OUE SER ZERO (TIT = ZERO)";
                    case "151": return "VL.MORA IGUAL A ZEROS P. COD.MORA 1";
                    case "152": return "VL. TAXA MORA IGUAL A ZEROS P.COD MORA 2";
                    case "153": return "VL. MORA DIFERENTE DE ZEROS P.COD.MORA 3";
                    case "154": return "VL. MORA NAO NUMERICO P. COD MORA 2";
                    case "155": return "VL. MORA INVALIDO P. COD.MORA 4";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("44"))
                switch (codigo)
                {
                    case "086": return "DATA SEGUNDO DESCONTO INVALIDA";
                    case "087": return "DATA TERCEIRO DESCONTO INVALIDA";
                    case "110": return "DATA PRIMEIRO DESCONTO INVALIDA";
                    case "111": return "DATA DESCONTO NAO NUMERICA";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("45"))
                switch (codigo)
                {
                    case "025": return "VALOR DESCONTO NAO NUMERICO";
                    case "074": return "PRIM. DESGONTO MAIOR/IGUAL VALOR TITULO";
                    case "075": return "SEG. DESCONTO MAIOR/IGUAL VALOR TITULO";
                    case "076": return "TERC. DESCONTO MAIOR/IGUAL VALOR TITULO";
                    case "077": return "DESC. POR ANTEC. MAIOR/IGUAL VLR TITULO";
                    case "079": return "NAO EXISTE PRIM. DESCONTO P/ CANCELAR";
                    case "080": return "NAO EXISTE SEG. DESCONTO P/ CANCELAR";
                    case "081": return "NAO EXISTE TERC. DESCONTO P/ CANCELAR";
                    case "082": return "NAO EXISTE DESC. POR ANTEC. P/ CANCELAR";
                    case "090": return "JA EXISTE DESCONTO POR DIA ANTECIPACAO";
                    case "091": return "JA EXISTE CONCESSAO DE DESCONTO";
                    case "112": return "VALOR DESCONTO NAO INFORMADO";
                    case "113": return "VALOR DESCONTO INVALIDO";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().Equals("46"))
                switch(codigo)
                {
                    case "122": return "VALOR IOF MAIOR OUE VALOR TITULO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("47"))
                switch (codigo)
                {
                    case "002": return "VALOR DO ABATIMENTO NAO NUMERICO";
                    case "114": return "VALOR ABATIMENTO NAO INFORMADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("48"))
                switch (codigo)
                {
                    case "128": return "CODIGO PROTESTO INVALIDO";
                    case "146": return "CODIGO P. PROTESTO NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("49"))
                switch (codigo)
                {
                    case "046": return "QTD DE DIAS PROTESTO NAO PREENCHIDO";
                    case "147": return "QTDE DE DIAS P. PROTESTO INVALIDO";
                    case "148": return "QTDE DE DIAS P. PROTESTO NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("52"))
                switch (codigo)
                {
                    case "045": return "QTD DE DIAS DE BAIXA NAO PREENCHIDO";
                    case "156": return "QTDE DIAS P.BAIXA/DEVOL. NAO NUMERICO";
                    case "157": return "QTDE DIAS BAIXA/DEV. INVALIDO P. COD. 1";
                    case "158": return "QTDE DIAS BAIXA/DEV. INVALIDO P.COD. 2";
                    case "159": return "OTDE DIAS BAIXA/DEV.INVALIDO P.COD. 3";
                    default: return string.Empty;
                }
            else if(ocorrencia.Trim().Equals("53"))
                switch(codigo)
                {
                    case "008": return "UNIDADE DE VALOR NAO NUMERICA";
                    case "009": return "UNIDADE DE VALOR INVALIDA";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("55"))
                switch (codigo)
                {
                    case "024": return "TOTAL PARCELA NAO NUMERICO";
                    case "027": return "NUMERO PARCELAS CARNE NAO NUMERICO";
                    case "028": return "NUMERO PARCELAS CARNE ZERADO";
                    case "047": return "TOT PARC. INF. NAO BATE Cl OTD PARC GER";
                    case "048": return "CARNE COM PARCELAS COM ERRO";
                    case "049": return "SEU NUMERO NAO CONFERE COM O CARNE";
                    case "162": return "INDICADOR DE CARNE NAO NUMERICO";
                    case "163": return "NUM. TOTAL DE PARC.CARNE NAO NUMERICO";
                    case "165": return "INDICADOR DE PARCELAS CARNE INVALIDO";
                    case "168": return "N.TOT.PARC.INV.P.INDIC. MAIOR ZEROS";
                    case "169": return "NUM.TOT.PARC.INV.P.INDIC.DIFER.ZEROS";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("57"))
                switch (codigo)
                {
                    case "166": return "N.SEO. PARCELA INV.P.INDIC. MAIOR 0";
                    case "167": return "N. SEO.PARCELA INV.P.INDIC.DIF.ZEROS";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("59"))
                switch (codigo)
                {
                    case "020": return "TIPO INSCRICAO NAO NUMERICO";
                    case "021": return "NUMERO DO CGC OU CPF NAO NUMERICO";
                    case "058": return "CGC/CPF INCORRETO";
                    case "105": return "TIPO INSCRICAO NAO EXISTE";
                    case "106": return "CGCICPF NAO INFORMADO";
                    case "108": return "DIGITO CGC/CPF INCORRETO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("61"))
                switch (codigo)
                {
                    case "101": return "NOME DO SACADO NAO INFORMADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("62"))
                switch (codigo)
                {
                    case "019": return "NUMERO DO CEP NAO NUMERICO";
                    case "057": return "CEP DO SACADO INCORRETO";
                    case "063": return "CEP NAO ENCONTRADO NA TABELA DE PRACAS";
                    case "123": return "CEP DO SACADO NAO NUMERICO";
                    case "124": return "CEP SACADO NAO ENCONTRADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("63"))
                switch (codigo)
                {
                    case "102": return "ENDERECO DO SACADO NAO INFORMADO";
                    case "160": return "BAIRRO DO SACADO NAO INFORMADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("64"))
                switch (codigo)
                {
                    case "103": return "MUNICIPIO DO SACADO NAO INFORMADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("65"))
                switch (codigo)
                {
                    case "104": return "UNIDADE DA FEDERACAO NAO INFORMADA";
                    case "107": return "UNIDADE DA FEDERACAO";
                    case "108": return "DIGITO CGC/CPF INCORRETO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("66"))
                switch (codigo)
                {
                    case "161": return "TIPO INSC.CPF/CGC SACADOR/AVAL.NAO NUM.";
                    case "199": return "TIPO INSC.CGC/CPF SACADOR.AVAL.INVAL.";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("67"))
                switch (codigo)
                {
                    case "200": return "NUM.INSC.(CGC)SACADOR/AVAL.NAO NUMERICO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("71"))
                switch (codigo)
                {
                    case "084": return "JA EXISTE SEGUNDO DESCONTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("74"))
                switch (codigo)
                {
                    case "085": return "JA EXISTE TERCEIRO DESCONTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("76"))
                switch (codigo)
                {
                    case "089": return "DATA MULTA MENOR/IGUAL OUE VENCIMENTO";
                    case "116": return "DATA MULTA NAO NUMERICA";
                    case "118": return "DATA MULTA NAO INFORMADA";
                    case "119": return "DATA MULTA MAIOR OUE DATA DE VENCIMENTO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("77"))
                switch (codigo)
                {
                    case "083": return "NAO EXISTE MULTA POR ATRASO P/ CANCELAR";
                    case "120": return "PERCENTUAL MULTA NAO NUMERICO";
                    case "121": return "PERCENTUAL MULTA NAO INFORMADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("80"))
                switch (codigo)
                {
                    case "053": return "OCOR. NAO ACATADA, TITULO BAIXADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("81"))
                switch (codigo)
                {
                    case "052": return "OCOR. NAOACATADA,TITULO LIOUIDADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("84"))
                switch (codigo)
                {
                    case "056": return "OCOR. NAO ACATADA, TIT. NAO VENCIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("89"))
                switch (codigo)
                {
                    case "062": return "SACADO NAO PROTESTAVEL";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("90"))
                switch (codigo)
                {
                    case "073": return "ABATIMENTO MAIOR/IGUAL AO VALOR TITULO";
                    case "115": return "VALOR ABATIMENTO MAIOR VALOR TITULO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("91"))
                switch (codigo)
                {
                    case "117": return "VALOR DESCONTO MAIOR VALOR TITULO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("92"))
                switch (codigo)
                {
                    case "078": return "NAO EXISTE ABATIMENTO P/ CANCELAR";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("93"))
                switch (codigo)
                {
                    case "043": return "NAO BAIXAR, COMPL. INFORMADO INVALIDO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().Equals("94"))
                switch (codigo)
                {
                    case "044": return "NAO PROTESTAR, COMPL. INFORMADO INVALIDO";
                    case "054": return "TITULO COM ORDEM DE PROTESTO JA EMITIDA";
                    case "055": return "OCOR. NAO ACATADA, TITULO JA PROTESTADO";
                    case "061": return "CEDENTE SEM CARTA DE PROTESTO";
                    case "064": return "TIPO DE COBRANCA NAO PERMITE PROTESTO";
                    case "066": return "SUSTACAO PROTESTO FORA DE PRAZO";
                    case "096": return "ESPECIE DOCTO NAO PERMITE PROTESTO";
                    default: return string.Empty;
                }
            else return string.Empty;
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
            //Codigo Transmissão 027-046
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia +
                             aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(8, '0') +
                             (aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.Length > 8 ?
                             aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.Substring(0, 8) :
                             aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0')));
            //Nome Empresa 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.FormatStringDireita(30, ' '));
            //Numero Banco Camara Compensacao 077-079
            registros.Append(CodigoBanco.Trim());
            //Nome Banco Extenso 080-094
            registros.Append(NomeBanco.FormatStringDireita(15, ' '));
            //Data Arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Brancos 101-116
            registros.Append("".FormatStringDireita(16, '0'));
            //Mensagem 1 117-163
            registros.Append("".FormatStringDireita(47, ' '));
            //Mensagem 2 164-210
            registros.Append("".FormatStringDireita(47, ' '));
            //Mensagem 3 211-257
            registros.Append("".FormatStringDireita(47, ' '));
            //Mensagem 4 258-304
            registros.Append("".FormatStringDireita(47, ' '));
            //Mensagem 5 305-351
            registros.Append("".FormatStringDireita(47, ' '));
            //Brancos 352-391
            registros.Append("".FormatStringDireita(40, ' '));
            //Numero versão remessa <opcional> 392-394
            registros.Append("000");
            //Sequencial do registro 395-400
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
                //Tipo Inscrição Beneficiario 002-003
                registros.Append(p.Cedente.TipoInscricao == TTipoInscricao.tiPessoaJuridica ? "02" : "01");
                //CNPJ/CPF 004-017
                registros.Append(p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Agencia Beneficiario 018-021
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia);
                //Codigo Cedente 022-029
                registros.Append(p.Cedente.CodigoCedente.Length > 8 ? p.Cedente.CodigoCedente.Substring(0, 8) : p.Cedente.CodigoCedente.FormatStringEsquerda(8, '0'));
                //Conta Corrente 030-037
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.Length > 8 ? p.Cedente.ContaBancaria.NumeroConta.Substring(0, 8) : p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0'));
                //Numero controle do participante 038-062
                registros.Append("".FormatStringDireita(25, ' '));
                //Nosso Numero 063-070
                registros.Append(p.Nosso_numero + p.Digito_NossoNumero);
                //Data Segundo Desconto 071-076
                registros.Append("000000");
                //Brancos 077-077
                registros.Append(" ");
                //Multa 078-078
                registros.Append(p.Pc_multa > decimal.Zero ? "4" : "0");
                //% Multa 079-082
                registros.Append(p.Pc_multa.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(4, '0'));
                //Unidade valor moeda 083-084
                registros.Append("00");
                //Valor titulo outra unidade 085-097
                registros.Append("".FormatStringEsquerda(13, '0'));
                //Brancos 098-101
                registros.Append("".FormatStringDireita(4, ' '));
                //Data Multa 102-107
                registros.Append(p.Nr_diasmulta > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasmulta)).ToString("ddMMyy") : "000000");
                //Carteira 108-108
                registros.Append(p.Carteira);//5-Rapida com Registro(boleto emitido pelo cliente)
                //Instrução 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Seu numero 111-120
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(10, '0'));
                //Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor titulo 127-139
                registros.Append(p.Vl_documento.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(13, '0'));
                //Numero banco cobrador 140-142
                registros.Append(CodigoBanco);
                //Agencia cobradora 143-147
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia + p.Cedente.ContaBancaria.DigitoAgencia);
                //Especie Documento 148-149
                registros.Append(ConverterEspecieDoc(p.Especie_documento));
                //Aceite 150-150
                registros.Append(p.Aceite_SN);
                //Data Emissao 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Primeira instrução cobranca 157-158
                registros.Append("00");
                //Segunda instrução cobrança 159-160
                registros.Append(p.St_protestarauto ? "06" : "00");
                //Valor juro por dia atraso 161-173
                decimal ret = decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100);
                registros.Append((p.Tp_jurodia.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100) : p.Pc_jurodia).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(13, '0'));
                //Data limite desconto 174-179
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                //Valor desconto 180-192
                registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(13, '0'));
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
                //Bairro Sacado 315-326
                registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().FormatStringDireita(12, ' '));
                //CEP Sacado 327-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                //Municipio Sacado 335-349
                registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().FormatStringDireita(15, ' '));
                //UF Sacado 350-351
                registros.Append(p.Sacado.Endereco.Estado.RemoverCaracteres().FormatStringDireita(2, ' '));
                //Brancos 352-382
                registros.Append("".FormatStringDireita(31, ' '));
                //Identificador do complemento 383-383
                registros.Append("I");
                //Complemento 384-385
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.Substring(p.Cedente.ContaBancaria.NumeroConta.Length - 1, 1) + p.Cedente.ContaBancaria.DigitoConta);
                //Brancos 386-391
                registros.Append("".FormatStringDireita(6, ' '));
                //Numero dias para protesto 392-393
                registros.Append(p.St_protestarauto ? p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "00");
                //Brancos 394-394
                registros.Append(" ");
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
            //Quantidade Documentos 002-007
            registros.Append(aCobranca.Titulos.Count.FormatStringEsquerda(6, '0'));
            //Valor Documentos 008-020
            registros.Append(aCobranca.Titulos.Sum(p => p.Vl_documento).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(13, '0'));
            //Zeros 021-394
            registros.Append("".FormatStringEsquerda(374, '0'));
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
            if (!Directory.Exists(Path_remessa))
                throw new Exception("Path salvar arquivo remessa invalido.");
            if (Path_remessa.Substring(Path_remessa.Length - 1, 1) != Path.DirectorySeparatorChar.ToString())
                Path_remessa += Path.DirectorySeparatorChar.ToString();
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
            using (StreamWriter sw = new StreamWriter(Path_remessa +
                                                      ACobranca.DataArquivo.Day.FormatStringEsquerda(2, '0') +
                                                      ACobranca.DataArquivo.Month.FormatStringEsquerda(2, '0') +
                                                      (obj == null ? "01" : decimal.Parse(obj.ToString() + 1).FormatStringEsquerda(2, '0')) +
                                                      ".TXT"))
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
                ACodigoCedente = Convert.ToInt32(Retorno[NumeroRegistro].Substring(30, 8)).ToString();

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
                    ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(62, 7);
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
                    //Valor tarifa
                    if (Retorno[NumeroRegistro].Substring(175, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(175, 13)) / 100;
                    //Valor despesas
                    if (Retorno[NumeroRegistro].Substring(188, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(188, 13)) / 100;
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
                    if (Retorno[NumeroRegistro].Substring(134, 2) != "00")
                    {
                        string codigo = Retorno[NumeroRegistro].Substring(136, 9);
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            if (!string.IsNullOrEmpty(codigo.Substring(0, 3)))
                                ATitulo.Ds_motivoocorrencia += TratarMotivo(Retorno[NumeroRegistro].Substring(134, 2), codigo.Substring(0, 3)) + "|";
                            if (!string.IsNullOrEmpty(codigo.Substring(3, 3)))
                                ATitulo.Ds_motivoocorrencia += TratarMotivo(Retorno[NumeroRegistro].Substring(134, 2), codigo.Substring(3, 3)) + "|";
                            if (!string.IsNullOrEmpty(codigo.Substring(6, 3)))
                                ATitulo.Ds_motivoocorrencia += TratarMotivo(Retorno[NumeroRegistro].Substring(134, 2), codigo.Substring(6, 3));
                        }
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
