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
using LeituraSerial;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadProtocolo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadProtocolo()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("NONE", "0"));
            cbx.Add(new TDataCombo("MARK", "1"));
            cbx.Add(new TDataCombo("EVEN", "2"));
            cbx.Add(new TDataCombo("ODD", "3"));
            cbx.Add(new TDataCombo("SPACE", "4"));
            parity.DataSource = cbx;
            parity.DisplayMember = "Display";
            parity.ValueMember = "Value";

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new TDataCombo("NONE", "0"));
            cbx1.Add(new TDataCombo("REQUESTTOSEND", "1"));
            cbx1.Add(new TDataCombo("REQUESTTOSENDXONXOFF", "2"));
            cbx1.Add(new TDataCombo("XONXOFF", "3"));
            handshake.DataSource = cbx1;
            handshake.DisplayMember = "Display";
            handshake.ValueMember = "Value";
        }

        public override void formatZero()
        {
            pCadastro.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pCadastro.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pCadastro.validarCampoObrigatorio())
            {
                if (st_discartarnull.Checked && string.IsNullOrEmpty(nm_dll.Text))
                {
                    MessageBox.Show("Obrigatório informar nome dll.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nm_dll.Focus();
                    return string.Empty;
                }
                return TCN_CadProtocolo.Gravar(bSource.Current as TRegistro_CadProtocolo, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_RegCadProtocolo lista = TCN_CadProtocolo.Busca(CD_Protocolo.Text, 
                                                                 DS_Protocolo.Text, 
                                                                 string.Empty,
                                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bSource.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bSource.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bSource.AddNew();
                base.afterNovo();
                if (!(CD_Protocolo.Focus()))
                    DS_Protocolo.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bSource.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            DS_Protocolo.Focus();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadProtocolo.Excluir(bSource.Current as TRegistro_CadProtocolo, null);
                    bSource.RemoveCurrent();
                    pCadastro.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void afterPrint()
        {
            if (bSource.Current!= null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bSource;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + this.Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else { MessageBox.Show("Não Existe Registro Para ser Impresso No Relatório!"); }
        
        }             

        private void button1_Click(object sender, EventArgs e)
        {
            using (LeituraSerial.TFLeituraSerial fSerial = new TFLeituraSerial())
            {
                fSerial.rProtocolo = bSource.Current as TRegistro_CadProtocolo;
                fSerial.ShowDialog();
            }
        }

        private void TFCadProtocolo_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            nm_dll.CharacterCasing = CharacterCasing.Normal;
        }
    }
}

