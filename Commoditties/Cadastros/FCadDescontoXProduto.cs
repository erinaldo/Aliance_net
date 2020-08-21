using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Graos;
using CamadaDados.Graos;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Utils;

namespace Commoditties.Cadastros
{
    public partial class TFCadDescontoXProduto : FormCadPadrao.FFormCadPadrao
    {
        public TFCadDescontoXProduto()
        {
            InitializeComponent();
            DTS = BS_CadDescontoxProduto;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            
        }

        public override void afterBusca()
        {
            base.afterBusca();
            BB_Alterar.Enabled = false;
        }

        public override void afterExclui()
        {
            base.afterExclui();
            BB_Alterar.Enabled = false;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadDescontoxProduto.Grava_CadDescontoProduto(BS_CadDescontoxProduto.Current as TRegistro_CadDescontoxProduto);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_CadDescontoxProduto lista = TCN_CadDescontoxProduto.Busca(CD_TabelaDesconto.Text.Trim(), 
                                                                            CD_Produto.Text.Trim(), "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadDescontoxProduto.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadDescontoxProduto.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadDescontoxProduto.AddNew();
                base.afterNovo();
                CD_TabelaDesconto.Focus();
                BB_Alterar.Enabled = false;
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadDescontoxProduto.RemoveCurrent();

            BB_Alterar.Enabled = false;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            //bb_TabelaDesconto.Enabled = false;
            //bb_Produto.Enabled = false;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadDescontoxProduto.Deleta_CadDescontoxProduto(BS_CadDescontoxProduto.Current as TRegistro_CadDescontoxProduto);
                    BS_CadDescontoxProduto.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }
       
        private void CD_TabelaDesconto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_TabelaDesconto|=|'" + CD_TabelaDesconto.Text + "'",
                new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto}, new TCD_CadDesconto());
        }

        private void bb_TabelaDesconto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_tabelaDesconto|Descrição|200;CD_TabelaDesconto|Cód.TabelaDesconto|80",
                new Componentes.EditDefault[] { CD_TabelaDesconto, ds_tabelaDesconto}, new TCD_CadDesconto(), null);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, ds_produto },
                                    new TCD_CadProduto());
        }

        private void bb_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, ds_produto },"");
        }

        private void TFCadDescontoXProduto_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }  
    }
}

