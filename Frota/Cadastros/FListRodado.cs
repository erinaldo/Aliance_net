using CamadaDados.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFListRodado : Form
    {
        public string Id_veiculo
        { get; set; }
        public List<CamadaDados.Frota.Cadastros.TRegistro_Rodado> llRodado
        {
            get
            {
                if (bsRodado.Count > 0)
                    return (bsRodado.DataSource as TList_Rodado);
                else return null;
            }
        }

        public TFListRodado()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsRodado.Count > 0)
                if ((bsRodado.DataSource as CamadaDados.Frota.Cadastros.TList_Rodado).Exists(p => p.St_processar))
                    DialogResult = DialogResult.OK;
        }

        private void TFListRodado_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsRodado.DataSource = new CamadaDados.Frota.Cadastros.TCD_Rodado().Select(null, 0, string.Empty);
            var listaRodadoSemVeiculo = new CamadaDados.Frota.Cadastros.TCD_Rodado().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "not exists",
                                                        vVL_Busca = "(select 1 from TB_FRT_RodadoVeic x " +
                                                                    "where x.id_rodado = a.id_rodado " +
                                                                    "and x.id_veiculo = '" + Id_veiculo.Trim() + "')"
                                                    }
                                                }, 0, string.Empty);
            (bsRodado.DataSource as TList_Rodado).ForEach(p =>
            {
                if (listaRodadoSemVeiculo.ToList().Exists(x => x.Id_rodado.Equals(p.Id_rodado)))
                    p.St_processar = false;
            });
            bsRodado.ResetBindings(true);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsRodado.Count > 0)
            {
                (bsRodado.DataSource as CamadaDados.Frota.Cadastros.TList_Rodado).ForEach(p => p.St_processar = cbTodos.Checked);
                bsRodado.ResetBindings(true);
            }
        }

        private void gRodado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsRodado.Current as CamadaDados.Frota.Cadastros.TRegistro_Rodado).St_processar =
                    !(bsRodado.Current as CamadaDados.Frota.Cadastros.TRegistro_Rodado).St_processar;
                bsRodado.ResetCurrentItem();
            }
        }

        private void TFListRodado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
