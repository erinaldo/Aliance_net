using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Utils;

namespace Faturamento
{
    public partial class TFLanCaixaPDV : Form
    {
        private bool Altera_relatorio = false;

        public TFLanCaixaPDV()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_caixa.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            cbAberto.Checked = false;
            cbAuditado.Checked = false;
            cbFechado.Checked = false;
            cbProcessado.Checked = false;
        }

        private void AbrirCaixa()
        {
            using (Proc_Commoditties.TFAbrirCaixaPDV fAbrir = new Proc_Commoditties.TFAbrirCaixaPDV())
            {
                if(fAbrir.ShowDialog() == DialogResult.OK)
                    if (fAbrir.rCaixa != null)
                    {
                        try
                        {

                            CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.AbrirCaixa(fAbrir.rCaixa, null);
                            MessageBox.Show("Caixa aberto com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_caixa.Text = fAbrir.rCaixa.Id_caixastr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterExclui()
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido excluir caixa FECHADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido excluir caixa AUDITADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir caixa PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma excluir registro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.Excluir(bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV, null);
                        MessageBox.Show("Caixa excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar caixa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbFechado.Checked)
            {
                status += virg + "'F'";
                virg = ",";
            }
            if (cbAuditado.Checked)
            {
                status += virg + "'D'";
                virg = ",";
            }
            if (cbProcessado.Checked)
                status += virg + "'P'";
            bscaixaPDV.DataSource = CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.Buscar(id_caixa.Text,
                                                                                      "A",
                                                                                      dt_ini.Text,
                                                                                      dt_fin.Text,
                                                                                      status,
                                                                                      usuario.Text,
                                                                                      null);
            bscaixaPDV_PositionChanged(this, new EventArgs());
        }

        private void AuditarCaixa()
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Não é permitido AUDITAR caixa ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFFecharCaixaPDV fAudit = new TFFecharCaixaPDV())
                {
                    fAudit.rCaixa = bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV;
                    if(fAudit.ShowDialog() == DialogResult.OK)
                        if (fAudit.rCaixa != null)
                        {
                            try
                            {
                                if (CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.AuditarCaixa(fAudit.rCaixa, null))
                                    ProcessarCaixa();
                                else
                                    MessageBox.Show("Valores auditados gravados com sucesso.\r\n" +
                                                    "O caixa continua fechado aguardando auditoria dos portadores restantes.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_caixa.Text = fAudit.rCaixa.Id_caixastr;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar caixa para AUDITAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarCaixa()
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper() != "D")
                {
                    MessageBox.Show("Permitido processar somente caixa auditado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se existe fechamento de caixa para todos os portadores movimentados
                object obj = new CamadaDados.Faturamento.PDV.TCD_Cupom_X_MovCaixa().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_caixa",
                                        vOperador = "=",
                                        vVL_Busca = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(c.st_cartafrete, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_pdv_fechamentocaixa x " +
                                                    "where x.id_caixa = a.id_caixa " +
                                                    "and x.cd_portador = a.cd_portador " +
                                                    "and isnull(x.st_registro, 'A') <> 'C')"
                                    }
                                }, "a.cd_portador");
                if (MessageBox.Show((obj != null ? "Existe portador(" + obj.ToString() + ") com movimento de caixa e sem fechamento." : string.Empty) + "\r\nConfirma processamento do caixa AUDITADO?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Processar caixa
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.ProcessarCaixa(bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV, null);
                        MessageBox.Show("Caixa processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_caixa.Text = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void InserirRetirada()
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido inserir retirada em um caixa AUDITADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido inserir retirada em um caixa PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
                {
                    fRetirar.pId_caixa = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                    if (fRetirar.ShowDialog() == DialogResult.OK)
                        if (fRetirar.rRetirada != null)
                        {
                            try
                            {
                                fRetirar.rRetirada.Id_caixastr = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                                fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                                CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                                MessageBox.Show("Retirada gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                }
            }
        }

        private void CancelarRetirada()
        {
            if (bsRetirada.Current != null)
            {
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido CANCELAR retirada/suprimento PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Retirada/suprimento ja se encontra CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido CANCELAR retirada/suprimento de caixa AUDITADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido CANCELAR retirada/suprimento de caixa PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma cancelamento da retirada/suprimento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Cancelar((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa), null);
                        MessageBox.Show((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Tp_registro.Trim().ToUpper().Equals("R") ?
                            "Retirada CANCELADA com sucesso." : "SUPRIMENTO CANCELADO COM SUCESSO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar retirada/suprimento para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarRetirada()
        {
            if (bsRetirada.Current != null)
            {
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido processar retirada/suprimento cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Retirada/suprimento ja se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido processar retirada/suprimento de caixa auditado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido processar retirada/suprimento de caixa processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirmar processamento da retidada/suprimento?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (Proc_Commoditties.TFProcessarRetiradaCaixa fProc = new Proc_Commoditties.TFProcessarRetiradaCaixa())
                    {
                        fProc.Vl_processar = (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Vl_retirada;
                        fProc.Id_caixa = (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Id_caixastr;
                        if (fProc.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).lPortador = fProc.lPortador;
                                CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.ProcessarRetirada(bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa, null);
                                MessageBox.Show((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Tp_registro.Trim().ToUpper().Equals("R") ?
                                    "Retirada processada com sucesso." : "Suprimento processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar retirada/suprimento para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstornarFechamento()
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Caixa encontra-se com status ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido estornar fechamento de caixa PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma estorno do fechamento do caixa selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.EstornarFechamento(bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV, null);
                        MessageBox.Show("Fechamento caixa estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_caixa.Text = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void PrintRetirada()
        {
            if (bsRetirada.Count > 0)
            {
                //Imprimir Suprimento/Retirada
                FormRelPadrao.Relatorio retirada = new FormRelPadrao.Relatorio();
                retirada.Altera_Relatorio = Altera_relatorio;
                retirada.Nome_Relatorio = "SUPRIMENTO_RETIRADA";
                retirada.NM_Classe = "TFLanFrenteCaixa";
                retirada.Modulo = "PDV";
                retirada.Ident = "SUPRIMENTO_RETIRADA";
                retirada.Adiciona_DataSource("RETIRADA", bsRetirada);
                retirada.DTS_Relatorio = bsFechamentoCaixa;
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "SUPRIMENTO/RETIRADA";

                    if (Altera_relatorio)
                    {
                        retirada.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "SUPRIMENTO/RETIRADA",
                                                fImp.pDs_mensagem);
                        Altera_relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            retirada.Gera_Relatorio(string.Empty,
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "SUPRIMENTO/RETIRADA",
                                                    fImp.pDs_mensagem);
                }
            }
        }

        private void TFLanCaixaPDV_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gCaixaPDV);
            ShapeGrid.RestoreShape(this, gFechamento);
            ShapeGrid.RestoreShape(this, gMovCaixa);
            ShapeGrid.RestoreShape(this, gRetirada);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_cancelaretirada_Click(object sender, EventArgs e)
        {
            CancelarRetirada();
        }

        private void bb_procretirada_Click(object sender, EventArgs e)
        {
            ProcessarRetirada();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            AuditarCaixa();
        }

        private void bb_reprocessarfiscal_Click(object sender, EventArgs e)
        {
            ProcessarCaixa();
        }

        private void bscaixaPDV_PositionChanged(object sender, EventArgs e)
        {
            if (bscaixaPDV.Current != null)
            {
                //Buscar Retiradas
                (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lRetiradas =
                    CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Buscar(string.Empty,
                                                                           (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                           "'S', 'R'",
                                                                           string.Empty,
                                                                           null);
                //Buscar Fechamentos
                (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa =
                    CamadaNegocio.Faturamento.PDV.TCN_FechamentoCaixa.Buscar((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             null);
                //Buscar movimento caixa
                bsMovCaixa.DataSource = CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.BuscarMovCaixa((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                  string.Empty,
                                                                                                  "cd_portador, id_cupom",
                                                                                                  null);
                //Buscar Emprestimos Concedidos
                bsEmprestimo.DataSource = CamadaNegocio.Faturamento.PDV.TCN_EmprestimoConcedido.Buscar(string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       null);
                //Credito Avulso
                bsCaixaDevCredAvulso.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_DevCredAvulso.Buscar(string.Empty,
                                                                                                                 (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 null);
                bscaixaPDV.ResetCurrentItem();
            }
        }

        private void gCaixaPDV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                    gCaixaPDV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                else if (e.Value.ToString().Trim().ToUpper().Equals("AUDITADO"))
                    gCaixaPDV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    gCaixaPDV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gCaixaPDV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void gRetirada_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void gFechamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gFechamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gFechamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bb_usuario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.login|Login|100;" +
                              "a.nome_usuario|Nome Usuario|200";
            string vParam = "a.Tp_Registro|=|'U'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { usuario },
                                            new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
        }

        private void usuario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.login|=|'" + usuario.Text.Trim() + "';" +
                            "a.tp_registro|=|'U'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { usuario },
                                                new CamadaDados.Diversos.TCD_CadUsuario());
        }

        private void TFLanCaixaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                AbrirCaixa();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                AuditarCaixa();
            else if (e.KeyCode.Equals(Keys.F10))
                ProcessarCaixa();
            else if (e.KeyCode.Equals(Keys.F11))
                EstornarFechamento();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                ProcessarRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                CancelarRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            CancelarRetirada();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirRetirada();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            ProcessarRetirada();
        }

        private void extratoFechamentoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Caixa se encontra ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade venda = new CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade();
                venda = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from VTB_PDV_MovCaixa x where x.id_Cupom = a.Id_Cupom and a.CD_Empresa = x.CD_Empresa "+
                                        " and x.id_caixa = "+(bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr+")"
                        }
                    }, 0, string.Empty, string.Empty); 

                //Imprimir Extrato Fechamento Caixa
                FormRelPadrao.Relatorio extrato = new FormRelPadrao.Relatorio();
                extrato.Altera_Relatorio = Altera_relatorio;
                extrato.Nome_Relatorio = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                extrato.NM_Classe = "TFLanFrenteCaixa";
                extrato.Modulo = "PDV";
                extrato.Ident = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                BindingSource bs_caixa = new BindingSource();
                bs_caixa.DataSource = new CamadaDados.Faturamento.PDV.TList_CaixaPDV() { bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV };
                BindingSource bs_ab = new BindingSource();
                bs_ab.DataSource =   venda ;
                extrato.Adiciona_DataSource("CAIXA", bs_caixa);
                extrato.Adiciona_DataSource("pontos", bs_ab);
                extrato.DTS_Relatorio = bsFechamentoCaixa;
                //Buscar retiradas a processar
                object obj =
                new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.tp_registro, 'R')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                }
                                            }, "isnull(sum(a.Vl_Retirada), 0)");
                if (obj != null)
                    extrato.Parametros_Relatorio.Add("VL_RET_PROCESSAR", decimal.Parse(obj.ToString()));
                obj =
                new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.tp_registro, 'R')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, "isnull(sum(a.Vl_Retirada), 0)");
                if (obj != null)
                    extrato.Parametros_Relatorio.Add("VL_SUP_PROCESSAR", decimal.Parse(obj.ToString()));
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "EXTRATO FECHAMENTO CAIXA OPERACIONAL";

                    if (Altera_relatorio)
                    {
                        extrato.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                               fImp.pDs_mensagem);
                        Altera_relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            extrato.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   null,
                                                   "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                   fImp.pDs_mensagem);
                }
            }
        }

        private void suprimentoRetiradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintRetirada();
        }

        private void bb_imprimirRetirada_Click(object sender, EventArgs e)
        {
            //  PrintRetirada();

            object porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                              new TpBusca[]
                                              {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                                }
                                              }, "porta_imptick");
           // if (porta == null ? false : !string.IsNullOrEmpty(porta.ToString()))
            printAberturaCaixa(null, (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa), porta.ToString());
            afterBusca();
            bsRetirada.ResetCurrentItem();

        }

        private void printAberturaCaixa(CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa, CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa rRetirada, string porta)
        {
            string title = string.Empty;
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                               new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");
            if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
            {
                title = rCaixa != null ? "ABERTURA" : rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? "SUPRIMENTO" : "RETIRADA";
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Abertura.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(" =========================================");
                    w.WriteLine("          " + title.Trim() + " - CAIXA Nº" + (rCaixa == null ? rRetirada.Id_caixastr.Trim() : rCaixa.Id_caixastr.Trim()));
                    w.WriteLine(" =========================================");
                    w.WriteLine(" Data: " + (rCaixa == null ? rRetirada.Dt_retiradastr : rCaixa.Dt_aberturastr));
                    if (rCaixa != null)
                        w.WriteLine(" USUÁRIO: " + rCaixa.Login.Trim().ToUpper());
                    w.WriteLine((rCaixa == null ? (rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? " VL.Suprimento: " : " VL.Retirada: ")
                        + (rRetirada.Vl_retirada.ToString("N2", new System.Globalization.CultureInfo("en-US", true)))
                        : (" VL.Abertura: " + rCaixa.Vl_abertura.ToString("N2", new System.Globalization.CultureInfo("en-US", true)))));
                    if (rRetirada != null)
                    {
                        w.WriteLine();
                        rRetirada.lPortador.ForEach(p =>
                        {
                            w.WriteLine(" Portador: " + p.Ds_portador.Trim() + "  Valor: " + p.Vl_pagtoPDV.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)));
                            if (p.lCheque.Count > 0)
                                p.lCheque.ForEach(v => w.WriteLine("Nº Cheque: " + v.Nr_cheque.Trim() + "  Vl. Cheque: " + v.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true))));
                        });
                    }
                    if (rRetirada != null)
                        w.WriteLine(" OBS: " + rRetirada.Ds_observacao.Trim().ToUpper());

                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(porta);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão Abertura Caixa: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
            else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.NM_Classe = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "TFLanVendaRapida_AberturaCaixa";
                Relatorio.Altera_Relatorio = Altera_relatorio;

                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rRetirada.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                //buscar portador
                if (new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_PDV_Retirada_X_Cheque x where x.id_retirada = a.id_retirada and x.cd_empresa = a.cd_empresa)"
                        }
                    }, "1") == null)
                {
                    //dinheiro
                    rRetirada.lPortador.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador()
                    {
                        Ds_portador = "Dinheiro",
                        Vl_pagtoPDV = rRetirada.Vl_retirada
                    });
                }
                else
                {
                    //cheque
                    CamadaDados.Financeiro.Titulo.TList_RegLanTitulo list = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
                    list = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vOperador = "exists",
                                    vVL_Busca = "( select 1 from TB_PDV_Retirada_X_Cheque x where x.nr_lanctocheque = a.nr_lanctocheque and a.cd_empresa = x.cd_empresa )"
                                }
                            }, 1, string.Empty, string.Empty);

                    decimal valor = decimal.Zero;
                    list.ForEach(p => valor += p.Vl_titulo);

                    rRetirada.lPortador.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador()
                    { 
                        Ds_portador = "Cheque",
                        lCheque = list,
                        Vl_pagtoPDV = valor
                    });
                }



               BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = rRetirada;
                Relatorio.DTS_Relatorio = meu_bind;


                //Verificar se existe Impressora padrão para o PDV
                object objIMP = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
                string print = string.Empty;
                print = objIMP == null ? string.Empty : objIMP.ToString();
                if (string.IsNullOrEmpty(print))
                    using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                    {
                        if (fLista.ShowDialog() == DialogResult.OK)
                            if (!string.IsNullOrEmpty(fLista.Impressora))
                                print = fLista.Impressora;

                    }
                //Imprimir
                if (!string.IsNullOrEmpty(print))
                    Relatorio.ImprimiGraficoReduzida(print,
                                                     true,
                                                     false,
                                                     null,
                                                     string.Empty,
                                                     string.Empty,
                                                     1);
                Altera_relatorio = false;
            }
        }


        private void TFLanCaixaPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gCaixaPDV);
            ShapeGrid.SaveShape(this, gFechamento);
            ShapeGrid.SaveShape(this, gMovCaixa);
            ShapeGrid.SaveShape(this, gRetirada);
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            EstornarFechamento();
        }

        private void movimentaçãoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsRetirada.Count > 0)
            {
                //Imprimir Movimentação Caixa
                FormRelPadrao.Relatorio retirada = new FormRelPadrao.Relatorio();
                retirada.Altera_Relatorio = Altera_relatorio;
                retirada.Nome_Relatorio = "MOV_CAIXA";
                retirada.NM_Classe = "TFLanFrenteCaixa";
                retirada.Modulo = "PDV";
                retirada.Ident = "MOV_CAIXA";
                retirada.Adiciona_DataSource("MOVCAIXA", bsMovCaixa);
                BindingSource caixa = new BindingSource();
                caixa.DataSource = new CamadaDados.Faturamento.PDV.TList_CaixaPDV() {bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV};
                retirada.DTS_Relatorio = caixa;
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "MOVIMENTAÇÃO CAIXA";

                    if (Altera_relatorio)
                    {
                        retirada.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "MOVIMENTAÇÃO CAIXA",
                                                fImp.pDs_mensagem);
                        Altera_relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            retirada.Gera_Relatorio(string.Empty,
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "MOVIMENTAÇÃO CAIXA",
                                                    fImp.pDs_mensagem);
                }
            }
        }

        private void listagemDeCaixasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bscaixaPDV.Count > 0)
            {
                //Imprimir Lista de Caixas
                FormRelPadrao.Relatorio rel = new FormRelPadrao.Relatorio();
                rel.Altera_Relatorio = Altera_relatorio;
                rel.Nome_Relatorio = "CAIXA";
                rel.NM_Classe = "TFLanFrenteCaixa";
                rel.Modulo = "PDV";
                rel.Ident = "CAIXA";
                rel.DTS_Relatorio = bscaixaPDV;
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "LISTA DE CAIXAS";

                    if (Altera_relatorio)
                    {
                        rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "LISTA DE CAIXAS",
                                           fImp.pDs_mensagem);
                        Altera_relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "LISTA DE CAIXAS",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void gEmprestimos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    gEmprestimos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gEmprestimos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void gCaixaPDV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCaixaPDV.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bscaixaPDV.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV());
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCaixaPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCaixaPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_CaixaPDV(lP.Find(gCaixaPDV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCaixaPDV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_CaixaPDV(lP.Find(gCaixaPDV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCaixaPDV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bscaixaPDV.List as CamadaDados.Faturamento.PDV.TList_CaixaPDV).Sort(lComparer);
            bscaixaPDV.ResetBindings(false);
            gCaixaPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void extratoFechamentoCaixaAnalíticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bscaixaPDV.Current != null)
            {
                if ((bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Caixa se encontra ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FormRelPadrao.Relatorio extrato = new FormRelPadrao.Relatorio();
                extrato.Altera_Relatorio = Altera_relatorio;
                extrato.Nome_Relatorio = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL_ANALITICO";
                extrato.NM_Classe = "TFLanFrenteCaixa";
                extrato.Modulo = "PDV";
                extrato.Ident = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL_ANALITICO";
                BindingSource bs_caixa = new BindingSource();
                bs_caixa.DataSource = new CamadaDados.Faturamento.PDV.TList_CaixaPDV() { bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV };
                extrato.Adiciona_DataSource("CAIXA", bs_caixa);
                extrato.DTS_Relatorio = bsFechamentoCaixa;
                extrato.Adiciona_DataSource("MOV", bsMovCaixa);
                
                //Buscar retiradas a processar
                object obj =
                new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.tp_registro, 'R')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                }
                                            }, "isnull(sum(a.Vl_Retirada), 0)");
                if (obj != null)
                    extrato.Parametros_Relatorio.Add("VL_RET_PROCESSAR", decimal.Parse(obj.ToString()));
                obj =
                new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = (bscaixaPDV.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.tp_registro, 'R')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, "isnull(sum(a.Vl_Retirada), 0)");
                if (obj != null)
                    extrato.Parametros_Relatorio.Add("VL_SUP_PROCESSAR", decimal.Parse(obj.ToString()));



                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "EXTRATO FECHAMENTO CAIXA OPERACIONAL";

                    if (Altera_relatorio)
                    {
                        extrato.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                               fImp.pDs_mensagem);
                        Altera_relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            extrato.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   null,
                                                   "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                   fImp.pDs_mensagem);
                }
            }
        }
    }
}
