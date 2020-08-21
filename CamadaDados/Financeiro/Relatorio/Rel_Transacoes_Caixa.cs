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
    public class TCD_Rel_Transacoes_Caixa : TDataQuery
    {
        public TCD_Rel_Transacoes_Caixa()
        { }

        public TCD_Rel_Transacoes_Caixa(string vNM_Proc)
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
                sql.AppendLine(" Select "+ strTop +" a.Cd_ContaGer, a.Cd_lanctoCaixa, a.Cd_Empresa, b.nm_empresa, a.Tp_Docto, a.Nr_Docto, ");
                sql.AppendLine(" a.Cd_Historico, c.ds_historico, ");
                sql.AppendLine(" a.Id_LoteCtB, a.ComplHistorico, a.DT_Lancto, a.Vl_Pagar, ");
                sql.AppendLine(" a.VL_Receber, a.Vl_Anterior, a.Vl_Atual, a.ST_Titulo, a.ST_Estorno ");

            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine(" from tb_fin_caixa a ");
            sql.AppendLine(" left outer join TB_Div_Empresa b on (a.cd_Empresa = b.cd_empresa) ");
            sql.AppendLine(" left outer join Tb_Fin_Historico c on (a.cd_historico = c.cd_historico) ");


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

        private string SqlCodeBusca_Saldo_Anterior(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
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
                sql.AppendLine("Select " + strTop + " max(a.dt_lancto) as Ultima_Data , sum(a.vl_receber) - sum(a.vl_pagar) as Vl_Saldo "); 
                
                
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine("From TB_fin_Caixa A");
            
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
