using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using Componentes;
using CamadaDados.Financeiro.Cadastros;

namespace NumeroNota
{
    public partial class TFNumero_Nota : Form
    {
        public string pCd_movto
        { get; set; }
        public string pCd_cmi
        { get; set; }
        public string pNr_serie
        { get; set; }
        public string pDs_serie
        { get; set; }
        public string pCd_modelo
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        private string ptp_nota;
        public string pTp_nota
        {
            get { return ptp_nota; }
            set { ptp_nota = value; }
        }
        public string pTp_movimento
        { get; set; }
        public string pTp_pessoa
        { get; set; }
        public string pNr_notafiscal
        { get; set; }
        public string pChave_Acesso_NFe
        { get; set; }
        public bool pSt_sequenciaauto
        { get; set; }
        public string pDs_obsfiscal
        { get; set; }
        public string pDs_dadosadic
        { get; set; }
        public DateTime? pDt_emissao
        { get; set; }
        public DateTime? pDt_saient
        { get; set; }
        public bool pST_NotaUnica { get; set; }
        public string pInsc_estadual
        { get; set; }
        public string pCd_transportadora
        { get; set; }
        public string pNm_transportadora
        { get; set; }
        public string pCd_endtransportadora
        { get; set; }
        public string pCnpjCpfTransp
        { get; set; }
        public string pPlacaVeiculo
        { get; set; }
        public string pTp_frete
        { get; set; }
        public string pEspecie
        { get; set; }
        public decimal pQuantidade
        { get; set; }
        public decimal pPsbruto
        { get; set; }
        public decimal pPsliquido
        { get; set; }
        public decimal pVl_frete
        { get; set; }
        public string pCd_municipioexecservico
        { get; set; }
        public string pNm_municipioexecservico
        { get; set; }
        public string pCd_ufsaidaex
        { get; set; }
        public string pDs_ufsaidaex
        { get; set; }
        public string pUf_saidaex
        { get; set; }
        public string pDs_localex
        { get; set; }
        public bool pSt_servico
        { get; set; }

        public TFNumero_Nota()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("PROPRIA", "P"));
            cbx.Add(new TDataCombo("TERCEIRO", "T"));
            tp_nota.DataSource = cbx;
            tp_nota.DisplayMember = "Display";
            tp_nota.ValueMember = "Value";

            System.Collections.ArrayList cBox2 = new System.Collections.ArrayList();
            cBox2.Add(new TDataCombo("EMITENTE", "0"));
            cBox2.Add(new TDataCombo("DESTINATARIO", "1"));
            cBox2.Add(new TDataCombo("TERCEIRO", "2"));
            cBox2.Add(new TDataCombo("SEM FRETE", "9"));
            freteporconta.DataSource = cBox2;
            freteporconta.DisplayMember = "Display";
            freteporconta.ValueMember = "Value";

