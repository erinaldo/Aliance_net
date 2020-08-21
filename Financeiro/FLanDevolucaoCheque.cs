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
    public partial class TFLanDevolucaoCheque : Form
    {
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TRegistro_DevolucaoCheque rDev
        {
            get
            {
                if (bsDevolucao.Current != null)
                    return (bsDevolucao.Current as CamadaDados.Financeiro.Titulo.TRegistro_DevolucaoCheque);
                else
                    return null;
            }
        }
        public TFLanDevolucaoCheque()
        {
            InitializeComponent();
            lCheques = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }

        private void TFLanDevolucaoCheque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheques);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsDevolucao.AddNew();
            (bsDevolucao.Current as CamadaDados.Financeiro.Titulo.TRegistro_DevolucaoCheque).lCheques = lCheques;
            bsDevolucao.ResetCurrentItem();
            dt_devolucao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dt_devolucao.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanDevolucaoCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanDevolucaoCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCheques);
        }
    }
}
