using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_CfgECommerce : List<TRegistro_CfgECommerce> { }
    public class TRegistro_CfgECommerce
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        private decimal? id_categoriaclifor = null;
        public decimal? Id_categoriaclifor
        {
            get { return id_categoriaclifor; }
            set
            {
                id_categoriaclifor = value;
                id_categoriacliforstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_categoriacliforstr = string.Empty;
        public string Id_categoriacliforstr
        {
            get { return id_categoriacliforstr; }
            set
            {
                id_categoriacliforstr = value;
                try
                {
                    id_categoriaclifor = decimal.Parse(value);
                }
                catch { id_categoriaclifor = null; }
            }
        }
        public string Ds_categoriaclifor { get; set; } = string.Empty;
        public string Cd_condfiscal_clifor { get; set; } = string.Empty;
        public string Ds_condfiscal_clifor { get; set; } = string.Empty;
        public string Cd_condfiscal_cliforCF { get; set; } = string.Empty;
        public string Ds_condfiscal_cliforCF { get; set; } = string.Empty;
        public string Cfg_pedido { get; set; } = string.Empty;
        public string Ds_tipopedido { get; set; } = string.Empty;
        public string Cd_moeda { get; set; } = string.Empty;
        public string Ds_moeda { get; set; } = string.Empty;
        public string Cd_local { get; set; } = string.Empty;
        public string Ds_local { get; set; } = string.Empty;
        public decimal Tmp_integraestoque { get; set; } = decimal.Zero;
        public decimal Tmp_integrapedido { get; set; } = decimal.Zero;
    }
    public class TCD_CfgECommerce:TDataQuery
    {
        public TCD_CfgECommerce() { }
        public TCD_CfgECommerce(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_CategoriaClifor, c.DS_CategoriaClifor, ");
                sql.AppendLine("a.Cd_CondFiscal_Clifor, d.DS_CondFiscal, ");
                sql.AppendLine("a.Cd_CondFiscal_CliforCF, h.Ds_CondFiscal as Ds_CondFiscalCF, ");
                sql.AppendLine("a.cfg_pedido, e.ds_tipopedido, ");
                sql.AppendLine("a.cd_moeda, f.ds_moeda_singular, ");
                sql.AppendLine("a.cd_local, g.ds_local, ");
                sql.AppendLine("a.TMP_IntegraEstoque, a.tmp_integrapedido ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_div_cfgecommerce a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left join TB_FIN_CategoriaClifor c ");
            sql.AppendLine("on a.ID_CategoriaClifor = c.ID_CategoriaClifor ");
            sql.AppendLine("left join TB_FIS_CondFiscal_Clifor d ");
            sql.AppendLine("on a.Cd_CondFiscal_Clifor = d.Cd_CondFiscal_Clifor ");
            sql.AppendLine("left join tb_fat_cfgpedido e ");
            sql.AppendLine("on a.cfg_pedido = e.cfg_pedido ");
            sql.AppendLine("left join tb_fin_moeda f ");
            sql.AppendLine("on a.cd_moeda = f.cd_moeda ");
            sql.AppendLine("left join tb_est_localarm g ");
            sql.AppendLine("on a.cd_local = g.CD_Local ");
            sql.AppendLine("left outer join TB_FIS_CondFiscal_Clifor h ");
            sql.AppendLine("on a.Cd_CondFiscal_CliforCF = h.Cd_CondFiscal_Clifor ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_CfgECommerce Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CfgECommerce lista = new TList_CfgECommerce();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgECommerce reg = new TRegistro_CfgECommerce();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CategoriaClifor")))
                        reg.Id_categoriaclifor = reader.GetDecimal(reader.GetOrdinal("ID_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CategoriaClifor")))
                        reg.Ds_categoriaclifor = reader.GetString(reader.GetOrdinal("DS_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal")))
                        reg.Ds_condfiscal_clifor = reader.GetString(reader.GetOrdinal("DS_CondFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_CliforCF")))
                        reg.Cd_condfiscal_cliforCF = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_CliforCF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_CondFiscalCF")))
                        reg.Ds_condfiscal_cliforCF = reader.GetString(reader.GetOrdinal("Ds_CondFiscalCF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("cd_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moeda_singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TMP_IntegraEstoque")))
                        reg.Tmp_integraestoque = reader.GetDecimal(reader.GetOrdinal("TMP_IntegraEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_integrapedido")))
                        reg.Tmp_integrapedido = reader.GetDecimal(reader.GetOrdinal("tmp_integrapedido"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }
        public string Gravar(TRegistro_CfgECommerce val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_categoriaclifor);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.Cd_condfiscal_clifor);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_TMP_INTEGRAESTOQUE", val.Tmp_integraestoque);
            hs.Add("@P_TMP_INTEGRAPEDIDO", val.Tmp_integrapedido);
            hs.Add("@P_CD_CONDFISCAL_CLIFORCF", val.Cd_condfiscal_cliforCF);

            return executarProc("IA_DIV_CFGECOMMERCE", hs);
        }
        public string Excluir(TRegistro_CfgECommerce val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_DIV_CFGECOMMERCE", hs);
        }
    }
}
