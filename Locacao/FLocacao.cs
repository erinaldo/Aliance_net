using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.ProgEspecialVenda;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Locacao;
using CamadaDados.Locacao.Cadastros;

namespace Locacao
{
    public partial class TFLocacao : Form
    {
        public bool Altera_Relatorio = false;
        private string Vendedordefault = string.Empty;
        private int month
        { get; set; }
        private int daysMonth
        { get; set; }
        private TList_ItensLocacao lItensLocacao
        { get; set; }
        private CamadaDados.Servicos.TList_LanServico lOS
        { get; set; }
        private TList_CadPrecoItens lPreco
        { get; set; }
        private CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente;
        private bool St_duplicata
        { get; set; }
        private TList_CFGLocacao lCfg { get; set; }


        public TFLocacao()
        {
            InitializeComponent();
            for (int i = 2013; i < 2050; i++)
                cbxAno.Items.Add(i);
            cbxStatusProd.SelectedIndex = 0;

            //FRETE
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("EMPRESA", "E"));
            cbx.Add(new TDataCombo("CLIENTE", "C"));
            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";
        }

        private void BuscarConfig()
        {
            lCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(string.Empty, string.Empty, null);
            if (lCfg.Count > 0)
            {
                lblDespesas.Visible = !lCfg[0].St_HoraAuto;
                tp_frete.Visible = !lCfg[0].St_HoraAuto;
                vl_despesas.Visible = !lCfg[0].St_HoraAuto;
                tp_frete.SelectedIndex = lCfg[0].St_HoraAuto ? 1 : 0;//Cliente
                lblPessoasAut.Visible = !lCfg[0].St_HoraAuto;
                id_pessoa.Visible = !lCfg[0].St_HoraAuto;
                bb_autorizada.Visible = !lCfg[0].St_HoraAuto;
                nm_pessoa.Visible = !lCfg[0].St_HoraAuto;
                lblEntrada.Visible = !lCfg[0].St_HoraAuto;
                vl_entrada.Visible = !lCfg[0].St_HoraAuto;
                lblResponsavel.Visible = !lCfg[0].St_HoraAuto;
                nm_responsavel.Visible = !lCfg[0].St_HoraAuto;
                lblCondPgto.Visible = !lCfg[0].St_HoraAuto;
                cbCondPgto.Visible = !lCfg[0].St_HoraAuto;
                lblPortador.Visible = !lCfg[0].St_HoraAuto;
                cbPortador.Visible = !lCfg[0].St_HoraAuto;
            }
        }

        private void Cancelar()
        {
            bsProdutoLoc.Clear();
            bsLocacao.Clear();
            LimparCampos();
            AddLocacao();
        }
        private void LimparCampos()
        {
            cd_clifor.BackColor = Color.White;
            bb1.BackColor = Color.White;
            bb1.Text = string.Empty;
            bb2.Text = string.Empty;
            bb2.BackColor = Color.White;
            bb3.Text = string.Empty;
            bb3.BackColor = Color.White;
            bb4.Text = string.Empty;
            bb4.BackColor = Color.White;
            bb5.Text = string.Empty;
            bb5.BackColor = Color.White;
            bb6.Text = string.Empty;
            bb6.BackColor = Color.White;
            bb7.Text = string.Empty;
            bb7.BackColor = Color.White;
            bb8.Text = string.Empty;
            bb8.BackColor = Color.White;
            bb9.Text = string.Empty;
            bb9.BackColor = Color.White;
            bb10.Text = string.Empty;
            bb10.BackColor = Color.White;
            bb11.Text = string.Empty;
            bb11.BackColor = Color.White;
            bb12.Text = string.Empty;
            bb12.BackColor = Color.White;
            bb13.Text = string.Empty;
            bb13.BackColor = Color.White;
            bb14.Text = string.Empty;
            bb14.BackColor = Color.White;
            bb15.Text = string.Empty;
            bb15.BackColor = Color.White;
            bb16.Text = string.Empty;
            bb16.BackColor = Color.White;
            bb17.Text = string.Empty;
            bb17.BackColor = Color.White;
            bb18.Text = string.Empty;
            bb18.BackColor = Color.White;
            bb19.Text = string.Empty;
            bb19.BackColor = Color.White;
            bb20.Text = string.Empty;
            bb20.BackColor = Color.White;
            bb21.Text = string.Empty;
            bb21.BackColor = Color.White;
            bb22.Text = string.Empty;
            bb22.BackColor = Color.White;
            bb23.Text = string.Empty;
            bb23.BackColor = Color.White;
            bb24.Text = string.Empty;
            bb24.BackColor = Color.White;
            bb25.Text = string.Empty;
            bb25.BackColor = Color.White;
            bb26.Text = string.Empty;
            bb26.BackColor = Color.White;
            bb27.Text = string.Empty;
            bb27.BackColor = Color.White;
            bb28.Text = string.Empty;
            bb28.BackColor = Color.White;
            bb29.Text = string.Empty;
            bb29.BackColor = Color.White;
            bb30.Text = string.Empty;
            bb30.BackColor = Color.White;
            bb31.Text = string.Empty;
            bb31.BackColor = Color.White;
            bb32.Text = string.Empty;
            bb32.BackColor = Color.White;
            bb33.Text = string.Empty;
            bb33.BackColor = Color.White;
            bb34.Text = string.Empty;
            bb34.BackColor = Color.White;
            bb35.Text = string.Empty;
            bb35.BackColor = Color.White;
            bb36.Text = string.Empty;
            bb36.BackColor = Color.White;
            bb37.Text = string.Empty;
            bb37.BackColor = Color.White;
        }

        private void afterGrava()
        {
            if (bsLocacao.Current != null)
            {
                if (pDados.validarCampoObrigatorio())
                {
                    if (bsHistorico.Count.Equals(0))
                        new_historico();

                    (bsLocacao.Current as TRegistro_Locacao).Ds_condPgto = cbCondPgto.SelectedItem != null ?
                        (cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Ds_condpgto : string.Empty;
                    if (vl_despesas.Focused)
                        vl_despesas_Leave(this, new EventArgs());
                    else if (vl_entrada.Focused)
                        (bsLocacao.Current as TRegistro_Locacao).Vl_entrada = vl_entrada.Value;
                    if ((bsLocacao.Current as TRegistro_Locacao).Vl_entrada == 0)
                        if (!bloqueioCredito())
                        {
                            MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                           "Financeiro não poderá ser gravado.", "Mensagem", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }
                    if (bsItens.Count.Equals(0))
                    {
                        MessageBox.Show("Obrigatório adicionar itens para gravar a locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Cd_condPgto))
                    {
                        MessageBox.Show("Obrigatório informar Condição de Pagamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsLocacao.Current as TRegistro_Locacao).Tp_frete.ToUpper().Equals("E") && vl_despesas.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatório informar despesas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_despesas.Focus();
                        return;
                    }
                    if (!string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Cd_condPgto) &&
                         string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Cd_portador) &&
                         (cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas > 0)
                    {
                        MessageBox.Show("Obrigatório informar Portador quando Condição de Pagto estiver selecionada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbPortador.Focus();
                        return;
                    }
                    if ((cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas.Equals(0) &&
                        (cbCondPgto.SelectedItem as TRegistro_CadCondPgto).St_comentradabool &&
                        vl_entrada.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatório informar Vl.Entrada quando Cond.Pagto for à vista!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_entrada.Focus();
                        return;
                    }
                    try
                    {
                        if ((bsLocacao.Current as TRegistro_Locacao).lItens.Exists(p => p.Tp_tabela.Equals("4")))
                        {
                            using (TFParcelas fParc = new TFParcelas())
                            {
                                (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p =>
                                    p.Vl_desconto = p.Vl_desconto.Equals(decimal.Zero) ? CalcularDescEspecial(p.Vl_unitario, p.Cd_produto, p.Id_tabelastr) : p.Vl_desconto);
                                fParc.Vl_locacao = (bsLocacao.Current as TRegistro_Locacao).lItens.FindAll(p =>
                                    p.Tp_tabela.Equals("4")).Sum(p => (p.QTDItem * p.Vl_unitario - p.Vl_desconto));
                                fParc.rLocacao = bsLocacao.Current as TRegistro_Locacao;
                                if (fParc.ShowDialog() == DialogResult.OK)
                                    if (fParc.rLocacao.lParc.Count > 0)
                                    {
                                        (bsLocacao.Current as TRegistro_Locacao).lParc = fParc.rLocacao.lParc;
                                        bsLocacao.ResetCurrentItem();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatório calcular parcelas da locação mensal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório calcular parcelas da locação mensal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        else
                            (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p =>
                                    p.Vl_desconto = p.Vl_desconto.Equals(decimal.Zero) ? CalcularDescEspecial(p.Vl_unitario, p.Cd_produto, p.Id_tabelastr) : p.Vl_desconto);

                        //Verificar se Locação possui entrada
                        (bsLocacao.Current as TRegistro_Locacao).St_comEntrada = vl_entrada.Value > 0 ? true : false;
                        (bsLocacao.Current as TRegistro_Locacao).Id_locacao = null;

                        //Retirar lançamento de estoque para acessórios
                        (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p => p.lAcessorio.ForEach(a => a.St_gerarLanctoS = false));

                        CamadaNegocio.Locacao.TCN_Locacao.Gravar(bsLocacao.Current as TRegistro_Locacao, null);
                        MessageBox.Show("Locação gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PrintOrdemLocacao();
                        Cancelar();
                        AddLocacao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cancelar();
                    }
                }
            }
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty(cd_clifor.Text)))
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(cd_clifor.Text,
                                                               decimal.Zero,
                                                               true,
                                                               ref rDados,
                                                               null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private decimal CalcularDescEspecial(decimal Vl_unit,
                                          string Cd_produto,
                                          string Cd_tabelapreco)
        {
            TRegistro_ProgEspecialVenda rProg = null;

            //Verificar se existe programacao especial de venda 
            TList_ProgEspecialVenda lProg = new TList_ProgEspecialVenda();
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                lProg = new TCD_ProgEspecialVenda().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + cd_clifor.Text.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + cd_clifor.Text.Trim() + "'))"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "a.ID_TabelaLocacao = " + Cd_tabelapreco.Trim() + ""
                                }
                            }, 1, string.Empty);
            }
            if (lProg.Count > 0)
                rProg = lProg[0];
            else
            {
                lProg = new TCD_ProgEspecialVenda().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + cd_clifor.Text.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + cd_clifor.Text.Trim() + "'))"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.ID_TabelaLocacao",
                                    vOperador = "is",
                                    vVL_Busca = "null"
                                }
                            }, 1, string.Empty);
                if (lProg.Count > 0)
                    rProg = lProg[0];
                else rProg = null;
            }
            if (rProg != null)
                if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                    {
                        ds_informeCliente.Text = "Cliente possui desconto especial de LOCAÇÃO de R$" + rProg.Valor.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) +
                                                 "para " + (string.IsNullOrEmpty(rProg.Cd_produto) ? "Grupo " + rProg.Ds_grupo : rProg.Ds_produto);
                        return rProg.Valor;
                    }
                    else
                    {
                        ds_informeCliente.Text = "Cliente possui desconto especial de LOCAÇÃO de " + rProg.Valor.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%" +
                                                 " para:\r\n" + (string.IsNullOrEmpty(rProg.Cd_produto) ? "Grupo " + rProg.Ds_grupo : rProg.Ds_produto);
                        return Vl_unit * rProg.Valor / 100;
                    }
                }
                else
                {
                    ds_informeCliente.Text = string.Empty;
                    return decimal.Zero;
                }
            else
            {
                ds_informeCliente.Text = string.Empty;
                return decimal.Zero;
            }
        }

