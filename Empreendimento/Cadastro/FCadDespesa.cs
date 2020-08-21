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
    public partial class FCadDespesa : FormCadPadrao.FFormCadPadrao
    {
        public FCadDespesa()
        {
            InitializeComponent();
        }

        private void FCadDespesa_Load(object sender, EventArgs e)
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
            if (!id.Focus())
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
                bsCadDespesa.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadDespesa lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Busca(id.Text, editDefault2.Text, null);

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
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Excluir(bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa, null);
                    bsCadDespesa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }
    }
}
