using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Balanca;
using Componentes;
using System.Linq;
using System.Linq.Expressions;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;

namespace Balanca
{
    public partial class TFLanNotasPesagem : Form
    {
        TList_RegLanPesagemClifor lexcluiproduto;
        public TList_RegLanPesagemClifor Lexcluiproduto
        {
            get { return lexcluiproduto; }
            set { lexcluiproduto = value; }
        }        

        private TTpModo tpModo;
        public bool St_controlardesdobro
        { get; set; }
        private string UnEst = string.Empty;

        public bool vST_Altera
        {get;set;}
        public decimal vQTDesdobro
        {get;set;}
        public string vCD_Empresa
        {get;set;}
        public string vNr_Contrato
        { get; set; }
        public string vNR_PedidoPrincipal
        { get; set; }
        public string vTP_MovPedido
        { get; set; }
        public string vTP_Movimento
        { get; set; }
        public string vCD_Produto
        { get; set; }
        public string vDS_Produto
        { get; set; }
        public decimal vQTD_PESAGEM
        { get; set; }
        public string cd_movimentacao
        { get; set; }

        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endclifor
        { get; set; }
        public string Ds_endclifor
        { get; set; }
        public string Tp_pessoa
        { get; set; }
        public string Uf_clifor
        { get; set; }
        public string Cd_clifor_pedido
        { get; set; }
        public string Nm_clifor_pedido
        { get; set; }
        public string Nr_cnpj_cpf_pedido
        { get; set; }
        public string vCd_transportadora
        { get; set; }
        public string vNm_transportadora
        { get; set; }
        public string vPlacaveiculo
        { get; set; }

        public TFLanNotasPesagem()
        {
            InitializeComponent();
            this.St_controlardesdobro = false;
            this.vST_Altera = false;
            this.vQTDesdobro = decimal.Zero;
            this.vCD_Empresa = string.Empty;
            this.vNr_Contrato = string.Empty;
            this.vNR_PedidoPrincipal = string.Empty;
            this.vTP_MovPedido = string.Empty;
            this.vTP_Movimento = string.Empty;
            this.vCD_Produto = string.Empty;
            this.vDS_Produto = string.Empty;
            this.vQTD_PESAGEM = decimal.Zero;
            this.cd_movimentacao = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endclifor = string.Empty;
            this.Ds_endclifor = string.Empty;
            this.Tp_pessoa = string.Empty;
            this.Uf_clifor = string.Empty;
            this.Cd_clifor_pedido = string.Empty;
            this.Nm_clifor_pedido = string.Empty;
            this.Nr_cnpj_cpf_pedido = string.Empty;
            this.vCd_transportadora = string.Empty;
            this.vNm_transportadora = string.Empty;
            this.vPlacaveiculo = string.Empty;
            tpModo = TTpModo.tm_Standby;
            lexcluiproduto = new TList_RegLanPesagemClifor();

            ArrayList cBox2 = new ArrayList();
            cBox2.Add(new TDataCombo("EMITENTE", "1"));
            cBox2.Add(new TDataCombo("DESTINATARIO", "2"));
            freteporconta.DataSource = cBox2;
            freteporconta.DisplayMember = "Display";
            freteporconta.ValueMember = "Value";
        }

        private void habilitaBotoes(bool vNovo, bool vAlterar, bool vGravar, bool vExcluir, bool vCancelar)
        {
            BB_Novo.Visible = vNovo;
            BB_Alterar.Visible = vAlterar;
            BB_Gravar.Visible = vGravar;
            BB_Excluir.Visible = vExcluir;
            BB_Cancelar.Visible = vCancelar;
        }

        private void modoBotoes()
        {
            if (tpModo == TTpModo.tm_Standby)
                habilitaBotoes(true, true, false, true, false);
            else if (tpModo == TTpModo.tm_Insert)
                habilitaBotoes(false, false, true, false, true);
            else if (tpModo == TTpModo.tm_Edit)
                habilitaBotoes(false, false, true, false, true);
        }

