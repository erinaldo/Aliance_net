using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Tipo60R
    {
        public static int CriarRegistroTipo60R(string Cd_empresa,
                                               DateTime Dt_ini,
                                               DateTime Dt_fin,
                                               ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo60R> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo60R().Select(
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
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + "'"
                    }
                }, 0, string.Empty);
            Linha ln = string.Empty;
            retorno.ForEach(p =>
            {
                //Tipo Registro
                ln += p.Tipo.Trim();
                //Sub Tipo
                ln += p.Subtipo.Trim();
                //Mes e Ano de emissao do documento
                ln += new DateTime(p.Ano, p.Mes, 1).ToString("ddMMyyyy").Substring(2, 6);
                //Codigo Produto
                ln += p.Cd_produto.FormatStringDireita(14, ' ');
                //Quantidade Produto
                ln += string.Format("{0:N3}", p.Quantidade).SoNumero().FormatStringEsquerda(13, '0');
                //Valor Produto
                ln += string.Format("{0:N2}", p.Vl_subtotal).SoNumero().FormatStringEsquerda(16, '0');
                //Base Calculo
                ln += string.Format("{0:N2}", p.Vl_basecalc).SoNumero().FormatStringEsquerda(16, '0');
                //Situacao Tributaria/Aliquota
                ln += p.Situacao_trib;
                //Brancos
                ln += "".FormatStringDireita(54, ' ');
                ln += "\r\n";
            });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
