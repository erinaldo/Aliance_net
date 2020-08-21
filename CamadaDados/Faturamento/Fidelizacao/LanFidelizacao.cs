using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Fidelizacao
{
    #region Prog Fidelidade
    public class TList_ProgFidelidade : List<TRegistro_ProgFidelidade>, IComparer<TRegistro_ProgFidelidade>
    {
        #region IComparer<TRegistro_ProgFidelidade> Members
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

        public TList_ProgFidelidade()
        { }

        public TList_ProgFidelidade(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProgFidelidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProgFidelidade x, TRegistro_ProgFidelidade y)
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

    public class TRegistro_ProgFidelidade
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private string tp_vl_pc;
        public string Tp_vl_pc
        {
            get { return tp_vl_pc; }
            set
            {
                tp_vl_pc = value;
                if (value.Trim().ToUpper().Equals("V"))
                    tipo_vl_pc = "R$";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_vl_pc = "%";
            }
        }
        private string tipo_vl_pc;
        public string Tipo_vl_pc
        {
            get { return tipo_vl_pc; }
            set
            {
                tipo_vl_pc = value;
                if (value.Trim().ToUpper().Equals("R$"))
                    tp_vl_pc = "V";
                else if (value.Trim().ToUpper().Equals("%"))
                    tp_vl_pc = "P";
            }
        }
        public decimal Valor
        { get; set; }
        public decimal Qt_pontos
        { get; set; }
        public decimal Qt_pontosind
        { get; set; }
        public decimal Nr_diasvalidade
        { get; set; }
        public decimal Pc_maxpontosutilizar
        { get; set; }

        public TRegistro_ProgFidelidade()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            tp_vl_pc = string.Empty;
            tipo_vl_pc = string.Empty;
            Valor = decimal.Zero;
            Qt_pontos = decimal.Zero;
            Qt_pontosind = decimal.Zero;
            Nr_diasvalidade = decimal.Zero;
            Pc_maxpontosutilizar = decimal.Zero;
        }
    }

    public class TCD_ProgFidelidade : TDataQuery
    {
        public TCD_ProgFidelidade() { }

        public TCD_ProgFidelidade(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.tp_vl_pc, a.valor, a.qt_pontos, a.qt_pontosind, ");
                sql.AppendLine("a.pc_maxpontosutilizar, a.nr_diasvalidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAT_ProgFidelidade a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ProgFidelidade Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ProgFidelidade lista = new TList_ProgFidelidade();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ProgFidelidade reg = new TRegistro_ProgFidelidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_vl_pc")))
                        reg.Tp_vl_pc = reader.GetString(reader.GetOrdinal("tp_vl_pc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontos")))
                        reg.Qt_pontos = reader.GetDecimal(reader.GetOrdinal("qt_pontos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontosind")))
                        reg.Qt_pontosind = reader.GetDecimal(reader.GetOrdinal("qt_pontosind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasvalidade")))
                        reg.Nr_diasvalidade = reader.GetDecimal(reader.GetOrdinal("nr_diasvalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_maxpontosutilizar")))
                        reg.Pc_maxpontosutilizar = reader.GetDecimal(reader.GetOrdinal("pc_maxpontosutilizar"));

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

        public string Gravar(TRegistro_ProgFidelidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_VL_PC", val.Tp_vl_pc);
            hs.Add("@P_VALOR", val.Valor);
            hs.Add("@P_QT_PONTOS", val.Qt_pontos);
            hs.Add("@P_QT_PONTOSIND", val.Qt_pontosind);
            hs.Add("@P_NR_DIASVALIDADE", val.Nr_diasvalidade);
            hs.Add("@P_PC_MAXPONTOSUTILIZAR", val.Pc_maxpontosutilizar);

            return executarProc("IA_FAT_PROGFIDELIDADE", hs);
        }

        public string Excluir(TRegistro_ProgFidelidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FAT_PROGFIDELIDADE", hs);
        }
    }
    #endregion

    #region Pontos Fidelidade
    public class TList_PontosFidelidade : List<TRegistro_PontosFidelidade>, IComparer<TRegistro_PontosFidelidade>
    {
        #region IComparer<TRegistro_PontosFidelidade> Members
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

        public TList_PontosFidelidade()
        { }

        public TList_PontosFidelidade(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PontosFidelidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PontosFidelidade x, TRegistro_PontosFidelidade y)
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

    public class TRegistro_PontosFidelidade
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_ponto;
        public decimal? Id_ponto
        {
            get { return id_ponto; }
            set
            {
                id_ponto = value;
                id_pontostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pontostr;
        public string Id_pontostr
        {
            get { return id_pontostr; }
            set
            {
                id_pontostr = value;
                try
                {
                    id_ponto = decimal.Parse(value);
                }
                catch { id_ponto = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Placa
        { get; set; }
        public string Cpf_cliente
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch { id_cupom = null; }
            }
        }
        private DateTime? dt_registro;
        public DateTime? Dt_registro
        {
            get { return dt_registro; }
            set
            {
                dt_registro = value;
                dt_registrostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_registrostr;
        public string Dt_registrostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_registrostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_registrostr = value;
                try
                {
                    dt_registro = DateTime.Parse(value);
                }
                catch { dt_registro = null; }
            }
        }
        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = DateTime.Parse(value);
                }
                catch { dt_validade = null; }
            }
        }
        public decimal Qt_pontos
        { get; set; }
        public decimal Pontos_res
        { get; set; }
        public decimal SD_Pontos
        { get { return Qt_pontos - Pontos_res; } }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return SD_Pontos.Equals(decimal.Zero) ? "RESGATADO" : "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public string MotivoCancelamento
        { get; set; }
        public string LoginCanc
        { get; set; }
        public TList_ResgatePontos lPontosRes
        { get; set; }

        public TRegistro_PontosFidelidade()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_ponto = null;
            id_pontostr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Placa = string.Empty;
            Cpf_cliente = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            dt_registro = null;
            dt_registrostr = string.Empty;
            dt_validade = null;
            dt_validadestr = string.Empty;
            Qt_pontos = decimal.Zero;
            Pontos_res = decimal.Zero;
            St_registro = string.Empty;
            MotivoCancelamento = string.Empty;
            LoginCanc = string.Empty;
            lPontosRes = new TList_ResgatePontos();
        }
    }

    public class TCD_PontosFidelidade : TDataQuery
    {
        public TCD_PontosFidelidade() { }

        public TCD_PontosFidelidade(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_ponto, a.cd_clifor, c.nm_clifor, a.nr_lanctofiscal, ");
                sql.AppendLine("a.id_cupom, a.placa, a.dt_registro, a.dt_validade, ");
                sql.AppendLine("a.cpf_cliente, a.qt_pontos, a.pontos_res, a.MotivoCancelamento, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM VTB_FAT_PontosFidelidade a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrWhiteSpace(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_PontosFidelidade Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_PontosFidelidade lista = new TList_PontosFidelidade();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_PontosFidelidade reg = new TRegistro_PontosFidelidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ponto")))
                        reg.Id_ponto = reader.GetDecimal(reader.GetOrdinal("id_ponto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_cliente")))
                        reg.Cpf_cliente = reader.GetString(reader.GetOrdinal("cpf_cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_registro")))
                        reg.Dt_registro = reader.GetDateTime(reader.GetOrdinal("dt_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("dt_validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontos")))
                        reg.Qt_pontos = reader.GetDecimal(reader.GetOrdinal("qt_pontos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pontos_res")))
                        reg.Pontos_res = reader.GetDecimal(reader.GetOrdinal("pontos_res"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCancelamento")))
                        reg.MotivoCancelamento = reader.GetString(reader.GetOrdinal("MotivoCancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_PontosFidelidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PONTO", val.Id_ponto);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_CPF_CLIENTE", val.Cpf_cliente);
            hs.Add("@P_DT_REGISTRO", val.Dt_registro);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);
            hs.Add("@P_QT_PONTOS", val.Qt_pontos);
            hs.Add("@P_MOTIVOCANCELAMENTO", val.MotivoCancelamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_PONTOSFIDELIDADE", hs);
        }

        public string Excluir(TRegistro_PontosFidelidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PONTO", val.Id_ponto);

            return executarProc("EXCLUI_FAT_PONTOSFIDELIDADE", hs);
        }
    }
    #endregion

    #region Resgate Pontos
    public class TList_ResgatePontos : List<TRegistro_ResgatePontos>, IComparer<TRegistro_ResgatePontos>
    {
        #region IComparer<TRegistro_ResgatePontos> Members
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

        public TList_ResgatePontos()
        { }

        public TList_ResgatePontos(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ResgatePontos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ResgatePontos x, TRegistro_ResgatePontos y)
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

    public class TRegistro_ResgatePontos
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_ponto;
        public decimal? Id_ponto
        {
            get { return id_ponto; }
            set
            {
                id_ponto = value;
                id_pontostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pontostr;
        public string Id_pontostr
        {
            get { return id_pontostr; }
            set
            {
                id_pontostr = value;
                try
                {
                    id_ponto = decimal.Parse(value);
                }
                catch { id_ponto = null; }
            }
        }
        private decimal? id_resgate;
        public decimal? Id_resgate
        {
            get { return id_resgate; }
            set
            {
                id_resgate = value;
                id_resgatestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_resgatestr;
        public string Id_resgatestr
        {
            get { return id_resgatestr; }
            set
            {
                id_resgatestr = value;
                try
                {
                    id_resgate = decimal.Parse(value);
                }
                catch { id_resgate = null; }
            }
        }
        public string Login
        { get; set; }
        public string Logincanc
        { get; set; }
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch { id_lancto = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch { id_cupom = null; }
            }
        }
        private decimal? id_vale;
        public decimal? Id_vale
        {
            get { return id_vale; }
            set
            {
                id_vale = value;
                id_valestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_valestr;
        public string Id_valestr
        {
            get { return id_valestr; }
            set
            {
                id_valestr = value;
                try
                {
                    id_vale = decimal.Parse(value);
                }
                catch { id_vale = null; }
            }
        }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch { id_prevenda = null; }
            }
        }
        private decimal? id_itemprevenda;
        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;
        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = decimal.Parse(value);
                }
                catch { id_itemprevenda = null; }
            }
        }
        public decimal Qt_pontos
        { get; set; }
        private DateTime? dt_resgate;
        public DateTime? Dt_resgate
        {
            get { return dt_resgate; }
            set
            {
                dt_resgate = value;
                dt_resgatestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_resgatestr;
        public string Dt_resgatestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_resgatestr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_resgatestr = value;
                try
                {
                    dt_resgate = DateTime.Parse(value);

                }
                catch { dt_resgate = null; }
            }
        }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }

        public TRegistro_ResgatePontos()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_ponto = null;
            id_pontostr = string.Empty;
            id_resgate = null;
            id_resgatestr = string.Empty;
            Login = string.Empty;
            Logincanc = string.Empty;
            id_lancto = null;
            id_lanctostr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            id_vale = null;
            id_valestr = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
            Qt_pontos = decimal.Zero;
            dt_resgate = null;
            dt_resgatestr = string.Empty;
            St_registro = "A";
        }
    }

    public class TCD_ResgatePontos : TDataQuery
    {
        public TCD_ResgatePontos() { }

        public TCD_ResgatePontos(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_empresa, b.nm_empresa, a.id_vale, ");
                sql.AppendLine("a.id_ponto, a.id_resgate, a.login, a.id_lancto, ");
                sql.AppendLine("a.id_prevenda, a.id_itemprevenda, ");
                sql.AppendLine("a.id_cupom, a.qt_pontos, a.dt_resgate, a.logincanc, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAT_ResgatePontos a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ResgatePontos Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ResgatePontos lista = new TList_ResgatePontos();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ResgatePontos reg = new TRegistro_ResgatePontos();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ponto")))
                        reg.Id_ponto = reader.GetDecimal(reader.GetOrdinal("id_ponto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_resgate")))
                        reg.Id_resgate = reader.GetDecimal(reader.GetOrdinal("id_resgate"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logincanc")))
                        reg.Logincanc = reader.GetString(reader.GetOrdinal("logincanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vale")))
                        reg.Id_vale = reader.GetDecimal(reader.GetOrdinal("id_vale"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontos")))
                        reg.Qt_pontos = reader.GetDecimal(reader.GetOrdinal("qt_pontos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_resgate")))
                        reg.Dt_resgate = reader.GetDateTime(reader.GetOrdinal("dt_resgate"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_ResgatePontos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PONTO", val.Id_ponto);
            hs.Add("@P_ID_RESGATE", val.Id_resgate);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_LOGINCANC", val.Logincanc);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_VALE", val.Id_vale);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_QT_PONTOS", val.Qt_pontos);
            hs.Add("@P_DT_RESGATE", val.Dt_resgate);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_RESGATEPONTOS", hs);
        }
        
        public string Excluir(TRegistro_ResgatePontos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PONTO", val.Id_ponto);
            hs.Add("@P_ID_RESGATE", val.Id_resgate);

            return executarProc("EXCLUI_FAT_RESGATEPONTOS", hs);
        }
    }
    #endregion

    #region Vale Resgate
    public class TList_ValeResgate : List<TRegistro_ValeResgate>
    { }

    public class TRegistro_ValeResgate
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_vale;
        public decimal? Id_vale
        {
            get { return id_vale; }
            set
            {
                id_vale = value;
                id_valestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_valestr;
        public string Id_valestr
        {
            get { return id_valestr; }
            set
            {
                id_valestr = value;
                try
                {
                    id_vale = decimal.Parse(value);
                }
                catch { id_vale = null; }
            }
        }
        public string Loginautoriza
        { get; set; }
        public string St_impresso
        { get; set; }
        public bool St_impressobool
        { get { return St_impresso.Trim().ToUpper().Equals("S"); } }
        public DateTime? Dt_vale
        { get; set; }
        public string Login
        { get; set; }
        public string Logincanc
        { get; set; }
        public string Placa
        { get; set; }
        public string St_registro
        { get; set; }
        public string Cd_clifor { get; set; } = string.Empty;
        public string Nm_clifor { get; set; } = string.Empty;
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public TList_ResgatePontos lResgate
        { get; set; }

        public TRegistro_ValeResgate()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_vale = null;
            id_valestr = string.Empty;
            Loginautoriza = string.Empty;
            St_impresso = string.Empty;
            Dt_vale = null;
            Login = string.Empty;
            Logincanc = string.Empty;
            St_registro = "A";
            Placa = string.Empty;
            lResgate = new TList_ResgatePontos();
        }
    }

    public class TCD_ValeResgate : TDataQuery
    {
        public TCD_ValeResgate() { }

        public TCD_ValeResgate(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_vale, a.st_impresso, a.dt_cad, ");
                sql.AppendLine("a.loginautoriza, a.st_registro, ");
                sql.AppendLine("a.login, a.placa, a.logincanc, a.cd_clifor, c.nm_clifor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM VTB_FAT_ValeResgate a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_CLIFOR c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ValeResgate Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ValeResgate lista = new TList_ValeResgate();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ValeResgate reg = new TRegistro_ValeResgate();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vale")))
                        reg.Id_vale = reader.GetDecimal(reader.GetOrdinal("id_vale"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginautoriza")))
                        reg.Loginautoriza = reader.GetString(reader.GetOrdinal("loginautoriza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logincanc")))
                        reg.Logincanc = reader.GetString(reader.GetOrdinal("logincanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_impresso")))
                        reg.St_impresso = reader.GetString(reader.GetOrdinal("st_impresso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cad")))
                        reg.Dt_vale = reader.GetDateTime(reader.GetOrdinal("dt_cad"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));

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

        public string Gravar(TRegistro_ValeResgate val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VALE", val.Id_vale);
            hs.Add("@P_LOGINAUTORIZA", val.Loginautoriza);
            hs.Add("@P_ST_IMPRESSO", val.St_impresso);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_VALERESGATE", hs);
        }

        public string Excluir(TRegistro_ValeResgate val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VALE", val.Id_vale);

            return executarProc("EXCLUI_FAT_VALERESGATE", hs);
        }
    }
    #endregion
}
