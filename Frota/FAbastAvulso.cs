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

namespace Frota
{
    public partial class TFAbastAvulso : Form
    {
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vId_veiculo = string.Empty;
        public string vDs_veiculo = string.Empty;
        public string vCd_clifor = string.Empty;
        public string vCd_endereco = string.Empty;
        public string vDs_endereco = string.Empty;
        private CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliforEmit
        { get; set; }
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe rItem
        { get; set; }
        private CamadaDados.Frota.TRegistro_AbastVeiculo rabast;
        public CamadaDados.Frota.TRegistro_AbastVeiculo rAbast
        {
            get
            {
                if (bsAbastecimento.Current != null)
                    return bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                else
                    return null;
            }
            set { rabast = value; }
        }

        public TFAbastAvulso()
        {
            InitializeComponent();
            this.lCfg = new CamadaDados.Frota.Cadastros.TList_CfgFrota();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PROPRIO", "P"));
            cbx.Add(new Utils.TDataCombo("TERCEIRO", "T"));
            tp_abastecimento.DataSource = cbx;
            tp_abastecimento.DisplayMember = "Display";
            tp_abastecimento.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("EMPRESA", "E"));
            cbx1.Add(new Utils.TDataCombo("MOTORISTA", "M"));
            tp_pagamento.DataSource = cbx1;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (volume_requisicao.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar volume.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (vl_unitario.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor unitario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(cd_produto.Text))
                {
                    MessageBox.Show("Não existe combustivel configurado para a empresa " + cd_empresa.Text.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("T") &&
                    string.IsNullOrEmpty((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento))
                {
                    MessageBox.Show("Obrigatorio selecionar tipo de pagamento para abastecimento TERCEIRO", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("T") &&
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento.Trim().ToUpper().Equals("E") &&
                    string.IsNullOrWhiteSpace(vCd_clifor))
                {
                    MessageBox.Show("Obrigatório informar fornecedor cadastrado para incluir duplicata.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(lCfg.Count > 0)
                    if (lCfg[0].St_km_obrigatoriobool && km_atual.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Configuração exige KM para toda abastecida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscarEndereco()
        {
            //Busca Endereço Fornecedor
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + vCd_clifor.Trim() + "'"
                        }
                    }, 1, string.Empty);
            if (List_Endereco.Count > 0)
            {
                vCd_endereco = List_Endereco[0].Cd_endereco;
                vDs_endereco = List_Endereco[0].Ds_endereco;
            }
        }

        private void CustoProduto()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar Combustivel
                if (lCfg.Count > 0)
                {
                    cd_produto.Text = string.IsNullOrEmpty(cd_produto.Text) ? lCfg[0].Cd_combustivel : cd_produto.Text;
                    ds_produto.Text = string.IsNullOrEmpty(ds_produto.Text) ? lCfg[0].Ds_combustivel : ds_produto.Text;
                    id_despesa.Text = string.IsNullOrEmpty(id_despesa.Text) ? lCfg[0].Id_despesacombustivelstr : id_despesa.Text;
                    ds_despesa.Text = string.IsNullOrEmpty(ds_despesa.Text) ? lCfg[0].Ds_despesacombustivel : ds_despesa.Text;
                }
                if (tp_abastecimento.Text.Trim().ToUpper().Equals("PROPRIO"))
                {
                    decimal vl_custo = decimal.Zero;
                    CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(cd_empresa.Text, cd_produto.Text, ref vl_custo, null);
                    vl_unitario.Value = vl_custo;
                    vl_subtotal.Value = volume_requisicao.Value * vl_custo;
                }
            }
        }

        private void ImportNfe(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            using (TFImportarNFeCTe fImport = new TFImportarNFeCTe())
            {
                //Leitura do arquivo XML
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
                XmlNodeList lNo = xml.GetElementsByTagName("infNFe");
                if (lNo.Count.Equals(0))
                {
                    MessageBox.Show("XML Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #region Identificação NFe
                lNo = xml.GetElementsByTagName("ide");
                if (lNo.Count > 0)
                {
                    string tp_mov = string.Empty;
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("nNF"))
                            nr_notafiscal.Text = no.InnerText;
                        else if (no.LocalName.Equals("dhEmi"))
                            dt_requisicao.Text = DateTime.Parse(no.InnerText).ToString("dd/MM/yyyy");
                    }

                }
                #endregion
                #region Emitente NFe
                lNo = xml.GetElementsByTagName("emit");
                //Criar classe Clifor
                rCliforEmit =
                    new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
                //Criar classe Endereco
                CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndCliforEmit =
                    new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                if (lNo.Count > 0)
                {
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("CNPJ"))
                        {
                            rCliforEmit.Nr_cgc = no.InnerText;
                            rCliforEmit.Tp_pessoa = "J";
                        }
                        else if (no.LocalName.Equals("CPF"))
                        {
                            rCliforEmit.Nr_cpf = no.InnerText;
                            rCliforEmit.Tp_pessoa = "F";
                        }
                        else if (no.LocalName.Equals("xNome"))
                            rCliforEmit.Nm_clifor = no.InnerText;
                        else if (no.LocalName.Equals("xFant"))
                            rCliforEmit.Nm_fantasia = no.InnerText;
                        else if (no.LocalName.Equals("IE"))
                            rEndCliforEmit.Insc_estadual = no.InnerText;
                    }
                    //Buscar fornecedor
                    lFornec =
                       CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.IsNullOrEmpty(rCliforEmit.Nr_cgc.SoNumero()) ? string.Empty : Convert.ToUInt64(rCliforEmit.Nr_cgc).ToString(@"00\.000\.000\/0000\-00"),
                                                                                     string.IsNullOrEmpty(rCliforEmit.Nr_cpf.SoNumero()) ? string.Empty : Convert.ToUInt64(rCliforEmit.Nr_cpf).ToString(@"000\.000\.000\-00"),
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
                }
                #endregion

                #region Endereco Emitente NFe
                lNo = xml.GetElementsByTagName("enderEmit");
                if (lNo.Count > 0)
                {
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("xLgr"))
                            rEndCliforEmit.Ds_endereco = no.InnerText;
                        else if (no.LocalName.Equals("nro"))
                            rEndCliforEmit.Numero = no.InnerText;
                        else if (no.LocalName.Equals("xCpl"))
                            rEndCliforEmit.Ds_complemento = no.InnerText;
                        else if (no.LocalName.Equals("xBairro"))
                            rEndCliforEmit.Bairro = no.InnerText;
                        else if (no.LocalName.Equals("cMun"))
                            rEndCliforEmit.Cd_cidade = no.InnerText;
                        else if (no.LocalName.Equals("xMun"))
                            rEndCliforEmit.DS_Cidade = no.InnerText;
                        else if (no.LocalName.Equals("CEP"))
                            rEndCliforEmit.Cep = no.InnerText;
                        else if (no.LocalName.Equals("fone"))
                            rEndCliforEmit.Fone = no.InnerText;
                        else if (no.LocalName.Equals("UF"))
                            rEndCliforEmit.UF = no.InnerText;
                    }
                    //Buscar endereco fornecedor
                    if (lFornec.Count > 0)
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lFornec[0].Cd_clifor,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.IsNullOrEmpty(rEndCliforEmit.Cep.SoNumero()) ? string.Empty : rEndCliforEmit.Cep,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                    }
                }
                #endregion

