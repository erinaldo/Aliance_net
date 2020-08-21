using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadUnidade : List<TRegistro_CadUnidade>, IComparer<TRegistro_CadUnidade>
    {
        #region IComparer<TRegistro_CadUnidade> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadUnidade()
        { }

        public TList_CadUnidade(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadUnidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadUnidade x, TRegistro_CadUnidade y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }

        #endregion
    }
    public class TRegistro_CadUnidade
    {
        public string CD_Unidade { get;set; }
        public string DS_Unidade { get; set;}
        public string Sigla_Unidade{ get; set;}
        public string St_Registro{get; set; }
        public decimal CasasDecimais { get; set; }
        private string tp_tipo;
        public string Tp_tipo
        {
            get { return tp_tipo; }
            set
            {
                tp_tipo = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_tipo = "METRO QUADRADO";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_tipo = "METRO CUBICO";
            }
        }
        private string tipo_tipo;
        public string Tipo_tipo
        {
            get { return tipo_tipo; }
            set
            {
                tipo_tipo = value;
                if (value.Trim().ToUpper().Equals("METRO QUADRADO"))
                    tp_tipo = "0";
                else if (value.Trim().ToUpper().Equals("METRO CUBICO"))
                    tp_tipo = "1";
            }
        }
        public TRegistro_CadUnidade()
        {
            CD_Unidade = string.Empty;
            DS_Unidade = string.Empty;
            Sigla_Unidade = string.Empty;
            St_Registro = string.Empty;
            CasasDecimais = decimal.Zero;
            tipo_tipo = string.Empty;
            tp_tipo = string.Empty;
        }

    }

     public class TCD_CadUnidade : TDataQuery
     {
        public TCD_CadUnidade() { }
        public TCD_CadUnidade(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
         private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
         {
             string strTop = string.Empty;
             if (vTop > 0)
                 strTop = "TOP " + Convert.ToString(vTop);
             StringBuilder sql = new StringBuilder();

             if (string.IsNullOrEmpty(vNM_Campo))
                 sql.AppendLine(" SELECT " + strTop + " a.tp_unidade, a.cd_unidade, a.ds_unidade, a.sigla_unidade,a.CasasDecimais, a.st_registro ");
             else
                 sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

             sql.AppendLine(" FROM tb_est_unidade a ");


             string cond = " where ";
             if (vBusca != null)
                 for (int i = 0; i < (vBusca.Length); i++)
                 {
                     sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                     cond = " and ";
                 }
             sql.Append("Order by a.ds_unidade asc");
             return sql.ToString();
         }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.tp_unidade, a.cd_unidade, a.ds_unidade, a.sigla_unidade,a.CasasDecimais, a.st_registro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_est_unidade a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (string.IsNullOrEmpty(vOrderBy))
                vOrderBy = "a.ds_unidade asc";

            sql.Append("Order by "+vOrderBy+" desc");
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
         {
               return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
         }

         public TList_CadUnidade Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
         {
             TList_CadUnidade lista = new TList_CadUnidade();
             SqlDataReader reader = null;
             bool podeFecharBco = false;
             if (Banco_Dados == null)
                 podeFecharBco = CriarBanco_Dados(false);

             try
             {
                 reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                 while (reader.Read())
                 {
                     TRegistro_CadUnidade reg = new TRegistro_CadUnidade();
                     if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                         reg.CD_Unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                         reg.DS_Unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                         reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                         reg.St_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_unidade")))
                        reg.Tp_tipo = reader.GetString(reader.GetOrdinal("tp_unidade")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("CasasDecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("CasasDecimais")); 
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


        public TList_CadUnidade Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            TList_CadUnidade lista = new TList_CadUnidade();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
                while (reader.Read())
                {
                    TRegistro_CadUnidade reg = new TRegistro_CadUnidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.CD_Unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.DS_Unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_unidade")))
                        reg.Tp_tipo = reader.GetString(reader.GetOrdinal("tp_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CasasDecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("CasasDecimais"));
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
        public string Grava(TRegistro_CadUnidade vRegistro)
         {
             Hashtable hs = new Hashtable(6);
             hs.Add("@P_CD_UNIDADE", vRegistro.CD_Unidade);
             hs.Add("@P_DS_UNIDADE", vRegistro.DS_Unidade);
             hs.Add("@P_SIGLA_UNIDADE", vRegistro.Sigla_Unidade);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_Registro);
            hs.Add("@P_TP_UNIDADE", vRegistro.Tp_tipo); 
            hs.Add("@P_CASASDECIMAIS", vRegistro.CasasDecimais); 
            return this.executarProc("IA_EST_UNIDADE", hs); 
         }

         public string Deleta(TRegistro_CadUnidade vRegistro)
         {
             Hashtable hs = new Hashtable(1);
             hs.Add("@P_CD_UNIDADE", vRegistro.CD_Unidade);
             return this.executarProc("EXCLUI_EST_UNIDADE", hs);
         }

     }
}
