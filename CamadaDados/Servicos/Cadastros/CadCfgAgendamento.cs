using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_CfgAgendamento : List<TRegistro_CfgAgendamento> { }

    public class TRegistro_CfgAgendamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? tp_ordem;
        public decimal? Tp_ordem
        {
            get { return tp_ordem; }
            set
            {
                tp_ordem = value;
                tp_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_ordemstr;
        public string Tp_ordemstr
        {
            get { return tp_ordemstr; }
            set
            {
                tp_ordemstr = value;
                try
                {
                    tp_ordem = decimal.Parse(value);
                }
                catch { tp_ordem = null; }
            }
        }
        public string Ds_tipoordem
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }

        public TRegistro_CfgAgendamento()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.tp_ordem = null;
            this.tp_ordemstr = string.Empty;
            this.Ds_tipoordem = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
        }
    }

    public class TCD_CfgAgendamento : TDataQuery
    {
        public TCD_CfgAgendamento() { }

        public TCD_CfgAgendamento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, b.NM_Empresa, ");
                sql.AppendLine("a.tp_ordem, c.ds_tipoordem, a.cd_tabelapreco, d.ds_tabelapreco, ");
                sql.AppendLine("a.cd_local, e.ds_local ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ose_cfgagendamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_ose_tpordem c ");
            sql.AppendLine("on a.tp_ordem = c.tp_ordem ");
            sql.AppendLine("left outer join tb_div_tabelapreco d ");
            sql.AppendLine("on a.cd_tabelapreco = d.cd_tabelapreco ");
            sql.AppendLine("left outer join tb_est_localarm e ");
            sql.AppendLine("on a.cd_local = e.cd_local ");

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

        public TList_CfgAgendamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgAgendamento lista = new TList_CfgAgendamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CfgAgendamento reg = new TRegistro_CfgAgendamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("tp_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoordem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_tipoordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));

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

        public string Gravar(TRegistro_CfgAgendamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_LOCAL", val.Cd_local);

            return this.executarProc("IA_OSE_CFGAGENDAMENTO", hs);
        }

        public string Excluir(TRegistro_CfgAgendamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_OSE_CFGAGENDAMENTO", hs);
        }
    }
}
