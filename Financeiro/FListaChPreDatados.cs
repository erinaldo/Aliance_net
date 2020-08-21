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
    public partial class TFListaChPreDatados : Form
    {
        public string Nm_clifor
        { get; set; }

        public TFListaChPreDatados()
        {
            InitializeComponent();
        }

        private void TFListaChPreDatados_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsCheque.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.nomeclifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Nm_clifor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_titulo",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.status_compensado, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'N'"
                                        }
                                    }, 0, string.Empty, string.Empty);
        }
    }
}
