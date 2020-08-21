using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Balanca.Cadastros
{
    public class TList_CFGSeqPesagem : List<TRegistro_CFGSeqPesagem>, IComparer<TRegistro_CFGSeqPesagem>
    {
        #region IComparer<TRegistro_CFGSeqPesagem> Members
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

        public TList_CFGSeqPesagem()
        { }

        public TList_CFGSeqPesagem(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGSeqPesagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGSeqPesagem x, TRegistro_CFGSeqPesagem y)
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

    
    public class TRegistro_CFGSeqPesagem
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Tp_pesagem
        { get; set; }
        
        public string Nm_tppesagem
        { get; set; }
        
        public decimal Seq_idticket
        { get; set; }

        public TRegistro_CFGSeqPesagem()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.Nm_tppesagem = string.Empty;
            this.Seq_idticket = decimal.Zero;
        }
    }

    public class TCD_CFGSeqPesagem : TDataQuery
    {
        public TCD_CFGSeqPesagem()
        { }

        public TCD_CFGSeqPesagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.tp_pesagem, c.nm_tppesagem, a.seq_idticket ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_cfgseqpesagem a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_bal_tppesagem c ");
            sql.AppendLine("on a.tp_pesagem = c.tp_pesagem ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CFGSeqPesagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CFGSeqPesagem lista = new TList_CFGSeqPesagem();
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
                    TRegistro_CFGSeqPesagem reg = new TRegistro_CFGSeqPesagem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_TpPesagem"))))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TpPesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Seq_idticket")))
                        reg.Seq_idticket = reader.GetDecimal(reader.GetOrdinal("Seq_idticket"));

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

        public string Gravar(TRegistro_CFGSeqPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_SEQ_IDTICKET", val.Seq_idticket);

            return this.executarProc("IA_BAL_CFGSEQPESAGEM", hs);
        }

        public string Excluir(TRegistro_CFGSeqPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("EXCLUI_BAL_CFGSEQPESAGEM", hs);
        }

        public string GerarIdTicket(TRegistro_CFGSeqPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@@P_SEQ_IDTICKET", val.Seq_idticket);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("STP_GERARID_TICKET", hs);
        }
    }
}
