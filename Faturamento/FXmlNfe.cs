using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Faturamento
{
    public partial class TFXmlNfe : Form
    {
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFaturamento;
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rfaturamento
        {
            get
            {
                if (bsNotaFiscal.Current != null)
                    return bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                else
                    return null;
            }
            set
            { rFaturamento = value; }
        }
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItem;
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item ritem
        {
            get
            {
                if (bsItensNota.Current != null)
                    return bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item;
                else
                    return null;
            }
            set
            { rItem = value; }
        }
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rInf;
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rINF
        {
            get
            {
                if (bsImpostosItens.Current != null)
                    return bsImpostosItens.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF;
                else
                    return null;
            }
            set
            { rInf = value; }
        }
        public TFXmlNfe()
        {
            InitializeComponent();
        }

        private void ImportarXML()
        {
            //Pedir caminho do arquivo a ser importado
            using (OpenFileDialog op = new OpenFileDialog())
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    //Ler  arquivo do Path
                    if (System.IO.File.Exists(op.FileName))
                    {
                        bsNotaFiscal.AddNew();
                        XmlDocument xml = new XmlDocument();
                        xml.Load(@op.FileName);

                        #region NFE
                        //Numero da nota
                        nNFe.Text = decimal.Parse(xml["nfeProc"]["NFe"]["infNFe"]["ide"]["nNF"].InnerText).ToString();
                        //Modelo
                        modelo.Text = decimal.Parse(xml["nfeProc"]["NFe"]["infNFe"]["ide"]["mod"].InnerText).ToString();
                        //Série da nota
                        serie.Text = decimal.Parse(xml["nfeProc"]["NFe"]["infNFe"]["ide"]["serie"].InnerText).ToString();
                        //Operação
                        operacao.Text = xml["nfeProc"]["NFe"]["infNFe"]["ide"]["natOp"].InnerText;
                        //Finalidade
                        finalidade.Text = decimal.Parse(xml["nfeProc"]["NFe"]["infNFe"]["ide"]["finNFe"].InnerText).ToString();
                        //Chave de acesso
                        chaveAcesso.Text = xml["nfeProc"]["NFe"]["infNFe"].GetAttribute("Id").Replace("NFe", string.Empty);
                        //Ambiente
                        ambiente.Text = decimal.Parse(xml["nfeProc"]["NFe"]["infNFe"]["ide"]["tpAmb"].InnerText).ToString();
                        //Nome emitente
                        razaoSocial.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["xNome"].InnerText;
                        //Nome fantasia
                        fantasia.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["xFant"].InnerText;
                        //Endereço emitente
                        endereco.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["xLgr"].InnerText;
                        //Numero emitente
                        numero.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["nro"].InnerText;
                        //Bairro
                        bairro.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["xBairro"].InnerText;
                        //Municipio
                        municipio.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["xMun"].InnerText;
                        //UF
                        uf.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["UF"].InnerText;
                        //CEP
                        cep.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["CEP"].InnerText;
                        //Pais
                        pais.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["xPais"].InnerText;
                        //Telefone
                        telefone.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["enderEmit"]["fone"].InnerText;
                        //Inscrição Estadual
                        inscricaoEstadual.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["IE"].InnerText;
                        //CNPJ
                        cnpj.Text = xml["nfeProc"]["NFe"]["infNFe"]["emit"]["CNPJ"].InnerText;
                        //Verificar se Fornecedor existe 
                        string format = cnpj.Text;
                        string cnpjMask = Convert.ToUInt64(format).ToString(@"00\.000\.000\/0000\-00");
                        object empresaDest = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_clifor_PJ x " +
                                            "where x.cd_clifor = a.cd_clifor " +
                                            "and x.nr_cgc = '" + cnpjMask.Trim() + "')"
                            }
                        }, "1");
                        if (empresaDest == null)
                        {
                            MessageBox.Show("Fornecedor nâo cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bb_cadclifor.Enabled = true;
                        }
                        #endregion

                        #region Itens da nota
                        //Itens da nota
                        foreach (XmlElement e in xml["nfeProc"]["NFe"]["infNFe"].ChildNodes)
                        {
                            if (e.Name.Trim().ToUpper().Equals("DET"))
                            {
                                bsItensNota.AddNew();
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item item = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                                //Numero da nota
                                ritem.Nr_notafiscal = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_notafiscal.Value;
                                //Item
                                ritem.Id_nfitem = decimal.Parse(e.GetAttribute("nItem"));
                                //Código Produto
                                ritem.Cd_produto = e["prod"]["cProd"].InnerText;
                                //Produto
                                ritem.Ds_produto = e["prod"]["xProd"].InnerText;
                                //Unidade
                                ritem.Ds_unidade = e["prod"]["uCom"].InnerText;
                                //NCM
                                ritem.Cd_ncm = e["prod"]["NCM"].InnerText;
                                //CFOP
                                ritem.Cd_cfop = e["prod"]["CFOP"].InnerText;
                                //Quantidade
                                ritem.Quantidade = Convert.ToDecimal(e["prod"]["qCom"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                //Unitario
                                ritem.Vl_unitario = Convert.ToDecimal(e["prod"]["vUnCom"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                //Vl.SubTotal
                                ritem.Vl_subtotal = Convert.ToDecimal(e["prod"]["vProd"].InnerText, new System.Globalization.CultureInfo("en-US"));

                                

                                #region Impostos Itens NFe

                                #region Consultas

                                
                                //Busca empresa Destinatario
                                CamadaDados.Diversos.TList_CadEmpresa empresa = null;
                                try
                                {
                                    string formatado = xml["nfeProc"]["NFe"]["infNFe"]["dest"]["CNPJ"].InnerText;
                                    string cnpjFormat = Convert.ToUInt64(formatado).ToString(@"00\.000\.000\/0000\-00");
                                    empresa = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                       new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_DIV_Empresa a " +
                                                        "inner join TB_FIN_Clifor_PJ b " +
                                                        "on a.CD_Clifor = b.CD_Clifor " +
                                                        "where b.NR_CGC  = '" + cnpjFormat.Trim() + "')"
                                           
                                        }
                                    }, 0, "a.cd_empresa");
                                }
                                catch { }
                                #endregion

                                #region ICMS
                                bsImpostosItens.AddNew();
                                object impostoICMS = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "st_icms",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                    }, "a.cd_imposto");

                                object ds_ICMS = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                  new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_icms",
                                            vOperador = "=",
                                            vVL_Busca = "0"   

                                        }
                                    }, "a.ds_imposto");
                                 //IMPOSTOS PRODUTOS E SERVIÇOS
                                //ICMS
                                //ICMS00
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //Cd.St
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS00"]["CST"].InnerText;
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS00"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS00"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS00"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS10
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS10"]["CST"].InnerText;
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC do ICMS ST
                                    rINF.Pc_reducaobasecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["pRedBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor da BC do ICMS ST
                                    rINF.Vl_basecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Alíquota do imposto do ICMS ST
                                    rINF.Pc_aliquotasubst = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["pICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST 
                                    rINF.Vl_impostosubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS10"]["vICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS20
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS20"]["CST"].InnerText;
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS20"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS20"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS20"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC
                                    rINF.Pc_reducaobasecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS20"]["pRedBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS30
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS30"]["CST"].InnerText;
                                    //Percentual da Redução de BC do ICMS ST
                                    rINF.Pc_reducaobasecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS30"]["pRedBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor da BC do ICMS ST
                                    rINF.Vl_basecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS30"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Alíquota do imposto do ICMS ST
                                    rINF.Pc_aliquotasubst = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS30"]["pICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST 
                                    rINF.Vl_impostosubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS30"]["vICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS40
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS40"]["CST"].InnerText;
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS40"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS51
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS51"]["CST"].InnerText;
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS51"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS51"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS51"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC
                                    rINF.Pc_reducaobasecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS51"]["pRedBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS60
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS60"]["CST"].InnerText;
                                    //Valor da BC do ICMS ST retido
                                    //rINF.vl = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS60"]["vBCSTRet"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST retido
                                    rINF.Vl_impostoretido = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS60"]["vICMSSTRet"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS70
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS70"]["CST"].InnerText;
                                    //Percentual da Redução de BC
                                    rINF.Pc_reducaobasecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["pRedBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC do ICMS ST
                                    rINF.Pc_reducaobasecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["pRedBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor da BC do ICMS ST
                                    rINF.Vl_basecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Alíquota do imposto do ICMS ST
                                    rINF.Pc_aliquotasubst = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["pICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST 
                                    rINF.Vl_impostosubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS70"]["vICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMS90
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMS90"]["CST"].InnerText;
                                    //Percentual da Redução de BC
                                    rINF.Pc_reducaobasecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["pRedBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC do ICMS ST
                                    rINF.Pc_reducaobasecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS90"]["ICMS90"]["pRedBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor da BC do ICMS ST
                                    rINF.Vl_basecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Alíquota do imposto do ICMS ST
                                    rINF.Pc_aliquotasubst = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["pICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST 
                                    rINF.Vl_impostosubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMS90"]["vICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMSPart
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMSPart"]["CST"].InnerText;
                                    //Percentual da Redução de BC
                                    rINF.Pc_reducaobasecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["pRedBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Base Cálculo
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["pICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.ICMS 
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual da Redução de BC do ICMS ST
                                    rINF.Pc_reducaobasecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMSPart"]["ICMSPart"]["pRedBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor da BC do ICMS ST
                                    rINF.Vl_basecalcsubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Alíquota do imposto do ICMS ST
                                    rINF.Pc_aliquotasubst = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["pICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Valor do ICMS ST 
                                    rINF.Vl_impostosubsttrib = Convert.ToDecimal(e["imposto"]["ICMS"]["ICMSPart"]["vICMSST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //ICMSST
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //Cd Imposto
                                    rINF.Cd_impostostr = impostoICMS.ToString();
                                    //Ds_imposto
                                    rINF.Ds_imposto = ds_ICMS.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CD.ST
                                    rINF.Cd_st = e["imposto"]["ICMS"]["ICMSST"]["CST"].InnerText;
                                }
                                catch { }
                                
                                 #endregion

                                #region PIS
                                 bsImpostosItens.AddNew();
                                object impostoPis = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                  new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_pis",
                                            vOperador = "=",
                                            vVL_Busca = "0"   

                                        }
                                    }, "a.cd_imposto");
                                 object DS_pis = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                  new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_pis",
                                            vOperador = "=",
                                            vVL_Busca = "0"   

                                        }
                                    }, "a.ds_imposto");

                                //PISNT
                                try
                                {
                                     //Empresa
                                     try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                     catch { }
                                     //Cd Imposto
                                     rINF.Cd_impostostr = impostoPis.ToString();
                                     //Ds_imposto
                                     rINF.Ds_imposto = DS_pis.ToString();
                                     //ID ITEM
                                     rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                     //CST PIS
                                     rINF.Cd_st = e["imposto"]["PIS"]["PISNT"]["CST"].InnerText;

                                }
                                catch { }

                                     //PISOutr
                                 try
                                 {
                                     try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                     catch { }
                                     //CD imposto
                                     rINF.Cd_impostostr = impostoPis.ToString();
                                     //Ds_imposto
                                     rINF.Ds_imposto = DS_pis.ToString();
                                     //ID ITEM
                                     rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                     //CST PIS
                                     rINF.Cd_st = e["imposto"]["PIS"]["PISOutr"]["CST"].InnerText;
                                     //Vl.Base.Calc
                                     rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISOutr"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Percentual Aliquota
                                     rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["PIS"]["PISOutr"]["pPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Vl.PIS
                                     rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISOutr"]["vPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                     //PISAliq
                                 try
                                 {
                                     //Empresa
                                     try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                     catch { }
                                     //CD imposto
                                     rINF.Cd_impostostr = impostoPis.ToString();
                                     //Ds_imposto
                                     rINF.Ds_imposto = DS_pis.ToString();
                                     //ID ITEM
                                     rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                     //CST PIS
                                     rINF.Cd_st = e["imposto"]["PIS"]["PISAliq"]["CST"].InnerText;
                                     //Vl.Base.Calc
                                     rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISAliq"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Percentual Aliquota
                                     rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["PIS"]["PISAliq"]["pPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Vl.PIS
                                     rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISAliq"]["vPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                 
                                }
                                catch { }

                                //PISST
                              try
                              {
                                     //Empresa
                                     try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                     catch { }
                                     //CD imposto
                                     rINF.Cd_impostostr = impostoPis.ToString();
                                     //Ds_imposto
                                     rINF.Ds_imposto = DS_pis.ToString();
                                     //ID ITEM
                                     rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                     //CST PIS
                                     rINF.Cd_st = e["imposto"]["PIS"]["PISST"]["CST"].InnerText;
                                     //Vl.Base.Calc
                                     rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISST"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Percentual Aliquota
                                     rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["PIS"]["PISST"]["pPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                     //Vl.PIS
                                     rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["PIS"]["PISST"]["vPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                 
                               }
                               catch { }
                               
                                 #endregion

                                #region COFINS
                                bsImpostosItens.AddNew();
                                //Buscar Imposto
                                object impostoCofins = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                  new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_cofins",
                                            vOperador = "=",
                                            vVL_Busca = "0"   

                                        }
                                    }, "a.cd_imposto");
                                object DS_cofins = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                  new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_cofins",
                                            vOperador = "=",
                                            vVL_Busca = "0"   

                                        }
                                    }, "a.ds_imposto");
                                //COFINSNT
                                try 
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //DS Imposto
                                    rINF.Ds_imposto = DS_cofins.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CST COFINS
                                    rINF.Cd_st = e["imposto"]["COFINS"]["COFINSNT"]["CST"].InnerText;
                                }
                                catch { }
                                //COFINSAliq
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //CD Imposto
                                    rINF.Cd_impostostr = impostoCofins.ToString();
                                    //DS Imposto
                                    rINF.Ds_imposto = DS_cofins.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CST
                                    rINF.Cd_st = e["imposto"]["COFINS"]["COFINSAliq"]["CST"].InnerText;
                                    //Vl.Base.Calc
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSAliq"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSAliq"]["pCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.PIS
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSAliq"]["vCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }

                                //COFINSOutr
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //CD imposto
                                    rINF.Cd_impostostr = impostoCofins.ToString();
                                    //DS Imposto
                                    rINF.Ds_imposto = DS_cofins.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CST PIS
                                    rINF.Cd_st = e["imposto"]["COFINS"]["COFINSOutr"]["CST"].InnerText;
                                    //Vl.Base.Calc
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSOutr"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSOutr"]["pCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.PIS
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSOutr"]["vCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                                //COFINSAliq
                                try
                                {
                                    //Empresa
                                    try { rINF.Cd_empresa = empresa[0].Cd_empresa.Trim(); }
                                    catch { }
                                    //CD imposto
                                    rINF.Cd_impostostr = impostoCofins.ToString();
                                    //DS Imposto
                                    rINF.Ds_imposto = DS_cofins.ToString();
                                    //ID ITEM
                                    rINF.Id_nfitem = (bsItensNota.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem;
                                    //CST PIS
                                    rINF.Cd_st = e["imposto"]["COFINS"]["COFINSST"]["CST"].InnerText;
                                    //Vl.Base.Calc
                                    rINF.Vl_basecalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSST"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Percentual Aliquota
                                    rINF.Pc_aliquota = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSST"]["pCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                    //Vl.PIS
                                    rINF.Vl_impostocalc = Convert.ToDecimal(e["imposto"]["COFINS"]["COFINSST"]["vCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                                catch { }
                               
                                #endregion

                                #endregion

                            }
                        }
                        #endregion

                        #region Frete
                        //FRETE

                        //Modadidade
                        modFrete.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["modFrete"].InnerText;
                        //Grupo Transporta
                        try
                        {
                            //Razao Social
                            rSocial.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["xNome"].InnerText;
                            try
                            {
                                //CNPJ
                                cnpjCpf.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["CNPJ"].InnerText;
                            }
                            //CPF
                            catch { cnpjCpf.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["CPF"].InnerText; }
                            //IE
                            iEstadual.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["IE"].InnerText;
                            //Endereço
                            end.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["xEnder"].InnerText;
                            //Cidade
                            cidade.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["xMun"].InnerText;
                            //Estado
                            estado.Text = xml["nfeProc"]["NFe"]["infNFe"]["transp"]["transporta"]["UF"].InnerText;
                        }
                        catch { }

                        //Grupo Veiculo
                        try
                        {
                            //Placa
                            placa.Text = xml["nfeProc"]["NFe"]["infNFe"]["veicTransp"]["placa"].InnerText;
                            //Grupo Volume
                            //QTD
                            quantidade.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["vol"]["qVol"].InnerText);
                            //Especie
                            especie.Text = xml["nfeProc"]["NFe"]["infNFe"]["vol"]["esp"].InnerText;
                            //Peso Bruto
                            pesobruto.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["vol"]["pesoB"].InnerText);
                            //Peso Liquido
                            pesoLiq.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["vol"]["pesoL"].InnerText);
                        }
                        catch { }
                        #endregion

                        #region Cálculo Total de Impostos/Inf.Adicionais

                        //Cálculo Total de  Impostos

                        //Vl.Base Calc ICMS
                        bc_Icms.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vBC"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Vl.ICMS
                        icms.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vICMS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Base Cálc ICMS ST
                        bcIcmsSt.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vBCST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //ICMS ST
                        icmsSt.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vST"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Vl.Produtos
                        vlProdutos.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vProd"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Vl.Frete
                        frete.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vFrete"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Vl.Seguro
                        seguro.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vSeg"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Desconto
                        desconto.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vDesc"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Total II
                        totalII.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vII"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Total IPI
                        totalIPI.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vIPI"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Total PIS
                        totalPIS.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vPIS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Total COFINS
                        totaCofins.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vCOFINS"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        // Outras Despesas
                        despesas.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vOutro"].InnerText, new System.Globalization.CultureInfo("en-US"));
                        //Total Nota
                        vlNota.Value = Convert.ToDecimal(xml["nfeProc"]["NFe"]["infNFe"]["total"]["ICMSTot"]["vNF"].InnerText, new System.Globalization.CultureInfo("en-US"));

                        //INFORMAÇÕES ADICIONAIS
                        try
                        {
                            //Observação Fiscal
                            obsFiscal.Text = xml["nfeProc"]["NFe"]["infNFe"]["infAdic"]["infAdFisco"].InnerText;
                            //Dados Adicionais
                            dadosAdc.Text = xml["nfeProc"]["NFe"]["infNFe"]["infAdic"]["infCpl"].InnerText;
                        }
                        catch { }
                        #endregion

                    }
                }
            }
        }

        private void TFXmlNfe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
                this.ImportarXML();
        }

        private void TFXmlNfe_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void bsItensNota_PositionChanged(object sender, EventArgs e)
        {
            
        }

        private void bb_Importar_Click(object sender, EventArgs e)
        {
            this.ImportarXML();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.GravarClifor(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.GravarClifor(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
        }
    }
}
