using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Titulo
{
    #region "Lote Cheque"
    public class TList_LoteCH : List<TRegistro_LoteCH>
    { }

    
    public class TRegistro_LoteCH
    {
        
        public decimal Id_lote
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }
        
        public decimal? Cd_lanctocaixa
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
        
        public string Ds_lote
        { get; set; }
        private DateTime? dt_processamento;
        
        public DateTime? Dt_processamento
        {
            get { return dt_processamento; }
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
        private DateTime? dt_enviolote;
        
        public DateTime? Dt_enviolote
        {
            get { return dt_enviolote; }
            set
            {
                dt_enviolote = value;
                dt_enviolotestr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
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
                else if (value.Trim().ToUpper().Equals("ENVIADO"))
                    st_registro = "E";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        
        public decimal Vl_credito
        { get; set; }
        
        public decimal Vl_taxa
        { get; set; }
        
        public TList_RegLanTitulo lCheques
        { get; set; }
        
        public TList_RegLanTitulo lChequesesc
        { get; set; }

        public TRegistro_LoteCH()
        {
            this.Id_lote = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Cd_lanctocaixa = null;
            this.dt_lote = DateTime.Now;
            this.dt_lotestr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_processamento = null;
            this.dt_processamentostr = string.Empty;
            this.dt_enviolote = null;
            this.dt_enviolotestr = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";

            this.Vl_credito = decimal.Zero;
            this.Vl_taxa = decimal.Zero;
            this.lCheques = new TList_RegLanTitulo();
            this.lChequesesc = new TList_RegLanTitulo();
        }
    }

    public class TCD_LoteCH : TDataQuery
    {
        public TCD_LoteCH()
        { }

        public TCD_LoteCH(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_lote, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cd_contager, c.ds_contager, a.cd_lanctocaixa, a.dt_lote, ");
                sql.AppendLine("a.ds_lote, a.dt_processamento, a.dt_enviolote, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_lotech a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_contager c ");
            sql.AppendLine("on a.cd_contager = c.cd_contager ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LoteCH Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteCH lista = new TList_LoteCH();
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
                    TRegistro_LoteCH reg = new TRegistro_LoteCH();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Lote"))))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lote"))))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EnvioLote")))
                        reg.Dt_enviolote = reader.GetDateTime(reader.GetOrdinal("DT_EnvioLote"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));

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

        public string GravarLoteCH(TRegistro_LoteCH val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_DS_LOTE", val.Ds_lote);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_processamento);
            hs.Add("@P_DT_ENVIOLOTE", val.Dt_enviolote);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_LOTECH", hs);
        }

        public string DeletarLoteCH(TRegistro_LoteCH val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_FIN_LOTECH", hs);
        }
    }
    #endregion

    #region "Lote X Cheque"
    public class TList_LoteCH_X_Titulo : List<TRegistro_LoteCH_X_Titulo>
    { }
    
    public class TRegistro_LoteCH_X_Titulo
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lanctocheque
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public decimal? Id_lote
        { get; set; }
        
        public decimal Vl_taxa
        { get; set; }

        public TRegistro_LoteCH_X_Titulo()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_lanctocheque = null;
            this.Cd_banco = string.Empty;
            this.Id_lote = null;
            this.Vl_taxa = decimal.Zero;
        }
    }

    public class TCD_LoteCH_X_Titulo : TDataQuery
    {
        public TCD_LoteCH_X_Titulo()
        { }

        public TCD_LoteCH_X_Titulo(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctocheque, ");
                sql.AppendLine("a.cd_banco, a.id_lote, a.vl_taxa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_lotech_x_titulo a ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LoteCH_X_Titulo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteCH_X_Titulo lista = new TList_LoteCH_X_Titulo();
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
                    TRegistro_LoteCH_X_Titulo reg = new TRegistro_LoteCH_X_Titulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lote"))))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Taxa"))))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));

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

        public string GravarLoteCH_X_Titulo(TRegistro_LoteCH_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);

            return this.executarProc("IA_FIN_LOTECH_X_TITULO", hs);
        }

        public string DeletarLoteCH_X_Titulo(TRegistro_LoteCH_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FIN_LOTECH_X_TITULO", hs);
        }
    }
    #endregion

    #region "Lote Cheque X Caixa"
    public class TList_LoteCH_X_Caixa : List<TRegistro_LoteCH_X_Caixa>
    { }
    
    public class TRegistro_LoteCH_X_Caixa
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lanctocheque
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public decimal? Cd_lanctocaixa
        { get; set; }

        public TRegistro_LoteCH_X_Caixa()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_lanctocheque = null;
            this.Cd_banco = string.Empty;
            this.Cd_contager = string.Empty;
            this.Cd_lanctocaixa = null;
        }
    }

    public class TCD_LoteCH_X_Caixa : TDataQuery
    {
        public TCD_LoteCH_X_Caixa()
        { }

        public TCD_LoteCH_X_Caixa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctocheque, ");
                sql.AppendLine("a.cd_banco, a.cd_contager, a.cd_lanctocaixa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_lotech_x_caixa a ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LoteCH_X_Caixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LoteCH_X_Caixa lista = new TList_LoteCH_X_Caixa();
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
                    TRegistro_LoteCH_X_Caixa reg = new TRegistro_LoteCH_X_Caixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_contager"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("Cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));

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

        public string GravarLoteCH_X_Caixa(TRegistro_LoteCH_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("IA_FIN_LOTECH_X_CAIXA", hs);
        }

        public string DeletarLoteCH_X_Caixa(TRegistro_LoteCH_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("EXCLUI_FIN_LOTECH_X_CAIXA", hs);
        }
    }
    #endregion
}
