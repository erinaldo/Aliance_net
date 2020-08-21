using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;

namespace Faturamento
{
    public partial class TFLanCreditoClifor : Form
    {
        public TFLanCreditoClifor()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_credito.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
        }

        private void afterNovo()
        {
            using (TFCreditoClifor fCred = new TFCreditoClifor())
            {
                if(fCred.ShowDialog() == DialogResult.OK)
                    if (fCred.rCred != null)
                        using (Financeiro.TFLanCaixa fCaixa = new Financeiro.TFLanCaixa())
                        {
                            fCaixa.dsLanCaixa.AddNew();

                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_Empresa = fCred.rCred.Cd_empresa;
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).NM_Clifor = fCred.rCred.Nm_clifor;
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Dt_lancto = fCred.rCred.Dt_credito;
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).ComplHistorico = fCred.rCred.Ds_observacao;
                            fCaixa.RB_Receber.Checked = true;

                            fCaixa.CD_Empresa.Enabled = false;
                            fCaixa.NM_Clifor.Enabled = false;
                            fCaixa.DT_Lancto.Enabled = false;
                            fCaixa.RB_Pagar.Enabled = false;
                            fCaixa.RB_Receber.Enabled = false;

                            fCaixa.dsLanCaixa.ResetCurrentItem();

                            if (fCaixa.ShowDialog() == DialogResult.OK)
                                if (fCaixa.dsLanCaixa.Current != null)
                                    try
                                    {
                                        TCN_CreditoClifor.Gravar(fCred.rCred, fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa, null);
                                        MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.LimparFiltros();
                                        id_credito.Text = fCred.rCred.Id_creditostr;
                                        this.afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                else
                                    MessageBox.Show("Obrigatorio informar caixa para gravar credito cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Obrigatorio informar caixa para gravar credito cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
            }
        }

        private void afterBusca()
        {
            bsCreditoClifor.DataSource = TCN_CreditoClifor.Buscar(id_credito.Text,
                                                                  cd_empresa.Text,
                                                                  cd_clifor.Text,
                                                                  string.Empty,
                                                                  DT_Inicial.Text,
                                                                  DT_Final.Text,
                                                                  st_comsaldo.Checked,
                                                                  null);
            bsCreditoClifor_PositionChanged(this, new EventArgs());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanCreditoClifor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsCreditoClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsCreditoClifor.Current != null)
            {
                (bsCreditoClifor.Current as TRegistro_CreditoClifor).lCaixa =
                    TCN_CreditoClifor_X_Caixa.BuscarCaixa((bsCreditoClifor.Current as TRegistro_CreditoClifor).Id_creditostr,
                                                          (bsCreditoClifor.Current as TRegistro_CreditoClifor).Cd_empresa,
                                                          null);
                bsCreditoClifor.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void TFLanCreditoClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
