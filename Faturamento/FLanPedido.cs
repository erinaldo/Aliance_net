using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Querys;
using Querys.Diversos;
using Querys.Financeiro;
using Querys.Faturamento;
using Querys.Fiscal;
using Querys.Graos;
using Querys.Estoque;
using Utils;
using Componentes;
using FormBusca;
using System.Data.SqlClient;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using System.Collections;

namespace Faturamento
{
    public partial class TFLanPedido : Form
    {
        enum TTpPed { tpSTANDBY, tpFATURAMENTO, tpSERVICO };
        
        public TFLanPedido()
        {
            InitializeComponent();
        }
        private Utils.TTpModo TPModo = TTpModo.tm_Standby;
        private string vST_AlteraFISCAL;
        private string vST_AlteraFINAN;                

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("cd_empresa|=|'" + CD_Empresa.Text + "';" +
                                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
                , new Componentes.EditDefault[] { CD_Empresa }, new TDatEmpresa());
        }
        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
                            , new Componentes.EditDefault[] { CD_Empresa }
                            , new TDatEmpresa(),
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
        }        
        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TDatClifor());
        }
        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                            , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TDatClifor(), null);            
            
        }
        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new TDatEndereco());

        }
        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;c.DS_UF|Estado|150"
                            , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade }, new TDatEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text + "'");            
        }

        private void CFG_Fiscal(string vCFG_pedido)
        {
            TDatCFG_PedidoFiscal QTB_CFGFiscal = new TDatCFG_PedidoFiscal();
            DataTable tbfis = new DataTable();
            TpBusca[] busca = new TpBusca[1];
            TRegistro_Pedido rgped = (bindingSource_PedidoCab.DataSource as TList_Pedido)[dataGridNavegador.CurrentRow.Index];
            busca[0].vNM_Campo = "a.CFG_Pedido";
            busca[0].vOperador = "=";
            busca[0].vVL_Busca = "'"+vCFG_pedido+"'";
            tbfis = QTB_CFGFiscal.Buscar(busca, 0);
            
            if (tbfis.Rows.Count > 0)
            {
                if (bindingSource_Fiscal.Count > 0) 
                {
                    for (int x = 0; x < bindingSource_Fiscal.Count; x++)
                        bindingSource_Fiscal.RemoveAt(x);
                }

                for (int x = 0; x < tbfis.Rows.Count; x++)
                {
                    bindingSource_Fiscal.AddNew();
                    rgped.Pedido_Fiscal[x].Nr_pedido = Nr_Pedido.Value;
                    rgped.Pedido_Fiscal[x].Cd_cmistring = tbfis.Rows[x]["CD_CMI"].ToString();
                    rgped.Pedido_Fiscal[x].ds_cmi = tbfis.Rows[0]["DS_CMI"].ToString();
                    rgped.Pedido_Fiscal[x].Cd_movtostring = tbfis.Rows[x]["CD_Movto"].ToString();
                    rgped.Pedido_Fiscal[x].ds_movimentacao = tbfis.Rows[x]["DS_CMI"].ToString();
                    rgped.Pedido_Fiscal[x].Nr_serie = tbfis.Rows[x]["Nr_Serie"].ToString();
                    rgped.Pedido_Fiscal[x].Ds_SerieNf = tbfis.Rows[x]["Ds_Movimentacao"].ToString();
                    rgped.Pedido_Fiscal[x].St_registro = "A";
                    rgped.Pedido_Fiscal[x].Tp_fiscal = tbfis.Rows[x]["TP_Fiscal"].ToString();                   
                }
            }
        
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            DataRow[] linha = new DataRow[1];
            string vLogin = TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
            string cond = "";
            if (rbEntrada.Checked)
                cond = "a.CFG_Pedido|=|'" + CFG_Pedido.Text + "';a.TP_Movimento|=|'E'";
            else
                cond = "a.CFG_Pedido|=|'" + CFG_Pedido.Text + "';a.TP_Movimento|=|'S'";

            linha[0] = UtilPesquisa.EDIT_LEAVE(cond
                , new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido }, new TDatCFG_Pedidos("SqlCodeBuscaXUsuario",vLogin));
            if (linha[0] != null)
            {
                vST_AlteraFISCAL = linha[0]["ST_PermiteCFG_Fiscal"].ToString();
                if (vST_AlteraFISCAL == "N") { toolStrip_ItemFiscal.Enabled = false; Pn_Fiscal.HabilitarControls(false, TPModo); }
                vST_AlteraFINAN = linha[0]["ST_PermiteCFG_Finan"].ToString();
                if (vST_AlteraFINAN == "N") 
                { 
                    Pn_Financeiro.HabilitarControls(false, TPModo); 
                }

                CFG_Fiscal(CFG_Pedido.Text);
            }
        }
        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vLogin = TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
            string cond = "";
            if (rbEntrada.Checked)
                cond = "a.TP_Movimento|=|'E'";
            else
                cond = "a.TP_Movimento|=|'S'";

            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;a.CFG_Pedido|CD. CFG Pedido|80"
                            , new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido }, new TDatCFG_Pedidos("SqlCodeBuscaXUsuario", vLogin), cond);
        }

        private void CD_Vendedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Vendedor|=|'" + CD_CompVend.Text + "'"
                , new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new TCD_CadVendedor());
        }
        private void BB_Vendedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("NomeVendedor|Nome do Vendedor|300;CD_Vendedor|Cd. Vendedor|80"
                            , new Componentes.EditDefault[] { CD_CompVend, NM_CompVend }, new TCD_CadVendedor(),
                            null); 
        }
        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_TabelaPreco|=|'" + CD_TabelaPreco.Text + "'"
                , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco }, new TDatTabelaPreco());
        }
        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                            , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco }, new TDatTabelaPreco(),
                            null);
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            string cond;
            cond = "CD_CondPgto|=|'" + CD_CondPGTO.Text + "'";

            UtilPesquisa.EDIT_LEAVE(cond
                , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPgto }, new TDatCondPgto());
        }
        private void BB_CondPgto_Click(object sender, EventArgs e)
        {
            string cond;
            cond = "";
            UtilPesquisa.BTN_BUSCA("DS_CondPgto|Ds Cond Pgto|300;CD_CondPgto|CD.CondPgto|80"
                            , new Componentes.EditDefault[] { CD_CondPGTO, DS_CondPgto }, new TDatCondPgto(),
                            cond); 
        }
        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Moeda|=|'" + CD_Moeda.Text + "'"
                , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda }, new TDatMoeda());
        }
        private void BB_Moeda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Moeda_singular|Ds Moeda|300;CD_Moeda|CD.Moeda|80"
                            , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda }, new TDatMoeda(),
                            null); 
        }

        private void Nr_Serie_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.Nr_Serie|=|'" + Nr_Serie.Text + "'"
                , new Componentes.EditDefault[] { Nr_Serie, DS_Serie }, new TDatSerieNF());
        }
        private void BB_Serie_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_SerieNF|Ds Serie NF|300;NR_Serie|Nr.Serie|80"
                            , new Componentes.EditDefault[] { Nr_Serie, DS_Serie }, new TDatSerieNF(),
                            null);
        }
        private void CD_Movto_Leave(object sender, EventArgs e)
        {
            string cond = "";
            if (rbEntrada.Checked) 
            {
                if (TP_Fiscal.SelectedIndex == 2) 
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'S'"; 
                else
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'E'";                  

            };
            if (rbSaida.Checked) 
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'E'";
                else
                    cond = "a.CD_Movimentacao|=|'" + CD_Movto.Text + "';a.Tp_Movimento|=|'S'";
            };

            UtilPesquisa.EDIT_LEAVE( cond, new Componentes.EditDefault[] { CD_Movto, DS_Movto }, new TDatMovimentacao());
        }
        private void BB_Movto_Click(object sender, EventArgs e)
        {
            string cond = "";
            if (rbEntrada.Checked) 
            { 
                if (TP_Fiscal.SelectedIndex == 2) 
                    cond = "a.Tp_Movimento|=|'S'"; 
                else
                    cond = "a.Tp_Movimento|=|'E'"; 
            };
            if (rbSaida.Checked) 
            {
                if (TP_Fiscal.SelectedIndex == 2)
                    cond = "a.Tp_Movimento|=|'E'";
                else
                    cond = "a.Tp_Movimento|=|'S'";
            };            
            UtilPesquisa.BTN_BUSCA("DS_Movimentacao|Ds Movimentação|300;CD_Movimentacao|Cd.Movimentação|80"
                            , new Componentes.EditDefault[] { CD_Movto, DS_Movto }, new TDatMovimentacao(),
                            cond);
        }
        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            string cond = "";
            if (TP_Fiscal.SelectedIndex == 0) //NORMAL
            { 
                cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'"+CD_Movto.Text+"'";
            }
            else if (TP_Fiscal.SelectedIndex == 1) //COMPLEMENTO
            { 
                cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'"+CD_Movto.Text+"';a.ST_Complementar|=|'S'";
            }
            else if (TP_Fiscal.SelectedIndex == 2) //DEVOLUCAO
            { 
                cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'"+CD_Movto.Text+"';a.ST_Devolucao|=|'S'";
            }
            else if (TP_Fiscal.SelectedIndex == 3) //FUTURA
            { 
                cond = "a.CD_CMI|=|'" + CD_CMI.Text + "';f.cd_Movimentacao|=|'"+CD_Movto.Text+"';a.ST_Mestra|=|'S'";
            }

            UtilPesquisa.EDIT_LEAVE( cond, new Componentes.EditDefault[] { CD_CMI, DS_CMI }, new TDatCMI("SqlCodeBuscaCMI_X_MOV"));
        }
        private void BB_CMI_Click(object sender, EventArgs e)
        {
            string cond = "";
            if (TP_Fiscal.SelectedIndex == 0) //NORMAL
            {
                cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "'";
            }
            else if (TP_Fiscal.SelectedIndex == 1) //COMPLEMENTO
            {
                cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Complementar|=|'S'";
            }
            else if (TP_Fiscal.SelectedIndex == 2) //DEVOLUCAO
            {
                cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Devolucao|=|'S'";
            }
            else if (TP_Fiscal.SelectedIndex == 3) //FUTURA
            {
                cond = "f.cd_Movimentacao|=|'" + CD_Movto.Text + "';a.ST_Mestra|=|'S'";
            }            
            UtilPesquisa.BTN_BUSCA("DS_CMI|Ds CMI|300;CD_CMI|Cd.CMI|80"
                            , new Componentes.EditDefault[] { CD_CMI, DS_CMI }, new TDatCMI("SqlCodeBuscaCMI_X_MOV"),
                            cond);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
                UtilPesquisa.EDIT_LEAVE("a.CD_Produto|=|'" + CD_Produto.Text + "'"
                    , new Componentes.EditDefault[] { CD_Produto, DS_Produto }, new TDatProduto());
        }
        private void BB_Produto_Click(object sender, EventArgs e)
        {
                UtilPesquisa.BTN_BUSCA("a.DS_Produto|Ds Produto|300;CD_Produto|Cd.Produto|80"
                                , new Componentes.EditDefault[] { CD_Produto, DS_Produto }, new TDatProduto(),
                                null);
        }
        private void CD_Variedade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Variedade|=|'" + CD_Variedade.Text + "';a.cd_Produto|=|'" + CD_Produto.Text + "'"
                , new Componentes.EditDefault[] { CD_Variedade, DS_Variedade }, new TDatVariedade());

        }
        private void BB_Variedade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Variedade|Ds Variedade|300;CD_Variedade|Cd.Variedade|80"
                            , new Componentes.EditDefault[] { CD_Variedade, DS_Variedade }, new TDatVariedade(),
                            "a.CD_Produto|=|'" + CD_Produto.Text + "'");
        }
        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Unidade|=|'" + CD_Unidade.Text + "'"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UnidVLR }, new TDatUnidade());
        }
        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Unidade|Ds Unidade|300;CD_Unidade|Cd.Unidade|80;Sigla_Unidade|Unid|60"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UnidVLR }, new TDatUnidade(),
                null);
        }        
               

        private void tabPedidoVenda_Enter(object sender, EventArgs e)
        {
            if ((TPModo == TTpModo.tm_Insert) || (TPModo == TTpModo.tm_Edit))
            {
                if ((bindingSource_Venda.Count == 0))  
                    bindingSource_Venda.AddNew();                
                CD_CompVend.Focus();
            }
        }

        private void PreparaBotoes(TTpModo pModo)
        {
            if (pModo == TTpModo.tm_Standby)
            {
                BB_Novo.Visible = true;
                BB_Alterar.Visible = false;
                BB_Cancelar.Visible = false;
                BB_Gravar.Visible = false;
                BB_Excluir.Visible = false;
                BB_Buscar.Visible = true;
            }
            else if (pModo == TTpModo.tm_Insert)
            {
                BB_Novo.Visible = false;
                BB_Alterar.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = true;
                BB_Excluir.Visible = false;
                BB_Buscar.Visible = true;
            }
            else if (pModo == TTpModo.tm_Edit)
            {
                BB_Novo.Visible = false;
                BB_Alterar.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = true;
                BB_Excluir.Visible = false;
                BB_Buscar.Visible = false;
            }
            else if (pModo == TTpModo.tm_busca)
            {
                BB_Novo.Visible = true;
                BB_Alterar.Visible = true;
                BB_Cancelar.Visible = true;
                BB_Gravar.Visible = false;
                BB_Excluir.Visible = true;
                BB_Buscar.Visible = true;
            };

        }
        private void TFLanPedido_Load(object sender, EventArgs e)
        {
            
            TPModo = TTpModo.tm_Standby;            
            tabControl_op.SelectedTab = tabPage_Navegador;

            ArrayList CBox3 = new ArrayList();
            CBox3.Add(new Utils.TDataCombo("N - Lançamentos Normais", "N"));
            CBox3.Add(new Utils.TDataCombo("C - Lançamentos de Complementos", "C"));
            CBox3.Add(new Utils.TDataCombo("D - Lançamentos de Devoluções", "D"));
            CBox3.Add(new Utils.TDataCombo("F - Lançamentos de Entregas Futuras", "F"));
            TP_Fiscal.DataSource = CBox3;
            TP_Fiscal.DisplayMember = "Display";
            TP_Fiscal.ValueMember = "Value";

            
            Pn_Cabecalho.set_FormatZero();
            Pn_Dados.set_FormatZero();
            Pn_Fiscal.set_FormatZero();
            Pn_Financeiro.set_FormatZero();
            Pn_ItemPedido.set_FormatZero();

            if (rbEntrada.Checked)
                lblAgente.Text = "CD.Comprador:";
            else
                lblAgente.Text = "CD.Vendedor:";

 
        }
        private void HabilitarPaineis(bool Valor) {
            toolStrip_ItemPedido .Enabled = Valor;
            toolStrip_ItemFiscal.Enabled = Valor;
            Tp_Movimento.Enabled = Valor;

                Pn_Cabecalho.HabilitarControls(Valor, TPModo);
                Pn_Dados.HabilitarControls(Valor, TPModo);
                Pn_Fiscal.HabilitarControls(Valor, TPModo);
                Pn_Financeiro.HabilitarControls(Valor, TPModo);
                Pn_ItemPedido.HabilitarControls(Valor, TPModo);
        
        }
        private void TFLanPedido_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F2): { BB_Novo_Click(sender,e); break; }
                case (Keys.F3): { BB_Alterar_Click(sender,e); break; }
                case (Keys.F4): { BB_Gravar_Click(sender,e); break; }
                case (Keys.F5): { BB_Excluir_Click(sender,e); break; }
                case (Keys.F6): { BB_Cancelar_Click(sender,e); break; }
                case (Keys.F7): { BB_Buscar_Click(sender,e); break; }
                case(Keys.F8): { BB_Imprimir_Click(sender,e); break; }
            }

        }
        private void ZerarBindings() 
        {
            //limpar listas listas
            bindingSource_PedidoCab.DataSource = new TList_Pedido();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
                dataGridNavegador.Enabled = false;
                TPModo = TTpModo.tm_Insert;
                PreparaBotoes(TPModo);               
                ZerarBindings();
                bindingSource_PedidoCab.AddNew();                
                HabilitarPaineis(true);                
                Tp_Movimento.Focus();
        }
        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            TPModo = TTpModo.tm_Edit;
            tabControl_op.SelectedTab = tabPage_Lancamento;
            PreparaBotoes(TPModo);
            HabilitarPaineis(true);
            Tp_Movimento.Enabled = false;
            Nr_Pedido.Enabled = false;
            Nr_Pedido.ReadOnly = true;
            dataGridNavegador.Enabled = false;
            CD_Empresa.Focus();
        }
        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            TPModo = TTpModo.tm_Standby;
            PreparaBotoes(TPModo);
            tabControl_op.SelectedTab = tabPage_Navegador;            
            ZerarBindings();            
            HabilitarPaineis(false);
            dataGridNavegador.Enabled = true;            
        }
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            string ped;
            dataGridNavegador.Enabled = true;
            TRegistro_Pedido rgped = (bindingSource_PedidoCab.DataSource as TList_Pedido)[dataGridNavegador.CurrentRow.Index];

            if (TPModo == TTpModo.tm_Insert)
                rgped.ST_Pedido = 'A';
            rgped.ST_Registro = 'A';

            ped = TCN_Pedido.GravaPedido(rgped, null);
            HabilitarPaineis(false);           

            Nr_Pedido.Value = Convert.ToDecimal(Querys.TDataQuery.getPubVariavel(ped, "@P_NR_PEDIDO"));
            PreparaBotoes(TTpModo.tm_Standby);
            
        }
        private void BB_Excluir_Click(object sender, EventArgs e)
        {

        }
        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            TPModo = TTpModo.tm_busca;
            PreparaBotoes(TPModo);
            dataGridNavegador.Enabled = true;
            tabControl_op.SelectedTab = tabPage_Navegador;

            bindingSource_PedidoCab.DataSource = TCN_LanPedido.Busca(CD_Empresa.Text,
                                rbEntrada.Checked,
                                rbSaida.Checked,
                                Convert.ToInt64(Nr_Pedido.Value),
                                CD_Clifor.Text,
                                CD_Endereco.Text, DS_ObsPedido.Text, 
                                Nr_PedidoOrigem.Text, DT_Pedido.Text, 
                                CFG_Pedido.Text);
            
            if (dataGridNavegador.CurrentRow != null)
                CalculaTotalPedido();

            //retirar o foco dos campos para conseguir desabilita-los
            tabControl_Geral.Focus();
            HabilitarPaineis(false);            
        }
        private void BB_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void CalculaTotalPedido()
        {
            TList_RegLanPedido_Item lst = (bindingSource_PedidoCab.DataSource as TList_RegLanPedido)[dataGridNavegador.CurrentRow.Index].PedidoItens;
            Vl_Total.Value = 0;
            for (Int16 x = 0; x < lst.Count; x++)
            {
                Vl_Total.Value += lst[x].Vl_subtotal - lst[x].Vl_desc;
            }
        }

        private void panelDados1_Leave(object sender, EventArgs e)
        {
            if (TPModo == TTpModo.tm_Insert)
              CD_Empresa.Focus();
        }


        private void toolStrip_InsereFis_Click(object sender, EventArgs e)
        {
            if ((TPModo == TTpModo.tm_Insert) || (TPModo == TTpModo.tm_Edit))
            {
                if ((bindingSource_Fiscal.Count < 4))
                    bindingSource_Fiscal.AddNew();
                BarraBotoesItem(toolStrip_ItemFiscal, TTpModo.tm_Insert);
                dataGrid_Fiscal.Enabled = false;
            }
        }
        private void toolStrip_DeletaFis_Click(object sender, EventArgs e)
        {
            //remover item DE FISCAL do banco de dados
            TCN_LanPedido_Fiscal.DeletaPedido_Fiscal((bindingSource_PedidoCab.DataSource as TList_RegLanPedido)
                               [dataGridNavegador.CurrentRow.Index].PedidoFiscal [dataGrid_Fiscal.CurrentRow.Index]);

            //remover item de memoria
            bindingSource_Fiscal.RemoveAt(dataGrid_Fiscal.CurrentRow.Index);
            BarraBotoesItem(toolStrip_ItemFiscal, TTpModo.tm_Standby);

        }
        private void toolStrip_SalvaFis_Click(object sender, EventArgs e)
        {
            dataGrid_Fiscal.Enabled = true;
            //setando o nr_pedido igual ao pedido principal
            (bindingSource_PedidoCab.DataSource as TList_RegLanPedido)[dataGridNavegador.CurrentRow.Index].PedidoFiscal [dataGrid_Fiscal.CurrentRow.Index].Nr_pedido = Nr_Pedido.Value;
            BarraBotoesItem(toolStrip_ItemFiscal, TTpModo.tm_Standby);
            dataGrid_Fiscal.Enabled = true;
            Nr_Serie.Focus();

        }

        private void BarraBotoesItem(ToolStrip barra, TTpModo modo)
        {
            if (modo == TTpModo.tm_Insert)
            {
                barra.Items[0].Enabled = false;
                barra.Items[1].Enabled = true;
                barra.Items[2].Enabled = true;
            }
            else 
            {
                barra.Items[0].Enabled = true;
                barra.Items[1].Enabled = true;
                barra.Items[2].Enabled = false;
            }
        }

        private void BB_InsereItem_Click(object sender, EventArgs e)
        {
            dataGridItens.Enabled = false;
            BindingSource_pedidoItens.AddNew();
            BarraBotoesItem(toolStrip_ItemPedido, TTpModo.tm_Insert);
            dataGridItens.Enabled = false;
            CD_Produto.Focus();
        }
        private void BB_GravaItem_Click(object sender, EventArgs e)
        {
            dataGridItens.Enabled = true;
            //setando o nr_pedido igual ao pedido principal
            (bindingSource_PedidoCab.DataSource as TList_RegLanPedido)[dataGridNavegador.CurrentRow.Index].PedidoItens[dataGridItens.CurrentRow.Index].Nr_pedido = Nr_Pedido.Value;
            //CALCULAR O VALOR TOTAL DO PEDIDO.
            CalculaTotalPedido();
            BarraBotoesItem(toolStrip_ItemPedido, TTpModo.tm_Standby);
            dataGridItens.Enabled = true;
        }
        private void BB_DeletaItem_Click(object sender, EventArgs e)
        {
            //remover item DE FATURAMENTO do banco de dados
            TCN_LanPedido_Item.DeletaPedido_Item((bindingSource_PedidoCab.DataSource as TList_RegLanPedido)
                               [dataGridNavegador.CurrentRow.Index].PedidoItens[dataGridItens.CurrentRow.Index]);
            //remover item de memoria
            BindingSource_pedidoItens.RemoveAt(dataGridItens.CurrentRow.Index);
            BarraBotoesItem(toolStrip_ItemPedido, TTpModo.tm_Standby);
            dataGridItens.Enabled = true;
        }

        private void Vl_SubTotal_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotalPedido();
        }
        private void Vl_DescontoItem_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotalPedido();
        }

        private void Tp_Movimento_Leave(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}