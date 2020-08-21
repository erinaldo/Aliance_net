using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFCadEvento : FormCadPadrao.FFormCadPadrao
    {
        public TFCadEvento()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("CARTA CORREÇÃO", "CC"));
            cbx.Add(new Utils.TDataCombo("CANCELAMENTO", "CA"));
            cbx.Add(new Utils.TDataCombo("MANIFESTO", "MF"));
            cbx.Add(new Utils.TDataCombo("ENCERRAMENTO", "EC"));
            cbx.Add(new Utils.TDataCombo("INCLUSÃO CONDUTOR", "IC"));
            tp_evento.DataSource = cbx;
            tp_evento.DisplayMember = "Display";
            tp_evento.ValueMember = "Value";
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                return CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Gravar(
                    bsEvento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Evento, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_Evento lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(cd_evento.Text,
                                                                      ds_evento.Text,
                                                                      tp_evento.SelectedValue != null ? tp_evento.SelectedValue.ToString() : string.Empty,
                                                                      null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEvento.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsEvento.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsEvento.AddNew();
                base.afterNovo();
                cd_evento.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsEvento.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_evento.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Excluir(
                        bsEvento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Evento, null);
                    bsEvento.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void gEvento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEvento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEvento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Cadastros.TRegistro_Evento());
            CamadaDados.Faturamento.Cadastros.TList_Evento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEvento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEvento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Cadastros.TList_Evento(lP.Find(gEvento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEvento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Cadastros.TList_Evento(lP.Find(gEvento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEvento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEvento.List as CamadaDados.Faturamento.Cadastros.TList_Evento).Sort(lComparer);
            bsEvento.ResetBindings(false);
            gEvento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadEvento_Load(object sender, EventArgs e)
        {
            ds_evento.CharacterCasing = CharacterCasing.Normal;
        }
    }
}
