using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
 public class TList_CadAmostra : List<TRegistro_CadAmostra>
    {
    }

    
    public class TRegistro_CadAmostra
    {
        
        public string CD_TipoAmostra { get; set;}
        
        public string Ds_Amostra{get; set;}
        private decimal? id_metodo;
        
        public decimal? Id_metodo
        {
            get { return id_metodo; }
            set
            {
                id_metodo = value;
                id_metodostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_metodostr;
        
        public string Id_metodostr
        {
            get { return id_metodostr; }
            set
            {
                id_metodostr = value;
                try
                {
                    id_metodo = Convert.ToDecimal(value);
                }
                catch
                { id_metodo = null; }
            }
        }
        
        public string Ds_metodo
        { get; set; }
        
        public string Ordem{get; set;}
        private string st_gerasubproduto;
        
        public string St_gerasubproduto
        {
            get { return st_gerasubproduto; }
            set
            {
                st_gerasubproduto = value;
                st_gerasubprodutobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerasubprodutobool;
        
        public bool St_gerasubprodutobool
        {
            get { return st_gerasubprodutobool; }
            set
            {
                st_gerasubprodutobool = value;
                st_gerasubproduto = value ? "S" : "N";
            }
        }
        
        public string St_Registro{ get; set;}
        
        public TRegistro_CadAmostra()
        {
            this.CD_TipoAmostra = string.Empty;
            this.Ds_Amostra = string.Empty;
            this.id_metodo = null;
            this.id_metodostr = string.Empty;
            this.Ds_metodo = string.Empty;
            this.st_gerasubproduto = "N";
            this.st_gerasubprodutobool = false;
            this.St_Registro = "A";
            this.Ordem = string.Empty;
        }
    }

    public class TCD_CadAmostra : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_tipoamostra, a.ds_amostra, ");
                sql.AppendLine("a.st_registro, ordem, a.id_metodo, b.ds_metodo, a.st_gerasubproduto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_amostra a ");
            sql.AppendLine("left outer join tb_gro_metodoanalise b ");
            sql.AppendLine("on a.id_metodo = b.id_metodo ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.ds_amostra");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadAmostra Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadAmostra lista = new TList_CadAmostra();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAmostra reg = new TRegistro_CadAmostra();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra")))
                        reg.CD_TipoAmostra = reader.GetString(reader.GetOrdinal("cd_tipoamostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_amostra")))
                        reg.Ds_Amostra = reader.GetString(reader.GetOrdinal("ds_amostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ordem")))
                        reg.Ordem = reader.GetString(reader.GetOrdinal("ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Metodo")))
                        reg.Id_metodo = reader.GetDecimal(reader.GetOrdinal("ID_Metodo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Metodo")))
                        reg.Ds_metodo = reader.GetString(reader.GetOrdinal("DS_Metodo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerasubproduto")))
                        reg.St_gerasubproduto = reader.GetString(reader.GetOrdinal("st_gerasubproduto"));
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

        public string Grava(TRegistro_CadAmostra vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_TIPOAMOSTRA", vRegistro.CD_TipoAmostra);
            hs.Add("@P_DS_AMOSTRA", vRegistro.Ds_Amostra);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_Registro);
            hs.Add("@P_ORDEM", vRegistro.Ordem);
            hs.Add("@P_ID_METODO", vRegistro.Id_metodo);
            hs.Add("@P_ST_GERASUBPRODUTO", vRegistro.St_gerasubproduto);

            return this.executarProc("IA_GRO_AMOSTRA", hs);
        }

        public string Deleta(TRegistro_CadAmostra vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_TIPOAMOSTRA", vRegistro.CD_TipoAmostra);
            return this.executarProc("EXCLUI_GRO_AMOSTRA", hs);
        }

    }
}