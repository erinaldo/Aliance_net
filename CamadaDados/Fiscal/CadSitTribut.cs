using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{    
    public class TRegistro_CadSitTribut
    {
        public string Cd_st
        { get; set; }
        public string Ds_situacao
        { get; set; }
        public string cd_ds
        { get { return this.Cd_st.Trim() + " - " + this.Ds_situacao.Trim(); } }
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
        private string tp_situacao;
        public string Tp_situacao
        {
            get { return tp_situacao; }
            set
            {
                tp_situacao = value;
                if (tp_situacao.Trim().ToUpper().Equals("1"))
                    tipo_situacao = "TRIBUTADO";
                else if (tp_situacao.Trim().ToUpper().Equals("2"))
                    tipo_situacao = "ISENTA";
                else if (tp_situacao.Trim().ToUpper().Equals("3"))
                    tipo_situacao = "OUTRAS";
            }
        }
        private string tipo_situacao;
        public string Tipo_situacao
        {
            get { return tipo_situacao; }
            set
            {
                tipo_situacao = value;
                if (value.Trim().ToUpper().Equals("TRIBUTADO"))
                    tp_situacao = "1";
                else if (value.Trim().ToUpper().Equals("ISENTA"))
                    tp_situacao = "2";
                else if (value.Trim().ToUpper().Equals("OUTRAS"))
                    tp_situacao = "3";
            }
        }
        private string st_simplesnacional;
        public string St_simplesnacional
        {
            get { return st_simplesnacional; }
            set
            {
                st_simplesnacional = value;
                st_simplesnacionalbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_simplesnacionalbool;
        public bool St_simplesnacionalbool
        {
            get { return st_simplesnacionalbool; }
            set
            {
                st_simplesnacionalbool = value;
                st_simplesnacional = value ? "S" : "N";
            }
        }
        private string st_substtrib;
        public string St_substtrib
        {
            get { return st_substtrib; }
            set
            {
                st_substtrib = value;
                st_substtribbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_substtribbool;
        public bool St_substtribbool
        {
            get { return st_substtribbool; }
            set
            {
                st_substtribbool = value;
                st_substtrib = value ? "S" : "N";
            }
        }

        public TRegistro_CadSitTribut()
        {
            this.Cd_st = string.Empty;
            this.Ds_situacao = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.tp_situacao = string.Empty;
            this.tipo_situacao = string.Empty;
            this.st_simplesnacional = "N";
            this.st_simplesnacionalbool = false;
            this.st_substtrib = "N";
            this.st_substtribbool = false;
        }
    }
    
    public class TList_CadSitTribut : List<TRegistro_CadSitTribut>
    { }

    public class TCD_CadSitTribut : TDataQuery
    {
        public TCD_CadSitTribut()
        { }

        public TCD_CadSitTribut(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_st, a.ds_situacao, ");
                sql.AppendLine("a.cd_imposto, b.ds_imposto, a.tp_situacao, ");
                sql.AppendLine("a.st_simplesnacional, a.st_substtrib ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_SitTribut a ");
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
        
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override Object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadSitTribut Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadSitTribut lista = new TList_CadSitTribut();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSitTribut reg = new TRegistro_CadSitTribut();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_St")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("CD_St"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("DS_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("tp_situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_simplesnacional")))
                        reg.St_simplesnacional = reader.GetString(reader.GetOrdinal("st_simplesnacional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_substtrib")))
                        reg.St_substtrib = reader.GetString(reader.GetOrdinal("st_substtrib"));

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

        public string gravarSitTribut(TRegistro_CadSitTribut val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_DS_SITUACAO", val.Ds_situacao);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_TP_SITUACAO", val.Tp_situacao);
            hs.Add("@P_ST_SIMPLESNACIONAL", val.St_simplesnacional);
            hs.Add("@P_ST_SUBSTTRIB", val.St_substtrib);

            return executarProc("IA_FIS_SITTRIBUT", hs);
        }

        public string deletarSitTribut(TRegistro_CadSitTribut val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);

            return executarProc("EXCLUI_FIS_SITTRIBUT", hs);
        }
    }
}
