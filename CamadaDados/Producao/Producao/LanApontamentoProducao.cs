using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_ApontamentoProducao : List<TRegistro_ApontamentoProducao>
    { }
    public class TRegistro_ApontamentoProducao
    {
        private decimal? id_apontamento;
        
        public decimal? Id_apontamento
        {
            get { return id_apontamento; }
            set
            {
                id_apontamento = value;
                id_apontamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_apontamentostr;
        
        public string Id_apontamentostr
        {
            get { return id_apontamentostr; }
            set
            {
                id_apontamentostr = value;
                try
                {
                    id_apontamento = Convert.ToDecimal(value);
                }
                catch
                { id_apontamento = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? id_formulacao;
        
        public decimal? Id_formulacao
        {
            get { return id_formulacao; }
            set
            {
                id_formulacao = value;
                id_formulacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_formulacaostr;
        
        public string Id_formulacaostr
        {
            get { return id_formulacaostr; }
            set
            {
                id_formulacaostr = value;
                try
                {
                    id_formulacao = Convert.ToDecimal(value);
                }
                catch
                { id_formulacao = null; }
            }
        }
        
        public string Ds_formula
        { get; set; }
        private decimal? nr_loteproducao;
        
        public decimal? Nr_loteproducao
        {
            get { return nr_loteproducao; }
            set
            {
                nr_loteproducao = value;
                nr_loteproducaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_loteproducaostr;
        
        public string Nr_loteproducaostr
        {
            get { return nr_loteproducaostr; }
            set
            {
                nr_loteproducaostr = value;
                try
                {
                    nr_loteproducao = Convert.ToDecimal(value);
                }
                catch
                { nr_loteproducao = null; }
            }
        }
        private decimal? id_turno;
        
        public decimal? Id_turno
        {
            get { return id_turno; }
            set
            {
                id_turno = value;
                id_turnostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_turnostr;
        
        public string Id_turnostr
        {
            get { return id_turnostr; }
            set
            {
                id_turnostr = value;
                try
                {
                    id_turno = Convert.ToDecimal(value);
                }
                catch
                { id_turno = null; }
            }
        }
        public string Ds_turno
        { get; set; }
        private decimal? id_ordem;
        
        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;
        
        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = Convert.ToDecimal(value);
                }
                catch
                { id_ordem = null; }
            }
        }
        
        public string Ds_loteproducao
        { get; set; }
        private DateTime? dt_apontamento;
        
        public DateTime? Dt_apontamento
        {
            get { return dt_apontamento; }
            set
            {
                dt_apontamento = value;
                dt_apontamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_apontamentostr;
        public string Dt_apontamentostr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_apontamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_apontamentostr = value;
                try
                {
                    dt_apontamento = Convert.ToDateTime(value);
                }
                catch
                { dt_apontamento = null; }
            }
        }
        private DateTime? dt_validade;
        
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = Convert.ToDateTime(value);
                }
                catch
                { dt_validade = null; }
            }
        }
        
        public decimal Vl_custo_mpd
        { get; set; }
        
        public decimal Vl_custo_fixodireto
        { get; set; }
        public decimal Vl_custototal
        {
            get
            {
                return Vl_custo_mpd + Vl_custo_fixodireto;
            }
        }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.ToUpper().Trim().Equals("0"))
                    return "EM PRODUÇÃO";
                else
                    return "CONCLUÍDO";
            }
        }
        public decimal Qtd_batch { get; set; } = 1;

        //Lista Custo Fixo
        public TList_Apontamento_CustoFixo LCustoFixo
        { get; set; }
        //Lista Apontamento Estoque
        public TList_Apontamento_Estoque LApontamentoEstoque
        { get; set; }
        //Lista de Formula Apontamento
        public TList_FormulaApontamento LFormulaApontamento
        { get; set; }
        //Lista Materia Prima Apontamento
        public TList_Apontamento_MPrima lMPrimaApontamento
        { get; set; }
        //Lista Ordem Producao
        public TList_OrdemProducao lOrdem
        { get; set; }

        public TList_SerieProduto lSerie
        { get; set; }
        public TList_MovRastreabilidade lMov
        { get; set; }

        public TRegistro_ApontamentoProducao()
        {
            id_apontamento = null;
            id_apontamentostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_formulacao = null;
            id_formulacaostr = string.Empty;
            Ds_formula = string.Empty;
            nr_loteproducao = null;
            nr_loteproducaostr = string.Empty;
            Ds_loteproducao = string.Empty;
            dt_apontamento = DateTime.Now.Date;
            dt_apontamentostr = DateTime.Now.Date.ToString("dd/MM/yyyy");
            dt_validade = null;
            dt_validadestr = string.Empty;
            id_turno = null;
            id_turnostr = string.Empty;
            Ds_turno = string.Empty;
            id_ordem = null;
            id_ordemstr = string.Empty;
            Vl_custo_mpd = decimal.Zero;
            Vl_custo_fixodireto = decimal.Zero;
            St_registro = string.Empty;
            LCustoFixo = new TList_Apontamento_CustoFixo();
            LApontamentoEstoque = new TList_Apontamento_Estoque();
            LFormulaApontamento = new TList_FormulaApontamento();
            lMPrimaApontamento = new TList_Apontamento_MPrima();
            lOrdem = new TList_OrdemProducao();
            lSerie = new TList_SerieProduto();
            lMov = new TList_MovRastreabilidade();
        }
    }

    public class TCD_ApontamentoProducao : TDataQuery
    {
        public TCD_ApontamentoProducao()
        { }

        public TCD_ApontamentoProducao(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_apontamento, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.nr_loteproducao, d.ds_loteproducao, a.id_turno, e.ds_turno, ");
                sql.AppendLine("a.dt_apontamento, a.dt_validade, ");
                sql.AppendLine("a.vl_custo_mpd, a.vl_custo_fixodireto, a.St_registro ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_apontamentoproducao a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_prd_lote d ");
            sql.AppendLine("on a.nr_loteproducao = d.nr_loteproducao ");
            sql.AppendLine("left outer join tb_prd_turno e ");
            sql.AppendLine("on a.id_turno = e.id_turno ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return executarEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ApontamentoProducao Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ApontamentoProducao lista = new TList_ApontamentoProducao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ApontamentoProducao reg = new TRegistro_ApontamentoProducao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LoteProducao")))
                        reg.Nr_loteproducao = reader.GetDecimal(reader.GetOrdinal("NR_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LoteProducao")))
                        reg.Ds_loteproducao = reader.GetString(reader.GetOrdinal("DS_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Apontamento")))
                        reg.Dt_apontamento = reader.GetDateTime(reader.GetOrdinal("DT_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("DT_Validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Turno")))
                        reg.Id_turno = reader.GetDecimal(reader.GetOrdinal("ID_Turno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Turno")))
                        reg.Ds_turno = reader.GetString(reader.GetOrdinal("DS_Turno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Custo_MPD")))
                        reg.Vl_custo_mpd = reader.GetDecimal(reader.GetOrdinal("Vl_Custo_MPD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Custo_FixoDireto")))
                        reg.Vl_custo_fixodireto = reader.GetDecimal(reader.GetOrdinal("Vl_Custo_FixoDireto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("St_registro"));

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

        public string Gravar(TRegistro_ApontamentoProducao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LOTEPRODUCAO", val.Nr_loteproducao);
            hs.Add("@P_DT_APONTAMENTO", val.Dt_apontamento);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);
            hs.Add("@P_ID_TURNO", val.Id_turno);
            hs.Add("@P_VL_CUSTO_MPD", val.Vl_custo_mpd);
            hs.Add("@P_VL_CUSTO_FIXODIRETO", val.Vl_custo_fixodireto);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PRD_APONTAMENTOPRODUCAO", hs);
        }

        public string Deletar(TRegistro_ApontamentoProducao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);

            return executarProc("EXCLUI_PRD_APONTAMENTOPRODUCAO", hs);
        }
    }
}
