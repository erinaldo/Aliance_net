using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaDados.Restaurante.Cadastro;

namespace Restaurante.Cadastro
{
    public partial class FCadPista : Form
    {
        Utils.TTpModo modo = Utils.TTpModo.tm_Standby;
        public FCadPista()
        {
            InitializeComponent();
        }

        #region Métodos
        private void controlsButton(Utils.TTpModo t)
        {
            if (t == Utils.TTpModo.tm_Standby)
            {
                BB_Novo.Enabled = true;
                BB_Alterar.Enabled = true;
                BB_Buscar.Enabled = true;
                BB_Excluir.Enabled = true;
                bb_inutilizar.Enabled = false;
            }
            else if (t == Utils.TTpModo.tm_Insert)
            {
                BB_Novo.Enabled = false;
                BB_Alterar.Enabled = false;
                BB_Buscar.Enabled = false;
                BB_Excluir.Enabled = false;
                bb_inutilizar.Enabled = true;
            }
            else if (t == Utils.TTpModo.tm_Edit)
            {
                BB_Novo.Enabled = false;
                BB_Alterar.Enabled = false;
                BB_Buscar.Enabled = false;
                BB_Excluir.Enabled = false;
                bb_inutilizar.Enabled = true;
            }
            modo = t;
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(ds_pista.Text))
                bsPistaBoliche.DataSource = TCN_PistaBoliche.Buscar(string.Empty,
                                                                    ds_pista.Text,
                                                                    "A",
                                                                    null);
            else
                bsPistaBoliche.DataSource = TCN_PistaBoliche.Buscar(string.Empty,
                                                                    string.Empty,
                                                                    "A",
                                                                    null);
            panelNome.LimparRegistro();
            bsPistaBoliche.ResetCurrentItem();
            controlsButton(Utils.TTpModo.tm_Standby);
        }

        private void afterNovo()
        {
            controlsButton(Utils.TTpModo.tm_Insert);
        }

        private void afterAlterar()
        {
            if (bsPistaBoliche.Current != null)
                controlsButton(Utils.TTpModo.tm_Edit);
        }

        private void afterExcluir()
        {
            if (bsPistaBoliche.Current != null)
            {
                //Valida existencia de pista locada
                if (CamadaNegocio.Restaurante.TCN_MovBoliche.Buscar(string.Empty,
                                                                    string.Empty,
                                                                    (bsPistaBoliche.Current as TRegistro_PistaBoliche).Id_Pista.ToString().Trim(),
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null).Exists(p => p.Dt_fechamento == null || string.IsNullOrEmpty(p.Dt_fechamento.ToString())))
                {
                    MessageBox.Show("Está pista possui movimentação em aberto, não será possível realizar a exclusão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                (bsPistaBoliche.Current as TRegistro_PistaBoliche).st_registro = "C";
                TCN_PistaBoliche.Gravar((bsPistaBoliche.Current as TRegistro_PistaBoliche), null);
                MessageBox.Show("Pista excluída com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelNome.LimparRegistro();
                afterBusca();
            }
        }

        private void afterGravar()
        {
            if (modo == Utils.TTpModo.tm_Insert)
            {
                if (!string.IsNullOrEmpty(ds_pista.Text))
                {
                    TCN_PistaBoliche.Gravar(new TRegistro_PistaBoliche { Ds_Pista = ds_pista.Text, st_registro = "A", Tp_servico = rbBoliche.Checked ? "B" : "S" }, null);
                    afterBusca();
                }
                else
                {
                    MessageBox.Show("Necessário informar o nome para pista", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    controlsButton(Utils.TTpModo.tm_Standby);
                    return;
                }
            }
            else if (modo == Utils.TTpModo.tm_Edit)
            {
                if (bsPistaBoliche.Current != null)
                {
                    if (string.IsNullOrEmpty(ds_pista.Text))
                    {
                        MessageBox.Show("Para alterar, selecione um registro na listagem, informe a nova descrição e click na opção gravar ou utilize o atalho F4.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        controlsButton(Utils.TTpModo.tm_Standby);
                        return;
                    }
                    else
                    {
                        (bsPistaBoliche.Current as TRegistro_PistaBoliche).Ds_Pista = ds_pista.Text;
                        (bsPistaBoliche.Current as TRegistro_PistaBoliche).Tp_servico = rbBoliche.Checked ? "B" : "S";
                        TCN_PistaBoliche.Gravar((bsPistaBoliche.Current as TRegistro_PistaBoliche), null);
                        MessageBox.Show("Pista alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                }
            }

        }
        #endregion

        #region Eventos

        private void FCadPista_Load(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAlterar();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExcluir();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCadPista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                afterNovo();
            else if (e.KeyCode == Keys.F3)
                afterAlterar();
            else if (e.KeyCode == Keys.F4)
                afterBusca();
            else if (e.KeyCode == Keys.F5)
                afterExcluir();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGravar();
        }
        #endregion

    }
}
