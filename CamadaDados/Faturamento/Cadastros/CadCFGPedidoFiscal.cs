using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadCFGPedidoFiscal : List<TRegistro_CadCFGPedidoFiscal>
    { }
    
    public class TRegistro_CadCFGPedidoFiscal
    {
        public string Cfg_pedido { get;set; }
        public string Ds_tipopedido{ get; set; }
        public string Tp_movimento{ get; set; }
        public bool St_servico { get; set; }
        public string Tp_fiscal { get; set; }
        public string Tipo_fiscal
        {
            get
            {
                switch (Tp_fiscal.Trim().ToUpper())
                {
                    case "NO":
                            return "LANÇAMENTO NORMAL";
                    case "CP":
                            return "LANÇAMENTO DE COMPLEMENTO";
                    case "DV":
                            return "LANÇAMENTO DE DEVOLUÇÃO/RETORNO";
                    case "FT":
                            return "LANÇAMENTO DE ENTREGA FUTURA";
                    case "TF":
                            return "TRANSFERENCIA ENTRE CONTRATOS";
                    case "DF":
                            return "DEVOLUÇÃO FISCAL";
                    case "CF":
                            return "COMPLEMENTO FISCAL";
                    case "SE":
                            return "LANÇAMENTO SERVIÇO";
                    case "RT": 
                            return "REMESSA TRANSPORTE";
                    default:
                            return string.Empty;
                }
            }
        }
        public string Nr_serie { get; set; }
        public string Ds_serienf { get; set; }
        public string Tp_serie { get; set; }
        public string Cd_modelo { get; set; }
        public string Ds_modelo { get; set; }
        private decimal? cd_cmi;
        public decimal? Cd_cmi
        {
            get { return cd_cmi; }
            set 
            { 
                cd_cmi = value;
                cd_cmistring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_cmistring;
        public string Cd_cmistring
        {
            get { return cd_cmistring; }
            set 
            { 
                cd_cmistring = value;
                try
                {
                    cd_cmi = Convert.ToDecimal(value);
                }
                catch { cd_cmi = null; }
            }
        }
        public string Ds_cmi  { get; set; }
        private decimal? cd_movto;
        public decimal? Cd_movto
        {
            get { return cd_movto; }
            set 
            { 
                cd_movto = value;
                cd_movtostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_movtostring;
        public string Cd_movtostring
        {
            get { return cd_movtostring; }
            set 
            { 
                cd_movtostring = value;
                try
                {
                    cd_movto = Convert.ToDecimal(value);
                }
                catch { cd_movto = null; }
            }
        }
        public string Ds_movimentacao{ get; set; }
        public string Cd_historicoMov
        { get; set; }
        public string Ds_historicoMov
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = (value.HasValue ? value.Value.ToString() : string.Empty);
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
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        public string CD_CondPgto
        { get; set; }
        public string ST_SequenciaAuto
        { get; set; }
        public string ST_Devolucao
        { get; set;}
        public string ST_Retorno
        { get; set; }
        public string ST_Complementar
        { get; set;}
        public string St_geraestoque
        { get; set; }
        public string ST_Mestra
        { get; set;}
        public string ST_SimplesRemessa
        { get; set; }
        public bool St_commoditties
        { get; set; }
        public bool St_valoresfixos
        { get; set; }
        public bool St_deposito
        { get; set; }
        public bool St_vincularcf
        { get; set; }
        public bool St_gerarfin
        { get; set; }
        public bool St_integraralmox { get; set; }

        public TRegistro_CadCFGPedidoFiscal()
        {
            cd_cmi = null;
            cd_cmistring = string.Empty;
            CD_CondPgto = string.Empty;
            Cd_modelo = string.Empty;
            cd_movto = null;
            cd_movtostring = string.Empty;
            Cfg_pedido = string.Empty;
            Ds_cmi = string.Empty;
            Ds_modelo = string.Empty;
            Ds_movimentacao = string.Empty;
            Cd_historicoMov = string.Empty;
            Ds_historicoMov = string.Empty;
            Ds_serienf = string.Empty;
            Ds_tipopedido = string.Empty;
            Ds_tpdocto = string.Empty;
            Ds_tpduplicata = string.Empty;
            Nr_serie = string.Empty;
            Tp_serie = string.Empty;
            ST_Complementar = "N";
            St_geraestoque = "N";
            ST_Devolucao = "N";
            ST_Retorno = "N";
            ST_Mestra = "N";
            ST_SequenciaAuto = "N";
            ST_SimplesRemessa = "N";
            tp_docto = null;
            tp_doctostr = string.Empty;
            Tp_duplicata = string.Empty;
            Tp_fiscal = string.Empty;
            Tp_movimento = string.Empty;
            St_servico = false;
            St_commoditties = false;
            St_valoresfixos = false;
            St_deposito = false;
            St_vincularcf = false;
            St_gerarfin = false;
            St_integraralmox = false;
        }
    }

    public class TCD_CadCFGPedidoFiscal : TDataQuery
    {
        public TCD_CadCFGPedidoFiscal()
        { }

        public TCD_CadCFGPedidoFiscal(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cfg_pedido, a.tp_fiscal, a.nr_serie, ");
                sql.AppendLine("b.ds_serienf, b.tp_serie, b.ST_SequenciaAuto, a.cd_modelo, ");
                sql.AppendLine("c.ds_modelo, a.cd_cmi, d.ds_cmi, cfgped.tp_movimento, isnull(d.ST_Retorno, 'N') as ST_Retorno, ");
                sql.AppendLine("isnull(d.ST_Devolucao,'N') as ST_Devolucao, isnull(d.ST_Complementar,'N') as ST_Complementar, ");
                sql.AppendLine("isnull(d.ST_Mestra,'N') as ST_Mestra, isnull(d.ST_SimplesRemessa,'N') as ST_SimplesRemessa, hist.ds_historico, ");
                sql.AppendLine("a.cd_movto, e.ds_movimentacao, e.cd_historico, cfgped.DS_TipoPedido, ");
                sql.AppendLine("e.cd_obsfiscal_dentroestado, obs_de.ds_observacaofiscal as DS_ObsFiscal_DentroEstado, ");
                sql.AppendLine("e.cd_obsfiscal_foraestado, obs_fe.ds_observacaofiscal as DS_ObsFiscal_ForaEstado, ");
                sql.AppendLine("e.cd_dadosadic_dentroestado, adic_de.ds_observacaofiscal as DS_DadosAdic_DentroEstado, ");
                sql.AppendLine("e.cd_dadosadic_foraestado, adic_fe.ds_observacaofiscal as DS_DadosAdic_ForaEstado, ");
                sql.AppendLine("cond.cd_condpgto, cond.ds_condpgto, dup.tp_duplicata, dup.ds_tpduplicata, ");
                sql.AppendLine("d.tp_docto, cfgped.st_servico, doc.ds_tpdocto, d.st_compdevimposto, ");
                sql.AppendLine("cond.qt_parcelas, cond.qt_diasdesdobro, cond.st_comentrada, cfgped.st_gerarfin, ");
                sql.AppendLine("juro_fin.cd_juro as cd_juro_fin, juro_fin.ds_juro as ds_juro_fin, ");
                sql.AppendLine("juro_fin.pc_jurodiario_atrazo, juro_fin.tp_juro, d.st_geraEstoque, cfgped.st_integraralmox, ");
                sql.AppendLine("cfgped.st_commoditties, cfgped.st_deposito, cfgped.st_valoresfixos, cfgped.st_vincularcf ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_cfg_pedfiscal a ");
            sql.AppendLine("inner join tb_fat_cfgpedido cfgped ");
            sql.AppendLine("on a.cfg_pedido = cfgped.cfg_pedido");
            sql.AppendLine("inner join tb_fat_serienf b ");
            sql.AppendLine("on a.nr_serie = b.nr_serie ");
            sql.AppendLine("and a.cd_modelo = b.cd_modelo ");
            sql.AppendLine("inner join tb_fat_modelonf c ");
            sql.AppendLine("on a.cd_modelo = c.cd_modelo");
            sql.AppendLine("inner join tb_fis_cmi d ");
            sql.AppendLine("on a.cd_cmi = d.cd_cmi");
            sql.AppendLine("inner join tb_fis_movimentacao e ");
            sql.AppendLine("on a.cd_movto = e.cd_movimentacao ");
            sql.AppendLine("left outer join tb_fis_observacaofiscal obs_de ");
            sql.AppendLine("on e.cd_obsfiscal_dentroestado = obs_de.cd_observacaofiscal ");
            sql.AppendLine("left outer join tb_fis_observacaofiscal obs_fe ");
            sql.AppendLine("on e.cd_obsfiscal_foraestado = obs_fe.cd_observacaofiscal ");
            sql.AppendLine("left outer join tb_fis_observacaofiscal adic_de ");
            sql.AppendLine("on e.cd_dadosadic_dentroestado = adic_de.cd_observacaofiscal");
            sql.AppendLine("left outer join tb_fis_observacaofiscal adic_fe ");
            sql.AppendLine("on e.cd_dadosadic_foraestado = adic_fe.cd_observacaofiscal ");
            sql.AppendLine("left outer join tb_fin_condpgto cond ");
            sql.AppendLine("on d.cd_condpgto = cond.cd_condpgto ");
            sql.AppendLine("left outer join tb_fin_tpduplicata dup ");
            sql.AppendLine("on d.tp_duplicata = dup.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup doc ");
            sql.AppendLine("on d.tp_docto = doc.tp_docto ");
            sql.AppendLine("left outer join tb_fin_juro juro_fin ");
            sql.AppendLine("on cond.cd_juro_fin = juro_fin.cd_juro ");
            sql.AppendLine("left outer join tb_fin_historico hist ");
            sql.AppendLine("on e.cd_historico = hist.cd_historico ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.cfg_pedido");
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

        public TList_CadCFGPedidoFiscal Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadCFGPedidoFiscal lista = new TList_CadCFGPedidoFiscal();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCFGPedidoFiscal reg = new TRegistro_CadCFGPedidoFiscal();

                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("ST_Servico")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Fiscal")))
                        reg.Tp_fiscal = reader.GetString(reader.GetOrdinal("TP_Fiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNf")))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_serie")))
                        reg.Tp_serie = reader.GetString(reader.GetOrdinal("tp_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CMI")))
                        reg.Cd_cmi = reader.GetDecimal(reader.GetOrdinal("CD_CMI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CMI")))
                        reg.Ds_cmi = reader.GetString(reader.GetOrdinal("DS_CMI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movto")))
                        reg.Cd_movto = reader.GetDecimal(reader.GetOrdinal("CD_Movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historicoMov = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historicoMov = reader.GetString(reader.GetOrdinal("ds_historico"));

                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("Ds_modelo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.CD_CondPgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Devolucao")))
                        reg.ST_Devolucao = reader.GetString(reader.GetOrdinal("ST_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Complementar")))
                        reg.ST_Complementar = reader.GetString(reader.GetOrdinal("ST_Complementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GeraEstoque")))
                        reg.St_geraestoque = reader.GetString(reader.GetOrdinal("ST_GeraEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Mestra")))
                        reg.ST_Mestra = reader.GetString(reader.GetOrdinal("ST_Mestra"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SimplesRemessa")))
                        reg.ST_SimplesRemessa = reader.GetString(reader.GetOrdinal("ST_SimplesRemessa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("ST_Retorno")))
                        reg.ST_Retorno = reader.GetString(reader.GetOrdinal("ST_Retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SequenciaAuto")))
                        reg.ST_SequenciaAuto = reader.GetString(reader.GetOrdinal("ST_SequenciaAuto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_commoditties")))
                        reg.St_commoditties = reader.GetString(reader.GetOrdinal("st_commoditties")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_valoresfixos")))
                        reg.St_valoresfixos = reader.GetString(reader.GetOrdinal("st_valoresfixos")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_deposito")))
                        reg.St_deposito = reader.GetString(reader.GetOrdinal("st_deposito")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vincularcf")))
                        reg.St_vincularcf = reader.GetString(reader.GetOrdinal("st_vincularcf")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarfin")))
                        reg.St_gerarfin = reader.GetString(reader.GetOrdinal("st_gerarfin")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_integraralmox")))
                        reg.St_integraralmox = reader.GetString(reader.GetOrdinal("st_integraralmox")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));

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

        public string Gravar(TRegistro_CadCFGPedidoFiscal val)
        {
             Hashtable hs = new Hashtable(6);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_TP_FISCAL", val.Tp_fiscal);
            hs.Add("@P_CD_MOVTO", val.Cd_movto);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_CMI", val.Cd_cmi);

            return executarProc("IA_FAT_CFG_PEDFISCAL", hs);
        }

        public string Excluir(TRegistro_CadCFGPedidoFiscal val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido.Trim());
            hs.Add("@P_TP_FISCAL", val.Tp_fiscal);

            return executarProc("EXCLUI_FAT_CFG_PEDFISCAL", hs);
        }
    }
}
