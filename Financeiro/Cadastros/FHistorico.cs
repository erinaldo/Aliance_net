using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFHistorico : Form
    {
        public string Tp_movimento
        { get; set; }

        private CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico rhist;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico rHist
        {
            get
            {
                if (bsHistorico.Current != null)
                    return bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico;
                else return null;
            }
            set { rhist = value; }
        }
        public TFHistorico()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("(NENHUM)", ""));
            cbx.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_mov.DataSource = cbx;
            tp_mov.DisplayMember = "Display";
            tp_mov.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFHistorico_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rhist != null)
            {
                bsHistorico.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadHistorico() { rhist };
                tp_mov.Enabled = false;
            }
            else
            {
                bsHistorico.AddNew();
                if (!string.IsNullOrEmpty(Tp_movimento))
                {
                    (bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico).Tp_mov = Tp_movimento;
                    tp_mov.Enabled = false;
                    bsHistorico.ResetCurrentItem();
                }
            }
        }

        private void BB_Historico_Quitacao_Click(object sender, EventArgs e)
        {
            if (tp_mov.SelectedValue != "")
            {
                string vColunas = "a.DS_Historico|Des. Histórico Quitação|350;" +
                                "a.CD_Historico|Cód. Histórico Quitação|100";
                string vParamFixo = string.Empty;
                if (tp_mov.SelectedValue != null)
                    vParamFixo += "a.TP_Mov|=|'" + tp_mov.SelectedValue.ToString().Trim().ToUpper() + "'";
                FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Quitacao, DS_Historico_Quitacao },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
            }
            else
                MessageBox.Show("Informe o Movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CD_Historico_Quitacao_Leave(object sender, EventArgs e)
        {
            if (tp_mov.SelectedValue != "")
            {
                string vColunas = "a.CD_Historico|=|'" + CD_Historico_Quitacao.Text + "'";
                if (tp_mov.SelectedValue != null)
                    vColunas += ";a.TP_Mov|=|'" + tp_mov.SelectedValue.ToString().Trim().ToUpper() + "'";
                FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico_Quitacao, DS_Historico_Quitacao },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
            }
            else
                MessageBox.Show("Informe o Movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_grupocf_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupocf|Despesas Fixas|200;" +
                              "a.cd_grupocf|Codigo|80;" +
                              "b.ds_grupocf|Grupo Pai|200";
            string vParam = "isnull(a.st_sintetico, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupocf_juro, ds_grupocf_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadGrupoCF(), vParam);
        }

        private void cd_grupocf_juro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupocf|=|'" + cd_grupocf_juro.Text.Trim() + "';" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupocf_juro, ds_grupocf_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadGrupoCF());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFHistorico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        //private void bb_centroresult_Click(object sender, EventArgs e)
        //{
        //    if (tp_mov.SelectedIndex != 0)
        //    {
        //        string vColunas = "a.DS_CentroResultado|Centro Resultado|200;" +
        //                          "a.CD_CentroResult|Código|60";
        //        string vParam = "isnull(a.st_registro, 'A')|<>|'C';isnull(a.ST_Sintetico, 'N')|<>|'S'" +
        //                        (tp_mov.SelectedValue.Equals("P") ? ";a.TP_Registro|=|'D'" : ";a.TP_Registro|=|'R'");
        //        FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_centroresult, ds_centroresultado },
        //            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado(), vParam);
        //    }
        //    else
        //        MessageBox.Show("Informe o Tipo de Movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void cd_centroresult_Leave(object sender, EventArgs e)
        //{
        //    if (tp_mov.SelectedIndex != 0)
        //    {
        //        string vParam = "a.cd_centroresult|=|'" + cd_centroresult.Text.Trim() + "';" +
        //                    "isnull(a.st_registro, 'A')|<>|'C';isnull(a.st_sintetico, 'N')|<>|'S'" +
        //                        (tp_mov.SelectedValue.Equals("P") ? ";a.TP_Registro|=|'D'" : ";a.TP_Registro|=|'R'");
        //        FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult, ds_centroresultado },
        //            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        //    }
        //    else
        //        MessageBox.Show("Informe o Tipo de Movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
    }
}
