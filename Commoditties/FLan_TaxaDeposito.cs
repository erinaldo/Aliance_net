using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;

namespace Commoditties
{
    public partial class TFLan_TaxaDeposito : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_TaxaDeposito()
        {
            InitializeComponent();
        }

        private void totalizarMovimentacao()
        {
            if (bsPedido.Current != null)
            {
                qtd_total_entrada.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).MovContrato.Sum(p => p.Qtd_entrada);
                qtd_total_saida.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).MovContrato.Sum(p => p.Qtd_saida);
                qtd_total_saldo.Value = qtd_total_entrada.Value - qtd_total_saida.Value;
                vl_total_entrada.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).MovContrato.Where(p => p.Tp_movimento.Trim().ToUpper().Equals("ENTRADA")).Sum(p => p.Vl_subtotal);
                vl_total_saida.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).MovContrato.Where(p => p.Tp_movimento.Trim().ToUpper().Equals("SAIDA")).Sum(p => p.Vl_subtotal);
                vl_total_saldo.Value = vl_total_entrada.Value - vl_total_saida.Value;
            }
        }

        private void TotalizarTaxasRealizar()
        {
            if (bsTaxaRealizar.Count > 0)
            {
                tot_pesorealizar.Value = (bsTaxaRealizar.DataSource as TList_TaxaDeposito).Sum(p => p.Ps_Taxa);
                tot_valorrealizar.Value = (bsTaxaRealizar.DataSource as TList_TaxaDeposito).Sum(p => p.Vl_Taxa);
            }
        }

        private void afterNovo()
        {
            if (bsPedido.Current != null)
            {
                TFLan_Taxa fTaxa = new TFLan_Taxa();
                try
                {
                    fTaxa.Nr_contrato = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.ToString();
                    fTaxa.Nr_pedido = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_pedidostring;
                    fTaxa.Cd_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto;
                    fTaxa.Ds_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Ds_produto;
                    fTaxa.Sigla_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Sigla_unidade_estoque;
                    if (fTaxa.ShowDialog() == DialogResult.OK)
                        if (fTaxa.bsTaxaDeposito.Current != null)
                            try
                            {
                                TCN_LanTaxas_Deposito.Gravar((fTaxa.bsTaxaDeposito.Current as TRegistro_TaxaDeposito), null);
                                if (tcContratoPedido.SelectedTab.Equals(tpTaxas))
                                    tcTaxas_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro gravar taxa deposito: " + ex.Message);
                            }
                }
                finally
                {
                    fTaxa.Dispose();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Nr_Contrato.Text))
            {
                MessageBox.Show("Obrigatorio informar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nr_Contrato.Focus();
                return;
            }
            bsPedido.DataSource = TCN_PedidoAplicacao.Buscar(cd_empresa.Text,
                                                             nr_pedido.Text, 
                                                             string.Empty,
                                                             cd_contratante.Text,
                                                             string.Empty,
                                                             false,
                                                             Nr_Contrato.Text,
                                                             AnoSafra.Text,
                                                             cd_tabeladesconto.Text,
                                                             rG_FiltroData.NM_Valor,
                                                             DT_Inic.Text,
                                                             DT_Final.Text,
                                                             false, 
                                                             string.Empty, 
                                                             false, 
                                                             false, 
                                                             string.Empty, 
                                                             false, 
                                                             false,
                                                             0);
            bsPedido_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsPedido.Current != null)
                //Chamar tela de impressao relatorio
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsPedido;
                    Rel.Adiciona_DataSource("DTS_Sintetico", bsSinteticoTaxa);
                    Rel.Adiciona_DataSource("DTS_Analitico", bsAnaliticoTaxa);
                    Rel.Adiciona_DataSource("DTS_MovContrato", bsMovContrato);
                    Rel.Adiciona_DataSource("DTS_TaxasRealizar", bsTaxaRealizar);
                    Rel.Parametros_Relatorio.Add("ST_VISUALIZAR_SINTETICO", st_sintetico.Checked && (bsSinteticoTaxa.Count > 0));
                    Rel.Parametros_Relatorio.Add("ST_VISUALIZAR_ANALITICO", st_analitico.Checked && (bsAnaliticoTaxa.Count > 0));
                    Rel.Parametros_Relatorio.Add("ST_VISUALIZAR_REALIZAR", st_realizar.Checked && (bsTaxaRealizar.Count > 0));
                    Rel.Parametros_Relatorio.Add("ST_VISUALIZAR_MOVCONTRATO", st_movdeposito.Checked && (bsMovContrato.Count > 0));
                    Rel.Parametros_Relatorio.Add("PS_PROVISIONADO", ps_provisionado.Value);
                    Rel.Parametros_Relatorio.Add("VL_PROVISIONADO", vl_provisionado.Value);
                    Rel.Nome_Relatorio = Name.Trim();
                    Rel.Ident = Name.Trim();
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "GRO";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "EXTRATO TAXAS CONTRATO";

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
                                           "EXTRATO TAXAS CONTRATO",
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
                                               "EXTRATO TAXAS CONTRATO",
                                               fImp.pDs_mensagem);
                }
            else
                MessageBox.Show("Não existe Contrato para imprimir relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReprocessarTaxasContrato()
        {
            if (bsPedido.Current != null)
            {
                if (MessageBox.Show("Confirma reprocessamento das taxas do contrato?\r\n" +
                                   "Obs. Serão reprocessadas somente as taxas em aberto.", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio reprocesso taxas...");
                    try
                    {
                        TCN_MovDeposito.ReprocessarTaxasContrato(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                        {
                            Nr_pedido = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_pedido,
                            Cd_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto,
                            Id_pedidoitem = (bsPedido.Current as TRegistro_PedidoAplicacao).Id_pedidoitem
                        },
                        tEspera,
                        null);
                        MessageBox.Show("Taxas recalculadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsPedido_PositionChanged(this, new EventArgs());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        tEspera.Fechar();
                        tEspera = null;
                    }
                }
            }
            else
                MessageBox.Show("Necessário selecionar contrato para reprocessar taxas.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FaturarTaxasContrato()
        {
            if (bsPedido.Current != null)
            {
                using (TFLanFaturarTaxas fFatura = new TFLanFaturarTaxas())
                {
                    fFatura.Nr_contrato = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr;
                    fFatura.Nr_pedido = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_pedidostring;
                    fFatura.Cd_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto;
                    if (fFatura.ShowDialog() == DialogResult.OK)
                        if (fFatura.lTaxas != null)
                        {
                            try
                            {
                                decimal retorno =
                                    TCN_MovDeposito.FaturarTaxasContrato((bsPedido.Current as TRegistro_PedidoAplicacao),
                                                                         fFatura.lTaxas,
                                                                         fFatura.Tp_taxa,
                                                                         (fFatura.Tp_taxa.Trim().ToUpper().Equals("P") ? 
                                                                         Proc_Commoditties.TProcessaQuebraTec.ProcessaQuebraTec((bsPedido.Current as TRegistro_PedidoAplicacao),
                                                                                                                                fFatura.lTaxas,
                                                                                                                                fFatura.Tp_taxa): null),
                                                                         null);
                                if (fFatura.Tp_taxa.Trim().ToUpper().Equals("V"))
                                {
                                    if (MessageBox.Show("Taxas processadas com sucesso.\r\n" +
                                                    "Deseja emitir nota fiscal agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        using(Faturamento.TFLanFaturamento fFaturamento = new Faturamento.TFLanFaturamento())
                                        {
                                            fFaturamento.Nr_pedidoFaturar = retorno > 0 ? retorno.ToString() : string.Empty;
                                            fFaturamento.ShowDialog();
                                            //Verificar se o pedido ainda tem saldo, se nao, encerrar o pedido
                                            CamadaDados.Faturamento.Pedido.TList_Pedido lPedido = new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                                new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = retorno > 0 ? retorno.ToString() : string.Empty
                                                }
                                            }, 1, string.Empty);
                                            if (lPedido.Count > 0)
                                                if (lPedido[0].Vl_saldopedido <= 0)
                                                    if (MessageBox.Show("Total do pedido faturado.\r\nDeseja encerrar o pedido?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                        == DialogResult.Yes)
                                                    {
                                                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed =
                                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(retorno.ToString(), null);
                                                        rPed.ST_Pedido = "P";
                                                        rPed.St_registro = "P";
                                                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                                                        MessageBox.Show("Pedido encerrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                        }
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Taxas Processadas com Sucesso.\r\nDeseja imprimir nota fiscal?\r\n" +
                                                            "Obs.: Somente serão impressas as notas fiscais proprias e não NF-e.", "Pergunta",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                            == DialogResult.Yes)
                                    {
                                        //Buscar nota de origem
                                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          retorno.ToString(),
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          decimal.Zero,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          decimal.Zero,
                                                                                                          decimal.Zero,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          1,
                                                                                                          string.Empty,
                                                                                                          null);
                                        if (lNf.Count > 0)
                                            if (lNf[0].Tp_nota.Trim().ToUpper().Equals("P") && (!lNf[0].Cd_modelo.Trim().Equals("55")))
                                                //Chamar tela de impressao para a nota fiscal
                                                //somente se for nota propria
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = lNf[0].Cd_clifor;
                                                    fImp.pMensagem = "NOTA FISCAL Nº" + lNf[0].Nr_notafiscal.ToString();
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(lNf[0],
                                                                                                        fImp.pSt_imprimir,
                                                                                                        fImp.pSt_visualizar,
                                                                                                        fImp.pSt_enviaremail,
                                                                                                        fImp.pDestinatarios,
                                                                                                        "NOTA FISCAL Nº " + lNf[0].Nr_notafiscal.ToString(),
                                                                                                        fImp.pDs_mensagem);
                                                }
                                    }
                                }
                                bsPedido_PositionChanged(this, new EventArgs());
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Não existe taxas selecionadas para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar contrato/pedido para faturar taxas.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarTaxasProvisionadas()
        {
            if(bsPedido.Current != null)
            {
                TList_TaxaDeposito lTaxa = TCN_LanTaxas_Deposito.BuscarTx((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                                          "'P'",
                                                                          null);
                ps_provisionado.Value = lTaxa.Sum(p => p.Ps_Taxa);
                vl_provisionado.Value = lTaxa.Sum(p => p.Vl_Taxa);
            }
        }

        private void TFLan_TaxaDeposito_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, movContratoDataGridDefault);
            Utils.ShapeGrid.RestoreShape(this, sinteticoTaxasDataGridDefault);
            Utils.ShapeGrid.RestoreShape(this, gAnalitico);
            Utils.ShapeGrid.RestoreShape(this, gPedido);
            Utils.ShapeGrid.RestoreShape(this, gPesagem);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados4.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pAmostra.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pTotalTaxa.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            dt_prevista.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyy");
        }

        private void bb_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome|150;a.CD_EMPRESA|Código|80"
                            , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            string vColunas = "d.nm_clifor|Nome Contratante|250;" +
                              "a.cd_clifor|Cd. Contratante|80;" +
                              "f.nm_empresa|Empresa|250;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "a.nr_contrato|Nº Contrato|80";
            string vParam = string.Empty;
            string pontoevirgula = string.Empty;
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
                pontoevirgula = ";";
            }
            else
            {
                vParam += pontoevirgula + "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                         "where x.cd_empresa = a.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "          where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_Contrato },
                                    new TCD_CadContrato(), vParam);
        }

        private void Nr_Contrato_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_contrato|=|" + Nr_Contrato.Text + ";";
            if (cd_empresa.Text.Trim() != string.Empty)
                vColunas += "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            else
            {
                vColunas += "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_Contrato },
                                    new TCD_CadContrato());
        }

        private void bb_Contratante_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vParam = "|exists|(select 1 from tb_gro_contrato x " +
                         "where x.cd_clifor = a.cd_clifor " +
                         "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_contratante }, vParam);
        }

        private void cd_contratante_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "'";
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vColunas += ";|exists|(select 1 from tb_gro_contrato x " +
                            "where x.cd_clifor = a.cd_clifor " +
                            "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contratante },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "d.nm_clifor|Clifor Pedido|250;" +
                              "a.cd_clifor|Cd. Clifor|80;" +
                              "b.Nm_Empresa|Empresa Pedido|250;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "a.nr_pedido|Nº Pedido|80";
            string vParam = string.Empty;
            string pontoevirgula = string.Empty;
            if (Nr_Contrato.Text.Trim() != string.Empty)
            {
                vParam += pontoevirgula + "|exists|(select 1 from vtb_gro_contrato x " +
                         "where x.nr_pedido = a.nr_pedido " +
                         "and x.nr_contrato = " + Nr_Contrato.Text + ")";
                pontoevirgula = ";";
            }
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                vParam += pontoevirgula + "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
                pontoevirgula = ";";
            }
            if (cd_contratante.Text.Trim() != string.Empty)
            {
                vParam += pontoevirgula + "a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "'";
                pontoevirgula = ";";
            }
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_pedido },
                                    new CamadaDados.Faturamento.Pedido.TCD_Pedido(), vParam);
        }

        private void nr_pedido_Leave(object sender, EventArgs e)
        {
            string pontoevirgula = string.Empty;
            string vColunas = "a.nr_pedido|=|" + nr_pedido.Text;
            if (Nr_Contrato.Text.Trim() != string.Empty)
            {
                vColunas += pontoevirgula + "|exists|(select 1 from vtb_gro_contrato x " +
                                            "where x.nr_pedido = a.nr_pedido " +
                                            "and x.nr_contrato = " + Nr_Contrato.Text + ")";
                pontoevirgula = ";";
            }
            if (cd_empresa.Text.Trim() != string.Empty)
            {
                vColunas += pontoevirgula + "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
                pontoevirgula = ";";
            }
            if (cd_contratante.Text.Trim() != string.Empty)
            {
                vColunas += pontoevirgula + "a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "'";
                pontoevirgula = ";";
            }
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_pedido },
                                    new CamadaDados.Faturamento.Pedido.TCD_Pedido());
        }

        private void bb_AnoSafra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Safra|Ano Safra|200;" +
                              "a.Anosafra|Cd. Safra|80";
            string vParam = string.Empty;
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vParam = "|exists|(select 1 from tb_gro_contrato x " +
                         "where x.anosafra = a.anosafra " +
                         "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { AnoSafra },
                                    new TCD_CadSafra(), vParam);
        }

        private void AnoSafra_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.anosafra|=|'" + AnoSafra.Text.Trim() + "'";
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vColunas += ";|exists|(select 1 from tb_gro_contrato x " +
                            "where x.anosafra = a.anosafra " +
                            "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { AnoSafra },
                                    new TCD_CadSafra());
        }

        private void bb_tabeladesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabeladesconto|Tabela Desconto|200;" +
                              "a.cd_tabeladesconto|Cd. Tabela|80";
            string vParam = string.Empty;
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vParam = "|exists|(select 1 from tb_gro_contrato x " +
                         "where x.cd_tabeladesconto = a.cd_tabeladesconto " +
                         "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto },
                                    new TCD_CadDesconto(), vParam);
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            if (Nr_Contrato.Text.Trim() != string.Empty)
                vColunas += ";|exists|(select 1 from tb_gro_contrato x " +
                            "where x.cd_tabeladesconto = a.cd_tabeladesconto " +
                            "and x.nr_contrato = " + Nr_Contrato.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto },
                                    new TCD_CadDesconto());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void tcTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bsPedido.Current != null)
                if (tcTaxas.SelectedTab.Equals(tpSinteticoTaxas))
                {
                    bsSinteticoTaxa.DataSource = new TCD_SinteticoTaxas().Select((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.ToString());
                    if (bsSinteticoTaxa.Current != null)
                        //Buscar detalhes taxa
                        (bsSinteticoTaxa.Current as TRegistro_SinteticoTaxas).rTaxas = TCN_CadContratoTaxaDeposito.Buscar(decimal.Zero, 
                                                                                                                          (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.Value,
                                                                                                                          (bsSinteticoTaxa.Current as TRegistro_SinteticoTaxas).Id_taxa,
                                                                                                                          decimal.Zero, 
                                                                                                                          string.Empty, 
                                                                                                                          decimal.Zero, 
                                                                                                                          decimal.Zero, 
                                                                                                                          string.Empty,
                                                                                                                          decimal.Zero, 
                                                                                                                          decimal.Zero, 
                                                                                                                          string.Empty, 
                                                                                                                          string.Empty, 
                                                                                                                          0, 
                                                                                                                          null)[0];
                    bsSinteticoTaxa.ResetCurrentItem();
                }
                else if (tcTaxas.SelectedTab.Equals(tpAnaliticoTaxas))
                {
                    bsAnaliticoTaxa.DataSource = TCN_LanTaxas_Deposito.BuscarTx((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr, 
                                                                                string.Empty,
                                                                                null);
                    bsAnaliticoTaxa.ResetCurrentItem();
                }
        }
                
        private void TFLan_TaxaDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ReprocessarTaxasContrato();
            else if (e.KeyCode.Equals(Keys.F10))
                FaturarTaxasContrato();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsSinteticoTaxa_PositionChanged(object sender, EventArgs e)
        {
            if (bsSinteticoTaxa.Current != null)
                //Buscar detalhes taxa
                (bsSinteticoTaxa.Current as TRegistro_SinteticoTaxas).rTaxas = TCN_CadContratoTaxaDeposito.Buscar(decimal.Zero, 
                                                                                                                  (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.Value,
                                                                                                                  (bsSinteticoTaxa.Current as TRegistro_SinteticoTaxas).Id_taxa,
                                                                                                                  decimal.Zero, 
                                                                                                                  string.Empty, 
                                                                                                                  decimal.Zero, 
                                                                                                                  decimal.Zero, 
                                                                                                                  string.Empty,
                                                                                                                  decimal.Zero, 
                                                                                                                  decimal.Zero, 
                                                                                                                  string.Empty, 
                                                                                                                  string.Empty, 
                                                                                                                  0, 
                                                                                                                  null)[0];
            bsSinteticoTaxa.ResetCurrentItem();
        }

        private void BB_ReprocessaTaxas_Click(object sender, EventArgs e)
        {
            ReprocessarTaxasContrato();
        }

        private void bsPedido_PositionChanged(object sender, EventArgs e)
        {
            if (bsPedido.Current != null)
            {
                //Buscar Movimentacao
                (bsPedido.Current as TRegistro_PedidoAplicacao).MovContrato = 
                    new TCD_MovContrato().Select(new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca
                                                    {
                                                        vNM_Campo = "c.nr_contrato",
                                                        vOperador = "=",
                                                        vVL_Busca = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.ToString()
                                                    }
                                                }, 0, string.Empty);
                //Buscar sintetico Taxas
                (bsPedido.Current as TRegistro_PedidoAplicacao).SinteticoTaxas = 
                    new TCD_SinteticoTaxas().Select((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.ToString());
                //Buscar Analitico Taxas
                (bsPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas = 
                    TCN_LanTaxas_Deposito.BuscarTx((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr, 
                                                 string.Empty,
                                                 null);

                //Totalizar Registro
                totalizarMovimentacao();
                totalizarTaxas();
                bsPedido.ResetCurrentItem();
                bsSinteticoTaxa_PositionChanged(this, new EventArgs());
                bsAnaliticoTaxa_PositionChanged(this, new EventArgs());
                //Buscar taxa realizar
                try
                {
                    bsTaxaRealizar.DataSource = TCN_MovDeposito.CalcularTaxasExpedicaoPendentes(
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto,
                                                dt_prevista.Data,
                                                string.Empty);
                    TotalizarTaxasRealizar();
                }
                catch
                {}
                //Buscar taxas provisionadas
                BuscarTaxasProvisionadas();
            }
        }

        private void totalizarTaxas()
        {
            if(bsPedido.Current != null)
            {
                qtd_taxa_fat.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("P")).Sum(p => p.Ps_Taxa);
                qtd_peso_faturar.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("A")).Sum(p => p.Ps_Taxa);
                qtd_pesototal.Value = qtd_taxa_fat.Value + qtd_peso_faturar.Value;
                vl_taxa_fat.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_Taxa);
                vl_taxa_faturar.Value = (bsPedido.Current as TRegistro_PedidoAplicacao).AnaliticoTaxas.Where(p => p.St_registro.Trim().ToUpper().Equals("A")).Sum(p => p.Vl_Taxa);
                vl_taxa_total.Value = vl_taxa_faturar.Value + vl_taxa_fat.Value;
            }
        }

        private void gAnalitico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gAnalitico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gAnalitico.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_Faturar_Click(object sender, EventArgs e)
        {
            FaturarTaxasContrato();
        }

        private void bsAnaliticoTaxa_PositionChanged(object sender, EventArgs e)
        {
            //Buscar origem taxas
            if (bsAnaliticoTaxa.Current != null)
                if ((bsAnaliticoTaxa.Current as TRegistro_TaxaDeposito).Tp_Lancto.Trim().ToUpper().Equals("A"))
                {
                    //Buscar ticket origem
                    bsPesagem.DataSource = CamadaNegocio.Balanca.TCN_LanPesagemGraos.Busca((bsAnaliticoTaxa.Current as TRegistro_TaxaDeposito).Cd_empresa,
                                                                                           (bsAnaliticoTaxa.Current as TRegistro_TaxaDeposito).Id_ticket.Value.ToString(),
                                                                                           (bsAnaliticoTaxa.Current as TRegistro_TaxaDeposito).Tp_pesagem,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           decimal.Zero,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           0,
                                                                                           string.Empty,
                                                                                           null);
                    bsPesagem_PositionChanged(this, new EventArgs());
                }
        }

        private void bsPesagem_PositionChanged(object sender, EventArgs e)
        {
            if (bsPesagem.Current != null)
            {
                //Buscar classificacao do ticket
                bsClassificacao.DataSource =
                    CamadaNegocio.Balanca.TCN_LanClassificacao.Buscar((bsPesagem.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                      (bsPesagem.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                      (bsPesagem.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      0,
                                                                      string.Empty,
                                                                      null);
            }
        }

        private void bb_recalctaxa_realizar_Click(object sender, EventArgs e)
        {
            
        }

        private void bb_recalcular_Click(object sender, EventArgs e)
        {
            if (bsPedido.Current != null)
            {
                try
                {
                    bsTaxaRealizar.DataSource = TCN_MovDeposito.CalcularTaxasExpedicaoPendentes(
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto,
                                                dt_prevista.Data,
                                                string.Empty);
                    TotalizarTaxasRealizar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bb_provisao_Click(object sender, EventArgs e)
        {
            if ((bsTaxaRealizar.Count > 0) && (bsPedido.Current != null))
            {
                if (dt_prevista.Data.Date > CamadaDados.UtilData.Data_Servidor().Date)
                {
                    MessageBox.Show("Data prevista deve ser menor ou igual a data atual para gerar provisão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_prevista.Focus();
                    return;
                }
                using (TFProvisionarTaxas fProvisao = new TFProvisionarTaxas())
                {
                    fProvisao.Cd_empresa = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa;
                    fProvisao.Nr_contrato = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr;
                    fProvisao.Cd_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto;
                    fProvisao.Dt_prevista = dt_prevista.Data;
                    if (fProvisao.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Provisão realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsPedido_PositionChanged(this, new EventArgs());
                    }
                }
            }
            else
                MessageBox.Show("Não existe taxa a realizar para gerar provisão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tot_pesorealizar_ValueChanged(object sender, EventArgs e)
        {
            ps_disponivel.Value = tot_pesorealizar.Value - ps_provisionado.Value;
        }

        private void ps_provisionado_ValueChanged(object sender, EventArgs e)
        {
            ps_disponivel.Value = tot_pesorealizar.Value - ps_provisionado.Value;
        }

        private void tot_valorrealizar_ValueChanged(object sender, EventArgs e)
        {
            vl_disponivel.Value = tot_valorrealizar.Value - vl_provisionado.Value;
        }

        private void vl_provisionado_ValueChanged(object sender, EventArgs e)
        {
            vl_disponivel.Value = tot_valorrealizar.Value - vl_provisionado.Value;
        }

        private void bb_excluirtaxa_Click(object sender, EventArgs e)
        {
            if(bsPedido.Current != null)
                using (TFExcluirTaxasProvisionadas fExcluir = new TFExcluirTaxasProvisionadas())
                {
                    fExcluir.Nr_contrato = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr;
                    if(fExcluir.ShowDialog() == DialogResult.OK)
                        if (fExcluir.lTaxa != null)
                        {
                            try
                            {
                                TCN_LanTaxas_Deposito.ExcluirTaxasProvisionadas(fExcluir.lTaxa, null);
                                MessageBox.Show("Taxas provisionadas/manuais excluidas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsPedido_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_incluirtx_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFLan_TaxaDeposito_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, movContratoDataGridDefault);
            Utils.ShapeGrid.SaveShape(this, sinteticoTaxasDataGridDefault);
            Utils.ShapeGrid.SaveShape(this, gAnalitico);
            Utils.ShapeGrid.SaveShape(this, gPedido);
            Utils.ShapeGrid.SaveShape(this, gPesagem);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
        }
    }
}
