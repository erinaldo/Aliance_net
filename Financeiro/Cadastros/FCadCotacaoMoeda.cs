using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadCotacaoMoeda : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCotacaoMoeda()
        {
            InitializeComponent();
            this.DTS = bsCotacao;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("* - Multiplicação", "*"));
            cbx.Add(new TDataCombo("/ - Divisão", "/"));
            op.DataSource = cbx;
            op.DisplayMember = "Display";
            op.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CotacaoMoeda.GravarCotacao(bsCotacao.Current as TRegistro_CotacaoMoeda, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CotacaoMoeda lista = TCN_CotacaoMoeda.Buscar(CD_Moeda.Text,
                                                               CD_moedaResult.Text,
                                                               null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCotacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCotacao.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                bsCotacao.AddNew();
            base.afterNovo();
            CD_Moeda.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_moeda.Enabled = false;
            bb_moedaresult.Enabled = false;
            valor.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCotacao.RemoveCurrent();
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|350;" +
                              "CD_Moeda|Cód. Moeda|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "");
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            if (CD_Moeda.Text.Trim() != "")
            {
                string vColunas = CD_Moeda.NM_CampoBusca + "|=|'" + CD_Moeda.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                        new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
            }
            else
                ds_moeda.Clear();
        }

        private void bb_moedaresult_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|350;" +
                              "CD_Moeda|Cód. Moeda|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_moedaResult, ds_moedaresult },
                                    new TCD_Moeda(), "");
        }

        private void CD_moedaResult_Leave(object sender, EventArgs e)
        {
            if (CD_moedaResult.Text.Trim() != "")
            {
                string vColunas = CD_moedaResult.NM_CampoBusca + "|=|'" + CD_moedaResult.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_moedaResult, ds_moedaresult },
                                        new TCD_Moeda());
            }
            else
                ds_moedaresult.Clear();
        }

        private void TFCadCotacaoMoeda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCotacaoMoeda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

