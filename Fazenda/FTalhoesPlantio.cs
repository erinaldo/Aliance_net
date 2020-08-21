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
    public partial class TFTalhoesPlantio : Form
    {
        private CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes rtalhoes;
        public CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes rTalhoes
        {
            get
            {
                if (bsTalhoesPlantio.Current != null)
                    return bsTalhoesPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes;
                else
                    return null;
            }
            set { rtalhoes = value; }
        }
        public string UndProduto
        { get; set; }

        public TFTalhoesPlantio()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (area_plantada.Focused)
                    (bsTalhoesPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Area_plantada = area_plantada.Value;
                if (producao_prevista.Focused)
                    (bsTalhoesPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Producao_prevista = producao_prevista.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFTalhoesPlantio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            undproduto.Text = UndProduto;
            if (rtalhoes != null)
            {
                bsTalhoesPlantio.DataSource = new CamadaDados.Fazenda.Cadastros.TList_Plantio_X_Talhoes() { rtalhoes };
                cd_fazenda.Enabled = false;
                bb_fazenda.Enabled = false;
                id_area.Enabled = false;
                bb_area.Enabled = false;
                id_talhao.Enabled = false;
                bb_talhao.Enabled = false;
                area_plantada.Focus();
            }
            else
                bsTalhoesPlantio.AddNew();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFTalhoesPlantio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_fazenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Fazenda|150;" +
                              "a.cd_fazenda|Cd. Fazenda|80;" +
                              "c.Sigla_Unidade|UND|80";
            string vParam = "isnull(b.st_registro, 'A')|<>|'C'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                    new CamadaDados.Fazenda.Cadastros.TCD_Fazenda(), vParam);
            if ((linha != null) && (bsTalhoesPlantio.Current != null))
            {
                (bsTalhoesPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsTalhoesPlantio.ResetCurrentItem();
            }
        }

        private void cd_fazenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "isnull(b.st_registro, 'A')|<>|'C'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fazenda, nm_fazenda },
                                                                new CamadaDados.Fazenda.Cadastros.TCD_Fazenda());
            if ((linha != null) && (bsTalhoesPlantio.Current != null))
            {
                (bsTalhoesPlantio.Current as CamadaDados.Fazenda.Cadastros.TRegistro_Plantio_X_Talhoes).Sigla_unidade = linha["sigla_unidade"].ToString();
                bsTalhoesPlantio.ResetCurrentItem();
            }
        }

        private void bb_area_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_area|Area|200;" +
                              "a.id_area|Id. Area|80";
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_area, ds_area },
                                                new CamadaDados.Fazenda.Cadastros.TCD_Area(), vParam);
        }

        private void id_area_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_area|=|" + id_area.Text + ";" +
                            "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_area, ds_area },
                                                new CamadaDados.Fazenda.Cadastros.TCD_Area());
        }

        private void bb_talhao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_talhao|Talhão|200;" +
                              "a.id_talhao|Id. Talhão|80;" +
                              "a.area_talhao|Area Talhão|80";
            string vParam = "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "a.id_area|=|" + id_area.Text;
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_talhao, ds_talhao },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Talhoes(), vParam);
            if (linha != null)
                area_talhao.Value = decimal.Parse(linha["area_talhao"].ToString());
        }

        private void id_talhao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_talhao|=|" + id_talhao.Text + ";" +
                            "a.cd_fazenda|=|'" + cd_fazenda.Text.Trim() + "';" +
                            "a.id_area|=|" + id_area.Text;
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_talhao, ds_talhao },
                                            new CamadaDados.Fazenda.Cadastros.TCD_Talhoes());
            if (linha != null)
                area_talhao.Value = decimal.Parse(linha["area_talhao"].ToString());
        }
    }
}
