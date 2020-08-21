using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Fazenda : List<TRegistro_Fazenda>, IComparer<TRegistro_Fazenda>
    {
        #region IComparer<TRegistro_Fazenda> Members
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

        public TList_Fazenda()
        { }

        public TList_Fazenda(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Fazenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Fazenda x, TRegistro_Fazenda y)
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

    
    public class TRegistro_Fazenda
    {
        
        public string Cd_fazenda
        { get; set; }
        
        public string Nm_fazenda
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Nr_incra
        { get; set; }
        
        public string Nr_registro
        { get; set; }
        
        public string Cd_itr
        { get; set; }
        
        public string Nr_matricula
        { get; set; }
        
        public string Cri
        { get; set; }
        
        public string Cei
        { get; set; }
        private DateTime? dt_aquisicao;
        
        public DateTime? Dt_aquisicao
        {
            get { return dt_aquisicao; }
            set
            {
                dt_aquisicao = value;
                dt_aquisicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aquisicaostr;
        public string Dt_aquisicaostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_aquisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aquisicaostr = value;
                try
                {
                    dt_aquisicao = DateTime.Parse(value);
                }
                catch
                { dt_aquisicao = null; }
            }
        }
        
        public decimal Area_preservacao
        { get; set; }
        
        public decimal Area_pastagem
        { get; set; }
        
        public decimal Area_producao
        { get; set; }
        public decimal Area_total
        { get { return Area_pastagem + Area_preservacao + Area_producao; } }

        public TRegistro_Fazenda()
        {
            this.Cd_fazenda = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Nr_incra = string.Empty;
            this.Nr_matricula = string.Empty;
            this.Cri = string.Empty;
            this.Cei = string.Empty;
            this.dt_aquisicao = null;
            this.dt_aquisicaostr = string.Empty;
            this.Area_preservacao = decimal.Zero;
            this.Area_pastagem = decimal.Zero;
            this.Area_producao = decimal.Zero;
        }
    }

    public class TCD_Fazenda : TDataQuery
    {
        public TCD_Fazenda()
        { }

        public TCD_Fazenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Fazenda, a.NM_Fazenda, ");
                sql.AppendLine("a.CD_Unidade, b.DS_Unidade, b.Sigla_Unidade, ");
                sql.AppendLine("a.NR_Incra, a.NR_Registro, a.CD_ITR, a.NR_Matricula, ");
                sql.AppendLine("a.CRI, a.CEI, a.DT_Aquisicao, a.Area_Preservacao, ");
                sql.AppendLine("a.Area_Pastagem, a.Area_Producao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from VTB_FAZ_Fazenda a");
            sql.AppendLine("inner join TB_EST_Unidade b ");
            sql.AppendLine("on a.CD_Unidade = b.CD_Unidade ");

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

        public TList_Fazenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Fazenda lista = new TList_Fazenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Fazenda reg = new TRegistro_Fazenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Incra")))
                        reg.Nr_incra = reader.GetString(reader.GetOrdinal("NR_Incra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Registro")))
                        reg.Nr_registro = reader.GetString(reader.GetOrdinal("NR_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ITR")))
                        reg.Cd_itr = reader.GetString(reader.GetOrdinal("CD_ITR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Matricula")))
                        reg.Nr_matricula = reader.GetString(reader.GetOrdinal("NR_Matricula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CRI")))
                        reg.Cri = reader.GetString(reader.GetOrdinal("CRI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEI")))
                        reg.Cei = reader.GetString(reader.GetOrdinal("CEI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Aquisicao")))
                        reg.Dt_aquisicao = reader.GetDateTime(reader.GetOrdinal("DT_Aquisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Preservacao")))
                        reg.Area_preservacao = reader.GetDecimal(reader.GetOrdinal("Area_Preservacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Pastagem")))
                        reg.Area_pastagem = reader.GetDecimal(reader.GetOrdinal("Area_Pastagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Producao")))
                        reg.Area_producao = reader.GetDecimal(reader.GetOrdinal("Area_Producao"));

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

        public string Gravar(TRegistro_Fazenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_NR_INCRA", val.Nr_incra);
            hs.Add("@P_NR_REGISTRO", val.Nr_registro);
            hs.Add("@P_CD_ITR", val.Cd_itr);
            hs.Add("@P_NR_MATRICULA", val.Nr_matricula);
            hs.Add("@P_CRI", val.Cri);
            hs.Add("@P_CEI", val.Cei);
            hs.Add("@P_DT_AQUISICAO", val.Dt_aquisicao);

            return this.executarProc("IA_FAZ_FAZENDA", hs);
        }

        public string Excluir(TRegistro_Fazenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);

            return this.executarProc("EXCLUI_FAZ_FAZENDA", hs);
        }
    }
}
