using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;

namespace Servicos.Cadastros
{
    public partial class TFCadVeiculoCliente : FormCadPadrao.FFormCadPadrao
    {
        public TFCadVeiculoCliente()
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
                return TCN_VeiculoCliente.Gravar(bsVeiculoCliente.Current as TRegistro_VeiculoCliente, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {

            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsVeiculoCliente.AddNew();
                base.afterNovo();
                CD_Clifor.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_Clifor.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_veiculo.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsVeiculoCliente.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_VeiculoCliente lista = TCN_VeiculoCliente.Buscar(CD_Clifor.Text,
                                                                   placaveiculo.Text,
                                                                   ds_veiculo.Text,
                                                                   ds_marca.Text,
                                                                   ds_observacao.Text,
                                                                   string.Empty,
                                                                   null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsVeiculoCliente.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsVeiculoCliente.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_VeiculoCliente.Excluir(bsVeiculoCliente.Current as TRegistro_VeiculoCliente, null);
                        bsVeiculoCliente.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch
                    {
                        MessageBox.Show("Não é possivel excluir veiculo com movimentação.\r\n" +
                                        "Altere o cadastro do veiculo e desative o mesmo para que não seja mais possivel movimentar o mesmo.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void bb_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFCadVeiculoCliente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCadVeiculoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
