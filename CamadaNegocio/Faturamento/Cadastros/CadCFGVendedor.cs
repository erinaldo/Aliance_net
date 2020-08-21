using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_Vendedor_X_Empresa
    {
        public static TList_Vendedor_X_Empresa Buscar(string Cd_vendedor,
                                                      string Cd_empresa,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_Vendedor_X_Empresa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vendedor_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_Empresa qtb_vend = new TCD_Vendedor_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vendedor x empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vendedor_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_Empresa qtb_vend = new TCD_Vendedor_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir vendedor x empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Vendedor_X_CondPgto
    {
        public static TList_Vendedor_X_CondPgto Buscar(string Cd_vendedor,
                                                       string Cd_condpgto,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_condpgto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }

            return new TCD_Vendedor_X_CondPgto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vendedor_X_CondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_CondPgto qtb_vend = new TCD_Vendedor_X_CondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Gravar(IEnumerable<TRegistro_Vendedor_X_CondPgto> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_CondPgto qtb_vend = new TCD_Vendedor_X_CondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                val.ToList<TRegistro_Vendedor_X_CondPgto>().ForEach(p => Gravar(p, qtb_vend.Banco_Dados));
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vendedor_X_CondPgto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_CondPgto qtb_vend = new TCD_Vendedor_X_CondPgto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Vendedor_X_TabelaPreco
    {
        public static TList_Vendedor_X_TabelaPreco Buscar(string Cd_vendedor,
                                                          string Cd_tabelapreco,
                                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            return new TCD_Vendedor_X_TabelaPreco(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vendedor_X_TabelaPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_TabelaPreco qtb_vend = new TCD_Vendedor_X_TabelaPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Gravar(IEnumerable<TRegistro_Vendedor_X_TabelaPreco> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_TabelaPreco qtb_vend = new TCD_Vendedor_X_TabelaPreco();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                val.ToList<TRegistro_Vendedor_X_TabelaPreco>().ForEach(p => Gravar(p, qtb_vend.Banco_Dados));
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vendedor_X_TabelaPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_TabelaPreco qtb_vend = new TCD_Vendedor_X_TabelaPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Vendedor_X_RegiaoVenda
    {
        public static TList_Vendedor_X_RegiaoVenda Buscar(string Cd_vendedor,
                                                          string Id_regiao,
                                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_regiao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_regiao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_regiao;
            }
            return new TCD_Vendedor_X_RegiaoVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vendedor_X_RegiaoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_RegiaoVenda qtb_vend = new TCD_Vendedor_X_RegiaoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Gravar(IEnumerable<TRegistro_Vendedor_X_RegiaoVenda> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_RegiaoVenda qtb_vend = new TCD_Vendedor_X_RegiaoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                val.ToList<TRegistro_Vendedor_X_RegiaoVenda>().ForEach(p => Gravar(p, qtb_vend.Banco_Dados));
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vendedor_X_RegiaoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_RegiaoVenda qtb_vend = new TCD_Vendedor_X_RegiaoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Vendedor_X_GrupoProd
    {
        public static TList_Vendedor_X_GrupoProd Buscar(string Cd_vendedor,
                                                      string Cd_grupo,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            return new TCD_Vendedor_X_GrupoProd(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Vendedor_X_GrupoProd val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_GrupoProd qtb_vend = new TCD_Vendedor_X_GrupoProd();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vendedor x Grupo Produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Vendedor_X_GrupoProd val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Vendedor_X_GrupoProd qtb_vend = new TCD_Vendedor_X_GrupoProd();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir vendedor x Grupo Produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Gerente_X_Vendedor
    {
        public static TList_Gerente_X_Vendedor Buscar(string Cd_gerente,
                                                      string Cd_vendedor,
                                                      string Cd_empresa,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_gerente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_gerente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_gerente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_Gerente_X_Vendedor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Gerente_X_Vendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Gerente_X_Vendedor qtb_vend = new TCD_Gerente_X_Vendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                string retorno = qtb_vend.Gravar(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Gerente X Vendedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Gerente_X_Vendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Gerente_X_Vendedor qtb_vend = new TCD_Gerente_X_Vendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vend.CriarBanco_Dados(true);
                else
                    qtb_vend.Banco_Dados = banco;
                qtb_vend.Excluir(val);
                if (st_transacao)
                    qtb_vend.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vend.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Gerente X Vendedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vend.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DescontoVendedor
    {
        public static TList_DescontoVendedor Buscar(string Cd_vendedor,
                                                    string Cd_empresa,
                                                    string Cd_grupo,
                                                    string Cd_tabelapreco,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            return new TCD_DescontoVendedor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DescontoVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DescontoVendedor qtb_desc = new TCD_DescontoVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else qtb_desc.Banco_Dados = banco;
                //Verificar se existe configuracao
                if ((!string.IsNullOrEmpty(val.Cd_empresa)) &&
                    string.IsNullOrEmpty(val.Cd_grupo) &&
                    string.IsNullOrEmpty(val.Cd_tabelapreco))
                {
                    object obj = qtb_desc.BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_grupo",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_tabelapreco",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "a.id_desconto");
                    if (obj != null)
                        val.Id_desconto = decimal.Parse(obj.ToString());
                }
                if ((!string.IsNullOrEmpty(val.Cd_grupo)) && string.IsNullOrEmpty(val.Cd_tabelapreco))
                {
                    object obj = qtb_desc.BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_grupo",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_grupo.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_tabelapreco",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "a.id_desconto");
                    if (obj != null)
                        val.Id_desconto = decimal.Parse(obj.ToString());
                }
                if ((!string.IsNullOrEmpty(val.Cd_tabelapreco)) && string.IsNullOrEmpty(val.Cd_grupo))
                {
                    object obj = qtb_desc.BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_tabelapreco",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_tabelapreco.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_grupo",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "a.id_desconto");
                    if (obj != null)
                        val.Id_desconto = decimal.Parse(obj.ToString());
                }
                if ((!string.IsNullOrEmpty(val.Cd_grupo)) && (!string.IsNullOrEmpty(val.Cd_tabelapreco)))
                {
                    object obj = qtb_desc.BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_grupo",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_grupo.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_tabelapreco",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_tabelapreco.Trim() + "'"
                                        }
                                    }, "a.id_desconto");
                    if (obj != null)
                        val.Id_desconto = decimal.Parse(obj.ToString());
                }
                val.Id_descontostr = CamadaDados.TDataQuery.getPubVariavel(qtb_desc.Gravar(val), "@P_ID_DESCONTO");
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return val.Id_descontostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DescontoVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DescontoVendedor qtb_desc = new TCD_DescontoVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desc.CriarBanco_Dados(true);
                else qtb_desc.Banco_Dados = banco;
                qtb_desc.Excluir(val);
                if (st_transacao)
                    qtb_desc.Banco_Dados.Commit_Tran();
                return val.Id_descontostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MetaVendedor
    {
        public static TList_MetaVendedor Buscar(string Cd_vendedor,
                                                    string Cd_empresa,
                                                    string MesVig,
                                                    string AnoVig,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(MesVig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.MesVig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = MesVig;
            }
            if (!string.IsNullOrEmpty(AnoVig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.AnoVig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = AnoVig;
            }
            return new TCD_MetaVendedor(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_MetaVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MetaVendedor qtb_meta = new TCD_MetaVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_meta.CriarBanco_Dados(true);
                else qtb_meta.Banco_Dados = banco;
                val.Id_metastr = CamadaDados.TDataQuery.getPubVariavel(qtb_meta.Gravar(val), "@P_ID_META");
                if (st_transacao)
                    qtb_meta.Banco_Dados.Commit_Tran();
                return val.Id_metastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_meta.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_meta.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MetaVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MetaVendedor qtb_meta = new TCD_MetaVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_meta.CriarBanco_Dados(true);
                else qtb_meta.Banco_Dados = banco;
                qtb_meta.Excluir(val);
                if (st_transacao)
                    qtb_meta.Banco_Dados.Commit_Tran();
                return val.Id_metastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_meta.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_meta.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PercComissao_X_Desconto
    {
        public static TList_PercComissao_X_Desconto Buscar(string Cd_empresa,
                                                           string Cd_vendedor,
                                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_vendedor))
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_vendedor", "'" + Cd_vendedor.Trim() + "'");
            return new TCD_PercComissao_X_Desconto(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_PercComissao_X_Desconto val, BancoDados.TObjetoBanco banco)
        {
            TCD_PercComissao_X_Desconto qtb_perc = new TCD_PercComissao_X_Desconto();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else qtb_perc.Banco_Dados = banco;
                val.Id_configstr = CamadaDados.TDataQuery.getPubVariavel(qtb_perc.Gravar(val), "@P_ID_CONFIG");
                if (st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_PercComissao_X_Desconto val, BancoDados.TObjetoBanco banco)
        {
            TCD_PercComissao_X_Desconto qtb_perc = new TCD_PercComissao_X_Desconto();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else qtb_perc.Banco_Dados = banco;
                qtb_perc.Excluir(val);
                if (st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }
    }
}
