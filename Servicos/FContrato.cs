using System;
using System.Data;
using System.Windows.Forms;
using FormBusca;

namespace Servicos
{
    public partial class TFContrato : Form
    {
        private CamadaDados.Servicos.TRegistro_Contrato rcontrato;
        public CamadaDados.Servicos.TRegistro_Contrato rContrato
        {
            get
            {
                if (bsContrato.Current != null)
                    return bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato;
                else
                    return null;
            }
            set
            {
                rcontrato = value;
            }
        }

        public TFContrato()
        {
            InitializeComponent();
        }

        private void Busca_Endereco_Clifor()
        {
            if (!string.IsNullOrEmpty(cd_contratante.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_contratante.Text,
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
                                                                              string.Empty,
                                                                              0,
                                                                              null);

                if (List_Endereco.Count == 1)
                {
                    if (string.IsNullOrEmpty(cd_endcontratante.Text))
                    {
                        cd_endcontratante.Text = List_Endereco[0].Cd_endereco.Trim();
                        ds_endcontratante.Text = List_Endereco[0].Ds_endereco.Trim();
                    }
                }
            }
        }

        private void Alterar()
        {
            if (this.rcontrato != null)
            {
                bsContrato.DataSource = new CamadaDados.Servicos.TList_Contrato() { this.rcontrato };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                cd_vendedor.Focus();
            }
            else
            {
                bsContrato.AddNew();
                CD_Empresa.Focus();
                //Buscar vendedor do login
                this.BuscarVendedor();
            }
        }

        private void BuscarVendedor()
        {
            CamadaDados.Financeiro.Cadastros.TList_CadClifor lVend =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.BuscaVendedor(string.Empty,
                                                                               Utils.Parametros.pubLogin,
                                                                               null);
            if (lVend.Count > 0)
            {
                cd_vendedor.Text = lVend[0].Cd_clifor;
                nm_vendedor.Text = lVend[0].Nm_clifor;
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            if (bsContrato.Current != null)
            {
                using (TFItensContrato fItem = new TFItensContrato())
                {
                    if(fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rItem != null)
                        {
                            if ((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItens.Exists(p => p.Cd_produto.Trim().Equals(fItem.rItem.Cd_produto.Trim())))
                            {
                                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItens.Find(p => p.Cd_produto.Trim().Equals(fItem.rItem.Cd_produto.Trim())).Quantidade = fItem.rItem.Quantidade;
                                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItens.Find(p => p.Cd_produto.Trim().Equals(fItem.rItem.Cd_produto.Trim())).Vl_unitario = fItem.rItem.Vl_unitario;
                            }
                            else
                                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItens.Add(fItem.rItem);
                            bsContrato.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Não existe contrato para inserir item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarItem()
        {
            if (bsItensContrato.Current != null)
            {
                using (TFItensContrato fItem = new TFItensContrato())
                {
                    decimal quantidade = (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Quantidade;
                    decimal vl_unitario = (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Vl_unitario;
                    fItem.rItem = bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Quantidade = quantidade;
                        (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Vl_unitario = vl_unitario;
                        bsContrato.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItem()
        {
            if (bsItensContrato.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItensDel.Add(
                        bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens);
                    bsItensContrato.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFContrato_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensContrato);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            this.Alterar();
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_contratante_Click(object sender, EventArgs e)
        {
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(cd_vendedor.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_vendedor.Text.Trim() + "'"
                                        }
                                    }, "1");
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')";

            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_contratante, nm_contratante }, vParam);
            this.Busca_Endereco_Clifor();
        }

        private void cd_contratante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'";
            object obj_regvenda = null;
            if (!string.IsNullOrEmpty(cd_vendedor.Text))
                obj_regvenda = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_vendedor.Text.Trim() + "'"
                                        }
                                    }, "1");
            if (obj_regvenda == null ? false : obj_regvenda.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_regiaovenda x " +
                          "         where x.id_regiao = a.id_regiao " +
                          "         and x.cd_vendedor = '" + cd_vendedor.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contratante, nm_contratante }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
        }

        private void bb_endcontratante_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                       , new Componentes.EditDefault[] { cd_endcontratante, ds_endcontratante }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "'");
        }

        private void cd_endcontratante_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_endcontratante.Text + "';a.cd_clifor|=|'" + cd_contratante.Text + "'"
                                                    , new Componentes.EditDefault[] { cd_endcontratante, ds_endcontratante }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensContrato);
        }

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|CFG. Pedido|80";
            string vParam = "a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(),
                                            vParam);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "';" +
                            "a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                           new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|60";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_config },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco(), vParam);
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_contager = a.cd_contager and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_config },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco());
        }

        private void bb_condpgtocarne_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|150;" +
                              "a.cd_condpgto|Código|60;" +
                              "a.qt_parcelas|Nº Parcelas|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgtocarne, ds_condpgtocarne },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), "a.qt_parcelas|>|1");
        }

        private void cd_condpgtocarne_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgtocarne.Text.Trim() + "';" +
                            "a.qt_parcelas|>|1";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgtocarne, ds_condpgtocarne },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }
    }
}
