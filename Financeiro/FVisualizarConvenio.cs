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
    public partial class TFVisualizarConvenio : Form
    {
        public string Id_convenio
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public TFVisualizarConvenio()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("ENCERRADO", "E"));

            st_registro.DataSource = cbx;
            st_registro.ValueMember = "Value";
            st_registro.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx1.Add(new Utils.TDataCombo("VALOR", "V"));

            tp_desconto.DataSource = cbx1;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("ACRESCIMO", "A"));
            cbx2.Add(new Utils.TDataCombo("DESCONTO", "D"));
            tp_acresdesc.DataSource = cbx2;
            tp_acresdesc.DisplayMember = "Display";
            tp_acresdesc.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new Utils.TDataCombo("CUPOM FISCAL", "CF"));
            cbx3.Add(new Utils.TDataCombo("NOTA FISCAL", "NF"));
            tp_faturamento.DataSource = cbx3;
            tp_faturamento.DisplayMember = "Display";
            tp_faturamento.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("SEMANAL", "S"));
            cbx4.Add(new Utils.TDataCombo("QUINZENAL", "Q"));
            cbx4.Add(new Utils.TDataCombo("MENSAL", "M"));
            periodofatura.DataSource = cbx4;
            periodofatura.DisplayMember = "Display";
            periodofatura.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new Utils.TDataCombo("SEGUNDA-FEIRA", "0"));
            cbx5.Add(new Utils.TDataCombo("TERÇA-FEIRA", "1"));
            cbx5.Add(new Utils.TDataCombo("QUARTA-FEIRA", "2"));
            cbx5.Add(new Utils.TDataCombo("QUINTA-FEIRA", "3"));
            cbx5.Add(new Utils.TDataCombo("SEXTA-FEIRA", "4"));
            cbx5.Add(new Utils.TDataCombo("SABADO", "5"));
            cbx5.Add(new Utils.TDataCombo("DOMINGO", "6"));
            diasemana.DataSource = cbx5;
            diasemana.DisplayMember = "Display";
            diasemana.ValueMember = "Value";
        }

        private void TFVisualizarConvenio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsConvenio.DataSource =
                new CamadaDados.PostoCombustivel.TCD_Convenio().Select(
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
                            vNM_Campo = "a.id_convenio",
                            vOperador = "=",
                            vVL_Busca = Id_convenio
                        }
                    }, 1, string.Empty);
        }

        private void TFVisualizarConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
