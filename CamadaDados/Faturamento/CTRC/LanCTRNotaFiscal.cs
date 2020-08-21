using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_CTRNotaFiscal : List<TRegistro_CTRNotaFiscal>
    { }
    
    public class TRegistro_CTRNotaFiscal
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_nota;
        public decimal? Id_nota
        {
            get { return id_nota; }
            set
            {
                id_nota = value;
                id_notastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_notastr;
        public string Id_notastr
        {
            get { return id_notastr; }
            set
            {
                id_notastr = value;
                try
                {
                    id_nota = decimal.Parse(value);
                }
                catch { id_nota = null; }
            }
        }
        private decimal? nr_lanctoctr;
        public decimal? Nr_lanctoctr
        {
            get { return nr_lanctoctr; }
            set
            {
                nr_lanctoctr = value;
                nr_lanctoctrstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoctrstr;
        public string Nr_lanctoctrstr
        {
            get { return nr_lanctoctrstr; }
            set
            {
                nr_lanctoctrstr = value;
                try
                {
                    nr_lanctoctr = decimal.Parse(value);
                }
                catch { nr_lanctoctr = null; }
            }
        }
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
        public string Chave_acesso_nfe
        { get; set; }
        private string tp_documento;
        public string Tp_documento
        {
            get { return tp_documento; }
            set
            {
                tp_documento = value;
                if (value.Trim().Equals("00"))
                    tipo_documento = "DECLARAÇÃO";
                else if (value.Trim().Equals("10"))
                    tipo_documento = "DUTOVIARIO";
                else if (value.Trim().Equals("99"))
                    tipo_documento = "OUTROS";
            }
        }
        private string tipo_documento;
        public string Tipo_documento
        {
            get { return tipo_documento; }
            set
            {
                tipo_documento = value;
                if (value.Trim().ToUpper().Equals("DECLARAÇÃO"))
                    tp_documento = "00";
                else if (value.Trim().ToUpper().Equals("DUTOVIARIO"))
                    tp_documento = "10";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_documento = "99";
            }
        }
        public string Ds_documento
        { get; set; }
        public string Nr_documento
        { get; set; }
        private DateTime? dt_documento;
        public DateTime? Dt_documento
        {
            get { return dt_documento; }
            set
            {
                dt_documento = value;
                dt_documentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_documentostr;
        public string Dt_documentostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_documentostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_documentostr = value;
                try
                {
                    dt_documento = DateTime.Parse(value);
                }
                catch { dt_documento = null; }
            }
        }
        public decimal Vl_documento
        { get; set; }

        public TRegistro_CTRNotaFiscal()
        {
            this.Cd_empresa = string.Empty;
            this.id_nota = null;
            this.id_notastr = string.Empty;
            this.nr_lanctoctr = null;
            this.nr_lanctoctrstr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.Chave_acesso_nfe = string.Empty;
            this.tp_documento = string.Empty;
            this.tipo_documento = string.Empty;
            this.Ds_documento = string.Empty;
            this.Nr_documento = string.Empty;
            this.dt_documento = null;
            this.dt_documentostr = string.Empty;
            this.Vl_documento = decimal.Zero;
        }
    }

    public class TCD_CTRNotaFiscal : TDataQuery
    {
        public TCD_CTRNotaFiscal()
        { }

        public TCD_CTRNotaFiscal(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, a.ID_Nota, ");
                sql.AppendLine("a.NR_LanctoCTR, a.NR_LanctoFiscal, a.Chave_Acesso_NFe, ");
                sql.AppendLine("a.TP_Documento, a.DS_Documento, a.NR_Documento, ");
                sql.AppendLine("a.DT_Documento, a.Vl_Documento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_NotaFiscal a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
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
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTRNotaFiscal Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (this.Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(true);
            TList_CTRNotaFiscal lista = new TList_CTRNotaFiscal();
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CTRNotaFiscal reg = new TRegistro_CTRNotaFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nota")))
                        reg.Id_nota = reader.GetDecimal(reader.GetOrdinal("id_nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_acesso_nfe")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("chave_acesso_nfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_documento")))
                        reg.Tp_documento = reader.GetString(reader.GetOrdinal("tp_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_documento")))
                        reg.Ds_documento = reader.GetString(reader.GetOrdinal("ds_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_documento")))
                        reg.Nr_documento = reader.GetString(reader.GetOrdinal("nr_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_documento")))
                        reg.Dt_documento = reader.GetDateTime(reader.GetOrdinal("dt_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_documento")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("vl_documento"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CTRNotaFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_NOTA", val.Id_nota);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CHAVE_ACESSO_NFE", val.Chave_acesso_nfe);
            hs.Add("@P_TP_DOCUMENTO", val.Tp_documento);
            hs.Add("@P_DS_DOCUMENTO", val.Ds_documento);
            hs.Add("@P_NR_DOCUMENTO", val.Nr_documento);
            hs.Add("@P_DT_DOCUMENTO", val.Dt_documento);
            hs.Add("@P_VL_DOCUMENTO", val.Vl_documento);

            return this.executarProc("IA_CTR_NOTAFISCAL", hs);
        }

        public string Excluir(TRegistro_CTRNotaFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_NOTA", val.Id_nota);

            return this.executarProc("EXCLUI_CTR_NOTAFISCAL", hs);
        }
    }
}
