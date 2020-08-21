using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{
    public class TList_CadCFOP : List<TRegistro_CadCFOP>, IComparer<TRegistro_CadCFOP>
    {
        #region IComparer<TRegistro_CadCFOP> Members
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

        public TList_CadCFOP()
        { }

        public TList_CadCFOP(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCFOP value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCFOP x, TRegistro_CadCFOP y)
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

    public class TRegistro_CadCFOP
    {
        public string CD_CFOP { get; set; }
        public string DS_CFOP { get; set; }
        public string DS_APLICACAO { get; set; }
        private string st_bonificacao;
        public string St_bonificacao
        {
            get { return st_bonificacao; }
            set
            {
                st_bonificacao = value;
                st_bonificacaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_bonificacaobool;
        public bool St_bonificacaobool
        {
            get { return st_bonificacaobool; }
            set
            {
                st_bonificacaobool = value;
                st_bonificacao = value ? "S" : "N";
            }
        }
        private string st_usoconsumo;
        public string St_usoconsumo
        {
            get { return st_usoconsumo; }
            set
            {
                st_usoconsumo = value;
                st_usoconsumobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_usoconsumobool;
        public bool St_usoconsumobool
        {
            get { return st_usoconsumobool; }
            set
            {
                st_usoconsumobool = value;
                st_usoconsumo = value ? "S" : "N";
            }
        }
        private string st_devolucao;
        public string St_devolucao
        {
            get { return st_devolucao; }
            set
            {
                st_devolucao = value;
                st_devolucaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_devolucaobool;
        public bool St_devolucaobool
        {
            get { return st_devolucaobool; }
            set
            {
                st_devolucaobool = value;
                st_devolucao = value ? "S" : "N";
            }
        }
        private string st_remessa;
        public string St_remessa
        {
            get { return st_remessa; }
            set
            {
                st_remessa = value;
                st_remessabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_remessabool;
        public bool St_remessabool
        {
            get { return st_remessabool; }
            set
            {
                st_remessabool = value;
                st_remessa = value ? "S" : "N";
            }
        }
        private string st_retorno;
        public string St_retorno
        {
            get { return st_retorno; }
            set
            {
                st_retorno = value;
                st_retornobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_retornobool;
        public bool St_retornobool
        {
            get { return st_retornobool; }
            set
            {
                st_retornobool = value;
                st_retorno = value ? "S" : "N";
            }
        }
        private string st_combustivel;
        public string St_combustivel
        {
            get { return st_combustivel; }
            set
            {
                st_combustivel = value;
                st_combustivelbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_combustivelbool;
        public bool St_combustivelbool
        {
            get { return st_combustivelbool; }
            set
            {
                st_combustivelbool = value;
                st_combustivel = value ? "S" : "N";
            }
        }
        
        public TRegistro_CadCFOP()
        {
            this.CD_CFOP = string.Empty;
            this.DS_CFOP = string.Empty;
            this.DS_APLICACAO = string.Empty;
            this.st_bonificacao = "N";
            this.st_bonificacaobool = false;
            this.st_usoconsumo = "N";
            this.st_usoconsumobool = false;
            this.st_devolucao = "N";
            this.st_devolucaobool = false;
            this.st_retorno = "N";
            this.st_retornobool = false;
            this.st_remessa = "N";
            this.st_remessabool = false;
            this.st_combustivel = "N";
            this.st_combustivelbool = false;
        }        
    }
    
    public class TCD_CadCFOP : TDataQuery
    {
        public TCD_CadCFOP()
        { }

        public TCD_CadCFOP(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_CFOP, a.DS_CFOP, a.DS_APLICACAO, a.ST_Combustivel, ");
                sql.AppendLine("a.ST_BONIFICACAO, a.ST_UsoConsumo, a.ST_Devolucao, a.ST_Remessa, a.ST_Retorno ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_CFOP A ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
        
        public TList_CadCFOP Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCFOP lista = new TList_CadCFOP();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCFOP reg = new TRegistro_CadCFOP();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.CD_CFOP = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.DS_CFOP = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_APLICACAO")))
                        reg.DS_APLICACAO = reader.GetString(reader.GetOrdinal("DS_APLICACAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_BONIFICACAO")))
                        reg.St_bonificacao = reader.GetString(reader.GetOrdinal("ST_BONIFICACAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_usoconsumo")))
                        reg.St_usoconsumo = reader.GetString(reader.GetOrdinal("st_usoconsumo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Devolucao")))
                        reg.St_devolucao = reader.GetString(reader.GetOrdinal("ST_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Remessa")))
                        reg.St_remessa = reader.GetString(reader.GetOrdinal("ST_Remessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Retorno")))
                        reg.St_retorno = reader.GetString(reader.GetOrdinal("ST_Retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Combustivel")))
                        reg.St_combustivel = reader.GetString(reader.GetOrdinal("ST_Combustivel"));

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
        
        public string Gravar(TRegistro_CadCFOP val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_CFOP", val.CD_CFOP);
            hs.Add("@P_DS_CFOP", val.DS_CFOP);
            hs.Add("@P_DS_APLICACAO", val.DS_APLICACAO);
            hs.Add("@P_ST_BONIFICACAO", val.St_bonificacao);
            hs.Add("@P_ST_USOCONSUMO", val.St_usoconsumo);
            hs.Add("@P_ST_DEVOLUCAO", val.St_devolucao);
            hs.Add("@P_ST_REMESSA", val.St_remessa);
            hs.Add("@P_ST_RETORNO", val.St_retorno);
            hs.Add("@P_ST_COMBUSTIVEL", val.St_combustivel);

            return executarProc("IA_FIS_CFOP", hs);
        }
        
        public string Excluir(TRegistro_CadCFOP val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CFOP", val.CD_CFOP);

            return executarProc("EXCLUI_FIS_CFOP", hs);
        }
    }
}
