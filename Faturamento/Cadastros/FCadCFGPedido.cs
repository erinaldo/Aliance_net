using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using System.Collections;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGPedido : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGPedido()
        {
            InitializeComponent();
            DTS = BS_CadCFGPedido;
        }

        public override string gravarRegistro()
        {
            return TCN_CadCFGPedido.Gravar(BS_CadCFGPedido.Current as TRegistro_CadCFGPedido, null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {

            TList_CadCFGPedido lista = TCN_CadCFGPedido.Buscar(CFG_Pedido.Text,
                                                               DS_TipoPedido.Text,
                                                               Tp_Movimento.SelectedValue != null ? Tp_Movimento.SelectedValue.ToString().Trim() : string.Empty,
                                                               ST_Deposito.Checked ? "S" : string.Empty,
                                                               ST_Confere_Saldo.Checked ? "S" : string.Empty,
                                                               ST_ValoresFixos.Checked ? "S" : string.Empty,
                                                               cb_ST_PermPedParc.Checked ? "S" : string.Empty,
                                                               cb_ST_PermTransf.Checked ? "S" : string.Empty,
                                                               ST_ComissaoPed.Checked ? "S" : string.Empty,
                                                               st_comissaofat.Checked ? "S" : string.Empty,
                                                               ST_Servico.Checked ? "S" : string.Empty,                                                               
                                                               decimal.Zero, 0, string.Empty, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadCFGPedido.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadCFGPedido.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadCFGPedido.AddNew();
                base.afterNovo();
                if (!CFG_Pedido.Focus())
                    DS_TipoPedido.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadCFGPedido.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            this.HabilitarFlags();
            DS_TipoPedido.Focus();
        }

        public override void afterExclui()
        {
            if (BS_CadCFGPedido.Current != null)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            TCN_CadCFGPedido.Excluir(BS_CadCFGPedido.Current as TRegistro_CadCFGPedido, null);
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro excluir: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void HabilitarFlags()
        {
            if (Tp_Movimento.SelectedValue != null)
                if (this.vTP_Modo.Equals(TTpModo.tm_Insert) || this.vTP_Modo.Equals(TTpModo.tm_Edit))
                    if (Tp_Movimento.SelectedValue.ToString().Equals("E"))
                    {
                        cb_Rastrear_NFOrig.Checked = false;
                        cb_Rastrear_NFOrig.Enabled = false;
                        st_atualizaprecovenda.Enabled = true;

                    }
                    else
                    {
                        cb_Rastrear_NFOrig.Enabled = true;
                        st_atualizaprecovenda.Enabled = false;
                        st_atualizaprecovenda.Checked = false;
                    }
        }

        private void ST_ValoresFixos_CheckedChanged(object sender, EventArgs e)
        {
            if (ST_ValoresFixos.Checked)
                ST_Deposito.Enabled = false;
            else
                ST_Deposito.Enabled = true;
        }

        private void ST_Confere_Saldo_CheckedChanged(object sender, EventArgs e)
        {
            if (ST_Confere_Saldo.Checked)
                ST_Deposito.Enabled = false;
            else
                ST_Deposito.Enabled = true;
        }
        
        private void CadCFGPedido_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("ENTRADA", "E"));
            CBox1.Add(new Utils.TDataCombo("SAIDA", "S"));
            Tp_Movimento.DataSource = CBox1;
            Tp_Movimento.DisplayMember = "Display";
            Tp_Movimento.ValueMember = "Value";
            Tp_Movimento.SelectedIndex = -1;
        }

        private void ST_Deposito_CheckedChanged(object sender, EventArgs e)
        {
            if (ST_Deposito.Checked)
            {
                ST_ComissaoPed.Enabled = false;
                ST_Servico.Enabled = false;

            }
            else
            {
                ST_ComissaoPed.Enabled = true;
                ST_Servico.Enabled = true;
            }
        }

        private void ST_Servico_CheckedChanged(object sender, EventArgs e)
        {
            if (ST_Servico.Checked)
                ST_Deposito.Enabled = false;
            else
                ST_Deposito.Enabled = true;
        }

        private void Tp_Movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HabilitarFlags();
        }

        private void BS_CadCFGPedido_CurrentChanged(object sender, EventArgs e)
        {
            if (BS_CadCFGPedido.Current != null)
                Tp_Movimento_SelectedIndexChanged(this, e);
        }

        private void TFCadCFGPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void ST_ComissaoPed_Click(object sender, EventArgs e)
        {
            if (ST_ComissaoPed.Checked)
            {
                ST_Deposito.Enabled = false;
                st_comissaofat.Checked = false;
            }
            else
                ST_Deposito.Enabled = true;
        }

        private void st_comissaofat_Click(object sender, EventArgs e)
        {
            if (st_comissaofat.Checked)
            {
                ST_Deposito.Enabled = false;
                ST_ComissaoPed.Checked = false;
            }
            else
                ST_Deposito.Enabled = true;
        }
    }
}

