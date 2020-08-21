using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_LacreBomba : List<TRegistro_LacreBomba>, IComparer<TRegistro_LacreBomba>
    {
        #region IComparer<TRegistro_LacreBomba> Members
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

        public TList_LacreBomba()
        { }

        public TList_LacreBomba(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LacreBomba value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LacreBomba x, TRegistro_LacreBomba y)
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

    
    public class TRegistro_LacreBomba
    {
        private decimal? id_lacre;
        
        public decimal? Id_lacre
        {
            get { return id_lacre; }
            set
            {
                id_lacre = value;
                id_lacrestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lacrestr;
        
        public string Id_lacrestr
        {
            get { return id_lacrestr; }
            set
            {
                id_lacrestr = value;
                try
                {
                    id_lacre = decimal.Parse(value);
                }
                catch
                { id_lacre = null; }
            }
        }
        private decimal? id_bomba;
        
        public decimal? Id_bomba
        {
            get { return id_bomba; }
            set
            {
                id_bomba = value;
                id_bombastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bombastr;
        
        public string Id_bombastr
        {
            get { return id_bombastr; }
            set
            {
                id_bombastr = value;
                try
                {
                    id_bomba = decimal.Parse(value);
                }
                catch
                { id_bomba = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nr_lacre
        { get; set; }
        private DateTime? dt_aplicacao;
        
        public DateTime? Dt_aplicacao
        {
            get { return dt_aplicacao; }
            set
            {
                dt_aplicacao = value;
                dt_aplicacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aplicacaostr;
        public string Dt_aplicacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_aplicacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aplicacaostr = value;
                try
                {
                    dt_aplicacao = DateTime.Parse(value);
                }
                catch
                { dt_aplicacao = null; }
            }
        }

        public TRegistro_LacreBomba()
        {
            this.id_lacre = null;
            this.id_lacrestr = string.Empty;
            this.id_bomba = null;
            this.id_bombastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_lacre = string.Empty;
            this.dt_aplicacao = null;
            this.dt_aplicacaostr = string.Empty;
        }
    }

    public class TCD_LacreBomba : TDataQuery
    {
        public TCD_LacreBomba()
        { }

        public TCD_LacreBomba(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_lacre, a.id_bomba, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa, a.nr_lacre, a.dt_aplicacao ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_LacreBomba a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
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

        public TList_LacreBomba Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LacreBomba lista = new TList_LacreBomba();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LacreBomba reg = new TRegistro_LacreBomba();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bomba")))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("ID_Bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lacre")))
                        reg.Id_lacre = reader.GetDecimal(reader.GetOrdinal("id_lacre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lacre")))
                        reg.Nr_lacre = reader.GetString(reader.GetOrdinal("nr_lacre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_aplicacao")))
                        reg.Dt_aplicacao = reader.GetDateTime(reader.GetOrdinal("dt_aplicacao"));

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

        public string Gravar(TRegistro_LacreBomba val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LACRE", val.Id_lacre);
            hs.Add("@P_ID_BOMBA", val.Id_bomba);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LACRE", val.Nr_lacre);
            hs.Add("@P_DT_APLICACAO", val.Dt_aplicacao);

            return this.executarProc("IA_PDC_LACREBOMBA", hs);
        }

        public string Excluir(TRegistro_LacreBomba val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LACRE", val.Id_lacre);

            return this.executarProc("EXCLUI_PDC_LACREBOMBA", hs);
        }
    }
}
