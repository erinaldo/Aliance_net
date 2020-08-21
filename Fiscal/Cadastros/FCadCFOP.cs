using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Fiscal;
using CamadaDados.Fiscal;
using Utils;


namespace Fiscal.Cadastros
{
    public partial class TFCadCFOP : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFOP()
        {
            InitializeComponent();
            DTS = BS_CFOP;

        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadCFOP.Gravar(BS_CFOP.Current as TRegistro_CadCFOP, null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadCFOP lista = TCN_CadCFOP.Busca(cd_cfop.Text, 
                                                    ds_cfop.Text, 
                                                    string.Empty, 
                                                    st_bonificacao.Checked, 
                                                    cbUsoConsumo.Checked, 
                                                    st_devolucao.Checked,
                                                    st_remessa.Checked,
                                                    st_retorno.Checked,
                                                    null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CFOP.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CFOP.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            ds_cfop.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CFOP.AddNew();
                base.afterNovo();
                if (!(cd_cfop.Focus()))
                    ds_cfop.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_CFOP.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadCFOP.Excluir((BS_CFOP.Current as TRegistro_CadCFOP), null);
                    BS_CFOP.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadCFOP_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
        }

        private void TFCadCFOP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void gCadastro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCadastro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_CFOP.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadCFOP());
            TList_CadCFOP lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadCFOP(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadCFOP(lP.Find(gCadastro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCadastro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_CFOP.List as TList_CadCFOP).Sort(lComparer);
            BS_CFOP.ResetBindings(false);
            gCadastro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bbSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TRegistro_CadCFOP> lista = ServiceRest.DataService.BuscarCFOPRest();
                if (lista != null)
                {
                    lista.ForEach(p => TCN_CadCFOP.Gravar(p, null));
                    MessageBox.Show("Cadastro sincronizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
            }
            catch(Exception ex)
            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