        private void AlterarDescCliente()
        {
            //Alterar Prog. Especial de Venda dos Itens
            if (bsItens.Count > 0)
            {
                (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p =>
                {
                    decimal desc =
                    CalcularDescEspecial(p.Vl_unitario,
                                                    p.Cd_produto,
                                                    p.Id_tabelastr);
                    if (desc > 0)
                    {
                        p.Vl_desconto = desc;
                        p.St_progEspecial = true;
                    }
                    else
                    {
                        p.St_progEspecial = false;
                        p.Vl_desconto = decimal.Zero;
                    }
                });
                bsItens_PositionChanged(this, new EventArgs());
                bsLocacao.ResetCurrentItem();
            }
        }

        private Button NextDay(string bb, string text)
        {
            Button retorno = new Button();
            switch (bb)
            {
                case ("bb0"):
                    {
                        bb1.Text = text;
                        return bb1;
                    }
                case ("bb1"):
                    {
                        bb2.Text = text;
                        return bb2;
                    }
                case ("bb2"):
                    {
                        bb3.Text = text;
                        return bb3;
                    }
                case ("bb3"):
                    {
                        bb4.Text = text;
                        return bb4;
                    }
                case ("bb4"):
                    {
                        bb5.Text = text;
                        return bb5;
                    }
                case ("bb5"):
                    {
                        bb6.Text = text;
                        return bb6;
                    }
                case ("bb6"):
                    {
                        bb7.Text = text;
                        return bb7;
                    }
                case ("bb7"):
                    {
                        bb8.Text = text;
                        return bb8;
                    }
                case ("bb8"):
                    {
                        bb9.Text = text;
                        return bb9;
                    }
                case ("bb9"):
                    {
                        bb10.Text = text;
                        return bb10;
                    }
                case ("bb10"):
                    {
                        bb11.Text = text;
                        return bb11;
                    }
                case ("bb11"):
                    {
                        bb12.Text = text;
                        return bb12;
                    }
                case ("bb12"):
                    {
                        bb13.Text = text;
                        return bb13;
                    }
                case ("bb13"):
                    {
                        bb14.Text = text;
                        return bb14;
                    }
                case ("bb14"):
                    {
                        bb15.Text = text;
                        return bb15;
                    }
                case ("bb15"):
                    {
                        bb16.Text = text;
                        return bb16;
                    }
                case ("bb16"):
                    {
                        bb17.Text = text;
                        return bb17;
                    }
                case ("bb17"):
                    {
                        bb18.Text = text;
                        return bb18;
                    }
                case ("bb18"):
                    {
                        bb19.Text = text;
                        return bb19;
                    }
                case ("bb19"):
                    {
                        bb20.Text = text;
                        return bb20;
                    }
                case ("bb20"):
                    {
                        bb21.Text = text;
                        return bb21;
                    }
                case ("bb21"):
                    {
                        bb22.Text = text;
                        return bb22;
                    }
                case ("bb22"):
                    {
                        bb23.Text = text;
                        return bb23;
                    }
                case ("bb23"):
                    {
                        bb24.Text = text;
                        return bb24;
                    }
                case ("bb24"):
                    {
                        bb25.Text = text;
                        return bb25;
                    }
                case ("bb25"):
                    {
                        bb26.Text = text;
                        return bb26;
                    }
                case ("bb26"):
                    {
                        bb27.Text = text;
                        return bb27;
                    }
                case ("bb27"):
                    {
                        bb28.Text = text;
                        return bb28;
                    }
                case ("bb28"):
                    {
                        bb29.Text = text;
                        return bb29;
                    }
                case ("bb29"):
                    {
                        bb30.Text = text;
                        return bb30;
                    }
                case ("bb30"):
                    {
                        bb31.Text = text;
                        return bb31;
                    }
                case ("bb31"):
                    {
                        bb32.Text = text;
                        return bb32;
                    }
                case ("bb32"):
                    {
                        bb33.Text = text;
                        return bb33;
                    }
                case ("bb33"):
                    {
                        bb34.Text = text;
                        return bb34;
                    }
                case ("bb34"):
                    {
                        bb35.Text = text;
                        return bb35;
                    }
                case ("bb35"):
                    {
                        bb36.Text = text;
                        return bb36;
                    }
                case ("bb36"):
                    {
                        bb37.Text = text;
                        return bb37;
                    }
                default: { return retorno; }
            }

        }

        private void PreencherMes(string day)
        {
            if (day.Trim().ToUpper().Equals("SUNDAY"))
                PositionWeek(-1);
            else if (day.ToUpper().Equals("MONDAY"))
                PositionWeek(0);
            else if (day.Trim().ToUpper().Equals("TUESDAY"))
                PositionWeek(1);
            else if (day.Trim().ToUpper().Equals("WEDNESDAY"))
                PositionWeek(2);
            else if (day.Trim().ToUpper().Equals("THURSDAY"))
                PositionWeek(3);
            else if (day.Trim().ToUpper().Equals("FRIDAY"))
                PositionWeek(4);
            else if (day.Trim().ToUpper().Equals("SATURDAY"))
                PositionWeek(5);
        }

