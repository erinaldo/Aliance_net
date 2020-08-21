using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_Mov_X_CFOP : List<TRegistro_Mov_X_CFOP>, IComparer<TRegistro_Mov_X_CFOP>
    {
        #region IComparer<TRegistro_Mov_X_CFOP> Members
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

        public TList_Mov_X_CFOP()
        { }

        public TList_Mov_X_CFOP(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Mov_X_CFOP value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Mov_X_CFOP x, TRegistro_Mov_X_CFOP y)
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
    
    public class TRegistro_Mov_X_CFOP
    {
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movimentacaostr;
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = decimal.Parse(value);
                }
                catch
                { cd_movimentacao = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ds_condfiscal_produto
        { get; set; }
        public string Cd_cfop_dentroestado
        { get; set; }
        public string Ds_cfop_dentroestado
        { get; set; }
        public string Cd_cfop_foraestado
        { get; set; }
        public string Ds_cfop_foraestado
        { get; set; }
        public string Cd_cfop_internacional
        { get; set; }
        public string Ds_cfop_internacional
        { get; set; }

        public TRegistro_Mov_X_CFOP()
        {
            this.cd_movimentacao = null;
            this.cd_movimentacaostr = string.Empty;
            this.Ds_movimentacao = string.Empty;
            this.Tp_movimento = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Ds_condfiscal_produto = string.Empty;
            this.Cd_cfop_dentroestado = string.Empty;
            this.Ds_cfop_dentroestado = string.Empty;
            this.Cd_cfop_foraestado = string.Empty;
            this.Ds_cfop_foraestado = string.Empty;
            this.Cd_cfop_internacional = string.Empty;
            this.Ds_cfop_internacional = string.Empty;
        }
    }

    public class TCD_Mov_X_CFOP : TDataQuery
    {
        public TCD_Mov_X_CFOP()
        { }

        public TCD_Mov_X_CFOP(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Movimentacao, b.DS_Movimentacao, ");
                sql.AppendLine("b.tp_movimento, a.CD_CondFiscal_Produto, c.DS_CondFiscal_Produto, ");
                sql.AppendLine("a.CD_CFOP_DentroEstado, d.DS_CFOP as DS_CFOP_DentroEstado, ");
                sql.AppendLine("a.CD_CFOP_ForaEstado, e.DS_CFOP as DS_CFOP_ForaEstado, ");
                sql.AppendLine("a.CD_CFOP_Internacional, f.DS_CFOP as DS_CFOP_Internacional ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FIS_Mov_X_CFOP a ");
            sql.AppendLine("inner join TB_FIS_Movimentacao b ");
            sql.AppendLine("on a.CD_Movimentacao = b.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CondFiscal_Produto c ");
            sql.AppendLine("on a.CD_CondFiscal_Produto = c.CD_CondFiscal_Produto ");
            sql.AppendLine("inner join TB_FIS_CFOP d ");
            sql.AppendLine("on a.CD_CFOP_DentroEstado = d.CD_CFOP ");
            sql.AppendLine("inner join TB_FIS_CFOP e ");
            sql.AppendLine("on a.CD_CFOP_ForaEstado = e.CD_CFOP ");
            sql.AppendLine("left outer join TB_FIS_CFOP f ");
            sql.AppendLine("on a.CD_CFOP_Internacional = f.CD_CFOP ");

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

        public TList_Mov_X_CFOP Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Mov_X_CFOP lista = new TList_Mov_X_CFOP();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Mov_X_CFOP reg = new TRegistro_Mov_X_CFOP();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal_Produto")))
                        reg.Ds_condfiscal_produto = reader.GetString(reader.GetOrdinal("DS_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP_DentroEstado")))
                        reg.Cd_cfop_dentroestado = reader.GetString(reader.GetOrdinal("CD_CFOP_DentroEstado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP_DentroEstado")))
                        reg.Ds_cfop_dentroestado = reader.GetString(reader.GetOrdinal("DS_CFOP_DentroEstado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP_ForaEstado")))
                        reg.Cd_cfop_foraestado = reader.GetString(reader.GetOrdinal("CD_CFOP_ForaEstado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP_ForaEstado")))
                        reg.Ds_cfop_foraestado = reader.GetString(reader.GetOrdinal("DS_CFOP_ForaEstado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP_Internacional")))
                        reg.Cd_cfop_internacional = reader.GetString(reader.GetOrdinal("CD_CFOP_Internacional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP_Internacional")))
                        reg.Ds_cfop_internacional = reader.GetString(reader.GetOrdinal("DS_CFOP_Internacional"));

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

        public string Gravar(TRegistro_Mov_X_CFOP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.Cd_condfiscal_produto);
            hs.Add("@P_CD_CFOP_DENTROESTADO", val.Cd_cfop_dentroestado);
            hs.Add("@P_CD_CFOP_FORAESTADO", val.Cd_cfop_foraestado);
            hs.Add("@P_CD_CFOP_INTERNACIONAL", val.Cd_cfop_internacional);

            return this.executarProc("IA_FIS_MOV_X_CFOP", hs);
        }

        public string Excluir(TRegistro_Mov_X_CFOP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.Cd_condfiscal_produto);

            return this.executarProc("EXCLUI_FIS_MOV_X_CFOP", hs);
        }
    }
}
