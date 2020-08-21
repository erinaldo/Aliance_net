using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Utils;
using System.Data;

namespace CamadaDados.Estoque
{
    #region Consulta Produto
    public class TList_ConsultaProduto : List<TRegistro_ConsultaProduto>, IComparer<TRegistro_ConsultaProduto>
    {
        #region IComparer<TRegistro_ConsultaProduto> Members
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

        public TList_ConsultaProduto()
        { }

        public TList_ConsultaProduto(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ConsultaProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ConsultaProduto x, TRegistro_ConsultaProduto y)
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
    
    public class TRegistro_ConsultaProduto
    {
        public string cd_produto
        { get; set; }
        public string ds_produto
        { get; set; }
        private decimal? cd_marca;
        public decimal? Cd_marca
        {
            get { return cd_marca; }
            set
            {
                cd_marca = value;
                cd_MarcaString = (value.HasValue ? value.ToString() : string.Empty);
            }
        }
        private string cd_MarcaString;
        public string Cd_MarcaString
        {
            get { return cd_MarcaString; }
            set
            {
                cd_MarcaString = value;
                try
                {
                    cd_marca = Convert.ToDecimal(value);
                }
                catch { cd_marca = null; }
            }
        }
        public string ds_marca
        { get; set; }
        public string cd_grupo
        { get; set; }
        public string ds_grupo
        { get; set; }
        public string cd_unidade
        { get; set; }
        public string ds_unidade
        { get; set; }
        public string Sg_unidade
        { get; set; }
        private decimal? id_variedade;
        public decimal? Id_variedade
        {
            get { return id_variedade; }
            set
            {
                id_variedade = value;
                id_variedadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_variedadestr;
        public string Id_variedadestr
        {
            get { return id_variedadestr; }
            set
            {
                id_variedadestr = value;
                try
                {
                    id_variedade = decimal.Parse(value);
                }
                catch { id_variedade = null; }
            }
        }
        public string Ds_variedade
        { get; set; }
        public string ds_comercial
        { get; set; }
        public string cd_Empresa
        { get; set; }
        public string nm_Empresa
        { get; set; }
        public string cd_localArm
        { get; set; }
        public string ds_LocalArm
        { get; set; }
        public decimal qtd_reservada
        { get; set; }
        public decimal qtd_saldoest
        { get; set; }
        public decimal Qtd_saldofuturo
        {
            get
            {
                return qtd_saldoest - qtd_reservada;
            }   
        }
        private bool st_Kitbool;
        public bool St_Kitbool
        {
            get { return st_Kitbool; }
            set
            {
                st_Kitbool = value;
                if (value == true)
                {
                    st_KitString = "S";
                }
                else
                {
                    st_KitString = "N";
                }

            }
        }
        private string st_KitString;
        public string St_KitString
        {
            get { return st_KitString; }
            set
            {
                st_KitString = value;
                if (value == "S")
                {
                    st_Kitbool = true;
                }
                else
                {
                    st_Kitbool = false;
                }
            }
        }
        private string _ST_Servico;
        public string ST_Servico
        {
            get { return _ST_Servico; }
            set
            {
                _ST_Servico = value;
                st_servicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_servicobool;
        public bool St_servicobool
        {
            get { return st_servicobool; }
            set
            {
                st_servicobool = value;
                if (value)
                    _ST_Servico = "S";
                else
                    _ST_Servico = "N";
            }
        }
        private bool st_registro;
        public bool St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value)
                    st_registroString = "S";
                else
                    st_registroString = "N";
            }
        }
        private string st_registroString;
        public string St_registroString
        {
            get { return st_registroString; }
            set
            {
                st_registroString = value;
                St_registro = value.Trim().ToUpper().Equals("S");
            }
        }
        public decimal Vl_ultimacompra
        { get; set; }
        public decimal Vl_medio
        { get; set; }
        public decimal Pc_indice_venda
        { get; set; }
        public decimal Vl_custoreal
        {
            get
            {
                if (this.Pc_indice_venda > decimal.Zero)
                    return decimal.Divide(this.Vl_medio, decimal.Divide(100 - this.Pc_indice_venda, 100));
                else return this.Vl_medio;
            }
        }
        public decimal Vl_CustoContabil
        {
            get { return Math.Round(Math.Round(this.qtd_saldoest, 3) * Math.Round(this.Vl_medio, 3), 2); }
        }

        public TRegistro_ConsultaProduto()
        {
            this.cd_produto = string.Empty;
            this.ds_produto = string.Empty;
            this.cd_marca = null;
            this.ds_marca = string.Empty;
            this.cd_grupo = string.Empty;
            this.ds_grupo = string.Empty;
            this.cd_unidade = string.Empty;
            this.ds_unidade = string.Empty;
            this.Sg_unidade = string.Empty;
            this.id_variedade = null;
            this.id_variedadestr = string.Empty;
            this.Ds_variedade = string.Empty;
            this.cd_Empresa = string.Empty;
            this.nm_Empresa = string.Empty;
            this.cd_localArm = string.Empty;
            this.ds_LocalArm = string.Empty;
            this.ds_comercial = string.Empty;
            this.st_Kitbool = false;
            this.st_KitString = "N";
            this.st_servicobool = false;
            this.ST_Servico = "N";
            this.st_registroString = "N";
            this.qtd_reservada = decimal.Zero;
            this.qtd_saldoest = decimal.Zero;
            this.Vl_medio = decimal.Zero;
            this.Pc_indice_venda = decimal.Zero;
            this.Vl_ultimacompra = decimal.Zero;
        }

    }

