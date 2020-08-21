using CamadaDados.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadMaquinaCartao
    {
        public static TList_CadMaquinaCartao Buscar(string ID_Maquina,
                                                      string DS_Maquina,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(ID_Maquina))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Maquina";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Maquina;
            }
            if (!string.IsNullOrEmpty(DS_Maquina))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Maquina";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + DS_Maquina.Trim() + "%')";
            }
            return new TCD_CadMaquinaCartao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadMaquinaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMaquinaCartao qtb_maquina = new TCD_CadMaquinaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_maquina.CriarBanco_Dados(true);
                else
                    qtb_maquina.Banco_Dados = banco;
                val.Id_maquinastr = CamadaDados.TDataQuery.getPubVariavel(qtb_maquina.Gravar(val), "@P_ID_MAQUINA");
                if (st_transacao)
                    qtb_maquina.Banco_Dados.Commit_Tran();
                return val.Id_maquinastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_maquina.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_maquina.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_CadMaquinaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMaquinaCartao qtb_maquina = new TCD_CadMaquinaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_maquina.CriarBanco_Dados(true);
                else
                    qtb_maquina.Banco_Dados = banco;
                qtb_maquina.Excluir(val);
                if (st_transacao)
                    qtb_maquina.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_maquina.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_maquina.deletarBanco_Dados();
            }
        }
    }
}
