using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadCargoFuncionario : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCargoFuncionario()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CargoFuncionario.Gravar(bsCargoFuncionario.Current as TRegistro_CargoFuncionario, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CargoFuncionario lista = TCN_CargoFuncionario.Buscar(id_cargo.Text,
                                                                       ds_cargo.Text,
                                                                       st_vendedor.Checked,
                                                                       null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    Lista = lista;
                    bsCargoFuncionario.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCargoFuncionario.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCargoFuncionario.AddNew();
                base.afterNovo();
                if (!id_cargo.Focus())
                    ds_cargo.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCargoFuncionario.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_cargo.Focus();
        }

        public override void excluirRegistro()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
                {
                    TCN_CargoFuncionario.Excluir(bsCargoFuncionario.Current as TRegistro_CargoFuncionario, null);
                    bsCargoFuncionario.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}
