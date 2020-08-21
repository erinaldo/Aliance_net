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
    public partial class TFData : Form
    {
        public bool St_cliente
        { get; set; }
        public bool St_conjuge
        { get; set; }
        public bool St_contato
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_DataContato rDataContato;
        public CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor rDataClifor;

        public TFData()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(id_tpdata.Text))
            {
                MessageBox.Show("Informe o Tipo de Data!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (data.Text.Equals("/  /"))
            {
                MessageBox.Show("Informe o Data!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (St_cliente)
            {
                rDataClifor.Id_TpDataStr = id_tpdata.Text;
                rDataClifor.Ds_tpdata = ds_tpdata.Text;
                rDataClifor.Datastr = data.Text;
                rDataClifor.Tp_clifor = "C";
            }
            else if (St_conjuge)
            {
                rDataClifor.Id_TpDataStr = id_tpdata.Text;
                rDataClifor.Ds_tpdata = ds_tpdata.Text;
                rDataClifor.Datastr = data.Text;
                rDataClifor.Tp_clifor = "J";
            }
            else if (St_contato)
            {
                rDataContato.Id_TpDataStr = id_tpdata.Text;
                rDataContato.Ds_tpdata = ds_tpdata.Text;
                rDataContato.Datastr = data.Text;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void TFData_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rDataClifor == null)
                rDataClifor = new CamadaDados.Financeiro.Cadastros.TRegistro_DataClifor();
            if (rDataContato == null)
                rDataContato = new CamadaDados.Financeiro.Cadastros.TRegistro_DataContato();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_tpdata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdata|Tipo Data|200;" +
                             "a.id_tpdata|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpdata, ds_tpdata },
                new CamadaDados.Financeiro.Cadastros.TCD_TpData(),
               string.Empty);
        }

        private void id_tpdata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpdata|=|'" + id_tpdata.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpdata, ds_tpdata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_TpData());
        }

        private void TFData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;

        }
    }
}
