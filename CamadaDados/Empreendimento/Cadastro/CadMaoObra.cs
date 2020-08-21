using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Empreendimento.Cadastro
{
    #region Mao de Obra
    public class TList_CadMaoObra : List<TRegistro_CadMaoObra>, IComparer<TRegistro_CadMaoObra>
    {
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

        public object Clone()
        {
            return MemberwiseClone();
        }
        public TList_CadMaoObra()
        { }

        public TList_CadMaoObra(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadMaoObra value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadMaoObra x, TRegistro_CadMaoObra y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }

    public class TRegistro_CadMaoObra : ICloneable
    {
        public bool st_importar { get; set; } = false;
        private decimal? id_MaoObra = null;
        public decimal? Id_MaoObra
        {
            get { return id_MaoObra; }
            set
            {
                id_MaoObra = value;
                id_MaoObratr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_MaoObratr = string.Empty;
        public string Id_MaoObratr
        {
            get { return id_MaoObratr; }
            set
            {
                id_MaoObratr = value;
                try
                {
                    id_MaoObra = decimal.Parse(value);
                }
                catch { id_MaoObra = null; }
            }
        }

        private decimal? id_orcamento = null;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        public decimal horastrabaladas { get; set; } = decimal.Zero;

        private decimal? id_cargo = null;
        public decimal? Id_cargo
        {
            get { return id_cargo; }
            set
            {
                id_cargo = value;
                id_cargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargostr = string.Empty;
        public string Id_cargostr
        {
            get { return id_cargostr; }
            set
            {
                id_cargostr = value;
                try
                {
                    id_cargo = decimal.Parse(value);
                }
                catch { id_cargo = null; }
            }
        }

        private decimal? id_empresa = null;
        public decimal? Id_empresa
        {
            get { return id_empresa; }
            set
            {
                id_empresa = value;
                id_empresastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_empresastr = string.Empty;
        public string Id_empresastr
        {
            get { return id_empresastr; }
            set
            {
                id_empresastr = value;
                try
                {
                    id_empresa = decimal.Parse(value);
                }
                catch { id_empresa = null; }
            }
        }

        public string Id_unidadestr { get; set; } = string.Empty;

        private decimal? nr_versao = null;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr = string.Empty;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }

        public decimal qtd_pessoas { get; set; } = decimal.Zero;

        public decimal Quantidade { get; set; } = decimal.Zero;

        public decimal vl_unitario { get; set; } = decimal.Zero;

        public decimal vl_subtotal { get; set; } = decimal.Zero;

        public string ds_unidade { get; set; }
        public decimal qtd_horascen { get; set; } = decimal.Zero;
        public decimal qtd_horascinco { get; set; } = decimal.Zero;
        public decimal qtd_adNoturno { get; set; } = decimal.Zero;
        public decimal Qtd_horas150 { get; set; } = decimal.Zero;
        public decimal vl_horas100 { get; set; } = decimal.Zero;
        public decimal vl_horas50 { get; set; } = decimal.Zero;
        public decimal Vl_horas150 { get; set; } = decimal.Zero;
        public decimal vl_horas20 { get; set; } = decimal.Zero;
        public string ds_cargo { get; set; }

        public decimal qtd_executada { get; set; }
        public decimal qtd_exec_100 { get; set; }
        //public decimal qtd_total
        //{
        //    get
        //    {
        //        return decimal.Multiply((Qtd_horas150+ qtd_horascen + qtd_horascinco + qtd_pessoas + qtd_total), Quantidade);
        //    }
        //}
        public decimal qtd_exec_50 { get; set; }
        public decimal qtd_exec_20 { get; set; }
        public decimal Qtd_exec_150 { get; set; } = decimal.Zero;

        public decimal cargahorariaMes { get; set; } = decimal.Zero;
        public TRegistro_CadMaoObra()
        {
            qtd_executada = decimal.Zero;
            qtd_exec_100 = decimal.Zero;
            qtd_exec_20 = decimal.Zero;
            qtd_exec_50 = decimal.Zero;
            id_cargo = decimal.Zero;
            Id_empresa = decimal.Zero;
            id_orcamento = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_unitario = decimal.Zero;
            qtd_pessoas = decimal.Zero;
            Quantidade = decimal.Zero;
            Id_unidadestr = string.Empty;
            ds_unidade = string.Empty;
            nr_versao = decimal.Zero;
            Qtd_horas150 = decimal.Zero;
            ds_cargo = string.Empty;
            id_MaoObra = decimal.Zero;
            qtd_adNoturno = decimal.Zero;
            horastrabaladas = decimal.Zero;
            qtd_horascinco = decimal.Zero;
            qtd_horascen = decimal.Zero;
            cargahorariaMes = decimal.Zero;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_CadMaoObra : TDataQuery
    {
        public TCD_CadMaoObra()
        { }

        public TCD_CadMaoObra(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "  a.nr_versao,  ");
                sql.AppendLine("a.id_registro, c.cargahorariames ,a.qtd_horas100,a.qtd_horas150, a.qtd_horas50,a.cargahorariaMes, a.qtd_adnoturno,a.id_orcamento,a.cd_unidade, b.ds_unidade, c.ds_cargo, a.id_cargo, a.cd_empresa, a.qtd_pessoas, a.quantidade, a.vl_unitario, a.vl_subtotal ");
                sql.AppendLine(", a.id_orcamento,a.cd_unidade, b.ds_unidade, c.ds_cargo, a.id_cargo, a.cd_empresa, a.qtd_pessoas, a.quantidade, a.vl_unitario, a.vl_subtotal, ");
                sql.AppendLine("a.qtd_horasexec, a.qtd_horas50exec, a.qtd_horas100exec,  a.qtd_horas150exec, a.qtd_adnoturnoexec ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  vTB_EMP_MAODEOBRA a ");
            sql.AppendLine("left join TB_EST_Unidade b ");
            sql.AppendLine("on a.cd_unidade = b.cd_unidade ");
            sql.AppendLine("left join TB_DIV_CARGOFUNCIONARIO c ");
            sql.AppendLine("on c.id_cargo = a.id_cargo");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);

            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_CadMaoObra Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadMaoObra lista = new TList_CadMaoObra();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);


            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadMaoObra reg = new TRegistro_CadMaoObra();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_pessoas")))
                        reg.qtd_pessoas = reader.GetDecimal(reader.GetOrdinal("qtd_pessoas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Id_empresastr = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cargo")))
                        reg.Id_cargo = reader.GetDecimal(reader.GetOrdinal("id_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Id_unidadestr = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cargo")))
                        reg.ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_MaoObra = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cargahorariames")))
                        reg.horastrabaladas = reader.GetDecimal(reader.GetOrdinal("cargahorariames"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_adnoturno")))
                        reg.qtd_adNoturno = reader.GetDecimal(reader.GetOrdinal("qtd_adnoturno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas100")))
                        reg.qtd_horascen = reader.GetDecimal(reader.GetOrdinal("qtd_horas100"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas50")))
                        reg.qtd_horascinco = reader.GetDecimal(reader.GetOrdinal("qtd_horas50"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_horas150")))
                        reg.Qtd_horas150 = reader.GetDecimal(reader.GetOrdinal("Qtd_horas150"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cargahorariaMes")))
                        reg.cargahorariaMes = reader.GetDecimal(reader.GetOrdinal("cargahorariaMes"));
                    reg.ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_MaoObra = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas50exec")))
                        reg.qtd_exec_50 = reader.GetDecimal(reader.GetOrdinal("qtd_horas50exec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas100exec")))
                        reg.qtd_exec_100 = reader.GetDecimal(reader.GetOrdinal("qtd_horas100exec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas150exec")))
                        reg.Qtd_exec_150 = reader.GetDecimal(reader.GetOrdinal("qtd_horas150exec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_adnoturnoexec")))
                        reg.qtd_exec_20 = reader.GetDecimal(reader.GetOrdinal("qtd_adnoturnoexec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horasexec")))
                        reg.qtd_executada = reader.GetDecimal(reader.GetOrdinal("qtd_horasexec"));




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

        public string Grava(TRegistro_CadMaoObra vRegistro)
        {
            Hashtable hs = new Hashtable(15);
            hs.Add("@P_CD_EMPRESA", vRegistro.Id_empresastr);
            hs.Add("@P_ID_ORCAMENTO", vRegistro.Id_orcamento);
            hs.Add("@P_NR_VERSAO", vRegistro.Nr_versao);
            hs.Add("@P_ID_CARGO", vRegistro.Id_cargo);
            hs.Add("@P_CD_UNIDADE", vRegistro.Id_unidadestr);
            hs.Add("@P_QTD_PESSOAS", vRegistro.qtd_pessoas);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_VL_UNITARIO", vRegistro.vl_unitario);
            hs.Add("@P_QTD_HORAS100", vRegistro.qtd_horascen);
            hs.Add("@P_QTD_HORAS150", vRegistro.Qtd_horas150);
            hs.Add("@P_QTD_HORAS50", vRegistro.qtd_horascinco);
            hs.Add("@P_QTD_ADNOTURNO", vRegistro.qtd_adNoturno);
            hs.Add("@P_ID_REGISTRO", vRegistro.Id_MaoObra);
            hs.Add("@P_VL_SUBTOTAL", vRegistro.vl_subtotal);
            hs.Add("@P_CARGAHORARIAMES", vRegistro.cargahorariaMes);

            return executarProc("IA_EMP_MAODEOBRA", hs);
        }

        public string Deleta(TRegistro_CadMaoObra vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", vRegistro.Id_empresastr);
            hs.Add("@P_ID_ORCAMENTO", vRegistro.Id_orcamento);
            hs.Add("@P_NR_VERSAO", vRegistro.Nr_versao);
            hs.Add("@P_ID_CARGO", vRegistro.Id_cargo);
            hs.Add("@P_ID_REGISTRO", vRegistro.Id_MaoObra);

            return executarProc("EXCLUI_EMP_MAODEOBRA", hs);
        }
    }
    #endregion

    #region Exec Mao de Obra
    public class TList_ExecCadMaoObra : List<TRegistro_ExecCadMaoObra> { }
    public class TRegistro_ExecCadMaoObra
    {
        public string ds_funcionario { get;set;} = string.Empty;
        private decimal? id_MaoObra = null;
        public decimal? Id_MaoObra
        {
            get { return id_MaoObra; }
            set
            {
                id_MaoObra = value;
                id_MaoObratr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_MaoObratr = string.Empty;
        public string Id_MaoObratr
        {
            get { return id_MaoObratr; }
            set
            {
                id_MaoObratr = value;
                try
                {
                    id_MaoObra = decimal.Parse(value);
                }
                catch { id_MaoObra = null; }
            }
        }

        private decimal? id_orcamento = null;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? id_registro = null;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr = string.Empty;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }

        private decimal? id_empresa = null;
        public decimal? Id_empresa
        {
            get { return id_empresa; }
            set
            {
                id_empresa = value;
                id_empresastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_empresastr = string.Empty;
        public string Id_empresastr
        {
            get { return id_empresastr; }
            set
            {
                id_empresastr = value;
                try
                {
                    id_empresa = decimal.Parse(value);
                }
                catch { id_empresa = null; }
            }
        }
        public string id_cargo { get; set; } = string.Empty;
        public string ds_cargo { get; set; } = string.Empty;
        public string Id_unidadestr { get; set; } = string.Empty;

        private string tp_hora = "A";
        public string Tp_hora
        {
            get { return tp_hora; }
            set
            {
                tp_hora = value;
                if (value.Trim().Equals("0"))
                    tipo_hora = "NORMAL";
                else if (value.Trim().Equals("1"))
                    tipo_hora = "HORA 50";
                else if (value.Trim().Equals("2"))
                    tipo_hora = "HORA 100";
                else if (value.Trim().Equals("3"))
                    tipo_hora = "ADICIONAL NOTURNO";
                else if (value.Trim().Equals("4"))
                    tipo_hora = "HORA 150";
                else tipo_hora = string.Empty;
            }
        }
        private string tipo_hora = "NORMAL";
        public string Tipo_hora
        {
            get { return tipo_hora; }
            set
            {
                tipo_hora = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_hora = "0";
                else if (value.Trim().ToUpper().Equals("HORA 50"))
                    tp_hora = "1";
                else if (value.Trim().ToUpper().Equals("HORA 100"))
                    tp_hora = "2";
                else if (value.Trim().ToUpper().Equals("ADICIONAL NOTURNO"))
                    tp_hora = "3";
                else if (value.Trim().ToUpper().Equals("HORA 150"))
                    tp_hora = "4";
                else tp_hora = string.Empty;
            }
        }

        private decimal? nr_versao = null;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr = string.Empty;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        public decimal qtd_executada { get; set; }

        private DateTime? dt_fim;
        public DateTime? Dt_fim
        {
            get { return dt_fim; }
            set
            {
                dt_fim = value;
                dt_fimstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fimstr;
        public string Dt_fimstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_fimstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_fimstr = value;
                try
                {
                    dt_fim = DateTime.Parse(value);
                }
                catch { dt_fim = null; }
            }
        }
        private DateTime? dt_ini;
        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = DateTime.Parse(value);
                }
                catch { dt_ini = null; }
            }
        }
        private decimal? id_execucao = null;
        public decimal? Id_execucao
        {
            get { return id_execucao; }
            set
            {
                id_execucao = value;
                id_execucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_execucaostr = string.Empty;
        public string Id_execucaostr
        {
            get { return id_execucaostr; }
            set
            {
                id_execucaostr = value;
                try
                {
                    id_execucao = decimal.Parse(value);
                }
                catch { id_execucao = null; }
            }
        }
        public string cd_funcionario { get; set; }
        public TRegistro_ExecCadMaoObra()
        {
            tp_hora = string.Empty;
            cd_funcionario = string.Empty;
            id_registro = decimal.Zero;
            Id_empresa = decimal.Zero;
            id_orcamento = decimal.Zero;
            id_execucao = decimal.Zero;
            qtd_executada = decimal.Zero;
            Dt_fimstr = string.Empty;
            Dt_inistr = string.Empty;
            nr_versao = decimal.Zero;
        }
    }
    public class TCD_ExecCadMaoObra : TDataQuery
    {
        public TCD_ExecCadMaoObra()
        { }

        public TCD_ExecCadMaoObra(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "  a.cd_empresa, a.id_orcamento, a.nr_versao, ");
                sql.AppendLine("a.id_registro, a.id_execucao, a.cd_funcionario,b.nm_clifor, a.qtd_executada,a.tp_hora, a.DT_INIEXEC,a.DT_FINEXEC,c.id_cargo, d.ds_cargo ");

            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_ExecMaodeObra a ");
            sql.AppendLine("left join TB_FIN_Clifor b on b.cd_clifor = a.cd_funcionario ");
            sql.AppendLine("left join TB_EMP_MaodeObra c on c.cd_empresa = a.cd_empresa and c.id_orcamento = a.id_orcamento and a.nr_versao = c.nr_versao and a.id_registro = c.id_registro ");
            sql.AppendLine("left join TB_DIV_CargoFuncionario d on c.id_cargo = d.id_cargo ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_ExecCadMaoObra Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ExecCadMaoObra lista = new TList_ExecCadMaoObra();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            
            try
            {
                reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_ExecCadMaoObra reg = new TRegistro_ExecCadMaoObra();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_execucao")))
                        reg.Id_execucao = reader.GetDecimal(reader.GetOrdinal("id_execucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_funcionario")))
                        reg.cd_funcionario = reader.GetString(reader.GetOrdinal("cd_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_executada")))
                        reg.qtd_executada = reader.GetDecimal(reader.GetOrdinal("qtd_executada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_HORA")))
                        reg.Tp_hora = reader.GetString(reader.GetOrdinal("TP_HORA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_INIEXEC")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("DT_INIEXEC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FINEXEC")))
                        reg.Dt_fim = reader.GetDateTime(reader.GetOrdinal("DT_FINEXEC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.ds_funcionario = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cargo")))
                        reg.id_cargo = reader.GetDecimal(reader.GetOrdinal("id_cargo")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cargo")))
                        reg.ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));




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

        public string Grava(TRegistro_ExecCadMaoObra vRegistro)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_EMPRESA", vRegistro.Id_empresastr);
            hs.Add("@P_ID_ORCAMENTO", vRegistro.Id_orcamento);
            hs.Add("@P_NR_VERSAO", vRegistro.Nr_versao);
            hs.Add("@P_ID_REGISTRO", vRegistro.Id_registro);
            hs.Add("@P_ID_EXECUCAO", vRegistro.Id_execucao);
            hs.Add("@P_QTD_EXECUTADA", vRegistro.qtd_executada);
            hs.Add("@P_TP_HORA", vRegistro.Tp_hora);
            hs.Add("@P_CD_FUNCIONARIO", vRegistro.cd_funcionario);
            hs.Add("@P_DT_INIEXEC", vRegistro.Dt_ini);
            hs.Add("@P_DT_FINEXEC", vRegistro.Dt_fim);

            return executarProc("IA_EMP_EXECMAODEOBRA", hs);
        }

        public string Deleta(TRegistro_ExecCadMaoObra vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", vRegistro.Id_empresastr);
            hs.Add("@P_ID_ORCAMENTO", vRegistro.Id_orcamento);
            hs.Add("@P_NR_VERSAO", vRegistro.Nr_versao);
            hs.Add("@P_ID_EXECUCAO", vRegistro.Id_execucao);
            hs.Add("@P_ID_REGISTRO", vRegistro.Id_MaoObra);

            return executarProc("EXCLUI_EMP_MAODEOBRA", hs);
        }
    }
    #endregion
}
