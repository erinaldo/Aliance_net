using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fazenda
{
    public partial class TFLanPlantio : Form
    {
        public TFLanPlantio()
        {
            InitializeComponent();
        }

        public void LimparFiltros()
        {
            id_plantio.Clear();
            cd_fazenda.Clear();
            id_area.Clear();
            id_talhao.Clear();
            id_cultura.Clear();
            anosafra.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            rbIniPlantio.Checked = true;
        }

        private void afterNovo()
        {
            using (TFPlantio fPlantio = new TFPlantio())
            {
                if(fPlantio.ShowDialog() == DialogResult.OK)
                    if(fPlantio.rPlantio != null)
                        try
                        {
                            CamadaNegocio.Fazenda.Cadastros.TCN_Plantio.Gravar(fPlantio.rPlantio, null);
                            MessageBox.Show("Plantio cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_plantio.Text = fPlantio.rPlantio.Id_plantiostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsPlantio.Current !=null)
                using (TFPlantio fPlantio = new TFPlantio())
                {
                    fPlantio.rPlantio = bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio;
                    if(fPlantio.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Fazenda.Cadastros.TCN_Plantio.Gravar(fPlantio.rPlantio, null);
                            MessageBox.Show("Plantio alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_plantio.Text = fPlantio.rPlantio.Id_plantiostr;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsPlantio.Current != null)
                if(MessageBox.Show("Confirma exclusão do plantio selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Fazenda.Cadastros.TCN_Plantio.Excluir(bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio, null);
                        MessageBox.Show("Plantio excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void afterBusca()
        {
            bsPlantio.DataSource = CamadaNegocio.Fazenda.Cadastros.TCN_Plantio.Buscar(id_plantio.Text,
                                                                                      string.Empty,
                                                                                      id_cultura.Text,
                                                                                      anosafra.Text,
                                                                                      cd_fazenda.Text,
                                                                                      id_area.Text,
                                                                                      id_talhao.Text,
                                                                                      rbIniPlantio.Checked ? "I" : "F",
                                                                                      dt_ini.Text,
                                                                                      dt_fin.Text,
                                                                                      null);
            bsPlantio_PositionChanged(this, new EventArgs());
        }

        private void TFLanPlantio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Fazenda|200;" +
                              "a.cd_fazenda|Cd. Fazenda|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fazenda },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Fazenda(), string.Empty);
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fazenda },
                                                new CamadaDados.Fazenda.Cadastros.TCD_Fazenda());
        }

        private void bb_area_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_area|Area|200;" +
                              "a.id_area|Id. Area|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_area },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Area(), string.Empty);
        }

        private void id_area_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_area|=|" + id_area.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_area },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Area());
        }

        private void bb_talhao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_talhao|Talhão|200;" +
                              "a.id_talhao|Id. Talhão|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_talhao },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Talhoes(), string.Empty);
        }

        private void id_talhao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_talhao|=|" + id_talhao.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_talhao },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Talhoes());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_safra|Safra|200;" +
                            "a.anosafra|Ano Safra|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { anosafra },
                                            new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra },
                                                new CamadaDados.Graos.TCD_CadSafra());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_cultura_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cultura|Cultura|200;" +
                              "a.id_cultura|Id. Cultura|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_cultura },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Cultura(), string.Empty);
        }

        private void id_cultura_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cultura|=|" + id_cultura.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cultura },
                                                new CamadaDados.Fazenda.Cadastros.TCD_Cultura());
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

        private void TFLanPlantio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bsPlantio_PositionChanged(object sender, EventArgs e)
        {
            if (bsPlantio.Current != null)
            {
                (bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).lTalhoesPlantio =
                    CamadaNegocio.Fazenda.Cadastros.TCN_Plantio_X_Talhoes.Buscar((bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).Id_plantiostr,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 null);
                bsPlantio.ResetCurrentItem();
            }
        }

        private void TFLanPlantio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
