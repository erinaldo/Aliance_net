using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco756
    {
        const string CodigoBanco = "756";
        const string NomeBanco = "SICOOB";
        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantialIndicacao: return "03";
                case TEspecieDocumento.edNotaPromissoria: return "12";
                case TEspecieDocumento.edNotaSeguro: return "16";
                case TEspecieDocumento.edRecibo: return "17";
                case TEspecieDocumento.edLetraCambio: return "07";
                case TEspecieDocumento.edNotaDebito: return "19";
                case TEspecieDocumento.edDuplicataServicoIndicacao: return "05";
                case TEspecieDocumento.edDuplicataMercantil: return "02";
                case TEspecieDocumento.edCheque: return "01";
                case TEspecieDocumento.edDuplicataServico: return "04";
                default: return "99";
            }
        }
        public string GetNomeBanco()
        {
            return NomeBanco;
        }
        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            string cl = ATitulo.Modalidade.Trim().FormatStringEsquerda(2, '0') +//Modalidade de Cobranca
                        (ATitulo.Cedente.CodigoCedente + ATitulo.Cedente.DigitoCodigoCedente).FormatStringEsquerda(7, '0') +
                        ATitulo.Nosso_numero.FormatStringEsquerda(7, '0') +
                        ATitulo.Digito_NossoNumero.Trim() +
                        "001";
            return cl.Trim();
        }
        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            return (vNossoNumero + 1).ToString().FormatStringEsquerda(7, '0');
        }
        public string CalcularDigitoNossoNumero(blTitulo ATitulo)
        {
            string calc = ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() +
                          (ATitulo.Cedente.CodigoCedente + ATitulo.Cedente.DigitoCodigoCedente).FormatStringEsquerda(10, '0') +
                          ATitulo.Nosso_numero.FormatStringEsquerda(7, '0');
            decimal ret = decimal.Zero;
            for (int i = 0; i < calc.Trim().Length; i++)
            {
                if (i == 0 ||
                    i == 4 ||
                    i == 8 ||
                    i == 12 ||
                    i == 16 ||
                    i == 20)
                    ret += decimal.Parse(calc[i].ToString()) * 3;
                else if (i == 1 ||
                    i == 5 ||
                    i == 9 ||
                    i == 13 ||
                    i == 17)
                    ret += decimal.Parse(calc[i].ToString()) * 1;
                else if (i == 2 ||
                    i == 5 ||
                    i == 10 ||
                    i == 14 ||
                    i == 18)
                    ret += decimal.Parse(calc[i].ToString()) * 9;
                else ret += decimal.Parse(calc[i].ToString()) * 7;
            }
            decimal resto = ret % 11;
            if (resto.Equals(0) || resto.Equals(1))
                return "0";
            else return (11 - (ret % 11)).ToString();
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
                case "04": return "TRANSFERENCIA DE CARTEIRA/ENTRADA";
                case "05": return "TRANSFERENCIA DE CARTEIRA/BAIXA";
                case "06": return "LIQUIDAÇÃO";
                case "09": return "BAIXA";
                case "11": return "TITULO EM CARTEIRA/EM SER";
                case "10": return "BAIXA CONFORME INSTRUÇÃO DA AGÊNCIA";
                case "12": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE ABATIMENTO";
                case "13": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE CANCELAMENTO DE ABATIMENTO";
                case "14": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO ALTERAÇÃO DE VENCIMENTO";
                case "17": return "LIQUIDAÇÃO APÓS BAIXA";
                case "19": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMAÇÃO RECEBIMENTO INSTRUÇÃO DE SUSTAÇÃO/CANCELAMENTO DE PROTESTO";
                case "23": return "REMESSA A CARTORIO/APONTE EM CARTORIO";
                case "24": return "RETIRADA DE CARTORIO E MANUTENÇÃO EM CARTEIRA";
                case "25": return "PROTESTADO E BAIXADO";
                case "26": return "INSTRUÇÃO REJEITADA";
                case "27": return "CONFIRMAÇÃO DO PEDIDO DE ALTERAÇÃO DE OUTROS DADOS";
                case "28": return "DEBITO DE TARIFAS/CUSTAS";
                case "29": return "OCORRENCIAS DO SACADO";
                case "30": return "ALTERAÇÃO DE DADOS REJEITADA";
                default: return string.Empty;
            }
        }
        private string TratarMotivoOcorrencia(string codigo)
        {
            switch (codigo)
            {
                case "03": return "TARIFA DE DESISTÊNCIA";
                case "04": return "TARIFA DE PROTESTO";
                case "08": return "CUSTAS DE PROTESTO";
                case "21": return "TARIFA DE GRAVAÇÃO ELETRÔNICA";
                default: return string.Empty;
            }
        }
        private void GerarRemessaCNAB240(blCobranca cobranca, StringBuilder Remessa)
        {
            if (cobranca.Titulos.Count.Equals(0))
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
            registros.Append(cobranca.Titulos[0].Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "2" : "1");
            //CNPJ Empresa 019-032
            registros.Append(cobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
            //Uso Banco 033-052
            registros.Append("".FormatStringEsquerda(20, ' '));
            //Agencia 053-057
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito Agencia 058-058
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.Trim());
            //Conta Corrente 059-070
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
            //Digito Cedente 071-071
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta.Trim());
            //072-072
            registros.Append("0");
            //Nome Cedente 073-102
            registros.Append(cobranca.Titulos[0].Cedente.Nome.FormatStringDireita(30, ' '));
            //Nome Banco 103-132
            registros.Append(NomeBanco.FormatStringDireita(30, ' '));
            //Brancos 133-142
            registros.Append("".FormatStringDireita(10, ' '));
            //Codigo Remessa 143-143
            registros.Append("1");
            //Data Arquivo 144-151
            registros.Append(cobranca.DataArquivo.ToString("ddMMyyyy"));
            //Hora Arquivo 152-157
            registros.Append(cobranca.DataArquivo.ToString("HHmmss"));
            //Sequencial Arquivo 158-163
            registros.Append(cobranca.SequencialArq.FormatStringEsquerda(6, '0'));
            //Layout Arquivo 164-166
            registros.Append("081");
            //Densidade 167-171
            registros.Append("".FormatStringEsquerda(5, '0'));
            //Brancos 172-191
            registros.Append("".FormatStringDireita(20, ' '));
            //Reservado Empresa 192-211
            registros.Append("".FormatStringDireita(20, ' '));
            //Reservado Caixa 212-240
            registros.Append("".FormatStringDireita(29, ' '));
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
            registros.Append(cobranca.Titulos[0].Tp_cobranca.Trim().ToUpper().Equals("CR") ? "01" : "02");
            //Febraban 012-013
            registros.Append("  ");
            //Layout Lote 014-016
            registros.Append("040");
            //Brancos 017-017
            registros.Append(" ");
            //Tipo Insc. Empresa 018-018
            registros.Append(cobranca.Titulos[0].Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaJuridica) ? "2" : "1");
            //CNPJ Empresa 019-033
            registros.Append(cobranca.Titulos[0].Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(15, '0'));
            //Brancos 034-053
            registros.Append("".FormatStringDireita(20, ' '));
            //Agencia 054-058
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Digito Agencia 059-059
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.Trim());
            //Conta Corrente 060-071
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
            //Digito Conta 072-072
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta);
            //Uso Caixa 073-073
            registros.Append(" ");
            //Nome Empresa 074-103
            registros.Append(cobranca.Titulos[0].Cedente.Nome.ToUpper().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Informaçoes 104-183
            registros.Append("".FormatStringDireita(80, ' '));
            //Numero Arquivo 184-191
            registros.Append(cobranca.SequencialArq.ToString().FormatStringEsquerda(8, '0'));
            //Data Arquivo 192-199
            registros.Append(cobranca.DataArquivo.ToString("ddMMyyyy"));
            //Data Credito 200-207
            registros.Append("00000000");
            //Brancos 208-240
            registros.Append("".FormatStringDireita(33, ' '));

            tot_registros++;
            tot_reglote++;
            Remessa.AppendLine(registros.ToString());
            #endregion

            #region Registro Detalhe
            cobranca.Titulos.ForEach(p =>
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
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Agencia 018-022
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
                //Digito Agencia 023-023
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia.Trim());
                //Conta Corrente 024-035
                registros.Append(p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(12, '0'));
                //Digito Conta 036-036
                registros.Append(p.Cedente.ContaBancaria.DigitoConta);
                //Brancos 037-037
                registros.Append(" ");
                //Nosso Numero 038-047
                registros.Append((p.Nosso_numero + p.Digito_NossoNumero).FormatStringEsquerda(10, '0'));
                //Parcelas 048-049
                registros.Append("01");
                //Modalidade 050-051
                registros.Append(p.Modalidade.Trim());
                //Tipo Formulario 052-052
                registros.Append("4");//A4 sem envelopamento
                //Brancos 053-057
                registros.Append("".FormatStringDireita(5, ' '));
                //Carteira 058-058
                registros.Append("1");//1-Cobrança Simples 2-Cobrança Caucionada 3-Cobrança Descontada
                //Cadastramento 059-059
                registros.Append("0");
                //Tipo Documento 060-060
                registros.Append(" ");
                //Emissão Boleto 061-061
                registros.Append("2");//Cliente Emite
                //Distribuição 062-062
                registros.Append("2");//Beneficiario distribui
                //Numero Documento 063-077
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(15, ' '));
                //Vencimento 078-085
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor Nominal 086-100
                registros.Append(p.Vl_documento.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(15, '0'));
                //Agencia Cobrança 101-105
                registros.Append("".FormatStringEsquerda(5, '0'));
                //Digito Agencia 106-106
                registros.Append(" ");
                //Especie Titulo 107-108
                registros.Append(ConverterEspecieDoc(p.Especie_documento));
                //Aceite 109-109
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "A" : "N");
                //Data Emissao 110-117
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyyyy"));
                //Codigo Juros 118-118
                registros.Append(p.Pc_jurodia.Equals(decimal.Zero) ? "0" : p.Tp_jurodia.Trim().ToUpper().Equals("V") ? "1" : "2");//0-Isento 1-Valor por dia 2-Taxa Mensal
                //Data Juros 119-126
                registros.Append(p.Pc_jurodia > decimal.Zero ? p.Dt_vencimento.Value.ToString("ddMMyyyy") : "00000000");
                //Juros Mora 127-141
                registros.Append(p.Tp_jurodia.Trim().ToUpper().Equals("V") ?
                    Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_jurodia), 100), 2).SoNumero().FormatStringEsquerda(15, '0') :
                    (p.Pc_jurodia * 30).SoNumero().FormatStringEsquerda(15, '0'));
                //Codigo Desconto 142-142
                registros.Append(p.Pc_desconto.Equals(decimal.Zero) ? "0" : p.Tp_desconto.Trim().ToUpper().Equals("V") ? "1" : "2");//0-Sem Desconto 1-Valor 2-Percentual
                //Data Desconto 143-150
                registros.Append(p.Pc_desconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(p.Nr_diasdesconto > decimal.Zero ? Convert.ToDouble(p.Nr_diasdesconto) * -1 : -1).ToString("ddMMyyyy") : "00000000");
                //Valor Desconto 151-165
                registros.Append(p.Pc_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(15, '0'));
                //valor IOF 166-180
                registros.Append("".FormatStringEsquerda(15, '0'));
                //valor abatimento 181-195
                registros.Append("".FormatStringEsquerda(15, '0'));
                //Identificação Titulo 196-220
                registros.Append((p.Nr_lancto.ToString() + p.Id_cobranca.ToString()).Trim().FormatStringDireita(25, ' '));
                //Codigo Protesto 221-221
                registros.Append("1");
                //Prazo Protesto 222-223
                registros.Append(p.Nr_diasprotestar.FormatStringEsquerda(2, '0'));
                //Codigo Baixa 224-224
                registros.Append("0");
                //Prazo Baixa 225-227
                registros.Append("   ");
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
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
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
                registros.Append("000");
                //Nosso Num. Correspondente 213-232
                registros.Append("".FormatStringDireita(20, ' '));
                //Brancos 233-240
                registros.Append("".FormatStringDireita(8, ' '));

                tot_registros++;

                Remessa.AppendLine(registros.ToString());
                #endregion

                #region Segmento R
                if(p.Pc_multa > decimal.Zero)
                {
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
                    registros.Append("R");
                    //Brancos 015-015
                    registros.Append(" ");
                    //Codigo Remessa 016-017
                    registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                    //Codigo desconto 2 018-018
                    registros.Append("0");//Não conceder desconto
                    //Data Desconto 2 019-026
                    registros.Append("00000000");
                    //Valor Desconto 2 027--041
                    registros.Append(string.Empty.FormatStringDireita(15, '0'));
                    //Codigo desconto 3 042-042
                    registros.Append("0");//Não conceder desconto
                    //Data Desconto 3 043-050
                    registros.Append("00000000");
                    //Valor Desconto 3 051--065
                    registros.Append(string.Empty.FormatStringDireita(15, '0'));
                    //Codigo Multa 066-066
                    registros.Append(p.Tp_multa.Trim().ToUpper().Equals("V") ? "1" : "2");
                    //Data Multa 067-074
                    registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                    //Valor Multa 075-089
                    registros.Append(p.Tp_multa.Trim().ToUpper().Equals("V") ?
                    Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_multa), 100), 2).SoNumero().FormatStringEsquerda(15, '0') :
                    p.Pc_multa.SoNumero().FormatStringEsquerda(15, '0'));
                    //Brancos 090-099
                    registros.Append(string.Empty.FormatStringDireita(10, ' '));
                    //Mensagem 100-199
                    registros.Append(string.Empty.FormatStringDireita(100, ' '));
                    //Codigo ocorrencia pagador 200-207
                    registros.Append("00000000");
                    //Codigo banco na conta do debito 208-210
                    registros.Append("000");
                    //Agencia do debito 211-215
                    registros.Append("00000");
                    //Digito agencia debito 216-216
                    registros.Append(" ");
                    //Codigo conta debito 217-228
                    registros.Append("".FormatStringDireita(12, '0'));
                    //Digito conta debito 229-229
                    registros.Append(" ");
                    //Digito agencia/conta debito 230-230
                    registros.Append(" ");
                    //Aviso debito automatico 231-231
                    registros.Append("0");
                    //Brancos 232-240
                    registros.Append("".FormatStringDireita(9, ' '));

                    tot_registros++;

                    Remessa.AppendLine(registros.ToString());
                }
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
            registros.Append(cobranca.Titulos.Count.ToString().FormatStringEsquerda(6, '0'));
            //Vl titulos simples 030-046
            registros.Append(cobranca.Titulos.Sum(p => p.Vl_documento).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).SoNumero().FormatStringEsquerda(17, '0'));
            //Qtd Titulos Vinculado 047-052
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Vl Titulos Vinculado 053-069
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Qtd Titulos Caucionada 070-075
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Vl Titulos Caucionada 076-092
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Qtd Titulos Descontada 093-098
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Vl Titulos Descontada 099-115
            registros.Append("".FormatStringEsquerda(17, '0'));
            //Brancos 116-240
            registros.Append("".FormatStringDireita(125, ' '));

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
            //Qtde contas para conciliação 030-035
            registros.Append("".FormatStringEsquerda(6, '0'));
            //Brancos 036-240
            registros.Append("".FormatStringDireita(205, ' '));

            Remessa.AppendLine(registros.ToString());
            #endregion
        }
        //Com Registro Banco Correspondente
        private void GerarRemessaCorrespondenteCNAB240(blCobranca cobranca, StringBuilder Remessa)
        {
            if (cobranca.Titulos.Count.Equals(0))
                throw new Exception("Não há titulos para gerar remessa.");

            StringBuilder registros = new StringBuilder();

            #region Registro Header
            //Codigo do banco 001-003
            registros.Append(CodigoBanco.Trim());
            //Zeros 004-007
            registros.Append("0".FormatStringEsquerda(4, '0'));
            //Header do lote 008-008
            registros.Append("1");
            //Tipo Operacao 009-009
            registros.Append("R");
            //Zeros 010-016
            registros.Append("0".FormatStringEsquerda(7, '0'));
            //Brancos 017-018
            registros.Append("".FormatStringDireita(2, ' '));
            //Numero da cooperativa/agencia 019-022
            registros.Append(cobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Codigo de cobranca 023-029
            registros.Append(cobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(7, '0'));
            //Numero da conta 030-040
            registros.Append((cobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta + cobranca.Titulos[0].Cedente.ContaBancaria.DigitoConta).FormatStringEsquerda(11, '0'));
            //Brancos 041-070
            registros.Append("".FormatStringDireita(30, ' '));
            //Nome Empresa 071-100
            registros.Append(cobranca.Titulos[0].Nm_cedente.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Brancos 101-180
            registros.Append("".FormatStringDireita(80, ' '));
            //Numero Arquivo 181-188
            registros.Append(cobranca.SequencialArq.ToString().FormatStringEsquerda(8, '0'));
            //Data arquivo 189-196
            registros.Append(cobranca.DataArquivo.ToString("ddMMyyyy"));
            //Zeros 197-207
            registros.Append("0".FormatStringEsquerda(11, '0'));
            //Filler 208-240
            registros.Append("".FormatStringDireita(33, ' '));

            Remessa.AppendLine(registros.ToString());
            int tot_registro = 1;
            #endregion

            #region Detalhes

            int lote = 0;
            cobranca.Titulos.ForEach(p =>
            {
                #region Segmento P
                registros = new StringBuilder();
                lote++;
                //Zeros 001-007
                registros.Append("0".FormatStringEsquerda(7, '0'));
                //Tipo registro 008-008
                registros.Append("3");
                //Numero sequencial lote 009-013
                registros.Append(lote.ToString().FormatStringEsquerda(5, '0'));
                //Codigo segmento 014-014
                registros.Append("P");
                //Brancos 015-015
                registros.Append(" ");
                //Cogido Instrucao 016-017
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Brancos 018-040
                registros.Append("".FormatStringDireita(23, ' '));
                //Nosso numero 041-057
                registros.Append(p.Nosso_numero);
                //Carteira 058-058
                registros.Append(p.Carteira.Trim());
                //Tipo documento 059-060
                registros.Append(p.RetornarCodigoEspecieDocumento().FormatStringEsquerda(2, '0'));
                //Emissao do boleto 061-061
                registros.Append("2");//Cedente emite
                                      //Branco 062-062
                registros.Append(" ");
                //Numero interno do boleto 063-077
                registros.Append((p.Nr_lancto.ToString() + p.Cd_parcela.ToString() + p.Id_cobranca.ToString()).FormatStringEsquerda(15, '0'));
                //Data vencimento 078-085
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor do documento 086-100
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //Zeros 101-106
                registros.Append("0".FormatStringEsquerda(6, '0'));
                //Aceite 107-107
                registros.Append(p.Aceite_documento.Equals(TAceiteDocumento.adSim) ? "A" : "N");
                //Brancos 108-109
                registros.Append("".FormatStringDireita(2, ' '));
                //Data emissao 110-117
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyyyy"));
                //Tipo juro 118-118
                registros.Append(p.Pc_jurodia > decimal.Zero ? p.Tp_jurodia.Trim().Equals("P") ? "3" : "2" : "1");
                //Percentual juro 119-133
                registros.Append(p.Pc_jurodia.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //Zeros 134-142
                registros.Append("0".FormatStringEsquerda(9, '0'));
                //Data limite desconto 143-150
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyyyy") : p.Dt_vencimento.Value.ToString("ddMMyyyy"));
                //Valor desconto 151-165
                registros.Append((p.Tp_desconto.Trim().Equals("P") ? decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100) : p.Pc_desconto).ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //Filler 166-180
                registros.Append("".FormatStringDireita(15, ' '));
                //Valor abatimento 181-195
                registros.Append(string.Empty.FormatStringEsquerda(15, '0'));
                //Controle cedente 196-220
                registros.Append((p.Nosso_numero.Trim() + cobranca.Cd_instrucao.ToString()).FormatStringDireita(25, ' '));
                //Protesto automatico 221-221
                registros.Append(p.St_protestarauto ? "1" : "0");
                //Numero dias protesto 222-223
                registros.Append((p.St_protestarauto ? p.Nr_diasprotestar : 0).ToString().FormatStringEsquerda(2, '0'));
                //Zeros 224-227
                registros.Append("0".FormatStringEsquerda(4, '0'));
                //Moeda 228-229
                registros.Append("09");
                //Contrato desconto titulo 230-239
                registros.Append("0".FormatStringEsquerda(10, '0'));
                //Zero 240-240
                registros.Append("0");

                Remessa.AppendLine(registros.ToString());

                #endregion

                #region Segmento Q
                lote++;
                registros = new StringBuilder();
                //Zeros 001-007
                registros.Append("0".FormatStringEsquerda(7, '0'));
                //Registro 008-008
                registros.Append("3");
                //Numero registro continua numeracao registro P 009-013
                registros.Append(lote.ToString().FormatStringEsquerda(5, '0'));
                //Codigo segmento 014-014
                registros.Append("Q");
                //Brancos 015-015
                registros.Append(" ");
                //Codigo instrucao = igual informado segmento P 016-017
                registros.Append(cobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Tipo inscricao sacado 018-019
                registros.Append(p.Sacado.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "01" : "02");
                //Cnpj/Cpf 020-033
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
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
                //Tipo inscricao avalista 154-155
                registros.Append(string.IsNullOrEmpty(p.Cd_bancocorrespondente) ?
                    p.Avalista.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "01" : "02" :
                    p.Cedente.TipoInscricao.Equals(TTipoInscricao.tiPessoaFisica) ? "01" : "02");
                //Inscricao avalista 156-169
                registros.Append(string.IsNullOrEmpty(p.Cd_bancocorrespondente) ?
                    p.Avalista.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0') :
                    p.Cedente.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome avalista 170-209
                registros.Append(string.IsNullOrEmpty(p.Cd_bancocorrespondente) ?
                    p.Avalista.Nome.RemoverCaracteres().FormatStringDireita(40, ' ') :
                    p.Cedente.Nome.RemoverCaracteres().FormatStringDireita(40, ' '));
                //Filler 210-240
                registros.Append("".FormatStringDireita(31, ' '));

                Remessa.AppendLine(registros.ToString());
                #endregion
            });

            #endregion

            #region Registro Trailer
            registros = new StringBuilder();
            //Zeros 001-007
            registros.Append("0".FormatStringEsquerda(7, '0'));
            //Tipo registro 008-008
            registros.Append("5");
            //Brancos 009-017
            registros.Append("".FormatStringDireita(9, ' '));
            //Quantidade total registros 018-023
            registros.Append((tot_registro + lote + 1).ToString().FormatStringEsquerda(6, '0'));
            //Valor total do boletos 024-040
            registros.Append(cobranca.Titulos.Sum(p => p.Vl_documento).ToString().SoNumero().FormatStringEsquerda(17, '0'));
            //Zeros 041-046
            registros.Append("0".FormatStringEsquerda(6, '0'));
            //Filler 047-240
            registros.Append("".FormatStringDireita(194, ' '));

            Remessa.Append(registros.ToString());
            #endregion
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
            //Identificação por extenso do tipo de operação 003-009
            registros.Append("REMESSA".FormatStringDireita(7, ' '));
            //Identificação tipo serviço 010-011
            registros.Append("01");
            //Literal COBRANCA 012-019
            registros.Append("COBRANÇA");
            //Complemento Registro 020-026
            registros.Append("".FormatStringDireita(7, ' '));
            //Numero Agencia 027-030
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Digito da Agencia 031-031
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.DigitoAgencia.FormatStringDireita(1, ' '));
            //Codigo cedente 032-039
            registros.Append(aCobranca.Titulos[0].Cedente.CodigoCedente.FormatStringEsquerda(8, '0'));
            //Digito cedente 040-040
            registros.Append(aCobranca.Titulos[0].Cedente.DigitoCodigoCedente.FormatStringDireita(1, ' '));
            //Complemento 041-046
            registros.Append("      ");
            //Nome Cedente 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.RemoverCaracteres().FormatStringDireita(30, ' '));
            //Identificacao Banco 077-094
            registros.Append("756BANCOOBCED".FormatStringDireita(18, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Sequencial da Remessa 101-107
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(7, '0'));
            //Complemento 108-394
            registros.Append("".FormatStringDireita(287, ' '));
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
                registros.Append("1");
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
                //Codigo Cedente 032-037
                registros.Append("".FormatStringEsquerda(6, '0'));
                //Brancos 038-062
                registros.Append("".FormatStringDireita(25, ' '));
                //Nosso Numero 063-074
                registros.Append((p.Nosso_numero + p.Digito_nossonumero).FormatStringEsquerda(12, '0'));
                //Numero Parcela 075-076
                registros.Append("01");
                //Grupo valor 077-078
                registros.Append("00");
                //Brancos 079-081
                registros.Append("   ");
                //Indicativo de Mensagem ou Sacador/Avalista 082-082
                registros.Append(" ");
                //Brancos 083-085
                registros.Append("   ");
                //Variação Carteira 086-088
                registros.Append("000");
                //Conta caução 089-089
                registros.Append("0");
                //Contrato Garantia 090-094
                registros.Append("00000");
                //Digito contrato 095-095
                registros.Append("0");
                //Numero bordero 096-101
                registros.Append("000000");
                //Brancos 102-105
                registros.Append("    ");
                //Tipo emissao 106-106
                registros.Append("2");
                //Modalidade 107-108
                registros.Append(p.Modalidade.FormatStringEsquerda(2, '0'));
                //Comando 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Seu Numero 111-120
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(10, ' '));
                //Data Vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor Titulo 127-139
                registros.Append(p.Vl_documento.ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Numero Banco 140-142
                registros.Append(CodigoBanco);
                //Agencia 143-146
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Digito agencia 147-147
                registros.Append(p.Cedente.ContaBancaria.DigitoAgencia);
                //Especie Titulo 148-149
                registros.Append(ConverterEspecieDoc(p.Especie_documento));
                //Aceite 150-150
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "1" : "0");
                //Data emissao 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
            //Instrucao Codificada 157-158
            registros.Append(p.St_protestarauto ?
                                p.Nr_diasprotestar <= 3 ? "03" :
                                p.Nr_diasprotestar <= 4 ? "04" :
                                p.Nr_diasprotestar <= 5 ? "05" :
                                p.Nr_diasprotestar <= 10 ? "10" :
                                p.Nr_diasprotestar <= 15 ? "15" : "20": "00");
                //Instrucao Codificada 159-160
                registros.Append(p.Pc_jurodia > decimal.Zero ? "01" : "00");
                //Juros Mora 161-166
                if (p.Pc_jurodia > decimal.Zero)
                {
                    if (p.Tp_jurodia.Trim().ToUpper().Equals("V"))
                        throw new Exception("Modalidade de cobrança não permite informar juro em VALOR.");
                    registros.Append((p.Pc_jurodia * 30).ToString("N4").SoNumero().FormatStringEsquerda(6, '0'));
                }
                else registros.Append("".FormatStringEsquerda(6, '0'));
                //Valor Desconto 167-172
                if (p.Pc_multa > decimal.Zero)
                {
                    if (p.Tp_multa.Trim().ToUpper().Equals("V"))
                        throw new Exception("Modalidade de cobrança não permite informar multa em VALOR.");
                    registros.Append(p.Pc_multa.ToString("N4").SoNumero().FormatStringEsquerda(6, '0'));
                }
                else
                    registros.Append("".FormatStringEsquerda(6, '0'));
                //Tipo Distribuicao 173-173
                registros.Append("2");
                //Data desconto 174-179
                registros.Append(p.Nr_diasdesconto > decimal.Zero ?
                                    p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto * -1)).ToString("ddMMyy") : "000000");
                //Valor desconto 180-192
                registros.Append(Math.Round(decimal.Divide(decimal.Multiply(p.Vl_documento, p.Pc_desconto), 100), 2, MidpointRounding.AwayFromZero).ToString().SoNumero().FormatStringEsquerda(13, '0'));
                //Codigo Moeda 193-193
                registros.Append("9");
                //Valor IOF 194-205
                registros.Append("".FormatStringEsquerda(12, '0'));
                //Valor Abatimento 206-218
                registros.Append(string.Empty.FormatStringEsquerda(13, '0'));
                //Tipo Inscricao Sacado 219-220
                registros.Append(p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //CPF/CNPJ Sacado 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome Sacado 235-274
                registros.Append(p.Sacado.Nome.RemoverCaracteres().FormatStringDireita(40, ' '));
                //Endereco Sacado 275-311
                registros.Append((p.Sacado.Endereco.Rua.Trim() + ", " + p.Sacado.Endereco.Numero.Trim()).RemoverCaracteres().FormatStringDireita(37, ' '));
                //Bairro Sacado 312-326
                registros.Append(p.Sacado.Endereco.Bairro.RemoverCaracteres().FormatStringDireita(15, ' '));
                //CEP Sacado 327-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                //Cidade Sacado 335-349
                registros.Append(p.Sacado.Endereco.Cidade.RemoverCaracteres().FormatStringDireita(15, ' '));
                //UF Sacado 350-351
                registros.Append(p.Sacado.Endereco.Estado.RemoverCaracteres().FormatStringDireita(2, ' '));
                //Mensagem ou Sacador Avalista 352-391
                registros.Append("".FormatStringDireita(40, ' '));
                //Dias Protesto 392-393
                registros.Append("00");
                //Complemento 394-394
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
            //Complemento 002-394
            registros.Append(string.Empty.FormatStringDireita(393, ' '));
            //Sequencial registro 395-400
            registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));

            Remessa.AppendLine(registros.ToString());
            #endregion
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
                        ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(39, 7);
                        //Data de vencimento
                        if (Retorno[NumeroRegistro].Substring(73, 8) != "00000000")
                            ATitulo.Dt_vencimento = DateTime.Parse(Retorno[NumeroRegistro].Substring(73, 2) + "/" +
                                                                    Retorno[NumeroRegistro].Substring(75, 2) + "/" +
                                                                    Retorno[NumeroRegistro].Substring(77, 4));
                        else
                            ATitulo.Dt_vencimento = DateTime.Now;
                        //Valor do titulo
                        if (Retorno[NumeroRegistro].Substring(81, 15) != "000000000000000")
                            ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(81, 15)) / 100;
                        else
                            ATitulo.Vl_documento = decimal.Zero;
                        //Valor das despesas
                        if (Retorno[NumeroRegistro].Substring(198, 15) != "000000000000000")
                            ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(198, 15)) / 100;
                        else
                            ATitulo.Vl_despesa_cobranca = decimal.Zero;
                        //Motivo ocorrencia
                        ATitulo.Ds_motivoocorrencia = TratarMotivoOcorrencia(Retorno[NumeroRegistro].Substring(213, 10));
                        if (Retorno[NumeroRegistro + 1].Substring(7, 1).Equals("3") &&
                            Retorno[NumeroRegistro + 1].Substring(13, 1).Equals("U"))
                        {
                            NumeroRegistro++;
                            //Juros
                            if (Retorno[NumeroRegistro].Substring(17, 15) != "000000000000000")
                                ATitulo.Vl_morajuros = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(17, 15)) / 100;
                            else
                                ATitulo.Vl_morajuros = decimal.Zero;
                            //Desconto
                            if (Retorno[NumeroRegistro].Substring(32, 15) != "000000000000000")
                                ATitulo.Vl_desconto = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(32, 15)) / 100;
                            else
                                ATitulo.Vl_desconto = decimal.Zero;
                            //Abatimento
                            if (Retorno[NumeroRegistro].Substring(47, 15) != "000000000000000")
                                ATitulo.Vl_abatimento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(47, 15)) / 100;
                            else
                                ATitulo.Vl_abatimento = decimal.Zero;
                            //Outras despesas
                            if (Retorno[NumeroRegistro].Substring(107, 15) != "000000000000000")
                                ATitulo.Vl_outras_despesas = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(107, 15)) / 100;
                            else
                                ATitulo.Vl_outras_despesas = decimal.Zero;
                            //Outros creditos
                            if (Retorno[NumeroRegistro].Substring(122, 15) != "000000000000000")
                                ATitulo.vl_outros_creditos = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(122, 15)) / 100;
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
        private bool LerRetornoCorrespondenteCNAB240(blCobranca ACobranca, string[] Retorno)
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
                ACodigoCedente = Retorno[NumeroRegistro].Substring(22, 7);
                //Data do arquivo
                if (Retorno[NumeroRegistro].Substring(188, 8) != "00000000")
                    ACobranca.DataArquivo = DateTime.Parse(Retorno[NumeroRegistro].Substring(188, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(190, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(192, 4));
                else
                    ACobranca.DataArquivo = DateTime.Now;
                //Numero arquivo
                ACobranca.SequencialArq = decimal.Parse(Retorno[NumeroRegistro].Substring(180, 8));
                #endregion

                for (NumeroRegistro = 1; NumeroRegistro <= (Retorno.Length - 2); NumeroRegistro++)
                {
                    ATitulo = new blTitulo();
                    //Tipo registro é 3
                    if (Retorno[NumeroRegistro].Substring(7, 1) != "3")
                        continue;//Nao processa se registro diferente de 3
                    ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                    //Codigo do cedente
                    ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                    //Ocorrencia
                    ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(15, 2);
                    //Descricao ocorrencia
                    ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia);
                    //Nosso numero
                    ATitulo.Nosso_numero = decimal.Parse(Retorno[NumeroRegistro].Substring(37, 20)).ToString();
                    //Data de vencimento
                    if (Retorno[NumeroRegistro].Substring(74, 8) != "00000000")
                        ATitulo.Dt_vencimento = DateTime.Parse(Retorno[NumeroRegistro].Substring(74, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(76, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(78, 4));
                    else
                        ATitulo.Dt_vencimento = DateTime.Now;
                    //Valor do titulo
                    if (Retorno[NumeroRegistro].Substring(82, 15) != "000000000000000")
                        ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(82, 15)) / 100;
                    else
                        ATitulo.Vl_documento = decimal.Zero;
                    //Valor das despesas
                    if (Retorno[NumeroRegistro].Substring(199, 15) != "000000000000000")
                        ATitulo.Vl_despesa_cobranca = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(199, 15)) / 100;
                    else
                        ATitulo.Vl_despesa_cobranca = decimal.Zero;
                    //Motivo ocorrencia
                    string codigo = Retorno[NumeroRegistro].Substring(214, 10);
                    if (codigo.Substring(0, 2) != "00")
                        ATitulo.Ds_motivoocorrencia += TratarMotivoOcorrencia(codigo.Substring(0, 2)) + "|";
                    if (codigo.Substring(2, 2) != "00")
                        ATitulo.Ds_motivoocorrencia += TratarMotivoOcorrencia(codigo.Substring(2, 2)) + "|";
                    if (codigo.Substring(4, 2) != "00")
                        ATitulo.Ds_motivoocorrencia += TratarMotivoOcorrencia(codigo.Substring(4, 2)) + "|";
                    if (codigo.Substring(6, 2) != "00")
                        ATitulo.Ds_motivoocorrencia += TratarMotivoOcorrencia(codigo.Substring(6, 2)) + "|";
                    if (codigo.Substring(8, 2) != "00")
                        ATitulo.Ds_motivoocorrencia += TratarMotivoOcorrencia(codigo.Substring(8, 2));
                    if (!string.IsNullOrEmpty(ATitulo.Ds_motivoocorrencia))
                        if (ATitulo.Ds_motivoocorrencia.Substring(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1).Equals("|"))
                            ATitulo.Ds_motivoocorrencia = ATitulo.Ds_motivoocorrencia.Remove(ATitulo.Ds_motivoocorrencia.Trim().Length - 1, 1);
                    if (Retorno[NumeroRegistro + 1].Substring(7, 1).Equals("3") &&
                        Retorno[NumeroRegistro + 1].Substring(13, 1).Equals("U"))
                    {
                        NumeroRegistro++;
                        //Juros
                        if (Retorno[NumeroRegistro].Substring(17, 15) != "000000000000000")
                            ATitulo.Vl_morajuros = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(17, 15)) / 100;
                        else
                            ATitulo.Vl_morajuros = decimal.Zero;
                        //Desconto
                        if (Retorno[NumeroRegistro].Substring(32, 15) != "000000000000000")
                            ATitulo.Vl_desconto = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(32, 15)) / 100;
                        else
                            ATitulo.Vl_desconto = decimal.Zero;
                        //Abatimento
                        if (Retorno[NumeroRegistro].Substring(47, 15) != "000000000000000")
                            ATitulo.Vl_abatimento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(47, 15)) / 100;
                        else
                            ATitulo.Vl_abatimento = decimal.Zero;
                        //Valor documento
                        if (Retorno[NumeroRegistro].Substring(62, 15) != "000000000000000")
                            ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(62, 15)) / 100;
                        else
                            ATitulo.Vl_documento = decimal.Zero;
                        //Outras despesas
                        if (Retorno[NumeroRegistro].Substring(107, 15) != "000000000000000")
                            ATitulo.Vl_outras_despesas = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(107, 15)) / 100;
                        else
                            ATitulo.Vl_outras_despesas = decimal.Zero;
                        //Outros creditos
                        if (Retorno[NumeroRegistro].Substring(122, 15) != "000000000000000")
                            ATitulo.vl_outros_creditos = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(122, 15)) / 100;
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
                return true;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
        private bool LerRetornoCNAB400(blCobranca ACobranca, string[] Retorno)
        {
            string ACodigoBanco = string.Empty;
            string ACodigoCedente = string.Empty;
            int NumeroRegistro = 0;
            blTitulo ATitulo = null;
            try
            {
                #region HEADER
                ACodigoBanco = Retorno[NumeroRegistro].Substring(76, 3);
                ACodigoCedente = decimal.Parse(Retorno[NumeroRegistro].Substring(31, 8)).ToString();
                if (ACodigoBanco != CodigoBanco)
                    throw new Exception("Este não é um retorno de cobrança do banco " + CodigoBanco + " " + NomeBanco);

                if (Retorno[NumeroRegistro].Substring(94, 6).PadLeft(6, '0') != "000000")
                    ACobranca.DataArquivo = DateTime.Parse(Retorno[NumeroRegistro].Substring(94, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(96, 2) + "/" +
                                                           Retorno[NumeroRegistro].Substring(98, 2));
                else
                    ACobranca.DataArquivo = DateTime.Now;

                if (Retorno[NumeroRegistro].Substring(100, 7).PadLeft(7, '0') != "000000")
                    ACobranca.SequencialArq = Convert.ToInt32(Retorno[NumeroRegistro].Substring(100, 7));
                else
                    ACobranca.SequencialArq = 0;
                #endregion
                //{Lê os registros DETALHE}
                //{Processa até o penúltimo registro porque o último contém apenas o TRAILLER}
                for (NumeroRegistro = 1; NumeroRegistro <= (Retorno.Length - 2); NumeroRegistro++)
                {
                    ATitulo = new blTitulo();
                    //{Confirmar se o tipo do registro é 1}
                    if (Retorno[NumeroRegistro].Substring(0, 1) != "1")
                        continue; //{Não processa o registro atual}

                    //Ocorrencia
                    ATitulo.Cd_ocorrencia = Retorno[NumeroRegistro].Substring(108, 2);
                    //Descricao ocorrencia
                    ATitulo.Ds_ocorrencia = TratarOcorrencia(ATitulo.Cd_ocorrencia);
                    ATitulo.Cedente.ContaBancaria.Banco.Codigo = ACodigoBanco;
                    //Codigo do cedente
                    ATitulo.Cedente.CodigoCedente = ACodigoCedente;
                    //Data ocorrencia
                    if (Retorno[NumeroRegistro].Substring(110, 6).PadLeft(6, '0') != "000000")
                        ATitulo.Dt_ocorrencia = DateTime.Parse(Retorno[NumeroRegistro].Substring(110, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(112, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(114, 2));
                    else
                        ATitulo.Dt_ocorrencia = DateTime.Now;
                    //Data vencimento
                    if (Retorno[NumeroRegistro].Substring(146, 6).PadLeft(6, '0') != "000000")
                        ATitulo.Dt_vencimento = DateTime.Parse(Retorno[NumeroRegistro].Substring(146, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(148, 2) + "/" +
                                                               Retorno[NumeroRegistro].Substring(150, 2));
                    else
                        ATitulo.Dt_vencimento = DateTime.Now;
                    //Valor documento
                    if (Retorno[NumeroRegistro].Substring(253, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_documento = Convert.ToDecimal(Retorno[NumeroRegistro].Substring(253, 13)) / 100;
                    else
                        ATitulo.Vl_documento = decimal.Zero;
                    //Outras despesas
                    if (Retorno[NumeroRegistro].Substring(188, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_outras_despesas = decimal.Divide(Convert.ToDecimal(Retorno[NumeroRegistro].Substring(188, 13)), 100);
                    else ATitulo.Vl_outras_despesas = decimal.Zero;
                    //Valor abatimento
                    if (Retorno[NumeroRegistro].Substring(227, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_abatimento = decimal.Divide(decimal.Parse(Retorno[NumeroRegistro].Substring(227, 13)), 100);
                    else ATitulo.Vl_abatimento = decimal.Zero;
                    //Desconto concedido
                    if (Retorno[NumeroRegistro].Substring(240, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_desconto = decimal.Divide(decimal.Parse(Retorno[NumeroRegistro].Substring(240, 13)), 100);
                    else ATitulo.Vl_desconto = decimal.Zero;
                    //Juros recebidos
                    if (Retorno[NumeroRegistro].Substring(266, 13).PadLeft(13, '0') != "0000000000000")
                        ATitulo.Vl_morajuros = decimal.Divide(decimal.Parse(Retorno[NumeroRegistro].Substring(266, 13)), 100);
                    else ATitulo.Vl_morajuros = decimal.Zero;
                    ATitulo.Vl_documento = ATitulo.Vl_documento - ATitulo.Vl_outras_despesas - ATitulo.Vl_morajuros;
                    ATitulo.Nosso_numero = Retorno[NumeroRegistro].Substring(66, 7);

                    if (Retorno[NumeroRegistro].Substring(175, 6).PadLeft(6, '0') != "000000")
                        ATitulo.Dt_credito = DateTime.Parse(Retorno[NumeroRegistro].Substring(175, 2) + "/" +
                                                            Retorno[NumeroRegistro].Substring(177, 2) + "/" +
                                                            Retorno[NumeroRegistro].Substring(179, 2));
                    else
                        ATitulo.Dt_credito = DateTime.Now;
                    //{Insere o título}
                    ACobranca.Titulos.Add(ATitulo);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GerarRemessa(blCobranca cobranca, string Path_remessa)
        {
            StringBuilder remessa = new StringBuilder();
            switch (cobranca.LayoutArquivo)
            {
                case TLayoutArquivo.laCNAB240:
                    {
                        if (string.IsNullOrWhiteSpace(cobranca.Cd_bancocorrespondente))
                            GerarRemessaCNAB240(cobranca, remessa);
                        else GerarRemessaCorrespondenteCNAB240(cobranca, remessa);
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
        public bool LerRetorno(blCobranca ACobranca, string[] arq)  //{Lê o arquivo retorno recebido do banco}
        {
            try
            {
                if (arq.Length <= 0)
                    throw new Exception("O retorno está vazio. Não há dados para processar");

                switch (ACobranca.LayoutArquivo)
                {
                    case TLayoutArquivo.laCNAB240:
                        {
                            if (string.IsNullOrWhiteSpace(ACobranca.Cd_bancocorrespondente))
                                return LerRetornoCNAB240(ACobranca, arq);
                            else return LerRetornoCorrespondenteCNAB240(ACobranca, arq);
                        }
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
