using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using BancoDados;

namespace CamadaDados.Estoque.Cadastros
{
    #region Produto PDV
    
    public class TRegistro_ProdutoPDV
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Cd_codbarra
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal CasasDecimais { get; set; } = decimal.Zero;
        public decimal Vl_precovenda
        { get; set; }
        public decimal Pc_aliquotaicms
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

        public TRegistro_ProdutoPDV()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Cd_grupo = string.Empty;
            Cd_codbarra = string.Empty;
            Cd_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Vl_precovenda = decimal.Zero;
            Pc_aliquotaicms = decimal.Zero;
            imagem = null;
            img = null;
        }
    }
    public class TList_ProdutoLocacao : List<TRegistro_ProdutoLocacao>, IComparer<TRegistro_ProdutoLocacao>
    {
        #region IComparer<TRegistro_ProdutoLocacao> Members
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

        public TList_ProdutoLocacao()
        { }

        public TList_ProdutoLocacao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProdutoLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProdutoLocacao x, TRegistro_ProdutoLocacao y)
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
    public class TRegistro_ProdutoLocacao
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Ds_tecnica
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_codbarra
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal CasasDecimais { get; set; } = decimal.Zero;
        public decimal Quantidade
        { get; set; }
        public string Nr_Patrimonio
        { get; set; }
        public decimal Qtd_horas
        { get; set; }
        public decimal Vl_compra
        { get; set; }
        private DateTime? dt_compra;

        public DateTime? Dt_compra
        {
            get { return dt_compra; }
            set
            {
                dt_compra = value;
                dt_comprastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_comprastr;
        public string Dt_comprastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_comprastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_comprastr = value;
                try
                {
                    dt_compra = Convert.ToDateTime(value);
                }
                catch
                { dt_compra = null; }
            }
        }
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
        public decimal vl_unitario { get; set; }
        public string Vl_hora { get; set; }
        public string Vl_dia { get; set; }
        public string Vl_semana { get; set; }
        public string Vl_quinzena { get; set; }
        public string Vl_mes { get; set; }
        public string Vl_unidade { get; set; }
        public string StatusProduto
        { get; set; }
        public bool St_coleta
        {
            get
            {
                if (StatusProduto.Trim().ToUpper().Equals("C"))
                    return true;
                else return false;
            }
        }
        public bool St_bloqItem
        { get; set; }
        public TList_CadProduto_Imagens lImagens
        { get; set; }

        public TRegistro_ProdutoLocacao()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Ds_tecnica = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_codbarra = string.Empty;
            Cd_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Quantidade = decimal.Zero;
            Nr_Patrimonio = string.Empty;
            Qtd_horas = decimal.Zero;
            Vl_compra = decimal.Zero;
            dt_compra = null;
            dt_comprastr = string.Empty;
            st_controlehora = "N";
            st_controlehorabool = false;
            StatusProduto = string.Empty;
            St_bloqItem = false;
            vl_unitario = decimal.Zero;
            Vl_hora = string.Empty;
            Vl_dia = string.Empty;
            Vl_semana = string.Empty;
            Vl_quinzena = string.Empty;
            Vl_mes = string.Empty;
            Vl_unidade = string.Empty;
            lImagens = new TList_CadProduto_Imagens();
        }
    }
    #endregion

    #region Classe Produto

    public class TList_CadProduto : List<TRegistro_CadProduto>, IComparer<TRegistro_CadProduto>
    {
        #region IComparer<TRegistro_CadProduto> Members
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

        public TList_CadProduto()
        { }

        public TList_CadProduto(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadProduto x, TRegistro_CadProduto y)
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
    
    public class TRegistro_CadProduto
    {
        public string CD_Produto
        {
            get;
            set;
        }
        public string tp_unidade { get; set; }
        public string Codigo_alternativo
        { get; set; }
        public string CD_Unidade
        {
            get;
            set;
        }
        public string DS_Unidade
        {
            get;
            set;
        }
        public string Sigla_unidade
        {
            get;
            set;
        }
        public decimal CasasDecimais { get; set; } = decimal.Zero;
        public string CD_Grupo
        {
            get;
            set;
        }
        public string DS_Grupo
        {
            get;
            set;
        }
        public string Cd_grupo_pai
        { get; set; }
        public string Ds_grupo_pai
        { get; set; }
        private decimal? cd_marca;
        public decimal? CD_Marca
        {
            get { return cd_marca; }
            set 
            {
                cd_marca = value;
                cd_marcastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_marcastr;
        public string Cd_marcastr
        {
            get { return cd_marcastr; }
            set 
            {
                cd_marcastr = value;
                try
                {
                    cd_marca = Convert.ToDecimal(value);
                }
                catch
                { cd_marca = null; }
            }
        }
        public string DS_Marca
        {
            get;
            set;
        }
        public string DS_Produto
        {
            get;
            set;
        }
        public string CD_CondFiscal_Produto
        {
            get;
            set;
        }
        public string DS_CondFiscal_Produto
        {
            get;
            set;
        }
        public decimal PS_Unitario
        {
            get;
            set;
        }
        public string Sigla
        {
            get;
            set;
        }
        public decimal Pc_Comissao
        {
            get;
            set;
        }
        private string tp_comissao;
        public string Tp_comissao
        {
            get { return tp_comissao; }
            set
            {
                tp_comissao = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_comissao = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_comissao = "VALOR";
            }
        }
        private string tipo_comissao;
        public string Tipo_comissao
        {
            get { return tipo_comissao; }
            set
            {
                tipo_comissao = value;
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_comissao = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_comissao = "V";
            }
        }
        public decimal PS_Embalagem
        {
            get;
            set;
        }
        private string st_tanqueaereo;
        public string ST_TanqueAereo
        {
            get { return st_tanqueaereo; }
            set 
            {
                st_tanqueaereo = value;
                st_tanqueaereobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_tanqueaereobool;
        public bool ST_TanqueAereobool
        {
            get { return st_tanqueaereobool; }
            set 
            {
                st_tanqueaereobool = value;
                st_tanqueaereo = value ? "S" : "N";
            }
        }
        public string DS_AbreviadaProduto
        {
            get;
            set;
        }
        public string DS_Tecnica
        {
            get;
            set;
        }
        public string TP_Produto
        {
            get;
            set;
        }
        public string DS_TpProduto
        {
            get;
            set;
        }
        private string st_registro;
        public string ST_Registro
        {
            get { return st_registro; }
            set 
            { 
                st_registro = value;
                status = value.Trim().ToUpper().Equals("C");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set 
            { 
                status = value;
                st_registro = value ? "C" : "A";
            }
        }
        public string Ncm
        {
            get;
            set;
        }
        public string Ds_ncm
        {
            get;
            set;
        }
        public string Cest
        { get; set; }
        public decimal Qt_dias_PrazoGarantia
        { get; set; }
        public string DS_TecnicaInterna
        {
            get;
            set;
        }
        public string DS_TecnicaAssistencia
        {
            get;
            set;
        }
        private string st_exigirserie;
        public string St_exigirserie
        {
            get { return st_exigirserie; }
            set
            {
                st_exigirserie = value;
                st_exigirseriebool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_exigirseriebool;
        public bool St_exigirseriebool
        {
            get { return st_exigirseriebool; }
            set
            {
                st_exigirseriebool = value;
                st_exigirserie = value ? "S" : "N";
            }
        }
        private string st_expbalanca;
        public string St_expbalanca
        {
            get { return st_expbalanca; }
            set
            {
                st_expbalanca = value;
                st_expbalancabool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_expbalancabool;
        public bool St_expbalancabool
        {
            get { return st_expbalancabool; }
            set
            {
                st_expbalancabool = value;
                st_expbalanca = value ? "S" : "N";
            }
        }

        private string st_prodexportado;
        public string St_prodexportado
        {
            get { return st_prodexportado; }
            set
            {
                st_prodexportado = value;
                st_prodexportadobool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_prodexportadobool;
        public bool St_prodexportadobool
        {
            get { return st_prodexportadobool; }
            set
            {
                st_prodexportadobool = value;
                st_prodexportado = value ? "S" : "N";
            }
        }

        private string st_pesarprod;
        public string St_pesarprod
        {
            get { return st_pesarprod; }
            set
            {
                st_pesarprod = value;
                st_pesarprodbool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_pesarprodbool;
        public bool St_pesarprodbool
        {
            get { return st_pesarprodbool; }
            set
            {
                st_pesarprodbool = value;
                st_pesarprod = value ? "S" : "N";
            }
        }
        private string st_tanquecombustivel;
        public string St_tanquecombustivel
        {
            get { return st_tanquecombustivel; }
            set
            {
                st_tanquecombustivel = value;
                st_tanquecombustivelbool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_tanquecombustivelbool;
        public bool St_tanquecombustivelbool
        {
            get { return st_tanquecombustivelbool; }
            set
            {
                st_tanquecombustivelbool = value;
                st_tanquecombustivel = value ? "S" : "N";
            }
        }
        private decimal? id_genero;
        public decimal? Id_genero
        {
            get { return id_genero; }
            set
            {
                id_genero = value;
                id_generostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_generostr;
        public string Id_generostr
        {
            get { return id_generostr; }
            set
            {
                id_generostr = value;
                try
                {
                    id_genero = Convert.ToDecimal(value);
                }
                catch
                { id_genero = null; }
            }
        }
        public string Ds_genero
        { get; set; }
        public string Id_tpservico
        {
            get;
            set;

        }
        public string Ds_tpservico
        { get; set; }
        public bool St_servico
        { get; set; }
        public bool St_composto
        { get; set; }
        public bool St_mprima
        { get; set; }
        public bool St_embalagem
        { get; set; }
        public bool St_consumointerno
        { get; set; }
        public bool St_industrializado
        { get; set; }
        public string Tp_item
        { get; set; }
        public string Tipo_item
        {
            get
            {
                if (Tp_item.Trim().Equals("00"))
                    return "MERCADORIA PARA REVENDA";
                else if (Tp_item.Trim().Equals("01"))
                    return "MATERIA-PRIMA";
                else if (Tp_item.Trim().Equals("02"))
                    return "EMBALAGEM";
                else if (Tp_item.Trim().Equals("03"))
                    return "PRODUTO EM PROCESSO";
                else if (Tp_item.Trim().Equals("04"))
                    return "PRODUTO ACABADO";
                else if (Tp_item.Trim().Equals("05"))
                    return "SUBPRODUTO";
                else if (Tp_item.Trim().Equals("06"))
                    return "PRODUTO INTERMEDIARIO";
                else if (Tp_item.Trim().Equals("07"))
                    return "MATERIAL DE USO E CONSUMO";
                else if (Tp_item.Trim().Equals("08"))
                    return "ATIVO IMOBILIZADO";
                else if (Tp_item.Trim().Equals("09"))
                    return "SERVICOS";
                else if (Tp_item.Trim().Equals("10"))
                    return "OUTROS INSUMOS";
                else if (Tp_item.Trim().Equals("99"))
                    return "OUTROS";
                else return string.Empty;
            }
        }
        public string Cd_anp
        { get; set; }
        public string Ds_anp
        { get; set; }
        //public decimal Vl_custoatual
        //{ get; set; }
        public decimal Vl_ultimacompra
        { get; set; }
        public decimal Vl_precovenda
        { get; set; }
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
                }catch { id_caracteristicaH = null; }
            }
        }
        public string Ds_caracteristicaH
        { get; set; } = string.Empty;
        private decimal? id_caracteristicaV = null;
        public decimal? Id_caracteristicaV
        {
            get { return id_caracteristicaV; }
            set
            {
                id_caracteristicaV = value;
                id_caracteristicaVstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicaVstr = string.Empty;
        public string Id_caracteristicaVstr
        {
            get { return id_caracteristicaVstr; }
            set
            {
                id_caracteristicaVstr = value;
                try
                {
                    id_caracteristicaV = decimal.Parse(value);
                }catch { id_caracteristicaV = null; }
            }
        }
        public string Ds_caracteristicaV
        { get; set; } = string.Empty;
        public decimal vl_unitario { get; set; } = decimal.Zero;

        public TList_CadAcessoriosProduto Acessorios
        { get; set; }
        public TList_CadAcessoriosProduto AcessoriosApagar
        { get; set; }
        public TList_CadProduto_Imagens LImagens
        {
            get;
            set;
        }
        public TRegistro_LanPrecoItem rPrecoItem { get; set; }
        public TList_CadProduto_Imagens lImagensApagar
        { get; set; }
        public TList_FichaTecProduto lFicha
        { get; set; }
        public TList_FichaTecProduto lFichaApagar
        { get; set; }
        public TList_Produto_QtdEstoque lQtdEstoque
        { get; set; }
        public TList_Produto_QtdEstoque lQtdEstoqueDel
        { get; set; }
        public TList_CodBarra lCodBarra
        { get; set; }
        public TList_CodBarra lCodBarraDel
        { get; set; }
        public TList_Variedade lVariedade
        { get; set; }
        public TList_Variedade lVariedadeDel
        { get; set; }
        public TRegistro_LanEstoque rSaldoEst
        { get; set; }
        public Almoxarifado.TRegistro_Movimentacao rSaldoAlmox
        { get; set; }
        public TList_LanPrecoItem lPrecoItem
        { get; set; }
        public TList_Produto_X_Fornecedor lFornec
        { get; set; }
        public TList_Produto_X_Fornecedor lFornecDel
        { get; set; }
        public TList_LanPrecoItem lTabPrecoVenda
        { get; set; }
        public List<TRegistro_SaldoEstoque> lSaldoEst { get; set; }
        public TList_CadAssistenteVenda lAssistVenda
        { get; set; }
        public TList_CadPatrimonio lPatrimonio
        { get; set; }
        public TList_PrecoItemFicha lPreco
        { get; set; }
        public TList_FichaOP lFichaOP { get; set; } = new TList_FichaOP();
        public TList_FichaOP lFichaOPDel { get; set; } = new TList_FichaOP();
        public bool St_processar
        { get; set; }
        private string tp_combustivel;
        public string Tp_combustivel
        {
            get { return tp_combustivel; }
            set
            {
                tp_combustivel = value;
                if (value.Trim().Equals("1"))
                    tipo_combustivel = "Etanol Hidratado Aditivado";
                else if (value.Trim().Equals("2"))
                    tipo_combustivel = "Etanol Hidratado Comum";
                else if (value.Trim().Equals("3"))
                    tipo_combustivel = "Gasolina C Aditivada";
                else if (value.Trim().Equals("4"))
                    tipo_combustivel = "Gasolina C Comum";
                else if (value.Trim().Equals("5"))
                    tipo_combustivel = "Gasolina C Premium";
                else if (value.Trim().Equals("6"))
                    tipo_combustivel = "Óleo Diesel A Maritimo";
                else if (value.Trim().Equals("7"))
                    tipo_combustivel = "Óleo Diesel B";
                else if (value.Trim().Equals("8"))
                    tipo_combustivel = "Óleo Diesel B Aditivado";
                else if (value.Trim().Equals("9"))
                    tipo_combustivel = "Óleo Diesel B S10";
                else if (value.Trim().Equals("10"))
                    tipo_combustivel = "Óleo Diesel B S10 Aditivado";
                else if (value.Trim().Equals("11"))
                    tipo_combustivel = "Querosene Iluminante";
            }
        }
        private string tipo_combustivel;
        public string Tipo_combustivel
        {
            get { return tipo_combustivel; }
            set
            {
                tipo_combustivel = value;
                if (value.Trim().Equals("Etanol Hidratado Aditivado"))
                    tp_combustivel = "1";
                else if (value.Trim().Equals("Etanol Hidratado Comum"))
                    tp_combustivel = "2";
                else if (value.Trim().Equals("Gasolina C Aditivada"))
                    tp_combustivel = "3";
                else if (value.Trim().Equals("Gasolina C Comum"))
                    tp_combustivel = "4";
                else if (value.Trim().Equals("Gasolina C Premium"))
                    tp_combustivel = "5";
                else if (value.Trim().Equals("Óleo Diesel A Maritimo"))
                    tp_combustivel = "6";
                else if (value.Trim().Equals("Óleo Diesel B"))
                    tp_combustivel = "7";
                else if (value.Trim().Equals("Óleo Diesel B Aditivado"))
                    tp_combustivel = "8";
                else if (value.Trim().Equals("Óleo Diesel B S10"))
                    tp_combustivel = "9";
                else if (value.Trim().Equals("Óleo Diesel B S10 Aditivado"))
                    tp_combustivel = "10";
                else if (value.Trim().Equals("Querosene Iluminante"))
                    tp_combustivel = "11";
            }
        }
        public bool St_reganvisa
        { get; set; }
        public string Reg_anvisa
        { get; set; }
        public string Nr_patrimonio
        { get; set; }
        private string st_rastrear;
        public string St_rastrear
        {
            get { return st_rastrear; }
            set
            {
                st_rastrear = value;
                st_rastrearbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_rastrearbool;
        public bool St_rastrearbool
        {
            get { return st_rastrearbool; }
            set
            {
                st_rastrearbool = value;
                st_rastrear = value ? "S" : "N";
            }
        }
        private string st_integraecommerce = string.Empty;
        public string St_integraecommerce
        {
            get { return st_integraecommerce;}
            set
            {
                st_integraecommerce = value;
                st_integraecommercebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_integraecommercebool = false;
        public bool St_integraecommercebool
        {
            get { return st_integraecommercebool; }
            set
            {
                st_integraecommercebool = value;
                st_integraecommerce = value ? "S" : "N";
            }
        }

        public decimal? Id_Rua { get; set; }
        public decimal? Id_Secao { get; set; }
        public decimal? Id_Celula { get; set; }
        public string Ds_Rua { get; set; }
        public string Ds_Secao { get; set; }
        public string Ds_Celula { get; set; }
        public decimal? qt_combsabores { get; set; } = null;
        public decimal? id_localimp { get; set; }
        public string porta_imp { get; set; }
        public string Cd_integracao { get; set; } = string.Empty;

        public TRegistro_CadProduto()
        {
            qt_combsabores = null;
            Id_Rua = null;
            Id_Secao = null;
            Id_Celula = null;
            Ds_Rua = string.Empty;
            Ds_Secao = string.Empty;
            Ds_Celula = string.Empty;
            CD_Produto = string.Empty;
            id_localimp = null;
            porta_imp = string.Empty;
            Codigo_alternativo = string.Empty;
            CD_Unidade	= string.Empty;
            DS_Unidade = string.Empty;
            CD_Grupo = string.Empty;
            DS_Grupo = string.Empty;
            Cd_grupo_pai = string.Empty;
            Ds_grupo_pai = string.Empty;
            DS_Produto	= string.Empty;
            CD_CondFiscal_Produto = string.Empty;
            DS_CondFiscal_Produto = string.Empty;
            PS_Unitario = decimal.Zero;
            Sigla = string.Empty;
            Pc_Comissao = decimal.Zero;
            tp_comissao = string.Empty;
            tipo_comissao = string.Empty;
            PS_Embalagem = decimal.Zero;
            ST_TanqueAereo = string.Empty;
            DS_AbreviadaProduto = string.Empty;
            CD_Marca = null;
            cd_marcastr = string.Empty;
            DS_Marca = string.Empty;
            TP_Produto = string.Empty;
            DS_TpProduto = string.Empty;
            ST_Registro = "A";
            id_genero = null;
            id_generostr = string.Empty;
            Ds_genero = string.Empty;
            Id_tpservico = "";
            Ds_tpservico = string.Empty;
            DS_Tecnica = string.Empty;
            DS_TecnicaInterna = string.Empty;
            DS_TecnicaAssistencia = string.Empty;
            st_exigirserie = "N";
            st_exigirseriebool = false;
            st_expbalanca = "N";
            st_expbalancabool = false;
            st_prodexportado = "N";
            st_prodexportadobool = false;
            st_pesarprod = "N";
            st_pesarprodbool = false;
            st_tanquecombustivel = "N";
            st_tanquecombustivelbool = false;
            St_servico = false;
            St_composto = false;
            St_mprima = false;
            St_embalagem = false;
            St_industrializado = false;
            Tp_item = string.Empty;
            Cd_anp = string.Empty;
            Ds_anp = string.Empty;
            St_consumointerno = false;

            Ncm = string.Empty;
            Ds_ncm = string.Empty;
            Cest = string.Empty;
            St_processar = false;
            //Vl_custoatual = decimal.Zero;
            Vl_ultimacompra = decimal.Zero;
            Vl_precovenda = decimal.Zero;
            tp_combustivel = string.Empty;
            tipo_combustivel = string.Empty;
            St_reganvisa = false;
            Reg_anvisa = string.Empty;
            Nr_patrimonio = string.Empty;

            LImagens = new TList_CadProduto_Imagens();
            lImagensApagar = new TList_CadProduto_Imagens();
            Acessorios = new TList_CadAcessoriosProduto();
            AcessoriosApagar = new TList_CadAcessoriosProduto();
            lFicha = new TList_FichaTecProduto();
            lFichaApagar = new TList_FichaTecProduto();
            lQtdEstoque = new TList_Produto_QtdEstoque();
            lQtdEstoqueDel = new TList_Produto_QtdEstoque();
            lCodBarra = new TList_CodBarra();
            lCodBarraDel = new TList_CodBarra();
            lFornec = new TList_Produto_X_Fornecedor();
            lFornecDel = new TList_Produto_X_Fornecedor();
            lTabPrecoVenda = new TList_LanPrecoItem();
            lSaldoEst = new List<TRegistro_SaldoEstoque>();
            lAssistVenda = new TList_CadAssistenteVenda();
            lPatrimonio = new TList_CadPatrimonio();
            lPreco = new TList_PrecoItemFicha();
            lVariedade = new TList_Variedade();
            lVariedadeDel = new TList_Variedade();

            lPrecoItem = new TList_LanPrecoItem(); ;
            rSaldoEst = null;
            rSaldoAlmox = null;
            st_rastrear = "N";
            st_rastrearbool = false;
        }
    }

    public class TCD_CadProduto : TDataQuery
    {
        public TCD_CadProduto()
        { }

        public TCD_CadProduto(string vNm_proc)
        { NM_ProcSqlBusca = vNm_proc; }

        public TCD_CadProduto(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBuscaImport(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT a.qt_combsabores, a.cd_produto, a.sigla, a.cd_unidade, a.cd_marca, f.ds_marca, b.ds_unidade, b.sigla_unidade, ");
            sql.AppendLine("a.cd_grupo, c.ds_grupo, a.ds_produto, a.cd_condfiscal_produto, d.ds_condfiscal_produto, c.cd_grupo_pai, ");
            sql.AppendLine("a.ps_unitario, h.ds_grupo as ds_grupo_pai, b.CasasDecimais, ");
            sql.AppendLine("a.id_caracteristicaV, n.ds_caracteristica as ds_caracteristicaV, ");
            sql.AppendLine("a.id_caracteristicaH, o.ds_caracteristica as ds_caracteristicaH, ");
            sql.AppendLine("a.pc_comissao, a.ps_embalagem, a.st_tanqueaereo, e.st_servico, e.st_composto, e.st_mprima, e.st_embalagem, e.St_industrializado, ");
            sql.AppendLine("a.ds_abreviadaproduto, a.tp_produto, e.ds_tpproduto, isnull(a.st_registro, 'A') as st_registro, a.ds_tecnica, a.qt_dias_prazoGarantia, ");
            sql.AppendLine("a.DS_TecnicaInterna, a.DS_TecnicaAssistencia, a.codigo_alternativo, a.st_exigirserie, ");
            sql.AppendLine("a.ncm,  g.ds_ncm, g.cest, a.id_genero, i.ds_genero, a.id_tpservico, j.ds_tpservico, ");
            sql.AppendLine("vl_precovenda = dbo.F_PRECO_VENDA(@CD_EMPRESA, a.cd_produto, @CD_TABELAPRECO) ");
            sql.AppendLine(", a.id_rua, a.id_secao, a.id_celula,m.ds_celula, l.ds_secao, k.ds_rua, a.id_localimp ");

            sql.AppendLine("FROM TB_EST_PRODUTO a ");
            sql.AppendLine("inner join TB_EST_UNIDADE b ");
            sql.AppendLine("on b.cd_unidade = a.cd_unidade ");
            sql.AppendLine("inner join TB_EST_GRUPOPRODUTO c ");
            sql.AppendLine("on c.cd_grupo = a.cd_grupo ");
            sql.AppendLine("inner join TB_FIS_CONDFISCAL_PRODUTO d ");
            sql.AppendLine("on d.cd_condfiscal_produto = a.cd_condfiscal_produto ");
            sql.AppendLine("left outer join TB_EST_TpProduto e ");
            sql.AppendLine("on e.tp_produto = a.tp_produto ");
            sql.AppendLine("left outer join TB_EST_Marca f ");
            sql.AppendLine("On f.cd_Marca = a.cd_marca ");
            sql.AppendLine("left outer join TB_FIS_NCM g ");
            sql.AppendLine("on a.ncm = g.ncm ");
            sql.AppendLine("left outer join tb_est_grupoproduto h ");
            sql.AppendLine("on c.cd_grupo_pai = h.cd_grupo ");
            sql.AppendLine("left outer join tb_est_generoproduto i ");
            sql.AppendLine("on a.id_genero = i.id_genero ");
            sql.AppendLine("left outer join tb_est_tiposervico j ");
            sql.AppendLine("on a.id_tpservico = j.id_tpservico ");
            sql.AppendLine("left join tb_amx_rua k ");
            sql.AppendLine("on a.id_rua = k.id_rua ");
            sql.AppendLine("left join tb_amx_secao l ");
            sql.AppendLine("on l.id_rua = k.id_rua and a.id_secao = l.id_secao ");
            sql.AppendLine("left join tb_amx_celulaam m ");
            sql.AppendLine("on  l.id_rua = m.id_rua ");
            sql.AppendLine("and l.id_secao = m.id_secao ");
            sql.AppendLine("and m.id_celula = a.id_celula ");
            sql.AppendLine("left join tb_est_caracteristica n ");
            sql.AppendLine("on a.id_caracteristicaV = n.id_caracteristica ");
            sql.AppendLine("left join tb_est_caracteristica o ");
            sql.AppendLine("on a.id_caracteristicaH = o.id_caracteristica ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.cd_produto asc");
            return sql.ToString();
        }

        public DataTable BuscarImport(TpBusca[] vBusca, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBuscaImport(vBusca), vParametros);
        }
               
        private string SqlCodePrecoVenda(string vCd_empresa, string vCd_produto, string vCd_tabelapreco)
        {
            return "select dbo.F_PRECO_VENDA('"+ vCd_empresa + "', '" + vCd_produto + "', '" + vCd_tabelapreco + "')";
        }

        public object BuscarPrecoVenda(string vCd_empresa, string vCd_produto, string vCd_tabelapreco)
        {
            return ExecutarBuscaEscalar(SqlCodePrecoVenda(vCd_empresa, vCd_produto, vCd_tabelapreco), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.qt_combsabores, a.cd_produto, a.sigla, a.cd_unidade, a.cd_marca, f.ds_marca, b.ds_unidade, b.sigla_unidade, ");
                sql.AppendLine("a.cd_grupo, rtrim(c.ds_grupo) as ds_grupo, a.ds_produto, a.cd_condfiscal_produto, d.ds_condfiscal_produto, c.cd_grupo_pai, ");
                sql.AppendLine("a.ps_unitario, rtrim(h.ds_grupo) as ds_grupo_pai, a.tp_item, a.cd_anp, k.ds_anp, e.st_consumointerno, e.st_reganvisa, ");
                sql.AppendLine("a.pc_comissao, a.tp_comissao, a.ps_embalagem, a.st_tanqueaereo, e.ST_TanqueCombustivel, e.st_servico, e.st_composto, e.st_mprima, e.st_embalagem, e.St_industrializado, ");
                sql.AppendLine("a.ds_abreviadaproduto, a.tp_produto, e.ds_tpproduto, isnull(a.st_registro, 'A') as st_registro, a.reg_anvisa, ");
                sql.AppendLine("a.DS_TecnicaInterna, a.DS_TecnicaAssistencia, a.codigo_alternativo, a.st_exigirserie, b.CasasDecimais, ");
                sql.AppendLine("a.ds_tecnica, a.qt_dias_prazoGarantia, a.tp_combustivel, a.ST_ExpBalanca, a.ST_ProdExportado, a.ST_PesarProd, ");
                sql.AppendLine("a.ncm, g.ds_ncm, g.cest, a.id_genero, i.ds_genero, a.id_tpservico, j.ds_tpservico, a.st_rastrear, a.st_Integraecommerce, ");
                sql.AppendLine("Nr_Patrimonio = isnull((select x.NR_Patrimonio from TB_EST_Patrimonio x ");
                sql.AppendLine("                        where x.CD_Patrimonio = a.CD_Produto), ''), ");
                //Comentado devido a lentidão na busca de produtos ticket 6922
                //sql.AppendLine("Vl_ultimacompra = dbo.F_FAT_ULTIMACOMPRA(null, a.cd_produto), ");
                sql.AppendLine("isnull(b.tp_unidade, 9) as tp_unidade, a.cd_integracao, ");
                sql.AppendLine("a.id_rua, a.id_secao, a.id_celula,m.ds_celula, l.ds_secao, n.ds_rua, a.id_localimp, o.porta_imp, ");
                sql.AppendLine("a.id_rua, a.id_secao, a.id_celula,m.ds_celula, l.ds_secao, n.ds_rua, ");
                sql.AppendLine("a.id_caracteristicaV, p.ds_caracteristica as ds_caracteristicaV, ");
                sql.AppendLine("a.id_caracteristicaH, q.ds_caracteristica as ds_caracteristicaH ");
            }                                                                                                      
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_PRODUTO a ");
            sql.AppendLine("inner join TB_EST_UNIDADE b ");
            sql.AppendLine("on b.cd_unidade = a.cd_unidade ");
            sql.AppendLine("inner join TB_EST_GRUPOPRODUTO c ");
            sql.AppendLine("on c.cd_grupo = a.cd_grupo ");
            sql.AppendLine("left join TB_FIS_CONDFISCAL_PRODUTO d ");
            sql.AppendLine("on d.cd_condfiscal_produto = a.cd_condfiscal_produto ");
            sql.AppendLine("left outer join TB_EST_TpProduto e ");
            sql.AppendLine("on e.tp_produto = a.tp_produto ");
            sql.AppendLine("left outer join TB_EST_Marca f ");
            sql.AppendLine("On f.cd_Marca = a.cd_marca ");
            sql.AppendLine("left outer join TB_FIS_NCM g ");
            sql.AppendLine("on a.ncm = g.ncm ");
            sql.AppendLine("left outer join tb_est_grupoproduto h ");
            sql.AppendLine("on c.cd_grupo_pai = h.cd_grupo ");
            sql.AppendLine("left outer join tb_est_generoproduto i ");
            sql.AppendLine("on a.id_genero = i.id_genero ");
            sql.AppendLine("left outer join tb_est_tiposervico j ");
            sql.AppendLine("on a.id_tpservico = j.id_tpservico ");
            sql.AppendLine("left outer join tb_est_anp k ");
            sql.AppendLine("on a.cd_anp = k.cd_anp ");
            sql.AppendLine("left join tb_amx_rua n ");
            sql.AppendLine("on a.id_rua = n.id_rua ");
            sql.AppendLine("left join tb_amx_secao l ");
            sql.AppendLine("on l.id_rua = n.id_rua and a.id_secao = l.id_secao ");
            sql.AppendLine("left join TB_AMX_CelulaArm m ");
            sql.AppendLine("on  l.id_rua = m.id_rua and l.id_secao = m.id_secao and m.id_celula = a.id_celula");
            sql.AppendLine("left join tb_res_localimp o");
            sql.AppendLine(" on o.id_localimp = a.id_localimp ");
            sql.AppendLine("left join tb_est_caracteristica p ");
            sql.AppendLine("on a.id_caracteristicaV = p.id_caracteristica ");
            sql.AppendLine("left join tb_est_caracteristica q ");
            sql.AppendLine("on a.id_caracteristicaH = q.id_caracteristica ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            else
                sql.AppendLine("Order By a.cd_produto asc");
            
            return sql.ToString();
        }

        private string SqlCodeBuscaProduto(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.st_pesarprod, a.qt_combsabores, a.id_localimp , a.cd_produto, a.sigla, ");
                sql.AppendLine("a.cd_unidade, a.cd_marca, f.ds_marca, b.ds_unidade, b.sigla_unidade, b.CasasDecimais, a.cd_integracao, ");
                sql.AppendLine("a.cd_grupo, rtrim(c.ds_grupo) as ds_grupo, a.ds_produto, a.cd_condfiscal_produto, d.ds_condfiscal_produto, c.cd_grupo_pai, ");
                sql.AppendLine("a.ps_unitario, rtrim(h.ds_grupo) as ds_grupo_pai, a.tp_item, a.cd_anp, k.ds_anp, e.st_consumointerno, a.tp_combustivel, ");
                sql.AppendLine("a.pc_comissao, a.tp_comissao, a.ps_embalagem, a.st_tanqueaereo, e.st_servico, e.st_composto, e.st_mprima, e.st_embalagem, e.St_industrializado, ");
                sql.AppendLine("a.ds_abreviadaproduto, a.tp_produto, e.ds_tpproduto, isnull(a.st_registro, 'A') as st_registro, a.reg_anvisa, a.st_rastrear, ");
                sql.AppendLine("a.DS_TecnicaInterna, a.DS_TecnicaAssistencia, a.codigo_alternativo, a.st_exigirserie, e.st_reganvisa, ");
                sql.AppendLine("a.ds_tecnica, a.qt_dias_prazoGarantia, a.tp_combustivel, a.st_integraecommerce, ");
                sql.AppendLine("a.ncm, g.ds_ncm, g.cest, a.id_genero, i.ds_genero, a.id_tpservico, j.ds_tpservico, ");
                sql.AppendLine("a.id_caracteristicaV, l.ds_caracteristica as ds_caracteristicaV, ");
                sql.AppendLine("a.id_caracteristicaH, m.ds_caracteristica as ds_caracteristicaH, ");
                sql.AppendLine("vl_precovenda = dbo.F_PRECO_VENDA(@CD_EMPRESA, a.cd_produto, @CD_TABELAPRECO), ");
                sql.AppendLine("Vl_ultimacompra = dbo.F_FAT_ULTIMACOMPRA(@CD_EMPRESA, a.cd_produto), ");
                sql.AppendLine("NR_Patrimonio = isnull((select top 1 x.NR_Patrimonio ");
                sql.AppendLine("				from TB_EST_Patrimonio x ");
                sql.AppendLine("				where x.CD_Patrimonio = a.CD_Produto), '') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_PRODUTO a ");
            sql.AppendLine("inner join TB_EST_UNIDADE b ");
            sql.AppendLine("on b.cd_unidade = a.cd_unidade ");
            sql.AppendLine("inner join TB_EST_GRUPOPRODUTO c ");
            sql.AppendLine("on c.cd_grupo = a.cd_grupo ");
            sql.AppendLine("left join TB_FIS_CONDFISCAL_PRODUTO d ");
            sql.AppendLine("on d.cd_condfiscal_produto = a.cd_condfiscal_produto ");
            sql.AppendLine("left outer join TB_EST_TpProduto e ");
            sql.AppendLine("on e.tp_produto = a.tp_produto ");
            sql.AppendLine("left outer join TB_EST_Marca f ");
            sql.AppendLine("On f.cd_Marca = a.cd_marca ");
            sql.AppendLine("left outer join TB_FIS_NCM g ");
            sql.AppendLine("on a.ncm = g.ncm ");
            sql.AppendLine("left outer join tb_est_grupoproduto h ");
            sql.AppendLine("on c.cd_grupo_pai = h.cd_grupo ");
            sql.AppendLine("left outer join tb_est_generoproduto i ");
            sql.AppendLine("on a.id_genero = i.id_genero ");
            sql.AppendLine("left outer join tb_est_tiposervico j ");
            sql.AppendLine("on a.id_tpservico = j.id_tpservico ");
            sql.AppendLine("left outer join tb_est_anp k ");
            sql.AppendLine("on a.cd_anp = k.cd_anp ");
            sql.AppendLine("left join tb_est_caracteristica l ");
            sql.AppendLine("on a.id_caracteristicaV = l.id_caracteristica ");
            sql.AppendLine("left join tb_est_caracteristica m ");
            sql.AppendLine("on a.id_caracteristicaH = m.id_caracteristica ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            else
                sql.AppendLine("Order By a.cd_produto asc");
            return sql.ToString();
        }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder(); 
            sql.AppendLine("select a.id_localimp ,a.qt_combsabores, a.CD_Produto, a.DS_Produto, a.CD_CODBARRA, "); 
            sql.AppendLine("a.CD_Unidade, b.Sigla_Unidade, b.CasasDecimais, c.VL_PrecoVenda, ");
            sql.AppendLine("a.cd_condfiscal_produto, a.cd_grupo, ");
            sql.AppendLine("imgproduto = (select top 1 x.Imagem ");
            sql.AppendLine("				from TB_EST_Produto_Imagens x ");
            sql.AppendLine("				where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				order by x.ID_Imagem) ");
            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_Unidade b ");
            sql.AppendLine("on a.CD_Unidade = b.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_PrecoItem c ");
            sql.AppendLine("on a.CD_Produto = c.CD_Produto ");

            string cond = " where ";
            if(vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaLocacao(TpBusca[] vBusca, string dt_locacao)
        {
            StringBuilder sql = new StringBuilder(); 
            sql.AppendLine("select a.qt_combsabores, a.CD_Produto,a.id_localimp , a.DS_Produto, a.DS_TecnicaAssistencia, "); 
            sql.AppendLine("a.CD_Unidade, b.Sigla_Unidade, b.CasasDecimais, d.Quantidade, d.NR_Patrimonio, d.St_controleHora, d.Qtd_horas, ");
            sql.AppendLine("a.cd_condfiscal_produto, a.cd_grupo, rtrim(c.ds_grupo) as ds_grupo, d.vl_compra, d.dt_compra, ");
            if (!string.IsNullOrEmpty(dt_locacao))
            {
                sql.AppendLine("StatusProduto =  case (SELECT top 1 1 FROM TB_LOC_ColetaEntrega x ");                    
                sql.AppendLine("                       inner join TB_LOC_Vistoria_X_ColEnt y ");
                sql.AppendLine("                       on x.CD_Empresa = y.CD_Empresa ");
                sql.AppendLine("                       and x.ID_Coleta = y.ID_Coleta ");
                sql.AppendLine("                       inner join TB_LOC_ItensLocacao k ");
                sql.AppendLine("                       on k.CD_Empresa = y.cd_empresa ");
                sql.AppendLine("                       and k.id_locacao = y.id_locacao ");
                sql.AppendLine("                       and k.ID_ItemLoc = y.ID_ItemLoc ");
                sql.AppendLine("                       inner join TB_LOC_Locacao l ");
                sql.AppendLine("                       on l.CD_Empresa = k.CD_Empresa ");
                sql.AppendLine("                       and l.ID_Locacao = k.ID_Locacao ");
                sql.AppendLine("                       where y.CD_Empresa = k.CD_Empresa ");
                sql.AppendLine("                       and isnull(l.ST_Registro, '0') in('3', '6')");
                sql.AppendLine("                       and isnull(k.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("                       and k.CD_Produto = a.CD_Produto ");
                sql.AppendLine("                       and x.TP_Mov = 'C' ");
                sql.AppendLine("                       and x.DT_RETORNO is null) when 1 then 'C' else ");
                sql.AppendLine("                 case (Select top 1 1 ");
                sql.AppendLine("			           from TB_LOC_ItensLocacao x ");
                sql.AppendLine("			           inner join TB_LOC_Locacao loc ");
                sql.AppendLine("			           on x.cd_empresa = loc.cd_empresa ");
                sql.AppendLine("			           and x.id_locacao = loc.id_locacao ");
                sql.AppendLine("		               where (loc.dt_locacao >= '" + dt_locacao.Trim() + "' or ");
                sql.AppendLine("			           ISNULL(x.DT_Devolucao, case when x.DT_PrevDev < '" + dt_locacao.Trim() + "' then '" + dt_locacao.Trim() + "' ELSE x.DT_PrevDev end) >= '" + dt_locacao.Trim() + "') ");
                sql.AppendLine("			           and (loc.dt_locacao <= '" + dt_locacao.Trim() + "' or ");
                sql.AppendLine("			           ISNULL(x.DT_Devolucao, case when x.DT_PrevDev < '" + dt_locacao.Trim() + "' then '" + dt_locacao.Trim() + "' ELSE x.DT_PrevDev end) <= '" + dt_locacao.Trim() + "') ");
                sql.AppendLine("			           and (isnull(loc.st_registro, '0') <> '8')");// not in('7', '8')) ");
                sql.AppendLine("                       and (isnull(x.st_registro, 'A') <> 'C') ");
                sql.AppendLine("			           and (x.CD_Produto = a.CD_Produto)) when 1 then 'L' else ");
                sql.AppendLine("                 case (select TOP 1 1 from TB_OSE_Servico x ");
                sql.AppendLine("					   where isnull(x.ST_OS, 'AB') = 'AB' ");
                sql.AppendLine("					   and x.CD_ProdutoOS = a.cd_produto)   when 1 then 'M' else 'D' end end end ");
                //Código comentado atendimento Nº Ticket: 6105 para não locar produto em manutenção independente da data de previsão.
                //sql.AppendLine("					   where (x.DT_Abertura >= '" + dt_locacao.Trim() + "' or ");
                //sql.AppendLine("		               ISNULL(x.dt_finalizada, case when x.dt_previsao < GETDATE() then GETDATE() ELSE x.dt_previsao end)  >= '" + dt_locacao.Trim() + "' ) ");
                //sql.AppendLine("                       and (x.DT_Abertura <= '" + dt_locacao.Trim() + "' or ");
                //sql.AppendLine("		               ISNULL(x.dt_finalizada, case when x.dt_previsao < GETDATE() then GETDATE() ELSE x.dt_previsao end)  <= '" + dt_locacao.Trim() + "' ) ");
                //sql.AppendLine("					   and isnull(x.ST_OS, 'AB') <> 'CA' ");
                //sql.AppendLine("					   and x.CD_ProdutoOS = a.cd_produto)   when 1 then 'M' else 'D' end end ");
            }
            else
                sql.AppendLine("StatusProduto = 'D' ");
            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_Unidade b ");
            sql.AppendLine("on a.CD_Unidade = b.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_GrupoProduto c ");
            sql.AppendLine("on c.cd_grupo = a.cd_grupo ");
            sql.AppendLine("left outer join TB_EST_Patrimonio d ");
            sql.AppendLine("on d.CD_Patrimonio = a.CD_Produto ");
            sql.AppendLine("Where isNull(a.ST_Registro,'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_grupo ");
            return sql.ToString();
        }

        public string SqlCodeBuscaProdXTabDesc(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string  strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            { 
                sql.AppendLine("Select " + strTop + " a.qt_combsabores, a.id_localimp , a.CD_Produto, a.DS_Produto, a.DS_AbreviadaProduto, ");

                sql.AppendLine("a.CD_Unidade, e.DS_Unidade, e.Sigla_Unidade, e.CasasDecimais, ");
                sql.AppendLine("a.CD_Grupo, f.DS_Grupo, a.CD_CondFiscal_Produto, ");
                sql.AppendLine("g.DS_CondFiscal_Produto, a.TP_Produto, h.DS_TPProduto, ");
                sql.AppendLine("a.sigla, a.ps_unitario, ");
                sql.AppendLine("a.pc_comissao, h.st_servico, h.st_composto, h.st_mprima, h.st_embalagem, h.St_industrializado, ");
                sql.AppendLine("a.ps_embalagem, ");
                sql.AppendLine("a.st_tanqueaereo, a.dt_cad, a.dt_alt ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_GRO_DescontoXProduto i ");
            sql.AppendLine("inner join TB_EST_Produto a On a.cd_produto = i.cd_produto ");
            sql.AppendLine("left outer join TB_EST_Unidade e On e.CD_Unidade = a.CD_Unidade ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto f On f.CD_Grupo = a.CD_Grupo ");
            sql.AppendLine("left outer join TB_FIS_CondFiscal_Produto g On g.CD_CondFiscal_Produto = a.CD_CondFiscal_Produto ");
            sql.AppendLine("left outer join TB_EST_TPProduto h On h.TP_Produto = a.TP_Produto ");
            sql.AppendLine("Where isNull(a.ST_Registro,'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, vNM_Campo), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                return ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }
        }

        public TList_CadProduto Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            TList_CadProduto lista = new TList_CadProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vGroup, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadProduto reg = new TRegistro_CadProduto();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.CD_Unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.DS_Unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CasasDecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("CasasDecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Marca")))
                        reg.CD_Marca = reader.GetDecimal(reader.GetOrdinal("CD_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Marca")))
                        reg.DS_Marca = reader.GetString(reader.GetOrdinal("DS_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.CD_Grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.DS_Grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Grupo_Pai")))
                        reg.Cd_grupo_pai = reader.GetString(reader.GetOrdinal("CD_Grupo_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo_Pai")))
                        reg.Ds_grupo_pai = reader.GetString(reader.GetOrdinal("DS_Grupo_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnica")))
                        reg.DS_Tecnica = reader.GetString(reader.GetOrdinal("ds_tecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.CD_CondFiscal_Produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condfiscal_produto")))
                        reg.DS_CondFiscal_Produto = reader.GetString(reader.GetOrdinal("ds_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_unitario")))
                        reg.PS_Unitario = reader.GetDecimal(reader.GetOrdinal("ps_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comissao")))
                        reg.Pc_Comissao = reader.GetDecimal(reader.GetOrdinal("pc_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_comissao")))
                        reg.Tp_comissao = reader.GetString(reader.GetOrdinal("tp_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_embalagem")))
                        reg.PS_Embalagem = reader.GetDecimal(reader.GetOrdinal("ps_embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tanqueaereo")))
                        reg.ST_TanqueAereo = reader.GetString(reader.GetOrdinal("st_tanqueaereo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_abreviadaproduto")))
                        reg.DS_AbreviadaProduto = reader.GetString(reader.GetOrdinal("ds_abreviadaproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_produto")))
                        reg.TP_Produto = reader.GetString(reader.GetOrdinal("tp_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpproduto")))
                        reg.DS_TpProduto = reader.GetString(reader.GetOrdinal("ds_tpproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_dias_prazoGarantia")))
                        reg.Qt_dias_PrazoGarantia = reader.GetDecimal(reader.GetOrdinal("qt_dias_prazoGarantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaInterna")))
                        reg.DS_TecnicaInterna = reader.GetString(reader.GetOrdinal("DS_TecnicaInterna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaAssistencia")))
                        reg.DS_TecnicaAssistencia = reader.GetString(reader.GetOrdinal("DS_TecnicaAssistencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Codigo_alternativo = reader.GetString(reader.GetOrdinal("Codigo_alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExigirSerie")))
                        reg.St_exigirserie = reader.GetString(reader.GetOrdinal("ST_ExigirSerie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExpBalanca")))
                        reg.St_expbalanca = reader.GetString(reader.GetOrdinal("ST_ExpBalanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ProdExportado")))
                        reg.St_prodexportado = reader.GetString(reader.GetOrdinal("ST_ProdExportado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_PesarProd")))
                        reg.St_pesarprod = reader.GetString(reader.GetOrdinal("ST_PesarProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NCM")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_NCM")))
                        reg.Ds_ncm = reader.GetString(reader.GetOrdinal("DS_NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_genero")))
                        reg.Id_genero = reader.GetDecimal(reader.GetOrdinal("id_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_genero")))
                        reg.Ds_genero = reader.GetString(reader.GetOrdinal("ds_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpservico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("id_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpservico")))
                        reg.Ds_tpservico = reader.GetString(reader.GetOrdinal("ds_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("st_servico")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_composto")))
                        reg.St_composto = reader.GetString(reader.GetOrdinal("st_composto")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mprima")))
                        reg.St_mprima = reader.GetString(reader.GetOrdinal("st_mprima")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_embalagem")))
                        reg.St_embalagem = reader.GetString(reader.GetOrdinal("st_embalagem")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_consumointerno")))
                        reg.St_consumointerno = reader.GetString(reader.GetOrdinal("st_consumointerno")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_reganvisa")))
                        reg.St_reganvisa = reader.GetString(reader.GetOrdinal("st_reganvisa")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TanqueCombustivel")))
                        reg.St_tanquecombustivelbool = reader.GetString(reader.GetOrdinal("ST_TanqueCombustivel")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_item")))
                        reg.Tp_item = reader.GetString(reader.GetOrdinal("tp_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("vl_custoatual")))
                    //    reg.Vl_custoatual = reader.GetDecimal(reader.GetOrdinal("vl_custoatual"));
                    //Comentado devido a lentidão na busca de produtos ticket 6922
                    //if (!reader.IsDBNull(reader.GetOrdinal("Vl_ultimacompra")))
                    //    reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("Vl_ultimacompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_combustivel")))
                        reg.Tp_combustivel = reader.GetString(reader.GetOrdinal("tp_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("reg_anvisa")))
                        reg.Reg_anvisa = reader.GetString(reader.GetOrdinal("reg_anvisa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_rastrear")))
                        reg.St_rastrear = reader.GetString(reader.GetOrdinal("st_rastrear"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_unidade")))
                        reg.tp_unidade = reader.GetString(reader.GetOrdinal("tp_unidade"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("st_integraecommerce")))
                        reg.St_integraecommerce = reader.GetString(reader.GetOrdinal("st_Integraecommerce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_localimp")))
                        reg.id_localimp = reader.GetDecimal(reader.GetOrdinal("id_localimp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_imp")))
                        reg.porta_imp = reader.GetString(reader.GetOrdinal("porta_imp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristicaH")))
                        reg.Id_caracteristicaH = reader.GetDecimal(reader.GetOrdinal("id_caracteristicaH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristicaH")))
                        reg.Ds_caracteristicaH = reader.GetString(reader.GetOrdinal("ds_caracteristicaH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristicaV")))
                        reg.Id_caracteristicaV = reader.GetDecimal(reader.GetOrdinal("id_caracteristicaV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristicaV")))
                        reg.Ds_caracteristicaV = reader.GetString(reader.GetOrdinal("ds_caracteristicaV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_combsabores")))
                        reg.qt_combsabores = reader.GetDecimal(reader.GetOrdinal("qt_combsabores"));
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

        public TList_CadProduto Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            TList_CadProduto lista = new TList_CadProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBuscaReader(SqlCodeBuscaProduto(vBusca, Convert.ToInt16(vTop), vNM_Campo, vGroup, vOrder), vParametros);
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadProduto reg = new TRegistro_CadProduto();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.CD_Unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.DS_Unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("casasdecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("casasdecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_combsabores")))
                        reg.qt_combsabores = reader.GetDecimal(reader.GetOrdinal("qt_combsabores"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Marca")))
                        reg.CD_Marca = reader.GetDecimal(reader.GetOrdinal("CD_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Marca")))
                        reg.DS_Marca = reader.GetString(reader.GetOrdinal("DS_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.CD_Grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.DS_Grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Grupo_Pai")))
                        reg.Cd_grupo_pai = reader.GetString(reader.GetOrdinal("CD_Grupo_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo_Pai")))
                        reg.Ds_grupo_pai = reader.GetString(reader.GetOrdinal("DS_Grupo_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnica")))
                        reg.DS_Tecnica = reader.GetString(reader.GetOrdinal("ds_tecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.CD_CondFiscal_Produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condfiscal_produto")))
                        reg.DS_CondFiscal_Produto = reader.GetString(reader.GetOrdinal("ds_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_unitario")))
                        reg.PS_Unitario = reader.GetDecimal(reader.GetOrdinal("ps_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comissao")))
                        reg.Pc_Comissao = reader.GetDecimal(reader.GetOrdinal("pc_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_comissao")))
                        reg.Tp_comissao = reader.GetString(reader.GetOrdinal("tp_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_embalagem")))
                        reg.PS_Embalagem = reader.GetDecimal(reader.GetOrdinal("ps_embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tanqueaereo")))
                        reg.ST_TanqueAereo = reader.GetString(reader.GetOrdinal("st_tanqueaereo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_abreviadaproduto")))
                        reg.DS_AbreviadaProduto = reader.GetString(reader.GetOrdinal("ds_abreviadaproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_produto")))
                        reg.TP_Produto = reader.GetString(reader.GetOrdinal("tp_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpproduto")))
                        reg.DS_TpProduto = reader.GetString(reader.GetOrdinal("ds_tpproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_dias_prazoGarantia")))
                        reg.Qt_dias_PrazoGarantia = reader.GetDecimal(reader.GetOrdinal("qt_dias_prazoGarantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaInterna")))
                        reg.DS_TecnicaInterna = reader.GetString(reader.GetOrdinal("DS_TecnicaInterna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaAssistencia")))
                        reg.DS_TecnicaAssistencia = reader.GetString(reader.GetOrdinal("DS_TecnicaAssistencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Codigo_alternativo = reader.GetString(reader.GetOrdinal("Codigo_alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExigirSerie")))
                        reg.St_exigirserie = reader.GetString(reader.GetOrdinal("ST_ExigirSerie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NCM")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_NCM")))
                        reg.Ds_ncm = reader.GetString(reader.GetOrdinal("DS_NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_genero")))
                        reg.Id_genero = reader.GetDecimal(reader.GetOrdinal("id_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_genero")))
                        reg.Ds_genero = reader.GetString(reader.GetOrdinal("ds_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpservico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("id_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpservico")))
                        reg.Ds_tpservico = reader.GetString(reader.GetOrdinal("ds_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("st_servico")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_composto")))
                        reg.St_composto = reader.GetString(reader.GetOrdinal("st_composto")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mprima")))
                        reg.St_mprima = reader.GetString(reader.GetOrdinal("st_mprima")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_embalagem")))
                        reg.St_embalagem = reader.GetString(reader.GetOrdinal("st_embalagem")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_consumointerno")))
                        reg.St_consumointerno = reader.GetString(reader.GetOrdinal("st_consumointerno")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("St_industrializado")))
                        reg.St_industrializado = reader.GetString(reader.GetOrdinal("St_industrializado")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_reganvisa")))
                        reg.St_reganvisa = reader.GetString(reader.GetOrdinal("st_reganvisa")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_item")))
                        reg.Tp_item = reader.GetString(reader.GetOrdinal("tp_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("vl_custoatual")))
                    //    reg.Vl_custoatual = reader.GetDecimal(reader.GetOrdinal("vl_custoatual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precovenda")))
                        reg.Vl_precovenda = reader.GetDecimal(reader.GetOrdinal("vl_precovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ultimacompra")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ultimacompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_combustivel")))
                        reg.Tp_combustivel = reader.GetString(reader.GetOrdinal("tp_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("reg_anvisa")))
                        reg.Reg_anvisa = reader.GetString(reader.GetOrdinal("reg_anvisa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_rastrear")))
                        reg.St_rastrear = reader.GetString(reader.GetOrdinal("st_rastrear"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_pesarprod")))
                        reg.St_pesarprod = reader.GetString(reader.GetOrdinal("St_pesarprod"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_integraecommerce")))
                        reg.St_integraecommerce = reader.GetString(reader.GetOrdinal("st_Integraecommerce")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("id_localimp")))
                        reg.id_localimp = reader.GetDecimal(reader.GetOrdinal("id_localimp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristicaH")))
                        reg.Id_caracteristicaH = reader.GetDecimal(reader.GetOrdinal("id_caracteristicaH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristicaH")))
                        reg.Ds_caracteristicaH = reader.GetString(reader.GetOrdinal("ds_caracteristicaH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristicaV")))
                        reg.Id_caracteristicaV = reader.GetDecimal(reader.GetOrdinal("id_caracteristicaV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristicaV")))
                        reg.Ds_caracteristicaV = reader.GetString(reader.GetOrdinal("ds_caracteristicaV"));
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

        public List<TRegistro_ProdutoPDV> SelectProdutoPDV(TpBusca[] vBusca)
        {
            List<TRegistro_ProdutoPDV> lista = new List<TRegistro_ProdutoPDV>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProdutoPDV reg = new TRegistro_ProdutoPDV();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CODBARRA")))
                        reg.Cd_codbarra = reader.GetString(reader.GetOrdinal("CD_CODBARRA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("casasdecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("casasdecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_PrecoVenda")))
                        reg.Vl_precovenda = reader.GetDecimal(reader.GetOrdinal("VL_PrecoVenda"));
                    if(!reader.IsDBNull(reader.GetOrdinal("imgproduto")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("imgproduto")); 


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

        public List<TRegistro_ProdutoLocacao> SelectProdutoLocacao(TpBusca[] vBusca, string dt_locacao)
        {
            List<TRegistro_ProdutoLocacao> lista = new List<TRegistro_ProdutoLocacao>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaLocacao(vBusca, dt_locacao));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProdutoLocacao reg = new TRegistro_ProdutoLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaAssistencia")))
                        reg.Ds_tecnica = reader.GetString(reader.GetOrdinal("DS_TecnicaAssistencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("casasdecimais")))
                        reg.CasasDecimais = reader.GetDecimal(reader.GetOrdinal("casasdecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Patrimonio")))
                        reg.Nr_Patrimonio = reader.GetString(reader.GetOrdinal("NR_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horas = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_compra")))
                        reg.Vl_compra = reader.GetDecimal(reader.GetOrdinal("vl_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("Dt_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("StatusProduto")))
                        reg.StatusProduto = reader.GetString(reader.GetOrdinal("StatusProduto")); 

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

        public string Grava(TRegistro_CadProduto vRegistro)
        {
            Hashtable hs = new Hashtable(38);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_GRUPO", vRegistro.CD_Grupo);
            hs.Add("@P_DS_PRODUTO", vRegistro.DS_Produto);
            hs.Add("@P_CD_UNIDADE", vRegistro.CD_Unidade);
            hs.Add("@P_CD_MARCA", vRegistro.CD_Marca);
            hs.Add("@P_TP_PRODUTO", vRegistro.TP_Produto);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", vRegistro.CD_CondFiscal_Produto);
            hs.Add("@P_PS_UNITARIO", vRegistro.PS_Unitario);
            hs.Add("@P_SIGLA", vRegistro.Sigla);
            hs.Add("@P_PC_COMISSAO", vRegistro.Pc_Comissao);
            hs.Add("@P_TP_COMISSAO", vRegistro.Tp_comissao);
            hs.Add("@P_PS_EMBALAGEM", vRegistro.PS_Embalagem);
            hs.Add("@P_ST_TANQUEAEREO", vRegistro.ST_TanqueAereo);
            hs.Add("@P_DS_ABREVIADAPRODUTO", vRegistro.DS_AbreviadaProduto);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            hs.Add("@P_QT_DIAS_PRAZOGARANTIA", vRegistro.Qt_dias_PrazoGarantia);
            hs.Add("@P_DS_TECNICA", vRegistro.DS_Tecnica);
            hs.Add("@P_DS_TECNICAINTERNA", vRegistro.DS_TecnicaInterna);
            hs.Add("@P_DS_TECNICAASSISTENCIA", vRegistro.DS_TecnicaAssistencia);
            hs.Add("@P_CODIGO_ALTERNATIVO", vRegistro.Codigo_alternativo);
            hs.Add("@P_ST_EXIGIRSERIE", vRegistro.St_exigirserie);
            hs.Add("@P_ST_EXPBALANCA", vRegistro.St_expbalanca);
            hs.Add("@P_ST_PRODEXPORTADO", vRegistro.St_prodexportado);
            hs.Add("@P_ST_PESARPROD", vRegistro.St_pesarprod);
            hs.Add("@P_NCM", vRegistro.Ncm);
            hs.Add("@P_ID_GENERO", vRegistro.Id_genero);
            hs.Add("@P_ID_TPSERVICO", vRegistro.Id_tpservico);
            hs.Add("@P_TP_ITEM", vRegistro.Tp_item);
            hs.Add("@P_CD_ANP", vRegistro.Cd_anp);
            //hs.Add("@P_VL_CUSTOATUAL", vRegistro.Vl_custoatual);
            hs.Add("@P_TP_COMBUSTIVEL", vRegistro.Tp_combustivel);
            hs.Add("@P_REG_ANVISA", vRegistro.Reg_anvisa);
            hs.Add("@P_ST_RASTREAR", vRegistro.St_rastrear);
            hs.Add("@P_ST_INTEGRAECOMMERCE", vRegistro.St_integraecommerce);
            hs.Add("@P_ID_CELULA", vRegistro.Id_Celula);
            hs.Add("@P_ID_SECAO", vRegistro.Id_Secao);
            hs.Add("@P_ID_RUA", vRegistro.Id_Rua);
            hs.Add("@P_ID_CARACTERISTICAH", vRegistro.Id_caracteristicaH);
            hs.Add("@P_ID_CARACTERISTICAV", vRegistro.Id_caracteristicaV);
            hs.Add("@P_ID_LOCALIMP", vRegistro.id_localimp);
            hs.Add("@P_QT_COMBSABORES", vRegistro.qt_combsabores);
            return executarProc("IA_EST_PRODUTO", hs);
        }

        public string Deleta(TRegistro_CadProduto vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);

            return executarProc("EXCLUI_EST_PRODUTO", hs);
        }

        public bool ItemServico(string vCD_Produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + vCD_Produto.Trim() + "' " +
                "and isnull(b.st_servico, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoConsumoInterno(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_consumointerno, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoComposto(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_composto, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoPatrimonio(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_patrimonio, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoSemente(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_semente, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoFolhares(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.ST_Folhares, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoCombustivel(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_combustivel, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoLubrificante(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_lubrificante, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoIndustrializado(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_industrializado, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoMPrima(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.ST_MPrima, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoEmbalagem(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.ST_Embalagem, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public bool ProdutoRegAnvisa(string Cd_produto)
        {
            object obj = executarEscalar(
                "select 1 from tb_est_produto a " +
                "inner join tb_est_tpproduto b " +
                "on a.tp_produto = b.tp_produto " +
                "and a.cd_produto = '" + Cd_produto.Trim() + "' " +
                "and isnull(b.st_reganvisa, 'N') = 'S'", null);
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }
    }
    
    #endregion

    #region Classe Imagem Produto
    public class TList_CadProduto_Imagens : List<TRegistro_CadProduto_Imagens>, IComparer<TRegistro_CadProduto_Imagens>
    {
        #region IComparer<TRegistro_CadProduto_Imagens> Members
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

        public TList_CadProduto_Imagens()
        { }

        public TList_CadProduto_Imagens(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadProduto_Imagens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadProduto_Imagens x, TRegistro_CadProduto_Imagens y)
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
    
    public class TRegistro_CadProduto_Imagens
    {
        public decimal Id_imagem
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
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

        public TRegistro_CadProduto_Imagens()
        {
            Id_imagem = 0;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            imagem = null;
            img = null;
        }
    }

    public class TCD_CadProduto_Imagens : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.id_imagem, a.cd_produto, b.ds_produto, a.imagem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_PRODUTO_Imagens a ");
            sql.AppendLine(" inner join tb_est_produto b ");
            sql.AppendLine(" on a.cd_produto = b.cd_produto ");

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

        public TList_CadProduto_Imagens Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadProduto_Imagens lista = new TList_CadProduto_Imagens();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadProduto_Imagens reg = new TRegistro_CadProduto_Imagens();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Imagem")))
                        reg.Id_imagem = reader.GetDecimal(reader.GetOrdinal("ID_Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("Imagem"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_CadProduto_Imagens vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_ID_IMAGEM", vRegistro.Id_imagem);
            hs.Add("@P_IMAGEM", vRegistro.Img);

            return executarProc("IA_EST_PRODUTO_IMAGENS", hs);
        }

        public string Deleta(TRegistro_CadProduto_Imagens vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_IMAGEM", vRegistro.Id_imagem);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);

            return executarProc("EXCLUI_EST_PRODUTO_IMAGENS", hs);
        }
    }
    #endregion

    #region Classe Codigo Barra
    public class TList_CodBarra : List<TRegistro_CodBarra>, IComparer<TRegistro_CodBarra>
    {
        #region IComparer<TRegistro_CodBarra> Members
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

        public TList_CodBarra()
        { }

        public TList_CodBarra(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CodBarra value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CodBarra x, TRegistro_CodBarra y)
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

    public class TRegistro_CodBarra
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Referencia
        { get; set; }
        public string Cd_codbarra
        { get; set; }
        public decimal Vl_venda
        { get; set; }
        public decimal Quantidade
        { get; set; }

        public string cd_unidade
        { get; set; }

        public string ds_unidade
        { get; set; }

        public string uni
        { get; set; }

        public bool agregar { get; set; }
        public decimal Quantidade_agregar
        { get; set; }
        public TRegistro_CodBarra()
        {
            Quantidade_agregar = decimal.Zero;
            agregar = true;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Referencia = string.Empty;
            Cd_codbarra = string.Empty;
            Vl_venda = decimal.Zero;
            Quantidade = decimal.Zero;
            cd_unidade = string.Empty;
            ds_unidade = string.Empty;
            uni = string.Empty;
        }
    }

    public class TCD_CodBarra : TDataQuery
    {
        public TCD_CodBarra()
        { }

        public TCD_CodBarra(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.cd_produto, b.ds_produto, a.cd_codbarra, c.ds_unidade,c.cd_unidade,c.sigla_unidade ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_CodBarra a ");
            sql.AppendLine(" inner join tb_est_produto b ");
            sql.AppendLine(" on a.cd_produto = b.cd_produto ");
            sql.AppendLine(" left join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
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

        public TList_CodBarra Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CodBarra lista = new TList_CodBarra();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CodBarra reg = new TRegistro_CodBarra();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CodBarra")))
                        reg.Cd_codbarra = reader.GetString(reader.GetOrdinal("CD_CodBarra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.uni = reader.GetString(reader.GetOrdinal("sigla_unidade")); 

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CodBarra val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_CODBARRA", val.Cd_codbarra);

            return executarProc("IA_EST_CODBARRA", hs);
        }

        public string Excluir(TRegistro_CodBarra val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_CODBARRA", val.Cd_codbarra);

            return executarProc("EXCLUI_EST_CODBARRA", hs);
        }
    }
    #endregion

    #region Classe Ficha Tecnica Produto
    public class TList_FichaTecProduto : List<TRegistro_FichaTecProduto>, IComparer<TRegistro_FichaTecProduto>
    {
        #region IComparer<TRegistro_FichaTecProduto> Members
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

        public TList_FichaTecProduto()
        { }

        public TList_FichaTecProduto(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FichaTecProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FichaTecProduto x, TRegistro_FichaTecProduto y)
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
    
    public class TRegistro_FichaTecProduto
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_item
        { get; set; }
        public string Ds_item
        { get; set; }
        public string Cd_unditem
        { get; set; }
        public string Ds_unditem
        { get; set; }
        public string Sg_unditem
        { get; set; }
        public string Ncmitem
        { get; set; }
        public string Cestitem
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Quantidade_agregar
        { get; set; }
        public decimal Vl_custoservico
        { get; set; }
        public decimal Vl_subtotalservico
        { get { return Quantidade * Vl_custoservico; } }
        public decimal Vl_precovenda
        { get; set; }
        public decimal Vl_precovendatotal
        { get { return Quantidade * Vl_precovenda; } }

        public TRegistro_FichaTecProduto()
        {
            Quantidade_agregar = decimal.Zero;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_item = string.Empty;
            Ds_item = string.Empty;
            Cd_unditem = string.Empty;
            Ds_unditem = string.Empty;
            Sg_unditem = string.Empty;
            Ncmitem = string.Empty;
            Cestitem = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Quantidade = decimal.Zero;
            Vl_custoservico = decimal.Zero;
            Vl_precovenda = decimal.Zero;
        }
    }

    public class TCD_FichaTecProduto : TDataQuery
    {
        public TCD_FichaTecProduto()
        { }

        public TCD_FichaTecProduto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_produto, b.ds_produto, a.cd_item, ");
                sql.AppendLine("c.ds_produto as ds_item, c.cd_unidade as cd_unditem, ");
                sql.AppendLine("d.ds_unidade as ds_unditem, d.sigla_unidade as sg_unditem, ");
                sql.AppendLine("a.vl_custoservico, a.quantidade, c.ncm, e.cest, a.cd_local, f.ds_local ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_FichaTecProduto a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_item = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("left outer join TB_FIS_NCM e ");
            sql.AppendLine("on c.ncm = e.ncm ");
            sql.AppendLine("left outer join TB_EST_LocalArm f ");
            sql.AppendLine("on a.cd_local = f.cd_local ");

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

        public TList_FichaTecProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FichaTecProduto lista = new TList_FichaTecProduto();
            
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaTecProduto reg = new TRegistro_FichaTecProduto();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("cd_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unditem")))
                        reg.Cd_unditem = reader.GetString(reader.GetOrdinal("cd_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unditem")))
                        reg.Ds_unditem = reader.GetString(reader.GetOrdinal("ds_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_unditem")))
                        reg.Sg_unditem = reader.GetString(reader.GetOrdinal("sg_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncmitem = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cestitem = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("Cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("Ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_CustoServico")))
                        reg.Vl_custoservico = reader.GetDecimal(reader.GetOrdinal("Vl_CustoServico"));

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

        public string Gravar(TRegistro_FichaTecProduto val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_CUSTOSERVICO", val.Vl_custoservico);

            return executarProc("IA_EST_FICHATECPRODUTO", hs);
        }

        public string Excluir(TRegistro_FichaTecProduto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_ITEM", val.Cd_item);

            return executarProc("EXCLUI_EST_FICHATECPRODUTO", hs);
        }
    }
    #endregion

    #region Preço Item Ficha
    public class TList_PrecoItemFicha : List<TRegistro_PrecoItemFicha>, IComparer<TRegistro_PrecoItemFicha>
    {
        #region IComparer<TRegistro_PrecoItemFicha> Members
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

        public TList_PrecoItemFicha()
        { }

        public TList_PrecoItemFicha(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PrecoItemFicha value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PrecoItemFicha x, TRegistro_PrecoItemFicha y)
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

    public class TRegistro_PrecoItemFicha
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_item
        { get; set; }
        public string Ds_item
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public decimal Vl_venda
        { get; set; }

        public TRegistro_PrecoItemFicha()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_item = string.Empty;
            Ds_item = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Vl_venda = decimal.Zero;
        }
    }

    public class TCD_PrecoItemFicha : TDataQuery
    {
        public TCD_PrecoItemFicha()
        { }

        public TCD_PrecoItemFicha(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_produto, b.ds_produto, a.cd_item, ");
                sql.AppendLine("c.ds_produto as ds_item, c.cd_unidade as cd_unditem, a.CD_TabelaPreco, d.DS_TabelaPreco, a.Vl_Venda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_PrecoItemFicha a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_item = c.cd_produto ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco d ");
            sql.AppendLine("on a.CD_TabelaPreco = d.CD_TabelaPreco ");

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

        public TList_PrecoItemFicha Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PrecoItemFicha lista = new TList_PrecoItemFicha();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PrecoItemFicha reg = new TRegistro_PrecoItemFicha();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("cd_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("Cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("Ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_venda")))
                        reg.Vl_venda = reader.GetDecimal(reader.GetOrdinal("Vl_venda"));

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

        public string Gravar(TRegistro_PrecoItemFicha val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_VL_VENDA", val.Vl_venda);

            return executarProc("IA_EST_PRECOITEMFICHA", hs);
        }

        public string Excluir(TRegistro_PrecoItemFicha val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);

            return executarProc("EXCLUI_EST_PRECOITEMFICHA", hs);
        }
    }
    #endregion

    #region Classe Produto Qtde Estoque
    public class TList_Produto_QtdEstoque : List<TRegistro_Produto_QtdEstoque>, IComparer<TRegistro_Produto_QtdEstoque>
    {
        #region IComparer<TRegistro_Produto_QtdEstoque> Members
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

        public TList_Produto_QtdEstoque()
        { }

        public TList_Produto_QtdEstoque(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Produto_QtdEstoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Produto_QtdEstoque x, TRegistro_Produto_QtdEstoque y)
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
    
    public class TRegistro_Produto_QtdEstoque
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal Qt_min_estoque
        { get; set; }
        public decimal Qt_max_estoque
        { get; set; }

        public TRegistro_Produto_QtdEstoque()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Qt_max_estoque = decimal.Zero;
            Qt_min_estoque = decimal.Zero;
        }
    }

    public class TCD_Produto_QtdEstoque : TDataQuery
    {
        public TCD_Produto_QtdEstoque()
        { }

        public TCD_Produto_QtdEstoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Produto, b.DS_Produto, c.Sigla_Unidade, ");
                sql.AppendLine("a.CD_Empresa, d.NM_Empresa, a.QT_Max_Estoque, a.QT_Min_Estoque ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Produto_QTDEstoque a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.CD_Empresa = d.CD_Empresa ");

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

        public TList_Produto_QtdEstoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Produto_QtdEstoque lista = new TList_Produto_QtdEstoque();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Produto_QtdEstoque reg = new TRegistro_Produto_QtdEstoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_min_estoque")))
                        reg.Qt_min_estoque = reader.GetDecimal(reader.GetOrdinal("qt_min_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_max_estoque")))
                        reg.Qt_max_estoque = reader.GetDecimal(reader.GetOrdinal("qt_max_estoque"));

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

        public string Gravar(TRegistro_Produto_QtdEstoque val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_QT_MIN_ESTOQUE", val.Qt_min_estoque);
            hs.Add("@P_QT_MAX_ESTOQUE", val.Qt_max_estoque);

            return executarProc("IA_EST_PRODUTO_QTDESTOQUE", hs);
        }

        public string Excluir(TRegistro_Produto_QtdEstoque val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_EST_PRODUTO_QTDESTOQUE", hs);
        }
    }
    #endregion

    #region Classe Produto X Fornecedor
    public class TList_Produto_X_Fornecedor : List<TRegistro_Produto_X_Fornecedor>
    { }
    
    public class TRegistro_Produto_X_Fornecedor
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public string Codigo_fornecedor
        { get; set; }
        public string Cd_unidade_fornec
        { get; set; }
        public string Ds_unidade_fornec
        { get; set; }
        public string Sigla_unidade_fornec
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }

        public TRegistro_Produto_X_Fornecedor()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_fornecedor = string.Empty;
            Nm_fornecedor = string.Empty;
            Codigo_fornecedor = string.Empty;
            Cd_unidade_fornec = string.Empty;
            Ds_unidade_fornec = string.Empty;
            Sigla_unidade_fornec = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
        }
    }

    public class TCD_Produto_X_Fornecedor : TDataQuery
    {
        public TCD_Produto_X_Fornecedor() { }

        public TCD_Produto_X_Fornecedor(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Produto, b.DS_Produto, ");
                sql.AppendLine("a.CD_Fornecedor, c.nm_clifor as NM_Fornecedor, a.Codigo_fornecedor, ");
                sql.AppendLine("a.cd_unidade_fornec, d.ds_unidade as ds_unidade_fornec, ");
                sql.AppendLine("d.sigla_unidade as sigla_unidade_fornec, a.cd_local, local.ds_local ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Produto_X_Fornecedor a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_fornecedor = c.CD_Clifor ");
            sql.AppendLine("left outer join TB_EST_Unidade d ");
            sql.AppendLine("on a.cd_unidade_fornec = d.cd_unidade ");
            sql.AppendLine("left outer join TB_EST_LocalArm local ");
            sql.AppendLine("on a.cd_local = local.cd_local ");

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

        public TList_Produto_X_Fornecedor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Produto_X_Fornecedor lista = new TList_Produto_X_Fornecedor();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Produto_X_Fornecedor reg = new TRegistro_Produto_X_Fornecedor();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("cd_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("codigo_fornecedor")))
                        reg.Codigo_fornecedor = reader.GetString(reader.GetOrdinal("codigo_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade_fornec")))
                        reg.Cd_unidade_fornec = reader.GetString(reader.GetOrdinal("cd_unidade_fornec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade_fornec")))
                        reg.Ds_unidade_fornec = reader.GetString(reader.GetOrdinal("ds_unidade_fornec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade_fornec")))
                        reg.Sigla_unidade_fornec = reader.GetString(reader.GetOrdinal("sigla_unidade_fornec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));

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

        public string Gravar(TRegistro_Produto_X_Fornecedor val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CODIGO_FORNECEDOR", val.Codigo_fornecedor);
            hs.Add("@P_CD_UNIDADE_FORNEC", val.Cd_unidade_fornec);
            hs.Add("@P_CD_LOCAL", val.Cd_local);

            return executarProc("IA_EST_PRODUTO_X_FORNECEDOR", hs);
        }

        public string Excluir(TRegistro_Produto_X_Fornecedor val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CODIGO_FORNECEDOR", val.Codigo_fornecedor);

            return executarProc("EXCLUI_EST_PRODUTO_X_FORNECEDOR", hs);
        }
    }
    #endregion

    #region Atualiza Preco Percentual
    public class TList_AtualizaPrecoPerc : List<TRegistro_AtualizaPrecoPerc>, IComparer<TRegistro_AtualizaPrecoPerc>
    {
        #region IComparer<TRegistro_AtualizaPrecoPerc> Members
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

        public TList_AtualizaPrecoPerc()
        { }

        public TList_AtualizaPrecoPerc(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AtualizaPrecoPerc value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AtualizaPrecoPerc x, TRegistro_AtualizaPrecoPerc y)
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

    public class TRegistro_AtualizaPrecoPerc
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public decimal Pc_ajuste
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_AtualizaPrecoPerc()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Pc_ajuste = decimal.Zero;
            St_processar = false;
        }
    }

    public class TCD_AtualizaPrecoPerc : TDataQuery
    {
        public TCD_AtualizaPrecoPerc()
        { }

        public TCD_AtualizaPrecoPerc(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + "a.cd_empresa, emp.nm_empresa, a.cd_produto, b.ds_produto, a.cd_tabelapreco, c.ds_tabelapreco, a.pc_ajuste ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_AtualizaPrecoPerc a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco c ");
            sql.AppendLine("on c.cd_tabelapreco = a.cd_tabelapreco ");

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

        public TList_AtualizaPrecoPerc Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AtualizaPrecoPerc lista = new TList_AtualizaPrecoPerc();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AtualizaPrecoPerc reg = new TRegistro_AtualizaPrecoPerc();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_ajuste")))
                        reg.Pc_ajuste = reader.GetDecimal(reader.GetOrdinal("Pc_ajuste"));

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

        public string Gravar(TRegistro_AtualizaPrecoPerc val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_PC_AJUSTE", val.Pc_ajuste);

            return executarProc("IA_EST_ATUALIZAPRECOPERC", hs);
        }

        public string Excluir(TRegistro_AtualizaPrecoPerc val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);

            return executarProc("EXCLUI_EST_ATUALIZAPRECOPERC", hs);
        }
    }
    #endregion

    #region Ficha OP
    public class TList_FichaOP:List<TRegistro_FichaOP>, IComparer<TRegistro_FichaOP>
    {
        #region IComparer<TRegistro_FichaOP> Members
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

        public TList_FichaOP()
        { }

        public TList_FichaOP(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FichaOP value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FichaOP x, TRegistro_FichaOP y)
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

    public class TRegistro_FichaOP
    {
        public string Cd_produto { get; set; }
        public int Id_item { get; set; }
        public string Ds_item { get; set; }
        public int Quantidade { get; set; }
        public int DiasPrevisao { get; set; }
        private string tp_item = string.Empty;
        public string Tp_item
        {
            get { return tp_item; }
            set
            {
                tp_item = value;
                if (value.Trim().ToUpper().Equals("U"))
                    tipo_item = "USINAGEM";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_item = "ACESSORIOS";
            }
        }
        private string tipo_item = string.Empty;
        public string Tipo_item
        {
            get { return tipo_item; }
            set
            {
                tipo_item = value;
                if (value.Trim().ToUpper().Equals("USINAGEM"))
                    tp_item = "U";
                else if (value.Trim().ToUpper().Equals("ACESSORIOS"))
                    tp_item = "A";
            }
        }
        public DateTime? Dt_prevProducao { get; set; } = null;
    }

    public class TCD_FichaOP:TDataQuery
    {
        public TCD_FichaOP() { }

        public TCD_FichaOP(TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Produto, a.ID_Item, ");
                sql.AppendLine("a.DS_Item, a.Quantidade, a.DiasPrevisto, a.TP_Item ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_FichaOP a ");

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

        public TList_FichaOP Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FichaOP lista = new TList_FichaOP();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaOP reg = new TRegistro_FichaOP();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetInt32(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasprevisto")))
                        reg.DiasPrevisao = reader.GetInt32(reader.GetOrdinal("diasprevisto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_item")))
                        reg.Tp_item = reader.GetString(reader.GetOrdinal("tp_item"));

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

        public string Gravar(TRegistro_FichaOP val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_DS_ITEM", val.Ds_item);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_DIASPREVISTO", val.DiasPrevisao);
            hs.Add("@P_TP_ITEM", val.Tp_item);

            return executarProc("IA_EST_FICHAOP", hs);
        }

        public string Excluir(TRegistro_FichaOP val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_EST_FICHAOP", hs);
        }
    }
    #endregion
}

