using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empreendimento.Cadastro
{
    public partial class TFCadCFGEmpreendimento : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGEmpreendimento()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Empreendimento.Cadastro.TCN_CadCFGEmpreendimento.Gravar(bsEmpreendimento.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadCFGEmpreendimento, null);
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsEmpreendimento.AddNew();
            base.afterNovo();
            if (!cd_empresa.Focus())
                cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            cd_empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsEmpreendimento.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            CamadaDados.Empreendimento.Cadastro.TList_CadCFGEmpreendimento lista = CamadaNegocio.Empreendimento.Cadastro.TCN_CadCFGEmpreendimento.Busca(cd_empresa.Text,string.Empty,null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsEmpreendimento.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                        bsEmpreendimento.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadCFGEmpreendimento.Excluir(bsEmpreendimento.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadCFGEmpreendimento, null);
                    bsEmpreendimento.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo pedido|200;" +
                              "a.cfg_pedido|Cfg. Pedido|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, DS_TIPOPEDIDO },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(),
               string.Empty);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, DS_TIPOPEDIDO },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo pedido|200;" +
                              "a.cfg_pedido|Cfg. Pedido|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CFG_SERVICO, ds_servico },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(),
               "isnull(a.st_servico, 'N')|=|'S'");
        }

        private void CFG_SERVICO_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + CFG_SERVICO.Text.Trim() + "';isnull(a.st_servico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_SERVICO, ds_servico },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void TFCadCFGEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "a.ds_tabelapreco|Tabela Preço|150;" +
                "a.cd_tabelapreco|Código|50",
                new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(),
                string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_unidade|Unidade|150;" +
                               "a.cd_unidade|Código|50",
                               new Componentes.EditDefault[] { cd_unidade, editDefault4 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                               string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_unidade|=|" + cd_unidade.Text + "",
               new Componentes.EditDefault[] { cd_unidade, editDefault4 },
               new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void TFCadCFGEmpreendimento_Load(object sender, EventArgs e)
        {
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("Custo Medio", "0"));
            cbx.Add(new Utils.TDataCombo("Tabela Preco", "1")); 
            cbtipoprecoitem.DataSource = cbx;
            cbtipoprecoitem.DisplayMember = "Display";
            cbtipoprecoitem.ValueMember = "Value";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_local|local|150;" +
                               "a.cd_local|Código|50",
                               new Componentes.EditDefault[] { editDefault1, editDefault2 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(),
                               string.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_local|=|" + editDefault1.Text + "",
               new Componentes.EditDefault[] { editDefault1, editDefault2 },
               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_tpduplicata|local|150;" +
                               "a.tp_duplicata|Código|50",
                               new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                               new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(),
                               string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.tp_duplicata|=|" + tp_duplicata.Text + "",
              new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
              new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_TPDocto|local|150;" +
                               "a.TP_Docto|Código|50",
                               new Componentes.EditDefault[] { TP_Docto, editDefault5 },
                               new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(),
                               string.Empty);
        }

        private void TP_Docto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.TP_Docto|=|" + TP_Docto.Text + "",
              new Componentes.EditDefault[] { TP_Docto, editDefault5 },
              new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void pDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.CD_PRODUTO|Cd. Produto|80";
            string vparam = "e.st_servico|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_PRODUTO, editDefault3 },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto(),
               vparam);
        }

        private void CD_PRODUTO_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.CD_PRODUTO|=|" + CD_PRODUTO.Text + "",
              new Componentes.EditDefault[] { CD_PRODUTO, editDefault3 },
              new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string vColunas = "a.ds_tprequisicao|Tp Requisição|200;" +
                              "a.id_tprequisicao|Cd. Tp Requisição|80";
            //string vparam = "e.st_servico|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault6, editDefault7 },
                new CamadaDados.Compra.TCD_TpRequisicao(),
               string.Empty);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string vColunas = "a.ds_tprequisicao|Tp Requisição|200;" +
                              "a.id_tprequisicao|Cd. Tp Requisição|80";
            //string vparam = "e.st_servico|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault8, editDefault9 },
                new CamadaDados.Compra.TCD_TpRequisicao(),
               string.Empty);
        }

        private void editDefault6_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.id_tprequisicao|=|" + editDefault6.Text + "",
              new Componentes.EditDefault[] { editDefault6, editDefault7 },
              new CamadaDados.Compra.TCD_TpRequisicao());
        }

        private void editDefault8_Leave(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.id_tprequisicao|=|" + editDefault8.Text + "",
              new Componentes.EditDefault[] { editDefault8, editDefault9 },
              new CamadaDados.Compra.TCD_TpRequisicao());
        }
    }
}
