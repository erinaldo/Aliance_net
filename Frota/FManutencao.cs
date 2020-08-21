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
    public partial class TFManutencao : Form
    {
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vId_veiculo = string.Empty;
        public string vDs_veiculo = string.Empty;
        public bool st_consumointerno = false;
        private CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo rmanutencao;
        public CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo rManutencao
        {
            get
            {
                if (bsManutencao.Count > 0)
                    return bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo;
                else
                    return null;
            }
            set
            { rmanutencao = value; }
        }

        private CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliforEmit
        { get; set; }

        public TFManutencao()
        {
            InitializeComponent();
        }

        private void TotalizarManut()
        {
            if (bsMovimentacao.Current != null)
                vl_realizado.Value = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lMov.Sum(p => p.Vl_subtotal);
            else
                vl_realizado.Value = decimal.Zero;
        }

        private void afterGrava()
        {
            if (pManutencao.validarCampoObrigatorio())
            {
                if (vl_realizado.Value.Equals(decimal.Zero) && !st_consumointerno)
                {
                    MessageBox.Show("Obrigatorio informar valor para manutenção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirItens()
        {
            using (TFRetirarItensAlmox fAlmox = new TFRetirarItensAlmox())
            {
                fAlmox.Cd_empresa = cd_empresa.Text;
                if (fAlmox.ShowDialog() == DialogResult.OK)
                    if (fAlmox.rMovimentacao != null)
                    {
                        fAlmox.rMovimentacao.Ds_observacao = "PRODUTO RETIRADO PELA MANUTENÇÃO DE VEICULOS FROTA";
                        fAlmox.rMovimentacao.Cd_empresa = fAlmox.Cd_empresa;
                        fAlmox.rMovimentacao.Tp_movimento = "S";
                        fAlmox.rMovimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                        fAlmox.rMovimentacao.LoginAlmoxarife = Utils.Parametros.pubLogin;
                        fAlmox.rMovimentacao.St_registro = "A";
                        (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lMov.Add(fAlmox.rMovimentacao);
                        bsManutencao.ResetCurrentItem();
                    }
                this.TotalizarManut();
            }
        }

        private void ExcluirItens()
        {
            if (bsMovimentacao.Current != null)
            {
                if (MessageBox.Show("Deseja excluir o Item Selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lMovDel.Add(bsMovimentacao.Current as CamadaDados.Almoxarifado.TRegistro_Movimentacao);
                    //Excluir Item do Grid
                    (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lMov.Remove(bsMovimentacao.Current as CamadaDados.Almoxarifado.TRegistro_Movimentacao);
                    bsManutencao.ResetCurrentItem();

                }
                this.TotalizarManut();
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
                            dt_realizada.Text = DateTime.Parse(no.InnerText).ToString("dd/MM/yyyy");
                    }

                }
                lNo = xml.GetElementsByTagName("total");
                if (lNo.Count > 0)
                    foreach (XmlNode noT in lNo[0].ChildNodes)
                    {
                        if (noT.LocalName.Equals("ICMSTot"))
                            foreach (XmlNode noIT in noT.ChildNodes)
                            {
                                if (noIT.LocalName.Equals("vNF"))
                                    vl_realizado.Value = decimal.Parse(noIT.InnerText, new System.Globalization.CultureInfo("pt-BR"));
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
                        cd_cliforOficina.Text = lFornec[0].Cd_clifor;
                        nm_cliforOficina.Text = lFornec[0].Nm_clifor;
                    }
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

        private void TFManutencao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
            this.Size = new Size(865, 334);
            pManutencao.set_FormatZero();
            if (rmanutencao != null)
            {
                bsManutencao.DataSource = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo() { rmanutencao };
                id_veiculo.Enabled = false;
                bb_veiculo.Enabled = false;
                cd_empresa.Enabled = !rmanutencao.Nr_lancto.HasValue;
                bb_empresa.Enabled = !rmanutencao.Nr_lancto.HasValue;
                cd_cliforOficina.Enabled = !rmanutencao.Nr_lancto.HasValue;
                bb_Oficina.Enabled = !rmanutencao.Nr_lancto.HasValue;
                bbAddOficina.Enabled = !rmanutencao.Nr_lancto.HasValue;
                nr_notafiscal.Enabled = !rmanutencao.Nr_lancto.HasValue;
                dt_realizada.Enabled = !rmanutencao.Nr_lancto.HasValue;
                vl_realizado.Enabled = !rmanutencao.Nr_lancto.HasValue;
            }
            else
            {
                bsManutencao.AddNew();
                cd_empresa.Text = vCd_empresa;
                nm_empresa.Text = vNm_empresa;
                id_veiculo.Text = vId_veiculo;
                ds_veiculo.Text = vDs_veiculo;
            }
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|'" + id_despesa.Text.Trim() + "';" +
                            "a.tp_despesa|IN|('MV', 'MI', 'DV')";
           DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                new CamadaDados.Frota.Cadastros.TCD_Despesa());

           if (linha != null)
           {
               vl_realizado.Enabled = !linha["TP_DESPESA"].ToString().Equals("MI");
               st_consumointerno = linha["TP_DESPESA"].ToString().Equals("MI");
           }
           if (st_consumointerno && !string.IsNullOrEmpty(cd_empresa.Text))
           {
               //Buscar Clifor Empresa
               CamadaDados.Diversos.TList_CadEmpresa lEmp = null;
               lEmp = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                   new Utils.TpBusca[]
                   {
                       new Utils.TpBusca()
                       {
                           vNM_Campo = "a.cd_empresa",
                           vOperador = "=",
                           vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                       }
                   }, 1, string.Empty);
               if (lEmp != null)
               {
                   cd_cliforOficina.Text = lEmp[0].Cd_clifor;
                   nm_cliforOficina.Text = lEmp[0].Nm_clifor;
               }
               //Marcar como Realizada
               dt_realizada.Text = CamadaDados.UtilData.Data_Servidor().ToString();
               //Habilitar retirada Almoxarifado
               tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 285);
               this.Size = new Size(865, 600);
           }
           else
           {
               tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
               this.Size = new Size(865, 334);
           }
                            
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|IN|('MV', 'MI', 'DV')";
           DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);

           if (linha != null)
           {
               vl_realizado.Enabled = !linha["TP_DESPESA"].ToString().Equals("MI");
               st_consumointerno = linha["TP_DESPESA"].ToString().Equals("MI");
           }
           if (st_consumointerno && !string.IsNullOrEmpty(cd_empresa.Text))
           {
               //Buscar Clifor Empresa
               CamadaDados.Diversos.TList_CadEmpresa lEmp = null;
               lEmp = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                   new Utils.TpBusca[]
                   {
                       new Utils.TpBusca()
                       {
                           vNM_Campo = "a.cd_empresa",
                           vOperador = "=",
                           vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                       }
                   }, 1, string.Empty);
               if (lEmp != null)
               {
                   cd_cliforOficina.Text = lEmp[0].Cd_clifor;
                   nm_cliforOficina.Text = lEmp[0].Nm_clifor;
               }
               //Marcar como Realizada
               dt_realizada.Text = CamadaDados.UtilData.Data_Servidor().ToString();
               //Habilitar retirada Almoxarifado
               tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 260);
               this.Size = new Size(865, 600);
           }
           else
           {
               tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
               this.Size = new Size(865, 334);
           }
        }
        
        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void bb_Responsavel_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Responsavel|200;" +
                               "a.cd_clifor|Codigo|80";
              string vParam = "isnull(a.st_funcionarios, 'N')|=|'S';" +
                               "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
        }

        private void cd_cliforResponsavel_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforResponsavel.Text.Trim() + "';" +
                               "isnull(a.st_funcionarios, 'N')|=|'S';" +
                               "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel},
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_Oficina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Oficina|200;" +
                               "a.cd_clifor|Codigo|80";
               string vParam = "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
        }

        private void cd_cliforOficina_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforOficina.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFManutencao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItens();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItens();
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_inserirItem_Click(object sender, EventArgs e)
        {
            this.InserirItens();
        }

        private void bb_excluirItem_Click(object sender, EventArgs e)
        {
            this.ExcluirItens();
        }

        private void bbAddResponsavel_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cliforResponsavel.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforResponsavel.Text = fClifor.rClifor.Nm_clifor;
                        cd_cliforOficina.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAddOficina_Click(object sender, EventArgs e)
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
                        cd_cliforOficina.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforOficina.Text = fClifor.rClifor.Nm_clifor;
                        nr_notafiscal.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAddDespesa_Click(object sender, EventArgs e)
        {
            Utils.InputBox ibp = new Utils.InputBox();
            ibp.Text = "Descrição Despesa";
            string despesa = ibp.ShowDialog();
            if (!string.IsNullOrEmpty(despesa))
                try
                {
                    CamadaDados.Frota.Cadastros.TRegistro_Despesa rDesp = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
                    rDesp.Ds_despesa = despesa;
                    rDesp.Tp_despesa = "MV";
                    CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(rDesp, null);
                    id_despesa.Text = rDesp.Id_despesastr;
                    ds_despesa.Text = rDesp.Ds_despesa;
                    vl_realizado.Enabled = true;
                    cd_cliforResponsavel.Focus();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else MessageBox.Show("Obrigatório informar descrição despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
