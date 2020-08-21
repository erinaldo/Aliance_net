using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca.Cadastros;

namespace CamadaNegocio.Mudanca.Cadastros
{
    public class TCN_CadServico
    {
        public static TList_CadServico Buscar(string Id_servico,
                                           string Ds_servico,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_servico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_servico;
            }
            if (!string.IsNullOrEmpty(Ds_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ds_servico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_servico.Trim() + "%'";
            }
            return new TCD_CadServico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadServico qtb_servico = new TCD_CadServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                val.Id_servicostr = CamadaDados.TDataQuery.getPubVariavel(qtb_servico.Gravar(val), "@P_ID_SERVICO");
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return val.Id_servicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadServico qtb_servico = new TCD_CadServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                qtb_servico.Excluir(val);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return val.Id_servicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }
    }
}
