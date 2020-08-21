using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Balanca;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_RegLanAplicacao_NotaFiscal : List<TRegistro_LanAplicacao_NotaFiscal>
    { }
    
    public class TRegistro_LanAplicacao_NotaFiscal
    {
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set 
            { 
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set 
            { 
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }
        private decimal? id_aplicacao;
        public decimal? Id_aplicacao
        {
            get { return id_aplicacao; }
            set 
            { 
                id_aplicacao = value;
                id_aplicacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_aplicacaostr;
        public string Id_aplicacaostr
        {
            get { return id_aplicacaostr; }
            set
            {
                id_aplicacaostr = value;
                try
                {
                    id_aplicacao = decimal.Parse(value);
                }
                catch { id_aplicacao = null; }
            }
        }
        private decimal? nr_notafiscal;
        public decimal? Nr_notafiscal
        {
            get { return nr_notafiscal; }
            set 
            { 
                nr_notafiscal = value;
                nr_notafiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_notafiscalstr;
        public string Nr_notafiscalstr
        {
            get { return nr_notafiscalstr; }
            set
            {
                nr_notafiscalstr = value;
                try
                {
                    nr_notafiscal = decimal.Parse(value);
                }
                catch { nr_notafiscal = null; }
            }
        }
        public string Nr_serie
        { get; set; }

        public TRegistro_LanAplicacao_NotaFiscal()
        {
            this.Cd_empresa = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.id_aplicacao = null;
            this.id_aplicacaostr = string.Empty;
            this.nr_notafiscal = null;
            this.nr_notafiscalstr = string.Empty;
            this.Nr_serie = string.Empty;
        }
    }

    public class TCD_LanAplicacao_NotaFiscal : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.NR_LanctoFiscal, a.ID_NFItem, ");
                sql.AppendLine("a.ID_Aplicacao, ");
                sql.AppendLine("NR_NotaFiscal = (select x.NR_NotaFiscal ");
                sql.AppendLine("                    From TB_FAT_NotaFiscal x ");
                sql.AppendLine("                    Where x.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("                    and x.NR_LanctoFiscal = a.NR_LanctoFiscal), ");
                sql.AppendLine("NR_Serie = (select NR_Serie ");
                sql.AppendLine("                From TB_FAT_NotaFiscal x ");
                sql.AppendLine("                Where x.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("                and x.NR_LanctoFiscal = a.NR_LanctoFiscal) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("From TB_FAT_Aplicacao_X_NotaFiscal a ");
            string cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine(" Group By " + vGroup);
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" Order By " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
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
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
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
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
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
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBuscaEscalar(sql, vParametros);
            }
        }

        public TList_RegLanAplicacao_NotaFiscal Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_RegLanAplicacao_NotaFiscal lista = new TList_RegLanAplicacao_NotaFiscal();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                if (vNM_Campo == string.Empty)
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty));

                while (reader.Read())
                {
                    TRegistro_LanAplicacao_NotaFiscal lanAplicacao = new TRegistro_LanAplicacao_NotaFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Aplicacao")))
                        lanAplicacao.Id_aplicacao = reader.GetDecimal(reader.GetOrdinal("ID_Aplicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        lanAplicacao.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        lanAplicacao.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFItem"))))
                        lanAplicacao.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal"))))
                        lanAplicacao.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        lanAplicacao.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    lista.Add(lanAplicacao);
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

        public string GravarAplicacaoXNotaFiscal(TRegistro_LanAplicacao_NotaFiscal val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_APLICACAO", val.Id_aplicacao);

            return this.executarProc("IA_FAT_APLICACAO_X_NOTAFISCAL", hs);
        }

        public string DeletarAplicacaoXNotaFiscal(TRegistro_LanAplicacao_NotaFiscal val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_APLICACAO", val.Id_aplicacao);

            return this.executarProc("EXCLUI_FAT_APLICACAO_X_NOTAFISCAL", hs);
        }
    }
}
