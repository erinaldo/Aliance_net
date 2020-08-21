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
    public partial class TFListGrupoMenu : Form
    {
        public List<CamadaDados.Diversos.TRegistro_CadUsuario> lGrupo
        {
            get
            {
                if (bsGrupo.Count > 0)
                    return (bsGrupo.DataSource as CamadaDados.Diversos.TList_CadUsuario).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public string Login
        { get; set; }

        public TFListGrupoMenu()
        {
            InitializeComponent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListGrupoMenu_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsGrupo.DataSource = new CamadaDados.Diversos.TCD_CadUsuario().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_registro",
                                            vOperador = "=",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Grupos x " +
                                                        "where x.logingrp = a.login " +
                                                        "and x.loginusr = '" + Login.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsGrupo.Count > 0)
            {
                (bsGrupo.DataSource as CamadaDados.Diversos.TList_CadUsuario).ForEach(p => p.St_processar = cbTodos.Checked);
                bsGrupo.ResetBindings(true);
            }
        }

        private void gGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsGrupo.Current as CamadaDados.Diversos.TRegistro_CadUsuario).St_processar =
                    !(bsGrupo.Current as CamadaDados.Diversos.TRegistro_CadUsuario).St_processar;
                bsGrupo.ResetCurrentItem();
            }
        }

        private void TFListGrupoMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
