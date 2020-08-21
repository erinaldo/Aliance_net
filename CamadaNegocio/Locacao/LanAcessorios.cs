using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Locacao;
using Utils;

namespace CamadaNegocio.Locacao
{
    public class TCN_AcessoriosItem
    {
        public static TList_AcessoriosItem buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_itemloc,
                                             string Id_acessorio,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_acessorio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_acessorio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_acessorio;
            }
            return new TCD_AcessoriosItem(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AcessoriosItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcessoriosItem qtb_locacao = new TCD_AcessoriosItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.Id_acessoriostr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_ACESSORIO");
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_acessoriostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string BaixarAcessorios(TRegistro_AcessoriosItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcessoriosItem qtb_locacao = new TCD_AcessoriosItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                if (val.Qtd_saldo > decimal.Zero)
                {
                    //Buscar Local Arm
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_locacao.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                    //Buscar Vl.Médio
                    decimal vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(val.Cd_empresa,
                                                                                     val.Cd_produto,
                                                                                     qtb_locacao.Banco_Dados);
                    //Gravar Estoque
                    string ret_est =
                       Estoque.TCN_LanEstoque.GravarEstoque(
                           new CamadaDados.Estoque.TRegistro_LanEstoque()
                           {
                               Cd_empresa = val.Cd_empresa,
                               Cd_produto = val.Cd_produto,
                               Cd_local = obj.ToString(),
                               Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                               Tp_movimento = "E",
                               Qtd_entrada = val.Qtd_saldo,
                               Qtd_saida = decimal.Zero,
                               Vl_unitario = vl_unit,
                               Vl_subtotal = vl_unit * val.Qtd_saldo,
                               Tp_lancto = "N",
                               St_registro = "A",
                               Ds_observacao = "DEVOLUÇÃO DE ACESSORIOS LOCAÇÃO Nº " + val.Id_locacaostr,
                           }, qtb_locacao.Banco_Dados);
                    val.Id_lanctoestoque_estr = CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE");
                }
                //Gravar Acessorios
                Gravar(val, qtb_locacao.Banco_Dados);
                val.Id_acessoriostr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_ACESSORIO");
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_acessoriostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AcessoriosItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AcessoriosItem qtb_loc = new TCD_AcessoriosItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                if (val.Id_lanctoestoque_s.HasValue)
                    Estoque.TCN_LanEstoque.CancelarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Id_lanctoestoque = val.Id_lanctoestoque_s.Value
                        }, qtb_loc.Banco_Dados);
                if(val.Id_lanctoestoque_e.HasValue)
                    Estoque.TCN_LanEstoque.CancelarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Id_lanctoestoque = val.Id_lanctoestoque_e.Value
                        }, qtb_loc.Banco_Dados);

                //Validar existencia de prevenda para acessorio
                TList_Acessorios_X_PreVenda _Acessorios_X_PreVendas = TCN_Acessorios_X_PreVenda.buscar(val.Cd_empresa, val.Id_locacaostr, val.Id_itemlocstr, val.Id_acessoriostr, string.Empty, string.Empty, null);
                if (_Acessorios_X_PreVendas.Count > 0)
                {
                    _Acessorios_X_PreVendas.ForEach(p => 
                    {
                        TCN_Acessorios_X_PreVenda.Excluir(p, qtb_loc.Banco_Dados);
                    });
                }

                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Acessorios_X_PreVenda
    {
        public static TList_Acessorios_X_PreVenda buscar(string Cd_empresa,
                                                         string Id_locacao,
                                                         string Id_itemloc,
                                                         string Id_acessorio,
                                                         string Id_prevenda,
                                                         string Id_itemprevenda,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_acessorio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_acessorio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_acessorio;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_prevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemprevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            return new TCD_Acessorios_X_PreVenda(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Acessorios_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acessorios_X_PreVenda qtb_locacao = new TCD_Acessorios_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                string retorno = qtb_locacao.Gravar(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Acessorios_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acessorios_X_PreVenda qtb_loc = new TCD_Acessorios_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }
}
