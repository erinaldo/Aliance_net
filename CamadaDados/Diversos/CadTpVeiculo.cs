using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Diversos
{
    public class TList_CadTpVeiculo : List<TRegistro_CadTpVeiculo>, IComparer<TRegistro_CadTpVeiculo>
    {
        #region IComparer<TRegistro_CadTpVeiculo> Members
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

        public TList_CadTpVeiculo()
        { }

        public TList_CadTpVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTpVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTpVeiculo x, TRegistro_CadTpVeiculo y)
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

    
    public class TRegistro_CadTpVeiculo
    {
        
        public string CD_TpVeiculo { get; set; }
        
        public string DS_TpVeiculo { get; set; }
        private string tp_veiculo;
        
        public string Tp_veiculo
        {
            get { return tp_veiculo; }
            set
            {
                tp_veiculo = value;
                if (value.Trim().ToUpper().Equals("T"))
                    tipo_veiculo = "TRAÇÃO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_veiculo = "REBOQUE";
            }
        }
        private string tipo_veiculo;
        
        public string Tipo_veiculo
        {
            get { return tipo_veiculo; }
            set
            {
                tipo_veiculo = value;
                if (value.Trim().ToUpper().Equals("TRAÇÃO"))
                    tp_veiculo = "T";
                else if (value.Trim().ToUpper().Equals("REBOQUE"))
                    tp_veiculo = "R";
            }
        }
        private string tp_rodado;
        
        public string Tp_rodado
        {
            get { return tp_rodado; }
            set
            {
                tp_rodado = value;
                if (value.Trim().Equals("00"))
                    tipo_rodado = "NÃO APLICAVEL";
                else if (value.Trim().Equals("01"))
                    tipo_rodado = "TRUCK";
                else if (value.Trim().Equals("02"))
                    tipo_rodado = "TOCO";
                else if (value.Trim().Equals("03"))
                    tipo_rodado = "CAVALO MECANICO";
                else if (value.Trim().Equals("04"))
                    tipo_rodado = "VAN";
                else if (value.Trim().Equals("05"))
                    tipo_rodado = "UTILITARIO";
                else if (value.Trim().Equals("06"))
                    tipo_rodado = "OUTROS";
            }
        }
        private string tipo_rodado;
        
        public string Tipo_rodado
        {
            get { return tipo_rodado; }
            set
            {
                tipo_rodado = value;
                if (value.Trim().ToUpper().Equals("NÃO APLICAVEL"))
                    tp_rodado = "00";
                else if (value.Trim().ToUpper().Equals("TRUCK"))
                    tp_rodado = "01";
                else if (value.Trim().ToUpper().Equals("TOCO"))
                    tp_rodado = "02";
                else if (value.Trim().ToUpper().Equals("CAVALO MECANICO"))
                    tp_rodado = "03";
                else if (value.Trim().ToUpper().Equals("VAN"))
                    tp_rodado = "04";
                else if (value.Trim().ToUpper().Equals("UTILITARIO"))
                    tp_rodado = "05";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_rodado = "06";
            }
        }
        
        public string ST_Registro { get; set; }

        public TRegistro_CadTpVeiculo()
        {
            this.CD_TpVeiculo = string.Empty;
            this.DS_TpVeiculo = string.Empty;
            this.tp_veiculo = string.Empty;
            this.tipo_veiculo = string.Empty;
            this.tp_rodado = string.Empty;
            this.tipo_rodado = string.Empty;
            this.ST_Registro = "A";
        }
    }

    public class TCD_CadTpVeiculo : TDataQuery
    {
        public TCD_CadTpVeiculo()
        { }

        public TCD_CadTpVeiculo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" Select " + strTop + " a.cd_tpveiculo, a.ds_tpveiculo, a.tp_veiculo, a.tp_rodado ");
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo);

            sql.AppendLine("From tb_div_tpveiculo a ");
            sql.AppendLine("WHERE ISNULL(a.ST_REGISTRO, 'A') <> 'C' ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public TList_CadTpVeiculo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTpVeiculo lista = new TList_CadTpVeiculo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTpVeiculo cadTpVeiculo = new TRegistro_CadTpVeiculo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo"))))
                        cadTpVeiculo.CD_TpVeiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpVeiculo"))))
                        cadTpVeiculo.DS_TpVeiculo = reader.GetString(reader.GetOrdinal("DS_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_veiculo")))
                        cadTpVeiculo.Tp_veiculo = reader.GetString(reader.GetOrdinal("tp_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_rodado")))
                        cadTpVeiculo.Tp_rodado = reader.GetString(reader.GetOrdinal("tp_rodado"));

                    lista.Add(cadTpVeiculo);
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

        public string GravaVeiculo(TRegistro_CadTpVeiculo val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_TPVEICULO", val.CD_TpVeiculo);
            hs.Add("@P_DS_TPVEICULO", val.DS_TpVeiculo);
            hs.Add("@P_ST_REGISTRO", val.ST_Registro);
            hs.Add("@P_TP_VEICULO", val.Tp_veiculo);
            hs.Add("@P_TP_RODADO", val.Tp_rodado);

            return executarProc("IA_DIV_TPVeiculo", hs);
        }

        public string DeletaVeiculo(TRegistro_CadTpVeiculo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_TPVEICULO", val.CD_TpVeiculo);
            return this.executarProc("EXCLUI_DIV_TPVeiculo", hs);
        }
    }
}
