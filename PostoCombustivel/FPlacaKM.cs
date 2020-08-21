using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFPlacaKM : Form
    {
        private string pplaca;
        public string Placa
        { get { return placa.Text; } set { pplaca = value; } }
        public decimal Km_atual
        { get { return km.Value; } }
        public decimal Km_maximo
        { get; set; }
        public string Nm_motorista
        { get { return nm_motorista.Text; } }
        public string Cpf_motorista
        { get { return cpf_motorista.Text; } }
        public string Nr_frota
        { get { return nr_frota.Text; } }
        public string Nr_requisicao
        { get { return nr_requisicao.Text; } }
        public TFPlacaKM()
        {
            InitializeComponent();
        }

        private bool ValidarKm(ref decimal Km_atual)
        {
            bool retorno = true;
            //Validar KM Atual
            if ((!string.IsNullOrEmpty(placa.Text)) &&
                (placa.Text.Trim() != "-") &&
                (km.Value > decimal.Zero))
            {

                //Buscar ultimo KM Informado para a placa
                object obj = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                            vOperador = "=",
                                            vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                        }
                                    }, "isnull(a.km_atual, 0)", string.Empty, "a.dt_abastecimento desc", null);
                if (obj != null)
                {
                    Km_atual = decimal.Parse(obj.ToString());
                    if (Km_atual > km.Value)
                        retorno = false;
                }
            }
            return retorno;
        }

        private void afterGrava()
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                if (cpf_motorista.Focused)
                {
                    cpf_motorista_Leave(cpf_motorista.Text, new EventArgs());
                    return;
                }
                decimal KM = decimal.Zero;
                if (!this.ValidarKm(ref KM))
                {
                    if (MessageBox.Show("KM Atual não pode ser menor ou igual ao ultimo KM informado para a placa (Ultimo KM: " + KM.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + ").\r\n" +
                                    "Deseja corrigir ultimo KM informado?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Buscar abastecida do ultimo KM
                        CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaUltimoKM =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                    vOperador = "=",
                                    vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                }
                            }, 1, string.Empty, "a.dt_abastecimento desc");
                        if (lVendaUltimoKM.Count > 0)
                            using (PDV.TFCorrigirKM fKM = new PDV.TFCorrigirKM())
                            {
                                fKM.Ultimo_km = lVendaUltimoKM[0].Km_atual;
                                fKM.Km_atual = km.Value;
                                if (fKM.ShowDialog() == DialogResult.OK)
                                    try
                                    {
                                        lVendaUltimoKM[0].Km_atual = fKM.Km_corrigido;
                                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(lVendaUltimoKM[0], null);
                                        MessageBox.Show("Ultimo KM corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void cpf_motorista_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
            {
                Utils.CPF_Valido.nr_CPF = cpf_motorista.Text;
                if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cpf_motorista.Clear();
                    cpf_motorista.Focus();
                    return;
                }
            }
        }

        private void cpf_motorista_TextChanged(object sender, EventArgs e)
        {
            if (cpf_motorista.Text.Trim().Length.Equals(3) ||
                cpf_motorista.Text.Trim().Length.Equals(7))
            {
                cpf_motorista.Text = cpf_motorista.Text + ".";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
            if (cpf_motorista.Text.Trim().Length.Equals(11))
            {
                cpf_motorista.Text = cpf_motorista.Text + "-";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
        }

        private void TFPlacaKM_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFPlacaKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
 }
