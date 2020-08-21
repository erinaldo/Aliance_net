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
    public partial class FCadEncargosFolha :  FormCadPadrao.FFormCadPadrao
    {
        public FCadEncargosFolha()
        {
            InitializeComponent();
        }

        private void FCadEncargosFolha_Load(object sender, EventArgs e)
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
                bsEncargofolha.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadEncargosFolha lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadEncargosFolha.Buscar(editDefault1.Text, editDefault2.Text, null);

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
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadEncargosFolha.Excluir(bsEncargofolha.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadEncargosFolha, null);
                    bsEncargofolha.RemoveCurrent();
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
