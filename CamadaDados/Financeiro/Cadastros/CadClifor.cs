using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Cadastros
{
    #region Interface Clifor PJ
    interface IClifor_PJ
    {
        string Nm_fantasia { get; set; }
        string Nr_cgc { get; set; }
    }
    #endregion

    #region Interface Clifor PF
    interface IClifor_PF
    {
        string Nr_cpf { get; set; }
        decimal Vl_renda { get; set; }
        string Nm_localtrabalho { get; set; }
        string Nm_cargo { get; set; }
        string Enderecotrab { get; set; }
        string Fonetrab { get; set; }
        string Dt_adm { get; set; }
        string Nr_rg { get; set; }
        string Estadocivil { get; set; }
        string Estadocivilstr{ get; set; }
        string Tp_residencia { get; set; }
        string Tipo_residencia { get; set; }
        decimal Vl_aluguel { get; set; }
        string St_veiculoproprio { get; set; }
        bool St_veiculopropriobool { get; set; }
        string Nm_conjuge { get; set; }
        string Cpf_conjuge { get; set; }
        string Rg_conjuge { get; set; }
        string Orgaoesp { get; set; }
        string Orgaoespconj { get; set; }
        DateTime? Dt_nascimento { get; set; }
        string Dt_nascimentostr { get; set; }
        DateTime? Dt_nascconjuge { get; set; }
        string Dt_nascconjugestr { get; set; }
        string Emailconj { get; set; }
        string St_envemailaniversario { get; set; }
        bool St_envemailaniversariobool { get; set; }
        string Tp_sexo { get; set; }
        string Tipo_sexo { get; set; }
        string Nm_pai { get; set; }
        string Nm_mae { get; set; }
        string Ds_localTrabConj { get; set; }
        string Nm_cargoConj { get; set; }
        decimal Vl_rendaConj { get; set; }
    }
    #endregion

    #region Interface Clifor Funcionario
    interface IClifor_Funcionario:IClifor_Motorista
    {
        string Cd_empresa { get; set; }
        string Nm_empresa { get; set; }
        decimal? Id_cargo { get; set; }
        string Id_cargostr { get; set; }
        string Ds_cargo { get; set; }
        bool St_vendedor { get; set; }
        bool St_motorista { get; set; }
        DateTime? Dt_admissao { get; set; }
        string Dt_admissaostr { get; set; }
        DateTime? Dt_demissao { get; set; }
        string Dt_demissaostr { get; set; }
        decimal Vl_salario { get; set; }
        bool St_gerarpagamento { get; set; }
        string Nr_pis { get; set; }
        string Cd_cidadenasc { get; set; }
        string Ds_cidadenasc { get; set; }
        string Uf_nasc { get; set; }
        string St_funcativo { get; set; }
        bool St_funcativobool { get; set; }
    }
    #endregion

    #region Interface Clifor Motorista
    interface IClifor_Motorista
    {
        decimal? Id_veiculo { get; set; }
        string Id_veiculostr { get; set; }
        string cnh { get; set; }
        string Categoria_cnh { get; set; }
        DateTime? Dt_vencimento_cnh { get; set; }
        string Dt_vencimento_cnhstr { get; set; }
        string St_ativomot { get; set; }
        bool St_ativomotbool { get; set; }
       
    }
    #endregion

    #region Clifor
    public class TList_CadClifor : List<TRegistro_CadClifor>, IComparer<TRegistro_CadClifor>
    {
        #region IComparer<TRegistro_CadClifor> Members
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

        public TList_CadClifor()
        { }

        public TList_CadClifor(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadClifor x, TRegistro_CadClifor y)
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
    
    public class TRegistro_CadClifor : IClifor_PJ, IClifor_PF, IClifor_Funcionario
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_regiao;
        public decimal? Id_regiao
        {
            get { return id_regiao; }
            set
            {
                id_regiao = value;
                id_regiaostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_regiaostring;
        public string Id_regiaostring
        {
            get { return id_regiaostring; }
            set
            {
                id_regiaostring = value;
                try
                {
                    id_regiao = Convert.ToDecimal(value);
                }
                catch
                { id_regiao = null; }
            }
        }
        public string Nm_regiao
        { get; set; }
        private decimal? id_ramoatividade;
        public decimal? Id_ramoatividade
        {
            get { return id_ramoatividade; }
            set
            {
                id_ramoatividade = value;
                id_ramoatividadestring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_ramoatividadestring;
        public string Id_ramoatividadestring
        {
            get { return id_ramoatividadestring; }
            set
            {
                id_ramoatividadestring = value;
                try
                {
                    id_ramoatividade = Convert.ToDecimal(value);
                }
                catch
                { id_ramoatividade = null; }
            }
        }
        public string Ds_ramoatividade
        { get; set; }
        public string Cd_indicador
        { get; set; }
        public string Nm_indicador
        { get; set; }
        private string tp_pessoa;
        public string Tp_pessoa
        {
            get { return tp_pessoa; }
            set
            {
                tp_pessoa = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_pessoa = "FISICA";
                else if (value.Trim().ToUpper().Equals("J"))
                    tipo_pessoa = "JURIDICA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_pessoa = "ESTRANGEIRO";
            }
        }
        private string tipo_pessoa;
        public string Tipo_pessoa
        {
            get { return tipo_pessoa; }
            set
            {
                tipo_pessoa = value;
                if (value.Trim().ToUpper().Equals("FISICA"))
                    tp_pessoa = "F";
                else if (value.Trim().ToUpper().Equals("JURIDICA"))
                    tp_pessoa = "J";
                else if (value.Trim().ToUpper().Equals("ESTRANGEIRO"))
                    tp_pessoa = "E";
            }
        }
        public string Id_estrangeiro
        { get; set; }
        private string st_transportadora;
        public string St_transportadora
        {
            get { return st_transportadora; }
            set
            {
                st_transportadora = value;
                st_transportadorabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_transportadorabool;
        public bool St_transportadorabool
        {
            get { return st_transportadorabool; }
            set
            {
                st_transportadorabool = value;
                st_transportadora = value ? "S" : "N";
            }
        }
        public bool St_funcionario
        { get; set; }
        private string st_equiparado_pj;
        public string St_equiparado_pj
        {
            get { return st_equiparado_pj; }
            set
            {
                st_equiparado_pj = value;
                st_equiparado_pjbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_equiparado_pjbool;
        public bool St_equiparado_pjbool
        {
            get { return st_equiparado_pjbool; }
            set
            {
                st_equiparado_pjbool = value;
                st_equiparado_pj = value ? "S" : "N";
            }
        }
        private string st_fornecedor;
        public string St_fornecedor
        {
            get { return st_fornecedor; }
            set
            {
                st_fornecedor = value;
                st_fornecedorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_fornecedorbool;
        public bool St_fornecedorbool
        {
            get { return st_fornecedorbool; }
            set
            {
                st_fornecedorbool = value;
                st_fornecedor = value ? "S" : "N";
            }
        }
        private string st_agropecuaria;
        public string St_agropecuaria
        {
            get { return st_agropecuaria; }
            set
            {
                st_agropecuaria = value;
                st_agropecuariabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_agropecuariabool;
        public bool St_agropecuariabool
        {
            get { return st_agropecuariabool; }
            set
            {
                st_agropecuariabool = value;
                st_agropecuaria = value ? "S" : "N";
            }
        }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Ds_condfiscal_clifor
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
                    status = "ATIVO";
                    st_registrobool = true;
                }
                else if (value.Trim().ToUpper().Equals("C"))
                {
                    status = "CANCELADO";
                    st_registrobool = false;
                }
            }
        }
        private bool st_registrobool;
        public bool St_registrobool
        {
            get { return st_registrobool; }
            set
            {
                st_registrobool = value;
                st_registro = value ? "A" : "C";
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
            }
        }
        public decimal Vl_limitecredito
        { get; set; }
        public decimal Vl_limitecredCH
        { get; set; }
        private string st_bloq_debitovencido;
        public string St_bloq_debitovencido
        {
            get { return st_bloq_debitovencido; }
            set
            {
                st_bloq_debitovencido = value;
                st_bloq_debitovencidobool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_bloq_debitovencidobool;
        public bool St_bloq_debitovencidobool
        {
            get { return st_bloq_debitovencidobool; }
            set
            {
                st_bloq_debitovencidobool = value;
                st_bloq_debitovencido = value ? "S" : "N";
            }
        }
        public decimal DiasCarenciaDebVencto
        { get; set; }
        private string st_bloqcreditoavulso;
        public string St_bloqcreditoavulso
        {
            get { return st_bloqcreditoavulso; }
            set
            {
                st_bloqcreditoavulso = value;
                st_bloqcreditoavulsobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_bloqcreditoavulsobool;
        public bool St_bloqcreditoavulsobool
        {
            get { return st_bloqcreditoavulsobool; }
            set
            {
                st_bloqcreditoavulsobool = value;
                st_bloqcreditoavulso = value ? "S" : "N";
            }
        }
        public string Ds_motivobloqavulso
        { get; set; }
        private DateTime? dt_cadastro;
        public DateTime? Dt_cadastro
        {
            get { return dt_cadastro; }
            set
            {
                dt_cadastro = value;
                dt_cadastrostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_cadastrostr;
        public string Dt_cadastrostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_cadastrostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_cadastrostr = value;
                try
                {
                    dt_cadastro = DateTime.Parse(value);
                }
                catch { dt_cadastro = null; }
            }
        }
        private DateTime? dt_renovacaocadastro;
        public DateTime? Dt_renovacaocadastro
        {
            get { return dt_renovacaocadastro; }
            set
            {
                dt_renovacaocadastro = value;
                dt_renovacaocadastrostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_renovacaocadastrostr;
        public string Dt_renovacaocadastrostr
        {
            get { return dt_renovacaocadastrostr; }
            set
            {
                dt_renovacaocadastrostr = value;
                try
                {
                    dt_renovacaocadastro = DateTime.Parse(value);
                }
                catch
                { dt_renovacaocadastro = null; }
            }
        }
        public decimal Dias_renovacaocadastro
        { get; set; }
        public DateTime Dt_atual
        { get; set; }
        public bool St_renovarcadastro
        {
            get
            {
                if (Dias_renovacaocadastro > decimal.Zero)
                    return dt_renovacaocadastro.Value.AddDays(Convert.ToDouble(Dias_renovacaocadastro)).Date < Dt_atual.Date;
                else
                    return false;
            }
        }
        public string Loginrenovacao
        { get; set; }
        public string Loginvendedor
        { get; set; }
        public string Cod_assim
        { get; set; }
        public string Ident_qualificacao
        { get; set; }
        public string Ident_frentista
        { get; set; }
        public string Renasem
        { get; set; }
        private decimal? id_categoriaclifor;
        public decimal? Id_categoriaclifor
        {
            get { return id_categoriaclifor; }
            set
            {
                id_categoriaclifor = value;
                id_categoriacliforstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_categoriacliforstr;
        public string Id_categoriacliforstr
        {
            get { return id_categoriacliforstr; }
            set
            {
                id_categoriacliforstr = value;
                try
                {
                    id_categoriaclifor = Convert.ToDecimal(value);
                }
                catch
                { id_categoriaclifor = null; }
            }
        }
        public string Ds_categoriaclifor
        { get; set; }
        private string st_avisarevolucaoos;
        public string St_avisarevolucaoos
        {
            get { return st_avisarevolucaoos; }
            set
            {
                st_avisarevolucaoos = value;
                st_avisarevolucaoosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_avisarevolucaoosbool;
        public bool St_avisarevolucaoosbool
        {
            get { return st_avisarevolucaoosbool; }
            set
            {
                st_avisarevolucaoosbool = value;
                st_avisarevolucaoos = value ? "S" : "N";
            }
        }
        public string Email
        { get; set; }
        public string Homepage
        { get; set; }
        private DateTime? dt_consultaspc;
        public DateTime? Dt_consultaSPC
        {
            get { return dt_consultaspc; }
            set
            {
                dt_consultaspc = value;
                dt_consultaspcstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_consultaspcstr;
        public string Dt_consultaSPCstr
        {
            get { return dt_consultaspcstr; }
            set
            {
                dt_consultaspcstr = value;
                try
                {
                    dt_consultaspc = DateTime.Parse(value);
                }
                catch
                { dt_consultaspc = null; }
            }
        }
        public string Ds_ConsultaSPC
        { get; set; }
        private string st_bloqueiospc;
        public string St_bloqueiospc
        {
            get { return st_bloqueiospc; }
            set
            {
                st_bloqueiospc = value;
                st_bloqueiospcbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_bloqueiospcbool;
        public bool St_bloqueiospcbool
        {
            get { return st_bloqueiospcbool; }
            set
            {
                st_bloqueiospcbool = value;
                st_bloqueiospc = value ? "S" : "N";
            }
        }

        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (Image)new ImageConverter().ConvertFrom(value);
            }
        }

        public string Ds_observacao
        { get; set; }
        public string Cd_historicorec
        { get; set; }
        public string Ds_historicorec
        { get; set; }
        public string Cd_historicopag
        { get; set; }
        public string Ds_historicopag
        { get; set; }
        public string Cod_suframa
        { get; set; }
        public decimal Tot_cotado
        { get; set; }
        public TList_CadEndereco lEndereco
        { get; set; }
        public TList_CadEndereco lEndDel
        { get; set; }
        public TList_CadDados_Bancarios_Clifor lDadosBanc
        { get; set; }
        public TList_CadDados_Bancarios_Clifor lDadosBancDel
        { get; set; }
        public TList_CadContatoCliFor lContato
        { get; set; }
        public TList_CadContatoCliFor lContatoDel
        { get; set; }
        public TList_CadReferenciaCliFor lReferencia
        { get; set; }
        public TList_CadReferenciaCliFor lReferenciaDel
        { get; set; }
        public TList_DataClifor lDataClifor
        { get; set; }
        public TList_DataClifor lDataCliforDel
        { get; set; }
        public TList_PessoasAutorizadas lPessoas
        { get; set; }
        public TList_AnexoClifor lAnexo
        { get; set; }
        public TList_AnexoClifor lAnexoDel
        { get; set; }
        public TList_Clifor_X_TabPreco lTabPreco
        { get; set; }
        public TList_Clifor_X_TabPreco lTabPrecoDel
        { get; set; }
        public TList_Clifor_X_CondPgto lConfPagto
        { get; set; }
        public TList_Clifor_X_CondPgto lConfPagtoDel
        { get; set; }
        public CamadaDados.Faturamento.Cadastros.TList_MetaVendedor lMeta
        { get; set; }
        public CamadaDados.Faturamento.PDV.TList_ResumoVendedor lResumoVendedor
        { get; set; }
        public string Cd_integracao { get; set; } = string.Empty;
        
        #region IClifor_PJ Members
        public string Nm_fantasia
        { get; set; }
        public string Nr_cgc
        { get; set; }
        public bool St_processar
        { get; set; }
        #endregion

        #region IClifor_PF Members
        public string Nr_cpf
        { get; set; }
        public decimal Vl_renda
        { get; set; }
        public string Nm_localtrabalho
        { get; set; }
        public string Nm_cargo
        { get; set; }
        public string Enderecotrab
        { get; set; }
        public string Fonetrab
        { get; set; }
        public string Dt_adm
        { get; set; }
        public string Nr_rg
        { get; set; }
        private string estadocivil;
        public string Estadocivil
        {
            get { return estadocivil; }
            set
            {
                estadocivil = value;
                if (value.Trim().Equals("0"))
                    estadocivilstr = "SOLTEIRO";
                else if (value.Trim().Equals("1"))
                    estadocivilstr = "CASADO";
                else if (value.Trim().Equals("2"))
                    estadocivilstr = "SEPARADO";
                else if (value.Trim().Equals("3"))
                    estadocivilstr = "DIVORCIADO";
                else if (value.Trim().Equals("4"))
                    estadocivilstr = "VIUVO";
            }
        }
        private string estadocivilstr;
        public string Estadocivilstr
        {
            get { return estadocivilstr; }
            set
            {
                estadocivilstr = value;
                if (value.Trim().ToUpper().Equals("SOLTEIRO"))
                    estadocivil = "0";
                else if (value.Trim().ToUpper().Equals("CASADO"))
                    estadocivil = "1";
                else if (value.Trim().ToUpper().Equals("SEPARADO"))
                    estadocivil = "2";
                else if (value.Trim().ToUpper().Equals("DIVORCIADO"))
                    estadocivil = "3";
                else if (value.Trim().ToUpper().Equals("VIUVO"))
                    estadocivil = "4";
            }
        }
        private string tp_residencia;
        public string Tp_residencia
        {
            get { return tp_residencia; }
            set
            {
                tp_residencia = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_residencia = "PROPRIA";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_residencia = "ALUGADA";
            }
        }
        private string tipo_residencia;
        public string Tipo_residencia
        {
            get { return tipo_residencia; }
            set
            {
                tipo_residencia = value;
                if (value.Trim().ToUpper().Equals("PROPRIA"))
                    tp_residencia = "P";
                else if (value.Trim().ToUpper().Equals("ALUGADA"))
                    tp_residencia = "A";
            }
        }
        public decimal Vl_aluguel
        { get; set; }
        private string st_veiculoproprio;
        public string St_veiculoproprio
        {
            get { return st_veiculoproprio; }
            set
            {
                st_veiculoproprio = value;
                st_veiculopropriobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_veiculopropriobool;
        public bool St_veiculopropriobool
        {
            get { return st_veiculopropriobool; }
            set
            {
                st_veiculopropriobool = value;
                st_veiculoproprio = value ? "S" : "N";
            }
        }
        public string Nm_conjuge
        { get; set; }
        public string Cpf_conjuge
        { get; set; }
        public string Rg_conjuge
        { get; set; }
        public string Orgaoesp
        { get; set; }
        public string Orgaoespconj
        { get; set; }
        private DateTime? dt_nascimento;
        public DateTime? Dt_nascimento
        {
            get
            { return dt_nascimento; }
            set
            {
                dt_nascimento = value;
                dt_nascimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_nascimentostr;
        public string Dt_nascimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_nascimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_nascimentostr = value;
                try
                {
                    dt_nascimento = Convert.ToDateTime(value);
                }
                catch
                { dt_nascimento = null; }
            }
        }
        private DateTime? dt_nascconjuge;
        public DateTime? Dt_nascconjuge
        {
            get
            {
                return dt_nascconjuge;
            }
            set
            {
                dt_nascconjuge = value;
                dt_nascconjugestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_nascconjugestr;
        public string Dt_nascconjugestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_nascconjugestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_nascconjugestr = value;
                try
                {
                    dt_nascconjuge = Convert.ToDateTime(value);
                }
                catch
                { dt_nascconjuge = null; }
            }
        }
        public string Nm_pai
        { get; set; }
        public string Nm_mae
        { get; set; }
        public string Ds_localTrabConj
        { get; set; }
        public string Nm_cargoConj
        { get; set; }
        public decimal Vl_rendaConj
        { get; set; }
        public string Emailconj
        { get; set; }
        private string st_envemailaniversario;
        public string St_envemailaniversario
        {
            get { return st_envemailaniversario; }
            set
            {
                st_envemailaniversario = value;
                st_envemailaniversariobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_envemailaniversariobool;
        public bool St_envemailaniversariobool
        {
            get { return st_envemailaniversariobool; }
            set
            {
                st_envemailaniversariobool = value;
                st_envemailaniversario = value ? "S" : "N";
            }
        }
        private string tp_sexo;
        public string Tp_sexo
        {
            get { return tp_sexo; }
            set
            {
                tp_sexo = value;
                if (value.Trim().ToUpper().Equals("M"))
                    tipo_sexo = "MASCULINO";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_sexo = "FEMININO";
            }
        }
        private string tipo_sexo;
        public string Tipo_sexo
        {
            get { return tipo_sexo; }
            set
            {
                tipo_sexo = value;
                if (value.Trim().ToUpper().Equals("MASCULINO"))
                    tp_sexo = "M";
                else if (value.Trim().ToUpper().Equals("FEMININO"))
                    tp_sexo = "F";
            }
        }
        #endregion

        #region IClifor_Funcionario Members
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_cargo;
        public decimal? Id_cargo
        {
            get
            { return id_cargo; }
            set
            {
                id_cargo = value;
                id_cargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargostr;
        public string Id_cargostr
        {
            get
            { return id_cargostr; }
            set
            {
                id_cargostr = value;
                try
                {
                    id_cargo = Convert.ToDecimal(value);
                }
                catch
                { id_cargo = null; }
            }
        }
        public string Ds_cargo
        { get; set; }
        public bool St_representante
        { get; set; }
        public bool St_vendedor
        { get; set; }
        public bool St_motorista
        { get; set; }
        public bool St_tecnico
        { get; set; }
        public bool St_frentista
        { get; set; }
        public bool St_operadorcx
        { get; set; }
        private DateTime? dt_admissao;
        public DateTime? Dt_admissao
        {
            get
            { return dt_admissao; }
            set
            {
                dt_admissao = value;
                dt_admissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_admissaostr;
        public string Dt_admissaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_admissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_admissaostr = value;
                try
                {
                    dt_admissao = Convert.ToDateTime(value);
                }
                catch
                { dt_admissao = null; }
            }
        }
        private DateTime? dt_demissao;
        public DateTime? Dt_demissao
        {
            get { return dt_demissao; }
            set
            {
                dt_demissao = value;
                dt_demissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_demissaostr;
        public string Dt_demissaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_demissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_demissaostr = value;
                try
                {
                    dt_demissao = Convert.ToDateTime(value);
                }
                catch
                { dt_demissao = null; }
            }
        }
        public decimal Vl_salario
        { get; set; }
        public bool St_gerarpagamento
        { get; set; }
        public string Nr_pis { get; set; } = string.Empty;
        public string Cd_cidadenasc { get; set; } = string.Empty;
        public string Ds_cidadenasc { get; set; } = string.Empty;
        public string Uf_nasc { get; set; } = string.Empty;
        private string st_funcativo;
        public string St_funcativo
        {
            get { return st_funcativo; }
            set
            {
                st_funcativo = value;
                st_funcativobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_funcativobool;
        public bool St_funcativobool
        {
            get { return st_funcativobool; }
            set
            {
                st_funcativobool = value;
                st_funcativo = value ? "S" : "N";
            }
        }
        #endregion

        #region IClifor_Motorista Members
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
        public string Placa
        { get; set; }
        public string cnh
        { get; set; }
        public string Categoria_cnh
        { get; set; }
        private DateTime? dt_vencimento_cnh;
        public DateTime? Dt_vencimento_cnh
        {
            get
            { return dt_vencimento_cnh; }
            set
            {
                dt_vencimento_cnh = value;
                dt_vencimento_cnhstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencimento_cnhstr;
        public string Dt_vencimento_cnhstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencimento_cnhstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimento_cnhstr = value;
                try
                {
                    dt_vencimento_cnh = Convert.ToDateTime(value);
                }
                catch
                { dt_vencimento_cnh = null; }
            }
        }
        private string st_ativomot;
        public string St_ativomot
        {
            get { return st_ativomot; }
            set
            {
                st_ativomot = value;
                st_ativomotbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_ativomotbool;
        public bool St_ativomotbool
        {
            get { return st_ativomotbool; }
            set
            {
                st_ativomotbool = value;
                st_ativomot = value ? "S" : "N";
            }
        }
        #endregion

        public TRegistro_CadClifor()
        {
            Cd_clifor = string.Empty;
            Cd_condfiscal_clifor = string.Empty;
            Cod_assim = string.Empty;
            Cpf_conjuge = string.Empty;
            Ds_condfiscal_clifor = string.Empty;
            Ds_ramoatividade = string.Empty;
            Cd_indicador = string.Empty;
            Nm_indicador = string.Empty;
            dt_nascconjuge = null;
            dt_nascconjugestr = string.Empty;
            dt_nascimento = null;
            dt_nascimentostr = string.Empty;
            Nm_pai = string.Empty;
            Nm_mae = string.Empty;
            Ds_localTrabConj = string.Empty;
            Vl_rendaConj = decimal.Zero;
            id_ramoatividade = null;
            id_ramoatividadestring = string.Empty;
            id_regiao = null;
            id_regiaostring = string.Empty;
            Ident_qualificacao = string.Empty;
            Ident_frentista = string.Empty;
            Nm_cargo = string.Empty;
            Nm_clifor = string.Empty;
            Nm_conjuge = string.Empty;
            Nm_fantasia = string.Empty;
            Nm_localtrabalho = string.Empty;
            Nm_regiao = string.Empty;
            Nr_cgc = string.Empty;
            Nr_cpf = string.Empty;
            Nr_rg = string.Empty;
            Orgaoesp = string.Empty;
            Orgaoespconj = string.Empty;
            Renasem = string.Empty;
            Rg_conjuge = string.Empty;
            st_agropecuaria = "N";
            st_agropecuariabool = false;
            st_bloq_debitovencido = "N";
            st_bloq_debitovencidobool = false;
            DiasCarenciaDebVencto = decimal.Zero;
            st_bloqcreditoavulso = "N";
            st_bloqcreditoavulsobool = false;
            Ds_motivobloqavulso = string.Empty;
            dt_renovacaocadastro = null;
            dt_renovacaocadastrostr = string.Empty;
            Dias_renovacaocadastro = decimal.Zero;
            Loginrenovacao = string.Empty;
            Loginvendedor = string.Empty;
            Dt_atual = DateTime.Now;
            st_equiparado_pj = "N";
            st_equiparado_pjbool = false;
            st_fornecedor = "N";
            st_fornecedorbool = false;
            st_registro = "A";
            st_registrobool = true;
            st_transportadora = "N";
            st_transportadorabool = false;
            St_funcionario = false;
            status = "ATIVO";
            tipo_pessoa = string.Empty;
            tp_pessoa = string.Empty;
            Vl_limitecredito = decimal.Zero;
            Vl_limitecredCH = decimal.Zero;
            Vl_salario = decimal.Zero;
            id_categoriaclifor = null;
            id_categoriacliforstr = string.Empty;
            Ds_categoriaclifor = string.Empty;
            st_avisarevolucaoos = "N";
            st_avisarevolucaoosbool = false;
            Email = string.Empty;
            Homepage = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_cargo = null;
            id_cargostr = string.Empty;
            Ds_cargo = string.Empty;
            St_representante = false;
            St_vendedor = false;
            St_motorista = false;
            St_tecnico = false;
            St_frentista = false;
            St_operadorcx = false;
            dt_admissao = null;
            dt_admissaostr = string.Empty;
            dt_demissao = null;
            dt_demissaostr = string.Empty;
            Vl_salario = decimal.Zero;
            st_funcativo = "S";
            st_funcativobool = true;
            St_gerarpagamento = false;
            id_veiculo = null;
            id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            cnh = string.Empty;
            Categoria_cnh = string.Empty;
            dt_vencimento_cnh = null;
            dt_vencimento_cnhstr = string.Empty;
            dt_consultaspc = null;
            dt_consultaspcstr = string.Empty;
            Ds_ConsultaSPC = string.Empty;
            st_bloqueiospc = "N";
            st_bloqueiospcbool = false;
            dt_cadastro = null;
            dt_cadastrostr = string.Empty;
            Emailconj = string.Empty;
            st_envemailaniversario = "N";
            st_envemailaniversariobool = false;
            Ds_observacao = string.Empty;
            St_processar = false;
            Cd_historicorec = string.Empty;
            Ds_historicorec = string.Empty;
            Cd_historicopag = string.Empty;
            Ds_historicopag = string.Empty;
            Id_estrangeiro = string.Empty;
            Enderecotrab = string.Empty;
            Fonetrab = string.Empty;
            Dt_adm = string.Empty;
            estadocivil = string.Empty;
            estadocivilstr = string.Empty;
            tp_residencia = string.Empty;
            tipo_residencia = string.Empty;
            Vl_aluguel = decimal.Zero;
            st_veiculoproprio = string.Empty;
            st_veiculopropriobool = false;
            Nm_cargoConj = string.Empty;
            Cod_suframa = string.Empty;
            Tot_cotado = decimal.Zero;
            img = null;
            imagem = null;
            lEndereco = new TList_CadEndereco();
            lEndDel = new TList_CadEndereco();
            lDadosBanc = new TList_CadDados_Bancarios_Clifor();
            lDadosBancDel = new TList_CadDados_Bancarios_Clifor();
            lContato = new TList_CadContatoCliFor();
            lContatoDel = new TList_CadContatoCliFor();
            lReferencia = new TList_CadReferenciaCliFor();
            lReferenciaDel = new TList_CadReferenciaCliFor();
            lDataClifor = new TList_DataClifor();
            lDataCliforDel = new TList_DataClifor();
            lPessoas = new TList_PessoasAutorizadas();
            lAnexo = new TList_AnexoClifor();
            lAnexoDel = new TList_AnexoClifor();
            lTabPreco = new TList_Clifor_X_TabPreco();
            lTabPrecoDel = new TList_Clifor_X_TabPreco();
            lConfPagto = new TList_Clifor_X_CondPgto();
            lConfPagtoDel = new TList_Clifor_X_CondPgto();
            lMeta = new CamadaDados.Faturamento.Cadastros.TList_MetaVendedor();
            lResumoVendedor = new CamadaDados.Faturamento.PDV.TList_ResumoVendedor();
        }
    }

    public class TCD_CadClifor : TDataQuery
    {
        public TCD_CadClifor()
        { }

        public TCD_CadClifor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_clifor, a.nm_clifor, a.id_regiao, b.nm_regiao, a.dt_cad, a.id_estrangeiro, a.cd_integracao, ");
                sql.AppendLine("a.tp_pessoa, a.st_transportadora, a.st_equiparado_pj, a.st_fornecedor, a.nm_pai, a.nm_mae, a.DS_LocalTrabConj, a.Vl_RendaConj, ");
                sql.AppendLine("a.vl_limitecredito, a.vl_limitecredCH, a.st_bloq_debitovencido, isnull(a.nr_cgc, a.nr_cpf) as NR_CGC_CPF, ");
                sql.AppendLine("a.cd_cidadenasc, h.ds_cidade as ds_cidadenasc, i.uf as uf_nasc, ");
                sql.AppendLine("a.st_agropecuaria, a.cd_condfiscal_clifor, c.ds_condfiscal, a.st_registro, a.cod_suframa, ");
                sql.AppendLine("a.ds_ramoatividade, a.nr_cgc, a.nm_fantasia, a.nr_cpf, a.vl_renda, a.dt_demissao, a.tp_sexo, ");
                sql.AppendLine("a.nm_localtrabalho, a.nm_cargo, a.nr_rg, a.nm_conjuge, a.cpf_conjuge, a.rg_conjuge, a.emailconj, a.st_envemailaniversario, ");
                sql.AppendLine("a.orgaoesp, a.orgaoespconj, a.dt_nascimento, a.dt_nascconjuge, a.email, a.homepage, ");
                sql.AppendLine("a.Id_CategoriaClifor, a.DS_CategoriaClifor, a.DT_ConsultaSPC, a.DS_ConsultaSPC, a.ST_BloqueioSPC, ");
                sql.AppendLine("a.id_ramoAtividade, a.DS_RamoAtividade, a.cd_indicador, g.nm_clifor as Nm_indicador, a.loginrenovacao, a.loginvendedor, ");
                sql.AppendLine("A.Cod_Assim, A.Ident_qualificacao, A.Ident_frentista, A.renasem, a.st_representante, ");
                sql.AppendLine("a.cd_empresa, emp.nm_empresa, a.id_cargo, a.ds_cargo, a.st_vendedor, a.st_motorista, a.st_tecnico, a.st_frentista, a.st_operadorcx, ");
                sql.AppendLine("a.dt_admissao, a.vl_salario, a.st_funcativo, a.Nr_pis, a.st_funcionarios, a.id_veiculo, d.ds_veiculo, d.placa, ");
                sql.AppendLine("a.cnh, a.categoria_cnh, a.dt_vencimento_cnh, a.st_ativomot, a.st_bloqcreditoavulso, a.ds_motivobloqavulso, ");
                sql.AppendLine("a.diascarenciadebvencto, a.dt_renovacaocadastro, a.diasrenovacaocadastro, dt_atual = getdate(), a.ds_observacao, ");
                sql.AppendLine("a.cd_historicorec, e.ds_historico as ds_historicorec, a.cd_historicopag, f.ds_historico as ds_historicopag, ");
                sql.AppendLine("a.enderecotrab, a.fonetrab, a.dt_adm, a.estadocivil, a.tp_residencia, a.vl_aluguel, a.st_veiculoproprio, a.nm_cargoconj ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_clifor a ");
            sql.AppendLine("left outer join tb_div_regiaovenda b ");
            sql.AppendLine("on a.id_regiao = b.id_regiao ");
            sql.AppendLine("left outer join tb_fis_condfiscal_clifor c ");
            sql.AppendLine("on a.cd_condfiscal_clifor = c.cd_condfiscal_clifor ");
            sql.AppendLine("left outer join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join tb_frt_veiculo d ");
            sql.AppendLine("on a.id_veiculo = d.id_veiculo ");
            sql.AppendLine("left outer join tb_fin_historico e ");
            sql.AppendLine("on a.cd_historicorec = e.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico f ");
            sql.AppendLine("on a.cd_historicopag = f.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Clifor g ");
            sql.AppendLine("on g.cd_clifor = a.cd_indicador ");
            sql.AppendLine("left outer join TB_FIN_Cidade h ");
            sql.AppendLine("on a.cd_cidadenasc = h.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF i ");
            sql.AppendLine("on h.cd_uf = i.cd_uf ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.nm_clifor, a.cd_clifor ");

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

        public TList_CadClifor Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadClifor lista = new TList_CadClifor();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadClifor reg = new TRegistro_CadClifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Regiao")))
                        reg.Id_regiao = reader.GetDecimal(reader.GetOrdinal("ID_Regiao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Regiao"))))
                        reg.Nm_regiao = reader.GetString(reader.GetOrdinal("NM_Regiao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Transportadora")))
                        reg.St_transportadora = reader.GetString(reader.GetOrdinal("ST_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Equiparado_PJ")))
                        reg.St_equiparado_pj = reader.GetString(reader.GetOrdinal("ST_Equiparado_PJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Fornecedor")))
                        reg.St_fornecedor = reader.GetString(reader.GetOrdinal("ST_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Agropecuaria")))
                        reg.St_agropecuaria = reader.GetString(reader.GetOrdinal("ST_Agropecuaria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal")))
                        reg.Ds_condfiscal_clifor = reader.GetString(reader.GetOrdinal("DS_CondFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CategoriaClifor")))
                        reg.Id_categoriaclifor = reader.GetDecimal(reader.GetOrdinal("ID_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CategoriaClifor")))
                        reg.Ds_categoriaclifor = reader.GetString(reader.GetOrdinal("DS_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitecredito")))
                        reg.Vl_limitecredito = reader.GetDecimal(reader.GetOrdinal("vl_limitecredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitecredCH")))
                        reg.Vl_limitecredCH = reader.GetDecimal(reader.GetOrdinal("vl_limitecredCH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_bloq_debitovencido")))
                        reg.St_bloq_debitovencido = reader.GetString(reader.GetOrdinal("st_bloq_debitovencido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_bloqcreditoavulso")))
                        reg.St_bloqcreditoavulso = reader.GetString(reader.GetOrdinal("st_bloqcreditoavulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivobloqavulso")))
                        reg.Ds_motivobloqavulso = reader.GetString(reader.GetOrdinal("ds_motivobloqavulso"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Cod_Assim")))
                        reg.Cod_assim = reader.GetString(reader.GetOrdinal("Cod_Assim"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Ident_qualificacao")))
                        reg.Ident_qualificacao = reader.GetString(reader.GetOrdinal("Ident_qualificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ident_frentista")))
                        reg.Ident_frentista = reader.GetString(reader.GetOrdinal("Ident_frentista"));
                    if(!reader.IsDBNull(reader.GetOrdinal("renasem")))
                        reg.Renasem = reader.GetString(reader.GetOrdinal("renasem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_RamoAtividade")))
                        reg.Id_ramoatividade = reader.GetDecimal(reader.GetOrdinal("ID_RamoAtividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_RamoAtividade")))
                        reg.Ds_ramoatividade = reader.GetString(reader.GetOrdinal("DS_RamoAtividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_indicador")))
                        reg.Cd_indicador = reader.GetString(reader.GetOrdinal("Cd_indicador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_indicador")))
                        reg.Nm_indicador = reader.GetString(reader.GetOrdinal("Nm_indicador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fantasia")))
                        reg.Nm_fantasia = reader.GetString(reader.GetOrdinal("NM_Fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Nr_cgc = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.Nr_cpf = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_renda")))
                        reg.Vl_renda = reader.GetDecimal(reader.GetOrdinal("Vl_renda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_LocalTrabalho")))
                        reg.Nm_localtrabalho = reader.GetString(reader.GetOrdinal("NM_LocalTrabalho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Cargo")))
                        reg.Nm_cargo = reader.GetString(reader.GetOrdinal("NM_Cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EnderecoTrab")))
                        reg.Enderecotrab = reader.GetString(reader.GetOrdinal("EnderecoTrab"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FoneTrab")))
                        reg.Fonetrab = reader.GetString(reader.GetOrdinal("FoneTrab"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Adm")))
                        reg.Dt_adm = reader.GetString(reader.GetOrdinal("DT_Adm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_RG")))
                        reg.Nr_rg = reader.GetString(reader.GetOrdinal("NR_RG"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EstadoCivil")))
                        reg.Estadocivil = reader.GetString(reader.GetOrdinal("EstadoCivil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Residencia")))
                        reg.Tp_residencia = reader.GetString(reader.GetOrdinal("TP_Residencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Aluguel")))
                        reg.Vl_aluguel = reader.GetDecimal(reader.GetOrdinal("Vl_Aluguel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_VeiculoProprio")))
                        reg.St_veiculoproprio = reader.GetString(reader.GetOrdinal("ST_VeiculoProprio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Conjuge")))
                        reg.Nm_conjuge = reader.GetString(reader.GetOrdinal("NM_Conjuge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CPF_Conjuge")))
                        reg.Cpf_conjuge = reader.GetString(reader.GetOrdinal("CPF_Conjuge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("RG_Conjuge")))
                        reg.Rg_conjuge = reader.GetString(reader.GetOrdinal("RG_Conjuge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("OrgaoEsp")))
                        reg.Orgaoesp = reader.GetString(reader.GetOrdinal("OrgaoEsp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("OrgaoEspConj")))
                        reg.Orgaoespconj = reader.GetString(reader.GetOrdinal("OrgaoEspConj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Nascimento")))
                        reg.Dt_nascimento = reader.GetDateTime(reader.GetOrdinal("DT_Nascimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_NascConjuge")))
                        reg.Dt_nascconjuge = reader.GetDateTime(reader.GetOrdinal("DT_NascConjuge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pai")))
                        reg.Nm_pai = reader.GetString(reader.GetOrdinal("nm_pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_mae")))
                        reg.Nm_mae = reader.GetString(reader.GetOrdinal("nm_mae"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LocalTrabConj")))
                        reg.Ds_localTrabConj = reader.GetString(reader.GetOrdinal("DS_LocalTrabConj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_CargoConj")))
                        reg.Nm_cargoConj = reader.GetString(reader.GetOrdinal("NM_CargoConj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_RendaConj")))
                        reg.Vl_rendaConj = reader.GetDecimal(reader.GetOrdinal("Vl_RendaConj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        reg.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HomePage")))
                        reg.Homepage = reader.GetString(reader.GetOrdinal("HomePage"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_ConsultaSPC")))
                        reg.Dt_consultaSPC = reader.GetDateTime(reader.GetOrdinal("DT_ConsultaSPC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ConsultaSPC")))
                        reg.Ds_ConsultaSPC = reader.GetString(reader.GetOrdinal("DS_ConsultaSPC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_BloqueioSPC")))
                        reg.St_bloqueiospcbool = reader.GetString(reader.GetOrdinal("ST_BloqueioSPC")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cargo")))
                        reg.Id_cargo = reader.GetDecimal(reader.GetOrdinal("ID_Cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cargo")))
                        reg.Ds_cargo = reader.GetString(reader.GetOrdinal("DS_Cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_representante")))
                        reg.St_representante = reader.GetString(reader.GetOrdinal("st_representante")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Vendedor")))
                        reg.St_vendedor = reader.GetString(reader.GetOrdinal("ST_Vendedor")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_motorista")))
                        reg.St_motorista = reader.GetString(reader.GetOrdinal("st_motorista")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tecnico")))
                        reg.St_tecnico = reader.GetString(reader.GetOrdinal("st_tecnico")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_frentista")))
                        reg.St_frentista = reader.GetString(reader.GetOrdinal("st_frentista")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_operadorcx")))
                        reg.St_operadorcx = reader.GetString(reader.GetOrdinal("st_operadorcx")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Admissao")))
                        reg.Dt_admissao = reader.GetDateTime(reader.GetOrdinal("DT_Admissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_demissao")))
                        reg.Dt_demissao = reader.GetDateTime(reader.GetOrdinal("dt_demissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Salario")))
                        reg.Vl_salario = reader.GetDecimal(reader.GetOrdinal("Vl_Salario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_FuncAtivo")))
                        reg.St_funcativo = reader.GetString(reader.GetOrdinal("ST_FuncAtivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_PIS")))
                        reg.Nr_pis = reader.GetString(reader.GetOrdinal("NR_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CidadeNasc")))
                        reg.Cd_cidadenasc = reader.GetString(reader.GetOrdinal("CD_CidadeNasc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CidadeNasc")))
                        reg.Ds_cidadenasc = reader.GetString(reader.GetOrdinal("DS_CidadeNasc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Nasc")))
                        reg.Uf_nasc = reader.GetString(reader.GetOrdinal("UF_Nasc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Funcionarios")))
                        reg.St_funcionario = reader.GetString(reader.GetOrdinal("ST_Funcionarios")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("diascarenciadebvencto")))
                        reg.DiasCarenciaDebVencto = reader.GetDecimal(reader.GetOrdinal("diascarenciadebvencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_renovacaocadastro")))
                        reg.Dt_renovacaocadastro = reader.GetDateTime(reader.GetOrdinal("dt_renovacaocadastro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasrenovacaocadastro")))
                        reg.Dias_renovacaocadastro = reader.GetDecimal(reader.GetOrdinal("diasrenovacaocadastro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_atual")))
                        reg.Dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnh")))
                        reg.cnh = reader.GetString(reader.GetOrdinal("cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("categoria_cnh")))
                        reg.Categoria_cnh = reader.GetString(reader.GetOrdinal("categoria_cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencimento_cnh")))
                        reg.Dt_vencimento_cnh = reader.GetDateTime(reader.GetOrdinal("dt_vencimento_cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_ativomot")))
                        reg.St_ativomot = reader.GetString(reader.GetOrdinal("st_ativomot"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginrenovacao")))
                        reg.Loginrenovacao = reader.GetString(reader.GetOrdinal("loginrenovacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginvendedor")))
                        reg.Loginvendedor = reader.GetString(reader.GetOrdinal("loginvendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cad")))
                        reg.Dt_cadastro = reader.GetDateTime(reader.GetOrdinal("dt_cad"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EmailConj")))
                        reg.Emailconj = reader.GetString(reader.GetOrdinal("EmailConj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EnvEmailAniversario")))
                        reg.St_envemailaniversario = reader.GetString(reader.GetOrdinal("ST_EnvEmailAniversario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_sexo")))
                        reg.Tp_sexo = reader.GetString(reader.GetOrdinal("tp_sexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicorec")))
                        reg.Cd_historicorec = reader.GetString(reader.GetOrdinal("cd_historicorec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicorec")))
                        reg.Ds_historicorec = reader.GetString(reader.GetOrdinal("ds_historicorec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicopag")))
                        reg.Cd_historicopag = reader.GetString(reader.GetOrdinal("cd_historicopag"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicopag")))
                        reg.Ds_historicopag = reader.GetString(reader.GetOrdinal("ds_historicopag"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_estrangeiro")))
                        reg.Id_estrangeiro = reader.GetString(reader.GetOrdinal("id_estrangeiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cod_suframa")))
                        reg.Cod_suframa = reader.GetString(reader.GetOrdinal("cod_suframa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_integracao")))
                        reg.Cd_integracao = reader.GetString(reader.GetOrdinal("cd_integracao"));

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

        public string Gravar(TRegistro_CadClifor val)
        {
            Hashtable hs = new Hashtable(78);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_REGIAO", val.Id_regiao);
            hs.Add("@P_TP_PESSOA", val.Tp_pessoa);
            hs.Add("@P_ST_EQUIPARADO_PJ", val.St_equiparado_pj);
            hs.Add("@P_ST_AGROPECUARIA", val.St_agropecuaria);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.Cd_condfiscal_clifor);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_CD_INDICADOR", val.Cd_indicador);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_categoriaclifor);
            hs.Add("@P_VL_LIMITECREDITO", val.Vl_limitecredito);
            hs.Add("@P_VL_LIMITECREDCH", val.Vl_limitecredCH);
            hs.Add("@P_ST_BLOQ_DEBITOVENCIDO", val.St_bloq_debitovencido);
            hs.Add("@P_ST_BLOQCREDITOAVULSO", val.St_bloqcreditoavulso);
            hs.Add("@P_DS_MOTIVOBLOQAVULSO", val.Ds_motivobloqavulso);
            hs.Add("@P_COD_ASSIM", val.Cod_assim);
            hs.Add("@P_IDENT_QUALIFICACAO", val.Ident_qualificacao);
            hs.Add("@P_IDENT_FRENTISTA", val.Ident_frentista);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_RENASEM", val.Renasem);
            hs.Add("@P_ST_AVISAREVOLUCAOOS", val.St_avisarevolucaoos);
            hs.Add("@P_EMAIL", val.Email);
            hs.Add("@P_HOMEPAGE", val.Homepage);
            hs.Add("@P_ID_RAMOATIVIDADE", val.Id_ramoatividade);
            hs.Add("@P_NM_FANTASIA", val.Nm_fantasia);
            hs.Add("@P_NR_CGC", val.Nr_cgc);
            hs.Add("@P_NR_CPF", val.Nr_cpf);
            hs.Add("@P_VL_RENDA", val.Vl_renda);
            hs.Add("@P_NM_LOCALTRABALHO", val.Nm_localtrabalho);
            hs.Add("@P_NM_CARGO", val.Nm_cargo);
            hs.Add("@P_ENDERECOTRAB", val.Enderecotrab);
            hs.Add("@P_FONETRAB", val.Fonetrab);
            hs.Add("@P_DT_ADM", val.Dt_adm);
            hs.Add("@P_NR_RG", val.Nr_rg);
            hs.Add("@P_ESTADOCIVIL", val.Estadocivil);
            hs.Add("@P_TP_RESIDENCIA", val.Tp_residencia);
            hs.Add("@P_VL_ALUGUEL", val.Vl_aluguel);
            hs.Add("@P_ST_VEICULOPROPRIO", val.St_veiculoproprio);
            hs.Add("@P_NM_CONJUGE", val.Nm_conjuge);
            hs.Add("@P_CPF_CONJUGE", val.Cpf_conjuge);
            hs.Add("@P_RG_CONJUGE", val.Rg_conjuge);
            hs.Add("@P_ORGAOESP", val.Orgaoesp);
            hs.Add("@P_ORGAOESPCONJ", val.Orgaoespconj);
            hs.Add("@P_DT_NASCIMENTO", val.Dt_nascimento);
            hs.Add("@P_DT_NASCCONJUGE", val.Dt_nascconjuge);
            hs.Add("@P_NM_PAI", val.Nm_pai);
            hs.Add("@P_NM_MAE", val.Nm_mae);
            hs.Add("@P_DS_LOCALTRABCONJ", val.Ds_localTrabConj);
            hs.Add("@P_NM_CARGOCONJ", val.Nm_cargoConj);
            hs.Add("@P_VL_RENDACONJ", val.Vl_rendaConj);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGO", val.Id_cargo);
            hs.Add("@P_DT_ADMISSAO", val.Dt_admissao);
            hs.Add("@P_DT_DEMISSAO", val.Dt_demissao);
            hs.Add("@P_VL_SALARIO", val.Vl_salario);
            hs.Add("@P_ST_FUNCATIVO", val.St_funcativo);
            hs.Add("@P_DIASCARENCIADEBVENCTO", val.DiasCarenciaDebVencto);
            hs.Add("@P_DT_RENOVACAOCADASTRO", val.Dt_renovacaocadastro);
            hs.Add("@P_DT_CONSULTASPC", val.Dt_consultaSPC);
            hs.Add("@P_DS_CONSULTASPC", val.Ds_ConsultaSPC);
            hs.Add("@P_ST_BLOQUEIOSPC", val.St_bloqueiospc);
            hs.Add("@P_LOGINRENOVACAO", val.Loginrenovacao);
            hs.Add("@P_LOGINVENDEDOR", val.Loginvendedor);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CNH", val.cnh);
            hs.Add("@P_CATEGORIA_CNH", val.Categoria_cnh);
            hs.Add("@P_DT_VENCIMENTO_CNH", val.Dt_vencimento_cnh);
            hs.Add("@P_ST_ATIVOMOT", val.St_ativomot);
            hs.Add("@P_EMAILCONJ", val.Emailconj);
            hs.Add("@P_ST_ENVEMAILANIVERSARIO", val.St_envemailaniversario);
            hs.Add("@P_TP_SEXO", val.Tp_sexo);
            hs.Add("@P_CD_HISTORICOREC", val.Cd_historicorec);
            hs.Add("@P_CD_HISTORICOPAG", val.Cd_historicopag);
            hs.Add("@P_ID_ESTRANGEIRO", val.Id_estrangeiro);
            hs.Add("@P_COD_SUFRAMA", val.Cod_suframa);
            hs.Add("@P_FOTO", val.Img);
            hs.Add("@P_CD_INTEGRACAO", val.Cd_integracao);
            hs.Add("@P_NR_PIS", val.Nr_pis);
            hs.Add("@P_CD_CIDADENASC", val.Cd_cidadenasc);
            
            return executarProc("IA_FIN_CLIFOR", hs);
        }

        public string Excluir(TRegistro_CadClifor val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);

            return executarProc("EXCLUI_FIN_CLIFOR", hs);
        }
    }
    #endregion

    #region Classe Aniversariante
    public class TList_Aniversariante : List<TRegistro_Aniversariante>, IComparer<TRegistro_Aniversariante>
    {
        #region IComparer<TRegistro_Aniversariante> Members
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

        public TList_Aniversariante()
        { }

        public TList_Aniversariante(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Aniversariante value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Aniversariante x, TRegistro_Aniversariante y)
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

    public class TRegistro_Aniversariante
    {
        public string Pessoa
        { get; set; }
        public string Nm_cliente
        { get; set; }
        public string Email
        { get; set; }
        public string Tp_registro
        { get; set; }
        public string Tipo_registro
        {
            get
            {
                if (Tp_registro.Trim().ToUpper().Equals("C"))
                    return "CLIENTE";
                else if (Tp_registro.Trim().ToUpper().Equals("J"))
                    return "CONJUGE";
                else if (Tp_registro.Trim().ToUpper().Equals("T"))
                    return "CONTATO";
                else return string.Empty;
            }
        }
        public decimal? Id_TpData
        { get; set; }
        public string Tipo_Data
        { get; set; }
        public bool St_enviaremail
        { get; set; }
        private string st_enviado;
        public string St_enviado
        {
            get { return st_enviado; }
            set
            {
                st_enviado = value;
                st_enviadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_enviadobool;
        public bool St_enviadobool
        {
            get { return st_enviadobool; }
            set
            {
                st_enviadobool = value;
                st_enviado = value ? "S" : "N";
            }
        }
        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_eventostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = Convert.ToDateTime(value);
                }
                catch
                { dt_evento = null; }
            }
        }

        public TRegistro_Aniversariante()
        {
            Pessoa = string.Empty;
            Nm_cliente = string.Empty;
            Email = string.Empty;
            Tp_registro = string.Empty;
            Id_TpData = null;
            Tipo_Data = string.Empty;
            St_enviaremail = false;
            St_enviado = "N";
            St_enviadobool = false;
            Dt_evento = null;
            Dt_eventostr = string.Empty;
        }
    }

    public class TCD_Aniversariante : TDataQuery
    {
        public TCD_Aniversariante() { }

        public TCD_Aniversariante(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, string Nr_dias)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Pessoa, a.Id_TpData, a.TP_DATA, a.NM_Clifor, a.Email, a.data, a.TP_Registro, a.st_enviado ");
            sql.AppendLine("from VTB_FIN_DATAEVENTOS a ");
            sql.AppendLine("where DATEDIFF(day, getdate(), DATEADD(YEAR, YEAR(getdate()) - YEAR(Data), Data)) between 0 and " + Nr_dias);
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public TList_Aniversariante Select(TpBusca[] vBusca, string Nr_dias)
        {
            bool podeFecharBco = false;
            TList_Aniversariante lista = new TList_Aniversariante();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Nr_dias));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Aniversariante reg = new TRegistro_Aniversariante();
                    if (!reader.IsDBNull(reader.GetOrdinal("Pessoa")))
                        reg.Pessoa = reader.GetString(reader.GetOrdinal("Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        reg.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Registro"))))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_TpData")))
                        reg.Id_TpData = reader.GetDecimal(reader.GetOrdinal("Id_TpData"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_DATA")))
                        reg.Tipo_Data = reader.GetString(reader.GetOrdinal("TP_DATA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_enviado"))))
                        reg.St_enviado = reader.GetString(reader.GetOrdinal("st_enviado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("data"))))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("data"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
    }

    public class TCD_BuscarEmail : TDataQuery
    {
        public TCD_BuscarEmail() { }

        public TCD_BuscarEmail(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.nm_contato, a.email ");
            sql.AppendLine("from VTB_FIN_EMAIL a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }
    }
    #endregion    

    #region Pessoas Autorizadas
    public class TList_PessoasAutorizadas : List<TRegistro_PessoasAutorizadas>, IComparer<TRegistro_PessoasAutorizadas>
    {
        #region IComparer<TRegistro_PessoasAutorizadas> Members
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

        public TList_PessoasAutorizadas()
        { }

        public TList_PessoasAutorizadas(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PessoasAutorizadas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PessoasAutorizadas x, TRegistro_PessoasAutorizadas y)
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
    
    public class TRegistro_PessoasAutorizadas
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
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
        public string Nr_cpf
        { get; set; }
        private string tp_relacionamento;
        public string Tp_relacionamento
        {
            get { return tp_relacionamento; }
            set
            {
                tp_relacionamento = value;
                if (value.Trim().ToUpper().Equals("PA"))
                    tipo_relacionamento = "PAI";
                else if (value.Trim().ToUpper().Equals("MA"))
                    tipo_relacionamento = "MÃE";
                else if (value.Trim().ToUpper().Equals("FL"))
                    tipo_relacionamento = "FILHO/FILHA";
                else if (value.Trim().ToUpper().Equals("NT"))
                    tipo_relacionamento = "NETO/NETA";
                else if (value.Trim().ToUpper().Equals("AV"))
                    tipo_relacionamento = "AVÔ/AVÓ";
                else if (value.Trim().ToUpper().Equals("PR"))
                    tipo_relacionamento = "PRIMO/PRIMA";
                else if (value.Trim().ToUpper().Equals("SB"))
                    tipo_relacionamento = "SOBRINHO/SOBRINHA";
                else if (value.Trim().ToUpper().Equals("TI"))
                    tipo_relacionamento = "TIO/TIA";
                else if (value.Trim().ToUpper().Equals("SG"))
                    tipo_relacionamento = "SOGRO/SOGRA";
                else if (value.Trim().ToUpper().Equals("CH"))
                    tipo_relacionamento = "CUNHADO/CUNHADA";
                else if (value.Trim().ToUpper().Equals("AM"))
                    tipo_relacionamento = "AMIGO/AMIGA";
                else if (value.Trim().ToUpper().Equals("VZ"))
                    tipo_relacionamento = "VIZINHO/VIZINHA";
                else if (value.Trim().ToUpper().Equals("OU"))
                    tipo_relacionamento = "OUTROS";
            }
        }
        private string tipo_relacionamento;
        public string Tipo_relaciomento
        {
            get { return tipo_relacionamento; }
            set
            {
                tipo_relacionamento = value;
                if (value.Trim().ToUpper().Equals("PAI"))
                    tp_relacionamento = "PA";
                else if (value.Trim().ToUpper().Equals("MÃE"))
                    tp_relacionamento = "MA";
                else if (value.Trim().ToUpper().Equals("FILHO/FILHA"))
                    tp_relacionamento = "FL";
                else if (value.Trim().ToUpper().Equals("NETO/NETA"))
                    tp_relacionamento = "NT";
                else if (value.Trim().ToUpper().Equals("AVÔ/AVÓ"))
                    tp_relacionamento = "AV";
                else if (value.Trim().ToUpper().Equals("PRIMO/PRIMA"))
                    tp_relacionamento = "PR";
                else if (value.Trim().ToUpper().Equals("SOBRINHO/SOBRINHA"))
                    tp_relacionamento = "SB";
                else if (value.Trim().ToUpper().Equals("TIO/TIA"))
                    tp_relacionamento = "TI";
                else if (value.Trim().ToUpper().Equals("SOGRO/SOGRA"))
                    tp_relacionamento = "SG";
                else if (value.Trim().ToUpper().Equals("CUNHADO/CUNHADA"))
                    tp_relacionamento = "CH";
                else if (value.Trim().ToUpper().Equals("AMIGO/AMIGA"))
                    tp_relacionamento = "AM";
                else if (value.Trim().ToUpper().Equals("VIZINHO/VIZINHA"))
                    tp_relacionamento = "VZ";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_relacionamento = "OU";
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
            }
        }
        public bool St_processar
        { get; set; }

        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (Image)new ImageConverter().ConvertFrom(value);
            }
        }
        private DateTime? dt_autorizacao;
        public DateTime? Dt_autorizacao
        {
            get { return dt_autorizacao; }
            set
            {
                dt_autorizacao = value;
                dt_autorizacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_autorizacaostr;
        public string Dt_autorizacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(Dt_autorizacaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_autorizacaostr = value;
                try
                {
                    dt_autorizacao = DateTime.Parse(value);
                }
                catch { dt_autorizacao = null; }
            }
        }

        public TRegistro_PessoasAutorizadas()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            id_pessoa = null;
            id_pessoastr = string.Empty;
            Nm_pessoa = string.Empty;
            Nr_cpf = string.Empty;
            tp_relacionamento = string.Empty;
            tipo_relacionamento = string.Empty;
            st_registro = "A";
            status = "ATIVO";
            Img = null;
            Imagem = null;
            St_processar = false;
            dt_autorizacaostr = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    public class TCD_PessoasAutorizadas : TDataQuery
    {
        public TCD_PessoasAutorizadas() { }

        public TCD_PessoasAutorizadas(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.dt_autorizacao, a.foto, a.cd_clifor, b.nm_clifor, a.id_pessoa, ");
                sql.AppendLine("a.nm_pessoa, a.nr_cpf, a.tp_relacionamento, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_pessoasautorizadas a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PessoasAutorizadas Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PessoasAutorizadas lista = new TList_PessoasAutorizadas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PessoasAutorizadas reg = new TRegistro_PessoasAutorizadas();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("ID_Pessoa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Pessoa"))))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("NM_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.Nr_cpf = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Relacionamento")))
                        reg.Tp_relacionamento = reader.GetString(reader.GetOrdinal("TP_Relacionamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Foto")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("Foto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_autorizacao")))
                        reg.Dt_autorizacao = reader.GetDateTime(reader.GetOrdinal("dt_autorizacao"));

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

        public string Gravar(TRegistro_PessoasAutorizadas val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);
            hs.Add("@P_NM_PESSOA", val.Nm_pessoa);
            hs.Add("@P_NR_CPF", val.Nr_cpf);
            hs.Add("@P_TP_RELACIONAMENTO", val.Tp_relacionamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_FOTO", val.Img);
            hs.Add("@P_DT_AUTORIZACAO", val.Dt_autorizacao);

            return executarProc("IA_FIN_PESSOASAUTORIZADAS", hs);
        }

        public string Excluir(TRegistro_PessoasAutorizadas val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);

            return executarProc("EXCLUI_FIN_PESSOASAUTORIZADAS", hs);
        }
    }
    #endregion

    #region Anexo Clifor
    public class TList_AnexoClifor : List<TRegistro_AnexoClifor>, IComparer<TRegistro_AnexoClifor>
    {
        #region IComparer<TRegistro_AnexoClifor> Members
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

        public TList_AnexoClifor()
        { }

        public TList_AnexoClifor(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AnexoClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AnexoClifor x, TRegistro_AnexoClifor y)
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

    public class TRegistro_AnexoClifor
    {
        public string Cd_clifor
        { get; set; }
        private decimal? id_anexo;

        public decimal? Id_anexo
        {
            get { return id_anexo; }
            set
            {
                id_anexo = value;
                id_anexostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_anexostr;

        public string Id_anexostr
        {
            get { return id_anexostr; }
            set
            {
                id_anexostr = value;
                try
                {
                    id_anexo = decimal.Parse(value);
                }
                catch
                { id_anexo = null; }
            }
        }

        public string Ds_anexo
        { get; set; }
        public string Ext_Anexo
        { get; set; }
        public byte[] Imagem_anexo
        { get; set; }

        public TRegistro_AnexoClifor()
        {
            Cd_clifor = string.Empty;
            id_anexo = null;
            id_anexostr = string.Empty;
            Ext_Anexo = string.Empty;
            Imagem_anexo = null;
            Ds_anexo = string.Empty;
        }
    }

    public class TCD_AnexoClifor : TDataQuery
    {
        public TCD_AnexoClifor()
        { }

        public TCD_AnexoClifor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.CD_Clifor, a.ID_Anexo, a.DS_Anexo, a.Ext_Anexo, a.IMG_Anexo");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FIN_AnexoClifor a");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AnexoClifor Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_AnexoClifor lista = new TList_AnexoClifor();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AnexoClifor reg = new TRegistro_AnexoClifor();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Anexo")))
                        reg.Id_anexo = reader.GetDecimal(reader.GetOrdinal("ID_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Anexo")))
                        reg.Ds_anexo = reader.GetString(reader.GetOrdinal("DS_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ext_Anexo")))
                        reg.Ext_Anexo = reader.GetString(reader.GetOrdinal("Ext_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("IMG_Anexo")))
                        reg.Imagem_anexo = (byte[])reader.GetValue(reader.GetOrdinal("IMG_Anexo"));
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

        public string Grava(TRegistro_AnexoClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);
            hs.Add("@P_DS_ANEXO", val.Ds_anexo);
            hs.Add("@P_EXT_ANEXO", val.Ext_Anexo);
            hs.Add("@P_IMG_ANEXO", val.Imagem_anexo);

            return executarProc("IA_FIN_ANEXOCLIFOR", hs);
        }

        public string Deleta(TRegistro_AnexoClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);

            return executarProc("EXCLUI_FIN_ANEXOCLIFOR", hs);
        }
    }
    #endregion

    #region Clifor X TabPreco
    public class TList_Clifor_X_TabPreco : List<TRegistro_Clifor_X_TabPreco> { }

    public class TRegistro_Clifor_X_TabPreco
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }

        public TRegistro_Clifor_X_TabPreco()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
        }
    }

    public class TCD_Clifor_X_TabPreco : TDataQuery
    {
        public TCD_Clifor_X_TabPreco() { }

        public TCD_Clifor_X_TabPreco(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.CD_Clifor, b.NM_Clifor, a.CD_TabelaPreco, c.DS_TabelaPreco ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Clifor_X_TabPreco a");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco c ");
            sql.AppendLine("on a.cd_tabelapreco = c.cd_tabelapreco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Clifor_X_TabPreco Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Clifor_X_TabPreco lista = new TList_Clifor_X_TabPreco();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Clifor_X_TabPreco reg = new TRegistro_Clifor_X_TabPreco();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));
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

        public string Gravar(TRegistro_Clifor_X_TabPreco val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);

            return executarProc("IA_FIN_CLIFOR_X_TABPRECO", hs);
        }

        public string Excluir(TRegistro_Clifor_X_TabPreco val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);

            return executarProc("EXCLUI_FIN_CLIFOR_X_TABPRECO", hs);
        }
    }
    #endregion

    #region Clifor X CondPagto
    public class TList_Clifor_X_CondPgto : List<TRegistro_Clifor_X_CondPgto> { }

    public class TRegistro_Clifor_X_CondPgto
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string CD_CondPGTO
        { get; set; }
        public string DS_CondPGTO
        { get; set; }

        public TRegistro_Clifor_X_CondPgto()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            CD_CondPGTO = string.Empty;
            DS_CondPGTO = string.Empty;
        }
    }

    public class TCD_Clifor_X_CondPgto : TDataQuery
    {
        public TCD_Clifor_X_CondPgto() { }

        public TCD_Clifor_X_CondPgto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.CD_Clifor, b.NM_Clifor, a.CD_CondPGTO, c.DS_CondPGTO ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Clifor_X_CondPgto a");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_CondPGTO c ");
            sql.AppendLine("on a.CD_CondPGTO = c.CD_CondPGTO ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Clifor_X_CondPgto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Clifor_X_CondPgto lista = new TList_Clifor_X_CondPgto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Clifor_X_CondPgto reg = new TRegistro_Clifor_X_CondPgto();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.CD_CondPGTO = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.DS_CondPGTO = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
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

        public string Gravar(TRegistro_Clifor_X_CondPgto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_CONDPGTO", val.CD_CondPGTO);

            return executarProc("IA_FIN_CLIFOR_X_CONDPGTO", hs);
        }

        public string Excluir(TRegistro_Clifor_X_CondPgto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_CONDPGTO", val.CD_CondPGTO);

            return executarProc("EXCLUI_FIN_CLIFOR_X_CONDPGTO", hs);
        }
    }
    #endregion
}
