using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Almoxarifado
{
    public class TList_AlocacaoItem : List<TRegistro_AlocacaoItem>
    { }

    
    public class TRegistro_AlocacaoItem
    {
        private decimal? id_entrega;
        
        public decimal? Id_entrega
        {
            get { return id_entrega; }
            set
            {
                id_entrega = value;
                id_entregastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_entregastr;
        
        public string Id_entregastr
        {
            get { return id_entregastr; }
            set
            {
                id_entregastr = value;
                try
                {
                    id_entrega = decimal.Parse(value);
                }
                catch
                { id_entrega = null; }
            }
        }
        private decimal? id_almox;
        
        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_almoxstr;
        
        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = decimal.Parse(value);
                }
                catch
                { id_almox = null; }
            }
        }

        public TRegistro_AlocacaoItem()
        {
            this.id_entrega = null;
            this.id_entregastr = string.Empty;
            this.id_almox = null;
            this.id_almoxstr = string.Empty;
        }
    }

    public class TCD_AlocacaoItem : TDataQuery
    {
        public TCD_AlocacaoItem()
        { }

        public TCD_AlocacaoItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_entrega, a.id_almox ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_AMX_AlocacaoItem a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AlocacaoItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AlocacaoItem lista = new TList_AlocacaoItem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AlocacaoItem reg = new TRegistro_AlocacaoItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_entrega")))
                        reg.Id_entrega = reader.GetDecimal(reader.GetOrdinal("id_entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("id_almox"));

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

        public string Gravar(TRegistro_AlocacaoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ENTREGA", val.Id_entrega);
            hs.Add("@P_ID_ALMOX", val.Id_almox);

            return this.executarProc("IA_AMX_ALOCACAOITEM", hs);
        }

        public string Excluir(TRegistro_AlocacaoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ENTREGA", val.Id_entrega);
            hs.Add("@P_ID_ALMOX", val.Id_almox);

            return this.executarProc("EXCLUI_AMX_ALOCACAOITEM", hs);
        }
    }
}
