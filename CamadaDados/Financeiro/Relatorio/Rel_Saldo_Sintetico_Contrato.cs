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
    public class TCD_Rel_Saldo_Sintetico_Contrato : TDataQuery
    {
        public TCD_Rel_Saldo_Sintetico_Contrato()
        { }

        public TCD_Rel_Saldo_Sintetico_Contrato(string vNM_Proc)
        {
            this.NM_ProcSqlBusca = vNM_Proc;
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return ExecutarBusca(SqlCodeBusca_Saldo_Sintetico_Contrato(vBusca, vTop, "", "", ""), null);
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
                return this.ExecutarBusca(this.SqlCodeBusca_Saldo_Sintetico_Contrato(vBusca, vTop, vNM_Campo, "", ""), null);
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
                return this.ExecutarBusca(this.SqlCodeBusca_Saldo_Sintetico_Contrato(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
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
                return ExecutarBuscaEscalar(SqlCodeBusca_Saldo_Sintetico_Contrato(vBusca, 1, vNM_Campo, "", ""), null);
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
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca_Saldo_Sintetico_Contrato(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
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

        private string SqlCodeBusca_Saldo_Sintetico_Contrato(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
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
                sql.AppendLine(" Select " + strTop + "   a.cd_clifor, c.nm_clifor, g.Sigla, a.vl_contrato, ");
                sql.AppendLine(" vl_faturado = isnull((select sum(isnull(b.vl_documento,0)) from tb_fin_faturacontrato b  ");
                sql.AppendLine("                where b.nr_contrato = a.nr_contrato),0), ");
                
                sql.AppendLine(" vl_impostos_retidos = isnull((select round(sum(isnull(vl_imposto,0) * isnull(pc_retencao,0) /100),2)  ");
                sql.AppendLine("                        from TB_FIN_FaturaContrato_X_Impostos b ");
                sql.AppendLine("                        where b.nr_contrato = a.nr_contrato ),0), ");

                sql.AppendLine(" vl_impostos_recolhidos = isnull((select round(sum(isnull(vl_imposto,0)) ,2)  ");
                sql.AppendLine("                        from TB_FIN_FaturaContrato_X_Impostos b ");
                sql.AppendLine("                        where b.nr_contrato = a.nr_contrato ),0), ");

                sql.AppendLine(" vl_finan_pagar = isnull((select sum( isnull(k.vl_rateio,0)  ) "); 
                sql.AppendLine("                   from tb_fin_contrato_x_duplicata k ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = k.cd_empresa and d.nr_lancto = k.nr_lancto ");
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and t.tp_mov = 'P' ");
                sql.AppendLine("                   ),0), ");

                sql.AppendLine(" vl_finan_pagar_quitado = isnull((select sum(isnull(p.vl_liquidacao_padrao,0)) ");
                sql.AppendLine("                   from tb_fin_liquidacao p ");
                sql.AppendLine("                   join tb_fin_contrato_x_duplicata k  on k.cd_empresa = p.cd_empresa and k.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = p.cd_empresa and d.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and p.st_registro <> 'C' ");
                sql.AppendLine("                     and t.tp_mov = 'P' ");
                sql.AppendLine("                   ),0), ");

                sql.AppendLine(" vl_finan_atualpagar = isnull((select sum( isnull(DBO.F_CALC_ATUAL(p.CD_Empresa, p.Nr_Lancto, p.Cd_Parcela, Getdate(), 'N' ),0)  ) ");
                sql.AppendLine("                   from tb_fin_parcela p ");
                sql.AppendLine("                   join tb_fin_contrato_x_duplicata k  on k.cd_empresa = p.cd_empresa and k.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = p.cd_empresa and d.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and t.tp_mov = 'P' ");
                sql.AppendLine("                   ),0), ");

                sql.AppendLine(" vl_finan_receber = isnull((select sum( isnull(k.vl_rateio,0)  ) ");
                sql.AppendLine("                   from tb_fin_parcela p ");
                sql.AppendLine("                   join tb_fin_contrato_x_duplicata k  on k.cd_empresa = p.cd_empresa and k.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = p.cd_empresa and d.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and t.tp_mov = 'R' ");
                sql.AppendLine("                   ),0), ");

                sql.AppendLine(" vl_finan_receber_quitado = isnull((select sum(isnull(p.vl_liquidacao_padrao,0)) ");
                sql.AppendLine("                   from tb_fin_liquidacao p ");
                sql.AppendLine("                   join tb_fin_contrato_x_duplicata k  on k.cd_empresa = p.cd_empresa and k.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = p.cd_empresa and d.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and p.st_registro <> 'C' ");
                sql.AppendLine("                     and t.tp_mov = 'R' ");
                sql.AppendLine("                   ),0),");

                sql.AppendLine(" vl_finan_atualreceber = isnull((select sum( isnull(DBO.F_CALC_ATUAL(p.CD_Empresa, p.Nr_Lancto, p.Cd_Parcela, Getdate(), 'N' ),0)  ) ");
                sql.AppendLine("                   from tb_fin_parcela p ");
                sql.AppendLine("                   join tb_fin_contrato_x_duplicata k  on k.cd_empresa = p.cd_empresa and k.nr_lancto = p.nr_lancto ");
                sql.AppendLine("                   join tb_fin_duplicata d on d.cd_empresa = p.cd_empresa and d.nr_lancto = p.nr_lancto "); 
                sql.AppendLine("                   join tb_fin_tpduplicata t on t.tp_duplicata = d.tp_duplicata ");
                sql.AppendLine("                   where k.nr_contrato = a.nr_contrato ");
                sql.AppendLine("                     and d.st_registro = 'A' ");
                sql.AppendLine("                     and t.tp_mov = 'R' ");
                sql.AppendLine("                   ),0) ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine(" from tb_fin_Contrato a ");
            sql.AppendLine(" left outer join tb_div_empresa b on (b.cd_empresa = a.cd_empresa) ");
            sql.AppendLine(" left outer join tb_fin_Clifor c on (c.cd_clifor = a.cd_clifor) "); 
            sql.AppendLine(" left outer join tb_fin_endereco d on (d.cd_endereco = a.cd_endereco and d.cd_clifor = a.cd_clifor) ");
            sql.AppendLine(" left outer join tb_fin_Cidade e on (e.cd_Cidade = d.cd_cidade) ");
            sql.AppendLine(" left outer join tb_fin_uf f on (f.UF = e.UF) ");
            sql.AppendLine(" left outer join tb_fin_moeda g on (g.cd_moeda = a.cd_moeda) ");
           
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
