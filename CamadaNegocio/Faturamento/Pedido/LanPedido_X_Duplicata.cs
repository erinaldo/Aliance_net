using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido_X_Duplicata
    {
        public static TList_LanPedido_X_Duplicata Buscar(string Nr_pedido,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_LanPedido_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(decimal Nr_pedido,
                                                                                       TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.nr_pedido = '" + Nr_pedido + "')"
                    }
                }, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDupNf(string Nr_pedido,
                                                                                         TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                    "inner join tb_fat_notafiscal_item y " +
                                    "on x.cd_empresa = y.cd_empresa " +
                                    "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctoduplicata = a.nr_lancto " +
                                    "and y.nr_pedido = " + Nr_pedido + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanPedido_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_X_Duplicata qtb_ped = new TCD_LanPedido_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                string retorno = qtb_ped.Gravar(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanPedido_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_X_Duplicata qtb_ped = new TCD_LanPedido_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                qtb_ped.Excluir(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }
    }
}
