using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadCidade : List<TRegistro_CadCidade>, IComparer<TRegistro_CadCidade>
    {
        #region IComparer<TRegistro_CadCidade> Members
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

        public TList_CadCidade()
        { }

        public TList_CadCidade(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCidade x, TRegistro_CadCidade y)
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
    
    public class TRegistro_CadCidade
    {
        public string Cd_cidade 
        { get; set; }
        public string Ds_cidade 
        { get; set; }
        private string st_registro;
        public string St_registro 
        {
            get { return st_registro; }
            set 
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set 
            { 
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        public string Cd_uf
        { get; set; }
        public string Ds_uf
        { get; set; }
        public TRegistro_CadUf rUf
        { get; set; }

        public TRegistro_CadCidade()
        {
            this.Cd_cidade = string.Empty;
            this.Ds_cidade = string.Empty;
            this.Cd_uf = string.Empty;
            this.Ds_uf = string.Empty;
            this.rUf = new TRegistro_CadUf();
            this.st_registro = "A";
            this.status = "ATIVO";
        }
    }

    public class TCD_CadCidade : TDataQuery
    {
        public TCD_CadCidade()
        { }

        public TCD_CadCidade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_cidade, a.ds_cidade, ");
                sql.AppendLine("a.cd_uf, a.st_registro, ");
                sql.AppendLine("b.uf, b.ds_uf, b.st_registro as st_uf ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cidade a ");
            sql.AppendLine("left outer join tb_fin_uf b ");
            sql.AppendLine("on b.cd_uf = a.cd_uf ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadCidade Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadCidade lista = new TList_CadCidade();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCidade reg = new TRegistro_CadCidade();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Cidade"))))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Cidade"))))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.rUf.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF")))
                    {
                        reg.rUf.Cd_uf = reader.GetString(reader.GetOrdinal("CD_UF"));
                        reg.Cd_uf = reader.GetString(reader.GetOrdinal("CD_UF"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UF")))
                    {
                        reg.rUf.Ds_uf = reader.GetString(reader.GetOrdinal("DS_UF"));
                        reg.Ds_uf = reader.GetString(reader.GetOrdinal("DS_UF"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_UF")))
                        reg.rUf.St_registro = reader.GetString(reader.GetOrdinal("ST_UF"));

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

        public string Gravar(TRegistro_CadCidade val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);
            hs.Add("@P_DS_CIDADE", val.Ds_cidade);
            hs.Add("@P_CD_UF", val.Cd_uf);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_CIDADE", hs);
        }

        public string Excluir(TRegistro_CadCidade val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);

            return this.executarProc("EXCLUI_FIN_CIDADE", hs);
        }
    }
}
