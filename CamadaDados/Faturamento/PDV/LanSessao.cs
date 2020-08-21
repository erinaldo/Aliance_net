using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_Sessao : List<TRegistro_Sessao>, IComparer<TRegistro_Sessao>
    {
        #region IComparer<TRegistro_Sessao> Members
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

        public TList_Sessao()
        { }

        public TList_Sessao(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Sessao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Sessao x, TRegistro_Sessao y)
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

    
    public class TRegistro_Sessao
    {
        private decimal? id_pdv;
        
        public decimal? Id_pdv
        {
            get { return id_pdv; }
            set
            {
                id_pdv = value;
                id_pdvstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pdvstr;
        
        public string Id_pdvstr
        {
            get { return id_pdvstr; }
            set
            {
                id_pdvstr = value;
                try
                {
                    id_pdv = Convert.ToDecimal(value);
                }
                catch
                { id_pdv = null; }
            }
        }
        public string Ds_pdv
        { get; set; }
        private decimal? id_sessao;
        
        public decimal? Id_sessao
        {
            get { return id_sessao; }
            set
            {
                id_sessao = value;
                id_sessaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_sessaostr;
        
        public string Id_sessaostr
        {
            get { return id_sessaostr; }
            set
            {
                id_sessaostr = value;
                try
                {
                    id_sessao = Convert.ToDecimal(value);
                }
                catch
                { id_sessao = null; }
            }
        }
        
        public string Login
        { get; set; }
        private DateTime? dt_abertura;
        
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = Convert.ToDateTime(value);
                }
                catch
                { dt_abertura = null; }
            }
        }
        private DateTime? dt_fechamento;
        
        public DateTime? Dt_fechamento
        {
            get { return dt_fechamento; }
            set
            {
                dt_fechamento = value;
                dt_fechamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_fechamentostr;
        public string Dt_fechamentostr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_fechamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fechamentostr = value;
                try
                {
                    dt_fechamento = Convert.ToDateTime(value);
                }
                catch
                { dt_fechamento = null; }
            }
        }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTA";
                else if (St_registro.Trim().ToUpper().Equals("S"))
                    return "STANDBY";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FECHADA";
                else return string.Empty;
            }
        }

        public TRegistro_Sessao()
        {
            this.id_pdv = null;
            this.id_pdvstr = string.Empty;
            this.Ds_pdv = string.Empty;
            this.id_sessao = null;
            this.id_sessaostr = string.Empty;
            this.Login = string.Empty;
            this.dt_abertura = null;
            this.dt_aberturastr = string.Empty;
            this.dt_fechamento = null;
            this.dt_fechamentostr = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_Sessao : TDataQuery
    {
        public TCD_Sessao()
        { }

        public TCD_Sessao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_pdv, b.Ds_pdv, a.id_sessao, a.login, ");
                sql.AppendLine("a.dt_abertura, a.dt_fechamento, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_Sessao a ");
            sql.AppendLine("inner join TB_PDV_PontoVenda b ");
            sql.AppendLine("on a.id_pdv = b.id_pdv ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
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

        public TList_Sessao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Sessao lista = new TList_Sessao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Sessao reg = new TRegistro_Sessao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_pdv"))))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("id_pdv"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_pdv"))))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("Ds_pdv"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_sessao"))))
                        reg.Id_sessao = reader.GetDecimal(reader.GetOrdinal("id_sessao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("dt_fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_Sessao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_SESSAO", val.Id_sessao);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_SESSAO", hs);
        }

        public string Excluir(TRegistro_Sessao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_SESSAO", val.Id_sessao);

            return this.executarProc("EXCLUI_PDV_SESSAO", hs);
        }
    }
}
