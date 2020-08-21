using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Locacao.Cadastros
{
    #region CFG_Locacao
    public class TList_CFGLocacao : List<TRegistro_CFGLocacao>, IComparer<TRegistro_CFGLocacao>
    {
        #region IComparer<TRegistro_CFGLocacao> Members
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

        public TList_CFGLocacao()
        { }

        public TList_CFGLocacao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGLocacao x, TRegistro_CFGLocacao
 y)
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


    public class TRegistro_CFGLocacao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? tp_ordem;
        public decimal? Tp_ordem
        {
            get { return tp_ordem; }
            set
            {
                tp_ordem = value;
                tp_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_ordemstr;
        public string Tp_ordemstr
        {
            get { return tp_ordemstr; }
            set
            {
                tp_ordemstr = value;
                try
                {
                    tp_ordem = decimal.Parse(value);
                }
                catch
                { tp_ordem = null; }
            }
        }
        public string Ds_tipoordem
        { get; set; }
        public string Tp_duplicata
        { get; set; }

        public string Ds_tpduplicata
        { get; set; }

        private decimal? tp_docto;

        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;

        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }

        public string Ds_tpdocto
        { get; set; }

        public string Cd_historico
        { get; set; }

        public string Ds_historico
        { get; set; }

        public string Cfg_pedido_servico
        { get; set; }

        public string Ds_tipopedido_servico
        { get; set; }
        private decimal? id_configboleto;
        public decimal? Id_configboleto
        {
            get { return id_configboleto; }
            set
            {
                id_configboleto = value;
                id_configboletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configboletostr;
        public string Id_configboletostr
        {
            get { return id_configboletostr; }
            set
            {
                id_configboletostr = value;
                try
                {
                    id_configboleto = decimal.Parse(value);
                }
                catch { id_configboleto = null; }
            }
        }
        public string Ds_configboleto
        { get; set; }
        public string Cd_centroresultdia { get; set; }
        public string Ds_centroresultdia { get; set; }
        public string Cd_centroresultsem { get; set; }
        public string Ds_centroresultsem { get; set; }
        public string Cd_centroresultquinz { get; set; }
        public string Ds_centroresultquinz { get; set; }
        public string Cd_centroresultmes { get; set; }
        public string Ds_centroresultmes { get; set; }
        public string Tp_prodcombustivel { get; set; } = string.Empty;
        public string Ds_tpprodcombustivel { get; set; } = string.Empty;
        public decimal Nr_seqrecibo { get; set; } = decimal.Zero;
        public bool St_HoraAuto { get; set; }

        private decimal? tp_ordemp;
        public decimal? Tp_ordemp
        {
            get { return tp_ordemp; }
            set
            {
                tp_ordemp = value;
                tp_ordempstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_ordempstr;
        public string Tp_ordempstr
        {
            get { return tp_ordempstr; }
            set
            {
                tp_ordempstr = value;
                try
                {
                    tp_ordemp = decimal.Parse(value);
                }
                catch
                { tp_ordemp = null; }
            }
        }
        public string Ds_tipoordemP
        { get; set; }

        public TRegistro_CFGLocacao()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            tp_ordem = null;
            tp_ordemstr = string.Empty;
            Ds_tipoordem = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cfg_pedido_servico = string.Empty;
            Ds_tipopedido_servico = string.Empty;
            id_configboleto = null;
            id_configboletostr = string.Empty;
            Ds_configboleto = string.Empty;
            Cd_centroresultdia = string.Empty;
            Ds_centroresultdia = string.Empty;
            Cd_centroresultsem = string.Empty;
            Ds_centroresultsem = string.Empty;
            Cd_centroresultquinz = string.Empty;
            Ds_centroresultquinz = string.Empty;
            Cd_centroresultmes = string.Empty;
            Ds_centroresultmes = string.Empty;
            St_HoraAuto = false;
        }
    }

    public class TCD_CFGLocacao : TDataQuery
    {
        public TCD_CFGLocacao()
        { }

        public TCD_CFGLocacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, c.nm_empresa, a.TP_Ordem, b.DS_TipoOrdem, a.Nr_SeqRecibo, ");
                sql.AppendLine("a.tp_duplicata, tpdup.ds_tpduplicata, a.tp_docto, d.ds_tpdocto, a.cd_historico, e.ds_historico, ");
                sql.AppendLine("a.cfg_pedido_servico, f.ds_tipopedido as ds_tipopedido_servico, a.id_config, cg.ds_config, ");
                sql.AppendLine("a.cd_centroresultdia, Space((i.Nivel - 1)*5) + i.DS_CentroResultado as ds_centroresultdia, ");
                sql.AppendLine("a.cd_centroresultsem, Space((j.Nivel - 1)*5) + j.DS_CentroResultado as ds_centroresultsem, ");
                sql.AppendLine("a.cd_centroresultquinz, Space((k.Nivel - 1)*5) + k.DS_CentroResultado as ds_centroresultquinz, ");
                sql.AppendLine("a.cd_centroresultmes, Space((l.Nivel - 1)*5) + l.DS_CentroResultado as ds_centroresultmes, ");
                sql.AppendLine("a.Tp_ProdCombustivel, m.Ds_TpProduto, a.st_horaauto, a.TP_OrdemP, n.DS_TipoOrdem as DS_TipoOrdemP ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_loc_cfglocacao a ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("left outer join TB_OSE_TpOrdem b ");
            sql.AppendLine("on a.TP_Ordem = b.TP_Ordem ");
            sql.AppendLine("left outer join tb_fin_tpduplicata tpdup ");
            sql.AppendLine("on a.tp_duplicata = tpdup.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup d ");
            sql.AppendLine("on a.tp_docto = d.tp_docto ");
            sql.AppendLine("left outer join tb_fin_historico e ");
            sql.AppendLine("on a.cd_historico = e.cd_historico ");
            sql.AppendLine("left outer join tb_fat_cfgpedido f ");
            sql.AppendLine("on a.cfg_pedido_servico = f.cfg_pedido ");
            sql.AppendLine("left outer join TB_Cob_CfgBanco cg ");
            sql.AppendLine("On cg.ID_Config = a.ID_Config ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado i ");
            sql.AppendLine("on a.CD_CentroResultDia = i.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado j ");
            sql.AppendLine("on a.CD_CentroResultSem = j.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado k ");
            sql.AppendLine("on a.Cd_CentroResultQuinz = k.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado l ");
            sql.AppendLine("on a.Cd_CentroResultMes = l.CD_CentroResult ");
            sql.AppendLine("left outer join TB_EST_TpProduto m ");
            sql.AppendLine("on a.TP_ProdCombustivel = m.TP_Produto ");
            sql.AppendLine("left outer join TB_OSE_TpOrdem n ");
            sql.AppendLine("on a.TP_OrdemP = n.TP_Ordem ");
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

        public TList_CFGLocacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CFGLocacao lista = new TList_CFGLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGLocacao reg = new TRegistro_CFGLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("TP_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoOrdem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("DS_TipoOrdem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_servico")))
                        reg.Cfg_pedido_servico = reader.GetString(reader.GetOrdinal("cfg_pedido_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_servico")))
                        reg.Ds_tipopedido_servico = reader.GetString(reader.GetOrdinal("ds_tipopedido_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_configboleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_configboleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultdia")))
                        reg.Cd_centroresultdia = reader.GetString(reader.GetOrdinal("cd_centroresultdia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultdia")))
                        reg.Ds_centroresultdia = reader.GetString(reader.GetOrdinal("ds_centroresultdia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultsem")))
                        reg.Cd_centroresultsem = reader.GetString(reader.GetOrdinal("cd_centroresultsem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultsem")))
                        reg.Ds_centroresultsem = reader.GetString(reader.GetOrdinal("ds_centroresultsem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultquinz")))
                        reg.Cd_centroresultquinz = reader.GetString(reader.GetOrdinal("cd_centroresultquinz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultquinz")))
                        reg.Ds_centroresultquinz = reader.GetString(reader.GetOrdinal("ds_centroresultquinz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultmes")))
                        reg.Cd_centroresultmes = reader.GetString(reader.GetOrdinal("cd_centroresultmes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultmes")))
                        reg.Ds_centroresultmes = reader.GetString(reader.GetOrdinal("ds_centroresultmes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_ProdCombustivel")))
                        reg.Tp_prodcombustivel = reader.GetString(reader.GetOrdinal("Tp_ProdCombustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_TpProduto")))
                        reg.Ds_tpprodcombustivel = reader.GetString(reader.GetOrdinal("Ds_TpProduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_SeqRecibo")))
                        reg.Nr_seqrecibo = reader.GetDecimal(reader.GetOrdinal("Nr_SeqRecibo"));

                    if (!reader.IsDBNull(reader.GetOrdinal("st_horaauto")))
                        reg.St_HoraAuto = reader.GetBoolean(reader.GetOrdinal("st_horaauto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("TP_OrdemP")))
                        reg.Tp_ordemp = reader.GetDecimal(reader.GetOrdinal("TP_OrdemP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoOrdemP")))
                        reg.Ds_tipoordemP = reader.GetString(reader.GetOrdinal("DS_TipoOrdemP"));


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

        public string Gravar(TRegistro_CFGLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CFG_PEDIDO_SERVICO", val.Cfg_pedido_servico);
            hs.Add("@P_ID_CONFIG", val.Id_configboleto);
            hs.Add("@P_CD_CENTRORESULTDIA", val.Cd_centroresultdia);
            hs.Add("@P_CD_CENTRORESULTSEM", val.Cd_centroresultsem);
            hs.Add("@P_CD_CENTRORESULTQUINZ", val.Cd_centroresultquinz);
            hs.Add("@P_CD_CENTRORESULTMES", val.Cd_centroresultmes);
            hs.Add("@P_TP_PRODCOMBUSTIVEL", val.Tp_prodcombustivel);
            hs.Add("@P_NR_SEQRECIBO", val.Nr_seqrecibo);
            hs.Add("@P_ST_HORAAUTO", val.St_HoraAuto);

            hs.Add("@P_TP_ORDEMP", val.Tp_ordemp);
            
            return executarProc("IA_LOC_CFGLOCACAO", hs);
        }

        public string Excluir(TRegistro_CFGLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_LOC_CFGLOCACAO", hs);
        }
    }

    #endregion
}
