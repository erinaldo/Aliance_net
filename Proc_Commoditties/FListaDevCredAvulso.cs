using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFListaDevCredAvulso : Form
    {
        public string Id_caixa
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_Caixa_X_DevCredAvulso rDev
        {
            get
            {
                if (bsCaixaDevCredAvulso.Current != null)
                    return bsCaixaDevCredAvulso.Current as CamadaDados.Faturamento.PDV.TRegistro_Caixa_X_DevCredAvulso;
                else return null;
            }
        }

        public TFListaDevCredAvulso()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListaDevCredAvulso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsCaixaDevCredAvulso.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_DevCredAvulso.Buscar(string.Empty,
                                                                                                             Id_caixa,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             null);
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaDevCredAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
