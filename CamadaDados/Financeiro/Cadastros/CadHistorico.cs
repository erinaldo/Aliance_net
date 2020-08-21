using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Utils;
using System.Data;


namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadHistorico : List<TRegistro_CadHistorico>, IComparer<TRegistro_CadHistorico>
    {
        #region IComparer<TRegistro_CadHistorico> Members
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

        public TList_CadHistorico()
        { }

        public TList_CadHistorico(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadHistorico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadHistorico x, TRegistro_CadHistorico y)
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

    public class TRegistro_CadHistorico
    {
        public string Cd_historico { get; set; }
        private string tp_mov;
        public string Tp_mov 
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_movimento = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBER";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_mov = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_mov = "R";
            }
        }
        public string Ds_historico { get; set; }
        public string CD_Historico_Quitacao { get; set; }
        public string DS_Historico_Quitacao { get; set; }
        public string Cd_grupoCF
        { get; set; }
        public string Ds_grupoCF
        { get; set; }
        private string st_transferencia;
        public string St_transferencia
        {
            get { return st_transferencia; }
            set
            {
                st_transferencia = value;
                st_transferenciabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_transferenciabool;
        public bool St_transferenciabool
        { 
            get { return st_transferenciabool; }
            set
            {
                st_transferenciabool = value;
                st_transferencia = value ? "S" : "N";
            }
        }
        public string Ds_aplicacao
        { get; set; }
        public string St_registro
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadHistorico()
        {
            Cd_historico = string.Empty;
            Tp_mov = string.Empty;
            tipo_movimento = string.Empty;
            Ds_historico = string.Empty;
            CD_Historico_Quitacao = string.Empty;
            DS_Historico_Quitacao = string.Empty;
            Cd_grupoCF = string.Empty;
            Ds_grupoCF = string.Empty;
            Ds_aplicacao = string.Empty;
            St_registro = "A";
            st_transferencia = "N";
            st_transferenciabool = false;
            St_processar = false;
        }
    }

    public class TCD_CadHistorico : TDataQuery
    {
        public TCD_CadHistorico()
        { }

        public TCD_CadHistorico(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {

                sql.AppendLine("select " + strTop + " a.cd_historico, a.Tp_Mov, ");
                sql.AppendLine("a.ds_historico, a.cd_Historico_Quitacao, ");
                sql.AppendLine("e.DS_Historico as DS_Historico_Quitacao, ");
                sql.AppendLine("a.DS_Aplicacao, a.ST_Registro, ");
                sql.AppendLine("a.cd_grupoCF, f.ds_grupoCF, a.ST_Transferencia ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_historico a ");
            sql.AppendLine("left outer join tb_fin_historico e ");
            sql.AppendLine("on e.cd_historico = a.cd_historico_quitacao ");
            sql.AppendLine("left outer join tb_fin_grupoCF f ");
            sql.AppendLine("on a.cd_grupocf = f.cd_grupocf ");

            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            sql.AppendLine("order by a.cd_historico ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo),null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadHistorico Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadHistorico lista = new TList_CadHistorico();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadHistorico reg = new TRegistro_CadHistorico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Quitacao"))))
                        reg.CD_Historico_Quitacao = reader.GetString(reader.GetOrdinal("CD_Historico_Quitacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_MOV"))))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_MOV"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico"))))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_Quitacao"))))
                        reg.DS_Historico_Quitacao = reader.GetString(reader.GetOrdinal("DS_Historico_Quitacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Transferencia"))))
                        reg.St_transferencia = reader.GetString(reader.GetOrdinal("ST_Transferencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Aplicacao"))))
                        reg.Ds_aplicacao = reader.GetString(reader.GetOrdinal("DS_Aplicacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupocf")))
                        reg.Cd_grupoCF = reader.GetString(reader.GetOrdinal("cd_grupocf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupocf")))
                        reg.Ds_grupoCF = reader.GetString(reader.GetOrdinal("ds_grupocf"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadHistorico val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_HISTORICO_QUITACAO", val.CD_Historico_Quitacao);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_DS_HISTORICO", val.Ds_historico);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_GRUPOCF", val.Cd_grupoCF);
            hs.Add("@P_DS_APLICACAO", val.Ds_aplicacao);
            hs.Add("@P_ST_TRANSFERENCIA", val.St_transferencia);

            return executarProc("IA_FIN_HISTORICO", hs);
        }

        public string Excluir(TRegistro_CadHistorico val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);

            return executarProc("EXCLUI_FIN_HISTORICO", hs);
        }
    }
}
