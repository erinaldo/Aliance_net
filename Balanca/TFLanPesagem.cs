using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados;
using Querys;
using Querys.Financeiro;
using Querys.Fiscal;
using Querys.Graos;
using Querys.Estoque;
using Querys.Diversos;
using Querys.Balanca;
using Querys.LanPesagem;
using FormBusca;

namespace Balanca
{
    struct TEstadoPage
    {
        public string NM_Page;
        public Utils.TTpModo ST_Page;
        public string Placa;
        public string CD_Empresa;
        public string NM_Empresa;
        public decimal ID_Ticket;
        public string TP_Pesagem;
        public string DS_TPPesagem;
        public decimal PS_Balanca;
        public decimal PS_Bruto;
        public decimal PS_Tara;
        public decimal PS_Desconto;
        public decimal PS_Liquido;
        public string NM_Protocolo;
        public string TP_CapturaBruto;
        public string TP_CapturaTara;
        public string DT_Bruto;
        public string DT_Tara;
        public string Login_PSBruto;
        public string Login_PSTara;
        public string vTP_MovDefault;
        public string vOrdemPesagem;
        public string vST_SeqManual;
        public int vIndexTP_Movimento;
    }

    public partial class TFLanPesagem : Form
    {
        #region "Atributos"
        private Utils.TTpModo tpModo;
        private Utils.TTpModo tpModoDesdobro;
        private TEstadoPage[] estadoPage;
        private System.Windows.Forms.TabPage pageAnterior;
        private string vTP_MovDefault;
        private string vOrdemPesagem;
        private string vST_SeqManual;
        #endregion

        #region "Construtor"
        public TFLanPesagem()
        {
            InitializeComponent();
        }
        #endregion

        #region "Métodos Privados"
        private void removerPages(TabControl tab)
        {
            System.Collections.IEnumerator pages = tab.TabPages.GetEnumerator();
            while (pages.MoveNext())
                tab.TabPages.Remove((pages.Current as TabPage));
        }

