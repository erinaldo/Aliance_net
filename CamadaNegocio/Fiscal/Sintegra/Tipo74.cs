using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Tipo74
    {
        public static int CriarRegistroTipo74(string Cd_empresa,
                                              DateTime Dt_fin,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo74> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo74().Select(Cd_empresa, Dt_fin.ToString());
            Linha ln = string.Empty;
            retorno.ForEach(p =>
            {
                //Tipo
                ln += p.Tipo.Trim();
                //Data Inventario
                ln += Dt_fin.ToString("yyyyMMdd");
                //Codigo Produto
                ln += p.Cd_produto.Trim().FormatStringDireita(14, ' ');
                //Quantidade Produto
                ln += string.Format("{0:N3}", p.Quantidade).ToString().SoNumero().FormatStringEsquerda(13, '0');
                //Valor Produto
                ln += string.Format("{0:N2}", p.Vl_produto).ToString().SoNumero().FormatStringEsquerda(13, '0');
                //Codigo de posse
                ln += "1";//Mercadoria de propriedade da empresa
                //CNPJ do Possuidor
                ln += "0".FormatStringEsquerda(14, '0');
                //Insc. do Possuidor
                ln += "".FormatStringDireita(14, ' ');
                //UF Possuidor
                ln += "".FormatStringDireita(2, ' ');
                //Espacos Brancos
                ln += "".FormatStringDireita(45, ' ');
                ln += "\r\n";
            });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
