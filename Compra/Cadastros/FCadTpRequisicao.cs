using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compra.Cadastros
{
    public partial class TFCadTpRequisicao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTpRequisicao()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("INTERNA", "I"));
            cbx.Add(new Utils.TDataCombo("EXTERNA", "E"));
            tp_requisicao.DataSource = cbx;
            tp_requisicao.DisplayMember = "Display";
            tp_requisicao.ValueMember = "Value";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            TS_ItensPedido.Enabled = (vTP_Modo == Utils.TTpModo.tm_Insert) || (vTP_Modo == Utils.TTpModo.tm_Edit);
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsTpRequisicao.AddNew();
                base.afterNovo();
                if (!id_tprequisicao.Focus())
                    ds_tprequisicao.Focus();
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsTpRequisicao.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                ds_tprequisicao.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsTpRequisicao.Current != null)
            {
                try
                {
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    {
                        if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                        {
                            CamadaNegocio.Compra.TCN_TpRequisicao.Excluir(bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao, null);
                            bsTpRequisicao.RemoveCurrent();
                            pDados.LimparRegistro();
                            afterBusca();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Não existem itens cadastrados", "Mensagem");
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return CamadaNegocio.Compra.TCN_TpRequisicao.Gravar(bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Compra.TList_TpRequisicao lista =
                CamadaNegocio.Compra.TCN_TpRequisicao.Buscar(id_tprequisicao.Text,
                                                             ds_tprequisicao.Text,
                                                             tp_requisicao.SelectedValue != null ? tp_requisicao.SelectedValue.ToString() : string.Empty,
                                                             null);
            bsTpRequisicao_PositionChanged(this, new EventArgs());
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTpRequisicao.DataSource = Lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsTpRequisicao.Clear();
                return lista.Count;
            }
            else return 0;
        }

        private void gTpRequisicao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTpRequisicao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTpRequisicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Compra.TRegistro_TpRequisicao());
            CamadaDados.Compra.TList_TpRequisicao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTpRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTpRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Compra.TList_TpRequisicao(lP.Find(gTpRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTpRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Compra.TList_TpRequisicao(lP.Find(gTpRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTpRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTpRequisicao.List as CamadaDados.Compra.TList_TpRequisicao).Sort(lComparer);
            bsTpRequisicao.ResetBindings(false);
            gTpRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            if (bsTpRequisicao.Current != null)
            {
                string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                             "a.CD_Grupo|Cód. Grupo|100";
                string vParamFixo = "a.TP_Grupo|=|'A';" +
                                    "|NOT EXISTS|(select 1 from TB_CMP_TpRequisicao_X_GrupoProd x " +
                                    "             where a.cd_grupo = x.cd_grupo )";        
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null,
                                        new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);

                if (linha != null)
                {
                    CamadaDados.Compra.TRegistro_TpRequisicao_X_GrupoProd val = new CamadaDados.Compra.TRegistro_TpRequisicao_X_GrupoProd();
                    val.Id_tprequisicao = (bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao).Id_tprequisicao;
                    val.Cd_grupo = linha["cd_grupo"].ToString();
                    try
                    {
                        CamadaNegocio.Compra.TCN_TpRequisicao_X_GrupoProd.Gravar(val, null);
                        MessageBox.Show("Grupo Produto gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsTpRequisicao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if (bsGrupoProd.Current != null)
                if (MessageBox.Show("Confirma a exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Compra.TCN_TpRequisicao_X_GrupoProd.Excluir(bsGrupoProd.Current as CamadaDados.Compra.TRegistro_TpRequisicao_X_GrupoProd, null);
                        MessageBox.Show("Grupo Produto excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsTpRequisicao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bsTpRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsTpRequisicao.Current != null)
            {
                (bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao).lGrupoProd =
                    CamadaNegocio.Compra.TCN_TpRequisicao_X_GrupoProd.Buscar((bsTpRequisicao.Current as CamadaDados.Compra.TRegistro_TpRequisicao).Id_tprequisicaostr,
                                                                             string.Empty,
                                                                             null);
                bsTpRequisicao.ResetCurrentItem();
            }
        }
    }
}
