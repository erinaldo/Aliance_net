using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fiscal.IDominio;

namespace CamadaNegocio.Fiscal.IDominio
{
    public class TCN_IDominioClifor
    {
        public static string GerarRegistroCliente(string Cd_empresa,
                                                  DateTime Dt_ini,
                                                  DateTime Dt_fin)
        {
            StringBuilder ln = new StringBuilder();
            new TCD_IDominioClifor().SelectClifor(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.ToString("yyyyMMdd")) + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.ToString("yyyyMMdd")) + " 23:59:59'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "b.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }).OrderBy(p => p.Tipo).ToList().ForEach(p =>
                    {
                        //Tipo Registro
                        ln.Append(p.Tipo.Trim().FormatStringDireita(2, ' '));
                        //Codigo empresa dominio
                        ln.Append(p.Cd_empresa.Trim().FormatStringEsquerda(7, '0'));
                        //Sigla do Estado
                        ln.Append(p.Sg_uf.Trim().FormatStringDireita(2, ' '));
                        //Codigo da conta
                        ln.Append(p.Cd_conta.FormatStringEsquerda(7, '0'));
                        //Codigo da cidade
                        ln.Append(p.Cd_cidade.Trim().Remove(p.Cd_cidade.Trim().Length - 2, 2).FormatStringEsquerda(7, '0'));
                        //Nome Reduzido
                        ln.Append(p.Nm_cliforreduzido.Trim().FormatStringDireita(10, ' '));
                        //Nome clifor
                        ln.Append(p.Nm_clifor.Trim().FormatStringDireita(40, ' '));
                        //Endereco
                        ln.Append(p.Ds_endereco.Trim().FormatStringDireita(40, ' '));
                        //Numero 
                        ln.Append(p.Numero.SoNumero().FormatStringEsquerda(7, '0'));
                        //Espacos em branco
                        ln.Append("".FormatStringDireita(30, ' '));
                        //Cep
                        ln.Append(p.Cep.Trim().Replace(".", "").Replace(",", "").FormatStringDireita(8, ' '));
                        //Cnpj/Cpf
                        ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? p.Cnpj.SoNumero().FormatStringDireita(14, ' ') : p.Cpf.SoNumero().FormatStringDireita(14, ' '));
                        //Inscricao Estadual
                        ln.Append(p.Insc_estadual.SoNumero().FormatStringDireita(20, ' '));
                        //Fone
                        ln.Append("".FormatStringDireita(14, ' '));
                        //Fax
                        ln.Append("".FormatStringDireita(14, ' '));
                        //Agropecuario
                        ln.Append(p.St_agropecuaria.Trim().FormatStringDireita(1, ' '));
                        //ICMS
                        ln.Append("S");
                        //Tipo de Inscricao
                        ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? "1" : !string.IsNullOrEmpty(p.Cpf) ? "2" : "4");
                        //Inscricao Municipal
                        ln.Append("".FormatStringDireita(20, ' '));
                        //Bairro
                        ln.Append(p.Bairro.Trim().FormatStringDireita(20, ' '));
                        //DDD Fone
                        ln.Append("".FormatStringDireita(4, ' '));
                        //Aliquota do ICMS
                        ln.Append(decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).SoNumero().FormatStringEsquerda(5, '0'));
                        //Codigo Pais
                        ln.Append(p.Cd_pais.FormatStringEsquerda(7, '0'));
                        //Inscricao Suframa
                        ln.Append("".FormatStringDireita(9, ' '));
                        //Espacos em branco
                        ln.Append("".FormatStringDireita(100, ' '));

                        ln.AppendLine();
                    });
            return ln.ToString();
        }

        public static string GerarRegistroFornecedor(string Cd_empresa,
                                                     DateTime Dt_ini,
                                                     DateTime Dt_fin)
        {
            StringBuilder ln = new StringBuilder();
            new TCD_IDominioClifor().SelectClifor(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.ToString("yyyyMMdd")) + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.ToString("yyyyMMdd")) + " 23:59:59'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "b.tp_movimento",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    }
                }).OrderBy(p => p.Tipo).ToList().ForEach(p =>
                {
                    //Tipo Registro
                    ln.Append(p.Tipo.Trim().FormatStringDireita(2, ' '));
                    //Codigo empresa dominio
                    ln.Append(p.Cd_empresa.Trim().FormatStringEsquerda(7, '0'));
                    //Sigla do Estado
                    ln.Append(p.Sg_uf.Trim().FormatStringDireita(2, ' '));
                    //Codigo da conta
                    ln.Append(p.Cd_conta.FormatStringEsquerda(7, '0'));
                    //Codigo da cidade
                    ln.Append(p.Cd_cidade.Trim().Remove(p.Cd_cidade.Trim().Length - 2, 2).FormatStringEsquerda(7, '0'));
                    //Nome Reduzido
                    ln.Append(p.Nm_cliforreduzido.Trim().FormatStringDireita(10, ' '));
                    //Nome clifor
                    ln.Append(p.Nm_clifor.Trim().FormatStringDireita(40, ' '));
                    //Endereco
                    ln.Append(p.Ds_endereco.Trim().Trim().FormatStringDireita(40, ' '));
                    //Numero 
                    ln.Append(p.Numero.SoNumero().FormatStringEsquerda(7, '0'));
                    //Espacos em branco
                    ln.Append("".FormatStringDireita(30, ' '));
                    //Cep
                    ln.Append(p.Cep.Trim().Replace(".", "").Replace(",", "").FormatStringDireita(8, ' '));
                    //Cnpj/Cpf
                    ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? p.Cnpj.SoNumero().FormatStringDireita(14, ' ') : p.Cpf.SoNumero().FormatStringDireita(14, ' '));
                    //Inscricao Estadual
                    ln.Append(p.Insc_estadual.SoNumero().FormatStringDireita(20, ' '));
                    //Fone
                    ln.Append("".FormatStringDireita(14, ' '));
                    //Fax
                    ln.Append("".FormatStringDireita(14, ' '));
                    //Agropecuario
                    ln.Append(p.St_agropecuaria.Trim().FormatStringDireita(1, ' '));
                    //ICMS
                    ln.Append("S");
                    //Tipo de Inscricao
                    ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? "1" : !string.IsNullOrEmpty(p.Cpf) ? "2" : "4");
                    //Inscricao Municipal
                    ln.Append("".FormatStringDireita(20, ' '));
                    //Bairro
                    ln.Append(p.Bairro.Trim().FormatStringDireita(20, ' '));
                    //DDD Fone
                    ln.Append("".FormatStringDireita(4, ' '));
                    //Codigo Pais
                    ln.Append(p.Cd_pais.Trim().FormatStringEsquerda(7, '0'));
                    //Inscricao Suframa
                    ln.Append("".FormatStringDireita(9, ' '));
                    //Espacos em branco
                    ln.Append("".FormatStringDireita(100, ' '));
                    ln.AppendLine();
                });
            return ln.ToString();
        }

        public static string GerarRegistroRemetenteDest(string Cd_empresa,
                                                      DateTime Dt_ini,
                                                      DateTime Dt_fin)
        {
            StringBuilder ln = new StringBuilder();
            new TCD_IDominioClifor().SelectRemetenteDest(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.ToString("yyyyMMdd")) + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_emissao_recebimento",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.ToString("yyyyMMdd")) + " 23:59:59'"
                    },
                }).ForEach(p =>
                    {
                        //Tipo Registro
                        ln.Append(p.Tipo.Trim().FormatStringDireita(2, ' '));
                        //Codigo empresa dominio
                        ln.Append(p.Cd_empresa.Trim().FormatStringEsquerda(7, '0'));
                        //Sigla Estado
                        ln.Append(p.Sg_uf.Trim().FormatStringDireita(2, ' '));
                        //Codigo Municipio
                        ln.Append(p.Cd_cidade.Trim().Remove(p.Cd_cidade.Trim().Length - 2, 2).FormatStringEsquerda(7, '0'));
                        //Nome clifor
                        ln.Append(p.Nm_clifor.Trim().FormatStringDireita(40, ' '));
                        //Endereco Clifor
                        ln.Append(p.Ds_endereco.Trim().FormatStringDireita(80, ' '));
                        //Inscricao Estadual
                        ln.Append(p.Insc_estadual.SoNumero().FormatStringDireita(20, '0'));
                        //Tipo de Inscricao
                        ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? "1" : !string.IsNullOrEmpty(p.Cpf) ? "2" : "4");
                        //Cnpj/Cpf
                        ln.Append(!string.IsNullOrEmpty(p.Cnpj) ? p.Cnpj.SoNumero().FormatStringDireita(14, ' ') : p.Cpf.SoNumero().FormatStringDireita(14, ' '));
                        //Espacos brancao
                        ln.Append("".FormatStringDireita(100, ' '));
                        ln.AppendLine();
                    });
            return ln.ToString();
        }
    }
}
