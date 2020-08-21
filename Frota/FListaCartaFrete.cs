using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFListaCartaFrete : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_motorista
        { get; set; }

        public List<CamadaDados.Frota.TRegistro_CartaFrete> lCarta
        {
            get
            {
                if (bsCartaFrete.Count > 0)
                    return (bsCartaFrete.List as CamadaDados.Frota.TList_CartaFrete).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaCartaFrete()
        {
            InitializeComponent();
        }

        private void TFListaCartaFrete_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar carta frete
            bsCartaFrete.DataSource = new CamadaDados.Frota.TCD_CartaFrete().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_motorista",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Cd_motorista.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_acerto",
                                                    vOperador = "is",
                                                    vVL_Busca = "null"
                                                }
                                            }, 0, string.Empty);
        }

        private void gCartaFrete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).St_processar =
                    !(bsCartaFrete.Current as CamadaDados.Frota.TRegistro_CartaFrete).St_processar;
                bsCartaFrete.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsCartaFrete.Count > 0)
            {
                (bsCartaFrete.List as CamadaDados.Frota.TList_CartaFrete).ForEach(p => p.St_processar = cbTodos.Checked);
                bsCartaFrete.ResetBindings(true);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
