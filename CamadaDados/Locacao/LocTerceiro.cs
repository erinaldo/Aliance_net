using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Locacao
{
    #region LocTerceiro
    public class TList_LocTerceiro : List<TRegistro_LocTerceiro>, IComparer<TRegistro_LocTerceiro>
    {
        #region IComparer<TRegistro_LocTerceiro> Members
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

        public TList_LocTerceiro()
        { }

        public TList_LocTerceiro(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LocTerceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LocTerceiro x, TRegistro_LocTerceiro y)
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


    public class TRegistro_LocTerceiro
    {
        private decimal? id_loc;

        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr;

        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = Convert.ToDecimal(value);
                }
                catch
                { id_loc = null; }
            }
        }


        public string Cd_empresa
        { get; set; }

        public string Nm_empresa
        { get; set; }

        public string Cd_fornecedor
        { get; set; }

        public string Nm_fornecedor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        private DateTime? dt_IniContrato;

        public DateTime? Dt_IniContrato
        {
            get { return dt_IniContrato; }
            set
            {
                dt_IniContrato = value;
                dt_IniContratostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_IniContratostr;
        public string Dt_IniContratostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_IniContratostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_IniContratostr = value;
                try
                {
                    dt_IniContrato = Convert.ToDateTime(value);
                }
                catch
                { dt_IniContrato = null; }
            }
        }
        public string Nr_contrato
        { get; set; }
        public decimal Vigencia
        { get; set; }
        public decimal Vl_contrato
        { get; set; }
        public string Obs
        { get; set; }
        private string tp_modalidade;
        public string Tp_modalidade
        {
            get { return tp_modalidade; }
            set
            {
                tp_modalidade = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_modalidade = "MES";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_modalidade = "TRIMESTRE";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_modalidade = "SEMESTRE";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_modalidade = "ANO";
            }
        }
        private string tipo_modalidade;
        public string Tipo_modalidade
        {
            get { return tipo_modalidade; }
            set
            {
                tipo_modalidade = value;
                if (value.Trim().ToUpper().Equals("MES"))
                    tp_modalidade = "0";
                else if (value.Trim().ToUpper().Equals("TRIMESTRE"))
                    tp_modalidade = "1";
                else if (value.Trim().ToUpper().Equals("SEMESTRE"))
                    tp_modalidade = "2";
                else if (value.Trim().ToUpper().Equals("ANO"))
                    tp_modalidade = "3";
            }
        }
        private string st_permuta;
        public string St_permuta
        {
            get { return st_permuta; }
            set
            {
                st_permuta = value;
                st_permutabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_permutabool;
        public bool St_permutabool
        {
            get { return st_permutabool; }
            set
            {
                st_permutabool = value;
                st_permuta = value ? "S" : "N";
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
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADO";
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
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
            }
        }
        public decimal Valor
        { get; set; }
        public string Cd_contager
        { get; set; }
        public TList_ItensLocTerceiro lItens
        { get; set; }
        public TList_ItensLocTerceiro lItensDel
        { get; set; } 
        public Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }     

        public TRegistro_LocTerceiro()
        {
            id_loc = null;
            id_locstr = string.Empty;
            Cd_fornecedor = string.Empty;
            Nm_fornecedor = string.Empty;
            Nr_contrato = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            dt_IniContrato = null;
            dt_IniContratostr = string.Empty;
            Vl_contrato = decimal.Zero;
            Obs = string.Empty;
            Vigencia = decimal.Zero;
            st_permuta = "N";
            st_permutabool = false;
            tipo_modalidade = string.Empty;
            tp_modalidade = string.Empty;
            St_registro = "A";
            Valor = decimal.Zero;
            Cd_contager = string.Empty;

            lItens = new TList_ItensLocTerceiro();
            lItensDel = new TList_ItensLocTerceiro();
            lDup = new Financeiro.Duplicata.TList_RegLanDuplicata();
        }
    }

    public class TCD_LocTerceiro : TDataQuery
    {
        public TCD_LocTerceiro()
        { }

        public TCD_LocTerceiro(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, c.Nm_empresa, a.ID_Loc, a.CD_Fornecedor, b.Nm_clifor, a.CD_Endereco, d.ds_endereco, ");
                sql.AppendLine("a.DT_IniContrato, a.NR_Contrato, a.Vigencia, a.TP_Modalidade, a.Vl_contrato, a.Obs, a.ST_Permuta, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_LOC_LocTerceiro a ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_fornecedor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_Endereco d ");
            sql.AppendLine("on a.cd_fornecedor = d.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = d.cd_endereco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" Order By " + vOrder);

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_LocTerceiro Select(TpBusca[] vBusca, int vTop, string vNm_Campo, string vOrder)
        {
            TList_LocTerceiro lista = new TList_LocTerceiro();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_LocTerceiro reg = new TRegistro_LocTerceiro();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniContrato")))
                        reg.Dt_IniContrato = reader.GetDateTime(reader.GetOrdinal("DT_IniContrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_contrato")))
                        reg.Vl_contrato = reader.GetDecimal(reader.GetOrdinal("Vl_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetString(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vigencia")))
                        reg.Vigencia = reader.GetDecimal(reader.GetOrdinal("Vigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Modalidade")))
                        reg.Tp_modalidade = reader.GetString(reader.GetOrdinal("TP_Modalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Permuta")))
                        reg.St_permuta = reader.GetString(reader.GetOrdinal("ST_Permuta"));
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
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_LocTerceiro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DT_INICONTRATO", val.Dt_IniContrato);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_VIGENCIA", val.Vigencia);
            hs.Add("@P_TP_MODALIDADE", val.Tp_modalidade);
            hs.Add("@P_VL_CONTRATO", val.Vl_contrato);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_PERMUTA", val.St_permuta);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_LOC_LOCTERCEIRO", hs);
        }

        public string Excluir(TRegistro_LocTerceiro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);

            return executarProc("EXCLUI_LOC_LOCTERCEIRO", hs);
        }
    }

    #endregion

    #region ItensLocTerceiro
    public class TList_ItensLocTerceiro : List<TRegistro_ItensLocTerceiro>, IComparer<TRegistro_ItensLocTerceiro>
    {

        #region IComparer<TRegistro_ItensLocTerceiro> Members
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

        public TList_ItensLocTerceiro()
        { }

        public TList_ItensLocTerceiro(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensLocTerceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensLocTerceiro x, TRegistro_ItensLocTerceiro y)
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

    public class TRegistro_ItensLocTerceiro
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_loc;

        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr;

        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = Convert.ToDecimal(value);
                }
                catch
                { id_loc = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = Convert.ToDecimal(value);
                }
                catch
                { id_item = null; }
            }
        }
        public string Nr_patrimonio
        { get; set; }
        public string Cd_patrimonio
        { get; set; }

        public string Ds_patrimonio
        { get; set; }
        public bool St_controlehora { get; set; }
        private DateTime? dt_ini;

        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_inistr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = Convert.ToDateTime(value);
                }
                catch
                { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;

        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_finstr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = Convert.ToDateTime(value);
                }
                catch
                { dt_fin = null; }
            }
        } 
        public string Obs
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
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
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        public decimal Qtd_consumo
        { get; set; }
        public TList_ProdutoItens ProdutoItens { get; set; } = new TList_ProdutoItens();
        public TList_ProdutoItens ProdutoItensDel { get; set; } = new TList_ProdutoItens();
        public TList_AbastItens AbastItens { get; set; } = new TList_AbastItens();

        public TRegistro_ItensLocTerceiro()
        {
            Cd_empresa = string.Empty;
            id_loc = null;
            id_locstr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Nr_patrimonio = string.Empty;
            Cd_patrimonio = string.Empty;
            Ds_patrimonio = string.Empty;
            St_controlehora = false;
            dt_ini = null;
            dt_inistr = null;
            dt_fin = null;
            dt_finstr = string.Empty;
            Obs = string.Empty;
            St_registro = "A";
            Qtd_consumo = decimal.Zero;
        }
    }

    public class TCD_ItensLocTerceiro : TDataQuery
    {
        public TCD_ItensLocTerceiro()
        { }

        public TCD_ItensLocTerceiro(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Loc, a.ID_Item, ");
                sql.AppendLine("c.Nr_patrimonio, c.st_controlehora, a.CD_Patrimonio, b.ds_produto, ");
                sql.AppendLine("a.DT_Ini, a.DT_Fin, a.Obs, b.ds_produto, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_ItensLocTerceiro a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Patrimonio = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Patrimonio c ");
            sql.AppendLine("on b.cd_produto = c.cd_patrimonio ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_ItensLocTerceiro Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_ItensLocTerceiro lista = new TList_ItensLocTerceiro();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensLocTerceiro reg = new TRegistro_ItensLocTerceiro();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Patrimonio")))
                        reg.Cd_patrimonio = reader.GetString(reader.GetOrdinal("CD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_patrimonio = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora")).Trim().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("DT_Ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("DT_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("St_registro"));

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

        public string Gravar(TRegistro_ItensLocTerceiro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PATRIMONIO", val.Cd_patrimonio);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_REGISTRO", val.St_registro);


            return executarProc("IA_LOC_ITENSLOCTERCEIRO", hs);
        }

        public string Excluir(TRegistro_ItensLocTerceiro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_LOC_ITENSLOCTERCEIRO", hs);
        }
    }
    #endregion

    #region ProdutoItens
    public class TList_ProdutoItens : List<TRegistro_ProdutoItens>, IComparer<TRegistro_ProdutoItens>
    {
        #region IComparer<TRegistro_ProdutoItens> Members
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

        public TList_ProdutoItens()
        { }

        public TList_ProdutoItens(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProdutoItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProdutoItens x, TRegistro_ProdutoItens y)
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

    public class TRegistro_ProdutoItens
    {
        public string Cd_empresa { get; set; } = string.Empty;
        private decimal? id_loc = null;
        public decimal? Id_loc
        {
            get{ return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr = string.Empty;
        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = decimal.Parse(value);
                }catch { id_loc = null; }
            }
        }
        private decimal? id_item = null;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr = string.Empty;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }catch { id_item = null; }
            }
        }
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public decimal Qt_medida { get; set; } = decimal.Zero;
    }

    public class TCD_ProdutoItens:TDataQuery
    {
        public TCD_ProdutoItens() { }

        public TCD_ProdutoItens(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Loc, a.ID_Item, ");
                sql.AppendLine("a.Cd_Produto, b.DS_Produto, a.Endereco ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_ProdutoItens a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_ProdutoItens Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_ProdutoItens lista = new TList_ProdutoItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ProdutoItens reg = new TRegistro_ProdutoItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Endereco")))
                        reg.Endereco = reader.GetString(reader.GetOrdinal("Endereco"));

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

        public string Gravar(TRegistro_ProdutoItens val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ENDERECO", val.Endereco);


            return executarProc("IA_LOC_PRODUTOITENS", hs);
        }

        public string Excluir(TRegistro_ProdutoItens val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return executarProc("EXCLUI_LOC_PRODUTOITENS", hs);
        }
    }
    #endregion

    #region FatLocTerceiro
    public class TList_FatLocTerceiro : List<TRegistro_FatLocTerceiro>, IComparer<TRegistro_FatLocTerceiro>
    {
        #region IComparer<TRegistro_FatLocTerceiro> Members
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

        public TList_FatLocTerceiro()
        { }

        public TList_FatLocTerceiro(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FatLocTerceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FatLocTerceiro x, TRegistro_FatLocTerceiro y)
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


    public class TRegistro_FatLocTerceiro
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_loc;

        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr;

        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = Convert.ToDecimal(value);
                }
                catch
                { id_loc = null; }
            }
        }

        public decimal? Nr_lancto
        { get; set; }


        public TRegistro_FatLocTerceiro()
        {
            Cd_empresa = string.Empty;
            id_loc = null;
            id_locstr = string.Empty;
            Nr_lancto = null;
        }
    }

    public class TCD_FatLocTerceiro : TDataQuery
    {
        public TCD_FatLocTerceiro()
        { }

        public TCD_FatLocTerceiro(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Loc, a.Nr_lancto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_FatLocTerceiro a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_FatLocTerceiro Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_FatLocTerceiro lista = new TList_FatLocTerceiro();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_FatLocTerceiro reg = new TRegistro_FatLocTerceiro();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("Nr_lancto"));

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

        public string Gravar(TRegistro_FatLocTerceiro val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);


            return executarProc("IA_LOC_FATLOCTERCEIRO", hs);
        }

        public string Excluir(TRegistro_FatLocTerceiro val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_LOC_FATLOCTERCEIRO", hs);
        }
    }
    #endregion

    #region AbastItens
    public class TList_AbastItens : List<TRegistro_AbastItens>, IComparer<TRegistro_AbastItens>
    {

        #region IComparer<TRegistro_AbastItens> Members
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

        public TList_AbastItens()
        { }

        public TList_AbastItens(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AbastItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AbastItens x, TRegistro_AbastItens y)
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

    public class TRegistro_AbastItens
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_loc;

        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr;

        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = Convert.ToDecimal(value);
                }
                catch
                { id_loc = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = Convert.ToDecimal(value);
                }
                catch
                { id_item = null; }
            }
        }
        private decimal? id_carga;

        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;

        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }
        private decimal? id_itemcarga;

        public decimal? Id_itemcarga
        {
            get { return id_itemcarga; }
            set
            {
                id_itemcarga = value;
                id_itemcargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcargastr;

        public string Id_itemcargastr
        {
            get { return id_itemcargastr; }
            set
            {
                id_itemcargastr = value;
                try
                {
                    id_itemcarga = decimal.Parse(value);
                }
                catch
                { id_itemcarga = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_patrimonio { get; set; }
        public string Ds_patrimonio { get; set; }
        public string Nr_patrimonio
        { get; set; }
        private DateTime? dt_abast;

        public DateTime? Dt_abast
        {
            get { return dt_abast; }
            set
            {
                dt_abast = value;
                dt_abaststr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_abaststr;
        public string Dt_abaststr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_abaststr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_abaststr = value;
                try
                {
                    dt_abast = Convert.ToDateTime(value);
                }
                catch
                { dt_abast = null; }
            }
        }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitCusto
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal => Vl_unitario * Quantidade;
        public bool St_processar
        { get; set; }


        public TRegistro_AbastItens()
        {
            Cd_empresa = string.Empty;
            id_loc = null;
            id_locstr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            id_carga = null;
            id_cargastr = string.Empty;
            id_itemcarga = null;
            id_itemcargastr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Cd_patrimonio = string.Empty;
            Ds_patrimonio = string.Empty;
            Nr_patrimonio = string.Empty;
            dt_abast = null;
            dt_abaststr = null;
            Quantidade = decimal.Zero;
            Vl_unitCusto = decimal.Zero;
            Vl_unitario = decimal.Zero;
            St_processar = false;
        }
    }

    public class TCD_AbastItens : TDataQuery
    {
        public TCD_AbastItens()
        { }

        public TCD_AbastItens(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Loc, a.ID_Item, a.ID_Carga, a.ID_ItemCarga, ");
                sql.AppendLine("b.cd_produto, c.ds_produto, e.Nr_patrimonio, a.DT_Abast, a.Quantidade, a.Vl_UnitCusto, ");
                sql.AppendLine("c.cd_unidade, f.ds_unidade, f.sigla_unidade, c.CD_CondFiscal_Produto, ");
                sql.AppendLine("d.cd_patrimonio, p.ds_produto as Ds_Patrimonio, a.vl_precovenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_AbastItens a ");
            sql.AppendLine("inner join TB_FAT_ItensCargaAvulsa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and b.id_carga = a.id_carga ");
            sql.AppendLine("and b.id_item = a.id_itemcarga ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on c.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_LOC_ItensLocTerceiro d ");
            sql.AppendLine("on d.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and d.id_loc = a.id_loc ");
            sql.AppendLine("and d.id_item = a.id_item ");
            sql.AppendLine("inner join TB_EST_Patrimonio e ");
            sql.AppendLine("on e.cd_patrimonio = d.cd_patrimonio ");
            sql.AppendLine("inner join TB_EST_Produto p ");
            sql.AppendLine("on e.cd_patrimonio = p.cd_produto ");
            sql.AppendLine("left join TB_EST_Unidade f ");
            sql.AppendLine("on f.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join tb_div_cfgempresa cfg ");
            sql.AppendLine("on a.cd_empresa = cfg.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_AbastItens Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_AbastItens lista = new TList_AbastItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBuscaReader(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo), null);
                while (reader.Read())
                {
                    TRegistro_AbastItens reg = new TRegistro_AbastItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCarga")))
                        reg.Id_itemcarga = reader.GetDecimal(reader.GetOrdinal("ID_ItemCarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("Ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("Cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("Ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("Cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Patrimonio")))
                        reg.Cd_patrimonio = reader.GetString(reader.GetOrdinal("CD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Patrimonio")))
                        reg.Ds_patrimonio = reader.GetString(reader.GetOrdinal("Ds_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abast")))
                        reg.Dt_abast = reader.GetDateTime(reader.GetOrdinal("DT_Abast"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_UnitCusto")))
                        reg.Vl_unitCusto = reader.GetDecimal(reader.GetOrdinal("Vl_UnitCusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precovenda")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_precovenda"));

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

        public string Gravar(TRegistro_AbastItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);
            hs.Add("@P_DT_ABAST", val.Dt_abast);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITCUSTO", val.Vl_unitCusto);


            return executarProc("IA_LOC_ABASTITENS", hs);
        }

        public string Excluir(TRegistro_AbastItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);

            return executarProc("EXCLUI_LOC_ABASTITENS", hs);
        }
    }
    #endregion

    #region AbastItens X NFCEItens
    public class TList_AbastItens_X_NFCeItens : List<TRegistro_AbastItens_X_NFCeItens>, IComparer<TRegistro_AbastItens_X_NFCeItens>
    {

        #region IComparer<TRegistro_AbastItens_X_NFCeItens> Members
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

        public TList_AbastItens_X_NFCeItens()
        { }

        public TList_AbastItens_X_NFCeItens(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AbastItens_X_NFCeItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AbastItens_X_NFCeItens x, TRegistro_AbastItens_X_NFCeItens y)
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

    public class TRegistro_AbastItens_X_NFCeItens
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_loc;

        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr;

        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = Convert.ToDecimal(value);
                }
                catch
                { id_loc = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = Convert.ToDecimal(value);
                }
                catch
                { id_item = null; }
            }
        }
        private decimal? id_carga;

        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;

        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }
        private decimal? id_itemcarga;

        public decimal? Id_itemcarga
        {
            get { return id_itemcarga; }
            set
            {
                id_itemcarga = value;
                id_itemcargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcargastr;

        public string Id_itemcargastr
        {
            get { return id_itemcargastr; }
            set
            {
                id_itemcargastr = value;
                try
                {
                    id_itemcarga = decimal.Parse(value);
                }
                catch
                { id_itemcarga = null; }
            }
        }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_lancto
        { get; set; }


        public TRegistro_AbastItens_X_NFCeItens()
        {
            Cd_empresa = string.Empty;
            id_loc = null;
            id_locstr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            id_carga = null;
            id_cargastr = string.Empty;
            id_itemcarga = null;
            id_itemcargastr = string.Empty;
            Id_cupom = null;
            Id_lancto = null;
        }
    }

    public class TCD_AbastItens_X_NFCeItens : TDataQuery
    {
        public TCD_AbastItens_X_NFCeItens()
        { }

        public TCD_AbastItens_X_NFCeItens(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo, bool St_colEnt)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Loc, a.ID_Item, a.ID_Carga, a.ID_ItemCarga, ");
                sql.AppendLine("a.id_cupom, a.id_lancto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_AbastItens_X_NFCeItens a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, false), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, false), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, false), null);
        }

        public TList_AbastItens_X_NFCeItens Select(TpBusca[] vBusca, int vTop, string vNm_Campo, bool St_colEnt)
        {
            TList_AbastItens_X_NFCeItens lista = new TList_AbastItens_X_NFCeItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, St_colEnt));
                while (reader.Read())
                {
                    TRegistro_AbastItens_X_NFCeItens reg = new TRegistro_AbastItens_X_NFCeItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCarga")))
                        reg.Id_itemcarga = reader.GetDecimal(reader.GetOrdinal("ID_ItemCarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("Id_lancto"));

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

        public string Gravar(TRegistro_AbastItens_X_NFCeItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);


            return executarProc("IA_LOC_ABASTITENS_X_NFCEITENS", hs);
        }

        public string Excluir(TRegistro_AbastItens_X_NFCeItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("EXCLUI_LOC_ABASTITENS_X_NFCEITENS", hs);
        }
    }
    #endregion
}
