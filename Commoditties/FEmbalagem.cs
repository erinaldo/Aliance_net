using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Estoque.Cadastros;

namespace Commoditties
{
    public partial class TFEmbalagem : Form
    {
        public string Tp_mov
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Qtd_entrada
        { get; set; }
        public decimal Qtd_saida
        { get; set; }
        public string Ds_observacao
        { get; set; }

        public CamadaDados.Estoque.TRegistro_LanEstoque rEstoque
        {
            get
            {
                if (BS_Lan_Estoque.Current != null)
                    return BS_Lan_Estoque.Current as CamadaDados.Estoque.TRegistro_LanEstoque;
                else
                    return null;
            }
        }

        public TFEmbalagem()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";

            this.Tp_mov = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Qtd_entrada = decimal.Zero;
            this.Qtd_saida = decimal.Zero;
            this.Ds_observacao = string.Empty;
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(DT_Lancamento.Text) || (DT_Lancamento.Text.Trim().Equals("/  /")))
            {
                MessageBox.Show("Obrigatorio informar data lançamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Lancamento.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Local.Text))
            {
                MessageBox.Show("Obrigatorio informar local de armazenagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Local.Focus();
                return;
            }
            if(tp_movimento.Text.Trim().ToUpper().Equals("ENTRADA") && Qtd_Entrada.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar quantidade de entrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Qtd_Entrada.Focus();
                return;
            }
            if(tp_movimento.Text.Trim().ToUpper().Equals("SAIDA") && Qtd_Saida.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar quantidade de saida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Qtd_Saida.Focus();
                return;
            }
            if(VL_Unitario.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar valor unitario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VL_Unitario.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void busca_Valor_Unitario()
        {
            if (BS_Lan_Estoque.Current != null)
                if ((!string.IsNullOrEmpty((BS_Lan_Estoque.Current as CamadaDados.Estoque.TRegistro_LanEstoque).Cd_empresa)) && 
                    (!string.IsNullOrEmpty((BS_Lan_Estoque.Current as CamadaDados.Estoque.TRegistro_LanEstoque).Cd_produto)))
                {
                    decimal Tot_Entrada = decimal.Zero;
                    decimal Tot_Saida = decimal.Zero;
                    decimal Tot_Saldo = decimal.Zero;
                    decimal VL_Estoque_ent = decimal.Zero;
                    decimal VL_Estoque_sai = decimal.Zero;
                    decimal VL_SaldoEstoque = decimal.Zero;
                    decimal VL_Medio = decimal.Zero;

                    CamadaNegocio.Estoque.TCN_LanEstoque.Valores_Estoque((BS_Lan_Estoque.Current as CamadaDados.Estoque.TRegistro_LanEstoque).Cd_empresa, 
                                                                         (BS_Lan_Estoque.Current as CamadaDados.Estoque.TRegistro_LanEstoque).Cd_produto, 
                                                                         ref Tot_Entrada, 
                                                                         ref Tot_Saida,
                                                                         ref Tot_Saldo, 
                                                                         ref VL_Estoque_ent, 
                                                                         ref VL_Estoque_sai, 
                                                                         ref VL_SaldoEstoque, 
                                                                         ref VL_Medio,
                                                                         null);
                    VL_Unitario.Value = VL_Medio;
                }
        }

        private void TFEmbalagem_Load(object sender, EventArgs e)
        {
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pnl_Lan_Estoque.set_FormatZero();
            BS_Lan_Estoque.AddNew();
            tp_movimento.SelectedIndex = this.Tp_mov.Trim().ToUpper().Equals("E") ? 0 :
                this.Tp_mov.Trim().ToUpper().Equals("S") ? 1 : -1;
            CD_Empresa.Text = this.Cd_empresa;
            NM_Empresa.Text = this.Nm_empresa;
            CD_Produto.Text = this.Cd_produto;
            DS_Produto.Text = this.Ds_produto;
            Sigla.Text = this.Sigla_unidade;
            CD_Local.Text = this.Cd_local;
            DS_Local.Text = this.Ds_local;
            Qtd_Saida.Value = this.Qtd_saida;
            Qtd_Saida.Enabled = (this.Qtd_saida.Equals(0) && Qtd_Saida.Visible);
            Qtd_Entrada.Value = this.Qtd_entrada;
            Qtd_Entrada.Enabled = (this.Qtd_entrada.Equals(0) && Qtd_Entrada.Visible);
            DS_Observacao.Text = this.Ds_observacao;
            this.busca_Valor_Unitario();
            DT_Lancamento.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                {
                    lbl_quantidade.Text = "Qtd. Entrada:";
                    Qtd_Entrada.Visible = true;
                    Qtd_Entrada.ST_NotNull = true;
                    Qtd_Saida.Visible = false;
                    Qtd_Saida.ST_NotNull = false;
                }
                else if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                {
                    lbl_quantidade.Text = "Qtd. Saida:";
                    Qtd_Saida.Visible = true;
                    Qtd_Saida.ST_NotNull = true;
                    Qtd_Entrada.Visible = false;
                    Qtd_Entrada.ST_NotNull = false;
                }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEmbalagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
