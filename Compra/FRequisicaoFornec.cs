using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Compra
{
    public partial class TFRequisicaoFornec : Form
    {
        private bool Altera_Relatorio = false;
        public TFRequisicaoFornec()
        {
            InitializeComponent();
        }

        private void afterPrint()
        {
            if (bsClifor.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    BindingSource BD_REQ = new BindingSource();
                    BD_REQ.DataSource =
                        new CamadaDados.Compra.Lancamento.TCD_Requisicao().Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                        "inner join TB_EST_Produto y " +
                                        "on x.cd_grupo = y.cd_grupo " +
                                        "where y.cd_produto = a.cd_produto " +
                                        "and x.CD_Clifor = '" + (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor.Trim() + "'" +
                                        "and a.ST_Requisicao in ('AC', 'RN')) "
                        }
                    }, 0, string.Empty, string.Empty);
                    BindingSource bd_clifor = new BindingSource();
                    bd_clifor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadClifor() { bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor };
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bd_clifor;
                    Rel.Adiciona_DataSource("REQ", BD_REQ);
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "CMP";
                    Rel.Ident = this.Name;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                    fImp.pMensagem = "RELATORIO DE REQUISIÇÕES POR FORNECEDOR";

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
                                           "RELATORIO DE REQUISIÇÕES POR FORNECEDOR",
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
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO DE REQUISIÇÕES POR FORNECEDOR",
                                           fImp.pDs_mensagem);
                }
            }
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            //Buscar~somente fornecedores das requisições aguardando cotação ou renegociar
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                            "inner join TB_EST_GrupoProduto y " +
                                            "on x.cd_grupo = y.cd_grupo " +
                                            "inner join TB_EST_Produto k " +
                                            "on k.cd_grupo = y.cd_grupo " +
                                            "inner join TB_CMP_Requisicao l " +
                                            "on l.cd_produto = k.cd_produto " +
                                            "where x.CD_Clifor = a.CD_Clifor " +
                                            "and l.ST_Requisicao in ('AC', 'RN'))";
            if (!string.IsNullOrEmpty(cd_fornecedor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_fornecedor.Text + "'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_CMP_Fornec_X_GrupoItem x " +
                                                        "inner join TB_EST_GrupoProduto y " +
                                                        "on x.cd_grupo = y.cd_grupo " +
                                                        "inner join TB_EST_Produto k " +
                                                        "on k.cd_grupo = y.cd_grupo " +
                                                        "inner join TB_CMP_Requisicao l " +
                                                        "on l.cd_produto = k.cd_produto " +
                                                        "where x.CD_Clifor = a.CD_Clifor " +
                                                        "and l.cd_produto = '" + cd_produto.Text + "'" +
                                                        "and l.ST_Requisicao in ('AC', 'RN'))";
            }
            if (cbCotacao.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_CMP_Cotacao x " +
                                                        "where x.cd_fornecedor = a.cd_clifor )";
            }
            if (cbCompras.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                      "where x.cd_clifor = a.cd_clifor " +
                                                      "and x.tp_movimento = 'E' " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' )";
            }
            //Buscar Fornecedores
            bsClifor.DataSource =
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(filtro, 0, string.Empty);
            bsClifor.ResetCurrentItem();
        }

        private void TFRequisicaoFornec_Load(object sender, EventArgs e)
        {
            pFiltro.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca(); 
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFRequisicaoFornec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_x_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, vParam);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S';" +
                            "|exists|(select 1 from tb_cmp_fornec_X_grupoitem x " +
                            "       where x.cd_clifor = a.cd_clifor )";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vCond = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vCond, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }
    }
}
