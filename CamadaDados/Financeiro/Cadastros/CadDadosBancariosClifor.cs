using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadDadosBancariosClifor : List<TRegistro_CadDadosBancariosClifor>
    { }

    public class TRegistro_CadDadosBancariosClifor
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_agencia
        { get; set; }
        public string Nr_conta
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string Ds_banco
        { get; set; }
        public string St_registro
        { get; set; }

        public TRegistro_CadDadosBancariosClifor()
        {
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Nr_agencia = string.Empty;
            this.Nr_conta = string.Empty;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_DadosBancariosClifor : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string strTop = "";
            if (vTop > 0)
                strTop = "top" + Convert.ToString(vTop);
            sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" select " + strTop + "a.cd_clifor, b.nm_clifor, a.nr_agencia, a.nr_conta, ");
                sql.AppendLine("a.cd_banco, c.ds_banco, a.st_registro ");
            }
            else
                sql.AppendLine(" select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("from tb_fin_dados_bancarios_clifor a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join tb_fin_banco c ");
            sql.AppendLine("on a.cd_banco = c.cd_banco ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + "" + vBusca[i].vOperador + "" + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_CadDadosBancariosClifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadDadosBancariosClifor lista = new TList_CadDadosBancariosClifor();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                while (reader.Read())
                {
                    TRegistro_CadDadosBancariosClifor reg = new TRegistro_CadDadosBancariosClifor();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Agencia")))
                        reg.Nr_agencia = reader.GetString(reader.GetOrdinal("NR_Agencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Conta")))
                        reg.Nr_conta = reader.GetString(reader.GetOrdinal("NR_Conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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
        public string GravarDadosBancariosClifor(TRegistro_CadDadosBancariosClifor val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NR_AGENCIA", val.Nr_agencia);
            hs.Add("@P_NR_CONTA", val.Nr_conta);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIN_DADOS_BANCARIOS_CLIFOR", hs);
        }
        public string DeletarDadosBancariosClifor(TRegistro_CadDadosBancariosClifor val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NR_AGENCIA", val.Nr_agencia);
            hs.Add("@P_NR_CONTA", val.Nr_conta);

            return this.executarProc("EXCLUI_FIN_DADOS_BANCARIOS_CLIFOR", hs);
        }
    }
}
