using System;
using System.Collections.Generic;
using CamadaDados.Faturamento.ProgEspecialVenda;

namespace CamadaNegocio.Faturamento.ProgEspecialVenda
{
    public class TCN_ProgEspecialVenda
    {
        public static TList_ProgEspecialVenda Buscar(string Cd_empresa,
                                                     string Id_categoriaclifor,
                                                     string Cd_grupo,
                                                     string Cd_clifor,
                                                     string Cd_produto,
                                                     string Cd_tabelapreco,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_categoriaclifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_categoriaclifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_categoriaclifor;
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            return new TCD_ProgEspecialVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static TRegistro_ProgEspecialVenda BuscarProg(string Cd_empresa,
                                                             string Cd_clifor,
                                                             string Cd_produto,
                                                             string Cd_tabelapreco,
                                                             BancoDados.TObjetoBanco banco)
        {
            TList_ProgEspecialVenda lProg = new TList_ProgEspecialVenda();
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                lProg = new TCD_ProgEspecialVenda(banco).Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " + 
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + Cd_clifor.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + Cd_clifor.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "a.cd_tabelapreco = '" + Cd_tabelapreco.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_inivigencia, getdate()))))",
                                    vOperador = "<=",
                                    vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_finvigencia, getdate()))))",
                                    vOperador = ">=",
                                    vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                }
                            }, 1, string.Empty);
            }
            if (lProg.Count > 0)
                return lProg[0];
            else
            {
                lProg = new TCD_ProgEspecialVenda(banco).Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " + 
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + Cd_clifor.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + Cd_clifor.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.cd_tabelapreco, '')",
                                    vOperador = "=",
                                    vVL_Busca = "''"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_inivigencia, getdate()))))",
                                    vOperador = "<=",
                                    vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), isnull(a.dt_finvigencia, getdate()))))",
                                    vOperador = ">=",
                                    vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                }
                            }, 1, string.Empty);
                if (lProg.Count > 0)
                    return lProg[0];
                else return null;
            }
        }

        public static string Gravar(TRegistro_ProgEspecialVenda val, 
                                    List<CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto> lGrupo,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProgEspecialVenda qtb_prog = new TCD_ProgEspecialVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prog.CriarBanco_Dados(true);
                else
                    qtb_prog.Banco_Dados = banco;
                string retorno = string.Empty;
                if (lGrupo == null ? false : lGrupo.Count > 0)
                {
                    lGrupo.ForEach(p =>
                    {
                        val.Cd_grupo = p.CD_Grupo;
                        qtb_prog.Gravar(val);
                    });
                    retorno = "OK";
                }
                else
                    retorno = qtb_prog.Gravar(val);
                if (st_transacao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prog.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProgEspecialVenda val, BancoDados.TObjetoBanco banco)
        {
            TCD_ProgEspecialVenda qtb_prog = new TCD_ProgEspecialVenda();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_prog.CriarBanco_Dados(true);
                else
                    qtb_prog.Banco_Dados = banco;
                qtb_prog.Excluir(val);
                if (st_transacao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prog.deletarBanco_Dados();
            }
        }
    }
}