            pCd_movto = string.Empty;
            pCd_cmi = string.Empty;
            pNr_serie = string.Empty;
            pDs_serie = string.Empty;
            pCd_modelo = string.Empty;
            pCd_empresa = string.Empty;
            pNm_empresa = string.Empty;
            pCd_clifor = string.Empty;
            pNm_clifor = string.Empty;
            ptp_nota = string.Empty;
            pTp_movimento = string.Empty;
            pTp_pessoa = string.Empty;
            pNr_notafiscal = string.Empty;
            pChave_Acesso_NFe = string.Empty;
            pSt_sequenciaauto = false;
            pDs_obsfiscal = string.Empty;
            pDs_dadosadic = string.Empty;
            pDt_emissao = null;
            pDt_saient = null;
            pST_NotaUnica = false;
            pInsc_estadual = string.Empty;
            pCd_transportadora = string.Empty;
            pNm_transportadora = string.Empty;
            pCnpjCpfTransp = string.Empty;
            pPlacaVeiculo = string.Empty;
            pTp_frete = "9";
            pEspecie = string.Empty;
            pQuantidade = decimal.Zero;
            pPsbruto = decimal.Zero;
            pPsliquido = decimal.Zero;
            pVl_frete = decimal.Zero;
            pSt_servico = false;
            pCd_municipioexecservico = string.Empty;
            pNm_municipioexecservico = string.Empty;
            pCd_ufsaidaex = string.Empty;
            pDs_ufsaidaex = string.Empty;
            pUf_saidaex = string.Empty;
            pDs_localex = string.Empty;
        }

        private void NotaFiscalExiste()
        {
            if (!string.IsNullOrEmpty(nr_nota.Text))
            {
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento retorno =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(nr_nota.Text,
                                                                                             nr_serie.Text,
                                                                                             cd_empresa.Text,
                                                                                             cd_clifor.Text,
                                                                                             pInsc_estadual,
                                                                                             ptp_nota,
                                                                                             null);
                if (retorno != null)
                    if (retorno.St_registro.Trim().ToUpper().Equals("C"))
                    {
                        if (MessageBox.Show("Nota Fiscal ja existe no sistema com status <CANCELADA>.\r\n" +
                                           "Deseja excluir a nota existente e reutilizar o numero?", "Pergunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.ExcluirNotaFiscal(retorno, null))
                            {
                                nr_nota.Clear();
                                nr_nota.Focus();
                            }
                        }
                        else
                        {
                            nr_nota.Clear();
                            nr_nota.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nota Fiscal ja existe no sistema com status <PROCESSADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nr_nota.Clear();
                        nr_nota.Focus();
                    }
            }
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                TList_CadEndereco lEnd =
                        new TCD_CadEndereco().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_Transp.Text.Trim() + "'"
                                    }
                                }, 0, string.Empty);
                if (lEnd.Count == 1)
                {
                    cd_enderecotransp.Text = lEnd[0].Cd_endereco;
                    ds_enderecotransp.Text = lEnd[0].Ds_endereco;
                }
            }
        }
                        
        private void TFNumero_Nota_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cd_movimentacao.Text = pCd_movto;
            if (!string.IsNullOrEmpty(pCd_movto))
            {
                object obj = new CamadaDados.Fiscal.TCD_CadMovimentacao().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_movimentacao",
                                    vOperador = "=",
                                    vVL_Busca = pCd_movto
                                }
                            }, "a.ds_movimentacao");
                if (obj != null)
                    ds_movimentacao.Text = obj.ToString();
            }
            cd_cmi.Text = pCd_cmi;
            if (!string.IsNullOrEmpty(pCd_cmi))
                cd_cmi_Leave(this, new EventArgs());
            ds_DadosAdicionais.Text = pDs_dadosadic;
            ds_ObservacaoFiscal.Text = pDs_obsfiscal;
            cd_empresa.Text = pCd_empresa;
            nm_empresa.Text = pNm_empresa;
            cd_clifor.Text = pCd_clifor;
            cd_municipioexecservico.Text = pCd_municipioexecservico;
            ds_municipioexecservico.Text = pNm_municipioexecservico;
            cd_ufsaidaex.Text = pCd_ufsaidaex;
            ds_ufsaidaex.Text = pDs_ufsaidaex;
            uf_saidaex.Text = pUf_saidaex;
            ds_localex.Text = pDs_localex;
            nm_clifor.Text = pNm_clifor;
            nr_serie.Text = pNr_serie;
            ds_serie.Text = pDs_serie;
            cd_modelo.Text = pCd_modelo;
            tp_nota.SelectedIndex = ptp_nota.Trim().ToUpper().Equals("P") ? 0 : ptp_nota.Trim().ToUpper().Equals("T") ? 1 : -1;
            tp_movimento.Text = pTp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : pTp_movimento.Trim().ToUpper().Equals("S") ? "SAIDA" : pTp_movimento.Trim().ToUpper();
            tp_pessoa.Text = pTp_pessoa.Trim().ToUpper().Equals("FISICA") ? "F" : pTp_pessoa.Trim().ToUpper().Equals("JURIDICA") ? "J" : pTp_pessoa.Trim().ToUpper();
            ChaveAcessoNFE.Text = pChave_Acesso_NFe.Trim();
            nr_nota.Text = pNr_notafiscal;
            nr_nota.Enabled = (ptp_nota.Trim().ToUpper().Equals("T") && (string.IsNullOrEmpty(pNr_notafiscal) || pST_NotaUnica)) ||
                                ((!pSt_sequenciaauto) && ptp_nota.Trim().ToUpper().Equals("P"));
            dt_emissao.Text = pDt_emissao != null ? pDt_emissao.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            dt_saient.Text = pDt_saient != null ? pDt_saient.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            CD_Transp.Text = pCd_transportadora;
            NM_RazaoSocialTransp.Text = pNm_transportadora;
            CPF_Transp.Text = pCnpjCpfTransp;
            PlacaVeiculo.Text = pPlacaVeiculo;
            freteporconta.SelectedValue = string.IsNullOrEmpty(pTp_frete) ? "9" : pTp_frete;
            Especie.Text = pEspecie;
            Quantidade.Value = pQuantidade;
            PesoBruto.Value = pPsbruto;
            PesoLiquido.Value = pPsliquido;
            VL_Frete.Value = pVl_frete;
        }

        private void TFNumero_Nota_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pSt_servico && string.IsNullOrEmpty(cd_municipioexecservico.Text))
            {
                MessageBox.Show("Obrigatorio informar municipio execução do serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_municipioexecservico.Focus();
                return;
            }
            if(nr_serie.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar serie da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_serie.Focus();
                return;
            }
            if ((!pSt_sequenciaauto) && string.IsNullOrEmpty(nr_nota.Text))
            {
                MessageBox.Show("Obrigatorio informar numera da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_nota.Focus();
                return;
            }
            if(dt_emissao.Enabled && (dt_emissao.Text.Trim().Equals(string.Empty) || dt_emissao.Text.Trim().Equals("/  /")))
            {
                MessageBox.Show("Obrigtorio informar data de emissão da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_emissao.Focus();
                return;
            }
            if (dt_saient.Enabled && (dt_saient.Text.Trim().Equals(string.Empty) || dt_emissao.Text.Trim().Equals("/  /")))
            {
                MessageBox.Show("Obrigatorio informar data de entrada/saida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_saient.Focus();
                return;
            }
            if (tp_nota.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar tipo nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_nota.Focus();
                return;
            }
            //Verificar se e NFe de Terceiro
            if (cd_modelo.Text.Trim().Equals("55") && tp_nota.SelectedValue.ToString().Trim().ToUpper().Equals("T"))
            {
                if (ChaveAcessoNFE.Text.Trim().Length.Equals(44))
                {
                    if (Estruturas.Mod11(ChaveAcessoNFE.Text.Trim().Substring(0, 43), 9, false, 0).ToString() != ChaveAcessoNFE.Text.Trim().Substring(43, 1))
                    {
                        MessageBox.Show("Chave acesso NFe invalida, verifique e informe novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChaveAcessoNFE.Focus();
                        return;
                    }
                    //Validar serie NFe
                    if (nr_serie.Text.Trim().FormatStringEsquerda(3, '0') != ChaveAcessoNFE.Text.Trim().Substring(22, 3))
                    {
                        MessageBox.Show("Numero serie NFe<" + nr_serie.Text.Trim().FormatStringEsquerda(3, '0') + ">" +
                                        "diferente da serie informada na chave acesso NFe<" + ChaveAcessoNFE.Text.Trim().Substring(22, 3) + ".\r\n" +
                                        "Obrigatorio informar serie correta para gravar NFe.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Validar numero da NFe
                    if (nr_nota.Text.FormatStringEsquerda(9, '0') != ChaveAcessoNFE.Text.Trim().Substring(25, 9))
                    {
                        MessageBox.Show("Numero da NFe<" + nr_nota.Text.FormatStringEsquerda(9, '0') + ">" +
                                        "diferente do numero da NFe informado na chave de acesso<" + ChaveAcessoNFE.Text.Trim().Substring(25, 9) + ".\r\n" +
                                        "Obrigatorio informar numero da NFe correto para gravar nota.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chave de acesso imcompleta. A chave de acesso deve conter 44 caracteres.<Total Caracteres: " + ChaveAcessoNFE.Text.Trim().Length.ToString() + ">",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChaveAcessoNFE.Focus();
                    return;
                }
            }
            pNr_serie = nr_serie.Text;
            pDs_serie = ds_serie.Text;
            pCd_modelo = cd_modelo.Text;
            pNr_notafiscal = nr_nota.Text;
            pChave_Acesso_NFe = ChaveAcessoNFE.Text;
            pCd_cmi = cd_cmi.Text;
            try
            {
                pDt_emissao = Convert.ToDateTime(dt_emissao.Text);
            }
            catch
            { pDt_emissao = CamadaDados.UtilData.Data_Servidor(); }
            try
            {
                pDt_saient = Convert.ToDateTime(dt_saient.Text);
            }
            catch
            { pDt_saient = pDt_emissao; }
            pDs_dadosadic = ds_DadosAdicionais.Text.Trim();
            pDs_obsfiscal = ds_ObservacaoFiscal.Text.Trim();
            pCd_transportadora = CD_Transp.Text;
            pCd_endtransportadora = cd_enderecotransp.Text;
            pNm_transportadora = NM_RazaoSocialTransp.Text;
            pCnpjCpfTransp = CPF_Transp.Text;
            pPlacaVeiculo = PlacaVeiculo.Text;
            pTp_frete = freteporconta.SelectedValue != null ? freteporconta.SelectedValue.ToString() : "9";
            pEspecie = Especie.Text;
            pQuantidade = Quantidade.Value;
            pPsbruto = PesoBruto.Value;
            pPsliquido = PesoLiquido.Value;
            pVl_frete = VL_Frete.Value;
            pCd_municipioexecservico = cd_municipioexecservico.Text;
            pNm_municipioexecservico = ds_municipioexecservico.Text;
            pCd_ufsaidaex = cd_ufsaidaex.Text;
            pDs_ufsaidaex = ds_ufsaidaex.Text;
            pUf_saidaex = uf_saidaex.Text;
            pDs_localex = ds_localex.Text;

            DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.nr_serie|Nº Série|80;" +
                                                       "a.DS_SerieNF|Serie Nota Fiscal|150;" +
                                                       "a.cd_modelo|Cd. Modelo|80"
                                                        , new EditDefault[] { nr_serie, ds_serie, cd_modelo }, 
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), string.Empty);
            if (linha != null)
                pSt_sequenciaauto = linha["st_sequenciaauto"].ToString().Trim().ToUpper().Equals("S");
            nr_nota.Enabled = ((ptp_nota.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(pNr_notafiscal)) ||
                            ((!pSt_sequenciaauto) && ptp_nota.Trim().ToUpper().Equals("P")) || pST_NotaUnica);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vColunas += ";a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { nr_serie, ds_serie, cd_modelo },
                                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
            if (linha != null)
                pSt_sequenciaauto = linha["st_sequenciaauto"].ToString().Trim().ToUpper().Equals("S");
            else
                pCd_modelo = string.Empty;
            nr_nota.Enabled = ((ptp_nota.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(pNr_notafiscal)) ||
                                ((!pSt_sequenciaauto) && ptp_nota.Trim().ToUpper().Equals("P")) || pST_NotaUnica);
        }

        private void bb_Obs_busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_ObservacaoFiscal|Observação Fiscal|300;cd_ObservacaoFiscal|Cód. Obs. Fiscal|90"
                           , new EditDefault[] { cd_Obs_busca }, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), string.Empty);
            cd_Obs_busca_Leave(this, e);
        }

        private void cd_Obs_busca_Leave(object sender, EventArgs e)
        {
            DataRow LINHA = UtilPesquisa.EDIT_LEAVE("cd_ObservacaoFiscal|=|'" + cd_Obs_busca.Text + "'"
                            , new EditDefault[] { cd_Obs_busca }, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal());
            if (LINHA != null)
            {
                if (tcObsFiscal.SelectedTab.Equals(tabObs))
                    if (ds_ObservacaoFiscal.Text.Trim().Equals(string.Empty))
                        ds_ObservacaoFiscal.Text = LINHA["ds_observacaofiscal"].ToString();
                    else
                        ds_ObservacaoFiscal.Text += "\r\n" + LINHA["ds_observacaofiscal"].ToString();
                else if (tcObsFiscal.SelectedTab.Equals(tabDados))
                    if (ds_DadosAdicionais.Text.Trim().Equals(string.Empty))
                        ds_DadosAdicionais.Text = LINHA["ds_observacaofiscal"].ToString();
                    else
                        ds_DadosAdicionais.Text += "\r\n" + LINHA["ds_observacaofiscal"].ToString();
            }
        }

        private void tcObsFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcObsFiscal.SelectedTab.Equals(tabDados))
                lblObsFiscal.Text = "Dados Adic.:";
            else if (tcObsFiscal.SelectedTab.Equals(tabObs))
                lblObsFiscal.Text = "Obs. Fiscal:";
        }

        private void nr_nota_Leave(object sender, EventArgs e)
        {
            NotaFiscalExiste();
        }

        private void dt_emissao_Leave(object sender, EventArgs e)
        {
            if (dt_saient.Text.Trim().Equals(string.Empty) || dt_saient.Text.Trim().Equals("/  /"))
                dt_saient.Text = dt_emissao.Text;
        }

        private void bb_cmi_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                              "a.CD_CMI|Cód. CMI|100";
            string vParam = "f.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_cmi, ds_cmi },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"), vParam);
        }

        private void cd_cmi_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CMI|=|'" + cd_cmi.Text + "';" +
                              "f.CD_Movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_cmi, ds_cmi },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
        }

        private void tp_nota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_nota.SelectedValue != null)
            {
                ptp_nota = tp_nota.SelectedValue.ToString();
                if (tp_nota.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                {
                    nr_nota.Clear();
                    dt_emissao.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss");
                    dt_emissao.Enabled = false;
                }
                ChaveAcessoNFE.Enabled = tp_nota.SelectedValue.ToString().Trim().ToUpper().Equals("T");
                nr_nota.Enabled = ((ptp_nota.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(pNr_notafiscal)) ||
                                ((!pSt_sequenciaauto) && ptp_nota.Trim().ToUpper().Equals("P")) || pST_NotaUnica);
            }
        }

        private void bb_trasnp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;NR_CGC_CPF|CNPJ/CPF|100"
                , new EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor(), string.Empty);
            BuscarEndereco();
        }

        private void CD_Transp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'"
                , new EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor());
            BuscarEndereco();
        }

        private void CD_Transp_TextChanged(object sender, EventArgs e)
        {
            NM_RazaoSocialTransp.Enabled = string.IsNullOrEmpty(CD_Transp.Text);
        }

        private void CPF_Transp_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CPF_Transp.Text))
            {
                if (CPF_Transp.Text.Trim().Length.Equals(11) ||
                    (CPF_Transp.Text.Trim().Length.Equals(14) &&
                    CPF_Transp.Text.Trim().Contains('.')))
                {
                    CPF_Valido.nr_CPF = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                    {
                        MessageBox.Show("CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CPF_Transp.Clear();
                    }
                }
                else if (CPF_Transp.Text.Trim().Length >= 14)
                {
                    CNPJ_Valido.nr_CNPJ = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
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

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + "';a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'"
               , new EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco());
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150"
                               , new EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'");
        }

        private void cd_modelo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(nr_serie.Text))
                vColunas += ";|EXISTS|(select 1 from tb_fat_serienf x " +
                                "where x.cd_modelo = a.cd_modelo "+
                                "and x.nr_serie = '" + nr_serie.Text+"')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_modelo},
                                                    new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF());
        }

        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|150;" +
                              "a.cd_modelo|Codigo|50";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), string.Empty);
        }

        private void cd_municipioexecservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipioexecservico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new TCD_CadCidade());
        }

        private void bb_municipioexecservico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Municipio|200;" +
                             "a.cd_cidade|Cd. Municipio|80;" +
                             "a.distrito|Distrito|100;" +
                             "a.uf|UF|20;" +
                             "a.sg_uf|Estado|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new TCD_CadCidade(), string.Empty);
        }

        private void bb_ufsaidaex_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_uf|Cd. UF|60;" +
                             "a.uf|Sigla|60;" +
                             "a.ds_uf|Estado|150";
            string vParam = "a.cd_uf|<>|'99'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_ufsaidaex, ds_ufsaidaex, uf_saidaex }, new TCD_CadUf(), vParam);
        }

        private void cd_ufsaidaex_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_ufsaidaex.Text.Trim() + "';" +
                           "a.cd_uf|<>|'99'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_ufsaidaex, ds_ufsaidaex, uf_saidaex }, new TCD_CadUf());
        }
    }
}
