using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FormBusca
{
    public partial class TFBuscaProduto : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public Utils.TpBusca[] vParamFixo;
        public string filtro
        { get; set; }
        public string vCond
        { get; set; }
        public bool vLista = false;
        public CamadaDados.Estoque.Cadastros.TList_CadProduto lProd
        {
            get
            {

                return null;
            }
        }
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd
        {
            get
            {
                if (bsProduto.Current != null)
                    return bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto;
                else
                    return null;
            }
        }

        public TFBuscaProduto()
        {
            InitializeComponent();
            Utils.ShapeGrid.RestoreShape(this, gProduto);
        }

        public void Produtos()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(txtBusca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + txtBusca.Text.Trim() + "') or " +
                                                      "(a.ds_produto like " + (Utils.Parametros.ST_UtilizarCoringaEsq ? "'%" : "'") + txtBusca.Text.Trim() + "%') or " +
                                                      "(a.codigo_alternativo like '%" + txtBusca.Text.Trim() + "%') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + txtBusca.Text.Trim() + "')) or " +
                                                      "(exists(select 1 from tb_est_patrimonio x " +
                                                      "           where x.CD_Patrimonio = a.cd_produto " +
                                                      "           and x.NR_Patrimonio = '" + txtBusca.Text.Trim() + "'))";
            }
            if (!string.IsNullOrEmpty(cd_marca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_marca.Text;

            }
            if (!string.IsNullOrEmpty(cd_grupo.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(tp_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCond))
            {
                string[] v = vCond.Split(new char[] { ';' });
                foreach (string s in v)
                {
                    string[] aux = s.Split(new char[] { '|' });
                    if (aux.Length != 3)
                        throw new Exception("Parametro busca incorreto.");
                    else
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = aux[0];
                        filtro[filtro.Length - 1].vOperador = aux[1];
                        filtro[filtro.Length - 1].vVL_Busca = aux[2];
                    }
                }
            }
            if (vParamFixo != null)
                if (vParamFixo.Length > 0)
                    filtro = filtro.Concat(vParamFixo).ToArray();
            System.Collections.Hashtable vParametros = new System.Collections.Hashtable();
            vParametros.Add("@CD_EMPRESA", string.IsNullOrEmpty(Cd_empresa) ? "null" : Cd_empresa);
            vParametros.Add("@CD_TABELAPRECO", string.IsNullOrEmpty(Cd_tabelapreco) ? "null" : Cd_tabelapreco);
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, Convert.ToInt16(nLinhas.Value), string.Empty, string.Empty, "a.ds_produto", vParametros);
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void VisualizarDetalhes(bool st_visualizar)
        {
            if (tlpProdutos.ColumnStyles[1].Width.Equals(0) || st_visualizar)
            {
                tlpProdutos.ColumnStyles[1].Width = 216;
                lblDetalhes.Text = "Ocultar Detalhes";
                if (bsProduto.Current != null)
                    if ((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens.Count.Equals(0))
                    {
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens =
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto_Imagens.Buscar(decimal.Zero,
                                                                                              (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
                        bsProduto.ResetCurrentItem();
                    }
            }
            else
            {
                tlpProdutos.ColumnStyles[1].Width = 0;
                lblDetalhes.Text = "Visualizar Detalhes";
            }
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca Produto|200;" +
                             "a.cd_marca|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca },
                                     new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), string.Empty);
            tempo_Tick(this, new EventArgs());
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_marca|=|" + cd_marca.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
            tempo_Tick(this, new EventArgs());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(),
                                    "isnull(a.tp_grupo, 'A')|=|'A';isnull(a.st_registro, 'A')|<>|'C'");
            tempo_Tick(this, new EventArgs());
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "isnull(a.tp_grupo, 'A')|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
            tempo_Tick(this, new EventArgs());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(),
                                string.Empty);
            tempo_Tick(this, new EventArgs());
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
            tempo_Tick(this, new EventArgs());
        }

        private void TFBuscaProduto_Load(object sender, EventArgs e)
        {
            nLinhas.Value = nLinhas.Value.Equals(decimal.Zero) ? Utils.Parametros.pubTopMax > decimal.Zero ? Utils.Parametros.pubTopMax : 15 : nLinhas.Value;
            tp_produto.Text = Properties.Settings.Default.vTP_prod;
            cd_marca.Text = Properties.Settings.Default.vMarca;
            cd_grupo.Text = Properties.Settings.Default.vCd_grupo;

            txtBusca.Text = filtro;
            tempo.Enabled = true;
            lblVisualizarCustos.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null);
            VisualizarDetalhes(Properties.Settings.Default.st_detalhes);
            
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            Produtos();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            tempo.Enabled = true;

            txtBusca.Text = txtBusca.Text.Replace("'", "");
        }

        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProduto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto());
            CamadaDados.Estoque.Cadastros.TList_CadProduto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).Sort(lComparer);
            bsProduto.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
                gProduto.Focus();
        }

        private void TFBuscaProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gProduto);
            Properties.Settings.Default.st_detalhes = tlpProdutos.ColumnStyles[1].Width > 0;
            Properties.Settings.Default.Save();
        }

        private void TFBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void gProduto_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void lblVisualizarCustos_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                using (TFCustoProduto fCusto = new TFCustoProduto())
                {
                    fCusto.pCd_empresa = Cd_empresa;
                    fCusto.pNm_empresa = Nm_empresa;
                    fCusto.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCusto.pDs_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fCusto.pUnd = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade;
                    fCusto.ShowDialog();
                }
            else
                MessageBox.Show("Necessario selecionar produto para visualizar custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblDetalhes_Click(object sender, EventArgs e)
        {
            VisualizarDetalhes(false);
        }

        private void bsProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                //Buscar Saldo Estoque
                if (!string.IsNullOrEmpty(Cd_empresa))
                {
                    object obj = new CamadaDados.Estoque.TCD_LanEstoque().BuscarSaldo_EstoqueEscalar(
                                        new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'"
                                        }
                                    }, "a.tot_saldo");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        qtd_estoque.Text = Convert.ToDecimal(obj).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                    else
                        qtd_estoque.Text = "0,000";
                }
                //Buscar Fotos Produto
                if ((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens.Count.Equals(0) &&
                    lblDetalhes.Text.Trim().ToUpper().Equals("OCULTAR DETALHES"))
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto_Imagens.Buscar(decimal.Zero,
                                                                                      (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
                    bsProduto.ResetCurrentItem();
                }
            }
        }

        private void lblAnterior_Click(object sender, EventArgs e)
        {
            bsFotos.MovePrevious();
        }

        private void lblProximo_Click(object sender, EventArgs e)
        {
            bsFotos.MoveNext();
        }

        private void BB_OK_Click(object sender, EventArgs e)
        {
          
        }
    }
}
