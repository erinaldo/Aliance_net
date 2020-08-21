using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo50
    {
        public static int CriarRegistroTipo50(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo50> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo50().Select(
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
                ln += p.Insc_estadual.FormatStringDireita(14, ' ');
                //Data de emissao na saida ou de entrada no recebimento
                ln += p.Dt_emissao_recebimento.Value.ToString("yyyyMMdd");
                //Sigla estado do remetente na entrada ou do destinatario na saida
                ln += p.Uf.Trim().FormatStringDireita(2, ' ');
                //Modelo da Nota Fiscal
                ln += p.Cd_modelo.Trim().SoNumero().FormatStringEsquerda(2, '0');
                //Serie da nota fiscal
                ln += p.Nr_serie.Trim().FormatStringDireita(3, ' ');
                //Numero da nota fiscal
                ln += p.Nr_notafiscal.Value.ToString().Length > 6 ?
                        p.Nr_notafiscal.Value.ToString().Substring(p.Nr_notafiscal.Value.ToString().Length - 6, 6) :
                        p.Nr_notafiscal.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                //Codigo do Cfop
                ln += p.Cd_cfop.Trim().SoNumero().FormatStringEsquerda(4, '0');
                //Tipo da Nota P-Propria T-Terceiro
                ln += p.Tp_nota.Trim().FormatStringDireita(1, ' ');
                //Valor total da nota fiscal
                ln += string.Format("{0:N2}", p.Vl_totalnota).SoNumero().FormatStringEsquerda(13, '0');
                //Base de calculo do icms
                ln += string.Format("{0:N2}", p.Vl_basecalcicms).SoNumero().FormatStringEsquerda(13, '0');
                //Valor do ICMS 
                ln += string.Format("{0:N2}", p.Vl_icms).SoNumero().FormatStringEsquerda(13, '0');
                //Valor Isento ou nao tributado
                ln += string.Format("{0:N2}", p.Vl_isento_naotributado).SoNumero().FormatStringEsquerda(13, '0');
                //Valor que nao confira debito ou credito de icms
                ln += string.Format("{0:N2}", p.Vl_outros).SoNumero().FormatStringEsquerda(13, '0');
                //Aliquota do ICMS
                ln += string.Format("{0:N2}", p.Pc_aliquota_icms).SoNumero().FormatStringEsquerda(4, '0');
                //Situacao da nota fiscal quanto ao cancelamento
                ln += p.Situacao_nf.Trim().FormatStringDireita(1, ' ');
                ln += "\r\n";
            });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
