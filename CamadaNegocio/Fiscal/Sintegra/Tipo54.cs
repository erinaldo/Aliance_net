using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo54
    {
        public static int CriarRegistroTipo54(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo54> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo54().Select(
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
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao_recebimento)))",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao_recebimento)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + "'"
                    }
                }, 0, string.Empty);
            if (retorno.Count > 0)
            {
                if (retorno.Count > 0)
                {
                    Linha ln = string.Empty;
                    retorno.ForEach(p =>
                        {
                            //Tipo Registro
                            ln += p.Tipo.Trim();
                            //Cnpj
                            ln += p.Cnpj.Trim().SoNumero().FormatStringEsquerda(14, '0');
                            //Modelo Nf
                            ln += p.Cd_modelo.Trim().SoNumero().FormatStringEsquerda(2, '0');
                            //Serie Nf
                            ln += p.Nr_serie.Trim().FormatStringDireita(3, ' ');
                            //Numero Nf
                            ln += p.Nr_notafiscal.Value.ToString().Length > 6 ?
                                    p.Nr_notafiscal.Value.ToString().Substring(p.Nr_notafiscal.Value.ToString().Length - 6, 6) :
                                    p.Nr_notafiscal.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                            //Cfop
                            ln += p.Cd_cfop.Trim().SoNumero().FormatStringEsquerda(4, '0');
                            //Codigo Situacao Tributaria
                            ln += p.Cd_st.Trim().SoNumero().FormatStringEsquerda(3, '0');
                            //Codigo do Item
                            ln += p.Id_nfitem.Value.ToString().SoNumero().FormatStringEsquerda(3, '0');
                            //Codigo do produto
                            ln += p.Cd_produto.Trim().FormatStringDireita(14, ' ');
                            //Quantidade
                            ln += string.Format("{0:N3}", p.Quantidade).ToString().SoNumero().FormatStringEsquerda(11, '0');
                            //SubTotal
                            ln += string.Format("{0:N2}", p.Vl_subtotal).ToString().SoNumero().FormatStringEsquerda(12, '0');
                            //Valor do desconto
                            ln += string.Format("{0:N2}", decimal.Zero).ToString().SoNumero().FormatStringEsquerda(12, '0');
                            //Valor Base Calc ICMS
                            ln += string.Format("{0:N2}", p.Vl_basecalc_icms).ToString().SoNumero().FormatStringEsquerda(12, '0');
                            //Base Calc ICMS SubstTrib
                            ln += string.Format("{0:N2}", p.Vl_basecalc_icmssubsttrib).ToString().SoNumero().FormatStringEsquerda(12, '0');
                            //Valor IPI
                            ln += string.Format("{0:N2}", decimal.Zero).ToString().SoNumero().FormatStringEsquerda(12, '0');
                            //% ICMS
                            ln += string.Format("{0:N2}", p.Pc_aliquotaicms).ToString().SoNumero().FormatStringEsquerda(4, '0');
                            ln += "\r\n";
                        });
                    Ret = ln.ToString();
                }
            }
            return retorno.Count;
        }
    }
}
