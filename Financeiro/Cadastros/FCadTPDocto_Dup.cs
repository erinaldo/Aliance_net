using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using Utils;
namespace Financeiro.Cadastros
{
    public partial class TFCadTPDocto_Dup : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTPDocto_Dup()
        {
            InitializeComponent();
            DTS = BS_TpDocumentoDup;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTpDoctoDup.gravarDocto(BS_TpDocumentoDup.Current as TRegistro_CadTpDoctoDup, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTpDoctoDup lista = TCN_CadTpDoctoDup.Buscar(Tp_Docto.Text, 
                                                                 DS_TpDocto.Text,
                                                                 string.Empty,
                                                                 null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TpDocumentoDup.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TpDocumentoDup.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_TpDocumentoDup.AddNew();
                base.afterNovo();
                if (!Tp_Docto.Focus())
                    DS_TpDocto.Focus();
                
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!Tp_Docto.Focus())
                    DS_TpDocto.Focus();
            }
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadTpDoctoDup.deletarDocto(BS_TpDocumentoDup.Current as TRegistro_CadTpDoctoDup, null);
                        BS_TpDocumentoDup.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void TFCadTPDocto_Dup_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_tpdoctoDup);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadTPDocto_Dup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_tpdoctoDup);
        }
    }
}

