using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    #region Venda Mesa Conveniencia
    public class TCN_VendaMesaConv
    {
        public static TList_VendaMesaConv Buscar(string Id_venda,
                                                 string Cd_empresa,
                                                 string Nm_cliente,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 string St_registro,
                                                 bool St_faturar,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_venda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_venda;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nm_cliente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_cliente";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_cliente.Trim() + "%')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_venda";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_venda";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_faturar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qtd_faturar";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_VendaMesaConv(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VendaMesaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaMesaConv qtb_venda = new TCD_VendaMesaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.Id_vendastr = CamadaDados.TDataQuery.getPubVariavel(qtb_venda.Gravar(val), "@P_ID_VENDA");

                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return val.Id_vendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaMesaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaMesaConv qtb_venda = new TCD_VendaMesaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_venda.Gravar(val);
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return val.Id_vendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Itens Venda
    public class TCN_ItensVendaMesaConv
    {
        public static TList_ItensVendaMesaConv Buscar(string Id_venda,
                                                      string Cd_empresa,
                                                      string Id_item,
                                                      string Cd_produto,
                                                      bool St_saldofat,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_venda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_venda;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (St_saldofat)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.quantidade - a.qtd_faturada";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_ItensVendaMesaConv(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_ItensVendaMesaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensVendaMesaConv qtb_item = new TCD_ItensVendaMesaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_item.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensVendaMesaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensVendaMesaConv qtb_item = new TCD_ItensVendaMesaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                qtb_item.Excluir(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Itens Venda X Venda Rapida
    public class TCN_VendaMesa_X_VendaRapida
    {
        public static TList_VendaMesa_X_VendaRapida Buscar(string Id_venda,
                                                           string Cd_empresa,
                                                           string Id_item,
                                                           string Id_lancto,
                                                           string Id_cupom,
                                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_venda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_venda;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            return new TCD_VendaMesa_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VendaMesa_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaMesa_X_VendaRapida qtb_venda = new TCD_VendaMesa_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                string retorno = qtb_venda.Gravar(val);
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaMesa_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaMesa_X_VendaRapida qtb_venda = new TCD_VendaMesa_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_venda.CriarBanco_Dados(true);
                else
                    qtb_venda.Banco_Dados = banco;
                qtb_venda.Excluir(val);
                if (st_transacao)
                    qtb_venda.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_venda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_venda.deletarBanco_Dados();
            }
        }
    }
    #endregion
}