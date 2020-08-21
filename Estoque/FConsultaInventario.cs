using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;

namespace Estoque
{
    public partial class TFConsultaInventario : Form
    {
        private Utils.TTpModo vModoSaldo;

        private bool Altera_Relatorio = false;

        public TFConsultaInventario()
        {
            InitializeComponent();
            vModoSaldo = Utils.TTpModo.tm_Standby;
        }

        private void AtivarCampos(bool Valor)
        {
            if (Valor)
            {
                //Exigir almoxarifado
                if ((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).St_consumointerno.Equals("S"))
                {
                    id_almox.Enabled = Valor;
                    bb_almox.Enabled = Valor;
                    cd_local.Enabled = !Valor;
                    bb_local.Enabled = !Valor;
                }

                //Exigir local/estoque
                else
                {
                    cd_local.Enabled = Valor;
                    bb_local.Enabled = Valor;
                    id_almox.Enabled = !Valor;
                    bb_almox.Enabled = !Valor;
                }

                qtd_contadaEditFloat.Enabled = Valor;
                vl_unitarioEditFloat.Enabled = Valor;
            }
            else
            {
                id_almox.Enabled = Valor;
                bb_almox.Enabled = Valor;
                cd_local.Enabled = Valor;
                bb_local.Enabled = Valor;
                qtd_contadaEditFloat.Enabled = Valor;
                vl_unitarioEditFloat.Enabled = Valor;
            }

            //Desabilita alteração de corrente na alteração
            gSaldoItem.Enabled = !Valor;
        }

