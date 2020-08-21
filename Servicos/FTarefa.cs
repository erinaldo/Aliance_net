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
    public partial class TFTarefa : Form
    {
        private CamadaDados.Servicos.TRegistro_LanAtividades ratividade;
        public CamadaDados.Servicos.TRegistro_LanAtividades rAtividade
        {
            get
            {
                if (bsAtividade.Current != null)
                    return bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades;
                else
                    return null;
            }
            set { ratividade = value; }
        }
        public bool St_visualizar = false;
        public bool St_Bloqueio = false;
        public TFTarefa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(DS_Funcao.Text))
            {
                MessageBox.Show("Obrigatório informar Técnico!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(Ds_atividade.Text))
            {
                MessageBox.Show("Obrigatório informar Descrição Atividade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
                
        }
        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ID_Tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + ID_Tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                  new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao },
                                                  new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void TFTarefa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (St_visualizar)
            {
                ID_Tecnico.ReadOnly = true;
                Ds_atividade.ReadOnly = true;
                DT_Atividade.ReadOnly = true;
                DT_Prevista.ReadOnly = true;
                DS_Funcao.ReadOnly = true;
                Ds_observacao.ReadOnly = true;
                BB_Tecnico.Enabled = false;
                barraMenu.Visible = false;
                this.Text = "Pressione ESC para Sair.";
            }
            if (ratividade != null)
                bsAtividade.DataSource = new CamadaDados.Servicos.TList_LanAtividades() { ratividade };
            else
                bsAtividade.AddNew();
            DT_Atividade.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
            
            //Verificar se Usuario é o Usuario do lançamento da Atividade
            if (St_Bloqueio)
            {
                ID_Tecnico.Enabled = false;
                BB_Tecnico.Enabled = false;
                DT_Atividade.Enabled = false;
                DT_Prevista.Enabled = false;
            }

        }

        private void TFTarefa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6) || e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
