using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Faturamento.NotaFiscal;
using Componentes;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Faturamento.NotaFiscal;
using Utils;
using System.Collections;

namespace Proc_Commoditties
{
    public partial class TFCorrecaoNota : Form
    {
        public TTpModo vTP_Modo;
        private TRegistro_LanFaturamento rFaturamento;
        public TRegistro_LanFaturamento rfaturamento 
        {
            get
            {
                if (bsNotaFiscal.Current != null)
                    return bsNotaFiscal.Current as TRegistro_LanFaturamento;
                else
                    return null;
            }
            set
            { rFaturamento = value; }
        }

        public TFCorrecaoNota()
        {
            InitializeComponent();

            ArrayList cBox = new ArrayList();
            cBox.Add(new TDataCombo("EMITENTE", "0"));
            cBox.Add(new TDataCombo("DESTINATARIO", "1"));
            cBox.Add(new TDataCombo("TERCEIRO", "2"));
            cBox.Add(new TDataCombo("SEM FRETE", "9"));
            freteporconta.DataSource = cBox;
            freteporconta.DisplayMember = "Display";
            freteporconta.ValueMember = "Value";

            ArrayList cBox1 = new ArrayList();
            cBox1.Add(new TDataCombo("PROPRIA", "P"));
            cBox1.Add(new TDataCombo("TERCEIRO", "T"));
            tp_nota.DataSource = cBox1;
            tp_nota.DisplayMember = "Display";
            tp_nota.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDadosNota.validarCampoObrigatorio() && pDadosFrete.validarCampoObrigatorio())
            {
                if (nr_notafiscal.Focused)
                {
                    if (nr_notafiscal.TextOld.Trim() != nr_notafiscal.Text.Trim())
                        if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(nr_notafiscal.Text,
                                                                                                     NR_Serie.Text,
                                                                                                     rFaturamento.Cd_empresa,
                                                                                                     rFaturamento.Cd_clifor,
                                                                                                     rFaturamento.Insc_estadualclifor,
                                                                                                     rFaturamento.Tp_nota,
                                                                                                     null) != null)
                        {
                            MessageBox.Show("Numero Nota Fiscal ja existe no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nr_notafiscal.Text = nr_notafiscal.TextOld;
                            nr_notafiscal.Focus();
                            return;
                        }
                }
                //Verificar se e NFe de Terceiro
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                {
                    if (ChaveAcessoNFE.Text.Trim().Length.Equals(44))
                    {
                        if (Estruturas.Mod11(ChaveAcessoNFE.Text.Trim().Substring(0, 43), 9, false, 0).ToString() != ChaveAcessoNFE.Text.Trim().Substring(43, 1))
                        {
                            MessageBox.Show("Chave acesso NFe invalida, verifique e informe novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChaveAcessoNFE.Focus();
                            return;
                        }
                        //Validar UF do Emitente
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim() != ChaveAcessoNFE.Text.Trim().Substring(0, 2))
                        {
                            MessageBox.Show("Estado do Fornecedor <" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim() + ">" +
                                            "diferente do estado informado na chave de acesso da NFe<" + ChaveAcessoNFE.Text.Trim().Substring(0, 2) + ".\r\n" +
                                            "Necessario corrigir o cadastro do fornecedor para gravar a NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar CNPJ
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_cgc_cpf.Trim().SoNumero() != ChaveAcessoNFE.Text.Trim().Substring(6, 14))
                        {
                            MessageBox.Show("CNPJ/CPF do Fornecedor<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_cgc_cpf.Trim() + ">" +
                                            "diferente do CNPJ/CPF informado na chave de acesso da NFe<" + ChaveAcessoNFE.Text.Trim().Substring(6, 14) + ".\r\n" +
                                            "Necessario corrigir o cadastro do fornecedor para gravar a NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar Modelo Documento Fiscal
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().FormatStringEsquerda(2, '0') != ChaveAcessoNFE.Text.Trim().Substring(20, 2))
                        {
                            MessageBox.Show("Modelo Documento Fiscal<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().FormatStringEsquerda(2, '0') + ">" +
                                            "diferente do modelo informado na chave acesso NFe<" + ChaveAcessoNFE.Text.Trim().Substring(20, 2) + ".\r\n" +
                                            "Necessario corrigir modelo informado para gravar NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar serie NFe
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim().FormatStringEsquerda(3, '0') != ChaveAcessoNFE.Text.Trim().Substring(22, 3))
                        {
                            MessageBox.Show("Numero serie NFe<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim().FormatStringEsquerda(3, '0') + ">" +
                                            "diferente da serie informada na chave acesso NFe<" + ChaveAcessoNFE.Text.Trim().Substring(22, 3) + ".\r\n" +
                                            "Obrigatorio informar serie correta para gravar NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar numero da NFe
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString().FormatStringEsquerda(9, '0') != ChaveAcessoNFE.Text.Trim().Substring(25, 9))
                        {
                            MessageBox.Show("Numero da NFe<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString().FormatStringEsquerda(9, '0') + ">" +
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
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TotalizarNota()
        {
            if (bsNotaFiscal.Current != null)
            {
                vl_totalbasecalc.Value = TCN_LanFaturamento.CalcTotalBaseCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalicms.Value = TCN_LanFaturamento.CalcTotalICMS(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalipi.Value = TCN_LanFaturamento.CalcTotalIPI(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_total_impcalc.Value = TCN_LanFaturamento.CalcTotalImpCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalimpret.Value = TCN_LanFaturamento.CalcTotalImpRet(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalitens.Value = TCN_LanFaturamento.CalcTotalProdServ(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalnota.Value = TCN_LanFaturamento.CalcTotalNota(bsNotaFiscal.Current as TRegistro_LanFaturamento);
            }
        }

        private void afterCancela()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cancela_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void FCorrecaoNota_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            pDadosNota.set_FormatZero();
            pDadosFrete.set_FormatZero();
            pEx.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rFaturamento != null)
            {
                bsNotaFiscal.DataSource = new TList_RegLanFaturamento() { rFaturamento };
                ChaveAcessoNFE.Enabled = rFaturamento.Tp_nota.Trim().ToUpper().Equals("T");
                nr_rps.Enabled = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_serie",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rFaturamento.Nr_serie.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_modelo",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rFaturamento.Cd_modelo.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_serie",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, "1") != null;
                cd_municipioexecservico.Enabled = nr_rps.Enabled;
                bb_municipioexecservico.Enabled = nr_rps.Enabled;
            }
            //Totalizar Nota
            this.TotalizarNota();
        }

        private void BB_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Movto, DS_Movto },
                                   new CamadaDados.Fiscal.TCD_CadMovimentacao(),
                                   "a.tp_movimento|=|'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper() + "'");
            if ((!string.IsNullOrEmpty(CD_Movto.Text)) && bsItensNota.Count > 0)
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                    {
                        //Procurar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(CD_Movto.Text,
                                                                           p.Cd_condfiscal_produto,
                                                                           cd_uf_clifor.Text.Trim().Equals("99") ? "I" :
                                                                           cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "D" : "F",
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           ref rCfop,
                                                                           null))
                        {
                            p.Cd_cfop = rCfop.CD_CFOP;
                            p.Ds_cfop = rCfop.DS_CFOP;
                            p.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                    });
        }

        private void CD_Movto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|'" + CD_Movto.Text.Trim() + "';" +
                            "a.tp_movimento|=|'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] {CD_Movto, DS_Movto},
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
            if ((!string.IsNullOrEmpty(CD_Movto.Text)) && bsItensNota.Count > 0)
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                {
                    //Procurar cfop do item
                    CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                    if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(CD_Movto.Text,
                                                                       p.Cd_condfiscal_produto,
                                                                       cd_uf_clifor.Text.Trim().Equals("99") ? "I" : cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "D" : "F",
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       ref rCfop,
                                                                       null))
                    {
                        p.Cd_cfop = rCfop.CD_CFOP;
                        p.Ds_cfop = rCfop.DS_CFOP;
                        p.St_bonificacao = rCfop.St_bonificacaobool;
                    }
                });
        }

        private void BB_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "a.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80;" +
                              "b.DS_Modelo|Descrição Modelo|350;" +
                              "a.tp_docto|TP. Docto|80;" +
                              "d.ds_tpdocto|Tipo Documento|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Serie, cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), string.Empty);
        }

        private void BB_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|400;" +
                              "a.cd_modelo|Cd. Modelo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_modelo, ds_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), string.Empty);
        }
                
        private void bb_trasnp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;NR_CGC_CPF|CNPJ/CPF|100",
                                    new Componentes.EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor(), "isnull(a.st_transportadora, 'N')|=|'S'"); 
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150"
                               , new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'");
        }

