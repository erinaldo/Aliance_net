using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CamadaDados.Financeiro.Bloqueto
{
    #region Lote Remessa
    public class TList_LoteRemessa : List<TRegistro_LoteRemessa>, IComparer<TRegistro_LoteRemessa>
    {
        #region IComparer<TRegistro_LoteRemessa> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_LoteRemessa()
        { }

        public TList_LoteRemessa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteRemessa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteRemessa x, TRegistro_LoteRemessa y)
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
    
    public class TRegistro_LoteRemessa
    {
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = Convert.ToDecimal(value);
                }
                catch
                { id_lote = null; }
            }
        }
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch { id_config = null; }
            }
        }
        public string Ds_config
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        private DateTime? dt_lote;
        public DateTime? Dt_lote
        {
            get { return dt_lote; }
            set
            {
                dt_lote = value;
                dt_lotestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lotestr;
        public string Dt_lotestr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_lotestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lotestr = value;
                try
                {
                    dt_lote = Convert.ToDateTime(value);
                }
                catch
                { dt_lote = null; }
            }
        }
        private string tp_instrucao;
        public string Tp_instrucao
        {
            get { return tp_instrucao; }
            set
            {
                tp_instrucao = value;
                if (value.Trim().ToUpper().Equals("RT"))
                    tipo_instrucao = "REGISTRAR TITULO";
                else if (value.Trim().ToUpper().Equals("PB"))
                    tipo_instrucao = "PEDIDO BAIXA";
                else if (value.Trim().ToUpper().Equals("CA"))
                    tipo_instrucao = "CONCEDER ABATIMENTO";
                else if (value.Trim().ToUpper().Equals("CB"))
                    tipo_instrucao = "CANCELAR ABATIMENTO";
                else if (value.Trim().ToUpper().Equals("CD"))
                    tipo_instrucao = "CONCEDER DESCONTO";
                else if (value.Trim().ToUpper().Equals("CE"))
                    tipo_instrucao = "CANCELAR DESCONTO";
                else if (value.Trim().ToUpper().Equals("AV"))
                    tipo_instrucao = "ALTERAR VENCIMENTO";
                else if (value.Trim().ToUpper().Equals("PT"))
                    tipo_instrucao = "PROTESTAR";
                else if (value.Trim().ToUpper().Equals("CP"))
                    tipo_instrucao = "CANCELAR PROTESTO";
            }
        }
        private string tipo_instrucao;
        public string Tipo_instrucao
        {
            get { return tipo_instrucao; }
            set
            {
                tipo_instrucao = value;
                if (value.Trim().ToUpper().Equals("REGISTRAR TITULO"))
                    tipo_instrucao = "RT";
                else if (value.Trim().ToUpper().Equals("PEDIDO BAIXA"))
                    tipo_instrucao = "PB";
                else if (value.Trim().ToUpper().Equals("CONCEDER ABATIMENTO"))
                    tipo_instrucao = "CA";
                else if (value.Trim().ToUpper().Equals("CANCELAR ABATIMENTO"))
                    tipo_instrucao = "CB";
                else if (value.Trim().ToUpper().Equals("CONCEDER DESCONTO"))
                    tipo_instrucao = "CD";
                else if (value.Trim().ToUpper().Equals("CANCELAR DESCONTO"))
                    tipo_instrucao = "CE";
                else if (value.Trim().ToUpper().Equals("ALTERAR VENCIMENTO"))
                    tipo_instrucao = "AV";
                else if (value.Trim().ToUpper().Equals("PROTESTAR"))
                    tipo_instrucao = "PT";
                else if (value.Trim().ToUpper().Equals("CANCELAR PROTESTO"))
                    tipo_instrucao = "CP";
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
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        public string Path_remessa
        { get; set; }
        public decimal Nr_arqRemessa
        { get; set; }
        public blListaTitulo lTitulos
        { get; set; }
        public blListaTitulo lTitulosDel
        { get; set; }

        public TRegistro_LoteRemessa()
        {
            id_lote = null;
            id_lotestr = string.Empty;
            id_config = null;
            id_configstr = string.Empty;
            Ds_config = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            dt_lote = DateTime.Now;
            dt_lotestr = DateTime.Now.ToString("dd/MM/yyyy");
            tp_instrucao = string.Empty;
            tipo_instrucao = string.Empty;
            st_registro = "A";
            status = "ABERTO";
            Path_remessa = string.Empty;
            Nr_arqRemessa = decimal.Zero;
            lTitulos = new blListaTitulo();
            lTitulosDel = new blListaTitulo();
        }
    }

    public class TCD_LoteRemessa : TDataQuery
    {
        public TCD_LoteRemessa()
        { }

        public TCD_LoteRemessa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_lote, a.id_config, ");
                sql.AppendLine("b.ds_config, b.cd_empresa, c.nm_empresa, ");
                sql.AppendLine("b.cd_contager, d.ds_contager, a.nr_arqremessa, ");
                sql.AppendLine("a.dt_lote, a.tp_instrucao, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_loteremessa a ");
            sql.AppendLine("inner join tb_cob_cfgbanco b ");
            sql.AppendLine("on a.id_config = b.id_config ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on b.cd_contager = d.cd_contager ");

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

        public TList_LoteRemessa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LoteRemessa lista = new TList_LoteRemessa();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteRemessa reg = new TRegistro_LoteRemessa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lote")))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_instrucao")))
                        reg.Tp_instrucao = reader.GetString(reader.GetOrdinal("tp_instrucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_arqremessa")))
                        reg.Nr_arqRemessa = reader.GetDecimal(reader.GetOrdinal("nr_arqremessa"));
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

        public string Gravar(TRegistro_LoteRemessa val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_TP_INSTRUCAO", val.Tp_instrucao);
            hs.Add("@P_NR_ARQREMESSA", val.Nr_arqRemessa);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_COB_LOTEREMESSA", hs);
        }

        public string Excluir(TRegistro_LoteRemessa val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return executarProc("EXCLUI_COB_LOTEREMESSA", hs);
        }
    }
    #endregion

    #region Lote Remessa X Titulo
    public class TList_LoteRemessa_X_Titulo : List<TRegistro_LoteRemessa_X_Titulo>
    { }
    
    public class TRegistro_LoteRemessa_X_Titulo
    {
        public decimal? Id_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public decimal? Cd_parcela
        { get; set; }
        public decimal? Id_cobranca
        { get; set; }
        public string St_loteremessa
        { get; set; }
        public string Status_loteremessa
        {
            get
            {
                if (St_loteremessa.Trim().ToUpper().Equals("A"))
                    return "ACEITO";
                else if (St_loteremessa.Trim().ToUpper().Equals("R"))
                    return "REJEITADO";
                else if (St_loteremessa.Trim().ToUpper().Equals("B"))
                    return "BAIXADO";
                else if (St_loteremessa.Trim().ToUpper().Equals("P"))
                    return "PROTESTADO";
                else return string.Empty;
            }
        }
        public string Ds_motivo
        { get; set; }

        public TRegistro_LoteRemessa_X_Titulo()
        {
            Id_lote = null;
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Cd_parcela = null;
            Id_cobranca = null;
            St_loteremessa = string.Empty;
            Ds_motivo = string.Empty;
        }
    }

    public class TCD_LoteRemessa_X_Titulo : TDataQuery
    {
        public TCD_LoteRemessa_X_Titulo()
        { }

        public TCD_LoteRemessa_X_Titulo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_lote, a.cd_empresa, ");
                sql.AppendLine("a.nr_lancto, a.cd_parcela, a.id_cobranca, ");
                sql.AppendLine("a.st_loteremessa, a.ds_motivo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_loteremessa_x_titulo a ");
            sql.AppendLine("inner join tb_cob_loteremessa b ");
            sql.AppendLine("on a.id_lote = b.id_lote ");

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

        public TList_LoteRemessa_X_Titulo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LoteRemessa_X_Titulo lista = new TList_LoteRemessa_X_Titulo();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteRemessa_X_Titulo reg = new TRegistro_LoteRemessa_X_Titulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cobranca")))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_LoteRemessa")))
                        reg.St_loteremessa = reader.GetString(reader.GetOrdinal("st_loteremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("DS_Motivo"));
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

        public string Gravar(TRegistro_LoteRemessa_X_Titulo val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_ST_LOTEREMESSA", val.St_loteremessa);
            hs.Add("@P_DS_MOTIVO", val.Ds_motivo);

            return executarProc("IA_COB_LOTEREMESSA_X_TITULO", hs);
        }

        public string Excluir(TRegistro_LoteRemessa_X_Titulo val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);

            return executarProc("EXCLUI_COB_LOTEREMESSA_X_TITULO", hs);
        }
    }
    #endregion
}
