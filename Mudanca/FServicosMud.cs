using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mudanca
{
    public partial class TFServicosMud : Form
    {
        public List<CamadaDados.Mudanca.Cadastros.TRegistro_CadServico> lServico
        {
            get
            {
                if (bsServico.Count > decimal.Zero)
                    return (bsServico.DataSource as CamadaDados.Mudanca.Cadastros.TList_CadServico).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFServicosMud()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsServico.DataSource =
                CamadaNegocio.Mudanca.Cadastros.TCN_CadServico.Buscar(string.Empty,
                                                                      ds_servico.Text,
                                                                      null);
            bsServico.ResetCurrentItem();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFServicosMud_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void gServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar =
                         !(bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar;
                //Informar Quantidade
                if ((bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar)
                {
                    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                    {
                        fValor.Ds_label = "Valor Serviço";
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                                (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico = fValor.Quantidade;
                    }
                    if ((bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico.Equals(decimal.Zero))
                    {
                        (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar = false;
                        MessageBox.Show("Obrigatório informar Valor serviço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico = decimal.Zero;

                tot_servico.Text = (bsServico.DataSource as CamadaDados.Mudanca.Cadastros.TList_CadServico).Sum(p => p.Vl_servico).ToString("N2", new System.Globalization.CultureInfo("pt-BR")); ;
                bsServico.ResetCurrentItem();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFServicosMud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gServico_DoubleClick(object sender, EventArgs e)
        {
            if (bsServico.Current != null)
                if ((bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar)
                {
                    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                    {
                        fValor.Vl_default = (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico;
                        fValor.Ds_label = "Valor Serviço";
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                                (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico = fValor.Quantidade;
                    }
                    if ((bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).Vl_servico.Equals(decimal.Zero))
                    {
                        (bsServico.Current as CamadaDados.Mudanca.Cadastros.TRegistro_CadServico).St_processar = false;
                        MessageBox.Show("Obrigatório informar Valor serviço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    tot_servico.Text = (bsServico.DataSource as CamadaDados.Mudanca.Cadastros.TList_CadServico).Sum(p => p.Vl_servico).ToString("N2", new System.Globalization.CultureInfo("pt-BR")); ;
                    bsServico.ResetCurrentItem();
                }
        }
    }
}
