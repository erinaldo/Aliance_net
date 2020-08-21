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
    public partial class TFCadUsuario_EtapaPed : Form
    {
        public string Login
        { get; set; }
        public List<CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa> lEtapaPed
        {
            get
            {
                if (bsEtapa.Count > 0)
                    return (bsEtapa.DataSource as CamadaDados.Faturamento.Cadastros.TList_CadEtapa).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFCadUsuario_EtapaPed()
        {
            InitializeComponent();
        }

        private void CadUsuario_EtapaPed_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEtapa.DataSource = new CamadaDados.Faturamento.Cadastros.TCD_CadEtapa().Select(
                                       new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_etapaped x " +
                                                            "where x.id_etapa = a.id_etapa" +
                                                            " and x.login = '" + Login.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsEtapa.Count > 0)
            {
                (bsEtapa.DataSource as CamadaDados.Faturamento.Cadastros.TList_CadEtapa).ForEach(p => p.St_processar = cbTodos.Checked);
                bsEtapa.ResetBindings(true);
            }
        }

        private void gContaGer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).St_processar =
                    !(bsEtapa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa).St_processar;
                bsEtapa.ResetCurrentItem();
            }
        }
    }
}