        private void afterNovo()
        {
            if (vQTDesdobro > bsNFPesagem.Count)
            {
                gNfPesagem.Enabled = false;
                tpModo = TTpModo.tm_Insert;
                pnClifor.HabilitarControls(true, tpModo);

                modoBotoes();
                bsNFPesagem.AddNew();
                NR_PedidoClifor.Text = vNR_PedidoPrincipal;
                nr_Contrato.Text = vNr_Contrato;
                cd_cliforpedido.Text = this.Cd_clifor_pedido;
                nm_cliforpedido.Text = this.Nm_clifor_pedido;
                cd_clifordesdobro.Text = this.Cd_clifor;
                nm_clifordesdobro.Text = this.Nm_clifor;
                cd_enderecodesdobro.Text = this.Cd_endclifor;
                DS_Endereco.Text = this.Ds_endclifor;
                tp_pessoadesdobro.Text = this.Tp_pessoa;
                ufdesdobro.Text = this.Uf_clifor;
                CD_Transp.Text = this.vCd_transportadora;
                nm_transportadora.Text = this.vNm_transportadora;
                PlacaVeiculo.Text = this.vPlacaveiculo;
                this.habilitarCampos(true);
                if (!NR_PedidoClifor.Focus())
                    nr_notafiscal.Focus();
            }
            else
                MessageBox.Show("Número máximo de desdobros atingido! ");
        }

