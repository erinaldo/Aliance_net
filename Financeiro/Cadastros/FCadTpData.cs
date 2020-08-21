using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCadTpData : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpData()
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
                return CamadaNegocio.Financeiro.Cadastros.TCN_TpData.Gravar(
                    bsTpData.Current as CamadaDados.Financeiro .Cadastros.TRegistro_TpData, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Financeiro.Cadastros.TList_TpData lista =
                CamadaNegocio.Financeiro.Cadastros.TCN_TpData.Buscar(Id_TpData.Text,
                                                                      Ds_TpData.Text,
                                                                      null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpData.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTpData.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsTpData.AddNew();
                base.afterNovo();
                if (Id_TpData.Enabled)
                    Id_TpData.Focus();
                else
                    Ds_TpData.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpData.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                Ds_TpData.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_TpData.Excluir(
                        bsTpData.Current as CamadaDados.Financeiro.Cadastros.TRegistro_TpData, null);
                    bsTpData.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}
