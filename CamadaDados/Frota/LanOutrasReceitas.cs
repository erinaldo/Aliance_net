using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region Outras Receitas
    public class TList_OutrasReceitas : List<TRegistro_OutrasReceitas>, IComparer<TRegistro_OutrasReceitas>
    {
        #region IComparer<TRegistro_OutrasReceitas> Members
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

        public TList_OutrasReceitas()
        { }

        public TList_OutrasReceitas(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OutrasReceitas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OutrasReceitas x, TRegistro_OutrasReceitas y)
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


    public class TRegistro_OutrasReceitas
    {
        private decimal? id_receita;

        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;

        public string Id_receitastr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch
                { id_receita = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_veiculo;

        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;

        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch
                { id_veiculo = null; }
            }
        }

        public string Ds_veiculo
        { get; set; }
        public string Cd_motorista
        { get; set; }

        public string Nm_motorista
        { get; set; }
       private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);

                }
                catch { nr_lancto = null; }
            }
        }
        private DateTime? dt_receita;

        public DateTime? Dt_receita
        {
            get { return dt_receita; }
            set
            {
                dt_receita = value;
                dt_receitastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_receitastr;
        public string Dt_receitastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_receitastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_receitastr = value;
                try
                {
                    dt_receita = DateTime.Parse(value);
                }
                catch
                { dt_receita = null; }
            }
        }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = Convert.ToDecimal(value);
                }
                catch
                { id_viagem = null; }
            }
        }

        public decimal Vl_receita
        { get; set; }

        public decimal Vl_comissao
        { get; set; }

        public decimal Vl_adtoViagem
        { get; set; }
        public TimeSpan HR_IniServico
        { get; set; }
        public TimeSpan HR_FinServico
        { get; set; }
        public decimal Vl_devadtoViagem
        { get; set; }
        public decimal Sd_devadtoViagem
        { get { return Vl_adtoViagem - Vl_devadtoViagem; } }

        public string Ds_observacao
        { get; set; }

        public bool St_processar
        { get; set; }


        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }

        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }

        public TRegistro_OutrasReceitas()
        {
            id_receita = null;
            id_receitastr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            id_veiculo = null;
            id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Cd_motorista = string.Empty;
            Nm_motorista = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            dt_receita = null;
            dt_receitastr = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Vl_receita = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Ds_observacao = string.Empty;
            St_processar = false;
            Vl_adtoViagem = decimal.Zero;
            HR_IniServico = new TimeSpan();
            HR_FinServico = new TimeSpan();
            Vl_devadtoViagem = decimal.Zero;

            rDup = null;
            lDup = new Financeiro.Duplicata.TList_RegLanDuplicata();
        }
    }

    public class TCD_OutrasReceitas: TDataQuery
    {
        public TCD_OutrasReceitas()
        { }

        public TCD_OutrasReceitas(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Receita, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.cd_clifor, e.nm_clifor, a.Id_Veiculo, c.ds_veiculo, a.DT_Receita, ");
                sql.AppendLine("a.CD_Motorista, d.NM_Clifor as NM_Motorista, a.NR_Lancto, a.id_viagem, a.HR_IniServico, a.HR_FinServico, ");
                sql.AppendLine("a.Vl_Receita, a.DS_Observacao, isnull(a.vl_adtoViagem, 0) as vl_adtoViagem, a.vl_devadtoviagem, a.vl_comissao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FRT_OutrasReceitas a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FRT_Veiculo c ");
            sql.AppendLine("on a.Id_Veiculo = c.Id_Veiculo ");
            sql.AppendLine("inner join TB_FIN_Clifor d ");
            sql.AppendLine("on a.CD_Motorista = d.CD_Clifor ");
            sql.AppendLine("left outer join TB_FIN_Clifor e ");
            sql.AppendLine("on a.cd_clifor = e.CD_Clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_OutrasReceitas Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OutrasReceitas lista = new TList_OutrasReceitas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OutrasReceitas reg = new TRegistro_OutrasReceitas();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("ID_Receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Receita")))
                        reg.Dt_receita = reader.GetDateTime(reader.GetOrdinal("DT_Receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Receita")))
                        reg.Vl_receita = reader.GetDecimal(reader.GetOrdinal("Vl_Receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("Vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_adtoViagem")))
                        reg.Vl_adtoViagem = reader.GetDecimal(reader.GetOrdinal("Vl_adtoViagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HR_IniServico")))
                        reg.HR_IniServico = reader.GetTimeSpan(reader.GetOrdinal("HR_IniServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HR_FinServico")))
                        reg.HR_FinServico = reader.GetTimeSpan(reader.GetOrdinal("HR_FinServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devadtoviagem")))
                        reg.Vl_devadtoViagem = reader.GetDecimal(reader.GetOrdinal("vl_devadtoviagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));

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

        public string Gravar(TRegistro_OutrasReceitas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_DT_RECEITA", val.Dt_receita);
            hs.Add("@P_VL_RECEITA", val.Vl_receita);
            hs.Add("@P_VL_ADTOVIAGEM", val.Vl_adtoViagem);
            hs.Add("@P_HR_INISERVICO", val.HR_IniServico);
            hs.Add("@P_HR_FINSERVICO", val.HR_FinServico);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_FRT_OUTRASRECEITAS", hs);
        }

        public string Excluir(TRegistro_OutrasReceitas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_RECEITA", val.Id_receita);

            return executarProc("EXCLUI_FRT_OUTRASRECEITAS", hs);
        }
    }
    #endregion
}
