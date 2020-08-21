using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Locacao
{
    #region Retirada
    public class TList_Retirada : List<TRegistro_Retirada>, IComparer<TRegistro_Retirada>
    {

        #region IComparer<TRegistro_Retirada> Members
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

        public TList_Retirada()
        { }

        public TList_Retirada(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Retirada value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Retirada x, TRegistro_Retirada y)
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


    public class TRegistro_Retirada
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_retirada;

        public decimal? Id_retirada
        {
            get { return id_retirada; }
            set
            {
                id_retirada = value;
                id_retiradastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_retiradastr;

        public string Id_retiradastr
        {
            get { return id_retiradastr; }
            set
            {
                id_retiradastr = value;
                try
                {
                    id_retirada = Convert.ToDecimal(value);
                }
                catch
                { id_retirada = null; }
            }
        }
        public string Cd_funcionario
        { get; set; }
        public string Nm_funcionario
        { get; set; }
        public string Login
        { get; set; }
        public string Cd_contager { get; set; }
        public string Ds_contager { get; set; }
        private decimal? cd_lanctocaixa;
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }catch { cd_lanctocaixa = null; }
            }
        }

        private DateTime? dt_Retirada;

        public DateTime? Dt_Retirada
        {
            get { return dt_Retirada; }
            set
            {
                dt_Retirada = value;
                dt_Retiradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_Retiradastr;
        public string Dt_Retiradastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_Retiradastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_Retiradastr = value;
                try
                {
                    dt_Retirada = Convert.ToDateTime(value);
                }
                catch
                { dt_Retirada = null; }
            }
        }
        public decimal Vl_retirada { get; set; }
        public decimal Vl_abastecidas { get; set; } = decimal.Zero;
        public decimal Vl_medidas { get; set; } = decimal.Zero;
        public string Obs
        { get; set; }

        public TRegistro_Retirada()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_retirada = null;
            id_retiradastr = string.Empty;
            Cd_funcionario = string.Empty;
            Nm_funcionario = string.Empty;
            Login = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            dt_Retirada = null;
            dt_Retiradastr = string.Empty;
            Vl_retirada = decimal.Zero;
            Obs = string.Empty;
        }
    }

    public class TCD_Retirada : TDataQuery
    {
        public TCD_Retirada()
        { }

        public TCD_Retirada(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.nm_empresa, a.ID_retirada, ");
                sql.AppendLine("a.cd_funcionario, c.nm_clifor, a.Login, a.DT_Retirada, a.Obs, ");
                sql.AppendLine("a.cd_contager, d.ds_contager, a.cd_lanctocaixa, a.Vl_Retirada, ");
                sql.AppendLine("a.vl_abastecidas, a.vl_medidas ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_Retirada a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on c.cd_clifor = a.cd_funcionario ");
            sql.AppendLine("left outer join TB_FIN_Contager d ");
            sql.AppendLine("on a.cd_contager = d.cd_contager ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrWhiteSpace(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
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

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_Retirada Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Retirada lista = new TList_Retirada();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_Retirada reg = new TRegistro_Retirada();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_retirada")))
                        reg.Id_retirada = reader.GetDecimal(reader.GetOrdinal("id_retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("Cd_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Retirada")))
                        reg.Dt_Retirada = reader.GetDateTime(reader.GetOrdinal("DT_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Retirada")))
                        reg.Vl_retirada = reader.GetDecimal(reader.GetOrdinal("Vl_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_abastecidas")))
                        reg.Vl_abastecidas = reader.GetDecimal(reader.GetOrdinal("vl_abastecidas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_medidas")))
                        reg.Vl_medidas = reader.GetDecimal(reader.GetOrdinal("vl_medidas"));
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

        public string Gravar(TRegistro_Retirada val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_DT_RETIRADA", val.Dt_Retirada);
            hs.Add("@P_VL_ABASTECIDAS", val.Vl_abastecidas);
            hs.Add("@P_VL_MEDIDAS", val.Vl_medidas);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_LOC_RETIRADA", hs);
        }

        public string Excluir(TRegistro_Retirada val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);

            return executarProc("EXCLUI_LOC_RETIRADA", hs);
        }
    }
    #endregion
}
