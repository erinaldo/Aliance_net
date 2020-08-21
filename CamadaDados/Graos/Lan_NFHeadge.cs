using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Graos
{
    #region "LAN NF HEADGE"

        public class TList_Lan_NFHeadge : List<TRegistro_Lan_NFHeadge> { }

        public class TRegistro_Lan_NFHeadge
        {
            public decimal ID_LanctoHeadge { get; set; }
            public decimal ID_Headge { get; set; }
            public decimal ID_Originacao { get; set; }
            public string DS_Headge { get; set; }
            public string CD_Empresa { get; set; }
            public string NM_Empresa { get; set; }
            public decimal Nr_LanctoFiscal { get; set; }
            public decimal ID_NFItem { get; set; }
            public decimal VL_Lancto { get; set; }
            public decimal PC_Headge { get; set; }
            public decimal VL_Headge { get; set; }
            public string CD_UnidHeadge { get; set; }

            public TRegistro_Lan_NFHeadge()
            {
                this.ID_LanctoHeadge = decimal.Zero;
                this.ID_Headge = decimal.Zero;
                this.ID_Originacao = decimal.Zero;
                this.DS_Headge = string.Empty;
                this.CD_Empresa = string.Empty;
                this.NM_Empresa = string.Empty;
                this.Nr_LanctoFiscal = decimal.Zero;
                this.ID_NFItem = decimal.Zero;
                this.VL_Lancto = decimal.Zero;
                this.Nr_LanctoFiscal = decimal.Zero;
                this.PC_Headge = decimal.Zero;
                this.VL_Headge = decimal.Zero;
                this.CD_UnidHeadge = string.Empty;
            }
        }

        public class TCD_Lan_NFHeadge : TDataQuery
        {
            public TCD_Lan_NFHeadge() { }

            public TCD_Lan_NFHeadge(string vNM_ProcSqlBusca)
            {
                this.NM_ProcSqlBusca = vNM_ProcSqlBusca;        
            }

            public string SqlCodeBuscaLanctoHeadge(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" e.ID_Headge, e.DS_Headge, a.CD_Empresa, f.NM_Empresa, a.ID_NFItem, a.Nr_LanctoFiscal, d.PC_Headge, d.VL_Headge, d.CD_UnidValor as CD_UnidHeadge, g.CD_Unidade, a.Quantidade, a.VL_Subtotal as VL_Lancto, a.VL_subtotal ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_FAT_Notafiscal_Item a ");
                sql.AppendLine("JOIN VTB_GRO_Contrato c on c.nr_pedido = a.nr_pedido and c.cd_produto = a.cd_produto and c.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("JOIN TB_GRO_Contrato_X_Headge d on d.nr_contrato = c.nr_contrato ");
                sql.AppendLine("JOIN TB_GRO_Headge e on e.id_headge = d.id_headge ");
                sql.AppendLine("JOIN TB_DIV_Empresa f on f.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("JOIN TB_EST_Produto g on g.CD_Produto = a.CD_Produto  ");

                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }

                return sql.ToString();
            }

            public string SqlCodeBuscaLanctoHeadgeVenda(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" e.ID_Headge, e.DS_Headge, a.ID_NFItem, g.PS_Chegada as Quantidade, f.CD_Empresa, f.NM_Empresa, ");
                    sql.AppendLine(" a.VL_subtotal as VL_Lancto, a.Nr_LanctoFiscal, d.PC_Headge, d.VL_Headge, ");
                    sql.AppendLine(" Round(((a.VL_SubTotal/a.Quantidade)*g.PS_Chegada),2) as VL_subtotal, d.CD_UnidValor as CD_UnidHeadge, h.CD_Unidade ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_FAT_Notafiscal_Item a ");
                sql.AppendLine("JOIN VTB_GRO_Contrato c on c.nr_pedido = a.nr_pedido and c.cd_produto = a.cd_produto and c.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("JOIN TB_GRO_Contrato_X_Headge d on d.nr_contrato = c.nr_contrato ");
                sql.AppendLine("JOIN TB_GRO_Headge e on e.id_headge = d.id_headge ");
                sql.AppendLine("JOIN TB_DIV_Empresa f on f.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("JOIN TB_GRO_Originacao g on g.Nr_LanctoFiscal = a.Nr_LanctoFiscal and g.CD_empresa = a.CD_empresa and g.ID_NFItem = a.ID_NFItem ");
                sql.AppendLine("JOIN TB_EST_Produto h on h.CD_Produto = a.CD_Produto ");

                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }

                return sql.ToString();
            }

            public string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" a.ID_LanctoHeadge, a.ID_Headge, b.DS_Headge, a.CD_Empresa, a.ID_NFItem, ");
                    sql.AppendLine(" a.VL_Lancto, a.Nr_LanctoFiscal, c.NM_Empresa ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_GRO_Lancto_NFHeadge a ");
                sql.AppendLine("JOIN TB_GRO_Headge b on a.ID_Headge = b.ID_Headge ");
                sql.AppendLine("JOIN TB_DIV_Empresa c on a.CD_Empresa = c.CD_Empresa ");
                
                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }

                return sql.ToString();
            }

            public string SqlCodeBuscaCompra(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" a.ID_LanctoHeadge, a.ID_Headge, b.DS_Headge, a.CD_Empresa, a.ID_NFItem, ");
                    sql.AppendLine(" a.VL_Lancto, a.Nr_LanctoFiscal, c.NM_Empresa ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_GRO_Lancto_NFHeadge a ");
                sql.AppendLine("JOIN TB_GRO_Headge b on a.ID_Headge = b.ID_Headge ");
                sql.AppendLine("JOIN TB_DIV_Empresa c on a.CD_Empresa = c.CD_Empresa ");
                sql.AppendLine("join tb_gro_originacao_x_custoheadge d on d.id_headge = d.id_headge and d.id_lanctoheadge = a.id_lanctoheadge ");
                sql.AppendLine("join tb_gro_originacao e on e.id_originacao = d.id_originacao ");

                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }

                return sql.ToString();
            }

            public string SqlCodeBuscaTotais(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" d.id_headge, e.ds_headge, sum(d.vl_lancto) as Vl_Lancto ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM tb_gro_originacao a ");
                sql.AppendLine("JOIN tb_gro_originacao_x_faturamento b on a.id_originacao = b.id_originacao ");
                sql.AppendLine("JOIN tb_fat_notafiscal_item c on b.cd_empresa = c.cd_empresa and b.nr_lanctofiscal = c.nr_lanctofiscal and b.id_nfitem = c.id_nfitem ");
                sql.AppendLine("JOIN tb_gro_lancto_nfHeadge d on d.nr_lanctofiscal = c.nr_lanctofiscal and d.cd_empresa = c.cd_empresa and d.id_nfitem = c.id_nfitem ");
                sql.AppendLine("JOIN tb_gro_headge e on d.id_headge = e.id_headge ");

                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }

                sql.AppendLine("group by d.id_headge, e.ds_headge ");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                if (this.NM_ProcSqlBusca == "")
                    return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
                else
                {
                    Type t = this.GetType();
                    System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                                System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                                System.Reflection.BindingFlags.Instance);
                    string sql = m.Invoke(this, new object[] { vBusca, vTop, "" }).ToString();
                    return this.ExecutarBusca(sql, null);
                }
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                if (this.NM_ProcSqlBusca.Trim() == "")
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

            public TList_Lan_NFHeadge Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Lan_NFHeadge lista = new TList_Lan_NFHeadge();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    if (this.NM_ProcSqlBusca == "")
                        reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    else
                        reader = this.ExecutarBusca(this.SqlCodeBuscaCompra(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                    while (reader.Read())
                    {
                        TRegistro_Lan_NFHeadge reg = new TRegistro_Lan_NFHeadge();

                        if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoHeadge")))
                            reg.ID_LanctoHeadge = reader.GetDecimal(reader.GetOrdinal("ID_LanctoHeadge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Headge")))
                            reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("ID_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                            reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                            reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                            reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Headge")))
                            reg.DS_Headge = reader.GetString(reader.GetOrdinal("DS_Headge")).Trim();
                        if (!reader.IsDBNull(reader.GetOrdinal("VL_Lancto")))
                            reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));
                        
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

            public TList_Lan_NFHeadge SelectLanctoHeadge(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, decimal vQuantidade, decimal vValor, decimal vID_Originacao)
            {
                TList_Lan_NFHeadge lista = new TList_Lan_NFHeadge();
                SqlDataReader reader;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    if (this.NM_ProcSqlBusca == "SqlCodeBuscaLanctoHeadge")
                        reader = this.ExecutarBusca(this.SqlCodeBuscaLanctoHeadge(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    else 
                        reader = this.ExecutarBusca(this.SqlCodeBuscaLanctoHeadgeVenda(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                    while (reader.Read())
                    {
                        TRegistro_Lan_NFHeadge reg = new TRegistro_Lan_NFHeadge();
                        
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Headge")))
                            reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("ID_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                            reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                            reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                            reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                        if (!reader.IsDBNull(reader.GetOrdinal("PC_Headge")))
                            reg.PC_Headge = reader.GetDecimal(reader.GetOrdinal("PC_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("VL_Headge")))
                            reg.VL_Headge = reader.GetDecimal(reader.GetOrdinal("VL_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidHeadge")))
                            reg.CD_UnidHeadge = reader.GetString(reader.GetOrdinal("CD_UnidHeadge"));
                        
                        if (reg.PC_Headge > 0)
                        {
                            reg.VL_Lancto = Math.Round(((reg.PC_Headge / 100) * vValor),2);
                        }
                        else if (reg.VL_Headge > 0)
                            if (reg.CD_UnidHeadge == "")
                                reg.VL_Lancto = Math.Round(reader.GetDecimal(reader.GetOrdinal("VL_Headge")),2);
                            else
                                reg.VL_Lancto = Math.Round((new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(reader.GetString(reader.GetOrdinal("CD_Unidade")), reader.GetString(reader.GetOrdinal("CD_UnidHeadge")), vQuantidade)) * reader.GetDecimal(reader.GetOrdinal("VL_Headge")), 2);


                        reg.ID_Originacao = vID_Originacao;

                        lista.Add(reg);
                    }
                }
                finally
                {
                    if (podeFecharBco)
                        this.deletarBanco_Dados();
                }
                return lista;
            }

            public TList_Lan_NFHeadge SelectTotais(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Lan_NFHeadge lista = new TList_Lan_NFHeadge();
                SqlDataReader reader;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBuscaTotais(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                    while (reader.Read())
                    {
                        TRegistro_Lan_NFHeadge reg = new TRegistro_Lan_NFHeadge();

                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Headge")))
                            reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("ID_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Headge")))
                            reg.DS_Headge = reader.GetString(reader.GetOrdinal("DS_Headge")).Trim();
                        if (!reader.IsDBNull(reader.GetOrdinal("VL_Lancto")))
                            reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));

                        lista.Add(reg);
                    }
                }
                finally
                {
                    if (podeFecharBco)
                        this.deletarBanco_Dados();
                }
                return lista;
            }

            public string Grava(TRegistro_Lan_NFHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(6);

                hs.Add("@P_ID_LANCTOHEADGE", vRegistro.ID_LanctoHeadge);
                hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
                hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
                hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_LanctoFiscal);
                hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);
                hs.Add("@P_VL_LANCTO", vRegistro.VL_Lancto);

                return this.executarProc("IA_GRO_LANCTO_NFHEADGE", hs);
            }

            public string Alterar(TRegistro_Lan_NFHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(7);

                hs.Add("@P_ID_LANCTOHEADGE", vRegistro.ID_LanctoHeadge);
                hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
                hs.Add("@P_VL_LANCTO", vRegistro.VL_Lancto);

                return this.executarProc("IA_GRO_ALTERAR_LANCTO_NFHEADGE", hs);
            }

            public string Deleta(TRegistro_Lan_NFHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(2);

                hs.Add("@P_ID_LANCTOHEADGE", vRegistro.ID_LanctoHeadge);
                hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);

                return this.executarProc("EXCLUI_GRO_LANCTO_NFHEADGE", hs);
            }

            public string DeletaTodos(TRegistro_Lan_NFHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(3);

                hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
                hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_LanctoFiscal);
                hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);

                return this.executarProc("EXCLUI_GRO_LANCTO_NFHEADGETODOS", hs);
            }

        }

    #endregion
}
