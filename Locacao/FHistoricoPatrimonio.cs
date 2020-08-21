using System;
using System.Data;
using System.Windows.Forms;
using FormBusca;
using System.Linq;

namespace Locacao
{
    public partial class TFHistoricoPatrimonio : Form
    {
        private bool Altera_Relatorio = false;
        public TFHistoricoPatrimonio()
        {
            InitializeComponent();
        }

        public void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            
            if (!string.IsNullOrEmpty(txtBusca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_patrimonio like '%" + txtBusca.Text.Trim() + "') or " +
                                                      "(a.nr_patrimonio = '" + txtBusca.Text.Trim() + "') or " +
                                                      "(b.ds_produto like " + (Utils.Parametros.ST_UtilizarCoringaEsq ? "'%" : "'") + txtBusca.Text.Trim() + "%') or " +
                                                      "(b.codigo_alternativo like '%" + txtBusca.Text.Trim() + "%') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_patrimonio " +
                                                      "           and x.cd_codbarra = '" + txtBusca.Text.Trim() + "'))";
            }
            if (!string.IsNullOrEmpty(cd_marca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_marca.Text;

            }
            if (!string.IsNullOrEmpty(cd_grupo.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(tp_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.tp_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
            }
            bsPatrimonio.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().CalcularROI(filtro);
        }

        private void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.Nome_Relatorio = Name;
                Rel.NM_Classe = Name;
                Rel.Modulo = Tag.ToString().Substring(0, 3);
                Rel.DTS_Relatorio = bsPatrimonio;

                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO HISTÓRICO PATRIMÔNIO";

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
                                        "RELATORIO HISTÓRICO PATRIMÔNIO",
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
                                        "RELATORIO HISTÓRICO PATRIMÔNIO",
                                        fImp.pDs_mensagem);
            }
        }

        private void TFHistoricoPatrimonio_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_marca|=|" + cd_marca.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca Produto|200;" +
                            "a.cd_marca|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca },
                                     new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "isnull(a.tp_grupo, 'A')|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(),
                                    "isnull(a.tp_grupo, 'A')|=|'A';isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(),
                                string.Empty);
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    if (e.ColumnIndex == 0)
            //        if (string.IsNullOrEmpty((bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio))
            //        {
            //            gProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //            gProdutos.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            //        }
            //        else
            //        {
            //            gProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            //            gProdutos.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
            //        }
            //}
        }

        private void TFHistoricoPatrimonio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void dtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpDetalhes))
                if (bsPatrimonio.Current != null)
                {
                    bsItens.DataSource = new CamadaDados.Locacao.TCD_ItensLocacao().SelectHistPatrimonio(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsPatrimonio.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio).CD_Patrimonio.Trim() + "'"

                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "loc.Vl_faturado",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(loc.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, 0, string.Empty);
                    totRec.Text = (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).Sum(p => p.Tot_Faturado).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    bsOS.DataSource =
                        new CamadaDados.Servicos.TCD_LanServico().Select(
                            new Utils.TpBusca[]
                            {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_CfgLocacao x " +
                                            "where a.cd_empresa = x.cd_empresa) "
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_produtoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsPatrimonio.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio).CD_Patrimonio.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.ST_OS, 'AB')",
                                vOperador = "<>",
                                vVL_Busca = "'CA'"
                            }
                            }, 0, string.Empty, string.Empty);
                    totDespesas.Text = (bsOS.List as CamadaDados.Servicos.TList_LanServico).Sum(p => p.Vl_subtotalLiq).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                }
                else
                {
                    bsOS.Clear();
                    totDespesas.Text = string.Empty;
                    totRec.Text = string.Empty;
                }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbImprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bbAltPatrimonio_Click(object sender, EventArgs e)
        {
            if (bsPatrimonio.Current != null)
                using (Proc_Commoditties.TFPatrimonio fPatrimonio = new Proc_Commoditties.TFPatrimonio())
                {
                    fPatrimonio.rPatrimonio = bsPatrimonio.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio;
                    if(fPatrimonio.ShowDialog() == DialogResult.OK)
                        if(fPatrimonio.rPatrimonio != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadPatrimonio.Gravar(fPatrimonio.rPatrimonio, null);
                                MessageBox.Show("Patrimonio alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtBusca.Text = fPatrimonio.rPatrimonio.CD_Patrimonio;
                                afterBusca();
                            }
                            catch(Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar patrimonio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
