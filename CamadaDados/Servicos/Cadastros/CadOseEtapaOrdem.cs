using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_EtapaOrdem : List<TRegistro_EtapaOrdem>, IComparer<TRegistro_EtapaOrdem>
    {
        #region IComparer<TRegistro_EtapaOrdem> Members
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

        public TList_EtapaOrdem()
        { }

        public TList_EtapaOrdem(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EtapaOrdem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EtapaOrdem x, TRegistro_EtapaOrdem y)
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

    
    public class TRegistro_EtapaOrdem
    {
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
        
        public bool St_processar
        { get; set; }


        public TRegistro_EtapaOrdem()
        {
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
            this.St_processar = false;
        }
    }

    public class TCD_EtapaOrdem : TDataQuery
    {
        public TCD_EtapaOrdem()
        { }

        public TCD_EtapaOrdem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_etapa, a.ds_etapa, ");
                sql.AppendLine("a.st_iniciarOS, a.st_finalizarOS, a.st_etapaorcamento, a.st_envterceiro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from tb_ose_etapaordem a ");

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

        public TList_EtapaOrdem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_EtapaOrdem lista = new TList_EtapaOrdem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_EtapaOrdem reg = new TRegistro_EtapaOrdem();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        reg.Ds_etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
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

        public string Gravar(TRegistro_EtapaOrdem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_DS_ETAPA", val.Ds_etapa);
            hs.Add("@P_ST_INICIAROS", val.St_iniciarOS);
            hs.Add("@P_ST_FINALIZAROS", val.St_finalizarOS);
            hs.Add("@P_ST_ETAPAORCAMENTO", val.St_etapaorcamento);
            hs.Add("@P_ST_ENVTERCEIRO", val.St_envterceiro);

            return this.executarProc("IA_OSE_ETAPAORDEM", hs);
        }

        public string Excluir(TRegistro_EtapaOrdem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);

            return this.executarProc("EXCLUI_OSE_ETAPAORDEM", hs);
        }
    }
}