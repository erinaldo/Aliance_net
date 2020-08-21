using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Contabil
{
    public class TList_LanctoAvulso : List<TRegistro_LanctoAvulso>, IComparer<TRegistro_LanctoAvulso>
    {
        #region IComparer<TRegistro_LanctoAvulso> Members
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

        public TList_LanctoAvulso()
        { }

        public TList_LanctoAvulso(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanctoAvulso value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanctoAvulso x, TRegistro_LanctoAvulso y)
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
    
    public class TRegistro_LanctoAvulso
    {
        private decimal? id_lan;
        public decimal? Id_lan
        {
            get { return id_lan; }
            set
            {
                id_lan = value;
                id_lanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanstr;
        public string Id_lanstr
        {
            get { return id_lanstr; }
            set
            {
                id_lanstr = value;
                try
                {
                    id_lan = Convert.ToDecimal(value);
                }
                catch
                { id_lan = null; }
            }
        }
        private decimal? id_reg;
        public decimal? Id_reg
        {
            get { return id_reg; }
            set
            {
                id_reg = value;
                id_regstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_regstr;
        public string Id_regstr
        {
            get { return id_regstr; }
            set
            {
                id_regstr = value;
                try
                {
                    id_reg = Convert.ToDecimal(value);
                }
                catch
                { id_reg = null; }
            }
        }
        private decimal? cd_conta_ctb;
        public decimal? Cd_conta_ctb
        {
            get { return cd_conta_ctb; }
            set
            {
                cd_conta_ctb = value;
                cd_conta_ctbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_conta_ctbstr;
        public string Cd_conta_ctbstr
        {
            get { return cd_conta_ctbstr; }
            set
            {
                cd_conta_ctbstr = value;
                try
                {
                    cd_conta_ctb = Convert.ToDecimal(value);
                }
                catch
                { cd_conta_ctb = null; }
            }
        }
        public string Ds_conta_ctb
        { get; set; }
        public string Cd_classificacao_ctb
        { get; set; }
        public decimal Vl_lancto
        { get; set; }
        private string d_c;
        public string D_C
        {
            get { return d_c; }
            set
            {
                d_c = value;
                if (value.Trim().ToUpper().Equals("D"))
                    debito_credito = "DEBITO";
                else if (value.Trim().ToUpper().Equals("C"))
                    debito_credito = "CREDITO";
            }
        }
        private string debito_credito;
        public string Debito_Credito
        {
            get { return debito_credito; }
            set
            {
                debito_credito = value;
                if (debito_credito.Trim().ToUpper().Equals("DEBITO"))
                    d_c = "D";
                else if (value.Trim().ToUpper().Equals("CREDITO"))
                    d_c = "C";
            }
        }

        public TRegistro_LanctoAvulso()
        {
            this.Cd_classificacao_ctb = string.Empty;
            this.cd_conta_ctb = null;
            this.cd_conta_ctbstr = string.Empty;
            this.d_c = string.Empty;
            this.debito_credito = string.Empty;
            this.Ds_conta_ctb = string.Empty;
            this.id_lan = null;
            this.id_lanstr = string.Empty;
            this.id_reg = null;
            this.id_regstr = string.Empty;
            this.Vl_lancto = decimal.Zero;
        }
    }

    public class TCD_LanctoAvulso : TDataQuery
    {
        public TCD_LanctoAvulso()
        { }

        public TCD_LanctoAvulso(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.Id_Lan, a.ID_Reg, a.CD_Conta_CTB, ");
                sql.AppendLine("b.DS_ContaCTB, b.CD_Classificacao, a.VL_Lancto, a.D_C ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_LanctoAvulso a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on a.CD_Conta_CTB = b.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable  Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
 	        return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable  Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
 	        return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object  BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
 	        return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanctoAvulso Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanctoAvulso lista = new TList_LanctoAvulso();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanctoAvulso reg = new TRegistro_LanctoAvulso();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lan")))
                        reg.Id_lan = reader.GetDecimal(reader.GetOrdinal("ID_Lan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Reg")))
                        reg.Id_reg = reader.GetDecimal(reader.GetOrdinal("ID_Reg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB")))
                        reg.Ds_conta_ctb = reader.GetString(reader.GetOrdinal("DS_ContaCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao")))
                        reg.Cd_classificacao_ctb = reader.GetString(reader.GetOrdinal("CD_Classificacao"));
                    if(!reader.IsDBNull(reader.GetOrdinal("VL_Lancto")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));
                    if(!reader.IsDBNull(reader.GetOrdinal("D_C")))
                        reg.D_C = reader.GetString(reader.GetOrdinal("D_C"));
                    
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_LanctoAvulso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LAN", val.Id_lan);
            hs.Add("@P_ID_REG", val.Id_reg);
            hs.Add("@P_CD_CONTA_CTB", val.Cd_conta_ctb);
            hs.Add("@P_VL_LANCTO", val.Vl_lancto);
            hs.Add("@P_D_C", val.D_C);

            return this.executarProc("IA_CTB_LANCTOAVULSO", hs);
        }

        public string Excluir(TRegistro_LanctoAvulso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LAN", val.Id_lan);
            hs.Add("@P_ID_REG", val.Id_reg);

            return this.executarProc("EXCLUI_CTB_LANCTOAVULSO", hs);
        }
    }
}
