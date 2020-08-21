using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TRegistro_CadRequisitos
    {
        public string id_requisito { get; set; } = string.Empty;
        public string ds_requisito { get; set; } = string.Empty;
        public bool st_agregar { get; set; } = false;

    }

    public class TList_CadRequisitos : List<TRegistro_CadRequisitos> { }

    public class TCD_CadRequisitos : TDataQuery
    {
        public TCD_CadRequisitos() { }
        public TCD_CadRequisitos(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_requisito , a.ds_requisito ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_CadRequisito a ");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_CadRequisitos Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadRequisitos lista = new TList_CadRequisitos();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadRequisitos reg = new TRegistro_CadRequisitos();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_requisito")))
                        reg.id_requisito = reader.GetDecimal(reader.GetOrdinal("id_requisito")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_requisito")))
                        reg.ds_requisito = reader.GetString(reader.GetOrdinal("ds_requisito"));

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
        public string Gravar(TRegistro_CadRequisitos val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);
            hs.Add("@P_DS_REQUISITO", val.ds_requisito);

            return executarProc("IA_EMP_CADREQUISITO", hs);
        }
        public string Excluir(TRegistro_CadRequisitos val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);

            return executarProc("EXCLUI_EMP_CADREQUISITO", hs);
        }
    }
}
