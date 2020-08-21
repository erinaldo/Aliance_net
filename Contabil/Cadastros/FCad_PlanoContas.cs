using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Contabil.Cadastro;
using CamadaNegocio.Contabil.Cadastro;

namespace Contabil.Cadastros
{
    public partial class TFCad_PlanoContas : Form
    {
        public bool Altera_Relatorio = false;

        public TFCad_PlanoContas()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (FormBusca.TFPlanoContas fPlano = new FormBusca.TFPlanoContas())
            {
                if(fPlano.ShowDialog() == DialogResult.OK)
                    if(fPlano.rPlano != null)
                        try
                        {
                            TCN_PlanoContas.Gravar(fPlano.rPlano, null);
                            MessageBox.Show("Conta Contabil cadastrada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsPlanoContas.Current != null)
                using (FormBusca.TFPlanoContas fPlano = new FormBusca.TFPlanoContas())
                {
                    fPlano.rPlano = bsPlanoContas.Current as TRegistro_CadPlanoContas;
                    if(fPlano.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_PlanoContas.Gravar(fPlano.rPlano, null);
                            MessageBox.Show("Conta Contabil alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
        }

        private void afterExclui()
        {
            if (bsPlanoContas.Current != null)
                if(MessageBox.Show("Confirma exclusão da conta selecionado?" + 
                    ((bsPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S") ?
                    "\r\nObs.: Conta Sintética, será cancelada automaticamente todas as contas filhas." : string.Empty),
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_PlanoContas.Excluir(bsPlanoContas.Current as TRegistro_CadPlanoContas, null);
                        MessageBox.Show("Conta excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsPlanoContas.DataSource = TCN_PlanoContas.Buscar(cd_conta_ctb.Text,
                                                              ds_conta.Text,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
        }

        private void afterPrint()
        {
            if (bsPlanoContas.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "TFCadPlanoContas";
                Relatorio.NM_Classe = "TFCadPlanoContas";
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                Relatorio.DTS_Relatorio = bsPlanoContas;
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "PLANO CONTAS CONTABIL";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "PLANO CONTAS CONTABIL",
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

        private void TFCad_PlanoContas_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFCad_PlanoContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar o layout.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gPlanoContas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(3))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("SINTETICA"))
                        gPlanoContas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gPlanoContas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bbPlanoReferencial_Click(object sender, EventArgs e)
        {
            using (TFPlanoReferencial fPlano = new TFPlanoReferencial())
            {
                fPlano.ShowDialog();
            }
        }

        private void aplicarPlanoReferencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bsPlanoContas.Current != null)
                using (FormBusca.TFBuscarContasReferenciais fBusca = new FormBusca.TFBuscarContasReferenciais())
                {
                    if(fBusca.ShowDialog() == DialogResult.OK)
                        if(fBusca.rConta != null)
                            try
                            {
                                TCN_PlanoContas.AplicarContaReferencial(
                                    bsPlanoContas.Current as TRegistro_CadPlanoContas,
                                    fBusca.rConta,
                                    null);
                                afterBusca();

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }
    }
}
