using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace PDV
{
    public partial class TFGerarCupomNFe : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.DataSource as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public string Cd_empresa
        { get { return cbEmpresa.SelectedValue.ToString(); } }
        public string Cd_clifor
        { get { return cd_clifor.Text; } }

        public bool St_habilitarNfConsumo
        { get; set; }
        public bool St_gerarNfConsumo
        { get; set; }
        public bool St_NFCe
        { get; set; }

        public TFGerarCupomNFe()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(id_cupom.Text) && cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            
            //Venda Ativa
            filtro[0].vNM_Campo = "isnull(vr.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            //Nao ter gerado cupom 
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "not exists";
            filtro[1].vVL_Busca = "(select 1 from TB_PDV_Cupom_X_VendaRapida x " +
                                  "inner join TB_PDV_NFCe y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.id_cupom = y.id_nfce " +
                                  "and isnull(y.st_registro, 'A') <> 'C' " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_vendarapida " +
                                  "and x.id_lanctovenda = a.id_lanctovenda)";
            //Nao ter gerado pedido
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "not exists";
            filtro[2].vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                  "inner join TB_FAT_NotaFiscal_Item y " +
                                  "on x.nr_pedido = y.nr_pedido " +
                                  "and x.cd_produto = y.cd_produto " +
                                  "and x.id_pedidoitem = y.id_pedidoitem " +
                                  "inner join TB_FAT_NotaFiscal z " +
                                  "on y.cd_empresa = z.cd_empresa " +
                                  "and y.nr_lanctofiscal = z.nr_lanctofiscal " +
                                  "and isnull(z.st_registro, 'A') <> 'C' " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_vendarapida " +
                                  "and x.id_lanctovenda = a.id_lanctovenda)";
            //Cliente Cupom
            string vFiltroClifor = "(vr.cd_clifor = '" + cd_clifor.Text.Trim() + "' or vr.nm_clifor like '%" +
                (nm_clifor.Text.Trim().Length > 50 ? nm_clifor.Text.Trim().Substring(0, 50) : nm_clifor.Text.Trim()) + "%')";
            if (st_filtrocliente.Checked)
                vFiltroClifor += "or(isnull(vr.nm_clifor, '') = '') or " +
                                 "(vr.nm_clifor = (select top 1 y.NM_Clifor " +
                                 "					from TB_PDV_CFGCupomFiscal x " +
                                 "					inner join TB_FIN_Clifor y " +
                                 "					on x.CD_Clifor = y.CD_Clifor " +
                                 "					where x.CD_Empresa = a.CD_Empresa)) or " +
                                 "(vr.CD_Clifor = (select top 1 y.CD_Clifor " +
                                 "					from TB_PDV_CFGCupomFiscal x " +
                                 "					inner join TB_FIN_Clifor y " +
                                 "					on x.CD_Clifor = y.CD_Clifor " +
                                 "					where x.CD_Empresa = a.CD_Empresa))";
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = string.Empty;
            filtro[3].vVL_Busca = vFiltroClifor;
            //Nao ter gerado NF Entrega Futura
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vOperador = "not exists";
            filtro[4].vVL_Busca = "(select 1 from TB_PDV_VendaRapida_X_EntregaFutura x " +
                                  "inner join TB_FAT_NotaFiscal y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                  "where isnull(y.st_registro, 'A') <> 'C' " +
                                  "and x.cd_empresa = a.cd_empresa " +
                                  "and x.id_cupom = a.id_vendarapida " +
                                  "and x.id_lancto = a.id_lanctovenda)";
            if (!string.IsNullOrEmpty(id_cupom.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cupom.Text;
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            //Empresa
            if (cbEmpresa.SelectedValue != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "vr.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + "'";
            }
            bsItens.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(filtro, 0, string.Empty, string.Empty);
            tot_venda.Value = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p=> p.Vl_subtotalliquido);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.DataSource as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).ForEach(p => p.St_processar = cbProcessar.Checked);
                tot_cupom.Value = (bsItens.DataSource as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotalliquido);
                bsItens.ResetBindings(true);
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFGerarCupomNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
            {
                St_gerarNfConsumo = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFGerarCupomNFe_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            bb_nfconsumo.Visible = St_habilitarNfConsumo;
            Utils.TpBusca[] vParam = new Utils.TpBusca[1];
            vParam[0].vNM_Campo = string.Empty;
            vParam[0].vOperador = "exists";
            vParam[0].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (St_NFCe)
            {
                Array.Resize(ref vParam, vParam.Length + 1);
                vParam[vParam.Length - 1].vNM_Campo = string.Empty;
                vParam[vParam.Length - 1].vOperador = "exists";
                vParam[vParam.Length - 1].vVL_Busca = "(select 1 from tb_fat_cfgnfe x " +
                                                      "          where x.cd_empresa = a.cd_empresa " +
                                                      "          and isnull(x.tp_ambiente_nfce, '') <> '')";
            }
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(vParam, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_processar =
                    !(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_processar;
                bsItens.ResetCurrentItem();
                if (bsItens.Count > 0)
                    tot_cupom.Value = (bsItens.DataSource as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotalliquido);
            }
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item());
            CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_VendaRapida_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_VendaRapida_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sort(lComparer);
            bsItens.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_nfconsumo_Click(object sender, EventArgs e)
        {
            St_gerarNfConsumo = true;
            DialogResult = DialogResult.OK;
        }

        private void TFGerarCupomNFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }

        private void cd_clifor_TextChanged(object sender, EventArgs e)
        {
            nm_clifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                           new Componentes.EditDefault[] { cd_produto },
                                           new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }
    }
}
