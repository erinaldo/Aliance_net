using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Faturamento.Pedido;

namespace CamadaDados.Graos
{
    #region Contrato
    public class TList_CadContrato : List<TRegistro_CadContrato>, IComparer<TRegistro_CadContrato>
    {
        #region IComparer<TRegistro_CadContrato> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadContrato()
        { }

        public TList_CadContrato(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadContrato value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadContrato x, TRegistro_CadContrato y)
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
    
    public class TRegistro_CadContrato
    {
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = (value.HasValue ? value.Value.ToString() : string.Empty);
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
        public string Cd_tabeladesconto
        { get; set; }
        public string Ds_tabeladesconto
        { get; set; }
        public string Nr_contratoorigem
        { get; set; }
        public string Anosafra
        { get; set; }
        public string Ds_safra
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Tp_pessoa
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Ds_obsgro
        { get; set; }
        private string tp_prodcontrato;
        public string Tp_prodcontrato
        {
            get { return tp_prodcontrato; }
            set
            {
                tp_prodcontrato = value;
                if (value.Trim().ToUpper().Equals("CV"))
                    tipo_prodcontrato = "CONVENCIONAL";
                else if (value.Trim().ToUpper().Equals("TR"))
                    tipo_prodcontrato = "TRANSGÊNICA";
                else if (value.Trim().ToUpper().Equals("ID"))
                    tipo_prodcontrato = "INTACTA DECLARADA";
                else if (value.Trim().ToUpper().Equals("IP"))
                    tipo_prodcontrato = "INTACTA PARTICIPANTE";
            }
        }
        private string tipo_prodcontrato;
        public string Tipo_prodcontrato
        {
            get { return tipo_prodcontrato; }
            set
            {
                tipo_prodcontrato = value;
                if (value.Trim().ToUpper().Equals("CONVENCIONAL"))
                    tp_prodcontrato = "CV";
                else if (value.Trim().ToUpper().Equals("TRANSGÊNICA"))
                    tp_prodcontrato = "TR";
                else if (value.Trim().ToUpper().Equals("INTACTA DECLARADA"))
                    tp_prodcontrato = "ID";
                else if (value.Trim().ToUpper().Equals("INTACTA PARTICIPANTE"))
                    tp_prodcontrato = "IP";
            }
        }
        private string tp_frete;
        public string Tp_frete
        {
            get { return tp_frete; }
            set
            {
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_frete = "EMITENTE";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_frete = "DESTINATARIO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_frete = "TERCEIRO";
                else if (value.Trim().ToUpper().Equals("9"))
                    tipo_frete = "SEM FRETE";;
            }
        }
        private string tipo_frete;
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("EMITENTE"))
                    tp_frete = "0";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_frete = "1";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_frete = "2";
                else if (value.Trim().ToUpper().Equals("SEM FRETE"))
                    tp_frete = "9";
            }
        }
        private DateTime? dt_abertura;
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy");
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
        private DateTime? dt_encerramento;
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_encerramentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = Convert.ToDateTime(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
            }
        }
        private string st_exigirautorizretirada;
        public string St_exigirautorizretirada
        {
            get { return st_exigirautorizretirada; }
            set
            {
                st_exigirautorizretirada = value;
                st_exigirautorizretiradabool = value.ToString().Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirautorizretiradabool;
        public bool St_exigirautorizretiradabool
        {
            get { return st_exigirautorizretiradabool; }
            set
            {
                st_exigirautorizretiradabool = value;
                if (value)
                    st_exigirautorizretirada = "S";
                else
                    st_exigirautorizretirada = "N";
            }
        }
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostr;
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        private decimal? id_pedidoitem;
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemstr;
        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = decimal.Parse(value);
                }
                catch { id_pedidoitem = null; }
            }
        }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        public bool St_valoresfixos
        { get; set; }
        public bool St_deposito
        { get; set; }
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Sigla_moeda
        { get; set; }
        public string CD_CondPGTO
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unid_produto
        { get; set; }
        public string Ds_unid_produto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Sigla_unid_produto
        { get; set; }
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
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public string Cd_produtoembalagem
        { get; set; }
        public string Ds_produtoembalagem
        { get; set; }
        public string Sigla_undembalagem
        { get; set; }
        public string Cd_localembalagem
        { get; set; }
        public string Ds_localembalagem
        { get; set; }
        public string DS_Endereco_Empresa { get; set; }
        public string DS_Cidade_Empresa { get; set; }
        public string CD_UFEmpresa { get; set; }
        public string UF_Empresa { get; set; }
        public string CEP_Empresa { get; set; }
        public string CNPJ_Empresa { get; set; }
        public string IE_Empresa { get; set; }
        public string Bairro_Empresa { get; set; }
        public string DS_Cidade_Clifor { get; set; }
        public string CD_UFClifor { get; set; }
        public string UF_Clifor { get; set; }
        public string IE_Clifor { get; set; }
        public string CPF_CNPJ_Clifor { get; set; }
        public string CEP_Clifor { get; set; }
        public string Bairro_Clifor { get; set; }
        public string NumEnderecoClifor { get; set; }
        public string NumEnderecoEmpresa { get; set; }
        public string Padrao_qualidade
        { get; set; }
        public string Cd_condpgto_fix
        { get; set; }
        public string Ds_condpgto_fix
        { get; set; }
        public string Cd_portador_fix
        { get; set; }
        public string Ds_portador_fix
        { get; set; }
        public string Cd_historico_fix
        { get; set; }
        public string Ds_historico_fix
        { get; set; }
        public string Tp_mov_historico_fix
        { get; set; }
        public string Tp_duplicata_fix
        { get; set; }
        public string Ds_tpduplicata_fix
        { get; set; }
        public string Tp_mov_duplicata_fix
        { get; set; }
        public string Cd_contager_fix
        { get; set; }
        public string Ds_contager_fix
        { get; set; }
        private decimal? tp_docto_fix;
        public decimal? Tp_docto_fix
        {
            get { return tp_docto_fix; }
            set
            {
                tp_docto_fix = value;
                tp_doctostr_fix = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr_fix;
        public string Tp_doctostr_fix
        {
            get { return tp_doctostr_fix; }
            set
            {
                tp_doctostr_fix = value;
                try
                {
                    tp_docto_fix = Convert.ToDecimal(value);
                }
                catch
                { tp_docto_fix = null; }
            }
        }
        public string Ds_tpdocto_fix
        { get; set; }
        public decimal Vl_bonificacao_fix
        { get; set; }
        public string Cd_tipoamostra1
        { get; set; }
        public string Ds_tipoamostra1
        { get; set; }
        public string Cd_tipoamostra2
        { get; set; }
        public string Ds_tipoamostra2
        { get; set; }
        public TList_CadContratoTaxaDeposito Taxas
        { get; set; }
        public TList_CadContratoTaxaDeposito DelTaxas
        { get; set; }
        public TList_CadContrato_Headge lContrato_Headge { get; set; }
        public TList_CadContrato_Headge lDelContrato_Headge { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdto
        { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto
        { get; set; }
        public CamadaDados.Estoque.TList_RegLanEstoque lEstoqueEmbalagem
        { get; set; }
        public TList_Contrato_X_DesdEspecial lDesdobro
        { get; set; }
        public TList_Contrato_X_DesdEspecial lDesdobroDel
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal Pedido_Fiscal
        { get; set; }
        public decimal Qtd_embalagem_cedida
        {
            get
            {
                if (lEstoqueEmbalagem != null)
                    return lEstoqueEmbalagem.Sum(p => (this.tp_movimento.Trim().ToUpper().Equals("E") ?  p.Qtd_saida : p.Qtd_entrada));
                else
                    return decimal.Zero;
            }
        }
        public decimal Qtd_embalagem_devolvida
        {
            get
            {
                if (lEstoqueEmbalagem != null)
                    return lEstoqueEmbalagem.Sum(p => (this.tp_movimento.Trim().ToUpper().Equals("E") ? p.Qtd_entrada : p.Qtd_saida));
                else
                    return decimal.Zero;
            }
        }
        public decimal Qtd_saldoembalagem
        {
            get { return Qtd_embalagem_cedida - Qtd_embalagem_devolvida; }
        }

        public TRegistro_CadContrato()
        {
            this.Anosafra = string.Empty;
            this.Bairro_Clifor = string.Empty;
            this.Bairro_Empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Cd_condpgto_fix = string.Empty;
            this.Cd_contager_fix = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Cd_historico_fix = string.Empty;
            this.Cd_local = string.Empty;
            this.Cd_localembalagem = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Cd_portador_fix = string.Empty;
            this.Cd_produto = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_produtoembalagem = string.Empty;
            this.Cd_tabeladesconto = string.Empty;
            this.Cd_tipoamostra1 = string.Empty;
            this.Cd_tipoamostra2 = string.Empty;
            this.Cd_unid_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.CEP_Clifor = string.Empty;
            this.CEP_Empresa = string.Empty;
            this.Cfg_pedido = string.Empty;
            this.St_valoresfixos = false;
            this.St_deposito = false;
            this.CNPJ_Empresa = string.Empty;
            this.CPF_CNPJ_Clifor = string.Empty;
            this.DelTaxas = new TList_CadContratoTaxaDeposito();
            this.DS_Cidade_Clifor = string.Empty;
            this.DS_Cidade_Empresa = string.Empty;
            this.Ds_condpgto_fix = string.Empty;
            this.Ds_contager_fix = string.Empty;
            this.Ds_endereco = string.Empty;
            this.DS_Endereco_Empresa = string.Empty;
            this.Ds_historico_fix = string.Empty;
            this.Ds_local = string.Empty;
            this.Ds_localembalagem = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Ds_obsgro = string.Empty;
            this.Ds_portador_fix = string.Empty;
            this.Ds_produto = string.Empty;
            this.Ds_produtoembalagem = string.Empty;
            this.Ds_safra = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.Ds_tipoamostra1 = string.Empty;
            this.Ds_tipoamostra2 = string.Empty;
            this.Ds_tipopedido = string.Empty;
            this.Ds_tpdocto_fix = string.Empty;
            this.Ds_tpduplicata_fix = string.Empty;
            this.Vl_bonificacao_fix = decimal.Zero;
            this.Ds_unid_produto = string.Empty;
            this.Ds_unidade = string.Empty;
            this.dt_abertura = DateTime.Now;
            this.dt_aberturastr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_encerramento = null;
            this.dt_encerramentostr = string.Empty;
            this.id_pedidoitem = null;
            this.id_pedidoitemstr = string.Empty;
            this.IE_Clifor = string.Empty;
            this.IE_Empresa = string.Empty;
            this.lAdto = new CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento();
            this.lContrato_Headge = new TList_CadContrato_Headge();
            this.lDelContrato_Headge = new TList_CadContrato_Headge();
            this.lDesdobro = new TList_Contrato_X_DesdEspecial();
            this.lDesdobroDel = new TList_Contrato_X_DesdEspecial();
            this.lEstoqueEmbalagem = new CamadaDados.Estoque.TList_RegLanEstoque();
            this.Nm_clifor = string.Empty;
            this.Cd_condfiscal_clifor = string.Empty;
            this.Tp_pessoa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.nr_contrato = null;
            this.Nr_contratoorigem = string.Empty;
            this.nr_contratostr = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.NumEnderecoClifor = string.Empty;
            this.NumEnderecoEmpresa = string.Empty;
            this.Padrao_qualidade = string.Empty;
            this.Quantidade = decimal.Zero;
            this.rAdto = null;
            this.Sigla_moeda = string.Empty;
            this.CD_CondPGTO = string.Empty;
            this.Sigla_undembalagem = string.Empty;
            this.Sigla_unid_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.st_exigirautorizretirada = "N";
            this.st_exigirautorizretiradabool = false;
            this.st_registro = "A";
            this.status = "ATIVO";
            this.Taxas = new TList_CadContratoTaxaDeposito();
            this.tipo_movimento = string.Empty;
            this.tp_docto_fix = null;
            this.tp_doctostr_fix = string.Empty;
            this.Tp_duplicata_fix = string.Empty;
            this.Tp_mov_duplicata_fix = string.Empty;
            this.Tp_mov_historico_fix = string.Empty;
            this.tp_movimento = string.Empty;
            this.CD_UFClifor = string.Empty;
            this.UF_Clifor = string.Empty;
            this.CD_UFEmpresa = string.Empty;
            this.UF_Empresa = string.Empty;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.tp_prodcontrato = "CV";
            this.tipo_prodcontrato = "CONVENCIONAL";
            this.tp_frete = "9";
            this.tipo_frete = "SEM FRETE";
            this.Pedido_Fiscal = new CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal();
        }
    }

    public class TCD_CadContrato : TDataQuery
    {
        public TCD_CadContrato()
        { }

        public TCD_CadContrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.cd_tabeladesconto, b.ds_tabeladesconto, b.padrao_qualidade, ");
                sql.AppendLine("a.anosafra, c.ds_safra, a.cd_clifor, d.nm_clifor, a.cd_endereco, e.ds_endereco,e.insc_estadual, ");
                sql.AppendLine("a.cd_empresa, f.nm_empresa, a.ds_obsgro, a.tp_prodcontrato, a.dt_abertura, e.ds_cidade, e.uf, e.cd_uf, ");
                sql.AppendLine("a.dt_encerramento, a.st_registro, a.tp_movimento, isnull(d.Nr_CGC,d.NR_CPF) as NR_CGCCPF,e.cep,e.bairro, ");
                sql.AppendLine("endEmpresa.numero as NumEmpresa, e.numero, a.nr_contratoorigem, a.cd_condpgto, d.cd_condfiscal_clifor, d.tp_pessoa, ");
                sql.AppendLine("endEmpresa.ds_endereco as endempresa, endEmpresa.ds_cidade as CidEmpresa, endEmpresa.uf as UFEmpresa, ");
                sql.AppendLine("endEmpresa.bairro as BairroEmp, endEmpresa.cep as cepEmpresa, endEmpresa.cd_uf as CD_UFEmpresa, ");
                sql.AppendLine("endEmpresa.insc_estadual as IEEmpresa, isnull(Clifemp.nr_cgc,Clifemp.nr_cpf) as NRCRC_Empresa, ");
                sql.AppendLine("a.cd_produtoembalagem, g.ds_produto as ds_produtoembalagem, UNDEmb.sigla_unidade as sigla_undembalagem, ");
                sql.AppendLine("a.cd_localembalagem, h.ds_local as ds_localembalagem, a.st_exigirautorizretirada, ");
                sql.AppendLine("a.cd_condpgto_fix, i.ds_condpgto as ds_condpgto_fix, ");
                sql.AppendLine("a.cd_portador_fix, j.ds_portador as ds_portador_fix, ");
                sql.AppendLine("a.cd_historico_fix, k.ds_historico as ds_historico_fix, k.tp_mov as tp_movhistorico_fix, ");
                sql.AppendLine("a.tp_duplicata_fix, l.ds_tpduplicata as ds_tpduplicata_fix, l.tp_mov as tp_movduplicata_fix, ");
                sql.AppendLine("a.cd_contager_fix, m.ds_contager as ds_contager_fix, ");
                sql.AppendLine("a.tp_docto_fix, n.ds_tpdocto as ds_tpdocto_fix, a.vl_bonificacao_fix, ");
                sql.AppendLine("a.cd_tipoamostra1, o.ds_amostra as ds_tipoamostra1, ");
                sql.AppendLine("a.cd_tipoamostra2, p.ds_amostra as ds_tipoamostra2, ");
                sql.AppendLine("a.Nr_Pedido, a.ID_PedidoItem, a.CFG_Pedido, cfgped.DS_TipoPedido, cfgped.st_valoresfixos, ");
                sql.AppendLine("a.CD_Moeda, moeda.DS_Moeda_Singular, moeda.Sigla as sigla_moeda, cfgped.st_deposito, ");
                sql.AppendLine("a.CD_Produto, prod.DS_Produto, prod.CD_Unidade as cd_unid_produto, prod.cd_condfiscal_produto, ");
                sql.AppendLine("und.DS_Unidade as ds_unid_produto, und.Sigla_Unidade as sigla_unid_produto, ");
                sql.AppendLine("a.CD_Unidade, uContrato.DS_Unidade, a.tp_frete, ");
                sql.AppendLine("uContrato.Sigla_Unidade, a.CD_Local, lArm.DS_Local, a.Quantidade, a.VL_Unitario, a.Vl_SubTotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM vtb_gro_Contrato a ");
            sql.AppendLine("INNER JOIN tb_gro_tabeladesconto b ");
            sql.AppendLine("ON a.cd_tabeladesconto = b.cd_tabeladesconto ");
            sql.AppendLine("INNER JOIN tb_gro_safra c ");
            sql.AppendLine("ON a.anosafra = c.anosafra ");
            sql.AppendLine("INNER JOIN vtb_fin_clifor d ");
            sql.AppendLine("ON a.cd_clifor = d.cd_clifor ");
            sql.AppendLine("INNER JOIN vtb_fin_endereco e ");
            sql.AppendLine("ON a.cd_endereco = e.cd_endereco ");
            sql.AppendLine("AND a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("INNER JOIN tb_div_empresa f ");
            sql.AppendLine("ON a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("INNER JOIN vtb_fin_endereco endEmpresa ");
            sql.AppendLine("ON endEmpresa.cd_endereco = f.cd_endereco ");
            sql.AppendLine("AND endEmpresa.cd_clifor = f.cd_clifor  ");
            sql.AppendLine("INNER JOIN vtb_fin_clifor Clifemp ");
            sql.AppendLine("ON Clifemp.cd_clifor = f.cd_clifor  ");
            sql.AppendLine("inner join TB_FAT_CFGPedido cfgped ");
            sql.AppendLine("on a.CFG_Pedido = cfgped.CFG_Pedido ");
            sql.AppendLine("inner join TB_FIN_Moeda moeda ");
            sql.AppendLine("on a.CD_Moeda = moeda.CD_Moeda ");
            sql.AppendLine("inner join TB_EST_Produto prod ");
            sql.AppendLine("on a.CD_Produto = prod.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade und ");
            sql.AppendLine("on prod.CD_Unidade = und.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_Unidade uContrato ");
            sql.AppendLine("on a.CD_Unidade = uContrato.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_LocalArm lArm ");
            sql.AppendLine("on a.CD_Local = lArm.CD_Local ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_Produto g ");
            sql.AppendLine("ON a.cd_produtoembalagem = g.cd_produto ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_Unidade UNDEmb ");
            sql.AppendLine("ON g.cd_unidade = UNDEmb.cd_unidade ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_LocalArm h ");
            sql.AppendLine("ON a.cd_localembalagem = h.cd_local ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_CondPgto i ");
            sql.AppendLine("on a.cd_condpgto_fix = i.cd_condpgto ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Portador j ");
            sql.AppendLine("on a.cd_portador_fix = j.cd_portador ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico k ");
            sql.AppendLine("on a.cd_historico_fix = k.cd_historico ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_TpDuplicata l ");
            sql.AppendLine("on a.tp_duplicata_fix = l.tp_duplicata ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_ContaGer m ");
            sql.AppendLine("on a.cd_contager_fix = m.cd_contager ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_TpDocto_Dup n ");
            sql.AppendLine("on a.tp_docto_fix = n.tp_docto ");
            sql.AppendLine("LEFT OUTER JOIN TB_GRO_Amostra o ");
            sql.AppendLine("on a.cd_tipoamostra1 = o.cd_tipoamostra ");
            sql.AppendLine("LEFT OUTER JOIN TB_GRO_Amostra p ");
            sql.AppendLine("on a.cd_tipoamostra2 = p.cd_tipoamostra ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        } 

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadContrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadContrato lista = new TList_CadContrato();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadContrato reg = new TRegistro_CadContrato();

                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Contrato"))))
                        reg.Nr_contrato= reader.GetDecimal(reader.GetOrdinal("Nr_Contrato"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto"))))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto"))))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("padrao_qualidade"))))
                        reg.Padrao_qualidade = reader.GetString(reader.GetOrdinal("padrao_qualidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto"))))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_ContratoOrigem"))))
                        reg.Nr_contratoorigem = reader.GetString(reader.GetOrdinal("NR_ContratoOrigem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("AnoSafra"))))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_safra"))))
                        reg.Ds_safra = reader.GetString(reader.GetOrdinal("ds_safra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("cd_condfiscal_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ObsGRO"))))
                        reg.Ds_obsgro = reader.GetString(reader.GetOrdinal("DS_ObsGRO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Abertura"))))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Encerramento"))))
                        reg.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("DT_Encerramento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ProdutoEmbalagem")))
                        reg.Cd_produtoembalagem = reader.GetString(reader.GetOrdinal("CD_ProdutoEmbalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ProdutoEmbalagem")))
                        reg.Ds_produtoembalagem = reader.GetString(reader.GetOrdinal("DS_ProdutoEmbalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_undembalagem")))
                        reg.Sigla_undembalagem = reader.GetString(reader.GetOrdinal("sigla_undembalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LocalEmbalagem")))
                        reg.Cd_localembalagem = reader.GetString(reader.GetOrdinal("CD_LocalEmbalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LocalEmbalagem")))
                        reg.Ds_localembalagem = reader.GetString(reader.GetOrdinal("DS_LocalEmbalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExigirAutorizRetirada")))
                        reg.St_exigirautorizretirada = reader.GetString(reader.GetOrdinal("ST_ExigirAutorizRetirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_valoresfixos")))
                        reg.St_valoresfixos = reader.GetString(reader.GetOrdinal("st_valoresfixos")).Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_deposito")))
                        reg.St_deposito = reader.GetString(reader.GetOrdinal("st_deposito")).Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_moeda")))
                        reg.Sigla_moeda = reader.GetString(reader.GetOrdinal("sigla_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.CD_CondPGTO = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("cd_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unid_produto")))
                        reg.Ds_unid_produto = reader.GetString(reader.GetOrdinal("ds_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unid_produto")))
                        reg.Sigla_unid_produto = reader.GetString(reader.GetOrdinal("sigla_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_prodcontrato")))
                        reg.Tp_prodcontrato = reader.GetString(reader.GetOrdinal("tp_prodcontrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    
                    //BUSCA DADOS CLIFOR
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_endereco"))))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade"))))
                        reg.DS_Cidade_Clifor = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("uf"))))
                        reg.UF_Clifor = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.CD_UFClifor = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("insc_estadual"))))
                        reg.IE_Clifor = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CGCCPF"))))
                        reg.CPF_CNPJ_Clifor = reader.GetString(reader.GetOrdinal("NR_CGCCPF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro"))))
                        reg.Bairro_Clifor = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cep"))))
                        reg.CEP_Clifor = reader.GetString(reader.GetOrdinal("cep"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero"))))
                        reg.NumEnderecoClifor = reader.GetString(reader.GetOrdinal("numero"));

                    //BUSCA DADOS DA EMPRESA
                    if (!(reader.IsDBNull(reader.GetOrdinal("endempresa"))))
                        reg.DS_Endereco_Empresa = reader.GetString(reader.GetOrdinal("endempresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CidEmpresa"))))
                        reg.DS_Cidade_Empresa = reader.GetString(reader.GetOrdinal("CidEmpresa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_ufempresa")))
                        reg.CD_UFEmpresa = reader.GetString(reader.GetOrdinal("cd_ufempresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("UFEmpresa"))))
                        reg.UF_Empresa = reader.GetString(reader.GetOrdinal("UFEmpresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("IEEmpresa"))))
                        reg.IE_Empresa = reader.GetString(reader.GetOrdinal("IEEmpresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NRCRC_Empresa"))))
                        reg.CNPJ_Empresa = reader.GetString(reader.GetOrdinal("NRCRC_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cepEmpresa"))))
                        reg.CEP_Empresa = reader.GetString(reader.GetOrdinal("cepEmpresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("BairroEmp"))))
                        reg.Bairro_Empresa = reader.GetString(reader.GetOrdinal("BairroEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NumEmpresa"))))
                        reg.NumEnderecoEmpresa = reader.GetString(reader.GetOrdinal("NumEmpresa"));

                    //DADOS FIXACAO
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto_fix")))
                        reg.Cd_condpgto_fix = reader.GetString(reader.GetOrdinal("cd_condpgto_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto_fix")))
                        reg.Ds_condpgto_fix = reader.GetString(reader.GetOrdinal("ds_condpgto_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador_fix")))
                        reg.Cd_portador_fix = reader.GetString(reader.GetOrdinal("cd_portador_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador_fix")))
                        reg.Ds_portador_fix = reader.GetString(reader.GetOrdinal("ds_portador_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_fix")))
                        reg.Cd_historico_fix = reader.GetString(reader.GetOrdinal("cd_historico_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_fix")))
                        reg.Ds_historico_fix = reader.GetString(reader.GetOrdinal("ds_historico_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movhistorico_fix")))
                        reg.Tp_mov_historico_fix = reader.GetString(reader.GetOrdinal("tp_movhistorico_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata_fix")))
                        reg.Tp_duplicata_fix = reader.GetString(reader.GetOrdinal("tp_duplicata_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata_fix")))
                        reg.Ds_tpduplicata_fix = reader.GetString(reader.GetOrdinal("ds_tpduplicata_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movduplicata_fix")))
                        reg.Tp_mov_duplicata_fix = reader.GetString(reader.GetOrdinal("tp_movduplicata_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager_fix")))
                        reg.Cd_contager_fix = reader.GetString(reader.GetOrdinal("cd_contager_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager_fix")))
                        reg.Ds_contager_fix = reader.GetString(reader.GetOrdinal("ds_contager_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto_fix")))
                        reg.Tp_docto_fix = reader.GetDecimal(reader.GetOrdinal("tp_docto_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto_fix")))
                        reg.Ds_tpdocto_fix = reader.GetString(reader.GetOrdinal("ds_tpdocto_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_bonificacao_fix")))
                        reg.Vl_bonificacao_fix = reader.GetDecimal(reader.GetOrdinal("vl_bonificacao_fix"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra1")))
                        reg.Cd_tipoamostra1 = reader.GetString(reader.GetOrdinal("cd_tipoamostra1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoamostra1")))
                        reg.Ds_tipoamostra1 = reader.GetString(reader.GetOrdinal("ds_tipoamostra1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra2")))
                        reg.Cd_tipoamostra2 = reader.GetString(reader.GetOrdinal("cd_tipoamostra2"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoamostra2")))
                        reg.Ds_tipoamostra2 = reader.GetString(reader.GetOrdinal("ds_tipoamostra2"));
                    
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadContrato val)
        {
            Hashtable hs = new Hashtable(36);

            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_NR_CONTRATOORIGEM", val.Nr_contratoorigem);            
            hs.Add("@P_ANOSAFRA", val.Anosafra);
            hs.Add("@P_CD_PRODUTOEMBALAGEM", val.Cd_produtoembalagem);
            hs.Add("@P_CD_LOCALEMBALAGEM", val.Cd_localembalagem);
            hs.Add("@P_CD_CONDPGTO_FIX", val.Cd_condpgto_fix);
            hs.Add("@P_CD_PORTADOR_FIX", val.Cd_portador_fix);
            hs.Add("@P_CD_HISTORICO_FIX", val.Cd_historico_fix);
            hs.Add("@P_TP_DUPLICATA_FIX", val.Tp_duplicata_fix);
            hs.Add("@P_CD_CONTAGER_FIX", val.Cd_contager_fix);
            hs.Add("@P_TP_DOCTO_FIX", val.Tp_docto_fix);
            hs.Add("@P_VL_BONIFICACAO_FIX", val.Vl_bonificacao_fix);
            hs.Add("@P_CD_TIPOAMOSTRA1", val.Cd_tipoamostra1);
            hs.Add("@P_CD_TIPOAMOSTRA2", val.Cd_tipoamostra2);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_DS_OBSGRO", val.Ds_obsgro);
            hs.Add("@P_ST_EXIGIRAUTORIZRETIRADA", val.St_exigirautorizretirada);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_ENCERRAMENTO", val.Dt_encerramento);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_TP_PRODCONTRATO", val.Tp_prodcontrato);

            return this.executarProc("IA_GRO_CONTRATO", hs);
        }

        public string Excluir(TRegistro_CadContrato val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);

            return this.executarProc("EXCLUI_GRO_CONTRATO", hs);
        }
    }
    #endregion

    #region Movimentacao Contrato
    public class TList_MovContrato : List<TRegistro_MovContrato>
    { }

    public class TRegistro_MovContrato
    {
        public decimal Id_movto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal Id_pedidoitem
        { get; set; }
        public decimal Id_lanctoestoque
        { get; set; }
        public string Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public DateTime Dt_estoque
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public decimal Qtd_entrada
        { get; set; }
        public decimal Qtd_saida
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }

        public TRegistro_MovContrato()
        {
            this.Id_movto = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Id_pedidoitem = decimal.Zero;
            this.Id_lanctoestoque = decimal.Zero;
            this.Nr_pedido = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Dt_estoque = DateTime.Now;
            this.Tp_movimento = string.Empty;
            this.Qtd_entrada = 0;
            this.Qtd_saida = 0;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Vl_unitario = 0;
            this.Vl_subtotal = 0;
        }
    }

    public class TCD_MovContrato : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_pedido, a.cd_produto, d.ds_produto, a.cd_empresa, ");
                sql.AppendLine("b.cd_local, e.ds_local, b.dt_lancto, a.id_movto, a.id_pedidoitem, a.id_lanctoestoque, ");
                sql.AppendLine("case when b.tp_movimento = 'E' then 'ENTRADA' else 'SAIDA' end as tp_movimento, ");
                sql.AppendLine("b.qtd_entrada, b.qtd_saida, d.cd_unidade, f.ds_unidade, ");
                sql.AppendLine("f.sigla_unidade, b.vl_unitario, b.vl_subtotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_movdeposito a ");
            sql.AppendLine("inner join tb_est_estoque b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
            sql.AppendLine("inner join vtb_gro_contrato c ");
            sql.AppendLine("on a.nr_pedido = c.nr_pedido ");
            sql.AppendLine("and a.cd_produto = c.cd_produto ");
            sql.AppendLine("and a.id_pedidoitem = c.id_pedidoitem ");
            sql.AppendLine("inner join tb_est_produto d ");
            sql.AppendLine("on a.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join tb_est_localarm e ");
            sql.AppendLine("on b.cd_local = e.cd_local ");
            sql.AppendLine("inner join tb_est_unidade f ");
            sql.AppendLine("on d.cd_unidade = f.cd_unidade ");

            sql.AppendLine("where isnull(b.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("order by b.dt_lancto, b.tp_movimento ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_MovContrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MovContrato lista = new TList_MovContrato();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovContrato reg = new TRegistro_MovContrato();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movto")))
                        reg.Id_movto = reader.GetDecimal(reader.GetOrdinal("Id_movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Local"))))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lancto"))))
                        reg.Dt_estoque = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Entrada"))))
                        reg.Qtd_entrada = reader.GetDecimal(reader.GetOrdinal("QTD_Entrada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Saida"))))
                        reg.Qtd_saida = reader.GetDecimal(reader.GetOrdinal("QTD_Saida"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Unidade"))))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Unidade"))))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_unidade"))))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }
    }
    #endregion

    #region Sintetico Taxas
    public class TList_SinteticoTaxas : List<TRegistro_SinteticoTaxas>
    { }

    public class TRegistro_SinteticoTaxas
    {
        public decimal Id_taxa
        { get; set; }
        public string Ds_taxa
        { get; set; }
        public decimal Total_pstaxa
        { get; set; }
        public decimal Total_vltaxa
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public TRegistro_CadContratoTaxaDeposito rTaxas
        { get; set; }

        public TRegistro_SinteticoTaxas()
        {
            this.Id_taxa = 0;
            this.Ds_taxa = string.Empty;
            this.Total_pstaxa = 0;
            this.Total_vltaxa = 0;
            this.Sigla_unidade = string.Empty;
            this.rTaxas = null;
        }
    }

    public class TCD_SinteticoTaxas : TDataQuery
    {
        public TList_SinteticoTaxas Select(string Nr_contrato)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_taxa, b.ds_taxa, d.sigla_unidade, sum(isnull(a.ps_taxa, 0)) as total_pstaxa, ");
            sql.AppendLine("sum(isnull(a.vl_taxa, 0)) as total_taxa ");

            sql.AppendLine("from VTB_GRO_LANCTO_TAXADEPOSITO a ");
            sql.AppendLine("inner join TB_GRO_Contrato con ");
            sql.AppendLine("on a.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("inner join tb_gro_taxadeposito b ");
            sql.AppendLine("on a.id_taxa = b.id_taxa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on con.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");

            sql.AppendLine("where a.nr_contrato = " + Nr_contrato);
            sql.AppendLine("group by a.id_taxa, b.ds_taxa, d.sigla_unidade ");
            sql.AppendLine("order by a.id_taxa ");

            TList_SinteticoTaxas lista = new TList_SinteticoTaxas();
            bool st_transacao = false;
            if (this.Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBuscaReader(sql.ToString(), null);
            try
            {
                while (reader.Read())
                {
                    TRegistro_SinteticoTaxas reg = new TRegistro_SinteticoTaxas();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_taxa")))
                        reg.Id_taxa = reader.GetDecimal(reader.GetOrdinal("id_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_taxa")))
                        reg.Ds_taxa = reader.GetString(reader.GetOrdinal("ds_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("total_pstaxa")))
                        reg.Total_pstaxa = reader.GetDecimal(reader.GetOrdinal("total_pstaxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("total_taxa")))
                        reg.Total_vltaxa = reader.GetDecimal(reader.GetOrdinal("total_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
            return lista;
        }
    }
    #endregion

    #region Saldo Contrato
    public class TList_SaldoContrato : List<TRegistro_SaldoContrato>
    { }

    public class TRegistro_SaldoContrato
    {
        public string CD_Empresa
        { get; set; }
        public string NM_Empresa
        { get; set; }
        public string CD_Local
        { get; set; }
        public string DS_Local
        { get; set; }
        public string CD_Produto
        { get; set; }
        public string DS_Produto
        { get; set; }
        public string Sigla_Unidade
        { get; set; }
        public decimal qtd_entrada
        { get; set; }
        public decimal qtd_saida
        { get; set; }
        public decimal Tot_saldo
        { get { return qtd_entrada - qtd_saida; } }

        public TRegistro_SaldoContrato()
        {
            this.CD_Empresa = string.Empty;
            this.NM_Empresa = string.Empty;
            this.CD_Local = string.Empty;
            this.DS_Local = string.Empty;
            this.CD_Produto = string.Empty;
            this.DS_Produto = string.Empty;
            this.Sigla_Unidade = string.Empty;
            this.qtd_entrada = decimal.Zero;
            this.qtd_saida = decimal.Zero;
        }
    }

    public class TCD_SaldoContrato : TDataQuery
    {
        public TCD_SaldoContrato()
        { }

        public TCD_SaldoContrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string BuscaSaldoProduto(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select f.CD_Empresa, h.NM_Empresa, f.CD_Local, g.DS_Local, a.CD_Produto, i.DS_Produto, j.Sigla_Unidade, ");
            sql.AppendLine("qtd_entrada = ISNULL(SUM(ISNULL(f.QTD_Entrada, 0)), 0), qtd_saida = ISNULL(SUM(ISNULL(f.QTD_Saida, 0)), 0) ");

            sql.AppendLine("from TB_GRO_Contrato a ");
            sql.AppendLine("inner join TB_FAT_Pedido b ");
            sql.AppendLine("on a.Nr_Pedido = b.Nr_Pedido ");
            sql.AppendLine("inner join TB_FAT_CFGPedido c ");
            sql.AppendLine("on b.CFG_Pedido = c.CFG_Pedido ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item d ");
            sql.AppendLine("on a.Nr_Pedido = d.Nr_Pedido ");
            sql.AppendLine("and a.CD_Produto = d.CD_Produto ");
            sql.AppendLine("and a.ID_PedidoItem = d.ID_PedidoItem ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item_X_Estoque e ");
            sql.AppendLine("on d.CD_Empresa = e.CD_Empresa ");
            sql.AppendLine("and d.Nr_LanctoFiscal = e.Nr_LanctoFiscal ");
            sql.AppendLine("and d.ID_NFItem = e.ID_NFItem ");
            sql.AppendLine("inner join TB_EST_Estoque f ");
            sql.AppendLine("on e.CD_Empresa = f.CD_Empresa ");
            sql.AppendLine("and e.CD_Produto = f.CD_Produto ");
            sql.AppendLine("and e.Id_LanctoEstoque = f.Id_LanctoEstoque ");
            sql.AppendLine("inner join TB_EST_LocalArm g ");
            sql.AppendLine("on f.CD_Local = g.CD_Local ");
            sql.AppendLine("inner join TB_DIV_Empresa h ");
            sql.AppendLine("on f.CD_Empresa = h.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto i ");
            sql.AppendLine("on a.CD_Produto = i.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade j ");
            sql.AppendLine("on i.CD_Unidade = j.CD_Unidade ");

            sql.AppendLine("where isnull(f.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("group by f.CD_Empresa, h.NM_Empresa, f.CD_Local, g.DS_Local, a.CD_Produto, i.DS_Produto, j.Sigla_Unidade ");
            sql.AppendLine("order by f.CD_Empresa, a.CD_Produto ");

            return sql.ToString();
        }

        public TList_SaldoContrato Select(TpBusca[] vBusca)
        {
            TList_SaldoContrato lista = new TList_SaldoContrato();
            bool st_transacao = false;
            if (this.Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBuscaReader(this.BuscaSaldoProduto(vBusca), null);
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoContrato reg = new TRegistro_SaldoContrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.CD_Local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.DS_Local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entrada")))
                        reg.qtd_entrada = reader.GetDecimal(reader.GetOrdinal("qtd_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_saida")))
                        reg.qtd_saida = reader.GetDecimal(reader.GetOrdinal("qtd_saida"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
            return lista;
        }
    }
    #endregion
}


