using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using System.Drawing;

namespace CamadaDados.Diversos
{
    #region Empresa
    public class TList_CadEmpresa : List<TRegistro_CadEmpresa>, IComparer<TRegistro_CadEmpresa>
    {
        #region IComparer<TRegistro_CadEmpresa> Members
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

        public TList_CadEmpresa()
        { }

        public TList_CadEmpresa(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadEmpresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadEmpresa x, TRegistro_CadEmpresa y)
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

    public class TRegistro_CadEmpresa
    {
        private string cd_empresa;
        public string Cd_empresa { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Cd_empresa_matriz { get; set; }
        public string Nm_empresa_matriz { get; set; }
        public string Cd_clifor { get; set; }
        public string Nm_clifor { get; set; }
        public string Cd_endereco { get; set; }
        public string Ds_endereco { get; set; }
        public string Cd_clifor_contador { get; set; }
        public string Nm_clifor_contador { get; set; }
        public string Crc_contador { get; set; }
        public string SequencialCRC { get; set; }
        private DateTime? dt_validadeCRC;
        public DateTime? Dt_validadeCRC
        {
            get { return dt_validadeCRC; }
            set
            {
                dt_validadeCRC = value;
                dt_validadeCRCstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadeCRCstr;
        public string Dt_validadeCRCstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_validadeCRCstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_validadeCRCstr = value;
                try
                {
                    dt_validadeCRC = DateTime.Parse(value);
                }
                catch { dt_validadeCRC = null; }
            }
        }
        public string Cd_ufexpCRC
        { get; set; }
        public string Ds_ufexpCRC
        { get; set; }
        public string Sg_ufexpCRC
        { get; set; }
        public string Cpf_contador { get; set; }
        public string Cd_escritorio_contabil
        { get; set; }
        public string Nm_escritorio_contabil
        { get; set; }
        public string Cnpj_escritorio_contabil
        { get; set; }
        public string Nm_administrador { get; set; }
        public string Cpf_administrador { get; set; }
        public decimal? Cd_empresa_dominio
        { get; set; }
        public string Nm_empresa { get; set; }
        public string Cd_registroJunta { get; set; }
        private DateTime? dt_abertura;
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_aberturastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = DateTime.Parse(value);
                }
                catch { dt_abertura = null; }
            }
        }
        private Image logoempresa;
        public Image LogoEmpresa
        {
            get { return logoempresa; }
            set
            {
                logoempresa = value;
                if (logoempresa != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        logoempresa.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get{ return img; }
            set
            {
                img = value;
                if (value != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        ms.Write(value, 0, value.Length);
                        logoempresa = Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                    }
                }
                else
                    logoempresa = null;
            }
        }
        private string tp_regimetributario;
        public string Tp_regimetributario
        {
            get { return tp_regimetributario; }
            set
            {
                tp_regimetributario = value;
                if (value.Trim().Equals("1"))
                    tipo_regimetributario = "SIMPLES NACIONAL";
                else if (value.Trim().Equals("2"))
                    tipo_regimetributario = "SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA";
                else if (value.Trim().Equals("3"))
                    tipo_regimetributario = "REGIME NORMAL";
            }
        }
        private string tipo_regimetributario;
        public string Tipo_regimetributario
        {
            get{return tipo_regimetributario;}
            set
            {
                tipo_regimetributario = value;
                if (value.Trim().ToUpper().Equals("SIMPLES NACIONAL"))
                    tp_regimetributario = "1";
                else if (value.Trim().ToUpper().Equals("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA"))
                    tp_regimetributario = "2";
                else if (value.Trim().ToUpper().Equals("REGIME NORMAL"))
                    tp_regimetributario = "3";
            }
        }
        private string tp_basetributacaonormal;
        public string Tp_basetributacaonormal
        {
            get { return tp_basetributacaonormal; }
            set
            {
                tp_basetributacaonormal = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_basetributacaonormal = "LUCRO NORMAL";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_basetributacaonormal = "LUCRO PRESUMIDO";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_basetributacaonormal = "LUCRO ARBITRADO";
                else if (value.Trim().ToUpper().Equals("4"))
                    tipo_basetributacaonormal = "ESTIMATIVA MENSAL";
            }
        }
        private string tipo_basetributacaonormal;
        public string Tipo_basetributacaonormal
        {
            get { return tipo_basetributacaonormal; }
            set
            {
                tipo_basetributacaonormal = value;
                if (value.Trim().ToUpper().Equals("LUCRO NORMAL"))
                    tp_basetributacaonormal = "1";
                else if (value.Trim().ToUpper().Equals("LUCRO PRESUMIDO"))
                    tp_basetributacaonormal = "2";
                else if (value.Trim().ToUpper().Equals("LUCRO ARBITRADO"))
                    tp_basetributacaonormal = "3";
                else if (value.Trim().ToUpper().Equals("ESTIMATIVA MENSAL"))
                    tp_basetributacaonormal = "4";
            }
        }
        private string tp_empresasimples;
        public string Tp_empresasimples
        {
            get { return tp_empresasimples; }
            set
            {
                tp_empresasimples = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_empresasimples = "MICRO EMPRESA";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_empresasimples = "EMPRESA PEQUENO PORTE";
            }
        }
        private string tipo_empresasimples;
        public string Tipo_empresasimples
        {
            get { return tipo_empresasimples; }
            set
            {
                tipo_empresasimples = value;
                if (value.Trim().ToUpper().Equals("MICRO EMPRESA"))
                    tp_empresasimples = "1";
                else if (value.Trim().ToUpper().Equals("EMPRESA PEQUENO PORTE"))
                    tp_empresasimples = "2";
            }
        }
        public string Insc_estadual_subst
        { get; set; }
        public string Insc_municipal { get; set; }
        public string Cnae_fiscal
        { get; set; }
        public string Ds_cnae
        { get; set; }
        private string tp_regimetribmunicipal;
        public string Tp_regimetribmunicipal
        {
            get { return tp_regimetribmunicipal; }
            set
            {
                tp_regimetribmunicipal = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_regimetribmunicipal = "MICROEMPRESA MUNICIPAL";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_regimetribmunicipal = "ESTIMATIVA";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_regimetribmunicipal = "SOCIEDADE DE PROFISSIONAIS";
                else if (value.Trim().ToUpper().Equals("4"))
                    tipo_regimetribmunicipal = "COOPERATIVA";
                else if (value.Trim().ToUpper().Equals("5"))
                    tipo_regimetribmunicipal = "MICROEMPRESARIO INDIVIDUAL";
                else if (value.Trim().ToUpper().Equals("6"))
                    tipo_regimetribmunicipal = "MICROEMPRESARIO E EMPRESA DE PEQUENO PORTE";

            }
        }
        private string tipo_regimetribmunicipal;
        public string Tipo_regimetribmunicipal
        {
            get { return tipo_regimetribmunicipal; }
            set
            {
                tipo_regimetribmunicipal = value;
                if (value.Trim().ToUpper().Equals("MICROEMPRESA MUNICIPAL"))
                    tp_regimetribmunicipal = "1";
                else if (value.Trim().ToUpper().Equals("ESTIMATIVA"))
                    tp_regimetribmunicipal = "2";
                else if (value.Trim().ToUpper().Equals("SOCIEDADE DE PROFISSIONAIS"))
                    tp_regimetribmunicipal = "3";
                else if (value.Trim().ToUpper().Equals("COOPERATIVA"))
                    tp_regimetribmunicipal = "4";
                else if (value.Trim().ToUpper().Equals("MICROEMPRESARIO INDIVIDUAL"))
                    tp_regimetribmunicipal = "5";
                else if (value.Trim().ToUpper().Equals("MICROEMPRESARIO E EMPRESA DE PEQUENO PORTE"))
                    tp_regimetribmunicipal = "6";
            }
        }
        private string st_incentivadorcultural;
        public string St_incentivadorcultural
        {
            get { return st_incentivadorcultural; }
            set
            {
                st_incentivadorcultural = value;
                st_incentivadorculturalbool = value.Trim().ToUpper().Equals("S"); 
            }
        }
        private bool st_incentivadorculturalbool;
        public bool St_incentivadorculturalbool
        {
            get { return st_incentivadorculturalbool; }
            set
            {
                st_incentivadorculturalbool = value;
                st_incentivadorcultural = value ? "S" : "N";
            }
        }
        public string Tp_perfilfiscal
        { get; set; }
        public string Tipo_perfilfiscal
        {
            get
            {
                if (Tp_perfilfiscal.Trim().ToUpper().Equals("A"))
                    return "PERFIL A";
                else if (Tp_perfilfiscal.Trim().ToUpper().Equals("B"))
                    return "PERFIL B";
                else if (Tp_perfilfiscal.Trim().ToUpper().Equals("C"))
                    return "PERFIL C";
                else return string.Empty;
            }
        }
        public string Tp_atividadespedfiscal
        { get; set; }
        public string Tipo_atividadespedfiscal
        {
            get
            {
                if (Tp_atividadespedfiscal.Trim().ToUpper().Equals("0"))
                    return "INDUSTRIAL";
                else if (Tp_atividadespedfiscal.Trim().ToUpper().Equals("1"))
                    return "OUTROS";
                else return string.Empty;
            }
        }
        public string Tp_atividadespedpiscofins
        { get; set; }
        public string Tipo_atividadespedpiscofins
        {
            get
            {
                if (Tp_atividadespedpiscofins.Trim().Equals("0"))
                    return "INDUSTRIAL OU EQUIPARADO";
                else if (Tp_atividadespedpiscofins.Trim().Equals("1"))
                    return "PRESTADOR DE SERVIÇOS";
                else if (Tp_atividadespedpiscofins.Trim().Equals("2"))
                    return "ATIVIDADE DE COMERCIO";
                else if (Tp_atividadespedpiscofins.Trim().Equals("3"))
                    return "ATIVIDADE FINANCEIRA";
                else if (Tp_atividadespedpiscofins.Trim().Equals("4"))
                    return "ATIVIDADE IMOBILIARIA";
                else if (Tp_atividadespedpiscofins.Trim().Equals("9"))
                    return "OUTROS";
                else return string.Empty;
            }
        }
        public string Tp_naturezaPJ
        { get; set; }
        public string Tipo_naturezaPJ
        {
            get 
            {
                if (Tp_naturezaPJ.Trim().Equals("00"))
                    return "SOCIEDADE EMPRESARIAL";
                else if (Tp_naturezaPJ.Trim().Equals("01"))
                    return "SOCIEDADE COOPERATIVA";
                else if (Tp_naturezaPJ.Trim().Equals("02"))
                    return "ENTIDADE SUJEITA AO PIS COM BASE NA FOLHA DE PAGAMENTO";
                else return string.Empty;
            }
        }
        public string Tp_incidtributaria
        { get; set; }
        public string Tipo_incidtributaria
        {
            get
            {
                if (Tp_incidtributaria.Trim().Equals("1"))
                    return "NÃO CUMULATIVO";
                else if (Tp_incidtributaria.Trim().Equals("2"))
                    return "CUMULATIVO";
                else if (Tp_incidtributaria.Trim().Equals("3"))
                    return "NÃO CUMULATIVO E CUMULATIVO";
                else return string.Empty;
            }
        }
        public string Tp_apropcredito
        { get; set; }
        public string Tipo_apropcredito
        {
            get
            {
                if (Tp_apropcredito.Trim().Equals("1"))
                    return "APROPRIAÇÃO DIRETA";
                else if (Tp_apropcredito.Trim().Equals("2"))
                    return "RATEIO PROPORCIONAL";
                else return string.Empty;
            }
        }
        public string Tp_contribuicao
        { get; set; }
        public string Tipo_contribuicao
        {
            get
            {
                if (Tp_contribuicao.Trim().Equals("1"))
                    return "ALIQUOTA BASICA";
                else if (Tp_contribuicao.Trim().Equals("2"))
                    return "ALIQUOTA ESPECIFICA";
                else return string.Empty;
            }
        }
        public string Tp_regimecumulativo
        { get; set; }
        public string Tipo_regimecumulativo
        {
            get
            {
                if (Tp_regimecumulativo.Trim().Equals("1"))
                    return "REGIME CAIXA";
                else if (Tp_regimecumulativo.Trim().Equals("2"))
                    return "REGIME COMPETENCIA CONSOLIDADA";
                else if (Tp_regimecumulativo.Trim().Equals("3"))
                    return "REGIME COMPETENCIA DETALHADA";
                else return string.Empty;
            }
        }
        public string LayoutSpedFiscal
        { get; set; }
        public string LayoutSpedPisCofins
        { get; set; }
        private string tp_viscusto;
        public string Tp_viscusto
        {
            get { return tp_viscusto; }
            set
            {
                tp_viscusto = value;
                if (value.Trim().Equals("0"))
                    tipo_viscusto = "PREÇO MÉDIO";
                else if (value.Trim().Equals("1"))
                    tipo_viscusto = "ULTIMA COMPRA(UEPS)";
            }
        }
        private string tipo_viscusto;
        public string Tipo_viscusto
        {
            get { return tipo_viscusto; }
            set
            {
                if (value.Trim().ToUpper().Equals("PREÇO MÉDIO"))
                    tp_viscusto = "0";
                else if (value.Trim().ToUpper().Equals("ULTIMA COMPRA(UEPS)"))
                    tp_viscusto = "1";
            }
        }
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
        private decimal? id_aliquota;
        public decimal? Id_aliquota
        {
            get { return id_aliquota; }
            set
            {
                id_aliquota = value;
                id_aliquotastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_aliquotastr;
        public string Id_aliquotastr
        {
            get { return id_aliquotastr; }
            set
            {
                id_aliquotastr = value;
                try
                {
                    id_aliquota = decimal.Parse(value);
                }
                catch { id_aliquota = null; }
            }
        }
        public string Ds_aliquota
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public byte[] Modelo_OS
        { get; set; }
        public byte[] Modelo_Entrega
        { get; set; }
        public byte[] Modelo_Garantia
        { get; set; }
        public byte[] Modelo_Laudo
        { get; set; }
        public byte[] Modelo_Acompanhamento
        { get; set; }
        private string tp_instplanoref;
        public string Tp_instplanoref
        {
            get { return tp_instplanoref; }
            set
            {
                tp_instplanoref = value;
                if (value.Trim().Equals("1"))
                    tipo_instplanoref = "PJ EM GERAL";
                else if (value.Trim().Equals("2"))
                    tipo_instplanoref = "PJ EM GERAL - LUCRO PRESUMIDO";
                else if (value.Trim().Equals("3"))
                    tipo_instplanoref = "FINANCEIRAS";
                else if (value.Trim().Equals("4"))
                    tipo_instplanoref = "SEGURADORAS";
                else if (value.Trim().Equals("5"))
                    tipo_instplanoref = "IMUNES E ISENTAS EM GERAL";
                else if (value.Trim().Equals("6"))
                    tipo_instplanoref = "FINANCEIRAS - IMUNES E ISENTAS";
                else if (value.Trim().Equals("7"))
                    tipo_instplanoref = "SEGURADORAS - IMUNES E ISENTAS";
                else if (value.Trim().Equals("8"))
                    tipo_instplanoref = "ENTIDADES FECHADAS DE PREVIDENCIA COMPLEMENTAR";
                else if (value.Trim().Equals("9"))
                    tipo_instplanoref = "PARTIDOS POLITICOS";
            }
        }
        private string tipo_instplanoref;
        public string Tipo_instplanoref
        {
            get { return tipo_instplanoref; }
            set
            {
                tipo_instplanoref = value;
                if (value.Trim().ToUpper().Equals("PJ EM GERAL"))
                    tp_instplanoref = "1";
                else if (value.Trim().ToUpper().Equals("PJ EM GERAL - LUCRO PRESUMIDO"))
                    tp_instplanoref = "2";
                else if (value.Trim().ToUpper().Equals("FINANCEIRAS"))
                    tp_instplanoref = "3";
                else if (value.Trim().ToUpper().Equals("SEGURADORAS"))
                    tp_instplanoref = "4";
                else if (value.Trim().ToUpper().Equals("IMUNES E ISENTAS EM GERAL"))
                    tp_instplanoref = "5";
                else if (value.Trim().ToUpper().Equals("FINANCEIRAS - IMUNES E ISENTAS"))
                    tp_instplanoref = "6";
                else if (value.Trim().ToUpper().Equals("SEGURADORAS - IMUNES E ISENTAS"))
                    tp_instplanoref = "7";
                else if (value.Trim().ToUpper().Equals("ENTIDADES FECHADAS DE PREVIDENCIA COMPLEMENTAR"))
                    tp_instplanoref = "8";
                else if (value.Trim().ToUpper().Equals("PARTIDOS POLITICOS"))
                    tp_instplanoref = "9";
            }
        }
        private string tp_spedcontabil;
        public string Tp_spedcontabil
        {
            get { return tp_spedcontabil; }
            set
            {
                tp_spedcontabil = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_spedcontabil = "LIVRO DIARIO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_spedcontabil = "LIVRO DIARIO COM ESCRITURAÇÃO RESUMIDA";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_spedcontabil = "LIVRO DIARIO AUXILIAR AO DIARIO COM ESCRITURAÇÃO RESUMIDA";
                else if (value.Trim().ToUpper().Equals("B"))
                    tipo_spedcontabil = "BALANCETE DIARIOS E BALANÇOS";
                else if (value.Trim().ToUpper().Equals("Z"))
                    tipo_spedcontabil = "RAZÃO AUXILIAR";
            }
        }
        private string tipo_spedcontabil;
        public string Tipo_spedcontabil
        {
            get { return tipo_spedcontabil; }
            set
            {
                tipo_spedcontabil = value;
                if (value.Trim().ToUpper().Equals("LIVRO DIARIO"))
                    tp_spedcontabil = "G";
                else if (value.Trim().ToUpper().Equals("LIVRO DIARIO COM ESCRITURAÇÃO RESUMIDA"))
                    tp_spedcontabil = "R";
                else if (value.Trim().ToUpper().Equals("LIVRO DIARIO AUXILIAR AO DIARIO COM ESCRITURAÇÃO RESUMIDA"))
                    tp_spedcontabil = "A";
                else if (value.Trim().ToUpper().Equals("BALANCETE DIARIOS E BALANÇOS"))
                    tp_spedcontabil = "B";
                else if (value.Trim().ToUpper().Equals("RAZÃO AUXILIAR"))
                    tp_spedcontabil = "Z";
            }
        }
        public string Layoutspedcontabil
        { get; set; }
        public string St_registro { get; set; }
        public bool St_processar
        { get; set; }
        public TRegistro_CadClifor rClifor { get; set; }
        public TRegistro_CadEndereco rEndereco{ get; set; }
        public TList_SociosEmpresa lSocios { get; set; }
        public TList_SociosEmpresa lSociosDel { get; set; }
        public TList_InscSubstEmpresa lInsc { get; set; }
        public TList_InscSubstEmpresa lInscDel { get; set; }
        public TRegistro_CadEmpresa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_empresa_matriz = string.Empty;
            Nm_empresa_matriz = string.Empty;
            Crc_contador = string.Empty;
            Cpf_contador = string.Empty;
            SequencialCRC = string.Empty;
            dt_validadeCRC = null;
            dt_validadeCRCstr = string.Empty;
            Cd_ufexpCRC = string.Empty;
            Ds_ufexpCRC = string.Empty;
            Sg_ufexpCRC = string.Empty;
            Nm_administrador = string.Empty;
            Cpf_administrador = string.Empty;
            Cd_registroJunta = string.Empty;
            dt_abertura = null;
            dt_aberturastr = string.Empty;
            Insc_estadual_subst = string.Empty;
            Insc_municipal = string.Empty;
            St_registro = "A";
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            logoempresa = null;
            img = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_clifor_contador = string.Empty;
            Nm_clifor_contador = string.Empty;
            Cd_escritorio_contabil = string.Empty;
            Nm_escritorio_contabil = string.Empty;
            Cnpj_escritorio_contabil = string.Empty;
            tp_regimetributario = string.Empty;
            tipo_regimetributario = string.Empty;
            tp_basetributacaonormal = string.Empty;
            tipo_basetributacaonormal = string.Empty;
            tp_empresasimples = string.Empty;
            tipo_empresasimples = string.Empty;
            Cnae_fiscal = string.Empty;
            Ds_cnae = string.Empty;
            tp_regimetribmunicipal = string.Empty;
            tipo_regimetribmunicipal = string.Empty;
            st_incentivadorcultural = "N";
            st_incentivadorculturalbool = false;
            
            Tp_perfilfiscal = string.Empty;
            Tp_atividadespedfiscal = string.Empty;
            Tp_atividadespedpiscofins = string.Empty;
            Tp_naturezaPJ = string.Empty;
            Tp_incidtributaria = string.Empty;
            Tp_apropcredito = string.Empty;
            Tp_contribuicao = string.Empty;
            Tp_regimecumulativo = string.Empty;
            Cd_empresa_dominio = null;
            LayoutSpedFiscal = string.Empty;
            LayoutSpedPisCofins = string.Empty;
            St_processar = false;
            tp_viscusto = "0";
            tipo_viscusto = "PREÇO MÉDIO";
            id_tabela = null;
            id_tabelastr = string.Empty;
            Ds_tabela = string.Empty;
            id_aliquota = null;
            id_aliquotastr = string.Empty;
            Ds_aliquota = string.Empty;
            Pc_aliquota = decimal.Zero;
            Modelo_OS = null;
            Modelo_Entrega = null;
            Modelo_Garantia = null;
            Modelo_Laudo = null;
            Modelo_Acompanhamento = null;
            tp_instplanoref = string.Empty;
            tipo_instplanoref = string.Empty;
            tp_spedcontabil = string.Empty;
            tipo_spedcontabil = string.Empty;
            Layoutspedcontabil = string.Empty;
            rClifor = new TRegistro_CadClifor();
            rEndereco = new TRegistro_CadEndereco();
            lSocios = new TList_SociosEmpresa();
            lSociosDel = new TList_SociosEmpresa();
            lInsc = new TList_InscSubstEmpresa();
            lInscDel = new TList_InscSubstEmpresa();
        }
    }

    public class TCD_CadEmpresa : TDataQuery
    {
        public TCD_CadEmpresa()
        { }

        public TCD_CadEmpresa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.nm_empresa, a.crc_contador, a.cd_registroJunta, ");
                sql.AppendLine("a.sequencialCRC, a.dt_validadeCRC, a.cd_ufexpCRC, uf.ds_uf as ds_ufexpCRC, uf.uf as sg_ufexpCRC, ");
                sql.AppendLine("a.st_registro, a.cd_clifor_contador, a.insc_municipal, a.logoempresa, ");
                sql.AppendLine("e.nm_clifor as nm_clifor_contador, e.nr_cpf as cpf_contador,f.nm_empresa as nm_empresa_matriz, ");
                sql.AppendLine("a.cd_clifor, a.cd_endereco, a.cd_empresa_matriz, a.cnae_fiscal, a.ds_cnae, ");
                sql.AppendLine("a.tp_regimetributario, a.tp_basetributacaonormal, a.tp_viscusto, ");
                sql.AppendLine("a.tp_regimetribmunicipal, a.st_incentivadorcultural, a.dt_abertura, ");
                sql.AppendLine("a.tp_perfilfiscal, a.tp_atividadespedfiscal, a.cd_empresa_dominio, a.tp_empresasimples, ");
                sql.AppendLine("a.cd_escritorio_contabil, g.nm_clifor as nm_escritorio_contabil, g.nr_cgc as cnpj_escritorio_contabil, ");
                sql.AppendLine("a.tp_atividadespedpiscofins, a.tp_naturezaPJ, a.tp_incidtributaria, a.tp_apropcredito, ");
                sql.AppendLine("a.tp_contribuicao, a.tp_regimecumulativo, a.layoutspedfiscal, a.layoutspedpiscofins, ");
                sql.AppendLine("a.Modelo_OS, a.Modelo_Entrega, a.Modelo_Garantia, a.Modelo_Laudo, a.Modelo_Acompanhamento, ");
                sql.AppendLine("a.TP_InstPlanoRef, a.TP_SpedContabil, a.LayoutSpedContabil, ");
                //Cliente Empresa
                sql.AppendLine("b.nm_clifor, b.tp_pessoa, b.cd_condfiscal_clifor, b.nm_fantasia, b.nr_cgc, b.email, ");
                //Endereco Empresa
                sql.AppendLine("c.ds_endereco, c.cd_cidade, c.numero, c.bairro, c.proximo, c.cep, c.cp, c.fone, c.fone_comercial, ");
                sql.AppendLine("c.st_endentrega, c.st_endcobranca, c.celular, c.ds_complemento, c.ds_cidade, c.uf, c.cd_uf, ");
                sql.AppendLine("c.ds_uf, c.cd_pais, c.nm_pais, c.insc_estadual, ");
                sql.AppendLine("a.id_tabela, h.ds_tabela, a.id_aliquota, i.ds_aliquota, i.pc_aliquota, ");
                sql.AppendLine("nm_administrador = isnull((select top 1 y.nm_clifor ");
                sql.AppendLine("                    from tb_div_sociosempresa x ");
                sql.AppendLine("                    inner join tb_fin_clifor y ");
                sql.AppendLine("                    on x.cd_clifor = y.cd_clifor ");
                sql.AppendLine("                    where a.cd_empresa = x.cd_empresa ");
                sql.AppendLine("                    and isnull(x.st_responsavel, 'N') = 'S'), ''), ");
                sql.AppendLine("cpf_administrador = isnull((select top 1 y.nr_cpf ");
                sql.AppendLine("                    from tb_div_sociosempresa x ");
                sql.AppendLine("                    inner join tb_fin_clifor_pf y ");
                sql.AppendLine("                    on x.cd_clifor = y.cd_clifor ");
                sql.AppendLine("                    where a.cd_empresa = x.cd_empresa ");
                sql.AppendLine("                    and isnull(x.st_responsavel, 'N') = 'S'), '') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_EMPRESA a ");
            sql.AppendLine("inner join vtb_fin_clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = c.cd_endereco ");
            sql.AppendLine("left outer join vtb_fin_clifor e ");
            sql.AppendLine("on a.cd_clifor_contador = e.cd_clifor ");
            sql.AppendLine("left join tb_div_empresa f ");
            sql.AppendLine("on  f.cd_empresa = a.cd_empresa_matriz ");
            sql.AppendLine("left outer join vtb_fin_clifor g ");
            sql.AppendLine("on a.cd_escritorio_contabil = g.cd_clifor ");
            sql.AppendLine("left outer join tb_fis_tabsimples h ");
            sql.AppendLine("on a.id_tabela = h.id_tabela ");
            sql.AppendLine("left outer join tb_fis_aliquotasimples i ");
            sql.AppendLine("on a.id_tabela = i.id_tabela ");
            sql.AppendLine("and a.id_aliquota = i.id_aliquota ");
            sql.AppendLine("left outer join tb_fin_uf uf ");
            sql.AppendLine("on a.cd_ufexpcrc = uf.cd_uf ");

            sql.AppendLine("WHERE ISNULL(a.ST_REGISTRO, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
                
        public TList_CadEmpresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadEmpresa lista = new TList_CadEmpresa();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            { 
                while(reader.Read())
                {
                    TRegistro_CadEmpresa cadEmpresa = new TRegistro_CadEmpresa();
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        cadEmpresa.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        cadEmpresa.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("crc_contador")))
                        cadEmpresa.Crc_contador = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sequencialCRC")))
                        cadEmpresa.SequencialCRC = reader.GetString(reader.GetOrdinal("sequencialCRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_validadeCRC")))
                        cadEmpresa.Dt_validadeCRC = reader.GetDateTime(reader.GetOrdinal("dt_validadeCRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ufexpCRC")))
                        cadEmpresa.Cd_ufexpCRC = reader.GetString(reader.GetOrdinal("cd_ufexpCRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ufexpCRC")))
                        cadEmpresa.Ds_ufexpCRC = reader.GetString(reader.GetOrdinal("ds_ufexpCRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_ufexpCRC")))
                        cadEmpresa.Sg_ufexpCRC = reader.GetString(reader.GetOrdinal("sg_ufexpCRC"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_registroJunta")))
                        cadEmpresa.Cd_registroJunta = reader.GetString(reader.GetOrdinal("cd_registroJunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                        cadEmpresa.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                    if(!reader.IsDBNull(reader.GetOrdinal("insc_municipal")))
                        cadEmpresa.Insc_municipal = reader.GetString(reader.GetOrdinal("insc_municipal"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        cadEmpresa.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_clifor_contador")))
                        cadEmpresa.Cd_clifor_contador = reader.GetString(reader.GetOrdinal("cd_clifor_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_contador")))
                        cadEmpresa.Nm_clifor_contador = reader.GetString(reader.GetOrdinal("nm_clifor_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_contador")))
                        cadEmpresa.Cpf_contador = reader.GetString(reader.GetOrdinal("cpf_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_administrador")))
                        cadEmpresa.Nm_administrador = reader.GetString(reader.GetOrdinal("nm_administrador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_administrador")))
                        cadEmpresa.Cpf_administrador = reader.GetString(reader.GetOrdinal("cpf_administrador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_escritorio_contabil")))
                        cadEmpresa.Cd_escritorio_contabil = reader.GetString(reader.GetOrdinal("cd_escritorio_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_escritorio_contabil")))
                        cadEmpresa.Nm_escritorio_contabil = reader.GetString(reader.GetOrdinal("nm_escritorio_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_escritorio_contabil")))
                        cadEmpresa.Cnpj_escritorio_contabil = reader.GetString(reader.GetOrdinal("cnpj_escritorio_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_viscusto")))
                        cadEmpresa.Tp_viscusto = reader.GetString(reader.GetOrdinal("tp_viscusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tabela")))
                        cadEmpresa.Id_tabela = reader.GetDecimal(reader.GetOrdinal("id_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabela")))
                        cadEmpresa.Ds_tabela = reader.GetString(reader.GetOrdinal("ds_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_aliquota")))
                        cadEmpresa.Id_aliquota = reader.GetDecimal(reader.GetOrdinal("id_aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_aliquota")))
                        cadEmpresa.Ds_aliquota = reader.GetString(reader.GetOrdinal("ds_aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota")))
                        cadEmpresa.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("pc_aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo_OS")))
                        cadEmpresa.Modelo_OS = (byte[])reader.GetValue(reader.GetOrdinal("Modelo_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo_Entrega")))
                        cadEmpresa.Modelo_Entrega = (byte[])reader.GetValue(reader.GetOrdinal("Modelo_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo_Garantia")))
                        cadEmpresa.Modelo_Garantia = (byte[])reader.GetValue(reader.GetOrdinal("Modelo_Garantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo_Laudo")))
                        cadEmpresa.Modelo_Laudo = (byte[])reader.GetValue(reader.GetOrdinal("Modelo_Laudo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo_Acompanhamento")))
                        cadEmpresa.Modelo_Acompanhamento = (byte[])reader.GetValue(reader.GetOrdinal("Modelo_Acompanhamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_InstPlanoRef")))
                        cadEmpresa.Tp_instplanoref = reader.GetString(reader.GetOrdinal("TP_InstPlanoRef"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_SpedContabil")))
                        cadEmpresa.Tp_spedcontabil = reader.GetString(reader.GetOrdinal("TP_SpedContabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LayoutSpedContabil")))
                        cadEmpresa.Layoutspedcontabil = reader.GetString(reader.GetOrdinal("LayoutSpedContabil"));
                    //Dados Cliente Empresa

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                    {
                        cadEmpresa.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                        cadEmpresa.rClifor.Cd_clifor = cadEmpresa.Cd_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                    {
                        cadEmpresa.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                        cadEmpresa.rClifor.Nm_clifor = cadEmpresa.Nm_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fantasia")))
                        cadEmpresa.rClifor.Nm_fantasia = reader.GetString(reader.GetOrdinal("nm_fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        cadEmpresa.rClifor.Nr_cgc = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        cadEmpresa.rClifor.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_clifor")))
                        cadEmpresa.rClifor.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("cd_condfiscal_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        cadEmpresa.rClifor.Email = reader.GetString(reader.GetOrdinal("email"));
                    //Endereco Empresa
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                    {
                        cadEmpresa.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                        cadEmpresa.rEndereco.Cd_endereco = cadEmpresa.Cd_endereco;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                    {
                        cadEmpresa.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                        cadEmpresa.rEndereco.Ds_endereco = cadEmpresa.Ds_endereco;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                    {
                        cadEmpresa.rEndereco.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                        cadEmpresa.rEndereco.rCidade.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                    {
                        cadEmpresa.rEndereco.DS_Cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                        cadEmpresa.rEndereco.rCidade.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        cadEmpresa.rEndereco.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        cadEmpresa.rEndereco.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo")))
                        cadEmpresa.rEndereco.Proximo = reader.GetString(reader.GetOrdinal("proximo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        cadEmpresa.rEndereco.Cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cp")))
                        cadEmpresa.rEndereco.Cp = reader.GetString(reader.GetOrdinal("cp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        cadEmpresa.rEndereco.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_endentrega")))
                        cadEmpresa.rEndereco.St_enderecoentrega = reader.GetString(reader.GetOrdinal("st_endentrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_endcobranca")))
                        cadEmpresa.rEndereco.St_endcobranca = reader.GetString(reader.GetOrdinal("st_endcobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        cadEmpresa.rEndereco.Celular = reader.GetString(reader.GetOrdinal("celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_comercial")))
                        cadEmpresa.rEndereco.Fone_comercial = reader.GetString(reader.GetOrdinal("fone_comercial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        cadEmpresa.rEndereco.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        cadEmpresa.rEndereco.DS_Cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                    {
                        cadEmpresa.rEndereco.UF = reader.GetString(reader.GetOrdinal("uf"));
                        cadEmpresa.rEndereco.rCidade.rUf.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                    {
                        cadEmpresa.rEndereco.Cd_uf = reader.GetString(reader.GetOrdinal("cd_uf"));
                        cadEmpresa.rEndereco.rCidade.rUf.Cd_uf = reader.GetString(reader.GetOrdinal("cd_uf"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_uf")))
                    {
                        cadEmpresa.rEndereco.DS_Estado = reader.GetString(reader.GetOrdinal("ds_uf"));
                        cadEmpresa.rEndereco.rCidade.rUf.Ds_uf = reader.GetString(reader.GetOrdinal("ds_uf"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_pais")))
                        cadEmpresa.rEndereco.CD_Pais = reader.GetString(reader.GetOrdinal("cd_pais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pais")))
                        cadEmpresa.rEndereco.NM_Pais = reader.GetString(reader.GetOrdinal("nm_pais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        cadEmpresa.rEndereco.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_matriz")))
                        cadEmpresa.Cd_empresa_matriz = reader.GetString(reader.GetOrdinal("cd_empresa_matriz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa_matriz")))
                        cadEmpresa.Nm_empresa_matriz = reader.GetString(reader.GetOrdinal("nm_empresa_matriz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logoempresa")))
                        cadEmpresa.Img = (byte[])reader.GetValue(reader.GetOrdinal("logoempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetributario")))
                        cadEmpresa.Tp_regimetributario = reader.GetString(reader.GetOrdinal("tp_regimetributario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_basetributacaonormal")))
                        cadEmpresa.Tp_basetributacaonormal = reader.GetString(reader.GetOrdinal("tp_basetributacaonormal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_empresasimples")))
                        cadEmpresa.Tp_empresasimples = reader.GetString(reader.GetOrdinal("tp_empresasimples"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnae_fiscal")))
                        cadEmpresa.Cnae_fiscal = reader.GetString(reader.GetOrdinal("cnae_fiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cnae")))
                        cadEmpresa.Ds_cnae = reader.GetString(reader.GetOrdinal("ds_cnae"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetribmunicipal")))
                        cadEmpresa.Tp_regimetribmunicipal = reader.GetString(reader.GetOrdinal("tp_regimetribmunicipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_incentivadorcultural")))
                        cadEmpresa.St_incentivadorcultural = reader.GetString(reader.GetOrdinal("st_incentivadorcultural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Perfilfiscal")))
                        cadEmpresa.Tp_perfilfiscal = reader.GetString(reader.GetOrdinal("TP_PerfilFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Atividadespedfiscal")))
                        cadEmpresa.Tp_atividadespedfiscal = reader.GetString(reader.GetOrdinal("TP_AtividadespedFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_atividadespedpiscofins")))
                        cadEmpresa.Tp_atividadespedpiscofins = reader.GetString(reader.GetOrdinal("tp_atividadespedpiscofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_naturezaPJ")))
                        cadEmpresa.Tp_naturezaPJ = reader.GetString(reader.GetOrdinal("tp_naturezaPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_incidtributaria")))
                        cadEmpresa.Tp_incidtributaria = reader.GetString(reader.GetOrdinal("tp_incidtributaria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_apropcredito")))
                        cadEmpresa.Tp_apropcredito = reader.GetString(reader.GetOrdinal("tp_apropcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_contribuicao")))
                        cadEmpresa.Tp_contribuicao = reader.GetString(reader.GetOrdinal("tp_contribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimecumulativo")))
                        cadEmpresa.Tp_regimecumulativo = reader.GetString(reader.GetOrdinal("tp_regimecumulativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dominio")))
                        cadEmpresa.Cd_empresa_dominio = reader.GetDecimal(reader.GetOrdinal("cd_empresa_dominio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LayoutSpedFiscal")))
                        cadEmpresa.LayoutSpedFiscal = reader.GetString(reader.GetOrdinal("LayoutSpedFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LayoutSpedPisCofins")))
                        cadEmpresa.LayoutSpedPisCofins = reader.GetString(reader.GetOrdinal("LayoutSpedPisCofins"));

                    lista.Add(cadEmpresa);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if(podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadEmpresa val)
        {
            Hashtable hs = new Hashtable(46);

            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_EMPRESA_MATRIZ", val.Cd_empresa_matriz);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_CLIFOR_CONTADOR", val.Cd_clifor_contador);
            hs.Add("@P_CD_ESCRITORIO_CONTABIL", val.Cd_escritorio_contabil);
            hs.Add("@P_CRC_CONTADOR", val.Crc_contador);
            hs.Add("@P_SEQUENCIALCRC", val.SequencialCRC);
            hs.Add("@P_DT_VALIDADECRC", val.Dt_validadeCRC);
            hs.Add("@P_CD_UFEXPCRC", val.Cd_ufexpCRC);
            hs.Add("@P_CD_EMPRESA_DOMINIO", val.Cd_empresa_dominio);
            hs.Add("@P_NM_EMPRESA", val.Nm_empresa);
            hs.Add("@P_CD_REGISTROJUNTA", val.Cd_registroJunta);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_LOGOEMPRESA", val.Img);
            hs.Add("@P_TP_REGIMETRIBUTARIO", val.Tp_regimetributario);
            hs.Add("@P_TP_BASETRIBUTACAONORMAL", val.Tp_basetributacaonormal);
            hs.Add("@P_TP_EMPRESASIMPLES", val.Tp_empresasimples);
            hs.Add("@P_INSC_MUNICIPAL", val.Insc_municipal);
            hs.Add("@P_CNAE_FISCAL", val.Cnae_fiscal);
            hs.Add("@P_DS_CNAE", val.Ds_cnae);
            hs.Add("@P_TP_REGIMETRIBMUNICIPAL", val.Tp_regimetribmunicipal);
            hs.Add("@P_ST_INCENTIVADORCULTURAL", val.St_incentivadorcultural);
            hs.Add("@P_TP_PERFILFISCAL", val.Tp_perfilfiscal);
            hs.Add("@P_TP_ATIVIDADESPEDFISCAL", val.Tp_atividadespedfiscal);
            hs.Add("@P_TP_ATIVIDADESPEDPISCOFINS", val.Tp_atividadespedpiscofins);
            hs.Add("@P_TP_NATUREZAPJ", val.Tp_naturezaPJ);
            hs.Add("@P_TP_INCIDTRIBUTARIA", val.Tp_incidtributaria);
            hs.Add("@P_TP_APROPCREDITO", val.Tp_apropcredito);
            hs.Add("@P_TP_CONTRIBUICAO", val.Tp_contribuicao);
            hs.Add("@P_TP_REGIMECUMULATIVO", val.Tp_regimecumulativo);
            hs.Add("@P_LAYOUTSPEDFISCAL", val.LayoutSpedFiscal);
            hs.Add("@P_LAYOUTSPEDPISCOFINS", val.LayoutSpedPisCofins);
            hs.Add("@P_TP_VISCUSTO", val.Tp_viscusto);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_ID_ALIQUOTA", val.Id_aliquota);
            hs.Add("@P_MODELO_OS", val.Modelo_OS);
            hs.Add("@P_MODELO_ENTREGA", val.Modelo_Entrega);
            hs.Add("@P_MODELO_GARANTIA", val.Modelo_Garantia);
            hs.Add("@P_MODELO_LAUDO", val.Modelo_Laudo);
            hs.Add("@P_MODELO_ACOMPANHAMENTO", val.Modelo_Acompanhamento);
            hs.Add("@P_TP_INSTPLANOREF", val.Tp_instplanoref);
            hs.Add("@P_TP_SPEDCONTABIL", val.Tp_spedcontabil);
            hs.Add("@P_LAYOUTSPEDCONTABIL", val.Layoutspedcontabil);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            
            return executarProc("IA_DIV_EMPRESA", hs);

        }

        public string Excluir(TRegistro_CadEmpresa val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_DIV_EMPRESA", hs);
        }
    }
    #endregion

    #region Socios Empresa
    public class TList_SociosEmpresa : List<TRegistro_SociosEmpresa>, IComparer<TRegistro_SociosEmpresa>
    {
        #region IComparer<TRegistro_SociosEmpresa> Members
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

        public TList_SociosEmpresa()
        { }

        public TList_SociosEmpresa(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_SociosEmpresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_SociosEmpresa x, TRegistro_SociosEmpresa y)
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

    
    public class TRegistro_SociosEmpresa
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }

        public string Cpf_clifor
        { get; set; }
        
        public string Ds_funcao
        { get; set; }
        private DateTime? dt_inclusao;
        
        public DateTime? Dt_inclusao
        {
            get { return dt_inclusao; }
            set
            {
                dt_inclusao = value;
                dt_inclusaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inclusaostr;
        
        public string Dt_inclusaostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_inclusaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inclusaostr = value;
                try
                {
                    dt_inclusao = DateTime.Parse(value);
                }
                catch { dt_inclusao = null; }
            }
        }
        private DateTime? dt_saida;
        
        public DateTime? Dt_saida
        {
            get { return dt_saida; }
            set
            {
                dt_saida = value;
                dt_saidastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_saidastr;
        
        public string Dt_saidastr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_saidastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_saidastr = value;
                try
                {
                    dt_saida = DateTime.Parse(value);
                }
                catch { dt_saida = null; }
            }
        }
        
        public decimal Pc_participacao
        { get; set; }
        private string st_responsavel;
        
        public string St_responsavel
        {
            get { return st_responsavel; }
            set
            {
                st_responsavel = value;
                st_responsavelbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_responsavelbool;
        
        public bool St_responsavelbool
        {
            get { return st_responsavelbool; }
            set
            {
                st_responsavelbool = value;
                st_responsavel = value ? "S" : "N";
            }
        }

        public TRegistro_SociosEmpresa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cpf_clifor = string.Empty;
            Ds_funcao = string.Empty;
            dt_inclusao = null;
            dt_inclusaostr = string.Empty;
            dt_saida = null;
            dt_saidastr = string.Empty;
            Pc_participacao = decimal.Zero;
            st_responsavel = "N";
            st_responsavelbool = false;
        }
    }

    public class TCD_SociosEmpresa : TDataQuery
    {
        public TCD_SociosEmpresa()
        { }

        public TCD_SociosEmpresa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.cd_empresa, b.nm_empresa, a.cd_clifor, ");
                sql.AppendLine("c.nm_clifor, c.nr_cpf, a.ds_funcao, a.dt_inclusao, a.dt_saida, ");
                sql.AppendLine("a.pc_participacao, a.st_responsavel ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_SociosEmpresa a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_SociosEmpresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_SociosEmpresa lista = new TList_SociosEmpresa();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SociosEmpresa cadEmpresa = new TRegistro_SociosEmpresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        cadEmpresa.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        cadEmpresa.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        cadEmpresa.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        cadEmpresa.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        cadEmpresa.Cpf_clifor = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_funcao")))
                        cadEmpresa.Ds_funcao = reader.GetString(reader.GetOrdinal("ds_funcao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_inclusao")))
                        cadEmpresa.Dt_inclusao = reader.GetDateTime(reader.GetOrdinal("dt_inclusao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_saida")))
                        cadEmpresa.Dt_saida = reader.GetDateTime(reader.GetOrdinal("dt_saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_participacao")))
                        cadEmpresa.Pc_participacao = reader.GetDecimal(reader.GetOrdinal("pc_participacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_responsavel")))
                        cadEmpresa.St_responsavel = reader.GetString(reader.GetOrdinal("st_responsavel"));

                    lista.Add(cadEmpresa);
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

        public string Gravar(TRegistro_SociosEmpresa val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_DS_FUNCAO", val.Ds_funcao);
            hs.Add("@P_DT_INCLUSAO", val.Dt_inclusao);
            hs.Add("@P_DT_SAIDA", val.Dt_saida);
            hs.Add("@P_PC_PARTICIPACAO", val.Pc_participacao);
            hs.Add("@P_ST_RESPONSAVEL", val.St_responsavel);

            return executarProc("IA_DIV_SOCIOSEMPRESA", hs);
        }

        public string Excluir(TRegistro_SociosEmpresa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);

            return executarProc("EXCLUI_DIV_SOCIOSEMPRESA", hs);
        }
    }
    #endregion

    #region Insc Subst Empresa
    public class TList_InscSubstEmpresa : List<TRegistro_InscSubstEmpresa>, IComparer<TRegistro_InscSubstEmpresa>
    {
        #region IComparer<TRegistro_InscSubstEmpresa> Members
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

        public TList_InscSubstEmpresa()
        { }

        public TList_InscSubstEmpresa(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_InscSubstEmpresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_InscSubstEmpresa x, TRegistro_InscSubstEmpresa y)
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

    
    public class TRegistro_InscSubstEmpresa
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_uf
        { get; set; }
        
        public string Ds_uf
        { get; set; }
        
        public string Uf
        { get; set; }
        
        public string Insc_estadual_subst
        { get; set; }

        public TRegistro_InscSubstEmpresa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_uf = string.Empty;
            Ds_uf = string.Empty;
            Uf = string.Empty;
            Insc_estadual_subst = string.Empty;
        }
    }

    public class TCD_InscSubstEmpresa : TDataQuery
    {
        public TCD_InscSubstEmpresa() { }

        public TCD_InscSubstEmpresa(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cd_uf, c.ds_uf, c.uf, a.insc_estadual_subst ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_InscSubstEmpresa a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fin_uf c ");
            sql.AppendLine("on a.cd_uf = c.cd_uf ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_InscSubstEmpresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_InscSubstEmpresa lista = new TList_InscSubstEmpresa();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_InscSubstEmpresa cadEmpresa = new TRegistro_InscSubstEmpresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        cadEmpresa.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        cadEmpresa.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        cadEmpresa.Cd_uf = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_uf")))
                        cadEmpresa.Ds_uf = reader.GetString(reader.GetOrdinal("ds_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        cadEmpresa.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_subst")))
                        cadEmpresa.Insc_estadual_subst = reader.GetString(reader.GetOrdinal("insc_estadual_subst"));

                    lista.Add(cadEmpresa);
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

        public string Gravar(TRegistro_InscSubstEmpresa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_UF", val.Cd_uf);
            hs.Add("@P_INSC_ESTADUAL_SUBST", val.Insc_estadual_subst);

            return executarProc("IA_DIV_INSCSUBSTEMPRESA", hs);
        }

        public string Excluir(TRegistro_InscSubstEmpresa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_UF", val.Cd_uf);

            return executarProc("EXCLUI_DIV_INSCSUBSTEMPRESA", hs);
        }
    }
    #endregion
}
