using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Graos;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using Utils;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Graos;
using Financeiro;
using CamadaDados.Faturamento.NotaFiscal;


namespace Commoditties
{
    public partial class TFLan_Fixacao : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_Fixacao()
        {
            InitializeComponent();
            pFiltro.set_FormatZero();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            cbMov.DataSource = cbx;
            cbMov.DisplayMember = "Display";
            cbMov.ValueMember = "Value";
        }

        private void afterNovo()
        {
            if (bsPedido.Current != null)
            {
                if ((bsPedido.Current as TRegistro_PedidoAplicacao).Ps_disponivel > 0)
                {
                    using (TFFixacao fFixacao = new TFFixacao())
                    {
                        TRegistro_LanFixacao rFixacao = new TRegistro_LanFixacao();
                        fFixacao.bsFixacao.Add(new TRegistro_LanFixacao()
                        {
                            Nr_contrato = (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contrato.Value,
                            Cd_produto = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto,
                            Cd_unidestoque = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_unidade_estoque,
                            Ds_unidestoque = (bsPedido.Current as TRegistro_PedidoAplicacao).Ds_unidade_estoque,
                            Sigla_unidestoque = (bsPedido.Current as TRegistro_PedidoAplicacao).Sigla_unidade_estoque,
                            Cd_unidvalor = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_unidade,
                            Ds_unidvalor = (bsPedido.Current as TRegistro_PedidoAplicacao).Ds_unidade,
                            Sigla_unidvalor = (bsPedido.Current as TRegistro_PedidoAplicacao).Sigla_unidade,
                            Vl_bonificacao = (bsPedido.Current as TRegistro_PedidoAplicacao).Vl_bonificacao
                        });
                        fFixacao.Qtd_fixar = (bsPedido.Current as TRegistro_PedidoAplicacao).Ps_disponivel;
                        fFixacao.Tp_movimento = (bsPedido.Current as TRegistro_PedidoAplicacao).Tp_movimento;
                        if ((fFixacao.ShowDialog() == DialogResult.OK) && (fFixacao.bsFixacao.Current != null))
                        {
                            try
                            {
                                Proc_Commoditties.TProcessaFixacao.ProcessarFixacao(bsPedido.Current as TRegistro_PedidoAplicacao,
                                                                                    fFixacao.bsFixacao.Current as TRegistro_LanFixacao);
                                TCN_LanFixacao.GravarFixacao(fFixacao.bsFixacao.Current as TRegistro_LanFixacao, null);
                                List<TRegistro_LanFaturamento> lNFe = new List<TRegistro_LanFaturamento>();
                                if ((fFixacao.bsFixacao.Current as TRegistro_LanFixacao).rNfDev != null)
                                    if ((fFixacao.bsFixacao.Current as TRegistro_LanFixacao).rNfDev.Cd_modelo.Trim().Equals("55") &&
                                        (fFixacao.bsFixacao.Current as TRegistro_LanFixacao).rNfDev.Tp_nota.Trim().ToUpper().Equals("P"))
                                        lNFe.Add(TCN_LanFaturamento.BuscarNF((fFixacao.bsFixacao.Current as TRegistro_LanFixacao).rNfDev.Cd_empresa,
                                                                             (fFixacao.bsFixacao.Current as TRegistro_LanFixacao).rNfDev.Nr_lanctofiscalstr,
                                                                             null));
                                (fFixacao.bsFixacao.Current as TRegistro_LanFixacao).lFixacaonf.ForEach(p => 
                                    {
                                        if((p.rNfComplemento != null ? (p.rNfComplemento.Cd_modelo.Trim().Equals("55") && p.rNfComplemento.Tp_nota.Trim().ToUpper().Equals("P")) : false))
                                            lNFe.Add(TCN_LanFaturamento.BuscarNF(p.rNfComplemento.Cd_empresa, p.rNfComplemento.Nr_lanctofiscalstr, null));
                                    });
                                if (lNFe.Count > 0)
                                {
                                    lNFe.ForEach(p =>
                                        {
                                            try
                                            {
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = p;
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        });
                                }
                                else
                                    MessageBox.Show("Fixação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Contrato sem saldo para aplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsPedido.DataSource = TCN_PedidoAplicacao.Buscar(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(), 
                                                             string.Empty, 
                                                             string.Empty, 
                                                             cd_clifor.Text, 
                                                             cbMov.SelectedValue == null ? string.Empty : cbMov.SelectedValue.ToString(), 
                                                             false, 
                                                             nr_contrato.Text, 
                                                             string.Empty, 
                                                             string.Empty, 
                                                             "A", 
                                                             dt_ini.Text, 
                                                             dt_fin.Text, 
                                                             true,
                                                             cd_produto.Text, 
                                                             true,
                                                             cbComSaldo.Checked,
                                                             string.Empty, 
                                                             false, 
                                                             false,
                                                             0);
            tslTotEntrada.Text = (bsPedido.List as TList_PedidoAplicacao).Sum(p => p.Ps_totalentrada).ToString("N0", new System.Globalization.CultureInfo("pt-BR", true));
            tslFixado.Text = (bsPedido.List as TList_PedidoAplicacao).Sum(p => p.Ps_fixado).ToString("N0", new System.Globalization.CultureInfo("pt-BR", true));
            tslSaldoFixar.Text = (bsPedido.List as TList_PedidoAplicacao).Sum(p => p.Ps_disponivel).ToString("N0", new System.Globalization.CultureInfo("pt-BR", true));
            bsPedido_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsFixacao.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão da fixação " + (bsFixacao.Current as TRegistro_LanFixacao).Id_fixacao.ToString() + "?",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        bool st_cancelar = true;
                        //Verificar se existe nfe
                        string motivo = string.Empty;
                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                        CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                        foreach(TRegistro_LanFaturamento_Item p in (bsFixacao.Current as TRegistro_LanFixacao).lItemNf)
                        {
                            if (new TCD_LanFaturamento().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = p.Nr_lanctofiscal.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_modelo",
                                        vOperador = "=",
                                        vVL_Busca = "'55'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_nota",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    },
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
                                        vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                    "and x.status = '100')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_fat_eventonfe x " +
                                                    "inner join tb_fat_evento y " +
                                                    "on x.cd_evento = y.cd_evento " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                    "and isnull(x.st_registro, 'A') <> 'T' " +
                                                    "and y.tp_evento = 'CA')"
                                    }
                                }, "1") != null)
                            {
                                //Verificar evento
                                CamadaDados.Faturamento.NFE.TList_EventoNFe lEvento =
                                    CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                                       p.Cd_empresa,
                                                                                       p.Nr_lanctofiscal.ToString(),
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "CA",
                                                                                       string.Empty,
                                                                                       null);
                                if (lEvento.Count.Equals(0))
                                {
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        InputBox ibp = new InputBox();
                                        ibp.Text = "Motivo Cancelamento Nota Fiscal";
                                        motivo = ibp.ShowDialog();
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
                                    }
                                    //Buscar evento Cancelamento
                                    if(lEv == null)
                                        lEv = CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                    if (lEv.Count.Equals(0))
                                    {
                                        MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    //Cancelar NFe Receita
                                    CamadaDados.Faturamento.NFE.TRegistro_EventoNFe rEvento = new CamadaDados.Faturamento.NFE.TRegistro_EventoNFe();
                                    rEvento.Cd_empresa = p.Cd_empresa;
                                    rEvento.Nr_lanctofiscal = p.Nr_lanctofiscal;
                                    rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                    rEvento.Ds_evento = motivo;
                                    rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                    rEvento.Descricao_evento = lEv[0].Ds_evento;
                                    rEvento.Tp_evento = lEv[0].Tp_evento;
                                    rEvento.St_registro = "A";
                                    CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Gravar(rEvento, null);
                                    lEvento = CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(rEvento.Id_eventostr,
                                                                                                 rEvento.Cd_empresa,
                                                                                                 rEvento.Nr_lanctofiscalstr,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                                }
                                if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                {
                                    //Buscar CfgNfe para a empresa
                                    if (lCfg == null)
                                        lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(p.Cd_empresa,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     null);
                                    if (lCfg.Count.Equals(0))
                                    {
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + p.Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        st_cancelar = false;
                                    }
                                    else
                                    {
                                        string msg = srvNFE.Evento.TEventoNFe.EnviarEvento(lEvento[0], lCfg[0]);
                                        if (!string.IsNullOrEmpty(msg))
                                        {
                                            MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                            "Aguarde um tempo e tente novamente.\r\n" +
                                                            "Erro: " + msg.Trim() + ".",
                                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            st_cancelar = false;
                                        }
                                        else
                                            st_cancelar = true;
                                    }
                                }
                                else
                                    st_cancelar = true;
                            }
                        }
                        if (st_cancelar)
                        {
                            TCN_LanFixacao.Excluir(bsFixacao.Current as TRegistro_LanFixacao, null);
                            MessageBox.Show("Fixação cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Não existe fixação para ser cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterPrintRomaneio()
        {
            if (bsFixacao.Current != null)
            {
                 //Buscar Dados Empresa
                BindingSource bs_empresa = new BindingSource();
                bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsPedido.Current as TRegistro_PedidoAplicacao).Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                //Dados Produtor
                BindingSource bs_produtor = new BindingSource();
                bs_produtor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsPedido.Current as TRegistro_PedidoAplicacao).Cd_clifor,
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

                //Endereco Produto
                BindingSource bs_endprodutor = new BindingSource();
                bs_endprodutor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsPedido.Current as TRegistro_PedidoAplicacao).Cd_clifor,
                                                                                                      (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_endereco,
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
                                                                                                      1,
                                                                                                      null);

                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_ROMANEIOAQUISICAOVENDA";
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = "GRO";

                BindingSource bsFix = new BindingSource();
                bsFix.DataSource = new TList_LanFixacao(){bsFixacao.Current as TRegistro_LanFixacao};

                BindingSource dts = new BindingSource();
                dts.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_gro_fixacao_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.id_fixacao = " + (bsFixacao.Current as TRegistro_LanFixacao).Id_fixacao.Value.ToString() + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                Relatorio.DTS_Relatorio = dts;                
                Relatorio.Adiciona_DataSource("EMPRESA", bs_empresa);
                Relatorio.Adiciona_DataSource("PRODUTOR", bs_produtor);
                Relatorio.Adiciona_DataSource("ENDPRODUTOR", bs_endprodutor);
                Relatorio.Adiciona_DataSource("FIXACAO", bsFix);

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_clifor;
                        fImp.pMensagem = "ROMANEIO DE AQUISIÇÃO/VENDA";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr + "/" + (bsFixacao.Current as TRegistro_LanFixacao).Id_fixacao.Value.ToString(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "ROMANEIO DE AQUISIÇÃO/VENDA",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar fixação para imprimir romaneio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLan_Fixacao_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gDupFixacao);
            ShapeGrid.RestoreShape(this, itensNotaDataGridDefault);
            ShapeGrid.RestoreShape(this, gPedido);
            ShapeGrid.RestoreShape(this, gFixacao);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsPedido_PositionChanged(object sender, EventArgs e)
        {
            if (bsPedido.Current != null)
            {
                //Buscar todas as notas fiscais de pauta
                (bsPedido.Current as TRegistro_PedidoAplicacao).lNfPauta = 
                    TCN_LanFaturamento_Item.BuscarNfFixacao((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr, 
                                                            (bsPedido.Current as TRegistro_PedidoAplicacao).Tp_movimento,
                                                            false,
                                                            true,
                                                            false,
                                                            0);
                bsPedido.ResetCurrentItem();
                //Buscar todas as fixacoes do pedido
                bsFixacao.Clear();
                bsFixacao.DataSource = TCN_LanFixacao.Buscar(string.Empty,
                                                             string.Empty,
                                                             decimal.Zero,
                                                             decimal.Zero,
                                                             decimal.Zero,
                                                             string.Empty,
                                                             (bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                             (bsPedido.Current as TRegistro_PedidoAplicacao).Cd_produto,
                                                             0,
                                                             string.Empty,
                                                             null);
                //Totalizar Notas Pauta
                qtd_pauta.Text = (bsPedido.Current as TRegistro_PedidoAplicacao).lNfPauta.Sum(p => p.Quantidade).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                vl_pauta.Text = (bsPedido.Current as TRegistro_PedidoAplicacao).lNfPauta.Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                //Totalizar Fixacao
                if(bsFixacao.Count > 0)
                {
                    tot_qtdfixada.Text = (bsFixacao.List as TList_LanFixacao).Sum(p => p.Ps_fixado_total).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                    tot_vlfixado.Text = (bsFixacao.List as TList_LanFixacao).Sum(p => p.Vl_fixacao).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_impret.Text = (bsFixacao.List as TList_LanFixacao).Sum(p => p.Vl_impostosret).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_liquido.Text = (bsFixacao.List as TList_LanFixacao).Sum(p => p.Vl_liquido).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLan_Fixacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrintRomaneio();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja editar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsFixacao_PositionChanged(object sender, EventArgs e)
        {
            if (bsFixacao.Current != null)
            {
                //Buscar Nf Fixacao
                (bsFixacao.Current as TRegistro_LanFixacao).lItemNf = 
                    TCN_LanFaturamento_Item.BuscarNfFixacao((bsPedido.Current as TRegistro_PedidoAplicacao).Nr_contratostr,
                                                            string.Empty,
                                                            false,
                                                            false,
                                                            true,
                                                            (bsFixacao.Current as TRegistro_LanFixacao).Id_fixacao.Value);
                //Totalizar Nf Fixacao
                vl_fixada.Text = (bsFixacao.Current as TRegistro_LanFixacao).lItemNf.Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                //Buscar Financeiro Fixacao
                (bsFixacao.Current as TRegistro_LanFixacao).lDupFixacao =
                    TCN_Fixacao_X_Duplicata.BuscarDup((bsFixacao.Current as TRegistro_LanFixacao).Id_fixacao.Value.ToString(), null);
                //Totalizar Duplicatas
                tot_duplicata.Text = (bsFixacao.Current as TRegistro_LanFixacao).lDupFixacao.Sum(p => p.Vl_documento).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_liquidado.Text = (bsFixacao.Current as TRegistro_LanFixacao).lDupFixacao.Sum(p => p.Vl_liquidado).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_atual.Text = (bsFixacao.Current as TRegistro_LanFixacao).lDupFixacao.Sum(p => p.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                bsFixacao.ResetCurrentItem();
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrintRomaneio();
        }

        private void TFLan_Fixacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gDupFixacao);
            ShapeGrid.SaveShape(this, itensNotaDataGridDefault);
            ShapeGrid.SaveShape(this, gPedido);
            ShapeGrid.SaveShape(this, gFixacao);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
        }

        private void gFixacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gFixacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gFixacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gDupFixacao_DoubleClick(object sender, EventArgs e)
        {
            if (bsDupFixacao.Current != null)
                using (TFRastrearLancamentos fRastrear = new TFRastrearLancamentos())
                {
                    fRastrear.bsDuplicata.Add(bsDupFixacao.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                    fRastrear.TRastrear = TP_Rastrear.tm_duplicata;
                    fRastrear.ShowDialog();
                }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());

        }

        private void tcFinanceiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsDupFixacao.Current != null)
                bsLiquidacoes.DataSource = CamadaNegocio.Financeiro.Duplicata.TCN_LanLiquidacao.Busca((bsDupFixacao.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa,
                                                                                                      (bsDupFixacao.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_lancto,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      string.Empty,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      false,
                                                                                                      "A",
                                                                                                      0,
                                                                                                      string.Empty,
                                                                                                      null);
            else bsLiquidacoes.Clear();
        }

        private void tcNf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsItensFixacao.Current != null)
                bsItensNFPauta.DataSource = new TCD_LanFaturamento_Item().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lanctofiscal_origem = a.nr_lanctofiscal " +
                                                                    "and x.id_nfitem_origem = a.id_nfitem " +
                                                                    "and x.cd_empresa = '" + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                                    "and x.nr_lanctofiscal_destino = " + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                                    "and x.id_nfitem_destino = " + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
            else bsItensNFPauta.Clear();
        }

        private void tcDetPauta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetPauta.SelectedIndex.Equals(1) && bsItensNFPauta.Current != null)
                    bsCompPauta.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_bal_aplicacao_pedido x " +
                                                                "inner join tb_fat_aplicacao_x_notafiscal  y " +
                                                                "on x.id_aplicacao = y.id_aplicacao " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.cd_produto = a.cd_produto " +
                                                                "and x.id_lanctoestcomp = a.id_lanctoestoque " +
                                                                "and y.cd_empresa = '" + (bsItensNFPauta.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                                "and y.nr_lanctofiscal = " + (bsItensNFPauta.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                                "and y.id_nfitem = " + (bsItensNFPauta.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                                }
                                            }, 0, string.Empty, string.Empty, string.Empty);
                
            else
                bsCompPauta.Clear();
        }

        private void tcDetComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetComp.SelectedIndex.Equals(1) && bsItensFixacao.Current != null)
                bsCompFixar.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_gro_fixacao_nf x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.cd_produto = a.cd_produto " +
                                                                "and x.id_lanctoestdevcomp = a.id_lanctoestoque " +
                                                                "and x.cd_empresa = '" + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                                "and x.nr_lanctofiscal = " + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                                "and x.id_nfitem = " + (bsItensFixacao.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                                }
                                            }, 0, string.Empty, string.Empty, string.Empty);
            else bsCompFixar.Clear();
        }

        private void tcDetDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetDev.SelectedIndex.Equals(1) && bsNFDev.Current != null)
                bsDevComp.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.cd_produto = a.cd_produto " +
                                                                "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                                "and x.cd_empresa = '" + (bsNFDev.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                                "and x.nr_lanctofiscal_destino = " + (bsNFDev.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                                "and x.id_nfitem_destino = " + (bsNFDev.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                                }
                                            }, 0, string.Empty, string.Empty, string.Empty);
            else bsDevComp.Clear();
        }

        private void tcPauta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPauta.SelectedIndex.Equals(1) && bsItensNota.Current != null)
            {
                tcDetDev.SelectedIndex = 0;
                bsNFDev.DataSource = new TCD_LanFaturamento_Item().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctofiscal_destino = a.nr_lanctofiscal " +
                                                            "and x.id_nfitem_destino = a.id_nfitem " +
                                                            "and x.tp_operacao = 'D' " +//Devolucao
                                                            "and x.cd_empresa = '" + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                            "and x.nr_lanctofiscal_origem = " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                            "and x.id_nfitem_origem = " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
            }
            else bsNFDev.Clear();
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedIndex.Equals(1))
                tcNf.SelectedIndex = 0;
            else if (tcDetalhes.SelectedIndex.Equals(2))
                tcFinanceiro.SelectedIndex = 0;
        }

        private void tcDetNFPauta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetNFPauta.SelectedTab.Equals(tpCompPauta) && bsItensNota.Current != null)
                bsCompNFPauta.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_bal_aplicacao_pedido x " +
                                                                    "inner join tb_fat_aplicacao_x_notafiscal  y " +
                                                                    "on x.id_aplicacao = y.id_aplicacao " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.cd_produto = a.cd_produto " +
                                                                    "and x.id_lanctoestcomp = a.id_lanctoestoque " +
                                                                    "and y.cd_empresa = '" + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_empresa.Trim() + "' " +
                                                                    "and y.nr_lanctofiscal = " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Nr_lanctofiscal.ToString() + " " +
                                                                    "and y.id_nfitem = " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Id_nfitem.ToString() + ")"
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
            else bsCompNFPauta.Clear();
        }
    }
}
