using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    #region Caixa PDV
    public class TList_CaixaPDV : List<TRegistro_CaixaPDV>, IComparer<TRegistro_CaixaPDV>
    {
        #region IComparer<TRegistro_CaixaPDV> Members
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

        public TList_CaixaPDV()
        { }

        public TList_CaixaPDV(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CaixaPDV value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CaixaPDV x, TRegistro_CaixaPDV y)
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

    public class TList_MovCaixa : List<TRegistro_MovCaixa>, IComparer<TRegistro_MovCaixa>
    {
        #region IComparer<TRegistro_CaixaPDV> Members
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

        public TList_MovCaixa()
        { }

        public TList_MovCaixa(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovCaixa x, TRegistro_MovCaixa y)
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

    public class TRegistro_CaixaPDV
    {
        private decimal? id_caixa;
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = Convert.ToDecimal(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        public string Login
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private DateTime? dt_abertura;
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = Convert.ToDateTime(value);
                }
                catch
                { dt_abertura = null; }
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
        private DateTime? dt_auditado;
        public DateTime? Dt_auditado
        {
            get { return dt_auditado; }
            set
            {
                dt_auditado = value;
                dt_auditadostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_auditadostr;
        public string Dt_auditadostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_auditadostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_auditadostr = value;
                try
                {
                    dt_auditado = Convert.ToDateTime(value);
                }
                catch
                { dt_auditado = null; }
            }
        }
        public decimal Vl_abertura
        { get; set; }
        public decimal Vl_movimento
        { get; set; }
        public decimal Vl_credavulso
        { get; set; }
        public decimal Vl_fechamento
        { get; set; }
        public decimal Vl_auditado
        { get; set; }
        public decimal Vl_transportar
        { get; set; }
        public decimal Vl_retirada
        { get; set; }
        public decimal Vl_suprimento
        { get; set; }
        public decimal Vl_emprestimo
        { get; set; }
        public decimal Vl_devcredito
        { get; set; }
        public decimal Vl_troco
        { get; set; }
        public decimal VL_Pago
        { get; set; }
        public decimal VL_Recebido
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        //Campos calculados
        public decimal Vl_liquido
        { get { return Vl_movimento + Vl_suprimento + Vl_credavulso - Vl_transportar - Vl_troco - Vl_devcredito - Vl_retirada - Vl_emprestimo - VL_Pago; } }
        public decimal Vl_diferencaAudit
        { get { return Vl_auditado - Vl_liquido; } }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FECHADO";
                else if (St_registro.Trim().ToUpper().Equals("D"))
                    return "AUDITADO";
                else if (St_registro.Trim().ToUpper().Equals("P"))
                    return "PROCESSADO";
                else return string.Empty;
            }
        }
        public bool St_valortransportar { get; set; } = false;
        public TRegistro_Lan_Transfere_Caixa rTransf
        { get; set; }
        public TList_RetiradaCaixa lRetiradas
        { get; set; }
        public List<TRegistro_CadPortador> lPorFecharCaixa
        { get; set; }
        public TList_FechamentoCaixa lFechamentoCaixa
        { get; set; }

        public TRegistro_CaixaPDV()
        {
            id_caixa = null;
            id_caixastr = string.Empty;
            Login = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            dt_abertura = null;
            dt_aberturastr = string.Empty;
            dt_fechamento = null;
            dt_fechamentostr = string.Empty;
            dt_auditado = null;
            dt_auditadostr = string.Empty;
            Vl_abertura = decimal.Zero;
            Vl_transportar = decimal.Zero;
            Vl_movimento = decimal.Zero;
            Vl_fechamento = decimal.Zero;
            Vl_auditado = decimal.Zero;
            Vl_retirada = decimal.Zero;
            Vl_suprimento = decimal.Zero;
            Vl_emprestimo = decimal.Zero;
            Vl_devcredito = decimal.Zero;
            Vl_troco = decimal.Zero;
            VL_Pago = decimal.Zero;
            VL_Recebido = decimal.Zero;
            Vl_desconto = decimal.Zero;
            St_registro = "A";
            rTransf = null;
            lRetiradas = new TList_RetiradaCaixa();
            lPorFecharCaixa = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
            lFechamentoCaixa = new TList_FechamentoCaixa();
        }
    }

    public class TCD_CaixaPDV : TDataQuery
    {
        public TCD_CaixaPDV()
        { }

        public TCD_CaixaPDV(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Caixa, a.DT_Abertura, a.dt_auditado, ");
                sql.AppendLine("a.DT_Fechamento, a.Vl_Transportar, a.ST_Registro, a.login, ");
                sql.AppendLine("a.cd_empresa, c.nm_empresa, a.vl_credavulso, a.vl_emprestimo, ");
                sql.AppendLine("a.vl_fechamento, a.vl_movimento, a.vl_auditado, a.Vl_DevCredito, ");
                sql.AppendLine("a.vl_credavulso, a.vl_retirada, a.vl_suprimento, a.vl_troco, ");
                sql.AppendLine("a.vl_pago, a.vl_recebido, a.vl_desconto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_Caixa a ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaMovCaixa(Utils.TpBusca[] vBusca, string vNM_Campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select a.cd_empresa, a.nm_empresa, a.id_cupom, a.id_movimento, ");
                sql.AppendLine("a.cd_portador, a.id_caixa, a.ds_portador, a.nm_clifor, ");
                sql.AppendLine("a.ds_bandeira, a.tp_cartao, a.vl_cupom, a.vl_recebido, a.vl_troco_dh, ");
                sql.AppendLine("a.vl_troco_ch, a.vl_devcredito, a.vl_credito, a.vl_pago, a.NR_Autorizacao, a.DS_Maquina, ");
                sql.AppendLine("c.ST_ControleTitulo, c.ST_CartaoCredito, c.ST_CartaFrete, c.ST_DevCredito, c.TP_PortadorPDV ");
            }
            else sql.AppendLine("select " + vNM_Campo.Trim());

            sql.AppendLine("from vtb_pdv_movcaixa a ");
            sql.AppendLine("inner join tb_pdv_caixa b ");
            sql.AppendLine("on a.id_caixa = b.id_caixa ");
            sql.AppendLine("inner join tb_fin_portador c ");
            sql.AppendLine("on a.cd_portador = c.cd_portador ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public string SqlCodeBuscaMovCaixaPortador(Utils.TpBusca[] vBusca, string vOrder, int vTop)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select " + strTop + " a.CD_Empresa, a.NM_Empresa, a.CD_Portador, a.DS_Portador, a.DT_Lancto, a.Vl_Recebido, a.vl_pago ");

            sql.AppendLine("from VTB_PDV_MOVCAIXAPORTADOR a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        private string SqlCodeBuscaResumoCartao(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_Bandeira, a.DS_Bandeira, a.TP_Cartao, SUM(ISNULL(A.VL_MOVIMENTO, 0)) as Vl_Movimento ");

            sql.AppendLine("from VTB_PDV_ResumoCartao a ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by a.ID_Bandeira, a.DS_Bandeira, a.TP_Cartao ");

            return sql.ToString();
        }

        //private string SqlCodeBuscaVendaPortador(Utils.TpBusca[] vBusca, string vNM_Campo)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.AppendLine("select * ");

        //    sql.AppendLine("from VTB_PDV_VENDAS_X_PORTADOR a ");

        //    string cond = " where ";
        //    if (vBusca != null)
        //        for (int i = 0; i < (vBusca.Length); i++)
        //        {
        //            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
        //            cond = " and ";
        //        }

        //    return sql.ToString();
        //}

        private string SqlCodeBuscaExtratoCaixa(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.DT_Cad as DT_Lancto, a.ID_Caixa, ");
            sql.AppendLine("a.CD_Empresa, b.NM_Empresa, a.NM_Clifor, ");
            sql.AppendLine("a.Docto, a.DS_Portador, a.Vl_RECEBER ");

            sql.AppendLine("from VTB_PDV_EXTRATOCAIXA a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("order by a.DT_Cad asc ");

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

        public object BuscarEscalarMovCaixa(Utils.TpBusca[] filtro, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBuscaMovCaixa(filtro, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_CaixaPDV Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CaixaPDV lista = new TList_CaixaPDV();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CaixaPDV reg = new TRegistro_CaixaPDV();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));
                    if(!reader.IsDBNull(reader.GetOrdinal("dt_auditado")))
                        reg.Dt_auditado = reader.GetDateTime(reader.GetOrdinal("dt_auditado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Transportar")))
                        reg.Vl_transportar = reader.GetDecimal(reader.GetOrdinal("vl_transportar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_movimento")))
                        reg.Vl_movimento = reader.GetDecimal(reader.GetOrdinal("vl_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_fechamento")))
                        reg.Vl_fechamento = reader.GetDecimal(reader.GetOrdinal("vl_fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_auditado")))
                        reg.Vl_auditado = reader.GetDecimal(reader.GetOrdinal("vl_auditado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_credavulso")))
                        reg.Vl_credavulso = reader.GetDecimal(reader.GetOrdinal("vl_credavulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_retirada")))
                        reg.Vl_retirada = reader.GetDecimal(reader.GetOrdinal("vl_retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_suprimento")))
                        reg.Vl_suprimento = reader.GetDecimal(reader.GetOrdinal("vl_suprimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_emprestimo")))
                        reg.Vl_emprestimo = reader.GetDecimal(reader.GetOrdinal("vl_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_troco")))
                        reg.Vl_troco = reader.GetDecimal(reader.GetOrdinal("vl_troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pago")))
                        reg.VL_Pago = reader.GetDecimal(reader.GetOrdinal("vl_pago"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_recebido")))
                        reg.VL_Recebido = reader.GetDecimal(reader.GetOrdinal("vl_recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DevCredito")))
                        reg.Vl_devcredito = reader.GetDecimal(reader.GetOrdinal("Vl_DevCredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_desconto"));
                    
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

        public TList_CaixaPDV SelectCaixaAbertoLogin(string Login)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_Caixa, a.Login, a.CD_Empresa, a.DT_Abertura, ")
                .AppendLine("a.DT_Fechamento, a.DT_Auditado, a.Vl_Transportar, a.ST_Registro ")
                .AppendLine("from TB_PDV_Caixa a ")
                .AppendLine("where isnull(a.st_registro, 'A') = 'A' ")
                .AppendLine("and a.login = '" + Login.Trim() + "'");

            bool podeFecharBco = false;
            TList_CaixaPDV lista = new TList_CaixaPDV();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_CaixaPDV reg = new TRegistro_CaixaPDV();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("DT_Fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_auditado")))
                        reg.Dt_auditado = reader.GetDateTime(reader.GetOrdinal("dt_auditado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Transportar")))
                        reg.Vl_transportar = reader.GetDecimal(reader.GetOrdinal("vl_transportar"));
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

        public List<TRegistro_MovCaixa> SelectMovCaixa(Utils.TpBusca[] vBusca, string vOrder)
        {
            bool podeFecharBco = false;
            List<TRegistro_MovCaixa> lista = new List<TRegistro_MovCaixa>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaMovCaixa(vBusca, string.Empty, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovCaixa reg = new TRegistro_MovCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("id_movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bandeira")))
                        reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("ds_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_autorizacao")))
                        reg.Nr_autorizacao = reader.GetString(reader.GetOrdinal("nr_autorizacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_maquina")))
                        reg.Ds_maquina = reader.GetString(reader.GetOrdinal("ds_maquina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("tp_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ControleTitulo")))
                        reg.St_controletitulo = reader.GetString(reader.GetOrdinal("ST_ControleTitulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_CartaoCredito")))
                        reg.St_cartaocredito = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_cartaocredito"))).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_CartaFrete")))
                        reg.St_cartafrete = reader.GetString(reader.GetOrdinal("ST_CartaFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_DevCredito")))
                        reg.St_devcredito = reader.GetString(reader.GetOrdinal("ST_DevCredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_portadorpdv")))
                        reg.Tp_portadorpdv = reader.GetString(reader.GetOrdinal("tp_portadorpdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("Vl_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Recebido")))
                        reg.Vl_recebido = reader.GetDecimal(reader.GetOrdinal("Vl_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pago")))
                        reg.Vl_pago = reader.GetDecimal(reader.GetOrdinal("vl_pago"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devcredito")))
                        reg.Vl_DevCredito = reader.GetDecimal(reader.GetOrdinal("vl_devcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Troco_dh")))
                        reg.Vl_troco_dh = reader.GetDecimal(reader.GetOrdinal("Vl_Troco_dh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Troco_ch")))
                        reg.Vl_troco_ch = reader.GetDecimal(reader.GetOrdinal("Vl_Troco_ch"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_credito")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("vl_credito"));

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

        public TList_MovCaixa SelectMovCaixaPortador(Utils.TpBusca[] vBusca, string vOrder, int vTop = 0)
        {
            bool podeFecharBco = false;
            TList_MovCaixa lista = new TList_MovCaixa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaMovCaixaPortador(vBusca, vOrder, vTop));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovCaixa reg = new TRegistro_MovCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Recebido")))
                        reg.Vl_recebido = reader.GetDecimal(reader.GetOrdinal("Vl_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pago")))
                        reg.Vl_pago = reader.GetDecimal(reader.GetOrdinal("vl_pago"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));

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

        public List<TRegistro_ResumoCartao> SelectResumoCartao(Utils.TpBusca[] vBusca)
        {
            bool podeFecharBco = false;
            List<TRegistro_ResumoCartao> lista = new List<TRegistro_ResumoCartao>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaResumoCartao(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ResumoCartao reg = new TRegistro_ResumoCartao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Bandeira"))))
                        reg.Id_bandeira = reader.GetDecimal(reader.GetOrdinal("ID_Bandeira"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Bandeira"))))
                        reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("DS_Bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("TP_Cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_movimento")))
                        reg.Vl_movimento = reader.GetDecimal(reader.GetOrdinal("Vl_movimento"));

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

        public List<TRegistro_ExtratoCaixa> SelectExtratoCaixa(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            List<TRegistro_ExtratoCaixa> lista = new List<TRegistro_ExtratoCaixa>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaExtratoCaixa(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ExtratoCaixa reg = new TRegistro_ExtratoCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lancto"))))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Docto")))
                        reg.Docto = reader.GetString(reader.GetOrdinal("Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_RECEBER")))
                        reg.Vl_receber = reader.GetDecimal(reader.GetOrdinal("Vl_RECEBER"));

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

        //public List<TRegistro_MovCaixa> SelectVendaPortador(Utils.TpBusca[] vBusca, short vTop)
        //{

        //}

        public string Gravar(TRegistro_CaixaPDV val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_VL_TRANSPORTAR", val.Vl_transportar);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDV_CAIXA", hs);
        }

        public string Excluir(TRegistro_CaixaPDV val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);

            return executarProc("EXCLUI_PDV_CAIXA", hs);
        }
    }
    #endregion

    #region Fechamento Caixa
    public class TList_FechamentoCaixa : List<TRegistro_FechamentoCaixa>, IComparer<TRegistro_FechamentoCaixa>
    {
        #region IComparer<TRegistro_FechamentoCaixa> Members
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

        public TList_FechamentoCaixa()
        { }

        public TList_FechamentoCaixa(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FechamentoCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FechamentoCaixa x, TRegistro_FechamentoCaixa y)
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

    
    public class TRegistro_FechamentoCaixa
    {
        private decimal? id_caixa;
        
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        private decimal? id_transf;
        
        public decimal? Id_transf
        {
            get { return id_transf; }
            set
            {
                id_transf = value;
                id_transfstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_transfstr;
        
        public string Id_transfstr
        {
            get { return id_transfstr; }
            set
            {
                id_transfstr = value;
                try
                {
                    id_transf = decimal.Parse(value);
                }
                catch
                { id_transf = null; }
            }
        }
        
        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }
        
        public string Loginaudit
        { get; set; }
        
        public bool St_cartao
        { get; set; }
        
        public bool St_cheque
        { get; set; }
        
        public decimal Vl_fechamento
        { get; set; }
        
        public decimal Vl_auditado
        { get; set; }
        
        public decimal Vl_movimento
        { get; set; }
        
        public decimal Vl_retirada
        { get; set; }
        
        public decimal Vl_suprimento
        { get; set; }
        
        public decimal Vl_emprestimo
        { get; set; }
        
        public decimal Vl_cupom
        { get; set; }
        
        public decimal Vl_recebido
        { get; set; }
        
        public decimal Vl_pago
        { get; set; }
        
        public decimal Vl_devCredito
        { get; set; }
        
        public decimal Vl_troco
        { get; set; }
        
        public decimal Vl_transportar
        { get; set; }
        public decimal Vl_liquido
        { get { return Vl_recebido + Vl_credAvulso + Vl_suprimento - (St_cartao || St_cheque ? 0 : Vl_pago) - Vl_devCredito - Vl_troco - Vl_retirada - Vl_transportar - Vl_emprestimo; } }
        public decimal Vl_diferenca
        { get { return Vl_fechamento - Vl_liquido; } }
        public decimal Vl_diferencaAudit
        { get { return Vl_auditado - Vl_liquido; } }
        
        public decimal Vl_credito
        { get; set; }
        
        public decimal Vl_credAvulso
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        
        public string Ds_observacao
        { get; set; }

        public TRegistro_FechamentoCaixa()
        {
            id_caixa = null;
            id_caixastr = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            id_transf = null;
            id_transfstr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            Loginaudit = string.Empty;
            St_cartao = false;
            St_cheque = false;
            Vl_fechamento = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_recebido = decimal.Zero;
            Vl_pago = decimal.Zero;
            Vl_devCredito = decimal.Zero;
            Vl_troco = decimal.Zero;
            Vl_auditado = decimal.Zero;
            Vl_movimento = decimal.Zero;
            Vl_retirada = decimal.Zero;
            Vl_suprimento = decimal.Zero;
            Vl_emprestimo = decimal.Zero;
            Vl_credito = decimal.Zero;
            Vl_credAvulso = decimal.Zero;
            St_registro = "A";
            Ds_observacao = string.Empty;
        }
    }

    public class TCD_FechamentoCaixa : TDataQuery
    {
        public TCD_FechamentoCaixa()
        { }

        public TCD_FechamentoCaixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Caixa, a.CD_Portador, ");
                sql.AppendLine("b.DS_Portador, a.Vl_Fechamento, a.vl_cupom, a.vl_transportar, ");
                sql.AppendLine("a.vl_recebido, a.vl_pago, a.vl_troco, a.vl_auditado, a.vl_movimento, ");
                sql.AppendLine("b.st_cartaocredito, b.st_controletitulo, a.Vl_DevCredito, a.vl_suprimento, ");
                sql.AppendLine("a.id_transf, a.cd_contager, a.cd_lanctocaixa, a.ds_observacao, a.vl_emprestimo, ");
                sql.AppendLine("a.loginaudit, a.st_registro, a.vl_retirada, a.vl_credito, a.vl_credAvulso ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_FechamentoCaixa a ");
            sql.AppendLine("inner join TB_FIN_Portador b ");
            sql.AppendLine("on a.cd_portador = b.cd_portador ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_FechamentoCaixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FechamentoCaixa lista = new TList_FechamentoCaixa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FechamentoCaixa reg = new TRegistro_FechamentoCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("Cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("id_transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginaudit")))
                        reg.Loginaudit = reader.GetString(reader.GetOrdinal("loginaudit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Fechamento")))
                        reg.Vl_fechamento = reader.GetDecimal(reader.GetOrdinal("Vl_Fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("Vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Recebido")))
                        reg.Vl_recebido = reader.GetDecimal(reader.GetOrdinal("Vl_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Pago")))
                        reg.Vl_pago = reader.GetDecimal(reader.GetOrdinal("Vl_Pago"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DevCredito")))
                        reg.Vl_devCredito = reader.GetDecimal(reader.GetOrdinal("Vl_DevCredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Troco")))
                        reg.Vl_troco = reader.GetDecimal(reader.GetOrdinal("Vl_Troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_auditado")))
                        reg.Vl_auditado = reader.GetDecimal(reader.GetOrdinal("vl_auditado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_movimento")))
                        reg.Vl_movimento = reader.GetDecimal(reader.GetOrdinal("vl_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_retirada")))
                        reg.Vl_retirada = reader.GetDecimal(reader.GetOrdinal("vl_retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_transportar")))
                        reg.Vl_transportar = reader.GetDecimal(reader.GetOrdinal("vl_transportar"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_cartaocredito")))
                        reg.St_cartao = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_cartaocredito"))).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controletitulo")))
                        reg.St_cheque = reader.GetString(reader.GetOrdinal("st_controletitulo")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_credito")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("vl_credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_credAvulso")))
                        reg.Vl_credAvulso = reader.GetDecimal(reader.GetOrdinal("vl_credAvulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_suprimento")))
                        reg.Vl_suprimento = reader.GetDecimal(reader.GetOrdinal("vl_suprimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_emprestimo")))
                        reg.Vl_emprestimo = reader.GetDecimal(reader.GetOrdinal("vl_emprestimo"));

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

        public string Gravar(TRegistro_FechamentoCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_ID_TRANSF", val.Id_transf);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_LOGINAUDIT", val.Loginaudit);
            hs.Add("@P_VL_FECHAMENTO", val.Vl_fechamento);
            hs.Add("@P_VL_AUDITADO", val.Vl_auditado);
            hs.Add("@P_VL_MOVIMENTO", val.Vl_movimento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_PDV_FECHAMENTOCAIXA", hs);
        }

        public string Excluir(TRegistro_FechamentoCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return executarProc("EXCLUI_PDV_FECHAMENTOCAIXA", hs);
        }
    }
    #endregion

    #region Caixa X Cheque
    public class TList_ProcCaixa_X_Cheque : List<TRegistro_ProcCaixa_X_Cheque>, IComparer<TRegistro_ProcCaixa_X_Cheque>
    {
        #region IComparer<TRegistro_ProcCaixa_X_Cheque> Members
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

        public TList_ProcCaixa_X_Cheque()
        { }

        public TList_ProcCaixa_X_Cheque(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcCaixa_X_Cheque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcCaixa_X_Cheque x, TRegistro_ProcCaixa_X_Cheque y)
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

    
    public class TRegistro_ProcCaixa_X_Cheque
    {
        private decimal? id_caixa;
        
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = Convert.ToDecimal(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctocheque;
        
        public decimal? Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set
            {
                nr_lanctocheque = value;
                nr_lanctochequestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctochequestr;
        
        public string Nr_lanctochequestr
        {
            get { return nr_lanctochequestr; }
            set
            {
                nr_lanctochequestr = value;
                try
                {
                    nr_lanctocheque = Convert.ToDecimal(value);
                }
                catch
                { nr_lanctocheque = null; }
            }
        }
        
        public string Cd_banco
        { get; set; }

        public TRegistro_ProcCaixa_X_Cheque()
        {
            id_caixa = null;
            id_caixastr = string.Empty;
            Cd_empresa = string.Empty;
            nr_lanctocheque = null;
            nr_lanctochequestr = string.Empty;
            Cd_banco = string.Empty;
        }
    }

    public class TCD_ProcCaixa_X_Cheque : TDataQuery
    {
        public TCD_ProcCaixa_X_Cheque()
        { }

        public TCD_ProcCaixa_X_Cheque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Caixa, ");
                sql.AppendLine("a.cd_empresa, a.nr_lanctocheque, a.cd_banco ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_ProcCaixa_X_Cheque a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ProcCaixa_X_Cheque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ProcCaixa_X_Cheque lista = new TList_ProcCaixa_X_Cheque();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProcCaixa_X_Cheque reg = new TRegistro_ProcCaixa_X_Cheque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));

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

        public string Gravar(TRegistro_ProcCaixa_X_Cheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return executarProc("IA_PDV_PROCCAIXA_X_CHEQUE", hs);
        }

        public string Excluir(TRegistro_ProcCaixa_X_Cheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return executarProc("EXCLUI_PDV_PROCCAIXA_X_CHEQUE", hs);
        }
    }
    #endregion

    #region Caixa X DevCredAvulso
    public class TList_Caixa_X_DevCredAvulso : List<TRegistro_Caixa_X_DevCredAvulso>
    { }

    public class TRegistro_Caixa_X_DevCredAvulso
    {
        private decimal? id_devcred;
        public decimal? Id_devcred
        {
            get { return id_devcred; }
            set
            {
                id_devcred = value;
                id_devcredstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devcredstr;
        public string Id_devcredstr
        {
            get { return id_devcredstr; }
            set
            {
                id_devcredstr = value;
                try
                {
                    id_devcred = decimal.Parse(value);
                }
                catch { id_devcred = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_caixa;
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch { id_caixa = null; }
            }
        }
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
                    id_adto = decimal.Parse(value);
                }
                catch { id_adto = null; }
            }
        }
        private decimal? cd_lanctocaixa;
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch { cd_lanctocaixa = null; }
            }
        }
        public string Cd_contager
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lDevCHP
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lDevCHT
        { get; set; }

        public TRegistro_Caixa_X_DevCredAvulso()
        {
            id_devcred = null;
            id_devcredstr = string.Empty;
            Cd_empresa = string.Empty;
            id_caixa = null;
            id_caixastr = string.Empty;
            id_adto = null;
            id_adtostr = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            Cd_contager = string.Empty;
            Vl_devolucao = decimal.Zero;
            rAdto = null;
            lDevCHP = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
            lDevCHT = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
        }
    }

    public class TCD_Caixa_X_DevCredAvulso : TDataQuery
    {
        public TCD_Caixa_X_DevCredAvulso() { }

        public TCD_Caixa_X_DevCredAvulso(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_devcred, a.CD_Empresa, a.ID_Caixa, ");
                sql.AppendLine("a.id_adto, a.cd_lanctocaixa, a.cd_contager, b.vl_pagar ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_Caixa_X_DevCredAvulso a ");
            sql.AppendLine("inner join TB_FIN_Caixa b ");
            sql.AppendLine("on a.cd_contager = b.cd_contager ");
            sql.AppendLine("and a.cd_lanctocaixa = b.cd_lanctocaixa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Caixa_X_DevCredAvulso Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Caixa_X_DevCredAvulso lista = new TList_Caixa_X_DevCredAvulso();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Caixa_X_DevCredAvulso reg = new TRegistro_Caixa_X_DevCredAvulso();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DevCred")))
                        reg.Id_devcred = reader.GetDecimal(reader.GetOrdinal("ID_DevCred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("ID_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pagar")))
                        reg.Vl_devolucao = reader.GetDecimal(reader.GetOrdinal("vl_pagar"));

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

        public string Gravar(TRegistro_Caixa_X_DevCredAvulso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_DEVCRED", val.Id_devcred);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("IA_PDV_CAIXA_X_DEVCREDAVULSO", hs);
        }

        public string Excluir(TRegistro_Caixa_X_DevCredAvulso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_DEVCRED", val.Id_devcred);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PDV_CAIXA_X_DEVCREDAVULSO", hs);
        }
    }
    #endregion

    #region Retirada Caixa
    public class TList_RetiradaCaixa : List<TRegistro_RetiradaCaixa>, IComparer<TRegistro_RetiradaCaixa>
    {
        #region IComparer<TRegistro_RetiradaCaixa> Members
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

        public TList_RetiradaCaixa()
        { }

        public TList_RetiradaCaixa(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_RetiradaCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_RetiradaCaixa x, TRegistro_RetiradaCaixa y)
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

    
    public class TRegistro_RetiradaCaixa
    {
        private decimal? id_retirada;
        
        public decimal? Id_retirada
        {
            get { return id_retirada; }
            set
            {
                id_retirada = value;
                id_retiradastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_retiradastr;
        
        public string Id_retiradastr
        {
            get { return id_retiradastr; }
            set
            {
                id_retiradastr = value;
                try
                {
                    id_retirada = Convert.ToDecimal(value);
                }
                catch
                { id_retirada = null; }
            }
        }
        private decimal? id_caixa;
        
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = Convert.ToDecimal(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_transf;
        
        public decimal? Id_transf
        {
            get { return id_transf; }
            set
            {
                id_transf = value;
                id_transfstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_transfstr;
        
        public string Id_transfstr
        {
            get { return id_transfstr; }
            set
            {
                id_transfstr = value;
                try
                {
                    id_transf = Convert.ToDecimal(value);
                }
                catch
                { id_transf = null; }
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
        
        public decimal Vl_retirada
        { get; set; }
        
        public decimal Vl_cheque
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTA";
                else if (St_registro.Trim().ToUpper().Equals("P"))
                    return "PROCESSADA";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADA";
                else return string.Empty;
            }
        }
        private string tp_registro;
        
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("S"))
                    tipo_registro = "SUPRIMENTO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_registro = "RETIRADA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_registro = "EMPRESTIMO";
            }
        }
        private string tipo_registro;
        
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("SUPRIMENTO"))
                    tp_registro = "S";
                else if (value.Trim().ToUpper().Equals("RETIRADA"))
                    tp_registro = "R";
                else if (value.Trim().ToUpper().Equals("EMPRESTIMO"))
                    tp_registro = "E";
            }
        }
        
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador> lPortador
        { get; set; }
        
        public TList_Retirada_X_Cheque lRetCheque
        { get; set; }

        public TRegistro_RetiradaCaixa()
        {
            id_retirada = null;
            id_retiradastr = string.Empty;
            id_caixa = null;
            id_caixastr = string.Empty;
            Cd_empresa = string.Empty;
            id_transf = null;
            id_transfstr = string.Empty;
            dt_retirada = null;
            dt_retiradastr = string.Empty;
            Vl_retirada = decimal.Zero;
            Vl_cheque = decimal.Zero;
            Ds_observacao = string.Empty;
            tp_registro = string.Empty;
            tipo_registro = string.Empty;
            St_registro = "A";
            lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
            lRetCheque = new TList_Retirada_X_Cheque();
        }
    }

    public class TCD_RetiradaCaixa : TDataQuery
    {
        public TCD_RetiradaCaixa()
        { }

        public TCD_RetiradaCaixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Retirada, a.ID_Caixa, a.Id_Transf, ");
                sql.AppendLine("a.DT_Retirada, a.Vl_Retirada, a.DS_Observacao, a.ST_Registro, ");
                sql.AppendLine("a.TP_Registro, a.Vl_cheque ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_RetiradaCaixa a ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_RetiradaCaixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RetiradaCaixa lista = new TList_RetiradaCaixa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_RetiradaCaixa reg = new TRegistro_RetiradaCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Retirada"))))
                        reg.Id_retirada = reader.GetDecimal(reader.GetOrdinal("ID_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Retirada")))
                        reg.Dt_retirada = reader.GetDateTime(reader.GetOrdinal("DT_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Retirada")))
                        reg.Vl_retirada = reader.GetDecimal(reader.GetOrdinal("Vl_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_cheque")))
                        reg.Vl_cheque = reader.GetDecimal(reader.GetOrdinal("vl_cheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));

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

        public string Gravar(TRegistro_RetiradaCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_ID_TRANSF", val.Id_transf);
            hs.Add("@P_DT_RETIRADA", val.Dt_retirada);
            hs.Add("@P_VL_RETIRADA", val.Vl_retirada);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDV_RETIRADACAIXA", hs);
        }

        public string Excluir(TRegistro_RetiradaCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);

            return executarProc("EXCLUI_PDV_RETIRADACAIXA", hs);
        }
    }
    #endregion

    #region Retirada X Cheque
    public class TList_Retirada_X_Cheque : List<TRegistro_Retirada_X_Cheque>, IComparer<TRegistro_Retirada_X_Cheque>
    {
        #region IComparer<TRegistro_Retirada_X_Cheque> Members
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

        public TList_Retirada_X_Cheque()
        { }

        public TList_Retirada_X_Cheque(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Retirada_X_Cheque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Retirada_X_Cheque x, TRegistro_Retirada_X_Cheque y)
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

    
    public class TRegistro_Retirada_X_Cheque
    {
        private decimal? id_retirada;
        
        public decimal? Id_retirada
        {
            get { return id_retirada; }
            set
            {
                id_retirada = value;
                id_retiradastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_retiradastr;
        
        public string Id_retiradastr
        {
            get { return id_retiradastr; }
            set
            {
                id_retiradastr = value;
                try
                {
                    id_retirada = decimal.Parse(value);
                }
                catch
                { id_retirada = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctocheque;
        
        public decimal? Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set
            {
                nr_lanctocheque = value;
                nr_lanctochequestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctochequestr;
        
        public string Nr_lanctochequestr
        {
            get { return nr_lanctochequestr; }
            set
            {
                nr_lanctochequestr = value;
                try
                {
                    nr_lanctocheque = decimal.Parse(value);
                }
                catch
                { nr_lanctocheque = null; }
            }
        }
        
        public string Cd_banco
        { get; set; }

        public TRegistro_Retirada_X_Cheque()
        {
            id_retirada = null;
            id_retiradastr = string.Empty;
            Cd_empresa = string.Empty;
            nr_lanctocheque = null;
            nr_lanctochequestr = string.Empty;
            Cd_banco = string.Empty;
        }
    }

    public class TCD_Retirada_X_Cheque : TDataQuery
    {
        public TCD_Retirada_X_Cheque()
        { }

        public TCD_Retirada_X_Cheque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Retirada, ");
                sql.AppendLine("a.cd_empresa, a.nr_lanctocheque, a.cd_banco ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_Retirada_X_Cheque a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Retirada_X_Cheque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Retirada_X_Cheque lista = new TList_Retirada_X_Cheque();
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Retirada_X_Cheque reg = new TRegistro_Retirada_X_Cheque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Retirada"))))
                        reg.Id_retirada = reader.GetDecimal(reader.GetOrdinal("ID_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));

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

        public string Gravar(TRegistro_Retirada_X_Cheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return executarProc("IA_PDV_RETIRADA_X_CHEQUE", hs);
        }

        public string Excluir(TRegistro_Retirada_X_Cheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return executarProc("EXCLUI_PDV_RETIRADA_X_CHEQUE", hs);
        }
    }
    #endregion

    #region Movimento Caixa
    
    public class TRegistro_MovCaixa
    {
        public decimal? Id_caixa
        { get; set; }
        public string Cd_empresa
        { get; set; }   
        public string Nm_empresa
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_movimento
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Tp_cartao { get; set; } = string.Empty;
        public string St_controletitulo { get; set; } = "N";
        public bool St_cartaocredito { get; set; } = false;
        public string St_cartafrete { get; set; } = "N";
        public string St_devcredito { get; set; } = "N";
        public string Tp_portadorpdv { get; set; } = string.Empty;
        private string _tpPortador = string.Empty;
        public string Tp_portador
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_tpPortador))
                {
                    if (St_controletitulo.Trim().ToUpper().Equals("S"))
                        return "02";
                    else if (St_cartaocredito)
                        return Tp_cartao.Trim().ToUpper().Equals("C") ? "03" : "04";
                    else if (St_cartafrete.Trim().ToUpper().Equals("S"))
                        return "13";
                    else if (St_devcredito.Trim().ToUpper().Equals("S"))
                        return "99";
                    else if (Tp_portadorpdv.Trim().ToUpper().Equals("P"))
                        return "05";
                    else return "01";
                }
                else return _tpPortador;
            }
            set { _tpPortador = value; }
        }
        public string Ds_bandeira
        { get; set; }
        public string Nr_autorizacao
        { get; set; } = string.Empty;
        public string Ds_maquina { get; set; } = string.Empty;
        public string Nm_clifor
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_recebido
        { get; set; }
        public decimal Vl_pago
        { get; set; }
        public decimal Vl_DevCredito
        { get; set; }
        public decimal Vl_troco_dh
        { get; set; }
        public decimal Vl_troco_ch
        { get; set; }
        public decimal Vl_credito
        { get; set; }
        public decimal Vl_recebidoliq
        { get { return Vl_recebido - Vl_pago - Vl_troco_dh - Vl_troco_ch - Vl_DevCredito; } }
        public DateTime DT_Lancto { get; set; }
        public TRegistro_MovCaixa()
        {
            Id_caixa = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_cupom = null;
            Id_movimento = null;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Ds_bandeira = string.Empty;
            Nm_clifor = string.Empty;
            Vl_cupom = decimal.Zero;
            Vl_recebido = decimal.Zero;
            Vl_pago = decimal.Zero;
            Vl_DevCredito = decimal.Zero;
            Vl_troco_dh = decimal.Zero;
            Vl_troco_ch = decimal.Zero;
            Vl_credito = decimal.Zero;
        }
    }
    #endregion

    #region Extrato Caixa
    
    public class TRegistro_ExtratoCaixa
    {
        
        public DateTime? Dt_lancto
        { get; set; }
        
        public decimal? Id_caixa
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Docto
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        
        public decimal Vl_receber
        { get; set; }

        public TRegistro_ExtratoCaixa()
        {
            Dt_lancto = null;
            Id_caixa = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nm_clifor = string.Empty;
            Docto = string.Empty;
            Ds_portador = string.Empty;
            Vl_receber = decimal.Zero;
        }
    }
    #endregion

    #region Liquidacao Caixa
    public class TList_Caixa_X_Liquidacao : List<TRegistro_Caixa_X_Liquidacao>, IComparer<TRegistro_Caixa_X_Liquidacao>
    {
        #region IComparer<TRegistro_Caixa_X_Liquidacao> Members
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

        public TList_Caixa_X_Liquidacao()
        { }

        public TList_Caixa_X_Liquidacao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Caixa_X_Liquidacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Caixa_X_Liquidacao x, TRegistro_Caixa_X_Liquidacao y)
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

    
    public class TRegistro_Caixa_X_Liquidacao
    {
        private decimal? id_caixa;
        
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lancto;
        
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch
                { cd_parcela = null; }
            }
        }
        private decimal? id_liquid;
        
        public decimal? Id_liquid
        {
            get { return id_liquid; }
            set
            {
                id_liquid = value;
                id_liquidstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_liquidstr;
        
        public string Id_liquidstr
        {
            get { return id_liquidstr; }
            set
            {
                id_liquidstr = value;
                try
                {
                    id_liquid = decimal.Parse(value);
                }
                catch
                { id_liquid = null; }
            }
        }

        public TRegistro_Caixa_X_Liquidacao()
        {
            id_caixa = null;
            id_caixastr = string.Empty;
            Cd_empresa = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            cd_parcela = null;
            cd_parcelastr = string.Empty;
            id_liquid = null;
            id_liquidstr = string.Empty;
        }
    }

    public class TCD_Caixa_X_Liquidacao : TDataQuery
    {
        public TCD_Caixa_X_Liquidacao()
        { }

        public TCD_Caixa_X_Liquidacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Caixa, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_liquid ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_Caixa_X_Liquidacao a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Caixa_X_Liquidacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Caixa_X_Liquidacao lista = new TList_Caixa_X_Liquidacao();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Caixa_X_Liquidacao reg = new TRegistro_Caixa_X_Liquidacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Caixa"))))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));

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

        public string Gravar(TRegistro_Caixa_X_Liquidacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return executarProc("IA_PDV_CAIXA_X_LIQUIDACAO", hs);
        }

        public string Excluir(TRegistro_Caixa_X_Liquidacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return executarProc("EXCLUI_PDV_CAIXA_X_LIQUIDACAO", hs);
        }
    }
    #endregion

    #region Resumo Cartao
    
    public class TRegistro_ResumoCartao
    {
        
        public decimal? Id_bandeira
        { get; set; }
        
        public string Ds_bandeira
        { get; set; }
        
        public string Tp_cartao
        { get; set; }
        public string Tipo_cartao
        {
            get
            {
                if (Tp_cartao.Trim().ToUpper().Equals("C"))
                    return "CREDITO";
                else if (Tp_cartao.Trim().ToUpper().Equals("D"))
                    return "DEBITO";
                else return string.Empty;
            }
        }
        
        public decimal Vl_movimento
        { get; set; }

        public TRegistro_ResumoCartao()
        {
            Id_bandeira = null;
            Ds_bandeira = string.Empty;
            Tp_cartao = string.Empty;
            Vl_movimento = decimal.Zero;
        }
    }
    #endregion
}
