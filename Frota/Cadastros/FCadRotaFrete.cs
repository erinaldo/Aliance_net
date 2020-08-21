using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFCadRotaFrete : FormCadPadrao.FFormCadPadrao
    {
        public TFCadRotaFrete()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Frota.Cadastros.TCN_RotaFrete.Gravar(
                    bsRotaFrete.Current as CamadaDados.Frota.Cadastros.TRegistro_RotaFrete, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Frota.Cadastros.TList_RotaFrete lista =
                CamadaNegocio.Frota.Cadastros.TCN_RotaFrete.Buscar(string.Empty,
                                                                   string.Empty,
                                                                   cd_cidadeOrigem.Text,
                                                                   cd_cidadeDestino.Text,
                                                                   cd_unidFrete.Text,
                                                                   null);
                                                                         

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsRotaFrete.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsRotaFrete.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsRotaFrete.AddNew();
                base.afterNovo();
                if (!id_rota.Focus())
                    ds_rota.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsRotaFrete.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_rota.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão da Rota?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Frota.Cadastros.TCN_RotaFrete.Excluir(
                        bsRotaFrete.Current as CamadaDados.Frota.Cadastros.TRegistro_RotaFrete, null);
                    bsRotaFrete.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_origem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|80;" +
                              "a.distrito|Distrito|100;" +
                              "b.uf|UF|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadeOrigem, ds_cidadeOrigem, uf_origem },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
               string.Empty);
        }

        private void cd_cidadeOrigem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadeOrigem.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadeOrigem, ds_cidadeOrigem, uf_origem },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_destino_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Codigo|80;" +
                              "a.distrito|Distrito|100;" +
                              "b.uf|UF|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadeDestino, ds_cidadeDestino, uf_destino },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(),
               string.Empty);
        }

        private void cd_cidadeDestino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadeDestino.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadeDestino, ds_cidadeDestino, uf_destino},
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_unidFrete_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|200;" +
                              "a.cd_unidade|Codigo|80;" +
                              "a.sigla_unidade|Sigla|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_unidFrete, ds_unidfrete, sigla_unidade },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
               string.Empty);
        }

        private void cd_unidFrete_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidFrete.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_unidFrete, ds_unidfrete, sigla_unidade },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void TFCadRotaFrete_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRotaFrete);
            this.pDados.set_FormatZero();
        }

        private void TFCadRotaFrete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRotaFrete);
        }

        private void gRotaFrete_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRotaFrete.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsRotaFrete.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_RotaFrete());
            CamadaDados.Frota.Cadastros.TList_RotaFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRotaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRotaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_RotaFrete(lP.Find(gRotaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRotaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_RotaFrete(lP.Find(gRotaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRotaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsRotaFrete.List as CamadaDados.Frota.Cadastros.TList_RotaFrete).Sort(lComparer);
            bsRotaFrete.ResetBindings(false);
            gRotaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
