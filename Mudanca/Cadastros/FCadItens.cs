using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Mudanca.Cadastros;
using CamadaNegocio.Mudanca.Cadastros;
using Utils;
using FormBusca;

namespace Mudanca.Cadastros
{
    public partial class TFCadItens : FormCadPadrao.FFormCadPadrao
    {
        public TFCadItens()
        {
            InitializeComponent();
            DTS = bsCadItens;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (metragemCub.Focused)
                    (bsCadItens.Current as TRegistro_CadItens).MetragemCub = metragemCub.Value;
                return TCN_CadItens.Gravar(bsCadItens.Current as TRegistro_CadItens, null);
            }
            else return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadItens lista = TCN_CadItens.Buscar(string.Empty, DS_Item.Text.Trim(),id_itempai.Text, st_sintetico.Checked ? "S" : string.Empty, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadItens.DataSource = lista;

                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsCadItens.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsCadItens.Clear();
                bsCadItens.AddNew();
                base.afterNovo();
                DS_Item.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCadItens.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            st_sintetico.Enabled = (bsCadItens.Current as TRegistro_CadItens).St_sintetico.Trim().ToUpper().Equals("N");
            id_itempai.Enabled = !(bsCadItens.Current as TRegistro_CadItens).Id_itempai.HasValue &&
                                    !(bsCadItens.Current as TRegistro_CadItens).St_sinteticobool;
            BB_Grupo.Enabled = !(bsCadItens.Current as TRegistro_CadItens).Id_itempai.HasValue &&
                                    !(bsCadItens.Current as TRegistro_CadItens).St_sinteticobool;
            if (vTP_Modo == TTpModo.tm_Edit)
                if (!id_itempai.Focus())
                    DS_Item.Focus();
        }

        public override void excluirRegistro()
        {
            if (gCadastro.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadItens.Excluir(bsCadItens.Current as TRegistro_CadItens, null);
                        bsCadItens.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void id_itempai_Leave(object sender, EventArgs e)
        {
           UtilPesquisa.EDIT_LEAVE("A.id_item|=|'" + id_itempai.Text + "';a.st_sintetico|=|'S'"
           , new Componentes.EditDefault[] { id_itempai, ds_itemPai }, new TCD_CadItens());
        }

        private void BB_Grupo_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("A.ds_item|Item Pai|350;A.id_item|Id.Item Pai|80"
                    , new Componentes.EditDefault[] { id_itempai , ds_itemPai }, new TCD_CadItens(), "a.st_sintetico|=|'S'");
        }

        private void gCadastro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 6)
                    if (e.Value.Equals(true))
                    {
                        gCadastro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gCadastro.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    }
            }
        }

        private void bb_organizar_Click(object sender, EventArgs e)
        {
            if (tsOrganizar.Visible == false)
            {
                bb_organizar.Text = "CONCLUIR";
                tsOrganizar.Visible = true;
            }
            else
            {
                bb_organizar.Text = "ORGANIZAR";
                tsOrganizar.Visible = false;
            }
        }

        private void TFCadItens_Load(object sender, EventArgs e)
        {
            tsOrganizar.Visible = false;
            bb_organizar.Text = "ORGANIZAR";
        }

        private void bb_cima_Click(object sender, EventArgs e)
        {
            if(bsCadItens.Current != null)
            {
                if ((bsCadItens.Current as TRegistro_CadItens).St_sinteticobool)
                {
                    MessageBox.Show("Não é permitido mover registro SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCadItens[bsCadItens.Position - 1] as TRegistro_CadItens).St_sinteticobool)
                {
                    MessageBox.Show("Não é permitido mover primeiro registro do grupo para CIMA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TCN_CadItens.MoverRegistros(bsCadItens.Current as TRegistro_CadItens, bsCadItens[bsCadItens.Position - 1] as TRegistro_CadItens, null);
                    bsCadItens.DataSource = TCN_CadItens.Buscar(string.Empty, string.Empty, string.Empty, st_sintetico.Checked ? "S" : string.Empty, null);
                    bsCadItens.MovePrevious();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_baixo_Click(object sender, EventArgs e)
        {
            if (bsCadItens.Current != null)
            {
                if ((bsCadItens.Current as TRegistro_CadItens).St_sinteticobool)
                {
                    MessageBox.Show("Não é permitido mover registro SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCadItens[bsCadItens.Position + 1] as TRegistro_CadItens).St_sinteticobool)
                {
                    MessageBox.Show("Não é permitido mover ultimo registro do grupo para BAIXO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TCN_CadItens.MoverRegistros(bsCadItens.Current as TRegistro_CadItens, bsCadItens[bsCadItens.Position + 1] as TRegistro_CadItens, null);
                    bsCadItens.DataSource = TCN_CadItens.Buscar(string.Empty, string.Empty, string.Empty, st_sintetico.Checked ? "S" : string.Empty, null);
                    bsCadItens.MoveNext();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