        private void PositionWeek(int y)
        {
            //x = dia do mes
            //Posicao dos dias do mes no calendario
            //y = Posicao - Inicio da semana do mes
            //b = DATA dd/MM/yyyy
            for (int x = 1; daysMonth + 1 > x; x++)
            {
                y++;
                string lista = string.Empty;
                string b = (x < 10 ? "0" : string.Empty) + x.ToString() + "/" + (month < 10 ? "0" : string.Empty) + month.ToString() + "/" + cbxAno.SelectedItem.ToString();
                if (bsProdutoLoc.Current != null)
                {
                    //NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.GreenYellow;
                    //Formar dias em que produto está em manutenção

                    //Formar Disponibilidade do Produto nos dias do Mes selecionado
                    decimal xLoc =
                    lItensLocacao.Where(p => DateTime.Parse(b) >= (string.IsNullOrEmpty(p.Dt_trocastr) ? p.Dt_locacao : p.Dt_troca) &&
                                        DateTime.Parse(b) <= (string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev >= DateTime.Now ?
                                                              p.Dt_prevdev : string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev <= DateTime.Now ?
                                                              DateTime.Parse(b) : p.Dt_devolucao)).ToList().Count();

                    decimal xManut =
                   lOS.Where(p => Convert.ToDateTime(DateTime.Parse(b).ToString("dd/MM/yyyy 23:59:59")) >= p.Dt_abertura &&
                                       Convert.ToDateTime(DateTime.Parse(b).ToString("dd/MM/yyyy 00:00:00")) <= (string.IsNullOrEmpty(p.Dt_finalizadastr) && string.IsNullOrEmpty(p.Dt_previsaostr) ?
                                                             DateTime.Now : string.IsNullOrEmpty(p.Dt_finalizadastr) && p.Dt_previsao <= DateTime.Now ?
                                                             DateTime.Now : string.IsNullOrEmpty(p.Dt_finalizadastr) && p.Dt_previsao >= DateTime.Now ?
                                                             p.Dt_previsao : p.Dt_finalizada)).ToList().Count();


                    decimal xManutParcial =
                    lOS.Where(p => DateTime.Parse(b).ToString("dd/MM/yyyy") == Convert.ToDateTime(p.Dt_abertura).ToString("dd/MM/yyyy") ||
                                        DateTime.Parse(b).ToString("dd/MM/yyyy") == (string.IsNullOrEmpty(p.Dt_finalizadastr) ?
                                                              Convert.ToDateTime(p.Dt_previsao).ToString("dd/MM/yyyy") : Convert.ToDateTime(p.Dt_finalizadastr).ToString("dd/MM/yyyy"))).ToList().Count();
                    //Verificar se disponibilidade do dia e parcial
                    decimal xParcial =
                    lItensLocacao.Where(p => DateTime.Parse(b).ToString("dd/MM/yyyy") == Convert.ToDateTime((string.IsNullOrEmpty(p.Dt_trocastr) ? p.Dt_locacao : p.Dt_troca)).ToString("dd/MM/yyyy") ||
                                        DateTime.Parse(b).ToString("dd/MM/yyyy") == (string.IsNullOrEmpty(p.Dt_devolucaostr) ?
                                                              Convert.ToDateTime(p.Dt_prevdev).ToString("dd/MM/yyyy") : Convert.ToDateTime(p.Dt_devolucao).ToString("dd/MM/yyyy"))).ToList().Count();


                    if (xParcial > 0 || xManut > 0)
                    {
                        if (xManut > 0)
                            NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Blue;
                        if (xParcial > 0 || xManutParcial > 0)
                            NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Yellow;
                    }
                    else if (xLoc.Equals(0))
                    {
                        //Marcar Dia da Locacao
                        if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                            NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                        else
                            NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        //Bloquear - Item selecionado nao esta disponivel na data de locação.
                        if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_bloqItem = true;
                        NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Red;
                    }
                    if (bsItens.Count > 0)
                    {
                        if ((bsLocacao.Current as TRegistro_Locacao).lItens.Exists
                            (p => p.Cd_produto.Equals((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto)))
                        {
                            if (DateTime.Parse(b).ToString("dd/MM/yyyy") ==
                                DateTime.Parse((bsLocacao.Current as TRegistro_Locacao).lItens.Find(p => p.Cd_produto ==
                                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto).Dt_prevdevstr).ToString("dd/MM/yyyy"))
                                NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    //Marcar Dia da Locacao
                    if (!string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr.SoNumero()))
                        if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                            NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                        else
                            NextDay("bb" + y.ToString(), x.ToString());
                    else
                        NextDay("bb" + y.ToString(), x.ToString());
                }
            }
        }

        private void BuscarPrecoItem(string pCd_produto, string pId_tabela)
        {
            if (!string.IsNullOrEmpty(pCd_produto) &&
                !string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
            {
                lPreco =
                    new TCD_CadPrecoItens().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + pCd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_tabela",
                                vOperador = "=",
                                vVL_Busca = string.IsNullOrEmpty(pId_tabela) ? "a.id_tabela" : pId_tabela
                            }
                        }, 0, string.Empty);
                if (lPreco.Count.Equals(0))
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario = decimal.Zero;
                else if (lPreco.Count.Equals(1))
                {
                    (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario = lPreco[0].Vl_preco;
                    (bsItens.Current as TRegistro_ItensLocacao).Id_tabela = lPreco[0].Id_tabela;
                    (bsItens.Current as TRegistro_ItensLocacao).Ds_tabela = lPreco[0].Ds_tabela;
                    (bsItens.Current as TRegistro_ItensLocacao).Tp_tabela = lPreco[0].Tp_tabela;
                }
                else if (lPreco.Count > 1)
                    if (!BuscarTabelaPreco(pCd_produto))
                        throw new Exception("Obrigatório selecionar tabela de preço.");
            }
            else
                throw new Exception("Obrigatório informar empresa!");
        }

        private void BuscarItens()
        {
            if (dt_locacao.Enabled == true)
            {
                MessageBox.Show("Confirme a nova Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
            {
                MessageBox.Show("Informe a EMPRESA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr.SoNumero()))
            {
                MessageBox.Show("Informe a data de locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cd_produto.Text) && string.IsNullOrEmpty(cd_grupo.Text))
                UtilPesquisa.BuscarProduto(string.Empty,
                                           cbEmpresa.SelectedValue.ToString(),
                                           cbEmpresa.SelectedText.ToString(),
                                           string.Empty,
                                           new Componentes.EditDefault[] { cd_produto },
                                           new TpBusca[] { new TpBusca { vNM_Campo = "isnull(e.st_patrimonio, 'N')", vOperador = "=", vVL_Busca = "'S'" } });
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length && string.IsNullOrEmpty(cd_grupo.Text))
                UtilPesquisa.BuscarProduto(cd_produto.Text,
                                           cbEmpresa.SelectedValue.ToString(),
                                           cbEmpresa.SelectedText.ToString(),
                                           string.Empty,
                                           new Componentes.EditDefault[] { cd_produto },
                                           new TpBusca[] { new TpBusca { vNM_Campo = "isnull(e.st_patrimonio, 'N')", vOperador = "=", vVL_Busca = "'S'" } });

            if (!string.IsNullOrEmpty(cd_produto.Text) || !string.IsNullOrEmpty(cd_grupo.Text))
            {
                if (!string.IsNullOrEmpty(cd_produto.Text))
                {
                    //Buscar lengt cd_produto
                    CamadaDados.Diversos.TList_CadParamSys lParam =
                        CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                     string.Empty,
                                                                     decimal.Zero,
                                                                     null);
                    if (lParam.Count > 0)
                        if (cd_produto.Text.Trim().Length < lParam[0].Tamanho)
                            cd_produto.Text = cd_produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                }
                //Buscar produto
                bsProdutoLoc.DataSource =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao(cd_produto.Text,
                                                                                        cd_grupo.Text,
                                                                                        cbEmpresa.SelectedValue.ToString(),
                                                                                        true,
                                                                                        Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss"),
                                                                                        null).FindAll(p => cbxStatusProd.SelectedIndex.Equals(1) ?
                                                                                                          p.StatusProduto.Equals("D") :
                                                                                                          cbxStatusProd.SelectedIndex.Equals(2) ?
                                                                                                          p.StatusProduto.Equals("M") :
                                                                                                          cbxStatusProd.SelectedIndex.Equals(3) ?
                                                                                                          (p.StatusProduto.Equals("L") || p.StatusProduto.Equals("C")) :
                                                                                                          p.StatusProduto.Equals(p.StatusProduto));
                bsProdutoLoc_PositionChanged(this, new EventArgs());

            }
        }

        private void BuscarMes()
        {
            month = 0;
            if (cbxMes.Text.ToUpper().Equals("JANEIRO"))
                month = 01;
            else if (cbxMes.Text.ToUpper().Equals("FEVEREIRO"))
                month = 02;
            else if (cbxMes.Text.ToUpper().Equals("MARÇO"))
                month = 03;
            else if (cbxMes.Text.ToUpper().Equals("ABRIL"))
                month = 04;
            else if (cbxMes.Text.ToUpper().Equals("MAIO"))
                month = 05;
            else if (cbxMes.Text.ToUpper().Equals("JUNHO"))
                month = 06;
            else if (cbxMes.Text.ToUpper().Equals("JULHO"))
                month = 07;
            else if (cbxMes.Text.ToUpper().Equals("AGOSTO"))
                month = 08;
            else if (cbxMes.Text.ToUpper().Equals("SETEMBRO"))
                month = 09;
            else if (cbxMes.Text.ToUpper().Equals("OUTUBRO"))
                month = 10;
            else if (cbxMes.Text.ToUpper().Equals("NOVEMBRO"))
                month = 11;
            else if (cbxMes.Text.ToUpper().Equals("DEZEMBRO"))
                month = 12;

            // obtém a quantidade de dias MÊS e ANO selecionados
            System.Globalization.Calendar c = new System.Globalization.GregorianCalendar();
            daysMonth = c.GetDaysInMonth(int.Parse(cbxAno.SelectedItem.ToString()), month);
            //Verificar dia da semana em que se incia o MÊS selecionado
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.SelectedItem.ToString());
            string day = date.DayOfWeek.ToString();
            //Preencher mes
            LimparCampos();
            PreencherMes(day);
        }

        private void DisponibilidadeProduto(DateTime data)
        {
            if (bsProdutoLoc.Current != null)
            {
                //Calcular ultimo dia do mes
                DateTime d = data.AddMonths(1);
                d = d.AddDays(-1);
                if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(1) ||
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(0))
                {
                    //Disponibilidade Manutenção
                    lOS = new CamadaDados.Servicos.TCD_LanServico().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.DT_Abertura",
                            vOperador = ">=",
                            vVL_Busca = "'" + data.ToString("yyyyMMdd") + "' or " +
                                         "a.DT_Previsao >= '" + data.ToString("yyyyMMdd") + "' or " +
                                        "a.DT_Finalizada >= '" + data.ToString("yyyyMMdd") + "' or a.DT_Finalizada is null"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.DT_Abertura",
                            vOperador = "<=",
                            vVL_Busca = "'" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                         "a.DT_Previsao <= '" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                        "a.DT_Finalizada <= '" + d.ToString("yyyyMMdd 23:59:59") + "' or a.DT_Finalizada is null"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.CD_ProdutoOS",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.ST_OS, 'AB')",
                            vOperador = "=",
                            vVL_Busca = "'AB'"
                        }
                    }, 0, string.Empty, string.Empty);

                    //Disponibilidade Locação
                    lItensLocacao = new TCD_ItensLocacao().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.dt_troca, loc.dt_locacao)",
                            vOperador = ">=",
                            vVL_Busca = "'" + data.ToString("yyyyMMdd") + "' or " +
                                        "a.DT_PrevDev >= '" + data.ToString("yyyyMMdd") + "' or " +
                                        "isnull(a.DT_Devolucao, '" + d.ToString("yyyyMMdd 23:59:59") + "') >= '" + data.ToString("yyyyMMdd") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.dt_troca, loc.dt_locacao)",
                            vOperador = "<=",
                            vVL_Busca = "'" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                        "a.DT_PrevDev <= '" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                        "a.DT_Devolucao <= '" + d.ToString("yyyyMMdd 23:59:59") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(loc.st_registro, '0')",
                            vOperador = "<>",
                            vVL_Busca = "'8'"
                        },
                        new TpBusca()
                        {
                             vNM_Campo = "isnull(a.st_registro, 'A')",
                             vOperador = "<>",
                             vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                             vNM_Campo = "a.cd_produto",
                             vOperador = "=",
                             vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                        }
                    }, 0, string.Empty, false);
                }
                else
                {
                    lOS = new CamadaDados.Servicos.TList_LanServico();
                    lItensLocacao = new TList_ItensLocacao();
                }
            }
            // obtém a quantidade de dias MÊS e ANO selecionados
            System.Globalization.Calendar c = new System.Globalization.GregorianCalendar();
            daysMonth = c.GetDaysInMonth(int.Parse(cbxAno.SelectedItem.ToString()), month);
            //Verificar dia da semana em que se incia o MÊS selecionado
            string day = data.DayOfWeek.ToString();
            //Preencher mes
            LimparCampos();
            PreencherMes(day);
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                              Cd_endereco.Text,
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
                if (lEnd.Count > 0)
                {
                    Cd_endereco.Text = lEnd[0].Cd_endereco;
                    Ds_endereco.Text = lEnd[0].Ds_endereco;
                    Cep.Text = lEnd[0].Cep;
                    Ds_end.Text = lEnd[0].Ds_endereco;
                    Numero.Text = lEnd[0].Numero;
                    Bairro.Text = lEnd[0].Bairro;
                    DS_Complemento.Text = lEnd[0].Ds_complemento;
                    Proximo.Text = lEnd[0].Proximo;
                    CD_Cidade.Text = lEnd[0].Cd_cidade;
                    Ds_Cidade.Text = lEnd[0].DS_Cidade;
                    UF.Text = lEnd[0].UF;
                }
            }
        }

        private void BuscarCondPagto()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                //Buscar Condições de pgamento Amarradas ao Cliente
                cbCondPgto.DataSource =
                    new TCD_CadCondPgto().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FIN_Clifor_X_CondPgto x " +
                                            "where x.CD_CondPGTO = a.CD_CondPGTO " +
                                            "and x.cd_clifor = '" + cd_clifor.Text.Trim() + "') "
                            }
                        }, 0, string.Empty);
                if (cbCondPgto.Items.Count == 0)
                {
                    //Buscar todas as Condições de Pagamento
                    cbCondPgto.DataSource =
                    new TCD_CadCondPgto().Select(null, 0, string.Empty);
                }
                cbCondPgto.DisplayMember = "DS_CondPGTO";
                cbCondPgto.ValueMember = "CD_CondPGTO";
                cbPortador.SelectedIndex = -1;
                if (lCfg.Count > 0 ? lCfg[0].St_HoraAuto : false)
                {
                    if ((cbCondPgto.DataSource as TList_CadCondPgto).Exists(p => p.Qt_parcelas.Equals(0)))
                        cbCondPgto.SelectedIndex = (cbCondPgto.DataSource as TList_CadCondPgto).IndexOf((cbCondPgto.DataSource as TList_CadCondPgto).First(p => p.Qt_parcelas.Equals(0)));
                    else cbCondPgto.SelectedIndex = 0;
                }
                else cbCondPgto.SelectedIndex = -1;
                if (cbCondPgto.SelectedValue != null)
                {
                    //Buscar Portadores
                    cbPortador.DataSource = new TCD_CadPortador().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.TP_PortadorPDV",
                                                        vOperador = "=",
                                                        vVL_Busca = (cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas.Equals(0) ? "'A'" : "'P'"
                                                    }
                                                }, 0, string.Empty, string.Empty);
                    cbPortador.DisplayMember = "DS_Portador";
                    cbPortador.ValueMember = "CD_Portador";
                    if ((cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas > 0)
                        cbPortador.SelectedIndex = 0;
                }
            }
        }

        private void BuscarEndEntrega(string pCd_endereco)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                              pCd_endereco,
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
                if (lEnd.Count > 0)
                {
                    Cep.Text = lEnd[0].Cep;
                    Ds_end.Text = lEnd[0].Ds_endereco;
                    Numero.Text = lEnd[0].Numero;
                    Bairro.Text = lEnd[0].Bairro;
                    DS_Complemento.Text = lEnd[0].Ds_complemento;
                    Proximo.Text = lEnd[0].Proximo;
                    CD_Cidade.Text = lEnd[0].Cd_cidade;
                    Ds_Cidade.Text = lEnd[0].DS_Cidade;
                    UF.Text = lEnd[0].UF;
                }
            }
        }

        private bool BuscarTabelaPreco(string pCd_produto)
        {
            string vColunas = "b.DS_Tabela|Tabela Preço|200;" +
                                     "a.ID_Tabela|Id. Tabela|80;" +
                                     "a.Vl_preco|Vl. Preço|80";
            string vParam = "a.cd_produto|=|'" + (bsItens.Current as TRegistro_ItensLocacao).Cd_produto.Trim() + "';" +
                            "a.cd_empresa|=|'" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "';" +
                            "isnull(b.cancelado, 0)|=|0";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ds_tabelapreco },
                                     new TCD_CadPrecoItens(), vParam);

            if (linha != null)
            {
                (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario = Convert.ToDecimal(linha["Vl_preco"].ToString());
                (bsItens.Current as TRegistro_ItensLocacao).Id_tabela = Convert.ToDecimal(linha["id_tabela"].ToString());
                (bsItens.Current as TRegistro_ItensLocacao).Tp_tabela = linha["tp_tabela"].ToString();
                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto =
                     CalcularDescEspecial((bsItens.Current as TRegistro_ItensLocacao).Vl_unitario,
                                                (bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                                (bsItens.Current as TRegistro_ItensLocacao).Id_tabelastr);
                bsItens.ResetCurrentItem();
                return true;
            }
            else return false;
        }

        private void BuscarGrupo()
        {
            if (dt_locacao.Enabled == true)
            {
                MessageBox.Show("Confirme a nova Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr.SoNumero()))
            {
                MessageBox.Show("Informe a data de locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Limpar Produto selecionado
            cd_produto.Clear();
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                             "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
            BuscarItens();
            cd_grupo.Clear();
        }

        private void InserirItem(object sender, string dt_btn, bool ST_HORAS)
        {
            if (bsProdutoLoc.Current == null)
                return;

            //Verificar se produto ja esta adicionado na locação
            if ((bsLocacao.Current as TRegistro_Locacao).lItens.Exists(p =>
                p.Cd_produto.Equals((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto)))
            {
                MessageBox.Show("Produto já está selecionado na locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_bloqItem)
            {
                MessageBox.Show("Item com Nº" +
                    (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                    (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto +
                    " não está disponível para a Dt.Locação " + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy"), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToDateTime(dt_btn) < Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr) && !ST_HORAS)
            {
                MessageBox.Show("Dt.Prev.Devolução não pode ser menor que a Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Criar Item locacao
            bsItens.AddNew();
            (bsItens.Current as TRegistro_ItensLocacao).Nr_Patrimonio =
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio;
            (bsItens.Current as TRegistro_ItensLocacao).Cd_produto =
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto;
            (bsItens.Current as TRegistro_ItensLocacao).Ds_produto =
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto;
            (bsItens.Current as TRegistro_ItensLocacao).Cd_grupo =
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_grupo;
            (bsItens.Current as TRegistro_ItensLocacao).Ds_grupo =
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_grupo;
            (bsItens.Current as TRegistro_ItensLocacao).Dt_locacaostr = (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr;
            //Marcar Dt.Prev.Devolucao Locacao
            (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = dt_btn;
            (bsItens.Current as TRegistro_ItensLocacao).QTDItem = 1;
            if (((Button)sender).BackColor.Equals(Color.GreenYellow) ||
                ((Button)sender).BackColor.Equals(Color.Yellow) ||
                ((Button)sender).BackColor.Equals(Color.Gray))
            {
                if (!((Button)sender).BackColor.Equals(Color.Yellow))
                {
                    //Inserir Hora da Devolução
                    if (!lCfg[0].St_HoraAuto)
                    {
                        using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
                        {
                            fQtde.Ds_label = "Hora da Devolução";
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(fQtde.pHoras.SoNumero()))
                                {
                                    if (!fQtde.pHoras.SoNumero().Length.Equals(4))
                                    {
                                        MessageBox.Show("Obrigatório informar Horário da Prev.Devolução corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = string.Empty;
                                        ((Button)sender).BackColor = Color.GreenYellow;
                                        bsItens.RemoveCurrent();
                                        bsProdutoLoc_PositionChanged(this, new EventArgs());
                                        return;
                                    }
                                    string data = Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("dd/MM/yyyy ");
                                    string dt = Convert.ToDateTime(data += fQtde.pHoras).ToString("dd/MM/yyyy HH:mm");
                                    (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = Convert.ToDateTime(dt).ToString("dd/MM/yyyy HH:mm");
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = string.Empty;
                                    ((Button)sender).BackColor = Color.GreenYellow;
                                    bsItens.RemoveCurrent();
                                    bsProdutoLoc_PositionChanged(this, new EventArgs());
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = string.Empty;
                                ((Button)sender).BackColor = Color.GreenYellow;
                                bsItens.RemoveCurrent();
                                bsProdutoLoc_PositionChanged(this, new EventArgs());
                                return;
                            }
                        }
                    }
                    else
                    {
                        string data = Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("dd/MM/yyyy ");
                        string dt = Convert.ToDateTime(data += "23:00").ToString("dd/MM/yyyy HH:mm");
                        (bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr = Convert.ToDateTime(dt).ToString("dd/MM/yyyy HH:mm");
                    }
                }
                if (Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr) <
                    Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr) && ST_HORAS)
                {
                    MessageBox.Show("Dt.Prev.Devolução não pode ser menor que a Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsItens.RemoveCurrent();
                    return;
                }
                //Se o patrimonio possuir quantidade informar
                if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade > 1)
                {
                    decimal saldo = decimal.Zero;
                    //Buscar Locações em execução no Periodo
                    TList_ItensLocacao lItens =
                    new TCD_ItensLocacao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = ">=",
                                vVL_Busca = "'" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev >= '" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada >= '" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = "<=",
                                vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev <= '" + Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada <= '" + Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(loc.st_registro, '0')",
                                vOperador = "<>",
                                vVL_Busca = "'8'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Devolucao",
                                vOperador = "is",
                                vVL_Busca = "null"
                            }
                        }, 0, string.Empty, false);
                    if (lItens.Count > 0)
                    {
                        lItens.ForEach(p =>
                            {
                                //Buscar QTD de Itens Locação em cada devolução
                                if (Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr) >= p.Dt_prevdev)
                                {
                                    object obj =
                                    new TCD_ItensLocacao().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "loc.dt_locacao",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + Convert.ToDateTime(p.Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, '0')",
                                            vOperador = "<>",
                                            vVL_Busca = "'8'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                                        },
                                         new TpBusca()
                                        {
                                            vNM_Campo = "a.dt_prevdev",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + Convert.ToDateTime(p.Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or a.DT_PrevDev < getdate()"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "isnull(SUM(A.qtditem), 0) ");

                                    if (obj != null)
                                        //Buscar saldo Minimo Periodo
                                        saldo = (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade - decimal.Parse(obj.ToString());
                                }
                                else
                                {
                                    //se no periodo não existir nenhuma dt_prev de locação calcular saldo pelo dt.prev da locação corrente
                                    object obj =
                                    new TCD_ItensLocacao().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "loc.dt_locacao",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, '0')",
                                            vOperador = "<>",
                                            vVL_Busca = "'8'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                                        },
                                         new TpBusca()
                                        {
                                            vNM_Campo = "a.dt_prevdev",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or a.DT_PrevDev < getdate()"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "isnull(SUM(A.qtditem), 0) ");
                                    if (obj != null)
                                        //Buscar saldo Minimo Periodo
                                        saldo = (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade - decimal.Parse(obj.ToString());
                                }
                            });
                    }
                    else
                    {
                        saldo = (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade;
                    }

                    //Informar Quantidade
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Ds_label = "Saldo: " + saldo;
                        fQtde.Casas_decimais = 2;
                        fQtde.Vl_default = 1;
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (saldo >= fQtde.Quantidade)
                                (bsItens.Current as TRegistro_ItensLocacao).QTDItem = fQtde.Quantidade;
                            else
                            {
                                MessageBox.Show("Não existe saldo para esse período informado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ((Button)sender).BackColor = Color.GreenYellow;
                                bsItens.RemoveCurrent();
                                bsProdutoLoc_PositionChanged(this, new EventArgs());
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar quantidade para inserir item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ((Button)sender).BackColor = Color.GreenYellow;
                            bsItens.RemoveCurrent();
                            bsProdutoLoc_PositionChanged(this, new EventArgs());
                            return;
                        }

                    }
                }
                else
                {
                    //Verificar se patrimonio possui controle de horas
                    if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_controlehorabool)
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Horas";
                            fQtde.Vl_default = (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Qtd_horas;
                            fQtde.Vl_Minimo = fQtde.Vl_default;
                            fQtde.Casas_decimais = 2;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (fQtde.Quantidade > decimal.Zero)
                                {
                                    (bsItens.Current as TRegistro_ItensLocacao).St_controlehorabool = true;
                                    (bsItens.Current as TRegistro_ItensLocacao).Qtd_horasAtual = fQtde.Quantidade;
                                    (bsItens.Current as TRegistro_ItensLocacao).Qtd_horasRetirada = fQtde.Quantidade;

                                    //Informar se item necessita de manutenção preventiva
                                    //Buscar ultima data de encerramento ordem de serviço para patrimonio informado
                                    TpBusca[] tpBuscas = new TpBusca[0];
                                    Estruturas.CriarParametro(ref tpBuscas, "a.CD_ProdutoOS", "'" + (bsItens.Current as TRegistro_ItensLocacao).Cd_produto + "'");
                                    Estruturas.CriarParametro(ref tpBuscas, "a.ST_OS", "('FE', 'PR')", "in");
                                    object dtEncerramento = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(tpBuscas, "MAX(a.DT_Finalizada)");
                                    if (dtEncerramento != null && !string.IsNullOrEmpty(dtEncerramento.ToString()))
                                    {
                                        tpBuscas = new TpBusca[0];
                                        Estruturas.CriarParametro(ref tpBuscas, "a.NR_Patrimonio", "'" + (bsItens.Current as TRegistro_ItensLocacao).Nr_Patrimonio + "'");
                                        object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutHora");
                                        object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutDia");
                                        TimeSpan intervalo = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(dtEncerramento.ToString()));

                                        bool messege = false;
                                        if (vl_manuPorHoras != null && intervalo.TotalHours > Convert.ToDouble(vl_manuPorHoras))
                                            messege = true;
                                        else if (vl_manuPorDia != null && intervalo.TotalDays > Convert.ToDouble(vl_manuPorDia))
                                            messege = true;

                                        if (messege)
                                            MessageBox.Show("PRODUTO NECESSITA DE MANUTENÇÃO PREVENTIVA.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    //else
                                    //{
                                    //    object vl_diferenca = fQtde.Quantidade - fQtde.Vl_default;
                                    //    tpBuscas = new TpBusca[0];
                                    //    Estruturas.CriarParametro(ref tpBuscas, "a.NR_Patrimonio", "'" + (bsItens.Current as TRegistro_ItensLocacao).Nr_Patrimonio + "'");
                                    //    object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutHora");
                                    //    object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutDia");
                                    //    bool messege = false;
                                    //    if (vl_manuPorHoras != null && Convert.ToDecimal(vl_diferenca) > Convert.ToDecimal(vl_manuPorHoras))
                                    //        messege = true;
                                    //    else if (vl_manuPorDia != null && (Convert.ToDecimal(vl_diferenca) / 24) > Convert.ToDecimal(vl_manuPorDia))
                                    //        messege = true;

                                    //    if (messege)
                                    //        MessageBox.Show("PRODUTO NECESSITA DE MANUTENÇÃO PREVENTIVA.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //}
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ((Button)sender).BackColor = Color.GreenYellow;
                                    bsItens.RemoveCurrent();
                                    bsProdutoLoc_PositionChanged(this, new EventArgs());
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ((Button)sender).BackColor = Color.GreenYellow;
                                bsItens.RemoveCurrent();
                                bsProdutoLoc_PositionChanged(this, new EventArgs());
                                return;
                            }

                        }
                    }
                    (bsItens.Current as TRegistro_ItensLocacao).QTDItem = 1;
                }
            }
            try
            {
                //Buscar Tabelas Preço
                BuscarPrecoItem((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto,
                                bsItens.Count > 1 ? (bsItens[bsItens.Position - 1] as TRegistro_ItensLocacao).Id_tabelastr : string.Empty);
                bsItens.ResetCurrentItem();
                //Marcar Botao
                ((Button)sender).BackColor = Color.Gray;
                AddCarrinho();
                //Selecionar Aba Itens
                tcItens.SelectTab(tpItens);
                //Desabilitar se já existir itens.
                cbEmpresa.Enabled = bsItens.Count.Equals(0);
                lbAlterarDtLocacao.Visible = bsItens.Count.Equals(0);
                if (CalcularDescEspecial((bsItens.Current as TRegistro_ItensLocacao).Vl_unitario,
                                               (bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                               (bsItens.Current as TRegistro_ItensLocacao).Id_tabelastr) > decimal.Zero)
                {
                    bb_desconto_unit.Enabled = false;
                    tot_desconto.Enabled = false;
                    tot_pcdesconto.Enabled = false;
                    (bsItens.Current as TRegistro_ItensLocacao).St_progEspecial = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bsItens.RemoveCurrent();
            }
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsLocacao.Current as TRegistro_Locacao).lItensDel.Add(
                        bsItens.Current as TRegistro_ItensLocacao);
                    bsItens.RemoveCurrent();
                    //Desabilitar se já existir itens.
                    cbEmpresa.Enabled = bsItens.Count.Equals(0);
                    lbAlterarDtLocacao.Visible = bsItens.Count.Equals(0);
                    bsProdutoLoc_PositionChanged(this, new EventArgs());
                }
        }

        private void AddLocacao()
        {
            bsLocacao.AddNew();
            BuscarConfig();
            if (lCfg.Count > 0)
            {
                cbEmpresa.SelectedValue = lCfg[0].Cd_empresa;
                tot_desconto.Text = "0,00";
                tot_pcdesconto.Text = "0,00";
                ds_informeCliente.Text = string.Empty;
                cbEmpresa.SelectedIndex = 0;
                if (!cbEmpresa.Enabled)
                    cbEmpresa.Enabled = true;
            }
            else if (lCfg.Count == 0)
            {
                MessageBox.Show("Não existe configuração de locação para nenhuma empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            if (string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr))
            {
                ds_informe.Text = "Selecione a data de locação pelo calendário!";
                dt_loc.Visible = false;
            }
            try
            {
                cbxAno.Text = DateTime.Now.ToString("yyyy");
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                BuscarMes();
            }
            catch
            {
                cbxAno.Text = DateTime.Now.ToString("yyyy");
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                BuscarMes();
            }
            //Buscar vendedor Padrao
            object obj = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginvendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                }
                            }, "a.cd_clifor");
            if (obj != null)
            {
                cd_vendedor.Text = obj.ToString();
                cd_vendedor_Leave(this, new EventArgs());
            }
        }

        private void PrintOrdemLocacao()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).St_registro.Trim().Equals("8"))
                {
                    MessageBox.Show("Não é permitido Imprimir contrato de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new TList_Locacao() { bsLocacao.Current as TRegistro_Locacao };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "TFLanLocacao_OrdemLoc";
                    Rel.NM_Classe = "TFLanLocacao_OrdemLoc";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ORDEM LOCAÇÃO";
                    //Valor extenso VL.Patrimonio
                    string vl_patrimonio =
                        new Extenso().ValorExtenso((bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio), "Real", "Reais");
                    decimal tot_patrimonio = (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("VL_PATRIMONIO", vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("TOT_PATRIMONIO", tot_patrimonio.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    //Valor total dos acessorios
                    decimal tot_vlAcessorios = 0;
                    (bsLocacao.Current as TRegistro_Locacao).lItens.ForEach(p => p.lAcessorio.ForEach(a =>
                    {
                        tot_vlAcessorios += a.Vl_unitario * a.Qtd_saldo;
                    }));
                    Rel.Parametros_Relatorio.Add("TOT_VL_ACESSORIOS", tot_vlAcessorios.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));


                    //Chave Acesso
                    (bsLocacao.Current as TRegistro_Locacao).ChaveAcesso = (bsLocacao.Current as TRegistro_Locacao).Id_locacaostr.FormatStringEsquerda(44, '0');
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
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
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as TRegistro_Locacao).Cd_clifor,
                                                                                                         (bsLocacao.Current as TRegistro_Locacao).Cd_endereco,
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
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);
                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as TRegistro_Locacao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

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
                                           "ORDEM LOCAÇÃO",
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
                                           "ORDEM LOCAÇÃO",
                                           fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatório selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddCarrinho()
        {
            if (bsItens.Count > 0)
            {
                //Buscar Produtos no Cadastro Assistente de Venda
                lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as TRegistro_ItensLocacao).Cd_produto,
                                                                                            string.Empty,
                                                                                            null);
                if (lAssistente.Count > 0)
                {
                    //Buscar Empresa
                    CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfgFrenteCaixa =
                       CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsLocacao.Current as TRegistro_Locacao).Cd_empresa, null);
                    using (Faturamento.TFAssistenteVenda fAssistente = new Faturamento.TFAssistenteVenda())
                    {
                        fAssistente.lAssistente = lAssistente;
                        fAssistente.Cd_empresa = (bsLocacao.Current as TRegistro_Locacao).Cd_empresa;
                        fAssistente.Nm_empresa = string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Nm_empresa) ? cbEmpresa.Text : (bsLocacao.Current as TRegistro_Locacao).Nm_empresa;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                {
                                    TRegistro_AcessoriosItem rAcessorios = new TRegistro_AcessoriosItem();
                                    rAcessorios.Cd_produto = p.CD_ProdVenda;
                                    rAcessorios.Ds_produto = p.DS_ProdVenda;
                                    rAcessorios.Quantidade = p.Quantidade;
                                    rAcessorios.Vl_desconto = p.Vl_desconto;

                                    //Buscar Tab. Preço pré-cadastrada para clifor
                                    object cd_tabpreco_x_clifor = null;
                                    if (!string.IsNullOrEmpty(cd_clifor.Text.Trim()))
                                    {
                                        cd_tabpreco_x_clifor = new TCD_Clifor_X_TabPreco().BuscarEscalar(new TpBusca[] { new TpBusca() { vNM_Campo = "a.CD_Clifor", vOperador = "=", vVL_Busca = "'" + cd_clifor.Text.Trim() + "'" } }, "a.CD_TabelaPreco");
                                        if (cd_tabpreco_x_clifor != null) MessageBox.Show("Cliente informado possui pré-cadastrado tabela de preço. Será utilizado para cálculo do valor unitário.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    //Buscar Vl.Unitário
                                    object vl_precoacessorio = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                                                     new TpBusca[]
                                                     {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsLocacao.Current as TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_produto",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + p.CD_ProdVenda.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_tabelapreco",
                                                            vOperador = "=",
                                                            vVL_Busca = cd_tabpreco_x_clifor == null ? "'" + lCfgFrenteCaixa[0].Cd_tabelapreco.Trim() + "'" : "'" + cd_tabpreco_x_clifor.ToString() + "'"
                                                        }
                                                     }, "a.Vl_PrecoVenda");
                                    rAcessorios.Vl_unitario = vl_precoacessorio == null || string.IsNullOrEmpty(vl_precoacessorio.ToString()) ? decimal.Zero : decimal.Parse(vl_precoacessorio.ToString());
                                    (bsItens.Current as TRegistro_ItensLocacao).lAcessorio.Add(rAcessorios);
                                });
                                bsItens.ResetCurrentItem();
                            }
                    }
                }
            }
        }

        private bool VerificarTotDesconto(TRegistro_Locacao val, bool St_percentual)
        {
            for (int i = 0; i < (val.lItens.Count); i++)
            {
                //Buscar lista de descontos configuradas para o vendedor
                CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(cd_vendedor.Text,
                                                                                    cbEmpresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);

                if (!St_percentual)
                    tot_pcdesconto.Text = (decimal.Parse(tot_desconto.Text) * 100 / (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_unitario)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                if ((bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc.Equals(0) ||
                    ((bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc < decimal.Parse(tot_pcdesconto.Text)))
                {
                    if (lDesc.Count > 0)
                    {
                        //Desconto por grupo de produto
                        if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())))
                        {
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.lItens[i].Cd_grupo.Trim())).Pc_max_desconto;
                            if (!St_percentual)
                                tot_pcdesconto.Text = (decimal.Parse(tot_desconto.Text) * 100 / (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_unitario)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            if (decimal.Parse(tot_pcdesconto.Text) > pc_max_desc)
                            {
                                MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_grupo = val.lItens[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = decimal.Parse(tot_pcdesconto.Text);
                                    if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        (bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                        return true;
                                    }
                                }
                            }
                            //else return true;
                        }
                        //Desconto por vendedor e empresa
                        if (!St_percentual)
                            tot_pcdesconto.Text = (decimal.Parse(tot_desconto.Text) * 100 / (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_unitario)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        if (decimal.Parse(tot_pcdesconto.Text) > lDesc[0].Pc_max_desconto)
                        {
                            MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = decimal.Parse(tot_pcdesconto.Text);
                                if (fLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                    return false;
                                else
                                {
                                    (bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                    return true;
                                }
                            }
                        }
                        //else return true;
                    }
                    else return true;
                }
            }
            return true;
        }

        private void TotalizarVenda()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as TRegistro_Locacao).lItens.Count > 0)
                {
                    tot_desconto.Text = (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_pcdesconto.Text = (decimal.Parse(tot_desconto.Text) * 100 / (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_unitario)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
                else
                {
                    tot_desconto.Text = "0,00";
                    tot_pcdesconto.Text = "0,00";
                }
                bsLocacao.ResetCurrentItem();
            }
        }

        private void TFLocacao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
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
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_LOC_CfgLocacao x " +
                                                        "where x.cd_empresa = a.cd_empresa) "
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbEmpresa.SelectedIndex = 0;

            //Buscar Portadores
            cbPortador.DataSource = new TCD_CadPortador().Select(null, 0, string.Empty, string.Empty);
            cbPortador.DisplayMember = "DS_Portador";
            cbPortador.ValueMember = "CD_Portador";
            AddLocacao();
            cbEmpresa.SelectedIndex = 0;
            cbPortador.SelectedIndex = -1;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            //Cancelar();
            DialogResult = DialogResult.Cancel;
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new TCD_CadClifor());
            object obj_foto = new TCD_CadClifor().executarEscalar("select foto from tb_fin_clifor where cd_clifor = '" + cd_clifor.Text.Trim() + "'", null);
            if (obj_foto != null)
                try
                {
                    bsClifor.Clear();
                    pImagens.Image = null;
                    if (bsClifor.Current == null)
                        bsClifor.AddNew();
                    (bsClifor.Current as TRegistro_CadClifor).Img = (byte[])obj_foto;
                    bsClifor.ResetCurrentItem();
                }
                catch { }
            BuscarEndereco();
            BuscarCondPagto();
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                nm_clifor.Clear();
                cd_clifor.BackColor = Color.White;
            }
            else
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(cd_clifor.Text,
                                                                                                  decimal.Zero,
                                                                                                  true,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.St_consulta = true;
                        fBloq.ShowDialog();
                        cd_clifor.BackColor = Color.Red;
                    }
                else cd_clifor.BackColor = Color.White;
            }
            //Buscar Obs Cliente
            object obj =
                new TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        }
                    }, "a.DS_Observacao");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                MessageBox.Show("OBS CLIENTE: " + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AlterarDescCliente();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            object obj_foto = new TCD_CadClifor().executarEscalar("select foto from tb_fin_clifor where cd_clifor = '" + cd_clifor.Text.Trim() + "'", null);
            if (obj_foto != null)
                try
                {
                    bsClifor.Clear();
                    pImagens.Image = null;
                    if (bsClifor.Current == null)
                        bsClifor.AddNew();
                    (bsClifor.Current as TRegistro_CadClifor).Img = (byte[])obj_foto;
                    bsClifor.ResetCurrentItem();
                }
                catch { }

            BuscarEndereco();
            BuscarCondPagto();
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                nm_clifor.Clear();
                cd_clifor.BackColor = Color.White;
            }
            else
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(cd_clifor.Text,
                                                                                                  decimal.Zero,
                                                                                                  true,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.St_consulta = true;
                        fBloq.ShowDialog();
                        cd_clifor.BackColor = Color.Red;
                    }
                else cd_clifor.BackColor = Color.White;
            }
            //Buscar Obs Cliente
            object obj =
                new TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        }
                    }, "a.DS_Observacao");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                MessageBox.Show("OBS CLIENTE: " + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AlterarDescCliente();
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                        nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                        Cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        Ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        AlterarDescCliente();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            object obj_foto = new TCD_CadClifor().executarEscalar("select foto from tb_fin_clifor where cd_clifor = '" + cd_clifor.Text.Trim() + "'", null);
            if (obj_foto != null)
                try
                {
                    bsClifor.Clear();
                    pImagens.Image = null;
                    if (bsClifor.Current == null)
                        bsClifor.AddNew();
                    (bsClifor.Current as TRegistro_CadClifor).Img = (byte[])obj_foto;
                    bsClifor.ResetCurrentItem();
                }
                catch { }
        }

        private void bb_cadEndereco_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_clifor.Text)))
            {
                using (Financeiro.Cadastros.TFEndereco fEndereco = new Financeiro.Cadastros.TFEndereco())
                {
                    if (!string.IsNullOrEmpty(Cd_endereco.Text))
                        fEndereco.rEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                                                   Cd_endereco.Text,
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
                                                                                                   null)[0];
                    if (fEndereco.ShowDialog() == DialogResult.OK)
                        if (fEndereco.rEnd != null)
                            try
                            {
                                fEndereco.rEnd.Cd_clifor = (bsLocacao.Current as TRegistro_Locacao).Cd_clifor;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(fEndereco.rEnd, null);
                                MessageBox.Show("Endereço cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cd_endereco.Text = fEndereco.rEnd.Cd_endereco;
                                Cep.Text = fEndereco.rEnd.Cep;
                                Ds_endereco.Text = fEndereco.rEnd.Ds_endereco;
                                Ds_end.Text = fEndereco.rEnd.Ds_endereco;
                                Numero.Text = fEndereco.rEnd.Numero;
                                Bairro.Text = fEndereco.rEnd.Bairro;
                                DS_Complemento.Text = fEndereco.rEnd.Ds_complemento;
                                Proximo.Text = fEndereco.rEnd.Proximo;

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void Cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                           "a.cd_endereco|=|'" + Cd_endereco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_endereco, Ds_endereco },
                                            new TCD_CadEndereco());
            BuscarEndereco();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_endereco, Ds_endereco },
                                            new TCD_CadEndereco(),
                                            vParam);
            BuscarEndereco();
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new TCD_CadClifor());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new TCD_CadClifor(),
               vParam);
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
            {
                cbxStatusProd.SelectedIndex = 0;
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void cd_grupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarGrupo();
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            //string vColunas = "a.CD_Grupo|=|'" + cd_grupo.Text + "';" +
            //                 "a.TP_Grupo|=|'A'";
            //UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_grupo },
            //                        new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
            //BuscarItens();
            //cd_grupo.Clear();
        }

        private void Produto_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            DisponibilidadeProduto(date);
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (bsProdutoLoc.Current != null)
                DisponibilidadeProduto(date);
        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (bsProdutoLoc.Current != null)
                DisponibilidadeProduto(date);
        }

        private void bb_anterior_Click(object sendeor, EventArgs e)
        {
            month = month - 1;
            if (month.Equals(0))
            {
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text) - 1, 12, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                cbxAno.Text = (int.Parse(cbxAno.Text) - 1).ToString();
            }
            else
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text), month, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            //BuscarMes();
            //DateTime date;
            //date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            //if (bsProdutoLoc.Current != null)
            //    DisponibilidadeProduto(date);       
        }

        private void bb_proximo_Click(object sender, EventArgs e)
        {
            month = month + 1;
            if (month.Equals(13))
            {
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text) + 1, 01, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                cbxAno.Text = (int.Parse(cbxAno.Text) + 1).ToString();
            }
            else
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text), month, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            //BuscarMes();
            //DateTime date;
            //date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            //if (bsProdutoLoc.Current != null)
            //    DisponibilidadeProduto(date);
        }

        private void bb_Click(object sender, EventArgs e)
        {
            #region Dia selecionado
            if (dt_locacao.Enabled == true)
            {
                MessageBox.Show("Confirme a nova Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string dt_btn =
                (((Button)sender).Text.Length == 1 ? "0" + ((Button)sender).Text : ((Button)sender).Text) + "/" +
                                    (month < 10 ? ("0" + month).ToString() : month.ToString()) + "/" + cbxAno.Text;
            #endregion
            #region Verificações
            //Verificar se existe dia no botao selecionado
            if (string.IsNullOrEmpty((((Button)sender).Text.SoNumero())))
                return;
            //Verificar se locacao ja esta selecionada e não possui itens inserir
            if (bsItens.Count == 0 &&
                !string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr.SoNumero()) &&
                ((Button)sender).BackColor.Equals(Color.White))
            {
                MessageBox.Show("Dt.Locação já está informada, Por favor selecione um produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bsItens.Count == 0 &&
                bsProdutoLoc.Count == 0 &&
                !string.IsNullOrEmpty((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr.SoNumero()) &&
                ((Button)sender).BackColor.Equals(Color.Gray))
            {
                //Desmarcar Dt.Locação
                dt_locacao.Text = string.Empty;
                dt_loc.Text = string.Empty;
                (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = string.Empty;
                ((Button)sender).BackColor = Color.White;
                return;
            }
            #endregion
            #region Selecionar Dt.Locação
            if (((Button)sender).BackColor.Equals(Color.White))
            {
                //Verificar se dt.locação é inferior a dt.atual
                //if (Convert.ToDateTime(Convert.ToDateTime(dt_btn).ToString("dd/MM/yyyy")) < Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy")))
                //{
                //    MessageBox.Show("Dt.Locação não pode ser menor que data atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //Marcar Dt.Inicio Locacao
                (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = dt_btn;
                ((Button)sender).BackColor = Color.Gray;
                bsLocacao.ResetCurrentItem();

                //Inserir Início Hora da Locação
                using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
                {
                    fQtde.Ds_label = "Hora da Locação";
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(fQtde.pHoras.SoNumero()))
                        {
                            string data = dt_locacao.Text.SoNumero();
                            dt_locacao.Text = data += fQtde.pHoras;
                            dt_loc.Text = dt_locacao.Text;
                            ds_informe.Text = "DT.LOCAÇÃO: ";
                            dt_loc.Visible = true;
                            //Verificar se dt.locação é inferior a data e hora atual
                            //if (Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr) <= CamadaDados.UtilData.Data_Servidor())
                            //{
                            //    MessageBox.Show("Dt.Locação não pode ser menor que data e hora atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    ((Button)sender).BackColor = Color.White;
                            //    dt_locacao.Text = string.Empty;
                            //    return;
                            //}
                            if (!dt_locacao.SoNumero().Length.Equals(12))
                            {
                                MessageBox.Show("Obrigatório informar Horário da Locação corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ((Button)sender).BackColor = Color.White;
                                dt_locacao.Text = string.Empty;
                                dt_loc.Text = string.Empty;
                                (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = string.Empty;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Horário da Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ((Button)sender).BackColor = Color.White;
                            dt_locacao.Text = string.Empty;
                            dt_loc.Text = string.Empty;
                            (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = string.Empty;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Horário da Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((Button)sender).BackColor = Color.White;
                        dt_locacao.Text = string.Empty;
                        dt_loc.Text = string.Empty;
                        (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = string.Empty;
                        return;
                    }
                }
                return;
            }

            #endregion
            #region Dia Indisponivel
            //Bloquear se produto estiver em Manutenção
            if (bsProdutoLoc.Current != null)
                if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).StatusProduto.Trim().ToUpper().Equals("M"))
                {
                    MessageBox.Show("Produto se encontra em Manutenção!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            if (((Button)sender).BackColor.Equals(Color.Red))
            {
                TList_ItensLocacao lDia = new TList_ItensLocacao();
                lItensLocacao.Where(p => DateTime.Parse(dt_btn) >= p.Dt_locacao &&
                                        DateTime.Parse(dt_btn) <= (string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev >= DateTime.Now ?
                                                                   p.Dt_prevdev : string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev <= DateTime.Now ?
                                                                   DateTime.Now : p.Dt_devolucao)).ToList().ForEach(p =>
                                                                  lDia.Add(p));
                if (lDia.Count > 0)
                {
                    for (int i = 0; i < lDia.Count; i++)
                    {
                        MessageBox.Show("Item Nº" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto + "\r\nnão está disponivel no dia  " + dt_btn + "\r\n\r\n" +
                             "LOCADO para " + lDia[i].Cd_clifor.Trim() + "-" + lDia[i].Nm_clifor + "\r\n" +
                             "Dt.Locação: " + lDia[i].Dt_locacaostr + "\r\n" +
                             (string.IsNullOrEmpty(lDia[i].Dt_devolucaostr) && lDia[i].Dt_prevdev >= DateTime.Now ? "Dt.Prev.Devolução: " + lDia[i].Dt_prevdevstr :
                             string.IsNullOrEmpty(lDia[i].Dt_devolucaostr) && lDia[i].Dt_prevdev <= DateTime.Now ? "Produto com Dt.Prev.Devolução " + lDia[i].Dt_prevdevstr + " está indisponível porque a devolução está expirada!" :
                             "Dt.Devolução: " + lDia[i].Dt_devolucaostr),
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return;
            }
            if (((Button)sender).BackColor.Equals(Color.Blue))
            {
                CamadaDados.Servicos.TList_LanServico lDia = new CamadaDados.Servicos.TList_LanServico();
                lOS.Where(p => Convert.ToDateTime(DateTime.Parse(dt_btn).ToString("dd/MM/yyyy 23:59:59")) >= p.Dt_abertura &&
                                        Convert.ToDateTime(DateTime.Parse(dt_btn).ToString("dd/MM/yyyy 00:00:00")) <= (string.IsNullOrEmpty(p.Dt_finalizadastr) && string.IsNullOrEmpty(p.Dt_previsaostr) ?
                                                              DateTime.Now : string.IsNullOrEmpty(p.Dt_finalizadastr) && p.Dt_previsao <= DateTime.Now ?
                                                              DateTime.Now : string.IsNullOrEmpty(p.Dt_finalizadastr) && p.Dt_previsao >= DateTime.Now ?
                                                              p.Dt_previsao : p.Dt_finalizada)).ToList().ForEach(p =>
                                                              lDia.Add(p));

                if (lDia.Count > 0)
                {
                    for (int i = 0; i < lDia.Count; i++)
                    {
                        MessageBox.Show("Item Nº" +
                           (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                           (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto + " está em MANUTENÇÃO!\r\n" +
                            "Dt.abertura: " + lDia[i].Dt_abertura + "\r\n" +
                             (string.IsNullOrEmpty(lDia[i].Dt_devolucaostr) && lDia[i].Dt_previsao >= DateTime.Now ? "Dt.Prev.Finalização: " + lDia[i].Dt_previsaostr :
                             string.IsNullOrEmpty(lDia[i].Dt_devolucaostr) && lDia[i].Dt_previsao <= DateTime.Now ? "Produto com Dt.Prev.Finalização " + lDia[i].Dt_previsaostr + " está indisponível porque a Finalização está expirada!" :
                             "Dt.Final: " + lDia[i].Dt_finalizadastr),
                                       "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return;
            }
            #endregion
            #region Inserir Dt.Prev em dias com disponibilidades parciais.
            if (((Button)sender).BackColor.Equals(Color.Yellow))
            {
                //Verificar se item esta indisponivel no periodo de locacao -MANUTENÇÃO 
                CamadaDados.Servicos.TList_LanServico lEvol =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "convert(datetime,floor(convert(decimal(30,10),a.DT_Abertura)))",
                        vOperador = "=",
                        vVL_Busca = "'" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                     "isnull(convert(datetime,floor(convert(decimal(30,10),a.DT_Finalizada))), " +
                                     "case when a.dt_previsao < GETDATE() then GETDATE() ELSE convert(datetime,floor(convert(decimal(30,10),a.DT_Previsao))) end) " +
                                     " = '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.CD_ProdutoOS",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.ST_OS, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'CA'"
                    }
                }, 0, string.Empty, string.Empty);
                //Verificar locacao
                TList_ItensLocacao lItens =
                new TCD_ItensLocacao().Select(
                     new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "convert(datetime,floor(convert(decimal(30,10), isnull(a.dt_troca, loc.dt_locacao))))",
                                vOperador = "=",
                                vVL_Busca = "'" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd") + "' or " +
                                            "convert(datetime,floor(convert(decimal(30,10),a.DT_PrevDev))) = '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd") + "' or " +
                                            "convert(datetime,floor(convert(decimal(30,10),a.DT_Devolucao))) = '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(loc.st_registro, '0')",
                                vOperador = "<>",
                                vVL_Busca = "'8'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                            }
                        }, 0, string.Empty, false);
                if (lItens.Count > 0 || lEvol.Count > 0)
                {
                    string msg = string.Empty;
                    for (int i = 0; i < lItens.Count; i++)
                    {
                        msg += "Item Nº" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto + "\r\n" +
                             "LOCADO para " + lItens[i].Cd_clifor.Trim() + "-" + lItens[i].Nm_clifor + "\r\n" +
                             "Dt.Locação: " + lItens[i].Dt_locacaostr + "\r\n" +
                             (string.IsNullOrEmpty(lItens[i].Dt_devolucaostr) && lItens[i].Dt_prevdev >= DateTime.Now ? "Dt.Prev.Devolução: " + lItens[i].Dt_prevdevstr :
                             string.IsNullOrEmpty(lItens[i].Dt_devolucaostr) && lItens[i].Dt_prevdev <= DateTime.Now ? "Produto com Dt.Prev.Devolução " + lItens[i].Dt_prevdevstr + " está indisponível porque a devolução está expirada!" :
                             "Dt.Devolução: " + lItens[i].Dt_devolucaostr) + "\r\n\r\n";
                    }
                    for (int i = 0; i < lEvol.Count; i++)
                    {
                        msg += "Item Nº" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto + " em MANUTENÇÃO\r\n" +
                             "Dt.Inicio: " + lEvol[i].Dt_aberturastr + "\r\n" +
                             (string.IsNullOrEmpty(lEvol[i].Dt_finalizadastr) && lEvol[i].Dt_previsao >= DateTime.Now ? "Dt.Prev.Termino: " + lEvol[i].Dt_previsao :
                             string.IsNullOrEmpty(lEvol[i].Dt_finalizadastr) && lEvol[i].Dt_previsao <= DateTime.Now ? "Produto com Dt.Final Manutenção " + lEvol[i].Dt_previsao + " está indisponível porque a devolução está expirada!" :
                             "Dt.Final: " + lEvol[i].Dt_finalizada) + "\r\n\r\n";
                    }
                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Inserir Hora da Devolução
                    using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
                    {
                        fQtde.Ds_label = "Hora da Devolução";
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (!string.IsNullOrEmpty(fQtde.pHoras.SoNumero()))
                            {
                                if (!fQtde.pHoras.SoNumero().Length.Equals(4))
                                {
                                    MessageBox.Show("Obrigatório informar Horário da Prev.Devolução corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                string data = Convert.ToDateTime(dt_btn).ToString("dd/MM/yyyy ");
                                string dt = Convert.ToDateTime(data += fQtde.pHoras).ToString("dd/MM/yyyy HH:mm:ss");
                                dt_btn = Convert.ToDateTime(dt).ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            #endregion
            #region  Verificar se item esta indisponivel no periodo de locacao
            if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(1) ||
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(0))
            {
                if (new TCD_ItensLocacao().BuscarEscalar(
                     new TpBusca[]
                     {
                        new TpBusca()
                        {
                            vNM_Campo = "loc.dt_locacao",
                            vOperador = ">=",
                            vVL_Busca = "'" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                        "ISNULL(a.DT_Devolucao, a.DT_PrevDev) >= '" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "loc.dt_locacao",
                            vOperador = "<=",
                            vVL_Busca = "'" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                        "ISNULL(a.DT_Devolucao, a.DT_PrevDev) <= '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(loc.st_registro, '0')",
                            vOperador = "<>",
                            vVL_Busca = "'8'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.dt_devolucao",
                            vOperador = "is",
                            vVL_Busca = "null"
                        }

                     }, "1") != null)
                {
                    MessageBox.Show("Item com Nº" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto +
                            " não está disponivel no periodo informado!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Verificar se item esta indisponivel no periodo de locacao -MANUTENÇÃO 
                if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                     new TpBusca[]
                {
                    //new TpBusca()
                    //{
                    //     vNM_Campo = "a.DT_Abertura",
                    //    vOperador = ">=",
                    //    vVL_Busca = "'" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                    //                 "ISNULL(a.dt_finalizada, case when a.dt_previsao < GETDATE() then GETDATE() ELSE a.dt_previsao end) " +
                    //                 " >= '" + Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "'"
                    //},
                    //new TpBusca()
                    //{
                    //    vNM_Campo = "a.DT_Abertura",
                    //    vOperador = "<=",
                    //    vVL_Busca = "'" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                    //                 "ISNULL(a.dt_finalizada, case when a.dt_previsao < GETDATE() then GETDATE() ELSE a.dt_previsao end) " +
                    //                 " <= '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "'"
                    //},
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.ST_OS, 'AB')",
                        vOperador = "=",
                        vVL_Busca = "'AB'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produtoOS",
                        vOperador = "=",
                        vVL_Busca = "'" + (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto.Trim() + "'"
                    }
                }, "1") != null)
                {
                    MessageBox.Show("Item com Nº" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto +
                            " não está disponivel por motivo de MANUTENÇÃO, será necessário finalizar a ordem de serviço com status ABERTO!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion
            #region Inserir Item ou Excluir Item
            //Selecionar Dt.Prev.Devolucao de dia disponivel ou parcial
            if (((Button)sender).BackColor.Equals(Color.GreenYellow) ||
                ((Button)sender).BackColor.Equals(Color.Yellow))
            {
                //Criar Item locacao
                InserirItem(sender, dt_btn, false);
                return;
            }
            //Desmarcar Datas Dt.Prev.Devolucao e Excluir Item
            if (((Button)sender).BackColor.Equals(Color.Gray))
            {
                //Inserir Locacao em Horas no mesmo dia.
                if (Convert.ToDateTime(dt_btn).ToString("dd/MM/yyyy") == Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy"))
                {
                    //Criar Item locacao
                    InserirItem(sender, dt_btn, true);
                    return;
                }
                if (bsItens.Current != null)
                {
                    //Excluir Item 
                    string dia = ((Button)sender).Text;
                    if (!string.IsNullOrEmpty((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr.SoNumero()))
                        if (dia.Equals(Convert.ToDateTime((bsItens.Current as TRegistro_ItensLocacao).Dt_prevdevstr).Day.ToString()))
                        {
                            if (bsItens.Current != null)
                                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    (bsLocacao.Current as TRegistro_Locacao).lItensDel.Add(
                                        bsItens.Current as TRegistro_ItensLocacao);
                                    bsItens.RemoveCurrent();
                                    //Desabilitar se já existir itens.
                                    cbEmpresa.Enabled = bsItens.Count.Equals(0);
                                    lbAlterarDtLocacao.Visible = bsItens.Count.Equals(0);
                                    bsProdutoLoc_PositionChanged(this, new EventArgs());
                                }
                        }
                    return;
                }
            }
            #endregion
        }

        private void bsProdutoLoc_PositionChanged(object sender, EventArgs e)
        {
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            DisponibilidadeProduto(date);
            if (bsProdutoLoc.Current != null)
            {
                //Buscar Imagens
                (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).lImagens =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto_Imagens.Buscar(0,
                                                                                  (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto);
                bsProdutoLoc.ResetCurrentItem();
            }
            //Selecionar Aba Detalhes
            tcItens.SelectTab(tpDetalhes);


        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
                BuscarTabelaPreco((bsItens.Current as TRegistro_ItensLocacao).Cd_produto);
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void TFLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                bb_consultaProduto_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F3) && dt_locacao.Enabled == false)
                lbAlterarDtLocacao_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.Enter) && dt_locacao.Enabled == true)
                lbAlterarDtLocacao_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                Cancelar();
            else if (e.KeyCode.Equals(Keys.F10))
                BuscarGrupo();
            else if (e.KeyCode.Equals(Keys.F12))
            {
                BuscarItens();
                cd_produto.Clear();
            }
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cep_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Cep.Text.SoNumero())))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(Cep.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            Ds_end.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            CD_Cidade.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            Bairro.Text = valida.bairro;
                        CD_Cidade_Leave(this, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void CD_Cidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_Cidade.Text + "'",
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade());
        }

        private void BB_Cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade(), string.Empty);
        }

        private void vl_despesas_Leave(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                if (vl_despesas.Value > decimal.Zero)
                {
                    CamadaNegocio.Locacao.TCN_Locacao.RatearFrete(bsLocacao.Current as TRegistro_Locacao, vl_despesas.Value);
                    bsLocacao.ResetBindings(true);
                }
            }
            else
            {
                MessageBox.Show("Obrigatório informar itens para gerar despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_despesas.Value = decimal.Zero;
            }
        }

        private void bb_novoEnd_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_clifor.Text)))
            {
                using (Financeiro.Cadastros.TFEndereco fEndereco = new Financeiro.Cadastros.TFEndereco())
                {
                    fEndereco.Tp_pessoa = string.Empty;
                    if (!string.IsNullOrEmpty(Ds_end.Text))
                    {
                        TRegistro_CadEndereco rEnd =
                        new TRegistro_CadEndereco();
                        rEnd.Cep = Cep.Text;
                        rEnd.Ds_endereco = Ds_end.Text;
                        rEnd.Numero = Numero.Text;
                        rEnd.Bairro = Bairro.Text;
                        rEnd.Ds_complemento = DS_Complemento.Text;
                        rEnd.Cd_cidade = CD_Cidade.Text;
                        rEnd.DS_Cidade = Ds_Cidade.Text;
                        rEnd.UF = UF.Text;
                        rEnd.Proximo = Proximo.Text;
                        fEndereco.rEnd = rEnd;
                    }
                    if (fEndereco.ShowDialog() == DialogResult.OK)
                        if (fEndereco.rEnd != null)
                            try
                            {
                                fEndereco.rEnd.Cd_clifor = cd_clifor.Text;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(fEndereco.rEnd, null);
                                MessageBox.Show("Endereço cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cep.Text = fEndereco.rEnd.Cep;
                                Ds_end.Text = fEndereco.rEnd.Ds_endereco;
                                Numero.Text = fEndereco.rEnd.Numero;
                                Bairro.Text = fEndereco.rEnd.Bairro;
                                DS_Complemento.Text = fEndereco.rEnd.Ds_complemento;
                                CD_Cidade.Text = fEndereco.rEnd.Cd_cidade;
                                Ds_Cidade.Text = fEndereco.rEnd.DS_Cidade;
                                UF.Text = fEndereco.rEnd.UF;
                                Proximo.Text = fEndereco.rEnd.Proximo;
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Equals(tpEndereco))
                if (string.IsNullOrEmpty(Ds_end.Text))
                    cd_clifor_Leave(this, new EventArgs());
        }

        private void bb_trocarEndEnntrega_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Ds_end },
                                             new TCD_CadEndereco(),
                                             vParam);
            if (linha != null)
                BuscarEndEntrega(linha["cd_endereco"].ToString());
        }

        private void bbPessoasAut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente para selecionar pessoa autorizada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            using (Faturamento.TFListPessoasAut fLista = new Faturamento.TFListPessoasAut())
            {
                fLista.pCd_clifor = cd_clifor.Text;
                fLista.pNm_clifor = nm_clifor.Text;
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rPessoa != null)
                    {
                        id_pessoa.Text = fLista.rPessoa.Id_pessoastr;
                        nm_pessoa.Text = fLista.rPessoa.Nm_pessoa;
                        BuscarCondPagto();
                    }
            }
        }

        private void id_pessoa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                                "a.id_pessoa|=|" + id_pessoa.Text + ";" +
                                "isnull(a.dt_autorizacao, GETDATE())|>=| '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd HH:mm:ss") + "'";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_pessoa, nm_pessoa },
                    new TCD_PessoasAutorizadas());
            }
        }

        private void bb_autorizada_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                string vColunas = "a.nm_pessoa|Nome|200;" +
                                  "a.id_pessoa|Código|80";
                string vParam = "a.cd_clifor|=|" + cd_clifor.Text.Trim() + ";" +
                                "isnull(a.dt_autorizacao, GETDATE())|>=| '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd HH:mm:ss") + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_pessoa, nm_pessoa },
                    new TCD_PessoasAutorizadas(),
                   vParam);
            }
        }

        private void bb_desconto_unit_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                using (PDV.TFDesconto fDesc = new PDV.TFDesconto())
                {
                    decimal vl_total =
                        (bsItens.Current as TRegistro_ItensLocacao).Vl_unitario *
                        (bsItens.Current as TRegistro_ItensLocacao).QTDItem;
                    fDesc.Vl_venda = vl_total;
                    if (fDesc.ShowDialog() == DialogResult.OK)
                    {
                        //decimal vl_desconto = decimal.Zero;
                        decimal pc_desconto = decimal.Zero;
                        if (fDesc.St_valor)
                        {
                            (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = fDesc.Desconto;
                            pc_desconto = Math.Round(fDesc.Desconto * (100 / vl_total), 2);
                        }
                        else
                        {
                            pc_desconto = fDesc.Desconto;
                            (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = vl_total * (fDesc.Desconto / 100);
                        }
                        bsItens.ResetCurrentItem();
                        if ((bsItens.Current as TRegistro_ItensLocacao).Vl_desconto > decimal.Zero)
                        {
                            //Buscar lista de descontos configuradas para o vendedor
                            CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc =
                                CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(cd_vendedor.Text,
                                                                                                cbEmpresa.SelectedValue.ToString(),
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                               null);
                            if ((bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc.Equals(0) ||
                                    ((bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc < pc_desconto))
                                if (lDesc.Count > 0)
                                {
                                    //Desconto por grupo de produto
                                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_grupo.Trim())))
                                    {
                                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals((bsItens.Current as TRegistro_ItensLocacao).Cd_grupo.Trim())).Pc_max_desconto;
                                        if (pc_desconto > pc_max_desc)
                                        {
                                            MessageBox.Show("O grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                            {
                                                fLogin.Cd_grupo = (bsItens.Current as TRegistro_ItensLocacao).Cd_grupo;
                                                fLogin.Cd_empresa = cbEmpresa.SelectedValue.ToString();
                                                fLogin.Pc_desc = pc_desconto;
                                                if (fLogin.ShowDialog() != DialogResult.OK)
                                                {
                                                    (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = decimal.Zero;
                                                    bsItens.ResetCurrentItem();
                                                    return;
                                                }
                                                else
                                                {
                                                    (bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                                    TotalizarVenda();
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            TotalizarVenda();
                                            return;
                                        }
                                    }
                                    //Desconto por vendedor e empresa
                                    if (pc_desconto > lDesc[0].Pc_max_desconto)
                                    {
                                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                        {
                                            fLogin.Cd_empresa = cbEmpresa.SelectedValue.ToString();
                                            fLogin.Pc_desc = pc_desconto;
                                            if (fLogin.ShowDialog() != DialogResult.OK)
                                            {
                                                (bsItens.Current as TRegistro_ItensLocacao).Vl_desconto = decimal.Zero;
                                                bsItens.ResetCurrentItem();
                                                return;
                                            }
                                            else
                                            {
                                                (bsItens.Current as TRegistro_ItensLocacao).Pc_AutorizadoDesc = fLogin.Pc_desc;
                                                TotalizarVenda();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TotalizarVenda();
                                        return;
                                    }
                                }
                        }
                    }
                }
            }
        }

        private void tot_desconto_Leave(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null && bsItens.Count > 0)
            {
                if (decimal.Parse(tot_desconto.Text) < (bsLocacao.Current as TRegistro_Locacao).lItens.Sum(p => p.Vl_unitario))
                {
                    if (VerificarTotDesconto(bsLocacao.Current as TRegistro_Locacao, false))
                    {
                        CamadaNegocio.Locacao.TCN_Locacao.RatearDescontoLocacao(bsLocacao.Current as TRegistro_Locacao, decimal.Parse(tot_desconto.Text), decimal.Zero);
                        bsLocacao.ResetBindings(true);
                        TotalizarVenda();
                    }
                    else
                    {
                        tot_desconto.Text = "0,00";
                        tot_pcdesconto.Text = "0,00";
                        tot_desconto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Valor de desconto maior que o valor da locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tot_desconto.Text = "0,00";
                    tot_pcdesconto.Text = "0,00";
                    tot_desconto.Focus();
                }
            }
        }

        private void tot_pcdesconto_Leave(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null && bsItens.Count > 0)
            {
                if (decimal.Parse(tot_pcdesconto.Text) < 100)
                {
                    if (VerificarTotDesconto(bsLocacao.Current as TRegistro_Locacao, true))
                    {
                        CamadaNegocio.Locacao.TCN_Locacao.RatearDescontoLocacao(bsLocacao.Current as TRegistro_Locacao, decimal.Zero, decimal.Parse(tot_pcdesconto.Text));
                        bsLocacao.ResetBindings(true);
                        TotalizarVenda();
                    }
                    else
                    {
                        tot_desconto.Text = "0,00";
                        tot_pcdesconto.Text = "0,00";
                        tot_pcdesconto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Valor de desconto maior que o valor da locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tot_desconto.Text = "0,00";
                    tot_pcdesconto.Text = "0,00";
                    tot_pcdesconto.Focus();
                }
            }
        }

        private void gProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).StatusProduto.ToUpper().Trim().Equals("M") &&
                        ((bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(0) ||
                        (bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(1)))
                        gProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (((bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).StatusProduto.ToUpper().Trim().Equals("L") ||
                              (bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).StatusProduto.ToUpper().Trim().Equals("C")) &&
                            ((bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(0) ||
                            (bsProdutoLoc[e.RowIndex] as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Quantidade.Equals(1)))
                        gProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        private void cbxStatusProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
            {
                if (string.IsNullOrEmpty(cbEmpresa.SelectedValue.ToString()))
                    return;
                if (string.IsNullOrEmpty(dt_locacao.Text.SoNumero()))
                    return;
                if (bsProdutoLoc.Current != null)
                {
                    //Buscar produto
                    bsProdutoLoc.DataSource =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao(cd_produto.Text,
                                                                                            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_grupo,
                                                                                            cbEmpresa.SelectedValue.ToString(),
                                                                                            true,
                                                                                            Convert.ToDateTime((bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss"),
                                                                                            null).FindAll(p => cbxStatusProd.SelectedIndex.Equals(1) ?
                                                                                                              p.StatusProduto.Equals("D") :
                                                                                                              cbxStatusProd.SelectedIndex.Equals(2) ?
                                                                                                              p.StatusProduto.Equals("M") :
                                                                                                              cbxStatusProd.SelectedIndex.Equals(3) ?
                                                                                                              (p.StatusProduto.Equals("L") || p.StatusProduto.Equals("C")) :
                                                                                                              p.StatusProduto.Equals(p.StatusProduto));
                    bsProdutoLoc_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void cbCondPgto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCondPgto.SelectedValue != null)
            {
                if ((cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas > 0)
                {
                    //Buscar Portadores
                    TList_CadPortador lPortador = new TList_CadPortador() { new TRegistro_CadPortador() };
                    new TCD_CadPortador().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.TP_PortadorPDV",
                                                        vOperador = "=",
                                                        vVL_Busca = "'P'"
                                                    }
                                                }, 0, string.Empty, string.Empty).ForEach(p => lPortador.Add(p));
                    cbPortador.DataSource = lPortador;
                    if ((cbCondPgto.SelectedItem as TRegistro_CadCondPgto).Qt_parcelas > 0)
                        cbPortador.SelectedIndex = 1;
                    cbPortador.Enabled = true;
                    bsLocacao.ResetCurrentItem();
                }
                else
                {
                    cbPortador.SelectedIndex = 0;
                    cbPortador.SelectedValue = string.Empty;
                    cbPortador.Text = string.Empty;
                    cbPortador.Enabled = false;
                }
            }
        }

        private void lbAlterarDtLocacao_Click(object sender, EventArgs e)
        {
            if (bsItens.Count.Equals(0))
            {
                if (dt_locacao.Enabled == false)
                {
                    dt_locacao.Enabled = true;
                    lbAlterarDtLocacao.Text = "(ENTER) CONFIRME ALTERAÇÃO";
                    dt_locacao.Focus();
                }
                else
                {
                    if (!dt_locacao.SoNumero().Length.Equals(12))
                    {
                        MessageBox.Show("Obrigatório informar Data da Locação corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_locacao.Text = string.Empty;
                        dt_loc.Text = string.Empty;
                        (bsLocacao.Current as TRegistro_Locacao).Dt_locacaostr = string.Empty;
                        return;
                    }
                    lbAlterarDtLocacao.Text = "(F3) ALTERAR DT.LOCAÇÃO";
                    ds_informe.Text = "DT.LOCAÇÃO: ";
                    dt_loc.Text = dt_locacao.Text;
                    dt_loc.Visible = true;
                    dt_locacao.Enabled = false;
                    if (bsProdutoLoc.Count > 0)
                    {
                        bsProdutoLoc.Clear();
                        BuscarGrupo();
                    }
                    else
                        BuscarMes();
                }
            }
        }

        private void bb_consultaProduto_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
                using (TFInfoPatrimonio fInfo = new TFInfoPatrimonio())
                {
                    fInfo.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                    fInfo.ShowDialog();
                }
            else
                MessageBox.Show("Obrigatório selecionar empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            new_historico();
        }

        private void new_historico()
        {
            if (bsLocacao.Current != null)
                using (TFHistorico fHist = new TFHistorico())
                {
                    if (fHist.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fHist.pDs_mensagem))
                        {
                            TRegistro_Historico rHist =
                                new TRegistro_Historico();
                            rHist.Login = Utils.Parametros.pubLogin;
                            rHist.Dt_historico = CamadaDados.UtilData.Data_Servidor();
                            rHist.Ds_historico = fHist.pDs_mensagem;
                            (bsLocacao.Current as TRegistro_Locacao).lHist.Add(rHist);
                            bsLocacao.ResetCurrentItem();
                        }
                }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (bsHistorico.Current != null)
                if (MessageBox.Show("Confirma a exclusão do histórico?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    bsHistorico.RemoveCurrent();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                bb_desconto_unit.Enabled = !(bsItens.Current as TRegistro_ItensLocacao).St_progEspecial;
                tot_desconto.Enabled = !(bsItens.Current as TRegistro_ItensLocacao).St_progEspecial;
                tot_pcdesconto.Enabled = !(bsItens.Current as TRegistro_ItensLocacao).St_progEspecial;
            }
        }

        private void tot_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
               e.KeyChar != (char)Keys.Back &&
               e.KeyChar != (char)44)
                e.Handled = true;
            else if (e.KeyChar == ',')
                if (((ToolStripTextBox)sender).Text.Contains(","))
                    e.Handled = true;
        }
    }
}
