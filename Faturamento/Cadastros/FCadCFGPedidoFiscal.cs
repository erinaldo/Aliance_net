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
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Fiscal;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGPedidoFiscal : FormCadPadrao.FFormCadPadrao
    {
        private bool St_vincularcf = false;
        private bool St_valoresfixos = false;
        private bool St_commoditties = false;
        public bool St_gerarfin = false;
        public bool st_maximizar = true;
        public string pTp_fiscal
        { get; set; }
        public string pCfg_pedido
        { get; set; }

        public TFCadCFGPedidoFiscal()
        {
            InitializeComponent();
            DTS = bsCFGPedidoFiscal;
            CD_CMI.Enabled = false;
            BB_CMI.Enabled = false;
            this.pTp_fiscal = string.Empty;
            this.pCfg_pedido = string.Empty;

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO NORMAL", "NO"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE COMPLEMENTO", "CP"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE DEVOLUÇÃO/RETORNO", "DV"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE ENTREGA FUTURA", "FT"));
            cbx1.Add(new Utils.TDataCombo("TRANSFERENCIA ENTRE CONTRATOS", "TF"));
            cbx1.Add(new Utils.TDataCombo("COMPLEMENTO FISCAL", "CF"));
            cbx1.Add(new Utils.TDataCombo("DEVOLUÇÃO FISCAL", "DF"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO SERVIÇO", "SE"));
            cbx1.Add(new Utils.TDataCombo("REMESSA TRANSPORTE", "RT"));

            Cbx_TP_Fiscal.DataSource = cbx1;
            Cbx_TP_Fiscal.DisplayMember = "Display";
            Cbx_TP_Fiscal.ValueMember = "Value";
            Cbx_TP_Fiscal.SelectedValue = "";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return TCN_CadCFGPedidoFiscal.Gravar(bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal, null);
            }
            else
                return "";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override int buscarRegistros()
        {
            TList_CadCFGPedidoFiscal lista = TCN_CadCFGPedidoFiscal.Buscar(  CFG_Pedido.Text.Trim(), 
                                                                             Cbx_TP_Fiscal.SelectedValue != null ? Cbx_TP_Fiscal.SelectedValue.ToString().Trim() : "",
                                                                             Nr_Serie.Text,
                                                                             CD_CMI.Text.Trim() != "" ? Convert.ToDecimal(CD_CMI.Text) : 0,
                                                                             CD_Movto.Text.Trim() != "" ? Convert.ToDecimal(CD_Movto.Text) : 0,
                                                                              0, "", null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGPedidoFiscal.DataSource = lista;
                    bsCFGPedidoFiscal_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCFGPedidoFiscal.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            { 
                bsCFGPedidoFiscal.AddNew();
                base.afterNovo();
                Cbx_TP_Fiscal.Focus();
            }
            CD_CMI.Enabled = false;
            BB_CMI.Enabled = false;
        }

        public override void afterCancela()
        {
            pDados.LimparRegistro();
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCFGPedidoFiscal.RemoveCurrent();

            CD_CMI.Enabled = false;
            BB_CMI.Enabled = false;

            
        }

        public override void afterAltera()
        {
            
            base.afterAltera();
            Cbx_TP_Fiscal.Enabled = false;
            BB_CFG_Pedido.Enabled = false;
            CFG_Pedido.Enabled = false;
            Nr_Serie.Focus();
            if (!string.IsNullOrEmpty(CD_Movto.Text))
            {
                CD_CMI.Enabled = true;
                BB_CMI.Enabled = true;
            }
            else
            {
                CD_CMI.Enabled = false;
                BB_CMI.Enabled = false;
            }
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido lCfgPed =
                CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedido.Buscar(CFG_Pedido.Text,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            decimal.Zero,
                                                                            1,
                                                                            string.Empty,
                                                                            null);
            if (lCfgPed.Count > 0)
            {
                St_valoresfixos = lCfgPed[0].St_valoresfixosbool;
                St_commoditties = lCfgPed[0].St_commodittiesbool;
                St_gerarfin = lCfgPed[0].St_gerarfinbool;
            }
        }

        public override void afterExclui()
        {
            if (bsCFGPedidoFiscal.Current != null)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadCFGPedidoFiscal.Excluir(bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal, null);
                        bsCFGPedidoFiscal.Clear();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void BB_CFG_Pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|Configuração Pedido|350;" +
                              "CFG_Pedido|Cód. Configuração Pedido|100;" +
                              "TP_Movimento| Tipo Movimento |100;" +
                              "ST_Servico|Pedido Serviço|80";

            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CFG_Pedido, DS_TipoPedido, TP_Movimento },
                                                        new TCD_CadCFGPedido(), string.Empty);
            if (linha != null)
            {
                St_valoresfixos = linha["ST_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                St_commoditties = linha["ST_Commoditties"].ToString().Trim().ToUpper().Equals("S");
                St_vincularcf = linha["st_vincularcf"].ToString().Trim().ToUpper().Equals("S");
                St_gerarfin = linha["st_gerarfin"].ToString().Trim().ToUpper().Equals("S");
                st_servico.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                Nr_Serie.Clear();
                DS_Serie.Clear();
            }
            if (!string.IsNullOrEmpty(CD_Movto.Text))
            {
                
                CD_CMI.Clear();
                DS_CMI.Clear();
                CD_Movto.Clear();
                DS_Movto.Clear();
            }
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vColunas = "cfg_pedido|=|'" + CFG_Pedido.Text.Trim() + "'";
           
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CFG_Pedido, DS_TipoPedido, TP_Movimento },
                                                    new TCD_CadCFGPedido());
            if (linha != null)
            {
                St_valoresfixos = linha["ST_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                St_commoditties = linha["ST_Commoditties"].ToString().Trim().ToUpper().Equals("S");
                St_vincularcf = linha["st_vincularcf"].ToString().Trim().ToUpper().Equals("S");
                St_gerarfin = linha["st_gerarfin"].ToString().Trim().ToUpper().Equals("S");
                st_servico.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                Nr_Serie.Clear();
                DS_Serie.Clear();
            }
            if (!string.IsNullOrEmpty(CD_Movto.Text))
            {
                CD_CMI.Clear();
                DS_CMI.Clear();
                CD_Movto.Clear();
                DS_Movto.Clear();
            }
        }
                
        private void BB_Serie_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_SerieNF|Série |350;" +
                              "Nr_Serie|Cód. Série |100;" +
                              "Cd_modelo|Cód. Modelo|100;" +
                              "b.ds_modelo|Modelo NF|100";
            string vParam = string.Empty;
            if (st_servico.Checked)
                vParam = "tp_serie|in|('S', 'M')";
            else
                vParam = "tp_serie|<>|'S'";
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vParam += ";a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_Serie, DS_Serie, cd_modelo, ds_modelo },
                                    new TCD_CadSerieNF(), vParam);
        }

        private void Nr_Serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "nr_serie|=|'" + Nr_Serie.Text.Trim() + "'";
            if (st_servico.Checked)
                vColunas += ";tp_serie|in|('S', 'M')";
            else
                vColunas += ";tp_serie|<>|'S'";
            if (!string.IsNullOrEmpty(cd_modelo.Text))
                vColunas += ";a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_Serie, DS_Serie, cd_modelo, ds_modelo },
                                    new TCD_CadSerieNF());
        }

        private void BB_Movto_Click(object sender, EventArgs e)
        {
                string vcond = string.Empty;
                if (TP_Movimento.Text.Trim().ToUpper().Equals("E"))
                    vcond = "a.Tp_Movimento|=|'E'"; 
                else if (TP_Movimento.Text.Trim().ToUpper().Equals("S"))
                    vcond = "a.Tp_Movimento|=|'S'";
                if (Cbx_TP_Fiscal.SelectedValue == null)
                    Cbx_TP_Fiscal.SelectedValue = "NO";
                if(((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
                    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("E"))))
                    vcond = "a.Tp_Movimento|=|'S'";
                if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
                    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("S"))))
                    vcond = "a.Tp_Movimento|=|'E'";
                if (!string.IsNullOrEmpty(CD_CMI.Text))
                    vcond += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                             "          where x.cd_movimentacao = a.cd_movimentacao " +
                             "          and x.cd_cmi = " + CD_CMI.Text + ")";

                string vColunas = "DS_Movimentacao|Movimentação|350;" +
                                  "CD_Movimentacao|Cód. Movimentação|100";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movto, DS_Movto },
                                        new TCD_CadMovimentacao(), vcond);
        }

        private void CD_Movto_Leave(object sender, EventArgs e)
        {
            string vcond = "";
            if (TP_Movimento.Text == "S")
                vcond = "a.Tp_Movimento|=|'S'";
            if (TP_Movimento.Text == "E")
                vcond = "a.Tp_Movimento|=|'E'";
            if (Cbx_TP_Fiscal.SelectedValue == null)
                Cbx_TP_Fiscal.SelectedValue = "NO";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("E"))))
                vcond = "a.Tp_Movimento|=|'S'";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("S"))))
                vcond = "a.Tp_Movimento|=|'E'";

            string vColunas = CD_Movto.NM_CampoBusca + "|=|'" + CD_Movto.Text.Trim() + "'";
            if (vcond != "")
                vColunas = vColunas + ";" + vcond;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Movto, DS_Movto },
                                    new TCD_CadMovimentacao());
        }

        private void BB_CMI_Click(object sender, EventArgs e)
        {
            string vcond = string.Empty;

            //if (TP_Movimento.Text.Trim().ToUpper().Equals("E"))
            //    vcond = "a.Tp_Movimento|=|'E'";
            //if (TP_Movimento.Text.Trim().ToUpper().Equals("S"))
            //    vcond = "a.Tp_Movimento|=|'S'";

            //if (Cbx_TP_Fiscal.SelectedValue == null)
            //    Cbx_TP_Fiscal.SelectedValue = "NO";

            //if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
            //        Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("E"))))
            //    vcond = "a.Tp_Movimento|=|'S';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";

            //if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
            //    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("S"))))
            //    vcond = "a.Tp_Movimento|=|'E';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";

            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CP"))
            //    vcond += ";isnull(a.ST_Complementar, 'N')|=|'S'";

            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CF"))
            //    vcond += ";||isnull(a.ST_CompDevImposto, 'N') = 'S' or isnull(a.ST_Complementar, 'N') = 'S'";

            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("FT"))
            //    vcond += ";isnull(a.ST_Mestra, 'N')|=|'S'";

            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("NO"))
            //    vcond += ";||isnull(a.ST_Devolucao, 'N') <> 'S' and isnull(a.ST_Retorno, 'N') <> 'S' and isnull(a.ST_Complementar, 'N') <> 'S' and isnull(a.ST_Mestra, 'N') <> 'S'";

            //if (((!St_valoresfixos) && St_commoditties) || St_gerarfin)//Contratos de graos a fixar nao pode gerar financeiro
            //    vcond += ";a.tp_duplicata|is|null";

            //if (St_vincularcf)
            //    vcond += ";isnull(a.st_geraestoque, 'N')|<>|'S'";

            vcond = "f.cd_movimentacao|=|" + CD_Movto.Text +
                (string.IsNullOrEmpty(vcond) ? string.Empty : ";" + vcond.Trim());

            string vColunas = "DS_CMI|Descrição CMI|350;" +
                              "CD_CMI|Cód. CMI|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, DS_CMI },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"), vcond);
        }

        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            string vcond = string.Empty;

            //if (TP_Movimento.Text == "E")
            //    vcond = "a.Tp_Movimento|=|'E'";
            //if (TP_Movimento.Text == "S")
            //    vcond = "a.Tp_Movimento|=|'S'";
            //if (Cbx_TP_Fiscal.SelectedValue == null)
            //    Cbx_TP_Fiscal.SelectedValue = "NO";
            //if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
            //    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("E"))))
            //    vcond = "a.Tp_Movimento|=|'S';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            //if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") || 
            //    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (TP_Movimento.Text.Trim().ToUpper().Equals("S"))))
            //    vcond = "a.Tp_Movimento|=|'E';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CP"))
            //    vcond += ";isnull(a.ST_Complementar, 'N')|=|'S'";
            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CF"))
            //    vcond += ";||isnull(a.ST_CompDevImposto, 'N') = 'S' or isnull(a.ST_Complementar, 'N') = 'S'";
            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("FT"))
            //    vcond += ";isnull(a.ST_Mestra, 'N')|=|'S'";
            //if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("NO"))
            //    vcond += ";||isnull(a.ST_Devolucao, 'N') <> 'S' and isnull(a.ST_Retorno, 'N') <> 'S' and isnull(a.ST_Complementar, 'N') <> 'S' and isnull(a.ST_Mestra, 'N') <> 'S'";
            //if (((!St_valoresfixos) && St_commoditties) || St_gerarfin)//Contratos de graos a fixar nao pode gerar financeiro
            //    vcond += ";a.tp_duplicata|is|null";
            //if (St_vincularcf)
            //    vcond += ";isnull(a.st_geraestoque, 'N')|<>|'S'";

            vcond = "a.cd_cmi|=|" + CD_CMI.Text + ";" +
                "f.cd_movimentacao|=|" + CD_Movto.Text + (string.IsNullOrEmpty(vcond) ? string.Empty : ";" + vcond.Trim());

            UtilPesquisa.EDIT_LEAVE(vcond, new Componentes.EditDefault[] { CD_CMI, DS_CMI },
                                           new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
        }

        private void Cbx_TP_Fiscal_Leave(object sender, EventArgs e)
        {
            CFG_Pedido.Clear();
            DS_TipoPedido.Clear();
            CFG_Pedido.Focus();
        }

        private void Cbx_TP_Fiscal_Enter(object sender, EventArgs e)
        {
            CFG_Pedido.Clear();
            DS_TipoPedido.Clear();
            CD_CMI.Clear();
            DS_CMI.Clear();
            CD_Movto.Clear();
            DS_Movto.Clear();
        }

        private void CFG_Pedido_Enter(object sender, EventArgs e)
        {
            CD_CMI.Clear();
            DS_CMI.Clear();
            CD_Movto.Clear();
            DS_Movto.Clear();
        }

        private void CD_Movto_Enter(object sender, EventArgs e)
        {
            CD_CMI.Clear();
            DS_CMI.Clear();
        }

        private void TFCadCFGPedidoFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadCFGPedidoFiscal);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            if (st_maximizar)
                this.WindowState = FormWindowState.Maximized;
            else
            {
                //Verificar se nao existe configuracao
                CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedidoFiscal.Buscar(pCfg_pedido,
                                                                                      pTp_fiscal,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null);
                if (lCfg.Count > 0)
                {
                    bsCFGPedidoFiscal.DataSource = lCfg;
                    this.vTP_Modo = TTpModo.tm_busca;
                    this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
                }
                else
                {
                    afterNovo();
                    Cbx_TP_Fiscal.SelectedValue = pTp_fiscal;
                    CFG_Pedido.Text = pCfg_pedido;
                    Nr_Serie.Focus();
                }
            }
        }

        private void CD_Movto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CD_Movto.Text) || (vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                CD_CMI.Enabled = false;
                BB_CMI.Enabled = false;
            }
            else
            {
                CD_CMI.Enabled = true;
                BB_CMI.Enabled = true;
            }
        }

        private void bsCFGPedidoFiscal_PositionChanged(object sender, EventArgs e)
        {
            if (bsCFGPedidoFiscal.Current != null)
            {
                St_commoditties = (bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).St_commoditties;
                St_valoresfixos = (bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).St_valoresfixos;
                St_vincularcf = (bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).St_vincularcf;
                St_gerarfin = (bsCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).St_gerarfin;
            }
        }

        private void TFCadCFGPedidoFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadCFGPedidoFiscal);
        }

        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|200;" +
                              "a.cd_modelo|Cd. Modelo|80";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(Nr_Serie.Text))
                vParam = "|exists|(select 1 from tb_fat_serienf x " +
                         "          where x.cd_modelo = a.cd_modelo " +
                         "          and x.nr_serie = '" + Nr_Serie.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), vParam);
        }

        private void cd_modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            if(!string.IsNullOrEmpty(Nr_Serie.Text))
                vParam += ";|exists|(select 1 from tb_fat_serienf x " +
                          "          where x.cd_modelo = a.cd_modelo " +
                          "          and x.nr_serie = '" + Nr_Serie.Text.Trim() + "')";
        }
    }
}