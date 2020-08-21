using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_BombaAbastecimento : List<TRegistro_BombaAbastecimento>, IComparer<TRegistro_BombaAbastecimento>
    {
        #region IComparer<TRegistro_BombaAbastecimento> Members
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

        public TList_BombaAbastecimento()
        { }

        public TList_BombaAbastecimento(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_BombaAbastecimento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_BombaAbastecimento x, TRegistro_BombaAbastecimento y)
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

    
    public class TRegistro_BombaAbastecimento
    {
        private decimal? id_bomba;
        
        public decimal? Id_bomba
        {
            get { return id_bomba; }
            set
            {
                id_bomba = value;
                id_bombastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bombastr;
        
        public string Id_bombastr
        {
            get { return id_bombastr; }
            set
            {
                id_bombastr = value;
                try
                {
                    id_bomba = decimal.Parse(value);
                }
                catch
                { id_bomba = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nm_fabricante
        { get; set; }
        
        public string Nr_serie
        { get; set; }
        
        public string Ds_modelo
        { get; set; }
        
        public string Tp_medicao
        { get; set; }
        public string Tipo_medicao
        {
            get
            {
                if (Tp_medicao.Trim().ToUpper().Equals("A"))
                    return "ANALOGICA";
                else if (Tp_medicao.Trim().ToUpper().Equals("D"))
                    return "DIGITAL";
                else return string.Empty;
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public bool St_processar
        { get; set; }
        
        public TList_BicoBomba lBico
        { get; set; }
        
        public TList_BicoBomba lBicoDel
        { get; set; }
        
        public TList_LacreBomba lLacre
        { get; set; }
        
        public TList_LacreBomba lLacreDel
        { get; set; }
        
        public TRegistro_BombaAbastecimento()
        {
            this.id_bomba = null;
            this.id_bombastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nm_fabricante = string.Empty;
            this.Nr_serie = string.Empty;
            this.Ds_modelo = string.Empty;
            this.Tp_medicao = string.Empty;
            this.St_processar = false;
            this.lBico = new TList_BicoBomba();
            this.lBicoDel = new TList_BicoBomba();
            this.lLacre = new TList_LacreBomba();
            this.lLacreDel = new TList_LacreBomba();
        }
    }

    public class TCD_BombaAbastecimento : TDataQuery
    {
        public TCD_BombaAbastecimento()
        { }

        public TCD_BombaAbastecimento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.ID_Bomba, A.nm_fabricante, ");
                sql.AppendLine("a.NR_Serie, a.DS_Modelo, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.TP_Medicao, a.ds_observacao ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_BombaAbastecimento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
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

        public TList_BombaAbastecimento Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_BombaAbastecimento lista = new TList_BombaAbastecimento();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_BombaAbastecimento reg = new TRegistro_BombaAbastecimento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bomba")))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("ID_Bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fabricante")))
                        reg.Nm_fabricante = reader.GetString(reader.GetOrdinal("nm_fabricante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("DS_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Medicao")))
                        reg.Tp_medicao = reader.GetString(reader.GetOrdinal("TP_Medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    
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

        public string Gravar(TRegistro_BombaAbastecimento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_BOMBA", val.Id_bomba);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NM_FABRICANTE", val.Nm_fabricante);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_DS_MODELO", val.Ds_modelo);
            hs.Add("@P_TP_MEDICAO", val.Tp_medicao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_PDC_BOMBAABASTECIMENTO", hs);
        }

        public string Excluir(TRegistro_BombaAbastecimento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_BOMBA", val.Id_bomba);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDC_BOMBAABASTECIMENTO", hs);
        }
    }
}
