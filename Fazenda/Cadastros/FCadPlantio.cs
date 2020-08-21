using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Fazenda.Cadastros;
using CamadaNegocio.Fazenda.Cadastros;
using Utils;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Graos;

namespace Fazenda.Cadastros
{
    public partial class TFCadPlantio : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPlantio()
        {
            InitializeComponent();
            DTS = BS_CadPlantio;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadPlantio.Grava_CadPlantio(BS_CadPlantio.Current as TRegistro_CadPlantio);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadPlantio lista = TCN_CadPlantio.Busca( (Id_Plantio.Text.Trim()!= "")? Convert.ToDecimal(Id_Plantio.Text):0,
                                                           (CD_Fazenda.Text.Trim() != "") ? Convert.ToDecimal(CD_Fazenda.Text):0,
                                                           (CD_Area.Text.Trim()!= "")? Convert.ToDecimal(CD_Area.Text):0,
                                                           (CD_Talhao.Text.Trim() != "") ? Convert.ToDecimal(CD_Talhao.Text) : 0,
                                                            CD_Variedade.Text.Trim(),
                                                            CD_Produto.Text.Trim(),
                                                            AnoSafra.Text.Trim());
       
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadPlantio.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadPlantio.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadPlantio.AddNew();
                base.afterNovo();
                if (!Id_Plantio.Focus())
                    CD_Fazenda.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadPlantio.RemoveCurrent();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!Id_Plantio.Focus())
                    CD_Fazenda.Focus();
            }

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadPlantio.Deleta_CadPlantio(BS_CadPlantio.Current as TRegistro_CadPlantio);
                    BS_CadPlantio.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        private void BB_Fazenda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_fazenda|Nome Fazenda|350;a.CD_Fazenda|Codigo Fazenda|100"
                , new Componentes.EditDefault[] { CD_Fazenda, NM_Fazenda }, new TCD_Fazenda(), null);
        }

        private void CD_Fazenda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_fazenda|=|'" + CD_Fazenda.Text + "'"
                    , new Componentes.EditDefault[] { CD_Fazenda, NM_Fazenda }, new TCD_Fazenda());
        }

        private void BB_Area_Click(object sender, EventArgs e)
        {
            string VParam;
            if (CD_Fazenda.Text != "")
                VParam = "a.cd_fazenda |=|" + CD_Fazenda.Text.ToString();
            else
                VParam = null;

            UtilPesquisa.BTN_BUSCA("a.nm_area|Nome Área|350;a.cd_area|Codigo Área|70"
                , new Componentes.EditDefault[] { CD_Area, NM_Area }, new TCD_Area(), VParam);
        }

        private void CD_Area_Leave(object sender, EventArgs e)
        {
            if (CD_Fazenda.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_area|=|" + CD_Area.Text + ";a.cd_fazenda|=|" + CD_Fazenda.Text.ToString()
                        , new Componentes.EditDefault[] { CD_Area, NM_Area }, new TCD_Area());

            }
        }
        private void BB_Talhao_Click(object sender, EventArgs e)
        {
            string vParam;
            string vColunas = "a.nm_talhao|Nome Talhão|350;" +
                              "a.cd_talhao|Código Talhão|70";
            if (CD_Fazenda.Text != "")
                vParam = "a.cd_fazenda |=| " + CD_Fazenda.Text.ToString();
            else
                vParam = null;

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Talhao, NM_Talhao }, new TCD_Talhoes(), vParam);
        }

        private void CD_Talhao_Leave(object sender, EventArgs e)
        {
            if (CD_Fazenda.Text != "")
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_talhao|=|" + CD_Talhao.Text + ";a.cd_fazenda|=|" + CD_Fazenda.Text
                        , new Componentes.EditDefault[] { CD_Talhao, NM_Talhao }, new TCD_Talhoes());
            }
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto },"");
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = CD_Produto.NM_CampoBusca + "|=|'" + CD_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                    new TCD_CadProduto());
        }

        private void BB_Variedade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Variedade|Descrição Variedade|350;" +
                              "CD_Variedade|Cód. Variedade|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Variedade, DS_Variedade},
                                    new TCD_CadVariedades(), "");
        }

        private void CD_Variedade_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Variedade|=|'" + CD_Variedade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Variedade, DS_Variedade},
                                    new TCD_CadVariedades());
        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Safra|Descrição Safra|350;" +
                              "AnoSafra|Ano Safra|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { AnoSafra, DS_Safra},
                                    new TCD_CadSafra(), "");
        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.AnoSafra|=|'" + AnoSafra.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { AnoSafra, DS_Safra},
                                    new TCD_CadSafra());
        }

        private void TFCadPlantio_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("textchang");
        }

        private void TFCadPlantio_Load(object sender, EventArgs e)
        {
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        
    }
}
