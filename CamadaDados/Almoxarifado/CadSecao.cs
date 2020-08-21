using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Almoxarifado
{
    public class TList_CadSecao : List<TRegistro_CadSecao>, IComparer<TRegistro_CadSecao>
    {
        #region IComparer<TRegistro_CadSecao> Members
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

        public TList_CadSecao()
        { }

        public TList_CadSecao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSecao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSecao x, TRegistro_CadSecao y)
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

    
    public class TRegistro_CadSecao
    {
        private decimal? id_rua;
        
        public decimal? Id_rua
        {
            get { return id_rua; }
            set
            {
                id_rua = value;
                id_ruastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ruastr;
        
        public string Id_ruastr
        {
            get { return id_ruastr; }
            set
            {
                id_ruastr = value;
                try
                {
                    id_rua = decimal.Parse(value);
                }
                catch
                { id_rua = null; }
            }
        }
        
        public string Ds_rua
        { get; set; }
        private decimal? id_secao;
        
        public decimal? Id_secao
        {
            get { return id_secao; }
            set
            {
                id_secao = value;
                id_secaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_secaostr;
        
        public string Id_secaostr
        {
            get { return id_secaostr; }
            set
            {
                id_secaostr = value;
                try
                {
                    id_secao = decimal.Parse(value);
                }
                catch
                { id_secao = null; }
            }
        }
        
        public string Ds_secao
        { get; set; }

        public TRegistro_CadSecao()
        {
            this.id_rua = null;
            this.id_ruastr = string.Empty;
            this.Ds_rua = string.Empty;
            this.id_secao = null;
            this.id_secaostr = string.Empty;
            this.Ds_secao = string.Empty;
        }
    }

    public class TCD_CadSecao : TDataQuery
    {
        public TCD_CadSecao()
        {}

        public TCD_CadSecao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
          string strTop = string.Empty;
          if (vTop > 0)
              strTop = " TOP" + Convert.ToString(vTop);
          StringBuilder sql = new StringBuilder();
          if (string.IsNullOrEmpty(vNm_Campo))
              sql.AppendLine(" Select " + strTop + " a.id_rua , a.id_secao , a.ds_secao , b.ds_rua ");
          else
              sql.AppendLine(" Select " + strTop + " " + vNm_Campo + " ");
          sql.AppendLine("From tb_amx_secao a ");
          sql.AppendLine("inner join tb_amx_rua b ");
          sql.AppendLine("on b.id_rua = a.id_rua ");

          string cond = "where";
          if (vBusca != null)
              for (int i = 0; i < (vBusca.Length); i++)
              {
                  sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ") ");
                  cond = "and";
              }
          return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
          return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
          return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
          return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadSecao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
          TList_CadSecao lista = new TList_CadSecao();
          System.Data.SqlClient.SqlDataReader reader = null;
          bool podeFecharBco = false;
          if (Banco_Dados == null)
              podeFecharBco = this.CriarBanco_Dados(false);
          try
          {
              reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
              while (reader.Read())
              {
                  TRegistro_CadSecao reg = new TRegistro_CadSecao();
                  if (!(reader.IsDBNull(reader.GetOrdinal("Id_Rua"))))
                      reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("Id_Rua"));
                  if (!(reader.IsDBNull(reader.GetOrdinal("Id_Secao"))))
                      reg.Id_secao = reader.GetDecimal(reader.GetOrdinal("Id_Secao"));
                  if (!(reader.IsDBNull(reader.GetOrdinal("DS_Secao"))))
                      reg.Ds_secao = reader.GetString(reader.GetOrdinal("DS_Secao"));
                  if (!(reader.IsDBNull(reader.GetOrdinal("Ds_Rua"))))
                      reg.Ds_rua = reader.GetString(reader.GetOrdinal("Ds_Rua"));
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

        public string Gravar(TRegistro_CadSecao val)
        {
          System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
          hs.Add("@P_ID_RUA", val.Id_rua);
          hs.Add("@P_ID_SECAO", val.Id_secao);
          hs.Add("@P_DS_SECAO", val.Ds_secao);

          return this.executarProc("IA_AMX_SECAO", hs);
        }

        public string Excluir(TRegistro_CadSecao val)
        {
          System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
          hs.Add("@P_ID_RUA", val.Id_rua);
          hs.Add("@P_ID_SECAO", val.Id_secao);

          return this.executarProc("EXCLUI_AMX_SECAO", hs);
        }
    }
}
