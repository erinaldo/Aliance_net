using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Contabil.SPED_CONTABIL;

namespace CamadaNegocio.Contabil.SPED_CONTABIL
{
    public class TCN_SpedContabil
    {
        private static decimal Qtd_linha;
        private static decimal Qtd_linhaI;
        private static decimal Qtd_linhaJ;
        private static decimal Qtd_linha9;

        private static TList_RegArquivo RegArq;

        #region Bloco 0
        //Abertura Arquivo Digital
        private static void GerarRegistro0000(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0000...");
            Qtd_linha = decimal.Zero;
            //Texto Fixo
            string reg0000 = "|0000|";
            //Texto Fixo
            reg0000 += "LECD|";
            //Data Inicial
            reg0000 += Dt_ini.Value.ToString("dd/MM/yyyy").SoNumero() + "|";
            //Data Final
            reg0000 += Dt_fin.Value.ToString("dd/MM/yyyy").SoNumero() + "|";
            //Nome Empresa
            reg0000 += rEmpresa.Nm_empresa.Trim() + "|";
            //CNPJ Empresa
            reg0000 += rEmpresa.Cnpj.SoNumero() + "|";
            //UF Empresa
            reg0000 += rEmpresa.Uf.Trim() + "|";
            //Insc. Estadual Empresa
            reg0000 += rEmpresa.Insc_estadual.Trim() + "|";
            //Cidade Empresa
            reg0000 += rEmpresa.Cd_cidade.Trim() + "|";
            //Inscrição Municipal Empresa
            reg0000 += rEmpresa.Insc_municipal.Trim() + "|";
            //Situação Especial
            reg0000 += "|";
            //Situação Arquivo
            reg0000 += "0|";
            //Inscrição Junta Comercial
            reg0000 += string.IsNullOrEmpty(rEmpresa.Cd_registrojunta) ? "0|" : "1|";
            //Finalidade Escrituração
            reg0000 += "0|";//Original
            //Hash Escrituração Substituida
            reg0000 += "|";
            //Nire Escrituração Substituida
            reg0000 += "|";
            //Auditoria Independente
            reg0000 += "0|";
            //Tipo ECD
            reg0000 += "0|";
            //Identificação SCP
            reg0000 += "|";
            //Identificação Moeda Funcional
            reg0000 += "N|";

            SpedContabil.AppendLine(reg0000);
            Qtd_linha++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0000", Qtd_linha = 1 });
        }
        //Abertura Bloco 0
        private static void GerarRegistro0001(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0001...");
            string reg0001 = "|0001|";
            reg0001 += "0|";

            SpedContabil.AppendLine(reg0001);
            Qtd_linha++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0001", Qtd_linha = 1 });
        }
        //Outras Inscrições Cadastrais da Pessoa Juridica
        private static void GerarRegistro0007(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0007...");
            string reg0007 = "|0007|";
            //Codigo instituição responsavel
            reg0007 += "00|";//Nenhuma inscrição em outras entidades
            //Codigo cadastral
            reg0007 += "|";

            SpedContabil.AppendLine(reg0007);
            Qtd_linha++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0007", Qtd_linha = 1 });
        }
        //Encerramento Bloco 0
        private static void GerarRegistro0990(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0990...");
            string reg0990 = "|0990|";
            Qtd_linha++;
            reg0990 += Qtd_linha.ToString() + "|";

            SpedContabil.AppendLine(reg0990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0990", Qtd_linha = 1 });
        }

        private static void GerarBloco0(TRegistro_Empresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedContabil,
                                        ThreadEspera tEspera)
        {
            GerarRegistro0000(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);
            GerarRegistro0001(SpedContabil, tEspera);
            GerarRegistro0007(SpedContabil, tEspera);
            GerarRegistro0990(SpedContabil, tEspera);
        }
        #endregion

        #region Bloco I
        //Abertura Bloco I
        private static void GerarRegistroI001(StringBuilder SpedContabil, bool St_movimento, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I001...");
            string regI001 = "|I001|";
            regI001 += St_movimento ? "0|" : "1|";

            SpedContabil.AppendLine(regI001);
            Qtd_linhaI++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I001", Qtd_linha = 1 });
        }
        //Identificação da Escrituração Contabil
        private static void GerarRegistroI010(TRegistro_Empresa rEmpresa, StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I010...");
            string regI010 = "|I010|";
            //Forma Escrituração
            regI010 += rEmpresa.Tp_spedcontabil.Trim() + "|";
            //Versão Layout
            regI010 += rEmpresa.Layoutspedcontabil.Trim() + "|";

            SpedContabil.AppendLine(regI010);
            Qtd_linhaI++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I010", Qtd_linha = 1 });
        }
        //Termo de Abertura Livro
        private static void GerarRegistroI030(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I030...");
            string regI030 = "|I030|";
            regI030 += "TERMO DE ABERTURA|";
            //Numero Livro
            regI030 += "{@NR_SPED}|";
            //Natureza Livro
            regI030 += "DIÁRIO GERAL|";
            //Quantidade Linhas Arquivo
            regI030 += "{@QTD_LINHAS}|";
            //Nome Empresa
            regI030 += rEmpresa.Nm_empresa.Trim() + "|";
            //Registro Junta Comercial
            regI030 += rEmpresa.Cd_registrojunta.Trim() + "|";
            //CNPJ
            regI030 += rEmpresa.Cnpj.SoNumero() + "|";
            //Data Abertura
            regI030 += (rEmpresa.Dt_abertura.HasValue ? rEmpresa.Dt_abertura.Value.ToString("dd/MM/yyyy").SoNumero() : string.Empty) + "|";
            //Data Arquivamento
            regI030 += "|";
            //Municipio
            regI030 += rEmpresa.Ds_cidade.Trim() + "|";
            //Data Encerramento Exercicio
            regI030 += Dt_fin.Value.ToString("dd/MM/yyyy").SoNumero() + "|";

            SpedContabil.AppendLine(regI030);
            Qtd_linhaI++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I030", Qtd_linha = 1 });
        }
        //Plano de Contas
        private static void GerarRegistroI050(TRegistro_Empresa rEmpresa,
                                              List<CamadaDados.Contabil.TRegistro_BalancoSintetico> lContas,
                                              decimal? Id_dre,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I050...");
            decimal cont = decimal.Zero;
            lContas.ForEach(p =>
                               {
                                   string regI050 = "|I050|";
                                   //Data Inclusão/Alteração
                                   regI050 += p.Dt_altconta.Value.ToString("ddMMyyyy") + "|";
                                   //Código da Natureza
                                   regI050 += p.Tp_contasped.Trim() + "|";
                                   //Tipo Conta Sintetica/Analitica
                                   regI050 += p.Tp_conta.Trim() + "|";
                                   //Nivel Conta
                                   regI050 += p.Nivelconta.ToString() + "|";
                                   //Código Conta
                                   regI050 += p.Cd_contaCTBstr + "|";
                                   //Código Conta Pai
                                   regI050 += (p.Cd_contaCTBPai.HasValue ? p.Cd_contaCTBPai.ToString() : string.Empty) + "|";
                                   //Nome da Conta
                                   regI050 += p.Ds_contactb.Trim() + "|";

                                   SpedContabil.AppendLine(regI050);
                                   Qtd_linhaI++;
                                   cont++;


                                   if (p.Tp_conta.Trim().ToUpper().Equals("A"))
                                   {
                                       //Registro Plano Referencial
                                       if (!string.IsNullOrEmpty(p.Cd_referencia))
                                           GerarRegistroI051(rEmpresa, p, SpedContabil, tEspera);
                                       //Registro Codigos Aglutinação
                                       GerarRegistroI052(p, Id_dre, SpedContabil, tEspera);
                                   }
                               });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I050", Qtd_linha = cont });
        }
        //Plano Contas Referencial
        private static void GerarRegistroI051(TRegistro_Empresa rEmpresa,
                                              CamadaDados.Contabil.TRegistro_BalancoSintetico rConta,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I051...");
            string regI051 = "|I051|";
            //Instituição Responsavel Plano Referencial
            regI051 += rEmpresa.Tp_InstPlanoRef.Trim() + "|";
            //Centro Custo
            regI051 += "|";
            //Codigo Conta Referencial
            regI051 += rConta.Cd_referencia.Trim() + "|";

            SpedContabil.AppendLine(regI051);
            Qtd_linhaI++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I051", Qtd_linha = 1 });
        }
        //Codigos Aglutinação
        private static void GerarRegistroI052(CamadaDados.Contabil.TRegistro_BalancoSintetico rConta,
                                              decimal? Id_dre,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I052...");
            decimal cont = 1;
            string regI052 = "|I052|";
            //Centro Custo
            regI052 += "|";
            //Codigo Aglutinação
            regI052 += rConta.Cd_contaCTBstr.Trim() + "|";

            SpedContabil.AppendLine(regI052);
            Qtd_linhaI++;
            
            //Verificar se conta esta amarrada a DRE
            object obj = new CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_dre",
                                    vOperador = "=",
                                    vVL_Busca = Id_dre.Value.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.CD_Conta_CTB",
                                    vOperador = "=",
                                    vVL_Busca = rConta.Cd_contaCTBstr
                                }
                            }, "c.classificacao");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
            {
                regI052 = "|I052|";
                //Centro Custo
                regI052 += "|";
                //Codigo Aglutinação
                regI052 += obj.ToString() + "|";

                SpedContabil.AppendLine(regI052);
                Qtd_linhaI++;
                cont++;
            }

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I052", Qtd_linha = cont });
        }
        //Identificação Periodo
        private static void GerarRegistroI150(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if(tEspera != null)
                tEspera.Msg("Gerando registro I150...");
            decimal cont = decimal.Zero;
            int mescorrente = Dt_ini.Value.Month;
            do
            {
                string regI150 = "|I150|";
                //Data Inicio
                regI150 += new DateTime(Dt_ini.Value.Year, mescorrente, 1).ToString("dd/MM/yyyy").SoNumero() + "|";
                //Data Final
                regI150 += new DateTime(Dt_ini.Value.Year, mescorrente, DateTime.DaysInMonth(Dt_ini.Value.Year, mescorrente)).ToString("dd/MM/yyyy").SoNumero() + "|";

                SpedContabil.AppendLine(regI150);
                Qtd_linhaI++;
                cont++;

                //Gerar Registro I155
                GerarRegistroI155(rEmpresa,
                                  new DateTime(Dt_ini.Value.Year, mescorrente, 1),
                                  new DateTime(Dt_ini.Value.Year, mescorrente, DateTime.DaysInMonth(Dt_ini.Value.Year, mescorrente)),
                                  SpedContabil,
                                  tEspera);

            }while(++mescorrente <= Dt_fin.Value.Month);
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I150", Qtd_linha = cont });
        }
        //Detalhe dos saldos periodicos
        private static void GerarRegistroI155(TRegistro_Empresa rEmpresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I155...");
            decimal cont = decimal.Zero;
            new CamadaDados.Contabil.TCD_LanctosCTB().SelectBalancoSintetico(rEmpresa.Cd_empresa,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             Dt_ini,
                                                                             Dt_fin,
                                                                             true,
                                                                             false)
                                                                             .Where(p=> p.Tp_conta.Trim().ToUpper().Equals("A"))
                                                                             .ToList()
                                                                             .ForEach(p =>
                                                                                 {
                                                                                     string regI155 = "|I155|";
                                                                                     //Codigo da Conta
                                                                                     regI155 += p.Cd_contaCTBstr + "|";
                                                                                     //Centro Custo
                                                                                     regI155 += "|";
                                                                                     //Saldo Inicial Periodo
                                                                                     regI155 += Math.Abs(p.Vl_saldoant).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                                                                     //Indicador Saldo Inicial
                                                                                     regI155 += (p.Vl_saldoant >= decimal.Zero ? p.Natureza.Trim() : p.Natureza.Trim().Equals("D") ? "C" : "D") + "|";
                                                                                     //Valor dos debitos
                                                                                     regI155 += p.Vl_debito.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                                                                     //Valor dos creditos
                                                                                     regI155 += p.Vl_credito.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                                                                     //Saldo Final
                                                                                     regI155 += Math.Abs(p.Vl_atual).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                                                                     //Indicador Saldo Final
                                                                                     regI155 += (p.Vl_atual >= decimal.Zero ? p.Natureza.Trim() : p.Natureza.Trim().Equals("D") ? "C" : "D") + "|";

                                                                                     SpedContabil.AppendLine(regI155);
                                                                                     Qtd_linhaI++;
                                                                                     cont++;
                                                                                 });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I155", Qtd_linha = cont });
        }
        //Lançamento Contabil
        private static void GerarRegistroI200(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I200...");
            decimal cont = decimal.Zero;
            CamadaDados.Contabil.TList_LanContabil lLanctos =
                new CamadaDados.Contabil.TCD_LanctosCTB().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))",
                            vOperador = ">=",
                            vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))",
                            vOperador = "<=",
                            vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                        }
                    }, 0, string.Empty, string.Empty);
            lLanctos.Where(p=> p.D_c.Trim().ToUpper().Equals("D")).OrderBy(p=> p.Data).ToList().ForEach(p =>
                {
                    string regI200 = "|I200|";
                    //Numero Lote
                    regI200 += p.ID_LoteCTB.Value.ToString() + "|";
                    //Data Lançamento
                    regI200 += p.Data.Value.ToString("ddMMyyyy") + "|";
                    //Valor Lançamento
                    regI200 += p.Valor.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Tipo Lançamento N-Normal E-Encerramento
                    regI200 += p.Tp_integracao.Trim().ToUpper().Equals("ZR") ? "E|" : "N|";

                    SpedContabil.AppendLine(regI200);
                    Qtd_linhaI++;
                    cont++;

                    //Registro Filho I250
                    GerarRegistroI250(lLanctos.FindAll(v=> v.ID_LoteCTB == p.ID_LoteCTB), SpedContabil, tEspera);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I200", Qtd_linha = cont });
        }

        //Partidas do Lançamento
        private static void GerarRegistroI250(List<CamadaDados.Contabil.TRegistro_LanctosCTB> val,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I250...");
            decimal cont = decimal.Zero;
            val.ForEach(p =>
                    {
                        string regI250 = "|I250|";
                        //Codigo da Conta
                        regI250 += p.Cd_conta_ctbstr + "|";
                        //Centro Custo
                        regI250 += "|";
                        //Valor Lançamento
                        regI250 += p.Valor.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Natureza
                        regI250 += p.D_c.Trim() + "|";
                        //Numero Documento arquivado
                        regI250 += "|";
                        //Codigo Historico
                        regI250 += "|";
                        //Historico
                        regI250 += (string.IsNullOrEmpty(p.Ds_compl_historico) ? p.Ds_contactb.Trim() : p.Ds_compl_historico.Trim()) + "|";
                        //Codigo Participante
                        regI250 += "|";

                        SpedContabil.AppendLine(regI250);
                        Qtd_linhaI++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I250", Qtd_linha = cont });
        }
        //Saldo Contas de Resultado
        private static void GerarRegistroI350(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I350...");
            string regI350 = "|I350|";
            //Data Apuração
            regI350 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
            
            SpedContabil.AppendLine(regI350);
            Qtd_linhaI++;
            GerarRegistroI355(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I350", Qtd_linha = 1 });
        }
        //Detalhe Saldo das Contas de Resultado
        private static void GerarRegistroI355(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I355...");
            decimal cont = decimal.Zero;
            new TCD_I355().Select(rEmpresa.Cd_empresa,
                                  Dt_ini.Value,
                                  Dt_fin.Value).FindAll(p=> !p.Vl_saldo.Equals(decimal.Zero)).ForEach(p =>
                                      {
                                          string regI355 = "|I355|";
                                          //Codigo Conta
                                          regI355 += p.Cd_contaCTB.Value.ToString() + "|";
                                          //Centro Custo
                                          regI355 += "|";
                                          //Saldo Conta
                                          regI355 += Math.Abs(p.Vl_saldo).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                          //Indicador Saldo Inicial
                                          regI355 += (p.Vl_saldo >= decimal.Zero ? p.Natureza.Trim() : p.Natureza.Trim().Equals("D") ? "C" : "D") + "|";

                                          SpedContabil.AppendLine(regI355);
                                          Qtd_linhaI++;
                                          cont++;
                                      });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I355", Qtd_linha = cont });
        }
        //Encerramento Bloco I
        private static void GerarRegistroI990(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro I990...");
            string regI990 = "|I990|";
            //Qtde Linhas Bloco I
            regI990 += (++Qtd_linhaI).ToString() + "|";
            SpedContabil.AppendLine(regI990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "I990", Qtd_linha = 1 });
        }

        private static void GerarBlocoI(TRegistro_Empresa rEmpresa,
                                        List<CamadaDados.Contabil.TRegistro_BalancoSintetico> balanco,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        decimal? Id_dre,
                                        StringBuilder SpedContabil,
                                        ThreadEspera tEspera)
        {
            GerarRegistroI001(SpedContabil, balanco.Count > 0, tEspera);
            if (balanco.Count > 0)
            {
                GerarRegistroI010(rEmpresa, SpedContabil, tEspera);
                GerarRegistroI030(rEmpresa, Dt_fin, SpedContabil, tEspera);
                GerarRegistroI050(rEmpresa, balanco, Id_dre, SpedContabil, tEspera);
                GerarRegistroI150(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);
                GerarRegistroI200(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);
                GerarRegistroI350(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);
            }
            GerarRegistroI990(SpedContabil, tEspera);
        }
        #endregion

        #region Bloco J
        //Abertura Bloco J
        private static void GerarRegistroJ001(StringBuilder SpedContabil,
                                              bool St_movimento,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J001...");
            string regJ001 = "|J001|";
            regJ001 += St_movimento ? "0|" : "1|";

            SpedContabil.AppendLine(regJ001);
            Qtd_linhaJ++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J001", Qtd_linha = 1 });
        }
        //Demonstrações Contabeis
        private static void GerarRegistroJ005(List<CamadaDados.Contabil.TRegistro_BalancoSintetico> balanco,
                                              TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              decimal Id_dre,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J005...");
            string regJ005 = "|J005|";
            //Data Inicial
            regJ005 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
            //Data Final
            regJ005 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
            //Identificação Demonstração
            regJ005 += "1|";
            //Cabeçalho
            regJ005 += "|";

            SpedContabil.AppendLine(regJ005);
            Qtd_linhaJ++;
            GerarRegistroJ100(balanco, SpedContabil, tEspera);
            GerarRegistroJ150(rEmpresa, Id_dre, Dt_ini, Dt_fin, SpedContabil, tEspera);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J005", Qtd_linha = 1 });
        }
        //Balanço Patrimonial
        private static void GerarRegistroJ100(List<CamadaDados.Contabil.TRegistro_BalancoSintetico> balanco,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J100...");
            decimal cont = decimal.Zero;
            balanco.Where(p => p.Classificacao.StartsWith("1") || p.Classificacao.StartsWith("2")).ToList().ForEach(p =>
                {
                    string regJ100 = "|J100|";
                    //Codigo Conta
                    regJ100 += p.Cd_contaCTBstr + "|";
                    //Nivel
                    regJ100 += p.Nivelconta.ToString() + "|";
                    //Indicador de grupo balanço
                    regJ100 += p.Classificacao.Substring(0, 1) + "|";
                    //Descrição Conta
                    regJ100 += p.Ds_contactb.Trim() + "|";
                    //Valor Conta
                    regJ100 += Math.Abs(p.Vl_atual).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador situação saldo
                    regJ100 += (p.Vl_atual >= decimal.Zero ? p.Natureza.Trim() : p.Natureza.Trim().Equals("D") ? "C" : "D") + "|";
                    //Valor Inicial
                    regJ100 += Math.Abs(p.Vl_saldoant).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador situação saldo
                    regJ100 += (p.Vl_saldoant >= decimal.Zero ? p.Natureza.Trim() : p.Natureza.Trim().Equals("D") ? "C" : "D") + "|";

                    SpedContabil.AppendLine(regJ100);
                    Qtd_linhaJ++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J100", Qtd_linha = cont });
        }
        //DRE
        private static void GerarRegistroJ150(TRegistro_Empresa rEmpresa,
                                              decimal Id_dre,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J150...");
            decimal cont = decimal.Zero;
            TCN_LanContabil.GerarDRE(rEmpresa.Cd_empresa, Id_dre.ToString(), Dt_fin.Value.Year).ForEach(p =>
                {
                    string regJ150 = "|J150|";
                    //Codigo Aglutinação
                    regJ150 += (p.Cd_conta_ctb.HasValue ? p.Cd_conta_ctb.Value.ToString() : p.Classificacao.Trim()) + "|";
                    //Nivel Aglutinação
                    regJ150 += p.Nivel.ToString() + "|";
                    //Descrição Aglutinação
                    regJ150 += (!string.IsNullOrEmpty(p.Ds_contactb) ? p.Ds_contactb.Trim() : p.Ds_param.Trim()) + "|";
                    //Valor Conta
                    regJ150 += Math.Abs(p.Tp_conta.Trim().ToUpper().Equals("A") ? p.Sd_atual : p.Tot_atual).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador do Valor
                    regJ150 += (p.Tp_conta.Trim().ToUpper().Equals("R") ? (p.Tp_conta.Trim().ToUpper().Equals("A") ? p.Sd_atual : p.Tot_atual) >= decimal.Zero ? "P" : "N" : p.Operador.Trim().ToUpper().Equals("S") ? "R" : "D") + "|";
                    //Saldo Anterior
                    regJ150 += Math.Abs(p.Tp_conta.Trim().ToUpper().Equals("A") ? p.Sd_ant : p.Tot_ant).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador do Valor
                    regJ150 += (p.Tp_conta.Trim().ToUpper().Equals("R") ? (p.Tp_conta.Trim().ToUpper().Equals("A") ? p.Sd_ant : p.Tot_ant) >= decimal.Zero ? "P" : "N" : p.Operador.Trim().ToUpper().Equals("S") ? "R" : "D") + "|";

                    SpedContabil.AppendLine(regJ150);
                    Qtd_linhaJ++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J150", Qtd_linha = cont });
        }
        //Termo Encerramento
        private static void GerarRegistroJ900(TRegistro_Empresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J900...");
            string regJ900 = "|J900|";
            //Texto Fixo
            regJ900 += "TERMO DE ENCERRAMENTO|";
            //Numero Arquivo
            regJ900 += "{@NR_SPED}|";
            //Natureza Livro
            regJ900 += "DIÁRIO GERAL|";
            //Nome Empresa
            regJ900 += rEmpresa.Nm_empresa.Trim() + "|";
            //Total Linhas Arquivo
            regJ900 += "{@QTD_LINHAS}|";
            //Data Inicial
            regJ900 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
            //Data Final
            regJ900 += Dt_fin.Value.ToString("ddMMyyyy") + "|";

            SpedContabil.AppendLine(regJ900);
            Qtd_linhaJ++;

            GerarRegistroJ930(rEmpresa, SpedContabil, tEspera);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J900", Qtd_linha = 1 });
        }
        //Signatarios da escrituração
        private static void GerarRegistroJ930(TRegistro_Empresa rEmpresa,
                                              StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J930...");
            decimal qtd_J930 = decimal.Zero;
            #region Contador
            string regJ930 = "|J930|";
            //Nome Signatario
            regJ930 += rEmpresa.NM_contador.RemoverCaracteres() + "|";
            //CPF Contador
            regJ930 += rEmpresa.Cpf_contador.SoNumero() + "|";
            //Qualificação
            regJ930 += "CONTADOR|";
            //Codigo qualificação
            regJ930 += "900|";
            //CRC Contador
            regJ930 += rEmpresa.Nr_CRC.Trim() + "|";
            //Email Contador
            regJ930 += rEmpresa.Email_contador.Trim() + "|";
            //Fone Contador
            regJ930 += rEmpresa.Fone_contador.Trim() + "|";
            //UF CRC Contador
            regJ930 += rEmpresa.UF_CRC.Trim() + "|";
            //Sequencial CRC Contador
            regJ930 += rEmpresa.SequencialCRC.Trim() + "|";
            //Validade CRC
            regJ930 += (rEmpresa.Dt_validadeCRC.HasValue ? rEmpresa.Dt_validadeCRC.Value.ToString("ddMMyyyy") : string.Empty) + "|";
            //Administrador
            regJ930 += "N|";
            SpedContabil.AppendLine(regJ930);
            Qtd_linhaJ++;
            qtd_J930++;
            #endregion
            #region Administrador
            CamadaDados.Diversos.TList_SociosEmpresa lSocio =
            new CamadaDados.Diversos.TCD_SociosEmpresa().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_responsavel, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 1, string.Empty);
            if (lSocio.Count > 0)
            {
                regJ930 = "|J930|";
                //Nome Signatario
                regJ930 += lSocio[0].Nm_clifor.RemoverCaracteres() + "|";
                //CPF Contador
                regJ930 += lSocio[0].Cpf_clifor.SoNumero() + "|";
                //Qualificação
                regJ930 += "ADMINISTRADOR|";
                //Codigo qualificação
                regJ930 += "205|";
                //CRC Contador
                regJ930 += "|";
                //Email Contador
                regJ930 += "|";
                //Fone Contador
                regJ930 += "|";
                //UF CRC Contador
                regJ930 += "|";
                //Sequencial CRC Contador
                regJ930 += "|";
                //Validade CRC
                regJ930 += "|";
                //Administrador
                regJ930 += "S|";
                SpedContabil.AppendLine(regJ930);
                Qtd_linhaJ++;
                qtd_J930++;
            }
            #endregion
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J930", Qtd_linha = qtd_J930 });
        }
        //Encerramento Bloco J
        private static void GerarRegistroJ990(StringBuilder SpedContabil,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro J990...");
            string regJ990 = "|J990|";
            //Qtde Linhas Bloco I
            regJ990 += (++Qtd_linhaJ).ToString() + "|";
            SpedContabil.AppendLine(regJ990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "J990", Qtd_linha = 1 });
        }

        public static void GerarBlocoJ(TRegistro_Empresa rEmpresa,
                                       List<CamadaDados.Contabil.TRegistro_BalancoSintetico> balanco,
                                       DateTime? Dt_ini,
                                       DateTime? Dt_fin,
                                       decimal Id_dre,
                                       StringBuilder SpedContabil,
                                       ThreadEspera tEspera)
        {
            GerarRegistroJ001(SpedContabil, balanco.Count > 0, tEspera);
            if (balanco.Count > 0)
            {
                GerarRegistroJ005(balanco, rEmpresa, Dt_ini, Dt_fin, Id_dre, SpedContabil, tEspera);
                GerarRegistroJ900(rEmpresa, Dt_ini, Dt_fin, SpedContabil, tEspera);
            }
            GerarRegistroJ990(SpedContabil, tEspera);
        }
        #endregion

        #region Bloco 9000
        //Abertura bloco 9
        private static void GerarRegistro9001(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9001...");
            string reg9001 = "|9001|";
            //Indicador de Movimento
            reg9001 += "0|";

            SpedContabil.AppendLine(reg9001);
            Qtd_linha9++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9001", Qtd_linha = 1 });
        }
        //Registros do Arquivo
        private static void GerarRegistro9900(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9900...");
            decimal cont = decimal.Zero;
            string reg9900 = string.Empty;
            RegArq.ForEach(p =>
            {
                reg9900 = "|9900|";
                //Registro totalizado
                reg9900 += p.Registro.Trim() + "|";
                //Quantidade registro
                reg9900 += p.Qtd_linha.ToString("N0").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                SpedContabil.AppendLine(reg9900);
                Qtd_linha9++;
                cont++;
            });
            Qtd_linha9 += 3;
            cont += 3;
            //Totalizar registro 9900
            reg9900 = "|9900|";
            reg9900 += "9900|";
            reg9900 += cont.ToString("N0").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            SpedContabil.AppendLine(reg9900);
            //Totalizar Registro 9990
            reg9900 = "|9900|";
            reg9900 += "9990|";
            reg9900 += "1|";
            SpedContabil.AppendLine(reg9900);
            //Totalizar Registro 9999
            reg9900 = "|9900|";
            reg9900 += "9999|";
            reg9900 += "1|";
            SpedContabil.AppendLine(reg9900);
        }
        //Encerramento bloco 9
        private static void GerarRegistro9990(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9990...");
            string reg9990 = "|9990|";
            Qtd_linha9 += 2;
            reg9990 += Qtd_linha9.ToString() + "|";

            SpedContabil.AppendLine(reg9990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9990", Qtd_linha = 1 });
        }
        //Encerramento Arquivo Digital
        private static void GerarRegistro9999(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9999...");
            string reg9999 = "|9999|";
            reg9999 += (Qtd_linha + Qtd_linhaI + Qtd_linhaJ + Qtd_linha9).ToString() + "|";
            SpedContabil.AppendLine(reg9999);
        }

        private static void GerarBloco9(StringBuilder SpedContabil, ThreadEspera tEspera)
        {
            GerarRegistro9001(SpedContabil, tEspera);
            GerarRegistro9900(SpedContabil, tEspera);
            GerarRegistro9990(SpedContabil, tEspera);
            GerarRegistro9999(SpedContabil, tEspera);
        }
        #endregion

        public static string ProcessarSpedContabil(string Cd_empresa,
                                                   DateTime? Dt_ini,
                                                   DateTime? Dt_fin,
                                                   decimal Id_dre,
                                                   ThreadEspera tEspera)
        {
            try
            {
                StringBuilder SpedContabil = new StringBuilder();
                RegArq = new TList_RegArquivo();
                if (string.IsNullOrEmpty(Cd_empresa))
                    throw new Exception("Obrigatório informar empresa.");
                if(Dt_ini == null)
                    throw new Exception("Obrigatorio informar data inicial.");
                if (Dt_fin == null)
                    throw new Exception("Obrigatorio informar data final.");
                List<TRegistro_Empresa> lEmpresa = new TCD_Empresa().Select(new TpBusca[]{
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    }
                });
                if (lEmpresa.Count > 0)
                {
                    GerarBloco0(lEmpresa[0], Dt_ini, Dt_fin, SpedContabil, tEspera);
                    List<CamadaDados.Contabil.TRegistro_BalancoSintetico> Balanco =
                    TCN_LanContabil.GerarBalanco(Cd_empresa, string.Empty, string.Empty, Dt_ini, Dt_fin, true, false, string.Empty, false, false);
                    GerarBlocoI(lEmpresa[0], Balanco, Dt_ini, Dt_fin, Id_dre, SpedContabil, tEspera);
                    GerarBlocoJ(lEmpresa[0], Balanco, Dt_ini, Dt_fin, Id_dre, SpedContabil, tEspera);
                    GerarBloco9(SpedContabil, tEspera);
                    string sped = SpedContabil.ToString().Trim().Replace("{@QTD_LINHAS}", (Qtd_linha + Qtd_linhaI + Qtd_linhaJ + Qtd_linha9).ToString());
                    //Verificar numero do livro
                    object obj = new TCD_SpedContabil().BuscarEscalar(new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_empresa",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                                            },
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_ini)))",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                                                                            },
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_fin)))",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                                                                            }
                                                                        }, "a.nr_sped");
                    if (obj != null)
                        sped = sped.Replace("{@NR_SPED}", obj.ToString());
                    else
                    {
                        obj = new TCD_SpedContabil().BuscarEscalar(new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_empresa",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                                        }
                                                                    }, "isnull(max(a.nr_sped), 0)");
                        new TCD_SpedContabil().Gravar(new TRegistro_SpedContabil() 
                        { 
                            Cd_empresa = Cd_empresa,
                            Nr_sped = decimal.Parse(obj.ToString()) + 1,
                            Dt_ini = Dt_ini,
                            Dt_fin = Dt_fin
                        });
                        sped = sped.Replace("{@NR_SPED}", (decimal.Parse(obj.ToString()) + 1).ToString());
                    }
                    return sped;
                }
                else throw new Exception("Não foi possivel encontrar os dados da empresa.");
            }
            catch (Exception ex)
            { throw new Exception("Erro gerar sped contabil: " + ex.Message.Trim()); }
        }
    }
}
