using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo71
    {
        public static int CriarRegistroTipo71(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo71> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo71().Select(
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
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao_recebimento)))",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }, 0, string.Empty);
            Linha ln = string.Empty;
            retorno.ForEach(p =>
                {
                    ln += p.Tipo.Trim();
                    //Cnpj do tomador
                    ln += p.Cnpj_tomador.Trim().SoNumero().FormatStringEsquerda(14, '0');
                    //Inscricao estadual tomador
                    ln += p.Insc_estadual_tomador.Trim().FormatStringDireita(14, ' ');
                    //Data emissao ctrc
                    ln += p.Dt_emissao_ctrc.Value.ToString("yyyyMMdd");
                    //Uf do tomador
                    ln += p.Uf_tomador.Trim().FormatStringDireita(2, ' ');
                    //Modelo do ctrc
                    ln += p.Cd_modelo_ctrc.Trim().SoNumero().FormatStringEsquerda(2, '0');
                    //Serie do ctrc
                    ln += p.Nr_serie_ctrc.Trim().FormatStringDireita(1, ' ');
                    //Subserie do ctrc
                    ln += p.Nr_subserie_ctrc.Trim().FormatStringDireita(2, ' ');
                    //Numero do ctrc
                    ln += p.Nr_ctrc.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                    //Uf do remetente
                    ln += p.Uf_remetente.Trim().FormatStringDireita(2, ' ');
                    //Cnpj do remetente
                    ln += p.Cnpj_remetente.Trim().SoNumero().FormatStringEsquerda(14, '0');
                    //Inscricao estadual do remetente
                    ln += p.Insc_estadual_remetente.Trim().FormatStringDireita(14, ' ');
                    //Data emissao da nf
                    ln += p.Dt_emissao_nf.Value.ToString("yyyyMMdd");
                    //Modelo da Nf
                    ln += p.Cd_modelo_nf.Trim().FormatStringEsquerda(2, ' ');
                    //Serie da Nf
                    ln += p.Nr_serie_nf.Trim().FormatStringDireita(3, ' ');
                    //Numero da nota fiscal
                    ln += p.Nr_notafiscal.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                    //Valor total da nota
                    ln += string.Format("{0:N2}", p.Vl_total_nf).ToString().SoNumero().FormatStringEsquerda(14, '0');
                    //Espacos em branco
                    ln += " ".FormatStringDireita(12, ' ');
                    ln += "\r\n";
                });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
