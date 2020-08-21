using CamadaDados.Estoque;
using CamadaDados.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    #region Resumo Empresa
    public class TList_ResumoEmpresa : List<TRegistro_ResumoEmpresa>, IComparer<TRegistro_ResumoEmpresa>
    {
        #region IComparer<TRegistro_ResumoEmpresa> Members
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

        public TList_ResumoEmpresa()
        { }

        public TList_ResumoEmpresa(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ResumoEmpresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ResumoEmpresa x, TRegistro_ResumoEmpresa y)
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

    public class TRegistro_ResumoEmpresa
    {
        public int Mes
        { get; set; }
        public string Ds_Mes
        {
            get
            {
                if (Mes.Equals(1))
                    return "JANEIRO";
                else if (Mes.Equals(2))
                    return "FEVEREIRO";
                else if (Mes.Equals(3))
                    return "MARÇO";
                else if (Mes.Equals(4))
                    return "ABRIL";
                else if (Mes.Equals(5))
                    return "MAIO";
                else if (Mes.Equals(6))
                    return "JUNHO";
                else if (Mes.Equals(7))
                    return "JULHO";
                else if (Mes.Equals(8))
                    return "AGOSTO";
                else if (Mes.Equals(9))
                    return "SETEMBRO";
                else if (Mes.Equals(10))
                    return "OUTUBRO";
                else if (Mes.Equals(11))
                    return "NOVEMBRO";
                else if (Mes.Equals(12))
                    return "DEZEMBRO";
                else return string.Empty;
            }
        }
        public string Nm_empresa
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public decimal Vl_totalitens
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public decimal VL_TotalLiquido
        { get; set; }

        public TRegistro_ResumoEmpresa()
        {
            Mes = 0;
            Nm_empresa = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Vl_totalitens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_desconto = decimal.Zero;
            VL_TotalLiquido = decimal.Zero;
        }
    }
    #endregion

    #region Resumo PDV
    public class TList_ResumoPDV : List<TRegistro_ResumoPDV>, IComparer<TRegistro_ResumoPDV>
    {
        #region IComparer<TRegistro_ResumoPDV> Members
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

        public TList_ResumoPDV()
        { }

        public TList_ResumoPDV(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ResumoPDV value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ResumoPDV x, TRegistro_ResumoPDV y)
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

    public class TRegistro_ResumoPDV
    {
        public string Ds_pdv
        { get; set; }
        public decimal Vl_totalitens
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public decimal Vl_totalliquido
        { get; set; }

        public TRegistro_ResumoPDV()
        {
            Ds_pdv = string.Empty;
            Vl_totalitens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_devolucao = decimal.Zero;
            Vl_totalliquido = decimal.Zero;
        }
    }
    #endregion

    #region Resumo Cliente
    public class TList_ResumoCliente : List<TRegistro_ResumoCliente>, IComparer<TRegistro_ResumoCliente>
    {
        #region IComparer<TRegistro_ResumoPDV> Members
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

        public TList_ResumoCliente()
        { }

        public TList_ResumoCliente(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ResumoCliente value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ResumoCliente x, TRegistro_ResumoCliente y)
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

    public class TRegistro_ResumoCliente
    {
        public string Nm_cliente
        { get; set; }
        public decimal Vl_totalitens
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public decimal Vl_TotalLiquido
        { get; set; }

        public TRegistro_ResumoCliente()
        {
            Nm_cliente = string.Empty;
            Vl_totalitens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_devolucao = decimal.Zero;
            Vl_TotalLiquido = decimal.Zero;
        }
    }
    #endregion

    #region Resumo Vendedor
    public class TList_ResumoVendedor : List<TRegistro_ResumoVendedor>, IComparer<TRegistro_ResumoVendedor>
    {
        #region IComparer<TRegistro_ResumoVendedor> Members
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

        public TList_ResumoVendedor()
        { }

        public TList_ResumoVendedor(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ResumoVendedor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ResumoVendedor x, TRegistro_ResumoVendedor y)
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

    public class TRegistro_ResumoVendedor
    {
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public int Mes
        { get; set; }
        private string ds_mes;
        public string Ds_Mes
        {
            get
            {
                if (Mes.Equals(1))
                    return "JANEIRO";
                else if (Mes.Equals(2))
                    return "FEVEREIRO";
                else if (Mes.Equals(3))
                    return "MARÇO";
                else if (Mes.Equals(4))
                    return "ABRIL";
                else if (Mes.Equals(5))
                    return "MAIO";
                else if (Mes.Equals(6))
                    return "JUNHO";
                else if (Mes.Equals(7))
                    return "JULHO";
                else if (Mes.Equals(8))
                    return "AGOSTO";
                else if (Mes.Equals(9))
                    return "SETEMBRO";
                else if (Mes.Equals(10))
                    return "OUTUBRO";
                else if (Mes.Equals(11))
                    return "NOVEMBRO";
                else if (Mes.Equals(12))
                    return "DEZEMBRO";
                else return ds_mes;
            }
            set { ds_mes = value; }
        }
        public decimal Ano
        { get; set; }
        public decimal Vl_totalitens
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public decimal Vl_TotalLiquido
        { get; set; }

        public TRegistro_ResumoVendedor()
        {
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Mes = 0;
            Ano = decimal.Zero;
            Vl_totalitens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_devolucao = decimal.Zero;
            Vl_TotalLiquido = decimal.Zero;
        }
    }
    #endregion

    #region Venda Rapida
    public class TList_VendaRapida : List<TRegistro_VendaRapida>, IComparer<TRegistro_VendaRapida>
    {
        #region IComparer<TRegistro_CupomFiscal> Members
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

        public TList_VendaRapida()
        { }

        public TList_VendaRapida(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VendaRapida value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VendaRapida x, TRegistro_VendaRapida y)
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

    public class TRegistro_VendaRapida
    {

        private decimal? id_vendarapida;
        public decimal? Id_vendarapida
        {
            get { return id_vendarapida; }
            set
            {
                id_vendarapida = value;
                id_vendarapidastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vendarapidastr;
        public string Id_vendarapidastr
        {
            get { return id_vendarapidastr; }
            set
            {
                id_vendarapidastr = value;
                try
                {
                    id_vendarapida = Convert.ToDecimal(value);
                }
                catch
                { id_vendarapida = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_uf_empresa
        { get; set; }
        private decimal? id_pdv;
        public decimal? Id_pdv
        {
            get { return id_pdv; }
            set
            {
                id_pdv = value;
                id_pdvstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pdvstr;
        public string Id_pdvstr
        {
            get { return id_pdvstr; }
            set
            {
                id_pdvstr = value;
                try
                {
                    id_pdv = Convert.ToDecimal(value);
                }
                catch
                { id_pdv = null; }
            }
        }
        public string Valor_Extenso { get; set; }

        public string sigla_moeda { get; set; }

        public string Ds_pdv
        { get; set; }
        private decimal? id_sessao;
        public decimal? Id_sessao
        {
            get { return id_sessao; }
            set
            {
                id_sessao = value;
                id_sessaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_sessaostr;
        public string Id_sessaostr
        {
            get { return id_sessaostr; }
            set
            {
                id_sessaostr = value;
                try
                {
                    id_sessao = Convert.ToDecimal(value);
                }
                catch
                { id_sessao = null; }
            }
        }
        public string LoginSessao
        { get; set; }
        public bool st_restaurante { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_cliforInd
        { get; set; }
        public string Nm_cliforInd
        { get; set; }
        public string Cd_representante
        { get; set; }
        public string Nm_representante
        { get; set; }
        public string Nr_cgccpf
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Cd_ufCliente
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
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
                    return Convert.ToDateTime(dt_emissaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
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
        public decimal Vl_cupom
        { get; set; }
        public decimal vl_devolvido
        { get; set; }
        public decimal Vl_devcred
        { get; set; }
        public TList_VendaRapida_Item lItem
        { get; set; }
        public TList_CadPortador lPortador
        { get; set; }
        public string Cd_vend
        { get; set; }
        public string Nm_vend
        { get; set; }
        public string Logindesconto
        { get; set; }
        public bool St_processar
        { get; set; }
        public string Ds_observacao
        { get; set; }
        public string Placa
        { get; set; }
        public string ObsOS
        { get; set; }
        public string Nr_requisicao
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
        public decimal PontosFid
        { get; set; }
        public decimal PontosFidRes
        { get; set; }
        public string LoginCancPontos
        { get; set; }
        public string Id_locacao
        { get; set; }
        public string NR_Docto_Origem
        { get; set; }
        public string MotivoCanc
        { get; set; }
        public string LoginCanc
        { get; set; }
        public decimal? Id_caixa
        { get; set; }
        public Diversos.TRegistro_CadEmpresa rEmpresa
        { get; set; }
        public TRegistro_CadClifor rCliente
        { get; set; }
        public TRegistro_CadEndereco rEndCli
        { get; set; }
        public List<TRegistro_MovCaixa> lPagto
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public Financeiro.CCustoLan.TList_LanCCustoLancto lCusto { get; set; }

        public TRegistro_VendaRapida()
        {
            Id_vendarapida = null;
            id_vendarapidastr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_uf_empresa = string.Empty;
            id_pdv = null;
            id_pdvstr = string.Empty;
            Ds_pdv = string.Empty;
            id_sessao = null;
            id_sessaostr = string.Empty;
            LoginSessao = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_cliforInd = string.Empty;
            Nm_cliforInd = string.Empty;
            Cd_representante = string.Empty;
            Nm_representante = string.Empty;
            Nr_cgccpf = string.Empty;
            st_restaurante = false;
            Cd_endereco = string.Empty;
            Cd_ufCliente = string.Empty;
            Ds_endereco = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            dt_emissao = DateTime.Now;
            Valor_Extenso = string.Empty;
            sigla_moeda = string.Empty;
            St_registro = "A";
            Logindesconto = string.Empty;
            Ds_observacao = string.Empty;
            Placa = string.Empty;
            Vl_cupom = decimal.Zero;
            ObsOS = string.Empty;
            Nr_requisicao = string.Empty;
            id_pessoa = null;
            id_pessoastr = string.Empty;
            Nm_pessoa = string.Empty;
            vl_devolvido = decimal.Zero;
            Vl_devcred = decimal.Zero;
            PontosFid = decimal.Zero;
            PontosFidRes = decimal.Zero;
            LoginCancPontos = string.Empty;
            Id_locacao = string.Empty;
            NR_Docto_Origem = string.Empty;
            MotivoCanc = string.Empty;
            LoginCanc = string.Empty;
            Id_caixa = null;

            lItem = new TList_VendaRapida_Item();
            lPortador = new TList_CadPortador();
            lCusto = new Financeiro.CCustoLan.TList_LanCCustoLancto();
            St_processar = false;
        }
    }

    public class TCD_VendaRapida : TDataQuery
    {
        public TCD_VendaRapida()
        { }

        public TCD_VendaRapida(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_VendaRapida, a.CD_Empresa, ")
                    .AppendLine("b.NM_Empresa, endEmp.cd_cidade, endEmp.cd_uf, ")
                    .AppendLine("a.cd_cliforind, ind.nm_clifor as nm_cliforInd, a.cd_representante, rep.nm_clifor as nm_representante, ")
                    .AppendLine("a.DT_Emissao, a.ST_Registro, a.pontosfid, a.pontosfidres, ")
                    .AppendLine("a.id_pdv, e.ds_pdv, a.id_sessao, a.cd_clifor, a.nm_clifor, a.cd_endereco, endClifor.CD_UF as CD_UFCliente, ")
                    .AppendLine("a.ds_endereco, a.ds_observacao, a.placa, a.nr_requisicao, a.NR_Docto_Origem, a.MotivoCanc, a.LoginCanc, ")
                    .AppendLine("a.nr_cgc_cpf, a.cd_tabelapreco, tab.ds_tabelapreco, d.Login as LoginSessao, a.LoginDesconto, ")
                    .AppendLine("cEmp.nr_cgc as NR_CGC_Empresa, a.Vl_cupom, a.id_pessoa, paut.nm_pessoa, a.cd_vendedor, vend.nm_clifor as nm_vendedor, ")
                    .AppendLine("Id_caixa = case when (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_Cupom_X_MovCaixa x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) is not null then ")
                    .AppendLine("             (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_Cupom_X_MovCaixa x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) else  ")
                    .AppendLine("case when (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_Cupom_X_DevCredito x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) is not null then ")
                    .AppendLine("             (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_Cupom_X_DevCredito x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) else ")
                    .AppendLine("case when (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_CupomFiscal_X_Duplicata x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) is not null then ")
                    .AppendLine("             (select top 1 x.id_caixa ")
                    .AppendLine("            from TB_PDV_CupomFiscal_X_Duplicata x ")
                    .AppendLine("            where a.cd_empresa = x.cd_empresa ")
                    .AppendLine("            and a.Id_VendaRapida = x.id_cupom) end end end, ")
                    .AppendLine("(select sum(ISNULL(x.Qtd_devolvida,0) * ")
                    .AppendLine("((ISNULL(x.vl_subtotal,0) - ISNULL(x.vl_desconto,0) + ISNULL(x.Vl_Acrescimo,0) ")
                    .AppendLine("+ ISNULL(x.Vl_Juro_Fin,0) + ISNULL(x.Vl_frete,0)) / ISNULL(x.quantidade,0))) from VTB_PDV_VENDARAPIDA_ITEM x ")
                    .AppendLine("where x.cd_empresa = a.CD_Empresa ")
                    .AppendLine("and x.id_vendarapida = a.Id_VendaRapida ) as valorDevolvido ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_VendaRapida a ");
            sql.AppendLine("inner join TB_DIV_Empresa b");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa");

            sql.AppendLine("inner join TB_FIN_Clifor_PJ cEmp");
            sql.AppendLine("on b.cd_clifor = cEmp.cd_clifor");

            sql.AppendLine("inner join VTB_FIN_Endereco endEmp");
            sql.AppendLine("on b.cd_clifor = endEmp.cd_clifor");
            sql.AppendLine("and b.cd_endereco = endEmp.cd_endereco");

            sql.AppendLine("left outer join VTB_FIN_Endereco endClifor");
            sql.AppendLine("on a.cd_clifor = endClifor.cd_clifor");
            sql.AppendLine("and a.cd_endereco = endClifor.cd_endereco");

            sql.AppendLine("left outer join TB_PDV_Sessao d");
            sql.AppendLine("on a.id_pdv = d.id_pdv");
            sql.AppendLine("and a.id_sessao = d.id_sessao");

            sql.AppendLine("left outer join TB_PDV_PontoVenda e");
            sql.AppendLine("on d.id_pdv = e.id_pdv");

            sql.AppendLine("left outer join tb_fin_clifor ind");
            sql.AppendLine("on a.cd_cliforind = ind.cd_clifor");

            sql.AppendLine("left outer join tb_fin_clifor rep");
            sql.AppendLine("on a.cd_representante = rep.cd_clifor");

            sql.AppendLine("left outer join TB_DIV_TabelaPreco tab");
            sql.AppendLine("on a.cd_tabelapreco = tab.cd_tabelapreco");

            sql.AppendLine("left outer join TB_FIN_PessoasAutorizadas paut");
            sql.AppendLine("on a.cd_clifor = paut.cd_clifor");
            sql.AppendLine("and a.id_pessoa = paut.id_pessoa");

            sql.AppendLine("left outer join TB_FIN_Clifor vend");
            sql.AppendLine("on a.cd_vendedor = vend.cd_clifor");

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

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_VendaRapida Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_VendaRapida lista = new TList_VendaRapida();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida reg = new TRegistro_VendaRapida();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_VendaRapida"))))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("Id_VendaRapida"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pdv")))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("id_pdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pdv")))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("ds_pdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_sessao")))
                        reg.Id_sessao = reader.GetDecimal(reader.GetOrdinal("id_sessao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginSessao")))
                        reg.LoginSessao = reader.GetString(reader.GetOrdinal("LoginSessao"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Cgc_Cpf")))
                        reg.Nr_cgccpf = reader.GetString(reader.GetOrdinal("NR_Cgc_Cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFCliente")))
                        reg.Cd_ufCliente = reader.GetString(reader.GetOrdinal("CD_UFCliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("Ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginDesconto")))
                        reg.Logindesconto = reader.GetString(reader.GetOrdinal("LoginDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_requisicao")))
                        reg.Nr_requisicao = reader.GetString(reader.GetOrdinal("nr_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pontosfid")))
                        reg.PontosFid = reader.GetDecimal(reader.GetOrdinal("pontosfid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pontosfidres")))
                        reg.PontosFidRes = reader.GetDecimal(reader.GetOrdinal("pontosfidres"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto_Origem")))
                        reg.NR_Docto_Origem = reader.GetString(reader.GetOrdinal("NR_Docto_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        reg.LoginCanc = reader.GetString(reader.GetOrdinal("LoginCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("Id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("id_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pessoa")))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("nm_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valorDevolvido")))
                        reg.vl_devolvido = reader.GetDecimal(reader.GetOrdinal("valorDevolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vend = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vend = reader.GetString(reader.GetOrdinal("nm_vendedor"));

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
        
        public string Gravar(TRegistro_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(31);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_SESSAO", val.Id_sessao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_NR_CGC_CPF", val.Nr_cgccpf);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_LOGINDESCONTO", val.Logindesconto);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_CLIFORIND", val.Cd_cliforInd);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);
            hs.Add("@P_LOGINCANC", val.LoginCanc);
            hs.Add("@P_CD_REPRESENTANTE", val.Cd_representante);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vend);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_NR_REQUISICAO", val.Nr_requisicao);
            hs.Add("@P_NR_DOCTO_ORIGEM", val.NR_Docto_Origem);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDV_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PDV_CUPOMFISCAL", hs);
        }
    }
    #endregion

    #region Item Venda Rapida
    public class TList_VendaRapida_Item : List<TRegistro_VendaRapida_Item>, IComparer<TRegistro_VendaRapida_Item>
    {
        #region IComparer<TRegistro_CupomFiscal_Item> Members
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

        public TList_VendaRapida_Item()
        { }

        public TList_VendaRapida_Item(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VendaRapida_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VendaRapida_Item x, TRegistro_VendaRapida_Item y)
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

    public class TRegistro_VendaRapida_Item
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_vendarapida
        { get; set; }
        public decimal? Id_lanctovenda
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ncm
        { get; set; }
        public string Cest
        { get; set; }
        public string Cd_anp
        { get; set; }
        public string Ds_anp { get; set; } = string.Empty;
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_representante
        { get; set; }
        public decimal Pc_comissao
        { get; set; }
        public decimal Pc_AutorizadoDesc
        { get; set; }
        private decimal quantidade;
        public decimal Quantidade
        {
            get { return Math.Round(quantidade, 3, MidpointRounding.AwayFromZero); }
            set { quantidade = Math.Round(value, 3, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return Math.Round(vl_unitario, 7, MidpointRounding.AwayFromZero); }
            set { vl_unitario = Math.Round(value, 7, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_subtotal, 2) : Math.Round(vl_subtotal, 2, MidpointRounding.AwayFromZero); }
            set { vl_subtotal = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_desconto, 5) : Math.Round(vl_desconto, 5, MidpointRounding.AwayFromZero); }
            set { vl_desconto = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 5) : Math.Round(value, 5, MidpointRounding.AwayFromZero); }
        }
        public decimal Pc_desconto
        { get; set; }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_acrescimo, 5) : Math.Round(vl_acrescimo, 5, MidpointRounding.AwayFromZero); }
            set { vl_acrescimo = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 5) : Math.Round(value, 5, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_frete;
        public decimal Vl_frete
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_frete, 2) : Math.Round(vl_frete, 2, MidpointRounding.AwayFromZero); }
            set { vl_frete = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        public decimal Pc_acrescimo
        { get; set; }
        public decimal Vl_juro_fin
        { get; set; }
        public decimal Vl_subtotalliquido
        { get { return Utils.Parametros.pubTruncarSubTotal ?
            Utils.Estruturas.Truncar(Vl_subtotal + vl_frete + vl_acrescimo + Vl_juro_fin - vl_desconto, 2) :
            Math.Round(Vl_subtotal + vl_frete + vl_acrescimo + Vl_juro_fin - vl_desconto, 2, MidpointRounding.AwayFromZero); } }
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
        public string Ds_promocao
        { get; set; }
        public DateTime? Dt_emissao
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
        private decimal? id_caracteristicaH = null;
        public decimal? Id_caracteristicaH
        {
            get { return id_caracteristicaH; }
            set
            {
                id_caracteristicaH = value;
                id_caracteristicaHstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicaHstr = string.Empty;
        public string Id_caracteristicaHstr
        {
            get { return id_caracteristicaHstr; }
            set
            {
                id_caracteristicaHstr = value;
                try
                {
                    id_caracteristicaH = decimal.Parse(value);
                }
                catch { id_caracteristicaH = null; }
            }
        }
        public PostoCombustivel.TRegistro_VendaCombustivel rVendaCombustivel
        { get; set; }
        public PostoCombustivel.TRegistro_ItensVendaMesaConv rItensVendaMesaConv
        { get; set; }
        public PostoCombustivel.TRegistro_ItensOrdemServico rItemOS
        { get; set; }
        public TRegistro_ItensPreVenda rItemPreVenda
        { get; set; }
        public Orcamento.TRegistro_Orcamento_Item rItemOrcamento
        { get; set; }
        public TRegistro_ItensCondicional rItemCond
        { get; set; }
        public TList_VendaRapida_Item lItemVR
        { get; set; }
        public TRegistro_Cupom_X_VendaRapida rItemVRDelivery
        { get; set; }
        public Servicos.TList_LanServicosPecas lPecasOS
        { get; set; }
        public NotaFiscal.TList_ImpostosNF ImpostosItens
        { get; set; }
        public LoteAnvisa.TList_MovLoteAnvisa lMovLoteAnvisa
        { get; set; }
        public TList_TrocaItem lTrocaItem
        { get; set; }
        public CamadaDados.Locacao.TList_AbastItens lAbastItens
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Sd_devolver
        { get { return quantidade - Qtd_devolvida; } }
        public decimal Qtd_devolver
        { get; set; }
        public decimal Qt_pontosutilizados
        { get; set; }
        public string Placa_KM
        { get; set; }
        public string NR_Bico
        { get; set; }
        public decimal EncerranteFin
        { get; set; }
        public bool St_combustivel
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal id_item { get; set; }
        public decimal id_prevenda { get; set; }
        public decimal id_rua { get; set; }
        public decimal id_secao { get; set; }
        public decimal id_celula { get; set; }
        public string ds_rua { get; set; }
        public string ds_secao { get; set; }
        public string ds_celula { get; set; }
        public Estoque.Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Estoque.Cadastros.TList_ValorCaracteristica();
        public TList_GradeEstoque lGradeEstoque { get; set; } = new TList_GradeEstoque();
        public string DesGrade { get
            {
                string s = "";
                lGradeEstoque.ForEach(x => s += x.valor + ": " + x.quantidade.ToString() + " | ");
                return s;
            } }
        public bool st_servico { get; set; }

        public TRegistro_VendaRapida_Item()
        {
            st_servico = false;
            id_rua = decimal.Zero;
            id_celula = decimal.Zero;
            id_secao = decimal.Zero;
            ds_celula = string.Empty;
            ds_rua = string.Empty;
            ds_secao = string.Empty;
            Cd_empresa = string.Empty;
            Id_vendarapida = null;
            Id_lanctovenda = null;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_tabelapreco = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ncm = string.Empty;
            Cest = string.Empty;
            Cd_anp = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_representante = string.Empty;
            Pc_comissao = decimal.Zero;
            Pc_AutorizadoDesc = decimal.Zero;
            quantidade = decimal.Zero;
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_desconto = decimal.Zero;
            Pc_desconto = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            Pc_acrescimo = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
            vl_frete = decimal.Zero;
            St_registro = "A";
            Ds_promocao = string.Empty;
            rVendaCombustivel = null;
            rItensVendaMesaConv = null;
            rItemOS = null;
            rItemPreVenda = null;
            rItemOrcamento = null;
            rItemCond = null;
            lItemVR = new TList_VendaRapida_Item();
            rItemVRDelivery = null;
            lPecasOS = new Servicos.TList_LanServicosPecas();
            St_processar = false;
            Dt_emissao = null;
            Qtd_devolver = decimal.Zero;
            Qt_pontosutilizados = decimal.Zero;
            Placa_KM = string.Empty;
            st_baixapatrimonio = "N";
            st_baixapatrimoniobool = false;
            lMovLoteAnvisa = new LoteAnvisa.TList_MovLoteAnvisa();
            lTrocaItem = new TList_TrocaItem();
            lAbastItens = new CamadaDados.Locacao.TList_AbastItens();
            NR_Bico = string.Empty;
            EncerranteFin = decimal.Zero;
            St_combustivel = false;
            id_item = decimal.Zero;
            id_prevenda = decimal.Zero;
        }
    }

    public class TCD_VendaRapida_Item : TDataQuery
    {
        public TCD_VendaRapida_Item()
        { }

        public TCD_VendaRapida_Item(string vNM_Proc)
        { NM_ProcSqlBusca = vNM_Proc; }

        public TCD_VendaRapida_Item(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public TCD_VendaRapida_Item(string vNM_Proc, BancoDados.TObjetoBanco banco)
        {
            NM_ProcSqlBusca = vNM_Proc;
            Banco_Dados = banco;
        }

        private string SqlCodeBuscaCFFechamento(Utils.TpBusca[] filtro, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_VendaRapida, a.Id_lanctoVenda, a.cd_produto, ");
                sql.AppendLine("b.DS_Produto, c.CD_Unidade, c.DS_Unidade, b.cd_condfiscal_produto, ");
                sql.AppendLine("c.Sigla_Unidade, a.cd_local, vr.dt_emissao, ");
                sql.AppendLine("a.quantidade, a.cd_empresa, ");
                sql.AppendLine("Vl_Unitario = case when prog.PC_Desconto > 0 and ISNULL(prog.ST_DESCVLUNIT, 'N') = 'S' then ");
                sql.AppendLine("				case when prog.TP_DESCONTO = 'V' then ");
                sql.AppendLine("					a.Vl_Unitario - prog.PC_Desconto ");
                sql.AppendLine("				else a.Vl_Unitario - (a.Vl_Unitario * (prog.PC_Desconto / 100)) end ");
                sql.AppendLine("			  else a.Vl_Unitario end, ");
                sql.AppendLine("Vl_SubTotal =  case when prog.PC_Desconto > 0 and ISNULL(prog.ST_DESCVLUNIT, 'N') = 'S' then ");
                sql.AppendLine("				case when prog.TP_DESCONTO = 'V' then ");
                sql.AppendLine("					a.Quantidade * (a.Vl_Unitario - prog.PC_Desconto) ");
                sql.AppendLine("				else round(a.Quantidade * (a.Vl_Unitario - (a.Vl_Unitario * (prog.PC_Desconto / 100))), 2) end ");
                sql.AppendLine("			  else a.Vl_SubTotal end, ");
                sql.AppendLine("Vl_Desconto = case when prog.PC_Desconto > 0 and ISNULL(prog.ST_DESCVLUNIT, 'N') <> 'S' then ");
                sql.AppendLine("				case when prog.TP_DESCONTO = 'V' then ");
                sql.AppendLine("					a.Quantidade * prog.PC_Desconto ");
                sql.AppendLine("				else ROUND(a.Vl_SubTotal * (prog.PC_Desconto / 100), 2) end ");
                sql.AppendLine("			  else a.vl_desconto end ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_VendaRapida_Item a ");
            sql.AppendLine("inner join TB_PDV_VendaRapida vr ");
            sql.AppendLine("on a.Id_VendaRapida = vr.Id_VendaRapida");
            sql.AppendLine("and a.cd_empresa = vr.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_TpProduto tp ");
            sql.AppendLine("on b.tp_produto = tp.tp_produto ");
            sql.AppendLine("left outer join TB_PDC_ProgCombustivel prog ");
            sql.AppendLine("on a.cd_empresa = prog.CD_Empresa ");
            sql.AppendLine("and a.CD_Produto = prog.CD_Produto ");
            sql.AppendLine("where ISNULL(vr.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and not exists(select 1 from tb_pdv_cupom_x_vendarapida x ");
            sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("				and x.id_vendarapida = a.id_vendarapida ");
            sql.AppendLine("				and x.id_lanctovenda = a.Id_lanctoVenda) ");
            sql.AppendLine("and not exists(select 1 from TB_PDV_Pedido_X_VendaRapida x ");
            sql.AppendLine("				inner join TB_FAT_Pedido y ");
            sql.AppendLine("				on x.nr_pedido = y.nr_pedido ");
            sql.AppendLine("				where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("				and x.id_vendarapida = a.id_vendarapida ");
            sql.AppendLine("				and x.id_lanctovenda = a.Id_lanctoVenda ");
            sql.AppendLine("				and isnull(y.st_pedido, 'F') <> 'C') ");
            sql.AppendLine("and not exists(select 1 from TB_PDV_VendaRapida_X_EntregaFutura x ");
            sql.AppendLine("                inner join TB_FAT_NotaFiscal y ");
            sql.AppendLine("                on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("                where isnull(y.st_registro, 'A') <> 'C' ");
            sql.AppendLine("                and x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                and x.id_cupom = a.id_vendarapida ");
            sql.AppendLine("                and x.id_lancto = a.Id_lanctoVenda) ");
            sql.AppendLine("and isnull(tp.st_servico, 'N') <> 'S' ");
            sql.AppendLine("and (ISNULL(tp.ST_Combustivel, 'N') = 'S' or ISNULL(tp.ST_Lubrificante, 'N') = 'S') ");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        private string SqlCodeBuscaCFAuditCaixa(Utils.TpBusca[] filtro)
        {
            string strTop = string.Empty;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select " + strTop + " a.Id_VendaRapida, a.Id_lanctoVenda, a.cd_produto, ");
            sql.AppendLine("b.DS_Produto, c.CD_Unidade, c.DS_Unidade, b.cd_condfiscal_produto, ");
            sql.AppendLine("c.Sigla_Unidade, a.cd_local, vr.DT_Emissao, a.cd_empresa, ");
            sql.AppendLine("a.quantidade, a.Vl_Unitario, a.Vl_SubTotal, a.Vl_Desconto, a.Vl_Acrescimo ");

            sql.AppendLine("from TB_PDV_VendaRapida_Item a ");
            sql.AppendLine("inner join TB_PDV_VendaRapida vr ");
            sql.AppendLine("on a.Id_VendaRapida = vr.Id_VendaRapida");
            sql.AppendLine("and a.cd_empresa = vr.CD_Empresa");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(vr.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_VendaRapida, a.Id_lanctoVenda, a.cd_produto, b.ncm, b.cd_anp, b.id_caracteristicaH, ");
                sql.AppendLine("b.DS_Produto, c.CD_Unidade, c.DS_Unidade, b.cd_condfiscal_produto, nc.cest, anp.ds_anp, ");
                sql.AppendLine("c.Sigla_Unidade, a.cd_local, d.DS_Local, b.cd_grupo, gProd.ds_grupo, vr.CD_Clifor, vr.NM_Clifor, vr.CD_Representante, vr.CD_TabelaPreco, ");
                sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_desconto, a.cd_empresa, tp.st_combustivel, ");
                sql.AppendLine("a.vl_subtotal, a.st_registro, a.Vl_Acrescimo, a.Vl_Juro_Fin, a.Vl_frete, a.cd_vendedor, e.nm_clifor as NomeVendedor, ");
                sql.AppendLine("b.Pc_comissao, vr.dt_emissao, a.St_BaixaPatrimonio, a.Qtd_devolvida ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_VendaRapida_Item a ");
            sql.AppendLine("inner join TB_PDV_VendaRapida vr ");
            sql.AppendLine("on a.Id_VendaRapida = vr.Id_VendaRapida ");
            sql.AppendLine("and a.cd_empresa = vr.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_TpProduto tp ");
            sql.AppendLine("on b.tp_produto = tp.tp_produto ");
            sql.AppendLine("inner join TB_EST_GrupoProduto gProd ");
            sql.AppendLine("on b.cd_grupo = gProd.cd_grupo ");
            sql.AppendLine("left outer join TB_EST_LocalArm d ");
            sql.AppendLine("on a.cd_local = d.CD_Local ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.cd_vendedor = e.cd_clifor ");
            sql.AppendLine("left outer  join tb_fis_ncm nc ");
            sql.AppendLine("on b.ncm = nc.ncm ");
            sql.AppendLine("left outer join tb_est_anp anp ");
            sql.AppendLine("on b.cd_anp = anp.cd_anp ");

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

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, string.Empty }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }
        }

        public TList_VendaRapida_Item Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_VendaRapida_Item lista = new TList_VendaRapida_Item();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida_Item reg = new TRegistro_VendaRapida_Item();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_VendaRapida"))))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("Id_VendaRapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_lanctoVenda"))))
                        reg.Id_lanctovenda = reader.GetDecimal(reader.GetOrdinal("Id_lanctoVenda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_representante")))
                        reg.Cd_representante = reader.GetString(reader.GetOrdinal("Cd_representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NomeVendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("NomeVendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("Pc_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("vl_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_BaixaPatrimonio")))
                        reg.St_baixapatrimonio = reader.GetString(reader.GetOrdinal("St_BaixaPatrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristicaH")))
                        reg.Id_caracteristicaH = reader.GetDecimal(reader.GetOrdinal("id_caracteristicaH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_combustivel")))
                        reg.St_combustivel = reader.GetString(reader.GetOrdinal("st_combustivel")).Trim().ToUpper().Equals("S");

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

        public TList_VendaRapida_Item SelectCFFechamento(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_VendaRapida_Item lista = new TList_VendaRapida_Item();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaCFFechamento(filtro, 0, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida_Item reg = new TRegistro_VendaRapida_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_VendaRapida")))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("ID_VendaRapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctovenda")))
                        reg.Id_lanctovenda = reader.GetDecimal(reader.GetOrdinal("id_lanctovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));

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

        public TList_VendaRapida_Item SelectCFAuditCaixa(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_VendaRapida_Item lista = new TList_VendaRapida_Item();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaCFAuditCaixa(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida_Item reg = new TRegistro_VendaRapida_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vendarapida")))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("id_vendarapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctovenda")))
                        reg.Id_lanctovenda = reader.GetDecimal(reader.GetOrdinal("id_lanctovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("Vl_Acrescimo"));

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

        public string Gravar(TRegistro_VendaRapida_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_ACRESCIMO", val.Vl_acrescimo);
            hs.Add("@P_VL_JURO_FIN", val.Vl_juro_fin);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_ST_BAIXAPATRIMONIO", val.St_baixapatrimonio);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDV_VENDARAPIDA_ITEM", hs);
        }

        public string Excluir(TRegistro_VendaRapida_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);

            return executarProc("EXCLUI_PDV_VENDARAPIDA_ITEM", hs);
        }
    }
    #endregion

    #region Duplicata Venda Rapida
    public class TList_CupomFiscal_X_Duplicata : List<TRegistro_CupomFiscal_X_Duplicata>, IComparer<TRegistro_CupomFiscal_X_Duplicata>
    {
        #region IComparer<TRegistro_CupomFiscal_X_Duplicata> Members
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

        public TList_CupomFiscal_X_Duplicata()
        { }

        public TList_CupomFiscal_X_Duplicata(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CupomFiscal_X_Duplicata value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CupomFiscal_X_Duplicata x, TRegistro_CupomFiscal_X_Duplicata y)
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

    public class TRegistro_CupomFiscal_X_Duplicata
    {
        public decimal? Id_cupom
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public decimal? Id_caixa
        { get; set; }

        public TRegistro_CupomFiscal_X_Duplicata()
        {
            Id_cupom = null;
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Id_caixa = null;
        }
    }

    public class TCD_CupomFiscal_X_Duplicata : TDataQuery
    {
        public TCD_CupomFiscal_X_Duplicata()
        { }

        public TCD_CupomFiscal_X_Duplicata(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_Cupom, a.CD_Empresa, ");
                sql.AppendLine("a.NR_Lancto, a.ID_Caixa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_CupomFiscal_X_Duplicata a ");

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

        public TList_CupomFiscal_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CupomFiscal_X_Duplicata lista = new TList_CupomFiscal_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CupomFiscal_X_Duplicata reg = new TRegistro_CupomFiscal_X_Duplicata();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));

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

        public string Gravar(TRegistro_CupomFiscal_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);

            return executarProc("IA_PDV_CUPOMFISCAL_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_CupomFiscal_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_PDV_CUPOMFISCAL_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region Estoque Venda Rapida
    public class TList_CupomFiscal_Item_X_Estoque : List<TRegistro_CupomFiscal_Item_X_Estoque>, IComparer<TRegistro_CupomFiscal_Item_X_Estoque>
    {
        #region IComparer<TRegistro_CupomFiscal_Item_X_Estoque> Members
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

        public TList_CupomFiscal_Item_X_Estoque()
        { }

        public TList_CupomFiscal_Item_X_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CupomFiscal_Item_X_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CupomFiscal_Item_X_Estoque x, TRegistro_CupomFiscal_Item_X_Estoque y)
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

    public class TRegistro_CupomFiscal_Item_X_Estoque
    {
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_lancto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }

        public TRegistro_CupomFiscal_Item_X_Estoque()
        {
            Id_cupom = null;
            Id_lancto = null;
            Cd_empresa = string.Empty;
            Cd_produto = string.Empty;
            Id_lanctoestoque = null;
        }
    }

    public class TCD_CupomFiscal_Item_X_Estoque : TDataQuery
    {
        public TCD_CupomFiscal_Item_X_Estoque()
        { }

        public TCD_CupomFiscal_Item_X_Estoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_Cupom, a.Id_lancto, ");
                sql.AppendLine("a.cd_empresa, a.cd_produto, a.id_lanctoestoque ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_CupomFiscal_Item_X_Estoque a ");

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

        public TList_CupomFiscal_Item_X_Estoque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CupomFiscal_Item_X_Estoque lista = new TList_CupomFiscal_Item_X_Estoque();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CupomFiscal_Item_X_Estoque reg = new TRegistro_CupomFiscal_Item_X_Estoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));

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

        public string Gravar(TRegistro_CupomFiscal_Item_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("IA_PDV_CUPOMFISCAL_ITEM_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_CupomFiscal_Item_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("EXCLUI_PDV_CUPOMFISCAL_ITEM_X_ESTOQUE", hs);
        }
    }
    #endregion

    #region Venda Rapida X MovCaixa
    public class TList_Cupom_X_MovCaixa : List<TRegistro_Cupom_X_MovCaixa>, IComparer<TRegistro_Cupom_X_MovCaixa>
    {
        #region IComparer<TRegistro_Cupom_X_MovCaixa> Members
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

        public TList_Cupom_X_MovCaixa()
        { }

        public TList_Cupom_X_MovCaixa(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cupom_X_MovCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cupom_X_MovCaixa x, TRegistro_Cupom_X_MovCaixa y)
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

    public class TRegistro_Cupom_X_MovCaixa
    {
        private decimal? id_movimento;
        public decimal? Id_movimento
        {
            get { return id_movimento; }
            set
            {
                id_movimento = value;
                id_movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_lanctostring;
        public string Dt_lanctostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostring).ToString("dd/MM/yyyy");
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                dt_lanctostring = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_lancto = null;
                }
            }
        }
        public decimal vl_apagar { get; set; } = decimal.Zero;
        public decimal vl_receber { get; set; } = decimal.Zero;
        private string id_movimentostr;
        public string Id_movimentostr
        {
            get { return id_movimentostr; }
            set
            {
                id_movimentostr = value;
                try
                {
                    id_movimento = Convert.ToDecimal(value);
                }
                catch
                { id_movimento = null; }
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
                    id_cupom = Convert.ToDecimal(value);
                }
                catch
                { id_cupom = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
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
                    cd_lanctocaixa = Convert.ToDecimal(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }
        private decimal? cd_lanctocaixa_troco;
        public decimal? Cd_lanctocaixa_troco
        {
            get { return cd_lanctocaixa_troco; }
            set
            {
                cd_lanctocaixa_troco = value;
                cd_lanctocaixa_trocostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixa_trocostr;
        public string Cd_lanctocaixa_trocostr
        {
            get { return cd_lanctocaixa_trocostr; }
            set
            {
                cd_lanctocaixa_trocostr = value;
                try
                {
                    cd_lanctocaixa_troco = Convert.ToDecimal(value);
                }
                catch
                { cd_lanctocaixa_troco = null; }
            }
        }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
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
                    id_caixa = Convert.ToDecimal(value);
                }
                catch
                { id_caixa = null; }
            }
        }
        public decimal Vl_portador
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
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        private decimal? id_cartafrete;
        public decimal? Id_cartafrete
        {
            get { return id_cartafrete; }
            set
            {
                id_cartafrete = value;
                id_cartafretestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartafretestr;
        public string Id_cartafretestr
        {
            get { return id_cartafretestr; }
            set
            {
                id_cartafretestr = value;
                try
                {
                    id_cartafrete = decimal.Parse(value);
                }
                catch
                { id_cartafrete = null; }
            }
        }
        public TRegistro_CadPortador rPortador
        { get; set; }

        public TRegistro_Cupom_X_MovCaixa()
        {
            id_movimento = null;
            id_movimentostr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            cd_lanctocaixa_troco = null;
            cd_lanctocaixa_trocostr = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            id_caixa = null;
            id_caixastr = string.Empty;
            Vl_portador = decimal.Zero;
            id_adto = null;
            id_adtostr = string.Empty;
            id_cartafrete = null;
            id_cartafretestr = string.Empty;
            rPortador = new TRegistro_CadPortador();
        }
    }

    public class TCD_Cupom_X_MovCaixa : TDataQuery
    {
        public TCD_Cupom_X_MovCaixa()
        { }

        public TCD_Cupom_X_MovCaixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " A.ID_MOVIMENTO, A.ID_CUPOM, ");
                sql.AppendLine("A.CD_CONTAGER, B.DS_ContaGer, A.CD_LANCTOCAIXA, ");
                sql.AppendLine("A.CD_EMPRESA, D.NM_EMPRESA, a.Id_Adto, a.id_cartafrete, ");
                sql.AppendLine("A.CD_PORTADOR, C.DS_Portador, a.id_caixa, a.CD_LanctoCaixa_Troco, ");
                //Dados Portador
                sql.AppendLine("c.qt_min_parc, c.qt_max_parc,   c.st_controletitulo, c.st_tituloterceiro, ");
                sql.AppendLine("c.st_cartaocredito, c.tp_portadorpdv, c.st_devcredito, ");
                sql.AppendLine("c.st_cartafrete, c.st_entregafutura, c.pc_juro_fin, c.pc_txtroca, ");
                sql.AppendLine("Tp_Cartao = (select top 1 z.TP_Cartao ");
                sql.AppendLine("			from TB_FIN_FaturaCartao_X_Caixa x ");
                sql.AppendLine("			inner join TB_FIN_FaturaCartao y ");
                sql.AppendLine("			on x.ID_Fatura = y.ID_Fatura ");
                sql.AppendLine("			inner join TB_FIN_BandeiraCartao z ");
                sql.AppendLine("			on y.ID_Bandeira = z.ID_Bandeira ");
                sql.AppendLine("			where x.CD_ContaGer = a.CD_ContaGer ");
                sql.AppendLine("			and x.CD_LanctoCaixa = a.CD_LanctoCaixa), ");
                sql.AppendLine("Vl_portador = isnull((select x.vl_receber ");
                sql.AppendLine("                from tb_fin_caixa x ");
                sql.AppendLine("                where x.cd_contager = a.cd_contager ");
                sql.AppendLine("                and x.cd_lanctocaixa = a.cd_lanctocaixa ");
                sql.AppendLine("                and isnull(x.st_estorno, 'N') <> 'S'), 0), ");
                sql.AppendLine("e.dt_lancto,e.vl_pagar,e.vl_receber");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_CUPOM_X_MOVCAIXA A ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_ContaGer B ");
            sql.AppendLine("ON A.CD_CONTAGER = B.CD_ContaGer ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Portador C ");
            sql.AppendLine("ON A.CD_PORTADOR = C.CD_Portador ");
            sql.AppendLine("INNER JOIN TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("left JOIN tb_fin_caixa e ");
            sql.AppendLine("on e.cd_empresa = a.cd_empresa and e.cd_lanctocaixa = a.cd_lanctocaixa and e.cd_Contager = a.cd_contager ");



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

        public TList_Cupom_X_MovCaixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cupom_X_MovCaixa lista = new TList_Cupom_X_MovCaixa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cupom_X_MovCaixa reg = new TRegistro_Cupom_X_MovCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_MOVIMENTO"))))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("ID_MOVIMENTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_CUPOM"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("ID_CUPOM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CONTAGER"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_CONTAGER"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LANCTOCAIXA")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LANCTOCAIXA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_Troco")))
                        reg.Cd_lanctocaixa_troco = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_Troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PORTADOR")))
                    {
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_PORTADOR"));
                        reg.rPortador.Cd_portador = reg.Cd_portador;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                    {
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                        reg.rPortador.Ds_portador = reg.Ds_portador;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_min_parc")))
                        reg.rPortador.Qt_min_parc = reader.GetDecimal(reader.GetOrdinal("qt_min_parc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_max_parc")))
                        reg.rPortador.Qt_max_parc = reader.GetDecimal(reader.GetOrdinal("qt_max_parc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controletitulo")))
                        reg.rPortador.St_controletitulo = reader.GetString(reader.GetOrdinal("st_controletitulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tituloterceiro")))
                        reg.rPortador.St_tituloterceiro = reader.GetString(reader.GetOrdinal("st_tituloterceiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cartaocredito")))
                        reg.rPortador.St_cartaocredito = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_cartaocredito")));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_portadorpdv")))
                        reg.rPortador.Tp_portadorpdv = reader.GetString(reader.GetOrdinal("tp_portadorpdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_devcredito")))
                        reg.rPortador.St_devcredito = reader.GetString(reader.GetOrdinal("st_devcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cartafrete")))
                        reg.rPortador.St_cartafrete = reader.GetString(reader.GetOrdinal("st_cartafrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_entregafutura")))
                        reg.rPortador.St_entregafutura = reader.GetString(reader.GetOrdinal("st_entregafutura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_juro_fin")))
                        reg.rPortador.Pc_juro_fin = reader.GetDecimal(reader.GetOrdinal("pc_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_txtroca")))
                        reg.rPortador.Pc_txtroca = reader.GetDecimal(reader.GetOrdinal("pc_txtroca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Cartao")))
                        reg.rPortador.Tp_cartao = reader.GetString(reader.GetOrdinal("Tp_Cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartafrete")))
                        reg.Id_cartafrete = reader.GetDecimal(reader.GetOrdinal("id_cartafrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_portador")))
                        reg.Vl_portador = reader.GetDecimal(reader.GetOrdinal("Vl_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pagar")))
                        reg.vl_apagar = reader.GetDecimal(reader.GetOrdinal("vl_pagar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_receber")))
                        reg.vl_receber = reader.GetDecimal(reader.GetOrdinal("vl_receber"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));

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

        public string Gravar(TRegistro_Cupom_X_MovCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_LANCTOCAIXA_TROCO", val.Cd_lanctocaixa_troco);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);

            return executarProc("IA_PDV_CUPOM_X_MOVCAIXA", hs);
        }

        public string Excluir(TRegistro_Cupom_X_MovCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);

            return executarProc("EXCLUI_PDV_CUPOM_X_MOVCAIXA", hs);
        }
    }
    #endregion

    #region Venda Rapida X Dev Credito
    public class TList_Cupom_X_DevCredito : List<TRegistro_Cupom_X_DevCredito>, IComparer<TRegistro_Cupom_X_DevCredito>
    {
        #region IComparer<TRegistro_Cupom_X_DevCredito> Members
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

        public TList_Cupom_X_DevCredito()
        { }

        public TList_Cupom_X_DevCredito(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cupom_X_DevCredito value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cupom_X_DevCredito x, TRegistro_Cupom_X_DevCredito y)
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

    public class TRegistro_Cupom_X_DevCredito
    {
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
                    id_devolucao = decimal.Parse(value);
                }
                catch
                { id_devolucao = null; }
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
        private decimal? cd_lanctocaixa_dev;
        public decimal? Cd_lanctocaixa_dev
        {
            get { return cd_lanctocaixa_dev; }
            set
            {
                cd_lanctocaixa_dev = value;
                cd_lanctocaixa_devstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixa_devstr;
        public string Cd_lanctocaixa_devstr
        {
            get { return cd_lanctocaixa_devstr; }
            set
            {
                cd_lanctocaixa_devstr = value;
                try
                {
                    cd_lanctocaixa_dev = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa_dev = null; }
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
                catch
                { id_cupom = null; }
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
                catch
                { id_caixa = null; }
            }
        }
        public string Cd_portador
        { get; set; }

        public TRegistro_Cupom_X_DevCredito()
        {
            id_devolucao = null;
            id_devolucaostr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            cd_lanctocaixa_dev = null;
            cd_lanctocaixa_devstr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            Cd_empresa = string.Empty;
            id_caixa = null;
            id_caixastr = string.Empty;
            Cd_portador = string.Empty;
        }
    }

    public class TCD_Cupom_X_DevCredito : TDataQuery
    {
        public TCD_Cupom_X_DevCredito()
        { }

        public TCD_Cupom_X_DevCredito(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_devolucao, a.cd_contager, ");
                sql.AppendLine("a.cd_lanctocaixa, a.cd_lanctocaixa_dev, a.id_cupom, ");
                sql.AppendLine("a.cd_empresa, a.id_caixa, a.cd_portador ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_Cupom_X_DevCredito a ");

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

        public TList_Cupom_X_DevCredito Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cupom_X_DevCredito lista = new TList_Cupom_X_DevCredito();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cupom_X_DevCredito reg = new TRegistro_Cupom_X_DevCredito();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("id_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa_dev")))
                        reg.Cd_lanctocaixa_dev = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa_dev"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));

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

        public string Gravar(TRegistro_Cupom_X_DevCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_LANCTOCAIXA_DEV", val.Cd_lanctocaixa_dev);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return executarProc("IA_PDV_CUPOM_X_DEVCREDITO", hs);
        }

        public string Excluir(TRegistro_Cupom_X_DevCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);

            return executarProc("EXCLUI_PDV_CUPOM_X_DEVCREDITO", hs);
        }
    }
    #endregion

    #region Cupom X Venda Rapida
    public class TList_Cupom_X_VendaRapida : List<TRegistro_Cupom_X_VendaRapida>, IComparer<TRegistro_Cupom_X_VendaRapida>
    {
        #region IComparer<TRegistro_Cupom_X_VendaRapida> Members
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

        public TList_Cupom_X_VendaRapida()
        { }

        public TList_Cupom_X_VendaRapida(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cupom_X_VendaRapida value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cupom_X_VendaRapida x, TRegistro_Cupom_X_VendaRapida y)
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

    public class TRegistro_Cupom_X_VendaRapida
    {
        public decimal? Id_cupom
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Id_lancto
        { get; set; }
        public decimal? Id_vendarapida
        { get; set; }
        public decimal? Id_lanctovenda
        { get; set; }

        public TRegistro_Cupom_X_VendaRapida()
        {
            Id_cupom = null;
            Cd_empresa = string.Empty;
            Id_lancto = null;
            Id_vendarapida = null;
            Id_lanctovenda = null;
        }
    }

    public class TCD_Cupom_X_VendaRapida : TDataQuery
    {
        public TCD_Cupom_X_VendaRapida()
        { }

        public TCD_Cupom_X_VendaRapida(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_cupom, a.cd_empresa, a.id_lancto, a.id_vendarapida, a.id_lanctovenda ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_Cupom_X_VendaRapida a ");

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

        public TList_Cupom_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cupom_X_VendaRapida lista = new TList_Cupom_X_VendaRapida();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cupom_X_VendaRapida reg = new TRegistro_Cupom_X_VendaRapida();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_VendaRapida"))))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("Id_VendaRapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctovenda")))
                        reg.Id_lanctovenda = reader.GetDecimal(reader.GetOrdinal("id_lanctovenda"));

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

        public string Gravar(TRegistro_Cupom_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);

            return executarProc("IA_PDV_CUPOM_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_Cupom_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);

            return executarProc("EXCLUI_PDV_CUPOM_X_VENDARAPIDA", hs);
        }
    }
    #endregion

    #region Pedido X Venda Rapida
    public class TList_Pedido_X_VendaRapida : List<TRegistro_Pedido_X_VendaRapida>, IComparer<TRegistro_Pedido_X_VendaRapida>
    {
        #region IComparer<TRegistro_Pedido_X_VendaRapida> Members
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

        public TList_Pedido_X_VendaRapida()
        { }

        public TList_Pedido_X_VendaRapida(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Pedido_X_VendaRapida value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Pedido_X_VendaRapida x, TRegistro_Pedido_X_VendaRapida y)
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

    public class TRegistro_Pedido_X_VendaRapida
    {
        public decimal? Id_vendarapida
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Id_lanctovenda
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_pedidoitem
        { get; set; }

        public TRegistro_Pedido_X_VendaRapida()
        {
            Id_vendarapida = null;
            Cd_empresa = string.Empty;
            Id_lanctovenda = null;
            Nr_pedido = null;
            Cd_produto = string.Empty;
            Id_pedidoitem = null;
        }
    }

    public class TCD_Pedido_X_VendaRapida : TDataQuery
    {
        public TCD_Pedido_X_VendaRapida()
        { }

        public TCD_Pedido_X_VendaRapida(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_vendarapida, a.cd_empresa, a.id_lanctovenda, a.nr_pedido, a.cd_produto, a.id_pedidoitem ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_Pedido_X_VendaRapida a ");
            sql.AppendLine("INNER JOIN TB_FAT_Pedido b ");
            sql.AppendLine("ON a.nr_pedido = b.nr_pedido ");

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

        public TList_Pedido_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Pedido_X_VendaRapida lista = new TList_Pedido_X_VendaRapida();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Pedido_X_VendaRapida reg = new TRegistro_Pedido_X_VendaRapida();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_VendaRapida"))))
                        reg.Id_vendarapida = reader.GetDecimal(reader.GetOrdinal("Id_VendaRapida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctovenda")))
                        reg.Id_lanctovenda = reader.GetDecimal(reader.GetOrdinal("id_lanctovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));

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

        public string Gravar(TRegistro_Pedido_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return executarProc("IA_PDV_PEDIDO_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_Pedido_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_VENDARAPIDA", val.Id_vendarapida);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOVENDA", val.Id_lanctovenda);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return executarProc("EXCLUI_PDV_PEDIDO_X_VENDARAPIDA", hs);
        }
    }
    #endregion

    #region Venda Rapida X Orcamento
    public class TList_VendaRapida_X_Orcamento : List<TRegistro_VendaRapida_X_Orcamento>
    { }

    public class TRegistro_VendaRapida_X_Orcamento
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_lancto
        { get; set; }
        public decimal? Nr_orcamento
        { get; set; }
        public decimal? Id_item
        { get; set; }

        public TRegistro_VendaRapida_X_Orcamento()
        {
            Cd_empresa = string.Empty;
            Id_cupom = null;
            Id_lancto = null;
            Nr_orcamento = null;
            Id_item = null;
        }
    }

    public class TCD_VendaRapida_X_Orcamento : TDataQuery
    {
        public TCD_VendaRapida_X_Orcamento()
        { }

        public TCD_VendaRapida_X_Orcamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_cupom, ");
                sql.AppendLine("a.id_lancto, a.nr_orcamento, a.id_item ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_VendaRapida_X_Orcamento a ");

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

        public TList_VendaRapida_X_Orcamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_VendaRapida_X_Orcamento lista = new TList_VendaRapida_X_Orcamento();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida_X_Orcamento reg = new TRegistro_VendaRapida_X_Orcamento();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
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

        public string Gravar(TRegistro_VendaRapida_X_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("IA_PDV_VENDARAPIDA_X_ORCAMENTO", hs);
        }

        public string Excluir(TRegistro_VendaRapida_X_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_PDV_VENDARAPIDA_X_ORCAMENTO", hs);
        }
    }
    #endregion

    #region Venda Rapida X Entrega Futura
    public class TList_VendaRapida_X_EntregaFutura : List<TRegistro_VendaRapida_X_EntregaFutura>
    { }

    public class TRegistro_VendaRapida_X_EntregaFutura
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_lancto
        { get; set; }

        public TRegistro_VendaRapida_X_EntregaFutura()
        {
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Id_nfitem = null;
            Id_cupom = null;
            Id_lancto = null;
        }
    }

    public class TCD_VendaRapida_X_EntregaFutura : TDataQuery
    {
        public TCD_VendaRapida_X_EntregaFutura() { }

        public TCD_VendaRapida_X_EntregaFutura(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_cupom, ");
                sql.AppendLine("a.id_lancto, a.nr_lanctofiscal, a.id_nfitem ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_VendaRapida_X_EntregaFutura a ");

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

        public TList_VendaRapida_X_EntregaFutura Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_VendaRapida_X_EntregaFutura lista = new TList_VendaRapida_X_EntregaFutura();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaRapida_X_EntregaFutura reg = new TRegistro_VendaRapida_X_EntregaFutura();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));

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

        public string Gravar(TRegistro_VendaRapida_X_EntregaFutura val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return executarProc("IA_PDV_VENDARAPIDA_X_ENTREGAFUTURA", hs);
        }

        public string Excluir(TRegistro_VendaRapida_X_EntregaFutura val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return executarProc("EXCLUI_PDV_VENDARAPIDA_X_ENTREGAFUTURA", hs);
        }
    }
    #endregion

    #region Venda Rapida X Centro Resultado
    public class TList_Cupom_X_CCusto : List<TRegistro_Cupom_X_CCusto>
    { }

    public class TRegistro_Cupom_X_CCusto
    {
        public decimal? Id_cupom
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Id_ccustolan
        { get; set; }

        public TRegistro_Cupom_X_CCusto()
        {
            Id_cupom = null;
            Cd_empresa = string.Empty;
            Id_ccustolan = null;
        }
    }

    public class TCD_Cupom_X_CCusto : TDataQuery
    {
        public TCD_Cupom_X_CCusto()
        { }

        public TCD_Cupom_X_CCusto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_cupom, a.cd_empresa, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Cupom_X_CCusto a ");

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

        public TList_Cupom_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cupom_X_CCusto lista = new TList_Cupom_X_CCusto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cupom_X_CCusto reg = new TRegistro_Cupom_X_CCusto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));

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

        public string Gravar(TRegistro_Cupom_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("IA_FIN_CUPOM_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_Cupom_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_CUPOM_X_CCUSTO", hs);
        }
    }
    #endregion

    #region Troco Cheque
    public class TList_TrocoCH : List<TRegistro_TrocoCH>
    { }

    public class TRegistro_TrocoCH
    {
        private decimal? id_troco;
        public decimal? Id_troco
        {
            get { return id_troco; }
            set
            {
                id_troco = value;
                id_trocostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_trocostr;
        public string Id_trocostr
        {
            get { return id_trocostr; }
            set
            {
                id_trocostr = value;
                try
                {
                    id_troco = decimal.Parse(value);
                }
                catch
                { id_troco = null; }
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
                catch
                { id_caixa = null; }
            }
        }
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
        private decimal? id_movimento;
        public decimal? Id_movimento
        {
            get { return id_movimento; }
            set
            {
                id_movimento = value;
                id_movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movimentostr;
        public string Id_movimentostr
        {
            get { return id_movimentostr; }
            set
            {
                id_movimentostr = value;
                try
                {
                    id_movimento = decimal.Parse(value);
                }
                catch
                { id_movimento = null; }
            }
        }
        private decimal? id_troca;
        public decimal? Id_troca
        {
            get { return id_troca; }
            set
            {
                id_troca = value;
                id_trocastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_trocastr;
        public string Id_trocastr
        {
            get { return id_trocastr; }
            set
            {
                id_trocastr = value;
                try
                {
                    id_troca = decimal.Parse(value);
                }
                catch { id_troca = null; }
            }
        }
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
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_cgccpf
        { get; set; }

        public TRegistro_TrocoCH()
        {
            id_troco = null;
            id_trocostr = string.Empty;
            Cd_empresa = string.Empty;
            id_caixa = null;
            id_caixastr = string.Empty;
            nr_lanctocheque = null;
            nr_lanctochequestr = string.Empty;
            Cd_banco = string.Empty;
            id_movimento = null;
            id_movimentostr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cgccpf = string.Empty;
            id_troca = null;
            id_trocastr = string.Empty;
            id_devcred = null;
            id_devcredstr = string.Empty;
        }
    }

    public class TCD_TrocoCH : TDataQuery
    {
        public TCD_TrocoCH()
        { }

        public TCD_TrocoCH(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_troco, a.id_movimento, ");
                sql.AppendLine("a.cd_empresa, a.id_caixa, a.nr_lanctocheque, a.cd_banco, ");
                sql.AppendLine("c.cd_clifor, isnull(d.nm_clifor, c.nm_clifor) as NM_Clifor, ");
                sql.AppendLine("ISNULL(d.NR_CGC, d.NR_CPF) as Nr_cgccpf, a.id_troca, a.id_devcred ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_TrocoCH a ");
            sql.AppendLine("left outer join TB_PDV_Cupom_X_MovCaixa b ");
            sql.AppendLine("on a.id_movimento = b.id_movimento ");
            sql.AppendLine("left outer join TB_PDV_VendaRapida c ");
            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and b.id_cupom = c.id_vendarapida ");
            sql.AppendLine("left outer join VTB_FIN_Clifor d ");
            sql.AppendLine("on c.cd_clifor = d.cd_clifor ");

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

        public TList_TrocoCH Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocoCH lista = new TList_TrocoCH();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocoCH reg = new TRegistro_TrocoCH();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("id_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_troco")))
                        reg.Id_troco = reader.GetDecimal(reader.GetOrdinal("id_troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctocheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("nr_lanctocheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("cd_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgccpf")))
                        reg.Nr_cgccpf = reader.GetString(reader.GetOrdinal("nr_cgccpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_troca")))
                        reg.Id_troca = reader.GetDecimal(reader.GetOrdinal("id_troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devcred")))
                        reg.Id_devcred = reader.GetDecimal(reader.GetOrdinal("id_devcred"));

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

        public string Gravar(TRegistro_TrocoCH val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_TROCO", val.Id_troco);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_ID_DEVCRED", val.Id_devcred);

            return executarProc("IA_PDV_TROCOCH", hs);
        }

        public string Excluir(TRegistro_TrocoCH val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TROCO", val.Id_troco);

            return executarProc("EXCLUI_PDV_TROCOCH", hs);
        }
    }
    #endregion

    #region NFCe
    public class TList_NFCe : List<TRegistro_NFCe>, IComparer<TRegistro_NFCe>
    {
        #region IComparer<TRegistro_CupomFiscal> Members
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

        public TList_NFCe()
        { }

        public TList_NFCe(System.ComponentModel.PropertyDescriptor Prop,
                          System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_NFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_NFCe x, TRegistro_NFCe y)
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

    public class TRegistro_NFCe
    {
        private decimal? id_nfce = null;
        public decimal? Id_nfce
        {
            get { return id_nfce; }
            set
            {
                id_nfce = value;
                id_nfcestr = value?.ToString();
            }
        }
        private string id_nfcestr = string.Empty;
        public string Id_nfcestr
        {
            get { return id_nfcestr; }
            set
            {
                id_nfcestr = value;
                try
                {
                    id_nfce = decimal.Parse(value);
                }
                catch { id_nfce = null; }
            }
        }
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string Cd_uf_empresa { get; set; } = string.Empty;
        public string st_delivery { get; set; } = string.Empty;
        private decimal? id_pdv = null;
        public decimal? Id_pdv
        {
            get { return id_pdv; }
            set
            {
                id_pdv = value;
                id_pdvstr = value?.ToString();
            }
        }
        private string id_pdvstr = string.Empty;
        public string Id_pdvstr
        {
            get { return id_pdvstr; }
            set
            {
                id_pdvstr = value;
                try
                {
                    id_pdv = decimal.Parse(value);
                }
                catch { id_pdv = null; }
            }
        }
        public string Ds_pdv { get; set; } = string.Empty;
        private decimal? id_sessao = null;
        public decimal? Id_sessao
        {
            get { return id_sessao; }
            set
            {
                id_sessao = value;
                id_sessaostr = value?.ToString();
            }
        }
        private string id_sessaostr = string.Empty;
        public string Id_sessaostr
        {
            get { return id_sessaostr; }
            set
            {
                id_sessaostr = value;
                try
                {
                    id_sessao = decimal.Parse(value);
                }
                catch { id_sessao = null; }
            }
        }
        public string LoginSessao { get; set; } = string.Empty;
        public string Valor_Extenso { get; set; } = string.Empty;
        public string sigla_moeda { get; set; } = string.Empty;
        public bool st_restaurante { get; set; } = false;
        public string Cd_clifor { get; set; } = string.Empty;
        public string Nm_clifor { get; set; } = string.Empty;
        public string Nr_cgc_cpf { get; set; } = string.Empty;
        public string Cd_ufCliente { get; set; } = string.Empty;
        public string Cd_endereco { get; set; } = string.Empty;
        public string Ds_endereco { get; set; } = string.Empty;
        public string Nr_serie { get; set; } = string.Empty;
        public string Ds_serienf { get; set; } = string.Empty;
        public string Cd_modelo { get; set; } = string.Empty;
        private decimal? cd_movimentacao = null;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value?.ToString();
            }
        }
        private string cd_movimentacaostr = string.Empty;
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = decimal.Parse(value);
                }
                catch { cd_movimentacao = null; }
            }
        }
        public string Ds_movimentacao { get; set; } = string.Empty;
        private decimal? id_contingencia = null;
        public decimal? Id_contingencia
        {
            get { return id_contingencia; }
            set
            {
                id_contingencia = value;
                id_contingenciastr = value?.ToString();
            }
        }
        private string id_contingenciastr = string.Empty;
        public string Id_contingenciastr
        {
            get { return id_contingenciastr; }
            set
            {
                id_contingenciastr = value;
                try
                {
                    id_contingencia = decimal.Parse(value);
                }
                catch { id_contingencia = null; }
            }
        }
        public string LoginCanc { get; set; } = string.Empty;
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
                    return Convert.ToDateTime(dt_emissaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        private decimal? nr_nfce = null;
        public decimal? NR_NFCe
        {
            get { return nr_nfce; }
            set
            {
                nr_nfce = value;
                nr_nfcestr = value?.ToString();
            }
        }
        private string nr_nfcestr = string.Empty;
        public string NR_NFCestr
        {
            get { return nr_nfcestr; }
            set
            {
                nr_nfcestr = value;
                try
                {
                    nr_nfce = decimal.Parse(value);
                }
                catch { nr_nfce = null; }
            }
        }
        public string Ds_observacao { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Nr_requisicao { get; set; } = string.Empty;
        public string Chave_acesso { get; set; } = string.Empty;
        public string Nr_docto_origem { get; set; } = string.Empty;
        public string MotivoCanc { get; set; } = string.Empty;
        public string St_registro { get; set; } = "A";
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
        public decimal Vl_cupom { get; set; } = decimal.Zero;
        public bool St_processar { get; set; } = false;
        public string XmlNFCe { get; set; } = string.Empty;
        public string Tp_ambiente { get; set; } = string.Empty;
        public decimal? Nr_protocolo { get; set; } = null;
        public string Digval { get; set; } = string.Empty;
        public DateTime? Dt_processamento { get; set; } = null;
        public decimal? Statusnfce { get; set; } = null;
        public decimal? StatusLote { get; set; } = null;
        public string Ds_msgnfce { get; set; } = string.Empty;
        public string Veraplic { get; set; } = string.Empty;
        public string Cd_versao { get; set; } = string.Empty;
        public string CD_VersaoNFCe { get; set; } = string.Empty;
        public DateTime? dt_entcontingencia { get; set; } = null;
        public string Justificativacontingencia { get; set; } = string.Empty;
        public bool St_contingencia => id_contingencia.HasValue;
        public bool St_transmitidonfce => Nr_protocolo.HasValue;
        public bool St_transmitidocancnfce { get; set; } = false;
        public System.Drawing.Image QR_Code { get; set; } = null;

        public TList_NFCe_Item lItem { get; set; } = new TList_NFCe_Item();
        public Diversos.TRegistro_CadEmpresa rEmpresa { get; set; } = null;
        public TRegistro_CadClifor rCliente { get; set; } = null;
        public TRegistro_CadEndereco rEndCli { get; set; } = null;
        public Cadastros.TRegistro_CfgNfe rCfgNFCe { get; set; } = new Cadastros.TRegistro_CfgNfe();
        public TList_EventoNFCe lEvento { get; set; } = new TList_EventoNFCe();

        public Financeiro.Duplicata.TList_RegLanDuplicata lDup { get; set; } = new Financeiro.Duplicata.TList_RegLanDuplicata();
        public List<TRegistro_MovCaixa> lPagto { get; set; } = new List<TRegistro_MovCaixa>();
    }

    public class TCD_NFCe : TDataQuery
    {
        public TCD_NFCe() { }

        public TCD_NFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " A.ST_CUPOMDELIVERY, a.ID_NFCe, a.CD_Empresa,");
                sql.AppendLine("b.NM_Empresa, f.ds_serienf, endEmp.cd_cidade, endEmp.cd_uf, a.nr_serie, ");
                sql.AppendLine("a.DT_Emissao, a.ST_Registro, a.cd_modelo, a.pontosfid, a.pontosfidres,");
                sql.AppendLine("a.id_pdv, e.ds_pdv, a.id_sessao, a.cd_clifor, a.nm_clifor, a.cd_endereco, endClifor.CD_UF as CD_UFCliente,");
                sql.AppendLine("a.ds_endereco, a.ds_observacao, a.placa, a.nr_requisicao, a.id_venda, a.NR_Docto_Origem, a.MotivoCanc, a.LoginCanc,");
                sql.AppendLine("a.nr_cgc_cpf, a.cd_movimentacao, h.ds_movimentacao, d.Login as LoginSessao,");
                sql.AppendLine("h.Cd_CentroResult as cd_centroresultCMV, a.Chave_Acesso, ");
                sql.AppendLine("a.id_contingencia, cont.dt_entrada as dt_entcontingencia, cont.justificativa as justificativacontingencia,");
                sql.AppendLine("lnfce.tp_ambiente, lnfce.status as StatusLote, lote.NR_Protocolo, lote.DigVal, lote.DT_Processamento, lote.veraplic,");
                sql.AppendLine("lote.status, lote.ds_mensagem, lote.cd_versao, a.NR_NFCe, a.ST_TransmitidoCancNFCe,");
                sql.AppendLine("cfgNFCe.Path_NFE_Schemas, cfgNFCe.NR_Certificado_NFE, cfgNFCe.TP_Ambiente_NFCe,");
                sql.AppendLine("cfgNFCe.CD_VersaoNFCe, cfgNFCe.HorasCancNfe, cfgNFCe.NR_DiasExpirarCert,");
                //Configuração NFCe
                sql.AppendLine("cfgNFCe.ST_EnviarEmailContador, cfgNFCe.DT_AvisoCert, cfgNFCe.DS_CondUsoCCe,");
                sql.AppendLine("cfgNFCe.CD_VersaoEvento, cfgNFCe.CD_VersaoConDest,");
                sql.AppendLine("cfgNFCe.NR_CSC, cfgNFCe.ID_TokenCSC, cfgNFCe.Url_NFCe, cfgNFCe.Url_ChaveNFCe,");
                sql.AppendLine("cEmp.nr_cgc as NR_CGC_Empresa, b.tp_regimetributario, b.Insc_Municipal, a.Vl_cupom");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_NFCe a")
            .AppendLine("inner join TB_DIV_Empresa b")
            .AppendLine("on a.CD_Empresa = b.CD_Empresa")
            .AppendLine("inner join TB_FIN_Clifor_PJ cEmp")
            .AppendLine("on b.cd_clifor = cEmp.cd_clifor")
            .AppendLine("inner join VTB_FIN_Endereco endEmp")
            .AppendLine("on b.cd_clifor = endEmp.cd_clifor")
            .AppendLine("and b.cd_endereco = endEmp.cd_endereco")
            .AppendLine("left outer join VTB_FIN_Endereco endClifor")
            .AppendLine("on a.cd_clifor = endClifor.cd_clifor")
            .AppendLine("and a.cd_endereco = endClifor.cd_endereco")
            .AppendLine("left outer join TB_PDV_Sessao d")
            .AppendLine("on a.id_pdv = d.id_pdv")
            .AppendLine("and a.id_sessao = d.id_sessao")
            .AppendLine("left outer join TB_PDV_PontoVenda e")
            .AppendLine("on d.id_pdv = e.id_pdv")
            .AppendLine("left outer join TB_FAT_SerieNF f")
            .AppendLine("on a.nr_serie = f.nr_serie")
            .AppendLine("and a.cd_modelo = f.cd_modelo")
            .AppendLine("left outer join TB_FIS_Movimentacao h")
            .AppendLine("on a.cd_movimentacao = h.cd_movimentacao")
            .AppendLine("left outer join TB_PDV_CFGCupomFiscal cfg")
            .AppendLine("on a.CD_Empresa = cfg.CD_Empresa")
            .AppendLine("left outer join TB_FAT_CfgNFe cfgNFCe")
            .AppendLine("on a.cd_empresa = cfgNFCe.cd_empresa")
            .AppendLine("left outer join TB_PDV_ContingenciaNFCeOFF cont")
            .AppendLine("on a.cd_empresa = cont.cd_empresa")
            .AppendLine("and a.id_pdv = cont.id_pdv")
            .AppendLine("and a.id_contingencia = cont.id_contingencia")
            .AppendLine("left outer join TB_FAT_Lote_X_NFCe lote")
            .AppendLine("on a.cd_empresa = lote.cd_empresa")
            .AppendLine("and a.ID_NFCe = lote.id_cupom")
            .AppendLine("and lote.status in ('100', '150')")
            .AppendLine("left outer join TB_FAT_LoteNFCe lnfce")
            .AppendLine("on lote.cd_empresa = lnfce.cd_empresa")
            .AppendLine("and lote.id_lote = lnfce.id_lote");
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

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_NFCe Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_NFCe lista = new TList_NFCe();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCe reg = new TRegistro_NFCe();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFCe"))))
                        reg.Id_nfce = reader.GetDecimal(reader.GetOrdinal("ID_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NFCe")))
                        reg.NR_NFCe = reader.GetDecimal(reader.GetOrdinal("NR_NFCe"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                    {
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        reg.rCfgNFCe.Cd_empresa = reg.Cd_empresa;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                    {
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("cd_uf"));
                        reg.rCfgNFCe.Cd_uf_empresa = reg.Cd_uf_empresa;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pdv")))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("id_pdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pdv")))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("ds_pdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_sessao")))
                        reg.Id_sessao = reader.GetDecimal(reader.GetOrdinal("id_sessao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginSessao")))
                        reg.LoginSessao = reader.GetString(reader.GetOrdinal("LoginSessao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_CUPOMDELIVERY")))
                        reg.st_delivery = reader.GetString(reader.GetOrdinal("ST_CUPOMDELIVERY"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Cgc_Cpf")))
                        reg.Nr_cgc_cpf = reader.GetString(reader.GetOrdinal("NR_Cgc_Cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFCliente")))
                        reg.Cd_ufCliente = reader.GetString(reader.GetOrdinal("CD_UFCliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_requisicao")))
                        reg.Nr_requisicao = reader.GetString(reader.GetOrdinal("nr_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigVal")))
                        reg.Digval = reader.GetString(reader.GetOrdinal("DigVal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_contingencia")))
                        reg.Id_contingencia = reader.GetDecimal(reader.GetOrdinal("id_contingencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_entcontingencia")))
                        reg.dt_entcontingencia = reader.GetDateTime(reader.GetOrdinal("dt_entcontingencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("justificativacontingencia")))
                        reg.Justificativacontingencia = reader.GetString(reader.GetOrdinal("justificativacontingencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TransmitidoCancNFCe")))
                        reg.St_transmitidocancnfce = reader.GetString(reader.GetOrdinal("ST_TransmitidoCancNFCe")).Trim().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status")))
                        reg.Statusnfce = reader.GetDecimal(reader.GetOrdinal("status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("StatusLote")))
                        reg.StatusLote = reader.GetDecimal(reader.GetOrdinal("StatusLote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_mensagem")))
                        reg.Ds_msgnfce = reader.GetString(reader.GetOrdinal("ds_mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("veraplic")))
                        reg.Veraplic = reader.GetString(reader.GetOrdinal("veraplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versao")))
                        reg.Cd_versao = reader.GetString(reader.GetOrdinal("cd_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoNFCe")))
                        reg.CD_VersaoNFCe = reader.GetString(reader.GetOrdinal("CD_VersaoNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto_Origem")))
                        reg.Nr_docto_origem = reader.GetString(reader.GetOrdinal("NR_Docto_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        reg.LoginCanc = reader.GetString(reader.GetOrdinal("LoginCanc"));
                    //Cfg Nfe
                    if (!reader.IsDBNull(reader.GetOrdinal("Path_NFE_Schemas")))
                        reg.rCfgNFCe.Path_nfe_schemas = reader.GetString(reader.GetOrdinal("Path_NFE_Schemas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Certificado_NFE")))
                        reg.rCfgNFCe.Nr_certificado_nfe = reader.GetString(reader.GetOrdinal("NR_Certificado_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente_NFCe")))
                        reg.rCfgNFCe.Tp_ambiente_nfce = reader.GetString(reader.GetOrdinal("TP_Ambiente_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoNFCe")))
                        reg.rCfgNFCe.Cd_versaonfce = reader.GetString(reader.GetOrdinal("CD_VersaoNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HorasCancNfe")))
                        reg.rCfgNFCe.Horascancnfe = reader.GetDecimal(reader.GetOrdinal("HorasCancNfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasExpirarCert")))
                        reg.rCfgNFCe.Nr_diasexpirarcert = reader.GetDecimal(reader.GetOrdinal("NR_DiasExpirarCert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EnviarEmailContador")))
                        reg.rCfgNFCe.St_enviaremailcontador = reader.GetString(reader.GetOrdinal("ST_EnviarEmailContador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_AvisoCert")))
                        reg.rCfgNFCe.Dt_avisoCert = reader.GetDateTime(reader.GetOrdinal("DT_AvisoCert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondUsoCCe")))
                        reg.rCfgNFCe.Ds_condusoCCe = reader.GetString(reader.GetOrdinal("DS_CondUsoCCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoEvento")))
                        reg.rCfgNFCe.Cd_versaoEvento = reader.GetString(reader.GetOrdinal("CD_VersaoEvento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoConDest")))
                        reg.rCfgNFCe.Cd_versaocondest = reader.GetString(reader.GetOrdinal("CD_VersaoConDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.rCfgNFCe.Cd_municipio_empresa = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetributario")))
                        reg.rCfgNFCe.Tp_regimetributario = reader.GetString(reader.GetOrdinal("tp_regimetributario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_municipal")))
                        reg.rCfgNFCe.Insc_municipal_empresa = reader.GetString(reader.GetOrdinal("insc_municipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC_Empresa")))
                        reg.rCfgNFCe.Cnpj_empresa = reader.GetString(reader.GetOrdinal("NR_CGC_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("URL_NFCe")))
                        reg.rCfgNFCe.Url_nfce = reader.GetString(reader.GetOrdinal("URL_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("URL_ChaveNFCe")))
                        reg.rCfgNFCe.Url_chavenfce = reader.GetString(reader.GetOrdinal("URL_ChaveNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CSC")))
                        reg.rCfgNFCe.Nr_csc = reader.GetString(reader.GetOrdinal("NR_CSC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TokenCSC")))
                        reg.rCfgNFCe.Id_tokencsc = reader.GetString(reader.GetOrdinal("ID_TokenCSC"));

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

        public string Gravar(TRegistro_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(23);
            hs.Add("@P_ID_NFCE", val.Id_nfce);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_ID_SESSAO", val.Id_sessao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NR_CGC_CPF", val.Nr_cgc_cpf);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_ID_CONTINGENCIA", val.Id_contingencia);
            hs.Add("@P_LOGINCANC", val.LoginCanc);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_NR_NFCE", val.NR_NFCe);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_NR_REQUISICAO", val.Nr_requisicao);
            hs.Add("@P_CHAVE_ACESSO", val.Chave_acesso);
            hs.Add("@P_NR_DOCTO_ORIGEM", val.Nr_docto_origem);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDV_NFCE", hs);
        }

        public TList_NFCe SelectNFCeEnviar(string Cd_empresa)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Cd_empresa, a.ID_NFCe, a.DT_Emissao, a.cd_clifor, a.nm_clifor, a.ds_observacao, a.NR_Serie, a.Cd_Modelo, ");
            sql.AppendLine("a.cd_movimentacao, a.NR_NFCe, a.placa, a.nr_cgc_cpf, a.Chave_Acesso, a.id_contingencia, a.Vl_Cupom, ");
            sql.AppendLine("cd_uf = (select y.cd_uf ");
            sql.AppendLine("        from tb_div_empresa x ");
            sql.AppendLine("        inner join vtb_fin_endereco y ");
            sql.AppendLine("        on x.cd_clifor = y.cd_clifor ");
            sql.AppendLine("        and x.cd_endereco = y.cd_endereco ");
            sql.AppendLine("        and x.cd_empresa = a.cd_empresa)");
            sql.AppendLine("from VTB_PDV_NFCE a");
            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and a.cd_modelo = '65' ");
            sql.AppendLine("and isnull(a.st_registro, 'N') <> 'C' ");
            sql.AppendLine("and not exists (select 1 from tb_fat_lote_x_nfce x where x.cd_empresa = a.cd_empresa and x.id_cupom = a.ID_NFCe) ");
            sql.AppendLine("order by a.dt_emissao desc ");
            bool podeFecharBco = false;
            TList_NFCe lista = new TList_NFCe();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCe reg = new TRegistro_NFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFCe"))))
                        reg.Id_nfce = reader.GetDecimal(reader.GetOrdinal("ID_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NFCe")))
                        reg.NR_NFCe = reader.GetDecimal(reader.GetOrdinal("NR_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Cgc_Cpf")))
                        reg.Nr_cgc_cpf = reader.GetString(reader.GetOrdinal("NR_Cgc_Cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_contingencia")))
                        reg.Id_contingencia = reader.GetDecimal(reader.GetOrdinal("id_contingencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
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

        public void incSeqNFCe(TRegistro_NFCe vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_serie);
            hs.Add("@P_CD_MODELO", vRegistro.Cd_modelo);
            hs.Add("@P_NR_LANCTOFISCAL", DBNull.Value);

            string retorno = executarProc("INC_SEQNOTAFISCAL", hs);
            try
            {
                vRegistro.NR_NFCe = decimal.Parse(getPubVariavel(retorno, "@P_NR_NOTAFISCAL"));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro incrementar numero NFCe: " + ex.Message.Trim());
            }
        }

        public string ExcluirNFCe(TRegistro_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_NFCE", val.Id_nfce);

            return executarProc("EXCLUI_PDV_NFCE", hs);
        }
    }
    #endregion

    #region Item NFCe
    public class TList_NFCe_Item:List<TRegistro_NFCe_Item>, IComparer<TRegistro_NFCe_Item>
    {
        #region IComparer<TRegistro_CupomFiscal> Members
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

        public TList_NFCe_Item()
        { }

        public TList_NFCe_Item(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_NFCe_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_NFCe_Item x, TRegistro_NFCe_Item y)
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

    public class TRegistro_NFCe_Item
    {
        public string Cd_empresa
        { get; set; }
        public decimal? ID_NFCe
        { get; set; }
        public decimal? Id_lancto
        { get; set; }
        public int Id_itemdisplay
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cod_barra { get; set; } = string.Empty;
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ncm
        { get; set; }
        public string Cest
        { get; set; }
        public string Cd_anp
        { get; set; }
        public string Ds_anp { get; set; } = string.Empty;
        public decimal Pc_imposto_Aprox
        { get; set; }
        public decimal Vl_imposto_Aprox
        { get { return Math.Round(Math.Round(Vl_subtotalliquido, 2, MidpointRounding.AwayFromZero) * Math.Round(Pc_imposto_Aprox, 2, MidpointRounding.AwayFromZero) / 100, 2, MidpointRounding.AwayFromZero); } }
        public decimal Pc_aliquotasimples
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public string Ds_cfop
        { get; set; }
        public decimal Pc_AutorizadoDesc
        { get; set; }
        private decimal quantidade;
        public decimal Quantidade
        {
            get { return Math.Round(quantidade, 3, MidpointRounding.AwayFromZero); }
            set { quantidade = Math.Round(value, 3, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return Math.Round(vl_unitario, 7, MidpointRounding.AwayFromZero); }
            set { vl_unitario = Math.Round(value, 7, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_subtotal, 2) : Math.Round(vl_subtotal, 2, MidpointRounding.AwayFromZero); }
            set { vl_subtotal = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_desconto, 5) : Math.Round(vl_desconto, 5, MidpointRounding.AwayFromZero); }
            set { vl_desconto = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 5) : Math.Round(value, 5, MidpointRounding.AwayFromZero); }
        }
        public decimal Pc_desconto
        { get; set; }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_acrescimo, 5) : Math.Round(vl_acrescimo, 5, MidpointRounding.AwayFromZero); }
            set { vl_acrescimo = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 5) : Math.Round(value, 5, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_frete;
        public decimal Vl_frete
        {
            get { return Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(vl_frete, 2) : Math.Round(vl_frete, 2, MidpointRounding.AwayFromZero); }
            set { vl_frete = Utils.Parametros.pubTruncarSubTotal ? Utils.Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        public decimal Pc_acrescimo
        { get; set; }
        public decimal Vl_juro_fin
        { get; set; }
        public decimal Vl_subtotalliquido
        {
            get
            {
                return Utils.Parametros.pubTruncarSubTotal ?
            Utils.Estruturas.Truncar(Vl_subtotal + vl_frete + vl_acrescimo + Vl_juro_fin - vl_desconto, 2) :
            Math.Round(Vl_subtotal + vl_frete + vl_acrescimo + Vl_juro_fin - vl_desconto, 2, MidpointRounding.AwayFromZero);
            }
        }
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
        public string Ds_promocao
        { get; set; }
        public DateTime? Dt_emissao
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
        #region Fiscal
        public decimal? Cd_icms { get; set; } = null;
        public string Cd_st_icms { get; set; } = null;
        public decimal? Cd_pis { get; set; } = null;
        public string Cd_st_pis { get; set; } = null;
        public decimal? Cd_cofins { get; set; } = null;
        public string Cd_st_cofins { get; set; } = null;
        public decimal? Id_tpcontribuicaoPIS { get; set; } = null;
        public decimal? Id_tpcontribuicaoCOFINS { get; set; } = null;
        public decimal? Id_detrecisentaPIS { get; set; } = null;
        public decimal? Id_detrecisentaCofins { get; set; } = null;
        public decimal? Id_receitaPIS { get; set; } = null;
        public decimal? Id_receitaCofins { get; set; } = null;
        public decimal Pc_aliquotaICMS { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaPIS { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaCofins { get; set; } = decimal.Zero;
        public decimal Vl_icms { get; set; } = decimal.Zero;
        public decimal Vl_pis { get; set; } = decimal.Zero;
        public decimal Vl_cofins { get; set; } = decimal.Zero;
        public decimal Vl_basecalcICMS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcPIS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcCofins { get; set; } = decimal.Zero;
        public bool St_gerarCredito { get; set; } = false;
        public string Tp_situacao { get; set; } = string.Empty;
        public string Tp_modbasecalc { get; set; } = string.Empty;
        public string Tp_modbasecalcST { get; set; } = string.Empty;
        #endregion
        public TList_VendaRapida_Item lItemVR
        { get; set; }
        public Servicos.TList_LanServicosPecas lPecasOS
        { get; set; }
        public CamadaDados.Locacao.TList_AbastItens lAbastItens
        { get; set; }
        public decimal Qt_pontosutilizados
        { get; set; }
        public string Placa_KM
        { get; set; }
        public string NR_Bico
        { get; set; }
        public decimal EncerranteFin
        { get; set; }
        public bool St_combustivel
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal id_item { get; set; }
        public decimal id_prevenda { get; set; }
        public bool st_servico { get; set; }
        public decimal? Id_loteCTB { get; set; } = null;
        public TRegistro_NFCe_Item()
        {
            st_servico = false;
            Cd_empresa = string.Empty;
            ID_NFCe = null;
            Id_lancto = null;
            Id_itemdisplay = 0;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ncm = string.Empty;
            Cest = string.Empty;
            Cd_anp = string.Empty;
            Pc_imposto_Aprox = decimal.Zero;
            Pc_aliquotasimples = decimal.Zero;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_cfop = string.Empty;
            Ds_cfop = string.Empty;
            Pc_AutorizadoDesc = decimal.Zero;
            quantidade = decimal.Zero;
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_desconto = decimal.Zero;
            Pc_desconto = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            Pc_acrescimo = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
            vl_frete = decimal.Zero;
            St_registro = "A";
            Ds_promocao = string.Empty;
            lItemVR = new TList_VendaRapida_Item();
            lPecasOS = new Servicos.TList_LanServicosPecas();
            St_processar = false;
            Dt_emissao = null;
            Qt_pontosutilizados = decimal.Zero;
            Placa_KM = string.Empty;
            st_baixapatrimonio = "N";
            st_baixapatrimoniobool = false;
            lAbastItens = new CamadaDados.Locacao.TList_AbastItens();
            NR_Bico = string.Empty;
            EncerranteFin = decimal.Zero;
            St_combustivel = false;
            id_item = decimal.Zero;
            id_prevenda = decimal.Zero;
        }
    }

    public class TCD_NFCe_Item : TDataQuery
    {
        public TCD_NFCe_Item() { }

        public TCD_NFCe_Item(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_NFCE, a.id_lancto, a.cd_produto, b.ncm, b.cd_anp, ")
                .AppendLine("b.DS_Produto, c.CD_Unidade, c.DS_Unidade, b.cd_condfiscal_produto, nc.cest, a.id_lotectb, anp.ds_anp,")
                .AppendLine("c.Sigla_Unidade, b.cd_grupo, gProd.ds_grupo, nfce.cd_clifor, nfce.nm_clifor, ")
                .AppendLine("a.quantidade, a.vl_unitario, a.vl_desconto, a.cd_empresa, tp.st_combustivel,")
                .AppendLine("a.vl_subtotal, a.st_registro, a.PC_AliquotaSimples,")
                .AppendLine("a.Vl_Acrescimo, a.Vl_Juro_Fin, a.Vl_frete, a.cd_cfop, f.ds_cfop,")
                .AppendLine("nfce.dt_emissao, a.St_BaixaPatrimonio, a.PC_Imposto_Aprox,")
                .AppendLine("Cod_barra = (select top 1 x.cd_codbarra from tb_est_codbarra x where x.cd_produto = b.cd_produto), ")
                //Dados Fiscais
                .AppendLine("a.cd_icms, a.cd_st_icms, a.cd_pis, a.cd_st_pis, a.cd_cofins, a.cd_st_cofins, ")
                .AppendLine("a.id_tpcontribuicaoPIS, a.id_tpcontribuicaoCofins, ")
                .AppendLine("a.id_detrecisentaPIS, a.id_detrecisentaCofins, ")
                .AppendLine("a.id_receitaPIS, a.id_receitaCofins, a.pc_aliquotaicms, ")
                .AppendLine("a.pc_aliquotapis, a.pc_aliquotacofins, a.vl_icms, ")
                .AppendLine("a.vl_pis, a.vl_cofins, a.vl_basecalcICMS, a.vl_basecalcPIS, ")
                .AppendLine("a.vl_basecalcCofins, a.st_gerarcredito, a.tp_situacao, ")
                .AppendLine("a.tp_modbasecalc, a.tp_modbasecalcST ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_NFCe_Item a")
               .AppendLine("inner join TB_PDV_NFCE nfce")
               .AppendLine("on a.ID_NFCE = nfce.ID_NFCe")
               .AppendLine("and a.cd_empresa = nfce.CD_Empresa")
               .AppendLine("inner join TB_EST_Produto b")
               .AppendLine("on a.cd_produto = b.CD_Produto")
               .AppendLine("inner join TB_EST_Unidade c")
               .AppendLine("on b.CD_Unidade = c.CD_Unidade")
               .AppendLine("inner join TB_EST_TpProduto tp")
               .AppendLine("on b.tp_produto = tp.tp_produto")
               .AppendLine("inner join TB_EST_GrupoProduto gProd")
               .AppendLine("on b.cd_grupo = gProd.cd_grupo")
               .AppendLine("left outer join tb_fis_cfop f")
               .AppendLine("on a.cd_cfop = f.cd_cfop")
               .AppendLine("left outer  join tb_fis_ncm nc")
               .AppendLine("on b.ncm = nc.ncm")
               .AppendLine("left outer join tb_est_anp anp")
               .AppendLine("on b.cd_anp = anp.cd_anp");

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

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, string.Empty }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }
        }

        public TList_NFCe_Item Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_NFCe_Item lista = new TList_NFCe_Item();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCe_Item reg = new TRegistro_NFCe_Item();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFCe"))))
                        reg.ID_NFCe = reader.GetDecimal(reader.GetOrdinal("ID_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cod_barra")))
                        reg.Cod_barra = reader.GetString(reader.GetOrdinal("Cod_barra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_imposto_aprox")))
                        reg.Pc_imposto_Aprox = reader.GetDecimal(reader.GetOrdinal("pc_imposto_aprox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotasimples")))
                        reg.Pc_aliquotasimples = reader.GetDecimal(reader.GetOrdinal("pc_aliquotasimples"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfop")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("ds_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("vl_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_BaixaPatrimonio")))
                        reg.St_baixapatrimonio = reader.GetString(reader.GetOrdinal("St_BaixaPatrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_combustivel")))
                        reg.St_combustivel = reader.GetString(reader.GetOrdinal("st_combustivel")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));
                    //Fiscal
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ICMS")))
                        reg.Cd_icms = reader.GetDecimal(reader.GetOrdinal("CD_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST_ICMS")))
                        reg.Cd_st_icms = reader.GetString(reader.GetOrdinal("CD_ST_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_pis")))
                        reg.Cd_pis = reader.GetDecimal(reader.GetOrdinal("cd_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st_pis")))
                        reg.Cd_st_pis = reader.GetString(reader.GetOrdinal("cd_st_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cofins")))
                        reg.Cd_cofins = reader.GetDecimal(reader.GetOrdinal("cd_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st_cofins")))
                        reg.Cd_st_cofins = reader.GetString(reader.GetOrdinal("cd_st_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcontribuicaopis")))
                        reg.Id_tpcontribuicaoPIS = reader.GetDecimal(reader.GetOrdinal("id_tpcontribuicaopis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcontribuicaocofins")))
                        reg.Id_tpcontribuicaoCOFINS = reader.GetDecimal(reader.GetOrdinal("id_tpcontribuicaocofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_detrecisentapis")))
                        reg.Id_detrecisentaPIS = reader.GetDecimal(reader.GetOrdinal("id_detrecisentapis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_detrecisentacofins")))
                        reg.Id_detrecisentaCofins = reader.GetDecimal(reader.GetOrdinal("id_detrecisentacofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receitapis")))
                        reg.Id_receitaPIS = reader.GetDecimal(reader.GetOrdinal("id_receitapis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receitacofins")))
                        reg.Id_receitaCofins = reader.GetDecimal(reader.GetOrdinal("id_receitacofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicms")))
                        reg.Pc_aliquotaICMS = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotapis")))
                        reg.Pc_aliquotaPIS = reader.GetDecimal(reader.GetOrdinal("pc_aliquotapis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotacofins")))
                        reg.Pc_aliquotaCofins = reader.GetDecimal(reader.GetOrdinal("pc_aliquotacofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pis")))
                        reg.Vl_pis = reader.GetDecimal(reader.GetOrdinal("vl_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cofins")))
                        reg.Vl_cofins = reader.GetDecimal(reader.GetOrdinal("vl_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcicms")))
                        reg.Vl_basecalcICMS = reader.GetDecimal(reader.GetOrdinal("vl_basecalcicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcpis")))
                        reg.Vl_basecalcPIS = reader.GetDecimal(reader.GetOrdinal("vl_basecalcpis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalccofins")))
                        reg.Vl_basecalcCofins = reader.GetDecimal(reader.GetOrdinal("vl_basecalccofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarcredito")))
                        reg.St_gerarCredito = reader.GetBoolean(reader.GetOrdinal("st_gerarcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("tp_situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modbasecalc")))
                        reg.Tp_modbasecalc = reader.GetString(reader.GetOrdinal("tp_modbasecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modbasecalcst")))
                        reg.Tp_modbasecalcST = reader.GetString(reader.GetOrdinal("tp_modbasecalcst"));

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

        public string Gravar(TRegistro_NFCe_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(17);
            hs.Add("@P_ID_NFCE", val.ID_NFCe);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_CFOP", val.Cd_cfop);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_ACRESCIMO", val.Vl_acrescimo);
            hs.Add("@P_VL_JURO_FIN", val.Vl_juro_fin);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_PC_IMPOSTO_APROX", val.Pc_imposto_Aprox);
            hs.Add("@P_PC_ALIQUOTASIMPLES", val.Pc_aliquotasimples);
            hs.Add("@P_ST_BAIXAPATRIMONIO", val.St_baixapatrimonio);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            //Fiscal
            hs.Add("@P_CD_ICMS", val.Cd_icms);
            hs.Add("@P_CD_ST_ICMS", val.Cd_st_icms);
            hs.Add("@P_CD_PIS", val.Cd_pis);
            hs.Add("@P_CD_ST_PIS", val.Cd_st_pis);
            hs.Add("@P_CD_COFINS", val.Cd_cofins);
            hs.Add("@P_CD_ST_COFINS", val.Cd_st_cofins);
            hs.Add("@P_ID_TPCONTRIBUICAOPIS", val.Id_tpcontribuicaoPIS);
            hs.Add("@P_ID_TPCONTRIBUICAOCOFINS", val.Id_tpcontribuicaoCOFINS);
            hs.Add("@P_ID_DETRECISENTAPIS", val.Id_detrecisentaPIS);
            hs.Add("@P_ID_DETRECISENTACOFINS", val.Id_detrecisentaCofins);
            hs.Add("@P_ID_RECEITAPIS", val.Id_receitaPIS);
            hs.Add("@P_ID_RECEITACOFINS", val.Id_receitaCofins);
            hs.Add("@P_PC_ALIQUOTAICMS", val.Pc_aliquotaICMS);
            hs.Add("@P_PC_ALIQUOTAPIS", val.Pc_aliquotaPIS);
            hs.Add("@P_PC_ALIQUOTACOFINS", val.Pc_aliquotaCofins);
            hs.Add("@P_VL_ICMS", val.Vl_icms);
            hs.Add("@P_VL_PIS", val.Vl_pis);
            hs.Add("@P_VL_COFINS", val.Vl_cofins);
            hs.Add("@P_VL_BASECALCICMS", val.Vl_basecalcICMS);
            hs.Add("@P_VL_BASECALCPIS", val.Vl_basecalcPIS);
            hs.Add("@P_VL_BASECALCCOFINS", val.Vl_basecalcCofins);
            hs.Add("@P_ST_GERARCREDITO", val.St_gerarCredito);
            hs.Add("@P_TP_SITUACAO", val.Tp_situacao);
            hs.Add("@P_TP_MODBASECALC", val.Tp_modbasecalc);
            hs.Add("@P_TP_MODBASECALCST", val.Tp_modbasecalcST);

            return executarProc("IA_PDV_NFCE_ITEM", hs);
        }

        public string Excluir(TRegistro_NFCe_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_NFCE", val.ID_NFCe);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("EXCLUI_PDV_NFCE_ITEM", hs);
        }
    }
    #endregion

    #region XML NFCe
    public class TList_XML_NFCe:List<TRegistro_XML_NFCe>
    {

    }

    public class TRegistro_XML_NFCe
    {
        private decimal? _id_registro = null;
        public decimal? Id_registro
        {
            get { return _id_registro; }
            set
            {
                _id_registro = value;
                _id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string _id_registrostr = string.Empty;
        public string Id_registrostr
        {
            get { return _id_registrostr; }
            set
            {
                _id_registrostr = value;
                try
                {
                    _id_registro = decimal.Parse(value);
                }
                catch { _id_registro = null; }
            }
        }
        public string Cd_empresa { get; set; } = string.Empty;
        private decimal? _id_nfce = null;
        public decimal? Id_nfce
        {
            get { return _id_nfce; }
            set
            {
                _id_nfce = value;
                _id_nfcestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string _id_nfcestr = string.Empty;
        public string Id_nfcestr
        {
            get { return _id_nfcestr; }
            set
            {
                _id_nfcestr = value;
                try
                {
                    _id_nfce = decimal.Parse(value);
                }
                catch { _id_nfce = null; }
            }
        }
        public string Xml_nfce { get; set; } = string.Empty;

        //Propriedade utilizadas para gerar XML
        public string Tp_ambiente { get; set; } = string.Empty;
        public string Veraplic { get; set; } = string.Empty;
        public string Chave_acesso { get; set; } = string.Empty;
        public DateTime? Dt_processamento { get; set; } = null;
        public decimal? Nr_protocolo { get; set; } = null;
        public string Digval { get; set; } = string.Empty;
        public decimal? Statusnfce { get; set; } = null;
        public string Ds_msgnfce { get; set; } = string.Empty;
        public decimal? Nr_NFCe { get; set; } = null;
    }

    public class TCD_XML_NFCe:TDataQuery
    {
        public TCD_XML_NFCe() { }

        public TCD_XML_NFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_registro, a.cd_empresa, a.id_nfce, a.xml_nfce, ");
                sql.AppendLine("d.tp_ambiente, c.VerAplic, b.Chave_Acesso, c.DT_Processamento, ");
                sql.AppendLine("c.NR_Protocolo, c.Digval, c.Status, c.DS_Mensagem ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_PDV_XML_NFCe a ");
            sql.AppendLine("inner join TB_PDV_NFCe b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_nfce = b.id_nfce ");
            sql.AppendLine("inner join TB_FAT_Lote_X_NFCe c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.id_nfce = c.id_cupom ");
            sql.AppendLine("inner join TB_FAT_LoteNFCe d ");
            sql.AppendLine("on c.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and c.id_lote = d.id_lote ");

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

        public TList_XML_NFCe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_XML_NFCe lista = new TList_XML_NFCe();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_XML_NFCe reg = new TRegistro_XML_NFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfce")))
                        reg.Id_nfce = reader.GetDecimal(reader.GetOrdinal("id_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_nfce")))
                        reg.Xml_nfce = reader.GetString(reader.GetOrdinal("xml_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VerAplic")))
                        reg.Veraplic = reader.GetString(reader.GetOrdinal("VerAplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Digval")))
                        reg.Digval = reader.GetString(reader.GetOrdinal("Digval"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.Statusnfce = reader.GetDecimal(reader.GetOrdinal("Status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_msgnfce = reader.GetString(reader.GetOrdinal("DS_Mensagem"));

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

        public string Gravar(TRegistro_XML_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_NFCE", val.Id_nfce);
            hs.Add("@P_XML_NFCE", val.Xml_nfce);

            return executarProc("IA_PDV_XML_NFCE", hs);
        }

        public string Excluir(TRegistro_XML_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);

            return executarProc("EXCLUI_PDV_XML_NFCE", hs);
        }
    }
    #endregion
}
