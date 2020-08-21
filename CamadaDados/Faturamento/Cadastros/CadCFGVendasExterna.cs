using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CFGVendasExterna : List<TRegistro_CFGVendasExterna> { }
    public class TRegistro_CFGVendasExterna
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string Cd_uf_empresa { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Licenca { get; set; } = string.Empty;
        public string Integracao { get; set; } = string.Empty;
        public string Tp_duplicata { get; set; } = string.Empty;
        public string Ds_tpduplicata { get; set; } = string.Empty;
        private decimal? tp_docto = null;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr = string.Empty;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }catch { tp_docto = null; }
            }
        }
        public string Ds_tpdocto { get; set; } = string.Empty;
        public string Cd_condpgto { get; set; } = string.Empty;
        public string Ds_condpgto { get; set; } = string.Empty;
        public string Cd_historico { get; set; } = string.Empty;
        public string Ds_historico { get; set; } = string.Empty;
        private decimal? id_config = null;

        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr = string.Empty;

        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }catch { id_config = null; }
            }
        }
        public string Ds_config { get; set; } = string.Empty;
        public string Cfg_pedido { get; set; } = string.Empty;
        public string Ds_tipopedido { get; set; } = string.Empty;
    }
    public class TCD_CFGVendasExterna:TDataQuery
    {
        public TCD_CFGVendasExterna() { }
        public TCD_CFGVendasExterna(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("c.cd_uf, a.Login, a.Senha, a.Licenca, a.Integracao, ");
                sql.AppendLine("a.tp_duplicata, d.ds_tpduplicata, a.tp_docto, e.ds_tpdocto, ");
                sql.AppendLine("a.cd_condpgto, f.ds_condpgto, a.cd_historico, g.ds_historico, ");
                sql.AppendLine("a.id_config, h.ds_config, a.cfg_pedido, i.ds_tipopedido  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from tb_fat_cfgvendasexterna a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_endereco c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = c.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_tpduplicata d ");
            sql.AppendLine("on a.tp_duplicata = d.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup e ");
            sql.AppendLine("on a.tp_docto = e.tp_docto ");
            sql.AppendLine("left outer join tb_fin_condpgto f ");
            sql.AppendLine("on a.cd_condpgto = f.cd_condpgto ");
            sql.AppendLine("left outer join tb_fin_historico g ");
            sql.AppendLine("on a.cd_historico = g.cd_historico ");
            sql.AppendLine("left outer join tb_cob_cfgbanco h ");
            sql.AppendLine("on a.id_config = h.id_config ");
            sql.AppendLine("left outer join tb_fat_cfgpedido i ");
            sql.AppendLine("on a.cfg_pedido = i.cfg_pedido ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CFGVendasExterna Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_CFGVendasExterna lista = new TList_CFGVendasExterna();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGVendasExterna reg = new TRegistro_CFGVendasExterna();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                        reg.Senha = reader.GetString(reader.GetOrdinal("Senha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Licenca")))
                        reg.Licenca = reader.GetString(reader.GetOrdinal("Licenca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Integracao")))
                        reg.Integracao = reader.GetString(reader.GetOrdinal("Integracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("TP_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));

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

        public string Gravar(TRegistro_CFGVendasExterna val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_SENHA", val.Senha);
            hs.Add("@P_LICENCA", val.Licenca);
            hs.Add("@P_INTEGRACAO", val.Integracao);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);

            return executarProc("IA_FAT_CFGVENDASEXTERNA", hs);
        }

        public string Excluir(TRegistro_CFGVendasExterna val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FAT_CFGVENDASEXTERNA", hs);
        }
    }
}
