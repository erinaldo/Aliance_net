using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using Utils;

namespace CamadaNegocio.Diversos
{
    #region Tabela
    public class TCN_CadTabela
    {
        public static TList_Tabelasbd Busca(string nome_tabela, string trigger, bool st_triggers,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(nome_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.name";
                vBusca[vBusca.Length - 1].vOperador = "LIKE";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + nome_tabela.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(trigger))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "TRIG.name";
                vBusca[vBusca.Length - 1].vOperador = "LIKE";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + trigger.Trim() + "%'";
            } 
            if (st_triggers)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "exists ";
                vBusca[vBusca.Length - 1].vVL_Busca = "( select 1 from [sys].[triggers] as x  where x.parent_id = a.object_id   )";
            }
            

            return new TCD_Tabelas(banco).Select(vBusca, 0, string.Empty, string.Empty);

        }

       
    }
    #endregion

    #region Colunas
    public class TCN_Colunas
    {
        public static TList_Colunasbd Busca(string nome_coluna, string nome_tabela,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(nome_coluna))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "COLUMN_NAME";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nome_coluna.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nome_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "TABLE_NAME ";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nome_tabela.Trim() + "'";
            }

            return new TCD_Columnsbd(banco).Select(vBusca, 0, string.Empty, string.Empty);

        }

    }
    #endregion

    #region Triggers

    public class TCN_Triggers
    {
        public static TList_Triggers Busca(string Trigger_Name, string nome_tabela,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(Trigger_Name))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "TRIG.name";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Trigger_Name.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nome_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "TAB.name";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nome_tabela.Trim() + "'";
            }

            return new TCD_Triggers(banco).Select(vBusca, 0, string.Empty, string.Empty);

        }
      

    }
    #endregion


    #region dscolunas
    public class TCN_Coluna
    {
        public static TList_Colunas Busca(string id_coluna,
                                             string nm_tabela,
                                             string nm_coluna,
                                             string ds_coluna,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_coluna))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_coluna";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_coluna.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(nm_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nm_tabela";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + nm_tabela.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(nm_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nm_coluna";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + nm_coluna.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(ds_coluna))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_coluna";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + ds_coluna.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            return new TCD_Colunas(banco).Select(vBusca, 0,string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Colunas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Colunas qtb_emp = new TCD_Colunas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                string retorno = qtb_emp.Gravar(val);
                

                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar colunas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Colunas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Colunas qtb_emp = new TCD_Colunas();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
               

                try
                {
                    qtb_emp.Excluir(val);
                }
                catch
                {
                    //Exclusao logica
                    //val.St_registro = "C";
                    qtb_emp.Gravar(val);
                }
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir colunas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
