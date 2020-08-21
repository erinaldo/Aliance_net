using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using Utils;
using CamadaDados.Fiscal.SPED_FISCAL;

namespace CamadaNegocio.Fiscal.SPED_FISCAL
{
    public class TCN_SpedFiscal
    {
        private static decimal Qtd_linha;
        private static decimal Qtd_linhaB;
        private static decimal Qtd_linhaC;
        private static decimal Qtd_linhaD;
        private static decimal Qtd_linhaE;
        private static decimal Qtd_linhaG;
        private static decimal Qtd_linhaH;
        private static decimal Qtd_linhaK;
        private static decimal Qtd_linha1;
        private static decimal Qtd_linha9;

        private static TList_RegArquivo RegArq;

        #region Bloco 0
        //Abertura do arquivo digital e identificacao da entidade
        private static void GerarRegistro0000(TRegistro_DadosEmpresa rEmpresa,
                                              string Finalidade,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0000...");
            Qtd_linha = decimal.Zero;
            if (rEmpresa != null)
            {
                //Texto Fixo
                string reg0000 = "|0000|";
                //Versao do Layout
                reg0000 += rEmpresa.LayoutSpedFiscal.Trim().FormatStringEsquerda(3, '0') + "|";
                //Finalidade do arquivo
                reg0000 += Finalidade.Trim().ToUpper().Equals("O") ? "0|" : "1|";
                //Data Inicial
                reg0000 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
                //Data Final
                reg0000 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
                //Nome da Empresa
                reg0000 += rEmpresa.Nm_empresa.Trim().RemoverCaracteres() + "|";
                //Cnpj Empresa
                reg0000 += rEmpresa.Nr_cnpj.Trim().SoNumero() + "|";
                //Cpf Empresa
                reg0000 += "|";
                //UF Empresa
                reg0000 += rEmpresa.Uf.Trim() + "|";
                //Inscricao Estadual
                reg0000 += Regex.Replace(rEmpresa.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                //Cidade Empresa
                reg0000 += rEmpresa.Cd_cidade.Trim().SoNumero() + "|";
                //Inscricao Municipal
                reg0000 += Regex.Replace(rEmpresa.Insc_municipal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                //Inscricao Suframa
                reg0000 += "|";
                //Perfil de apresentacao do arquivo
                reg0000 += rEmpresa.Tp_perfilfiscal.Trim() + "|";
                //Tipo Atividade Empresa
                reg0000 += rEmpresa.Tp_atividadespedfiscal.Trim() + "|";

                SpedFiscal.AppendLine(reg0000);
                Qtd_linha++;

                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0000", Qtd_linha = 1 });
            }
        }

        //Abertura do bloco 0
        private static void GerarRegistro0001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0001...");
            string reg0001 = "|0001|";
            reg0001 += "0|";

            SpedFiscal.AppendLine(reg0001);
            Qtd_linha++;

            RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "0001", Qtd_linha = 1 });
        }

        //Dados complementares da entidade
        private static void GerarRegistro0005(TRegistro_DadosEmpresa rEmpresa, StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0005...");
            if (rEmpresa != null)
            {
                //Texto Fixo
                string reg0005 = "|0005|";
                //Nome Fantasia Empresa
                reg0005 += rEmpresa.Nm_empresa.Trim().RemoverCaracteres() + "|";
                //CEP Empresa
                reg0005 += rEmpresa.Cep.Trim().SoNumero() + "|";
                //Endereco Empresa
                reg0005 += rEmpresa.Ds_endereco.RemoverCaracteres().Trim() + "|";
                //Numero Empresa
                reg0005 += rEmpresa.Numero.Trim() + "|";
                //Complemento Endereco
                reg0005 += rEmpresa.Ds_complemento.RemoverCaracteres().Trim() + "|";
                //Bairro
                reg0005 += rEmpresa.Bairro.RemoverCaracteres().Trim() + "|";
                //Fone
                string fone = rEmpresa.Fone.Trim().SoNumero();
                if (fone.Trim().Length > 10)
                    fone = fone.Trim().Substring(1);
                else
                    fone = fone.PadLeft(10, '0');
                reg0005 += fone + "|";
                //Fax
                reg0005 += "|";
                //Email
                reg0005 += rEmpresa.Email.Trim() + "|";

                SpedFiscal.AppendLine(reg0005);
                Qtd_linha++;

                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0005", Qtd_linha = 1 });
            }
        }

