using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CamadaDados.Fiscal
{
    public class TRegistro_CadCondFiscalClifor
    {
        public string Cd_condFiscal_clifor { get; set; }
        public string Ds_condFiscal { get; set; }
        public string Cd_Ds { get { return Cd_condFiscal_clifor.Trim() + " - " + Ds_condFiscal.Trim(); } }
        public string St_Registro { get; set; }
        public bool St_agregar { get; set; }

        public TRegistro_CadCondFiscalClifor()
        {
            this.Cd_condFiscal_clifor = string.Empty;
            this.Ds_condFiscal = string.Empty;
            this.St_Registro = "A";
            this.St_agregar = false;
        }
    }
   
    public class TList_CadConFiscalClifor : List<TRegistro_CadCondFiscalClifor>, IComparer<TRegistro_CadCondFiscalClifor>
    {
        #region IComparer<TRegistro_CadCondFiscalClifor> Members
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

        public TList_CadConFiscalClifor()
        { }

        public TList_CadConFiscalClifor(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCondFiscalClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCondFiscalClifor x, TRegistro_CadCondFiscalClifor y)
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

    public class TCD_CadConFiscalClifor : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " Cd_condFiscal_clifor, Ds_condFiscal, St_Registro ");
                
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_fis_condfiscal_clifor ");
            sql.AppendLine("Where isNull(St_Registro, 'A') <> 'C'");
            cond = " and ";

            if (vBusca != null)
                if (vBusca.Length > 0)
                {
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        if ((vBusca[i].vOperador.ToUpper() == "IN") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT IN") ||
                            (vBusca[i].vOperador.ToUpper() == "EXISTS") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT EXISTS"))
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        }
                        else
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        }
                    }
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadConFiscalClifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadConFiscalClifor lista = new TList_CadConFiscalClifor();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadCondFiscalClifor reg = new TRegistro_CadCondFiscalClifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_condFiscal_clifor"))))
                        reg.Cd_condFiscal_clifor = reader.GetString(reader.GetOrdinal("Cd_condFiscal_clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_condFiscal"))))
                        reg.Ds_condFiscal = reader.GetString(reader.GetOrdinal("DS_condFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("St_Registro"))))
                        reg.St_Registro = reader.GetString(reader.GetOrdinal("St_Registro"));
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
        
        public string GravarConFisc(TRegistro_CadCondFiscalClifor val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.Cd_condFiscal_clifor);
            hs.Add("@P_DS_CONDFISCAL", val.Ds_condFiscal);
            hs.Add("@P_ST_REGISTRO", val.St_Registro);
            return executarProc("IA_FIS_CONDFISCAL_CLIFOR", hs);
        }
        
        public string DeletarConFisc(TRegistro_CadCondFiscalClifor val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.Cd_condFiscal_clifor);
            return executarProc("EXCLUI_FIS_CONDFISCAL_CLIFOR", hs);
        }
    }
}
