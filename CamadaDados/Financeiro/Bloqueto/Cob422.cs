using System;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco422
    {
        const string CodigoBanco = "422";
        const string NomeBanco = "BANCO SAFRA";
        public string GetNomeBanco()
        {
            return NomeBanco;
        }
        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantialIndicacao: return "01";
                case TEspecieDocumento.edDuplicataMercantil: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edNotaSeguro: return "03";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edDuplicataServico: return "09";
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
                case "04": return "TRANSFERÊNCIA DE CARTEIRA (ENTRADA)";
                case "05": return "TRANSFERÊNCIA DE CARTEIRA (BAIXA)";
                case "06": return "LIQUIDAÇÃO NORMAL";
                case "09": return "BAIXADO AUTOMATICAMENTE";
                case "10": return "BAIXADO CONFORME INSTRUÇÕES";
                case "11": return "TÍTULOS EM SER (PARA ARQUIVO MENSAL)";
                case "12": return "ABATIMENTO CONCEDIDO";
                case "13": return "ABATIMENTO CANCELADO";
                case "14": return "VENCIMENTO ALTERADO";
                case "15": return "LIQUIDAÇÃO EM CARTÓRIO";
                case "19": return "CONFIRMAÇÃO DE INSTRUÇÃO DE PROTESTO";
                case "20": return "CONFIRMAÇÃO DE SUSTAR PROTESTO";
                case "21": return "TRANSFERÊNCIA DE BENEFICIÁRIO";
                case "23": return "TÍTULO ENVIADO A CARTÓRIO";
                case "40": return "BAIXA DE TÍTULO PROTESTADO";
                case "41": return "LIQUIDAÇÃO DE TÍTULO BAIXADO";
                case "42": return "TÍTULO RETIRADO DO CARTÓRIO";
                case "43": return "DESPESA DE CARTÓRIO";
                case "44": return "ACEITE DO TÍTULO DDA PELO PAGADOR";
                case "45": return "NÃO ACEITE DO TÍTULO DDA PELO PAGADOR";
                case "51": return "VALOR DO TÍTULO ALTERADO";
                case "52": return "ACERTO DE DATA DE EMISSAO";
                case "53": return "ACERTO DE COD ESPECIE DOCTO";
                case "54": return "ALTERACAO DE SEU NUMERO";
                case "56": return "INSTRUÇÃO NEGATIVAÇÃO ACEITA";
                case "57": return "INSTRUÇÃO BAIXA DE NEGATIVAÇÃO ACEITA";
                case "58": return "INSTRUÇÃO NÃO NEGATIVAR ACEITA";
                default: return string.Empty;
            }
        }

        public string TratarMotivo(string ocorrencia, string codigo)
        {
            switch (codigo)
            {
                case "001": return "MOEDA INVÁLIDA";
                case "002": return "MOEDA INVÁLIDA PARA CARTEIRA";
                case "007": return "CEP NÃO CORRESPONDE UF";
                case "008": return "VALOR JUROS AO DIA MAIOR QUE 5 % DO VALOR DO TÍTULO";
                case "009": return "USO EXCLUSIVO NÃO NUMÉRICO PARA COBRANCA EXPRESS";
                case "010": return "IMPOSSIBILIDADE DE REGISTRO -CONTATE O SEU GERENTE";
                case "011": return "NOSSO NÚMERO FORA DA FAIXA";
                case "012": return "CEP DE CIDADE INEXISTENTE";
                case "013": return "CEP FORA DE FAIXA DA CIDADE";
                case "014": return "UF INVÁLIDO PARA CEP DA CIDADE";
                case "015": return "CEP ZERADO";
                case "016": return "CEP NÃO CONSTA NA TABELA SAFRA";
                case "017": return "CEP NÃO CONSTA TABELA BANCO CORRESPONDENTE";
                case "019": return "PROTESTO IMPRATICÁVEL";
                case "020": return "PRIMEIRA INSTRUÇÃO DE COBRANÇA INVALIDA";
                case "021": return "SEGUNDA INSTRUÇÃO DE COBRANÇA INVÁLIDA";
                case "023": return "TERCEIRA INSTRUÇÃO DE COBRANÇA INVÁLIDA";
                case "026": return "CÓDIGO DE OPERAÇÃO/ OCORRÊNCIA INVÁLIDO";
                case "027": return "OPERAÇÃO INVÁLIDA PARA O CLIENTE";
                case "028": return "NOSSO NÚMERO NÃO NUMÉRICO OU ZERADO";
                case "029": return "NOSSO NÚMERO COM DÍGITO DE CONTROLE ERRADO/ INCONSISTENTE";
                case "030": return "VALOR DO ABATIMENTO NÃO NUMÉRICO OU ZERADO";
                case "031": return "SEU NÚMERO EM BRANCO";
                case "032": return "CÓDIGO DA CARTEIRA INVÁLIDO";
                case "036": return "DATA DE EMISSÃO INVÁLIDA";
                case "037": return "DATA DE VENCIMENTO INVÁLIDA";
                case "038": return "DEPOSITÁRIA INVÁLIDA";
                case "039": return "DEPOSITÁRIA INVÁLIDA PARA O CLIENTE";
                case "040": return "DEPOSITÁRIA NÃO CADASTRADA NO BANCO";
                case "041": return "CÓDIGO DE ACEITE INVÁLIDO";
                case "042": return "ESPÉCIE DE TÍTULO INVÁLIDO";
                case "043": return "INSTRUÇÃO DE COBRANÇA INVÁLIDA";
                case "044": return "VALOR DO TÍTULO NÃO NUMÉRICO OU ZERADO";
                case "046": return "VALOR DE JUROS NÃO NUMÉRICO OU ZERADO";
                case "047": return "DATA LIMITE PARA DESCONTO INVÁLIDA";
                case "048": return "VALOR DO DESCONTO INVÁLIDO";
                case "049": return "VALOR IOF.NÃO NUMÉRICO OU ZERADO (SEGUROS)";
                case "051": return "CÓDIGO DE INSCRIÇÃO DO SACADO INVÁLIDO";
                case "053": return "NÚMERO DE INSCRIÇÃO DO SACADO NÃO NÚMERICO OU DÍGITO ERRADO";
                case "054": return "NOME DO SACADO EM BRANCO";
                case "055": return "ENDEREÇO DO SACADO EM BRANCO";
                case "056": return "CLIENTE NÃO CADASTRADO";
                case "058": return "PROCESSO DE CARTÓRIO INVÁLIDO";
                case "059": return "ESTADO DO SACADO INVÁLIDO";
                case "060": return "CEP / ENDEREÇO DIVERGEM DO CORREIO";
                case "061": return "INSTRUÇÃO AGENDADA PARA AGÊNCIA";
                case "062": return "OPERAÇÃO INVÁLIDA PARA A CARTEIRA";
                case "064": return "TÍTULO INEXISTENTE(TFC)";
                case "065": return "OPERAÇÃO / TITULO JÁ EXISTENTE";
                case "066": return "TÍTULO JÁ EXISTE(TFC)";
                case "067": return "DATA DE VENCIMENTO INVÁLIDA PARA PROTESTO";
                case "068": return "CEP DO SACADO NÃO CONSTA NA TABELA";
                case "069": return "PRAÇA NÃO ATENDIDA PELO SERVIÇO CARTÓRIO";
                case "070": return "AGÊNCIA INVÁLIDA";
                case "072": return "TÍTULO JÁ EXISTE(COB)";
                case "074": return "TÍTULO FORA DE SEQÜÊNCIA";
                case "078": return "TÍTULO INEXISTENTE(COB)";
                case "079": return "OPERAÇÃO NÃO CONCLUÍDA";
                case "080": return "TÍTULO JÁ BAIXADO";
                case "083": return "PRORROGAÇÃO / ALTERAÇÃO DE VENCIMENTO INVÁLIDA";
                case "085": return "OPERAÇÃO INVÁLIDA PARA A CARTEIRA";
                case "086": return "ABATIMENTO MAIOR QUE VALOR DO TÍTULO";
                case "088": return "TÍTULO RECUSADO COMO GARANTIA(SACADO / NOVO / EXCLUSIVO / ALÇADA COMITÊ)";
                case "089": return "ALTERAÇÃO DE DATA DE PROTESTO INVÁLIDA";
                case "094": return "ENTRADA TÍTULO COBRANÇA DIRETA INVÁLIDA";
                case "095": return "BAIXA TÍTULO COBRANÇA DIRETA INVÁLIDA";
                case "096": return "VALOR DO TÍTULO INVÁLIDO";
                case "098": return "PCB DO TFC DIVERGEM DA PCB DO COB";
                case "100": return "INSTRUÇÃO NÃO PERMITIDA - TÍT COM PROTESTO(SE TÍTULO PROTESTADO NÃO PODE NEGATIVAR)";
                case "101": return "INSTRUÇÃO INCOMPATÍVEL - NÃO EXISTE INSTRUÇÃO DE NEGATIVAR PARA O TÍTULO";
                case "102": return "INSTRUÇÃO NÃO PERMITIDA - PRAZO INVÁLIDO PARA NEGATIVAÇÃO(MÍNIMO 2 DIAS CORRIDOS APÓS O VENCIMENTO)";
                case "103": return "INSTRUÇÃO NÃO PERMITIDA - TÍT INEXISTENTE";
                default: return string.Empty;
            }
        }
        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            return "7" +
                   ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim() +
                   ATitulo.Cedente.ContaBancaria.NumeroConta.Trim().FormatStringEsquerda(9, '0') +
                   ATitulo.Nosso_numero.Trim() +
                   ATitulo.Digito_NossoNumero +
                   "2";
        }

        public string CalcularNossoNumero(decimal vNossoNumero)
        {
            return (vNossoNumero + 1).ToString().PadLeft(8, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Estruturas.Mod10(ATitulo.Nosso_numero.Trim()).ToString().Trim();
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
            //Agencia 027-031
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0'));
            //Conta 032-040
            registros.Append(aCobranca.Titulos[tot_registros].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(9, '0'));
            //Brancos 041-046
            registros.Append(string.Empty.FormatStringDireita(6, ' '));
            //Nome empresa 047-076
            registros.Append(aCobranca.Titulos[tot_registros].Nm_cedente.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
            //Codigo banco 077-079
            registros.Append(CodigoBanco);
            //Nome banco 080-094
            registros.Append(NomeBanco.Trim().FormatStringDireita(15, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Brancos 101-391
            registros.Append("".FormatStringDireita(291, ' '));
            //Numero do arquivo 392-394
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(3, '0'));
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
                    registros.Append(Estruturas.Mod10(p.Cedente.ContaBancaria.CodigoAgencia.Trim() + p.Cedente.ContaBancaria.NumeroConta.Trim()));
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
                    //Agencia/conta 018-031
                    registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(5, '0') +
                                     p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(9, '0'));

                    //Brancos 032-062
                    registros.Append("".FormatStringDireita(31, ' '));
                    //Nosso numero 063-071
                    registros.Append(p.Nosso_numero.FormatStringEsquerda(8, '0') + p.Digito_nossonumero);
                    //Brancos 072-101
                    registros.Append("".FormatStringDireita(30, ' '));
                    //Codigo IOF 102-102
                    registros.Append("0");//Isento
                    //Identificação Moeda 103-104
                    registros.Append("00");//Real
                    //Branco 105-105
                    registros.Append(" ");
                    //Zeros 106-107
                    registros.Append("00");
                    //Tipo cobrança 108-108
                    registros.Append(p.Carteira);//1-Cobrança Simples 2-Cobrança Vinculada
                    //Identificação Ocorrencia 109-110
                    registros.Append("01");//Remessa Titulo
                    //Identificação Titulo Empresa 111-120
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
                    //Bairro 315-324
                    registros.Append(p.Sacado.Endereco.Bairro.Trim().RemoverCaracteres().FormatStringDireita(10, ' '));
                    //Brancos 325-326
                    registros.Append("  ");
                    //CEP 327-334
                    registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                    //Cidade 335-349
                    registros.Append(p.Sacado.Endereco.Cidade.Trim().RemoverCaracteres().FormatStringDireita(15, ' '));
                    //Estado 350-351
                    registros.Append(p.Sacado.Endereco.Estado.Trim());
                    //Sacador avalista 352-381
                    registros.Append(p.Avalista.Nome.Trim().RemoverCaracteres().FormatStringDireita(30, ' '));
                    //Brancos 382-388
                    registros.Append("".FormatStringDireita(7, ' '));
                    //Banco 389-391
                    registros.Append(CodigoBanco);
                    //Sequencial do arquivo 392-394
                    registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(3, '0'));
                    //Numero registro 395-400
                    registros.Append((++tot_registros).ToString().FormatStringEsquerda(6, '0'));
                }

                Remessa.AppendLine(registros.ToString());

                #endregion
            });

            #region Trailer
            registros = new StringBuilder();
            //Tipo registro 001-001
            registros.Append("9");
            //Brancos 002-368
            registros.Append("".FormatStringDireita(367, ' '));
            //Quantidade Boletos 369-376
            registros.Append(aCobranca.Titulos.Count().FormatStringEsquerda(8, '0'));
            //Valor Boletos 377-391
            registros.Append(aCobranca.Titulos.Sum(x => x.Vl_documento).SoNumero().FormatStringEsquerda(15, '0'));
            //Sequencial do arquivo 392-394
            registros.Append(aCobranca.SequencialArq.FormatStringEsquerda(3, '0'));
            //Numero registro 395-400
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
                case TLayoutArquivo.laCNAB240:{ throw new Exception("Layout CNAB240 não suportado pelo Aliance.NET"); }
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
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path_remessa + "C" + DateTime.Now.ToString("ddMMyy") + ".TXT"))
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
                        throw new Exception("Layout CNAB240 não suportado pelo Aliance.NET");
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
