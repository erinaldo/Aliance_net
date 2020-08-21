using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_CadMarcaVeiculo
    {
        public static TList_CadMarcaVeiculo Buscar(string Id_marca,
                                             string Ds_marca,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_marca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_marca;
            }
            if (!string.IsNullOrEmpty(Ds_marca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Ds_marca.Trim() + "'";
            }

            return new TCD_CadMarcaVeiculo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string GravarMarca(TRegistro_CadMarcaVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMarcaVeiculo qtb_marca = new TCD_CadMarcaVeiculo();
            try
            {
                if (banco == null)
                {
                    qtb_marca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_marca.Banco_Dados = banco;
                //Gravar  Marca Veiculo
                string retorno = qtb_marca.Gravar(val);
                if (st_transacao)
                    qtb_marca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_marca.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_marca.deletarBanco_Dados();
            }
        }

        public static string DeletarMarca(TRegistro_CadMarcaVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMarcaVeiculo qtb_marca = new TCD_CadMarcaVeiculo();
            try
            {
                if (banco == null)
                {
                    qtb_marca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_marca.Banco_Dados = banco;
                //Deletar Marca Veiculo
                qtb_marca.Excluir(val);
                if (st_transacao)
                    qtb_marca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_marca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir marca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_marca.deletarBanco_Dados();
            }
        }
    }
}
