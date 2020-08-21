using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_ProgCombustivel : List<TRegistro_ProgCombustivel>, IComparer<TRegistro_ProgCombustivel>
    {
        #region IComparer<TRegistro_ProgCombustivel> Members
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

        public TList_ProgCombustivel()
        { }

        public TList_ProgCombustivel(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProgCombustivel value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProgCombustivel x, TRegistro_ProgCombustivel y)
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

    
    public class TRegistro_ProgCombustivel
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public decimal Pc_desconto
        { get; set; }
        private string tp_desconto;
        
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_desconto = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_desconto = "VALOR";
            }
        }
        private string tipo_desconto;
        
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_desconto = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_desconto = "V";
            }
        }
        private string st_descvlunit;
        
        public string St_descvlunit
        {
            get { return st_descvlunit; }
            set
            {
                st_descvlunit = value;
                st_descvluntibool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_descvluntibool;
        
        public bool St_descvlunitbool
        {
            get { return st_descvluntibool; }
            set
            {
                st_descvluntibool = value;
                st_descvlunit = value ? "S" : "N";
            }
        }

        public TRegistro_ProgCombustivel()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Pc_desconto = decimal.Zero;
            this.tp_desconto = string.Empty;
            this.tipo_desconto = string.Empty;
            this.st_descvlunit = "N";
            this.st_descvluntibool = false;
        }
    }

    public class TCD_ProgCombustivel : TDataQuery
    {
        public TCD_ProgCombustivel()
        { }

        public TCD_ProgCombustivel(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cd_produto, c.ds_produto, a.pc_desconto, ");
                sql.AppendLine("a.tp_desconto, a.st_descvlunit ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_ProgCombustivel a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
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

        public TList_ProgCombustivel Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ProgCombustivel lista = new TList_ProgCombustivel();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProgCombustivel reg = new TRegistro_ProgCombustivel();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_desconto")))
                        reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("pc_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_descvlunit")))
                        reg.St_descvlunit = reader.GetString(reader.GetOrdinal("st_descvlunit"));

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

        public string Gravar(TRegistro_ProgCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_PC_DESCONTO", val.Pc_desconto);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_ST_DESCVLUNIT", val.St_descvlunit);

            return this.executarProc("IA_PDC_PROGCOMBUSTIVEL", hs);
        }

        public string Excluir(TRegistro_ProgCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_PDC_PROGCOMBUSTIVEL", hs);
        }
    }
}
