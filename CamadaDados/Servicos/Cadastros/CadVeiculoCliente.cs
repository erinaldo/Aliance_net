using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_VeiculoCliente : List<TRegistro_VeiculoCliente>, IComparer<TRegistro_VeiculoCliente>
    {
        #region IComparer<TRegistro_VeiculoCliente> Members
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

        public TList_VeiculoCliente()
        { }

        public TList_VeiculoCliente(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VeiculoCliente value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VeiculoCliente x, TRegistro_VeiculoCliente y)
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

    public class TRegistro_VeiculoCliente
    {
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Placaveiculo
        { get; set; }
        
        public string Ds_veiculo
        { get; set; }
        
        public decimal Anofabric
        { get; set; }
        
        public string Ds_marca
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                status = value.Trim().ToUpper().Equals("A");
            }
        }
        private bool status;
        
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                st_registro = value ? "A" : "C";
            }
        }
        
        public bool St_processar
        { get; set; }

        public TRegistro_VeiculoCliente()
        {
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Placaveiculo = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Anofabric = decimal.Zero;
            this.Ds_marca = string.Empty;
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = true;
            this.St_processar = false;
        }
    }

    public class TCD_VeiculoCliente : TDataQuery
    {
        public TCD_VeiculoCliente()
        { }

        public TCD_VeiculoCliente(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_clifor, b.nm_clifor, a.placaveiculo, ");
                sql.AppendLine("a.ds_veiculo, a.anofabric, a.ds_marca, a.ds_observacao, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_ose_veiculocliente a ");
            sql.AppendLine("left outer join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");

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

        public TList_VeiculoCliente Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_VeiculoCliente lista = new TList_VeiculoCliente();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_VeiculoCliente reg = new TRegistro_VeiculoCliente();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placaveiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("placaveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("anofabric")))
                        reg.Anofabric = reader.GetDecimal(reader.GetOrdinal("anofabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_VeiculoCliente val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_DS_VEICULO", val.Ds_veiculo);
            hs.Add("@P_ANOFABRIC", val.Anofabric);
            hs.Add("@P_DS_MARCA", val.Ds_marca);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_OSE_VEICULOCLIENTE", hs);
        }

        public string Excluir(TRegistro_VeiculoCliente val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);

            return this.executarProc("EXCLUI_OSE_VEICULOCLIENTE", hs);
        }
    }
}
