using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFSerieNF : Form
    {
        public string cd_modelostr = string.Empty;
        private CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF rserie;
        public CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF rSerie
        {
            get
            {
                if (bsSerie.Current != null)
                    return bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF;
                else return null;
            }
            set { rserie = value; }
        }

        public TFSerieNF()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PRODUTO", "P"));
            cbx.Add(new Utils.TDataCombo("SERVIÇO", "S"));
            cbx.Add(new Utils.TDataCombo("MISTO - PRODUTO E SERVIÇO", "M"));

            tp_serie.DataSource = cbx;
            tp_serie.DisplayMember = "Display";
            tp_serie.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFSerieNF_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            if (rserie != null)
            {
                bsSerie.DataSource = new CamadaDados.Faturamento.Cadastros.TList_CadSerieNF() { rserie };
                cd_modelo.Enabled = false;
                bb_modelo.Enabled = false;
                nr_serie.Enabled = false;
            }
            else 
            {
                bsSerie.AddNew();
                (bsSerie.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo = cd_modelostr;
                cd_modelo.Text = cd_modelostr;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFSerieNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|150;" +
                              "a.cd_modelo|Codigo|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(), string.Empty);
        }

        private void cd_modelo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'" + cd_modelo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_modelo, ds_modelo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF());
        }
    }
}
