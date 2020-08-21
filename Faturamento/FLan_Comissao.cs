using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.Comissao;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Pedido;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Duplicata;
using Utils;
using CamadaDados.Fiscal;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Duplicata;
using Financeiro;
using NumeroNota;



namespace Faturamento
{
    public partial class TFLan_Comissao : FormPadrao.FFormPadrao
    {
        public TFLan_Comissao()
        {
            InitializeComponent();

            BB_Alterar.Dispose();
            BB_Excluir.Dispose();
            BB_Gravar.Dispose();
            BB_Cancelar.Dispose();


        }
                
        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BTN_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Vendedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_Vendedor|=|'" + CD_Vendedor.Text + "'"
                , new Componentes.EditDefault[] { CD_Vendedor, NM_Vendedor }, new TCD_CadVendedor());        
        }

        private void btn_Vendedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NomeVendedor|Vendedor|250;a.cd_Vendedor|Código Vendedor|80"
                                   , new Componentes.EditDefault[] { CD_Vendedor, NM_Vendedor }, new TCD_CadVendedor(), "");
        }

        private void ID_RegiaoVenda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_regiao|=|'" + ID_RegiaoVenda.Text + "'"
                , new Componentes.EditDefault[] { ID_RegiaoVenda, NM_Regiao }, new TCD_CadRegiaoVenda());       
        }

        private void btn_regiao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_Regiao|Região de Venda|250;a.ID_regiao|Código Região|80"
                                   , new Componentes.EditDefault[] { ID_RegiaoVenda, NM_Regiao }, new TCD_CadRegiaoVenda(), "");
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TCD_CadClifor());            
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasiaa|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
                , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new TCD_CadClifor(), null);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto.Text + "'"
                , new Componentes.EditDefault[] { CD_Produto, DS_Produto }, new TCD_CadProduto());
        }

        private void btn_CD_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, "");  
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_grupo|=|'" + CD_Grupo.Text + "'"
             , new Componentes.EditDefault[] { CD_Grupo, DS_Grupo}, new TCD_CadGrupoProduto());
            
        }

        private void btn_Grupo_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Grupo|Grupo Produto|250;a.CD_Grupo|Código Grupo Produto|80"
                                , new Componentes.EditDefault[] { CD_Grupo, DS_Grupo }, new TCD_CadGrupoProduto(), "");
        }

        private void TFLan_Comissao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pnl_Consulta.set_FormatZero();
        }

        public override void afterNovo()
        {
            BS_Comissao.Clear();
            base.afterNovo();
            if (TC_Comissao.SelectedTab != TabComissao)
            {
                TC_Comissao.SelectedTab = TabComissao;
            }
        }

        public override void afterBusca()
        {
            TList_Lan_Comissao Lista_Comissao = TCN_Lan_Comissao.Busca(ID_Comissao.Text, NR_Pedido.Text, CD_Vendedor.Text, CD_Produto.Text, CD_Empresa.Text, ID_RegiaoVenda.Text,
                                                                       CD_Clifor.Text, CD_Grupo.Text, DT_Inicial.Text, DT_Final.Text,  "SqlCodeBusca_Totais_Vendedor");

            
            if (Lista_Comissao != null)
            {
                BS_Comissao.DataSource = Lista_Comissao;

                if (TC_Comissao.SelectedTab != TabComissao)
                {
                    TC_Comissao.SelectedTab = TabComissao;
                }

                Atualiza();
            }
            else
            {
            }
            
            
        }

        public override void habilitarControls(bool value)
        {
            pnl_Consulta.HabilitarControls(value, this.vTP_Modo);
        }

        private void Atualiza()
        {
            bool Atualiza = false;

            if (TC_Comissao.SelectedTab == TabComissao)
            {
            }
            else
            {
                if (TC_Comissao.SelectedTab == tabPedidoItens)
                {
                    TCN_Lan_Comissao.Busca_Comissao_PedidoItens(BS_Comissao.Current as TRegistro_Lan_Comissao);
                }
                else
                {
                    if (TC_Comissao.SelectedTab == tabPedido)
                    {
                        TCN_Lan_Comissao.Busca_Comissao_Pedido(BS_Comissao.Current as TRegistro_Lan_Comissao);
                    }
                    else
                    {
                        if (TC_Comissao.SelectedTab == tabClientes)
                        {
                            TCN_Lan_Comissao.Busca_Comissao_Cliente(BS_Comissao.Current as TRegistro_Lan_Comissao);
                        }
                        else
                        {
                            if (TC_Comissao.SelectedTab == tabProduto)
                            {
                                TCN_Lan_Comissao.Busca_Comissao_Produto(BS_Comissao.Current as TRegistro_Lan_Comissao);
                            }
                            else
                            {
                                if (TC_Comissao.SelectedTab == tabRegiaoVenda)
                                {
                                    TCN_Lan_Comissao.Busca_Comissao_RegiaoVenda(BS_Comissao.Current as TRegistro_Lan_Comissao);
                                }
                                else
                                {
                                    if (TC_Comissao.SelectedTab == tabGrupoProduto)
                                    {
                                        TCN_Lan_Comissao.Busca_Comissao_GrupoProduto(BS_Comissao.Current as TRegistro_Lan_Comissao);
                                    }
                                    else
                                    {
                                        if (TC_Comissao.SelectedTab == tabFechamento)
                                        {
                                            TCN_Lan_Comissao.Busca_Comissao_Fechamento(BS_Comissao.Current as TRegistro_Lan_Comissao);
                                            if (Atualiza == false)
                                            {
                                                BS_Comissao.ResetBindings(true);
                                            }
                                            Atualiza = true;
                                            Soma_Fechamento();
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            if (Atualiza == false)
            {
                BS_Comissao.ResetBindings(true);
            }
        }

        private void TC_Comissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void NR_Pedido_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.NR_pedido|=|" + NR_Pedido.Text + ";Exists|(select top 1 1 from tb_fat_Comissao_X_pedidoitem x where x.nr_pedido = a.nr_pedido and x.cd_produto| = a.cd_produto )"
             , new Componentes.EditDefault[] { NR_Pedido }, new TCD_LanPedido_Item());
        }

        private void btn_Pedido_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NR_Pedido|Nº Pedido|250"
                             , new Componentes.EditDefault[] { NR_Pedido }, new TCD_LanPedido_Item(), "Exists|(select top 1 1 from tb_fat_Comissao_X_pedidoitem x where x.nr_pedido = a.nr_pedido and x.cd_produto =| a.cd_produto)");
        }

        private void Gera_Faturamento()
        {
            try
            {
                if ((BS_Comissao != null) && (BS_Comissao.Count > 0))
                {
                    if ((BS_Fechamento_Comissao != null) && (BS_Fechamento_Comissao.Count > 0) && (g_Fechamento_Comissao.Rows.Count > 0))
                    {
                        try
                        {
                            if (VL_Com_Liberada.Text.Trim() == "")
                            {
                                VL_Com_Liberada.Text = "0";
                            }

                            if (Convert.ToDecimal(VL_Com_Liberada.Text) == 0)
                            {
                                throw new Exception("Não existe Valores Liberados para se Faturar!");
                            }
                        }
                        catch
                        {
                            throw new Exception("Problemas com o Valores Liberados para Faturar!");
                        }

                        if (Existe_Empresas_Diferentes() == true)
                        {
                            throw new Exception("Você deve Faturar somente Comissões de E!");
                        }

                        // Cria a Lista com os selecionados
                        TList_Lan_Comissao List_Comissao = new TList_Lan_Comissao();
                        for (int i = 0; i < g_Fechamento_Comissao.SelectedRows.Count; i++)
                        {
                            TRegistro_Lan_Comissao Reg_Lan_Comissao = BS_Fechamento_Comissao[g_Fechamento_Comissao.SelectedRows[i].Index] as TRegistro_Lan_Comissao;
                            List_Comissao.Add(Reg_Lan_Comissao);
                        }

                        TList_CadVendedor List_Vendedor = TCN_CadVendedor.Busca((BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).CD_Vendedor.ToString(), "", "", "", "", "", "", "", "", "", "");
                        TRegistro_CadVendedor Reg_Vendedor = List_Vendedor[0];
                        if (List_Vendedor.Count == 0)
                        {
                            throw new Exception("Vendedor: " + (BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).CD_Vendedor.ToString() + " - " + (BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).NM_Vendedor +  "não encontrado.");
                        }
                        
                        if (List_Vendedor[0].CD_condpgto_comissao == "")
                        {
                            throw new Exception("Vendedor: " + (BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).CD_Vendedor.ToString() + " - " + (BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).NM_Vendedor + "\r\n sem condição de Pagamento configurada. Verifique cadastro de Vendedor.");
                        }

                        string Moeda_Padrao = TCN_CadParamGer.BuscaVlString("CD_MOEDA_PADRAO");
                        if (Moeda_Padrao == "")
                        {
                            throw new Exception("Moeda Padrão não encontrado. Verificar configurações Gerais");
                        }
                        
                        string Produto_Comissao = TCN_CadParamGer.BuscaVlString("CD_PRODUTO_COMISSAO");
                        if (Produto_Comissao == "")
                        {
                            throw new Exception("Produto Comissão não encontrado. Verificar configurações Gerais");
                        }
                        TRegistro_CadProduto Reg_Produto = TCN_CadProduto.Busca_Produto_Codigo(Produto_Comissao);
                        if ((Reg_Produto == null) || (Reg_Produto.CD_Unidade == ""))
                        {
                            throw new Exception("Unidade da Comissão não encontrado. Verificar configurações Gerais");
                        }

                        string CFG_Pedido_Comissao = TCN_CadParamGer.BuscaVlString("CFG_Pedido_Comissao");
                        if (CFG_Pedido_Comissao == "")
                        {
                            throw new Exception("Configuração de Pedido de Comissão não encontrado. Verificar configurações Gerais");
                        }

                        TRegistro_CadClifor Reg_Clifor_Vendedor = new TRegistro_CadClifor();
                        Reg_Clifor_Vendedor = TCN_CadClifor.Busca_Clifor_Codigo(List_Vendedor[0].Cd_clifor);

                        TList_CadEmpresa List_Empresa = new TList_CadEmpresa();
                        TRegistro_CadEmpresa Reg_Empresa = new TRegistro_CadEmpresa();
                        List_Empresa = TCN_CadEmpresa.Busca((BS_Fechamento_Comissao.Current as TRegistro_Lan_Comissao).CD_Empresa, "", "", null);
                        Reg_Empresa = List_Empresa[0];

                        TList_CadEndereco List_Endereco = new TList_CadEndereco();
                        TRegistro_CadEndereco Reg_Endereco = new TRegistro_CadEndereco();
                        List_Endereco = TCN_CadEndereco.Buscar(List_Vendedor[0].Cd_clifor, List_Vendedor[0].Cd_endereco, "", "", "", "", "", "",
                                                               "", "", "", "", "", "", "", 0, null);
                        Reg_Endereco = List_Endereco[0];


                        TList_RegLanDuplicata Duplicata = new TList_RegLanDuplicata();
                        Duplicata = Gera_Financeiro(CFG_Pedido_Comissao, List_Vendedor[0].CD_condpgto_comissao, Moeda_Padrao, Reg_Empresa, Reg_Clifor_Vendedor, Reg_Endereco);

                        if (Duplicata == null)
                        {
                            throw new Exception("Por favor! \r\n  - Verifique os dados das Duplicatas");
                        }

                        decimal Total_Faturar = Convert.ToDecimal(VL_Com_Liberada.Text);
                        
                        bool Pode_Gravar = false;
                        bool ST_SequenciaNF = false;
                        decimal NR_Nota = 0;

                        TCD_CadCFGPedidoFiscal Pedido_Fiscal = new TCD_CadCFGPedidoFiscal();
                        TpBusca[] vBusca = new TpBusca[0];
                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = "a.cfg_pedido";
                        vBusca[vBusca.Length - 1].vVL_Busca = "'" + CFG_Pedido_Comissao + "'";
                        vBusca[vBusca.Length - 1].vOperador = "=";

                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_FISCAL";
                        vBusca[vBusca.Length - 1].vVL_Busca = "'N'";
                        vBusca[vBusca.Length - 1].vOperador = "=";

                        DataTable DT_Pedido_Fiscal = Pedido_Fiscal.Buscar(vBusca, 0);

                        if (DT_Pedido_Fiscal.Rows.Count > 0)
                        {
                            if (DT_Pedido_Fiscal.Rows[0]["nr_serie"].ToString().Trim() != string.Empty)
                            {
                                TList_CadSerieNF List_SerieNF = TCN_CadSerieNF.Busca(DT_Pedido_Fiscal.Rows[0]["nr_serie"].ToString().Trim(), 
                                                                                     string.Empty, 
                                                                                     decimal.Zero, 
                                                                                     string.Empty, 
                                                                                     string.Empty, 
                                                                                     string.Empty, 
                                                                                     string.Empty, 
                                                                                     string.Empty, 
                                                                                     string.Empty, 
                                                                                     null);
                                if (List_SerieNF.Count > 0)
                                {
                                    if (List_SerieNF[0].ST_SequenciaAutoBool == false)
                                    {
                                        TFNumero_Nota Numero_Nota = new TFNumero_Nota();
                                        Numero_Nota.pCd_empresa = Reg_Empresa.Cd_empresa;
                                        Numero_Nota.pNm_empresa = Reg_Empresa.Nm_empresa;
                                        Numero_Nota.pCd_clifor = Reg_Clifor_Vendedor.Cd_clifor;
                                        Numero_Nota.pNm_clifor = Reg_Clifor_Vendedor.Nm_clifor;
                                        Numero_Nota.pNr_serie = DT_Pedido_Fiscal.Rows[0]["nr_serie"].ToString().Trim();
                                        Numero_Nota.pDs_serie = DT_Pedido_Fiscal.Rows[0]["ds_serie"].ToString().Trim();
                                        Numero_Nota.pTp_nota = "P";
                                        if (Numero_Nota.ShowDialog() == DialogResult.OK)
                                        {
                                            NR_Nota = Numero_Nota.pNr_notafiscal;
                                            Pode_Gravar = true;
                                        }
                                        else
                                        {
                                            Pode_Gravar = false;
                                        }
                                    }
                                    else
                                    {
                                        ST_SequenciaNF = true;
                                        Pode_Gravar = true;
                                    }
                                }
                                else
                                {
                                    throw new Exception("A Configuração do Pedido:" + CFG_Pedido_Comissao + "não está correta. Vefrificar numero de série!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("A Configuração do Pedido:" + CFG_Pedido_Comissao + "não está correta");
                        }
                                                

                        if (Pode_Gravar == true)
                        {
                            TCN_Lan_Fechamento_Comissao.Gera_Faturamento(List_Comissao, NR_Nota, ST_SequenciaNF, Duplicata, Reg_Vendedor, Moeda_Padrao, Produto_Comissao, Reg_Produto, CFG_Pedido_Comissao,
                                                                         Reg_Clifor_Vendedor, Reg_Empresa, Reg_Endereco, Total_Faturar, null);
                            MessageBox.Show("Comissão Faturada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterNovo();

                        }
                        else
                        {
                            throw new Exception("De Alguma forma o processo foi cancelado!");
                        }

                        
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro: \r\n\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
            }
        }
        
        private void Soma_Fechamento()
        {
            if ((BS_Fechamento_Comissao != null) && (BS_Fechamento_Comissao.Count > 0) && (g_Fechamento_Comissao.Rows.Count > 0))
            {
                
                decimal _VL_Com_Liquidado = 0;
                decimal _VL_Com_Liberada = 0;
                decimal _VL_Com_Fechada = 0;
                decimal _VL_Com_Bloqueada = 0;
                    
                for (int i = 0; i < g_Fechamento_Comissao.SelectedRows.Count; i++)
                {
                    TRegistro_Lan_Comissao Reg_Lan_Comissao = BS_Fechamento_Comissao[g_Fechamento_Comissao.SelectedRows[i].Index] as TRegistro_Lan_Comissao;

                    _VL_Com_Liquidado += Reg_Lan_Comissao.VL_Tot_Liquidado;
                    _VL_Com_Liberada += Reg_Lan_Comissao.VL_Tot_Liberada;
                    _VL_Com_Fechada += Reg_Lan_Comissao.VL_Tot_Fechada;
                    _VL_Com_Bloqueada += Reg_Lan_Comissao.VL_Tot_Bloqueado;
                }

                VL_Com_Liquidado.Text = _VL_Com_Liquidado.ToString();
                VL_Com_Liberada.Text = _VL_Com_Liberada.ToString();
                VL_Com_Fechada.Text = _VL_Com_Fechada.ToString();
                VL_Com_Bloqueada.Text = _VL_Com_Bloqueada.ToString();


            }
        }

        private bool Existe_Empresas_Diferentes()
        {
            bool retorno = false;
            if ((BS_Fechamento_Comissao != null) && (BS_Fechamento_Comissao.Count > 0) && (g_Fechamento_Comissao.Rows.Count > 0))
            {
                string CD_Empresa = "";
                for (int i = 0; i < g_Fechamento_Comissao.SelectedRows.Count; i++)
                {
                    TRegistro_Lan_Comissao Reg_Lan_Comissao = BS_Fechamento_Comissao[g_Fechamento_Comissao.SelectedRows[i].Index] as TRegistro_Lan_Comissao;
                    if (i == 0)
                    {
                        CD_Empresa = Reg_Lan_Comissao.CD_Empresa;
                    }
                    else
                    {
                        if (CD_Empresa != Reg_Lan_Comissao.CD_Empresa)
                        {
                            return true;
                        }
                    }                    
                }                
            }
            return retorno;
        }

        private void g_Fechamento_Comissao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Soma_Fechamento();
        }

        private void BS_Fechamento_Comissao_PositionChanged(object sender, EventArgs e)
        {
            Soma_Fechamento();
        }

        private void btn_Fecha_Comissao_Click(object sender, EventArgs e)
        {
            Gera_Faturamento();
        }

        public TList_RegLanDuplicata Gera_Financeiro(string CFG_Pedido_Comissao, string CD_CondPGTO, string CD_Moeda, TRegistro_CadEmpresa Reg_Empresa, TRegistro_CadClifor Reg_Clifor_Vendedor, TRegistro_CadEndereco Reg_Endereco)
        {
            TList_RegLanDuplicata Duplicata = new TList_RegLanDuplicata();

            if (CFG_Pedido_Comissao != "")
            {

                TCD_CadCFGPedidoFiscal Pedido_Fiscal = new TCD_CadCFGPedidoFiscal();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cfg_pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CFG_Pedido_Comissao + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
                
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_FISCAL";
                vBusca[vBusca.Length - 1].vVL_Busca = "'N'";
                vBusca[vBusca.Length - 1].vOperador = "=";
              
                DataTable DT_Pedido_Fiscal = Pedido_Fiscal.Buscar(vBusca, 0);

                if (DT_Pedido_Fiscal.Rows.Count > 0)
                {
                    if (DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim() != string.Empty)
                    {
                        
                        TpBusca[] vBusca_Mov = new TpBusca[0];
                        Array.Resize(ref vBusca_Mov, vBusca_Mov.Length + 1);
                        vBusca_Mov[vBusca_Mov.Length - 1].vNM_Campo = "a.cd_movimentacao";
                        vBusca_Mov[vBusca_Mov.Length - 1].vVL_Busca = "'" + DT_Pedido_Fiscal.Rows[0]["cd_movto"].ToString().Trim() + "'";
                        vBusca_Mov[vBusca_Mov.Length - 1].vOperador = "=";

                        TList_CadMovimentacao List_Movimentacao = new TCD_CadMovimentacao().Select(vBusca_Mov, 0, "");

                        TList_CadCondPgto List_CondPagamento = TCN_CadCondPgto.Buscar(CD_CondPGTO, "", "", "", "", "", 0, 0, "", "", 1, "", null);
                        if (List_CondPagamento.Count > 0)
                        {
                            List_CondPagamento[0].lCondPgto_X_Parcelas = TCN_CadCondPgto_X_Parcelas.Buscar(List_CondPagamento[0].Cd_condpgto);
                        }

                        TRegistro_LanDuplicata Reg_Duplicata = new TRegistro_LanDuplicata();
                        TList_CadTpDuplicata List_TPDuplicata = TCN_CadTpDuplicata.Buscar(DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim(), "", "");
                        if ((DT_Pedido_Fiscal.Rows[0]["ST_Devolucao"].ToString().Trim().ToUpper() != "S") && 
                            (!List_CondPagamento[0].St_solicitardtvenctobool) && 
                            (List_CondPagamento[0].lCondPgto_X_Parcelas.Count > 0) && 
                            (List_Movimentacao[0].cd_historico.Trim() != string.Empty) &&
                            (!List_TPDuplicata[0].St_gerarboletoautobool))
                        {
                            Reg_Duplicata.Cd_empresa = Reg_Empresa.Cd_empresa.Trim();
                            Reg_Duplicata.Nm_empresa = Reg_Empresa.Nm_empresa.Trim();
                            Reg_Duplicata.Cd_clifor = Reg_Clifor_Vendedor.Cd_clifor.Trim();
                            Reg_Duplicata.Nm_clifor = Reg_Clifor_Vendedor.Nm_clifor.Trim();
                            Reg_Duplicata.Cd_endereco = Reg_Endereco.Cd_endereco.Trim();
                            Reg_Duplicata.Ds_endereco = Reg_Endereco.Ds_endereco.Trim();

                            Reg_Duplicata.Cd_historico = List_Movimentacao[0].cd_historico.Trim();
                            Reg_Duplicata.Ds_historico = List_Movimentacao[0].ds_historico.Trim();

                            Reg_Duplicata.Tp_duplicata = DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim();
                            Reg_Duplicata.Ds_tpduplicata = DT_Pedido_Fiscal.Rows[0]["ds_tpduplicata"].ToString().Trim();
                            Reg_Duplicata.Tp_mov = DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "E" ? "P" :
                                          DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "S" ? "R" : "";
                            Reg_Duplicata.Tp_docto = DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString().Trim() != string.Empty ? Convert.ToDecimal(DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString()) : 0;
                            Reg_Duplicata.Ds_tpdocto = DT_Pedido_Fiscal.Rows[0]["ds_tpdocto"].ToString().Trim();

                            

                            Reg_Duplicata.Cd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                            Reg_Duplicata.Ds_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                            Reg_Duplicata.St_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                            Reg_Duplicata.Cd_juro = List_CondPagamento[0].Cd_juro.Trim();
                            Reg_Duplicata.Ds_juro = List_CondPagamento[0].Ds_juro.Trim();
                            Reg_Duplicata.Tp_juro = List_CondPagamento[0].Tp_juro.Trim();

                            Reg_Duplicata.Cd_moeda = CD_Moeda.Trim();
                            //Reg_Duplicata.Ds_moeda = List_Dados_Pedido[0].Ds_moeda.Trim();
                            //Reg_Duplicata.Sigla_moeda = List_Dados_Pedido[0].Sigla.Trim();
                            Reg_Duplicata.Qt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                            Reg_Duplicata.Qt_parcelas = List_CondPagamento[0].Qt_parcelas;
                            Reg_Duplicata.Pc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                            Reg_Duplicata.Cd_portador = List_CondPagamento[0].Cd_portador.Trim();
                            Reg_Duplicata.Ds_portador = List_CondPagamento[0].Ds_portador.Trim();
                            Reg_Duplicata.Nr_docto = "";
                            Reg_Duplicata.Dt_emissao = DateTime.Now;
                            
                            Reg_Duplicata.Vl_documento = Convert.ToDecimal(VL_Com_Liberada.Text);
                            Reg_Duplicata.Vl_documento_padrao = Convert.ToDecimal(VL_Com_Liberada.Text);
                            
                            

                            decimal vl_saldoadto = TCN_LanAdiantamento.SaldoAdiantamentoDevolver(Reg_Empresa.Cd_empresa.Trim(), Reg_Clifor_Vendedor.Cd_clifor.Trim(), "S", null);

                            if (Reg_Duplicata.Vl_documento_padrao > 0)
                            {
                                if (Reg_Duplicata.Vl_documento_padrao > vl_saldoadto)
                                {
                                    Reg_Duplicata.cVl_adiantamento = vl_saldoadto;
                                }
                                else
                                {
                                    Reg_Duplicata.cVl_adiantamento = Reg_Duplicata.Vl_documento_padrao;
                                }
                            }
                            else
                            {
                                Reg_Duplicata.cVl_adiantamento = 0;
                            }

                            Reg_Duplicata.Parcelas = TCN_LanDuplicata.calcularParcelas(Reg_Duplicata);

                        }
                        else
                        {

                            TFLanDuplicata fDuplicata = new TFLanDuplicata();
                            
                            fDuplicata.vNr_pedido = null;
                            fDuplicata.vSt_notafiscal = true;
                            fDuplicata.vCd_empresa = Reg_Empresa.Cd_empresa.Trim();
                            fDuplicata.vNm_empresa = Reg_Empresa.Nm_empresa.Trim();
                            fDuplicata.vCd_clifor = Reg_Clifor_Vendedor.Cd_clifor.Trim();
                            fDuplicata.vNm_clifor = Reg_Clifor_Vendedor.Nm_clifor.Trim();
                            fDuplicata.vCd_endereco = Reg_Endereco.Cd_endereco.Trim();
                            fDuplicata.vDs_endereco = Reg_Endereco.Ds_endereco.Trim();
                            if (List_Movimentacao.Count > 0)
                            {
                                fDuplicata.vCd_historico = List_Movimentacao[0].cd_historico;
                                fDuplicata.vDs_historico = List_Movimentacao[0].ds_historico;
                            }

                            fDuplicata.vTp_duplicata = DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim();
                            fDuplicata.vDs_tpduplicata = DT_Pedido_Fiscal.Rows[0]["ds_tpduplicata"].ToString().Trim();
                            fDuplicata.vTp_mov = DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "E" ? "P" :
                                          DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "S" ? "R" : "";
                            fDuplicata.vTp_docto = DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString().Trim();
                            fDuplicata.vDs_tpdocto = DT_Pedido_Fiscal.Rows[0]["ds_tpdocto"].ToString().Trim();
                            if (List_TPDuplicata[0].St_gerarboletoauto.Trim().ToUpper().Equals("S"))
                            {
                                TList_CadContaGer List_Conta = TCN_CadContaGer.Buscar(List_TPDuplicata[0].Cd_contager_boletoauto, "", null, "", "", "", "", 0, "", "", "", "", 0, null);

                                fDuplicata.vSt_gerarboletoauto = List_TPDuplicata[0].St_gerarboletoauto;
                                fDuplicata.vCd_contager = List_TPDuplicata[0].Cd_contager_boletoauto;
                                fDuplicata.vDs_contager = List_TPDuplicata[0].Ds_contager_boletoauto;
                            }
                            if (List_CondPagamento.Count > 0)
                            {
                                fDuplicata.vCd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                                fDuplicata.vDs_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                                fDuplicata.vSt_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                                fDuplicata.vCd_juro = List_CondPagamento[0].Cd_juro.Trim();
                                fDuplicata.vDs_juro = List_CondPagamento[0].Ds_juro.Trim();
                                fDuplicata.vTp_juro = List_CondPagamento[0].Tp_juro.Trim();

                                fDuplicata.vCd_moeda = CD_Moeda;
                               // fDuplicata.vDs_moeda = List_Dados_Pedido[0].Ds_moeda;
                               // fDuplicata.vSigla_moeda = List_Dados_Pedido[0].Sigla;

                                fDuplicata.vQt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                                fDuplicata.vQt_parcelas = List_CondPagamento[0].Qt_parcelas;
                                fDuplicata.vPc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                                fDuplicata.vCd_portador = List_CondPagamento[0].Cd_portador.Trim();
                                fDuplicata.vDs_portador = List_CondPagamento[0].Ds_portador.Trim();
                                fDuplicata.vSt_solicitardtvencto = List_CondPagamento[0].St_solicitardtvenctobool;
                            }
                            fDuplicata.vNr_docto = "0";
                            fDuplicata.vDt_emissao = DateTime.Now.ToString();
                            fDuplicata.vVl_documento = Convert.ToDecimal(VL_Com_Liberada.Text);
                            

                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                            {
                                Reg_Duplicata = (fDuplicata.dsDuplicata[0] as TRegistro_LanDuplicata);
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar financeiro para gravar aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return null;
                            }
                        }
                        
                        Duplicata.Add(Reg_Duplicata);
                        return Duplicata;
                    }

                    return Duplicata;
                }
            }

            return Duplicata;
        }

        private void g_Pedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
