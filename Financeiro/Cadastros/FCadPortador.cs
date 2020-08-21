using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadPortador : FormCadPadrao.FFormCadPadrao
    {
        public TFCadPortador()
        {
            InitializeComponent();
            DTS = bsPortador;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadPortador.Gravar(bsPortador.Current as TRegistro_CadPortador, null);
            else
                return string.Empty;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsPortador.AddNew();
            base.afterNovo();
            if (!cd_portador.Focus())
                ds_portador.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                ds_portador.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsPortador.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CadPortador lista = TCN_CadPortador.Buscar(cd_portador.Text,
                                                     ds_portador.Text,
                                                     QT_Min_Parc.Value,
                                                     QT_MAX_PARC.Value,
                                                     st_controletitulo.Checked,
                                                     st_tituloterceiro.Checked,
                                                     string.Empty,
                                                     0, 
                                                     string.Empty,
                                                     string.Empty,
                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsPortador.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsPortador.Clear();
                return lista.Count;
            }
            else
                return 0;
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
                        TCN_CadPortador.Excluir(bsPortador.Current as TRegistro_CadPortador, null);
                        bsPortador.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void TFCadPortador_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new Utils.TDataCombo("A VISTA", "A"));
            cbx.Add(new Utils.TDataCombo("A PRAZO", "P"));

            tp_portadorpdv.DataSource = cbx;
            tp_portadorpdv.ValueMember = "Value";
            tp_portadorpdv.DisplayMember = "Display";
        }

        private void buscarlogo_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsPortador.Current != null) && ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit)))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsPortador.Current as TRegistro_CadPortador).Icone_portador = Image.FromFile(ofd.FileName);
                            bsPortador.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPortador.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadPortador());
            TList_CadPortador lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadPortador(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadPortador(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPortador.List as TList_CadPortador).Sort(lComparer);
            bsPortador.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFCadPortador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }
    }
}

