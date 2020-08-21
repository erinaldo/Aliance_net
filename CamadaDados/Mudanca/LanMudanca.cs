using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca
{
    #region Mudança
    public class TList_LanMudanca : List<TRegistro_LanMudanca>, IComparer<TRegistro_LanMudanca>
    {
        #region IComparer<TRegistro_LanMudanca> Members
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

        public TList_LanMudanca()
        { }

        public TList_LanMudanca(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanMudanca value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanMudanca x, TRegistro_LanMudanca y)
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

    public class TRegistro_LanMudanca
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_mudanca;
        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;
        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Rg
        { get; set; }
        public string Cpf
        { get; set; }
        public string Cnpj
        { get; set; }
        public string Cd_condFiscal_Clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string DS_cidade
        { get; set; }
        public string UF
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string CD_CondPGTO
        { get; set; }
        public string DS_CondPGTO
        { get; set; }
        public string CD_Cidade_Orig
        { get; set; }
        public string DS_Cidade_Orig
        { get; set; }
        public string UfOrig
        { get; set; }
        public string CD_UfOrig
        { get; set; }
        public string CD_Cidade_Dest
        { get; set; }
        public string DS_Cidade_Dest
        { get; set; }
        public string UfDest
        { get; set; }
        public string CD_UfDest
        { get; set; }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string placa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = Convert.ToDecimal(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public decimal Vl_mudanca
        { get; set; }
        public decimal Tot_MTCub
        { get; set; }
        public decimal Tot_Seguro
        { get; set; }
        public decimal SaldoFaturar
        { get; set; }
        public decimal TotalFaturado
        { get; set; }
        private string tp_registro;
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Equals("0"))
                    tipo_registro = "RESIDENCIAL";
                else if (value.Equals("1"))
                    tipo_registro = "COMERCIAL";
            }
        }
        private string tipo_registro;
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("RESIDENCIAL"))
                    tp_registro = "0";
                else if (value.Trim().ToUpper().Equals("COMERCIAL"))
                    tp_registro = "1";
            }
        }
        private DateTime? dt_coleta;
        public DateTime? Dt_coleta
        {
            get { return dt_coleta; }
            set
            {
                dt_coleta = value;
                dt_coletastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_coletastr;
        public string Dt_coletastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_coletastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_coletastr = value;
                try
                {
                    dt_coleta = DateTime.Parse(value);
                }
                catch
                { dt_coleta = null; }
            }
        }
        private DateTime? dt_entrega;
        public DateTime? Dt_entrega
        {
            get { return dt_entrega; }
            set
            {
                dt_entrega = value;
                dt_entregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_entregastr;
        public string Dt_entregastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_entregastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_entregastr = value;
                try
                {
                    dt_entrega = DateTime.Parse(value);
                }
                catch
                { dt_entrega = null; }
            }
        }
        private DateTime? dt_embalagem;
        public DateTime? Dt_embalagem
        {
            get { return dt_embalagem; }
            set
            {
                dt_embalagem = value;
                dt_embalagemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_embalagemstr;
        public string Dt_embalagemstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_embalagemstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_embalagemstr = value;
                try
                {
                    dt_embalagem = DateTime.Parse(value);
                }
                catch
                { dt_embalagem = null; }
            }
        }
        private DateTime? dt_viagem;
        public DateTime? Dt_viagem
        {
            get { return dt_viagem; }
            set
            {
                dt_viagem = value;
                dt_viagemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_viagemstr;
        public string Dt_viagemstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_viagemstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_viagemstr = value;
                try
                {
                    dt_viagem = DateTime.Parse(value);
                }
                catch
                { dt_viagem = null; }
            }
        }
        public string Logradouro_Orig
        { get; set; }
        public string Numero_Orig
        { get; set; }
        public string Bairro_Orig
        { get; set; }
        public string Complemento_Orig
        { get; set; }
        public string Proximo_Orig
        { get; set; }
        public string CEP_Orig
        { get; set; }
        public string Logradouro_Dest
        { get; set; }
        public string Numero_Dest
        { get; set; }
        public string Bairro_Dest
        { get; set; }
        public string Complemento_Dest
        { get; set; }
        public string Proximo_Dest
        { get; set; }
        public string CEP_Dest
        { get; set; }
        private string st_elevadorcoleta;
        public string St_elevadorcoleta
        {
            get { return st_elevadorcoleta; }
            set
            {
                st_elevadorcoleta = value;
                st_elevadorcoletabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_elevadorcoletabool;
        public bool St_elevadorcoletabool
        {
            get { return st_elevadorcoletabool; }
            set
            {
                st_elevadorcoletabool = value;
                if (value)
                    st_elevadorcoleta = "S";
                else
                    st_elevadorcoleta = "N";
            }
        }
        private string st_escadacoleta;
        public string St_escadacoleta
        {
            get { return st_escadacoleta; }
            set
            {
                st_escadacoleta = value;
                st_escadacoletabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_escadacoletabool;
        public bool St_escadacoletabool
        {
            get { return st_escadacoletabool; }
            set
            {
                st_escadacoletabool = value;
                if (value)
                    st_escadacoleta = "S";
                else
                    st_escadacoleta = "N";
            }
        }
        private string st_elevadorentrega;
        public string St_elevadorentrega
        {
            get { return st_elevadorentrega; }
            set
            {
                st_elevadorentrega = value;
                st_elevadorentregabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_elevadorentregabool;
        public bool St_elevadorentregabool
        {
            get { return st_elevadorentregabool; }
            set
            {
                st_elevadorentregabool = value;
                if (value)
                    st_elevadorentrega = "S";
                else
                    st_elevadorentrega = "N";
            }
        }
        private string st_escadaentrega;
        public string St_escadaentrega
        {
            get { return st_escadaentrega; }
            set
            {
                st_escadaentrega = value;
                st_escadaentregabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_escadaentregabool;
        public bool St_escadaentregabool
        {
            get { return st_escadaentregabool; }
            set
            {
                st_escadaentregabool = value;
                if (value)
                    st_escadaentrega = "S";
                else
                    st_escadaentrega = "N";
            }
        }
        private string st_utilizaguardamoveis;
        public string St_utilizaguardamoveis
        {
            get { return st_utilizaguardamoveis; }
            set
            {
                st_utilizaguardamoveis = value;
                st_utilizaguardamoveisbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_utilizaguardamoveisbool;
        public bool St_utilizaguardamoveisbool
        {
            get { return st_utilizaguardamoveisbool; }
            set
            {
                st_utilizaguardamoveisbool = value;
                if (value)
                    st_utilizaguardamoveis = "S";
                else
                    st_utilizaguardamoveis = "N";
            }
        }
        public decimal NR_DiasGuardaMoveis
        { get; set; }
        public string Nr_guardavol
        { get; set; }
        public int NR_DiasExecMudanca
        {
            get
            {
                if (this.dt_coleta.HasValue && this.dt_entrega.HasValue)
                    return this.dt_entrega.Value.Subtract(this.dt_coleta.Value).Days;
                else return 0;
            }
        }
        public string Ds_observacao
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Equals("0"))
                    status = "ORÇAMENTO";
                else if (value.Equals("1"))
                    status = "APROVADA";
                else if (value.Equals("3"))
                    status = "CANCELADA";
                else if (value.Equals("4"))
                    status = "PROCESSADA";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ORÇAMENTO"))
                    st_registro = "0";
                else if (value.Trim().ToUpper().Equals("APROVADA"))
                    st_registro = "1";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_registro = "3";
                else if (value.Trim().ToUpper().Equals("PROCESSADA"))
                    st_registro = "4";
            }
        }
        public string Ds_servico
        { get; set; }
        public string Cd_remetente
        { get; set; }
        public string Nm_remetente
        { get; set; }
        public string Cnpj_remetente
        { get; set; }
        public string Cd_endremetente
        { get; set; }
        public string Ds_endremetente
        { get; set; }
        public string Cd_CondFiscalRemetente
        { get; set; }
        public string Ds_cidaderemetente
        { get; set; }
        public string Uf_remetente
        { get; set; }
        public string Cd_destinatario
        { get; set; }
        public string Nm_destinatario
        { get; set; }
        public string Cnpj_destinatario
        { get; set; }
        public string Cd_enddestinatario
        { get; set; }
        public string Ds_enddestinatario
        { get; set; }
        public string Cd_CondFiscalDestinatario
        { get; set; }
        public string Ds_cidadedestinatario
        { get; set; }
        public string Uf_destinatario
        { get; set; }
        public string Tp_mudanca
        {
            get
            {
                if (!string.IsNullOrEmpty(CD_Cidade_Orig) && !string.IsNullOrEmpty(CD_Cidade_Dest))
                    if (CD_Cidade_Orig.Trim().Equals(CD_Cidade_Dest.Trim()))
                        return "MUNICIPAL";
                    else return "INTERMUNICIPAL";
                else return string.Empty;
            }
        }
        private string tp_pagamento;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().Equals("0"))
                    tipo_pagamento = "DINHEIRO";
                else if (value.Trim().Equals("1"))
                    tipo_pagamento = "CHEQUE";
                else if (value.Trim().Equals("2"))
                    tipo_pagamento = "CARTÃO CRED/DEB";
                else if (value.Trim().Equals("3"))
                    tipo_pagamento = "DEPOSITO BANCARIO";
                else if (value.Trim().Equals("4"))
                    tipo_pagamento = "DUPLICATA";
                else if (value.Trim().Equals("5"))
                    tipo_pagamento = "BOLETO BANCARIO";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("DINHEIRO"))
                    tp_pagamento = "0";
                else if (value.Trim().ToUpper().Equals("CHEQUE"))
                    tp_pagamento = "1";
                else if (value.Trim().ToUpper().Equals("CARTÃO CRED/DEB"))
                    tp_pagamento = "2";
                else if (value.Trim().ToUpper().Equals("DEPOSITO BANCARIO"))
                    tp_pagamento = "3";
                else if (value.Trim().ToUpper().Equals("DUPLICATA"))
                    tp_pagamento = "4";
                else if (value.Trim().ToUpper().Equals("BOLETO BANCARIO"))
                    tp_pagamento = "5";
            }
        }
        public string Obspagamento
        { get; set; }

        public decimal QTD_parcelas
        { get; set; }
        public decimal QTD_diasdesdobro
        { get; set; }
        public string ST_SolicitarDTVencto
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }

        public TList_LanItensMud lItensMud
        { get; set; }
        public TList_LanItensMud lItensMudDel
        { get; set; }
        public TList_LanServicosMud lServicosMud
        { get; set; }
        public TList_LanServicosMud lServicosMudDel
        { get; set; }
        public TList_ParcelasMud lParcelasMud
        { get; set; }
        public TList_ParcelasMud lParcelasMudDel
        { get; set; }
        public TList_MaterialMud lMaterialMud
        { get; set; }
        public TList_MaterialMud lMaterialMudDel
        { get; set; }
        public TList_AjudantesMud lAjudantesMud
        { get; set; }
        public TList_AjudantesMud lAjudantesMudDel
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDupDel
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lFat
        { get; set; }
        public CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrc
        { get; set; }
        public CamadaDados.Mudanca.TList_Orcamento lOrcamento
        { get; set; }
        public CamadaDados.Frota.TRegistro_Viagem rViagem
        { get; set; }
        public CamadaDados.Frota.Cadastros.TList_DespesasVeiculo lDespesas
        { get; set; }

        public TRegistro_LanMudanca()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Rg = string.Empty;
            this.Cpf = string.Empty;
            this.Cnpj = string.Empty;
            this.Cd_condFiscal_Clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.DS_cidade = string.Empty;
            this.UF = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.CD_CondPGTO = string.Empty;
            this.DS_CondPGTO = string.Empty;
            this.CD_Cidade_Orig = string.Empty;
            this.DS_Cidade_Orig = string.Empty;
            this.UfOrig = string.Empty;
            this.CD_UfOrig = string.Empty;
            this.CD_Cidade_Dest = string.Empty;
            this.DS_Cidade_Dest = string.Empty;
            this.UfDest = string.Empty;
            this.CD_UfDest = string.Empty;
            this.id_veiculo = null;
            this.id_veiculostr = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.placa = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Ds_viagem = string.Empty;
            this.Nr_lancto = null;
            this.Vl_mudanca = decimal.Zero;
            this.Tot_MTCub = decimal.Zero;
            this.Tot_Seguro = decimal.Zero;
            this.SaldoFaturar = decimal.Zero;
            this.TotalFaturado = decimal.Zero;
            this.tp_registro = string.Empty;
            this.tipo_registro = string.Empty;
            this.dt_coleta = null;
            this.dt_coletastr = string.Empty;
            this.dt_entrega = null;
            this.dt_entregastr = string.Empty;
            this.dt_embalagem = null;
            this.dt_embalagemstr = string.Empty;
            this.dt_viagem = null;
            this.dt_viagemstr = string.Empty;
            this.Logradouro_Orig = string.Empty;
            this.Numero_Orig = string.Empty;
            this.Bairro_Orig = string.Empty;
            this.Complemento_Orig = string.Empty;
            this.Numero_Orig = string.Empty;
            this.CEP_Orig = string.Empty;
            this.Logradouro_Dest = string.Empty;
            this.Numero_Dest = string.Empty;
            this.Bairro_Dest = string.Empty;
            this.Complemento_Dest = string.Empty;
            this.Proximo_Dest = string.Empty;
            this.CEP_Dest = string.Empty;
            this.st_elevadorcoleta = "N";
            this.st_elevadorcoletabool = false;
            this.st_escadacoleta = "N";
            this.st_escadacoletabool = false;
            this.st_elevadorentrega = "N";
            this.st_elevadorentregabool = false;
            this.st_escadaentrega = "N";
            this.st_escadaentregabool = false;
            this.st_utilizaguardamoveis = "N";
            this.st_utilizaguardamoveisbool = false;
            this.NR_DiasGuardaMoveis = decimal.Zero;
            this.Nr_guardavol = string.Empty;
            this.Ds_observacao = string.Empty;
            this.st_registro = "0";
            this.Ds_servico = string.Empty;
            this.Cd_remetente = string.Empty;
            this.Nm_remetente = string.Empty;
            this.Cnpj_remetente = string.Empty;
            this.Cd_CondFiscalRemetente = string.Empty;
            this.Cd_endremetente = string.Empty;
            this.Ds_endremetente = string.Empty;
            this.Ds_cidaderemetente = string.Empty;
            this.Uf_remetente = string.Empty;
            this.Cd_destinatario = string.Empty;
            this.Nm_destinatario = string.Empty;
            this.Cnpj_destinatario = string.Empty;
            this.Cd_CondFiscalDestinatario = string.Empty;
            this.Cd_enddestinatario = string.Empty;
            this.Ds_enddestinatario = string.Empty;
            this.Ds_cidadedestinatario = string.Empty;
            this.Uf_destinatario = string.Empty;

            this.QTD_parcelas = decimal.Zero;
            this.QTD_diasdesdobro = 0;
            this.ST_SolicitarDTVencto = string.Empty;
            this.tp_pagamento = string.Empty;
            this.tipo_pagamento = string.Empty;
            this.Obspagamento = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;

            this.lItensMud = new TList_LanItensMud();
            this.lItensMudDel = new TList_LanItensMud();
            this.lServicosMud = new TList_LanServicosMud();
            this.lServicosMudDel = new TList_LanServicosMud();
            this.lParcelasMud = new TList_ParcelasMud();
            this.lParcelasMudDel = new TList_ParcelasMud();
            this.lMaterialMud = new TList_MaterialMud();
            this.lMaterialMudDel = new TList_MaterialMud();
            this.lAjudantesMud = new TList_AjudantesMud();
            this.lAjudantesMudDel = new TList_AjudantesMud();
            this.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lDupDel = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lFat = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            this.lCtrc = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete();
            this.lOrcamento = new TList_Orcamento();
            this.rViagem = new CamadaDados.Frota.TRegistro_Viagem();
            this.lDespesas = new CamadaDados.Frota.Cadastros.TList_DespesasVeiculo();
        }
    }

    public class TCD_LanMudanca : TDataQuery
    {
        public TCD_LanMudanca()
        { }

        public TCD_LanMudanca(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.cd_empresa, emp.nm_empresa, a.ID_mudanca, a.NR_GuardaVol, ");
                sql.AppendLine("a.Cd_clifor, b.nm_clifor, b.NR_CPF, b.NR_RG, b.NR_CGC, b.CD_CONDFISCAL_CLIFOR, a.cd_endereco, ");
                sql.AppendLine("c.ds_endereco, c.ds_cidade, c.uf, a.cd_portador, d.ds_portador, ");
                sql.AppendLine("a.CD_CondPGTO, e.DS_CondPGTO, e.QT_parcelas, e.ST_SolicitarDTVencto, ");
                sql.AppendLine("e.QT_diasdesdobro, a.CD_Cidade_Orig, cidOrig.ds_cidade as DS_Cidade_Orig, ");
                sql.AppendLine("a.CD_Cidade_Dest, cidDest.ds_cidade as DS_Cidade_Dest, ");
                sql.AppendLine("a.id_veiculo, f.ds_veiculo, f.placa, a.cd_motorista, g.nm_clifor as nm_motorista, ");
                sql.AppendLine("a.tp_registro, a.dt_coleta, a.dt_entrega, a.dt_embalagem, a.dt_viagem, ");
                sql.AppendLine("ufOrig.uf as ufOrig, ufDest.uf as ufDest, a.nr_lancto, a.vl_mudanca, ");
                sql.AppendLine("a.Tot_MTCub, a.Tot_Seguro, a.SaldoFaturar, a.TotalFaturado, a.Logradouro_Orig, ");
                sql.AppendLine("a.Numero_Orig, a.Bairro_Orig, a.Complemento_Orig, a.Proximo_Orig, a.CEP_Orig, ");
                sql.AppendLine("a.Logradouro_Dest, cidOrig.cd_uf as cd_ufOrig, cidDest.cd_uf as cd_ufDest, ");
                sql.AppendLine("a.Numero_Dest, a.Bairro_Dest, a.Complemento_Dest, a.Proximo_Dest, a.CEP_Dest, ");
                sql.AppendLine("a.ST_ElevadorColeta, a.ST_EscadaColeta, a.TP_Pagamento, a.ObsPagamento, ");
                sql.AppendLine("a.cd_remetente, rem.nm_clifor as nm_remetente, rem.nr_cgc as cnpj_remetente, rem.CD_CONDFISCAL_CLIFOR as cd_condfiscalRementente, ");
                sql.AppendLine("a.cd_vendedor, cVend.nm_clifor as nm_vendedor, ");
                sql.AppendLine("a.cd_endremetente, eRem.ds_endereco as ds_endremetente, eRem.ds_cidade as ds_cidaderemetente, eRem.uf as uf_remetente, ");
                sql.AppendLine("a.cd_destinatario, dest.nm_clifor as nm_destinatario, dest.nr_cgc as cnpj_destinatario, dest.CD_CONDFISCAL_CLIFOR as cd_condfiscalDestinatario, ");
                sql.AppendLine("a.cd_enddestinatario, eDest.ds_endereco as ds_enddestinatario, ");
                sql.AppendLine("eDest.ds_cidade as ds_cidadedestinatario, eDest.uf as uf_destinatario, ");
                sql.AppendLine("a.ST_ElevadorEntrega, a.ST_EscadaEntrega, a.ST_UtilizaGuardaMoveis, ");
                sql.AppendLine("a.NR_DiasGuardaMoveis, a.ds_observacao, a.ST_Registro, ");
                sql.AppendLine("a.id_viagem, h.ds_viagem, h.dt_viagem, h.dt_retorno, ");
                sql.AppendLine("h.km_inicial, h.km_final, h.ds_observacao, h.st_viagem ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_MUD_Mudanca a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join VTB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = c.cd_endereco ");
            sql.AppendLine("left outer join TB_FIN_Portador d ");
            sql.AppendLine("on a.cd_portador = d.cd_portador  ");
            sql.AppendLine("left outer join TB_FIN_CondPgto e ");
            sql.AppendLine("on a.CD_CondPGTO = e.CD_CondPGTO ");
            sql.AppendLine("left outer join TB_FIN_Cidade cidOrig ");
            sql.AppendLine("on a.CD_Cidade_Orig = cidOrig.CD_Cidade ");
            sql.AppendLine("left outer join TB_FIN_UF ufOrig ");
            sql.AppendLine("on cidOrig.cd_uf = ufOrig.cd_uf ");
            sql.AppendLine("left outer join TB_FIN_Cidade cidDest ");
            sql.AppendLine("on a.CD_Cidade_Dest = cidDest.CD_Cidade ");
            sql.AppendLine("left outer join TB_FIN_UF ufDest ");
            sql.AppendLine("on cidDest.cd_uf = ufDest.cd_uf ");
            sql.AppendLine("left outer join TB_FRT_Veiculo f ");
            sql.AppendLine("on a.id_veiculo = f.id_veiculo ");
            sql.AppendLine("left outer join TB_FIN_Clifor g ");
            sql.AppendLine("on a.cd_motorista = g.cd_clifor ");
            sql.AppendLine("left outer join TB_FRT_Viagem h ");
            sql.AppendLine("on a.cd_empresa = h.cd_empresa ");
            sql.AppendLine("and a.id_viagem = h.id_viagem ");
            sql.AppendLine("left outer join VTB_FIN_Clifor rem ");
            sql.AppendLine("on a.cd_remetente = rem.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco eRem ");
            sql.AppendLine("on a.cd_remetente = eRem.cd_clifor ");
            sql.AppendLine("and a.cd_endremetente = eRem.cd_endereco ");
            sql.AppendLine("left outer join VTB_FIN_Clifor dest ");
            sql.AppendLine("on a.cd_destinatario = dest.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco eDest ");
            sql.AppendLine("on a.cd_destinatario = eDest.cd_clifor ");
            sql.AppendLine("and a.cd_enddestinatario = eDest.cd_endereco ");
            sql.AppendLine("left outer join TB_FIN_Clifor cVend ");
            sql.AppendLine("on a.cd_vendedor = cVend.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.id_mudanca ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanMudanca Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LanMudanca lista = new TList_LanMudanca();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LanMudanca reg = new TRegistro_LanMudanca();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                    {
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                        reg.rViagem.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                    {
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                        reg.rViagem.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("Id_mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.Cpf = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_RG")))
                        reg.Rg = reader.GetString(reader.GetOrdinal("NR_RG"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONDFISCAL_CLIFOR")))
                        reg.Cd_condFiscal_Clifor = reader.GetString(reader.GetOrdinal("CD_CONDFISCAL_CLIFOR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.DS_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.UF = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("Cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("Ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.CD_CondPGTO = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.DS_CondPGTO = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_parcelas")))
                        reg.QTD_parcelas = reader.GetDecimal(reader.GetOrdinal("QT_parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SolicitarDTVencto")))
                        reg.ST_SolicitarDTVencto = reader.GetString(reader.GetOrdinal("ST_SolicitarDTVencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_diasdesdobro")))
                        reg.QTD_diasdesdobro = reader.GetDecimal(reader.GetOrdinal("QT_diasdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade_Orig")))
                        reg.CD_Cidade_Orig = reader.GetString(reader.GetOrdinal("CD_Cidade_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade_Orig")))
                        reg.DS_Cidade_Orig = reader.GetString(reader.GetOrdinal("DS_Cidade_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ufOrig")))
                        reg.UfOrig = reader.GetString(reader.GetOrdinal("ufOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UfOrig")))
                        reg.CD_UfOrig = reader.GetString(reader.GetOrdinal("CD_UfOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade_Dest")))
                        reg.CD_Cidade_Dest = reader.GetString(reader.GetOrdinal("CD_Cidade_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade_Dest")))
                        reg.DS_Cidade_Dest = reader.GetString(reader.GetOrdinal("DS_Cidade_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ufDest")))
                        reg.UfDest = reader.GetString(reader.GetOrdinal("ufDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UfDest")))
                        reg.CD_UfDest = reader.GetString(reader.GetOrdinal("CD_UfDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Veiculo")))
                    {
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_Veiculo"));
                        reg.rViagem.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_veiculo")))
                    {
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("Ds_veiculo"));
                        reg.rViagem.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                    {
                        reg.placa = reader.GetString(reader.GetOrdinal("placa"));
                        reg.rViagem.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                    {
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                        reg.rViagem.Cd_motorista = reader.GetString(reader.GetOrdinal("cd_motorista"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_motorista")))
                    {
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("Nm_motorista"));
                        reg.rViagem.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_viagem")))
                    {
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("Id_viagem"));
                        reg.rViagem.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_viagem")))
                    {
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                        reg.rViagem.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_viagem")))
                        reg.rViagem.Dt_viagem = reader.GetDateTime(reader.GetOrdinal("dt_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_retorno")))
                        reg.rViagem.Dt_retorno = reader.GetDateTime(reader.GetOrdinal("dt_retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_inicial")))
                        reg.rViagem.KM_inicial = reader.GetDecimal(reader.GetOrdinal("km_inicial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_final")))
                        reg.rViagem.KM_final = reader.GetDecimal(reader.GetOrdinal("km_final"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.rViagem.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_viagem")))
                        reg.rViagem.St_viagem = reader.GetString(reader.GetOrdinal("st_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_mudanca")))
                        reg.Vl_mudanca = reader.GetDecimal(reader.GetOrdinal("vl_mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_MTCub")))
                        reg.Tot_MTCub = reader.GetDecimal(reader.GetOrdinal("Tot_MTCub"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Seguro")))
                        reg.Tot_Seguro = reader.GetDecimal(reader.GetOrdinal("Tot_Seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoFaturar")))
                        reg.SaldoFaturar = reader.GetDecimal(reader.GetOrdinal("SaldoFaturar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TotalFaturado")))
                        reg.TotalFaturado = reader.GetDecimal(reader.GetOrdinal("TotalFaturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Coleta")))
                        reg.Dt_coleta = reader.GetDateTime(reader.GetOrdinal("DT_Coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("Dt_entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_embalagem")))
                        reg.Dt_embalagem = reader.GetDateTime(reader.GetOrdinal("Dt_embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_viagem")))
                        reg.Dt_viagem = reader.GetDateTime(reader.GetOrdinal("Dt_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logradouro_Orig")))
                        reg.Logradouro_Orig = reader.GetString(reader.GetOrdinal("Logradouro_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero_Orig")))
                        reg.Numero_Orig = reader.GetString(reader.GetOrdinal("Numero_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro_Orig")))
                        reg.Bairro_Orig = reader.GetString(reader.GetOrdinal("Bairro_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complemento_Orig")))
                        reg.Complemento_Orig = reader.GetString(reader.GetOrdinal("Complemento_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Proximo_Orig")))
                        reg.Proximo_Orig = reader.GetString(reader.GetOrdinal("Proximo_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEP_Orig")))
                        reg.CEP_Orig = reader.GetString(reader.GetOrdinal("CEP_Orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logradouro_Dest")))
                        reg.Logradouro_Dest = reader.GetString(reader.GetOrdinal("Logradouro_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero_Dest")))
                        reg.Numero_Dest = reader.GetString(reader.GetOrdinal("Numero_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro_Dest")))
                        reg.Bairro_Dest = reader.GetString(reader.GetOrdinal("Bairro_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complemento_Dest")))
                        reg.Complemento_Dest = reader.GetString(reader.GetOrdinal("Complemento_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Proximo_Dest")))
                        reg.Proximo_Dest = reader.GetString(reader.GetOrdinal("Proximo_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEP_Dest")))
                        reg.CEP_Dest = reader.GetString(reader.GetOrdinal("CEP_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ElevadorColeta")))
                        reg.St_elevadorcoleta = reader.GetString(reader.GetOrdinal("ST_ElevadorColeta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EscadaColeta")))
                        reg.St_escadacoleta = reader.GetString(reader.GetOrdinal("ST_EscadaColeta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ElevadorEntrega")))
                        reg.St_elevadorentrega = reader.GetString(reader.GetOrdinal("ST_ElevadorEntrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EscadaEntrega")))
                        reg.St_escadaentrega = reader.GetString(reader.GetOrdinal("ST_EscadaEntrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_UtilizaGuardaMoveis")))
                        reg.St_utilizaguardamoveis = reader.GetString(reader.GetOrdinal("ST_UtilizaGuardaMoveis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasGuardaMoveis")))
                        reg.NR_DiasGuardaMoveis = reader.GetDecimal(reader.GetOrdinal("NR_DiasGuardaMoveis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("Ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_remetente")))
                        reg.Cd_remetente = reader.GetString(reader.GetOrdinal("cd_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_remetente")))
                        reg.Nm_remetente = reader.GetString(reader.GetOrdinal("nm_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_remetente")))
                        reg.Cnpj_remetente = reader.GetString(reader.GetOrdinal("cnpj_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscalRementente")))
                        reg.Cd_CondFiscalRemetente = reader.GetString(reader.GetOrdinal("cd_condfiscalRementente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endremetente")))
                        reg.Cd_endremetente = reader.GetString(reader.GetOrdinal("cd_endremetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endremetente")))
                        reg.Ds_endremetente = reader.GetString(reader.GetOrdinal("ds_endremetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidaderemetente")))
                        reg.Ds_cidaderemetente = reader.GetString(reader.GetOrdinal("ds_cidaderemetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_remetente")))
                        reg.Uf_remetente = reader.GetString(reader.GetOrdinal("uf_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_destinatario")))
                        reg.Cd_destinatario = reader.GetString(reader.GetOrdinal("cd_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_destinatario")))
                        reg.Nm_destinatario = reader.GetString(reader.GetOrdinal("nm_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_destinatario")))
                        reg.Cnpj_destinatario = reader.GetString(reader.GetOrdinal("cnpj_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscalDestinatario")))
                        reg.Cd_CondFiscalDestinatario = reader.GetString(reader.GetOrdinal("cd_condfiscalDestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_enddestinatario")))
                        reg.Cd_enddestinatario = reader.GetString(reader.GetOrdinal("cd_enddestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_enddestinatario")))
                        reg.Ds_enddestinatario = reader.GetString(reader.GetOrdinal("ds_enddestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadedestinatario")))
                        reg.Ds_cidadedestinatario = reader.GetString(reader.GetOrdinal("ds_cidadedestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_destinatario")))
                        reg.Uf_destinatario = reader.GetString(reader.GetOrdinal("uf_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("tp_pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obspagamento")))
                        reg.Obspagamento = reader.GetString(reader.GetOrdinal("obspagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_guardavol")))
                        reg.Nr_guardavol = reader.GetString(reader.GetOrdinal("nr_guardavol"));

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

        public string Gravar(TRegistro_LanMudanca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(44);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_CONDPGTO", val.CD_CondPGTO);
            hs.Add("@P_CD_CIDADE_ORIG", val.CD_Cidade_Orig);
            hs.Add("@P_CD_CIDADE_DEST", val.CD_Cidade_Dest);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_REMETENTE", val.Cd_remetente);
            hs.Add("@P_CD_ENDREMETENTE", val.Cd_endremetente);
            hs.Add("@P_CD_DESTINATARIO", val.Cd_destinatario);
            hs.Add("@P_CD_ENDDESTINATARIO", val.Cd_enddestinatario);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_DT_COLETA", val.Dt_coleta);
            hs.Add("@P_DT_ENTREGA", val.Dt_entrega);
            hs.Add("@P_DT_EMBALAGEM", val.Dt_embalagem);
            hs.Add("@P_DT_VIAGEM", val.Dt_viagem);
            hs.Add("@P_LOGRADOURO_ORIG", val.Logradouro_Orig);
            hs.Add("@P_NUMERO_ORIG", val.Numero_Orig);
            hs.Add("@P_BAIRRO_ORIG", val.Bairro_Orig);
            hs.Add("@P_COMPLEMENTO_ORIG", val.Complemento_Orig);
            hs.Add("@P_PROXIMO_ORIG", val.Proximo_Orig);
            hs.Add("@P_CEP_ORIG", val.CEP_Orig);
            hs.Add("@P_LOGRADOURO_DEST", val.Logradouro_Dest);
            hs.Add("@P_NUMERO_DEST", val.Numero_Dest);
            hs.Add("@P_BAIRRO_DEST", val.Bairro_Dest);
            hs.Add("@P_COMPLEMENTO_DEST", val.Complemento_Dest);
            hs.Add("@P_PROXIMO_DEST", val.Proximo_Dest);
            hs.Add("@P_CEP_DEST", val.CEP_Dest);
            hs.Add("@P_ST_ELEVADORCOLETA", val.St_elevadorcoleta);
            hs.Add("@P_ST_ESCADACOLETA", val.St_escadacoleta);
            hs.Add("@P_ST_ELEVADORENTREGA", val.St_elevadorentrega);
            hs.Add("@P_ST_ESCADAENTREGA", val.St_escadaentrega);
            hs.Add("@P_ST_UTILIZAGUARDAMOVEIS", val.St_utilizaguardamoveis);
            hs.Add("@P_NR_DIASGUARDAMOVEIS", val.NR_DiasGuardaMoveis);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_OBSPAGAMENTO", val.Obspagamento);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_MUD_MUDANCA", hs);
        }

        public string Excluir(TRegistro_LanMudanca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);

            return this.executarProc("EXCLUI_MUD_MUDANCA", hs);
        }


    }


    #endregion

    #region Parcelas Mudança
    public class TList_ParcelasMud : List<TRegistro_ParcelasMud>, IComparer<TRegistro_ParcelasMud>
    {
        #region IComparer<TRegistro_ParcelasMud> Members
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

        public TList_ParcelasMud()
        { }

        public TList_ParcelasMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ParcelasMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ParcelasMud x, TRegistro_ParcelasMud y)
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


    public class TRegistro_ParcelasMud
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;

        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;

        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
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

        public decimal DiaVencto
        { get; set; }
        public DateTime Dt_vencto
        { get { return DateTime.Now.Date.AddDays(Convert.ToDouble(this.DiaVencto)); } }

        public decimal Vl_parcela
        { get; set; }

        public TRegistro_ParcelasMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.cd_parcela = null;
            this.cd_parcelastr = string.Empty;
            this.DiaVencto = decimal.Zero;
            this.Vl_parcela = decimal.Zero;
        }
    }

    public class TCD_ParcelasMud : TDataQuery
    {
        public TCD_ParcelasMud()
        { }

        public TCD_ParcelasMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, ");
                sql.AppendLine("a.CD_Parcela, a.DiaVencto, a.Vl_Parcela ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_ParcelasMud a ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ParcelasMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ParcelasMud lista = new TList_ParcelasMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ParcelasMud reg = new TRegistro_ParcelasMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaVencto")))
                        reg.DiaVencto = reader.GetDecimal(reader.GetOrdinal("DiaVencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Parcela")))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("Vl_Parcela"));


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

        public string Gravar(TRegistro_ParcelasMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_DIAVENCTO", val.DiaVencto);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);

            return this.executarProc("IA_MUD_PARCELASMUD", hs);
        }

        public string Excluir(TRegistro_ParcelasMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);

            return this.executarProc("EXCLUI_MUD_PARCELASMUD", hs);
        }


    }


    #endregion

    #region Material Mudança
    public class TList_MaterialMud : List<TRegistro_MaterialMud>, IComparer<TRegistro_MaterialMud>
    {
        #region IComparer<TRegistro_MaterialMud> Members
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

        public TList_MaterialMud()
        { }

        public TList_MaterialMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MaterialMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MaterialMud x, TRegistro_MaterialMud y)
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


    public class TRegistro_MaterialMud
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;

        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;

        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
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
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public string Sigla_Unidade
        { get; set; }


        public TRegistro_MaterialMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Sigla_Unidade = string.Empty;
        }
    }

    public class TCD_MaterialMud : TDataQuery
    {
        public TCD_MaterialMud()
        { }

        public TCD_MaterialMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, a.ID_Movimento, ");
                sql.AppendLine("a.CD_Produto, b.ds_produto, c.Sigla_Unidade, a.Quantidade ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_MaterialMud a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_MaterialMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_MaterialMud lista = new TList_MaterialMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_MaterialMud reg = new TRegistro_MaterialMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("ID_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));


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

        public string Gravar(TRegistro_MaterialMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return this.executarProc("IA_MUD_MATERIALMUD", hs);
        }

        public string Excluir(TRegistro_MaterialMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_MUD_MATERIALMUD", hs);
        }


    }


    #endregion

    #region Ajudantes Mudança
    public class TList_AjudantesMud : List<TRegistro_AjudantesMud>, IComparer<TRegistro_AjudantesMud>
    {
        #region IComparer<TRegistro_AjudantesMud> Members
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

        public TList_AjudantesMud()
        { }

        public TList_AjudantesMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AjudantesMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AjudantesMud x, TRegistro_AjudantesMud y)
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


    public class TRegistro_AjudantesMud
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;

        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;

        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
        public string Cd_ajudante
        { get; set; }
        public string Nm_ajudante
        { get; set; }

        public TRegistro_AjudantesMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.Cd_ajudante = string.Empty;
            this.Nm_ajudante = string.Empty;
        }
    }

    public class TCD_AjudantesMud : TDataQuery
    {
        public TCD_AjudantesMud()
        { }

        public TCD_AjudantesMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, ");
                sql.AppendLine("a.Cd_ajudante, b.nm_clifor as nm_ajudante ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_AjudantesMud a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_ajudante = b.cd_clifor ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AjudantesMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_AjudantesMud lista = new TList_AjudantesMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_AjudantesMud reg = new TRegistro_AjudantesMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ajudante")))
                        reg.Cd_ajudante = reader.GetString(reader.GetOrdinal("Cd_ajudante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_ajudante")))
                        reg.Nm_ajudante = reader.GetString(reader.GetOrdinal("nm_ajudante"));


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

        public string Gravar(TRegistro_AjudantesMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_AJUDANTE", val.Cd_ajudante);

            return this.executarProc("IA_MUD_AJUDANTESMUD", hs);
        }

        public string Excluir(TRegistro_AjudantesMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_CD_AJUDANTE", val.Cd_ajudante);

            return this.executarProc("EXCLUI_MUD_AJUDANTESMUD", hs);
        }


    }


    #endregion
}
