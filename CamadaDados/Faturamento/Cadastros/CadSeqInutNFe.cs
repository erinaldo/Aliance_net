using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_SeqInutNFe : List<TRegistro_SeqInutNFe>, IComparer<TRegistro_SeqInutNFe>
    {
        #region IComparer<TRegistro_SeqInutNFe> Members
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

        public TList_SeqInutNFe()
        { }

        public TList_SeqInutNFe(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_SeqInutNFe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_SeqInutNFe x, TRegistro_SeqInutNFe y)
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

    
    public class TRegistro_SeqInutNFe
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nr_serie
        { get; set; }
        
        public string Ds_serie
        { get; set; }
        
        public string Cd_modelo
        { get; set; }
        
        public string Ds_modelo
        { get; set; }
        private decimal? id_sequencia;
        
        public decimal? Id_sequencia
        {
            get { return id_sequencia; }
            set
            {
                id_sequencia = value;
                id_sequenciastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_sequenciastr;
        
        public string Id_sequenciastr
        {
            get { return id_sequenciastr; }
            set
            {
                id_sequenciastr = value;
                try
                {
                    id_sequencia = decimal.Parse(value);
                }
                catch
                { id_sequencia = null; }
            }
        }
        
        public decimal Nr_nfinicial
        { get; set; }
        
        public decimal Nr_nffinal
        { get; set; }
        
        public decimal Ano
        { get; set; }
        private DateTime? dh_processamento;
        
        public DateTime? Dh_processamento
        {
            get { return dh_processamento; }
            set
            {
                dh_processamento = value;
                dh_processamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dh_processamentostr;
        public string Dh_processamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dh_processamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dh_processamentostr = value;
                try
                {
                    dh_processamento = DateTime.Parse(value);
                }
                catch
                { dh_processamento = null; }
            }
        }
        
        public decimal Nr_protocolo
        { get; set; }

        public TRegistro_SeqInutNFe()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_serie = string.Empty;
            this.Ds_serie = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Ds_modelo = string.Empty;
            this.id_sequencia = null;
            this.id_sequenciastr = string.Empty;
            this.Nr_nfinicial = decimal.Zero;
            this.Nr_nffinal = decimal.Zero;
            this.Ano = decimal.Zero;
            this.dh_processamento = null;
            this.dh_processamentostr = string.Empty;
            this.Nr_protocolo = decimal.Zero;
        }
    }

    public class TCD_SeqInutNFe : TDataQuery
    {
        public TCD_SeqInutNFe()
        { }

        public TCD_SeqInutNFe(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.nr_serie, b.ds_serienf, ");
                sql.AppendLine("a.id_sequencia, a.nr_nfinicial, a.nr_nffinal, ");
                sql.AppendLine("a.ano, a.dh_processamento, a.nr_protocolo, ");
                sql.AppendLine("a.cd_modelo, c.ds_modelo, a.cd_empresa, d.nm_empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_seqinutnfe a ");
            sql.AppendLine("inner  join tb_fat_serienf b ");
            sql.AppendLine("on a.nr_serie = b.nr_serie ");
            sql.AppendLine("and a.cd_modelo = b.cd_modelo ");
            sql.AppendLine("inner join tb_fat_modelonf c ");
            sql.AppendLine("on a.cd_modelo = c.cd_modelo ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_SeqInutNFe Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_SeqInutNFe lista = new TList_SeqInutNFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_SeqInutNFe reg = new TRegistro_SeqInutNFe();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.Ds_serie = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("ds_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_sequencia")))
                        reg.Id_sequencia = reader.GetDecimal(reader.GetOrdinal("id_sequencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nfinicial")))
                        reg.Nr_nfinicial = reader.GetDecimal(reader.GetOrdinal("nr_nfinicial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nffinal")))
                        reg.Nr_nffinal = reader.GetDecimal(reader.GetOrdinal("nr_nffinal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ano")))
                        reg.Ano = reader.GetDecimal(reader.GetOrdinal("ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dh_processamento")))
                        reg.Dh_processamento = reader.GetDateTime(reader.GetOrdinal("dh_processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("nr_protocolo"));

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

        public string Gravar(TRegistro_SeqInutNFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_ID_SEQUENCIA", val.Id_sequencia);
            hs.Add("@P_NR_NFINICIAL", val.Nr_nfinicial);
            hs.Add("@P_NR_NFFINAL", val.Nr_nffinal);
            hs.Add("@P_ANO", val.Ano);
            hs.Add("@P_DH_PROCESSAMENTO", val.Dh_processamento);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);

            return this.executarProc("IA_FAT_SEQINUTNFE", hs);
        }

        public string Excluir(TRegistro_SeqInutNFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_ID_SEQUENCIA", val.Id_sequencia);

            return this.executarProc("EXCLUI_FAT_SEQINUTNFE", hs);
        }
    }
}
