using System;
using System.Data;
using System.Windows.Forms;
using Utils;
using System.Collections;
using FormBusca;
using System.Drawing;

namespace Restaurante.Cadastro
{
    public partial class FProduto : Form
    {
        private bool Altera_Relatorio = false;

        public FProduto()
        {
            InitializeComponent();
        }
        private void afterbusca()
        {

            TpBusca[] filtro = new TpBusca[0];
            Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'C'", st_cancelado.Checked ? "=" : "<>");
            if (!string.IsNullOrEmpty(CD_Produto.Text.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = CD_Produto.Text.Trim();
            }
            if (!string.IsNullOrEmpty(DS_Produto.Text.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Produto";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + DS_Produto.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(CD_Grupo.Text.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Grupo.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(TP_Produto.Text.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + TP_Produto.Text.Trim() + "'";
            }
            CamadaDados.Restaurante.Cadastro.TList_CFG lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            Hashtable hs = new Hashtable(2);
            hs.Add("@CD_TABELAPRECO", lcfg[0].cd_tabelapreco);
            hs.Add("@CD_EMPRESA", lcfg[0].cd_empresa);
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0,
                string.Empty, string.Empty, string.Empty, hs);
            bsProduto.ResetCurrentItem();
        }

        public void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = bsProduto;
                Rel.Nome_Relatorio = "TFCadProduto";
                Rel.NM_Classe = "TFCadProduto";
                Rel.Modulo = "EST";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO " + Text.Trim();

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO " + Text.Trim(),
                                       fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       null,
                                       fImp.pDestinatarios,
                                       "RELATORIO " + Text.Trim(),
                                       fImp.pDs_mensagem);
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using(FCadProduto prod = new FCadProduto())
            {
                if(prod.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_Produto.Gravar(prod.rProduto, null);
                    MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterbusca();
                }
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            using (FCadProduto prod = new FCadProduto())
            {
                prod.rProduto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto);
                if (prod.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_Produto.Gravar(prod.rProduto, null);
                    MessageBox.Show("Produto alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                afterbusca();
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if(bsProduto.Current != null)
                if(MessageBox.Show("Deseja excluir o produto?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Excluir((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto), null);
                    afterbusca();
                }
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Produto},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());

        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80;" +
                              "ST_RegAnvisa|Farmacêutico|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Produto},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void FProduto_Load(object sender, EventArgs e)
        {

            Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void FProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                BB_Novo_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F3))
                BB_Alterar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5))
                BB_Excluir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F7))
                bbBuscar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if(e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void gProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                    if (e.Value.ToString().Trim().ToUpper().Equals("TRUE"))
                        gProduto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gProduto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }
    }
}
