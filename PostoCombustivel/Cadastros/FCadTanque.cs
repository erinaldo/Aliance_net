using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.PostoCombustivel.Cadastros;
using CamadaNegocio.PostoCombustivel.Cadastros;
using Utils;

namespace PostoCombustivel.Cadastros
{
    public partial class TFCadTanque : FormCadPadrao.FFormCadPadrao
    {
        public TFCadTanque()
        {
            InitializeComponent();
            DTS = bsTanque;

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("ATIVO", "A"));
            cbx.Add(new TDataCombo("CANCELADO", "C"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";
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
            if (qtd_armazenagem.Focused)
                (bsTanque.Current as TRegistro_TanqueCombustivel).Capacidadetanque = qtd_armazenagem.Value;
            return TCN_TanqueCombustivel.Gravar((bsTanque.Current as TRegistro_TanqueCombustivel), null);
        }

        public override void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                base.afterGrava();
        }

        public override int buscarRegistros()
        {
            TList_TanqueCombustivel lista = TCN_TanqueCombustivel.Buscar(id_tanque.Text,
                                                                         cd_empresa.Text,
                                                                         cd_local.Text,
                                                                         cd_prod.Text,
                                                                         string.Empty,
                                                                         null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsTanque.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsTanque.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsTanque.AddNew();
            base.afterNovo();
            if (!id_tanque.Focus())
                cd_empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsTanque.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            cd_prod.Focus();
        }

        public override void excluirRegistro()
        {
            if (bsTanque.Current != null)
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_TanqueCombustivel.Excluir(bsTanque.Current as TRegistro_TanqueCombustivel, null);
                        bsTanque.RemoveCurrent();
                        pDados.LimparRegistro();
                    }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100";
            string vParam = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_local.Text))
                vParam += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.cd_local = '" + cd_local.Text.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_local.Text))
                vParam += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.cd_local = '" + cd_local.Text.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }
                
        private void bb_local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = 
                new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_prod.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_prod.Text);
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { cd_local, ds_local },
                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_prod.Text : string.Empty, cd_empresa.Text), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = 
                new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_prod.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_prod.Text);

            FormBusca.UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_local.Text + "';isnull(a.st_registro, 'A')|<>|'C'",
                new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_prod.Text : string.Empty, cd_empresa.Text));
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prod, ds_prod, sigla_unidade }, vParam);
        }

        private void cd_prod_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_prod.Text.Trim() + "';"+
                            "isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_prod, ds_prod, sigla_unidade },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gTanque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gTanque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsTanque.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_TanqueCombustivel());
            CamadaDados.PostoCombustivel.Cadastros.TList_TanqueCombustivel lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_TanqueCombustivel(lP.Find(gTanque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gTanque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_TanqueCombustivel(lP.Find(gTanque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gTanque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsTanque.List as CamadaDados.PostoCombustivel.Cadastros.TList_TanqueCombustivel).Sort(lComparer);
            bsTanque.ResetBindings(false);
            gTanque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gTanque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gTanque.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gTanque.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void st_registro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (st_registro.SelectedValue == null ? false : st_registro.SelectedValue.ToString().Equals("C"))
            {
                lblAtivacao.Visible = false;
                dt_ativacao.Visible = false;
                lblDtDesativacao.Visible = true;
                dt_desativacao.Visible = true;
            }
            else
            {
                lblAtivacao.Visible = true;
                dt_ativacao.Visible = true;
                lblDtDesativacao.Visible = false;
                dt_desativacao.Visible = false;
                dt_desativacao.Clear();
            }
        }
    }
}
