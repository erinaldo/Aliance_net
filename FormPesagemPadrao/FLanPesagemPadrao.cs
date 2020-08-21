using System;
using System.Windows.Forms;
using Utils;
using FormBusca;
using LeituraSerial;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace FormPesagemPadrao
{
    public partial class TFLanPesagemPadrao : Form
    {
        protected BindingSource DTS;
        protected bool Altera_Relatorio = false;
        protected bool St_PesagemClassif = false;
        public bool vST_FecharPesagem = false;
        private TTpModo tpModo;
        public TTpModo TpModo
        {
            get { return tpModo; }
            set { tpModo = value; }
        }

        private string vTP_MovDefault;
        public string VTP_MovDefault
        {
            get { return vTP_MovDefault; }
            set { vTP_MovDefault = value; }
        }

        private string vOrdemPesagem;
        public string VOrdemPesagem
        {
            get { return vOrdemPesagem; }
            set { vOrdemPesagem = value; }
        }

        private string vST_SeqManual;
        public string VST_SeqManual
        {
            get { return vST_SeqManual; }
            set { vST_SeqManual = value; }
        }

        public TFLanPesagemPadrao()
        {
            InitializeComponent();
            tpModo = TTpModo.tm_Standby;            
            vOrdemPesagem = string.Empty;
            vST_SeqManual = string.Empty;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ENTRADA", "E"));
            cbx.Add(new Utils.TDataCombo("SAIDA", "S"));
            TP_Movimento.DataSource = cbx;
            TP_Movimento.DisplayMember = "Display";
            TP_Movimento.ValueMember = "Value";
        }
        
        public virtual void afterNovo()
        {
            TpModo = TTpModo.tm_Insert;
            modoBotoes();                        
        }

        public virtual void afterAltera()
        {
            TpModo = TTpModo.tm_Edit;
            visibleBotoes(false, false, true, true, false, false, false, false, false, false, false, false, false);            
            configTPPesagem();
            pTopEsquerdo.HabilitarControls(false, TpModo);
            vST_FecharPesagem = false;
            ps_bruto.Enabled = TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR DIGITAR PESO MANUALMENTE", null) && (ps_bruto.Value > 0);
            ps_tara.Enabled = TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR DIGITAR PESO MANUALMENTE", null) && (ps_tara.Value > 0);
            dt_bruto.Enabled = true;
            dt_tara.Enabled = true;
        }

        public virtual void afterCancela()
        { }

        public virtual void afterGrava()
        {
            if (ps_bruto.Focused)
                if (!(sairPS_Bruto(true)))
                    return;
            if (ps_tara.Focused)
                if (!(sairPS_Tara(true)))
                    return;
            if (!(validaCampoPeso()))
                throw new Exception("Falta Informar Pesagem!");
            ps_bruto.Enabled = false;
            ps_tara.Enabled = false;
            dt_bruto.Enabled = false;
            dt_tara.Enabled = false;
        }

        public virtual void afterBusca()
        {

        }

        public virtual void afterImprime()
        {

        }

        public virtual void afterExclui()
        { }

        public virtual void AplicarPesagem()
        { }

        public virtual void configTPPesagem()
        { }

        public virtual void ProcessarTicketReprovados()
        { }

        public virtual void RefugarTicket()
        { }

        public virtual void DesdobrarTicket()
        { }

        public virtual void ProcessarDesdobroEspecial()
        { }

        public virtual void TrocarContrato()
        { }

        public virtual void CapturarImagem()
        { }

        private void visibleBotoes(bool vNovo, bool vAlterar, bool vGravar,
                                    bool vCancelar, bool vExcluir, bool vImprimir,
                                    bool vCapturaAuto, bool vCapturaManual, bool vBuscar, 
                                    bool vAplicar, bool vSt_ProcessarRep, bool vSt_refugar,
                                    bool vSt_DesdobroEspecial)
        {
            BB_Novo.Visible = vNovo;
            BB_Alterar.Visible = vAlterar;
            BB_Gravar.Visible = vGravar;
            BB_Cancelar.Visible = vCancelar;
            BB_Excluir.Visible = vExcluir;
            BB_Imprimir.Visible = vImprimir;
            BB_CapturaAutomatico.Visible = vCapturaAuto;
            BB_CapturaManual.Visible = vCapturaManual;
            BB_Buscar.Visible = vBuscar;
            bb_aplicarticket.Visible = vAplicar;
            bb_processarticketrecusado.Visible = vSt_ProcessarRep;
            bb_recusarticket.Visible = vSt_refugar;
            bb_desdobrarticket.Visible = vSt_DesdobroEspecial;
            bb_desdobroespecial.Visible = vSt_DesdobroEspecial;
            bb_trocarcontrato.Visible = vSt_DesdobroEspecial;
        }

        protected void modoBotoes()
        {
            
            if (tpModo == TTpModo.tm_Insert)
                visibleBotoes(false, false, true, true, false, false, true,
                                        (this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA") || CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR DIGITAR PESO MANUALMENTE", null)),
                                        false, false, false, false, false);
            else if (tpModo == TTpModo.tm_Edit)
                visibleBotoes(false, false, true, true, false, false,
                                        (!((ps_bruto.Value > 0) && (ps_tara.Value > 0))),
                                        (this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA") || ((!((ps_bruto.Value > 0) && (ps_tara.Value > 0)))
                                        && (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR DIGITAR PESO MANUALMENTE", null)))),
                                        false, false, false, false, false);
            else if (tpModo == TTpModo.tm_Standby)
                visibleBotoes(true, 
                              CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR ALTERACAO DE PESAGEM", null),
                              false, 
                              false, 
                              CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR EXCLUSAO DE PESAGEM", null),
                              true, 
                              false, 
                              false, 
                              true, 
                              ((!this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA")) && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR APLICAR PESAGEM", null)),
                              ((!this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA")) && (!this.Name.Trim().ToUpper().Equals("TFLANPESAGEMDIVERSAS")) && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR PROCESSAR TICKET REFUGADO", null)),
                              ((!this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA")) && (!this.Name.Trim().ToUpper().Equals("TFLANPESAGEMDIVERSAS")) && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR REFUGAR TICKET", null)),
                              !this.Name.Trim().ToUpper().Equals("TFLANPESAGEMAVULSA") && !this.Name.Trim().ToUpper().Equals("TFLANPESAGEMDIVERSAS"));
        }

        private bool validaCampoPeso()
        {
            bool retorno = true;
            if (!(TP_Movimento.Text.Trim().ToUpper().Equals("TROCA NOTAS")))
            {
                if ((tpModo == TTpModo.tm_Insert) || St_PesagemClassif)
                {
                    if (TP_Movimento.Text.Trim().ToUpper().Equals("ENTRADA"))
                    {
                        if (ps_bruto.Value == 0)
                        {
                            MessageBox.Show("Falta peso bruto para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            retorno = false;
                        }
                    }
                    else if (TP_Movimento.Text.Trim().ToUpper().Equals("SAIDA"))
                    {
                        if (ps_tara.Value == 0)
                        {
                            MessageBox.Show("Falta peso tara para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            retorno = false;
                        }
                    }
                }
                else if (tpModo == TTpModo.tm_Edit)
                {
                    if (TP_Movimento.Text.Trim().ToUpper().Equals("ENTRADA") && vST_FecharPesagem)
                    {
                        if (ps_tara.Value == 0)
                        {
                            MessageBox.Show("Falta peso tara para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            retorno = false;
                        }
                    }
                    else if (TP_Movimento.Text.Trim().ToUpper().Equals("SAIDA") && vST_FecharPesagem)
                    {
                        if (ps_bruto.Value == 0)
                        {
                            MessageBox.Show("Falta peso bruto para gravar pesagem.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            retorno = false;
                        }
                    }
                }
            }
            return retorno;
        }

        private bool sairPS_Bruto(bool St_manual)
        {
            bool retorno = true;
            //Buscar configuracao peso tara minimo tipo pesagem
            object obj = new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_pesagem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Pesagem.Text.Trim() + "'"
                    }
                }, "a.ps_min_bruto");
            decimal ps_min_bruto = decimal.Zero;
            try
            {
                ps_min_bruto = Convert.ToDecimal(obj.ToString());
            }
            catch
            { }
            if ((ps_min_bruto.Equals(decimal.Zero) ? false : ps_bruto.Value < ps_min_bruto) && (ps_bruto.Value > 0))
            {
                if (MessageBox.Show("Peso bruto menor que " + ps_min_bruto.ToString() + " Kg. Confirma captura mesmo assim?",
                                    "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) ==
                                    System.Windows.Forms.DialogResult.No)
                {
                    ps_bruto.Value = 0;
                    ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value - ps_desdobro.Value;
                    ps_bruto.Enabled = false;
                    return false;
                }
                else
                    TP_Captura_Bruto.Clear();
            }

            ps_bruto.Enabled = false;
            ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value - ps_desdobro.Value;
            dt_bruto.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss");
            login_PsBruto.Text = Utils.Parametros.pubLogin.ToUpper().Trim();
            TP_Captura_Bruto.Text = St_manual ? "M" : "A";
            if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
            {
                if (ps_bruto.Value < ps_tara.Value)
                {
                    MessageBox.Show("Peso tara não pode ser maior que peso bruto.",
                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ps_tara.Value = 0;
                    dt_tara.Clear();
                    login_PsTara.Clear();
                    tp_captura_tara.Clear();
                    return false;
                }
            }
            if (ps_tara.Enabled)
            {
                ps_bruto.Enabled = true;
                ps_tara.Focus();
            }

            return retorno;
        }

        private bool sairPS_Tara(bool St_manual)
        {
            bool retorno = true;
            //Buscar configuracao peso tara minimo tipo pesagem
            object obj = new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_pesagem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Pesagem.Text.Trim() + "'"
                    }
                }, "a.ps_min_tara");
            decimal ps_min_tara = decimal.Zero;
            try
            {
                ps_min_tara = Convert.ToDecimal(obj.ToString());
            }
            catch
            { }
            if ((ps_min_tara.Equals(decimal.Zero) ? false : ps_tara.Value < ps_min_tara) && (ps_tara.Value > 0))
            {
                if (MessageBox.Show("Peso tara menor que "+ ps_min_tara.ToString() + " Kg. Confirma captura mesmo assim?",
                                    "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    ps_tara.Value = 0;
                    ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value - ps_desdobro.Value;
                    ps_tara.Enabled = false;
                    return false;
                }
                else
                    tp_captura_tara.Clear();
            }
            ps_tara.Enabled = false;
            ps_liquido.Value = ps_bruto.Value - ps_tara.Value - ps_desconto.Value - ps_desdobro.Value;
            dt_tara.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss");
            login_PsTara.Text = Utils.Parametros.pubLogin.ToUpper().Trim();
            tp_captura_tara.Text = St_manual ? "M" : "A";
            if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
            {
                if (ps_bruto.Value < ps_tara.Value)
                {
                    MessageBox.Show("Peso tara não pode ser maior que peso bruto.",
                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ps_tara.Value = 0;
                    dt_tara.Clear();
                    login_PsTara.Clear();
                    tp_captura_tara.Clear();
                    return false;
                }
            }
            if (ps_bruto.Enabled)
            {
                ps_tara.Enabled = true;                
            }
            return retorno;
        }

        private void capturaPeso(ToolStripButton sender)
        {
            if (string.IsNullOrEmpty(TP_Pesagem.Text.Trim()))
            {
                MessageBox.Show("Obrigatório informar antes o tipo de pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (TP_Movimento.Text.ToUpper().Equals("TROCA NOTAS"))
            {
                MessageBox.Show("Troca de notas não permite captura de peso!",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string vTP_Mov = string.Empty;
            if (TP_Movimento.Text.ToUpper().Equals("ENTRADA"))
                vTP_Mov = "E";
            else if (TP_Movimento.Text.ToUpper().Equals("SAIDA"))
                vTP_Mov = "S";

            if (vTP_Mov.ToUpper().Equals(vTP_MovDefault.ToUpper()))
            {
                if ((vOrdemPesagem.Trim().Length == 0) || (vOrdemPesagem.ToUpper().Trim().Equals("NM")))
                {
                    if (TP_Movimento.Text.ToUpper().Equals("ENTRADA"))
                    {
                        if ((tpModo == TTpModo.tm_Insert) || (ps_bruto.Value.Equals(0)))
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Captura_Bruto.Clear();
                                dt_bruto.Clear();
                                login_PsBruto.Clear();
                                ps_bruto.Enabled = true;
                                dt_bruto.Enabled = true;
                                ps_bruto.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                if(cbProtocolo.SelectedItem == null)
                                {
                                    MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbProtocolo.Focus();
                                    return;
                                }
                                using (TFLeituraSerial fSerial = new TFLeituraSerial())
                                {
                                    fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                    if (fSerial.ShowDialog() == DialogResult.OK)
                                    {
                                        ps_bruto.Value = fSerial.Ps_capturado;
                                        sairPS_Bruto(false);
                                    }
                                }
                            }
                        }
                        else if (tpModo == TTpModo.tm_Edit)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                tp_captura_tara.Clear();
                                dt_tara.Clear();
                                login_PsTara.Clear();
                                ps_tara.Enabled = true;
                                dt_tara.Enabled = true;
                                ps_tara.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                if (cbProtocolo.SelectedItem == null)
                                {
                                    MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbProtocolo.Focus();
                                    return;
                                }
                                using (TFLeituraSerial fSerial = new TFLeituraSerial())
                                {
                                    fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                    if (fSerial.ShowDialog() == DialogResult.OK)
                                    {
                                        ps_tara.Value = fSerial.Ps_capturado;
                                        sairPS_Tara(false);
                                    }
                                }
                            }
                        }
                    }
                    else if (TP_Movimento.Text.ToUpper().Equals("SAIDA"))
                    {
                        if ((tpModo == TTpModo.tm_Insert) || (ps_tara.Value.Equals(0)))
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                tp_captura_tara.Clear();
                                dt_tara.Clear();
                                login_PsTara.Clear();
                                ps_tara.Enabled = true;
                                dt_tara.Enabled = true;
                                ps_tara.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                if (cbProtocolo.SelectedItem == null)
                                {
                                    MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbProtocolo.Focus();
                                    return;
                                }
                                using (TFLeituraSerial fSerial = new TFLeituraSerial())
                                {
                                    fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                    if (fSerial.ShowDialog() == DialogResult.OK)
                                    {
                                        ps_tara.Value = fSerial.Ps_capturado;
                                        sairPS_Tara(false);
                                    }
                                }
                            }
                        }
                        else if (tpModo == TTpModo.tm_Edit)
                        {
                            if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                            {
                                TP_Captura_Bruto.Clear();
                                dt_bruto.Clear();
                                login_PsBruto.Clear();
                                ps_bruto.Enabled = true;
                                dt_bruto.Enabled = true;
                                ps_bruto.Focus();
                            }
                            else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                            {
                                if (cbProtocolo.SelectedItem == null)
                                {
                                    MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbProtocolo.Focus();
                                    return;
                                }
                                using (TFLeituraSerial fSerial = new TFLeituraSerial())
                                {
                                    fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                    if (fSerial.ShowDialog() == DialogResult.OK)
                                    {
                                        ps_bruto.Value = fSerial.Ps_capturado;
                                        sairPS_Bruto(false);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (vOrdemPesagem.ToUpper().Trim().Equals("DI"))
                {
                    if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                    {
                        if (ps_bruto.Value.Equals(decimal.Zero))
                        {
                            ps_bruto.Enabled = true;
                            dt_bruto.Enabled = true;
                            TP_Captura_Bruto.Clear();
                            login_PsBruto.Clear();
                            dt_bruto.Clear();
                        }
                        if (ps_tara.Value.Equals(decimal.Zero))
                        {
                            ps_tara.Enabled = true;
                            dt_tara.Enabled = true;
                            tp_captura_tara.Clear();
                            login_PsTara.Clear();
                            dt_tara.Clear();
                        }
                        if (!ps_bruto.Focus())
                            ps_tara.Focus();
                    }
                    else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                    {
                        if (cbProtocolo.SelectedItem == null)
                        {
                            MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbProtocolo.Focus();
                            return;
                        }
                        using (TFLeituraSerial fSerial = new TFLeituraSerial())
                        {
                            fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                            if (fSerial.ShowDialog() == DialogResult.OK)
                            {
                                if (ps_bruto.Value.Equals(decimal.Zero))
                                {
                                    ps_bruto.Value = fSerial.Ps_capturado;
                                    ps_bruto.Enabled = false;
                                    sairPS_Bruto(false);
                                }
                                else
                                {
                                    ps_tara.Value = fSerial.Ps_capturado;
                                    ps_tara.Enabled = false;
                                    sairPS_Tara(false);
                                }
                            }
                        }
                    }
                
                }
                else if (vOrdemPesagem.ToUpper().Trim().Equals("BT"))
                {
                    if ((tpModo == TTpModo.tm_Insert) || (ps_bruto.Value.Equals(0)))
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            dt_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_bruto.Value = fSerial.Ps_capturado;
                                    sairPS_Bruto(false);
                                }
                            }
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            dt_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_tara.Value = fSerial.Ps_capturado;
                                    sairPS_Tara(false);
                                }
                            }
                        }
                    }
                }
                else if (vOrdemPesagem.ToUpper().Equals("TB"))
                {
                    if ((tpModo == TTpModo.tm_Insert) || (ps_tara.Value.Equals(0)))
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            tp_captura_tara.Clear();
                            login_PsTara.Clear();
                            dt_tara.Clear();
                            ps_tara.Enabled = true;
                            dt_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_tara.Value = fSerial.Ps_capturado;
                                    sairPS_Tara(false);
                                }
                            }
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            dt_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_bruto.Value = fSerial.Ps_capturado;
                                    sairPS_Bruto(false);
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                if (TP_Movimento.Text.ToUpper().Equals("ENTRADA"))
                {
                    if ((tpModo == TTpModo.tm_Insert) || (ps_bruto.Value.Equals(0)))
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            dt_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_bruto.Value = fSerial.Ps_capturado;
                                    sairPS_Bruto(false);
                                }
                            }
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            dt_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_tara.Value = fSerial.Ps_capturado;
                                    sairPS_Tara(false);
                                }
                            }
                        }
                    }
                }
                else if (TP_Movimento.Text.ToUpper().Equals("SAIDA"))
                {
                    if ((tpModo == TTpModo.tm_Insert) || (ps_tara.Value.Equals(0)))
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            tp_captura_tara.Clear();
                            dt_tara.Clear();
                            login_PsTara.Clear();
                            ps_tara.Enabled = true;
                            dt_tara.Enabled = true;
                            ps_tara.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_tara.Value = fSerial.Ps_capturado;
                                    sairPS_Tara(false);
                                }
                            }
                        }
                    }
                    else if (tpModo == TTpModo.tm_Edit)
                    {
                        if (sender.Name.ToUpper().Equals("BB_CAPTURAMANUAL"))
                        {
                            TP_Captura_Bruto.Clear();
                            dt_bruto.Clear();
                            login_PsBruto.Clear();
                            ps_bruto.Enabled = true;
                            dt_bruto.Enabled = true;
                            ps_bruto.Focus();
                        }
                        else if (sender.Name.ToUpper().Equals("BB_CAPTURAAUTOMATICO"))
                        {
                            if (cbProtocolo.SelectedItem == null)
                            {
                                MessageBox.Show("Obrigatório selecionar BALANÇA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbProtocolo.Focus();
                                return;
                            }
                            using (TFLeituraSerial fSerial = new TFLeituraSerial())
                            {
                                fSerial.rProtocolo = cbProtocolo.SelectedItem as TRegistro_CadProtocolo;
                                if (fSerial.ShowDialog() == DialogResult.OK)
                                {
                                    ps_bruto.Value = fSerial.Ps_capturado;
                                    sairPS_Bruto(false);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TFLanPesagemPadrao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && BB_Imprimir.Visible)
                afterImprime();
            else if (e.KeyCode.Equals(Keys.F9) && bb_aplicarticket.Visible)
                this.AplicarPesagem();
            else if (e.KeyCode.Equals(Keys.F10) && bb_processarticketrecusado.Visible)
                this.ProcessarTicketReprovados();
            else if (e.Control && e.KeyCode.Equals(Keys.R) && bb_recusarticket.Visible)
                this.RefugarTicket();
            else if (e.Control && e.KeyCode.Equals(Keys.D) && bb_desdobrarticket.Visible)
                this.DesdobrarTicket();
            else if (e.Control && e.KeyCode.Equals(Keys.E) && bb_desdobroespecial.Visible)
                this.ProcessarDesdobroEspecial();
            else if (e.KeyCode.Equals(Keys.F11) && BB_CapturaManual.Visible)
                capturaPeso(BB_CapturaManual);
            else if (e.KeyCode.Equals(Keys.F12) && BB_CapturaAutomatico.Visible)
                capturaPeso(BB_CapturaAutomatico);
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar layout.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }
                
        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void ID_Ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && (!string.IsNullOrEmpty(TP_Pesagem.Text)))
            {
                ID_Ticket.Text = CamadaNegocio.Balanca.Cadastros.TCN_CFGSeqPesagem.GerarIdTicket(
                                    new CamadaDados.Balanca.Cadastros.TRegistro_CFGSeqPesagem()
                                    {
                                        Cd_empresa = CD_Empresa.Text,
                                        Tp_pesagem = TP_Pesagem.Text
                                    }, null).ToString();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_CapturaManual_Click(object sender, EventArgs e)
        {
            capturaPeso(BB_CapturaManual);
        }

        private void BB_CapturaAutomatico_Click(object sender, EventArgs e)
        {
            capturaPeso(BB_CapturaAutomatico);
        }

        private void ps_bruto_Leave(object sender, EventArgs e)
        {
            sairPS_Bruto(true);
        }

        private void ps_tara_Leave(object sender, EventArgs e)
        {
            sairPS_Tara(true);
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterImprime();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLanPesagemPadrao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void pTopEsquerdo_Leave(object sender, EventArgs e)
        {
            if ((ps_bruto.Enabled) && (ps_tara.Enabled))
                ps_bruto.Focus();
        }

        private void BB_Aplicar_Click(object sender, EventArgs e)
        {
            this.AplicarPesagem();
        }

        private void BB_ProcessarTicketRep_Click(object sender, EventArgs e)
        {
            this.ProcessarTicketReprovados();
        }

        private void BB_Refugar_Click(object sender, EventArgs e)
        {
            this.RefugarTicket();
        }

        private void lklImagem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CapturarImagem();
        }

        private void dt_bruto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_bruto.Text.SoNumero()))
                try
                {
                    Convert.ToDateTime(dt_bruto.Text);
                }
                catch
                {
                    MessageBox.Show("Data Bruto invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_bruto.Focus();
                }
        }

        private void dt_tara_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_tara.Text.SoNumero()))
                try
                {
                    Convert.ToDateTime(dt_tara.Text);
                }
                catch
                {
                    MessageBox.Show("Data Tara invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_tara.Focus();
                }
        }

        private void bb_desdobrar_Click(object sender, EventArgs e)
        {
            this.DesdobrarTicket();
        }

        private void bb_aplicarticket_Click(object sender, EventArgs e)
        {
            this.AplicarPesagem();
        }

        private void bb_desdobrarticket_Click(object sender, EventArgs e)
        {
            this.DesdobrarTicket();
        }

        private void bb_recusarticket_Click(object sender, EventArgs e)
        {
            this.RefugarTicket();
        }

        private void bb_processarticketrecusado_Click(object sender, EventArgs e)
        {
            this.ProcessarTicketReprovados();
        }

        private void bb_desdobroespecial_Click(object sender, EventArgs e)
        {
            this.ProcessarDesdobroEspecial();
        }

        private void bb_trocarcontrato_Click(object sender, EventArgs e)
        {
            this.TrocarContrato();
        }
    }
}