using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.IO;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco748
    {
        const string CodigoBanco = "748";
        const string NomeBanco = "SICREDI";

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantialIndicacao: return "A";
                case TEspecieDocumento.edDuplicataMercantil: return "A";
                case TEspecieDocumento.edDuplicataRural: return "B";
                case TEspecieDocumento.edNotaPromissoria: return "C";
                case TEspecieDocumento.edNotaPromissoriaRural: return "D";
                case TEspecieDocumento.edNotaSeguro: return "E";
                case TEspecieDocumento.edRecibo: return "G";
                case TEspecieDocumento.edLetraCambio: return "H";
                case TEspecieDocumento.edNotaDebito: return "I";
                case TEspecieDocumento.edDuplicataServicoIndicacao: return "J";
                default: return "K";
            }
        }

        private string CodigoMes(int Mes)
        {
            switch (Mes)
            {
                case (1): return "1";
                case (2): return "2";
                case (3): return "3";
                case (4): return "4";
                case (5): return "5";
                case (6): return "6";
                case (7): return "7";
                case (8): return "8";
                case (9): return "9";
                case (10): return "O";
                case (11): return "N";
                case (12): return "D";
                default: return string.Empty;
            }
        }

        public string GetNomeBanco()
        {
            return NomeBanco;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            string nosso_numero = ATitulo.Nosso_numero.Trim() + CalcularDigitoNossoNumero(ATitulo);
            string cl = (ATitulo.Tp_cobranca.Trim().ToUpper().Equals("CR") ? "1" : "3") +//Tipo de cobranca
                        ATitulo.Carteira.Trim() +//Tipo carteira 1 - cobranca simples
                        nosso_numero.Trim().Remove(nosso_numero.Trim().LastIndexOf("/"), 1) +//Nosso numero
                        ATitulo.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0') +//Agencia
                        ATitulo.Cedente.Postocedente.Trim() +//Posto
                        ATitulo.Cedente.CodigoCedente.Trim() +//Codigo cedente
                        "1" +//Valor expresso no campo valor documento
                        "0";//Filler
            return cl.Trim() + Utils.Estruturas.Mod11(cl.Trim(), 9, false, 0).ToString().Trim();
        }

        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            //Formula para calculo nosso numero
            //YY    - Ano da geracao do titulo
            //B     - Geracao do nosso numero (1 - Sicredi / 2 a 9 - Cedente
            //nnnnn - Numero sequencial do cedente
            //d     - Digito verificador
            return DateTime.Now.ToString("dd/MM/yyyy").Substring(8, 2) + "/2" + (vNossoNumero + 1).ToString().PadLeft(5, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            string ret = Utils.Estruturas.Mod11(ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim().PadLeft(4, '0') +
                                          ATitulo.Cedente.Postocedente.Trim().PadLeft(2, '0') +
                                          ATitulo.Cedente.CodigoCedente.Trim().PadLeft(5, '0') +
                                          ATitulo.Nosso_numero.Trim().Remove(ATitulo.Nosso_numero.Trim().LastIndexOf("/"), 1), 9, false, 0).ToString().Trim();
            return ret;
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

        public string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "02": return "ENTRADA CONFIRMADA";
                case "03": return "ENTRADA REJEITADA";
                case "06": return "LIQUIDAÇÃO NORMAL";
                case "09": return "BAIXADO AUTOMATICAMENTE VIA ARQUIVO";
                case "10": return "BAIXADO CONFORME INSTRUÇÕES DA COOPERATIVA DE CREDITO";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "VENCIMENTO ALTERADO";
                case "15": return "LIQUIDAÇÃO EM CARTORIO";
                case "17": return "LIQUIDAÇÃO APÓS BAIXA";
                case "19": return "CONFIRMAÇÃO DE RECEBIMENTO DE INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMAÇÃO DE RECEBIMENTO DE INSTRUÇÃO DE SUSTAÇÃO DE PROTESTO";
                case "23": return "ENTRADA DE TITULO EM CARTORIO";
                case "24": return "ENTRADA REJEITADA POR CEP IRREGULAR";
                case "27": return "BAIXA REJEITADA";
                case "28": return "TARIFA";
                case "30": return "ALTERAÇÃO REJEITADA";
                case "32": return "INSTRUÇÃO REJEITADA";
                case "33": return "CONFIRMAÇÃO DE PEDIDO DE ALTERAÇÃO DE OUTROS DADOS";
                case "34": return "RETIRADO DE CARTORIO E MANUTENÇÃO EM CARTEIRA";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string codigo)
        {
            switch(codigo)
            {
                case "01": return "CODIGO DO BANCO INVALIDO";
                case "02": return "CODIGO DO REGISTRO DETALHE INVALIDO";
                case "03": return "CODIGO DA OCORRENCIA INVALIDO";
                case "04": return "CODIGO DE OCORRENCIA NÃO PERMITIDA PARA A CARTEIRA";
                case "05": return "CODIGO DE OCORRENCIA NÃO NUMERICO";
                case "07": return "COOPERATIVA/AGENCIA/CONTA/DIGITOS INVALIDOS";
                case "08": return "NOSSO NUMERO INVALIDO";
                case "09": return "NOSSO NUMERO DUPLICADO";
                case "10": return "CARTEIRA INVALIDA";
                case "14": return "TITULO PROTESTADO";
                case "15": return "COOPERATIVA/CARTEIRA/AGENCIA/CONTA/NOSSO NUMERO INVALIDOS";
                case "16": return "DATA DE VENCIMENTO INVALIDA";
                case "17": return "DATA DE VENCIMENTO ANTERIOR A DATA DE EMISSÃO";
                case "18": return "VENCIMENTO FORA DO PRAZO DE OPERAÇÃO";
                case "20": return "VALOR DO TITULO INVALIDO";
                case "21": return "ESPECIE DO TITULO INVALIDA";
                case "22": return "ESPECIE NÃO PERMITIDA PARA A CARTEIRA";
                case "24": return "DATA DE EMISSÃO INVALIDA";
                case "29": return "VALOR DO DESCONTO MAIOR/IGUAL AO VALOR DO TITULO";
                case "31": return "CONCESSÃO DE DESCONTO - EXISTE DESCONTO ANTERIOR";
                case "33": return "VALOR DO ABATIMENTO INVALIDO";
                case "34": return "VALOR DO ABATIMENTO MAIOR/IGUAL AO VALOR DO TITULO";
                case "36": return "CONCESSÃO DE ABATIMENTO - EXISTE ABATIMENTO ANTERIOR";
                case "38": return "PRAZO PARA PROTESTO INVALIDO";
                case "39": return "PEDIDO PARA PROTESTO NÃO PERMITIDO PARA O TITULO";
                case "40": return "TITULO COM ORDEM DE PROTESTO EMITIDA";
                case "41": return "PEDIDO CANCELAMENTO/SUSTAÇÃO SEM INSTRUÇÃO DE PROTESTO";
                case "44": return "COOPERATIVA DE CREDITO/AGENCIA CEDENTE NÃO PREVISTA";
                case "45": return "NOME DO SACADO INVALIDO";
                case "46": return "TIPO/NUMERO DE INSCRIÇÃO DO SACADO INVALIDO";
                case "47": return "ENDEREÇO DO SACADO NÃO INFORMADO";
                case "48": return "CEP IRREGULAR";
                case "49": return "NUMERO DE INSCRIÇÃO DO SACADOR/AVALISTA INVALIDO";
                case "50": return "SACADOR/AVALISTA NÃO INFORMADO";
                case "60": return "MOVIMENTO PARA TITULO NÃO CADASTRADO";
                case "63": return "ENTRADA PARA TITULO NÃO CADASTRADO";
                case "A": return "ACEITO";
                case "D": return "DESPREZADO";
                case "A1": return "PRAÇA DO SACADO NÃO CADASTRADA";
                case "A2": return "TIPO DE COBRANÇA DO TITULO DIVERGENTE COM A PRAÇA DO SACADO";
                case "A3": return "COOPERATIVA/AGENCIA DEPOSITARIA DIVERGENTE";
                case "A4": return "CEDENTE NÃO CADASTRADO OU POSSUI CNPJ INVALIDO";
                case "A5": return "SACADO NÃO CADASTRADO";
                case "A6": return "DATA DE INSTRUÇÃO/OCORRENCIA INVALIDA";
                case "A7": return "OCORRENCIA NÃO PODE SER COMANDADA";
                case "A8": return "RECEBIMENTO DA LIQUIDAÇÃO FORA DA REDE SICREDI";
                case "B4": return "TIPO DE MOEDA INVALIDO";
                case "B5": return "TIPO DE DESCONTO/JUROS INVALIDO";
                case "B6": return "MENSAGEM PADRÃO NÃO CADASTRADA";
                case "B7": return "SEU NUMERO INVALIDO";
                case "B8": return "PERCENTUAL DE MULTA INVALIDO";
                case "B9": return "VALOR OU PERCENTUAL DE JUROS INVALIDO";
                case "C1": return "DATA LIMITE PARA CONCESSÃO DE DESCONTO INVALIDA";
                case "C2": return "ACEITE DO TITULO INVALIDO";
                case "C3": return "Campo alterado na instrução <31 – alteração de outros dados> inválido";
                case "C4": return "Título ainda não foi confirmado pela centralizadora";
                case "C5": return "Título rejeitado pela centralizadora";
                case "C6": return "Título já liquidado";
                case "C7": return "Título já baixado";
                case "C8": return "Existe mesma instrução pendente de confirmação para este título";
                case "C9": return "Instrução prévia de concessão de abatimento não existe ou não confirmada";
                case "D1": return "Título dentro do prazo de vencimento (em dia)";
                case "D2": return "Espécie de documento não permite protesto de título";
                case "D3": return "Título possui instrução de baixa pendente de confirmação";
                case "D4": return "Quantidade de mensagens padrão excede o limite permitido";
                case "D5": return "Quantidade inválida no pedido de bloquetos pré-impressos da cobrança sem registro";
                case "D6": return "Tipo de impressão inválida para cobrança sem registro";
                case "D7": return "Cidade ou Estado do sacado não informado";
                case "D8": return "Seqüência para composição do nosso número do ano atual esgotada";
                case "D9": return "Registro mensagem para título não cadastrado";
                case "E2": return "Registro complementar ao cadastro do título da cobrança com e sem registro não cadastrado";
                case "E3": return "Tipo de postagem inválido, diferente de S, N e branco";
                case "E4": return "Pedido de bloquetos pré-impressos";
                case "E5": return "Confirmação/rejeição para pedidos de bloquetos não cadastrado";
                case "E6": return "Sacador/avalista não cadastrado";
                case "E7": return "Informação para atualização do valor do título para protesto inválido";
                case "E8": return "Tipo de impressão inválido, diferente de A, B e branco";
                case "E9": return "Código do sacado do título divergente com o código da cooperativa de crédito";
                case "F1": return "Liquidado no sistema do cliente";
                case "F2": return "Baixado no sistema do cliente";
                case "F3": return "Instrução inválida, este título está caucionado";
                case "F4": return "Instrução fixa com caracteres inválidos";
                case "F6": return "Nosso número / número da parcela fora de seqüência – total de parcelas inválido";
                case "F7": return "Falta de comprovante de prestação de serviço";
                case "F8": return "Nome do cedente incompleto / incorreto.";
                case "F9": return "CNPJ / CPF incompatível com o nome do sacado / sacador avalista";
                case "G1": return "CNPJ / CPF do sacador Incompatível com a espécie";
                case "G2": return "Título aceito: sem a assinatura do sacado";
                case "G3": return "Título aceito: rasurado ou rasgado";
                case "G4": return "Título aceito: falta título (cooperativa/ag. cedente deverá enviá-lo)";
                case "G5": return "Praça de pagamento incompatível com o endereço";
                case "G6": return "Título aceito: sem endosso ou cedente irregular";
                case "G7": return "Título aceito: valor por extenso diferente do valor numérico";
                case "G8": return "Saldo maior que o valor do título";
                case "G9": return "Tipo de endosso inválido";
                case "H1": return "Nome do sacador incompleto / Incorreto";
                case "H2": return "Sustação judicial";
                case "H3": return "Sacado não encontrado";
                case "H4": return "Alteração de carteira";
                case "H5": return "Recebimento de liquidação fora da rede SICREDI – VLB Inferior – Via Compensação";
                case "H6": return "Recebimento de liquidação fora da rede SICREDI – VLB Superior – Via Compensação";
                case "H7": return "Espécie de documento necessita cedente ou avalista PJ";
                case "H8": return "Recebimento de liquidação fora da rede SICREDI – Contingência Via Compe";
                case "H9": return "Dados do título não conferem com disquete";
                case "I1": return "Sacado e sacador avalista são a mesma pessoa";
                case "I2": return "Aguardar um dia útil após o vencimento para protestar";
                case "I3": return "Data do vencimento rasurada";
                case "I4": return "Vencimento – extenso não confere com número";
                case "I5": return "Falta data de vencimento no título";
                case "I6": return "DM/DMI sem comprovante autenticado ou declaração";
                case "I7": return "Comprovante ilegível para conferência e microfilmagem";
                case "I8": return "Nome solicitado não confere com emitente ou sacado";
                case "I9": return "Confirmar se são 2 emitentes. Se sim, indicar os dados dos 2";
                case "J1": return "Endereço do sacado igual ao do sacador ou do portador";
                case "J2": return "Endereço do apresentante incompleto ou não informado";
                case "J3": return "Rua/número inexistente no endereço";
                case "J4": return "Falta endosso do favorecido para o apresentante";
                case "J5": return "Data da emissão rasurada";
                case "J6": return "Falta assinatura do sacador no título";
                case "J7": return "Nome do apresentante não informado/incompleto/incorreto";
                case "J8": return "Erro de preenchimento do titulo";
                case "J9": return "Titulo com direito de regresso vencido";
                case "K1": return "Titulo apresentado em duplicidade";
                case "K2": return "Titulo já protestado";
                case "K3": return "Letra de cambio vencida – falta aceite do sacado";
                case "K4": return "Falta declaração de saldo assinada no título";
                case "K5": return "Contrato de cambio – Falta conta gráfica";
                case "K6": return "Ausência do documento físico";
                case "K7": return "Sacado falecido";
                case "K8": return "Sacado apresentou quitação do título";
                case "K9": return "Título de outra jurisdição territorial";
                case "L1": return "Título com emissão anterior a concordata do sacado";
                case "L2": return "Sacado consta na lista de falência";
                case "L3": return "Apresentante não aceita publicação de edital";
                case "L4": return "Dados do Sacado em Branco ou inválido";
                case "L5": return "Código do Sacado na agência cedente está duplicado";
                case "X1": return "Regularização centralizadora – Rede SICREDI";
                case "X2": return "Regularização centralizadora – Compensação";
                case "X3": return "Regularização centralizadora – Banco correspondente";
                case "X4": return "Regularização centralizadora - VLB Inferior - via compensação";
                case "X5": return "Regularização centralizadora - VLB Superior - via compensação";
                default: return string.Empty;
            }
        }

        public string TratarMotivoTaxa(string codigo)
        {
            switch (codigo)
            {
                case "03": return "TARIFA DE SUSTAÇÃO";
                case "04": return "TARIFA DE PROTESTO";
                case "08": return "TARIFA DE CUSTAS DE PROTESTO";
                case "A9": return "TARIFA DE MANUTENÇÃO DE TITULO VENCIDO";
                case "B1": return "TARIFA DE BAIXA DE CARTEIRRA";
                case "B2": return "TARIFA DE RATEIO DOS CUSTOS DE IMPRESSÃO COMPLETA DE BLOQUETOS";
                case "B3": return "TARIFA DE REGISTRO DE ENTRADA DO TITULO";
                case "F5": return "TARIFA DE ENTRADA NA REDE SICREDI";
                case "E1": return "TARIFA DE RATEIO IMPRESSÃO COMPLETA POSTA NÃO";
                default: return string.Empty;
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
            //Codigo cedente 027-031
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(5, '0'));
            //CNPJ cedente 032-045
            registros.Append(aCobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
            //Filler 046-076
            registros.Append(string.Empty.FormatStringDireita(31, ' '));
            //Numero Sicredi 077-079
            registros.Append("748");
            //Literal SICREDI 080-094
            registros.Append("SICREDI".FormatStringDireita(15, ' '));
            //Data arquivo 095-102
            registros.Append(aCobranca.DataArquivo.ToString("yyyyMMdd"));
            //Filler 103-110
            registros.Append(string.Empty.FormatStringDireita(8, ' '));
            //Numero remessa 111-117
            registros.Append(aCobranca.SequencialArq.ToString().FormatStringEsquerda(7, '0'));
            //Filler 118-390
            registros.Append(string.Empty.FormatStringDireita(273, ' '));
            //Versao Sistema 391-394
            registros.Append("2.00");
            //Numero sequencia registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            aCobranca.Titulos.ForEach(p =>
                {
                    #region Detalhe do titulo
                    registros = new StringBuilder();
                    //Identificao titulo 001-001
                    registros.Append("1");
                    //Tipo cobranca 002-002
                    registros.Append("A");//Com Registro
                    //Tipo carteira 003-003
                    registros.Append("A");//Simples
                    //Tipo impressao 004-004
                    registros.Append("A");//Normal
                    //Filler 005-016
                    registros.Append(string.Empty.FormatStringDireita(12, ' '));
                    //Tipo moeda 017-017
                    registros.Append("A");//Real
                    //Tipo desconto 018-018
                    registros.Append(p.Tp_desconto.Trim().Equals("P") ? "B" : "A");
                    //Tipo juro 019-019
                    registros.Append(p.Tp_jurodia.Trim().Equals("P") ? "B" : "A");
                    //Filler 020-047
                    registros.Append(string.Empty.FormatStringDireita(28, ' '));
                    //Nosso numero 048-056
                    registros.Append(p.Nosso_numero.SoNumero().FormatStringEsquerda(8, '0') +
                                     p.Digito_nossonumero.Trim());
                    //Filler 057-062
                    registros.Append(string.Empty.FormatStringDireita(6, ' '));
                    //Data instrucao 063-070
                    registros.Append(aCobranca.DataArquivo.ToString("yyyyMMdd"));
                    //Campo alterado, quando instrucao 31 071-071
                    registros.Append(string.Empty.FormatStringDireita(1, ' '));
                    //Postagem titulo 072-072
                    registros.Append("N");//Nao Postar
                    //Filler 073-073
                    registros.Append(string.Empty.FormatStringDireita(1, ' '));
                    //Emissao boleto 074-074
                    registros.Append("B");//Impressao Cedente
                    //Numero parcela carne 075-076
                    registros.Append("00");
                    //Numero total parcelas carne 077-078
                    registros.Append("00");
                    //Filler 079-082
                    registros.Append(string.Empty.FormatStringDireita(4, ' '));
                    //valor desconto por dia de antecipacao 083-092
                    registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(10, '0'));
                    //% multa por atrazo 093-096
                    if (p.Tp_multa.Trim().Equals("V"))
                        throw new Exception("Banco não permite multa em PERCENTUAL.");
                    registros.Append(p.Pc_multa.ToString().SoNumero().FormatStringEsquerda(4, '0'));
                    //Filler 097-108
                    registros.Append(string.Empty.FormatStringDireita(12, ' '));
                    //Instrucao 109-110
                    registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                    //Seu numero 111-120
                    registros.Append((p.Nr_lancto.ToString() + p.Cd_parcela.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(10, '0'));
                    //Data vencimento 121-126
                    registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                    //valor titulo 127-139
                    registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                    //Filler 140-148
                    registros.Append(string.Empty.FormatStringDireita(9, ' '));
                    //Especie documento 149-149
                    registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                    //Aceite titulo 150-150
                    registros.Append(p.Aceite_SN.Trim());
                    //Data emissao 151-156
                    registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                    //Instrucao Protesto 157-158
                    registros.Append(p.St_protestarauto ? "06" : "00");
                    //Numero dias protesto 159-160
                    registros.Append(p.St_protestarauto ? p.Nr_diasprotestar < 3 ? "03" : p.Nr_diasprotestar > 99 ? "99" : p.Nr_diasprotestar.ToString().FormatStringEsquerda(2, '0') : "00");
                    //Valor/% juro dia atrazo 161-173
                    registros.Append(p.Pc_jurodia.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                    //Data limite desconto 174-179
                    registros.Append(p.Pc_desconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                    //Valor/% Desconto 180-192
                    registros.Append((p.Pc_desconto > decimal.Zero ? p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto : decimal.Zero).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                    //Filler 193-205
                    registros.Append(string.Empty.FormatStringDireita(13, '0'));
                    //Valor abatimento 206-218
                    registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                    //Tipo pessoa sacado 219-219
                    registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : "2");
                    //Filler 220-220
                    registros.Append(string.Empty.FormatStringDireita(1, '0'));
                    //CPF/CNPJ Sacado 221-234
                    registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                    //Nome sacado 235-274
                    registros.Append(p.Sacado.Nome.Trim().RemoverCaracteres().FormatStringDireita(40, ' '));
                    //endereco sacado 275-314
                    registros.Append(p.Sacado.Endereco.Rua.Trim().RemoverCaracteres().FormatStringDireita(40, ' '));
                    //Codigo sacado na cooperativa cedente 315-319
                    registros.Append(string.Empty.FormatStringEsquerda(5, '0'));
                    //Filler 320-325
                    registros.Append(string.Empty.FormatStringEsquerda(6, '0'));
                    //Filler 326-326
                    registros.Append(string.Empty.FormatStringDireita(1, ' '));
                    //CEP sacado 327-334
                    registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                    //Codigo sacado junto ao cliente 335-339
                    registros.Append(string.Empty.FormatStringEsquerda(5, '0'));
                    //CPF/CNPJ avalista 340-353
                    registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, ' '));
                    //Nome avalista 354-394
                    registros.Append(p.Avalista.Nome.Trim().RemoverCaracteres().FormatStringEsquerda(41, ' '));
                    //sequencial do registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                    Remessa.AppendLine(registros.ToString());
                    #endregion

                    #region Avalista
                    if (!string.IsNullOrEmpty(p.Avalista.Nome))
                    {
                        registros = new StringBuilder();
                        //Identificacao registro 001-001
                        registros.Append("6");
                        //Nosso numero 002-016
                        registros.Append((p.Nosso_numero.SoNumero().FormatStringEsquerda(8, '0') +
                                         p.Digito_nossonumero.Trim()).FormatStringDireita(15, ' '));
                        //Seu numero 017-026
                        registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(10, '0'));
                        //Codigo sacado 027-031
                        registros.Append(string.Empty.FormatStringEsquerda(5, '0'));
                        //CPF/CNPJ Avalista 032-045
                        registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                        //Nome avalista 046-086
                        registros.Append(p.Avalista.Nome.Trim().RemoverCaracteres().FormatStringDireita(41, ' '));
                        //Endereco avalista 087-131
                        registros.Append((p.Avalista.Endereco.Rua.Trim() + "," + p.Avalista.Endereco.Numero.Trim()).RemoverCaracteres().FormatStringDireita(45, ' '));
                        //Cidade 132-151
                        registros.Append(p.Avalista.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(20, ' '));
                        //CEP 152-159
                        registros.Append(p.Avalista.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                        //Estado 160-161
                        registros.Append(p.Avalista.Endereco.Estado.Trim().FormatStringDireita(2, ' '));
                        //Filler 162-394
                        registros.Append(string.Empty.FormatStringDireita(233, ' '));
                        //Sequencial registro 395-400
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
            //Identificacao remessa 002-002
            registros.Append("1");
            //Numero sicredi 003-005
            registros.Append("748");
            //Codigo cedente 006-010
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(5, '0'));
            //Filler 011-394
            registros.Append(string.Empty.FormatStringDireita(384, ' '));
            //Sequencial registro
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion
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
                ACodigoCedente = Retorno[NumeroRegistro].Substring(26, 5);

                if (Retorno[NumeroRegistro].Substring(94, 8).PadLeft(8, '0') != "00000000")
                        ACobranca.DataArquivo = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(94, 4)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(98, 2)),
                                                             Convert.ToInt32(Retorno[NumeroRegistro].Substring(100, 2)));
                else
                    ACobranca.DataArquivo = DateTime.Now;

                if (Retorno[NumeroRegistro].Substring(394, 6).PadLeft(6, '0') != "000000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(394, 6));
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
                        ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(47, 2) + "/" + Retorno[NumeroRegistro].Substring(49, 6);
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
                        //Valor despesas
                        if (!string.IsNullOrEmpty(Retorno[NumeroRegistro].Substring(175, 13).Trim()) &&
                            Retorno[NumeroRegistro].Substring(175, 13).PadLeft(13, '0') != "0000000000000")
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
                        //Juros
                        if (Retorno[NumeroRegistro].Substring(266, 13).PadLeft(13, '0') != "0000000000000")
                        {
                            ATitulo.Vl_morajuros = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(266, 13)) / 100;

                            //Multa
                            if (Retorno[NumeroRegistro].Substring(279, 13).PadLeft(13, '0') != "0000000000000")
                                ATitulo.Vl_morajuros += Convert.ToDecimal(Retorno[NumeroRegistro].Substring(279, 13)) / 100;
                        }
                        else
                            ATitulo.Vl_morajuros = decimal.Zero;
                        //Motivo ocorrencia
                        string codigo = Retorno[NumeroRegistro].Substring(318, 10);
                        if(codigo.Substring(0, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(codigo.Substring(0, 2)) + "|";
                        if(codigo.Substring(2, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(codigo.Substring(2, 2)) + "|";
                        if(codigo.Substring(4, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(codigo.Substring(4, 2)) + "|";
                        if(codigo.Substring(6, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(codigo.Substring(6, 2)) + "|";
                        if(codigo.Substring(8, 2) != "00")
                            ATitulo.Ds_motivoocorrencia += TratarMotivo(codigo.Substring(8, 2));
                        if(!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                            if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                                ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                        //Data credito
                        if (Retorno[NumeroRegistro].Substring(328, 8).Trim().PadLeft(8, '0') != "00000000")
                            ATitulo.Dt_credito = new DateTime(Convert.ToInt32(Retorno[NumeroRegistro].Substring(328, 4)),
                                                               Convert.ToInt32(Retorno[NumeroRegistro].Substring(332, 2)),
                                                               Convert.ToInt32(Retorno[NumeroRegistro].Substring(334, 2)));
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
            string extensao = ".CRM";
            TList_LoteRemessa lLote = new TCD_LoteRemessa().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "b.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + ACobranca.Titulos[0].Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "b.cd_contager",
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
                                                vNM_Campo = "isnull(a.nr_arqremessa, 0)",
                                                vOperador = "<>",
                                                vVL_Busca = "0"
                                            }
                                        }, 0, string.Empty);
            if (lLote.Count > 0)
            {
                if (lLote.Exists(p => p.Nr_arqRemessa.Equals(ACobranca.SequencialArq)))
                {
                    if (lLote.OrderBy(p => p.Nr_arqRemessa).ToList().FindIndex(p => p.Nr_arqRemessa.Equals(ACobranca.SequencialArq)) > 0)
                        extensao = ".RM" + (lLote.OrderBy(p => p.Nr_arqRemessa).ToList().FindIndex(p => p.Nr_arqRemessa.Equals(ACobranca.SequencialArq)) + 1).ToString();
                }
                else extensao = ".RM" + (lLote.Count + 1).ToString();
            }
            using (StreamWriter sw = new StreamWriter(Path_remessa + 
                                                      ACobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(5, '0') + 
                                                      this.CodigoMes(ACobranca.DataArquivo.Month) + 
                                                      ACobranca.DataArquivo.Day.FormatStringEsquerda(2, '0') + 
                                                      extensao))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
