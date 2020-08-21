using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using Utils;
using FormBusca;

namespace Estoque.Cadastros
{
    public partial class TFCadAssistenteVenda : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public bool St_alterar
        { get; set; }

        private TRegistro_CadAssistenteVenda rvenda;
        public TRegistro_CadAssistenteVenda rVenda
        {
            get
            {
                if (bsAssistente.Current != null)
                    return bsAssistente.Current as TRegistro_CadAssistenteVenda;
                else
                    return null;
            }
            set { rvenda = value; }
        }

        public TFCadAssistenteVenda()
        {
            InitializeComponent();
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.St_alterar = false;
        }

        private void HabilitaCamposGravar()
        {
            CD_ProdVenda.Enabled = true;
            BB_ProdVenda.Enabled = true;
            DS_ProdVenda.Enabled = true;
            bb_novo.Visible = false;
            bb_alterar.Visible = false;
            bb_excluir.Visible = false;
            btn_Gravar.Visible = true;
            if (!St_alterar)
            {
                CD_ProdVenda.Text = string.Empty;
                DS_ProdVenda.Text = string.Empty;
            }


        }

        private void DesabilitaCamposGravar()
        {
            bb_novo.Visible = true;
            bb_alterar.Visible = true;
            bb_excluir.Visible = true;
            btn_Gravar.Visible = false;
            CD_ProdVenda.Enabled = false;
            BB_ProdVenda.Enabled = false;
            DS_ProdVenda.Enabled = false;
        }

        private void afterBusca()
        {
            bsAssistente.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca(Cd_produto,
                                                                                                   CD_ProdVenda.Text,
                                                                                                   null);
            this.DesabilitaCamposGravar();
        }

        private void TFCadAssistenteVenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gAssistente);
            CD_Produto.Text = Cd_produto;
            DS_Produto.Text = Ds_produto;
            this.afterBusca();
        }

        private void TFCadAssistenteVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gAssistente);
        }

        private void bb_novo_Click(object sender, EventArgs e)
        {
            St_alterar = false;
            bsAssistente.AddNew();
            CD_Produto.Text = Cd_produto;
            DS_Produto.Text = Ds_produto;
            this.HabilitaCamposGravar();
            bb_novo.Visible = false;
            bb_alterar.Visible = false;
            bb_excluir.Visible = false;
            btn_Gravar.Visible = true;
        }

        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_ProdVenda.Text))
            {
                try
                {
                    CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Gravar(rVenda, null);
                    MessageBox.Show("Produto gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DesabilitaCamposGravar();
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            if (bsAssistente.Current != null)
            {
                try
                {
                    St_alterar = true;
                    CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Excluir(rVenda, null);
                    this.HabilitaCamposGravar();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            if (bsAssistente.Current != null)
                if (MessageBox.Show("Confirma exclusão da configuração?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Excluir(rVenda, null);
                        MessageBox.Show("Produto excluído com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_ProdVenda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_ProdVenda, DS_ProdVenda }, string.Empty);
        }

        private void CD_ProdVenda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Produto|=|'" + CD_ProdVenda.Text + "'",
                                new Componentes.EditDefault[] { CD_ProdVenda, DS_ProdVenda },
                                new TCD_CadProduto());
        }
    }
}
