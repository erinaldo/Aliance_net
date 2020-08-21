using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadTipoTransporte : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTipoTransporte()
        {
            InitializeComponent();
            DTS = BS_CadTipoTransporte;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value,this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTipoTransporte.GravaCadTipoTransporte(BS_CadTipoTransporte.Current as TRegistro_CadTipoTransporte);
            else
                return "";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadTipoTransporte.AddNew();
                base.afterNovo();
                if(!id_tptransp.Focus())
                ds_tptransp.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                if (!id_tptransp.Focus())
                    ds_tptransp.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadTipoTransporte.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CadTipoTransporte lista = TCN_CadTipoTransporte.Busca(id_tptransp.Text.Trim() != "" ? Convert.ToDecimal(id_tptransp.Text) : 0, 
                                                                        ds_tptransp.Text.Trim(), cd_transportadora.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadTipoTransporte.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadTipoTransporte.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if (BS_CadTipoTransporte.Count > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadTipoTransporte.DeletaCadTipoTransporte(BS_CadTipoTransporte.Current as TRegistro_CadTipoTransporte);
                        BS_CadTipoTransporte.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
            }
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora, ds_transportadora }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_transportadora.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transportadora, ds_transportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFCadTipoTransporte_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}
