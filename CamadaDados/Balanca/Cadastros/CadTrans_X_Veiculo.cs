using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using CamadaDados;
using Utils;
using System.Runtime.Serialization;

namespace CamadaDados.Balanca.Cadastros
{
    public class TList_CadTransp_X_Veiculo : List<TRegistro_CadTransp_X_Veiculo>, IComparer<TRegistro_CadTransp_X_Veiculo>
    {
        #region IComparer<TRegistro_CadTransp_X_Veiculo> Members
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

        public TList_CadTransp_X_Veiculo()
        { }

        public TList_CadTransp_X_Veiculo(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTransp_X_Veiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTransp_X_Veiculo x, TRegistro_CadTransp_X_Veiculo y)
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

    [DataContract]
    public class TRegistro_CadTransp_X_Veiculo
    {
        [DataMember]
        public string cd_Transp
        {
            get;
            set;
        }
        [DataMember]
        public string nr_Veiculo
        {
            get;
            set;
        }
        [DataMember]
        public string placa
        {
            get;
            set;
        }
        [DataMember]
        public decimal qtd_Caixas { get; set; }
        [DataMember]
        public decimal vl_ConsumoMedio
        {
            get;
            set;
        }
        [DataMember]
        public decimal ps_Combustivel
        {
            get;
            set;
        }
        [DataMember]
        public decimal ps_Tara
        {
            get;
            set;
        }
        [DataMember]
        public decimal ps_Tolerancia_Tara
        {
            get;
            set;
        }
        [DataMember]
        public string cd_TpVeiculo
        {
            get;
            set;
        }
        [DataMember]
        public string ds_TpVeiculo
        {
            get;
            set;
        }
        [DataMember]
        public string nm_Clifor
        {
            get;
            set;
        }
        [DataMember]
        public string St_registro
        {
            get;
            set;
        }

        public TRegistro_CadTransp_X_Veiculo()
        {
            
        }
    }

    public class TCD_CadTransp_X_Veiculo : TDataQuery
    {
     
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.CD_Transp, a. Nr_Veiculo, a.Placa, a.Qtd_Caixas, a.Vl_ConsumoMedio,");
                sql.AppendLine("a.PS_Combustivel, a.Ps_tara, a.PS_Tolerancia_tara, a.CD_TpVeiculo, b.Nm_Clifor, c.DS_TPVeiculo, a.ST_Registro "); 
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_bal_transp_x_veiculo a ");
            sql.AppendLine(" left outer join TB_FIN_Clifor b on (a.cd_transp = b.cd_Clifor)");
            sql.AppendLine(" left outer join TB_DIV_TPVeiculo c on (a.cd_TpVeiculo = c.cd_tpveiculo)");

            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadTransp_X_Veiculo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTransp_X_Veiculo lista = new TList_CadTransp_X_Veiculo();
            SqlDataReader reader = null;
            Int64 x = 0;
            bool podeFecharBco = false;

            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
                else
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                while (reader.Read() && (x <= vTop || vTop == 0))
                {
                    TRegistro_CadTransp_X_Veiculo CadTransp_X_Veiculo = new TRegistro_CadTransp_X_Veiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transp")))
                        CadTransp_X_Veiculo.cd_Transp = reader.GetString(reader.GetOrdinal("CD_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Veiculo")))
                        CadTransp_X_Veiculo.nr_Veiculo = reader.GetString(reader.GetOrdinal("Nr_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                       CadTransp_X_Veiculo.placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Caixas")))
                        CadTransp_X_Veiculo.qtd_Caixas = reader.GetDecimal(reader.GetOrdinal("QTD_Caixas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ConsumoMedio")))
                        CadTransp_X_Veiculo.vl_ConsumoMedio = reader.GetDecimal(reader.GetOrdinal("VL_ConsumoMedio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Combustivel")))
                        CadTransp_X_Veiculo.ps_Combustivel = reader.GetDecimal(reader.GetOrdinal("PS_Combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Tara")))
                        CadTransp_X_Veiculo.ps_Tara = reader.GetDecimal(reader.GetOrdinal("PS_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Tolerancia_tara")))
                        CadTransp_X_Veiculo.ps_Tolerancia_Tara = reader.GetDecimal(reader.GetOrdinal("PS_Tolerancia_tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo")))
                        CadTransp_X_Veiculo.cd_TpVeiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpVeiculo")))
                        CadTransp_X_Veiculo.ds_TpVeiculo = reader.GetString(reader.GetOrdinal("DS_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        CadTransp_X_Veiculo.nm_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        CadTransp_X_Veiculo.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    lista.Add(CadTransp_X_Veiculo);
                    x++;
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

        public string Grava(TRegistro_CadTransp_X_Veiculo vRegistro)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_TRANSP", vRegistro.cd_Transp);
            hs.Add("@P_NR_VEICULO", vRegistro.nr_Veiculo);
            hs.Add("@P_PLACA", vRegistro.placa);
            hs.Add("@P_QTD_CAIXAS", vRegistro.qtd_Caixas);
            hs.Add("@P_VL_CONSUMOMEDIO", vRegistro.vl_ConsumoMedio);
            hs.Add("@P_PS_COMBUSTIVEL", vRegistro.ps_Combustivel);
            hs.Add("@P_PS_TARA", vRegistro.ps_Tara);
            hs.Add("@P_PS_TOLERANCIA_TARA", vRegistro.ps_Tolerancia_Tara);
            hs.Add("@P_CD_TPVEICULO", vRegistro.cd_TpVeiculo);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);

            return executarProc("IA_BAL_TRANSP_X_VEICULO", hs);
        }

        public string Deleta(TRegistro_CadTransp_X_Veiculo vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_TRANSP", vRegistro.cd_Transp);
            hs.Add("@P_NR_VEICULO", vRegistro.nr_Veiculo);
            return executarProc("EXCLUI_BAL_TRANSP_X_VEICULO", hs);
        }
    }

}