    public class TCD_ConsultaProduto : TDataQuery
    {
        public TCD_ConsultaProduto()
        { }

        public TCD_ConsultaProduto(string vNm_ProcSqlBusca)
        {
            this.NM_ProcSqlBusca = vNm_ProcSqlBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select a.cd_produto,a.ds_produto,a.cd_grupo,h.st_servico,h.st_composto,a.st_Registro, ");
                sql.AppendLine("a.cd_marca,m.ds_marca,a.cd_unidade,u.ds_unidade,g.ds_grupo,a.ds_tecnica, u.sigla_unidade, ");
                sql.AppendLine("pc_indice_venda = isnull((select top 1 x.Vl_Numerico ");
                sql.AppendLine("                    from TB_CFG_ParamGer x ");
                sql.AppendLine("                    where x.DS_Parametro = 'PC_INDICE_VENDA'), 0) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_est_produto a  ");
            sql.AppendLine("left outer join tb_est_marca m ");
            sql.AppendLine("on a.cd_marca = m.cd_marca ");
            sql.AppendLine("inner join tb_est_unidade u ");
            sql.AppendLine("on a.cd_unidade = u.cd_unidade ");
            sql.AppendLine("left outer join tb_est_grupoProduto g ");
            sql.AppendLine("on a.cd_grupo = g.cd_grupo");
            sql.AppendLine("left outer join tb_est_tpproduto h ");
            sql.AppendLine("on a.tp_produto = h.tp_produto ");



            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaVariedade(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, b.NM_Empresa, ");
            sql.AppendLine("a.cd_produto, c.DS_Produto, c.CD_Unidade, ");
            sql.AppendLine("d.DS_Unidade, d.Sigla_Unidade, a.id_variedade, ");
            sql.AppendLine("e.ds_variedade, a.tot_saldo ");

            sql.AppendLine("from vtb_est_SaldoVariedade a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("left outer join TB_EST_Variedade e ");
            sql.AppendLine("on a.cd_produto = e.CD_Produto ");
            sql.AppendLine("and a.id_variedade = e.ID_Variedade ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.Append(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaLocal(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select a.cd_empresa, d.nm_empresa, a.cd_produto, b.ds_produto, ");
                sql.AppendLine("c.sigla_unidade, a.vl_medio, a.tot_saldo, a.cd_local, f.DS_Local, ");
                sql.AppendLine("e.qtd_saldoreserva, e.qtd_saldofuturo, ");
                sql.AppendLine("Vl_ultimacompra = dbo.F_FAT_ULTIMACOMPRA(a.cd_empresa, a.cd_produto), ");
                sql.AppendLine("pc_indice_venda = isnull((select top 1 x.Vl_Numerico ");
                sql.AppendLine("                    from TB_CFG_ParamGer x ");
                sql.AppendLine("                    where x.DS_Parametro = 'PC_INDICE_VENDA'), 0) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_EST_VLESTOQUELOCAL a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join TB_EST_LocalArm f ");
            sql.AppendLine("on a.cd_local = f.CD_Local ");
            sql.AppendLine("left outer join VTB_EST_RESERVAESTOQUE e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.cd_produto = e.cd_produto ");
            sql.AppendLine("and a.cd_local = e.cd_local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ConsultaProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ConsultaProduto lista = new TList_ConsultaProduto();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaProduto reg = new TRegistro_ConsultaProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_marca")))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("cd_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnica")))
                        reg.ds_comercial = reader.GetString(reader.GetOrdinal("ds_tecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Composto")))
                        reg.St_KitString = reader.GetString(reader.GetOrdinal("st_composto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Registro")))
                        reg.St_registroString = reader.GetString(reader.GetOrdinal("st_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Servico")))
                        reg.ST_Servico = reader.GetString(reader.GetOrdinal("st_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_indice_venda")))
                        reg.Pc_indice_venda = reader.GetDecimal(reader.GetOrdinal("pc_indice_venda"));


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

        public TList_ConsultaProduto SelectLocal(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ConsultaProduto lista = new TList_ConsultaProduto();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBuscaLocal(vBusca, Convert.ToInt16(vTop), vNM_Campo));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaProduto reg = new TRegistro_ConsultaProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.cd_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.cd_localArm = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.ds_LocalArm = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Medio")))
                        reg.Vl_medio = reader.GetDecimal(reader.GetOrdinal("Vl_Medio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ultimacompra")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ultimacompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Saldo")))
                        reg.qtd_saldoest = reader.GetDecimal(reader.GetOrdinal("Tot_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaldoReserva")))
                        reg.qtd_reservada = reader.GetDecimal(reader.GetOrdinal("QTD_SaldoReserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_indice_venda")))
                        reg.Pc_indice_venda = reader.GetDecimal(reader.GetOrdinal("pc_indice_venda"));

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

        public TList_ConsultaProduto SelectVariedade(TpBusca[] vBusca)
        {
            TList_ConsultaProduto lista = new TList_ConsultaProduto();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBuscaVariedade(vBusca));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaProduto reg = new TRegistro_ConsultaProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.cd_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_variedade")))
                        reg.Id_variedade = reader.GetDecimal(reader.GetOrdinal("id_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                        reg.Ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Saldo")))
                        reg.qtd_saldoest = reader.GetDecimal(reader.GetOrdinal("Tot_Saldo"));

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
    }
    #endregion

    #region "Classe Consulta Cliente/Fornecedor"
    public class TList_ConsultaClifor : List<TRegistro_ConsultaClifor>, IComparer<TRegistro_ConsultaClifor>
    {
        #region IComparer<TRegistro_ConsultaClifor> Members
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

        public TList_ConsultaClifor()
        { }

        public TList_ConsultaClifor(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ConsultaClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ConsultaClifor x, TRegistro_ConsultaClifor y)
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

    
    public class TRegistro_ConsultaClifor
    {
        
        public string cd_Clifor
        { get; set; }
        
        public string nm_Clifor
        { get; set; }
        
        public string cd_EnderecoClifor
        { get; set; }
        
        public string enderecoClifor
        { get; set; }
        
        public string Fone
        { get; set; }
        
        public string emailContato
        { get; set; }
        
        public string foneContato
        { get; set; }
        
        public string nm_Contato
        { get; set; }

        private string st_Transportadora;
        
        public string St_Transportadora
        {
            get { return st_Transportadora; }
            set
            {
                st_Transportadora = value;
                if (value == "S")
                {
                    st_TranportadoraBool = true;
                }
                else
                {
                    st_TranportadoraBool = false;
                }
            }
        }

        private bool st_TranportadoraBool;
        
        public bool St_TranportadoraBool
        {
           get { return st_TranportadoraBool; }
            set
            {
                st_TranportadoraBool = value;
                if (value == true)
                {
                    st_Transportadora = "S";
                }
                else
                {
                    st_Transportadora = "N";
                }
            }
        }
        
        private string st_Fornecedor;
        
        public string St_Fornecedor
        {
            get { return st_Fornecedor; }
            set
            {
                st_Fornecedor = value;
                if (value == "S")
                {
                    st_FornecedorBool = true;
                }
                else
                {
                    st_FornecedorBool = false;
                }
            }
        }

        private bool st_FornecedorBool;
        
        public bool St_FornecedorBool
        {
            get { return st_FornecedorBool; }
            set
            {
                st_FornecedorBool = value;
                if (value == true)
                {
                    st_Fornecedor = "S";
                }
                else
                {
                    st_Fornecedor = "N";
                }
            }
        }
        
        public decimal vl_Adto
        { get; set; }
        
        public decimal vl_AdtoQuitado
        { get; set; }
        
        public decimal vl_AdtoQuitar
        {
            get;
            set;
        }
        
        public string cd_Endereco
        { get; set; }
        
        public string ds_Endereco
        { get; set; }
        
        public string numero { get; set; }
        
        public string bairro { get; set; }
        
        public string cidade { get; set; }
        
        public string uf { get; set; }
        
        public string cep { get; set; }
        
        public string complemento { get; set; }

        public TRegistro_ConsultaClifor()
        {
            this.cd_Clifor = string.Empty;
            this.nm_Clifor = string.Empty;
            this.cd_EnderecoClifor = string.Empty;
            this.Fone = string.Empty;
            this.numero = string.Empty;
            this.bairro = string.Empty;
            this.cidade = string.Empty;
            this.uf = string.Empty;
            this.cep = string.Empty;
            this.complemento = string.Empty;
            this.enderecoClifor = string.Empty;
            this.emailContato = string.Empty;
            this.foneContato = string.Empty;
            this.nm_Contato = string.Empty;
            this.st_Fornecedor = string.Empty;
            this.st_FornecedorBool = false;
            this.st_Transportadora = string.Empty;
            this.st_TranportadoraBool = false;
            this.vl_Adto = 0;
            this.vl_AdtoQuitado = 0;
            this.vl_AdtoQuitar = 0;
        }
    }

    public class TCD_ConsultaClifor : TDataQuery
    {
        public TCD_ConsultaClifor()
        { }

        public TCD_ConsultaClifor(string vNm_ProcSqlBusca)
        {
            this.NM_ProcSqlBusca = vNm_ProcSqlBusca;
        }

        private string SqlCodeBuscaClifor(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {


                sql.AppendLine(" Select a.cd_clifor, a.nm_Clifor, b.cd_endereco, ");
                sql.AppendLine("b.ds_endereco,b.cd_cidade, ");
                sql.AppendLine("a.st_transportadora,a.st_Fornecedor ");


            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_clifor a");
            sql.AppendLine("inner join tb_fin_Endereco b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaCliforContato(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {


                sql.AppendLine(" select email,fone,nm_contato  ");
                


            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_contatoClifor c");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaCliforEndereco(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine(" Select a.cd_Endereco, a.ds_Endereco, numero, bairro, ds_cidade as cidade ,uf,cep, ds_complemento, fone ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_endereco a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBusca(this.SqlCodeBuscaClifor(vBusca, vTop, ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBuscaClifor(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBuscaClifor(vBusca, 1, vNM_Campo), null);
        }

        public TList_ConsultaClifor SelectClifor(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ConsultaClifor lista = new TList_ConsultaClifor();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBuscaClifor(vBusca, Convert.ToInt16(vTop), vNM_Campo));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaClifor reg = new TRegistro_ConsultaClifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Clifor")))
                        reg.cd_Clifor = reader.GetString(reader.GetOrdinal("cd_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_Clifor")))
                        reg.nm_Clifor = reader.GetString(reader.GetOrdinal("nm_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.cd_EnderecoClifor = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Endereco")))
                        reg.enderecoClifor = reader.GetString(reader.GetOrdinal("ds_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Transportadora")))
                        reg.St_Transportadora = reader.GetString(reader.GetOrdinal("st_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Fornecedor")))
                        reg.St_Fornecedor = reader.GetString(reader.GetOrdinal("st_Fornecedor"));


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

        public TList_ConsultaClifor SelectCliforContato(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ConsultaClifor lista = new TList_ConsultaClifor();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBuscaCliforContato(vBusca, Convert.ToInt16(vTop), vNM_Campo));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaClifor reg = new TRegistro_ConsultaClifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_Contato")))
                        reg.nm_Contato = reader.GetString(reader.GetOrdinal("nm_Contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        reg.emailContato = reader.GetString(reader.GetOrdinal("email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.foneContato = reader.GetString(reader.GetOrdinal("fone"));
                    



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

        public TList_ConsultaClifor SelectCliforEndereco(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ConsultaClifor lista = new TList_ConsultaClifor();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBuscaCliforEndereco(vBusca, Convert.ToInt16(vTop), vNM_Campo));

            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsultaClifor reg = new TRegistro_ConsultaClifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Endereco")))
                        reg.cd_Endereco = reader.GetString(reader.GetOrdinal("cd_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.ds_Endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cidade")))
                        reg.cidade = reader.GetString(reader.GetOrdinal("cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        reg.cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));

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
    }
    #endregion
}

