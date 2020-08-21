using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace CamadaDados.Empreendimento
{
    public class TRegistro_CompraEmpreendimento
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;

        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string id_contato { get; set; } = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        public string id_atividade { get; set; } = string.Empty;


        private decimal? id_requisicao;
        public decimal? Id_requisicao
        {
            get { return id_requisicao; }
            set
            {
                id_requisicao = value;
                id_requisicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_requisicaostr;
        public string Id_requisicaostr
        {
            get { return id_requisicaostr; }
            set
            {
                id_requisicaostr = value;
                try
                {
                    id_requisicao = decimal.Parse(value);
                }
                catch { id_requisicao = null; }
            }
        }
        private decimal? id_ficha;
        public decimal? Id_ficha
        {
            get { return id_ficha; }
            set
            {
                id_ficha = value;
                id_fichastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_fichastr;
        public string Id_fichastr
        {
            get { return id_fichastr; }
            set
            {
                id_fichastr = value;
                try
                {
                    id_ficha = decimal.Parse(value);
                }
                catch { id_ficha = null; }
            }
        }
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }

    }

    public class TList_CompraEmpreendimento : List<TRegistro_CompraEmpreendimento> { }

    public class TCD_CompraEmpreendimento : TDataQuery
    {
        public TCD_CompraEmpreendimento() { }
        public TCD_CompraEmpreendimento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_atividade, a.id_requisicao, a.id_registro, a.id_orcamento, a.nr_versao, a.cd_empresa, a.id_ficha ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_CompraEmpreendimento a ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_CompraEmpreendimento Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CompraEmpreendimento lista = new TList_CompraEmpreendimento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CompraEmpreendimento reg = new TRegistro_CompraEmpreendimento();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.id_atividade = reader.GetDecimal(reader.GetOrdinal("id_atividade")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_requisicao")))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("id_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha"));

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
        public string Gravar(TRegistro_CompraEmpreendimento val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_ID_ATIVIDADE", val.id_atividade);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao); 
            hs.Add("@P_ID_FICHA", val.Id_ficha); 

            return executarProc("IA_EMP_COMPRAEMPREENDIMENTO", hs);
        }
        public string Excluir(TRegistro_CompraEmpreendimento val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_ID_ATIVIDADE", val.id_atividade);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_FICHA", val.Id_ficha);

            return executarProc("EXCLUI_EMP_COMPRAEMPREENDIMENTO", hs);
        }
    }

}
