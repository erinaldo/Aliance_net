using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using CamadaDados;
using Utils;

namespace CamadaDados.Diversos
{
    
    public class TList_CadRegiaoVenda : List<TRegistro_CadRegiaoVenda>, IComparer<TRegistro_CadRegiaoVenda>
    {
        #region IComparer<TRegistro_CadRegiaoVenda> Members
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

        public TList_CadRegiaoVenda()
        { }

        public TList_CadRegiaoVenda(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadRegiaoVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadRegiaoVenda x, TRegistro_CadRegiaoVenda y)
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
    
    public class TRegistro_CadRegiaoVenda
    {
        private decimal? id_regiao;
        public decimal? Id_Regiao
        {
            get { return id_regiao; }
            set
            {
               id_regiao = value;
               id_regiaostr = value.ToString();
            }
        }
        private string id_regiaostr;
        public string ID_RegiaoString
        {
            get { return id_regiaostr; }
            set {
                id_regiaostr = value;
                try 
                { 
                    id_regiao = decimal.Parse(value); 
                }
                catch { id_regiao = null; }
            }
        }
        public string NM_Regiao  {get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadRegiaoVenda()
        {
            this.id_regiao = null;
            this.id_regiaostr = string.Empty;
            this.NM_Regiao = string.Empty;
            this.St_processar = false;
        }
    }
    
    public class TCD_CadRegiaoVenda : TDataQuery
        {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = string.Empty;
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (string.IsNullOrEmpty(vNM_Campo))
                    sql.AppendLine(" SELECT " + strTop + "a.ID_Regiao, a.NM_Regiao ");
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine(" FROM tb_div_regiaovenda a ");

                string cond = " where ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
                sql.Append("Order by a.NM_Regiao asc");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public TList_CadRegiaoVenda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_CadRegiaoVenda lista = new TList_CadRegiaoVenda();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                    podeFecharBco = this.CriarBanco_Dados(false);

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    while (reader.Read())
                    {
                        TRegistro_CadRegiaoVenda reg = new TRegistro_CadRegiaoVenda();
                        if (!reader.IsDBNull(reader.GetOrdinal("Id_Regiao")))
                            reg.Id_Regiao = reader.GetDecimal(reader.GetOrdinal("Id_Regiao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NM_Regiao")))
                            reg.NM_Regiao = reader.GetString(reader.GetOrdinal("NM_Regiao"));
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

            public string Grava(TRegistro_CadRegiaoVenda vRegistro)
            {
                Hashtable hs = new Hashtable();
                hs.Add("@P_ID_REGIAO", vRegistro.Id_Regiao);
                hs.Add("@P_NM_REGIAO", vRegistro.NM_Regiao);
                return executarProc("IA_DIV_REGIAOVENDA", hs);
            }

            public void Deleta(TRegistro_CadRegiaoVenda vRegistro)
            {
                Hashtable hs = new Hashtable();
                hs.Add("@P_ID_REGIAO", vRegistro.Id_Regiao);
                executarProc("EXCLUI_DIV_REGIAOVENDA", hs);
            }
        }
    
}
