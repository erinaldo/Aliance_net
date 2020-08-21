using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;

namespace Frota.Cadastros
{
    public partial class TFCad_CfgMDFe : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_CfgMDFe()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PRODUÇÃO", "1"));
            cbx1.Add(new Utils.TDataCombo("HOMOLOGAÇÃO", "2"));
            tp_ambiente.DataSource = cbx1;
            tp_ambiente.ValueMember = "Value";
            tp_ambiente.DisplayMember = "Display";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CfgMDFe.Gravar(bsMDFe.Current as TRegistro_CfgMDFe, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CfgMDFe lista = TCN_CfgMDFe.Buscar(cd_empresa.Text,
                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMDFe.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsMDFe.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsMDFe.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            path_schemas.Focus();
            bb_empresa.Enabled = false;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsMDFe.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CfgMDFe.Excluir(bsMDFe.Current as TRegistro_CfgMDFe, null);
                    bsMDFe.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_pathschemas_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
            {
                if (fbdPath.ShowDialog() == DialogResult.OK)
                    path_schemas.Text = fbdPath.SelectedPath.Trim();
            }
        }
    }
}
