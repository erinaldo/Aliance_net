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
    public partial class TFCadCondPGTO_X_Parcelas : Form
    {
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rcondpgto;
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCondpgto
        {
            get
            {
                if (BS_CondPGTO.Current != null)
                    return BS_CondPGTO.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto;
                else
                    return null;
            }
            set
            { rcondpgto = value; }
        }

        public TFCadCondPGTO_X_Parcelas()
        {
            InitializeComponent();
        }

        private void TFCadCondPGTO_X_Parcelas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCondicaoXparcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            BS_CondPGTO.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadCondPgto() { rcondpgto };
            if (rcondpgto != null)
                if (rcondpgto.lCondPgto_X_Parcelas.Count < 1)
                    rcondpgto.lCondPgto_X_Parcelas = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto_X_Parcelas.CriarParcelas(rcondpgto);
            BS_CondPGTO.ResetCurrentItem();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            if (pDados != null)
                this.DialogResult = DialogResult.OK;   
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void rateio_Leave(object sender, EventArgs e)
        {
           (BS_CondPgtoXParcelas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto_X_Parcelas).Pc_rateio = rateio.Value;
            decimal soma_rateio = decimal.Zero;
            rcondpgto.lCondPgto_X_Parcelas.ForEach(p => soma_rateio += p.Pc_rateio);
            if (soma_rateio != 100)
            {
                CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto_X_Parcelas.recalcularRateio(rcondpgto, Convert.ToInt32((BS_CondPgtoXParcelas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto_X_Parcelas).Id_parcela - 1));
                gCondicaoXparcelas.Refresh();
            }
        }

        private void TFCadCondPGTO_X_Parcelas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCondicaoXparcelas);
        }
    }
}