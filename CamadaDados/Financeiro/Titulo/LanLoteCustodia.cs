using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Titulo
{
    #region Lote Custodia
    public class TList_LoteCustodia : List<TRegistro_LoteCustodia>
    { }

    
    public class TRegistro_LoteCustodia
    {
        
        public decimal? Id_lote
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public string Ds_banco
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
        
        public string Nr_lote
        { get; set; }
        private DateTime? dt_enviolote;
        
        public DateTime? Dt_enviolote
        {
            get { return dt_enviolote; }
            set
            {
                dt_enviolote = value;
                dt_enviolotestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_enviolotestr;
        public string Dt_enviolotestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_enviolotestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_enviolotestr = value;
                try
                {
                    dt_enviolote = Convert.ToDateTime(value);
                }
                catch
                { dt_enviolote = null; }
            }
        }
        
        public string Ds_lote
        { get; set; }
        private string tp_registro;
        
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("C"))
                    tipo_registro = "CUSTODIA";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_registro = "DEPOSITO";
            }
        }
        private string tipo_registro;
        
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("CUSTODIA"))
                    tp_registro = "C";
                else if (value.Trim().ToUpper().Equals("DEPOSITO"))
                    tp_registro = "D";
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
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENVIADO";
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
                else if (value.Trim().ToUpper().Equals("ENVIADO"))
                    st_registro = "E";
            }
        }
        
        public TList_RegLanTitulo lChCustodia
        { get; set; }
        
        public TList_RegLanTitulo lChCustodiaDel
        { get; set; }

        public TRegistro_LoteCustodia()
        {
            this.Id_lote = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.dt_lote = DateTime.Now;
            this.dt_lotestr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Nr_lote = string.Empty;
            this.dt_enviolote = null;
            this.dt_enviolotestr = string.Empty;
            this.Ds_lote = string.Empty;
            this.tp_registro = string.Empty;
            this.tipo_registro = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.lChCustodia = new TList_RegLanTitulo();
            this.lChCustodiaDel = new TList_RegLanTitulo();
        }
    }

    public class TCD_LoteCustodia : TDataQuery
    {
        public TCD_LoteCustodia()
        { }

        public TCD_LoteCustodia(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.ID_Lote, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_ContaGer, c.DS_ContaGer, a.DT_Lote, ");
                sql.AppendLine("a.DT_EnvioLote, a.DS_Lote, a.NR_Lote, a.TP_Registro, ");
                sql.AppendLine("a.ST_Registro, c.CD_Banco, d.DS_Banco ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_LoteCH_Custodia a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_ContaGer c ");
            sql.AppendLine("on a.CD_ContaGer = c.CD_ContaGer ");
            sql.AppendLine("left outer join TB_FIN_Banco d ");
            sql.AppendLine("on c.CD_Banco = d.CD_Banco ");

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

        public TList_LoteCustodia Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteCustodia lista = new TList_LoteCustodia();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteCustodia reg = new TRegistro_LoteCustodia();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Lote"))))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lote"))))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("NR_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EnvioLote")))
                        reg.Dt_enviolote = reader.GetDateTime(reader.GetOrdinal("DT_EnvioLote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    
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

        public string Gravar(TRegistro_LoteCustodia val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_NR_LOTE", val.Nr_lote);
            hs.Add("@P_DT_ENVIOLOTE", val.Dt_enviolote);
            hs.Add("@P_DS_LOTE", val.Ds_lote);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_LOTECH_CUSTODIA", hs);
        }

        public string Excluir(TRegistro_LoteCustodia val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_FIN_LOTECH_CUSTODIA", hs);
        }
    }
    #endregion

    #region Lote Custodia X Titulo
    
    public class TList_LoteCustodia_X_Titulo : List<TRegistro_LoteCustodia_X_Titulo>
    { }

    public class TRegistro_LoteCustodia_X_Titulo
    {
        
        public decimal? Id_lote
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public decimal? Nr_lanctocheque
        { get; set; }
        
        public TRegistro_LoteCustodia_X_Titulo()
        {
            this.Id_lote = null;
            this.Cd_empresa = string.Empty;
            this.Cd_banco = string.Empty;
            this.Nr_lanctocheque = null;
        }
    }

    public class TCD_LoteCustodia_X_Titulo : TDataQuery
    {
        public TCD_LoteCustodia_X_Titulo()
        { }

        public TCD_LoteCustodia_X_Titulo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_lote, a.cd_empresa, ");
                sql.AppendLine("a.nr_lanctocheque, a.cd_banco ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Titulo_X_LoteCustodia a ");
            sql.AppendLine("inner join tb_fin_lotech_custodia b ");
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

        public TList_LoteCustodia_X_Titulo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteCustodia_X_Titulo lista = new TList_LoteCustodia_X_Titulo();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteCustodia_X_Titulo reg = new TRegistro_LoteCustodia_X_Titulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));

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

        public string Gravar(TRegistro_LoteCustodia_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("IA_FIN_TITULO_X_LOTECUSTODIA", hs);
        }

        public string Excluir(TRegistro_LoteCustodia_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FIN_TITULO_X_LOTECUSTODIA", hs);
        }
    }
    #endregion
}
