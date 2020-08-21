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
    public partial class FCadPCDespesa : FormCadPadrao.FFormCadPadrao
    {
        public FCadPCDespesa()
        {
            InitializeComponent();
        }

        private void FCadPCDespesa_Load(object sender, EventArgs e)
        {

        }
        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Gravar(bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCadDespesa.AddNew();
            base.afterNovo();
            //if (!.Focus())
                editFloat3.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            editFloat3.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadDespesa.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadDespesa lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Busca(cd_vendedor.Text, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadDespesa.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsCadDespesa.Clear();
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
                    (bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa).Pc_margemcont = decimal.Zero;
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Gravar(bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa, null);
                    
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {

            string vColunas = "a.ds_despesa|Nome despesa|200;" +
                              "a.id_despesa|Cd. despesa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor,editDefault1 },
                new CamadaDados.Empreendimento.Cadastro.TCD_CadDespesa(),
               string.Empty);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|'" + cd_vendedor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, editDefault1 },
                                    new CamadaDados.Empreendimento.Cadastro.TCD_CadDespesa());
        }
    }
}
