using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using BancoDados;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Estoque;

namespace Faturamento
{
    public partial class TFLanEntregaPedido : FormPadrao.FFormPadrao
    {
        public bool Altera_Relatorio = false;
        public bool AlterarQtdeEntrada = false;
        public TFLanEntregaPedido()
        {
            InitializeComponent();
            BB_Imprimir.Visible = true;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            panelDados.set_FormatZero();
        }
        
        public override void afterNovo()
        {
            //base.afterNovo();
            Nr_Pedido.Enabled = true;
            Cd_Produto.Enabled = true;
            bb_NrPedido.Enabled = true;
            bbProduto.Enabled = true;
            QtdEntregue.Enabled = true;
            Nr_Pedido.Focus();
            BS_Registro_Pedido.Clear();
            BS_Lancamento_Item.Clear();
            tcCentral.SelectedIndex = 0;

            //limpa os campos
            Nm_Empresa.Text = "";
            Nr_cpf_cnpj.Text = "";
            NM_Clifor.Text = "";
        }

        public override void afterBusca()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                buscarRegistros();
                vTP_Modo = TTpModo.tm_busca;
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            BS_Registro_Pedido.Clear();
            BS_Lancamento_Item.Clear();
        }

        public override int buscarRegistros()
        {
            decimal ped = 0;
            if (Nr_Pedido.Text != "")
                ped = Convert.ToDecimal(Nr_Pedido.Text);

            TList_RegLanPedido_Item list = TCN_LanPedido_Item.Busca("", "", "", ped, string.Empty, "b.ds_produto asc", false);
            if (list != null)
            {
                if (list.Count > 0)
                {
                    this.Lista = list;
                    BS_Registro_Pedido.DataSource = list;
                }

                return list.Count;
            }

            return 0;
        }

        public override void afterGrava()
        {
            base.afterGrava();
        }

