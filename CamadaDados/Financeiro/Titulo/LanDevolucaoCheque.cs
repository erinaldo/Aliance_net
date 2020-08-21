using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Titulo
{
    public class TList_DevolucaoCheque : List<TRegistro_DevolucaoCheque>, IComparer<TRegistro_DevolucaoCheque>
    {
        #region IComparer<TRegistro_DevolucaoCheque> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_DevolucaoCheque()
        { }

        public TList_DevolucaoCheque(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DevolucaoCheque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DevolucaoCheque x, TRegistro_DevolucaoCheque y)
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
    
    public class TRegistro_DevolucaoCheque
    {
        
        public decimal Id_devolucao
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Nr_lanctocheque
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public string Ds_banco
        { get; set; }
        private DateTime? dt_devolucao;
        
        public DateTime? Dt_devolucao
        {
            get { return dt_devolucao; }
            set
            {
                dt_devolucao = value;
                dt_devolucaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_devolucaostr;
        public string Dt_devolucaostr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_devolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_devolucaostr = value;
                try
                {
                    dt_devolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_devolucao = null; }
            }
        }
        private DateTime? dt_reapresentacao;
        
        public DateTime? Dt_reapresentacao
        {
            get { return dt_reapresentacao; }
            set
            {
                dt_reapresentacao = value;
                dt_reapresentacaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_reapresentacaostr;
        public string Dt_reapresentacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_reapresentacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_reapresentacaostr = value;
                try
                {
                    dt_reapresentacao = Convert.ToDateTime(value);
                }
                catch
                { dt_reapresentacao = null; }
            }
        }
        
        public string Ds_motivo
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public TList_RegLanTitulo lCheques
        { get; set; }

        public TRegistro_DevolucaoCheque()
        {
            this.Id_devolucao = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_lanctocheque = null;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.dt_devolucao = null;
            this.dt_devolucaostr = string.Empty;
            this.dt_reapresentacao = null;
            this.dt_reapresentacaostr = string.Empty;
            this.Ds_motivo = string.Empty;
            this.Ds_observacao = string.Empty;
            this.lCheques = new TList_RegLanTitulo();
        }
    }

    public class TCD_DevolucaoCheque : TDataQuery
    {
        public TCD_DevolucaoCheque()
        { }

        public TCD_DevolucaoCheque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_devolucao, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.nr_lanctocheque, a.cd_banco, c.ds_banco, a.dt_devolucao, ");
                sql.AppendLine("a.dt_reapresentacao, a.ds_motivo, a.ds_observacao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_devolucaocheque a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fin_banco c ");
            sql.AppendLine("on a.cd_banco = c.cd_banco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_DevolucaoCheque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_DevolucaoCheque lista = new TList_DevolucaoCheque();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DevolucaoCheque reg = new TRegistro_DevolucaoCheque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Devolucao"))))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("ID_Devolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Banco"))))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("DT_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Reapresentacao")))
                        reg.Dt_reapresentacao = reader.GetDateTime(reader.GetOrdinal("DT_Reapresentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("DS_Motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));

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

        public string GravarDevolucaoCheque(TRegistro_DevolucaoCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_DT_DEVOLUCAO", val.Dt_devolucao);
            hs.Add("@P_DT_REAPRESENTACAO", val.Dt_reapresentacao);
            hs.Add("@P_DS_MOTIVO", val.Ds_motivo);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FIN_DEVOLUCAOCHEQUE", hs);
        }

        public string DeletarDevolucaoCheque(TRegistro_DevolucaoCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);

            return this.executarProc("EXCLUI_FIN_DEVOLUCAOCHEQUE", hs);
        }
    }
}
