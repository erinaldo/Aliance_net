using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Balanca.Cadastros;
using CamadaNegocio.Balanca.Cadastros;

namespace Balanca.Cadastros
{
    public partial class TFCadTpPesagem : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpPesagem()
        {
            InitializeComponent();
            DTS = bsTpPesagem;

            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("BRUTO/TARA", "BT"));
            cbx.Add(new TDataCombo("TARA/BRUTO", "TB"));
            cbx.Add(new TDataCombo("NORMAL CONFORME TIPO DE MOVIMENTO", "NM"));
            cbx.Add(new TDataCombo("DIRETA BRUTO E TARA", "DI"));
            ordempesagem.DataSource = cbx;
            ordempesagem.DisplayMember = "Display";
            ordempesagem.ValueMember = "Value";

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new TDataCombo("GRAOS", "G"));
            cbx1.Add(new TDataCombo("FAZENDA", "F"));
            cbx1.Add(new TDataCombo("AVULSA", "V"));
            cbx1.Add(new TDataCombo("DIVERSA", "D"));
            tp_modo.DataSource = cbx1;
            tp_modo.DisplayMember = "Display";
            tp_modo.ValueMember = "Value";

            ArrayList cbx2 = new ArrayList();
            cbx2.Add(new TDataCombo("ENTRADA", "E"));
            cbx2.Add(new TDataCombo("SAIDA", "S"));
            tp_movdefault.DataSource = cbx2;
            tp_movdefault.DisplayMember = "Display";
            tp_movdefault.ValueMember = "Value";

            
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
            pSeq.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            if (tcCentral.SelectedIndex == 0)
                pDados.HabilitarControls(value, this.vTP_Modo);
            else
                pSeq.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (tcCentral.SelectedIndex.Equals(0))
                if (pDados.validarCampoObrigatorio())
                    return TCN_CadTpPesagem.Gravar(bsTpPesagem.Current as TRegistro_CadTpPesagem, null);
                else
                    return string.Empty;
            else
                if (pSeq.validarCampoObrigatorio())
                {
                    if (Seq_NotaFiscal.Focused)
                        (bsSeq.Current as TRegistro_CFGSeqPesagem).Seq_idticket = Seq_NotaFiscal.Value;
                    return TCN_CFGSeqPesagem.Gravar(bsSeq.Current as TRegistro_CFGSeqPesagem, null);
                }
                else
                    return string.Empty;
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex.Equals(0))
            {
                TList_CadTpPesagem lista = TCN_CadTpPesagem.Buscar(tp_pesagem.Text,
                                                                   nm_tppesagem.Text,
                                                                   st_seqmanual.Checked,
                                                                   tp_modo.SelectedValue != null ? tp_modo.SelectedValue.ToString() : string.Empty,
                                                                   ordempesagem.SelectedValue != null ? ordempesagem.SelectedValue.ToString() : string.Empty,
                                                                   tp_movdefault.SelectedValue != null ? tp_movdefault.SelectedValue.ToString() : string.Empty,
                                                                   tipo_transbordo.Checked,
                                                                   0, 
                                                                   string.Empty,
                                                                   null);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        bsTpPesagem.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                            bsTpPesagem.Clear();
                    return lista.Count;
                }
                else
                    return 0;
            }
            else
            {
                TList_CFGSeqPesagem lista = TCN_CFGSeqPesagem.Buscar(CD_Empresa.Text,
                                                                     tp_pesagemseq.Text,
                                                                     null);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        bsSeq.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                            bsSeq.Clear();
                    return lista.Count;
                }
                else
                    return 0;
            }
        }

        public override void afterNovo()
        {
            if(tcCentral.SelectedIndex.Equals(0))
            {
                if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                    bsTpPesagem.AddNew();
                base.afterNovo();
                if (!tp_pesagem.Focus())
                    nm_tppesagem.Focus();
            }
            else
            {
                if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                {
                    bsSeq.AddNew();                  
                    base.afterNovo();
                    CD_Empresa.Focus();

                    (bsSeq.Current as TRegistro_CFGSeqPesagem).Tp_pesagem = (bsTpPesagem.Current as TRegistro_CadTpPesagem).Tp_pesagem;
                    (bsSeq.Current as TRegistro_CFGSeqPesagem).Nm_tppesagem = (bsTpPesagem.Current as TRegistro_CadTpPesagem).Nm_tppesagem;
                    bsSeq.ResetCurrentItem();
                }
            }
        }

        public override void afterAltera()
        {
            if (tcCentral.SelectedIndex.Equals(0))
            {
                base.afterAltera();
                nm_tppesagem.Focus();
            }
            else
            {
                if (bsSeq.Count > 0)
                {
                    base.afterAltera();
                    Seq_NotaFiscal.Focus();
                }
                else
                    afterNovo();
            }
        }

        public override void afterCancela()
        {
            tcCentral.SelectedIndex = 0;
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTpPesagem.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (tcCentral.SelectedIndex.Equals(0))
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTpPesagem.Excluir(bsTpPesagem.Current as TRegistro_CadTpPesagem, null);
                        bsTpPesagem.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
            else
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CFGSeqPesagem.Excluir(bsSeq.Current as TRegistro_CFGSeqPesagem, null);
                        bsSeq.RemoveCurrent();
                        pSeq.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        public override void limparControls()
        {
            if (tcCentral.SelectedIndex == 0)
                pDados.LimparRegistro();
            else
                pSeq.LimparRegistro();
        }

        private void TFCadTpPesagem_Load(object sender, EventArgs e)
        {
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedIndex == 1)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if ((bsTpPesagem == null) || (bsTpPesagem.Count <= 0))
                    {
                        MessageBox.Show("Por Favor! Selecione um Tipo Pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        tcCentral.SelectedIndex = 0;
                    }
                }
                else
                    tcCentral.SelectedIndex = 0;
            else
            {
                if (bsSeq != null)
                {
                    string TP_Pesagem_Sequencia = tp_pesagemseq.Text.Trim();
                    string NM_TpPesagem_Sequencia = nm_tppesagemseq.Text.Trim();

                    pSeq.HabilitarControls(false, TTpModo.tm_Standby);
                    pSeq.LimparRegistro();
                    bsSeq.Clear();
                    if (bsTpPesagem.Current != null)
                    {
                        (bsTpPesagem.Current as TRegistro_CadTpPesagem).Tp_pesagem = TP_Pesagem_Sequencia;
                        (bsTpPesagem.Current as TRegistro_CadTpPesagem).Nm_tppesagem = NM_TpPesagem_Sequencia;
                        bsTpPesagem.ResetCurrentItem();
                    }
                }
            }
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                             "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "' or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), "");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void gTpPesagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpPesagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpPesagem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadTpPesagem());
            TList_CadTpPesagem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadTpPesagem(lP.Find(gTpPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadTpPesagem(lP.Find(gTpPesagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpPesagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpPesagem.List as TList_CadTpPesagem).Sort(lComparer);
            bsTpPesagem.ResetBindings(false);
            gTpPesagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_protocolo_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_protocolo|Protocolo Balança|200;a.cd_protocolo|Código|50",
                new Componentes.EditDefault[] { cd_protocolo, ds_protocolo }, new CamadaDados.Diversos.TCD_CadProtocolo(), string.Empty);
        }

        private void cd_protocolo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_protocolo|=|'" + cd_protocolo.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_protocolo, ds_protocolo }, new CamadaDados.Diversos.TCD_CadProtocolo());
        }
    }
}

