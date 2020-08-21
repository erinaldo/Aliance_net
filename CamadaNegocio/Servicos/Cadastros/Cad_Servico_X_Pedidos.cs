using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_Cad_Servico_X_Pedidos
    {
         public static TList_Servico_X_Pedidos Buscar(string Id_OS,
                                                  string CD_Empresa,
                                                  string NR_Pedido,
                                                  string TP_Pedido,
                                                  int vTop,
                                                  string vNm_campo)
        {
            TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_OS.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_OS";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_OS.Trim();
            }
            
            if (CD_Empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Trim() + "'";
            }

            if (NR_Pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_PEDIDO";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca =  NR_Pedido.Trim() ;
            }

            if (TP_Pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + TP_Pedido.Trim() + "'";
            }

            return new TCD_Servico_X_Pedidos().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar_Servico_X_Pedidos(TRegistro_Servico_X_Pedidos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Servico_X_Pedidos qtb_Servico_X_Pedidos = new TCD_Servico_X_Pedidos();
            try
            {
                if (banco == null)
                {
                    qtb_Servico_X_Pedidos.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Servico_X_Pedidos.Banco_Dados = banco;
                string retorno = qtb_Servico_X_Pedidos.Gravar_Servico_X_Pedido(val);
                if (st_transacao)
                    qtb_Servico_X_Pedidos.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Servico_X_Pedidos.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_Servico_X_Pedidos.deletarBanco_Dados();
            }
        }

        public static string Deleta_Servico_X_Pedidos(TRegistro_Servico_X_Pedidos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Servico_X_Pedidos qtb_Servico_X_Pedidos = new TCD_Servico_X_Pedidos();
            try
            {
                if (banco == null)
                {
                    qtb_Servico_X_Pedidos.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Servico_X_Pedidos.Banco_Dados = banco;
                string retorno = qtb_Servico_X_Pedidos.Delerar_Servico_X_Pedido(val);
                if (st_transacao)
                    qtb_Servico_X_Pedidos.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Servico_X_Pedidos.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_Servico_X_Pedidos.deletarBanco_Dados();
            }
        }

     
    }
}
