using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using System.Collections;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TList_OrcamentoEncargo : List<TRegistro_OrcamentoEncargo>, IComparer<TRegistro_OrcamentoEncargo>
    {
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

        public TList_OrcamentoEncargo()
        { }

        public TList_OrcamentoEncargo(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrcamentoEncargo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrcamentoEncargo x, TRegistro_OrcamentoEncargo y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }
    public class TRegistro_OrcamentoEncargo : ICloneable
    {
        public bool st_importar { get; set; } = false;
        private decimal? id_encargo = null;
        public decimal? Id_encargo
        {
            get { return id_encargo; }
            set
            {
                id_encargo = value;
                id_encargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_encargostr = string.Empty;
        public string Id_encargostr
        {
            get { return id_encargostr; }
            set
            {
                id_encargostr = value;
                try
                {
                    id_encargo = decimal.Parse(value);
                }
                catch { id_encargo = null; }
            }
        }

        public decimal vl_encargo { get; set; } = decimal.Zero;

        private decimal? cd_empresa = null;
        public decimal? Cd_empresa
        {
            get { return cd_empresa; }
            set
            {
                cd_empresa = value;
                cd_empresastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_empresastr = string.Empty;
        public string Cd_empresastr
        {
            get { return cd_empresastr; }
            set
            {
                cd_empresastr = value;
                try
                {
                    cd_empresa = decimal.Parse(value);
                }
                catch { cd_empresa = null; }
            }
        }


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
        public string id_contato { get; set; } = string.Empty;
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
        public string ds_encargo { get; set; } = string.Empty;
        public decimal pc_encargo { get; set; } = decimal.Zero;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    public class TCD_OrcamentoEncargo : TDataQuery
    {
        public TCD_OrcamentoEncargo() { }
        public TCD_OrcamentoEncargo(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_encargo, a.cd_empresa, a.id_orcamento, a.nr_versao,a.vl_encargo, a.pc_encargo, b.ds_encargo");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_EncargosOrc a ");
            sql.AppendLine(" left join tb_emp_encargosfolha b on a.id_encargo = b.id_encargo");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_OrcamentoEncargo Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrcamentoEncargo lista = new TList_OrcamentoEncargo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_OrcamentoEncargo reg = new TRegistro_OrcamentoEncargo();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_encargo")))
                        reg.Id_encargo = reader.GetDecimal(reader.GetOrdinal("id_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresastr = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("Nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_encargo")))
                        reg.ds_encargo = reader.GetString(reader.GetOrdinal("ds_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_encargo")))
                        reg.pc_encargo = reader.GetDecimal(reader.GetOrdinal("pc_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_encargo")))
                        reg.vl_encargo = reader.GetDecimal(reader.GetOrdinal("vl_encargo"));

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
        public string Gravar(TRegistro_OrcamentoEncargo val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_ENCARGO", val.Id_encargo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresastr);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamentostr);
            hs.Add("@P_NR_VERSAO", val.Nr_versaostr);
            hs.Add("@P_PC_ENCARGO", val.pc_encargo);
            hs.Add("@P_VL_ENCARGO", val.vl_encargo);

            return executarProc("IA_EMP_ENCARGOSORC", hs);
        }
        public string Excluir(TRegistro_OrcamentoEncargo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresastr);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ENCARGO", val.Id_encargo);
            
            return executarProc("EXCLUI_EMP_ENCARGOSORC", hs);
        }
    }
}
