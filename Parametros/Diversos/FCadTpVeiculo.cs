using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadTpVeiculo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpVeiculo()
        {
            InitializeComponent();
            DTS = BS_TipoVeiculo;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("TRAÇÃO", "T"));
            cbx.Add(new TDataCombo("REBOQUE", "R"));
            tp_veiculo.DataSource = cbx;
            tp_veiculo.DisplayMember = "Display";
            tp_veiculo.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("NÃO APLICAVEL", "00"));
            cbx1.Add(new TDataCombo("TRUCK", "01"));
            cbx1.Add(new TDataCombo("TOCO", "02"));
            cbx1.Add(new TDataCombo("CAVALO MECANICO", "03"));
            cbx1.Add(new TDataCombo("VAN", "04"));
            cbx1.Add(new TDataCombo("UTILITARIO", "05"));
            cbx1.Add(new TDataCombo("OUTROS", "06"));
            tp_rodado.DataSource = cbx1;
            tp_rodado.DisplayMember = "Display";
            tp_rodado.ValueMember = "Value";
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            TList_CadTpVeiculo lista = TCN_CadTpVeiculo.Busca(cd_tpveiculo.Text.Trim(),
                                                              DS_TpVeiculo.Text.Trim(),
                                                              tp_veiculo.SelectedValue != null ? tp_veiculo.SelectedValue.ToString() : string.Empty,
                                                              tp_rodado.SelectedValue != null ? tp_rodado.SelectedValue.ToString(): string.Empty,
                                                              null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_TipoVeiculo.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_TipoVeiculo.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTpVeiculo.GravarVeiculo(BS_TipoVeiculo.Current as TRegistro_CadTpVeiculo, null);
            else
                return string.Empty;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit)
            {
                if (!cd_tpveiculo.Focus())
                    DS_TpVeiculo.Focus();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_TipoVeiculo.AddNew();
                base.afterNovo();
                if(!cd_tpveiculo.Focus())
                DS_TpVeiculo.Focus();
            }
        }
        
        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_TipoVeiculo.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadTpVeiculo.DeletarVeiculo(BS_TipoVeiculo.Current as TRegistro_CadTpVeiculo, null);
                    BS_TipoVeiculo.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadTpVeiculo_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}

