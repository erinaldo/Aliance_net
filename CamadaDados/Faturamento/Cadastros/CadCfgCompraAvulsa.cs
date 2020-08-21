using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CfgCompraAvulsa : List<TRegistro_CfgCompraAvulsa>, IComparer<TRegistro_CfgCompraAvulsa>
    {
        #region IComparer<TRegistro_CfgCompraAvulsa> Members
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

        public TList_CfgCompraAvulsa()
        { }

        public TList_CfgCompraAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgCompraAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgCompraAvulsa x, TRegistro_CfgCompraAvulsa y)
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
    
    public class TRegistro_CfgCompraAvulsa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        private decimal? id_almox;

        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = id_almox.HasValue ? id_almox.ToString() : string.Empty;
            }
        }

        private string id_almoxstr;

        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = decimal.Parse(value);
                }
                catch
                { id_almox = null; }
            }
        }

        public string Ds_almox
        { get; set; }

        public TRegistro_CfgCompraAvulsa()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cfg_pedido = string.Empty;
            this.Ds_tipopedido = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.id_almox = null;
            this.id_almoxstr = string.Empty;
            this.Ds_almox = string.Empty;
        }
    }

    public class TCD_CfgCompraAvulsa : TDataQuery
    {
        public TCD_CfgCompraAvulsa()
        { }

        public TCD_CfgCompraAvulsa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cfg_pedido, c.ds_tipopedido, a.cd_local, d.ds_local, a.id_almox, e.ds_almoxarifado  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_cfgcompraavulsa a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fat_cfgpedido c ");
            sql.AppendLine("on a.cfg_pedido = c.cfg_pedido ");
            sql.AppendLine("left outer join tb_est_localarm d ");
            sql.AppendLine("on a.cd_local = d.cd_local ");
            sql.AppendLine("left outer join TB_AMX_ALMOXARIFADO e ");
            sql.AppendLine("on e.id_almox = a.id_almox ");

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

        public TList_CfgCompraAvulsa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CfgCompraAvulsa lista = new TList_CfgCompraAvulsa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CfgCompraAvulsa reg = new TRegistro_CfgCompraAvulsa();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_almoxarifado")))
                        reg.Ds_almox = reader.GetString(reader.GetOrdinal("ds_almoxarifado"));

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

        public string Gravar(TRegistro_CfgCompraAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ID_ALMOX", val.Id_almox);

            return this.executarProc("IA_FAT_CFGCOMPRAAVULSA", hs);
        }

        public string Excluir(TRegistro_CfgCompraAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_CFGCOMPRAAVULSA", hs);
        }
    }
}
