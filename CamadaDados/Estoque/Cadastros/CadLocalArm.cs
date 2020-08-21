using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadLocalArm : List<TRegistro_CadLocalArm>, IComparer<TRegistro_CadLocalArm>
    {
        #region IComparer<TRegistro_CadLocalArm> Members
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

        public TList_CadLocalArm()
        { }

        public TList_CadLocalArm(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadLocalArm value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadLocalArm x, TRegistro_CadLocalArm y)
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
    
        
    public class TRegistro_CadLocalArm
    {
        
        public string Cd_local {get; set; }
        
        public string Ds_local {get; set;}        
        private string tp_local;
        
        public string Tp_local
        {
            get { return tp_local; }
            set 
            {
                tp_local = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tp_localstr = "CARGA/DESCARGA";
                else if (value.Trim().ToUpper().Equals("C"))
                    tp_localstr = "CARGA";
                else if (value.Trim().ToUpper().Equals("D"))
                    tp_localstr = "DESCARGA";
            }
        }
        private string tp_localstr;
        
        public string Tp_localstr
        {
            get { return tp_localstr; }
            set 
            {
                tp_localstr = value;
                if (value.Trim().ToUpper().Equals("CARGA/DESCARGA"))
                    tp_local = "A";
                else if (value.Trim().ToUpper().Equals("CARGA"))
                    tp_local = "C";
                else if (value.Trim().ToUpper().Equals("D"))
                    tp_local = "D";
            }
        }
        private string st_estterceiro;
        
        public string St_estterceiro
        {
            get { return st_estterceiro; }
            set
            {
                st_estterceiro = value;
                st_estterceirobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_estterceirobool;
        
        public bool St_estterceirobool
        {
            get { return st_estterceirobool; }
            set
            {
                st_estterceirobool = value;
                st_estterceiro = value ? "S" : "N";
            }
        }
        
        public string St_registro{ get; set;}
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }

        public TRegistro_CadLocalArm()
        {
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.tp_local = string.Empty;
            this.tp_localstr = string.Empty;
            this.st_estterceiro = "N";
            this.st_estterceirobool = false;
            this.St_registro = "A";
        }
    }
 
    public class TCD_CadLocalArm : TDataQuery
    {
        private string _CD_Produto;
        private string _CD_Empresa;

        public TCD_CadLocalArm()
        {            
            _CD_Produto = string.Empty;
            _CD_Empresa = string.Empty;
        }

        public TCD_CadLocalArm(BancoDados.TObjetoBanco banco)
        {
            _CD_Produto = string.Empty;
            _CD_Empresa = string.Empty;
            this.Banco_Dados = banco;
        }

        public TCD_CadLocalArm(string vCD_Produto, string vCD_Empresa)
        {
            _CD_Produto = vCD_Produto;
            _CD_Empresa = vCD_Empresa;
        }

        public TCD_CadLocalArm(string Cd_produto, string Cd_empresa, BancoDados.TObjetoBanco banco)
        {
            _CD_Empresa = Cd_empresa;
            _CD_Produto = Cd_produto;
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            string cond = " Where ";

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT distinct " + strTop + " a.cd_local, a.ds_local, a.tp_local, a.st_registro, a.st_estterceiro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_LocalArm a ");

            if ((!string.IsNullOrEmpty(_CD_Produto)) && (string.IsNullOrEmpty(_CD_Empresa)))
            {                
                sql.AppendLine(" left outer join tb_est_localArm_X_produto b ");
                sql.AppendLine(" on a.cd_local = b.cd_local ");
                sql.AppendLine(" where b.cd_produto = '" + _CD_Produto.Trim() + "' ");
                cond = " and ";
            }
            else if ((!string.IsNullOrEmpty(_CD_Empresa)) && (string.IsNullOrEmpty(_CD_Produto)))
            {
                sql.AppendLine(" left outer join tb_est_Empresa_X_localArm b ");
                sql.AppendLine(" on a.cd_local = b.cd_local ");
                sql.AppendLine(" where b.cd_empresa = '" + _CD_Empresa.Trim() + "' ");
                cond = " and ";
            }
            else if ((!string.IsNullOrEmpty(_CD_Empresa)) && (!string.IsNullOrEmpty(_CD_Produto)))
            {
                sql.AppendLine(" left outer join tb_est_localArm_X_produto b ");
                sql.AppendLine(" on a.cd_local = b.cd_local");
                sql.AppendLine(" left outer join tb_est_Empresa_X_localArm c ");
                sql.AppendLine(" on a.cd_local = c.cd_local");
                sql.AppendLine(" where b.cd_produto = '" + _CD_Produto.Trim() + "' ");
                sql.AppendLine(" and c.cd_empresa = '" + _CD_Empresa.Trim() + "' ");
                cond = " and ";
            }
            else
                cond = " Where ";

            
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.ds_local asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
               return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadLocalArm Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadLocalArm lista = new TList_CadLocalArm();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadLocalArm reg = new TRegistro_CadLocalArm();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_local")))
                        reg.Tp_local = reader.GetString(reader.GetOrdinal("tp_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_estterceiro")))
                        reg.St_estterceiro = reader.GetString(reader.GetOrdinal("st_estterceiro"));
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

        public string Gravar(TRegistro_CadLocalArm vRegistro)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_LOCAL", vRegistro.Cd_local);
            hs.Add("@P_DS_LOCAL", vRegistro.Ds_local);
            hs.Add("@P_TP_LOCAL", vRegistro.Tp_local);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
            hs.Add("@P_ST_ESTTERCEIRO", vRegistro.St_estterceiro);

            return this.executarProc("IA_EST_LOCALARM", hs);
        }

        public string Excluir(TRegistro_CadLocalArm vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_LOCAL", vRegistro.Cd_local);
            return this.executarProc("EXCLUI_EST_LocalArm", hs);
        }
    }
}