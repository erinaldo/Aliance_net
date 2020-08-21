using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Caixa;
using BancoDados;

namespace CamadaNegocio.Financeiro.Caixa
{
    public class TCN_Lan_Transfere_Caixa
    {
        public static TList_Lan_Transfere_Caixa Buscar(decimal Id_transf,
                                                       string Cd_conta_ent,
                                                       decimal Cd_lanctocaixa_ent,
                                                       string Cd_conta_sai,
                                                       decimal Cd_lanctocaixa_sai,
                                                       int vTop,
                                                       string vNm_campo,
                                                       TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_transf > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_transf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_transf.ToString();
            }
            if (Cd_conta_ent.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ent";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_conta_ent.Trim() + "'";
            }
            if (Cd_lanctocaixa_ent > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_ent";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa_ent.ToString();
            }
            if (Cd_conta_sai.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_sai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_conta_sai.Trim() + "'";
            }
            if (Cd_lanctocaixa_sai > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_sai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa_sai.ToString();
            }
            return new TCD_Lan_Transferencia_Caixa(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Transfere_Caixa(TRegistro_Lan_Transfere_Caixa val, TObjetoBanco banco)
        {
            TCD_Lan_Transferencia_Caixa QTB_Transfere_Caixa = new TCD_Lan_Transferencia_Caixa();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = QTB_Transfere_Caixa.CriarBanco_Dados(true);
                else
                    QTB_Transfere_Caixa.Banco_Dados = banco;
                string retorno = string.Empty;
                //Grava Saida na conta origem
                if (val != null)
                {
                    retorno = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                                        {
                                                            Cd_ContaGer = val.CD_ContaGer_Saida,
                                                            Cd_Empresa = val.CD_Empresa,
                                                            Nr_Docto = val.NR_Docto,
                                                            Cd_Historico = val.CD_Historico,
                                                            ComplHistorico = val.Complemento,
                                                            Dt_lancto = val.DT_Lancto,
                                                            Vl_PAGAR = val.Valor_Transferencia,
                                                            Vl_RECEBER = decimal.Zero,
                                                            St_Titulo = "N",
                                                            St_Estorno = "N",
                                                            St_avulso = val.St_avulso ? "S" : "N"
                                                        }, QTB_Transfere_Caixa.Banco_Dados);
                    val.CD_LANCTOCAIXA_SAI = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA"));
                }

                //Grava Entrada na conta destino
                if (val != null)
                {
                    retorno = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                                        {
                                                            Cd_ContaGer = val.CD_ContaGer_Entrada,
                                                            Cd_Empresa = val.CD_Empresa,
                                                            Nr_Docto = val.NR_Docto,
                                                            Cd_Historico = val.CD_Historico,
                                                            Dt_lancto = val.DT_Lancto,
                                                            Vl_PAGAR = decimal.Zero,
                                                            Vl_RECEBER = val.Vl_saida_transferencia,
                                                            St_Titulo = "N",
                                                            St_Estorno = "N",
                                                            St_avulso = val.St_avulso ? "S" : "N"
                                                        }, QTB_Transfere_Caixa.Banco_Dados);
                    val.CD_LANCTOCAIXA_ENT = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA"));
                }

                //Grava na Transfere Caixa
                val.ID_TRANSF = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(QTB_Transfere_Caixa.Grava_Transferencia(val), "@P_ID_TRANSF"));
                
                if (pode_liberar)
                    QTB_Transfere_Caixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    QTB_Transfere_Caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar transferencia caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    QTB_Transfere_Caixa.deletarBanco_Dados();
            }

        }
    }
}
