using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Balanca
{
    public class TList_PsAvulsa_X_Duplicata : List<TRegistro_PsAvulsa_X_Duplicata>, IComparer<TRegistro_PsAvulsa_X_Duplicata>
    {
        #region IComparer<TRegistro_PsAvulsa_X_Duplicata> Members
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

        public TList_PsAvulsa_X_Duplicata()
        { }

        public TList_PsAvulsa_X_Duplicata(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PsAvulsa_X_Duplicata value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PsAvulsa_X_Duplicata x, TRegistro_PsAvulsa_X_Duplicata y)
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

    public class TRegistro_PsAvulsa_X_Duplicata
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_ticket
        { get; set; }
        public string Tp_pesagem
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }

        public TRegistro_PsAvulsa_X_Duplicata()
        {
            this.Cd_empresa = string.Empty;
            this.Id_ticket = null;
            this.Tp_pesagem = string.Empty;
            this.Nr_lancto = null;
        }
    }

    public class TCD_PsAvulsa_X_Duplicata : TDataQuery
    {
        public TCD_PsAvulsa_X_Duplicata()
        { }

        public TCD_PsAvulsa_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Ticket, ");
                sql.AppendLine("a.Tp_Pesagem, a.nr_lancto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_psavulsa_x_duplicata a ");

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

        public TList_PsAvulsa_X_Duplicata Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_PsAvulsa_X_Duplicata lista = new TList_PsAvulsa_X_Duplicata();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PsAvulsa_X_Duplicata reg = new TRegistro_PsAvulsa_X_Duplicata();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));

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

        public string GravarPsAvulsa_X_Duplicata(TRegistro_PsAvulsa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_BAL_PSAVULSA_X_DUPLICATA", hs);
        }

        public string DeletarPsAvulsa_X_Duplicata(TRegistro_PsAvulsa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_BAL_PSAVULSA_X_DUPLICATA", hs);
        }
    }
}
