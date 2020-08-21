using System;
using System.Collections.Generic;
using System.Text;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_OSE_ParamOS : List<TRegistro_OSE_ParamOS>
    { }
    
    public class TRegistro_OSE_ParamOS
    {
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
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }
        
        public string Cfg_pedido_item
        { get; set; }
        
        public string Ds_tipopedido_item
        { get; set; }
        
        public string Cfg_pedido_servico
        { get; set; }
        
        public string Ds_tipopedido_servico
        { get; set; }
        
        public string Cfg_pedido_garantia
        { get; set; }
        
        public string Ds_tipopedido_garantia
        { get; set; }
        
        public string Cfg_pedido_transpremessa
        { get; set; }
        
        public string Ds_tipopedido_transpremessa
        { get; set; }
        
        public string Cfg_pedido_transpremessaenvio
        { get; set; }
        
        public string Ds_tipopedido_transpremessaenvio
        { get; set; }
        private string st_gerarpedidoservicoseparado;
        
        public string St_gerarpedidoservicoseparado
        {
            get { return st_gerarpedidoservicoseparado; }
            set
            {
                st_gerarpedidoservicoseparado = value;
                st_gerarpedidoservicoseparadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarpedidoservicoseparadobool;
        
        public bool St_gerarpedidoservicoseparadobool
        {
            get { return st_gerarpedidoservicoseparadobool; }
            set
            {
                st_gerarpedidoservicoseparadobool = value;
                if (value)
                    st_gerarpedidoservicoseparado = "S";
                else
                    st_gerarpedidoservicoseparado = "N";
            }
        }
        private string st_sequenciamanual;
        
        public string St_sequenciamanual
        {
            get { return st_sequenciamanual; }
            set
            {
                st_sequenciamanual = value;
                st_sequenciamanualbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sequenciamanualbool;
        
        public bool St_sequenciamanualbool
        {
            get { return st_sequenciamanualbool; }
            set
            {
                st_sequenciamanualbool = value;
                if (value)
                    st_sequenciamanual = "S";
                else
                    st_sequenciamanual = "N";
            }
        }
        
        public decimal? Nr_os
        { get; set; }
        
        public decimal Vl_minimopedido
        { get; set; }
        
        public string Cd_produtofrete
        { get; set; }
        
        public string Ds_produtofrete
        { get; set; }
        
        public string Cd_transportadora
        { get; set; }
        
        public string Nm_transportadora
        { get; set; }
        
        public string Cd_enderecoTransp
        { get; set; }
        
        public string Ds_enderecoTransp
        { get; set; }
        
        public decimal Dias_garantia
        { get; set; }
        
        public string Ds_termogarantia
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
        
        public string Cd_servicopadrao
        { get; set; }
        
        public string Ds_servicopadrao
        { get; set; }
        
        public string Cd_tabelapreco
        { get; set; }
        
        public string Ds_tabelapreco
        { get; set; }
        
        public decimal Dias_retirar
        { get; set; }
        private string st_sum_d_a_unit;
        public string St_sum_d_a_unit
        {
            get { return st_sum_d_a_unit; }
            set
            {
                st_sum_d_a_unit = value;
                st_sum_d_a_unitbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sum_d_a_unitbool;
        public bool St_sum_d_a_unitbool
        {
            get { return st_sum_d_a_unitbool; }
            set
            {
                st_sum_d_a_unitbool = value;
                st_sum_d_a_unit = value ? "S" : "N";
            }
        }
        private string st_acrescbasedesc;
        public string St_acrescbasedesc
        {
            get { return st_acrescbasedesc; }
            set
            {
                st_acrescbasedesc = value;
                st_acrescbasedescbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_acrescbasedescbool;
        public bool St_acrescbasedescbool
        {
            get { return st_acrescbasedescbool; }
            set
            {
                st_acrescbasedescbool = value;
                st_acrescbasedesc = value ? "S" : "N";
            }
        }

        public TRegistro_OSE_ParamOS()
        {
            tp_ordem = null;
            tp_ordemstr = string.Empty;
            Ds_tipoordem = string.Empty;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Cfg_pedido_item = string.Empty;
            Ds_tipopedido_item = string.Empty;
            Cfg_pedido_servico = string.Empty;
            Ds_tipopedido_servico = string.Empty;
            Cfg_pedido_garantia = string.Empty;
            Ds_tipopedido_garantia = string.Empty;
            Cfg_pedido_transpremessa = string.Empty;
            Ds_tipopedido_transpremessa = string.Empty;
            Cfg_pedido_transpremessaenvio = string.Empty;
            Ds_tipopedido_transpremessaenvio = string.Empty;
            st_gerarpedidoservicoseparado = "N";
            st_gerarpedidoservicoseparadobool = false;
            st_sequenciamanual = "N";
            st_sequenciamanualbool = false;
            Nr_os = null;
            Vl_minimopedido = decimal.Zero;
            Cd_produtofrete = string.Empty;
            Ds_produtofrete = string.Empty;
            Cd_transportadora = string.Empty;
            Nm_transportadora = string.Empty;
            Cd_enderecoTransp = string.Empty;
            Ds_enderecoTransp = string.Empty;
            Dias_garantia = decimal.Zero;
            Ds_termogarantia = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_servicopadrao = string.Empty;
            Ds_servicopadrao = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Dias_retirar = decimal.Zero;
            st_sum_d_a_unit = "N";
            st_sum_d_a_unitbool = false;
            st_acrescbasedesc = "N";
            st_acrescbasedescbool = false;
        }
    }

    public class TCD_OSE_ParamOS : TDataQuery
    {
        public TCD_OSE_ParamOS()
        { }

        public TCD_OSE_ParamOS(TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.tp_ordem, b.ds_tipoordem, a.st_gerarpedidoservicoseparado, ");
                sql.AppendLine("a.cd_moeda, c.ds_moeda_singular, c.sigla, a.dias_garantia, a.ds_termogarantia, ");
                sql.AppendLine("a.cfg_pedido_item, d.ds_tipopedido as ds_tipopedido_item, ");
                sql.AppendLine("a.cfg_pedido_servico, e.ds_tipopedido as ds_tipopedido_servico, ");
                sql.AppendLine("a.cfg_pedido_garantia, f.ds_tipopedido as ds_tipopedido_garantia, ");
                sql.AppendLine("a.cfg_pedido_transpremessa, h.ds_tipopedido as ds_tipopedido_transpremessa, ");
                sql.AppendLine("a.cfg_pedido_transpremessaenvio, i.ds_tipopedido as ds_tipopedido_transpremessaenvio, ");
                sql.AppendLine("a.st_sequenciamanual, a.nr_os, a.vl_minimopedido, a.cd_produtofrete, j.ds_produto as ds_produtofrete, ");
                sql.AppendLine("a.cd_transportadora, l.nm_clifor as nm_transportadora, ");
                sql.AppendLine("a.cd_enderecotransp, m.ds_endereco as ds_enderecotransp, ");
                sql.AppendLine("a.tp_duplicata, n.ds_tpduplicata, a.tp_docto, o.ds_tpdocto, a.cd_historico, p.ds_historico, ");
                sql.AppendLine("a.cd_servicopadrao, q.ds_produto as ds_servicopadrao, ");
                sql.AppendLine("a.cd_tabelapreco, r.ds_tabelapreco, a.dias_retirar, a.st_sum_d_a_unit, a.st_acrescbasedesc ");
            }
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ose_paramos a ");
            sql.AppendLine("inner join tb_ose_tpordem b ");
            sql.AppendLine("on a.tp_ordem = b.tp_ordem ");
            sql.AppendLine("left outer join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moeda = c.cd_moeda ");
            sql.AppendLine("left outer join tb_fat_cfgpedido d ");
            sql.AppendLine("on a.cfg_pedido_item = d.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido e ");
            sql.AppendLine("on a.cfg_pedido_servico = e.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido f ");
            sql.AppendLine("on a.cfg_pedido_garantia = f.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido h ");
            sql.AppendLine("on a.cfg_pedido_transpremessa = h.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido i ");
            sql.AppendLine("on a.cfg_pedido_transpremessaenvio = i.cfg_pedido ");
            sql.AppendLine("left outer join tb_est_produto j ");
            sql.AppendLine("on a.cd_produtofrete = j.cd_produto ");
            sql.AppendLine("left outer join vtb_fin_clifor l ");
            sql.AppendLine("on a.cd_transportadora = l.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco m ");
            sql.AppendLine("on a.cd_transportadora = m.cd_clifor ");
            sql.AppendLine("and a.cd_enderecotransp = m.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_tpduplicata n ");
            sql.AppendLine("on a.tp_duplicata = n.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup o ");
            sql.AppendLine("on a.tp_docto = o.tp_docto ");
            sql.AppendLine("left outer join tb_fin_historico p ");
            sql.AppendLine("on a.cd_historico = p.cd_historico ");
            sql.AppendLine("left outer join tb_est_produto q ");
            sql.AppendLine("on a.cd_servicopadrao = q.cd_produto ");
            sql.AppendLine("left outer join tb_div_tabelapreco r ");
            sql.AppendLine("on a.cd_tabelapreco = r.cd_tabelapreco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OSE_ParamOS Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OSE_ParamOS lista = new TList_OSE_ParamOS();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_OSE_ParamOS reg = new TRegistro_OSE_ParamOS();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("tp_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoordem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_tipoordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("cd_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moeda_singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_item")))
                        reg.Cfg_pedido_item = reader.GetString(reader.GetOrdinal("cfg_pedido_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_item")))
                        reg.Ds_tipopedido_item = reader.GetString(reader.GetOrdinal("ds_tipopedido_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_servico")))
                        reg.Cfg_pedido_servico = reader.GetString(reader.GetOrdinal("cfg_pedido_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_servico")))
                        reg.Ds_tipopedido_servico = reader.GetString(reader.GetOrdinal("ds_tipopedido_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_garantia")))
                        reg.Cfg_pedido_garantia = reader.GetString(reader.GetOrdinal("cfg_pedido_garantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_garantia")))
                        reg.Ds_tipopedido_garantia = reader.GetString(reader.GetOrdinal("ds_tipopedido_garantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_transpremessa")))
                        reg.Cfg_pedido_transpremessa = reader.GetString(reader.GetOrdinal("cfg_pedido_transpremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_transpremessa")))
                        reg.Ds_tipopedido_transpremessa = reader.GetString(reader.GetOrdinal("ds_tipopedido_transpremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido_transpremessaenvio")))
                        reg.Cfg_pedido_transpremessaenvio = reader.GetString(reader.GetOrdinal("cfg_pedido_transpremessaenvio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido_transpremessaenvio")))
                        reg.Ds_tipopedido_transpremessaenvio = reader.GetString(reader.GetOrdinal("ds_tipopedido_transpremessaenvio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarpedidoservicoseparado")))
                        reg.St_gerarpedidoservicoseparado = reader.GetString(reader.GetOrdinal("st_gerarpedidoservicoseparado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SequenciaManual")))
                        reg.St_sequenciamanual = reader.GetString(reader.GetOrdinal("ST_SequenciaManual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_OS")))
                        reg.Nr_os = reader.GetDecimal(reader.GetOrdinal("NR_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_MinimoPedido")))
                        reg.Vl_minimopedido = reader.GetDecimal(reader.GetOrdinal("Vl_MinimoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ProdutoFrete")))
                        reg.Cd_produtofrete = reader.GetString(reader.GetOrdinal("CD_ProdutoFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ProdutoFrete")))
                        reg.Ds_produtofrete = reader.GetString(reader.GetOrdinal("DS_ProdutoFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EnderecoTransp")))
                        reg.Cd_enderecoTransp = reader.GetString(reader.GetOrdinal("CD_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EnderecoTransp")))
                        reg.Ds_enderecoTransp = reader.GetString(reader.GetOrdinal("DS_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dias_garantia")))
                        reg.Dias_garantia = reader.GetDecimal(reader.GetOrdinal("dias_garantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_termogarantia")))
                        reg.Ds_termogarantia = reader.GetString(reader.GetOrdinal("ds_termogarantia"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_servicopadrao")))
                        reg.Cd_servicopadrao = reader.GetString(reader.GetOrdinal("cd_servicopadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servicopadrao")))
                        reg.Ds_servicopadrao = reader.GetString(reader.GetOrdinal("ds_servicopadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dias_retirar")))
                        reg.Dias_retirar = reader.GetDecimal(reader.GetOrdinal("dias_retirar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_sum_d_a_unit")))
                        reg.St_sum_d_a_unit = reader.GetString(reader.GetOrdinal("st_sum_d_a_unit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_acrescbasedesc")))
                        reg.St_acrescbasedesc = reader.GetString(reader.GetOrdinal("st_acrescbasedesc"));

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

        public string Gravar(TRegistro_OSE_ParamOS val)
        {
            Hashtable hs = new Hashtable(24);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_ST_GERARPEDIDOSERVICOSEPARADO", val.St_gerarpedidoservicoseparado);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CFG_PEDIDO_ITEM", val.Cfg_pedido_item);
            hs.Add("@P_CFG_PEDIDO_SERVICO", val.Cfg_pedido_servico);
            hs.Add("@P_CFG_PEDIDO_GARANTIA", val.Cfg_pedido_garantia);
            hs.Add("@P_CFG_PEDIDO_TRANSPREMESSA", val.Cfg_pedido_transpremessa);
            hs.Add("@P_CFG_PEDIDO_TRANSPREMESSAENVIO", val.Cfg_pedido_transpremessaenvio);
            hs.Add("@P_ST_SEQUENCIAMANUAL", val.St_sequenciamanual);
            hs.Add("@P_NR_OS", val.Nr_os);
            hs.Add("@P_VL_MINIMOPEDIDO", val.Vl_minimopedido);
            hs.Add("@P_CD_PRODUTOFRETE", val.Cd_produtofrete);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_CD_ENDERECOTRANSP", val.Cd_enderecoTransp);
            hs.Add("@P_DIAS_GARANTIA", val.Dias_garantia);
            hs.Add("@P_DS_TERMOGARANTIA", val.Ds_termogarantia);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_SERVICOPADRAO", val.Cd_servicopadrao);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_DIAS_RETIRAR", val.Dias_retirar);
            hs.Add("@P_ST_SUM_D_A_UNIT", val.St_sum_d_a_unit);
            hs.Add("@P_ST_ACRESCBASEDESC", val.St_acrescbasedesc);

            return executarProc("IA_OSE_PARAMOS", hs);

        }

        public string Excluir(TRegistro_OSE_ParamOS val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);

            return executarProc("EXCLUI_OSE_PARAMOS", hs);
        }
    }
}
