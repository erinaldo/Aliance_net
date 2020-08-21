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
    public partial class TFListaParcelasAgrupadas : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nr_lancto
        { get; set; }

        public TFListaParcelasAgrupadas()
        {
            InitializeComponent();
        }

        private void TFListaParcelasAgrupadas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_FIN_VincularDup x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctovinculado = a.nr_lancto " +
                                                            "and x.cd_parcelavinculado = a.cd_parcela " + 
                                                            "and x.cd_empresa = '" + Cd_empresa.Trim( ) + "' " +
                                                            "and x.nr_lancto = " + Nr_lancto + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
        }

        private void TFListaParcelasAgrupadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }
    }
}
