using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadDados_Bancarios_Clifor : List<TRegistro_CadDados_Bancarios_Clifor> { }

    
    public class TRegistro_CadDados_Bancarios_Clifor
    {
        
        public string CD_Clifor { get; set; }
        
        public string NM_Clifor { get; set; }
        
        public string NR_Agencia{get;set;}
        
        public string NR_Conta{get;set;}
        
        public string CD_Banco{get;set;}
        
        public string DS_Banco { get; set; }
        public string Tp_conta { get; set; }
        public string Tipo_conta
        {
            get
            {
                if (Tp_conta.Trim().Equals("0"))
                    return "CONTA CORRENTE";
                else if (Tp_conta.Trim().Equals("1"))
                    return "POUPANÇA";
                else return string.Empty;
            }
        }
        public string NM_Favorecido { get; set; } = string.Empty;
        public string DOC_Favorecido { get; set; } = string.Empty;
        public string ST_Registro { get; set; }

        public TRegistro_CadDados_Bancarios_Clifor()
        {
            CD_Clifor = string.Empty;
            NM_Clifor = string.Empty;
            NR_Agencia = string.Empty;
            NR_Conta = string.Empty;
            CD_Banco = string.Empty;
            DS_Banco = string.Empty;
            Tp_conta = string.Empty;
            ST_Registro = string.Empty;
        }
    }

    public class TCD_CadDados_Bancarios_Clifor : TDataQuery
    {
        public TCD_CadDados_Bancarios_Clifor()
        { }

        public TCD_CadDados_Bancarios_Clifor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.CD_Clifor,a.NR_Agencia, ");
                sql.AppendLine("a.NR_Conta, a.CD_Banco, a.TP_Conta, a.ST_Registro, ");
                sql.AppendLine("c.DS_Banco, b.NM_Clifor, a.NM_Favorecido, a.DOC_Favorecido ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FIN_Dados_Bancarios_Clifor a ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_CLIFOR b on (b.CD_Clifor = a.CD_Clifor)");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_BANCO c on (c.CD_Banco = a.CD_Banco)");


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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadDados_Bancarios_Clifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadDados_Bancarios_Clifor lista = new TList_CadDados_Bancarios_Clifor();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadDados_Bancarios_Clifor reg = new TRegistro_CadDados_Bancarios_Clifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                   if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Agencia")))
                        reg.NR_Agencia = reader.GetString(reader.GetOrdinal("NR_Agencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Conta")))
                        reg.NR_Conta = reader.GetString(reader.GetOrdinal("NR_Conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.CD_Banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.DS_Banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("TP_Conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Favorecido")))
                        reg.NM_Favorecido = reader.GetString(reader.GetOrdinal("NM_Favorecido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DOC_Favorecido")))
                        reg.DOC_Favorecido = reader.GetString(reader.GetOrdinal("DOC_Favorecido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    
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

        public string Gravar(TRegistro_CadDados_Bancarios_Clifor vRegistro)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_NR_AGENCIA", vRegistro.NR_Agencia);
            hs.Add("@P_NR_CONTA", vRegistro.NR_Conta);
            hs.Add("@P_CD_BANCO", vRegistro.CD_Banco);
            hs.Add("@P_TP_CONTA", vRegistro.Tp_conta);
            hs.Add("@P_NM_FAVORECIDO", vRegistro.NM_Favorecido);
            hs.Add("@P_DOC_FAVORECIDO", vRegistro.DOC_Favorecido);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);

            return executarProc("IA_FIN_DADOS_BANCARIOS_CLIFOR", hs);
        }

        public string Excluir(TRegistro_CadDados_Bancarios_Clifor vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_NR_AGENCIA", vRegistro.NR_Agencia);
            hs.Add("@P_NR_CONTA", vRegistro.NR_Conta);
            return executarProc("EXCLUI_FIN_DADOS_BANCARIOS_CLIFOR", hs);
        }

    }
}
