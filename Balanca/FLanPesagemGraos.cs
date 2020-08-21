using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using CamadaNegocio.Diversos;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Cadastros;
using Commoditties;
using CamadaDados.Faturamento.Cadastros;
using Proc_Commoditties;
using CamadaDados.Balanca.Cadastros;

namespace Balanca
{
    public partial class TFLanPesagemGraos : FormPesagemPadrao.TFLanPesagemPadrao
    {
        private decimal peso_referencia = 0;
        private bool controlePlaca = true;
        private string tp_movtopedido;
        public string Tp_movtopedido
        {
            get { return tp_movtopedido; }
            set { tp_movtopedido = value; }
        }
        private bool PERMITE_CLASSIF = false;

        public TFLanPesagemGraos()
        {
            InitializeComponent();
            tp_movtopedido = string.Empty;
            pTopEsquerdo.set_FormatZero();
            pPesagemGraos.set_FormatZero();
            pBuscaPsGraos.set_FormatZero();
            modoBotoes();
            ativaPage(string.Empty, string.Empty);
            cbProtocolo.DataSource = TCN_CadProtocolo.Busca(string.Empty, string.Empty, Parametros.pubTerminal, null);
            cbProtocolo.DisplayMember = "Ds_protocolo";
            cbProtocolo.ValueMember = "Cd_protocolo";

            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new TDataCombo("ENTRADA", "E"));
            CBox1.Add(new TDataCombo("SAIDA", "S"));
            TP_Movimento.DataSource = CBox1;
            TP_Movimento.DisplayMember = "Display";
            TP_Movimento.ValueMember = "Value";

            ArrayList cbx2 = new ArrayList();
            cbx2.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx2.Add(new TDataCombo("CONVENCIONAL", "CV"));
            cbx2.Add(new TDataCombo("TRANSGÊNICA", "TR"));
            cbx2.Add(new TDataCombo("INTACTA DECLARADA", "ID"));
            cbx2.Add(new TDataCombo("INTACTA TESTADA", "IT"));
            cbx2.Add(new TDataCombo("INTACTA PARTICIPANTE", "IP"));
            tp_prodpesagem.DataSource = cbx2;
            tp_prodpesagem.DisplayMember = "Display";
            tp_prodpesagem.ValueMember = "Value";

            HabilitaCamposFazenda(false);

            PERMITE_CLASSIF = TCN_Usuario_RegraEspecial.ValidaRegra(CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "PERMITIR ACESSO A LANCAR CLASSIFICACAO", null);
        }

        public void ativaPage(string Tp_Modo, string Tp_movimento)
        {
            if (!string.IsNullOrEmpty(Tp_Modo))
            {
                if (Tp_Modo.Trim().ToUpper().Equals("G"))
                {
                    if (TpModo.Equals(TTpModo.tm_Standby) || TpModo.Equals(TTpModo.tm_busca))
                    {
                        if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                            tcPesagemGraos.TabPages.Insert(0, tpBuscaPsGraos);
                        if (tcPesagemGraos.TabPages.Contains(tabPesagemFazenda))
                            tcPesagemGraos.TabPages.Remove(tabPesagemFazenda);
                        if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                            tcPesagemGraos.TabPages.Remove(tpPsGraos);
                        if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                            tcPesagemGraos.TabPages.Remove(tpClassifGraos);
                        if (tcPesagemGraos.TabPages.Contains(tpDesdobro))
                            tcPesagemGraos.TabPages.Remove(tpDesdobro);

                        if (tcPesagemGraos.TabPages.Count < 1)
                            tcPesagemGraos.TabPages.Add(tpPsGraos);
                        else
                            tcPesagemGraos.TabPages.Insert(1, tpPsGraos);
                        if (tcPesagemGraos.TabPages.Count < 2)
                            tcPesagemGraos.TabPages.Add(tpClassifGraos);
                        else
                            tcPesagemGraos.TabPages.Insert(2, tpClassifGraos);
                        if (tcPesagemGraos.TabPages.Count < 3)
                            tcPesagemGraos.TabPages.Add(tpDesdobro);
                        else
                            tcPesagemGraos.TabPages.Insert(3, tpDesdobro);
                    }
                    else
                    {
                        tcPesagemGraos.TabPages.Clear();
                        tcPesagemGraos.TabPages.Add(tpPsGraos);
                        tcPesagemGraos.TabPages.Add(tpClassifGraos);
                        tcPesagemGraos.TabPages.Add(tpDesdobro);
                    }
                }
                if (Tp_Modo.Trim().ToUpper().Equals("F"))
                {
                    if (Tp_movimento.Trim().ToUpper().Equals("S"))
                    {
                        if (TpModo.Equals(TTpModo.tm_Standby) || TpModo.Equals(TTpModo.tm_busca))
                        {
                            if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                                tcPesagemGraos.TabPages.Insert(0, tpBuscaPsGraos);
                            if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.TabPages.Remove(tpPsGraos);
                            if (tcPesagemGraos.TabPages.Contains(tabPesagemFazenda))
                                tcPesagemGraos.TabPages.Remove(tabPesagemFazenda);
                            if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                                tcPesagemGraos.TabPages.Remove(tpClassifGraos);

                            if (tcPesagemGraos.TabPages.Count < 1)
                                tcPesagemGraos.TabPages.Add(tpPsGraos);
                            else
                                tcPesagemGraos.TabPages.Insert(1, tpPsGraos);
                            if (tcPesagemGraos.TabPages.Count < 3)
                                tcPesagemGraos.TabPages.Add(tpClassifGraos);
                            else
                                tcPesagemGraos.TabPages.Insert(3, tpClassifGraos);
                        }
                        else
                        {
                            tcPesagemGraos.TabPages.Clear();
                            tcPesagemGraos.TabPages.Add(tpPsGraos);
                            tcPesagemGraos.TabPages.Add(tpClassifGraos);
                        }
                    }
                    else
                    {
                        if (TpModo.Equals(TTpModo.tm_Standby) || TpModo.Equals(TTpModo.tm_busca))
                        {
                            if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                                tcPesagemGraos.TabPages.Insert(0, tpBuscaPsGraos);
                            if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.TabPages.Remove(tpPsGraos);
                            if (tcPesagemGraos.TabPages.Contains(tabPesagemFazenda))
                                tcPesagemGraos.TabPages.Remove(tabPesagemFazenda);
                            if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                                tcPesagemGraos.TabPages.Remove(tpClassifGraos);

                            if (tcPesagemGraos.TabPages.Count < 1)
                                tcPesagemGraos.TabPages.Add(tabPesagemFazenda);
                            else
                                tcPesagemGraos.TabPages.Insert(1, tabPesagemFazenda);
                        
                            if (tcPesagemGraos.TabPages.Count < 2)
                                tcPesagemGraos.TabPages.Add(tpClassifGraos);
                            else
                                tcPesagemGraos.TabPages.Insert(2, tpClassifGraos);
                        }
                        else
                        {
                            tcPesagemGraos.TabPages.Clear();
                            tcPesagemGraos.TabPages.Add(tabPesagemFazenda);
                            tcPesagemGraos.TabPages.Add(tpClassifGraos);
                        }
                    }
                }
            }
            else
            {

                if (TpModo.Equals(TTpModo.tm_Standby) || TpModo.Equals(TTpModo.tm_busca))
                {
                    tcPesagemGraos.TabPages.Clear();
                    tcPesagemGraos.TabPages.Add(tpBuscaPsGraos);
                }
            }
        }

