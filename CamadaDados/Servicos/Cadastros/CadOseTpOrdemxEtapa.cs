using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_TpOrdem_X_Etapa:List<TRegistro_TpOrdem_X_Etapa>, IComparer<TRegistro_TpOrdem_X_Etapa>
    {
        #region IComparer<TRegistro_TpOrdem_X_Etapa> Members
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

        public TList_TpOrdem_X_Etapa()
        { }

        public TList_TpOrdem_X_Etapa(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpOrdem_X_Etapa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpOrdem_X_Etapa x, TRegistro_TpOrdem_X_Etapa y)
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

    
    public class TRegistro_TpOrdem_X_Etapa
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
        private decimal? id_etapa;
        
        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;
        
        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        
        public string Ds_etapa
        { get; set; }
        public decimal Ordem
        { get; set; }
        private string st_iniciarOS;

        public string St_iniciarOS
        {
            get { return st_iniciarOS; }
            set
            {
                st_iniciarOS = value;
                st_iniciarOSbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_iniciarOSbool;

        public bool St_iniciarOSbool
        {
            get { return st_iniciarOSbool; }
            set
            {
                st_iniciarOSbool = value;
                st_iniciarOS = value ? "S" : "N";
            }
        }
        private string st_finalizarOS;

        public string St_finalizarOS
        {
            get { return st_finalizarOS; }
            set
            {
                st_finalizarOS = value;
                st_finalizarOSbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_finalizarOSbool;

        public bool St_finalizarOSbool
        {
            get { return st_finalizarOSbool; }
            set
            {
                st_finalizarOSbool = value;
                st_finalizarOS = value ? "S" : "N";
            }
        }
        private string st_etapaorcamento;

        public string St_etapaorcamento
        {
            get { return st_etapaorcamento; }
            set
            {
                st_etapaorcamento = value;
                st_etapaorcamentobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_etapaorcamentobool;

        public bool St_etapaorcamentobool
        {
            get { return st_etapaorcamentobool; }
            set
            {
                st_etapaorcamentobool = value;
                st_etapaorcamento = value ? "S" : "N";
            }
        }
        private string st_envterceiro;

        public string St_envterceiro
        {
            get { return st_envterceiro; }
            set
            {
                st_envterceiro = value;
                st_envterceirobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_envterceirobool;

        public bool St_envterceirobool
        {
            get { return st_envterceirobool; }
            set
            {
                st_envterceirobool = value;
                st_envterceiro = value ? "S" : "N";
            }
        }

        public TRegistro_TpOrdem_X_Etapa()
        {
            this.tp_ordem = null;
            this.tp_ordemstr = string.Empty;
            this.Ds_tipoordem = string.Empty;
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.Ds_etapa = string.Empty;
            this.Ordem = decimal.Zero;
            this.st_iniciarOS = string.Empty;
            this.st_iniciarOSbool = false;
            this.st_finalizarOS = string.Empty;
            this.st_finalizarOSbool = false;
            this.st_etapaorcamento = string.Empty;
            this.st_etapaorcamentobool = false;
            this.st_envterceiro = string.Empty;
            this.st_envterceirobool = false;
        }
    }

    public class TCD_TpOrdem_X_Etapa : TDataQuery
    {
        public TCD_TpOrdem_X_Etapa()
        { }

        public TCD_TpOrdem_X_Etapa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.tp_ordem, b.ds_tipoordem, ");
                sql.AppendLine("a.id_etapa, c.ds_etapa, a.Ordem, ");
                sql.AppendLine("c.st_iniciarOS, c.st_finalizarOS, c.st_etapaorcamento, c.st_envterceiro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_ose_tpordem_x_etapa a ");
            sql.AppendLine("inner join tb_ose_tpordem b ");
            sql.AppendLine("on a.tp_ordem = b.tp_ordem ");
            sql.AppendLine("inner join tb_ose_etapaordem c ");
            sql.AppendLine("on a.id_etapa = c.id_etapa ");

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

        public TList_TpOrdem_X_Etapa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TpOrdem_X_Etapa lista = new TList_TpOrdem_X_Etapa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TpOrdem_X_Etapa reg = new TRegistro_TpOrdem_X_Etapa();

                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("tp_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoordem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_tipoordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        reg.Ds_etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ordem")))
                        reg.Ordem = reader.GetDecimal(reader.GetOrdinal("Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_iniciarOS")))
                        reg.St_iniciarOS = reader.GetString(reader.GetOrdinal("st_iniciarOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_finalizarOS")))
                        reg.St_finalizarOS = reader.GetString(reader.GetOrdinal("st_finalizarOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_etapaorcamento")))
                        reg.St_etapaorcamento = reader.GetString(reader.GetOrdinal("st_etapaorcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_envterceiro")))
                        reg.St_envterceiro = reader.GetString(reader.GetOrdinal("st_envterceiro"));

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

        public string Gravar(TRegistro_TpOrdem_X_Etapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_ORDEM", val.Ordem);

            return this.executarProc("IA_OSE_TPORDEM_X_ETAPA", hs);
        }

        public string Excluir(TRegistro_TpOrdem_X_Etapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);

            return this.executarProc("EXCLUI_OSE_TPORDEM_X_ETAPA", hs);
        }
    }
}
