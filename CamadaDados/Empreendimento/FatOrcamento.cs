using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Empreendimento
{

    public class TRegistro_FatOrcamento
    {
        public decimal valor_notafiscal { get; set; } = decimal.Zero;
        public string Cd_empresa
        { get; set; }
        public decimal id_despesa { get; set; }
        public decimal id_execucao { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        public decimal vl_totalnota { get; set; } = decimal.Zero;


        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }
        public decimal nr_lancto
        { get; set; }
        public string nr_lanctostr { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal vl_executado
        { get; set; }
        public decimal vl_total_servico_nota
        { get; set; }
        public string Cd_municipioexec { get; set; } = string.Empty;
        public Financeiro.Duplicata.TRegistro_LanDuplicata rDuplicata { get; set; } = new Financeiro.Duplicata.TRegistro_LanDuplicata();
        public Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItens { get; set; } = new Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();

        public TRegistro_FatOrcamento()
        {
            id_orcamentostr = string.Empty;
            nr_versaostr = string.Empty;
            nr_lancto = decimal.Zero;
            nr_lanctostr = string.Empty;
            Nr_notafiscal = null;
            vl_totalnota = decimal.Zero;
            dt_emissao = new DateTime();
            vl_total_servico_nota = decimal.Zero;
            vl_executado = decimal.Zero;
            valor_notafiscal = decimal.Zero;
            rDuplicata = new Financeiro.Duplicata.TRegistro_LanDuplicata();
            lItens = new Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
        }
    }

    public class TList_FatOrcamento : List<TRegistro_FatOrcamento>, IComparer<TRegistro_FatOrcamento>
    {
        #region IComparer<TRegistro_FatOrcamento> Members
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

        public TList_FatOrcamento()
        { }

        public TList_FatOrcamento(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FatOrcamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FatOrcamento x, TRegistro_FatOrcamento y)
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

    public class TCD_FatOrcamento : TDataQuery
    {
        public TCD_FatOrcamento() { }

        public TCD_FatOrcamento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " b.dt_emissao, b.vl_totalnota , a.cd_empresa, a.id_orcamento, a.nr_versao, a.nr_lanctofiscal, b.Nr_notafiscal,a.vl_executado ,b.Vl_totalservicos");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_FatOrcamento a");
            sql.AppendLine(" inner join vTB_FAT_NotaFiscal b on a.Nr_LanctoFiscal = b.Nr_LanctoFiscal");


            string cond = " and ";
            sql.AppendLine("where b.st_registro <> 'C' ");
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_FatOrcamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FatOrcamento lista = new TList_FatOrcamento();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FatOrcamento reg = new TRegistro_FatOrcamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("Nr_Versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_totalnota")))
                        reg.vl_totalnota = reader.GetDecimal(reader.GetOrdinal("vl_totalnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_executado")))
                        reg.vl_executado = reader.GetDecimal(reader.GetOrdinal("vl_executado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalservicos")))
                        reg.vl_total_servico_nota = reader.GetDecimal(reader.GetOrdinal("Vl_totalservicos"));
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

        public string Gravar(TRegistro_FatOrcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_NR_LANCTOFISCAL", val.nr_lanctostr); 
            hs.Add("@P_VL_EXECUTADO", val.vl_executado); 

            return this.executarProc("IA_EMP_FATORCAMENTO", hs);
        }

        public string Excluir(TRegistro_FatOrcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_NR_LANCTOFISCAL", val.nr_lanctostr);

            return this.executarProc("EXCLUI_EMP_FATORCAMENTO", hs);
        }
    }
}
