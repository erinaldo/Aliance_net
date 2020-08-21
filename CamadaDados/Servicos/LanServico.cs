using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaDados.Servicos
{
    public class TList_LanServico : List<TRegistro_LanServico>, IComparer<TRegistro_LanServico>
    {
        #region IComparer<TRegistro_LanServico> Members
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

        public TList_LanServico()
        { }

        public TList_LanServico(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanServico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanServico x, TRegistro_LanServico y)
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
    
    public class TRegistro_LanServico
    {
        private decimal? id_os;
        public decimal? Id_os 
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_condPagto
        { get; set; }
        public string Ds_condPagto
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
        public bool St_acrescbasedesc
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_cnpj_cpf
        { get; set; }
        public string Nm_Fantasia
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Numero
        { get; set; }
        public string Proximo
        { get; set; }
        public string Bairro
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Sigla_uf
        { get; set; }
        public string Fone
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        private decimal? id_tptransp_recebido;
        public decimal? Id_tptransp_recebido
        {
            get { return id_tptransp_recebido; }
            set
            {
                id_tptransp_recebido = value;
                id_tptransp_recebidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tptransp_recebidostr;
        public string Id_tptransp_recebidostr
        {
            get { return id_tptransp_recebidostr; }
            set
            {
                id_tptransp_recebidostr = value;
                try
                {
                    id_tptransp_recebido = decimal.Parse(value);
                }
                catch
                { id_tptransp_recebido = null; }
            }
        }
        public string Ds_tptransp_recebido
        { get; set; }
        private decimal? id_tptransp_enviado;
        public decimal? Id_tptransp_enviado
        {
            get { return id_tptransp_enviado; }
            set
            {
                id_tptransp_enviado = value;
                id_tptransp_enviadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tptransp_enviadostr;
        public string Id_tptransp_enviadostr
        {
            get { return id_tptransp_enviadostr; }
            set
            {
                id_tptransp_enviadostr = value;
                try
                {
                    id_tptransp_enviado = decimal.Parse(value);
                }
                catch
                { id_tptransp_enviado = null; }
            }
        }
        public string Ds_tptransp_enviado
        { get; set; }
        public string Logindevolucao
        { get; set; }
        public string Placaveiculo
        { get; set; }
        public decimal Km_veiculo
        { get; set; }
        public string Ds_veiculo
        { get; set; }
        public decimal Anofabric
        { get; set; }
        public string Ds_marca
        { get; set; }
        public string Ds_obsVeiculo
        { get; set; }
        public decimal Dias_Retirar
        { get; set; }
        public string Nr_osorigem
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
                    return DateTime.Parse(dt_aberturastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_aberturastr = value;
                try
                {
                    dt_abertura = DateTime.Parse(value);
                }
                catch
                { dt_abertura = null; }
            }
        }
        private DateTime? dt_previsao;
        public DateTime? Dt_previsao 
        {
            get { return dt_previsao; }
            set
            {
                dt_previsao = value;
                dt_previsaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_previsaostr;
        public string Dt_previsaostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_previsaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_previsaostr = value;
                try
                {
                    dt_previsao = DateTime.Parse(value);
                }
                catch
                { dt_previsao = null; }
            }
        }
        private DateTime? dt_finalizada;
        public DateTime? Dt_finalizada
        {
            get { return dt_finalizada; }
            set
            {
                dt_finalizada = value;
                dt_finalizadastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_finalizadastr;
        public string Dt_finalizadastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finalizadastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finalizadastr = value;
                try
                {
                    dt_finalizada = DateTime.Parse(value);
                }
                catch
                { dt_finalizada = null; }
            }
        }
        private DateTime? dt_encerramento;
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_encerramentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = DateTime.Parse(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }
        private string st_prioridade;
        public string St_prioridade 
        {
            get { return st_prioridade; }
            set
            {
                st_prioridade = value;
                if (value.Trim().ToUpper().Equals("0"))
                    status_prioridade = "BAIXA";
                else if (value.Trim().ToUpper().Equals("1"))
                    status_prioridade = "MEDIA";
                else if (value.Trim().ToUpper().Equals("2"))
                    status_prioridade = "ALTA";
            }
        }
        private string status_prioridade;
        public string Status_prioridade
        {
            get { return status_prioridade; }
            set 
            { 
                status_prioridade = value;
                if (value.Trim().ToUpper().Equals("BAIXA"))
                    st_prioridade = "0";
                else if (value.Trim().ToUpper().Equals("MEDIA"))
                    st_prioridade = "1";
                else if (value.Trim().ToUpper().Equals("ALTA"))
                    st_prioridade = "2";
            }
        }
        private string st_os;
        public string St_os 
        {
            get { return st_os; }
            set
            {
                st_os = value;
                if (value.Trim().ToUpper().Equals("AB"))
                    if (dt_previsao.HasValue ? dt_previsao.Value < DateTime.Now : false)
                        status_os = "EXPIRADA";
                    else
                        status_os = "ABERTA";
                else if (value.Trim().ToUpper().Equals("FE"))
                {
                    if ((Dias_Retirar > 0)  && (dt_finalizada.HasValue ? dt_finalizada.Value.AddDays(Convert.ToDouble(Dias_Retirar)).Date < DateTime.Now : false))
                        status_os = "RETIRAR";
                    else
                        status_os = "FINALIZADA";
                }
                else if (value.Trim().ToUpper().Equals("CA"))
                    status_os = "CANCELADA";
                else if (value.Trim().ToUpper().Equals("PR"))
                    status_os = "PROCESSADA";
                else if (value.Trim().ToUpper().Equals("DV"))
                    status_os = "RETIRADA";
            }
        }
        private string status_os;
        public string Status_os
        {
            get { return status_os; }
            set 
            { 
                status_os = value;
                if (value.Trim().ToUpper().Equals("ABERTA") ||
                    value.Trim().ToUpper().Equals("EXPIRADA"))
                    st_os = "AB";
                else if (value.Trim().ToUpper().Equals("FINALIZADA") ||
                    value.Trim().ToUpper().Equals("RETIRAR"))
                    st_os = "FE";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_os = "CA";
                else if (value.Trim().ToUpper().Equals("PROCESSADA"))
                    st_os = "PR";
                else if (value.Trim().ToUpper().Equals("DEVOLVIDA"))
                    st_os = "DV";
            }
        }
        public string Ds_observacoesgerais
        { get; set; }
        public string DS_Equipamento
        {
            get;
            set;
        }
        public string DS_Modelo
        {
            get;
            set;
        }
        public string DS_ConclusaoOS
        {
            get;
            set;
        }
        public string Nr_serial
        { get; set; }
        public string CD_ProdutoOS
        {
            get;
            set;
        }
        public string DS_ProdutoOS
        {
            get;
            set;
        }
        public string Nr_patrimonio
        { get; set; }
        public string Cd_unidOS
        { get; set; }
        public string Nm_oficina
        { get; set; }
        private string _ST_EquipamentoGarantia;
        public string ST_EquipamentoGarantia
        {
            get { return _ST_EquipamentoGarantia; }
            set { _ST_EquipamentoGarantia = value;
                if (value == "S")
                {
                    _ST_EquipamentoGarantia_Bool = true;
                }
                else
                {
                    if (value == "N")
                    {
                        _ST_EquipamentoGarantia_Bool = false;
                    }
                }
            }
        }
        private bool _ST_EquipamentoGarantia_Bool;
        public bool ST_EquipamentoGarantia_Bool
        {
            get { return _ST_EquipamentoGarantia_Bool; }
            set { _ST_EquipamentoGarantia_Bool = value; 
                if(value == true)
                {
                    _ST_EquipamentoGarantia = "S";

                }
                else
                {
                    _ST_EquipamentoGarantia = "N"; 
                }
            }
        }
        private string st_equipamentocomnf;
        public string St_equipamentocomnf
        {
            get { return st_equipamentocomnf; }
            set
            {
                st_equipamentocomnf = value;
                st_equipamentocomnfbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_equipamentocomnfbool;
        public bool St_equipamentocomnfbool
        {
            get { return st_equipamentocomnfbool; }
            set
            {
                st_equipamentocomnfbool = value;
                if (value)
                    st_equipamentocomnf = "S";
                else
                    st_equipamentocomnf = "N";
            }
        }
        public string Ds_defeitocliente
        { get; set; }
        private DateTime? dt_devolucao;
        public DateTime? Dt_devolucao
        {
            get { return dt_devolucao; }
            set
            {
                dt_devolucao = value;
                dt_devolucaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_devolucaostr;
        public string Dt_devolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_devolucaostr).ToString("dd/MM/yyyy");
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
        public decimal Horimetro { get; set; }
        public TList_LanServicosPecas lPecas
        { get; set; }
        public TList_LanServicosPecas Deleta_lPecas
        { get; set; }
        public TList_LanServicosPecas lServico
        { get; set; }
        public TList_LanServicosPecas Deleta_lServico
        { get; set; }
        public TList_LanServicoEvolucao lEvolucao
        { get; set; }
        public TList_LanServicoEvolucao lEvolucaoDel
        { get; set; }
        public TList_OSE_SerialClifor lSerialClifor
        { get; set; }
        public TList_OSE_ParamOS lParamOS
        {
            get;
            set;
        }
        public TList_Acessorios lAcessorios
        { get; set; }
        public TList_Acessorios lAcessoriosDel
        { get; set; }
        public TList_Imagens lImagens
        { get; set; }
        public TList_Imagens lImagensDel
        { get; set; }
        public TList_Historico lHistorico
        { get; set; }
        public TRegistro_Lote_X_Servicos rLoteServico
        { get; set; }
        public TList_Pedido lPedido
        { get; set; }
        public decimal Pc_desconto
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Pc_acrescimo
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_subtotalLiq
        { get { return Vl_subtotal - Vl_desconto + Vl_acrescimo; } }
        public decimal Vl_garantia
        { get; set; }
        public decimal Vl_pecas
        { get; set; }
        public decimal Vl_servico
        { get; set; }
        public bool St_Lote
        { get; set; }
        public bool St_processarOS
        { get; set; }
        public string Ds_etapaatual
        {get;set;}
        public string Nm_fornecedor
        { get; set; }
        public decimal? Nr_pedidointegra
        { get; set; }
        public decimal? Id_prevenda
        { get; set; }
        public string Ds_servico
        { get; set; }
        public decimal? Nr_nfce
        { get; set; }
        public TList_RegLanDuplicata lDup
        { get; set; }
        public TList_RegLanDuplicata lDupDel
        { get; set; }

        public TRegistro_LanServico()
        {
            id_os = null;
            id_osstr = string.Empty;
            Nr_serial = string.Empty;
            dt_abertura = CamadaDados.UtilData.Data_Servidor();
            dt_aberturastr = CamadaDados.UtilData.Data_Servidor().ToString();
            dt_previsao = null;
            dt_previsaostr = string.Empty;
            dt_finalizada = null;
            dt_finalizadastr = string.Empty;
            st_prioridade = "1";
            status_prioridade = "MEDIA";
            st_os = "AB";
            status_os = "ABERTA";
            Ds_observacoesgerais = string.Empty;
            lEvolucao = new TList_LanServicoEvolucao();
            lEvolucaoDel = new TList_LanServicoEvolucao();
            lPecas = new TList_LanServicosPecas();
            lServico = new TList_LanServicosPecas();
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cnpj_cpf = string.Empty;
            Nm_Fantasia = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Numero = string.Empty;
            Proximo = string.Empty;
            Bairro = string.Empty;
            Ds_cidade = string.Empty;
            Sigla_uf = string.Empty;
            Fone = string.Empty;
            Nr_osorigem = string.Empty;
            Ds_defeitocliente = string.Empty;
            lSerialClifor = new TList_OSE_SerialClifor();
            lParamOS = new TList_OSE_ParamOS();
            lHistorico = new TList_Historico();
            lImagens = new TList_Imagens();
            lImagensDel = new TList_Imagens();

            Deleta_lServico = new TList_LanServicosPecas();
            Deleta_lPecas = new TList_LanServicosPecas();
            rLoteServico = null;
            lPedido = new TList_Pedido();

            id_tptransp_enviado = null;
            id_tptransp_enviadostr = string.Empty;
            Ds_tptransp_enviado = string.Empty;
            id_tptransp_recebido = null;
            id_tptransp_recebidostr = string.Empty;
            Ds_tptransp_recebido = string.Empty;
            tp_ordem = null;
            tp_ordemstr = string.Empty;
            Ds_tipoordem = string.Empty;
            St_acrescbasedesc = false;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            dt_encerramento = null;
            dt_encerramentostr = string.Empty;
            DS_Equipamento = string.Empty;
            DS_Modelo = string.Empty;
            DS_ConclusaoOS = string.Empty;
            CD_ProdutoOS = string.Empty;
            DS_ProdutoOS = string.Empty;
            Nr_patrimonio = string.Empty;
            Cd_unidOS = string.Empty;
            Nm_oficina = string.Empty;
            _ST_EquipamentoGarantia = "N";
            _ST_EquipamentoGarantia_Bool = false;
            st_equipamentocomnf = "N";
            st_equipamentocomnfbool = false;
            St_Lote = false;
            St_processarOS = false;

            Ds_etapaatual = string.Empty;
            Nm_fornecedor = string.Empty;
            Pc_desconto = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Pc_acrescimo = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Vl_garantia = decimal.Zero;
            Vl_pecas = decimal.Zero;
            Vl_servico = decimal.Zero;
            Logindevolucao = string.Empty;
            dt_devolucao = null;
            dt_devolucaostr = string.Empty;
            Nr_pedidointegra = null;
            Placaveiculo = string.Empty;
            Km_veiculo = decimal.Zero;
            Ds_veiculo = string.Empty;
            Anofabric = decimal.Zero;
            Ds_marca = string.Empty;
            Ds_obsVeiculo = string.Empty;
            Dias_Retirar = decimal.Zero;
            Id_prevenda = null;
            Ds_servico = string.Empty;
            Nr_nfce = null;
            Cd_condPagto = string.Empty;
            Ds_condPagto = string.Empty;

            lAcessorios = new TList_Acessorios();
            lAcessoriosDel = new TList_Acessorios();
            lDup = new TList_RegLanDuplicata();
            lDupDel = new TList_RegLanDuplicata();
        }
    }

    public class TCD_LanServico : TDataQuery
    {
        public TCD_LanServico()
        { }

        public TCD_LanServico(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "a.id_os, a.nr_serial, a.tp_ordem, e.ds_TipoOrdem, m.st_acrescbasedesc, a.dt_abertura, ");
                sql.AppendLine("a.dt_previsao, a.dt_finalizada, a.st_prioridade, a.st_os, ds_observacoesgerais, a.dt_devolucao, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa, a.nr_osorigem, a.ds_defeitocliente, a.placaveiculo, ");
                sql.AppendLine("a.cd_clifor, a.nm_clifor, a.nr_cnpj_cpf, l.NM_Fantasia, j.cd_unidade as cd_unidos, a.Ds_servico, ");
                sql.AppendLine("a.logindevolucao, a.km_veiculo, a.dias_retirar, a.numero, a.proximo, a.Nr_nfce, ");
                sql.AppendLine("a.cd_endereco, a.ds_endereco, a.ds_cidade, a.uf, a.st_equipamentocomnf, ");
	            sql.AppendLine("a.id_tptransp_recebido, f.ds_tptransp as ds_tptransp_Recebido, a.bairro, a.fone, ");
                sql.AppendLine("a.id_tptransp_Enviado, g.ds_tptransp as ds_tptransp_enviado, a.nr_pedidointegra, ");
                sql.AppendLine("a.dt_encerramento, a.ds_equipamento, a.ds_modelo, a.st_EquipamentoGarantia, ");
	            sql.AppendLine("a.DS_ConclusaoOS, a.CD_tabelaPreco, h.ds_tabelaPreco, a.cd_produtoOS, j.ds_produto, pat.Nr_patrimonio, ");
                sql.AppendLine("a.ds_veiculo, k.anofabric, k.ds_marca, k.ds_observacao as ds_obsveiculo, ");
                sql.AppendLine("a.id_prevenda, a.ds_etapaatual, a.nm_fornecedor, a.vl_subtotal, a.vl_desconto, ");
                sql.AppendLine("a.vl_acrescimo, a.vl_garantia, a.vl_pecas, a.vl_servico, a.Horimetro, ");
                sql.AppendLine("Nm_oficina = isnull((select TOP 1 y.nm_clifor from tb_ose_evolucao x ");
                sql.AppendLine("                    inner join tb_fin_clifor y ");
                sql.AppendLine("                    on x.cd_oficina = y.cd_clifor ");
                sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                    and x.id_os = a.id_os ");
                sql.AppendLine("                    and x.cd_oficina is not null), '') ");
                sql.AppendLine(", a.cd_condpgto, (select x.ds_condpgto from tb_fin_condpgto x where x.cd_condpgto = a.cd_condpgto )as ds_condpgto");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_OSE_Servico a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_ose_tpordem e ");
            sql.AppendLine("on e.tp_ordem = a.tp_ordem ");
            sql.AppendLine("left outer join tb_Div_tpTransporte f ");
            sql.AppendLine("on f.id_tptransp = a.id_tptransp_recebido ");
            sql.AppendLine("left outer join tb_Div_tpTransporte g ");
            sql.AppendLine("on g.id_tptransp = a.id_tptransp_enviado ");
            sql.AppendLine("left outer join tb_div_tabelaPreco h ");
            sql.AppendLine("on h.cd_tabelaPreco = a.cd_tabelaPreco ");
            sql.AppendLine("left outer join tb_est_produto j ");
            sql.AppendLine("on j.cd_produto = a.cd_produtoos ");
            sql.AppendLine("left outer join TB_EST_Patrimonio pat ");
            sql.AppendLine("on pat.cd_patrimonio = j.cd_produto ");
            sql.AppendLine("left outer join tb_ose_veiculocliente k ");
            sql.AppendLine("on a.placaveiculo = k.placaveiculo ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR l ");
            sql.AppendLine("on a.CD_Clifor = l.CD_Clifor ");
            sql.AppendLine("left outer join tb_ose_paramos m ");
            sql.AppendLine("on a.tp_ordem = m.tp_ordem ");

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

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_LanServico Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_LanServico lista = new TList_LanServico();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanServico reg = new TRegistro_LanServico();
                    //Dados da OS
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serial"))))
                        reg.Nr_serial = reader.GetString(reader.GetOrdinal("NR_Serial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_osorigem")))
                        reg.Nr_osorigem = reader.GetString(reader.GetOrdinal("nr_osorigem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Abertura"))))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Previsao"))))
                        reg.Dt_previsao = reader.GetDateTime(reader.GetOrdinal("DT_Previsao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Dt_finalizada"))))
                        reg.Dt_finalizada = reader.GetDateTime(reader.GetOrdinal("Dt_finalizada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Prioridade"))))
                        reg.St_prioridade = reader.GetString(reader.GetOrdinal("ST_Prioridade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_observacoesgerais"))))
                        reg.Ds_observacoesgerais = reader.GetString(reader.GetOrdinal("ds_observacoesgerais"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cnpj_cpf")))
                        reg.Nr_cnpj_cpf = reader.GetString(reader.GetOrdinal("nr_cnpj_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fantasia")))
                        reg.Nm_Fantasia = reader.GetString(reader.GetOrdinal("NM_Fantasia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Proximo")))
                        reg.Proximo = reader.GetString(reader.GetOrdinal("Proximo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Sigla_uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPTransp_Recebido")))
                        reg.Id_tptransp_recebido = reader.GetDecimal(reader.GetOrdinal("ID_TPTransp_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tptransp_Recebido")))
                        reg.Ds_tptransp_recebido = reader.GetString(reader.GetOrdinal("ds_tptransp_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPTransp_Enviado")))
                        reg.Id_tptransp_enviado = reader.GetDecimal(reader.GetOrdinal("ID_TPTransp_Enviado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tptransp_enviado")))
                        reg.Ds_tptransp_enviado = reader.GetString(reader.GetOrdinal("ds_tptransp_enviado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("TP_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_TipoOrdem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_TipoOrdem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_acrescbasedesc")))
                        reg.St_acrescbasedesc = reader.GetString(reader.GetOrdinal("st_acrescbasedesc")).ToString().Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_tabelaPreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("CD_tabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelaPreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_encerramento")))
                        reg.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("dt_encerramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Equipamento")))
                        reg.DS_Equipamento = reader.GetString(reader.GetOrdinal("DS_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Modelo")))
                        reg.DS_Modelo = reader.GetString(reader.GetOrdinal("DS_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EquipamentoComNF")))
                        reg.St_equipamentocomnf = reader.GetString(reader.GetOrdinal("ST_EquipamentoComNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ConclusaoOS")))
                        reg.DS_ConclusaoOS = reader.GetString(reader.GetOrdinal("DS_ConclusaoOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ProdutoOS")))
                        reg.CD_ProdutoOS = reader.GetString(reader.GetOrdinal("CD_ProdutoOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_ProdutoOS = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidOS")))
                        reg.Cd_unidOS = reader.GetString(reader.GetOrdinal("CD_UnidOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_oficina")))
                        reg.Nm_oficina = reader.GetString(reader.GetOrdinal("nm_oficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EquipamentoGarantia")))
                        reg.ST_EquipamentoGarantia = reader.GetString(reader.GetOrdinal("ST_EquipamentoGarantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_DefeitoCliente")))
                        reg.Ds_defeitocliente = reader.GetString(reader.GetOrdinal("DS_DefeitoCliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapaatual")))
                        reg.Ds_etapaatual = reader.GetString(reader.GetOrdinal("ds_etapaatual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("ds_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                    {
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                        if (reg.Vl_acrescimo > decimal.Zero)
                            reg.Pc_acrescimo = Math.Round(decimal.Multiply(decimal.Divide(reg.Vl_subtotal - reg.Vl_desconto, reg.Vl_subtotal) - 1, 100), 2, MidpointRounding.AwayFromZero);
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                    {
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                        if (reg.Vl_desconto > decimal.Zero)
                            reg.Pc_desconto = Math.Round(decimal.Multiply(1 - decimal.Divide((reg.St_acrescbasedesc ? reg.Vl_subtotal + reg.Vl_acrescimo : reg.Vl_subtotal) - reg.Vl_desconto, (reg.St_acrescbasedesc ? reg.Vl_subtotal + reg.Vl_acrescimo : reg.Vl_subtotal)), 100), 2, MidpointRounding.AwayFromZero);
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginDevolucao")))
                        reg.Logindevolucao = reader.GetString(reader.GetOrdinal("LoginDevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("DT_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_PedidoIntegra")))
                        reg.Nr_pedidointegra = reader.GetDecimal(reader.GetOrdinal("NR_PedidoIntegra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placaveiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("placaveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_veiculo")))
                        reg.Km_veiculo = reader.GetDecimal(reader.GetOrdinal("km_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("anofabric")))
                        reg.Anofabric = reader.GetDecimal(reader.GetOrdinal("anofabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_obsveiculo")))
                        reg.Ds_obsVeiculo = reader.GetString(reader.GetOrdinal("ds_obsveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dias_retirar")))
                        reg.Dias_Retirar = reader.GetDecimal(reader.GetOrdinal("dias_retirar"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_OS"))))
                        reg.St_os = reader.GetString(reader.GetOrdinal("ST_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_nfce")))
                        reg.Nr_nfce = reader.GetDecimal(reader.GetOrdinal("Nr_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_garantia")))
                        reg.Vl_garantia = reader.GetDecimal(reader.GetOrdinal("vl_garantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pecas")))
                        reg.Vl_pecas = reader.GetDecimal(reader.GetOrdinal("vl_pecas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_servico")))
                        reg.Vl_servico = reader.GetDecimal(reader.GetOrdinal("vl_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condPagto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condPagto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Horimetro")))
                        reg.Horimetro = reader.GetDecimal(reader.GetOrdinal("Horimetro"));

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

        public string Gravar(TRegistro_LanServico val)
        {
            Hashtable hs = new Hashtable(34);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_DS_CIDADE", val.Ds_cidade);
            hs.Add("@P_UF", val.Sigla_uf);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_NR_PEDIDOINTEGRA", val.Nr_pedidointegra);
            hs.Add("@P_CD_PRODUTOOS", val.CD_ProdutoOS);
            hs.Add("@P_ID_TRANSP_RECEBIDO", val.Id_tptransp_recebido);
            hs.Add("@P_ID_TRANSP_ENVIADO", val.Id_tptransp_enviado);
            hs.Add("@P_LOGINDEVOLUCAO", val.Logindevolucao);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_DS_VEICULO", val.Ds_veiculo);
            hs.Add("@P_KM_VEICULO", val.Km_veiculo);
            hs.Add("@P_NR_OSORIGEM", val.Nr_osorigem);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_PREVISAO", val.Dt_previsao);
            hs.Add("@P_DT_FINALIZADA", val.Dt_finalizada);
            hs.Add("@P_DT_ENCERRAMENTO", val.Dt_encerramento);
            hs.Add("@P_ST_PRIORIDADE", val.St_prioridade);
            hs.Add("@P_DS_DEFEITOCLIENTE", val.Ds_defeitocliente);
            hs.Add("@P_DS_CONCLUSAOOS", val.DS_ConclusaoOS);
            hs.Add("@P_NR_SERIAL", val.Nr_serial);
            hs.Add("@P_DS_EQUIPAMENTO", val.DS_Equipamento);
            hs.Add("@P_DS_MODELO", val.DS_Modelo);
            hs.Add("@P_ST_EQUIPAMENTOCOMNF", val.St_equipamentocomnf);
            hs.Add("@P_ST_EQUIPAMENTOGARANTIA", val.ST_EquipamentoGarantia);
            hs.Add("@P_DT_DEVOLUCAO", val.Dt_devolucao);
            hs.Add("@P_DS_OBSERVACOESGERAIS", val.Ds_observacoesgerais);
            hs.Add("@P_DS_SERVICO", val.Ds_servico);
            hs.Add("@P_ST_OS", val.St_os);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condPagto);
            hs.Add("@P_HORIMETRO", val.Horimetro);

            return executarProc("IA_OSE_SERVICO", hs);
        }

        public string Excluir(TRegistro_LanServico val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa); 
            
            return executarProc("EXCLUI_OSE_SERVICO", hs);
        }
    }
}
