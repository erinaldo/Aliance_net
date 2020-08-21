using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCadDRE : Form
    {
        private bool Altera_Relatorio = false;
        public TFCadDRE()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsDRE.DataSource = CamadaNegocio.Financeiro.DRE.TCN_DRE.Buscar(string.Empty,
                                                                           string.Empty,
                                                                           null);
            bsDRE.ResetCurrentItem();
            bsDRE_PositionChanged(this, new EventArgs());
        }

        private void TFCadDRE_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            if (bsDRE.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = this.Name;
                Relatorio.NM_Classe = this.Name.Trim();
                Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);

                BindingSource bs = new BindingSource();
                bs.DataSource = new CamadaDados.Financeiro.DRE.TCD_DRE().RelDRE((bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_drestr);
                Relatorio.DTS_Relatorio = bs;
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "RELATÓRIO CADASTRO DRE";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO CADASTRO DRE",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            bsDRE.AddNew();
            Utils.InputBox iB = new Utils.InputBox();
            iB.Text = "DRE";
            (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).ds_dre = iB.ShowDialog();
            if (string.IsNullOrEmpty((bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).ds_dre))
            {
                MessageBox.Show("Obrigatório informar descrição!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CamadaNegocio.Financeiro.DRE.TCN_DRE.Gravar(bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE, null);
                MessageBox.Show("DRE gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                afterBusca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if (bsDRE.Current != null)
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.DRE.TCN_DRE.Excluir((bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE), null);
                            MessageBox.Show("DRE excluído com sucesso!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    }
        }

        private void bb_inserirParam_Click(object sender, EventArgs e)
        {
            if (bsDRE.Current != null)
                using (TFParamDRE fParam = new TFParamDRE())
                {
                    fParam.Id_dre = (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_drestr;
                    if (fParam.ShowDialog() == DialogResult.OK)
                        if (fParam.rParam != null)
                            try
                            {
                                fParam.rParam.Id_dre = (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_dre;
                                CamadaNegocio.Financeiro.DRE.TCN_paramDRE.Gravar(fParam.rParam, null);
                                MessageBox.Show("Parâmetro gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_alterarParam_Click(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
                using (TFParamDRE fParam = new TFParamDRE())
                {
                    fParam.Id_dre = (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_drestr;
                    fParam.rParam = bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE;
                    if (fParam.ShowDialog() == DialogResult.OK)
                        if (fParam.rParam != null)
                            try
                            {
                                CamadaNegocio.Financeiro.DRE.TCN_paramDRE.Gravar(fParam.rParam, null);
                                MessageBox.Show("Parâmetro alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluirParam_Click(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.DRE.TCN_paramDRE.Excluir((bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE), null);
                        MessageBox.Show("Parâmetro excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_inserirHist_Click(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
            {
                if ((bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE).Tp_conta.Trim().ToUpper().Equals("A"))
                {
                    string vColunas = "a.CD_Historico|Cód. Histórico|100;" +
                                       "a.DS_Historico|Descrição Histórico|200";
                    DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new TCD_CadHistorico(), string.Empty);
                    string historico = string.Empty;
                    if (linha != null)
                    {
                        historico = linha["cd_historico"].ToString();
                        try
                        {
                            CamadaNegocio.Financeiro.DRE.TCN_PARAM_X_HISTORICO.Gravar(
                                new CamadaDados.Financeiro.DRE.TRegistro_param_x_Historico()
                                {
                                    Id_dre = (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_dre,
                                    Id_param = (bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE).Id_param,
                                    Cd_historico = historico
                                }, null);
                            MessageBox.Show("Histórico gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsParamDre_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Histórico!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else MessageBox.Show("Permitido cadastrar conta somente para parâmetro ANALITICO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_excluirHist_Click(object sender, EventArgs e)
        {
            if (bsHist.Current != null)
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.DRE.TCN_PARAM_X_HISTORICO.Excluir((bsHist.Current
                                                     as CamadaDados.Financeiro.DRE.TRegistro_param_x_Historico), null);
                        MessageBox.Show("Histórico excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsParamDre_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bsDRE_PositionChanged(object sender, EventArgs e)
        {
            if (bsDRE.Current != null)
                (bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).lParamDre =
                    CamadaNegocio.Financeiro.DRE.TCN_paramDRE.Buscar((bsDRE.Current as CamadaDados.Financeiro.DRE.TRegistro_DRE).Id_drestr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
            bsDRE.ResetCurrentItem();
            bsParamDre_PositionChanged(this, new EventArgs());
        }

        private void bsParamDre_PositionChanged(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
                (bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE).lparamConta =
                    CamadaNegocio.Financeiro.DRE.TCN_PARAM_X_HISTORICO.Buscar(
                                                                            (bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE).Id_drestr,
                                                                            (bsParamDre.Current as CamadaDados.Financeiro.DRE.TRegistro_paramDRE).Id_paramstr,
                                                                            string.Empty,
                                                                            null);
            bsParamDre.ResetCurrentItem();
        }

        private void TFCadDRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                bb_imprimir_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }
    }
}
