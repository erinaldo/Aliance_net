using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    #region Lote Fiscal

    public class TList_LoteImposto : List<TRegistro_LoteImposto>
    {}

    
    public class TRegistro_LoteImposto
    {
        
        public decimal? Id_lotefis
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
        
        public string Ds_observacao
        { get; set; }
        
        public decimal Vl_credito
        { get; set; }
        
        public decimal Vl_debito
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

        public TRegistro_LoteImposto()
        {
            this.Id_lotefis = null;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.dt_lote = null;
            this.dt_lotestr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.Vl_credito = decimal.Zero;
            this.Vl_debito = decimal.Zero;
            this.st_registro = "A";
            this.status = "ABERTO";
        }
    }

    public class TCD_LoteImposto : TDataQuery
    {
        public TCD_LoteImposto()
        { }

        public TCD_LoteImposto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = " "; string cond = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.ID_LoteFIS, a.CD_Imposto, ");
                sql.AppendLine("b.DS_Imposto, a.CD_Empresa, c.NM_Empresa, ");
                sql.AppendLine("a.DT_Lote, a.DS_Observacao, ");
                sql.AppendLine("a.Vl_Credito, a.Vl_Debito, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIS_LoteImposto a ");
            sql.AppendLine("inner join TB_FIS_Imposto b ");
            sql.AppendLine("on a.CD_Imposto = b.CD_Imposto ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_LoteImposto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_LoteImposto lista = new TList_LoteImposto();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteImposto reg = new TRegistro_LoteImposto();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteFIS")))
                        reg.Id_lotefis = reader.GetDecimal(reader.GetOrdinal("ID_LoteFIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lote")))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Credito")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("Vl_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Debito")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("Vl_Debito"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_LoteImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_VL_CREDITO", val.Vl_credito);
            hs.Add("@P_VL_DEBITO", val.Vl_debito);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIS_LOTEIMPOSTO", hs);
        }

        public string Excluir(TRegistro_LoteImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);

            return this.executarProc("EXCLUI_FIS_LOTEIMPOSTO", hs);
        }
    }

    #endregion

    #region Lote Fiscal X Duplicata

    public class TList_Lote_X_Duplicata:List<TRegistro_Lote_X_Duplicata>
    {}

    
    public class TRegistro_Lote_X_Duplicata
    {
        
        public decimal? Id_lotefis
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lancto
        { get; set; }

        public TRegistro_Lote_X_Duplicata()
        {
            this.Id_lotefis = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = null;
        }
    }

    public class TCD_Lote_X_Duplicata:TDataQuery
    {
        public TCD_Lote_X_Duplicata()
        { }

        public TCD_Lote_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = " "; string cond = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.ID_LoteFIS, a.CD_Empresa, a.NR_Lancto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIS_Lote_X_Duplicata a ");
            cond = " and ";

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

        public TList_Lote_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lote_X_Duplicata lista = new TList_Lote_X_Duplicata();
            System.Data.SqlClient.SqlDataReader reader;
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
                    TRegistro_Lote_X_Duplicata reg = new TRegistro_Lote_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteFIS")))
                        reg.Id_lotefis = reader.GetDecimal(reader.GetOrdinal("ID_LoteFIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));

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

        public string Gravar(TRegistro_Lote_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_FIS_LOTE_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Lote_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_FIS_LOTE_X_DUPLICATA", hs);
        }
    }

    #endregion
}
