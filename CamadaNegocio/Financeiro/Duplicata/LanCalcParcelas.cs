using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TLanCalcParcelas
    {
        private static void recalcDataVencimento(TList_Parcelas val, decimal DiasDesdobro, int index)
        {
            if(index < val.Count - 1)
                if (val[index].Dt_vencimento.Value.Date >= val[index + 1].Dt_vencimento.Value.Date)
                    for (int i = (index + 1); i < val.Count; i++)
                        val[i].Dt_vencimento = val[i - 1].Dt_vencimento.Value.AddDays(DiasDesdobro.Equals(decimal.Zero) ? 30 : Convert.ToDouble(DiasDesdobro));
        }

        public static void reajustaValorParcela(TList_Parcelas lParc, 
                                                 decimal Vl_documento,
                                                 int index)
        {
            decimal vl_parc = Math.Round((Vl_documento - lParc.Sum(p => p.Vl_parcela)) / (lParc.Count - index - 1), 2);
            for (int i = ++index; i < lParc.Count; i++)
                lParc[i].Vl_parcela += vl_parc;
            lParc[lParc.Count - 1].Vl_parcela += Vl_documento - lParc.Sum(p => p.Vl_parcela);
        }
        
        public static void ParcPedido(TList_Pedido_DT_Vencto lDt_vencto,
                                      TList_Parcelas lParc,
                                      DateTime Dt_emissao)
        {
            if (lDt_vencto.Count != lParc.Count)
            {
                lParc.Clear();
                lDt_vencto.ForEach(p=>
                    lParc.Add(new TParcelas()
                    {
                        Dt_vencimento = p.Dt_vencto,
                        Vl_parcela = p.VL_Parcela,
                        Vl_parcela_padrao = p.VL_Parcela
                    }));
            }
            for (int i = 0; i < lDt_vencto.Count; i++)
                lParc[i].Dt_vencimento = lDt_vencto[i].Dt_vencto;
        }

        public static TList_Parcelas CalcularParcelas(decimal Vl_documento, 
                                                      decimal Vl_documento_padrao,
                                                      DateTime Dt_emissao,
                                                      TList_CadCondPgto_X_Parcelas lCondParc)
        {
            TList_Parcelas lParc = new TList_Parcelas();
            lCondParc.ForEach(p=>
            {
                lParc.Add(new TParcelas()
                {
                    Dt_vencimento = Dt_emissao.AddDays(Convert.ToDouble(p.Qt_dias)),
                    Vl_parcela = Math.Round(Math.Round(Vl_documento, 2) * Math.Round(p.Pc_rateio, 2) / 100, 2),
                    Vl_parcela_padrao = Math.Round(Math.Round(Vl_documento_padrao, 2) * Math.Round(p.Pc_rateio, 2) / 100, 2)
                }
                );
            });
            return lParc;
        }

        public static TList_Parcelas CalcularParcelas(decimal Vl_documento,
                                                      decimal Vl_juro,
                                                      DateTime Dt_emissao,
                                                      decimal Qtd_parcelas,
                                                      decimal DiasDesdobro)
        {
            TList_Parcelas lParc = new TList_Parcelas();
            decimal vl_parcela = Math.Round(Vl_documento / Qtd_parcelas, 2);
            decimal vl_juroparc = Math.Round(Vl_juro / Qtd_parcelas, 2);
            for (int i = 0; i < Qtd_parcelas; i++)
            {
                Dt_emissao = Dt_emissao.AddDays(DiasDesdobro.Equals(decimal.Zero) ? 30 : Convert.ToDouble(DiasDesdobro));
                lParc.Add(new TParcelas()
                {
                    Dt_vencimento = Dt_emissao,
                    Vl_parcela = vl_parcela,
                    Vl_parcela_padrao = vl_parcela,
                    Vl_juro = vl_juroparc
                });
            }
            lParc[lParc.Count - 1].Vl_parcela += Vl_documento - lParc.Sum(p => p.Vl_parcela);
            lParc[lParc.Count - 1].Vl_juro += Vl_juro - lParc.Sum(p => p.Vl_juro);
            return lParc;
        }

        public static void ValidarDtEmissao(TList_Parcelas lParc,
                                            DateTime Dt_emissao,
                                            decimal DiasDesdobro,
                                            int index)
        {
            if (index != 0)
            {
                if (lParc[index].Dt_vencimento.Value.Date < lParc[index - 1].Dt_vencimento.Value.Date)
                    lParc[index].Dt_vencimento = lParc[index - 1].Dt_vencimento.Value.AddDays(1);
            }
            else
                if (lParc[index].Dt_vencimento.Value.Date < Dt_emissao)
                    lParc[index].Dt_vencimento = Dt_emissao;
            recalcDataVencimento(lParc, DiasDesdobro, index);
        }

        public static void RecalculaParc(TList_Parcelas lParc,
                                         decimal Vl_documento,
                                         int index)
        {
            if (lParc.Sum(p => p.Vl_parcela) != Vl_documento)
            {
                decimal vl_parc = Math.Round((Vl_documento - lParc.Sum(p => p.Vl_parcela)) / (lParc.Count - index - 1), 2);
                for (int i = ++index; i < lParc.Count; i++)
                    lParc[i].Vl_parcela += vl_parc;
                lParc[lParc.Count - 1].Vl_parcela += Vl_documento - lParc.Sum(p => p.Vl_parcela);
            }
        }
    }
}
