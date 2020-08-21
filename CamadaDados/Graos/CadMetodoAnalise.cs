using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_MetodoAnalise : List<TRegistro_MetodoAnalise>
    { }

    
    public class TRegistro_MetodoAnalise
    {
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

        public TRegistro_MetodoAnalise()
        {
            this.id_metodo = null;
            this.id_metodostr = string.Empty;
            this.Ds_metodo = string.Empty;
        }
    }

    public class TCD_MetodoAnalise : TDataQuery
    {
        public TCD_MetodoAnalise()
        { }

        public TCD_MetodoAnalise(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + "a.id_metodo, a.ds_metodo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_metodoanalise a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
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

        public TList_MetodoAnalise Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MetodoAnalise lista = new TList_MetodoAnalise();
            System.Data.SqlClient.SqlDataReader reader = null;
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
                    TRegistro_MetodoAnalise reg = new TRegistro_MetodoAnalise();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_metodo")))
                        reg.Id_metodo = reader.GetDecimal(reader.GetOrdinal("id_metodo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_metodo")))
                        reg.Ds_metodo = reader.GetString(reader.GetOrdinal("ds_metodo"));
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

        public string Gravar(TRegistro_MetodoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_METODO", val.Id_metodo);
            hs.Add("@P_DS_METODO", val.Ds_metodo);

            return this.executarProc("IA_GRO_METODOANALISE", hs);
        }

        public string Excluir(TRegistro_MetodoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_METODO", val.Id_metodo);

            return this.executarProc("EXCLUI_GRO_METODOANALISE", hs);
        }
    }
}
