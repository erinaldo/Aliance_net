using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadTipoServico
    {
        public static TList_CadTipoServico Busca(string vID_TipoServico, 
                                                 string vDS_TipoServico, 
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vID_TipoServico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_TpServico";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_TipoServico;
            }
            if (!string.IsNullOrEmpty(vDS_TipoServico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_tpservico";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_TipoServico.Trim() + "%')";
            }
            return new TCD_CadTipoServico(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadTipoServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTipoServico cd = new TCD_CadTipoServico();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Id_tpservico = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_TPSERVICO");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_tpservico;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo servico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadTipoServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTipoServico cd = new TCD_CadTipoServico();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_tpservico;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tipo servico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
