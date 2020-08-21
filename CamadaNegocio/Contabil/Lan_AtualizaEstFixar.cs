using BancoDados;
using CamadaDados.Contabil;
using System;
using Utils;

namespace CamadaNegocio.Contabil
{
    public class TCN_AtualizaEstFixar
    {
        public static TList_AtualizaEstFixar Buscar(string Cd_empresa,
                                                    string Cd_produto,
                                                    string Dt_ini,
                                                    string Dt_fin,
                                                    string Tp_movimento,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if(!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if(!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            return new TCD_AtualizaEstFixar(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_AtualizaEstFixar val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaEstFixar qtb_atualiza = new TCD_AtualizaEstFixar();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atualiza.CriarBanco_Dados(true);
                else qtb_atualiza.Banco_Dados = banco;
                val.Id_atualizastr = qtb_atualiza.Gravar(val);
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.Commit_Tran();
                return val.Id_atualizastr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atualização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atualiza.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_AtualizaEstFixar val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaEstFixar qtb_atualiza = new TCD_AtualizaEstFixar();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atualiza.CriarBanco_Dados(true);
                else qtb_atualiza.Banco_Dados = banco;
                qtb_atualiza.Excluir(val);
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.Commit_Tran();
                return val.Id_atualizastr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atualização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atualiza.deletarBanco_Dados();
            }
        }
        public static void AjustarEstFixar(string Cd_empresa, 
                                           string Cd_produto,
                                           DateTime Dt_lancto,
                                           decimal SaldoEstornar,
                                           decimal SaldoAjustar,
                                           string Tp_movimento,
                                           TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaEstFixar qtb_atualiza = new TCD_AtualizaEstFixar();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atualiza.CriarBanco_Dados(true);
                else qtb_atualiza.Banco_Dados = banco;
                if (qtb_atualiza.BuscarEscalar(
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
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'" + Tp_movimento.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))",
                            vOperador = ">=",
                            vVL_Busca = "'" + Dt_lancto.ToString("yyyyMMdd") + "'"
                        }
                    }, "1") != null)
                    throw new Exception("Existe lançamento de atualização para periodo igual ou maior que o informado.");
                //Buscar valor ajuste anterior
                //object obj = qtb_atualiza.BuscarEscalar(
                //                new TpBusca[]
                //                {
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = "a.cd_empresa",
                //                        vOperador = "=",
                //                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                //                    },
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = "a.cd_produto",
                //                        vOperador = "=",
                //                        vVL_Busca = "'" + Cd_produto.Trim() + "'"
                //                    },
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = "a.tp_movimento",
                //                        vOperador = "=",
                //                        vVL_Busca = "'" + Tp_movimento.Trim() + "'"
                //                    },
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))",
                //                        vOperador = "<",
                //                        vVL_Busca = "'" + Dt_lancto.ToString("yyyyMMdd") + "'"
                //                    },
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = "a.tp_registro",
                //                        vOperador = "=",
                //                        vVL_Busca = "'A'"
                //                    }
                //                }, "a.valor", string.Empty, "a.dt_lancto desc", null);
                //SaldoEstornar += obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
                //Gravar estorno
                string ret = qtb_atualiza.Gravar(new TRegistro_AtualizaEstFixar
                                {
                                    Cd_empresa = Cd_empresa,
                                    Cd_produto = Cd_produto,
                                    Dt_lancto = Dt_lancto,
                                    Tp_registro = "E",
                                    Tp_movimento = Tp_movimento,
                                    Valor = SaldoEstornar
                                });
                //Contabilizar estorno
                TList_ProcCompFixar lCont = TCN_Lan_ProcContabil.BuscarProc_CompFixar(Cd_empresa,
                                                                                      CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ATUALIZA"),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      "E",
                                                                                      Tp_movimento,
                                                                                      Cd_produto,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      false,
                                                                                      qtb_atualiza.Banco_Dados);
                if (lCont.Count > 0)
                    if(lCont.Exists(p=> p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue))
                        TCN_LanContabil.ProcessaCTB_CompFixar(lCont, qtb_atualiza.Banco_Dados);
                //Gravar atualização
                ret = qtb_atualiza.Gravar(new TRegistro_AtualizaEstFixar
                        {
                            Cd_empresa = Cd_empresa,
                            Cd_produto = Cd_produto,
                            Dt_lancto = Dt_lancto,
                            Tp_registro = "A",
                            Tp_movimento = Tp_movimento,
                            Valor = SaldoAjustar
                        });
                //Contabilizar atualização
                lCont = TCN_Lan_ProcContabil.BuscarProc_CompFixar(Cd_empresa,
                                                                  CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ATUALIZA"),
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  "A",
                                                                  Tp_movimento,
                                                                  Cd_produto,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  decimal.Zero,
                                                                  decimal.Zero,
                                                                  false,
                                                                  qtb_atualiza.Banco_Dados);
                if (lCont.Count > 0)
                    if (lCont.Exists(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue))
                            TCN_LanContabil.ProcessaCTB_CompFixar(lCont, qtb_atualiza.Banco_Dados);
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_atualiza.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ajustar estoque fixar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atualiza.deletarBanco_Dados();
            }
        }
    }
}
