using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;
using CamadaDados.Fiscal.SPED_PISCOFINS;

namespace CamadaNegocio.Fiscal.SPED_PISCOFINS
{
    public class TCN_SpedPisCofins
    {
        private static decimal Qtd_linha;
        private static decimal Qtd_linhaA;
        private static decimal Qtd_linhaC;
        private static decimal Qtd_linhaD;
        private static decimal Qtd_linhaF;
        private static decimal Qtd_linhaM;
        private static decimal Qtd_linha1;
        private static decimal Qtd_linha9;

        private static TList_RegArquivo RegArq;

        #region Bloco 0
        //Abertura do arquivo digital e identificacao da entidade
        private static void GerarRegistro0000(TRegistro_DadosEmpresa rEmpresa,
                                              string Finalidade,
                                              string Nr_recibo,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linha = decimal.Zero;
            if (rEmpresa != null)
            {
                //Texto Fixo
                string reg0000 = "|0000|";
                //Versao do Layout
                reg0000 += rEmpresa.LayoutSpedPisCofins.Trim().FormatStringEsquerda(3, '0') + "|";
                //Tipo Escrituracao
                reg0000 += Finalidade.Trim() + "|";
                //Indicador de situacao especial
                reg0000 += "|";
                //Numero do recibo a ser retificado
                reg0000 += Nr_recibo.Trim() + "|";
                //Data Inicial
                reg0000 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
                //Data Final
                reg0000 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
                //Nome da Empresa
                reg0000 += rEmpresa.Nm_empresa.Trim().RemoverCaracteres() + "|";
                //Cnpj Empresa
                reg0000 += rEmpresa.Nr_cnpj.Trim().SoNumero() + "|";
                //UF Empresa
                reg0000 += rEmpresa.Uf.Trim() + "|";
                //Codigo do Municipio
                reg0000 += rEmpresa.Cd_cidade.Trim().PadLeft(7, '0') + "|";
                //Inscricao Suframa
                reg0000 += "|";
                //Natureza Pessoa Juridica
                reg0000 += rEmpresa.Tp_naturezaPJ.Trim() + "|";
                //Tipo Atividade Empresa
                reg0000 += rEmpresa.Tp_atividadespedpiscofins.Trim() + "|";

                SpedFiscal.AppendLine(reg0000);
                Qtd_linha++;

                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0000", Qtd_linha = 1 });
            }
        }

