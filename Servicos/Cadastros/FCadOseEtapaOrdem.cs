using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;
using Utils;

namespace Servico.Cadastros
{
    public partial class TFCadOseEtapaOrdem : FormCadPadrao.FFormCadPadrao
    {
        public TFCadOseEtapaOrdem()
        {
            InitializeComponent();
            DTS = BS_CadOseEtapaOrdem;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_EtapaOrdem.Gravar(BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
        if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            BS_CadOseEtapaOrdem.AddNew();
            base.afterNovo();
            if (!id_etapa.Focus())
                Ds_etapa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!id_etapa.Focus())
                    Ds_etapa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadOseEtapaOrdem.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_EtapaOrdem lista = TCN_EtapaOrdem.Buscar(id_etapa.Text,
                                                           Ds_etapa.Text,
                                                           null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadOseEtapaOrdem.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadOseEtapaOrdem.Clear();

                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_EtapaOrdem.Excluir(BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem, null);
                    BS_CadOseEtapaOrdem.RemoveCurrent();
                    pDados.LimparRegistro();
                }
            }
        }

        public override void afterGrava()
        {
            base.afterGrava();
            validaChk();
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        private void St_IniciarOs_Click(object sender, EventArgs e)
        {
            if (St_IniciarOs.Checked)
            {
                St_FinalizarOs.Checked = false;
                (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_finalizarOS = "N";
            }
            else
                if (St_FinalizarOs.Checked)
                {
                    St_IniciarOs.Checked = false;
                    (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_finalizarOS = "S"; 
                }
        }

        private void St_FinalizarOs_Click(object sender, EventArgs e)
        {           
                if (St_FinalizarOs.Checked)
                {
                    St_IniciarOs.Checked = false;
                    (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_iniciarOS = "N";
                }
             else
                    if (St_IniciarOs.Checked)
                    {
                        St_FinalizarOs.Checked = false;
                        (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_iniciarOS = "S";
                    }
           
        }

        private void validaChk()
        {
            if ((St_FinalizarOs.Checked == false) && (St_IniciarOs.Checked == false))
            {
                (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_iniciarOS = "N";
                (BS_CadOseEtapaOrdem.Current as TRegistro_EtapaOrdem).St_finalizarOS = "N";
            }
        }

        private void BS_CadOseEtapaOrdem_PositionChanged(object sender, EventArgs e)
        {
            BS_CadOseEtapaOrdem.ResetBindings(true);
        }

        private void TFCadOseEtapaOrdem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_etapaOrdem);
            pDetalhes.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadOseEtapaOrdem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_etapaOrdem);
        }
    }
}
