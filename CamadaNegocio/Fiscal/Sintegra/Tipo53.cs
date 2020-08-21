using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Tipo53
    {
        public static int CriarRegistroTipo53(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo53> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo53().Select(
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
            Linha ln = string.Empty;
            retorno.ForEach(p =>
            {
                //Tipo Registro
                ln += p.Tipo.Trim();
                //Cnpj do remetente na entrada ou do destinatario na saida
                ln += p.Cnpj.Trim().SoNumero().FormatStringEsquerda(14, '0');
                //Inscricao estadual do remetente na entrada ou do destinatario na saida
                ln += p.Insc_estadual.Trim().FormatStringDireita(14, ' ');
                //Data emissao na saida ou recebimento na entrada
                ln += p.Dt_emissao_recebimento.Value.ToString("yyyyMMdd");
                //Sigla unidade da federacao do remetente na entrada ou do destinatario na saida
                ln += p.Uf.Trim().FormatStringDireita(2, ' ');
                //Modelo documento Fiscal
                ln += p.Cd_modelo.Trim().FormatStringEsquerda(2, ' ');
                //Serie da nota fiscal
                ln += p.Nr_serie.Trim().FormatStringDireita(3, ' ');
                //Numero da nota fiscal
                ln += p.Nr_notafiscal.Value.ToString().Length > 6 ?
                        p.Nr_notafiscal.Value.ToString().Substring(p.Nr_notafiscal.Value.ToString().Length - 6, 6) :
                        p.Nr_notafiscal.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                //Cfop
                ln += p.Cd_cfop.Trim().SoNumero().FormatStringEsquerda(4, '0');
                //Tipo emissao Nota P-Propria T-Terceiro
                ln += p.Tp_nota.Trim();
                //Valor Base Calc ICMS
                ln += string.Format("{0:N2}", p.Vl_basecalc).ToString().SoNumero().FormatStringEsquerda(13, '0');
                //Valor ICMS
                ln += string.Format("{0:N2}", p.Vl_icms).ToString().SoNumero().FormatStringEsquerda(13, '0');
                //Valor despesas
                ln += string.Format("{0:N2}", p.Vl_despesas).ToString().SoNumero().FormatStringEsquerda(13, '0');
                //Situacao da Nota
                ln += p.Situacao.Trim().FormatStringDireita(1, ' ');
                //Codigo tipo antecipacao tributaria
                ln += " ";
                //Espacos em branco
                ln += " ".FormatStringDireita(29, ' ');

                ln += "\r\n";
            });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
