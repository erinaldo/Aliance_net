using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFLanCustodiaCH : Form
    {
        public bool Altera_Relatorio;
        public TFLanCustodiaCH()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_lotebusca.Clear();
            cd_empresabusca.Clear();
            nr_cheque.Clear();
            cd_banco.Clear();
            cd_contager.Clear();
            cbEnviado.Checked = false;
            CB_Abertas.Checked = false;
            DT_Final.Clear();
            DT_Inicial.Clear();
        }

        private void afterNovo()
        {
            using (TFLoteCustodia fLote = new TFLoteCustodia())
            {
                if(fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote Gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_lotebusca.Text = fLote.rLote.Id_lote.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsLoteCustodia.Current != null)
            {
                using (TFLoteCustodia fLote = new TFLoteCustodia())
                {
                    fLote.rLote = bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia;
                    if (fLote.ShowDialog() == DialogResult.OK)
                        if (fLote.rLote != null)
                        {
                            try
                            {
                                CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia.Gravar(fLote.rLote, null);
                                MessageBox.Show("Lote alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                id_lotebusca.Text = fLote.rLote.Id_lote.Value.ToString();
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            else
                MessageBox.Show("Necessario selecionar lote para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsLoteCustodia.Current != null)
            {
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir lote enviado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do lote selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia.Excluir(bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia, null);
                        MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Necessario selecionar lote para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbEnviado.Checked)
            {
                status = "'E'";
                virg = ",";
            }
            if (CB_Abertas.Checked)
                status += virg + "'A'";
            string tp_registro = string.Empty;
            virg = string.Empty;
            if (st_custodia.Checked)
            {
                tp_registro = "'C'";
                virg = ",";
            }
            if (st_deposito.Checked)
                tp_registro += virg + "'D'";
            bsLoteCustodia.DataSource = CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia.Buscar(id_lotebusca.Text,
                                                                                                cd_empresabusca.Text,
                                                                                                cd_contager.Text,
                                                                                                cd_banco.Text,
                                                                                                nr_cheque.Text,
                                                                                                rbDtLote.Checked ? "L" : string.Empty,
                                                                                                DT_Inicial.Text,
                                                                                                DT_Final.Text,
                                                                                                string.Empty,
                                                                                                nr_lote.Text,
                                                                                                tp_registro,
                                                                                                status,
                                                                                                null);
            bsLoteCustodia_PositionChanged(this, new EventArgs());
        }

        private void EnviarLote()
        {
            if (bsLoteCustodia.Current != null)
            {
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Lote ja foi enviado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEnviarLote fEnv = new TFEnviarLote())
                {
                    if(fEnv.ShowDialog() == DialogResult.OK)
                    try
                    {
                        (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Nr_lote = fEnv.Nr_lote;
                        (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Dt_enviolote = fEnv.Dt_lote;
                        CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia.EnviarLote(bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia, null);
                        MessageBox.Show("Lote enviado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_lotebusca.Text = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote.Value.ToString();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Necessario selecionar lote para enviar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirItem()
        {
            if (bsLoteCustodia.Current != null)
            {
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido inserir cheque lote ENVIADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFTitulosCustodia fCustodia = new TFTitulosCustodia())
                {
                    fCustodia.Cd_empresa = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Cd_empresa;
                    if (fCustodia.ShowDialog() == DialogResult.OK)
                        if (fCustodia.lChCustodia != null)
                        {
                            try
                            {
                                CamadaDados.Financeiro.Titulo.TList_LoteCustodia_X_Titulo lLote = new CamadaDados.Financeiro.Titulo.TList_LoteCustodia_X_Titulo();
                                fCustodia.lChCustodia.ForEach(p=> lLote.Add(
                                    new CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia_X_Titulo()
                                    {
                                        Cd_banco = p.Cd_banco,
                                        Cd_empresa = p.Cd_empresa,
                                        Nr_lanctocheque = p.Nr_lanctocheque,
                                        Id_lote = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote
                                    }));
                                CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia_X_Titulo.Gravar(lLote, null);
                                MessageBox.Show("Cheques gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                id_lotebusca.Text = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote.Value.ToString();
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                }
            }
            else
                MessageBox.Show("Necessario selecionar lote para inserir cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItem()
        {
            if (bsChequesCustodia.Current != null)
            {
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir titulo de lote ENVIADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do cheque selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia_X_Titulo.Excluir(
                            new CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia_X_Titulo()
                            {
                                Cd_banco = (bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_banco,
                                Cd_empresa = (bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_empresa,
                                Nr_lanctocheque = (bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_lanctocheque,
                                Id_lote = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote
                            }, null);
                        MessageBox.Show("Cheque excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_lotebusca.Text = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote.Value.ToString();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Necessario selecionar cheque para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimeRelatorio()
        {
            if (bsChequesCustodia != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsChequesCustodia;
                    Rel.Ident = "TFConsultaTitulo";
                    Rel.NM_Classe = "TFConsultaTitulo";
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO CONSULTA CHEQUES";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO CONSULTA CHEQUES",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO CONSULTA CHEQUES",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void TFLanCustodiaCH_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheques);
            Utils.ShapeGrid.RestoreShape(this, gLoteCustodia);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresabusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresabusca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresabusca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresabusca.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresabusca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_banco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Banco|Banco|200;"+
                              "a.cd_banco|Cd. Banco|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_banco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Contager|Conta Gerencial|300;a.CD_ContaGer|Cd. Conta|100"
                          , new Componentes.EditDefault[] { cd_contager }
                          , new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_contager  x where x.cd_contager = A.cd_contager " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_contager  x where x.cd_contager = A.cd_contager " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bsLoteCustodia_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteCustodia.Current != null)
            {
                (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodia =
                    CamadaNegocio.Financeiro.Titulo.TCN_LoteCustodia_X_Titulo.BuscarCh((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Id_lote.Value.ToString(), null);
                tot_cheques.Text = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodia.Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                bsLoteCustodia.ResetCurrentItem();
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

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_EnviarLote_Click(object sender, EventArgs e)
        {
            this.EnviarLote();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFLanCustodiaCH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.ImprimeRelatorio();
            else if (e.KeyCode.Equals(Keys.F9))
                this.EnviarLote();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void gLoteCustodia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENVIADO"))
                    {
                        DataGridViewRow linha = gLoteCustodia.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else
                    {
                        DataGridViewRow linha = gLoteCustodia.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void gCheques_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("COMPENSADO"))
                    {
                        DataGridViewRow linha = gCheques.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gCheques.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLanCustodiaCH_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCheques);
            Utils.ShapeGrid.SaveShape(this, gLoteCustodia);
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.ImprimeRelatorio();
        }

        private void BB_Compensar_Click(object sender, EventArgs e)
        {
            if (bsLoteCustodia.Current != null)
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lCh =
                        (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodia.FindAll(p => p.Status_compensado.Trim().ToUpper() != "S");
                    if(lCh.Count > 0)
                        using (TFListaChCustodiaDeposito fLista = new TFListaChCustodiaDeposito())
                        {
                            fLista.lCheque = lCh;
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if(fLista.lCheque.Exists(p=> p.St_processar))
                                    try
                                    {
                                        Utils.InputBox inp = new Utils.InputBox("00/00/0000", "Data Compensação.");
                                        inp.Text = "Informar Data Compensação Cheques.";
                                        DateTime dt_compensacao;
                                        try
                                        {
                                            dt_compensacao = DateTime.Parse(inp.ShowDialog());
                                        }
                                        catch { dt_compensacao = CamadaDados.UtilData.Data_Servidor(); }
                                        fLista.lCheque.FindAll(p=> p.St_processar).ForEach(p =>
                                        {
                                            p.Dt_compensacao = dt_compensacao;
                                            p.Cd_contager_destino = (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).Cd_contager;
                                        });
                                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CompensarCheques(fLista.lCheque.FindAll(p=> p.St_processar), null);
                                        MessageBox.Show("Cheques compensados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
                else
                    MessageBox.Show("Permitido compensar cheques somente de lote enviado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_devolver_Click(object sender, EventArgs e)
        {
            if(bsLoteCustodia.Current != null)
                if ((bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).St_registro.Trim().ToUpper().Equals("E"))
                {
                    using (TFLanDevolucaoCheque fDev = new TFLanDevolucaoCheque())
                    {
                        (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodia.FindAll(p => p.Status_compensado.Trim().ToUpper().Equals("E") ||
                                                                                                                                  p.Status_compensado.Trim().ToUpper().Equals("L")).ForEach(p =>
                            fDev.lCheques.Add(p));
                        string cd_empresa = string.Empty;
                        if (fDev.ShowDialog() == DialogResult.OK)
                            if (fDev.rDev != null)
                                try
                                {
                                    if (fDev.rDev.lCheques.Count < 1)
                                    {
                                        MessageBox.Show("Não existe cheque selecionado para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    CamadaNegocio.Financeiro.Titulo.TCN_DevolucaoCheque.GravarDevolucaoCheque(fDev.rDev, null);
                                    MessageBox.Show("Cheques devolvidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim());
                                }
                            else
                                MessageBox.Show("Não existe registro de devolução de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Permitido compensar cheques somente de lote enviado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
