using CamadaDados.Faturamento.Locacao;
using CamadaDados.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    #region Pre Venda
    public class TList_PreVenda : List<TRegistro_PreVenda>, IComparer<TRegistro_PreVenda>
    {
        #region IComparer<TRegistro_PreVenda> Members
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

        public TList_PreVenda()
        { }

        public TList_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PreVenda x, TRegistro_PreVenda y)
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
    
    public class TRegistro_PreVenda
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch
                { id_prevenda = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_cliforInd
        { get; set; }
        public string Nm_cliforInd
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Cd_condPgto
        { get; set; }
        public string Ds_condPgto
        { get; set; }
        public string Cd_tabelaPreco
        { get; set; }
        public string Ds_tabelaPreco
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_representante
        { get; set; }
        public string Nm_representante
        { get; set; }
        private decimal? id_pessoa;
        public decimal? Id_pessoa
        {
            get { return id_pessoa; }
            set
            {
                id_pessoa = value;
                id_pessoastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pessoastr;
        public string Id_pessoastr
        {
            get { return id_pessoastr; }
            set
            {
                id_pessoastr = value;
                try
                {
                    id_pessoa = decimal.Parse(value);
                }
                catch { id_pessoa = null; }
            }
        }
        public string Nm_pessoa
        { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }
        private DateTime? dt_prevenda;
        public DateTime? Dt_prevenda
        {
            get { return dt_prevenda; }
            set
            {
                dt_prevenda = value;
                dt_prevendastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevendastr;
        public string Dt_prevendastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevendastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_prevendastr = value;
                try
                {
                    dt_prevenda = DateTime.Parse(value);
                }
                catch { dt_prevenda = null; }
            }
        }
        public string Ds_observacao
        { get; set; }
        private string st_orcamento;
        public string St_orcamento
        {
            get { return st_orcamento; }
            set
            {
                st_orcamento = value;
                st_orcamentobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_orcamentobool;
        public bool St_orcamentobool
        {
            get { return st_orcamentobool; }
            set
            {
                st_orcamentobool = value;
                st_orcamento = value ? "S" : "N";
            }
        }
        private string st_condicional;
        public string St_condicional
        {
            get { return st_condicional; }
            set
            {
                st_condicional = value;
                st_condicionalbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_condicionalbool;
        public bool St_condicionalbool
        {
            get { return st_condicionalbool; }
            set
            {
                st_condicionalbool = value;
                st_condicional = value ? "S" : "N";
            }
        }
        public decimal Vl_frete
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                {
                    if (St_faturada)
                        status = "FATURADA";
                    else
                        status = "ABERTA";
                }
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADA";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("ABERTA") || value.Trim().ToUpper().Equals("FATURADA"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_registro = "C";
            }
        }
        public decimal Vl_prevenda
        { get; set; }
        public decimal? Id_os
        { get; set; }
        public decimal? Id_locacao
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal Vl_entrada
        { get; set; }
        public bool St_cometrada
        { get; set; }
        public decimal QTD_Parcelas
        { get; set; }
        public string Parcelas_Entrada
        { get; set; }
        public decimal Parcelas_Dias_Desdobro
        { get; set; }
        public string Parcelas_Feriado
        { get; set; }
        public string ST_SolicitarDtVencto
        { get; set; }
        public string Cd_juro_fin
        { get; set; }
        public decimal Pc_juro_Diario_fin
        { get; set; }
        public string Tp_juro
        { get; set; }
        public decimal Vl_devcred
        { get; set; }
        public bool St_faturada
        { get; set; }
        public TList_ItensPreVenda lItens
        { get; set; }
        public TList_ItensPreVenda lItensDel
        { get; set; }
        public TList_PreVenda_DT_Vencto DT_Vencto
        { get; set; }
        public TList_PreVenda_DT_Vencto DT_VentoDel
        { get; set; }

        public TRegistro_PreVenda()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_cliforInd = string.Empty;
            Nm_cliforInd = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Cd_condPgto = string.Empty;
            Ds_condPgto = string.Empty;
            Cd_tabelaPreco = string.Empty;
            Ds_tabelaPreco = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_representante = string.Empty;
            Nm_representante = string.Empty;
            id_pessoa = null;
            id_pessoastr = string.Empty;
            Nm_pessoa = string.Empty;
            dt_emissao = DateTime.Now;
            dt_emissaostr = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dt_prevenda = DateTime.Now;
            dt_prevendastr = DateTime.Now.ToString("dd/MM/yyyy");
            Ds_observacao = string.Empty;
            st_orcamento = "N";
            st_orcamentobool = false;
            st_condicional = "N";
            st_condicionalbool = false;
            Vl_frete = decimal.Zero;
            st_registro = "A";
            status = "ABERTA";
            Vl_prevenda = decimal.Zero;
            St_processar = false;
            Id_os = null;
            Id_locacao = null;
            St_cometrada = false;
            QTD_Parcelas = decimal.Zero;
            Parcelas_Entrada = string.Empty;
            Parcelas_Dias_Desdobro = decimal.Zero;
            Parcelas_Feriado = string.Empty;
            ST_SolicitarDtVencto = string.Empty;
            Cd_juro_fin = string.Empty;
            Pc_juro_Diario_fin = decimal.Zero;
            Tp_juro = string.Empty;
            Vl_devcred = decimal.Zero;
            St_faturada = false;
            lItens = new TList_ItensPreVenda();
            lItensDel = new TList_ItensPreVenda();
            DT_Vencto = new TList_PreVenda_DT_Vencto();
            DT_VentoDel = new TList_PreVenda_DT_Vencto();
        }
    }

    public class TCD_PreVenda : TDataQuery
    {
        public TCD_PreVenda()
        { }

        public TCD_PreVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, a.vl_frete, a.st_condicional, ");
                sql.AppendLine("a.id_prevenda, a.cd_clifor, isnulL(a.nm_clifor, c.nm_clifor) as nm_clifor, a.cd_representante, rep.nm_clifor as nm_representante, ");
                sql.AppendLine("a.cd_cliforind, ind.nm_clifor as nm_cliforInd, a.id_pessoa, paut.nm_pessoa, ");
                sql.AppendLine("a.cd_endereco, a.ds_endereco, a.cd_portador, f.ds_portador, a.cd_condpgto, ");
                sql.AppendLine("g.ds_condpgto, a.cd_tabelapreco, tab.ds_tabelapreco, a.st_orcamento, ");
                sql.AppendLine("a.cd_vendedor, d.nm_clifor as nomevendedor, a.dt_emissao, a.id_os, a.id_locacao, ");
                sql.AppendLine("a.vl_prevenda, a.st_registro, a.ds_observacao, a.st_faturada, ");
                //Dados Condicao de Pagamento
                sql.AppendLine(" a.CD_CondPGTO, g.ds_CondPGTO, g.QT_Parcelas, g.ST_ComEntrada, g.CD_Juro_Fin, ");
                sql.AppendLine("g.QT_DiasDesdobro, g.ST_VenctoEmFeriado, g.ST_SolicitarDtVencto, a.vl_devcred, ");
                sql.AppendLine("Vl_entrada = isnull((select TOP 1 x.Vl_parcela from TB_PDV_PreVenda_DT_Vencto x ");
                sql.AppendLine("             where a.cd_empresa = x.cd_empresa ");
                sql.AppendLine("             and a.id_prevenda = x.id_prevenda ");
                sql.AppendLine("             and g.ST_ComEntrada = 'S'),0) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from vtb_pdv_prevenda a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor d ");
            sql.AppendLine("on a.cd_vendedor = d.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_endereco e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = e.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_portador f ");
            sql.AppendLine("on a.cd_portador = f.cd_portador ");
            sql.AppendLine("left outer join TB_FIN_CondPGTO g ");
            sql.AppendLine("on a.cd_condpgto = g.cd_condpgto ");
            sql.AppendLine("left outer join tb_div_tabelapreco tab ");
            sql.AppendLine("on a.cd_tabelapreco = tab.cd_tabelapreco ");
            sql.AppendLine("left outer join tb_fin_clifor ind ");
            sql.AppendLine("on a.cd_cliforind = ind.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_pessoasautorizadas paut ");
            sql.AppendLine("on a.cd_clifor = paut.cd_clifor ");
            sql.AppendLine("and a.id_pessoa = paut.id_pessoa ");
            sql.AppendLine("left outer join tb_fin_clifor rep ");
            sql.AppendLine("on a.cd_representante = rep.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo, string vOrder)
        {
            TList_PreVenda lista = new TList_PreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_PreVenda reg = new TRegistro_PreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforind")))
                        reg.Cd_cliforInd = reader.GetString(reader.GetOrdinal("cd_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforInd")))
                        reg.Nm_cliforInd = reader.GetString(reader.GetOrdinal("nm_cliforInd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_representante")))
                        reg.Cd_representante = reader.GetString(reader.GetOrdinal("Cd_representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_representante")))
                        reg.Nm_representante = reader.GetString(reader.GetOrdinal("Nm_representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condPgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condPgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelaPreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelaPreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Parcelas")))
                        reg.QTD_Parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ComEntrada")))
                        reg.St_cometrada = reader.GetString(reader.GetOrdinal("ST_ComEntrada")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_DiasDesdobro")))
                        reg.Parcelas_Dias_Desdobro = reader.GetDecimal(reader.GetOrdinal("QT_DiasDesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SolicitarDtVencto")))
                        reg.ST_SolicitarDtVencto = reader.GetString(reader.GetOrdinal("ST_SolicitarDtVencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Juro_Fin")))
                        reg.Cd_juro_fin = reader.GetString(reader.GetOrdinal("CD_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_entrada")))
                        reg.Vl_entrada = reader.GetDecimal(reader.GetOrdinal("Vl_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomevendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nomevendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("id_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pessoa")))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("nm_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_prevenda = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_orcamento")))
                        reg.St_orcamento = reader.GetString(reader.GetOrdinal("st_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_condicional")))
                        reg.St_condicional = reader.GetString(reader.GetOrdinal("st_condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_prevenda")))
                        reg.Vl_prevenda = reader.GetDecimal(reader.GetOrdinal("vl_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devcred")))
                        reg.Vl_devcred = reader.GetDecimal(reader.GetOrdinal("vl_devcred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_faturada")))
                        reg.St_faturada = reader.GetString(reader.GetOrdinal("st_faturada")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(19);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condPgto);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelaPreco);
            hs.Add("@P_CD_CLIFORIND", val.Cd_cliforInd);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_ORCAMENTO", val.St_orcamento);
            hs.Add("@P_ST_CONDICIONAL", val.St_condicional);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);
            hs.Add("@P_VL_DEVCRED", val.Vl_devcred);
            hs.Add("@P_CD_REPRESENTANTE", val.Cd_representante);

            return executarProc("IA_PDV_PREVENDA", hs);
        }

        public string Excluir(TRegistro_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);

            return executarProc("EXCLUI_PDV_PREVENDA", hs);
        }
    }
    #endregion

    #region Itens Pre Venda
    public class TList_ItensPreVenda : List<TRegistro_ItensPreVenda>, IComparer<TRegistro_ItensPreVenda>
    {
        #region IComparer<TRegistro_ItensPreVenda> Members
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

        public TList_ItensPreVenda()
        { }

        public TList_ItensPreVenda(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensPreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensPreVenda x, TRegistro_ItensPreVenda y)
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
    
    public class TRegistro_ItensPreVenda
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch
                { id_prevenda = null; }
            }
        }
        private decimal? id_itemprevenda;
        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;
        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = decimal.Parse(value);
                }
                catch { id_itemprevenda = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal CasasDecimais { get; set; } = decimal.Zero;
        public string Cd_grupo
        { get; set; }
        public string Cd_tabelaPreco
        { get; set; }
        public string Ncm
        { get; set; }
        public decimal Pc_AutorizadoDesc
        { get; set; }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return vl_desconto; }
            set { vl_desconto = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        public decimal Pc_desconto
        { get; set; }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return vl_acrescimo; }
            set { vl_acrescimo = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        public decimal Pc_acrescimo
        { get; set; }
        private decimal vl_juro_fin;
        public decimal Vl_juro_fin
        {
            get { return vl_juro_fin; }
            set { vl_juro_fin = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        private decimal vl_frete;
        public decimal Vl_frete
        {
            get { return vl_frete; }
            set
            { vl_frete = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return vl_subtotal; }
            set { vl_subtotal = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        private decimal vl_liquido;
        public decimal Vl_liquido
        {
            get { return vl_liquido; }
            set { vl_liquido = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        public decimal Qtd_entregar
        { get; set; }
        public decimal Qtd_entregueBalcao
        { get { return Quantidade - Qtd_entregar; } }
        public decimal Qtd_pontosutilizados
        { get; set; }
        public TList_LanServicosPecas lPecasOS
        { get; set; }
        public TRegistro_ItensLocacao rItemLocacao
        { get; set; }
        public bool St_itemLocacao
        { get; set; }
        public decimal? Id_itemLoc
        { get; set; }
        private string st_baixapatrimonio;
        public string St_baixapatrimonio
        {
            get { return st_baixapatrimonio; }
            set
            {
                st_baixapatrimonio = value;
                st_baixapatrimoniobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_baixapatrimoniobool;
        public bool St_baixapatrimoniobool
        {
            get { return st_baixapatrimoniobool; }
            set
            {
                st_baixapatrimoniobool = value;
                st_baixapatrimonio = value ? "S" : "N";
            }
        }
        public decimal? Id_Rua { get; set; }
        public decimal? Id_Secao { get; set; }
        public decimal? Id_Celula { get; set; }


        public string Ds_Rua { get; set; }
        public string Ds_Secao { get; set; }
        public string Ds_Celula { get; set; }

        public TRegistro_ItensPreVenda()
        {
            Id_Rua = null;
            Id_Secao = null;
            Id_Celula = null;
            Ds_Rua = string.Empty;
            Ds_Secao = string.Empty;
            Ds_Celula = string.Empty;
            Cd_empresa = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_grupo = string.Empty;
            Cd_tabelaPreco = string.Empty;
            Ncm = string.Empty;
            Pc_AutorizadoDesc = decimal.Zero;
            vl_desconto = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            Pc_acrescimo = decimal.Zero;
            vl_juro_fin = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_liquido = decimal.Zero;
            Pc_desconto = decimal.Zero;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Qtd_entregar = decimal.Zero;
            Qtd_pontosutilizados = decimal.Zero;
            St_itemLocacao = false;
            Id_itemLoc = null;
            st_baixapatrimonio = "N";
            st_baixapatrimoniobool = false;

            lPecasOS = new TList_LanServicosPecas();
            rItemLocacao = null;
        }
    }

    public class TCD_ItensPreVenda : TDataQuery
    {
        public TCD_ItensPreVenda()
        { }

        public TCD_ItensPreVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_prevenda, a.id_itemprevenda, pre.cd_tabelapreco, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, b.cd_unidade, c.ds_unidade, c.sigla_unidade, ");
                sql.AppendLine("b.cd_grupo, b.ncm, a.quantidade, a.vl_unitario, a.vl_subtotal, c.CasasDecimais, ");
                sql.AppendLine("a.vl_desconto, a.vl_acrescimo, a.vl_juro_fin, a.vl_frete, ");
                sql.AppendLine("a.vl_liquido, a.Qtd_entregar, a.St_BaixaPatrimonio, b.id_rua, b.id_secao,b.id_celula,r.ds_rua, s.ds_secao, ca.ds_celula ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_PDV_ITENSPREVENDA a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join TB_PDV_PreVenda pre ");
            sql.AppendLine("on a.CD_Empresa = pre.CD_Empresa ");
            sql.AppendLine("and a.ID_PreVenda = pre.ID_PreVenda ");
            sql.AppendLine("left join TB_AMX_Rua r ");
            sql.AppendLine("on b.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_Secao s ");
            sql.AppendLine("on b.id_secao = s.id_secao and s.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_CelulaArm ca ");
            sql.AppendLine("on ca.id_celula = b.id_celula and ca.id_secao = s.id_secao and ca.id_rua = r.id_rua");

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

        public TList_ItensPreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensPreVenda lista = new TList_ItensPreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensPreVenda reg = new TRegistro_ItensPreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CasasDecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("CasasDecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelaPreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("vl_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_liquido")))
                        reg.Vl_liquido = reader.GetDecimal(reader.GetOrdinal("vl_liquido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entregar")))
                        reg.Qtd_entregar = reader.GetDecimal(reader.GetOrdinal("qtd_entregar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_BaixaPatrimonio")))
                        reg.St_baixapatrimonio = reader.GetString(reader.GetOrdinal("St_BaixaPatrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rua")))
                        reg.Id_Rua = reader.GetDecimal(reader.GetOrdinal("id_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rua")))
                        reg.Ds_Rua = reader.GetString(reader.GetOrdinal("ds_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_secao")))
                        reg.Id_Secao = reader.GetDecimal(reader.GetOrdinal("id_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_secao")))
                        reg.Ds_Secao = reader.GetString(reader.GetOrdinal("ds_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Celula")))
                        reg.Id_Celula = reader.GetDecimal(reader.GetOrdinal("Id_Celula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Celula")))
                        reg.Ds_Celula = reader.GetString(reader.GetOrdinal("Ds_Celula"));

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

        public string Gravar(TRegistro_ItensPreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_ACRESCIMO", val.Vl_acrescimo);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_VL_JURO_FIN", val.Vl_juro_fin);
            hs.Add("@P_ST_BAIXAPATRIMONIO", val.St_baixapatrimonio);

            return executarProc("IA_PDV_ITENSPREVENDA", hs);
        }

        public string Excluir(TRegistro_ItensPreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("EXCLUI_PDV_ITENSPREVENDA", hs);
        }
    }
    #endregion

    #region Pre Venda X Venda Rapida
    public class TList_PreVenda_X_VendaRapida : List<TRegistro_PreVenda_X_VendaRapida>
    { }
    
    public class TRegistro_PreVenda_X_VendaRapida
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch { id_prevenda = null; }
            }
        }
        private decimal? id_itemprevenda;
        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;
        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = decimal.Parse(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch { id_cupom = null; }
            }
        }
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch { id_lancto = null; }
            }
        }

        public TRegistro_PreVenda_X_VendaRapida()
        {
            Cd_empresa = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            id_lancto = null;
            id_lanctostr = string.Empty;
        }
    }

    public class TCD_PreVenda_X_VendaRapida : TDataQuery
    {
        public TCD_PreVenda_X_VendaRapida()
        { }

        public TCD_PreVenda_X_VendaRapida(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_prevenda, ");
                sql.AppendLine("a.id_itemprevenda, a.id_cupom, a.id_lancto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_pdv_prevenda_x_vendarapida a ");

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

        public TList_PreVenda_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_PreVenda_X_VendaRapida lista = new TList_PreVenda_X_VendaRapida();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_PreVenda_X_VendaRapida reg = new TRegistro_PreVenda_X_VendaRapida();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));

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

        public string Gravar(TRegistro_PreVenda_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("IA_PDV_PREVENDA_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_PreVenda_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("EXCLUI_PDV_PREVENDA_X_VENDARAPIDA", hs);
        }
    }
    #endregion

    #region Pre Venda X Condicional
    public class TList_PreVenda_X_Condicional : List<TRegistro_PreVenda_X_Condicional>
    { }
    
    public class TRegistro_PreVenda_X_Condicional
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch
                { id_prevenda = null; }
            }
        }
        private decimal? id_itemprevenda;
        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;
        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = decimal.Parse(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch { id_condicional = null; }
            }
        }
        private decimal? id_item;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
            }
        }

        public TRegistro_PreVenda_X_Condicional()
        {
            Cd_empresa = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
            id_condicional = null;
            id_condicionalstr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
        }
    }

    public class TCD_PreVenda_X_Condicional : TDataQuery
    {
        public TCD_PreVenda_X_Condicional() { }

        public TCD_PreVenda_X_Condicional(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_prevenda, ");
                sql.AppendLine("a.id_itemprevenda, a.id_condicional, a.id_item ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_pdv_prevenda_x_condicional a ");

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

        public TList_PreVenda_X_Condicional Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_PreVenda_X_Condicional lista = new TList_PreVenda_X_Condicional();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_PreVenda_X_Condicional reg = new TRegistro_PreVenda_X_Condicional();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("id_condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));

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

        public string Gravar(TRegistro_PreVenda_X_Condicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("IA_PDV_PREVENDA_X_CONDICIONAL", hs);
        }

        public string Excluir(TRegistro_PreVenda_X_Condicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_PDV_PREVENDA_X_CONDICIONAL", hs);
        }
    }
    #endregion

    #region Pre Venda DT Vencto
    public class TList_PreVenda_DT_Vencto : List<TRegistro_PreVenda_DT_Vencto>
    { }
    
    public class TRegistro_PreVenda_DT_Vencto
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch { id_prevenda = null; }
            }
        }
        public decimal DiasVencto
        { get; set; }
        public DateTime Dt_vencto
        { get { return DateTime.Now.Date.AddDays(Convert.ToDouble(DiasVencto)); } }
        public decimal Vl_parcela
        { get; set; }
        public decimal id_parcela
        { get; set; }

        public TRegistro_PreVenda_DT_Vencto()
        {
            Cd_empresa = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            DiasVencto = decimal.Zero;
            Vl_parcela = decimal.Zero;
            id_parcela = decimal.Zero;
        }
    }

    public class TCD_PreVenda_DT_Vencto : TDataQuery
    {
        public TCD_PreVenda_DT_Vencto()
        { }

        public TCD_PreVenda_DT_Vencto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_prevenda, ");
                sql.AppendLine("a.diavencto, a.vl_parcela ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_PDV_PreVenda_DT_Vencto a ");

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

        public TList_PreVenda_DT_Vencto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_PreVenda_DT_Vencto lista = new TList_PreVenda_DT_Vencto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_PreVenda_DT_Vencto reg = new TRegistro_PreVenda_DT_Vencto();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diavencto")))
                        reg.DiasVencto = reader.GetDecimal(reader.GetOrdinal("diavencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_parcela")))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("vl_parcela"));

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

        public string Gravar(TRegistro_PreVenda_DT_Vencto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_DIAVENCTO", val.DiasVencto);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);

            return executarProc("IA_PDV_PREVENDA_DT_VENCTO", hs);
        }

        public string Excluir(TRegistro_PreVenda_DT_Vencto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_DIAVENCTO", val.DiasVencto);

            return executarProc("EXCLUI_PDV_PREVENDA_DT_VENCTO", hs);
        }
    }
    #endregion                   '
}
