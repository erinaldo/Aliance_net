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
    public partial class FPCEncargo : FormCadPadrao.FFormCadPadrao
    {
        public FPCEncargo()
        {
            InitializeComponent();
        }

        private void FPCEncargo_Load(object sender, EventArgs e)
        {

        }
        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_CadEncargosFolha.Gravar(bsEncargofolha.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadEncargosFolha, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsEncargofolha.AddNew();
            base.afterNovo();
            if (!cd_vendedor.Focus())
                editFloat1.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            cd_vendedor.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsEncargofolha.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadEncargosFolha lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadEncargosFolha.Buscar(cd_vendedor.Text, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEncargofolha.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsEncargofolha.Clear();
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
                    (bsEncargofolha.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadEncargosFolha).Pc_encargo = decimal.Zero;
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadEncargosFolha.Gravar(bsEncargofolha.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadEncargosFolha, null);
                    
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void bbUnidade_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.id_encargo|CD. Encargo|50;" +
                               "a.ds_encargo|DS. Encargo|150",
                               new Componentes.EditDefault[] { cd_vendedor },
                               new CamadaDados.Empreendimento.Cadastro.TCD_CadEncargosFolha(),
                               string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.id_encargo|=|" + cd_vendedor.Text,
                new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Empreendimento.Cadastro.TCD_CadEncargosFolha());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Encargo|Nome Encargo|200;" +
                             "a.id_Encargo|Cd. Encargo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, editDefault1 },
                new CamadaDados.Empreendimento.Cadastro.TCD_CadEncargosFolha(),
               string.Empty);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {

            string vParam = "a.id_encargo|=|'" + cd_vendedor.Text.Trim() + "'" ;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, editDefault1 },
                                    new CamadaDados.Empreendimento.Cadastro.TCD_CadEncargosFolha());
        }

        private void editDefault1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cd_vendedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
