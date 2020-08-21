using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCfgImpCheque : Form
    {
        private CamadaDados.Financeiro.Cadastros.TRegistro_CFGImpCheque rcfg;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CFGImpCheque rCfg
        {
            get
            {
                if (bsCfgImpCheque.Current != null)
                    return bsCfgImpCheque.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGImpCheque;
                else
                    return null;
            }
            set { rcfg = value; }
        }

        public TFCfgImpCheque()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ESQUERDA", "E"));
            cbx.Add(new Utils.TDataCombo("DIREITA", "D"));
            tp_alinhamento.DataSource = cbx;
            tp_alinhamento.DisplayMember = "Display";
            tp_alinhamento.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("VALOR CHEQUE", "VL_TITULO"));
            cbx1.Add(new Utils.TDataCombo("VALOR EXTENSO", "VL_EXTENSO"));
            cbx1.Add(new Utils.TDataCombo("VALOR EXTENSO 1", "VL_EXTENSO1"));
            cbx1.Add(new Utils.TDataCombo("CIDADE", "DS_CIDADE"));
            cbx1.Add(new Utils.TDataCombo("DIA", "DIA"));
            cbx1.Add(new Utils.TDataCombo("MES", "MES"));
            cbx1.Add(new Utils.TDataCombo("ANO", "ANO"));
            cbx1.Add(new Utils.TDataCombo("DATA VENCIMENTO", "DT_PARA"));
            cbx1.Add(new Utils.TDataCombo("NOMINAL", "NOMINAL"));
            cbx1.Add(new Utils.TDataCombo("Nº CHEQUE", "NR_CHEQUE"));
            nm_campo.DataSource = cbx1;
            nm_campo.DisplayMember = "Display";
            nm_campo.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("NORMAL", "N"));
            cbx2.Add(new Utils.TDataCombo("EXPANDIDO", "E"));
            cbx2.Add(new Utils.TDataCombo("COMPRIMIDO", "C"));
            tp_fonte.DataSource = cbx2;
            tp_fonte.DisplayMember = "Display";
            tp_fonte.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFCfgImpCheque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcfg != null)
                bsCfgImpCheque.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CFGImpCheque() { rcfg };
            else
                bsCfgImpCheque.AddNew();
            nm_campo.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCfgImpCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
