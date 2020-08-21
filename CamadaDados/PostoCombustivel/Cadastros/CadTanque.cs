using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_TanqueCombustivel : List<TRegistro_TanqueCombustivel>, IComparer<TRegistro_TanqueCombustivel>
    {
        #region IComparer<TRegistro_TanqueCombustivel> Members
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

        public TList_TanqueCombustivel()
        { }

        public TList_TanqueCombustivel(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TanqueCombustivel value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TanqueCombustivel x, TRegistro_TanqueCombustivel y)
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

    
    public class TRegistro_TanqueCombustivel
    {
        private decimal? id_tanque;
        
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch
                { id_tanque = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidproduto
        { get; set; }
        
        public string Ds_unidproduto
        { get; set; }
        
        public string Sg_produto
        { get; set; }
        
        public decimal Capacidadetanque
        { get; set; }
        
        public decimal Saldo_tanque
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        private DateTime? dt_desativacao;
        
        public DateTime? Dt_desativacao
        {
            get { return dt_desativacao; }
            set
            {
                dt_desativacao = value;
                dt_desativacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_desativacaostr;
        public string Dt_desativacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_desativacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_desativacaostr = value;
                try
                {
                    dt_desativacao = DateTime.Parse(value);
                }
                catch
                { dt_desativacao = null; }
            }
        }
        private DateTime? dt_ativacao;
        
        public DateTime? Dt_ativacao
        {
            get { return dt_ativacao; }
            set
            {
                dt_ativacao = value;
                dt_ativacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_ativacaostr;
        public string Dt_ativacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_ativacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ativacaostr = value;
                try
                {
                    dt_ativacao = DateTime.Parse(value);
                }
                catch
                { dt_ativacao = null; }
            }
        }
        
        public bool St_processar
        { get; set; }
        
        public TRegistro_TanqueCombustivel()
        {
            this.id_tanque = null;
            this.id_tanquestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidproduto = string.Empty;
            this.Ds_unidproduto = string.Empty;
            this.Sg_produto = string.Empty;
            this.Capacidadetanque = decimal.Zero;
            this.Saldo_tanque = decimal.Zero;
            this.St_processar = false;
            this.St_registro = "A";
            this.dt_desativacao = null;
            this.dt_desativacaostr = string.Empty;
            this.dt_ativacao = null;
            this.dt_ativacaostr = string.Empty;
        }
    }

    public class TCD_TanqueCombustivel : TDataQuery
    {
        public TCD_TanqueCombustivel()
        { }

        public TCD_TanqueCombustivel(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_tanque, a.cd_empresa, ");
                sql.AppendLine("b.NM_Empresa, a.cd_local, c.DS_Local, a.st_registro, ");
                sql.AppendLine("a.capacidadetanque, a.cd_produto, a.dt_desativacao, ");
                sql.AppendLine("e.ds_produto, e.cd_unidade as cd_unidproduto, a.dt_ativacao, ");
                sql.AppendLine("f.ds_unidade as ds_undproduto, f.sigla_unidade as sg_produto, ");
                sql.AppendLine("saldo_tanque = (select x.Tot_Saldo ");
                sql.AppendLine("				from VTB_EST_VLESTOQUELOCAL x ");
                sql.AppendLine("				where x.cd_empresa = a.CD_Empresa ");
                sql.AppendLine("				and x.cd_produto = a.CD_Produto ");
                sql.AppendLine("				and x.cd_local = a.CD_Local ) ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_pdc_tanque a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_LocalArm c ");
            sql.AppendLine("on a.cd_local = c.CD_Local ");
            sql.AppendLine("inner join TB_EST_Produto e ");
            sql.AppendLine("on a.cd_produto = e.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade f ");
            sql.AppendLine("on e.cd_unidade = f.cd_unidade ");
            sql.AppendLine("inner join TB_EST_TpProduto g ");
            sql.AppendLine("on e.tp_produto = g.tp_produto ");
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

        public TList_TanqueCombustivel Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_TanqueCombustivel lista = new TList_TanqueCombustivel();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TanqueCombustivel reg = new TRegistro_TanqueCombustivel();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidproduto")))
                        reg.Cd_unidproduto = reader.GetString(reader.GetOrdinal("cd_unidproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_undproduto")))
                        reg.Ds_unidproduto = reader.GetString(reader.GetOrdinal("ds_undproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_produto")))
                        reg.Sg_produto = reader.GetString(reader.GetOrdinal("sg_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapacidadeTanque")))
                        reg.Capacidadetanque = reader.GetDecimal(reader.GetOrdinal("CapacidadeTanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("saldo_tanque")))
                        reg.Saldo_tanque = reader.GetDecimal(reader.GetOrdinal("saldo_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_desativacao")))
                        reg.Dt_desativacao = reader.GetDateTime(reader.GetOrdinal("dt_desativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ativacao")))
                        reg.Dt_ativacao = reader.GetDateTime(reader.GetOrdinal("dt_ativacao"));

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

        public string Gravar(TRegistro_TanqueCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_TANQUE", val.Id_tanque);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CAPACIDADETANQUE", val.Capacidadetanque);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DT_ATIVACAO", val.Dt_ativacao);
            hs.Add("@P_DT_DESATIVACAO", val.Dt_desativacao);

            return this.executarProc("IA_PDC_TANQUE", hs);
        }

        public string Excluir(TRegistro_TanqueCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TANQUE", val.Id_tanque);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDC_TANQUE", hs);
        }
    }
}
