using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota.Cadastros;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_RotaFrete
    {
        public static TList_RotaFrete Buscar(string Id_rota,
                                             string Ds_rota,
                                             string Cd_cidade_origem,
                                             string Cd_cidade_destino,
                                             string Cd_unidade_frete,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_rota))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rota";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rota;
            }
            if (!string.IsNullOrEmpty(Ds_rota))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_rota";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_rota.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Cd_cidade_origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cidade_origem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cidade_origem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_cidade_destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cidade_destino";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cidade_destino.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_unidade_frete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_unidfrete";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_unidade_frete.Trim() + "'";
            }
            return new TCD_RotaFrete(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_RotaFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RotaFrete qtb_rotafrete = new TCD_RotaFrete();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_rotafrete.CriarBanco_Dados(true);
                else
                    qtb_rotafrete.Banco_Dados = banco;
                string retorno = qtb_rotafrete.Gravar(val);
                if (st_transacao)
                    qtb_rotafrete.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rotafrete.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Rota Frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rotafrete.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_RotaFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RotaFrete qtb_rotafrete = new TCD_RotaFrete();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_rotafrete.CriarBanco_Dados(true);
                else
                    qtb_rotafrete.Banco_Dados = banco;
                qtb_rotafrete.Excluir(val);
                if (st_transacao)
                    qtb_rotafrete.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rotafrete.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Rota Frete " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rotafrete.deletarBanco_Dados();
            }
        }
    }
}
