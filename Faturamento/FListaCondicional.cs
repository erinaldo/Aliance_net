using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFListaCondicional : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_Condicional> lCondicional
        {
            get
            {
                if (bsCondicional.Count > 0)
                    return (bsCondicional.List as CamadaDados.Faturamento.PDV.TList_Condicional).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public TFListaCondicional()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsCondicional.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Condicional.Buscar(cd_empresa.Text,
                                                                                            id_condicional.Text,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            "'A'",
                                                                                            false,
                                                                                            false,
                                                                                            false,
                                                                                            null);
        }

        private void TFListaCondicional_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsCondicional.Count > 0)
            {
                (bsCondicional.List as CamadaDados.Faturamento.PDV.TList_Condicional).ForEach(p => p.St_processar = cbProcessar.Checked);
                bsCondicional.ResetBindings(true);
            }
        }

        private void gCondicional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_processar =
                    !(bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).St_processar;
                bsCondicional.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaCondicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bsCondicional_PositionChanged(object sender, EventArgs e)
        {
            if (bsCondicional.Current != null)
            {
                (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).lItens =
                    CamadaNegocio.Faturamento.PDV.TCN_ItensCondicional.Buscar((bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Cd_empresa,
                                                                              (bsCondicional.Current as CamadaDados.Faturamento.PDV.TRegistro_Condicional).Id_condicionalstr,
                                                                              null);
                bsCondicional.ResetCurrentItem();
            }
        }
    }
}
