using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Fiscal
{
    public partial class TFLanctoImposto : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_imposto
        { get; set; }
        public string Dt_lancto
        { get; set; }
        public string Dt_ini
        { get; set; }
        public string D_c
        { get; set; }
        public bool St_icms
        { get; set; }

        public CamadaDados.Fiscal.TRegistro_LanctoImposto rLancto
        {
            get
            {
                if (bsLanctoImposto.Current != null)
                    return bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto;
                else
                    return null;
            }
        }

        public TFLanctoImposto()
        {
            InitializeComponent();
            this.St_icms = false;
            this.Cd_empresa = string.Empty;
            this.Cd_imposto = string.Empty;
            this.Dt_lancto = string.Empty;
            this.Dt_ini = string.Empty;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("OUTROS DEBITOS", "0"));
            cbx.Add(new Utils.TDataCombo("ESTORNO CREDITOS", "1"));
            cbx.Add(new Utils.TDataCombo("OUTROS CREDITOS", "2"));
            cbx.Add(new Utils.TDataCombo("ESTORNO DEBITOS", "3"));
            cbx.Add(new Utils.TDataCombo("DEDUÇÕES IMPOSTO APURAR", "4"));
            cbx.Add(new Utils.TDataCombo("DEBITOS ESPECIAIS", "5"));
            tp_lancto.DataSource = cbx;
            tp_lancto.DisplayMember = "Display";
            tp_lancto.ValueMember = "Value";
        }

        private void afterBusca()
        {
            bsLanctoImposto.DataSource = CamadaNegocio.Fiscal.TCN_LanctoImposto.Buscar(string.Empty,
                                                                                       cd_imposto.Text,
                                                                                       CD_Empresa.Text,
                                                                                       Dt_ini,
                                                                                       dt_lancto.Text,
                                                                                       string.Empty,
                                                                                       null);
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
            {
                bsLanctoImposto.AddNew();
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Cd_empresa = CD_Empresa.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Nm_empresa = NM_Empresa.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Cd_impostostr = cd_imposto.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Ds_imposto = ds_imposto.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).D_c = d_c.Text.Trim().ToUpper().Equals("DEBITO") ? "D" : d_c.Text.Trim().ToUpper().Equals("CREDITO") ? "C" : string.Empty;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Dt_lanctostr = dt_lancto.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Vl_lancto = vl_lancto.Value;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Tp_lancto = tp_lancto.SelectedValue != null ? tp_lancto.SelectedValue.ToString() : string.Empty;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Ds_observacao = ds_observacao.Text;
                (bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto).Cd_ajuste = cd_ajuste.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void afterExclui()
        {
            if (bsLanctoImposto.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_LanctoImposto.Excluir(bsLanctoImposto.Current as CamadaDados.Fiscal.TRegistro_LanctoImposto, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }   

        private void TFLanctoImposto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            CD_Empresa.Text = this.Cd_empresa;
            CD_Empresa_Leave(this, new EventArgs());
            CD_Empresa.Enabled = string.IsNullOrEmpty(this.Cd_empresa);
            BB_Empresa.Enabled = string.IsNullOrEmpty(this.Cd_empresa);
            cd_imposto.Text = this.Cd_imposto;
            cd_imposto_Leave(this, new EventArgs());
            cd_imposto.Enabled = string.IsNullOrEmpty(this.Cd_imposto);
            bb_imposto.Enabled = string.IsNullOrEmpty(this.Cd_imposto);
            dt_lancto.Text = this.Dt_lancto;
            if (!string.IsNullOrEmpty(D_c))
                tp_lancto.SelectedIndex = D_c.Trim().ToUpper().Equals("D") ? 0 : 2;
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanctoImposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParam = "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam); 
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(Select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Imposto|Imposto|200;" +
                              "a.CD_Imposto|Cd. Imposto|80";
            string vParam = string.Empty;
            if (this.St_icms)
                vParam = "a.st_icms|=|0";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                            new CamadaDados.Fiscal.TCD_CadImposto(), vParam);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            if (this.St_icms)
                vParam += ";a.st_icms|=|0";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void tp_lancto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_lancto.SelectedValue != null)
                if (tp_lancto.SelectedValue.ToString().Trim().Equals("0") ||
                    tp_lancto.SelectedValue.ToString().Trim().Equals("1") ||
                    tp_lancto.SelectedValue.ToString().Trim().Equals("4") ||
                    tp_lancto.SelectedValue.ToString().Trim().Equals("5"))
                    d_c.Text = "DEBITO";
                else
                    d_c.Text = "CREDITO";
        }

        private void bb_ajuste_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ajuste|Descrição Ajuste|200;" +
                              "a.cd_ajuste|Cd. Ajuste|80";
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text + ";" +
                            "substring(a.cd_ajuste, 4, 1)|=|'" + (tp_lancto.SelectedValue != null ? tp_lancto.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ajuste, ds_ajuste },
                                    new CamadaDados.Fiscal.TCD_AjusteICMS(), vParam);
        }

        private void cd_ajuste_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_ajuste|=|'" + cd_ajuste.Text.Trim() + "';" +
                            "a.cd_imposto|=|" + cd_imposto.Text + ";" +
                            "substring(a.cd_ajuste, 4, 1)|=|'" + (tp_lancto.SelectedValue != null ? tp_lancto.SelectedValue.ToString() : string.Empty) + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ajuste, ds_ajuste },
                                    new CamadaDados.Fiscal.TCD_AjusteICMS());
        }

        private void bb_ajusteIPI_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ajusteipi|Ajuste IPI|200;" +
                              "a.cd_ajusteipi|Cd. Ajuste|80";
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ajusteIPI, ds_ajusteIPI },
                                    new CamadaDados.Fiscal.TCD_AjusteIPI(), vParam);
        }

        private void cd_ajusteIPI_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_ajusteipi|=|" + cd_ajusteIPI.Text + ";" +
                            "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ajusteIPI, ds_ajusteIPI },
                                    new CamadaDados.Fiscal.TCD_AjusteIPI());
        }

        private void TFLanctoImposto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
