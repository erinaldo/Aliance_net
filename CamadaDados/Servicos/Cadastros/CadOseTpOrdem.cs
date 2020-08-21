using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_TpOrdem : List<TRegistro_TpOrdem>, IComparer<TRegistro_TpOrdem>
    {
        #region IComparer<TRegistro_TpOrdem> Members
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

        public TList_TpOrdem()
        { }

        public TList_TpOrdem(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpOrdem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpOrdem x, TRegistro_TpOrdem y)
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
    
    public class TRegistro_TpOrdem
    {
        private decimal? tp_ordem;
        public decimal? Tp_ordem
        {
            get { return tp_ordem; }
            set
            {
                tp_ordem = value;
                tp_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_ordemstr;
        public string Tp_ordemstr
        {
            get { return tp_ordemstr; }
            set
            {
                tp_ordemstr = value;
                try
                {
                    tp_ordem = decimal.Parse(value);
                }
                catch
                { tp_ordem = null; }
            }
        }
        public string Ds_tipoordem
        { get; set; }
        private string tp_os;
        public string Tp_os
        {
            get { return tp_os; }
            set
            {
                tp_os = value;
                if (value.Trim().ToUpper().Equals("O"))
                    tipo_os = "OFICINA";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_os = "PRODUÇÃO PROPRIA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_os = "PRESTAÇÃO SERVIÇO";
                else if (value.Trim().ToUpper().Equals("I"))
                    tipo_os = "SERVIÇO INTERNO";
            }
        }
        private string tipo_os;
        public string Tipo_os
        {
            get { return tipo_os; }
            set
            {
                tipo_os = value;
                if (value.Trim().ToUpper().Equals("OFICINA"))
                    tp_os = "O";
                else if (value.Trim().ToUpper().Equals("PRODUÇÃO PROPRIA"))
                    tp_os = "P";
                else if (value.Trim().ToUpper().Equals("PRESTAÇÃO SERVIÇO"))
                    tp_os = "S";
                else if (value.Trim().ToUpper().Equals("SERVIÇO INTERNO"))
                    tp_os = "I"; 
            }
        }
        private string st_exigirconferencia;
        public string St_exigirconferencia
        {
            get { return st_exigirconferencia; }
            set
            {
                st_exigirconferencia = value;
                st_exigirconferenciabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirconferenciabool;
        public bool St_exigirconferenciabool
        {
            get { return st_exigirconferenciabool; }
            set
            {
                st_exigirconferenciabool = value;
                st_exigirconferencia = value ? "S" : "N";
            }
        }
        private string st_infDtAbertura;
        public string St_infDtAbertura
        {
            get { return st_infDtAbertura; }
            set
            {
                st_infDtAbertura = value;
                st_infDtAberturabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_infDtAberturabool;
        public bool St_infDtAberturabool
        {
            get { return st_infDtAberturabool; }
            set
            {
                st_infDtAberturabool = value;
                st_infDtAbertura = value ? "S" : "N";
            }
        }
        private string st_comissaofechamento;
        public string St_comissaofechamento
        {
            get { return st_comissaofechamento; }
            set
            {
                st_comissaofechamento = value;
                st_comissaofechamentobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comissaofechamentobool;
        public bool St_comissaofechamentobool
        {
            get { return st_comissaofechamentobool; }
            set
            {
                st_comissaofechamentobool = value;
                st_comissaofechamento = value ? "S" : "N";
            }
        }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        private string st_procestoque;
        public string St_procestoque
        {
            get { return st_procestoque; }
            set
            {
                st_procestoque = value;
                st_procestoquebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_procestoquebool;
        public bool St_procestoquebool
        {
            get { return st_procestoquebool; }
            set
            {
                st_procestoquebool = value;
                st_procestoque = value ? "S" : "N";
            }
        }
        private string tp_faturamento;
        public string Tp_faturamento
        {
            get { return tp_faturamento; }
            set
            {
                tp_faturamento = value;
                if (value.Trim().ToUpper().Equals("D"))
                    tipo_faturamento = "DUPLICATA";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_faturamento = "PEDIDO";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_faturamento = "PRE VENDA";
            }
        }
        private string tipo_faturamento;
        public string Tipo_faturamento
        {
            get { return tipo_faturamento; }
            set
            {
                tipo_faturamento = value;
                if (value.Trim().ToUpper().Equals("DUPLICATA"))
                    tp_faturamento = "D";
                else if (value.Trim().ToUpper().Equals("PEDIDO"))
                    tp_faturamento = "P";
                else if (value.Trim().ToUpper().Equals("PRE VENDA"))
                    tp_faturamento = "V";
            }
        }

        public TList_EtapaOrdem lEtapa
        { get; set; }

        public TRegistro_TpOrdem()
        {
            this.tp_ordem = null;
            this.tp_ordemstr = string.Empty;
            this.Ds_tipoordem = string.Empty;
            this.st_exigirconferencia = "N";
            this.st_exigirconferenciabool = false;
            this.st_infDtAbertura = "N";
            this.st_infDtAberturabool = false;
            this.st_comissaofechamento = "N";
            this.st_comissaofechamentobool = false;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.st_procestoque = "N";
            this.st_procestoquebool = false;
            this.tp_faturamento = string.Empty;
            this.tipo_faturamento = string.Empty;
            this.lEtapa = new TList_EtapaOrdem();
        }
    }

    public class TCD_TpOrdem : TDataQuery
    {
        public TCD_TpOrdem()
        { }

        public TCD_TpOrdem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.tp_ordem, a.ds_tipoordem, ");
                sql.AppendLine("a.tp_os, a.st_exigirconferencia, a.st_infdtabertura, a.st_comissaofechamento, ");
                sql.AppendLine("b.cd_tabelapreco, c.ds_tabelapreco, a.st_procestoque, a.tp_faturamento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_ose_tpordem a ");
            sql.AppendLine("left outer join tb_ose_paramos b ");
            sql.AppendLine("on a.tp_ordem = b.tp_ordem ");
            sql.AppendLine("left outer join tb_div_tabelapreco c ");
            sql.AppendLine("on b.cd_tabelapreco = c.cd_tabelapreco ");

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

        public TList_TpOrdem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TpOrdem lista = new TList_TpOrdem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TpOrdem reg = new TRegistro_TpOrdem();

                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("tp_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoordem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_tipoordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_os")))
                        reg.Tp_os = reader.GetString(reader.GetOrdinal("tp_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_exigirconferencia")))
                        reg.St_exigirconferencia = reader.GetString(reader.GetOrdinal("st_exigirconferencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_infdtabertura")))
                        reg.St_infDtAbertura = reader.GetString(reader.GetOrdinal("st_infdtabertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_comissaofechamento")))
                        reg.St_comissaofechamento = reader.GetString(reader.GetOrdinal("st_comissaofechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_faturamento")))
                        reg.Tp_faturamento = reader.GetString(reader.GetOrdinal("tp_faturamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_procestoque")))
                        reg.St_procestoque = reader.GetString(reader.GetOrdinal("st_procestoque"));

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

        public string Gravar(TRegistro_TpOrdem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_DS_TIPOORDEM", val.Ds_tipoordem);
            hs.Add("@P_TP_OS", val.Tp_os);
            hs.Add("@P_ST_EXIGIRCONFERENCIA", val.St_exigirconferencia);
            hs.Add("@P_ST_INFDTABERTURA", val.St_infDtAbertura);
            hs.Add("@P_ST_COMISSAOFECHAMENTO", val.St_comissaofechamento);
            hs.Add("@P_TP_FATURAMENTO", val.Tp_faturamento);
            hs.Add("@P_ST_PROCESTOQUE", val.St_procestoque);

            return this.executarProc("IA_OSE_TPORDEM", hs);
        }

        public string Excluir(TRegistro_TpOrdem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);

            return this.executarProc("EXCLUI_OSE_TPORDEM", hs);
        }
    }
}