        private void afterGrava()
        {
            if (pnClifor.validarCampoObrigatorio())
            {
                if ((bsNFPesagem.Current as TRegistro_LanPesagemClifor).Desdobroprodutos.Count < 1)
                {
                    MessageBox.Show("Obrigatorio informar item para gravar nota fiscal pesagem.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                tpModo = TTpModo.tm_Standby;
                modoBotoes();
                pnClifor.HabilitarControls(false, tpModo);
                bb_obsfiscal.Enabled = false;
                ds_obsfiscal.Enabled = false;
                bb_dadosadic.Enabled = false;
                ds_DadosAdicionais.Enabled = false;
                gNfPesagem.Enabled = true;
            }
        }

        private void afterCancela()
        {
            if (tpModo.Equals(TTpModo.tm_Insert))
                bsNFPesagem.RemoveCurrent();
            else
                bsNFPesagem.CancelEdit();
            tpModo = TTpModo.tm_Standby;
            modoBotoes();
            pnClifor.HabilitarControls(false, tpModo);
            bb_obsfiscal.Enabled = false;
            ds_obsfiscal.Enabled = false;
            bb_dadosadic.Enabled = false;
            ds_DadosAdicionais.Enabled = false;
            gNfPesagem.Enabled = true;
        }

        private void afterExclui()
        {
            if (bsNFPesagem.Count > 0)
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                {                    
                    lexcluiproduto.Add((bsNFPesagem.Current as TRegistro_LanPesagemClifor));
                    bsNFPesagem.RemoveCurrent();
                    bsNFPesagem.ResetCurrentItem();
                    tpModo = TTpModo.tm_Standby;
                    modoBotoes();
                    pnClifor.HabilitarControls(false, tpModo);
                    bb_obsfiscal.Enabled = false;
                    ds_obsfiscal.Enabled = false;
                    bb_dadosadic.Enabled = false;
                    ds_DadosAdicionais.Enabled = false;
                }
        }

        private void afterAltera()
        {
            if (bsNFPesagem.Current != null)
            {
                tpModo = TTpModo.tm_Edit;
                modoBotoes();
                NR_PedidoClifor.Text = vNR_PedidoPrincipal;
                nr_Contrato.Text = vNr_Contrato;
                cd_clifordesdobro.Focus();
                gNfPesagem.Enabled = false;
                bb_obsfiscal.Enabled = true;
                ds_obsfiscal.Enabled = true;
                bb_dadosadic.Enabled = true;
                ds_DadosAdicionais.Enabled = true;
                this.habilitarCampos(true);
            }
        }

        private void habilitarCampos(bool Status)
        {
            NR_PedidoClifor.Enabled = this.vNR_PedidoPrincipal.Trim().Equals(string.Empty) && (!tpModo.Equals(TTpModo.tm_Edit));
            bb_pedidoclifor.Enabled = this.vNR_PedidoPrincipal.Trim().Equals(string.Empty) &&(!tpModo.Equals(TTpModo.tm_Edit));
            cd_cliforpedido.Enabled = Status && (!tpModo.Equals(TTpModo.tm_Edit));
            bb_cliforpedido.Enabled = Status && (!tpModo.Equals(TTpModo.tm_Edit));
            nm_cliforpedido.Enabled = cd_cliforpedido.Text.Trim().Equals(string.Empty) && (!tpModo.Equals(TTpModo.tm_Edit));
            cd_clifordesdobro.Enabled = Status;
            bb_clifordesdobro.Enabled = Status;
            cd_enderecodesdobro.Enabled = Status;
            nr_notafiscal.Enabled = Status;
            nr_serie.Enabled = Status;
            bb_serie.Enabled = Status;
            dt_emissao.Enabled = Status;
            DT_SaiEnt.Enabled = Status;
            bb_obsfiscal.Enabled = Status;
            ds_obsfiscal.Enabled = Status;
            bb_dadosadic.Enabled = Status;
            ds_DadosAdicionais.Enabled = Status;
            TS_ItensPedido.Enabled = Status;
        }

        private void InserirItensNf()
        {
            if((this.tpModo.Equals(TTpModo.tm_Edit) || this.tpModo.Equals(TTpModo.tm_Insert)))
                if(bsNFPesagem.Current != null)
                {
                    using (TFItensNfPesagem fItensNf = new TFItensNfPesagem())
                    {
                        fItensNf.Nr_pedido = NR_PedidoClifor.Text;
                        fItensNf.Nr_contrato = nr_Contrato.Text;
                        fItensNf.Cd_produto = this.vCD_Produto;
                        fItensNf.Cd_empresa = this.vCD_Empresa;
                        if (fItensNf.ShowDialog() == DialogResult.OK)
                        {
                            if(fItensNf.rPsProduto != null)
                            {
                                (bsNFPesagem.Current as CamadaDados.Balanca.TRegistro_LanPesagemClifor).Desdobroprodutos.Add(fItensNf.rPsProduto);
                                bsNFPesagem.ResetCurrentItem();
                            }
                        }
                    }
                }
        }

        private void DeletarItensNf()
        {
            if((this.tpModo.Equals(TTpModo.tm_Edit) || this.tpModo.Equals(TTpModo.tm_Insert)))
                if(bsNFItens.Current != null)
                {
                    if(MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (bsNFPesagem.Current as CamadaDados.Balanca.TRegistro_LanPesagemClifor).DesdProdExcluir.Add(
                            bsNFItens.Current as CamadaDados.Balanca.TRegistro_LanPesagemProduto);
                        bsNFItens.RemoveCurrent();
                    }
                }
            else
                    MessageBox.Show("Necessario selecionar item da nota fiscal para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PreparaBSClifor_Pedido(string vNr_Pedido)
        {
            if (vNr_Pedido.Trim() != string.Empty)
            {
                string vParamFixo = "a.NR_Pedido|=|" + this.vNR_PedidoPrincipal.Trim() + ";" +
                                        "a.CD_Empresa|=|'" + this.vCD_Empresa.Trim() + "';" +

                                        //Usuario tem que ter acesso a empresa
                                        "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +

                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +

                                        //Pedido tem que estar amarrado a um contrato                                    
                                        ";|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                        "on x.nr_contrato = y.nr_contrato where " + (this.vNr_Contrato.Trim() != "" ? " x.nr_contrato = " + this.vNr_Contrato.Trim() + " and " : "") + " x.nr_pedido = a.nr_pedido )" +

                                        //Usuario tem que ter acesso ao tipo de pedido                                    
                                        ";|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";


                DataRow linha = UtilPesquisa.EDIT_LEAVE(vParamFixo, new Componentes.EditDefault[] { new Componentes.EditDefault() { Text = vNr_Pedido.ToString(), NM_CampoBusca = "nr_pedido" } }, new TCD_Pedido());
                if (linha != null)
                {
                    this.Cd_clifor_pedido = linha["CD_Clifor"].ToString();
                    this.Nm_clifor_pedido = linha["NM_Clifor"].ToString();
                    this.Cd_clifor = linha["CD_Clifor"].ToString();
                    this.Nm_clifor = linha["NM_Clifor"].ToString();
                    this.Cd_endclifor = linha["cd_endereco"].ToString();
                    this.Ds_endclifor = linha["DS_endereco"].ToString();
                    if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("F"))
                        if (linha["ST_Equiparado_PJ"].ToString().Trim().ToUpper().Equals("S"))
                            this.Tp_pessoa = "J";
                        else
                            this.Tp_pessoa = "F";
                    else if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("J"))
                        if (linha["ST_Agropecuaria"].ToString().Trim().ToUpper().Equals("S"))
                            this.Tp_pessoa = "F";
                        else
                            this.Tp_pessoa = "J";

                    this.Uf_clifor = linha["UF_Cliente"].ToString();
                    this.Nr_cnpj_cpf_pedido = linha["nr_cgc_cpf"].ToString();

                }
                else
                    MessageBox.Show("Pedido Unico não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            if (tpModo != TTpModo.tm_Standby)
            {
                if (MessageBox.Show("Existe Alterações que ainda não foram salvas. Deseja Salvar?", "Mensagem", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    bsNFPesagem.EndEdit();
                else
                {
                    bsNFPesagem.RemoveCurrent();
                    if (bsNFItens.Count > 0)
                        bsNFItens.RemoveCurrent();
                    tpModo = TTpModo.tm_Standby;
                    modoBotoes();
                }
            }
            else
            {
                if ((bsNFPesagem.Count > 0) && (bsNFItens.Count > 0))
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }
                
        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }
        
        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void TFLanNotasPesagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F11))
                this.InserirItensNf();
            else if (e.KeyCode.Equals(Keys.F12))
                this.DeletarItensNf();
            else if (e.KeyCode.Equals(Keys.Escape))
                BB_Fechar_Click(this, new EventArgs());
        }

        private void TFLanNotasPesagem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gNfPesagem);
            Utils.ShapeGrid.RestoreShape(this, gNFItens);
            pFrete.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pObsFiscal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pDadosAdic.BackColor = Utils.SettingsUtils.Default.COLOR_2;

            qtd_desdobro.Text = this.vQTDesdobro.ToString();
            pnClifor.set_FormatZero();
            pFrete.set_FormatZero();

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);

