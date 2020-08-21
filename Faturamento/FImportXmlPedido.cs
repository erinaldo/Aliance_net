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
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using Financeiro;
using CamadaDados.Financeiro.CCustoLan;
using Proc_Commoditties;

namespace Faturamento
{
    public partial class TFImportXmlPedido : Form
    {
        private bool St_serieexiste = false;
        private bool St_modeloexiste = false;
        private bool St_cmifinanceiro = false;
        private bool St_commoditties = false;
        private bool St_valoresfixos = false;
        private bool St_finavista = false;
        public string NomeArquivo = string.Empty;
        private CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup;
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCondPgto;
        private CamadaDados.Financeiro.Duplicata.TList_Parcelas lParc;
        private CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfg
        { get; set; }
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedido
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TList_CadClifor lClifor
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndFornec;

        private CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLancto
        { get; set; }
        private CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLanctoDel
        { get; set; }
        public TFImportXmlPedido()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMITENTE", "0"));
            cbx.Add(new Utils.TDataCombo("DESTINATARIO", "1"));
            cbx.Add(new Utils.TDataCombo("TERCEIRO", "2"));
            cbx.Add(new Utils.TDataCombo("SEM FRETE", "9"));

            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";
        }

        private void BuscarClifor()
        {
            if (rPedido != null)
            {
                lClifor = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + rPedido.CD_Clifor.Trim() + "'"
                            }
                        }, 1, string.Empty);
            }
        }

        private void ImportarXml()
        {
            if (!string.IsNullOrEmpty(NomeArquivo))
            {
                List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe> lItens = new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>();
                XmlDocument xml = new XmlDocument();
                xml.Load(NomeArquivo);
                XmlNodeList lNo = xml.GetElementsByTagName("infNFe");
                if (lNo.Count > 0)
                {
                    chave_acesso.Text = lNo[0].Attributes.GetNamedItem("Id").InnerText.Remove(0, 3);
                    //Verificar se chave de acesso existe no banco
                    if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                        new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.Chave_Acesso_NFE",
                                        vOperador = "=",
                                        vVL_Busca = "'" + chave_acesso.Text.Trim() + "'"
                                    }
                                }, "1") != null)
                    {
                        MessageBox.Show("Chave de acesso " + chave_acesso.Text.Trim() + " ja se encontra cadastrada no sistema.", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("XML Invalido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #region Identificacao NFe
                lNo = xml.GetElementsByTagName("ide");
                //Identificacao da NFe
                if (lNo.Count > 0)
                {
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("mod"))
                        {
                            cd_modelo.Text = no.InnerText;
                            if (new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_modelo",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_modelo.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                            {
                                cd_modelo.ForeColor = Color.Red;
                                St_modeloexiste = false;
                            }
                            else
                            {
                                cd_modelo.ForeColor = Color.Black;
                                St_modeloexiste = true;
                            }
                        }
                        else if (no.LocalName.Equals("serie"))
                        {
                            nr_serie.Text = no.InnerText;
                            if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_serie",
                                                vOperador = "=",
                                                vVL_Busca = "'" + nr_serie.Text.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_modelo",
                                                vOperador = "=",
                                                vVL_Busca = "'"+ cd_modelo.Text.Trim() + "'"
                                            }
                                        }, "1") == null)
                            {
                                nr_serie.ForeColor = Color.Red;
                                St_serieexiste = false;
                            }
                            else
                            {
                                nr_serie.ForeColor = Color.Black;
                                St_serieexiste = true;
                            }
                        }
                        else if (no.LocalName.Equals("nNF"))
                            nr_notafiscal.Text = no.InnerText;
                        else if (no.LocalName.Equals("dEmi"))
                            dt_emissao.Text = DateTime.Parse(no.InnerText).ToString("dd/MM/yyyy HH:mm:ss");
                        else if (no.LocalName.Equals("dhEmi"))
                            dt_emissao.Text = DateTime.Parse(no.InnerText).ToString("dd/MM/yyyy HH:mm:ss");
                        else if (no.LocalName.Equals("finNFe"))
                        {
                            if (no.InnerText != "1")
                            {
                                MessageBox.Show("Permitido importar somente XML de NFe NORMAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                return;
                            }
                        }
                    }
                }
                #endregion
                #region Fornecedor
                lNo = xml.GetElementsByTagName("emit");
                if (lNo.Count > 0)
                {
                    string cpf = string.Empty;
                    string cnpj = string.Empty;
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("CNPJ"))
                            cnpj = String.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(no.InnerText));
                        else if (no.LocalName.Equals("CPF"))
                            cpf = String.Format(@"{0:000\.000\.000\-00}", long.Parse(no.InnerText));
                    }
                    //Buscar fornecedor
                    if (new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.IsNullOrEmpty(cnpj) ? "a.cpf" : "a.nr_cgc",
                                            vOperador = "=",
                                            vVL_Busca = string.IsNullOrEmpty(cnpj) ? "'" + cpf.Trim() + "'"  : "'" + cnpj.Trim() + "'" 
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rPedido.CD_Clifor.Trim() + "'"
                                        }
                                    }, "1") == null)
                    {
                        MessageBox.Show("Fornecedor do Pedido é diferente do XML!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }
                #endregion

                #region Endereco Fornecedor
                lNo = xml.GetElementsByTagName("enderEmit");
                string cepFornec = string.Empty;
                if (lNo.Count > 0)
                {
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("CEP"))
                            cepFornec = no.InnerText;
                    }
                    //Buscar endereco fornecedor
                    if (!string.IsNullOrEmpty(rPedido.CD_Clifor))
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rPedido.CD_Clifor,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.IsNullOrEmpty(cepFornec.SoNumero()) ? string.Empty : cepFornec,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                        if (lEnd.Count > 0)
                            rEndFornec = lEnd[0];
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
                                                    vVL_Busca =  "'" + rPedido.CD_Clifor + "'",
                                                }
                                            }, 1, string.Empty);

                            if (lEndereco.Count > 0)
                                rEndFornec = lEndereco[0];
                        }
                    }
                }
                #endregion
                #region Empresa
                lNo = xml.GetElementsByTagName("dest");
                if (lNo.Count > 0)
                {
                    string Cnpj = lNo[0].FirstChild.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                    CamadaDados.Diversos.TList_CadEmpresa lEmp =
                    new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "b.nr_cgc",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cnpj.Trim() + "'"
                                            }
                                        }, 1, string.Empty);
                    if (lEmp.Count > 0)
                    {
                        cd_empresa.Text = lEmp[0].Cd_empresa;
                        nm_empresa.Text = lEmp[0].Nm_empresa;
                        tp_regimetributario.Text = lEmp[0].Tp_regimetributario;
                        cd_uf_empresa.Text = lEmp[0].rEndereco.Cd_uf;
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado empresa cadastrada no sistema com o CNPJ " + Cnpj.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }
                }
                #endregion
                #region Itens da NFe
                //Buscar lista impostos
                CamadaDados.Fiscal.TList_CadImposto lImpostos =
                    CamadaNegocio.Fiscal.TCN_CadImposto.Busca(string.Empty, string.Empty, null);
                lNo = xml.GetElementsByTagName("det");
                if (lNo.Count > 0)
                {
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
                            else if (noF.LocalName.Equals("imposto"))
                            {
                                foreach (XmlNode noI in noF.ChildNodes)
                                {
                                    if (noI.LocalName.Equals("ICMS"))
                                    {
                                        if (noI.ChildNodes.Count > 0)
                                        {
                                            if (!lImpostos.Exists(p => p.St_ICMS))
                                            {
                                                MessageBox.Show("Não existe imposto ICMS cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                return;
                                            }
                                            switch (noI.LastChild.LocalName)
                                            {
                                                case "ICMS00":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS00 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS00.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS00.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS00.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS00 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS00.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS00.InnerText;
                                                            else if (ICMS00.LocalName.Equals("CST"))
                                                                rICMS00.Cd_st_xml = ICMS00.InnerText;
                                                            else if (ICMS00.LocalName.Equals("vBC"))
                                                                rICMS00.Vl_basecalc_xml = decimal.Parse(ICMS00.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS00.LocalName.Equals("pICMS"))
                                                                rICMS00.Pc_aliquota_xml = decimal.Parse(ICMS00.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS00.LocalName.Equals("vICMS"))
                                                                rICMS00.Vl_imposto_xml = decimal.Parse(ICMS00.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS00);
                                                        break;
                                                    }
                                                case "ICMS10":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS10 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS10.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS10.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS10.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS10 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS10.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS10.InnerText;
                                                            else if (ICMS10.LocalName.Equals("CST"))
                                                                rICMS10.Cd_st_xml = ICMS10.InnerText;
                                                            else if (ICMS10.LocalName.Equals("vBC"))
                                                                rICMS10.Vl_basecalc_xml = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS10.LocalName.Equals("pICMS"))
                                                                rICMS10.Pc_aliquota_xml = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS10.LocalName.Equals("vICMS"))
                                                                rICMS10.Vl_imposto_xml = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS10.LocalName.Equals("vBCST"))
                                                                rICMS10.Vl_basecalcsubsttrib = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS10.LocalName.Equals("pICMSST"))
                                                                rICMS10.Pc_aliquotasubst = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS10.LocalName.Equals("vICMSST"))
                                                                rICMS10.Vl_impostosubsttrib = decimal.Parse(ICMS10.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS10);
                                                        break;
                                                    }
                                                case "ICMS20":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS20 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS20.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS20.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS20.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS20 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS20.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS20.InnerText;
                                                            else if (ICMS20.LocalName.Equals("CST"))
                                                                rICMS20.Cd_st_xml = ICMS20.InnerText;
                                                            else if (ICMS20.LocalName.Equals("pRedBC"))
                                                                rICMS20.Pc_reducaobasecalc_xml = decimal.Parse(ICMS20.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS20.LocalName.Equals("vBC"))
                                                                rICMS20.Vl_basecalc_xml = decimal.Parse(ICMS20.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS20.LocalName.Equals("pICMS"))
                                                                rICMS20.Pc_aliquota_xml = decimal.Parse(ICMS20.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS20.LocalName.Equals("vICMS"))
                                                                rICMS20.Vl_imposto_xml = decimal.Parse(ICMS20.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS20);
                                                        break;
                                                    }
                                                case "ICMS30":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS30 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS30.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS30.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS30.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS30 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS30.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS30.InnerText;
                                                            else if (ICMS30.LocalName.Equals("CST"))
                                                                rICMS30.Cd_st_xml = ICMS30.InnerText;
                                                            else if (ICMS30.LocalName.Equals("pRedBCST"))
                                                                rICMS30.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS30.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS30.LocalName.Equals("vBCST"))
                                                                rICMS30.Vl_basecalcsubsttrib = decimal.Parse(ICMS30.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS30.LocalName.Equals("pICMSST"))
                                                                rICMS30.Pc_aliquotasubst = decimal.Parse(ICMS30.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS30.LocalName.Equals("vICMSST"))
                                                                rICMS30.Vl_impostosubsttrib = decimal.Parse(ICMS30.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS30);
                                                        break;
                                                    }
                                                case "ICMS40":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS40 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS40.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS40.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS40.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS40 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS40.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS40.InnerText;
                                                            else if (ICMS40.LocalName.Equals("CST"))
                                                                rICMS40.Cd_st_xml = ICMS40.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rICMS40);
                                                        break;
                                                    }
                                                case "ICMS51":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS51 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS51.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS51.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS51.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS51 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS51.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS51.InnerText;
                                                            else if (ICMS51.LocalName.Equals("CST"))
                                                                rICMS51.Cd_st_xml = ICMS51.InnerText;
                                                            else if (ICMS51.LocalName.Equals("pRedBC"))
                                                                rICMS51.Pc_reducaobasecalc_xml = decimal.Parse(ICMS51.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS51.LocalName.Equals("vBC"))
                                                                rICMS51.Vl_basecalc_xml = decimal.Parse(ICMS51.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS51.LocalName.Equals("pICMS"))
                                                                rICMS51.Pc_aliquota_xml = decimal.Parse(ICMS51.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS51.LocalName.Equals("vICMS"))
                                                                rICMS51.Vl_imposto_xml = decimal.Parse(ICMS51.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS51);
                                                        break;
                                                    }
                                                case "ICMS60":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS60 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS60.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS60.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS60.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS60 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS60.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS60.InnerText;
                                                            else if (ICMS60.LocalName.Equals("CST"))
                                                                rICMS60.Cd_st_xml = ICMS60.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rICMS60);
                                                        break;
                                                    }
                                                case "ICMS70":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS70 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS70.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS70.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS70.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS70 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS70.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS70.InnerText;
                                                            else if (ICMS70.LocalName.Equals("CST"))
                                                                rICMS70.Cd_st_xml = ICMS70.InnerText;
                                                            else if (ICMS70.LocalName.Equals("pRedBC"))
                                                                rICMS70.Pc_reducaobasecalc_xml = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("vBC"))
                                                                rICMS70.Vl_basecalc_xml = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("pICMS"))
                                                                rICMS70.Pc_aliquota_xml = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("vICMS"))
                                                                rICMS70.Vl_imposto_xml = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("pRedBCST"))
                                                                rICMS70.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("vBCST"))
                                                                rICMS70.Vl_basecalcsubsttrib = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("pICMSST"))
                                                                rICMS70.Pc_aliquotasubst = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS70.LocalName.Equals("vICMSST"))
                                                                rICMS70.Vl_impostosubsttrib = decimal.Parse(ICMS70.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS70);
                                                        break;
                                                    }
                                                case "ICMS90":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS90 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS90.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS90.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS90.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS90 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS90.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS90.InnerText;
                                                            else if (ICMS90.LocalName.Equals("CST"))
                                                                rICMS90.Cd_st_xml = ICMS90.InnerText;
                                                            else if (ICMS90.LocalName.Equals("vBC"))
                                                                rICMS90.Vl_basecalc_xml = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("pRedBC"))
                                                                rICMS90.Pc_reducaobasecalc_xml = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("pICMS"))
                                                                rICMS90.Pc_aliquota_xml = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("vICMS"))
                                                                rICMS90.Vl_imposto_xml = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("pRedBCST"))
                                                                rICMS90.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("vBCST"))
                                                                rICMS90.Vl_basecalcsubsttrib = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("pICMSST"))
                                                                rICMS90.Pc_aliquotasubst = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS90.LocalName.Equals("vICMSST"))
                                                                rICMS90.Vl_impostosubsttrib = decimal.Parse(ICMS90.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS90);
                                                        break;
                                                    }
                                                case "ICMSSN101":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS101 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS101.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS101.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS101.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS101 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS101.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS101.InnerText;
                                                            else if (ICMS101.LocalName.Equals("CSOSN"))
                                                                rICMS101.Cd_st_xml = ICMS101.InnerText;
                                                            else if (ICMS101.LocalName.Equals("pCredSN"))
                                                                rICMS101.Pc_aliquota_xml = decimal.Parse(ICMS101.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS101.LocalName.Equals("vCredICMSSN"))
                                                                rICMS101.Vl_imposto_xml = decimal.Parse(ICMS101.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS101);
                                                        break;
                                                    }
                                                case "ICMSSN102":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS102 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS102.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS102.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS102.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS102 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS102.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS102.InnerText;
                                                            else if (ICMS102.LocalName.Equals("CSOSN"))
                                                                rICMS102.Cd_st_xml = ICMS102.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rICMS102);
                                                        break;
                                                    }
                                                case "ICMSSN201":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS201 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS201.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS201.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS201.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS201 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS201.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS201.InnerText;
                                                            else if (ICMS201.LocalName.Equals("CSOSN"))
                                                                rICMS201.Cd_st_xml = ICMS201.InnerText;
                                                            else if (ICMS201.LocalName.Equals("pRedBCST"))
                                                                rICMS201.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS201.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS201.LocalName.Equals("vBCST"))
                                                                rICMS201.Vl_basecalcsubsttrib = decimal.Parse(ICMS201.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS201.LocalName.Equals("pICMSST"))
                                                                rICMS201.Pc_aliquotasubst = decimal.Parse(ICMS201.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS201.LocalName.Equals("vICMSST"))
                                                                rICMS201.Vl_impostosubsttrib = decimal.Parse(ICMS201.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS201);
                                                        break;
                                                    }
                                                case "ICMSSN202":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS202 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS202.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS202.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS202.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS202 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS202.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS202.InnerText;
                                                            else if (ICMS202.LocalName.Equals("CSOSN"))
                                                                rICMS202.Cd_st_xml = ICMS202.InnerText;
                                                            else if (ICMS202.LocalName.Equals("pRedBCST"))
                                                                rICMS202.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS202.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS202.LocalName.Equals("vBCST"))
                                                                rICMS202.Vl_basecalcsubsttrib = decimal.Parse(ICMS202.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS202.LocalName.Equals("pICMSST"))
                                                                rICMS202.Pc_aliquotasubst = decimal.Parse(ICMS202.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS202.LocalName.Equals("vICMSST"))
                                                                rICMS202.Vl_impostosubsttrib = decimal.Parse(ICMS202.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS202);
                                                        break;
                                                    }
                                                case "ICMSSN500":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS500 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS500.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS500.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS500.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS500 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS500.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS500.InnerText;
                                                            else if (ICMS500.LocalName.Equals("CSOSN"))
                                                                rICMS500.Cd_st_xml = ICMS500.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rICMS500);
                                                        break;
                                                    }
                                                case "ICMSSN900":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rICMS900 = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rICMS900.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).Cd_imposto;
                                                        rICMS900.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_ICMS).ds_imposto;
                                                        rICMS900.Imposto = lImpostos.FirstOrDefault(p => p.St_ICMS);
                                                        foreach (XmlNode ICMS900 in noI.LastChild.ChildNodes)
                                                        {
                                                            if (ICMS900.LocalName.Equals("orig"))
                                                                rItem.Tp_origem = ICMS900.InnerText;
                                                            else if (ICMS900.LocalName.Equals("CSOSN"))
                                                                rICMS900.Cd_st_xml = ICMS900.InnerText;
                                                            else if (ICMS900.LocalName.Equals("vBC"))
                                                                rICMS900.Vl_basecalc_xml = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("pRedBC"))
                                                                rICMS900.Pc_reducaobasecalc_xml = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("pICMS"))
                                                                rICMS900.Pc_aliquota_xml = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("vICMS"))
                                                                rICMS900.Vl_imposto_xml = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("pRedBCST"))
                                                                rICMS900.Pc_reducaobasecalcsubsttrib = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("vBCST"))
                                                                rICMS900.Vl_basecalcsubsttrib = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("pICMSST"))
                                                                rICMS900.Pc_aliquotasubst = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (ICMS900.LocalName.Equals("vICMSST"))
                                                                rICMS900.Vl_impostosubsttrib = decimal.Parse(ICMS900.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rICMS900);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    else if (noI.LocalName.Equals("IPI"))
                                    {
                                        if (noI.ChildNodes.Count > 0)
                                        {
                                            if (!lImpostos.Exists(p => p.St_IPI))
                                            {
                                                MessageBox.Show("Não existe imposto IPI cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                return;
                                            }
                                            foreach (XmlNode noIPI in noI.ChildNodes)
                                            {
                                                if (noIPI.LocalName.Equals("IPITrib"))
                                                {
                                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rIPI = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                    rIPI.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_IPI).Cd_imposto;
                                                    rIPI.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_IPI).ds_imposto;
                                                    rIPI.Imposto = lImpostos.FirstOrDefault(p => p.St_IPI);
                                                    foreach (XmlNode noIP in noIPI.ChildNodes)
                                                    {
                                                        if (noIP.LocalName.Equals("CST"))
                                                            rIPI.Cd_st_xml = noIP.InnerText;
                                                        else if (noIP.LocalName.Equals("vBC"))
                                                            rIPI.Vl_basecalc_xml = decimal.Parse(noIP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        else if (noIP.LocalName.Equals("pIPI"))
                                                            rIPI.Pc_aliquota_xml = decimal.Parse(noIP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        else if (noIP.LocalName.Equals("vIPI"))
                                                            rIPI.Vl_imposto_xml = decimal.Parse(noIP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                    }
                                                    rItem.lImpostos.Add(rIPI);
                                                }
                                            }
                                        }
                                    }
                                    else if (noI.LocalName.Equals("PIS"))
                                    {
                                        if (noI.ChildNodes.Count > 0)
                                        {
                                            if (!lImpostos.Exists(p => p.St_PIS))
                                            {
                                                MessageBox.Show("Não existe imposto PIS cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                return;
                                            }
                                            switch (noI.LastChild.LocalName)
                                            {
                                                case "PISAliq":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPISAliq = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rPISAliq.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).Cd_imposto;
                                                        rPISAliq.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).ds_imposto;
                                                        rPISAliq.Imposto = lImpostos.FirstOrDefault(p => p.St_PIS);
                                                        foreach (XmlNode PISAliq in noI.LastChild.ChildNodes)
                                                        {
                                                            if (PISAliq.LocalName.Equals("CST"))
                                                                rPISAliq.Cd_st_xml = PISAliq.InnerText;
                                                            else if (PISAliq.LocalName.Equals("vBC"))
                                                                rPISAliq.Vl_basecalc_xml = decimal.Parse(PISAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISAliq.LocalName.Equals("pPIS"))
                                                                rPISAliq.Pc_aliquota_xml = decimal.Parse(PISAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISAliq.LocalName.Equals("vPIS"))
                                                                rPISAliq.Vl_imposto_xml = decimal.Parse(PISAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rPISAliq);
                                                        break;
                                                    }
                                                case "PISQtde":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPISQtd = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rPISQtd.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).Cd_imposto;
                                                        rPISQtd.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).ds_imposto;
                                                        rPISQtd.Imposto = lImpostos.FirstOrDefault(p => p.St_PIS);
                                                        foreach (XmlNode PISQtd in noI.LastChild.ChildNodes)
                                                        {
                                                            if (PISQtd.LocalName.Equals("CST"))
                                                                rPISQtd.Cd_st_xml = PISQtd.InnerText;
                                                            else if (PISQtd.LocalName.Equals("vBC"))
                                                                rPISQtd.Vl_basecalc_xml = decimal.Parse(PISQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISQtd.LocalName.Equals("pPIS"))
                                                                rPISQtd.Pc_aliquota_xml = decimal.Parse(PISQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISQtd.LocalName.Equals("vPIS"))
                                                                rPISQtd.Vl_imposto_xml = decimal.Parse(PISQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rPISQtd);
                                                        break;
                                                    }
                                                case "PISNT":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPISNT = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rPISNT.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).Cd_imposto;
                                                        rPISNT.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).ds_imposto;
                                                        rPISNT.Imposto = lImpostos.FirstOrDefault(p => p.St_PIS);
                                                        foreach (XmlNode PISNT in noI.LastChild.ChildNodes)
                                                        {
                                                            if (PISNT.LocalName.Equals("CST"))
                                                                rPISNT.Cd_st_xml = PISNT.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rPISNT);
                                                        break;
                                                    }
                                                case "PISOutr":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rPISOut = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rPISOut.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).Cd_imposto;
                                                        rPISOut.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).ds_imposto;
                                                        rPISOut.Imposto = lImpostos.FirstOrDefault(p => p.St_PIS);
                                                        foreach (XmlNode PISOut in noI.LastChild.ChildNodes)
                                                        {
                                                            if (PISOut.LocalName.Equals("CST"))
                                                                rPISOut.Cd_st_xml = PISOut.InnerText;
                                                            else if (PISOut.LocalName.Equals("vBC"))
                                                                rPISOut.Vl_basecalc_xml = decimal.Parse(PISOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISOut.LocalName.Equals("pPIS"))
                                                                rPISOut.Pc_aliquota_xml = decimal.Parse(PISOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (PISOut.LocalName.Equals("vPIS"))
                                                                rPISOut.Vl_imposto_xml = decimal.Parse(PISOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rPISOut);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    else if (noI.LocalName.Equals("COFINS"))
                                    {
                                        if (noI.ChildNodes.Count > 0)
                                        {
                                            if (!lImpostos.Exists(p => p.St_Cofins))
                                            {
                                                MessageBox.Show("Não existe imposto COFINS cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Close();
                                                return;
                                            }
                                            switch (noI.LastChild.LocalName)
                                            {
                                                case "COFINSAliq":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCOFINSAliq = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rCOFINSAliq.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).Cd_imposto;
                                                        rCOFINSAliq.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).ds_imposto;
                                                        rCOFINSAliq.Imposto = lImpostos.FirstOrDefault(p => p.St_Cofins);
                                                        foreach (XmlNode COFINSAliq in noI.LastChild.ChildNodes)
                                                        {
                                                            if (COFINSAliq.LocalName.Equals("CST"))
                                                                rCOFINSAliq.Cd_st_xml = COFINSAliq.InnerText;
                                                            else if (COFINSAliq.LocalName.Equals("vBC"))
                                                                rCOFINSAliq.Vl_basecalc_xml = decimal.Parse(COFINSAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSAliq.LocalName.Equals("pCOFINS"))
                                                                rCOFINSAliq.Pc_aliquota_xml = decimal.Parse(COFINSAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSAliq.LocalName.Equals("vCOFINS"))
                                                                rCOFINSAliq.Vl_imposto_xml = decimal.Parse(COFINSAliq.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rCOFINSAliq);
                                                        break;
                                                    }
                                                case "COFINSQtde":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCOFINSQtd = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rCOFINSQtd.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).Cd_imposto;
                                                        rCOFINSQtd.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).ds_imposto;
                                                        rCOFINSQtd.Imposto = lImpostos.FirstOrDefault(p => p.St_Cofins);
                                                        foreach (XmlNode COFINSQtd in noI.LastChild.ChildNodes)
                                                        {
                                                            if (COFINSQtd.LocalName.Equals("CST"))
                                                                rCOFINSQtd.Cd_st_xml = COFINSQtd.InnerText;
                                                            else if (COFINSQtd.LocalName.Equals("vBC"))
                                                                rCOFINSQtd.Vl_basecalc_xml = decimal.Parse(COFINSQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSQtd.LocalName.Equals("pCOFINS"))
                                                                rCOFINSQtd.Pc_aliquota_xml = decimal.Parse(COFINSQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSQtd.LocalName.Equals("vCOFINS"))
                                                                rCOFINSQtd.Vl_imposto_xml = decimal.Parse(COFINSQtd.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rCOFINSQtd);
                                                        break;
                                                    }
                                                case "COFINSNT":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCOFINSNT = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rCOFINSNT.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).Cd_imposto;
                                                        rCOFINSNT.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).ds_imposto;
                                                        rCOFINSNT.Imposto = lImpostos.FirstOrDefault(p => p.St_Cofins);
                                                        foreach (XmlNode COFINSNT in noI.LastChild.ChildNodes)
                                                        {
                                                            if (COFINSNT.LocalName.Equals("CST"))
                                                                rCOFINSNT.Cd_st_xml = COFINSNT.InnerText;
                                                        }
                                                        rItem.lImpostos.Add(rCOFINSNT);
                                                        break;
                                                    }
                                                case "COFINSOutr":
                                                    {
                                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rCOFINSOut = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
                                                        rCOFINSOut.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).Cd_imposto;
                                                        rCOFINSOut.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).ds_imposto;
                                                        rCOFINSOut.Imposto = lImpostos.FirstOrDefault(p => p.St_Cofins);
                                                        foreach (XmlNode COFINSOut in noI.LastChild.ChildNodes)
                                                        {
                                                            if (COFINSOut.LocalName.Equals("CST"))
                                                                rCOFINSOut.Cd_st_xml = COFINSOut.InnerText;
                                                            else if (COFINSOut.LocalName.Equals("vBC"))
                                                                rCOFINSOut.Vl_basecalc_xml = decimal.Parse(COFINSOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSOut.LocalName.Equals("pCOFINS"))
                                                                rCOFINSOut.Pc_aliquota_xml = decimal.Parse(COFINSOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                            else if (COFINSOut.LocalName.Equals("vCOFINS"))
                                                                rCOFINSOut.Vl_imposto_xml = decimal.Parse(COFINSOut.InnerText, new System.Globalization.CultureInfo("en-US"));
                                                        }
                                                        rItem.lImpostos.Add(rCOFINSOut);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //Buscar produto no sistema
                        if (!string.IsNullOrEmpty(rPedido.CD_Clifor))
                        {
                            CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                                new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_EST_Produto_X_Fornecedor x " +
                                                            "where x.cd_produto = a.cd_produto " +
                                                            "and x.codigo_fornecedor = '" + rItem.Cd_produto_xml.Trim() + "' " +
                                                            "and x.cd_fornecedor = '" + rPedido.CD_Clifor.Trim() + "')"
                                            }
                                        }, 1, string.Empty, string.Empty, string.Empty);
                            if (lProd.Count.Equals(1))
                            {
                                rItem.rProd = lProd[0];
                                rItem.Cd_produto = lProd[0].CD_Produto;
                                rItem.Ds_produto = lProd[0].DS_Produto;
                                rItem.Cd_condfiscal_produto = lProd[0].CD_CondFiscal_Produto;
                                rItem.Sigla_unidade = lProd[0].Sigla_unidade;
                                rItem.Ncm = lProd[0].Ncm;
                                if (rItem.Ncm.Trim() != rItem.Ncm_xml.Trim())
                                    ncm.ForeColor = Color.Red;
                                rItem.Cd_anp = lProd[0].Cd_anp;
                                if (rItem.Cd_anp.Trim() != rItem.Cd_anp_xml.Trim())
                                    cd_anp.ForeColor = Color.Red;
                                //Buscar CFOP
                                object obj = new CamadaDados.Fiscal.TCD_Mov_X_CFOP().BuscarEscalar(
                                                new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.CD_Movimentacao",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_movimentacao.Text.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.CD_CondFiscal_Produto",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + lProd[0].CD_CondFiscal_Produto.Trim() + "'"
                                                            }
                                                        }, rItem.Cfop_xml.Trim().Substring(0, 1).Equals("5") ? "a.CD_CFOP_DentroEstado" : "a.CD_CFOP_ForaEstado");
                                if (obj != null)
                                    rItem.Cfop = obj.ToString();
                                //Buscar impostos estaduais
                                string ObsFiscal = string.Empty;
                                rItem.lImpostos.ConcatenarXMLNFe(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(cd_empresa.Text,
                                                                                                                                             rEndFornec.Cd_uf,
                                                                                                                                             cd_uf_empresa.Text,
                                                                                                                                             cd_movimentacao.Text,
                                                                                                                                             "E",
                                                                                                                                             lClifor[0].Cd_condfiscal_clifor,
                                                                                                                                             rItem.Cd_condfiscal_produto,
                                                                                                                                             rItem.Vl_liquido,
                                                                                                                                             rItem.Quantidade,
                                                                                                                                             ref ObsFiscal,
                                                                                                                                             null,
                                                                                                                                             cd_produto.Text,
                                                                                                                                             "T",
                                                                                                                                             nr_serie.Text,
                                                                                                                                             null));
                                //Buscar outros impostos
                                rItem.lImpostos.ConcatenarXMLNFe(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lClifor[0].Cd_condfiscal_clifor,
                                                                                                                                                      rItem.Cd_condfiscal_produto,
                                                                                                                                                      cd_movimentacao.Text,
                                                                                                                                                      "E",
                                                                                                                                                      string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero()) ? "F" : "J",
                                                                                                                                                      cd_empresa.Text,
                                                                                                                                                      nr_serie.Text,
                                                                                                                                                      rPedido.CD_Clifor,
                                                                                                                                                      lProd[0].CD_Unidade,
                                                                                                                                                      null,
                                                                                                                                                      rItem.Quantidade,
                                                                                                                                                      rItem.Vl_liquido,
                                                                                                                                                      "T",
                                                                                                                                                      string.Empty,
                                                                                                                                                      null));
                                //Configuracao ICMS
                                if (rItem.lImpostos.Exists(p => p.Imposto.St_ICMS && string.IsNullOrEmpty(p.Cd_st)))
                                {
                                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_ICMS", cd_empresa.Text, null);
                                    if (!string.IsNullOrEmpty(sittrib))
                                        rItem.lImpostos.Find(p => p.Imposto.St_ICMS && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                                }
                                //Configuracao PIS
                                if (rItem.lImpostos.Exists(p => p.Imposto.St_PIS && string.IsNullOrEmpty(p.Cd_st)))
                                {
                                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_PIS", cd_empresa.Text, null);
                                    if (!string.IsNullOrEmpty(sittrib))
                                        rItem.lImpostos.Find(p => p.Imposto.St_PIS && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                                }
                                //Configuracao COFINS
                                if (rItem.lImpostos.Exists(p => p.Imposto.St_Cofins && string.IsNullOrEmpty(p.Cd_st)))
                                {
                                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_COFINS", cd_empresa.Text, null);
                                    if (!string.IsNullOrEmpty(sittrib))
                                        rItem.lImpostos.Find(p => p.Imposto.St_Cofins && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                                }
                                //Valor IPI
                                if (rItem.lImpostos.Exists(p => p.Imposto.St_IPI))
                                {
                                    rItem.lImpostos.Find(p => p.Imposto.St_IPI).Vl_basecalc = rItem.lImpostos.Find(p => p.Imposto.St_IPI).Vl_basecalc_xml;
                                    rItem.lImpostos.Find(p => p.Imposto.St_IPI).Pc_aliquota = rItem.lImpostos.Find(p => p.Imposto.St_IPI).Pc_aliquota_xml;
                                    rItem.lImpostos.Find(p => p.Imposto.St_IPI).Vl_impostocalc = rItem.lImpostos.Find(p => p.Imposto.St_IPI).Vl_imposto_xml;
                                    rItem.lImpostos.Find(p => p.Imposto.St_IPI).St_totalnota = "S";
                                }
                            }
                            //Buscar unidade fornecedor
                            CamadaDados.Estoque.Cadastros.TList_CadUnidade lUnid =
                                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade().Select(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_EST_Produto_X_Fornecedor x " +
                                                            "where x.cd_unidade_fornec = a.cd_unidade " +
                                                            "and x.codigo_fornecedor = '" + rItem.Cd_produto_xml.Trim() + "' " +
                                                            "and x.cd_fornecedor = '" + rPedido.CD_Clifor.Trim() + "')"
                                            }
                                        }, 1, string.Empty);
                            if (lUnid.Count > 0)
                            {
                                rItem.Cd_unidade_fornec = lUnid[0].CD_Unidade;
                                rItem.Ds_unidade_fornec = lUnid[0].DS_Unidade;
                            }
                            //Buscar local armazenagem
                            CamadaDados.Estoque.Cadastros.TList_CadLocalArm lLocal =
                             new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().Select(
                                                new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_est_empresa_x_localarm x " +
                                                                            "where x.cd_local = a.cd_local " +
                                                                            "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_est_localarm_x_produto x " +
                                                                            "where x.cd_local = a.cd_local " +
                                                                            "and x.cd_produto = '" + rItem.Cd_produto.Trim() + "')"
                                                            }
                                                        }, 1, string.Empty);
                            if (lLocal.Count > 0)
                            {
                                rItem.Cd_local = lLocal[0].Cd_local;
                                rItem.Ds_local = lLocal[0].Ds_local;
                            }
                            else
                            {
                                //Buscar Local de Armazenagem
                                CamadaDados.Estoque.Cadastros.TList_Produto_X_Fornecedor lLocalForn =
                                    new CamadaDados.Estoque.Cadastros.TCD_Produto_X_Fornecedor().Select(
                                        new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_produto",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rItem.Cd_produto.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_fornecedor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rPedido.CD_Clifor.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.Codigo_Fornecedor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rItem.Cd_produto_xml.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);
                                if (lLocalForn.Count > 0)
                                {
                                    rItem.Cd_local = lLocalForn[0].Cd_local;
                                    rItem.Ds_local = lLocalForn[0].Ds_local;
                                }
                            }
                        }
                        if ((rItem.rProd != null) && (!string.IsNullOrEmpty(rItem.Cd_unidade_fornec)))
                        {
                            //Converter unidade
                            try
                            {
                                //Verificar se existe conversao de unidade para as medidas
                                rItem.Quantidade =
                                CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(rItem.Cd_unidade_fornec,
                                                                                               rItem.rProd.CD_Unidade,
                                                                                               rItem.Quantidade_xml,
                                                                                               3,
                                                                                               null);
                                rItem.Vl_unitario = rItem.Vl_subtotal / rItem.Quantidade;
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                        lItens.Add(rItem);
                    }
                }
                #endregion
                #region Totais NFe
                lNo = xml.GetElementsByTagName("total");
                if (lNo.Count > 0)
                    foreach (XmlNode noT in lNo[0].ChildNodes)
                    {
                        if (noT.LocalName.Equals("ICMSTot"))
                            foreach (XmlNode noIT in noT.ChildNodes)
                            {
                                if (noIT.LocalName.Equals("vBC"))
                                    tot_baseicms.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vICMS"))
                                    tot_icms.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vBCST"))
                                    tot_basecalcicmsst.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vST"))
                                    tot_icmsst.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vProd"))
                                    tot_produtos.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vFrete"))
                                    tot_frete.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vSeg"))
                                    tot_seguro.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vDesc"))
                                    tot_desconto.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vII"))
                                    tot_ii.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vIPI"))
                                    tot_ipi.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vPIS"))
                                    tot_pis.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vCOFINS"))
                                    tot_cofins.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vOutro"))
                                    tot_outrasdesp.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noIT.LocalName.Equals("vNF"))
                                    tot_nfe.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("en-US"));
                            }
                    }
                #endregion
                #region Frete
                lNo = xml.GetElementsByTagName("transp");
                if (lNo.Count > 0)
                    if (lNo[0].FirstChild.LocalName.Equals("modFrete"))
                        tp_frete.SelectedValue = lNo[0].FirstChild.InnerText;
                #endregion
                #region Duplicata
                lParc = new CamadaDados.Financeiro.Duplicata.TList_Parcelas();
                lNo = xml.GetElementsByTagName("cobr");
                if (lNo.Count > 0)
                {
                    foreach (XmlNode noDup in lNo[0].ChildNodes)
                    {
                        if (noDup.LocalName.Equals("dup"))
                        {
                            CamadaDados.Financeiro.Duplicata.TParcelas rParc = new CamadaDados.Financeiro.Duplicata.TParcelas();
                            foreach (XmlNode noP in noDup.ChildNodes)
                            {
                                if (noP.LocalName.Equals("dVenc"))
                                    rParc.Dt_vencimento = DateTime.Parse(noP.InnerText);
                                else if (noP.LocalName.Equals("vDup"))
                                    rParc.Vl_parcela = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                            }
                            lParc.Add(rParc);
                        }
                    }
                    if (lParc.Count > 0)
                    {
                        //Buscar condicao de pagamento
                        CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(!string.IsNullOrEmpty(rPedido.CD_CondPGTO) ? rPedido.CD_CondPGTO : string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      lParc.Count,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
                        if (lCond.Count > 0)
                        {
                            if (lCond.Count.Equals(1))
                            {
                                rCondPgto = lCond[0];
                                cd_condpgto.Text = lCond[0].Cd_condpgto;
                                ds_condpgto.Text = lCond[0].Ds_condpgto;
                                St_finavista = lCond[0].Qt_parcelas.Equals(decimal.Zero);
                                bsParcela.DataSource = lParc;
                            }
                            else
                                bb_condpgto_Click(this, new EventArgs());
                        }
                    }
                }
                #endregion
                bsItensXMLNFe.DataSource = lItens;
                bsItensXMLNFe_PositionChanged(this, new EventArgs());
            }
            else
                Close();
        }

        private void GravarProduto_X_Fornecedor()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text) &&
                   !string.IsNullOrEmpty(rPedido.CD_Clifor))
            {
                try
                {
                    //Gravar configuracao produto x fornecedor
                    CamadaNegocio.Estoque.Cadastros.TCN_Produto_X_Fornecedor.Gravar(
                        new CamadaDados.Estoque.Cadastros.TRegistro_Produto_X_Fornecedor()
                        {
                            Cd_fornecedor = rPedido.CD_Clifor,
                            Cd_produto = cd_produto.Text,
                            Cd_unidade_fornec = cd_unidade_fornec.Text,
                            Codigo_fornecedor = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_produto_xml,
                            Cd_local = cd_local.Text
                        }, null);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cfg_pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar TIPO PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Empresa não localizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpNFe;
                return;
            }
            if (!St_serieexiste)
            {
                MessageBox.Show("Serie não cadastrada no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpNFe;
                return;
            }
            if (!St_modeloexiste)
            {
                MessageBox.Show("Modelo documento fiscal não cadastrado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpNFe;
                return;
            }
            if (dt_entrada.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data entrada NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpNFe;
                dt_entrada.Focus();
                return;
            }
            if (bsItensXMLNFe.Count.Equals(0))
            {
                MessageBox.Show("Não foi importado item NFe do arquivo XML.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpItens;
                tcItens.SelectedTab = tpProdutos;
                return;
            }
            if ((bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).Exists(p => string.IsNullOrEmpty(p.Cd_produto)))
            {
                MessageBox.Show("Existe item da NFe sem produto identificado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpItens;
                tcItens.SelectedTab = tpProdutos;
                return;
            }
            if ((bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).Exists(p => string.IsNullOrEmpty(p.Cd_local)))
            {
                MessageBox.Show("Existe item da NFe sem local de armazenagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpItens;
                tcItens.SelectedTab = tpProdutos;
                return;
            }
            if ((bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).Exists(p => string.IsNullOrEmpty(p.Cfop)))
            {
                MessageBox.Show("Existe item da NFe sem CFOP.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpItens;
                tcItens.SelectedTab = tpProdutos;
                return;
            }
            bool st_validaimposto = true;
            (bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).ForEach(p =>
                st_validaimposto = p.lImpostos.Exists(v => (v.Imposto.St_ICMS ||
                                                            v.Imposto.St_PIS ||
                                                            v.Imposto.St_Cofins) &&
                                                            string.IsNullOrEmpty(v.Cd_st)));
            if (st_validaimposto)
            {
                MessageBox.Show("Existe imposto item sem configuração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpItens;
                tcItens.SelectedTab = tpImpostos;
                return;
            }
            if ((bsParcela.Count > 0) && string.IsNullOrEmpty(cd_condpgto.Text))
            {
                MessageBox.Show("Obrigatorio informar condição de pagamento para gravar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcCentral.SelectedTab = tpDup;
                return;
            }
            if (St_cmifinanceiro)
            {
                if (string.IsNullOrEmpty(tp_duplicata.Text))
                {
                    MessageBox.Show("Obrigatorio informar tipo duplicata para gerar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcCentral.SelectedTab = tpDup;
                    return;
                }
                if (string.IsNullOrEmpty(tp_docto.Text))
                {
                    MessageBox.Show("Obrigatorio informar tipo documento para gerar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcCentral.SelectedTab = tpDup;
                    return;
                }
                if (string.IsNullOrEmpty(cd_condpgto.Text))
                {
                    MessageBox.Show("Obrigatorio informar condição pagamento para gerar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcCentral.SelectedTab = tpDup;
                    return;
                }
                if (string.IsNullOrEmpty(cd_historico.Text))
                {
                    MessageBox.Show("Obrigatorio informar historico para gerar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcCentral.SelectedTab = tpDup;
                    return;
                }
                if (bsParcela.Count.Equals(0))
                {
                    MessageBox.Show("Não existe parcela gerada para gravar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcCentral.SelectedTab = tpDup;
                    return;
                }
            }
            try
            {
                if (bsParcela.Count > 0 && St_cmifinanceiro)
                {
                    //se duplicata for a vista abrir tela duplicata
                    if (St_finavista)
                        GerarDup();
                    else
                        //Verificar se a empresa utiliza rateio na provisao
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresa.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                    {
                        //Verificar historico informado está ligado a um centro de resultado
                        TList_CentroResultado lCentro =
                            new TCD_CentroResultado().Select(
                                        new TpBusca[]
                                        {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_FIN_CentroResult_X_Historico x " +
                                                                    "where x.cd_centroresult = a.cd_centroresult " +
                                                                    "and x.cd_historico = '" + cd_historico.Text.Trim() + "') "
                                                    }
                                        }, 0, string.Empty);
                        if (lCentro.Count == 1)
                        {
                            lCustoLancto.Add(
                               new TRegistro_LanCCustoLancto()
                               {
                                   Cd_empresa = cd_empresa.Text,
                                   Cd_centroresult = lCentro[0].Cd_centroresult,
                                   Vl_lancto = (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas).Sum(p => p.Vl_parcela),
                                   Dt_lanctostr = dt_emissao.Text,
                                   Tp_registro = "A"
                               });
                        }
                        else if (lCentro.Count > 1)
                        {
                            using (TFRateioCentro fRateio = new TFRateioCentro())
                            {
                                TList_LanCCustoLancto lCCusto =
                                    new TList_LanCCustoLancto();
                                lCentro.ForEach(p =>
                                    lCCusto.Add(new TRegistro_LanCCustoLancto()
                                    {
                                        Cd_centroresult = p.Cd_centroresult,
                                        Ds_centroresultado = p.Ds_centroresultado,
                                        Dt_lanctostr = dt_emissao.Text,
                                        Tp_registro = "M",
                                    }));
                                fRateio.lCCusto = lCCusto;
                                fRateio.vVl_Documento = (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas).Sum(p => p.Vl_parcela);
                                if (fRateio.ShowDialog() == DialogResult.OK)
                                    if (fRateio.lCCusto != null)
                                        lCustoLancto = fRateio.lCCusto;
                            }
                        }
                        else
                        {
                            using (TFRateioCResultado fRateio = new TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas).Sum(p => p.Vl_parcela);
                                fRateio.lCResultado = lCustoLancto = new TList_LanCCustoLancto();
                                fRateio.lCResultadoDel = lCustoLanctoDel = new TList_LanCCustoLancto();
                                fRateio.Tp_mov = tp_mov.Text;
                                fRateio.Dt_movimento = DateTime.Parse(dt_emissao.Text);
                                fRateio.ShowDialog();
                                lCustoLancto = fRateio.lCResultado;
                                lCustoLanctoDel = fRateio.lCResultadoDel;
                            }
                        }
                    }
                }
                //Verificar se itens são materia-prima ou embalagem e se a empresa esta configurada para gerar lote materia-prima
                if ((bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>).Exists(p =>
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_rastrear, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") != null))
                {
                    using (Producao.TFMovLote fLote = new Producao.TFMovLote())
                    {
                        fLote.pCd_empresa = cd_empresa.Text;
                        fLote.pNm_empresa = nm_empresa.Text;
                        fLote.pCd_fornecedor = rPedido.CD_Clifor;
                        fLote.pNm_fornecedor = rPedido.NM_Clifor;
                        fLote.pTp_mov = "E";
                        fLote.lItens = (bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>);
                        if (fLote.ShowDialog() == DialogResult.OK)
                        {
                            if (fLote.lItens != null)
                                bsItensXMLNFe.DataSource = fLote.lItens;
                            else
                            {
                                MessageBox.Show("Obrigatório informar Lote!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Lote!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.ProcessarXMLNFeEntrada(cd_empresa.Text,
                                                                                               rPedido.CD_Clifor,
                                                                                               rPedido.CD_Endereco,
                                                                                               lClifor[0].Cd_condfiscal_clifor,
                                                                                               string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero()) ? "F" : "J",
                                                                                               cfg_pedido.Text,
                                                                                               tp_frete.SelectedValue == null ? "9" : tp_frete.SelectedValue.ToString(),
                                                                                               nr_serie.Text,
                                                                                               cd_modelo.Text,
                                                                                               nr_notafiscal.Text,
                                                                                               dt_emissao.Text,
                                                                                               dt_entrada.Text,
                                                                                               chave_acesso.Text,
                                                                                               tp_duplicata.Text,
                                                                                               tp_docto.Text,
                                                                                               cd_condpgto.Text,
                                                                                               cd_historico.Text,
                                                                                               cd_cmi.Text,
                                                                                               St_cmifinanceiro,
                                                                                               vl_acrescimo_fin.Value,
                                                                                               vl_desconto_fin.Value,
                                                                                               rPedido,
                                                                                               (bsItensXMLNFe.List as List<CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe>),
                                                                                               St_finavista ? null :
                                                                                               (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas),
                                                                                               St_finavista ? rDup : null,
                                                                                               lCustoLancto,
                                                                                               lCustoLanctoDel,
                                                                                               null);
                MessageBox.Show("Nota fiscal gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Copiar arquivo XML
                string path = "C://Aliance.Net//XML ENTRADA//" + CamadaDados.UtilData.Data_Servidor().ToString("MM-yyyy");
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(path + "//" + System.IO.Path.GetFileName(NomeArquivo)))
                    System.IO.File.Copy(NomeArquivo, path + "//" + System.IO.Path.GetFileName(NomeArquivo));
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + cfg_pedido.Text.Trim() + "'"
                        }
                    }, "a.st_atualizaprecovenda") != null)
                {
                    CamadaNegocio.Estoque.Cadastros.TCN_AtualizaPrecoPerc.AtualizarPreco(rNf.ItensNota, null);
                    using (TFPrecoItem fPreco = new TFPrecoItem())
                    {
                        fPreco.Cd_empresa = rNf.Cd_empresa;
                        fPreco.Nm_empresa = rNf.Nm_empresa;
                        fPreco.lItens = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
                        rNf.ItensNota.FindAll(p=> p.St_atualizaprecovenda).ForEach(p => fPreco.lItens.Add(p));
                        fPreco.ShowDialog();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UltimaCompra()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text.Trim())) &&
                (!string.IsNullOrEmpty(cd_produto.Text.Trim())))
            {
                CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras UltimaCompra =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.tp_movimento",
                                                            vOperador = "=",
                                                            vVL_Busca = "'E'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "b.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "b.cd_produto",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'N'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'N'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'S'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        }
                                                    }, 1);
                if (UltimaCompra.Count > 0)
                    vl_ultimacompra.Value = UltimaCompra[0].Vl_UnitCustoNota;
            }
            else
                vl_ultimacompra.Value = decimal.Zero;
        }

        private decimal BuscarSaldoLocal()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(cd_local.Text)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(cd_empresa.Text, cd_produto.Text, cd_local.Text, ref saldo, null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void GerarDup()
        {
            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
            {
                fDuplicata.vCd_empresa = cd_empresa.Text;
                fDuplicata.vNm_empresa = nm_empresa.Text;
                fDuplicata.vCd_clifor = rPedido.CD_Clifor;
                fDuplicata.vNm_clifor = rPedido.NM_Clifor;
                fDuplicata.vCd_endereco = rPedido.CD_Endereco;
                fDuplicata.vDs_endereco = rPedido.DS_Endereco;
                fDuplicata.vSt_ecf = true;
                fDuplicata.vTp_mov = tp_mov.Text;
                fDuplicata.vTp_duplicata = tp_duplicata.Text;
                fDuplicata.vDs_tpduplicata = ds_tpduplicata.Text;
                fDuplicata.vTp_docto = tp_docto.Text;
                fDuplicata.vDs_tpdocto = ds_tpdocto.Text;
                fDuplicata.vCd_historico = cd_historico.Text;
                fDuplicata.vDs_historico = ds_historico.Text;
                fDuplicata.vCd_condpgto = cd_condpgto.Text;
                fDuplicata.vDs_condpgto = ds_condpgto.Text;
                //Buscar Moeda Padrao
                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(cd_empresa.Text, null);
                if (tabela != null)
                    if (tabela.Count > 0)
                    {
                        fDuplicata.vCd_moeda = tabela[0].Cd_moeda;
                        fDuplicata.vDs_moeda = tabela[0].Ds_moeda_singular;
                    }
                fDuplicata.vVl_documento = tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value;
                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                fDuplicata.vNr_docto = nr_notafiscal.Text;
                if (fDuplicata.ShowDialog() == DialogResult.OK)
                    rDup = fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                else
                    throw new Exception("Obrigatorio informar Financeiro para Gerar Duplicata!");
            }
        }

        private void BuscarProduto()
        {
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                  "where x.cd_produto = a.cd_produto " +
                                  "and x.nr_pedido = " + rPedido.Nr_pedido.ToString() + ")";
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             cd_empresa.Text,
                                                             nm_empresa.Text,

                                                             string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                             filtro);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             cd_empresa.Text,
                                                             nm_empresa.Text,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                             filtro);
            else
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vOperador = "<>";
                filtro[filtro.Length - 2].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                                      "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))";
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                {
                    //se lista possuir mais de um produto dar prioridade para Código do produto
                    if (lProd.Count > 1)
                    {
                        //Buscar lengt cd_produto
                        CamadaDados.Diversos.TList_CadParamSys lParam =
                            CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         null);
                        bool st_produto = false;
                        if (lParam.Count > 0)
                            if (cd_produto.Text.Trim().Length < lParam[0].Tamanho)
                                cd_produto.Text = cd_produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                        //se tamanho for maior qua o parametro do produtos não verificar na lista se existe produto identico
                        if (cd_produto.Text.Trim().Length == lParam[0].Tamanho)
                        {
                            for (int i = 0; lProd.Count > i; i++)
                                if (lProd[i].CD_Produto.Equals(cd_produto.Text))
                                {
                                    rProd = lProd[i];
                                    st_produto = true;
                                    break;
                                }
                        }
                        if (!st_produto)
                            rProd = lProd[0];
                    }
                    else
                        rProd = lProd[0];
                }
            }
            if (rProd != null)
            {
                //Buscar registro produto
                cd_produto.Text = rProd.CD_Produto;
                ds_produto.Text = rProd.DS_Produto;
                (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd = rProd;
                condfiscal.Text = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_CondFiscal_Produto;
                sigla_unidade.Text = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.Sigla_unidade;
                ncm.Text = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.Ncm;
                if (ncm.Text.Trim() != ncm_xml.Text.Trim())
                    ncm.ForeColor = Color.Red;
                cd_anp.Text = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.Cd_anp;
                if (cd_anp.Text.Trim() != cd_anp_xml.Text.Trim())
                    cd_anp.ForeColor = Color.Red;
                //Buscar cfop produto
                object obj = new CamadaDados.Fiscal.TCD_Mov_X_CFOP().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.CD_Movimentacao",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_movimentacao.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.CD_CondFiscal_Produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + condfiscal.Text.Trim() + "'"
                                    }
                                }, cd_cfop_xml.Text.Trim().Substring(0, 1).Equals("5") ? "a.CD_CFOP_DentroEstado" : "a.CD_CFOP_ForaEstado");
                if (obj != null)
                    cd_cfop.Text = obj.ToString();
                //Buscar local armazenagem
                obj = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_empresa_x_localarm x " +
                                                    "where x.cd_local = a.cd_local " +
                                                    "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_localarm_x_produto x " +
                                                    "where x.cd_local = a.cd_local " +
                                                    "and x.cd_produto = '" + cd_produto.Text.Trim() + "')"
                                    }
                                }, "a.cd_local");
                if (obj != null)
                {
                    cd_local.Text = obj.ToString();
                    cd_local_Leave(this, new EventArgs());
                }
                //Converter unidade
                if (!string.IsNullOrEmpty((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_unidade_fornec))
                    try
                    {
                        //Verificar se existe conversao de unidade para as medidas
                        quantidade.Value =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_unidade_fornec,
                                                                                       (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_Unidade,
                                                                                       (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade_xml,
                                                                                       3,
                                                                                       null);
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_unitario =
                            (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_subtotal /
                            (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade;
                        bsItensXMLNFe.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                //Buscar impostos estaduais
                string ObsFiscal = string.Empty;
                (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.ConcatenarXMLNFe(
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(cd_empresa.Text,
                                                                                                      rEndFornec.Cd_uf,
                                                                                                      cd_uf_empresa.Text,
                                                                                                      cd_movimentacao.Text,
                                                                                                      "E",
                                                                                                      lClifor[0].Cd_condfiscal_clifor,
                                                                                                      (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto,
                                                                                                      (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_liquido,
                                                                                                      (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade,
                                                                                                      ref ObsFiscal,
                                                                                                      null,
                                                                                                      cd_produto.Text,
                                                                                                      "T",
                                                                                                      nr_serie.Text,
                                                                                                      null));
                //Buscar outros impostos
                (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.ConcatenarXMLNFe(
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lClifor[0].Cd_condfiscal_clifor,
                                                                                                               (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto,
                                                                                                               cd_movimentacao.Text,
                                                                                                               "E",
                                                                                                               string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero()) ? "F" : "J",
                                                                                                               cd_empresa.Text,
                                                                                                               nr_serie.Text,
                                                                                                               rPedido.CD_Clifor,
                                                                                                               (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_Unidade,
                                                                                                               null,
                                                                                                               (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade,
                                                                                                               (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_liquido,
                                                                                                               "T",
                                                                                                               string.Empty,
                                                                                                               null));
                //Configuracao ICMS
                if ((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Exists(p => p.Imposto.St_ICMS && string.IsNullOrEmpty(p.Cd_st)))
                {
                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_ICMS", cd_empresa.Text, null);
                    if (!string.IsNullOrEmpty(sittrib))
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_ICMS && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                }
                //Configuracao PIS
                if ((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Exists(p => p.Imposto.St_PIS && string.IsNullOrEmpty(p.Cd_st)))
                {
                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_PIS", cd_empresa.Text, null);
                    if (!string.IsNullOrEmpty(sittrib))
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_PIS && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                }
                //Configuracao COFINS
                if ((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Exists(p => p.Imposto.St_Cofins && string.IsNullOrEmpty(p.Cd_st)))
                {
                    string sittrib = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_COFINS", cd_empresa.Text, null);
                    if (!string.IsNullOrEmpty(sittrib))
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_Cofins && string.IsNullOrEmpty(p.Cd_st)).Cd_st = sittrib;
                }
                //Valor IPI
                if ((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Exists(p => p.Imposto.St_IPI))
                {
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Vl_basecalc = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Vl_basecalc_xml;
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Pc_aliquota = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Pc_aliquota_xml;
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Vl_impostocalc = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).Vl_imposto_xml;
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.Find(p => p.Imposto.St_IPI).St_totalnota = "S";
                }
                GravarProduto_X_Fornecedor();
                bsItensXMLNFe_PositionChanged(this, new EventArgs());
            }
        }

        private void TFImportXmlPedido_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar configuracao fiscal pedido
            if (rPedido != null)
            {
                cfg_pedido.Text = rPedido.CFG_Pedido;
                ds_tipopedido.Text = rPedido.DS_CFG_Pedido;
                lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedidoFiscal.Buscar(cfg_pedido.Text,
                                                                                  "NO",
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  null);
                if (lCfg.Count > 0)
                {
                    St_cmifinanceiro = !string.IsNullOrEmpty(lCfg[0].Tp_duplicata);
                    cd_movimentacao.Text = lCfg[0].Cd_movtostring;
                    ds_movimentacao.Text = lCfg[0].Ds_movimentacao;
                    cd_cmi.Text = lCfg[0].Cd_cmistring;
                    ds_cmi.Text = lCfg[0].Ds_cmi;
                    tp_duplicata.Text = lCfg[0].Tp_duplicata;
                    ds_tpduplicata.Text = lCfg[0].Ds_tpduplicata;
                    tp_docto.Text = lCfg[0].Tp_doctostr;
                    ds_tpdocto.Text = lCfg[0].Ds_tpdocto;
                    cd_historico.Text = lCfg[0].Cd_historicoMov;
                    ds_historico.Text = lCfg[0].Ds_historicoMov;
                    St_valoresfixos = lCfg[0].St_valoresfixos;
                    St_commoditties = lCfg[0].St_commoditties;
                    cd_cmi_Leave(this, new EventArgs());
                    tp_duplicata_Leave(this, new EventArgs());
                }
                BuscarClifor();
                ImportarXml();
                dt_entrada.Focus();
            }
        }

        private void bsItensXMLNFe_PositionChanged(object sender, EventArgs e)
        {
            //Buscar Ultima Compra
            if (lCfg[0].Tp_movimento.Trim().ToUpper().Equals("E"))
                UltimaCompra();
            if (!string.IsNullOrEmpty(cd_produto.Text) &&
                !string.IsNullOrEmpty(cd_empresa.Text) &&
                !string.IsNullOrEmpty(cd_local.Text))
            {
                //Buscar Vl.Custo
                vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Vl_MedioLocal(cd_empresa.Text, cd_produto.Text, cd_local.Text, null);
            }
            else
                vl_custo.Value = decimal.Zero;
            //Buscar Saldo
            qtd_saldoreal.Value = BuscarSaldoLocal();
        }

        private void BB_CMI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cfg_pedido.Text))
            {
                string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                                 "a.CD_CMI|Cód. CMI|100;" +
                                 "a.TP_Duplicata|TP. Duplicata|80;" +
                                 "d.DS_TpDuplicata|Tipo Duplicata|200";
                string vParam = "f.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'";
                if ((!St_valoresfixos) && St_commoditties)//Contrato fixar nao gerar financeiro
                    vParam += ";a.tp_duplicata|is|null";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cmi, ds_cmi, tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"), vParam);
                if (linha != null)
                {
                    cd_condpgto.Enabled = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                    bb_condpgto.Enabled = cd_condpgto.Enabled;
                    St_cmifinanceiro = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                }
            }
        }

        private void cd_cmi_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cfg_pedido.Text))
            {
                string vColunas = "a.CD_CMI|=|'" + cd_cmi.Text + "';" +
                                  "f.CD_Movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'";
                if ((!St_valoresfixos) && St_commoditties)//Contrato fixar nao pode gerar financeiro
                    vColunas += ";a.tp_duplicata|is|null";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_cmi, ds_cmi, tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
                if (linha != null)
                {
                    cd_condpgto.Enabled = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                    bb_condpgto.Enabled = cd_condpgto.Enabled;
                    St_cmifinanceiro = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                }
            }
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov }, string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveTpDuplicata("a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                                                        string.Empty, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov });
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Docto|=|'" + tp_docto.Text + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                             "TP_Docto|TP. Docto|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
                   vParam += bsParcela.Count.Equals(0) && lParc.Count > 0 ? ";a.qt_parcelas|=|" + lParc.Count : string.Empty;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (!string.IsNullOrEmpty(cd_condpgto.Text))
            {
                rCondPgto = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(cd_condpgto.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                if (rCondPgto.Qt_parcelas.Equals(decimal.Zero))
                {
                    rCondPgto.Qt_parcelas = 1;
                    St_finavista = true;
                }
                else
                    St_finavista = false;

                if (bsParcela.Count > 0 || lParc.Count.Equals(0))
                {
                    bsParcela.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value,
                                                                                                                    decimal.Zero,
                                                                                                                    dt_emissao.Text.Trim() != "/  /" ? DateTime.Parse(dt_emissao.Text) : DateTime.Now,
                                                                                                                    rCondPgto.Qt_parcelas,
                                                                                                                    rCondPgto.Qt_diasdesdobro);
                }
                else
                    bsParcela.DataSource = lParc;
                bsParcela_PositionChanged(this, new EventArgs());
            }
            else
                rCondPgto = null;
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                              "a.CD_CondPgto|Cód. CondPgto|100;" +
                              "d.CD_Juro|Cód. Juro|100;" +
                              "d.DS_Juro|Descrição Juro|350";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), bsParcela.Count.Equals(0) && lParc.Count > 0 ? "a.qt_parcelas|=|" + lParc.Count : string.Empty);
            if (!string.IsNullOrEmpty(cd_condpgto.Text))
            {
                rCondPgto = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(cd_condpgto.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                if (rCondPgto.Qt_parcelas.Equals(decimal.Zero))
                {
                    rCondPgto.Qt_parcelas = 1;
                    St_finavista = true;
                }
                else
                    St_finavista = false;
                if (bsParcela.Count > 0 || lParc.Count.Equals(0))
                {
                    bsParcela.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value,
                                                                                                                    decimal.Zero,
                                                                                                                    dt_emissao.Text.Trim() != "/  /" ? DateTime.Parse(dt_emissao.Text) : DateTime.Now,
                                                                                                                    rCondPgto.Qt_parcelas,
                                                                                                                    rCondPgto.Qt_diasdesdobro);
                }
                else
                    bsParcela.DataSource = lParc;
                bsParcela_PositionChanged(this, new EventArgs());
            }
            else
                rCondPgto = null;
        }

        private void bb_addCondPgto_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCad_CondPGTO fCond = new Financeiro.Cadastros.TFCad_CondPGTO())
            {
                fCond.ShowDialog();
                //Buscar condicao de pagamento
                CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              bsParcela.Count,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              null);
                if (lCond.Count > 0)
                {
                    rCondPgto = lCond[0];
                    cd_condpgto.Text = lCond[0].Cd_condpgto;
                    ds_condpgto.Text = lCond[0].Ds_condpgto;
                }
            }
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text + "';" +
                             "a.TP_Mov|=|'" + (lCfg[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R") + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                             "a.CD_Historico|Cód. Histórico|100;" +
                             "a.TP_Mov|Natureza|100;" +
                             "a.cd_Historico_Quitacao|Cd. Quitação|80;" +
                             "e.DS_Historico|Historico Quitação|200";
            string vParamFixo = "a.TP_Mov|=|'" + (lCfg[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R") + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            (bsParcela.Current as CamadaDados.Financeiro.Duplicata.TParcelas).Dt_vencimentostr = dt_vencto.Text;
            CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.ValidarDtEmissao(bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas,
                                                                                 dt_emissao.Text.Trim() != "/  /" ? DateTime.Parse(dt_emissao.Text) : DateTime.Now,
                                                                                 rCondPgto.Qt_diasdesdobro,
                                                                                 bsParcela.Position);
            bsParcela.ResetBindings(true);
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            (bsParcela.Current as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela = VL_Parcela.Value;
            CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.RecalculaParc(bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas,
                                                                                     tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value,
                                                                                     bsParcela.Position);
            bsParcela.ResetBindings(true);
        }

        private void vl_acrescimo_fin_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_condpgto.Text)))
            {
                rCondPgto = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(cd_condpgto.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                bsParcela.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value,
                                                                                                            decimal.Zero,
                                                                                                            dt_emissao.Text.Trim() != "/  /" ? DateTime.Parse(dt_emissao.Text) : DateTime.Now,
                                                                                                            rCondPgto.Qt_parcelas,
                                                                                                            rCondPgto.Qt_diasdesdobro);
            }
        }

        private void vl_desconto_fin_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_condpgto.Text)))
            {
                rCondPgto = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(cd_condpgto.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                bsParcela.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(tot_nfe.Value + vl_acrescimo_fin.Value - vl_desconto_fin.Value,
                                                                                                            decimal.Zero,
                                                                                                            dt_emissao.Text.Trim() != "/  /" ? DateTime.Parse(dt_emissao.Text) : DateTime.Now,
                                                                                                            rCondPgto.Qt_parcelas,
                                                                                                            rCondPgto.Qt_diasdesdobro);
            }
        }

        private void bb_addProduto_Click(object sender, EventArgs e)
        {
            if (bsItensXMLNFe.Current != null)
            {
                if ((!string.IsNullOrEmpty(ncm_xml.Text)) && string.IsNullOrEmpty(ncm.Text))
                {
                     //Verificar se o ncm ja nao existe
                    if (new CamadaDados.Fiscal.TCD_CadNCM().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.ncm",
                                vOperador = "=",
                                vVL_Busca = "'" + ncm_xml.Text.Trim() + "'"
                            }
                        }, "1") == null)
                    {
                        InputBox ibp = new InputBox();
                        ibp.Text = "NCM";
                        string ds_ncm = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(ds_ncm))
                        {
                            MessageBox.Show("Obrigatorio informar descrição NCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(
                                new CamadaDados.Fiscal.TRegistro_CadNCM()
                                {
                                    NCM = ncm_xml.Text,
                                    Ds_NCM = ds_ncm
                                });
                            MessageBox.Show("NCM gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                        ncm.Text = ncm_xml.Text;
                }
                using (Proc_Commoditties.TFAtualizaCadProduto fProd = new Proc_Commoditties.TFAtualizaCadProduto())
                {
                    if ((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd != null)
                    {
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.Ncm = ncm_xml.Text;
                        (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.Cd_anp = cd_anp_xml.Text;
                        fProd.rProd = (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd;
                    }
                    else
                    {
                        CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                        rProd.DS_Produto = ds_produto_xml.Text;
                        rProd.Ncm = ncm_xml.Text;
                        rProd.Cd_anp = cd_anp.Text;
                        fProd.rProd = rProd;
                    }
                    if (fProd.ShowDialog() == DialogResult.OK)
                        if (fProd.rProd != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                                MessageBox.Show("Produto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Buscar registro produto
                                cd_produto.Text = fProd.rProd.CD_Produto;
                                cd_produto_Leave(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            BuscarProduto();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string prod = cd_produto.Text;
            cd_produto.Text = string.Empty;
            BuscarProduto();
            if (string.IsNullOrEmpty(cd_produto.Text))
                cd_produto.Text = prod;
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
                if (!string.IsNullOrEmpty(cd_produto.Text))
                    List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
                string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "'";
                FormBusca.UtilPesquisa.EDIT_LEAVE(vParam,
                                        new Componentes.EditDefault[] { cd_local, ds_local },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text));
                if (!string.IsNullOrEmpty(cd_local.Text))
                    GravarProduto_X_Fornecedor();
                bsItensXMLNFe_PositionChanged(this, new EventArgs());
            }
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
                if (!string.IsNullOrEmpty(cd_produto.Text))
                    List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
                string vParam = string.Empty;
                FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                    new Componentes.EditDefault[] { cd_local, ds_local },
                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text),
                    vParam);
                if (!string.IsNullOrEmpty(cd_local.Text))
                    GravarProduto_X_Fornecedor();
                bsItensXMLNFe_PositionChanged(this, new EventArgs());
            }
        }

        private void bb_addNcm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ncm_xml.Text))
                //Verificar se o ncm ja nao existe
                if (new CamadaDados.Fiscal.TCD_CadNCM().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.ncm",
                            vOperador = "=",
                            vVL_Busca = "'" + ncm_xml.Text.Trim() + "'"
                        }
                    }, "1") == null)
                {
                    InputBox ibp = new InputBox();
                    ibp.Text = "NCM";
                    string ds_ncm = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds_ncm))
                    {
                        MessageBox.Show("Obrigatorio informar descrição NCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(
                            new CamadaDados.Fiscal.TRegistro_CadNCM()
                            {
                                NCM = ncm_xml.Text,
                                Ds_NCM = ds_ncm
                            });
                        MessageBox.Show("NCM gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("NCM ja cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cd_unidade_fornec_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade_fornec.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidade_fornec, ds_unidade_fornec },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
            if ((!string.IsNullOrEmpty(cd_unidade_fornec.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)))
            {
                try
                {
                    //Verificar se existe conversao de unidade para as medidas
                    quantidade.Value =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(cd_unidade_fornec.Text,
                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_Unidade,
                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade_xml,
                                                                                   3,
                                                                                   null);
                    vl_unitario.Value = vl_subtotal.Value / quantidade.Value;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                GravarProduto_X_Fornecedor();
            }
        }

        private void bb_unidade_fornec_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|200;" +
                              "a.cd_unidade|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidade_fornec, ds_unidade_fornec },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
            if ((!string.IsNullOrEmpty(cd_unidade_fornec.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)))
            {
                try
                {
                    //Verificar se existe conversao de unidade para as medidas
                    quantidade.Value =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(cd_unidade_fornec.Text,
                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_Unidade,
                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade_xml,
                                                                                   3,
                                                                                   null);
                    vl_unitario.Value = vl_subtotal.Value / quantidade.Value;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                GravarProduto_X_Fornecedor();
            }
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_cfop_xml.Text))
            {
                string vParam = "a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "';" +
                                "substring(a.cd_cfop, 1, 1)|=|'" + (cd_cfop_xml.Text.Trim().Substring(0, 1).Equals("5") ? "1" : "2") + "'";
                FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cfop },
                    new CamadaDados.Fiscal.TCD_CadCFOP());
            }
        }

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_cfop_xml.Text))
            {
                string vColunas = "a.ds_cfop|CFOP|200;" +
                                  "a.cd_cfop|Codigo|80";
                string vParam = "substring(a.cd_cfop, 1, 1)|=|'" + (cd_cfop_xml.Text.Trim().Substring(0, 1).Equals("5") ? "1" : "2") + "'";
                FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop },
                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
            }
        }

        private void bb_addAnp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_anp_xml.Text))
                //Verificar se o codigo ANP nao existe
                if (new CamadaDados.Estoque.Cadastros.TCD_CodANP().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_anp",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_anp_xml.Text.Trim() + "'"
                        }
                    }, "1") == null)
                {
                    InputBox ibp = new InputBox();
                    ibp.Text = "Codigo ANP";
                    string ds_anp = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds_anp))
                    {
                        MessageBox.Show("Obrigatorio informar descrição codigo ANP.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_CodANP.Gravar(
                            new CamadaDados.Estoque.Cadastros.TRegistro_CodANP()
                            {
                                Cd_anp = cd_anp_xml.Text,
                                Ds_anp = ds_anp
                            }, null);
                        MessageBox.Show("Codigo ANP gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Codigo ANP ja cadastrado no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_atualizaQtde_Click(object sender, EventArgs e)
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Text = "Quantidade Item";
                if (fQtde.ShowDialog() == DialogResult.OK)
                {
                    quantidade.Value = fQtde.Quantidade;
                    vl_unitario.Value = vl_subtotal.Value / quantidade.Value;
                }
            }
        }

        private void bb_addSerie_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(nr_serie.Text)) && (!St_serieexiste))
            {
                InputBox ibp = new InputBox();
                ibp.Text = "Serie Nota Fiscal";
                string ds_serie = ibp.ShowDialog();
                if (string.IsNullOrEmpty(ds_serie))
                {
                    MessageBox.Show("Obrigatorio informar descrição SERIE NOTA FISCAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF()
                        {
                            Nr_Serie = nr_serie.Text,
                            DS_SerieNf = ds_serie,
                            CD_Modelo = cd_modelo.Text,
                            ST_GeraSintegra = "S",
                            Tp_serie = "M",
                            ST_SequenciaAuto = "N"
                        }, null);
                    MessageBox.Show("Serie gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    St_serieexiste = true;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_addModelo_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_modelo.Text)) && (!St_modeloexiste))
            {
                InputBox ibp = new InputBox();
                ibp.Text = "Modelo Documento Fiscal";
                string ds_modelo = ibp.ShowDialog();
                if (string.IsNullOrEmpty(ds_modelo))
                {
                    MessageBox.Show("Obrigatorio informar descrição MODELO DOCUMENTO FISCAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadModeloNF.Grava_CadModeloNF(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF()
                        {
                            CD_Modelo = cd_modelo.Text,
                            DS_Modelo = ds_modelo
                        }, null);
                    MessageBox.Show("Modelo documento fiscal gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    St_modeloexiste = true;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_impostosEstaduais_Click(object sender, EventArgs e)
        {
            if (bsImpostos.Current != null)
            {
                using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
                {
                    fCondICMS.pCd_empresa = cd_empresa.Text;
                    fCondICMS.pCd_condfiscal_clifor = lClifor[0].Cd_condfiscal_clifor;
                    fCondICMS.pCd_condfiscal_produto = condfiscal.Text;
                    fCondICMS.pCd_movto = cd_movimentacao.Text;
                    fCondICMS.pCd_UfDest = cd_uf_empresa.Text;
                    fCondICMS.pCd_UfOrig = rEndFornec.Cd_uf;
                    fCondICMS.pTp_movimento = lCfg[0].Tp_movimento.Trim();
                    fCondICMS.pCd_imposto = (bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr;
                    if (fCondICMS.ShowDialog() == DialogResult.OK)
                        if ((fCondICMS.rCond != null) &&
                            (fCondICMS.lMov != null) &&
                            (fCondICMS.lUfDestino != null) &&
                            (fCondICMS.lUfOrigem != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                                  fCondICMS.lMov,
                                                                                  fCondICMS.lUfOrigem,
                                                                                  fCondICMS.lUfDestino,
                                                                                  null);
                            }
                            catch
                            { }
                    //Buscar impostos estaduais
                    string ObsFiscal = string.Empty;
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.ConcatenarXMLNFe(
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(cd_empresa.Text,
                                                                                                          rEndFornec.Cd_uf,
                                                                                                          cd_uf_empresa.Text,
                                                                                                          cd_movimentacao.Text,
                                                                                                          lCfg[0].Tp_movimento.Trim(),
                                                                                                          lClifor[0].Cd_condfiscal_clifor,
                                                                                                          (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto,
                                                                                                          (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_liquido,
                                                                                                          (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade,
                                                                                                          ref ObsFiscal,
                                                                                                          null,
                                                                                                          cd_produto.Text,
                                                                                                          "T",
                                                                                                          nr_serie.Text,
                                                                                                          null));
                    bsItensXMLNFe.ResetCurrentItem();
                }
            }
        }

        private void bb_outrosimpostos_Click(object sender, EventArgs e)
        {
            if (bsImpostos.Current != null)
            {
                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                {
                    fCondImposto.pCd_empresa = cd_empresa.Text;
                    fCondImposto.pCd_condfiscal_clifor = lClifor[0].Cd_condfiscal_clifor;
                    fCondImposto.pCd_condfiscal_produto = condfiscal.Text;
                    fCondImposto.pCd_movimentacao = cd_movimentacao.Text;
                    fCondImposto.pTp_faturamento = lCfg[0].Tp_movimento.Trim();
                    fCondImposto.pSt_juridica = !string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero());
                    fCondImposto.pSt_fisica = string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero());
                    fCondImposto.pCd_imposto = (bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr;
                    if (fCondImposto.ShowDialog() == DialogResult.OK)
                        if ((fCondImposto.rCond != null) &&
                        (fCondImposto.lMov != null) &&
                        (fCondImposto.lCondClifor != null) &&
                        (fCondImposto.lCondProd != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                 fCondImposto.lMov,
                                                                                                 fCondImposto.lCondClifor,
                                                                                                 fCondImposto.lCondProd,
                                                                                                 fCondImposto.pSt_fisica,
                                                                                                 fCondImposto.pSt_juridica,
                                                                                                 fCondImposto.pSt_estrangeiro,
                                                                                                 null);
                            }
                            catch { }
                    //Buscar outros impostos
                    (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).lImpostos.ConcatenarXMLNFe(
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lClifor[0].Cd_condfiscal_clifor,
                                                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto,
                                                                                                                   cd_movimentacao.Text,
                                                                                                                   lCfg[0].Tp_movimento.Trim(),
                                                                                                                   string.IsNullOrEmpty(lClifor[0].Nr_cgc.SoNumero()) ? "F" : "J",
                                                                                                                   cd_empresa.Text,
                                                                                                                   nr_serie.Text,
                                                                                                                   rPedido.CD_Clifor,
                                                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).rProd.CD_Unidade,
                                                                                                                   null,
                                                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Quantidade,
                                                                                                                   (bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Vl_liquido,
                                                                                                                   "T",
                                                                                                                   string.Empty,
                                                                                                                   null));
                    bsItensXMLNFe.ResetCurrentItem();
                }
            }
        }

        private void cd_st_Leave(object sender, EventArgs e)
        {
            if (bsImpostos.Current != null)
            {
                string vParam = "a.cd_st|=|'" + cd_st.Text.Trim() + "'";
                if (!string.IsNullOrEmpty((bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr.Trim()))
                    vParam += ";a.cd_imposto|=|" + (bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr;
                if (!string.IsNullOrEmpty(tp_regimetributario.Text) && !string.IsNullOrEmpty((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto.Trim()))
                    vParam += ";isnull(a.st_simplesnacional, 'N')|=|" + (tp_regimetributario.Text.Trim().Equals("1") ? "'S'" : "'N'");
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_st, ds_situacao, tp_situacao }, new CamadaDados.Fiscal.TCD_CadSitTribut());
            }
        }

        private void bb_st_Click(object sender, EventArgs e)
        {
            if (bsImpostos.Current != null)
            {
                string vCond = string.Empty;
                if (!string.IsNullOrEmpty((bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr.Trim()))
                    vCond = "a.cd_imposto|=|" + (bsImpostos.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_impostostr.Trim();
                if (!string.IsNullOrEmpty(tp_regimetributario.Text) && !string.IsNullOrEmpty((bsItensXMLNFe.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe).Cd_condfiscal_produto.Trim()))
                    vCond += ";isnull(a.st_simplesnacional, 'N')|=|" + (tp_regimetributario.Text.Trim().Equals("1") ? "'S'" : "'N'");
                UtilPesquisa.BTN_BUSCA("Ds_situacao|Descrição|200;cd_st|Cd. St|80;tp_situacao|Tipo Situação|80",
                    new Componentes.EditDefault[] { cd_st, ds_situacao, tp_situacao }, new CamadaDados.Fiscal.TCD_CadSitTribut(), vCond);
            }
        }

        private void bsParcela_PositionChanged(object sender, EventArgs e)
        {
            if (rCondPgto != null)
                if (rCondPgto.St_comentradabool)
                {
                    if (bsParcela.Position.Equals(0))
                    {
                        dt_vencto.Enabled = false;
                        VL_Parcela.Enabled = false;
                    }
                    else
                    {
                        dt_vencto.Enabled = rCondPgto.St_solicitardtvenctobool;
                        VL_Parcela.Enabled = bsParcela.Position != bsParcela.Count - 1;
                    }
                }
                else
                {
                    dt_vencto.Enabled = rCondPgto.St_solicitardtvenctobool;
                    VL_Parcela.Enabled = bsParcela.Position != bsParcela.Count - 1;
                }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFImportXmlPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        //private void pc_compaliquota_Leave(object sender, EventArgs e)
        //{
        //    if (vl_basecalc_xml.Value > decimal.Zero && pc_compaliquota.Value > decimal.Zero)
        //        vl_compaliquota.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_basecalc_xml.Value, pc_compaliquota.Value), 100), 2, MidpointRounding.AwayFromZero);
        //}

        //private void vl_compaliquota_Leave(object sender, EventArgs e)
        //{
        //    if (vl_basecalc_xml.Value > decimal.Zero && vl_compaliquota.Value > decimal.Zero)
        //        pc_compaliquota.Value = Math.Round(decimal.Divide(decimal.Multiply(vl_compaliquota.Value, 100), vl_basecalc_xml.Value), 2, MidpointRounding.AwayFromZero);
        //}

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void dt_entrada_Leave(object sender, EventArgs e)
        {
            if (dt_entrada.Text.Trim() != "/  /")
            {
                DateTime dt_servidor = CamadaDados.UtilData.Data_Servidor();
                if ((dt_entrada.Data < dt_servidor ? dt_servidor.Subtract(dt_entrada.Data) : dt_entrada.Data.Subtract(dt_servidor)).Days > 365)
                {
                    MessageBox.Show("Não é permitido lançar nota fiscal com data entrada/saida com diferença MAIOR ou MENOR que 365 dias da data atual.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_entrada.Focus();
                    return;
                }
                if (dt_servidor < dt_entrada.Data)
                {
                    MessageBox.Show("Dt.Entrada não pode ser maior que a data atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_entrada.Clear();
                    dt_entrada.Focus();
                    return;
                }
            }
        }
    }
}
