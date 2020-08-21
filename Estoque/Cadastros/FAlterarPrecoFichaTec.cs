using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFAlterarPrecoFichaTec : Form
    {
        public bool St_atualizar = false;
        public string pCd_produto
        { get; set; } = string.Empty;
        public string pDs_produto
        { get; set; } = string.Empty;
        public string pCd_tabelapreco
        { get; set; } = string.Empty;
        public string pDs_tabelapreco
        { get; set; } = string.Empty;
        public List<CamadaDados.Estoque.Cadastros.TRegistro_PrecoItemFicha> lficha
        { get; set; } = new CamadaDados.Estoque.Cadastros.TList_PrecoItemFicha();
        public CamadaDados.Estoque.Cadastros.TList_PrecoItemFicha lFicha
        {
            get
            {
                if (bsFicha.Count > 0)
                    return bsFicha.DataSource as CamadaDados.Estoque.Cadastros.TList_PrecoItemFicha;
                else
                    return null;
            }
        } 

        public TFAlterarPrecoFichaTec()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            gFicha.EndEdit();
            DialogResult = DialogResult.OK;
        }

        private void gFicha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != (char)44)
                e.Handled = true;
            else if (e.KeyChar == ',')
                if (((TextBox)sender).Text.Contains(","))
                    e.Handled = true; 
        }

        private void gFicha_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gFicha[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gFicha.EndEdit();
        }

        private void TFAlterarPrecoFichaTec_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (lficha.Count > 0 && !St_atualizar)
                bsFicha.DataSource = lficha;
            else if (St_atualizar)
            {
                //Buscar Preços item gravados
                bsFicha.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_PrecoItemFicha.Buscar(pCd_produto,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               null);
                //Buscar Preços dos itens ainda não gravados
                lficha.ForEach(p =>
                (bsFicha.DataSource as CamadaDados.Estoque.Cadastros.TList_PrecoItemFicha).Add(p));
                bsFicha.ResetBindings(true);
            }
            
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFAlterarPrecoFichaTec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
