using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadSerieNF : List<TRegistro_CadSerieNF>, IComparer<TRegistro_CadSerieNF>
    {
        #region IComparer<TRegistro_CadSerieNF> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadSerieNF()
        { }

        public TList_CadSerieNF(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSerieNF value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSerieNF x, TRegistro_CadSerieNF y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }
    
    public class TRegistro_CadSerieNF
    {
        public string Nr_Serie{get;set; }
        public string CD_Modelo{get;set;}
        public string DS_Modelo{get; set;}
        public string DS_SerieNf{get; set;}
        public string ST_Registro{get; set;}
        private string st_gerasintegra;
        public string ST_GeraSintegra
        {
            get { return st_gerasintegra; }
            set 
            { 
                    st_gerasintegra = value;
                    st_gerasintegrabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerasintegrabool;
        public bool St_gerasintegrabool
        {
            get { return st_gerasintegrabool; }
            set
            {
                st_gerasintegrabool = value;
                st_gerasintegra = value ? "S" : "N";
            }
        }
        private string st_sequenciaauto;
        public string ST_SequenciaAuto
        {
            get { return st_sequenciaauto; }
            set { 
                st_sequenciaauto = value;
                st_sequenciaautobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sequenciaautobool;
        public bool ST_SequenciaAutoBool
        {
            get { return st_sequenciaautobool; }
            set
            {
                st_sequenciaautobool = value;
                st_sequenciaauto = value ? "S" : "N";
            }
        }
        private string tp_serie;
        public string Tp_serie
        {
            get { return tp_serie; }
            set
            {
                tp_serie = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_serie = "PRODUTO";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_serie = "SERVIÇO";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_serie = "MISTO - PRODUTO E SERVIÇO";
            }
        }
        private string tipo_serie;
        public string Tipo_serie
        {
            get { return tipo_serie; }
            set
            {
                tipo_serie = value;
                if (value.Trim().ToUpper().Equals("PRODUTO"))
                    tp_serie = "P";
                else if (value.Trim().ToUpper().Equals("SERVIÇO"))
                    tp_serie = "S";
                else if (value.Trim().ToUpper().Equals("MISTO - PRODUTO E SERVIÇO"))
                    tp_serie = "M";
            }
        }

        public TRegistro_CadSerieNF()
        {
            Nr_Serie = string.Empty;
            CD_Modelo = string.Empty;
            DS_Modelo = string.Empty;
            DS_SerieNf = string.Empty;
            ST_Registro = "A";
            st_gerasintegra = "S";
            st_gerasintegrabool = true;
            st_sequenciaauto = string.Empty;
            st_sequenciaautobool = false;
            tp_serie = string.Empty;
            tipo_serie = string.Empty;
        }

        public override string ToString()
        {
            return Nr_Serie.Trim() + "-" + DS_SerieNf.Trim();
        }
    }

    public class TCD_CadSerieNF : TDataQuery
    {
        public TCD_CadSerieNF()
        { }

        public TCD_CadSerieNF(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.nr_serie, a.cd_modelo, b.ds_modelo, ");
                sql.AppendLine("a.ds_serienf, a.st_gerasintegra, a.st_sequenciaauto, a.tp_serie, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAT_SerieNF a ");
            sql.AppendLine("inner join TB_FAT_ModeloNF b ");
            sql.AppendLine("on b.cd_modelo = a.cd_modelo ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.nr_serie asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadSerieNF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadSerieNF lista = new TList_CadSerieNF();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSerieNF reg = new TRegistro_CadSerieNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_Serie = reader.GetString(reader.GetOrdinal("nr_serie")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.CD_Modelo = reader.GetString(reader.GetOrdinal("cd_modelo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.DS_Modelo = reader.GetString(reader.GetOrdinal("ds_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.DS_SerieNf = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerasintegra")))
                        reg.ST_GeraSintegra = reader.GetString(reader.GetOrdinal("st_gerasintegra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_sequenciaauto")))
                        reg.ST_SequenciaAuto = reader.GetString(reader.GetOrdinal("st_sequenciaauto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_serie")))
                        reg.Tp_serie = reader.GetString(reader.GetOrdinal("tp_serie"));
                    
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_CadSerieNF vRegistro)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_Serie);
            hs.Add("@P_CD_MODELO", vRegistro.CD_Modelo);
            hs.Add("@P_DS_SERIENF", vRegistro.DS_SerieNf);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            hs.Add("@P_ST_GERASINTEGRA", vRegistro.ST_GeraSintegra);
            hs.Add("@P_TP_SERIE", vRegistro.Tp_serie);
            hs.Add("@P_ST_SEQUENCIAAUTO", vRegistro.ST_SequenciaAuto);

            return executarProc("IA_FAT_SERIENF", hs);
        }

        public string Deleta(TRegistro_CadSerieNF vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_Serie);
            hs.Add("@P_CD_MODELO", vRegistro.CD_Modelo);

            return executarProc("EXCLUI_FAT_SERIENF", hs);
        }
    }
}