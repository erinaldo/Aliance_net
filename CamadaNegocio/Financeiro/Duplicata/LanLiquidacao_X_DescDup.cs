using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Duplicata;
using Utils;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TCN_LanLiquidacao_X_DescDup
    {
        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixaDesc(string Cd_empresa,
                                                                                  decimal Nr_lancto,
                                                                                  decimal Cd_parcela,
                                                                                  decimal Id_liquid,
                                                                                  int vTop,
                                                                                  string vNm_campo,
                                                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_estorno, 'N')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'S'";

            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "exists";
            filtro[1].vVL_Busca = "(select 1 from tb_fin_liquidacao_x_descdup x " +
                                  "where x.cd_contager = a.cd_contager " +
                                  "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                  "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                  "and x.nr_lancto = " + Nr_lancto.ToString() +
                                  "and x.cd_parcela = " + Cd_parcela.ToString() +
                                  "and x.id_liquid = " + Id_liquid.ToString() + ")";
            CamadaDados.Financeiro.Caixa.TCD_LanCaixa qtb_caixa = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa();
            qtb_caixa.Banco_Dados = banco;
            return qtb_caixa.Select(filtro, 0, string.Empty);
        }

        public static string GravarLiquidacao_X_DescDup(TRegistro_LanLiquidacao_X_DescDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLiquidacao_X_DescDup qtb_liq = new TCD_LanLiquidacao_X_DescDup();
            try
            {
                if (banco == null)
                {
                    qtb_liq.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liq.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_liq.GravarLiquidacao_X_DescDup(val);
                if (st_transacao)
                    qtb_liq.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_liq.deletarBanco_Dados();
            }
        }

        public static string DeletarLiquidacao_X_DescDup(TRegistro_LanLiquidacao_X_DescDup val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLiquidacao_X_DescDup qtb_liq = new TCD_LanLiquidacao_X_DescDup();
            try
            {
                if (banco == null)
                {
                    qtb_liq.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liq.Banco_Dados = banco;
                //Deletar registro
                qtb_liq.DeletarLiquidacao_X_DescDup(val);
                if (st_transacao)
                    qtb_liq.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_liq.deletarBanco_Dados();
            }
        }
    }
}
