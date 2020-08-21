using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;


namespace Empreendimento
{
    public partial class FDesconto : Form
    {
        private TRegistro_Orcamento cEmpreendimento { get; set; } = new TRegistro_Orcamento(); 
        public TRegistro_Orcamento rEmpreendimento
        {
            get
            {
                return bsOrcamento.Current as TRegistro_Orcamento;
            }
            set
            {
                cEmpreendimento = value;
            }
        }

        public FDesconto()
        {
            InitializeComponent();
        }

        private void FDesconto_Load(object sender, EventArgs e)
        {
            if (cEmpreendimento != null)
            {
                bsOrcamento.Add(cEmpreendimento);
                tot_orcamento.Value = cEmpreendimento.vl_orcamento;
            }
            else
                bsOrcamento.AddNew();

        }


        private void calcula_desconto()
        {
            if(vl_desconto.Value != decimal.Zero)
            {
                decimal pcdesc = decimal.Divide(decimal.Multiply(vl_desconto.Value, 100),tot_orcamento.Value);
                if ((bsOrcamento.Current as TRegistro_Orcamento).Pc_descprog >= pcdesc)
                {
                    pc_desconto.Value = pcdesc;
                    tot_orcamento_liq.Value = decimal.Subtract(tot_orcamento.Value, vl_desconto.Value);
                }
                else
                {
                    MessageBox.Show("Desconto máximo disponivel é " + (bsOrcamento.Current as TRegistro_Orcamento).Pc_descprog + "%", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    tot_orcamento_liq.Value =tot_orcamento.Value; 
                }


            }else if(pc_desconto.Value != decimal.Zero)
            {
                if((bsOrcamento.Current as TRegistro_Orcamento).Pc_descprog >= pc_desconto.Value)
                {
                    vl_desconto.Value = decimal.Divide(decimal.Multiply(tot_orcamento.Value, pc_desconto.Value), 100);
                    tot_orcamento_liq.Value = decimal.Subtract(tot_orcamento.Value, vl_desconto.Value);
                }
                else
                {
                    MessageBox.Show("Desconto máximo disponivel é " + (bsOrcamento.Current as TRegistro_Orcamento).Pc_descprog + "%", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    vl_desconto.Value = decimal.Zero;
                    pc_desconto.Value = decimal.Zero;
                    tot_orcamento_liq.Value = tot_orcamento.Value;
                }
            } 

        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            calcula_desconto();
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {

            calcula_desconto();
        }

        private void FDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bsOrcamento.ResetCurrentItem();
                this.DialogResult = DialogResult.OK;

            }else if (e.KeyCode.Equals(Keys.F6))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            bsOrcamento.ResetCurrentItem();
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
