using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using FormBusca;


namespace Financeiro.Cadastros
{
    public partial class FCadCFGBanco : FormCadPadrao.FFormCadPadrao
    {
        public FCadCFGBanco()
        {
            InitializeComponent();
            DTS = bsCFGBanco;
            ArrayList cb = new ArrayList();
            cb.Add(new Utils.TDataCombo("ACEITE", "A"));
            cb.Add(new Utils.TDataCombo("NAO ACEITE", "N"));
            aceite_sn.DataSource = cb;
            aceite_sn.DisplayMember = "Display";
            aceite_sn.ValueMember = "Value";

            ArrayList cb1 = new ArrayList();
            cb1.Add(new Utils.TDataCombo("CHEQUE", "1"));
            cb1.Add(new Utils.TDataCombo("DUPLICATA MERCANTIL", "2"));
            cb1.Add(new Utils.TDataCombo("DUPLICATA MERCANTIL INDICAÇÃO", "3"));
            cb1.Add(new Utils.TDataCombo("DUPLICATA SERVIÇO", "4"));
            cb1.Add(new Utils.TDataCombo("DUPLICATA SERVIÇO INDICAÇÃO", "5"));
            cb1.Add(new Utils.TDataCombo("DUPLICATA RURAL", "6"));
            cb1.Add(new Utils.TDataCombo("LETRA CAMBIO", "7"));
            cb1.Add(new Utils.TDataCombo("NOTA CRÉDITO COMERCIAL", "8"));
            cb1.Add(new Utils.TDataCombo("NOTA CRÉDITO EXPORTAÇÃO", "9"));
            cb1.Add(new Utils.TDataCombo("NOTA CRÉDITO INDUSTRIAL", "10"));
            cb1.Add(new Utils.TDataCombo("NOTA CRÉDITO RURAL", "11"));
            cb1.Add(new Utils.TDataCombo("NOTA PROMISSÓRIA", "12"));
            cb1.Add(new Utils.TDataCombo("NOTA PROMISSÓRIA RURAL", "13"));
            cb1.Add(new Utils.TDataCombo("TRIPLICATA MERCANTIL", "14"));
            cb1.Add(new Utils.TDataCombo("TRIPLICATA SERVIÇO", "15"));
            cb1.Add(new Utils.TDataCombo("NOTA SEGURO", "16"));
            cb1.Add(new Utils.TDataCombo("RECIBO", "17"));
            cb1.Add(new Utils.TDataCombo("FATURA", "18"));
            cb1.Add(new Utils.TDataCombo("NOTA DÉBITO", "19"));
            cb1.Add(new Utils.TDataCombo("APOLICE SEGURO", "20"));
            especiedocumento.DataSource = cb1;
            especiedocumento.DisplayMember = "Display";
            especiedocumento.ValueMember = "Value";

            ArrayList cb2 = new ArrayList();
            cb2.Add(new Utils.TDataCombo("COM REGISTRO", "CR"));
            cb2.Add(new Utils.TDataCombo("SEM REGISTRO", "SR"));
            tp_cobranca.DataSource = cb2;
            tp_cobranca.DisplayMember = "Display";
            tp_cobranca.ValueMember = "Value";

            ArrayList cb3 = new ArrayList();
            cb3.Add(new Utils.TDataCombo("NORMAL", "N"));
            cb3.Add(new Utils.TDataCombo("CARNE", "C"));
            cbLayoutBloqueto.DataSource = cb3;
            cbLayoutBloqueto.DisplayMember = "Display";
            cbLayoutBloqueto.ValueMember = "Value";

            ArrayList cb4 = new ArrayList();
            cb4.Add(new TDataCombo("LAYOUT CNAB 240", "2"));
            cb4.Add(new TDataCombo("LAYOUT CNAB 400", "4"));
            tp_layoutremessa.DataSource = cb4;
            tp_layoutremessa.DisplayMember = "Display";
            tp_layoutremessa.ValueMember = "Value";

            ArrayList cb5 = new ArrayList();
            cb5.Add(new TDataCombo("LAYOUT CNAB 240", "2"));
            cb5.Add(new TDataCombo("LAYOUT CNAB 400", "4"));
            tp_layoutretorno.DataSource = cb5;
            tp_layoutretorno.DisplayMember = "Display";
            tp_layoutretorno.ValueMember = "Value";

            ArrayList cb6 = new ArrayList();
            cb6.Add(new TDataCombo("R$", "V"));
            cb6.Add(new TDataCombo("%", "P"));
            tp_jurodia.DataSource = cb6;
            tp_jurodia.DisplayMember = "Display";
            tp_jurodia.ValueMember = "Value";

            ArrayList cb7 = new ArrayList();
            cb7.Add(new TDataCombo("R$", "V"));
            cb7.Add(new TDataCombo("%", "P"));
            tp_desconto.DataSource = cb7;
            tp_desconto.DisplayMember = "Display";
            tp_desconto.ValueMember = "Value";

            ArrayList cb8 = new ArrayList();
            cb8.Add(new TDataCombo("R$", "V"));
            cb8.Add(new TDataCombo("%", "P"));
            tp_multa.DataSource = cb8;
            tp_multa.DisplayMember = "Display";
            tp_multa.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((pc_jurodiaEditFloat.Value > decimal.Zero) && (tp_jurodia.SelectedValue == null))
                {
                    MessageBox.Show("Obrigatorio selecionar tipo juro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_jurodia.Focus();
                    return string.Empty;
                }
                if ((pc_descontoEditFloat.Value > decimal.Zero) && (tp_desconto.SelectedValue == null))
                {
                    MessageBox.Show("Obrigatorio selecionar tipo desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_desconto.Focus();
                    return string.Empty;
                }
                if ((pc_multa.Value > decimal.Zero) && (tp_multa.SelectedValue == null))
                {
                    MessageBox.Show("Obrigatorio selecionar tipo multa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_multa.Focus();
                    return string.Empty;
                }
                return TCN_CadCFGBanco.Gravar(bsCFGBanco.Current as TRegistro_CadCFGBanco, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadCFGBanco lista = TCN_CadCFGBanco.Buscar(id_config.Text, 
                                                             cd_banco.Text,
                                                             cd_empresa.Text,
                                                             codigocedente.Text,
                                                             tp_cobranca.SelectedValue != null ? tp_cobranca.SelectedValue.ToString() : string.Empty,
                                                             cd_contager.Text, 
                                                             string.Empty,
                                                             string.Empty,
                                                             0, 
                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGBanco.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        bsCFGBanco.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsCFGBanco.AddNew();
            base.afterNovo();
            ano.Text = DateTime.Now.ToString("dd/MM/yyyy").Substring(6, 4);
            cd_empresa.Focus();
        }
        
        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCFGBanco.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadCFGBanco.Excluir(bsCFGBanco.Current as TRegistro_CadCFGBanco, null);
                        bsCFGBanco.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|200;" +
                              "a.CD_Empresa|Cd. Empresa|80";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                            new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.Cd_Empresa|=|'" + cd_empresa.Text + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Banco|Banco|200;" +
                              "CD_Banco|Cd. Banco|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco, ds_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), "");
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vColunas = "Cd_Banco|=|'" + cd_banco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_banco, ds_banco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void FCadCFGBanco_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCfgBanco);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
        }

        private void bb_logo_Click(object sender, EventArgs e)
        {
            if ((bsCFGBanco.Current != null) && ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit)))
            {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsCFGBanco.Current as TRegistro_CadCFGBanco).Logo_banco = Image.FromFile(ofd.FileName);
                            bsCFGBanco.ResetCurrentItem();
                        }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Descrição Portador|350;" +
                              "cd_portador|Cód. Portador|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), "");
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. ContaGer|80";
            string vParam = "b.cd_banco|=|'" + cd_banco.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                              "b.cd_banco|=|'" + cd_banco.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                              "         where x.cd_contager = a.cd_contager " +
                              "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new TCD_CadContaGer());
        }

