using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Utils;
using FormBusca;
using System.Drawing;
using System.Collections;
using System.Linq;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using CamadaNegocio.Faturamento.Cadastros;
using Fiscal.Cadastros;
using CamadaDados.Fiscal;
using System.Text;
using System.Windows.Forms;
using Proc_Commoditties;

namespace Faturamento
{
    public partial class TFLanNFWizard : Form
    {
        private bool cfgpedido = false;
        private bool cfgpedidofiscal = false;
        private bool movcfop = false;
        private bool St_vincularcf = false;
        private bool St_valoresfixos = false;
        private bool St_commoditties = false;
        public bool St_gerarfin = false;
        public bool st_maximizar = true;
        private bool cfgPedidoGrava = false;
        private bool cfgPedidoFiscaGrava = false;
        private bool movcfopGrava = false;
        public TFLanNFWizard()
        {
            InitializeComponent();
        }

        private void habilitaUsuario(bool habilita)
        {
           // btn_add_user.Enabled = habilita;
            bb_busca_usuario.Enabled = habilita;
            bb_novo_us.Enabled = !habilita;
            bb_altera_us.Enabled = !habilita;


        }

        private void CFGPedido_Click(object sender, EventArgs e)
        {

        }

        private void FLanNFWizard_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            // preenche cfg pedido
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("ENTRADA", "E"));
            CBox1.Add(new Utils.TDataCombo("SAIDA", "S"));
            Tp_Movimento.DataSource = CBox1;
            Tp_Movimento.DisplayMember = "Display";
            Tp_Movimento.ValueMember = "Value";
            Tp_Movimento.SelectedIndex = -1;

