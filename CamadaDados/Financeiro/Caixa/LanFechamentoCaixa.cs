using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Caixa
{
    public class TList_LanFechamentoCaixa : List<TRegistro_LanFechamentoCaixa>
    { }

    
    public class TRegistro_LanFechamentoCaixa
    {
        
        public decimal? Id_fechamento
        { get; set; }
        private DateTime? dt_fechamento;
        
        public DateTime? Dt_fechamento
        {
            get { return dt_fechamento; }
            set 
            { 
                dt_fechamento = value;
                dt_fechamentostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_fechamentostring;
        public string Dt_fechamentostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_fechamentostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_fechamentostring = value;
                try
                {
                    dt_fechamento = Convert.ToDateTime(value);
                }
                catch
                { dt_fechamento = null; }
            }
        }
        private DateTime? dt_ultimofechamento;
        
        public DateTime? Dt_ultimofechamento
        {
            get { return dt_ultimofechamento; }
            set 
            { 
                dt_ultimofechamento = value;
                dt_ultimofechamentostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_ultimofechamentostring;
        public string Dt_ultimofechamentostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_ultimofechamentostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_ultimofechamentostring = value;
                try
                {
                    dt_ultimofechamento = Convert.ToDateTime(value);
                }
                catch
                { dt_ultimofechamento = null; }
            }
        }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }
        
        public decimal Vl_anterior
        { get; set; }
        
        public decimal Vl_atual
        { get; set; }
        
        public decimal Vl_ch_emit_compensar
        { get; set; }
        
        public decimal Vl_ch_rec_compensar
        { get; set; }
        
        public decimal Vl_saldofuturo
        { get; set; }

        public TRegistro_LanFechamentoCaixa()
        {
            this.Id_fechamento = null;
            this.dt_fechamento = null;
            this.dt_fechamentostring = string.Empty;
            this.dt_ultimofechamento = null;
            this.dt_ultimofechamentostring = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.Vl_anterior = decimal.Zero;
            this.Vl_atual = decimal.Zero;
            this.Vl_ch_emit_compensar = decimal.Zero;
            this.Vl_ch_rec_compensar = decimal.Zero;
            this.Vl_saldofuturo = decimal.Zero;
        }
    }

    public class TCD_LanFechamentoCaixa : TDataQuery
    {
        public TCD_LanFechamentoCaixa()
        { }

        public TCD_LanFechamentoCaixa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" select " + strTop + " b.id_fechamento, ");
                sql.AppendLine("b.DT_Fechamento, b.cd_contager, a.ds_contager, b.vl_atual, ");
                sql.AppendLine("b.vl_anterior, b.vl_ch_emit_compensar, b.vl_ch_rec_compensar, ");
                sql.AppendLine("c.cd_moeda, c.ds_moeda_singular, c.sigla, b.vl_saldofuturo ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_fin_contager a ");
            sql.AppendLine("inner join tb_fin_fechamento_caixa b ");
            sql.AppendLine("on a.cd_contager = b.cd_contager");
            sql.AppendLine("inner join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moeda = c.cd_moeda ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
               sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        public TList_LanFechamentoCaixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_LanFechamentoCaixa lista = new TList_LanFechamentoCaixa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_LanFechamentoCaixa reg = new TRegistro_LanFechamentoCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Fechamento"))))
                        reg.Id_fechamento = reader.GetDecimal(reader.GetOrdinal("ID_Fechamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Fechamento"))))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Contager"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Contager"))))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Anterior")))
                        reg.Vl_anterior = reader.GetDecimal(reader.GetOrdinal("Vl_Anterior"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Atual")))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("Vl_Atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ch_emit_compensar")))
                        reg.Vl_ch_emit_compensar = reader.GetDecimal(reader.GetOrdinal("Vl_ch_emit_compensar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ch_rec_compensar")))
                        reg.Vl_ch_rec_compensar = reader.GetDecimal(reader.GetOrdinal("vl_ch_rec_compensar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SaldoFuturo")))
                        reg.Vl_saldofuturo = reader.GetDecimal(reader.GetOrdinal("Vl_SaldoFuturo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));

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

        public string GravarFechamentoCaixa(TRegistro_LanFechamentoCaixa val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_FECHAMENTO", val.Id_fechamento);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_VL_ANTERIOR", val.Vl_anterior);
            hs.Add("@P_VL_ATUAL", val.Vl_atual);
            hs.Add("@P_VL_CH_EMIT_COMPENSAR", val.Vl_ch_emit_compensar);
            hs.Add("@P_VL_CH_REC_COMPENSAR", val.Vl_ch_rec_compensar);
            hs.Add("@P_VL_SALDOFUTURO", val.Vl_saldofuturo);

            return this.executarProc("IA_FIN_FECHAMENTO_CAIXA", hs);
        }

        public string DeletarFechamentoCaixa(TRegistro_LanFechamentoCaixa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_FECHAMENTO", val.Id_fechamento);

            return this.executarProc("EXCLUI_FIN_FECHAMENTO_CAIXA", hs);
        }
    }
}