        private void bb_historico_desconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_desconto, ds_historico_desconto },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_desconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico_desconto.Text.Trim() + "';" +
                              "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_desconto, ds_historico_desconto },
                                    new TCD_CadHistorico());
        }

        private void bb_historico_taxadesc_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_taxadesc, ds_historico_taxadesc },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_taxadesc_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico_taxadesc.Text.Trim() + "';" +
                              "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_taxadesc, ds_historico_taxadesc },
                                    new TCD_CadHistorico());
        }

        private void bb_historico_baixadesc_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_baixadesc, ds_historico_baixadesc },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_baixadesc_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico_baixadesc.Text.Trim() + "';" +
                              "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_baixadesc, ds_historico_baixadesc },
                                    new TCD_CadHistorico());
        }

        private void cd_historico_taxacob_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico_taxacob.Text.Trim() + "';" +
                              "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_taxacob, ds_historico_taxacob },
                                    new TCD_CadHistorico());
        }

        private void bb_historico_taxacob_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_taxacob, ds_historico_taxacob },
                                    new TCD_CadHistorico(), vParamFixo);
        }

        private void FCadCFGBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCfgBanco);
        }

        private void bb_bancocorrespondente_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_banco|Banco|250;" +
                              "a.cd_banco|Cd. Banco|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_bancocorrespondente, ds_bancocorrespondente },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_bancocorrespondente_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_banco|=|'" + cd_bancocorrespondente.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_bancocorrespondente, ds_bancocorrespondente },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void gCfgBanco_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gCfgBanco.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gCfgBanco.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_centroresultTXCob_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResultado fBusca = new FormBusca.TFBuscaCentroResultado())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresultTXCob.Text = fBusca.Cd_centro;
                        ds_centroresultTXCob.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresultTXCob_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultTXCob.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "a.tp_registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultTXCob, ds_centroresultTXCob }, new TCD_CentroResultado());
        }
    }
}