        //Abertura do bloco 0
        private static void GerarRegistro0001(StringBuilder SpedFiscal)
        {
            string reg0001 = "|0001|";
            reg0001 += "0|";

            SpedFiscal.AppendLine(reg0001);
            Qtd_linha++;

            RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "0001", Qtd_linha = 1 });
        }

        //Dados do contabilista
        private static void GerarRegistro0100(TRegistro_DadosEmpresa rEmpresa, 
                                              StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
                if (!string.IsNullOrEmpty(rEmpresa.Cd_clifor_contador))
                {
                    //Buscar dados Contabilista
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Contador =
                        Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rEmpresa.Cd_clifor_contador, null);
                    //Buscar endereco contador
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                        Financeiro.Cadastros.TCN_CadEndereco.Buscar(rEmpresa.Cd_clifor_contador,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  null);
                    string reg0100 = "|0100|";
                    //Nome Contador
                    reg0100 += Contador.Nm_clifor.RemoverCaracteres().Trim() + "|";
                    //CPF Contador
                    reg0100 += Contador.Nr_cpf.SoNumero() + "|";
                    //CRC Contador
                    reg0100 += rEmpresa.Crc_contador.Trim() + "|";
                    //CNPJ Escritorio Contabil
                    reg0100 += rEmpresa.Cnpj_escritorio_contabil.SoNumero() + "|";
                    //CEP Contador
                    reg0100 += (lEndereco.Count > 0 ? Regex.Replace(lEndereco[0].Cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(8, '0') : string.Empty) + "|";
                    //Endereco Contador
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Ds_endereco.Trim() : string.Empty) + "|";
                    //Numero
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Numero.Trim() : string.Empty) + "|";
                    //Complemento Endereco
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Ds_complemento.Trim() : string.Empty) + "|";
                    //Bairro
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Bairro.Trim() : string.Empty) + "|";
                    //Fone
                    string fone = lEndereco.Count > 0 ? lEndereco[0].Fone.SoNumero() : string.Empty;
                    if (string.IsNullOrEmpty(fone))
                        reg0100 += "|";
                    else
                        reg0100 += fone.Trim().FormatStringDireita(10, '0') + "|";
                    //Fax
                    reg0100 += "|";
                    //Email
                    reg0100 += string.Empty + "|";
                    //Municipio do Contador
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Cd_cidade.Trim().Substring(0, 7) : string.Empty) + "|";

                    SpedFiscal.AppendLine(reg0100);
                    Qtd_linha++;

                    RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0100", Qtd_linha = 1 });
                }
                else
                    throw new Exception("Não existe contador configurado para a empresa " + rEmpresa.Cd_empresa.Trim());
        }

        //Regime de apuração da contribuição
        private static void GerarRegistro0110(TRegistro_DadosEmpresa rEmpresa, StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
            {
                //Texto Fixo
                string reg0110 = "|0110|";
                //Incidencia Tributaria
                reg0110 += rEmpresa.Tp_incidtributaria.Trim() + "|";
                //Metodo Apropriacao Credito
                reg0110 += rEmpresa.Tp_apropcredito.Trim() + "|";
                //Tipo Contribuicao Apurada
                reg0110 += rEmpresa.Tp_contribuicao.Trim() + "|";
                //Criterio de Escrituracao e apuracao adotado no regime cumulativo
                reg0110 += (string.IsNullOrEmpty(rEmpresa.Tp_incidtributaria) ? string.Empty : rEmpresa.Tp_regimecumulativo.Trim()) + "|";

                SpedFiscal.AppendLine(reg0110);
                Qtd_linha++;

                RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "0110", Qtd_linha = 1 });
            }
            else
                throw new Exception("Não existe empresa selecionada para gerar arquivo.");
        }

        //Cadastro de Estabelecimentos
        private static void GerarRegistro0140(TRegistro_DadosEmpresa rEmpresa, StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
            {
                //Texto Fixo
                string reg0140 = "|0140|";
                //Codigo da Empresa
                reg0140 += rEmpresa.Cd_empresa.Trim() + "|";
                //Nome da Empresa
                reg0140 += rEmpresa.Nm_empresa.RemoverCaracteres().Trim() + "|";
                //Cnpj da Empresa
                reg0140 += rEmpresa.Nr_cnpj.SoNumero() + "|";
                //Sigla Estado
                reg0140 += rEmpresa.Uf.Trim() + "|";
                //Inscricao Estadual
                reg0140 += Regex.Replace(rEmpresa.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                //Codigo da cidade
                reg0140 += rEmpresa.Cd_cidade.Trim().Substring(0, 7).SoNumero() + "|";
                //Inscricao Municipal
                reg0140 += Regex.Replace(rEmpresa.Insc_municipal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                //Suframa
                reg0140 += "|";

                SpedFiscal.AppendLine(reg0140);
                Qtd_linha++;

                RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "0140", Qtd_linha = 1 });
            }
            else
                throw new Exception("Não existe empresa selecionada para gerar arquivo.");
        }

        //Tabela de cadastro do participante
        private static void GerarRegistro0150(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_Participamente().Select(
            new TpBusca[]
            {
                new TpBusca()
                {
                    vNM_Campo = "cd_empresa",
                    vOperador = "=",
                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                },
                new TpBusca()
                {
                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), data)))",
                    vOperador = ">=",
                    vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                },
                new TpBusca()
                {
                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), data)))",
                    vOperador = "<=",
                    vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                }
            }).ForEach(p =>
            {
                string reg0150 = "|0150|";
                //Codigo Clifor
                reg0150 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                //Nome Clifor
                reg0150 += p.Nm_clifor.Trim() + "|";
                //Pais
                reg0150 += p.Cd_pais.Trim() + "|";
                //CNPJ
                reg0150 += p.Cnpj.SoNumero() + "|";
                //CPF
                reg0150 += p.Cpf.SoNumero() + "|";
                //Inscricao Estadual
                reg0150 += Regex.Replace(p.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                //Cidade
                reg0150 += p.Cd_cidade.Trim().Substring(0, 7).SoNumero() + "|";
                //Suframa
                reg0150 += "|";
                //Endereco
                reg0150 += p.Ds_endereco.Trim() + "|";
                //Numero
                reg0150 += p.Numero.Trim() + "|";
                //Complemento
                reg0150 += p.Complemento.Trim() + "|";
                //Bairro
                reg0150 += p.Bairro.Trim() + "|";

                SpedFiscal.AppendLine(reg0150);
                Qtd_linha++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0150", Qtd_linha = cont });
        }

        //Identificacao das unidades de medida
        private static void GerarRegistro0190(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_Unidade().Select(Cd_empresa, Dt_ini, Dt_fin).ForEach(p =>
            {
                string reg0190 = "|0190|";
                //Codigo Unidade
                reg0190 += p.Cd_unidade.Trim() + "|";
                //Descricao Unidade
                reg0190 += p.Ds_unidade.Trim() + "|";

                SpedFiscal.AppendLine(reg0190);
                Qtd_linha++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0190", Qtd_linha = cont });
        }

        //Identificacao dos itens(produtos e servicos)
        private static void GerarRegistro0200(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ItensNota().Select(Cd_empresa, Dt_ini, Dt_fin).ForEach(p =>
                {
                    string reg0200 = "|0200|";
                    //Codigo Item
                    reg0200 += p.Cd_produto.Trim() + "|";
                    //Descricao Item
                    reg0200 += p.Ds_produto.Trim() + "|";
                    //Codigo Barras
                    reg0200 += "|";
                    //Codigo Anterior
                    reg0200 += "|";
                    //Unidade Estoque
                    reg0200 += p.Cd_unidade.Trim() + "|";
                    //Tipo Item
                    reg0200 += p.Tp_item.Trim() + "|";
                    //NCM
                    reg0200 += p.Ncm.Trim() + "|";
                    //Codigo EX
                    reg0200 += "|";
                    //Codigo do Genero
                    reg0200 += (p.Id_genero.HasValue ? p.Id_genero.Value.ToString() : string.Empty) + "|";
                    //Codigo Servico
                    reg0200 += p.Id_tpservico.Trim().Replace(".","") + "|";
                    //Aliquota ICMS
                    reg0200 += "|";

                    SpedFiscal.AppendLine(reg0200);
                    Qtd_linha++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0200", Qtd_linha = cont });
        }

        //Natureza da Operacao
        private static void GerarRegistro0400(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_MovComercial().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "c.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when c.tp_movimento = 'S' then c.dt_emissao else c.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when c.tp_movimento = 'S' then c.dt_emissao else c.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                {
                    string reg0400 = "|0400|";
                    //Codigo CFOP
                    reg0400 += p.Cd_movimentacao.Value.ToString().Trim() + "|";
                    //Descricao
                    reg0400 += p.Ds_movimentacao.Trim() + "|";

                    SpedFiscal.AppendLine(reg0400);
                    Qtd_linha++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0400", Qtd_linha = cont });
        }

        //Dados Complementares
        private static void GerarRegistro0450(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DadosAdicionais().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                {
                    string reg0450 = "|0450|";
                    //Codigo
                    reg0450 += p.Cd_dadosadicionais.Trim() + "|";
                    //Descricao
                    reg0450 += p.Ds_dadosadicionais.Replace('\r', ' ').Replace('\n', ' ').Trim() + "|";

                    SpedFiscal.AppendLine(reg0450);
                    Qtd_linha++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0450", Qtd_linha = cont });
        }
        //Plano Contas Contabeis
        private static void GerarRegistro0500(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_PlanoContas().Select(Cd_empresa, Dt_ini, Dt_fin).ForEach(p =>
            {
                string reg0500 = "|0500|";
                //Data Inclusão/Alteração conta
                reg0500 += p.Dt_alt.Value.ToString("dd/MM/yyyy").SoNumero() + "|";
                //Codigo natureza da conta
                reg0500 += p.Tp_contasped + "|";
                //Indicador tipo conta
                reg0500 += p.Tp_conta + "|";
                //Nivel
                reg0500 += p.Nivelconta + "|";
                //Codigo Conta
                reg0500 += p.Cd_conta_CTB + "|";
                //Nome Conta
                reg0500 += (p.Ds_contaCTB.Trim().Length > 60 ? p.Ds_contaCTB.Substring(0, 60) : p.Ds_contaCTB.Trim()) + "|";
                //Referencia
                reg0500 += p.Cd_referencia.Trim() + "|";
                //CNPJ Estabelecimento
                reg0500 += "|";

                SpedFiscal.AppendLine(reg0500);
                Qtd_linha++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0500", Qtd_linha = cont });
        }
        //Encerramento do Bloco
        private static void GerarRegistro0990(StringBuilder SpedFiscal)
        {
            string reg0990 = "|0990|";
            Qtd_linha++;
            reg0990 += Qtd_linha.ToString() + "|";

            SpedFiscal.AppendLine(reg0990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0990", Qtd_linha = 1 });
        }

        private static void GerarBloco0(TRegistro_DadosEmpresa rEmpresa,
                                        string Finalidade,
                                        string Nr_recibo,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal)
        {
            //Gerar Registro 0000
            GerarRegistro0000(rEmpresa, Finalidade, Nr_recibo, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0001
            GerarRegistro0001(SpedFiscal);
            //Gerar Registro 0100
            GerarRegistro0100(rEmpresa, SpedFiscal);
            //Gerar Registro 0110
            GerarRegistro0110(rEmpresa, SpedFiscal);
            //Gerar Registro 0140
            GerarRegistro0140(rEmpresa, SpedFiscal);
            //Gerar Registro 0150
            GerarRegistro0150(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0190
            GerarRegistro0190(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0200
            GerarRegistro0200(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0400
            GerarRegistro0400(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0450
            GerarRegistro0450(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0500
            GerarRegistro0500(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro 0990
            GerarRegistro0990(SpedFiscal);
        }
        #endregion

        #region Bloco A
        private static void GerarRegistroA001(bool St_movimento,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linhaA = decimal.Zero;
            string regA001 = "|A001|";
            //Indicador de movimento 0-com dados 1-sem dados
            regA001 += (St_movimento ? "0" : "1") + "|";

            SpedFiscal.AppendLine(regA001);
            Qtd_linhaA++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A001", Qtd_linha = 1 });
        }

        private static void GerarRegistroA010(TRegistro_DadosEmpresa rEmpresa,
                                              StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
            {
                //Texto Fixo
                string regA010 = "|A010|";
                //Cnpj da Empresa
                regA010 += rEmpresa.Nr_cnpj.SoNumero() + "|";

                SpedFiscal.AppendLine(regA010);
                Qtd_linhaA++;


                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A010", Qtd_linha = 1 });
            }
            else
                throw new Exception("Obrigatorio selecionar empresa para gerar arquivo.");
        }

        private static void GerarRegistroA100(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lFat,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lFat.ForEach(p =>
                    {
                        //Texto Fixo
                        string regA100 = "|A100|";
                        //Tipo Operacao
                        regA100 += p.Tp_movimento.Trim().ToUpper().Equals("E") ? "0|" : "1|";
                        //Emitente da Nota
                        regA100 += p.Tp_nota.Trim().ToUpper().Equals("P") ? "0|" : "1|";
                        //clifor
                        regA100 += p.St_registro.Trim().ToUpper().Equals("A") ? p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|" : "|";
                        //Situacao da Nota
                        regA100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                        //Serie 
                        regA100 += p.Nr_serie.Trim() + "|";
                        //Sub Serie
                        regA100 += "|";
                        //Numero nota
                        regA100 += p.Nr_notafiscal.ToString() + "|";
                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem = null;
                        if (p.St_registro.Trim().ToUpper().Equals("A"))
                        {
                            //Buscar item da nota
                            lItem = Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa,
                                                                                         p.Nr_lanctofiscalstr,
                                                                                         string.Empty,
                                                                                         null);
                            //Chave Acesso NFSe
                            regA100 += p.Chave_acesso_nfe.Trim() + "|";
                            //Data emissao
                            regA100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                            //Data execucao servico
                            regA100 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                            //Valor nota
                            regA100 += p.Vl_totalnota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Tipo de Pagamento
                            regA100 += (string.IsNullOrEmpty(p.Cd_condpgto) ? "9" : p.Qtd_Parcelas > 0 ? "1" : "0") + "|";
                            //Valor Desconto
                            regA100 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Base Calc PIS
                            regA100 += lItem.Sum(v=> v.Vl_basecalcPIS).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', '.') + "|";
                            //Valor PIS
                            regA100 += lItem.Sum(v=> v.Vl_pis).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Base Calc COFINS
                            regA100 += lItem.Sum(v=> v.Vl_basecalcCofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Valor COFINS
                            regA100 += lItem.Sum(v=> v.Vl_cofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Valor PIS Retido
                            regA100 += lItem.Sum(v=> v.Vl_retidoPIS).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Valor COFINS Retido
                            regA100 += lItem.Sum(v=> v.Vl_retidoCofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Valor ISS
                            regA100 += lItem.Sum(v=> v.Vl_issretido).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                            
                        }
                        else
                            regA100 += "|||||||||||||";
                        SpedFiscal.AppendLine(regA100);
                        Qtd_linhaA++;
                        cont++;

                        if(p.St_registro.Trim().ToUpper().Equals("A"))
                        {
                            //Registros Filhos
                            //Informacao Complementar
                            GerarRegistroA110(p, SpedFiscal);
                            //Itens do Documento Fiscal
                            GerarRegistroA170(lItem, SpedFiscal);
                        }
                    });
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A100", Qtd_linha = cont });
        }

        private static void GerarRegistroA110(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DadosAdicionais().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rNf.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_lanctofiscal",
                        vOperador = "=",
                        vVL_Busca = rNf.Nr_lanctofiscal.ToString()
                    }
                }).ForEach(p =>
                {
                    string regA110 = "|A110|";
                    //Codigo
                    regA110 += p.Cd_dadosadicionais.Trim() + "|";
                    //Descricao
                    regA110 += p.Ds_dadosadicionais.Trim() + "|";

                    SpedFiscal.AppendLine(regA110);
                    Qtd_linhaA++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A110", Qtd_linha = cont });
        }

        private static void GerarRegistroA170(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            //Buscar Itens da Nota
            lItem.ForEach(p =>
            {
                if (string.IsNullOrWhiteSpace(p.Cd_ST_PIS))
                    throw new Exception("Documento Fiscal Nº " + p.Nr_notafiscal.ToString() + " não possui imposto PIS.");
                if (string.IsNullOrWhiteSpace(p.Cd_ST_COFINS))
                    throw new Exception("Documento Fiscal Nº " + p.Nr_notafiscal.ToString() + " não possui imposto COFINS.");
                //Texto Fixo
                string regA170 = "|A170|";
                //Codigo Item
                regA170 += p.Id_nfitem.ToString() + "|";
                //Codigo Produto/Servico
                regA170 += p.Cd_produto.Trim() + "|";
                //Descricao Produto
                regA170 += p.Ds_produto.Trim() + "|";
                //Valor Item
                regA170 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Desconto
                regA170 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Codigo da base de calculo do credito
                regA170 += p.Id_BaseCreditoPIS.HasValue ? p.Id_BaseCreditoPIS.Value.ToString() : p.Id_BaseCreditoCofins.HasValue ? p.Id_BaseCreditoCofins.Value.ToString() : string.Empty +  "|";
                //Origem do credito 0-interno 1-importacao
                regA170 += "0|";
                //Situacao Tributaria PIS
                regA170 += p.Cd_ST_PIS.Trim() + "|";
                //Base calc PIS
                regA170 += p.Vl_basecalcPIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //% Aliquota
                regA170 += p.Pc_aliquotaPIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor PIS
                regA170 += p.Vl_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Situacao Tributaria COFINS
                regA170 += p.Cd_ST_COFINS.Trim() + "|";
                //Base calc COFINS
                regA170 += p.Vl_basecalcCofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //% Aliquota
                regA170 += p.Pc_aliquotaCofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor COFINS
                regA170 += p.Vl_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Conta Contabil
                regA170 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.Value.ToString() : string.Empty) + "|";
                //Centro Resultado
                regA170 += "|";

                SpedFiscal.AppendLine(regA170);
                Qtd_linhaA++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A170", Qtd_linha = cont });
        }

        private static void GerarRegistroA990(StringBuilder SpedFiscal)
        {
            string regA990 = "|A990|";
            Qtd_linhaA++;
            regA990 += Qtd_linhaA.ToString() + "|";

            SpedFiscal.AppendLine(regA990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "A990", Qtd_linha = 1 });
        }

        private static void GerarBlocoA(TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal)
        {
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lFat =
            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "e.tp_serie",
                        vOperador = "=",
                        vVL_Busca = "'S'"//Somente NF de Serviço
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty);
            //Gerar Registro A001
            GerarRegistroA001(lFat.Count > 0, SpedFiscal);
            if (lFat.Count > 0)
            {
                //Gerar Registro A010
                GerarRegistroA010(rEmpresa, SpedFiscal);
                //Gerar Registro A100
                GerarRegistroA100(lFat, SpedFiscal);
            }
            //Gerar Registro A990
            GerarRegistroA990(SpedFiscal);
        }
        #endregion

        #region Bloco C
        //Abertura do Bloco C
        private static void GerarRegistroC001(StringBuilder SpedFiscal)
        {
            Qtd_linhaC = decimal.Zero;
            string regC001 = "|C001|";
            regC001 += "0|"; //Registro com dados Movimentados

            SpedFiscal.AppendLine(regC001);
            Qtd_linhaC++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C001", Qtd_linha = 1 });
        }

        //Identificacao do Estabelecimento
        private static void GerarRegistroC010(TRegistro_DadosEmpresa rEmpresa,
                                              StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
            {
                //Texto Fixo
                string regC010 = "|C010|";
                //CNPJ da Empresa
                regC010 += rEmpresa.Nr_cnpj.Trim().SoNumero() + "|";
                //Indicador da apuração das contribuições
                regC010 += "1|";

                SpedFiscal.AppendLine(regC010);
                Qtd_linhaC++;

                RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "C010", Qtd_linha = 1 });
            }
            else
                throw new Exception("Obrigatorio selecionar empresa para gerar arquivo.");
        }

        //Registro C100
        private static void GerarRegistroC100(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "e.tp_serie",
                        vOperador = "<>",
                        vVL_Busca = "'S'"//Notas de Servicos - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "in",
                        vVL_Busca = "('01', '1B', '04', '55')"
                    },
                    new TpBusca()
                    {
                         vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                         vOperador = "=",
                         vVL_Busca = "'S'"
                    }
                }, 0, string.Empty).ForEach(p =>
                {
                    //Texto Fixo
                    string regC100 = "|C100|";
                    //Tipo de Movimento
                    regC100 += (p.Tp_movimento.Trim().ToUpper().Equals("E") ? "0" : "1") + "|";
                    //Tipo Nota
                    regC100 += (p.Tp_nota.Trim().ToUpper().Equals("P") ? "0" : "1") + "|";
                    //Codigo Clifor
                    regC100 += p.St_registro.Trim().ToUpper().Equals("C") ? "|" : p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Modelo da Nota
                    regC100 += p.Cd_modelo.Trim() + "|";
                    //Codigo Situacao Documento
                    regC100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : p.rCmi.St_complementarbool ? "06" : "00") + "|";
                    //Serie Documento
                    regC100 += p.Nr_serie.Trim() + "|";
                    //Numero do Documento
                    regC100 += p.Nr_notafiscal.ToString().Length > 9 ?
                        p.Nr_notafiscal.ToString().Substring(p.Nr_notafiscal.ToString().Length - 9, 9) + "|" :
                        p.Nr_notafiscal.ToString() + "|";
                    //Chave NFe
                    regC100 += p.Chave_acesso_nfe.Trim() + "|";
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem = null;
                    if (p.St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Buscar itens NF
                        lItem = Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa,
                                                                                     p.Nr_lanctofiscalstr,
                                                                                     string.Empty,
                                                                                     null);
                        //Data Emissao
                        regC100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                        //Data Entrada/Saida
                        regC100 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                        //Valor da Nota
                        regC100 += p.Vl_totalnota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo de Pagamento
                        regC100 += (string.IsNullOrEmpty(p.Cd_condpgto) ? "2" : p.Qtd_Parcelas > 0 ? "1" : "0") + "|";
                        //Valor Desconto
                        regC100 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Abatimento nao tributado
                        regC100 += "|";
                        //Valor total produtos/servicos
                        regC100 += p.Vl_totalProdutosServicos.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo Frete
                        regC100 += p.Freteporconta.Trim() + "|";
                        //Valor Frete
                        regC100 += p.Vl_frete.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //valor seguro
                        regC100 += p.Vl_seguro.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Outras Despesas
                        regC100 += p.Vl_outrasdesp.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc ICMS
                        regC100 += lItem.Sum(v=> v.Vl_basecalcICMS).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regC100 += lItem.Sum(v=> v.Vl_icms).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc Subst
                        regC100 += lItem.Sum(v=> v.Vl_basecalcSTICMS).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS Subst
                        regC100 += lItem.Sum(v=> v.Vl_ICMSST).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor IPI
                        regC100 += lItem.Sum(v=> v.Vl_ipi).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor PIS
                        regC100 += lItem.Sum(v=> v.Vl_pis).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor COFINS
                        regC100 += lItem.Sum(v=> v.Vl_cofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor PIS Subst
                        regC100 += "|";
                        //Valor COFINS Subst
                        regC100 += "|";

                        
                    }
                    else
                        regC100 += "||||||||||||||||||||";
                    SpedFiscal.AppendLine(regC100);
                    Qtd_linhaC++;
                    cont++;

                    if(p.St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Registros Filhos
                        //Informacao Complementar
                        GerarRegistroC110(p, SpedFiscal);
                        //Itens do Documento Fiscal
                        GerarRegistroC170(lItem, p.Cd_movimentacaostring, SpedFiscal);
                    }
                });
            //Cupom Fiscal Eletronico
            new TCD_NFCe().Select(rEmpresa.Cd_empresa, Dt_ini.Value, Dt_fin.Value).ForEach(p =>
                {
                    //Texto Fixo
                    string regC100 = "|C100|";
                    //Movimento
                    regC100 += "1|";//Saida
                    //Tipo Nota
                    regC100 += "0|";//Propria
                    //Cliente
                    regC100 += "|";//NFC-e omitir cliente
                    //Modelo documento fiscal
                    regC100 += p.Cd_modelo.Trim() + "|";
                    //Codigo Situacao Documento
                    regC100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                    //Serie Documento
                    regC100 += p.Nr_serie.Trim() + "|";
                    //Numero do Documento
                    regC100 += p.Id_coo_ecf.ToString().Length > 9 ?
                        p.Id_coo_ecf.ToString().Substring(p.Id_coo_ecf.ToString().Length - 9, 9) + "|" :
                        p.Id_coo_ecf.ToString() + "|";
                    //Chave NFe
                    regC100 += p.Chave_acesso.Trim() + "|";
                    if (p.St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Data Emissao
                        regC100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                        //Data Entrada/Saida
                        regC100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                        //Valor da Nota
                        regC100 += p.Vl_cupom.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo de Pagamento
                        regC100 += "0|";
                        //Valor Desconto
                        regC100 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Abatimento nao tributado
                        regC100 += "|";
                        //Valor total produtos/servicos
                        regC100 += p.Vl_itens.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo Frete
                        regC100 += "9|";
                        //Valor Frete
                        regC100 += "|";
                        //valor seguro
                        regC100 += "|";
                        //Valor Outras Despesas
                        regC100 += p.Vl_outrasdesp.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc ICMS
                        regC100 += p.Vl_basecalcicms.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regC100 += p.Vl_icms.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc Subst
                        regC100 += "|";
                        //Valor ICMS Subst
                        regC100 += "|";
                        //Valor IPI
                        regC100 += "|";
                        //Valor PIS
                        regC100 += p.Vl_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor COFINS
                        regC100 += p.Vl_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor PIS Subst
                        regC100 += "|";
                        //Valor COFINS Subst
                        regC100 += "|";
                    }
                    else
                        regC100 += "||||||||||||||||||||";
                    SpedFiscal.AppendLine(regC100);
                    Qtd_linhaC++;
                    cont++;
                    if (p.St_registro.Trim().ToUpper().Equals("A"))
                        //Registros Filhos C175
                        GerarRegistroC175(rEmpresa.Cd_empresa, p.Id_cupom.Value.ToString(), SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C100", Qtd_linha = cont });
        }

        //Registro C110
        private static void GerarRegistroC110(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DadosAdicionais().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rNf.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_lanctofiscal",
                        vOperador = "=",
                        vVL_Busca = rNf.Nr_lanctofiscal.ToString()
                    }
                }).ForEach(p =>
                {
                    string regC110 = "|C110|";
                    //Codigo
                    regC110 += p.Cd_dadosadicionais.Trim() + "|";
                    //Descricao
                    regC110 += p.Ds_dadosadicionais.Trim() + "|";

                    SpedFiscal.AppendLine(regC110);
                    Qtd_linhaC++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C110", Qtd_linha = cont });
        }

        //Registro C170
        private static void GerarRegistroC170(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem, 
                                              string Cd_movimentacao,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            //Buscar Itens da Nota
            lItem.ForEach(p =>
                   {
                       //Texto Fixo
                       string regC170 = "|C170|";
                       //Codigo Item
                       regC170 += p.Id_nfitem.ToString() + "|";
                       //Codigo Produto/Servico
                       regC170 += p.Cd_produto.Trim() + "|";
                       //Descricao Produto
                       regC170 += p.Ds_produto.Trim() + "|";
                       //Quantidade Item
                       regC170 += p.Quantidade.ToString("N5").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                       //Unidade Valor
                       regC170 += p.Cd_unidade.Trim() + "|";
                       //Valor Item
                       regC170 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                       //Valor Desconto
                       regC170 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                       //Movimentacao Fisica Produto
                       regC170 += (p.St_movEstoque ? "0" : "1") + "|";
                       //Situacao Tributaria ICMS
                       regC170 += p.Cd_ST_ICMS.Trim().PadLeft(3, '0') + "|";
                       //CFOP
                       regC170 += p.Cd_cfop.Trim() + "|";
                       //Natureza Operacao
                       regC170 += Cd_movimentacao + "|";
                       //Valor Base Calc ICMS
                       regC170 += (p.Vl_basecalcICMS > decimal.Zero ? p.Vl_basecalcICMS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Aliquota ICMS
                       regC170 += (p.Pc_aliquotaICMS > decimal.Zero ? p.Pc_aliquotaICMS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Valor ICMS
                       regC170 += (p.Vl_icms > decimal.Zero ? p.Vl_icms.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Valor Base Calc Subst
                       regC170 += (p.Vl_basecalcSTICMS > decimal.Zero ? p.Vl_basecalcSTICMS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Aliquota ICMS Subst
                       regC170 += (p.Pc_aliquotaSTICMS > decimal.Zero ? p.Pc_aliquotaSTICMS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Valor ICMS Subst
                       regC170 += (p.Vl_ICMSST > decimal.Zero ? p.Vl_ICMSST.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Indicador do periodo de apuracao do IPI
                       regC170 += "0|";
                       //Situacao Tributaria IPI
                       regC170 += p.Cd_ST_IPI.Trim() + "|";
                       //Codigo enquadramento IPI, deixar em branco
                       regC170 += "|";
                       //Valor Base Calc IPI
                       regC170 += (p.Vl_basecalcIPI > decimal.Zero ? p.Vl_basecalcIPI.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Aliquota IPI
                       regC170 += (p.Pc_aliquotaIPI > decimal.Zero ? p.Pc_aliquotaIPI.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Valor IPI
                       regC170 += (p.Vl_ipi > decimal.Zero ? p.Vl_ipi.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //situacao tributaria PIS
                       regC170 += p.Cd_ST_PIS.Trim() + "|";
                       //Valor Base Calc. PIS
                       regC170 += (p.Vl_basecalcPIS > decimal.Zero ? p.Vl_basecalcPIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Aliquota PIS
                       regC170 += (p.Pc_aliquotaPIS > decimal.Zero ? p.Pc_aliquotaPIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Base Calc PIS Quantidade
                       regC170 += "|";
                       //Aliquota PIS R$
                       regC170 += "|";
                       //Valor PIS
                       regC170 += (p.Vl_pis > decimal.Zero ? p.Vl_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Situacao Tributaria COFINS
                       regC170 += p.Cd_ST_COFINS.Trim() + "|";
                       //Valor Base Calc. COFINS
                       regC170 += (p.Vl_basecalcCofins > decimal.Zero ? p.Vl_basecalcCofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Aliquota COFINS
                       regC170 += (p.Pc_aliquotaCofins > decimal.Zero ? p.Pc_aliquotaCofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Base Calc. COFINS Quantidade
                       regC170 += "|";
                       //Aliquota COFINS R$
                       regC170 += "|";
                       //Valor COFINS
                       regC170 += (p.Vl_cofins > decimal.Zero ? p.Vl_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') : string.Empty) + "|";
                       //Conta Contabil Debitada/Creditada
                       regC170 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                       SpedFiscal.AppendLine(regC170);
                       Qtd_linhaC++;
                       cont++;
                   });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C170", Qtd_linha = cont });
        }

        //Registro C175
        private static void GerarRegistroC175(string Cd_empresa,
                                              string Id_cupom,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetNFCe().Select(Cd_empresa, Id_cupom).ForEach(p =>
                {
                    //Texto Fixo
                    string regC175 = "|C175|";
                    //CFOP
                    regC175 += p.Cd_cfop.Trim() + "|";
                    //Valor Operacao
                    regC175 += p.Vl_operacao.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Desconto
                    regC175 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //CST PIS
                    regC175 += p.Cd_st_pis.Trim() + "|";
                    //Base Calc PIS
                    regC175 += p.Vl_basecalc_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota PIS
                    regC175 += p.Pc_aliquota_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Qtde PIS
                    regC175 += "|";
                    //Aliquota Qtde PIS
                    regC175 += "|";
                    //Valor PIS
                    regC175 += p.Vl_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //CST Cofins
                    regC175 += p.Cd_st_cofins.Trim() + "|";
                    //Base Calc Cofins
                    regC175 += p.Vl_basecalc_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota Cofins
                    regC175 += p.Pc_aliquota_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Qtde Cofins
                    regC175 += "|";
                    //Aliquota Qtde Cofins
                    regC175 += "|";
                    //Valor Cofins
                    regC175 += p.Vl_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regC175 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";
                    //Inf. Complementares
                    regC175 += "|";

                    SpedFiscal.AppendLine(regC175);
                    Qtd_linhaC++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C175", Qtd_linha = cont });
        }

        //Registro C180
        private static void GerarRegistroC180(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ConsVendaPIS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(d.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }).ForEach(p =>
                    {
                        //Texto Fixo
                        string regC180 = "|C180|";
                        //Modelo Documento
                        regC180 += "55|";
                        //Data Inicial
                        regC180 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
                        //Data Final
                        regC180 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
                        //Codigo Produto
                        regC180 += p.Cd_produto.Trim() + "|";
                        //NCM
                        regC180 += p.Ncm.Trim() + "|";
                        //Codigo TIPI
                        regC180 += "|";
                        //Valor total item
                        regC180 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                        SpedFiscal.AppendLine(regC180);
                        Qtd_linhaC++;
                        cont++;
                        
                        //Gerar Registro C181
                        GerarRegistroC181(rEmpresa.Cd_empresa, p.Cd_produto, Dt_ini, Dt_fin, SpedFiscal);
                        //Gerar Registro C185
                        GerarRegistroC185(rEmpresa.Cd_empresa, p.Cd_produto, Dt_ini, Dt_fin, SpedFiscal);
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C180", Qtd_linha = cont });
        }

        //Registro C181
        private static void GerarRegistroC181(string Cd_empresa,
                                              string Cd_produto,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetVendaPIS().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(c.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_produto.Trim() + "'"
                    }
                }).ForEach(p =>
                    {
                        //Texto Fixo
                        string regC181 = "|C181|";
                        //Situacao Tributaria
                        regC181 += p.Cd_st.Trim() + "|";
                        //CFOP
                        regC181 += p.Cd_cfop.Trim() + "|";
                        //Valor do Item
                        regC181 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor desconto
                        regC181 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calculo
                        regC181 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Aliquota
                        regC181 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calculo Quantidade
                        regC181 += "|";
                        //Aliquota em Valor
                        regC181 += "|";
                        //Valor Imposto
                        regC181 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Conta Contabil
                        regC181 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                        SpedFiscal.AppendLine(regC181);
                        Qtd_linhaC++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C181", Qtd_linha = cont });
        }

        //Registro C185
        private static void GerarRegistroC185(string Cd_empresa,
                                              string Cd_produto,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetVendaCOFINS().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(c.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_produto.Trim() + "'"
                    }
                }).ForEach(p =>
                    {
                        //Texto Fixo
                        string regC185 = "|C185|";
                        //Situacao Tributaria
                        regC185 += p.Cd_st.Trim() + "|";
                        //CFOP
                        regC185 += p.Cd_cfop.Trim() + "|";
                        //Valor Item
                        regC185 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Desconto
                        regC185 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calculo
                        regC185 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //% Aliquota
                        regC185 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calc Quantidade
                        regC185 += "|";
                        //Aliquota Valor
                        regC185 += "|";
                        //Valor Imposto
                        regC185 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Conta Contabil
                        regC185 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                        SpedFiscal.AppendLine(regC185);
                        Qtd_linhaC++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C185", Qtd_linha = cont });
        }

        //Registro C190
        private static void GerarRegistroC190(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ConsVendaCOFINS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(d.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }).ForEach(p =>
                {
                    //Texto Fixo
                    string regC190 = "|C190|";
                    //Modelo Documento
                    regC190 += "55|";
                    //Data Inicial
                    regC190 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
                    //Data Final
                    regC190 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
                    //Codigo Produto
                    regC190 += p.Cd_produto.Trim() + "|";
                    //NCM
                    regC190 += p.Ncm.Trim() + "|";
                    //Codigo TIPI
                    regC190 += "|";
                    //Valor total item
                    regC190 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(regC190);
                    Qtd_linhaC++;
                    cont++;

                    //Gerar Registro C191
                    GerarRegistroC191(rEmpresa.Cd_empresa, p.Cd_produto, Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Registro C195
                    GerarRegistroC195(rEmpresa.Cd_empresa, p.Cd_produto, Dt_ini, Dt_fin, SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C190", Qtd_linha = cont });
        }

        //Registro C191
        private static void GerarRegistroC191(string Cd_empresa,
                                              string Cd_produto,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetCompraPIS().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(d.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_produto.Trim() + "'"
                    }
                }).ForEach(p =>
                {
                    //Texto Fixo
                    string regC191 = "|C191|";
                    //CNPJ/CPF do Clifor
                    regC191 += p.Cnpj_cpf.SoNumero() + "|";
                    //Situacao Tributaria
                    regC191 += p.Cd_st.Trim() + "|";
                    //CFOP
                    regC191 += p.Cd_cfop.Trim() + "|";
                    //Valor do Item
                    regC191 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor desconto
                    regC191 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Base Calculo
                    regC191 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Aliquota
                    regC191 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calculo Quantidade
                    regC191 += "|";
                    //Aliquota em Valor
                    regC191 += "|";
                    //Valor Imposto
                    regC191 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regC191 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                    SpedFiscal.AppendLine(regC191);
                    Qtd_linhaC++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C191", Qtd_linha = cont });
        }

        //Registro C195
        private static void GerarRegistroC195(string Cd_empresa,
                                              string Cd_produto,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetCompraCOFINS().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(d.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_produto.Trim() + "'"
                    }
                }).ForEach(p =>
                {
                    //Texto Fixo
                    string regC195 = "|C195|";
                    //Cnpj/Cpf do clifor
                    regC195 += p.Cnpj_cpf.SoNumero() + "|";
                    //Situacao Tributaria
                    regC195 += p.Cd_st.Trim() + "|";
                    //CFOP
                    regC195 += p.Cd_cfop.Trim() + "|";
                    //Valor Item
                    regC195 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Desconto
                    regC195 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calculo
                    regC195 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //% Aliquota
                    regC195 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calc Quantidade
                    regC195 += "|";
                    //Aliquota Valor
                    regC195 += "|";
                    //Valor Imposto
                    regC195 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regC195 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                    SpedFiscal.AppendLine(regC195);
                    Qtd_linhaC++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C195", Qtd_linha = cont });
        }

        //Registro C490
        private static void GerarRegistroC490(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            //Texto Fixo
            string regC490 = "|C490|";
            //Data Inicial
            regC490 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
            //Data Final
            regC490 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
            //Modelo Fiscal
            regC490 += rEmpresa.Cd_modelo_ecf.Trim() + "|";

            SpedFiscal.AppendLine(regC490);
            Qtd_linhaC++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C490", Qtd_linha = 1 });

            //Gerar Registro C491
            GerarRegistroC491(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro C495
            GerarRegistroC495(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
        }

        //Registro C491
        private static void GerarRegistroC491(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetECFPIS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(b.ST_Registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }).ForEach(p =>
                    {
                        //Texto Fixo
                        string regC491 = "|C491|";
                        //Codigo Produto
                        regC491 += p.Cd_produto.Trim() + "|";
                        //Situacao Tributaria
                        regC491 += p.Cd_st.Trim() + "|";
                        //CFOP
                        regC491 += p.Cd_cfop.Trim() + "|";
                        //Valor Item
                        regC491 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calculo
                        regC491 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //% Aliquota
                        regC491 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Quantidade
                        regC491 += "|";
                        //Aliquota Valor
                        regC491 += "|";
                        //Valor Imposto
                        regC491 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Conta Contabil
                        regC491 += "|";

                        SpedFiscal.AppendLine(regC491);
                        Qtd_linhaC++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C491", Qtd_linha = cont });
        }

        //Registro C495
        private static void GerarRegistroC495(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetECFCofins().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(b.ST_Registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }).ForEach(p =>
                {
                    //Texto Fixo
                    string regC495 = "|C495|";
                    //Codigo Produto
                    regC495 += p.Cd_produto.Trim() + "|";
                    //Situacao Tributaria
                    regC495 += p.Cd_st.Trim() + "|";
                    //CFOP
                    regC495 += p.Cd_cfop.Trim() + "|";
                    //Valor Item
                    regC495 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calculo
                    regC495 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //% Aliquota
                    regC495 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Quantidade
                    regC495 += "|";
                    //Aliquota Valor
                    regC495 += "|";
                    //Valor Imposto
                    regC495 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regC495 += "|";

                    SpedFiscal.AppendLine(regC495);
                    Qtd_linhaC++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C495", Qtd_linha = cont });
        }

        //Registro C500
        private static void GerarRegistroC500(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "in",
                        vVL_Busca = "('06', '29', '28')"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty).ForEach(p =>
                {
                    //Buscar itens NF
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem =
                        Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa,
                                                                             p.Nr_lanctofiscalstr,
                                                                             string.Empty,
                                                                             null);
                    string regC500 = "|C500|";
                    //Codigo do Clifor
                    regC500 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Modelo Documento Fiscal
                    regC500 += p.Cd_modelo.Trim() + "|";
                    //Situacao do Documento
                    regC500 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                    //Serie do Documento
                    regC500 += p.Nr_serie.Trim() + "|";
                    //SubSerie do Documento
                    regC500 += "|";
                    //Numero do Documento
                    regC500 += p.Nr_notafiscal.ToString() + "|";
                    //Data Emissao
                    regC500 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                    //Data Entrada/Saida
                    regC500 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                    //Valor do Documento
                    regC500 += p.Vl_totalnota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS
                    regC500 += lItem.Sum(v=> v.Vl_icms).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Codigo dados adicionais
                    if (!string.IsNullOrEmpty(p.Dadosadicionais))
                        regC500 += "000001|";
                    else
                        regC500 += "|";
                    //Valor PIS
                    regC500 += lItem.Sum(v=> v.Vl_pis).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor COFINS
                    regC500 += lItem.Sum(v=> v.Vl_cofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(regC500);
                    Qtd_linhaC++;
                    cont++;

                    //Gerar Registro C501
                    GerarRegistroC501(lItem, SpedFiscal);
                    //Gerar Registro C505
                    GerarRegistroC505(lItem, SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C500", Qtd_linha = cont });
        }

        private static void GerarRegistroC501(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lItem.ForEach(p =>
            {
                if (string.IsNullOrWhiteSpace(p.Cd_ST_PIS))
                    throw new Exception("Documento Fiscal Nº " + p.Nr_notafiscal.ToString() + " não possui imposto PIS.");
                //Texto Fixo
                string regC501 = "|C501|";
                //Situacao Tributaria
                regC501 += p.Cd_ST_PIS.Trim() + "|";
                //Valor Item
                regC501 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Natureza do Credito
                regC501 += p.Id_BaseCreditoPIS.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                //Base Calculo
                regC501 += p.Vl_basecalcPIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //% Aliquota
                regC501 += p.Pc_aliquotaPIS.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Imposto
                regC501 += p.Vl_pis.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Conta Contabil
                regC501 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                SpedFiscal.AppendLine(regC501);
                Qtd_linhaC++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C501", Qtd_linha = cont });
        }

        private static void GerarRegistroC505(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lItem.ForEach(p =>
            {
                if(string.IsNullOrWhiteSpace(p.Cd_ST_COFINS))
                    throw new Exception("Documento Fiscal Nº " + p.Nr_notafiscal.ToString() + " não possui imposto COFINS.");
                //Texto Fixo
                string regC505 = "|C505|";
                //Situacao Tributaria
                regC505 += p.Cd_ST_COFINS.Trim() + "|";
                //Valor Item
                regC505 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Natureza do Credito
                regC505 += p.Id_BaseCreditoCofins.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                //Base Calculo
                regC505 += p.Vl_basecalcCofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //% Aliquota
                regC505 += p.Pc_aliquotaCofins.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Imposto
                regC505 += p.Vl_cofins.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Conta Contabil
            regC505 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                SpedFiscal.AppendLine(regC505);
                Qtd_linhaC++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C505", Qtd_linha = cont });
        }

        //Registro C990
        private static void GerarRegistroC990(StringBuilder SpedFiscal)
        {
            string regC990 = "|C990|";
            Qtd_linhaC++;
            regC990 += Qtd_linhaC.ToString() + "|";

            SpedFiscal.AppendLine(regC990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C990", Qtd_linha = 1 });
        }
        
        private static void GerarBlocoC(TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal)
        {
            //Gerar Registro C001
            GerarRegistroC001(SpedFiscal);
            //Gerar Registro C010
            GerarRegistroC010(rEmpresa, SpedFiscal);
            //Gerar Registro C100
            GerarRegistroC100(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro C180
            GerarRegistroC180(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro C190
            GerarRegistroC190(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            if (new CamadaDados.Faturamento.PDV.TCD_NFCe_Item().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "nf.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(cf.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "<>",
                        vVL_Busca = "'65'"//NFC-e
                    }
                }, "1") != null)
                //Gerar Registro C490
                GerarRegistroC490(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro C500
            GerarRegistroC500(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro C990
            GerarRegistroC990(SpedFiscal);
        }
        #endregion

        #region Bloco D
        //Abertura do Bloco D
        private static void GerarRegistroD001(bool St_movimento,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linhaD = decimal.Zero;
            string regD001 = "|D001|";
            //Indicador de movimento 0-com dados 1-sem dados
            regD001 += (St_movimento ? "0" : "1") + "|";

            SpedFiscal.AppendLine(regD001);
            Qtd_linhaD++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D001", Qtd_linha = 1 });
        }

        private static void GerarRegistroD010(TRegistro_DadosEmpresa rEmpresa,
                                              StringBuilder SpedFiscal)
        {
            if (rEmpresa != null)
            {
                //Texto Fixo
                string regD010 = "|D010|";
                //Cnpj da Empresa
                regD010 += rEmpresa.Nr_cnpj.SoNumero() + "|";

                SpedFiscal.AppendLine(regD010);
                Qtd_linhaD++;


                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D010", Qtd_linha = 1 });
            }
            else
                throw new Exception("Obrigatorio selecionar empresa para gerar arquivo.");
        }

        private static void GerarRegistroD100(List<CamadaDados.Fiscal.SPED_FISCAL.TRegistro_NFServicos> lCTR,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lCTR.ForEach(p =>
                {
                    string regD100 = "|D100|";
                    //Tipo Operacao
                    regD100 += "0|";//Aquisicao
                    //Emitente do documento
                    regD100 += p.Tp_nota.Trim().ToUpper().Equals("P") ? "0|" : "1|";
                    //Codigo do clifor
                    regD100 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Modelo Fiscal
                    regD100 += p.Cd_modelo.Trim() + "|";
                    //Status documento
                    regD100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                    //Serie do documento
                    regD100 += p.Nr_serie.Trim() + "|";
                    //SubSerie do documento
                    regD100 += p.Nr_subserie.Trim() + "|";
                    //Numero do documento
                    regD100 += p.Nr_notafiscal.Value.ToString() + "|";
                    //Chave acesso
                    regD100 += p.Chave_acesso.Trim() + "|";
                    //Data emissao
                    regD100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                    //Data Sai/Ent
                    regD100 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                    //Tipo CTe
                    regD100 += p.Tp_cte.Trim() + "|";
                    //Chave acesso CTe referencia
                    regD100 += p.Chave_cte_refenciado.Trim() + "|";
                    //Valor total do documento
                    regD100 += p.Vl_totalnota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor descontos
                    if (p.Vl_desconto > decimal.Zero)
                        regD100 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Tipo frete
                    regD100 += p.Freteporconta.Trim() + "|";
                    //Valor servicos
                    regD100 += p.Vl_totalservico.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Base Calc ICMS
                    if (p.Vl_basecalcicms > decimal.Zero)
                        regD100 += p.Vl_basecalcicms.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Valor ICMS
                    if (p.Vl_icms > decimal.Zero)
                        regD100 += p.Vl_icms.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Valor nao tributado
                    if (p.Vl_naotributado > decimal.Zero)
                        regD100 += p.Vl_naotributado.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Codigo informacao complementar
                    regD100 += "|";
                    //Codigo conta analitica
                    regD100 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                    SpedFiscal.AppendLine(regD100);
                    Qtd_linhaD++;
                    cont++;

                    //Gerar Registro D101
                    GerarRegistroD101(p.Cd_empresa, p.Nr_lancto.ToString(), p.Tp_registro, SpedFiscal);
                    //Gerar Registro D105
                    GerarRegistroD105(p.Cd_empresa, p.Nr_lancto.ToString(), p.Tp_registro, SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D100", Qtd_linha = cont });
        }

        private static void GerarRegistroD101(string Cd_empresa,
                                              string Nr_lancto,
                                              string Tp_registro,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetCTRPIS().Select(Cd_empresa, Nr_lancto, Tp_registro).ForEach(p =>
                {
                    //Texto Fixo
                    string regD101 = "|D101|";
                    //Indicador da natureza do frete contratado
                    regD101 += p.Tp_movimento.Trim().ToUpper().Equals("S") ?
                        p.Tp_frete.Trim().Equals("1") ? "0|" : "1|" : "2|";
                    //Valor do item
                    regD101 += p.Vl_item.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Situacao Tributaria
                    regD101 += p.Cd_st.Trim() + "|";
                    //Codigo Base Calculo
                    regD101 += p.Id_basecreditoPIS.Trim().FormatStringEsquerda(2, '0') + "|";
                    //Base Calculo
                    regD101 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota 
                    regD101 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor PIS
                    regD101 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regD101 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                    SpedFiscal.AppendLine(regD101);
                    Qtd_linhaD++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D101", Qtd_linha = cont });
        }

        private static void GerarRegistroD105(string Cd_empresa,
                                              string Nr_lancto,
                                              string Tp_registro,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetCTRCofins().Select(Cd_empresa, Nr_lancto, Tp_registro).ForEach(p =>
            {
                //Texto Fixo
                string regD105 = "|D105|";
                //Indicador da natureza do frete contratado
                regD105 += p.Tp_movimento.Trim().ToUpper().Equals("S") ?
                    p.Tp_frete.Trim().Equals("1") ? "0|" : "1|" : "2|";
                //Valor do item
                regD105 += p.Vl_item.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Situacao Tributaria
                regD105 += p.Cd_st.Trim() + "|";
                //Codigo Base Calculo
                regD105 += p.Id_basecreditoCOFINS.Trim().FormatStringEsquerda(2, '0') + "|";
                //Base Calculo
                regD105 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Aliquota 
                regD105 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor PIS
                regD105 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Conta Contabil
                regD105 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                SpedFiscal.AppendLine(regD105);
                Qtd_linhaD++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D105", Qtd_linha = cont });
        }

        private static void GerarRegistroD500(CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lNf.ForEach(p =>
                {
                    //Buscar itens NF
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItem =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa,
                                                                                           p.Nr_lanctofiscalstr,
                                                                                           string.Empty,
                                                                                           null);
                    string regD500 = "|D500|";
                    //Tipo Movimento
                    regD500 += p.Tp_movimento.Trim().ToUpper().Equals("E") ? "0|" : "1|";
                    //Emitente do documento
                    regD500 += p.Tp_nota.Trim().ToUpper().Equals("P") ? "0|" : "1|";
                    //Codigo Cliente
                    regD500 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Codigo Modelo
                    regD500 += p.Cd_modelo.Trim() + "|";
                    //Status do documento
                    regD500 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                    //Serie do documento
                    regD500 += p.Nr_serie.Trim() + "|";
                    //SubSerie do documento
                    regD500 += "|";
                    //Numero documento
                    regD500 += (p.Nr_notafiscal.ToString().Length > 9 ?
                                p.Nr_notafiscal.ToString().Substring(p.Nr_notafiscal.ToString().Length - 9, 9) :
                                p.Nr_notafiscal.ToString()) + "|";
                    //Data Emissao
                    regD500 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                    //Data SaiEnt
                    regD500 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                    //Valor documento
                    regD500 += p.Vl_totalnota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor desconto
                    if (p.Vl_desconto > 0)
                        regD500 += p.Vl_desconto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD500 += "|";
                    //Valor servicos
                    regD500 += p.Vl_totalProdutosServicos.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor servicos isento
                    if ((p.Vl_totalProdutosServicos - lItem.Sum(v=> v.Vl_icms)) > 0)
                        regD500 += (p.Vl_totalProdutosServicos - lItem.Sum(v=> v.Vl_icms)).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD500 += "|";
                    //valor cobrado em nome terceiro
                    regD500 += "|";
                    //Valor outras despesas
                    regD500 += p.Vl_outrasdesp.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor base calc icms
                    regD500 += lItem.Sum(v=> v.Vl_basecalcICMS).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS
                    regD500 += lItem.Sum(v=> v.Vl_icms).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Informacao complementar
                    if (!string.IsNullOrEmpty(p.Dadosadicionais))
                        regD500 += "000001|";
                    else
                        regD500 += "|";
                    //valor PIS
                    if (lItem.Sum(v=> v.Vl_pis) > decimal.Zero)
                        regD500 += lItem.Sum(v=> v.Vl_pis).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD500 += "|";
                    //Valor COFINS
                    if (lItem.Sum(v=> v.Vl_cofins) > decimal.Zero)
                        regD500 += lItem.Sum(v=> v.Vl_cofins).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD500 += "|";
                    
                    SpedFiscal.AppendLine(regD500);
                    Qtd_linhaD++;
                    cont++;

                    //Registro D501
                    GerarRegistroD501(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), SpedFiscal);
                    //Registro D505
                    GerarRegistroD505(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D500", Qtd_linha = cont });
        }

        private static void GerarRegistroD501(string Cd_empresa,
                                              string Nr_lancto,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetComPIS().Select(Cd_empresa, Nr_lancto).ForEach(p =>
                {
                    //Texto Fixo
                    string regD501 = "|D501|";
                    //Situacao Tributaria
                    regD501 += p.Cd_st.Trim() + "|";
                    //Valor Item
                    regD501 += p.Vl_item.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Natureza Base Credito
                    regD501 += (p.Tp_basecalc.HasValue ? p.Tp_basecalc.Value.ToString().FormatStringEsquerda(2, '0') : string.Empty) + "|";
                    //Base Calc
                    regD501 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota PIS
                    regD501 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Imposto
                    regD501 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta contabil
                    regD501 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                    SpedFiscal.AppendLine(regD501);
                    Qtd_linhaD++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D501", Qtd_linha = cont });
        }

        private static void GerarRegistroD505(string Cd_empresa,
                                              string Nr_lancto,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_DetComCOFINS().Select(Cd_empresa, Nr_lancto).ForEach(p =>
            {
                //Texto Fixo
                string regD505 = "|D505|";
                //Situacao Tributaria
                regD505 += p.Cd_st.Trim() + "|";
                //Valor Item
                regD505 += p.Vl_item.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Natureza Base Credito
                regD505 += (p.Tp_basecalc.HasValue ? p.Tp_basecalc.ToString().FormatStringEsquerda(2, '0') : string.Empty) + "|";
                //Base Calc
                regD505 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Aliquota PIS
                regD505 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Imposto
                regD505 += p.Vl_imposto.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Conta contabil
                regD505 += (p.Cd_contactb_sped.HasValue ? p.Cd_contactb_sped.ToString() : string.Empty) + "|";

                SpedFiscal.AppendLine(regD505);
                Qtd_linhaD++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D505", Qtd_linha = cont });
        }

        private static void GerarRegistroD990(StringBuilder SpedFiscal)
        {
            string regD990 = "|D990|";
            Qtd_linhaD++;
            regD990 += Qtd_linhaD.ToString() + "|";

            SpedFiscal.AppendLine(regD990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D990", Qtd_linha = 1 });
        }

        private static void GerarBlocoD(TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal)
        {
            //Dados Frete
            List<CamadaDados.Fiscal.SPED_FISCAL.TRegistro_NFServicos> lCTRC =
            new CamadaDados.Fiscal.SPED_FISCAL.TCD_NFServicos().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                });
            //Dados Servicos Telecomunicacao
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNFCom =
            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = ">=",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "in",
                        vVL_Busca = "('21', '22')"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_serie",
                        vOperador = "<>",
                        vVL_Busca = "'F'"//Nota Servico - Bloco A
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty);
            //Gerar Registro D001
            GerarRegistroD001((lCTRC.Count > 0) || (lNFCom.Count > 0), SpedFiscal);
            if ((lCTRC.Count > 0) || (lNFCom.Count > 0))
                //Gerar Registro D010
                GerarRegistroD010(rEmpresa, SpedFiscal);
            if(lCTRC.Count > 0)
                //Gerar Registro D100
                GerarRegistroD100(lCTRC, SpedFiscal);
            if(lNFCom.Count > 0)
                //Gerar Registro D500
                GerarRegistroD500(lNFCom, SpedFiscal);
            //Gerar Registro D990
            GerarRegistroD990(SpedFiscal);

        }
        #endregion

        #region Bloco F
        private static void GerarRegistroF001(bool St_movimento,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linhaF = decimal.Zero;
            string regF001 = "|F001|";
            //Indicador de movimento 0-com dados 1-sem dados
            regF001 += (St_movimento ? "0" : "1") + "|";

            SpedFiscal.AppendLine(regF001);
            Qtd_linhaF++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "F001", Qtd_linha = 1 });
        }

        public static void GerarRegistroF990(StringBuilder SpedFiscal)
        {
            string regF990 = "|F990|";
            Qtd_linhaF++;
            regF990 += Qtd_linhaF.ToString() + "|";

            SpedFiscal.AppendLine(regF990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "F990", Qtd_linha = 1 });
        }

        public static void GerarBlocoF(TRegistro_DadosEmpresa rEmpresa,
                                       DateTime? Dt_ini,
                                       DateTime? Dt_fin,
                                       StringBuilder SpedFiscal)
        {
            //Gerar registro F001
            GerarRegistroF001(false, SpedFiscal);
            //Gerar Registro F990
            GerarRegistroF990(SpedFiscal);
        }
        #endregion

        #region Bloco M
        private static void GerarRegistroM001(bool St_movimento,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linhaM = decimal.Zero;
            string regM001 = "|M001|";
            //Indicador de movimento 0-com dados 1-sem dados
            regM001 += (St_movimento ? "0" : "1") + "|";

            SpedFiscal.AppendLine(regM001);
            Qtd_linhaM++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M001", Qtd_linha = 1 });
        }

        private static decimal GerarRegistroM100(List<TRegistro_CreditoPIS> lCredPIS,
                                                 decimal Vl_contribuicao,
                                                 TRegistro_DadosEmpresa rEmpresa,
                                                 DateTime? Dt_ini,
                                                 DateTime? Dt_fin,
                                                 StringBuilder SpedFiscal)
        {
            decimal tot_credUtilizado = decimal.Zero;
            decimal vl_credUtilizado = decimal.Zero;
            decimal cont = decimal.Zero;
            lCredPIS.ForEach(p =>
                    {
                        if (!p.Tp_cred.HasValue)
                            throw new Exception("Existe movimentação gerando credito PIS sem informar valor no campo Tipo Credito.");
                        if (Vl_contribuicao > p.Vl_PIS)
                            vl_credUtilizado = p.Vl_PIS;
                        else
                            vl_credUtilizado = Vl_contribuicao;
                        tot_credUtilizado += vl_credUtilizado;
                        Vl_contribuicao -= vl_credUtilizado;
                        //Campo Fixo
                        string regM100 = "|M100|";
                        //Tipo Credito
                        regM100 += p.Tp_cred.Value.ToString().FormatStringEsquerda(3, '0') + "|";
                        //Indicador origem credito
                        regM100 += "0|";//0-Operacao propria 1-incorporacao, cisao, fusao
                        //Valor Base Calc
                        regM100 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Aliquota PIS
                        regM100 += p.Pc_aliquota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calc Qtde
                        regM100 += "|";
                        //Aliquota PIS em Valor
                        regM100 += "|";
                        //Valor Imposto
                        regM100 += p.Vl_PIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Ajustes Credito
                        regM100 += "0|";
                        //Valor Ajustes Reducao Cred
                        regM100 += "0|";
                        //Valor Diferido
                        regM100 += "0|";
                        //Valor Credito Disponivel
                        regM100 += p.Vl_PIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Indicador utilizacao credito
                        regM100 += p.Vl_PIS - vl_credUtilizado > decimal.Zero ? "1|" : "0|";//0-Utilizacao valor total 1-Utilizacao parcial
                        //Valor Credito Disponivel
                        regM100 += vl_credUtilizado.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Saldo Credito
                        regM100 += (p.Vl_PIS - vl_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                        SpedFiscal.AppendLine(regM100);
                        Qtd_linhaM++;
                        cont++;

                        //Registro M105
                        GerarRegistroM105(rEmpresa,
                                          Dt_ini,
                                          Dt_fin,
                                          p.Tp_cred.Value.ToString(),
                                          SpedFiscal);
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M100", Qtd_linha = cont });
            return tot_credUtilizado;
        }

        private static void GerarRegistroM105(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              string Id_tpcred,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_BaseCalcCred().Select(
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
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(c.ST_GerarSpedPisCofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.Id_TpCredPIS",
                        vOperador = "=",
                        vVL_Busca = Id_tpcred
                    }
                }).ForEach(p =>
                    {
                        if (!p.Id_basecredito.HasValue)
                            throw new Exception("Existe movimentação sem BASE DE CREDITO.\r\n" + 
                                                "Verifique a parametrização e reprocesse os documentos fiscais.");
                        string regM105 = "|M105|";
                        //Codigo Base Calc
                        regM105 += p.Id_basecredito.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                        //Situacao Tributaria
                        regM105 += p.Cd_st.Trim() + "|";
                        //Valor Base Calc
                        regM105 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Parcela Valor Base Calc. Campo regimo cumulativo e nao-cumulativo
                        regM105 += "|";
                        //Valor total base calc
                        regM105 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor base calc vinculada ao tipo de credito
                        regM105 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Qtde Base calc
                        regM105 += "|";
                        //Parcela Qtde Base Calc
                        regM105 += "|";
                        //Descricao Credito
                        regM105 += "|";

                        SpedFiscal.AppendLine(regM105);
                        Qtd_linhaM++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M105", Qtd_linha = cont });
        }

        private static void GerarRegistroM200(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              decimal Vl_contribuicao,
                                              decimal Tot_credUtilizado,
                                              StringBuilder SpedFiscal)
        {
            string regM200 = "|M200|";
            //Valor Contribuicao apurada
            regM200 += Vl_contribuicao.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor do credito descontado no periodo
            regM200 += Tot_credUtilizado.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Credito descontado em periodo anterior
            regM200 += "0|";
            //Valor Total Contribuicao nao cumulativa
            regM200 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor retido na fonte
            regM200 += "0|";
            //Outras deducoes no periodo
            regM200 += "0|";
            //Valor da contribuicao nao cumulativa a recolher
            regM200 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor total contribuicao cumulativa periodo
            regM200 += "0|";
            //Valor retido na fonte
            regM200 += "0|";
            //Outras deducoes periodo
            regM200 += "0|";
            //Valor contribuicao cumulativa recolher
            regM200 += "0|";
            //Valor total contribuicao a recolher
            regM200 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

            SpedFiscal.AppendLine(regM200);
            Qtd_linhaM++;

            //Gerar registro M210
            if (Vl_contribuicao > decimal.Zero)
            {
                if(Vl_contribuicao - Tot_credUtilizado > decimal.Zero)
                    GerarRegistroM205(rEmpresa, Dt_ini, Dt_fin, Tot_credUtilizado, SpedFiscal);
                GerarRegistroM210(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            }

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M200", Qtd_linha = 1 });
        }

        public static void GerarRegistroM205(TRegistro_DadosEmpresa rEmpresa,
                                             DateTime? Dt_ini,
                                             DateTime? Dt_fin,
                                             decimal Tot_credUtilizado,
                                             StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ReceitaPIS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                    {
                        if (!p.Id_receita.HasValue)
                            throw new Exception("Existe movimentação tributada de PIS sem CODIGO DE RECEITA.\r\n" +
                                                "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                        string regM205 = "|M205|";
                        //Numero do campo do registro M200
                        regM205 += "08|";//Contribuição não cumulativa
                        //Codigo da receita
                        regM205 += p.Id_receita.Value.ToString() + "|";
                        //Valor do debito
                        regM205 += (p.Vl_debito - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                        SpedFiscal.AppendLine(regM205);
                        Qtd_linhaM++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M205", Qtd_linha = cont });
        }

        private static void GerarRegistroM210(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ContribuicaoPIS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                    {
                        if (!p.Id_tpcontribuicao.HasValue)
                            throw new Exception("Existe movimentação sem TIPO DE CONTRIBUIÇÃO.\r\n" +
                                                "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                        string regM210 = "|M210|";
                        //Codigo contribuicao social
                        regM210 += p.Id_tpcontribuicao.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                        //Valor receita bruta
                        regM210 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor base calculo
                        regM210 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ajustes acrescimo da base de calculo
                        regM210 += "0|";
                        //Valor ajustes redução da base de calculo
                        regM210 += "0|";
                        //Valor base de calculo apos ajustes
                        regM210 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Aliquota PIS
                        regM210 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Qtde
                        regM210 += "|";
                        //Aliquota Valor
                        regM210 += "|";
                        //Valor Contribuicao
                        regM210 += p.Vl_PIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ajustes
                        regM210 += "0|";
                        //Valor reducao
                        regM210 += "0|";
                        //Valor diferido
                        regM210 += "0|";
                        //Valor diferido periodos anteriores
                        regM210 += "0|";
                        //Valor total contribuicao
                        regM210 += p.Vl_PIS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                        SpedFiscal.AppendLine(regM210);
                        Qtd_linhaM++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M210", Qtd_linha = cont });
        }

        private static void GerarRegistroM400(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            List<TRegistro_ReceitasIsentasPIS> lRegistro =
            new TCD_ReceitasIsentasPIS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                });
            lRegistro.GroupBy(p=> new { p.Cd_st, p.Cd_conta_ctb },
                (aux, reg)=>
                    new
                    {
                        cd_st = aux.Cd_st,
                        cd_conta_ctb = aux.Cd_conta_ctb,
                        Vl_receita = reg.Sum(x=> x.Vl_Receita)
                    }).ToList().ForEach(p =>
                    {
                        string regM400 = "|M400|";
                        //Situacao Tributaria
                        regM400 += p.cd_st.Trim() + "|";
                        //Valor Receita
                        regM400 += p.Vl_receita.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Conta Contabil
                        regM400 += p.cd_conta_ctb + "|";
                        //Descricao complementar
                        regM400 += "|";

                        SpedFiscal.AppendLine(regM400);
                        Qtd_linhaM++;
                        cont++;

                        //Registro M410
                        GerarRegistroM410(rEmpresa, lRegistro.Where(x=> x.Cd_st.Trim().Equals(p.cd_st.Trim()) && x.Cd_conta_ctb.Equals(p.cd_conta_ctb)).ToList(), SpedFiscal);
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M400", Qtd_linha = cont });
        }

        private static void GerarRegistroM410(TRegistro_DadosEmpresa rEmpresa,
                                              List<TRegistro_ReceitasIsentasPIS> lRegistro,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lRegistro.GroupBy(p=> new { p.Id_detrecIsenta, p.Cd_conta_ctb },
                (aux, reg)=>
                    new
                    {
                        Id_detrecisenta = aux.Id_detrecIsenta,
                        Cd_conta_ctb = aux.Cd_conta_ctb,
                        Vl_receita = reg.Sum(x=> x.Vl_Receita)
                    }).ToList().ForEach(p =>
                    {
                        if (!p.Id_detrecisenta.HasValue)
                            throw new Exception("Existe movimentação sem NATUREZA DA RECEITA ISENTA.\r\n" + 
                                                "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                        string regM410 = "|M410|";
                        //Detalhe receita isenta
                        regM410 += p.Id_detrecisenta.Value.ToString().FormatStringEsquerda(3, '0') + "|";
                        //Valor receita
                        regM410 += p.Vl_receita.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Conta Contabil
                        regM410 += p.Cd_conta_ctb + "|";
                        //Complemento
                        regM410 += "|";

                        SpedFiscal.AppendLine(regM410);
                        Qtd_linhaM++;
                        cont++;
                    });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M410", Qtd_linha = cont });
        }

        private static decimal GerarRegistroM500(List<TRegistro_CreditoCOFINS> lCredCOFINS,
                                                 decimal Vl_contribuicao,
                                                 TRegistro_DadosEmpresa rEmpresa,
                                                 DateTime? Dt_ini,
                                                 DateTime? Dt_fin,
                                                 StringBuilder SpedFiscal)
        {
            decimal tot_credUtilizado = decimal.Zero;
            decimal vl_credUtilizado = decimal.Zero;
            decimal cont = decimal.Zero;
            lCredCOFINS.ForEach(p =>
            {
                if (!p.Tp_cred.HasValue)
                    throw new Exception("Existe movimentação gerando credito COFINS sem informar valor no campo Tipo Credito.");
                if (Vl_contribuicao > p.Vl_COFINS)
                    vl_credUtilizado = p.Vl_COFINS;
                else
                    vl_credUtilizado = Vl_contribuicao;
                tot_credUtilizado += vl_credUtilizado;
                Vl_contribuicao -= vl_credUtilizado;
                string regM500 = "|M500|";
                //Tipo Credito
                regM500 += p.Tp_cred.Value.ToString().FormatStringEsquerda(3, '0') + "|";
                //Indicador origem credito
                regM500 += "0|";//0-Operacao propria 1-incorporacao, cisao, fusao
                //Valor Base Calc
                regM500 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Aliquota PIS
                regM500 += p.Pc_aliquota.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Base Calc Qtde
                regM500 += "|";
                //Aliquota PIS em Valor
                regM500 += "|";
                //Valor Imposto
                regM500 += p.Vl_COFINS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Ajustes Credito
                regM500 += "0|";
                //Valor Ajustes Reducao Cred
                regM500 += "0|";
                //Valor Diferido
                regM500 += "0|";
                //Valor Credito Disponivel
                regM500 += p.Vl_COFINS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Indicador utilizacao credito
                regM500 += p.Vl_COFINS - vl_credUtilizado > decimal.Zero ? "1|" : "0|";//0-Utilizacao valor total 1-Utilizacao parcial
                //Valor Credito Disponivel
                regM500 += vl_credUtilizado.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Saldo Credito
                regM500 += (p.Vl_COFINS - vl_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                SpedFiscal.AppendLine(regM500);
                Qtd_linhaM++;
                cont++;

                //Registro M505
                GerarRegistroM505(rEmpresa,
                                  Dt_ini,
                                  Dt_fin,
                                  p.Tp_cred.Value.ToString(),
                                  SpedFiscal);
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M500", Qtd_linha = cont });
            return tot_credUtilizado;
        }

        private static void GerarRegistroM505(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              string Id_tpcred,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_BaseCalcCredCOFINS().Select(
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
                        vNM_Campo = "a.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(c.ST_GerarSpedPisCofins, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.Id_TpCredCofins",
                        vOperador = "=",
                        vVL_Busca = Id_tpcred
                    }
                }).ForEach(p =>
                {
                    if (!p.Id_basecredito.HasValue)
                        throw new Exception("Existe movimentação sem BASE CREDITO COFINS.\r\n" +
                                            "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                    string regM505 = "|M505|";
                    //Codigo Base Calc
                    regM505 += p.Id_basecredito.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                    //Situacao Tributaria
                    regM505 += p.Cd_st.Trim() + "|";
                    //Valor Base Calc
                    regM505 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Parcela Valor Base Calc. Campo regimo cumulativo e nao-cumulativo
                    regM505 += "|";
                    //Valor total base calc
                    regM505 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor base calc vinculada ao tipo de credito
                    regM505 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Qtde Base calc
                    regM505 += "|";
                    //Parcela Qtde Base Calc
                    regM505 += "|";
                    //Descricao Credito
                    regM505 += "|";

                    SpedFiscal.AppendLine(regM505);
                    Qtd_linhaM++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M505", Qtd_linha = cont });
        }

        private static void GerarRegistroM600(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              decimal Vl_contribuicao,
                                              decimal Tot_credUtilizado,
                                              StringBuilder SpedFiscal)
        {
            string regM600 = "|M600|";
            //Valor Contribuicao apurada
            regM600 += Vl_contribuicao.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor do credito descontado no periodo
            regM600 += Tot_credUtilizado.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Credito descontado em periodo anterior
            regM600 += "0|";
            //Valor Total Contribuicao nao cumulativa
            regM600 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor retido na fonte
            regM600 += "0|";
            //Outras deducoes no periodo
            regM600 += "0|";
            //Valor da contribuicao nao cumulativa a recolher
            regM600 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor total contribuicao cumulativa periodo
            regM600 += "0|";
            //Valor retido na fonte
            regM600 += "0|";
            //Outras deducoes periodo
            regM600 += "0|";
            //Valor contribuicao cumulativa recolher
            regM600 += "0|";
            //Valor total contribuicao a recolher
            regM600 += (Vl_contribuicao - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

            SpedFiscal.AppendLine(regM600);
            Qtd_linhaM++;

            //Gerar registro M210
            if (Vl_contribuicao > decimal.Zero)
            {
                if(Vl_contribuicao - Tot_credUtilizado > decimal.Zero)
                    GerarRegistroM605(rEmpresa, Dt_ini, Dt_fin, Tot_credUtilizado, SpedFiscal);
                GerarRegistroM610(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            }

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M600", Qtd_linha = 1 });
        }

        private static void GerarRegistroM605(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              decimal Tot_credUtilizado,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ReceitaCOFINS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                {
                    if (!p.Id_receita.HasValue)
                        throw new Exception("Existe movimentação tributada de PIS sem CODIGO DE RECEITA.\r\n" +
                                            "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                    string regM605 = "|M605|";
                    //Numero do campo do registro M600
                    regM605 += "08|";//Contribuição não cumulativa
                    //Codigo da receita
                    regM605 += p.Id_receita.Value.ToString() + "|";
                    //Valor do debito
                    regM605 += (p.Vl_debito - Tot_credUtilizado).ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(regM605);
                    Qtd_linhaM++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M605", Qtd_linha = cont });
        }

        private static void GerarRegistroM610(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_ContribuicaoCOFINS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                }).ForEach(p =>
                {
                    if (!p.Id_tpcontribuicao.HasValue)
                        throw new Exception("Existe movimentação sem TIPO CONTRIBUIÇÃO PARA O COFINS.\r\n" +
                                            "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                    string regM610 = "|M610|";
                    //Codigo contribuicao social
                    regM610 += p.Id_tpcontribuicao.Value.ToString().FormatStringEsquerda(2, '0') + "|";
                    //Valor receita bruta
                    regM610 += p.Vl_subtotal.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor base calculo
                    regM610 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor acrescimo base de calculo
                    regM610 += "0|";
                    //Valor reducao base de calculo
                    regM610 += "0|";
                    //Valor base calculo ajustada
                    regM610 += p.Vl_basecalc.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota PIS
                    regM610 += p.Pc_aliquota.ToString("N4").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Qtde
                    regM610 += "|";
                    //Aliquota Valor
                    regM610 += "|";
                    //Valor Contribuicao
                    regM610 += p.Vl_COFINS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ajustes
                    regM610 += "0|";
                    //Valor reducao
                    regM610 += "0|";
                    //Valor diferido
                    regM610 += "0|";
                    //Valor diferido periodos anteriores
                    regM610 += "0|";
                    //Valor total contribuicao
                    regM610 += p.Vl_COFINS.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(regM610);
                    Qtd_linhaM++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M610", Qtd_linha = cont });
        }

        private static void GerarRegistroM800(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            List<TRegistro_ReceitasIsentasCOFINS> lRegistro =
            new TCD_ReceitasIsentasCOFINS().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "between",
                        vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                    }
                });
            lRegistro.GroupBy(p=> new { p.Cd_st, p.Cd_conta_ctb }, 
                (aux, reg)=>
                new
                    {
                        Cd_st = aux.Cd_st,
                        Cd_conta_ctb = aux.Cd_conta_ctb,
                        Vl_receita = reg.Sum(x=> x.Vl_Receita)
                    }).ToList().ForEach(p =>
                {
                    string regM800 = "|M800|";
                    //Situacao Tributaria
                    regM800 += p.Cd_st.Trim() + "|";
                    //Valor Receita
                    regM800 += p.Vl_receita.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Conta Contabil
                    regM800 += p.Cd_conta_ctb + "|";
                    //Descricao complementar
                    regM800 += "|";

                    SpedFiscal.AppendLine(regM800);
                    Qtd_linhaM++;
                    cont++;

                    //Registro M810
                    GerarRegistroM810(rEmpresa, lRegistro.Where(x=> x.Cd_st.Trim().Equals(p.Cd_st.Trim()) && x.Cd_conta_ctb.Equals(p.Cd_conta_ctb)).ToList(), SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M800", Qtd_linha = cont });
        }

        private static void GerarRegistroM810(TRegistro_DadosEmpresa rEmpresa,
                                              List<TRegistro_ReceitasIsentasCOFINS> lRegistro,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lRegistro.GroupBy(p=> new { p.Id_detrecIsenta, p.Cd_conta_ctb },
                (aux, reg)=>
                    new
                    {
                        Id_detrecisenta = aux.Id_detrecIsenta,
                        Cd_conta_ctb = aux.Cd_conta_ctb,
                        Vl_receita = reg.Sum(x=> x.Vl_Receita)
                    }).ToList().ForEach(p =>
                        {
                            if (!p.Id_detrecisenta.HasValue)
                                throw new Exception("Existe movimentação sem NATUREZA RECEITA ISENTA DO COFINS.\r\n" +
                                                    "Verifique os parametros fiscais e reprocesse os documentos fiscais.");
                            string regM810 = "|M810|";
                            //Detalhe receita isenta
                            regM810 += p.Id_detrecisenta.Value.ToString().FormatStringEsquerda(3, '0') + "|";
                            //Valor receita
                            regM810 += p.Vl_receita.ToString("N2").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                            //Conta Contabil
                            regM810 += p.Cd_conta_ctb + "|";
                            //Complemento
                            regM810 += "|";

                            SpedFiscal.AppendLine(regM810);
                            Qtd_linhaM++;
                            cont++;
                        });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M810", Qtd_linha = cont });
        }

        private static void GerarRegistroM990(StringBuilder SpedFiscal)
        {
            string regM990 = "|M990|";
            Qtd_linhaM++;
            regM990 += Qtd_linhaM.ToString() + "|";

            SpedFiscal.AppendLine(regM990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "M990", Qtd_linha = 1 });
        }

        public static void GerarBlocoM(TRegistro_DadosEmpresa rEmpresa,
                                       DateTime? Dt_ini,
                                       DateTime? Dt_fin,
                                       StringBuilder SpedFiscal)
        {
            //Gerar Registro M001
            GerarRegistroM001(Qtd_linhaA > decimal.Zero ||
                              Qtd_linhaC > decimal.Zero ||
                              Qtd_linhaD > decimal.Zero ||
                              Qtd_linhaF > decimal.Zero, SpedFiscal);
            #region PIS
            //Gerar Registro M100
            List<TRegistro_CreditoPIS> lCredPIS =
                new TCD_CreditoPIS().Select(
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
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                            vOperador = "between",
                            vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(c.ST_GerarSpedPisCofins, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "b.Pc_aliquotaPIS",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    });
            //Buscar Contribuicao Apurada no Periodo
            decimal Vl_PIS = decimal.Zero;
            object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nf.dt_emissao)))",
                                    vOperador = "between",
                                    vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(nf.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.cd_modelo",
                                    vOperador = "in",
                                    vVL_Busca = "('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Cd_St_pis",
                                    vOperador = "not in",
                                    vVL_Busca = "('04', '05', '06', '07', '08', '09')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fis_movimentacao x " +
                                                "where x.cd_movimentacao = nf.cd_movimentacao " +
                                                "and isnull(x.st_gerarspedpiscofins, 'N') = 'S')"
                                }
                            }, "isnull(sum(isnull(a.Vl_pis, 0)), 0)");
            Vl_PIS = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            obj = new CamadaDados.Faturamento.PDV.TCD_NFCe_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "nfce.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nfce.dt_emissao)))",
                            vOperador = "between",
                            vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nfce.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.Cd_St_pis",
                            vOperador = "not in",
                            vVL_Busca = "('04', '05', '06', '07', '08', '09')"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_lote_x_nfce x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_nfce " +
                                        "and x.status in('100', '150'))"
                        }
                    }, "isnull(sum(isnull(a.vl_pis, 0)), 0)");
            Vl_PIS += obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            decimal tot_credUtilizadoPIS = GerarRegistroM100(lCredPIS, Vl_PIS, rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro M200
            GerarRegistroM200(rEmpresa, Dt_ini, Dt_fin, Vl_PIS, tot_credUtilizadoPIS, SpedFiscal);
            //Gerar Registro M400
            GerarRegistroM400(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            #endregion

            #region COFINS
            //Gerar Registro M500
            List<TRegistro_CreditoCOFINS> lCredCOFINS =
                new TCD_CreditoCOFINS().Select(
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
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))",
                            vOperador = "between",
                            vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(c.ST_GerarSpedPisCofins, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "b.pc_aliquotacofins",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    });
            //Buscar Contribuicao Apurada no Periodo
            decimal VL_COFINS = decimal.Zero;
            obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nf.dt_emissao)))",
                                    vOperador = "between",
                                    vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(nf.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.cd_modelo",
                                    vOperador = "in",
                                    vVL_Busca = "('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Cd_St_cofins",
                                    vOperador = "not in",
                                    vVL_Busca = "('04', '05', '06', '07', '08', '09')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fis_movimentacao x " +
                                                "where x.cd_movimentacao = nf.cd_movimentacao " +
                                                "and isnull(x.st_gerarspedpiscofins, 'N') = 'S')"
                                }
                            }, "isnull(sum(isnull(a.vl_cofins, 0)), 0)");
            VL_COFINS = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            obj = new CamadaDados.Faturamento.PDV.TCD_NFCe_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "nfce.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nfce.dt_emissao)))",
                            vOperador = "between",
                            vVL_Busca = "'" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nfce.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.Cd_St_cofins",
                            vOperador = "not in",
                            vVL_Busca = "('04', '05', '06', '07', '08', '09')"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_lote_x_nfce x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_nfce " +
                                        "and x.status in('100', '150'))"
                        }
                    }, "isnull(sum(isnull(a.Vl_Cofins, 0)), 0)");
            VL_COFINS += obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
            decimal tot_credUtilizadoCOFINS = GerarRegistroM500(lCredCOFINS, VL_COFINS, rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            //Gerar Registro M600
            GerarRegistroM600(rEmpresa, Dt_ini, Dt_fin, VL_COFINS, tot_credUtilizadoCOFINS, SpedFiscal); 
            //Gerar Registro M800
            GerarRegistroM800(rEmpresa, Dt_ini, Dt_fin, SpedFiscal);
            #endregion
            //Gerar Registro M990
            GerarRegistroM990(SpedFiscal);
        }
        #endregion

        #region Bloco 1
        private static void GerarRegistro1001(bool St_movimento,
                                              StringBuilder SpedFiscal)
        {
            Qtd_linha1 = decimal.Zero;
            string reg1001 = "|1001|";
            //Indicador de movimento 0-com dados 1-sem dados
            reg1001 += (St_movimento ? "0" : "1") + "|";

            SpedFiscal.AppendLine(reg1001);
            Qtd_linha1++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1001", Qtd_linha = 1 });
        }
                
        private static void GerarRegistro1990(StringBuilder SpedFiscal)
        {
            string reg1990 = "|1990|";
            Qtd_linha1++;
            reg1990 += Qtd_linha1.ToString() + "|";

            SpedFiscal.AppendLine(reg1990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1990", Qtd_linha = 1 });
        }

        public static void GerarBloco1(TRegistro_DadosEmpresa rEmpresa,
                                       DateTime? Dt_ini,
                                       DateTime? Dt_fin,
                                       StringBuilder SpedFiscal)
        {
            //Gerar Registro 1001
            GerarRegistro1001(false, SpedFiscal);
            //Gerar Registro 1990
            GerarRegistro1990(SpedFiscal);
        }
        #endregion

        #region Bloco 9
        private static void GerarRegistro9001(StringBuilder SpedFiscal)
        {
            Qtd_linha9 = decimal.Zero;
            string reg9001 = "|9001|";
            reg9001 += "0|";

            SpedFiscal.AppendLine(reg9001);
            Qtd_linha9++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9001", Qtd_linha = 1 });
        }

        private static void GerarRegistro9900(StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            string reg9900 = string.Empty;
            RegArq.ForEach(p =>
            {
                reg9900 = "|9900|";
                //Registro totalizado
                reg9900 += p.Registro.Trim() + "|";
                //Quantidade registro
                reg9900 += p.Qtd_linha.ToString("N0").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                SpedFiscal.AppendLine(reg9900);
                Qtd_linha9++;
                cont++;
            });
            Qtd_linha9 += 3;
            cont += 3;
            //Totalizar registro 9900
            reg9900 = "|9900|";
            reg9900 += "9900|";
            reg9900 += cont.ToString("N0").Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            SpedFiscal.AppendLine(reg9900);
            //Totalizar Registro 9990
            reg9900 = "|9900|";
            reg9900 += "9990|";
            reg9900 += "1|";
            SpedFiscal.AppendLine(reg9900);
            //Totalizar Registro 9999
            reg9900 = "|9900|";
            reg9900 += "9999|";
            reg9900 += "1|";
            SpedFiscal.AppendLine(reg9900);
        }

        private static void GerarRegistro9990(StringBuilder SpedFiscal)
        {
            string reg9990 = "|9990|";
            Qtd_linha9 += 2;
            reg9990 += Qtd_linha9.ToString() + "|";

            SpedFiscal.AppendLine(reg9990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9990", Qtd_linha = 1 });
        }

        private static void GerarRegistro9999(StringBuilder SpedFiscal)
        {
            string reg9999 = "|9999|";
            reg9999 += (Qtd_linha + Qtd_linha1 + Qtd_linha9 + Qtd_linhaC + Qtd_linhaD + Qtd_linhaM + Qtd_linhaA + Qtd_linhaF).ToString() + "|";
            SpedFiscal.AppendLine(reg9999);
        }

        private static void GerarBloco9(StringBuilder SpedFiscal)
        {
            GerarRegistro9001(SpedFiscal);
            GerarRegistro9900(SpedFiscal);
            GerarRegistro9990(SpedFiscal);
            GerarRegistro9999(SpedFiscal);
        }
        #endregion

        public static string ProcessarSpedFiscal(string Cd_empresa,
                                                 DateTime? Dt_ini,
                                                 DateTime? Dt_fin,
                                                 string Finalidade,
                                                 string Nr_recibo)
        {
            try
            {
                StringBuilder SpedFiscal = new StringBuilder();
                RegArq = new TList_RegArquivo();
                if (string.IsNullOrEmpty(Cd_empresa))
                    throw new Exception("Obrigatorio informar empresa.");
                if (Dt_ini == null)
                    throw new Exception("Obrigatorio informar data inicial.");
                if (Dt_fin == null)
                    throw new Exception("Obrigatorio informar data final.");
                if (string.IsNullOrEmpty(Finalidade))
                    throw new Exception("Obrigatorio informar finalidade.");
                if (Finalidade.Trim().Equals("1") && string.IsNullOrEmpty(Nr_recibo))
                    throw new Exception("Obrigatorio informar recibo para gerar arquivo de retificação.");
                //Buscar dados empresa
                List<TRegistro_DadosEmpresa> lEmpresa = new TCD_DadosEmpresa().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                                }
                                                            });
                if (lEmpresa.Count > 0)
                {
                    //Gerar Bloco 0
                    GerarBloco0(lEmpresa[0], Finalidade, Nr_recibo, Dt_ini, Dt_fin, SpedFiscal);
                    ////Gerar Bloco A
                    GerarBlocoA(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco C
                    GerarBlocoC(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco D
                    GerarBlocoD(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco F
                    GerarBlocoF(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco M
                    GerarBlocoM(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco 1
                    GerarBloco1(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal);
                    //Gerar Bloco 9
                    GerarBloco9(SpedFiscal);
                    return SpedFiscal.ToString().Trim();
                }
                else
                    throw new Exception("Não foi possivel encontrar os dados da empresa.");
            }
            catch (Exception ex)
            { throw new Exception("Erro gerar Sped Fiscal: " + ex.Message.Trim()); }
        }
    }
}
