using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BancoDados;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TRegistro_CadCFGEmpreendimento
    {
        public string cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string cfg_remessa { get; set; } = string.Empty;
        public string Ds_cfgremessa { get; set; } = string.Empty;
        public string cfg_servico { get; set; } = string.Empty;
        public string Ds_cfgservico { get; set; } = string.Empty;
        public string Cd_tabelapreco { get; set; } = string.Empty;
        public string cd_servico { get; set; } = string.Empty;
        public string Ds_tabelapreco { get; set; } = string.Empty;
        public decimal Pc_IRPJ { get; set; } = decimal.Zero;
        public decimal Pc_CSLL { get; set; } = decimal.Zero;
        public decimal Pc_PIS { get; set; } = decimal.Zero;
        public decimal Pc_Cofins { get; set; } = decimal.Zero;
        public decimal Pc_margemcont { get; set; } = decimal.Zero;
        public string cd_unimes { get; set; } = string.Empty;
        public string ds_unimes { get; set; } = string.Empty;
        public string cd_local { get; set; } = string.Empty;
        public string ds_local { get; set; } = string.Empty;
        public string tp_docto { get; set; } = string.Empty;
        public string ds_docto { get; set; } = string.Empty;
        public string ds_produto { get; set; } = string.Empty;
        public string tp_dup { get; set; } = string.Empty;
        public string ds_dup { get; set; } = string.Empty;
        public string tp_mov { get; set; } = string.Empty;
        public string tp_requisicao { get; set; } = string.Empty;
        public string ds_tp_requisicao { get; set; } = string.Empty;
        public string tp_requisicaodir { get; set; } = string.Empty;
        public string ds_tp_requisicaodir { get; set; } = string.Empty;
        public decimal QT_MINREQUISITO { get; set; } = decimal.Zero;
        public string tp_precoitem { get; set; } = string.Empty;
        public string tipo_precoitem
        {
            get
            {
                if (tp_precoitem.Equals("0"))
                    return "Custo Medio";
                else if (tp_precoitem.Equals("1"))
                    return "Tabela Preco";
                else
                    return string.Empty;
            }
            set
            {
                if (value.Equals("Tabela Preco"))
                    tp_precoitem = "1";
                else if (value.Equals("Custo Medio"))
                    tp_precoitem = "0";
                else
                    tp_precoitem = null;
            }
        }
        public int? ValidadePropostaDias { get; set; } = null;

    }

    public class TList_CadCFGEmpreendimento : List<TRegistro_CadCFGEmpreendimento>
    { }

    public class TCD_CadCFGEmpreendimento : TDataQuery
    {
        public TCD_CadCFGEmpreendimento()
        { }

        public TCD_CadCFGEmpreendimento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " J.DS_PRODUTO, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cfg_remessa,a.cd_servico, c.ds_tipopedido as ds_cfgremessa, ");
                sql.AppendLine("a.cfg_servico, d.ds_tipopedido as ds_cfgservico, ");
                sql.AppendLine("a.cd_tabelapreco, tp.ds_tabelapreco, ");
                sql.AppendLine("a.tp_docto, i.ds_tpdocto, ");
                sql.AppendLine("a.tp_duplicata, g.ds_tpduplicata, g.tp_mov, ");
                sql.AppendLine("a.ID_TpRequisicao, a.ID_TpRequisicaoDireta, a.tp_precoitem,");
                sql.AppendLine("a.pc_irpj, a.pc_csll, a.pc_pis, a.pc_cofins, a.pc_margemcont,a.CD_UnidMes, a.QT_MINREQUISITO ,e.sigla_unidade, a.cd_local, f.ds_local, ");
                sql.AppendLine("a.ValidadePropostaDias ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_CFGEmpreendimento a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left join tb_div_tabelapreco tp ");
            sql.AppendLine("on a.cd_tabelapreco = tp.cd_tabelapreco ");
            sql.AppendLine("left outer join tb_fat_cfgpedido c ");
            sql.AppendLine("on a.cfg_remessa = c.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido d ");
            sql.AppendLine("on a.cfg_servico = d.cfg_pedido ");
            sql.AppendLine("left  join tb_est_unidade e ");
            sql.AppendLine("on a.cd_unidmes = e.cd_unidade");
            sql.AppendLine("left  join TB_EST_LocalArm f ");
            sql.AppendLine("on a.cd_local = f.cd_local");
            sql.AppendLine("left join TB_FIN_TPDuplicata g ");
            sql.AppendLine("on g.tp_duplicata = a.tp_duplicata ");
            sql.AppendLine("left join TB_FIN_TPDocto_Dup i");
            sql.AppendLine("on i.tp_docto = a.tp_docto");
            sql.AppendLine("left join TB_EST_PRODUTO J");
            sql.AppendLine("on J.CD_PRODUTO = a.CD_SERVICO");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_CadCFGEmpreendimento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCFGEmpreendimento lista = new TList_CadCFGEmpreendimento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadCFGEmpreendimento reg = new TRegistro_CadCFGEmpreendimento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_servico")))
                        reg.cfg_servico = reader.GetString(reader.GetOrdinal("cfg_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfgservico")))
                        reg.Ds_cfgservico = reader.GetString(reader.GetOrdinal("ds_cfgservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_remessa")))
                        reg.cfg_remessa = reader.GetString(reader.GetOrdinal("cfg_remessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_servico")))
                        reg.cd_servico = reader.GetString(reader.GetOrdinal("cd_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfgremessa")))
                        reg.Ds_cfgremessa = reader.GetString(reader.GetOrdinal("ds_cfgremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_irpj")))
                        reg.Pc_IRPJ = reader.GetDecimal(reader.GetOrdinal("pc_irpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_csll")))
                        reg.Pc_CSLL = reader.GetDecimal(reader.GetOrdinal("pc_csll"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_pis")))
                        reg.Pc_PIS = reader.GetDecimal(reader.GetOrdinal("pc_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_cofins")))
                        reg.Pc_Cofins = reader.GetDecimal(reader.GetOrdinal("pc_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_margemcont")))
                        reg.Pc_margemcont = reader.GetDecimal(reader.GetOrdinal("pc_margemcont"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidMes")))
                        reg.cd_unimes = reader.GetString(reader.GetOrdinal("CD_UnidMes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.ds_unimes = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.tp_dup = reader.GetString(reader.GetOrdinal("tp_duplicata")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.ds_dup = reader.GetString(reader.GetOrdinal("ds_tpduplicata")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_mov")))
                        reg.tp_mov = reader.GetString(reader.GetOrdinal("tp_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.ds_docto = reader.GetString(reader.GetOrdinal("ds_tpdocto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PRODUTO")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("DS_PRODUTO")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_MINREQUISITO")))
                        reg.QT_MINREQUISITO = reader.GetDecimal(reader.GetOrdinal("QT_MINREQUISITO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpRequisicaoDireta")))
                        reg.tp_requisicaodir = reader.GetDecimal(reader.GetOrdinal("ID_TpRequisicaoDireta")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpRequisicao")))
                        reg.tp_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_TpRequisicao")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_precoitem")))
                        reg.tp_precoitem = reader.GetString(reader.GetOrdinal("tp_precoitem"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ValidadePropostaDias")))
                        reg.ValidadePropostaDias = reader.GetInt32(reader.GetOrdinal("ValidadePropostaDias"));


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

        public string Grava(TRegistro_CadCFGEmpreendimento vRegistro)
        {
            Hashtable hs = new Hashtable(19);
            hs.Add("@P_CD_EMPRESA", vRegistro.cd_empresa);
            hs.Add("@P_CFG_REMESSA", vRegistro.cfg_remessa);
            hs.Add("@P_CFG_SERVICO", vRegistro.cfg_servico);
            hs.Add("@P_CD_TABELAPRECO", vRegistro.Cd_tabelapreco);
            hs.Add("@P_PC_IRPJ", vRegistro.Pc_IRPJ);
            hs.Add("@P_PC_CSLL", vRegistro.Pc_CSLL);
            hs.Add("@P_TP_DOCTO", vRegistro.tp_docto);
            hs.Add("@P_TP_DUPLICATA", vRegistro.tp_dup);
            hs.Add("@P_PC_PIS", vRegistro.Pc_PIS);
            hs.Add("@P_PC_COFINS", vRegistro.Pc_Cofins);
            hs.Add("@P_CD_SERVICO", vRegistro.cd_servico);
            hs.Add("@P_PC_MARGEMCONT", vRegistro.Pc_margemcont);
            hs.Add("@P_CD_UNIDMES", vRegistro.cd_unimes);
            hs.Add("@P_CD_LOCAL", vRegistro.cd_local);
            hs.Add("@P_QT_MINREQUISITO", vRegistro.QT_MINREQUISITO);
            hs.Add("@P_ID_TPREQUISICAO", vRegistro.tp_requisicao);
            hs.Add("@P_ID_TPREQUISICAODIRETA", vRegistro.tp_requisicaodir);
            hs.Add("@P_TP_PRECOITEM", vRegistro.tp_precoitem);
            hs.Add("@P_VALIDADEPROPOSTADIAS", vRegistro.ValidadePropostaDias);

            return executarProc("IA_EMP_CFGEMPREENDIMENTO", hs);
        }

        public string Deleta(TRegistro_CadCFGEmpreendimento vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", vRegistro.cd_empresa);

            return executarProc("EXCLUI_EMP_CFGEMPREENDIMENTO", hs);
        }
    }
}
