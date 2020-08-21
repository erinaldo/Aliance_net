using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;

namespace Restaurante.Cadastro
{
    public partial class FCadLocal : FormCadPadrao.FFormCadPadrao
    {
        public FCadLocal()
        {
            InitializeComponent();
        }

        private void FCadLocal_Load(object sender, EventArgs e)
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

                return TCN_Local.Gravar(bsLocal.Current as TRegistro_Local, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsLocal.AddNew();
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
                bsLocal.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_Local lista = TCN_Local.Buscar(id_local.Text,ds_local.Text,string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsLocal.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsLocal.Clear();
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
                    TCN_Local.Excluir(bsLocal.Current as TRegistro_Local, null);
                    bsLocal.RemoveCurrent();
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
    }
}
