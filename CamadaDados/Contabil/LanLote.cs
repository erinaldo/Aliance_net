using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Contabil
{
    public class TList_LoteCTB : List<TRegistro_LoteCTB>, IComparer<TRegistro_LoteCTB>
    {
        #region IComparer<TRegistro_LoteCTB> Members
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

        public TList_LoteCTB()
        { }

        public TList_LoteCTB(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteCTB value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteCTB x, TRegistro_LoteCTB y)
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

    public class TRegistro_LoteCTB
    {
        private decimal? id_loteCTB;
        public decimal? Id_loteCTB
        {
            get { return id_loteCTB; }
            set
            {
                id_loteCTB = value;
                id_loteCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTBstr;
        public string Id_loteCTBstr
        {
            get { return id_loteCTBstr; }
            set
            {
                id_loteCTBstr = value;
                try
                {
                    id_loteCTB = decimal.Parse(value);
                }
                catch { id_loteCTB = null; }
            }
        }
        public string Ds_lote
        { get; set; }
        private string tp_integracao;
        public string Tp_integracao
        {
            get { return tp_integracao; }
            set
            {
                tp_integracao = value;
                if (value.Trim().ToUpper().Equals("FA"))
                    tipo_integracao = "FATURAMENTO";
                else if (value.Trim().ToUpper().Equals("IF"))
                    tipo_integracao = "IMPOSTO FATURAMENTO";
                else if (value.Trim().ToUpper().Equals("FI"))
                    tipo_integracao = "FINANCEIRO";
                else if (value.Trim().ToUpper().Equals("CC"))
                    tipo_integracao = "CHEQUE COMPENSADO";
                else if (value.Trim().ToUpper().Equals("CX"))
                    tipo_integracao = "CAIXA";
                else if (value.Trim().ToUpper().Equals("PE"))
                    tipo_integracao = "PROVISÃO ESTOQUE";
                else if (value.Trim().ToUpper().Equals("PA"))
                    tipo_integracao = "PATRIMONIO";
                else if (value.Trim().ToUpper().Equals("AV"))
                    tipo_integracao = "AVULSO";
                else if (value.Trim().ToUpper().Equals("FE"))
                    tipo_integracao = "FECHAMENTO CONTABIL";
                else if (value.Trim().ToUpper().Equals("IS"))
                    tipo_integracao = "IMPLANTAÇÃO SALDO";
                else if (value.Trim().ToUpper().Equals("CF"))
                    tipo_integracao = "COMPLEMENTO FIXAR";
                else if (value.Trim().ToUpper().Equals("ZR"))
                    tipo_integracao = "ZERAMENTO";
                else if (value.Trim().ToUpper().Equals("FC"))
                    tipo_integracao = "FATURA CARTÃO";
            }
        }
        private string tipo_integracao;
        public string Tipo_integracao
        {
            get { return tipo_integracao; }
            set
            {
                tipo_integracao = value;
                if (value.Trim().ToUpper().Equals("FATURAMENTO"))
                    tp_integracao = "FA";
                else if (value.Trim().ToUpper().Equals("IMPOSTO FATURAMENTO"))
                    tp_integracao = "IF";
                else if (value.Trim().ToUpper().Equals("FINANCEIRO"))
                    tp_integracao = "FI";
                else if (value.Trim().ToUpper().Equals("CHEQUE COMPENSADO"))
                    tp_integracao = "CC";
                else if (value.Trim().ToUpper().Equals("CAIXA"))
                    tp_integracao = "CX";
                else if (value.Trim().ToUpper().Equals("PROVISÃO ESTOQUE"))
                    tp_integracao = "PE";
                else if (value.Trim().ToUpper().Equals("PATRIMONIO"))
                    tp_integracao = "PA";
                else if (value.Trim().ToUpper().Equals("AVULSO"))
                    tp_integracao = "AV";
                else if (value.Trim().ToUpper().Equals("FECHAMENTO CONTABIL"))
                    tp_integracao = "FE";
                else if (value.Trim().ToUpper().Equals("IMPLANTAÇÃO SALDO"))
                    tp_integracao = "IS";
                else if (value.Trim().ToUpper().Equals("COMPLEMENTO FIXAR"))
                    tp_integracao = "CF";
                else if (value.Trim().ToUpper().Equals("ZERAMENTO"))
                    tp_integracao = "ZR";
                else if (value.Trim().ToUpper().Equals("FATURA CARTÃO"))
                    tp_integracao = "FC";
            }
        }

        public TRegistro_LoteCTB()
        {
            id_loteCTB = null;
            id_loteCTBstr = string.Empty;
            Ds_lote = string.Empty;
            tp_integracao = string.Empty;
            tipo_integracao = string.Empty;
        }
    }

    public class TCD_LoteCTB : TDataQuery
    {
        public TCD_LoteCTB() { }

        public TCD_LoteCTB(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_loteCTB, a.DS_Lote, a.TP_Integracao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_LoteLan a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LoteCTB Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_LoteCTB lista = new TList_LoteCTB();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteCTB reg = new TRegistro_LoteCTB();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB"))))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_lote"))))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Integracao")))
                        reg.Tp_integracao = reader.GetString(reader.GetOrdinal("TP_Integracao"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_LoteCTB val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);
            hs.Add("@P_DS_LOTE", val.Ds_lote);
            hs.Add("@P_TP_INTEGRACAO", val.Tp_integracao);

            return executarProc("IA_CTB_LOTECTB", hs);
        }

        public string Excluir(TRegistro_LoteCTB val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);

            return executarProc("EXCLUI_CTB_LOTELAN", hs);
        }
    }
}
