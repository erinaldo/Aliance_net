using System;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Duplicata;

namespace Servicos
{
    public partial class TFListaDuplicata : Form
    {
        public string Cd_empresa { get; set; }
        public string Cd_clifor { get; set; }
        public TRegistro_LanDuplicata rDup
        {
            get
            {
                if (bsCarne.Current != null)
                    return bsCarne.Current as TRegistro_LanDuplicata;
                else return null;
            }
        }
        public TFListaDuplicata()
        {
            InitializeComponent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFListaDuplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFListaDuplicata_Load(object sender, EventArgs e)
        {
            bsCarne.DataSource = new TCD_LanDuplicata().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "g.TP_Mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_clifor.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
        }
    }
}
