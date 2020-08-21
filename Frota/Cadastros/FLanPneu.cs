using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;
using FormBusca;

namespace Frota.Cadastros
{
    public partial class TFLanPneu : Form
    {
        public TFLanPneu()
        {
            InitializeComponent();
        }

        private void LimpaFiltros()
        {
            id_pneu.Clear();
            id_modelo.Clear();
            id_marca.Clear();
            cd_fornecedor.Clear();
            cd_empresa.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void TFLanPneu_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPneus);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void afterNovo()
        {
            using (TFPneu fPneu = new TFPneu())
            {
                if (fPneu.ShowDialog() == DialogResult.OK)
                    if (fPneu.rPneu != null)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_LanPneu.Gravar(fPneu.rPneu, null);
                            MessageBox.Show("Pneu gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimpaFiltros();
                            id_pneu.Text = fPneu.rPneu.Id_pneustr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterAltera()
        {
            if (bsPneus.Current != null)
            {
                using (TFPneu fPneu = new TFPneu())
                {
                    fPneu.rPneu = bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu;
                    if (fPneu.ShowDialog() == DialogResult.OK)
                        if (fPneu.rPneu != null)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_LanPneu.Gravar(fPneu.rPneu, null);
                                bsPneus.ResetCurrentItem();
                                MessageBox.Show("Pneu alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    this.LimpaFiltros();
                    id_pneu.Text = fPneu.rPneu.Id_pneustr;
                    this.afterBusca();
                   
                }
            }
        }

        private void afterBusca()
        {
            bsPneus.DataSource = TCN_LanPneu.Buscar(cd_empresa.Text,
                                                    id_pneu.Text,
                                                    id_modelo.Text,
                                                    id_marca.Text,
                                                    string.Empty,
                                                    dt_ini.Text,
                                                    dt_fin.Text,
                                                    string.Empty,
                                                    null);
            bsPneus_PositionChanged(this, new EventArgs());
            bsPneus.ResetCurrentItem();
        }

        private void id_modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_modelo|=|'" + id_modelo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_modelo },
                                    new CamadaDados.Frota.Cadastros.TCD_CadModeloPneu());
        }

        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_modelo|Modelo|200;" +
                              "a.id_modelo|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { id_modelo },
                new CamadaDados.Frota.Cadastros.TCD_CadModeloPneu(),
               string.Empty);
        }

        private void id_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_marca|=|'" + id_marca.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_marca },
                                    new CamadaDados.Frota.Cadastros.TCD_CadMarcaPneu());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_marca|Marca|200;" +
                              "a.id_marca|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { id_marca },
                new CamadaDados.Frota.Cadastros.TCD_CadMarcaPneu(),
               string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Fornecedor|200;" +
                              "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fornecedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               string.Empty);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { cd_empresa }
                         , new CamadaDados.Diversos.TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bsPneus_PositionChanged(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).lPneu =
                    TCN_FotosPneu.Buscar((bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).Cd_empresa,
                                         (bsPneus.Current as CamadaDados.Frota.Cadastros.TRegistro_LanPneu).Id_pneustr,
                                         string.Empty,
                                          null);

                bsPneus.ResetCurrentItem();
                                                                        
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }        

        private void gPneus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("INATIVO"))
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gPneus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void TFLanPneu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPneus);
        }

        private void gPneus_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPneus.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPneus.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_LanPneu());
            CamadaDados.Frota.Cadastros.TList_LanPneu lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneus.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPneus.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneus.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPneus.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPneus.List as CamadaDados.Frota.Cadastros.TList_LanPneu).Sort(lComparer);
            bsPneus.ResetBindings(false);
            gPneus.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void ptbImagem_DoubleClick(object sender, EventArgs e)
        {
            if (bsFotoPneu.Current != null)
            {
                if ((bsFotoPneu.Current as CamadaDados.Frota.Cadastros.TRegistro_FotosPneu).Imagem != null)
                {
                    //Criar Form
                    Form fImagem = new Form();
                    fImagem.Size = new Size(1040, 720);
                    fImagem.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    fImagem.ShowInTaskbar = false;
                    fImagem.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                    fImagem.MinimizeBox = false;
                    fImagem.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fImagem.Text = "Visualizador de IMAGENS -  Aliance.Net";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    //Criar PictureBox
                    PictureBox img = new PictureBox();
                    this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
                    bindingNavigator2.BindingSource = this.bsFotoPneu;
                    fImagem.Controls.Add(panel);
                    panel.Controls.Add(img);
                    panel.Controls.Add(this.bindingNavigator2);
                    img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsFotoPneu, "imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    fImagem.ShowDialog();
                }
            }
        }
    }
}
