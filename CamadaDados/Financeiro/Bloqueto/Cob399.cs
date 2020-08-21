using System;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    public class blBanco399
    {
        const string CodigoBanco = "399";
        const string NomeBanco = "HSBC";

        public string CalcularNossoNumero(decimal vNossoNumero, string CodigoCedente)
        {
            return CodigoCedente.Trim() + (vNossoNumero + 1).FormatStringEsquerda(5, '0');
        }

        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return Utils.Estruturas.Mod11(Utils.Estruturas.StrTam(ATitulo.Nosso_numero.Trim(), "0", false, 15), 7, false, 0).ToString();
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

        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            return ATitulo.Nosso_numero.Trim() +
                   ATitulo.Digito_NossoNumero +
                   ATitulo.Cedente.ContaBancaria.CodigoAgencia.Trim().PadLeft(4, '0') + //codigo da agencia
                   ATitulo.Cedente.ContaBancaria.NumeroConta.Trim().PadLeft(7, '0') + //numero da conta
                   ATitulo.Modalidade.FormatStringEsquerda(2, '0') +
                   '1';//Codigo do aplicativo de cobranca
        }

        private string ConverterEspecieDoc(TEspecieDocumento especie)
        {
            switch (especie)
            {
                case TEspecieDocumento.edDuplicataMercantil: return "01";
                case TEspecieDocumento.edNotaPromissoria: return "02";
                case TEspecieDocumento.edNotaSeguro: return "03";
                case TEspecieDocumento.edRecibo: return "05";
                case TEspecieDocumento.edDuplicataServico: return "10";
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
            //Tipo do arquivo 002-002
            registros.Append("1");
            //Identificação por extenso do tipo de operação 003-009
            registros.Append("REMESSA".FormatStringDireita(7, ' '));
            //Identificação tipo serviço 010-011
            registros.Append("01");
            //Literal COBRANCA 012-026
            registros.Append("COBRANCA".FormatStringDireita(15, ' '));
            //Complemento Registro 027-027
            registros.Append("0");
            //Numero Agencia 028-031
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
            //Sub-conta do cliente 032-033
            registros.Append("55");
            //Numero Conta 034-044
            registros.Append(aCobranca.Titulos[0].Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(11, '0'));
            //Uso Banco 045-046
            registros.Append("  ");
            //Nome Cedente 047-076
            registros.Append(aCobranca.Titulos[0].Cedente.Nome.FormatStringDireita(30, ' '));
            //Numero Banco 077-079
            registros.Append(CodigoBanco);
            //Nome Banco 080-094
            registros.Append(NomeBanco.ToUpper().FormatStringDireita(15, ' '));
            //Data arquivo 095-100
            registros.Append(aCobranca.DataArquivo.ToString("ddMMyy"));
            //Densidade Gravacao 101-105
            registros.Append("01600");
            //Unidade Densidade 106-108
            registros.Append("BPI");
            //Uso do banco 109-110
            registros.Append("  ");
            //Sigla Layout Tecnico 111-117
            registros.Append("LANCV08");
            //Uso Banco 118-394
            registros.Append("".FormatStringDireita(277, ' '));
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
                //Zero 018-018
                registros.Append("0");
                //Codigo Agencia 019-022
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0'));
                //Sub-conta 023-024
                registros.Append("55");
                //Numero Conta 025-035
                registros.Append(p.Cedente.ContaBancaria.CodigoAgencia.FormatStringEsquerda(4, '0') +
                                 p.Cedente.ContaBancaria.NumeroConta.FormatStringEsquerda(5, '0') +
                                 p.Cedente.ContaBancaria.DigitoConta.FormatStringEsquerda(2, '0'));
                //Brancos 036-037
                registros.Append("  ");
                //Controle Empresa 038-062
                registros.Append((p.Nr_lancto.ToString() + "/" + p.Cd_parcela.ToString()).FormatStringDireita(25, ' '));
                //Nosso Numero 063-073
                registros.Append(p.Nosso_numero.FormatStringEsquerda(11, '0'));
                //Data Desconto 074-079
                registros.Append("000000");
                //Valor desconto 080-090
                registros.Append("".FormatStringEsquerda(11, '0'));
                //Data Desconto 091-096
                registros.Append("000000");
                //Valor desconto 097-107
                registros.Append("".FormatStringEsquerda(11, '0'));
                //Carteira 108-108
                registros.Append(p.Carteira.Trim());
                //Codigo Ocorrencia 109-110
                registros.Append(aCobranca.Cd_instrucao.FormatStringEsquerda(2, '0'));
                //Seu numero 111-120
                registros.Append((p.Nr_lancto.Value.ToString() + p.Cd_parcela.Value.ToString()).FormatStringEsquerda(10, '0'));
                //Data vencimento 121-126
                registros.Append(p.Dt_vencimento.Value.ToString("ddMMyy"));
                //Valor titulo 127-139
                registros.Append(p.Vl_documento.SoNumero().FormatStringEsquerda(13, '0'));
                //Numero do banco 140-142
                registros.Append(p.Cd_banco.Trim());
                //Agencia depositaria 143-147
                registros.Append("00000");
                //Especie do titulo 148-149
                registros.Append(this.ConverterEspecieDoc(p.Especie_documento));
                //Aceite 150-150
                registros.Append(p.Aceite_documento == TAceiteDocumento.adSim ? "A" : "N");
                //Data emissao 151-156
                registros.Append(p.Dt_emissaobloqueto.Value.ToString("ddMMyy"));
                //Instrucao 157-158
                registros.Append("00");
                //Instrucao 159-160
                registros.Append("00");
                //Juros de mora 161-173
                if (p.Pc_jurodia > decimal.Zero)
                    registros.Append("        T" + p.Pc_jurodia.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).SoNumero().FormatStringEsquerda(4, '0'));
                else registros.Append("".FormatStringEsquerda(13, '0'));
                //Data desconto 174-179
                registros.Append(p.Nr_diasdesconto > decimal.Zero ? p.Dt_vencimento.Value.AddDays(Convert.ToDouble(p.Nr_diasdesconto) * -1).ToString("ddMMyy") : "000000");
                //Valor desconto 180-192
                registros.Append(p.Vl_desconto.SoNumero().FormatStringEsquerda(13, '0'));
                //Valor IOF 193-205
                registros.Append("".FormatStringEsquerda(13, '0'));
                //Valor abatimento 206-218
                registros.Append(p.Vl_abatimento.SoNumero().FormatStringEsquerda(13, '0'));
                //Tipo inscricao pagador 219-220
                registros.Append(p.Sacado.TipoInscricao == TTipoInscricao.tiPessoaFisica ? "01" : "02");
                //CPF/CNPJ Sacado 221-234
                registros.Append(p.Sacado.NumeroCPFCNPJ.SoNumero().FormatStringEsquerda(14, '0'));
                //Nome sacado 235-274
                registros.Append(p.Sacado.Nome.FormatStringDireita(40, ' '));
                //Endereco sacado 275-312
                registros.Append((p.Sacado.Endereco.Rua.Trim() + ", " + p.Sacado.Endereco.Numero).FormatStringDireita(38, ' '));
                //Instrucao de nao recebimento de boleto 313-314
                registros.Append("  ");
                //Bairro sacado 315-326
                registros.Append(p.Sacado.Endereco.Bairro.FormatStringDireita(12, ' '));
                //CEP Sacado 327-334
                registros.Append(p.Sacado.Endereco.CEP.SoNumero().FormatStringEsquerda(8, '0'));
                //Cidade Sacado 335-349
                registros.Append(p.Sacado.Endereco.Cidade.FormatStringDireita(15, ' '));
                //UF Sacado 350-351
                registros.Append(p.Sacado.Endereco.Estado.FormatStringDireita(2, ' '));
                //Sacador Avalista 352-390
                registros.Append("".FormatStringDireita(39, ' '));
                //Tipo boleto 391-391
                registros.Append(" ");
                //Dias Protesto 392-393
                if (p.St_protestarauto)
                    registros.Append(p.Nr_diasprotestar < 5 ? "05" : p.Nr_diasprotestar.FormatStringEsquerda(2, '0'));
                else registros.Append("  ");
                //Moeda 394-394
                registros.Append("9");//Real
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
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path_remessa + "C" + DateTime.Now.ToString("ddMMyy") + ".TXT"))
            {
                sw.Write(Remessa.ToString());
                sw.Flush();
                sw.Close();
            }
        }
        /*
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
        }*/
    }
}
