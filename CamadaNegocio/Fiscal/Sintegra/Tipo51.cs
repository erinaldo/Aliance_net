using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo51
    {
        public static int CriarRegistroTipo51(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo51> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo51().Select(
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
                    //Serie da nota fiscal
                    ln += p.Nr_serie.Trim().FormatStringDireita(3, ' ');
                    //Numero da nota fiscal
                    ln += p.Nr_notafiscal.Value.ToString().Length > 6 ?
                            p.Nr_notafiscal.Value.ToString().Substring(p.Nr_notafiscal.Value.ToString().Length - 6, 6) :
                            p.Nr_notafiscal.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                    //Cfop
                    ln += p.Cd_cfop.Trim().SoNumero().FormatStringEsquerda(4, '0');
                    //Valor total da nf
                    ln += string.Format("{0:N2}", p.Vl_totalnota).ToString().SoNumero().FormatStringEsquerda(13, '0');
                    //Valor total do IPI
                    ln += string.Format("{0:N2}", p.Vl_ipi).ToString().SoNumero().FormatStringEsquerda(13, '0');
                    //Valor isento ou nao tributado
                    ln += string.Format("{0:N2}", p.Vl_isento_naotributado).ToString().SoNumero().FormatStringEsquerda(13, '0');
                    //Valor que nao confira credito ou debito do IPI
                    ln += string.Format("{0:N2}", p.Vl_outros).ToString().SoNumero().FormatStringEsquerda(13, '0');
                    //Espacos em branco
                    ln += " ".FormatStringDireita(20, ' ');
                    //Situacao da nota fiscal quanto cancelamento
                    ln += p.Situacao.Trim().FormatStringDireita(1, ' ');
                    ln += "\r\n";
                });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
