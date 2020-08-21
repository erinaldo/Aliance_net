using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Utils;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadBomba : Form
    {
        private CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento rbomba;
        public CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento rBomba
        {
            get
            {
                if (bsBomba.Current != null)
                    return bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento;
                else
                    return null;
            }
            set { rbomba = value; }
        }

        public TFCadBomba()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ANALOGICA", "A"));
            cbx.Add(new Utils.TDataCombo("DIGITAL", "D"));

            tp_medicao.DataSource = cbx;
            tp_medicao.DisplayMember = "Display";
            tp_medicao.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirBico()
        {
            if(bsBomba.Current != null)
                using (TFCadBicoBomba fBico = new TFCadBicoBomba())
                {
                    fBico.Cd_empresa = cd_empresa.Text;
                    fBico.Nm_empresa = nm_empresa.Text;
                    if(fBico.ShowDialog() == DialogResult.OK)
                        if (fBico.rBico != null)
                        {
                            (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lBico.Add(fBico.rBico);
                            bsBomba.ResetCurrentItem();
                        }
                }
        }

        private void AlterarBico()
        {
            if(bsBico.Current != null)
                using (TFCadBicoBomba fBico = new TFCadBicoBomba())
                {
                    string id_tanque = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Id_tanquestr;
                    string cd_produto = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Cd_produto;
                    string ds_produto = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Ds_produto;
                    string endbico = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Enderecofisicobico;
                    fBico.rBico = bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba;
                    if (fBico.ShowDialog() != DialogResult.OK)
                    {
                        (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Id_tanquestr = id_tanque;
                        (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Cd_produto = cd_produto;
                        (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Ds_produto = ds_produto;
                        (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Enderecofisicobico = endbico;
                        bsBico.ResetCurrentItem();
                    }
                }
        }

        private void ExcluirBico()
        {
            if(bsBico.Current != null)
                if (MessageBox.Show("Confirma exclusão do bico selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().BuscarEscalar(
                        new TpBusca[]{
                            new TpBusca(){
                                vNM_Campo = "",
                                vOperador = "exists",
                                vVL_Busca = "( select 1 from tb_pdc_vendacombustivel x where x.id_bico = a.id_bico )"

                            },
                            new TpBusca(){
                                vNM_Campo = "a.id_bico",
                                vOperador = "=",
                                vVL_Busca = (bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba).Id_bicostr


                            }


                        },"a.id_bico"


                        );
                    if (obj == null)
                    {

                        (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lBicoDel.Add(
                            bsBico.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba);
                        bsBico.RemoveCurrent();
                    }
                    else
                    {
                        MessageBox.Show("Bico existe abastecida, não pode excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void InserirLacre()
        {
            if(bsBomba.Current != null)
                using (TFCadLacre fLacre = new TFCadLacre())
                {
                    if(fLacre.ShowDialog() == DialogResult.OK)
                        if (fLacre.rLacre != null)
                        {
                            (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lLacre.Add(fLacre.rLacre);
                            bsBomba.ResetCurrentItem();
                        }
                }
        }

        private void AlterarLacre()
        {
            if(bsLacre.Current !=  null)
                using (TFCadLacre fLacre = new TFCadLacre())
                {
                    string nr_lacre = (bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba).Nr_lacre;
                    DateTime dt_lacre = (bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba).Dt_aplicacao.Value;
                    fLacre.rLacre = bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba;
                    if (fLacre.ShowDialog() != DialogResult.OK)
                    {
                        (bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba).Nr_lacre = nr_lacre;
                        (bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba).Dt_aplicacao = dt_lacre;
                        bsLacre.ResetCurrentItem();
                    }
                }
        }

        private void ExcluirLacre()
        {
            if(bsLacre.Current != null)
                if (MessageBox.Show("Confirma exclusão do lacre selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lLacreDel.Add(
                        bsLacre.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba);
                    bsLacre.RemoveCurrent();
                }
        }

        private void TFCadBomba_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rbomba != null)
            {
                bsBomba.DataSource = new CamadaDados.PostoCombustivel.Cadastros.TList_BombaAbastecimento() { rbomba };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                nm_fabricante.Focus();
            }
            else
            {
                bsBomba.AddNew();
                cd_empresa.Focus();
            }
        }

        private void bb_fabricante_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_fabricante }, string.Empty);
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirBico();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirBico();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadBomba_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcCentral.SelectedTab.Equals(tpBico))
                this.InserirBico();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcCentral.SelectedTab.Equals(tpBico))
                this.AlterarBico();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcCentral.SelectedTab.Equals(tpBico))
                this.ExcluirBico();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcCentral.SelectedTab.Equals(tpLacre))
                this.InserirLacre();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcCentral.SelectedTab.Equals(tpLacre))
                this.AlterarLacre();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcCentral.SelectedTab.Equals(tpLacre))
                this.ExcluirLacre();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarBico();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.InserirLacre();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.AlterarLacre();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.ExcluirLacre();
        }

        private void gLacre_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLacre.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLacre.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba());
            CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba(lP.Find(gLacre.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLacre.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba(lP.Find(gLacre.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLacre.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLacre.List as CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba).Sort(lComparer);
            bsLacre.ResetBindings(false);
            gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba());
            CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBico.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).Sort(lComparer);
            bsBico.ResetBindings(false);
            gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gBico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gBico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
