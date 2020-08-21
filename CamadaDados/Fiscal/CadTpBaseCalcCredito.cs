using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_TpBaseCalcCredito : List<TRegistro_TpBaseCalcCredito>
    { }

    
    public class TRegistro_TpBaseCalcCredito
    {
        private decimal? id_basecredito;
        
        public decimal? Id_basecredito
        {
            get { return id_basecredito; }
            set
            {
                id_basecredito = value;
                id_basecreditostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_basecreditostr;
        
        public string Id_basecreditostr
        {
            get { return id_basecreditostr; }
            set
            {
                id_basecreditostr = value;
                try
                {
                    id_basecredito = decimal.Parse(value);
                }
                catch
                { id_basecredito = null; }
            }
        }
        
        public string Ds_basecredito
        { get; set; }

        public TRegistro_TpBaseCalcCredito()
        {
            this.id_basecredito = null;
            this.id_basecreditostr = string.Empty;
            this.Ds_basecredito = string.Empty;
        }
    }

    public class TCD_TpBaseCalcCredito : TDataQuery
    {
        public TCD_TpBaseCalcCredito()
        { }

        public TCD_TpBaseCalcCredito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_basecredito, a.ds_basecredito ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_TpBaseCalcCredito a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_TpBaseCalcCredito Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TpBaseCalcCredito lista = new TList_TpBaseCalcCredito();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TpBaseCalcCredito reg = new TRegistro_TpBaseCalcCredito();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_basecredito")))
                        reg.Id_basecredito = reader.GetDecimal(reader.GetOrdinal("id_basecredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_basecredito")))
                        reg.Ds_basecredito = reader.GetString(reader.GetOrdinal("DS_basecredito"));

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

        public string Gravar(TRegistro_TpBaseCalcCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_BASECREDITO", val.Id_basecredito);
            hs.Add("@P_DS_BASECREDITO", val.Ds_basecredito);

            return this.executarProc("IA_FIS_TPBASECALCCREDITO", hs);
        }

        public string Excluir(TRegistro_TpBaseCalcCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_BASECREDITO", val.Id_basecredito);

            return this.executarProc("EXCLUI_FIS_TPBASECALCCREDITO", hs);
        }
    }
}
