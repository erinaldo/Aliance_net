using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    #region Rodado
    public class TList_Rodado : List<TRegistro_Rodado>, IComparer<TRegistro_Rodado>
    {
        #region IComparer<TRegistro_Rodado> Members
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

        public TList_Rodado()
        { }

        public TList_Rodado(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Rodado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Rodado x, TRegistro_Rodado y)
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

    public class TRegistro_Rodado
    {
        private decimal? id_rodado = null;
        public decimal? Id_rodado
        {
            get { return id_rodado; }
            set
            {
                id_rodado = value;
                id_rodadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_rodadostr = string.Empty;
        public string Id_rodadostr
        {
            get { return id_rodadostr; }
            set
            {
                id_rodadostr = value;
                try
                {
                    id_rodado = decimal.Parse(value);
                }
                catch
                { id_rodado = null; }
            }
        }

        public string Ds_rodado { get; set; } = string.Empty;

        //Informações pneu do rodado
        public string Id_pneu { get; set; } = string.Empty;
        public string Nr_serie { get; set; } = string.Empty;
        public string Cd_produto { get; set; } = string.Empty;

        private decimal? id_veiculo = null;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr = string.Empty;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch
                {
                    id_veiculo = null;
                }
            }
        }
        public bool St_processar { get; set; } = true;

    }

    public class TCD_Rodado : TDataQuery
    {
        public TCD_Rodado()
        { }

        public TCD_Rodado(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_rodado, a.ds_rodado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Rodado a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaRodadoComVeiculo(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_rodado, a.ds_rodado, b.id_veiculo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Rodado a ");
            sql.AppendLine("inner join TB_FRT_RodadoVeic b on a.ID_Rodado = b.ID_Rodado ");

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

        public TList_Rodado Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Rodado lista = new TList_Rodado();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Rodado reg = new TRegistro_Rodado();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rodado")))
                        reg.Id_rodado = reader.GetDecimal(reader.GetOrdinal("Id_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rodado")))
                        reg.Ds_rodado = reader.GetString(reader.GetOrdinal("Ds_rodado"));

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

        public TList_Rodado SelectRodadoComVeiculo(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Rodado lista = new TList_Rodado();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaRodadoComVeiculo(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Rodado reg = new TRegistro_Rodado();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rodado")))
                        reg.Id_rodado = reader.GetDecimal(reader.GetOrdinal("Id_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rodado")))
                        reg.Ds_rodado = reader.GetString(reader.GetOrdinal("Ds_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_veiculo"));

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


        public string Gravar(TRegistro_Rodado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_RODADO", val.Id_rodado);
            hs.Add("@P_DS_RODADO", val.Ds_rodado);

            return this.executarProc("IA_FRT_RODADO", hs);
        }

        public string Excluir(TRegistro_Rodado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_RODADO", val.Id_rodado);

            return this.executarProc("EXCLUI_FRT_RODADO", hs);
        }
    }
    #endregion

    #region Rodado Veículo
    public class TList_RodadoVeic : List<TRegistro_RodadoVeic>, IComparer<TRegistro_RodadoVeic>
    {
        #region IComparer<TRegistro_RodadoVeic> Members
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

        public TList_RodadoVeic()
        { }

        public TList_RodadoVeic(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_RodadoVeic value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_RodadoVeic x, TRegistro_RodadoVeic y)
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

    public class TRegistro_RodadoVeic
    {
        private decimal? id_rodado = null;
        public decimal? Id_rodado
        {
            get { return id_rodado; }
            set
            {
                id_rodado = value;
                id_rodadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_rodadostr = string.Empty;
        public string Id_rodadostr
        {
            get { return id_rodadostr; }
            set
            {
                id_rodadostr = value;
                try
                {
                    id_rodado = decimal.Parse(value);
                }
                catch
                { id_rodado = null; }
            }
        }
        private decimal? id_veiculo = null;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr = string.Empty;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public bool St_processar { get; set; } = false;
    }

    public class TCD_RodadoVeic : TDataQuery
    {
        public TCD_RodadoVeic()
        { }

        public TCD_RodadoVeic(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_rodado, a.id_veiculo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_RodadoVeic a ");

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

        public TList_RodadoVeic Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RodadoVeic lista = new TList_RodadoVeic();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_RodadoVeic reg = new TRegistro_RodadoVeic();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rodado")))
                        reg.Id_rodado = reader.GetDecimal(reader.GetOrdinal("Id_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_veiculo"));

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

        public string Gravar(TRegistro_RodadoVeic val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_RODADO", val.Id_rodado);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return this.executarProc("IA_FRT_RODADOVEIC", hs);
        }

        public string Excluir(TRegistro_RodadoVeic val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_RODADO", val.Id_rodado);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return this.executarProc("EXCLUI_FRT_RODADOVEIC", hs);
        }
    }
    #endregion
}
