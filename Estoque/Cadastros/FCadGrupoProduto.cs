using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;
using FormBusca;
using System.Collections;

namespace Estoque.Cadastros
{
    public partial class TFCadGrupoProduto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadGrupoProduto()
        {
            InitializeComponent(); 
            DTS = BS_GrupoProduto; 
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadGrupoProduto.Grava_CadGrupoProduto(BS_GrupoProduto.Current as TRegistro_CadGrupoProduto, null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadGrupoProduto lista = TCN_CadGrupoProduto.Busca(string.Empty, DS_Grupo.Text.Trim(),CD_Grupo_Pai.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_GrupoProduto.DataSource = lista;

                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_GrupoProduto.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_GrupoProduto.Clear();
                BS_GrupoProduto.AddNew();
                base.afterNovo();
                Tp_Grupo.Focus();
                qt_vl_bi.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_GrupoProduto.RemoveCurrent();
        }
     
        public override void afterAltera()
        {
            base.afterAltera();
            Tp_Grupo.Enabled = (BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).Tp_Grupo.Trim().ToUpper().Equals("A");
            CD_Grupo_Pai.Enabled = (BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).CD_Grupo_Pai.Trim().Equals(string.Empty) &&
                                    ((BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).Nivel > 1);
            BB_Grupo.Enabled = (BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).CD_Grupo_Pai.Trim().Equals(string.Empty) &&
                                ((BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).Nivel > 1);
            if (vTP_Modo == TTpModo.tm_Edit)
                if (!Tp_Grupo.Focus())
                    if (!CD_Grupo_Pai.Focus())
                        DS_Grupo.Focus();
        }
      
        public override void excluirRegistro()
        {
            if (gCadastro.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            TCN_CadGrupoProduto.Deleta_CadGrupoProduto(BS_GrupoProduto.Current as TRegistro_CadGrupoProduto, null);
                            BS_GrupoProduto.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Não foi possivel excluir pois existe uma dependencia!","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }
       
        private void BB_Grupo_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("A.DS_Grupo|Desc. Grupo Pai|350;A.CD_grupo|Cód. Grupo Pai|80"
                    , new Componentes.EditDefault[] { CD_Grupo_Pai, DS_Grupo_Pai }, new TCD_CadGrupoProduto(), "a.tp_grupo|=|'S'");
        }

        private void CD_Grupo_Pai_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Grupo|=|'" + CD_Grupo_Pai.Text + "';A.TP_GRUPO|=|'S'"
            , new Componentes.EditDefault[] { CD_Grupo_Pai, DS_Grupo_Pai }, new TCD_CadGrupoProduto());
        }

        private void TFCadGrupoProduto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("A - ANALÍTICO", "A"));
            CBox1.Add(new Utils.TDataCombo("S - SINTÉTICO", "S"));
            Tp_Grupo.DataSource = CBox1;
            Tp_Grupo.DisplayMember = "Display";
            Tp_Grupo.ValueMember = "Value";
            Tp_Grupo.SelectedValue = "";

            ArrayList qt_vl_bial = new ArrayList();
            qt_vl_bial.Add(new Utils.TDataCombo("Q - Quantidade", "Q"));
            qt_vl_bial.Add(new Utils.TDataCombo("V - Valor", "V"));
            qt_vl_bi.DataSource = qt_vl_bial;
            qt_vl_bi.DisplayMember = "Display";
            qt_vl_bi.ValueMember = "Value";
            qt_vl_bi.SelectedValue = "";

        }

        private void CD_Grupo_Pai_EnabledChanged(object sender, EventArgs e)
        {
            BB_Grupo.Enabled = CD_Grupo_Pai.Enabled;
        }

        private void Tp_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tp_Grupo.SelectedIndex == 0)
            {
                CD_Grupo_Pai.ST_NotNull = true;
            }
            else
                CD_Grupo_Pai.ST_NotNull = false;
        }

        private void TFCadGrupoProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void BS_GrupoProduto_PositionChanged(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty((BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).QT_vl_bi) )
                qt_vl_bi.SelectedValue = (BS_GrupoProduto.Current as TRegistro_CadGrupoProduto).QT_vl_bi;
        }

    }
}