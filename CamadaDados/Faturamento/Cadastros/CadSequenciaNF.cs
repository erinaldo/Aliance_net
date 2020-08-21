using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadSequenciaNF : List<TRegistro_CadSequenciaNF>, IComparer<TRegistro_CadSequenciaNF>
    {
        #region IComparer<TRegistro_CadSequenciaNF> Members
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

        public TList_CadSequenciaNF()
        { }

        public TList_CadSequenciaNF(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSequenciaNF value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSequenciaNF x, TRegistro_CadSequenciaNF y)
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

    
    public class TRegistro_CadSequenciaNF
    {
        
        public string Nr_Serie
        { get; set; }
        
        public string DS_Serie
        { get; set; }
        
        public string Cd_modelo
        { get; set; }
        
        public string Ds_modelo
        { get; set; }
        
        public string CD_Empresa
        { get; set; }
        
        public string NM_Empresa
        { get; set; }
        
        public decimal Seq_NotaFiscal
        { get; set; }
        
        public decimal Seq_RPS
        { get; set; }

        public TRegistro_CadSequenciaNF()
        {
            this.Nr_Serie = string.Empty;
            this.DS_Serie = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Ds_modelo = string.Empty;
            this.CD_Empresa = string.Empty;
            this.NM_Empresa = string.Empty;
            this.Seq_NotaFiscal = decimal.Zero;
            this.Seq_RPS = decimal.Zero;
        }
    }

    public class TCD_CadSequenciaNF : TDataQuery
    {
        public TCD_CadSequenciaNF()
        { }

        public TCD_CadSequenciaNF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.nr_serie, c.ds_serieNF, a.cd_modelo, d.ds_modelo, ");
                sql.AppendLine("a.seq_notafiscal, a.seq_rps ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_fat_sequencianf a ");
            sql.AppendLine("inner join tb_div_Empresa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_Empresa ");
            sql.AppendLine("inner join tb_fat_Serienf c ");
            sql.AppendLine("on c.nr_serie = a.nr_serie ");
            sql.AppendLine("and c.cd_modelo = a.cd_modelo ");
            sql.AppendLine("inner join tb_fat_modelonf d ");
            sql.AppendLine("on a.cd_modelo = d.cd_modelo ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
           
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

        public TList_CadSequenciaNF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadSequenciaNF lista = new TList_CadSequenciaNF();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSequenciaNF reg = new TRegistro_CadSequenciaNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_Serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.DS_Serie = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("ds_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("seq_NotaFiscal")))
                        reg.Seq_NotaFiscal = reader.GetDecimal(reader.GetOrdinal("seq_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("seq_rps")))
                        reg.Seq_RPS = reader.GetDecimal(reader.GetOrdinal("seq_rps"));
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

        public string Grava(TRegistro_CadSequenciaNF vRegistro)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_Serie);
            hs.Add("@P_CD_MODELO", vRegistro.Cd_modelo);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_SEQ_NOTAFISCAL", vRegistro.Seq_NotaFiscal);
            hs.Add("@P_SEQ_RPS", vRegistro.Seq_RPS);

            return this.executarProc("IA_FAT_SEQUENCIANF", hs);
        }

        public string Deleta(TRegistro_CadSequenciaNF vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_Serie);
            hs.Add("@P_CD_MODELO", vRegistro.Cd_modelo);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);

            return this.executarProc("EXCLUI_FAT_SEQUENCIANF", hs);
        }
    }
}
