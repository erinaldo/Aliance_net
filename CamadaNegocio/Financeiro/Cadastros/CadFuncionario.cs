using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadMotorista
    {
        public static TList_CadMotorista Buscar(string Cd_motorista,
                                             string Id_veiculo,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_motorista";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_veiculo;
            }

            return new TCD_CadMotorista(banco).Select(vBusca, 0, string.Empty);
        }

        public static string GravarMotorista(TRegistro_CadMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMotorista qtb_motorista = new TCD_CadMotorista();
            try
            {
                if (banco == null)
                {
                    qtb_motorista.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_motorista.Banco_Dados = banco;
                string retorno = qtb_motorista.Gravar(val);
                if (st_transacao)
                    qtb_motorista.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_motorista.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar motorista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_motorista.deletarBanco_Dados();
            }
        }

        public static string DeletarMotorista(TRegistro_CadMotorista val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMotorista qtb_motorista = new TCD_CadMotorista();
            try
            {
                if (banco == null)
                {
                    qtb_motorista.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_motorista.Banco_Dados = banco;
                qtb_motorista.Excluir(val);
                if (st_transacao)
                    qtb_motorista.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_motorista.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir motorista: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_motorista.deletarBanco_Dados();
            }
        }
    }
}
