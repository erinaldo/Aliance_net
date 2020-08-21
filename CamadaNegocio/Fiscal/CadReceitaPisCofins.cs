using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_ReceitaPisCofins
    {
        public static TList_ReceitaPisCofins Buscar(string Id_receita,
                                                    string Ds_receita,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_receita";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_receita;
            }
            if (!string.IsNullOrEmpty(Ds_receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_receita";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_receita.Trim() + "%'";
            }
            return new TCD_ReceitaPisCofins(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ReceitaPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReceitaPisCofins qtb_rec = new TCD_ReceitaPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_rec.CriarBanco_Dados(true);
                else qtb_rec.Banco_Dados = banco;
                val.Id_receitastr = CamadaDados.TDataQuery.getPubVariavel(qtb_rec.Gravar(val), "@P_ID_RECEITA");
                if (st_transacao)
                    qtb_rec.Banco_Dados.Commit_Tran();
                return val.Id_receitastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rec.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rec.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ReceitaPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ReceitaPisCofins qtb_rec = new TCD_ReceitaPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_rec.CriarBanco_Dados(true);
                else qtb_rec.Banco_Dados = banco;
                qtb_rec.Excluir(val);
                if (st_transacao)
                    qtb_rec.Banco_Dados.Commit_Tran();
                return val.Id_receitastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_rec.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_rec.deletarBanco_Dados();
            }
        }
    }
}
