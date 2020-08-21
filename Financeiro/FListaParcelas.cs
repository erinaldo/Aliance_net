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
    public partial class TFListaParcelas : Form
    {
        public string Cd_clifor
        { get; set; }

        public TFListaParcelas()
        {
            InitializeComponent();
        }

        private void TFListaParcelas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_clifor.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "and CONVERT(datetime, floor(convert(decimal(30,10), DATEADD(day, c.diascarenciadebvencto, a.DT_Vencto))))",
                                            vOperador = "<",
                                            vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
        }
    }
}
