using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compra
{
    public partial class TFAprovarCompra : Form
    {
        public CamadaDados.Compra.Lancamento.TRegistro_Requisicao rRequisicao
        {
            get
            {
                if (bsRequisicao.Current != null)
                    return bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao;
                else
                    return null;
            }
            set
            {
                bsRequisicao.Add(value);
            }
        }

        public TFAprovarCompra()
        {
            InitializeComponent();
        }

        private void AprovarRequisicao()
        {
            if (bsRequisicao.Current != null)
            {
                if (qtd_aprovada.Value <= 0)
                {
                    MessageBox.Show("Obrigatorio informar quantidade aprovada para aprovar requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    qtd_aprovada.Focus();
                    return;
                }
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Count > 0)
                {
                    //Verificar se existe alguma negociacao selecionada
                    if (!(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar uma negociação para aprovar requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count > 0)
                {
                    //Verificar se existe alguma cotacao selecionada
                    if (!(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Exists(p => p.St_integrar))
                    {
                        MessageBox.Show("Obrigatorio selecionar uma cotação para aprovar requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao = "AP";//Aprovada
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ReprovarRequisicao()
        {
            if (bsRequisicao.Current != null)
            {
                if (MessageBox.Show("Confirma reprovação da requisição de compra?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao = "RE";//Reprovada
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void RenegociarRequisicao()
        {
            if (bsRequisicao.Current != null)
            {
                if (MessageBox.Show("Confirma a renegociação da requisição selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_requisicao = "RN";//Renegociar
                    this.DialogResult = DialogResult.OK;
                }
            }
        }   

        private void QtdAprovadaNegociacao()
        {
            if (bsNegociacao.Current != null)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar)
                {
                    if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_porcompra > 0)
                    {
                        if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_porcompra > quantidade.Value)
                        {
                            MessageBox.Show("Negociação não podera ser utilizada nesta requisição.\r\n" +
                                            "Quantidade por compra da negociação é maior que a quantidade requisitada.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar = false;
                            bsNegociacao.ResetCurrentItem();
                            return;
                        }
                        qtd_aprovada.Value = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_porcompra;
                        qtd_aprovada.Enabled = false;
                    }
                    else if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_min_compra > 0)
                    {
                        if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_min_compra > quantidade.Value)
                        {
                            MessageBox.Show("Negociação não podera ser utilizada nesta requisição.\r\n" +
                                            "Quantidade minima da negociação é maior que a quantidade requisitada.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar = false;
                            bsNegociacao.ResetCurrentItem();
                            return;
                        }
                        if (qtd_aprovada.Value > (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_min_compra)
                            qtd_aprovada.Value = (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).Qtd_min_compra;
                    }
                }
                if (qtd_aprovada.Value > quantidade.Value)
                    qtd_aprovada.Value = quantidade.Value;
            }
        }

        private void TFAprovarCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gNegociacoes);
            Utils.ShapeGrid.RestoreShape(this, gCotacao);
            pAprovar.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rRequisicao != null)
            {
                qtd_aprovada.Value = quantidade.Value;
                if (rRequisicao.lReqneg.Count > 0)
                {
                    tcDetalhes.TabPages.Remove(tpCotacoes);
                    bb_renegociar.Visible = false;
                }
                else if (rRequisicao.lCotacoes.Count > 0)
                {
                    tcDetalhes.TabPages.Remove(tpNegociacoes);
                    qtd_aprovada.Enabled = false;
                }   
            }
        }

        private void gNegociacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar)
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar = false;
                else
                {
                    //Desmarcar todos as negociacoes
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.ForEach(p => p.St_processar = false);
                    //Marcar a negociacao corrente
                    (bsNegociacao.Current as CamadaDados.Compra.Lancamento.TRegistro_NegociacaoItem).St_processar = true;
                    //Verificar regra para o campo qtd_aprovada
                    this.QtdAprovadaNegociacao();
                }
            }
        }

        private void qtd_aprovada_Leave(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedTab.Equals(tpNegociacoes))
                this.QtdAprovadaNegociacao();
        }

        private void bb_aprovar_Click(object sender, EventArgs e)
        {
            this.AprovarRequisicao();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_reprovar_Click(object sender, EventArgs e)
        {
            this.ReprovarRequisicao();
        }

        private void bb_renegociar_Click(object sender, EventArgs e)
        {
            this.RenegociarRequisicao();
        }

        private void TFAprovarCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.AprovarRequisicao();
            else if (e.KeyCode.Equals(Keys.F5))
                this.ReprovarRequisicao();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                this.RenegociarRequisicao();
        }

        private void gCotacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar)
                    (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar = false;
                else
                {
                    //Desmarcar todos as cotacoes
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.ForEach(p => p.St_integrar = false);
                    //Verificar se a cotacao selecionada nao esta vencida
                    if ((bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Nr_diasvigencia > 0)
                    {
                        if (CamadaDados.UtilData.Data_Servidor() > Convert.ToDateTime((bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Dt_validadecotacao))
                            MessageBox.Show("Prazo de validade da cotação expirado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            qtd_aprovada.Value = (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).Qtd_atendida;
                            (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar = true;
                        }
                    }
                    else
                        (bsCotacao.Current as CamadaDados.Compra.Lancamento.TRegistro_Cotacao).St_integrar = true;
                }
                bsCotacao.ResetCurrentItem();
            }
        }

        private void TFAprovarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gNegociacoes);
            Utils.ShapeGrid.SaveShape(this, gCotacao);
        }
    }
}
