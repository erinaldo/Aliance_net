using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Balanca
{
    public class TList_LanTransbordo : List<TRegistro_LanTransbordo>, IComparer<TRegistro_LanTransbordo>
    {
        #region IComparer<TRegistro_LanTransbordo> Members
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

        public TList_LanTransbordo()
        { }

        public TList_LanTransbordo(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanTransbordo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanTransbordo x, TRegistro_LanTransbordo y)
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

    public class TRegistro_LanTransbordo
    {
        public decimal Id_transbordo
        { get; set; }
        public string Cd_empresaorig
        { get; set; }
        public decimal Id_ticketorig
        { get; set; }
        public string Tp_pesagemorig
        { get; set; }
        public string Cd_empresadest
        { get; set; }
        public decimal Id_ticketdest
        { get; set; }
        public string Tp_pesagemdest
        { get; set; }
        public decimal Ps_transbordo
        { get; set; }

        public TRegistro_LanTransbordo()
        {
            this.Id_transbordo = 0;
            this.Cd_empresaorig = string.Empty;
            this.Id_ticketorig = 0;
            this.Tp_pesagemorig = string.Empty;
            this.Cd_empresadest = string.Empty;
            this.Id_ticketdest = 0;
            this.Tp_pesagemdest = string.Empty;
            this.Ps_transbordo = 0;
        }
    }

    public class TCD_LanTransbordo : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_transbordo, a.cd_empresaorig, ");
                sql.AppendLine("a.id_ticketorig, a.tp_pesagemorig, a.ps_transbordo, ");
                sql.AppendLine("a.cd_empresadest, a.id_ticketdest, a.tp_pesagemdest ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_transbordo a ");

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

        public TList_LanTransbordo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanTransbordo lista = new TList_LanTransbordo();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanTransbordo reg = new TRegistro_LanTransbordo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Transbordo"))))
                        reg.Id_transbordo = reader.GetDecimal(reader.GetOrdinal("ID_Transbordo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EmpresaOrig"))))
                        reg.Cd_empresaorig = reader.GetString(reader.GetOrdinal("CD_EmpresaOrig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TicketOrig"))))
                        reg.Id_ticketorig = reader.GetDecimal(reader.GetOrdinal("ID_TicketOrig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_PesagemOrig"))))
                        reg.Tp_pesagemorig = reader.GetString(reader.GetOrdinal("TP_PesagemOrig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EmpresaDest"))))
                        reg.Cd_empresadest = reader.GetString(reader.GetOrdinal("CD_EmpresaDest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TicketDest"))))
                        reg.Id_ticketdest = reader.GetDecimal(reader.GetOrdinal("ID_TicketDest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_PesagemDest"))))
                        reg.Tp_pesagemdest = reader.GetString(reader.GetOrdinal("TP_PesagemDest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ps_Transbordo"))))
                        reg.Ps_transbordo = reader.GetDecimal(reader.GetOrdinal("Ps_Transbordo"));

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

        public string GravarTransbordo(TRegistro_LanTransbordo val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_TRANSBORDO", val.Id_transbordo);
            hs.Add("@P_CD_EMPRESAORIG", val.Cd_empresaorig);
            hs.Add("@P_ID_TICKETORIG", val.Id_ticketorig);
            hs.Add("@P_TP_PESAGEMORIG", val.Tp_pesagemorig);
            hs.Add("@P_CD_EMPRESADEST", val.Cd_empresadest);
            hs.Add("@P_ID_TICKETDEST", val.Id_ticketdest);
            hs.Add("@P_TP_PESAGEMDEST", val.Tp_pesagemdest);
            hs.Add("@P_PS_TRANSBORDO", val.Ps_transbordo);

            return this.executarProc("IA_BAL_TRANSBORDO", hs);
        }

        public string DeletarTransbordo(TRegistro_LanTransbordo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TRANSBORDO", val.Id_transbordo);

            return this.executarProc("EXCLUI_BAL_TRANSBORDO", hs);
        }
    }
}
