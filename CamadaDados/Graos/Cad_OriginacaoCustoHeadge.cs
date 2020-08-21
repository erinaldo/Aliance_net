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
    #region "ORIGINACAO_X_CUSTOHEADGE"

        public class TList_Cad_OriginacaoCustoHeadge : List<TRegistro_Cad_OriginacaoCustoHeadge> { }

        public class TRegistro_Cad_OriginacaoCustoHeadge
        {
            public decimal ID_Originacao { get; set; }
            public decimal ID_Headge { get; set; }
            public decimal ID_LanctoHeadge { get; set; }
            
            public TRegistro_Cad_OriginacaoCustoHeadge()
            {
                this.ID_Originacao = decimal.Zero;
                this.ID_LanctoHeadge = decimal.Zero;
                this.ID_Headge = decimal.Zero;
            }
        }

        public class TCD_Cad_OriginacaoCustoHeadge : TDataQuery
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
                    sql.AppendLine(" a.ID_Originacao, a.ID_Headge, a.ID_LanctoHeadge ");

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

            public TList_Cad_OriginacaoCustoHeadge Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Cad_OriginacaoCustoHeadge lista = new TList_Cad_OriginacaoCustoHeadge();
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
                        TRegistro_Cad_OriginacaoCustoHeadge reg = new TRegistro_Cad_OriginacaoCustoHeadge();

                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Originacao")))
                            reg.ID_Originacao = reader.GetDecimal(reader.GetOrdinal("ID_Originacao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Headge")))
                            reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("ID_Headge"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoHeadge")))
                            reg.ID_LanctoHeadge = reader.GetDecimal(reader.GetOrdinal("ID_LanctoHeadge"));

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

            public string Grava(TRegistro_Cad_OriginacaoCustoHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(3);

                hs.Add("@P_ID_ORIGINACAO", vRegistro.ID_Originacao);
                hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
                hs.Add("@P_ID_LANCTOHEADGE", vRegistro.ID_LanctoHeadge);

                return this.executarProc("IA_GRO_ORIGINACAO_X_CUSTOHEADGE", hs);
            }

            public string Deleta(TRegistro_Cad_OriginacaoCustoHeadge vRegistro)
            {
                Hashtable hs = new Hashtable(3);

                hs.Add("@P_ID_ORIGINACAO", vRegistro.ID_Originacao);
                hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
                hs.Add("@P_ID_LANCTOHEADGE", vRegistro.ID_LanctoHeadge);

                return this.executarProc("EXCLUI_GRO_ORIGINACAO_X_CUSTOHEADGE", hs);
            }

        }

    #endregion
}
