using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region Manutencao_X_Almox
    public class TList_Manutencao_X_Almox : List<TRegistro_Manutencao_X_Almox>, IComparer<TRegistro_Manutencao_X_Almox>
    {
        #region IComparer<TRegistro_Manutencao_X_Almox> Members
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

        public TList_Manutencao_X_Almox()
        { }

        public TList_Manutencao_X_Almox(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Manutencao_X_Almox value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Manutencao_X_Almox x, TRegistro_Manutencao_X_Almox y)
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
    
    public class TRegistro_Manutencao_X_Almox
    {
        private decimal? id_manutencao;
        
        public decimal? Id_manutencao
        {
            get { return id_manutencao; }
            set
            {
                id_manutencao = value;
                id_manutencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_manutencaostr;
        
        public string Id_manutencaostr
        {
            get { return id_manutencaostr; }
            set
            {
                id_manutencaostr = value;
                try
                {
                    id_manutencao = decimal.Parse(value);
                }
                catch
                { id_manutencao = null; }

            }
        }
        private decimal? id_veiculo;
        
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        
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
        private decimal? id_movimento;
        
        public decimal? Id_movimento
        {
            get { return id_movimento; }
            set
            {
                id_movimento = value;
                id_movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movimentostr;
        
        public string Id_movimentostr
        {
            get { return id_movimentostr; }
            set
            {
                id_movimentostr = value;
                try
                {
                    id_movimento = decimal.Parse(value);
                }
                catch
                { id_movimento = null; }
            }
        }


        public TRegistro_Manutencao_X_Almox()
        {
            this.id_manutencao = null;
            this.id_manutencaostr = string.Empty;
            this.id_veiculo = null;
            this.id_veiculostr = string.Empty;
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;

        }
    }

    public class TCD_Manutencao_X_Almox : TDataQuery
    {
        public TCD_Manutencao_X_Almox()
        { }

        public TCD_Manutencao_X_Almox(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_manutencao, a.id_veiculo, a.id_movimento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Manut_X_Almox a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Manutencao_X_Almox Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Manutencao_X_Almox lista = new TList_Manutencao_X_Almox();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Manutencao_X_Almox reg = new TRegistro_Manutencao_X_Almox();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_manutencao")))
                        reg.Id_manutencao = reader.GetDecimal(reader.GetOrdinal("id_manutencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("id_movimento"));

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

        public string Gravar(TRegistro_Manutencao_X_Almox val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);


            return this.executarProc("IA_FRT_MANUT_X_ALMOX", hs);
        }

        public string Excluir(TRegistro_Manutencao_X_Almox val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);


            return this.executarProc("EXCLUI_FRT_MANUT_X_ALMOX", hs);
        }
    }
    #endregion
}
