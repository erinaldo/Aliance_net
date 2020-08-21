using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_LanctoImposto : List<TRegistro_LanctoImposto>
    { }

    
    public class TRegistro_LanctoImposto
    {
        
        public decimal? Id_lancto
        { get; set; }
        private decimal? cd_imposto;
        
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = Convert.ToDecimal(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        
        public string Ds_imposto
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Id_lotefis
        { get; set; }
        
        public string Cd_ajuste
        { get; set; }
        
        public string Ds_ajuste
        { get; set; }
        
        public string Cd_ajusteIPI
        { get; set; }
        
        public string Ds_ajusteIPI
        { get; set; }
        
        public string Tp_origemIPI
        { get; set; }
        public string Tipo_origemIPI
        {
            get
            {
                if (Tp_origemIPI.Trim().Equals("0"))
                    return "PROCESSO JUDICIAL";
                else if (Tp_origemIPI.Trim().Equals("1"))
                    return "PROCESSO ADMINISTRATIVO";
                else if (Tp_origemIPI.Trim().Equals("2"))
                    return "PER/DCOMP";
                else if (Tp_origemIPI.Trim().Equals("9"))
                    return "OUTROS";
                else return string.Empty;
            }
        }
        
        public string Nr_docajusteIPI
        { get; set; }
        private string d_c;
        
        public string D_c
        {
            get { return d_c; }
            set
            {
                d_c = value;
                if (value.Trim().ToUpper().Equals("D"))
                    debito_credito = "DEBITO";
                else if (value.Trim().ToUpper().Equals("C"))
                    debito_credito = "CREDITO";
            }
        }
        private string debito_credito;
        
        public string Debito_credito
        {
            get { return debito_credito; }
            set
            {
                debito_credito = value;
                if (value.Trim().ToUpper().Equals("DEBITO"))
                    d_c = "D";
                else if (value.Trim().ToUpper().Equals("CREDITO"))
                    d_c = "C";
            }
        }
        private DateTime? dt_lancto;
        
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        
        public decimal Vl_lancto
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public string Tp_lancto
        { get; set; }
        public string Tipo_lancto
        {
            get
            {
                if (Tp_lancto.Trim().Equals("0"))
                    return "OUTROS DEBITOS";
                else if (Tp_lancto.Trim().Equals("1"))
                    return "ESTORNO CREDITOS";
                else if (Tp_lancto.Trim().ToUpper().Equals("2"))
                    return "OUTROS CREDITOS";
                else if (Tp_lancto.Trim().Equals("3"))
                    return "ESTORNO DEBITOS";
                else if (Tp_lancto.Trim().Equals("4"))
                    return "DEDUÇÕES IMPOSTO APURADO";
                else if (Tp_lancto.Trim().Equals("5"))
                    return "DEBITOS ESPECIAIS";
                else return string.Empty;
            }
        }
        
        public TList_AjusteImposto lAjusteImposto
        { get; set; }

        public TRegistro_LanctoImposto()
        {
            this.Id_lancto = null;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_lotefis = null;
            this.Cd_ajuste = string.Empty;
            this.Ds_ajuste = string.Empty;
            this.Cd_ajusteIPI = string.Empty;
            this.Ds_ajusteIPI = string.Empty;
            this.Tp_origemIPI = string.Empty;
            this.Nr_docajusteIPI = string.Empty;
            this.d_c = "D";
            this.debito_credito = "DEBITO";
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Vl_lancto = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.Tp_lancto = string.Empty;
            this.lAjusteImposto = new TList_AjusteImposto();
        }
    }

    public class TCD_LanctoImposto : TDataQuery
    {
        public TCD_LanctoImposto()
        { }

        public TCD_LanctoImposto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty; 
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Lancto, a.CD_Imposto, b.DS_Imposto, ");
                sql.AppendLine("a.CD_Empresa, c.NM_Empresa, a.ID_LoteFIS, a.tp_lancto, ");
                sql.AppendLine("a.D_C, a.DT_Lancto, a.Vl_Lancto, a.DS_Observacao, ");
                sql.AppendLine("a.cd_ajuste, d.ds_ajuste, a.cd_ajusteIPI, e.ds_ajusteIPI, ");
                sql.AppendLine("a.tp_origemIPI, a.nr_docajusteIPI ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIS_LanctoImposto a ");
            sql.AppendLine("inner join TB_FIS_Imposto b ");
            sql.AppendLine("on a.CD_Imposto = b.CD_Imposto ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIS_AjusteICMS d ");
            sql.AppendLine("on a.cd_ajuste = d.cd_ajuste ");
            sql.AppendLine("left outer join TB_FIS_AjusteIPI e ");
            sql.AppendLine("on a.cd_ajusteIPI = e.cd_ajusteIPI ");
            
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

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

        public TList_LanctoImposto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanctoImposto lista = new TList_LanctoImposto();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanctoImposto reg = new TRegistro_LanctoImposto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotefis")))
                        reg.Id_lotefis = reader.GetDecimal(reader.GetOrdinal("id_lotefis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("d_c")))
                        reg.D_c = reader.GetString(reader.GetOrdinal("d_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_lancto")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("vl_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_lancto")))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("tp_lancto"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_ajuste")))
                        reg.Cd_ajuste = reader.GetString(reader.GetOrdinal("cd_ajuste"));
                    if(!reader.IsDBNull(reader.GetOrdinal("ds_ajuste")))
                        reg.Ds_ajuste = reader.GetString(reader.GetOrdinal("ds_ajuste"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ajusteIPI")))
                        reg.Cd_ajusteIPI = reader.GetString(reader.GetOrdinal("cd_ajusteIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ajusteIPI")))
                        reg.Ds_ajusteIPI = reader.GetString(reader.GetOrdinal("ds_ajusteIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_origemIPI")))
                        reg.Tp_origemIPI = reader.GetString(reader.GetOrdinal("tp_origemIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docajusteIPI")))
                        reg.Nr_docajusteIPI = reader.GetString(reader.GetOrdinal("nr_docajusteIPI"));

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

        public string Gravar(TRegistro_LanctoImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);
            hs.Add("@P_CD_AJUSTE", val.Cd_ajuste);
            hs.Add("@P_CD_AJUSTEIPI", val.Cd_ajusteIPI);
            hs.Add("@P_D_C", val.D_c);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_VL_LANCTO", val.Vl_lancto);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_TP_LANCTO", val.Tp_lancto);
            hs.Add("@P_TP_ORIGEMIPI", val.Tp_origemIPI);
            hs.Add("@P_NR_DOCAJUSTEIPI", val.Nr_docajusteIPI);

            return this.executarProc("IA_FIS_LANCTOIMPOSTO", hs);
        }

        public string Excluir(TRegistro_LanctoImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return this.executarProc("EXCLUI_FIS_LANCTOIMPOSTO", hs);
        }
    }
}
