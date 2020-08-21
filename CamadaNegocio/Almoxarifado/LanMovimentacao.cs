using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Almoxarifado;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_SaldoAlmoxarifado
    {
        public static TList_SaldoAlmoxarifado Buscar(string Cd_empresa,
                                                     string Id_almox,
                                                     string Cd_produto,
                                                     bool St_comsaldo,
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
            if (!string.IsNullOrEmpty(Id_almox))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_almox";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_almox;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (St_comsaldo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.saldo";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_SaldoAlmoxarifado(banco).Select(filtro, 0, string.Empty);
        }

        public static decimal ConsultaSaldoAlmox(string Cd_empresa,
                                                 string Id_almox,
                                                 string Cd_produto,
                                                 BancoDados.TObjetoBanco banco)
        {
            object obj = new TCD_SaldoAlmoxarifado(banco).BuscarEscalar(
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
                                    vNM_Campo = "a.id_almox",
                                    vOperador = "=",
                                    vVL_Busca = Id_almox
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_produto.Trim() + "'"
                                }
                            }, "isnull(a.saldo, 0)");
            return obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
        }

        public static decimal Vl_Custo_Almox_Prod(string Cd_empresa,
                                                  string Id_almox,
                                                  string Cd_produto,
                                                  BancoDados.TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(Cd_empresa) || 
                string.IsNullOrEmpty(Id_almox) || 
                string.IsNullOrEmpty(Cd_produto))
                return 0;
            object obj = new TCD_SaldoAlmoxarifado(banco).BuscarEscalar(
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
                                    vNM_Campo = "a.id_almox",
                                    vOperador = "=",
                                    vVL_Busca = Id_almox
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_produto.Trim() + "'"
                                }
                            }, "isnull(a.vl_custo, 0)");
            return obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
        }
    }

    public class TCN_Movimentacao
    {
        public static TList_Movimentacao Buscar(string Id_movimentacao,
                                                string Cd_empresa,
                                                string LoginAlmoxarife,
                                                string Id_almox,
                                                string Cd_produto,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string Tp_movimento,
                                                string St_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movimentacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(LoginAlmoxarife))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.loginalmoxarife";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + LoginAlmoxarife.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_almox))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_almox";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_almox;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && Dt_ini.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_movimento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && Dt_fin.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_movimento)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_movimento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Movimentacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Movimentacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Movimentacao qtb_mov = new TCD_Movimentacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                if (val.Tp_movimento.Trim().ToUpper().Equals("S"))
                {
                    decimal saldo = TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(val.Cd_empresa,
                                                                             val.Id_almoxstr,
                                                                             val.Cd_produto,
                                                                             qtb_mov.Banco_Dados);
                    if (saldo < val.Quantidade)
                        throw new Exception("Não existe saldo suficiente para gravar movimentação.\r\n" +
                                            "Saldo Atual: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                                            "Qtde Requerida: " + val.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")));
                }
                val.LoginAlmoxarife = Utils.Parametros.pubLogin;
                val.Id_movimentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_mov.Gravar(val), "@P_ID_MOVIMENTO");
                if (val.rNFItem != null)
                {
                    val.rNFItem.Id_movimento = val.Id_movimento;
                    TCN_Mov_X_NFItem.Gravar(val.rNFItem, qtb_mov.Banco_Dados);
                }
                if (val.rRequisicao != null)
                {
                    val.rRequisicao.Id_movimento = val.Id_movimento;
                    val.rRequisicao.Cd_empresa = val.Cd_empresa;
                    TCN_Mov_X_Requisicao.Gravar(val.rRequisicao, qtb_mov.Banco_Dados);
                }
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static void Cancelar(TRegistro_Movimentacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Movimentacao qtb_mov = new TCD_Movimentacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                if (val.Tp_movimento.Trim().ToUpper().Equals("E"))
                {
                    decimal saldo = TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(val.Cd_empresa,
                                                                             val.Id_almoxstr,
                                                                             val.Cd_produto,
                                                                             qtb_mov.Banco_Dados);
                    if (saldo < val.Quantidade)
                        throw new Exception("Não existe saldo suficiente para cancelar movimentação.\r\n" +
                                            "Saldo Atual: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                                            "Qtde Requerida: " + val.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")));
                }
                val.St_registro = "C";
                Gravar(val, qtb_mov.Banco_Dados);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Movimentacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Movimentacao qtb_mov = new TCD_Movimentacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Mov_X_NFItem
    {
        public static TList_Mov_X_NFItem Buscar(string Id_movimento,
                                                string Cd_empresa,
                                                string Nr_lanctofiscal,
                                                string Id_nfitem,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movimento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            return new TCD_Mov_X_NFItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Mov_X_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_NFItem qtb_mov = new TCD_Mov_X_NFItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                string retorno = qtb_mov.Gravar(val);
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

        public static string Excluir(TRegistro_Mov_X_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_NFItem qtb_mov = new TCD_Mov_X_NFItem();
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

    public class TCN_Mov_X_Requisicao
    {
        public static TList_Mov_X_Requisicao Buscar(string id_movimento,
                                                    string id_requisicao,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_movimento;
            }
            if (!string.IsNullOrEmpty(id_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_requisicao;
            }
            return new TCD_Mov_X_Requisicao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Mov_X_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_Requisicao qtb_mov = new TCD_Mov_X_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                string retorno = qtb_mov.Gravar(val);
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

        public static string Excluir(TRegistro_Mov_X_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Mov_X_Requisicao qtb_mov = new TCD_Mov_X_Requisicao();
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
