using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento.Cadastro;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class FCadRequisito : FormCadPadrao.FFormCadPadrao
    {
        public FCadRequisito()
        {
            InitializeComponent();
        }

        private void FCadRequisito_Load(object sender, EventArgs e)
        {

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Gravar(bsRequisito.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsRequisito.AddNew();
            base.afterNovo();
            if (!id_requisito.Focus())
                id_requisito.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            id_requisito.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsRequisito.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Buscar(id_requisito.Text, string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsRequisito.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsRequisito.Clear();
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
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadRequisitos.Excluir(bsRequisito.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadRequisitos, null);
                    bsRequisito.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {

        }
        

        private void TFCadCFGEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
        
    }
}
