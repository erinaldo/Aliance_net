using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CTRC
{
    #region Evento CTe
    public class TList_EventoCTe : List<TRegistro_EventoCTe>
    { }
    
    public class TRegistro_EventoCTe
    {
        public string Cd_empresa
        { get; set; }
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
        private decimal? nr_ctrc;
        public decimal? Nr_ctrc
        {
            get { return nr_ctrc; }
            set
            {
                nr_ctrc = value;
                nr_ctrcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_ctrcstr;
        public string Nr_ctrcstr
        {
            get { return nr_ctrcstr; }
            set
            {
                nr_ctrcstr = value;
                try
                {
                    nr_ctrc = decimal.Parse(value);
                }
                catch { nr_ctrc = null; }
            }
        }
        public string Chaveacesso
        { get; set; }
        private decimal? nr_protocolo_cte;
        public decimal? Nr_protocolo_cte
        {
            get { return nr_protocolo_cte; }
            set
            {
                nr_protocolo_cte = value;
                nr_protocolo_ctestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_protocolo_ctestr;
        public string Nr_protocolo_ctestr
        {
            get { return nr_protocolo_ctestr; }
            set
            {
                nr_protocolo_ctestr = value;
                try
                {
                    nr_protocolo_cte = decimal.Parse(value);
                }
                catch { nr_protocolo_cte = null; }
            }
        }
        private decimal? id_evento;
        public decimal? Id_evento
        {
            get { return id_evento; }
            set
            {
                id_evento = value;
                id_eventostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_eventostr;
        public string Id_eventostr
        {
            get { return id_eventostr; }
            set
            {
                id_eventostr = value;
                try
                {
                    id_evento = decimal.Parse(value);
                }
                catch { id_evento = null; }
            }
        }
        private decimal? cd_evento;
        public decimal? Cd_evento
        {
            get { return cd_evento; }
            set
            {
                cd_evento = value;
                cd_eventostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_eventostr;
        public string Cd_eventostr
        {
            get { return cd_eventostr; }
            set
            {
                cd_eventostr = value;
                try
                {
                    cd_evento = decimal.Parse(value);
                }
                catch { cd_evento = null; }
            }
        }
        public string Ds_evento
        { get; set; }
        public string Tp_evento
        { get; set; }
        public string Tipo_evento
        {
            get
            {
                if (Tp_evento.Trim().ToUpper().Equals("CC"))
                    return "CARTA CORREÇÃO";
                else if (Tp_evento.Trim().ToUpper().Equals("CA"))
                    return "CANCELAMENTO";
                else if (Tp_evento.Trim().ToUpper().Equals("MF"))
                    return "MANIFESTO";
                else return string.Empty;
            }
        }
        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_eventostr).ToString("dd/MM/yyyy");
                }
                catch { return dt_eventostr; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch { dt_evento = null; }
            }
        }
        public string Justificativa
        { get; set; }
        private decimal? nr_protocolo;
        public decimal? Nr_protocolo
        {
            get { return nr_protocolo; }
            set
            {
                nr_protocolo = value;
                nr_protocolostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_protocolostr;
        public string Nr_protocolostr
        {
            get { return nr_protocolostr; }
            set
            {
                nr_protocolostr = value;
                try
                {
                    nr_protocolo = decimal.Parse(value);
                }
                catch { nr_protocolo = null; }
            }
        }
        public string Xml_evento
        { get; set; }
        public string Xml_retevent
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
                else if (value.Trim().ToUpper().Equals("T"))
                    status = "TRANSMITIDO";
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
                else if (value.Trim().ToUpper().Equals("TRANSMITIDO"))
                    st_registro = "T";
            }
        }

        public TList_CamposCC lCamposCC
        { get; set; }

        public TRegistro_EventoCTe()
        {
            this.Cd_empresa = string.Empty;
            this.nr_lanctoctr = null;
            this.nr_lanctoctrstr = string.Empty;
            this.nr_ctrc = null;
            this.nr_ctrcstr = string.Empty;
            this.Chaveacesso = string.Empty;
            this.id_evento = null;
            this.id_eventostr = string.Empty;
            this.cd_evento = null;
            this.cd_eventostr = string.Empty;
            this.dt_evento = null;
            this.dt_eventostr = string.Empty;
            this.Justificativa = string.Empty;
            this.nr_protocolo = null;
            this.nr_protocolostr = string.Empty;
            this.Tp_evento = string.Empty;
            this.Ds_evento = string.Empty;
            this.Xml_evento = string.Empty;
            this.Xml_retevent = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";

            this.lCamposCC = new TList_CamposCC();
        }
    }

    public class TCD_EventoCTe : TDataQuery
    {
        public TCD_EventoCTe() { }

        public TCD_EventoCTe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, a.NR_LanctoCTR, ");
                sql.AppendLine("a.ID_Evento, a.CD_Evento, b.DS_Evento, a.xml_evento, a.xml_retevent, ");
                sql.AppendLine("a.DT_Evento, a.Justificativa, a.NR_Protocolo, a.ST_Registro, ");
                sql.AppendLine("d.tp_evento, d.ds_evento as descricao_evento, c.nr_ctrc, c.chaveacesso ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_EventoCTe a ");
            sql.AppendLine("inner join tb_fat_evento b ");
            sql.AppendLine("on a.cd_evento = b.CD_Evento ");
            sql.AppendLine("inner join tb_ctr_conhecimentofrete c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoctr = c.nr_lanctoctr ");
            sql.AppendLine("inner join TB_FAT_Evento d ");
            sql.AppendLine("on a.cd_evento = d.cd_evento ");

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

        public TList_EventoCTe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_EventoCTe lista = new TList_EventoCTe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_EventoCTe reg = new TRegistro_EventoCTe();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_evento")))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("id_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_ctrc")))
                        reg.Nr_ctrc = reader.GetDecimal(reader.GetOrdinal("nr_ctrc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.Chaveacesso = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Evento")))
                        reg.Cd_evento = reader.GetDecimal(reader.GetOrdinal("CD_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Evento")))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("DS_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("tp_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("DT_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Justificativa")))
                        reg.Justificativa = reader.GetString(reader.GetOrdinal("Justificativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_evento")))
                        reg.Xml_evento = reader.GetString(reader.GetOrdinal("xml_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_retevent")))
                        reg.Xml_retevent = reader.GetString(reader.GetOrdinal("xml_retevent"));
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

        public string Gravar(TRegistro_EventoCTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);
            hs.Add("@P_JUSTIFICATIVA", val.Justificativa);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_XML_EVENTO", val.Xml_evento);
            hs.Add("@P_XML_RETEVENT", val.Xml_retevent);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_CTR_EVENTOCTE", hs);
        }

        public string Excluir(TRegistro_EventoCTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_EVENTO", val.Id_evento);

            return this.executarProc("EXCLUI_CTR_EVENTOCTE", hs);
        }
    }
    #endregion

    #region Campos CC
    public class TList_CamposCC : List<TRegistro_CamposCC> { }

    public class TRegistro_CamposCC
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctoCTR
        { get; set; }
        public decimal? Id_evento
        { get; set; }
        public decimal? Id_campo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Ds_campo
        { get; set; }
        public string ValorAlterado
        { get; set; }

        public TRegistro_CamposCC()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_lanctoCTR = null;
            this.Id_evento = null;
            this.Id_campo = null;
            this.Ds_grupo = string.Empty;
            this.Ds_campo = string.Empty;
            this.ValorAlterado = string.Empty;
        }
    }

    public class TCD_CamposCC : TDataQuery
    {
        public TCD_CamposCC() { }

        public TCD_CamposCC(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, a.NR_LanctoCTR, ");
                sql.AppendLine("a.ID_Evento, a.ID_Campo, a.DS_Grupo, a.DS_Campo, a.ValorAlterado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_CamposCC a ");

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

        public TList_CamposCC Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CamposCC lista = new TList_CamposCC();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CamposCC reg = new TRegistro_CamposCC();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_evento")))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("id_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoCTR = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Campo")))
                        reg.Id_campo = reader.GetDecimal(reader.GetOrdinal("ID_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Campo")))
                        reg.Ds_campo = reader.GetString(reader.GetOrdinal("DS_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ValorAlterado")))
                        reg.ValorAlterado = reader.GetString(reader.GetOrdinal("ValorAlterado"));

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

        public string Gravar(TRegistro_CamposCC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTR);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_ID_CAMPO", val.Id_campo);
            hs.Add("@P_DS_GRUPO", val.Ds_grupo);
            hs.Add("@P_DS_CAMPO", val.Ds_campo);
            hs.Add("@P_VALORALTERADO", val.ValorAlterado);

            return this.executarProc("IA_CTR_CAMPOSCC", hs);
        }

        public string Excluir(TRegistro_CamposCC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTR);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_ID_CAMPO", val.Id_campo);

            return this.executarProc("EXCLUI_CTR_CAMPOSCC", hs);
        }
    }
    #endregion
}
