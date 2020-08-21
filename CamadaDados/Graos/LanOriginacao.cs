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
    #region "ORIGINACAO"

        public class TList_Lan_Originacao : List<TRegistro_Lan_Originacao> { }

        public class TRegistro_Lan_Originacao
        {
            public decimal ID_Originacao { get; set; }
            public string CD_Empresa { get; set; }
		    public decimal Nr_LanctoFiscal { get; set; }
		    public decimal ID_NFItem { get; set; }
            public decimal PS_Chegada { get; set; }
     
            public TRegistro_Lan_Originacao()
            {
                ID_Originacao = decimal.Zero;
                CD_Empresa = string.Empty;
                Nr_LanctoFiscal = decimal.Zero;
                ID_NFItem = decimal.Zero;
                PS_Chegada = decimal.Zero;
            }

        }

        public class TCD_Lan_Originacao : TDataQuery
        {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" a.ID_Originacao, a.CD_Empresa, a.Nr_LanctoFiscal, a.ID_NFItem, a.PS_Chegada ");

                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_GRO_Originacao a ");

                string cond = " WHERE ";
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
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            }

            public TList_Lan_Originacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Lan_Originacao lista = new TList_Lan_Originacao();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    while (reader.Read())
                    {
                        TRegistro_Lan_Originacao reg = new TRegistro_Lan_Originacao();
                        
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Originacao")))
                            reg.ID_Originacao = reader.GetDecimal(reader.GetOrdinal("ID_Originacao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                            reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                            reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("PS_Chegada")))
                            reg.PS_Chegada = reader.GetDecimal(reader.GetOrdinal("PS_Chegada"));

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

            public string Grava(TRegistro_Lan_Originacao vRegistro)
            {
                Hashtable hs = new Hashtable(5);

                hs.Add("@P_ID_ORIGINACAO", vRegistro.ID_Originacao);
                hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
                hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_LanctoFiscal);
                hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);
                hs.Add("@P_PS_CHEGADA", vRegistro.PS_Chegada);
                
                return this.executarProc("IA_GRO_ORIGINACAO", hs);
            }

            public string Deleta(TRegistro_Lan_Originacao vRegistro)
            {
                Hashtable hs = new Hashtable(1);

                hs.Add("@P_ID_Originacao", vRegistro.ID_Originacao);
                return this.executarProc("EXCLUI_GRO_Originacao", hs);
            }

        }

    #endregion

    #region "ORIGINACAO_X_FATURAMENTO"

        public class TList_Lan_Originacao_x_Faturamento : List<TRegistro_Lan_Originacao_x_Faturamento> { }

        public class TRegistro_Lan_Originacao_x_Faturamento
        {
            private decimal? id_originacao;
            public decimal? ID_Originacao
            {
                get { return id_originacao; }
                set
                {
                    id_originacao = value;
                    id_originacaostr = value.ToString();
                }
            }
            private string id_originacaostr;
            public string ID_Originacaostr
            {
                get { return id_originacaostr; }
                set
                {
                    id_originacaostr = value;
                    try
                    {
                        id_originacao = Convert.ToDecimal(value);
                    }
                    catch
                    { id_originacao = null; }
                }
            }
            public decimal ID_NFItem { get; set; }
            public string CD_Empresa { get; set; }
            private decimal? nr_lanctoFiscal;
            public decimal? Nr_LanctoFiscal
            {
                get { return nr_lanctoFiscal; }
                set
                {
                    nr_lanctoFiscal = value;
                    nr_lanctoFiscalstr = value.ToString();
                }
            }
            private string nr_lanctoFiscalstr;
            public string Nr_LanctoFiscalstr
            {
                get { return nr_lanctoFiscalstr; }
                set
                {
                    nr_lanctoFiscalstr = value;
                    try
                    {
                        nr_lanctoFiscal = Convert.ToDecimal(value);
                    }
                    catch
                    { nr_lanctoFiscal = null; }
                }
            }
            public decimal QTD_Origem { get; set; }
            public decimal VL_Origem { get; set; }
            public TList_Lan_NFHeadge lNFHeadge { get; set; }

            public TRegistro_Lan_Originacao_x_Faturamento()
            {
                this.ID_Originacaostr = string.Empty;
                this.ID_NFItem = decimal.Zero;
                this.CD_Empresa = string.Empty;
                this.Nr_LanctoFiscalstr = string.Empty;
                this.ID_NFItem = decimal.Zero;
                this.QTD_Origem = decimal.Zero;
                this.VL_Origem = decimal.Zero;
                this.lNFHeadge = new TList_Lan_NFHeadge();
            }

        }

        public class TCD_Lan_Originacao_x_Faturamento : TDataQuery
        {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" a.ID_Originacao, a.CD_Empresa, a.Nr_LanctoFiscal, a.ID_NFItem, a.QTD_Origem, a.VL_Origem ");

                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_GRO_Originacao_x_Faturamento a ");

                string cond = " WHERE ";
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
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            }

            public TList_Lan_Originacao_x_Faturamento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Lan_Originacao_x_Faturamento lista = new TList_Lan_Originacao_x_Faturamento();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    while (reader.Read())
                    {
                        TRegistro_Lan_Originacao_x_Faturamento reg = new TRegistro_Lan_Originacao_x_Faturamento();

                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Originacao")))
                            reg.ID_Originacao = reader.GetDecimal(reader.GetOrdinal("ID_Originacao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                            reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                            reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_Origem")))
                            reg.QTD_Origem = reader.GetDecimal(reader.GetOrdinal("QTD_Origem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("VL_Origem")))
                            reg.VL_Origem = reader.GetDecimal(reader.GetOrdinal("VL_Origem"));

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

            public string Grava(TRegistro_Lan_Originacao_x_Faturamento vRegistro)
            {
                Hashtable hs = new Hashtable(6);

                hs.Add("@P_ID_ORIGINACAO", vRegistro.ID_Originacao);
                hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
                hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_LanctoFiscal);
                hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);
                hs.Add("@P_QTD_ORIGEM", vRegistro.QTD_Origem);
                hs.Add("@P_VL_ORIGEM", vRegistro.VL_Origem);

                return this.executarProc("IA_GRO_Originacao_X_FATURAMENTO", hs);
            }

            public string Deleta(TRegistro_Lan_Originacao_x_Faturamento vRegistro)
            {
                Hashtable hs = new Hashtable(4);

                hs.Add("@P_ID_ORIGINACAO", vRegistro.ID_Originacao);
                hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
                hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_LanctoFiscal);
                hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);

                return this.executarProc("EXCLUI_GRO_Originacao_X_FATURAMENTO", hs);
            }

        }

        public class TCD_Lan_SaldoNotasOriginacao : TDataQuery
        {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine("SELECT " + strTop);
                    sql.AppendLine(" c.Nr_NotaFiscal, c.Nr_LanctoFiscal, a.ID_NFItem, c.CD_Empresa, c.CD_Clifor, d.NM_Clifor, c.DT_Emissao, c.DT_SaiEnt, ");
                    sql.AppendLine(" c.Especie, c.Marca, c.Tp_Movimento, a.CD_Produto, e.DS_Produto, a.Quantidade, a.Vl_Unitario, a.Vl_SubTotal ");
                    sql.AppendLine(" ,(a.Quantidade - (ISNULL((SELECT SUM(isnull(x.QTD_Origem,0)) FROM TB_GRO_Originacao_x_Faturamento x ");
                    sql.AppendLine("	   WHERE x.Nr_lanctoFiscal = a.Nr_LanctoFiscal ");
                    sql.AppendLine("	   AND x.ID_NFItem = a.ID_NFItem ");
                    sql.AppendLine("	   AND x.CD_Empresa = a.CD_Empresa),0))) as QTD_Disponivel ");
                    sql.AppendLine(" ,(a.Vl_SubTotal - (ISNULL((SELECT SUM(isnull(x.VL_Origem,0)) FROM TB_GRO_Originacao_x_Faturamento x ");
                    sql.AppendLine("	   WHERE x.Nr_lanctoFiscal = a.Nr_LanctoFiscal ");
                    sql.AppendLine("	   AND x.ID_NFItem = a.ID_NFItem ");
                    sql.AppendLine("	   AND x.CD_Empresa = a.CD_Empresa),0))) as VL_Disponivel ");
                }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_FAT_NotaFiscal_Item a ");
                sql.AppendLine("JOIN TB_FAT_NotaFiscal c ON c.Nr_LanctoFiscal = a.Nr_LanctoFiscal AND c.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("JOIN vTB_FIN_Clifor d ON d.CD_Clifor = c.CD_Clifor ");
                sql.AppendLine("JOIN TB_EST_Produto e ON e.CD_Produto = a.CD_Produto ");
                sql.AppendLine("WHERE ISNULL((SELECT SUM(isnull(b.QTD_Origem,0)) FROM TB_GRO_Originacao_x_Faturamento b ");
                sql.AppendLine("	   WHERE b.Nr_lanctoFiscal = a.Nr_LanctoFiscal ");
                sql.AppendLine("	   AND b.ID_NFItem = a.ID_NFItem ");
                sql.AppendLine("	   AND b.CD_Empresa = a.CD_Empresa),0) < a.Quantidade ");
                sql.AppendLine("AND ISNULL((SELECT SUM(isnull(b.VL_Origem,0)) FROM TB_GRO_Originacao_x_Faturamento b ");
                sql.AppendLine("	   WHERE b.Nr_lanctoFiscal = a.Nr_LanctoFiscal ");
                sql.AppendLine("	   AND b.ID_NFItem = a.ID_NFItem ");
                sql.AppendLine("	   AND b.CD_Empresa = a.CD_Empresa),0) < a.Vl_Subtotal ");

                string cond = " AND ";
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
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            }
        }

     #endregion
}
