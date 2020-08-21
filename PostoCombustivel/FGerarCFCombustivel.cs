using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFGerarCFCombustivel : Form
    {
        public string Cd_empresa
        { get; set; }

        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFGerarCFCombustivel()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Empresa
            filtro[0].vNM_Campo = "vr.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            //Venda Ativa
            filtro[1].vNM_Campo = "isnull(vr.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'C'";
            //Nao ter gerado cupom
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "not exists";
            filtro[2].vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_vendarapida " +
                                  "and x.id_lanctovenda = a.id_lanctovenda)";
            //Nao ter gerado pedido
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                  "inner join TB_FAT_Pedido y " +
                                  "on x.nr_pedido = y.nr_pedido " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_vendarapida " +
                                  "and x.id_lanctovenda = a.id_lanctovenda " +
                                  "and isnull(y.st_pedido, 'F') <> 'C')";
            //Item nao pode ser servico
            filtro[4].vNM_Campo = "isnull(tp.st_servico, 'N')";
            filtro[4].vOperador = "<>";
            filtro[4].vVL_Busca = "'S'";
            //Cupom finalizador somente de produto combustivel
            if (st_combustivel.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(tp.st_combustivel, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (!string.IsNullOrEmpty(id_venda.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_venda.Text;
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "vr.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(tp_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "tp.tp_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(login.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                      "where x.id_pdv = a.id_pdv " +
                                                      "and x.id_sessao = a.id_sessao " +
                                                      "and x.login = '" + login.Text.Trim() + "')";
            }
            if (vl_inicial.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "vr.vl_cupom";
                filtro[filtro.Length - 1].vVL_Busca = vl_inicial.Value.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if (vl_final.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "vr.vl_cupom";
                filtro[filtro.Length - 1].vVL_Busca = vl_final.Value.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (st_vendacaixaaberto.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                      "inner join tb_pdv_caixa y " +
                                                      "on x.id_caixa = y.id_caixa " +
                                                      "where x.id_cupom = a.id_cupom " +
                                                      "and isnull(y.st_registro, 'A') = 'A')";
            }
            CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lItem = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(filtro, 0, string.Empty, string.Empty);
            tot_venda.Value = lItem.Sum(p => p.Vl_subtotal);
            tot_desconto.Value = lItem.Sum(p => p.Vl_desconto);
            tot_liquido.Value = lItem.Sum(p => p.Vl_subtotalliquido);
            bsItens.DataSource = lItem;
        }

        private void TFGerarCFCombustivel_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            CD_Empresa.Text = Cd_empresa;
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
        
        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, st_combustivel.Checked ? "isnull(e.st_combustivel, 'N')|=|'S'" : string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            if(st_combustivel.Checked)
                vParam += ";isnull(e.st_combustivel, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vParam, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_login_Click(object sender, EventArgs e)
        {
            string vColunas = "a.login|Login|100;" +
                              "a.nome_usuario|Nome Usuario|200";
            string vParam = "a.Tp_Registro|=|'U'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { login },
                                            new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
        }

        private void login_Leave(object sender, EventArgs e)
        {
            string vParam = "a.login|=|'" + login.Text.Trim() + "';" +
                            "a.tp_registro|=|'U'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { login },
                                                new CamadaDados.Diversos.TCD_CadUsuario());
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

        private void gVenda_CellClick(object sender, DataGridViewCellEventArgs e)
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
        
        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFGerarCFCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
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

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|TP. Produto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(),
                                            string.Empty);
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void TFGerarCFCombustivel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
