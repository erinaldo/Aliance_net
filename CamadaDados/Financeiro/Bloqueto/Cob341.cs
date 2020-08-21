using System;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco341
    {
        const string CodigoBanco = "341";
        const string NomeBanco = "BANCO ITAU SA";
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
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edContrato: return "06";
                case TEspecieDocumento.edCosseguros: return "07";
                case TEspecieDocumento.edDuplicataServico: return "08";
                case TEspecieDocumento.edLetraCambio: return "09";
                case TEspecieDocumento.edNotaDebito: return "13";
                default: return "99";
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
                case "04": return "ALTERAÇÃO DE DADOS - NOVA ENTRADA";
                case "05": return "ALTERAÇÃO DE DADOS - BAIXA";
                case "06": return "LIQUIDAÇÃO NORMAL";
                case "08": return "LIQUIDAÇÃO EM CARTÓRIO";
                case "09": return "BAIXA SIMPLES";
                case "10": return "BAIXA POR TER SIDO LIQUIDADO";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "VENCIMENTO ALTERADO";
                case "15": return "BAIXAS REJEITADAS";
                case "16": return "INSTRUÇÕES REJEITADAS";
                case "17": return "ALTERAÇÃO/EXCLUSÃO DE DADOS REJEITADOS";
                case "18": return "COBRANÇA CONTRATUAL - INSTRUÇÕES/ALTERAÇÕES REJEITADAS/PENDENTES";
                case "19": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE SUSTAÇÃO DE PROTESTO /TARIFA";
                case "21": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO DE NÃO PROTESTAR";
                case "23": return "TÍTULO ENVIADO A CARTÓRIO/TARIFA";
                case "24": return "INSTRUÇÃO DE PROTESTO REJEITADA / SUSTADA / PENDENTE";
                case "25": return "ALEGAÇÕES DO SACADO";
                case "26": return "TARIFA DE AVISO DE COBRANÇA";
                case "27": return "TARIFA DE EXTRATO POSIÇÃO";
                case "28": return "TARIFA DE RELAÇÃO DAS LIQUIDAÇÕES";
                case "29": return "TARIFA DE MANUTENÇÃO DE TÍTULOS VENCIDOS";
                case "30": return "DÉBITO MENSAL DE TARIFAS (PARA ENTRADAS E BAIXAS)";
                case "32": return "BAIXA POR TER SIDO PROTESTADO";
                case "33": return "CUSTAS DE PROTESTO";
                case "34": return "CUSTAS DE SUSTAÇÃO";
                case "35": return "CUSTAS DE CARTÓRIO DISTRIBUIDOR";
                case "36": return "CUSTAS DE EDITAL";
                case "37": return "TARIFA DE EMISSÃO DE BOLETO/TARIFA DE ENVIO DE DUPLICATA";
                case "38": return "TARIFA DE INSTRUÇÃO";
                case "39": return "TARIFA DE OCORRÊNCIAS";
                case "40": return "TARIFA MENSAL DE EMISSÃO DE BOLETO/TARIFA MENSAL DE ENVIO DE DUPLICATA";
                case "41": return "DÉBITO MENSAL DE TARIFAS – EXTRATO DE POSIÇÃO";
                case "42": return "DÉBITO MENSAL DE TARIFAS – OUTRAS INSTRUÇÕES";
                case "43": return "DÉBITO MENSAL DE TARIFAS – MANUTENÇÃO DE TÍTULOS VENCIDOS";
                case "44": return "DÉBITO MENSAL DE TARIFAS – OUTRAS OCORRÊNCIAS";
                case "45": return "DÉBITO MENSAL DE TARIFAS – PROTESTO";
                case "46": return "DÉBITO MENSAL DE TARIFAS – SUSTAÇÃO DE PROTESTO";
                case "47": return "BAIXA COM TRANSFERÊNCIA PARA DESCONTO";
                case "48": return "CUSTAS DE SUSTAÇÃO JUDICIAL";
                case "51": return "TARIFA MENSAL REF A ENTRADAS BANCOS CORRESPONDENTES NA CARTEIRA";
                case "52": return "TARIFA MENSAL BAIXAS NA CARTEIRA";
                case "53": return "TARIFA MENSAL BAIXAS EM BANCOS CORRESPONDENTES NA CARTEIRA";
                case "54": return "TARIFA MENSAL DE LIQUIDAÇÕES NA CARTEIRA";
                case "55": return "TARIFA MENSAL DE LIQUIDAÇÕES EM BANCOS CORRESPONDENTES NA CARTEIRA";
                case "56": return "CUSTAS DE IRREGULARIDADE";
                case "57": return "INSTRUÇÃO CANCELADA";
                case "59": return "BAIXA POR CRÉDITO EM C/C ATRAVÉS DO SISPAG";
                case "60": return "ENTRADA REJEITADA CARNÊ";
                case "61": return "TARIFA EMISSÃO AVISO DE MOVIMENTAÇÃO DE TÍTULOS";
                case "62": return "DÉBITO MENSAL DE TARIFA - AVISO DE MOVIMENTAÇÃO DE TÍTULOS";
                case "63": return "TÍTULO SUSTADO JUDICIALMENTE";
                case "64": return "ENTRADA CONFIRMADA COM RATEIO DE CRÉDITO";
                case "69": return "CHEQUE DEVOLVIDO";
                case "71": return "ENTRADA REGISTRADA, AGUARDANDO AVALIAÇÃO";
                case "72": return "BAIXA POR CRÉDITO EM C/C ATRAVÉS DO SISPAG SEM TÍTULO CORRESPONDENTE";
                case "73": return "CONFIRMAÇÃO DE ENTRADA NA COBRANÇA SIMPLES";
                case "76": return "CHEQUE COMPENSADO";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string ocorrencia, string codigo)
        {
            if (ocorrencia.Trim().ToUpper().Equals("03"))
                switch (codigo)
                {
                    case "03": return "NÃO FOI POSSÍVEL ATRIBUIR A AGÊNCIA PELO CEP OU CEP SEM ATENDIMENTO DE PROTESTO NO MOMENTO";
                    case "04": return "SIGLA DO ESTADO INVÁLIDA";
                    case "05": return "PRAZO DA OPERAÇÃO MENOR QUE PRAZO MÍNIMO OU MAIOR QUE O MÁXIMO";
                    case "07": return "VALOR DO TÍTULO MAIOR QUE 10.000.000,00";
                    case "08": return "NÃO INFORMADO OU DESLOCADO";
                    case "09": return "AGÊNCIA ENCERRADA";
                    case "10": return "NÃO INFORMADO OU DESLOCADO";
                    case "11": return "CEP NÃO NUMÉRICO OU CEP INVÁLIDO";
                    case "12": return "NOME NÃO INFORMADO OU DESLOCADO";
                    case "13": return "CEP INCOMPATÍVEL COM A SIGLA DO ESTADO";
                    case "14": return "NOSSO NÚMERO JÁ REGISTRADO NO CADASTRO DO BANCO OU FORA DA FAIXA";
                    case "15": return "NOSSO NÚMERO EM DUPLICIDADE NO MESMO MOVIMENTO";
                    case "18": return "DATA DE ENTRADA INVÁLIDA PARA OPERAR COM ESTA CARTEIRA";
                    case "19": return "OCORRÊNCIA INVÁLIDA";
                    case "21": return "CARTEIRA NÃO ACEITA DEPOSITÁRIA CORRESPONDENTE ESTADO DA AGÊNCIA DIFERENTE DO ESTADO DO SACADO AG. COBRADORA NÃO CONSTA NO CADASTRO OU ENCERRANDO";
                    case "22": return "CARTEIRA NÃO PERMITIDA (NECESSÁRIO CADASTRAR FAIXA LIVRE)";
                    case "26": return "AGÊNCIA/CONTA NÃO LIBERADA PARA OPERAR COM COBRANÇA";
                    case "27": return "CNPJ DO CEDENTE INAPTO DEVOLUÇÃO DE TÍTULO EM GARANTIA";
                    case "29": return "CATEGORIA DA CONTA INVÁLIDA";
                    case "30": return "ENTRADAS BLOQUEADAS, CONTA SUSPENSA EM COBRANÇA";
                    case "31": return "CONTA NÃO TEM PERMISSÃO PARA PROTESTAR (CONTATE SEU GERENTE)";
                    case "35": return "IOF MAIOR QUE 5%";
                    case "36": return "QUANTIDADE DE MOEDA INCOMPATÍVEL COM VALOR DO TÍTULO";
                    case "37": return "NÃO NUMÉRICO OU IGUAL A ZEROS";
                    case "42": return "NOSSO NÚMERO FORA DE FAIXA";
                    case "52": return "EMPRESA NÃO ACEITA BANCO CORRESPONDENTE";
                    case "53": return "EMPRESA NÃO ACEITA BANCO CORRESPONDENTE - COBRANÇA MENSAGEM";
                    case "54": return "BANCO CORRESPONDENTE - TÍTULO COM VENCIMENTO INFERIOR A 15 DIAS";
                    case "55": return "CEP NÃO PERTENCE À DEPOSITÁRIA INFORMADA";
                    case "56": return "VENCTO SUPERIOR A 180 DIAS DA DATA DE ENTRADA";
                    case "57": return "CEP SÓ DEPOSITÁRIA BCO DO BRASIL COM VENCTO INFERIOR A 8 DIAS";
                    case "60": return "VALOR DO ABATIMENTO INVÁLIDO";
                    case "61": return "JUROS DE MORA MAIOR QUE O PERMITIDO";
                    case "63": return "VALOR DA IMPORTÂNCIA POR DIA DE DESCONTO (IDD) NÃO PERMITIDO";
                    case "64": return "DATA DE EMISSÃO DO TÍTULO INVÁLIDA";
                    case "65": return "TAXA INVÁLIDA (VENDOR)";
                    case "66": return "INVALIDA/FORA DE PRAZO DE OPERAÇÃO (MÍNIMO OU MÁXIMO)";
                    case "67": return "VALOR DO TÍTULO/QUANTIDADE DE MOEDA INVÁLIDO";
                    case "68": return "CARTEIRA INVÁLIDA OU NÃO CADASTRADA NO INTERCÂMBIO DA COBRANÇA";
                    case "69": return "CARTEIRA INVÁLIDA PARA TÍTULOS COM RATEIO DE CRÉDITO";
                    case "70": return "CEDENTE NÃO CADASTRADO PARA FAZER RATEIO DE CRÉDITO";
                    case "78": return "DUPLICIDADE DE AGÊNCIA/CONTA BENEFICIÁRIA DO RATEIO DE CRÉDITO";
                    case "80": return "QUANTIDADE DE CONTAS BENEFICIÁRIAS DO RATEIO MAIOR DO QUE O PERMITIDO (MÁXIMO DE 30 CONTAS POR TÍTULO)";
                    case "81": return "CONTA PARA RATEIO DE CRÉDITO INVÁLIDA / NÃO PERTENCE AO ITAÚ";
                    case "82": return "DESCONTO/ABATIMENTO NÃO PERMITIDO PARA TÍTULOS COM RATEIO DE CRÉDITO";
                    case "83": return "VALOR DO TÍTULO MENOR QUE A SOMA DOS VALORES ESTIPULADOS PARA RATEIO";
                    case "84": return "AGÊNCIA/CONTA BENEFICIÁRIA DO RATEIO É A CENTRALIZADORA DE CRÉDITO DO CEDENTE";
                    case "85": return "AGÊNCIA/CONTA DO CEDENTE É CONTRATUAL / RATEIO DE CRÉDITO NÃO PERMITIDO";
                    case "86": return "CÓDIGO DO TIPO DE VALOR INVÁLIDO / NÃO PREVISTO PARA TÍTULOS COM RATEIO DE CRÉDITO";
                    case "87": return "REGISTRO TIPO 4 SEM INFORMAÇÃO DE AGÊNCIAS/CONTAS BENEFICIÁRIAS DO RATEIO";
                    case "90": return "COBRANÇA MENSAGEM - NÚMERO DA LINHA DA MENSAGEM INVÁLIDO OU QUANTIDADE DE LINHAS EXCEDIDAS";
                    case "91": return "DAC AGENCIA / CONTA CORRENTE INVÁLIDO";
                    case "92": return "DAC AGENCIA / CONTA CORRENTE / CARTEIRA / NOSSO NÚMERO INVÁLIDO";
                    case "93": return "SIGLA ESTADO INVÁLIDA";
                    case "94": return "SIGLA ESTADO INCOMPATIVEL COM O CEP DO SACADO";
                    case "95": return "CEP DO SACADO NÃO NUMÉRICO OU INVÁLIDO";
                    case "96": return "ENDEREÇO / NOME / CIDADE SACADO INVÁLIDO";
                    case "97": return "COBRANÇA MENSAGEM SEM MENSAGEM (SÓ DE CAMPOS FIXOS), PORÉM COM REGISTRO DO TIPO 7 OU 8";
                    case "98": return "REGISTRO MENSAGEM SEM FLASH CADASTRADO OU FLASH INFORMADO DIFERENTE DO CADASTRADO";
                    case "99": return "CONTA DE COBRANÇA COM FLASH CADASTRADO E SEM REGISTRO DE MENSAGEM CORRESPONDENTE";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("17"))
                switch (codigo)
                {
                    case "02": return "AGÊNCIA COBRADORA INVÁLIDA OU COM O MESMO CONTEÚDO";
                    case "04": return "SIGLA DO ESTADO INVÁLIDA";
                    case "05": return "DATA DE VENCIMENTO INVÁLIDA OU COM O MESMO CONTEÚDO";
                    case "06": return "VALOR DO TÍTULO COM OUTRA ALTERAÇÃO SIMULTÂNEA";
                    case "08": return "NOME DO SACADO COM O MESMO CONTEÚDO";
                    case "09": return "AGÊNCIA/CONTA INCORRETA";
                    case "11": return "CEP INVÁLIDO";
                    case "12": return "NÚMERO INSCRIÇÃO INVÁLIDO DO SACADOR AVALISTA";
                    case "13": return "SEU NÚMERO COM O MESMO CONTEÚDO";
                    case "16": return "ABATIMENTO/ALTERAÇÃO DO VALOR DO TÍTULO OU SOLICITAÇÃO DE BAIXA BLOQUEADA";
                    case "20": return "ESPÉCIE INVÁLIDA";
                    case "21": return "AGÊNCIA COBRADORA NÃO CONSTA NO CADASTRO DE DEPOSITÁRIA OU EM ENCERRAMENTO";
                    case "23": return "DATA DE EMISSÃO DO TÍTULO INVÁLIDA OU COM MESMO CONTEÚDO";
                    case "41": return "CAMPO ACEITE INVÁLIDO OU COM MESMO CONTEÚDO";
                    case "42": return "ALTERAÇÃO INVÁLIDA PARA TÍTULO VENCIDO";
                    case "43": return "ALTERAÇÃO BLOQUEADA – VENCIMENTO JÁ ALTERADO";
                    case "53": return "INSTRUÇÃO COM O MESMO CONTEÚDO";
                    case "54": return "DATA VENCIMENTO PARA BANCOS CORRESPONDENTES INFERIOR AO ACEITO PELO BANCO";
                    case "55": return "ALTERAÇÕES IGUAIS PARA O MESMO CONTROLE (AGÊNCIA/CONTA/CARTEIRA/NOSSO NÚMERO)";
                    case "56": return "CNPJ/CPF INVÁLIDO NÃO NUMÉRICO OU ZERADO";
                    case "57": return "PRAZO DE VENCIMENTO INFERIOR A 15 DIAS";
                    case "60": return "VALOR DE IOF – ALTERAÇÃO NÃO PERMITIDA PARA CARTEIRAS DE N.S. – MOEDA VARIÁVEL";
                    case "61": return "TÍTULO JÁ BAIXADO OU LIQUIDADO OU NÃO EXISTE TÍTULO CORRESPONDENTE NO SISTEMA";
                    case "66": return "ALTERAÇÃO NÃO PERMITIDA PARA CARTEIRAS DE NOTAS DE SEGUROS – MOEDA VARIÁVEL";
                    case "67": return "NOME INVÁLIDO DO SACADOR AVALISTA";
                    case "72": return "ENDEREÇO INVÁLIDO – SACADOR AVALISTA";
                    case "73": return "BAIRRO INVÁLIDO – SACADOR AVALISTA";
                    case "74": return "CIDADE INVÁLIDA – SACADOR AVALISTA";
                    case "75": return "SIGLA ESTADO INVÁLIDO – SACADOR AVALISTA";
                    case "76": return "CEP INVÁLIDO – SACADOR AVALISTA";
                    case "81": return "ALTERAÇÃO BLOQUEADA – TÍTULO COM PROTESTO";
                    case "87": return "ALTERAÇÃO BLOQUEADA – TÍTULO COM RATEIO DE CRÉDITO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("16"))
                switch (codigo)
                {
                    case "01": return "INSTRUÇÃO/OCORRÊNCIA NÃO EXISTENTE";
                    case "03": return "CONTA NÃO TEM PERMISSÃO PARA PROTESTAR (CONTATE SEU GERENTE)";
                    case "06": return "NOSSO NÚMERO IGUAL A ZEROS";
                    case "09": return "CNPJ/CPF DO SACADOR/AVALISTA INVÁLIDO";
                    case "10": return "VALOR DO ABATIMENTO IGUAL OU MAIOR QUE O VALOR DO TÍTULO";
                    case "11": return "SEGUNDA INSTRUÇÃO/OCORRÊNCIA NÃO EXISTENTE";
                    case "14": return "REGISTRO EM DUPLICIDADE";
                    case "15": return "CNPJ/CPF INFORMADO SEM NOME DO SACADOR/AVALISTA";
                    case "19": return "VALOR DO ABATIMENTO MAIOR QUE 90% DO VALOR DO TÍTULO";
                    case "20": return "EXISTE SUSTACAO DE PROTESTO PENDENTE PARA O TITULO";
                    case "21": return "TÍTULO NÃO REGISTRADO NO SISTEMA";
                    case "22": return "TÍTULO BAIXADO OU LIQUIDADO";
                    case "23": return "INSTRUÇÃO NÃO ACEITA POR TER SIDO EMITIDO ÚLTIMO AVISO AO SACADO";
                    case "24": return "INSTRUÇÃO INCOMPATÍVEL - EXISTE INSTRUÇÃO DE PROTESTO PARA O TÍTULO";
                    case "25": return "INSTRUÇÃO INCOMPATÍVEL – NÃO EXISTE INSTRUÇÃO DE PROTESTO PARA O TÍTULO";
                    case "26": return "INSTRUÇÃO NÃO ACEITA POR JÁ TER SIDO EMITIDA A ORDEM DE PROTESTO AO CARTÓRIO";
                    case "27": return "INSTRUÇÃO NÃO ACEITA POR NÃO TER SIDO EMITIDA A ORDEM DE PROTESTO AO CARTÓRIO";
                    case "28": return "JÁ EXISTE UMA MESMA INSTRUÇÃO CADASTRADA ANTERIORMENTE PARA O TÍTULO";
                    case "29": return "VALOR LÍQUIDO + VALOR DO ABATIMENTO DIFERENTE DO VALOR DO TÍTULO REGISTRADO";
                    case "30": return "EXISTE UMA INSTRUÇÃO DE NÃO PROTESTAR ATIVA PARA O TÍTULO";
                    case "31": return "EXISTE UMA OCORRÊNCIA DO SACADO QUE BLOQUEIA A INSTRUÇÃO";
                    case "32": return "DEPOSITÁRIA DO TÍTULO = 9999 OU CARTEIRA NÃO ACEITA PROTESTO";
                    case "33": return "ALTERAÇÃO DE VENCIMENTO IGUAL À REGISTRADA NO SISTEMA OU QUE TORNA O TÍTULO VENCIDO";
                    case "34": return "INSTRUÇÃO DE EMISSÃO DE AVISO DE COBRANÇA PARA TÍTULO VENCIDO ANTES DO VENCIMENTO";
                    case "35": return "SOLICITAÇÃO DE CANCELAMENTO DE INSTRUÇÃO INEXISTENTE";
                    case "36": return "TÍTULO SOFRENDO ALTERAÇÃO DE CONTROLE (AGÊNCIA/CONTA/CARTEIRA/NOSSO NÚMERO)";
                    case "37": return "INSTRUÇÃO NÃO PERMITIDA PARA A CARTEIRA";
                    case "38": return "INSTRUÇÃO NÃO PERMITIDA PARA TÍTULO COM RATEIO DE CRÉDITO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("15"))
                switch (codigo)
                {
                    case "01": return "CARTEIRA/Nº NÚMERO NÃO NUMÉRICO";
                    case "04": return "NOSSO NÚMERO EM DUPLICIDADE NUM MESMO MOVIMENTO";
                    case "05": return "SOLICITAÇÃO DE BAIXA PARA TÍTULO JÁ BAIXADO OU LIQUIDADO";
                    case "06": return "SOLICITAÇÃO DE BAIXA PARA TÍTULO NÃO REGISTRADO NO SISTEMA";
                    case "07": return "COBRANÇA PRAZO CURTO – SOLICITAÇÃO DE BAIXA P/ TÍTULO NÃO REGISTRADO NO SISTEMA";
                    case "08": return "SOLICITAÇÃO DE BAIXA PARA TÍTULO EM FLOATING";
                    case "10": return "VALOR DO TITULO FAZ PARTE DE GARANTIA DE EMPRESTIMO";
                    case "11": return "PAGO ATRAVÉS DO SISPAG POR CRÉDITO EM C/C E NÃO BAIXADO";
                    default: return string.Empty;
                }
            else if (ocorrencia.Trim().ToUpper().Equals("18"))
                switch (codigo)
                {
                    case "16": return "ABATIMENTO/ALTERAÇÃO DO VALOR DO TÍTULO OU SOLICITAÇÃO DE BAIXA BLOQUEADOS";
                    case "40": return "NÃO APROVADA DEVIDO AO IMPACTO NA ELEGIBILIDADE DE GARANTIAS";
                    case "41": return "AUTOMATICAMENTE REJEITADA";
                    case "42": return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO – PENDENTE DE ANÁLISE";
                    default: return string.Empty;
                }
            else return string.Empty;
        }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            return ATitulo.Carteira.Trim() +
                   ATitulo.Nosso_numero.Trim() +
                   Utils.Estruturas.Mod10(ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() +
                                          ATitulo.Cedente.ContaBancaria.NumeroConta.Trim() +
                                          ATitulo.Carteira.Trim() +
                                          ATitulo.Nosso_numero.Trim()).ToString().Trim() +
                   ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() +
                   ATitulo.Cedente.ContaBancaria.NumeroConta.Trim() +
                   Utils.Estruturas.Mod10(ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() + ATitulo.Cedente.ContaBancaria.NumeroConta.Trim()) +
                   "000";
        }

        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            return (vNossoNumero + 1).ToString().PadLeft(8, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Utils.Estruturas.Mod10(ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() +
                                          ATitulo.Cedente.ContaBancaria.NumeroConta.Trim() +
                                          ATitulo.Carteira.Trim() +
                                          ATitulo.Nosso_numero.Trim()).ToString().Trim();
        }

        private void GerarRemessaCNAB240(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;

            #region Registro Header Arquivo
            //Codigo Banco 001-003
            registros.Append(CodigoBanco);
            //Codigo do lote 004-007
            registros.Append("0000");
            //Tipo registro 008-008
            registros.Append("0");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Tipo inscricao empresa 018-018
            registros.Append("2");//CNPJ
            //Numero inscricao 019-032 NOTA 2
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
            //Brancos 033-052
            registros.Append("".FormatStringDireita(20, ' '));
            //Zeros 053-053
            registros.Append("0");
            //Codigo Agencia 054-057
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Brancos 058-058
            registros.Append(" ");
            //Zeros 059-065
            registros.Append("0000000");
            //Conta Corrente 066-070
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(5, '0'));
            //Brancos 071-071
            registros.Append(" ");
            //DAC 072-072
            registros.Append(Utils.Estruturas.Mod10(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.Trim() + 
                aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.Trim()));
            //Nome Empresa 073-102 NOTA 2
            registros.Append(aCobranca.Titulos[tot_registros].Nm_cedente.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Nome Banco 103-132
            registros.Append(NomeBanco.Trim().FormatStringDireita(30, ' '));
            //Brancos 133-142
            registros.Append("".FormatStringDireita(10, ' '));
            //Codigo Arquivo 143-143
            registros.Append("1");//Remessa
            //Data arquivo 144-151
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyyyy"));
            //Hora arquivo 152-157
            registros.Append(aCobranca.DataArquivo.ToString("HH:mm:ss").SoNumero());
            //Numero arquivo retorno 158-163
            registros.Append("000000");
            //Layout arquivo 164-166
            registros.Append("040");
            //Zeros 167-171
            registros.Append("00000");
            //Brancos 172-225
            registros.Append("".FormatStringDireita(54, ' '));
            //Zeros 226-228
            registros.Append("000");
            //Brancos 229-240
            registros.Append("".FormatStringDireita(12, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Header Lote
            registros = new StringBuilder();
            //Codigo Banco 001-003
            registros.Append(CodigoBanco);
            //Lote servico 004-007 NOTA 1
            registros.Append("0001");//Somente um lote de servico por arquivo
            //Tipo registro 008-008
            registros.Append("1");
            //Tipo operacao 009-009
            registros.Append("R");//Remessa
            //Codigo servico 010-011
            registros.Append("01");
            //Zeros 012-013
            registros.Append("00");
            //Layout lote 014-016
            registros.Append("030");
            //Brancos 017-017
            registros.Append(" ");
            //Tipo inscricao 018-018
            registros.Append("2");//CNPJ
            //CNPJ 019-033 NOTA 2
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
            //Brancos 034-053
            registros.Append("".FormatStringDireita(20, ' '));
            //Zeros 054-054
            registros.Append("0");
            //Agencia 055-058
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Brancos 059-059
            registros.Append(" ");
            //Zeros 060-066
            registros.Append("0000000");
            //Numero conta 067-071
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(5, '0'));
            //Brancos 072-072
            registros.Append(" ");
            //DAC 073-073
            registros.Append(Utils.Estruturas.Mod10(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.Trim() + 
                aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.Trim()));
            //Nome empresa 074-103
            registros.Append(aCobranca.Titulos[tot_registros].Nm_cedente.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Brancos 104-183
            registros.Append("".FormatStringDireita(80, ' '));
            //Numero arquivo retorno 184-191
            registros.Append("00000000");
            //Data arquivo 192-199
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyyyy"));
            //Data credito 200-207
            registros.Append("00000000");
            //Brancos 208-240
            registros.Append("".FormatStringDireita(33, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            aCobranca.Titulos.ForEach(p =>
            {
                #region Segmento P
                registros = new StringBuilder();
                //Codigo Banco 001-003
                registros.Append(CodigoBanco);
                //Lote servico 004-007 NOTA 1
                registros.Append("0001");
                //Tipo registro 008-008
                registros.Append("3");
                //Numero registro 009-013 NOTA 3
                registros.Append((++tot_registros).ToString().FormatStringEsquerda(5, '0'));
                //Segmento 014-014
                registros.Append("P");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo ocorrencia 016-017 NOTA 4
                registros.Append(p.Cd_ocorrencia.FormatStringEsquerda(2, '0'));
                //Zeros 018-018
                registros.Append("0");
                //Agencia 019-022
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Brancos 023-023
                registros.Append(" ");
                //Zeros 024-030
                registros.Append("0000000");
                //Numero conta 031-035
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(5, '0'));
                //Brancos 036-036
                registros.Append(" ");
                //DAC 037-037
                registros.Append(Utils.Estruturas.Mod10(p.Cedente.ContaBancaria.CodigoAgencia.Trim() + p.Cedente.ContaBancaria.NumeroConta.Trim()));
                //Carteira 038-040 NOTA 5
                registros.Append(p.Carteira.Trim());
                //Nosso numero 041-048 NOTA 6
                registros.Append(p.Nosso_numero.Trim());
                //DAC Nosso numero 049-049 NOTA 25
                registros.Append(p.Digito_NossoNumero);
                //Brancos 050-057
                registros.Append("".FormatStringDireita(8, ' '));
                //Zeros 058-062
                registros.Append("00000");
                //Numero do documento 063-072 NOTA 7
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(10, '0'));
                //Brancos 073-077
                registros.Append("".FormatStringDireita(5, ' '));
                //Data vencimento 078-085 NOTA 8
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor documento 086-100 NOTA 9
                registros.Append(p.Vl_documento.SoNumero().FormatStringEsquerda(15, '0'));
                //Agencia cobradora 101-105 NOTA 10
                registros.Append("00000");
                //DAC Agencia cobradora 106-106
                registros.Append(Utils.Estruturas.Mod10(p.Cedente.ContaBancaria.CodigoAgencia.Trim() + p.Cedente.ContaBancaria.NumeroConta.Trim()));
                //Especie do titulo 107-108 NOTA 11
                registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                //Aceite 109-109
                registros.Append(p.Aceite_SN.Trim().ToUpper().Equals("S") ? "A" : "N");
                //Data emissao 110-117
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyyyy"));
                //Zeros 118-118
                registros.Append("0");
                //Data juro 119-126 NOTA 12
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //valor juro 127-141 NOTA 13
                registros.Append(p.Vl_morajuros.SoNumero().FormatStringEsquerda(15, '0'));
                //Zeros 142-142
                registros.Append("0");
                //Data desconto 143-150
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyyyy") : "00000000");
                //Valor desconto 151-165 NOTA 14
                registros.Append(p.Vl_desconto.SoNumero().FormatStringEsquerda(15, '0'));
                //Valor IOF 166-180 NOTA 15
                registros.Append("".FormatStringEsquerda(15, '0'));
                //Valor abatimento 181-195 NOTA 16
                registros.Append(p.Vl_abatimento.SoNumero().FormatStringEsquerda(15, '0'));
                //Identificacao titulo empresa 196-220 NOTA 17
                registros.Append("".FormatStringDireita(25, ' '));
                //Codigo protesto 221-221 NOTA 18
                registros.Append(p.St_protestarauto ? "2" : "0");
                //Prazo protesto 222-223 NOTA 18
                registros.Append(p.Nr_diasprotestar.ToString().FormatStringEsquerda(2, '0'));
                //Codigo baixa 224-224 NOTA 19
                registros.Append("0");//Sem instrucao
                //Numero dias baixa 225-226 NOTA 19
                registros.Append("00");
                //Zeros 227-239
                registros.Append("".FormatStringEsquerda(13, '0'));
                //Brancos 240-240
                registros.Append(" ");

                Remessa.AppendLine(registros.ToString());

                #endregion

                #region Segmento Q
                registros = new StringBuilder();
                //Numero banco 001-003
                registros.Append(CodigoBanco);
                //Lote servico 004-007 NOTA 1
                registros.Append("0001");
                //Tipo registro 008-008
                registros.Append("3");
                //Numero registro 009-013 NOTA 3
                registros.Append((++tot_registros).ToString().FormatStringEsquerda(5, '0'));
                //Segmento 014-014
                registros.Append("Q");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo ocorrencia 016-017 NOTA 4
                registros.Append(p.Cd_ocorrencia.FormatStringEsquerda(2, '0'));
                //Tipo inscricao Pagador 018-018
                registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : "2");
                //Inscricao Pagador 019-033
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome Pagador 034-063
                registros.Append(p.Sacado.Nome.RemoverCaracteres().Trim().FormatStringDireita(30, ' '));
                //Brancos 064-073 NOTA 20
                registros.Append("".FormatStringDireita(10, ' '));
                //Endereco Pagador 074-113
                registros.Append((p.Sacado.Endereco.Rua.RemoverCaracteres().Trim() + "," + p.Sacado.Endereco.Numero.RemoverCaracteres().Trim()).FormatStringDireita(40, ' '));
                //Bairro 114-128
                registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().Trim().FormatStringDireita(15, ' '));
                //CEP 129-133
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0').Substring(0, 5));
                //Sufixo CEP 134-136
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0').Substring(5, 3));
                //Cidade Pagador 137-151
                registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().Trim().FormatStringDireita(15, ' '));
                //Sigla UF 152-153
                registros.Append(p.Sacado.Endereco.Estado.Trim());
                //Tipo inscricao avalista 154-154
                registros.Append(p.Avalista.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : "2");
                //Inscricao Avalista 155-169
                registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome Avalista 170-199
                registros.Append(p.Avalista.Nome.RemoverCaracteres().Trim().FormatStringDireita(30, ' '));
                //Brancos 200-209
                registros.Append("".FormatStringDireita(10, ' '));
                //Zeros 210-212
                registros.Append("000");
                //Brancos 213-240
                registros.Append("".FormatStringDireita(28, ' '));

                Remessa.AppendLine(registros.ToString());
                #endregion

                #region Segmento Y
                if (!string.IsNullOrEmpty(p.Avalista.Nome))
                {
                    registros = new StringBuilder();
                    //Codigo banco 001-003
                    registros.Append(CodigoBanco);
                    //Codigo lote 004-007 NOTA 1
                    registros.Append("0001");
                    //Tipo registro 008-008
                    registros.Append("3");
                    //Numero registro 009-013 NOTA 3 G038
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(5, '0'));
                    //Segmento 014-014
                    registros.Append("Y");
                    //Brancos 015-015
                    registros.Append(" ");
                    //Codigo ocorrencia 016-017 NOTA 4
                    registros.Append(p.Cd_ocorrencia.FormatStringEsquerda(2, '0'));
                    //Identificao registro opcional 018-019
                    registros.Append("01");
                    //Tipo inscricao 020-020
                    registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : "2");
                    //Inscricao 021-035 NOTA 2
                    registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                    //Nome avalista 036-075
                    registros.Append(p.Sacado.Nome.RemoverCaracteres().Trim().FormatStringDireita(40, ' '));
                    //Endereco 076-115
                    registros.Append((p.Sacado.Endereco.Rua.RemoverCaracteres().Trim() + "," + p.Sacado.Endereco.Numero.RemoverCaracteres().Trim()).FormatStringDireita(40, ' '));
                    //Bairro 116-130
                    registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().Trim().FormatStringDireita(15, ' '));
                    //CEP 131-138
                    registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                    //Cidade 139-153
                    registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().Trim().FormatStringDireita(15, ' '));
                    //UF 154-155
                    registros.Append(p.Sacado.Endereco.Estado.Trim().FormatStringDireita(2, ' '));
                    //Brancos 156-240
                    registros.Append("".FormatStringDireita(85, ' '));

                    Remessa.AppendLine(registros.ToString());
                }
                #endregion
            });
            #endregion

            #region Trailer Lote
            registros = new StringBuilder();
            //Numero banco 001-003
            registros.Append(CodigoBanco);
            //Codigo lote 004-007 NOTA 1
            registros.Append("0001");
            //Tipo registro 008-008
            registros.Append("5");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Quantidade registro lote 018-023 NOTA 26
            registros.Append((tot_registros + 2).ToString().FormatStringEsquerda(6, '0'));
            //Quantidade titulo cobranca simples 024-029 NOTA 24
            registros.Append(aCobranca.Titulos.Count.ToString().FormatStringEsquerda(6, '0'));
            //Valor cobranca simples 030-046 NOTA 24
            registros.Append(aCobranca.Titulos.Sum(p=> p.Vl_documento).SoNumero().FormatStringEsquerda(17, '0'));
            //Quantidade cobranca vinculada 047-052 NOTA 24
            registros.Append("000000");
            //Valor cobranca vinculada 053-069 NOTA 24
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Zeros 070-115
            registros.Append("".FormatStringEsquerda(46, '0'));
            //Aviso bancario 116-123 NOTA 25
            registros.Append("".FormatStringDireita(8, ' '));
            //Brancos 124-240
            registros.Append("".FormatStringDireita(117, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Trailer Arquivo
            registros = new StringBuilder();
            //Numero banco 001-003
            registros.Append(CodigoBanco);
            //Codigo lote 004-007
            registros.Append("9999");
            //Registro 008-008
            registros.Append("9");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Total de lotes 018-023 NOTA 26
            registros.Append("000001");
            //Total registros 024-029 NOTA 26
            registros.Append((tot_registros + 4).ToString().FormatStringEsquerda(6, '0'));
            //Zeros 030-035
            registros.Append("000000");
            //Brancos 036-240
            registros.Append("".FormatStringDireita(205, ' '));
            
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
            //Tipo registro 001-001
            registros.Append("0");
            //Tipo operacao 002-002
            registros.Append("1");//Remessa
            //Literal remessa 003-009
            registros.Append("REMESSA".FormatStringDireita(7, ' '));
            //Codigo servico 010-011
            registros.Append("01");
            //Literal servico 012-026
            registros.Append("COBRANCA".FormatStringDireita(15, ' '));
            //Agencia 027-030
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.Trim());
            //Zeros 031-032
            registros.Append("00");
            //Numero conta 033-037
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.Trim());
            //DAC agencia/conta 038-038
            registros.Append(Utils.Estruturas.Mod10(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.Trim() +
                aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.Trim()));
            //Brancos 039-046
            registros.Append("".FormatStringDireita(8, ' '));
            //Nome empresa 047-076
            registros.Append(aCobranca.Titulos[tot_registros].Nm_cedente.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Codigo banco 077-079
            registros.Append(CodigoBanco);
            //Nome banco 080-094
            registros.Append(NomeBanco.Trim().FormatStringDireita(15, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Brancos 101-394
            registros.Append("".FormatStringDireita(294, ' '));
            //Numero registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion

            aCobranca.Titulos.ForEach(p =>
            {
                #region Registro Detalhe
                registros = new StringBuilder();
                if (aCobranca.Cd_instrucao.Equals(2) ||
                    aCobranca.Cd_instrucao.Equals(6))//Pedido de baixa ou alterar vencimento
                {
                    //Tipo registro 001-001
                    registros.Append("1");
                    //Tipo inscricao 002-003
                    registros.Append("".FormatStringDireita(2, '0'));
                    //Numero inscricao 004-017
                    registros.Append("".FormatStringEsquerda(14, '0'));
                    //Agencia conta 018-021
                    registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.Trim());
                    //Zeros 022-023
                    registros.Append("00");
                    //Conta 024-028
                    registros.Append(p.Cedente.ContaBancaria.NumeroConta.Trim());
                    //DAC Agencia/Conta 029-029
                    registros.Append(Utils.Estruturas.Mod10(p.Cedente.ContaBancaria.CodigoAgencia.Trim() + p.Cedente.ContaBancaria.NumeroConta.Trim()));
                    //Brancos 030-033
                    registros.Append("".FormatStringDireita(4, ' '));
                    //Codigo Instrucao/Alegacao 034-037
                    registros.Append("0000");
                    //Identificao titulo empresa 038-062
                    registros.Append("".FormatStringDireita(25, ' '));
                    //Nosso numero 063-070
                    registros.Append(p.Nosso_numero.FormatStringEsquerda(8, '0'));
                    //Qtde moeda 071-083
                    registros.Append("".FormatStringDireita(13, '0'));
                    //Carteira 084-086
                    registros.Append(p.Carteira.Trim());
                    //Brancos 087-107
                    registros.Append("".FormatStringDireita(21, ' '));
                    //Codigo carteira 108-108
                    registros.Append("I");
                    //Codigo instrucao 109-110
                    registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                    //Nº documento cobranca 111-120
                    registros.Append("".FormatStringDireita(10, ' '));
                    //Vencimento 121-126
                    registros.Append(aCobranca.Cd_instrucao.Equals(6) ? p.Dt_vencimento.Value.ToString("ddMMyy") : "".FormatStringEsquerda(6, '0'));
                    //Valor documento 127-139
                    registros.Append(p.Vl_documento.SoNumero().FormatStringEsquerda(13, '0'));
                    //Codigo banco 140-142
                    registros.Append("000");
                    //Agencia cobradora 143-147
                    registros.Append("00000");
                    //Especie titulo 148-149
                    registros.Append("  ");
                    //Aceite 150-150
                    registros.Append(" ");
                    //Data emissao 151-156
                    registros.Append("".FormatStringEsquerda(6, '0'));
                    //Instrucao cobranca 1 157-158
                    registros.Append("00");
                    //Instrucao cobranca 2 159-160
                    registros.Append("00");
                    //Juro 161-173
                    registros.Append((p.Tp_jurodia.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100) : p.Pc_jurodia).FormatStringEsquerda(13, '0'));
                    //Data Limite concessao desconto 174-179
                    registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : p.Dt_vencimento.Value.ToString("ddMMyy"));
                    //Valor desconto 180-192
                    registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                    //Valor IOF 193-205
                    registros.Append("".FormatStringEsquerda(13, '0'));
                    //Valor abatimento 206-218
                    registros.Append("".FormatStringEsquerda(13, '0'));
                    //Tipo inscricao sacado 219-220
                    registros.Append("00");
                    //Inscricao sacado 221-234
                    registros.Append("".FormatStringEsquerda(14, '0'));
                    //Nome sacado 235-264
                    registros.Append("".FormatStringDireita(30, ' '));
                    //Brancos 265-274
                    registros.Append("".FormatStringDireita(10, ' '));
                    //Endereco 275-314
                    registros.Append("".FormatStringDireita(40, ' '));
                    //Bairro 315-326
                    registros.Append("".FormatStringDireita(12, ' '));
                    //CEP 327-334
                    registros.Append("".FormatStringEsquerda(8, '0'));
                    //Cidade 335-349
                    registros.Append("".FormatStringDireita(15, ' '));
                    //Estado 350-351
                    registros.Append("  ");
                    //Sacador avalista 352-381
                    registros.Append("".FormatStringDireita(30, ' '));
                    //Brancos 382-385
                    registros.Append("".FormatStringDireita(4, ' '));
                    //Data mora 386-391
                    registros.Append("000000");
                    //Prazo dias 392-393
                    registros.Append("00");
                    //Brancos 394-394
                    registros.Append(" ");
                    //Numero registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));
                }
                else
                {
                    //Tipo registro 001-001
                    registros.Append("1");
                    //Tipo inscricao 002-003
                    registros.Append(p.Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "02" : "01");
                    //Numero inscricao 004-017
                    registros.Append(p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                    //Agencia conta 018-021
                    registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.Trim());
                    //Zeros 022-023
                    registros.Append("00");
                    //Conta 024-028
                    registros.Append(p.Cedente.ContaBancaria.NumeroConta.Trim());
                    //DAC Agencia/Conta 029-029
                    registros.Append(Utils.Estruturas.Mod10(p.Cedente.ContaBancaria.CodigoAgencia.Trim() + p.Cedente.ContaBancaria.NumeroConta.Trim()));
                    //Brancos 030-033
                    registros.Append("".FormatStringDireita(4, ' '));
                    //Codigo Instrucao/Alegacao 034-037
                    registros.Append("0000");
                    //Identificao titulo empresa 038-062
                    registros.Append("".FormatStringDireita(25, ' '));
                    //Nosso numero 063-070
                    registros.Append(p.Nosso_numero.FormatStringEsquerda(8, '0'));
                    //Qtde moeda 071-083
                    registros.Append("".FormatStringDireita(13, '0'));
                    //Carteira 084-086
                    registros.Append(p.Carteira.Trim());
                    //Brancos 087-107
                    registros.Append("".FormatStringDireita(21, ' '));
                    //Codigo carteira 108-108
                    registros.Append("I");
                    //Codigo instrucao 109-110
                    registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                    //Nº documento cobranca 111-120
                    registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).FormatStringDireita(10, ' '));
                    //Vencimento 121-126
                    registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                    //Valor documento 127-139
                    registros.Append(p.Vl_documento.SoNumero().FormatStringEsquerda(13, '0'));
                    //Codigo banco 140-142
                    registros.Append(CodigoBanco);
                    //Agencia cobradora 143-147
                    registros.Append("00000");
                    //Especie titulo 148-149
                    registros.Append(ConverterEspecieDoc(p.Especie_documento));
                    //Aceite 150-150
                    registros.Append(p.Aceite_SN.Trim().ToUpper().Equals("S") ? "A" : "N");
                    //Data emissao 151-156
                    registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                    //Instrucao cobranca 1 157-158
                    registros.Append("00");
                    //Instrucao cobranca 2 159-160
                    registros.Append("00");
                    //Juro 161-173
                    registros.Append(p.Vl_morajuros.SoNumero().FormatStringEsquerda(13, '0'));
                    //Data desconto 174-179
                    registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                    //Valor desconto 180-192
                    registros.Append(p.Vl_desconto.SoNumero().FormatStringEsquerda(13, '0'));
                    //Valor IOF 193-205
                    registros.Append("".FormatStringEsquerda(13, '0'));
                    //Valor abatimento 206-218
                    registros.Append(p.Vl_abatimento.SoNumero().FormatStringEsquerda(13, '0'));
                    //Tipo inscricao sacado 219-220
                    registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "02" : "01");
                    //Inscricao sacado 221-234
                    registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                    //Nome sacado 235-264
                    registros.Append(p.Sacado.Nome.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
                    //Brancos 265-274
                    registros.Append("".FormatStringDireita(10, ' '));
                    //Endereco 275-314
                    registros.Append((p.Sacado.Endereco.Rua.Trim() + "," + p.Sacado.Endereco.Numero.Trim()).RemoverCaracteres().FormatStringDireita(40, ' '));
                    //Bairro 315-326
                    registros.Append(p.Sacado.Endereco.Bairro.Trim().RemoverCaracteres().FormatStringDireita(12, ' '));
                    //CEP 327-334
                    registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                    //Cidade 335-349
                    registros.Append(p.Sacado.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                    //Estado 350-351
                    registros.Append(p.Sacado.Endereco.Estado.Trim());
                    //Sacador avalista 352-381
                    registros.Append(p.Avalista.Nome.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
                    //Brancos 382-385
                    registros.Append("".FormatStringDireita(4, ' '));
                    //Data mora 386-391
                    registros.Append("000000");
                    //Prazo dias 392-393
                    registros.Append("00");
                    //Brancos 394-394
                    registros.Append(" ");
                    //Numero registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));
                }

                Remessa.AppendLine(registros.ToString());

                #endregion

                #region Avalista
                if ((!string.IsNullOrEmpty(p.Avalista.Nome)) && aCobranca.Cd_instrucao.Equals(1))
                {
                    registros = new StringBuilder();
                    //Tipo registro 001-001
                    registros.Append("5");
                    //Brancos 002-121
                    registros.Append("".FormatStringDireita(120, ' '));
                    //Tipo inscricao avalista 122-123
                    registros.Append(p.Avalista.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "02" : "01");
                    //Numero inscricao 124-137
                    registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                    //Endereco 138-177
                    registros.Append((p.Avalista.Endereco.Rua.Trim() + "," + p.Avalista.Endereco.Numero.Trim()).RemoverCaracteres().FormatStringDireita(40, ' '));
                    //Bairro 178-189
                    registros.Append(p.Avalista.Endereco.Bairro.Trim().FormatStringDireita(12, ' '));
                    //CEP 190-197
                    registros.Append(p.Avalista.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                    //Cidade 198-212
                    registros.Append(p.Avalista.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                    //Estado 213-214
                    registros.Append(p.Avalista.Endereco.Estado.Trim());
                    //Brancos 215-394
                    registros.Append("".FormatStringDireita(180, ' '));
                    //Numero registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                    Remessa.AppendLine(registros.ToString());
                }
                #endregion
            });

            #region Trailer
            registros = new StringBuilder();
            //Tipo registro 001-001
            registros.Append("9");
            //Brancos 002-394
            registros.Append("".FormatStringDireita(393, ' '));
            //Numero registro
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
                ACodigoCedente = Retorno[NumeroRegistro].Substring(32, 5);

                if (Retorno[NumeroRegistro].Substring(94, 6).PadLeft(6, '0') != "000000")
                    ACobranca.DataArquivo = new DateTime(2000 + Convert.ToInt32(Retorno[NumeroRegistro].Substring(98, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(96, 2)),
                                                         Convert.ToInt32(Retorno[NumeroRegistro].Substring(94, 2)));
                else
                    ACobranca.DataArquivo = DateTime.Now;

                if (Retorno[NumeroRegistro].Substring(108, 5).PadLeft(5, '0') != "00000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(108, 5));
                else
                    ACobranca.SequencialArq = 0;

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
                    ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(85, 8);
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
                    string codigo = Retorno[NumeroRegistro].Substring(377, 8);
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
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path_remessa + "C" + DateTime.Now.ToString("ddMMyy") +".TXT", true, Encoding.Default))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
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
    }
}
