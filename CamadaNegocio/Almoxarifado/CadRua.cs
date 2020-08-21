using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Almoxarifado;
using Utils;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_CadRua
    {
        public static TList_CadRua Busca(string vId_rua, 
                                         string vDs_rua,
                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_rua))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_rua";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_rua;
            }
            if (!string.IsNullOrEmpty(vDs_rua))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_rua";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDs_rua + "%')";
            }

            return new TCD_CadRua(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadRua val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRua qtb_rua = new TCD_CadRua();
            try
            {
                if(banco == null)
                    st_transacao = qtb_rua.CriarBanco_Dados(true);
                else
                    qtb_rua.Banco_Dados = banco;
                val.Id_ruastr = CamadaDados.TDataQuery.getPubVariavel(qtb_rua.Gravar(val), "@P_ID_RUA");
                if(st_transacao)
                    qtb_rua.Banco_Dados.Commit_Tran();
                return val.Id_ruastr;
            }
            catch(Exception ex)
            {
                if(st_transacao)
                    qtb_rua.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar rua: "+ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_rua.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadRua val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadRua qtb_rua = new TCD_CadRua();
            try
            {
                if (banco == null)
                    st_transacao = qtb_rua.CriarBanco_Dados(true);
                else
                    qtb_rua.Banco_Dados = banco;
                qtb_rua.Excluir(val);
                if (st_transacao)
                    qtb_rua.Banco_Dados.Commit_Tran();
                return val.Id_ruastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rua.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir rua: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rua.deletarBanco_Dados();
            }
        }
    }
}
