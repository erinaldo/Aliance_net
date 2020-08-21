using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Entrega;

namespace CamadaNegocio.Faturamento.Entrega
{
    public class TCN_RomaneioEntrega
    {
        public static TList_RomaneioEntrega Buscar(string Cd_empresa,
                                                   string Id_romaneio,
                                                   string Nm_cliente,
                                                   string Id_prevenda,
                                                   string Nr_pedido,
                                                   string Tp_data,
                                                   string Dt_ini,
                                                   string Dt_fin,
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
            if (!string.IsNullOrEmpty(Id_romaneio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_romaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_romaneio;
            }
            if (!string.IsNullOrEmpty(Nm_cliente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_cliente";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_cliente.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                                      "where a.cd_empresa = x.cd_empresa " +
                                                      "and a.id_romaneio = x.id_romaneio " +
                                                      "and x.id_prevenda = " + Id_prevenda + ")";
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                                      "where a.cd_empresa = x.cd_empresa " +
                                                      "and a.id_romaneio = x.id_romaneio " +
                                                      "and x.nr_pedido = " + Nr_pedido + ")";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.DT_Romaneio" : "a.DT_PrevEntrega") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.DT_Romaneio" : "a.DT_PrevEntrega") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }

            return new TCD_RomaneioEntrega(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_RomaneioEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RomaneioEntrega qtb_entrega = new TCD_RomaneioEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.Id_romaneiostr = CamadaDados.TDataQuery.getPubVariavel(qtb_entrega.Gravar(val), "@P_ID_ROMANEIO");
                //Item Entrega
                val.lItensDel.ForEach(p => TCN_ItensRomaneio.Excluir(p, qtb_entrega.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    if (p.St_processar)
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_romaneio = val.Id_romaneio;
                        TCN_ItensRomaneio.Gravar(p, qtb_entrega.Banco_Dados);
                    }
                });
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return val.Id_romaneiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_RomaneioEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RomaneioEntrega qtb_entrega = new TCD_RomaneioEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                //Buscar Itens Romaneio
                TCN_ItensRomaneio.Buscar(val.Cd_empresa,
                                         val.Id_romaneiostr,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         qtb_entrega.Banco_Dados).ForEach(p => TCN_ItensRomaneio.Excluir(p, qtb_entrega.Banco_Dados));
                qtb_entrega.Excluir(val);
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return val.Id_romaneiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensRomaneio
    {
        public static TList_ItensRomaneio Buscar(string Cd_empresa,
                                                 string Id_romaneio,
                                                 string Id_itemromaneio,
                                                 string Id_prevenda,
                                                 string Id_itemprevenda,
                                                 string Nr_pedido,
                                                 string Id_pedidoitem,
                                                 string Cd_produto,    
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
            if (!string.IsNullOrEmpty(Id_romaneio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_romaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_romaneio;
            }
            if (!string.IsNullOrEmpty(Id_itemromaneio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_itemromaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemromaneio;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_ItensRomaneio(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensRomaneio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensRomaneio qtb_entrega = new TCD_ItensRomaneio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.Id_itemromaneiostr = CamadaDados.TDataQuery.getPubVariavel(qtb_entrega.Gravar(val), "@P_ID_ITEMROMANEIO");
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return val.Id_itemromaneiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens Entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensRomaneio val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensRomaneio qtb_entrega = new TCD_ItensRomaneio();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                //Verificar se item esta amarrado a entrega
                if (new TCD_ItensCarga(qtb_entrega.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_romaneio",
                            vOperador = "=",
                            vVL_Busca = val.Id_romaneiostr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_itemromaneio",
                            vOperador = "=",
                            vVL_Busca = val.Id_itemromaneiostr
                        }
                    }, "1") != null)
                    throw new Exception("Item Romaneio possui entrega.");
                qtb_entrega.Excluir(val);
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return val.Id_itemromaneiostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item Entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }
    }
}
