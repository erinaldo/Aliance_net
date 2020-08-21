using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFLan_AutorizRetDeposito : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_AutorizRetDeposito()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_autoriz.Clear();
            nr_Contrato.Clear();
            cd_clifor.Clear();
            cd_produto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFAutorizRetDeposito fAutoriz = new TFAutorizRetDeposito())
            {
                if(fAutoriz.ShowDialog() == DialogResult.OK)
                    if (fAutoriz.rAutoriz != null)
                    {
                        try
                        {
                            CamadaNegocio.Graos.TCN_AutorizRetDeposito.Gravar(fAutoriz.rAutoriz, null);
                            MessageBox.Show("Autorização retirada de produto em deposito gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_autoriz.Text = fAutoriz.rAutoriz.Id_autorizstr;
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
            if (bsAutoriz.Current != null)
            {
                if (!CamadaNegocio.Graos.TCN_AutorizRetDeposito.AutorizComMovimentacao((bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito).Id_autorizstr, null))
                {
                    using (TFAutorizRetDeposito fAutoriz = new TFAutorizRetDeposito())
                    {
                        fAutoriz.rAutoriz = bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito;
                        if (fAutoriz.ShowDialog() == DialogResult.OK)
                            if (fAutoriz.rAutoriz != null)
                            {
                                try
                                {
                                    CamadaNegocio.Graos.TCN_AutorizRetDeposito.Gravar(fAutoriz.rAutoriz, null);
                                    MessageBox.Show("Autorização alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        this.LimparFiltros();
                        id_autoriz.Text = fAutoriz.rAutoriz.Id_autorizstr;
                        this.afterBusca();
                    }
                }
                else
                    MessageBox.Show("Não é permitido excluir autorização de retirada com movimentação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatório selecionar autorização para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsAutoriz.DataSource = CamadaNegocio.Graos.TCN_AutorizRetDeposito.Buscar(id_autoriz.Text,
                                                                                     nr_Contrato.Text,
                                                                                     cd_clifor.Text,
                                                                                     string.Empty,
                                                                                     dt_ini.Text,
                                                                                     dt_fin.Text,
                                                                                     string.Empty,
                                                                                     "'A'",
                                                                                     null);
            bsAutoriz_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsAutoriz.Current != null)
                if (!CamadaNegocio.Graos.TCN_AutorizRetDeposito.AutorizComMovimentacao((bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito).Id_autorizstr, null))
                {
                    if (MessageBox.Show("Confirma exclusão da autorização selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Graos.TCN_AutorizRetDeposito.Excluir(bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito, null);
                            MessageBox.Show("Autorização retirada excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Não é permitido excluir autorização de retirada com movimentação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Obrigatório selecionar autorização para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterPrint()
        {
            if (bsAutoriz.Count > 0)
                //Chamar tela de impressao relatorio
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = this.Altera_Relatorio;
                    Rel.DTS_Relatorio = bsAutoriz;
                    Rel.Nome_Relatorio = this.Name.Trim();
                    Rel.Ident = this.Name.Trim();
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "GRO";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO AUTORIZACAO RETIRADA";

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
                                           "RELATORIO AUTORIZACAO RETIRADA",
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
                                               "RELATORIO AUTORIZACAO RETIRADA",
                                               fImp.pDs_mensagem);
                }
            else
                MessageBox.Show("Não existe autorização retirada para imprimir relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirTermo()
        {
            if (bsAutoriz.Current != null)
                //Chamar tela de impressao relatorio
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = this.Altera_Relatorio;
                    BindingSource bs_termo = new BindingSource();
                    bs_termo.DataSource = new CamadaDados.Graos.TList_AutorizRetDeposito() { bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito };
                    Rel.DTS_Relatorio = bs_termo;
                    Rel.Nome_Relatorio = "REL_TERMO_RETIRADA_DEPOSITO";
                    Rel.Ident = "REL_TERMO_RETIRADA_DEPOSITO";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "GRO";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "TERMO RETIRADA PRODUTO EM DEPOSITO";

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
                                           "TERMO RETIRADA DE PRODUTO EM DEPOSITO",
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
                                               "TERMO RETIRADA DE PRODUTO EM DEPOSITO",
                                               fImp.pDs_mensagem);
                }
            else
                MessageBox.Show("Obrigatorio selecionar autorização para imprimir termo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLan_AutorizRetDeposito_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAutoriz);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.sigla_unidade|UND|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bsAutoriz_PositionChanged(object sender, EventArgs e)
        {
            if(bsAutoriz.Current != null)
                if ((bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito).Id_autoriz != null)
                {
                    (bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito).lPesagem =
                        new CamadaDados.Balanca.TCD_LanPesagemGraos().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_Autoriz",
                                vOperador = "=",
                                vVL_Busca = (bsAutoriz.Current as CamadaDados.Graos.TRegistro_AutorizRetDeposito).Id_autorizstr
                            }
                        }, string.Empty, string.Empty, 0, string.Empty);
                    bsAutoriz.ResetCurrentItem();
                }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void TFLan_AutorizRetDeposito_KeyDown(object sender, KeyEventArgs e)
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
                this.afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                this.ImprimirTermo();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void BB_ImpTermo_Click(object sender, EventArgs e)
        {
            this.ImprimirTermo();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLan_AutorizRetDeposito_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAutoriz);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_Contrato },
                                                        "a.tp_movimento|=|'E';" +
                                                        "isnull(a.st_registro, 'A')|=|'A';" +
                                                        "isnull(cfgped.st_deposito, 'N')|=|'S'");
        }

        private void nr_Contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_Contrato.Text + ";" +
                            "a.tp_movimento|=|'E';" +
                            "isnull(a.st_registro, 'A')|=|'A';" +
                            "isnull(cfgped.st_deposito, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_Contrato },
                                              new CamadaDados.Graos.TCD_CadContrato());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
