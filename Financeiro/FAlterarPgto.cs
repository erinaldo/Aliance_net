using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFAlterarPgto : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_funcionario
        { get; set; }
        public string Nm_funcionario
        { get; set; }
        public decimal Vl_pagamento
        {
            get { return vl_pagamento.Value; }
            set { vl_pagamento.Value = value; }
        }
        public decimal Vl_adiantamento
        {
            get { return vl_adtodevolver.Value; }
            set { vl_adtodevolver.Value = value; }
        }

        public TFAlterarPgto()
        {
            InitializeComponent();
            this.Cd_funcionario = string.Empty;
            this.Nm_funcionario = string.Empty;
        }

        private void afterGrava()
        {
            if (vl_adtodevolver.Focused)
                vl_adtodevolver_Leave(this, new EventArgs());
            this.DialogResult = DialogResult.OK;
        }

        private void TFAlterarPgto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_funcionario.Text = this.Cd_funcionario;
            nm_funcionario.Text = this.Nm_funcionario;
            //Buscar saldo adiantamento devolver
            object obj = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'" 
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_funcionario.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_adto, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'C'"
                                }
                            }, "ISNULL(SUM(ISNULL(a.vl_pagar, 0)), 0) - ISNULL(SUM(ISNULL(a.vl_receber, 0)), 0)");
            vl_saldodevolver.Value = obj == null ? vl_saldodevolver.Minimum : Convert.ToDecimal(obj.ToString());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFAlterarPgto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void vl_adtodevolver_Leave(object sender, EventArgs e)
        {
            if (vl_adtodevolver.Value > vl_saldodevolver.Value)
                vl_adtodevolver.Value = vl_saldodevolver.Value;
            if (vl_adtodevolver.Value > vl_pagamento.Value)
                vl_adtodevolver.Value = vl_pagamento.Value;
        }
    }
}
