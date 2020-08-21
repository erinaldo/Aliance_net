using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_Turno : List<TRegistro_Turno>
    { }

    
    public class TRegistro_Turno
    {
        private decimal? id_turno;
        
        public decimal? Id_turno
        {
            get { return id_turno; }
            set
            {
                id_turno = value;
                id_turnostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_turnostr;
        
        public string Id_turnostr
        {
            get { return id_turnostr; }
            set
            {
                id_turnostr = value;
                try
                {
                    id_turno = Convert.ToDecimal(value);
                }
                catch
                { id_turno = null; }
            }
        }
        
        public string Ds_turno
        { get; set; }

        public TRegistro_Turno()
        {
            this.id_turno = null;
            this.id_turnostr = string.Empty;
            this.Ds_turno = string.Empty;
        }
    }

    public class TCD_Turno : TDataQuery
    {
        public TCD_Turno()
        { }

        public TCD_Turno(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.Append(" Select " + strTop + " a.id_turno, a.ds_turno ");
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.Append("From TB_PRD_Turno a");

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

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Turno Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Turno lista = new TList_Turno();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Turno reg = new TRegistro_Turno();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Turno")))
                        reg.Id_turno = reader.GetDecimal(reader.GetOrdinal("ID_Turno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Turno")))
                        reg.Ds_turno = reader.GetString(reader.GetOrdinal("DS_Turno"));

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

        public string Gravar(TRegistro_Turno val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TURNO", val.Id_turno);
            hs.Add("@P_DS_TURNO", val.Ds_turno);

            return this.executarProc("IA_PRD_TURNO", hs);
        }

        public string Excluir(TRegistro_Turno val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TURNO", val.Id_turno);

            return this.executarProc("EXCLUI_PRD_TURNO", hs);
        }
    }
}
