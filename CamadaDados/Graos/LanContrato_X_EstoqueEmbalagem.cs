using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Graos
{
    public class TList_Contrato_X_EstoqueEmbalagem : List<TRegistro_Contrato_X_EstoqueEmbalagem>
    { }

    
    public class TRegistro_Contrato_X_EstoqueEmbalagem
    {
        
        public decimal Nr_contrato
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public decimal Id_lanctoestoque
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public TRegistro_Contrato_X_EstoqueEmbalagem()
        {
            this.Nr_contrato = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Id_lanctoestoque = decimal.Zero;
            this.Ds_observacao = string.Empty;
        }
    }

    public class TCD_Contrato_X_EstoqueEmbalagem : TDataQuery
    {
        public TCD_Contrato_X_EstoqueEmbalagem()
        { }

        public TCD_Contrato_X_EstoqueEmbalagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.nr_contrato, a.cd_empresa, ");
                sql.AppendLine("a.cd_produto, a.id_lanctoestoque, a.ds_observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_contrato_x_estoqueembalagem a ");
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

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Contrato_X_EstoqueEmbalagem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Contrato_X_EstoqueEmbalagem lista = new TList_Contrato_X_EstoqueEmbalagem();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Contrato_X_EstoqueEmbalagem reg = new TRegistro_Contrato_X_EstoqueEmbalagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));

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

        public string Gravar(TRegistro_Contrato_X_EstoqueEmbalagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_GRO_CONTRATO_X_ESTOQUEEMBALAGEM", hs);
        }

        public string Excluir(TRegistro_Contrato_X_EstoqueEmbalagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_GRO_CONTRATO_X_ESTOQUEEMBALAGEM", hs);
        }
    }
}
