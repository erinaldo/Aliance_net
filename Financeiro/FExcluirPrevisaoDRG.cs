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
    public partial class TFExcluirPrevisaoDRG : Form
    {
        public TFExcluirPrevisaoDRG()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterBusca()
        {
            bsProvisaoDRG.DataSource =
                CamadaNegocio.Financeiro.ProvisaoDRG.TCN_LanProvisaoDRG.Buscar(CD_CentroResultBusca.Text,
                                                                               cd_empresa_busca.Text,
                                                                               ano.Value.Year,
                                                                               cbxMesBusca.SelectedIndex,
                                                                               0,
                                                                               string.Empty);
            bsProvisaoDRG.ResetCurrentItem();
        }

        private void afterExclui()
        {
            if ((bsProvisaoDRG.DataSource as CamadaDados.Financeiro.ProvisaoDRG.TList_LanProvisaoDRG).Exists(p => p.St_processar))
            {

                if (MessageBox.Show("Confirma a exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        (bsProvisaoDRG.DataSource as CamadaDados.Financeiro.ProvisaoDRG.TList_LanProvisaoDRG).FindAll(p => p.St_processar).ForEach(p =>
                         {
                             CamadaNegocio.Financeiro.ProvisaoDRG.TCN_LanProvisaoDRG.Excluir(p, null);
                         });
                        MessageBox.Show("Provisão(s) excluída(s) com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
            }
            else
                MessageBox.Show("Selecione uma provisão para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFExcluirPrevisaoDRG_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbxMesBusca.SelectedIndex = 0;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFExcluirPrevisaoDRG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsProvisaoDRG.Count > 0)
            {
                (bsProvisaoDRG.DataSource as CamadaDados.Financeiro.ProvisaoDRG.TList_LanProvisaoDRG).ForEach(p => p.St_processar = cbTodos.Checked);
                bsProvisaoDRG.ResetBindings(true);
            }
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsProvisaoDRG.Current as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).St_processar =
                    !(bsProvisaoDRG.Current as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).St_processar;
                bsProvisaoDRG.ResetCurrentItem();
            }
        }
    }
}
