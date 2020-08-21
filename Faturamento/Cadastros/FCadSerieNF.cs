using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using Utils;
using System.Collections;
using CamadaDados.Diversos;

namespace Faturamento.Cadastros
{
    public partial class TFCadSerieNF : FormCadPadrao.FFormCadPadrao
    {
        public TFCadSerieNF()
        {
            InitializeComponent();
            DTS = BS_CadSerieNF;
        }
        
        public override void formatZero()
        {
            pDados.set_FormatZero();
            pnl_Sequencia.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            if (tcCentral.SelectedIndex == 0)
            {
                pDados.HabilitarControls(value, this.vTP_Modo);
            }
            else
            {
                pnl_Sequencia.HabilitarControls(value, this.vTP_Modo);
            }

        }

        public override string gravarRegistro()
        {
            if (tcCentral.SelectedIndex.Equals(0))
            {
                if (pDados.validarCampoObrigatorio())
                {
                    if ((BS_CadSerieNF.Current as TRegistro_CadSerieNF).CD_Modelo.Trim().Equals("55") &&
                        (!(BS_CadSerieNF.Current as TRegistro_CadSerieNF).ST_NFEBool))
                    {
                        MessageBox.Show("Não é permitido utilizar modelo 55 para serie nota fiscal que não seja to tipo NFe.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return string.Empty;
                    }
                    if ((BS_CadSerieNF.Current as TRegistro_CadSerieNF).ST_NFEBool &&
                        ((BS_CadSerieNF.Current as TRegistro_CadSerieNF).Tp_serie.Trim().ToUpper() != "S") &&
                        ((BS_CadSerieNF.Current as TRegistro_CadSerieNF).CD_Modelo.Trim() != "55"))
                    {
                        MessageBox.Show("Não é permitido gravar serie do tipo NFe com modelo diferente de 55.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return string.Empty;
                    }
                    return TCN_CadSerieNF.Gravar(BS_CadSerieNF.Current as TRegistro_CadSerieNF, null);
                }
                else
                    return string.Empty;
            }
            else
            {
                if (pnl_Sequencia.validarCampoObrigatorio())
                {
                    if (Seq_NotaFiscal.Focused)
                        (BS_Sequencia.Current as TRegistro_CadSequenciaNF).Seq_NotaFiscal = Seq_NotaFiscal.Value;
                    try
                    {
                        return TCN_CadSequenciaNF.Gravar(BS_Sequencia.Current as TRegistro_CadSequenciaNF, null);
                    }
                    catch (Exception ex)
                    { 
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return string.Empty;
                    }
                }
                else
                    return string.Empty;
            }
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                TList_CadSerieNF lista = TCN_CadSerieNF.Busca(Nr_Serie.Text,
                                                              CD_Modelo.Text,
                                                              DS_SerieNf.Text,
                                                              string.Empty,
                                                              ST_GeraSintegra.SelectedValue != null ? ST_GeraSintegra.SelectedValue.ToString() : "",
                                                              ST_SequenciaAuto.Checked ? "S" : "N",
                                                              string.Empty, null);

                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_CadSerieNF.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                            BS_CadSerieNF.Clear();
                    return lista.Count;
                }
                else

                    return 0;
            }
            else
            {
                TList_CadSequenciaNF lista = TCN_CadSequenciaNF.Busca(NR_Serie_Sequencia_edit.Text, CD_Empresa.Text, null);
                bsSeqInut.DataSource = TCN_SeqInutNFe.Buscar(NR_Serie_Sequencia_edit.Text, null);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_Sequencia.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                            BS_Sequencia.Clear();
                    return lista.Count;
                }
                else

                    return 0;
            }
        }

