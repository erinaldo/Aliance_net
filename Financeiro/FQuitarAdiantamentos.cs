using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Adiantamento;

namespace Financeiro
{
    public partial class TFQuitarAdiantamentos : Form
    {
        public TRegistro_LanAdiantamento rAdto
        {
            get
            {
                if (bsAdiantamento.Current != null)
                    return bsAdiantamento.Current as TRegistro_LanAdiantamento;
                else
                    return null;
            }
        }
        public TFQuitarAdiantamentos()
        {
            InitializeComponent();
        }


        private void afterBusca()
        {
            bsAdiantamento.DataSource = TCN_LanAdiantamento.Buscar(string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     0,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     decimal.Zero,
                                                                     decimal.Zero,
                                                                     false,
                                                                     true,
                                                                     false,
                                                                     string.Empty,
                                                                     false,
                                                                     false,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     0,
                                                                     string.Empty,
                                                                     null);
            bsAdiantamento.ResetCurrentItem();
        }

        private void afterGrava()
        {
            if (bsAdiantamento.Current != null)
                if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).ST_ADTO != "C")
                    if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao > 0)
                        this.DialogResult = DialogResult.OK;
                        
        }

        private void TFQuitarAdiantamentos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFQuitarAdiantamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void btn_alteraValor_Click(object sender, EventArgs e)
        {
            if (bsAdiantamento.Current != null)
            {
                if ((bsAdiantamento.Current as TRegistro_LanAdiantamento).VL_total_quitado > 0)
                {
                    MessageBox.Show("Já existe quitação parcial para adiantamento!\r\n" +
                                    "Não é possível alterar o valor do adto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Vl_default = (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_saldo_quitacao;
                    fQtd.Ds_label = "Informe o Valor!";
                    fQtd.Casas_decimais = 2;
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > 0)
                            try
                            {                             
                                (bsAdiantamento.Current as TRegistro_LanAdiantamento).Vl_adto = fQtd.Quantidade;
                                TCN_LanAdiantamento.Gravar(bsAdiantamento.Current as TRegistro_LanAdiantamento, null);
                                MessageBox.Show("Valor adiantamento alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }  
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }               
                }
            }
        }
    }
}
