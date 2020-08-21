using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Area : List<TRegistro_Area>, IComparer<TRegistro_Area>
    {
        #region IComparer<TRegistro_Area> Members
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

        public TList_Area()
        { }

        public TList_Area(System.ComponentModel.PropertyDescriptor Prop,
                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Area value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Area x, TRegistro_Area y)
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

    
    public class TRegistro_Area
    {
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
        
        public string Cd_fazenda
        { get; set; }
        
        public string Nm_fazenda
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Ds_area
        { get; set; }
        
        public decimal Area_preservacao
        { get; set; }
        
        public decimal Area_pastagem
        { get; set; }
        
        public decimal Area_producao
        { get; set; }
        
        public decimal Area_dividida
        { get; set; }
        public decimal Area_total
        { get { return Area_pastagem + Area_preservacao + Area_producao; } }
        
        public string Ds_observacao
        { get; set; }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVA";
                else if (value.Trim().ToUpper().Equals("I"))
                    status = "INATIVA";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "ARRENDADA";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVA"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("INATIVA"))
                    st_registro = "I";
                else if (value.Trim().ToUpper().Equals("ARRENDADA"))
                    st_registro = "R";
            }
        }

        public TRegistro_Area()
        {
            this.id_area = null;
            this.id_areastr = string.Empty;
            this.Cd_fazenda = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Ds_area = string.Empty;
            this.Area_preservacao = decimal.Zero;
            this.Area_pastagem = decimal.Zero;
            this.Area_producao = decimal.Zero;
            this.Area_dividida = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = "ATIVA";
        }
    }

    public class TCD_Area : TDataQuery
    {
        public TCD_Area()
        { }

        public TCD_Area(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Area, a.CD_Fazenda, a.DS_Area, ");
                sql.AppendLine("b.NM_Fazenda, c.sigla_unidade,  a.ST_Registro, ");
                sql.AppendLine("a.Area_Pastagem, a.Area_Preservacao, a.Area_Producao, ");
                sql.AppendLine("a.Area_Dividida, a.DS_Observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from VTB_FAZ_AREA a ");
            sql.AppendLine("inner join VTB_FAZ_Fazenda b ");
            sql.AppendLine("on a.cd_fazenda = b.cd_fazenda ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

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

        public TList_Area Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Area lista = new TList_Area();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Area reg = new TRegistro_Area();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("nm_fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Area")))
                        reg.Id_area = reader.GetDecimal(reader.GetOrdinal("ID_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("DS_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Preservacao")))
                        reg.Area_preservacao = reader.GetDecimal(reader.GetOrdinal("Area_Preservacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Pastagem")))
                        reg.Area_pastagem = reader.GetDecimal(reader.GetOrdinal("Area_Pastagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Producao")))
                        reg.Area_producao = reader.GetDecimal(reader.GetOrdinal("Area_Producao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Dividida")))
                        reg.Area_dividida = reader.GetDecimal(reader.GetOrdinal("Area_Dividida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_Area val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);
            hs.Add("@P_DS_AREA", val.Ds_area);
            hs.Add("@P_AREA_PRESERVACAO", val.Area_preservacao);
            hs.Add("@P_AREA_PASTAGEM", val.Area_pastagem);
            hs.Add("@P_AREA_PRODUCAO", val.Area_producao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAZ_AREA", hs);
        }

        public string Excluir(TRegistro_Area val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);

            return this.executarProc("EXCLUI_FAZ_AREA", hs);
        }
    }
}