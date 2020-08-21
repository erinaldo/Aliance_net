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
    public partial class TFListTpPesagem : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Balanca.Cadastros.TRegistro_CadTpPesagem> lPesagem
        {
            get
            {
                if (bsTpPesagem.Count > 0)
                    return (bsTpPesagem.List as CamadaDados.Balanca.Cadastros.TList_CadTpPesagem).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListTpPesagem()
        {
            InitializeComponent();
        }

        private void TFListTpPesagem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsTpPesagem.DataSource = new CamadaDados.Balanca.Cadastros.TCD_CadTpPesagem().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpPesagem x " +
                                                            "where x.tp_pesagem = a.tp_pesagem " +
                                                            "and x.login = '" + Login.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListTpPesagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTpPesagem.Count > 0)
            {
                (bsTpPesagem.List as CamadaDados.Balanca.Cadastros.TList_CadTpPesagem).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTpPesagem.ResetBindings(true);
            }
        }

        private void gTpPesagem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTpPesagem.Current as CamadaDados.Balanca.Cadastros.TRegistro_CadTpPesagem).St_processar =
                    !(bsTpPesagem.Current as CamadaDados.Balanca.Cadastros.TRegistro_CadTpPesagem).St_processar;
                bsTpPesagem.ResetCurrentItem();
            }
        }
    }
}
