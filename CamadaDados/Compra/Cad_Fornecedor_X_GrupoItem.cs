using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Compra
{
    public class TList_Cad_Fornecedor_X_GrupoItem : List<TRegistro_Cad_Fornecedor_X_GrupoItem> { }

    
    public class TRegistro_Cad_Fornecedor_X_GrupoItem
    {
        
        public string CD_Clifor { get; set; }
        
        public string NM_Clifor { get; set; }
        
        public string CD_Grupo { get; set; }
        
        public string DS_Grupo{ get; set; }
        
        public bool St_utilizar
        { get; set; }

        public TRegistro_Cad_Fornecedor_X_GrupoItem()
        {
            this.CD_Clifor = string.Empty;
            this.NM_Clifor = string.Empty;
            this.CD_Grupo = string.Empty;
            this.DS_Grupo = string.Empty;
            this.St_utilizar = false;
        }
    }

    public class TCD_Cad_Fornecedor_X_GrupoItem : TDataQuery
    {
        public TCD_Cad_Fornecedor_X_GrupoItem()
        { }

        public TCD_Cad_Fornecedor_X_GrupoItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.CD_Clifor, a.CD_Grupo, b.NM_Clifor, c.DS_Grupo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CMP_Fornec_X_GrupoItem a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on b.cd_clifor = a.cd_clifor ");
            sql.AppendLine("inner join TB_EST_GRUPOProduto c ");
            sql.AppendLine("on c.cd_grupo = a.cd_grupo ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca);
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_Fornecedor_X_GrupoItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Fornecedor_X_GrupoItem lista = new TList_Cad_Fornecedor_X_GrupoItem();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_Fornecedor_X_GrupoItem reg = new TRegistro_Cad_Fornecedor_X_GrupoItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Grupo")))
                        reg.CD_Grupo = reader.GetString(reader.GetOrdinal("CD_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.DS_Grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_Cad_Fornecedor_X_GrupoItem val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.CD_Clifor);
            hs.Add("@P_CD_GRUPO", val.CD_Grupo);
            return executarProc("IA_CMP_FORNEC_X_GRUPOITEM", hs);
        }

        public string Deleta(TRegistro_Cad_Fornecedor_X_GrupoItem val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.CD_Clifor);
            hs.Add("@P_CD_GRUPO", val.CD_Grupo);
            return executarProc("EXCLUIR_CMP_FORNEC_X_GRUPOITEM", hs);
        }
    }
}
