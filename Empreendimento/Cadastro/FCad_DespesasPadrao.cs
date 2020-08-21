using System;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class TFCad_DespesasPadrao : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_DespesasPadrao()
        {
            InitializeComponent();
            this.DTS = bsCadDespesa;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Gravar(bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCadDespesa.AddNew();
            base.afterNovo();
            if (!id_despesa.Focus())
                ds_despesa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_despesa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadDespesa.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadDespesa lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Busca(id_despesa.Text, ds_despesa.Text, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadDespesa.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCadDespesa.Clear();
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
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadDespesa.Excluir(bsCadDespesa.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadDespesa, null);
                    bsCadDespesa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void bbUnidade_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "a.ds_unidade|Unidade|100;" +
                "a.cd_unidade|Código|50;" +
                "a.sigla_unidade|UND|30",
                new Componentes.EditDefault[] { cd_unidade, ds_unidade, sg_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_unidade, ds_despesa, sg_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void TFCad_DespesasPadrao_Load(object sender, EventArgs e)
        {

        }
    }
}
