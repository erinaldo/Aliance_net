using Financeiro.Cadastros;
using System;
using System.Data;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFDespesasViagem : Form
    {
        public string vCD_Clifor { get; set; } = string.Empty;
        private CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem rdespesas;
        public CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem rDespesas
        {
            get
            {
                if (bsDespesas.Current != null)
                    return bsDespesas.Current as CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem;
                else
                    return null;
            }
            set { rdespesas = value; }
        }
        public TFDespesasViagem()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("FUNCIONÁRIO", "0"));
            cbx.Add(new Utils.TDataCombo("EMPRESA", "1"));
            tp_pagamento.DataSource = cbx;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDespesas.validarCampoObrigatorio())
            {
                if (tp_pagamento.SelectedValue.Equals("1") && string.IsNullOrEmpty(vCD_Clifor))
                {
                    MessageBox.Show("Tipo de Pagamento selecionado é por Empresa.\r\n" + 
                                    "Informe um fornecedor já cadastrado no sistema!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFDespesasViagem_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDespesas.set_FormatZero();
            if (rdespesas != null)
            {
                bsDespesas.DataSource = new CamadaDados.Financeiro.Viagem.TList_DespesasViagem() { rdespesas };
                tp_pagamento.Enabled = false;
            }
            else
                bsDespesas.AddNew();
        }

        private void TFDespesasViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
           DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_fornecedor }, vParam);

            if (linha != null)
                vCD_Clifor = linha["cd_clifor"].ToString();

        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                quantidade_Leave(this, new EventArgs());
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_unitario_Leave(this, new EventArgs());
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {
            if (quantidade.Value > decimal.Zero)
                vl_unitario.Value = vl_subtotal.Value / quantidade.Value;
        }

        private void vl_subtotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_subtotal_Leave(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            vCD_Clifor = fClifor.rClifor.Cd_clifor;
                            nm_fornecedor.Text = fClifor.rClifor.Nm_clifor;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbCliente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliente, nm_cliente }, string.Empty);
        }

        private void cd_cliente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|'" + cd_cliente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliente, nm_cliente },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
