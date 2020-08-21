using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante
{
    public class TRegistro_ItensCupom
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal id_prevenda { get; set; } = decimal.Zero;
        public decimal id_item { get; set; } = decimal.Zero;
        public decimal id_lancto { get; set; } = decimal.Zero;
        public decimal id_Cupom { get; set; } = decimal.Zero;



    }

    public class TList_ItensCupom : List<TRegistro_ItensCupom> { }

    public class TCD_ItensCupom : TDataQuery
    {
        public TCD_ItensCupom() { }

        public TCD_ItensCupom(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_prevenda, a.id_item, a.cd_empresa, a.id_lancto, a.id_cupom ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_RES_ItensPreVenda_X_ItensCupom a ");


            string cond = " where ";
            //  sql.AppendLine("where  ");
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

        public TList_ItensCupom Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ItensCupom lista = new TList_ItensCupom();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensCupom reg = new TRegistro_ItensCupom();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.id_Cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom")); 

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

        public string Gravar(TRegistro_ItensCupom val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_CUPOM", val.id_Cupom);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);
            hs.Add("@P_ID_ITEM", val.id_item);
            hs.Add("@P_ID_LANCTO", val.id_lancto);

            return this.executarProc("IA_RES_ITENSPREVENDA_X_ITENSCUPOM", hs);
        }

        public string Excluir(TRegistro_ItensCupom val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_CUPOM", val.id_Cupom);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);
            hs.Add("@P_ID_ITEM", val.id_item);
            hs.Add("@P_ID_LANCTO", val.id_lancto);

            return this.executarProc("EXCLUI_RES_ITENSPREVENDA_X_ITENSCUPOM", hs);
        }
    }

}
