using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using CamadaDados.Empreendimento.Cadastro;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_OrcamentoEncargo
    {
        public static TList_OrcamentoEncargo Buscar(string Id_encargo,
                                                    string cd_empresa,
                                                    string nr_versao,
                                                    string id_orcamento,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_encargo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_encargo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_encargo;
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_versao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_orcamento.Trim() + "'";
            }
            return new TCD_OrcamentoEncargo(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_OrcamentoEncargo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrcamentoEncargo qtb_cad = new TCD_OrcamentoEncargo();
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
            catch (Exception ex)
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
        public static void Excluir(TRegistro_OrcamentoEncargo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrcamentoEncargo qtb_cad = new TCD_OrcamentoEncargo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                //verificar os valores
                qtb_cad.Excluir(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
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