        //Dados do contabilista
        private static void GerarRegistro0100(TRegistro_DadosEmpresa rEmpresa, 
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (rEmpresa != null)
                if (!string.IsNullOrEmpty(rEmpresa.Cd_clifor_contador))
                {
                    if (tEspera != null)
                        tEspera.Msg("Gerando registro 0100...");
                    //Buscar dados Contabilista
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Contador =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rEmpresa.Cd_clifor_contador, null);
                    //Buscar endereco contador
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rEmpresa.Cd_clifor_contador,
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
                    reg0100 += Regex.Replace(Contador.Nr_cpf.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                    //CRC Contador
                    reg0100 += rEmpresa.Crc_contador.Trim() + "|";
                    //CNPJ Contador
                    reg0100 += Regex.Replace(Contador.Nr_cgc.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
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
                    reg0100 += Contador.Email.Trim() + "|";
                    //Municipio do Contador
                    reg0100 += (lEndereco.Count > 0 ? lEndereco[0].Cd_cidade.Trim().SoNumero() : string.Empty) + "|";

                    SpedFiscal.AppendLine(reg0100);
                    Qtd_linha++;

                    RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0100", Qtd_linha = 1 });
                }
                else
                    throw new Exception("Não existe contador configurado para a empresa " + rEmpresa.Cd_empresa.Trim());
        }

        //Tabela de cadastro do participante
        private static void GerarRegistro0150(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0150...");
            decimal cont = decimal.Zero;
            new TCD_CodeParticipante().Select(
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
                    vNM_Campo = "data",
                    vOperador = ">=",
                    vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                },
                new TpBusca()
                {
                    vNM_Campo = "data",
                    vOperador = "<=",
                    vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                }
            }).ForEach(p =>
                {
                    string reg0150 = "|0150|";
                    //Codigo participante no arquivo
                    reg0150 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Nome Clifor
                    reg0150 += p.Nm_clifor.Trim() + "|";
                    //Pais
                    reg0150 += p.Cd_pais.Trim() + "|";
                    //CNPJ
                    reg0150 += Regex.Replace(p.Nr_cnpj.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                    //CPF
                    reg0150 += Regex.Replace(p.Nr_cpf.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                    //Inscricao Estadual
                    reg0150 += Regex.Replace(p.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) + "|";
                    //Cidade
                    reg0150 += p.Cd_cidade.Trim().SoNumero() + "|";
                    //Suframa
                    reg0150 += "|";
                    //Endereco
                    reg0150 += p.Ds_endereco.Trim() + "|";
                    //Numero
                    reg0150 += p.Numero.Trim() + "|";
                    //Complemento
                    reg0150 += p.Ds_complemento.Trim() + "|";
                    //Bairro
                    reg0150 += p.Bairro.Trim() + "|";

                    SpedFiscal.AppendLine(reg0150);
                    Qtd_linha++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0150", Qtd_linha = cont });
        }

        //Identificacao das unidades de medida
        private static void GerarRegistro0190(string Cd_empresa,
                                              bool St_industria,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0190...");
            decimal cont = decimal.Zero;
            new TCD_CodeUnidade().Select(Cd_empresa.Trim(), St_industria, Dt_ini.Value, Dt_fin.Value).ForEach(p =>
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
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0190", Qtd_linha = cont });
        }

        //Identificacao dos itens(produtos e servicos)
        private static void GerarRegistro0200(string Cd_empresa,
                                              bool St_industria,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0200...");
            decimal cont = decimal.Zero;
            decimal cont206 = decimal.Zero;
            new TCD_CodeItensNota().Select(Cd_empresa, St_industria, Dt_ini, Dt_fin).ForEach(p =>
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
                    reg0200 += (string.IsNullOrWhiteSpace(p.Tp_item.Trim()) ? "00" : p.Tp_item.Trim()) + "|";
                    //NCM
                    reg0200 += p.Ncm.Trim() + "|";
                    //Codigo EX
                    reg0200 += "|";
                    //Codigo do Genero
                    reg0200 += (p.Id_genero.HasValue ? p.Id_genero.Value.ToString() : string.Empty) + "|";
                    //Codigo Servico
                    reg0200 += p.Id_tpservico.Trim() + "|";
                    //Aliquota ICMS
                    if (p.Pc_aliquotaicms > decimal.Zero)
                        reg0200 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        reg0200 += "|";
                    //Codigo CEST
                    reg0200 += p.CEST.Trim() + "|";
                    SpedFiscal.AppendLine(reg0200);
                    Qtd_linha++;
                    cont++;
                    //Registro 0206
                    if (!string.IsNullOrEmpty(p.Cd_anp))
                    {
                        string reg0206 = "|0206|";
                        reg0206 += p.Cd_anp.Trim() + "|";

                        SpedFiscal.AppendLine(reg0206);
                        Qtd_linha++;
                        cont206++;
                    }
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0200", Qtd_linha = cont });
            if (cont206 > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0206", Qtd_linha = cont206 });
        }

        //Fatores de conversao das unidades
        private static void GerarRegistro0220(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0220...");
            decimal cont = decimal.Zero;
            new TCD_FatorConversao().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "d.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when d.tp_movimento = 'S' then d.dt_emissao else d.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when d.tp_movimento = 'S' then d.dt_emissao else d.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }).ForEach(p =>
                {
                    string reg0220 = "|0220|";
                    //Unidade Comercial
                    reg0220 += p.Cd_unidade.Trim() + "|";
                    //Fator de conversao
                    reg0220 += p.Vl_indice.ToString("N6").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(reg0220);
                    Qtd_linha++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0220", Qtd_linha = cont });
        }

        //Natureza da Operacao
        private static void GerarRegistro0400(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0400...");
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
                        vNM_Campo = "(case when c.tp_movimento = 'S' then c.dt_emissao else c.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when c.tp_movimento = 'S' then c.dt_emissao else c.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }).ForEach(p =>
                {
                    string reg0400 = "|0400|";
                    //Codigo CFOP
                    reg0400 += p.Cd_movto.Value.ToString().Trim() + "|";
                    //Descricao
                    reg0400 += p.Ds_movimentacao.Trim().Replace("\r", "").Replace("\n", "") + "|";

                    SpedFiscal.AppendLine(reg0400);
                    Qtd_linha++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0400", Qtd_linha = cont });
        }

        //Dados Complementares
        private static void GerarRegistro0450(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0450...");
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
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }).ForEach(p =>
                {
                    string reg0450 = "|0450|";
                    //Codigo
                    reg0450 += p.Cd_dadosadicionais.Trim() + "|";
                    //Descricao
                    reg0450 += p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "").Length > 255 ? p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "").Substring(0, 255).Trim() + "|" : p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "") + "|";

                    SpedFiscal.AppendLine(reg0450);
                    Qtd_linha++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0450", Qtd_linha = cont });
        }

        //Observacao fiscal
        /*
        private static void GerarRegistro0460(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera,
                                              BancoDados.TObjetoBanco banco)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0460...");
            decimal cont = decimal.Zero;
            new CamadaDados.Fiscal.SPED_FISCAL.TCD_ObservacaoFiscal(banco).Select(
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
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }).ForEach(p =>
                    {
                        string reg0460 = "|0460|";
                        //Codigo
                        reg0460 += p.Cd_observacao.Trim() + "|";
                        //Observacao
                        reg0460 += p.Ds_observacao.Trim().Replace("\r", "").Replace("\n", "") + "|";

                        SpedFiscal.AppendLine(reg0460);
                        Qtd_linha++;
                        cont++;
                    });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0460", Qtd_linha = cont });
        }*/

        //Encerramento do Bloco
        private static void GerarRegistro0990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 0990...");
            string reg0990 = "|0990|";
            Qtd_linha++;
            reg0990 += Qtd_linha.ToString() + "|";

            SpedFiscal.AppendLine(reg0990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "0990", Qtd_linha = 1 });
        }

        private static void GerarBloco0(TRegistro_DadosEmpresa rEmpresa,
                                        string Finalidade,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        { 
            //Gerar Registro 0000
            GerarRegistro0000(rEmpresa, Finalidade, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0001
            GerarRegistro0001(SpedFiscal, tEspera);
            //Gerar Registro 0005
            GerarRegistro0005(rEmpresa, SpedFiscal, tEspera);
            //Gerar Registro 0100
            GerarRegistro0100(rEmpresa, SpedFiscal, tEspera);
            //Gerar Registro 0150
            GerarRegistro0150(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0190
            GerarRegistro0190(rEmpresa.Cd_empresa, rEmpresa.Tp_atividadespedfiscal.Trim().Equals("0"), Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0200
            GerarRegistro0200(rEmpresa.Cd_empresa, rEmpresa.Tp_atividadespedfiscal.Trim().Equals("0"), Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0220
            GerarRegistro0220(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0400
            GerarRegistro0400(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0450
            GerarRegistro0450(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Gerar Registro 0460
            //GerarRegistro0460(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera, banco);
            //Gerar Registro 0990
            GerarRegistro0990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco B
        private static void GerarRegistroB001(StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro B001...");
            Qtd_linhaB = decimal.Zero;
            string regB001 = "|B001|";
            regB001 += "1|";

            SpedFiscal.AppendLine(regB001);
            Qtd_linhaB++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "B001", Qtd_linha = 1 });
        }

        private static void GerarRegistroB990(StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro B990...");
            string regB990 = "|B990|";
            Qtd_linhaB++;
            regB990 += Qtd_linhaB.ToString() + "|";

            SpedFiscal.AppendLine(regB990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "B990", Qtd_linha = 1 });
        }

        private static void GerarBlocoB(StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            GerarRegistroB001(SpedFiscal, tEspera);
            GerarRegistroB990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco C
        //Abertura do Bloco C
        private static void GerarRegistroC001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro C001...");
            Qtd_linhaC = decimal.Zero;
            string regC001 = "|C001|";
            regC001 += "0|"; //Registro com dados Movimentados

            SpedFiscal.AppendLine(regC001);
            Qtd_linhaC++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C001", Qtd_linha = 1 });
        }

        //Registro C100
        private static void GerarRegistroC100(List<TRegistro_NotaFiscal> lNf,
                                              string Tp_atividadespedfiscal,
                                              string pCd_empresa,
                                              DateTime pDt_ini,
                                              DateTime pDt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            //TRegistro_NotaFiscal r = new TRegistro_NotaFiscal();
            if (tEspera != null)
                tEspera.Msg("Gerando registro C100...");
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where (new string[] { "01", "1B", "04", "55" }).Contains(a.Cd_modelo)
                      group a by new
                      {
                          a.Cd_empresa,
                          a.Nr_lanctofiscal,
                          a.Nr_serie,
                          a.Nr_notafiscal,
                          a.Tp_movimento,
                          a.Tp_nota,
                          a.St_registro,
                          a.Cd_modelo,
                          a.Cd_clifor,
                          a.Cd_endereco,
                          a.Chave_acesso_nfe,
                          a.Dt_emissao,
                          a.Dt_saient,
                          a.Freteporconta,
                          a.Cd_movimentacao,
                          a.Tp_serie,
                          a.Cd_condpgto,
                          a.Qt_parcelas,
                          a.St_NFVinculada
                      } into g
                      select new
                      {
                          g.Key.Cd_empresa,
                          g.Key.Nr_lanctofiscal,
                          g.Key.Nr_serie,
                          g.Key.Nr_notafiscal,
                          g.Key.Tp_movimento,
                          g.Key.Tp_nota,
                          g.Key.St_registro,
                          g.Key.Cd_modelo,
                          g.Key.Cd_clifor,
                          g.Key.Cd_endereco,
                          g.Key.Chave_acesso_nfe,
                          g.Key.Dt_emissao,
                          g.Key.Dt_saient,
                          g.Key.Freteporconta,
                          g.Key.Cd_movimentacao,
                          g.Key.Tp_serie,
                          g.Key.Cd_condpgto,
                          g.Key.Qt_parcelas,
                          g.Key.St_NFVinculada,
                          vl_totalnota = (g.Sum(p => ((System.Decimal?)p.Vl_totalnota ?? (System.Decimal?)0)) ?? 0),
                          vl_desconto = (g.Sum(p => ((System.Decimal?)p.Vl_desconto ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalprodutosservicos = (g.Sum(p => ((System.Decimal?)p.Vl_totalprodutosservicos ?? (System.Decimal?)0)) ?? 0),
                          vl_frete = (g.Sum(p => ((System.Decimal?)p.Vl_frete ?? (System.Decimal?)0)) ?? 0),
                          vl_seguro = (g.Sum(p => ((System.Decimal?)p.Vl_seguro ?? (System.Decimal?)0)) ?? 0),
                          vl_outrasdesp = (g.Sum(p => ((System.Decimal?)p.Vl_outrasdesp ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalbasecalcicms = (g.Sum(p => ((System.Decimal?)p.Vl_totalbasecalcicms ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalicms = (g.Sum(p => ((System.Decimal?)p.Vl_totalicms ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalipi = (g.Sum(p=> ((System.Decimal?)p.Vl_totalipi ?? (System.Decimal?)0)) ?? 0)
                      };
            sql.ToList().ForEach(p =>
                {
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
                    regC100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" :
                                p.St_registro.Trim().ToUpper().Equals("D") ? "04" : "00") + "|";
                    //Serie Documento
                    regC100 += p.Nr_serie.Trim() + "|";
                    //Numero do Documento
                    regC100 += (p.Nr_notafiscal.ToString().Trim().Length > 9 ?
                        p.Nr_notafiscal.ToString().Trim().Substring(p.Nr_notafiscal.ToString().Trim().Length - 9, 9) : p.Nr_notafiscal.ToString()) + "|";
                    //Chave NFe
                    regC100 += p.Chave_acesso_nfe.Trim() + "|";
                    if (p.St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Data Emissao
                        regC100 += p.Dt_emissao.ToString("ddMMyyyy") + "|";
                        //Data Entrada/Saida
                        regC100 += p.Dt_saient.ToString("ddMMyyyy") + "|";
                        //Valor da Nota
                        regC100 += p.vl_totalnota.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo de Pagamento
                        regC100 += (string.IsNullOrEmpty(p.Cd_condpgto) ? "2" : p.Qt_parcelas > 0 ? "1" : "0") + "|";
                        //Valor Desconto
                        regC100 += p.vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Abatimento nao tributado
                        regC100 += "|";
                        //Valor total produtos/servicos
                        regC100 += p.Vl_totalprodutosservicos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo Frete
                        regC100 += p.Freteporconta.Trim() + "|";
                        //Valor Frete
                        regC100 += p.vl_frete.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //valor seguro
                        regC100 += p.vl_seguro.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Outras Despesas
                        regC100 += p.vl_outrasdesp.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc ICMS
                        regC100 += p.Vl_totalbasecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regC100 += p.Vl_totalicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc Subst
                        regC100 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS Subst
                        regC100 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor IPI
                        regC100 += Tp_atividadespedfiscal.Trim().Equals("0") ?
                            p.Vl_totalipi.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|" : "|";
                        //Valor PIS
                        regC100 += "|";
                        //Valor COFINS
                        regC100 += "|";
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
                    {
                        if ((!p.Cd_modelo.Trim().Equals("55")) ||//Se nao for NFe
                            p.Tp_nota.Trim().ToUpper().Equals("T"))//ou se for de Terceiro
                        {
                            //Registros Filhos
                            //Informacao Complementar
                            GerarRegistroC110(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), SpedFiscal);
                            //Notas Fiscais Referenciadas
                            //Registro C113
                            GerarRegistroC113(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), SpedFiscal);
                            //Registro C140 sera gerado somente para documento 01 ou 1A
                            if (p.Cd_modelo.Trim().Equals("01") || p.Cd_modelo.Trim().Equals("1A"))
                                GerarRegistroC140(p.Cd_empresa, p.Nr_lanctofiscal.ToString(), p.Tp_nota, SpedFiscal);
                            //Registro C170
                            GerarRegistroC170(p.Cd_empresa, p.Nr_lanctofiscal, lNf, SpedFiscal);
                        }
                        //Registro C190
                        GerarRegistroC190(p.Cd_empresa, p.Nr_lanctofiscal, lNf, SpedFiscal);
                    }
                });
            //Buscar Cupom Fiscal Eletronico
            new TCD_NFCe().Select(pCd_empresa, pDt_ini, pDt_fin).ForEach(p =>
                {
                    string regC100 = "|C100|";
                    //Tipo de Movimento
                    regC100 += "1|";
                    //Tipo Nota
                    regC100 += "0|";
                    //Codigo Clifor
                    regC100 += "|";
                    //Modelo da Nota
                    regC100 += p.Cd_modelo.Trim() + "|";
                    //Codigo Situacao Documento
                    regC100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : "00") + "|";
                    //Serie Documento
                    regC100 += p.Nr_serie.Trim() + "|";
                    //Numero do Documento
                    regC100 += (p.Nr_nfce.ToString().Trim().Length > 9 ?
                        p.Nr_nfce.ToString().Trim().Substring(p.Nr_nfce.ToString().Trim().Length - 9, 9) : p.Nr_nfce.ToString()) + "|";
                    //Chave NFe
                    regC100 += p.Chave_acesso.Trim() + "|";
                    if (p.St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Data Emissao
                        regC100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                        //Data Entrada/Saida
                        regC100 += "|";
                        //Valor da Nota
                        regC100 += p.Vl_cupom.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo de Pagamento
                        regC100 += "0|";
                        //Valor Desconto
                        regC100 += p.Vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Abatimento nao tributado
                        regC100 += "|";
                        //Valor total produtos/servicos
                        regC100 += p.Vl_itens.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Tipo Frete
                        regC100 += "9|";
                        //Valor Frete
                        regC100 += "|";
                        //valor seguro
                        regC100 += "|";
                        //Valor Outras Despesas
                        regC100 += p.Vl_outrasdesp.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc ICMS
                        regC100 += p.Vl_basecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regC100 += p.Vl_icms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor Base Calc Subst
                        regC100 += "|";
                        //Valor ICMS Subst
                        regC100 += "|";
                        //Valor IPI
                        regC100 += "|";
                        //Valor PIS
                        regC100 += "|";
                        //Valor COFINS
                        regC100 += "|";
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
                    {
                        decimal cont190 = decimal.Zero;
                        new TCD_NFCeC190().Select(pCd_empresa, p.Id_cupom.Value.ToString()).ForEach(v =>
                            {
                                string regC190 = "|C190|";
                                //Situacao Tributaria
                                regC190 += v.Cd_st_icms.Trim().PadLeft(3, '0') + "|";
                                //CFOP
                                regC190 += v.Cd_cfop.Trim() + "|";
                                //Aliquota ICMS
                                regC190 += v.Pc_aliquota.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Valor Operacao
                                regC190 += v.Vl_operacao.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Base Calc. ICMS
                                regC190 += v.Vl_basecalc.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Valor ICMS
                                regC190 += v.Vl_icms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Base Calc. Subst.
                                regC190 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //ICMS Subst
                                regC190 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Valor Reducao Base Calc.
                                regC190 += (v.Vl_operacao - v.Vl_basecalc).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Valor IPI
                                regC190 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                                //Observacao do lancamento fiscal, so deve ser informado UF 
                                regC190 += "|";

                                SpedFiscal.AppendLine(regC190);
                                Qtd_linhaC++;
                                cont190++;
                            });
                        if (cont190 > decimal.Zero)
                            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C190", Qtd_linha = cont190 });
                    }
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C100", Qtd_linha = cont });
        }

        //Registro C110
        private static void GerarRegistroC110(string Cd_empresa,
                                              string Nr_lanctofiscal, 
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
                        vNM_Campo = "a.nr_lanctofiscal",
                        vOperador = "=",
                        vVL_Busca = Nr_lanctofiscal
                    }
                }).ForEach(p =>
                {
                    string regC110 = "|C110|";
                    //Codigo
                    regC110 += p.Cd_dadosadicionais.Trim() + "|";
                    //Descricao
                    regC110 += p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "").Length > 255 ? p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "").Substring(0, 255).Trim() + "|" : p.Ds_dadosadicionais.Trim().Replace("\r", "").Replace("\n", "") + "|";

                    SpedFiscal.AppendLine(regC110);
                    Qtd_linhaC++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C110", Qtd_linha = cont });
        }

        //Registro C113
        private static void GerarRegistroC113(string Cd_empresa,
                                              string Nr_lanctofiscal, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            //Buscar Notas Fiscais Referenciadas
            new TCD_NotaFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal_origem = a.nr_lanctofiscal " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " + 
                                    "and x.nr_lanctofiscal_destino = " + Nr_lanctofiscal + ")"
                    }
                }).ForEach(p =>
                {
                    string regC113 = "|C113|";
                    //Tipo Movimento
                    regC113 += (p.Tp_movimento.Trim().ToUpper().Equals("E") ? "0" : "1") + "|";
                    //Tipo Nota
                    regC113 += (p.Tp_nota.Trim().ToUpper().Equals("P") ? "0" : "1") + "|";
                    //Codigo Clifor
                    regC113 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Codigo Modelo Fiscal
                    regC113 += p.Cd_modelo.Trim() + "|";
                    //Serie Nota
                    regC113 += p.Nr_serie.Trim() + "|";
                    //Sub Serie
                    regC113 += "|";
                    //Numero Nota Fiscal
                    regC113 += p.Nr_notafiscal.ToString() + "|";
                    //Data Emissao
                    regC113 += p.Dt_emissao.ToString("ddMMyyyy") + "|";
                    //Chave Acesso Documento
                    regC113 += p.Chave_acesso_nfe.Trim() + "|";

                    SpedFiscal.AppendLine(regC113);
                    Qtd_linhaC++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C113", Qtd_linha = cont });
        }

        //Registro C140
        private static void GerarRegistroC140(string Cd_empresa,
                                              string Nr_lanctofiscal,
                                              string Tp_nota,
                                              StringBuilder SpedFiscal)
        {
            //Buscar duplicata
            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " + 
                                    "and x.nr_lanctoduplicata = a.nr_lancto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.nr_lanctofiscal = " + Nr_lanctofiscal + ")"
                    }
                }, 0, string.Empty);
            if (lDup.Count > 0)
            {
                string regC140 = "|C140|";
                //Indicador do emitente do titulo
                regC140 += (Tp_nota.Trim().ToUpper().Equals("P") ? "0" : "1") + "|";
                //Indicador do tipo de titulo
                regC140 += "00|";//Duplicata
                //Observacao duplicata
                regC140 += lDup[0].Ds_observacao.Trim() + "|";
                //Codigo Duplicata
                regC140 += lDup[0].Nr_lancto.ToString() + "|";
                //Quantidade parcelas
                regC140 += lDup[0].Qt_parcelas.ToString() + "|";
                //Valor Duplicata
                regC140 += lDup[0].Vl_documento_padrao.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                SpedFiscal.AppendLine(regC140);
                Qtd_linhaC++;
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C140", Qtd_linha = 1 });
                //Buscar parcelas duplicata
                decimal cont = decimal.Zero;
                CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.Busca(lDup[0].Cd_empresa,
                                                                        lDup[0].Nr_lancto,
                                                                        decimal.Zero,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        0,
                                                                        string.Empty,
                                                                        null).ForEach(p =>
                                                                            {
                                                                                GerarRegistroC141(p, SpedFiscal);
                                                                                cont++;
                                                                            });
                if (cont > 0)
                    RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C141", Qtd_linha = cont });
            }
        }

        //Registro C141
        private static void GerarRegistroC141(CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela rParc, StringBuilder SpedFiscal)
        {
            string regC141 = "|C141|";
            //Numero da parcela
            regC141 += rParc.Cd_parcela.ToString() + "|";
            //Vencimento
            regC141 += rParc.Dt_vencto.Value.ToString("ddMMyyyy") + "|";
            //Valor Parcela
            regC141 += rParc.Vl_parcela_padrao.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

            SpedFiscal.AppendLine(regC141);
            Qtd_linhaC++;
        }
                
        //Registro C170
        private static void GerarRegistroC170(string Cd_empresa,
                                              decimal Nr_lanctofiscal,
                                              List<TRegistro_NotaFiscal> lNf, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            //Buscar Itens da Nota
            lNf.FindAll(p=> p.Cd_empresa.Trim().Equals(Cd_empresa.Trim()) && p.Nr_lanctofiscal.Equals(Nr_lanctofiscal)).ForEach(p =>
                {
                    string regC170 = "|C170|";
                    //Codigo Item
                    regC170 += p.Id_nfitem.ToString() + "|";
                    //Codigo Produto/Servico
                    regC170 += p.Cd_produto.Trim() + "|";
                    //Descricao Produto
                    regC170 += p.Ds_produto.Trim() + "|";
                    //Quantidade Item
                    regC170 += p.Quantidade.ToString("N5").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Unidade Valor
                    regC170 += p.Cd_unidade.Trim() + "|";
                    //Valor Item
                    regC170 += p.Vl_totalprodutosservicos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Desconto
                    regC170 += p.Vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Movimentacao Fisica Produto
                    regC170 += p.St_movestoque ? "0|" : "1|";
                    //Situacao Tributaria ICMS
                    regC170 += p.Cd_st.Trim().PadLeft(3, '0') + "|";
                    //CFOP
                    regC170 += p.Cd_cfop.Trim() + "|";
                    //Natureza Operacao
                    regC170 += p.Cd_movimentacao.ToString() + "|";
                    //Valor Base Calc ICMS
                    regC170 += p.Vl_totalbasecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota ICMS
                    regC170 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS
                    regC170 += p.Vl_totalicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Base Calc Subst
                    regC170 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota ICMS Subst
                    regC170 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS Subst
                    regC170 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador do periodo de apuracao do IPI
                    regC170 += "0|";
                    //Situacao Tributaria IPI
                    regC170 += p.Cd_stipi.Trim() + "|";
                    //Codigo enquadramento IPI, deixar em branco
                    regC170 += "|";
                    //Valor Base Calc IPI
                    regC170 += p.Vl_basecalcipi.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Aliquota IPI
                    regC170 += p.Pc_aliquotaipi.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor IPI
                    regC170 += p.Vl_totalipi.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //situacao tributaria PIS
                    regC170 += "|";
                    //Valor Base Calc. PIS
                    regC170 += "|";
                    //Aliquota PIS
                    regC170 += "|";
                    //Base Calc PIS Quantidade
                    regC170 += "|";
                    //Aliquota PIS R$
                    regC170 += "|";
                    //Valor PIS
                    regC170 += "|";
                    //Situacao Tributaria COFINS
                    regC170 += "|";
                    //Valor Base Calc. COFINS
                    regC170 += "|";
                    //Aliquota COFINS
                    regC170 += "|";
                    //Base Calc. COFINS Quantidade
                    regC170 += "|";
                    //Aliquota COFINS R$
                    regC170 += "|";
                    //Valor COFINS
                    regC170 += "|";
                    //Conta Contabil Debitada/Creditada
                    regC170 += "|";
                    //Valor do abatimento não tributado e não comercial
                    regC170 += "|";

                    SpedFiscal.AppendLine(regC170);
                    Qtd_linhaC++;
                    cont++;

                    //Gerar Registro C171
                    if (p.Tp_movimento.Trim().ToUpper().Equals("E") &&
                        (!p.Tp_nota.Trim().ToUpper().Equals("P")) &&
                        (p.Cd_modelo.Trim().Equals("01") || p.Cd_modelo.Trim().Equals("55")))
                        GerarRegistroC171(p, SpedFiscal);
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C170", Qtd_linha = cont });
        }

        //Registro C171
        private static void GerarRegistroC171(TRegistro_NotaFiscal rNfItem, 
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            string regC171 = "|C171|";
            //Numero tanque armazenamento
            regC171 += rNfItem.Id_tanque.ToString() + "|";
            //Quantidade Armazenada
            regC171 += rNfItem.Quantidade.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

            SpedFiscal.AppendLine(regC171);
            Qtd_linhaC++;
            cont++;
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C171", Qtd_linha = cont });
        }
        
        //Registro C190
        private static void GerarRegistroC190(string Cd_empresa,
                                              decimal Nr_lanctofiscal, 
                                              List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where a.Cd_empresa.Trim().Equals(Cd_empresa.Trim()) && a.Nr_lanctofiscal.Equals(Nr_lanctofiscal)
                      group a by new
                      {
                          a.Cd_cfop,
                          a.Cd_st,
                          a.Pc_aliquotaicms
                      } into g
                      select new
                      {
                          g.Key.Cd_cfop,
                          g.Key.Cd_st,
                          g.Key.Pc_aliquotaicms,
                          vl_operacao = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalnota ?? (System.Decimal?)0))),
                          vl_basecalcicms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalbasecalcicms ?? (System.Decimal?)0))),
                          vl_icms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalicms ?? (System.Decimal?)0))),
                          vl_baseimposto = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalprodutosservicos + p.Vl_frete + p.Vl_outrasdesp + p.Vl_seguro - p.Vl_desconto ?? (System.Decimal?)0))),
                          vl_ipi = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalipi ?? (System.Decimal?)0)))
                      };
            sql.ToList().ForEach(p =>
                {
                    string regC190 = "|C190|";
                    //Situacao Tributaria
                    regC190 += p.Cd_st.Trim().PadLeft(3, '0') + "|";
                    //CFOP
                    regC190 += p.Cd_cfop.Trim() + "|";
                    //Aliquota ICMS
                    regC190 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Operacao
                    regC190 += (p.vl_operacao.HasValue ? p.vl_operacao.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calc. ICMS
                    regC190 += (p.vl_basecalcicms.HasValue ? p.vl_basecalcicms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS
                    regC190 += (p.vl_icms.HasValue ? p.vl_icms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calc. Subst.
                    regC190 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //ICMS Subst
                    regC190 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Reducao Base Calc.
                    regC190 += (p.vl_operacao.HasValue && p.vl_basecalcicms.HasValue ? p.vl_operacao.Value - p.vl_basecalcicms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor IPI
                    regC190 += p.vl_ipi.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Observacao do lancamento fiscal, so deve ser informado UF 
                    regC190 += "|";

                    SpedFiscal.AppendLine(regC190);
                    Qtd_linhaC++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C190", Qtd_linha = cont });
        }

        //Registro C500
        private static void GerarRegistroC500(List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro C500...");
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where a.Tp_movimento == "E" && (new string[] { "06", "28", "29" }).Contains(a.Cd_modelo)
                      group a by new
                      {
                          a.Cd_empresa,
                          a.Nr_lanctofiscal,
                          a.Nr_serie,
                          a.Nr_notafiscal,
                          a.Tp_movimento,
                          a.Tp_nota,
                          a.St_registro,
                          a.Cd_modelo,
                          a.Cd_clifor,
                          a.Cd_endereco,
                          a.Chave_acesso_nfe,
                          a.Dt_emissao,
                          a.Dt_saient,
                          a.Freteporconta,
                          a.Cd_movimentacao,
                          a.Tp_serie,
                          a.Cd_condpgto,
                          a.Qt_parcelas,
                          a.St_NFVinculada
                      } into g
                      select new
                      {
                          g.Key.Cd_empresa,
                          g.Key.Nr_lanctofiscal,
                          g.Key.Nr_serie,
                          g.Key.Nr_notafiscal,
                          g.Key.Tp_movimento,
                          g.Key.Tp_nota,
                          g.Key.St_registro,
                          g.Key.Cd_modelo,
                          g.Key.Cd_clifor,
                          g.Key.Cd_endereco,
                          g.Key.Chave_acesso_nfe,
                          g.Key.Dt_emissao,
                          g.Key.Dt_saient,
                          g.Key.Freteporconta,
                          g.Key.Cd_movimentacao,
                          g.Key.Tp_serie,
                          g.Key.Cd_condpgto,
                          g.Key.Qt_parcelas,
                          g.Key.St_NFVinculada,
                          vl_totalnota = (g.Sum(p => ((System.Decimal?)p.Vl_totalnota ?? (System.Decimal?)0)) ?? 0),
                          vl_desconto = (g.Sum(p => ((System.Decimal?)p.Vl_desconto ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalprodutosservicos = (g.Sum(p => ((System.Decimal?)p.Vl_totalprodutosservicos ?? (System.Decimal?)0)) ?? 0),
                          vl_frete = (g.Sum(p => ((System.Decimal?)p.Vl_frete ?? (System.Decimal?)0)) ?? 0),
                          vl_seguro = (g.Sum(p => ((System.Decimal?)p.Vl_seguro ?? (System.Decimal?)0)) ?? 0),
                          vl_outrasdesp = (g.Sum(p => ((System.Decimal?)p.Vl_outrasdesp ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalbasecalcicms = (g.Sum(p => ((System.Decimal?)p.Vl_totalbasecalcicms ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalicms = (g.Sum(p => ((System.Decimal?)p.Vl_totalicms ?? (System.Decimal?)0)) ?? 0),
                          Vl_totalipi = (g.Sum(p => ((System.Decimal?)p.Vl_totalipi ?? (System.Decimal?)0)) ?? 0)
                      };
            sql.ToList().ForEach(p =>
                {
                    string regC500 = "|C500|";
                    //Tipo Movimento
                    regC500 += "0|";//Somente entrada
                    //Emitente da nota
                    regC500 += (p.Tp_nota.Trim().ToUpper().Equals("P") ? "0" : "1") + "|";
                    //Codigo do Clifor
                    regC500 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Modelo Documento Fiscal
                    regC500 += p.Cd_modelo.Trim() + "|";
                    //Situacao do Documento
                    regC500 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : "00") + "|";
                    //Serie do Documento
                    regC500 += p.Nr_serie.Trim() + "|";
                    //SubSerie do Documento
                    regC500 += "|";
                    //Codigo de classe de consumo de energia/agua
                    regC500 += "|";
                    //Numero do Documento
                    regC500 += p.Nr_notafiscal.ToString() + "|";
                    //Data Emissao
                    regC500 += p.Dt_emissao.ToString("ddMMyyyy") + "|";
                    //Data Entrada/Saida
                    regC500 += p.Dt_saient.ToString("ddMMyyyy") + "|";
                    //Valor do Documento
                    regC500 += p.vl_totalnota.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Desconto
                    if (p.vl_desconto > 0)
                        regC500 += p.vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC500 += "|";
                    //Valor Total produtos
                    regC500 += p.Vl_totalprodutosservicos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor servicos nao tributados pelo ICMS
                    if ((p.vl_totalnota - p.Vl_totalbasecalcicms) > 0)
                        regC500 += (p.vl_totalnota - p.Vl_totalbasecalcicms).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC500 += "|";
                    //Valor cobrado em nome de terceiros
                    regC500 += "|";
                    //Valor despesas acessorias
                    if (p.vl_outrasdesp > 0)
                        regC500 += p.vl_outrasdesp.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC500 += "|";
                    //Valor Base Calc ICMS
                    if (p.Vl_totalbasecalcicms > 0)
                        regC500 += p.Vl_totalbasecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC500 += "|";
                    //Valor ICMS
                    if (p.Vl_totalicms > 0)
                        regC500 += p.Vl_totalicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC500 += "|";
                    //Base Calculo ICMS Subst
                    regC500 += "|";
                    //Valor ICMS Subst
                    regC500 += "|";
                    //Codigo dados adicionais
                    regC500 += "|";
                    //Valor PIS
                    regC500 += "|";
                    //Valor COFINS
                    regC500 += "|";
                    //Tipo Ligacao
                    regC500 += "|";
                    //Grupo Tensao
                    regC500 += "|";

                    SpedFiscal.AppendLine(regC500);
                    Qtd_linhaC++;
                    cont++;

                    //Gerar Registro Analitico
                    GerarRegistroC590(p.Cd_empresa, p.Nr_lanctofiscal, lNf, SpedFiscal);
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C500", Qtd_linha = cont });
        }

        //Registro C590
        public static void GerarRegistroC590(string Cd_empresa,
                                             decimal Nr_lanctofiscal,
                                             List<TRegistro_NotaFiscal> lNf, 
                                             StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where a.Cd_empresa.Trim().Equals(Cd_empresa.Trim()) && a.Nr_lanctofiscal.Equals(Nr_lanctofiscal)
                      group a by new
                      {
                          a.Cd_cfop,
                          a.Cd_st,
                          a.Pc_aliquotaicms
                      } into g
                      select new
                      {
                          g.Key.Cd_cfop,
                          g.Key.Cd_st,
                          g.Key.Pc_aliquotaicms,
                          vl_operacao = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalnota ?? (System.Decimal?)0))),
                          vl_basecalcicms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalbasecalcicms ?? (System.Decimal?)0))),
                          vl_icms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalicms ?? (System.Decimal?)0))),
                          vl_baseimposto = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalprodutosservicos + p.Vl_frete + p.Vl_outrasdesp + p.Vl_seguro - p.Vl_desconto ?? (System.Decimal?)0))),
                          vl_ipi = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalipi ?? (System.Decimal?)0)))
                      };
            sql.ToList().ForEach(p =>
                {
                    string regC590 = "|C590|";
                    //Situacao Tributaria
                    regC590 += p.Cd_st.Trim().PadLeft(3, '0') + "|";
                    //CFOP
                    regC590 += p.Cd_cfop.Trim() + "|";
                    //Aliquota ICMS
                    if (p.Pc_aliquotaicms > 0)
                        regC590 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC590 += "|";
                    //Valor Operacao
                    regC590 += p.vl_operacao.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Base Calc
                    if (p.vl_basecalcicms.HasValue)
                        regC590 += p.vl_basecalcicms.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC590 += "|";
                    //Valor ICMS
                    if (p.vl_icms.HasValue)
                        regC590 += p.vl_icms.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC590 += "|";
                    //Valor Base Calc Subst
                    regC590 += "|";
                    //Valor ICMS Subst
                    regC590 += "|";
                    //Valor reducao base calc
                    if (p.vl_basecalcicms.HasValue)
                        regC590 += (p.vl_operacao.Value - p.vl_basecalcicms.Value).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regC590 += "|";
                    //Observacao Fiscal
                    regC590 += "|";

                    SpedFiscal.AppendLine(regC590);
                    Qtd_linhaC++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C590", Qtd_linha = cont });
        }

        //Registro C990
        private static void GerarRegistroC990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro C990...");
            string regC990 = "|C990|";
            Qtd_linhaC++;
            regC990 += Qtd_linhaC.ToString() + "|";

            SpedFiscal.AppendLine(regC990);

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "C990", Qtd_linha = 1 });
        }

        private static void GerarBlocoC(TRegistro_DadosEmpresa rEmpresa,
                                        List<TRegistro_NotaFiscal> lNf,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            GerarRegistroC001(SpedFiscal, tEspera);
            GerarRegistroC100(lNf, rEmpresa.Tp_atividadespedfiscal, rEmpresa.Cd_empresa, Dt_ini.Value, Dt_fin.Value, SpedFiscal, tEspera);
            GerarRegistroC500(lNf, SpedFiscal, tEspera);
            GerarRegistroC990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco D
        private static void GerarRegistroD001(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro D001...");
            Qtd_linhaD = decimal.Zero;
            string regD001 = "|D001|";
            //Verificar se o bloco possui informacao
            if ((new TCD_NFServicos().BuscarEscalar(
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
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
               }, "1") != null) ||
               (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "in",
                        vVL_Busca = "('21', '22')"
                    }
                }, "1") != null))
                regD001 += "0|";
            else
                regD001 += "1|";

            SpedFiscal.AppendLine(regD001);
            Qtd_linhaD++;

            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D001", Qtd_linha = 1 });
        }

        private static void GerarRegistroD100(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro D100...");
            decimal cont = decimal.Zero;
            new TCD_NFServicos().Select(
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
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }).ForEach(p =>
                {
                    string regD100 = "|D100|";
                    //Tipo de Operação 0-Aquisição 1-Prestação
                    regD100 +=  p.Tp_nota.Trim().ToUpper().Equals("T") ? "0|" : "1|";
                    //Emitente do documento
                    regD100 += p.Tp_nota.Trim().ToUpper().Equals("P") ? "0|" : "1|";
                    //Codigo do clifor
                    regD100 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                    //Modelo Fiscal
                    regD100 += p.Cd_modelo.Trim() + "|";
                    //Status documento
                    regD100 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : "00") + "|";
                    //Serie do documento
                    if (!string.IsNullOrEmpty(p.Nr_serie))
                        regD100 += p.Nr_serie.Trim() + "|";
                    else
                        regD100 += "|";
                    //SubSerie do documento
                    if (!string.IsNullOrEmpty(p.Nr_subserie))
                        regD100 += p.Nr_subserie.Trim() + "|";
                    else
                        regD100 += "|";
                    //Numero do documento
                    regD100 += p.Nr_notafiscal.Value.ToString() + "|";
                    //Chave acesso
                    if (!string.IsNullOrEmpty(p.Chave_acesso))
                        regD100 += p.Chave_acesso.Trim() + "|";
                    else
                        regD100 += "|";
                    //Data emissao
                    regD100 += p.Dt_emissao.Value.ToString("ddMMyyyy") + "|";
                    //Data Sai/Ent
                    regD100 += p.Dt_saient.Value.ToString("ddMMyyyy") + "|";
                    if (!string.IsNullOrEmpty(p.Tp_cte))
                        regD100 += p.Tp_cte.Trim() + "|";
                    else
                        regD100 += "|";
                    //Chave acesso CTe referencia
                    if (!string.IsNullOrEmpty(p.Chave_cte_refenciado))
                        regD100 += p.Chave_cte_refenciado.Trim() + "|";
                    else
                        regD100 += "|";
                    //Valor total do documento
                    regD100 += p.Vl_totalnota.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor descontos
                    if (p.Vl_desconto > 0)
                        regD100 += p.Vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Tipo frete
                    regD100 += p.Freteporconta.Trim() + "|";
                    //Valor servicos
                    regD100 += p.Vl_totalservico.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Base Calc ICMS
                    if (p.Vl_basecalcicms > 0)
                        regD100 += p.Vl_basecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Valor ICMS
                    if (p.Vl_icms > 0)
                        regD100 += p.Vl_icms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Valor nao tributado
                    if (p.Vl_naotributado > 0)
                        regD100 += p.Vl_naotributado.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD100 += "|";
                    //Codigo informacao complementar
                    regD100 += "|";
                    //Codigo conta analitica
                    regD100 += "|";
                    //Código Municipio Origem Servico
                    regD100 += p.Cd_cidade_ini.Trim() + "|";
                    //Código Municipio Destino Servico
                    regD100 += p.Cd_cidade_fin.Trim() + "|";

                    SpedFiscal.AppendLine(regD100);
                    Qtd_linhaD++;
                    cont++;

                    //Gerar Registro D190
                    GerarRegistroD190(p.Cd_empresa, 
                                      p.Nr_lancto.ToString(), 
                                      p.Tp_registro.Trim().ToUpper().Equals("NFF"), 
                                      SpedFiscal);
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D100", Qtd_linha = cont });
        }

        private static void GerarRegistroD190(string Cd_empresa,
                                              string Nr_lancto,
                                              bool St_nf,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_AnaliticoServicos().Select(Cd_empresa, Nr_lancto, St_nf).ForEach(p =>
                {
                    string regD190 = "|D190|";
                    //Situacao Tributaria
                    regD190 += p.Cd_st.Trim().PadLeft(3, '0') + "|";
                    //Cfop
                    regD190 += p.Cd_cfop.Trim() + "|";
                    //Aliquota ICMS
                    if (p.Pc_aliquotaicms > 0)
                        regD190 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regD190 += "|";
                    //valor operacao
                    regD190 += p.Vl_operacao.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Base Calc ICMS
                    regD190 += p.Vl_basecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor ICMS
                    regD190 += p.Vl_icms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor nao tributado
                    regD190 += p.Vl_reducaobasecalc.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Observacao Fiscal
                    regD190 += "|";

                    SpedFiscal.AppendLine(regD190);
                    Qtd_linhaD++;
                    cont++;
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D190", Qtd_linha = cont });
        }

        private static void GerarRegistroD500(List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro D500...");
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where (new string[] { "21", "22" }).Contains(a.Cd_modelo)
                      group a by new
                      {
                          a.Cd_empresa,
                          a.Nr_lanctofiscal,
                          a.Nr_serie,
                          a.Nr_notafiscal,
                          a.Tp_nota,
                          a.St_registro,
                          a.Cd_modelo,
                          a.Cd_clifor,
                          a.Cd_endereco,
                          a.Chave_acesso_nfe,
                          a.Dt_emissao,
                          a.Dt_saient,
                          a.Freteporconta,
                          a.Cd_movimentacao,
                          a.Tp_serie,
                          a.Cd_condpgto,
                          a.Qt_parcelas,
                          a.St_NFVinculada
                      } into g
                      select new
                      {
                          g.Key.Cd_empresa,
                          g.Key.Nr_lanctofiscal,
                          g.Key.Nr_serie,
                          g.Key.Nr_notafiscal,
                          g.Key.Tp_nota,
                          g.Key.St_registro,
                          g.Key.Cd_modelo,
                          g.Key.Cd_clifor,
                          g.Key.Cd_endereco,
                          g.Key.Chave_acesso_nfe,
                          g.Key.Dt_emissao,
                          g.Key.Dt_saient,
                          g.Key.Freteporconta,
                          g.Key.Cd_movimentacao,
                          g.Key.Tp_serie,
                          g.Key.Cd_condpgto,
                          g.Key.Qt_parcelas,
                          g.Key.St_NFVinculada,
                          vl_totalnota = (g.Sum(p => ((decimal?)p.Vl_totalnota ?? (decimal?)0)) ?? 0),
                          vl_desconto = (g.Sum(p => ((decimal?)p.Vl_desconto ?? (decimal?)0)) ?? 0),
                          Vl_totalprodutosservicos = (g.Sum(p => ((decimal?)p.Vl_totalprodutosservicos ?? (decimal?)0)) ?? 0),
                          vl_frete = (g.Sum(p => ((decimal?)p.Vl_frete ?? (decimal?)0)) ?? 0),
                          vl_seguro = (g.Sum(p => ((decimal?)p.Vl_seguro ?? (decimal?)0)) ?? 0),
                          vl_outrasdesp = (g.Sum(p => ((decimal?)p.Vl_outrasdesp ?? (decimal?)0)) ?? 0),
                          Vl_totalbasecalcicms = (g.Sum(p => ((decimal?)p.Vl_totalbasecalcicms ?? (decimal?)0)) ?? 0),
                          Vl_totalicms = (g.Sum(p => ((decimal?)p.Vl_totalicms ?? (decimal?)0)) ?? 0),
                          Vl_totalipi = (g.Sum(p => ((decimal?)p.Vl_totalipi ?? (decimal?)0)) ?? 0)
                      };
            sql.ToList().ForEach(p =>
                    {
                        string regD500 = "|D500|";
                        //Tipo Operação 0-Aquisição 1-Prestação
                        regD500 += p.Tp_nota.Trim().ToUpper().Equals("T") ? "0|" : "1|";
                        //Emitente do documento
                        regD500 += p.Tp_nota.Trim().ToUpper().Equals("P") ? "0|" : "1|";
                        //Codigo Cliente
                        regD500 += p.Cd_clifor.Trim() + p.Cd_endereco.Trim() + "|";
                        //Codigo Modelo
                        regD500 += p.Cd_modelo.Trim() + "|";
                        //Status do documento
                        regD500 += (p.St_registro.Trim().ToUpper().Equals("C") ? "02" : "00") + "|";
                        //Serie do documento
                        regD500 += p.Nr_serie.Trim() + "|";
                        //SubSerie do documento
                        regD500 += "|";
                        //Numero do Documento
                        regD500 += (p.Nr_notafiscal.ToString().Trim().Length > 9 ?
                            p.Nr_notafiscal.ToString().Trim().Substring(p.Nr_notafiscal.ToString().Trim().Length - 9, 9) : p.Nr_notafiscal.ToString()) + "|";
                        //Data Emissao
                        regD500 += p.Dt_emissao.ToString("ddMMyyyy") + "|";
                        //Data SaiEnt
                        regD500 += p.Dt_saient.ToString("ddMMyyyy") + "|";
                        //Valor documento
                        regD500 += p.vl_totalnota.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor desconto
                        if (p.vl_desconto > 0)
                            regD500 += p.vl_desconto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        else
                            regD500 += "|";
                        //Valor servicos
                        regD500 += p.Vl_totalprodutosservicos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor servicos isento
                        if((p.Vl_totalprodutosservicos - p.Vl_totalbasecalcicms) > 0)
                            regD500 += (p.Vl_totalprodutosservicos - p.Vl_totalbasecalcicms).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        else
                            regD500 += "|";
                        //valor cobrado em nome terceiro
                        regD500 += "|";
                        //Valor outras despesas
                        regD500 += p.vl_outrasdesp.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor base calc icms
                        regD500 += p.Vl_totalbasecalcicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regD500 += p.Vl_totalicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Informacao complementar
                        regD500 += "|";
                        //valor PIS
                        regD500 += "|";
                        //Valor COFINS
                        regD500 += "|";
                        //Conta contabil analitica
                        regD500 += "|";
                        //Codigo tipo assinante
                        regD500 += "|";

                        SpedFiscal.AppendLine(regD500);
                        Qtd_linhaD++;
                        cont++;

                        //Registro D590
                        GerarRegistroD590(p.Cd_empresa, p.Nr_lanctofiscal, lNf, SpedFiscal);
                    });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D500", Qtd_linha = cont });
        }

        private static void GerarRegistroD590(string Cd_empresa, 
                                              decimal Nr_lanctofiscal,
                                              List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where a.Cd_empresa.Trim().Equals(Cd_empresa.Trim()) && a.Nr_lanctofiscal.Equals(Nr_lanctofiscal)
                      group a by new
                      {
                          a.Cd_cfop,
                          a.Cd_st,
                          a.Pc_aliquotaicms
                      } into g
                      select new
                      {
                          g.Key.Cd_cfop,
                          g.Key.Cd_st,
                          g.Key.Pc_aliquotaicms,
                          vl_operacao = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalnota ?? (System.Decimal?)0))),
                          vl_basecalcicms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalbasecalcicms ?? (System.Decimal?)0))),
                          vl_icms = (decimal?)g.Sum(p => ((System.Decimal)((System.Decimal?)p.Vl_totalicms ?? (System.Decimal?)0))),
                          vl_baseimposto = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalprodutosservicos + p.Vl_frete + p.Vl_outrasdesp + p.Vl_seguro - p.Vl_desconto ?? (System.Decimal?)0))),
                          vl_ipi = (decimal?)g.Sum(p=>((System.Decimal)((System.Decimal?) p.Vl_totalipi ?? (System.Decimal?)0)))
                      };
            sql.ToList().ForEach(p =>
                    {
                        string regD590 = "|D590|";
                        //Situacao Tributaria
                        regD590 += p.Cd_st.Trim().PadLeft(3, '0') + "|";
                        //CFOP
                        regD590 += p.Cd_cfop.Trim() + "|";
                        //Aliquota ICMS
                        if (p.Pc_aliquotaicms > 0)
                            regD590 += p.Pc_aliquotaicms.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        else
                            regD590 += "|";
                        //Valor Operacao
                        regD590 += p.vl_operacao.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calc ICMS
                        regD590 += (p.vl_basecalcicms.HasValue ? p.vl_basecalcicms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS
                        regD590 += (p.vl_icms.HasValue ? p.vl_icms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Base Calc Subst
                        regD590 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor ICMS Subst
                        regD590 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Valor reducao base calc
                        regD590 += (p.vl_basecalcicms.HasValue ? p.vl_operacao.Value - p.vl_basecalcicms.Value : decimal.Zero).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                        //Observacao fiscal
                        regD590 += "|";

                        SpedFiscal.AppendLine(regD590);
                        Qtd_linhaD++;
                        cont++;
                    });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D590", Qtd_linha = cont });
        }

        private static void GerarRegistroD990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro D990...");
            string regD990 = "|D990|";
            Qtd_linhaD++;
            regD990 += Qtd_linhaD.ToString() + "|";

            SpedFiscal.AppendLine(regD990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "D990", Qtd_linha = 1 });
        }

        private static void GerarBlocoD(TRegistro_DadosEmpresa rEmpresa,
                                        List<TRegistro_NotaFiscal> lNf,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            GerarRegistroD001(rEmpresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            GerarRegistroD100(rEmpresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            GerarRegistroD500(lNf, SpedFiscal, tEspera);
            GerarRegistroD990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco E
        //Abertura do bloco
        private static void GerarRegistroE001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E001...");
            Qtd_linhaE = decimal.Zero;
            string regE001 = "|E001|";
            regE001 += "0|";

            SpedFiscal.AppendLine(regE001);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E001", Qtd_linha = 1 });
        }

        private static void GerarRegistroE100(DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E100...");
            string regE100 = "|E100|";
            //Data Inicial
            regE100 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
            //Data Final
            regE100 += Dt_fin.Value.ToString("ddMMyyyy") + "|";

            SpedFiscal.AppendLine(regE100);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E100", Qtd_linha = 1 });
        }

        private static void GerarRegistroE110(TRegistro_DadosEmpresa rEmpresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E110...");
            decimal cont = decimal.Zero;
            new TCD_ApuracaoICMS().Select(rEmpresa.Cd_empresa, Dt_ini, Dt_fin).ForEach(p =>
                {
                    string regE110 = "|E110|";
                    //Total de Debitos
                    regE110 += p.Vl_tot_debitos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Total Ajuste Documento Fiscal
                    regE110 += "000|";
                    //Total Ajuste a Debito
                    regE110 += p.Vl_tot_aj_debitos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Total Estorno Credito
                    regE110 += p.Vl_estorno_cred.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Total Credito
                    regE110 += p.Vl_tot_creditos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Total Ajuste Documento Fiscal
                    regE110 += "000|";
                    //Total Ajuste a Credito
                    regE110 += p.Vl_tot_aj_creditos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Total Estorno Debitos
                    regE110 += p.Vl_estorno_deb.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Saldo Credor do periodo anterior
                    regE110 += p.Vl_sld_credor_ant.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Saldo Apurado
                    decimal vl_apurado = (p.Vl_tot_debitos + p.Vl_tot_aj_debitos + p.Vl_estorno_cred) -
                                         (p.Vl_tot_creditos + p.Vl_tot_aj_creditos + p.Vl_estorno_deb + p.Vl_sld_credor_ant);
                    if (vl_apurado > decimal.Zero)
                        regE110 += vl_apurado.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    else
                        regE110 += "000|";
                    //Valor Total Deducoes
                    regE110 += p.Vl_tot_deducoes.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //ICMS a Recolher
                    regE110 += (vl_apurado - p.Vl_tot_deducoes) > 0 ? (vl_apurado - p.Vl_tot_deducoes).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|" : "000|";
                    //Saldo credor transportar
                    regE110 += vl_apurado < 0 ? Math.Abs(vl_apurado).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|" : "000|";
                    //Valores recolhidos/recolher extra apuracao
                    regE110 += p.Vl_tot_deb_especiais.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(regE110);
                    Qtd_linhaE++;
                    cont++;

                    if (vl_apurado > decimal.Zero)
                        GerarRegistroE116(vl_apurado, Dt_fin.Value, SpedFiscal);
                });
            if(cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E110", Qtd_linha = cont });
        }

        private static void GerarRegistroE116(decimal Vl_imposto,
                                              DateTime Dt_movimento,
                                              StringBuilder SpedFiscal)
        {
            string regE116 = "|E116|";
            //Codigo obrigacao recolher
            regE116 += "000|";//ICMS a Recolher
            //Valor obrigacao
            regE116 += Vl_imposto.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Vencimento
            regE116 += new DateTime(Dt_movimento.Year, Dt_movimento.AddMonths(1).Month, 15).ToString("ddMMyyyy") + "|";
            //Codigo da receita
            regE116 += "1015|";//Regime Mensal de Apuracao - GIA-ICMS
            //Numero Processo
            regE116 += "|";
            //Indicador processo
            regE116 += "|";
            //Descricao processo
            regE116 += "|";
            //Complemento
            regE116 += "|";
            //Mes referencia
            regE116 += Dt_movimento.ToString("ddMMyyyy").Substring(2, 6) + "|";

            SpedFiscal.AppendLine(regE116);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E116", Qtd_linha = 1 });
        }

        private static void GerarRegistroE200(string UF,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E200...");
            string regE200 = "|E200|";
            //UF
            regE200 += UF.Trim() + "|";
            //Data Inicial
            regE200 += Dt_ini.ToString("ddMMyyyy") + "|";
            //Data Final
            regE200 += Dt_fin.ToString("ddMMyyyy") + "|";

            SpedFiscal.AppendLine(regE200);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E200", Qtd_linha = 1 });
        }

        private static void GerarRegistroE210(decimal Vl_icmsSubst,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E210...");
            string regE210 = "|E210|";
            //Indicador movimento
            regE210 += "1|";//Com operacao ST
            //Saldo credor anterior
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Devolucao ST VL_DEVOL_ST
            regE210 += Vl_icmsSubst.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor ressarcimento
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Outros Creditos
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Ajuste Credito
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor retido
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Outros debitos
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Ajuste debito
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Saldo Devedor
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Total dos ajustes
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Imposto recolher
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Saldo credor ST
            regE210 += Vl_icmsSubst.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Valor recolhido/recolher
            regE210 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

            SpedFiscal.AppendLine(regE210);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E210", Qtd_linha = 1 });
        }

        private static void GerarRegistroE500(StringBuilder SpedFiscal,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E500...");
            string regE500 = "|E500|";
            //Indicador de apuração
            regE500 += "0|";
            //Data Inicial
            regE500 += Dt_ini.ToString("ddMMyyyy") + "|";
            //Data Final
            regE500 += Dt_fin.ToString("ddMMyyyy") + "|";

            SpedFiscal.AppendLine(regE500);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E500", Qtd_linha = 1 });
        }

        private static void GerarRegistroE510(List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            decimal cont = decimal.Zero;
            var sql = from a in lNf
                      where a.Vl_totalipi > decimal.Zero
                      group a by new
                      {
                          a.Cd_cfop,
                          a.Cd_stipi
                      } into g
                      select new
                      {
                          g.Key.Cd_cfop,
                          g.Key.Cd_stipi,
                          vl_operacao = (decimal?)g.Sum(p => (decimal)((decimal?)p.Vl_totalnota ?? (decimal?)0)),
                          vl_basecalcipi = (decimal?)g.Sum(p => (decimal)((decimal?)p.Vl_basecalcipi ?? (decimal?)0)),
                          vl_ipi = (decimal?)g.Sum(p => (decimal)((decimal?)p.Vl_totalipi ?? (decimal?)0))
                      };
            sql.ToList().ForEach(p =>
            {
                string regE510 = "|E510|";
                //CFOP
                regE510 += p.Cd_cfop.Trim() + "|";
                //CST IPI
                regE510 += p.Cd_stipi.Trim() + "|";
                //Valor Operacao
                regE510 += p.vl_operacao.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor Base Calc
                regE510 += p.vl_basecalcipi.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                //Valor IPI
                regE510 += p.vl_ipi.Value.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                
                SpedFiscal.AppendLine(regE510);
                Qtd_linhaE++;
                cont++;
            });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E510", Qtd_linha = cont });
        }

        private static void GerarRegistroE520(List<TRegistro_NotaFiscal> lNf,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E520...");
            decimal debitos = lNf.Where(p => p.Cd_cfop.Substring(0, 1).Equals("5") ||
                                             p.Cd_cfop.Substring(0, 1).Equals("6")).Sum(p => p.Vl_totalipi);
            decimal creditos = lNf.Where(p => p.Cd_cfop.Substring(0, 1).Equals("1") ||
                                             p.Cd_cfop.Substring(0, 1).Equals("2") ||
                                             p.Cd_cfop.Substring(0, 1).Equals("3")).Sum(p => p.Vl_totalipi);
            string regE520 = "|E520|";
            //Saldo credor do periodo anterior
            regE520 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Total debitos
            regE520 += debitos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Total Creditos
            regE520 += creditos.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Outros debitos
            regE520 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Outros creditos
            regE520 += decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Saldo Credor
            regE520 += creditos > debitos ? (creditos - debitos).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|" : 
                decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Saldo Devedor
            regE520 += debitos > creditos ? (debitos - creditos).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|" : 
                decimal.Zero.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            SpedFiscal.AppendLine(regE520);
            Qtd_linhaE++;
            RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "E520", Qtd_linha = 1 });
        }

        private static void GerarRegistroE990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro E990...");
            string regE990 = "|E990|";
            Qtd_linhaE++;
            regE990 += Qtd_linhaE.ToString() + "|";

            SpedFiscal.AppendLine(regE990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "E990", Qtd_linha = 1 });
        }

        private static void GerarBlocoE(TRegistro_DadosEmpresa rEmpresa,
                                        List<TRegistro_NotaFiscal> lNf,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            GerarRegistroE001(SpedFiscal, tEspera);
            GerarRegistroE100(Dt_ini, Dt_fin, SpedFiscal, tEspera);
            GerarRegistroE110(rEmpresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            //Buscar valor subst tributaria
            //object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
            //                new TpBusca[]
            //                {
            //                    new TpBusca()
            //                    {
            //                        vNM_Campo = "a.cd_empresa",
            //                        vOperador = "=",
            //                        vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
            //                    },
            //                    new TpBusca()
            //                    {
            //                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
            //                        vOperador = ">=",
            //                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
            //                    },
            //                    new TpBusca()
            //                    {
            //                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
            //                        vOperador = "<=",
            //                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
            //                    },
            //                    new TpBusca()
            //                    {
            //                        vNM_Campo = "a.cd_modelo",
            //                        vOperador = "in",
            //                        vVL_Busca = "('01', '1B', '04', '55')"
            //                    }
            //                }, "isnull(sum(isnull(a.Vl_totalicmssubsttrib, 0)), 0)");
            //if (obj != null)
            //{
            //    GerarRegistroE200(rEmpresa.Uf, Dt_ini.Value, Dt_fin.Value, SpedFiscal);
            //    GerarRegistroE210(decimal.Parse(obj.ToString()), SpedFiscal);
            //}
            if (rEmpresa.Tp_atividadespedfiscal.Trim().Equals("0"))
            {
                GerarRegistroE500(SpedFiscal, Dt_ini.Value, Dt_fin.Value, tEspera);
                GerarRegistroE510(lNf, SpedFiscal, tEspera);
                GerarRegistroE520(lNf, SpedFiscal, tEspera);
            }
            GerarRegistroE990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco G
        private static void GerarRegistroG001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro G001...");
            Qtd_linhaG = decimal.Zero;
            string regG001 = "|G001|";
            regG001 += "1|";

            SpedFiscal.AppendLine(regG001);
            Qtd_linhaG++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "G001", Qtd_linha = 1 });
        }

        private static void GerarRegistroG990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro G990...");
            string regG990 = "|G990|";
            Qtd_linhaG++;
            regG990 += Qtd_linhaG.ToString() + "|";

            SpedFiscal.AppendLine(regG990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "G990", Qtd_linha = 1 });
        }

        private static void GerarBlocoG(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            GerarRegistroG001(SpedFiscal, tEspera);
            GerarRegistroG990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco H
        private static void GerarRegistroH001(bool St_movimento,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro H001...");
            Qtd_linhaH = decimal.Zero;
            string regH001 = "|H001|";
            regH001 += St_movimento ? "0|" : "1|";

            SpedFiscal.AppendLine(regH001);
            Qtd_linhaH++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "H001", Qtd_linha = 1 });
        }

        private static void GerarRegistroH005(List<TRegistro_Inventario> lInventario,
                                              DateTime Dt_movimento,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro H005...");
            string regH005 = "|H005|";
            //Data Inventario
            regH005 += Dt_movimento.ToString("ddMMyyyy") + "|";
            //Valor estoque
            regH005 += lInventario.Sum(p=> p.Vl_custo).ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
            //Motivo Inventario
            regH005 += "01|";

            SpedFiscal.AppendLine(regH005);
            Qtd_linhaH++;
            RegArq.Adiciona(new TRegistro_RegArquivo(){Registro = "H005", Qtd_linha = 1});

            //Registro filho
            GerarRegistroH010(lInventario, SpedFiscal);
        }

        private static void GerarRegistroH010(List<TRegistro_Inventario> lInventario,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            lInventario.ForEach(p =>
                {
                    string regH010 = "|H010|";
                    //Produto
                    regH010 += p.Cd_produto.Trim() + "|";
                    //Unidade
                    regH010 += p.Cd_unidade.Trim() + "|";
                    //Quantidade
                    regH010 += p.Quantidade.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Valor Unitario
                    regH010 += p.Vl_medio.ToString("N6").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Custo Produto
                    regH010 += p.Vl_custo.ToString("N2").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Indicador Propriedade
                    regH010 += "0|";//Item de propriedade do informante e em seu poder
                    //Participante
                    regH010 += "|";
                    //Descricao
                    regH010 += "|";
                    //Conta Analitica
                    regH010 += p.Cd_conta.Trim() + "|";
                    //Valor do item para efeitos do Imposto de Renda.
                    regH010 += "|";

                    SpedFiscal.AppendLine(regH010);
                    Qtd_linhaH++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "H010", Qtd_linha = cont });
        }

        private static void GerarRegistroH990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro H990...");
            string regH990 = "|H990|";
            Qtd_linhaH++;
            regH990 += Qtd_linhaH.ToString() + "|";

            SpedFiscal.AppendLine(regH990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "H990", Qtd_linha = 1 });
        }

        private static void GerarBlocoH(TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_movimento,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            if (Dt_movimento.Value.Month.Equals(2))
            {
                List<TRegistro_Inventario> lInventario =
                    new TCD_Inventario().Select(rEmpresa.Cd_empresa,
                                                     new DateTime(Dt_movimento.Value.AddMonths(-2).Year,
                                                                  Dt_movimento.Value.AddMonths(-2).Month,
                                                                  DateTime.DaysInMonth(Dt_movimento.Value.AddMonths(-2).Year,
                                                                                       Dt_movimento.Value.AddMonths(-2).Month)));
                GerarRegistroH001(lInventario.FindAll(p => p.Quantidade > decimal.Zero && p.Vl_medio > decimal.Zero).Count > decimal.Zero, SpedFiscal, tEspera);
                if (lInventario.FindAll(p => p.Quantidade > decimal.Zero && p.Vl_medio > decimal.Zero).Count > decimal.Zero)
                    GerarRegistroH005(lInventario.FindAll(p => p.Quantidade > decimal.Zero && p.Vl_medio > decimal.Zero),
                                      new DateTime(Dt_movimento.Value.AddMonths(-2).Year,
                                                                      Dt_movimento.Value.AddMonths(-2).Month,
                                                                      DateTime.DaysInMonth(Dt_movimento.Value.AddMonths(-2).Year,
                                                                                           Dt_movimento.Value.AddMonths(-2).Month)),
                                      SpedFiscal, tEspera);
            }
            else
                GerarRegistroH001(false, SpedFiscal, tEspera);
            GerarRegistroH990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco K
        private static void GerarRegistroK001(bool St_movimento,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro K001...");
            Qtd_linhaK = decimal.Zero;
            string regK001 = "|K001|";
            regK001 += St_movimento ? "0|" : "1|";

            SpedFiscal.AppendLine(regK001);
            Qtd_linhaK++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "K001", Qtd_linha = 1 });
        }

        private static void GerarRegistroK100(StringBuilder SpedFiscal,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro K100...");
            string regK100 = "|K100|";
            //Data Inicial
            regK100 += Dt_ini.Value.ToString("ddMMyyyy") + "|";
            //Data Final
            regK100 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
            SpedFiscal.AppendLine(regK100);
            Qtd_linhaK++;
            RegArq.Adiciona(new TRegistro_RegArquivo { Registro = "K100", Qtd_linha = 1 });
        }

        private static void GerarRegistroK200(StringBuilder SpedFiscal, List<TRegistro_SaldoEstoque> lEstoques, DateTime? Dt_fin, ThreadEspera tEspera)
        {
            decimal cont = decimal.Zero;
            lEstoques.Where(p=> p.Quantidade > decimal.Zero)
                .ToList()
                .ForEach(p =>
                {
                    string regK200 = "|K200|";
                    //Data do Estoque Final
                    regK200 += Dt_fin.Value.ToString("ddMMyyyy") + "|";
                    //Codigo Produto
                    regK200 += p.Cd_produto.Trim() + "|";
                    //Quantidade Estoque
                    regK200 += p.Quantidade.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Tipo Estoque
                    regK200 += "0|";
                    //Codigo participante, quando estoque for de terceiro
                    regK200 += "|";
                    SpedFiscal.AppendLine(regK200);
                    Qtd_linhaK++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "K200", Qtd_linha = cont });
        }

        private static void GerarRegistroK990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro K990...");
            string regK990 = "|K990|";
            Qtd_linhaK++;
            regK990 += Qtd_linhaK.ToString() + "|";

            SpedFiscal.AppendLine(regK990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "K990", Qtd_linha = 1 });
        }

        private static void GerarBlocoK(StringBuilder SpedFiscal,
                                        TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        ThreadEspera tEspera)
        {
            List<TRegistro_SaldoEstoque> lEstoque = new List<TRegistro_SaldoEstoque>();
            if (rEmpresa.Tp_atividadespedfiscal.Trim().Equals("0"))
                lEstoque = new TCD_SaldoEstoque().Select(rEmpresa.Cd_empresa, Dt_fin.Value);
            GerarRegistroK001(lEstoque.Count(p=> p.Quantidade > 0) > 0, SpedFiscal, tEspera);
            if (lEstoque.Count(p => p.Quantidade > 0) > 0)
            {
                GerarRegistroK100(SpedFiscal, Dt_ini, Dt_fin, tEspera);
                GerarRegistroK200(SpedFiscal, lEstoque, Dt_fin, tEspera);
            }
            GerarRegistroK990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco 1
        private static void GerarRegistro1001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 1001...");
            Qtd_linha1 = decimal.Zero;
            string reg1001 = "|1001|";
            reg1001 += "0|";

            SpedFiscal.AppendLine(reg1001);
            Qtd_linha1++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1001", Qtd_linha = 1 });
        }

        private static void GerarRegistro1010(bool St_posto,
                                              bool St_vendaCartao,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 1010...");
            string reg1010 = "|1010|";
            //Exportacao
            reg1010 += "N|";
            //Informacoes credito
            reg1010 += "N|";
            //Posto combustivel
            reg1010 += St_posto ? "S|" : "N|";
            //Usina acucar/alcool
            reg1010 += "N|";
            //Obrigatorio UF
            reg1010 += "N|";
            //Energia
            reg1010 += "N|";
            //Venda Cartao
            reg1010 += St_vendaCartao ? "S|" : "N|";
            //Documentos Fiscais em Papel
            reg1010 += "N|";
            //Servicos aereos
            reg1010 += "N|";
            //GIAF1
            reg1010 += "N|";
            //GIAF3
            reg1010 += "N|";
            //GIAF4
            reg1010 += "N|";
            SpedFiscal.AppendLine(reg1010);
            Qtd_linha1++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1010", Qtd_linha = 1 });
        }

        private static void GerarRegistro1300(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin,
                                              StringBuilder SpedFiscal,
                                              ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 1300...");
            decimal cont = decimal.Zero;
            new TCD_MovCombustivel().Select(Cd_empresa, Dt_ini, Dt_fin).ForEach(p =>
                {
                    string reg1300 = "|1300|";
                    //Combustivel
                    reg1300 += p.Cd_produto.Trim() + "|";
                    //Data
                    reg1300 += p.Dt_movimento.Value.ToString("ddMMyyyy") + "|";
                    //Abertura
                    reg1300 += p.Vol_abertura.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Recebido
                    reg1300 += p.Vol_recebido.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Disponivel
                    reg1300 += p.Vol_disponivel.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Vendas
                    reg1300 += p.Vol_venda.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Escritural
                    reg1300 += p.Est_escritural.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Perda
                    reg1300 += p.Vol_perda.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Ganho
                    reg1300 += p.Vol_ganho.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Fisico
                    reg1300 += p.Vol_fechamento.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(reg1300);
                    Qtd_linha1++;
                    cont++;

                    //Registro Filhos
                    GerarRegistro1310(Cd_empresa, p.Cd_produto, p.Dt_movimento.Value, SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1300", Qtd_linha = cont });
        }

        private static void GerarRegistro1310(string Cd_empresa,
                                              string Cd_produto,
                                              DateTime Dt_movimento,
                                              StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_MovTanque().Select(Cd_empresa, Cd_produto, Dt_movimento).ForEach(p =>
                {
                    string reg1310 = "|1310|";
                    //Tanque
                    reg1310 += p.Id_tanque.ToString() + "|";
                    //Abertura
                    reg1310 += p.Vol_abertura.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Entrada
                    reg1310 += p.Vol_recebido.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Disponivel
                    reg1310 += p.Vol_disponivel.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Venda
                    reg1310 += p.Vol_venda.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Escritural
                    reg1310 += p.Est_escritural.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Perda
                    reg1310 += p.Vol_perda.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Ganho
                    reg1310 += p.Vol_ganho.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Fisico
                    reg1310 += p.Vol_fechamento.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(reg1310);
                    Qtd_linha1++;
                    cont++;

                    //Registro filho
                    GerarRegistro1320(p.Id_tanque.Value.ToString(), Dt_movimento, SpedFiscal);
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1310", Qtd_linha = cont });
        }

        public static void GerarRegistro1320(string Id_tanque,
                                             DateTime Dt_movimento,
                                             StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new TCD_VolVendas().Select(Id_tanque, Dt_movimento).ForEach(p =>
                {
                    string reg1320 = "|1320|";
                    //Numero Bico
                    reg1320 += p.Id_bico.Value.ToString() + "|";
                    //Intervencao
                    reg1320 += "|";
                    //Motivo
                    reg1320 += "|";
                    //Interventor
                    reg1320 += "|";
                    //CNPJ
                    reg1320 += "|";
                    //CPF
                    reg1320 += "|";
                    //Fechamento
                    reg1320 += p.Vol_fechamento.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Abertura
                    reg1320 += p.Vol_abertura.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Afericao
                    reg1320 += p.Vol_afericao.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
                    //Vendas
                    reg1320 += p.Vol_vendas.ToString("N3").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(reg1320);
                    Qtd_linha1++;
                    cont++;
                });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1320", Qtd_linha = cont });
        }

        public static void GerarRegistro1350(string Cd_empresa,
                                             DateTime? Dt_ini,
                                             DateTime? Dt_fin,
                                             StringBuilder SpedFiscal,
                                             ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 1350...");
            decimal cont = decimal.Zero;
            new CamadaDados.PostoCombustivel.Cadastros.TCD_BombaAbastecimento().Select(
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
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdc_bicobomba x " +
                                    "inner join tb_pdc_tanque y " +
                                    "on x.cd_empresa = y.cd_empresa " +
                                    "and x.id_tanque = y.id_tanque " +
                                    "inner join tb_est_produto z " +
                                    "on y.cd_produto = z.cd_produto " +
                                    "inner join tb_est_tpproduto w " +
                                    "on z.tp_produto = w.tp_produto " +
                                    "and isnull(w.st_lubrificante, 'N') <> 'S' " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_bomba = a.id_bomba " +
                                    "and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(x.DT_Ativacao, a.dt_cad)))) <= " +
                                    "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + "' " +
                                    "and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(x.DT_Desativacao, getdate())))) > " +
                                    "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + "')"
                    }
                }, 0, string.Empty).ForEach(p =>
                       {
                           string reg1350 = "|1350|";
                           //Serie
                           reg1350 += p.Nr_serie.Trim() + "|";
                           //Fabricante
                           reg1350 += p.Nm_fabricante.Trim() + "|";
                           //Modelo
                           reg1350 += p.Ds_modelo.Trim() + "|";
                           //Medicao
                           reg1350 += p.Tp_medicao.Trim().ToUpper().Equals("A") ? "0|" : "1|";

                           SpedFiscal.AppendLine(reg1350);
                           Qtd_linha1++;
                           cont++;

                           //Registro Filho
                           GerarRegistro1360(p.Cd_empresa,
                                             p.Id_bombastr,
                                             SpedFiscal);
                           GerarRegistro1370(p.Cd_empresa,
                                             p.Id_bombastr,
                                             Dt_ini,
                                             Dt_fin,
                                             SpedFiscal);
                       });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1350", Qtd_linha = cont });
        }

        public static void GerarRegistro1360(string Cd_empresa,
                                             string Id_bomba,
                                             StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            CamadaNegocio.PostoCombustivel.Cadastros.TCN_LacreBomba.Buscar(string.Empty,
                                                                           Id_bomba,
                                                                           Cd_empresa,
                                                                           null).ForEach(p =>
                                                                               {
                                                                                   string reg1360 = "|1360|";
                                                                                   //Numero lacre
                                                                                   reg1360 += p.Nr_lacre.Trim() + "|";
                                                                                   //Data lacre
                                                                                   reg1360 += p.Dt_aplicacaostr.SoNumero() + "|";

                                                                                   SpedFiscal.AppendLine(reg1360);
                                                                                   Qtd_linha1++;
                                                                                   cont++;
                                                                               });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1360", Qtd_linha = cont });
        }

        public static void GerarRegistro1370(string Cd_empresa,
                                             string Id_bomba,
                                             DateTime? Dt_ini,
                                             DateTime? Dt_fin,
                                             StringBuilder SpedFiscal)
        {
            decimal cont = decimal.Zero;
            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().Select(
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
                        vNM_Campo = "a.id_bomba",
                        vOperador = "=",
                        vVL_Busca = Id_bomba
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(f.st_lubrificante, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, a.dt_cad))))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate()))))",
                        vOperador = ">",
                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + "'"
                    }
                }, 0, string.Empty).ForEach(p =>
                                          {
                                              string reg1370 = "|1370|";
                                              //Bico
                                              reg1370 += p.Id_bicostr + "|";
                                              //Produto
                                              reg1370 += p.Cd_produto.Trim() + "|";
                                              //Tanque
                                              reg1370 += p.Id_tanquestr + "|";

                                              SpedFiscal.AppendLine(reg1370);
                                              Qtd_linha1++;
                                              cont++;
                                          });
            if (cont > decimal.Zero)
                RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1370", Qtd_linha = cont });
        }

        private static void GerarRegistro1990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 1990...");
            string reg1990 = "|1990|";
            Qtd_linha1++;
            reg1990 += Qtd_linha1.ToString() + "|";

            SpedFiscal.AppendLine(reg1990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "1990", Qtd_linha = 1 });
        }

        private static void GerarBloco1(TRegistro_DadosEmpresa rEmpresa,
                                        DateTime? Dt_ini,
                                        DateTime? Dt_fin,
                                        StringBuilder SpedFiscal,
                                        ThreadEspera tEspera)
        {
            GerarRegistro1001(SpedFiscal, tEspera);
            //Posto Combustivel
            bool st_posto = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rEmpresa.Cd_empresa.Trim() + "'"
                                    }
                                }, "1") != null;
            //bool st_posto = false;
            bool st_vendacartao = false;
            //Venda Cartao
            GerarRegistro1010(st_posto, st_vendacartao, SpedFiscal, tEspera);
            if (st_posto)
            {
                GerarRegistro1300(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
                GerarRegistro1350(rEmpresa.Cd_empresa, Dt_ini, Dt_fin, SpedFiscal, tEspera);
            }
            GerarRegistro1990(SpedFiscal, tEspera);
        }
        #endregion

        #region Bloco 9
        private static void GerarRegistro9001(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9001...");
            Qtd_linha9 = decimal.Zero;
            string reg9001 = "|9001|";
            reg9001 += "0|";

            SpedFiscal.AppendLine(reg9001);
            Qtd_linha9++;
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9001", Qtd_linha = 1 });            
        }

        private static void GerarRegistro9900(StringBuilder SpedFiscal, ThreadEspera tEspera)
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
                    reg9900 += p.Qtd_linha.ToString("N0").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";

                    SpedFiscal.AppendLine(reg9900);
                    Qtd_linha9++;
                    cont++;
                });
            Qtd_linha9 += 3;
            cont += 3;
            //Totalizar registro 9900
            reg9900 = "|9900|";
            reg9900 += "9900|";
            reg9900 += cont.ToString("N0").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, string.Empty).Replace('.', ',') + "|";
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

        private static void GerarRegistro9990(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9990...");
            string reg9990 = "|9990|";
            Qtd_linha9 += 2;
            reg9990 += Qtd_linha9.ToString() + "|";

            SpedFiscal.AppendLine(reg9990);
            RegArq.Adiciona(new TRegistro_RegArquivo() { Registro = "9990", Qtd_linha = 1 });
        }

        private static void GerarRegistro9999(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            if (tEspera != null)
                tEspera.Msg("Gerando registro 9999...");
            string reg9999 = "|9999|";
            reg9999 += (Qtd_linha + Qtd_linha1 + Qtd_linha9 + Qtd_linhaC + Qtd_linhaD + Qtd_linhaE + Qtd_linhaG + Qtd_linhaH + Qtd_linhaK + Qtd_linhaB).ToString() + "|";
            SpedFiscal.AppendLine(reg9999);
        }

        private static void GerarBloco9(StringBuilder SpedFiscal, ThreadEspera tEspera)
        {
            GerarRegistro9001(SpedFiscal, tEspera);
            GerarRegistro9900(SpedFiscal, tEspera);
            GerarRegistro9990(SpedFiscal, tEspera);
            GerarRegistro9999(SpedFiscal, tEspera);
        }
        #endregion

        public static string ProcessarSpedFiscal(string Cd_empresa,
                                                 DateTime? Dt_ini,
                                                 DateTime? Dt_fin,
                                                 string Finalidade,
                                                 ThreadEspera tEspera)
        {
            StringBuilder SpedFiscal = new StringBuilder();
            RegArq = new TList_RegArquivo();
            if (string.IsNullOrEmpty(Cd_empresa))
                throw new Exception("Obrigatorio informar empresa.");
            if (Dt_ini == null)
                throw new Exception("Obrigatorio informar data inicial.");
            if (Dt_fin == null)
                throw new Exception("Obrigatorio informar data final.");
            try
            {
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
                    GerarBloco0(lEmpresa[0], Finalidade, Dt_ini, Dt_fin, SpedFiscal, tEspera);
                    //Buscar listagem de nota fiscal
                    List<TRegistro_NotaFiscal> lNf = new TCD_NotaFiscal().Select(
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
                                                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                                                        vOperador = ">=",
                                                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "(case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)",
                                                        vOperador = "<=",
                                                        vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_modelo",
                                                        vOperador = "in",
                                                        vVL_Busca = "('01','1B','04','55','06', '29', '28','21', '22')"
                                                    }
                                                });
                    //Gerar Bloco B
                    GerarBlocoB(SpedFiscal, tEspera);
                    //Gerar Bloco C
                    GerarBlocoC(lEmpresa[0], lNf, Dt_ini, Dt_fin, SpedFiscal, tEspera);
                    //Gerar Bloco D
                    GerarBlocoD(lEmpresa[0], lNf, Dt_ini, Dt_fin, SpedFiscal, tEspera);
                    //Gerar Bloco E
                    GerarBlocoE(lEmpresa[0], lNf, Dt_ini, Dt_fin, SpedFiscal, tEspera);
                    //Gerar Bloco G
                    GerarBlocoG(SpedFiscal, tEspera);
                    //Gerar Bloco H
                    GerarBlocoH(lEmpresa[0], Dt_fin, SpedFiscal, tEspera);
                    //Gerar Bloco K
                    GerarBlocoK(SpedFiscal, lEmpresa[0], Dt_ini, Dt_fin, tEspera);
                    //Gerar Bloco 1
                    GerarBloco1(lEmpresa[0], Dt_ini, Dt_fin, SpedFiscal, tEspera);
                    //Gerar Bloco 9
                    GerarBloco9(SpedFiscal, tEspera);
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
