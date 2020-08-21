using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class FCadAtividade : FormCadPadrao.FFormCadPadrao
    {
        public FCadAtividade()
        {
            InitializeComponent();
        }

        private void FCadAtividade_Load(object sender, EventArgs e)
        {
        }
        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Gravar(bsCadAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCadAtividade.AddNew();
            base.afterNovo();
            if (!editDefault1.Focus())
                editDefault2.Focus();
            
        }

        public override void afterAltera()
        {
            base.afterAltera();
            editDefault2.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            

            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadAtividade.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadAtividade lista = CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Buscar(editDefault1.Text, editDefault2.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadAtividade.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsCadAtividade.Clear();
                return lista.Count;
            }
            else

                return 0;

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Excluir(bsCadAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade, null);
                    bsCadAtividade.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void bnprojetobt_RefreshItems(object sender, EventArgs e)
        {

        }
         

        private void bnprojetobt_RefreshItems_1(object sender, EventArgs e)
        {

        }
         
         

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridDefault4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editDefault2.Text))
            {
                CamadaDados.Empreendimento.Cadastro.TList_CadAtividade tlist = new CamadaDados.Empreendimento.Cadastro.TList_CadAtividade();
                 
                tlist = CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Buscar(editDefault1.Text, string.Empty, null);
                if(tlist.Count > 0)
                    editDefault2.Text = tlist[0].Ds_atividade;
            }
        }
    }
}
