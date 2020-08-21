using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFListContaGer : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadContaGer> lContaGer
        {
            get
            {
                if (bsContaGer.Count > 0)
                    return (bsContaGer.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadContaGer).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListContaGer()
        {
            InitializeComponent();
        }

        private void TFListContaGer_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsContaGer.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_DIV_Usuario_X_ContaGer x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Login.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListContaGer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsContaGer.Count > 0)
            {
                (bsContaGer.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadContaGer).ForEach(p => p.St_processar = cbTodos.Checked);
                bsContaGer.ResetBindings(true);
            }
        }

        private void gContaGer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsContaGer.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContaGer).St_processar =
                    !(bsContaGer.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContaGer).St_processar;
                bsContaGer.ResetCurrentItem();
            }
        }
    }
}
