using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadTrans_X_UnidPag : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTrans_X_UnidPag()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return CamadaNegocio.PostoCombustivel.Cadastros.TCN_Trans_X_UnidPag.Gravar(
                    bsTrans_X_UnidPag.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_Trans_X_UnidPag, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.PostoCombustivel.Cadastros.TList_Trans_X_UnidPag lista =
                CamadaNegocio.PostoCombustivel.Cadastros.TCN_Trans_X_UnidPag.Buscar(CD_Transportadora.Text,
                                                                                    CD_UnidPag.Text,
                                                                                    null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTrans_X_UnidPag.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTrans_X_UnidPag.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsTrans_X_UnidPag.AddNew();
                base.afterNovo();
                CD_Transportadora.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTrans_X_UnidPag.RemoveCurrent();
        }

        public override void afterAltera()
        {

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_Trans_X_UnidPag.Excluir(
                        bsTrans_X_UnidPag.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_Trans_X_UnidPag, null);
                    bsTrans_X_UnidPag.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void CD_Transportadora_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Transportadora.Text.Trim() + "'" +
                                                    ";isnull(a.st_transportadora, 'N')|=|'S'",
                                                   new Componentes.EditDefault[] { CD_Transportadora, NM_Transportadora },
                                                   new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Transportadora, NM_Transportadora }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void CD_UnidPag_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_UnidPag.Text.Trim() + "'",
                                                  new Componentes.EditDefault[] { CD_UnidPag, NM_UnidPag },
                                                  new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_unidpag_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_UnidPag, NM_UnidPag }, string.Empty);
        }

        private void TFCadTrans_X_UnidPag_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }
    }
}
