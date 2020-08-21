using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Locacao.Cadastros;
using CamadaNegocio.Locacao.Cadastros;
using Componentes;

namespace Locacao.Cadastros
{
    public partial class TFCadTabPreco : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTabPreco()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("UNIDADE", "0"));
            cbx.Add(new Utils.TDataCombo("MILIMETRO", "1"));
            cbx.Add(new Utils.TDataCombo("HORA", "2"));
            cbx.Add(new Utils.TDataCombo("DIA", "3"));
            cbx.Add(new Utils.TDataCombo("MÊS", "4"));
            cbx.Add(new Utils.TDataCombo("SEMANA", "5"));
            cbx.Add(new Utils.TDataCombo("QUINZENA", "6"));
            tp_tabpreco.DataSource = cbx;
            tp_tabpreco.DisplayMember = "Display";
            tp_tabpreco.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (bsTabPreco.Current == null)
                return string.Empty;
            else if (existsRegistro(ds_tabpreco.Text, tp_tabpreco.SelectedValue))
            {
                MessageBox.Show("Já existe um registro com o mesmo nome e tipo de tabela informado. Não será possível finalizar o processo.", 
                    "Informativo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return string.Empty;
            }
            else if (pDados.validarCampoObrigatorio())
                return TCN_CadTabPreco.Gravar(bsTabPreco.Current as TRegistro_CadTabPreco, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTabPreco lista = TCN_CadTabPreco.Buscar(string.Empty,
                                                             ds_tabpreco.Text,
                                                             (tp_tabpreco.SelectedValue != null ? tp_tabpreco.SelectedValue.ToString() : string.Empty),
                                                             null,
                                                             cbxCancelado.Checked);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTabPreco.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTabPreco.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsTabPreco.AddNew();
            base.afterNovo();
            ds_tabpreco.Focus();
        }

        private bool existsRegistro(string text, object tp_tabpreco)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            else if (tp_tabpreco == null)
                return false;
            else if (string.IsNullOrEmpty(tp_tabpreco.ToString()))
                return false;
            else return new TCD_CadTabPreco()
                    .BuscarEscalar(
                        new Utils.TpBusca[] 
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ds_tabela",
                                vOperador = "=",
                                vVL_Busca = "'" + text.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_tabela",
                                vOperador = "=",
                                vVL_Busca = "'" + tp_tabpreco + "'"
                            }
                        }, "1") != null;
        }

        public override void afterAltera()
        {
            if (bsTabPreco.Current == null)
                return;
            else if ((bsTabPreco.Current as TRegistro_CadTabPreco).Cancelado)
                MessageBox.Show("Não é permitido alterar registros cancelados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                base.afterAltera();
                ds_tabpreco.Focus();
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTabPreco.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (bsTabPreco.Current == null)
                return;
            else if ((bsTabPreco.Current as TRegistro_CadTabPreco).Cancelado)
                MessageBox.Show("Não é permitido excluir registros cancelados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TCN_CadTabPreco.Cancelar(bsTabPreco.Current as TRegistro_CadTabPreco, null);
                    MessageBox.Show("Exlcuído com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    bsTabPreco.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
    }
}
