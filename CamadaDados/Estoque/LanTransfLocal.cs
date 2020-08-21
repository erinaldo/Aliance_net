using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque
{
    public class TList_TransfLocal : List<TRegistro_TransfLocal>, IComparer<TRegistro_TransfLocal>
    {
        #region IComparer<TRegistro_TransfLocal> Members
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

        public TList_TransfLocal()
        { }

        public TList_TransfLocal(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TransfLocal value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TransfLocal x, TRegistro_TransfLocal y)
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

    
    public class TRegistro_TransfLocal
    {
        
        public decimal? Id_transf
        { get; set; }
        
        public string Ds_transf
        { get; set; }
        private DateTime? dt_lancto;
        
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }

        //Campos utilizados para gravar
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public string Cd_localorigem
        { get; set; }
        
        public string Ds_localorigem
        { get; set; }
        
        public string Cd_localdestino
        { get; set; }
        
        public string Ds_localdestino
        { get; set; }
        
        public string Cd_empresaorigem
        { get; set; }
        
        public string Nm_empresaorigem
        { get; set; }
        
        public string Cd_empresadestino
        { get; set; }
        
        public string Nm_empresadestino
        { get; set; }
        
        public string Ds_observacao
        { get; set; }

        
        public TList_RegLanEstoque lEstTransf
        { get; set; }

        public TRegistro_TransfLocal()
        {
            this.Id_transf = null;
            this.Ds_transf = string.Empty;
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Cd_localorigem = string.Empty;
            this.Ds_localorigem = string.Empty;
            this.Cd_localdestino = string.Empty;
            this.Ds_localdestino = string.Empty;
            this.Cd_empresaorigem = string.Empty;
            this.Nm_empresaorigem = string.Empty;
            this.Cd_empresadestino = string.Empty;
            this.Nm_empresadestino = string.Empty;
            this.Ds_observacao = string.Empty;
            this.lEstTransf = new TList_RegLanEstoque();
        }
    }

    public class TCD_TransfLocal : TDataQuery
    {
        public TCD_TransfLocal()
        { }

        public TCD_TransfLocal(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP" + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNm_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.ID_Transf, a.DS_Transf, a.DT_Lancto ");
            else
                sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
            sql.AppendLine("from TB_EST_TransfLocal a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TransfLocal Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TransfLocal lista = new TList_TransfLocal();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TransfLocal reg = new TRegistro_TransfLocal();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("id_transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_transf")))
                        reg.Ds_transf = reader.GetString(reader.GetOrdinal("ds_transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));

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

        public string Gravar(TRegistro_TransfLocal val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TRANSF", val.Id_transf);
            hs.Add("@P_DS_TRANSF", val.Ds_transf);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);

            return this.executarProc("IA_EST_TRANSFLOCAL", hs);
        }

        public string Excluir(TRegistro_TransfLocal val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TRANSF", val.Id_transf);

            return this.executarProc("EXCLUI_EST_TRANSFLOCAL", hs);
        }
    }
}