        public override void afterNovo()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                {
                    BS_CadSerieNF.AddNew();
                    base.afterNovo();
                    if (!Nr_Serie.Focus())
                        DS_SerieNf.Focus();
                }
            }
            else
            {
                if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                {
                    string NR_Serie_Sequencia = (BS_CadSerieNF.Current as TRegistro_CadSerieNF).Nr_Serie.Trim();
                    string DS_Serie_Sequencia = (BS_CadSerieNF.Current as TRegistro_CadSerieNF).DS_SerieNf.Trim();

                    BS_Sequencia.AddNew();                  
                    base.afterNovo();
                    CD_Empresa.Focus();

                    (BS_Sequencia.Current as TRegistro_CadSequenciaNF).Nr_Serie = NR_Serie_Sequencia;
                    (BS_Sequencia.Current as TRegistro_CadSequenciaNF).DS_Serie = DS_Serie_Sequencia;
                    NR_Serie_Sequencia_edit.Text = NR_Serie_Sequencia;
                    DS_Serie_Sequencia_edit.Text = DS_Serie_Sequencia;

                }
            }

        }

        public override void afterCancela()
        {
            tcCentral.SelectedIndex = 0;
            
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadSerieNF.RemoveCurrent();
            
        }

        public override void afterAltera()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                base.afterAltera();
                if (vTP_Modo == TTpModo.tm_Edit)
                    DS_SerieNf.Focus();
            }
            else
            {
                if (BS_Sequencia.Count > 0)
                {
                    base.afterAltera();
                    if (vTP_Modo == TTpModo.tm_Edit)
                        CD_Empresa.Focus();
                }
                else
                {
                    afterNovo();
                }

            }
        }

        public override void limparControls()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                pDados.LimparRegistro();
            }
            else
            {
                pnl_Sequencia.LimparRegistro();
            }
        }
        
        public override void excluirRegistro()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadSerieNF.Excluir(BS_CadSerieNF.Current as TRegistro_CadSerieNF, null);
                        BS_CadSerieNF.RemoveCurrent();
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
                        TCN_CadSequenciaNF.Excluir(BS_Sequencia.Current as TRegistro_CadSequenciaNF, null);
                        BS_Sequencia.RemoveCurrent();
                        pnl_Sequencia.LimparRegistro();
                        afterBusca();
                    }
                }
            }

        }

        private void TFCad_SerieNF_Load(object sender, EventArgs e)
        {
            panelDados3.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("S - Sim", "S"));
            CBox1.Add(new Utils.TDataCombo("N - Não", "N"));
            ST_GeraSintegra.DataSource = CBox1;
            ST_GeraSintegra.DisplayMember = "Display";
            ST_GeraSintegra.ValueMember = "Value";

            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("PRODUTO", "P"));
            cbx.Add(new Utils.TDataCombo("SERVIÇO", "S"));
            cbx.Add(new Utils.TDataCombo("MISTO - PRODUTO E SERVIÇO", "M"));

            tp_serie.DataSource = cbx;
            tp_serie.DisplayMember = "Display";
            tp_serie.ValueMember = "Value";
        }

        private void BB_Modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Modelo|Descrição Modelo|350;" +
                              "CD_Modelo|Cód. Modelo|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Modelo, DS_Modelo },
                                    new TCD_CadModeloNF(), "");
        }

        private void CD_Modelo_Leave(object sender, EventArgs e)
        {
            if (CD_Modelo.Text.Trim() != "")
            {
                string vColunas = CD_Modelo.NM_CampoBusca + "|=|'" + CD_Modelo.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Modelo, DS_Modelo },
                                        new TCD_CadModeloNF());
            }
            else
                DS_Modelo.Clear();
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
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), "");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());
        }
             
        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedIndex == 1)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if ((BS_CadSerieNF == null) || (BS_CadSerieNF.Count <= 0))
                    {
                        MessageBox.Show("Por Favor! Selecione uma Série de Nota Fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        tcCentral.SelectedIndex = 0;
                    }
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                }
            }
            else
            {
                if (BS_Sequencia != null)
                {

                    string NR_Serie_Sequencia = NR_Serie_Sequencia_edit.Text.Trim();
                    string DS_Serie_Sequencia = DS_Serie_Sequencia_edit.Text.Trim();

                    pnl_Sequencia.HabilitarControls(false, TTpModo.tm_Standby);
                    pnl_Sequencia.LimparRegistro(); 
                    BS_Sequencia.Clear();
                    if (BS_CadSerieNF.Current != null)
                    {
                        (BS_CadSerieNF.Current as TRegistro_CadSerieNF).Nr_Serie = NR_Serie_Sequencia;
                        (BS_CadSerieNF.Current as TRegistro_CadSerieNF).DS_SerieNf = DS_Serie_Sequencia;
                        BS_CadSerieNF.RemoveCurrent();
                    }
                }
            }           
        }
    }
}