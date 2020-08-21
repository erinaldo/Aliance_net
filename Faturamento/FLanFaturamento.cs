using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using Financeiro;
using Componentes;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaNegocio.Estoque;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using FormRelPadrao;
using CamadaNegocio.Financeiro.Cadastros;
using Proc_Commoditties;

namespace Faturamento
{
    public partial class TFLanFaturamento : Form
    {
        public TTpModo vTP_Modo;
        public TTpModo vTP_ModoItem;
        private TList_RegLanFaturamento ListaNF;
        private bool st_equiparado_pj = false;
        private bool st_equiparado_pf = false;
        private bool st_permite_pedidoparcial = false;
        private bool st_confere_saldo = false;
        private bool st_valoresfixos = false;
        private bool st_exigirconferenciaentrega = false;
        private bool st_devolucao = false;
        private bool st_retorno = false;
        private bool st_complemento = false;
        private bool st_compdevimposto = false;
        private bool st_mestra = false;
        private bool st_simplesRemessa = false;
        private bool st_controleTitulo = false;
        private bool st_gerarEstoque = false;
        private bool st_atualizaprecovenda = false;
        private bool st_geraretiqueta = false;
        private string tp_pessoa = string.Empty;
        private string cd_unidProduto = string.Empty;
        private decimal tQtdPedido = decimal.Zero;
        private decimal tVlPedido = decimal.Zero;
        private decimal tQtdEstPedido = decimal.Zero;
        private decimal tVlEstPedido = decimal.Zero;
        private bool st_sequenciaauto = false;
        private string Tp_serie = string.Empty;
        private string tp_docto = string.Empty;
        private string ds_tpdocto = string.Empty;
        public string Nr_pedidoFaturar = string.Empty;
        public string vTp_movimento = string.Empty;
        public string vTp_NFFiscal = string.Empty;
        private bool Altera_Relatorio = false;

        public TFLanFaturamento()
        {
            InitializeComponent();
            tcDetalhe.TabPages.Remove(tpEx);
            pDadosNotas.set_FormatZero();
            pDadosFretes.set_FormatZero();
            pItensNota.set_FormatZero();
            panelBusca.set_FormatZero();
            pImpostos.set_FormatZero();
            pEntrega.set_FormatZero();
            pEx.set_FormatZero();
            ListaNF = new TList_RegLanFaturamento();
            bsNotaFiscal.DataSource = ListaNF;
            vTP_Modo = TTpModo.tm_Standby;
            vTP_ModoItem = TTpModo.tm_Standby;

            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new TDataCombo("ENTRADA", "E"));
            CBox1.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = CBox1;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";

            ArrayList cBox2 = new ArrayList();
            cBox2.Add(new TDataCombo("EMITENTE", "0"));
            cBox2.Add(new TDataCombo("DESTINATARIO", "1"));
            cBox2.Add(new TDataCombo("TERCEIRO", "2"));
            cBox2.Add(new TDataCombo("SEM FRETE", "9"));
            freteporconta.DataSource = cBox2;
            freteporconta.DisplayMember = "Display";
            freteporconta.ValueMember = "Value";

            ArrayList cBox3 = new ArrayList();
            cBox3.Add(new TDataCombo("PROPRIA", "P"));
            cBox3.Add(new TDataCombo("TERCEIRO", "T"));
            tp_nota.DataSource = cBox3;
            tp_nota.DisplayMember = "Display";
            tp_nota.ValueMember = "Value";

            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("0-Nacional", "0"));
            cbx.Add(new TDataCombo("1-Estrangeira - Importação Direta", "1"));
            cbx.Add(new TDataCombo("2-Estrangeira - Adquirada Mercado Interno", "2"));
            cbx.Add(new TDataCombo("3-Nacional - Importação 40% a 70%", "3"));
            cbx.Add(new TDataCombo("4-Nacional - Outros", "4"));
            cbx.Add(new TDataCombo("5-Nacional - Importação <= 40%", "5"));
            cbx.Add(new TDataCombo("6-Estrangeira - Importação Direta sem Similar Nacional", "6"));
            cbx.Add(new TDataCombo("7-Estrangeira - Adquirida Mercado Nacional Sem Similar", "7"));
            cbx.Add(new TDataCombo("8-Nacional - Importação > 70%", "8"));
            tp_origem.DataSource = cbx;
            tp_origem.DisplayMember = "Display";
            tp_origem.ValueMember = "Value";

            ArrayList cbx4 = new ArrayList();
            cbx4.Add(new TDataCombo("IGNORAR", "I"));
            cbx4.Add(new TDataCombo("SOMAR", "S"));
            cbx4.Add(new TDataCombo("DIMINUIR", "D"));
            st_totalnota.DataSource = cbx4;
            st_totalnota.DisplayMember = "Display";
            st_totalnota.ValueMember = "Value";
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void ModoBotoesItens()
        {
            if (vTP_ModoItem.Equals(TTpModo.tm_Standby) ||
                vTP_ModoItem.Equals(TTpModo.tm_busca))
            {
                BB_InsereItem.Visible = true;
                BB_AlterarItem.Visible = true;
                BB_GravarItem.Visible = false;
                BB_DeletaItem.Visible = true;
                gItensNota.Enabled = true;
            }
            else if (vTP_ModoItem.Equals(TTpModo.tm_Insert) ||
                vTP_ModoItem.Equals(TTpModo.tm_Edit))
            {
                BB_InsereItem.Visible = false;
                BB_AlterarItem.Visible = false;
                BB_GravarItem.Visible = true;
                BB_DeletaItem.Visible = true;
                gItensNota.Enabled = false;
            }
        }

        private void modoBotoes()
        {
            if (vTP_Modo == TTpModo.tm_Standby)
            {
                BB_Novo.Visible = true;
                BB_Gravar.Visible = false;
                BB_Excluir.Visible = false;
                BB_Cancelar.Visible = false;
                BB_Buscar.Visible = true;
                BB_Imprimir.Visible = false;
            }
            else if (vTP_Modo == TTpModo.tm_Insert)
            {
                BB_Novo.Visible = false;
                BB_Gravar.Visible = true;
                BB_Excluir.Visible = false;
                BB_Cancelar.Visible = true;
                BB_Buscar.Visible = false;
                BB_Imprimir.Visible = false;
            }
            else if (vTP_Modo == TTpModo.tm_busca)
            {
                BB_Novo.Visible = true;
                BB_Gravar.Visible = false;
                BB_Excluir.Visible = true;
                BB_Cancelar.Visible = false;
                BB_Buscar.Visible = true;
                BB_Imprimir.Visible = true;
            }
        }

        private void HabilitarCamposImpostos(bool st_campo, TTpModo vModo)
        {
            //ICMS
            vlBaseCalcICMS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pReducaoBC.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pAliquotaICMS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pReducaoAliquota.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vlICMS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pRetencaoICMS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vlICMSRetido.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vlBCStICMS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pReducaoBCSt.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pAliquotaST.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vlICMSST.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_fcp.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_fcp.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_fcpst.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_fcpst.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            //IPI
            vl_baseCalcIPI.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pAliquotaIPI.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_ipi.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            st_totalnota.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            //PIS
            //cd_st_pis.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_basecreditoPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            id_tpcredPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_tpcontribuicaoPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_detrecisentaPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_receitaPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_basecalcPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_aliquotaPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_pis.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoPIS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            editFloat1.Enabled = st_campo && vTP_ModoItem.Equals(vModo);


            //cd_st_cofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_basecredCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_tpcredCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_tpcontribuicaoCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_detrecisentaCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            id_receitaCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_basecalcCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_aliquotaCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_cofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidoCofins.Enabled = st_campo && vTP_ModoItem.Equals(vModo);


            vl_basecalcISS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_aliquotaISS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_iss.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_reducaobasecalcISS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoISS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_issretido.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            dsDeducao.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            
            //CSLL
            vl_basecalcCSLL.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_redbasecalccsll.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoCSLL.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidoCSLL.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_percentualCSLL.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_CSLL.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            //INSS
            vl_basecalcINSS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_redbasecalcinss.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoINSS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidoINSS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_percentualINSS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_INSS.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            vl_basecalcFunrural.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_funrural.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_funrural.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoFunrural.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidofunrural.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_basecalcSenar.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_senar.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_senar.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoSenar.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidoSenar.Enabled = st_campo && vTP_ModoItem.Equals(vModo);


            editFloat5.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            editFloat4.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            editFloat3.Enabled = st_campo && vTP_ModoItem.Equals(vModo);

            //IRRF
            vl_percentualIRRF.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_IRRF.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_basecalcIRRF.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_redbasecalcirrf.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            pc_retencaoIRRF.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
            vl_retidoIRRF.Enabled = st_campo && vTP_ModoItem.Equals(vModo);
        }

        private void habilitarNovaNf()
        {
            pDadosNotas.HabilitarControls(true, vTP_Modo);
            pBuscaObs.HabilitarControls(true, vTP_Modo);
            pDadosFretes.HabilitarControls(true, vTP_Modo);
            pEx.HabilitarControls(true, vTP_Modo);
            pEntrega.HabilitarControls(true, vTP_Modo);
            ds_DadosAdicionais.Enabled = true;
            ds_ObservacaoFiscal.Enabled = true;
        }

