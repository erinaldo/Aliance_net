using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca; 
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Restaurante.Cadastro
{
    public partial class FProtocoloBalanca : FormCadPadrao.FFormCadPadrao
    {
        public FProtocoloBalanca()
        {
            InitializeComponent();
        }

        private void FProtocoloBalanca_Load(object sender, EventArgs e)
        {

        }
         

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return TCN_CadProtocolo.Gravar(bSource.Current as TRegistro_CadProtocolo, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_RegCadProtocolo lista = TCN_CadProtocolo.Busca(CD_Protocolo.Text,
                                                                 DS_Protocolo.Text,
                                                                 string.Empty,
                                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bSource.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                    bSource.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bSource.AddNew();
                base.afterNovo();
                if (!(CD_Protocolo.Focus()))
                    DS_Protocolo.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bSource.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            DS_Protocolo.Focus();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadProtocolo.Excluir(bSource.Current as TRegistro_CadProtocolo, null);
                    bSource.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(Parametros.Diversos.TFCadTerminal_X_Protocolo ae = new Parametros.Diversos.TFCadTerminal_X_Protocolo())
            {
                if(DialogResult.OK == ae.ShowDialog())
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FTesteBalanca a = new FTesteBalanca())
            {
                a.rProt = (bSource.Current as CamadaDados.Diversos.TRegistro_CadProtocolo);
                a.vl_unit = 10;
                a.ShowDialog();
            }
        }
    }
}
