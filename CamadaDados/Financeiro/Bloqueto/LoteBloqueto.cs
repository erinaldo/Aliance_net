using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    #region "Lote Bloqueto"
    public class TList_LoteBloqueto : List<TRegistro_LoteBloqueto>, IComparer<TRegistro_LoteBloqueto>
    {
        #region IComparer<TRegistro_LoteBloqueto> Members
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

        public TList_LoteBloqueto()
        { }

        public TList_LoteBloqueto(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteBloqueto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteBloqueto x, TRegistro_LoteBloqueto y)
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
    
    public class TRegistro_LoteBloqueto
    {
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = (value.HasValue ? value.Value.ToString() : string.Empty);
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
        public string Ds_lote
        { get; set; }
        private DateTime? dt_lote;
        public DateTime? Dt_lote
        {
            get { return dt_lote; }
            set
            {
                dt_lote = value;
                dt_lotestr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
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
        private DateTime? dt_processamento;
        public DateTime? Dt_processamento
        {
            get
            {
                return dt_processamento;
            }
            set
            {
                dt_processamento = value;
                dt_processamentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_processamentostr;
        public string Dt_processamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_processamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_processamentostr = value;
                try
                {
                    dt_processamento = Convert.ToDateTime(value);
                }
                catch
                { dt_processamento = null; }
            }
        }
        public decimal Vl_taxa
        { get; set; }
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
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
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
                }catch { id_config = null; }
            }
        }
        public string Ds_config
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public TList_Lote_X_Titulo lBloquetos
        { get; set; }
        public blListaTitulo lBloquetosExcluir
        { get; set; }
        public TList_Lote_X_Caixa lCaixa
        { get; set; }
        public Caixa.TList_LanCaixa ListaCaixa
        { get; set; }
        public blListaTitulo ListaBloqueto
        { get; set; }
    
        public TRegistro_LoteBloqueto()
        {
            id_lote = null;
            id_lotestr = string.Empty;
            Ds_lote = string.Empty;
            dt_lote = null;
            dt_lotestr = string.Empty;
            dt_processamento = null;
            dt_processamentostr = string.Empty;
            Vl_taxa = decimal.Zero;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_config = null;
            id_configstr = string.Empty;
            Ds_config = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            St_registro = "A";
            status = "ABERTO";
            lBloquetos = new TList_Lote_X_Titulo();
            lBloquetosExcluir = new blListaTitulo();
            lCaixa = new TList_Lote_X_Caixa();
            ListaBloqueto = new blListaTitulo();
            ListaCaixa = new Caixa.TList_LanCaixa();
        }
    }

    public class TCD_LoteBloqueto : TDataQuery
    {
        public TCD_LoteBloqueto()
        { }

        public TCD_LoteBloqueto(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_lote, a.ds_lote, ");
                sql.AppendLine("a.dt_lote, a.vl_taxa, a.st_registro, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa, a.dt_processamento, ");
                sql.AppendLine("a.id_config,  c.ds_config, c.cd_contager, d.ds_contager ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_lote a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_cob_cfgbanco c ");
            sql.AppendLine("on a.id_config = c.id_config ");
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on c.cd_contager = d.cd_contager ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LoteBloqueto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteBloqueto lista = new TList_LoteBloqueto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteBloqueto reg = new TRegistro_LoteBloqueto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Lote"))))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lote"))))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Taxa"))))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("ID_Config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("DS_Config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));

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

        public string Gravar(TRegistro_LoteBloqueto val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_DS_LOTE", val.Ds_lote);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_processamento);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_COB_LOTE", hs);
        }

        public string Excluir(TRegistro_LoteBloqueto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return executarProc("EXCLUI_COB_LOTE", hs);
        }
    }
    #endregion

    #region "Lote Bloqueto X Bloqueto"
    public class TList_Lote_X_Titulo : List<TRegistro_Lote_X_Titulo>
    { }
    
    public class TRegistro_Lote_X_Titulo
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lancto
        { get; set; }
        
        public decimal? Cd_parcela
        { get; set; }
        
        public decimal? Id_cobranca
        { get; set; }
        
        public decimal? Id_lote
        { get; set; }
        
        public decimal Vl_taxa
        { get; set; }
        
        public decimal Vl_documento
        { get; set; }
       
        public TRegistro_Lote_X_Titulo()
        {
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Cd_parcela = null;
            Id_cobranca = null;
            Id_lote = null;
            Vl_taxa = decimal.Zero;
            Vl_documento = decimal.Zero;
        }
    }

    public class TCD_Lote_X_Titulo : TDataQuery
    {
        public TCD_Lote_X_Titulo()
        { }

        public TCD_Lote_X_Titulo(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lancto, ");
                sql.AppendLine("a.cd_parcela, a.id_cobranca, a.id_lote, a.vl_taxa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_lote_x_titulo a ");
            sql.AppendLine("inner join tb_cob_lote b ");
            sql.AppendLine("on a.id_lote = b.id_lote ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lote_X_Titulo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Lote_X_Titulo lista = new TList_Lote_X_Titulo();
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lote_X_Titulo reg = new TRegistro_Lote_X_Titulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_taxa")))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));

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

        public string Gravar(TRegistro_Lote_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);

            return executarProc("IA_COB_LOTE_X_TITULO", hs);
        }

        public string Excluir(TRegistro_Lote_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);

            return executarProc("EXCLUI_COB_LOTE_X_TITULO", hs);
        }
    }
    #endregion

    #region "Lote Bloqueto X Caixa"
    public class TList_Lote_X_Caixa : List<TRegistro_Lote_X_Caixa>
    { }
    
    public class TRegistro_Lote_X_Caixa
    {
        
        public decimal Id_lote
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public decimal Cd_lanctocaixa
        { get; set; }        
        private string tp_registro;
        
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("L"))
                    tipo_registro = "LIQUIDACAO";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_registro = "TAXA";
            }
        }        
        private string tipo_registro;
        
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("LIQUIDACAO"))
                    tp_registro = "L";
                else if (value.Trim().ToUpper().Equals("TAXA"))
                    tp_registro = "T";
            }
        }
        
        public TRegistro_Lote_X_Caixa()
        {
            Id_lote = decimal.Zero;
            Cd_contager = string.Empty;
            Cd_lanctocaixa = decimal.Zero;
            tp_registro = string.Empty;
            tipo_registro = string.Empty;
        }
    }

    public class TCD_Lote_X_Caixa : TDataQuery
    {
        public TCD_Lote_X_Caixa()
        { }

        public TCD_Lote_X_Caixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.id_lote, a.cd_contager, a.cd_lanctocaixa, a.tp_registro ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_lote_x_caixa a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lote_X_Caixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Lote_X_Caixa lista = new TList_Lote_X_Caixa();
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lote_X_Caixa reg = new TRegistro_Lote_X_Caixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa"))))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Registro"))))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));

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

        public string GravarLote_X_Caixa(TRegistro_Lote_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);

            return executarProc("IA_COB_LOTE_X_CAIXA", hs);
        }

        public string DeletarLote_X_Caixa(TRegistro_Lote_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("EXCLUI_COB_LOTE_X_CAIXA", hs);
        }
    }
    #endregion
}
