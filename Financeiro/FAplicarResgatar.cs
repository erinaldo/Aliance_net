using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFAplicarResgatar : Form
    {
        public string Tp_lancamento
        { get; set; }
        public string pCd_empresa
        { get { return cd_empresa.Text; } }
        public string pCd_historico
        { get { return cd_historico.Text; } }
        public decimal pValor
        { get { return valor.Value; } }
        public DateTime? pDt_lancto
        { get { return string.IsNullOrEmpty(dt_lancto.Text.SoNumero()) ? CamadaDados.UtilData.Data_Servidor() : DateTime.Parse(dt_lancto.Text); } }

        public TFAplicarResgatar()
        {

            InitializeComponent();
            this.Tp_lancamento = string.Empty;
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_historico.Text))
            {
                MessageBox.Show("Obrigatório informar histórico.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_historico.Focus();
                return;
            }
            if (valor.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_lancto.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data lançamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_lancto.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFAplicarResgatar_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (this.Tp_lancamento.Trim().ToUpper().Equals("T"))
                this.Text = "Aplicação/Resgate";
            else this.Text = "Corrigir Aplicação";
            dt_lancto.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Codigo|60";
            string vParam = string.Empty;
            if (Tp_lancamento.Trim().ToUpper().Equals("T"))
                vParam = "isnull(a.st_transferencia, 'N')|=|'S'";
            else vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "'";
            if (Tp_lancamento.Trim().ToUpper().Equals("T"))
                vParam += ";isnull(a.st_transferencia, 'N')|=|'S'";
            else vParam += ";a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void TFAplicarResgatar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
