using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;


namespace CamadaDados.Financeiro.Relatorio
{
    public class TCD_Rel_Cheques : TDataQuery
    {
        public TCD_Rel_Cheques()
        { }

        public TCD_Rel_Cheques(string vNM_Proc)
        {
            this.NM_ProcSqlBusca = vNM_Proc;
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, "", "", "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, "", "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, "", "" }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (NM_ProcSqlBusca.Trim() == "")
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
            {
                strTop = "TOP " + Convert.ToString(vTop);
            }
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" Select " + strTop + "  a.cd_empresa, b.nm_empresa, a.nr_lanctoCheque, a.Cd_banco, c.ds_banco, ");
                sql.AppendLine(" a.NR_Cheque, a.NR_CGCCPF, a.TP_Titulo, a.NomeBanco, a.DT_Emissao, a.DT_Vencto, ");
                sql.AppendLine(" a.DT_Compensacao, a.VL_Titulo, a.Observacao, a.NomeClifor, a.Fone, ");
                sql.AppendLine(" a.Status_Compensado, a.st_Impresso, a.cd_portador, a.cd_historico ");
                
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine(" from TB_fin_titulo a ");
            sql.AppendLine(" left outer join tb_div_Empresa b on (a.cd_empresa = b.cd_Empresa) ");
            sql.AppendLine(" left outer join tb_fin_banco c on (a.cd_banco = c.cd_banco) ");


            if (vBusca != null)
            {
                cond = " where ";
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            }

            if (vGroup.Trim() != "")
                sql.AppendLine(" Group By " + vGroup);
            if (vOrder.Trim() != "")
                sql.AppendLine(" Order By " + vOrder);

            return sql.ToString();
        }

    }
}
