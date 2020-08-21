using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_Negociacao : List<TRegistro_Negociacao>
    { }

    
    public class TRegistro_Negociacao
    {
        
        public decimal? Id_negociacao
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_grupo
        { get; set; }
        
        public string Ds_grupo
        { get; set; }
        
        public string Loginaprovareprova
        { get; set; }
        
        public string Ds_negociacao
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        private DateTime? dt_negociacao;
        
        public DateTime? Dt_negociacao
        {
            get { return dt_negociacao; }
            set
            {
                dt_negociacao = value;
                dt_negociacaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_negociacaostr;
        public string Dt_negociacaostr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_negociacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_negociacaostr = value;
                try
                {
                    dt_negociacao = Convert.ToDateTime(value);
                }
                catch
                { dt_negociacao = null; }
            }
        }
        private DateTime? dt_fechnegociacao;
        
        public DateTime? Dt_fechnegociacao
        {
            get { return dt_fechnegociacao; }
            set
            {
                dt_fechnegociacao = value;
                dt_fechnegociacaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_fechnegociacaostr;
        public string Dt_fechnegociacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fechnegociacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fechnegociacaostr = value;
                try
                {
                    dt_fechnegociacao = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_fechnegociacao = null;
                }
            }
        }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTA";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADA";
                else if (value.Trim().ToUpper().Equals("F"))
                    status = "FECHADA";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADA";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADA";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTA"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("FECHADA"))
                    st_registro = "F";
                else if (value.Trim().ToUpper().Equals("PROCESSADA"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("ENCERRADA"))
                    st_registro = "E";
            }
        }
        
        public TList_NegociacaoItem lItens
        { get; set; }
        
        public TList_NegociacaoItem lItensDel
        { get; set; }

        public TRegistro_Negociacao()
        {
            this.Id_negociacao = null;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
            this.Loginaprovareprova = string.Empty;
            this.Ds_negociacao = string.Empty;
            this.Ds_observacao = string.Empty;
            this.dt_negociacao = DateTime.Now;
            this.dt_negociacaostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_fechnegociacao = null;
            this.dt_fechnegociacaostr = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTA";

            this.lItens = new TList_NegociacaoItem();
            this.lItensDel = new TList_NegociacaoItem();
        }

        public TRegistro_Negociacao Copia()
        {
            return new TRegistro_Negociacao()
            {
                Id_negociacao = this.Id_negociacao,
                Cd_produto = this.Cd_produto,
                Ds_produto = this.Ds_produto,
                Sigla_unidade = this.Sigla_unidade,
                Cd_grupo = this.Cd_grupo,
                Ds_grupo = this.Ds_grupo,
                Loginaprovareprova = this.Loginaprovareprova,
                Ds_negociacao = this.Ds_negociacao,
                dt_negociacao = this.dt_negociacao,
                dt_fechnegociacao = this.dt_fechnegociacao,
                st_registro = this.st_registro,
                lItens = this.lItens,
                lItensDel = this.lItensDel
            };
        }
    }

    public class TCD_Negociacao : TDataQuery
    {
        public TCD_Negociacao()
        { }

        public TCD_Negociacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_negociacao, a.cd_produto, b.ds_produto, ");
                sql.AppendLine("c.sigla_unidade, a.cd_grupo, d.ds_grupo, a.ds_negociacao, a.loginaprovareprova, ");
                sql.AppendLine("a.ds_observacao, a.dt_negociacao, a.dt_fechnegociacao, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_negociacao a ");
            sql.AppendLine("left outer join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("left outer join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto d ");
            sql.AppendLine("on a.cd_grupo = d.cd_grupo ");

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

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Negociacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Negociacao lista = new TList_Negociacao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Negociacao reg = new TRegistro_Negociacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Negociacao"))))
                        reg.Id_negociacao = reader.GetDecimal(reader.GetOrdinal("ID_Negociacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade"))))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Grupo"))))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("CD_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Negociacao")))
                        reg.Ds_negociacao = reader.GetString(reader.GetOrdinal("DS_Negociacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Negociacao")))
                        reg.Dt_negociacao = reader.GetDateTime(reader.GetOrdinal("DT_Negociacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FechNegociacao")))
                        reg.Dt_fechnegociacao = reader.GetDateTime(reader.GetOrdinal("DT_FechNegociacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAprovaReprova")))
                        reg.Loginaprovareprova = reader.GetString(reader.GetOrdinal("LoginAprovaReprova"));

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

        public string GravarNegociacao(TRegistro_Negociacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);
            hs.Add("@P_LOGINAPROVAREPROVA", val.Loginaprovareprova);
            hs.Add("@P_DS_NEGOCIACAO", val.Ds_negociacao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DT_NEGOCIACAO", val.Dt_negociacao);
            hs.Add("@P_DT_FECHNEGOCIACAO", val.Dt_fechnegociacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_CMP_NEGOCIACAO", hs);
        }

        public string DeletarNegociacao(TRegistro_Negociacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);

            return this.executarProc("EXCLUIR_CMP_NEGOCIACAO", hs);
        }
    }
}
