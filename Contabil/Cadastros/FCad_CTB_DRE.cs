using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FormBusca;
using System.Windows.Forms;

namespace Contabil.Cadastros
{
    public partial class TFCad_CTB_DRE : Form
    {
        private bool Altera_Relatorio = false;

        public TFCad_CTB_DRE()
        {
            InitializeComponent();
        }

        private void gridParamDRE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            bsDRE.AddNew();
            Utils.InputBox iB = new Utils.InputBox();
            iB.Text = "DRE";
            (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).ds_dre = iB.ShowDialog();
            if (string.IsNullOrEmpty((bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).ds_dre))
            {
                MessageBox.Show("Obrigatório informar descrição", "Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            try
            {
                CamadaNegocio.Contabil.Cadastro.TCN_CTB_DRE.Gravar(bsDRE.Current 
                                                                as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE,null);

                MessageBox.Show("DRE Gravado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }catch(Exception ex){
                MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            afterBusca();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(bsDRE.Current != null)
                using (TFParamDRE fParam = new TFParamDRE())
                {
                    fParam.Id_dre = (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_drestr;
                    if(fParam.ShowDialog() == DialogResult.OK)
                        if(fParam.rParam != null)
                            try
                            {
                                fParam.rParam.Id_dre = (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_dre;
                                CamadaNegocio.Contabil.Cadastro.TCN_CTB_paramDRE.Gravar(fParam.rParam, null);
                                MessageBox.Show("Parâmetro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
            {
                if ((bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE).Tp_conta.Trim().ToUpper().Equals("A"))
                {
                    CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                    FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
                    string cd_conta = string.Empty;
                    if (rConta != null)
                    {
                        cd_conta = rConta.Cd_conta_ctbstr;
                        try
                        {
                            CamadaNegocio.Contabil.Cadastro.TCN_CTB_PARAM_X_CONTACTB.Gravar(
                                new CamadaDados.Contabil.Cadastro.TRegistro_CTB_param_x_contaCTB()
                                {
                                    Id_dre = (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_dre,
                                    Id_param = (bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE).Id_param,
                                    Cd_conta_CTBstr = cd_conta


                                }, null);
                            MessageBox.Show("Salvo com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsParamDre_PositionChanged(this, new EventArgs());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar conta", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else MessageBox.Show("Permitido cadastrar conta somente para parâmetro ANALITICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                try{
                    CamadaNegocio.Contabil.Cadastro.TCN_CTB_DRE.Excluir((bsDRE.Current
                                                 as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE), null);
                    afterBusca();
                    MessageBox.Show("Excluido com sucesso", "erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch(Exception ex){
                    MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Contabil.Cadastro.TCN_CTB_paramDRE.Excluir((bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE), null);
                    MessageBox.Show("Excluido com sucesso", "erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Contabil.Cadastro.TCN_CTB_PARAM_X_CONTACTB.Excluir((bsParamConta.Current
                                                 as CamadaDados.Contabil.Cadastro.TRegistro_CTB_param_x_contaCTB), null);
                    MessageBox.Show("Excluido com sucesso", "erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsParamDre_PositionChanged(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        private void TFCad_CTB_DRE_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        public void afterBusca()
        {

            bsDRE.DataSource = CamadaNegocio.Contabil.Cadastro.TCN_CTB_DRE.Buscar(string.Empty,
                                                                                  string.Empty,
                                                                                  null
                                                                                  );
            bsDRE_PositionChanged(this, new EventArgs());
            bsParamDre_PositionChanged(this, new EventArgs());
        }

        private void bsDRE_PositionChanged(object sender, EventArgs e)
        {
            if (bsDRE.Current != null)
                (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).lParamDre =
                    CamadaNegocio.Contabil.Cadastro.TCN_CTB_paramDRE.Buscar((bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_drestr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
            bsDRE.ResetCurrentItem();
        }

        private void bsParamDre_PositionChanged(object sender, EventArgs e)
        {

            if (bsParamDre.Current != null)
                (bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE).lparamConta =
                    CamadaNegocio.Contabil.Cadastro.TCN_CTB_PARAM_X_CONTACTB.Buscar(
                                                                            (bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE).Id_drestr,
                                                                            (bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE).Id_paramstr,
                                                                            string.Empty,
                                                                            null);
            bsParamDre.ResetCurrentItem();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFCad_CTB_DRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (bsParamDre.Current != null)
                using (TFParamDRE fParam = new TFParamDRE())
                {
                    fParam.Id_dre = (bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_drestr;
                    fParam.rParam = bsParamDre.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE;
                    if (fParam.ShowDialog() == DialogResult.OK)
                        if (fParam.rParam != null)
                            try
                            {
                                CamadaNegocio.Contabil.Cadastro.TCN_CTB_paramDRE.Gravar(fParam.rParam, null);
                                MessageBox.Show("Parâmetro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
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
                bs.DataSource = new CamadaDados.Contabil.Cadastro.TCD_CTD_DRE().RelDRE((bsDRE.Current as CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE).Id_drestr);
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
    }
}