            // cfg pedido fiscal
            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO NORMAL", "NO"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE COMPLEMENTO", "CP"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE DEVOLUÇÃO/RETORNO", "DV"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE ENTREGA FUTURA", "FT"));
            cbx1.Add(new Utils.TDataCombo("TRANSFERENCIA ENTRE CONTRATOS", "TF"));
            cbx1.Add(new Utils.TDataCombo("COMPLEMENTO FISCAL", "CF"));
            cbx1.Add(new Utils.TDataCombo("DEVOLUÇÃO FISCAL", "DF"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO SERVIÇO", "SE"));


            Cbx_TP_Fiscal.DataSource = cbx1;
            Cbx_TP_Fiscal.DisplayMember = "Display";
            Cbx_TP_Fiscal.ValueMember = "Value";
            Cbx_TP_Fiscal.SelectedValue = "";
            Cbx_TP_Fiscal.SelectedItem = "";
            tabControl1.TabPages.Remove(CFGPedido);
            tabControl1.TabPages.Remove(CFGPedidoFiscal);
            tabControl1.TabPages.Remove(tpMovimentacaoCfop);
            tabControl1.TabPages.Remove(tpusuario);

        }

        public void habilitaCamposCfgPedido(bool habilita)
        {
            DS_TipoPedido.Enabled = habilita;
            cb_comissaopedido.Enabled = habilita;
            cb_cupomfiscal.Enabled = habilita;
            cb_deposito.Enabled = habilita;
            cb_duplicata.Enabled = habilita;
            cb_gerarOP.Enabled = habilita;
            cb_rastrear.Enabled = habilita;
            cb_servico.Enabled = habilita;
            cb_ST_PermPedParc.Enabled = habilita;
            cb_ST_PermTransf.Enabled = habilita;
            cb_valorfixo.Enabled = habilita;
            cbComissaofat.Enabled = habilita;
            cbCommoditties.Enabled = habilita;
            cbconferirsaldo.Enabled = habilita;
            cbExigeEtapa.Enabled = habilita;
            cbFrota.Enabled = habilita;
            cbGerarEtiqu.Enabled = habilita;
            cbIntegrarAlmo.Enabled = habilita;
            Tp_Movimento.Enabled = habilita;
            st_atualizaprecovenda.Enabled = habilita;
            st_ExigirConf.Enabled = habilita;
            st_gerarreservaestoque.Enabled = habilita;
            st_permitelanpedido.Enabled = habilita;
            st_servico_pf.Enabled = habilita;
            bbAlterar_cp.Enabled = !habilita;
            bbNovo_cp.Enabled = !habilita;
            cfgPedidoGrava = habilita;
            // bbBuscar.Enabled = !habilita;
        }

        public void buscaConfigPedidoFiscal()
        {
            if (bsCadCfgPedido.Current != null)
            {
                cfg_pedido_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
                ds_pedido_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Ds_tipopedido;
                tp_movimento_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tp_movimento;
            }

            if (!string.IsNullOrEmpty((bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido))
            {
                bsCadCFGPedidoFiscal.Clear();
                CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfg =
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedidoFiscal.Buscar((bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido,
                                                                                          string.Empty,
                                                                                          Nr_Serie_pf.Text,
                                                                                          decimal.Zero,
                                                                                          decimal.Zero,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);

                if (lCfg.Count != 0 )
                    bsCadCFGPedidoFiscal.DataSource = lCfg;
                else
                    novoPedidoFiscal();


            }



        }

        public void buscaConfigPedido()
        {
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedido lista = CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedido.Buscar(string.Empty,
                                                               DS_TipoPedido.Text,
                                                               Tp_Movimento.SelectedValue != null ? Tp_Movimento.SelectedValue.ToString().Trim() : string.Empty,
                                                               cb_deposito.Checked ? "S" : string.Empty,
                                                               cbconferirsaldo.Checked ? "S" : string.Empty,
                                                               cb_valorfixo.Checked ? "S" : string.Empty,
                                                               cb_ST_PermPedParc.Checked ? "S" : string.Empty,
                                                               cb_ST_PermTransf.Checked ? "S" : string.Empty,
                                                               cb_comissaopedido.Checked ? "S" : string.Empty,
                                                               cbComissaofat.Checked ? "S" : string.Empty,
                                                               cb_servico.Checked ? "S" : string.Empty,
                                                               decimal.Zero, 0, string.Empty, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    bsCadCfgPedido.DataSource = lista;
                }
                else
                    bsCadCfgPedido.Clear();
            }
        }
        private void buscaMovCfop()
        {

            //Preencher grid cond produto
            bsCondFiscalProdu.DataSource = CamadaNegocio.Fiscal.TCN_CadCondFiscalProduto.Busca(string.Empty, string.Empty);

            bsMovCfop.DataSource = CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Buscar(CD_Movto.Text,
                                                         (bsCondFiscalProdu.Current != null ?
                                                         (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).Exists(p => p.St_agregar) ?
                                                         (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).Find(p => p.St_agregar).CD_CONDFISCAL_PRODUTO : string.Empty : string.Empty),
                                                         CD_CFOP_DentroEstado.Text,
                                                         CD_CFOP_ForaEstado.Text,
                                                         string.Empty,
                                                         null);
            bsMovCfop_PositionChanged(this, new EventArgs());
            if (bsMovCfop.Count == 0)
            {
                bb_novo_mov_Click(this, new EventArgs());
            }
            bsMovCfop.ResetCurrentItem();
        }

        private void BuscaUsuario()
        {

            CamadaDados.Diversos.TList_CadUsuario_CFGPedido lista = CamadaNegocio.Diversos.TCN_CadUsuario_CFGPedido.Busca(string.Empty,
                                                                                                       (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido,
                                                                                                       (bsEmpresa.Current as TRegistro_CadEmpresa).Cd_empresa,
                                                                                                       null);



            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    bs_Usuario_Cfg_Pedido.DataSource = lista;
                }
                else
                    bs_Usuario_Cfg_Pedido.Clear();
            }

        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            habilitaCamposCfgPedido(false);
        }

        private void bbNovo_cp_Click(object sender, EventArgs e)
        {
            bsCadCfgPedido.Clear();
            habilitaCamposCfgPedido(true);
            bsCadCfgPedido.AddNew();
        }

        private void bbAlterar_cp_Click(object sender, EventArgs e)
        {
            habilitaCamposCfgPedido(true);
        }

        private void bb_avancar_cp_Click(object sender, EventArgs e)
        {

            if (bsCadCfgPedido.Current as TRegistro_CadCFGPedido != null)
            {
                if (panelDados1.validarCampoObrigatorio())
                {


                    if (cfgPedidoGrava)
                    {
                        (bsCadCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido).Tp_movimento = Tp_Movimento.SelectedValue.ToString();
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadCFGPedido.Gravar
                            (bsCadCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido, null);
                        habilitaCamposCfgPedido(false);
                        buscaConfigPedido();
                        bsCadCfgPedido.ResetCurrentItem();
                        
                    }
                    tabControl1.TabPages.Remove(CFGPedido);
                    tabControl1.TabPages.Insert(0, CFGPedidoFiscal);
                    bsCadCfgPedido.Add(bsCadCfgPedido.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadCFGPedido);
                    bsCadCfgPedido.Position = bsCadCfgPedido.Count;
                    buscaConfigPedidoFiscal();
                }
                else
                {
                    MessageBox.Show("Campo obrigatório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Selecione a configuração de pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



            //tabControl1.SelectedIndex = 1;
            //if (!cfgpedido)
            //{
            //    tabControl1.SelectedIndex = 0;
            //    habilitaCamposCfgPedido(false);
            //}
            //else
            //{
            //    tabControl1.SelectedIndex = 1;
            //}
        }

        private void bb_retroceder_pf_Click(object sender, EventArgs e)
        {
            if (bsCadCFGPedidoFiscal.Current != null)
            {
                buscaConfigPedidoFiscal();
            }
            tabControl1.TabPages.Remove(CFGPedidoFiscal);
            tabControl1.TabPages.Insert(0, CFGPedido);
            buscaConfigPedido();
            habilitaCamposPedidoFiscal(false);
        }

        private void bb_avancar_pf_Click(object sender, EventArgs e)
        {
            if (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal != null
                        && tabControl1.SelectedIndex == 0
                        && panelDados3.validarCampoObrigatorio())
            {


                if (cfgPedidoFiscaGrava)
                    TCN_CadCFGPedidoFiscal.Gravar(bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal, null);
                  
                bsCadCFGPedidoFiscal.ResetCurrentItem();
                buscaConfigPedidoFiscal();
                habilitaCamposPedidoFiscal(false);
                buscaMovCfop();
                

                tabControl1.TabPages.Remove(CFGPedidoFiscal);
                tabControl1.TabPages.Insert(0, tpMovimentacaoCfop);
            }
            else
            {
                MessageBox.Show("Selecione a configuração de pedido fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //   bb_voltar_mov_Click(this, new EventArgs());

            }


            //if (!cfgpedidofiscal)
            //{
            //    tabControl1.SelectedIndex = 1;
            //    habilitaCamposPedidoFiscal(false);
            //}
        }

        private void habilitaCamposPedidoFiscal(bool habilita)
        {
            Cbx_TP_Fiscal.Enabled = habilita;
            cd_modelo_pf.Enabled = habilita;
            Nr_Serie_pf.Enabled = habilita;
            bb_modelo.Enabled = habilita;
            bb_modelonf.Enabled = habilita;
            BB_Serie.Enabled = habilita;
            bbAlterar_cp.Enabled = !habilita;
            bbNovo_cp.Enabled = !habilita;
            bb_NRSerie.Enabled = habilita;
            // bb_cancelar_pf.Enabled = habilita;
            bbAlterar_pf.Enabled = !habilita;
            cfgPedidoFiscaGrava = habilita;
            bbNovo_pf.Enabled = !habilita;
            bbBuscar_pf.Enabled = habilita;
            CD_Movto.Enabled = habilita;
            BB_Movto.Enabled = habilita;
            button1.Enabled = habilita;
            CD_CMI.Enabled = habilita;
            CD_Movto.Enabled = habilita;
            BB_CMI.Enabled = habilita;
            button2.Enabled = habilita;
            bbNovo_pf.Enabled = !habilita;
            // bbBuscar_pf.Enabled = !habilita;
            bbAlterar_pf.Enabled = !habilita;
            // cfg_pedido_pf.Enabled = habilita;

        }

        private void novoPedidoFiscal()
        {

            habilitaCamposPedidoFiscal(true);
            bsCadCFGPedidoFiscal.AddNew();
            bsCadCFGPedidoFiscal.ResetCurrentItem();
            if (bsCadCfgPedido.Current != null)
            {
                cfg_pedido_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
                ds_pedido_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Ds_tipopedido;
                tp_movimento_pf.Text = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tp_movimento;
            }
        }

        private void bbNovo_pf_Click(object sender, EventArgs e)
        {
            novoPedidoFiscal();
        }

        private void bbAlterar_pf_Click(object sender, EventArgs e)
        {
            habilitaCamposPedidoFiscal(true);
            //     bsCadCFGPedidoFiscal.Clear();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            habilitaCamposCfgPedido(false);
            buscaConfigPedido();
        }

        private void bbBuscar_pf_Click(object sender, EventArgs e)
        {
            habilitaCamposPedidoFiscal(false);
            buscaConfigPedidoFiscal();
        }

        private void dataGridDefault2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cfgPedidoFiscaGrava = false;
        }

        private void bb_NRSerie_Click(object sender, EventArgs e)
        {
            using (Faturamento.Cadastros.TFSerieNF fSerie = new Faturamento.Cadastros.TFSerieNF())
            {
                //fSerie.rSerie.CD_Modelo = string.IsNullOrEmpty(cd_modelo_pf.Text) ? string.Empty : cd_modelo_pf.Text;
                fSerie.cd_modelostr = cd_modelo_pf.Text;
                if (fSerie.ShowDialog() == DialogResult.OK)
                {
                    if (fSerie.rSerie != null)
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Gravar(fSerie.rSerie, null);
                        MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nr_Serie_pf.Text = fSerie.rSerie.Nr_Serie;
                        ds_Serie_pf.Text = fSerie.rSerie.DS_SerieNf;
                    }

                }
            }
        }

        private void Nr_Serie_pf_Leave(object sender, EventArgs e)
        {

            string vColunas = "a.nr_serie|=|'" + Nr_Serie_pf.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_Serie_pf, ds_Serie_pf },
                                    new TCD_CadSerieNF());


            //if ((bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal) != null)
            //{
            //    object descricao = new TCD_CadSerieNF().BuscarEscalar(
            //        new TpBusca[]{
            //        new TpBusca(){
            //            vNM_Campo = "a.nr_serie",
            //            vOperador = "=",
            //            vVL_Busca = Nr_Serie_pf.Text
            //        }
            //    }, "a.ds_serienf");
            //    DS_Serie_pf.Text = descricao.ToString();
            //    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_serienf = descricao.ToString();
            //}
        }

        private void bb_cancelarp_Click(object sender, EventArgs e)
        {
            habilitaCamposCfgPedido(false);
            bsCadCfgPedido.Clear();
            buscaConfigPedido();
        }

        private void bb_cancelar_pf_Click(object sender, EventArgs e)
        {
            habilitaCamposPedidoFiscal(false);
            bsCadCFGPedidoFiscal.ResetCurrentItem();
            buscaConfigPedidoFiscal();
        }

        private void BB_CFG_Pedido_Click(object sender, EventArgs e)
        {
            if (bsCadCFGPedidoFiscal.Current != null)
            {

                string vColunas = "DS_TipoPedido|Configuração Pedido|350;" +
                                 "CFG_Pedido|Cód. Configuração Pedido|100;" +
                                 "TP_Movimento| Tipo Movimento |100;" +
                                 "ST_Servico|Pedido Serviço|80";

                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido_pf, ds_pedido_pf, tp_movimento_pf },
                                                            new TCD_CadCFGPedido(), string.Empty);
                if (linha != null)
                {
                    St_valoresfixos = linha["ST_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                    St_commoditties = linha["ST_Commoditties"].ToString().Trim().ToUpper().Equals("S");
                    St_vincularcf = linha["st_vincularcf"].ToString().Trim().ToUpper().Equals("S");
                    St_gerarfin = linha["st_gerarfin"].ToString().Trim().ToUpper().Equals("S");
                    st_servico_pf.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                    tp_movimento_pf.Text = linha["tp_movimento"].ToString().Trim();
                    ds_pedido_pf.Text = linha["ds_tipopedido"].ToString().Trim();
                }
                (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Tp_movimento = tp_movimento_pf.Text;
                (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_tipopedido = ds_pedido_pf.Text;
                (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Cfg_pedido = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
            }
        }

        private void cfg_pedido_pf_Leave(object sender, EventArgs e)
        {
            string vColunas = "cfg_pedido|=|'" + cfg_pedido_pf.Text.Trim() + "'";

            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cfg_pedido_pf, ds_pedido_pf, tp_movimento_pf },
                                                    new TCD_CadCFGPedido());
            if (linha != null)
            {
                St_valoresfixos = linha["ST_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                St_commoditties = linha["ST_Commoditties"].ToString().Trim().ToUpper().Equals("S");
                St_vincularcf = linha["st_vincularcf"].ToString().Trim().ToUpper().Equals("S");
                St_gerarfin = linha["st_gerarfin"].ToString().Trim().ToUpper().Equals("S");
                st_servico_pf.Checked = linha["st_servico"].ToString().Trim().ToUpper().Equals("S");
                // ds_pedido_pf.Text = linha["ds_tipopedido"].ToString().Trim();
            }

        }

        private void BB_Serie_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_SerieNF|Série |350;" +
                              "Nr_Serie|Cód. Série |100;" +
                              "Cd_modelo|Cód. Modelo|100;" +
                              "b.ds_modelo|Modelo NF|100";
            string vParam = string.Empty;
            if (st_servico_pf.Checked)
                vParam = "tp_serie|in|('S', 'M')";
            else
                vParam = "tp_serie|<>|'S'";
            if (!string.IsNullOrEmpty(cd_modelo_pf.Text))
                vParam += ";a.cd_modelo|=|'" + cd_modelo_pf.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_Serie_pf, ds_Serie_pf, cd_modelo_pf, ds_modelo_pf },
                                    new TCD_CadSerieNF(), vParam);
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Nr_serie = Nr_Serie_pf.Text;
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_serienf = ds_Serie_pf.Text;
        }

        
        private void bb_modelo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_modelo|Modelo NF|200;" +
                              "a.cd_modelo|Cd. Modelo|80";
            //string vParam = string.Empty;
            //if (!string.IsNullOrEmpty(Nr_Serie_pf.Text))
            //    vParam = "|exists|(select 1 from tb_fat_serienf x " +
            //             "          where x.cd_modelo = a.cd_modelo " +
            //             "          and x.nr_serie = '" + Nr_Serie_pf.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_modelo_pf, ds_modelo_pf },
                new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF(),string.Empty);
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Cd_modelo = cd_modelo_pf.Text;
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_modelo = ds_modelo_pf.Text;
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Nr_serie = string.Empty;
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_serienf = string.Empty;

        }





        private void bb_modelonf_Click(object sender, EventArgs e)
        {
            using (Faturamento.Cadastros.TFCadModeloNotaFiscal fCadModeloNF = new Faturamento.Cadastros.TFCadModeloNotaFiscal())
            {
                if (fCadModeloNF.ShowDialog() == DialogResult.OK)
                {
                    TCN_CadModeloNF.Grava_CadModeloNF(fCadModeloNF.rModelo, null);
                    MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cd_modelo_pf.Text = fCadModeloNF.rModelo.CD_Modelo;
                    ds_modelo_pf.Text = fCadModeloNF.rModelo.DS_Modelo;
                    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Nr_serie = string.Empty;
                    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_serienf = string.Empty;
                }
            }
        }

        private void bb_voltar_mov_Click(object sender, EventArgs e)
        {
            habilitaMovCfop(false);
            buscaConfigPedidoFiscal();
            tabControl1.TabPages.Remove(tpMovimentacaoCfop);
            tabControl1.TabPages.Insert(0, CFGPedidoFiscal);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cbx_TP_Fiscal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BB_Movto_Click(object sender, EventArgs e)

        {

        }

        private void BB_Movto_Click_1(object sender, EventArgs e)
        {

            string vcond = string.Empty;
            if (tp_movimento_pf.Text.Trim().ToUpper().Equals("E") && (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tp_movimento.Trim().ToUpper().Equals("E"))
                vcond = "a.Tp_Movimento|=|'E'";
            else if (tp_movimento_pf.Text.Trim().ToUpper().Equals("S") && (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tp_movimento.Trim().ToUpper().Equals("S"))
                vcond = "a.Tp_Movimento|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue == null)
                Cbx_TP_Fiscal.SelectedValue = "NO";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("E"))))
                vcond = "a.Tp_Movimento|=|'S'";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("S"))))
                vcond = "a.Tp_Movimento|=|'E'";
            if (!string.IsNullOrEmpty(CD_CMI.Text))
                vcond += ";|exists|(select 1 from tb_fis_mov_x_cmi x " +
                         "          where x.cd_movimentacao = a.cd_movimentacao " +
                         "          and x.cd_cmi = " + CD_CMI.Text + ")";

            string vColunas = "DS_Movimentacao|Movimentação|350;" +
                              "CD_Movimentacao|Cód. Movimentação|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movto, DS_Movto },
                                    new TCD_CadMovimentacao(), vcond);

            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Cd_cmistring = string.Empty;
            (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_cmi = string.Empty;
        }

        private void BB_CMI_Click(object sender, EventArgs e)
        {
            string vcond = string.Empty;
            if (tp_movimento_pf.Text.Trim().ToUpper().Equals("E"))
                vcond = "a.Tp_Movimento|=|'E'";
            if (tp_movimento_pf.Text.Trim().ToUpper().Equals("S"))
                vcond = "a.Tp_Movimento|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue == null)
                Cbx_TP_Fiscal.SelectedValue = "NO";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                    Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("E"))))
                vcond = "a.Tp_Movimento|=|'S';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("S"))))
                vcond = "a.Tp_Movimento|=|'E';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CP"))
                vcond += ";isnull(a.ST_Complementar, 'N')|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CF"))
                vcond += ";||isnull(a.ST_CompDevImposto, 'N') = 'S' or isnull(a.ST_Complementar, 'N') = 'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("FT"))
                vcond += ";isnull(a.ST_Mestra, 'N')|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("NO"))
                vcond += ";||isnull(a.ST_Devolucao, 'N') <> 'S' and isnull(a.ST_Retorno, 'N') <> 'S' and isnull(a.ST_Complementar, 'N') <> 'S' and isnull(a.ST_Mestra, 'N') <> 'S'";
            if (((!St_valoresfixos) && St_commoditties) || St_gerarfin)//Contratos de graos a fixar nao pode gerar financeiro
                vcond += ";a.tp_duplicata|is|null";
            if (St_vincularcf)
                vcond += ";isnull(a.st_geraestoque, 'N')|<>|'S'";

            vcond = "f.cd_movimentacao|=|" + CD_Movto.Text +
                (string.IsNullOrEmpty(vcond) ? string.Empty : ";" + vcond.Trim());

            string vColunas = "DS_CMI|Descrição CMI|350;" +
                              "CD_CMI|Cód. CMI|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CMI, DS_CMI },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"), vcond);
        }

        private void CD_Movto_Leave(object sender, EventArgs e)
        {

            string vcond = "";
            if (tp_movimento_pf.Text == "S")
                vcond = "a.Tp_Movimento|=|'S'";
            if (tp_movimento_pf.Text == "E")
                vcond = "a.Tp_Movimento|=|'E'";
            if (Cbx_TP_Fiscal.SelectedValue == null)
                Cbx_TP_Fiscal.SelectedValue = "NO";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("E"))))
                vcond = "a.Tp_Movimento|=|'S'";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("S"))))
                vcond = "a.Tp_Movimento|=|'E'";

            string vColunas = CD_Movto.NM_CampoBusca + "|=|'" + CD_Movto.Text.Trim() + "'";
            if (vcond != "")
                vColunas = vColunas + ";" + vcond;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Movto, DS_Movto },
                                    new TCD_CadMovimentacao());
            CD_CMI.Text = string.Empty;
            DS_CMI.Text = string.Empty;

        }

        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            string vcond = string.Empty;
            if (tp_movimento_pf.Text == "E")
                vcond = "a.Tp_Movimento|=|'E'";
            if (tp_movimento_pf.Text == "S")
                vcond = "a.Tp_Movimento|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue == null)
                Cbx_TP_Fiscal.SelectedValue = "NO";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("E"))))
                vcond = "a.Tp_Movimento|=|'S';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            if (((Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DV") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("TF") ||
                Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("DF")) && (tp_movimento_pf.Text.Trim().ToUpper().Equals("S"))))
                vcond = "a.Tp_Movimento|=|'E';||isnull(a.ST_Devolucao, 'N') = 'S' or isnull(a.ST_Retorno, 'N') = 'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CP"))
                vcond += ";isnull(a.ST_Complementar, 'N')|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("CF"))
                vcond += ";||isnull(a.ST_CompDevImposto, 'N') = 'S' or isnull(a.ST_Complementar, 'N') = 'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("FT"))
                vcond += ";isnull(a.ST_Mestra, 'N')|=|'S'";
            if (Cbx_TP_Fiscal.SelectedValue.ToString().Trim().ToUpper().Equals("NO"))
                vcond += ";||isnull(a.ST_Devolucao, 'N') <> 'S' and isnull(a.ST_Retorno, 'N') <> 'S' and isnull(a.ST_Complementar, 'N') <> 'S' and isnull(a.ST_Mestra, 'N') <> 'S'";
            if (((!St_valoresfixos) && St_commoditties) || St_gerarfin)//Contratos de graos a fixar nao pode gerar financeiro
                vcond += ";a.tp_duplicata|is|null";
            if (St_vincularcf)
                vcond += ";isnull(a.st_geraestoque, 'N')|<>|'S'";

            vcond = "a.cd_cmi|=|" + CD_CMI.Text + ";" +
                "f.cd_movimentacao|=|" + CD_Movto.Text + (string.IsNullOrEmpty(vcond) ? string.Empty : ";" + vcond.Trim());

            UtilPesquisa.EDIT_LEAVE(vcond, new Componentes.EditDefault[] { CD_CMI, DS_CMI },
                                           new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.FCadMovimentacaoComercial fMov = new Fiscal.Cadastros.FCadMovimentacaoComercial())
            {
                if (fMov.ShowDialog() == DialogResult.OK)
                {
                    //pega cd movto
                    object obj = new CamadaDados.Fiscal.TCD_CadMovimentacao().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.DS_Movimentacao",
                                                vOperador = "=",
                                                vVL_Busca = "  '" + fMov.rMov.ds_movimentacao.Trim() + "'"
                                            }
                                        }, "a.CD_Movimentacao"
                                            );
                    DS_Movto.Text =
                        fMov.rMov.ds_movimentacao;
                    CD_Movto.Text =
                        obj.ToString();
                    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Cd_cmistring = string.Empty;
                    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_cmi = string.Empty;
                }

            }
        }

        private void DS_Movto_Leave(object sender, EventArgs e)
        {

        }

        private void CD_Movto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.TFCadMovXCmi fCad = new Fiscal.Cadastros.TFCadMovXCmi())
            {
                fCad.cd_mov = CD_Movto.Text;
                fCad.ds_mov = DS_Movto.Text;
                fCad.tp = tp_movimento_pf.Text;
                if (fCad.ShowDialog() == DialogResult.OK)
                {
                    //pega cd movto
                    object obj = new CamadaDados.Fiscal.TCD_CadMov_x_CMI().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "c.ds_cmi",
                                                vOperador = "=",
                                                vVL_Busca = "  '" + fCad.rMov.ds_cmi.Trim() + "'"
                                            }
                                        }, "c.cd_cmi"
                                            );
                    DS_CMI.Text =
                        fCad.rMov.ds_cmi;
                    CD_CMI.Text =
                        obj.ToString();


                }
            }
        }

        private void habilitaMovCfop(bool habilita)
        {
            cd_cfop_internacional.Enabled = habilita;
            CD_CFOP_ForaEstado.Enabled = habilita;
            CD_CFOP_DentroEstado.Enabled = habilita;
            cd_movimentacao.Enabled = habilita;
            bb_cfop_internacional.Enabled = habilita;
            bb_cfopDentro.Enabled = habilita;
            bb_cfopFora.Enabled = habilita;
            bb_movimentacao.Enabled = habilita;
            movcfopGrava = habilita;
            gCondFiscalProd.Enabled = habilita;
            button3.Enabled = habilita;
            button4.Enabled = habilita;
            button5.Enabled = habilita;
            bb_novo_mov.Enabled = !habilita;
            bb_altera_mov.Enabled = !habilita;
         //   bb_busca_mov.Enabled = habilita;

        }
        private void bb_novo_mov_Click(object sender, EventArgs e)
        {
            buscaConfigPedidoFiscal();
            panelDados4.set_FormatZero();
            habilitaMovCfop(true);
            bsMovCfop.AddNew();
            cd_movimentacao.Text = (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Cd_movtostring;
            ds_movimentacao.Text = (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_movimentacao;
            editDefault1.Text = (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Tp_movimento;
            //    cd_movimentacao_Leave(this, new EventArgs());


        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movimentacao.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao, editDefault1 },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movimentação|80;" +
                              "a.tp_movimento|Movimento|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao, editDefault1 },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void CD_CFOP_DentroEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + CD_CFOP_DentroEstado.Text.Trim() + "'";
            vColunas += !string.IsNullOrEmpty(editDefault1.Text) ?
                        editDefault1.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CFOP_DentroEstado, ds_cfop_dentroestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void bb_cfopDentro_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(editDefault1.Text) ?
                            editDefault1.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CFOP_DentroEstado, ds_cfop_dentroestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void bb_cfopFora_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(editDefault1.Text) ?
                            editDefault1.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'6'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CFOP_ForaEstado, ds_cfop_foraestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void CD_CFOP_ForaEstado_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + CD_CFOP_ForaEstado.Text + "'";
            vColunas += !string.IsNullOrEmpty(editDefault1.Text) ?
                        editDefault1.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'2'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'6'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CFOP_ForaEstado, ds_cfop_foraestado },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void cd_cfop_internacional_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CFOP|=|'" + cd_cfop_internacional.Text + "'";
            vColunas += !string.IsNullOrEmpty(editDefault1.Text) ?
                        editDefault1.Text.Trim().ToUpper().Equals("E") ?
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'" :
                        ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_cfop_internacional, ds_cfop_internacional },
                                    new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void bb_cfop_internacional_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CFOP|Descrição CFOP|350;" +
                              "CD_CFOP|Cód. CFOP|100";
            string vParam = !string.IsNullOrEmpty(editDefault1.Text) ?
                            editDefault1.Text.Trim().ToUpper().Equals("E") ?
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'3'" :
                            "SUBSTRING(a.CD_CFOP, 1, 1)|=|'7'" : string.Empty;
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop_internacional, ds_cfop_internacional },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
        }

        private void bb_busca_mov_Click(object sender, EventArgs e)
        {
            buscaMovCfop();
            habilitaMovCfop(false);
        }

        private void bb_cancela_mov_Click(object sender, EventArgs e)
        {
            panelDados4.set_FormatZero();
            habilitaMovCfop(false);
            buscaMovCfop();
        }

        private void bb_altera_mov_Click(object sender, EventArgs e)
        {
            buscaMovCfop();
            habilitaMovCfop(true);
        }

           private void gCondFiscalProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bsCondFiscalProdu.Current != null))
                if (e.ColumnIndex == 0)
                {
                    (bsCondFiscalProdu.Current as TRegistro_CadCondFiscalProduto).St_agregar =
                        !(bsCondFiscalProdu.Current as TRegistro_CadCondFiscalProduto).St_agregar;
                    bsCondFiscalProdu.ResetCurrentItem();
                }
        }

        private void bsMovCfop_PositionChanged(object sender, EventArgs e)
        {
            if (bsMovCfop.Current != null)
            {
                //Posicionar cursor condicao fiscal produto
                if (bsCondFiscalProdu.Count > 0)
                {
                    (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).ForEach(p => p.St_agregar = false);
                    if ((bsCondFiscalProdu.List as TList_CadCondFiscalProduto).Exists(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto)))
                    {
                        (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).Find(p => p.CD_CONDFISCAL_PRODUTO.Trim().Equals((bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto)).St_agregar = true;
                        bsCondFiscalProdu.ResetBindings(true);
                    }
                }
            }
        }


        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            BuscaUsuario();
            habilitaMovCfop(false);
            tabControl1.TabPages.Remove(tpusuario);
            tabControl1.TabPages.Insert(0, tpMovimentacaoCfop);
            buscaMovCfop();

        }


        private void bb_busca_usuario_Click(object sender, EventArgs e)
        {
            string vColunas = //"Nome_Usuario| Descrição |350;" +
                              "Login|Log.|100";
            string vParam = "|exists|(select 1 from tb_div_usuario x " +
                        "          where x.Login = a.Login )";
            // "          and x.Login = '" + Login.Text.Trim() + "')";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Login },
                                    new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (bsMovCfop.Current as TRegistro_Mov_X_CFOP != null && panelDados4.validarCampoObrigatorio())
            {

                if (movcfopGrava)
                    CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Gravar(bsMovCfop.Current as TRegistro_Mov_X_CFOP, (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).FindAll(p => p.St_agregar), null);
                bsMovCfop.ResetCurrentItem();
                buscaMovCfop();
                BuscaUsuario();
                habilitaMovCfop(false);
                tabControl1.TabPages.Remove(tpMovimentacaoCfop);
                tabControl1.TabPages.Insert(0, tpusuario);
            }
            else
            {
                MessageBox.Show("Selecione a movimentação de cfop.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


      
        private void bb_finalizar_us_Click(object sender, EventArgs e)
        {
            CamadaNegocio.Diversos.TCN_CadUsuario_CFGPedido.Gravar
                                       (bs_Usuario_Cfg_Pedido.Current as CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido, null);
            BuscaUsuario();
            bs_Usuario_Cfg_Pedido.ResetCurrentItem();
            habilitaUsuario(false);
            //tabControl1.TabPages.Remove(tpusuario);
            //tabControl1.TabPages.Insert(0, CFGPedido);
        }

        private void bb_novo_us_Click(object sender, EventArgs e)
        {
            bs_Usuario_Cfg_Pedido.AddNew();
            (bs_Usuario_Cfg_Pedido.Current as CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido).Cfg_pedido =
                (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
            cd_cfgpedido_us.Text =
                (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
            ds_cfgpedido_us.Text =
                (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Ds_tipopedido;
            habilitaUsuario(true);
        }

        private void bb_altera_us_Click(object sender, EventArgs e)
        {
            if (bs_Usuario_Cfg_Pedido.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CamadaNegocio.Diversos.TCN_CadUsuario_CFGPedido.Excluir(
                        bs_Usuario_Cfg_Pedido.Current as CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido, null);
                    bs_Usuario_Cfg_Pedido.RemoveCurrent();
                }
        }

        private void bb_busca_us_Click(object sender, EventArgs e)
        {
            habilitaUsuario(false);
            BuscaUsuario();
        }

        private void bb_cancel_us_Click(object sender, EventArgs e)
        {
            habilitaUsuario(false);
            bs_Usuario_Cfg_Pedido.ResetCurrentItem();
            BuscaUsuario();
            cd_cfgpedido_us.Text =
                (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Cfg_pedido;
            ds_cfgpedido_us.Text =
                (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Ds_tipopedido;

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            bsCadCFGPedidoFiscal.ResetCurrentItem();
            buscaConfigPedidoFiscal();
            habilitaCamposPedidoFiscal(false);
            buscaMovCfop();

            tabControl1.TabPages.Remove(tpMovimentacaoCfop);
            tabControl1.TabPages.Insert(0, CFGPedidoFiscal);
        }

        private void bb_avancarmov_Click(object sender, EventArgs e)
        {

            if (bsMovCfop.Current as TRegistro_Mov_X_CFOP != null && panelDados4.validarCampoObrigatorio())
            {

                if (movcfopGrava)
                    CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Gravar(bsMovCfop.Current as TRegistro_Mov_X_CFOP, (bsCondFiscalProdu.List as TList_CadCondFiscalProduto).FindAll(p => p.St_agregar), null);
                bsMovCfop.ResetCurrentItem();
                buscaMovCfop();
                BuscaUsuario();
                habilitaMovCfop(false);

                tabControl1.TabPages.Remove(tpMovimentacaoCfop);
                tabControl1.TabPages.Insert(0, tpusuario);

                if (bs_Usuario_Cfg_Pedido.Current == null)
                    bb_novo_us_Click(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Selecione a movimentação de cfop.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (bsCadCfgPedido.Current != null && bsMovCfop.Current != null && bsEmpresa.Current != null)
            {
                CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS condfiscal = new CamadaDados.Fiscal.TRegistro_CadCondFiscalICMS();
                condfiscal.Cd_empresa = (bsEmpresa.Current as TRegistro_CadEmpresa).Cd_empresa;
                condfiscal.Tp_movimento = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tp_movimento;
                condfiscal.Tipo_movimento = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tipo_movimento;
                condfiscal.Cd_condfiscal_produto = (bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto;
                condfiscal.Ds_condfiscal_produto = (bsMovCfop.Current as TRegistro_Mov_X_CFOP).Ds_condfiscal_produto;
                condfiscal.Cd_movimentacao = (bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_movimentacao;

                using (Proc_Commoditties.TFCondFiscalICMS fcond = new Proc_Commoditties.TFCondFiscalICMS())
                {
                    fcond.st_novo = true;
                    fcond.rCond = condfiscal;
                    //  fcond.
                    if (fcond.ShowDialog() == DialogResult.OK)
                        if ((fcond.rCond != null) &&
                            (fcond.lMov != null) &&
                            (fcond.lUfOrigem != null) &&
                            (fcond.lUfDestino != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fcond.rCond,
                                                                                  fcond.lMov,
                                                                                  fcond.lUfOrigem,
                                                                                  fcond.lUfDestino,
                                                                                  null);
                                MessageBox.Show("Condição fiscal gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (bsCadCfgPedido.Current != null && bsMovCfop.Current != null && bsEmpresa.Current != null)
            {
                CamadaDados.Fiscal.TRegistro_CondicaoFiscalImposto condfiscalImposto = new CamadaDados.Fiscal.TRegistro_CondicaoFiscalImposto();
                condfiscalImposto.cd_empresa = (bsEmpresa.Current as TRegistro_CadEmpresa).Cd_empresa;
                condfiscalImposto.Tipo_faturamento = (bsCadCfgPedido.Current as TRegistro_CadCFGPedido).Tipo_movimento;
                condfiscalImposto.cd_movimentacao = (bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_movimentacao;
                condfiscalImposto.cd_condfiscal_produto = (bsMovCfop.Current as TRegistro_Mov_X_CFOP).Cd_condfiscal_produto;



                using (Proc_Commoditties.TFCondFiscalImposto fCond = new Proc_Commoditties.TFCondFiscalImposto())
                {
                    fCond.rCond = condfiscalImposto;
                    if (fCond.ShowDialog() == DialogResult.OK)
                        if ((fCond.rCond != null) &&
                            (fCond.lMov != null) &&
                            (fCond.lCondClifor != null) &&
                            (fCond.lCondProd != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCond.rCond,
                                                                                                 fCond.lMov,
                                                                                                 fCond.lCondClifor,
                                                                                                 fCond.lCondProd,
                                                                                                 fCond.pSt_fisica,
                                                                                                 fCond.pSt_juridica,
                                                                                                 fCond.pSt_estrangeiro,
                                                                                                 null);
                                MessageBox.Show("Condição fiscal alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (bsEmpresa.Current != null)
            {
                tabControl1.TabPages.Add(CFGPedido);
                tabControl1.TabPages.Remove(tpEmpresa);
                habilitaCamposCfgPedido(false);
                buscaConfigPedido();
            }
            else
            {
                 MessageBox.Show("Selecione uma empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tpEmpresa);
            tabControl1.TabPages.Remove(CFGPedido);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CamadaDados.Diversos.TList_CadEmpresa lista = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    bsEmpresa.DataSource = lista;
                }
                else
                    bsEmpresa.Clear();
            }
        }

        private void cd_modelo_pf_Leave_1(object sender, EventArgs e)
        {
            string vColunas = "a.cd_modelo|=|'" + cd_modelo_pf.Text.Trim() + "'";
            //vColunas += !string.IsNullOrEmpty(editDefault1.Text) ?
            //            editDefault1.Text.Trim().ToUpper().Equals("E") ?
            //            ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'1'" :
            //            ";SUBSTRING(a.CD_CFOP, 1, 1)|=|'5'" : string.Empty;
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_modelo_pf, ds_modelo_pf },
                                    new TCD_CadModeloNF());

            //ds_modelo_pf.Text = string.Empty;
            //if ((bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal) != null)
            //{
            //    object descricao = new TCD_CadModeloNF().BuscarEscalar(
            //        new TpBusca[]{
            //        new TpBusca(){
            //            vNM_Campo = "a.cd_modelo",
            //            vOperador = "=",
            //            vVL_Busca = cd_modelo_pf.Text
            //        }
            //    }, "a.ds_modelo");
            //    if (descricao != null)
            //    {
            //        ds_modelo_pf.Text = descricao.ToString();
            //    }
            //    (bsCadCFGPedidoFiscal.Current as TRegistro_CadCFGPedidoFiscal).Ds_modelo = ds_modelo_pf.Text;
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.Remove(tpusuario);
            tabControl1.TabPages.Insert(0, tpEmpresa);
        }

        private void TFLanNFWizard_KeyDown(object sender, KeyEventArgs e)
        {

            if (tabControl1.SelectedTab.Equals(tpEmpresa))
            {
                if (e.KeyCode.Equals(Keys.F7))
                    toolStripButton2_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Left))
                    toolStripButton5_Click_1(this, new EventArgs());
            }
            else if (tabControl1.SelectedTab.Equals(CFGPedido))
            {
                if (e.KeyCode.Equals(Keys.F2))
                    bbNovo_cp_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F7))
                    bbBuscar_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F3))
                    bbAlterar_cp_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F6))
                    bb_cancelarp_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Left))
                    toolStripButton11_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Right))
                    bb_avancar_cp_Click(this, new EventArgs());
            }
            else if (tabControl1.SelectedTab.Equals(CFGPedidoFiscal))
            {
                if (e.KeyCode.Equals(Keys.F2))
                    bbNovo_pf_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F7))
                    bbBuscar_pf_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F3))
                    bbAlterar_pf_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F6))
                    bb_cancelar_pf_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Left))
                    bb_retroceder_pf_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Right))
                    bb_avancar_pf_Click(this, new EventArgs());
            }
            else if (tabControl1.SelectedTab.Equals(tpMovimentacaoCfop))
            {
                if (e.KeyCode.Equals(Keys.F2))
                    bb_novo_mov_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F7))
                    bb_busca_mov_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F3))
                    bb_altera_mov_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F6))
                    bb_cancela_mov_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Left))
                    bb_voltar_mov_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Right))
                    bb_avancarmov_Click(this, new EventArgs());
            }
            else if (tabControl1.SelectedTab.Equals(tpusuario))
            {
                if (e.KeyCode.Equals(Keys.F2))
                    bb_novo_us_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F7))
                    bb_busca_us_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F5))
                    bb_altera_us_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F6))
                    bb_cancel_us_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.Left))
                    toolStripButton11_Click(this, new EventArgs());
                if (e.KeyCode.Equals(Keys.F4) || e.KeyCode.Equals(Keys.Right))
                    bb_finalizar_us_Click(this, new EventArgs());
            }

        }

        private void DS_Movto_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelDados3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(Fiscal.Cadastros.FCFOP fcop = new FCFOP())
            {
                if(fcop.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Fiscal.TCN_CadCFOP.Gravar(fcop.rCFOP, null);
                    CD_CFOP_DentroEstado.Text = fcop.rCFOP.CD_CFOP;
                    ds_cfop_dentroestado.Text = fcop.rCFOP.DS_CFOP;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.FCFOP fcop = new FCFOP())
            {
                if (fcop.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Fiscal.TCN_CadCFOP.Gravar(fcop.rCFOP, null);
                    CD_CFOP_ForaEstado.Text = fcop.rCFOP.CD_CFOP;
                    ds_cfop_foraestado.Text = fcop.rCFOP.DS_CFOP;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.FCFOP fcop = new FCFOP())
            {
                if (fcop.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Fiscal.TCN_CadCFOP.Gravar(fcop.rCFOP, null);
                    cd_cfop_internacional.Text = fcop.rCFOP.CD_CFOP;
                    ds_cfop_internacional.Text = fcop.rCFOP.DS_CFOP;
                }

            }
        }
    }
}
