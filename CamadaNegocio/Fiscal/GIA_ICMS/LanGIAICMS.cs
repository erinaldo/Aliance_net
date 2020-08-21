using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fiscal.GIA_ICMS;
using System.Text.RegularExpressions;

namespace CamadaNegocio.Fiscal.GIA_ICMS
{
    public class TCN_GIAICMS
    {
        public static TList_GIAICMS Buscar(string Cd_empresa,
                                           string Dt_ini,
                                           string Dt_fin,
                                           BancoDados.TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Dt_ini)) &&
                (!string.IsNullOrEmpty(Dt_fin)))
                return new TCD_GIA_ICMS(banco).Select(Cd_empresa, Dt_ini, Dt_fin);
            else
                return null;
        }
       
        public static string GerarGIAICMS(TRegistro_GIAICMS val)
        {
            if (val != null)
            {
                StringBuilder gia = new StringBuilder();
                #region Registro Tipo 1 - Cabeçalho
                //Tipo Registro - 1
                gia.Append("1");
                //Inscricao Estadual Empresa
                gia.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                //Ano/Mes de Referencia YYYYMM
                gia.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                //Tipo Gia NORMAL=43 RETIFICACAO=51
                gia.Append(val.Tp_gia.Trim());
                //CRC Contador
                gia.Append(Regex.Replace(val.Crc_contador.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).FormatStringEsquerda(10, ' '));
                //Valor do estoque
                gia.Append(val.Vl_estoque.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                //Numero Funcionarios
                gia.Append(val.Qtd_funcionario.ToString().SoNumero().FormatStringEsquerda(5, '0'));
                //Valor da folha de pagamento
                gia.Append(val.Vl_folhapgto.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                #endregion

                #region Registros Detalhes
                StringBuilder det = new StringBuilder();
                int tot_regdetalhes = 0;
                //Registro Detalhe Valor Despesas
                det.Append("2");
                det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                det.Append(val.Tp_gia.Trim());
                det.Append("02");
                det.AppendLine(val.Vl_despesas.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                tot_regdetalhes++;
                //Registro Detalhe Produtos Primarios
                det.Append("2");
                det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                det.Append(val.Tp_gia.Trim());
                det.Append("04");
                det.AppendLine(val.Vl_produtosprimarios.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                tot_regdetalhes++;
                //Registro Detalhe Receitas com Servicos
                det.Append("2");
                det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                det.Append(val.Tp_gia.Trim());
                det.Append("06");
                det.AppendLine(val.Vl_servicos.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                tot_regdetalhes++;
                //Campo 10 = Valor Despesas + Produtos Primarios + Servicos
                det.Append("2");
                det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                det.Append(val.Tp_gia.Trim());
                det.Append("10");
                det.AppendLine(val.Campo10.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                tot_regdetalhes++;


                #region Quadro 08 - Valor Contabil - Entrada
                //Campo 11
                if (val.Campo11 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("11");
                    det.AppendLine(val.Campo11.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 13
                if (val.Campo13 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("13");
                    det.AppendLine(val.Campo13.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 14

                if (val.Campo14> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("14");
                    det.AppendLine(val.Campo14.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 15
                if (val.Campo15> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("15");
                    det.AppendLine(val.Campo15.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 16
                if (val.Campo16> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("16");
                    det.AppendLine(val.Campo16.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 17
                if (val.Campo17> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("17");
                    det.AppendLine(val.Campo17.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 18
                if (val.Campo18> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("18");
                    det.AppendLine(val.Campo18.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 19
                if (val.Campo19> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("19");
                    det.AppendLine(val.Campo19.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                
                //Campo 20 Totalizar Quadro 08
                if (val.Campo20 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("20");
                    det.AppendLine(val.Campo20.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #region Quadro 08 Valor Base de Calculo - Entrada
                //Campo 21
                if (val.Campo21> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("21");
                    det.AppendLine(val.Campo21.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 23
                if (val.Campo23> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("23");
                    det.AppendLine(val.Campo23.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 24
                if (val.Campo24 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("24");
                    det.AppendLine(val.Campo24.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 25
                if (val.Campo25> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("25");
                    det.AppendLine(val.Campo25.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 26
                if (val.Campo26 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("26");
                    det.AppendLine(val.Campo26.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 27
                if (val.Campo27 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("27");
                    det.AppendLine(val.Campo27.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 28
                if (val.Campo28> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("28");
                    det.AppendLine(val.Campo28.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 29
                if (val.Campo29 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("29");
                    det.AppendLine(val.Campo29.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 30
                if (val.Campo30 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("30");
                    det.AppendLine(val.Campo30.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #region Quadro 08 Valor Contabil - Saida
                //Campo 31
                if (val.Campo31> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("31");
                    det.AppendLine(val.Campo31.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 33
                if (val.Campo33 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("33");
                    det.AppendLine(val.Campo33.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 34
                if (val.Campo34 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("34");
                    det.AppendLine(val.Campo34.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 35
                if (val.Campo35 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("35");
                    det.AppendLine(val.Campo35.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 36
                if (val.Campo36 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("36");
                    det.AppendLine(val.Campo36.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 39
                if (val.Campo39 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("39");
                    det.AppendLine(val.Campo39.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 40
                if (val.Campo40 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("40");
                    det.AppendLine(val.Campo40.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #region Quadro 08 - Valor Base Calculo - Saida
                //Campo 41
                if (val.Campo41 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("41");
                    det.AppendLine(val.Campo41.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 43
                if (val.Campo43 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("43");
                    det.AppendLine(val.Campo43.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 44
                if (val.Campo44 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("44");
                    det.AppendLine(val.Campo44.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 45
                if (val.Campo45 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("45");
                    det.AppendLine(val.Campo45.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
            //Campo 46
                if (val.Campo46 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("46");
                    det.AppendLine(val.Campo46.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 49
                if (val.Campo49 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("49");
                    det.AppendLine(val.Campo49.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 50
                if (val.Campo50 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("50");
                    det.AppendLine(val.Campo50.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #region Quadro 09 - Debitos ICMS
                //Campo 51
                if (val.Campo51 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("51");
                    det.AppendLine(val.Campo51.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 52
                if (val.Campo52 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("52");
                    det.AppendLine(val.Campo52.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 53
                if (val.Campo53 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("53");
                    det.AppendLine(val.Campo53.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 54
                if (val.Campo54 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("54");
                    det.AppendLine(val.Campo54.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 55
                if (val.Campo55> 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("55");
                    det.AppendLine(val.Campo55.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 56
                if (val.Campo56 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("56");
                    det.AppendLine(val.Campo56.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 58
                if (val.Campo58 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("58");
                    det.AppendLine(val.Campo58.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 59
                if (val.Campo59 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("59");
                    det.AppendLine(val.Campo59.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 60
                if (val.Campo60 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("60");
                    det.AppendLine(val.Campo60.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #region Quadro 10 - Creditos ICMS
                //Campo 61
                if (val.Campo61 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("61");
                    det.AppendLine(val.Campo61.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 62
                if (val.Campo62 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("62");
                    det.AppendLine(val.Campo62.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 63
                if (val.Campo63 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("63");
                    det.AppendLine(val.Campo63.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 64
                if (val.Campo64 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("64");
                    det.AppendLine(val.Campo64.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 65
                if (val.Campo65 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("65");
                    det.AppendLine(val.Campo65.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 66
                if (val.Campo66 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("66");
                    det.AppendLine(val.Campo66.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 67
                if (val.Campo67 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("67");
                    det.AppendLine(val.Campo67.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 68
                if (val.Campo68 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("68");
                    det.AppendLine(val.Campo68.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 69
                if (val.Campo69 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("69");
                    det.AppendLine(val.Campo69.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 70
                if (val.Campo70 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("70");
                    det.AppendLine(val.Campo70.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }

                #endregion

                #region Quadro 11 - Apuracao no Periodo
                //Campo 80
                if (val.Campo80 > 0)
                {
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("80");
                    det.Append(val.Campo80.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                //Campo 90
                if (val.Campo90 > 0)
                {   
                    det.Append("2");
                    det.Append(Regex.Replace(val.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Replace('-', ' ').FormatStringEsquerda(10, '0'));
                    det.Append(val.Ano_referencia.Trim() + val.Mes_referencia.Trim());
                    det.Append(val.Tp_gia.Trim());
                    det.Append("90");
                    det.Append(val.Campo90.ToString().SoNumero().FormatStringEsquerda(15, '0'));
                    tot_regdetalhes++;
                }
                #endregion

                #endregion
                //Quantidade de Registros Tipo 2 do Arquivo
                gia.AppendLine(tot_regdetalhes.ToString().FormatStringEsquerda(2, '0'));
                gia.Append(det.ToString());
                return gia.ToString();
            }
            return string.Empty;
        }
    }
}
