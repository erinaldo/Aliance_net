using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Equipamento : List<TRegistro_Equipamento>, IComparer<TRegistro_Equipamento>
    {
        #region IComparer<TRegistro_Equipamento> Members
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

        public TList_Equipamento()
        { }

        public TList_Equipamento(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Equipamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Equipamento x, TRegistro_Equipamento y)
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

    
    public class TRegistro_Equipamento
    {
        
        public string Cd_equipamento
        { get; set; }
        
        public string Ds_equipamento
        { get; set; }
        
        public string Cd_fazenda
        { get; set; }
        
        public string Nm_fazenda
        { get; set; }
        private string tp_equipamento;
        
        public string Tp_equipamento
        {
            get { return tp_equipamento; }
            set
            {
                tp_equipamento = value;
                if (value.Trim().ToUpper().Equals("M"))
                    tipo_equipamento = "MAQUINA";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_equipamento = "VEICULO";
                else if (value.Trim().ToUpper().Equals("I"))
                    tipo_equipamento = "IMPLEMENTO";
                else if (value.Trim().ToUpper().Equals("O"))
                    tipo_equipamento = "OUTROS";

            }
        }
        private string tipo_equipamento;
        
        public string Tipo_equipamento
        {
            get { return tipo_equipamento; }
            set
            {
                tipo_equipamento = value;
                if (value.Trim().ToUpper().Equals("MAQUINA"))
                    tp_equipamento = "M";
                else if (value.Trim().ToUpper().Equals("VEICULO"))
                    tp_equipamento = "V";
                else if (value.Trim().ToUpper().Equals("IMPLEMENTO"))
                    tp_equipamento = "I";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_equipamento = "O";
                
            }
        }
        private string tp_conservacao;
        
        public string Tp_conservacao
        {
            get { return tp_conservacao; }
            set
            {
                tp_conservacao = value;
                if (value.Trim().ToUpper().Equals("O"))
                    tipo_conservacao = "OTIMO";
                else if (value.Trim().ToUpper().Equals("B"))
                    tipo_conservacao = "BOM";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_conservacao = "REGULAR";
                else if (value.Trim().ToUpper().Equals("U"))
                    tipo_conservacao = "RUIM";
            }
        }
        private string tipo_conservacao;
        
        public string Tipo_conservacao
        {
            get { return tipo_conservacao; }
            set
            {
                tipo_conservacao = value;
                if (value.Trim().ToUpper().Equals("OTIMO"))
                    tp_conservacao = "O";
                else if (value.Trim().ToUpper().Equals("BOM"))
                    tp_conservacao = "B";
                else if (value.Trim().ToUpper().Equals("REGULAR"))
                    tp_conservacao = "R";
                else if (value.Trim().ToUpper().Equals("RUIM"))
                    tp_conservacao = "U";
            }
        }
        
        public decimal Vl_equipamento
        { get; set; }
        private DateTime? dt_aquisicao;
        
        public DateTime? Dt_aquisicao
        {
            get { return dt_aquisicao; }
            set
            {
                dt_aquisicao = value;
                dt_aquisicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aquisicaostr;
        public string Dt_aquisicaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_aquisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aquisicaostr = value;
                try
                {
                    dt_aquisicao = DateTime.Parse(value);
                }
                catch
                { dt_aquisicao = null; }
            }
        }
        
        public string Placa
        { get; set; }
        
        public string AnoFabric
        { get; set; }
        
        public string Observacao
        { get; set; }
        
        public decimal Vl_custohora
        { get; set; }

        public TRegistro_Equipamento()
        {
            this.Cd_equipamento = string.Empty;
            this.Ds_equipamento = string.Empty;
            this.Cd_fazenda = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.tp_equipamento = string.Empty;
            this.tipo_equipamento = string.Empty;
            this.tp_conservacao = string.Empty;
            this.tipo_conservacao = string.Empty;
            this.Vl_equipamento = decimal.Zero;
            this.dt_aquisicao = null;
            this.dt_aquisicaostr = string.Empty;
            this.Placa = string.Empty;
            this.AnoFabric = string.Empty;
            this.Observacao = string.Empty;
            this.Vl_custohora = decimal.Zero;
        }
    }

    public class TCD_Equipamento : TDataQuery
    {
        public TCD_Equipamento()
        { }

        public TCD_Equipamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Equipamento, b.DS_Produto as Ds_equipamento, ");
                sql.AppendLine("a.CD_Fazenda, c.NM_Fazenda, a.TP_Equipamento, a.TP_Conservacao, a.vl_custohora, ");
                sql.AppendLine("a.Vl_Equipamento, a.DT_Aquisicao, a.Placa, a.AnoFabric, a.Observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Equipamento a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Equipamento = b.CD_Produto ");
            sql.AppendLine("inner join VTB_FAZ_FAZENDA c ");
            sql.AppendLine("on a.CD_Fazenda = c.CD_Fazenda ");

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

        public TList_Equipamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Equipamento lista = new TList_Equipamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Equipamento reg = new TRegistro_Equipamento();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Equipamento")))
                        reg.Cd_equipamento = reader.GetString(reader.GetOrdinal("CD_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_equipamento")))
                        reg.Ds_equipamento = reader.GetString(reader.GetOrdinal("Ds_equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Equipamento")))
                        reg.Tp_equipamento = reader.GetString(reader.GetOrdinal("TP_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Conservacao")))
                        reg.Tp_conservacao = reader.GetString(reader.GetOrdinal("TP_Conservacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Equipamento")))
                        reg.Vl_equipamento = reader.GetDecimal(reader.GetOrdinal("Vl_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Aquisicao")))
                        reg.Dt_aquisicao = reader.GetDateTime(reader.GetOrdinal("DT_Aquisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoFabric")))
                        reg.AnoFabric = reader.GetString(reader.GetOrdinal("AnoFabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Observacao")))
                        reg.Observacao = reader.GetString(reader.GetOrdinal("Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custohora")))
                        reg.Vl_custohora = reader.GetDecimal(reader.GetOrdinal("vl_custohora"));

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

        public string Gravar(TRegistro_Equipamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EQUIPAMENTO", val.Cd_equipamento);
            hs.Add("@P_CD_FAZENDA", val.Cd_fazenda);
            hs.Add("@P_TP_EQUIPAMENTO", val.Tp_equipamento);
            hs.Add("@P_TP_CONSERVACAO", val.Tp_conservacao);
            hs.Add("@P_VL_EQUIPAMENTO", val.Vl_equipamento);
            hs.Add("@P_DT_AQUISICAO", val.Dt_aquisicao);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_ANOFABRIC", val.AnoFabric);
            hs.Add("@P_OBSERVACAO", val.Observacao);
            hs.Add("@P_VL_CUSTOHORA", val.Vl_custohora);

            return this.executarProc("IA_FAZ_EQUIPAMENTO", hs);
        }

        public string Excluir(TRegistro_Equipamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EQUIPAMENTO", val.Cd_equipamento);

            return this.executarProc("EXCLUI_FAZ_EQUIPAMENTO", hs);
        }
    }
}

