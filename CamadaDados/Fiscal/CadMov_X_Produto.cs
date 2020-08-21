using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace CamadaDados.Fiscal
{
    public class TList_Mov_X_Produto : List<TRegistro_Mov_X_Produto>
    { }

    [DataContract]
    public class TRegistro_Mov_X_Produto
    {
        private decimal? cd_movimentacao;
        [DataMember]
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movimentacaostr;
        [DataMember]
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = Convert.ToDecimal(value);
                }
                catch
                { cd_movimentacao = null; }
            }
        }
        [DataMember]
        public string Ds_movimentacao
        { get; set; }
        [DataMember]
        public string Cd_produto
        { get; set; }
        [DataMember]
        public string Ds_produto
        { get; set; }

        public TRegistro_Mov_X_Produto()
        {
            this.cd_movimentacao = null;
            this.cd_movimentacaostr = string.Empty;
            this.Ds_movimentacao = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
        }
    }

    public class TCD_Mov_X_Produto : TDataQuery
    {
        public TCD_Mov_X_Produto()
        { }

        public TCD_Mov_X_Produto(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.cd_movimentacao, b.ds_movimentacao, ");
                sql.AppendLine("a.cd_produto, c.ds_produto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_fis_movimentacao_x_produto a ");
            sql.AppendLine("inner join tb_fis_movimentacao b ");
            sql.AppendLine("on a.cd_movimentacao = b.cd_movimentacao ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");

            cond = " where ";
            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
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

        public TList_Mov_X_Produto Select(Utils.TpBusca[] vBusca, Int32 vTop)
        {
            TList_Mov_X_Produto lista = new TList_Mov_X_Produto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                while (reader.Read())
                {
                    TRegistro_Mov_X_Produto reg = new TRegistro_Mov_X_Produto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MOVIMENTACAO"))))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MOVIMENTACAO"))))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));

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

        public string Gravar(TRegistro_Mov_X_Produto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("IA_FIS_MOVIMENTACAO_X_PRODUTO", hs);
        }

        public string Excluir(TRegistro_Mov_X_Produto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_FIS_MOVIMENTACAO_X_PRODUTO", hs);
        }
    }
}
