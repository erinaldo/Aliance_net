using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CotacaoMoeda : List<TRegistro_CotacaoMoeda>
    { }

    
    public class TRegistro_CotacaoMoeda
    {
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }
        
        public string Cd_moedaresult
        { get; set; }
        
        public string Ds_moedaresult
        { get; set; }
        
        public string Sg_moedaresult
        { get; set; }
        private DateTime? data;
        
        public DateTime? Data
        {
            get { return data; }
            set
            {
                data = value;
                datastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string datastr;
        public string Datastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(datastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                datastr = value;
                try
                {
                    data = DateTime.Parse(value);
                }
                catch
                { data = null; }
            }
        }
        
        public decimal Valor
        { get; set; }
        
        public string Op
        { get; set; }

        public TRegistro_CotacaoMoeda()
        {
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.Cd_moedaresult = string.Empty;
            this.Ds_moedaresult = string.Empty;
            this.Sg_moedaresult = string.Empty;
            this.data = null;
            this.datastr = string.Empty;
            this.Valor = decimal.Zero;
            this.Op = string.Empty;
        }
    }

    public class TCD_CotacaoMoeda : TDataQuery
    {
        public TCD_CotacaoMoeda()
        { }

        public TCD_CotacaoMoeda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_moeda, b.ds_moeda_singular as ds_moeda, b.sigla, ");
                sql.AppendLine("a.cd_moedaresult, c.ds_moeda_singular as ds_moedaresult, c.sigla as sg_moedaresult, ");
                sql.AppendLine("a.data, a.valor, a.op, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cotacaomoeda a ");
            sql.AppendLine("inner join tb_fin_moeda b ");
            sql.AppendLine("on a.cd_moeda = b.cd_moeda ");
            sql.AppendLine("inner join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moedaresult = c.cd_moeda ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine("group by " + vGroup.Trim());
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public TList_CotacaoMoeda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CotacaoMoeda lista = new TList_CotacaoMoeda();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CotacaoMoeda reg = new TRegistro_CotacaoMoeda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda"))))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_MoedaResult"))))
                        reg.Cd_moedaresult = reader.GetString(reader.GetOrdinal("Cd_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MoedaResult"))))
                        reg.Ds_moedaresult = reader.GetString(reader.GetOrdinal("DS_MoedaResult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_moedaresult")))
                        reg.Sg_moedaresult = reader.GetString(reader.GetOrdinal("sg_moedaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Data")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("OP")))
                        reg.Op = reader.GetString(reader.GetOrdinal("OP"));

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

        public string GravarCotacao(TRegistro_CotacaoMoeda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_DATA", val.Data);
            hs.Add("@P_CD_MOEDARESULT", val.Cd_moedaresult);
            hs.Add("@P_VALOR", val.Valor);
            hs.Add("@P_OP", val.Op);

            return this.executarProc("IA_FIN_COTACAOMOEDA", hs);
        }

        public string ExcluirCotacao(TRegistro_CotacaoMoeda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_DATA", val.Data);
            hs.Add("@P_CD_MOEDARESULT", val.Cd_moedaresult);

            return this.executarProc("EXCLUI_FIN_COTACAOMOEDA", hs);
        }
    }
}
