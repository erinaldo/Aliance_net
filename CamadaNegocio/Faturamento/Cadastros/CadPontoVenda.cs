using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_PontoVenda
    {
        public static TList_PontoVenda Buscar(string Id_pdv,
                                              string Ds_pdv,
                                              string Cd_terminal,
                                              string Cd_empresa,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(Ds_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_pdv";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_pdv.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_terminal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_terminal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_terminal.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            
            return new TCD_PontoVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PontoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PontoVenda qtb_pdv = new TCD_PontoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pdv.CriarBanco_Dados(true);
                else
                    qtb_pdv.Banco_Dados = banco;
                val.Id_pdvstr = CamadaDados.TDataQuery.getPubVariavel(qtb_pdv.Gravar(val), "@P_ID_PDV");
                if (st_transacao)
                    qtb_pdv.Banco_Dados.Commit_Tran();
                return val.Id_pdvstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pdv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar PDV: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pdv.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PontoVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PontoVenda qtb_pdv = new TCD_PontoVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pdv.CriarBanco_Dados(true);
                else
                    qtb_pdv.Banco_Dados = banco;
                qtb_pdv.Excluir(val);
                if (st_transacao)
                    qtb_pdv.Banco_Dados.Commit_Tran();
                return val.Id_pdvstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pdv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir PDV: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pdv.deletarBanco_Dados();
            }
        }
    }
}
