using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo70
    {
        public static int CriarRegistroTipo70(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo70> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo70().Select(
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
                    //Cnpj
                    ln += p.Cnpj.Trim().SoNumero().FormatStringEsquerda(14, '0');
                    //Inscricao estadual
                    ln += p.Insc_estadual.Trim().FormatStringDireita(14, ' ');
                    //Data emissao / utilizacao
                    ln += p.Dt_emissao_utilizacao.Value.ToString("yyyyMMdd");
                    //Uf
                    ln += p.Uf.Trim().FormatStringDireita(2, ' ');
                    //Modelo Documento
                    ln += p.Cd_modelo.Trim().SoNumero().FormatStringEsquerda(2, '0');
                    //Serie Documento
                    ln += p.Nr_Serie.Trim().FormatStringDireita(1, ' ');
                    //Sub serie documento
                    ln += p.Nr_subserie.Trim().FormatStringDireita(2, ' ');
                    //Numero documento
                    ln += p.Nr_documento.Value.ToString().SoNumero().FormatStringEsquerda(6, '0');
                    //Cfop
                    ln += p.Cd_cfop.Trim().SoNumero().FormatStringEsquerda(4, '0');
                    //Valor total do documento
                    ln += string.Format("{0:N2}", p.Vl_documento).SoNumero().FormatStringEsquerda(13, '0');
                    //Valor da base de calculo
                    ln += string.Format("{0:N2}", p.Vl_basecalcicms).SoNumero().FormatStringEsquerda(14, '0');
                    //Valor do ICMS
                    ln += string.Format("{0:N2}", p.Vl_icms).SoNumero().FormatStringEsquerda(14, '0');
                    //Valor isento ou nao tributado
                    ln += string.Format("{0:N2}", decimal.Zero).SoNumero().FormatStringEsquerda(14, '0');
                    //Valor que nao confira debito ou credito do ICMS
                    ln += string.Format("{0:N2}", decimal.Zero).SoNumero().FormatStringEsquerda(14, '0');
                    //Tipo de frete
                    ln += p.Tp_frete == CamadaDados.Fiscal.Sintegra.Modalidade_frete.CIF ? "1" : p.Tp_frete == CamadaDados.Fiscal.Sintegra.Modalidade_frete.FOB ? "2" : "0";
                    //Situacao do documento
                    ln += p.Situacao.Trim().FormatStringDireita(1, ' ');
                    ln += "\r\n";
                });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }   
}
