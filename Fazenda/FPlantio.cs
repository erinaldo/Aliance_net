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
    public partial class TFPlantio : Form
    {
        private CamadaDados.Fazenda.Cadastros.TRegistro_Plantio rplantio;
        public CamadaDados.Fazenda.Cadastros.TRegistro_Plantio rPlantio
        {
            get
            {
                if (bsPlantio.Current != null)
                    return bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio;
                else
                    return null;
            }
            set { rplantio = value; }
        }

        public TFPlantio()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (qt_sementespormetro.Focused)
                    (bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).Qt_sementespormetro = qt_sementespormetro.Value;
                if (espacosementes.Focused)
                    (bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).Espacosemente = espacosementes.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirTalhao()
        {
            using (TFTalhoesPlantio fTalhoes = new TFTalhoesPlantio())
            {
                fTalhoes.UndProduto = sigla_unidade.Text;
                if (fTalhoes.ShowDialog() == DialogResult.OK)
                    if (fTalhoes.rTalhoes != null)
                    {
                        (bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).lTalhoesPlantio.Add(fTalhoes.rTalhoes);
                        bsPlantio.ResetCurrentItem();
                    }
            }
        }

        public void AlterarTalhao()
        {
            if(bsTalhoes.Current != null)
                using (TFTalhoesPlantio fTalhoes = new TFTalhoesPlantio())
                {
                    decimal area_plantada = (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Area_plantada;
                    decimal producao_prevista = (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Producao_prevista;
                    fTalhoes.UndProduto = sigla_unidade.Text;
                    fTalhoes.rTalhoes = bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes;
                    if (fTalhoes.ShowDialog() != DialogResult.OK)
                    {
                        (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Area_plantada = area_plantada;
                        (bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Producao_prevista = producao_prevista;
                        bsTalhoes.ResetCurrentItem();
                    }
                }
        }

        public void ExcluirTalhao()
        {
            if(bsTalhoes.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio).lTalhoesPlantioDel.Add(
                        bsTalhoes.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes);
                    bsTalhoes.RemoveCurrent();
                }
        }

        private void TFPlantio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rplantio != null)
                bsPlantio.DataSource = new CamadaDados.Fazenda.Cadastros.TList_Plantio() { rplantio };
            else
                bsPlantio.AddNew();
        }

        private void bb_cultura_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_cultura|Cultura|200;" +
                            "a.id_cultura|Id. Cultura|80;" +
                            "c.sigla_unidade|UND|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { id_cultura, ds_cultura, sigla_unidade },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Cultura(), string.Empty);
        }

        private void id_cultura_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cultura|=|" + id_cultura.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cultura, ds_cultura, sigla_unidade },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Cultura());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Safra|200;" +
                              "a.anosafra|Ano Safra|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                            new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra, ds_safra },
                                            new CamadaDados.Graos.TCD_CadSafra());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFPlantio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTalhao();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarTalhao();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTalhao();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirTalhao();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarTalhao();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirTalhao();
        }

        private void TFPlantio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
