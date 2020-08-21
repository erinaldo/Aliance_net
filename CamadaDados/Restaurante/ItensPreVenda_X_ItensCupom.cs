using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CamadaDados.Restaurante
{
    public class TRegistro_ItensPreVenda_X_ItensCupom
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal? Id_PreVenda { get; set; } = null;
        public decimal? Id_Registro { get; set; } = null;
        public decimal? Id_Item { get; set; } = null;
        public decimal? Id_LanctoVenda { get; set; } = null;
        public decimal? Id_VendaRapida { get; set; } = null;
        public decimal? Id_NFCE { get; set; } = null;
        public decimal? Id_LanctoNFCe { get; set; } = null;
        
        public TRegistro_ItensPreVenda_X_ItensCupom()
        {
            Cd_Empresa = string.Empty;
            Id_PreVenda = null;
            Id_Registro = null;
            Id_Item = null;
            Id_LanctoVenda = null;
            Id_VendaRapida = null;
            Id_NFCE = null;
            Id_LanctoNFCe = null;
        }
    }

    public class TList_ItensPreVenda_X_ItensCupom : List<TRegistro_ItensPreVenda_X_ItensCupom>
    {
        #region IComparer<TRegistro_ConsultaProduto> Members
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

        public TList_ItensPreVenda_X_ItensCupom()
        { }

        public TList_ItensPreVenda_X_ItensCupom(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensPreVenda_X_ItensCupom value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensPreVenda_X_ItensCupom x, TRegistro_ItensPreVenda_X_ItensCupom y)
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

    public class TCD_ItensPreVenda_X_ItensCupom : TDataQuery
    {
        public TCD_ItensPreVenda_X_ItensCupom() { }

        public TCD_ItensPreVenda_X_ItensCupom(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.Cd_Empresa, a.Id_PreVenda, a.Id_Item, a.Id_LanctoVenda, a.Id_VendaRapida, a.Id_NFCE, a.Id_LanctoNFCe, a.Id_Registro ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_RES_ItensPreVenda_X_ItensCupom a ");

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

        public TList_ItensPreVenda_X_ItensCupom Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ItensPreVenda_X_ItensCupom lista = new TList_ItensPreVenda_X_ItensCupom();
            SqlDataReader reader;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensPreVenda_X_ItensCupom reg = new TRegistro_ItensPreVenda_X_ItensCupom();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_PreVenda")))
                        reg.Id_PreVenda = reader.GetDecimal(reader.GetOrdinal("Id_PreVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Item")))
                        reg.Id_Item = reader.GetDecimal(reader.GetOrdinal("Id_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Registro")))
                        reg.Id_Registro = reader.GetDecimal(reader.GetOrdinal("Id_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoVenda")))
                        reg.Id_LanctoVenda = reader.GetDecimal(reader.GetOrdinal("Id_LanctoVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_VendaRapida")))
                        reg.Id_VendaRapida = reader.GetDecimal(reader.GetOrdinal("Id_VendaRapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_NFCE")))
                        reg.Id_NFCE = reader.GetDecimal(reader.GetOrdinal("Id_NFCE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoNFCe")))
                        reg.Id_LanctoNFCe = reader.GetDecimal(reader.GetOrdinal("Id_LanctoNFCe"));

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

        public string Gravar(TRegistro_ItensPreVenda_X_ItensCupom val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_PreVenda);
            hs.Add("@P_ID_REGISTRO", val.Id_Registro);
            hs.Add("@P_ID_ITEM", val.Id_Item);
            hs.Add("@P_ID_NFCE", val.Id_NFCE);
            hs.Add("@P_ID_LANCTONFCE", val.Id_LanctoNFCe);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_VendaRapida);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_LanctoVenda);

            return this.executarProc("IA_RES_ITENSPREVENDA_X_ITENSCUPOM", hs);
        }

        public string Excluir(TRegistro_ItensPreVenda_X_ItensCupom val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_PreVenda);
            hs.Add("@P_ID_REGISTRO", val.Id_Registro);
            hs.Add("@P_ID_ITEM", val.Id_Item);

            return this.executarProc("EXCLUI_RES_ITENSPREVENDA_X_ITENSCUPOM", hs);
        }
    }

}
