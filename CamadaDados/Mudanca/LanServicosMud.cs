using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca
{
    #region Serviços Mudança
    public class TList_LanServicosMud : List<TRegistro_LanServicosMud>, IComparer<TRegistro_LanServicosMud>
    {
        #region IComparer<TRegistro_LanServicosMud> Members
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

        public TList_LanServicosMud()
        { }

        public TList_LanServicosMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanServicosMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanServicosMud x, TRegistro_LanServicosMud y)
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


    public class TRegistro_LanServicosMud
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
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
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

        public TRegistro_LanServicosMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.id_servico = null;
            this.id_servicostr = string.Empty;
            this.Ds_servico = string.Empty;
            this.Vl_servico = decimal.Zero;
        }
    }

    public class TCD_LanServicosMud : TDataQuery
    {
        public TCD_LanServicosMud()
        { }

        public TCD_LanServicosMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, ID_Mudanca, a.ID_Servico, b.ds_servico, a.vl_servico ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_ServicosMud a ");
            sql.AppendLine("inner join TB_MUD_Servicos b ");
            sql.AppendLine("on a.ID_Servico = b.ID_Servico ");

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

        public TList_LanServicosMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LanServicosMud lista = new TList_LanServicosMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LanServicosMud reg = new TRegistro_LanServicosMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Servico")))
                        reg.Id_servico = reader.GetDecimal(reader.GetOrdinal("ID_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("ds_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_servico")))
                        reg.Vl_servico = reader.GetDecimal(reader.GetOrdinal("Vl_servico"));


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

        public string Gravar(TRegistro_LanServicosMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_SERVICO", val.Id_servico);
            hs.Add("@P_VL_SERVICO", val.Vl_servico);

            return this.executarProc("IA_MUD_SERVICOSMUD", hs);
        }

        public string Excluir(TRegistro_LanServicosMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_SERVICO", val.Id_servico);

            return this.executarProc("EXCLUI_MUD_SERVICOSMUD", hs);
        }


    }


    #endregion
}
