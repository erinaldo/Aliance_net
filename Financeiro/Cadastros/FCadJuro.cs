using System;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadJuro : FormCadPadrao.FFormCadPadrao
    {
        public TFCadJuro()
        {
            InitializeComponent();
            DTS = bsJuro;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (rbSimples.Focused)
                    (bsJuro.Current as TRegistro_CadJuro).Tp_juro = "S";
                if (rbComposto.Focused)
                    (bsJuro.Current as TRegistro_CadJuro).Tp_juro = "C";
                return TCN_CadJuro.GravarJuro(bsJuro.Current as TRegistro_CadJuro, null);
            }
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
                bsJuro.AddNew();
            base.afterNovo();
            if (!CD_Juro.Focus())
                DS_Juro.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                DS_Juro.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsJuro.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CadJuro lista = TCN_CadJuro.Buscar(CD_Juro.Text,
                                                     DS_Juro.Text,
                                                     TP_Juro.NM_Valor,
                                                    0, string.Empty);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsJuro.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsJuro.Clear();
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
                    try
                    {
                        TCN_CadJuro.DeletarJuro(bsJuro.Current as TRegistro_CadJuro, null);
                        bsJuro.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void TFCadJuro_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadJuro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