        private void LimparFiltros()
        {
            id_inventario.Clear();
            CD_Empresa.Clear();
            dt_fin.Clear();
            dt_ini.Clear();
            st_aberto.Checked = false;
            st_processado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFInventario fInventario = new TFInventario())
            {
                if (fInventario.ShowDialog() == DialogResult.OK)
                    if (fInventario.rInventario != null)
                    {
                        try
                        {
                            CamadaNegocio.Estoque.TCN_LanInventario.GravarInventario(fInventario.rInventario, null);
                            MessageBox.Show("Inventario gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_inventario.Text = fInventario.rInventario.Id_inventario.Value.ToString();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsInventario.Current != null)
            {
                if ((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).St_inventario.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido alterar inventario PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFInventario fInventario = new TFInventario())
                {
                    fInventario.rInventario = bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario;
                    if (fInventario.ShowDialog() == DialogResult.OK)
                        if (fInventario.rInventario != null)
                        {
                            try
                            {
                                CamadaNegocio.Estoque.TCN_LanInventario.GravarInventario(fInventario.rInventario, null);
                                MessageBox.Show("Inventario alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    LimparFiltros();
                    id_inventario.Text = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value.ToString();
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsInventario.Current != null)
            {
                if ((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).St_inventario.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir inventario PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do inventario selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Estoque.TCN_LanInventario.DeletarInventario(bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario, null);
                        MessageBox.Show("Inventario excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterBusca()
        {
            string aux = string.Empty;
            string virg = string.Empty;
            if (st_aberto.Checked)
            {
                aux = "'A'";
                virg = ",";
            }
            if (st_processado.Checked)
                aux += virg + "'P'";
            bsInventario.DataSource = CamadaNegocio.Estoque.TCN_LanInventario.Busca(id_inventario.Text,
                                                                                    CD_Empresa.Text,
                                                                                    aux,
                                                                                    dt_ini.Text,
                                                                                    dt_fin.Text,
                                                                                    null);
            bsInventario_PositionChanged(this, new EventArgs());
        }

        private void ProcessarInventario()
        {
            if (bsInventario.Current != null)
            {
                if ((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).St_inventario.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Inventário já se encontrato PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                object obj = new CamadaDados.Estoque.TCD_Inventario_Item().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_inventario",
                                        vOperador = "=",
                                        vVL_Busca = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_est_inventario_item_x_saldo x " +
                                                    "where x.id_inventario = a.id_inventario " +
                                                    "and x.cd_produto = a.cd_produto)"
                                    }
                                }, "1");
                if (obj != null)
                    if (MessageBox.Show("Inventário possui item sem contagem de estoque.\r\n" +
                                       "Deseja processar o inventario mesmo assim?", "Pergunta",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        return;
                if (obj != null ? true : MessageBox.Show("Confirma processamento do inventário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Estoque.TCN_LanInventario.ProcessarInventario(bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario, null);
                        MessageBox.Show("Inventário processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_inventario.Text = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value.ToString();
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void NovoSaldo()
        {
            if ((bsItensInventario.Current != null) && vModoSaldo.Equals(Utils.TTpModo.tm_Standby))
            {
                bsSaldoItem.AddNew();
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Id_inventario = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario;
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Cd_produto = (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto;
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Ds_produto = (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Ds_produto;
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Ds_unidade = (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Sigla_unidade;
                //Buscar Vl Medio estoque
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Vl_unitario =
                    CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa,
                                                                                 (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                                 null);

                bsSaldoItem.ResetCurrentItem();
                vModoSaldo = Utils.TTpModo.tm_Insert;
                AtivarCampos(true);
            }
        }

        private void GravarSaldo()
        {
            if (vModoSaldo.Equals(Utils.TTpModo.tm_Insert) || (bsSaldoItem.Current != null))
            {
                if ((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).St_consumointerno.Equals("N") && string.IsNullOrEmpty(cd_local.Text))
                {
                    MessageBox.Show("Obrigatório informar local armazemagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_local.Focus();
                    return;
                }
                else if ((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).St_consumointerno.Equals("S") && string.IsNullOrEmpty(id_almox.Text))
                {
                    MessageBox.Show("Obrigatório informar almoxarifado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_almox.Focus();
                    return;
                }
                if (qtd_contadaEditFloat.Focused)
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_contada = qtd_contadaEditFloat.Value;
                if (vl_unitarioEditFloat.Focused)
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Vl_unitario = vl_unitarioEditFloat.Value;
                try
                {
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.GravarInventarioItemSaldo(
                        bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo, null);
                    vModoSaldo = Utils.TTpModo.tm_Standby;
                    AtivarCampos(false);
                    bsItensInventario.MoveNext();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ExcluirSaldo()
        {
            if (bsSaldoItem.Current != null)
                if (MessageBox.Show("Confirma exclusão do saldo selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.DeletarInventarioItemSaldo(
                            bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo, null);
                        bsSaldoItem.RemoveCurrent();
                        AtivarCampos(false);
                        vModoSaldo = Utils.TTpModo.tm_Standby;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
        }

        private void PrintSaldoInventario()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                BindingSource bssaldo = new BindingSource();
                bssaldo.DataSource = new CamadaDados.Estoque.TCD_Inventario_Item_X_Saldo().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.id_inventario",
                                                vOperador = "=",
                                                vVL_Busca = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.ToString()
                                            }
                                        }, 0, string.Empty);
                Rel.DTS_Relatorio = bssaldo;
                Rel.Nome_Relatorio = "REST_SaldoInventario";
                Rel.NM_Classe = "REST_SaldoInventario";
                Rel.Modulo = string.Empty;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO SALDO INVENTARIO";

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
                                       "RELATORIO SALDO ESTOQUE",
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
                                       "RELATORIO SALDO ESTOQUE",
                                       fImp.pDs_mensagem);
            }
        }

        private void PrintItensInventariar()
        {
            BindingSource DTS = new BindingSource();
            DTS.DataSource = CamadaNegocio.Estoque.TCN_LanInventario.Busca((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value);
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = DTS;
                Rel.Nome_Relatorio = "REST_ItensInventario";
                Rel.NM_Classe = "REST_ItensInventario";
                Rel.Modulo = string.Empty;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO ITENS INVENTARIAR";

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
                                       "RELATORIO ITENS INVENTARIAR",
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
                                       "RELATORIO ITENS INVENTARIAR",
                                       fImp.pDs_mensagem);
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bsInventario_PositionChanged(object sender, EventArgs e)
        {
            if (bsInventario.Current != null)
            {
                (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).lItensInventario =
                    CamadaNegocio.Estoque.TCN_Inventario_Item.Busca((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value.ToString(),
                                                                    string.Empty,
                                                                    null);
                bsInventario.ResetCurrentItem();
                bsItensInventario_PositionChanged(this, new EventArgs());
                bsSaldoItem_PositionChanged(this, new EventArgs());
                pDadosSaldo.Enabled = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).St_inventario.Trim().ToUpper().Equals("A") &&
                                        ((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).lItensInventario.Count > 0);
            }
        }

        private void bsItensInventario_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensInventario.Current != null)
            {
                (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).lSaldoItem =
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.Buscar((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Id_inventario.Value.ToString(),
                                                                             (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             null);
                bsItensInventario.ResetCurrentItem();
                if (vModoSaldo.Equals(Utils.TTpModo.tm_Insert))
                {
                    vModoSaldo = Utils.TTpModo.tm_Standby;
                    AtivarCampos(false);
                }
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void gInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Equals("PROCESSADO"))
                    gInventario.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gInventario.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void saldoItensInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSaldoInventario();
        }

        private void itensInventariarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintItensInventariar();
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto =
            CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto);
            string vParam = "|not exists|(select 1 from tb_est_inventario_item_x_saldo x " +
                            "               where x.id_inventario = " + id_inventariosaldo.Text + " " +
                            "               and x.cd_produto = '" + cd_produto.Text.Trim() + "' " +
                            "               and x.cd_local = a.cd_local);" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { cd_local, ds_local },
                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto : string.Empty, (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa), vParam);
            if (bsSaldoItem.Current != null && !string.IsNullOrEmpty(cd_local.Text))
            {
                CamadaDados.Estoque.TList_Inventario_Item_X_Saldo lSaldo =
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.Buscar((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Id_inventario.Value.ToString(),
                                                                             (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                             cd_local.Text,
                                                                             string.Empty,
                                                                             null);
                if(lSaldo.Count > 0)
                {
                    MessageBox.Show("Ja existe saldo para o item selecionado no local de armazenagem informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldo =
                        CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa,
                                                                               (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                               cd_local.Text,
                                                                               null);
                bsSaldoItem.ResetCurrentItem();
            }
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto =
            CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto);
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|not exists|(select 1 from tb_est_inventario_item_x_saldo x " +
                            "               where x.cd_local = a.cd_local " +
                            "               and x.id_inventario = " + id_inventariosaldo.Text + " " +
                            "               and x.cd_produto = '" + cd_produto.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto : string.Empty, CD_Empresa.Text));

            if (bsSaldoItem.Current != null && !string.IsNullOrEmpty(cd_local.Text))
            {
                CamadaDados.Estoque.TList_Inventario_Item_X_Saldo lSaldo =
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.Buscar((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Id_inventario.Value.ToString(),
                                                                             (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                             cd_local.Text,
                                                                             string.Empty,
                                                                             null);
                if (lSaldo.Count > 0)
                {
                    MessageBox.Show("Ja existe saldo para o item selecionado no local de armazenagem informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldo =
                        CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa,
                                                                               (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                               cd_local.Text,
                                                                               null);
                bsSaldoItem.ResetCurrentItem();
                bsSaldoItem.ResetCurrentItem();
            }
        }

        private void TFConsultaInventario_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEstoque);
            Utils.ShapeGrid.RestoreShape(this, gSaldoItem);
            Utils.ShapeGrid.RestoreShape(this, gInventario);
            Utils.ShapeGrid.RestoreShape(this, gItensInventario);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pDadosSaldo.set_FormatZero();
        }

        private void ts_btn_Inserir_Endereco_Click(object sender, EventArgs e)
        {
            NovoSaldo();
        }

        private void ts_btn_Alterar_Endereco_Click(object sender, EventArgs e)
        {
            GravarSaldo();
        }

        private void ts_btn_Deletar_Endereco_Click(object sender, EventArgs e)
        {
            ExcluirSaldo();
        }

        private void bb_processa_Click(object sender, EventArgs e)
        {
            ProcessarInventario();
        }

        private void TFConsultaInventario_KeyDown(object sender, KeyEventArgs e)
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
                ProcessarInventario();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                NovoSaldo();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                GravarSaldo();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirSaldo();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio para alterar layout.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void bsSaldoItem_PositionChanged(object sender, EventArgs e)
        {
            if (bsSaldoItem.Current != null)
            {
                (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).lEstoque =
                    new CamadaDados.Estoque.TCD_LanEstoque().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_inventario_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_inventario = " + (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Id_inventario.Value.ToString() + " " +
                                        "and x.cd_produto = '" + (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Cd_produto.Trim() + "' " +
                                        "and x.id_registro = '" +(bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Id_registro + "' ) "
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                bsSaldoItem.ResetCurrentItem();
            }
        }

        private void gInventario_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gInventario.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsInventario.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.Tregistro_Inventario());
            CamadaDados.Estoque.Tlist_Inventario lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.Tlist_Inventario(lP.Find(gInventario.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gInventario.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.Tlist_Inventario(lP.Find(gInventario.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gInventario.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsInventario.List as CamadaDados.Estoque.Tlist_Inventario).Sort(lComparer);
            bsInventario.ResetBindings(false);
            gInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gItensInventario_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensInventario.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensInventario.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_Inventario_Item());
            CamadaDados.Estoque.TList_Inventario_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_Inventario_Item(lP.Find(gItensInventario.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensInventario.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_Inventario_Item(lP.Find(gItensInventario.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensInventario.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensInventario.List as CamadaDados.Estoque.TList_Inventario_Item).Sort(lComparer);
            bsItensInventario.ResetBindings(false);
            gItensInventario.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gSaldoItem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gSaldoItem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsSaldoItem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo());
            CamadaDados.Estoque.TList_Inventario_Item_X_Saldo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gSaldoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gSaldoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_Inventario_Item_X_Saldo(lP.Find(gSaldoItem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gSaldoItem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_Inventario_Item_X_Saldo(lP.Find(gSaldoItem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gSaldoItem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsSaldoItem.List as CamadaDados.Estoque.TList_Inventario_Item_X_Saldo).Sort(lComparer);
            bsSaldoItem.ResetBindings(false);
            gSaldoItem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gEstoque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEstoque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEstoque.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_LanEstoque());
            CamadaDados.Estoque.TList_RegLanEstoque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_RegLanEstoque(lP.Find(gEstoque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEstoque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_RegLanEstoque(lP.Find(gEstoque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEstoque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEstoque.List as CamadaDados.Estoque.TList_RegLanEstoque).Sort(lComparer);
            bsEstoque.ResetBindings(false);
            gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFConsultaInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEstoque);
            Utils.ShapeGrid.SaveShape(this, gSaldoItem);
            Utils.ShapeGrid.SaveShape(this, gInventario);
            Utils.ShapeGrid.SaveShape(this, gItensInventario);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
            if (!string.IsNullOrEmpty(id_almox.Text))
            {
                CamadaDados.Estoque.TList_Inventario_Item_X_Saldo lSaldo =
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.Buscar((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Id_inventario.Value.ToString(),
                                                                             (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                             string.Empty,
                                                                             id_almox.Text,
                                                                             null);
                if (lSaldo.Count > 0)
                {
                    MessageBox.Show("Ja existe saldo para o item selecionado no almoxarifado informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldo =
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldoAmx
                        = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa,
                                                                                              id_almox.Text,
                                                                                              (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                                              null);
                bsSaldoItem.ResetCurrentItem();
            }
                
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), string.Empty);
            if (!string.IsNullOrEmpty(id_almox.Text))
            {
                CamadaDados.Estoque.TList_Inventario_Item_X_Saldo lSaldo =
                    CamadaNegocio.Estoque.TCN_Inventario_Item_X_Saldo.Buscar((bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Id_inventario.Value.ToString(),
                                                                             (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                             string.Empty,
                                                                             id_almox.Text,
                                                                             null);
                if (lSaldo.Count > 0)
                {
                    MessageBox.Show("Ja existe saldo para o item selecionado no almoxarifado informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldo =
                    (bsSaldoItem.Current as CamadaDados.Estoque.TRegistro_Inventario_Item_X_Saldo).Qtd_saldoAmx
                        = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox((bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Cd_empresa,
                                                                                              id_almox.Text,
                                                                                              (bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item).Cd_produto,
                                                                                              null);
                bsSaldoItem.ResetCurrentItem();
            }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedIndex.Equals(1) && bsInventario.Current == null)
                return;
        }
    }
}
