using System;
using System.Collections.Generic;
using CamadaDados.Fiscal;
using Utils;

namespace CamadaNegocio.Fiscal
{
    public class TCN_Mov_X_CFOP
    {
        public static TList_Mov_X_CFOP Buscar(string Cd_movimentacao,
                                              string Cd_condfiscal_produto,
                                              string Cd_cfop_dentroestado,
                                              string Cd_cfop_foraestado,
                                              string Cd_cfop_internacional,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_movimentacao;
            }
            if (!string.IsNullOrEmpty(Cd_condfiscal_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condfiscal_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condfiscal_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cfop_dentroestado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cfop_dentroestado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cfop_dentroestado.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cfop_foraestado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cfop_foraestado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cfop_foraestado.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cfop_internacional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cfop_internacional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cfop_internacional.Trim() + "'";
            }
            return new TCD_Mov_X_CFOP(banco).Select(filtro, 0, string.Empty);
        }

        public static bool BuscarCFOP(string Cd_movimentacao,
                                      string Cd_condfiscal_produto,
                                      string St_dentroestado,
                                      string UF_Origem,
                                      string UF_Destino,
                                      string TP_Movimento,
                                      string Cd_condfiscal_clifor,
                                      string Cd_empresa,
                                      ref TRegistro_CadCFOP rCfop,
                                      BancoDados.TObjetoBanco banco)
        {
            if(!string.IsNullOrEmpty(Cd_movimentacao) &&
                !string.IsNullOrEmpty(Cd_condfiscal_produto) &&
                !string.IsNullOrEmpty(UF_Origem) &&
                !string.IsNullOrEmpty(UF_Destino) &&
                !string.IsNullOrEmpty(TP_Movimento) &&
                !string.IsNullOrEmpty(Cd_condfiscal_clifor) &&
                !string.IsNullOrEmpty(Cd_empresa))
            {
                TList_CadCondFiscalICMS lCond = new TCD_CadCondFiscalICMS().Select(
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
                                                            vNM_Campo = "a.cd_movimentacao",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Cd_movimentacao.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_condfiscal_produto",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Cd_condfiscal_produto.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_condfiscal_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Cd_condfiscal_clifor.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.tp_movimento",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + TP_Movimento.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.CD_UFOrig",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + UF_Origem.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.CD_UFDest",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + UF_Destino.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);
                if (lCond.Count > 0)
                    if (!string.IsNullOrEmpty(lCond[0].Cd_cfop))
                    {
                        rCfop = new TRegistro_CadCFOP();
                        rCfop.CD_CFOP = lCond[0].Cd_cfop;
                        rCfop.DS_CFOP = lCond[0].Ds_cfop;
                        return true;
                    }
            }
            TList_CadCFOP lCfop = new TCD_CadCFOP().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fis_mov_x_cfop x " +
                                                        "where x.cd_movimentacao = '" + Cd_movimentacao.Trim() + "' " +
                                                        "and x.cd_condfiscal_produto = '" + Cd_condfiscal_produto.Trim() + "' " +
                                                        (St_dentroestado.Trim().ToUpper().Equals("D") ? "and x.cd_cfop_dentroestado = a.cd_cfop)" : St_dentroestado.Trim().ToUpper().Equals("F") ? "and x.cd_cfop_foraestado = a.cd_cfop)" : "and x.cd_cfop_internacional = a.cd_cfop)")
                                        }
                                    }, 1, string.Empty);
            if (lCfop.Count > 0)
            {
                rCfop = lCfop[0];
                return true;
            }
            else return false;
        }

        public static string Gravar(TRegistro_Mov_X_CFOP val, 
                                    List<TRegistro_CadCondFiscalProduto> lCondProd,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_CFOP qtb_mov = new TCD_Mov_X_CFOP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                string retorno = string.Empty;
                lCondProd.ForEach(p =>
                    {
                        val.Cd_condfiscal_produto = p.CD_CONDFISCAL_PRODUTO;
                        retorno = qtb_mov.Gravar(val);
                    });
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Mov_X_CFOP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_CFOP qtb_mov = new TCD_Mov_X_CFOP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }
}
