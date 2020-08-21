using CamadaDados.Empreendimento.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_CadEncargosFolha
    {
        public static TList_CadEncargosFolha Buscar(string Id_encargo,
                                                    string Ds_encargo,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(Id_encargo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_encargo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_encargo;
            }
            if(!string.IsNullOrEmpty(Ds_encargo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_encargo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_encargo.Trim() + "%'";
            }
            return new TCD_CadEncargosFolha(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadEncargosFolha val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEncargosFolha qtb_cad = new TCD_CadEncargosFolha();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                val.Id_encargostr = CamadaDados.TDataQuery.getPubVariavel(qtb_cad.Gravar(val), "@P_ID_ENCARGO");
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.Id_encargostr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar encargo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_CadEncargosFolha val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEncargosFolha qtb_cad = new TCD_CadEncargosFolha();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                qtb_cad.Excluir(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.Id_encargostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir encargo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
    }
}
