using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using System.Windows.Forms;

namespace Restaurante.Cadastro
{
    public partial class FCadLocalImpressora : FormCadPadrao.FFormCadPadrao
    {
        public FCadLocalImpressora()
        {
            InitializeComponent();
        }

        private void FCadLocalImpressora_Load(object sender, EventArgs e)
        {
            bsLocalImp.AddNew();
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("BEMATECH", "0"));
            CBox1.Add(new Utils.TDataCombo("ELGIN", "1"));
            CBox1.Add(new Utils.TDataCombo("EPSON", "2"));  
            comboBoxDefault1.DataSource = CBox1;
            comboBoxDefault1.DisplayMember = "Display";
            comboBoxDefault1.ValueMember = "Value";
            comboBoxDefault1.SelectedIndex = -1;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {

             
            if (pDados.validarCampoObrigatorio())
            {

                return TCN_LocalImp.Gravar(bsLocalImp.Current as TRegistro_LocalImp, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsLocalImp.AddNew();
            base.afterNovo();
            if (!editDefault1.Focus())
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
                bsLocalImp.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_LocalImp lista = TCN_LocalImp.Buscar(string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsLocalImp.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bsLocalImp.Clear();
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
                    TCN_LocalImp.Excluir(bsLocalImp.Current as TRegistro_LocalImp, null);
                    bsLocalImp.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void FCadLocalImpressora_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
