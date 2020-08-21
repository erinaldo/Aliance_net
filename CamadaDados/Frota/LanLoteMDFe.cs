using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region LoteMDFe
    public class TList_LoteMDFe : List<TRegistro_LoteMDFe> { }

    public class TRegistro_LoteMDFe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch { id_lote = null; }
            }
        }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente = "PRODUÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente = "HOMOLOGAÇÃO";
            }
        }
        private string tipo_ambiente;
        public string Tipo_ambiente
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("PRODUÇÃO"))
                    tp_ambiente = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente = "2";
            }
        }
        public string cStat
        { get; set; }
        public string xMotivo
        { get; set; }
        public string nRec
        { get; set; }
        public DateTime? dhRebcto
        { get; set; }
        public TList_Lote_X_MDFe lMDFe
        { get; set; }

        public TRegistro_LoteMDFe()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.tp_ambiente = string.Empty;
            this.tipo_ambiente = string.Empty;
            this.cStat = string.Empty;
            this.xMotivo = string.Empty;
            this.nRec = string.Empty;
            this.dhRebcto = null;
            this.lMDFe = new TList_Lote_X_MDFe();
        }
    }

    public class TCD_LoteMDFe : TDataQuery
    {
        public TCD_LoteMDFe() { }

        public TCD_LoteMDFe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Lote, a.TP_Ambiente, a.cStat, a.xMotivo, ");
                sql.AppendLine("a.nRec, a.dhRecbto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_LoteMDFe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
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

        public TList_LoteMDFe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_LoteMDFe lista = new TList_LoteMDFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_LoteMDFe reg = new TRegistro_LoteMDFe();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("TP_Ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cStat")))
                        reg.cStat = reader.GetString(reader.GetOrdinal("cStat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xMotivo")))
                        reg.xMotivo = reader.GetString(reader.GetOrdinal("xMotivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nRec")))
                        reg.nRec = reader.GetString(reader.GetOrdinal("nRec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dhRecbto")))
                        reg.dhRebcto = reader.GetDateTime(reader.GetOrdinal("dhRecbto"));

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

        public string Gravar(TRegistro_LoteMDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_CSTAT", val.cStat);
            hs.Add("@P_XMOTIVO", val.xMotivo);
            hs.Add("@P_NREC", val.nRec);
            hs.Add("@P_DHRECBTO", val.dhRebcto);

            return this.executarProc("IA_CTR_LOTEMDFE", hs);
        }

        public string Excluir(TRegistro_LoteMDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_CTR_LOTEMDFE", hs);
        }
    }
    #endregion

    #region Lote X MDFe
    public class TList_Lote_X_MDFe : List<TRegistro_Lote_X_MDFe> { }

    public class TRegistro_Lote_X_MDFe
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch { id_lote = null; }
            }
        }
        private decimal? id_mdfe;
        public decimal? Id_mdfe
        {
            get { return id_mdfe; }
            set
            {
                id_mdfe = value;
                id_mdfestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mdfestr;
        public string Id_mdfestr
        {
            get { return id_mdfestr; }
            set
            {
                id_mdfestr = value;
                try
                {
                    id_mdfe = decimal.Parse(value);
                }
                catch { id_mdfe = null; }
            }
        }
        public DateTime? dhRecbto
        { get; set; }
        public string nProt
        { get; set; }
        public string digVal
        { get; set; }
        public string cStat
        { get; set; }
        public string xMotivo
        { get; set; }
        public string Xml_lote
        { get; set; }
        public decimal? Nr_mdfe
        { get; set; }
        public string ChaveAcesso
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }

        public TRegistro_Lote_X_MDFe()
        {
            this.Cd_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.id_mdfe = null;
            this.id_mdfestr = string.Empty;
            this.dhRecbto = null;
            this.nProt = string.Empty;
            this.digVal = string.Empty;
            this.cStat = string.Empty;
            this.xMotivo = string.Empty;
            this.Xml_lote = string.Empty;
            this.Nr_mdfe = null;
            this.ChaveAcesso = string.Empty;
            this.Dt_emissao = null;
        }
    }

    public class TCD_Lote_X_MDFe : TDataQuery
    {
        public TCD_Lote_X_MDFe() { }

        public TCD_Lote_X_MDFe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Lote, ");
                sql.AppendLine("a.ID_MDFe, a.dhRecbto, a.nProt, a.digVal, a.cStat, ");
                sql.AppendLine("a.xMotivo, a.xml_lote, c.nr_mdfe, c.chaveacesso, c.dt_emissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_Lote_X_MDFe a ");
            sql.AppendLine("inner join TB_CTR_LoteMDFe b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_lote = b.id_lote ");
            sql.AppendLine("inner join TB_CTR_MDFe c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.id_mdfe = c.id_mdfe ");

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

        public TList_Lote_X_MDFe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lote_X_MDFe lista = new TList_Lote_X_MDFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Lote_X_MDFe reg = new TRegistro_Lote_X_MDFe();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cStat")))
                        reg.cStat = reader.GetString(reader.GetOrdinal("cStat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xMotivo")))
                        reg.xMotivo = reader.GetString(reader.GetOrdinal("xMotivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nProt")))
                        reg.nProt = reader.GetString(reader.GetOrdinal("nProt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("digVal")))
                        reg.digVal = reader.GetString(reader.GetOrdinal("digVal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dhRecbto")))
                        reg.dhRecbto = reader.GetDateTime(reader.GetOrdinal("dhRecbto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_mdfe")))
                        reg.Nr_mdfe = reader.GetDecimal(reader.GetOrdinal("nr_mdfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.ChaveAcesso = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_lote")))
                        reg.Xml_lote = reader.GetString(reader.GetOrdinal("xml_lote"));

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

        public string Gravar(TRegistro_Lote_X_MDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_DHRECBTO", val.dhRecbto);
            hs.Add("@P_CSTAT", val.cStat);
            hs.Add("@P_XMOTIVO", val.xMotivo);
            hs.Add("@P_NPROT", val.nProt);
            hs.Add("@P_DIGVAL", val.digVal);
            hs.Add("@P_XML_LOTE", val.Xml_lote);

            return this.executarProc("IA_CTR_LOTE_X_MDFE", hs);
        }

        public string Excluir(TRegistro_Lote_X_MDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);

            return this.executarProc("EXCLUI_CTR_LOTE_X_MDFE", hs);
        }
    }
    #endregion
}
