using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFCadBandeiraCartao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadBandeiraCartao()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("DEBITO", "D"));
            cbx.Add(new TDataCombo("CREDITO", "C"));
            cbx.Add(new TDataCombo("ROTATIVO", "R"));

            tp_cartao.DataSource = cbx;
            tp_cartao.ValueMember = "Value";
            tp_cartao.DisplayMember = "Display";
        }

        public override int buscarRegistros()
        {
            TList_Cad_BandeiraCartao lista = TCN_Cad_BandeiraCartao.Buscar(ID_Bandeira.Text, DS_Bandeira.Text, string.Empty, 0, string.Empty, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsBandeiraCartao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                        bsBandeiraCartao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsBandeiraCartao.AddNew();
                base.afterNovo();
                if (!ID_Bandeira.Focus())
                    DS_Bandeira.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsBandeiraCartao.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_Cad_BandeiraCartao.Deletar(bsBandeiraCartao.Current as TRegistro_Cad_BandeiraCartao, null);
                        bsBandeiraCartao.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_BandeiraCartao.Gravar(bsBandeiraCartao.Current as TRegistro_Cad_BandeiraCartao, null);
            else
                return string.Empty;
        }

        private void bb_logo_Click_1(object sender, EventArgs e)
        {
            if ((bsBandeiraCartao.Current != null) && ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit)))
            {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsBandeiraCartao.Current as TRegistro_Cad_BandeiraCartao).Imagem = Image.FromFile(ofd.FileName);
                            bsBandeiraCartao.ResetCurrentItem();
                        }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }

        private void gBandeiraCartao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBandeiraCartao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBandeiraCartao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Cad_BandeiraCartao());
            TList_Cad_BandeiraCartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Cad_BandeiraCartao(lP.Find(gBandeiraCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBandeiraCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Cad_BandeiraCartao(lP.Find(gBandeiraCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBandeiraCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBandeiraCartao.DataSource as TList_Cad_BandeiraCartao).Sort(lComparer);
            bsBandeiraCartao.ResetBindings(false);
            gBandeiraCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
        }

        private void TFCadBandeiraCartao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBandeiraCartao);
        }

        private void TFCadBandeiraCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBandeiraCartao);
        }
    }
}
