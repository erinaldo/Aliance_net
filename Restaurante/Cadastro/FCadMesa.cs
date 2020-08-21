using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using System.Windows.Forms;

namespace Restaurante.Cadastro
{
    public partial class FCadMesa : FormCadPadrao.FFormCadPadrao
    {
        public FCadMesa()
        {
            InitializeComponent();
        }

        private void FCadMesa_Load(object sender, EventArgs e)
        { 
        }
        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {

            if (pDados.validarCampoObrigatorio())
            {

                return TCN_Mesa.Gravar(bsMesa.Current as TRegistro_Mesa, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsMesa.AddNew();
            base.afterNovo();

        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsMesa.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_Mesa lista = TCN_Mesa.Buscar(editDefault3.Text, id_local.Text, editDefault2.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMesa.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsMesa.Clear();
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
                    (bsMesa.Current as TRegistro_Mesa).st_registro = "C";
                    TCN_Mesa.Gravar(bsMesa.Current as TRegistro_Mesa, null);
                    bsMesa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void TFCadCFGEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void pDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "a.ds_local|local|150;" +
                "a.id_local|Código|50",
                new Componentes.EditDefault[] { id_local, ds_local},
                new CamadaDados.Restaurante.Cadastro.TCD_Local(),
                string.Empty);
        }

        private void id_local_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.id_local|=|'" + id_local.Text.Trim() + "'", new Componentes.EditDefault[] { id_local, ds_local }, new CamadaDados.Restaurante.Cadastro.TCD_Local());
        }
    }
}
