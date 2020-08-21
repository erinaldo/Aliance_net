using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_VeiculoCliente
    {
        public static TList_VeiculoCliente Buscar(string Cd_clifor,
                                                  string Placaveiculo,
                                                  string Ds_veiculo,
                                                  string Ds_marca,
                                                  string Ds_observacao,
                                                  string St_registro,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Placaveiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placaveiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placaveiculo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_veiculo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_veiculo.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Ds_marca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_marca";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_marca.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Ds_observacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_observacao.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_VeiculoCliente(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VeiculoCliente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VeiculoCliente qtb_veic = new TCD_VeiculoCliente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veic.CriarBanco_Dados(true);
                else
                    qtb_veic.Banco_Dados = banco;
                string retorno = qtb_veic.Gravar(val);
                if (st_transacao)
                    qtb_veic.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veic.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VeiculoCliente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VeiculoCliente qtb_veic = new TCD_VeiculoCliente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veic.CriarBanco_Dados(true);
                else
                    qtb_veic.Banco_Dados = banco;
                qtb_veic.Excluir(val);
                if (st_transacao)
                    qtb_veic.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veic.deletarBanco_Dados();
            }
        }
    }
}