        private void adicionarPages(TabControl tab)
        {
            if (tab.Equals(tcPesagem))
            {
                TpBusca[] vBusca = new TpBusca[1];
                vBusca[0].vNM_Campo = "a.Login";
                vBusca[0].vVL_Busca = "'" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "'";
                vBusca[0].vOperador = "=";
                TDatUsuarioXTpPesagem qtb_busca = new TDatUsuarioXTpPesagem("SqlCodeBuscaUserXTpPesagem");
                DataTable tabela = qtb_busca.Buscar(vBusca, 0);
                if(tabela != null)
                    for (int i = 0; i < tabela.Rows.Count; i++)
                    {
                        switch (tabela.Rows[i]["TP_Modo"].ToString())
                        {
                            case "G":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemGraos);
                                    break;
                                }
                            case "A":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemAves);
                                    break;
                                }
                            case "R":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemRacao);
                                    break;
                                }
                            case "F":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemFazenda);
                                    break;
                                }
                            case "D":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemDiversos);
                                    break;
                                }
                            case "C":
                                {
                                    tcPesagem.TabPages.Add(tpPesagemCD);
                                    break;
                                }
                        }
                    }
            }
        }

        private string capturaHoraServer()
        {
            TDatValidaSys qtb_sys = new TDatValidaSys();
            return qtb_sys.getHoraServer();
        }

        private bool ticketGravado()
        {
            TpBusca[] vBusca = new TpBusca[3];
            vBusca[0].vNM_Campo = "a.CD_Empresa";
            vBusca[0].vVL_Busca = CD_Empresa.Text;
            vBusca[0].vOperador = "=";
            vBusca[1].vNM_Campo = "a.ID_Ticket";
            vBusca[1].vVL_Busca = ID_Ticket.Value.ToString();
            vBusca[1].vOperador = "=";
            vBusca[2].vNM_Campo = "a.TP_Pesagem";
            vBusca[2].vVL_Busca = TP_Pesagem.Text;
            vBusca[2].vOperador = "=";
            TDatBalPesagem qtb_pesagem = new TDatBalPesagem();
            object obj = qtb_pesagem.BuscarEscalar(vBusca, "1");
            if (obj != null)
                return obj.ToString() != "";
            else
                return false;
        }

        private bool existeClassificacaoTela()
        {
            if (gClassifPsGraos.DataSource != null)
            {
                int cont = (gClassifPsGraos.DataSource as DataTable).Rows.Count;
                for (int i = 0; i < cont; i++)
                    if (Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[i]["PC_Result"].ToString()) > 0)
                        return true;
            }
            return false;
        }

        private void visibleBotoes(bool vNovo, bool vAlterar, bool vGravar,
                                    bool vCancelar, bool vExcluir, bool vImprimir,
                                    bool vCapturaAuto, bool vCapturaManual, bool vBuscar)
        {
            BB_Novo.Visible              = vNovo;
            BB_Alterar.Visible           = vAlterar;
            BB_Gravar.Visible            = vGravar;
            BB_Cancelar.Visible          = vCancelar;
            BB_Excluir.Visible           = vExcluir;
            BB_Imprimir.Visible          = vImprimir;
            BB_CapturaAutomatico.Visible = vCapturaAuto;
            BB_CapturaManual.Visible     = vCapturaManual;
            BB_Buscar.Visible            = vBuscar;
        }

        private void modoBotoes(System.Windows.Forms.TabPage vPage)
        {
            TDatUsuarioXRegraEspecial qtb_regra = new TDatUsuarioXRegraEspecial();
            if ((vPage.Equals(tpPsGraos))||(vPage.Equals(tpPesagemGraos)))
            {
                if (tpModo == TTpModo.tm_Standby)
                    visibleBotoes(true, false, false, false, false, false, false, false, true);
                else if (tpModo == TTpModo.tm_Insert)
                    visibleBotoes(false, false, true, true, false, false, true,
                                        qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR DIGITAR PESO MANUALMENTE"),
                                        false);
                else if (tpModo == TTpModo.tm_Edit)
                    visibleBotoes(false, false, true, true, false, false,
                                        (!((ps_bruto.Value > 0) && (ps_tara.Value > 0))),
                                        ((!((ps_bruto.Value > 0) && (ps_tara.Value > 0)))
                                        && (qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR DIGITAR PESO MANUALMENTE"))),
                                        false);
                else if (tpModo == TTpModo.tm_busca)
                    visibleBotoes(true, qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR ALTERACAO DE PESAGEM"),
                                        false, true, qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR EXCLUSAO DE PESAGEM"),
                                        true, false, false, true);
            }
            else if (vPage.Equals(tpDesdobroClifor))
            {
                if (tpModoDesdobro == TTpModo.tm_Standby)
                    visibleBotoes(true, false, false, false, false, false, false, false, false);
                else if (tpModoDesdobro == TTpModo.tm_Insert)
                    visibleBotoes(false, false, true, true, false, false, false, false, false);
                else if (tpModoDesdobro == TTpModo.tm_Edit)
                    visibleBotoes(false, false, true, true, true, false, false, false, false);
            }
        }

        private void ativaCampos(System.Windows.Forms.TabPage vPage)
        {
            if (vPage.Equals(tpPsGraos))
            {
                if (tpModo == TTpModo.tm_Standby)
                {
                    pTopEsquerdo.HabilitarControls(false, this.tpModo);
                    pTopDireito.HabilitarControls(false, this.tpModo);
                    pPesagemGraos.HabilitarControls(false, this.tpModo);
                    pDesdobroNF.HabilitarControls(false, this.tpModo);
                }
                else if (tpModo == TTpModo.tm_Insert)
                {
                    placaCarreta.Enabled    = false;
                    BB_PlacaCarreta.Enabled = false;
                    CD_Empresa.Enabled      = true;
                    BB_Empresa.Enabled      = true;
                    TP_Pesagem.Enabled      = true;
                    bb_tppesagem.Enabled    = true;
                    TP_Movimento.Enabled    = true;
                    ID_Ticket.Enabled       = (vST_SeqManual == "S");
                    cbProtocolo.Enabled     = true;
                    pPesagemGraos.HabilitarControls(true, tpModo);
                    cd_transp.Enabled = true;
                    cd_obs.Enabled = true;
                    pClassif.HabilitarControls(true, tpModo);
                }
                else if (tpModo == TTpModo.tm_Edit)
                {
                    pTopEsquerdo.HabilitarControls(false, tpModo);
                    pTopDireito.HabilitarControls(false, tpModo);
                    pPesagemGraos.HabilitarControls(true, tpModo);
                    cd_transp.Enabled = true;
                    cd_obs.Enabled = true;
                    pClassif.HabilitarControls(true, tpModo);
                }
            }
            else if (vPage.Equals(tpDesdobroClifor))
            {
                if (tpModoDesdobro == TTpModo.tm_Standby)
                    pDesdobroNF.HabilitarControls(false, tpModoDesdobro);
                else if ((tpModoDesdobro == TTpModo.tm_Insert)||
                         (tpModoDesdobro == TTpModo.tm_Edit))
                {
                    pDesdobroNF.HabilitarControls(true, tpModoDesdobro);
                    CD_ProdutoClifor.Enabled = CD_ProdutoClifor.Text != "";
                    BB_ProdutoClifor.Enabled = CD_ProdutoClifor.Text != "";
                }
            }
        }

        private void limpaCampos(System.Windows.Forms.TabPage vPage)
        {
            vTP_MovDefault = "";
            vOrdemPesagem  = "";
            vST_SeqManual  = "";
            if (vPage.Equals(tpPsGraos))
            {
                pTopDireito.LimparRegistro();
                pTopEsquerdo.LimparRegistro();
                pPesagemGraos.LimparRegistro();
            }
            else if (vPage.Equals(tpBuscaPsGraos))
                pBuscaPsGraos.LimparRegistro();
            else if (vPage.Equals(tpClassifGraos))
                pClassif.LimparRegistro();
            else if (vPage.Equals(tpDesdobroClifor))
                pDesdobroNF.LimparRegistro();
        }

        private void carregarRegistros(TabPage vPage, DataRow linha, TTpModo vModo)
        {
            if (vPage.Equals(tpPsGraos))
            {
                pTopEsquerdo.CarregarRegistro(linha, vModo);
                pTopDireito.CarregarRegistro(linha, vModo);
                pPesagemGraos.CarregarRegistro(linha, vModo);
                if (linha["TP_Movimento"].ToString() == "E")
                    TP_Movimento.Text = "RECEBIMENTO";
                else if (linha["TP_Movimento"].ToString() == "S")
                    TP_Movimento.Text = "EXPEDIÇÃO";
                else if (linha["TP_Movimento"].ToString() == "T")
                    TP_Movimento.Text = "TROCA NOTAS";
                st_gmo.Checked = linha["ST_GMO"].ToString() == "S";
                ST_GMODeclarado.Checked = linha["ST_GMODeclarado"].ToString() == "S";
            }
        }

        private void salvarPageAnterior()
        {
            if(estadoPage != null)
                for (Int16 i = 0; i < estadoPage.Length; i++)
                {
                    if (estadoPage[i].NM_Page.ToUpper().Equals(pageAnterior.Name.ToUpper()))
                    {
                        estadoPage[i].ST_Page        = tpModo;
                        estadoPage[i].Placa          = placaCarreta.Text;
                        estadoPage[i].CD_Empresa     = CD_Empresa.Text;
                        estadoPage[i].NM_Empresa     = NM_Empresa.Text;
                        estadoPage[i].ID_Ticket      = ID_Ticket.Value;
                        estadoPage[i].TP_Pesagem     = TP_Pesagem.Text;
                        estadoPage[i].DS_TPPesagem   = NM_TpPesagem.Text;
                        estadoPage[i].PS_Balanca     = ps_balanca.Value;
                        estadoPage[i].PS_Bruto       = ps_bruto.Value;
                        estadoPage[i].PS_Tara        = ps_tara.Value;
                        estadoPage[i].PS_Liquido     = ps_liquido.Value;
                        estadoPage[i].NM_Protocolo   = cbProtocolo.Text;
                        estadoPage[i].TP_CapturaBruto= TP_Captura_Bruto.Text;
                        estadoPage[i].TP_CapturaTara = tp_captura_tara.Text;
                        estadoPage[i].DT_Bruto       = dt_bruto.Text;
                        estadoPage[i].DT_Tara        = dt_tara.Text;
                        estadoPage[i].Login_PSBruto  = login_PsBruto.Text;
                        estadoPage[i].Login_PSTara   = login_PsTara.Text;
                        estadoPage[i].vTP_MovDefault = vTP_MovDefault;
                        estadoPage[i].vOrdemPesagem  = vOrdemPesagem;
                        estadoPage[i].vST_SeqManual  = vST_SeqManual;
                        break;
                    }
                }
        }

        private void carregarPageAtual(System.Windows.Forms.TabPage vPage)
        {
            if(estadoPage != null)
                for (Int16 i = 0; i < estadoPage.Length; i++)
                {
                    if (estadoPage[i].NM_Page.ToUpper().Equals(vPage.Name.ToUpper()))
                    {
                        tpModo               = estadoPage[i].ST_Page;
                        placaCarreta.Text    = estadoPage[i].Placa;
                        CD_Empresa.Text      = estadoPage[i].CD_Empresa;
                        NM_Empresa.Text      = estadoPage[i].NM_Empresa;
                        ID_Ticket.Value      = estadoPage[i].ID_Ticket;
                        TP_Pesagem.Text      = estadoPage[i].TP_Pesagem;
                        NM_TpPesagem.Text    = estadoPage[i].DS_TPPesagem;
                        ps_balanca.Value     = estadoPage[i].PS_Balanca;
                        ps_bruto.Value       = estadoPage[i].PS_Bruto;
                        ps_tara.Value        = estadoPage[i].PS_Tara;
                        ps_liquido.Value     = estadoPage[i].PS_Liquido;
                        cbProtocolo.Text     = estadoPage[i].NM_Protocolo;
                        TP_Captura_Bruto.Text= estadoPage[i].TP_CapturaBruto;
                        tp_captura_tara.Text = estadoPage[i].TP_CapturaTara;
                        dt_bruto.Text        = estadoPage[i].DT_Bruto;
                        dt_tara.Text         = estadoPage[i].DT_Tara;
                        login_PsTara.Text    = estadoPage[i].Login_PSTara;
                        login_PsBruto.Text   = estadoPage[i].Login_PSBruto;
                        vTP_MovDefault       = estadoPage[i].vTP_MovDefault;
                        vOrdemPesagem        = estadoPage[i].vOrdemPesagem;
                        vST_SeqManual        = estadoPage[i].vST_SeqManual;
                        TP_Movimento.SelectedIndex = estadoPage[i].vIndexTP_Movimento;
                        break;
                    }
                }
        }

        private void sairPS_Bruto()
        {
            if (ps_bruto.Value < 500)
            {
                if (MessageBox.Show("Peso bruto menor que 500 Kg. Confirma captura mesmo assim?",
                                    "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) ==
                                    System.Windows.Forms.DialogResult.No)
                {
                    ps_bruto.Value = 0;
                    ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                    ps_bruto.Enabled = false;
                    return;
                }
            }
            ps_bruto.Enabled = false;
            ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
            if (TP_Captura_Bruto.Text == "")
                TP_Captura_Bruto.Text = "M";
            dt_bruto.Text = capturaHoraServer();
            login_PsBruto.Text = TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
            if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
            {
                if (ps_bruto.Value > ps_tara.Value)
                {
                    TDatBalClassificacao qtb_classif = new TDatBalClassificacao();
                    qtb_classif.CD_Empresa = CD_Empresa.Text;
                    qtb_classif.ID_Ticket = ID_Ticket.Value;
                    qtb_classif.TP_Pesagem = TP_Pesagem.Text;
                    if (qtb_classif.existeClassificacao())
                    {
                        if (gravarPsGraos(false))
                        {
                            BB_CapturaAutomatico.Enabled = false;
                            BB_CapturaManual.Enabled = false;
                        }
                        else
                        {
                            BB_CapturaAutomatico.Enabled = true;
                            BB_CapturaManual.Enabled = true;
                            return;
                        }
                        ps_desconto.Value = qtb_classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                    }
                    else
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                }
                else
                {
                    if (MessageBox.Show("Peso tara maior que peso bruto...Deseja inverter os pesos e o tipo de movimento?",
                                        "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        decimal aux = ps_bruto.Value;
                        ps_bruto.Value = ps_tara.Value;
                        ps_tara.Value = aux;
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                        if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                            TP_Movimento.Text = "EXPEDIÇÃO";
                        else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                            TP_Movimento.Text = "RECEBIMENTO";
                        TDatBalClassificacao qtb_Classif = new TDatBalClassificacao();
                        qtb_Classif.CD_Empresa = CD_Empresa.Text;
                        qtb_Classif.ID_Ticket = ID_Ticket.Value;
                        qtb_Classif.TP_Pesagem = TP_Pesagem.Text;
                        if (qtb_Classif.existeClassificacao())
                        {
                            ps_desconto.Value = qtb_Classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                            ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                        }
                        else
                            ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                    }
                    else
                        afterCancela();
                }
            }
        }

        private void sairPS_Tara()
        {
            if (ps_tara.Value < 500)
            {
                if (MessageBox.Show("Peso bruto menor que 500 Kg. Confirma captura mesmo assim?",
                                    "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    ps_tara.Value = 0;
                    ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                    ps_tara.Enabled = false;
                    return;
                }
            }
            ps_tara.Enabled = false;
            ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
            if (tp_captura_tara.Text == "")
                tp_captura_tara.Text = "M";
            dt_tara.Text = capturaHoraServer();
            login_PsTara.Text = TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
            if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
            {
                if (ps_bruto.Value > ps_tara.Value)
                {
                    TDatBalClassificacao qtb_classif = new TDatBalClassificacao();
                    qtb_classif.CD_Empresa = CD_Empresa.Text;
                    qtb_classif.ID_Ticket = ID_Ticket.Value;
                    qtb_classif.TP_Pesagem = TP_Pesagem.Text;
                    if (qtb_classif.existeClassificacao())
                    {
                        if (gravarPsGraos(false))
                        {
                            BB_CapturaAutomatico.Enabled = false;
                            BB_CapturaManual.Enabled = false;
                        }
                        else
                        {
                            BB_CapturaAutomatico.Enabled = false;
                            BB_CapturaManual.Enabled = false;
                            return;
                        }
                        ps_desconto.Value = qtb_classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                    }
                    else
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                }
                else
                {
                    if (MessageBox.Show("Peso tara maior que peso bruto...Deseja inverter os pesos e o tipo de movimento?",
                                        "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        decimal aux = ps_bruto.Value;
                        ps_bruto.Value = ps_tara.Value;
                        ps_tara.Value = aux;
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                        if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                            TP_Movimento.Text = "EXPEDIÇÃO";
                        else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                            TP_Movimento.Text = "RECEBIMENTO";
                    }
                    else
                        afterCancela();
                }
            }
        }

        private void capturaPeso(ToolStripButton sender)
        {
            if (TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS"))
            {
                MessageBox.Show("Troca de notas não permite captura de peso!",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string vTP_Mov = "";
            if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                vTP_Mov = "E";
            else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                vTP_Mov = "S";
            if (vTP_Mov.ToUpper().Equals(vTP_MovDefault.ToUpper()))
            {
                if ((vOrdemPesagem.Length == 0) || (vOrdemPesagem.ToUpper().Equals("NM")))
                {
                    if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                    {
                        if (tpModo == TTpModo.tm_Insert)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Movimento.Enabled = false;
                                TP_Captura_Bruto.Clear();
                                dt_bruto.Clear();
                                login_PsBruto.Clear();
                                ps_bruto.Enabled = true;
                                ps_bruto.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                TP_Movimento.Enabled = false;
                                ps_bruto.Value = ps_balanca.Value; //Implementar captura automatica
                                TP_Captura_Bruto.Text = "A";
                                sairPS_Bruto();
                            }
                        }
                        else if (tpModo == TTpModo.tm_Edit)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Movimento.Enabled = false;
                                tp_captura_tara.Clear();
                                dt_tara.Clear();
                                login_PsTara.Clear();
                                ps_tara.Enabled = true;
                                ps_tara.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                TP_Movimento.Enabled = false;
                                ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                                tp_captura_tara.Text = "A";
                                sairPS_Tara();
                            }
                        }
                    }
                    else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                    {
                        if (tpModo == TTpModo.tm_Insert)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Movimento.Enabled = false;
                                tp_captura_tara.Clear();
                                dt_tara.Clear();
                                login_PsTara.Clear();
                                ps_tara.Enabled = true;
                                ps_tara.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                TP_Movimento.Enabled = false;
                                ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                                tp_captura_tara.Text = "A";
                                sairPS_Tara();
                            }
                        }
                        else if (tpModo == TTpModo.tm_Edit)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Movimento.Enabled = false;
                                TP_Captura_Bruto.Clear();
                                dt_bruto.Clear();
                                login_PsBruto.Clear();
                                ps_bruto.Enabled = true;
                                ps_bruto.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                TP_Movimento.Enabled = false;
                                ps_bruto.Value = ps_balanca.Value; //Implementar captura automatica
                                TP_Captura_Bruto.Text = "A";
                                sairPS_Bruto();
                            }
                        }
                    }
                }
                else if (vOrdemPesagem.ToUpper().Equals("BT"))
                {
                    if (tpModo == TTpModo.tm_Insert)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_bruto.Value = ps_balanca.Value; //Implementar captura automatica
                            TP_Captura_Bruto.Text = "A";
                            sairPS_Bruto();
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                            tp_captura_tara.Text = "A";
                            sairPS_Tara();
                        }
                    }
                }
                else if (vOrdemPesagem.ToUpper().Equals("TB"))
                {
                    if (tpModo == TTpModo.tm_Insert)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            tp_captura_tara.Clear();
                            login_PsTara.Clear();
                            dt_tara.Clear();
                            ps_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                            tp_captura_tara.Text = "A";
                            sairPS_Tara();
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_bruto.Value = ps_balanca.Value; //Implementar captura automatica
                            TP_Captura_Bruto.Text = "A";
                            sairPS_Bruto();
                        }
                    }
                }
            }
            else
            {
                if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                {
                    if (tpModo == TTpModo.tm_Insert)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_bruto.Value = ps_balanca.Value; //Implementar captura automatica
                            TP_Captura_Bruto.Text = "A";
                            sairPS_Bruto();
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                            tp_captura_tara.Text = "A";
                            sairPS_Tara();
                        }
                    }
                }
                else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                {
                    if (tpModo == TTpModo.tm_Insert)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_tara.Value = ps_balanca.Value; //Implementar captura automatica
                            tp_captura_tara.Text = "A";
                            sairPS_Tara();
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Movimento.Enabled = false;
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            TP_Movimento.Enabled = false;
                            ps_bruto.Value = ps_tara.Value; //Implementar captura automatica
                            TP_Captura_Bruto.Text = "A";
                            sairPS_Bruto();
                        }
                    }
                }
            }
        }

        private bool gravarPsGraos(bool fecharPesagem)
        {
            bool vPodeGravar = true;
            if (!((TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO")) || (QTD_DesdobroClifor.Value > 0)))
            {
                MessageBox.Show("Quantidade de desdobro NF não informado corretamente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QTD_DesdobroClifor.Focus();
                return false;
            }
            if (cd_tabeladesconto.Text == "")
            {
                MessageBox.Show("Obrigatório informar a tabela de classificação.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_tabeladesconto.Focus();
                return false;
            }
            if (!(TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS")))
            {
                if (tpModo == TTpModo.tm_Insert)
                {
                    if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                    {
                        if (ps_bruto.Value == 0)
                        {
                            MessageBox.Show("Falta peso bruto para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                    {
                        if (ps_tara.Value == 0)
                        {
                            MessageBox.Show("Falta peso tara para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }
            if (((ps_bruto.Value > 0) && (ps_tara.Value > 0)) || (TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS")))
            {
                if (placaCarreta.Text == "")
                {
                    MessageBox.Show("Obrigatório informar placa.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placaCarreta.Focus();
                    return false;
                }
                if (TP_Movimento.Text == "")
                {
                    MessageBox.Show("Obrigatório informar tipo de movimento.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TP_Movimento.Focus();
                    return false;
                }
                if (CD_Empresa.Text == "")
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return false;
                }
                if (CD_Local.Text == "")
                {
                    MessageBox.Show("Obrigatório informar local de armazenagem.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Local.Focus();
                    return false;
                }
                if (anosafra.Text == "")
                {
                    MessageBox.Show("Obrigatório informar ano safra.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    anosafra.Focus();
                    return false;
                }
            }
            if (tpModo == TTpModo.tm_Edit)
            {
                TDatBalClassificacao qtb_classif = new TDatBalClassificacao();
                if (cd_produto.Text != "")
                {
                    if (!(TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS")))//testar tambem se não é transf. entre local arm.
                    {
                        if (qtb_classif.produtoClassificavel(cd_produto.Text, cd_tabeladesconto.Text))
                        {
                            qtb_classif.CD_Empresa = CD_Empresa.Text;
                            qtb_classif.ID_Ticket = ID_Ticket.Value;
                            qtb_classif.TP_Desconto = TP_Pesagem.Text;
                            if (qtb_classif.existeClassificacao())
                            {
                                ps_desconto.Value = qtb_classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                                ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                                vPodeGravar = true;
                            }
                            else
                            {
                                tcPesagemGraos.SelectedTab = tpClassifGraos;
                                return false;
                            }
                        }
                        else
                        {
                            ps_desconto.Value = 0;
                            ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                        }
                    }
                    else
                        vPodeGravar = true;
                }
                else
                {
                    qtb_classif.CD_Empresa = CD_Empresa.Text;
                    qtb_classif.ID_Ticket = ID_Ticket.Value;
                    qtb_classif.TP_Pesagem = TP_Pesagem.Text;
                    if (qtb_classif.existeClassificacao())
                    {
                        ps_desconto.Value = qtb_classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                        vPodeGravar = true;
                    }
                    else
                    {
                        ps_desconto.Value = 0;
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value;
                        fecharPesagem = false;
                    }
                }
            }
            else
                vPodeGravar = true;
            TDatBalClifor qtb_balclifor = new TDatBalClifor();
            qtb_balclifor.CD_Empresa = CD_Empresa.Text;
            qtb_balclifor.ID_Ticket = ID_Ticket.Value;
            qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
            Int16 vQTD_Desdobro = qtb_balclifor.qtdDesdobro();
            if ((vQTD_Desdobro > 0) && (QTD_DesdobroClifor.Value > vQTD_Desdobro) && (nr_pedido.Text == ""))
            {
                MessageBox.Show("Quantidade de notas fiscais digitadas não confere com a quantidade de notas fiscais informadas na pesagem.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcPesagemGraos.SelectedTab = tpDesdobroClifor;
                return false;
            }
            if (vPodeGravar)
            {
                TDatBalPsGraos qtb_psgraos = new TDatBalPsGraos();
                if (nr_pedido.Text != "")
                {
                    TpBusca[] vBusca = new TpBusca[3];
                    vBusca[0].vNM_Campo = "a.CD_Empresa";
                    vBusca[0].vVL_Busca = "'" + CD_Empresa.Text + "'";
                    vBusca[0].vOperador = "=";
                    vBusca[1].vNM_Campo = "a.ID_Ticket";
                    vBusca[1].vVL_Busca = "'" + ID_Ticket.Value.ToString() + "'";
                    vBusca[1].vOperador = "=";
                    vBusca[2].vNM_Campo = "a.TP_Pesagem";
                    vBusca[2].vVL_Busca = "'" + TP_Pesagem.Text + "'";
                    vBusca[2].vOperador = "=";
                    qtb_balclifor.CD_Empresa = CD_Empresa.Text;
                    qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
                    qtb_balclifor.NR_Pedido = nr_pedido.Text;
                    object obj = qtb_balclifor.BuscarEscalar(vBusca, "ID_Desdobro");
                    if (obj != null)
                        if (obj.ToString() != "")
                            qtb_balclifor.ID_Desdobro = obj.ToString();
                    //Abrir tela de lançamento de nota
                    if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                    {
                        TFLanNotasPesagem fnotas = new TFLanNotasPesagem();
                        if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                            fnotas.ST_ControlarDesdobro = true;
                        else
                            fnotas.ST_ControlarDesdobro = false;
                        fnotas.qtd_desdobro.Text = QTD_DesdobroClifor.Value.ToString();
                        fnotas.lblProduto.Text = cd_produto.Text + " - " + ds_produto.Text;
                        fnotas.CD_Empresa = CD_Empresa.Text;
                        fnotas.ID_Ticket = ID_Ticket.Value;
                        fnotas.TP_Pesagem = TP_Pesagem.Text;
                        fnotas.ShowDialog();
                        int qtd_notas = 0;
                        if(fnotas.tabela != null)
                            qtd_notas = fnotas.tabela.Rows.Count;
                        for (Int16 i = 0; i < qtd_notas; i++)
                        {
                            TDatBalProduto qtb_balproduto = new TDatBalProduto();
                            try
                            {
                                qtb_balproduto.CD_Empresa = CD_Empresa.Text;
                                qtb_balproduto.TP_Pesagem = TP_Pesagem.Text;
                                qtb_balproduto.CD_Produto = cd_produto.Text;
                                qtb_balproduto.NR_Pedido = nr_pedido.Text;
                                qtb_balproduto.ID_Desdobro = fnotas.tabela.Rows[i]["ID_Desdobro"].ToString();
                                qtb_balproduto.ID_Item = fnotas.tabela.Rows[i]["ID_Item"].ToString();
                                qtb_balproduto.NR_NotaFiscal = fnotas.tabela.Rows[i]["NR_NotaFiscal"].ToString();
                                qtb_balproduto.NR_Serie = fnotas.tabela.Rows[i]["NR_Serie"].ToString();
                                qtb_balproduto.ST_Registro = fnotas.tabela.Rows[i]["ST_Registro"].ToString();
                                try
                                {
                                    qtb_balproduto.QTD_Nota = Convert.ToInt32(fnotas.tabela.Rows[i]["QTD_Nota"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.QTD_Nota = 0;
                                }
                                qtb_balproduto.DT_Emissao = fnotas.tabela.Rows[i]["DT_Emissao"].ToString();
                                try
                                {
                                    qtb_balproduto.Vl_Unitario = Convert.ToDecimal(fnotas.tabela.Rows[i]["Vl_Unitario"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.Vl_Unitario = 0;
                                }
                                try
                                {
                                    qtb_balproduto.Vl_SubTotal = Convert.ToDecimal(fnotas.tabela.Rows[i]["Vl_SubTotal"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.Vl_SubTotal = 0;
                                }
                                try
                                {
                                    qtb_balproduto.Vl_BaseCalc = Convert.ToDecimal(fnotas.tabela.Rows[i]["Vl_BaseCalc"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.Vl_BaseCalc = 0;
                                }
                                try
                                {
                                    qtb_balproduto.PC_Desdobro = Convert.ToDecimal(fnotas.tabela.Rows[i]["PC_Desdobro"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.PC_Desdobro = 0;
                                }
                                try
                                {
                                    qtb_balproduto.Vl_ICMS = Convert.ToDecimal(fnotas.tabela.Rows[i]["Vl_ICMS"].ToString());
                                }
                                catch
                                {
                                    qtb_balproduto.Vl_ICMS = 0;
                                }
                                qtb_balclifor.addBalProduto(qtb_balproduto);
                            }
                            finally
                            {
                                qtb_balproduto = null;
                            }
                        }
                    }
                    qtb_psgraos.addBalClifor(qtb_balclifor);
                }
                qtb_psgraos.CD_Empresa = CD_Empresa.Text;
                qtb_psgraos.ID_Ticket = ID_Ticket.Value;
                if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                    qtb_psgraos.TP_Movimento = "E";
                else if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                    qtb_psgraos.TP_Movimento = "S";
                qtb_psgraos.TP_Pesagem = TP_Pesagem.Text;
                qtb_psgraos.NR_Pedido = nr_pedido.Text;
                qtb_psgraos.PlacaCarreta = placaCarreta.Text;
                qtb_psgraos.PlacaCavalo = "";
                qtb_psgraos.PS_Bruto = ps_bruto.Value;
                qtb_psgraos.DT_Bruto = dt_bruto.Text;
                qtb_psgraos.TP_Captura_Bruto = TP_Captura_Bruto.Text;
                qtb_psgraos.PS_Tara = ps_tara.Value;
                qtb_psgraos.DT_Tara = dt_tara.Text;
                qtb_psgraos.TP_Captura_Tara = tp_captura_tara.Text;
                qtb_psgraos.PS_Liquido = ps_liquido.Value;
                qtb_psgraos.QTD_DesdobroClifor = Convert.ToInt16(QTD_DesdobroClifor.Value);
                qtb_psgraos.CD_Transp = cd_transp.Text;
                qtb_psgraos.Login_PsBruto = login_PsBruto.Text;
                qtb_psgraos.Login_PsTara = login_PsTara.Text;
                qtb_psgraos.CD_TpVeiculo = cd_tpveiculo.Text;
                qtb_psgraos.NM_Motorista = nm_motorista.Text;
                if (st_gmo.Checked)
                    qtb_psgraos.ST_GMO = "S";
                else
                    qtb_psgraos.ST_GMO = "N";
                if (ST_GMODeclarado.Checked)
                    qtb_psgraos.ST_GMODeclarado = "S";
                else
                    qtb_psgraos.ST_GMODeclarado = "N";
                if (TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS"))
                    qtb_psgraos.ST_TrocaNF = "S";
                else
                    qtb_psgraos.ST_TrocaNF = "N";
                if (st_descontorateado.Checked)
                    qtb_psgraos.ST_DescontoRateado = "S";
                else
                    qtb_psgraos.ST_DescontoRateado = "N";
                qtb_psgraos.QTD_Embalagem = Convert.ToInt16(qtd_embalagem.Value);
                qtb_psgraos.PS_Embalagem = ps_embalagem.Value;
                qtb_psgraos.DS_Observacao = ds_observacao.Text;
                qtb_psgraos.AnoSafra = anosafra.Text;
                qtb_psgraos.CD_Produto = cd_produto.Text;
                qtb_psgraos.CD_Moega = cd_moega.Text;
                qtb_psgraos.CD_Variedade = cd_variedade.Text;
                qtb_psgraos.CD_Local = CD_Local.Text;
                qtb_psgraos.CD_TabelaDesconto = cd_tabeladesconto.Text;
                qtb_psgraos.CD_Autoriz = cd_autoriz.Text;
                if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                    if (fecharPesagem)
                        qtb_psgraos.ST_Registro = "F";
                try
                {
                    qtb_psgraos.CriarBanco_Dados(true);
                    string retorno = qtb_psgraos.gravarPesagem();
                    qtb_psgraos.Banco_Dados.Commit_Tran();
                    MessageBox.Show("Romaneio " + TDataQuery.getPubVariavel(retorno, "@P_ID_TICKET") +
                                    " gravado com sucesso.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    tpModo = TTpModo.tm_Standby;
                    modoBotoes(tpPsGraos);
                    limpaCampos(tpPsGraos);
                    ativaCampos(tpPsGraos);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    qtb_psgraos.Banco_Dados.RollBack_Tran();
                    return false;
                }
            }
            return true;
        }

        private void gravarClassifGraos()
        {
            //Testar se ja existe classificação
            if (gClassifPsGraos.DataSource is DataTable)
            {
                if ((gClassifPsGraos.DataSource as DataTable).Rows.Count > 0)
                {
                    TDatBalClassificacao qtb_classif = new TDatBalClassificacao();
                    qtb_classif.CriarBanco_Dados(true);
                    try
                    {
                        int cont = (gClassifPsGraos.DataSource as DataTable).Rows.Count;
                        for (Int16 i = 0; i < cont; i++)
                        {
                            qtb_classif.CD_Empresa = CD_Empresa.Text;
                            qtb_classif.ID_Ticket = ID_Ticket.Value;
                            qtb_classif.TP_Pesagem = TP_Pesagem.Text;
                            qtb_classif.CD_TipoAmostra = (gClassifPsGraos.DataSource as DataTable).Rows[i]["CD_TipoAmostra"].ToString();
                            try
                            {
                                qtb_classif.PC_ResultadoLocal = Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[i]["PC_Result"].ToString());
                            }
                            catch
                            {
                                qtb_classif.PC_ResultadoLocal = 0;
                            }
                            qtb_classif.DT_Classif = DateTime.Now.ToString();
                            qtb_classif.LoginCla = TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
                            qtb_classif.gravarClassif();
                        }
                        qtb_classif.Banco_Dados.Commit_Tran();
                    }
                    catch
                    {
                        qtb_classif.Banco_Dados.RollBack_Tran();
                        qtb_classif.deletarBanco_Dados();
                    }
                    if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                    {
                        if (gravarPsGraos(false))
                        {
                            CD_Empresa.Enabled = false;
                            TP_Movimento.Enabled = false;
                            cd_produto.Enabled = false;
                        }
                        else
                        {
                            CD_Empresa.Enabled = true;
                            TP_Movimento.Enabled = true;
                            cd_produto.Enabled = true;
                        }
                        ps_desconto.Value = qtb_classif.calcClassif() + (ps_embalagem.Value * qtd_embalagem.Value);
                        ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value;
                        if (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO"))
                            gravarPsGraos(true);
                    }
                    else
                    {
                        TDatBalClifor qtb_desdobro = new TDatBalClifor();
                        qtb_desdobro.CD_Empresa = CD_Empresa.Text;
                        qtb_desdobro.ID_Ticket = ID_Ticket.Value;
                        qtb_desdobro.TP_Pesagem = TP_Pesagem.Text;
                        if ((QTD_DesdobroClifor.Value > qtb_desdobro.qtdDesdobro()) && (nr_pedido.Text == ""))
                        {
                            tcPesagemGraos.SelectedTab = tpDesdobroClifor;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Classificação realizada com sucesso.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tcPesagemGraos.SelectedTab = tpPsGraos;
                        }
                    }
                }
            }
        }

        private void gravarDesdobro()
        {
            TDatBalClifor qtb_balclifor = new TDatBalClifor();
            qtb_balclifor.CD_Empresa = CD_Empresa.Text;
            qtb_balclifor.ID_Ticket = ID_Ticket.Value;
            qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
            qtb_balclifor.ID_Desdobro = id_desdobro.Text;
            qtb_balclifor.NR_Pedido = nr_pedido.Text;
            qtb_balclifor.NM_CliforPedido = nm_cliforpedido.Text;
            qtb_balclifor.NM_Clifor = nm_clifordesdobro.Text;
            if (tp_pessoadesdobro.Text.ToUpper().Equals("JURÍDICA"))
                qtb_balclifor.TP_Pessoa = "J";
            else if (tp_pessoadesdobro.Text.ToUpper().Equals("FÍSICA"))
                qtb_balclifor.TP_Pessoa = "F";
            qtb_balclifor.CD_Endereco = cd_enderecodesdobro.Text;
            qtb_balclifor.CD_Clifor = cd_clifordesdobro.Text;
            qtb_balclifor.CD_CliforPedido = cd_cliforpedido.Text;
            TFLanNotasPesagem fNotas = new TFLanNotasPesagem();
            fNotas.qtd_desdobro.Text = QTD_DesdobroClifor.Value.ToString();
            fNotas.lblProduto.Text = cd_produto.Text.ToUpper() + " - " + ds_produto.Text.ToUpper();
            fNotas.CD_Empresa = CD_Empresa.Text;
            fNotas.ID_Ticket = ID_Ticket.Value;
            fNotas.TP_Pesagem = TP_Pesagem.Text;
            fNotas.ID_Desdobro = Convert.ToDecimal(id_desdobro.Text);
            fNotas.QTD_Desdobro = 0;//Implementar
            fNotas.ShowDialog();
            int cont = fNotas.tabela.Rows.Count;
            for(Int16 i = 0; i < cont; i++)
            {
                TDatBalProduto qtb_balproduto = new TDatBalProduto();
                try
                {
                    qtb_balproduto.CD_Empresa = CD_Empresa.Text;
                    qtb_balproduto.TP_Pesagem = TP_Pesagem.Text;
                    qtb_balproduto.CD_Produto = CD_ProdutoClifor.Text;
                    qtb_balproduto.NR_Pedido = NR_PedidoClifor.Text;
                    qtb_balproduto.ID_Desdobro = fNotas.tabela.Rows[i]["ID_Desdobro"].ToString();
                    qtb_balproduto.ID_Item = fNotas.tabela.Rows[i]["ID_Item"].ToString();
                    qtb_balproduto.NR_NotaFiscal = fNotas.tabela.Rows[i]["NR_NotaFiscal"].ToString();
                    qtb_balproduto.NR_Serie = fNotas.tabela.Rows[i]["NR_Serie"].ToString();
                    qtb_balproduto.QTD_Nota = Convert.ToInt32(fNotas.tabela.Rows[i]["QTD_Nota"].ToString());
                    qtb_balproduto.DT_Emissao = fNotas.tabela.Rows[i]["DT_Emissao"].ToString();
                    qtb_balproduto.Vl_Unitario = Convert.ToDecimal(fNotas.tabela.Rows[i]["Vl_Unitario"].ToString());
                    qtb_balproduto.Vl_SubTotal = Convert.ToDecimal(fNotas.tabela.Rows[i]["Vl_SubTotal"].ToString());
                    qtb_balproduto.Vl_BaseCalc = Convert.ToDecimal(fNotas.tabela.Rows[i]["Vl_BaseCalc"].ToString());    
                    qtb_balproduto.PC_Desdobro = Convert.ToDecimal(fNotas.tabela.Rows[i]["PC_Desdobro"].ToString());
                    qtb_balproduto.Vl_ICMS = Convert.ToDecimal(fNotas.tabela.Rows[i]["Vl_ICMS"].ToString());
                    qtb_balproduto.ST_Registro = fNotas.tabela.Rows[i]["ST_Registro"].ToString();
                    qtb_balclifor.addBalProduto(qtb_balproduto);
                }
                finally
                {
                    qtb_balproduto = null;
                }
            }
            qtb_balclifor.CriarBanco_Dados(true);
            try
            {
                qtb_balclifor.gravarBalClifor();
                qtb_balclifor.Banco_Dados.Commit_Tran();
                TpBusca[] vBusca = new TpBusca[4];
                vBusca[0].vNM_Campo = "a.CD_Empresa";
                vBusca[0].vVL_Busca = CD_Empresa.Text;
                vBusca[0].vOperador = "=";
                vBusca[1].vNM_Campo = "a.ID_Ticket";
                vBusca[1].vVL_Busca = ID_Ticket.Value.ToString();
                vBusca[1].vOperador = "=";
                vBusca[2].vNM_Campo = "a.TP_Pesagem";
                vBusca[2].vVL_Busca = TP_Pesagem.Text;
                vBusca[2].vOperador = "=";
                vBusca[3].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                vBusca[3].vVL_Busca = "C";
                vBusca[3].vOperador = "<>";
                //gDesdobroClifor.DataSource = qtb_balclifor.buscarDesdobro(vBusca);
                tpModoDesdobro = TTpModo.tm_Standby;
                modoBotoes(tpDesdobroClifor);
                limpaCampos(tpDesdobroClifor);
                ativaCampos(tpDesdobroClifor);
            }
            catch
            {
                qtb_balclifor.Banco_Dados.RollBack_Tran();
            }
        }

        private void excluirDesdobro()
        {
            if (id_desdobro.Text == "")
            {
                MessageBox.Show("Campo cód. desdobro é obrigatório.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_desdobro.Focus();
                return;
            }
            if (MessageBox.Show("Confirma exclusão do registro?", "Mensagem",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) ==
                                System.Windows.Forms.DialogResult.Yes)
            {
                TDatBalClifor qtb_balclifor = new TDatBalClifor();
                qtb_balclifor.CD_Empresa = CD_Empresa.Text;
                qtb_balclifor.ID_Ticket = ID_Ticket.Value;
                qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
                qtb_balclifor.ID_Desdobro = id_desdobro.Text;
                qtb_balclifor.ST_Registro = "C";
                qtb_balclifor.CriarBanco_Dados(true);
                try
                {
                    qtb_balclifor.excluirBalClifor();
                    qtb_balclifor.Banco_Dados.Commit_Tran();
                    TpBusca[] vBusca = new TpBusca[4];
                    vBusca[0].vNM_Campo = "a.CD_Empresa";
                    vBusca[0].vVL_Busca = CD_Empresa.Text;
                    vBusca[0].vOperador = "=";
                    vBusca[1].vNM_Campo = "a.ID_Ticket";
                    vBusca[1].vVL_Busca = ID_Ticket.Value.ToString();
                    vBusca[1].vOperador = "=";
                    vBusca[2].vNM_Campo = "a.TP_Pesagem";
                    vBusca[2].vVL_Busca = TP_Pesagem.Text;
                    vBusca[2].vOperador = "=";
                    vBusca[3].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                    vBusca[3].vVL_Busca = "C";
                    vBusca[3].vOperador = "<>";
                    //gDesdobroClifor.DataSource = qtb_balclifor.buscarDesdobro();
                    tpModoDesdobro = TTpModo.tm_Standby;
                    modoBotoes(tpDesdobroClifor);
                    limpaCampos(tpDesdobroClifor);
                    ativaCampos(tpDesdobroClifor);
                }
                catch
                {
                    qtb_balclifor.Banco_Dados.RollBack_Tran();
                }
            }
        }

        private void buscarPsGraos()
        {
            TpBusca[] vBusca = new TpBusca[0];
            if(CD_EmpBuscaPSGraos.Text != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a."+CD_EmpBuscaPSGraos.NM_CampoBusca;
                vBusca[vBusca.Length - 1].vVL_Busca = CD_EmpBuscaPSGraos.Text;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TDatBalPsGraos qtb_psgraos = new TDatBalPsGraos();
            gBuscaPsGraos.DataSource = qtb_psgraos.Buscar(vBusca, 0);
        }

        private void afterNovo()
        {
            if (TDataQuery.getPubVariavel(TInfo.pub, "TERMINAL") == "")
            {
                MessageBox.Show("Obrigatório informar terminal para realizar pesagem", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!(tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor)))
            {
                tpModo = TTpModo.tm_Insert;
                tcPesagemGraos.SelectedTab = tpPsGraos;
                modoBotoes(tcPesagemGraos.SelectedTab);
                placaCarreta.Enabled = true;
                BB_PlacaCarreta.Enabled = true;
                placaCarreta.Focus();
                configTPPesagem();
            }
            else
            {
                TDatBalClifor qtb_balclifor = new TDatBalClifor();
                qtb_balclifor.CD_Empresa = CD_Empresa.Text;
                qtb_balclifor.ID_Ticket = Convert.ToInt64(ID_Ticket.Value);
                qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
                if (qtb_balclifor.qtdDesdobro() < QTD_DesdobroClifor.Value)
                {
                    if (qtb_balclifor.qtdClifor() < QTD_DesdobroClifor.Value)
                    {
                        tpModoDesdobro = TTpModo.tm_Insert;
                        modoBotoes(tcPesagemGraos.SelectedTab);
                        pDesdobroNF.LimparRegistro();
                        pDesdobroNF.HabilitarControls(true, tpModoDesdobro);
                        CD_ProdutoClifor.Text = cd_produto.Text;
                        ds_produtoclifor.Text = ds_produto.Text;
                        id_desdobro.Enabled = false;
                        NR_PedidoClifor.Focus();
                        CD_ProdutoClifor.Enabled = (CD_ProdutoClifor.Text == "");
                        BB_ProdutoClifor.Enabled = (CD_ProdutoClifor.Text == "");
                    }
                    else
                        MessageBox.Show("Numero máximo de Clifor informado. Altere os desdobros existentes para informar as notas que faltam.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Numero máximo de desdobro informado.", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void configTPPesagem()
        {
            DataTable tabela = new DataTable();
            TDatTpPesagem qtb_TpPesagem = new TDatTpPesagem();
            TpBusca[] vBusca = new TpBusca[2];
            vBusca[0].vNM_Campo = "TP_Modo";
            vBusca[0].vOperador = "=";
            vBusca[1].vVL_Busca = "(Select 1 From TB_DIV_Usuario_X_TpPesagem x Where x.TP_Pesagem = TB_BAL_TPPesagem.TP_Pesagem and x.Login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "')";
            vBusca[1].vOperador = "EXISTS";
            if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
            {
                vBusca[0].vVL_Busca = "'G'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemAves))
            {
                vBusca[0].vVL_Busca = "'A'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemCD))
            {
                vBusca[0].vVL_Busca = "'C'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemDiversos))
            {
                vBusca[0].vVL_Busca = "'D'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemFazenda))
            {
                vBusca[0].vVL_Busca = "'F'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemRacao))
            {
                vBusca[0].vVL_Busca = "'R'";
                tabela = qtb_TpPesagem.Buscar(vBusca, 1);
            }
            if (tabela.Rows.Count > 0)
            {
                try
                {
                    TP_Pesagem.Text = tabela.Rows[0]["TP_Pesagem"].ToString();
                    NM_TpPesagem.Text = tabela.Rows[0]["NM_TpPesagem"].ToString();
                    vTP_MovDefault = tabela.Rows[0]["TP_MovDefault"].ToString();
                    vOrdemPesagem = tabela.Rows[0]["OrdemPesagem"].ToString();
                    vST_SeqManual = tabela.Rows[0]["ST_SeqManual"].ToString();
                    if (tabela.Rows[0]["TP_MovDefault"].ToString().ToUpper().Equals("E"))
                        TP_Movimento.Text = "RECEBIMENTO";
                    else if (tabela.Rows[0]["TP_MovDefault"].ToString().ToUpper().Equals("S"))
                        TP_Movimento.Text = "EXPEDIÇÃO";
                }
                catch
                {
                    TP_Pesagem.Text = "";
                    NM_TpPesagem.Text = "";
                    vTP_MovDefault = "";
                    vOrdemPesagem = "";
                    vST_SeqManual = "";
                    TP_Movimento.Text = "";
                }
            }
            else
            {
                TP_Pesagem.Text = "";
                NM_TpPesagem.Text = "";
                vTP_MovDefault = "";
                vOrdemPesagem = "";
                vST_SeqManual = "";
                TP_Movimento.Text = "";
            }
        }

        private void afterAltera()
        {
            if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
            {
                if (tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor))
                {
                    tpModoDesdobro = TTpModo.tm_Edit;
                    modoBotoes(tcPesagemGraos.SelectedTab);
                    limpaCampos(tcPesagemGraos.SelectedTab);
                    id_desdobro.Enabled = true;
                    id_desdobro.Focus();
                }
            }
        }

        private void afterCancela()
        {
            if (tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor))
                tpModoDesdobro = TTpModo.tm_Standby;
            else
                tpModo = TTpModo.tm_Standby;
            modoBotoes(tcPesagemGraos.SelectedTab);
            limpaCampos(tcPesagemGraos.SelectedTab);
            ativaCampos(tcPesagemGraos.SelectedTab);
        }

        private void afterGrava()
        {
            if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
            {
                if (tcPesagemGraos.SelectedTab.Equals(tpPsGraos))
                    gravarPsGraos(true);
                else if (tcPesagemGraos.SelectedTab.Equals(tpClassifGraos))
                    gravarClassifGraos();
                else if (tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor))
                    gravarDesdobro();
            }
        }

        private void afterExclui()
        {
            if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
            {
                if (tcPesagemGraos.SelectedTab.Equals(tpPsGraos))
                    gravarPsGraos(true);
                else if (tcPesagemGraos.SelectedTab.Equals(tpClassifGraos))
                    gravarClassifGraos();
                else if (tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor))
                    excluirDesdobro();
            }
        }

        private void afterBusca()
        {
            if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
                buscarPsGraos();
        }

        private void BB_PlacaCarreta_Click(object sender, EventArgs e)
        {
            if (tcPesagem.SelectedTab.Equals(tpPesagemAves))
            {
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemCD))
            {
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemDiversos))
            {
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemFazenda))
            {
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
            {
                string vColunas = "a.placaCarreta|Placa|80;" +
                                  "a.TP_Movimento|TP. Movimento|80;" +
                                  "a.CD_Empresa|Cód. Empresa|80;" +
                                  "f.CD_Produto|Cód. Produto|80;" +
                                  "l.CD_Local|Local Arm.|80;" +
                                  "l.CD_TabelaDesconto|Tab. Desconto|80";
                string vParamFixo = "a.ST_Registro|=|'A';" +
                                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaCarreta }, new TDatBalPsGraos(),
                                        vParamFixo);
            }
            else if (tcPesagem.SelectedTab.Equals(tpPesagemRacao))
            {
            }
            placaCarreta_Leave(this, e);
        }

        private void placaCarreta_Leave(object sender, EventArgs e)
        {
            if (placaCarreta.Text != "")
            {
                if (tcPesagem.SelectedTab.Equals(tpPesagemAves))
                {
                }
                else if (tcPesagem.SelectedTab.Equals(tpPesagemCD))
                {
                }
                else if (tcPesagem.SelectedTab.Equals(tpPesagemDiversos))
                {
                }
                else if (tcPesagem.SelectedTab.Equals(tpPesagemFazenda))
                {
                }
                else if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
                {
                    TpBusca[] vBusca = new TpBusca[3];
                    vBusca[0].vNM_Campo = "a." + placaCarreta.NM_CampoBusca;
                    vBusca[0].vVL_Busca = "'" + placaCarreta.Text + "'";
                    vBusca[0].vOperador = "=";
                    vBusca[1].vNM_Campo = "a.ST_Registro";
                    vBusca[1].vVL_Busca = "'A'";
                    vBusca[1].vOperador = "=";
                    vBusca[2].vVL_Busca = "(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                    vBusca[2].vOperador = "EXISTS";
                    TDatBalPsGraos qtb_psgraos = new TDatBalPsGraos();
                    DataTable tabela = qtb_psgraos.Buscar(vBusca, 1);
                    if (tabela != null)
                        if (tabela.Rows.Count > 0)
                        {
                            ps_bruto.Value = 0;
                            ps_tara.Value = 0;
                            ps_liquido.Value = 0;
                            CD_Empresa.Enabled = false;
                            BB_Empresa.Enabled = false;
                            cd_produto.Enabled = false;
                            BB_Produto.Enabled = false;
                            placaCarreta.Enabled = false;
                            carregarRegistros(tcPesagemGraos.SelectedTab, tabela.Rows[0], TTpModo.tm_Standby);
                            tpModo = TTpModo.tm_Edit;
                            modoBotoes(tcPesagemGraos.SelectedTab);
                            ativaCampos(tcPesagemGraos.SelectedTab);
                            if (nr_pedido.Text != "")
                                nr_pedido_Leave(this, null);
                            cd_autoriz.Enabled = false;
                            bb_autoriz.Enabled = false;
                            TP_Movimento.Enabled = false;
                        }
                        else
                        {
                            ativaCampos(tcPesagemGraos.SelectedTab);
                            cd_autoriz.Enabled = false;
                            bb_autoriz.Enabled = false;
                            CD_Empresa.Focus();
                        }
                }
                else if (tcPesagem.SelectedTab.Equals(tpPesagemRacao))
                {
                }
            }
        }

        private void nr_pedido_Leave(object sender, EventArgs e)
        {
            if (nr_pedido.Text != "")
            {
                TpBusca[] vBusca = new TpBusca[3];
                vBusca[0].vNM_Campo = "a." + CD_Empresa.NM_CampoBusca;
                vBusca[0].vVL_Busca = CD_Empresa.Text;
                vBusca[0].vOperador = "=";
                vBusca[1].vVL_Busca = "(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" +
                                        TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                vBusca[1].vOperador = "EXISTS";
                vBusca[2].vNM_Campo = "a." + nr_pedido.NM_CampoBusca;
                vBusca[2].vVL_Busca = nr_pedido.Text;
                vBusca[2].vOperador = "=";
                if (cd_produto.Text != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "b." + cd_produto.NM_CampoBusca;
                    vBusca[vBusca.Length - 1].vVL_Busca = cd_produto.Text;
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }

                CamadaDados.Faturamento.Pedido.TCD_LanPedido_GRO qtb_pedido = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_GRO();
                DataTable tabela = qtb_pedido.Buscar(vBusca, 0);
                if (tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        if (tabela.Rows[0]["TP_Movimento"].ToString().ToUpper().Equals("E"))
                            TP_Movimento.Text = "RECEBIMENTO";
                        else if (tabela.Rows[0]["TP_Movimento"].ToString().ToUpper().Equals("S"))
                            TP_Movimento.Text = "EXPEDIÇÃO";
                        st_gmo.Checked = tabela.Rows[0]["ST_GMO"].ToString().ToUpper().Equals("S");
                        st_gmo.Enabled = (!(st_gmo.Checked));
                        if ((tabela.Rows[0]["ST_Deposito"].ToString().ToUpper().Equals("S")) &&
                           (TP_Movimento.Text.ToUpper().Equals("EXPEDIÇÃO")))
                        {
                            cd_autoriz.Enabled = true;
                            bb_autoriz.Enabled = true;
                        }
                        else
                        {
                            cd_autoriz.Enabled = false;
                            bb_autoriz.Enabled = false;
                            cd_autoriz.Clear();
                        }
                        cd_clifor.Text = tabela.Rows[0]["CD_Clifor"].ToString();
                        nm_clifor.Text = tabela.Rows[0]["NM_Clifor"].ToString();

                        cd_tabeladesconto.Text = tabela.Rows[0]["CD_TabelaDesconto"].ToString();
                        cd_tabeladesconto.Enabled = false;
                        BB_TabelaDesconto.Enabled = false;
                        cd_tabeladesconto_Leave(this, e);

                        cd_produto.Text = tabela.Rows[0]["CD_Produto"].ToString();
                        if (tabela.Rows.Count == 1)
                        {
                            cd_produto.Enabled = false;
                            BB_Produto.Enabled = false;
                        }
                        else
                        {
                            cd_produto.Enabled = true;
                            BB_Produto.Enabled = true;
                        }
                        cd_produto_Leave(this, e);
                        cd_variedade.Text = tabela.Rows[0]["CD_Variedade"].ToString();
                        if (tabela.Rows.Count == 1)
                        {
                            cd_variedade.Enabled = false;
                            bb_variedade.Enabled = false;
                        }
                        else
                        {
                            cd_variedade.Enabled = true;
                            bb_variedade.Enabled = true;
                        }
                        cd_variedade_Leave(this, e);
                        anosafra.Text = tabela.Rows[0]["AnoSafra"].ToString();
                        anosafra.Enabled = false;
                        BB_AnoSafra.Enabled = false;
                        anosafra_Leave(this, e);
                    }
                    else
                    {
                        st_gmo.Enabled = true;
                        nr_pedido.Clear();
                        cd_clifor.Clear();
                        nm_clifor.Clear();
                        if (tpModo == TTpModo.tm_Insert)
                        {
                            cd_produto.Clear();
                            ds_produto.Clear();
                            cd_variedade.Clear();
                            ds_variedade.Clear();
                            cd_tabeladesconto.Clear();
                            ds_tabeladesconto.Clear();
                            anosafra.Clear();
                            ds_safra.Clear();
                        }
                        cd_produto.Enabled = true;
                        BB_Produto.Enabled = true;
                        cd_variedade.Enabled = true;
                        bb_variedade.Enabled = true;
                        cd_tabeladesconto.Enabled = true;
                        BB_TabelaDesconto.Enabled = true;
                        anosafra.Enabled = true;
                        BB_AnoSafra.Enabled = true;
                    }
            }
            else
            {
                st_gmo.Enabled = true;
                nr_pedido.Clear();
                cd_clifor.Clear();
                nm_clifor.Clear();
                if (tpModo == TTpModo.tm_Insert)
                {
                    cd_produto.Clear();
                    ds_produto.Clear();
                    cd_variedade.Clear();
                    ds_variedade.Clear();
                    cd_tabeladesconto.Clear();
                    ds_tabeladesconto.Clear();
                    anosafra.Clear();
                    ds_safra.Clear();
                }
                cd_produto.Enabled = true;
                BB_Produto.Enabled = true;
                cd_variedade.Enabled = true;
                bb_variedade.Enabled = true;
                cd_tabeladesconto.Enabled = true;
                BB_TabelaDesconto.Enabled = true;
                anosafra.Enabled = true;
                BB_AnoSafra.Enabled = true;
            }
        }

        private void CD_Empresa_Enter(object sender, EventArgs e)
        {
            if (CD_Empresa.Text.Equals(""))
            {
                TpBusca[] vBusca = new TpBusca[1];
                vBusca[0].vNM_Campo = "a.CD_Terminal";
                try
                {
                    vBusca[0].vVL_Busca = TDataQuery.getPubVariavel(TInfo.pub, "TERMINAL");
                }
                catch
                {
                    vBusca[0].vVL_Busca = "";
                }
                vBusca[0].vOperador = "=";
                TDatTerminal qtb_terminal = new TDatTerminal();
                DataTable tabela = qtb_terminal.Buscar(vBusca, 1);
                if (tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        CD_Empresa.Text = tabela.Rows[0]["CD_EmpresaPadrao"].ToString();
                        NM_Empresa.Text = tabela.Rows[0]["NM_Empresa"].ToString();
                    }
            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            if (CD_Empresa.Text != "")
            {
                string vColunas = "a." + CD_Empresa.NM_CampoBusca + "|=|'" + CD_Empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new TDatEmpresa());
            }
            else
                NM_Empresa.Clear();
        }

        private void CD_Empresa_TextChanged(object sender, EventArgs e)
        {
            if (CD_Empresa.Text.Trim().Equals(""))
            {
                CD_Local.Clear();
                ds_local.Clear();
                cd_moega.Clear();
                ds_moega.Clear();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new TDatEmpresa(), vParamFixo);
        }

        private void ID_Ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                TDatTpPesagem qtb_tppesagem = new TDatTpPesagem();
                ID_Ticket.Value = qtb_tppesagem.GerarID_Ticket(TP_Pesagem.Text);
                ID_Ticket.Select(0, ID_Ticket.Text.Length);
            }
        }
      
        private void ps_bruto_Leave(object sender, EventArgs e)
        {
            sairPS_Bruto();
        }

        private void ps_tara_Leave(object sender, EventArgs e)
        {
            sairPS_Tara();
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            if (cd_tabeladesconto.Text != "")
            {
                string vColunas = cd_tabeladesconto.NM_CampoBusca + "|=|'" + cd_tabeladesconto.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                        new TDatTabelaDesconto());
            }
            else
                ds_tabeladesconto.Clear();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (cd_produto.Text != "")
            {
                TpBusca[] vBusca = new TpBusca[2];
                vBusca[0].vNM_Campo = "a." + cd_produto.NM_CampoBusca;
                vBusca[0].vVL_Busca = cd_produto.Text;
                vBusca[0].vOperador = "=";
                vBusca[1].vNM_Campo = "i." + cd_tabeladesconto.NM_CampoBusca;
                vBusca[1].vVL_Busca = cd_tabeladesconto.Text;
                vBusca[1].vOperador = "=";
                TDatProduto qtb_produto = new TDatProduto("SqlCodeBuscaProdXTabDesc");
                DataTable tabela = qtb_produto.Buscar(vBusca, 1);
                if (tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        ds_produto.Text = tabela.Rows[0]["DS_Produto"].ToString();
                        try
                        {
                            ps_embalagem.Value = Convert.ToDecimal(tabela.Rows[0]["PS_Embalagem"].ToString());
                            ps_embalagem.Enabled = ps_embalagem.Value > 0;
                            qtd_embalagem.Enabled = ps_embalagem.Value > 0;
                        }
                        catch
                        {
                            ps_embalagem.Value = 0;
                            ps_embalagem.Enabled = false;
                            qtd_embalagem.Enabled = false;
                        }
                    }
                    else
                    {
                        cd_produto.Clear();
                        ds_produto.Clear();
                    }
            }
            else
                ds_produto.Clear();
        }

        private void cd_variedade_Leave(object sender, EventArgs e)
        {
            if (cd_variedade.Text != "")
            {
                string vColunas = "a." + cd_produto.NM_CampoBusca + "|=|'" + cd_produto.Text + "';" +
                                  "a." + cd_variedade.NM_CampoBusca + "|=|'" + cd_variedade.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_variedade, ds_variedade },
                                        new TDatVariedade());
            }
            else
                ds_variedade.Clear();
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            if (anosafra.Text != "")
                UtilPesquisa.EDIT_LEAVE(anosafra.NM_CampoBusca + "|=|'" + anosafra.Text + "'",
                                        new Componentes.EditDefault[] { anosafra, ds_safra },
                                        new TDatSafra());
            else
                ds_safra.Clear();
        }

        private void bb_pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Pedido|Nº Pedido|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "f.NM_Clifor|Nome Clifor|350;" +
                              "b.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|350";

            string vParamFixo = "a." + CD_Empresa.NM_CampoBusca + "|=|'" + CD_Empresa.Text + "';" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_pedido, cd_produto }, new CamadaDados.Faturamento.Pedido.TCD_LanPedido_GRO(), vParamFixo);
            nr_pedido_Leave(this, e);
            if(nr_pedido.Text.Equals(""))
            {
                nr_pedido.Clear();
                cd_clifor.Clear();
                nm_clifor.Clear();
                cd_produto.Clear();
                ds_produto.Clear();
                cd_variedade.Clear();
                ds_variedade.Clear();
                cd_tabeladesconto.Clear();
                ds_tabeladesconto.Clear();
                anosafra.Clear();
                ds_safra.Clear();
            }
        }

        private void BB_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Classificação|350;" +
                              "CD_TabelaDesconto|Cód. TabDesconto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                    new TDatTabelaDesconto(), "");
        }

        private void cd_tabeladesconto_TextChanged(object sender, EventArgs e)
        {
            if (cd_tabeladesconto.Text.Trim().Equals(""))
            {
                cd_produto.Clear();
                ds_produto.Clear();
                cd_moega.Clear();
                ds_moega.Clear();
            }
        }

        private void cd_produto_TextChanged(object sender, EventArgs e)
        {
            if (cd_produto.Text.Trim().Equals(""))
            {
                cd_variedade.Clear();
                ds_variedade.Clear();
            }
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;"+
                              "a.CD_Produto|Cód. Produto|80";
            string vParamFixo = "i.CD_TabelaDesconto|=|'"+cd_tabeladesconto.Text+"'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{cd_produto},
                                    new TDatProduto("SqlCodeBuscaProdXTabDesc"), vParamFixo);
            cd_produto_Leave(this, e);
        }

        private void cd_variedade_Enter(object sender, EventArgs e)
        {
            if ((cd_produto.Text != "")&&(cd_variedade.Text.Equals("")))
            {
                UtilPesquisa.EDIT_LEAVE("a." + cd_produto.NM_CampoBusca + "|=|'" + cd_produto.Text + "'",
                                        new Componentes.EditDefault[] { cd_variedade, ds_variedade },
                                        new TDatVariedade());
            }
        }

        private void bb_variedade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Variedade|Descrição Variedade|350;"+
                              "a.CD_Variedade|Cód. Varidade|100";
            string vParamFixo = "a.CD_Produto|=|'"+cd_produto.Text+"'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_variedade, ds_variedade },
                                    new TDatVariedade(), vParamFixo);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
                string vColunas = "a." + CD_Local.NM_CampoBusca + "|=|'" + CD_Local.Text + "';" +
                                  "a." + CD_Empresa.NM_CampoBusca + "|=|'" + CD_Empresa.Text + "'";

                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, ds_local },
                                        new TDatLocalArmXEmpresa());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "c.DS_Local|Local Armazenagem|350;" +
                              "a.CD_Local|Cód. Local|80";
            string vParamFixo = "a." + CD_Empresa.NM_CampoBusca + "|=|'" + CD_Empresa.Text + "'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, ds_local },
                                    new TDatLocalArmXEmpresa(), vParamFixo);
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
                UtilPesquisa.EDIT_LEAVE(cd_tpveiculo.NM_CampoBusca + "|=|'" + cd_tpveiculo.Text + "'",
                                        new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                        new TDatTpVeiculo());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veiculo|350;" +
                              "CD_TpVeiculo|Cód. TPVeiculo|100";  

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{cd_tpveiculo, ds_tpveiculo},
                                    new TDatTpVeiculo(), "");
        }

        private void cd_moega_Leave(object sender, EventArgs e)
        {
                string vColunas = cd_moega.NM_CampoBusca + "|=|'" + cd_moega.Text + "';" +
                                  "|EXISTS|(select 1 from tb_est_moega_x_tabdesc w where w.cd_moega = tb_est_moega.cd_moega and w.cd_tabeladesconto = '" + cd_tabeladesconto.Text + "')" +
                                            "OR exists(select 1 from tb_est_empresa_x_moega y where y.cd_moega = tb_est_moega.cd_moega and y.cd_empresa = '" + CD_Empresa.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moega, ds_moega },
                                        new TDatMoega());
        }

        private void bb_moega_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moega|Descrição Moega|350;" +
                              "CD_Moega|Cód. Moega|80";
            string vParamFixo = "|EXISTS|(select 1 from tb_est_moega_x_tabdesc w where w.cd_moega = tb_est_moega.cd_moega and w.cd_tabeladesconto = '" + cd_tabeladesconto.Text + "')" +
                                                  "OR exists(select 1 from tb_est_empresa_x_moega y where y.cd_moega = tb_est_moega.cd_moega and y.cd_empresa = '" + CD_Empresa.Text + "')";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moega, ds_moega },
                                    new TDatMoega(), vParamFixo);
        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Safra|Ano Safra|350;" +
                              "AnoSafra|Cód. Safra|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new TDatSafra(), "");
        }

        private void cd_transp_Leave(object sender, EventArgs e)
        {
            if (cd_transp.Text != "")
            {
                string vColunas = "a." + cd_transp.NM_CampoBusca + "|=|'" + cd_transp.Text + "';" +
                                  "a.ST_Transportadora|=|'S'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transp, nm_motorista },
                                        new TDatClifor());
            }
        }

        private void bb_transp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Transportadora|350;" +
                              "a.CD_Clifor|Cód. Clifor|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_transp, nm_motorista },
                                    new TDatClifor(), "a.ST_Transportadora|=|'S'");
        }

        private void cd_obs_Leave(object sender, EventArgs e)
        {
            if (cd_obs.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE(cd_obs.NM_CampoBusca + "|=|'" + cd_obs.Text + "'",
                                        new Componentes.EditDefault[] { cd_obs, ds_observacao },
                                        new TDatObservacaoFiscal());
            }
        }

        private void bb_obs_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_ObservacaoFiscal|Observação Fiscal|350;" +
                              "CD_ObservacaoFiscal|Cód. ObsFiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_obs, ds_observacao },
                                    new TDatObservacaoFiscal(), "");
        }

        private void tcPesagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPesagem.TabCount > 1)
                if (!(tcPesagem.SelectedTab.Equals(pageAnterior)))
                {
                    salvarPageAnterior();
                    carregarPageAtual(tcPesagem.SelectedTab);
                    pageAnterior = tcPesagem.SelectedTab;
                    modoBotoes(tcPesagem.SelectedTab);
                }
        }

        private void tcPesagemGraos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPesagemGraos.SelectedTab.Equals(tpBuscaPsGraos))
            {
                if ((tpModoDesdobro == TTpModo.tm_Insert) || (tpModoDesdobro == TTpModo.tm_Edit))
                {
                    tcPesagemGraos.SelectedTab = tpDesdobroClifor;
                    return;
                }
                modoBotoes(tpPsGraos);
            }
            else if (tcPesagemGraos.SelectedTab.Equals(tpPsGraos))
            {
                if ((tpModoDesdobro == TTpModo.tm_Insert) || (tpModoDesdobro == TTpModo.tm_Edit))
                {
                    tcPesagemGraos.SelectedTab = tpDesdobroClifor;
                    return;
                }
                modoBotoes(tpPsGraos);
            }
            else if (tcPesagemGraos.SelectedTab.Equals(tpClassifGraos))
            {
                if ((tpModoDesdobro == TTpModo.tm_Insert) || (tpModoDesdobro == TTpModo.tm_Edit))
                {
                    tcPesagemGraos.SelectedTab = tpDesdobroClifor;
                    return;
                }
                modoBotoes(tpPsGraos);
                if (cd_tabeladesconto.Text.Trim().Equals(""))
                {
                    tcPesagemGraos.SelectedTab = tpPsGraos;
                    return;
                }
                TDatUsuarioXRegraEspecial qtb_regra = new TDatUsuarioXRegraEspecial();
                if (!(qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR ACESSO A LANCAR CLASSIFICACAO")))
                {
                    tcPesagemGraos.SelectedTab = tpPsGraos;
                    return;
                }
                TDatBalClassificacao qtb_classif = new TDatBalClassificacao();
                if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                {
                    if (qtb_classif.produtoClassificavel(cd_produto.Text, cd_tabeladesconto.Text))
                    {
                        qtb_classif.CD_Empresa = CD_Empresa.Text;
                        qtb_classif.ID_Ticket = ID_Ticket.Value;
                        qtb_classif.TP_Pesagem = TP_Pesagem.Text;
                        if (qtb_classif.existeClassificacao())
                        {
                            if (TP_Movimento.Text.ToUpper().Equals("RECEBIMENTO"))
                                bb_desdobroespecial.Enabled = qtb_regra.ValidaRegra(TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR DESDOBROS ESPECIAIS");
                            else
                                bb_desdobroespecial.Enabled = false;
                        }
                        else
                            bb_desdobroespecial.Enabled = false;
                    }
                    else
                        bb_desdobroespecial.Enabled = false;
                }
                else
                    bb_desdobroespecial.Enabled = false;
                if ((tpModo == TTpModo.tm_Insert) || (tpModo == TTpModo.tm_Edit))
                {
                    if (cd_tabeladesconto.Text != "")
                    {
                        if (!(existeClassificacaoTela()))
                        {
                            qtb_classif.NM_ProcSqlBusca = "";
                            gClassifPsGraos.DataSource = qtb_classif.BuscaClassif(CD_Empresa.Text, ID_Ticket.Value.ToString(),
                                                                                 TP_Pesagem.Text, cd_tabeladesconto.Text);
                            Binding bg = new Binding("Text", gClassifPsGraos.DataSource, "ds_amostra");
                            ds_amostra.DataBindings.Clear();
                            ds_amostra.DataBindings.Add(bg);
                            bg = new Binding("Text", gClassifPsGraos.DataSource, "pc_result");
                            pc_result.DataBindings.Clear();
                            pc_result.DataBindings.Add(bg);

                            if (gClassifPsGraos.DataSource is DataTable)
                                if ((gClassifPsGraos.DataSource as DataTable).Rows.Count > 0)
                                {
                                    if (gClassifPsGraos.CurrentRow == null)
                                    {
                                        ds_amostra.Text = (gClassifPsGraos.DataSource as DataTable).Rows[0]["DS_Amostra"].ToString();
                                        try
                                        {
                                            pc_result.Value = Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[0]["PC_Result"].ToString());
                                        }
                                        catch
                                        {
                                            pc_result.Value = 0;
                                        }
                                    }
                                    else
                                    {
                                        ds_amostra.Text = (gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["DS_Amostra"].ToString();
                                        try
                                        {
                                            pc_result.Value = Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["PC_Result"].ToString());
                                        }
                                        catch
                                        {
                                            pc_result.Value = 0;
                                        }
                                    }
                                    pc_result.Focus();
                                }
                        }
                    }
                }
            }
            else if (tcPesagemGraos.SelectedTab.Equals(tpDesdobroClifor))
            {
                if (nr_pedido.Text != "")
                    tcPesagemGraos.SelectedTab = tpPsGraos;
                else
                {
                    modoBotoes(tpDesdobroClifor);
                    TpBusca[] vBusca = new TpBusca[4];
                    vBusca[0].vNM_Campo = "a.CD_Empresa";
                    vBusca[0].vVL_Busca = "'" + CD_Empresa.Text + "'";
                    vBusca[0].vOperador = "=";
                    vBusca[1].vNM_Campo = "a.ID_Ticket";
                    vBusca[1].vVL_Busca = "'" + ID_Ticket.Value.ToString() + "'";
                    vBusca[1].vOperador = "=";
                    vBusca[2].vNM_Campo = "a.TP_Pesagem";
                    vBusca[2].vVL_Busca = "'" + TP_Pesagem.Text + "'";
                    vBusca[2].vOperador = "=";
                    vBusca[3].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                    vBusca[3].vVL_Busca = "'C'";
                    vBusca[3].vOperador = "<>";
                    //Verificar este codigo
                    //TDatBalClifor qtb_desdobro = new TDatBalClifor();
                    //gDesdobroClifor.DataSource = qtb_desdobro.buscarDesdobro();
                    //gDesdobroClifor.TableStyles.Item[0].MappingName:= (gDesdobroClifor.DataSource as DataSet).Tables[0].TableName;
                    //gDesdobroClifor.TableStyles.Item[1].MappingName:= (gDesdobroClifor.DataSource as DataSet).Tables[1].TableName;
                    if (cd_produto.Text != "")
                    {
                        CD_ProdutoClifor.Text = cd_produto.Text;
                        ds_produtoclifor.Text = ds_produto.Text;
                        CD_ProdutoClifor.Enabled = false;
                        BB_ProdutoClifor.Enabled = false;
                    }
                    else
                    {
                        CD_ProdutoClifor.Clear();
                        ds_produtoclifor.Clear();
                        CD_ProdutoClifor.Enabled = true;
                        BB_ProdutoClifor.Enabled = true;
                    }
                }
                
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
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

        private void BB_CapturaManual_Click(object sender, EventArgs e)
        {
            capturaPeso(BB_CapturaManual);
        }

        private void BB_CapturaAutomatico_Click(object sender, EventArgs e)
        {
            capturaPeso(BB_CapturaAutomatico);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanPesagem_Load(object sender, EventArgs e)
        {
            pTopEsquerdo.set_FormatZero();
            pPesagemGraos.set_FormatZero();
            pDesdobroNF.set_FormatZero();
            pBuscaPsGraos.set_FormatZero();
            removerPages(tcPesagem);
            adicionarPages(tcPesagem);
            int cont = tcPesagem.TabPages.Count;
            estadoPage = new TEstadoPage[cont];
            for (Int16 i = 0; i < cont; i++)
            {
                estadoPage[i].NM_Page = tcPesagem.TabPages[i].Name;
                estadoPage[i].ST_Page = TTpModo.tm_Standby;
                estadoPage[i].Placa = placaCarreta.Text;
                estadoPage[i].CD_Empresa = CD_Empresa.Text;
                estadoPage[i].NM_Empresa = NM_Empresa.Text;
                estadoPage[i].ID_Ticket = ID_Ticket.Value;
                estadoPage[i].PS_Balanca = ps_balanca.Value;
                estadoPage[i].PS_Bruto = ps_bruto.Value;
                estadoPage[i].PS_Tara = ps_tara.Value;
                estadoPage[i].PS_Desconto = ps_desconto.Value;
                estadoPage[i].PS_Liquido = ps_liquido.Value;
                estadoPage[i].NM_Protocolo = cbProtocolo.Text;
                estadoPage[i].TP_CapturaBruto = TP_Captura_Bruto.Text;
                estadoPage[i].TP_CapturaTara = tp_captura_tara.Text;
                estadoPage[i].DT_Bruto = dt_bruto.Text;
                estadoPage[i].DT_Tara = dt_tara.Text;
                estadoPage[i].Login_PSBruto = login_PsBruto.Text;
                estadoPage[i].Login_PSTara = login_PsTara.Text;
                estadoPage[i].vIndexTP_Movimento = TP_Movimento.SelectedIndex;
            }
            pageAnterior = tcPesagem.SelectedTab;
            tpModoDesdobro = TTpModo.tm_Standby;
        }

        private void TFLanPesagem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F2): { afterNovo(); break; }
                case (Keys.F3): { afterAltera(); break; }
                case (Keys.F4): { afterGrava(); break; }
                case (Keys.F5): { afterExclui(); break; }
                case (Keys.F6): { afterCancela(); break; }
                //case(Keys.F7): buscar
                //case(Keys.F8): imprimir
                case (Keys.F11): { capturaPeso(BB_CapturaManual); break; }
                case (Keys.F12): { capturaPeso(BB_CapturaAutomatico); break; }
            }
        }

        private void CD_EmpBuscaPSGraos_Leave(object sender, EventArgs e)
        {
            if (CD_EmpBuscaPSGraos.Text != "")
            {
                string vColunas = "a." + CD_EmpBuscaPSGraos.NM_CampoBusca + "|=|'" + CD_EmpBuscaPSGraos.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_EmpBuscaPSGraos },
                                        new TDatEmpresa());
            }
        }

        private void BB_EmpBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_EmpBuscaPSGraos },
                                    new TDatEmpresa(), vParamFixo);
        }

        private void cd_prodBuscaPsGraos_Leave(object sender, EventArgs e)
        {
            if (cd_prodBuscaPsGraos.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE("a." + cd_prodBuscaPsGraos.NM_CampoBusca + "|=|'" + cd_prodBuscaPsGraos.Text + "'",
                                        new Componentes.EditDefault[] { cd_prodBuscaPsGraos },
                                        new TDatProduto());
            }
        }

        private void BB_ProdBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_prodBuscaPsGraos },
                                    new TDatProduto(), "");
        }

        private void cd_tabDescBuscaPsGraos_Leave(object sender, EventArgs e)
        {
            if (cd_tabDescBuscaPsGraos.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE(cd_tabDescBuscaPsGraos.NM_CampoBusca + "|=|'" + cd_tabDescBuscaPsGraos.Text + "'",
                                        new Componentes.EditDefault[] { cd_tabDescBuscaPsGraos },
                                        new TDatTabelaDesconto());
            }
        }

        private void BB_tabDescBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Desconto|350;" +
                              "CD_TabelaDesconto|Cód. TabDesc.|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabDescBuscaPsGraos },
                                    new TDatTabelaDesconto(), "");
        }

        private void cd_contratante_Leave(object sender, EventArgs e)
        {
            if (cd_contratante.Text != "")
                UtilPesquisa.EDIT_LEAVE("a." + cd_contratante.NM_CampoBusca + "|=|'" + cd_contratante.Text + "'",
                                        new Componentes.EditDefault[] { cd_contratante },
                                        new TDatClifor());
        }

        private void BB_Contratante_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Contratante|350;" +
                              "a.CD_Clifor|Cód. Clifor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contratante },
                                    new TDatClifor(), "");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            if (cd_fornecedor.Text != "")
                UtilPesquisa.EDIT_LEAVE("a." + cd_fornecedor.NM_CampoBusca + "|=|'" + cd_fornecedor.Text + "'",
                                        new Componentes.EditDefault[] { cd_fornecedor },
                                        new TDatClifor());
        }

        private void BB_Fornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Fornecedor|350;" +
                              "a.CD_Clifor|Cód. Fornecedor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fornecedor },
                                    new TDatClifor(), "");
        }

        private void id_desdobro_Leave(object sender, EventArgs e)
        {
            if (id_desdobro.Text != "")
            {
                if (gDesdobroClifor.DataSource is DataSet)
                {
                    DataRow[] lClifor = new DataRow[0];
                    lClifor = (gDesdobroClifor.DataSource as DataSet).Tables[0].Select(
                              "CD_Empresa = "+CD_Empresa.Text+" and ID_Ticket = "+ID_Ticket.Value.ToString()+
                              " and TP_Pesagem = "+TP_Pesagem.Text+" and ID_Desdobro = "+id_desdobro.Text);
                    if (lClifor.Length > 0)
                    {
                        NR_PedidoClifor.Text = lClifor[0]["NR_Pedido"].ToString();
                        cd_cliforpedido.Text = lClifor[0]["CD_CliforPedido"].ToString();
                        nm_cliforpedido.Text = lClifor[0]["Nome_CliforPedido"].ToString();
                        cd_clifordesdobro.Text = lClifor[0]["CD_Clifor"].ToString();
                        nm_clifordesdobro.Text = lClifor[0]["Nome_Clifor"].ToString();
                        tp_pessoadesdobro.Text = lClifor[0]["TP_Pessoa"].ToString();
                        cd_enderecodesdobro.Text = lClifor[0]["CD_Endereco"].ToString();
                        DataRow[] lProduto = new DataRow[0];
                        lProduto = (gDesdobroClifor.DataSource as DataSet).Tables[1].Select(
                                    "CD_Empresa = "+CD_Empresa.Text+" and ID_Ticket = "+ID_Ticket.Value.ToString()+
                                    " and TP_Pesagem = "+TP_Pesagem.Text+" and ID_Desdobro = "+id_desdobro.Text);
                        if (lProduto.Length > 0)
                        {
                            CD_ProdutoClifor.Text = lProduto[0]["CD_Produto"].ToString();
                            ds_produtoclifor.Text = lProduto[0]["DS_Produto"].ToString();
                        }
                        ativaCampos(tcPesagemGraos.SelectedTab);
                        NR_PedidoClifor.Focus();
                    }
                    else
                    {
                        TDatBalClifor qtb_balclifor = new TDatBalClifor();
                        qtb_balclifor.CD_Empresa = CD_Empresa.Text;
                        qtb_balclifor.ID_Ticket = ID_Ticket.Value;
                        qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
                        if (qtb_balclifor.qtdClifor() < QTD_DesdobroClifor.Value)
                        {
                            tpModoDesdobro = TTpModo.tm_Insert;
                            modoBotoes(tcPesagemGraos.SelectedTab);
                            limpaCampos(tcPesagemGraos.SelectedTab);
                            ativaCampos(tcPesagemGraos.SelectedTab);
                            id_desdobro.Enabled = false;
                            NR_PedidoClifor.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Numero máximo de clifor informado.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterCancela();
                        }
                    }
                }
            }
            else
            {
                TDatBalClifor qtb_balclifor = new TDatBalClifor();
                qtb_balclifor.CD_Empresa = CD_Empresa.Text;
                qtb_balclifor.ID_Ticket = ID_Ticket.Value;
                qtb_balclifor.TP_Pesagem = TP_Pesagem.Text;
                if (qtb_balclifor.qtdClifor() < QTD_DesdobroClifor.Value)
                {
                    tpModoDesdobro = TTpModo.tm_Insert;
                    modoBotoes(tcPesagemGraos.SelectedTab);
                    limpaCampos(tcPesagemGraos.SelectedTab);
                    ativaCampos(tcPesagemGraos.SelectedTab);
                    id_desdobro.Enabled = false;
                    NR_PedidoClifor.Focus();
                }
                else
                {
                    MessageBox.Show("Numero máximo de clifor informado.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterCancela();
                }
            }
        }

        private void NR_PedidoClifor_Leave(object sender, EventArgs e)
        {
            if (NR_PedidoClifor.Text != "")
            {
                TpBusca[] vBusca = new TpBusca[4];
                vBusca[0].vNM_Campo = "a." + CD_Empresa.NM_CampoBusca;
                vBusca[0].vVL_Busca = "'" + CD_Empresa.Text + "'";
                vBusca[0].vOperador = "=";
                vBusca[1].vVL_Busca = "(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                vBusca[1].vOperador = "EXISTS";
                vBusca[2].vNM_Campo = "a." + NR_PedidoClifor.NM_CampoBusca;
                vBusca[2].vVL_Busca = "'" + NR_PedidoClifor.Text + "'";
                vBusca[2].vOperador = "=";
                vBusca[3].vNM_Campo = "i." + cd_tabeladesconto.NM_CampoBusca;
                vBusca[3].vVL_Busca = "'" + cd_tabeladesconto.Text + "'";
                vBusca[3].vOperador = "=";
                if (CD_ProdutoClifor.Text != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "b." + CD_ProdutoClifor.NM_CampoBusca;
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_ProdutoClifor.Text + "'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item qtb_pedido = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item();
                DataTable tabela = qtb_pedido.Buscar(vBusca, 1);
                if (tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        cd_cliforpedido.Text = tabela.Rows[0]["CD_Clifor"].ToString();
                        nm_cliforpedido.Text = tabela.Rows[0]["NM_Clifor"].ToString();
                        if (tabela.Rows[0]["TP_Pessoa"].ToString().ToUpper().Equals("F"))
                            NR_CGCCPFClifor.Text = tabela.Rows[0]["NR_CPF"].ToString();
                        else if (tabela.Rows[0]["TP_Pessoa"].ToString().ToUpper().Equals("J"))
                            NR_CGCCPFClifor.Text = tabela.Rows[0]["NR_CGC"].ToString();
                        if (CD_ProdutoClifor.Text.Equals(""))
                        {
                            CD_ProdutoClifor.Text = tabela.Rows[0]["CD_Produto"].ToString();
                            ds_produtoclifor.Text = tabela.Rows[0]["DS_Produto"].ToString();
                        }
                        cd_cliforpedido.Enabled = false;
                        bb_cliforpedido.Enabled = false;
                        nm_cliforpedido.Enabled = false;
                        NR_CGCCPFClifor.Enabled = false;
                    }
                    else
                    {
                        cd_cliforpedido.Clear();
                        nm_cliforpedido.Clear();
                        NR_CGCCPFClifor.Clear();
                        if (cd_produto.Text.Equals(""))
                        {
                            CD_ProdutoClifor.Clear();
                            ds_produtoclifor.Clear();
                        }
                        cd_cliforpedido.Enabled = true;
                        bb_cliforpedido.Enabled = true;
                        nm_cliforpedido.Enabled = true;
                        NR_CGCCPFClifor.Enabled = true;
                    }
            }
            else
            {
                cd_cliforpedido.Clear();
                nm_cliforpedido.Clear();
                NR_CGCCPFClifor.Clear();
                if (cd_produto.Text.Equals(""))
                {
                    CD_ProdutoClifor.Clear();
                    ds_produtoclifor.Clear();
                }
                cd_cliforpedido.Enabled = true;
                bb_cliforpedido.Enabled = true;
                nm_cliforpedido.Enabled = true;
                NR_CGCCPFClifor.Enabled = true;
            }
        }

        private void NR_PedidoClifor_TextChanged(object sender, EventArgs e)
        {
            if (cd_produto.Text.Equals(""))
            {
                CD_ProdutoClifor.Clear();
                ds_produtoclifor.Clear();
            }
            cd_cliforpedido.Clear();
            NR_CGCCPFClifor.Clear();
            nm_cliforpedido.Clear();
        }

        private void bb_pedidoclifor_Click(object sender, EventArgs e)
        {
            TFBusca fBusca = new TFBusca();
            try
            {
                fBusca.confBusca = new TpBusca[5];
                fBusca.confBusca[0].vNM_Caption = "Nº Pedido";
                fBusca.confBusca[0].vWidth = 80;
                fBusca.confBusca[0].vNM_Campo = "a.NR_Pedido";
                fBusca.confBusca[0].vOperador = "like";

                fBusca.confBusca[1].vNM_Caption = "Cód. Clifor";
                fBusca.confBusca[1].vWidth = 80;
                fBusca.confBusca[1].vNM_Campo = "a.CD_Clifor";
                fBusca.confBusca[1].vOperador = "like";

                fBusca.confBusca[2].vNM_Caption = "Nome Clifor";
                fBusca.confBusca[2].vWidth = 350;
                fBusca.confBusca[2].vNM_Campo = "f.NM_Clifor";
                fBusca.confBusca[2].vOperador = "like";

                fBusca.confBusca[3].vNM_Caption = "Cód. Produto";
                fBusca.confBusca[3].vWidth = 80;
                fBusca.confBusca[3].vNM_Campo = "b.CD_Produto";
                fBusca.confBusca[3].vOperador = "like";

                fBusca.confBusca[4].vNM_Caption = "Descrição Produto";
                fBusca.confBusca[4].vWidth = 350;
                fBusca.confBusca[4].vNM_Campo = "d.DS_Produto";
                fBusca.confBusca[4].vOperador = "like";

                TpBusca[] aux = new TpBusca[3];
                aux[0].vVL_Busca = "(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";
                aux[0].vOperador = "EXISTS";
                aux[1].vNM_Campo = "a." + CD_Empresa.NM_CampoBusca;
                aux[1].vVL_Busca = "'" + CD_Empresa.Text + "'";
                aux[1].vOperador = "=";
                aux[2].vNM_Campo = "i." + cd_tabeladesconto.NM_CampoBusca;
                aux[2].vVL_Busca = "'" + cd_tabeladesconto.Text + "'";
                aux[2].vOperador = "=";
                if (CD_ProdutoClifor.Text != "")
                {
                    Array.Resize(ref aux, aux.Length + 1);
                    aux[aux.Length - 1].vNM_Campo = "b." + CD_ProdutoClifor.NM_CampoBusca;
                    aux[aux.Length - 1].vVL_Busca = "'" + CD_ProdutoClifor.Text + "'";
                    aux[aux.Length - 1].vOperador = "=";
                }
                fBusca.aParamBusca = aux;
                fBusca.NM_DatClass = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item();
                if (fBusca.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if(fBusca.gBusca.CurrentRow != null)
                        if (fBusca.gBusca.CurrentRow.Index > -1)
                        {
                            NR_PedidoClifor.Text = fBusca.gBusca[0, fBusca.gBusca.CurrentRow.Index].Value.ToString();
                            CD_ProdutoClifor.Text = fBusca.gBusca[3, fBusca.gBusca.CurrentRow.Index].Value.ToString();
                            NR_PedidoClifor_Leave(this, e);
                        }
            }
            finally
            {
                fBusca.Dispose();
            }
        }

        private void CD_ProdutoClifor_Leave(object sender, EventArgs e)
        {
            if (CD_ProdutoClifor.Text != "")
            {
                string vColunas = "a." + CD_ProdutoClifor.NM_CampoBusca + "|=|'" + CD_ProdutoClifor.Text + "';" +
                                  "|EXISTS|(select 1 from TB_GRO_DescontoXProduto  x where x.CD_TabelaDesconto = '" + cd_tabeladesconto.Text + "' and x.cd_produto = A.cd_produto)";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_ProdutoClifor, ds_produtoclifor },
                                        new TDatProduto());
            }
            else
            {
                CD_ProdutoClifor.Clear();
                ds_produtoclifor.Clear();
            }
        }

        private void BB_ProdutoClifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100";
            string vParamFixo = "|EXISTS|(select 1 from TB_GRO_DescontoXProduto  x where x.CD_TabelaDesconto = '" + cd_tabeladesconto.Text + "' and x.cd_produto = A.cd_produto)";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ProdutoClifor, ds_produtoclifor },
                                    new TDatProduto(), vParamFixo);
        }

        private void cd_cliforpedido_Leave(object sender, EventArgs e)
        {
            if (cd_cliforpedido.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE("a." + cd_cliforpedido.NM_CampoBusca + "|=|'" + cd_cliforpedido.Text + "'",
                                        new Componentes.EditDefault[] { cd_cliforpedido, nm_cliforpedido, NR_CGCCPFClifor },
                                        new TDatClifor());
            }
            else
            {
                cd_cliforpedido.Clear();
                nm_cliforpedido.Clear();
                NR_CGCCPFClifor.Clear();
            }
        }

        private void bb_cliforpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Clifor|350;" +
                              "a.CD_Clifor|Cód. Clifor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforpedido, nm_cliforpedido, NR_CGCCPFClifor },
                                    new TDatClifor(), "");
        }

        private void cd_clifordesdobro_Leave(object sender, EventArgs e)
        {
            if (cd_clifordesdobro.Text != "")
            {
                string vColunas = "a." + cd_clifordesdobro.NM_CampoBusca + "|=|'" + cd_clifordesdobro.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifordesdobro, nm_clifordesdobro, NR_CGCCPFDesdobro },
                                        new TDatClifor());
            }
            else
            {
                NR_CGCCPFDesdobro.Clear();
                tp_pessoadesdobro.Clear();
            }
        }

        private void cd_clifordesdobro_TextChanged(object sender, EventArgs e)
        {
            cd_enderecodesdobro.Clear();
            ufdesdobro.Clear();
        }

        private void bb_clifordesdobro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Clifor|350;" +
                              "a.CD_Clifor|Cód. Clifor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_clifordesdobro, nm_clifordesdobro, NR_CGCCPFDesdobro },
                                    new TDatClifor(), "");
        }

        private void NR_CGCCPFDesdobro_Leave(object sender, EventArgs e)
        {
            if (NR_CGCCPFDesdobro.Text != "")
            {
                TpBusca[] vBusca = new TpBusca[1];
                vBusca[0].vVL_Busca = "(a.NR_CGC = '"+NR_CGCCPFDesdobro.Text+"')or(a.NR_CPF = '"+NR_CGCCPFDesdobro.Text+"')";
                TDatClifor qtb_clifor = new TDatClifor("SqlCodeBuscaVTBClifor");
                DataTable tabela = qtb_clifor.Buscar(vBusca, 1);
                if(tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        cd_clifordesdobro.Text = tabela.Rows[0]["CD_Clifor"].ToString();
                        cd_clifordesdobro_Leave(this, e);
                    }
                    else
                    {
                        cd_clifordesdobro.Clear();
                        NR_CGCCPFDesdobro.Clear();
                        nm_clifordesdobro.Clear();
                        tp_pessoadesdobro.Clear();
                    }
            }
        }

        private void nm_clifordesdobro_Leave(object sender, EventArgs e)
        {
            if ((cd_clifordesdobro.Text.Equals("")) && (NR_CGCCPFDesdobro.Text.Equals(""))
                && (nm_clifordesdobro.Text.Equals("")))
            {
                cd_clifordesdobro.Text = cd_cliforpedido.Text;
                cd_clifordesdobro_Leave(this, e);
            }
        }

        private void cd_enderecodesdobro_Leave(object sender, EventArgs e)
        {
            if (cd_enderecodesdobro.Text != "")
            {
                string vConsulta = "a." + cd_enderecodesdobro.NM_CampoBusca + "|=|'" + cd_enderecodesdobro.Text + "';" +
                                   "a." + cd_clifordesdobro.NM_CampoBusca + "|=|'" + cd_clifordesdobro.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vConsulta, new Componentes.EditDefault[] { cd_enderecodesdobro, ufdesdobro },
                                        new TDatEndereco());
            }
            else
            {
                cd_enderecodesdobro.Clear();
                ufdesdobro.Clear();
            }
        }

        private void bb_enderecodesdobro_Click(object sender, EventArgs e)
        {
            string vConsulta = "a.DS_Endereco|Endereço|350;" +
                               "a.CD_Endereco|Cód. Endereco|100;" +
                               "b.DS_Cidade|Cidade|150;" +
                               "c.DS_UF|Estado|150";
            string vParamFixo = "a." + cd_clifordesdobro.NM_CampoBusca + "|=|'" + cd_clifordesdobro.Text + "'";
            UtilPesquisa.BTN_BUSCA(vConsulta, new Componentes.EditDefault[] { cd_enderecodesdobro, ufdesdobro },
                                    new TDatEndereco(), vParamFixo);
        }

        private void bb_proximo_Click(object sender, EventArgs e)
        {
            if ((gClassifPsGraos.DataSource is DataTable) && (gClassifPsGraos.CurrentRow != null))
            {
                (gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["PC_Result"] = pc_result.Value.ToString();
                pc_result.Focus();
            }
            this.BindingContext[gClassifPsGraos.DataSource].Position += 1;
            pc_result.Select(0, pc_result.Value.ToString().Length);
        }

        private void bb_anterior_Click(object sender, EventArgs e)
        {
            if ((gClassifPsGraos.DataSource is DataTable) && (gClassifPsGraos.CurrentRow != null))
            {
                (gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["PC_Result"] = pc_result.Value.ToString();
                pc_result.Focus();
            }
            this.BindingContext[gClassifPsGraos.DataSource].Position -= 1;
            pc_result.Select(0, pc_result.Value.ToString().Length);
        }

        private void pc_result_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode.Equals(Keys.Enter)) || (e.KeyCode.Equals(Keys.Escape)))
            {
                if (gClassifPsGraos.DataSource != null)
                    if (gClassifPsGraos.CurrentRow != null)
                    {
                        if ((pc_result.Value > Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["MenorQue"].ToString())) ||
                        (pc_result.Value < Convert.ToDecimal((gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["MaiorQue"].ToString())))
                        {
                            if (MessageBox.Show("Percentual de Desconto esta fora da faixa de valores permitido.\r\n" +
                                            "Faixa permitida: de " + (gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["MaiorQue"].ToString() +
                                            " até " + (gClassifPsGraos.DataSource as DataTable).Rows[gClassifPsGraos.CurrentRow.Index]["MenorQue"].ToString()+"\r\n"+
                                            "Deseja Corrigir o Valor?", "Questionamento",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                            {
                                pc_result.Value = 0;
                                pc_result.Select(0, pc_result.Text.Length);
                            }
                        }
                    }
            }
            if (e.KeyCode.Equals(Keys.Enter))
                bb_proximo_Click(this, e);
            else if (e.KeyCode.Equals(Keys.Escape))
                bb_anterior_Click(this, e);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }
        
        private void bb_tppesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_TPPesagem|Tipo Pesagem|350;" +
                              "TP_Pesagem|TP. Pesagem|100";
            string vParamFixo = "|EXISTS|(Select 1 From TB_DIV_Usuario_X_TpPesagem x Where x.TP_Pesagem = TB_BAL_TPPesagem.TP_Pesagem and x.Login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "');";
            if (tcPesagem.SelectedTab.Equals(tpPesagemAves))
                vParamFixo += "TP_Modo|=|'A'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemCD))
                vParamFixo += "TP_Modo|=|'C'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemDiversos))
                vParamFixo += "TP_Modo|=|'D'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemFazenda))
                vParamFixo += "TP_Modo|=|'F'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
                vParamFixo += "TP_Modo|=|'G'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemRacao))
                vParamFixo += "TP_Modo|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TDatTpPesagem(), vParamFixo);
            TP_Pesagem_Leave(this, e);
        }
        
        private void TP_Pesagem_Leave(object sender, EventArgs e)
        {
            string vColunas = TP_Pesagem.NM_CampoBusca + "|=|'" + TP_Pesagem.Text + "';" +
                              "|EXISTS|(Select 1 From TB_DIV_Usuario_X_TpPesagem x Where x.TP_Pesagem = TB_BAL_TPPesagem.TP_Pesagem and x.Login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "');";
            if (tcPesagem.SelectedTab.Equals(tpPesagemAves))
                vColunas += "TP_Modo|=|'A'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemCD))
                vColunas += "TP_Modo|=|'C'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemDiversos))
                vColunas += "TP_Modo|=|'D'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemFazenda))
                vColunas += "TP_Modo|=|'F'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemGraos))
                vColunas += "TP_Modo|=|'G'";
            else if (tcPesagem.SelectedTab.Equals(tpPesagemRacao))
                vColunas += "TP_Modo|=|'R'";
            DataRow retorno = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TDatTpPesagem());
            if (retorno != null)
            {
                vOrdemPesagem = retorno["OrdemPesagem"].ToString().Trim();
                vTP_MovDefault = retorno["TP_MovDefault"].ToString().Trim();
                vST_SeqManual = retorno["ST_SeqManual"].ToString().Trim();
                ID_Ticket.Enabled = retorno["ST_SeqManual"].ToString().Trim().Equals("S");
                if (retorno["TP_MovDefault"].ToString().Trim().Equals("E"))
                    TP_Movimento.SelectedIndex = 0;
                else if (retorno["TP_MovDefault"].ToString().Trim().Equals("S"))
                    TP_Movimento.SelectedIndex = 1;
            }
            else
            {
                vOrdemPesagem = "";
                vTP_MovDefault = "";
                vST_SeqManual = "";
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
            }
        }
                
        private void ID_Ticket_Leave(object sender, EventArgs e)
        {
            nr_pedido.Focus();
        }
        
        private void TP_Movimento_Leave(object sender, EventArgs e)
        {
            if (!(ID_Ticket.Focus()))
                nr_pedido.Focus();
        }
        #endregion

        private void QTD_DesdobroClifor_Leave(object sender, EventArgs e)
        {
            TDatBalClifor qtb_busca = new TDatBalClifor();
            qtb_busca.CD_Empresa = CD_Empresa.Text;
            qtb_busca.ID_Ticket = ID_Ticket.Value;
            qtb_busca.TP_Pesagem = TP_Pesagem.Text;
            if (qtb_busca.qtdDesdobro() > QTD_DesdobroClifor.Value)
            {
                MessageBox.Show("Erro de Desdobro!");
            }
        }
    }
}