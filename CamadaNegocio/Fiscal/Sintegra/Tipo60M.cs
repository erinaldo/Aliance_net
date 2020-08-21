using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Tipo60M
    {
        public static int CriarRegistroTipo60M(string Cd_empresa,
                                               DateTime Dt_ini,
                                               DateTime Dt_fin,
                                               bool St_tipo60D,
                                               bool St_tipo60I,
                                               ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo60M> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo60M().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_mapa)))",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_mapa)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + "'"
                    }
                }, 0, string.Empty);
            Linha ln = string.Empty;
            int cont = 0;
            retorno.ForEach(p =>
            {
                //Tipo Registro
                ln += p.Tipo.Trim();
                //Sub Tipo
                ln += p.Subtipo.Trim();
                //Data de emissao na saida ou de entrada no recebimento
                ln += p.Dt_emissao.Value.ToString("yyyyMMdd");
                //Numero de serie do equipamento
                ln += p.Nr_serie_equipamento.Trim().FormatStringDireita(20, ' ');
                //Id equipamento
                ln += p.Id_equipamento.Value.ToString().FormatStringEsquerda(3, '0');
                //Modelo da Nota Fiscal
                ln += p.Cd_modelo.Trim().SoNumero().FormatStringEsquerda(2, '0');
                //COO Inicial
                ln += p.Nr_coo_inicial.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                //COO Final
                ln += p.Nr_coo_final.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                //Contador Reducao Z
                ln += p.Contador_reducaoZ.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                //Contador Reinicio Operacao
                ln += p.Contador_reinicio_operacao.Value.ToString().SoNumero().FormatStringEsquerda(3, '0');
                //Valor venda bruta
                ln += string.Format("{0:N2}", p.Vl_vendabruta).SoNumero().FormatStringEsquerda(16, '0');
                //Valor Total Geral
                ln += string.Format("{0:N2}", p.Vl_totalgeral).SoNumero().FormatStringEsquerda(16, '0');
                //Brancos
                ln += "".FormatStringDireita(37, ' ');
                ln += "\r\n";
                cont++;
                //Buscar registro Analiticos
                new CamadaDados.Fiscal.Sintegra.TCD_Tipo60A().Select(p.Id_mapa.Value.ToString(), p.Id_equipamento.Value.ToString()).ForEach(v =>
                    {
                        //Tipo Registro
                        ln += v.Tipo.Trim();
                        //Sub Tipo
                        ln += v.Subtipo.Trim();
                        //Data de emissao na saida ou de entrada no recebimento
                        ln += v.Dt_emissao.Value.ToString("yyyyMMdd");
                        //Numero de serie do equipamento
                        ln += v.Nr_serie_equipamento.Trim().FormatStringDireita(20, ' ');
                        //Situacao Tributaria
                        ln += v.Situacao_tributaria.FormatStringDireita(4, ' ');
                        //Valor Acumulado no Totalizador
                        ln += string.Format("{0:N2}", v.Vl_totalizador).SoNumero().FormatStringEsquerda(12, '0');
                        //Brancos
                        ln += "".FormatStringDireita(79, ' ');
                        ln += "\r\n";
                        cont++;
                    });
                //Buscar Lista de Cupons
                List<CamadaDados.Fiscal.Sintegra.Tipo60> l60 = new List<CamadaDados.Fiscal.Sintegra.Tipo60>();
                if (St_tipo60D || St_tipo60I)
                    l60 = new CamadaDados.Fiscal.Sintegra.TCD_Tipo60().Select(
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
                                    vNM_Campo = "a.id_equipamento",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_equipamento.Value.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.ID_COO_ECF",
                                    vOperador = "between",
                                    vVL_Busca = p.Nr_coo_inicial.Value.ToString() + " and " + p.Nr_coo_final.Value.ToString()
                                }
                            }, 0, string.Empty);

                if (St_tipo60D)
                {
                    var sql = from a in l60
                              group a by new
                              {
                                  a.Cd_produto,
                                  a.Pc_aliquota,
                                  a.Situacao_tributaria,
                                  a.St_substtrib
                              } into g
                              select new
                              {
                                  g.Key.Cd_produto,
                                  g.Key.Pc_aliquota,
                                  g.Key.Situacao_tributaria,
                                  g.Key.St_substtrib,
                                  Quantidade = (g.Sum(v => ((System.Decimal?)v.Quantidade ?? (System.Decimal?)0)) ?? 0),
                                  Vl_subtotal = (g.Sum(v=> ((System.Decimal?)v.Vl_subtotal ?? (System.Decimal?)0)) ?? 0),
                                  Vl_basecalc = (g.Sum(v=> ((System.Decimal?)v.Vl_basecalc ?? (System.Decimal?)0)) ?? 0),
                                  Vl_icms = (g.Sum(v=> ((System.Decimal?)v.Vl_icms ?? (System.Decimal?)0)) ?? 0)
                              };
                    sql.ToList().ForEach(v =>
                            {
                                //Tipo Registro
                                ln += "60";
                                //Sub Tipo
                                ln += "D";
                                //Data de emissao na saida ou de entrada no recebimento
                                ln += p.Dt_emissao.Value.ToString("yyyyMMdd");
                                //Numero de serie do equipamento
                                ln += p.Nr_serie_equipamento.Trim().FormatStringDireita(20, ' ');
                                //Codigo Produto
                                ln += v.Cd_produto.FormatStringDireita(14, ' ');
                                //Quantidade Produto
                                ln += string.Format("{0:N3}", v.Quantidade).SoNumero().FormatStringEsquerda(13, '0');
                                //Valor Produto
                                ln += string.Format("{0:N2}", v.Vl_subtotal).SoNumero().FormatStringEsquerda(16, '0');
                                //Base Calculo
                                ln += string.Format("{0:N2}", v.Vl_basecalc).SoNumero().FormatStringEsquerda(16, '0');
                                //Situacao Tributaria/Aliquota
                                ln += v.Situacao_tributaria;
                                //Valor ICMS
                                ln += string.Format("{0:N2}", v.Vl_icms).SoNumero().FormatStringEsquerda(13, '0');
                                //Brancos
                                ln += "".FormatStringDireita(19, ' ');
                                ln += "\r\n";

                                cont++;
                            });
                }
                if (St_tipo60I)
                    l60.ForEach(v =>
                            {
                                //Tipo Registro
                                ln += "60";
                                //Sub Tipo
                                ln += "I";
                                //Data de emissao na saida ou de entrada no recebimento
                                ln += p.Dt_emissao.Value.ToString("yyyyMMdd");
                                //Numero de serie do equipamento
                                ln += p.Nr_serie_equipamento.Trim().FormatStringDireita(20, ' ');
                                //Modelo Documento Fiscal
                                ln += v.Cd_modelo.Trim().FormatStringDireita(2, ' ');
                                //COO Cupom
                                ln += v.Id_coo_ecf.Value.ToString().FormatStringEsquerda(6, '0');
                                //Numero ordem do item
                                ln += v.Nr_sequencial_ecf.Value.ToString().FormatStringEsquerda(3, '0');
                                //Codigo Produto
                                ln += v.Cd_produto.FormatStringDireita(14, ' ');
                                //Quantidade Produto
                                ln += string.Format("{0:N3}", v.Quantidade).SoNumero().FormatStringEsquerda(13, '0');
                                //Valor Produto
                                ln += string.Format("{0:N2}", v.Vl_subtotal).SoNumero().FormatStringEsquerda(13, '0');
                                //Base Calculo
                                ln += string.Format("{0:N2}", v.Vl_basecalc).SoNumero().FormatStringEsquerda(12, '0');
                                //Situacao Tributaria/Aliquota
                                ln += v.Situacao_tributaria;
                                //Valor ICMS
                                ln += string.Format("{0:N2}", v.Vl_icms).SoNumero().FormatStringEsquerda(12, '0');
                                //Brancos
                                ln += "".FormatStringDireita(16, ' ');
                                ln += "\r\n";

                                cont++;
                            });
            });
            Ret = ln.ToString();
            return cont;
        }
    }
}
