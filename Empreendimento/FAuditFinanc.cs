using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;


namespace Empreendimento
{
    public partial class TFAuditFinanc : Form
    {
        public TFAuditFinanc()
        {
            InitializeComponent();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TList_RegLanDuplicata lDup = TCN_LanDuplicata.Busca(CD_Empresa.Text,
                                                                    nr_lancto.Text,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    false,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    "A",
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    true,
                                                                    0,
                                                                    string.Empty,
                                                                    null);
                //Buscr Centro Resultado
                lDup.ForEach(p => p.lCustoLancto = TCN_DuplicataXCCusto.BuscarCusto(p.Cd_empresa, p.Nr_lancto.ToString(), null));
                BS_Duplicata.DataSource = lDup;
            }
            else
            {

            }
        }
        
    }
}
