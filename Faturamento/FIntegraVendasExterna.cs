using CamadaDados.Estoque.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.VendasExterna;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Fiscal;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Fiscal;
using Componentes;
using Financeiro.Cadastros;
using FormBusca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;
using System.Linq;
using CamadaDados.Estoque;
using CamadaDados.Faturamento.NotaFiscal;
using System.Xml;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaNegocio.Financeiro.Bloqueto;

namespace Faturamento
{
    public partial class TFIntegraVendasExterna : Form
    {
        private Token _token;

        public TFIntegraVendasExterna()
        {
            InitializeComponent();
        }

        private bool ValidarToken()
        {
            if (cbEmpresa.SelectedItem == null)
                return false;
            if (_token == null ? true : !_token.St_valido)
            {
                _token = ServiceRest.DataService.GerarToken((cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Login,
                                                                (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Senha,
                                                                (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Licenca,
                                                                (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Integracao);
                return _token != null;
            }
            else return true;
        }

        private TRegistro_LanFaturamento ImportarNFe(string xml)
        {
            TRegistro_LanFaturamento retorno = new TRegistro_LanFaturamento();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList lNo = doc.GetElementsByTagName("infNFe");
            if (lNo.Count > 0)
                retorno.Chave_acesso_nfe = lNo[0].Attributes.GetNamedItem("Id").InnerText.Remove(0, 3);
            else
                throw new Exception("XML Invalido.");
            #region Identificacao NFe
            lNo = doc.GetElementsByTagName("ide");
            //Identificacao da NFe
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("mod"))
                        retorno.Cd_modelo = no.InnerText;
                    else if (no.LocalName.Equals("serie"))
                        retorno.Nr_serie = no.InnerText;
                    else if (no.LocalName.Equals("nNF"))
                        retorno.Nr_notafiscal = decimal.Parse(no.InnerText);
                    else if (no.LocalName.Equals("dEmi"))
                    {
                        retorno.Dt_emissao = DateTime.Parse(no.InnerText);
                        retorno.Dt_saient = retorno.Dt_emissao;
                    }
                    else if (no.LocalName.Equals("dhEmi"))
                    {
                        retorno.Dt_emissao = DateTime.Parse(no.InnerText);
                        retorno.Dt_saient = retorno.Dt_emissao;
                    }
                    else if (no.LocalName.Equals("finNFe"))
                    {
                        if (no.InnerText != "1")
                            throw new Exception("Permitido importar somente XML de NFe NORMAL.");
                    }
                }
            }
            #endregion
            #region Emitente
            retorno.NR_CGC_Empresa = doc.GetElementsByTagName("emit")[0].FirstChild.InnerText.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            CamadaDados.Diversos.TList_CadEmpresa lEmp =
            new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "b.nr_cgc",
                                vOperador = "=",
                                vVL_Busca = "'" + retorno.NR_CGC_Empresa.Trim() + "'"
                            }
                        }, 1, string.Empty);
            if (lEmp.Count > 0)
            {
                retorno.Cd_empresa = lEmp[0].Cd_empresa;
                retorno.Nm_empresa = lEmp[0].Nm_empresa;
                retorno.Cd_uf_empresa = lEmp[0].rEndereco.Cd_uf;
                //Verificar se chave de acesso existe no banco
                if (new TCD_LanFaturamento().BuscarEscalar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lEmp[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.Chave_Acesso_NFE",
                                vOperador = "=",
                                vVL_Busca = "'" + retorno.Chave_acesso_nfe.Trim() + "'"
                            }
                    }, "1") != null)
                    throw new Exception("Chave de acesso " + retorno.Chave_acesso_nfe.Trim() + " ja se encontra cadastrada no sistema.");
            }
            else
                throw new Exception("Não foi encontrado empresa cadastrada no sistema com CNPJ " + retorno.NR_CGC_Empresa.Trim());

            #endregion
            #region Cliente
            lNo = doc.GetElementsByTagName("dest");
            string cnpj = string.Empty;
            string cpf = string.Empty;
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("CNPJ"))
                        cnpj = no.InnerText;
                    else if (no.LocalName.Equals("CPF"))
                        cpf = no.InnerText;
                }
                if (!string.IsNullOrWhiteSpace(cnpj))
                    cnpj = cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                else if (string.IsNullOrWhiteSpace(cpf))
                    cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                //Buscar Cliente
                TList_CadClifor lCliente = TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.IsNullOrEmpty(cnpj.SoNumero()) ? string.Empty : cnpj,
                                                                      string.IsNullOrEmpty(cpf.SoNumero()) ? string.Empty : cpf,
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
                if (lCliente.Count > 0)
                {
                    retorno.Cd_clifor = lCliente[0].Cd_clifor;
                    retorno.Cd_condfiscal_clifor = lCliente[0].Cd_condfiscal_clifor;
                    retorno.Nm_clifor = lCliente[0].Nm_clifor;
                    //Endereco do cliente
                    retorno.Cd_endereco = new TCD_CadEndereco().BuscarEscalar(
                                            new TpBusca[] 
                                            {
                                                new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + retorno.Cd_clifor.Trim() + "'" },
                                                new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                            }, "a.cd_endereco").ToString();
                }
                else throw new Exception("Não existe cliente cadastrado no sistema para o " + (string.IsNullOrWhiteSpace(cnpj) ? "CPF: " + cpf.Trim() : "CNPJ: " + cnpj.Trim()) + ".");
            }
            #endregion
            #region Itens da NFe
            //Buscar lista impostos
            TList_CadImposto lImpostos = TCN_CadImposto.Busca(string.Empty, string.Empty, null);
            lNo = doc.GetElementsByTagName("det");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo)
                {
                    TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                    foreach (XmlNode noF in no.ChildNodes)
                    {
                        if (noF.LocalName.Equals("prod"))
                        {
                            string CdProduto = string.Empty;
                            foreach (XmlNode noP in noF.ChildNodes)
                            {
                                if (noP.LocalName.Equals("cProd"))
                                    CdProduto = noP.InnerText;
                                else if (noP.LocalName.Equals("qCom"))
                                    rItem.Quantidade = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vUnCom"))
                                    rItem.Vl_unitario = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vProd"))
                                    rItem.Vl_subtotal = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vFrete"))
                                    rItem.Vl_freteitem = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vSeg"))
                                    rItem.Vl_seguro = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vDesc"))
                                    rItem.Vl_desconto = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                else if (noP.LocalName.Equals("vOutro"))
                                    rItem.Vl_outrasdesp = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                            }
                            //Buscar Produto
                            TList_CadProduto lProd = new TCD_CadProduto().Select(
                                new TpBusca[]
                                {
                                    new TpBusca { vNM_Campo = "a.Cd_Integracao", vOperador = "=", vVL_Busca = "'" + CdProduto.Trim() + "'" }
                                }, 1, string.Empty, string.Empty, string.Empty);
                            if (lProd.Count > 0)
                            {
                                rItem.Cd_produto = lProd.FirstOrDefault().CD_Produto;
                                rItem.Ds_produto = lProd.FirstOrDefault().DS_Produto;
                                rItem.Cd_condfiscal_produto = lProd.FirstOrDefault().CD_CondFiscal_Produto;
                                rItem.Cd_unidade = lProd.FirstOrDefault().CD_Unidade;
                                rItem.Cd_unidEst = lProd.FirstOrDefault().CD_Unidade;
                            }
                            else throw new Exception("Não existe produto cadastrado no sistema.");
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
                                            throw new Exception("Não existe imposto ICMS cadastrado no sistema Aliance.NET.");
                                        switch (noI.LastChild.LocalName)
                                        {
                                            case "ICMS00":
                                                {
                                                    TRegistro_ImpostosNF rICMS00 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS00);
                                                    break;
                                                }
                                            case "ICMS10":
                                                {
                                                    TRegistro_ImpostosNF rICMS10 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS10);
                                                    break;
                                                }
                                            case "ICMS20":
                                                {
                                                    TRegistro_ImpostosNF rICMS20 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS20);
                                                    break;
                                                }
                                            case "ICMS30":
                                                {
                                                    TRegistro_ImpostosNF rICMS30 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS30);
                                                    break;
                                                }
                                            case "ICMS40":
                                                {
                                                    TRegistro_ImpostosNF rICMS40 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS40);
                                                    break;
                                                }
                                            case "ICMS51":
                                                {
                                                    TRegistro_ImpostosNF rICMS51 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS51);
                                                    break;
                                                }
                                            case "ICMS60":
                                                {
                                                    TRegistro_ImpostosNF rICMS60 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS60);
                                                    break;
                                                }
                                            case "ICMS70":
                                                {
                                                    TRegistro_ImpostosNF rICMS70 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS70);
                                                    break;
                                                }
                                            case "ICMS90":
                                                {
                                                    TRegistro_ImpostosNF rICMS90 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS90);
                                                    break;
                                                }
                                            case "ICMSSN101":
                                                {
                                                    TRegistro_ImpostosNF rICMS101 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS101);
                                                    break;
                                                }
                                            case "ICMSSN102":
                                                {
                                                    TRegistro_ImpostosNF rICMS102 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS102);
                                                    break;
                                                }
                                            case "ICMSSN201":
                                                {
                                                    TRegistro_ImpostosNF rICMS201 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS201);
                                                    break;
                                                }
                                            case "ICMSSN202":
                                                {
                                                    TRegistro_ImpostosNF rICMS202 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS202);
                                                    break;
                                                }
                                            case "ICMSSN500":
                                                {
                                                    TRegistro_ImpostosNF rICMS500 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS500);
                                                    break;
                                                }
                                            case "ICMSSN900":
                                                {
                                                    TRegistro_ImpostosNF rICMS900 = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rICMS900);
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
                                            throw new Exception("Não existe imposto IPI cadastrado no sistema Aliance.NET");
                                        foreach (XmlNode noIPI in noI.ChildNodes)
                                        {
                                            if (noIPI.LocalName.Equals("IPITrib"))
                                            {
                                                TRegistro_ImpostosNF rIPI = new TRegistro_ImpostosNF();
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
                                                //rItem.ImpostosItens.Add(rIPI);
                                            }
                                        }
                                    }
                                }
                                else if (noI.LocalName.Equals("PIS"))
                                {
                                    if (noI.ChildNodes.Count > 0)
                                    {
                                        if (!lImpostos.Exists(p => p.St_PIS))
                                            throw new Exception("Não existe imposto PIS cadastrado no sistema Aliance.NET");
                                        switch (noI.LastChild.LocalName)
                                        {
                                            case "PISAliq":
                                                {
                                                    TRegistro_ImpostosNF rPISAliq = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rPISAliq);
                                                    break;
                                                }
                                            case "PISQtde":
                                                {
                                                    TRegistro_ImpostosNF rPISQtd = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rPISQtd);
                                                    break;
                                                }
                                            case "PISNT":
                                                {
                                                    TRegistro_ImpostosNF rPISNT = new TRegistro_ImpostosNF();
                                                    rPISNT.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).Cd_imposto;
                                                    rPISNT.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_PIS).ds_imposto;
                                                    rPISNT.Imposto = lImpostos.FirstOrDefault(p => p.St_PIS);
                                                    foreach (XmlNode PISNT in noI.LastChild.ChildNodes)
                                                    {
                                                        if (PISNT.LocalName.Equals("CST"))
                                                            rPISNT.Cd_st_xml = PISNT.InnerText;
                                                    }
                                                    //rItem.ImpostosItens.Add(rPISNT);
                                                    break;
                                                }
                                            case "PISOutr":
                                                {
                                                    TRegistro_ImpostosNF rPISOut = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rPISOut);
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
                                            throw new Exception("Não existe imposto COFINS cadastrado no sistema Aliance.NET");
                                        switch (noI.LastChild.LocalName)
                                        {
                                            case "COFINSAliq":
                                                {
                                                    TRegistro_ImpostosNF rCOFINSAliq = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rCOFINSAliq);
                                                    break;
                                                }
                                            case "COFINSQtde":
                                                {
                                                    TRegistro_ImpostosNF rCOFINSQtd = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rCOFINSQtd);
                                                    break;
                                                }
                                            case "COFINSNT":
                                                {
                                                    TRegistro_ImpostosNF rCOFINSNT = new TRegistro_ImpostosNF();
                                                    rCOFINSNT.Cd_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).Cd_imposto;
                                                    rCOFINSNT.Ds_imposto = lImpostos.FirstOrDefault(p => p.St_Cofins).ds_imposto;
                                                    rCOFINSNT.Imposto = lImpostos.FirstOrDefault(p => p.St_Cofins);
                                                    foreach (XmlNode COFINSNT in noI.LastChild.ChildNodes)
                                                    {
                                                        if (COFINSNT.LocalName.Equals("CST"))
                                                            rCOFINSNT.Cd_st_xml = COFINSNT.InnerText;
                                                    }
                                                    //rItem.ImpostosItens.Add(rCOFINSNT);
                                                    break;
                                                }
                                            case "COFINSOutr":
                                                {
                                                    TRegistro_ImpostosNF rCOFINSOut = new TRegistro_ImpostosNF();
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
                                                    //rItem.ImpostosItens.Add(rCOFINSOut);
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    retorno.ItensNota.Add(rItem);
                }
            }
            #endregion
            #region Frete
            lNo = doc.GetElementsByTagName("transp");
            if (lNo.Count > 0)
                if (lNo[0].FirstChild.LocalName.Equals("modFrete"))
                    retorno.Freteporconta = lNo[0].FirstChild.InnerText;
            #endregion
            return retorno;
        }

        private void TFIntegraVendasExterna_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltroCliente.set_FormatZero();
            pFiltroProd.set_FormatZero();
            //Buscar Config
            cbEmpresa.DataSource = TCN_CFGVendasExterna.Buscar(string.Empty, null);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void bbConfig_Click(object sender, EventArgs e)
        {
            using (TFConfigVendasExterna fConfig = new TFConfigVendasExterna())
            {
                if (cbEmpresa.SelectedItem != null)
                    fConfig.rCfg = cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna;
                if(fConfig.ShowDialog() == DialogResult.OK)
                    if(fConfig.rCfg != null)
                        try
                        {
                            TCN_CFGVendasExterna.Gravar(fConfig.rCfg, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbEmpresa.DataSource = TCN_CFGVendasExterna.Buscar(string.Empty, null);
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void BB_CategoriaClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CategoriaClifor|Categoria Clifor|200;a.ID_CategoriaClifor|Cód. Categoria Clifor|100",
                new Componentes.EditDefault[] { ID_CategoriaClifor, ds_categoriaclifor },
                new TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void ID_CategoriaClifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + ID_CategoriaClifor.Text + "'",
              new Componentes.EditDefault[] { ID_CategoriaClifor, ds_categoriaclifor },
              new TCD_CadCategoriaCliFor());
        }

        private void bb_rota_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_rota|Rota|200;a.id_rota|Código|100",
                new Componentes.EditDefault[] { id_rota, ds_rota },
                new CamadaDados.Diversos.TCD_CadRota(), string.Empty);
        }

        private void id_rota_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_rota|=|'" + id_rota.Text + "'",
              new Componentes.EditDefault[] { id_rota, ds_rota },
              new CamadaDados.Diversos.TCD_CadRota());
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                Estruturas.CriarParametro(ref filtro, "a.cd_clifor", "'" + CD_Clifor.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(NM_Clifor.Text))
                Estruturas.CriarParametro(ref filtro, "a.nm_clifor", "'%" + NM_Clifor.Text.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(NR_CGC.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "dbo.FVALIDA_NUMEROS(a.nr_cgc)", "'" + NR_CGC.Text.SoNumero() + "'");
            if (!string.IsNullOrEmpty(NR_CPF.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "dbo.FVALIDA_NUMEROS(a.nr_cpf)", "'" + NR_CPF.Text.SoNumero() + "'");
            if (!string.IsNullOrEmpty(ID_CategoriaClifor.Text))
                Estruturas.CriarParametro(ref filtro, "a.id_categoriaclifor", ID_CategoriaClifor.Text);
            if (!string.IsNullOrEmpty(id_rota.Text))
                Estruturas.CriarParametro(ref filtro, "a.id_rota", id_rota.Text);
            bsClifor.DataSource = new TCD_CadClifor().Select(filtro, 0, string.Empty);
            bsClifor_PositionChanged(this, new EventArgs());
        }

        private void bsClifor_PositionChanged(object sender, EventArgs e)
        {
            if(bsClifor.Current != null)
            {
                (bsClifor.Current as TRegistro_CadClifor).lEndereco =
                    new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor.Trim() + "'"
                            }
                        }, 0, string.Empty);
                bsClifor.ResetCurrentItem();
            }
        }

        private void bbNovoCliente_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                if(MessageBox.Show("Cliente cadastrado com sucesso no Aliance.NET\r\n" +
                                                   "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                                    try
                                    {
                                        if (ValidarToken())
                                        {
                                            Clientes cliente = new Clientes();
                                            cliente.NOME = fClifor.rClifor.Nm_clifor.Trim();
                                            cliente.TIPO_PESSOA = fClifor.rClifor.Tp_pessoa;
                                            cliente.SITUACAO = "A";
                                            cliente.DOCUMENTO = fClifor.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? fClifor.rClifor.Nr_cpf : fClifor.rClifor.Nr_cgc;
                                            cliente.EXCLUIDO = "N";
                                            if (fClifor.rClifor.lContato.Count > 0)
                                                cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.lContato[0].Nm_Contato.Trim() };
                                            else cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.Nm_clifor.Trim() };
                                            fClifor.rClifor.lEndereco.ForEach(v =>
                                            cliente.ENDERECOS.Add(new Endereco
                                            {
                                                TIPO = "C",
                                                PRINCIPAL = "S",
                                                CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                                ENDERECO = v.Ds_endereco.Trim(),
                                                NUMERO = v.Numero.Trim(),
                                                COMPLEMENTO = v.Ds_complemento.Trim(),
                                                BAIRRO = v.Bairro.Trim(),
                                                PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                                ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                                CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                                            }
                                            ));
                                            Retorno ret = ServiceRest.DataService.CadastrarCliente(cliente, _token);
                                            if (ret != null)
                                                if (ret.REFERENCIAS != null)
                                                {
                                                    fClifor.rClifor.Cd_integracao = ret.REFERENCIAS.CODIGO;
                                                    new CamadaDados.TDataQuery().executarSql("update TB_FIN_clifor set cd_integracao = '" + fClifor.rClifor.Cd_integracao + "', dt_alt = GETDATE() " +
                                                                                             "WHERE cd_clifor = '" + fClifor.rClifor.Cd_clifor.Trim() + "' ", null);
                                                }
                                        }
                                        else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch(Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                bbBuscar_Click(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (TFClifor fClifor = new TFClifor())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                if (MessageBox.Show("Cliente cadastrado com sucesso no Aliance.NET\r\n" +
                                                    "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                                    try
                                    {
                                        if (ValidarToken())
                                        {
                                            Clientes cliente = new Clientes();
                                            cliente.NOME = fClifor.rClifor.Nm_clifor.Trim();
                                            cliente.TIPO_PESSOA = fClifor.rClifor.Tp_pessoa;
                                            cliente.SITUACAO = "A";
                                            cliente.DOCUMENTO = fClifor.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? fClifor.rClifor.Nr_cpf : fClifor.rClifor.Nr_cgc;
                                            cliente.EXCLUIDO = "N";
                                            if (fClifor.rClifor.lContato.Count > 0)
                                                cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.lContato[0].Nm_Contato.Trim() };
                                            else cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.Nm_clifor.Trim() };
                                            fClifor.rClifor.lEndereco.ForEach(v =>
                                            cliente.ENDERECOS.Add(new Endereco
                                            {
                                                TIPO = "C",
                                                PRINCIPAL = "S",
                                                CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                                ENDERECO = v.Ds_endereco.Trim(),
                                                NUMERO = v.Numero.Trim(),
                                                COMPLEMENTO = v.Ds_complemento.Trim(),
                                                BAIRRO = v.Bairro.Trim(),
                                                PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                                ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                                CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                                            }
                                            ));
                                            Retorno ret = ServiceRest.DataService.CadastrarCliente(cliente, _token);
                                            if (ret != null)
                                                if (ret.REFERENCIAS != null)
                                                {
                                                    fClifor.rClifor.Cd_integracao = ret.REFERENCIAS.CODIGO;
                                                    new CamadaDados.TDataQuery().executarSql("update TB_FIN_clifor set cd_integracao = '" + fClifor.rClifor.Cd_integracao + "', dt_alt = GETDATE() " +
                                                                                             "WHERE cd_clifor = '" + fClifor.rClifor.Cd_clifor.Trim() + "' ", null);
                                                }
                                        }
                                        else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                bbBuscar_Click(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bbIntegrarCliente_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                try
                {
                    if (ValidarToken())
                    {
                        //Novo cliente
                        if (string.IsNullOrEmpty((bsClifor.Current as TRegistro_CadClifor).Cd_integracao))
                        {
                            Clientes cliente = new Clientes();
                            cliente.NOME = (bsClifor.Current as TRegistro_CadClifor).Nm_clifor.Trim();
                            cliente.TIPO_PESSOA = (bsClifor.Current as TRegistro_CadClifor).Tp_pessoa;
                            cliente.SITUACAO = "A";
                            cliente.DOCUMENTO = (bsClifor.Current as TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("F") ?
                                                (bsClifor.Current as TRegistro_CadClifor).Nr_cpf : (bsClifor.Current as TRegistro_CadClifor).Nr_cgc;
                            cliente.EXCLUIDO = "N";
                            if ((bsClifor.Current as TRegistro_CadClifor).lContato.Count > 0)
                                cliente.RESPONSAVEL = new Responsavel { NOME = (bsClifor.Current as TRegistro_CadClifor).lContato[0].Nm_Contato.Trim() };
                            else cliente.RESPONSAVEL = new Responsavel { NOME = (bsClifor.Current as TRegistro_CadClifor).Nm_clifor.Trim() };
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco.ForEach(v =>
                            cliente.ENDERECOS.Add(new Endereco
                            {
                                TIPO = "C",
                                PRINCIPAL = "S",
                                CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                ENDERECO = v.Ds_endereco.Trim(),
                                NUMERO = v.Numero.Trim(),
                                COMPLEMENTO = v.Ds_complemento.Trim(),
                                BAIRRO = v.Bairro.Trim(),
                                PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                            }
                            ));
                            Retorno ret = ServiceRest.DataService.CadastrarCliente(cliente, _token);
                            if (ret != null)
                                if (ret.REFERENCIAS != null)
                                {
                                    (bsClifor.Current as TRegistro_CadClifor).Cd_integracao = ret.REFERENCIAS.CODIGO;
                                    new CamadaDados.TDataQuery().executarSql("update TB_FIN_clifor set cd_integracao = '" + (bsClifor.Current as TRegistro_CadClifor).Cd_integracao + "', dt_alt = GETDATE() " +
                                                                             "WHERE cd_clifor = '" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor.Trim() + "' ", null);
                                }
                        }
                        else if((bsClifor.Current as TRegistro_CadClifor).St_registro.Trim().ToUpper().Equals("C"))
                        {
                            //Cancelar cliente no site
                            ServiceRest.DataService.InativarCliente((bsClifor.Current as TRegistro_CadClifor).Cd_integracao, _token);
                            MessageBox.Show("Cliente CANCELADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //alterar cliente no site
                            Clientes cliente = new Clientes();
                            cliente.NOME = (bsClifor.Current as TRegistro_CadClifor).Nm_clifor.Trim();
                            cliente.TIPO_PESSOA = (bsClifor.Current as TRegistro_CadClifor).Tp_pessoa;
                            cliente.SITUACAO = "A";
                            cliente.DOCUMENTO = (bsClifor.Current as TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("F") ? (bsClifor.Current as TRegistro_CadClifor).Nr_cpf : (bsClifor.Current as TRegistro_CadClifor).Nr_cgc;
                            cliente.EXCLUIDO = "N";
                            if ((bsClifor.Current as TRegistro_CadClifor).lContato.Count > 0)
                                cliente.RESPONSAVEL = new Responsavel { NOME = (bsClifor.Current as TRegistro_CadClifor).lContato[0].Nm_Contato.Trim() };
                            else cliente.RESPONSAVEL = new Responsavel { NOME = (bsClifor.Current as TRegistro_CadClifor).Nm_clifor.Trim() };
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco.ForEach(v =>
                            cliente.ENDERECOS.Add(new Endereco
                            {
                                TIPO = "C",
                                PRINCIPAL = "S",
                                CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                ENDERECO = v.Ds_endereco.Trim(),
                                NUMERO = v.Numero.Trim(),
                                COMPLEMENTO = v.Ds_complemento.Trim(),
                                BAIRRO = v.Bairro.Trim(),
                                PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                            }
                            ));
                            Retorno ret = ServiceRest.DataService.AlterarCliente((bsClifor.Current as TRegistro_CadClifor).Cd_integracao, cliente, _token);
                            MessageBox.Show("Cliente alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show("Não existe cliente disponivel para integrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbAltCliente_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                    using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
                    {
                        fClifor.rClifor = bsClifor.Current as TRegistro_CadClifor;
                        if (fClifor.ShowDialog() == DialogResult.OK)
                            if (fClifor.rClifor != null)
                                try
                                {
                                    TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                    if (MessageBox.Show("Cliente cadastrado com sucesso no Aliance.NET\r\n" +
                                                       "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                        == DialogResult.Yes)
                                        try
                                        {
                                            if (ValidarToken())
                                            {
                                                Clientes cliente = new Clientes();
                                                cliente.NOME = fClifor.rClifor.Nm_clifor.Trim();
                                                cliente.TIPO_PESSOA = fClifor.rClifor.Tp_pessoa;
                                                cliente.SITUACAO = "A";
                                                cliente.DOCUMENTO = fClifor.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? fClifor.rClifor.Nr_cpf : fClifor.rClifor.Nr_cgc;
                                                cliente.EXCLUIDO = "N";
                                                if (fClifor.rClifor.lContato.Count > 0)
                                                    cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.lContato[0].Nm_Contato.Trim() };
                                                else cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.Nm_clifor.Trim() };
                                                fClifor.rClifor.lEndereco.ForEach(v =>
                                                cliente.ENDERECOS.Add(new Endereco
                                                {
                                                    TIPO = "C",
                                                    PRINCIPAL = "S",
                                                    CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                                    ENDERECO = v.Ds_endereco.Trim(),
                                                    NUMERO = v.Numero.Trim(),
                                                    COMPLEMENTO = v.Ds_complemento.Trim(),
                                                    BAIRRO = v.Bairro.Trim(),
                                                    PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                                    ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                                    CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                                                }
                                                ));
                                                Retorno ret = ServiceRest.DataService.AlterarCliente(fClifor.rClifor.Cd_integracao, cliente, _token);
                                            }
                                            else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                    bbBuscar_Click(this, new EventArgs());
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    using (TFClifor fClifor = new TFClifor())
                    {
                        fClifor.rClifor = bsClifor.Current as TRegistro_CadClifor;
                        if (fClifor.ShowDialog() == DialogResult.OK)
                            if (fClifor.rClifor != null)
                                try
                                {
                                    TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                    if (MessageBox.Show("Cliente cadastrado com sucesso no Aliance.NET\r\n" +
                                                        "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                        == DialogResult.Yes)
                                        try
                                        {
                                            if (ValidarToken())
                                            {
                                                Clientes cliente = new Clientes();
                                                cliente.NOME = fClifor.rClifor.Nm_clifor.Trim();
                                                cliente.TIPO_PESSOA = fClifor.rClifor.Tp_pessoa;
                                                cliente.SITUACAO = "A";
                                                cliente.DOCUMENTO = fClifor.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? fClifor.rClifor.Nr_cpf : fClifor.rClifor.Nr_cgc;
                                                cliente.EXCLUIDO = "N";
                                                if (fClifor.rClifor.lContato.Count > 0)
                                                    cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.lContato[0].Nm_Contato.Trim() };
                                                else cliente.RESPONSAVEL = new Responsavel { NOME = fClifor.rClifor.Nm_clifor.Trim() };
                                                fClifor.rClifor.lEndereco.ForEach(v =>
                                                cliente.ENDERECOS.Add(new Endereco
                                                {
                                                    TIPO = "C",
                                                    PRINCIPAL = "S",
                                                    CEP = v.Cep.Replace('.', ' ').Replace(',', ' '),
                                                    ENDERECO = v.Ds_endereco.Trim(),
                                                    NUMERO = v.Numero.Trim(),
                                                    COMPLEMENTO = v.Ds_complemento.Trim(),
                                                    BAIRRO = v.Bairro.Trim(),
                                                    PAIS = new Pais { NOME = v.NM_Pais.Trim() },
                                                    ESTADO = new Estado { SIGLA = v.UF.Trim() },
                                                    CIDADE = new Cidade { NOME = v.DS_Cidade.Trim(), CODIGO_IBGE = v.Cd_cidade }
                                                }
                                                ));
                                                Retorno ret = ServiceRest.DataService.AlterarCliente(fClifor.rClifor.Cd_integracao, cliente, _token);
                                            }
                                            else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                    bbBuscar_Click(this, new EventArgs());
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
        }

        private void bbExluirCliente_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (MessageBox.Show("Confirma a exclusão do cliente selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        if (ValidarToken())
                        {
                            //Cancelar cliente no sistema
                            new CamadaDados.TDataQuery().executarSql("update TB_FIN_Clifor set ST_Registro = 'C', DT_Alt = GETDATE() " +
                                         "where cd_clifor = '" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor.Trim() + "' ", null);
                            if (!string.IsNullOrEmpty((bsClifor.Current as TRegistro_CadClifor).Cd_integracao))
                                ServiceRest.DataService.InativarCliente((bsClifor.Current as TRegistro_CadClifor).Cd_integracao, _token);
                            MessageBox.Show("Cliente CANCELADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bbBuscar_Click(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Grupo },
                                    new TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Grupo },
                                    new TCD_CadGrupoProduto());
        }

        private void bbBuscarProd_Click(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            //Buscar tabela de preco
            object obj = new CamadaDados.Diversos.TCD_CfgEmpresa().BuscarEscalar(
                new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'" } }, "a.cd_tabelapreco");
            if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
            {
                MessageBox.Show("Não existe tabela preço configurada para empresa selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_produto.Text))
                Estruturas.CriarParametro(ref filtro, "a.cd_produto", "'" + cd_produto.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(ds_produto.Text))
                Estruturas.CriarParametro(ref filtro, "a.ds_produto", "'%" + ds_produto.Text.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(CD_Grupo.Text))
                Estruturas.CriarParametro(ref filtro, "a.cd_grupo", "'" + CD_Grupo.Text.Trim() + "'");
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@CD_EMPRESA", cbEmpresa.SelectedValue.ToString());
            hs.Add("@CD_TABELAPRECO", obj.ToString());
            bsProduto.DataSource = new TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty, hs);
            if (!tcProduto.SelectedTab.Equals(tpProd))
                tcProduto.SelectedTab = tpProd;
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void bbAddProduto_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFProdutoResumido fProd = new Proc_Commoditties.TFProdutoResumido())
            {
                if(fProd.ShowDialog() == DialogResult.OK)
                    if(fProd.Produto != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.Produto, null);
                            if (MessageBox.Show("Produto cadastrado com sucesso no Aliance.NET\r\n" +
                                                    "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                                try
                                {
                                    cd_produto.Text = fProd.Produto.CD_Produto;
                                    bbBuscarProd_Click(this, new EventArgs());
                                    if (ValidarToken())
                                    {
                                        Produtos produto = new Produtos();
                                        //Buscar codigo barras
                                        object obj = new TCD_CodBarra().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "'" } }, "a.cd_codbarra");
                                        if (obj != null)
                                            produto.CODIGO_BARRAS = obj.ToString();
                                        produto.NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                                        produto.FABRICACAO_PROPRIA = "N";
                                        produto.DISPONIBILIDADE = "D";
                                        produto.ORIGEM = "0";
                                        produto.NCM = (bsProduto.Current as TRegistro_CadProduto).Ncm.SoNumero();
                                        produto.CEST = (bsProduto.Current as TRegistro_CadProduto).Cest;
                                        produto.CATEGORIA = new Categoria { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Grupo.Trim() };
                                        produto.FABRICANTE = new Fabricante { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Marca.Trim() };
                                        produto.UNIDADE_MEDIDA_VENDA = new Unidade { SIGLA = (bsProduto.Current as TRegistro_CadProduto).Sigla_unidade.Trim().ToUpper() };
                                        (bsSaldoEst.List as List<TRegistro_SaldoEstoque>).ForEach(p =>
                                        produto.ESTOQUES.Add(new Estoque
                                        {
                                            UNIDADE = "1",
                                            LOCALIZACAO = "0",
                                            QUANTIDADE_MINIMA = 0,
                                            QUANTIDADE_ATUAL = p.Tot_saldo,
                                            QUANTIDADE_RESERVA = 0,
                                        }));
                                        if ((bsProduto.Current as TRegistro_CadProduto).Vl_precovenda > decimal.Zero)
                                            produto.PRECOS = new List<Preco>
                                {
                                    new Preco
                                    {
                                        UNIDADE = "0",
                                        MARGEM_CUSTO_REAL = 0,
                                        PRECO_CUSTO = 0,
                                        PRECO_CUSTO_ANTERIOR = 0,
                                        PRECO_CUSTO_REAL = 0,
                                        PRECO_MEDIO = 0,
                                        PRECO_VENDA = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda,
                                        PRECO_VENDA_ANTERIOR = 0,
                                        DESCONTO_MAXIMO = 0,
                                    }
                                };
                                        produto.TRIBUTARIOS = new Tributarios
                                        {
                                            UNIDADE = "0",
                                            ICMS_SIMPLES_NACIONAL = "N",
                                            IPI_CST_ENTRADA = null,
                                            IPI_CST_SAIDA = null,
                                            IPI_ALIQUOTA = decimal.Zero,
                                            IPI_VALOR_UNIDADE = decimal.Zero,
                                            IPI_CLASSE_ENQUADRAMENTO = null,
                                            PIS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).Cd_st,
                                            PIS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).pc_aliquota,
                                            PIS_NATUREZA_RECEITA = null,
                                            COFINS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).Cd_st,
                                            COFINS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).pc_aliquota,
                                            COFINS_NATUREZA_RECEITA = null,
                                            CONTRIBUICAO_SOCIAL_APURADA = null,
                                            TOTAL_TRIBUTOS_TIPO = "P",
                                            TOTAL_TRIBUTOS_VALOR = null,
                                            TOTAL_TRIBUTOS_PERCENTUAL = decimal.Zero
                                        };
                                        (bsCondFiscalIMCS.List as TList_CadCondFiscalICMS).ForEach(p =>
                                        produto.TRIBUTARIOS_ICMS.Add(new Tributario_ICMS
                                        {
                                            UNIDADE = "1",
                                            CST = p.Cd_st.Trim().Length > 2 ? "41" : p.Cd_st.Trim(),
                                            ALIQUOTA_ORIGEM = p.Pc_aliquota_icms,
                                            ALIQUOTA_DESTINO = p.Pc_aliquota_icmsDest,
                                            MVA = p.Vl_mva,
                                            MVA_AJUSTAR = "N",
                                            ALIQUOTA_REDUCAO = p.Pc_reducaoaliquota,
                                            ALIQUOTA_REDUCAO_ST = p.Pc_reducaobasecalc_substtrib,
                                            INTERESTADUAL_ALIQUOTA_FCP = p.PC_FCP,
                                            INTERESTADUAL_ALIQUOTA_DESTINO = decimal.Zero,
                                            ESTADO = new Estado { SIGLA = p.Sg_ufdest }
                                        }));
                                        Retorno ret = ServiceRest.DataService.NovoProduto(produto, _token);
                                        if (ret != null)
                                            if (ret.REFERENCIAS != null)
                                            {
                                                (bsProduto.Current as TRegistro_CadProduto).Cd_integracao = ret.REFERENCIAS.CODIGO;
                                                new CamadaDados.TDataQuery().executarSql("update TB_EST_Produto set cd_integracao = '" + (bsProduto.Current as TRegistro_CadProduto).Cd_integracao + "', dt_alt = GETDATE() " +
                                                                                         "WHERE cd_produto = '" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "' ", null);
                                            }
                                    }
                                    else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch(Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            cd_produto.Text = fProd.Produto.CD_Produto;
                            bbBuscar_Click(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAltProduto_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                using (Proc_Commoditties.TFProdutoResumido fProd = new Proc_Commoditties.TFProdutoResumido())
                {
                    fProd.Produto = bsProduto.Current as TRegistro_CadProduto;
                    if (fProd.ShowDialog() == DialogResult.OK)
                        if (fProd.Produto != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.Produto, null);
                                if (MessageBox.Show("Produto alterado com sucesso no Aliance.NET\r\n" +
                                                        "Deseja enviar cadastro para o Vendas Externa?", "Pergunta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                        == DialogResult.Yes)
                                    try
                                    {
                                        cd_produto.Text = fProd.Produto.CD_Produto;
                                        bbBuscarProd_Click(this, new EventArgs());
                                        if (ValidarToken())
                                        {
                                            Produtos produto = new Produtos();
                                            //Buscar codigo barras
                                            object obj = new TCD_CodBarra().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "'" } }, "a.cd_codbarra");
                                            if (obj != null)
                                                produto.CODIGO_BARRAS = obj.ToString();
                                            produto.NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                                            produto.FABRICACAO_PROPRIA = "N";
                                            produto.DISPONIBILIDADE = "D";
                                            produto.ORIGEM = "0";
                                            produto.NCM = (bsProduto.Current as TRegistro_CadProduto).Ncm.SoNumero();
                                            produto.CEST = (bsProduto.Current as TRegistro_CadProduto).Cest;
                                            produto.CATEGORIA = new Categoria { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Grupo.Trim() };
                                            produto.FABRICANTE = new Fabricante { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Marca.Trim() };
                                            produto.UNIDADE_MEDIDA_VENDA = new Unidade { SIGLA = (bsProduto.Current as TRegistro_CadProduto).Sigla_unidade.Trim().ToUpper() };
                                            if ((bsProduto.Current as TRegistro_CadProduto).Vl_precovenda > decimal.Zero)
                                                produto.PRECOS = new List<Preco>
                                                {
                                                    new Preco
                                                    {
                                                        UNIDADE = "0",
                                                        MARGEM_CUSTO_REAL = 0,
                                                        PRECO_CUSTO = 0,
                                                        PRECO_CUSTO_ANTERIOR = 0,
                                                        PRECO_CUSTO_REAL = 0,
                                                        PRECO_MEDIO = 0,
                                                        PRECO_VENDA = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda,
                                                        PRECO_VENDA_ANTERIOR = 0,
                                                        DESCONTO_MAXIMO = 0,
                                                    }
                                                };
                                            produto.TRIBUTARIOS = new Tributarios
                                            {
                                                UNIDADE = "0",
                                                ICMS_SIMPLES_NACIONAL = "N",
                                                IPI_CST_ENTRADA = null,
                                                IPI_CST_SAIDA = null,
                                                IPI_ALIQUOTA = decimal.Zero,
                                                IPI_VALOR_UNIDADE = decimal.Zero,
                                                IPI_CLASSE_ENQUADRAMENTO = null,
                                                PIS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).Cd_st,
                                                PIS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).pc_aliquota,
                                                PIS_NATUREZA_RECEITA = null,
                                                COFINS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).Cd_st,
                                                COFINS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).pc_aliquota,
                                                COFINS_NATUREZA_RECEITA = null,
                                                CONTRIBUICAO_SOCIAL_APURADA = null,
                                                TOTAL_TRIBUTOS_TIPO = "P",
                                                TOTAL_TRIBUTOS_VALOR = null,
                                                TOTAL_TRIBUTOS_PERCENTUAL = decimal.Zero
                                            };
                                            (bsCondFiscalIMCS.List as TList_CadCondFiscalICMS).ForEach(p =>
                                            produto.TRIBUTARIOS_ICMS.Add(new Tributario_ICMS
                                            {
                                                UNIDADE = "1",
                                                CST = p.Cd_st.Trim().Length > 2 ? "41" : p.Cd_st.Trim(),
                                                ALIQUOTA_ORIGEM = p.Pc_aliquota_icms,
                                                ALIQUOTA_DESTINO = p.Pc_aliquota_icmsDest,
                                                MVA = p.Vl_mva,
                                                MVA_AJUSTAR = "N",
                                                ALIQUOTA_REDUCAO = p.Pc_reducaoaliquota,
                                                ALIQUOTA_REDUCAO_ST = p.Pc_reducaobasecalc_substtrib,
                                                INTERESTADUAL_ALIQUOTA_FCP = p.PC_FCP,
                                                INTERESTADUAL_ALIQUOTA_DESTINO = decimal.Zero,
                                                ESTADO = new Estado { SIGLA = p.Sg_ufdest }
                                            }));
                                            Retorno ret = ServiceRest.DataService.AlterarProduto((bsProduto.Current as TRegistro_CadProduto).Cd_integracao, produto, _token);
                                        }
                                        else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                cd_produto.Text = fProd.Produto.CD_Produto;
                                bbBuscar_Click(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar produto para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbDelProduto_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                if (MessageBox.Show("Confirma a exclusão do produto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        if (ValidarToken())
                        {
                            //Cancelar produto no sistema
                            new CamadaDados.TDataQuery().executarSql("update TB_EST_Produto set ST_Registro = 'C', DT_Alt = GETDATE() " +
                                         "where cd_produto = '" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "' ", null);
                            if (!string.IsNullOrEmpty((bsProduto.Current as TRegistro_CadProduto).Cd_integracao))
                                ServiceRest.DataService.InativarProduto((bsProduto.Current as TRegistro_CadProduto).Cd_integracao, _token);
                            MessageBox.Show("Produto CANCELADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bbBuscarProd_Click(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbIntegraProduto_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                try
                {
                    if (ValidarToken())
                    {
                        //Novo produto
                        if (string.IsNullOrEmpty((bsProduto.Current as TRegistro_CadProduto).Cd_integracao))
                        {
                            Produtos produto = new Produtos();
                            //Buscar codigo barras
                            object obj = new TCD_CodBarra().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "'" } }, "a.cd_codbarra");
                            if(obj != null)
                                produto.CODIGO_BARRAS = obj.ToString();
                            produto.NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                            produto.FABRICACAO_PROPRIA = "N";
                            produto.DISPONIBILIDADE = "D";
                            produto.ORIGEM = "0";
                            produto.NCM = (bsProduto.Current as TRegistro_CadProduto).Ncm.SoNumero();
                            produto.CEST = (bsProduto.Current as TRegistro_CadProduto).Cest;
                            produto.CATEGORIA = new Categoria { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Grupo.Trim() };
                            produto.FABRICANTE = new Fabricante { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Marca.Trim() };
                            produto.UNIDADE_MEDIDA_VENDA = new Unidade { SIGLA = (bsProduto.Current as TRegistro_CadProduto).Sigla_unidade.Trim().ToUpper() };
                            (bsSaldoEst.List as List<TRegistro_SaldoEstoque>).ForEach(p =>
                            produto.ESTOQUES.Add(new Estoque
                            {
                                UNIDADE = "1",
                                LOCALIZACAO = "0",
                                QUANTIDADE_MINIMA = 0,
                                QUANTIDADE_ATUAL = p.Tot_saldo,
                                QUANTIDADE_RESERVA = 0,
                            }));
                            if ((bsProduto.Current as TRegistro_CadProduto).Vl_precovenda > decimal.Zero)
                                produto.PRECOS = new List<Preco>
                                {
                                    new Preco
                                    {
                                        UNIDADE = "0",
                                        MARGEM_CUSTO_REAL = 0,
                                        PRECO_CUSTO = 0,
                                        PRECO_CUSTO_ANTERIOR = 0,
                                        PRECO_CUSTO_REAL = 0,
                                        PRECO_MEDIO = 0,
                                        PRECO_VENDA = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda,
                                        PRECO_VENDA_ANTERIOR = 0,
                                        DESCONTO_MAXIMO = 0,
                                    }
                                };
                            produto.TRIBUTARIOS = new Tributarios
                            {
                                UNIDADE = "0",
                                ICMS_SIMPLES_NACIONAL = "N",
                                IPI_CST_ENTRADA = null,
                                IPI_CST_SAIDA = null,
                                IPI_ALIQUOTA = decimal.Zero,
                                IPI_VALOR_UNIDADE = decimal.Zero,
                                IPI_CLASSE_ENQUADRAMENTO = null,
                                PIS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p=> p.St_pis).Cd_st,
                                PIS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).pc_aliquota,
                                PIS_NATUREZA_RECEITA = null,
                                COFINS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).Cd_st,
                                COFINS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).pc_aliquota,
                                COFINS_NATUREZA_RECEITA = null,
                                CONTRIBUICAO_SOCIAL_APURADA = null,
                                TOTAL_TRIBUTOS_TIPO = "P",
                                TOTAL_TRIBUTOS_VALOR = null,
                                TOTAL_TRIBUTOS_PERCENTUAL = decimal.Zero
                            };
                            (bsCondFiscalIMCS.List as TList_CadCondFiscalICMS).ForEach(p =>
                            produto.TRIBUTARIOS_ICMS.Add(new Tributario_ICMS
                            {
                                UNIDADE = "1",
                                CST = p.Cd_st.Trim().Length > 2 ? "41" : p.Cd_st.Trim(),
                                ALIQUOTA_ORIGEM = p.Pc_aliquota_icms,
                                ALIQUOTA_DESTINO = p.Pc_aliquota_icmsDest,
                                MVA = p.Vl_mva,
                                MVA_AJUSTAR = "N",
                                ALIQUOTA_REDUCAO = p.Pc_reducaoaliquota,
                                ALIQUOTA_REDUCAO_ST = p.Pc_reducaobasecalc_substtrib,
                                INTERESTADUAL_ALIQUOTA_FCP = p.PC_FCP,
                                INTERESTADUAL_ALIQUOTA_DESTINO = decimal.Zero,
                                ESTADO = new Estado { SIGLA = p.Sg_ufdest }
                            }));
                            Retorno ret = ServiceRest.DataService.NovoProduto(produto, _token);
                            if (ret != null)
                                if (ret.REFERENCIAS != null)
                                {
                                    (bsProduto.Current as TRegistro_CadProduto).Cd_integracao = ret.REFERENCIAS.CODIGO;
                                    new CamadaDados.TDataQuery().executarSql("update TB_EST_Produto set cd_integracao = '" + (bsProduto.Current as TRegistro_CadProduto).Cd_integracao + "', dt_alt = GETDATE() " +
                                                                             "WHERE cd_produto = '" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "' ", null);
                                }
                        }
                        else if ((bsProduto.Current as TRegistro_CadProduto).ST_Registro.Trim().ToUpper().Equals("C"))
                        {
                            //Cancelar produto no site
                            ServiceRest.DataService.InativarProduto((bsProduto.Current as TRegistro_CadProduto).Cd_integracao, _token);
                            MessageBox.Show("Produto CANCELADO com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Produtos produto = new Produtos();
                            //Buscar codigo barras
                            object obj = new TCD_CodBarra().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "'" } }, "a.cd_codbarra");
                            if (obj != null)
                                produto.CODIGO_BARRAS = obj.ToString();
                            produto.NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                            produto.FABRICACAO_PROPRIA = "N";
                            produto.DISPONIBILIDADE = "D";
                            produto.ORIGEM = "0";
                            produto.NCM = (bsProduto.Current as TRegistro_CadProduto).Ncm.SoNumero();
                            produto.CEST = (bsProduto.Current as TRegistro_CadProduto).Cest;
                            produto.CATEGORIA = new Categoria { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Grupo.Trim() };
                            produto.FABRICANTE = new Fabricante { NOME = (bsProduto.Current as TRegistro_CadProduto).DS_Marca.Trim() };
                            produto.UNIDADE_MEDIDA_VENDA = new Unidade { SIGLA = (bsProduto.Current as TRegistro_CadProduto).Sigla_unidade.Trim().ToUpper() };
                            if ((bsProduto.Current as TRegistro_CadProduto).Vl_precovenda > decimal.Zero)
                                produto.PRECOS = new List<Preco>
                                                {
                                                    new Preco
                                                    {
                                                        UNIDADE = "0",
                                                        MARGEM_CUSTO_REAL = 0,
                                                        PRECO_CUSTO = 0,
                                                        PRECO_CUSTO_ANTERIOR = 0,
                                                        PRECO_CUSTO_REAL = 0,
                                                        PRECO_MEDIO = 0,
                                                        PRECO_VENDA = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda,
                                                        PRECO_VENDA_ANTERIOR = 0,
                                                        DESCONTO_MAXIMO = 0,
                                                    }
                                                };
                            produto.TRIBUTARIOS = new Tributarios
                            {
                                UNIDADE = "0",
                                ICMS_SIMPLES_NACIONAL = "N",
                                IPI_CST_ENTRADA = null,
                                IPI_CST_SAIDA = null,
                                IPI_ALIQUOTA = decimal.Zero,
                                IPI_VALOR_UNIDADE = decimal.Zero,
                                IPI_CLASSE_ENQUADRAMENTO = null,
                                PIS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).Cd_st,
                                PIS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_pis).pc_aliquota,
                                PIS_NATUREZA_RECEITA = null,
                                COFINS_CST = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).Cd_st,
                                COFINS_ALIQUOTA = (bsCondFiscalImp.List as TList_CondicaoFiscalImposto).FirstOrDefault(p => p.St_cofins).pc_aliquota,
                                COFINS_NATUREZA_RECEITA = null,
                                CONTRIBUICAO_SOCIAL_APURADA = null,
                                TOTAL_TRIBUTOS_TIPO = "P",
                                TOTAL_TRIBUTOS_VALOR = null,
                                TOTAL_TRIBUTOS_PERCENTUAL = decimal.Zero
                            };
                            (bsCondFiscalIMCS.List as TList_CadCondFiscalICMS).ForEach(p =>
                            produto.TRIBUTARIOS_ICMS.Add(new Tributario_ICMS
                            {
                                UNIDADE = "1",
                                CST = p.Cd_st.Trim().Length > 2 ? "41" : p.Cd_st.Trim(),
                                ALIQUOTA_ORIGEM = p.Pc_aliquota_icms,
                                ALIQUOTA_DESTINO = p.Pc_aliquota_icmsDest,
                                MVA = p.Vl_mva,
                                MVA_AJUSTAR = "N",
                                ALIQUOTA_REDUCAO = p.Pc_reducaoaliquota,
                                ALIQUOTA_REDUCAO_ST = p.Pc_reducaobasecalc_substtrib,
                                INTERESTADUAL_ALIQUOTA_FCP = p.PC_FCP,
                                INTERESTADUAL_ALIQUOTA_DESTINO = decimal.Zero,
                                ESTADO = new Estado { SIGLA = p.Sg_ufdest }
                            }));
                            Retorno ret = ServiceRest.DataService.AlterarProduto((bsProduto.Current as TRegistro_CadProduto).Cd_integracao, produto, _token);
                            MessageBox.Show("Produto alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else MessageBox.Show("Token invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show("Não existe Produto disponivel para integrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bsProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                bsSaldoEst.DataSource = new TCD_LanEstoque().SelectSaldoEstoque(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'" },
                        new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_Produto.Trim() + "'" }
                    });
                //Buscar movimentação comercial venda
                object obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_cfgempresa x " +
                                                        "where x.cfg_pedvenda = a.cfg_pedido " +
                                                        "and a.tp_fiscal = 'NO')"
                                        }
                                }, "a.cd_movto");
                bsCondFiscalIMCS.DataSource = TCN_CadCondFiscalICMS.Busca(string.Empty,
                                                                          (bsProduto.Current as TRegistro_CadProduto).CD_CondFiscal_Produto,
                                                                          string.Empty,
                                                                          (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Cd_uf_empresa,
                                                                          string.Empty,
                                                                          "S",
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          obj == null ? string.Empty : obj.ToString(),
                                                                          cbEmpresa.SelectedValue.ToString(),
                                                                          string.Empty,
                                                                          false,
                                                                          false,
                                                                          null);
                bsCondFiscalImp.DataSource = new TCD_CondicaoFiscalImposto().Select(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.TP_Faturamento", vOperador = "=", vVL_Busca = "'S'" },
                        new TpBusca { vNM_Campo = "a.TP_Pessoa", vOperador = "=", vVL_Busca = "'J'" },
                        new TpBusca { vNM_Campo = "a.cd_condfiscal_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as TRegistro_CadProduto).CD_CondFiscal_Produto.Trim() + "'" },
                        new TpBusca { vNM_Campo = "a.cd_movimentacao", vOperador = "=", vVL_Busca = obj == null ? "a.cd_movimentacao" : obj.ToString() },
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'" },
                        new TpBusca { vNM_Campo = string.Empty, vOperador = string.Empty, vVL_Busca = "b.st_pis = 0 or b.st_cofins = 0 or b.st_ipi = 0"}
                    }, 0, string.Empty);
            }
            else
            {
                bsSaldoEst.Clear();
                bsCondFiscalIMCS.Clear();
                bsCondFiscalImp.Clear();
            }
        }

        private void bbBoleto_Click(object sender, EventArgs e)
        {
            if (ValidarToken())
            {
                List<Boleto> boletos = ServiceRest.DataService.BuscarBoletos(DateTime.Parse(dt_ini.Text), DateTime.Parse(dt_fin.Text), _token);
                boletos.ForEach(x => x.St_integrado = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca {vNM_Campo = "a.nossonumero", vOperador = "=", vVL_Busca = "'" + x.NUMERO_DOCUMENTO.FormatStringEsquerda(7, '0') + "'" },
                        new TpBusca {vNM_Campo = "a.id_config", vOperador = "=", vVL_Busca = (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Id_configstr  }
                    }, "1") != null);
                bsBoleto.DataSource = boletos;

            }
        }

        private void gBoletos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && !(bsBoleto.Current as Boleto).St_integrado)
            {
                (bsBoleto.Current as Boleto).St_processar = !(bsBoleto.Current as Boleto).St_processar;
                bsBoleto.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsBoleto.Count > 0)
            {
                (bsBoleto.List as List<Boleto>).Where(p=> !p.St_integrado).ToList().ForEach(p => p.St_processar = cbTodos.Checked);
                bsBoleto.ResetBindings(true);
            }
        }

        private void bbIntegrarBoleto_Click(object sender, EventArgs e)
        {
            if ((bsBoleto.List as List<Boleto>).Exists(x => x.St_processar))
            {
                string mensagem = string.Empty;
                (bsBoleto.List as List<Boleto>).Where(x => x.St_processar).ToList().ForEach(x =>
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.ProcessarVendasExterna(cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna, x);
                        x.St_integrado = true;
                        x.St_processar = false;
                    }
                    catch (Exception ex)
                    { mensagem += "Boleto Nº" + x.NUMERO_DOCUMENTO.FormatStringEsquerda(7, '0') + " não foi integrado\r\nErro:" + ex.Message.Trim() + "\r\n"; }
                });
                gBoletos.Refresh();
                MessageBox.Show("Boletos integrados com sucesso.\r\n" + mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("Obrigatório selecionar boletos para integrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbDownloadNfe_Click(object sender, EventArgs e)
        {
            if(!DtIniNfe.Text.IsDateTime())
            {
                MessageBox.Show("Data Inicial Invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtIniNfe.Focus();
                return;
            }
            if(!DtFinNfe.Text.IsDateTime())
            {
                MessageBox.Show("Data Final Invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtFinNfe.Focus();
                return;
            }
            if (ValidarToken())
            {
                List<RegistroNFe> notas = ServiceRest.DataService.BuscarNFe(DateTime.Parse(DtIniNfe.Text), DateTime.Parse(DtFinNfe.Text), _token);
                notas.ForEach(x => x.St_integrado = new TCD_LanFaturamento().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Faturamento.Cadastros.TRegistro_CFGVendasExterna).Cd_empresa.Trim() + "'" },
                        new TpBusca { vNM_Campo = "a.nr_serie", vOperador = "=", vVL_Busca = "'" + x.SERIE.Trim() + "'" },
                        new TpBusca { vNM_Campo = "a.nr_notafiscal", vOperador = "=", vVL_Busca = x.NUMERO.SoNumero() }
                    }, "1") != null);
                bsNFe.DataSource = notas;
            }
        }

        private void gNFe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && !(bsNFe.Current as RegistroNFe).St_integrado)
            {
                (bsNFe.Current as RegistroNFe).St_processar = !(bsNFe.Current as RegistroNFe).St_processar;
                bsNFe.ResetCurrentItem();
            }
        }

        private void stIntegrarNFe_Click(object sender, EventArgs e)
        {
            if (bsNFe.Count > 0)
            {
                (bsNFe.List as List<RegistroNFe>).Where(p => !p.St_integrado).ToList().ForEach(p => p.St_processar = stIntegrarNFe.Checked);
                bsNFe.ResetBindings(true);
            }
        }

        private void bbIntegrarNfe_Click(object sender, EventArgs e)
        {
            if ((bsNFe.List as List<RegistroNFe>).Exists(x => x.St_processar))
            {
                string mensagem = string.Empty;
                (bsNFe.List as List<RegistroNFe>).Where(x => x.St_processar).ToList().ForEach(x =>
                {
                    try
                    {
                        TCN_LanFaturamento.ProcessarXMLNFePropria(ImportarNFe(x.NFE.XML), 
                                                                  (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna),
                                                                  null);
                        x.St_integrado = true;
                        x.St_processar = false;
                    }
                    catch (Exception ex)
                    { mensagem += "NFe Nº" + x.NUMERO + " não foi integrada\r\nErro:" + ex.Message.Trim() + "\r\n"; }
                });
                gNFe.Refresh();
                MessageBox.Show("NFe integradas com sucesso.\r\n" + mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("Obrigatório selecionar NFe para integrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbBuscarLiq_Click(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(!dtIniLiq.Text.IsDateTime())
            {
                MessageBox.Show("Obrigatório informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtIniLiq.Focus();
                return;
            }
            if(!dtFinLiq.Text.IsDateTime())
            {
                MessageBox.Show("Obrigatório informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtFinLiq.Focus();
                return;
            }
            dsBloqueto.DataSource = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (cbEmpresa.SelectedItem as TRegistro_CFGVendasExterna).Cd_empresa.Trim() + "'" },
                                        new TpBusca { vNM_Campo = "isnull(a.cd_integracao, '')", vOperador = "<>", vVL_Busca = "''" },
                                        new TpBusca { vNM_Campo = "isnull(a.st_baixadointegracao, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
                                        new TpBusca
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.cd_parcela = a.cd_parcela " +
                                                        "and isnull(x.st_registro, 'A') <> 'C')"
                                        }
                                    }, 0, string.Empty);
        }

        private void cbTodosLiq_Click(object sender, EventArgs e)
        {
            if (dsBloqueto.Count > 0)
            {
                (dsBloqueto.List as CamadaDados.Financeiro.Bloqueto.blListaTitulo).ForEach(p => p.St_processar = cbTodosLiq.Checked);
                dsBloqueto.ResetBindings(true);
            }
        }

        private void gBloquetos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_processar = 
                    !(dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_processar;
                dsBloqueto.ResetCurrentItem();
            }
        }

        private void bbIntegrarLiq_Click(object sender, EventArgs e)
        {
            if ((dsBloqueto.List as CamadaDados.Financeiro.Bloqueto.blListaTitulo).Exists(x => x.St_processar))
            {
                if (ValidarToken())
                {
                    string mensagem = string.Empty;
                    (dsBloqueto.List as CamadaDados.Financeiro.Bloqueto.blListaTitulo).ForEach(x =>
                    {
                        try
                        {
                            //Buscar data liquidacao
                            object obj = new CamadaDados.Financeiro.Duplicata.TCD_LanLiquidacao().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + x.Cd_empresa.Trim() + "'" },
                                                new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = x.Nr_lancto.ToString() },
                                                new TpBusca { vNM_Campo = "a.cd_parcela", vOperador = "=", vVL_Busca = x.Cd_parcela.ToString() },
                                                new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                            }, "a.DT_Liquidacao");
                            if(obj != null)
                                if (ServiceRest.DataService.BaixarBoletos(
                                    new BaixarBoleto
                                    {
                                        CODIGO = x.Cd_integracao,
                                        DATA_PAGAMENTO = DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                                        VALOR_PAGO = x.Vl_recebido.ToString("N2", new System.Globalization.CultureInfo("en-US", true))
                                    }, _token))
                                {
                                    x.St_baixadointegracao = "S";
                                    TCN_Titulo.Gravar(x, null);
                                }
                                else
                                    mensagem += "Boleto Nº" + x.Nosso_numero + " não foi integrada\r\n";
                        }
                        catch (Exception ex)
                        { mensagem += "Boleto Nº" + x.Nosso_numero + " não foi integrada\r\nErro:" + ex.Message.Trim() + "\r\n"; }
                    });
                    bbBuscarLiq_Click(this, new EventArgs());
                    MessageBox.Show("Boletos integrados com sucesso.\r\n" + mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Obrigatório selecionar Boletos para integrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbImportar_Click(object sender, EventArgs e)
        {
            if (ValidarToken())
                ServiceRest.DataService.BuscarClientes(_token);
        }
    }
}