        public override void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BindDados = new BindingSource();
                    BindDados.DataSource = TCN_LanPedido_Item.Busca("", "", "", Convert.ToDecimal(Nr_Pedido.Text), string.Empty, "b.ds_produto asc", true);
                    Rel.DTS_Relatorio = BindDados;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.Parametros_Relatorio.Add("CD_CLIFOR", CD_Clifor.Text);
                    Rel.Parametros_Relatorio.Add("NM_CLIFOR", NM_Clifor.Text);
                    Rel.Parametros_Relatorio.Add("CGC", Nr_cpf_cnpj.Text);

                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pDestinatarios,
                                                    fImp.pPrioridade,
                                                    "RELATORIO " + this.Text.Trim(),
                                                    fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pDestinatarios,
                                                    fImp.pPrioridade,
                                                    "RELATORIO " + this.Text.Trim(),
                                                    fImp.pDs_mensagem);
                }
            }

        private void bb_NrPedido_Click(object sender, EventArgs e)
        {
            string vColunas = "b.nm_empresa|Empresa|350;" +
                              "d.cd_clifor|Cód. Clifor|80;" +
                              "d.nm_clifor|Nome Clifor|350;" +
                              "nr_cgc_cpf|CPF/CGC|350;" +
                              "a.nr_pedido|Nrº. Pedido|80;"+
                              "a.TP_Movimento|Tipo Movimento|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_Pedido, Nm_Empresa, NM_Clifor, Nr_cpf_cnpj, CD_Clifor },
                                    new TCD_Pedido(), "");

            if (Nr_Pedido.Text != "")
            {
                buscarRegistros();
            }
            else
            {
                BS_Registro_Pedido.Clear();
                BS_Lancamento_Item.Clear();
                BS_Registro_Pedido.ResetBindings(true);
            }
        }

        private void Nr_Pedido_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.nr_pedido|=|'" + Nr_Pedido.Text + "'",
                                    new Componentes.EditDefault[] { Nr_Pedido, Nm_Empresa, NM_Clifor, Nr_cpf_cnpj, CD_Clifor }, 
                                    new TCD_Pedido());

            if (Nr_Pedido.Text != "")
            {
                buscarRegistros();
            }
            else
            {
                BS_Registro_Pedido.Clear();
                BS_Lancamento_Item.Clear();
                BS_Registro_Pedido.ResetBindings(true);
            }
            //vTP_Modo = TTpModo.tm_Insert;
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            string vParamFixo = " |EXISTS|(select  1 from tb_fat_pedido_Itens b where a.cd_produto = b.cd_produto and b.nr_pedido = " + Nr_Pedido.Text + " )";
            if (Nr_Pedido.Text == "")
                vParamFixo = "";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_Produto, Ds_Produto }, vParamFixo);
            buscarRegistros();
        }

        private void Cd_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_Produto.Text + "'",
                                    new Componentes.EditDefault[] { Cd_Produto, Ds_Produto }, new TCD_CadProduto());
        }

        private void Busca_Entregue()
        {
            QtdEntregue.Enabled = false;
            dtEntrega.Enabled = false;
            Nm_Responsavel.Enabled = false;
            Observacao.Enabled = false;

            BS_Lancamento_Item.Clear();

            if (BS_Registro_Pedido.Current != null)
            {
                (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).EntregaPedido =
                    tcn.Busca("", Nr_Pedido.Text, (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto, (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Id_pedidoitem.ToString(), false, "", 0, null);
                BS_Registro_Pedido.ResetBindings(true);
                BS_Lancamento_Item.ResetBindings(true);
                TList_LanEntregaPedido lista = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).EntregaPedido;

                TotalEntrada.Value = Convert.ToDecimal(lista.Where(p => p.Tp_Movimento.Equals("E")).Sum(p => p.QTD_Entregue));
                TotalSaida.Value = Convert.ToDecimal(lista.Where(p => p.Tp_Movimento.Equals("S")).Sum(p => p.QTD_Entregue));
            }

        }

        #region "BOTOES ENTREGA"

            private void btn_NovaEntrega_Click(object sender, EventArgs e)
            {
                //HABILITA OS BOTÕES
                QtdEntregue.Enabled = true;
                dtEntrega.Enabled = true;
                Nm_Responsavel.Enabled = true;
                Observacao.Enabled = true;
                QtdEntregue.Text = "";
                dtEntrega.Text = "";
                Nm_Responsavel.Text = "";
                Observacao.Text = "";

                //DA O FOCO NO BOTÃO
                QtdEntregue.Focus();

                //GERA UM NOVO REGISTRO NO BIND E GRID
                BS_Lancamento_Item.AddNew();
                (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).NR_Pedido = Convert.ToDecimal((BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Nr_pedido);
                (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).CD_Produto = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto;
                (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).DS_Produto = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Ds_produto;
                (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).Sigla_Unidade = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Sg_unidade_est;
                (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).Tp_Movimento = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Tp_Movimento;
            }

            private void btn_CancelarEntrega_Click(object sender, EventArgs e)
            {
                bool Cancelar = true;
                if (BS_Lancamento_Item.Current != null)
                {
                    if ((BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).ID_Entrega != null)
                    {
                        if (Convert.ToDecimal((BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).ID_Entrega) > 0M)
                        {
                            Cancelar = false;
                        }
                    }
                }

                if (Cancelar)
                {
                    //HABILITA OS BOTÕES
                    QtdEntregue.Enabled = false;
                    dtEntrega.Enabled = false;
                    Nm_Responsavel.Enabled = false;
                    Observacao.Enabled = false;
                    QtdEntregue.Text = "";
                    dtEntrega.Text = "";
                    Nm_Responsavel.Text = "";
                    Observacao.Text = "";

                    //GERA UM NOVO REGISTRO NO BIND E GRID
                    BS_Lancamento_Item.CancelEdit();
                }
                else
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        string retorno = TCN_LanEntregaPedido.Deleta_LanEntregaPedido(BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido, null);

                        if (retorno == "OK")
                        {
                            BS_Lancamento_Item.RemoveCurrent();
                            limparDados();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível cancelar a entrega, provavelmente esta entrega já tem lançamento em estoque!");
                        }
                    }
                }
                Busca_Entregue();
            }

            private void btn_ConfirmarEntrega_Click(object sender, EventArgs e)
            {
                if(AlterarQtdeEntrada)
                {
                    //g_Itens.Focus();

                    if (Convert.ToDecimal(QtdEntregue.Value) <= 0M)
                    {
                        MessageBox.Show("Por favor, informe a quantidade a ser entregue/recebida!");
                        QtdEntregue.Enabled = true;
                        QtdEntregue.Focus();
                    }
                    else
                    if (dtEntrega.Text.Length == 0)
                    {
                        MessageBox.Show("Por favor, informe a data de entrega/recebimento!");
                        dtEntrega.Enabled = true;
                        dtEntrega.Focus();
                    }
                    else
                    if (Nm_Responsavel.Text.Length == 0)
                    {
                        MessageBox.Show("Por favor, informe o nome do responsável pela entrega/recebimento!");
                        dtEntrega.Enabled = true;
                        Nm_Responsavel.Focus();
                    }
                    else
                    {
                        (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).Id_pedidoitem = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Id_pedidoitem;
                        (BS_Lancamento_Item).ResetBindings(true);
                        TCN_LanEntregaPedido.Grava_LanEntregaPedido(BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido, null);

                        //SE TIVER REGISTRO NO ESTOQUE E FOR ALTERADO A QUANTIDADE ENTREGUE ELE ALTERA
                        if((BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).CD_Empresa != "" &&
                            (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).CD_Produto != "" &&
                            (BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido).ID_LanctoEstoque != 0)
                        TCN_LanEntregaPedido.Altera_LanEntregaPedido(BS_Lancamento_Item.Current as TRegistro_LanEntregaPedido,null);
                        AlterarQtdeEntrada = false;
                        Busca_Entregue();
                        

                    }
                }
            }

            private void Btn_AlterarQtde_Click(object sender, EventArgs e)
            {
                if (BS_Lancamento_Item.Current != null)
                {
                    QtdEntregue.Enabled = true;
                    dtEntrega.Enabled = true;
                    Nm_Responsavel.Enabled = true;
                    Observacao.Enabled = true;
                    AlterarQtdeEntrada = true;
                }
            }

            private void Btn_Cancelar_Click(object sender, EventArgs e)
            {
                Busca_Entregue();
            }


        #endregion

        public void limparDados()
        {
            Busca_Entregue();
            QtdEntregue.Enabled = false;
            dtEntrega.Enabled = false;
            Nm_Responsavel.Enabled = false;
            Observacao.Enabled = false;
            QtdEntregue.Text = "";
            dtEntrega.Text = "";
            Nm_Responsavel.Text = "";
            Observacao.Text = "";
            QtdEntregue.Focus();
        }

        private void tabEntrega_Enter(object sender, EventArgs e)
        {
            if (tcCentral.SelectedIndex == 1 && BS_Registro_Pedido.Current != null && !(BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto.Equals("")
                 && !(BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Cd_produto.Equals("0"))
            {
                Busca_Entregue();

                if ((BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Tp_Movimento.Equals("S"))
                {
                    string status = (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Quantidade.ToString() +" "+
                                    (BS_Registro_Pedido.Current as TRegistro_LanPedido_Item).Sg_unidade_est.ToString();
                    labelQTD.Visible = true;
                    labelQuantidade.Visible = true;
                    labelQuantidade.Text = status;
                    labelStatusPedido.Text = "Saída";
                }
                else
                {
                    labelQuantidade.Visible = false;
                    labelQTD.Visible = false;
                    labelStatusPedido.Text = "Entrada";
                }
            }
            else
            {
                tcCentral.SelectedIndex = 0;
                MessageBox.Show("É necessário selecionar um produto para fazer a entrega!");
            }
        }

        private void TFLanEntregaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                btn_NovaEntrega_Click(null, null);
            }
            else
            if (e.KeyCode == Keys.F11)
            {
                btn_ConfirmarEntrega_Click(null, null);
            }
            else
            if (e.KeyCode == Keys.F12)
            {
                btn_CancelarEntrega_Click(null, null);
            }
            else
                if (e.Control &&(e.KeyCode == Keys.P))
                {
                    Altera_Relatorio = true;
                    //MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
                }
        }

        private void TS_ItensPedido_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
        

    }
}
