using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using CamadaDados;
using Utils;

namespace CamadaDados.Diversos
{

    public class TList_CadRota : List<TRegistro_CadRota>, IComparer<TRegistro_CadRota >
    {
        #region IComparer<TRegistro_CadRota > Members
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

        public TList_CadRota ()
        { }

        public TList_CadRota (System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadRota  value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadRota  x, TRegistro_CadRota  y)
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

    public class TRegistro_CadRota 
    {
        private decimal? id_rota;
        public decimal? Id_rota
        {
            get { return id_rota; }
            set
            {
                id_rota = value;
                id_rotastr = value.ToString();
            }
        }
        private string id_rotastr;
        public string ID_rotaString
        {
            get { return id_rotastr; }
            set
            {
                id_rotastr = value;
                try
                {
                    id_rota = decimal.Parse(value);
                }
                catch { id_rota = null; }
            }
        }
        public string Ds_rota { get; set; }
        public Financeiro.Cadastros.TList_CadClifor lClifor
        { get; set; }
        public Financeiro.Cadastros.TList_CadClifor lCliforDel
        { get; set; }

        public TRegistro_CadRota ()
        {
            id_rota = null;
            id_rotastr = string.Empty;
            Ds_rota = string.Empty;
            lClifor = new Financeiro.Cadastros.TList_CadClifor();
            lCliforDel = new Financeiro.Cadastros.TList_CadClifor();
        }
    }

    public class TCD_CadRota  : TDataQuery
    {
        public TCD_CadRota()
        { }

        public TCD_CadRota(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + "a.ID_rota, a.ds_rota ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_div_rota a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.ds_rota asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadRota  Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadRota  lista = new TList_CadRota ();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadRota  reg = new TRegistro_CadRota ();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rota")))
                        reg.Id_rota = reader.GetDecimal(reader.GetOrdinal("Id_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rota")))
                        reg.Ds_rota = reader.GetString(reader.GetOrdinal("Ds_rota"));
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

        public string Grava(TRegistro_CadRota  vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ROTA", vRegistro.Id_rota);
            hs.Add("@P_DS_ROTA", vRegistro.Ds_rota);

            return executarProc("IA_DIV_ROTA", hs);
        }

        public void Deleta(TRegistro_CadRota  vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ROTA", vRegistro.Id_rota);

            executarProc("EXCLUI_DIV_ROTA", hs);
        }
    }

}
