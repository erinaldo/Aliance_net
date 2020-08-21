using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CFGCheque : List<TRegistro_CFGCheque>
    { }

    
    public class TRegistro_CFGCheque
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_historico_desconto
        { get; set; }
        
        public string Ds_historico_desconto
        { get; set; }
        
        public string Cd_historico_taxa
        { get; set; }
        
        public string Ds_historico_taxa
        { get; set; }
        
        public string Cd_historico_creddesconto
        { get; set; }
        
        public string Ds_historico_creddesconto
        { get; set; }
        
        public string Cd_histdev_chemitidos
        { get; set; }
        
        public string Ds_histdev_chemitidos
        { get; set; }
        
        public string Cd_histreap_chemitidos
        { get; set; }
        
        public string Ds_histreap_chemitidos
        { get; set; }
        
        public string Cd_contadev_chemitidos
        { get; set; }
        
        public string Ds_contadev_chemitidos
        { get; set; }
        
        public string Cd_histdev_chrecebidos
        { get; set; }
        
        public string Ds_histdev_chrecebidos
        { get; set; }
        
        public string Cd_histreap_chrecebidos
        { get; set; }
        
        public string Ds_histreap_chrecebidos
        { get; set; }
        
        public string Cd_contadev_chrecebidos
        { get; set; }
        
        public string Ds_contadev_chrecebidos
        { get; set; }
        
        public TRegistro_CFGCheque()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_historico_desconto = string.Empty;
            this.Ds_historico_desconto = string.Empty;
            this.Cd_historico_taxa = string.Empty;
            this.Ds_historico_taxa = string.Empty;
            this.Cd_historico_creddesconto = string.Empty;
            this.Ds_historico_creddesconto = string.Empty;
            this.Cd_histdev_chemitidos = string.Empty;
            this.Ds_histdev_chemitidos = string.Empty;
            this.Cd_histreap_chemitidos = string.Empty;
            this.Ds_histreap_chemitidos = string.Empty;
            this.Cd_contadev_chemitidos = string.Empty;
            this.Ds_contadev_chemitidos = string.Empty;
            this.Cd_histdev_chrecebidos = string.Empty;
            this.Ds_histdev_chrecebidos = string.Empty;
            this.Cd_histreap_chrecebidos = string.Empty;
            this.Ds_histreap_chrecebidos = string.Empty;
            this.Cd_contadev_chrecebidos = string.Empty;
            this.Ds_contadev_chrecebidos = string.Empty;
        }
    }

    public class TCD_CFGCheque : TDataQuery
    {
        public TCD_CFGCheque()
        { }

        public TCD_CFGCheque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cd_historico_desconto, c.ds_historico as ds_historico_desconto, ");
                sql.AppendLine("a.cd_historico_taxa, d.ds_historico as ds_historico_taxa, ");
                sql.AppendLine("a.cd_historico_creddesconto, e.ds_historico as ds_historico_creddesconto, ");
                sql.AppendLine("a.cd_histdev_chemitidos, f.ds_historico as ds_histdev_chemitidos, ");
                sql.AppendLine("a.cd_histreap_chemitidos, g.ds_historico as ds_histreap_chemitidos, ");
                sql.AppendLine("a.cd_contadev_chemitidos, h.ds_contager as ds_contadev_chemitidos, ");
                sql.AppendLine("a.cd_histdev_chrecebidos, i.ds_historico as ds_histdev_chrecebidos, ");
                sql.AppendLine("a.cd_histreap_chrecebidos, j.ds_historico as ds_histreap_chrecebidos, ");
                sql.AppendLine("a.cd_contadev_chrecebidos, k.ds_contager as ds_contadev_chrecebidos ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cfgcheque a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fin_historico c ");
            sql.AppendLine("on a.cd_historico_desconto = c.cd_historico ");
            sql.AppendLine("inner join tb_fin_historico d ");
            sql.AppendLine("on a.cd_historico_taxa = d.cd_historico ");
            sql.AppendLine("inner join tb_fin_historico e ");
            sql.AppendLine("on a.cd_historico_creddesconto = e.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico f ");
            sql.AppendLine("on a.cd_histdev_chemitidos = f.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico g ");
            sql.AppendLine("on a.cd_histreap_chemitidos = g.cd_historico ");
            sql.AppendLine("left outer join tb_fin_contager h ");
            sql.AppendLine("on a.cd_contadev_chemitidos = h.cd_contager ");
            sql.AppendLine("left outer join tb_fin_historico i ");
            sql.AppendLine("on a.cd_histdev_chrecebidos = i.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico j ");
            sql.AppendLine("on a.cd_histreap_chrecebidos = j.cd_historico ");
            sql.AppendLine("left outer join tb_fin_contager k ");
            sql.AppendLine("on a.cd_contadev_chrecebidos = k.cd_contager ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
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

        public TList_CFGCheque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CFGCheque lista = new TList_CFGCheque();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGCheque reg = new TRegistro_CFGCheque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Desconto"))))
                        reg.Cd_historico_desconto = reader.GetString(reader.GetOrdinal("CD_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Desconto")))
                        reg.Ds_historico_desconto = reader.GetString(reader.GetOrdinal("DS_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Taxa")))
                        reg.Cd_historico_taxa = reader.GetString(reader.GetOrdinal("CD_Historico_Taxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_Taxa"))))
                        reg.Ds_historico_taxa = reader.GetString(reader.GetOrdinal("DS_Historico_Taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_CredDesconto")))
                        reg.Cd_historico_creddesconto = reader.GetString(reader.GetOrdinal("CD_Historico_CredDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_CredDesconto")))
                        reg.Ds_historico_creddesconto = reader.GetString(reader.GetOrdinal("DS_Historico_CredDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Histdev_chemitidos")))
                        reg.Cd_histdev_chemitidos = reader.GetString(reader.GetOrdinal("CD_Histdev_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Histdev_chemitidos")))
                        reg.Ds_histdev_chemitidos = reader.GetString(reader.GetOrdinal("DS_Histdev_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Histreap_chemitidos")))
                        reg.Cd_histreap_chemitidos = reader.GetString(reader.GetOrdinal("CD_Histreap_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Histreap_chemitidos")))
                        reg.Ds_histreap_chemitidos = reader.GetString(reader.GetOrdinal("DS_Histreap_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contadev_chemitidos")))
                        reg.Cd_contadev_chemitidos = reader.GetString(reader.GetOrdinal("CD_Contadev_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contadev_chemitidos")))
                        reg.Ds_contadev_chemitidos = reader.GetString(reader.GetOrdinal("DS_Contadev_chemitidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Histdev_chrecebidos")))
                        reg.Cd_histdev_chrecebidos = reader.GetString(reader.GetOrdinal("CD_Histdev_chrecebidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Histdev_chrecebidos")))
                        reg.Ds_histdev_chrecebidos = reader.GetString(reader.GetOrdinal("DS_Histdev_chrecebidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Histreap_chrecebidos")))
                        reg.Cd_histreap_chrecebidos = reader.GetString(reader.GetOrdinal("CD_Histreap_chrecebidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Histreap_chrecebidos")))
                        reg.Ds_histreap_chrecebidos = reader.GetString(reader.GetOrdinal("DS_Histreap_chrecebidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contadev_chrecebidos")))
                        reg.Cd_contadev_chrecebidos = reader.GetString(reader.GetOrdinal("CD_Contadev_chrecebidos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contadev_chrecebidos")))
                        reg.Ds_contadev_chrecebidos = reader.GetString(reader.GetOrdinal("DS_Contadev_chrecebidos"));

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

        public string GravarCFGCheque(TRegistro_CFGCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO_DESCONTO", val.Cd_historico_desconto);
            hs.Add("@P_CD_HISTORICO_TAXA", val.Cd_historico_taxa);
            hs.Add("@P_CD_HISTORICO_CREDDESCONTO", val.Cd_historico_creddesconto);
            hs.Add("@P_CD_HISTDEV_CHEMITIDOS", val.Cd_histdev_chemitidos);
            hs.Add("@P_CD_HISTREAP_CHEMITIDOS", val.Cd_histreap_chemitidos);
            hs.Add("@P_CD_CONTADEV_CHEMITIDOS", val.Cd_contadev_chemitidos);
            hs.Add("@P_CD_HISTDEV_CHRECEBIDOS", val.Cd_histdev_chrecebidos);
            hs.Add("@P_CD_HISTREAP_CHRECEBIDOS", val.Cd_histreap_chrecebidos);
            hs.Add("@P_CD_CONTADEV_CHRECEBIDOS", val.Cd_contadev_chrecebidos);

            return this.executarProc("IA_FIN_CFGCHEQUE", hs);
        }

        public string DeletarCFGCheque(TRegistro_CFGCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CFGCHEQUE", hs);
        }
    }
}
