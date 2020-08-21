using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Fiscal
{
    
    public class TRegistro_CadTpImposto_x_SitTrib
    {
        
        public string Tp_imposto
        { get; set; }
        
        public string Cd_st
        { get; set; }
        
        public string Ds_situacao
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
                    cd_imposto = Convert.ToDecimal(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        
        public string Ds_imposto
        { get; set; }
        
        public TRegistro_CadTpImposto_x_SitTrib()
        {
            this.Tp_imposto = string.Empty;
            this.Cd_st = string.Empty;
            this.Ds_situacao = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
        }
    }

    public class TList_CadTpImposto_x_SitTrib : List<TRegistro_CadTpImposto_x_SitTrib>
    { }

    public class TCD_CadTpImposto_x_SitTrib : TDataQuery
    {
        public TCD_CadTpImposto_x_SitTrib()
        { }

        public TCD_CadTpImposto_x_SitTrib(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public string GravarImposto(TRegistro_CadTpImposto_x_SitTrib val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_TP_IMPOSTO", val.Tp_imposto);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_ST", val.Cd_st);

            return executarProc("IA_FIS_TIPOIMPOSTO_X_SITTRIB", hs);
        }

        public string DeletarImposto(TRegistro_CadTpImposto_x_SitTrib val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_TP_IMPOSTO", val.Tp_imposto);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_ST", val.Cd_st);

            return executarProc("EXCLUI_FIS_TIPOIMPOSTO_X_SITTRIB", hs);
        }

        public TList_CadTpImposto_x_SitTrib Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadTpImposto_x_SitTrib lista = new TList_CadTpImposto_x_SitTrib();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                if (vNm_Campo.Length > 0)
                    reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTpImposto_x_SitTrib reg = new TRegistro_CadTpImposto_x_SitTrib();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_IMPOSTO"))))
                        reg.Tp_imposto = reader.GetString(reader.GetOrdinal("TP_IMPOSTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_St")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("CD_St"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("DS_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));

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

        public string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.tp_imposto, a.cd_imposto, ");
                sql.AppendLine("b.ds_imposto, a.cd_st, c.ds_situacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fis_tipoimposto_x_sittrib a ");
            sql.AppendLine("inner join tb_fis_imposto b ");
            sql.AppendLine("on a.cd_imposto = b.cd_imposto ");
            sql.AppendLine("inner join tb_fis_sittribut c ");
            sql.AppendLine("on a.cd_st = c.cd_st ");
            sql.AppendLine("and a.cd_imposto = c.cd_imposto ");
            
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    if (vBusca[i].vVL_Busca != null)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " AND ";
                    }

            return sql.ToString();
        }
    }
}

