using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using Utils;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_Adicionais
    {
        public string CD_Grupo { get; set; } = string.Empty;
        public string DS_Grupo { get; set; } = string.Empty;
        public string CD_Grupo_prod { get; set; } = string.Empty;
        public string DS_Grupo_prod { get; set; } = string.Empty;
        public string CD_Produto { get; set; } = string.Empty;
        public string DS_Produto { get; set; } = string.Empty;
        public string CD_Produto_adicional { get; set; } = string.Empty;
        public string DS_Produto_adicional { get; set; } = string.Empty;
        public decimal Quantidade { get; set; } = decimal.Zero;
        public bool St_processar { get; set; } = false;
        public decimal vl_unitario { get; set; } = decimal.Zero;

    }
    public class TList_Adicionais : List<TRegistro_Adicionais> , IComparer<TRegistro_Adicionais>
    {
        #region IComparer<TRegistro_CadAssistenteVenda> Members
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

        public TList_Adicionais()
        { }

        public TList_Adicionais(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Adicionais value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Adicionais x, TRegistro_Adicionais y)
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

    public class TCD_Adicionais : TDataQuery
    {
        public TCD_Adicionais()
        { }

        public TCD_Adicionais(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_grupo    ,a.cd_produto , a.quantidade,  b.ds_grupo  , c.ds_produto    "); 
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_adicionais a ");
            sql.AppendLine("join  tb_est_grupoproduto b on a.cd_grupo = b.cd_grupo ");
            sql.AppendLine("join  tb_est_produto c on a.cd_produto = c.cd_produto ");
           // sql.AppendLine(" left join tb_est_produto d on d.cd_grupo = a.cd_grupo ");
            


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
          // sql.AppendLine("order by a.nm_clifor, a.cd_clifor ");


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

        public TList_Adicionais Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Adicionais lista = new TList_Adicionais();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Adicionais reg = new TRegistro_Adicionais();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Grupo"))))
                        reg.CD_Grupo = reader.GetString(reader.GetOrdinal("CD_Grupo")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto  = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.DS_Grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("TP_Pessoa")))
                    //    reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                    //    reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("dt_cad")))
                    //    reg.Dt_cadastro = reader.GetDateTime(reader.GetOrdinal("dt_cad"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("nr_cartao")))
                    //    reg.nr_cartao = reader.GetString(reader.GetOrdinal("nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto  = reader.GetString(reader.GetOrdinal("DS_Produto")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade")); 
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



        public string Gravar(TRegistro_Adicionais val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_PRODUTO", val.CD_Produto);
            hs.Add("@P_CD_GRUPO", val.CD_Grupo);
            hs.Add("@P_QUANTIDADE", val.Quantidade);


            return this.executarProc("IA_RES_ADICIONAIS", hs);
        }

        public string Excluir(TRegistro_Adicionais val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.CD_Produto);
            hs.Add("@P_CD_GRUPO", val.CD_Grupo);


            return this.executarProc("EXCLUI_RES_ADICIONAIS", hs);
        }
    }

}
