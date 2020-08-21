using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Talhoes : List<TRegistro_Talhoes>, IComparer<TRegistro_Talhoes>
    {
        #region IComparer<TRegistro_Talhoes> Members
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

        public TList_Talhoes()
        { }

        public TList_Talhoes(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Talhoes value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Talhoes x, TRegistro_Talhoes y)
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

    
    public class TRegistro_Talhoes
    {
        private decimal? id_talhao;
        
        public decimal? Id_talhao
        {
            get { return id_talhao; }
            set
            {
                id_talhao = value;
                id_talhaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_talhaostr;
        
        public string Id_talhaostr
        {
            get { return id_talhaostr; }
            set
            {
                id_talhaostr = value;
                try
                {
                    id_talhao = decimal.Parse(value);
                }
                catch
                { id_talhao = null; }
            }
        }
        private decimal? id_area;
        
        public decimal? Id_area
        {
            get { return id_area; }
            set
            {
                id_area = value;
                id_areastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_areastr;
        
        public string Id_areastr
        {
            get { return id_areastr; }
            set
            {
                id_areastr = value;
                try
                {
                    id_area = decimal.Parse(value);
                }
                catch
                { id_area = null; }
            }
        }
        
        public string Ds_area
        { get; set; }
        
        public string Cd_fazenda
        { get; set; }
        
        public string Nm_fazenda
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Ds_talhao
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public decimal Area_talhao
        { get; set; }
        
        public decimal Area_producao
        { get; set; }
        
        public decimal Area_dividida
        { get; set; }
        public decimal Pc_area_talhao
        {
            get
            {
                if (Area_producao > decimal.Zero)
                    return Area_talhao * 100 / Area_producao;
                else
                    return decimal.Zero;
            }
        }
        private string st_irrigado;
        
        public string St_irrigado
        {
            get { return st_irrigado; }
            set
            {
                st_irrigado = value;
                st_irrigadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_irrigadobool;
        
        public bool St_irrigadobool
        {
            get { return st_irrigadobool; }
            set
            {
                st_irrigadobool = value;
                st_irrigado = value ? "S" : "N";
            }
        }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("I"))
                    status = "INATIVO";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("INATIVO"))
                    st_registro = "I";
            }
        }

        public TRegistro_Talhoes()
        {
            this.id_talhao = null;
            this.id_talhaostr = string.Empty;
            this.id_area = null;
            this.id_areastr = string.Empty;
            this.Ds_area = string.Empty;
            this.Cd_fazenda = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Ds_talhao = string.Empty;
            this.Ds_observacao = string.Empty;
            this.Area_talhao = decimal.Zero;
            this.Area_producao = decimal.Zero;
            this.Area_dividida = decimal.Zero;
            this.st_irrigado = string.Empty;
            this.st_irrigadobool = false;
            this.st_registro = "A";
            this.status = "ATIVO";
        }
    }

    public class TCD_Talhoes : TDataQuery
    {
        public TCD_Talhoes()
        { }

        public TCD_Talhoes(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Talhao, a.ID_Area, c.DS_Area, d.sigla_unidade, ");
                sql.AppendLine("a.CD_Fazenda, b.nm_fazenda, a.DS_Talhao, a.DS_Observacao, ");
                sql.AppendLine("c.area_producao, c.area_dividida, a.area_talhao, a.ST_Irrigado, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Talhoes a");
            sql.AppendLine("inner join VTB_FAZ_Fazenda b ");
            sql.AppendLine("on a.cd_fazenda = b.cd_fazenda ");
            sql.AppendLine("inner join VTB_FAZ_Area c ");
            sql.AppendLine("on a.cd_fazenda = c.cd_fazenda ");
            sql.AppendLine("and a.id_area = c.id_area ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on b.cd_unidade = d.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Talhoes Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Talhoes lista = new TList_Talhoes();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Talhoes reg = new TRegistro_Talhoes();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Area")))
                        reg.Id_area = reader.GetDecimal(reader.GetOrdinal("ID_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("DS_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_talhao")))
                        reg.Id_talhao = reader.GetDecimal(reader.GetOrdinal("id_talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Talhao")))
                        reg.Ds_talhao = reader.GetString(reader.GetOrdinal("DS_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("area_talhao")))
                        reg.Area_talhao = reader.GetDecimal(reader.GetOrdinal("area_talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("area_producao")))
                        reg.Area_producao = reader.GetDecimal(reader.GetOrdinal("area_producao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("area_dividida")))
                        reg.Area_dividida = reader.GetDecimal(reader.GetOrdinal("area_dividida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Irrigado")))
                        reg.St_irrigado = reader.GetString(reader.GetOrdinal("ST_Irrigado"));

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

        public string Gravar(TRegistro_Talhoes val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);
            hs.Add("@P_DS_TALHAO", val.Ds_talhao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_AREA_TALHAO", val.Area_talhao);
            hs.Add("@P_ST_IRRIGADO", val.St_irrigado);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAZ_TALHOES", hs);
        }

        public string Excluir(TRegistro_Talhoes val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);

            return this.executarProc("EXCLUI_FAZ_TALHOES", hs);
        }
    }
}
