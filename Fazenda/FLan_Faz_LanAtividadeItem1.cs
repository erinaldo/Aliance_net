using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fazenda.Cadastros;
using CamadaDados.Estoque.Cadastros;

namespace Fazenda
{
    public partial class TFLan_Faz_LanAtividadeItem : Form
    {
        public bool St_alterar
        { get; set; }
        public CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade rAtiv
        {
            get
            {
                if (bs_atividade.Current != null)
                    return bs_atividade.Current as CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade;
                else
                    return null;
            }
            set
            {
                bs_atividade.Add(value);
            }
        }

        public TFLan_Faz_LanAtividadeItem()
        {
            InitializeComponent();
            this.St_alterar = false;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Atividade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Atividade|Atividade|250;a.ID_Atividade|Cód. Atividade|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Atividade, DS_Atividade }, new TCD_Atividade(), string.Empty);
        }

        private void BB_Item_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Ano Safra|200;" +
                              "a.anosafra|Cd. Safra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { AnoSafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra(), string.Empty);
        }

        private void BB_Equipamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Equipamento|Descrição Equipamento|250;a.ID_Equip|Cód. Equipamento|100;a.St_tipo|Tipo. Equipamento|10";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Equip, DS_Equipamento }, new TCD_Equipamento(), "a.st_tipo|=|'0'");
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Item, Ds_Item }, string.Empty);
            if (linha != null)
                sigla_unidade.Text = linha["sigla_unidade"].ToString();
        }

        private void TFLan_Faz_LanAtividadeItem_Load(object sender, EventArgs e)
        {
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.HabilitarControls(true, Utils.TTpModo.tm_Insert);
            pDados.set_FormatZero();
            if (this.St_alterar)
            {
                ID_Atividade.Enabled = false;
                BB_Atividade.Enabled = false;
                CD_Propriedade.Enabled = false;
                BB_Propriedade.Enabled = false;
                CD_talhao.Enabled = false;
                BB_talhao.Enabled = false;
                AnoSafra.Enabled = false;
                CD_Plantio.Enabled = false;
                BB_Item.Enabled = false;
                dt_ini.Enabled = false;
                dt_fim.Enabled = false;
                bsItem.MoveLast();
            }
            else
            {
                bs_atividade.AddNew();
                bsItem.AddNew();
                ID_Atividade.Focus();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLan_Faz_LanAtividadeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void ID_Atividade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_atividade|=|" + ID_Atividade.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { ID_Atividade, DS_Atividade },
                                    new TCD_Atividade());
        }

        private void BB_Propriedade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_fazenda|Propriedade|200;" +
                              "a.cd_fazenda|Cd. Propriedade|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Propriedade, DS_Propriedade },
                                    new TCD_Fazenda(), string.Empty);
        }

        private void CD_Propriedade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|" + CD_Propriedade.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Propriedade, DS_Propriedade },
                                    new TCD_Fazenda());
        }

        private void BB_talhao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_talhao|Nome Talhão|200;"+
                              "a.cd_talhao|Cd. Talhão|80";
            string vParam = "a.cd_fazenda|=|" + CD_Propriedade.Text;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_talhao, DS_talhao },
                                    new TCD_Talhoes(), vParam);
        }

        private void CD_talhao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_talhao|=|" + CD_talhao.Text + ";" +
                            "a.cd_fazenda|=|" + CD_Propriedade.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_talhao, DS_talhao },
                                    new TCD_Talhoes());
        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + AnoSafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { AnoSafra, ds_safra },
                                    new CamadaDados.Graos.TCD_CadSafra());
        }

        private void CD_Item_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(string.Empty, new Componentes.EditDefault[] { CD_Item, Ds_Item },
                                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null)
                sigla_unidade.Text = linha["sigla_Unidade"].ToString();
        }

        private void CD_Equip_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_equip|=|" + CD_Equip.Text+";a.st_tipo|=|'0'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Equip, DS_Equipamento },
                                    new TCD_Equipamento());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_equipamento|Descrição Implemento|250;a.ID_Equip|Cód. Implemento|100;a.St_tipo|Tipo. Implemento|10";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_implem, ds_implem }, new TCD_Equipamento(), "a.st_tipo|=|'1'");
        }

        private void cd_implem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_equip|=|" + CD_Equip.Text + ";a.st_tipo|=|'1'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_implem, ds_implem },
                                    new TCD_Equipamento());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AnoSafra.Text != "")
            {
                string vColunas = "a.cd_produto|Cód. Plantio|100;g.ds_produto|Plantio|200;f.ds_safra|Ano Safra|100;a.anosafra|Cod. Ano Safra|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Plantio, DS_plantio, AnoSafra }, new TCD_Plantio(), "a.anosafra|=|" + AnoSafra.Text);
            }
            else
            {
                MessageBox.Show("Atenção é necessário informar o Ano Safra!");
                AnoSafra.Focus();
            }
        }

        private void CD_Plantio_Leave(object sender, EventArgs e)
        {
            if (AnoSafra.Text != "")
            {
                string vParam = "a.cd_produto|=|" + CD_Plantio.Text;
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Plantio, DS_plantio },
                                        new TCD_Plantio());
            }else{
                MessageBox.Show("Atenção é necessário informar o Ano Safra!");
                AnoSafra.Focus();
            }
        }

        
    }
}
