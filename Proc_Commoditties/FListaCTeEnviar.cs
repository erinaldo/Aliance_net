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
    public partial class TFListaCTeEnviar : Form
    {
        public string Cd_transportadora
        { get; set; }
        public List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lCte
        {
            get
            {
                if (bsCte.Count > 0)
                    return (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaCTeEnviar()
        {
            InitializeComponent();
        }

        private void TFListaCTeEnviar_Load(object sender, EventArgs e)
        {
            bsCte.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cd_transportadora.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_emissao",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_modelo",
                                        vOperador = "=",
                                        vVL_Busca = "'57'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctoctr = a.nr_lanctoctr)"
                                    }
                                }, 0, string.Empty);
        }

        private void gCTe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar =
                    !(bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar;
                bsCte.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsCte.Count > 0)
            {
                (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).ForEach(p => p.St_processar = cbTodos.Checked);
                bsCte.ResetBindings(true);
            }
        }
    }
}
