using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_Cad_TaxaBandeiraCartao : List<TRegistro_Cad_TaxaBandeiraCartao>, IComparer<TRegistro_Cad_TaxaBandeiraCartao>
    {
        #region IComparer<TRegistro_Cad_TaxaBandeiraCartao> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Cad_TaxaBandeiraCartao()
        { }

        public TList_Cad_TaxaBandeiraCartao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cad_TaxaBandeiraCartao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cad_TaxaBandeiraCartao x, TRegistro_Cad_TaxaBandeiraCartao y)
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
    
    public class TRegistro_Cad_TaxaBandeiraCartao
    {
        private decimal? id_bandeira;
        
        public decimal? ID_Bandeira
        {
            get { return id_bandeira; }
            set
            {
                id_bandeira = value;
                id_bandeirastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bandeirastr;
        
        public string Id_bandeirastr
        {
            get { return id_bandeirastr; }
            set
            {
                id_bandeirastr = value;
                try
                {
                    id_bandeira = Convert.ToDecimal(value);
                }
                catch
                { id_bandeira = null; }
            }
        }
        
        public string DS_Bandeira
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }

        private decimal? id_maquina;
        public decimal? Id_maquina
        {
            get { return id_maquina; }
            set
            {
                id_maquina = value;
                id_maquinastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_maquinastr;
        public string Id_maquinastr
        {
            get { return id_maquinastr; }
            set
            {
                id_maquinastr = value;
                try
                {
                    id_maquina = decimal.Parse(value);
                }catch { id_maquina = null; }
            }
        }
        public string Ds_maquina { get; set; }

        public string Cd_domiciliobancario
        { get; set; }
        
        public string Ds_domiciliobancario
        { get; set; }
        
        public decimal Pc_taxa
        { get; set; }
        
        public decimal Dia_vencto
        { get; set; }

        public TRegistro_Cad_TaxaBandeiraCartao()
        {
            ID_Bandeira = null;
            id_bandeirastr = string.Empty;
            DS_Bandeira = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_maquina = null;
            id_maquinastr = string.Empty;
            Ds_maquina = string.Empty;
            Cd_domiciliobancario = string.Empty;
            Ds_domiciliobancario = string.Empty;
            Pc_taxa = decimal.Zero;
            Dia_vencto = decimal.Zero;
        }
    }

    public class TCD_Cad_TaxaBandeiraCartao : TDataQuery
    {
        public TCD_Cad_TaxaBandeiraCartao()
        { }

        public TCD_Cad_TaxaBandeiraCartao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Bandeira, b.DS_Bandeira, ");
                sql.AppendLine("a.cd_empresa, c.nm_empresa, a.pc_taxa, a.dia_vencto, ");
                sql.AppendLine("a.id_maquina, maq.ds_maquina, ");
                sql.AppendLine("a.cd_domiciliobancario, d.ds_contager as ds_domiciliobancario ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_taxabandeira a ");
            sql.AppendLine("inner join TB_FIN_BandeiraCartao b ");
            sql.AppendLine("on a.ID_Bandeira = b.ID_Bandeira ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_fin_maquinacartao maq ");
            sql.AppendLine("on a.id_maquina = maq.id_maquina ");
            sql.AppendLine("left outer join tb_fin_contager d ");
            sql.AppendLine("on a.cd_domiciliobancario = d.cd_contager ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_TaxaBandeiraCartao Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Cad_TaxaBandeiraCartao lista = new TList_Cad_TaxaBandeiraCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_TaxaBandeiraCartao reg = new TRegistro_Cad_TaxaBandeiraCartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bandeira")))
                        reg.ID_Bandeira = reader.GetDecimal(reader.GetOrdinal("ID_Bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Bandeira")))
                        reg.DS_Bandeira = reader.GetString(reader.GetOrdinal("DS_Bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_maquina")))
                        reg.Id_maquina = reader.GetDecimal(reader.GetOrdinal("id_maquina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_maquina")))
                        reg.Ds_maquina = reader.GetString(reader.GetOrdinal("ds_maquina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_domiciliobancario")))
                        reg.Cd_domiciliobancario = reader.GetString(reader.GetOrdinal("cd_domiciliobancario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_domiciliobancario")))
                        reg.Ds_domiciliobancario = reader.GetString(reader.GetOrdinal("ds_domiciliobancario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_taxa")))
                        reg.Pc_taxa = reader.GetDecimal(reader.GetOrdinal("pc_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dia_vencto")))
                        reg.Dia_vencto = reader.GetDecimal(reader.GetOrdinal("dia_vencto"));
        
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

        public string Gravar(TRegistro_Cad_TaxaBandeiraCartao val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_BANDEIRA", val.ID_Bandeira);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MAQUINA", val.Id_maquina);
            hs.Add("@P_CD_DOMICILIOBANCARIO", val.Cd_domiciliobancario);
            hs.Add("@P_PC_TAXA", val.Pc_taxa);
            hs.Add("@P_DIA_VENCTO", val.Dia_vencto);

            return executarProc("IA_FIN_TAXABANDEIRA", hs);
        }

        public string Excluir(TRegistro_Cad_TaxaBandeiraCartao val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_BANDEIRA", val.ID_Bandeira);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MAQUINA", val.Id_maquina);

            return executarProc("EXCLUI_FIN_TAXABANDEIRA", hs);
        }
    }
}
