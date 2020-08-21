using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante;
using FormBusca;

namespace Restaurante
{
    public partial class TFLanMovBoliche : Form
    {
        public decimal Id_cartao { get; set; } = decimal.Zero;
        public string Cd_Empresa { get; set; } = string.Empty;
        public string Nr_cartao { get; set; } = string.Empty;
        public string lblTitul { get; set; } = string.Empty;
        public bool formUniver { get; set; } = false;

        public TFLanMovBoliche()
        {
            InitializeComponent();
        }

        private void nr_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                if (panelDados1.validarCampoObrigatorio())
                {
                    TList_Cartao lCartao = new TCD_Cartao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_cartao",
                                vOperador = "=",
                                vVL_Busca = nr_cartao.Text.ToString()
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.st_registro",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 1, string.Empty, string.Empty);

                    if (lCartao.Count.Equals(0))
                    {
                        MessageBox.Show("O número do cartão informado não consta disponível no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panelDados1.LimparRegistro();
                        nr_cartao.Focus();
                        return;
                    }

                    //Para form universal, disponibilizar nr. cartão
                    if (formUniver)
                    {
                        Nr_cartao = lCartao[0].nr_cartao;
                        this.DialogResult = DialogResult.OK;
                        return;
                    }

                    Id_cartao = lCartao[0].id_cartao;
                    Cd_Empresa = lCartao[0].Cd_empresa;
                    Nr_cartao = lCartao[0].nr_cartao;
                    this.DialogResult = DialogResult.OK;
                }
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanMovBoliche_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTitul.Trim()))
                lblTitulo.Text = lblTitul;
            nr_cartao.Focus();
        }

    }
}