        public override void configTPPesagem()
        {
            TList_CadTpPesagem lTpPesagem =
                new TCD_CadTpPesagem().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_modo",
                        vOperador = "=",
                        vVL_Busca = "'G'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_pesagem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Pesagem.Text.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_div_usuario_x_tppesagem x "+
                                    "where x.tp_pesagem = a.tp_pesagem "+
                                    "and((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "        where y.logingrp = x.login " +
                                    "        and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                    }
                }, 1, string.Empty);

            if (lTpPesagem.Count > 0)
            {
                try
                {
                    TP_Pesagem.Text = lTpPesagem[0].Tp_pesagem.Trim();
                    NM_TpPesagem.Text = lTpPesagem[0].Nm_tppesagem.Trim();
                    VTP_MovDefault = lTpPesagem[0].Tp_movdefault.Trim();
                    VOrdemPesagem = lTpPesagem[0].Ordempesagem.Trim();
                    VST_SeqManual = lTpPesagem[0].St_seqmanual.Trim();
                    if (lTpPesagem[0].Tp_movdefault.Trim().ToUpper().Equals("E") && (TpModo == TTpModo.tm_Insert))
                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento = "E"; //Entrada
                    else if (lTpPesagem[0].Tp_movdefault.Trim().ToUpper().Equals("S") && (TpModo == TTpModo.tm_Insert))
                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento = "S"; //Saida
                    rgnfProdutorRural.Visible = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Equals("E");
                }
                catch
                {
                    TP_Pesagem.Text = string.Empty;
                    NM_TpPesagem.Text = string.Empty;
                    VTP_MovDefault = string.Empty;
                    VOrdemPesagem = string.Empty;
                    VST_SeqManual = string.Empty;
                    TP_Movimento.SelectedIndex = -1;
                    rgnfProdutorRural.Visible = false;
                }
            }
            else
            {
                TP_Pesagem.Text = string.Empty;
                NM_TpPesagem.Text = string.Empty;
                VTP_MovDefault = string.Empty;
                VOrdemPesagem = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                rgnfProdutorRural.Visible = false;
            }
        }

        public override void afterNovo()
        {
            afterCancela();
            base.afterNovo();
            if (Parametros.pubTerminal.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar terminal para realizar pesagem", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            tcPesagemGraos.TabPages.Clear();
            bsPesagemGraos.AddNew();
            bsPesagemGraos.ResetCurrentItem();

            placaCarreta.Enabled = true;
            BB_PlacaCarreta.Enabled = true;
            placaCarreta.Focus();
        }

        public override void afterAltera()
        {
            if (bsPesagemGraos.Current != null)
            {
                if (tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                    tcPesagemGraos.TabPages.Remove(tpBuscaPsGraos);

                tcPesagemGraos.SelectedIndex = 0;

                //Verificar se a pesagem nao esta cancelada
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar pesagem CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Verificar se a pesagem tem aplicacao
                if (TCN_LanAplicacaoPedido.Buscar(string.Empty, string.Empty, string.Empty,
                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                              string.Empty, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,null).Count > 0)
                {
                    MessageBox.Show("Não é permitido alterar pesagem com aplicação realizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Buscar classificacao
                if (bsClassificacao.Current == null)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao = TCN_LanClassificacao.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                                                      (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                                                      (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                                                      string.Empty,
                                                                                                                      (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto,
                                                                                                                      0, string.Empty, null);
                    bsPesagemGraos.ResetCurrentItem();
                }
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo.Trim().ToUpper().Equals("F"))
                {
                    //LIBERA OS CAMPOS ACEITOS
                    HabilitaCamposFazenda(false);
                    HabilitaFazenda(true);

                    if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo.Trim().ToUpper().Equals("F"))
                    {
                        if (!tcPesagemGraos.TabPages.Contains(tabPesagemFazenda))
                            tcPesagemGraos.TabPages.Add(tabPesagemFazenda);

                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Equals("E"))
                        {
                            if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.TabPages.Remove(tpPsGraos);

                            if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                            {
                                tcPesagemGraos.TabPages.Remove(tpClassifGraos);
                                tcPesagemGraos.TabPages.Add(tpClassifGraos);
                            }
                        }
                        else
                        {
                            if (!tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.TabPages.Add(tpPsGraos);

                            if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                            {
                                tcPesagemGraos.TabPages.Remove(tpClassifGraos);
                                tcPesagemGraos.TabPages.Add(tpClassifGraos);
                            }

                            nr_Contrato.Enabled = true;
                            bb_Contrato.Enabled = true;

                        }
                    }
                    HabilitaCamposFazenda(true);
                }

                base.afterAltera();

                pPesagemGraos.HabilitarControls(true, TpModo);

                nr_Contrato.Enabled = (!(bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool);
                bb_Contrato.Enabled = nr_Contrato.Enabled;

                cd_tabeladesconto.Enabled = false;
                BB_TabelaDesconto.Enabled = false;

            }
        }

        public void HabilitaCamposFazenda(bool habilita)
        {
            id_area.Enabled = habilita;
            bb_area.Enabled = habilita;
            id_talhao.Enabled = habilita;
            bb_talhao.Enabled = habilita;
            id_plantio.Enabled = habilita;
            bb_plantio.Enabled = habilita;
            cd_tabdescfaz.Enabled = habilita;
            bb_tabdescfaz.Enabled = habilita;
            cd_localfaz.Enabled = habilita;
            bb_localfaz.Enabled = habilita;
            vl_unitario.Enabled = habilita;
            ds_obsfazenda.Enabled = habilita;
        }

        public void HabilitaFazenda(bool habilita)
        {
            id_area.Enabled = habilita;
            bb_area.Enabled = habilita;
            id_talhao.Enabled = habilita;
            bb_talhao.Enabled = habilita;
            id_plantio.Enabled = habilita;
            bb_plantio.Enabled = habilita;
            vl_unitario.Enabled = habilita;
            ds_obsfazenda.Enabled = habilita;
        }

        public override void afterCancela()
        {
            if (TpModo == TTpModo.tm_Insert)
            {
                bsClassificacao.Clear();
                bsPesagemGraos.Clear();
            }            
            TpModo = TTpModo.tm_Standby;
            modoBotoes();
            ativaPage(string.Empty, string.Empty);
            pTopDireito.HabilitarControls(false, TpModo);
            pTopEsquerdo.HabilitarControls(false, TpModo);
            pPesagemGraos.HabilitarControls(false, TpModo);
            pClassif.HabilitarControls(false, TpModo);
            afterBusca();
        }

        public override void afterGrava()
        {
            try
            {
                base.afterGrava();
            }
            catch
            {
                return;
            }
            if (validaGravaPsGraos())
            {
                //VALIDAR PESAGEM TIPO TRANSBORDO
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool)
                {
                    //Se tipo de pesagem for Transbordo
                    if ((ps_bruto.Value > 0) && (ps_tara.Value > 0) &&
                        ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ?
                         TCN_LanTransbordo.Buscar(0, string.Empty, 0, string.Empty,
                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.Value,
                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                  0, string.Empty).Count < 1 :
                         TCN_LanTransbordo.Buscar(0, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.Value,
                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                  string.Empty,
                                                  0,
                                                  string.Empty,
                                                  0, string.Empty).Count < 1))
                    {
                        TFLan_Transbordo fTransbordo = new TFLan_Transbordo();
                        try
                        {
                            fTransbordo.Cd_empresa = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa;
                            fTransbordo.Id_ticket = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.Value;
                            fTransbordo.Tp_pesagem = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem;
                            fTransbordo.Cd_tabeladesconto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto;
                            fTransbordo.Cd_produto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_produto;
                            fTransbordo.Tp_movimento = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento;
                            fTransbordo.Ps_liqTicket = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_liquido;
                            if (fTransbordo.ShowDialog() == DialogResult.OK)
                                for (int i = 0; i < fTransbordo.bsTransbordo.Count; i++)
                                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lTransbordo.Add(fTransbordo.bsTransbordo[i] as TRegistro_LanTransbordo);
                            else
                            {
                                MessageBox.Show("Obrigatorio informar ticket de transbordo para concluir pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        finally
                        {
                            fTransbordo.Dispose();
                        }
                    }
                }
                else
                {
                    //Devolver embalagens para o estoque
                    if ((ps_bruto.Value > 0) &&
                        (ps_tara.Value > 0) &&
                        (qtd_embalagem.Value > 0) &&
                        ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper() != "R") &&
                        (!string.IsNullOrEmpty(nr_Contrato.Text)))
                    {
                        //Buscar registro Contrato
                        TList_CadContrato lContrato = TCN_CadContrato.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr,
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
                                                                             string.Empty,
                                                                             "A",
                                                                             string.Empty,
                                                                             1,
                                                                             null);
                        if (lContrato.Count > 0)
                            using (TFEmbalagem fEmbalagem = new TFEmbalagem())
                            {
                                fEmbalagem.Tp_mov = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? "E" : "S";
                                fEmbalagem.Cd_empresa = CD_Empresa.Text;
                                fEmbalagem.Nm_empresa = NM_Empresa.Text;
                                fEmbalagem.Cd_produto = lContrato[0].Cd_produtoembalagem;
                                fEmbalagem.Ds_produto = lContrato[0].Ds_produtoembalagem;
                                fEmbalagem.Sigla_unidade = lContrato[0].Sigla_undembalagem;
                                fEmbalagem.Cd_local = lContrato[0].Cd_localembalagem;
                                fEmbalagem.Ds_local = lContrato[0].Ds_localembalagem;
                                fEmbalagem.Qtd_entrada = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? qtd_embalagem.Value : decimal.Zero;
                                fEmbalagem.Qtd_saida = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? decimal.Zero : qtd_embalagem.Value;
                                fEmbalagem.Ds_observacao = "DEVOLUCAO DE EMBALAGEM CONFORME TICKET Nº " + ID_Ticket.Text;
                                if (fEmbalagem.ShowDialog() == DialogResult.OK)
                                    if (fEmbalagem.rEstoque != null)
                                    {
                                        fEmbalagem.rEstoque.Tp_lancto = "N";
                                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).rEstEmbalagem = fEmbalagem.rEstoque;
                                    }
                            }
                    }
                }
                if (TpModo.Equals(TTpModo.tm_Edit))
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao.ForEach(p => p.Dt_classif = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Dt_bruto);
                try
                {
                    string msg = string.Empty;

                    TCN_LanPesagemGraos.Gravar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos), null);
                    TpModo = TTpModo.tm_Standby;
                    bsPesagemGraos.ResetCurrentItem();
                    if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("R"))
                        msg = "Pesagem Refugada por conter classificação fora dos padrões aceitaveis.";
                    else if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                        msg = "Pesagem Finalizada com Sucesso.";
                    else
                        msg = "Pesagem Realizada com sucesso!";

                    bsPesagemGraos.DataSource = TCN_LanPesagemGraos.Busca((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                          (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                          (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          string.Empty, 
                                                                          0, 
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          0, 
                                                                          string.Empty, 
                                                                          null);
                    bsPesagemGraos_PositionChanged(this, new EventArgs());
                    if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                        tcPesagemGraos.TabPages.Add(tpBuscaPsGraos);
                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Configuraçoes de tela
                    modoBotoes();
                    HabilitaCamposFazenda(false);
                    pTopEsquerdo.HabilitarControls(false, TpModo);
                    pPesagemGraos.HabilitarControls(false, TpModo);

                    if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                        tcPesagemGraos.SelectedTab = tpPsGraos;
                    ProcessarDesdobroEspecial();
                    //Aplicar pesagem automaticamente
                    if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("F") &&
                        (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APLIC_PSAUTO", 
                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa, null).Trim().ToUpper().Equals("S") ||
                        ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo.Trim().ToUpper().Equals("F") &&
                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("S"))))
                        AplicarPesagem();
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        public override void afterExclui()
        {
            if (bsPesagemGraos.Current != null)
                if (MessageBox.Show("Confirma Exclusão da Pesagem?\r\n\r\n" +
                                   "Empresa.....: " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa + "\r\n" +
                                   "Ticket......: " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString() + "\r\n" +
                                   "TP. Pesagem.: " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem, "Questionamento",
                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    InputBox ibp = new InputBox();
                    ibp.Text = "Motivo Cancelamento Pesagem";
                    string motivo = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(motivo))
                    {
                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_motivocancelamento = motivo;
                    try
                    {
                        TCN_LanPesagemGraos.Excluir((bsPesagemGraos.Current as TRegistro_LanPesagemGraos), null);
                        bsPesagemGraos.RemoveCurrent();
                        ativaPage(string.Empty, string.Empty);
                        MessageBox.Show("Pesagem excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        public override void afterBusca()
        {
            bsPesagemGraos.DataSource = TCN_LanPesagemGraos.Busca(CD_EmpBuscaPSGraos.Text, 
                                                                  id_ticketBuscaPsGraos.Text, 
                                                                  placaCarretaBuscaPsGraos.Text,
                                                                  nr_contrato_busca.Text,
                                                                  cd_prodBuscaPsGraos.Text, 
                                                                  cd_tabDescBuscaPsGraos.Text, 
                                                                  dt_iniBuscaPsGraos.Text,
                                                                  dt_finBuscaPsGraos.Text, 
                                                                  cbEntrada.Checked, 
                                                                  cbSaida.Checked, 
                                                                  cbPesagemAberta.Checked,
                                                                  cbPesagemFechada.Checked, 
                                                                  cbPesagemCancelada.Checked,
                                                                  cbRefugado.Checked,
                                                                  Parametros.pubLogin, 
                                                                  cd_local_busca.Text, 
                                                                  cd_contratante_busca.Text,
                                                                  string.Empty,
                                                                  anosafra_busca.Text,
                                                                  ST_SaldoAplicar.Checked, 
                                                                  false, 
                                                                  st_PsFazenda.Checked,
                                                                  tp_transbordo_busca.Checked ? "S" : string.Empty,
                                                                  0, 
                                                                  string.Empty, 
                                                                  null);
            bsPesagemGraos_PositionChanged(this, new EventArgs());
            if (tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                tcPesagemGraos.SelectedTab = tpBuscaPsGraos;
        }

        public override void afterImprime()
        {
            if (bsPesagemGraos.Current != null)
            {
                //Verificar se a impressao e DOS ou GRAFICA
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Parametros.pubTerminal.Trim() + "'"
                                    }
                                }, "TP_ImpTick");
                if (obj == null)
                {
                    MessageBox.Show("Obrigatorio informar terminal para realizar pesagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (obj.ToString().Trim().ToUpper().Equals("G") ||
                    obj.ToString().Trim().ToUpper().Equals("R"))
                {
                    //Buscar Configuracao para impressao do laudo
                    bool st_laudo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("IMP_LAUDO_DESCARGA",
                                                                                         (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                         null).Trim().ToUpper().Equals("S");
                    FormRelPadrao.Relatorio rel = new FormRelPadrao.Relatorio();
                    try
                    {
                        rel.Altera_Relatorio = Altera_Relatorio;
                        DTS = new BindingSource();
                        bsPesagemGraos_PositionChanged(this, new EventArgs());
                        DTS.DataSource = new TList_RegLanPesagemGraos() { bsPesagemGraos.Current as TRegistro_LanPesagemGraos };
                        rel.DTS_Relatorio = DTS;
                        rel.Nome_Relatorio = Name;
                        rel.NM_Classe = Name;
                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("A") && st_laudo)
                            rel.Ident = "REL_LAUDO_CARGA_DESCARGA";
                        else if (obj.ToString().Trim().ToUpper().Equals("G"))
                            rel.Ident = "REL_IMPTICKET_GRAOS";
                        else rel.Ident = "REL_IMPTICKET_GRAOS_REDUZIDO";
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NM_Contratante.Trim();
                            fImp.pMensagem = "IMPRESSÃO TICKET Nº " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString();
                            if (Altera_Relatorio)
                            {
                                rel.Gera_Relatorio((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                    fImp.pSt_imprimir,
                                                    fImp.pSt_visualizar,
                                                    fImp.pSt_enviaremail,
                                                    fImp.pSt_exportPdf,
                                                    fImp.Path_exportPdf,
                                                    fImp.pDestinatarios,
                                                    null,
                                                    "IMPRESSÃO TICKET Nº " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                    fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                            else
                            {
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    rel.Gera_Relatorio(string.Empty,
                                                      fImp.pSt_imprimir,
                                                      fImp.pSt_visualizar,
                                                      fImp.pSt_enviaremail,
                                                      fImp.pSt_exportPdf,
                                                      fImp.Path_exportPdf,
                                                      fImp.pDestinatarios,
                                                      null,
                                                      "IMPRESSÃO TICKET Nº " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                      fImp.pDs_mensagem);
                            }
                        }
                    }
                    finally
                    { rel = null; }
                }
                else 
                    TCN_LanPesagemGraos.ImprimirTicket(bsPesagemGraos.Current as TRegistro_LanPesagemGraos);
            }
            else
                MessageBox.Show("Necessario selecionar registro para imprimir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void AplicarPesagem()
        {
            if (bsPesagemGraos.Current != null)
            {
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("F"))
                {
                    if (!string.IsNullOrEmpty((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr))
                    {
                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool)
                        {
                            MessageBox.Show("Não é permitido aplicar pesagem transbordo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo.Trim().ToUpper().Equals("F") &&
                            (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E"))
                        {
                            MessageBox.Show("Não é permitido aplicar pesagem fazenda de entrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Verificar se a pesagem tem aplicacao
                        if(new TCD_LanAplicacaoPedido().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_ticket",
                                    vOperador = "=",
                                    vVL_Busca = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_pesagem",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem.Trim() + "'"
                                }
                            }, "1") != null)
                        {
                            MessageBox.Show("Pesagem ja se encontra aplicada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E"))
                        {
                            if (string.IsNullOrEmpty((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Nr_notaprodutor))
                            {
                                MessageBox.Show("Não é permitido aplicar pesagem sem nota fiscal do produtor.\r\n" +
                                                "Altere a pesagem para informar o numero da nota do produtor.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if(!(bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Dt_venctonfprodutor.HasValue)
                            {
                                MessageBox.Show("Não é permitido aplicar pesagem sem informar data vencimento da nota do produtor.\r\n" +
                                                "Altere a pesagem para informar data vencimento da nota do produtor.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("S"))
                        {
                            if (new TCD_CadContrato().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_contrato",
                                        vOperador = "=",
                                        vVL_Busca = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_exigirautorizretirada, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null)
                            {
                                //Verificar se foi informado autorizacao de retirada
                                if (string.IsNullOrEmpty(cd_autoriz.Text))
                                {
                                    MessageBox.Show("Contrato Nº " + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr + ", " +
                                                    "exige autorização de retirada para gerar aplicação.", "Mensagem", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                    cd_autoriz.Focus();
                                    return;
                                }
                                //Verificar se autorizacao de retirada informado tem saldo suficiente para gerar aplicacao
                                if (!ProcessaAplicacao.VerificarSaldoAutoriz(cd_autoriz.Text, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_liquido))
                                {
                                    MessageBox.Show("Autorização de retirada não tem saldo suficiente para gerar aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cd_autoriz.Focus();
                                    return;
                                }
                            }
                        }
                        
                        if (MessageBox.Show("Confirma aplicação da pesagem selecionada?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            try
                            {
                                TList_RegLanFaturamento lNotas = ProcessaAplicacao.ProcessarAplicacao(false,
                                                                                                      (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_Aplicar,
                                                                                                      new List<TRegistro_LanPesagemGraos>() { bsPesagemGraos.Current as TRegistro_LanPesagemGraos });
                                TCN_LanAplicacaoPedido.ProcessarAplicacaoPedido(lNotas,
                                                                                ps_liquido.Value,
                                                                                null);
                                List<TRegistro_LanFaturamento> lNfe = lNotas.FindAll(p => p.Cd_modelo.Trim().Equals("55") && p.Tp_nota.Trim().ToUpper().Equals("P"));
                                List<TRegistro_LanFaturamento> lNfImp = lNotas.FindAll(p => (!p.Cd_modelo.Trim().Equals("55")) && p.Tp_nota.Trim().ToUpper().Equals("P"));
                                if(lNfe.Count.Equals(0) && lNfImp.Count.Equals(0))
                                    MessageBox.Show("Aplicação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if(lNfImp.Count > 0)
                                    if (MessageBox.Show("Aplicação realizada com sucesso.\r\nDeseja imprimir as notas fiscais?", "Pergunta",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                    {
                                        lNfImp.ForEach(p =>
                                        {
                                            //Buscar nota fiscal
                                            TList_RegLanFaturamento lNf =
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(p.Cd_empresa,
                                                                                                              p.Nr_notafiscalstr,
                                                                                                              p.Nr_serie,
                                                                                                              p.Nr_lanctofiscalstr,
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
                                            {
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
                                        });
                                    }
                                if (lNfe.Count > 0)
                                {
                                    if (MessageBox.Show("Deseja enviar NFe para receita?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            lNfe.ForEach(p =>
                                                {
                                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                    {
                                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(p.Cd_empresa,
                                                                                                                                        p.Nr_lanctofiscalstr,
                                                                                                                                        null);
                                                        fGerNfe.ShowDialog();
                                                    }
                                                });
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                    else
                        MessageBox.Show("Permitido aplicar somente pesagem com contrato.\r\n" +
                                        "Altere a pesagem e informe o numero do contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Permitido aplicar somente pesagem com status <FECHADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe pesagem selecionada para aplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void ProcessarTicketReprovados()
        {
            if (bsPesagemGraos.Current != null)
            {
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("R"))
                {
                    if (MessageBox.Show("Confirma processamento do ticket refugado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Devolver embalagens para o estoque
                        if ((ps_bruto.Value > 0) &&
                            (ps_tara.Value > 0) &&
                            (qtd_embalagem.Value > 0) &&
                            (!string.IsNullOrEmpty(nr_Contrato.Text)))
                        {
                            //Buscar registro Contrato
                            TList_CadContrato lContrato = TCN_CadContrato.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr,
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
                                                                                 string.Empty,
                                                                                 "A",
                                                                                 string.Empty,
                                                                                 1,
                                                                                 null);
                            if (lContrato.Count > 0)
                                using (TFEmbalagem fEmbalagem = new TFEmbalagem())
                                {
                                    fEmbalagem.Tp_mov = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? "E" : "S";
                                    fEmbalagem.Cd_empresa = CD_Empresa.Text;
                                    fEmbalagem.Nm_empresa = NM_Empresa.Text;
                                    fEmbalagem.Cd_produto = lContrato[0].Cd_produtoembalagem;
                                    fEmbalagem.Ds_produto = lContrato[0].Ds_produtoembalagem;
                                    fEmbalagem.Sigla_unidade = lContrato[0].Sigla_undembalagem;
                                    fEmbalagem.Cd_local = lContrato[0].Cd_localembalagem;
                                    fEmbalagem.Ds_local = lContrato[0].Ds_localembalagem;
                                    fEmbalagem.Qtd_entrada = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? qtd_embalagem.Value : decimal.Zero;
                                    fEmbalagem.Qtd_saida = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E") ? decimal.Zero : qtd_embalagem.Value;
                                    fEmbalagem.Ds_observacao = "DEVOLUCAO DE EMBALAGEM CONFORME TICKET Nº " + ID_Ticket.Text;
                                    if (fEmbalagem.ShowDialog() == DialogResult.OK)
                                        if (fEmbalagem.rEstoque != null)
                                        {
                                            fEmbalagem.rEstoque.Tp_lancto = "N";
                                            (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).rEstEmbalagem = fEmbalagem.rEstoque;
                                        }
                                }
                        }
                        try
                        {
                            TCN_LanPesagemGraos.ProcessarTicketRefugado(bsPesagemGraos.Current as TRegistro_LanPesagemGraos, null);
                            bsPesagemGraos.ResetCurrentItem();
                            string msg = string.Empty;
                            if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("R"))
                                msg = "Pesagem Refugada por conter classificação fora dos padrões aceitaveis.";
                            else if ((ps_bruto.Value > 0) && (ps_tara.Value > 0))
                                msg = "Pesagem Finalizada com Sucesso.";
                            else
                                msg = "Pesagem Realizada com sucesso!";

                            bsPesagemGraos.DataSource = TCN_LanPesagemGraos.Busca((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  null);
                            if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                                tcPesagemGraos.TabPages.Add(tpBuscaPsGraos);
                            bsPesagemGraos.ResetCurrentItem();
                            MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TpModo = TTpModo.tm_Standby;
                            ativaPage((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento);

                            modoBotoes();
                            HabilitaCamposFazenda(false);
                            pTopEsquerdo.HabilitarControls(false, TpModo);
                            pPesagemGraos.HabilitarControls(false, TpModo);

                            if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.SelectedTab = tpPsGraos;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido processar somente ticket com status <REFUGADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe pesagem selecionada para processar ticket refugado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void RefugarTicket()
        {
            if (bsPesagemGraos.Current != null)
            {
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().Equals("A"))
                {
                    try
                    {
                        if (MessageBox.Show("Confirma Refugo da Pesagem?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                        {
                            (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro = "R";
                            TCN_LanPesagemGraos.Gravar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos), null);
                            MessageBox.Show("Pesagem refugada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsPesagemGraos.DataSource = TCN_LanPesagemGraos.Busca((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                  (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  null);
                            if (!tcPesagemGraos.TabPages.Contains(tpBuscaPsGraos))
                                tcPesagemGraos.TabPages.Add(tpBuscaPsGraos);
                            bsPesagemGraos.ResetCurrentItem();

                            TpModo = TTpModo.tm_Standby;
                            ativaPage((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento);

                            modoBotoes();
                            HabilitaCamposFazenda(false);
                            pTopEsquerdo.HabilitarControls(false, TpModo);
                            pPesagemGraos.HabilitarControls(false, TpModo);

                            if (tcPesagemGraos.TabPages.Contains(tpPsGraos))
                                tcPesagemGraos.SelectedTab = tpPsGraos;
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("Erro refugar pesagem: " + ex.Message);
                    }
                }
                else
                    MessageBox.Show("Permitido refugar somente ticket em aberto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar pesagem para refugar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void CapturarImagem()
        {
            using (TFLanFotosPesagem fFotos = new TFLanFotosPesagem())
            {
                fFotos.St_capturar = TpModo.Equals(TTpModo.tm_Insert) || TpModo.Equals(TTpModo.tm_Edit);
                fFotos.ShowDialog();
                if (fFotos.St_capturar)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lFotosPesagem = fFotos.lFotos;
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lFotosPesagemExcluir = fFotos.lFotosExcluir;
                }
            }
        }

        public override void DesdobrarTicket()
        {
            if (bsPesagemGraos.Current != null)
            {
                if (!(bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Permitido desdobrar somente TICKET FECHADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ps_Aplicar.Equals(decimal.Zero))
                {
                    MessageBox.Show("TICKET sem saldo para DESDOBRAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDesdobrarTicket fDesdobrar = new TFDesdobrarTicket())
                {
                    fDesdobrar.rPsGraos = bsPesagemGraos.Current as TRegistro_LanPesagemGraos;
                    if(fDesdobrar.ShowDialog() == DialogResult.OK)
                        try
                        {
                            List<TRegistro_LanPesagemGraos> lTicketDest = TCN_LanPesagemGraos.DesdobrarTicket(fDesdobrar.rPsGraos,
                                                                                                              fDesdobrar.lDesdobros,
                                                                                                              null);
                            string msg = string.Empty;
                            string virg = string.Empty;
                            lTicketDest.ForEach(p =>
                                {
                                    msg += virg + p.Id_ticketstr;
                                    virg = ",";
                                });
                            MessageBox.Show("Desdobro gravado com sucesso.\r\n" +
                                            "Ticket(s) gerados: " + msg.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar TICKET para desdobrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void ProcessarDesdobroEspecial()
        {
            if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).St_registro.Trim().ToUpper().Equals("F"))
            {
                //Verificar se contrato esta configurado para desdobro especial
                TList_Contrato_X_DesdEspecial lDesd =
                TCN_Contrato_X_DesdEspecial.Buscar(string.Empty,
                                                   (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).NR_ContratoStr,
                                                   string.Empty,
                                                   null);
                if (lDesd.Count.Equals(0))
                    return;
                //Verificar se a pesagem tem aplicacao
                if (new TCD_LanAplicacaoPedido().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_ticket",
                            vOperador = "=",
                            vVL_Busca = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_pesagem",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem.Trim() + "'"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Pesagem ja se encontra aplicada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se pesagem ja possui desdobro processado
                if (new TCD_DesdobroPesagem().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa_orig",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_pesagem_orig",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_ticket_orig",
                            vOperador = "=",
                            vVL_Busca = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticketstr
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Pesagem ja possui desdobro especial processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma processamento do desdobro especial?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        using (TFDesdobrarTicket fDesdobrar = new TFDesdobrarTicket())
                        {
                            fDesdobrar.rPsGraos = bsPesagemGraos.Current as TRegistro_LanPesagemGraos;
                            fDesdobrar.lDesdobroEspecial = lDesd;
                            if (fDesdobrar.ShowDialog() == DialogResult.OK)
                            {
                                List<TRegistro_LanPesagemGraos> lTicketDest = TCN_LanPesagemGraos.DesdobrarTicket(fDesdobrar.rPsGraos,
                                                                                                                  fDesdobrar.lDesdobros,
                                                                                                                  null);
                                string msg = string.Empty;
                                string virg = string.Empty;
                                lTicketDest.ForEach(p =>
                                {
                                    msg += virg + p.Id_ticketstr;
                                    virg = ",";
                                });
                                MessageBox.Show("Desdobro especial processado com sucesso.\r\n" +
                                                "Ticket(s) gerados: " + msg.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        public override void TrocarContrato()
        {
            using (TFTrocarContrato fTrocar = new TFTrocarContrato())
            {
                if(fTrocar.ShowDialog() == DialogResult.OK)
                    if(fTrocar.lPesagem != null)
                        if(fTrocar.lPesagem.Count > 0)
                            try
                            {
                                CamadaNegocio.Balanca.TCN_LanPesagemGraos.TrocarContratoTicket(fTrocar.pNr_contrato_dest, fTrocar.lPesagem, null);
                                MessageBox.Show("Troca de contrato realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private bool validaGravaPsGraos()
        {
            bool retorno = true;
                        
            if (placaCarreta.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar placa.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                placaCarreta.Focus();
                return false;
            }
            if (TP_Movimento.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar tipo de movimento.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                TP_Movimento.Focus();
                return false;
            }
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return false;
            }

            if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo.Trim().ToUpper().Equals("F") &&
                (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento.Trim().ToUpper().Equals("E"))
            {
                if (string.IsNullOrEmpty(id_area.Text))
                {
                    MessageBox.Show("Obritatório informar area fazenda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_area.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(id_talhao.Text))
                {
                    MessageBox.Show("Obrigatório informar talhão fazenda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_talhao.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(id_plantio.Text))
                {
                    MessageBox.Show("Obrigatório informar plantio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_plantio.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cd_tabdescfaz.Text))
                {
                    MessageBox.Show("Obrigatório informar tabela desconto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_tabdescfaz.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cd_localfaz.Text))
                {
                    MessageBox.Show("Obrigatório informar local armazenagem", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_localfaz.Focus();
                    return false;
                }
                if (vl_unitario.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatório informar valor unitario para dar entrada no estoque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_unitario.Focus();
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cd_tabeladesconto.Text))
                {
                    MessageBox.Show("Obrigatório informar tabela de desconto.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_tabeladesconto.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cd_produto.Text))
                {
                    MessageBox.Show("Obrigatório informar produto.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_produto.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(CD_Local.Text))
                {
                    MessageBox.Show("Obrigatório informar local de armazenagem.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Local.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(anosafra.Text))
                {
                    MessageBox.Show("Obrigatório informar ano safra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    anosafra.Focus();
                    return false;
                }   
            }

            return retorno;
        }

        private void ativaCampos()
        {
            if (TpModo == TTpModo.tm_Standby)
            {
                pTopEsquerdo.HabilitarControls(false, TpModo);
                pTopDireito.HabilitarControls(false, TpModo);
                pPesagemGraos.HabilitarControls(false, TpModo);
                pNfProdutor.HabilitarControls(false, TpModo);
            }
            else if (TpModo == TTpModo.tm_Insert)
            {
                placaCarreta.Enabled = false;
                BB_PlacaCarreta.Enabled = false;
                CD_Empresa.Enabled = true;
                BB_Empresa.Enabled = true;
                TP_Pesagem.Enabled = true;
                bb_tppesagem.Enabled = true;
                ID_Ticket.Enabled = (VST_SeqManual == "S");
                cbProtocolo.Enabled = true;
                pPesagemGraos.HabilitarControls(true, TpModo);
                pNfProdutor.HabilitarControls(true, TpModo);
            }
            else if (TpModo == TTpModo.tm_Edit)
            {
                pTopEsquerdo.HabilitarControls(false, TpModo);
                pTopDireito.HabilitarControls(false, TpModo);
                pPesagemGraos.HabilitarControls(true, TpModo);
                pNfProdutor.HabilitarControls(true, TpModo);
            }
        }

        private void ativarDadosClassif(bool val)
        {
            gClassifPsGraos.Enabled = val && PERMITE_CLASSIF;
            pClassif.Enabled = val && PERMITE_CLASSIF;
            BT_Classificacao.Enabled = val && PERMITE_CLASSIF;
            pc_resultado_local.Enabled = val && PERMITE_CLASSIF;
            pc_resultado_origdest.Enabled = val && PERMITE_CLASSIF;
            ps_amostra.Enabled = val && PERMITE_CLASSIF;
            ps_referencia.Enabled = val && PERMITE_CLASSIF;
        }

        private void limparCampos()
        {
            VTP_MovDefault = string.Empty;
            VOrdemPesagem = string.Empty;
            VST_SeqManual = string.Empty;
            if (tcPesagemGraos.Equals(tpPsGraos))
            {
                pTopDireito.LimparRegistro();
                pTopEsquerdo.LimparRegistro();
                pPesagemGraos.LimparRegistro();
            }
            else if (tcPesagemGraos.Equals(tpBuscaPsGraos))
                pBuscaPsGraos.LimparRegistro();
            else if (tcPesagemGraos.Equals(tpClassifGraos))
                pClassif.LimparRegistro();
            cbPesagemAberta.Checked = true;
            cbPesagemFechada.Checked = true;
        }

        private void BB_PlacaCarreta_Click(object sender, EventArgs e)
        { 
            string vColunas = "a.placaCarreta|Placa|80;" +
                                  "a.TP_Movimento|TP. Movimento|80;" +
                                  "a.CD_Empresa|Cód. Empresa|80;" +
                                  "f.CD_Produto|Cód. Produto|80;" +
                                  "l.CD_Local|Local Arm.|80;" +
                                  "l.CD_TabelaDesconto|Tab. Desconto|80";
            string vParamFixo = "isnull(a.ST_Registro, 'A')|in|('A', 'R');" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaCarreta }, new TCD_LanPesagemGraos(),
                                    vParamFixo);
            placaCarreta_Leave(this, e);
        }

        private void placaCarreta_Leave(object sender, EventArgs e)
        {
            if (controlePlaca)
            {
                controlePlaca = false;

                if (!string.IsNullOrEmpty(placaCarreta.Text))
                {
                    TList_RegLanPesagemGraos lpsgraos = TCN_LanPesagemGraos.Busca(string.Empty, 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  placaCarreta.Text, 
                                                                                  "'A', 'R'", 
                                                                                  string.Empty, 
                                                                                  Parametros.pubLogin, 
                                                                                  string.Empty, 
                                                                                  0, 
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1, 
                                                                                  string.Empty, 
                                                                                  null);
                    if (lpsgraos.Count > 0)
                    {
                        //Buscar classificacao
                        lpsgraos[0].Classificacao = TCN_LanClassificacao.Buscar(lpsgraos[0].Cd_empresa,
                                                                                lpsgraos[0].Id_ticket.ToString(),
                                                                                lpsgraos[0].Tp_pesagem,
                                                                                string.Empty,
                                                                                lpsgraos[0].Cd_tabeladesconto,
                                                                                0, string.Empty, null);
                        ps_bruto.Value = 0;
                        ps_tara.Value = 0;
                        ps_liquido.Value = 0;
                        bsPesagemGraos.DataSource = lpsgraos;
                        St_PesagemClassif = (ps_bruto.Value.Equals(0) && ps_tara.Value.Equals(0));
                        CD_Empresa.Enabled = false;
                        BB_Empresa.Enabled = false;
                        cd_produto.Enabled = false;
                        BB_Produto.Enabled = false;
                        placaCarreta.Enabled = false;
                        TpModo = TTpModo.tm_Edit;
                        vST_FecharPesagem = true;
                        modoBotoes();
                        ativaCampos();
                        if (nr_Contrato.Text.Trim() != string.Empty)
                            nr_Contrato_Leave(this, new EventArgs());
                        cd_autoriz.Enabled = false;
                        bb_autoriz.Enabled = false;
                        cbProtocolo.Enabled = true;
                        nr_Contrato.Enabled = ((nr_Contrato.Text.Trim().Equals(string.Empty)) && (!(bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool));
                        bb_Contrato.Enabled = ((nr_Contrato.Text.Trim().Equals(string.Empty)) && (!(bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool));
                        nm_contratante.Enabled = CD_Contratante.Text.Trim().Equals(string.Empty);
                        cd_tabeladesconto_Leave(this, new EventArgs());
                        cd_produto_Leave(this, new EventArgs());                        
                        TP_Pesagem.Text = lpsgraos[0].Tp_pesagem;
                        TPPesagem();
                        nr_Contrato_Leave(this, e);
                        cd_produto_Leave(this, e);
                    }
                    else
                    {
                        ativaCampos();
                        cd_autoriz.Enabled = false;
                        bb_autoriz.Enabled = false;
                        nr_Contrato.Enabled = true;
                        bb_Contrato.Enabled = true;                        
                        CD_Empresa.Focus();
                    }
                }

                controlePlaca = true;
            }
        }

        private void CD_Empresa_TextChanged(object sender, EventArgs e)
        {
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                CD_Local.Clear();
                ds_local.Clear();
                cd_moega.Clear();
                ds_moega.Clear();
            }
        }

        private void bb_tppesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_TPPesagem|Tipo Pesagem|350;" +
                              "TP_Pesagem|TP. Pesagem|100;" +
                              "b.DS_Protocolo|Protocolo Balança|100;" +
                              "a.CD_Protocolo|Cd. Protocolo|60";
            string vParamFixo = "TP_Modo|IN|('G','F');" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TCD_CadTpPesagem(), vParamFixo);
            if (linha != null)
            {
                TPPesagem();
                bsPesagemGraos.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                bsPesagemGraos.ResetCurrentItem();
            }
        }

        private void TP_Pesagem_Leave(object sender, EventArgs e)
        {
            TPPesagem();
        }

        private void TPPesagem()
        {
            string vColunas = TP_Pesagem.NM_CampoBusca + "|=|'" + TP_Pesagem.Text + "';" +
                              "TP_Modo|IN|('G','F');" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_tppesagem x " +
                                "           where x.tp_pesagem = a.tp_pesagem " +
                                "           and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "           (EXISTS(select 1 from tb_div_usuario_x_grupos y " +
                                "                   where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            DataRow retorno = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Pesagem, NM_TpPesagem },
                                    new TCD_CadTpPesagem());

            if (retorno != null)
            {
                if (cbProtocolo.Items.Count > 0)
                {
                    if ((cbProtocolo.DataSource as CamadaDados.Diversos.TList_RegCadProtocolo).Exists(p => p.Cd_protocolo.Trim().Equals(retorno["cd_protocolo"].ToString())))
                    {
                        cbProtocolo.SelectedIndex = (cbProtocolo.DataSource as CamadaDados.Diversos.TList_RegCadProtocolo).FindIndex(p => p.Cd_protocolo.Trim().Equals(retorno["cd_protocolo"].ToString()));
                        cbProtocolo.Enabled = false;
                    }
                }
                if (bsPesagemGraos.Current != null)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo = retorno["tp_modo"].ToString();
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento = retorno["tp_movdefault"].ToString();
                    ativaPage((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento);
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordo = retorno["TP_Transbordo"].ToString().Trim();
                    bsPesagemGraos.ResetCurrentItem();
                }
                if ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_transbordobool)
                {
                    nr_Contrato.Enabled = false;
                    bb_Contrato.Enabled = false;
                }
                VOrdemPesagem = retorno["OrdemPesagem"].ToString().Trim();
                VTP_MovDefault = retorno["TP_MovDefault"].ToString().Trim();
                VST_SeqManual = retorno["ST_SeqManual"].ToString().Trim();
                ID_Ticket.Enabled = retorno["ST_SeqManual"].ToString().Trim().Equals("S");
                HabilitaCamposFazenda(retorno["tp_modo"].ToString().Trim().ToUpper().Equals("F"));
                HabilitaFazenda(retorno["tp_modo"].ToString().Trim().ToUpper().Equals("F"));
                rgnfProdutorRural.Visible = retorno["tp_movdefault"].ToString().Trim().ToUpper().Equals("E");
                bsPesagemGraos.ResetCurrentItem();
            }
            else
            {
                VOrdemPesagem = string.Empty;
                VTP_MovDefault = string.Empty;
                VST_SeqManual = string.Empty;
                TP_Movimento.SelectedIndex = -1;
                ID_Ticket.Enabled = false;
                rgnfProdutorRural.Visible = false;
                bsPesagemGraos.ResetCurrentItem();
            }
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|=|'A';" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";

            if (!string.IsNullOrEmpty(cd_tabeladesconto.Text))
                vParamFixo += ";a.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_Contratante.Text))
                vParamFixo += ";a.cd_clifor|=|'" + CD_Contratante.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(anosafra.Text))
                vParamFixo += ";a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_Contrato, CD_Contratante, nm_contratante }, vParamFixo);
            if (linha != null)
            {
                tp_movtopedido = linha["Tp_movimento"].ToString();
                if (!string.IsNullOrEmpty(linha["tp_prodcontrato"].ToString()) && tp_prodpesagem.SelectedValue == null)
                {
                    tp_prodpesagem.SelectedValue = linha["tp_prodcontrato"];
                    tp_prodpesagem.Enabled = linha["tp_prodcontrato"].ToString().Trim().ToUpper().Equals("CV") ||
                                                linha["tp_prodcontrato"].ToString().Trim().ToUpper().Equals("TR");
                }
                cd_autoriz.Enabled = TP_Movimento.Text.ToUpper().Equals("SAIDA");
                bb_autoriz.Enabled = TP_Movimento.Text.ToUpper().Equals("SAIDA");

                CD_Contratante.Text = linha["cd_clifor"].ToString();
                nm_contratante.Text = linha["Nm_clifor"].ToString();
                CD_Contratante.Enabled = false;
                bb_contratante.Enabled = false;
                nm_contratante.Enabled = false;
                CD_EndContratante.Text = linha["Cd_endereco"].ToString();

                cd_tabeladesconto.Text = linha["Cd_tabeladesconto"].ToString();
                cd_tabeladesconto.Enabled = false;
                BB_TabelaDesconto.Enabled = false;
                cd_tabeladesconto_Leave(this, e);
                cd_produto.Text = linha["Cd_Produto"].ToString();
                cd_produto_Leave(this, e);

                anosafra.Text = linha["Anosafra"].ToString();
                anosafra.Enabled = false;
                BB_AnoSafra.Enabled = false;
                anosafra_Leave(this, e);
                CD_Local.Text = linha["cd_local"].ToString();
                ds_local.Text = linha["ds_local"].ToString();
            }
            else
            {
                tp_movtopedido = string.Empty;
                tp_prodpesagem.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(nr_Contrato.Text))
                    nr_Contrato.Clear();
                if (TpModo == TTpModo.tm_Insert)
                {
                    cd_produto.Clear();
                    ds_produto.Clear();
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto = string.Empty;
                    ds_tabeladesconto.Clear();
                    anosafra.Clear();
                    ds_safra.Clear();
                }
                cd_produto.Enabled = true;
                BB_Produto.Enabled = true;
                cd_tabeladesconto.Enabled = true;
                BB_TabelaDesconto.Enabled = true;
                anosafra.Enabled = true;
                BB_AnoSafra.Enabled = true;
            }
        }

        private void nr_Contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_Contrato.Text + ";" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|=|'A';" +
                            "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))));" +
                                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_tabeladesconto.Text))
                vParam += ";a.CD_TabelaDesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_Contratante.Text))
                vParam += ";a.cd_clifor|=|'" + CD_Contratante.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(anosafra.Text))
                vParam += ";a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_Contrato, CD_Contratante, nm_contratante },
                            new TCD_CadContrato());
            
            if (linha != null)
            {
                tp_movtopedido = linha["Tp_movimento"].ToString();
                if (!string.IsNullOrEmpty(linha["tp_prodcontrato"].ToString()) && tp_prodpesagem.SelectedValue == null)
                {
                    tp_prodpesagem.SelectedValue = linha["tp_prodcontrato"];
                    tp_prodpesagem.Enabled = linha["tp_prodcontrato"].ToString().Trim().ToUpper().Equals("CV") ||
                                                linha["tp_prodcontrato"].ToString().Trim().ToUpper().Equals("TR");
                }
                cd_autoriz.Enabled = TP_Movimento.Text.ToUpper().Equals("SAIDA");
                bb_autoriz.Enabled = TP_Movimento.Text.ToUpper().Equals("SAIDA");

                CD_Contratante.Text = linha["cd_clifor"].ToString();
                nm_contratante.Text = linha["Nm_clifor"].ToString();
                CD_Contratante.Enabled = false;
                bb_contratante.Enabled = false;
                nm_contratante.Enabled = false;
                CD_EndContratante.Text = linha["Cd_endereco"].ToString();

                cd_tabeladesconto.Text = linha["Cd_tabeladesconto"].ToString();
                cd_tabeladesconto.Enabled = false;
                BB_TabelaDesconto.Enabled = false;
                cd_tabeladesconto_Leave(this, e);
                cd_produto.Text = linha["Cd_Produto"].ToString();
                cd_produto_Leave(this, e);

                anosafra.Text = linha["Anosafra"].ToString();
                anosafra.Enabled = false;
                BB_AnoSafra.Enabled = false;
                anosafra_Leave(this, e);
                CD_Local.Text = linha["cd_local"].ToString();
                ds_local.Text = linha["ds_local"].ToString();
            }
            else
            {
                tp_movtopedido = string.Empty;
                tp_prodpesagem.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(nr_Contrato.Text))
                    nr_Contrato.Clear();
                if (TpModo == TTpModo.tm_Insert)
                {
                    cd_produto.Clear();
                    ds_produto.Clear();
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto = string.Empty;
                    ds_tabeladesconto.Clear();
                    anosafra.Clear();
                    ds_safra.Clear();
                }
                cd_produto.Enabled = true;
                BB_Produto.Enabled = true;
                cd_tabeladesconto.Enabled = true;
                BB_TabelaDesconto.Enabled = true;
                anosafra.Enabled = true;
                BB_AnoSafra.Enabled = true;
                CD_Contratante.Enabled = true;
                bb_contratante.Enabled = true;
                nm_contratante.Enabled = string.IsNullOrEmpty(CD_Contratante.Text);
            }
        }

        private void BB_TabelaDesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Classificação|350;" +
                              "CD_TabelaDesconto|Cód. TabDesconto|100";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                    new TCD_TabelaDesconto(), "");
            if (linha != null)
            {                
                //Buscar Dados da Classificação
                if (TpModo == TTpModo.tm_Insert)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                    TCN_LanClassificacao.buscarDadosClassif(cd_tabeladesconto.Text,
                                                            Parametros.pubLogin.Trim());
                    bsPesagemGraos.ResetCurrentItem();
                }
            }
            else
            {
                (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_tabeladesconto = string.Empty;
                bsClassificacao.Clear();
            }
        }

        private void cd_tabeladesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = cd_tabeladesconto.NM_CampoBusca + "|=|'" + cd_tabeladesconto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_tabeladesconto, ds_tabeladesconto },
                                    new TCD_TabelaDesconto());
            if (!string.IsNullOrEmpty(cd_tabeladesconto.Text))
            {                
                //Buscar Dados da Classificação
                if (TpModo == TTpModo.tm_Insert)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                    TCN_LanClassificacao.buscarDadosClassif(cd_tabeladesconto.Text,
                                                            Parametros.pubLogin.Trim());
                }
            }
            else
            {
                bsClassificacao.Clear();
                
                if (string.IsNullOrEmpty(cd_tabeladesconto.Text))
                {
                    cd_produto.Clear();
                    ds_produto.Clear();
                    cd_moega.Clear();
                    ds_moega.Clear();
                }

            }
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|80";
            string vParamFixo = "i.CD_TabelaDesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(id_variedade.Text))
                vParamFixo += ";|exists|(select 1 from tb_est_variedade x " +
                              "         where x.cd_produto = a.cd_produto and x.id_variedade = " + id_variedade.Text + ")";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto("SqlCodeBuscaProdXTabDesc"), vParamFixo);
            if (linha != null)
            {
                try
                {
                    ps_embalagem.Value = Convert.ToDecimal(linha["PS_Embalagem"].ToString());
                    ps_embalagem.Enabled = ps_embalagem.Value > 0;
                    qtd_embalagem.Enabled = ps_embalagem.Value > 0;
                }
                catch
                {
                    ps_embalagem.Value = 0;
                    ps_embalagem.Enabled = false;
                    qtd_embalagem.Enabled = false;
                }
            }
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                              "i.cd_tabeladesconto|=|'" + cd_tabeladesconto.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(id_variedade.Text))
                vColunas += ";|exists|(select 1 from tb_est_variedade x " +
                            "         where x.cd_produto = a.cd_produto and x.id_variedade = " + id_variedade.Text + ")";

            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto("SqlCodeBuscaProdXTabDesc"));
            if (linha != null)
            {
                try
                {
                    ps_embalagem.Value = Convert.ToDecimal(linha["PS_Embalagem"].ToString());
                    ps_embalagem.Enabled = ps_embalagem.Value > 0;
                    qtd_embalagem.Enabled = ps_embalagem.Value > 0;
                }
                catch
                {
                    ps_embalagem.Value = 0;
                    ps_embalagem.Enabled = false;
                    qtd_embalagem.Enabled = false;
                }
            }
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "c.DS_Local|Local Armazenagem|350;" +
                              "a.CD_Local|Cód. Local|80";
            string vParamFixo = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'C'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(), vParamFixo);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                              "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "isnull(a.st_registro, 'A')|<>|'C'";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa());
        }

        private void bb_tpveiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TpVeiculo|Tipo Veiculo|350;" +
                              "CD_TpVeiculo|Cód. TPVeiculo|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                    new CamadaDados.Diversos.TCD_CadTpVeiculo(), "");
        }

        private void cd_tpveiculo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(cd_tpveiculo.NM_CampoBusca + "|=|'" + cd_tpveiculo.Text + "'",
                                        new Componentes.EditDefault[] { cd_tpveiculo, ds_tpveiculo },
                                        new CamadaDados.Diversos.TCD_CadTpVeiculo());
        }

        private void bb_moega_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moega|Descrição Moega|350;" +
                              "CD_Moega|Cód. Moega|80";
            string vParamFixo = "|EXISTS|(select 1 from tb_est_moega_x_tabdesc w where w.cd_moega = a.cd_moega and w.cd_tabeladesconto = '" + cd_tabeladesconto.Text + "')" +
                                                  "OR exists(select 1 from tb_est_empresa_x_moega y where y.cd_moega = a.cd_moega and y.cd_empresa = '" + CD_Empresa.Text + "')";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moega, ds_moega },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMoega(), vParamFixo);
        }

        private void cd_moega_Leave(object sender, EventArgs e)
        {
            string vColunas = cd_moega.NM_CampoBusca + "|=|'" + cd_moega.Text + "';" +
                                  "|EXISTS|(select 1 from tb_est_moega_x_tabdesc w where w.cd_moega = a.cd_moega and w.cd_tabeladesconto = '" + cd_tabeladesconto.Text + "')" +
                                            "OR exists(select 1 from tb_est_empresa_x_moega y where y.cd_moega = a.cd_moega and y.cd_empresa = '" + CD_Empresa.Text + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moega, ds_moega },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMoega());
        }

        private void BB_AnoSafra_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Safra|Ano Safra|350;" +
                              "AnoSafra|Cód. Safra|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra, ds_safra },
                                    new TCD_CadSafra(), "");
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(anosafra.NM_CampoBusca + "|=|'" + anosafra.Text + "'",
                                        new Componentes.EditDefault[] { anosafra, ds_safra },
                                        new TCD_CadSafra());
        }

        private void bb_transp_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transp, nm_motorista },
                                "a.ST_Transportadora|=|'S'");
            if (linha != null)
                cpf_cnpj_mot.Text = string.IsNullOrEmpty(linha["nr_cgc"].ToString()) ? linha["nr_cpf"].ToString() : linha["nr_cgc"].ToString();
            else cpf_cnpj_mot.Clear();
        }

        private void cd_transp_Leave(object sender, EventArgs e)
        {
            string vColunas = "a." + cd_transp.NM_CampoBusca + "|=|'" + cd_transp.Text + "';" +
                              "a.ST_Transportadora|=|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_transp, nm_motorista },
                                    new TCD_CadClifor());
            if (linha != null)
                cpf_cnpj_mot.Text = string.IsNullOrEmpty(linha["nr_cgc"].ToString()) ? linha["nr_cpf"].ToString() : linha["nr_cgc"].ToString();

            else cpf_cnpj_mot.Clear();
        }

        #region "BUSCAS DO NAVEGADOR"

        private void BB_EmpBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_EmpBuscaPSGraos },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void CD_EmpBuscaPSGraos_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_EmpBuscaPSGraos.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                              "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_EmpBuscaPSGraos },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_ProdBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_prodBuscaPsGraos },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), "");
        }

        private void cd_prodBuscaPsGraos_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a." + cd_prodBuscaPsGraos.NM_CampoBusca + "|=|'" + cd_prodBuscaPsGraos.Text + "'",
                                    new Componentes.EditDefault[] { cd_prodBuscaPsGraos },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_tabDescBuscaPsGraos_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TabelaDesconto|Tabela Desconto|350;" +
                              "CD_TabelaDesconto|Cód. TabDesc.|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabDescBuscaPsGraos },
                                    new TCD_TabelaDesconto(), "");
        }

        private void cd_tabDescBuscaPsGraos_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE(cd_tabDescBuscaPsGraos.NM_CampoBusca + "|=|'" + cd_tabDescBuscaPsGraos.Text + "'",
                                    new Componentes.EditDefault[] { cd_tabDescBuscaPsGraos },
                                    new TCD_TabelaDesconto());
        }

        private void bb_contratante_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Fornecedor|350;" +
                              "a.CD_Clifor|Cód. Fornecedor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contratante_busca },
                                    new TCD_CadClifor(), "");
        }

        private void cd_contratante_busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a." + cd_contratante_busca.NM_CampoBusca + "|=|'" + cd_contratante_busca.Text + "'",
                                    new Componentes.EditDefault[] { cd_contratante_busca },
                                    new TCD_CadClifor());
        }

        private void BB_Local_Busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Local|Local Armazenagem|350;" +
                              "a.CD_Local|Cód. Local|80";
            string vParamFixo = "";
            if (CD_EmpBuscaPSGraos.Text.Trim() != string.Empty)
                vParamFixo = "|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = CD_Local and x.CD_Empresa = '" + CD_EmpBuscaPSGraos.Text + "')";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local_busca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParamFixo);
        }

        private void cd_local_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_local|=|'" + cd_local_busca.Text.Trim() + "'";
            if (CD_EmpBuscaPSGraos.Text.Trim() != string.Empty)
                vColunas += ";|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = CD_Local and x.CD_Empresa = '" + CD_EmpBuscaPSGraos.Text + "')";

            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_local_busca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        #endregion

        private void BB_Fornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Fornecedor|350;" +
                              "a.CD_Clifor|Cód. Fornecedor|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local_busca },
                                    new TCD_CadClifor(), "");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            if (cd_local_busca.Text.Trim() != string.Empty)
                UtilPesquisa.EDIT_LEAVE("a." + cd_local_busca.NM_CampoBusca + "|=|'" + cd_local_busca.Text + "'",
                                        new Componentes.EditDefault[] { cd_local_busca },
                                        new TCD_CadClifor());
        }

        private void bb_proximo_Click(object sender, EventArgs e)
        {
            if ((bsClassificacao.Count - 1) >= bsClassificacao.Position)
            {
                if (pc_resultado_local.Value > 0)
                    if (!TCN_LanClassificacao.ValidaIndiceClassif(cd_tabeladesconto.Text,
                                                            (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                            pc_resultado_local.Value))
                    {
                        MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + cd_tabeladesconto.Text.Trim() + ", " +
                                        "amostra " + (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pc_resultado_local.Value = decimal.Zero;
                        pc_resultado_local.Focus();
                        return;
                    }
                (bsClassificacao.Current as TRegistro_LanClassificacao).Pc_resultado_local = pc_resultado_local.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Pc_resultado_origdes = pc_resultado_origdest.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Ps_amostra = ps_amostra.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Ps_referencia = ps_referencia.Value;
                string msg = string.Empty;
                if ((bsClassificacao.Current as TRegistro_LanClassificacao).Menorque > decimal.Zero)
                    if (pc_resultado_local.Value >= (bsClassificacao.Current as TRegistro_LanClassificacao).Menorque)
                        msg = "Deve ser menor que " + (bsClassificacao.Current as TRegistro_LanClassificacao).Menorque + ".\r\n";
                if ((bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque > decimal.Zero)
                    if (pc_resultado_local.Value <= (bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque)
                        msg += "Deve ser maior que " + (bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque + ".";
                if (msg.Trim() != string.Empty)
                {
                    //Verificar se o usuario tem permissao para gravar classificacao com indice fora do intervalo previsto
                    if (TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", null))
                        if (MessageBox.Show("O resultado da amostra <" + (bsClassificacao.Current as TRegistro_LanClassificacao).Ds_amostra.Trim().ToUpper() + ">.\r\n" + msg.Trim() +
                                           "\r\nDeseja corrigir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            pc_resultado_local.Value = 0;
                        else
                            bsClassificacao.MoveNext();
                    else
                        bsClassificacao.MoveNext();
                }
                else
                    bsClassificacao.MoveNext();
            }
        }

        private void bb_anterior_Click(object sender, EventArgs e)
        {
            if (bsClassificacao.Position >= 0)
            {
                if (pc_resultado_local.Value > 0)
                    if (!TCN_LanClassificacao.ValidaIndiceClassif(cd_tabeladesconto.Text,
                                                            (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                            pc_resultado_local.Value))
                    {
                        MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + cd_tabeladesconto.Text.Trim() + ", " +
                                        "amostra " + (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pc_resultado_local.Value = decimal.Zero;
                        pc_resultado_local.Focus();
                        return;
                    }
                (bsClassificacao.Current as TRegistro_LanClassificacao).Pc_resultado_local = pc_resultado_local.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Pc_resultado_origdes = pc_resultado_origdest.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Ps_amostra = ps_amostra.Value;
                (bsClassificacao.Current as TRegistro_LanClassificacao).Ps_referencia = ps_referencia.Value;
                string msg = string.Empty;
                if ((bsClassificacao.Current as TRegistro_LanClassificacao).Menorque > decimal.Zero)
                    if (pc_resultado_local.Value >= (bsClassificacao.Current as TRegistro_LanClassificacao).Menorque)
                        msg = "Deve ser menor que " + (bsClassificacao.Current as TRegistro_LanClassificacao).Menorque + ".\r\n";
                if ((bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque > decimal.Zero)
                    if (pc_resultado_local.Value <=(bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque)
                        msg += "Deve ser maior que " + (bsClassificacao.Current as TRegistro_LanClassificacao).Maiorque + ".";
                if (msg.Trim() != string.Empty)
                {
                    //Verificar se o usuario tem permissao para gravar classificacao com indice fora do intervalo previsto
                    if (TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", null))
                        if (MessageBox.Show("O resultado da amostra <" + (bsClassificacao.Current as TRegistro_LanClassificacao).Ds_amostra.Trim().ToUpper() + ">.\r\n" + msg.Trim() +
                                           "\r\nDeseja corrigir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            pc_resultado_local.Value = 0;
                        else
                            bsClassificacao.MovePrevious();
                    else
                        bsClassificacao.MovePrevious();
                }
                else
                    bsClassificacao.MovePrevious();
            }
        }

        private void tcPesagemGraos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsPesagemGraos.Current != null)
            {
                if (tcPesagemGraos.TabPages.Contains(tpClassifGraos))
                {
                    if (tcPesagemGraos.SelectedTab.Equals(tpClassifGraos))
                    {
                        if (bsClassificacao.Current == null)
                            (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao = TCN_LanClassificacao.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                                                              string.Empty,
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto,
                                                                                                                              0, string.Empty, null);
                        ativarDadosClassif(TpModo.Equals(TTpModo.tm_Insert) || TpModo.Equals(TTpModo.tm_Edit));
                        bsPesagemGraos.ResetCurrentItem();
                        bsClassificacao_PositionChanged(this, new EventArgs());
                    }
                }
            }
        }
                        
        private void ps_amostra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bb_proximo_Click(this, new EventArgs());
                if (ps_amostra.Enabled)
                    ps_amostra.Select(0, ps_amostra.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                bb_anterior_Click(this, new EventArgs());
                if (ps_amostra.Enabled)
                    ps_amostra.Select(0, ps_amostra.Text.Length);
            }
        }

        private void ps_referencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bb_proximo_Click(this, new EventArgs());
                if (ps_referencia.Enabled)
                    ps_referencia.Select(0, ps_referencia.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                bb_anterior_Click(this, new EventArgs());
                if (ps_referencia.Enabled)
                    ps_referencia.Select(0, ps_referencia.Text.Length);
            }
        }

        private void pc_resultado_local_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bb_proximo_Click(this, new EventArgs());
                if (pc_resultado_local.Enabled)
                    pc_resultado_local.Select(0, pc_resultado_local.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                bb_anterior_Click(this, new EventArgs());
                if (pc_resultado_local.Enabled)
                    pc_resultado_local.Select(0, pc_resultado_local.Text.Length);
            }
        }

        private void pc_resultado_origdest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bb_proximo_Click(this, new EventArgs());
                if (pc_resultado_origdest.Enabled)
                    pc_resultado_origdest.Select(0, pc_resultado_origdest.Text.Length);
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                bb_anterior_Click(this, new EventArgs());
                if (pc_resultado_origdest.Enabled)
                    pc_resultado_origdest.Select(0, pc_resultado_origdest.Text.Length);
            }
        }

        private void bsClassificacao_PositionChanged(object sender, EventArgs e)
        {
            if(tcPesagemGraos.SelectedTab != null)
                if (tcPesagemGraos.SelectedTab.Equals(tpClassifGraos))
                {
                    if (bsClassificacao.Current != null)
                    {
                        if (peso_referencia > 0)
                            (bsClassificacao.Current as TRegistro_LanClassificacao).Ps_referencia = peso_referencia;
                        if ((bsClassificacao.Current as TRegistro_LanClassificacao).InformarR_P.ToUpper().Trim().Equals("R"))
                        {
                            if ((bsClassificacao.Current as TRegistro_LanClassificacao).Capturapeso.Trim().ToUpper().Equals("S"))
                            {
                                bool st_capturar = TpModo.Equals(TTpModo.tm_Edit) || TpModo.Equals(TTpModo.tm_Insert);
                                if (pc_resultado_local.Value > 0)
                                    if (!(MessageBox.Show("Ja existe % Desconto capturado. Deseja capturar novo percentual?",
                                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes))
                                        st_capturar = false;
                                pc_resultado_local.Enabled = false;
                                if (st_capturar)
                                {
                                    TFLeituraSerial fSerial = new TFLeituraSerial();
                                    try
                                    {
                                        fSerial.Cd_protocolo = (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_protocolopeso;
                                        fSerial.ds_valor = "% Local:";
                                        fSerial.ds_amostra = (bsClassificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                        if (fSerial.ShowDialog() == DialogResult.OK)
                                        {
                                            pc_resultado_local.Value = fSerial.vl_capturado;
                                            bb_proximo_Click(this, new EventArgs());
                                            gClassifPsGraos.Refresh();
                                        }
                                    }
                                    finally
                                    {
                                        fSerial.Dispose();
                                    }
                                }
                            }
                            else
                                pc_resultado_local.Enabled = true;
                            pc_resultado_origdest.Enabled = true;
                            ps_amostra.Enabled = false;
                            ps_referencia.Enabled = false;
                            pc_resultado_local.Focus();
                        }
                        else if ((bsClassificacao.Current as TRegistro_LanClassificacao).InformarR_P.ToUpper().Trim().Equals("P"))
                        {
                            //Peso Referencia
                            if ((bsClassificacao.Current as TRegistro_LanClassificacao).Capturareferencia.Trim().ToUpper().Equals("S"))
                            {
                                bool st_capturar = true;
                                if (ps_referencia.Value > 0)
                                    if (!(MessageBox.Show("Ja existe peso referencia capturado. Deseja capturar novo peso referencia?",
                                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes))
                                        st_capturar = false;
                                ps_referencia.Enabled = false;
                                if(st_capturar)
                                {
                                    TFLeituraSerial fSerial = new TFLeituraSerial();
                                    try
                                    {
                                        fSerial.Cd_protocolo = (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_protocoloreferencia;
                                        fSerial.ds_valor = "Peso Referência:";
                                        fSerial.ds_amostra = (bsClassificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                        if (fSerial.ShowDialog() == DialogResult.OK)
                                        {
                                            ps_referencia.Value = fSerial.vl_capturado;
                                            peso_referencia = ps_referencia.Value;
                                        }
                                        gClassifPsGraos.Refresh();
                                    }
                                    finally
                                    {
                                        fSerial.Dispose();
                                    }
                                }
                            }
                            else
                                ps_referencia.Enabled = true;
                            //Peso Amostra
                            if ((bsClassificacao.Current as TRegistro_LanClassificacao).Capturapeso.Trim().ToUpper().Equals("S"))
                            {
                                bool st_capturar = true;
                                if(ps_amostra.Value > 0)
                                    if (!(MessageBox.Show("Ja existe peso amostra capturado. Deseja capturar novo peso amostra?",
                                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes))
                                        st_capturar = false;
                                if (st_capturar)
                                {
                                    TFLeituraSerial fSerial = new TFLeituraSerial();
                                    try
                                    {
                                        fSerial.Cd_protocolo = (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_protocolopeso;
                                        fSerial.ds_valor = "Peso Amostra:";
                                        fSerial.ds_amostra = (bsClassificacao.Current as TRegistro_LanClassificacao).Ds_amostra.ToUpper().Trim();
                                        if (fSerial.ShowDialog() == DialogResult.OK)
                                        {
                                            ps_amostra.Value = fSerial.vl_capturado;
                                            bb_proximo_Click(this, new EventArgs());
                                            gClassifPsGraos.Refresh();
                                        }
                                    }
                                    finally
                                    {
                                        fSerial.Dispose();
                                    }
                                }
                            }
                            else
                                ps_amostra.Enabled = true;

                            pc_resultado_local.Enabled = false;
                            pc_resultado_origdest.Enabled = false;

                            ps_amostra.Focus();
                        }
                    }
                }
        }

        private void gBuscaPsGraos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FECHADO"))
                    {
                        DataGridViewRow linha = gBuscaPsGraos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gBuscaPsGraos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REFUGADO"))
                    {
                        DataGridViewRow linha = gBuscaPsGraos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else
                    {
                        DataGridViewRow linha = gBuscaPsGraos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void TFLanPesagemGraos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.Right))
            {
                if (tcPesagemGraos.SelectedIndex < tcPesagemGraos.TabCount - 1)
                    tcPesagemGraos.SelectedIndex++;
            }
            else if (e.Control && (e.KeyCode == Keys.Left))
            {
                if (tcPesagemGraos.SelectedIndex > 0)
                    tcPesagemGraos.SelectedIndex--;
            }
            else if (e.Control && (e.KeyCode.Equals(Keys.F10)))
                btn_Inserir_Item_Click(this, new EventArgs());
            else if (e.Control && (e.KeyCode.Equals(Keys.F11)))
                BB_Alterar_Item_Click(this, new EventArgs());
            else if (e.Control && (e.KeyCode.Equals(Keys.F12)))
                btn_Deleta_Item_Click(this, new EventArgs());
        }

        private void bsPesagemGraos_PositionChanged(object sender, EventArgs e)
        {
            if (bsPesagemGraos.Current != null)
            {
                ativaPage((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_modo, (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento);
                if (((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa.Trim() != string.Empty) &&
                    ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem.Trim() != string.Empty) &&
                    ((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket > 0))
                {
                    //Buscar Classificacao da Pesagem
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao = TCN_LanClassificacao.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                                                              string.Empty,
                                                                                                                              (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto,
                                                                                                                              0, string.Empty, null);
                    //Buscar aplicacoes da pesagem
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lAplicTicket = TCN_LanAplicacaoPedido.Buscar(string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                                                       string.Empty,
                                                                                                                       (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticket.ToString(),
                                                                                                                       (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                                                       null);
                    //Buscar desdobros
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lDesdobro = TCN_ItensDesdobro.Buscar((bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa,
                                                                                                           (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_pesagem,
                                                                                                           (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Id_ticketstr,
                                                                                                           string.Empty,
                                                                                                           null);
                    bsPesagemGraos.ResetCurrentItem();
                }
            }
        }

        private void bb_origempesagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Cd. Cidade|80;" +
                              "a.distrito|Distrito|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_origempesagem, ds_origempesagem },
                                    new TCD_CadCidade(), string.Empty);
        }

        private void cd_origempesagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_origempesagem.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_origempesagem, ds_origempesagem },
                                    new TCD_CadCidade());
        }

        private void pc_resultado_local_Leave(object sender, EventArgs e)
        {
            if (pc_resultado_local.Value > 0)
                if (!TCN_LanClassificacao.ValidaIndiceClassif(cd_tabeladesconto.Text,
                                                        (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra,
                                                        pc_resultado_local.Value))
                {
                    MessageBox.Show("Percentual de desconto informado não existe para a tabela de desconto " + cd_tabeladesconto.Text.Trim() + ", " +
                                    "amostra " + (bsClassificacao.Current as TRegistro_LanClassificacao).Cd_tipoamostra.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pc_resultado_local.Value = decimal.Zero;
                    pc_resultado_local.Focus();
                }
        }

        private void bb_autoriz_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_autoriz|Id. Autoriz.|80;" +
                              "a.nr_pedido|Nº Pedido|80;" +
                              "a.nr_contrato|Nº Contrato|80;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.ds_produto|Produto Retirar|200;" +
                              "a.qtd_retirar|Qtd. Retirar|80;" +
                              "saldo_retirar|Saldo Retirar|80";
            string vParam = "a.nr_contrato|=|" + nr_Contrato.Text + ";" +
                            "(a.qtd_retirar - a.qtd_retirada)|>|0 ";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_autoriz },
                                    new TCD_Autoriz_RetDeposito(), vParam);
        }

        private void cd_autoriz_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_autoriz|=|" + cd_autoriz.Text + ";" +
                            "a.nr_contrato|=|" + nr_Contrato.Text + ";" +
                            "(a.qtd_retirar - a.qtd_retirada)|>|0";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_autoriz },
                                    new TCD_Autoriz_RetDeposito());
        }

        private void TFLanPesagemGraos_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gAplicacao);
            ShapeGrid.RestoreShape(this, gBuscaPsGraos);
            ShapeGrid.RestoreShape(this, gClassifPsGraos);
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);

            bb_cancAplic.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR CANCELAR NOTAS FISCAIS", null);
        }

        private void gClassifPsGraos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gClassifPsGraos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsClassificacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanClassificacao());
            TList_RegLanClassificacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gClassifPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gClassifPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanClassificacao(lP.Find(gClassifPsGraos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gClassifPsGraos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanClassificacao(lP.Find(gClassifPsGraos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gClassifPsGraos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsClassificacao.List as TList_RegLanClassificacao).Sort(lComparer);
            bsClassificacao.ResetBindings(false);
            gClassifPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBuscaPsGraos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBuscaPsGraos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPesagemGraos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanPesagemGraos());
            TList_RegLanPesagemGraos lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBuscaPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBuscaPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gBuscaPsGraos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBuscaPsGraos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanPesagemGraos(lP.Find(gBuscaPsGraos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBuscaPsGraos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPesagemGraos.List as TList_RegLanPesagemGraos).Sort(lComparer);
            bsPesagemGraos.ResetBindings(false);
            gBuscaPsGraos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gAplicacao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAplicacao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAplicacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanAplicacaoPedido());
            TList_LanAplicacaoPedido lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAplicacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAplicacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanAplicacaoPedido(lP.Find(gAplicacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAplicacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanAplicacaoPedido(lP.Find(gAplicacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAplicacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAplicacao.List as TList_LanAplicacaoPedido).Sort(lComparer);
            bsAplicacao.ResetBindings(false);
            gAplicacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_cancAplic_Click(object sender, EventArgs e)
        {
            if (bsAplicacao.Current != null)
            {
                if (MessageBox.Show("Confirma cancelamento Aplicação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Buscar objeto nota fiscal a ser cancelado
                    TList_RegLanFaturamento lNfAplic =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsAplicacao.Current as TRegistro_LanAplicacaoPedido).Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      (bsAplicacao.Current as TRegistro_LanAplicacaoPedido).Nr_lanctofiscalaplic.ToString(),
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
                    if (new TCD_Fixacao_NF().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lNfAplic[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctofiscal",
                                    vOperador = "=",
                                    vVL_Busca = lNfAplic[0].Nr_lanctofiscalstr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(fx.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, "1") != null)
                    {
                        MessageBox.Show("Aplicação possui fixação, obrigatório cancelar antes a fixação.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lNfAplic[0].Cd_modelo.Trim().Equals("55") && 
                        lNfAplic[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                        lNfAplic[0].St_transcanc_NFe)
                    {
                        //Verificar se NFe ja nao foi cancelada junto a receita
                        CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                            CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                               lNfAplic[0].Cd_empresa,
                                                                               lNfAplic[0].Nr_lanctofiscal.ToString(),
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               "CA",
                                                                               string.Empty,
                                                                               null);
                        if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                        {
                            //Cancelar somente NFe no Aliance.NET
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                            MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
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
                                CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                if (lEv.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar NFe Receita
                                CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                rEvento.Cd_empresa = lNfAplic[0].Cd_empresa;
                                rEvento.Nr_lanctofiscal = lNfAplic[0].Nr_lanctofiscal;
                                rEvento.Chave_acesso_nfe = lNfAplic[0].Chave_acesso_nfe;
                                rEvento.Nr_protocoloNfe = lNfAplic[0].Nr_protocolo;
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
                                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNfAplic[0].Cd_empresa.Trim() + ".",
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
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                            MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            afterBusca();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + lNfAplic[0].Cd_empresa.Trim() + ".",
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
                                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                                        MessageBox.Show("NF-e cancelada com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                }
                            }
                        }
                    }
                    else
                        try
                        {
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(lNfAplic[0], null);
                            MessageBox.Show("Aplicação Cancelada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (lNfAplic[0].Cd_modelo.Trim().Equals("55") &&
                                lNfAplic[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                                (!lNfAplic[0].St_transmitidoNFe))
                            {
                                TList_CadSequenciaNF lSeq = CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(lNfAplic[0].Nr_serie,
                                                                                                                         lNfAplic[0].Cd_modelo,
                                                                                                                         lNfAplic[0].Cd_empresa,
                                                                                                                         null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals(lNfAplic[0].Nr_notafiscal))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(lNfAplic[0].Cd_empresa,
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
                                                                                                   lNfAplic[0].Nr_serie,
                                                                                                   lNfAplic[0].Cd_modelo,
                                                                                                   DateTime.Now.Year.ToString(),
                                                                                                   lNfAplic[0].Nr_notafiscal.Value,
                                                                                                   lNfAplic[0].Nr_notafiscal.Value,
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
                        { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void bb_area_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_area|Area Fazenda|200;" +
                              "a.id_area|Id. Area|80";
            string vParam = "a.cd_fazenda|=|'" + CD_Empresa.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_area, ds_area },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Area(), vParam);
        }

        private void id_area_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "a.id_area|=|" + id_area.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_area, ds_area },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Area());
        }

        private void bb_talhao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_talhao|Talhão Fazenda|200;" +
                              "a.id_talhao|Id. Talhão|80";
            string vParam = "a.cd_fazenda|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "a.id_area|=|" + (string.IsNullOrEmpty(id_area.Text) ? "null" : id_area.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_talhao, ds_talhao },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Talhoes(), vParam);
        }

        private void id_talhao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_fazenda|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "a.id_area|=|" + (string.IsNullOrEmpty(id_area.Text) ? "null" : id_area.Text) + ";" +
                            "a.id_talhao|=|" + id_talhao.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_talhao, ds_talhao },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Talhoes());
        }

        private void bb_plantio_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_plantio|Id. Plantio|80;" +
                              "a.anosafra|Safra|80;" +
                              "c.ds_safra|Ano Safra|100;" +
                              "a.id_cultura|Id. Cultura|80;" +
                              "b.ds_cultura|Cultura|100;" +
                              "b.cd_produto|Cd. Produto|80;" +
                              "d.ds_produto|Produto|200";
            string vParam = "|exists|(select 1 from tb_faz_plantio_x_talhoes x " +
                            "           where x.id_plantio = a.id_plantio " +
                            "           and x.cd_fazenda = '" + CD_Empresa.Text.Trim() + "' " +
                            "           and x.id_area = " + (string.IsNullOrEmpty(id_area.Text) ? "null" : id_area.Text) + " " +
                            "           and x.id_talhao = " + (string.IsNullOrEmpty(id_talhao.Text) ? "null" : id_talhao.Text) + ")";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_plantio, anosafrafaz, ds_safrafaz, id_cultura, ds_cultura, cd_prodFazenda, ds_prodfazenda },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Plantio(), vParam);
        }

        private void id_plantio_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_plantio|=|" + id_plantio.Text + ";" +
                            "|exists|(select 1 from tb_faz_plantio_x_talhoes x " +
                            "           where x.id_plantio = a.id_plantio " +
                            "           and x.cd_fazenda = '" + CD_Empresa.Text.Trim() + "' " +
                            "           and x.id_area = " + (string.IsNullOrEmpty(id_area.Text) ? "null" : id_area.Text) + " " +
                            "           and x.id_talhao = " + (string.IsNullOrEmpty(id_talhao.Text) ? "null" : id_talhao.Text) + ")";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_plantio, anosafrafaz, ds_safrafaz, id_cultura, ds_cultura, cd_prodFazenda, ds_prodfazenda },
                                    new CamadaDados.Fazenda.Cadastros.TCD_Plantio());
        }

        private void bb_tabdescfaz_Click(object sender, EventArgs e)
        {
            string vColunas = "b.ds_tabeladesconto|Tabela Desconto|200;" +
                              "a.cd_tabeladesconto|Cd. Tabela|80";
            string vParam = "a.cd_produto|=|'" + cd_prodFazenda.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{cd_tabdescfaz, ds_tabdescfaz},
                                    new TCD_CadDescontoxProdutos(), vParam);
            if (!string.IsNullOrEmpty(cd_tabdescfaz.Text))
            {
                //Buscar Dados da Classificação
                if (TpModo == TTpModo.tm_Insert)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                    TCN_LanClassificacao.buscarDadosClassif(cd_tabdescfaz.Text,
                                                            Parametros.pubLogin.Trim());
                    bsPesagemGraos.ResetCurrentItem();
                }
            }
            else
            {
                ds_tabdescfaz.Clear();
                bsClassificacao.Clear();
            }
        }

        private void cd_tabdescfaz_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabeladesconto|=|'" + cd_tabdescfaz.Text.Trim() + "';" +
                            "a.cd_produto|=|'" + cd_prodFazenda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabdescfaz, ds_tabdescfaz },
                                    new TCD_CadDescontoxProdutos());
            if (!string.IsNullOrEmpty(cd_tabdescfaz.Text))
            {
                //Buscar Dados da Classificação
                if (TpModo == TTpModo.tm_Insert)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Classificacao =
                    TCN_LanClassificacao.buscarDadosClassif(cd_tabdescfaz.Text,
                                                            Parametros.pubLogin.Trim());
                    bsPesagemGraos.ResetCurrentItem();
                }
            }
            else
            {
                ds_tabdescfaz.Clear();
                bsClassificacao.Clear();
            }
        }

        private void bb_localfaz_Click(object sender, EventArgs e)
        {
            string vColunas = "c.DS_Local|Local Armazenagem|350;" +
                              "a.CD_Local|Cód. Local|80";
            string vParamFixo = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_localfaz, ds_localfaz },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(), vParamFixo);
        }

        private void cd_localfaz_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_localfaz.Text.Trim() + "';" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_localfaz, ds_localfaz },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa());
        }

        private void TFLanPesagemGraos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gAplicacao);
            ShapeGrid.SaveShape(this, gBuscaPsGraos);
            ShapeGrid.SaveShape(this, gClassifPsGraos);
        }

        private void CD_Contratante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Contratante.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Contratante, nm_contratante },
                new TCD_CadClifor());
            nm_contratante.Enabled = string.IsNullOrEmpty(CD_Contratante.Text);
        }

        private void bb_contratante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Contratante, nm_contratante }, string.Empty);
            nm_contratante.Enabled = string.IsNullOrEmpty(CD_Contratante.Text);
        }

        private void bb_safra_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Descrição|150;" +
                              "a.anosafra|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra_busca }, new TCD_CadSafra(), string.Empty);
        }

        private void anosafra_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra_busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra_busca }, new TCD_CadSafra());
        }

        private void tp_prodpesagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_prodpesagem.SelectedIndex == 4)
            {
                st_testeprod.Checked = true;
                st_testeprod.Enabled = false;
            }
            else st_testeprod.Enabled = true;
        }

        private void bb_variedade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_variedade|Variedade|200;" +
                              "a.id_variedade|Código|50";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_produto.Text))
                vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_variedade, ds_variedade },
                new CamadaDados.Estoque.Cadastros.TCD_Variedade(), vParam);
        }

        private void id_variedade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_variedade|=|" + id_variedade.Text;
            if (!string.IsNullOrEmpty(cd_produto.Text))
                vParam += ";a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_variedade, ds_variedade },
                new CamadaDados.Estoque.Cadastros.TCD_Variedade());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            if ((TpModo == TTpModo.tm_Insert || TpModo == TTpModo.tm_Edit) && bsPesagemGraos.Current != null)
            {
                using (TFItemDesdobro fItem = new TFItemDesdobro())
                {
                    fItem.pCd_tabeladesconto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto;
                    fItem.pDs_tabeladesconto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_tabeladesconto;
                    fItem.pTp_movimento = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento;
                    fItem.pCd_empresa = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa;
                    fItem.pNm_empresa = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Nm_empresa;
                    fItem.pCd_produto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_produto;
                    fItem.pDs_produto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_produto;

                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lDesdobro.Add(
                            new TRegistro_ItensDesdobro()
                            {
                                Nr_contrato_dest = fItem.Nr_contratodest,
                                Cd_contratante_dest = fItem.pCd_contratante_dest,
                                Nm_contratante_dest = fItem.pNm_contratante_dest,
                                Nr_notaprodutor = fItem.Nr_nfprodutor,
                                Dt_emissaonfprodutor = fItem.pDt_emissaonfprodutor,
                                Qt_nfprodutor = fItem.Qtd_nfprodutor,
                                Vl_nfprodutor = fItem.pVl_nfprodutor,
                                Tp_pesodesdobro = fItem.Tp_pesodesdobro,
                                Qtd_desdobro = fItem.Qtd_desdobro,
                                Tp_percvalor = fItem.Tp_percvalor
                            });
                        bsPesagemGraos.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Só é permitido manipular desdobros ao inserir ou alterar Tickets de Pesagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            if ((TpModo == TTpModo.tm_Insert || TpModo == TTpModo.tm_Edit) && bsDesdobro.Current != null)
            {
                if (MessageBox.Show("Confirma a exclusão do desdobro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).lDesdobroDel.Add(bsDesdobro.Current as TRegistro_ItensDesdobro);
                    bsDesdobro.RemoveCurrent();
                    bsPesagemGraos.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Só é permitido manipular desdobros ao inserir ou alterar Tickets de Pesagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            if ((TpModo == TTpModo.tm_Edit || TpModo == TTpModo.tm_Insert) && bsDesdobro.Current != null)
            {
                using (TFItemDesdobro fItem = new TFItemDesdobro())
                {
                    fItem.pCd_tabeladesconto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_tabeladesconto;
                    fItem.pDs_tabeladesconto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_tabeladesconto;
                    fItem.pTp_movimento = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Tp_movimento;
                    fItem.pCd_empresa = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_empresa;
                    fItem.pNm_empresa = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Nm_empresa;
                    fItem.pCd_produto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Cd_produto;
                    fItem.pDs_produto = (bsPesagemGraos.Current as TRegistro_LanPesagemGraos).Ds_produto;

                    fItem.Nr_contratodest = (bsDesdobro.Current as TRegistro_ItensDesdobro).Nr_contrato_dest;
                    fItem.pCd_contratante_dest = (bsDesdobro.Current as TRegistro_ItensDesdobro).Cd_contratante_dest;
                    fItem.pNm_contratante_dest = (bsDesdobro.Current as TRegistro_ItensDesdobro).Nm_contratante_dest;
                    fItem.Nr_nfprodutor = (bsDesdobro.Current as TRegistro_ItensDesdobro).Nr_notaprodutor;
                    fItem.pDt_emissaonfprodutor = (bsDesdobro.Current as TRegistro_ItensDesdobro).Dt_emissaonfprodutor;
                    fItem.Qtd_nfprodutor = (bsDesdobro.Current as TRegistro_ItensDesdobro).Qt_nfprodutor;
                    fItem.pVl_nfprodutor = (bsDesdobro.Current as TRegistro_ItensDesdobro).Vl_nfprodutor;
                    fItem.Tp_pesodesdobro = (bsDesdobro.Current as TRegistro_ItensDesdobro).Tp_pesodesdobro;
                    fItem.Qtd_desdobro = (bsDesdobro.Current as TRegistro_ItensDesdobro).Qtd_desdobro;
                    fItem.Tp_percvalor = (bsDesdobro.Current as TRegistro_ItensDesdobro).Tp_percvalor;

                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Nr_contrato_dest = fItem.Nr_contratodest;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Cd_contratante_dest = fItem.pCd_contratante_dest;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Nm_contratante_dest = fItem.pNm_contratante_dest;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Nr_notaprodutor = fItem.Nr_nfprodutor;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Dt_emissaonfprodutor = fItem.pDt_emissaonfprodutor;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Qt_nfprodutor = fItem.Qtd_nfprodutor;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Vl_nfprodutor = fItem.pVl_nfprodutor;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Tp_pesodesdobro = fItem.Tp_pesodesdobro;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Qtd_desdobro = fItem.Qtd_desdobro;
                        (bsDesdobro.Current as TRegistro_ItensDesdobro).Tp_percvalor = fItem.Tp_percvalor;
                        bsPesagemGraos.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Só é permitido manipular desdobros ao inserir ou alterar Tickets de Pesagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

