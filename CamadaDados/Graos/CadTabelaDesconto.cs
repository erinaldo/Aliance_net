using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_TabelaDesconto : List<TRegistro_TabelaDesconto>
    { }

    
    public class TRegistro_TabelaDesconto
    {
        
        public string Cd_tabeladesconto
        { get; set; }
        
        public string Ds_tabeladesconto
        { get; set; }
        
        public string Padrao_qualidade
        { get; set; }
        
        public string St_registro
        { get; set; }

        public TRegistro_TabelaDesconto()
        {
            this.Cd_tabeladesconto = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.Padrao_qualidade = string.Empty;
            this.St_registro = string.Empty;
        }
    }

    public class TCD_TabelaDesconto : TDataQuery
    {
        public TCD_TabelaDesconto()
        { }

        public TCD_TabelaDesconto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_tabeladesconto, ");
                sql.AppendLine("a.ds_tabeladesconto, a.padrao_qualidade, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_gro_tabeladesconto a ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TabelaDesconto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TabelaDesconto lista = new TList_TabelaDesconto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_TabelaDesconto reg = new TRegistro_TabelaDesconto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("padrao_qualidade")))
                        reg.Padrao_qualidade = reader.GetString(reader.GetOrdinal("padrao_qualidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
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

        public string Gravar(TRegistro_TabelaDesconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_DS_TABELADESCONTO", val.Ds_tabeladesconto);
            hs.Add("@P_PADRAO_QUALIDADE", val.Padrao_qualidade);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_GRO_TABELADESCONTO", hs);
        }

        public string Excluir(TRegistro_TabelaDesconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);

            return this.executarProc("EXCLUI_GRO_TABELADESCONTO", hs);
        }
    }
}
