using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante;

namespace Restaurante
{
    public partial class TFFecharDelivery : Form
    {
        private TRegistro_PreVenda cPrevenda = new TRegistro_PreVenda();
        public TRegistro_PreVenda rPreVenda
        {
            get
            {
                return bsPreVenda.Current as TRegistro_PreVenda;
            }
            set
            {
                cPrevenda = value;
            }
        }

        public TFFecharDelivery()
        {
            InitializeComponent();
        }

        private void FApontarDelivery_Load(object sender, EventArgs e)
        {
            decimal total = decimal.Zero;

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (cPrevenda != null)
            {
                bsPreVenda.Add(cPrevenda);
                cPrevenda.lItens.ForEach(p =>
                {
                    total += p.vl_liquido;
                });
                tot.Text = total.ToString();
                a_pagar.Value = total;
                editDefault1.Text = (a_pagar.Value - Convert.ToDecimal(tot.Text)).ToString();
            }
            editData1.Text = DateTime.Now.ToString();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            //  (bsPreVenda.Current as TRegistro_PreVenda).St_registro = "E";
            if (Convert.ToDecimal(tot.Text) <= a_pagar.Value)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Valor a pagar deve ser maior!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja cancelar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        { 
            a_pagar.Enabled = !checkBoxDefault1.Checked;
            if (checkBoxDefault1.Checked)
            {
                a_pagar.Value = Convert.ToDecimal(tot.Text);
                editDefault1.Text = (Convert.ToDecimal(tot.Text) - a_pagar.Value).ToString();

                //checkBoxDefault1.Checked = false;
            } 
        }

        private void FApontarDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            else
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs()); 
        }

        private void editFloat1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(a_pagar.Value) > Convert.ToDecimal(tot.Text))
                editDefault1.Text = ( a_pagar.Value - Convert.ToDecimal(tot.Text) ).ToString();
        }

        private void abrirmapa()
        {
            CamadaDados.Restaurante.Cadastro.TList_CFG lcfg = new CamadaDados.Restaurante.Cadastro.TList_CFG();
            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco end = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
            end = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lcfg[0].Cd_Clifor, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1, null);
            
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco endclif = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
            endclif = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsPreVenda.Current as TRegistro_PreVenda).cd_clifor, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1, null);

            using (Proc_Commoditties.FLocalizacaoGoogleMaps proc = new Proc_Commoditties.FLocalizacaoGoogleMaps())
            {
                proc.pOrigem = end[0].DS_Cidade +" "+ end[0].Ds_endereco + " " + end[0].Numero
                     + " " + end[0].Cep;
                proc.pDestino = endclif[0].DS_Cidade + " " + endclif[0].Ds_endereco + " " + endclif[0].Numero
                     + " " + endclif[0].Cep;

                if (proc.ShowDialog() == DialogResult.OK)
                {

                }

            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            abrirmapa();
        }

    }
}
