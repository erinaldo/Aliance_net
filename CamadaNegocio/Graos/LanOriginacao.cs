using System;
using Utils;
using BancoDados;
using CamadaDados.Graos;


namespace CamadaNegocio.Graos
{
    #region "ORIGINACAO"

    public class TCN_Lan_Originacao
        {
            public static TList_Lan_Originacao Buscar(decimal vID_Originacao,
                                                      string vCD_Empresa,
                                                      decimal vNr_LanctoFiscal,
                                                      decimal vID_NFITem,
                                                      decimal vPS_Chegada,
                                                      string vNm_campo,
                                                      int vTop,
                                                      TObjetoBanco banco)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vID_Originacao > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Originacao";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Originacao.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCD_Empresa.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vNr_LanctoFiscal > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Nr_LanctoFiscal";
                    filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_NFITem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFITem";
                    filtro[filtro.Length - 1].vVL_Busca = vID_NFITem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vPS_Chegada > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.PS_Chegada";
                    filtro[filtro.Length - 1].vVL_Busca = vPS_Chegada.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_Lan_Originacao().Select(filtro, vTop, vNm_campo);
            }

            public static string GravarOriginacao(TRegistro_Lan_Originacao val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_Originacao qtb_Originacao = new TCD_Lan_Originacao();
                try
                {
                    if (banco == null)
                    {
                        qtb_Originacao.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Originacao.Banco_Dados = banco;

                    string retorno = qtb_Originacao.Grava(val);
                    
                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_Originacao.deletarBanco_Dados();
                }
            }

            public static string GravarPSOriginacao(TRegistro_Lan_Originacao val, TRegistro_CadNotaFiscalHeadge reg_nfheadge, decimal nr_contrato, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_Originacao qtb_Originacao = new TCD_Lan_Originacao();
                try
                {
                    if (banco == null)
                    {
                        qtb_Originacao.CriarBanco_Dados(true);
                        st_transacao = true;
                        banco = qtb_Originacao.Banco_Dados;
                    }
                    else
                        qtb_Originacao.Banco_Dados = banco;

                    //GRAVA O PESO DE CHEGADA
                    string retorno = qtb_Originacao.Grava(val);

                    //VERIFICA SE A NATUREZA DA PESAGEM EH DESTINO
                    object obj = new CamadaDados.Graos.TCD_CadContrato().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_contrato",
                                vOperador = "=",
                                vVL_Busca = "'"+nr_contrato.ToString()+"'"
                            }
                        }, "a.tp_natureza_pesagem");
                    if(obj != null)
                        if (obj.ToString().Trim().ToUpper().Equals("D"))
                        {
                            //ATUALIZA NO LANCTOFISCAL O VALOR DO SALDO DE ESTOQUE
                            new CamadaDados.TDataQuery(banco).executarSql("UPDATE TB_EST_ESTOQUE SET  " +
                                           "	QTD_Saida = " + reg_nfheadge.Ps_Chegada + ",  " +
                                           "	VL_SubTotal = ROUND((" + reg_nfheadge.Ps_Chegada + " * VL_unitario),2),  " +
                                           "	DT_ALT = GetDate() " +
                                           "  FROM TB_FAT_NotaFiscal_Item_X_Estoque a  " +
                                           "	JOIN tb_est_estoque b on a.cd_empresa = b.cd_empresa and a.cd_produto = b.cd_produto and a.id_lanctoestoque = b.id_lanctoestoque " +
                                           "  WHERE a.CD_Empresa = '" + reg_nfheadge.CD_Empresa + "' " +
                                           "  and a.nr_lanctofiscal = '" + reg_nfheadge.Nr_LanctoFiscal + "' " +
                                           "  and a.id_nfitem = '" + reg_nfheadge.ID_NFItem + "'", null);
                        }

                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_Originacao.deletarBanco_Dados();
                }
            }

            public static string DeletarOriginacao(TRegistro_Lan_Originacao val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_Originacao qtb_Originacao = new TCD_Lan_Originacao();
                try
                {
                    if (banco == null)
                    {
                        qtb_Originacao.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Originacao.Banco_Dados = banco;
                    qtb_Originacao.Deleta(val);
                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Originacao.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_Originacao.deletarBanco_Dados();
                }
            }

        }

    #endregion

    #region "Originacao_x_Faturamento"

        public class TCN_Lan_Originacao_x_Faturamento
        {
            public static TList_Lan_Originacao_x_Faturamento Buscar(decimal vID_Originacao,
                                                                    string vCD_Empresa,
                                                                    decimal vNr_LanctoFiscal,
                                                                    decimal vID_NFITem,
                                                                    decimal vQTD_Origem,
                                                                    decimal vVL_Origem,
                                                                    string vNm_campo,
                                                                    int vTop,
                                                                    TObjetoBanco banco)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vID_Originacao > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Originacao";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Originacao.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCD_Empresa.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vNr_LanctoFiscal > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Nr_LanctoFiscal";
                    filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_NFITem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFITem";
                    filtro[filtro.Length - 1].vVL_Busca = vID_NFITem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vQTD_Origem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.QTD_Origem";
                    filtro[filtro.Length - 1].vVL_Busca = vQTD_Origem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vVL_Origem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.VL_Origem";
                    filtro[filtro.Length - 1].vVL_Busca = vVL_Origem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_Lan_Originacao_x_Faturamento().Select(filtro, vTop, vNm_campo);
            }

            public static string GravarOriginacao_x_Faturamento(TRegistro_Lan_Originacao_x_Faturamento val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_Originacao_x_Faturamento qtb_Originacao_x_Faturamento = new TCD_Lan_Originacao_x_Faturamento();
                try
                {
                    if (banco == null)
                    {
                        qtb_Originacao_x_Faturamento.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Originacao_x_Faturamento.Banco_Dados = banco;

                    string retorno = qtb_Originacao_x_Faturamento.Grava(val);
                    
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.deletarBanco_Dados();
                }
            }

            public static string DeletarOriginacao_x_Faturamento(TRegistro_Lan_Originacao_x_Faturamento val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_Originacao_x_Faturamento qtb_Originacao_x_Faturamento = new TCD_Lan_Originacao_x_Faturamento();
                try
                {
                    if (banco == null)
                    {
                        qtb_Originacao_x_Faturamento.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Originacao_x_Faturamento.Banco_Dados = banco;
                    qtb_Originacao_x_Faturamento.Deleta(val);
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_Originacao_x_Faturamento.deletarBanco_Dados();
                }
            }
        }

     #endregion
}
