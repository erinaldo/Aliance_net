using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_AjusteIPI : List<TRegistro_AjusteIPI>
    { }

    
    public class TRegistro_AjusteIPI
    {
        
        public string Cd_ajusteIPI
        { get; set; }
        
        public string Ds_ajusteIPI
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
        
        public string Tp_natureza
        { get; set; }
        public string Tipo_natureza
        {
            get
            {
                if (Tp_natureza.Trim().ToUpper().Equals("D"))
                    return "DEBITO";
                else if (Tp_natureza.Trim().ToUpper().Equals("C"))
                    return "CREDITO";
                else return string.Empty;
            }
        }
        
        public string Ds_finalidade
        { get; set; }

        public TRegistro_AjusteIPI()
        {
            this.Cd_ajusteIPI = string.Empty;
            this.Ds_ajusteIPI = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Tp_natureza = string.Empty;
            this.Ds_finalidade = string.Empty;
        }
    }

    public class TCD_AjusteIPI : TDataQuery
    {
        public TCD_AjusteIPI()
        { }

        public TCD_AjusteIPI(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_ajusteIPI, a.ds_ajusteIPI, ");
                sql.AppendLine("a.tp_natureza, a.ds_finalidade, a.cd_imposto, b.ds_imposto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_AjusteIPI A ");
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

        public TList_AjusteIPI Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AjusteIPI lista = new TList_AjusteIPI();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AjusteIPI reg = new TRegistro_AjusteIPI();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_ajusteIPI"))))
                        reg.Cd_ajusteIPI = reader.GetString(reader.GetOrdinal("cd_ajusteIPI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_ajusteIPI"))))
                        reg.Ds_ajusteIPI = reader.GetString(reader.GetOrdinal("ds_ajusteIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_natureza")))
                        reg.Tp_natureza = reader.GetString(reader.GetOrdinal("tp_natureza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_finalidade")))
                        reg.Ds_finalidade = reader.GetString(reader.GetOrdinal("ds_finalidade"));
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

        public string Gravar(TRegistro_AjusteIPI val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_AJUSTEIPI", val.Cd_ajusteIPI);
            hs.Add("@P_DS_AJUSTEIPI", val.Ds_ajusteIPI);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_TP_NATUREZA", val.Tp_natureza);
            hs.Add("@P_DS_FINALIDADE", val.Ds_finalidade);

            return this.executarProc("IA_FIS_AJUSTEIPI", hs);
        }

        public string Excluir(TRegistro_AjusteIPI val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_AJUSTEIPI", val.Cd_ajusteIPI);

            return this.executarProc("EXCLUI_FIS_AJUSTEIPI", hs);
        }
    }
}
