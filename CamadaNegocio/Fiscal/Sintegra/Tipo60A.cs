using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Tipo60A
    {
        public static int CriarRegistroTipo60A(string Cd_empresa,
                                               DateTime Dt_ini,
                                               DateTime Dt_fin,
                                               ref string Ret)
        {
            /*List<CamadaDados.Fiscal.Sintegra.Tipo60A> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo60A().Select(
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
                        vNM_Campo = "a.dt_mapa",
                        vOperador = ">=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.dt_mapa",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'"
                    }
                }, 0, string.Empty);
            Linha ln = string.Empty;
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
                //Situacao Tributaria
                ln += p.Situacao_tributaria.FormatStringDireita(4, ' ');
                //Valor Acumulado no Totalizador
                ln += string.Format("{0:N2}", p.Vl_totalizador).SoNumero().FormatSringEsquerda(12, '0');
                //Brancos
                ln += "".FormatStringDireita(79, ' ');
                ln += "\r\n";
            });
            Ret = ln.ToString();
            return retorno.Count;*/
            return 0;
        }
    }
}
