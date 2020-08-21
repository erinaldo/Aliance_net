using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CamadaDados.Estoque.Cadastros;


namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadTpProduto_X_Clifor : List<TRegistro_CadTpProduto_X_Clifor>
    {
    }
    
    public class TRegistro_CadTpProduto_X_Clifor
    {
        
        public string CD_Clifor
        {
            get;
            set;
        }
        
        public string Tp_Produto
        {
            get;
            set;
        }
        
        public string NM_Clifor
        {
            get;
            set;
        }
        
        public string DS_TpProduto
        {
            get;
            set;
        }
        
        public TRegistro_CadTpProduto_X_Clifor()
        {
            this.CD_Clifor = string.Empty;
            this.Tp_Produto = string.Empty;
            this.NM_Clifor = string.Empty;
            this.DS_TpProduto = string.Empty;
        }
    }

    public class TCD_CadTpProduto_X_Clifor : TDataQuery
    {
        public TCD_CadTpProduto_X_Clifor()
        { }

        public TCD_CadTpProduto_X_Clifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_clifor, b.nm_clifor, a.tp_produto, c.ds_tpproduto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_TipoProduto_X_Clifor a ");
            sql.AppendLine(" INNER JOIN TB_FIN_Clifor b ON (a.cd_clifor = b.cd_clifor) ");
            sql.AppendLine(" INNER JOIN TB_EST_TpProduto c ON (a.tp_produto = c.tp_produto) ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.Append(" ORDER BY b.nm_clifor ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadTpProduto_X_Clifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTpProduto_X_Clifor lista = new TList_CadTpProduto_X_Clifor();
            SqlDataReader reader = null;

            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                //ABRE A CONEXAO COM O BD
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                //EXECUTA A BUSCA DO DB E CARREGA A LISTA COM OS REGISTROS
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTpProduto_X_Clifor reg = new TRegistro_CadTpProduto_X_Clifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_produto")))
                        reg.Tp_Produto = reader.GetString(reader.GetOrdinal("tp_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpproduto")))
                        reg.DS_TpProduto = reader.GetString(reader.GetOrdinal("ds_tpproduto"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                //FECHA A CONEXAO COM O BD
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_CadTpProduto_X_Clifor vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_TP_PRODUTO", vRegistro.Tp_Produto);
            //COLOCA O TIPO DE OPERAÇÃO NO LUGAR Do TB
            return this.executarProc("IA_EST_TIPOPRODUTO_X_CLIFOR", hs);
        }

        public string Deleta(TRegistro_CadTpProduto_X_Clifor vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_TP_PRODUTO", vRegistro.Tp_Produto);
            //COLOCA O TIPO DE OPERAÇÃO NO LUGAR Do TB
            return this.executarProc("EXCLUI_EST_TPPRODUTO_X_CLIFOR", hs);
        }
    }


}
