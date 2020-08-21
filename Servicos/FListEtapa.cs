using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFListEtapa : Form
    {
        public string Id_os
        { get; set; }
        public string TP_Ordem
        { get; set; }
        public List<CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem> lEtapa
        {
            get
            {
                if (bsEtapa.Count > 0)
                    return (bsEtapa.DataSource as CamadaDados.Servicos.Cadastros.TList_EtapaOrdem).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFListEtapa()
        {
            InitializeComponent();
        }

        private void TFListEtapa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsEtapa.DataSource = new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                   new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                                        "where x.ID_Etapa = a.ID_Etapa " +
                                                        "and x.id_os = '" + Id_os.Trim() + "' )"
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
                (bsEtapa.DataSource as CamadaDados.Servicos.Cadastros.TList_EtapaOrdem).ForEach(p => p.St_processar = cbTodos.Checked);
                bsEtapa.ResetBindings(true);
            }
        }

        private void gEtapa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsEtapa.Current as CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem).St_processar =
                    !(bsEtapa.Current as CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem).St_processar;
                bsEtapa.ResetCurrentItem();
            }
        }

        private void TFListEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
