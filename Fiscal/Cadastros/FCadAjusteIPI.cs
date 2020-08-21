using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadAjusteIPI : FormCadPadrao.FFormCadPadrao
    {
        public TFCadAjusteIPI()
        {
            InitializeComponent();
            DTS = bsAjusteIPI;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("DEBITO", "D"));
            cbx.Add(new TDataCombo("CREDITO", "C"));

            tp_natureza.DataSource = cbx;
            tp_natureza.ValueMember = "Value";
            tp_natureza.DisplayMember = "Display";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_AjusteIPI.Gravar(bsAjusteIPI.Current as CamadaDados.Fiscal.TRegistro_AjusteIPI, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_AjusteIPI lista =
                CamadaNegocio.Fiscal.TCN_AjusteIPI.Buscar(cd_ajusteipi.Text,
                                                           cd_imposto.Text,
                                                           ds_ajusteipi.Text,
                                                           tp_natureza.SelectedValue != null ? tp_natureza.SelectedValue.ToString() : string.Empty,
                                                           ds_finalidade.Text,
                                                           null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsAjusteIPI.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsAjusteIPI.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_ajusteipi.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsAjusteIPI.AddNew();
                base.afterNovo();
                if (!(cd_ajusteipi.Focus()))
                    ds_ajusteipi.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsAjusteIPI.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_AjusteIPI.Excluir((bsAjusteIPI.Current as CamadaDados.Fiscal.TRegistro_AjusteIPI), null);
                    bsAjusteIPI.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Imposto|Imposto|200;" +
                              "a.CD_Imposto|Cd. Imposto|80";
            string vParam = "a.st_ipi|=|0";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                             new CamadaDados.Fiscal.TCD_CadImposto(), vParam);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text + ";" +
                            "a.st_ipi|=|0";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                              new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void TFCadAjusteIPI_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCadAjusteIPI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
