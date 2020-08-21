using System;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;

namespace Compra
{
    public partial class TFLanOrdemCompra : Form
    {
        public TFLanOrdemCompra()
        {
            InitializeComponent();
        }

        private void ProcessarOC()
        {
            using (TFGerarOrdemCompra fGerar = new TFGerarOrdemCompra())
            {
                fGerar.ShowDialog();
                afterBusca();
            }
        }

        private void afterExclui()
        {
            if (bsOrdemCompra.Current != null)
            {
                if ((bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Ordem de Compra ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_registro.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Ordem de Compra ja gerou pedido.\r\n" +
                                    "Para cancelar Ordem Compra necessario antes cancelar o pedido " + (bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).Nr_pedido.Value.ToString() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento da ordem de compra?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.Estornar(bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra, null);
                        MessageBox.Show("Ordem Compra cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void afterBusca()
        {
            string st = string.Empty;
            string virg = string.Empty;
            if(st_aberta.Checked)
            {
                st += virg.Trim() + "'A'";
                virg = ",";
            }
            if(st_faturada.Checked)
            {
                st += virg.Trim() + "'F'";
                virg = ",";
            }
            if(st_cancelada.Checked)
            {
                st += virg.Trim() + "'C'";
                virg = ",";
            }
            bsOrdemCompra.DataSource = CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.Buscar(id_os.Text,
                                                                                              cd_empresa.Text,
                                                                                              cd_produto.Text,
                                                                                              cd_fornecedor.Text,
                                                                                              cd_condpgto.Text,
                                                                                              cd_moeda.Text,
                                                                                              cd_portador.Text,
                                                                                              cd_transportadora.Text,
                                                                                              st,
                                                                                              nr_pedido.Text,
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
        }

        private void ProcessarPedido()
        {
            using (TFGerarPedidoCompra fPedido = new TFGerarPedidoCompra())
            {
                if (fPedido.ShowDialog() == DialogResult.OK)
                {
                    if (fPedido.lOC != null)
                    {
                        using (TFListaPed fLista = new TFListaPed())
                        {
                            fLista.pCd_empresa = fPedido.lOC[0].Cd_empresa;
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fLista.Cfg_pedido))
                                    try
                                    {
                                        CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.ProcessarPedido(fPedido.lOC, fLista.Cfg_pedido, null, fPedido.Anexo, null);
                                        MessageBox.Show("Pedido gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                else MessageBox.Show("Obrigatório selecionar CONFIG. PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Obrigatório selecionar CONFIG. PEDIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void TFLanOrdemCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOrdemCompra);
            pFiltro.set_FormatZero();
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_3;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vCond = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vCond, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, vParam);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Descrição Moeda|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora }, vParam);
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_transportadora, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_transportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            ProcessarOC();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            ProcessarPedido();
        }

        private void gOrdemCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADA"))
                    {
                        DataGridViewRow linha = gOrdemCompra.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    {
                        DataGridViewRow linha = gOrdemCompra.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gOrdemCompra.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanOrdemCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOrdemCompra);
        }

        private void TFLanOrdemCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                ProcessarOC();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ProcessarPedido();

        }
    }
}
