using CamadaDados.Restaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Restaurante
{
    public class TCN_MovBoliche
    {
        public static TList_MovBoliche Buscar(string Cd_Empresa,
                                              string Id_Cartao,
                                              string Id_Pista,
                                              string Id_Mov,
                                              string Id_PreVenda,
                                              string Id_Item,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_Cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_Cartao.ToString().Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_Pista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_Pista.ToString().Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_Mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_Mov.ToString().Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_PreVenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_PreVenda.ToString().Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_Item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_Item.ToString().Trim() + "'";
            }
           
            return new TCD_MovBoliche(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovBoliche qtb_orc = new TCD_MovBoliche();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                string ret = qtb_orc.Gravar(val);
                val.Id_Mov = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_MOV"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_Mov.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovBoliche val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovBoliche qtb_orc = new TCD_MovBoliche();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;

                string ret = qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
