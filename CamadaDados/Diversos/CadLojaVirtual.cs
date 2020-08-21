using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_LojaVirtual : List<TRegistro_LojaVirtual> { }
    public class TRegistro_LojaVirtual
    {
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        private decimal? id_loja;

        public decimal? Id_loja
        {
            get { return id_loja; }
            set
            {
                id_loja = value;
                id_lojastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lojastr;

        public string Id_lojastr
        {
            get { return id_lojastr; }
            set
            {
                id_lojastr = value;
                try
                {
                    id_loja = decimal.Parse(value);
                }
                catch { id_loja = null; }
            }
        }
        public string Nm_loja { get; set; }
        public string UserName { get; set; }
        public string ApiKey { get; set; }

        public TRegistro_LojaVirtual()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_loja = null;
            id_lojastr = string.Empty;
            Nm_loja = string.Empty;
            UserName = string.Empty;
            ApiKey = string.Empty;
        }
    }
    public class TCD_LojaVirtual:TDataQuery
    {
        public TCD_LojaVirtual() { }

        public TCD_LojaVirtual(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Loja, a.NM_Loja, a.UserName, a.ApiKey ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_DIV_LojaVirtual a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_LojaVirtual Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LojaVirtual lista = new TList_LojaVirtual();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LojaVirtual reg = new TRegistro_LojaVirtual();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loja")))
                        reg.Id_loja = reader.GetDecimal(reader.GetOrdinal("ID_Loja"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Loja")))
                        reg.Nm_loja = reader.GetString(reader.GetOrdinal("NM_Loja"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                        reg.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ApiKey")))
                        reg.ApiKey = reader.GetString(reader.GetOrdinal("ApiKey"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }
        public string Gravar(TRegistro_LojaVirtual val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOJA", val.Id_loja);
            hs.Add("@P_NM_LOJA", val.Nm_loja);
            hs.Add("@P_USERNAME", val.UserName);
            hs.Add("@P_APIKEY", val.ApiKey);
            return executarProc("IA_DIV_LOJAVIRTUAL", hs);
        }
        public string Excluir(TRegistro_LojaVirtual val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOJA", val.Id_loja);
            return executarProc("EXCLUI_DIV_LOJAVIRTUAL", hs);
        }
    }
}
