using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_CartaCorrecao : List<TRegistro_CartaCorrecao>, IComparer<TRegistro_CartaCorrecao>
    {
        #region IComparer<TRegistro_CartaCorrecao> Members
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

        public TList_CartaCorrecao()
        { }

        public TList_CartaCorrecao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CartaCorrecao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CartaCorrecao x, TRegistro_CartaCorrecao y)
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

    [DataContract]
    public class TRegistro_CartaCorrecao
    {
        private decimal? id_carta;
        [DataMember]
        public decimal? Id_carta
        {
            get { return id_carta; }
            set
            {
                id_carta = value;
                id_cartastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartastr;
        [DataMember]
        public string Id_cartastr
        {
            get { return id_cartastr; }
            set
            {
                id_cartastr = value;
                try
                {
                    id_carta = decimal.Parse(value);
                }
                catch
                { id_carta = null; }
            }
        }
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        [DataMember]
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
        [DataMember]
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
                catch
                { nr_lanctofiscal = null; }
            }
        }
        [DataMember]
        public decimal? Nr_notafiscal
        { get; set; }
        [DataMember]
        public string Chave_acesso_nfe
        { get; set; }
        private DateTime? dt_evento;
        [DataMember]
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_eventostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch
                { dt_evento = null; }
            }
        }
        [DataMember]
        public string Ds_correcao
        { get; set; }
        [DataMember]
        public decimal? Nr_protocolo
        { get; set; }
        [DataMember]
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("T"))
                    return "TRANSMITIDO";
                else return string.Empty;
            }
        }

        public TRegistro_CartaCorrecao()
        {
            this.id_carta = null;
            this.id_cartastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.Nr_notafiscal = null;
            this.Chave_acesso_nfe = string.Empty;
            this.dt_evento = null;
            this.dt_eventostr = string.Empty;
            this.Ds_correcao = string.Empty;
            this.Nr_protocolo = null;
            this.St_registro = "A";
        }
    }

    public class TCD_CartaCorrecao : TDataQuery
    {
        public TCD_CartaCorrecao()
        { }

        public TCD_CartaCorrecao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_Carta, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.Nr_LanctoFiscal, c.Chave_Acesso_NFE, ");
                sql.AppendLine("a.DT_Evento, a.DS_Correcao, c.NR_NotaFiscal, ");
                sql.AppendLine("a.NR_Protocolo, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_CartaCorrecao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = c.nr_lanctofiscal ");

            string cond = " where ";

            if (vBusca != null)
                foreach (Utils.TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
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

        public TList_CartaCorrecao Select(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (this.Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(true);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            TList_CartaCorrecao lista = new TList_CartaCorrecao();
            try
            {
                while (reader.Read())
                {
                    TRegistro_CartaCorrecao reg = new TRegistro_CartaCorrecao();

                    if (!(reader.IsDBNull(reader.GetOrdinal("id_carta"))))
                        reg.Id_carta = reader.GetDecimal(reader.GetOrdinal("id_carta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFE")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("dt_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_correcao")))
                        reg.Ds_correcao = reader.GetString(reader.GetOrdinal("ds_correcao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("nr_protocolo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_CartaCorrecao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_CARTA", val.Id_carta);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);
            hs.Add("@P_DS_CORRECAO", val.Ds_correcao);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAT_CARTACORRECAO", hs);
        }

        public string Excluir(TRegistro_CartaCorrecao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CARTA", val.Id_carta);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_CARTACORRECAO", hs);
        }
    }
}