        private void ProcessarRetornoOs()
        {
            CamadaDados.Servicos.TList_LanServico lOs = new CamadaDados.Servicos.TCD_LanServico().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.nr_pedidointegra",
                                                                    vOperador = "=",
                                                                    vVL_Busca = NR_Pedido.Text
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "isnull(a.st_os, 'AB')",
                                                                    vOperador = "<>",
                                                                    vVL_Busca = "'CA'"
                                                                },
                                                                //Ordem servico com NF de Remessa
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x "+
                                                                                "inner join tb_fat_notafiscal_item y "+
                                                                                "on x.nr_pedido = y.nr_pedido "+
                                                                                "and x.cd_produto = y.cd_produto "+
                                                                                "and x.id_pedidoitem = y.id_pedidoitem "+
                                                                                "inner join tb_fat_notafiscal z "+
                                                                                "on y.cd_empresa = z.cd_empresa "+
                                                                                "and y.nr_lanctofiscal = z.nr_lanctofiscal "+
                                                                                "where x.cd_empresa = a.cd_empresa "+
                                                                                "and x.id_os = a.id_os "+
                                                                                "and isnulL(z.st_registro, 'A') <> 'C' "+
                                                                                "and x.tp_pedido = 'RM')"
                                                                },
                                                                //Sem NF de Retorno
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "not exists",
                                                                    vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x "+
                                                                                "inner join tb_fat_notafiscal_item y "+
                                                                                "on x.nr_pedido = y.nr_pedido "+
                                                                                "and x.cd_produto = y.cd_produto "+
                                                                                "and x.id_pedidoitem = y.id_pedidoitem "+
                                                                                "inner join tb_fat_notafiscal z "+
                                                                                "on y.cd_empresa = z.cd_empresa "+
                                                                                "and y.nr_lanctofiscal = z.nr_lanctofiscal "+
                                                                                "inner join tb_fat_notafiscal_cmi w "+
                                                                                "on z.cd_empresa = w.cd_empresa "+
                                                                                "and z.nr_lanctofiscal = w.nr_lanctofiscal "+
                                                                                "where x.cd_empresa = a.cd_empresa "+
                                                                                "and x.id_os = a.id_os "+
                                                                                "and isnull(z.st_registro, 'A') <> 'C' "+
                                                                                "and x.tp_pedido = 'RM' "+
                                                                                "and (isnull(w.st_devolucao, 'N') = 'S' or isnull(w.st_retorno, 'N') = 'S'))"
                                                                }
                                                            }, 0, string.Empty, string.Empty);
            if (lOs.Count > 0)
                if (MessageBox.Show("Pedido Integra Ordem de Serviço com Nota Fiscal de Remessa.\r\n" +
                                   "Deseja emitir Nota Fiscal de retorno destes produto?",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Processar Nota Fiscal de Retorno de Conserto
                        TRegistro_LanFaturamento rNfRetorno = TCN_LanFaturamento.ProcessarNotaFiscalRetornoConserto(lOs);
                        //Para cada item da nota 
                        //amarrar a nota de entrada
                        rNfRetorno.ItensNota.ForEach(p =>
                        {
                            using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                            {
                                fCompDevol.Cd_empresa = p.Cd_empresa;
                                fCompDevol.Nr_pedido = p.Nr_pedido.ToString();
                                fCompDevol.Cd_produto = p.Cd_produto;
                                fCompDevol.Cd_clifor = rNfRetorno.Cd_clifor;
                                fCompDevol.St_vldevNfOrigem = true;
                                if (rNfRetorno.lCFGFiscal[0].ST_Complementar.ToString().Trim().ToUpper().Equals("S"))
                                {
                                    fCompDevol.Tp_operacao = "C";
                                    fCompDevol.Tp_movimento = rNfRetorno.Tp_movimento;
                                }
                                else if (rNfRetorno.lCFGFiscal[0].ST_Devolucao.Trim().ToUpper().Equals("S") ||
                                    rNfRetorno.lCFGFiscal[0].ST_Retorno.Trim().ToUpper().Equals("S"))
                                {
                                    fCompDevol.Tp_operacao = "D";
                                    if (rNfRetorno.Tp_movimento.Trim().Equals("E"))
                                        fCompDevol.Tp_movimento = "S";
                                    else if (rNfRetorno.Tp_movimento.Trim().Equals("S"))
                                        fCompDevol.Tp_movimento = "E";
                                }
                                fCompDevol.Quantidade = p.Quantidade;
                                fCompDevol.Valor = p.Vl_subtotal;
                                if (fCompDevol.ShowDialog() == DialogResult.OK)
                                {
                                    p.lNfcompdev = fCompDevol.ListaCompDev;
                                    p.Vl_unitario = (fCompDevol.ListaCompDev.Sum(v => v.Vl_lancto) / p.Quantidade);
                                }
                                else
                                    throw new Exception("Obrigatorio informar notas a serem processadas.");
                                //Observação do Item com os dados das notas de orig
                                string obsitem = string.Empty;
                                fCompDevol.ListaCompDev.ForEach(v =>
                                {
                                    obsitem += (v.Nr_notafiscal_origem.ToString() + "/" + v.Nr_serie_origem).FormatStringDireita(21, ' ') +
                                                (v.Qtd_lancto.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                                p.Sigla_unidade_estoque.Trim()).FormatStringDireita(15, ' ') +
                                                v.Vl_lancto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n";
                                });
                                p.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obsitem;
                            }
                        });
                        TCN_LanFaturamento.GravarFaturamento(rNfRetorno, null, null);
                        MessageBox.Show("Nota Fiscal de Retorno gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P"))
                        {
                            //Buscar nota fiscal gravada para completar o objeto nota com os dados descritivos
                            //Chamar tela de impressao para a nota fiscal
                            //somente se for nota propria
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                                fImp.pMensagem = "NOTA FISCAL Nº" + rNfRetorno.Nr_notafiscal.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                {
                                    //Buscar Dt.Processamento
                                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                            vOperador = "=",
                                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, "a.dt_processamento");
                                    if (obj != null)
                                        rNfRetorno.Dt_processamento = DateTime.Parse(obj.ToString());
                                    //Buscar Nr.Protocolo
                                    object nr_proc = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                            vOperador = "=",
                                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, "a.Nr_protocolo");
                                    if (nr_proc != null)
                                        rNfRetorno.Nr_protocolo = nr_proc.ToString();
                                    Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF(rNfRetorno.Cd_empresa,
                                                                                                                             rNfRetorno.Nr_lanctofiscalstr,
                                                                                                                             null),
                                                            fImp.pSt_imprimir,
                                                            fImp.pSt_visualizar,
                                                            fImp.pSt_enviaremail,
                                                            fImp.pDestinatarios,
                                                            "NOTA FISCAL Nº " + rNfRetorno.Nr_notafiscal.ToString(),
                                                            fImp.pDs_mensagem);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private string VerificarSaldoEstoque()
        {
            string msg = string.Empty;
            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
            {
                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoSemente(p.Cd_produto)) &&
                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                    {
                        //Buscar item do pedido
                        TList_RegLanPedido_Item lItemPed = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                    string.Empty,
                                                                                    p.Cd_produto,
                                                                                    p.Nr_pedido.ToString(),
                                                                                    p.Id_pedidoitemstr,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    false,
                                                                                    null);
                        if (lItemPed.Count > 0)
                        {
                            lItemPed[0].Quantidade = p.Quantidade;
                            TList_RegLanPedido_Item lItem = new TList_RegLanPedido_Item();
                            TCN_Pedido.MontarFichaTecItem(CD_Empresa.Text,
                                                          p.Cd_local,
                                                          lItemPed[0],
                                                          lItem);
                            if (lItem.Exists(v => v.St_semsaldoestoque))
                            {
                                msg += "Produto composto " + p.Cd_produto.Trim() + " sem saldo de materia prima para faturar.\r\n";
                                List<TRegistro_LanPedido_Item> lItemSaldo = lItem.FindAll(v => v.St_semsaldoestoque);
                                lItemSaldo.ForEach(v => msg += "Materia Prima: " + v.Cd_produto.Trim() + " Qtd: " + v.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + " Saldo: " +
                                    v.Qtd_estoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n");
                            }
                        }
                    }
                    else
                    {
                        //Buscar saldo estoque para o item
                        decimal saldo_estoque = TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, p.Cd_produto, p.Cd_local, null);
                        if (p.Quantidade > saldo_estoque)
                            msg += "Produto " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                   "Empresa " + CD_Empresa.Text.Trim() + "-" + NM_Empresa.Text.Trim() + "\r\n" +
                                   "Local " + p.Cd_local.Trim() + "-" + p.Ds_local.Trim() + "\r\n" +
                                   "Qtd..: " + p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                                   "Saldo: " + saldo_estoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
                    }
            });
            return msg;
        }

        private void afterNovo()
        {
            if (vTP_Modo != TTpModo.tm_Insert)
            {
                vTP_Modo = TTpModo.tm_Insert;
                vTP_ModoItem = TTpModo.tm_Standby;
                modoBotoes();
                ModoBotoesItens();
                tcFaturamento.SelectedTab = tabLancamento;
                bsNotaFiscal.AddNew();
                bsItensNota.Clear();
                bsImpostosItens.Clear();
                NR_Pedido.Enabled = true;
                bb_pedido.Enabled = true;
                NR_Pedido.Focus();
                if (tcFaturamento.TabPages.Contains(tpNavegador))
                    tcFaturamento.TabPages.Remove(tpNavegador);
                tp_nota.SelectedIndex = -1;
            }
        }

        private void afterGrava()
        {
            if (!tcFaturamento.SelectedTab.Equals(tabLancamento))
                tcFaturamento.SelectedTab = tabLancamento;
            if (dsDeducao.Enabled && string.IsNullOrEmpty(dsDeducao.Text))
            {
                MessageBox.Show("Quando é informado Red. BC. para ISS é obrigatório informar a descrição (Ds. Dedução Ref. Red. BC. ISS.)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((pDadosNotas.validarCampoObrigatorio()) &&
                (pDadosFretes.validarCampoObrigatorio()))
            {
                if (st_servico.Checked && string.IsNullOrEmpty(cd_municipioexecservico.Text))
                {
                    MessageBox.Show("Obrigatorio informar municipio execução do serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_municipioexecservico.Focus();
                    return;
                }
                if (vTP_ModoItem.Equals(TTpModo.tm_Insert) || vTP_ModoItem.Equals(TTpModo.tm_Edit))
                    afterGravaItensNF();
                if ((bsItensNota.Count <= 0) || (vTP_ModoItem != TTpModo.tm_Standby))
                {
                    MessageBox.Show("Não é permitido gravar nota fiscal sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcFaturamento.SelectedTab = tabItens;
                    return;
                }
                //Verificar estoque da nota
                if (tp_movimento.Text.Trim().ToUpper().Equals("SAIDA") && st_geraestoque.Checked)
                {
                    string msg = VerificarSaldoEstoque();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //Verificar se e exportacao
                if (cd_uf_clifor.Text.Trim().Equals("99") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("S") &&
                    (!st_devolucao) &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    if (string.IsNullOrEmpty(cd_ufsaidaex.Text))
                    {
                        MessageBox.Show("Obrigatório informar UF Saida para EXPORTAÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!tcDetalhe.SelectedTab.Equals(tpEx))
                            tcDetalhe.SelectedTab = tpEx;
                        cd_ufsaidaex.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(ds_localex.Text))
                    {
                        MessageBox.Show("Obrigatório informar LOCAL SAIDA para EXPORTAÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!tcDetalhe.SelectedTab.Equals(tpEx))
                            tcDetalhe.SelectedTab = tpEx;
                        ds_localex.Focus();
                        return;
                    }
                }
                //Verificar se e NFe de Terceiro e nao e Servico
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T") &&
                    (!Tp_serie.Trim().ToUpper().Equals("S")))
                {
                    if (ChaveAcessoNFE.Text.Trim().Length.Equals(44))
                    {
                        if (Estruturas.Mod11(ChaveAcessoNFE.Text.Trim().Substring(0, 43), 9, false, 0).ToString() != ChaveAcessoNFE.Text.Trim().Substring(43, 1))
                        {
                            MessageBox.Show("Chave acesso NFe invalida, verifique e informe novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChaveAcessoNFE.Focus();
                            return;
                        }
                        //Validar UF do Emitente
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim() != ChaveAcessoNFE.Text.Trim().Substring(0, 2))
                        {
                            MessageBox.Show("Estado do Fornecedor <" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim() + ">" +
                                            "diferente do estado informado na chave de acesso da NFe<" + ChaveAcessoNFE.Text.Trim().Substring(0, 2) + ".\r\n" +
                                            "Necessario corrigir o cadastro do fornecedor para gravar a NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar CNPJ
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_cgc_cpf.Trim().SoNumero() != ChaveAcessoNFE.Text.Trim().Substring(6, 14))
                        {
                            if (MessageBox.Show("CNPJ/CPF do Fornecedor<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_cgc_cpf.Trim() + ">" +
                                            "diferente do CNPJ/CPF informado na chave de acesso da NFe<" + ChaveAcessoNFE.Text.Trim().Substring(6, 14) + ".\r\n" +
                                            "Necessario corrigir o cadastro do fornecedor para gravar a NFe.\r\n" +
                                            "Deseja gravar nota fiscal mesmo assim?", "Pergunta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                                return;
                        }
                        //Validar Modelo Documento Fiscal
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().FormatStringEsquerda(2, '0') != ChaveAcessoNFE.Text.Trim().Substring(20, 2))
                        {
                            MessageBox.Show("Modelo Documento Fiscal<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().FormatStringEsquerda(2, '0') + ">" +
                                            "diferente do modelo informado na chave acesso NFe<" + ChaveAcessoNFE.Text.Trim().Substring(20, 2) + ".\r\n" +
                                            "Necessario corrigir modelo informado para gravar NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar serie NFe
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim().FormatStringEsquerda(3, '0') != ChaveAcessoNFE.Text.Trim().Substring(22, 3))
                        {
                            MessageBox.Show("Numero serie NFe<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim().FormatStringEsquerda(3, '0') + ">" +
                                            "diferente da serie informada na chave acesso NFe<" + ChaveAcessoNFE.Text.Trim().Substring(22, 3) + ".\r\n" +
                                            "Obrigatorio informar serie correta para gravar NFe.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Validar numero da NFe
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString().FormatStringEsquerda(9, '0') != ChaveAcessoNFE.Text.Trim().Substring(25, 9))
                        {
                            MessageBox.Show("Numero da NFe<" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString().FormatStringEsquerda(9, '0') + ">" +
                                            "diferente do numero da NFe informado na chave de acesso<" + ChaveAcessoNFE.Text.Trim().Substring(25, 9) + ".\r\n" +
                                            "Obrigatorio informar numero da NFe correto para gravar nota.", "Mensagem",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chave de acesso imcompleta. A chave de acesso deve conter 44 caracteres.<Total Caracteres: " + ChaveAcessoNFE.Text.Trim().Length.ToString() + ">",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChaveAcessoNFE.Focus();
                        return;
                    }
                }
                //Pedido exige conferencia de entrega
                if (st_exigirconferenciaentrega &&
                    (!st_devolucao) &&
                    (!st_complemento) &&
                    (!st_compdevimposto) &&
                    (!st_retorno))
                {
                    //Buscar conferencias dos itens da nota fiscal
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                        {
                            p.lEntrega = TCN_LanEntregaPedido.Busca(string.Empty,
                                                                    p.Nr_pedido.ToString(),
                                                                    p.Cd_produto,
                                                                    p.Id_pedidoitemstr,
                                                                    true,
                                                                    "P",
                                                                    null);
                            p.Qtd_totalconferencia = p.lEntrega.Sum(v => v.Saldo);
                        }
                    }
                        );
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => p.Qtd_difFatConf > 0 &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto))))
                    {
                        using (TFLan_ApurarDifConferencia fDif = new TFLan_ApurarDifConferencia())
                        {
                            fDif.bsItensNota.DataSource = (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota;
                            fDif.ShowDialog();
                            bool continuar = true;
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                            {
                                if (p.lEntrega != null)
                                    if (p.lEntrega.Exists(v => v.St_recontar))
                                        continuar = false;
                            });
                            if (!continuar)
                                return;
                            if (!(MessageBox.Show("Existe diferença entre os itens da nota fiscal e a conferência.\r\n" +
                                               "Deseja gravar nota fiscal mesmo assim?", "Pergunta", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                                return;
                        }
                    }
                }
                //Verificar se o pedido integra almoxarifado
                if (new TCD_CadCFGPedido().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_integraralmox, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_pedidostring + ")"
                        }
                    }, "1") != null)
                {
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALOCACAO ITENS ALMOXARIFADO", null))
                        //Buscar os itens que nao tem alocacao no almoxarifado
                        new TCD_LanPedido_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_pedidostring
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "not exists",
                                    vVL_Busca = "(select 1 from tb_fat_entregapedido x " +
                                                "where x.nr_pedido = a.nr_pedido " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_pedidoitem = a.id_pedidoitem)"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(p =>
                            {
                                using (TFAlocarItem fAloc = new TFAlocarItem())
                                {
                                    fAloc.Cd_empresa = CD_Empresa.Text;
                                    fAloc.Cd_produto = p.Cd_produto;
                                    fAloc.Ds_produto = p.Ds_produto;
                                    fAloc.Sigla_unidade = p.Sg_unidade_est;
                                    fAloc.Quantidade = p.Quantidade;
                                    if (fAloc.ShowDialog() == DialogResult.OK)
                                        try
                                        {
                                            CamadaNegocio.Almoxarifado.TCN_AlocacaoItem.AlocarItem(
                                                new TRegistro_EntregaPedido()
                                                {
                                                    Nr_pedido = p.Nr_pedido,
                                                    Cd_produto = p.Cd_produto,
                                                    Id_pedidoitem = p.Id_pedidoitem,
                                                    Login = Utils.Parametros.pubLogin,
                                                    Qtd_entregue = fAloc.Quantidade,
                                                    Dt_entrega = CamadaDados.UtilData.Data_Servidor(),
                                                    Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA ALOCACAO ITEM NO ALMOXARIFADO",
                                                    Id_almoxstr = fAloc.Id_almox,
                                                    St_registro = "P"
                                                }
                                                , null);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                }
                            });
                    else
                    {
                        MessageBox.Show("Obrigatorio alocar itens no almoxarifado antes de realizar o faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                /***********EXIGIR RASTREIO DA NF*********/
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("S"))
                {
                    object obj = new TCD_CadCFGPedido("SqlCodeBuscaXPedido").BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "b.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = "'"+(bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_pedido.ToString()+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "b.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'"+(bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim()+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.ST_Rastrear_NFOrig, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1");
                    if (obj != null)
                        if (obj.ToString().Trim().ToUpper().Equals("1"))
                        {
                            TFLan_Originacao fOriginacao = new TFLan_Originacao((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota);
                            try
                            {
                                //COLOCA OS DADOS DA NOTA FISCAL
                                fOriginacao.labelTitulo.Text = "Nota Fiscal Nr.: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                                fOriginacao.ShowDialog();

                                if (fOriginacao.fechaNormal)
                                {
                                    //(bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Clear();
                                    //(bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota = fOriginacao.BS_ItensNota.DataSource as TList_RegLanFaturamento_Item;

                                    //VERIFICA SE ESTA CHEIO AS OIGINAÇÕES
                                    for (int i = 0; i < (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Count; i++)
                                    {
                                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota[i].Quantidade !=
                                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota[i].lOriginacao_x_Faturamento.Sum(p => p.QTD_Origem))
                                        {
                                            MessageBox.Show("Obrigatório informar os valores e quantidades totais da nota fiscal para originação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar a originação da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            finally
                            {
                                fOriginacao.Dispose();
                            }
                        }
                }
                //Devolver financeiro
                if (st_devolucao || st_retorno)
                {
                    TList_RegLanParcela lParcDev = new TList_RegLanParcela();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                        p.lNfcompdev.ForEach(v =>
                            //Buscar Parcelas em Aberto da NF Devolvida
                            new TCD_LanParcela().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                    "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                    "and x.nr_lanctofiscal = " + v.Nr_lanctofiscal_origem.Value.ToString() + ")"
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty).ForEach(x => lParcDev.Add(x))));
                    if (lParcDev.Count > 0)
                        if (MessageBox.Show("Notas fiscais devolvidas possui financeiro.\r\n" +
                                           "Deseja devolver estes financeiros?",
                                           "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).lParcDev = lParcDev;
                }
                //Gerar Financeiro
                if ((!tp_duplicata.Text.Trim().Equals(string.Empty)) && ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Vl_totalnota > 0))
                {
                    //Buscar config CMI
                    CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(CD_CMI.Text,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 false,
                                                                                                 false,
                                                                                                 false,
                                                                                                 false,
                                                                                                 false,
                                                                                                 false,
                                                                                                 false,
                                                                                                 null);

                    //Buscar Configurações da Condição de Pagamento
                    TList_CadCondPgto lCondPgto = TCN_CadCondPgto.Buscar(CD_CondPGTO.Text,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            decimal.Zero,
                                                                                                            decimal.Zero,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            1,
                                                                                                            string.Empty,
                                                                                                            null);
                    //Buscar moeda do pedido
                    TList_Moeda lMoedaPed = new TCD_Moeda().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from vtb_fat_pedido x "+
                                            "where x.cd_moeda = a.cd_moeda "+
                                            "and x.nr_pedido = "+NR_Pedido.Text.Trim()+")"
                            }
                        }, 1, string.Empty);

                    //Buscar tipo de duplicata
                    TList_CadTpDuplicata lDup = TCN_CadTpDuplicata.Buscar(lCmi[0].Tp_duplicata, string.Empty, string.Empty, null);
                    //Abrir tela de lançamento de duplicata
                    using (TFLanDuplicata fDuplicata = new TFLanDuplicata())
                    {
                        if ((!st_complemento) && (!st_devolucao) && (!st_retorno))
                            try
                            {
                                fDuplicata.vNr_pedido = Convert.ToDecimal(NR_Pedido.Text);
                            }
                            catch
                            { fDuplicata.vNr_pedido = null; }
                        fDuplicata.vSt_notafiscal = true;
                        fDuplicata.vCd_empresa = CD_Empresa.Text;
                        fDuplicata.vNm_empresa = NM_Empresa.Text;
                        fDuplicata.vCd_clifor = CD_Clifor.Text;
                        fDuplicata.vNm_clifor = NM_Clifor.Text;
                        fDuplicata.vCd_endereco = CD_Endereco.Text;
                        fDuplicata.vDs_endereco = DS_Endereco.Text;
                        if (lDup.Count > 0)
                        {
                            fDuplicata.vCd_historico = lDup[0].Cd_historico_dup.Trim();
                            fDuplicata.vDs_historico = lDup[0].Ds_historico_dup.Trim();
                        }
                        if (lCmi.Count > 0)
                        {
                            fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata.Trim();
                            fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata.Trim();
                            fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper() == "E" ? "P" :
                                                 lCmi[0].Tp_movimento.Trim().ToUpper() == "S" ? "R" : "";
                            fDuplicata.vTp_docto = tp_docto.Trim().Equals(string.Empty) ? lCmi[0].Tp_doctostring.Trim() : tp_docto.Trim();
                            fDuplicata.vDs_tpdocto = ds_tpdocto.Trim().Equals(string.Empty) ? lCmi[0].ds_tpdocto.Trim() : ds_tpdocto.Trim();
                            //Configuracao para emissao de bloqueto automaticamente
                            if (lDup[0].Id_configboleto.HasValue)
                            {
                                fDuplicata.vId_configBoleto = lDup[0].Id_configboletostr;
                                fDuplicata.vDs_configBoleto = lDup[0].Ds_configboleto;
                            }
                        }
                        if (lCondPgto.Count > 0)
                        {
                            fDuplicata.vCd_condpgto = lCondPgto[0].Cd_condpgto.Trim();
                            fDuplicata.vDs_condpgto = lCondPgto[0].Ds_condpgto.Trim();
                            fDuplicata.vSt_comentrada = lCondPgto[0].St_comentrada.Trim();
                            fDuplicata.vCd_juro = lCondPgto[0].Cd_juro.Trim();
                            fDuplicata.vDs_juro = lCondPgto[0].Ds_juro.Trim();
                            fDuplicata.vTp_juro = lCondPgto[0].Tp_juro.Trim();
                            fDuplicata.vQt_dias_desdobro = lCondPgto[0].Qt_diasdesdobro;
                            fDuplicata.vQt_parcelas = lCondPgto[0].Qt_parcelas;
                            fDuplicata.vPc_jurodiario_atrazo = lCondPgto[0].Pc_jurodiario_atrazo;
                            fDuplicata.vCd_portador = lCondPgto[0].Cd_portador.Trim();
                            fDuplicata.vDs_portador = lCondPgto[0].Ds_portador.Trim();
                            fDuplicata.vSt_solicitardtvencto = lCondPgto[0].St_solicitardtvenctobool;
                        }
                        if (lMoedaPed.Count > 0)
                        {
                            //Moeda do pedido
                            fDuplicata.vCd_moeda = lMoedaPed[0].Cd_moeda;
                            fDuplicata.vDs_moeda = lMoedaPed[0].Ds_moeda_singular;
                            fDuplicata.vSigla_moeda = lMoedaPed[0].Sigla;
                        }
                        //Moeda Padrao
                        fDuplicata.vCd_moeda_padrao = cd_moeda_padrao.Text;
                        fDuplicata.vDs_moeda_padrao = ds_moeda_padrao.Text;
                        fDuplicata.vSigla_moeda_padrao = sigla_moeda_padrao.Text;

                        fDuplicata.vNr_docto = string.IsNullOrEmpty(NR_NotaFiscal.Text) ? "NF" : NR_NotaFiscal.Text;
                        fDuplicata.vDt_emissao = DT_Emissao.Text;
                        if (vl_cotacao.Value > 0)
                            fDuplicata.vVl_documento = operador.Text.Trim().ToUpper().Equals("*") ? TCN_LanFaturamento.CalcTotalFinNota(bsNotaFiscal.Current as TRegistro_LanFaturamento) / vl_cotacao.Value :
                                operador.Text.Trim().ToUpper().Equals("/") ? TCN_LanFaturamento.CalcTotalFinNota(bsNotaFiscal.Current as TRegistro_LanFaturamento) * vl_cotacao.Value : TCN_LanFaturamento.CalcTotalFinNota(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                        else
                            fDuplicata.vVl_documento = TCN_LanFaturamento.CalcTotalFinNota(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                        Financeiro.TInfo.pub = TInfo.pub;
                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata.Clear();
                            if (fDuplicata.dsDuplicata.Count == 1)
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata.Add(fDuplicata.dsDuplicata[0] as TRegistro_LanDuplicata);
                            else
                            {
                                MessageBox.Show("Erro: Tentativa de Gravar nota fiscal com mais de um financeiro!");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar financeiro para gravar nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                //Gravar Nota Fiscal
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_sequenciaauto = st_sequenciaauto;
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_serie = Tp_serie;
                ThreadEspera tEspera = new ThreadEspera("Inicio processo gravar nota fiscal.");
                try
                {
                    TCN_LanFaturamento.GravarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), tEspera, null);
                    MessageBox.Show("Nota Fiscal Gravada com Sucesso.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    //Se for nota propria e NF-e
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P"))
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                        {
                            if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                //Verificar se é nota de produto ou mista
                                object obj = new TCD_CadSerieNF().BuscarEscalar(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_serie",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + NR_Serie.Text.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_modelo",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + cd_modelo.Text.Trim() + "'"
                                                }
                                            }, "a.tp_serie");
                                if (obj != null)
                                    if (obj.ToString().Trim().ToUpper().Equals("P") ||
                                        obj.ToString().Trim().ToUpper().Equals("M"))
                                    {
                                        try
                                        {
                                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                            {
                                                fGerNfe.rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                                           null);
                                                fGerNfe.ShowDialog();
                                            }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                    else if (obj.ToString().Trim().ToUpper().Equals("S"))
                                    {
                                        try
                                        {
                                            TRegistro_LanFaturamento rNfs = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                                                        null);
                                            NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<TRegistro_LanFaturamento>() { rNfs });
                                            MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                            }
                        }
                        else
                        {
                            //Chamar tela de impressao para a nota fiscal
                            //somente se for nota propria
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                                fImp.pMensagem = "NOTA FISCAL Nº" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                {
                                    //Buscar Dt.Processamento
                                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                            vOperador = "=",
                                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, "a.dt_processamento");
                                    if (obj != null)
                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_processamento = DateTime.Parse(obj.ToString());
                                    //Buscar Nr.Protocolo
                                    object nr_proc = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                            vOperador = "=",
                                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, "a.Nr_protocolo");
                                    if (nr_proc != null)
                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_protocolo = nr_proc.ToString();
                                    Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                                        null),
                                                            fImp.pSt_imprimir,
                                                            fImp.pSt_visualizar,
                                                            fImp.pSt_enviaremail,
                                                            fImp.pDestinatarios,
                                                            "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                                            fImp.pDs_mensagem);
                                }
                            }
                        }
                    if (st_atualizaprecovenda &&
                        (!st_complemento) &&
                        (!st_devolucao) &&
                        (!st_compdevimposto) &&
                        (!st_retorno))
                    {
                        if (MessageBox.Show("Atualizar preço de venda dos itens faturados?", "Pergunta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_AtualizaPrecoPerc.AtualizarPreco((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota, null);
                            using (TFPrecoItem fPreco = new TFPrecoItem())
                            {
                                fPreco.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                fPreco.Nm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                                fPreco.lItens = new TList_RegLanFaturamento_Item();
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.FindAll(p => p.St_atualizaprecovenda).ForEach(p => fPreco.lItens.Add(p));
                                fPreco.ShowDialog();
                            }
                        }
                    }
                    if (st_geraretiqueta &&
                        (!st_complemento) &&
                        (!st_devolucao) &&
                        (!st_compdevimposto) &&
                        (!st_retorno))
                        try
                        {
                            using (TFImpEtiqueta fImp = new TFImpEtiqueta())
                            {
                                fImp.pCd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                fImp.pNm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                                {
                                    object obj = new CamadaDados.Estoque.Cadastros.TCD_CodBarra().BuscarEscalar(
                                           new TpBusca[]
                                           {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                                }
                                           }, "a.cd_codbarra");
                                    object obj1 = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                       new TpBusca[]
                                       {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        }
                                       }, "a.codigo_alternativo");
                                    if (p.lGrade.Count.Equals(0))
                                        fImp.lItens.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                                        {
                                            Cd_produto = p.Cd_produto,
                                            Ds_produto = p.Ds_produto,
                                            cd_unidade = p.Cd_unidade,
                                            ds_unidade = p.Ds_unidade,
                                            uni = p.Sigla_unidade,
                                            Referencia = obj1 == null ? string.Empty : obj1.ToString(),
                                            Quantidade = p.Quantidade,
                                            Cd_codbarra = obj == null ? string.Empty : obj.ToString()
                                        });
                                    else
                                    {
                                        p.lGrade.ForEach(x =>
                                            fImp.lItens.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                                            {
                                                Cd_produto = p.Cd_produto,
                                                Ds_produto = p.Ds_produto.Trim() + "/" + x.Valor,
                                                cd_unidade = p.Cd_unidade,
                                                ds_unidade = p.Ds_unidade,
                                                uni = p.Sigla_unidade,
                                                Referencia = obj1 == null ? string.Empty : obj1.ToString(),
                                                Quantidade = x.Vl_mov,
                                                Cd_codbarra = obj == null ? string.Empty : obj.ToString()
                                            }));
                                    }
                                });
                                fImp.ShowDialog();
                            }
                        }
                        catch { }
                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                            "where x.cd_empresa = c.cd_empresa "+
                                            "and x.nr_lanctoduplicata = c.nr_lancto "+
                                            "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' "+
                                            "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")"
                            }
                        }, 0, string.Empty);
                    if (lBloqueto.Count > 0)
                        //Chamar tela de impressao para o bloqueto
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "BLOQUETOS DA NOTA FISCAL Nº" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                    lBloqueto,
                                                                    fImp.pSt_imprimir,
                                                                    fImp.pSt_visualizar,
                                                                    fImp.pSt_enviaremail,
                                                                    fImp.pSt_exportPdf,
                                                                    fImp.Path_exportPdf,
                                                                    fImp.pDestinatarios,
                                                                    "BLOQUETO(S) DO DOCUMENTO Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                                                    fImp.pDs_mensagem,
                                                                    false);
                        }
                    //Imprimir Duplicata
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata.Count > 0)
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata[0].Tp_mov.Trim().ToUpper().Equals("R"))
                        {
                            object obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                            new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_docto",
                                                        vOperador = "=",
                                                        vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata[0].Tp_doctostring
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'S'"
                                                    }
                                                }, "1");
                            if (obj != null)
                            {
                                //Chamar tela de impressao duplicata
                                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                         (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                         null).Trim().ToUpper().Equals("S"))
                                    {
                                        //Buscar dados Empresa
                                        CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                                        //Buscar dados do sacado
                                        TList_CadClifor lSacado =
                                            TCN_CadClifor.Busca_Clifor((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                                          string.Empty,
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
                                                                                                          0,
                                                                                                          null);
                                        //Buscar endereco sacado
                                        if (lSacado.Count > 0)
                                            lSacado[0].lEndereco =
                                                TCN_CadEndereco.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_endereco,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          0,
                                                                                                          null);

                                        Relatorio Rel = new Relatorio();
                                        //Duplicata
                                        BindingSource bs = new BindingSource();
                                        bs.DataSource = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata;
                                        Rel.DTS_Relatorio = bs;
                                        //Verificar se existe logo configurada para a empresa
                                        if (lEmpresa.Count > 0)
                                            if (lEmpresa[0].Img != null)
                                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                        //Empresa
                                        BindingSource bs_emp = new BindingSource();
                                        bs_emp.DataSource = lEmpresa;
                                        Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                        //Parcelas
                                        BindingSource bs_parc = new BindingSource();
                                        //Buscar Parcelas
                                        TList_RegLanParcela lParc =
                                            new TCD_LanParcela().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata[0].Nr_lancto.ToString()
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                                        bs_parc.DataSource = lParc;
                                        Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                        //Sacado
                                        BindingSource bs_sacado = new BindingSource();
                                        bs_sacado.DataSource = lSacado;
                                        Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                        Rel.Nome_Relatorio = "FRel_CarneDup";
                                        Rel.NM_Classe = "TFDuplicata";
                                        Rel.Modulo = "FIN";
                                        Rel.Ident = "FRel_CarneDup";
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();

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
                                                               "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
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
                                                               "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                                               fImp.pDs_mensagem);
                                    }
                                    else
                                    {
                                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                  (bsNotaFiscal.Current as TRegistro_LanFaturamento).Duplicata[0].Parcelas,
                                                                                  null,
                                                                                  null,
                                                                                  fImp.pSt_imprimir,
                                                                                  fImp.pSt_visualizar,
                                                                                  fImp.pSt_exportPdf,
                                                                                  fImp.Path_exportPdf,
                                                                                  fImp.pSt_enviaremail,
                                                                                  fImp.pDestinatarios,
                                                                                  "DUPLICATAS(S) DO DOCUMENTO Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                                                                  fImp.pDs_mensagem);
                                    }
                                }
                            }
                        }
                    //Verificar se o pedido integra OS com NF de remessa
                    ProcessarRetornoOs();

                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_MANIFESTO_AUTO", (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa, null) == "S")
                        ManifestoNFe();

                    if (Nr_pedidoFaturar.Trim() != string.Empty)
                        //faturamento aberto pela tela de pedido
                        DialogResult = DialogResult.OK;
                    else
                    {
                        vTP_Modo = TTpModo.tm_Standby;
                        vTP_ModoItem = TTpModo.tm_Standby;
                        modoBotoes();
                        ModoBotoesItens();
                        pDadosNotas.HabilitarControls(false, vTP_Modo);
                        pBuscaObs.HabilitarControls(false, vTP_Modo);
                        ds_ObservacaoFiscal.Enabled = false;
                        ds_DadosAdicionais.Enabled = false;
                        if (!tcFaturamento.TabPages.Contains(tpNavegador))
                        {
                            tcFaturamento.TabPages.Remove(tabLancamento);
                            tcFaturamento.TabPages.Remove(tabItens);
                            tcFaturamento.TabPages.Add(tpNavegador);
                            tcFaturamento.TabPages.Add(tabLancamento);
                            tcFaturamento.TabPages.Add(tabItens);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                }
            }
        }

        private void afterCancela()
        {
            if (Nr_pedidoFaturar.Trim() != string.Empty)
                //Faturamento aberto pela tela de pedido
                DialogResult = DialogResult.Cancel;
            else
            {
                vTP_Modo = TTpModo.tm_Standby;
                vTP_ModoItem = TTpModo.tm_Standby;
                modoBotoes();
                ModoBotoesItens();
                pDadosNotas.LimparRegistro();
                pDadosNotas.HabilitarControls(false, vTP_Modo);
                pBuscaObs.HabilitarControls(false, vTP_Modo);
                ds_ObservacaoFiscal.Enabled = false;
                ds_DadosAdicionais.Enabled = false;
                pDadosFretes.LimparRegistro();
                pDadosFretes.HabilitarControls(false, vTP_Modo);
                pItensNota.HabilitarControls(false, vTP_Modo);
                pEntrega.LimparRegistro();
                pEntrega.HabilitarControls(false, vTP_Modo);
                pEx.LimparRegistro();
                pEx.HabilitarControls(false, vTP_Modo);
                bsNotaFiscal.CancelEdit();
                bsItensNota.CancelEdit();

                vTP_ModoItem = TTpModo.tm_Standby;
                ListaNF = null;
                st_equiparado_pj = false;
                st_equiparado_pf = false;
                st_permite_pedidoparcial = false;
                st_confere_saldo = false;
                st_valoresfixos = false;
                st_exigirconferenciaentrega = false;
                st_devolucao = false;
                st_retorno = false;
                st_complemento = false;
                st_compdevimposto = false;
                st_mestra = false;
                st_simplesRemessa = false;
                st_controleTitulo = false;
                st_atualizaprecovenda = false;
                st_geraretiqueta = false;
                tp_pessoa = string.Empty;
                cd_unidProduto = string.Empty;
                tQtdPedido = decimal.Zero;
                tVlPedido = decimal.Zero;
                tQtdEstPedido = decimal.Zero;
                tVlEstPedido = decimal.Zero;
                st_sequenciaauto = false;
                if (!tcFaturamento.TabPages.Contains(tpNavegador))
                {
                    tcFaturamento.TabPages.Remove(tabLancamento);
                    tcFaturamento.TabPages.Remove(tabItens);
                    tcFaturamento.TabPages.Add(tpNavegador);
                    tcFaturamento.TabPages.Add(tabLancamento);
                    tcFaturamento.TabPages.Add(tabItens);
                }
            }
        }

        private void afterBusca()
        {
            string tp_nota = string.Empty;
            string virg = string.Empty;
            if (st_propria.Checked)
            {
                tp_nota = "'P'";
                virg = ",";
            }
            if (ST_Terceiro.Checked)
                tp_nota += virg + "'T'";
            bsNotaFiscal.DataSource = TCN_LanFaturamento.Busca(cd_empresa_busca.Text,
                                                               nr_notafiscal_busca.Text,
                                                               nr_serie_busca.Text,
                                                               nr_lanctofiscal_busca.Text,
                                                               string.Empty,
                                                               string.Empty,
                                                               nr_pedido_busca.Text.Trim() != string.Empty ? Convert.ToDecimal(nr_pedido_busca.Text) : 0,
                                                               cd_clifor_busca.Text,
                                                               cd_endereco_busca.Text,
                                                               string.Empty,
                                                               cd_movto_busca.Text,
                                                               cd_cfop_busca.Text,
                                                               cd_cmi_busca.Text,
                                                               cd_produto_busca.Text,
                                                               cbEntrada.Checked ? "E" : cbSaida.Checked ? "S" : string.Empty,
                                                               st_nfe_busca.Checked,
                                                               string.Empty,
                                                               string.Empty,
                                                               st_transmitido_nfe.Checked ? "S" : st_nfenao_transmitida.Checked ? "N" : string.Empty,
                                                               st_canctransmitido.Checked ? "S" : st_cancnaotransmitido.Checked ? "N" : string.Empty,
                                                               status.SelectedIndex.Equals(0) ? "A" : status.SelectedIndex.Equals(1) ? "C" : status.SelectedIndex.Equals(2) ? "D" : string.Empty,
                                                               rbEmissao.Checked ? "E" : rbsaient.Checked ? "S" : string.Empty,
                                                               DT_Inicial.Text,
                                                               DT_Final.Text,
                                                               VL_Inicial.Value,
                                                               VL_Final.Value,
                                                               string.Empty,
                                                               tp_nota,
                                                               string.Empty,
                                                               false,
                                                               id_ecf_vinculado.Text,
                                                               vr_origem.Text,
                                                               Os_origem.Text,
                                                               Convert.ToInt16(qtd_notas.Value),
                                                               string.Empty, null);
            bsNotaFiscal_PositionChanged(this, new EventArgs());
            vTP_Modo = TTpModo.tm_busca;
            vTP_ModoItem = TTpModo.tm_Standby;
            modoBotoes();
            ModoBotoesItens();
            vl_totalnfgeral.Value = (bsNotaFiscal.DataSource as TList_RegLanFaturamento).Sum(p => p.Vl_totalnota);
        }

        private void afterExclui()
        {
            if (bsNotaFiscal.Current != null)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido CANCELAR NFe DENEGADA pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                {
                    ExcluirNotaFiscalCancelada();
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento Nota Fiscal?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Verificar se a nota nao esta amarrada a nenhuma fixacao
                    if (new CamadaDados.Graos.TCD_Fixacao_NF().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(fx.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                }, "1") != null)
                    {
                        MessageBox.Show("Nota Fiscal possui amarração com a fixação de contratos\r\nEsta nota somente poderá ser cancelada pela tela de fixação.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55")) &&
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P") &&
                        (!string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_protocolo)))
                    {
                        try
                        {
                            object obj = new TCD_CadSerieNF().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_serie",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_modelo",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim() + "'"
                                                }
                                            }, "a.tp_serie");
                            //Se for nfe de produto
                            if (obj == null ? true : obj.ToString().Trim().ToUpper().Equals("P") || obj.ToString().Trim().ToUpper().Equals("M"))
                            {
                                //Verificar se NFe nao foi denegada pela receita
                                if (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "110"
                                        }
                                    }, "1") != null)
                                {
                                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro = "D";
                                    TCN_LanFaturamento.CancelarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), null);
                                    MessageBox.Show("NFe DENEGADA com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                    vTP_Modo = TTpModo.tm_Standby;
                                    vTP_ModoItem = TTpModo.tm_Standby;
                                    modoBotoes();
                                    ModoBotoesItens();
                                }
                                else
                                {
                                    //Verificar se NFe ja nao foi cancelada junto a receita
                                    CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           "CA",
                                                                                           string.Empty,
                                                                                           null);
                                    if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                    {
                                        //Cancelar somente NFe no Aliance.NET
                                        TCN_LanFaturamento.CancelarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), null);
                                        MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                        vTP_Modo = TTpModo.tm_Standby;
                                        vTP_ModoItem = TTpModo.tm_Standby;
                                        modoBotoes();
                                        ModoBotoesItens();
                                    }
                                    else
                                    {
                                        if (lEvento.Count.Equals(0))
                                        {
                                            InputBox ibp = new InputBox();
                                            ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                            string motivo = ibp.ShowDialog();
                                            if (string.IsNullOrEmpty(motivo))
                                            {
                                                MessageBox.Show("Obrigatorio informar motivo de cancelamento da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            if (motivo.Trim().Length < 15)
                                            {
                                                MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            //Buscar evento Carta Correcao
                                            TList_Evento lEv = TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                            if (lEv.Count.Equals(0))
                                            {
                                                MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            //Cancelar NFe Receita
                                            CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                            rEvento.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                            rEvento.Nr_lanctofiscal = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal;
                                            rEvento.Chave_acesso_nfe = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Chave_acesso_nfe;
                                            rEvento.Nr_protocoloNfe = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_protocolo;
                                            rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                            rEvento.Ds_evento = motivo;
                                            rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                            rEvento.Descricao_evento = lEv[0].Ds_evento;
                                            rEvento.Tp_evento = lEv[0].Tp_evento;
                                            rEvento.St_registro = "A";
                                            CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                                            if (MessageBox.Show("Evento de CANCELAMENTO gravado com sucesso.\r\n" +
                                                                "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                                            {
                                                //Buscar CfgNfe para a empresa
                                                TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          null);
                                                if (lCfg.Count.Equals(0))
                                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                else
                                                {
                                                    string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rEvento, lCfg[0]);
                                                    if (!string.IsNullOrEmpty(msg))
                                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                                        "Erro: " + msg.Trim() + "\r\n" +
                                                                        "Obs.: A NFe não será cancelada no sistema Aliance.NET enquanto a mesma não for cancelada junto a receita.",
                                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    else
                                                    {
                                                        MessageBox.Show("Evento registrado e vinculado a NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        TCN_LanFaturamento.CancelarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), null);
                                                        MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        afterBusca();
                                                        vTP_Modo = TTpModo.tm_Standby;
                                                        vTP_ModoItem = TTpModo.tm_Standby;
                                                        modoBotoes();
                                                        ModoBotoesItens();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //Buscar CfgNfe para a empresa
                                            TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                                            if (lCfg.Count.Equals(0))
                                                MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                            {
                                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], lCfg[0]);
                                                if (!string.IsNullOrEmpty(msg))
                                                    MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                                    "Aguarde um tempo e tente novamente.\r\n" +
                                                                    "Erro: " + msg.Trim() + "\r\n" +
                                                                    "Obs.: A NFe não será cancelada no sistema Aliance.NET enquanto a mesma não for cancelada junto a receita.",
                                                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                else
                                                {
                                                    MessageBox.Show("Evento registrado e vinculado a NF-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    TCN_LanFaturamento.CancelarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), null);
                                                    MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    afterBusca();
                                                    vTP_Modo = TTpModo.tm_Standby;
                                                    vTP_ModoItem = TTpModo.tm_Standby;
                                                    modoBotoes();
                                                    ModoBotoesItens();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else//NFSe 
                                try
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                    string motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da nota fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (motivo.Trim().Length < 15)
                                    {
                                        MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    //Buscar CfgNfe para a empresa
                                    TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        NFES.TCancelarNfes.CancelarNFSe(new TList_RegLanFaturamento() { bsNotaFiscal.Current as TRegistro_LanFaturamento }, motivo, lCfg[0]);
                                        TCN_LanFaturamento.CancelarFaturamento(bsNotaFiscal.Current as TRegistro_LanFaturamento, null);
                                    }
                                    MessageBox.Show("NFS-e cancelada(s) com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                    vTP_Modo = TTpModo.tm_Standby;
                                    vTP_ModoItem = TTpModo.tm_Standby;
                                    modoBotoes();
                                    ModoBotoesItens();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(),
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        try
                        {
                            TCN_LanFaturamento.CancelarFaturamento((bsNotaFiscal.Current as TRegistro_LanFaturamento), null);
                            MessageBox.Show("Nota Fiscal Cancelada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P"))
                                if (!(bsNotaFiscal.Current as TRegistro_LanFaturamento).St_transmitidoNFe)
                                {
                                    TList_CadSequenciaNF lSeq = TCN_CadSequenciaNF.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                         (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                         (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                     null);
                                    if (lSeq.Count > 0)
                                        if (lSeq[0].Seq_NotaFiscal.Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal))
                                        {
                                            lSeq[0].Seq_NotaFiscal--;
                                            TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                            MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_serie.Trim().ToUpper() != "S")//Não for nota de servico
                                        {
                                            //Buscar configuracao nfe
                                            TList_CfgNfe lCfgNfe = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                                            if (lCfgNfe.Count > 0)
                                            {
                                                try
                                                {
                                                    //Inutilizar numero nota
                                                    srvNFE.InutilizarNFE.InutilizarNFE2.InutilizarNfe2(lCfgNfe[0].Cd_uf_empresa,
                                                                                                       lCfgNfe[0].Cnpj_empresa,
                                                                                                       (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                                       (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                                       DateTime.Now.Year.ToString(),
                                                                                                       (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                                       (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                                       "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFE",
                                                                                                       lCfgNfe[0]);
                                                    MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch
                                                { MessageBox.Show("Erro ao INUTILIZAR numero junto a receita.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                        }
                                }
                            afterBusca();
                            vTP_Modo = TTpModo.tm_Standby;
                            vTP_ModoItem = TTpModo.tm_Standby;
                            modoBotoes();
                            ModoBotoesItens();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void afterPrint()
        {
            if (bsNotaFiscal.Current != null)
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "DANFE",
                                               fImp.pDs_mensagem);
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }

        private void ExcluirNotaFiscalCancelada()
        {
            if (bsNotaFiscal.Current != null)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper() != "C")
                {
                    MessageBox.Show("Permitido excluir somente nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se o usuario tem permissao para cancelar nota fiscal
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR EXCLUIR NOTA FISCAL CANCELADA", null))
                {
                    MessageBox.Show("Usuario não tem permissão para excluir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão da nota fiscal selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanFaturamento.ExcluirNotaFiscal(bsNotaFiscal.Current as TRegistro_LanFaturamento, null);
                        MessageBox.Show("Nota Fiscal excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P") &&
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_sequenciaauto)
                        {
                            TList_CadSequenciaNF lSeq = TCN_CadSequenciaNF.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                 (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                 (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                 null);
                            if (lSeq.Count > 0)
                                if (lSeq[0].Seq_NotaFiscal.Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal))
                                {
                                    lSeq[0].Seq_NotaFiscal--;
                                    TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                    MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                                {
                                    //Buscar configuracao nfe
                                    TList_CfgNfe lCfgNfe = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfgNfe.Count > 0)
                                    {
                                        try
                                        {
                                            //Inutilizar numero nota
                                            srvNFE.InutilizarNFE.InutilizarNFE2.InutilizarNfe2(lCfgNfe[0].Cd_uf_empresa,
                                                                                               lCfgNfe[0].Cnpj_empresa,
                                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                               DateTime.Now.Year.ToString(),
                                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                               "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFE",
                                                                                               lCfgNfe[0]);
                                            MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch
                                        { MessageBox.Show("Erro ao INUTILIZAR numero junto a receita.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                        }
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void afterIncluiItensNF()
        {
            if ((vTP_ModoItem == TTpModo.tm_Standby) && (vTP_Modo == TTpModo.tm_Insert))
            {
                if (st_permite_pedidoparcial || st_devolucao || st_retorno || st_complemento || st_compdevimposto || st_simplesRemessa)
                    if (st_confere_saldo && (!st_compdevimposto))
                    {
                        if (st_complemento)
                        {
                            if ((tQtdEstPedido < tQtdPedido) || (tVlEstPedido < tVlPedido))
                            {
                                pItensNota.HabilitarControls(true, TTpModo.tm_Standby);
                                Vl_Unitario.Enabled = (!st_valoresfixos);
                                Vl_SubTotal.Enabled = (tVlEstPedido < tVlPedido);
                                bsItensNota.AddNew();
                                CD_Produto.Focus();
                                vTP_ModoItem = TTpModo.tm_Insert;
                                ModoBotoesItens();
                                HabilitarCamposImpostos(true, TTpModo.tm_Insert);
                            }
                        }
                        else if (st_devolucao || st_retorno)
                        {
                            pItensNota.HabilitarControls(true, TTpModo.tm_Standby);
                            Vl_Unitario.Enabled = (!st_valoresfixos);
                            Vl_SubTotal.Enabled = (tVlEstPedido < tVlPedido);
                            bsItensNota.AddNew();
                            CD_Produto.Focus();
                            vTP_ModoItem = TTpModo.tm_Insert;
                            ModoBotoesItens();
                            HabilitarCamposImpostos(true, TTpModo.tm_Insert);
                        }
                        else if ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido))
                        {
                            pItensNota.HabilitarControls(true, TTpModo.tm_Standby);
                            bsItensNota.AddNew();
                            CD_Produto.Focus();
                            vTP_ModoItem = TTpModo.tm_Insert;
                            ModoBotoesItens();
                            HabilitarCamposImpostos(true, TTpModo.tm_Insert);
                        }
                    }
                    else
                    {
                        pItensNota.HabilitarControls(true, TTpModo.tm_Standby);
                        Vl_Unitario.Enabled = (!st_valoresfixos) || st_compdevimposto;
                        bsItensNota.AddNew();
                        CD_Produto.Focus();
                        vTP_ModoItem = TTpModo.tm_Insert;
                        ModoBotoesItens();
                        id_pedidoitem.Enabled = true;
                        id_pedidoitem.Focus();
                        HabilitarCamposImpostos(true, TTpModo.tm_Insert);
                    }
            }
        }

        private void afterAlteraItensNF()
        {
            if ((vTP_ModoItem == TTpModo.tm_Standby) && (vTP_Modo == TTpModo.tm_Insert))
            {
                if (bsItensNota.Current != null)
                {
                    vTP_ModoItem = TTpModo.tm_Edit;
                    ModoBotoesItens();
                    HabilitarCamposImpostos(true, TTpModo.tm_Edit);
                    if (st_permite_pedidoparcial)
                    {
                        pItensNota.HabilitarControls(true, TTpModo.tm_Standby);
                        id_pedidoitem.Enabled = false;
                        bb_produto.Enabled = false;
                        if (st_confere_saldo)
                        {
                            if (st_devolucao || st_retorno || st_complemento)
                            {
                                Quantidade.Enabled = (tQtdEstPedido < tQtdPedido);
                                Vl_Unitario.Enabled = (!st_valoresfixos);
                                Vl_SubTotal.Enabled = (tVlEstPedido < tVlPedido);
                            }
                            else
                            {
                                Quantidade.Enabled = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                                Vl_Unitario.Enabled = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                                Vl_SubTotal.Enabled = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                            }
                        }
                        else
                            Vl_Unitario.Enabled = !(st_valoresfixos);
                    }
                }
            }
        }

        private void afterExcluiItensNF()
        {
            if ((vTP_Modo == TTpModo.tm_Insert))
            {
                if (bsItensNota.Current != null)
                {
                    if (MessageBox.Show("Confirma exclusão do item da nota fiscal?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        bsItensNota.RemoveCurrent();
                        //bsImpostosItens.Clear();
                        pItensNota.HabilitarControls(false, TTpModo.tm_Standby);
                        vTP_ModoItem = TTpModo.tm_Standby;
                        ModoBotoesItens();
                        //Totalizar Nota
                        TotalizarNota();
                    }
                }
            }
        }

        private void afterGravaItensNF()
        {
            if (((vTP_ModoItem == TTpModo.tm_Edit) || (vTP_ModoItem == TTpModo.tm_Insert)) && (vTP_Modo == TTpModo.tm_Insert))
            {
                if (st_complemento || st_devolucao || st_retorno || st_compdevimposto)
                {
                    QuantidadeItem.ST_NotNull = false;
                    Vl_Unitario.ST_NotNull = false;
                    Vl_SubTotal.ST_NotNull = false;
                }
                else
                {
                    QuantidadeItem.ST_NotNull = true;
                    Vl_Unitario.ST_NotNull = true;
                    Vl_SubTotal.ST_NotNull = true;
                }
                if (pItensNota.validarCampoObrigatorio())
                {
                    if (st_complemento || st_devolucao || st_retorno || st_simplesRemessa)
                    {
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = CD_Empresa.Text;
                            fCompDevol.Nr_pedido = (string.IsNullOrEmpty(Nr_PedidoItem.Text.Trim()) ? NR_Pedido.Text : Nr_PedidoItem.Text);
                            fCompDevol.Cd_produto = CD_Produto.Text;
                            fCompDevol.Cd_clifor = CD_Clifor.Text;
                            if (st_complemento)
                            {
                                fCompDevol.Tp_operacao = "C";
                                fCompDevol.Tp_movimento = tp_movimento.SelectedValue.ToString();
                            }
                            else if (st_devolucao || st_retorno)
                            {
                                fCompDevol.Tp_operacao = "D";
                                if (tp_movimento.SelectedValue.ToString().Trim().Equals("E"))
                                    fCompDevol.Tp_movimento = "S";
                                else if (tp_movimento.SelectedValue.ToString().Trim().Equals("S"))
                                    fCompDevol.Tp_movimento = "E";
                            }
                            else if (st_simplesRemessa)
                            {
                                fCompDevol.Tp_operacao = "E";
                                fCompDevol.Tp_movimento = tp_movimento.SelectedValue.ToString();
                            }
                            fCompDevol.Quantidade = QuantidadeItem.Value;
                            fCompDevol.Valor = Vl_SubTotal.Value - vl_descontoitem.Value + freteitem.Value + vl_juro_fin.Value + vl_outrasdespitem.Value + vl_seguroItem.Value;
                            if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev != null)
                                fCompDevol.ListaCompDev = (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev;
                            if (fCompDevol.ShowDialog() == DialogResult.OK)
                            {
                                QuantidadeItem.Value = fCompDevol.Tot_quantidade;
                                Vl_SubTotal.Value = fCompDevol.Tot_valor + vl_descontoitem.Value - freteitem.Value - vl_juro_fin.Value - vl_outrasdespitem.Value - vl_seguroItem.Value;
                                if (fCompDevol.Tot_quantidade > 0)
                                    Vl_Unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade.Text, cd_unidProduto,
                                        (fCompDevol.Tot_valor + vl_descontoitem.Value - freteitem.Value - vl_juro_fin.Value - vl_outrasdespitem.Value - vl_seguroItem.Value) / fCompDevol.Tot_quantidade, 5, null);
                                else
                                    Vl_Unitario.Value = 0;
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev = fCompDevol.ListaCompDev;

                                CamadaDados.Producao.Producao.TList_SerieProduto lSerie = new CamadaDados.Producao.Producao.TList_SerieProduto();
                                for (int i = 0; i < (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev.Count; i++)
                                {
                                    //Verificar se Item possui Nº Série a ser devolvido
                                    new CamadaDados.Producao.Producao.TCD_SerieProduto().Select(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                                                "inner join TB_FAT_Expedicao y " +
                                                                "on x.CD_Empresa = y.CD_Empresa " +
                                                                "and x.ID_Expedicao = y.ID_Expedicao " +
                                                                "inner join TB_FAT_ItensExpedicao z " +
                                                                "on y.CD_Empresa = z.CD_Empresa " +
                                                                "and y.ID_Expedicao = z.ID_Expedicao " +
                                                                "and z.ID_Serie = a.ID_Serie " +
                                                                "where x.cd_empresa = '" + (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev[i].Cd_empresa.Trim() + "' " +
                                                                "and x.nr_lanctofiscal = " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev[i].Nr_lanctofiscal_origem + ")"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" +(bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto.Trim() + "'"
                                                }
                                        }, 0, string.Empty).ForEach(p => lSerie.Add(p));
                                }

                                if (lSerie.Count > 0)
                                    if (lSerie.Count.Equals(1))
                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev[0].lSerie.Add(
                                                                    new CamadaDados.Producao.Producao.TRegistro_SerieDevolvida()
                                                                    {
                                                                        Id_serie = lSerie[0].Id_serie
                                                                    });
                                    else
                                    {
                                        using (TFDevolverSerieProduto fSerie = new TFDevolverSerieProduto())
                                        {
                                            for (int i = 0; lSerie.Count > i; i++)
                                                fSerie.lSerie.Add(new CamadaDados.Producao.Producao.TRegistro_SerieProduto()
                                                {
                                                    Cd_empresa = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_empresa,
                                                    Cd_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                    Ds_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_produto,
                                                    Nr_serie = lSerie[i].Nr_serie,
                                                    Id_serie = lSerie[i].Id_serie
                                                });
                                            fSerie.pQuantidade = QuantidadeItem.Value;
                                            if (fSerie.ShowDialog() == DialogResult.OK)
                                            {
                                                if (fSerie.lSerie != null)
                                                    if (fSerie.lSerie.Count > 0)
                                                        fSerie.lSerie.FindAll(p => p.St_processar).ForEach(p =>
                                                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).lNfcompdev[0].lSerie.Add(
                                                               new CamadaDados.Producao.Producao.TRegistro_SerieDevolvida()
                                                               {
                                                                   Id_serie = p.Id_serie
                                                               }));
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatório informar Nº Série!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar notas a serem " + (st_complemento ? "complementadas " : st_devolucao ? "devolvidas " : st_retorno ? "retornadas " : "venda futura ") + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Observação do Item com os dados das notas de origem
                            StringBuilder obs = new StringBuilder();
                            for (int i = 0; i < fCompDevol.ListaCompDev.Count; i++)
                                obs.Append((fCompDevol.ListaCompDev[i].Nr_notafiscal_origem.ToString() + "/" + fCompDevol.ListaCompDev[i].Nr_serie_origem).FormatStringDireita(21, ' ') +
                                            (fCompDevol.ListaCompDev[i].Qtd_lancto.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                            sigla_unidade_estoque.Text.Trim()).FormatStringDireita(15, ' ') +
                                            fCompDevol.ListaCompDev[i].Vl_lancto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n");

                            if (!string.IsNullOrEmpty(Observacao_Item.Text))
                            {
                                string auxObservacao = string.Empty;
                                for (int i = 0; i < Observacao_Item.Lines.Length; i++)
                                {
                                    if (Observacao_Item.Lines[i].Trim().Length < 3 ? true : Observacao_Item.Lines[i].Substring(0, 3).ToUpper() != "NF/")
                                        auxObservacao += Observacao_Item.Lines[i] + "\r\n";
                                }
                                Observacao_Item.Clear();
                                Observacao_Item.Text = auxObservacao + "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obs.ToString();
                            }
                            else
                                Observacao_Item.Text = "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obs.ToString();
                        }
                    }
                    //Verificar se o item e semente
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoSemente((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto))
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E") &&
                            (!st_devolucao) && (!st_retorno))
                        {
                            //Lote de Terceiro
                            if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade > decimal.Zero)
                            {
                                using (TFLotesSementes fLote = new TFLotesSementes())
                                {
                                    fLote.pCd_empresa = CD_Empresa.Text;
                                    fLote.pNm_empresa = NM_Empresa.Text;
                                    fLote.pCd_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto;
                                    fLote.pDs_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_produto;
                                    fLote.pQtd_movimentar = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade;
                                    fLote.pTp_mov = "E";
                                    if (fLote.ShowDialog() == DialogResult.OK)
                                        if (fLote.lMov != null)
                                        {
                                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente.Clear();
                                            fLote.lMov.ForEach(p => (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente.Add(p));
                                        }
                                }
                            }
                        }
                        else if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade > decimal.Zero)
                            using (Sementes.TFSaldoLoteSemente fSaldoLoteSemente = new Sementes.TFSaldoLoteSemente())
                            {
                                fSaldoLoteSemente.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                fSaldoLoteSemente.Nm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                                fSaldoLoteSemente.Cd_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto;
                                fSaldoLoteSemente.Ds_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_produto;
                                fSaldoLoteSemente.Tp_mov = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento;
                                fSaldoLoteSemente.Qtd_nota = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade;
                                fSaldoLoteSemente.St_devolucao = st_devolucao;
                                if (fSaldoLoteSemente.ShowDialog() == DialogResult.OK)
                                {
                                    if (fSaldoLoteSemente.lLoteNf != null)
                                    {
                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente = fSaldoLoteSemente.lLoteNf;
                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteNfOrigem = fSaldoLoteSemente.lLoteNfOrigem;
                                        fSaldoLoteSemente.lLoteNf.ForEach(p => (bsItensNota.Current as TRegistro_LanFaturamento_Item).Observacao_item += p.Ds_obsNfItem + "\r\n");
                                        bsItensNota.ResetCurrentItem();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                    //testar cfop de importação
                    if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_cfop.StartsWith("3"))
                        using (TFDeclaracaoImport tdi = new TFDeclaracaoImport())
                        {
                            if (tdi.ShowDialog() == DialogResult.OK)
                                if (tdi.rDi != null)
                                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).ldi.Add(tdi.rDi);
                        }

                    pItensNota.HabilitarControls(false, TTpModo.tm_Standby);
                    vTP_ModoItem = TTpModo.tm_Standby;
                    ModoBotoesItens();
                    HabilitarCamposImpostos(false, TTpModo.tm_Standby);
                    //Totalizar Nota
                    TotalizarNota();
                }
            }
        }

        private void habilitaCampoNumeroNota(bool vSt_sequenciaAuto)
        {
            if (tp_nota.SelectedValue != null)
            {
                if (vTP_Modo == TTpModo.tm_Insert)
                {
                    if (tp_nota.SelectedValue.ToString().Trim().ToUpper().Equals("T"))
                    {
                        NR_NotaFiscal.Enabled = true;
                        NR_NotaFiscal.Clear();
                    }
                    else if (tp_nota.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                    {
                        NR_NotaFiscal.Clear();
                        NR_NotaFiscal.Enabled = !vSt_sequenciaAuto;
                    }
                }
            }
        }

        private void calcSubTotal()
        {
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                decimal saldoQuantidade = decimal.Zero;
                decimal saldoValor = decimal.Zero;
                if (st_confere_saldo)
                {
                    if (st_simplesRemessa)
                        TCN_LanPedido_Item.BuscaSaldoSimplesRemessa(Nr_PedidoItem.Text, CD_Produto.Text, id_pedidoitem.Text, Tp_serie, ref saldoQuantidade, ref saldoValor, 1, string.Empty, null);
                    else if (st_devolucao || st_retorno)
                        TCN_LanPedido_Item.BuscaSaldoDevolucao(Nr_PedidoItem.Text, CD_Produto.Text, id_pedidoitem.Text, Tp_serie, ref saldoQuantidade, ref saldoValor, 1, string.Empty, null);
                    else if (st_mestra)
                        TCN_LanPedido_Item.BuscaSaldoMestra(Nr_PedidoItem.Text, CD_Produto.Text, Tp_serie, ref saldoQuantidade, ref saldoValor, 1, string.Empty, null);
                    else if (st_complemento)
                        TCN_LanPedido_Item.BuscaSaldoNFComplemento(Nr_PedidoItem.Text, CD_Produto.Text, id_pedidoitem.Text, Tp_serie, ref saldoQuantidade, ref saldoValor, 1, string.Empty, null);
                    else
                        TCN_LanPedido_Item.BuscaSaldoNFNormal(Nr_PedidoItem.Text, CD_Produto.Text, id_pedidoitem.Text, Tp_serie, ref saldoQuantidade, ref saldoValor, 1, string.Empty, null);
                    if (QuantidadeItem.Focused)
                    {
                        if (QuantidadeItem.Value > saldoQuantidade)
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(CD_Produto.Text))
                            {
                                if (MessageBox.Show("Quantidade não pode ser maior que saldo disponivel.\r\n" +
                                                "Produto: " + CD_Produto.Text + " - " + ds_produto.Text + "\r\n" +
                                                "Saldo Disponivel: " + Convert.ToString(saldoQuantidade) + "\r\n\r\n" +
                                                "Deseja Faturar Saldo Disponivel?",
                                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                {
                                    QuantidadeItem.Value = saldoQuantidade;
                                    freteitem.Value = TCN_LanPedido_Item.RatearFreteItemNF(Nr_PedidoItem.Text,
                                                                                           CD_Produto.Text,
                                                                                           id_pedidoitem.Text,
                                                                                           QuantidadeItem.Value,
                                                                                           null);
                                }
                                else
                                {
                                    QuantidadeItem.Value = decimal.Zero;
                                    QuantidadeItem.Focus();
                                }
                            }
                        }
                    }
                    else if (Vl_SubTotal.Focused)
                    {
                        if (Vl_SubTotal.Value > saldoValor)
                        {
                            MessageBox.Show("Valor não pode ser maior que saldo disponivel.\r\n" +
                                            "Produto: " + CD_Produto.Text + " - " + ds_produto.Text + "\r\n" +
                                            "Saldo Disponivel: " + Convert.ToString(saldoValor),
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Vl_SubTotal.Value = saldoValor;
                            Vl_SubTotal.Focus();
                        }

                    }
                }
                else
                {
                    if (!st_complemento)
                        freteitem.Value = TCN_LanPedido_Item.RatearFreteItemNF(Nr_PedidoItem.Text,
                                                                               CD_Produto.Text,
                                                                               id_pedidoitem.Text,
                                                                               QuantidadeItem.Value,
                                                                               null);

                    //TODO 8498 - Colocado pois estava havendo divergencia no calculo do subtotal
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal =
                        Math.Round((bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade * (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_unitario, 2);
                    bsItensNota.ResetCurrentItem();

                }
                if (tp_movimento.SelectedValue.ToString().Trim().Equals("S"))
                {
                    //Verificar se o cmi movimenta estoque
                    if (st_gerarEstoque)
                    {
                        decimal saldo = decimal.Zero;
                        if (TCN_LanEstoque.SaldoEstoqueLocal(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text, ref saldo, null))
                            if (QuantidadeItem.Value > saldo)
                                if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(CD_Produto.Text))
                                {
                                    if (MessageBox.Show("Quantidade de saida maior que saldo disponivel em estoque.\r\r" +
                                                    "Empresa...: " + CD_Empresa.Text + " - " + NM_Empresa.Text + "\r\n" +
                                                    "Produto...: " + CD_Produto.Text + " - " + ds_produto.Text + "\r\n" +
                                                    "Local Arm.: " + CD_Local.Text + " - " + ds_local.Text + "\r\n" +
                                                    "Saldo Disponivel: " + saldo.ToString() + "\r\n\r\n" +
                                                    "Deseja Faturar Saldo Disponivel?", "Pergunta", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        QuantidadeItem.Value = saldo;
                                        freteitem.Value = TCN_LanPedido_Item.RatearFreteItemNF(Nr_PedidoItem.Text,
                                                                                               CD_Produto.Text,
                                                                                               id_pedidoitem.Text,
                                                                                               QuantidadeItem.Value,
                                                                                               null);
                                    }
                                    else
                                    {
                                        QuantidadeItem.Value = decimal.Zero;
                                        QuantidadeItem.Focus();
                                    }
                                }
                    }
                }
            }
            if ((bsItensNota.Current != null) &&
                (vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (vTP_ModoItem.Equals(TTpModo.tm_Insert) || vTP_ModoItem.Equals(TTpModo.tm_Edit)))
            {
                //Buscar impostos estaduais
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                          tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                          tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                          CD_Movto.Text,
                                                                                          tp_movimento.SelectedValue.ToString(),
                                                                                          cd_condFiscal_clifor.Text,
                                                                                          cd_condfiscal_produto.Text,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                          ref vObsFiscal,
                                                                                          DT_Emissao.Data,
                                                                                          CD_Produto.Text,
                                                                                          tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                          NR_Serie.Text,
                                                                                          null);
                if (lImpostos.Exists(v => v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpostos.Find(v => v.Imposto.St_ICMS), bsItensNota.Current as TRegistro_LanFaturamento_Item);
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }

                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                          cd_condfiscal_produto.Text,
                                                                          CD_Movto.Text,
                                                                          tp_movimento.SelectedValue.ToString(),
                                                                          tp_pessoa,
                                                                          CD_Empresa.Text,
                                                                          NR_Serie.Text,
                                                                          CD_Clifor.Text,
                                                                          cd_unidProduto,
                                                                          DT_Emissao.Data,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                          tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                          cd_municipioexecservico.Text,
                                                                          null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());
                //Totalizar Nota
                TotalizarNota();
            }
            bsItensNota.ResetCurrentItem();
        }

        private void BuscarCotacao()
        {
            if ((!string.IsNullOrEmpty(DT_Emissao.Text.SoNumero())) && (cd_moeda_padrao.Text.Trim() != "") && (cd_moeda_pedido.Text.Trim() != ""))
            {
                DataTable tb_cotacao = new TCD_CotacaoMoeda().Buscar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_moeda",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_moeda_pedido.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_moedaresult",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_moeda_padrao.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.data",
                            vOperador = "<=",
                            vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Emissao.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                        }
                    }, 1, string.Empty, string.Empty, "a.data desc", null);
                if (tb_cotacao != null)
                    if (tb_cotacao.Rows.Count > 0)
                    {
                        dt_cotacao.Text = Convert.ToDateTime(tb_cotacao.Rows[0]["Data"].ToString()).ToString("dd/MM/yyyy");
                        vl_cotacao.Value = Convert.ToDecimal(tb_cotacao.Rows[0]["Valor"].ToString());
                        operador.Text = tb_cotacao.Rows[0]["OP"].ToString();
                    }
                    else
                    {
                        dt_cotacao.Text = string.Empty;
                        vl_cotacao.Value = 0;
                        operador.Text = string.Empty;
                    }
                else
                {
                    dt_cotacao.Text = string.Empty;
                    vl_cotacao.Value = 0;
                    operador.Text = string.Empty;
                }
            }
        }

        private void BuscarCfgFiscalPedido()
        {
            if (string.IsNullOrEmpty(vTp_NFFiscal))
                vTp_NFFiscal = "'NO'";
            TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                        "where x.cfg_pedido = a.cfg_pedido "+
                                        "and x.nr_pedido = " + NR_Pedido.Text + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "in",
                            vVL_Busca = "(" + vTp_NFFiscal + ")"
                        }
                }, 1, string.Empty);
            if (lPedFiscal.Count > 0)
            {
                CD_Movto.Text = lPedFiscal[0].Cd_movto.Value.ToString();
                DS_Movto.Text = lPedFiscal[0].Ds_movimentacao.Trim();
                if (!string.IsNullOrEmpty(vTp_movimento))
                    tp_movimento.SelectedValue = vTp_movimento;
                CD_Movto_Leave(this, new EventArgs());
                CD_CMI.Text = lPedFiscal[0].Cd_cmi.Value.ToString();
                CD_CMI_Leave(this, new EventArgs());
                cd_modelo.Text = lPedFiscal[0].Cd_modelo.Trim();
                ds_modelo.Text = lPedFiscal[0].Ds_modelo.Trim();
                NR_Serie.Text = lPedFiscal[0].Nr_serie.Trim();
                NR_Serie_Leave(this, new EventArgs());
                tp_docto = lPedFiscal[0].Tp_doctostr;
                ds_tpdocto = lPedFiscal[0].Ds_tpdocto;
            }
        }

        private void HabilitarCampoChaveAcesso()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) && (bsNotaFiscal.Current != null))
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota != null)
                    ChaveAcessoNFE.Enabled = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T") &&
                                             (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                                             (!Tp_serie.Trim().ToUpper().Equals("S"));

        }

        private void NotaFiscalExiste()
        {
            TRegistro_LanFaturamento retorno = TCN_LanFaturamento.existeNumeroNota(NR_NotaFiscal.Text, NR_Serie.Text, CD_Empresa.Text, CD_Clifor.Text, insc_estadualclifor.Text, tp_nota.SelectedValue.ToString().Trim(), null);
            if (retorno != null)
                if (retorno.St_registro.Trim().ToUpper().Equals("C"))
                {
                    if (MessageBox.Show("Nota Fiscal ja existe no sistema com status <CANCELADA>.\r\n" +
                                       "Deseja excluir a nota existente e reutilizar o numero?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!TCN_LanFaturamento.ExcluirNotaFiscal(retorno, null))
                        {
                            NR_NotaFiscal.Clear();
                            NR_NotaFiscal.Focus();
                        }
                    }
                    else
                    {
                        NR_NotaFiscal.Clear();
                        NR_NotaFiscal.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nota Fiscal ja existe no sistema com status <PROCESSADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NR_NotaFiscal.Clear();
                    NR_NotaFiscal.Focus();
                }
        }

        private void TotalizarNota()
        {
            if (bsNotaFiscal.Current != null)
            {
                vl_totalbasecalc.Value = TCN_LanFaturamento.CalcTotalBaseCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalicms.Value = TCN_LanFaturamento.CalcTotalICMS(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_toticmssubst.Value = TCN_LanFaturamento.CalcTotalICMSSubst(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalfcpst.Value = TCN_LanFaturamento.CalcTotalFCPST(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalipi.Value = TCN_LanFaturamento.CalcTotalIPI(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_total_impcalc.Value = TCN_LanFaturamento.CalcTotalImpCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalimpret.Value = TCN_LanFaturamento.CalcTotalImpRet(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalitens.Value = TCN_LanFaturamento.CalcTotalProdServ(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                vl_totalnota.Value = TCN_LanFaturamento.CalcTotalNota(bsNotaFiscal.Current as TRegistro_LanFaturamento);
            }
        }

        private void ConsultaNfe()
        {
            using (TFLanConsultaNFe fNfe = new TFLanConsultaNFe())
            {
                fNfe.ShowDialog();
            }
        }

        private void ReprocessarFiscal()
        {
            if ((bsNotaFiscal.Current != null) && (vTP_Modo.Equals(TTpModo.tm_Standby) || vTP_Modo.Equals(TTpModo.tm_busca)))
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().ToUpper().Equals("55") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P") &&
                    !string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_protocolo))
                {
                    MessageBox.Show("Não é permitido alterar documento eletronico aceito pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNotaFiscal.Current as TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nr_notafiscal_busca.Text = fReprocessa.rNf.Nr_notafiscalstr;
                            afterBusca();
                            //Verificar se Valor da nota é diferente do valor da duplicata desde que a mesma esteja sem liquidação.
                            if (new TCD_LanDuplicata().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_LanctoDuplicata = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'" +
                                                        "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr + ") "
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.vl_documento",
                                            vOperador = "<>",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Vl_totalnota.ToString().Replace(",", ".")
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and isnull(x.st_registro, 'A') <> 'C') "
                                        }
                                    }, "1") != null)
                            {
                                TList_RegLanDuplicata lDup =
                                    new TCD_LanDuplicata().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_LanctoDuplicata = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'" +
                                                        "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr + ") "
                                        }
                                    }, 1, string.Empty);

                                if (lDup.Count > 0)
                                    try
                                    {
                                        lDup[0].Vl_documento = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Vl_totalnota;
                                        lDup[0].Vl_documento_padrao = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Vl_totalnota;
                                        lDup[0].Parcelas.Clear();
                                        lDup[0].Parcelas = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(lDup[0], null);
                                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.AlterarDuplicata(lDup[0], null);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void ReprocessarEstoque()
        {
            if ((bsNotaFiscal.Current != null) && (vTP_Modo.Equals(TTpModo.tm_Standby) || vTP_Modo.Equals(TTpModo.tm_busca)))
            {
                if (MessageBox.Show("Confirma processamento do estoque?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanFaturamento.ReprocessarEstoqueNf(bsNotaFiscal.Current as TRegistro_LanFaturamento,
                                                                null);
                        MessageBox.Show("Estoque reprocessado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsNotaFiscal_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CorrigirNota()
        {
            if ((bsNotaFiscal.Current != null) && (vTP_Modo.Equals(TTpModo.tm_Standby) || vTP_Modo.Equals(TTpModo.tm_busca)))
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P") &&
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_transmitidoNFe)
                    {
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_serie.Trim().ToUpper().Equals("S"))
                        {
                            MessageBox.Show("NFS-e não disponibiliza serviço para emissão de carta correção.\r\n" +
                                            "Procedimento somente poderá ser realizado diretamente no site da prefeitura.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Buscar evento Carta Correcao
                        TList_Evento lEvento = TCN_Evento.Buscar(string.Empty, string.Empty, "CC", null);
                        if (lEvento.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe evento de CARTA CORREÇÃO cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (TFCartaCorrecaoEletronica fCCe = new TFCartaCorrecaoEletronica())
                        {
                            if (fCCe.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rCCe = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                    rCCe.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                    rCCe.Nr_lanctofiscal = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal;
                                    rCCe.Chave_acesso_nfe = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Chave_acesso_nfe;
                                    rCCe.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                    rCCe.Ds_evento = fCCe.Ds_correcao;
                                    rCCe.Cd_eventostr = lEvento[0].Cd_eventostr;
                                    rCCe.Descricao_evento = lEvento[0].Ds_evento;
                                    rCCe.Tp_evento = lEvento[0].Tp_evento;
                                    rCCe.St_registro = "A";
                                    CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rCCe, null);
                                    if (MessageBox.Show("Carta correção eletronica gravada com sucesso.\r\n" +
                                                    "Deseja enviar a mesma para a receita?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                    {
                                        //Buscar CfgNfe para a empresa
                                        TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de CCe para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            try
                                            {
                                                string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rCCe, lCfg[0]);
                                                if (!string.IsNullOrEmpty(msg))
                                                    MessageBox.Show("Erro ao enviar CCe para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                else
                                                {
                                                    MessageBox.Show("CCe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    afterBusca();
                                                    ImprimirEventoCCe();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                        using (TFCorrecaoNota fCorrecao = new TFCorrecaoNota())
                        {
                            fCorrecao.rfaturamento = (bsNotaFiscal.Current as TRegistro_LanFaturamento);
                            if (fCorrecao.ShowDialog() == DialogResult.OK)
                                if (fCorrecao.rfaturamento != null)
                                {
                                    //Processar alteracao nota
                                    TCN_LanFaturamento.AlterarFaturamento(fCorrecao.rfaturamento, null);
                                    MessageBox.Show("Nota Fiscal Alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    nr_notafiscal_busca.Text = fCorrecao.rfaturamento.Nr_notafiscalstr;
                                    afterBusca();
                                }
                        }
                }
            }
        }

        private void RefleshImpostosItem()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) &&
                (bsItensNota.Current != null))
            {
                bsImpostosItens.Clear();
                //Buscar impostos estaduais
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                          tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                          tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                          CD_Movto.Text,
                                                                                          tp_movimento.SelectedValue.ToString(),
                                                                                          cd_condFiscal_clifor.Text,
                                                                                          cd_condfiscal_produto.Text,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                          ref vObsFiscal,
                                                                                          DT_Emissao.Data,
                                                                                          CD_Produto.Text,
                                                                                          tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                          NR_Serie.Text,
                                                                                          null);
                if (lImpostos.Exists(v => v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpostos.Find(v => v.Imposto.St_ICMS), bsItensNota.Current as TRegistro_LanFaturamento_Item);
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }

                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                          cd_condfiscal_produto.Text,
                                                                          CD_Movto.Text,
                                                                          tp_movimento.SelectedValue.ToString(),
                                                                          tp_pessoa,
                                                                          CD_Empresa.Text,
                                                                          NR_Serie.Text,
                                                                          CD_Clifor.Text,
                                                                          cd_unidProduto,
                                                                          DT_Emissao.Data,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                          tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                          cd_municipioexecservico.Text,
                                                                          null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());
                TotalizarNota();
                bsNotaFiscal.ResetCurrentItem();
                bsItensNota.ResetCurrentItem();
            }
        }

        private void ConfigImpostoUf()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) &&
                (bsItensNota.Current != null))
            {
                using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
                {
                    fCondICMS.pCd_empresa = CD_Empresa.Text;
                    fCondICMS.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                    fCondICMS.pCd_condfiscal_produto = cd_condfiscal_produto.Text;
                    fCondICMS.pCd_movto = CD_Movto.Text;
                    fCondICMS.pCd_UfDest = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text;
                    fCondICMS.pCd_UfOrig = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text;
                    fCondICMS.pTp_movimento = tp_movimento.SelectedValue.ToString();
                    fCondICMS.pCd_imposto = (bsImpostosItens.Current != null ? (bsImpostosItens.Current as TRegistro_ImpostosNF).Cd_impostostr : string.Empty);
                    if (fCondICMS.ShowDialog() == DialogResult.OK)
                        if ((fCondICMS.rCond != null) &&
                            (fCondICMS.lMov != null) &&
                            (fCondICMS.lUfDestino != null) &&
                            (fCondICMS.lUfOrigem != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                                  fCondICMS.lMov,
                                                                                  fCondICMS.lUfOrigem,
                                                                                  fCondICMS.lUfDestino,
                                                                                  null);
                            }
                            catch
                            { }
                    RefleshImpostosItem();
                    afterGravaItensNF();
                }
            }
        }

        private void ConfigOutrosImpostos()
        {
            if (vTP_Modo.Equals(TTpModo.tm_Insert) &&
                (bsItensNota.Current != null))
            {
                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                {
                    fCondImposto.pCd_empresa = CD_Empresa.Text;
                    fCondImposto.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                    fCondImposto.pCd_condfiscal_produto = cd_condfiscal_produto.Text;
                    fCondImposto.pCd_movimentacao = CD_Movto.Text;
                    fCondImposto.pTp_faturamento = tp_movimento.SelectedValue.ToString();
                    fCondImposto.pSt_juridica = tp_pessoa.Trim().ToUpper().Equals("J");
                    fCondImposto.pSt_fisica = tp_pessoa.Trim().ToUpper().Equals("F");
                    fCondImposto.pCd_imposto = (bsImpostosItens.Current != null ? (bsImpostosItens.Current as TRegistro_ImpostosNF).Cd_impostostr : string.Empty);
                    if (fCondImposto.ShowDialog() == DialogResult.OK)
                        if ((fCondImposto.rCond != null) &&
                        (fCondImposto.lMov != null) &&
                        (fCondImposto.lCondClifor != null) &&
                        (fCondImposto.lCondProd != null))
                            try
                            {
                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                 fCondImposto.lMov,
                                                                                                 fCondImposto.lCondClifor,
                                                                                                 fCondImposto.lCondProd,
                                                                                                 fCondImposto.pSt_fisica,
                                                                                                 fCondImposto.pSt_juridica,
                                                                                                 fCondImposto.pSt_estrangeiro,
                                                                                                 null);
                            }
                            catch { }
                    RefleshImpostosItem();
                    afterGravaItensNF();
                }
            }
        }

        private void ManifestoNFe()
        {
            if (bsNotaFiscal.Current != null)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T") &&
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Buscar evento de Manifesto
                    TList_Evento lEvento = TCN_Evento.Buscar(string.Empty,
                                                             string.Empty,
                                                             "MF",
                                                             null);
                    TRegistro_Evento rEvento = null;
                    if (lEvento.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe evento de Manifesto configurado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (lEvento.Count > 1)
                    {
                        string vColunas = "a.ds_evento|Evento|200;" +
                                          "a.cd_evento|Codigo|80";
                        DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new TCD_Evento(), "a.tp_evento|=|'MF'");
                        if (linha != null)
                            rEvento = lEvento.Find(p => p.Cd_eventostr.Equals(linha["cd_evento"].ToString()));
                    }
                    else
                        rEvento = lEvento[0];
                    if (rEvento != null)
                    {
                        CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rMan = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                        rMan.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                        rMan.Nr_lanctofiscal = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal;
                        rMan.Chave_acesso_nfe = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Chave_acesso_nfe;
                        rMan.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                        rMan.Cd_eventostr = rEvento.Cd_eventostr;
                        rMan.Descricao_evento = rEvento.Ds_evento;
                        rMan.Tp_evento = rEvento.Tp_evento;
                        rMan.St_registro = "A";
                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rMan, null);
                        if (MessageBox.Show("Manifesto gravado com sucesso.\r\n" +
                                                "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                        {
                            //Buscar CfgNfe para a empresa
                            TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                            if (lCfg.Count.Equals(0))
                                MessageBox.Show("Não existe configuração para envio do Manifesto para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                try
                                {
                                    string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(rMan, lCfg[0]);
                                    if (!string.IsNullOrEmpty(msg))
                                        MessageBox.Show("Erro ao enviar Manifesto para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        MessageBox.Show("Manifesto enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).lEventoNFe = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                                                                                                           string.Empty,
                                                                                                                                           string.Empty,
                                                                                                                                           string.Empty,
                                                                                                                                           string.Empty,
                                                                                                                                           null);
                    }
                }
                else
                    MessageBox.Show("Permitido fazer Manifesto somente de NFe de TERCEIRO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImprimirEventoCCe()
        {
            if (bsEvento.Count > 0)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Status.Trim().ToUpper().Equals("ABERTO"))
                {
                    MessageBox.Show("Não é permitido Imprimir eventos com STATUS ABERTO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_eventostr != "110110")
                {
                    MessageBox.Show("Só é permitido imprimir Eventos de Carta de Correção!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Evento = new Relatorio();
                    Evento.Altera_Relatorio = Altera_Relatorio;

                    BindingSource Bin = new BindingSource();
                    Bin.DataSource = TCN_LanFaturamento.Busca(
                                                    (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa,
                                                    string.Empty,
                                                    string.Empty,
                                                    (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Nr_lanctofiscalstr,
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
                                                    0,
                                                    string.Empty,
                                                    null);
                    //Buscar Carta Correção
                    BindingSource binCCe = new BindingSource();
                    binCCe.DataSource = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Id_eventostr,
                                                                                           (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa,
                                                                                           (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Nr_lanctofiscalstr,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           "CC",
                                                                                           string.Empty,
                                                                                           null);
                    Evento.Adiciona_DataSource("CCe", binCCe);

                    Evento.Nome_Relatorio = "TFLanFaturamento_Evento";
                    Evento.NM_Classe = Name;
                    Evento.Modulo = "FAT";
                    Evento.Ident = "TFLanFaturamento_Evento";
                    Evento.DTS_Relatorio = Bin;
                    fImp.pMensagem = "CARTA CORREÇÃO";
                    //Verificar se existe logo configurada para a empresa
                    object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                                }
                                            }, "a.logoEmpresa");
                    if (log != null)
                        Evento.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);


                    if (Altera_Relatorio)
                    {
                        Evento.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "CARTA DE CORREÇÃO",
                                           fImp.pDs_mensagem);

                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Evento.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "CARTA DE CORREÇÃO",
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Evento!");

        }

        private void GerarXmlEvento(string path)
        {
            TRegistro_CfgNfe rCfg = TCN_CfgNfe.Buscar((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null)[0];
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Xml_evento.ToString());
            System.Xml.XmlNodeList y = doc.GetElementsByTagName("evento");
            string evento = y[0].InnerXml;

            System.Xml.XmlDocument docret = new System.Xml.XmlDocument();
            string retEvento = (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Xml_retevento.Remove(0, 405);

            string xmlEvento = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            xmlEvento += "<procEventoNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">\n";
            xmlEvento += "<evento versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">\n";
            xmlEvento += evento + "\n";
            xmlEvento += "</evento>\n";
            xmlEvento += retEvento + "\n";
            xmlEvento += "</procEventoNFe>";

            //Salvar arquivo no Path indicado 
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path.Trim() + "\\" +
                   (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Chave_acesso_nfe.Trim() +
                   (bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Cd_eventostr + "-procEventoNFe.xml"))
            {
                sw.Write(xmlEvento);
                sw.Flush();
                sw.Close();
            }
        }

        private void CalcularINSS(bool St_valor = false, bool St_valorRet = false)
        {
            if(vl_basecalcINSS.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcINSS.Value;
                if (pc_redbasecalcinss.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalcinss.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_INSS.Value > decimal.Zero)
                    vl_percentualINSS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_INSS.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if(vl_percentualINSS.Value > decimal.Zero)
                    vl_INSS.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualINSS.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoINSS.Value > decimal.Zero)
                    pc_retencaoINSS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoINSS.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if(pc_retencaoINSS.Value > decimal.Zero)
                    vl_retidoINSS.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoINSS.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void CalcularCSLL(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcCSLL.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcCSLL.Value;
                if (pc_redbasecalccsll.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalccsll.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_CSLL.Value > decimal.Zero)
                    vl_percentualCSLL.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_CSLL.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (vl_percentualCSLL.Value > decimal.Zero)
                    vl_CSLL.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualCSLL.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoCSLL.Value > decimal.Zero)
                    pc_retencaoCSLL.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoCSLL.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoCSLL.Value > decimal.Zero)
                    vl_retidoCSLL.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoCSLL.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void CalcularIRRF(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcIRRF.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcIRRF.Value;
                if (pc_redbasecalcirrf.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_redbasecalcirrf.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_IRRF.Value > decimal.Zero)
                    vl_percentualIRRF.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_IRRF.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (vl_percentualIRRF.Value > decimal.Zero)
                    vl_IRRF.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(vl_percentualIRRF.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_retidoIRRF.Value > decimal.Zero)
                    pc_retencaoIRRF.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_retidoIRRF.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoIRRF.Value > decimal.Zero)
                    vl_retidoIRRF.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoIRRF.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void CalcularISS(bool St_valor = false, bool St_valorRet = false)
        {
            if (vl_basecalcISS.Value > decimal.Zero)
            {
                decimal basecalc = vl_basecalcISS.Value;
                if (pc_reducaobasecalcISS.Value > decimal.Zero)
                    basecalc = Math.Round(decimal.Subtract(basecalc, decimal.Multiply(basecalc, decimal.Divide(pc_reducaobasecalcISS.Value, 100))), 2, MidpointRounding.AwayFromZero);
                if (St_valor && vl_iss.Value > decimal.Zero)
                    pc_aliquotaISS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_iss.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_aliquotaISS.Value > decimal.Zero)
                    vl_iss.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_aliquotaISS.Value, 100)), 2, MidpointRounding.AwayFromZero);
                if (St_valorRet && vl_issretido.Value > decimal.Zero)
                    pc_retencaoISS.Value = Math.Round(decimal.Multiply(decimal.Divide(vl_issretido.Value, basecalc), 100), 2, MidpointRounding.AwayFromZero);
                else if (pc_retencaoISS.Value > decimal.Zero)
                    vl_issretido.Value = Math.Round(decimal.Multiply(basecalc, decimal.Divide(pc_retencaoISS.Value, 100)), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void NR_Pedido_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|=|" + NR_Pedido.Text + ";" +
                              "isnull(a.st_pedido, 'A')|=|'F'" +

                              ";|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                              "where x.cfg_pedido = a.cfg_pedido " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))) " +

                              ";|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas,
                new EditDefault[] { NR_Pedido, CD_Clifor, NM_Clifor, cd_condFiscal_clifor, CD_Empresa, NM_Empresa,
                                                CD_Endereco, DS_Endereco, insc_estadualclifor, DS_Cidade, CD_CondPGTO, DS_CondPgto }, new TCD_Pedido());
            if (linha != null)
            {
                ds_ObservacaoFiscal.Text = linha["DS_Observacao"].ToString();
                cd_municipioexecservico.Text = !string.IsNullOrEmpty(linha["cd_municipioexecservico"].ToString()) ? linha["cd_municipioexecservico"].ToString() : linha["cd_cidade"].ToString();
                ds_municipioexecservico.Text = !string.IsNullOrEmpty(linha["cd_municipioexecservico"].ToString()) ? linha["ds_municipioexecservico"].ToString() : linha["ds_cidade"].ToString();
                CD_CondPGTO_Leave(this, new EventArgs());
                TCN_LanPedido_Item.totalPedido(NR_Pedido.Text, "", ref tQtdPedido, ref tVlPedido);
                TCN_LanPedidoItem_X_Estoque.saldoPedidoXEstoque(NR_Pedido.Text, "", ref tQtdEstPedido, ref tVlEstPedido, null);
                UF_EMPRESA.Text = linha["UF_Empresa"].ToString();
                cd_uf_empresa.Text = linha["cd_uf_empresa"].ToString();
                if (linha["TP_Movimento"].ToString().Trim() == "E")
                    tp_movimento.SelectedIndex = 0;
                else if (linha["TP_Movimento"].ToString().Trim() == "S")
                    tp_movimento.SelectedIndex = 1;
                UF_Cliente.Text = linha["UF_Cliente"].ToString();
                cd_uf_clifor.Text = linha["cd_uf_cliente"].ToString();
                if (linha["TP_Pessoa"].ToString().Trim().Equals("J"))
                    NR_CGC_CPF.Text = linha["NR_CGC"].ToString();
                else if (linha["TP_Pessoa"].ToString().Trim().Equals("F"))
                    NR_CGC_CPF.Text = linha["NR_CPF"].ToString();

                st_equiparado_pj = linha["ST_Equiparado_PJ"].ToString().Trim().Equals("S");
                st_equiparado_pf = linha["ST_Agropecuaria"].ToString().Trim().Equals("S");
                tp_pessoa = linha["TP_Pessoa"].ToString();
                tp_nota.SelectedIndex = TCN_LanFaturamento.validarST_Nota(tp_movimento.SelectedValue.ToString().Trim(), tp_pessoa, st_equiparado_pj, st_equiparado_pf);
                //Buscar configuração do pedido
                TList_CadCFGPedido lCfgPed = TCN_CadCFGPedido.Buscar(string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     Convert.ToDecimal(NR_Pedido.Text),
                                                                     1,
                                                                     string.Empty, null);
                cbconfere_saldo.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_confere_saldobool : false;
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_confere_saldo = cbconfere_saldo.Checked;
                cbpermite_pedidoparcial.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_permite_pedidoparcialbool : false;
                cbvalores_fixos.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_valoresfixosbool : false;
                st_servico.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_servicobool : false;
                st_commoditties.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_commodittiesbool : false;

                //Buscar moeda do pedido
                TList_Moeda lMoedaPed = new TCD_Moeda().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from vtb_fat_pedido x "+
                                        "where x.cd_moeda = a.cd_moeda "+
                                        "and x.nr_pedido = "+NR_Pedido.Text+")"
                        }
                    }, 1, string.Empty);
                if (lMoedaPed.Count > 0)
                {
                    cd_moeda_pedido.Text = lMoedaPed[0].Cd_moeda;
                    ds_moeda_pedido.Text = lMoedaPed[0].Ds_moeda_singular;
                    sigla_moeda_pedido.Text = lMoedaPed[0].Sigla;
                }
                //Buscar Moeda Padrao
                TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(CD_Empresa.Text, null);
                if (tabela != null)
                    if (tabela.Count > 0)
                    {
                        cd_moeda_padrao.Text = tabela[0].Cd_moeda;
                        ds_moeda_padrao.Text = tabela[0].Ds_moeda_singular;
                        sigla_moeda_padrao.Text = tabela[0].Sigla;
                    }
                    else
                    {
                        cd_moeda_padrao.Text = string.Empty;
                        ds_moeda_padrao.Text = string.Empty;
                        sigla_moeda_padrao.Text = string.Empty;
                    }
                else
                {
                    cd_moeda_padrao.Text = string.Empty;
                    ds_moeda_padrao.Text = string.Empty;
                    sigla_moeda_padrao.Text = string.Empty;
                }
                if (bsNotaFiscal.Current != null)
                {
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Freteporconta = linha["tp_frete"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Vl_frete = Convert.ToDecimal(linha["vl_frete"].ToString());
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_transportadora = linha["cd_transportadora"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_razaosocialtransp = linha["nm_transportadora"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cpf_transp = linha["nr_cgc_cpf_transp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_enderecotransp = linha["cd_enderecotransp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_enderecotransp = linha["ds_enderecotransp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Numero = linha["numeronf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Marca = linha["marcanf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Especie = linha["especienf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Quantidade = Convert.ToDecimal(linha["quantidadenf"].ToString());
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Logradouroent = linha["logradouroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Numeroent = linha["numeroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Complementoent = linha["complementoent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Bairroent = linha["bairroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_cidadeent = linha["cd_cidadeent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_cidadeent = linha["ds_cidadeent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Uf_ent = linha["uf_ent"].ToString();
                    if (!string.IsNullOrEmpty(linha["logradouroent"].ToString()) && vTp_NFFiscal.ToUpper().Equals("'NO'"))
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dadosadicionais =
                        "ENDERECO DE ENTREGA: " + linha["logradouroent"].ToString() + ", Nº " + linha["numeroent"].ToString() + "\r\n" +
                        "BAIRRO: " + linha["bairroent"].ToString() + "\r\n" +
                        "CIDADE: " + linha["ds_cidadeent"].ToString() + "-" + linha["uf_ent"].ToString();
                        bsNotaFiscal.ResetCurrentItem();
                    }
                }
                //Buscar Cotação
                BuscarCotacao();
                habilitarNovaNf();
                BuscarCfgFiscalPedido();
            }
        }

        private void bb_pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Pedido|Nº Pedido|100;" +
                              "a.CD_Empresa|Cd. Empresa|80;" +
                              "b.NM_Empresa|Nome Empresa|150;" +
                              "d.NM_Clifor|Nome Clifor|150;" +
                              "a.CD_Clifor|Cd. Clifor|80;" +
                              "nr_cgc_cpf|CNPJ/CPF|100;" +
                              "endClifor.Insc_Estadual|Insc. Estadual|100;" +
                              "a.CD_Endereco|Cd. Endereço|80;" +
                              "endClifor.ds_endereco|Endereço|150;" +
                              "endClifor.ds_cidade|Cidade|150;" +
                              "endClifor.Insc_Estadual|Insc. Estadual|100;" +
                              "a.TP_Movimento|TP. Movimento|80;" +
                              "d.cd_condfiscal_clifor|Cond. Fiscal Clifor|80;" +
                              "a.CD_CondPgto|Cd. CondPgto|80;" +
                              "h.DS_CondPgto|Condição Pagamento|150;" +
                              "a.CD_MunicipioExecServico|Cd. Municipio Serviço|100;" +
                              "b.TP_NaturezaOperacaoISS|Natureza ISSQN|80;" +
                              "ds_municipioexecservico|Municipio Serviço|200;" +
                              "#a.vl_totalpedido|Valor Pedido|100;" +
                              "#a.vl_totalfat_entrada|Valor Notas Entrada|100;" +
                              "#a.vl_totalfat_saida|Valor Notas Saida|100";

            string vParam = "isnull(a.st_pedido, 'A')|=|'F'" +

                            ";|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                            "where x.cfg_pedido = a.cfg_pedido " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))) " +

                            ";|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";

            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas
                , new EditDefault[] { NR_Pedido, CD_Clifor, NM_Clifor, CD_Endereco, DS_Endereco, insc_estadualclifor, DS_Cidade, cd_condFiscal_clifor, CD_Empresa, NM_Empresa, CD_CondPGTO, DS_CondPgto }
                , new TCD_Pedido(), vParam);
            if (linha != null)
            {
                ds_ObservacaoFiscal.Text = linha["DS_Observacao"].ToString();
                cd_municipioexecservico.Text = linha["cd_municipioexecservico"].ToString();
                ds_municipioexecservico.Text = linha["ds_municipioexecservico"].ToString();
                CD_CondPGTO_Leave(this, new EventArgs());
                TCN_LanPedido_Item.totalPedido(NR_Pedido.Text, "", ref tQtdPedido, ref tVlPedido);
                TCN_LanPedidoItem_X_Estoque.saldoPedidoXEstoque(NR_Pedido.Text, "", ref tQtdEstPedido, ref tVlEstPedido, null);
                UF_Cliente.Text = linha["UF_Cliente"].ToString();
                cd_uf_clifor.Text = linha["cd_uf_cliente"].ToString();
                UF_EMPRESA.Text = linha["UF_Empresa"].ToString();
                cd_uf_empresa.Text = linha["cd_uf_empresa"].ToString();
                if (linha["TP_Pessoa"].ToString().Trim().Equals("J"))
                    NR_CGC_CPF.Text = linha["NR_CGC"].ToString();
                else if (linha["TP_Pessoa"].ToString().Trim().Equals("F"))
                    NR_CGC_CPF.Text = linha["NR_CPF"].ToString();
                if (linha["TP_Movimento"].ToString().Trim() == "E")
                    tp_movimento.SelectedIndex = 0;
                else if (linha["TP_Movimento"].ToString().Trim() == "S")
                    tp_movimento.SelectedIndex = 1;
                st_equiparado_pj = linha["ST_Equiparado_PJ"].ToString().Trim().Equals("S");
                st_equiparado_pf = linha["ST_Agropecuaria"].ToString().Trim().Equals("S");
                tp_pessoa = linha["TP_Pessoa"].ToString();
                tp_nota.SelectedIndex = TCN_LanFaturamento.validarST_Nota(tp_movimento.SelectedValue.ToString().Trim(), tp_pessoa, st_equiparado_pj, st_equiparado_pf);
                //Buscar configuração do pedido
                TList_CadCFGPedido lCfgPed = TCN_CadCFGPedido.Buscar(string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     Convert.ToDecimal(NR_Pedido.Text),
                                                                     1,
                                                                     string.Empty,
                                                                     null);
                cbconfere_saldo.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_confere_saldobool : false;
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_confere_saldo = cbconfere_saldo.Checked;
                cbpermite_pedidoparcial.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_permite_pedidoparcialbool : false;
                cbvalores_fixos.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_valoresfixosbool : false;
                st_servico.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_servicobool : false;
                st_commoditties.Checked = lCfgPed.Count > 0 ? lCfgPed[0].St_commodittiesbool : false;
                //Buscar moeda do pedido
                TList_Moeda lMoedaPed = new TCD_Moeda().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from vtb_fat_pedido x "+
                                        "where x.cd_moeda = a.cd_moeda "+
                                        "and x.nr_pedido = "+NR_Pedido.Text+")"
                        }
                    }, 1, string.Empty);
                if (lMoedaPed.Count > 0)
                {
                    cd_moeda_pedido.Text = lMoedaPed[0].Cd_moeda;
                    ds_moeda_pedido.Text = lMoedaPed[0].Ds_moeda_singular;
                    sigla_moeda_pedido.Text = lMoedaPed[0].Sigla;
                }
                //Buscar Moeda Padrao
                TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(CD_Empresa.Text, null);
                if (tabela != null)
                    if (tabela.Count > 0)
                    {
                        cd_moeda_padrao.Text = tabela[0].Cd_moeda;
                        ds_moeda_padrao.Text = tabela[0].Ds_moeda_singular;
                        sigla_moeda_padrao.Text = tabela[0].Sigla;
                    }
                    else
                    {
                        cd_moeda_padrao.Text = string.Empty;
                        ds_moeda_padrao.Text = string.Empty;
                        sigla_moeda_padrao.Text = string.Empty;
                    }
                else
                {
                    cd_moeda_padrao.Text = string.Empty;
                    ds_moeda_padrao.Text = string.Empty;
                    sigla_moeda_padrao.Text = string.Empty;
                }
                if (bsNotaFiscal.Current != null)
                {
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Freteporconta = linha["tp_frete"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_transportadora = linha["cd_transportadora"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_razaosocialtransp = linha["nm_transportadora"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cpf_transp = linha["nr_cgc_cpf_transp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_enderecotransp = linha["cd_enderecotransp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_enderecotransp = linha["ds_enderecotransp"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Numero = linha["numeronf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Marca = linha["marcanf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Especie = linha["especienf"].ToString().Trim();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Quantidade = Convert.ToDecimal(linha["quantidadenf"].ToString());
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Logradouroent = linha["logradouroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Numeroent = linha["numeroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Complementoent = linha["complementoent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Bairroent = linha["bairroent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_cidadeent = linha["cd_cidadeent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_cidadeent = linha["ds_cidadeent"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Uf_ent = linha["uf_ent"].ToString();
                    bsNotaFiscal.ResetCurrentItem();
                }
                //Buscar Cotação
                BuscarCotacao();
                //habilitar campos nf
                habilitarNovaNf();
                BuscarCfgFiscalPedido();
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new EditDefault[] { CD_Clifor, NM_Clifor }, new TCD_CadClifor());
            if (linha != null)
            {
                NR_CGC_CPF.Text = linha["tp_pessoa"].ToString().Trim().ToUpper().Equals("J") ? linha["nr_cgc"].ToString() : linha["nr_cpf"].ToString();
                cd_condFiscal_clifor.Text = linha["CD_CondFiscal_Clifor"].ToString();
                st_equiparado_pf = linha["ST_Agropecuaria"].ToString().Trim().Equals("S");
                st_equiparado_pj = linha["ST_Equiparado_PJ"].ToString().Trim().Equals("S");
                tp_pessoa = linha["TP_Pessoa"].ToString();
                if (tp_movimento.SelectedValue != null)
                {
                    tp_nota.SelectedIndex = TCN_LanFaturamento.validarST_Nota(tp_movimento.SelectedValue.ToString().Trim(), tp_pessoa, st_equiparado_pj, st_equiparado_pf);
                    if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") &&
                            cd_uf_clifor.Text.Trim().Equals("99"))
                        if (!tcDetalhe.TabPages.Contains(tpEx))
                            tcDetalhe.TabPages.Add(tpEx);
                }
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            if (linha != null)
            {
                NR_CGC_CPF.Text = linha["tp_pessoa"].ToString().Trim().ToUpper().Equals("J") ? linha["nr_cgc"].ToString() : linha["nr_cpf"].ToString();
                cd_condFiscal_clifor.Text = linha["CD_CondFiscal_Clifor"].ToString();
                st_equiparado_pf = linha["ST_Agropecuaria"].ToString().Trim().Equals("S");
                st_equiparado_pj = linha["ST_Equiparado_PJ"].ToString().Trim().Equals("S");
                tp_pessoa = linha["TP_Pessoa"].ToString();
                if (tp_movimento.SelectedValue != null)
                {
                    tp_nota.SelectedIndex = TCN_LanFaturamento.validarST_Nota(tp_movimento.SelectedValue.ToString().Trim(), tp_pessoa, st_equiparado_pj, st_equiparado_pf);
                    if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") &&
                            cd_uf_clifor.Text.Trim().Equals("99"))
                        if (!tcDetalhe.TabPages.Contains(tpEx))
                            tcDetalhe.TabPages.Add(tpEx);
                }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF_Cliente, cd_uf_clifor, insc_estadualclifor }, new TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;a.DS_Cidade|Cidade|250;a.DS_UF|Estado|150;a.UF|UF|80;a.cd_uf|Cd. UF|80;a.insc_estadual|Insc. Estadual|80"
                , new EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF_Cliente, cd_uf_clifor, insc_estadualclifor }, new TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text + "'");
        }

        private void CD_Movto_Leave(object sender, EventArgs e)
        {
            if (NR_Pedido.Text.Trim() != string.Empty)
            {
                CD_Movto.NM_CampoBusca = "CD_Movto";
                string vColunas = "a.CD_Movto|=|'" + CD_Movto.Text + "';" +
                                  "d.TP_Movimento|=|'" + tp_movimento.SelectedValue.ToString().Trim() + "';" +
                                  "|exists|(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + NR_Pedido.Text + ")";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Movto, DS_Movto },
                                        new TCD_CadCFGPedidoFiscal());
                if (linha != null)
                {
                    if (UF_EMPRESA.Text != UF_Cliente.Text)
                    {
                        ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(linha["DS_ObsFiscal_ForaEstado"].ToString())) ? "," : string.Empty + linha["DS_ObsFiscal_ForaEstado"].ToString();
                        ds_DadosAdicionais.Text = linha["DS_DadosAdic_ForaEstado"].ToString();
                    }
                    else
                    {
                        ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(linha["DS_ObsFiscal_DentroEstado"].ToString())) ? "," : string.Empty + linha["DS_ObsFiscal_DentroEstado"].ToString();
                        ds_DadosAdicionais.Text = linha["DS_DadosAdic_DentroEstado"].ToString();
                    }
                }
            }
        }

        private void BB_Movto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_Pedido.Text))
            {
                string vColunas = "e.ds_movimentacao|Movimentação Comercial|300;" +
                                   "a.CD_Movto|Cd. Movimentação|100";
                string vParamFixo = "d.TP_Movimento|=|'" + tp_movimento.SelectedValue.ToString().Trim() + "';" +
                                    "|exists|(select 1 from tb_fat_pedido x " +
                                            "where x.cfg_pedido = a.cfg_pedido " +
                                            "and x.nr_pedido = " + NR_Pedido.Text + ")";
                UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Movto, DS_Movto },
                                        new TCD_CadCFGPedidoFiscal(), vParamFixo);
                CD_Movto_Leave(this, new EventArgs());
            }
        }

        private void BB_CMI_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CMI|Descrição CMI|350;" +
                              "a.CD_CMI|Cód. CMI|100;" +
                              "a.TP_Duplicata|TP. Duplicata|80;" +
                              "d.DS_TpDuplicata|Tipo Duplicata|200";
            string vParam = "f.cd_movimentacao|=|'" + CD_Movto.Text.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_CMI, tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"), vParam);
            if (linha != null)
            {
                if (bsNotaFiscal.Current != null)
                {
                    //Preencher CMI Nota
                    TCN_LanFaturamento_CMI.PreencherCMINota(bsNotaFiscal.Current as TRegistro_LanFaturamento, null);
                    bsNotaFiscal.ResetCurrentItem();
                }
                if (CD_CondPGTO.Text.Trim().Equals(string.Empty))
                {
                    CD_CondPGTO.Text = linha["CD_CondPgto"].ToString();
                    DS_CondPgto.Text = linha["DS_CondPgto"].ToString();
                    if (bsNotaFiscal.Current != null)
                    {
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = decimal.Zero;
                        }
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = decimal.Zero;
                        }
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S");
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_juro_fin = linha["CD_Juro_Fin"].ToString();
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_juro_fin = linha["DS_Juro_Fin"].ToString();
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = Convert.ToDecimal(linha["pc_jurodiario_atrazo"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = decimal.Zero;
                        }
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro = linha["TP_Juro"].ToString();
                        bsNotaFiscal.ResetCurrentItem();
                    }
                }
                st_devolucao = linha["ST_Devolucao"].ToString().Trim().Equals("S");
                st_retorno = linha["ST_Retorno"].ToString().Trim().Equals("S");
                st_complemento = linha["ST_Complementar"].ToString().Trim().Equals("S");
                st_compdevimposto = linha["ST_CompDevImposto"].ToString().Trim().Equals("S");
                st_mestra = linha["ST_Mestra"].ToString().Trim().Equals("S");
                st_simplesRemessa = linha["ST_SimplesRemessa"].ToString().Trim().Equals("S");
                st_gerarEstoque = linha["ST_GeraEstoque"].ToString().Trim().Equals("S");
                CD_CondPGTO.Enabled = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                BB_CondPgto.Enabled = CD_CondPGTO.Enabled;
            }
        }

        private void CD_CondPGTO_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("CD_CondPgto|=|'" + CD_CondPGTO.Text + "'"
                , new EditDefault[] { CD_CondPGTO, DS_CondPgto }, new TCD_CadCondPgto());
            if (linha != null)
            {
                st_controleTitulo = linha["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
                if (bsNotaFiscal.Current != null)
                {
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = decimal.Zero;
                    }
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = decimal.Zero;
                    }
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S");
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_juro_fin = linha["CD_Juro_Fin"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_juro_fin = linha["DS_Juro_Fin"].ToString();
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = decimal.Zero;
                    }
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro = linha["tp_juro_fin"].ToString();
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Count > 0)
                    {
                        //Limpar lista de itens da nota
                        //para calcular o valor do juro financeiro e os impostos
                        bsItensNota.Clear();
                    }
                    bsNotaFiscal.ResetCurrentItem();
                }
            }
        }

        private void BB_CondPgto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondPgto|Condição Pagamento|250;" +
                              "CD_CondPgto|Cd. CondPgto|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas
                                                        , new EditDefault[] { CD_CondPGTO, DS_CondPgto }, new TCD_CadCondPgto(), string.Empty);
            if (linha != null)
            {
                st_controleTitulo = linha["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
                if (bsNotaFiscal.Current != null)
                {
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = decimal.Zero;
                    }
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = decimal.Zero;
                    }
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S");
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_juro_fin = linha["CD_Juro_Fin"].ToString();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_juro_fin = linha["DS_Juro_Fin"].ToString();
                    try
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = Convert.ToDecimal(linha["pc_juroDiario_atrazoFin"].ToString());
                    }
                    catch
                    {
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = decimal.Zero;
                    }
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro = linha["tp_juro_fin"].ToString();
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Count > 0)
                    {
                        //Limpar lista de itens da nota
                        //para calcular o valor do juro financeiro e os impostos
                        bsItensNota.Clear();
                    }
                    bsNotaFiscal.ResetCurrentItem();
                }
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NR_Serie_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|=|'" + NR_Serie.Text.Trim() + "';" +
                              "a.CD_Modelo|=|'" + cd_modelo.Text.Trim() + "'";
            if (st_servico.Checked)
                vColunas += ";a.tp_serie|=|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas
                , new EditDefault[] { NR_Serie, cd_modelo, ds_modelo },
                new TCD_CadSerieNF());
            if (linha != null)
            {
                st_sequenciaauto = linha["ST_SequenciaAuto"].ToString().Equals("S");
                Tp_serie = linha["tp_serie"].ToString();
            }
            else
                Tp_serie = string.Empty;
            habilitaCampoNumeroNota(st_sequenciaauto);
            HabilitarCampoChaveAcesso();
        }

        private void CD_Transp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'"
                , new EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor());
        }

        private void bb_trasnp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;NR_CGC_CPF|CNPJ/CPF|100"
                , new EditDefault[] { CD_Transp, NM_RazaoSocialTransp, CPF_Transp }, new TCD_CadClifor(), "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        // ITENS
        private void inserirItensNota(DataTable tabela)
        {
            for (int i = 0; i < tabela.Rows.Count; i++)
                inserirItensNota(tabela.Rows[i]);
        }

        private void inserirItensNota(DataRow linha)
        {
            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => ((p.Id_pedidoitem.Equals(Convert.ToDecimal(linha["ID_PedidoItem"].ToString())))) && (p.Nr_pedido.ToString().Equals(linha["NR_Pedido"].ToString()))))
            {
                MessageBox.Show("Item ja se encontra cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!st_complemento)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_desconto = decimal.Parse(linha["pc_desc"].ToString());
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_outrasdesp = decimal.Parse(linha["pc_acrescimo"].ToString());
            }

            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto = linha["CD_Produto"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Nr_pedido = decimal.Parse(linha["NR_Pedido"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Id_pedidoitem = decimal.Parse(linha["ID_PedidoItem"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto = linha["CD_CondFiscal_Produto"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_local = linha["CD_Local"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_local = linha["DS_Local"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidEst = linha["CD_UnES"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Sigla_unidade_estoque = linha["SG_UnES"].ToString();

            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidade = linha["CD_UnVL"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_unidade = linha["DS_UnVL"].ToString();
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Sigla_unidade = linha["SG_UnVL"].ToString();
            if (!st_complemento)
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_freteitem =
                    TCN_LanPedido_Item.RatearFreteItemNF(linha["nr_pedido"].ToString(),
                                                         linha["cd_produto"].ToString(),
                                                         linha["id_pedidoitem"].ToString(),
                                                         decimal.Parse(linha["Quantidade"].ToString()),
                                                         null);
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade = decimal.Parse(linha["Quantidade"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Qtd_totalconferencia = decimal.Parse(linha["qtd_conferencia"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_unitario = decimal.Parse(linha["Vl_Unitario"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal = decimal.Parse(linha["Vl_subTotal"].ToString());
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).Observacao_item = linha["ds_observacaoitem"].ToString();
            try
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_imposto_Aprox = decimal.Parse(linha["pc_imposto_aprox"].ToString());
            }
            catch { }
            //Procurar cfop do item
            CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
            if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(CD_Movto.Text,
                                                               (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                               cd_uf_clifor.Text.Trim().Equals("99") ? "I" : cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "D" : "F",
                                                               tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                               tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                               tp_movimento.SelectedValue.ToString(),
                                                               cd_condFiscal_clifor.Text,
                                                               CD_Empresa.Text,
                                                               ref rCfop,
                                                               null))
            {
                if (st_devolucao && (!rCfop.St_devolucaobool))
                {
                    MessageBox.Show("Permitido emitir NF-e de DEVOLUÇÃO somente utilizando CFOP de DEVOLUÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if ((!st_devolucao) && rCfop.St_devolucaobool)
                {
                    MessageBox.Show("Não é permitido emitir NF-e NORMAL utilizando CFOP de DEVOLUÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (st_retorno && (!rCfop.St_retornobool))
                {
                    MessageBox.Show("Permitido emitir NF-e de RETORNO somente utilizando CFOP de RETORNO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_cfop = rCfop.CD_CFOP;
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_cfop = rCfop.DS_CFOP;
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_bonificacao = rCfop.St_bonificacaobool;
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_usoconsumo = rCfop.St_usoconsumobool;
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_retorno = rCfop.St_retornobool;
                }
            }
            else
            {
                MessageBox.Show("Não existe CFOP " + (cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + CD_Movto.Text + " condição fiscal do produto " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("S") && !st_complemento)
                //Calcular juro financeiro
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_juro_fin =
                    TCN_CadCondPgto.CalcularValorJuroFin(
                                                        new TRegistro_CadCondPgto()
                                                        {
                                                            Pc_jurodiario_atrazoFin = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo,
                                                            Tp_juro_fin = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro,
                                                            Qt_diasdesdobro = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro,
                                                            St_comentradabool = (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada,
                                                            Qt_parcelas = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas
                                                        }, (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal);

            cd_unidProduto = linha["CD_UnES"].ToString();
            sigla_unidade_estoque.Text = linha["SG_UnES"].ToString();
            Vl_Unitario.Enabled = !st_valoresfixos;
            string vObsFiscal = string.Empty;
            TList_ImpostosNF lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                      tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                      tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                      CD_Movto.Text,
                                                                                      tp_movimento.SelectedValue.ToString(),
                                                                                      cd_condFiscal_clifor.Text,
                                                                                      cd_condfiscal_produto.Text,
                                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                      ref vObsFiscal,
                                                                                      DT_Emissao.Data,
                                                                                      CD_Produto.Text,
                                                                                      tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                      NR_Serie.Text,
                                                                                      null);
            if (lImpostos.Exists(v => v.Imposto.St_ICMS))
            {
                TCN_LanFaturamento_Item.PreencherICMS(lImpostos.Find(v => v.Imposto.St_ICMS), bsItensNota.Current as TRegistro_LanFaturamento_Item);
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
            }
            else
            {
                //Verificar se existe imposto icms configurado para o item
                if (TCN_LanFaturamento_Item.ObrigImformarICMS((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto, (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie, null))
                {
                    CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondFiscalICMS");
                    if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                    {
                        //Buscar codigo imposto ICMS
                        object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.st_icms",
                                                vOperador = "=",
                                                vVL_Busca = "0"
                                            }
                                        }, "a.cd_imposto");
                        //Abrir cadastro de configuracao icms
                        using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
                        {
                            fCondICMS.pCd_empresa = CD_Empresa.Text;
                            fCondICMS.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                            fCondICMS.pCd_condfiscal_produto = linha["CD_CondFiscal_Produto"].ToString();
                            fCondICMS.pCd_movto = CD_Movto.Text;
                            fCondICMS.pCd_UfDest = tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text;
                            fCondICMS.pCd_UfOrig = tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text;
                            fCondICMS.pTp_movimento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                            fCondICMS.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                            if (fCondICMS.ShowDialog() == DialogResult.OK)
                                if ((fCondICMS.rCond != null) &&
                                    (fCondICMS.lMov != null) &&
                                    (fCondICMS.lUfOrigem != null) &&
                                    (fCondICMS.lUfDestino != null))
                                    try
                                    {
                                        CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                                          fCondICMS.lMov,
                                                                                          fCondICMS.lUfOrigem,
                                                                                          fCondICMS.lUfDestino,
                                                                                          null);
                                    }
                                    catch { }
                            vObsFiscal = string.Empty;
                            lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                      tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                      tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                      CD_Movto.Text,
                                                                                      tp_movimento.SelectedValue.ToString(),
                                                                                      cd_condFiscal_clifor.Text,
                                                                                      cd_condfiscal_produto.Text,
                                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                      ref vObsFiscal,
                                                                                      DT_Emissao.Data,
                                                                                      CD_Produto.Text,
                                                                                      tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                      NR_Serie.Text,
                                                                                      null);
                            if (lImpostos.Exists(v => v.Imposto.St_ICMS))
                            {
                                TCN_LanFaturamento_Item.PreencherICMS(lImpostos.Find(v => v.Imposto.St_ICMS), bsItensNota.Current as TRegistro_LanFaturamento_Item);
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                            }
                            bsNotaFiscal.ResetCurrentItem();
                            bsItensNota.ResetCurrentItem();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existe condição fiscal para: \r\n" +
                                        "Tipo Movimento: " + tp_movimento.Text.Trim() + "\r\n" +
                                        "Movimentação Comercial: " + CD_Movto.Text.Trim() + " - " + DS_Movto.Text.Trim() + "\r\n" +
                                        "Condição Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                        "Condição Fiscal Produto: " + linha["CD_CondFiscal_Produto"].ToString().Trim() + "\r\n" +
                                        "UF Origem: " + (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text) + "\r\n" +
                                        "UF Destino: " + (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_pedidoitem.Clear();
                        Nr_PedidoItem.Clear();
                        CD_Produto.Clear();
                        ds_produto.Clear();
                        cd_condfiscal_produto.Clear();
                        CD_Local.Clear();
                        ds_local.Clear();
                        CD_Unidade.Clear();
                        ds_unidade.Clear();
                        sigla_unidade_estoque.Clear();
                        sigla_unidade_vl.Clear();
                        Quantidade.Value = 0;
                        Vl_Unitario.Value = 0;
                        Vl_SubTotal.Value = 0;
                        id_pedidoitem.Focus();
                        bsNotaFiscal.ResetCurrentItem();
                        bsItensNota.ResetCurrentItem();
                    }
                }
            }
            //Procurar impostos sobre os itens da nota fiscal de destino
            TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                      cd_condfiscal_produto.Text,
                                                                      CD_Movto.Text,
                                                                      tp_movimento.SelectedValue.ToString(),
                                                                      tp_pessoa,
                                                                      CD_Empresa.Text,
                                                                      NR_Serie.Text,
                                                                      CD_Clifor.Text,
                                                                      cd_unidProduto,
                                                                      DT_Emissao.Data,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                      tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                      cd_municipioexecservico.Text,
                                                                      null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());
            //Verificar obrigatoriedade PIS
            if (TCN_LanFaturamento_Item.ObrigInformarPIS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                        bsItensNota.Current as TRegistro_LanFaturamento_Item, null))
            {
                //Verificar se o usuario tem acesso a tela de configuracao do imposto
                CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                {
                    //Buscar codigo imposto PIS
                    object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_pis",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                    }, "a.cd_imposto");
                    //Abrir cadastro de configuracao icms
                    using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                    {
                        fCondImposto.pCd_empresa = CD_Empresa.Text;
                        fCondImposto.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                        fCondImposto.pCd_condfiscal_produto = linha["CD_CondFiscal_Produto"].ToString();
                        fCondImposto.pCd_movimentacao = CD_Movto.Text;
                        fCondImposto.pTp_faturamento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                        fCondImposto.pSt_juridica = tp_pessoa.Trim().ToUpper().Equals("J");
                        fCondImposto.pSt_fisica = tp_pessoa.Trim().ToUpper().Equals("F");
                        fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                        if (fCondImposto.ShowDialog() == DialogResult.OK)
                            if ((fCondImposto.rCond != null) &&
                            (fCondImposto.lMov != null) &&
                            (fCondImposto.lCondClifor != null) &&
                            (fCondImposto.lCondProd != null))
                                try
                                {
                                    CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                     fCondImposto.lMov,
                                                                                                     fCondImposto.lCondClifor,
                                                                                                     fCondImposto.lCondProd,
                                                                                                     fCondImposto.pSt_fisica,
                                                                                                     fCondImposto.pSt_juridica,
                                                                                                     fCondImposto.pSt_estrangeiro,
                                                                                                     null);
                                }
                                catch { }
                        //Procurar impostos sobre os itens da nota fiscal de destino
                        TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                                  cd_condfiscal_produto.Text,
                                                                                  CD_Movto.Text,
                                                                                  tp_movimento.SelectedValue.ToString(),
                                                                                  tp_pessoa,
                                                                                  CD_Empresa.Text,
                                                                                  NR_Serie.Text,
                                                                                  CD_Clifor.Text,
                                                                                  cd_unidProduto,
                                                                                  DT_Emissao.Data,
                                                                                  (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                  (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                  tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                  cd_municipioexecservico.Text,
                                                                                  null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());
                        bsNotaFiscal.ResetCurrentItem();
                        bsItensNota.ResetCurrentItem();
                    }
                }
                else
                {
                    MessageBox.Show("Falta configuração fiscal do imposto PIS para emitir NFE.\r\n" +
                                    "Imposto: PIS\r\n" +
                                    "Cond. Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                    "Cond. Fiscal Produto: " + linha["CD_CondFiscal_Produto"].ToString().Trim() + "\r\n" +
                                    "Cd. Movimentação: " + (string.IsNullOrEmpty(CD_Movto.Text) ? decimal.Zero : Convert.ToDecimal(CD_Movto.Text)) + "\r\n" +
                                    "TP. Pessoa: " + tp_pessoa.Trim().ToUpper() + "\r\n" +
                                    "TP. Movimento: " + tp_movimento.SelectedValue.ToString().Trim().ToUpper() + "\r\n" +
                                    "Cd. Empresa: " + CD_Empresa.Text.Trim() + "\r\n" +
                                    "Nº Serie: " + NR_Serie.Text.Trim() + "\r\n\r\n" +
                                    "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                    "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_pedidoitem.Clear();
                    Nr_PedidoItem.Clear();
                    CD_Produto.Clear();
                    ds_produto.Clear();
                    cd_condfiscal_produto.Clear();
                    CD_Local.Clear();
                    ds_local.Clear();
                    CD_Unidade.Clear();
                    ds_unidade.Clear();
                    sigla_unidade_estoque.Clear();
                    sigla_unidade_vl.Clear();
                    Quantidade.Value = 0;
                    Vl_Unitario.Value = 0;
                    Vl_SubTotal.Value = 0;
                    id_pedidoitem.Focus();
                    bsNotaFiscal.ResetCurrentItem();
                    bsItensNota.ResetCurrentItem();
                }
            }
            //Verificar obrigatoriedade COFINS
            if (TCN_LanFaturamento_Item.ObrigInformarCOFINS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                           (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                           bsItensNota.Current as TRegistro_LanFaturamento_Item, null))
            {
                //Verificar se o usuario tem acesso a tela de configuracao do imposto
                CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                {
                    //Buscar codigo imposto PIS
                    object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_cofins",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                    }, "a.cd_imposto");
                    //Abrir cadastro de configuracao icms
                    using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                    {
                        fCondImposto.pCd_empresa = CD_Empresa.Text;
                        fCondImposto.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                        fCondImposto.pCd_condfiscal_produto = linha["CD_CondFiscal_Produto"].ToString();
                        fCondImposto.pCd_movimentacao = CD_Movto.Text;
                        fCondImposto.pTp_faturamento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                        fCondImposto.pSt_juridica = tp_pessoa.Trim().ToUpper().Equals("J");
                        fCondImposto.pSt_fisica = tp_pessoa.Trim().ToUpper().Equals("F");
                        fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                        if (fCondImposto.ShowDialog() == DialogResult.OK)
                            if ((fCondImposto.rCond != null) &&
                            (fCondImposto.lMov != null) &&
                            (fCondImposto.lCondClifor != null) &&
                            (fCondImposto.lCondProd != null))
                                try
                                {
                                    CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                     fCondImposto.lMov,
                                                                                                     fCondImposto.lCondClifor,
                                                                                                     fCondImposto.lCondProd,
                                                                                                     fCondImposto.pSt_fisica,
                                                                                                     fCondImposto.pSt_juridica,
                                                                                                     fCondImposto.pSt_estrangeiro,
                                                                                                     null);
                                }
                                catch { }
                        //Procurar impostos sobre os itens da nota fiscal de destino
                        TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                                  cd_condfiscal_produto.Text,
                                                                                  CD_Movto.Text,
                                                                                  tp_movimento.SelectedValue.ToString(),
                                                                                  tp_pessoa,
                                                                                  CD_Empresa.Text,
                                                                                  NR_Serie.Text,
                                                                                  CD_Clifor.Text,
                                                                                  cd_unidProduto,
                                                                                  DT_Emissao.Data,
                                                                                  (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                  (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal,
                                                                                  tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                  cd_municipioexecservico.Text,
                                                                                  null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());
                        bsNotaFiscal.ResetCurrentItem();
                        bsItensNota.ResetCurrentItem();
                    }
                }
                else
                {
                    MessageBox.Show("Falta configuração fiscal do imposto COFINS para emitir NFE.\r\n" +
                                    "Imposto: COFINS\r\n" +
                                    "Cond. Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                    "Cond. Fiscal Produto: " + linha["CD_CondFiscal_Produto"].ToString().Trim() + "\r\n" +
                                    "Cd. Movimentação: " + (string.IsNullOrEmpty(CD_Movto.Text) ? decimal.Zero : Convert.ToDecimal(CD_Movto.Text)) + "\r\n" +
                                    "TP. Pessoa: " + tp_pessoa.Trim().ToUpper() + "\r\n" +
                                    "TP. Movimento: " + tp_movimento.SelectedValue.ToString().Trim().ToUpper() + "\r\n" +
                                    "Cd. Empresa: " + CD_Empresa.Text.Trim() + "\r\n" +
                                    "Nº Serie: " + NR_Serie.Text.Trim() + "\r\n\r\n" +
                                    "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                    "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_pedidoitem.Clear();
                    Nr_PedidoItem.Clear();
                    CD_Produto.Clear();
                    ds_produto.Clear();
                    cd_condfiscal_produto.Clear();
                    CD_Local.Clear();
                    ds_local.Clear();
                    CD_Unidade.Clear();
                    ds_unidade.Clear();
                    sigla_unidade_estoque.Clear();
                    sigla_unidade_vl.Clear();
                    Quantidade.Value = 0;
                    Vl_Unitario.Value = 0;
                    Vl_SubTotal.Value = 0;
                    id_pedidoitem.Focus();
                    bsNotaFiscal.ResetCurrentItem();
                    bsItensNota.ResetCurrentItem();
                }
            }
            bsItensNota.ResetCurrentItem();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|Nr.Pedido|50;" +
                              "a.nr_contrato|Nr.Contrato|50;" +
                              "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100;" +
                              "a.quantidade|Quantidade|100;" +
                              "a.vl_subtotal|Valor Tot|100;" +
                              "a.ID_PedidoItem|Id. Item|80";

            string vParamFixo = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";

            if (st_devolucao || st_retorno)
            {
                string vParamFixoDev = "a.nr_pedido|=|" + NR_Pedido.Text;// a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoDevolucao"), vParamFixoDev);
                if (linha != null)
                {
                    Nr_PedidoItem.Text = linha["nr_pedido"].ToString();
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                }
            }
            else if (st_complemento || st_compdevimposto)
            {
                string vCol = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100;" +
                              "a.nr_pedido|Nr.Pedido|50;" +
                              "a.nr_contrato|Nr.Contrato|50;" +
                              "a.ID_PedidoItem|Id. Item|80";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixo += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixo += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vCol, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"), vParamFixo);
                if (linha != null)
                {
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                    Nr_PedidoItem.Text = linha["Nr_Pedido"].ToString();
                }
            }
            else if (st_mestra)
            {
                string vParamFixoMestra = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                          "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoMestra += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoMestra += ";isnull(a.st_servico, 'N')|<>|'S'";
                if (st_confere_saldo)
                    vParamFixoMestra += ";||a.Quantidade > 0 and a.Vl_SubTotal > 0";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoMestra"), vParamFixoMestra);
                if (linha != null)
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
            }
            else if (st_simplesRemessa)
            {
                string vParamFixoDev = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                        "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoSimplesRemessa"), vParamFixoDev);
                if (linha != null)
                {
                    Nr_PedidoItem.Text = linha["nr_pedido"].ToString();
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                }
            }
            else
            {
                vParamFixo = "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto);" +
                             "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixo += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixo += ";isnull(a.st_servico, 'N')|<>|'S'";
                if (st_confere_saldo)
                    vParamFixo += ";||a.Quantidade > 0 and b.Vl_SubTotal > 0";

                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"), vParamFixo);
                if (linha != null)
                {
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                    Nr_PedidoItem.Text = linha["Nr_Pedido"].ToString();
                    cd_unidProduto = linha["cd_unes"].ToString();
                }
            }
            id_pedidoitem_Leave(this, new EventArgs());
        }

        private void cd_empresa_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa_busca.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);

        }

        private void cd_clifor_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor_busca.Text + "'"
                , new EditDefault[] { cd_clifor_busca }, new TCD_CadClifor());
        }

        private void bb_clifor_busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { cd_clifor_busca }, string.Empty);
        }

        private void cd_endereco_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_endereco_busca.Text + "';a.cd_clifor|=|'" + cd_clifor_busca.Text + "'"
                , new EditDefault[] { cd_endereco_busca }, new TCD_CadEndereco());
        }

        private void bb_endereco_busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;c.DS_UF|Estado|150;UF|UF|80"
                , new EditDefault[] { cd_endereco_busca }, new TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_clifor_busca.Text + "'");
        }

        private void nr_pedido_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|=|" + nr_pedido_busca.Text + ";" +
                              "||(isnull(a.st_pedido, 'A') in ('F', 'P'));" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                              "where x.cfg_pedido = a.cfg_pedido " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas,
               new EditDefault[] { nr_pedido_busca }, new TCD_Pedido());
        }

        private void bb_pedido_busca_Click(object sender, EventArgs e)
        {
            string vParam = "||(isnull(a.st_pedido, 'A') in ('F', 'P'));" +
                            "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                            "where x.cfg_pedido = a.cfg_pedido " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NR_Pedido|Nº Pedido|100;f.NM_Clifor|Nome|120;a.CD_Clifor|CódClifor|80"
                , new EditDefault[] { nr_pedido_busca }
                , new TCD_Pedido(), vParam);
        }

        private void cd_movto_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Movimentacao|=|'" + cd_movto_busca.Text + "'"
                , new EditDefault[] { cd_movto_busca }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void ds_movto_busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Movimentacao|Ds Movimentação|300;CD_Movimentacao|Cd.Movimentação|80"
                            , new EditDefault[] { cd_movto_busca }, new CamadaDados.Fiscal.TCD_CadMovimentacao(),
                            string.Empty);
        }

        private void nr_serie_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("nr_serie|=|'" + nr_serie_busca.Text + "'"
                , new EditDefault[] { nr_serie_busca }, new TCD_CadSerieNF());
        }

        private void bb_serie_busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nr_serie|Nº Série|80;a.DS_SerieNF|Descrição|150"
                , new EditDefault[] { nr_serie_busca }, new TCD_CadSerieNF(), null);
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Serie|Nº Série|80;" +
                              "a.DS_SerieNF|Descrição Série|350;" +
                              "a.CD_Modelo|Cód. Modelo|80;" +
                              "b.DS_Modelo|Descrição Modelo|350";
            string vParam = string.Empty;
            if (st_servico.Checked)
                vParam = "a.tp_serie|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { NR_Serie, cd_modelo, ds_modelo },
                new TCD_CadSerieNF(), vParam);
            if (linha != null)
            {
                st_sequenciaauto = linha["ST_SequenciaAuto"].ToString().Equals("S");
                Tp_serie = linha["tp_serie"].ToString();
            }
            else
                Tp_serie = string.Empty;
            habilitaCampoNumeroNota(st_sequenciaauto);
            HabilitarCampoChaveAcesso();
        }

        private void bb_Obs_busca_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("ds_ObservacaoFiscal|Observação Fiscal|300;cd_ObservacaoFiscal|Cód. Obs. Fiscal|90"
                                                       , null, new CamadaDados.Fiscal.TCD_CadObservacaoFiscal(), null);

            if (linha != null)
            {
                if (tcObsFiscal.SelectedTab.Equals(tabObs))
                    if (ds_ObservacaoFiscal.Text.Trim().Equals(string.Empty))
                        ds_ObservacaoFiscal.Text = linha["ds_observacaofiscal"].ToString();
                    else
                        ds_ObservacaoFiscal.Text += "\r\n" + linha["ds_observacaofiscal"].ToString();
                else if (tcObsFiscal.SelectedTab.Equals(tabDados))
                    if (ds_DadosAdicionais.Text.Trim().Equals(string.Empty))
                        ds_DadosAdicionais.Text = linha["ds_observacaofiscal"].ToString();
                    else
                        ds_DadosAdicionais.Text += "\r\n" + linha["ds_observacaofiscal"].ToString();
            }
        }

        private void tcFaturamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vTP_Modo == TTpModo.tm_Insert)
            {
                if (tcFaturamento.SelectedTab.Equals(tabItens))
                {
                    bbDevOutrosPed.Visible = st_devolucaocmi.Checked || cbRetorno.Checked;
                    if (pDadosNotas.validarCampoObrigatorio())
                    {
                        if (string.IsNullOrEmpty(DT_Emissao.Text.SoNumero()))
                        {
                            MessageBox.Show("Obrigatório informar DT.Emissão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => (p.Id_pedidoitemstr.Trim().Equals(id_pedidoitem.Text.Trim()) && p.Nr_pedido.ToString().Equals(Nr_PedidoItem.Text.ToString().Trim()))))
                        {
                            //Procurar outros impostos
                            TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                          cd_condfiscal_produto.Text,
                                                                          CD_Movto.Text,
                                                                          tp_movimento.SelectedValue.ToString(),
                                                                          tp_pessoa,
                                                                          CD_Empresa.Text,
                                                                          NR_Serie.Text,
                                                                          CD_Clifor.Text,
                                                                          cd_unidProduto,
                                                                          DT_Emissao.Data,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                          tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                          cd_municipioexecservico.Text,
                                                                          null), bsItensNota.Current as TRegistro_LanFaturamento_Item, tp_movimento.SelectedValue.ToString());

                            return; //se o item ja existe na nota finaliza
                        }//Buscar configuração do pedido
                        TRegistro_CadCFGPedido rCfgPedido = TCN_CadCFGPedido.BuscarRegistro(string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                (!string.IsNullOrEmpty(NR_Pedido.Text) ? Convert.ToDecimal(NR_Pedido.Text) : 0),
                                                                                                0,
                                                                                                string.Empty,
                                                                                                null);
                        if (rCfgPedido != null)
                        {
                            st_permite_pedidoparcial = rCfgPedido.St_permite_pedidoparcialbool;
                            st_confere_saldo = rCfgPedido.St_confere_saldobool;
                            st_valoresfixos = rCfgPedido.St_valoresfixosbool;
                            st_exigirconferenciaentrega = rCfgPedido.St_ExigirConferenciaEntregaBool;
                            st_atualizaprecovenda = rCfgPedido.St_atualizaprecovendabool;
                            st_geraretiqueta = rCfgPedido.St_geraretiquetabool;
                        }
                        if (st_confere_saldo)
                        {
                            if (st_complemento)
                            {
                                if ((!st_permite_pedidoparcial) && (st_confere_saldo))
                                {
                                    BB_InsereItem.Visible = ((tQtdEstPedido < tQtdPedido) || (tVlEstPedido < tVlPedido));
                                    BB_AlterarItem.Visible = ((tQtdEstPedido < tQtdPedido) || (tVlEstPedido < tVlPedido));
                                    BB_DeletaItem.Visible = ((tQtdEstPedido < tQtdPedido) || (tVlEstPedido < tVlPedido));
                                    BB_GravarItem.Visible = ((tQtdEstPedido < tQtdPedido) || (tVlEstPedido < tVlPedido));
                                }
                            }
                            else if (st_devolucao || st_retorno)
                            {
                                BB_InsereItem.Visible = true;
                                BB_AlterarItem.Visible = true;
                                BB_DeletaItem.Visible = true;
                                BB_GravarItem.Visible = true;
                            }
                            else
                            {
                                BB_InsereItem.Visible = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                                BB_AlterarItem.Visible = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                                BB_DeletaItem.Visible = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                                BB_GravarItem.Visible = ((tQtdEstPedido < tQtdPedido) && (tVlEstPedido < tVlPedido));
                            }
                        }

                        if ((!st_devolucao) && (!st_retorno) && (!st_complemento) && (!st_simplesRemessa))
                        {
                            DataTable tabela = new DataTable();
                            if (st_mestra)
                            {
                                decimal saldoQtdMestra = 0;
                                decimal saldoVlMestra = 0;
                                tabela = TCN_LanPedido_Item.BuscaSaldoMestra(NR_Pedido.Text,
                                                                             string.Empty,
                                                                             Tp_serie,
                                                                             ref saldoQtdMestra,
                                                                             ref saldoVlMestra,
                                                                             0,
                                                                             string.Empty,
                                                                             null);

                            }
                            else
                            {
                                decimal saldoQtdNFNormal = 0;
                                decimal saldoVlNFNormal = 0;
                                tabela = TCN_LanPedido_Item.BuscaSaldoNFNormal(NR_Pedido.Text,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               Tp_serie,
                                                                               ref saldoQtdNFNormal,
                                                                               ref saldoVlNFNormal,
                                                                               0,
                                                                               string.Empty,
                                                                               null);
                            }

                            if (tabela != null)
                            {
                                for (int i = 0; i < tabela.Rows.Count; i++)
                                {
                                    TRegistro_LanFaturamento_Item itensNota = new TRegistro_LanFaturamento_Item();
                                    if (!(bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => (p.Id_pedidoitemstr.Trim().Equals(tabela.Rows[i]["ID_PedidoItem"].ToString())) && p.Nr_pedido.ToString().Trim().Equals(tabela.Rows[i]["Nr_Pedido"].ToString())))
                                    {
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoSemente(tabela.Rows[i]["CD_Produto"].ToString().Trim()))
                                            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E") &&
                                            !(bsNotaFiscal.Current as TRegistro_LanFaturamento).rCmi.St_devolucaobool &&
                                            !(bsNotaFiscal.Current as TRegistro_LanFaturamento).rCmi.St_retornobool)
                                            {
                                                //Compra semente terceiro
                                                //Lote de Terceiro
                                                if (decimal.Parse(tabela.Rows[i]["Quantidade"].ToString()) > decimal.Zero)
                                                {
                                                    using (TFLotesSementes fLote = new TFLotesSementes())
                                                    {
                                                        fLote.pCd_empresa = CD_Empresa.Text;
                                                        fLote.pNm_empresa = NM_Empresa.Text;
                                                        fLote.pCd_produto = tabela.Rows[i]["cd_produto"].ToString();
                                                        fLote.pDs_produto = tabela.Rows[i]["ds_produto"].ToString();
                                                        fLote.pQtd_movimentar = decimal.Parse(tabela.Rows[i]["quantidade"].ToString());
                                                        fLote.pTp_mov = "E";
                                                        if (fLote.ShowDialog() == DialogResult.OK)
                                                            if (fLote.lMov != null)
                                                            {
                                                                itensNota.lLoteSemente.Clear();
                                                                fLote.lMov.ForEach(p => itensNota.lLoteSemente.Add(p));
                                                            }
                                                    }
                                                }
                                            }
                                            else
                                                using (Sementes.TFSaldoLoteSemente fSaldoLoteSemente = new Sementes.TFSaldoLoteSemente())
                                                {
                                                    fSaldoLoteSemente.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                                    fSaldoLoteSemente.Nm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                                                    fSaldoLoteSemente.Cd_produto = tabela.Rows[i]["CD_Produto"].ToString().Trim();
                                                    fSaldoLoteSemente.Ds_produto = tabela.Rows[i]["DS_Produto"].ToString().Trim();
                                                    fSaldoLoteSemente.Tp_mov = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento;
                                                    fSaldoLoteSemente.St_devolucao = (bsNotaFiscal.Current as TRegistro_LanFaturamento).rCmi.St_devolucaobool;
                                                    fSaldoLoteSemente.Qtd_nota = Convert.ToDecimal(Convert.ToDecimal(tabela.Rows[i]["Quantidade"].ToString()));
                                                    if (fSaldoLoteSemente.ShowDialog() == DialogResult.OK)
                                                    {
                                                        if (fSaldoLoteSemente.lLoteNf != null)
                                                        {
                                                            itensNota.lLoteSemente = fSaldoLoteSemente.lLoteNf;
                                                            itensNota.lLoteNfOrigem = fSaldoLoteSemente.lLoteNfOrigem;
                                                            fSaldoLoteSemente.lLoteNf.ForEach(p => itensNota.Observacao_item += p.Ds_obsNfItem + "\r\n");
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                }

                                        //% Desconto
                                        try
                                        {
                                            itensNota.Pc_desconto = decimal.Parse(tabela.Rows[i]["pc_desc"].ToString());
                                        }
                                        catch { itensNota.Pc_desconto = decimal.Zero; }
                                        //% Acrescimo
                                        try
                                        {
                                            itensNota.Pc_outrasdesp = decimal.Parse(tabela.Rows[i]["pc_acrescimo"].ToString());
                                        }
                                        catch { itensNota.Pc_outrasdesp = decimal.Zero; }
                                        itensNota.Vl_freteitem =
                                            TCN_LanPedido_Item.RatearFreteItemNF(tabela.Rows[i]["nr_pedido"].ToString(),
                                                                                 tabela.Rows[i]["cd_produto"].ToString(),
                                                                                 tabela.Rows[i]["id_pedidoitem"].ToString(),
                                                                                 decimal.Parse(tabela.Rows[i]["Quantidade"].ToString()),
                                                                                 null);
                                        itensNota.Id_pedidoitemstr = tabela.Rows[i]["ID_PedidoItem"].ToString();
                                        itensNota.Cd_produto = tabela.Rows[i]["CD_Produto"].ToString();
                                        itensNota.Ds_produto = tabela.Rows[i]["DS_Produto"].ToString();
                                        itensNota.Cd_condfiscal_produto = tabela.Rows[i]["CD_CondFiscal_Produto"].ToString();
                                        itensNota.Cd_local = tabela.Rows[i]["CD_Local"].ToString();
                                        itensNota.Ds_local = tabela.Rows[i]["DS_Local"].ToString();
                                        itensNota.Cd_unidade = tabela.Rows[i]["CD_UnVL"].ToString();
                                        itensNota.Nr_pedido = decimal.Parse(tabela.Rows[i]["NR_Pedido"].ToString());
                                        itensNota.Ds_unidade = tabela.Rows[i]["DS_UnVL"].ToString();
                                        itensNota.Sigla_unidade = tabela.Rows[i]["SG_UnVL"].ToString();
                                        itensNota.Cd_unidEst = tabela.Rows[i]["CD_UnES"].ToString();
                                        itensNota.Sigla_unidade_estoque = tabela.Rows[i]["SG_UnES"].ToString();
                                        itensNota.Quantidade = decimal.Parse(tabela.Rows[i]["Quantidade"].ToString());
                                        itensNota.Qtd_totalconferencia = decimal.Parse(tabela.Rows[i]["qtd_conferencia"].ToString());
                                        itensNota.Observacao_item += (string.IsNullOrEmpty(itensNota.Observacao_item) ? string.Empty : "\r\n") + tabela.Rows[i]["ds_observacaoitem"].ToString();
                                        try
                                        {
                                            itensNota.Pc_imposto_Aprox = decimal.Parse(tabela.Rows[i]["pc_imposto_aprox"].ToString());
                                        }
                                        catch { }

                                        //Procurar cfop do item
                                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(CD_Movto.Text,
                                                                                           itensNota.Cd_condfiscal_produto,
                                                                                           cd_uf_clifor.Text.Trim().Equals("99") ? "I" : cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "D" : "F",
                                                                                           tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                           tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                           tp_movimento.SelectedValue.ToString(),
                                                                                           cd_condFiscal_clifor.Text,
                                                                                           CD_Empresa.Text,
                                                                                           ref rCfop,
                                                                                           null))
                                        {
                                            if (st_devolucao && (!rCfop.St_devolucaobool))
                                            {
                                                MessageBox.Show("Permitido emitir NF-e de DEVOLUÇÃO somente utilizando CFOP de DEVOLUÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if ((!st_devolucao) && rCfop.St_devolucaobool)
                                            {
                                                MessageBox.Show("Não é permitido emitir NF-e NORMAL utilizando CFOP de DEVOLUÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (st_retorno && (!rCfop.St_retornobool))
                                            {
                                                MessageBox.Show("Permitido emitir NF-e de RETORNO somente utilizando CFOP de RETORNO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else
                                            {
                                                itensNota.Cd_cfop = rCfop.CD_CFOP;
                                                itensNota.Ds_cfop = rCfop.DS_CFOP;
                                                itensNota.St_bonificacao = rCfop.St_bonificacaobool;
                                                itensNota.St_usoconsumo = rCfop.St_usoconsumobool;
                                                itensNota.St_retorno = rCfop.St_retornobool;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Não existe CFOP " + (cd_uf_clifor.Text.Trim().Equals(cd_uf_empresa.Text.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + CD_Movto.Text + " condição fiscal do produto " + itensNota.Cd_condfiscal_produto,
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        if ((vl_cotacao.Value > 0) && (operador.Text.Trim() != string.Empty))
                                        {
                                            if (operador.Text.Trim().ToUpper().Equals("/"))
                                            {
                                                itensNota.Vl_unitario = Convert.ToDecimal(tabela.Rows[i]["Vl_Unitario"].ToString()) / vl_cotacao.Value;
                                                itensNota.Vl_subtotal = Convert.ToDecimal(tabela.Rows[i]["Vl_subTotal"].ToString()) / vl_cotacao.Value;
                                            }
                                            else if (operador.Text.Trim().ToUpper().Equals("*"))
                                            {
                                                itensNota.Vl_unitario = Convert.ToDecimal(tabela.Rows[i]["Vl_Unitario"].ToString()) * vl_cotacao.Value;
                                                itensNota.Vl_subtotal = Convert.ToDecimal(tabela.Rows[i]["Vl_subTotal"].ToString()) * vl_cotacao.Value;
                                            }
                                        }
                                        else
                                        {
                                            itensNota.Vl_unitario = Convert.ToDecimal(tabela.Rows[i]["Vl_Unitario"].ToString());
                                            itensNota.Vl_subtotal = Convert.ToDecimal(tabela.Rows[i]["Vl_subTotal"].ToString());
                                        }
                                        if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("S"))
                                            //Calcular valor juro financeiro
                                            itensNota.Vl_juro_fin = TCN_CadCondPgto.CalcularValorJuroFin(
                                                                                                        new TRegistro_CadCondPgto()
                                                                                                        {
                                                                                                            Pc_jurodiario_atrazoFin = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo,
                                                                                                            Tp_juro_fin = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro,
                                                                                                            Qt_diasdesdobro = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro,
                                                                                                            St_comentradabool = (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada,
                                                                                                            Qt_parcelas = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas
                                                                                                        }, itensNota.Vl_subtotal);
                                        string vObsFiscal = string.Empty;
                                        //Procurar impostos estaduais
                                        TList_ImpostosNF lImpostos =
                                            TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                         tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                         tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                         CD_Movto.Text,
                                                                                         tp_movimento.SelectedValue.ToString(),
                                                                                         cd_condFiscal_clifor.Text,
                                                                                         tabela.Rows[i]["CD_CondFiscal_Produto"].ToString(),
                                                                                         operador.Text.Trim().ToUpper().Equals("/") ?
                                                                                         itensNota.Vl_basecalcImposto / vl_cotacao.Value :
                                                                                         operador.Text.Trim().ToUpper().Equals("*") ?
                                                                                         itensNota.Vl_basecalcImposto * vl_cotacao.Value :
                                                                                         itensNota.Vl_basecalcImposto,
                                                                                         Convert.ToDecimal(tabela.Rows[i]["quantidade"].ToString()),
                                                                                         ref vObsFiscal,
                                                                                         DT_Emissao.Data,
                                                                                         tabela.Rows[i]["cd_produto"].ToString(),
                                                                                         tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                         NR_Serie.Text,
                                                                                         null);
                                        if (lImpostos.Exists(v => v.Imposto.St_ICMS))
                                        {
                                            TCN_LanFaturamento_Item.PreencherICMS(lImpostos.Find(v => v.Imposto.St_ICMS), itensNota);
                                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal : "\r\n" + vObsFiscal;
                                        }
                                        else if (TCN_LanFaturamento_Item.ObrigImformarICMS(itensNota.Cd_produto, (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie, null))
                                        {
                                            CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondFiscalICMS");
                                            if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                                            {
                                                //Abrir cadastro de configuracao icms
                                                using (TFCondFiscalICMS fCondICMS = new TFCondFiscalICMS())
                                                {
                                                    fCondICMS.pCd_empresa = CD_Empresa.Text;
                                                    fCondICMS.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                                                    fCondICMS.pCd_condfiscal_produto = tabela.Rows[i]["CD_CondFiscal_Produto"].ToString();
                                                    fCondICMS.pCd_movto = CD_Movto.Text;
                                                    fCondICMS.pCd_UfDest = (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text);
                                                    fCondICMS.pCd_UfOrig = (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text);
                                                    fCondICMS.pTp_movimento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                                                    if (fCondICMS.ShowDialog() == DialogResult.OK)
                                                        if ((fCondICMS.rCond != null) &&
                                                            (fCondICMS.lMov != null) &&
                                                            (fCondICMS.lUfDestino != null) &&
                                                            (fCondICMS.lUfOrigem != null))
                                                            try
                                                            {
                                                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                                                                  fCondICMS.lMov,
                                                                                                                  fCondICMS.lUfOrigem,
                                                                                                                  fCondICMS.lUfDestino,
                                                                                                                  null);
                                                            }
                                                            catch { }
                                                    //Verificar se a configuracao foi feita
                                                    TList_ImpostosNF impostosNFs =
                                                    TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                                                                tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text,
                                                                                                tp_movimento.SelectedValue.ToString().Trim().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text,
                                                                                                CD_Movto.Text,
                                                                                                tp_movimento.SelectedValue.ToString(),
                                                                                                cd_condFiscal_clifor.Text,
                                                                                                tabela.Rows[i]["CD_CondFiscal_Produto"].ToString(),
                                                                                                operador.Text.Trim().ToUpper().Equals("/") ?
                                                                                                itensNota.Vl_basecalcImposto / vl_cotacao.Value :
                                                                                                operador.Text.Trim().ToUpper().Equals("*") ?
                                                                                                itensNota.Vl_basecalcImposto * vl_cotacao.Value :
                                                                                                itensNota.Vl_basecalcImposto,
                                                                                                Convert.ToDecimal(tabela.Rows[i]["quantidade"].ToString()),
                                                                                                ref vObsFiscal,
                                                                                                DT_Emissao.Data,
                                                                                                tabela.Rows[i]["cd_produto"].ToString(),
                                                                                                tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                                NR_Serie.Text,
                                                                                                null);
                                                    if (impostosNFs.Exists(x => x.Imposto.St_ICMS))
                                                        TCN_LanFaturamento_Item.PreencherICMS(impostosNFs.Find(v => v.Imposto.St_ICMS), itensNota);

                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Não existe condição fiscal para: \r\n" +
                                                                "Tipo Movimento: " + tp_movimento.Text.Trim() + "\r\n" +
                                                                "Movimentação Comercial: " + CD_Movto.Text.Trim() + " - " + DS_Movto.Text.Trim() + "\r\n" +
                                                                "Condição Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                                                "Condição Fiscal Produto: " + tabela.Rows[i]["CD_CondFiscal_Produto"].ToString() + "\r\n" +
                                                                "UF Origem: " + (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text) + "\r\n" +
                                                                "UF Destino: " + (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal : "\r\n" + vObsFiscal;
                                        //Procurar outros impostos
                                        TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                                                  tabela.Rows[i]["CD_CondFiscal_Produto"].ToString(),
                                                                                                  CD_Movto.Text,
                                                                                                  tp_movimento.SelectedValue.ToString().Trim(),
                                                                                                  tp_pessoa.Trim(),
                                                                                                  CD_Empresa.Text,
                                                                                                  NR_Serie.Text,
                                                                                                  CD_Clifor.Text,
                                                                                                  cd_unidProduto,
                                                                                                  Convert.ToDateTime(DT_Emissao.Text),
                                                                                                  itensNota.Quantidade,
                                                                                                  itensNota.Vl_basecalcImposto,
                                                                                                  tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                                  cd_municipioexecservico.Text,
                                                                                                  null), itensNota, tp_movimento.SelectedValue.ToString());
                                        //Verificar obrigatoriedade PIS
                                        if (TCN_LanFaturamento_Item.ObrigInformarPIS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                     (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                     (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                     (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                                                     itensNota.Cd_produto,
                                                                                     itensNota,
                                                                                     null))
                                        {
                                            //Verificar se o usuario tem acesso a tela de configuracao do imposto
                                            CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                                            if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                                            {
                                                //Buscar codigo imposto PIS
                                                object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                                                new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.st_pis",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "0"
                                                                            }
                                                                        }, "a.cd_imposto");
                                                //Abrir cadastro de configuracao icms
                                                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                                                {
                                                    fCondImposto.pCd_empresa = CD_Empresa.Text;
                                                    fCondImposto.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                                                    fCondImposto.pCd_condfiscal_produto = tabela.Rows[i]["CD_CondFiscal_Produto"].ToString();
                                                    fCondImposto.pCd_movimentacao = CD_Movto.Text;
                                                    fCondImposto.pTp_faturamento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                                                    fCondImposto.pSt_juridica = tp_pessoa.Trim().ToUpper().Equals("J");
                                                    fCondImposto.pSt_fisica = tp_pessoa.Trim().ToUpper().Equals("F");
                                                    fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                                                    if (fCondImposto.ShowDialog() == DialogResult.OK)
                                                        if ((fCondImposto.rCond != null) &&
                                                        (fCondImposto.lMov != null) &&
                                                        (fCondImposto.lCondClifor != null) &&
                                                        (fCondImposto.lCondProd != null))
                                                            try
                                                            {
                                                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                                                 fCondImposto.lMov,
                                                                                                                                 fCondImposto.lCondClifor,
                                                                                                                                 fCondImposto.lCondProd,
                                                                                                                                 fCondImposto.pSt_fisica,
                                                                                                                                 fCondImposto.pSt_juridica,
                                                                                                                                 fCondImposto.pSt_estrangeiro,
                                                                                                                                 null);
                                                            }
                                                            catch { }
                                                    //Verificar se a configuracao foi feita
                                                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                                        TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                                                              tabela.Rows[i]["CD_CondFiscal_Produto"].ToString(),
                                                                                                              CD_Movto.Text,
                                                                                                              tp_movimento.SelectedValue.ToString().Trim(),
                                                                                                              tp_pessoa.Trim(),
                                                                                                              CD_Empresa.Text,
                                                                                                              NR_Serie.Text,
                                                                                                              CD_Clifor.Text,
                                                                                                              cd_unidProduto,
                                                                                                              Convert.ToDateTime(DT_Emissao.Text),
                                                                                                              itensNota.Quantidade,
                                                                                                              itensNota.Vl_basecalcImposto,
                                                                                                              tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                                              cd_municipioexecservico.Text,
                                                                                                              null), itensNota, tp_movimento.SelectedValue.ToString());
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Falta configuração fiscal do imposto PIS para emitir NFE.\r\n" +
                                                                "Imposto: PIS\r\n" +
                                                                "Cond. Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                                                "Cond. Fiscal Produto: " + tabela.Rows[i]["CD_CondFiscal_Produto"].ToString().Trim() + "\r\n" +
                                                                "Cd. Movimentação: " + (string.IsNullOrEmpty(CD_Movto.Text) ? decimal.Zero : Convert.ToDecimal(CD_Movto.Text)) + "\r\n" +
                                                                "TP. Pessoa: " + tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                                "TP. Movimento: " + tp_movimento.SelectedValue.ToString().Trim().ToUpper() + "\r\n" +
                                                                "Cd. Empresa: " + CD_Empresa.Text.Trim() + "\r\n" +
                                                                "Nº Serie: " + NR_Serie.Text.Trim() + "\r\n\r\n" +
                                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        //Verificar obrigatoriedade COFINS
                                        if (TCN_LanFaturamento_Item.ObrigInformarCOFINS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                                                        itensNota.Cd_produto,
                                                                                        itensNota,
                                                                                        null))
                                        {
                                            //Verificar se o usuario tem acesso a tela de configuracao do imposto
                                            CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                                            if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                                            {
                                                //Buscar codigo imposto PIS
                                                object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                                                new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.st_cofins",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "0"
                                                                            }
                                                                        }, "a.cd_imposto");
                                                //Abrir cadastro de configuracao icms
                                                using (TFCondFiscalImposto fCondImposto = new TFCondFiscalImposto())
                                                {
                                                    fCondImposto.pCd_empresa = CD_Empresa.Text;
                                                    fCondImposto.pCd_condfiscal_clifor = cd_condFiscal_clifor.Text;
                                                    fCondImposto.pCd_condfiscal_produto = tabela.Rows[i]["CD_CondFiscal_Produto"].ToString();
                                                    fCondImposto.pCd_movimentacao = CD_Movto.Text;
                                                    fCondImposto.pTp_faturamento = tp_movimento.SelectedValue.ToString().Trim().ToUpper();
                                                    fCondImposto.pSt_juridica = tp_pessoa.Trim().ToUpper().Equals("J");
                                                    fCondImposto.pSt_fisica = tp_pessoa.Trim().ToUpper().Equals("F");
                                                    fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                                                    if (fCondImposto.ShowDialog() == DialogResult.OK)
                                                        if ((fCondImposto.rCond != null) &&
                                                        (fCondImposto.lMov != null) &&
                                                        (fCondImposto.lCondClifor != null) &&
                                                        (fCondImposto.lCondProd != null))
                                                            try
                                                            {
                                                                CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                                                 fCondImposto.lMov,
                                                                                                                                 fCondImposto.lCondClifor,
                                                                                                                                 fCondImposto.lCondProd,
                                                                                                                                 fCondImposto.pSt_fisica,
                                                                                                                                 fCondImposto.pSt_juridica,
                                                                                                                                 fCondImposto.pSt_estrangeiro,
                                                                                                                                 null);
                                                            }
                                                            catch { }
                                                    //Verificar se a configuracao foi feita
                                                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                                        TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(cd_condFiscal_clifor.Text,
                                                                                                              tabela.Rows[i]["CD_CondFiscal_Produto"].ToString(),
                                                                                                              CD_Movto.Text,
                                                                                                              tp_movimento.SelectedValue.ToString().Trim(),
                                                                                                              tp_pessoa.Trim(),
                                                                                                              CD_Empresa.Text,
                                                                                                              NR_Serie.Text,
                                                                                                              CD_Clifor.Text,
                                                                                                              cd_unidProduto,
                                                                                                              Convert.ToDateTime(DT_Emissao.Text),
                                                                                                              itensNota.Quantidade,
                                                                                                              itensNota.Vl_basecalcImposto,
                                                                                                              tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                                                                              cd_municipioexecservico.Text,
                                                                                                              null), itensNota, tp_movimento.SelectedValue.ToString());
                                                }
                                            }
                                            else
                                                MessageBox.Show("Falta configuração fiscal do imposto COFINS para emitir NFE.\r\n" +
                                                                "Imposto: COFINS\r\n" +
                                                                "Cond. Fiscal Clifor: " + cd_condFiscal_clifor.Text.Trim() + "\r\n" +
                                                                "Cond. Fiscal Produto: " + tabela.Rows[i]["CD_CondFiscal_Produto"].ToString().Trim() + "\r\n" +
                                                                "Cd. Movimentação: " + (string.IsNullOrEmpty(CD_Movto.Text) ? decimal.Zero : Convert.ToDecimal(CD_Movto.Text)) + "\r\n" +
                                                                "TP. Pessoa: " + tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                                "TP. Movimento: " + tp_movimento.SelectedValue.ToString().Trim().ToUpper() + "\r\n" +
                                                                "Cd. Empresa: " + CD_Empresa.Text.Trim() + "\r\n" +
                                                                "Nº Serie: " + NR_Serie.Text.Trim() + "\r\n\r\n" +
                                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Add(itensNota);
                                        bsNotaFiscal.ResetCurrentItem();
                                        //cfop de importacao
                                        if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_cfop.StartsWith("3"))
                                            using (TFDeclaracaoImport tdi = new TFDeclaracaoImport())
                                            {
                                                if (tdi.ShowDialog() == DialogResult.OK)
                                                    if (tdi.rDi != null)
                                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).ldi.Add(tdi.rDi);
                                            }
                                    }
                                }
                                //Totalizar Nota
                                TotalizarNota();
                                bsItensNota.ResetBindings(true);
                                BB_AlterarItem.Visible = true;
                                BB_InsereItem.Visible = st_permite_pedidoparcial;
                                BB_DeletaItem.Visible = st_permite_pedidoparcial;
                                BB_GravarItem.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Necessário informar dados obrigatorios da nota fiscal para lançar itens!");
                        tcFaturamento.SelectedTab = tabLancamento;
                    }
                }
            }
        }

        private void CD_CMI_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CMI|=|'" + CD_CMI.Text + "';" +
                              "f.CD_Movimentacao|=|'" + CD_Movto.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_CMI, tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Fiscal.TCD_CadCMI("SqlCodeBuscaCMI_X_MOV"));
            if (linha != null)
            {
                if (bsNotaFiscal.Current != null)
                {
                    //Preencher CMI Nota
                    TCN_LanFaturamento_CMI.PreencherCMINota(bsNotaFiscal.Current as TRegistro_LanFaturamento, null);
                    bsNotaFiscal.ResetCurrentItem();
                }
                if (CD_CondPGTO.Text.Trim().Equals(string.Empty))
                {
                    CD_CondPGTO.Text = linha["CD_CondPgto"].ToString();
                    DS_CondPgto.Text = linha["DS_CondPgto"].ToString();
                    if (bsNotaFiscal.Current != null)
                    {
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = decimal.Zero;
                        }
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = decimal.Zero;
                        }
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S");
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_juro_fin = linha["CD_Juro_Fin"].ToString();
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_juro_fin = linha["DS_Juro_Fin"].ToString();
                        try
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = Convert.ToDecimal(linha["pc_jurodiario_atrazo"].ToString());
                        }
                        catch
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = decimal.Zero;
                        }
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro = linha["TP_Juro"].ToString();
                        bsNotaFiscal.ResetCurrentItem();
                    }
                }
                st_devolucao = linha["ST_Devolucao"].ToString().Trim().Equals("S");
                st_retorno = linha["ST_Retorno"].ToString().Trim().Equals("S");
                st_complemento = linha["ST_Complementar"].ToString().Trim().Equals("S");
                st_compdevimposto = linha["ST_CompDevImposto"].ToString().Trim().Equals("S");
                st_mestra = linha["ST_Mestra"].ToString().Trim().Equals("S");
                st_simplesRemessa = linha["ST_SimplesRemessa"].ToString().Trim().Equals("S");
                st_gerarEstoque = linha["ST_GeraEstoque"].ToString().Trim().Equals("S");
                CD_CondPGTO.Enabled = !string.IsNullOrEmpty(linha["tp_duplicata"].ToString());
                BB_CondPgto.Enabled = CD_CondPGTO.Enabled;
            }
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit))
                if (tp_movimento.SelectedValue != null)
                {
                    tp_nota.SelectedIndex = TCN_LanFaturamento.validarST_Nota(tp_movimento.SelectedValue.ToString().Trim(), tp_pessoa, st_equiparado_pj, st_equiparado_pf);
                    habilitaCampoNumeroNota(st_sequenciaauto);
                    labelSaiEnt.Text = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? "Data Entrada:" : "Data Saida:";
                    //Buscar movimentacao
                    if (NR_Pedido.Text.Trim() != "")
                    {
                        if (string.IsNullOrEmpty(vTp_NFFiscal))
                            vTp_NFFiscal = "'NO'";
                        DataTable dt_fiscal = new TCD_CadCFGPedidoFiscal().Buscar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                "where x.cfg_pedido = a.cfg_pedido "+
                                                "and x.nr_pedido = "+NR_Pedido.Text+")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "d.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'"+tp_movimento.SelectedValue.ToString().Trim()+"'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "in",
                                    vVL_Busca = "(" + vTp_NFFiscal + ")"
                                }
                            }, 1, string.Empty);
                        if (dt_fiscal.Rows.Count > 0)
                        {
                            CD_Movto.Text = dt_fiscal.Rows[0]["cd_movto"].ToString();
                            DS_Movto.Text = dt_fiscal.Rows[0]["ds_movimentacao"].ToString();
                            if (UF_EMPRESA.Text != UF_Cliente.Text)
                            {
                                ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(dt_fiscal.Rows[0]["DS_ObsFiscal_ForaEstado"].ToString())) ? "," : string.Empty + dt_fiscal.Rows[0]["DS_ObsFiscal_ForaEstado"].ToString();
                                ds_DadosAdicionais.Text = dt_fiscal.Rows[0]["DS_DadosAdic_ForaEstado"].ToString();
                            }
                            else
                            {
                                ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(dt_fiscal.Rows[0]["DS_DadosAdic_DentroEstado"].ToString())) ? "," : string.Empty + dt_fiscal.Rows[0]["DS_DadosAdic_DentroEstado"].ToString();
                                ds_DadosAdicionais.Text = dt_fiscal.Rows[0]["DS_DadosAdic_DentroEstado"].ToString();
                            }
                            CD_CMI.Text = dt_fiscal.Rows[0]["cd_cmi"].ToString();
                            CD_CMI_Leave(this, new EventArgs());
                            tp_duplicata.Text = dt_fiscal.Rows[0]["TP_Duplicata"].ToString();
                            ds_tpduplicata.Text = dt_fiscal.Rows[0]["DS_TPDuplicata"].ToString();
                        }
                    }
                    HabilitarCampoChaveAcesso();
                    if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S") &&
                        cd_uf_clifor.Text.Trim().Equals("99"))
                        if (!tcDetalhe.TabPages.Contains(tpEx))
                            tcDetalhe.TabPages.Add(tpEx);
                }
        }

        private void tp_nota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_nota.SelectedValue != null)
                if (tp_nota.SelectedValue.ToString().Trim().Equals("P"))
                {
                    DT_Emissao.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss");
                    DT_SaiEnt.Text = DT_Emissao.Text;
                }
            habilitaCampoNumeroNota(st_sequenciaauto);
            HabilitarCampoChaveAcesso();
        }

        private void BB_InsereItem_Click(object sender, EventArgs e)
        {
            afterIncluiItensNF();
        }

        private void BB_CancelaItem_Click(object sender, EventArgs e)
        {
            bsItensNota.RemoveCurrent();
            pItensNota.HabilitarControls(false, TTpModo.tm_Standby);
        }

        private void BB_DeletaItem_Click(object sender, EventArgs e)
        {
            afterExcluiItensNF();
        }

        private void BB_AlterarItem_Click(object sender, EventArgs e)
        {
            afterAlteraItensNF();
        }

        private void BB_GravarItem_Click(object sender, EventArgs e)
        {
            afterGravaItensNF();
        }

        private void QuantidadeItem_Leave(object sender, EventArgs e)
        {
            calcSubTotal();
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            calcSubTotal();
        }

        private void Vl_SubTotal_Leave(object sender, EventArgs e)
        {
            calcSubTotal();
        }

        private void NR_NotaFiscal_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(NR_NotaFiscal.Text)) && vTP_Modo.Equals(TTpModo.tm_Insert))
                NotaFiscalExiste();
        }

        private void Vl_SubTotal_ValueChanged(object sender, EventArgs e)
        {
            if ((bsItensNota.Count > 0) && ((vTP_ModoItem == TTpModo.tm_Insert) || (vTP_ModoItem == TTpModo.tm_Edit)))
            {
                string vObsFiscal = string.Empty;
                TList_ImpostosNF impostosNF =
                TCN_LanFaturamento_Item.procuraImpostosPorUf(CD_Empresa.Text,
                                                             (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_clifor.Text : cd_uf_empresa.Text),
                                                             (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? cd_uf_empresa.Text : cd_uf_clifor.Text),
                                                             CD_Movto.Text,
                                                             tp_movimento.SelectedValue.ToString(),
                                                             cd_condFiscal_clifor.Text,
                                                             cd_condfiscal_produto.Text,
                                                             (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                             (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                             ref vObsFiscal,
                                                             DT_Emissao.Data,
                                                             CD_Produto.Text,
                                                             tp_nota.SelectedValue != null ? tp_nota.SelectedValue.ToString() : string.Empty,
                                                             NR_Serie.Text,
                                                             null);
                if (impostosNF.Exists(p => p.Imposto.St_ICMS))
                    TCN_LanFaturamento_Item.PreencherICMS(impostosNF.Find(p => p.Imposto.St_ICMS), bsItensNota.Current as TRegistro_LanFaturamento_Item);
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal : "\r\n" + vObsFiscal;
            }
        }

        private void TFLanFaturamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.F9) && BB_InsereItem.Enabled)
                afterIncluiItensNF();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && BB_AlterarItem.Enabled)
                afterAlteraItensNF();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && BB_GravarItem.Enabled)
                afterGravaItensNF();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && BB_DeletaItem.Enabled)
                afterExcluiItensNF();
            else if (e.KeyCode.Equals(Keys.F8) && BB_Imprimir.Visible)
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9) && bb_reprocessa.Visible)
                ReprocessarFiscal();
            else if (e.KeyCode.Equals(Keys.F10) && bb_reprocessaest.Visible)
                ReprocessarEstoque();
            else if (e.KeyCode.Equals(Keys.F11) && bb_corrigirnf.Visible)
                CorrigirNota();
            else if (e.KeyCode.Equals(Keys.F12))
                ManifestoNFe();
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void bb_cd_produto_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_produto_busca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), "");
        }

        private void cd_produto_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + cd_produto_busca.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { cd_produto_busca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void rgTodasNotas_CheckedChanged(object sender, EventArgs e)
        {
            if (rgTodasNotas.Checked)
            {
                qtd_notas.Value = 0;
                qtd_notas.Enabled = false;
            }
        }

        private void rgSomente_CheckedChanged(object sender, EventArgs e)
        {
            if (rgSomente.Checked)
            {
                qtd_notas.Enabled = true;
                qtd_notas.Value = 15;
            }
        }

        private void bb_cmi_busca_Click(object sender, EventArgs e)
        {
            string vParamFixo = "";
            if (cbEntrada.Checked)
                vParamFixo = "a.TP_Movimento|=|'E'";
            else if (cbSaida.Checked)
                vParamFixo = "a.TP_Movimento|=|'S'";
            if (cd_movto_busca.Text.Trim() != "")
                vParamFixo += ";|EXISTS|(Select 1 From TB_FIS_Mov_X_CMI x Where x.CD_CMI = a.CD_CMI and x.CD_Movimentacao = " + cd_movto_busca.Text + ")";
            UtilPesquisa.BTN_BUSCA("DS_CMI|Ds. CMI|300;CD_CMI|Cd. CMI|80"
                            , new EditDefault[] { cd_cmi_busca }, new CamadaDados.Fiscal.TCD_CadCMI(),
                            vParamFixo);
        }

        private void cd_cmi_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CD_CMI|=|" + cd_cmi_busca.Text;
            if (cbEntrada.Checked)
                vParam += ";a.TP_Movimento|=|'E'";
            else if (cbSaida.Checked)
                vParam += ";a.TP_Movimento|=|'S'";
            if (cd_movto_busca.Text.Trim() != "")
                vParam += ";|EXISTS|(Select 1 From TB_FIS_Mov_X_CMI x Where x.CD_CMI = a.CD_CMI and x.CD_Movimentacao = " + cd_movto_busca.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_cmi_busca }, new CamadaDados.Fiscal.TCD_CadCMI());
        }

        private void bb_cfop_busca_Click(object sender, EventArgs e)
        {
            string vParamFixo = string.Empty;
            if (!string.IsNullOrEmpty(cd_movto_busca.Text))
                vParamFixo = "|EXISTS|(Select 1 From TB_FIS_Movimentacao x Where ((x.CD_CFOP_DentroEstado = a.CD_CFOP)OR " +
                             "(x.CD_CFOP_ForaEstado = a.CD_CFOP)) and x.CD_Movimentacao = " + cd_movto_busca.Text + ")";
            UtilPesquisa.BTN_BUSCA("DS_CFOP|Descrição CFOP|300;CD_CFOP|Cd. CFOP|80", new EditDefault[] { cd_cfop_busca },
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), vParamFixo);
        }

        private void cd_cfop_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_CFOP|=|'" + cd_cfop_busca.Text + "'";
            if (!string.IsNullOrEmpty(cd_movto_busca.Text))
                vParam += ";|EXISTS|(Select 1 From TB_FIS_Movimentacao x Where ((x.CD_CFOP_DentroEstado = a.CD_CFOP)OR " +
                          "(x.CD_CFOP_ForaEstado = a.CD_CFOP)) and x.CD_Movimentacao = " + cd_movto_busca.Text + ")";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_cfop_busca }, new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void TFLanFaturamento_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gEstoque);
            ShapeGrid.RestoreShape(this, gItensNf);
            ShapeGrid.RestoreShape(this, gItensNota);
            ShapeGrid.RestoreShape(this, gNotaFiscal);
            ShapeGrid.RestoreShape(this, gParcelas);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, dataGridDefault4);
            dsDeducao.CharacterCasing = CharacterCasing.Normal;
            barraMenu.Visible = true;
            TS_ItensPedido.Visible = true;
            menuItem.Visible = true;
            bindingNavigator6.Visible = true;
            bindingNavigator7.Visible = true;
            bindingNavigator9.Visible = true;
            bnNotaFiscal.Visible = true;
            bnItensNF.Visible = true;
            if (tcDetalhe.TabPages.Contains(tpEx))
                tcDetalhe.TabPages.Remove(tpEx);
            status.SelectedIndex = 0;
            qtd_notas.Value = Utils.Parametros.pubTopMax > 0 ? Utils.Parametros.pubTopMax : 15;
            menuItem.Visible = true;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bb_reprocessa.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR REPROCESSAR FISCAL NF", null);
            bb_reprocessaest.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR REPROCESSAR ESTOQUE NF", null);
            bb_corrigirnf.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CORRIGIR NF", null);
            if (!string.IsNullOrEmpty(Nr_pedidoFaturar))
            {
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;
                afterNovo();
                NR_Pedido.Text = Nr_pedidoFaturar.Trim();
                NR_Pedido_Leave(this, new EventArgs());
                if (!NR_NotaFiscal.Focus())
                    DT_Emissao.Focus();
                if (!string.IsNullOrEmpty(vTp_movimento))
                {
                    tp_movimento.SelectedValue = vTp_movimento;
                    tp_movimento_SelectedIndexChanged(this, new EventArgs());
                    tp_movimento_Leave(this, new EventArgs());
                }
                BB_Fechar.Visible = false;
            }
        }

        private void DT_Emissao_Enter(object sender, EventArgs e)
        {
            DT_Emissao.Select(0, DT_Emissao.Text.Length);
        }

        private void DT_SaiEnt_Enter(object sender, EventArgs e)
        {
            DT_SaiEnt.Select(0, DT_SaiEnt.Text.Length);
        }

        private void CD_CMI_Enter(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(NR_Pedido.Text)) &&
                (!string.IsNullOrEmpty(CD_Movto.Text)))
            {
                TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                        "where x.cfg_pedido = a.cfg_pedido "+
                                        "and x.nr_pedido = "+NR_Pedido.Text+")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_movto",
                            vOperador = "=",
                            vVL_Busca = "'"+CD_Movto.Text.Trim()+"'"
                        }
                    }, 1, string.Empty);
                if (lPedFiscal.Count > 0)
                    CD_CMI.Text = lPedFiscal[0].Cd_cmistring;
            }
        }

        private void NR_Serie_Enter(object sender, EventArgs e)
        {
            if ((NR_Pedido.Text.Trim() != "") &&
                (CD_Movto.Text.Trim() != "") &&
                (CD_CMI.Text.Trim() != ""))
            {
                TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                        "where x.cfg_pedido = a.cfg_pedido "+
                                        "and x.nr_pedido = "+NR_Pedido.Text+")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_movto",
                            vOperador = "=",
                            vVL_Busca = "'"+CD_Movto.Text.Trim()+"'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_cmi",
                            vOperador = "=",
                            vVL_Busca = CD_CMI.Text
                        }
                    }, 1, "");
                if (lPedFiscal.Count > 0)
                {
                    NR_Serie.Text = lPedFiscal[0].Nr_serie;
                    cd_modelo.Text = lPedFiscal[0].Cd_modelo;
                    ds_modelo.Text = lPedFiscal[0].Ds_modelo;
                }
            }
        }

        private void DT_Emissao_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DT_SaiEnt.Text.SoNumero()))
                DT_SaiEnt.Text = DT_Emissao.Text;
            BuscarCotacao();
        }

        private void bsNotaFiscal_PositionChanged(object sender, EventArgs e)
        {
            if (bsNotaFiscal.Current != null)
            {
                if (((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() != string.Empty) &&
                    ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal > 0))
                {
                    //Buscar itens da nota fiscal
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Count <= 0)
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota =
                            TCN_LanFaturamento_Item.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                          string.Empty,
                                                          null);
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).lEstoqueNf.Count <= 0)
                        //Buscar estoque da nf
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).lEstoqueNf =
                            new CamadaDados.Estoque.TCD_LanEstoque().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x "+
                                                "where x.cd_empresa = a.cd_empresa "+
                                                "and x.cd_produto = a.cd_produto "+
                                                "and x.id_lanctoestoque = a.id_lanctoestoque "+
                                                "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cminf.Count <= 0)
                        //Buscar CMI da Nota
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cminf =
                            TCN_LanFaturamento_CMI.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                         (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                         0,
                                                         string.Empty,
                                                         null);
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).lEventoNFe.Count <= 0)
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).lEventoNFe =
                            CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                               (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);
                    tot_basecalc.Value = TCN_LanFaturamento.CalcTotalBaseCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_icms.Value = TCN_LanFaturamento.CalcTotalICMS(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_icmssubst.Value = TCN_LanFaturamento.CalcTotalICMSSubst(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_fcpst.Value = TCN_LanFaturamento.CalcTotalFCPST(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_ipi.Value = TCN_LanFaturamento.CalcTotalIPI(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_impcalc.Value = TCN_LanFaturamento.CalcTotalImpCalc(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_impretido.Value = TCN_LanFaturamento.CalcTotalImpRet(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    tot_impostos.Value = tot_impcalc.Value + tot_impretido.Value;
                    bsNotaFiscal.ResetCurrentItem();
                    bsItensNota_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void tList_RegLanFaturamentoDataGridDefault_DoubleClick(object sender, EventArgs e)
        {
            if (bsNotaFiscal.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.bsNotaFiscal.Add(bsNotaFiscal.Current as TRegistro_LanFaturamento);
                    fRastrear.TRastrear = TP_Rastrear.tm_nf;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void duplicataDataGridDefault_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("C"))
                    {
                        DataGridViewRow linha = duplicataDataGridDefault.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = duplicataDataGridDefault.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void Imprime_Danfe(string Documento,
                                   bool St_imprimir,
                                   bool St_visualizar,
                                   bool St_enviaremail,
                                   bool St_exportPdf,
                                   string Path_exportPdf,
                                   List<string> Destinatarios,
                                   List<string> Anexos,
                                   string Titulo,
                                   string Mensagem)
        {
            Relatorio Danfe = new Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v => v.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v => v.Vl_icms + v.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v => v.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v => v.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v => v.Vl_ICMSST + v.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
            //Buscar financeiro da DANFE
            TList_RegLanParcela lParc =
                new TCD_LanParcela().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                lParc =
                    new TCD_LanParcela().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count == 0)
                {
                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                    lParc =
                        new TCD_LanParcela().Select(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
                if(lParc.Count == 0 &&
                    new TCD_LanFaturamento_CMI().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'" },
                            new TpBusca{ vNM_Campo = "a.nr_lanctofiscal", vOperador = "=", vVL_Busca = rNfe.Nr_lanctofiscalstr },
                            new TpBusca{ vNM_Campo = "isnull(a.st_devolucao, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                            new TpBusca{ vNM_Campo = "isnull(a.st_complementar, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                            new TpBusca{ vNM_Campo = "isnull(a.st_simplesremessa, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                            new TpBusca{ vNM_Campo = "isnull(a.st_compdevimposto, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                            new TpBusca{ vNM_Campo = "isnull(a.st_remessatransp, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                            new TpBusca{ vNM_Campo = "isnull(a.st_retorno, 'N')", vOperador = "<>", vVL_Busca = "'S'" }

                        }, "1") != null)
                {
                    //Verificar se pedido de origem gerou financeiro
                    lParc = new TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca{ vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'L'" },
                            new TpBusca
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.nr_pedido = " + rNfe.Nr_pedidostring + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
            }
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio(Documento,
                                 St_imprimir,
                                 St_visualizar,
                                 St_enviaremail,
                                 St_exportPdf,
                                 Path_exportPdf,
                                 Destinatarios,
                                 Anexos,
                                 Titulo,
                                 Mensagem);
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                        bool St_imprimir,
                                        bool St_visualizar,
                                        bool St_enviaremail,
                                        List<string> Destinatarios,
                                        string Titulo,
                                        string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }

        private void bsItensNota_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (bsItensNota.Current != null)
                cd_unidProduto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidEst;
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150"
                                , new EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'");
        }

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + "';a.cd_clifor|=|'" + CD_Transp.Text.Trim() + "'"
                , new EditDefault[] { cd_enderecotransp, ds_enderecotransp }, new TCD_CadEndereco());
        }

        private void id_pedidoitem_Leave(object sender, EventArgs e)
        {
            if (id_pedidoitem.Text.Trim() != string.Empty)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => (p.Id_pedidoitemstr.Trim().Equals(id_pedidoitem.Text.Trim())) && p.Nr_pedido.ToString().Trim().Equals(Nr_PedidoItem.Text.ToString().Trim())))
                {
                    id_pedidoitem.Clear();
                    return;
                }
                else
                {
                    string vColunas = "a.id_pedidoitem|=|'" + id_pedidoitem.Text.Trim() + "';" +
                        "a.NR_Pedido|=|" + (string.IsNullOrEmpty(Nr_PedidoItem.Text.Trim()) ? NR_Pedido.Text : Nr_PedidoItem.Text);
                    DataRow linha = null;
                    if (st_devolucao || st_retorno)
                    {
                        if (Tp_serie.Trim().ToUpper().Equals("S"))
                            vColunas += ";isnull(a.st_servico, 'N')|=|'S'";
                        else
                            vColunas += ";isnull(a.st_servico, 'N')|<>|'S'";
                        linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { id_pedidoitem, CD_Produto, ds_produto, Nr_PedidoItem },
                                            new TCD_LanPedido_Item("SqlCodeBuscaSaldoDevolucao"));
                        if (linha != null)
                            if ((Convert.ToDecimal(linha["Quantidade"].ToString()) == 0) &&
                                (Convert.ToDecimal(linha["Vl_SubTotal"].ToString()) == 0))
                            {
                                MessageBox.Show("Item sem saldo para devolução/retorno.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CD_Produto.Clear();
                                ds_produto.Clear();
                                CD_Produto.Focus();
                                return;
                            }
                    }
                    else if (st_complemento || st_compdevimposto)
                    {
                        vColunas = "a.CD_Produto|=|'" + CD_Produto.Text.Trim() + "';" +
                                    "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
                        if (Tp_serie.Trim().ToUpper().Equals("S"))
                            vColunas += ";isnull(a.st_servico, 'N')|=|'S'";
                        else
                            vColunas += ";isnull(a.st_servico, 'N')|<>|'S'";
                        if ((Nr_PedidoItem.Text != "") && (id_pedidoitem.Text != ""))
                            vColunas += ";a.nr_pedido|=|'" + Nr_PedidoItem.Text + "';a.id_pedidoitem|=|'" + id_pedidoitem.Text + "'";
                        linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Produto, ds_produto },
                                            new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"));
                    }
                    else if (st_mestra)
                    {
                        if (Tp_serie.Trim().ToUpper().Equals("S"))
                            vColunas += ";isnull(a.st_servico, 'N')|=|'S'";
                        else
                            vColunas += ";isnull(a.st_servico, 'N')|<>|'S'";
                        if (st_confere_saldo)
                            vColunas += ";||a.Quantidade > 0 and a.Vl_SubTotal > 0";
                        linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { id_pedidoitem, CD_Produto, ds_produto, Nr_PedidoItem },
                                            new TCD_LanPedido_Item("SqlCodeBuscaSaldoMestra"));
                    }
                    else if (st_simplesRemessa)
                    {
                        if (Tp_serie.Trim().ToUpper().Equals("S"))
                            vColunas += ";isnull(a.st_servico, 'N')|=|'S'";
                        else
                            vColunas += ";isnull(a.st_servico, 'N')|<>|'S'";
                        linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { id_pedidoitem, CD_Produto, ds_produto, Nr_PedidoItem },
                                            new TCD_LanPedido_Item("SqlCodeBuscaSaldoSimplesRemessa"));
                        if (linha != null)
                            if ((Convert.ToDecimal(linha["Quantidade"].ToString()) == 0) &&
                                (Convert.ToDecimal(linha["Vl_SubTotal"].ToString()) == 0))
                            {
                                MessageBox.Show("Item sem saldo para entrega futura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CD_Produto.Clear();
                                ds_produto.Clear();
                                CD_Produto.Focus();
                                return;
                            }
                    }
                    else
                    {
                        if (Tp_serie.Trim().ToUpper().Equals("S"))
                            vColunas += ";isnull(a.st_servico, 'N')|=|'S'";
                        else
                            vColunas += ";isnull(a.st_servico, 'N')|<>|'S'";
                        if (st_confere_saldo)
                            vColunas += ";||a.Quantidade > 0 and a.Vl_SubTotal > 0";


                        linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { id_pedidoitem, CD_Produto, ds_produto, Nr_PedidoItem },
                                            new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"));
                        if (linha != null)
                        {
                            //% Desconto
                            try
                            {
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_desconto = Convert.ToDecimal(linha["Pc_Desc"].ToString());
                            }
                            catch
                            { (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_desconto = decimal.Zero; }
                            //% Acrescimo
                            try
                            {
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_outrasdesp = Convert.ToDecimal(linha["pc_acrescimo"].ToString());
                            }
                            catch { (bsItensNota.Current as TRegistro_LanFaturamento_Item).Pc_outrasdesp = decimal.Zero; }
                        }
                    }
                    if (linha != null)
                        inserirItensNota(linha);
                }
            }
        }

        private void tp_movimento_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_Pedido.Text))
            {
                CD_Movto.NM_CampoBusca = "CD_Movto";
                string vColunas = "a.CD_Movto|=|'" + CD_Movto.Text + "';" +
                                  "d.TP_Movimento|=|'" + tp_movimento.SelectedValue.ToString().Trim() + "';" +
                                  "|exists|(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + NR_Pedido.Text + ")";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Movto, DS_Movto },
                                        new TCD_CadCFGPedidoFiscal());
                if (linha != null)
                {
                    if (UF_EMPRESA.Text != UF_Cliente.Text)
                    {
                        ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(linha["DS_ObsFiscal_ForaEstado"].ToString())) ? "," : string.Empty + linha["DS_ObsFiscal_ForaEstado"].ToString();
                        ds_DadosAdicionais.Text = linha["DS_DadosAdic_ForaEstado"].ToString();
                    }
                    else
                    {
                        ds_ObservacaoFiscal.Text += (!string.IsNullOrEmpty(ds_ObservacaoFiscal.Text) && !string.IsNullOrEmpty(linha["DS_ObsFiscal_DentroEstado"].ToString())) ? "," : string.Empty + linha["DS_ObsFiscal_DentroEstado"].ToString();
                        ds_DadosAdicionais.Text = linha["DS_DadosAdic_DentroEstado"].ToString();
                    }
                }
            }


            if ((!string.IsNullOrEmpty(NR_Pedido.Text)) &&
                (!string.IsNullOrEmpty(CD_Movto.Text)))
            {
                string vColunas = "a.CD_CMI|=|'" + CD_CMI.Text + "';" +
                                  "a.CD_Movto|=|'" + CD_Movto.Text + "';" +
                                  "|exists|(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + NR_Pedido.Text + ")";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_CMI, tp_duplicata, ds_tpduplicata },
                                        new TCD_CadCFGPedidoFiscal());
                if (linha != null)
                {
                    if (CD_CondPGTO.Text.Trim().Equals(string.Empty))
                    {
                        CD_CondPGTO.Text = linha["CD_CondPgto"].ToString();
                        DS_CondPgto.Text = linha["DS_CondPgto"].ToString();
                        if (bsNotaFiscal.Current != null)
                        {
                            try
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                            }
                            catch
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qtd_Parcelas = decimal.Zero;
                            }
                            try
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                            }
                            catch
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Qt_diasdesdobro = decimal.Zero;
                            }
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).St_cometrada = linha["ST_ComEntrada"].ToString().Trim().ToUpper().Equals("S");
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_juro_fin = linha["CD_Juro_Fin"].ToString();
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_juro_fin = linha["DS_Juro_Fin"].ToString();
                            try
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = Convert.ToDecimal(linha["pc_jurodiario_atrazo"].ToString());
                            }
                            catch
                            {
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Pc_jurodiario_atrazo = decimal.Zero;
                            }
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_juro = linha["TP_Juro"].ToString();
                            bsNotaFiscal.ResetCurrentItem();
                        }
                    }
                    st_devolucao = linha["ST_Devolucao"].ToString().Trim().Equals("S");
                    st_retorno = linha["ST_Retorno"].ToString().Trim().Equals("S");
                    st_complemento = linha["ST_Complementar"].ToString().Trim().Equals("S");
                    st_compdevimposto = linha["ST_CompDevImposto"].ToString().Trim().Equals("S");
                    st_mestra = linha["ST_Mestra"].ToString().Trim().Equals("S");
                    st_simplesRemessa = linha["ST_SimplesRemessa"].ToString().Trim().Equals("S");
                    if (linha["TP_Duplicata"].ToString().Trim().Equals(string.Empty))
                    {
                        CD_CondPGTO.ST_NotNull = false;
                        CD_CondPGTO.Enabled = false;
                        BB_CondPgto.Enabled = false;
                    }
                    else
                    {
                        CD_CondPGTO.ST_NotNull = true;
                        CD_CondPGTO.Enabled = true;
                        BB_CondPgto.Enabled = true;
                    }
                }
            }
        }

        private void BB_Imprimir_NotasFiscais_Click(object sender, EventArgs e)
        {
            Visualizar_Todas_NotasFiscais();
        }

        private void Visualizar_Todas_NotasFiscais()
        {
            if (bsNotaFiscal.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsNotaFiscal;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLanFaturamento_Visualizar_NotasFiscais";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();
                    BindingSource bsInutilizadas = new BindingSource();
                    Rel.Adiciona_DataSource("INUTILIZADOS", bsInutilizadas);

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
                                                    "RELATORIO " + Text.Trim(),
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
                                                "RELATORIO " + Text.Trim(),
                                                fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void relatorioSinteticoDeNotasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir_Relatorio_NotasFiscais_Sintetica();
        }

        private void Imprimir_Relatorio_NotasFiscais_Sintetica()
        {
            if (bsNotaFiscal.Count > 0)
            {

                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsNotaFiscal;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLanFaturamento_Total_NotasFiscais_Sintetico";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");

        }

        private void visualizarTodasNotasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizar_Todas_NotasFiscais();
        }

        private void bb_moeda_padrao_Click(object sender, EventArgs e)
        {
            string coluna = "DS_Moeda_Singular|Descrição Moeda|200;" +
                            "CD_Moeda|Cd. Moeda|80;Sigla|Sigla|60;" +
                            "DS_Moeda_Plural|Moeda Plural|200";
            UtilPesquisa.BTN_BUSCA(coluna, new EditDefault[] { cd_moeda_padrao, ds_moeda_padrao, sigla_moeda_padrao, ds_moeda_plural },
                                    new TCD_Moeda(), string.Empty);
            BuscarCotacao();
        }

        private void cd_moeda_padrao_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_Moeda|=|'" + cd_moeda_padrao.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_moeda_padrao, ds_moeda_padrao, sigla_moeda_padrao, ds_moeda_plural },
                                    new TCD_Moeda());
            BuscarCotacao();
        }

        private void bb_reprocessa_Click(object sender, EventArgs e)
        {
            ReprocessarFiscal();
        }

        private void bb_corrigirnf_Click(object sender, EventArgs e)
        {
            CorrigirNota();
        }

        private void bb_impostouf_Click(object sender, EventArgs e)
        {
            ConfigImpostoUf();
        }

        private void bb_outrosimpostos_Click(object sender, EventArgs e)
        {
            ConfigOutrosImpostos();
        }

        private void bb_reprocessaest_Click(object sender, EventArgs e)
        {
            ReprocessarEstoque();
        }

        private void bb_municipioexecservico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Municipio|200;" +
                              "a.cd_cidade|Cd. Municipio|80;" +
                              "a.distrito|Distrito|100;" +
                              "a.uf|UF|20;" +
                              "a.sg_uf|Estado|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new TCD_CadCidade(), string.Empty);
        }

        private void cd_municipioexecservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_municipioexecservico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_municipioexecservico, ds_municipioexecservico },
                                    new TCD_CadCidade());
        }

        private void CPF_Transp_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CPF_Transp.Text))
            {
                if (CPF_Transp.Text.Trim().Length.Equals(11) ||
                    (CPF_Transp.Text.Trim().Length.Equals(14) &&
                    CPF_Transp.Text.Trim().Contains('.')))
                {
                    CPF_Valido.nr_CPF = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                    {
                        MessageBox.Show("CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CPF_Transp.Clear();
                    }
                }
                else if (CPF_Transp.Text.Trim().Length >= 14)
                {
                    CNPJ_Valido.nr_CNPJ = CPF_Transp.Text;
                    if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                    {
                        MessageBox.Show("CNPJ Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CPF_Transp.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("CNPJ/CPF Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CPF_Transp.Clear();
                }
            }
        }

        private void CPF_Transp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) &&
                (e.KeyChar != '.') &&
                (e.KeyChar != '/') &&
                (e.KeyChar != '-') &&
                (e.KeyChar != '\b'))
                e.Handled = true;
        }

        private void ChaveAcessoNFE_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ChaveAcessoNFE.Text))
                if (ChaveAcessoNFE.Text.Trim().Length.Equals(44))
                {
                    if (Estruturas.Mod11(ChaveAcessoNFE.Text.Trim().Substring(0, 43), 9, false, 0).ToString() != ChaveAcessoNFE.Text.Trim().Substring(43, 1))
                    {
                        MessageBox.Show("Chave acesso NFe invalida, verifique e informe novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChaveAcessoNFE.Focus();
                    }
                }
                else
                    MessageBox.Show("Chave de acesso imcompleta. A chave de acesso deve conter 44 caracteres.<Total Caracteres: " + ChaveAcessoNFE.Text.Trim().Length.ToString() + ">",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gNotaFiscal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == gNotaFiscal.ColumnCount - 1)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gNotaFiscal.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gNotaFiscal.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
        }

        private void gNotaFiscal_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gNotaFiscal.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNotaFiscal.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanFaturamento());
            TList_RegLanFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanFaturamento(lP.Find(gNotaFiscal.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gNotaFiscal.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanFaturamento(lP.Find(gNotaFiscal.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gNotaFiscal.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNotaFiscal.List as TList_RegLanFaturamento).Sort(lComparer);
            bsNotaFiscal.ResetBindings(false);
            gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gItensNf_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensNf.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensNota.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanFaturamento_Item());
            TList_RegLanFaturamento_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanFaturamento_Item(lP.Find(gItensNf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensNf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanFaturamento_Item(lP.Find(gItensNf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensNf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensNota.List as TList_RegLanFaturamento_Item).Sort(lComparer);
            bsItensNota.ResetBindings(false);
            gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanFaturamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gEstoque);
            ShapeGrid.SaveShape(this, gItensNf);
            ShapeGrid.SaveShape(this, gItensNota);
            ShapeGrid.SaveShape(this, gNotaFiscal);
            ShapeGrid.SaveShape(this, gParcelas);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, dataGridDefault4);
            //Coletar lixo memoria
            GC.Collect();
        }

        private void cd_cfopitem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cfop|=|'" + cd_cfopitem.Text.Trim() + "'";
            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E"))
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals("99"))
                    vParam += ";substring(a.cd_cfop, 1, 1)|=|'3'";
                else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa.Trim()))
                    vParam += ";substring(a.cd_cfop, 1, 1)|=|'1'";
                else
                    vParam += ";substring(a.cd_cfop, 1, 1)|=|'2'";
            else
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals("99"))
                vParam += ";substring(a.cd_cfop, 1, 1)|=|'7'";
            else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa.Trim()))
                vParam += ";substring(a.cd_cfop, 1, 1)|=|'5'";
            else
                vParam += ";substring(a.cd_cfop, 1, 1)|=|'6'";
            if (st_devolucao)
                vParam += ";isnull(a.st_devolucao, 'N')|=|'S'";
            else if (st_retorno)
                vParam += ";isnull(a.st_retorno, 'N')|=|'S'";
            else vParam += ";||isnull(a.st_devolucao, 'N') <> 'S' and isnull(a.st_retorno, 'N') <> 'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_cfopitem }, new CamadaDados.Fiscal.TCD_CadCFOP());
            if (linha != null)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_bonificacao = linha["st_bonificacao"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_usoconsumo = linha["st_usoconsumo"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_remessa = linha["st_remessa"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_retorno = linha["st_retorno"].ToString().Trim().ToUpper().Equals("S");
            }
        }

        private void bb_cfopitem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cfop|Descrição|200;" +
                              "a.cd_cfop|CFOP|80;" +
                              "a.st_bonificacao|Bonificação|80;" +
                              "a.st_usoconsumo|Uso Consumo|80;" +
                              "a.st_remessa|Remessa|80;" +
                              "a.st_retorno|Retorno|80";
            string vParam = string.Empty;
            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E"))
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals("99"))
                    vParam = "substring(a.cd_cfop, 1, 1)|=|'3'";
                else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa.Trim()))
                    vParam = "substring(a.cd_cfop, 1, 1)|=|'1'";
                else
                    vParam = "substring(a.cd_cfop, 1, 1)|=|'2'";
            else
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals("99"))
                vParam = "substring(a.cd_cfop, 1, 1)|=|'7'";
            else if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor.Trim().Equals((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa.Trim()))
                vParam = "substring(a.cd_cfop, 1, 1)|=|'5'";
            else
                vParam = "substring(a.cd_cfop, 1, 1)|=|'6'";
            if (st_devolucao)
                vParam += ";isnull(a.st_devolucao, 'N')|=|'S'";
            else if (st_retorno)
                vParam += ";isnull(a.st_retorno, 'N')|=|'S'";
            else vParam += ";||isnull(a.st_devolucao, 'N') <> 'S' and isnull(a.st_retorno, 'N') <> 'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_cfopitem },
                                                        new CamadaDados.Fiscal.TCD_CadCFOP(), vParam);
            if (linha != null)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_bonificacao = linha["st_bonificacao"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_usoconsumo = linha["st_usoconsumo"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_remessa = linha["st_remessa"].ToString().Trim().ToUpper().Equals("S");
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_retorno = linha["st_retorno"].ToString().Trim().ToUpper().Equals("S");
            }
        }

        private void bb_alterar_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido alterar evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarEventoNFe fAlt = new TFAlterarEventoNFe())
                {
                    fAlt.rEvento = bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe;
                    if (fAlt.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(fAlt.rEvento, null);
                            MessageBox.Show("Evento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).lEventoNFe =
                                CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                            bsNotaFiscal.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_exclui_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido excluir evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do evento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Excluir(bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe, null);
                        MessageBox.Show("Evento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsEvento.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_enviarevento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).Tp_evento.Trim().ToUpper().Equals("CA"))
                    afterExclui();
                else
                {
                    //Buscar CfgNfe para a empresa
                    TList_CfgNfe lCfg = TCN_CfgNfe.Buscar((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                    if (lCfg.Count.Equals(0))
                        MessageBox.Show("Não existe configuração para envio de EVENTO para a empresa " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe, lCfg[0]);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Erro ao enviar EVENTO para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                MessageBox.Show("EVENTO enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).lEventoNFe =
                                CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void bb_imprimirEvento_Click(object sender, EventArgs e)
        {
            ImprimirEventoCCe();
        }

        private void bb_manifesto_Click(object sender, EventArgs e)
        {
            ManifestoNFe();
        }

        private void CD_CondPGTO_EnabledChanged(object sender, EventArgs e)
        {
            if (!CD_CondPGTO.Enabled)
            {
                CD_CondPGTO.Clear();
                DS_CondPgto.Clear();
            }
        }

        private void bsItensNota_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
            {
                bb_lotesementes.Visible = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoSemente(
                       (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto);
                bb_alterarDI.Visible = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_cfop.StartsWith("3");
            }
        }

        private void bb_ratearSubst_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
            {
                using (TFQuantidade fQtde = new TFQuantidade())
                {
                    fQtde.Ds_label = "ICMS Subst.";
                    fQtde.Casas_decimais = 2;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        decimal vl_totalprod = (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_subtotal);
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                        {
                            p.Vl_ICMSST =
                                Math.Round(decimal.Divide(decimal.Multiply(fQtde.Quantidade, Math.Round(decimal.Divide(decimal.Multiply(p.Vl_subtotal, 100), vl_totalprod), 2, MidpointRounding.AwayFromZero)), 100), 2, MidpointRounding.AwayFromZero);
                        });
                        bsNotaFiscal.ResetCurrentItem();
                        TotalizarNota();
                        if (fQtde.Quantidade != vl_toticmssubst.Value)
                        {
                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Last().Vl_ICMSST += fQtde.Quantidade - vl_toticmssubst.Value;
                            bsNotaFiscal.ResetCurrentItem();
                            TotalizarNota();
                        }
                    }
                }
            }
        }

        private void tot_basecalc_ValueChanged(object sender, EventArgs e)
        {
            vl_totalbasecalc.Value = tot_basecalc.Value;
        }

        private void tot_icms_ValueChanged(object sender, EventArgs e)
        {
            vl_totalicms.Value = tot_icms.Value;
        }

        private void tot_icmssubst_ValueChanged(object sender, EventArgs e)
        {
            vl_toticmssubst.Value = tot_icmssubst.Value;
        }

        private void tot_ipi_ValueChanged(object sender, EventArgs e)
        {
            vl_totalipi.Value = tot_ipi.Value;
        }

        private void tot_impcalc_ValueChanged(object sender, EventArgs e)
        {
            vl_total_impcalc.Value = tot_impcalc.Value;
        }

        private void tot_impretido_ValueChanged(object sender, EventArgs e)
        {
            vl_totalimpret.Value = tot_impretido.Value;
        }

        private void tot_impostos_ValueChanged(object sender, EventArgs e)
        {
            vl_totimpostos.Value = tot_impostos.Value;
        }
               

        private void pAliquotaIPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                pAliquotaIPI_Leave(this, new EventArgs());
        }

        private void vl_baseCalcIPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                vl_baseCalcIPI_Leave(this, new EventArgs());
        }

        private void bb_ufsaidaex_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_uf|Cd. UF|60;" +
                              "a.uf|Sigla|60;" +
                              "a.ds_uf|Estado|150";
            string vParam = "a.cd_uf|<>|'99'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_ufsaidaex, ds_ufsaidaex, uf_saidaex }, new TCD_CadUf(), vParam);
        }

        private void cd_ufsaidaex_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_ufsaidaex.Text.Trim() + "';" +
                            "a.cd_uf|<>|'99'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_ufsaidaex, ds_ufsaidaex, uf_saidaex }, new TCD_CadUf());
        }

        private void cd_uf_clifor_TextChanged(object sender, EventArgs e)
        {
            if (cd_uf_clifor.Text.Trim().Equals("99"))
            {
                if (!tcDetalhe.TabPages.Contains(tpEx))
                    tcDetalhe.TabPages.Add(tpEx);
            }
            else
                if (tcDetalhe.TabPages.Contains(tpEx))
                tcDetalhe.TabPages.Remove(tpEx);
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|60;" +
                              "b.uf|UF|30";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new TCD_CadCidade(), string.Empty);
        }

        private void cd_cidadent_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadent.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_cidadent, ds_cidadeent, uf_ent },
                new TCD_CadCidade());
        }

        private void bb_endEntrega_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                UtilPesquisa.BTN_BuscaEndereco(new EditDefault[] { logradouroent, numeroent, complementoent, bairroent, cd_cidadent, ds_cidadeent, uf_ent }, "a.cd_clifor|=|'" + CD_Clifor.Text + "';isnull(a.st_endentrega, 'N')|=|'S'");
        }

        private void bb_gerarXmlEvento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
                if ((bsEvento.Current as CamadaDados.Faturamento.NFE.TRegistro_EventoNFe).St_registro.ToUpper().Equals("T"))
                {
                    string path = string.Empty;
                    using (FolderBrowserDialog fbdPath = new FolderBrowserDialog())
                    {
                        if (fbdPath.ShowDialog() == DialogResult.OK)
                            path = fbdPath.SelectedPath.Trim();
                        else return;
                    }
                    //Limpar diretorio path arquivo
                    string[] arq = System.IO.Directory.GetFiles(path, "*.xml");
                    if (arq.Length > 0)
                        if (MessageBox.Show("Existe arquivo XML antigo no path para salvar os novos arquivos.\r\n" +
                                            "Deseja excluir os arquivos antigos?", "Pergunta", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            for (int i = 0; i < arq.Length; i++)
                                System.IO.File.Delete(arq[i].Trim());
                    GerarXmlEvento(path);
                }
        }

        private void btn_Altera_Preco_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                using (TFPrecoItem fPreco = new TFPrecoItem())
                {
                    fPreco.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                    fPreco.Nm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                    fPreco.lItens = new TList_RegLanFaturamento_Item();
                    (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p => fPreco.lItens.Add(p));
                    fPreco.ShowDialog();
                }
            }
        }              

        private void bb_lotesementes_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E") &&
                            (!(bsCmiNf.Current as TRegistro_LanFaturamento_CMI).St_devolucaobool) && (!(bsCmiNf.Current as TRegistro_LanFaturamento_CMI).St_retornobool))
                {
                    //Lote de Terceiro
                    if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade > decimal.Zero)
                    {
                        using (TFLotesSementes fLote = new TFLotesSementes())
                        {
                            fLote.pCd_empresa = CD_Empresa.Text;
                            fLote.pNm_empresa = NM_Empresa.Text;
                            fLote.pCd_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto;
                            fLote.pDs_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_produto;
                            fLote.pQtd_movimentar = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade;
                            fLote.pTp_mov = "E";
                            if (fLote.ShowDialog() == DialogResult.OK)
                                if (fLote.lMov != null)
                                {
                                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente.Clear();
                                    fLote.lMov.ForEach(p => (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente.Add(p));
                                    TCN_LanFaturamento_Item.GravarLoteSementeItem(bsItensNota.Current as TRegistro_LanFaturamento_Item, null);
                                    MessageBox.Show("Lote adicionado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                    }
                }
                else if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade > decimal.Zero)
                    using (Sementes.TFSaldoLoteSemente fSaldoLoteSemente = new Sementes.TFSaldoLoteSemente())
                    {
                        fSaldoLoteSemente.Cd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                        fSaldoLoteSemente.Nm_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nm_empresa;
                        fSaldoLoteSemente.Cd_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto;
                        fSaldoLoteSemente.Ds_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Ds_produto;
                        fSaldoLoteSemente.Tp_mov = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento;
                        fSaldoLoteSemente.Qtd_nota = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade;
                        fSaldoLoteSemente.St_devolucao = st_devolucao;
                        if (fSaldoLoteSemente.ShowDialog() == DialogResult.OK)
                        {
                            if (fSaldoLoteSemente.lLoteNf != null)
                            {
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteSemente = fSaldoLoteSemente.lLoteNf;
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).lLoteNfOrigem = fSaldoLoteSemente.lLoteNfOrigem;
                                fSaldoLoteSemente.lLoteNf.ForEach(p => (bsItensNota.Current as TRegistro_LanFaturamento_Item).Observacao_item += p.Ds_obsNfItem + "\r\n");
                                bsItensNota.ResetCurrentItem();
                                TCN_LanFaturamento_Item.GravarLoteSementeItem(bsItensNota.Current as TRegistro_LanFaturamento_Item, null);
                                MessageBox.Show("Lote adicionado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar lote de semente para gravar item da nota.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
            }
        }

        private void bbDevOutrosPed_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|Nr.Pedido|50;" +
                              "a.nr_contrato|Nr.Contrato|50;" +
                              "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100;" +
                              "a.quantidade|Quantidade|100;" +
                              "a.vl_subtotal|Valor Tot|100;" +
                              "a.ID_PedidoItem|Id. Item|80";

            string vParamFixo = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";

            if (st_devolucao || st_retorno)
            {
                string vParamFixoDev = "a.nr_pedido|<>|" + NR_Pedido.Text + ";a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoDevolucao"), vParamFixoDev);
                if (linha != null)
                {
                    Nr_PedidoItem.Text = linha["nr_pedido"].ToString();
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                }
            }
            else if (st_complemento || st_compdevimposto)
            {
                string vCol = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100;" +
                              "a.nr_pedido|Nr.Pedido|50;" +
                              "a.nr_contrato|Nr.Contrato|50;" +
                              "a.ID_PedidoItem|Id. Item|80";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixo += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixo += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vCol, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"), vParamFixo);
                if (linha != null)
                {
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                    Nr_PedidoItem.Text = linha["Nr_Pedido"].ToString();
                }
            }
            else if (st_mestra)
            {
                string vParamFixoMestra = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                          "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoMestra += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoMestra += ";isnull(a.st_servico, 'N')|<>|'S'";
                if (st_confere_saldo)
                    vParamFixoMestra += ";||a.Quantidade > 0 and a.Vl_SubTotal > 0";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoMestra"), vParamFixoMestra);
                if (linha != null)
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
            }
            else if (st_simplesRemessa)
            {
                string vParamFixoDev = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                        "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto)";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixoDev += ";isnull(a.st_servico, 'N')|<>|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoSimplesRemessa"), vParamFixoDev);
                if (linha != null)
                {
                    Nr_PedidoItem.Text = linha["nr_pedido"].ToString();
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                }
            }
            else
            {
                vParamFixo = "|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = '" + NR_Pedido.Text + "' and m.cd_produto = a.cd_produto);" +
                             "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
                if (Tp_serie.Trim().ToUpper().Equals("S"))
                    vParamFixo += ";isnull(a.st_servico, 'N')|=|'S'";
                else
                    vParamFixo += ";isnull(a.st_servico, 'N')|<>|'S'";
                if (st_confere_saldo)
                    vParamFixo += ";||a.Quantidade > 0 and b.Vl_SubTotal > 0";

                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Produto, ds_produto, Nr_PedidoItem, id_pedidoitem },
                                    new TCD_LanPedido_Item("SqlCodeBuscaSaldoNFNormal"), vParamFixo);
                if (linha != null)
                {
                    id_pedidoitem.Text = linha["ID_PedidoItem"].ToString();
                    Nr_PedidoItem.Text = linha["Nr_Pedido"].ToString();
                    cd_unidProduto = linha["cd_unes"].ToString();
                }
            }
            id_pedidoitem_Leave(this, new EventArgs());
        }

        private void bb_alterarDI_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_transmitidoNFe)
                {
                    MessageBox.Show("Não é possível alturar declaração de importação de NF Transmitida para a receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar DI
                TList_DeclaracaoImport lDi =
                    new TCD_DeclaracaoImport().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.Nr_LanctoFiscal",
                                vOperador = "=",
                                vVL_Busca = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_NFItem",
                                vOperador = "=",
                                vVL_Busca = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString()
                            }
                        }, 0, string.Empty);
                if (lDi.Count > 0)
                {
                    using (TFDeclaracaoImport fDi = new TFDeclaracaoImport())
                    {
                        fDi.rDi = lDi[0];
                        if (fDi.ShowDialog() == DialogResult.OK)
                            if (fDi.rDi != null)
                                try
                                {
                                    TCN_DeclaracaoImport.Gravar(fDi.rDi, null);
                                    MessageBox.Show("Declaração de Importação alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void DT_SaiEnt_Leave(object sender, EventArgs e)
        {
            if (CamadaDados.UtilData.Data_Servidor() < Convert.ToDateTime(DT_SaiEnt.Text) && tp_movimento.SelectedValue.Equals("E"))
            {
                MessageBox.Show("Dt.Entrada não pode ser maior que a data atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_SaiEnt.Clear();
                DT_SaiEnt.Focus();
                return;
            }
        }

        private void devolverNFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TGerarDevolucaoNF.DevolverNF(bsNotaFiscal.Current as TRegistro_LanFaturamento);
        }

        #region Calc. Auto ICMS
        private void pc_fcp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vlBaseCalcICMS.Value > decimal.Zero)
                    vl_fcp.Value = vlBaseCalcICMS.Value * (pc_fcp.Value / 100);
            }
            catch { }
        }

        private void vl_fcp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vlBaseCalcICMS.Value > decimal.Zero)
                    pc_fcp.Value = (vl_fcp.Value / vlBaseCalcICMS.Value) * 100;
            }
            catch { }
        }

        private void pAliquotaICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                if (pReducaoAliquota.Value > 0)
                {
                    decimal asd = decimal.Multiply(vlBaseCalcICMS.Value, decimal.Divide(pAliquotaICMS.Value, 100));
                    decimal asd1 = decimal.Multiply(asd, decimal.Divide(pReducaoAliquota.Value, 100));
                    vlICMS.Value = vlBaseCalcICMS.Value - asd1;
                }
                else
                {
                    //if (pReducaoBC.Value > 0)
                    //    vlICMS.Value = decimal.Multiply(vlBaseCalcICMS.Value, decimal.Divide(pReducaoBC.Value, 100)) * decimal.Divide(pAliquotaICMS.Value, 100);
                    //else
                        vlICMS.Value = vlBaseCalcICMS.Value * (pAliquotaICMS.Value / 100);
                }
            }
            catch { }
        }

        private void vlICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                pAliquotaICMS.Value = (vlICMS.Value / vlBaseCalcICMS.Value) * 100;
            }
            catch { }
        }

        private void pRetencaoICMS_Leave(object sender, EventArgs e)
        {
            try
            {
                vlICMSRetido.Value = vlBaseCalcICMS.Value * (pRetencaoICMS.Value / 100);
            }
            catch { }
        }

        private void vlICMSRetido_Leave(object sender, EventArgs e)
        {
            try
            {
                pRetencaoICMS.Value = (vl_retidoCofins.Value / vlBaseCalcICMS.Value) * 100;
            }
            catch { }
        }

        private void pAliquotaST_Leave(object sender, EventArgs e)
        {
            try
            {
                vlICMSST.Value = (vlBCStICMS.Value * (pAliquotaST.Value / 100)) - vlBaseCalcICMS.Value;
            }
            catch { }
        }

        private void vlICMSST_Leave(object sender, EventArgs e)
        {
            try
            {
                pAliquotaST.Value = (vlICMSST.Value + vlBaseCalcICMS.Value) / vlBCStICMS.Value;
            }
            catch { }
        }
        #endregion        

        #region Calc. Auto PIS
        private void pc_aliquotaPIS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_pis.Value = vl_basecalcPIS.Value * (pc_aliquotaPIS.Value / 100);
            }
            catch { }
        }

        private void vl_pis_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_aliquotaPIS.Value = (vl_pis.Value / vl_basecalcPIS.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoPIS_Leave(object sender, EventArgs e)
        {
            try
            {
                //Vl. Retenção PIS
                editFloat1.Value = vl_basecalcPIS.Value * (pc_retencaoPIS.Value / 100);
            }
            catch { }
        }

        private void editFloat1_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoPIS.Value = (editFloat1.Value / vl_basecalcPIS.Value) * 100;
            }
            catch { }
        }


        #endregion

        #region Calc. Auto Cofins
        private void pc_aliquotaCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_cofins.Value = vl_basecalcCofins.Value * (pc_aliquotaCofins.Value / 100);
            }
            catch { }
        }

        private void vl_cofins_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_aliquotaCofins.Value = (vl_cofins.Value / vl_basecalcCofins.Value) * 100;
            }
            catch { }
        }

        private void pc_retencaoCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCofins.Value = vl_basecalcCofins.Value * (pc_retencaoCofins.Value / 100);
            }
            catch { }
        }

        private void vl_retidoCofins_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoCofins.Value = (vl_retidoCofins.Value / vl_basecalcCofins.Value) * 100;
            }
            catch { }
        }
        #endregion

        #region Calc. Auto IPI
        private void pAliquotaIPI_Leave(object sender, EventArgs e)
        {
            if (vl_baseCalcIPI.Value > decimal.Zero && pAliquotaIPI.Value > decimal.Zero)
                vl_ipi.Value = (vl_baseCalcIPI.Value / 100) * pAliquotaIPI.Value;
            else
                vl_ipi.Value = decimal.Zero;
            vl_ipi.Focus();
        }

        private void Vl_impostoCalcIPI_Leave(object sender, EventArgs e)
        {
            pReducaoBC.Focus();
        }

        private void vl_baseCalcIPI_Leave(object sender, EventArgs e)
        {
            if (vl_baseCalcIPI.Value > decimal.Zero && pAliquotaIPI.Value > decimal.Zero)
                vl_ipi.Value = (vl_baseCalcIPI.Value / 100) * pAliquotaIPI.Value;
            else
                vl_ipi.Value = decimal.Zero;
            pAliquotaIPI.Focus();
        }
        #endregion  

        #region Calc. Auto Serviço
        private void pc_aliquotaISS_Leave(object sender, EventArgs e)
        {
            CalcularISS();
            //try
            //{
            //    if (pc_reducaobasecalcISS.Value > 0)
            //    {
            //        decimal baseRedu = (vl_basecalcISS.Value * (pc_reducaobasecalcISS.Value / 100));
            //        baseRedu = vl_basecalcISS.Value - baseRedu;
            //        vl_iss.Value = baseRedu * (pc_aliquotaISS.Value / 100);
            //    }
            //    else
            //    {
            //        vl_iss.Value = vl_basecalcISS.Value * (pc_aliquotaISS.Value / 100);
            //    }
            //}
            //catch { }
        }

        private void vl_iss_Leave(object sender, EventArgs e)
        {
            CalcularISS(St_valor: true);
            //try
            //{
            //    if (pc_reducaobasecalcISS.Value > 0)
            //    {
            //        decimal baseRedu = (vl_basecalcISS.Value * (pc_reducaobasecalcISS.Value / 100));
            //        baseRedu = vl_basecalcISS.Value - baseRedu;
            //        pc_aliquotaISS.Value = (vl_iss.Value / baseRedu) * 100;
            //    }
            //    else
            //    {
            //        pc_aliquotaISS.Value = (vl_iss.Value / vl_basecalcISS.Value) * 100;
            //    }
            //}
            //catch { }
        }

        private void pc_retencaoISS_Leave(object sender, EventArgs e)
        {
            CalcularISS();
            ////try
            ////{
            ////    //if (pc_reducaobasecalcISS.Value > 0)
            ////    //{
            ////    //    vl_issretido.Value = (vl_basecalcISS.Value * pc_reducaobasecalcISS.Value / 100) * (pc_retencaoISS.Value / 100);
            ////    //}
            ////    //else
            ////    //{
            ////        vl_issretido.Value = vl_basecalcISS.Value * (pc_retencaoISS.Value / 100);
            ////    //}
            ////}
            ////catch { }
        }

        private void vl_issretido_Leave(object sender, EventArgs e)
        {
            CalcularISS(St_valorRet: true);
            //try
            //{
            //    pc_retencaoISS.Value = (vl_issretido.Value / vl_basecalcISS.Value) * 100;
            //}
            //catch { }
        }

        private void pc_retencaoIRRF_Leave(object sender, EventArgs e)
        {
            CalcularIRRF();
        }

        private void vl_retidoIRRF_Leave(object sender, EventArgs e)
        {
            CalcularIRRF(St_valorRet: true);
        }

        private void pc_retencaoCSLL_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoCSLL.Value = vl_basecalcCSLL.Value * (pc_retencaoCSLL.Value / 100);
            }
            catch { }
        }

        private void pc_retencaoINSS_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoINSS.Value = vl_basecalcINSS.Value * (pc_retencaoINSS.Value / 100);
            }
            catch { }
        }

        private void vl_retidoINSS_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoINSS.Value = vl_retidoINSS.Value / vl_basecalcINSS.Value;
            }
            catch { }
        }

        #endregion

        #region Calc. Auto Funrural/ Senar
        private void pc_funrural_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_funrural.Value = vl_basecalcFunrural.Value * (pc_funrural.Value / 100);
            }
            catch { }
        }

        private void vl_funrural_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_funrural.Value = vl_funrural.Value / vl_basecalcFunrural.Value;
            }
            catch { }
        }

        private void pc_retencaoFunrural_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidofunrural.Value = vl_basecalcFunrural.Value * (pc_retencaoFunrural.Value / 100);
            }
            catch { }
        }

        private void pc_senar_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_senar.Value = vl_basecalcSenar.Value * (pc_senar.Value / 100);
            }
            catch { }
        }

        private void vl_senar_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_senar.Value = vl_senar.Value / vl_basecalcSenar.Value;
            }
            catch { }
        }

        private void pc_retencaoSenar_Leave(object sender, EventArgs e)
        {
            try
            {
                vl_retidoSenar.Value = vl_basecalcSenar.Value * (pc_retencaoSenar.Value / 100);
            }
            catch { }
        }

        private void vl_retidoSenar_Leave(object sender, EventArgs e)
        {
            try
            {
                pc_retencaoSenar.Value = vl_retidoSenar.Value / vl_basecalcSenar.Value;
            }
            catch { }
        }
        #endregion

        #region Calc. Auto II
        private void editFloat4_Leave(object sender, EventArgs e)
        {
            //editFloat4 = % Aliquota do II
            try
            {
                //editFloat3 = Vl. II editFloat5 = Base Calc.
                editFloat3.Value = editFloat5.Value * (editFloat4.Value / 100);
            }
            catch { }
        }

        private void editFloat3_Leave(object sender, EventArgs e)
        {
            try
            {
                editFloat4.Value = editFloat3.Value / editFloat5.Value;
            }
            catch { }
        }

        #endregion

        private void vl_percentualIRRF_Leave(object sender, EventArgs e)
        {
            CalcularIRRF();
        }

        private void vl_percentualCSLL_Leave(object sender, EventArgs e)
        {
            CalcularCSLL();
        }

        private void vl_CSLL_Leave(object sender, EventArgs e)
        {
            CalcularCSLL(St_valor: true);
        }

        private void vl_percentualINSS_Leave(object sender, EventArgs e)
        {
            CalcularINSS();
        }

        private void vl_INSS_Leave(object sender, EventArgs e)
        {
            CalcularINSS(St_valor: true);
        }

        private void vl_IRRF_Leave(object sender, EventArgs e)
        {
            CalcularIRRF(St_valor: true);
        }

        private void pc_retencaoINSS_Leave_1(object sender, EventArgs e)
        {
            CalcularINSS();
        }

        private void vl_retidoINSS_Leave_1(object sender, EventArgs e)
        {
            CalcularINSS(St_valorRet: true);
        }

        private void pc_retencaoCSLL_Leave_1(object sender, EventArgs e)
        {
            CalcularCSLL();
        }

        private void vl_retidoCSLL_Leave(object sender, EventArgs e)
        {
            CalcularCSLL(St_valorRet: true);
        }

        private void pc_reducaobasecalcISS_ValueChanged(object sender, EventArgs e)
        {
            if (pc_reducaobasecalcISS != null &&
                pc_reducaobasecalcISS.Value > 0)
                dsDeducao.Enabled = true;
            else dsDeducao.Enabled = false;
        }

        private void pc_reducaobasecalcISS_Leave(object sender, EventArgs e)
        {
            CalcularISS();
            //try
            //{
            //    if (vl_basecalcISS.Value > 0 &&
            //        pc_aliquotaISS.Value > 0)
            //    {
            //        decimal baseRedu = (vl_basecalcISS.Value * (pc_reducaobasecalcISS.Value / 100));
            //        baseRedu = vl_basecalcISS.Value - baseRedu;
            //        vl_iss.Value = baseRedu * (pc_aliquotaISS.Value / 100);
            //    }
            //}
            //catch { }
        }

        private void pc_redbasecalcinss_Leave(object sender, EventArgs e)
        {
            CalcularINSS();
        }

        private void vl_basecalcINSS_Leave(object sender, EventArgs e)
        {
            CalcularINSS();
        }

        private void vl_basecalcCSLL_Leave(object sender, EventArgs e)
        {
            CalcularCSLL();
        }

        private void pc_redbasecalccsll_Leave(object sender, EventArgs e)
        {
            CalcularCSLL();
        }

        private void vl_basecalcIRRF_Leave(object sender, EventArgs e)
        {
            CalcularIRRF();
        }

        private void pc_redbasecalcirrf_Leave(object sender, EventArgs e)
        {
            CalcularIRRF();
        }

        private void pc_fcpst_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vlBCStICMS.Value > decimal.Zero)
                    vl_fcpst.Value = vlBCStICMS.Value * (pc_fcpst.Value / 100);
            }
            catch { }
        }

        private void vl_fcpst_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vlBCStICMS.Value > decimal.Zero)
                    pc_fcpst.Value = (vl_fcpst.Value / vlBCStICMS.Value) * 100;
            }
            catch { }
        }

        private void tot_fcpst_ValueChanged(object sender, EventArgs e)
        {
            vl_totalfcpst.Value = tot_fcpst.Value;
        }

        private void vl_basecalcISS_Leave(object sender, EventArgs e)
        {
            CalcularISS();
        }

        private void pc_retencaoISS_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}