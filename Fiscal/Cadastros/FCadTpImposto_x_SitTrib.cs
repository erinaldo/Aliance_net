using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;


namespace Fiscal.Cadastros
{
    public partial class TFCadTpImposto_x_SitTrib : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpImposto_x_SitTrib()
        {
            InitializeComponent();
            DTS = BS_TpImposto;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
                BS_TpImposto.AddNew();
            base.afterNovo();
            if (!cBox_tpImposto.Focus())
                cd_st.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_TpImposto.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if(this.vTP_Modo == TTpModo.tm_Edit)
                cd_st.Focus();           
            
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTpImposto_x_SitTrib.GravarTpImposto(BS_TpImposto.Current as TRegistro_CadTpImposto_x_SitTrib, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTpImposto_x_SitTrib lista = TCN_CadTpImposto_x_SitTrib.Busca(cBox_tpImposto.SelectedValue != null ? cBox_tpImposto.SelectedValue.ToString():string.Empty, 
                                                                                  cd_st.Text,
                                                                                  cd_imposto.Text,
                                                                                  null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TpImposto.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TpImposto.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadTpImposto_x_SitTrib.DeletarTpImposto(BS_TpImposto.Current as TRegistro_CadTpImposto_x_SitTrib, null);
                    BS_TpImposto.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadTpImposto_x_SitTrib_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPesquisa);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("ALIQUOTA", "AL"));
            CBox1.Add(new Utils.TDataCombo("QTDE", "QT"));
            CBox1.Add(new Utils.TDataCombo("NÃO TRIBUTADO", "NT"));
            CBox1.Add(new Utils.TDataCombo("OUTROS", "OU"));
            cBox_tpImposto.DataSource = CBox1;
            cBox_tpImposto.DisplayMember = "Display";
            cBox_tpImposto.ValueMember = "Value";
        }

        private void bb_st_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_st|Cd. Sit.|80;" +
                              "a.ds_situacao|Situação Tributaria|250;" +
                              "a.cd_imposto|Cd. Imposto|80;" +
                              "b.ds_imposto|Imposto|200";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_imposto.Text))
                vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_st, ds_situacao, cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadSitTribut(), vParam);
        }

        private void id_st_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_st|=|" + cd_st.Text;
            if (!string.IsNullOrEmpty(cd_imposto.Text))
                vColunas += ";a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_st, ds_situacao, cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadSitTribut());
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_imposto|=|" + cd_imposto.Text + "; " +
                              "||((a.st_pis = 0) or (a.st_cofins = 0))";
            if (!string.IsNullOrEmpty(cd_st.Text))
                vColunas += ";|exists|(select 1 from TB_FIS_SitTribut x " +
                            "           where x.cd_imposto = a.cd_imposto " +
                            "           and x.cd_st = '" + cd_st.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.cd_imposto|Cd. Imposto|80";
            string vParam = "||((a.st_pis = 0) or (a.st_cofins = 0))";
            if (!string.IsNullOrEmpty(cd_st.Text))
                vParam += ";|exists(select 1 from TB_FIS_SitTribut x " +
                          "         where x.cd_imposto = a.cd_imposto " +
                          "         and x.cd_st = '" + cd_st.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto(), vParam);
        }

        private void TFCadTpImposto_x_SitTrib_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPesquisa);
        }
    }
}
