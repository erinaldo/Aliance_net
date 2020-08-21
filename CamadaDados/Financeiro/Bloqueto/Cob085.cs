using System;
using System.IO;
using System.Text;
using System.Linq;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco085
    {
        const string CodigoBanco = "085";
        const string NomeBanco = "CECRED";

        public string GetNomeBanco() { return NomeBanco; }

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            string cl = ATitulo.Cedente.CodigoCedente.FormatStringEsquerda(6, '0') +
                        ATitulo.Nosso_numero.FormatStringEsquerda(17, '0') +
                        ATitulo.Carteira.FormatStringEsquerda(2, '0');
            return cl.Trim();
        }
        public string CalcularNossoNumero(decimal vNossoNumero, string CodigoAgencia, string DigitoAgencia)
        {
            return CodigoAgencia.Trim() + DigitoAgencia.Trim() + (vNossoNumero + 1).ToString().FormatStringEsquerda(9, '0');
        }
        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Estruturas.Mod11(ATitulo.Nosso_numero.Trim(), 9, false, 0).ToString().Trim();
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
                case "CD": { return 7; }
                case "CE": { return 8; }
                case "PT": { return 9; }
                case "CP": { return 10; }
                case "OO": { return 31; }
                default: return decimal.Zero;
            }
        }
        private string TratarOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "02": return "ENTRADA CONFIRMADA";
                case "03": return "ENTRADA REJEITADA";
                case "06": return "LIQUIDAÇÃO";
                case "07": return "CONFIRMAÇÃO DO RECEBIMENTO DA INSTRUÇÃO DE DESCONTO";
                case "08": return "CONFIRMAÇÃO DO RECEBIMENTO DO CANCELAMENTO DO DESCONTO";
                case "09": return "BAIXA";
                case "12": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE ABATIMENTO";
                case "13": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE CANCELAMENTO DE ABATIMENTO";
                case "14": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO ALTERAÇÃO DE VENCIMENTO";
                case "17": return "LIQUIDAÇÃO APÓS BAIXA OU LIQUIDAÇÃO TÍTULO NÃO REGISTRADO";
                case "19": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE SUSTAÇÃO/CANCELAMENTO DE PROTESTO";
                case "23": return "REMESSA A CARTORIO/APONTE EM CARTORIO";
                case "24": return "RETIRADA DE CARTORIO E MANUTENÇÃO EM CARTEIRA";
                case "25": return "PROTESTADO E BAIXADO/BAIXA POR TER SIDO PROTESTADO";
                case "26": return "INSTRUÇÃO REJEITADA";
                case "27": return "CONFIRMAÇÃO DO PEDIDO DE ALTERAÇÃO DE OUTROS DADOS";
                case "28": return "DEBITO DE TARIFAS/CUSTAS";
                case "36": return "CONFIRMAÇÃO DE ENVIO DE SMS";
                case "37": return "ENVIO DE SMS REJEITADO";
                case "42": return "CONFIRMAÇÃO DA ALTERAÇÃO DOS DADOS DO SACADO";
                case "46": return "INSTRUÇÃO PARA CANCELAR PROTESTO CONFIRMADA";
                case "64": return "CANCELAMENTO DE SMS";
                case "76": return "LIQUIDAÇÃO DE BOLETO/COOPERATIVA EMITE E EXPEDE";
                case "77": return "LIQUIDAÇÃO DE BOLETO APÓS BAIXA OU NÃO REGISTRADO/COOPERATIVA EMITE E EXPEDE";
                case "91": return "TITULO EM ABERTO NÃO ENVIADO AO PAGADOR";
                case "92": return "INCONSISTÊNCIA NEGATIVAÇÃO SERASA";
                case "93": return "INCLUSÃO NEGATIVAÇÃO VIA SERASA";
                case "94": return "EXCLUSÃO NEGATIVAÇÃO SERASA";
                default: return string.Empty;
            }
        }
        private string TratarMotivoOcorrencia(string codigo)
        {
            string mov = "";
            string[] cod = new string[5];
            cod[0] = codigo.Substring(0, 2);
            cod[1] = codigo.Substring(2, 2);
            cod[2] = codigo.Substring(4, 2);
            cod[3] = codigo.Substring(6, 2);
            cod[4] = codigo.Substring(8, 2);
            
            foreach (string x in cod){
                switch (x)
                {
                    case "01": mov += "CÓDIGO DO BANCO INVÁLIDO "; break;
                    case "02": mov += "CÓDIGO DO REGISTRO DETALHE INVÁLIDO "; break;
                    case "03": mov += "CÓDIGO DO SEGMENTO INVÁLIDO "; break;
                    case "04": mov += "CÓDIGO DE MOVIMENTO NÃO PERMITIDO PARA CARTEIRA "; break;
                    case "05": mov += "CÓDIGO DE MOVIMENTO INVÁLIDO "; break;
                    case "06": mov += "TIPO/NÚMERO DE INSCRIÇÃO DO CEDENTE INVÁLIDOS "; break;
                    case "07": mov += "AGÊNCIA/CONTA/DV INVÁLIDO "; break;
                    case "08": mov += "NOSSO NÚMERO INVÁLIDO "; break;
                    case "09": mov += "NOSSO NÚMERO DUPLICADO "; break;
                    case "10": mov += "CARTEIRA INVÁLIDA "; break;
                    case "11": mov += "FORMA DE CADASTRAMENTO DO TÍTULO INVÁLIDO "; break;
                    case "12": mov += "TIPO DE DOCUMENTO INVÁLIDO "; break;
                    case "13": mov += "IDENTIFICAÇÃO DA EMISSÃO DO BOLETO INVÁLIDA "; break;
                    case "14": mov += "IDENTIFICAÇÃO DA DISTRIBUIÇÃO DO BOLETO INVÁLIDA "; break;
                    case "15": mov += "CARACTERÍSTICAS DA COBRANÇA INCOMPATÍVEIS "; break;
                    case "16": mov += "DATA DE VENCIMENTO INVÁLIDA "; break;
                    case "17": mov += "DATA DE VENCIMENTO ANTERIOR A DATA DE EMISSAO "; break;
                    case "18": mov += "VENCIMENTO FORA DO PRAZO DE OPERAÇÃO "; break;
                    case "19": mov += "TÍTULO A CARGO DE BANCOS CORRESPONDENTES COM VENCIMENTO INFERIOR A XX DIAS "; break;
                    case "20": mov += "VALOR DO TÍTULO INVÁLIDO "; break;
                    case "21": mov += "ESPÉCIE DO TÍTULO INVÁLIDA "; break;
                    case "22": mov += "ESPÉCIE DO TÍTULO NÃO PERMITIDA PARA A CARTEIRA "; break;
                    case "23": mov += "ACEITE INVÁLIDO "; break;
                    case "24": mov += "DATA DA EMISSÃO INVÁLIDA "; break;
                    case "25": mov += "DATA DA EMISSÃO POSTERIOR A DATA DE ENTRADA "; break;
                    case "26": mov += "CÓDIGO DE JUROS DE MORA INVÁLIDO "; break;
                    case "27": mov += "VALOR/TAXA DE JUROS DE MORA INVÁLIDO "; break;
                    case "28": mov += "CÓDIGO DO DESCONTO INVÁLIDO "; break;
                    case "29": mov += "VALOR DO DESCONTO MAIOR OU IGUAL AO VALOR DO TÍTULO "; break;
                    case "30": mov += "DESCONTO A CONCEDER NÃO CONFERE "; break;
                    case "31": mov += "CONCESSÃO DE DESCONTO - JÁ EXISTE DESCONTO ANTERIOR "; break;
                    case "33": mov += "VALOR DO ABATIMENTO INVÁLIDO "; break;
                    case "34": mov += "VALOR DO ABATIMENTO MAIOR OU IGUAL AO VALOR DO TÍTULO "; break;
                    case "35": mov += "VALOR A CONCEDER NÃO CONFERE "; break;
                    case "36": mov += "CONCESSÃO DE ABATIMENTO - JÁ EXISTE ABATIMENTO ANTERIOR "; break;
                    case "37": mov += "CÓDIGO PARA PROTESTO INVÁLIDO "; break;
                    case "38": mov += "PRAZO PARA PROTESTO INVÁLIDO "; break;
                    case "39": mov += "PEDIDO DE PROTESTO NÃO PERMITIDO PARA O TÍTULO "; break;
                    case "40": mov += "TÍTULO COM ORDEM DE PROTESTO EMITIDA "; break;
                    case "41": mov += "PEDIDO DE CANCELAMENTO/SUSTAÇÃO PARA TÍTULOS SEM INSTRUÇÃO DE PROTESTO "; break;
                    case "42": mov += "CÓDIGO PARA BAIXA/DEVOLUÇÃO INVÁLIDO "; break;
                    case "43": mov += "PRAZO PARA BAIXA/DEVOLUÇÃO INVÁLIDO "; break;
                    case "44": mov += "CÓDIGO DA MOEDA INVÁLIDO "; break;
                    case "45": mov += "NOME DO SACADO NÃO INFORMADO "; break;
                    case "46": mov += "TIPO/NÚMERO DE INSCRIÇÃO DO SACADO INVÁLIDOS "; break;
                    case "47": mov += "ENDEREÇO DO SACADO NÃO INFORMADO "; break;
                    case "48": mov += "CEP INVÁLIDO "; break;
                    case "49": mov += "CEP SEM PRAÇA DE COBRANÇA (NÃO LOCALIZADO) "; break;
                    case "50": mov += "CEP REFERENTE A UM BANCO CORRESPONDENTE "; break;
                    case "51": mov += "CEP INCOMPATÍVEL COM A UNIDADE DA FEDERAÇÃO "; break;
                    case "52": mov += "UNIDADE DA FEDERAÇÃO INVÁLIDA "; break;
                    case "53": mov += "TIPO/NÚMERO DE INSCRIÇÃO DO SACADOR/AVALISTA INVÁLIDOS "; break;
                    case "54": mov += "SACADOR/AVALISTA NÃO INFORMADO "; break;
                    case "55": mov += "NOSSO NÚMERO NO BANCO CORRESPONDENTE NÃO INFORMADO "; break;
                    case "56": mov += "CÓDIGO DO BANCO CORRESPONDENTE NÃO INFORMADO "; break;
                    case "57": mov += "CÓDIGO DA MULTA INVÁLIDO "; break;
                    case "58": mov += "DATA DA MULTA INVÁLIDA "; break;
                    case "59": mov += "VALOR/PERCENTUAL DA MULTA INVÁLIDO "; break;
                    case "60": mov += "MOVIMENTO PARA TÍTULO NÃO CADASTRADO "; break;
                    case "61": mov += "ALTERAÇÃO DA AGÊNCIA COBRADORA/DV INVÁLIDA "; break;
                    case "62": mov += "TIPO DE IMPRESSÃO INVÁLIDO "; break;
                    case "63": mov += "ENTRADA PARA TÍTULO JÁ CADASTRADO "; break;
                    case "64": mov += "NÚMERO DA LINHA INVÁLIDO "; break;
                    case "65": mov += "CÓDIGO DO BANCO PARA DÉBITO INVÁLIDO "; break;
                    case "66": mov += "AGÊNCIA/CONTA/DV PARA DÉBITO INVÁLIDO "; break;
                    case "79": mov += "DATA JUROS DE MORA INVÁLIDO "; break;
                    case "80": mov += "DATA DO DESCONTO INVÁLIDA "; break;
                    case "86": mov += "SEU NÚMERO INVÁLIDO "; break;
                }
            }
            return mov;
        }
        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantil: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edCheque: return "10";
                case TEspecieDocumento.edDuplicataServico: return "12";
                default: return "99";
            }
        }
        private void GerarRemessaCNAB240(blCobranca cobranca, StringBuilder Remessa)
        {
            if (cobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");

            StringBuilder registros = new StringBuilder();

            #region Registro Header Arquivo
            //Codigo do banco 001-003
            registros.Append(CodigoBanco);
            //Lote Servico 004-007
            registros.Append("0000");
            //Tipo Registro 008-008
            registros.Append("0");
            //Brancos 009-017
            registros.Append(string.Empty.FormatStringDireita(9, ' '));
            //Tipo insc. cedente 018-018
            registros.Append(cobranca.Titulos[0].Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "2");
            //Inscrição cedente 019--032
            registros.Append(cobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
            //Codigo cedente 033-052
            registros.Append(cobranca.Titulos[0].Cedente.CodigoCedente.FormatStringDireita(20, ' '));
            //Agencia cedente 053-057
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito agencia 058-058
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.FormatStringEsquerda(1, '0'));
            //Conta corrente 059-070
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
            //Digito Conta 071-071
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta.FormatStringEsquerda(1, '0'));
            //Branco 072-072
            registros.Append(" ");
            //Nome cedente 073-102
            registros.Append(cobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Nome cooperativa 103-132
            registros.Append(NomeBanco.FormatStringDireita(30, ' '));
            //Brancos 133-142
            registros.Append(string.Empty.FormatStringDireita(10, ' '));
            //Codigo remessa 143-143
            registros.Append("1");
            //Data arquivo 144-151
            registros.Append(cobranca.DataArquivo.ToString("ddMMyyyy"));
            //Hora arquivo 152-157
            registros.Append(cobranca.DataArquivo.ToString("HHmmss"));
            //Numero Arquivo 158-163
            registros.Append(cobranca.SequencialArq.FormatStringEsquerda(6, '0'));
            //Numero versao 164-166
            registros.Append("087");
            //Densidade gravação 167-171
            registros.Append("01600");
            //Brancos 172-240
            registros.Append(string.Empty.FormatStringDireita(69, ' '));

            Remessa.AppendLine(registros.ToString());
            int tot_registro = 1;
            #endregion

            #region Registro Header Lote
            registros = new StringBuilder();
            //Codigo do banco 001-003
            registros.Append(CodigoBanco.Trim());
            //Lote servico 004-007
            registros.Append("0001");
            //Tipo registro 008-008
            registros.Append("1");
            //Tipo operação 009-009
            registros.Append("R");
            //Tipo serviço 010-011
            registros.Append("01");
            //Brancos 012-013
            registros.Append(string.Empty.FormatStringDireita(2, ' '));
            //Versão do layout 014-016
            registros.Append("045");
            //Branco 017-017
            registros.Append(" ");
            //Tipo Inscrição Empresa 018-018
            registros.Append(cobranca.Titulos[0].Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "1" : "2");
            //Inscrição Empresa 019-033
            registros.Append(cobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
            //Codigo Cendente 034-053
            registros.Append(cobranca.Titulos[0].Cedente.CodigoCedente.FormatStringDireita(20, ' '));
            //Agencia 054-058
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito Agencia 059-059
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.FormatStringEsquerda(1, '0'));
            //Conta Corrente 060-071
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
            //Digito Conta 072-072
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta.FormatStringEsquerda(1, '0'));
            //Digito Ag/Conta 073-073
            registros.Append(" ");
            //Nome Empresa 074-103
            registros.Append(cobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Mensagem 1 104-143
            registros.Append(string.Empty.FormatStringDireita(40, ' '));
            //Mensagem 2 144-183
            registros.Append(string.Empty.FormatStringDireita(40, ' '));
            //Numero Arquivo 184-191
            registros.Append(cobranca.SequencialArq.ToString().FormatStringEsquerda(8, '0'));
            //Data arquivo 192-199
            registros.Append(cobranca.DataArquivo.ToString("ddMMyyyy"));
            //Zeros 200-207
            registros.Append("0".FormatStringEsquerda(8, '0'));
            //Filler 208-240
            registros.Append("".FormatStringDireita(33, ' '));

            Remessa.AppendLine(registros.ToString());
            tot_registro += 1;
            #endregion

            #region Detalhes
            int lote = 1;
            cobranca.Titulos.ForEach(p =>
            {
                #region Segmento P
                registros = new StringBuilder();
                //Codigo Banco 001-003
                registros.Append(CodigoBanco);
                //Numero lote 004-007
                registros.Append("0001");
                //Tipo registro 008-008
                registros.Append("3");
                //Numero sequencial lote 009-013
                registros.Append("00001");
                //Codigo segmento 014-014
                registros.Append("P");
                //Brancos 015-015
                registros.Append(" ");
                //Cogido Instrucao 016-017
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Agencia 018-022
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
                //Digito Agencia 023-023
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia.FormatStringEsquerda(1, '0'));
                //Conta Corrente 024-035
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
                //Digito conta 036-036
                registros.Append(p.Cedente.ContaBancaria.DigitoConta.FormatStringEsquerda(1, '0'));
                //Branco 037-037
                registros.Append(" ");
                //Nosso numero 038-057
                registros.Append(p.Nosso_numero.FormatStringDireita(20, ' '));
                //Carteira 058-058
                registros.Append(p.Carteira.Trim());
                //Forma cadastro banco 059-059
                registros.Append("1");
                //Tipo documento 060-060
                registros.Append("1");
                //Identificação emissão 061-061
                registros.Append("2");
                //Identificação distribuição 062-062
                registros.Append("2");
                //Numero documento 063-077
                registros.Append((p.Nr_lancto.ToString() + p.Cd_parcela.ToString() + p.Id_cobranca.ToString()).FormatStringDireita(15, ' '));
                //Vencimento 078-085
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor titulo 086-100
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //Agencia cobrança 101-105
                registros.Append("00000");
                //Digito agencia cobrança 106-106
                registros.Append(" ");
                //Especie titulo 107-108
                registros.Append(p.RetornarCodigoEspecieDocumento().FormatStringEsquerda(2, '0'));
                //Tipo aceite 109-109
                registros.Append(p.Aceite_documento.Equals(TAceiteDocumento.adSim) ? "A" : "N");
                //Data emissão 110-117
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyyyy"));
                //Codigo juro 118-118
                registros.Append(p.Pc_jurodia > decimal.Zero ? p.Tp_jurodia.Trim().ToUpper().Equals("P") ? "2" : "1" : "3");
                //Data Juro 119-126
                registros.Append("00000000");
                //Juros valor/% 127-141
                registros.Append((p.Pc_jurodia * (p.Tp_jurodia.Trim().ToUpper().Equals("P") ? 30 : 1)).SoNumero().FormatStringEsquerda(15, '0'));
                //Codigo desconto 142-142
                registros.Append(p.Pc_desconto > decimal.Zero ? "1" : "0");
                //Data desconto 143-150
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyyyy") : p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor desconto 151-165
                registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //IOF 166-180
                registros.Append(decimal.Zero.FormatStringEsquerda(15, '0'));
                //Valor abatimento 181-195
                registros.Append(p.Vl_abatimento.SoNumero().FormatStringEsquerda(15, '0'));
                //Identificação titulo na empresa 196-220
                registros.Append((p.Nosso_numero.Trim() + cobranca.Cd_instrucao.ToString()).FormatStringDireita(25, ' '));
                //Protestar 221-221
                registros.Append(p.St_protestarauto ? "1" : "3");
                //Prazo protesto 222-223
                registros.Append(p.St_protestarauto ? p.Nr_diasprotestar < 5 ? "05" : p.Nr_diasprotestar > 15 ? "15" : p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "00");
                //Codigo baixa 224-224
                registros.Append("2");
                //Prazo baixa 225-227
                registros.Append("   ");
                //Codigo moeda 228-229
                registros.Append("09");
                //Numero contrato 230-239
                registros.Append(decimal.Zero.FormatStringEsquerda(10, '0'));
                //Brancos 240-240
                registros.Append(" ");

                Remessa.AppendLine(registros.ToString());
                tot_registro++;
                lote++;
                #endregion

                #region Segmento Q
                registros = new StringBuilder();
                //Zeros 001-003
                registros.Append(CodigoBanco);
                //Lote servico 004-007
                registros.Append("0001");
                //Registro 008-008
                registros.Append("3");
                //numero registro 009-013
                registros.Append("00002");
                //Codigo segmento 014-014
                registros.Append("Q");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo instrucao = igual informado segmento P 016-017
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Tipo inscricao sacado 018-018
                registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : "2");
                //Cnpj/Cpf 019-033
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome sacado 034-073
                registros.Append(p.Sacado.Nome.Trim().RemoverCaracteres().FormatStringDireita(40, ' '));
                //Endereco sacado 074-113
                registros.Append((p.Sacado.Endereco.Rua.Trim().RemoverCaracteres() + "," + p.Sacado.Endereco.Numero.RemoverCaracteres()).FormatStringDireita(40, ' '));
                //Bairro sacado 114-128
                registros.Append(p.Sacado.Endereco.Bairro.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                //CEP 129-133
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().Substring(0, 5));
                //Sufixo CEP 134-136
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().Substring(5, 3));
                //Cidade 137-151
                registros.Append(p.Sacado.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                //Sigla Estado 152-153
                registros.Append(p.Sacado.Endereco.Estado.FormatStringDireita(2, ' '));
                //Tipo inscricao avalista 154-154
                registros.Append(p.Avalista.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "1" : p.Avalista.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "2" : "0");
                //Inscricao avalista 155-169
                registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
                //Nome avalista 170-209
                registros.Append(p.Avalista.Nome.RemoverCaracteres().FormatStringDireita(40, ' '));
                //Filler 210-240
                registros.Append("".FormatStringDireita(31, ' '));

                Remessa.AppendLine(registros.ToString());
                tot_registro++;
                lote++;
                #endregion
            });

            #endregion

            #region Registro Trailer Lote
            registros = new StringBuilder();
            //Codigo Banco 001-003
            registros.Append(CodigoBanco);
            //Lote Servico 004-007
            registros.Append("0001");
            //Tipo registro 008-008
            registros.Append("5");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Quantidade total registros lote 018-023
            registros.Append((lote + 1).ToString().FormatStringEsquerda(6, '0'));
            //Quantidade titulos 024-029
            registros.Append(cobranca.Titulos.Count.FormatStringEsquerda(6, '0'));
            //Valor titulos 030-046
            registros.Append(cobranca.Titulos.Sum(p => p.Vl_documento).SoNumero().FormatStringEsquerda(17, '0'));
            //Zeros 047-115
            registros.Append("0".FormatStringEsquerda(69, '0'));
            //Filler 116-240
            registros.Append("".FormatStringDireita(125, ' '));

            Remessa.AppendLine(registros.ToString());
            tot_registro++;
            #endregion

            #region Trailer Arquivo
            registros = new StringBuilder();
            //Codigo banco 001-003
            registros.Append(CodigoBanco);
            //Lote servico 004-007
            registros.Append("9999");
            //Tipo registro 008-008
            registros.Append("9");
            //Brancos 009-017
            registros.Append(string.Empty.FormatStringDireita(9, ' '));
            //Quantidade Lotes 018-023
            registros.Append("000001");
            //Quantidade registros 024-029
            registros.Append((tot_registro + 1).FormatStringEsquerda(6, '0'));
            //Qtd contas 030-035
            registros.Append("000000");
            //Brancos 036-240
            registros.Append(string.Empty.FormatStringDireita(205, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }
        public void GerarRemessaCNAB400(blCobranca aCobranca, StringBuilder Remessa)
        {
            if (aCobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");
            StringBuilder registros = new StringBuilder();
            int tot_registros = 0;
            #region Header
            //Identificação registro 001-001
            registros.Append("0");
            //Tipo Operação 002-002
            registros.Append("1");
            //Identificação 003-009
            registros.Append("REMESSA");
            //Tipo serviço 010-011
            registros.Append("01");
            //Serviço 012-019
            registros.Append("COBRANCA");
            //Brancos 020-026
            registros.Append(string.Empty.FormatStringDireita(7, ' '));
            //Numero Agencia 027-030
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Digito Agencia 031-031
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.FormatStringDireita(1, ' '));
            //Conta Corrente 032-039
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0'));
            //Digito Conta 040-040
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta.FormatStringDireita(1, ' '));
            //Complemento 041-046
            registros.Append(string.Empty.FormatStringEsquerda(6, '0'));
            //Nome Cedente 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Banco 077-094
            registros.Append((CodigoBanco + NomeBanco).FormatStringDireita(18, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Sequencial arquivo 101-107
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(7, '0'));
            //Complementos 108-149
            registros.Append(string.Empty.FormatStringDireita(42, ' '));
            //Numero Convenio 150-156
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(7, '0'));
            //Complementos 157-394
            registros.Append(string.Empty.FormatStringDireita(238, ' '));
            //Sequencia do registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Detalhe
            aCobranca.Titulos.ForEach(p =>
            {
                registros = new StringBuilder();
                //Identificação Registro 001-001
                registros.Append("7");
                //Tipo Inscrição Cedente 002-003
                registros.Append(p.Cedente.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //Numero doc cedente 004-017
                registros.Append(p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Prefixo Agencia 018-021
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Digito Agencia 022-022
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia.FormatStringDireita(1, ' '));
                //Conta Corrente 023-030
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(8, '0'));
                //Digito Conta 031-031
                registros.Append(p.Cedente.ContaBancaria.DigitoConta.FormatStringDireita(1, ' '));
                //Codigo Cedente 032-038
                registros.Append(p.Cedente.CodigoCedente.FormatStringEsquerda(7, '0'));
                //Codigo controle empresa 039-063
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(25, ' '));
                //Nosso numero 064-080
                registros.Append(p.Nosso_numero.FormatStringEsquerda(17, '0'));
                //Zeros 081-084
                registros.Append("0000");
                //Brancos 085-087
                registros.Append("   ");
                //Mensagem ou Avalista 088-088
                registros.Append(string.IsNullOrEmpty(p.Avalista.NumeroCPFCNPJ) ? " " : "A");
                //Brancos 089-091
                registros.Append("   ");
                //Variação Carteira 092-094
                registros.Append("   ");
                //Zeros 095-101
                registros.Append("0000000");
                //Tipo cobrança 102-106
                registros.Append("     ");
                //Carteira 107-108
                registros.Append(p.Carteira.FormatStringEsquerda(2, '0'));
                //Movimento Remessa 109-110
                registros.Append(TratarInstrucaoRemessa(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0')));
                //Seu numero 111-120
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(10, ' '));
                //Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor Titulo 127-139
                registros.Append(p.Vl_documento.SoNumero().FormatStringEsquerda(13, '0'));
                //Codigo Banco 140-142
                registros.Append(CodigoBanco);
                //Prefixo agencia cobradora 143-146
                registros.Append("0000");
                //Digito agencia cobradora 147-147
                registros.Append(" ");
                //Especie titulo 148-149
                registros.Append(ConverterEspecieDoc(p.Especie_documento).FormatStringEsquerda(2, '0'));
                //Aceite titulo 150-150
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "1" : "0");
                //Data emissão 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Instrução codificada 157-158
                registros.Append(p.St_protestarauto ? "09" : "  ");
                //Instrução codificada 159-160
                registros.Append("  ");
                //Juros de mora 161-173
                if (p.Pc_jurodia > decimal.Zero)
                    registros.Append((p.Tp_jurodia.Trim().ToUpper().Equals("P") ? decimal.Multiply(p.Vl_documento, decimal.Divide(p.Pc_jurodia, 100)) : p.Pc_jurodia).SoNumero().FormatStringEsquerda(13, '0'));
                else registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Zeros 174-179
                registros.Append("000000");
                //Valor desconto 180-192
                if (p.Pc_desconto > decimal.Zero)
                    registros.Append((p.Tp_desconto.Trim().ToUpper().Equals("P") ? decimal.Multiply(p.Vl_documento, decimal.Divide(p.Pc_desconto, 100)) : p.Pc_desconto).SoNumero().FormatStringEsquerda(13, '0'));
                else registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Zeros 193-205
                registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Valor Abatimento 206-218
                registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Tipo inscrição sacado 219-220
                registros.Append(p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //Inscrição sacado 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome sacado 235-271
                registros.Append(p.Sacado.Nome.RemoverCaracteres().FormatStringDireita(37, ' '));
                //Brancos 272-274
                registros.Append("   ");
                //Endereço Sacado 275-314
                registros.Append(p.Sacado.Endereco.Rua.RemoverCaracteres().FormatStringDireita(40, ' '));
                //Bairro Sacado 315-326
                registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().FormatStringDireita(12, ' '));
                //CEP Sacado 327-334
                registros.Append(p.Sacado.Endereco.CEP.FormatStringDireita(8, ' '));
                //Cidade Sacado 335-349
                registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().FormatStringDireita(15, ' '));
                //UF Sacado 350-351
                registros.Append(p.Sacado.Endereco.Estado.FormatStringDireita(2, ' '));
                //Obs/Avalista 352-391
                if (!string.IsNullOrEmpty(p.Avalista.NumeroCPFCNPJ))
                    if(p.Avalista.TipoInscricao == TTipoInscricao.tiPessoaJuridica)
                    {
                        //Nome avalista 352-372
                        registros.Append(p.Avalista.Nome.RemoverCaracteres().FormatStringDireita(21, ' '));
                        //Branco 373-373
                        registros.Append(" ");
                        //CNPJ 374-377
                        registros.Append("CNPJ");
                        //Numero 378-391
                        registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                    }
                    else
                    {
                        //Nome avalista 352-376
                        registros.Append(p.Avalista.Nome.RemoverCaracteres().FormatStringDireita(25, ' '));
                        //Branco 377-377
                        registros.Append(" ");
                        //CPJ 378-380
                        registros.Append("CPF");
                        //Numero 381-391
                        registros.Append(p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(11, '0'));
                    }
                else registros.Append(string.Empty.FormatStringDireita(40, ' '));
                //Dias Protesto 392-393
                registros.Append(p.St_protestarauto ?
                                    p.Nr_diasprotestar <= 5 ? "05" :
                                    p.Nr_diasprotestar >= 15 ? "15" :
                                    p.Nr_diasprotestar.FormatStringEsquerda(2, '0') : "  ");
                //Branco 394-394
                registros.Append(" ");
                //sequencial do registro 395-400
                registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

                Remessa.AppendLine(registros.ToString());
            });
            #endregion

            #region Trailer
            registros = new StringBuilder();
            //Identificação Registro 001-001
            registros.Append("9");
            //Complemento 002-394
            registros.Append(string.Empty.FormatStringDireita(393, ' '));
            //Sequencial registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }
        public void GerarRemessa(blCobranca cobranca, string Path_remessa)
        {
            StringBuilder remessa = new StringBuilder();
            switch (cobranca.LayoutArquivo)
            {
                case TLayoutArquivo.laCNAB240:
                    {
                        GerarRemessaCNAB240(cobranca, remessa);
                        break;
                    }
                case TLayoutArquivo.laCNAB400:
                    {
                        GerarRemessaCNAB400(cobranca, remessa);
                        break;
                    }
            }
            //Salvar arquivo de remessa na pasta configurada
            if (!Directory.Exists(Path_remessa))
                throw new Exception("Path salvar arquivo remessa invalido.");
            if (Path_remessa.Substring(Path_remessa.Length - 1, 1) != Path.DirectorySeparatorChar.ToString())
                Path_remessa += Path.DirectorySeparatorChar.ToString();
            using (StreamWriter sw = new StreamWriter(Path_remessa + ("CBR" +
                                                                     cobranca.DataArquivo.ToString("yyyyMMdd").Substring(0, 4) +
                                                                     cobranca.DataArquivo.ToString("yyyyMMdd").Substring(4, 2) +
                                                                     cobranca.DataArquivo.ToString("yyyyMMdd").Substring(6, 2) +
                                                                     cobranca.SequencialArq.ToString().FormatStringEsquerda(2, '0') +
                                                                     ".REM"),
                                                      false,
                                                      Encoding.GetEncoding("iso-8859-1")))
            {
                sw.Write(remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }
        private bool LerRetornoCNAB240(blCobranca ACobranca, string[] Retorno)
        {
            string ACodigoBanco;
            string ACodigoCedente;
            int NumeroRegistro = 0;
            blTitulo ATitulo = null;
            try
            {
                #region HEADER
                //Codigo do banco
                ACodigoBanco = Retorno[NumeroRegistro].Substring(0, 3);
                if (ACodigoBanco != CodigoBanco)
                    throw new Exception("Este não é um retorno de cobrança do banco " + CodigoBanco + " " + NomeBanco);
                //Codigo cedente
                ACodigoCedente = Retorno[NumeroRegistro].Substring(32, 20);
                //Data do arquivo
                if (Retorno[NumeroRegistro].Substring(143, 8) != "00000000")
                    ACobranca.DataArquivo = DateTime.Parse(Retorno[NumeroRegistro].Substring(143, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(145, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(147, 4));
                else
                    ACobranca.DataArquivo = DateTime.Now;
                //Numero arquivo
                ACobranca.SequencialArq = decimal.Parse(Retorno[NumeroRegistro].Substring(157, 6));
                #endregion

                for (NumeroRegistro = 1; NumeroRegistro <= (Retorno.Length - 2); NumeroRegistro++)
                {
                    //Tipo registro é 3
                    if (Retorno[NumeroRegistro].Substring(7, 1) == "3")
                    {
                        ATitulo = new blTitulo();
                        ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                        //Codigo do cedente
                        ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                        //Ocorrencia
                        ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(15, 2);
                        //Descricao ocorrencia
                        ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia); 
                        //Nosso numero
                        ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(37, 20);
                        //Data de vencimento
                        if (Retorno[NumeroRegistro].Substring(73, 8) != "00000000")
                            ATitulo.Dt_vencimento = DateTime.Parse(Retorno[NumeroRegistro].Substring(73, 2) + "/" +
                                                                    Retorno[NumeroRegistro].Substring(75, 2) + "/" +
                                                                    Retorno[NumeroRegistro].Substring(77, 4));
                        else
                            ATitulo.Dt_vencimento = DateTime.Now;
                        //Valor do titulo
                        if (Retorno[NumeroRegistro].Substring(81, 13) != "0000000000000")
                            ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(81, 13)) / 100;
                        else
                            ATitulo.Vl_documento = decimal.Zero;
                        //Valor das despesas
                        if (Retorno[NumeroRegistro].Substring(198, 13) != "0000000000000")
                            ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(198, 13)) / 100;
                        else
                            ATitulo.Vl_despesa_cobranca = decimal.Zero;

                        //Motivo ocorrencia
                        ATitulo.Ds_motivoocorrencia = TratarMotivoOcorrencia(Retorno[NumeroRegistro].Substring(213, 10));

                        if (Retorno[NumeroRegistro + 1].Substring(7, 1).Equals("3") &&
                            Retorno[NumeroRegistro + 1].Substring(13, 1).Equals("U"))
                        {
                            NumeroRegistro++;
                            //Juros
                            if (Retorno[NumeroRegistro].Substring(17, 13) != "0000000000000")
                                ATitulo.Vl_morajuros = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(17, 13)) / 100;
                            else
                                ATitulo.Vl_morajuros = decimal.Zero;
                            //Desconto
                            if (Retorno[NumeroRegistro].Substring(32, 13) != "0000000000000")
                                ATitulo.Vl_desconto = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(32, 13)) / 100;
                            else
                                ATitulo.Vl_desconto = decimal.Zero;
                            //Abatimento
                            if (Retorno[NumeroRegistro].Substring(47, 13) != "0000000000000")
                                ATitulo.Vl_abatimento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(47, 13)) / 100;
                            else
                                ATitulo.Vl_abatimento = decimal.Zero;
                            //Outras despesas
                            if (Retorno[NumeroRegistro].Substring(107, 13) != "0000000000000")
                                ATitulo.Vl_outras_despesas = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(107, 13)) / 100;
                            else
                                ATitulo.Vl_outras_despesas = decimal.Zero;
                            //Outros creditos
                            if (Retorno[NumeroRegistro].Substring(122, 13) != "0000000000000")
                                ATitulo.vl_outros_creditos = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(122, 13)) / 100;
                            else
                                ATitulo.vl_outros_creditos = decimal.Zero;
                            //Data ocorrencia
                            if (Retorno[NumeroRegistro].Substring(137, 8) != "00000000")
                                ATitulo.Dt_ocorrencia = DateTime.Parse(Retorno[NumeroRegistro].Substring(137, 2) + "/" +
                                                                        Retorno[NumeroRegistro].Substring(139, 2) + "/" +
                                                                        Retorno[NumeroRegistro].Substring(141, 4));
                            else
                                ATitulo.Dt_ocorrencia = DateTime.Now;
                            //Data credito
                            if (Retorno[NumeroRegistro].Substring(145, 8) != "00000000")
                                ATitulo.Dt_credito = DateTime.Parse(Retorno[NumeroRegistro].Substring(145, 2) + "/" +
                                                                        Retorno[NumeroRegistro].Substring(147, 2) + "/" +
                                                                        Retorno[NumeroRegistro].Substring(149, 4));
                            else
                                ATitulo.Dt_credito = DateTime.Now;
                        }
                        ACobranca.Titulos.Add(ATitulo);
                    }
                }
                return true;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
        public bool LerRetorno(blCobranca ACobranca, string[] arq)  //{Lê o arquivo retorno recebido do banco}
        {
            try
            {
                if (arq.Length <= 0)
                    throw new Exception("O retorno está vazio. Não há dados para processar");

                switch (ACobranca.LayoutArquivo)
                {
                    case TLayoutArquivo.laCNAB240: return LerRetornoCNAB240(ACobranca, arq);
                    case TLayoutArquivo.laCNAB400: throw new Exception("Esse layout não é implementado");
                    default: throw new Exception("Tamanho de registro inválido: " + arq[0].Length);
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
