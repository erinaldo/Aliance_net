using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_DescontoXAmostra : List<TRegistro_DescontoXAmostra>, IComparer<TRegistro_DescontoXAmostra>
    {
        #region IComparer<TRegistro_DescontoXAmostra> Members
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

        public TList_DescontoXAmostra()
        { }

        public TList_DescontoXAmostra(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DescontoXAmostra value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DescontoXAmostra x, TRegistro_DescontoXAmostra y)
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

    
    public class TRegistro_DescontoXAmostra
    {
        
        public string Cd_tabeladesconto
        { get; set; }
        
        public string Ds_tabeladesconto
        { get; set; }
        
        public string Cd_tipoamostra
        { get; set; }
        
        public string Ds_tipoamostra
        { get; set; }
        
        public string Ordem
        { get; set; }
        
        public decimal Maiorque
        { get; set; }
        
        public decimal Menorque
        { get; set; }
        private string capturapeso;
        
        public string Capturapeso
        {
            get { return capturapeso; }
            set
            {
                capturapeso = value;
                capturapesobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool capturapesobool;
        
        public bool Capturapesobool
        {
            get { return capturapesobool; }
            set
            {
                capturapesobool = value;
                capturapeso = value ? "S" : "N";
            }
        }
        private string capturareferencia;
        
        public string Capturareferencia
        {
            get { return capturareferencia; }
            set
            {
                capturareferencia = value;
                capturareferenciabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool capturareferenciabool;
        
        public bool Capturareferenciabool
        {
            get { return capturareferenciabool; }
            set
            {
                capturareferenciabool = value;
                capturareferencia = value ? "S" : "N";
            }
        }
        private string informarR_P;
        
        public string InformarR_P
        {
            get { return informarR_P; }
            set
            {
                informarR_P = value;
                if(value.Trim().ToUpper().Equals("P"))
                    informarR_Pstr = "PESO";
                else if(value.Trim().ToUpper().Equals("R"))
                    informarR_Pstr = "PERCENTUAL";
            }
        }
        private string informarR_Pstr;
        
        public string InformarR_Pstr
        {
            get { return informarR_Pstr; }
            set
            {
                informarR_Pstr = value;
                if (value.Trim().ToUpper().Equals("PESO"))
                    informarR_P = "P";
                else if(value.Trim().ToUpper().Equals("PERCENTUAL"))
                    informarR_P = "R";
            }
        }
        
        public decimal Fator_conversao
        { get; set; }
        
        public decimal Ps_referencia_padrao
        { get; set; }
        private string tp_desconto;
        
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("B"))
                    tipo_desconto = "BRUTO";
                else if (value.Trim().ToUpper().Equals("L"))
                    tipo_desconto = "LIQUIDO";
            }
        }
        private string tipo_desconto;
        
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().ToUpper().Equals("BRUTO"))
                    tp_desconto = "B";
                else if (value.Trim().ToUpper().Equals("LIQUIDO"))
                    tp_desconto = "L";
            }
        }
        
        public string Cd_protocolo
        { get; set; }
        
        public string Ds_protocolo
        { get; set; }
        
        public string Cd_protocolo_ref
        { get; set; }
        
        public string Ds_protocolo_ref
        { get; set; }
        
        public string St_registro
        { get; set; }

        
        public TList_PercDesconto lPerc
        { get; set; }
        
        public TList_PercDesconto lPercDel
        { get; set; }

        public TRegistro_DescontoXAmostra()
        {
            this.capturapeso = "N";
            this.capturapesobool = false;
            this.capturareferencia = "N";
            this.capturareferenciabool = false;
            this.Cd_protocolo = string.Empty;
            this.Cd_protocolo_ref = string.Empty;
            this.Cd_tabeladesconto = string.Empty;
            this.Cd_tipoamostra = string.Empty;
            this.Ds_protocolo = string.Empty;
            this.Ds_protocolo_ref = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.Ds_tipoamostra = string.Empty;
            this.Fator_conversao = 1;
            this.informarR_P = string.Empty;
            this.informarR_Pstr = string.Empty;
            this.Maiorque = decimal.Zero;
            this.Menorque = decimal.Zero;
            this.Ps_referencia_padrao = decimal.Zero;
            this.St_registro = "A";
            this.tipo_desconto = string.Empty;
            this.tp_desconto = string.Empty;
            this.Ordem = string.Empty;
            this.lPerc = new TList_PercDesconto();
            this.lPercDel = new TList_PercDesconto();
        }
    }

    public class TCD_DescontoXAmostra : TDataQuery
    {
        public TCD_DescontoXAmostra()
        { }

        public TCD_DescontoXAmostra(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " CapturaPeso, CapturaReferencia, a.Cd_Protocolo, a.Cd_Protocolo_Ref, ");
                sql.AppendLine("d.ds_protocolo as ds_protocolo_peso, e.ds_protocolo as ds_protocolo_ref, ");
                sql.AppendLine("a.CD_TabelaDesconto, c.DS_TabelaDesconto, a.CD_TipoAmostra, b.DS_Amostra, ");
                sql.AppendLine("a.Fator_Conversao, InformarR_P, a.MaiorQue, ");
                sql.AppendLine("a.MenorQue, a.Ps_ReferenciaPadrao, a.ST_Registro, Tp_Desconto, b.ordem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_GRO_DescontoXAmostra a ");
            sql.AppendLine("inner join TB_GRO_Amostra b ");
            sql.AppendLine("on a.CD_TipoAmostra = b.CD_tipoAmostra ");
            sql.AppendLine("inner join TB_GRO_TabelaDesconto c ");
            sql.AppendLine("On a.CD_TabelaDesconto = c.CD_TabelaDesconto ");
            sql.AppendLine("left outer join TB_Div_Protocolo d ");
            sql.AppendLine("On a.cd_Protocolo = d.cd_protocolo ");
            sql.AppendLine("left outer join TB_Div_Protocolo e ");
            sql.AppendLine("On a.cd_Protocolo_Ref = e.cd_protocolo ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine(" order by b.ordem ");
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

        public TList_DescontoXAmostra Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DescontoXAmostra lista = new TList_DescontoXAmostra();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_DescontoXAmostra reg = new TRegistro_DescontoXAmostra();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra")))
                        reg.Cd_tipoamostra = reader.GetString(reader.GetOrdinal("cd_tipoamostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_amostra")))
                        reg.Ds_tipoamostra = (reader.GetString(reader.GetOrdinal("ds_amostra")));
                    if (!reader.IsDBNull(reader.GetOrdinal("ordem")))
                        reg.Ordem = reader.GetString(reader.GetOrdinal("Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Maiorque")))
                        reg.Maiorque = reader.GetDecimal(reader.GetOrdinal("Maiorque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Menorque")))
                        reg.Menorque = reader.GetDecimal(reader.GetOrdinal("Menorque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapturaPeso")))
                        reg.Capturapeso = reader.GetString(reader.GetOrdinal("CapturaPeso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapturaReferencia")))
                        reg.Capturareferencia = reader.GetString(reader.GetOrdinal("CapturaReferencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("InformarR_P")))
                        reg.InformarR_P = reader.GetString(reader.GetOrdinal("InformarR_P"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fator_Conversao")))
                        reg.Fator_conversao = reader.GetDecimal(reader.GetOrdinal("Fator_Conversao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_ReferenciaPadrao")))
                        reg.Ps_referencia_padrao = reader.GetDecimal(reader.GetOrdinal("Ps_ReferenciaPadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("TP_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Protocolo")))
                        reg.Cd_protocolo = reader.GetString(reader.GetOrdinal("CD_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_protocolo_peso")))
                        reg.Ds_protocolo = reader.GetString(reader.GetOrdinal("ds_protocolo_peso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Protocolo_Ref")))
                        reg.Cd_protocolo_ref = reader.GetString(reader.GetOrdinal("CD_Protocolo_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_protocolo_ref")))
                        reg.Ds_protocolo_ref = reader.GetString(reader.GetOrdinal("ds_protocolo_ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
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

        public string Gravar(TRegistro_DescontoXAmostra val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);
            hs.Add("@P_MAIORQUE", val.Maiorque);
            hs.Add("@P_MENORQUE", val.Menorque);
            hs.Add("@P_CAPTURAPESO", val.Capturapeso);
            hs.Add("@P_CAPTURAREFERENCIA", val.Capturareferencia);
            hs.Add("@P_INFORMARR_P", val.InformarR_P);
            hs.Add("@P_FATOR_CONVERSAO", val.Fator_conversao);
            hs.Add("@P_PS_REFERENCIAPADRAO", val.Ps_referencia_padrao);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);
            hs.Add("@P_CD_PROTOCOLO_REF", val.Cd_protocolo_ref);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_GRO_DESCONTOXAMOSTRA", hs);
        }

        public string Excluir(TRegistro_DescontoXAmostra val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);

            return this.executarProc("EXCLUI_GRO_DESCONTOXAMOSTRA", hs);
        }
    }
}
