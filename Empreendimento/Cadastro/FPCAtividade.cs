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
    public partial class FPCAtividade : FormCadPadrao.FFormCadPadrao
    {
        public FPCAtividade()
        {
            InitializeComponent();
        }

        private void FPCAtividade_Load(object sender, EventArgs e)
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
            if (!cd_vendedor.Focus())
                editDefault1.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            editDefault1.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadAtividade.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadAtividade lista = CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Buscar(editDefault1.Text,string.Empty,null);

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
                    (bsCadAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade).Pc_margemcont = decimal.Zero;
                    CamadaNegocio.Empreendimento.Cadastro.TCN_Atividade.Gravar(bsCadAtividade.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadAtividade, null);
                    
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ID_ATIVIDADE|CD. Atividade|50;" +
                               "a.DS_ATIVIDADE|DS. Atividade|150",
                               new Componentes.EditDefault[] { editDefault1 },
                               new CamadaDados.Empreendimento.Cadastro.TCD_CadAtividade(),
                               string.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.ID_ATIVIDADE|=|" + editDefault1.Text,
               new Componentes.EditDefault[] { editDefault1 },
               new CamadaDados.Empreendimento.Cadastro.TCD_CadAtividade());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_atividade|Nome atividade|200;" +
                             "a.id_atividade|Cd. atividade|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, editDefault1 },
                new CamadaDados.Empreendimento.Cadastro.TCD_CadAtividade(),
               string.Empty);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {

            string vParam = "a.id_atividade|=|'" + cd_vendedor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, editDefault1 },
                                    new CamadaDados.Empreendimento.Cadastro.TCD_CadAtividade());
        }
    }
}
