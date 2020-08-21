using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    #region "Condição de Pagamento"
    public class TCN_CadCondPgto
    {
        public static TList_CadCondPgto Buscar(string vCd_condpgto,
                                               string vDs_condpgto,
                                               string vCd_portador,
                                               string vCd_moeda,
                                               string vSt_comentrada,
                                               string vCd_juro,
                                               decimal vQt_parcelas,
                                               decimal vQt_diasdesdobro,
                                               string vSt_venctoemferiado,
                                               string vSt_solicitardtvencto,
                                               int vTop,
                                               string vNm_campo,
                                               BancoDados.TObjetoBanco banco)
        { 
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CondPgto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_condpgto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vDs_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_CondPgto";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_condpgto.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (vCd_portador.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Portador";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_portador.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_moeda.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Moeda";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moeda.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSt_comentrada.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_ComEntrada";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_comentrada.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_juro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Juro";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_juro.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vQt_parcelas > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.QT_Parcelas";
                filtro[filtro.Length - 1].vVL_Busca = vQt_parcelas.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vQt_diasdesdobro > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.QT_DiasDesdobro";
                filtro[filtro.Length - 1].vVL_Busca = vQt_diasdesdobro.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSt_venctoemferiado.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_VenctoEmFeriado";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_venctoemferiado.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSt_solicitardtvencto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_SolicitarDtVencto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_solicitardtvencto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            return new TCD_CadCondPgto(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCondPgto(TRegistro_CadCondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondPgto qtb_cond = new TCD_CadCondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                else
                    qtb_cond.Banco_Dados = banco;
                val.Cd_condpgto = CamadaDados.TDataQuery.getPubVariavel(qtb_cond.GravarCondPgto(val), "@P_CD_CONDPGTO");
                val.lCondParcDel.ForEach(p => TCN_CadCondPgto_X_Parcelas.DeletarCondPgto_X_Parcelas(p, qtb_cond.Banco_Dados));
                val.lCondPgto_X_Parcelas.ForEach(p =>
                    {
                        p.Cd_condpgto = val.Cd_condpgto;
                        TCN_CadCondPgto_X_Parcelas.GravarCondPgto_X_Parcelas(p, qtb_cond.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return val.Cd_condpgto;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar condicao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static string DeletarCondPgto(TRegistro_CadCondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondPgto qtb_cond = new TCD_CadCondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                else
                    qtb_cond.Banco_Dados = banco;
                val.lCondParcDel.ForEach(p => TCN_CadCondPgto_X_Parcelas.DeletarCondPgto_X_Parcelas(p, qtb_cond.Banco_Dados));
                val.lCondPgto_X_Parcelas.ForEach(p => TCN_CadCondPgto_X_Parcelas.DeletarCondPgto_X_Parcelas(p, qtb_cond.Banco_Dados));
                qtb_cond.DeletarCondPgto(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                val.St_registro = "C";//Cancelado
                return GravarCondPgto(val, null);
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static decimal CalcularValorJuroFin(TRegistro_CadCondPgto val,
                                                   decimal valor)
        {
            if (val.Pc_jurodiario_atrazoFin <= decimal.Zero)
                return decimal.Zero;
            else
            {
                decimal indice_reajuste = decimal.Zero;
                if (val.Tp_juro_fin.Trim().ToUpper().Equals("C"))//Composto
                    indice_reajuste = Math.Round(Convert.ToDecimal(Math.Pow(Convert.ToDouble((1 + Math.Round((val.Pc_jurodiario_atrazoFin / 100), 15))), Convert.ToDouble((val.Qt_diasdesdobro * (val.St_comentradabool ? val.Qt_parcelas - 1 : val.Qt_parcelas))))), 15);
                else//Simples
                    indice_reajuste = Math.Round((1 + Math.Round((val.Pc_jurodiario_atrazoFin / 100), 15) * (val.Qt_diasdesdobro * (val.St_comentradabool ? val.Qt_parcelas - 1 : val.Qt_parcelas))), 15);
                if (indice_reajuste > decimal.Zero)
                    return Math.Round(((valor * indice_reajuste) - valor), 2);
                else
                    return decimal.Zero;
            }
        }
    }
    #endregion

    #region "Condição Pagamento X Parcelas"
    public class TCN_CadCondPgto_X_Parcelas
    {
        public static TList_CadCondPgto_X_Parcelas Buscar(string Cd_condpgto, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            return new TCD_CadCondPgto_X_Parcelas(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_CadCondPgto_X_Parcelas CriarParcelas(TRegistro_CadCondPgto val)
        {
            TList_CadCondPgto_X_Parcelas retorno = new TList_CadCondPgto_X_Parcelas();
            decimal pc_rateio = Math.Round(100 / val.Qt_parcelas, 2);
            for (int i = 0; i < val.Qt_parcelas; i++)
                retorno.Add(new TRegistro_CadCondPgto_X_Parcelas()
                {
                    Id_parcela = i+1,
                    Cd_condpgto = val.Cd_condpgto,
                    Pc_rateio = pc_rateio,
                    Qt_dias = val.St_comentradabool ? val.Qt_diasdesdobro * i : val.Qt_diasdesdobro * (i + 1)
                });
            retorno[retorno.Count - 1].Pc_rateio += 100 - retorno.Sum(p => p.Pc_rateio);
            return retorno;
        }

        private static decimal somaRateioAnteriores(TRegistro_CadCondPgto val, int index)
        {
            decimal retorno = decimal.Zero;
            for (int i = 0; i <= index; i++)
                retorno += val.lCondPgto_X_Parcelas[i].Pc_rateio;
            return retorno;
        }

        private static decimal somarRateio(TRegistro_CadCondPgto val, int index)
        {
            decimal retorno = decimal.Zero;
            for (int i = 0; i < index; i++)
                retorno += val.lCondPgto_X_Parcelas[i].Pc_rateio;
            return retorno;
        }

        private static void reajustarRateio(TRegistro_CadCondPgto val, int index)
        {
            decimal somaRateio = somarRateio(val, index);
            if ((somaRateio + val.lCondPgto_X_Parcelas[index].Pc_rateio) >= (100 - (val.lCondPgto_X_Parcelas.Count - index)))
                val.lCondPgto_X_Parcelas[index].Pc_rateio = (100 - (val.lCondPgto_X_Parcelas.Count - 1) - somaRateio);
        }

        public static TList_CadCondPgto_X_Parcelas recalcularRateio(TRegistro_CadCondPgto val, int index)
        {
            if (val != null)
            {
                reajustarRateio(val, index);
                decimal diferenca = decimal.Zero;
                diferenca = Math.Abs(100 - somaRateioAnteriores(val, index));
                decimal nParcela = (val.Qt_parcelas) - (index + 1);
                diferenca = (diferenca / nParcela);
                for (int i = (index + 1); i < val.Qt_parcelas; i++)
                    val.lCondPgto_X_Parcelas[i].Pc_rateio = diferenca;
                val.lCondPgto_X_Parcelas[val.lCondPgto_X_Parcelas.Count - 1].Pc_rateio += 100 - val.lCondPgto_X_Parcelas.Sum(p => p.Pc_rateio);
                return val.lCondPgto_X_Parcelas;
            }
            else
            {
                return null;
            }
        }

        public static string GravarCondPgto_X_Parcelas(TRegistro_CadCondPgto_X_Parcelas val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondPgto_X_Parcelas qtb_cond = new TCD_CadCondPgto_X_Parcelas();
            try
            {
                if (st_transacao)
                {
                    qtb_cond.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cond.Banco_Dados = banco;
                string retorno = qtb_cond.GravarCondPgto_X_Parcelas(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static string ProcessarParcelasCad_CondPGTO(TRegistro_CadCondPgto val, TRegistro_CadCondPgto_X_Parcelas Cad_CondPGTO_X_Parcelas, bool gravar, decimal[] valoresRateio, int[] QtdDias)
        {
            TCD_CadCondPgto_X_Parcelas qtb_cond = new TCD_CadCondPgto_X_Parcelas();
            qtb_cond.CriarBanco_Dados(true);

            string retorno = string.Empty;
            try
            {
                //GRAVA OS NOVOS DADOS
                if (gravar)
                {
                    valoresRateio = null;
                }

                decimal[] valorRateio = Estruturas.calcularRateio(Convert.ToInt16(val.Qt_parcelas), 100M, valoresRateio);

                if (valorRateio != null)
                {
                    for (int i = 0; i < valorRateio.Length; i++)
                    {
                        TRegistro_CadCondPgto_X_Parcelas Cad_CondPGTO_X_ParcelasNEW = new TRegistro_CadCondPgto_X_Parcelas();

                        Cad_CondPGTO_X_ParcelasNEW.Cd_condpgto = val.Cd_condpgto;
                        Cad_CondPGTO_X_ParcelasNEW.Id_parcela = (i + 1);

                        if (QtdDias == null)
                        {
                            Cad_CondPGTO_X_ParcelasNEW.Qt_dias = (val.Qt_diasdesdobro * (i + 1));
                        }
                        else
                        {
                            Cad_CondPGTO_X_ParcelasNEW.Qt_dias = QtdDias[i];
                        }

                        Cad_CondPGTO_X_ParcelasNEW.Pc_rateio = valorRateio[i];

                        retorno = qtb_cond.GravarCondPgto_X_Parcelas(Cad_CondPGTO_X_ParcelasNEW);
                    }
                }   
                else
                {
                    //Retorna a mensagem de erro
                    throw new Exception("Atenção, o valor de todos os percentuais de rateio não pode exceder 100% no total!");
                }

                qtb_cond.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                qtb_cond.deletarBanco_Dados();
            }

            return retorno;
        }

        public static string DeletarCondPgto_X_Parcelas(TRegistro_CadCondPgto_X_Parcelas val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondPgto_X_Parcelas qtb_cond = new TCD_CadCondPgto_X_Parcelas();
            try
            {
                if (st_transacao)
                {
                    qtb_cond.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cond.Banco_Dados = banco;
                qtb_cond.DeletarCondPgto_X_Parcelas(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static string DeletarTodasParcelas(TRegistro_CadCondPgto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondPgto_X_Parcelas qtb_cond = new TCD_CadCondPgto_X_Parcelas();
            try
            {
                if (st_transacao)
                {
                    qtb_cond.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cond.Banco_Dados = banco;
                qtb_cond.DeletarTodasParcelas(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
