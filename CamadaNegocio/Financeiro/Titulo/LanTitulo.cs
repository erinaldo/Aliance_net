using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Titulo;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;

namespace CamadaNegocio.Financeiro.Titulo
{
    public class TCN_LanTitulo
    {
        public static TList_RegLanTitulo Busca(string vcd_empresa, 
                                               decimal vNr_lanctocheque,
                                               string vcd_banco, 
                                               string vNr_cheque,
                                               string vNr_cgccpf,
                                               string vTp_titulo,
                                               string vNomebanco,
                                               string vTp_data,
                                               string vDt_ini,
                                               string vDt_fin,
                                               decimal vVl_ini,
                                               decimal vVl_fin, 
                                               string vNomeclifor,
                                               string vStcompensado,
                                               string vOperadorStatus,
                                               string vStdescontado,
                                               string vStvencido,
                                               string vStcancelado,
                                               string vStimpresso,
                                               string vSt_aimprimir,
                                               string vSt_Repassado,
                                               string vSt_enviado,
                                               string vSt_devolvido,
                                               bool St_chequeavulso,
                                               bool St_custodiado,
                                               bool St_depositado,
                                               bool St_chtroco,
                                               string vCd_portador,
                                               string vCd_historico,
                                               string vOrdem,
                                               string vFiltro,
                                               string vNr_lotecustodiadeposito,
                                               int vTop,
                                               string vNm_campo,
                                               TObjetoBanco banco
                                               )
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vcd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vcd_empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (vNr_lanctocheque > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoCheque";
                vBusca[vBusca.Length - 1].vVL_Busca = vNr_lanctocheque.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vcd_banco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Banco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vcd_banco.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNr_cheque))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Cheque";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNr_cheque.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNr_cgccpf))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_CGCCPF";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNr_cheque + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vTp_titulo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_titulo.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNomebanco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NomeBanco";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNomebanco + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vTp_data))
            {
                if (vTp_data.Trim().ToUpper().Equals("D"))
                {
                    if ((vDt_ini.Trim() != string.Empty) && (vDt_ini.Trim() != "/  /") &&
                        (vDt_fin.Trim() != string.Empty) && (vDt_fin.Trim() != "/  /"))
                    {
                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                        vBusca[vBusca.Length - 1].vOperador = "exists";
                        vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_devolucaocheque x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and x.dt_devolucao >= '" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + " 00:00:00'" +
                                                              "and x.dt_devolucao <= '" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59:59')";
                    }
                }
                else
                {
                    string tp_data = "";
                    if (vTp_data.Trim().ToUpper().Equals("E"))
                        tp_data = "a.DT_Emissao";
                    else if (vTp_data.Trim().ToUpper().Equals("V"))
                        tp_data = "a.DT_Vencto";
                    else if (vTp_data.Trim().ToUpper().Equals("C"))
                        tp_data = "a.DT_Compensacao";
                    if ((vDt_ini.Trim() != "") && (vDt_ini.Trim() != "/  /"))
                    {
                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = tp_data;
                        vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + " 00:00'";
                        vBusca[vBusca.Length - 1].vOperador = ">=";
                    }
                    if ((vDt_fin.Trim() != "") && (vDt_fin.Trim() != "/  /"))
                    {
                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = tp_data;
                        vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59'";
                        vBusca[vBusca.Length - 1].vOperador = "<=";
                    }
                }
            }
            if (vVl_ini > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), vVl_ini.ToString("."));
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (vVl_fin > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), vVl_fin.ToString("."));
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(vNomeclifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NomeClifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNomeclifor.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vStcompensado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vStcompensado + "'";
                if (vOperadorStatus.Trim() != "")
                    vBusca[vBusca.Length - 1].vOperador = vOperadorStatus;
                else
                    vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vStdescontado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vStdescontado + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vStcancelado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                if (vStcancelado.Trim().ToUpper().Equals("C"))
                {
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vStcancelado + "'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                else
                {
                    vBusca[vBusca.Length - 1].vVL_Busca = "'C'";
                    vBusca[vBusca.Length - 1].vOperador = "<>";
                }
            }
            if (!string.IsNullOrEmpty(vStvencido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 2);
                vBusca[vBusca.Length - 2].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 2].vVL_Busca = "'N'";
                vBusca[vBusca.Length - 2].vOperador = "=";
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Vencto";
                vBusca[vBusca.Length - 1].vVL_Busca = "getDate()";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(vStimpresso))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.ST_Impresso, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_aimprimir))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_impresso, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'N'";
            }
            if (!string.IsNullOrEmpty(vSt_Repassado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'R'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (St_chtroco)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.status_compensado, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'T'";
            }
            if (!string.IsNullOrEmpty(vSt_enviado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'E'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_devolvido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'V'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_portador))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Portador";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_portador + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Historico";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_historico + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vFiltro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 from tb_fin_titulo_x_caixa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.cd_banco = a.cd_banco " +
                                                      "and x.nr_lanctocheque = a.nr_lanctocheque and " + vFiltro + ")";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }
            if (St_chequeavulso)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "not exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                      "inner join tb_fin_caixa y " +
                                                      "on x.cd_contager = y.cd_contager " +
                                                      "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "inner join tb_fin_liquidacao z " +
                                                      "on y.cd_contager = z.cd_contager " +
                                                      "and z.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.cd_banco = a.cd_banco " +
                                                      "and x.nr_lanctocheque = a.nr_lanctocheque)";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "not exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                      "inner join tb_fin_caixa y " +
                                                      "on x.cd_contager = y.cd_contager " +
                                                      "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "inner join tb_fin_adiantamento_x_caixa z " +
                                                      "on y.cd_contager = z.cd_contager " +
                                                      "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.cd_banco = a.cd_banco " +
                                                      "and x.nr_lanctocheque = a.nr_lanctocheque)";
            }
            if (St_custodiado)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'U'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (St_depositado)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.Status_Compensado, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'L'";
            }
            if (!string.IsNullOrEmpty(vOrdem))
                if (vOrdem.Trim().ToUpper().Equals("N"))
                    //Ordenar por Nº Cheque
                    vOrdem = "a.NR_Cheque";
                else if (vOrdem.Trim().ToUpper().Equals("E"))
                    vOrdem = "a.DT_Emissao";
                else if (vOrdem.Trim().ToUpper().Equals("V"))
                    vOrdem = "a.DT_Vencto";
                else if (vOrdem.Trim().ToUpper().Equals("C"))
                    vOrdem = "a.DT_Compensacao";
            if (!string.IsNullOrEmpty(vNr_lotecustodiadeposito))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_titulo_x_lotecustodia x " +
                                                      "inner join tb_fin_lotech_custodia y " +
                                                      "on x.id_lote = y.id_lote " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                      "and x.cd_banco = a.cd_banco " +
                                                      "and y.nr_lote = '" + vNr_lotecustodiadeposito.Trim() + "')";
            }

            return new TCD_LanTitulo(banco).Select(vBusca, vTop, vNm_campo, vOrdem);
        }

        public static string SubstituirTitulo(TRegistro_LanTitulo tituloOld, TRegistro_LanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                //Gravar novo Titulo
                val.St_lancarcaixa = false;
                string retorno = GravarTitulo(val, qtb_titulo.Banco_Dados);

                //Buscar Lançamento de Caixa do Titulo Old
                TList_LanCaixa lCaixa = TCN_TituloXCaixa.Buscar(tituloOld.Cd_empresa, 
                                                                tituloOld.Cd_banco, 
                                                                tituloOld.Nr_lanctocheque, 
                                                                string.Empty, 
                                                                0, 
                                                                string.Empty, 
                                                                qtb_titulo.Banco_Dados);
                lCaixa.ForEach(p =>
                {
                    //Transferir Lançamento de Caixa do Titulo Old para o Novo titulo
                    TCN_TituloXCaixa.GravarTituloCaixa(new TRegistro_LanTituloXCaixa()
                        {
                            Cd_empresa = p.Cd_Empresa,
                            Cd_contager = p.Cd_ContaGer,
                            Cd_banco = val.Cd_banco,
                            Cd_lanctocaixa = p.Cd_LanctoCaixa,
                            Nr_lanctocheque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTOCHEQUE")),
                            Tp_caixa = "S"
                        }, qtb_titulo.Banco_Dados);

                    //Excluir Titulo X Caixa do Titulo Old
                    TCN_TituloXCaixa.DeletarTituloCaixa(new TRegistro_LanTituloXCaixa()
                        {
                            Cd_empresa = tituloOld.Cd_empresa,
                            Cd_banco = tituloOld.Cd_banco,
                            Cd_contager = p.Cd_ContaGer,
                            Cd_lanctocaixa = p.Cd_LanctoCaixa,
                            Nr_lanctocheque = tituloOld.Nr_lanctocheque
                        }, qtb_titulo.Banco_Dados);
                });
                //Cancelar Titulo Old
                tituloOld.St_lancarcaixa = false;
                CancelarTitulo(tituloOld, qtb_titulo.Banco_Dados);

                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro substituir titulo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string GravarTitulo(TList_RegLanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                string retorno = string.Empty;
                foreach (TRegistro_LanTitulo rTitulo in val)
                    retorno += "|" + GravarTitulo(rTitulo, qtb_titulo.Banco_Dados);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string GravarTitulo(TRegistro_LanTitulo val, TObjetoBanco banco) 
        {
            string Ret = string.Empty;
            //Titulo
            bool pode_liberar = false;
            TCD_LanTitulo lantitulo = new TCD_LanTitulo();
            try
            {
                if (banco != null)
                    lantitulo.Banco_Dados = banco;
                else
                    pode_liberar = lantitulo.CriarBanco_Dados(true);
                bool st_novo = val.Nr_lanctocheque.Equals(decimal.Zero);
                Ret = lantitulo.GravaTitulo(val);
                val.Nr_lanctocheque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(Ret, "@P_NR_LANCTOCHEQUE"));

                //*** Caixa ***
                if (val.St_lancarcaixa)
                {
                    Ret += "|" + TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                                            {
                                                                Cd_Empresa = val.Cd_empresa,
                                                                Cd_ContaGer = val.Cd_contager,
                                                                Nr_Docto = val.Nr_cheque,
                                                                Cd_Historico = val.Cd_historico,
                                                                ComplHistorico = val.Observacao,
                                                                Dt_lancto = val.Dt_emissao,
                                                                Vl_PAGAR = val.Tp_titulo.Trim().ToUpper().Equals("P") ? val.Vl_titulo : decimal.Zero,
                                                                Vl_RECEBER = val.Tp_titulo.Trim().ToUpper().Equals("R") ? val.Vl_titulo : decimal.Zero,
                                                                St_Titulo = "S",
                                                                St_Estorno = "N",
                                                                Id_adto = val.Id_adto
                                                            }, lantitulo.Banco_Dados);
                    decimal vCd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(Ret, "@P_CD_LANCTOCAIXA"));

                    //Titulo X Caixa
                    TCN_TituloXCaixa.GravarTituloCaixa(new TRegistro_LanTituloXCaixa()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_contager = val.Cd_contager,
                            Cd_lanctocaixa = vCd_lanctocaixa,
                            Cd_banco = val.Cd_banco,
                            Nr_lanctocheque = val.Nr_lanctocheque,
                            Tp_caixa = "S",
                            Tp_lancto = "OR"//Conta Gerencial de Origem do Cheque
                        }, lantitulo.Banco_Dados);
                    if (val.Tp_titulo.Trim().ToUpper().Equals("P") && st_novo)
                    {
                        //Buscar dados conta gerencial para alterar sequencia
                        CamadaDados.Financeiro.Cadastros.TList_CadContaGer lConta =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(val.Cd_contager,
                                                                                      string.Empty,
                                                                                      null,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      lantitulo.Banco_Dados);
                        if (lConta.Count > 0)
                        {
                            try
                            {
                                lConta[0].Nr_cheque_seq = Convert.ToDecimal(val.Nr_cheque);
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Gravar(lConta[0], lantitulo.Banco_Dados);
                            }
                            catch
                            { }
                        }
                    }
                    if (pode_liberar)
                        lantitulo.Banco_Dados.Commit_Tran();
                    return Ret;
                }
                else
                {
                    if (val.Tp_titulo.Trim().ToUpper().Equals("P") && st_novo)
                    {
                        //Buscar dados conta gerencial para alterar sequencia
                        CamadaDados.Financeiro.Cadastros.TList_CadContaGer lConta =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(val.Cd_contager,
                                                                                      string.Empty,
                                                                                      null,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      lantitulo.Banco_Dados);
                        if (lConta.Count > 0)
                        {
                            try
                            {
                                lConta[0].Nr_cheque_seq = Convert.ToDecimal(val.Nr_cheque);
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Gravar(lConta[0], lantitulo.Banco_Dados);
                            }
                            catch
                            { }
                        }
                    }
                    return Ret;
                }
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    lantitulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar titulo: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    lantitulo.deletarBanco_Dados();
            }
        }

        public static bool EstornarCompensacaoTitulo(TRegistro_LanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            string aux_stc = val.Status_compensado;
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                
                object obj = new TCD_LoteCustodia_X_Titulo(qtb_titulo.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctocheque",
                                        vOperador = "=",
                                        vVL_Busca = val.Nr_lanctocheque.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_banco.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(b.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'E'"
                                    }
                                }, "isnull(b.tp_registro, 'C')");
                if(obj != null)
                    val.Status_compensado = obj.ToString().Trim().ToUpper().Equals("D") ? "L" : "U";
                else 
                    val.Status_compensado = "N";
                val.Dt_compensacao = null;
                qtb_titulo.GravaTitulo(val);
                //Buscar lançamentos de caixa gerado pela compensação do titulo
                new TCD_TransfTitulo(qtb_titulo.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctocheque",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lanctocheque.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_banco",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_banco.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_compensacao, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(b.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(c.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        }
                    }, 0, string.Empty).ForEach(p =>
                                            {
                                                //Estornar lancamento de caixa de origem
                                                TCN_LanCaixa.EstornarSomenteCaixa(TCN_LanCaixa.Busca(p.Cd_conta_orig,
                                                                                                     p.Cd_lanctocaixa_orig.ToString(),
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     decimal.Zero,
                                                                                                     decimal.Zero,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     "N",
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     decimal.Zero,
                                                                                                     false,
                                                                                                     qtb_titulo.Banco_Dados)[0],
                                                                                    qtb_titulo.Banco_Dados);
                                                //Estornar lancamento de caixa de origem
                                                TCN_LanCaixa.EstornarSomenteCaixa(TCN_LanCaixa.Busca(p.Cd_conta_dest,
                                                                        p.Cd_lanctocaixa_dest.ToString(),
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        "N",
                                                                        false,
                                                                        string.Empty,
                                                                        decimal.Zero,
                                                                        false,
                                                                        qtb_titulo.Banco_Dados)[0], qtb_titulo.Banco_Dados);
                                            });
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return true;
            }
            catch (Exception ex)
            {
                val.Status_compensado = aux_stc;
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar compensação: "+ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static bool CancelarTitulo(TRegistro_LanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                if (val.Status_compensado.Trim().ToUpper().Equals("E"))//Enviado
                    throw new Exception("Erro estornar cheque: Não é permitido estornar cheque com status de enviado para o banco para ser descontado.\r\n" +
                                        "Para estornar o cheque é necessario antes estornar o mesmo do lote.");
                if (val.Status_compensado.Trim().ToUpper().Equals("D"))//Descontado
                    throw new Exception("Erro estornar cheque: Não é permitido estornar cheque com status de descontado.\r\n" +
                                        "Para estornar o cheque é necessario antes estornar processamento do lote.");
                if (val.Status_compensado.Trim().ToUpper().Equals("U"))//Custodiado
                    throw new Exception("Erro estornar cheque: Não é permitido estornar cheque com em custodia.\r\n" +
                                        "Necessário antes excluir cheque do lote de custodia.");
                //Alterar Status_Compensado do titulo para C - Cancelado
                val.Status_compensado = "C";
                qtb_titulo.GravaTitulo(val);
                if (val.St_lancarcaixa)
                {
                    //Listar todos os lançamentos de caixa com status de compensado <> S
                    TCN_TituloXCaixa.Buscar(val.Cd_empresa, 
                                            val.Cd_banco, 
                                            val.Nr_lanctocheque, 
                                            "N", 
                                            0, 
                                            string.Empty, 
                                            qtb_titulo.Banco_Dados).ForEach(p=>
                        //Para cada lançamento de caixa chamar procedimento estorna caixa
                        //O procedimento estorna caixa ira estornar o caixa, a liquidacao se houver
                        //e alterar o status das parcelas
                        TCN_LanCaixa.EstornarCaixa(p, null, qtb_titulo.Banco_Dados));
                }
                //Verificar se cheque tem liquidacoes amarradas a ele
                TCN_Titulo_x_Liquidacao.Buscar(val.Cd_empresa,
                                               val.Cd_banco,
                                               val.Nr_lanctocheque.ToString(),
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               qtb_titulo.Banco_Dados).ForEach(p =>
                                                   {
                                                       //Buscar liquidacao
                                                       CamadaDados.Financeiro.Duplicata.TRegistro_LanLiquidacao rLiq =
                                                           CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.Busca(p.Cd_empresa,
                                                                                                                      p.Nr_lancto.Value,
                                                                                                                      p.Cd_parcela.Value,
                                                                                                                      p.Id_liquid.Value,
                                                                                                                      string.Empty,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      decimal.Zero,
                                                                                                                      false,
                                                                                                                      string.Empty,
                                                                                                                      1,
                                                                                                                      string.Empty,
                                                                                                                      qtb_titulo.Banco_Dados)[0];
                                                       //Excluir titulo x liquidacao
                                                       TCN_Titulo_x_Liquidacao.Excluir(p, qtb_titulo.Banco_Dados);
                                                       //Cancelar liquidacao
                                                       CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.CancelarLiquidacao(rLiq, null, qtb_titulo.Banco_Dados);
                                                   });

                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return true;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar cheque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }
        
        public static string TransferirTitulo(TRegistro_LanTitulo val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                
                //Verificar a data do caixa
                if (TCN_LanCaixa.DataCaixa(val.Cd_contager_destino, Convert.ToDateTime(val.Dt_compensacao), qtb_titulo.Banco_Dados))
                {
                    //Inicio do processo de transferencia
                    //Buscar todos os lancamentos de caixa amarrados ao titulo
                    TList_LanCaixa lCaixa = new TCD_LanCaixa(qtb_titulo.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_estorno, 'N')",
                                vVL_Busca = "'S'",
                                vOperador = "<>"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_titulo, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x "+
                                            "where x.cd_contager = a.cd_contager "+
                                            "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                            "and x.cd_empresa = '"+val.Cd_empresa.Trim()+"' "+
                                            "and x.cd_banco = '"+val.Cd_banco.Trim()+"' "+
                                            "and x.nr_lanctocheque = "+val.Nr_lanctocheque.ToString()+" "+
                                            "and isnull(x.tp_lancto, '') = 'OR')"
                            }
                        }, 0, string.Empty);
                    string retorno = string.Empty;
                    if (lCaixa.Count > 0)
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CFGCheque lCfgCh = new CamadaDados.Financeiro.Cadastros.TList_CFGCheque();
                        if (val.Status_compensado.Trim().ToUpper().Equals("V"))
                        {
                            lCfgCh = CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.Buscar(val.Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            1,
                                                                                            string.Empty,
                                                                                            qtb_titulo.Banco_Dados);
                            if (lCfgCh.Count < 1)
                                throw new Exception("Não existe configuração de cheque para compensar cheque devolvido para a empresa " + val.Cd_empresa.Trim());
                            if (val.Tp_titulo.Trim().ToUpper().Equals("P"))
                            {
                                if (lCfgCh[0].Cd_histreap_chemitidos.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe configuração de historico de reapresentação de cheque emitido para a empresa " + val.Cd_empresa.Trim());
                            }
                            else
                                if (lCfgCh[0].Cd_histreap_chrecebidos.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe configuração de historico de reapresentação de cheque recebido para a empresa " + val.Cd_empresa.Trim());
                        }
                        lCaixa.ForEach(p =>
                            {
                                if(!val.Status_compensado.Trim().ToUpper().Equals("S"))
                                    //Alterar status tipo lancto para null
                                    qtb_titulo.executarSql("update tb_fin_titulo_x_caixa set tp_lancto = null " +
                                                           "where cd_empresa = '" + p.Cd_Empresa.Trim() + "' " +
                                                           "and cd_banco = '" + val.Cd_banco.Trim() + "' " +
                                                           "and nr_lanctocheque = " + val.Nr_lanctocheque.ToString() + " " +
                                                           "and cd_contager = '" + p.Cd_ContaGer.Trim() + "' " +
                                                           "and cd_lanctocaixa = " + p.Cd_LanctoCaixa.ToString(), null);
                                //Incluir lançamento de caixa contrario ao original
                                retorno = TCN_LanCaixa.GravaLanCaixa(
                                    new TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = p.Cd_Empresa,
                                        Cd_ContaGer = p.Cd_ContaGer,
                                        Nr_Docto = val.Nr_cheque,
                                        Dt_lancto = val.Dt_compensacao,
                                        Cd_Historico = (val.Status_compensado.Trim().ToUpper().Equals("V") ? p.Vl_PAGAR > 0 ? lCfgCh[0].Cd_histreap_chemitidos : lCfgCh[0].Cd_histreap_chrecebidos : p.Cd_Historico),
                                        Vl_RECEBER = (p.Vl_PAGAR > 0 ? p.Vl_PAGAR : 0),
                                        Vl_PAGAR = (p.Vl_RECEBER > 0 ? p.Vl_RECEBER : 0),
                                        ComplHistorico = val.Status_compensado.Trim().ToUpper().Equals("N") ? "TRF. TITULO p/ C/C: " + val.Cd_contager_destino : p.ComplHistorico.Trim() + val.Observacao.Trim(),
                                        St_Estorno = "N",
                                        St_Titulo = "F"
                                    }, qtb_titulo.Banco_Dados);
                                string vCd_lanctocaixa_o = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA");

                                //Incluir titulo_x_caixa para o novo lancamento de caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_empresa = p.Cd_Empresa,
                                        Cd_contager = p.Cd_ContaGer,
                                        Cd_lanctocaixa = Convert.ToDecimal(vCd_lanctocaixa_o),
                                        Cd_banco = val.Cd_banco,
                                        Nr_lanctocheque = val.Nr_lanctocheque,
                                        Tp_caixa = "F"
                                    }, qtb_titulo.Banco_Dados);

                                //Incluir lancamento de caixa na conta destino
                                retorno = TCN_LanCaixa.GravaLanCaixa(
                                    new TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = val.Cd_empresa,
                                        Cd_ContaGer = val.Cd_contager_destino,
                                        Nr_Docto = val.Nr_cheque,
                                        Dt_lancto = val.Dt_compensacao,
                                        Cd_Historico = (val.Status_compensado.Trim().ToUpper().Equals("V") ? p.Vl_PAGAR > 0 ? lCfgCh[0].Cd_histreap_chemitidos : lCfgCh[0].Cd_histreap_chrecebidos : p.Cd_Historico),
                                        Vl_PAGAR = (p.Vl_PAGAR > 0 ? p.Vl_PAGAR : 0),
                                        Vl_RECEBER = (p.Vl_RECEBER > 0 ? p.Vl_RECEBER : 0),
                                        ComplHistorico = val.Status_compensado.Trim().ToUpper().Equals("S") ? p.ComplHistorico.Trim() + val.Observacao.Trim() : "CHEQUE TRANSFERIDO ORIG C/C: " + val.Cd_contager_destino,
                                        St_Estorno = "N",
                                        St_Titulo = (val.Status_compensado.Trim().ToUpper().Equals("S") ? "C" : "S")
                                    }, qtb_titulo.Banco_Dados);
                                string vCd_lanctoCaixa_d = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA");

                                //Incluir titulo_x_caixa para o novo lancamento de caixa
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                    new TRegistro_LanTituloXCaixa()
                                    {
                                        Cd_empresa = val.Cd_empresa,
                                        Cd_contager = val.Cd_contager_destino,
                                        Cd_lanctocaixa = Convert.ToDecimal(vCd_lanctoCaixa_d),
                                        Cd_banco = val.Cd_banco,
                                        Nr_lanctocheque = val.Nr_lanctocheque,
                                        Tp_lancto = val.Status_compensado.Trim().ToUpper().Equals("S") ? string.Empty : "OR",
                                        Tp_caixa = (val.Status_compensado.Trim().ToUpper().Equals("S") ? "C" : "S")
                                    }, qtb_titulo.Banco_Dados);
                                //Inserir novo registro na TB_Transfere_Titulo
                                TCN_TransfTitulo.GravarTransfTitulo(
                                    new TRegistro_TransfTitulo()
                                    {
                                        Cd_empresa = val.Cd_empresa,
                                        Cd_conta_orig = p.Cd_ContaGer,
                                        Cd_lanctocaixa_orig = Convert.ToDecimal(vCd_lanctocaixa_o),
                                        Cd_conta_dest = val.Cd_contager_destino,
                                        Cd_lanctocaixa_dest = Convert.ToDecimal(vCd_lanctoCaixa_d),
                                        Nr_lanctocheque = val.Nr_lanctocheque,
                                        Cd_banco = val.Cd_banco,
                                        St_compensacao = val.Status_compensado.Trim()
                                    }, qtb_titulo.Banco_Dados);
                                //Contabilidade Compensacao Cheque
                                List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado> lProcCh =
                                    CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_ChequeCompensado(string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           false,
                                                                                                           decimal.Zero,
                                                                                                           string.Empty,
                                                                                                           val.Cd_contager_destino,
                                                                                                           vCd_lanctoCaixa_d,
                                                                                                           decimal.Zero,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           decimal.Zero,
                                                                                                           decimal.Zero,
                                                                                                           qtb_titulo.Banco_Dados);
                                if (lProcCh.Count > 0)
                                    if (lProcCh.Exists(v => v.Cd_contadeb.HasValue && v.Cd_contacred.HasValue))
                                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ChequeCompensado(lProcCh.FindAll(v => v.Cd_contacred.HasValue && v.Cd_contadeb.HasValue), qtb_titulo.Banco_Dados);
                            });
                    }
                    else
                        return retorno;
                    if (pode_liberar)
                        qtb_titulo.Banco_Dados.Commit_Tran();

                    return retorno;
                }
                else
                    throw new Exception("Data de movimentação " + val.Dt_compensacao.ToString() + " está FECHADA para lançamentos");
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static void AlterarTitulo(TRegistro_LanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                qtb_titulo.GravaTitulo(val);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar titulo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string AlterarTitulos(TList_RegLanTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo cd = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                {
                    cd.CriarBanco_Dados(true);
                    banco = cd.Banco_Dados;
                    st_transacao = true;
                }
                string retorno = "";
                foreach (TRegistro_LanTitulo rTitulo in val)
                    retorno += "|" + cd.GravaTitulo(rTitulo);
                if (st_transacao)
                    banco.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    banco.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                {
                    cd.deletarBanco_Dados();
                    banco = null;
                }
            }
        }

        public static void GerarCreditoTitulo(TRegistro_CreditoTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                //Verificar se o status do titulo esta para compensar
                object obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(qtb_titulo.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'"+val.Cd_empresa.Trim()+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctocheque",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lanctocheque.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_banco",
                            vOperador = "=",
                            vVL_Busca = "'"+val.Cd_banco.Trim()+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.status_compensado, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'N'"
                        }
                    }, "1");
                if (obj == null)
                {
                    //Verificar se o cheque foi lancado avulso
                    obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(qtb_titulo.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "((select 1 from tb_fin_titulo_x_caixa x "+
                                            "inner join tb_fin_caixa y "+
                                            "on x.cd_contager = y.cd_contager "+
                                            "and x.cd_lanctocaixa = y.cd_lanctocaixa "+
                                            "inner join tb_fin_liquidacao z "+
                                            "on y.cd_contager = z.cd_contager "+
                                            "and y.cd_lanctocaixa = z.cd_lanctocaixa "+
                                            "where x.cd_empresa = a.cd_empresa "+
                                            "and x.cd_banco = a.cd_banco "+
                                            "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                            "and a.cd_empresa = '" + val.Cd_empresa.Trim() +"' "+
                                            "and a.cd_banco = '" + val.Cd_banco.Trim() + "' "+
                                            "and a.nr_lanctocheque = " + val.Nr_lanctocheque.Value.ToString() +") or" +
                                            "(select 1 from tb_fin_titulo_x_caixa x "+
                                            "inner join tb_fin_caixa y "+
                                            "on x.cd_contager = y.cd_contager "+
                                            "and x.cd_lanctocaixa = y.cd_lanctocaixa "+
                                            "inner join tb_fin_adiantamento_x_caixa z "+
                                            "on y.cd_contager = z.cd_contager "+
                                            "and y.cd_lanctocaixa = z.cd_lanctocaixa "+
                                            "where x.cd_empresa = a.cd_empresa "+
                                            "and x.cd_banco = a.cd_banco "+
                                            "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                            "and a.cd_empresa = '" + val.Cd_empresa.Trim() +"' "+
                                            "and a.cd_banco = '" + val.Cd_banco.Trim() + "' "+
                                            "and a.nr_lanctocheque = " + val.Nr_lanctocheque.Value.ToString() +"))"
                            }
                        }, "1");
                    if (obj == null)
                    {
                        //Verificar se ja nao foi gerado credito para o titulo
                        obj = new CamadaDados.Financeiro.Titulo.TCD_TituloXCaixa(qtb_titulo.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_lancto",
                                vOperador = "=",
                                vVL_Busca = "'GC'"//Gerar Credito
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'"+val.Cd_empresa.Trim()+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lanctocheque",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lanctocheque.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_banco",
                                vOperador = "=",
                                vVL_Busca = "'"+val.Cd_banco.Trim()+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_caixa x "+
                                            "where x.cd_contager = a.cd_contager "+
                                            "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                            "and isnull(x.st_estorno, 'N') = 'N')"
                            }
                        }, "1");
                        if (obj == null)
                        {
                            //Gerar lancamento de caixa credito
                            string ret_caixa = TCN_LanCaixa.GravaLanCaixa(
                                                new TRegistro_LanCaixa()
                                                {
                                                    Cd_ContaGer = val.Cd_contagercredito,
                                                    Cd_Empresa = val.Cd_empresacredito,
                                                    Cd_Historico = val.Cd_historico,
                                                    Cd_LanctoCaixa = 0,
                                                    ComplHistorico = val.CompHistorico,
                                                    Dt_lancto = val.Dt_lancto,
                                                    Nr_Docto = "GC" + val.Nr_cheque.Trim(),
                                                    Vl_RECEBER = val.Vl_titulo
                                                }, qtb_titulo.Banco_Dados);
                            //Gravar titulo x caixa
                            TCN_TituloXCaixa.GravarTituloCaixa(
                                new TRegistro_LanTituloXCaixa()
                                {
                                    Cd_banco = val.Cd_banco,
                                    Cd_contager = val.Cd_contagercredito,
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                    Nr_lanctocheque = val.Nr_lanctocheque.Value,
                                    Tp_caixa = string.Empty,
                                    Tp_lancto = "GC" //Gerar credito
                                }, qtb_titulo.Banco_Dados);
                            if (st_transacao)
                                qtb_titulo.Banco_Dados.Commit_Tran();
                        }
                        else
                            throw new Exception("Ja existe um lançamento de crédito para este titulo.");
                    }
                    else
                        throw new Exception("Só é permitido gerar crédito de titulo avulso.");
                }
                else
                    throw new Exception("Só é permitido gerar crédito de titulo a compensar.");
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar credito titulo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static void CompensarCheques(List<TRegistro_LanTitulo> lCheques, TObjetoBanco banco)
        {
            bool podecomitar = false;
            TCD_LanTitulo qtb_titulo = new TCD_LanTitulo();
            try
            {
                if (banco == null)
                    podecomitar = qtb_titulo.CriarBanco_Dados(true);
                else qtb_titulo.Banco_Dados = banco;
                if (lCheques == null)
                    throw new Exception("Não existe cheques para compensar.");
                if(lCheques.Count < 1)
                    throw new Exception("Não existe cheques para compensar.");
                if (!TCN_LanCaixa.DataCaixa(lCheques[0].Cd_contager, lCheques[0].Dt_compensacao, banco))
                    throw new Exception("Não é possivel compensar cheques.\r\n" +
                                        "Caixa ja se encontra fechado para a conta gerencial: " + lCheques[0].Cd_contager.Trim() + "\r\n" +
                                        "na data " + lCheques[0].Dt_compensacaostring);
                if(!TCN_LanCaixa.DataCaixa(lCheques[0].Cd_contager_destino, lCheques[0].Dt_compensacao, banco))
                    throw new Exception("Não é possivel compensar cheques.\r\n" +
                                        "Caixa ja se encontra fechado para a conta gerencial: " + lCheques[0].Cd_contager_destino.Trim() + "\r\n" +
                                        "na data " + lCheques[0].Dt_compensacaostring);
                lCheques.ForEach(p =>
                    {
                        //Muda status do cheque para compensado
                        //Necessario para alterar o ST_Titulo de todos
                        //os lancamentos de caixa para F
                        p.Status_compensado = "S";
                        //Transferir Titulo
                        string retorno = TransferirTitulo(p, qtb_titulo.Banco_Dados);
                        
                        retorno += GravarTitulo(p, qtb_titulo.Banco_Dados);
                        TList_DevolucaoCheque lDev = new TCD_DevolucaoCheque(qtb_titulo.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim()+ "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctocheque",
                                    vOperador = "=",
                                    vVL_Busca = p.Nr_lanctocheque.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_banco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_banco.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.dt_reapresentacao",
                                    vOperador = string.Empty,
                                    vVL_Busca = "is null"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lDev.Count > 0)
                        {
                            lDev[0].Dt_reapresentacao = p.Dt_compensacao;
                            TCN_DevolucaoCheque.GravarDevolucaoCheque(lDev[0], qtb_titulo.Banco_Dados);
                        }
                    });
                if (podecomitar)
                    qtb_titulo.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (podecomitar)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro compensar cheques: " + ex.Message.Trim());
            }
            finally
            {
                if (podecomitar)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static void ImprimirCheque(List<TRegistro_LanTitulo> lCheques)
        {
            if (lCheques != null)
            {
                //Buscar config impressao cheque
                CamadaDados.Financeiro.Cadastros.TList_CFGImpCheque lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CFGImpCheque.Buscar(lCheques[0].Cd_banco,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               null);
                if (lCfg.Count > 0)
                {
                    //Buscar porta impressao
                    object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.porta_imptick");
                    if (porta == null)
                        throw new Exception("Obrigatorio configurar porta impressão para o terminal " + Utils.Parametros.pubTerminal.Trim());
                    //Buscar dados borda inferior
                    object obj_borda = new CamadaDados.Financeiro.Cadastros.TCD_CadBanco().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_banco",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lCheques[0].Cd_banco.Trim() + "'"
                                            }
                                        }, "isnull(a.bordainferior, 0)");

                    System.IO.FileInfo f = null;
                    System.IO.StreamWriter w = null;
                    f = new System.IO.FileInfo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + "cheque.txt");
                    w = f.CreateText();
                    try
                    {
                        lCheques.OrderBy(p=> p.Nr_cheque).ToList().ForEach(p =>
                        {
                            string valor = string.Empty;
                            int ultimalinha = 0;
                            int ultimacoluna = 0;
                            int posextenso = 0;
                            lCfg.ForEach(v =>
                            {
                                if (Convert.ToInt32(v.Linha) > ultimalinha)
                                {
                                    valor = string.Empty;
                                    if(ultimalinha > decimal.Zero)
                                        for (int i = 0; i < Convert.ToInt32(v.Linha) - ultimalinha; i++)
                                            w.WriteLine();
                                }
                                if (v.Nm_campo.Trim().ToUpper().Equals("DT_PARA"))
                                {
                                    if (!string.IsNullOrEmpty(p.Dt_venctostring))
                                    {
                                        valor = "BOM P/ " + p.Dt_venctostring.RemoverCaracteres();
                                        if (v.Tamanho > decimal.Zero)
                                            valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                                valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                                valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                    }
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("NOMINAL"))
                                {
                                    valor = p.Nm_clifor_nominal.Trim().RemoverCaracteres();
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("DS_CIDADE"))
                                {
                                    valor = p.Ds_cidade_empresa.Trim().RemoverCaracteres();
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("DIA"))
                                {
                                    valor = p.Dt_emissao.Value.ToString("dd");
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("MES"))
                                {
                                    valor = p.Dt_emissao.Value.ToString("MMMM").RemoverCaracteres();
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("ANO"))
                                {
                                    valor = p.Dt_emissao.Value.ToString("yyyy");
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                            valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                            valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("VL_EXTENSO"))
                                {
                                    valor = "(" + p.Vl_titulo.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) + ")" +
                                               p.ValorExtenso.RemoverCaracteres();
                                    if (valor.Trim().Length < v.Tamanho)
                                        valor = valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), '*');
                                    else
                                        valor = valor.Trim().Substring(0, Convert.ToInt32(v.Tamanho));
                                    posextenso = Convert.ToInt32(v.Tamanho);
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("VL_EXTENSO1"))
                                {
                                    valor = "(" + p.Vl_titulo.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) + ")" + 
                                               p.ValorExtenso.RemoverCaracteres();
                                    if (valor.Trim().Length < (posextenso + v.Tamanho))
                                        valor = valor.Trim().FormatStringDireita(posextenso + Convert.ToInt32(v.Tamanho), '*').Substring(posextenso, Convert.ToInt32(v.Tamanho));
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("NR_CHEQUE"))
                                {
                                    valor = p.Nr_cheque;
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), ' ') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), ' ');
                                }
                                else if (v.Nm_campo.Trim().ToUpper().Equals("VL_TITULO"))
                                {
                                    valor = p.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                                    if (v.Tamanho > decimal.Zero)
                                        valor = v.Tp_alinhamento.Trim().ToUpper().Equals("D") ?
                                              valor.FormatStringDireita(Convert.ToInt32(v.Tamanho), '*') :
                                              valor.FormatStringEsquerda(Convert.ToInt32(v.Tamanho), '*');
                                }
                                if (ultimalinha != Convert.ToInt32(v.Linha))
                                    valor = valor.Insert(0, "".PadLeft(Convert.ToInt32(v.Coluna) - 1, ' '));
                                else
                                    valor = valor.Insert(0, "".PadLeft(Convert.ToInt32(v.Coluna) - ultimacoluna, ' '));
                                w.Write(valor);
                                ultimalinha = Convert.ToInt32(v.Linha);
                                ultimacoluna = Convert.ToInt32(v.Coluna + v.Tamanho);
                            });
                            //Ajustar borda inferior
                            if (obj_borda != null)
                                for (int i = 0; i < Convert.ToInt32(obj_borda.ToString()); i++)
                                    w.WriteLine();
                        });
                        w.Write(Convert.ToChar(12));
                        w.Flush();
                        f.CopyTo(porta.ToString());
                        //Alterar status dos cheques para impresso
                        lCheques.ForEach(p =>
                            {
                                try
                                {
                                    p.St_impresso = "S";
                                    TCN_LanTitulo.AlterarTitulo(p, null);
                                }
                                catch { }
                            });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro na impressao: " + ex.Message.Trim());
                    }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                }
            }
        }
    }

    public class TCN_TituloXCaixa
    {
        public static TList_RegLanTituloXCaixa Buscar(string Cd_empresa,
                                                      string Cd_contager,
                                                      string Cd_lanctocaixa,
                                                      string Cd_banco,
                                                      string Nr_lanctocheque,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }

            return new TCD_TituloXCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_LanCaixa Buscar(string vCd_Empresa,
                                            string vCd_Banco,
                                            decimal vNr_LanctoCheque,
                                            string vSt_estorno,
                                            int vTop,
                                            string vNm_campo,
                                            TObjetoBanco banco)
        {
            string filtro = "x.CD_Empresa = '" + vCd_Empresa + "' and " +
                            "x.NR_LanctoCheque = " + vNr_LanctoCheque.ToString() + " and " +
                            "x.CD_Banco = '" + vCd_Banco + "'";
            return TCN_LanCaixa.Busca(string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      string.Empty, 
                                      decimal.Zero, 
                                      decimal.Zero, 
                                      string.Empty, 
                                      string.Empty, 
                                      vSt_estorno, 
                                      false, 
                                      filtro, 
                                      decimal.Zero, 
                                      false,
                                      banco);
        }

        public static TList_RegLanTitulo Buscar(string vCd_ContaGer,
                                                decimal vCd_LanctoCaixa,
                                                string vStatus_compensado,
                                                string vOperadorStatus,
                                                int vTop,
                                                string vNm_campo,
                                                TObjetoBanco banco)
        {
            string filtro = "x.CD_ContaGer = '" + vCd_ContaGer + "' and " +
                            "x.CD_LanctoCaixa = " + vCd_LanctoCaixa.ToString();
            return TCN_LanTitulo.Busca(string.Empty, 
                                       decimal.Zero, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       decimal.Zero, 
                                       decimal.Zero, 
                                       string.Empty, 
                                       vStatus_compensado, 
                                       vOperadorStatus, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       false,
                                       false,
                                       false,
                                       false,
                                       string.Empty, 
                                       string.Empty, 
                                       string.Empty, 
                                       filtro, 
                                       string.Empty,
                                       0, 
                                       string.Empty, 
                                       banco);

        }

        public static string GravarTituloCaixa(TRegistro_LanTituloXCaixa val, TObjetoBanco banco)
        {
            TCD_TituloXCaixa qtb_tituloCaixa = new TCD_TituloXCaixa();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_tituloCaixa.CriarBanco_Dados(true);
                else
                    qtb_tituloCaixa.Banco_Dados = banco;
                string retorno = qtb_tituloCaixa.GravaTituloXCaixa(val);
                if (st_transacao)
                    qtb_tituloCaixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_tituloCaixa.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_tituloCaixa.deletarBanco_Dados();
            }
        }

        public static string DeletarTituloCaixa(TRegistro_LanTituloXCaixa val, TObjetoBanco banco)
        {
            TCD_TituloXCaixa qtb_tituloCaixa = new TCD_TituloXCaixa();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_tituloCaixa.CriarBanco_Dados(true);
                else
                    qtb_tituloCaixa.Banco_Dados = banco;
                string retorno = qtb_tituloCaixa.DeletaTituloXCaixa(val);
                if (st_transacao)
                    qtb_tituloCaixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_tituloCaixa.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_tituloCaixa.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Titulo_x_Liquidacao
    {
        public static TList_Titulo_x_Liquidacao Buscar(string Cd_empresa,
                                                       string Cd_banco,
                                                       string Nr_lanctocheque,
                                                       string Nr_lancto,
                                                       string Cd_parcela,
                                                       string Id_liquid,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            if (!string.IsNullOrEmpty(Id_liquid))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_liquid";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_liquid;
            }
            return new TCD_Titulo_x_Liquidacao(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanParcela BuscarParc(string Cd_empresa,
                                                                                      string Cd_banco,
                                                                                      string Nr_lanctocheque,
                                                                                      BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanParcela(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_titulo_x_liquidacao x " +
                                    "inner join tb_fin_liquidacao y " +
                                    "on x.cd_empresa = y.cd_empresa " +
                                    "and x.nr_lancto = y.nr_lancto " +
                                    "and x.cd_parcela = y.cd_parcela " +
                                    "and x.id_liquid = y.id_liquid " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.cd_parcela = a.cd_parcela " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.cd_banco = '" + Cd_banco.Trim() + "' " +
                                    "and x.nr_lanctocheque = " + Nr_lanctocheque + " " +
                                    "and isnull(y.st_registro, 'A') <> 'C')"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Titulo_x_Liquidacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo_x_Liquidacao qtb_titulo = new TCD_Titulo_x_Liquidacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else qtb_titulo.Banco_Dados = banco;
                string retorno = qtb_titulo.Gravar(val);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Titulo_x_Liquidacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo_x_Liquidacao qtb_titulo = new TCD_Titulo_x_Liquidacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else qtb_titulo.Banco_Dados = banco;
                qtb_titulo.Excluir(val);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TransfTitulo
    {
        public static TList_TransfTitulo Buscar(string vCd_empresa,
                                                    string vCd_contaorig,
                                                    string vCd_contadest,
                                                    decimal vCd_lanctocaixaorig,
                                                    decimal vCd_lanctocaixadest,
                                                    decimal vNr_lanctocheque,
                                                    string vCd_banco,
                                                    int vTop,
                                                    string vNm_campo,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if (vCd_contaorig.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contaorig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contaorig.Trim() + "'";
            }
            if (vCd_contadest.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contadest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contadest.Trim() + "'";
            }
            if (vCd_lanctocaixaorig > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixaorig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixaorig.ToString();
            }
            if (vCd_lanctocaixadest > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixadest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixadest.ToString();
            }
            if (vNr_lanctocheque > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lanctocheque.ToString();
            }
            if (vCd_banco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_banco.Trim() + "'";
            }
            return new TCD_TransfTitulo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTransfTitulo(TRegistro_TransfTitulo val, TObjetoBanco banco)
        {
            TCD_TransfTitulo qtb_transf = new TCD_TransfTitulo();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                {
                    qtb_transf.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_transf.Banco_Dados = banco;
                string retorno = qtb_transf.GravarTransfTitulo(val);
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }

        public static string ExcluirTransfTitulo(TRegistro_TransfTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfTitulo qtb_transf = new TCD_TransfTitulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else qtb_transf.Banco_Dados = banco;
                qtb_transf.DeletarTransfTitulo(val);
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }
    }
    
    public class TCN_Rastreab_ChTerceiro
    {
        public static TList_Rastreab_ChTerceiro Buscar(string Cd_empresa,
                                                       string Cd_banco,
                                                       string Nr_lanctocheque,
                                                       string Cd_clifor_origem,
                                                       string Cd_contager,
                                                       string Cd_lanctocaixa,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Cd_banco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (Nr_lanctocheque.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (Cd_clifor_origem.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor_origem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor_origem.Trim() + "'";
            }
            if (Cd_contager.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (Cd_lanctocaixa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            return new TCD_Rastreab_ChTerceiro(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_RegLanTitulo BuscarCheques(string Cd_contager,
                                                       string Cd_lanctocaixa,
                                                       BancoDados.TObjetoBanco banco)
        {
            if ((Cd_contager.Trim() != string.Empty) &&
                (Cd_lanctocaixa.Trim() != string.Empty))
                return new TCD_LanTitulo(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.status_compensado",
                            vOperador = "=",
                            vVL_Busca = "'R'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_rastreab_chterceiro x "+
                                        "where a.cd_empresa = x.cd_empresa "+
                                        "and a.cd_banco = x.cd_banco "+
                                        "and a.nr_lanctocheque = x.nr_lanctocheque "+
                                        "and x.cd_contager = '"+Cd_contager.Trim()+"' "+
                                        "and x.cd_lanctocaixa = "+Cd_lanctocaixa+")"
                        }
                    },
                    0,
                    string.Empty,
                    string.Empty);
            else
                return new TList_RegLanTitulo();
        }

        public static string GravarRastreab_ChTerceiro(TRegistro_Rastreab_ChTerceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rastreab_ChTerceiro qtb_rastreab = new TCD_Rastreab_ChTerceiro();
            try
            {
                if (banco == null)
                {
                    qtb_rastreab.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_rastreab.Banco_Dados = banco;
                string retorno = qtb_rastreab.GravarRastreab_ChTerceiro(val);
                if (st_transacao)
                    qtb_rastreab.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_rastreab.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_rastreab.deletarBanco_Dados();
            }
        }

        public static string DeletarRastreab_ChTerceiro(TRegistro_Rastreab_ChTerceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rastreab_ChTerceiro qtb_rastrear = new TCD_Rastreab_ChTerceiro();
            try
            {
                if (banco == null)
                {
                    qtb_rastrear.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_rastrear.Banco_Dados = banco;
                qtb_rastrear.DeletarRastreab_ChTerceiro(val);
                if (st_transacao)
                    qtb_rastrear.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_rastrear.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_rastrear.deletarBanco_Dados();
            }
        }
    }
}
