using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Teste Versao Atual

namespace CamadaDados.Almoxarifado
{
    public class TList_CadAlmox_X_Empresa : List<TRegistro_CadAlmox_X_Empresa>, IComparer<TRegistro_CadAlmox_X_Empresa>
    {
        #region IComparer<TRegistro_CadAlmox_X_Empresa> Members
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

        public TList_CadAlmox_X_Empresa()
        { }

        public TList_CadAlmox_X_Empresa(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadAlmox_X_Empresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadAlmox_X_Empresa x, TRegistro_CadAlmox_X_Empresa y)
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

    
    public class TRegistro_CadAlmox_X_Empresa
    {
        private decimal? id_almox;
        
        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = id_almox.HasValue ? id_almox.ToString() : string.Empty;
            }
        }

        private string id_almoxstr;
        
        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = decimal.Parse(value);
                }
                catch
                { id_almox = null; }
            }
        }
        
        public string Ds_almox
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }

        public TRegistro_CadAlmox_X_Empresa()
        {
            id_almox = null;
            id_almoxstr = string.Empty;
            Ds_almox = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
        }
    }

    public class TCD_CadAlmox_X_Empresa : TDataQuery
    {
        public TCD_CadAlmox_X_Empresa()
        { }

        public TCD_CadAlmox_X_Empresa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop);
                sql.AppendLine(" a.id_almox, a.cd_empresa, ");
                sql.AppendLine(" b.ds_almoxarifado, c.nm_empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_AMX_ALMOX_X_EMPRESA a ");
            sql.AppendLine("inner join TB_AMX_ALMOXARIFADO b ");
            sql.AppendLine("on b.id_almox = a.id_almox ");
            sql.AppendLine("inner join TB_DIV_EMPRESA c ");
            sql.AppendLine("on c.cd_empresa = a.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        
        public TList_CadAlmox_X_Empresa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadAlmox_X_Empresa lista = new TList_CadAlmox_X_Empresa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAlmox_X_Empresa reg = new TRegistro_CadAlmox_X_Empresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_almoxarifado")))
                        reg.Ds_almox = reader.GetString(reader.GetOrdinal("ds_almoxarifado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));

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

        public string Gravar(TRegistro_CadAlmox_X_Empresa vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ALMOX", vRegistro.Id_almox);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return executarProc("IA_AMX_ALMOX_X_EMPRESA", hs);
        }

        public string Excluir(TRegistro_CadAlmox_X_Empresa vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ALMOX", vRegistro.Id_almox);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return executarProc("EXCLUI_AMX_ALMOX_X_EMPRESA", hs);
        }
    }
}
