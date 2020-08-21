using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;

namespace Commoditties
{
    public partial class TFLan_Contratos : Form
    {
        public TFLan_Contratos()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new Utils.TDataCombo("CONVENCIONAL", "CV"));
            cbx.Add(new Utils.TDataCombo("TRANGENICA", "TR"));
            cbx.Add(new Utils.TDataCombo("INTACTA DECLARADA", "ID"));
            cbx.Add(new Utils.TDataCombo("INTACTA TESTADA", "IT"));
            cbx.Add(new Utils.TDataCombo("INTACTA PARTICIPANTE", "IP"));
            tp_prodcontrato.DataSource = cbx;
            tp_prodcontrato.DisplayMember = "Display";
            tp_prodcontrato.ValueMember = "Value";
        }

        private void afterNovo()
        {
            using (TFContrato fContrato = new TFContrato())
            {
                if(fContrato.ShowDialog() == DialogResult.OK)
                    if (fContrato.rContrato != null)
                    {
                        try
                        {
                            CamadaNegocio.Graos.TCN_CadContrato.GravarContrato(fContrato.rContrato, null);
                            MessageBox.Show("Contrato gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            nr_contrato.Text = fContrato.rContrato.Nr_contratostr;
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
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("E"))
                {
                    if(MessageBox.Show("Contrato ENCERRADO. Deseja ATIVAR o contrato novamente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //Voltar status do contrato para A - ATIVO
                        try
                        {
                            CamadaNegocio.Graos.TCN_CadContrato.AtivarContrato((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato), null);
                            MessageBox.Show("Contrato alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else
                {
                    using (TFContrato fContrato = new TFContrato())
                    {
                        fContrato.rContrato = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato);
                        if (fContrato.ShowDialog() == DialogResult.OK)
                        {
                            bsContrato.ResetCurrentItem();
                            if (fContrato.rContrato != null)
                            {
                                try
                                {
                                    CamadaNegocio.Graos.TCN_CadContrato.GravarContrato(fContrato.rContrato, null);
                                    MessageBox.Show("Contrato alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.LimparFiltros();
                                    nr_contrato.Text = fContrato.rContrato.Nr_contratostr;
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe contrato selecionado para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir contrato encerrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do contrato selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Graos.TCN_CadContrato.DeletarContrato(bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato, null);
                        MessageBox.Show("Contrato excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Não existe contrato selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EncerrarContrato()
        {
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido ENCERRAR contrato CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Contrato ja se encontra ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Contrato com status ENCERRADO não podera ser movimentado dentro do sistema.\r\n"+
                                    "Confirma encerramento do contrato?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Graos.TCN_CadContrato.EncerrarContrato(bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato, null);
                        MessageBox.Show("Contrato ENCERRADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Não existe contrato selecionado para encerrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void afterBusca()
        {
            string tp_mov = string.Empty;
            string virg = string.Empty;
            if (cbEntrada.Checked)
            {
                tp_mov = virg.Trim() + "'E'";
                virg = ",";
            }
            if (cbSaida.Checked)
            {
                tp_mov += virg.Trim() + "'S'";
                virg = ",";
            }
            string st_registro = string.Empty;
            virg = string.Empty;
            if (cbAberto.Checked)
            {
                st_registro = virg.Trim() + "'A'";
                virg = ",";
            }
            if (cbEncerrado.Checked)
            {
                st_registro += virg.Trim() + "'E'";
                virg = ",";
            }
            bsContrato.DataSource = CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(tp_mov,
                                                                                       nr_contrato.Text,
                                                                                       cd_empresa.Text,
                                                                                       cd_clifor.Text,
                                                                                       nr_pedido.Text,
                                                                                       cfg_pedido.Text,
                                                                                       anosafra.Text,
                                                                                       cd_tabeladesconto.Text,
                                                                                       cd_produto.Text,
                                                                                       (rbAbertura.Checked ? "A" : "E"),
                                                                                       DT_Inic.Text,
                                                                                       DT_Final.Text,
                                                                                       st_registro,
                                                                                       tp_prodcontrato.SelectedValue != null ? string.IsNullOrEmpty(tp_prodcontrato.SelectedValue.ToString()) ? string.Empty : ("'" + tp_prodcontrato.SelectedValue.ToString() + "'") : string.Empty,
                                                                                       null);
            bsContrato_PositionChanged(this, new EventArgs());
        }

        private void LimparFiltros()
        {
            nr_contrato.Clear();
            nr_pedido.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
            cd_tabeladesconto.Clear();
            anosafra.Clear();
            cd_produto.Clear();
            cbEntrada.Checked = false;
            cbSaida.Checked = false;
            cbAberto.Checked = false;
            cbEncerrado.Checked = false;
            DT_Inic.Clear();
            DT_Final.Clear();
            cfg_pedido.Clear();
        }

        private void AdiantamentoContrato()
        {
            if(bsContrato.Current != null)
            {
                using (Financeiro.TFLan_Adiantamento fAdto = new Financeiro.TFLan_Adiantamento())
                {
                    fAdto.BS_Adiantamento.AddNew();
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_empresa;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nm_empresa;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_clifor;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nm_clifor;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).CD_Endereco = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_endereco;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).DS_Endereco = 
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Ds_endereco;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).TP_Lancto = "C";

                    fAdto.CD_Empresa.Enabled = false;
                    fAdto.BB_Empresa.Enabled = false;
                    fAdto.cd_clifor.Enabled = false;
                    fAdto.bb_clifor.Enabled = false;
                    fAdto.CD_Endereco.Enabled = false;
                    fAdto.bb_endereco.Enabled = false;

                    if (fAdto.ShowDialog() == DialogResult.OK)
                    {
                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).rAdto = fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento;
                        try
                        {
                            CamadaNegocio.Graos.TCN_CadContrato.AdiantamentoContrato(bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato, null);
                            MessageBox.Show("Adiantamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
                else
                MessageBox.Show("Obrigatorio selecionar adiantamento para lançar adiantamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void faturarContrato(string Tp_nf)
        {
            if (bsContrato.Current != null)
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("A"))
                {
                    //Buscar Pedido do contrato
                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed =
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_pedidostr, null);
                    //Verificar se o pedido tem configuracao fiscal para emitir nota
                    if(new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rPed.CFG_Pedido.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "in",
                                    vVL_Busca = "(" + Tp_nf + ")"
                                }
                            }, "1") == null)
                    {
                        MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + rPed.CFG_Pedido.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (Faturamento.TFLanFaturamento fFaturamento = new Faturamento.TFLanFaturamento())
                    {
                        if (Tp_nf.ToUpper().Equals("'NO'") ||
                            Tp_nf.ToUpper().Equals("'CP', 'CF'") ||
                            Tp_nf.ToUpper().Equals("'FT'"))
                            fFaturamento.vTp_movimento = rPed.TP_Movimento;
                        else if (rPed.TP_Movimento.Trim().ToUpper().Equals("E"))
                            fFaturamento.vTp_movimento = "S";
                        else
                            fFaturamento.vTp_movimento = "E";
                        fFaturamento.Nr_pedidoFaturar = rPed.Nr_pedido.ToString();
                        fFaturamento.vTp_NFFiscal = Tp_nf;
                        fFaturamento.ShowDialog();
                        this.afterBusca();
                    }
                }
                else
                    MessageBox.Show("É permitido faturar somente pedido fechado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLan_Contratos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.RestoreShape(this, gContrato);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault6);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltros.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsContrato_PositionChanged(object sender, EventArgs e)
        {
            if(bsContrato.Current != null)
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato != null)
                {
                    //Buscar Taxas
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Taxas =
                        CamadaNegocio.Graos.TCN_CadContratoTaxaDeposito.Buscar(decimal.Zero,
                                                                               (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato.Value,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               0,
                                                                               null);
                    //Buscar Adiantamentos
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lAdto =
                        CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.BuscarAdtoContrato((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato.Value.ToString(), null);
                    //Buscar Headge
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lContrato_Headge =
                        CamadaNegocio.Graos.TCN_CadContrato_Headge.Busca(string.Empty,
                                                                        (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null);
                    //Buscar estoque embalagem
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lEstoqueEmbalagem =
                        CamadaNegocio.Graos.TCN_Contrato_X_EstoqueEmbalagem.BuscarEstoque(
                                                                                          (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr,
                                                                                          null);
                    //Buscar desdobros especial contrato
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lDesdobro =
                        CamadaNegocio.Graos.TCN_Contrato_X_DesdEspecial.Buscar(string.Empty,
                                                                               (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr,
                                                                               string.Empty,
                                                                               null);
                    bsContrato.ResetCurrentItem();
                    tsdFatContrato.Visible = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).St_registro.Trim().ToUpper().Equals("A");
                }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { cd_clifor }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tabeladesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabeladesconto|Tabela Desconto|200;" +
                              "a.cd_tabeladesconto|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto },
                                    new CamadaDados.Graos.TCD_CadDesconto(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabeladesconto },
                                    new CamadaDados.Graos.TCD_CadDesconto());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Ano Safra|200;" +
                              "a.anosafra|Cd. Safra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra },
                                    new CamadaDados.Graos.TCD_CadSafra(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra },
                                    new CamadaDados.Graos.TCD_CadSafra());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
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

        private void bb_encerrar_Click(object sender, EventArgs e)
        {
            this.EncerrarContrato();
        }

        private void gContrato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                    {
                        DataGridViewRow linha = gContrato.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gContrato.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }   
        }

        private void TFLan_Contratos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.EncerrarContrato();
            else if (e.KeyCode.Equals(Keys.F12))
                this.AdiantamentoContrato();
        }

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tipopedido|Tipo Pedido|200;" +
                            "a.cfg_pedido|CFG. Pedido|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { cfg_pedido },
                                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), string.Empty);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido },
                                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_adtocontrato_Click(object sender, EventArgs e)
        {
            this.AdiantamentoContrato();
        }

        private void TFLan_Contratos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            Utils.ShapeGrid.SaveShape(this, gContrato);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault6);
        }

        private void gContrato_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gContrato.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsContrato.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Graos.TRegistro_CadContrato());
            CamadaDados.Graos.TList_CadContrato lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Graos.TList_CadContrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Graos.TList_CadContrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsContrato.List as CamadaDados.Graos.TList_CadContrato).Sort(lComparer);
            bsContrato.ResetBindings(false);
            gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            this.faturarContrato("'NO'");
        }

        private void miNfDev_Click(object sender, EventArgs e)
        {
            this.faturarContrato("'DV','DF'");
        }

        private void miNfComplemento_Click(object sender, EventArgs e)
        {
            this.faturarContrato("'CP', 'CF'");
        }

        private void miNfEntregaFut_Click(object sender, EventArgs e)
        {
            this.faturarContrato("'FT'");
        }
    }
}
