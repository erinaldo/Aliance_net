using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_CfgEmpresa : List<TRegistro_CfgEmpresa> { }
    public class TRegistro_CfgEmpresa
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string Cd_clifor { get; set; } = string.Empty;
        public string Cd_endereco { get; set; } = string.Empty;
        public string CFG_PedRemCargaAvulsa { get; set; } = string.Empty;
        public string Ds_PedRemCargaAvulsa { get; set; } = string.Empty;
        public string CFG_PedVenda { get; set; } = string.Empty;
        public string Ds_PedVenda { get; set; } = string.Empty;
        public string Cd_tabelapreco { get; set; } = string.Empty;
        public string Ds_tabelapreco { get; set; } = string.Empty;
        public string Cd_historico { get; set; } = string.Empty;
        public string Ds_historico { get; set; } = string.Empty;
        private string st_AlocCargaAvPatrimonio;
        public string ST_AlocCargaAvPatrimonio
        {
            get { return st_AlocCargaAvPatrimonio; }
            set
            {
                st_AlocCargaAvPatrimonio = value;
                st_AlocCargaAvPatrimoniobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_AlocCargaAvPatrimoniobool;
        public bool ST_AlocCargaAvPatrimoniobool
        {
            get { return st_AlocCargaAvPatrimoniobool; }
            set
            {
                st_AlocCargaAvPatrimoniobool = value;
                st_AlocCargaAvPatrimonio = value ? "S" : "N";
            }
        }
    }
    public class TCD_CfgEmpresa : TDataQuery
    {
        public TCD_CfgEmpresa() { }
        public TCD_CfgEmpresa(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, b.cd_clifor, b.cd_endereco, ");
                sql.AppendLine("a.CFG_PedRemCargaAvulsa, c.DS_TipoPedido as  Ds_PedRemCargaAvulsa, ");
                sql.AppendLine("a.CFG_PedVenda, d.DS_TipoPedido as Ds_PedVenda, a.ST_AlocCargaAvPatrimonio, ");
                sql.AppendLine("a.cd_tabelapreco, e.ds_tabelapreco, a.cd_historico, f.ds_historico ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_DIV_CFGEmpresa a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left join tb_fat_cfgpedido c ");
            sql.AppendLine("on c.cfg_pedido = a.CFG_PedRemCargaAvulsa ");
            sql.AppendLine("left join tb_fat_cfgpedido d ");
            sql.AppendLine("on d.cfg_pedido = a.CFG_PedVenda ");
            sql.AppendLine("left outer join TB_DIV_TabelaPreco e ");
            sql.AppendLine("on e.cd_tabelapreco = a.cd_tabelapreco ");
            sql.AppendLine("left outer join TB_FIN_Historico f ");
            sql.AppendLine("on f.cd_historico = a.cd_historico ");

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
        public TList_CfgEmpresa Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CfgEmpresa lista = new TList_CfgEmpresa();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgEmpresa reg = new TRegistro_CfgEmpresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("Cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_PedRemCargaAvulsa")))
                        reg.CFG_PedRemCargaAvulsa = reader.GetString(reader.GetOrdinal("CFG_PedRemCargaAvulsa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_PedRemCargaAvulsa")))
                        reg.Ds_PedRemCargaAvulsa = reader.GetString(reader.GetOrdinal("Ds_PedRemCargaAvulsa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_PedVenda")))
                        reg.CFG_PedVenda = reader.GetString(reader.GetOrdinal("CFG_PedVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_PedVenda")))
                        reg.Ds_PedVenda = reader.GetString(reader.GetOrdinal("Ds_PedVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("Cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("Ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("Cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("Ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_AlocCargaAvPatrimonio")))
                        reg.ST_AlocCargaAvPatrimonio = reader.GetString(reader.GetOrdinal("ST_AlocCargaAvPatrimonio"));

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
        public string Gravar(TRegistro_CfgEmpresa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CFG_PEDREMCARGAAVULSA", val.CFG_PedRemCargaAvulsa);
            hs.Add("@P_CFG_PEDVENDA", val.CFG_PedVenda);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_HISTORICO",   val.Cd_historico);
            hs.Add("@P_ST_ALOCCARGAAVPATRIMONIO", val.ST_AlocCargaAvPatrimonio);

            return executarProc("IA_DIV_CFGEMPRESA", hs);
        }
        public string Excluir(TRegistro_CfgEmpresa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_DIV_CFGEMPRESA", hs);
        }
    }
}
