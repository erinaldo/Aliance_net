using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFImportarNFeCTe : Form
    {
        private bool St_cidadeEmitexiste = false;
        private bool St_cidadeDestexiste = false;

        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rEmitente;
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndEmit;
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rDestinatario;
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndDest;

        public string File_xml { get; set; }
        public string Chave_acesso_nfe
        { get { return chave_acesso_nfe.Text; } }
        public string Cd_remetente
        {
            get
            {
                if (rbEmitRemetenteCTe.Checked)
                    return cd_emit.Text;
                else if (rbDestRemetenteCTe.Checked)
                    return cd_dest.Text;
                else return string.Empty;
            }
        }
        public string Cd_endremetente
        {
            get
            {
                if (rbEmitRemetenteCTe.Checked)
                    return cd_endereco_emit.Text;
                else if (rbDestRemetenteCTe.Checked)
                    return cd_endereco_dest.Text;
                else return string.Empty;
            }
        }
        public string Cd_destinatario
        {
            get
            {
                if (rbEmitDestinatarioCTe.Checked)
                    return cd_emit.Text;
                else if (rbDestDestinatarioCTe.Checked)
                    return cd_dest.Text;
                else return string.Empty;
            }
        }
        public string Cd_enddestinatario
        {
            get
            {
                if (rbEmitDestinatarioCTe.Checked)
                    return cd_endereco_emit.Text;
                else if (rbDestDestinatarioCTe.Checked)
                    return cd_endereco_dest.Text;
                else return string.Empty;
            }
        }
        public string Lacres
        {
            get
            {
                if (lbLacre.Items.Count > 0)
                {
                    string ret = string.Empty;
                    string p = string.Empty;
                    foreach (string s in lbLacre.Items)
                    {
                        ret += p + s;
                        p = "|";
                    }
                    return ret;
                }
                else return string.Empty;
            }
        }
        public string Produto_predominante
        { get { return ds_produtoPred.Text; } }
        public string Sigla_unidade
        { get { return unidade.Text; } }
        public decimal Qtd_carga
        { get { return qtd_carga.Value; } }
        public decimal Valor_carga
        { get { return Vl_carga.Value; } }

        public TFImportarNFeCTe()
        {
            InitializeComponent();
        }

        public void afterGrava()
        {
            if ((rbEmitRemetenteCTe.Checked || rbEmitDestinatarioCTe.Checked) &&
                string.IsNullOrEmpty(cd_emit.Text))
            {
                MessageBox.Show("Obrigatório cadastrar emitente NFe para utiliza-lo na emissão CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((rbDestRemetenteCTe.Checked || rbDestDestinatarioCTe.Checked) &&
                string.IsNullOrEmpty(cd_dest.Text))
            {
                MessageBox.Show("Obrigatório cadastrar destinatario NFe para utiliza-lo na emissão CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFImportarNFeCTe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Leitura do arquivo XML
            XmlDocument xml = new XmlDocument();
            xml.Load(File_xml);
            XmlNodeList lNo = xml.GetElementsByTagName("infNFe");
            if (lNo.Count > 0)
                chave_acesso_nfe.Text = lNo[0].Attributes.GetNamedItem("Id").InnerText.Remove(0, 3);
            else MessageBox.Show("XML Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #region Identificação NFe
            lNo = xml.GetElementsByTagName("ide");
            if (lNo.Count > 0)
            {
                string tp_mov = string.Empty;
                foreach(XmlNode no in lNo[0].ChildNodes)
                    if (no.LocalName.Equals("tpNF"))
                    {
                        tp_mov = no.InnerText;
                        break;
                    }
                if (tp_mov.Equals("0"))//Entrada
                {
                    rbEmitDestinatarioCTe.Checked = true;
                    rbDestRemetenteCTe.Checked = true;
                }
                else
                {
                    rbEmitRemetenteCTe.Checked = true;
                    rbDestDestinatarioCTe.Checked = true;
                }
            }
            #endregion

            #region Emitente NFe
            lNo = xml.GetElementsByTagName("emit");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("CNPJ"))
                        cnpj_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("CPF"))
                        cpf_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("xNome"))
                        razao_social_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("xFant"))
                        fantasia_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("IE"))
                        inscricao_estadual_emit.Text = no.InnerText;
                }
                //Buscar fornecedor
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.IsNullOrEmpty(cnpj_emit.Text.SoNumero()) ? string.Empty : cnpj_emit.Text,
                                                                                  string.IsNullOrEmpty(cpf_emit.Text.SoNumero()) ? string.Empty : cpf_emit.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  null);
                if (lFornec.Count > 0)
                {
                    rEmitente = lFornec[0];
                    cd_emit.Text = lFornec[0].Cd_clifor;
                    if (razao_social_emit.Text.Trim().ToUpper() != lFornec[0].Nm_clifor.Trim().ToUpper())
                        razao_social_emit.ForeColor = Color.Red;
                    if (fantasia_emit.Text.Trim().ToUpper() != lFornec[0].Nm_fantasia.Trim().ToUpper())
                        fantasia_emit.ForeColor = Color.Red;
                }
            }
            #endregion

            #region Endereco Emitente NFe
            lNo = xml.GetElementsByTagName("enderEmit");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("xLgr"))
                        ds_endereco_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("nro"))
                        numero_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("xCpl"))
                        complemento_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("xBairro"))
                        bairro_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("cMun"))
                    {
                        cd_cidade_emit.Text = no.InnerText;
                        if (new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_cidade",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_cidade_emit.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                        {
                            cd_cidade_emit.ForeColor = Color.Red;
                            St_cidadeEmitexiste = false;
                        }
                        else
                        {
                            cd_cidade_emit.ForeColor = Color.Black;
                            St_cidadeEmitexiste = true;
                        }
                    }
                    else if (no.LocalName.Equals("xMun"))
                        ds_cidade_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("CEP"))
                        cep_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("fone"))
                        fone_emit.Text = no.InnerText;
                    else if (no.LocalName.Equals("UF"))
                        uf_emit.Text = no.InnerText;
                }
                //Buscar endereco fornecedor
                if (!string.IsNullOrEmpty(cd_emit.Text))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_emit.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.IsNullOrEmpty(cep_emit.Text.SoNumero()) ? string.Empty : cep_emit.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  null);
                    if (lEnd.Count > 0)
                    {
                        rEndEmit = lEnd[0];
                        cd_endereco_emit.Text = lEnd[0].Cd_endereco;
                        if (cep_emit.Text.Trim() != lEnd[0].Cep.Trim())
                            cep_emit.ForeColor = Color.Red;
                        if (ds_endereco_emit.Text.Trim().ToUpper() != lEnd[0].Ds_endereco.Trim().ToUpper())
                            ds_endereco_emit.ForeColor = Color.Red;
                        if (numero_emit.Text.Trim() != lEnd[0].Numero.Trim())
                            numero_emit.ForeColor = Color.Red;
                        if (complemento_emit.Text.Trim().ToUpper() != lEnd[0].Ds_complemento.Trim().ToUpper())
                            complemento_emit.ForeColor = Color.Red;
                        if (bairro_emit.Text.Trim().ToUpper() != lEnd[0].Bairro.Trim().ToUpper())
                            bairro_emit.ForeColor = Color.Red;
                        if (fone_emit.Text.Trim() != lEnd[0].Fone.Trim())
                            fone_emit.ForeColor = Color.Red;
                        if (inscricao_estadual_emit.Text.Trim() != lEnd[0].Insc_estadual.Trim())
                            inscricao_estadual_emit.ForeColor = Color.Red;
                        uf_emit.Text = lEnd[0].UF;
                        cd_uf_emit.Text = lEnd[0].Cd_uf;
                    }
                    else
                    {
                        //Buscar sem filtro CEP
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca =  "'" + cd_emit.Text + "'",
                                                }
                                            }, 1, string.Empty);

                        if (lEndereco.Count > 0)
                        {
                            cd_endereco_emit.Text = lEndereco[0].Cd_endereco;
                            if (cep_emit.Text.Trim() != lEndereco[0].Cep.Trim())
                                cep_emit.ForeColor = Color.Red;
                            if (ds_endereco_emit.Text.Trim().ToUpper() != lEndereco[0].Ds_endereco.Trim().ToUpper())
                                ds_endereco_emit.ForeColor = Color.Red;
                            if (numero_emit.Text.Trim() != lEndereco[0].Numero.Trim())
                                numero_emit.ForeColor = Color.Red;
                            if (complemento_emit.Text.Trim().ToUpper() != lEndereco[0].Ds_complemento.Trim().ToUpper())
                                complemento_emit.ForeColor = Color.Red;
                            if (bairro_emit.Text.Trim().ToUpper() != lEndereco[0].Bairro.Trim().ToUpper())
                                bairro_emit.ForeColor = Color.Red;
                            if (fone_emit.Text.Trim() != lEndereco[0].Fone.Trim())
                                fone_emit.ForeColor = Color.Red;
                            if (inscricao_estadual_emit.Text.Trim() != lEndereco[0].Insc_estadual.Trim())
                                inscricao_estadual_emit.ForeColor = Color.Red;
                            uf_emit.Text = lEndereco[0].UF;
                            cd_uf_emit.Text = lEndereco[0].Cd_uf;
                        }
                    }
                }
                else
                {
                    //Buscar CD_UF
                    cd_uf_emit.Text = new CamadaDados.Financeiro.Cadastros.TCD_CadUf().BuscarEscalar(
                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.UF",
                                                vOperador = "=",
                                                vVL_Busca = "'" + uf_emit.Text.Trim() + "'"
                                            }
                                        }, "a.cd_uf").ToString();
                }
            }
            #endregion

            #region Destinatario NFe
            lNo = xml.GetElementsByTagName("dest");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("CNPJ"))
                        cnpj_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("CPF"))
                        cpf_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("xNome"))
                        razao_social_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("xFant"))
                        fantasia_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("IE"))
                        insc_estadual_dest.Text = no.InnerText;
                }
                //Buscar fornecedor
                CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.IsNullOrEmpty(cnpj_dest.Text.SoNumero()) ? string.Empty : cnpj_dest.Text,
                                                                                  string.IsNullOrEmpty(cpf_dest.Text.SoNumero()) ? string.Empty : cpf_dest.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  null);
                if (lFornec.Count > 0)
                {
                    rDestinatario = lFornec[0];
                    cd_dest.Text = lFornec[0].Cd_clifor;
                    if (razao_social_dest.Text.Trim().ToUpper() != lFornec[0].Nm_clifor.Trim().ToUpper())
                        razao_social_dest.ForeColor = Color.Red;
                    if (fantasia_dest.Text.Trim().ToUpper() != lFornec[0].Nm_fantasia.Trim().ToUpper())
                        fantasia_dest.ForeColor = Color.Red;
                }
            }
            #endregion

            #region Endereco Destinatario NFe
            lNo = xml.GetElementsByTagName("enderDest");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("xLgr"))
                        ds_endereco_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("nro"))
                        numero_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("xCpl"))
                        complemento_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("xBairro"))
                        bairro_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("cMun"))
                    {
                        cd_cidade_dest.Text = no.InnerText;
                        if (new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_cidade",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_cidade_emit.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                        {
                            cd_cidade_dest.ForeColor = Color.Red;
                            St_cidadeDestexiste = false;
                        }
                        else
                        {
                            cd_cidade_dest.ForeColor = Color.Black;
                            St_cidadeDestexiste = true;
                        }
                    }
                    else if (no.LocalName.Equals("xMun"))
                        ds_cidade_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("CEP"))
                        cep_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("fone"))
                        fone_dest.Text = no.InnerText;
                    else if (no.LocalName.Equals("UF"))
                        uf_dest.Text = no.InnerText;
                }
                //Buscar endereco fornecedor
                if (!string.IsNullOrEmpty(cd_dest.Text))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_dest.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.IsNullOrEmpty(cep_dest.Text.SoNumero()) ? string.Empty : cep_dest.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  null);
                    if (lEnd.Count > 0)
                    {
                        rEndDest = lEnd[0];
                        cd_endereco_dest.Text = lEnd[0].Cd_endereco;
                        if (cep_dest.Text.Trim() != lEnd[0].Cep.Trim())
                            cep_dest.ForeColor = Color.Red;
                        if (ds_endereco_dest.Text.Trim().ToUpper() != lEnd[0].Ds_endereco.Trim().ToUpper())
                            ds_endereco_dest.ForeColor = Color.Red;
                        if (numero_dest.Text.Trim() != lEnd[0].Numero.Trim())
                            numero_dest.ForeColor = Color.Red;
                        if (complemento_dest.Text.Trim().ToUpper() != lEnd[0].Ds_complemento.Trim().ToUpper())
                            complemento_dest.ForeColor = Color.Red;
                        if (bairro_dest.Text.Trim().ToUpper() != lEnd[0].Bairro.Trim().ToUpper())
                            bairro_dest.ForeColor = Color.Red;
                        if (fone_dest.Text.Trim() != lEnd[0].Fone.Trim())
                            fone_dest.ForeColor = Color.Red;
                        if (insc_estadual_dest.Text.Trim() != lEnd[0].Insc_estadual.Trim())
                            insc_estadual_dest.ForeColor = Color.Red;
                        uf_dest.Text = lEnd[0].UF;
                        cd_uf_dest.Text = lEnd[0].Cd_uf;
                    }
                    else
                    {
                        //Buscar sem filtro CEP
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca =  "'" + cd_dest.Text + "'",
                                                }
                                            }, 1, string.Empty);

                        if (lEndereco.Count > 0)
                        {
                            cd_endereco_dest.Text = lEndereco[0].Cd_endereco;
                            if (cep_dest.Text.Trim() != lEndereco[0].Cep.Trim())
                                cep_dest.ForeColor = Color.Red;
                            if (ds_endereco_dest.Text.Trim().ToUpper() != lEndereco[0].Ds_endereco.Trim().ToUpper())
                                ds_endereco_dest.ForeColor = Color.Red;
                            if (numero_dest.Text.Trim() != lEndereco[0].Numero.Trim())
                                numero_dest.ForeColor = Color.Red;
                            if (complemento_dest.Text.Trim().ToUpper() != lEndereco[0].Ds_complemento.Trim().ToUpper())
                                complemento_dest.ForeColor = Color.Red;
                            if (bairro_dest.Text.Trim().ToUpper() != lEndereco[0].Bairro.Trim().ToUpper())
                                bairro_dest.ForeColor = Color.Red;
                            if (fone_dest.Text.Trim() != lEndereco[0].Fone.Trim())
                                fone_dest.ForeColor = Color.Red;
                            if (insc_estadual_dest.Text.Trim() != lEndereco[0].Insc_estadual.Trim())
                                insc_estadual_dest.ForeColor = Color.Red;
                            uf_dest.Text = lEndereco[0].UF;
                            cd_uf_dest.Text = lEndereco[0].Cd_uf;
                        }
                    }
                }
                else
                {
                    //Buscar CD_UF
                    cd_uf_dest.Text = new CamadaDados.Financeiro.Cadastros.TCD_CadUf().BuscarEscalar(
                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.UF",
                                                vOperador = "=",
                                                vVL_Busca = "'" + uf_dest.Text.Trim() + "'"
                                            }
                                        }, "a.cd_uf").ToString();
                }
            }
            #endregion

            #region Itens NFe
            lNo = xml.GetElementsByTagName("det");
            if (lNo.Count > 0)
            {
                List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe> lItens = new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>();
                foreach (XmlNode no in lNo)
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe();
                    foreach (XmlNode noF in no.ChildNodes)
                    {
                        if (noF.LocalName.Equals("prod"))
                        {
                            foreach (XmlNode noP in noF.ChildNodes)
                            {
                                if (noP.LocalName.Equals("cProd"))
                                    rItem.Cd_produto_xml = noP.InnerText;
                                else if (noP.LocalName.Equals("xProd"))
                                    rItem.Ds_produto_xml = noP.InnerText;
                                else if (noP.LocalName.Equals("NCM"))
                                    rItem.Ncm_xml = noP.InnerText;
                                else if (noP.LocalName.Equals("CFOP"))
                                    rItem.Cfop_xml = noP.InnerText;
                                else if (noP.LocalName.Equals("uCom"))
                                    rItem.Sigla_unidade = noP.InnerText;
                                else if (noP.LocalName.Equals("qCom"))
                                {
                                    rItem.Quantidade = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                    rItem.Quantidade_xml = rItem.Quantidade;
                                }
                                else if (noP.LocalName.Equals("vUnCom"))
                                    rItem.Vl_unitario = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vProd"))
                                    rItem.Vl_subtotal = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vFrete"))
                                    rItem.Vl_frete = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vSeg"))
                                    rItem.Vl_seguro = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vDesc"))
                                    rItem.Vl_desconto = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vOutro"))
                                    rItem.Vl_outrasdesp = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                if (noP.LocalName.Equals("comb"))
                                    foreach (XmlNode noC in noP.ChildNodes)
                                        if (noC.LocalName.Equals("cProdANP"))
                                            rItem.Cd_anp_xml = noC.InnerText;
                            }
                        }
                    }
                    lItens.Add(rItem);
                }
                //Buscar Produto Predominante
                ds_produtoPred.Text = lItens.OrderByDescending(p => p.Vl_subtotal).First().Ds_produto_xml;
                ds_produtoPred.Text = lItens.OrderByDescending(p => p.Vl_subtotal).First().Ds_produto_xml;
                unidade.Text = lItens.OrderByDescending(p => p.Vl_subtotal).First().Sigla_unidade;
                qtd_carga.Value = lItens.OrderByDescending(p => p.Vl_subtotal).First().Quantidade_xml;
                //Valor Carga
                Vl_carga.Value = lItens.Sum(p => p.Vl_liquido);
            }
            #endregion

            #region Dados Adicionais
            lNo = xml.GetElementsByTagName("infAdic");
            if (lNo.Count > 0)
                foreach (XmlNode no in lNo[0].ChildNodes)
                    if (no.LocalName.Equals("infCpl"))
                    {
                        ds_obsNFe.Text = no.InnerText;
                        break;
                    }
            #endregion
        }

        private void bb_addLacre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_lacre.Text))
            {
                lbLacre.Items.Add(nr_lacre.Text);
                nr_lacre.Clear();
            }
        }

        private void lbLacre_DoubleClick(object sender, EventArgs e)
        {
            if (lbLacre.SelectedIndex >= 0)
            {
                nr_lacre.Text = lbLacre.SelectedItem != null ? lbLacre.SelectedItem.ToString() : string.Empty;
                lbLacre.Items.RemoveAt(lbLacre.SelectedIndex);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_addEmitente_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
                rClifor.Cd_clifor = cd_emit.Text;
                rClifor.Tp_pessoa = string.IsNullOrEmpty(cnpj_emit.Text.SoNumero()) ? "F" : "J";
                rClifor.Nr_cgc = string.IsNullOrEmpty(cnpj_emit.Text.SoNumero()) ? string.Empty : cnpj_emit.Text;
                rClifor.Nr_cpf = string.IsNullOrEmpty(cpf_emit.Text.SoNumero()) ? string.Empty : cpf_emit.Text;
                rClifor.Nm_clifor = razao_social_emit.Text;
                rClifor.Nm_fantasia = fantasia_emit.Text;
                if (rEmitente != null)
                {
                    rClifor.Cd_condfiscal_clifor = rEmitente.Cd_condfiscal_clifor;
                    rClifor.Ds_condfiscal_clifor = rEmitente.Ds_condfiscal_clifor;
                    rClifor.Id_categoriaclifor = rEmitente.Id_categoriaclifor;
                    rClifor.Ds_categoriaclifor = rEmitente.Ds_categoriaclifor;
                    rClifor.Id_regiao = rEmitente.Id_regiao;
                    rClifor.Nm_regiao = rEmitente.Nm_regiao;
                }
                //Endereco
                rClifor.lEndereco.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                {
                    Cd_endereco = cd_endereco_emit.Text,
                    Cep = cep_emit.Text,
                    Ds_endereco = ds_endereco_emit.Text,
                    Numero = numero_emit.Text,
                    Ds_complemento = complemento_emit.Text,
                    Bairro = bairro_emit.Text,
                    Fone = fone_emit.Text,
                    Cd_cidade = cd_cidade_emit.Text,
                    DS_Cidade = ds_cidade_emit.Text,
                    UF = uf_emit.Text,
                    Insc_estadual = inscricao_estadual_emit.Text
                });
                fClifor.rClifor = rClifor;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            //Fornecedor
                            cd_emit.Text = fClifor.rClifor.Cd_clifor;
                            razao_social_emit.Text = fClifor.rClifor.Nm_clifor;
                            razao_social_emit.ForeColor = Color.Black;
                            fantasia_emit.Text = fClifor.rClifor.Nm_fantasia;
                            fantasia_emit.ForeColor = Color.Black;
                            cnpj_emit.Text = fClifor.rClifor.Nr_cgc;
                            cnpj_emit.ForeColor = Color.Black;
                            cpf_emit.Text = fClifor.rClifor.Nr_cpf;
                            cpf_emit.ForeColor = Color.Black;
                            rEmitente = fClifor.rClifor;
                            //Endereco
                            cd_endereco_emit.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                            cep_emit.Text = fClifor.rClifor.lEndereco[0].Cep;
                            cep_emit.ForeColor = Color.Black;
                            ds_endereco_emit.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                            ds_endereco_emit.ForeColor = Color.Black;
                            numero_emit.Text = fClifor.rClifor.lEndereco[0].Numero;
                            numero_emit.ForeColor = Color.Black;
                            complemento_emit.Text = fClifor.rClifor.lEndereco[0].Ds_complemento;
                            complemento_emit.ForeColor = Color.Black;
                            bairro_emit.Text = fClifor.rClifor.lEndereco[0].Bairro;
                            bairro_emit.ForeColor = Color.Black;
                            fone_emit.Text = fClifor.rClifor.lEndereco[0].Fone;
                            fone_emit.ForeColor = Color.Black;
                            cd_cidade_emit.Text = fClifor.rClifor.lEndereco[0].Cd_cidade;
                            cd_cidade_emit.ForeColor = Color.Black;
                            ds_cidade_emit.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                            uf_emit.Text = fClifor.rClifor.lEndereco[0].UF;
                            inscricao_estadual_emit.Text = fClifor.rClifor.lEndereco[0].Insc_estadual;
                            inscricao_estadual_emit.ForeColor = Color.Black;
                            rEndEmit = fClifor.rClifor.lEndereco[0];
                            MessageBox.Show("Remetente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_addCidadeEmit_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_cidade_emit.Text)) && (!St_cidadeEmitexiste))
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Gravar(
                        new CamadaDados.Financeiro.Cadastros.TRegistro_CadCidade()
                        {
                            Cd_cidade = cd_cidade_emit.Text,
                            Ds_cidade = ds_cidade_emit.Text,
                            Cd_uf = cd_cidade_emit.Text.Trim().Substring(0, 2),
                            St_registro = "A"
                        }, null);
                    St_cidadeEmitexiste = true;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_AddDestinatario_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
                rClifor.Cd_clifor = cd_dest.Text;
                rClifor.Tp_pessoa = string.IsNullOrEmpty(cnpj_dest.Text.SoNumero()) ? "F" : "J";
                rClifor.Nr_cgc = string.IsNullOrEmpty(cnpj_dest.Text.SoNumero()) ? string.Empty : cnpj_dest.Text;
                rClifor.Nr_cpf = string.IsNullOrEmpty(cpf_dest.Text.SoNumero()) ? string.Empty : cpf_dest.Text;
                rClifor.Nm_clifor = razao_social_dest.Text;
                rClifor.Nm_fantasia = fantasia_dest.Text;
                if (rDestinatario != null)
                {
                    rClifor.Cd_condfiscal_clifor = rDestinatario.Cd_condfiscal_clifor;
                    rClifor.Ds_condfiscal_clifor = rDestinatario.Ds_condfiscal_clifor;
                    rClifor.Id_categoriaclifor = rDestinatario.Id_categoriaclifor;
                    rClifor.Ds_categoriaclifor = rDestinatario.Ds_categoriaclifor;
                    rClifor.Id_regiao = rDestinatario.Id_regiao;
                    rClifor.Nm_regiao = rDestinatario.Nm_regiao;
                }
                //Endereco
                rClifor.lEndereco.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco()
                {
                    Cd_endereco = cd_endereco_dest.Text,
                    Cep = cep_dest.Text,
                    Ds_endereco = ds_endereco_dest.Text,
                    Numero = numero_dest.Text,
                    Ds_complemento = complemento_dest.Text,
                    Bairro = bairro_dest.Text,
                    Fone = fone_dest.Text,
                    Cd_cidade = cd_cidade_dest.Text,
                    DS_Cidade = ds_cidade_dest.Text,
                    UF = uf_dest.Text,
                    Insc_estadual = insc_estadual_dest.Text
                });
                fClifor.rClifor = rClifor;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            //Fornecedor
                            cd_dest.Text = fClifor.rClifor.Cd_clifor;
                            razao_social_dest.Text = fClifor.rClifor.Nm_clifor;
                            razao_social_dest.ForeColor = Color.Black;
                            fantasia_dest.Text = fClifor.rClifor.Nm_fantasia;
                            fantasia_dest.ForeColor = Color.Black;
                            cnpj_dest.Text = fClifor.rClifor.Nr_cgc;
                            cnpj_dest.ForeColor = Color.Black;
                            cpf_dest.Text = fClifor.rClifor.Nr_cpf;
                            cpf_dest.ForeColor = Color.Black;
                            rDestinatario = fClifor.rClifor;
                            //Endereco
                            cd_endereco_dest.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                            cep_dest.Text = fClifor.rClifor.lEndereco[0].Cep;
                            cep_dest.ForeColor = Color.Black;
                            ds_endereco_dest.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                            ds_endereco_dest.ForeColor = Color.Black;
                            numero_dest.Text = fClifor.rClifor.lEndereco[0].Numero;
                            numero_dest.ForeColor = Color.Black;
                            complemento_dest.Text = fClifor.rClifor.lEndereco[0].Ds_complemento;
                            complemento_dest.ForeColor = Color.Black;
                            bairro_dest.Text = fClifor.rClifor.lEndereco[0].Bairro;
                            bairro_dest.ForeColor = Color.Black;
                            fone_dest.Text = fClifor.rClifor.lEndereco[0].Fone;
                            fone_dest.ForeColor = Color.Black;
                            cd_cidade_dest.Text = fClifor.rClifor.lEndereco[0].Cd_cidade;
                            cd_cidade_dest.ForeColor = Color.Black;
                            ds_cidade_dest.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                            uf_dest.Text = fClifor.rClifor.lEndereco[0].UF;
                            insc_estadual_dest.Text = fClifor.rClifor.lEndereco[0].Insc_estadual;
                            insc_estadual_dest.ForeColor = Color.Black;
                            rEndDest = fClifor.rClifor.lEndereco[0];
                            MessageBox.Show("Destinatario gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_AddCidadeDest_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_cidade_dest.Text)) && (!St_cidadeDestexiste))
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Gravar(
                        new CamadaDados.Financeiro.Cadastros.TRegistro_CadCidade()
                        {
                            Cd_cidade = cd_cidade_dest.Text,
                            Ds_cidade = ds_cidade_dest.Text,
                            Cd_uf = cd_cidade_dest.Text.Trim().Substring(0, 2),
                            St_registro = "A"
                        }, null);
                    St_cidadeDestexiste = true;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void rbEmitRemetenteCTe_Click(object sender, EventArgs e)
        {
            if (rbEmitRemetenteCTe.Checked)
                rbDestDestinatarioCTe.Checked = true;
        }

        private void rbEmitDestinatarioCTe_Click(object sender, EventArgs e)
        {
            if (rbEmitDestinatarioCTe.Checked)
                rbDestRemetenteCTe.Checked = true;
        }

        private void rbDestRemetenteCTe_Click(object sender, EventArgs e)
        {
            if (rbDestRemetenteCTe.Checked)
                rbEmitDestinatarioCTe.Checked = true;
        }

        private void rbDestDestinatarioCTe_Click(object sender, EventArgs e)
        {
            if (rbDestDestinatarioCTe.Checked)
                rbEmitRemetenteCTe.Checked = true;
        }

        private void TFImportarNFeCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
