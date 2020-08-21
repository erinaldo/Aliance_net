using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Graos;
using Utils;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;
using System.Collections;

namespace Parametros.Diversos
{
    public partial class TFCadTerminal : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTerminal()
        {
            InitializeComponent();
            DTS = BS_CadTerminal;

            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new TDataCombo("GRAFICA", "G"));
            cbx.Add(new TDataCombo("TEXTO", "T"));
            tp_imptickavulso.DataSource = cbx;
            tp_imptickavulso.DisplayMember = "Display";
            tp_imptickavulso.ValueMember = "Value";

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new TDataCombo("GRAFICA", "G"));
            cbx1.Add(new TDataCombo("TEXTO", "T"));
            tp_imppedido.DataSource = cbx1;
            tp_imppedido.DisplayMember = "Display";
            tp_imppedido.ValueMember = "Value";

            ArrayList cbx2 = new ArrayList();
            cbx2.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx2.Add(new TDataCombo("GRAFICA", "G"));
            cbx2.Add(new TDataCombo("TEXTO", "T"));
            cbx2.Add(new TDataCombo("REDUZIDA", "R"));
            cbx2.Add(new TDataCombo("GRAFICA REDUZIDA", "F"));
            tp_imporcamento.DataSource = cbx2;
            tp_imporcamento.DisplayMember = "Display";
            tp_imporcamento.ValueMember = "Value";

            ArrayList cbx3 = new ArrayList();
            cbx3.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx3.Add(new TDataCombo("GRAFICA", "G"));
            cbx3.Add(new TDataCombo("TEXTO", "T"));
            cbx3.Add(new TDataCombo("REDUZIDA", "R"));
            tp_imptick.DataSource = cbx3;
            tp_imptick.DisplayMember = "Display";
            tp_imptick.ValueMember = "Value";

            ArrayList cbx4 = new ArrayList();
            cbx4.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx4.Add(new TDataCombo("GRAFICA", "G"));
            cbx4.Add(new TDataCombo("TEXTO", "T"));
            cbx4.Add(new TDataCombo("REDUZIDA", "R"));
            cbx4.Add(new TDataCombo("GRAFICA REDUZIDA", "F"));
            tp_imprecibo.DataSource = cbx4;
            tp_imprecibo.DisplayMember = "Display";
            tp_imprecibo.ValueMember = "Value";

            ArrayList cbx5 = new ArrayList();
            cbx5.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx5.Add(new TDataCombo("GRAFICA", "G"));
            cbx5.Add(new TDataCombo("TEXTO", "T"));
            tp_impcheque.DataSource = cbx5;
            tp_impcheque.DisplayMember = "Display";
            tp_impcheque.ValueMember = "Value";

            ArrayList cbx6 = new ArrayList();
            cbx6.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx6.Add(new TDataCombo("GRAFICA", "G"));
            cbx6.Add(new TDataCombo("TEXTO", "T"));
            cbx6.Add(new TDataCombo("REDUZIDA", "R"));
            tp_impos.DataSource = cbx6;
            tp_impos.DisplayMember = "Display";
            tp_impos.ValueMember = "Value";

            ArrayList cbx7 = new ArrayList();
            cbx7.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx7.Add(new TDataCombo("NORMAL", "N"));
            cbx7.Add(new TDataCombo("ZEBRA", "Z"));
            cbx7.Add(new TDataCombo("ARGOX", "A"));
            tp_impetiqueta.DataSource = cbx7;
            tp_impetiqueta.DisplayMember = "Display";
            tp_impetiqueta.ValueMember = "Value";

            ArrayList cbx8 = new ArrayList();
            cbx8.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx8.Add(new TDataCombo("LAYOUT 1", "1"));
            cbx8.Add(new TDataCombo("LAYOUT 2", "2"));
            cbx8.Add(new TDataCombo("LAYOUT 3", "3"));
            cbx8.Add(new TDataCombo("ELGIN 1<PRODUTO;COD BARRA>", "4"));
            cbx8.Add(new TDataCombo("ELGIN 2<PRODUTO;COD BARRA;PREÇO>", "5"));
            cbx8.Add(new TDataCombo("ELGIN 3<PRODUTO;COD BARRA;PREÇO>", "6"));
            layoutetiqueta.DataSource = cbx8;
            layoutetiqueta.DisplayMember = "Display";
            layoutetiqueta.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadTerminal.Grava_CadTerminal(BS_CadTerminal.Current as TRegistro_CadTerminal, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadTerminal lista = TCN_CadTerminal.Busca(CD_Terminal.Text.Trim(),
                                                            DS_Terminal.Text.Trim(), 
                                                            null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadTerminal.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        BS_CadTerminal.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                DS_Terminal.Focus();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadTerminal.AddNew();
                base.afterNovo();
                CD_Terminal.Focus();
            
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadTerminal.RemoveCurrent();
        }

        private void TFCadTerminal_Load(object sender, EventArgs e)
        {
            bb_calccharve.Visible = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
        }

        private void bb_calccharve_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nr_serial.Text))
                chave_acesso.Text = (Utils.Estruturas.CalcChaveAcesso(nr_serial.Text));
            else 
                MessageBox.Show("Obrigatório inserir Numero do Serial para calcular a chave!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);           
        }

        private void bb_mapear_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(porta_imptick.Text)) &&
                (!string.IsNullOrEmpty(mapearunidade.Text)))
                System.Diagnostics.Process.Start("net", "use " + porta_imptick.Text.Trim() + " " + mapearunidade.Text + " /persistent:yes");
        }

        private void bb_impressoras_Click(object sender, EventArgs e)
        {
             if(this.vTP_Modo.Equals(Utils.TTpModo.tm_Insert) ||
                 this.vTP_Modo.Equals(Utils.TTpModo.tm_Edit))
                using (TFListaImpressoras fLista = new TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            impressorapadrao.Text = fLista.Impressora;
                }
        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CadTerminal.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadTerminal());
            TList_CadTerminal lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadTerminal(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadTerminal(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CadTerminal.List as TList_CadTerminal).Sort(lComparer);
            BS_CadTerminal.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_layout|Layout|150;a.id_layout|Código|50",
                new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Diversos.TCD_CadLayoutEtiqueta(),
                string.Empty);
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                                              "a.id_layout|=|'" + cd_endereco.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                             new CamadaDados.Diversos.TCD_CadLayoutEtiqueta());
        }
    }
}

