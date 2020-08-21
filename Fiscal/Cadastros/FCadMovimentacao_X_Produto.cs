using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;

namespace Fiscal.Cadastros
{
    public partial class TFCadMovimentacao_X_Produto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMovimentacao_X_Produto()
        {
            InitializeComponent();
            this.DTS = bsMovimentacao;    
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_Mov_X_Produto.Gravar(bsMovimentacao.Current as TRegistro_Mov_X_Produto, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_Mov_X_Produto lista = TCN_Mov_X_Produto.Buscar(CD_Movimentacao.Text,
                                                                 CD_Produto.Text,
                                                                 null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMovimentacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsMovimentacao.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                bsMovimentacao.AddNew();
            base.afterNovo();
            CD_Movimentacao.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_Movimentacao.Enabled = false;
            bb_produto.Enabled = false;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsMovimentacao.RemoveCurrent();
        }

        private void bb_Movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                              "a.CD_Movimentacao|Cód. Movimentação|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), "");
        }

        private void CD_Movimentacao_Leave(object sender, EventArgs e)
        {
            if (CD_Movimentacao.Text.Trim() != "")
            {
                string vColunas = "a." + CD_Movimentacao.NM_CampoBusca + "|=|'" + CD_Movimentacao.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Movimentacao, ds_Movimentacao },
                                        new CamadaDados.Fiscal.TCD_CadMovimentacao());
            }
            else
                ds_Movimentacao.Clear();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParamFixo = "|NOT EXISTS|(Select 1 From TB_FIS_Movimentacao_X_Produto x " +
                                "Where x.CD_Produto = a.CD_Produto and x.CD_Movimentacao = '" + CD_Movimentacao.Text + "')";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, ds_produto },vParamFixo);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            if (CD_Produto.Text.Trim() != "")
            {
                string vColunas = "a." + CD_Produto.NM_CampoBusca + "|=|'" + CD_Produto.Text + "';" +
                                  "|NOT EXISTS|(Select 1 From TB_FIS_Movimentacao_X_Produto x " +
                                    "Where x.CD_Produto = a.CD_Produto and x.CD_Movimentacao = '" + CD_Movimentacao.Text + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, ds_produto },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            }
            else
                ds_produto.Clear();
        }

        private void TFCadMovimentacao_X_Produto_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }
    }
}

