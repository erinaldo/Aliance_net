using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca
{
    #region Mudanca_X_NFSe
    public class TList_Mudanca_X_NFSe : List<TRegistro_Mudanca_X_NFSe>, IComparer<TRegistro_Mudanca_X_NFSe>
    {
        #region IComparer<TRegistro_Mudanca_X_NFSe> Members
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

        public TList_Mudanca_X_NFSe()
        { }

        public TList_Mudanca_X_NFSe(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Mudanca_X_NFSe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Mudanca_X_NFSe x, TRegistro_Mudanca_X_NFSe y)
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


    public class TRegistro_Mudanca_X_NFSe
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;

        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;

        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = decimal.Parse(value);
                }
                catch
                { id_mudanca = null; }

            }
        }
        public decimal? Nr_LanctoFiscal
        { get; set; }


        public TRegistro_Mudanca_X_NFSe()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.Id_mudancastr = string.Empty;
            this.Nr_LanctoFiscal = null;
        }
    }

    public class TCD_Mudanca_X_NFSe : TDataQuery
    {
        public TCD_Mudanca_X_NFSe()
        { }

        public TCD_Mudanca_X_NFSe(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, a.Nr_LanctoFiscal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Mudanca_X_NFSe a ");


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

        public TList_Mudanca_X_NFSe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Mudanca_X_NFSe lista = new TList_Mudanca_X_NFSe();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Mudanca_X_NFSe reg = new TRegistro_Mudanca_X_NFSe();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));

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

        public string Gravar(TRegistro_Mudanca_X_NFSe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_LanctoFiscal);


            return this.executarProc("IA_MUD_MUDANCA_X_NFSE", hs);
        }

        public string Excluir(TRegistro_Mudanca_X_NFSe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_LanctoFiscal);


            return this.executarProc("EXCLUI_MUD_MUDANCA_X_NFSE", hs);
        }
    }
    #endregion
}
