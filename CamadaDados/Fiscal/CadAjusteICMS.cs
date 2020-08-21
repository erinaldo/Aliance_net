using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_AjusteICMS : List<TRegistro_AjusteICMS>
    { }

    
    public class TRegistro_AjusteICMS
    {
        
        public string Cd_ajuste
        { get; set; }
        
        public string Ds_ajuste
        { get; set; }
        private decimal? cd_imposto;
        
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = decimal.Parse(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        
        public string Ds_imposto
        { get; set; }

        public TRegistro_AjusteICMS()
        {
            this.Cd_ajuste = string.Empty;
            this.Ds_ajuste = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
        }
    }

    public class TCD_AjusteICMS : TDataQuery
    {
        public TCD_AjusteICMS()
        { }

        public TCD_AjusteICMS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.cd_ajuste, a.ds_ajuste, a.cd_imposto, b.ds_imposto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_AjusteICMS A ");
            sql.AppendLine("inner join TB_FIS_Imposto b ");
            sql.AppendLine("on a.cd_imposto = b.cd_imposto ");
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

        public TList_AjusteICMS Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AjusteICMS lista = new TList_AjusteICMS();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AjusteICMS reg = new TRegistro_AjusteICMS();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_ajuste"))))
                        reg.Cd_ajuste = reader.GetString(reader.GetOrdinal("cd_ajuste"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_ajuste"))))
                        reg.Ds_ajuste = reader.GetString(reader.GetOrdinal("ds_ajuste"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
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

        public string Gravar(TRegistro_AjusteICMS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_AJUSTE", val.Cd_ajuste);
            hs.Add("@P_DS_AJUSTE", val.Ds_ajuste);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);

            return this.executarProc("IA_FIS_AJUSTEICMS", hs);
        }

        public string Excluir(TRegistro_AjusteICMS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_AJUSTE", val.Cd_ajuste);

            return this.executarProc("EXCLUI_FIS_AJUSTEICMS", hs);
        }
    }
}
