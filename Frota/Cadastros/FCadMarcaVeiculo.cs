using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFCadMarcaVeiculo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMarcaVeiculo()
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
                return CamadaNegocio.Frota.Cadastros.TCN_CadMarcaVeiculo.GravarMarca(
                    bsMarcaVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadMarcaVeiculo, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Frota.Cadastros.TList_CadMarcaVeiculo lista =
                CamadaNegocio.Frota.Cadastros.TCN_CadMarcaVeiculo.Buscar(id_marca.Text,
                                                                         ds_marca.Text,           
                                                                         null);


            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMarcaVeiculo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsMarcaVeiculo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsMarcaVeiculo.AddNew();
            base.afterNovo();
            if (!id_marca.Focus())
                ds_marca.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsMarcaVeiculo.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_marca.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão da Marca?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Frota.Cadastros.TCN_CadMarcaVeiculo.DeletarMarca(
                        bsMarcaVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadMarcaVeiculo, null);
                    bsMarcaVeiculo.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadMarcaVeiculo_Load(object sender, EventArgs e)
        {
            this.pDados.set_FormatZero();
        }
    }
}
