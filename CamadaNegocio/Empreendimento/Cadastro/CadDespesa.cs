using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento.Cadastro;
using BancoDados;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_CadDespesa
    {
        public static TList_CadDespesa Busca(string iddespesa,
                                             string DSdespesa,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(iddespesa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_despesa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + iddespesa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(DSdespesa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_despesa";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DSdespesa.Trim() + "%')";
            }
            

            return new TCD_CadDespesa(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_CadDespesa val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadDespesa cd = new TCD_CadDespesa();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                //Buscar ultimo numero da ordem
                val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_DESPESA");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar etapa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        public static void Excluir(TRegistro_CadDespesa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDespesa cd = new TCD_CadDespesa();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
               // val.lprocesso.ForEach(p => TCN_CadProcessoEtapa.Excluir(p, cd.Banco_Dados));
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
