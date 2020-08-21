using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFListaHistoricos : Form
    {
        public string Tp_mov
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico> lHist
        {
            get
            {
                if (bsHistorico.Count > 0)
                    return (bsHistorico.List as CamadaDados.Financeiro.Cadastros.TList_CadHistorico).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaHistoricos()
        {
            InitializeComponent();
            this.Tp_mov = string.Empty;
        }

        private void TFListaHistoricos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar listagem de historicos
            Utils.TpBusca[] filtro = new Utils.TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.cd_grupocf, '')";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "''";
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'C'";
            if(!string.IsNullOrEmpty(Tp_mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_mov.Trim() + "'";
            }

            bsHistorico.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico().Select(filtro, 0, string.Empty);
        }

        private void gHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico).St_processar =
                    !(bsHistorico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico).St_processar;
                bsHistorico.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsHistorico.Count > 0)
            {
                (bsHistorico.List as CamadaDados.Financeiro.Cadastros.TList_CadHistorico).ForEach(p => p.St_processar = cbTodos.Checked);
                bsHistorico.ResetBindings(true);
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

        private void TFListaHistoricos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
