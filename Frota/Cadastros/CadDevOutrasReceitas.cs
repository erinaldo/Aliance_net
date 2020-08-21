using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{

    public class TList_DevOutrasReceitas : List<TRegistro_DevOutrasReceitas>, IComparer<TRegistro_DevOutrasReceitas>
    {
        #region IComparer<TRegistro_Despesa> Members
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

        public TList_DevOutrasReceitas()
        { }

        public TList_DevOutrasReceitas(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DevOutrasReceitas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DevOutrasReceitas x, TRegistro_DevOutrasReceitas y)
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

    public class TRegistro_DevOutrasReceitas
    {
        private decimal? id_receita;
        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;
        public string Id_receitaStr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch
                { id_receita = null; }
            }
        }

        public string cd_contager { get; set; }

        private decimal? id_lanctoCaixa;
        public decimal? Id_lanctoCaixa
        {
            get { return id_lanctoCaixa; }
            set
            {
                id_lanctoCaixa = value;
                id_lanctoCaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoCaixastr;
        public string Id_lanctoCaixastr
        {
            get { return id_lanctoCaixastr; }
            set
            {
                id_lanctoCaixastr = value;
                try
                {
                    id_lanctoCaixa = decimal.Parse(value);
                }
                catch
                { id_lanctoCaixa = null; }
            }
        }

        public TRegistro_DevOutrasReceitas()
        {
            this.Id_receitaStr = string.Empty;
            this.id_lanctoCaixastr = string.Empty;
            this.cd_contager = string.Empty;
        }
    }

    public class TCD_DevOutrasReceitas : TDataQuery
    {
        public TCD_DevOutrasReceitas()
        { }

        public TCD_DevOutrasReceitas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_despesa, a.ds_despesa, a.tp_despesa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Despesa a ");

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

        public TList_DevOutrasReceitas Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DevOutrasReceitas lista = new TList_DevOutrasReceitas();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas reg = new CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Id_lanctoCaixastr = reader.GetString(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receita")))
                        reg.Id_receitaStr = reader.GetString(reader.GetOrdinal("id_receita"));

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

        public string Gravar(CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_RECEITA", val.Id_receitaStr);
            hs.Add("@P_CD_CONTAGER", val.cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Id_lanctoCaixastr);

            return this.executarProc("IA_FRT_DEVADTOOUTRASREC", hs);
        }

        public string Excluir(CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_DESPESA", val.Id_receitaStr);

            return this.executarProc("EXCLUI_FRT_DESPESA", hs);
        }
    }
}
