using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Restaurante
{
    public partial class TFHoraBoliche : Form
    {
        Utils.TTpModo modo = new Utils.TTpModo();
        public TFHoraBoliche()
        {
            InitializeComponent();
            controlButtons(Utils.TTpModo.tm_Standby);
            ArrayList cBox = new ArrayList();
            cBox.Add(new TDataCombo("SEGUNDA", "2"));
            cBox.Add(new TDataCombo("TERÇA", "3"));
            cBox.Add(new TDataCombo("QUARTA", "4"));
            cBox.Add(new TDataCombo("QUINTA", "5"));
            cBox.Add(new TDataCombo("SEXTA", "6"));
            cBox.Add(new TDataCombo("SÁBADO", "7"));
            cBox.Add(new TDataCombo("DOMINGO", "1"));
            cbDias.DataSource = cBox;
            cbDias.DisplayMember = "Display";
            cbDias.ValueMember = "Value";
        }

        #region Métodos
        private void controlButtons(Utils.TTpModo tipo)
        {
            if (tipo == Utils.TTpModo.tm_Standby)
                dataGridDefault1.Enabled = true;
            else
                dataGridDefault1.Enabled = false;

            if (tipo == Utils.TTpModo.tm_Standby)
            {
                bb_novo_abastecimento.Enabled = true;
                bb_alterar_abastecimento.Enabled = true;
                bb_excluir_abastecimento.Enabled = true;
                bb_gravar_abastecimento.Enabled = false;
                pnListagem.Enabled = false;
            }
            if (tipo == Utils.TTpModo.tm_Edit)
            {
                bb_novo_abastecimento.Enabled = false;
                bb_alterar_abastecimento.Enabled = false;
                bb_excluir_abastecimento.Enabled = false;
                bb_gravar_abastecimento.Enabled = true;
                pnListagem.Enabled = true;
            }
            if (tipo == Utils.TTpModo.tm_Insert)
            {
                pnListagem.LimparRegistro();
                bb_novo_abastecimento.Enabled = false;
                bb_alterar_abastecimento.Enabled = false;
                bb_excluir_abastecimento.Enabled = false;
                bb_gravar_abastecimento.Enabled = true;
                pnListagem.Enabled = true;
            }
            modo = tipo;
        }

        private void afterAlterar()
        {
            if (bsHoraBoliche.Current != null)
                controlButtons(Utils.TTpModo.tm_Edit);
        }

        private void afterExcluir()
        {
            if (bsHoraBoliche.Current != null)
            {
                CamadaNegocio.Restaurante.TCN_HoraBoliche.Excluir(bsHoraBoliche.Current as CamadaDados.Restaurante.TRegistro_HoraBoliche, null);
                afterBuscar();
            }
        }

        private void afterBuscar()
        {
            controlButtons(TTpModo.tm_Standby);
            pnListagem.LimparRegistro();
            bsHoraBoliche.DataSource = CamadaNegocio.Restaurante.TCN_HoraBoliche.Buscar(string.Empty, null, OrdenarPor: "tp_servico, dia asc");
            bsHoraBoliche.ResetBindings(true);
        }

        #endregion

        #region Eventos     
        private void TFHoraBoliche_Load(object sender, EventArgs e)
        {
            bsHoraBoliche.DataSource = CamadaNegocio.Restaurante.TCN_HoraBoliche.Buscar(string.Empty, null, OrdenarPor: "tp_servico, dia asc");
        }

        private void bb_novo_abastecimento_Click(object sender, EventArgs e)
        {
            controlButtons(Utils.TTpModo.tm_Insert);
        }

        private void bb_gravar_abastecimento_Click(object sender, EventArgs e)
        {
            if (pnListagem.validarCampoObrigatorio())
            {
                if (modo.Equals(Utils.TTpModo.tm_Edit))
                {
                    //Alterar registro
                    CamadaNegocio.Restaurante.TCN_HoraBoliche.Gravar(
                    new CamadaDados.Restaurante.TRegistro_HoraBoliche()
                    {
                        Id_Hora = (bsHoraBoliche.Current as CamadaDados.Restaurante.TRegistro_HoraBoliche).Id_Hora,
                        Horastr = editHora1.Text,
                        Vl_hora = editFloat1.Value,
                        Dia = cbDias.SelectedValue.ToString(),
                        Tp_servico = rbBoliche.Checked ? "B" : "S"
                    }, null);
                }
                else
                {
                    //Novo registro
                    CamadaNegocio.Restaurante.TCN_HoraBoliche.Gravar(
                    new CamadaDados.Restaurante.TRegistro_HoraBoliche()
                    {
                        Horastr = editHora1.Text,
                        Vl_hora = editFloat1.Value,
                        Dia = cbDias.SelectedValue.ToString(),
                        Tp_servico = rbBoliche.Checked? "B" : "S"
                    }, null);
                }
                afterBuscar();
            }
        }

        private void bb_alterar_abastecimento_Click(object sender, EventArgs e)
        {
            afterAlterar();
        }

        private void bb_excluir_abastecimento_Click(object sender, EventArgs e)
        {
            afterExcluir();
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
