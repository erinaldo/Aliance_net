using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Almoxarifado
{
    public class TRegistro_CadItens
    {
        
        public string Cd_produto 
        { get; set; }
        
        public string Ds_Produto 
        { get; set; }
        private decimal? id_almox;
        
        public decimal? Id_almox
        {
            get { return id_almox; }
            set 
            { 
                id_almox = value;
                id_almoxString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_almoxString;
        
        public string Id_almoxString
        {
            get { return id_almoxString; }
            set 
            { 
                id_almoxString = value;
                try { id_almox = decimal.Parse(value); }
                catch { id_almox = null; }
            }
        }
        private decimal? id_rua;
        
        public decimal? Id_rua
        {
            get { return id_rua; }
            set 
            { 
                id_rua = value;
                id_ruaString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ruaString;
        
        public string Id_ruaString
        {
            get { return id_ruaString; }
            set 
            { 
                id_ruaString = value;
                try { id_rua = decimal.Parse(value); }
                catch { id_rua = null; }
            }
        }
        private decimal? id_secao;
        
        public decimal? Id_secao
        {
            get { return id_secao; }
            set 
            { 
                id_secao = value;
                id_secaoString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_secaoString;
        
        public string Id_secaoString
        {
            get { return id_secaoString; }
            set 
            { 
                id_secaoString = value;
                try { id_secao = decimal.Parse(value); }
                catch { id_secao = null; }
            }
        }
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
                try { id_celula = decimal.Parse(value); }
                catch { id_celula = null; }
            }
        }
        
        public string Ds_almox 
        { get; set; }
        
        public string Ds_rua 
        { get; set; }
        
        public string Ds_secao 
        { get; set; }
        
        public string Ds_celula 
        { get; set; }

        public TRegistro_CadItens()
        {
            Cd_produto = string.Empty;
            Ds_Produto = string.Empty;
            id_almox = null;
            id_almoxString = string.Empty;
            id_celula = null;
            id_celulastr = string.Empty;
            id_rua = null;
            id_ruaString = string.Empty;
            id_secao = null;
            id_secaoString = string.Empty;
            Ds_almox = string.Empty;
            Ds_celula = string.Empty;
            Ds_rua = string.Empty;
            Ds_secao = string.Empty;
        }
    }

    public class TList_CadItens : List<TRegistro_CadItens>, IComparer<TRegistro_CadItens>
    {
        #region IComparer<TRegistro_CadItens> Members
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

        public TList_CadItens()
        { }

        public TList_CadItens(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadItens x, TRegistro_CadItens y)
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

    public class TCD_CadItens : TDataQuery
    {
        public TCD_CadItens()
        { }

        public TCD_CadItens(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_produto,f.ds_produto, ");
                sql.AppendLine("a.id_almox, a.id_rua, a.id_secao, a.id_celula, ");
                sql.AppendLine("b.ds_almoxarifado, e.ds_celula, d.ds_secao, c.ds_rua");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_AMX_ITENS a ");
            sql.AppendLine("inner join TB_AMX_ALMOXARIFADO b");
            sql.AppendLine("on b.id_almox = a.id_almox");
            sql.AppendLine("left outer join TB_AMX_RUA c");
            sql.AppendLine("on c.id_rua = a.id_rua");
            sql.AppendLine("left outer join TB_AMX_SECAO d");
            sql.AppendLine("on d.id_secao = a.id_secao ");
            sql.AppendLine("and d.id_rua = a.id_rua");
            sql.AppendLine("left outer join TB_AMX_CELULAARM e ");
            sql.AppendLine("on e.id_celula = a.id_celula ");
            sql.AppendLine("and e.id_rua = a.id_rua ");
            sql.AppendLine("and e.id_secao = d.id_secao");
            sql.AppendLine("inner join tb_est_produto f ");
            sql.AppendLine("on a.cd_produto = f.cd_produto");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = "and";
                }
            return sql.ToString();
        }

        public TList_CadItens Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadItens lista = new TList_CadItens();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadItens reg = new TRegistro_CadItens();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Almox"))))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_Almox"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Rua"))))
                        reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("Id_Rua"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Secao"))))
                        reg.Id_secao = reader.GetDecimal(reader.GetOrdinal("Id_Secao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_celula"))))
                        reg.Id_celula = reader.GetDecimal(reader.GetOrdinal("id_celula"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_almoxarifado"))))
                        reg.Ds_almox = reader.GetString(reader.GetOrdinal("ds_almoxarifado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_celula"))))
                        reg.Ds_celula = reader.GetString(reader.GetOrdinal("ds_celula"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_secao"))))
                        reg.Ds_secao = reader.GetString(reader.GetOrdinal("ds_secao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_rua"))))
                        reg.Ds_rua = reader.GetString(reader.GetOrdinal("ds_rua"));

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

        public string gravarItens(TRegistro_CadItens val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ALMOX", val.Id_almox);
            hs.Add("@P_ID_RUA", val.Id_rua);
            hs.Add("@P_ID_SECAO", val.Id_secao);
            hs.Add("@P_ID_CELULA", val.Id_celula);
            
            return executarProc("IA_AMX_ITENS", hs);
        }

        public string deletarItens(TRegistro_CadItens val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ALMOX", val.Id_almox);

            return executarProc("EXCLUI_AMX_ITENS", hs);
        }
    }
}
