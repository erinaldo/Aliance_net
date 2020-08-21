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
    public partial class TFCadAjusteICMS : FormCadPadrao.FFormCadPadrao
    {
        public TFCadAjusteICMS()
        {
            InitializeComponent();
            DTS = bsAjusteICMS;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Fiscal.TCN_AjusteICMS.Gravar(bsAjusteICMS.Current as CamadaDados.Fiscal.TRegistro_AjusteICMS, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Fiscal.TList_AjusteICMS lista =
                CamadaNegocio.Fiscal.TCN_AjusteICMS.Buscar(cd_ajuste.Text,
                                                           cd_imposto.Text,
                                                           ds_ajuste.Text,
                                                           null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsAjusteICMS.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsAjusteICMS.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_ajuste.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                bsAjusteICMS.AddNew();
                base.afterNovo();
                if (!(cd_ajuste.Focus()))
                    ds_ajuste.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                bsAjusteICMS.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_AjusteICMS.Excluir((bsAjusteICMS.Current as CamadaDados.Fiscal.TRegistro_AjusteICMS), null);
                    bsAjusteICMS.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Imposto|Imposto|200;" +
                              "a.CD_Imposto|Cd. Imposto|80";
            string vParam = "a.st_icms|=|0";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                             new CamadaDados.Fiscal.TCD_CadImposto(), vParam);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text + ";" +
                            "a.st_icms|=|0";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                              new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void TFCadAjusteICMS_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCadAjusteICMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
