using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_Especificacao : List<TRegistro_Especificacao>
    { }

    
    public class TRegistro_Especificacao
    {
        private decimal? id_especificacao;
        
        public decimal? Id_especificacao
        {
            get { return id_especificacao; }
            set
            {
                id_especificacao = value;
                id_especificacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_especificacaostr;
        
        public string Id_especificacaostr
        {
            get { return id_especificacaostr; }
            set
            {
                id_especificacaostr = value;
                try
                {
                    id_especificacao = Convert.ToDecimal(value);
                }
                catch
                { id_especificacao = null; }
            }
        }
        
        public string Ds_especificacao
        { get; set; }

        public TRegistro_Especificacao()
        {
            this.id_especificacao = null;
            this.id_especificacaostr = string.Empty;
            this.Ds_especificacao = string.Empty;
        }
    }

    public class TCD_Especificacao : TDataQuery
    {
        public TCD_Especificacao()
        { }

        public TCD_Especificacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.id_especificacao, a.ds_especificacao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Especificacao a ");

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

        public TList_Especificacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Especificacao lista = new TList_Especificacao();
            System.Data.SqlClient.SqlDataReader reader = null;
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
                    TRegistro_Especificacao reg = new TRegistro_Especificacao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Especificacao")))
                        reg.Id_especificacao = reader.GetDecimal(reader.GetOrdinal("ID_Especificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Especificacao")))
                        reg.Ds_especificacao = reader.GetString(reader.GetOrdinal("DS_Especificacao"));

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

        public string Gravar(TRegistro_Especificacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ESPECIFICACAO", val.Id_especificacao);
            hs.Add("@P_DS_ESPECIFICACAO", val.Ds_especificacao);

            return this.executarProc("IA_FAT_ESPECIFICACAO", hs);
        }

        public string Excluir(TRegistro_Especificacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ESPECIFICACAO", val.Id_especificacao);

            return this.executarProc("EXCLUI_FAT_ESPECIFICACAO", hs);
        }
    }
}