            if (vTP_Movimento.Trim().Equals(string.Empty) || vTP_MovPedido.Trim().Equals(string.Empty))
                vTP_MovPedido = vTP_Movimento;
            this.PreparaBSClifor_Pedido(this.vNR_PedidoPrincipal);
                       
            if (vNR_PedidoPrincipal.Trim() != string.Empty)
            {
                //BUSCAR A CONFIGURACAO DO PEDIDO PRINCIPAL PRA VER SE VAI SER SIMPLES REMESSA OU NAO
                TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(new TpBusca[]
                {
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "EXISTS",
                        vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                    "where x.cfg_pedido = a.cfg_pedido "+
                                    "and x.nr_pedido = " + vNR_PedidoPrincipal.Trim() + ")"
                    },
                    new TpBusca
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = vTP_MovPedido.ToUpper().Equals(vTP_Movimento.Trim().ToUpper()) ? "'NO'" : "'DV'"
                    }
                    }, 1, string.Empty);

                if (lPedFiscal.Count < 1)
                {
                    string tp_fiscal = "";
                    if (vTP_MovPedido.Trim().Equals(vTP_Movimento))
                        tp_fiscal = "NORMAL";
                    else
                        tp_fiscal = "DEVOLUÇÃO";

                    MessageBox.Show("Falta configuração fiscal para o pedido.\r\n\r\n" +
                                    "Sugestão: Na tela de lançamento de pedido, localize o pedido Nº " + vNR_PedidoPrincipal.ToString() + ", \r\n" +
                                    "e na aba DADOS FISCAIS cadastre uma nova configuração fiscal do tipo fiscal " + tp_fiscal + " para o pedido.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (string.IsNullOrEmpty(lPedFiscal[0].Cd_modelo))
                        throw new Exception("Configuração de modelo de nota é obrigatório para o tipo de pedido " + lPedFiscal[0].Cfg_pedido.ToString());
                    cd_movimentacao = lPedFiscal[0].Cd_movto.ToString();
                    
                }
            }
        }
                
        private void cd_clifordesdobro_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifordesdobro.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifordesdobro, nm_clifordesdobro },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (linha != null)
            {
                if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("F"))
                    if (linha["ST_Equiparado_PJ"].ToString().Trim().ToUpper().Equals("S"))
                        tp_pessoadesdobro.Text = "J";
                    else
                        tp_pessoadesdobro.Text = "F";
                else if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("J"))
                    if (linha["ST_Agropecuaria"].ToString().Trim().ToUpper().Equals("S"))
                        tp_pessoadesdobro.Text = "F";
                    else
                        tp_pessoadesdobro.Text = "J";
            }
        }

        private void bb_clifordesdobro_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                                            , new Componentes.EditDefault[] { cd_clifordesdobro, nm_clifordesdobro }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "");
            if (linha != null)
            {
                if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("F"))
                    if (linha["ST_Equiparado_PJ"].ToString().Trim().ToUpper().Equals("S"))
                        tp_pessoadesdobro.Text = "J";
                    else
                        tp_pessoadesdobro.Text = "F";
                else if (linha["TP_Pessoa"].ToString().Trim().ToUpper().Equals("J"))
                    if (linha["ST_Agropecuaria"].ToString().Trim().ToUpper().Equals("S"))
                        tp_pessoadesdobro.Text = "F";
                    else
                        tp_pessoadesdobro.Text = "J";
                cd_clifordesdobro_Leave(sender, e);

            }
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "';" +
                            "a.cd_modelo|=|'04'";//Nota Fiscal Produtor
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_serie }, 
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'04'";//Nota Fiscal Produtor
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.DS_SerieNF|Descrição Série|350;a.NR_Serie|Cód. Série|100",
                                                       new Componentes.EditDefault[] { nr_serie },
                                                       new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
        }

        private void cd_enderecodesdobro_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + cd_enderecodesdobro.Text + "';" +
                  "a.CD_Clifor|=|'" + cd_clifordesdobro.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_enderecodesdobro, DS_Endereco, ufdesdobro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (cd_enderecodesdobro.Text.Trim().Equals(string.Empty))
                bb_enderecodesdobro_Click(this, new EventArgs());

        }

        private void bb_enderecodesdobro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "c.DS_UF|Estado|150;" +
                              "UF|UF|80";
            string vParamFixo = "a.CD_Clifor|=|'" + cd_clifordesdobro.Text + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_enderecodesdobro, DS_Endereco, ufdesdobro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParamFixo);            
        }

        private void DT_SaiEnt_Enter(object sender, EventArgs e)
        {
            DT_SaiEnt.Text = CamadaDados.UtilData.Data_Servidor().ToString();
        }

        private void bb_dadosadic_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Sobre|Descrição Observação Fiscal|200;" +
                              "CD_ObservacaoFiscal|Cd. Observação|80;" +
                              "DS_ObservacaoFiscal|Observação Fiscal|200";
             DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { DS_Sobre },
                                                        new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), string.Empty);
             if (linha != null)
                 ds_DadosAdicionais.Text += linha["DS_ObservacaoFiscal"].ToString();
        }

        private void bb_obsfiscal_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Sobre|Descrição Observação Fiscal|200;" +
                              "CD_ObservacaoFiscal|Cd. Observação|80;" +
                              "DS_ObservacaoFiscal|Observação Fiscal|200";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { ds_sobrefiscal },
                                                       new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), string.Empty);
            if (linha != null)
                ds_obsfiscal.Text = linha["DS_ObservacaoFiscal"].ToString();
        }

        private void bb_pedidoclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Pedido|Nº Pedido|80;" +
                              "contrato.NR_Contrato|Nº Contrato|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "clifor.NM_Clifor|Nome Clifor|350;" +
                              "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                              "b.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|350;" +
                              "a.id_pedidoitem|Id. Pedido Item|80;" +
                              "n.tp_frete|Tipo Frete|80";

            string vParamFixo = "n.CD_Empresa|=|'" + this.vCD_Empresa.Trim() + "';" +
                                //Usuario tem que ter acesso a empresa
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                                //Pedido tem que estar amarrado a um contrato
                                ";|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                "on x.nr_contrato = y.nr_contrato where " + (this.vNr_Contrato.Trim() != string.Empty ? " x.nr_contrato = " + this.vNr_Contrato.Trim() + " and " : "") + " x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)" +
                                //Usuario tem que ter acesso ao tipo de pedido
                                ";|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                "where x.cfg_pedido = n.cfg_pedido " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            vParamFixo += ";b.CD_Produto|=|'" + this.vCD_Produto.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_PedidoClifor}, new TCD_LanPedido_Item(), vParamFixo);
            nm_cliforpedido.Enabled = cd_cliforpedido.Text.Trim().Equals(string.Empty);
            if (linha != null)
            {
                nr_Contrato.Text = linha["nr_contrato"].ToString();
                this.vTP_MovPedido = linha["Tp_movimento"].ToString();
                cd_cliforpedido.Text = linha["CD_Clifor"].ToString();
                nm_cliforpedido.Text = linha["NM_Clifor"].ToString();

                cd_clifordesdobro.Text = linha["CD_Clifor"].ToString();
                nm_clifordesdobro.Text = linha["NM_Clifor"].ToString();
                freteporconta.SelectedValue = linha["tp_frete"].ToString();
            }
            else
                this.vTP_MovPedido = string.Empty;
        }

        private void NR_PedidoClifor_Leave(object sender, EventArgs e)
        {
            string vParamFixo = "a.NR_Pedido|=|" + NR_PedidoClifor.Text.Trim() + ";" +
                                    "n.CD_Empresa|=|'" + this.vCD_Empresa.Trim() + "';" +
                //Usuario tem que ter acesso a empresa
                                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                    "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                //Pedido tem que estar amarrado a um contrato
                                    ";|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                    "on x.nr_contrato = y.nr_contrato where " + (this.vNr_Contrato.Trim() != string.Empty ? " x.nr_contrato = " + this.vNr_Contrato.Trim() + " and " : "") + " x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)" +
                //Usuario tem que ter acesso ao tipo de pedido
                                    ";|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                    "where x.cfg_pedido = n.cfg_pedido " +
                                    "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (this.vCD_Produto.Trim() != string.Empty)
                vParamFixo += ";b.CD_Produto|=|'" + this.vCD_Produto.Trim() + "'";


            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParamFixo, new Componentes.EditDefault[] { NR_PedidoClifor }, new TCD_LanPedido_Item());
            nm_cliforpedido.Enabled = cd_cliforpedido.Text.Trim().Equals(string.Empty);
            if (linha != null)
            {
                nr_Contrato.Text = linha["nr_contrato"].ToString();
                this.vTP_MovPedido = linha["Tp_movimento"].ToString();
                cd_cliforpedido.Text = linha["CD_Clifor"].ToString();
                nm_cliforpedido.Text = linha["NM_Clifor"].ToString();

                cd_clifordesdobro.Text = linha["CD_Clifor"].ToString();
                nm_clifordesdobro.Text = linha["NM_Clifor"].ToString();
                freteporconta.SelectedValue = linha["tp_frete"].ToString();

                cd_cliforpedido.Enabled = false;
                nm_cliforpedido.Enabled = false;
                bb_cliforpedido.Enabled = false;


                //BUSCAR A CONFIGURACAO DO PEDIDO PRINCIPAL PRA VER SE VAI SER SIMPLES REMESSA OU NAO
                TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(new TpBusca[]
                                                                {
                                                                    new TpBusca
                                                                    {
                                                                        vNM_Campo = string.Empty,
                                                                        vOperador = "EXISTS",
                                                                        vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                                                    "where x.cfg_pedido = a.cfg_pedido "+
                                                                                    "and x.nr_pedido = " + NR_PedidoClifor.Text + ")"
                                                                    },
                                                                    new TpBusca
                                                                    {
                                                                        vNM_Campo = "a.tp_fiscal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = this.vTP_MovPedido.Trim().ToUpper().Equals(this.vTP_Movimento.Trim()) ? "'NO'" : "'DV'"
                                                                    }
                                                                }, 1, "");
                if (lPedFiscal.Count < 1)
                {
                    string tp_fiscal = "";
                    if (this.vTP_MovPedido.Trim().Equals(this.vTP_Movimento.Trim()))
                        tp_fiscal = "NORMAL";
                    else
                        tp_fiscal = "DEVOLUÇÃO";

                    throw new Exception("Falta configuração fiscal para o pedido.\r\n\r\n" +
                                        "Sugestão: Na tela de lançamento de pedido, localize o pedido Nº " + NR_PedidoClifor.Text.ToString() + ", \r\n" +
                                        "e na aba DADOS FISCAIS cadastre uma nova configuração fiscal do tipo fiscal " + tp_fiscal + " para o pedido.");
                }
                else
                    if (string.IsNullOrEmpty(lPedFiscal[0].Cd_modelo))
                        throw new Exception("Configuração de modelo de nota é obriatório para o tipo de pedido " + lPedFiscal[0].Cfg_pedido.ToString());
            }
            else
            {
                this.vTP_MovPedido = string.Empty;
                cd_cliforpedido.Enabled = true;
                nm_cliforpedido.Enabled = true;
                bb_cliforpedido.Enabled = true;
            }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItensNf();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.DeletarItensNf();
        }

        private void bb_cliforpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                                "tp_pessoa|Tipo Pessoa|80;" +
                                "nr_cgc|C.N.P.J|80;" +
                                "nr_cpf|C.P.F|80;" +
                                "nr_rg|R.G|80;" +
                                "nm_razaosocial|Razão Social|100;" +
                                "nm_fantasia|Fantasia|100;" +
                                "EMAILPF|E-Mail P.F|100;" +
                                "EMAILPJ|E-Mail P.J|100";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if (this.vNR_PedidoPrincipal.Trim() != string.Empty)
                vParam += ";|exists|(select 1 from tb_fat_pedido x " +
                          "where x.cd_clifor = a.cd_clifor " +
                          "and x.nr_pedido = " + this.vNR_PedidoPrincipal + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforpedido, nm_cliforpedido }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void cd_cliforpedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforpedido.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            if (this.vNR_PedidoPrincipal.Trim() != string.Empty)
                vParam += ";|exists|(select 1 from tb_fat_pedido x " +
                          "where x.cd_clifor = a.cd_clifor " +
                          "and x.nr_pedido = " + this.vNR_PedidoPrincipal + ")";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_cliforpedido, nm_cliforpedido },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_trasnp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Transp, nm_transportadora, CPF_Transp }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void CD_Transp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'"
                , new Componentes.EditDefault[] { CD_Transp, nm_transportadora, CPF_Transp }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150"
                                , new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp }, 
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), 
                                "a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'");
        }

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + 
                                    "';a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void CPF_Transp_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CPF_Transp.Text))
            {
                if (CPF_Transp.Text.Trim().Length.Equals(11) ||
                    (CPF_Transp.Text.Trim().Length.Equals(14) &&
                    CPF_Transp.Text.Trim().Contains('.')))
                {
                    Utils.CPF_Valido.nr_CPF = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                    {
                        MessageBox.Show("CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CPF_Transp.Clear();
                    }
                }
                else if (CPF_Transp.Text.Trim().Length >= 14)
                {
                    Utils.CNPJ_Valido.nr_CNPJ = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(Utils.CNPJ_Valido.nr_CNPJ))
                    {
                        MessageBox.Show("CNPJ Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CPF_Transp.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("CNPJ/CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CPF_Transp.Clear();
                }
            }
        }

        private void CPF_Transp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) &&
                (e.KeyChar != '.') &&
                (e.KeyChar != '/') &&
                (e.KeyChar != '-') &&
                (e.KeyChar != '\b'))
                e.Handled = true;
        }

        private void gNfPesagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gNfPesagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNFPesagem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemClifor());
            TList_RegLanPesagemClifor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gNfPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gNfPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemClifor(lP.Find(gNfPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gNfPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemClifor(lP.Find(gNfPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gNfPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNFPesagem.List as TList_RegLanPesagemClifor).Sort(lComparer);
            bsNFPesagem.ResetBindings(false);
            gNfPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gNFItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gNFItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNFItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemProduto());
            TList_RegLanPesagemProduto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gNFItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gNFItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemProduto(lP.Find(gNFItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gNFItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemProduto(lP.Find(gNFItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gNFItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNFItens.List as TList_RegLanPesagemProduto).Sort(lComparer);
            bsNFItens.ResetBindings(false);
            gNFItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanNotasPesagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gNfPesagem);
            Utils.ShapeGrid.SaveShape(this, gNFItens);
        }
    }
}
