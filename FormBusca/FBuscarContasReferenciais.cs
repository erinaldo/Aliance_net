using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Contabil.Cadastro;

namespace FormBusca
{
    public partial class TFBuscarContasReferenciais : Form
    {
        public Utils.TpBusca[] pFiltro
        { get; set; }
        public TRegistro_PlanoReferencial rConta
        { get; set; }
        private int index = 1;

        public TFBuscarContasReferenciais()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsPlanoReferencial.Current != null)
            {
                if ((bsPlanoReferencial.Current as TRegistro_PlanoReferencial).Tp_conta.ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido selecionar conta SINTÉTICA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                rConta = bsPlanoReferencial.Current as TRegistro_PlanoReferencial;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscarIndexContaCtb()
        {
            try
            {
                if (bsPlanoReferencial.Current != null)
                {
                    var linha = gPlanoReferencial.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pNome"].Value.ToString().Contains(ds_conta.Text)).ToList();
                    if (linha != null)
                    {
                        if (index + 1 < linha.Count)
                            index++;
                        else
                            index = 0;
                        var p = linha[index];
                        gPlanoReferencial.Rows[p.Index].Selected = true;
                        bsPlanoReferencial.Position = p.Index;
                        lbSequencia.Text = (index + 1).ToString() + " de " + linha.Count;
                    }
                }
            }
            catch { }
        }

        private void ds_conta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow linha = gPlanoReferencial.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pNome"].Value.ToString().Contains(ds_conta.Text)).First();
                if (linha != null)
                {
                    gPlanoReferencial.Rows[linha.Index].Selected = true;
                    bsPlanoReferencial.Position = linha.Index;
                    decimal result = gPlanoReferencial.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pNome"].Value.ToString().Contains(ds_conta.Text)).Count();
                    if (result == 0)
                    {
                        lbResultados.Text = "NENHUM RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result == 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result > 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADOS ENCONTRADOS";
                        index = 0;
                    }
                    lbSequencia.Text = (index + 1).ToString() + " de " + result.ToString();

                }
            }
            catch { }
        }

        private void gPlanoReferencial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 2)
                    if ((bsPlanoReferencial[e.RowIndex] as TRegistro_PlanoReferencial).Tp_conta.Equals("S"))
                        gPlanoReferencial.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gPlanoReferencial.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void TFBuscarContasReferenciais_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsPlanoReferencial.DataSource = CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Buscar(string.Empty, string.Empty, null);
            ds_conta.Focus();
        }

        private void TFBuscarContasReferenciais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.Down))
                this.BuscarIndexContaCtb();
        }

        private void gPlanoReferencial_DoubleClick(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
