using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Financeiro.Cadastros;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCad_CondPGTO : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_CondPGTO()
        {
            InitializeComponent();
            DTS = BS_Cad_CondPGTO;
        }

        public override int buscarRegistros()
        {
            TList_CadCondPgto lista = TCN_CadCondPgto.Buscar(CD_CondPGTO.Text,
                                                               DS_CondPgto.Text,
                                                               CD_Portador.Text,
                                                               CD_Moeda.Text,
                                                               string.Empty,
                                                               CD_Juro.Text,
                                                               decimal.Zero,
                                                               decimal.Zero,
                                                               string.Empty,
                                                               string.Empty,
                                                               0, 
                                                               string.Empty, 
                                                               null);
             
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    BS_Cad_CondPGTO.DataSource = lista;
                    BS_Cad_CondPGTO_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_Cad_CondPGTO.Clear();
                return lista.Count;
            }
            else
                return 0;
            
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                gCadastro.Focus();
                return TCN_CadCondPgto.GravarCondPgto(BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto, null);
            }
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_busca) || (this.vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                BS_Cad_CondPGTO.AddNew();
                base.afterNovo();
                ST_VenctoEmFeriado.Enabled = false;
                if (!(this.CD_CondPGTO.Focus()))
                    this.DS_CondPgto.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
            {
                ST_VenctoEmFeriado.Enabled = (QT_Parcelas.Value > 0);
                if (!ST_VenctoEmFeriado.Enabled)
                {
                    ST_VenctoEmFeriado.Checked = false;
                }
                this.DS_CondPgto.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }
                
        public override void excluirRegistro()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if (gCadastro.RowCount > 0)
                {
                    if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    {
                        if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                TCN_CadCondPgto.DeletarCondPgto(BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto, null);
                                BS_Cad_CondPGTO.RemoveCurrent();
                                pDados.LimparRegistro();
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Opção desabilitada!");
            }
        }

        public void InserirParcelas()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
                if (BS_Cad_CondPGTO.Current != null)
                    if ((BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).Qt_parcelas > 1)
                    {
                        using (TFCadCondPGTO_X_Parcelas fCondParcelas = new TFCadCondPGTO_X_Parcelas())
                        {
                            fCondParcelas.rCondpgto = BS_Cad_CondPGTO.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto;
                            fCondParcelas.ShowDialog();
                            BS_Cad_CondPGTO.ResetCurrentItem();
                        }
                    }
                    else
                        MessageBox.Show("Permitido gerar parcelas somente de condição de pagamento com mais de uma parcela.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExcluirParcelas()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit))
                if (BS_Cad_CondPGTO.Current != null)
                    if (MessageBox.Show("Confirma exclusão das parcelas da condição pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        (BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).lCondPgto_X_Parcelas.ForEach(p => (BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).lCondParcDel.Add(p));
                        BS_CondPgtoXParcelas.Clear();
                    }
        }
        
        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void limparControls()
        {
            pDados.LimparRegistro();
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Descrição Portador|350;" +
                              "CD_Portador|Cód. Portador|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), "");
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            if (CD_Portador.Text.Trim() != "")
            {
                string vColunas = CD_Portador.NM_CampoBusca + "|=|'" + CD_Portador.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Portador, ds_portador },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
            }
            else
                ds_portador.Clear();
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|350;" +
                              "CD_Moeda|Cód. Moeda|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                    new TCD_Moeda(), "");
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_moeda|=|'" + CD_Moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Moeda, ds_moeda },
                                    new TCD_Moeda());
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Juro|Descrição Juro|350;" +
                              "CD_Juro|Cód. Juro|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Juro, ds_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadJuro(), "");
        }

        private void CD_Juro_Leave(object sender, EventArgs e)
        {
            if (CD_Juro.Text.Trim() != "")
            {
                string vColunas = CD_Juro.NM_CampoBusca + "|=|'" + CD_Juro.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Juro, ds_juro },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadJuro());
            }
            else
                ds_juro.Clear();
        }

        private void QT_Parcelas_ValueChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
            {
                ST_VenctoEmFeriado.Enabled = (QT_Parcelas.Value > 0);
                if (!ST_VenctoEmFeriado.Enabled)
                    ST_VenctoEmFeriado.Checked = false;
                if (!string.IsNullOrEmpty(CD_Portador.Text))
                {
                    TList_CadPortador lPortador = TCN_CadPortador.Buscar(CD_Portador.Text,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         decimal.Zero,
                                                                         false,
                                                                         false,
                                                                         string.Empty,
                                                                         1,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                    if (lPortador.Count > 0)
                    {
                        if ((lPortador[0].Qt_min_parc > 0) && (QT_Parcelas.Value < lPortador[0].Qt_min_parc))
                        {
                            MessageBox.Show("Quantidade de parcelas menor que o minimo exigido pelo portador.\r\n" +
                                            "Portador: " + CD_Portador.Text.Trim() + " - " + ds_portador.Text.Trim() + "\r\n" +
                                            "Nº Minimo Parcelas: " + lPortador[0].Qt_min_parc + "\r\n" +
                                            "Nº Maximo Parcelas: " + lPortador[0].Qt_max_parc + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QT_Parcelas.Value = 1;
                            QT_Parcelas.Focus();
                            return;
                        }
                        if ((lPortador[0].Qt_max_parc > 0) && (QT_Parcelas.Value > lPortador[0].Qt_max_parc))
                        {
                            MessageBox.Show("Quantidade de parcelas maior que o maximo exigido pelo portador.\r\n" +
                                            "Portador: " + CD_Portador.Text.Trim() + " - " + ds_portador.Text.Trim() + "\r\n" +
                                            "Nº Minimo Parcelas: " + lPortador[0].Qt_min_parc + "\r\n" +
                                            "Nº Maximo Parcelas: " + lPortador[0].Qt_max_parc + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QT_Parcelas.Value = 1;
                            QT_Parcelas.Focus();
                            return;
                        }
                    }
                }
            }
        }

        private void ST_VenctoEmFeriado_EnabledChanged(object sender, EventArgs e)
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Insert) || (this.vTP_Modo == Utils.TTpModo.tm_Edit))
                if (!(ST_VenctoEmFeriado.Enabled))
                    ST_VenctoEmFeriado.Checked = false;
        }

        private void bbJuro_Fin_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_juro|Descrição Juro Mora|350;" +
                              "cd_juro|Cód. Juro Mora|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_Juro_Fin, ds_Juro_Fin },
                                    new TCD_CadJuro(), "");
        }

        private void cd_Juro_Fin_Leave(object sender, EventArgs e)
        {
            string vColunas = cd_Juro_Fin.NM_CampoBusca + "|=|'" + cd_Juro_Fin.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_Juro_Fin, ds_Juro_Fin },
                                  new TCD_CadJuro());
        }

        private void TFCad_CondPGTO_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            Utils.ShapeGrid.RestoreShape(this, gCondicaoXparcelas);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void ts_btn_Inserir_Cond_x_parcelas_Click(object sender, EventArgs e)
        {
            this.InserirParcelas();
        }

        private void ts_btn_Alterar_Cond_X_parcelas_Click(object sender, EventArgs e)
        {
            this.InserirParcelas();
        }

        private void ts_btn_Deletar_Cond_X_parcelas_Click(object sender, EventArgs e)
        {
            this.ExcluirParcelas();
        }

        private void BS_Cad_CondPGTO_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Cad_CondPGTO.Current != null)
            {
                if (!string.IsNullOrEmpty((BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).Cd_condpgto))
                {
                    (BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).lCondPgto_X_Parcelas =
                        TCN_CadCondPgto_X_Parcelas.Buscar((BS_Cad_CondPGTO.Current as TRegistro_CadCondPgto).Cd_condpgto, null);
                    BS_Cad_CondPGTO.ResetCurrentItem();
                }
            }
        }

        private void TFCad_CondPGTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirParcelas();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.excluirRegistro();
        }

        private void TFCad_CondPGTO_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
            Utils.ShapeGrid.SaveShape(this, gCondicaoXparcelas);
        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_Cad_CondPGTO.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadCondPgto());
            TList_CadCondPgto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadCondPgto(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadCondPgto(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_Cad_CondPGTO.List as TList_CadCondPgto).Sort(lComparer);
            BS_Cad_CondPGTO.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
