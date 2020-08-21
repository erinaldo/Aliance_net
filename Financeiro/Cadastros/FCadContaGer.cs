using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using System.Collections;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadContaGer : FormCadPadrao.FFormCadPadrao
    {
        public TFCadContaGer()
        {
            InitializeComponent();
            DTS = BS_CadContaGer;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadContaGer.Gravar(BS_CadContaGer.Current as TRegistro_CadContaGer, null);
            else
                return string.Empty;
        }
                
        public override int buscarRegistros()
        {
            TList_CadContaGer lista = TCN_CadContaGer.Buscar(CD_ContaGer.Text, 
                                                             DS_Conta.Text,
                                                             BS_CadContaGer.Current == null ? null: (BS_CadContaGer.Current as TRegistro_CadContaGer).Banco, 
                                                             Nr_Agencia.Text, 
                                                             Nr_ContaCorrente.Text, 
                                                             st_contacompensacao.Checked ? "S" : string.Empty, 
                                                             st_integractb.Checked ? "S" : string.Empty,
                                                             vl_limite.Value, 
                                                             cd_contager_compensacao.Text, 
                                                             string.Empty, 
                                                             string.Empty, 
                                                             string.Empty, 
                                                             0, 
                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadContaGer.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        BS_CadContaGer.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value,this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if((vTP_Modo==TTpModo.tm_busca)||(vTP_Modo==TTpModo.tm_Standby))
                BS_CadContaGer.AddNew();
            base.afterNovo();
                CD_ContaGer.Focus();
        }

        public override void afterAltera()
        {            
            base.afterAltera();
            DS_Conta.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadContaGer.RemoveCurrent();
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void afterExclui()
        {
            if (BS_CadContaGer.Current != null)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            TCN_CadContaGer.Excluir(BS_CadContaGer.Current as TRegistro_CadContaGer, null);
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro excluir: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void bb_banco_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Banco|Descrição Banco|350;" +
                              "CD_Banco|Cód. Banco|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Banco, ds_banco },
                                    new TCD_CadBanco(), "");
        }

        private void CD_Banco_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Banco|=|'" + CD_Banco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Banco, ds_banco },
                                    new TCD_CadBanco());
        }
       
        private void TFCadContaGer_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pFlags.BackColor = Utils.SettingsUtils.Default.COLOR_1;
        }

        private void bb_compensacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|Conta Compensação|100;a.ds_contager|Descrição Conta|350";
            string vParam = "a.st_contacompensacao|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager_compensacao, ds_conta_compensacao }, new TCD_CadContaGer(), vParam);
        }
        
        private void cd_contager_compensacao_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + cd_contager_compensacao.Text.Trim() + "';" +
                              "a.st_contacompensacao|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contager_compensacao, ds_conta_compensacao}, new TCD_CadContaGer());
        }
        
        private void st_contacompensacao_CheckedChanged(object sender, EventArgs e)
        {
            cd_contager_compensacao.Enabled = !st_contacompensacao.Checked && (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit));
            bb_compensacao.Enabled = !st_contacompensacao.Checked && (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit));
        }

        private void cd_contager_compensacao_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_contager_compensacao.Enabled)
            {
                cd_contager_compensacao.Clear();
                ds_conta_compensacao.Clear();
            }
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Descrição Moeda|250;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), string.Empty);
        }

        private void bb_ModeloCheque_Click(object sender, EventArgs e)
        {
            if (BS_CadContaGer.Current != null)
                if ((BS_CadContaGer.Current as TRegistro_CadContaGer).St_contacompensacaobool)
                {
                    FormRelPadrao.LayoutCheque Relatorio = new FormRelPadrao.LayoutCheque();
                    (BS_CadContaGer.Current as TRegistro_CadContaGer).LayoutCheque = Relatorio.Gera_ModeloCheque(BS_CadContaGer.Current as TRegistro_CadContaGer);
                    BS_CadContaGer.ResetCurrentItem();
                }
                else
                    MessageBox.Show("Permitido configurar layout de impressão de cheques somente para contas de compensação.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFCadContaGer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void bb_contager_aplic_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|Conta Compensação|100;a.ds_contager|Descrição Conta|350";
            string vParam = "a.st_contacompensacao|<>|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager_aplic, ds_contager_aplic }, new TCD_CadContaGer(), vParam);
        }

        private void cd_contager_aplic_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + cd_contager_aplic.Text.Trim() + "';" +
                              "a.st_contacompensacao|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contager_aplic, ds_contager_aplic }, new TCD_CadContaGer());
        }

        private void st_contaaplicacao_CheckedChanged(object sender, EventArgs e)
        {
            lblCtVinculada.Visible = st_contaaplicacao.Checked;
            cd_contager_aplic.Visible = st_contaaplicacao.Checked;
            bb_contager_aplic.Visible = st_contaaplicacao.Checked;
            ds_contager_aplic.Visible = st_contaaplicacao.Checked;
        }

        private void cd_contager_aplic_VisibleChanged(object sender, EventArgs e)
        {
            if (!cd_contager_aplic.Visible)
            {
                cd_contager_aplic.Clear();
                ds_contager_aplic.Clear();
            }
        }
    }
}

