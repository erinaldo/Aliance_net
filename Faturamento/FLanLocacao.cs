using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.Locacao;
using CamadaNegocio.Faturamento.Locacao;
using CamadaDados.Financeiro.Cadastros;
using System.IO;
using Utils;

namespace Faturamento
{
    public partial class TFLanLocacao : Form
    {
        public bool Altera_Relatorio;// = false;

        public TFLanLocacao()
        {
            InitializeComponent();
        }

        private void TFLanLocacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensLocacao);
            Utils.ShapeGrid.RestoreShape(this, gLocacao);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void LimpaFiltros()
        {
            Id_locacao.Clear();
            Cd_empresa.Clear();
            Cd_clifor.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFLocacao fLocacao = new TFLocacao())
            {
                if (fLocacao.ShowDialog() == DialogResult.OK)
                    if (fLocacao.rLocacao != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Locacao.TCN_Locacao.Gravar(fLocacao.rLocacao, null);
                            MessageBox.Show("Locacao gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimpaFiltros();
                            Id_locacao.Text = fLocacao.rLocacao.Id_locacaostr;
                            Cd_empresa.Text = fLocacao.rLocacao.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbxRetirado.Checked)
            {
                status += virg + "'R'";
                virg = ",";
            }
            if (cbxDevolvido.Checked)
                status += virg + "'D'"; 
            bsLocacao.DataSource = TCN_Locacao.buscar(Cd_empresa.Text,
                                                      Id_locacao.Text,
                                                      Cd_clifor.Text,
                                                      rbDtLocacao.Checked ? "L" : rdDtRetirada.Checked ? "R" : 
                                                      rbDtPrevDev.Checked ? "P" : rbDevolucao.Checked ? "D" : string.Empty,
                                                      dt_ini.Text,
                                                      dt_fin.Text,
                                                      status,
                                                      null);
            bsLocacao_PositionChanged(this, new EventArgs());
        }

        private void afterAltera()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido alterar Locacao Devolvida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("R"))
                {
                    MessageBox.Show("Não é permitido alterar Locacao Retirada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLocacao fLocacao = new TFLocacao())
                {
                    fLocacao.rLocacao = bsLocacao.Current as CamadaDados.Faturamento.Locacao.TRegistro_Locacao;
                    if (fLocacao.ShowDialog() == DialogResult.OK)
                        if (fLocacao.rLocacao != null)
                            try
                            {
                                CamadaNegocio.Faturamento.Locacao.TCN_Locacao.Gravar(fLocacao.rLocacao, null);
                                MessageBox.Show("Locacao alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    this.LimpaFiltros();
                    Id_locacao.Text = fLocacao.rLocacao.Id_locacaostr;
                    Cd_empresa.Text = fLocacao.rLocacao.Cd_empresa;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsLocacao.Current != null)
                if (MessageBox.Show("Confirma exclusão da Locacao selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Locacao.Excluir(bsLocacao.Current as TRegistro_Locacao, null);
                        MessageBox.Show("Locacao excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void EstornarRetirada()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("A"))
                {
                    MessageBox.Show("Locação se encontra ABERTA", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("D"))
                {
                    MessageBox.Show("Locação se encontra DEVOLVIDA", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o estorno da retirada da Locação?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Locacao.TCN_Locacao.EstornaRetirada(bsLocacao.Current as TRegistro_Locacao, null);
                        MessageBox.Show("Retirada da locação estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimpaFiltros();
                        Id_locacao.Text = (bsLocacao.Current as TRegistro_Locacao).Id_locacaostr;
                        Cd_empresa.Text = (bsLocacao.Current as TRegistro_Locacao).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void EstornarDevolucao()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("A"))
                {
                    MessageBox.Show("Locação se encontra ABERTA", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("R"))
                {
                    MessageBox.Show("Locação se encontra RETIRADA", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o estorno da devolução da Locação?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Locacao.TCN_Locacao.EstornaDevolucao(bsLocacao.Current as TRegistro_Locacao, null);
                        MessageBox.Show("Devolução da locação estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimpaFiltros();
                        Id_locacao.Text = (bsLocacao.Current as TRegistro_Locacao).Id_locacaostr;
                        Cd_empresa.Text = (bsLocacao.Current as TRegistro_Locacao).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void RetirarLocacao()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("R"))
                {
                    MessageBox.Show("Locação ja se encontra RETIRADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("D"))
                {
                    MessageBox.Show("Locação ja se encontra DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma RETIDADA  da locação corrente?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                        CamadaNegocio.Faturamento.Locacao.TCN_Locacao.RetirarLocacao(bsLocacao.Current as TRegistro_Locacao, ref rPreVenda, null);
                        MessageBox.Show("Locação retirada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimpaFiltros();
                        Id_locacao.Text = (bsLocacao.Current as TRegistro_Locacao).Id_locacaostr;
                        Cd_empresa.Text = (bsLocacao.Current as TRegistro_Locacao).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void DevolverLocacao()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("A"))
                {
                    MessageBox.Show("Não é permitido DEVOLVER locação ABERTA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Locação ja se encontra DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDevolverLocacao fDevolver = new TFDevolverLocacao())
                {
                    fDevolver.rLocacao = bsLocacao.Current as TRegistro_Locacao;
                    if(fDevolver.ShowDialog() == DialogResult.OK)
                        if(fDevolver.rLocacao != null)
                            try
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                                TCN_Locacao.DevolverLocacao(fDevolver.rLocacao, ref rPreVenda, null);
                                MessageBox.Show("Locação devolvida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimpaFiltros();
                                Id_locacao.Text = fDevolver.rLocacao.Id_locacaostr;
                                Cd_empresa.Text = fDevolver.rLocacao.Cd_empresa;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ImprimirContrato()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("A"))
                {
                    MessageBox.Show("Não é permitido Imprimir contrato de locação ABERTA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource bs_valor = new BindingSource();
                        bs_valor.DataSource = new TList_Locacao() { bsLocacao.Current as TRegistro_Locacao };
                        Rel.DTS_Relatorio = bs_valor;
                        Rel.Ident = this.Name;
                        Rel.NM_Classe = this.Name;
                        Rel.Modulo = string.Empty;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "Contrato de Locação";
                        //Buscar clifor da empresa
                        BindingSource bs_cliforemp = new BindingSource();
                        bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                        Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                        //Buscar Endereco Empresa
                        BindingSource bs_endemp = new BindingSource();
                        bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " + 
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                        Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                        //Buscar CFG Locacao
                        BindingSource bs_CFGLoc = new BindingSource();
                        bs_CFGLoc.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar((bsLocacao.Current as TRegistro_Locacao).Cd_empresa,
                                                                                                                                                   string.Empty,
                                                                                                                                                   string.Empty,
                                                                                                                                                   string.Empty,
                                                                                                                                                   null);
                        Rel.Adiciona_DataSource("DTS_CFGLoc", bs_CFGLoc);
                        //Buscar Cliente da Locacao
                        BindingSource bs_CliforLocacao = new BindingSource();
                        bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
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
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    string.Empty,
                                                                                                                    0,
                                                                                                                    null);
                        Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                        //Buscar Endereco do Clifor
                        BindingSource bs_endClifor = new BindingSource();
                        bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
                                                                                                             (bsLocacao.Current as TRegistro_Locacao).Cd_endereco,
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
                                                                                                                                                        0,
                                                                                                                                                        null);
                        Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);
                                                                                                                                                                                                                                  
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
                                               "Contrato de Locação",
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
                                                   "Contrato de Locação",
                                                   fImp.pDs_mensagem);
                    }
                
                
            }
            else
                MessageBox.Show("Obrigatorio selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { Cd_empresa }, string.Empty);
        }

        private void Cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + Cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsLocacao_PositionChanged(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                (bsLocacao.Current as TRegistro_Locacao).lItens =
                    TCN_ItensLocacao.buscar((bsLocacao.Current as TRegistro_Locacao).Cd_empresa,
                                            (bsLocacao.Current as TRegistro_Locacao).Id_locacaostr,
                                            null);
                (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p =>
                    p.lFichaTec = CamadaNegocio.Faturamento.Locacao.TCN_FichaTecItensLoc.Buscar(p.Cd_empresa,
                                                                                                p.Id_locacaostr,
                                                                                                p.Id_itemstr,
                                                                                                string.Empty,
                                                                                                null));
                bsLocacao.ResetCurrentItem();
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

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void TFLanLocacao_KeyDown(object sender, KeyEventArgs e)
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
                this.ImprimirContrato();
            else if (e.KeyCode.Equals(Keys.F9))
                this.RetirarLocacao();
            else if (e.KeyCode.Equals(Keys.F10))
                this.DevolverLocacao();
            else if (e.KeyCode.Equals(Keys.F11))
                this.EstornarRetirada();
            else if (e.KeyCode.Equals(Keys.F12))
                this.EstornarDevolucao();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.",  "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_retirar_Click(object sender, EventArgs e)
        {
            this.RetirarLocacao();
        }

        private void bb_devolver_Click(object sender, EventArgs e)
        {
            this.DevolverLocacao();
        }

        private void gLocacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("RETIRADO"))
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_estornarRet_Click(object sender, EventArgs e)
        {
            this.EstornarRetirada();
        }

        private void bb_estornarDev_Click(object sender, EventArgs e)
        {
            this.EstornarDevolucao();
        }
             
        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.ImprimirContrato();
        }

        private void TFLanLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensLocacao);
            Utils.ShapeGrid.SaveShape(this, gLocacao);
        }    
    }
}
