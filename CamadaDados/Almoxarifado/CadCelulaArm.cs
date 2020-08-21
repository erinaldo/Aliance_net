using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Almoxarifado
{
    public class TList_CadCelulaArm : List<TRegistro_CadCelulaArm>, IComparer<TRegistro_CadCelulaArm>
    {
        #region IComparer<TRegistro_CadCelulaArm> Members
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

        public TList_CadCelulaArm()
        { }

        public TList_CadCelulaArm(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCelulaArm value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCelulaArm x, TRegistro_CadCelulaArm y)
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

    
    public class TRegistro_CadCelulaArm
    {
        private decimal? id_rua;
        
        public decimal? Id_rua
        {
            get { return id_rua; }
            set
            {
                id_rua = value;
                id_ruastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ruastr;
        
        public string Id_ruastr
        {
            get { return id_ruastr; }
            set
            {
                id_ruastr = value;
                try
                {
                    id_rua = decimal.Parse(value);
                }
                catch
                { id_rua = null; }
            }
        }
        
        public string Ds_rua
        { get; set; }
        private decimal? id_secao;
        
        public decimal? Id_secao
        {
            get { return id_secao; }
            set
            {
                id_secao = value;
                id_secaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_secaostr;
        
        public string Id_secaostr
        {
            get { return id_secaostr; }
            set
            {
                id_secaostr = value;
                try
                {
                    id_secao = decimal.Parse(value);
                }
                catch
                { id_secao = null; }
            }
        }
        
        public string Ds_secao
        { get; set; }
        private decimal? id_celula;
        
        public decimal? Id_celula
        {
            get { return id_celula; }
            set
            {
                id_celula = value;
                id_celulastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_celulastr;
        
        public string Id_celulastr
        {
            get { return id_celulastr; }
            set
            {
                id_celulastr = value;
                try
                {
                    id_celula = decimal.Parse(value);
                }
                catch
                { id_celula = null; }
            }
        }
        
        public string Ds_celula
        { get; set; }

        public TRegistro_CadCelulaArm()
        {
            id_rua = null;
            id_ruastr = string.Empty;
            Ds_rua = string.Empty;
            id_secao = null;
            id_secaostr = string.Empty;
            Ds_secao = string.Empty;
            id_celula = null;
            id_celulastr = string.Empty;
            Ds_celula = string.Empty;
        }
    }

    public class TCD_CadCelulaArm : TDataQuery
    {
        public TCD_CadCelulaArm()
        { }

        public TCD_CadCelulaArm(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine(" Select " + strTop + " a.Id_Rua, b.DS_Rua, ");
                sql.AppendLine("a.Id_Secao, c.DS_Secao, a.Id_Celula, a.DS_Celula ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_AMX_CelulaArm a ");
            sql.AppendLine("inner join TB_AMX_Rua b ");
            sql.AppendLine("on a.Id_Rua = b.Id_Rua ");
            sql.AppendLine("inner join TB_AMX_Secao c ");
            sql.AppendLine("on a.Id_Rua = c.Id_Rua ");
            sql.AppendLine("and a.Id_Secao = c.Id_Secao ");

            string cond = "where";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ") ");
                    cond = "and";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadCelulaArm Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadCelulaArm lista = new TList_CadCelulaArm();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadCelulaArm reg = new TRegistro_CadCelulaArm();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Rua"))))
                        reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("Id_Rua"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Secao"))))
                        reg.Id_secao = reader.GetDecimal(reader.GetOrdinal("Id_Secao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Secao"))))
                        reg.Ds_secao = reader.GetString(reader.GetOrdinal("DS_Secao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_Rua"))))
                        reg.Ds_rua = reader.GetString(reader.GetOrdinal("Ds_Rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_celula")))
                        reg.Id_celula = reader.GetDecimal(reader.GetOrdinal("id_celula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_celula")))
                        reg.Ds_celula = reader.GetString(reader.GetOrdinal("ds_celula"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadCelulaArm val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CELULA", val.Id_celula);
            hs.Add("@P_ID_SECAO", val.Id_secao);
            hs.Add("@P_ID_RUA", val.Id_rua);
            hs.Add("@P_DS_CELULA", val.Ds_celula);

            return executarProc("IA_AMX_CELULAARM", hs);
        }

        public string Excluir(TRegistro_CadCelulaArm val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CELULA", val.Id_celula);
            hs.Add("@P_ID_SECAO", val.Id_secao);
            hs.Add("@P_ID_RUA", val.Id_rua);

            return executarProc("EXCLUI_AMX_CELULAARM", hs);
        }
    }
}
