using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante
{
    public class TRegistro_MovBoliche
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal Id_Cartao { get; set; } = decimal.Zero;
        public decimal Id_Pista { get; set; } = decimal.Zero;
        public decimal? Id_Mov { get; set; }
        public decimal? Id_PreVenda { get; set; }
        public decimal? Id_Item { get; set; }
        public DateTime? Dt_abertura { get; set; }
        public DateTime? Dt_fechamento { get; set; }
        public string LoginCanc { get; set; } = string.Empty;
        public bool Cancelado { get; set; } = false;
    }

    public class TList_MovBoliche : List<TRegistro_MovBoliche> { }

    public class TCD_MovBoliche : TDataQuery
    {
        public TCD_MovBoliche() { }

        public TCD_MovBoliche(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_cartao, a.id_pista, a.id_mov, a.id_prevenda, a.id_item, a.dt_abertura, a.dt_fechamento, ");
                sql.AppendLine("a.logincanc, a.cancelado ");
            }
            else
                sql.AppendLine("select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_movboliche a");

            string cond = "where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_MovBoliche Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MovBoliche lista = new TList_MovBoliche();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovBoliche rMov = new TRegistro_MovBoliche();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        rMov.Cd_Empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cartao")))
                        rMov.Id_Cartao = reader.GetDecimal(reader.GetOrdinal("Id_Cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Pista")))
                        rMov.Id_Pista = reader.GetDecimal(reader.GetOrdinal("Id_Pista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Mov")))
                        rMov.Id_Mov = reader.GetDecimal(reader.GetOrdinal("Id_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_PreVenda")))
                        rMov.Id_PreVenda = reader.GetDecimal(reader.GetOrdinal("Id_PreVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Item")))
                        rMov.Id_Item = reader.GetDecimal(reader.GetOrdinal("Id_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        rMov.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fechamento")))
                        rMov.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));

                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        rMov.LoginCanc = reader.GetString(reader.GetOrdinal("LoginCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cancelado")))
                        rMov.Cancelado = reader.GetBoolean(reader.GetOrdinal("Cancelado"));

                    lista.Add(rMov);
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

        public string Gravar(TRegistro_MovBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_CARTAO", val.Id_Cartao);
            hs.Add("@P_ID_PISTA", val.Id_Pista);
            hs.Add("@P_ID_MOV", val.Id_Mov);
            hs.Add("@P_ID_PREVENDA", val.Id_PreVenda);
            hs.Add("@P_ID_ITEM", val.Id_Item);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_LOGINCANC", val.LoginCanc);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return this.executarProc("IA_RES_MOVBOLICHE", hs);
        }

        public string Excluir(TRegistro_MovBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_CARTAO", val.Id_Cartao);
            hs.Add("@P_ID_PISTA", val.Id_Pista);
            hs.Add("@P_ID_MOV", val.Id_Mov);

            return this.executarProc("EXCLUI_RES_MOVBOLICHE", hs);
        }

    }
}
