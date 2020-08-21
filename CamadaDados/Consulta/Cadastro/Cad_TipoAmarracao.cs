using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Linq;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_TipoAmarracao : List<TRegistro_Cad_TipoAmarracao>{ }

    public class TRegistro_Cad_TipoAmarracao
    {
        public string _ID_Tipo_Amarracao;
        public string ID_Tipo_Amarracao_STR
        {
            get { return this._ID_Tipo_Amarracao; }
            set { 
                try {
                    this._ID_Tipo_Amarracao = (decimal.Parse(value)).ToString(); 
                } 
                catch {
                    this._ID_Tipo_Amarracao = null; 
                } 
            } 
        }
        public decimal ID_Tipo_Amarracao
        { 
            get { 
                try {
                    return decimal.Parse(_ID_Tipo_Amarracao); 
                } 
                catch { 
                    return 0; 
                }
            }
            set { _ID_Tipo_Amarracao = value.ToString(); }
        }
        public string Nm_Tipo_Amarracao 
        { get; set; }
        public string Sigla_Amarracao
        { get; set; }
       
        public TRegistro_Cad_TipoAmarracao()
        {
            this._ID_Tipo_Amarracao = string.Empty;
            this.Nm_Tipo_Amarracao = string.Empty;
            this.Sigla_Amarracao   = string.Empty;
            this.ID_Tipo_Amarracao_STR = string.Empty;
        }
    }

    public class TCD_Cad_TipoAmarracao : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.ID_Tipo_Amarracao, a.Nm_Tipo_Amarracao,  a.Sigla_Amarracao ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CON_Tipo_Amarracao a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
              

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_TipoAmarracao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_TipoAmarracao lista = new TList_Cad_TipoAmarracao();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_TipoAmarracao reg = new TRegistro_Cad_TipoAmarracao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Tipo_Amarracao"))))
                        reg.ID_Tipo_Amarracao = reader.GetDecimal(reader.GetOrdinal("ID_Tipo_Amarracao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_Tipo_Amarracao"))))
                        reg.Nm_Tipo_Amarracao = reader.GetString(reader.GetOrdinal("Nm_Tipo_Amarracao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_Amarracao"))))
                        reg.Sigla_Amarracao = reader.GetString(reader.GetOrdinal("Sigla_Amarracao"));



                    
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

        public string GravarTipo_Amarracao(TRegistro_Cad_TipoAmarracao val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_TIPO_AMARRACAO", val.ID_Tipo_Amarracao_STR);
            hs.Add("@P_NM_TIPO_AMARRACAO", val.Nm_Tipo_Amarracao);
            hs.Add("@P_SIGLA_AMARRACAO", val.Sigla_Amarracao);



            return this.executarProc("IA_CON_TIPO_AMARRACAO", hs);
        }

        public string DeletarTipo_Amarracao(TRegistro_Cad_TipoAmarracao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TIPO_AMARRACAO", val.ID_Tipo_Amarracao);
            return this.executarProc("EXCLUI_CON_TIPO_AMARRACAO", hs);
        }
    }
}
