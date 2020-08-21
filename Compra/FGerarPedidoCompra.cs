using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CamadaDados.Diversos;
using FormBusca;

namespace Compra
{
    public partial class TFGerarPedidoCompra : Form
    {
        public byte[] Anexo { get; set; } = null;
        public List<CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra> lOC
        {
            get
            {
                if (bsOrdemCompra.Current != null)
                    return (bsOrdemCompra.DataSource as CamadaDados.Compra.Lancamento.TList_OrdemCompra).FindAll(p => p.St_gerarpedido);
                else
                    return null;
            }
        }

        public TFGerarPedidoCompra()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsOrdemCompra.Current != null)
                if ((bsOrdemCompra.DataSource as CamadaDados.Compra.Lancamento.TList_OrdemCompra).Exists(p => p.St_gerarpedido))
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Obrigatório selecionar uma Ordem para gerar o pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Busque uma Ordem para gravar o pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void afterBusca()
        {
            if(cd_empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (cd_fornecedor.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar fornecedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_fornecedor.Focus();
                return;
            }
            if (cd_condpgto.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar condição pagamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_condpgto.Focus();
                return;
            }
            if (st_utilizarmoedaoc.Checked && cd_moeda.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar moeda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_moeda.Focus();
                return;
            }
            bsOrdemCompra.DataSource = CamadaNegocio.Compra.Lancamento.TCN_OrdemCompra.Buscar(string.Empty,
                                                                                              cd_empresa.Text,
                                                                                              string.Empty,
                                                                                              cd_fornecedor.Text,
                                                                                              cd_condpgto.Text,
                                                                                              cd_moeda.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              "'A'",
                                                                                              string.Empty,
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
        }

        private void HabilitarVlCotacao()
        {
            if (bsOrdemCompra.Current != null)
                if ((bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_gerarpedido &&
                    ((bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_utilizarmoedaoc.Trim() != "S") &&
                    ((bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).Cd_moeda.Trim() !=
                    (bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).Cd_moedacompra.Trim()))
                {
                    vl_cotacao.Enabled = true;
                    vl_cotacao.Focus();
                }
                else
                {
                    vl_cotacao.Enabled = false;
                    vl_cotacao.Value = vl_cotacao.Minimum;
                }
        }

        private void TFGerarPedidoCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOrdemCompra);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
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
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Compra.TCD_CFGCompra().BuscarEscalar(
                    new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                    }
                }, "a.st_utilizarmoedaoc");
                if (obj != null)
                    st_utilizarmoedaoc.Checked = obj.ToString().Trim().ToUpper().Equals("S");
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Compra.TCD_CFGCompra().BuscarEscalar(
                    new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                    }
                }, "a.st_utilizarmoedaoc");
                if (obj != null)
                    st_utilizarmoedaoc.Checked = obj.ToString().Trim().ToUpper().Equals("S");
            }
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

        private void bb_processar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFGerarPedidoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gOrdemCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_gerarpedido =
                    !(bsOrdemCompra.Current as CamadaDados.Compra.Lancamento.TRegistro_OrdemCompra).St_gerarpedido;
                bsOrdemCompra.ResetCurrentItem();
                HabilitarVlCotacao();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bsOrdemCompra_PositionChanged(object sender, EventArgs e)
        {
            HabilitarVlCotacao();   
        }

        private void TFGerarPedidoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOrdemCompra);
        }

        private void bbAnexar_Click(object sender, EventArgs e)
        {
            if(Anexo != null)
            {
                if(MessageBox.Show("Excluir Anexo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Anexo = null;
                    bbAnexar.Text = "Anexar Documento Pedido";
                }
            }
            else
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    if (file.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(file.FileName))
                        {
                            Anexo = System.IO.File.ReadAllBytes(file.FileName);
                            bbAnexar.Text = "Excluir Anexo Pedido";
                        }
                }
        }
    }
}
