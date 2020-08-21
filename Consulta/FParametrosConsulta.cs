using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consulta
{
    public partial class TFParametrosConsulta : Form
    {
        public DataTable data
        { get; set; }
        public List<string> lista
        { get; set; }
        public TFParametrosConsulta()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            TS_Param.Focus();
            for (int i = 0; gParam.RowCount > i; i++)
                data.Rows[i]["valor"] = gParam.Rows[i].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void TFParametrosConsulta_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            data = new DataTable();
            data.Columns.Add("param", Type.GetType("System.String"));
            data.Columns.Add("valor", Type.GetType("System.String"));
            lista.ForEach(p =>
            {
                DataRow line = data.NewRow();
                line["param"] = p;
                line["valor"] = string.Empty;
                data.Rows.Add(line);
            });
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            gParam.DataSource = bs;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFParametrosConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
        }
    }
}