                #region Destinatario NFe
                lNo = xml.GetElementsByTagName("dest");
                if (lNo.Count > 0)
                {
                    string cnpj_dest = string.Empty;
                    foreach (XmlNode no in lNo[0].ChildNodes)
                    {
                        if (no.LocalName.Equals("CNPJ"))
                            cnpj_dest = no.InnerText;
                    }
                    if (new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from VTB_FIN_Clifor x " +
                                                "where a.cd_clifor = x.cd_clifor " +
                                                "and x.nr_cgc = '" + rCliforEmit.Nr_cgc.Trim() + "')"
                                }
                            }, "1") == null)
                    {
                        MessageBox.Show("Destinatário do XML não se encontra cadastrado como empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    rCliforEmit.lEndereco.Add(rEndCliforEmit);
                    if (lFornec.Count > 0)
                    {
                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_fornecedor = lFornec[0].Cd_clifor;
                        nm_fornecedor.Text = lFornec[0].Nm_clifor;
                    }
                }
                #endregion

                #region Itens da NFe
                //Buscar Combustivel
                lNo = xml.GetElementsByTagName("det");
                if (lNo.Count == 1)
                {
                    foreach (XmlNode no in lNo)
                    {
                        rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe();
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
                                    else if (noP.LocalName.Equals("qCom"))
                                    {
                                        volume_requisicao.Value = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                        rItem.Quantidade_xml = volume_requisicao.Value;
                                    }
                                    else if (noP.LocalName.Equals("vUnCom"))
                                        vl_unitario.Value = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                    else if (noP.LocalName.Equals("vProd"))
                                        vl_subtotal.Value = decimal.Parse(noP.InnerText, new System.Globalization.CultureInfo("en-US"));
                                }
                            }
                        }
                        //Buscar produto no sistema
                        if (rCliforEmit != null)
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
                                                "and x.cd_fornecedor = '" + lFornec[0].Cd_clifor.Trim() + "')"
                                }
                            }, 1, string.Empty, string.Empty, string.Empty);
                            if (lProd.Count.Equals(1))
                            {
                                rItem.rProd = lProd[0];
                                rItem.Cd_produto = lProd[0].CD_Produto;
                                rItem.Ds_produto = lProd[0].DS_Produto;
                                cd_produto.Text = rItem.Cd_produto;
                                ds_produto.Text = rItem.Ds_produto;
                            }
                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).rProdForn = rItem;
                        }
                #endregion
                        if (!System.IO.Directory.Exists(Utils.SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp"))
                            System.IO.Directory.CreateDirectory(Utils.SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp");
                        if (!System.IO.File.Exists(Utils.SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" +
                            System.IO.Path.DirectorySeparatorChar.ToString() + path.Substring(path.LastIndexOf("\\"), path.Trim().Length - path.LastIndexOf("\\"))))
                            System.IO.File.Move(path,
                                Utils.SettingsUtils.Default.Path_XML_NFe_CTe + System.IO.Path.DirectorySeparatorChar.ToString() + "bkp" +
                                System.IO.Path.DirectorySeparatorChar.ToString() + path.Substring(path.LastIndexOf("\\"), path.Trim().Length - path.LastIndexOf("\\")));
                    }
                }
            }
        }


        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                if (lCfg.Count > 0)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Tp_concentrador))
                        tp_abastecimento.SelectedValue = "T";
                    tp_abastecimento.Enabled = !string.IsNullOrEmpty(lCfg[0].Tp_concentrador);
                }
            }
            this.CustoProduto();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                if (lCfg.Count > 0)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Tp_concentrador))
                        tp_abastecimento.SelectedValue = "T";
                    tp_abastecimento.Enabled = !string.IsNullOrEmpty(lCfg[0].Tp_concentrador);
                }
            }
            this.CustoProduto();
        }

        private void TFAbastAvulso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rabast != null)
            {
                bsAbastecimento.DataSource = new CamadaDados.Frota.TList_AbastVeiculo() { rabast };
                tp_abastecimento.Enabled = false;
                cd_empresa.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                bb_empresa.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                cd_produto.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                bb_produto.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                dt_requisicao.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                volume_requisicao.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                vl_unitario.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                vl_subtotal.Enabled = !rabast.Tp_abastecimento.Trim().ToUpper().Equals("P") && rabast.lDup.Count.Equals(0);
                nr_notafiscal.Enabled = rabast.lDup.Count.Equals(0);
                nm_fornecedor.Enabled = rabast.lDup.Count.Equals(0);
                bb_fornecedor.Enabled = rabast.lDup.Count.Equals(0);
                bbAddFornecedor.Enabled = rabast.lDup.Count.Equals(0);
            }
            else
            {
                bsAbastecimento.AddNew();
                cd_empresa.Text = vCd_empresa;
                nm_empresa.Text = vNm_empresa;
                id_veiculo.Text = vId_veiculo;
                ds_veiculo.Text = vDs_veiculo;
            }
        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Descrição Viagem|200;" +
                              "a.id_viagem|Codigo|80;" +
                              "c.ds_veiculo|Veiculo|150;" +
                              "c.placa|Placa|80;" +
                              "a.id_veiculo|Id. Veiculo|80";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
            if (!string.IsNullOrEmpty(id_veiculo.Text))
                vParam += ";a.id_veiculo|=|" + id_veiculo.Text;
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.TCD_Viagem(), vParam);
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_viagem|=|" + id_viagem.Text + ";" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
            if (!string.IsNullOrEmpty(id_veiculo.Text))
                vParam += ";a.id_veiculo|=|" + id_veiculo.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.TCD_Viagem());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I';" +
                            "|EXISTS|(select * from tb_div_tpveiculo x " +
                             "where a.cd_tpveiculo = x.cd_tpveiculo " +
                             "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void id_viagem_TextChanged(object sender, EventArgs e)
        {
            id_veiculo.Enabled = string.IsNullOrEmpty(id_viagem.Text);
            bb_veiculo.Enabled = string.IsNullOrEmpty(id_viagem.Text);
            tp_pagamento.Enabled = !string.IsNullOrEmpty(id_viagem.Text);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                              "isnull(a.st_registro, 'A')|<>|'I';" +
                              "|EXISTS|(select * from tb_div_tpveiculo x " +
                              "where a.cd_tpveiculo = x.cd_tpveiculo " +
                              "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Descrição Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
           DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
            if (linha != null && rItem != null)
            {
                rItem.Cd_produto = linha["cd_produto"].ToString();
                rItem.Ds_produto = linha["ds_produto"].ToString();
            }
            this.CustoProduto();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
          DataRow linha =  FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null && rItem != null)
            {
                rItem.Cd_produto = linha["cd_produto"].ToString();
                rItem.Ds_produto = linha["ds_produto"].ToString();
            }
            this.CustoProduto();
        }

        private void tp_abastecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CustoProduto();
            cd_produto.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
            bb_produto.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
            volume_requisicao.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
            vl_unitario.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
            vl_subtotal.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
            bb_abast.Enabled = tp_abastecimento.Text.Trim().ToUpper().Equals("PROPRIO");
            tp_pagamento.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO" && !string.IsNullOrEmpty(id_viagem.Text);
            dt_requisicao.Enabled = tp_abastecimento.Text.Trim().ToUpper() != "PROPRIO";
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void volume_requisicao_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = volume_requisicao.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = volume_requisicao.Value * vl_unitario.Value;
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {
            if (volume_requisicao.Value > decimal.Zero)
                vl_unitario.Value = vl_subtotal.Value / volume_requisicao.Value;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAbastAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
           DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_fornecedor }, string.Empty);
           vCd_clifor = linha["cd_clifor"].ToString();
           this.BuscarEndereco();
        }

        private void bb_abast_Click(object sender, EventArgs e)
        {
            if((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("P"))
                using (TFListaAbastecida fLista = new TFListaAbastecida())
                {
                    fLista.Cd_empresa = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.rAbast != null)
                        {
                            volume_requisicao.Value = fLista.rAbast.Volume;
                            vl_subtotal.Value = fLista.rAbast.Volume * vl_unitario.Value;
                            dt_requisicao.Text = fLista.rAbast.Dt_abastecidastr;
                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).rAbast = fLista.rAbast;
                            if(!vl_unitario.Focus())
                                vl_subtotal.Focus();
                        }
                }
        }

        private void volume_requisicao_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void tp_pagamento_EnabledChanged(object sender, EventArgs e)
        {
            if (!tp_pagamento.Enabled)
                tp_pagamento.SelectedIndex = -1;
        }

        private void bbAddFornecedor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (rCliforEmit != null)
                    fClifor.rClifor = rCliforEmit;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vCd_clifor = fClifor.rClifor.Cd_clifor;
                        nm_fornecedor.Text = fClifor.rClifor.Nm_clifor;
                        vCd_endereco = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        vDs_endereco = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_fornecedor = fClifor.rClifor.Cd_clifor;
                        ds_observacao.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_xmlNFe_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Documentos XML|*.xml";
                op.InitialDirectory = string.IsNullOrEmpty(Utils.SettingsUtils.Default.Path_XML_NFe_CTe) ? "c:" : Utils.SettingsUtils.Default.Path_XML_NFe_CTe;
                op.Title = "Selecione XML NFe";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(op.FileName))
                    {
                        Utils.SettingsUtils.Default.Path_XML_NFe_CTe = op.FileName.Substring(0, op.FileName.LastIndexOf("\\"));
                        Utils.SettingsUtils.Default.Save();
                        this.ImportNfe(op.FileName);
                    }
                }
            }
        }

        private void chave_acesso_nfe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
              char.IsSymbol(e.KeyChar) || //Símbolos
              char.IsWhiteSpace(e.KeyChar) || //Espaço
              char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void chave_acesso_nfe_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chave_acesso_nfe.Text))
                if (chave_acesso_nfe.Text.Length == 44)
                    if (Utils.Estruturas.Mod11(chave_acesso_nfe.Text.Trim().Substring(0, 43), 9, false, 0).ToString() == chave_acesso_nfe.Text.Trim().Substring(43, 1))
                        this.ImportNfe(Proc_Commoditties.DownloadXmlNFe.DownloadHtml(chave_acesso_nfe.Text));
                    else
                        MessageBox.Show("Chave de Acesso inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
