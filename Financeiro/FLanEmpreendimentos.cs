using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using FormRelPadrao;

namespace Financeiro
{
    public partial class TFLanEmpreendimentos : Form
    {
        public TFLanEmpreendimentos()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFEmpreendimento fEmp = new TFEmpreendimento())
            {
                fEmp.vModo = Utils.TTpModo.tm_Insert;
                if (fEmp.ShowDialog() == DialogResult.OK)
                {
                    if (fEmp.rEmp != null)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento.GravarEmpreendimento(fEmp.rEmp, null);
                            MessageBox.Show("Empreendimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Buscar registro gravado
                            id_empreendimento.Text = fEmp.rEmp.Id_empreendimento.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe empreendimento para ser gravado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void afterAltera()
        {
            if (bsEmpreendimento.Current != null)
                using (TFEmpreendimento fEmp = new TFEmpreendimento())
                {
                    fEmp.vModo = Utils.TTpModo.tm_Edit;
                    fEmp.rEmp = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento);
                    if (fEmp.ShowDialog() == DialogResult.OK)
                    {
                        bsEmpreendimento.ResetCurrentItem();
                        try
                        {
                            CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento.GravarEmpreendimento(fEmp.rEmp, null);
                            MessageBox.Show("Empreendimento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            id_empreendimento.Text = fEmp.rEmp.Id_empreendimento.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            else
                MessageBox.Show("Necessario selecionar um empreendimento para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsEmpreendimento.Current != null)
            {
                if ((bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir empreendimento encerrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do emprendimento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento.DeletarEmpreendimento(bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento, null);
                        MessageBox.Show("Empreendimento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Necessario selecionar um empreendimento para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EncerrarEmpreendimento()
        {
            if (bsEmpreendimento.Current != null)
            {
                if ((bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).St_registro.Trim().ToUpper().Equals("A"))
                {
                    if (MessageBox.Show("Confirma encerramento do pedido?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).St_registro = "E";
                            CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento.GravarEmpreendimento(bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento, null);
                            MessageBox.Show("Empreendimento encerrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            id_empreendimento.Text = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento.Value.ToString();
                            cbProcessado.Checked = true;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Não é permitido encerrar pedido com status diferente de <ATIVO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Necessario selecionar um empreendimento para encerrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LancarFinanceiro()
        {
            if (bsEmpreendimento.Current != null)
            {
                if ((bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).St_registro.Trim().ToUpper().Equals("A"))
                {
                    using (TFLanDuplicata fDuplicata = new TFLanDuplicata())
                    {
                        fDuplicata.vCd_empresa = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Cd_empresa;
                        fDuplicata.vNm_empresa = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Nm_empresa;
                        
                        fDuplicata.cd_empresa.Enabled = false;
                        fDuplicata.bb_empresa.Enabled = false;
                        fDuplicata.St_empreendimento = true;
                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                        {
                            //Ratear Centro de Custo
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_PROVISAO", 
                                                                                     (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                     null).Trim().ToUpper().Equals("S"))
                                using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                {
                                    fRateio.vVl_Documento = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                    //fDupCCusto.Id_empreendimento = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento.Value.ToString();
                                    fRateio.Tp_mov = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov;
                                    fRateio.ShowDialog();
                                    (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto = fRateio.lCResultado;
                                    (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLanctoDel = fRateio.lCResultadoDel;
                                }
                            try
                            {
                                string ret = TCN_LanDuplicata.GravarDuplicata((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata), false, null);
                                if (ret.Trim() != "")
                                {
                                    string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");

                                    MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                        CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                            (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            false,
                                                                                            0,
                                                                                            null);
                                    if (lBloqueto.Count > 0)
                                        //Chamar tela de impressao para o bloqueto
                                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                        {
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                            fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                    lBloqueto,
                                                                                    fImp.pSt_imprimir,
                                                                                    fImp.pSt_visualizar,
                                                                                    fImp.pSt_enviaremail,
                                                                                    fImp.pSt_exportPdf,
                                                                                    fImp.Path_exportPdf,
                                                                                    fImp.pDestinatarios,
                                                                                    "BLOQUETO(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                    fImp.pDs_mensagem,
                                                                                    false);
                                        }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim());
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Não é permitido lançar financeiro para empreendimento com status diferente <ATIVO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Necessario selecionar empreendimento para lançar financeiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string st_reg = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                st_reg = virg + "'A'";
                virg = ",";
            }
            if (cbProcessado.Checked)
            {
                st_reg = virg + "'E'";
                virg = ",";
            }
            bsEmpreendimento.DataSource = CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento.Buscar(id_empreendimento.Text,
                                                                                                            cd_empresa.Text,
                                                                                                            ds_empreendimento.Text,
                                                                                                            ds_observacao.Text,
                                                                                                            rgData.NM_Valor,
                                                                                                            DT_Inicial.Text,
                                                                                                            DT_Final.Text,
                                                                                                            0,
                                                                                                            string.Empty,
                                                                                                            null);
            bsEmpreendimento_PositionChanged(this, new EventArgs());
        }

        private void AlterarCResultado()
        {
            if (bsCusto.Current != null)
            {
                using (TFAlterarCResultado fAlterarCCusto = new TFAlterarCResultado())
                {
                    if (fAlterarCCusto.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Id_ccustolan = (bsCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Id_ccustolan,
                                    Vl_lancto = (bsCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Vl_lancto,
                                    Dt_lancto = (bsCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Dt_lancto,
                                    Cd_empresa = (bsCusto.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Cd_empresa
                                }, null);
                            MessageBox.Show("Lançamento Centro Resultado alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsEmpreendimento_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lançamento centro resultado para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanEmpreendimentos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pStatus.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltroData.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
               , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
               "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
               "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
               "(exists(select 1 from tb_div_usuario_x_grupos y " +
               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bsEmpreendimento_PositionChanged(object sender, EventArgs e)
        {
            if (bsEmpreendimento.Current != null)
            {
                if ((bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento != null)
                {
                    //Buscar centro resultado empreendimento
                    (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).lCResultado =
                        CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento_X_CResultado.BuscarCResultado(
                        (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento.Value.ToString(), null);
                    //Buscar lancamentos financeiros empreeendimento
                    (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).lLanCCusto =
                        CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento_X_LanCCusto.BuscarCResultado(
                        (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento.Value.ToString(), null);
                    bsEmpreendimento.ResetCurrentItem();
                }
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Pedido_Click(object sender, EventArgs e)
        {
            EncerrarEmpreendimento();
        }

        private void BB_Liquidar_Click(object sender, EventArgs e)
        {
            LancarFinanceiro();
        }

        private void TFLanEmpreendimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                EncerrarEmpreendimento();
            else if (e.KeyCode.Equals(Keys.F10))
                LancarFinanceiro();
        }

        private void bb_alterarccusto_Click(object sender, EventArgs e)
        {
            AlterarCResultado();
        }

        private void bb_fincentroresultado_Click(object sender, EventArgs e)
        {
            if (bsEmpreendimento.Current != null)
                using (TFConsultaFinCentroResultado fConsulta = new TFConsultaFinCentroResultado())
                {
                    fConsulta.Cd_empresa = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Cd_empresa;
                    //fConsulta.Id_empreendimento = (bsEmpreendimento.Current as CamadaDados.Financeiro.Empreendimento.TRegistro_Empreendimento).Id_empreendimento.Value.ToString();
                    if (fConsulta.ShowDialog() == DialogResult.OK)
                        bsEmpreendimento_PositionChanged(this, new EventArgs());
                }
            else
                MessageBox.Show("Obrigatorio selecionar um empreendimento para inserir resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanEmpreendimentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
