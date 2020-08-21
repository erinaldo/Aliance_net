using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_Evento : List<TRegistro_Evento>, IComparer<TRegistro_Evento>
    {
        #region IComparer<TRegistro_Evento> Members
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

        public TList_Evento()
        { }

        public TList_Evento(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Evento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Evento x, TRegistro_Evento y)
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

    
    public class TRegistro_Evento
    {
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
                catch
                { cd_evento = null; }
            }
        }
        
        public string Ds_evento
        { get; set; }
        private string tp_evento;
        
        public string Tp_evento
        {
            get { return tp_evento; }
            set
            {
                tp_evento = value;
                if (value.Trim().ToUpper().Equals("CC"))
                    tipo_evento = "CARTA CORREÇÃO";
                else if (value.Trim().ToUpper().Equals("CA"))
                    tipo_evento = "CANCELAMENTO";
                else if (value.Trim().ToUpper().Equals("MF"))
                    tipo_evento = "MANIFESTO";
                else if (value.Trim().ToUpper().Equals("EC"))
                    tipo_evento = "ENCERRAMENTO";
                else if (value.Trim().ToUpper().Equals("IC"))
                    tipo_evento = "INCLUSÃO CONDUTOR";
            }
        }
        private string tipo_evento;
        
        public string Tipo_evento
        {
            get { return tipo_evento; }
            set
            {
                tipo_evento = value;
                if (value.Trim().ToUpper().Equals("CARTA CORREÇÃO"))
                    tp_evento = "CC";
                else if (value.Trim().ToUpper().Equals("CANCELAMENTO"))
                    tp_evento = "CA";
                else if (value.Trim().ToUpper().Equals("MANIFESTO"))
                    tp_evento = "MF";
                else if (value.Trim().ToUpper().Equals("ENCERRAMENTO"))
                    tp_evento = "EC";
                else if (value.Trim().ToUpper().Equals("INCLUSÃO CONDUTOR"))
                    tp_evento = "IC";
            }
        }

        public TRegistro_Evento()
        {
            cd_evento = null;
            cd_eventostr = string.Empty;
            Ds_evento = string.Empty;
            tp_evento = string.Empty;
            tipo_evento = string.Empty;
        }
    }

    public class TCD_Evento : TDataQuery
    {
        public TCD_Evento() { }

        public TCD_Evento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.cd_evento, a.ds_evento, a.tp_evento ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Evento a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Evento Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Evento lista = new TList_Evento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Evento reg = new TRegistro_Evento();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_evento")))
                        reg.Cd_evento = reader.GetDecimal(reader.GetOrdinal("cd_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_evento")))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("ds_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("tp_evento"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Evento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);
            hs.Add("@P_DS_EVENTO", val.Ds_evento);
            hs.Add("@P_TP_EVENTO", val.Tp_evento);

            return executarProc("IA_FAT_EVENTO", hs);
        }

        public string Excluir(TRegistro_Evento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);

            return executarProc("EXCLUI_FAT_EVENTO", hs);
        }
    }
}
