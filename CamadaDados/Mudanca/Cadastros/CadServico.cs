using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca.Cadastros
{
    #region Cadastro Serviço
    public class TList_CadServico : List<TRegistro_CadServico>, IComparer<TRegistro_CadServico>
    {
        #region IComparer<TRegistro_CadServico> Members
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

        public TList_CadServico()
        { }

        public TList_CadServico(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadServico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadServico x, TRegistro_CadServico y)
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


    public class TRegistro_CadServico
    {
        private decimal? id_servico;

        public decimal? Id_servico
        {
            get { return id_servico; }
            set
            {
                id_servico = value;
                id_servicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_servicostr;

        public string Id_servicostr
        {
            get { return id_servicostr; }
            set
            {
                id_servicostr = value;
                try
                {
                    id_servico = Convert.ToDecimal(value);
                }
                catch
                { id_servico = null; }
            }
        }

        public string Ds_servico
        { get; set; }
        public decimal Vl_servico
        { get; set; }
        public bool St_processar
        { get; set; }



        public TRegistro_CadServico()
        {
            this.id_servico = null;
            this.id_servicostr = string.Empty;
            this.Ds_servico = string.Empty;
            this.Vl_servico = decimal.Zero;
            this.St_processar = false;
        }
    }

    public class TCD_CadServico : TDataQuery
    {
        public TCD_CadServico()
        { }

        public TCD_CadServico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Servico, ");
                sql.AppendLine("a.DS_Servico ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Servicos a ");

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

        public TList_CadServico Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadServico lista = new TList_CadServico();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadServico reg = new TRegistro_CadServico();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Servico")))
                        reg.Id_servico = reader.GetDecimal(reader.GetOrdinal("ID_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("DS_Servico"));

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

        public string Gravar(TRegistro_CadServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_SERVICO", val.Id_servico);
            hs.Add("@P_DS_SERVICO", val.Ds_servico);

            return this.executarProc("IA_MUD_SERVICOS", hs);
        }

        public string Excluir(TRegistro_CadServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_SERVICO", val.Id_servico);

            return this.executarProc("EXCLUI_MUD_SERVICOS", hs);
        }


    }


    #endregion
}
