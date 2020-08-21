using CamadaDados.Faturamento.Orcamento;
using CamadaNegocio.Estoque;
using Producao;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFProjEspeciais : Form
    {
        public TList_Orcamento_Item lItem =>
            bsItensOrcamento.Count > 0 ? bsItensOrcamento.DataSource as TList_Orcamento_Item : null;
        public TFProjEspeciais()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            gItens.EndEdit();
            DialogResult = DialogResult.OK;
        }

        private void PreencherFicha(string pCd_produto)
        {
            //Buscar Ficha Formula
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFichaTec =
            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(pCd_produto, string.Empty, null);
            if (lFichaTec.Exists(p => string.IsNullOrEmpty(p.Cd_local)))
            {
                string vColunas = "a.ds_local|Local Armazenagem|150;" +
                             "a.cd_local|Código|50";
                string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                "           where x.cd_local = a.cd_local and x.cd_empresa = '" + (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Cd_empresa.Trim() + "')";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
                try
                {
                    if (linha != null)
                    {
                        lFichaTec.ForEach(p =>
                        {
                            p.Cd_local = string.IsNullOrEmpty(p.Cd_local) ? linha["cd_local"].ToString() : p.Cd_local;
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Gravar(p, null);
                        });
                    }
                    else
                        PreencherFicha(pCd_produto);
                }
                catch { }
            }
            lFichaTec.ForEach(p =>
            {
                (bsItensOrcamento.Current as TRegistro_Orcamento_Item).lFichaTec.Add(
                        new TRegistro_FichaTecOrcItem()
                        {
                            Nr_orcamento = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Nr_orcamento,
                            Id_item = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Id_item,
                            Cd_item = p.Cd_item,
                            Ds_item = p.Ds_item,
                            Cd_local = p.Cd_local,
                            Ds_local = p.Ds_local,
                            Sg_unditem = p.Sg_unditem,
                            Cd_unditem = p.Cd_unditem,
                            Ds_unditem = p.Ds_unditem,
                            Quantidade = p.Quantidade,
                            SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local((bsItensOrcamento.Current as TRegistro_Orcamento_Item).Cd_empresa, p.Cd_item, p.Cd_local, null),
                            Vl_custo = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsItensOrcamento.Current as TRegistro_Orcamento_Item).Cd_empresa, p.Cd_produto, null),
                            Vl_ultimacompra = TCN_LanEstoque.BuscarVlUltimaCompra((bsItensOrcamento.Current as TRegistro_Orcamento_Item).Cd_empresa, p.Cd_produto, null)
                        });
            });
            bsItensOrcamento.ResetCurrentItem();
        }

        private void TFProjEspeciais_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bsItensOrcamento.DataSource = new TCD_Orcamento_Item().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.st_projespecial",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FAT_Orcamento x " +
                                    "where x.nr_orcamento = a.nr_orcamento " +
                                    "and isnull(x.st_registro, 'AB') = 'AB') "
                    }
                }, 0, string.Empty);
            bsItensOrcamento_PositionChanged(this, new EventArgs());
        }

        private void bsItensOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensOrcamento.Current != null)
            {
                (bsItensOrcamento.Current as TRegistro_Orcamento_Item).lFichaTec =
                        new TCD_FichaTecOrcItem().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.Nr_orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Nr_orcamento.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.Id_item",
                                vOperador = "=",
                                vVL_Busca = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Id_item.ToString()
                            }
                        }, 0, string.Empty);
                bsItensOrcamento.ResetCurrentItem();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFProjEspeciais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void gItens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gItens[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gItens.EndEdit();
        }

        private void gItens_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != (char)44)
                e.Handled = true;
            else if (e.KeyChar == ',')
                if (((TextBox)sender).Text.Contains(","))
                    e.Handled = true;
        }

        private void gFicha_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsFichaTec[e.RowIndex] as TRegistro_FichaTecOrcItem).Quantidade >
                        (bsFichaTec[e.RowIndex] as TRegistro_FichaTecOrcItem).SaldoEstoque)
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
                    else
                    {
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gFicha.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                    }
            }
        }

        private void bbAdd_Click(object sender, EventArgs e)
        {
            if(bsItensOrcamento.Current != null)
                using (TFItensFichaTec fItens = new TFItensFichaTec())
                {
                    if (fItens.ShowDialog() == DialogResult.OK)
                        if (fItens.rFicha != null)
                        {
                            fItens.rFicha.Nr_orcamento = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Nr_orcamento;
                            fItens.rFicha.Id_item = (bsItensOrcamento.Current as TRegistro_Orcamento_Item).Id_item;
                            fItens.rFicha.SaldoEstoque = TCN_LanEstoque.Busca_Saldo_Local((bsItensOrcamento.Current as TRegistro_Orcamento_Item).Cd_empresa, fItens.rFicha.Cd_item, fItens.rFicha.Cd_local, null);
                            (bsFichaTec.List as TList_FichaTecOrcItem).Add(fItens.rFicha);
                            bsFichaTec.ResetBindings(true);
                        }
                }
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
                if (MessageBox.Show("Confirma a exclusão do Item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Excluir(bsFichaTec.Current as TRegistro_FichaTecOrcItem, null);
                        MessageBox.Show("Item excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsFichaTec.Remove(bsFichaTec.Current as TRegistro_FichaTecOrcItem);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_copiarFicha_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Count > 0)
            {
                if (MessageBox.Show("Se a fórmula for modificada você pode perder as alterações na ficha,\r\n" +
                                         "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                         == DialogResult.Yes)
                {
                    string vParam = "isnull(e.st_industrializado, 'N')|=|'S'";
                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(null, vParam);
                    CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.ExcluirLista(bsFichaTec.DataSource as TList_FichaTecOrcItem, null);
                    bsFichaTec.Clear();
                    this.PreencherFicha(linha["cd_produto"].ToString());
                }
            }
            else
            {
                string vParam = "isnull(e.st_industrializado, 'N')|=|'S'";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(null, vParam);
                this.PreencherFicha(linha["cd_produto"].ToString());
            }
        }

        private void gFicha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void gFicha_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gFicha[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gFicha.EndEdit();
        }
    }
}
