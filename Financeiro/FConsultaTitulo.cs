using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Financeiro.Titulo;
using Utils;
using FormBusca;
using CamadaNegocio.Financeiro.Titulo;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFConsultaTitulo : Form
    {
        public bool Altera_Relatorio;

        public TFConsultaTitulo()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            RB_TpTitulo_Emitidos.Checked = true;
            ST_NaoCompensado.Checked = false;
            ST_Vencido.Checked = false;
            ST_Impresso.Checked = false;
            ST_Compensado.Checked = false;
            ST_Descontado.Checked = false;
            ST_Cancelado.Checked = false;
            ST_Repassado.Checked = false;
            st_enviado.Checked = false;
            st_chtroco.Checked = false;
            cd_empresa.Clear();
            cd_historico.Clear();
            CD_Clifor.Clear();
            NM_Clifor.Clear();
            CD_Banco.Clear();
            NR_Cheque.Clear();
            rB_Emissao.Checked = true;
            DT_Inic.Clear();
            DT_Final.Clear();
        }

        private void afterBusca()
        {
            tabControl1.SelectedIndex = 0;
            BS_Titulo.DataSource = TCN_LanTitulo.Busca(cd_empresa.Text,
                                                       0, CD_Banco.Text,
                                                       NR_Cheque.Text, 
                                                       string.Empty, 
                                                       TP_Titulo.NM_Valor,
                                                       string.Empty, 
                                                       rG_FiltroData.NM_Valor,
                                                       DT_Inic.Text,
                                                       DT_Final.Text,
                                                       Vl_Titulo_Inic.Value,
                                                       Vl_Titulo_Final.Value,
                                                       NM_Clifor.Text,
                                                       (ST_Compensado.Checked ? "S" : ST_NaoCompensado.Checked ? "N" : string.Empty),
                                                       string.Empty,
                                                       (ST_Descontado.Checked ? "D" : string.Empty),
                                                       (ST_Vencido.Checked ? "VV" : string.Empty),
                                                       (ST_Cancelado.Checked ? "C" : "NC"),
                                                       (ST_Impresso.Checked ? "S" : string.Empty),
                                                       (cbImprimir.Checked ? "N" : string.Empty),
                                                       (ST_Repassado.Checked ? "R" : string.Empty),
                                                       (st_enviado.Checked ? "E":string.Empty), 
                                                       (cb_devolvido.Checked ? "V":string.Empty),
                                                       ST_ChequesAvulsos.Checked,
                                                       st_custodia.Checked,
                                                       st_depositado.Checked,
                                                       st_chtroco.Checked,
                                                       string.Empty, 
                                                       cd_historico.Text, 
                                                       string.Empty, 
                                                       string.Empty,
                                                       nr_lotecustodiadeposito.Text,
                                                       0, 
                                                       string.Empty, 
                                                       null);
            tot_cheques.Text = (BS_Titulo.DataSource as TList_RegLanTitulo).Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void afterDevolucao()
        {
            if (BS_Titulo.Count > 0)
            {
                if (!(BS_Titulo.List as TList_RegLanTitulo).Exists(p=> p.St_processar))
                {
                    MessageBox.Show("Não existe cheque selecionados para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLanDevolucaoCheque fDev = new TFLanDevolucaoCheque())
                {

                    string cd_empresa = string.Empty;
                    (BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar).ForEach(p =>
                    {
                        if (p.Status_compensado.Trim().ToUpper().Equals("S") ||
                            p.Status_compensado.Trim().ToUpper().Equals("D") ||
                            p.Status_compensado.Trim().ToUpper().Equals("R") ||
                            p.Status_compensado.Trim().ToUpper().Equals("N") ||
                            p.Status_compensado.Trim().ToUpper().Equals("U"))
                            if(string.IsNullOrEmpty(cd_empresa))
                            {
                                cd_empresa = p.Cd_empresa;
                                fDev.lCheques.Add(p);
                            }
                            else if (p.Cd_empresa.Trim().Equals(cd_empresa.Trim()))
                                fDev.lCheques.Add(p);
                    });
                    if (fDev.ShowDialog() == DialogResult.OK)
                        if (fDev.rDev != null)
                            try
                            {
                                if (fDev.rDev.lCheques.Count < 1)
                                {
                                    MessageBox.Show("Não existe cheque selecionado para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                TCN_DevolucaoCheque.GravarDevolucaoCheque(fDev.rDev, null);
                                MessageBox.Show("Cheques devolvidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cb_devolvido.Checked = true;
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim());
                            }
                        else
                            MessageBox.Show("Não existe registro de devolução de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Não existe cheques para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterCompensa()
        {
            if (BS_Titulo.Count > 0)
            {
                if(!(BS_Titulo.DataSource as TList_RegLanTitulo).Exists(p=> p.St_processar))
                {
                    MessageBox.Show("Não existe cheques selecionados para compensar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_LiquidaTitulo fCompensar = new TFLan_LiquidaTitulo())
                {
                    string cd_contager = string.Empty;
                    string cd_empresa = string.Empty;
                    (BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar).ForEach(p =>
                        {
                            if((p.Status_compensado.Trim().ToUpper().Equals("N") ||
                                p.Status_compensado.Trim().ToUpper().Equals("V") ||
                                p.Status_compensado.Trim().ToUpper().Equals("U") ||
                                p.Status_compensado.Trim().ToUpper().Equals("L") ||
                                p.Status_compensado.Trim().ToUpper().Equals("E") ||
                                p.Status_compensado.Trim().ToUpper().Equals("T")) && 
                                (!p.St_contaCF))
                                if (string.IsNullOrEmpty(cd_contager) || string.IsNullOrEmpty(cd_empresa))
                                {
                                    cd_contager = p.Cd_contager;
                                    cd_empresa = p.Cd_empresa;
                                    fCompensar.lCheques.Add(p);
                                }
                                else if (p.Cd_contager.Trim().Equals(cd_contager.Trim()) &&
                                    p.Cd_empresa.Trim().Equals(cd_empresa.Trim()))
                                    fCompensar.lCheques.Add(p);
                            
                        });
                    fCompensar.pTp_mov = TP_Titulo.NM_Valor.Trim();
                    fCompensar.pCd_empresa = cd_empresa.Trim();
                    fCompensar.pCd_contager = cd_contager.Trim();
                    if(fCompensar.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LanTitulo.CompensarCheques(fCompensar.lCheques, null);
                            MessageBox.Show("Cheques compensados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim());
                        }
                }
            }
            else
                MessageBox.Show("Não existe cheques para compensar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterDesconta()
        {
            using (TFLanLoteCH fLote = new TFLanLoteCH())
            {
                fLote.ShowDialog();
            }
        }

        private void CustodiarCheque()
        {
            using (TFLanCustodiaCH fCustodia = new TFLanCustodiaCH())
            {
                fCustodia.ShowDialog();
            }
        }

        private void afterEstornaCompensacao()
        {
            if (MessageBox.Show("Confirma Estorno da Compensação do cheque?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    TCN_LanTitulo.EstornarCompensacaoTitulo(BS_Titulo.Current as TRegistro_LanTitulo, null);
                    MessageBox.Show("Compensação estornada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void GerarCredito()
        {
            if (BS_Titulo.Current != null)
            {
                if (!(BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("N"))
                {
                    MessageBox.Show("Só é permitido gerar créditos para cheques com status a compensar.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Tp_mov.Trim().ToUpper().Equals("P"))
                {
                    using (TFLan_GerarCreditoTitulo fCredTitulo = new TFLan_GerarCreditoTitulo())
                    {
                        fCredTitulo.rCheque = (BS_Titulo.Current as TRegistro_LanTitulo);
                        if (fCredTitulo.ShowDialog() == DialogResult.OK)
                            if(fCredTitulo.rCredTitulo != null)
                                if (TCN_LanCaixa.DataCaixa(fCredTitulo.rCredTitulo.Cd_contagercredito,
                                                           fCredTitulo.rCredTitulo.Dt_lancto,
                                                           null))
                                {
                                    try
                                    {
                                        TCN_LanTitulo.GerarCreditoTitulo(fCredTitulo.rCredTitulo, null);
                                        MessageBox.Show("Credito gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                    MessageBox.Show("Não foi possivel gerar crédito do titulo " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_cheque +
                                        " porque a data do crédito " +
                                        " é inferior ao ultimo fechamento de caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Só é permitido gerar créditos de cheques emitidos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EstornarCredito()
        {
            if (BS_Titulo.Current != null)
            {
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Cheque ja se encontra COMPENSADO.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa =
                    new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                        "where x.cd_contager = a.cd_contager " +
                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                        "and x.tp_lancto = 'GC' " +
                                        "and x.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                        "and x.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "' " +
                                        "and x.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + ")"
                        }
                    }, 0, string.Empty);
                if (lCaixa.Count.Equals(0))
                {
                    MessageBox.Show("Cheque não possui lançamento de credito para ser estornado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma estorno do CREDITO gerado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(lCaixa[0], null);
                        MessageBox.Show("Credito estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ImprimirOrdemPago()
        {
            if (BS_Titulo.Current != null)
            {
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Tp_mov.Trim().ToUpper().Equals("P"))
                {
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource bs_cheque = new BindingSource();
                        bs_cheque.DataSource = new TList_RegLanTitulo() { BS_Titulo.Current as TRegistro_LanTitulo };
                        Rel.DTS_Relatorio = bs_cheque;
                        Rel.Ident = "TFOrdem_Pago";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = string.Empty;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "ORDEM DE PAGO";
                        //Buscar clifor da empresa
                        BindingSource bs_cliforemp = new BindingSource();
                        bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                        Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                        //Buscar Endereco Empresa
                        BindingSource bs_endemp = new BindingSource();
                        bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " + 
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                        Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
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
                                               "ORDEM DE PAGO",
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
                                                   "ORDEM DE PAGO",
                                                   fImp.pDs_mensagem);
                    }
                }
                else
                    MessageBox.Show("Permitido imprimir ordem pago somente para cheques EMITIDOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar cheque para imprimir ordem pago.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CorrigirTitulo()
        {
            if (BS_Titulo.Current != null)
            {
                if (!(BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("N"))
                {
                    MessageBox.Show("Só é permitido fazer correções em cheques com status a compensar.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCorrigirTitulo fCor = new TFCorrigirTitulo())
                {
                    fCor.rTitulo = BS_Titulo.Current as TRegistro_LanTitulo;
                    if(fCor.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LanTitulo.AlterarTitulo(fCor.rTitulo, null);
                            MessageBox.Show("Cheque alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
            }
        }

        private void GerarChequeTroco()
        {
            using (TFChequeTroco fChTroco = new TFChequeTroco())
            {
                fChTroco.ShowDialog();
                afterNovo();
                st_chtroco.Checked = true;
                afterBusca();
            }
        }

        private void afterReimprimirCheque(bool Altera_titulo)
        {
            if ((BS_Titulo.List as TList_RegLanTitulo).Exists(p => p.St_processar && (!p.Status_compensado.ToUpper().Equals("C"))))
            {
                //Verificar se o terminal esta parametrizado para impressao grafica
                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal + "'"
                                    }
                                }, "isnull(a.tp_impcheque, 'G')");
                if (obj.ToString().Equals("T"))
                    try
                    {
                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque((BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar));
                        //Imprimir Cópia Cheques
                        if (MessageBox.Show("Deseja Imprimir a Cópia dos Cheques?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                        ImprimirCopiaCheque((BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar));
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    new FormRelPadrao.LayoutCheque().Imprime_Cheque((BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar));
                    //Imprimir Cópia Cheques
                    if (MessageBox.Show("Deseja Imprimir a Cópia dos Cheques?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    ImprimirCopiaCheque((BS_Titulo.List as TList_RegLanTitulo).FindAll(p => p.St_processar));
                }
            }
            else
                //Chamar tela para imprimir cheques na sequencia
                using (TFReimprimirCheques fReimprime = new TFReimprimirCheques())
                {
                    fReimprime.ShowDialog();
                }
        }

        private void ImprimirCopiaCheque(List<TRegistro_LanTitulo> ListaTitulo)
        {
            if (BS_Titulo.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_cheque = new BindingSource();
                    bs_cheque.DataSource = ListaTitulo.OrderBy(p => p.Nr_cheque).ToList();
                    Rel.DTS_Relatorio = bs_cheque;
                    Rel.Ident = "TFCopiaCheque";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "CÓPIA CHEQUE";
                    //Buscar Empresa
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(ListaTitulo[0].Cd_empresa, string.Empty, string.Empty, null);

                    //Buscar moeda para impressao dos cheques
                    ListaTitulo.ForEach(p =>
                        {
                            //Buscar moeda da conta gerencial
                            CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                                new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                                    "where x.cd_moeda = a.cd_moeda "+
                                                    "and x.cd_contager = '" + p.Cd_contager + "')"
                                    }
                                }, 1, string.Empty);
                            if (lMoeda.Count > 0)
                            {
                                p.Ds_moeda = lMoeda[0].Ds_moeda_singular;
                                p.Ds_moeda_plural = lMoeda[0].Ds_moeda_plural;
                            }
                            //p.ValorExtenso + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                        });
                    Rel.Adiciona_DataSource("BIMEMPRESA", BinEmpresa);
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
                                           "CÓPIA CHEQUE",
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
                                               "CÓPIA CHEQUE",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome|150;a.CD_EMPRESA|Código|80"
                            , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_banco|=|'" + CD_Banco.Text + "'"
                , new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_banco|Descrição|150;CD_banco|Código|80|nr_agencia|Agencia|80"
                , new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico }, 
                                    new TCD_CadHistorico());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição|150;a.CD_Historico|Código|80"
                , new Componentes.EditDefault[] { cd_historico }, new TCD_CadHistorico(), string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_clifor|=|'" + CD_Clifor.Text + "'"
              , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor } , new TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, String.Empty); 
        }

        private void TFConsultaTitulo_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dG_Titulo);
            Utils.ShapeGrid.RestoreShape(this, gCaixa);
            Utils.ShapeGrid.RestoreShape(this, gDevCheque);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelFiltro.set_FormatZero();
            ShapeGrid.RestoreShape(this, dG_Titulo);
            tlpDetCheque.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
            BB_Gravar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR LANCAR CHEQUE AVULSO", null);
            BB_Excluir.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR CAIXA OU BANCO", null);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }
            
        private void LancarTitulo()
        {
            using (TFLanTitulo LanctoTitulo = new TFLanTitulo())
            {
                LanctoTitulo.BS_Titulo.AddNew();
                if (LanctoTitulo.ShowDialog() == DialogResult.OK)
                {
                    if (LanctoTitulo.BS_Titulo.Count > 0)
                    {
                        (LanctoTitulo.BS_Titulo.Current as TRegistro_LanTitulo).St_lancarcaixa = true;
                        try
                        {
                            TCN_LanTitulo.GravarTitulo(LanctoTitulo.BS_Titulo.Current as TRegistro_LanTitulo, null);
                            MessageBox.Show("Cheque Gravado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NR_Cheque.Text = (LanctoTitulo.BS_Titulo.Current as TRegistro_LanTitulo).Nr_cheque;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void SubstituirTitulo()
        {
            if(BS_Titulo.Current != null)
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("N"))
                {
                    TFLanTitulo fTitulo = new TFLanTitulo();
                    try
                    {
                        fTitulo.Tp_titulo = (BS_Titulo.Current as TRegistro_LanTitulo).Tp_titulo.Trim();
                        fTitulo.Cd_contager = (BS_Titulo.Current as TRegistro_LanTitulo).Cd_contager;
                        fTitulo.Dt_emissao = (BS_Titulo.Current as TRegistro_LanTitulo).Dt_emissao;
                        fTitulo.Dt_vencto = (BS_Titulo.Current as TRegistro_LanTitulo).Dt_vencto;
                        fTitulo.Cd_empresa = (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa;
                        fTitulo.Cd_historico = (BS_Titulo.Current as TRegistro_LanTitulo).Cd_historico;
                        fTitulo.Ds_historico = (BS_Titulo.Current as TRegistro_LanTitulo).Ds_historico;
                        fTitulo.Cd_banco = (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco;
                        fTitulo.Ds_banco = (BS_Titulo.Current as TRegistro_LanTitulo).Ds_banco;
                        fTitulo.Cd_portador = (BS_Titulo.Current as TRegistro_LanTitulo).Cd_portador;
                        fTitulo.Ds_portador = (BS_Titulo.Current as TRegistro_LanTitulo).Ds_portador;
                        fTitulo.Nr_cgccpf = (BS_Titulo.Current as TRegistro_LanTitulo).Nr_cgccpf;
                        fTitulo.Nr_cheque = string.Empty;
                        fTitulo.Nomeclifor = (BS_Titulo.Current as TRegistro_LanTitulo).Nomeclifor;
                        fTitulo.pFone = (BS_Titulo.Current as TRegistro_LanTitulo).Fone;
                        fTitulo.Vl_titulo = (BS_Titulo.Current as TRegistro_LanTitulo).Vl_titulo;
                        fTitulo.Observacao = (BS_Titulo.Current as TRegistro_LanTitulo).Observacao;

                        fTitulo.tp_titulo.Enabled = false;
                        fTitulo.CD_Empresa.Enabled = false;
                        fTitulo.BB_Empresa.Enabled = false;
                        fTitulo.CD_Conta.Enabled = false;
                        fTitulo.BB_Conta.Enabled = false;
                        fTitulo.CD_Historico.Enabled = false;
                        fTitulo.BB_Historico.Enabled = false;
                        fTitulo.CD_Portador.Enabled = false;
                        fTitulo.BB_Portador.Enabled = false;
                        fTitulo.vl_titulo.Enabled = false;

                        if (fTitulo.ShowDialog() == DialogResult.OK)
                            if (fTitulo.BS_Titulo.Current != null)
                                try
                                {
                                    TCN_LanTitulo.SubstituirTitulo((BS_Titulo.Current as TRegistro_LanTitulo), (fTitulo.BS_Titulo.Current as TRegistro_LanTitulo), null);
                                    MessageBox.Show("Titulo Substituido com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                    }
                    finally
                    {
                        fTitulo.Dispose();
                    }
                }
                else
                    MessageBox.Show("Não é permitido substituir titulo com status diferente de <COMPENSAR>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ST_Compensado_CheckedChanged(object sender, EventArgs e)
        {
            ST_NaoCompensado.Enabled = (!ST_Compensado.Checked);
            ST_Descontado.Enabled = (!ST_Compensado.Checked);
            ST_Cancelado.Enabled = (!ST_Compensado.Checked);
            ST_Vencido.Enabled = (!ST_Compensado.Checked);
            ST_Impresso.Enabled = (!ST_Compensado.Checked);
            ST_Repassado.Enabled = (!ST_Compensado.Checked);                       
        }

        private void ST_NaoCompensado_CheckedChanged(object sender, EventArgs e)
        {
                ST_Compensado.Enabled = (!ST_NaoCompensado.Checked);
                ST_Descontado.Enabled = (!ST_NaoCompensado.Checked);
                ST_Cancelado.Enabled = (!ST_NaoCompensado.Checked);

            if (ST_NaoCompensado.Checked == false)
            {
                ST_Vencido.Checked = (ST_NaoCompensado.Checked);
                ST_Impresso.Checked = (ST_NaoCompensado.Checked);
                ST_Repassado.Checked = (ST_NaoCompensado.Checked);                 
            }
        
        }

        private void ST_Descontado_CheckedChanged(object sender, EventArgs e)
        {
            ST_NaoCompensado.Enabled = (!ST_Descontado.Checked);
            ST_Compensado.Enabled = (!ST_Descontado.Checked);
            ST_Cancelado.Enabled = (!ST_Descontado.Checked);
            ST_Vencido.Enabled = (!ST_Descontado.Checked);
            ST_Impresso.Enabled = (!ST_Descontado.Checked);
            ST_Repassado.Enabled = (!ST_Descontado.Checked);

          }

        private void ST_Vencido_CheckedChanged(object sender, EventArgs e)
        {
            ST_Descontado.Enabled = (!ST_Vencido.Checked);
            ST_Cancelado.Enabled = (!ST_Vencido.Checked);
            ST_Compensado.Enabled = (!ST_Vencido.Checked);

            if (ST_Vencido.Checked == false)
            {
                ST_NaoCompensado.Checked = (ST_Vencido.Checked);
                ST_Impresso.Checked = (ST_Vencido.Checked);
                ST_Repassado.Checked = (ST_Vencido.Checked);
            }

        }

        private void ST_Cancelado_CheckedChanged(object sender, EventArgs e)
        {
            ST_NaoCompensado.Enabled = (!ST_Cancelado.Checked);
            ST_Descontado.Enabled = (!ST_Cancelado.Checked);
            ST_Compensado.Enabled = (!ST_Cancelado.Checked);
            ST_Vencido.Enabled = (!ST_Cancelado.Checked);
            ST_Impresso.Enabled = (!ST_Cancelado.Checked);
            ST_Repassado.Enabled = (!ST_Cancelado.Checked);
            toolStripMenuTitulo.Enabled = (!ST_Cancelado.Checked);
        }

        private void ST_Impresso_CheckedChanged(object sender, EventArgs e)
        {
            ST_Descontado.Enabled = (!ST_Impresso.Checked);
            ST_Compensado.Enabled = (!ST_Impresso.Checked);
            ST_Cancelado.Enabled = (!ST_Impresso.Checked);
            
            if (ST_Impresso.Checked == false)
            {
                ST_NaoCompensado.Checked = (ST_Impresso.Checked);
                ST_Vencido.Checked = (ST_Impresso.Checked);
                ST_Repassado.Checked = (ST_Impresso.Checked);
            }
        }

        private void ST_NaoImpresso_CheckedChanged(object sender, EventArgs e)
        {
            ST_Descontado.Enabled = (!ST_Repassado.Checked);
            ST_Compensado.Enabled = (!ST_Repassado.Checked);
            ST_Cancelado.Enabled = (!ST_Repassado.Checked);
            ST_NaoCompensado.Enabled = !ST_Repassado.Checked;

            if (ST_Repassado.Checked == false)
            {
                ST_Vencido.Checked = (ST_Repassado.Checked);
                ST_Impresso.Checked = (ST_Repassado.Checked);
            }            
        }

        private void Vl_Titulo_Inic_EnabledChanged(object sender, EventArgs e)
        {
            if (!Vl_Titulo_Inic.Enabled)
                Vl_Titulo_Inic.Value = 0;
        }

        private void Vl_Titulo_Final_EnabledChanged(object sender, EventArgs e)
        {
            if (!Vl_Titulo_Final.Enabled)
                Vl_Titulo_Final.Value = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BS_Titulo.Current != null)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    (BS_Titulo.Current as TRegistro_LanTitulo).lCaixa.Clear();
                    NV_Titulo.BindingSource = BS_Titulo;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    (BS_Titulo.Current as TRegistro_LanTitulo).lCaixa =
                        TCN_TituloXCaixa.Buscar((BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa,
                                                (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco,
                                                (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque, "", 0, "", null);
                    BS_Titulo.ResetCurrentItem();
                    NV_Titulo.BindingSource = bsCaixa;
                }
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            LancarTitulo();
        }

        private void BB_Descontar_Click(object sender, EventArgs e)
        {
            afterDesconta();
            afterBusca();
        }

        private void BB_Compensar_Click(object sender, EventArgs e)
        {
            afterCompensa();
            afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (BS_Titulo.Count > 0)
            {
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Titulo ja se encontra cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("T"))
                {
                    object obj = new CamadaDados.Faturamento.PDV.TCD_TrocoCH().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_banco",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctocheque",
                                            vOperador = "=",
                                            vVL_Busca = (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString()
                                        }
                                    }, "b.id_cupom");
                    if(obj != null)
                    {
                        MessageBox.Show("Cheque troco ja foi utilizado no recebimento de uma venda.\r\n" +
                                        "Para cancelar cheque troco, necessario cancelar a venda Nº" + obj.ToString(), "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (MessageBox.Show("Confirma cancelamento do titulo " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_cheque.Trim() + "?\r\n\r\n" +
                                    "O cancelamento do titulo ira cancelar os lançamentos de caixa,\r\n" +
                                    "bem como as liquidações de contas pagar/receber que deram origem ao mesmo.", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (BS_Titulo.Current as TRegistro_LanTitulo).St_lancarcaixa = true;
                    try
                    {
                        TCN_LanTitulo.CancelarTitulo((BS_Titulo.Current as TRegistro_LanTitulo), null);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dG_Titulo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 3))
                if (e.Value.ToString().Trim().ToUpper().Equals("COMPENSADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else if (e.Value.ToString().Trim().ToUpper().Equals("COMPENSAR"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                else if (e.Value.ToString().Trim().ToUpper().Equals("DESCONTADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                else if (e.Value.ToString().Trim().ToUpper().Equals("REPASSADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Peru;
                else if (e.Value.ToString().Trim().ToUpper().Equals("ENVIADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                else if (e.Value.ToString().Trim().ToUpper().Equals("CUSTODIADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Olive;
                else if (e.Value.ToString().Trim().ToUpper().Equals("DEPOSITADO"))
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Indigo;
                else
                    dG_Titulo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void TFConsultaTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                CorrigirTitulo();
            else if (e.KeyCode.Equals(Keys.F3))
                BB_Descontar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                BB_Excluir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                BB_Compensar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterReimprimirCheque(false);
            else if (e.KeyCode.Equals(Keys.F9))
                tsBB_Transferir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F11))
                tsBB_Extornar_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.D))
                afterDevolucao();
            else if (e.Control && e.KeyCode.Equals(Keys.C))
                CustodiarCheque();
            else if (e.Control && e.KeyCode.Equals(Keys.E))
                EstornarCredito();
            else if (e.Control && e.KeyCode.Equals(Keys.T))
                GerarChequeTroco();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }

            else if (e.KeyCode.Equals(Keys.F12))
                afterReimprimirCheque(false);
            else if (e.Control && (e.KeyCode == Keys.P))
                afterReimprimirCheque(true);
            else if (e.Control && e.KeyCode.Equals(Keys.N))
                tsBB_EnumerarCheque_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.G))
                GerarCredito();
        }

        private void lCaixaDataGridDefault_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("SIM"))
                    gCaixa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gCaixa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dG_Titulo_DoubleClick(object sender, EventArgs e)
        {
            if(BS_Titulo.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.BS_Titulo.Add(BS_Titulo.Current as TRegistro_LanTitulo);
                    fRastrear.TRastrear = TP_Rastrear.tm_cheque;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void ImprimeRelatorio()
        {
            if (BS_Titulo != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = BS_Titulo;
                    Rel.Ident = "TFConsultaTitulo";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
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
        }

        #region "BOTÕES DO TOOLSTRIP"

            private void tsBB_Transferir_Click(object sender, EventArgs e)
            {
                if (BS_Titulo.Count > 0)
                {
                    if ((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("N"))
                    {
                        using(TFTransfTitulo fTransf = new TFTransfTitulo())
                        {
                            (BS_Titulo.Current as TRegistro_LanTitulo).Dt_compensacao = DateTime.Now;
                            fTransf.St_emitido = (BS_Titulo.Current as TRegistro_LanTitulo).Tp_titulo.Trim().ToUpper().Equals("P");
                            fTransf.bsTitulo.Add(BS_Titulo.Current as TRegistro_LanTitulo);
                            if (fTransf.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    TCN_LanTitulo.TransferirTitulo((BS_Titulo.Current as TRegistro_LanTitulo), null);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                        };
                    }
                    else
                        MessageBox.Show("Não é permitido transferir titulo com status diferente de <COMPENSAR>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void tsBB_SubstituirTitulo_Click(object sender, EventArgs e)
            {
                SubstituirTitulo();
            }

            private void tsBB_Extornar_Click(object sender, EventArgs e)
            {
                if (BS_Titulo.Current != null)
                    if ((BS_Titulo.Current as TRegistro_LanTitulo).Status_compensado.Trim().ToUpper().Equals("S"))
                        afterEstornaCompensacao();
                    else
                        MessageBox.Show("Titulo não se encontra compensado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void tsBB_EnumerarCheque_Click(object sender, EventArgs e)
            {
                EnumerarCheque();
            }

            private void EnumerarCheque()
            {
                if ((BS_Titulo.DataSource as TList_RegLanTitulo).Exists(p => p.St_processar))
                    try
                    {
                        string cd_empresa = string.Empty;
                        string cd_banco = string.Empty;
                        TList_RegLanTitulo listaCheque = new TList_RegLanTitulo();
                        (BS_Titulo.DataSource as TList_RegLanTitulo).FindAll(p => p.St_processar).ForEach(p =>
                            {
                                if (string.IsNullOrEmpty(cd_empresa) ||
                                    string.IsNullOrEmpty(cd_banco))
                                {
                                    cd_empresa = p.Cd_empresa;
                                    cd_banco = p.Cd_banco;
                                    listaCheque.Add(p);
                                }
                                else if (p.Cd_empresa.Trim().Equals(cd_empresa.Trim()) &&
                                    p.Cd_banco.Trim().Equals(cd_banco.Trim()))
                                    listaCheque.Add(p);
                            });
                        bool continua = true;
                        //Verificar se existe cheque numerado
                        if (listaCheque.Exists(p => decimal.Parse(p.Nr_cheque) > decimal.Zero))
                            if (MessageBox.Show("Existe cheques já numerados deseja numera-los novamente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.No)
                                continua = false;
                        if (continua)
                        {
                            //PEDI PARA INFORMAR O NR DO CHEQUE
                            int NRSequencial = 0;

                            //ABRE O INPUT BOX PARA SER INFORMADO O NUMERO SEQUENCIAL
                            InputBox box = new InputBox();
                            box.Text = "Informe o número sequêncial do primeiro cheque da lista";
                            box.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            string retorno = box.ShowDialog();

                            if (!string.IsNullOrEmpty(retorno))
                            {
                                try
                                {
                                    NRSequencial = Convert.ToInt32(retorno);
                                }
                                catch
                                { throw new Exception("Atenção o número sequêncial informado não é válido!"); }

                                if (NRSequencial > 0)
                                {
                                    listaCheque.ForEach(p=>
                                        {
                                            p.Nr_cheque = NRSequencial.ToString();
                                            NRSequencial++;
                                        });
                                    
                                    //GRAVA A ALTERAÇÃO DOS TITULOS
                                    try
                                    {
                                        TCN_LanTitulo.AlterarTitulos(listaCheque, null);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    BS_Titulo.ResetBindings(true);

                                    MessageBox.Show("Cheques enumerados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                    throw new Exception("Atenção, É necessário informar o número sequêncial do cheque!");
                            }
                        }
                    }
                    catch (Exception erro)
                    { MessageBox.Show("ERRO: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                    MessageBox.Show("Não existe cheques selecionados para enumerar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        #endregion
                    
            private void repassedeCheque_ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Imprimir_Relatorio_RepassedeCheque();
            }
            private void Imprimir_Relatorio_RepassedeCheque()
            {
                if (BS_Titulo.Count > 0)
                {
                    if (ST_Repassado.Checked)
                    {

                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            Rel.DTS_Relatorio = BS_Titulo;
                            Rel.Ident = "TFConsultaTitulo_RepasseDeCheque";
                            Rel.NM_Classe = Name;
                            Rel.Modulo = Tag.ToString().Substring(0, 3);
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
                        MessageBox.Show("Se Deseja Imprimir Este Relatório,\n"+
                                            " voce deve selecionar REPASSADOS e Buscar Novamente!");
                }
                else
                    MessageBox.Show("Não Existe Cheque Repassado Para ser Impresso No Relatório!");
            }

            private void consultaTítulosToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ImprimeRelatorio();
            }

            private void TFConsultaTitulo_FormClosed(object sender, FormClosedEventArgs e)
            {
                ShapeGrid.SaveShape(this, dG_Titulo);
            }

            private void bb_gerarcredito_Click(object sender, EventArgs e)
            {
                GerarCredito();
            }

            private void bb_devolver_Click(object sender, EventArgs e)
            {
                afterDevolucao();
            }

            private void BS_Titulo_PositionChanged(object sender, EventArgs e)
            {
                if (BS_Titulo.Current != null)
                {
                    //Buscar detalhes devolucao de cheque
                    (BS_Titulo.Current as TRegistro_LanTitulo).lDevolucao =
                        new TCD_DevolucaoCheque().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctocheque",
                                    vOperador = "=",
                                    vVL_Busca = (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_banco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "'"
                                }
                            }, 0, string.Empty, "a.dt_devolucao desc");
                    BS_Titulo.ResetCurrentItem();
                    if((BS_Titulo.Current as TRegistro_LanTitulo).lDevolucao.Count > 0)
                        tlpDetCheque.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 20);
                    else
                        tlpDetCheque.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
                }
            }

            private void bb_ordempago_Click(object sender, EventArgs e)
            {
                ImprimirOrdemPago();
            }

            private void BB_Custodia_Click(object sender, EventArgs e)
            {
                CustodiarCheque();
            }

            private void llbPesquisa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                if (llbPesquisa.Tag.ToString().Trim().Equals("N"))
                {
                    //Mudar para modo completo
                    llbPesquisa.Text = "<<<Pesquisa Normal";
                    tlpCentral.RowStyles[0].Height = 163;
                    llbPesquisa.Tag = "C";
                }
                else
                {
                    //Mudar para modo normal
                    llbPesquisa.Text = "Pesquisa Avançada>>>";
                    tlpCentral.RowStyles[0].Height = 89;
                    llbPesquisa.Tag = "N";
                    afterNovo();
                }
            }

            private void BB_Imprimir_Click(object sender, EventArgs e)
            {
                afterReimprimirCheque(false);
            }

            private void dG_Titulo_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if ((e.ColumnIndex == 0) && (BS_Titulo.Current != null))
                {
                    (BS_Titulo.Current as TRegistro_LanTitulo).St_processar = !(BS_Titulo.Current as TRegistro_LanTitulo).St_processar;
                    BS_Titulo.ResetCurrentItem();
                    soma_valor_atual.Text = (BS_Titulo.DataSource as TList_RegLanTitulo).FindAll(p => p.St_processar).Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }

            private void bb_corrigir_Click(object sender, EventArgs e)
            {
                CorrigirTitulo();
            }

            private void dG_Titulo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (dG_Titulo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;
                if (BS_Titulo.Count < 1)
                    return;
                PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanTitulo());
                TList_RegLanTitulo lComparer;
                SortOrder direcao = SortOrder.None;
                if ((dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                    (dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
                {
                    lComparer = new TList_RegLanTitulo(lP.Find(dG_Titulo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                    foreach (DataGridViewColumn c in dG_Titulo.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Ascending;
                }
                else
                {
                    lComparer = new TList_RegLanTitulo(lP.Find(dG_Titulo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                    foreach (DataGridViewColumn c in dG_Titulo.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Descending;
                }
                (BS_Titulo.DataSource as TList_RegLanTitulo).Sort(lComparer);
                BS_Titulo.ResetBindings(false);
                dG_Titulo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
            }

            private void gDevCheque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (gDevCheque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;
                if (bsDev.Count < 1)
                    return;
                PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_DevolucaoCheque());
                TList_DevolucaoCheque lComparer;
                SortOrder direcao = SortOrder.None;
                if ((gDevCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                    (gDevCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
                {
                    lComparer = new TList_DevolucaoCheque(lP.Find(gDevCheque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                    foreach (DataGridViewColumn c in gDevCheque.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Ascending;
                }
                else
                {
                    lComparer = new TList_DevolucaoCheque(lP.Find(gDevCheque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                    foreach (DataGridViewColumn c in gDevCheque.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Descending;
                }
                (bsDev.List as TList_DevolucaoCheque).Sort(lComparer);
                bsDev.ResetBindings(false);
                gDevCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
            }

            private void gCaixa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (gCaixa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                    return;
                if (bsCaixa.Count < 1)
                    return;
                PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanCaixa());
                TList_LanCaixa lComparer;
                SortOrder direcao = SortOrder.None;
                if ((gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                    (gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
                {
                    lComparer = new TList_LanCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                    foreach (DataGridViewColumn c in gCaixa.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Ascending;
                }
                else
                {
                    lComparer = new TList_LanCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                    foreach (DataGridViewColumn c in gCaixa.Columns)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direcao = SortOrder.Descending;
                }
                (bsCaixa.List as TList_LanCaixa).Sort(lComparer);
                bsCaixa.ResetBindings(false);
                gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;   
            }

            private void TFConsultaTitulo_FormClosing(object sender, FormClosingEventArgs e)
            {
                Utils.ShapeGrid.SaveShape(this, dG_Titulo);
                Utils.ShapeGrid.SaveShape(this, gCaixa);
                Utils.ShapeGrid.SaveShape(this, gDevCheque);
            }

            private void bb_estornarCred_Click(object sender, EventArgs e)
            {
                EstornarCredito();
            }

            private void bb_chtroco_Click(object sender, EventArgs e)
            {
                GerarChequeTroco();
            }
    }
}