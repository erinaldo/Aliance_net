using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaEmpCondedido : Form
    {
        public string Id_caixa
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_EmprestimoConcedido rEmp
        {
            get
            {
                if (bsEmprestimo.Current != null)
                    return bsEmprestimo.Current as CamadaDados.Faturamento.PDV.TRegistro_EmprestimoConcedido;
                else return null;
            }
        }

        public TFListaEmpCondedido()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaEmpCondedido_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEmprestimo.DataSource = CamadaNegocio.Faturamento.PDV.TCN_EmprestimoConcedido.Buscar(string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   Id_caixa,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   "A",
                                                                                                   null);
        }

        private void TFListaEmpCondedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
