using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Locacao
{
    #region Locacao
    public class TList_Locacao : List<TRegistro_Locacao>, IComparer<TRegistro_Locacao>
    {
        #region IComparer<TRegistro_Locacao> Members
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

        public TList_Locacao()
        { }

        public TList_Locacao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Locacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Locacao x, TRegistro_Locacao y)
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


    public class TRegistro_Locacao
    {
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }


        public string Cd_empresa
        { get; set; }

        public string Nm_empresa
        { get; set; }

        public string Cd_clifor
        { get; set; }

        public string Nm_clifor
        { get; set; }

        public string Cd_vendedor
        { get; set; }

        public string Nm_vendedor
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
        public string Nm_responsavel
        { get; set; }
        public decimal? Nr_contrato
        { get; set; }
        public string ObsContrato
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Cd_condPgto
        { get; set; }
        public string Ds_condPgto
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        private DateTime? dt_locacao;

        public DateTime? Dt_locacao
        {
            get { return dt_locacao; }
            set
            {
                dt_locacao = value;
                dt_locacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_locacaostr;
        public string Dt_locacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_locacaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_locacaostr = value;
                try
                {
                    dt_locacao = Convert.ToDateTime(value);
                }
                catch
                { dt_locacao = null; }
            }
        }
        public DateTime? Dt_parcela
        { get; set; }
        public string Ds_obs
        { get; set; }
        public string MotivoCancelamento
        { get; set; }
        public string Cep_Ent
        { get; set; }
        public string Logradouro_Ent
        { get; set; }
        public string Numero_Ent
        { get; set; }
        public string Bairro_Ent
        { get; set; }
        public string Complemento_Ent
        { get; set; }
        public string Proximo_Ent
        { get; set; }
        public string Cd_cidadeEnt
        { get; set; }
        public string Ds_cidadeEnt
        { get; set; }
        public string UFEnt
        { get; set; }
        public string Loginaltend { get; set; } = string.Empty;
        public bool St_entexp { get; set; } = false;
        public bool St_devexp { get; set; } = false;
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                switch (St_registro.Trim())
                {
                    case "0": return "AGUARDANDO ENTREGA";
                    case "1": return "EM ENTREGA";
                    case "2": return "ENTREGUE";
                    case "3": return "DISPONIVEL PARA COLETA";
                    case "4": return "EM COLETA";
                    case "5": return "FATURAMENTO AGENDADO";
                    case "6": return "FECHAMENTO PARCIAL";
                    case "7": return "DEVOLVIDO";
                    case "8": return "CANCELADO";
                    case "9": return "AGUARDANDO FATURAMENTO";
                    case "10": return "DEVOLUÇÃO PARCIAL";
                    default: return string.Empty;
                }
            }
        }
        private string st_frete;
        public string St_frete
        {
            get { return st_frete; }
            set
            {
                st_frete = value;
                st_fretebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_fretebool;
        public bool St_fretebool
        {
            get { return st_fretebool; }
            set
            {
                st_fretebool = value;
                st_frete = value ? "S" : "N";
            }
        }
        private string tp_frete;
        public string Tp_frete
        {
            get { return tp_frete; }
            set
            {
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_frete = "EMPRESA";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_frete = "CLIENTE";
            }
        }
        private string tipo_frete;
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_frete = "E";
                else if (value.Trim().ToUpper().Equals("CLIENTE"))
                    tp_frete = "C";
            }
        }
        public bool St_comEntrada
        { get; set; }
        public decimal Vl_entrada
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_locacao
        { get; set; }
        public decimal Vl_faturado
        { get; set; }
        public decimal SaldoFaturar
        { 
            get 
            {
                if (Vl_locacao - Vl_faturado >= 0)
                    return Vl_locacao - Vl_faturado;
                else return decimal.Zero;
            } 
        }
        public  decimal? Id_tabela { get; set; }
        public string Tp_tabela { get; set; }
        public string ChaveAcesso
        { get; set; }

        public TList_ItensLocacao lItens
        { get; set; }

        public TList_ItensLocacao lItensDel
        { get; set; }
        public Financeiro.Cadastros.TList_CadClifor lClifor
        { get; set; }

        public Financeiro.Cadastros.TList_CadClifor lCliforDel
        { get; set; }

        public TList_ColetaEntrega lColetaEntrega
        { get; set; }

        public Faturamento.PDV.TList_PreVenda lPreVenda
        { get; set; }

        public Faturamento.PDV.TList_PreVenda lBaixa
        { get; set; }

        public Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanDuplicata lDupDel
        { get; set; }
        public TList_Contrato lContrato
        { get; set; }
        public TList_ParcelaLocacao lParc
        { get; set; }
        public TList_ParcelaLocacao lParcDel
        { get; set; }
        public TList_Historico lHist
        { get; set; }
        public TList_OutrasDesp lOutrasDesp
        { get; set; }

        public TRegistro_Locacao()
        {
            id_locacao = null;
            id_locacaostr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            id_pessoa = null;
            id_pessoastr = string.Empty;
            Nm_pessoa = string.Empty;
            Nm_responsavel = string.Empty;
            Nr_contrato = null;
            ObsContrato = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Cd_condPgto = string.Empty;
            Ds_condPgto = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            dt_locacao = null;
            dt_locacaostr = string.Empty;
            Dt_locacao = null;
            Dt_parcela = null;
            Ds_obs = string.Empty;
            MotivoCancelamento = string.Empty;
            Cep_Ent = string.Empty;
            Logradouro_Ent = string.Empty;
            Numero_Ent = string.Empty;
            Bairro_Ent = string.Empty;
            Complemento_Ent = string.Empty;
            Proximo_Ent = string.Empty;
            Cd_cidadeEnt = string.Empty;
            Ds_cidadeEnt = string.Empty;
            UFEnt = string.Empty;
            St_registro = "0";
            st_frete = "N";
            st_fretebool = false;
            tp_frete = "E";
            tipo_frete = "EMPRESA";
            St_comEntrada = false;
            Vl_entrada = decimal.Zero;
            Vl_frete = decimal.Zero;
            Vl_locacao = decimal.Zero;
            Vl_faturado = decimal.Zero;
            ChaveAcesso = string.Empty;
            Id_tabela = null;
            Tp_tabela = string.Empty;

            lItens = new TList_ItensLocacao();
            lItensDel = new TList_ItensLocacao();
            lColetaEntrega = new TList_ColetaEntrega();
            lPreVenda = new Faturamento.PDV.TList_PreVenda();
            lBaixa = new Faturamento.PDV.TList_PreVenda();
            lDup = new Financeiro.Duplicata.TList_RegLanDuplicata();
            lDupDel = new Financeiro.Duplicata.TList_RegLanDuplicata();
            lContrato = new TList_Contrato();
            lParc = new TList_ParcelaLocacao();
            lParcDel = new TList_ParcelaLocacao();
            lHist = new TList_Historico();
            lOutrasDesp = new TList_OutrasDesp();
            lClifor = new Financeiro.Cadastros.TList_CadClifor();
            lCliforDel = new Financeiro.Cadastros.TList_CadClifor();
        }
    }

    public class TCD_Locacao : TDataQuery
    {
        public TCD_Locacao()
        { }

        public TCD_Locacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Locacao, a.id_tabela, tab.tp_tabela, a.LoginAltEnd, ");
                sql.AppendLine("a.cd_clifor, b.nm_clifor, a.id_pessoa, paut.nm_pessoa, a.Nm_responsavel, a.cd_portador, f.ds_portador, ");
                sql.AppendLine("a.cd_endereco, g.ds_endereco, a.dt_locacao, a.MotivoCancelamento, a.CD_CondPGTO, cond.DS_CondPGTO, ");
                sql.AppendLine("a.cd_empresa, c.nm_empresa, a.ds_obs, a.CEP_Ent, a.Logradouro_Ent, a.Numero_Ent, a.ST_DevExp, a.ST_EntExp, ");
                sql.AppendLine("a.Bairro_Ent, a.Complemento_Ent, a.Proximo_Ent, a.st_registro, a.Tp_frete, a.st_frete, ");
                sql.AppendLine("a.cd_vendedor, x.nm_clifor as nm_vendedor, a.status, a.vl_locacao, a.vl_entrada, a.vl_faturado ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_LOC_Locacao a ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_Endereco g ");
            sql.AppendLine("on a.cd_clifor = g.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = g.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_Clifor x ");
            sql.AppendLine("on a.cd_vendedor = x.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_portador f ");
            sql.AppendLine("on a.cd_portador = f.cd_portador ");
            sql.AppendLine("left outer join tb_fin_pessoasautorizadas paut ");
            sql.AppendLine("on a.cd_clifor = paut.cd_clifor ");
            sql.AppendLine("and a.id_pessoa = paut.id_pessoa ");
            sql.AppendLine("left outer join TB_FIN_CondPGTO cond ");
            sql.AppendLine("on a.CD_CondPGTO = cond.CD_CondPGTO ");
            sql.AppendLine("left outer join TB_LOC_TabPreco tab ");
            sql.AppendLine("on a.id_tabela = tab.id_tabela ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" Order By " + vOrder);

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
         
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_Locacao Select(TpBusca[] vBusca, int vTop, string vNm_Campo, string vOrder)
        {
            TList_Locacao lista = new TList_Locacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_Locacao reg = new TRegistro_Locacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("id_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pessoa")))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("nm_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_responsavel")))
                        reg.Nm_responsavel = reader.GetString(reader.GetOrdinal("Nm_responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.Cd_condPgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.Ds_condPgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("dt_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Obs")))
                        reg.Ds_obs = reader.GetString(reader.GetOrdinal("DS_Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCancelamento")))
                        reg.MotivoCancelamento = reader.GetString(reader.GetOrdinal("MotivoCancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEP_Ent")))
                        reg.Cep_Ent = reader.GetString(reader.GetOrdinal("CEP_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logradouro_Ent")))
                        reg.Logradouro_Ent = reader.GetString(reader.GetOrdinal("Logradouro_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero_Ent")))
                        reg.Numero_Ent = reader.GetString(reader.GetOrdinal("Numero_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro_Ent")))
                        reg.Bairro_Ent = reader.GetString(reader.GetOrdinal("Bairro_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complemento_Ent")))
                        reg.Complemento_Ent = reader.GetString(reader.GetOrdinal("Complemento_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Proximo_Ent")))
                        reg.Proximo_Ent = reader.GetString(reader.GetOrdinal("Proximo_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAltEnd")))
                        reg.Loginaltend = reader.GetString(reader.GetOrdinal("LoginAltEnd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_DevExp")))
                        reg.St_devexp = reader.GetString(reader.GetOrdinal("ST_DevExp")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EntExp")))
                        reg.St_entexp = reader.GetString(reader.GetOrdinal("ST_EntExp")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("Tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_frete")))
                        reg.St_frete = reader.GetString(reader.GetOrdinal("st_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_locacao")))
                        reg.Vl_locacao = reader.GetDecimal(reader.GetOrdinal("vl_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_entrada")))
                        reg.Vl_entrada = reader.GetDecimal(reader.GetOrdinal("vl_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_faturado")))
                        reg.Vl_faturado = reader.GetDecimal(reader.GetOrdinal("vl_faturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("id_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tabela")))
                        reg.Tp_tabela = reader.GetString(reader.GetOrdinal("tp_tabela"));

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

        public string Gravar(TRegistro_Locacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(23);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);
            hs.Add("@P_NM_RESPONSAVEL", val.Nm_responsavel);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condPgto);
            hs.Add("@P_DT_LOCACAO", val.Dt_locacao);
            hs.Add("@P_DS_OBS", val.Ds_obs);
            hs.Add("@P_MOTIVOCANCELAMENTO", val.MotivoCancelamento);
            hs.Add("@P_CEP_ENT", val.Cep_Ent);
            hs.Add("@P_LOGRADOURO_ENT", val.Logradouro_Ent);
            hs.Add("@P_NUMERO_ENT", val.Numero_Ent);
            hs.Add("@P_BAIRRO_ENT", val.Bairro_Ent);
            hs.Add("@P_COMPLEMENTO_ENT", val.Complemento_Ent);
            hs.Add("@P_PROXIMO_ENT", val.Proximo_Ent);
            hs.Add("@P_LOGINALTEND", val.Loginaltend);
            hs.Add("@P_ST_FRETE", val.St_frete);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_LOC_LOCACAO", hs);
        }

        public string Excluir(TRegistro_Locacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);

            return executarProc("EXCLUI_LOC_LOCACAO", hs);
        }


    }

    #endregion

    #region ItensLocacao
    public class TList_ItensLocacao : List<TRegistro_ItensLocacao>, IComparer<TRegistro_ItensLocacao>
    {

        #region IComparer<TRegistro_ItensLocacao> Members
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

        public TList_ItensLocacao()
        { }

        public TList_ItensLocacao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensLocacao x, TRegistro_ItensLocacao y)
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


    public class TRegistro_ItensLocacao
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }
        public string Id_os
        { get; set; }
        public string Cd_produto
        { get; set; }

        public string Ds_produto
        { get; set; }

        private decimal? id_tabela;

        public decimal? Id_tabela
        {
            get { return id_tabela; }
            set
            {
                id_tabela = value;
                id_tabelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tabelastr;

        public string Id_tabelastr
        {
            get { return id_tabelastr; }
            set
            {
                id_tabelastr = value;
                try
                {
                    id_tabela = decimal.Parse(value);
                }
                catch
                { id_tabela = null; }
            }
        }
        public string Ds_tabela
        { get; set; }
        public string Tp_tabela
        { get; set; }
        public string Cd_grupo
        { get; set; }

        public string Ds_grupo
        { get; set; }

        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public decimal Pc_AutorizadoDesc
        { get; set; }
        public string Nr_Patrimonio
        { get; set; }
        public string Codigo_Alternativo
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Qtd_baixada
        { get; set; }
        public decimal Qtd_devolver
        { get; set; }
        public decimal SaldoDevolver
        { get { return QTDItem - Qtd_devolvida; } }
        public decimal QTDItem
        { get; set; }
        public decimal Qtd_horasAtual
        { get; set; }
        public decimal Qtd_horasRetirada
        { get; set; }
        public decimal Qtd_horasDevolucao
        { get; set; }
        private string st_controlehora;
        public string St_controlehora
        {
            get { return st_controlehora; }
            set
            {
                st_controlehora = value;
                st_controlehorabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_controlehorabool;
        public bool St_controlehorabool
        {
            get { return st_controlehorabool; }
            set
            {
                st_controlehorabool = value;
                st_controlehora = value ? "S" : "N";
            }
        }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_patrimonio
        { get; set; }
        public decimal BaseCalc
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_acresc
        { get; set; }
        public decimal Vl_acessorios
        { get; set; }
        public decimal Vl_Baixa
        { get; set; }
        public decimal Vl_locacao
        { get { return Math.Round((QTDItem * (BaseCalc * (Vl_unitario - Vl_desconto))) + Vl_frete, 2); } }
        public decimal Tot_Faturado
        { get; set; }
        private DateTime? dt_locacao;

        public DateTime? Dt_locacao
        {
            get { return dt_locacao; }
            set
            {
                dt_locacao = value;
                dt_locacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_locacaostr;
        public string Dt_locacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_locacaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_locacaostr = value;
                try
                {
                    dt_locacao = Convert.ToDateTime(value);
                }
                catch
                { dt_locacao = null; }
            }
        }
        private DateTime? dt_retirada;

        public DateTime? Dt_retirada
        {
            get { return dt_retirada; }
            set
            {
                dt_retirada = value;
                dt_retiradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_retiradastr;
        public string Dt_retiradastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_retiradastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_retiradastr = value;
                try
                {
                    dt_retirada = Convert.ToDateTime(value);
                }
                catch
                { dt_retirada = null; }
            }
        }
        private DateTime? dt_prevdev;

        public DateTime? Dt_prevdev
        {
            get { return dt_prevdev; }
            set
            {
                dt_prevdev = value;
                dt_prevdevstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_prevdevstr;
        public string Dt_prevdevstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_prevdevstr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevdevstr = value;
                try
                {
                    dt_prevdev = Convert.ToDateTime(value);
                }
                catch
                { dt_prevdev = null; }
            }
        }
        private DateTime? dt_devolucao;

        public DateTime? Dt_devolucao
        {
            get { return dt_devolucao; }
            set
            {
                dt_devolucao = value;
                dt_devolucaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_devolucaostr;
        public string Dt_devolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_devolucaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_devolucaostr = value;
                try
                {
                    dt_devolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_devolucao = null; }
            }
        }
        private DateTime? dt_fechamento;

        public DateTime? Dt_fechamento
        {
            get { return dt_fechamento; }
            set
            {
                dt_fechamento = value;
                dt_fechamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_fechamentostr;
        public string Dt_fechamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fechamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fechamentostr = value;
                try
                {
                    dt_fechamento = Convert.ToDateTime(value);
                }
                catch
                { dt_fechamento = null; }
            }
        }
        private DateTime? dt_troca;

        public DateTime? Dt_troca
        {
            get { return dt_troca; }
            set
            {
                dt_troca = value;
                dt_trocastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_trocastr;
        public string Dt_trocastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_trocastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_trocastr = value;
                try
                {
                    dt_troca = Convert.ToDateTime(value);
                }
                catch
                { dt_troca = null; }
            }
        }
        public string TempoLocacao
        {
            get
            {
                if (!string.IsNullOrEmpty(dt_retiradastr) &&
                    !string.IsNullOrEmpty(dt_fechamentostr))
                {
                    TimeSpan result = dt_fechamento.Value.Subtract(dt_retirada.Value);
                    return (result.Days >= 1 ? Math.Round(double.Parse(result.Days.ToString()), 1).ToString() + " dia(s), " : string.Empty) +
                         (result.Hours >= 1 ? Math.Round(double.Parse(result.Hours.ToString()), 1) + " hora(s), " : string.Empty) +
                         (result.Minutes >= 1 ? Math.Round(double.Parse(result.Minutes.ToString()), 1).ToString() + " minuto(s)." : string.Empty);
                }
                else return string.Empty;
            }
        }
        public decimal Qtd_Patrimonio
        { get; set; }
        private string st_entrega;
        public string St_entrega
        {
            get { return st_entrega; }
            set
            {
                st_entrega = value;
                st_entregabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_entregabool;
        public bool St_entregabool
        {
            get { return st_entregabool; }
            set
            {
                st_entregabool = value;
                st_entrega = value ? "S" : "N";
            }
        }
        private string st_coleta;
        public string St_coleta
        {
            get { return st_coleta; }
            set
            {
                st_coleta = value;
                st_coletabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_coletabool;
        public bool St_coletabool
        {
            get { return st_coletabool; }
            set
            {
                st_coletabool = value;
                st_coleta = value ? "S" : "N";
            }
        }
        public string St_registro
        { get; set; }
        public bool St_baixa
        { get; set; }
        public bool St_processar
        { get; set; }

        public bool St_bloqItem
        { get; set; }

        public bool St_progEspecial
        { get; set; }

        public TList_AcessoriosItem lAcessorio
        { get; set; }
        public TList_AcessoriosItem lAcessoriosDel
        { get; set; }
        public CamadaDados.Servicos.TRegistro_LanServico rOs
        { get; set; }
        public string St_ItemLocado { get; set; }


        public TRegistro_ItensLocacao()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_itemloc = null;
            id_itemlocstr = string.Empty;
            Id_os = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_tabela = null;
            id_tabelastr = string.Empty;
            Ds_tabela = string.Empty;
            Tp_tabela = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_vendedor = string.Empty;
            Pc_AutorizadoDesc = decimal.Zero;
            Nr_Patrimonio = string.Empty;
            Codigo_Alternativo = string.Empty;
            Quantidade = decimal.Zero;
            Qtd_devolvida = decimal.Zero;
            Qtd_baixada = decimal.Zero;
            Qtd_devolver = decimal.Zero;
            QTDItem = decimal.Zero;
            Qtd_horasAtual = decimal.Zero;
            Qtd_horasRetirada = decimal.Zero;
            Qtd_horasDevolucao = decimal.Zero;
            st_controlehorabool = false;
            st_controlehora = "N";
            St_bloqItem = false;
            St_progEspecial = false;
            Vl_unitario = decimal.Zero;
            Vl_patrimonio = decimal.Zero;
            BaseCalc = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_acresc = decimal.Zero;
            Vl_acessorios = decimal.Zero;
            Vl_Baixa = decimal.Zero;
            Vl_frete = decimal.Zero;
            Tot_Faturado = decimal.Zero;
            Qtd_Patrimonio = decimal.Zero;
            dt_locacao = null;
            dt_locacaostr = null;
            dt_retirada = null;
            dt_retiradastr = string.Empty;
            dt_prevdev = null;
            dt_prevdevstr = string.Empty;
            dt_devolucao = null;
            dt_devolucaostr = string.Empty;
            dt_fechamento = null;
            dt_fechamentostr = string.Empty;
            dt_troca = null;
            dt_trocastr = string.Empty;
            st_entrega = "N";
            st_entregabool = false;
            st_coleta = "N";
            st_coletabool = false;
            St_registro = "A";
            St_baixa = false;
            St_processar = false;

            lAcessorio = new TList_AcessoriosItem();
            lAcessoriosDel = new TList_AcessoriosItem();
            rOs = new Servicos.TRegistro_LanServico();

            St_ItemLocado = string.Empty;
        }
    }

    public class TCD_ItensLocacao : TDataQuery
    {
        public TCD_ItensLocacao()
        { }

        public TCD_ItensLocacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo, bool St_colEnt)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.cd_clifor, a.nm_clifor, loc.Cd_vendedor, ");
                if (St_colEnt)
                {
                    sql.AppendLine("St_Entrega = CASE WHEN EXISTS(SELECT 1 FROM TB_LOC_ColetaEntrega x ");
                    sql.AppendLine("                              inner join TB_LOC_Vistoria_X_ColEnt y ");
                    sql.AppendLine("                              on x.CD_Empresa = y.CD_Empresa ");
                    sql.AppendLine("                              and x.ID_Coleta = y.ID_Coleta ");
                    sql.AppendLine("                              where y.CD_Empresa = a.CD_Empresa ");
                    sql.AppendLine("                              and y.ID_Locacao = a.ID_Locacao ");
                    sql.AppendLine("                              and isnull(loc.ST_Registro, 'A') <> 'C' ");
                    sql.AppendLine("                              and x.TP_Mov = 'E' ");
                    sql.AppendLine("                              and x.DT_RETORNO is null) then 'S' ELSE 'N' END, ");
                    sql.AppendLine("St_Coleta = CASE WHEN EXISTS(SELECT 1 FROM TB_LOC_ColetaEntrega x ");
                    sql.AppendLine("                              inner join TB_LOC_Vistoria_X_ColEnt y ");
                    sql.AppendLine("                              on x.CD_Empresa = y.CD_Empresa ");
                    sql.AppendLine("                              and x.ID_Coleta = y.ID_Coleta ");
                    sql.AppendLine("                              where y.CD_Empresa = a.CD_Empresa ");
                    sql.AppendLine("                              and isnull(loc.ST_Registro, 'A') = 'F' ");
                    sql.AppendLine("                              and isnull(loc.ST_Registro, 'A') <> 'C' ");
                    sql.AppendLine("                              and y.ID_Locacao = a.ID_Locacao ");
                    sql.AppendLine("                              and x.TP_Mov = 'C' ");
                    sql.AppendLine("                              and x.DT_RETORNO is null)  then 'S' ELSE 'N' end, ");
                }
                sql.AppendLine("a.id_locacao, a.id_itemloc, a.cd_produto, a.ds_produto, a.cd_grupo, a.ds_grupo, a.ID_Tabela, a.ds_tabela, a.TP_Tabela, ");
                sql.AppendLine("a.Nr_Patrimonio, b.Codigo_Alternativo, a.VL_Patrimonio, a.Base_Calc, a.vl_frete, a.vl_desconto, a.Vl_Acessorios, a.Vl_Baixa, a.Qtd_horasRetirada, a.Qtd_horasDevolucao, ");
                sql.AppendLine("a.quantidade, a.Qtd_devolvida, a.Qtd_baixada, a.QTDItem, a.vl_unitario, a.DT_Locacao, a.DT_Retirada, a.DT_PrevDev, a.DT_Devolucao, a.DT_Fechamento, a.Dt_Troca, ");
                sql.AppendLine("a.Qtd_horas, a.St_controleHora, a.QTD_Patrimonio, a.St_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_ItensLocacao a ");
            sql.AppendLine("inner join TB_LOC_Locacao loc ");
            sql.AppendLine("on a.cd_empresa = loc.cd_empresa ");
            sql.AppendLine("and a.id_locacao = loc.id_locacao ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaHistPatrimonio(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.cd_clifor, a.nm_clifor, loc.Cd_vendedor, loc.St_Entrega, loc.St_Coleta, ");
                sql.AppendLine("a.id_locacao, a.id_itemloc, a.cd_produto, a.ds_produto, a.cd_grupo, a.ds_grupo, a.ID_Tabela, a.ds_tabela, a.TP_Tabela, ");
                sql.AppendLine("a.Nr_Patrimonio, a.VL_Patrimonio, a.Base_Calc, a.vl_frete, a.vl_desconto, a.Vl_Acessorios, a.Vl_Baixa, a.Qtd_horasRetirada, a.Qtd_horasDevolucao, ");
                sql.AppendLine("a.quantidade, a.Qtd_devolvida, a.Qtd_baixada, a.QTDItem, a.vl_unitario, a.DT_Locacao, a.DT_Retirada, a.DT_PrevDev, a.DT_Devolucao, a.DT_Fechamento, ");
                sql.AppendLine("a.Qtd_horas, a.St_controleHora, a.QTD_Patrimonio, ");
                sql.AppendLine("Tot_Faturado = case when a.tp_tabela = '4' then ");
                sql.AppendLine("DBO.F_VL_FATURADOITEMLOC(A.CD_EMPRESA, A.ID_LOCACAO, A.id_itemloc) else ");
                sql.AppendLine("ISNULL((ISNULL(a.qtditem, 1) * (a.Base_Calc * (a.vl_unitario - ISNULL(a.vl_desconto, 0)))), 0) end " );
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_ItensLocacao a ");
            sql.AppendLine("inner join VTB_LOC_Locacao loc ");
            sql.AppendLine("on a.cd_empresa = loc.cd_empresa ");
            sql.AppendLine("and a.id_locacao = loc.id_locacao ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, false), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, false), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, false), null);
        }

        public TList_ItensLocacao Select(TpBusca[] vBusca, int vTop, string vNm_Campo, bool St_colEnt)
        {
            TList_ItensLocacao lista = new TList_ItensLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, St_colEnt));
                while (reader.Read())
                {
                    TRegistro_ItensLocacao reg = new TRegistro_ItensLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("Id_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabela")))
                        reg.Ds_tabela = reader.GetString(reader.GetOrdinal("ds_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tabela")))
                        reg.Tp_tabela = reader.GetString(reader.GetOrdinal("tp_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("Cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Patrimonio")))
                        reg.Nr_Patrimonio = reader.GetString(reader.GetOrdinal("NR_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Codigo_Alternativo = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_baixada")))
                        reg.Qtd_baixada = reader.GetDecimal(reader.GetOrdinal("Qtd_baixada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTDItem")))
                        reg.QTDItem = reader.GetDecimal(reader.GetOrdinal("QTDItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Patrimonio")))
                        reg.Qtd_Patrimonio = reader.GetDecimal(reader.GetOrdinal("QTD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Patrimonio")))
                        reg.Vl_patrimonio = reader.GetDecimal(reader.GetOrdinal("VL_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("VL_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("VL_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acessorios")))
                        reg.Vl_acessorios = reader.GetDecimal(reader.GetOrdinal("Vl_Acessorios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Baixa")))
                        reg.Vl_Baixa = reader.GetDecimal(reader.GetOrdinal("Vl_Baixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Base_Calc")))
                        reg.BaseCalc = reader.GetDecimal(reader.GetOrdinal("Base_Calc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("DT_Locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Retirada")))
                        reg.Dt_retirada = reader.GetDateTime(reader.GetOrdinal("DT_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevDev")))
                        reg.Dt_prevdev = reader.GetDateTime(reader.GetOrdinal("DT_PrevDev"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("DT_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Troca")))
                        reg.Dt_troca = reader.GetDateTime(reader.GetOrdinal("DT_Troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horasAtual = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_horasRetirada")))
                        reg.Qtd_horasRetirada = reader.GetDecimal(reader.GetOrdinal("Qtd_horasRetirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_horasDevolucao")))
                        reg.Qtd_horasDevolucao = reader.GetDecimal(reader.GetOrdinal("Qtd_horasDevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (St_colEnt)
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("st_entrega")))
                            reg.St_entrega = reader.GetString(reader.GetOrdinal("st_entrega"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_coleta")))
                            reg.St_coleta = reader.GetString(reader.GetOrdinal("st_coleta"));
                    }
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

        public TList_ItensLocacao SelectHistPatrimonio(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_ItensLocacao lista = new TList_ItensLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBuscaHistPatrimonio(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensLocacao reg = new TRegistro_ItensLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("Id_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabela")))
                        reg.Ds_tabela = reader.GetString(reader.GetOrdinal("ds_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tabela")))
                        reg.Tp_tabela = reader.GetString(reader.GetOrdinal("tp_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("Cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Patrimonio")))
                        reg.Nr_Patrimonio = reader.GetString(reader.GetOrdinal("NR_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_baixada")))
                        reg.Qtd_baixada = reader.GetDecimal(reader.GetOrdinal("Qtd_baixada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTDItem")))
                        reg.QTDItem = reader.GetDecimal(reader.GetOrdinal("QTDItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Patrimonio")))
                        reg.Qtd_Patrimonio = reader.GetDecimal(reader.GetOrdinal("QTD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Patrimonio")))
                        reg.Vl_patrimonio = reader.GetDecimal(reader.GetOrdinal("VL_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("VL_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("VL_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acessorios")))
                        reg.Vl_acessorios = reader.GetDecimal(reader.GetOrdinal("Vl_Acessorios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Baixa")))
                        reg.Vl_Baixa = reader.GetDecimal(reader.GetOrdinal("Vl_Baixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Base_Calc")))
                        reg.BaseCalc = reader.GetDecimal(reader.GetOrdinal("Base_Calc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("DT_Locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Retirada")))
                        reg.Dt_retirada = reader.GetDateTime(reader.GetOrdinal("DT_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevDev")))
                        reg.Dt_prevdev = reader.GetDateTime(reader.GetOrdinal("DT_PrevDev"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("DT_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horasAtual = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_horasRetirada")))
                        reg.Qtd_horasRetirada = reader.GetDecimal(reader.GetOrdinal("Qtd_horasRetirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_horasDevolucao")))
                        reg.Qtd_horasDevolucao = reader.GetDecimal(reader.GetOrdinal("Qtd_horasDevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_entrega")))
                        reg.St_entrega = reader.GetString(reader.GetOrdinal("st_entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_coleta")))
                        reg.St_coleta = reader.GetString(reader.GetOrdinal("st_coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Faturado")))
                        reg.Tot_Faturado = reader.GetDecimal(reader.GetOrdinal("Tot_Faturado"));

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

        public string Gravar(TRegistro_ItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(17);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_QTD_HORASRETIRADA", val.Qtd_horasRetirada);
            hs.Add("@P_QTD_HORASDEVOLUCAO", val.Qtd_horasDevolucao);
            hs.Add("@P_QTDITEM", val.QTDItem);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_DT_RETIRADA", val.Dt_retirada);
            hs.Add("@P_DT_PREVDEV", val.Dt_prevdev);
            hs.Add("@P_DT_DEVOLUCAO", val.Dt_devolucao);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);


            return executarProc("IA_LOC_ITENSLOCACAO", hs);
        }

        public string Excluir(TRegistro_ItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);

            return executarProc("EXCLUI_LOC_ITENSLOCACAO", hs);
        }

    }
    #endregion

    #region Painel Expedicao
    public class TList_PainelExp : List<TRegistro_PainelExp>, IComparer<TRegistro_PainelExp>
    {
        #region IComparer<TRegistro_PainelExp> Members
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

        public TList_PainelExp()
        { }

        public TList_PainelExp(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PainelExp value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PainelExp x, TRegistro_PainelExp y)
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

    public class TRegistro_PainelExp
    {
        public string Status
        { get; set; }
        public string st_registro
        { get; set; }
        public int Tot
        { get; set; }
        public List<CamadaDados.Locacao.TRegistro_ItensLocacao> lAgExpedicao
        { get; set; }
        public TList_ItensLocacao lDevExpirada
        { get; set; }
        public TList_ItensLocacao lEntExpirada
        { get; set; }
        public TList_ItensLocacao lEmEntrega
        { get; set; }
        public TList_ItensLocacao lEmColeta
        { get; set; }
        public TList_ItensLocacao lFechada
        { get; set; }
        public TList_ItensLocacao lAgEntregaa
        { get; set; }
        public TList_ItensLocacao lDispColeta
        { get; set; }
        public TList_ItensLocacao lAgColeta
        { get; set; }

        public TRegistro_PainelExp()
        {
            Status = string.Empty;
            st_registro = string.Empty;
            Tot = 0;

            lAgExpedicao = new List<CamadaDados.Locacao.TRegistro_ItensLocacao>();
            lDevExpirada = new TList_ItensLocacao();
            lEntExpirada = new TList_ItensLocacao();
            lEmEntrega = new TList_ItensLocacao();
            lEmColeta = new TList_ItensLocacao();
            lFechada = new TList_ItensLocacao();
            lAgEntregaa = new TList_ItensLocacao();
            lDispColeta = new TList_ItensLocacao();
            lAgColeta = new TList_ItensLocacao();
        }
    }

    public class TCD_PainelExp : TDataQuery
    {
        public TCD_PainelExp()
        { }

        public TCD_PainelExp(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("SELECT a.cd_empresa, a.STATUS, a.st_registro, COUNT(a.ID_LOCACAO) as Tot ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_Locacao a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("GROUP BY a.cd_empresa, a.STATUS, a.st_registro");
            sql.AppendLine("ORDER BY a.st_registro ");

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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PainelExp Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_PainelExp lista = new TList_PainelExp();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_PainelExp reg = new TRegistro_PainelExp();

                    if (!reader.IsDBNull(reader.GetOrdinal("STATUS")))
                        reg.Status = reader.GetString(reader.GetOrdinal("STATUS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot")))
                        reg.Tot = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Tot")));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.st_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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
    }
    #endregion

    #region LanDuplicata
    public class TList_Locacao_X_Duplicata : List<TRegistro_Locacao_X_Duplicata>
    { }


    public class TRegistro_Locacao_X_Duplicata
    {

        public decimal? Id_locacao
        { get; set; }

        public string Cd_empresa
        { get; set; }

        public decimal Nr_lancto
        { get; set; }
        public decimal Nr_recibo { get; set; } = decimal.Zero;

        public TRegistro_Locacao_X_Duplicata()
        {
            Id_locacao = decimal.Zero;
            Cd_empresa = string.Empty;
            Nr_lancto = decimal.Zero;
        }
    }

    public class TCD_Locacao_X_Duplicata : TDataQuery
    {
        public TCD_Locacao_X_Duplicata()
        { }

        public TCD_Locacao_X_Duplicata(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_locacao, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, a.Nr_Recibo ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_LOC_LOCACAO_X_DUPLICATA a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Locacao_X_Duplicata Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Locacao_X_Duplicata lista = new TList_Locacao_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Locacao_X_Duplicata reg = new TRegistro_Locacao_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Recibo")))
                        reg.Nr_recibo = reader.GetDecimal(reader.GetOrdinal("Nr_Recibo"));

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

        public string Gravar(TRegistro_Locacao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_NR_RECIBO", val.Nr_recibo);

            return executarProc("IA_LOC_LOCACAO_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Locacao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_LOC_LOCACAO_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region Parcelas
    public class TList_ParcelaLocacao : List<TRegistro_ParcelaLocacao>, IComparer<TRegistro_ParcelaLocacao>
    {
          #region IComparer<TRegistro_ParcelaLocacao> Members
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

        public TList_ParcelaLocacao()
        { }

        public TList_ParcelaLocacao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ParcelaLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ParcelaLocacao x, TRegistro_ParcelaLocacao y)
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

    public class TRegistro_ParcelaLocacao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }

        public string Cd_clifor
        { get; set; }

        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public decimal DiasVencto
        { get; set; }
        private DateTime? dt_locacao;

        public DateTime? Dt_locacao
        {
            get { return dt_locacao; }
            set
            {
                dt_locacao = value;
                dt_locacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_locacaostr;
        public string Dt_locacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_locacaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_locacaostr = value;
                try
                {
                    dt_locacao = Convert.ToDateTime(value);
                }
                catch
                { dt_locacao = null; }
            }
        }
        public DateTime Dt_vencto
        { get { return Dt_locacao.Value.AddDays(Convert.ToDouble(DiasVencto)); } }
        public decimal Vl_parcela
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal id_parcela
        { get; set; }
        private string st_faturado;
        public string St_faturado
        {
            get { return st_faturado; }
            set
            {
                st_faturado = value;
                st_faturadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_faturadobool;
        public bool St_faturadobool
        {
            get { return st_faturadobool; }
            set
            {
                st_faturadobool = value;
                st_faturado = value ? "S" : "N";
            }
        }
        public string StatusLocacao
        { get; set; }
        public string Recalcular
        {
            get
            {
                if (StatusLocacao.ToUpper().Equals("DEVOLUCAO EXPIRADA"))
                    return "DEVOLUÇÃO EXPIRADA: NECESSÁRIO RECALCULAR PARCELAS!";
                else return string.Empty;
            }
        }
        public bool St_processar
        { get; set; }


        public TRegistro_ParcelaLocacao()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            DiasVencto = decimal.Zero;
            dt_locacao = null;
            dt_locacaostr = string.Empty;
            Vl_parcela = decimal.Zero;
            Vl_comissao = decimal.Zero;
            id_parcela = decimal.Zero;
            StatusLocacao = string.Empty;
            st_faturado = "N";
            st_faturadobool = false;
            St_processar = false;
        }
    }

    public class TCD_ParcelaLocacao : TDataQuery
    {
        public TCD_ParcelaLocacao()
        { }

        public TCD_ParcelaLocacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, b.cd_clifor, b.nm_clifor, b.cd_endereco, b.ds_endereco, a.id_locacao, b.dt_locacao, ");
                sql.AppendLine("a.diavencto, a.vl_parcela, a.Vl_comissao, a.st_faturado, b.Status ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_PARCELALOCACAO a ");
            sql.AppendLine("inner join VTB_LOC_Locacao b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_locacao = b.id_locacao ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ParcelaLocacao Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ParcelaLocacao lista = new TList_ParcelaLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ParcelaLocacao reg = new TRegistro_ParcelaLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("Cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("Ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("Id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diavencto")))
                        reg.DiasVencto = reader.GetDecimal(reader.GetOrdinal("diavencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("dt_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_parcela")))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("vl_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_parcela")))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("vl_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("Vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_faturado")))
                        reg.St_faturado = reader.GetString(reader.GetOrdinal("St_faturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.StatusLocacao = reader.GetString(reader.GetOrdinal("Status"));

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

        public string Gravar(TRegistro_ParcelaLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_DIAVENCTO", val.DiasVencto);
            hs.Add("@P_ST_FATURADO", val.St_faturado);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);
            hs.Add("@P_VL_COMISSAO", val.Vl_comissao);

            return executarProc("IA_LOC_PARCELALOCACAO", hs);
        }

        public string Excluir(TRegistro_ParcelaLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_DIAVENCTO", val.DiasVencto);

            return executarProc("EXCLUI_LOC_PARCELALOCACAO", hs);
        }
    }
    #endregion                   '

    #region Adto Locacao
    public class TList_AdtoLocacao : List<TRegistro_AdtoLocacao>
    { }


    public class TRegistro_AdtoLocacao
    {

        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }

        public string Cd_empresa
        { get; set; }

        private decimal? id_adto;

        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;

        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = Convert.ToDecimal(value);
                }
                catch
                { id_adto = null; }
            }
        }

        public TRegistro_AdtoLocacao()
        {
            Id_locacao = null;
            Id_locacaostr = string.Empty;
            Cd_empresa = string.Empty;
            Id_adto = null;
            Id_adtostr = string.Empty;
        }
    }

    public class TCD_AdtoLocacao : TDataQuery
    {
        public TCD_AdtoLocacao()
        { }

        public TCD_AdtoLocacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_locacao, ");
                sql.AppendLine("a.cd_empresa, a.Id_adto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_LOC_AdtoLocacao a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AdtoLocacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_AdtoLocacao lista = new TList_AdtoLocacao();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AdtoLocacao reg = new TRegistro_AdtoLocacao();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("Id_adto"));

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

        public string Gravar(TRegistro_AdtoLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ADTO", val.Id_adto);

            return executarProc("IA_LOC_ADTOLOCACAO", hs);
        }

        public string Excluir(TRegistro_AdtoLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ADTO", val.Id_adto);

            return executarProc("EXCLUI_LOC_ADTOLOCACAO", hs);
        }
    }
    #endregion

    #region Devolução Itens Locacao
    public class TList_DevItensLocacao : List<TRegistro_DevItensLocacao>, IComparer<TRegistro_DevItensLocacao>
    {

        #region IComparer<TRegistro_DevItensLocacao> Members
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

        public TList_DevItensLocacao()
        { }

        public TList_DevItensLocacao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DevItensLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DevItensLocacao x, TRegistro_DevItensLocacao y)
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


    public class TRegistro_DevItensLocacao
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }
        private decimal? id_devolucao;

        public decimal? Id_devolucao
        {
            get { return id_devolucao; }
            set
            {
                id_devolucao = value;
                id_devolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devolucaostr;

        public string Id_devolucaostr
        {
            get { return id_devolucaostr; }
            set
            {
                id_devolucaostr = value;
                try
                {
                    id_devolucao = Convert.ToDecimal(value);
                }
                catch
                { id_devolucao = null; }
            }
        }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Qtd_baixada
        { get; set; }



        public TRegistro_DevItensLocacao()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_itemloc = null;
            id_itemlocstr = string.Empty;
            id_devolucao = null;
            id_devolucaostr = string.Empty;
            Qtd_devolvida = decimal.Zero;
            Qtd_baixada = decimal.Zero;
        }
    }

    public class TCD_DevItensLocacao : TDataQuery
    {
        public TCD_DevItensLocacao()
        { }

        public TCD_DevItensLocacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_locacao, a.id_itemloc, a.id_devolucao, ");
                sql.AppendLine("a.qtd_devolvida, a.qtd_baixada ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_DevItensLocacao a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_DevItensLocacao Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_DevItensLocacao lista = new TList_DevItensLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_DevItensLocacao reg = new TRegistro_DevItensLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("id_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_baixada")))
                        reg.Qtd_baixada = reader.GetDecimal(reader.GetOrdinal("Qtd_baixada"));

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

        public string Gravar(TRegistro_DevItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_QTD_DEVOLVIDA", val.Qtd_devolvida);
            hs.Add("@P_QTD_BAIXADA", val.Qtd_baixada);

            return executarProc("IA_LOC_DEVITENSLOCACAO", hs);
        }

        public string Excluir(TRegistro_DevItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);

            return executarProc("EXCLUI_LOC_DEVITENSLOCACAO", hs);
        }

    }
    #endregion

    #region Contrato Locacao
    public class TList_Contrato : List<TRegistro_Contrato>
    { }


    public class TRegistro_Contrato
    {

        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }

        public string Cd_empresa
        { get; set; }

        private decimal? id_contrato;

        public decimal? Id_contrato
        {
            get { return id_contrato; }
            set
            {
                id_contrato = value;
                id_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_contratostr;

        public string Id_contratostr
        {
            get { return id_contratostr; }
            set
            {
                id_contratostr = value;
                try
                {
                    id_contrato = Convert.ToDecimal(value);
                }
                catch
                { id_contrato = null; }
            }
        }
        private decimal? nr_contrato;

        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;

        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        public string Logincanc
        { get; set; }
        private DateTime? dt_contrato;

        public DateTime? Dt_contrato
        {
            get { return dt_contrato; }
            set
            {
                dt_contrato = value;
                dt_contratostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_contratostr;
        public string Dt_contratostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_contratostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_contratostr = value;
                try
                {
                    dt_contrato = Convert.ToDateTime(value);
                }
                catch
                { dt_contrato = null; }
            }
        }
        private DateTime? dt_cancelamento;

        public DateTime? Dt_cancelamento
        {
            get { return dt_cancelamento; }
            set
            {
                dt_cancelamento = value;
                dt_cancelamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_cancelamentostr;
        public string Dt_cancelamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cancelamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_cancelamentostr = value;
                try
                {
                    dt_cancelamento = Convert.ToDateTime(value);
                }
                catch
                { dt_cancelamento = null; }
            }
        }
        public string MotivoCanc
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else
                    return "CANCELADO";
            }
        }
        public string Obs
        { get; set; }

        public TRegistro_Contrato()
        {
            Id_locacao = null;
            Id_locacaostr = string.Empty;
            Cd_empresa = string.Empty;
            Id_contrato = null;
            Id_contratostr = string.Empty;
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Logincanc = string.Empty;
            dt_contrato = null;
            dt_contratostr = string.Empty;
            dt_cancelamento = null;
            dt_cancelamentostr = string.Empty;
            MotivoCanc = string.Empty;
            St_registro = "A";
            Obs = string.Empty;
        }
    }

    public class TCD_Contrato : TDataQuery
    {
        public TCD_Contrato()
        { }

        public TCD_Contrato(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_locacao, a.cd_empresa, a.ID_Contrato, a.NR_Contrato, ");
                sql.AppendLine("a.LoginCanc,  a.DT_Contrato, a.DT_Cancelamento, a.MotivoCanc, a.Obs, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_LOC_Contrato a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Contrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Contrato lista = new TList_Contrato();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato reg = new TRegistro_Contrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Contrato")))
                        reg.Id_contrato = reader.GetDecimal(reader.GetOrdinal("ID_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        reg.Logincanc = reader.GetString(reader.GetOrdinal("LoginCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Contrato")))
                        reg.Dt_contrato = reader.GetDateTime(reader.GetOrdinal("DT_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cancelamento")))
                        reg.Dt_cancelamento = reader.GetDateTime(reader.GetOrdinal("DT_Cancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONTRATO", val.Id_contrato);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_LOGINCANC", val.Logincanc);
            hs.Add("@P_DT_CONTRATO", val.Dt_contrato);
            hs.Add("@P_DT_CANCELAMENTO", val.Dt_cancelamento);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_LOC_CONTRATO", hs);
        }

        public string Excluir(TRegistro_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONTRATO", val.Id_contrato);

            return executarProc("EXCLUI_LOC_CONTRATO", hs);
        }
    }
    #endregion

    #region Itens Troca
    public class TList_ItensTroca : List<TRegistro_ItensTroca>, IComparer<TRegistro_ItensTroca>
    {

        #region IComparer<TRegistro_ItensTroca> Members
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

        public TList_ItensTroca()
        { }

        public TList_ItensTroca(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensTroca value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensTroca x, TRegistro_ItensTroca y)
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


    public class TRegistro_ItensTroca
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }
        private decimal? id_itemlocDest;

        public decimal? Id_itemlocDest
        {
            get { return id_itemlocDest; }
            set
            {
                id_itemlocDest = value;
                id_itemlocDeststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocDeststr;

        public string Id_itemlocDeststr
        {
            get { return id_itemlocDeststr; }
            set
            {
                id_itemlocDeststr = value;
                try
                {
                    id_itemlocDest = Convert.ToDecimal(value);
                }
                catch
                { id_itemlocDest = null; }
            }
        }
        private DateTime? dt_troca;

        public DateTime? Dt_troca
        {
            get { return dt_troca; }
            set
            {
                dt_troca = value;
                dt_trocastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_trocastr;
        public string Dt_trocastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_trocastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_trocastr = value;
                try
                {
                    dt_troca = Convert.ToDateTime(value);
                }
                catch
                { dt_troca = null; }
            }
        }


        public TRegistro_ItensTroca()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_itemloc = null;
            id_itemlocstr = string.Empty;
            id_itemlocDest = null;
            id_itemlocDeststr = string.Empty;
            dt_troca = null;
            dt_trocastr = string.Empty;
        }
    }

    public class TCD_ItensTroca : TDataQuery
    {
        public TCD_ItensTroca()
        { }

        public TCD_ItensTroca(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_locacao, a.id_itemloc, a.id_itemlocDest, a.dt_cad ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_ItensTroca a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ItensTroca Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensTroca lista = new TList_ItensTroca();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensTroca reg = new TRegistro_ItensTroca();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemlocdest")))
                        reg.Id_itemlocDest = reader.GetDecimal(reader.GetOrdinal("id_itemlocdest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cad")))
                        reg.Dt_troca = reader.GetDateTime(reader.GetOrdinal("dt_cad"));

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

        public string Gravar(TRegistro_ItensTroca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ITEMLOCDEST", val.Id_itemlocDest);

            return executarProc("IA_LOC_ITENSTROCA", hs);
        }

        public string Excluir(TRegistro_ItensTroca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ITEMLOCDEST", val.Id_itemlocDest);

            return executarProc("EXCLUI_LOC_ITENSTROCA", hs);
        }

    }
    #endregion

    #region Historico
    public class TList_Historico : List<TRegistro_Historico>, IComparer<TRegistro_Historico>
    {

        #region IComparer<TRegistro_Historico> Members
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

        public TList_Historico()
        { }

        public TList_Historico(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Historico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Historico x, TRegistro_Historico y)
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


    public class TRegistro_Historico
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_historico;

        public decimal? Id_historico
        {
            get { return id_historico; }
            set
            {
                id_historico = value;
                id_historicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_historicostr;

        public string Id_historicostr
        {
            get { return id_historicostr; }
            set
            {
                id_historicostr = value;
                try
                {
                    id_historico = Convert.ToDecimal(value);
                }
                catch
                { id_historico = null; }
            }
        }
        public string Login
        { get; set; }
        public string Ds_historico
        { get; set; }
        private DateTime? dt_historico;

        public DateTime? Dt_historico
        {
            get { return dt_historico; }
            set
            {
                dt_historico = value;
                dt_historicostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_historicostr;
        public string Dt_historicostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_historicostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_historicostr = value;
                try
                {
                    dt_historico = Convert.ToDateTime(value);
                }
                catch
                { dt_historico = null; }
            }
        }


        public TRegistro_Historico()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_historico = null;
            id_historicostr = string.Empty;
            Login = string.Empty;
            Ds_historico = string.Empty;
            dt_historico = null;
            dt_historicostr = string.Empty;
        }
    }

    public class TCD_Historico : TDataQuery
    {
        public TCD_Historico()
        { }

        public TCD_Historico(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_Historico, a.Login, a.DS_Historico, a.DT_Historico ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_Historico a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Historico Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Historico lista = new TList_Historico();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Historico reg = new TRegistro_Historico();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Historico")))
                        reg.Id_historico = reader.GetDecimal(reader.GetOrdinal("ID_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Historico")))
                        reg.Dt_historico = reader.GetDateTime(reader.GetOrdinal("DT_Historico"));

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

        public string Gravar(TRegistro_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_HISTORICO", val.Id_historico);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_HISTORICO", val.Ds_historico);
            hs.Add("@P_DT_HISTORICO", val.Dt_historico);

            return executarProc("IA_LOC_HISTORICO", hs);
        }

        public string Excluir(TRegistro_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_HISTORICO", val.Id_historico);

            return executarProc("EXCLUI_LOC_HISTORICO", hs);
        }

    }
    #endregion

    #region Historico
    public class TList_OutrasDesp : List<TRegistro_OutrasDesp>, IComparer<TRegistro_OutrasDesp>
    {

        #region IComparer<TRegistro_OutrasDesp> Members
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

        public TList_OutrasDesp()
        { }

        public TList_OutrasDesp(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OutrasDesp value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OutrasDesp x, TRegistro_OutrasDesp y)
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


    public class TRegistro_OutrasDesp
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_despesa;

        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;

        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = Convert.ToDecimal(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Login
        { get; set; }
        public string Ds_despesa
        { get; set; }
        private DateTime? dt_despesa;

        public DateTime? Dt_despesa
        {
            get { return dt_despesa; }
            set
            {
                dt_despesa = value;
                dt_despesastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_despesastr;
        public string Dt_despesastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_despesastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_despesastr = value;
                try
                {
                    dt_despesa = Convert.ToDateTime(value);
                }
                catch
                { dt_despesa = null; }
            }
        }
        public decimal Vl_despesa
        { get; set; }


        public TRegistro_OutrasDesp()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Login = string.Empty;
            Ds_despesa = string.Empty;
            dt_despesa = null;
            dt_despesastr = string.Empty;
        }
    }

    public class TCD_OutrasDesp : TDataQuery
    {
        public TCD_OutrasDesp()
        { }

        public TCD_OutrasDesp(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_despesa, a.Login, a.DS_despesa, a.DT_despesa, a.vl_despesa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_OutrasDesp a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OutrasDesp Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_OutrasDesp lista = new TList_OutrasDesp();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_OutrasDesp reg = new TRegistro_OutrasDesp();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("ID_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("DS_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_despesa")))
                        reg.Dt_despesa = reader.GetDateTime(reader.GetOrdinal("DT_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_despesa")))
                        reg.Vl_despesa = reader.GetDecimal(reader.GetOrdinal("Vl_despesa"));

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

        public string Gravar(TRegistro_OutrasDesp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_DESPESA", val.Ds_despesa);
            hs.Add("@P_DT_DESPESA", val.Dt_despesa);
            hs.Add("@P_VL_DESPESA", val.Vl_despesa);

            return executarProc("IA_LOC_OUTRASDESP", hs);
        }

        public string Excluir(TRegistro_OutrasDesp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);

            return executarProc("EXCLUI_LOC_OUTRASDESP", hs);
        }

    }
    #endregion
}
