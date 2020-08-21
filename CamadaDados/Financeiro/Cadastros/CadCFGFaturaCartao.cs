using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CFGFaturaCartao : List<TRegistro_CFGFaturaCartao>
    { }

    
    public class TRegistro_CFGFaturaCartao
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_historico_rec
        { get; set; }
        
        public string Ds_historico_rec
        { get; set; }
        
        public string Cd_historico_pag
        { get; set; }
        
        public string Ds_historico_pag
        { get; set; }
        
        public string Cd_historico_juro
        { get; set; }
        
        public string Ds_historico_juro
        { get; set; }
        
        public string Cd_historico_taxa
        { get; set; }
        
        public string Ds_historico_taxa
        { get; set; }
        
        public TRegistro_CFGFaturaCartao()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_historico_rec = string.Empty;
            this.Ds_historico_rec = string.Empty;
            this.Cd_historico_pag = string.Empty;
            this.Ds_historico_pag = string.Empty;
            this.Cd_historico_juro = string.Empty;
            this.Ds_historico_juro = string.Empty;
            this.Cd_historico_taxa = string.Empty;
            this.Ds_historico_taxa = string.Empty;
        }
    }

    public class TCD_CFGFaturaCartao : TDataQuery
    {
        public TCD_CFGFaturaCartao()
        { }

        public TCD_CFGFaturaCartao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Historico_rec, hC.DS_Historico as DS_Historico_rec, ");
                sql.AppendLine("a.cd_historico_pag, hp.ds_historico as DS_Historico_pag, ");
                sql.AppendLine("a.CD_Historico_Juro, hJuroC.DS_Historico as DS_Historico_Juro, ");
                sql.AppendLine("a.CD_Historico_Taxa, ht.ds_historico as DS_Historico_Taxa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_CFGFaturaCartao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Historico hC ");
            sql.AppendLine("on a.CD_Historico_rec = hC.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico hp ");
            sql.AppendLine("on a.cd_historico_pag = hp.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Historico hJuroC ");
            sql.AppendLine("on a.CD_Historico_Juro = hJuroC.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico ht ");
            sql.AppendLine("on a.cd_historico_taxa = ht.cd_historico ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
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

        public TList_CFGFaturaCartao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGFaturaCartao lista = new TList_CFGFaturaCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGFaturaCartao reg = new TRegistro_CFGFaturaCartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_rec")))
                        reg.Cd_historico_rec = reader.GetString(reader.GetOrdinal("CD_Historico_rec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_rec")))
                        reg.Ds_historico_rec = reader.GetString(reader.GetOrdinal("DS_Historico_rec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_pag")))
                        reg.Cd_historico_pag = reader.GetString(reader.GetOrdinal("cd_historico_pag"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_pag")))
                        reg.Ds_historico_pag = reader.GetString(reader.GetOrdinal("ds_historico_pag"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Juro")))
                        reg.Cd_historico_juro = reader.GetString(reader.GetOrdinal("CD_Historico_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Juro")))
                        reg.Ds_historico_juro = reader.GetString(reader.GetOrdinal("DS_Historico_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_taxa")))
                        reg.Cd_historico_taxa = reader.GetString(reader.GetOrdinal("cd_historico_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_taxa")))
                        reg.Ds_historico_taxa = reader.GetString(reader.GetOrdinal("ds_historico_taxa"));

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

        public string Gravar(TRegistro_CFGFaturaCartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO_REC", val.Cd_historico_rec);
            hs.Add("@P_CD_HISTORICO_PAG", val.Cd_historico_pag);
            hs.Add("@P_CD_HISTORICO_JURO", val.Cd_historico_juro);
            hs.Add("@P_CD_HISTORICO_TAXA", val.Cd_historico_taxa);

            return this.executarProc("IA_FIN_CFGFATURACARTAO", hs);
        }

        public string Excluir(TRegistro_CFGFaturaCartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CFGFATURACARTAO", hs);
        }
    }
}
