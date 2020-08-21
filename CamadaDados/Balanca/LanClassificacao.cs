using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Balanca
{
    public class TList_RegLanClassificacao : List<TRegistro_LanClassificacao>, IComparer<TRegistro_LanClassificacao>
    {
        #region IComparer<TRegistro_LanClassificacao> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_RegLanClassificacao()
        { }

        public TList_RegLanClassificacao(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanClassificacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanClassificacao x, TRegistro_LanClassificacao y)
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

    public class TRegistro_LanClassificacao
    {
        public string Cd_empresa
        {
            get;
            set;
        }
        public decimal Id_ticket
        {
            get;
            set;
        }
        public string Tp_pesagem
        {
            get;
            set;
        }
        public string Cd_tipoamostra
        {
            get;
            set;
        }
        public string Ds_amostra
        {
            get;
            set;
        }
        public string Login_cla
        {
            get;
            set;
        }
        private DateTime? dt_classif;
        public DateTime? Dt_classif
        {
            get { return dt_classif; }
            set 
            { 
                dt_classif = value;
                dt_classifstring = value.ToString();
            }
        }
        private string dt_classifstring;
        public string Dt_classifstring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_classifstring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_classifstring = value;
                try
                {
                    dt_classif = Convert.ToDateTime(value);
                }
                catch
                { dt_classif = null; }
            }
        }
        private decimal pc_resultado_local;
        public decimal Pc_resultado_local
        {
            get { return pc_resultado_local; }
            set 
            {
                if (Fator_conversao > 0)
                    pc_resultado_local = value * Fator_conversao;
                else
                    pc_resultado_local = value;
            }
        }
        public decimal Pc_resultado_origdes
        {
            get;
            set;
        }
        public decimal Pc_desc_estoque
        {
            get;
            set;
        }
        public decimal Pc_desc_pagto
        {
            get;
            set;
        }
        private decimal ps_amostra;
        public decimal Ps_amostra
        {
            get { return ps_amostra; }
            set 
            {
                ps_amostra = value;
                if ((ps_referencia > 0) && (value > 0))
                    if (Fator_conversao > 0)
                        pc_resultado_local = (value / ps_referencia) * 100 * Fator_conversao;
                    else
                        pc_resultado_local = (value / ps_referencia) * 100;
            }
        }
        private decimal ps_descontado_est;
        public decimal Ps_descontado_est
        {
            get { return Math.Round(ps_descontado_est, 0); }
            set { ps_descontado_est = Math.Round(value, 0); }
        }
        private decimal ps_descontado_pgt;
        public decimal Ps_descontado_pgt
        {
            get { return Math.Round(ps_descontado_pgt, 0); }
            set { ps_descontado_pgt = Math.Round(value, 0); }
        }
        public decimal Pc_desc_origem
        {
            get;
            set;
        }
        public string Tp_desconto
        {
            get;
            set;
        }
        public decimal Ps_descontado_origem
        {
            get;
            set;
        }
        private decimal ps_referencia;
        public decimal Ps_referencia
        {
            get { return ps_referencia; }
            set 
            { 
                ps_referencia = value;
                if ((value > 0) && (ps_amostra > 0))
                    if (Fator_conversao > 0)
                        pc_resultado_local = (ps_amostra / value) * 100 * Fator_conversao;
                    else
                        pc_resultado_local = (ps_amostra / value) * 100;
            }
        }
        public string InformarR_P
        {
            get;
            set;
        }
        public decimal Fator_conversao
        {
            get;
            set;
        }
        public decimal Maiorque
        {
            get;
            set;
        }
        public decimal Menorque
        {
            get;
            set;
        }
        public string St_registro
        {
            get;
            set;
        }
        public string Capturapeso
        {
            get;
            set;
        }
        public string Capturareferencia
        {
            get;
            set;
        }
        public string Cd_protocolopeso
        {
            get;
            set;
        }
        public string Cd_protocoloreferencia
        {
            get;
            set;
        }
        public string Ds_protocolopeso
        {
            get;
            set;
        }
        public string Ds_protocoloreferencia
        {
            get;
            set;
        }

        public TRegistro_LanClassificacao()
        {
            this.Cd_empresa = string.Empty;
            this.Id_ticket = decimal.Zero;
            this.Tp_pesagem = string.Empty;
            this.Cd_tipoamostra = string.Empty;
            this.Ds_amostra = string.Empty;
            this.Login_cla = string.Empty;
            this.dt_classif = null;
            this.dt_classifstring = string.Empty;
            this.pc_resultado_local = decimal.Zero;
            this.Pc_resultado_origdes = decimal.Zero;
            this.Pc_desc_estoque = decimal.Zero;
            this.Pc_desc_pagto = decimal.Zero;
            this.ps_amostra = decimal.Zero;
            this.ps_descontado_est = decimal.Zero;
            this.ps_descontado_pgt = decimal.Zero;
            this.Pc_desc_origem = decimal.Zero;
            this.Tp_desconto = string.Empty;
            this.Ps_descontado_origem = decimal.Zero;
            this.ps_referencia = decimal.Zero;
            this.InformarR_P = string.Empty;
            this.Fator_conversao = decimal.Zero;
            this.Maiorque = decimal.Zero;
            this.Menorque = decimal.Zero;
            this.St_registro = "A";
            this.Capturapeso = string.Empty;
            this.Capturareferencia = string.Empty;
            this.Cd_protocolopeso = string.Empty;
            this.Cd_protocoloreferencia = string.Empty;
            this.Ds_protocolopeso = string.Empty;
            this.Ds_protocoloreferencia = string.Empty;
        }
    }

    public class TCD_LanClassificacao : TDataQuery
    {
        public TCD_LanClassificacao()
        { }

        public TCD_LanClassificacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public TCD_LanClassificacao(string vNM_ProcSqlBusca)
        {
            this.NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Ticket, a.Tp_Pesagem, a.CD_TipoAmostra, a.Login_Cla, a.DT_Classif, ");
                sql.AppendLine("a.PC_Resultado_Local, a.PC_Resultado_OrigDes, a.PC_Desc_Estoque, a.PC_Desc_Pagto, a.PS_Amostra, ");
                sql.AppendLine("a.PS_Descontado_Est, a.PS_Descontado_Pgt, a.PC_Desc_origem, a.Tp_Desconto, a.PS_Descontado_Origem, ");
                sql.AppendLine("a.ST_Registro, b.NM_Empresa, c.DS_Amostra, e.ps_referenciapadrao, e.informarR_P, e.Fator_Conversao, ");
                sql.AppendLine("e.MaiorQue, e.MenorQue, e.CapturaPeso, e.CapturaReferencia, e.cd_protocolo, ");
                sql.AppendLine("f.ds_protocolo, e.cd_protocolo_ref, g.ds_protocolo as ds_protocolo_ref ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("FROM TB_BAL_Classif a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("ON a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_GRO_Amostra c ");
            sql.AppendLine("ON a.CD_TipoAmostra = c.CD_TipoAmostra ");
            sql.AppendLine("inner join TB_BAL_PsGraos d ");
            sql.AppendLine("ON a.CD_Empresa = d.CD_Empresa ");
            sql.AppendLine("and a.ID_Ticket = d.ID_Ticket ");
            sql.AppendLine("and a.TP_Pesagem = d.TP_Pesagem ");
            sql.AppendLine("inner join tb_gro_descontoxamostra e ");
            sql.AppendLine("on d.cd_tabeladesconto = e.cd_tabeladesconto ");
            sql.AppendLine("and e.cd_tipoamostra = a.cd_tipoamostra ");
            sql.AppendLine("left outer join tb_div_protocolo f ");
            sql.AppendLine("on e.cd_protocolo = f.cd_protocolo ");
            sql.AppendLine("left outer join tb_div_protocolo g ");
            sql.AppendLine("on e.cd_protocolo_ref = g.cd_protocolo ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        private string SqlCodeBuscaAmostrasClassif(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " A.CD_TipoAmostra, DS_Amostra, D.CD_Empresa, E.NM_Empresa, D.ID_Ticket, ");
                sql.AppendLine("D.TP_Pesagem, D.Login_Cla, D.DT_Classif, D.PC_RESULTADO_LOCAL, D.PC_Resultado_OrigDes, ");
                sql.AppendLine("D.PC_Desc_Estoque, D.PS_Amostra, D.PS_Descontado_Est, D.PC_Desc_Pagto, D.PS_Descontado_Pgt, ");
                sql.AppendLine("D.PC_Desc_origem,  D.Tp_Desconto, D.PS_Descontado_Origem, A.ST_Registro, a.PS_ReferenciaPadrao, ");
                sql.AppendLine("a.InformarR_P, a.Fator_Conversao, a.MaiorQue, a.MenorQue, a.capturapeso, a.capturareferencia, ");
                sql.AppendLine("a.cd_protocolo, f.ds_protocolo, a.cd_protocolo_ref, g.ds_protocolo as ds_protocolo_ref ");
            }
            else

                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("From TB_GRO_DescontoXAmostra A ");
            sql.AppendLine("inner join TB_GRO_Amostra C On a.CD_TipoAmostra = c.CD_TipoAmostra ");
            sql.AppendLine("inner join TB_BAL_PSGraos B On A.CD_TabelaDesconto = B.CD_TabelaDesconto ");
            sql.AppendLine("left outer join TB_BAL_Classif D On D.CD_Empresa = B.CD_Empresa and D.ID_Ticket = B.ID_Ticket ");
            sql.AppendLine("and D.TP_Pesagem = B.TP_Pesagem ");
            sql.AppendLine("left outer join TB_DIV_Empresa E On E.CD_Empresa = D.CD_Empresa ");
            sql.AppendLine("left outer join TB_DIV_Protocolo f ");
            sql.AppendLine("on a.cd_protocolo = f.cd_protocolo ");
            sql.AppendLine("left outer join TB_DIV_Protocolo g ");
            sql.AppendLine("on a.cd_protocolo_ref = g.cd_protocolo ");
            sql.AppendLine("Where isNull(A.ST_Registro, 'A') <> 'C'");
            sql.AppendLine(" and A.CD_TipoAmostra = D.CD_TipoAmostra ");
            
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("order by c.ordem ");                       
            return sql.ToString();
        }

        private string SqlCodeBuscaProdutoClassificavel(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select 1 ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_GRO_DescontoXProduto a inner join TB_GRO_DescontoXAmostra b ");
            sql.AppendLine("On b.CD_TabelaDesconto = a.CD_TabelaDesconto ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            sql.AppendLine(" and isNull(b.ST_Registro, 'A') <> 'C'");
            
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public TList_RegLanClassificacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            SqlDataReader reader;
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca, 
                                                            System.Reflection.BindingFlags.InvokeMethod| System.Reflection.BindingFlags.NonPublic| 
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                reader = this.ExecutarBusca(sql);
            }
            TList_RegLanClassificacao lista = new TList_RegLanClassificacao();
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanClassificacao reg = new TRegistro_LanClassificacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TipoAmostra"))))
                        reg.Cd_tipoamostra = reader.GetString(reader.GetOrdinal("CD_TipoAmostra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Amostra"))))
                        reg.Ds_amostra = reader.GetString(reader.GetOrdinal("DS_Amostra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_Cla"))))
                        reg.Login_cla = reader.GetString(reader.GetOrdinal("Login_Cla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Classif"))))
                        reg.Dt_classif = reader.GetDateTime(reader.GetOrdinal("DT_Classif"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Resultado_Local"))))
                        reg.Pc_resultado_local = reader.GetDecimal(reader.GetOrdinal("PC_Resultado_local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Resultado_OrigDes"))))
                        reg.Pc_resultado_origdes = reader.GetDecimal(reader.GetOrdinal("PC_Resultado_OrigDes"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Desc_Estoque"))))
                        reg.Pc_desc_estoque = reader.GetDecimal(reader.GetOrdinal("PC_Desc_Estoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Desc_Pagto"))))
                        reg.Pc_desc_pagto = reader.GetDecimal(reader.GetOrdinal("PC_Desc_Pagto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Amostra"))))
                        reg.Ps_amostra = reader.GetDecimal(reader.GetOrdinal("PS_Amostra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Descontado_Est"))))
                        reg.Ps_descontado_est = reader.GetDecimal(reader.GetOrdinal("PS_Descontado_Est"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Descontado_Pgt"))))
                        reg.Ps_descontado_pgt = reader.GetDecimal(reader.GetOrdinal("PS_Descontado_Pgt"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Desc_Origem"))))
                        reg.Pc_desc_origem = reader.GetDecimal(reader.GetOrdinal("PC_Desc_Origem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Desconto"))))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("TP_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Descontado_Origem"))))
                        reg.Ps_descontado_origem = reader.GetDecimal(reader.GetOrdinal("PS_Descontado_Origem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_ReferenciaPadrao"))))
                        reg.Ps_referencia = reader.GetDecimal(reader.GetOrdinal("PS_ReferenciaPadrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("InformarR_P"))))
                        reg.InformarR_P = reader.GetString(reader.GetOrdinal("InformarR_P"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fator_Conversao"))))
                        reg.Fator_conversao = reader.GetDecimal(reader.GetOrdinal("Fator_Conversao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("MaiorQue"))))
                        reg.Maiorque = reader.GetDecimal(reader.GetOrdinal("MaiorQue"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("MenorQue"))))
                        reg.Menorque = reader.GetDecimal(reader.GetOrdinal("MenorQue"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapturaPeso")))
                        reg.Capturapeso = reader.GetString(reader.GetOrdinal("CapturaPeso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapturaReferencia")))
                        reg.Capturareferencia = reader.GetString(reader.GetOrdinal("CapturaReferencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Protocolo")))
                        reg.Cd_protocolopeso = reader.GetString(reader.GetOrdinal("CD_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Protocolo")))
                        reg.Ds_protocolopeso = reader.GetString(reader.GetOrdinal("DS_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Protocolo_Ref")))
                        reg.Cd_protocoloreferencia = reader.GetString(reader.GetOrdinal("CD_Protocolo_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Protocolo_Ref")))
                        reg.Ds_protocoloreferencia = reader.GetString(reader.GetOrdinal("DS_Protocolo_Ref"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            return lista;
        }

        public decimal calcClassif(string vCD_Empresa,
                                   string vID_Ticket,
                                   string vTP_Pesagem)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", vCD_Empresa);
            hs.Add("@P_ID_TICKET", vID_Ticket);
            hs.Add("@P_TP_PESAGEM", vTP_Pesagem);
            string vResult = this.executarProc("CALC_CLASSIF", hs);
            try
            {
                return Convert.ToDecimal(TDataQuery.getPubVariavel(vResult, "@P_TOTDESC"));
            }
            catch
            {
                return 0;
            }
        }

        public string GravarClassificacao(TRegistro_LanClassificacao val)
        {
            Hashtable hs = new Hashtable(17);

            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);
            hs.Add("@P_LOGIN_CLA", val.Login_cla);
            hs.Add("@P_PC_RESULTADO_LOCAL", val.Pc_resultado_local);
            hs.Add("@P_DT_CLASSIF", val.Dt_classif);
            hs.Add("@P_PC_DESC_ESTOQUE", val.Pc_desc_estoque);
            hs.Add("@P_PC_DESC_ORIGEM", val.Pc_desc_origem);
            hs.Add("@P_PC_DESC_PAGTO", val.Pc_desc_pagto);
            hs.Add("@P_PC_RESULTADO_ORIGDES", val.Pc_resultado_origdes);
            hs.Add("@P_PS_AMOSTRA", val.Ps_amostra);
            hs.Add("@P_PS_DESCONTADO_EST", val.Ps_descontado_est);
            hs.Add("@P_PS_DESCONTADO_ORIGEM", val.Ps_descontado_origem);
            hs.Add("@P_PS_DESCONTADO_PGT", val.Ps_descontado_pgt);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);

            return this.executarProc("IA_BAL_CLASSIF", hs);
        }
    }
}