        private void CD_Transp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'"
                , new Componentes.EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor());
        }

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + "';a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco());
        }

        private void cd_modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_modelo, ds_modelo }, new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF());
        }

        private void NR_Serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|=|'" + NR_Serie.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas , new EditDefault[] { NR_Serie, cd_modelo, ds_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void TFCorrecaoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.afterCancela();
        }

        private void bb_cfop_item_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cfop|CFOP|200;" +
                              "a.cd_cfop|Nº CFOP|80";
            string vParam = string.Empty;
            if (tp_movimento.Text.Trim().ToUpper().Equals("ENTRADA"))
                if (cd_uf_clifor.Text.Trim().Equals("99"))
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'";
                else if (UF_Cliente.Text.Trim().ToUpper().Equals(UF_EMPRESA.Text.Trim().ToUpper()))
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'";
                else
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'";
            else if (tp_movimento.Text.Trim().ToUpper().Equals("SAIDA"))
                if (UF_Cliente.Text.Trim().Equals("99"))
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'";
                else if (UF_Cliente.Text.Trim().ToUpper().Equals(UF_EMPRESA.Text.Trim().ToUpper()))
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'";
                else
                    vParam = "SUBSTRING(a.CD_CFOP, 1, 1)|=|'6'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cfop_item },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void cfop_item_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cfop|=|'" + cfop_item.Text.Trim() + "'";
            if (tp_movimento.Text.Trim().ToUpper().Equals("ENTRADA"))
                if (cd_uf_clifor.Text.Trim().Equals("99"))
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'";
                else if (UF_Cliente.Text.Trim().ToUpper().Equals(UF_EMPRESA.Text.Trim().ToUpper()))
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'";
                else
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'";
            else if (tp_movimento.Text.Trim().ToUpper().Equals("SAIDA"))
                if (cd_uf_clifor.Text.Trim().Equals("99"))
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'";
                else if (UF_Cliente.Text.Trim().ToUpper().Equals(UF_EMPRESA.Text.Trim().ToUpper()))
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'";
                else
                    vParam += ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'6'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cfop_item },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void TFCorrecaoNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }

        private void bb_obs_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("ds_ObservacaoFiscal|Observação Fiscal|300;cd_ObservacaoFiscal|Cód. Obs. Fiscal|90"
                                                      , null, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), null);

            if (linha != null)
            {
                if (tcObsFiscal.SelectedTab.Equals(tabObs))
                    if (ds_ObservacaoFiscal.Text.Trim().Equals(string.Empty))
                        ds_ObservacaoFiscal.Text = linha["ds_observacaofiscal"].ToString();
                    else
                        ds_ObservacaoFiscal.Text += "\r\n" + linha["ds_observacaofiscal"].ToString();
                else if (tcObsFiscal.SelectedTab.Equals(tabDados))
                    if (ds_DadosAdicionais.Text.Trim().Equals(string.Empty))
                        ds_DadosAdicionais.Text = linha["ds_observacaofiscal"].ToString();
                    else
                        ds_DadosAdicionais.Text += "\r\n" + linha["ds_observacaofiscal"].ToString();
            }
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

        private void cd_municipioexecservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipioexecservico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new TCD_CadCidade());
        }

        private void nr_notafiscal_Leave(object sender, EventArgs e)
        {
            if (nr_notafiscal.TextOld.Trim() != nr_notafiscal.Text.Trim())
                if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(nr_notafiscal.Text,
                                                                                             NR_Serie.Text,
                                                                                             rFaturamento.Cd_empresa,
                                                                                             rFaturamento.Cd_clifor,
                                                                                             rFaturamento.Insc_estadualclifor,
                                                                                             rFaturamento.Tp_nota,
                                                                                             null) != null)
                {
                    MessageBox.Show("Numero Nota Fiscal ja existe no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_notafiscal.Text = nr_notafiscal.TextOld;
                    nr_notafiscal.Focus();
                }
        }

        private void nr_notafiscal_Enter(object sender, EventArgs e)
        {
            nr_notafiscal.TextOld = nr_notafiscal.Text;
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent }, "a.cd_clifor|=|'" + CD_Clifor.Text + "';isnull(a.st_endentrega, 'N')|=|'S'");
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
