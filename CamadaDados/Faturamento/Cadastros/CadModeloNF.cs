using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadModeloNF : List<TRegistro_CadModeloNF> { }

    
    public class TRegistro_CadModeloNF
    {
        
        public string CD_Modelo { get; set;}
        
        public string DS_Modelo { get; set; }
        
        public string ST_Registro { get; set;}
        
        public TRegistro_CadModeloNF()
        {
            this.CD_Modelo = string.Empty;
            this.DS_Modelo = string.Empty;
            this.ST_Registro = "A";
        }
    }

    public class TCD_CadModeloNF : TDataQuery
    {
        public TCD_CadModeloNF()
        { }

        public TCD_CadModeloNF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + "a.cd_modelo, a.ds_modelo, a.st_registro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FAT_ModeloNF a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.cd_modelo asc");
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

        public TList_CadModeloNF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadModeloNF lista = new TList_CadModeloNF();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadModeloNF reg = new TRegistro_CadModeloNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.CD_Modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.DS_Modelo = reader.GetString(reader.GetOrdinal("ds_modelo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
          
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

        public string Grava(TRegistro_CadModeloNF vRegistro)
        {
            Hashtable hs = new Hashtable(3);

            hs.Add("@P_CD_MODELO", vRegistro.CD_Modelo);
            hs.Add("@P_DS_MODELO", vRegistro.DS_Modelo);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);

            return this.executarProc("IA_FAT_MODELONF", hs);
        }

        public string Deleta(TRegistro_CadModeloNF vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_MODELO", vRegistro.CD_Modelo);

            return this.executarProc("EXCLUI_FAT_MODELONF", hs);
        }

    }
}