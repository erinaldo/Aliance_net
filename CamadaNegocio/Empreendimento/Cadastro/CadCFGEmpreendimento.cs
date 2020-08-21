using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Empreendimento.Cadastro;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_CadCFGEmpreendimento
    {
        public static TList_CadCFGEmpreendimento Busca(string cd_empresa,
                                                       string cfg_remessa,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(cfg_remessa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cfg_remessa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cfg_remessa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }


            return new TCD_CadCFGEmpreendimento(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_CadCFGEmpreendimento val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadCFGEmpreendimento cd = new TCD_CadCFGEmpreendimento();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.cfg_remessa.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cfg: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        public static void Excluir(TRegistro_CadCFGEmpreendimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFGEmpreendimento cd = new TCD_CadCFGEmpreendimento();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cfg: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
