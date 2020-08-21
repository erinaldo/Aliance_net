using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Utils;

namespace CamadaDados.Fazenda.Cadastros
{
    #region Plantio
    public class TList_Plantio : List<TRegistro_Plantio>, IComparer<TRegistro_Plantio>
    {
        #region IComparer<TRegistro_Plantio> Members
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

        public TList_Plantio()
        { }

        public TList_Plantio(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Plantio value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Plantio x, TRegistro_Plantio y)
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

    
    public class TRegistro_Plantio
    {
        private decimal? id_plantio;
        
        public decimal? Id_plantio
        {
            get { return id_plantio; }
            set
            {
                id_plantio = value;
                id_plantiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_plantiostr;
        
        public string Id_plantiostr
        {
            get { return id_plantiostr; }
            set
            {
                id_plantiostr = value;
                try
                {
                    id_plantio = decimal.Parse(value);
                }
                catch
                { id_plantio = null; }
            }
        }
        
        public string Anosafra
        { get; set; }
        
        public string Ds_safra
        { get; set; }
        private decimal? id_cultura;
        
        public decimal? Id_cultura
        {
            get { return id_cultura; }
            set
            {
                id_cultura = value;
                id_culturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_culturastr;
        
        public string Id_culturastr
        {
            get { return id_culturastr; }
            set
            {
                id_culturastr = value;
                try
                {
                    id_cultura = decimal.Parse(value);
                }
                catch
                { id_cultura = null; }
            }
        }
        
        public string Ds_cultura
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        private DateTime? dt_iniplantio;
        
        public DateTime? Dt_iniplantio
        {
            get { return dt_iniplantio; }
            set
            {
                dt_iniplantio = value;
                dt_iniplantiostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_iniplantiostr;
        public string Dt_iniplantiostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_iniplantiostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_iniplantiostr = value;
                try
                {
                    dt_iniplantio = DateTime.Parse(value);
                }
                catch
                { dt_iniplantio = null; }
            }
        }
        private DateTime? dt_finplantio;
        
        public DateTime? Dt_finplantio
        {
            get { return dt_finplantio; }
            set
            {
                dt_finplantio = value;
                dt_finplantiostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finplantiostr;
        public string Dt_finplantiostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finplantiostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finplantiostr = value;
                try
                {
                    dt_finplantio = DateTime.Parse(value);
                }
                catch
                { dt_finplantio = null; }
            }
        }
        
        public decimal Qt_sementespormetro
        { get; set; }
        
        public decimal Espacosemente
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public TList_Plantio_X_Talhoes lTalhoesPlantio
        { get; set; }
        
        public TList_Plantio_X_Talhoes lTalhoesPlantioDel
        { get; set; }

        public TRegistro_Plantio()
        {
            this.id_plantio = null;
            this.id_plantiostr = string.Empty;
            this.Anosafra = string.Empty;
            this.Ds_safra = string.Empty;
            this.id_cultura = null;
            this.id_culturastr = string.Empty;
            this.Ds_cultura = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.dt_iniplantio = null;
            this.dt_iniplantiostr = string.Empty;
            this.dt_finplantio = null;
            this.dt_finplantiostr = string.Empty;
            this.Qt_sementespormetro = decimal.Zero;
            this.Espacosemente = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.lTalhoesPlantio = new TList_Plantio_X_Talhoes();
            this.lTalhoesPlantioDel = new TList_Plantio_X_Talhoes();
        }
    }

    public class TCD_Plantio : TDataQuery
    {
        public TCD_Plantio()
        { }

        public TCD_Plantio(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Id_Plantio, a.DS_Observacao, ");
                sql.AppendLine("a.id_cultura, b.ds_cultura, a.AnoSafra, ");
                sql.AppendLine("b.cd_produto, d.ds_produto, e.sigla_unidade, ");
                sql.AppendLine("c.DS_Safra, a.DT_IniPlantio, a.DT_FinPlantio, ");
                sql.AppendLine("a.QT_SementesPorMetro, a.EspacoSemente ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Plantio a ");
            sql.AppendLine("inner join TB_FAZ_Cultura b ");
            sql.AppendLine("on a.id_cultura = b.id_cultura ");
            sql.AppendLine("inner join TB_GRO_Safra c ");
            sql.AppendLine("on a.AnoSafra = c.AnoSafra ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on b.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on d.cd_unidade = e.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Plantio Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Plantio lista = new TList_Plantio();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Plantio reg = new TRegistro_Plantio();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Plantio")))
                        reg.Id_plantio = reader.GetDecimal(reader.GetOrdinal("Id_Plantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cultura")))
                        reg.Id_cultura = reader.GetDecimal(reader.GetOrdinal("id_cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cultura")))
                        reg.Ds_cultura = reader.GetString(reader.GetOrdinal("ds_cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                        reg.Ds_safra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniPlantio")))
                        reg.Dt_iniplantio = reader.GetDateTime(reader.GetOrdinal("DT_IniPlantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FinPlantio")))
                        reg.Dt_finplantio = reader.GetDateTime(reader.GetOrdinal("DT_FinPlantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_SementesPorMetro")))
                        reg.Qt_sementespormetro = reader.GetDecimal(reader.GetOrdinal("QT_SementesPorMetro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EspacoSemente")))
                        reg.Espacosemente = reader.GetDecimal(reader.GetOrdinal("EspacoSemente"));

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

        public string Gravar(TRegistro_Plantio val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);
            hs.Add("@P_ID_CULTURA", val.Id_cultura);
            hs.Add("@P_ANOSAFRA", val.Anosafra);
            hs.Add("@P_DT_INIPLANTIO", val.Dt_iniplantio);
            hs.Add("@P_DT_FINPLANTIO", val.Dt_finplantio);
            hs.Add("@P_QT_SEMENTESPORMETRO", val.Qt_sementespormetro);
            hs.Add("@P_ESPACOSEMENTE", val.Espacosemente);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FAZ_PLANTIO", hs);
        }

        public string Excluir(TRegistro_Plantio val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);

            return this.executarProc("EXCLUI_FAZ_PLANTIO", hs);
        }
    }
    #endregion

    #region Plantio X Talhoes
    public class TList_Plantio_X_Talhoes : List<TRegistro_Plantio_X_Talhoes>, IComparer<TRegistro_Plantio_X_Talhoes>
    {
        #region IComparer<TRegistro_Plantio_X_Talhoes> Members
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

        public TList_Plantio_X_Talhoes()
        { }

        public TList_Plantio_X_Talhoes(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Plantio_X_Talhoes value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Plantio_X_Talhoes x, TRegistro_Plantio_X_Talhoes y)
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

    
    public class TRegistro_Plantio_X_Talhoes
    {
        private decimal? id_plantio;
        
        public decimal? Id_plantio
        {
            get { return id_plantio; }
            set
            {
                id_plantio = value;
                id_plantiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_plantiostr;
        
        public string Id_plantiostr
        {
            get { return id_plantiostr; }
            set
            {
                id_plantiostr = value;
                try
                {
                    id_plantio = decimal.Parse(value);
                }
                catch
                { id_plantio = null; }
            }
        }
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
        
        public string Ds_talhao
        { get; set; }
        
        public decimal Area_talhao
        { get; set; }
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
        
        public decimal Area_plantada
        { get; set; }
        public decimal Pc_plantado
        {
            get
            {
                if (Area_talhao > decimal.Zero)
                    return Area_plantada * 100 / Area_talhao;
                else
                    return decimal.Zero;
            }
        }
        
        public decimal Producao_prevista
        { get; set; }

        public TRegistro_Plantio_X_Talhoes()
        {
            this.id_plantio = null;
            this.id_plantiostr = string.Empty;
            this.id_talhao = null;
            this.id_talhaostr = string.Empty;
            this.Ds_talhao = string.Empty;
            this.Area_talhao = decimal.Zero;
            this.id_area = null;
            this.id_areastr = string.Empty;
            this.Ds_area = string.Empty;
            this.Cd_fazenda = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Area_plantada = decimal.Zero;
            this.Producao_prevista = decimal.Zero;
        }
    }

    public class TCD_Plantio_X_Talhoes : TDataQuery
    {
        public TCD_Plantio_X_Talhoes()
        { }

        public TCD_Plantio_X_Talhoes(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Id_Plantio, a.ID_Talhao, ");
                sql.AppendLine("d.DS_Talhao, a.ID_Area, c.DS_Area, a.CD_Fazenda, a.producao_prevista, ");
                sql.AppendLine("b.NM_Fazenda, a.Area_Plantada, d.area_talhao, e.sigla_unidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Plantio_X_Talhoes a ");
            sql.AppendLine("inner join VTB_FAZ_FAZENDA b ");
            sql.AppendLine("on a.CD_Fazenda = b.CD_Fazenda ");
            sql.AppendLine("inner join TB_FAZ_Area c ");
            sql.AppendLine("on a.CD_Fazenda = c.CD_Fazenda ");
            sql.AppendLine("and a.ID_Area = c.ID_Area ");
            sql.AppendLine("left outer join TB_FAZ_Talhoes d ");
            sql.AppendLine("on a.CD_Fazenda = d.CD_Fazenda ");
            sql.AppendLine("and a.ID_Area = d.ID_Area ");
            sql.AppendLine("and a.ID_Talhao = d.ID_Talhao ");
            sql.AppendLine("left outer join TB_EST_Unidade e ");
            sql.AppendLine("on b.cd_unidade = e.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Plantio_X_Talhoes Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Plantio_X_Talhoes lista = new TList_Plantio_X_Talhoes();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Plantio_X_Talhoes reg = new TRegistro_Plantio_X_Talhoes();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Plantio")))
                        reg.Id_plantio = reader.GetDecimal(reader.GetOrdinal("Id_Plantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Talhao")))
                        reg.Id_talhao = reader.GetDecimal(reader.GetOrdinal("ID_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Talhao")))
                        reg.Ds_talhao = reader.GetString(reader.GetOrdinal("DS_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("area_talhao")))
                        reg.Area_talhao = reader.GetDecimal(reader.GetOrdinal("area_talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Area")))
                        reg.Id_area = reader.GetDecimal(reader.GetOrdinal("ID_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("DS_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Area_Plantada")))
                        reg.Area_plantada = reader.GetDecimal(reader.GetOrdinal("Area_Plantada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("producao_prevista")))
                        reg.Producao_prevista = reader.GetDecimal(reader.GetOrdinal("producao_prevista"));

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

        public string Gravar(TRegistro_Plantio_X_Talhoes val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);
            hs.Add("@P_AREA_PLANTADA", val.Area_plantada);
            hs.Add("@P_PRODUCAO_PREVISTA", val.Producao_prevista);

            return this.executarProc("IA_FAZ_PLANTIO_X_TALHOES", hs);
        }

        public string Excluir(TRegistro_Plantio_X_Talhoes val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);

            return this.executarProc("EXCLUI_FAZ_PLANTIO_X_TALHOES", hs);
        }
    }
    #endregion
}
