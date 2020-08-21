using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class Tipo75
    {
        public string Tipo
        {
            get
            {
                return "75";
            }
        }
        public DateTime? Dt_inicial
        { get; set; }
        public DateTime? Dt_final
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ncm
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla
        { get; set; }
        public decimal Pc_aliquota_ipi
        { get; set; }
        public decimal Pc_aliquota_icms
        { get; set; }
        public decimal Pc_reducao_basecalcicms
        { get; set; }
        public decimal Base_calc_icms_substtrib
        { get; set; }

        public Tipo75()
        {
            this.Dt_inicial = null;
            this.Dt_final = null;
            this.Cd_produto = string.Empty;
            this.Ncm = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla = string.Empty;
            this.Pc_aliquota_ipi = decimal.Zero;
            this.Pc_aliquota_icms = decimal.Zero;
            this.Pc_reducao_basecalcicms = decimal.Zero;
            this.Base_calc_icms_substtrib = decimal.Zero;
        }
    }

    public class TCN_Tipo75
    {
        public static int CriarRegistroTipo75(string Cd_empresa,
                                              DateTime Dt_ini,
                                              DateTime Dt_fin,
                                              DateTime? Dt_inventario,
                                              ref string Ret)
        {
            List<CamadaDados.Fiscal.Sintegra.Tipo75> retorno = new CamadaDados.Fiscal.Sintegra.TCD_Tipo75().Select(Cd_empresa, Dt_ini, Dt_fin, Dt_inventario);
            Linha ln = string.Empty;
            retorno.ForEach(p =>
                {
                    //Tipo
                    ln += p.Tipo.Trim();
                    //Data inicial
                    ln += Dt_ini.ToString("yyyyMMdd");
                    //Data final
                    ln += Dt_fin.ToString("yyyyMMdd");
                    //Codigo Produto
                    ln += p.Cd_produto.Trim().FormatStringDireita(14, ' ');
                    //Codigo NCM
                    ln += p.Ncm.Trim().FormatStringDireita(8, ' ');
                    //Descricao do produto
                    ln += p.Ds_produto.Trim().FormatStringDireita(53, ' ');
                    //Unidade de Medida
                    ln += p.Sigla.Trim().FormatStringDireita(6, ' ');
                    //Aliquota de IPI do produto
                    ln += string.Format("{0:N2}", p.Pc_aliquota_ipi).ToString().SoNumero().FormatStringEsquerda(5, '0');
                    //Aliquota do ICMS do produto
                    ln += string.Format("{0:N2}", p.Pc_aliquota_icms).ToString().SoNumero().FormatStringEsquerda(4, '0');
                    //Reducao da base de calculo do icms
                    ln += string.Format("{0:N2}", p.Pc_reducao_basecalcicms).ToString().SoNumero().FormatStringEsquerda(5, '0');
                    //Base de calculo do icms substituicao tributaria
                    ln += string.Format("{0:N2}", p.Base_calc_icms_substtrib).ToString().SoNumero().FormatStringEsquerda(13, '0');
                    ln += "\r\n";
                });
            Ret = ln.ToString();
            return retorno.Count;
        }
    }
}
