using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Contabil
{
    public class TList_Lan_CTB_LanMultiplo:List<TRegistro_Lan_CTB_LanMultiplo>
    { }
    
    public class TRegistro_Lan_CTB_LanMultiplo
    {
        private decimal? id_lan;
        public decimal? Id_lan
        {
            get { return id_lan; }
            set 
            {
                id_lan = value;
                id_lanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanstr;
        public string Id_lanstr
        {
            get { return id_lanstr; }
            set 
            {
                id_lanstr = value;
                try
                {
                    id_lan = Convert.ToDecimal(value);
                }
                catch
                { id_lan = null; }
            }
        }
        private decimal? id_lotectb;
        public decimal? Id_lotectb
        {
            get { return id_lotectb; }
            set
            {
                id_lotectb = value;
                id_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotectbstr;
        public string Id_lotectbstr
        {
            get { return id_lotectbstr; }
            set 
            {
                id_lotectbstr = value;
                try
                {
                    id_lotectb = Convert.ToDecimal(value);
                }
                catch
                { id_lotectb = null; }
            }
        }
        public string Ds_lotectb
        { get;set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private DateTime? dt_lan;
        public DateTime? Dt_lan
        {
            get { return dt_lan; }
            set
            {
                dt_lan = value;
                dt_lanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_lanstr;
        public string Dt_lanstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanstr = value;
                try
                {
                    dt_lan = Convert.ToDateTime(value);
                }
                catch
                { dt_lan = null; }
            }
        }
        public string Complhistorico
        { get; set; }
        public string Nr_docto
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
        public TList_LanctoAvulso lLanctoAvulso
        { get; set; }
        public TList_LanctoAvulso lLanctoAvulsoDel
        { get; set; }
        public TList_LanContabil lLanctoCTB
        { get; set; }
        public List<TRegistro_LanctoAvulso> lLanctoDebito
        {
            get
            {
                return lLanctoAvulso.FindAll(p => p.D_C.Trim().ToUpper().Equals("D"));
            }
        }
        public List<TRegistro_LanctoAvulso> lLanctoCredito
        {
            get
            {
                return lLanctoAvulso.FindAll(p => p.D_C.Trim().ToUpper().Equals("C"));
            }
        }

        public TRegistro_Lan_CTB_LanMultiplo()
        {
            this.Complhistorico = string.Empty;
            this.Ds_lotectb = string.Empty;
            this.dt_lan = null;
            this.dt_lanstr = string.Empty;
            this.id_lan = null;
            this.id_lanstr = string.Empty;
            this.id_lotectb = null;
            this.id_lotectbstr = string.Empty;
            this.Nr_docto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.lLanctoCTB = new TList_LanContabil();
            this.lLanctoAvulso = new TList_LanctoAvulso();
            this.lLanctoAvulsoDel = new TList_LanctoAvulso();
        }
    }

    public class TCD_Lan_CTB_LanMultiplo : TDataQuery
    {
        public TCD_Lan_CTB_LanMultiplo()
        { }

        public TCD_Lan_CTB_LanMultiplo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.Id_Lan, a.id_lotectb, a.dt_lan, ");
                sql.AppendLine("a.complHistorico, a.Nr_Docto, a.St_Registro, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa, c.ds_lote ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_LanMultiplo a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_CTB_LoteLan c ");
            sql.AppendLine("on a.id_lotectb = c.id_lotectb");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.Id_Lan asc");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        protected override object ExecutarBuscaEscalar(string vSQLCode, Hashtable Parametros)
        {
            return base.ExecutarBuscaEscalar(vSQLCode, Parametros);
        }

        public TList_Lan_CTB_LanMultiplo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lan_CTB_LanMultiplo lista = new TList_Lan_CTB_LanMultiplo();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                
                while (reader.Read())
                {
                    TRegistro_Lan_CTB_LanMultiplo reg = new TRegistro_Lan_CTB_LanMultiplo();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lan")))
                        reg.Id_lan = reader.GetDecimal(reader.GetOrdinal("ID_Lan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB")))
                        reg.Id_lotectb = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Lote")))
                        reg.Ds_lotectb = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lan")))
                        reg.Dt_lan = reader.GetDateTime(reader.GetOrdinal("DT_Lan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ComplHistorico")))
                        reg.Complhistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("NR_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Grava(TRegistro_Lan_CTB_LanMultiplo vRegistro)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_LAN", vRegistro.Id_lan);
            hs.Add("@P_ID_LOTECTB", vRegistro.Id_lotectb);
            hs.Add("@P_DT_LAN", vRegistro.Dt_lan);
            hs.Add("@P_COMPLHISTORICO", vRegistro.Complhistorico);
            hs.Add("@P_NR_DOCTO", vRegistro.Nr_docto);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return this.executarProc("IA_CTB_LANMULTIPLO", hs);
        }

        public string Deleta(TRegistro_Lan_CTB_LanMultiplo vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LAN", vRegistro.Id_lan);

            return this.executarProc("EXCLUI_CTB_LANMULTIPLO", hs);
        }
    }
}
