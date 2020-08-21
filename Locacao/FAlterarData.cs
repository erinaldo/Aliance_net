using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFAlterarData : Form
    {
        public string pId_locacao
        { get; set; }
        public string pCd_produto
        { get; set; }
        public decimal pQuantidade
        { get; set; }
        public decimal pQtd_Item
        { get; set; }
        public string pNr_Patrimonio
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pDt_locacaostr
        { get; set; }
        public string pDt_prevdevstr
        { get; set; }
        private int month
        { get; set; }
        private int daysMonth
        { get; set; }
        private CamadaDados.Locacao.TList_ItensLocacao lItensLocacao
        { get; set; }
        private CamadaDados.Servicos.TList_LanServico lOS
        { get; set; }
        public TFAlterarData()
        {
            InitializeComponent();
            for (int i = 2013; i < 2050; i++)
                cbxAno.Items.Add(i);
        }

        private void LimparCampos()
        {
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
            this.PreencherMes(day);
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
                this.PositionWeek(-1);
            else if (day.ToUpper().Equals("MONDAY"))
                this.PositionWeek(0);
            else if (day.Trim().ToUpper().Equals("TUESDAY"))
                this.PositionWeek(1);
            else if (day.Trim().ToUpper().Equals("WEDNESDAY"))
                this.PositionWeek(2);
            else if (day.Trim().ToUpper().Equals("THURSDAY"))
                this.PositionWeek(3);
            else if (day.Trim().ToUpper().Equals("FRIDAY"))
                this.PositionWeek(4);
            else if (day.Trim().ToUpper().Equals("SATURDAY"))
                this.PositionWeek(5);
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
                if (!string.IsNullOrEmpty(pCd_produto))
                {
                    //this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.GreenYellow;
                    //Formar dias em que produto está em manutenção

                    //Formar Disponibilidade do Produto nos dias do Mes selecionado
                    decimal xLoc =
                    lItensLocacao.Where(p => DateTime.Parse(b) >= p.Dt_locacao &&
                                        DateTime.Parse(b) <= (string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev >= DateTime.Now ?
                                                              p.Dt_prevdev : string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev <= DateTime.Now ?
                                                              DateTime.Now : p.Dt_devolucao)).ToList().Count();

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
                    lItensLocacao.Where(p => DateTime.Parse(b).ToString("dd/MM/yyyy") == Convert.ToDateTime(p.Dt_locacao).ToString("dd/MM/yyyy") ||
                                        DateTime.Parse(b).ToString("dd/MM/yyyy") == (string.IsNullOrEmpty(p.Dt_devolucaostr) ?
                                                              Convert.ToDateTime(p.Dt_prevdev).ToString("dd/MM/yyyy") : Convert.ToDateTime(p.Dt_devolucao).ToString("dd/MM/yyyy"))).ToList().Count();


                    if (xParcial > 0 || xManut > 0)
                    {
                        if (xManut > 0)
                            this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Blue;
                        if (xParcial > 0 || xManutParcial > 0)
                            this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Yellow;
                    }
                    else if (xLoc.Equals(0))
                    {
                        //Marcar Dia da Locacao
                        //if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                        //    this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                        //else
                            this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        //Bloquear - Item selecionado nao esta disponivel na data de locação.
                        //if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                        //    (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_bloqItem = true;
                        this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Red;
                    }
                    //if (bsItens.Count > 0)
                    //{
                    //    if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists
                    //        (p => p.Cd_produto.Equals((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto)))
                    //    {
                    //        if (DateTime.Parse(b).ToString("dd/MM/yyyy") ==
                    //            DateTime.Parse((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Find(p => p.Cd_produto ==
                    //            (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto).Dt_prevdevstr).ToString("dd/MM/yyyy"))
                    //            this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                    //    }
                    //}
                }
                //else
                //{
                //    //Marcar Dia da Locacao
                //    if (!string.IsNullOrEmpty((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr.SoNumero()))
                //        if (DateTime.Parse(b).ToString("dd/MM/yyyy") == (Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy")))
                //            this.NextDay("bb" + y.ToString(), x.ToString()).BackColor = Color.Gray;
                //        else
                //            this.NextDay("bb" + y.ToString(), x.ToString());
                //    else
                //        this.NextDay("bb" + y.ToString(), x.ToString());
                //}
            }
        }

        private void DisponibilidadeProduto(DateTime data)
        {
            if (!string.IsNullOrEmpty(pCd_produto))
            {
                //Calcular ultimo dia do mes
                DateTime d = data.AddMonths(1);
                d = d.AddDays(-1);
                if (pQuantidade.Equals(1) || pQuantidade.Equals(0))
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
                                            "a.DT_Finalizada >= '" + data.ToString("yyyyMMdd") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Abertura",
                                vOperador = "<=",
                                vVL_Busca = "'" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                             "a.DT_Previsao <= '" + d.ToString("yyyyMMdd 23:59:59") + "' or " +
                                            "a.DT_Finalizada <= '" + d.ToString("yyyyMMdd 23:59:59") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_ProdutoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + pCd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.ST_OS, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'CA'"
                            }
                        }, 0, string.Empty, string.Empty);
                    //Disponibilidade Locação
                    lItensLocacao =
                        new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.dt_troca, loc.dt_locacao)",
                                vOperador = ">=",
                                vVL_Busca = "'" + data.ToString("yyyyMMdd") + "' or " +
                                            "a.DT_PrevDev >= '" + data.ToString("yyyyMMdd") + "' or " +
                                            "a.DT_Devolucao >= '" + data.ToString("yyyyMMdd") + "'"
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
                                 vVL_Busca = "'" + pCd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = !string.IsNullOrEmpty(pId_locacao) ? "<>" : "=",
                                vVL_Busca = !string.IsNullOrEmpty(pId_locacao) ? pId_locacao : "a.id_locacao"
                            }

                            
                        }, 0, string.Empty, false);
                }
                else
                {
                    lOS = new CamadaDados.Servicos.TList_LanServico();
                    lItensLocacao = new CamadaDados.Locacao.TList_ItensLocacao();
                }
            }
            // obtém a quantidade de dias MÊS e ANO selecionados
            System.Globalization.Calendar c = new System.Globalization.GregorianCalendar();
            daysMonth = c.GetDaysInMonth(int.Parse(cbxAno.SelectedItem.ToString()), month);
            //Verificar dia da semana em que se incia o MÊS selecionado
            string day = data.DayOfWeek.ToString();
            //Preencher mes
            LimparCampos();
            this.PreencherMes(day);
        }

        private void InserirItem(object sender, string dt_btn, bool ST_HORAS)
        {
            ////Verificar se produto ja esta adicionado na locação
            //if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p =>
            //    p.Cd_produto.Equals((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto)))
            //{
            //    MessageBox.Show("Produto já está selecionado na locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_bloqItem)
            //{
            //    MessageBox.Show("Item com Nº" +
            //        (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Nr_Patrimonio + "-" +
            //        (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Ds_produto +
            //        " não está disponível para a Dt.Locação " + Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy"), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (Convert.ToDateTime(dt_btn) < Convert.ToDateTime(pDt_locacaostr) && !ST_HORAS)
            {
                MessageBox.Show("Dt.Prev.Devolução não pode ser menor que a Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Marcar Dt.Prev.Devolucao Locacao
            pDt_prevdevstr = dt_btn;
            //(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem = 1;
            if (((Button)sender).BackColor.Equals(Color.GreenYellow) ||
                ((Button)sender).BackColor.Equals(Color.Yellow) ||
                ((Button)sender).BackColor.Equals(Color.Gray))
            {
                if (!((Button)sender).BackColor.Equals(Color.Yellow))
                {
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
                                    pDt_prevdevstr = string.Empty;
                                    ((Button)sender).BackColor = Color.GreenYellow;
                                    return;
                                }
                                string data = Convert.ToDateTime(pDt_prevdevstr).ToString("dd/MM/yyyy ");
                                string dt = Convert.ToDateTime(data += fQtde.pHoras).ToString("dd/MM/yyyy HH:mm");
                                pDt_prevdevstr = Convert.ToDateTime(dt).ToString("dd/MM/yyyy HH:mm");
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pDt_prevdevstr = string.Empty;
                                ((Button)sender).BackColor = Color.GreenYellow;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pDt_prevdevstr = string.Empty;
                            ((Button)sender).BackColor = Color.GreenYellow;
                            return;
                        }
                    }
                }
                if (Convert.ToDateTime(pDt_prevdevstr) <
                    Convert.ToDateTime(pDt_locacaostr) && ST_HORAS)
                {
                    MessageBox.Show("Dt.Prev.Devolução não pode ser menor que a Dt.Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Se o patrimonio possuir quantidade informar
                decimal menor = decimal.Zero;
                if (pQuantidade > 1)
                {
                    //Buscar Locações em execução no Periodo
                    CamadaDados.Locacao.TList_ItensLocacao lItens =
                    new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = ">=",
                                vVL_Busca = "'" + Convert.ToDateTime(pDt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev >= '" + Convert.ToDateTime(pDt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada >= '" + Convert.ToDateTime(pDt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = "<=",
                                vVL_Busca = "'" + Convert.ToDateTime(pDt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev <= '" + Convert.ToDateTime(pDt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada <= '" + Convert.ToDateTime(pDt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(loc.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + pCd_produto.Trim() + "'"
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
                            if (Convert.ToDateTime(pDt_prevdevstr) >= p.Dt_prevdev)
                            {
                                object obj =
                                new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
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
                                            vNM_Campo = "isnull(loc.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + pCd_produto.Trim() + "'"
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
                                {
                                    //Buscar saldo Minimo Periodo
                                    decimal qtd = pQuantidade - decimal.Parse(obj.ToString());
                                    if (menor.Equals(decimal.Zero))
                                        menor = qtd;
                                    else if (qtd < menor)
                                        menor = qtd;
                                }
                            }
                            else
                            {
                                //se no periodo não existir nenhuma dt_prev de locação calcular saldo pelo dt.prev da locação corrente
                                object obj =
                                new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "loc.dt_locacao",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + Convert.ToDateTime(pDt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'" 
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + pCd_produto.Trim() + "'"
                                        },
                                         new TpBusca()
                                        {
                                            vNM_Campo = "a.dt_prevdev",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + Convert.ToDateTime(pDt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or a.DT_PrevDev < getdate()" 
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        }
                                    }, "isnull(SUM(A.qtditem), 0) ");
                                if (obj != null)
                                {
                                    //Buscar saldo Minimo Periodo
                                    decimal qtd = pQuantidade - decimal.Parse(obj.ToString());
                                    if (menor.Equals(decimal.Zero))
                                        menor = qtd;
                                    else if (qtd < menor)
                                        menor = qtd;
                                }
                            }
                        });
                    }

                    ////Informar Quantidade
                    //using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    //{
                    //    decimal saldo = (menor.Equals(decimal.Zero) ? pQuantidade : menor);
                    //    fQtde.Ds_label = "Saldo: " + saldo;
                    //    fQtde.St_valor = true;
                    //    fQtde.Vl_default = 1;
                    //    if (fQtde.ShowDialog() == DialogResult.OK)
                    //    {
                    //        if (saldo >= fQtde.Quantidade)
                    //            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem = fQtde.Quantidade;
                    //        else
                    //        {
                    //            MessageBox.Show("Não existe saldo para esse período informado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            ((Button)sender).BackColor = Color.GreenYellow;
                    //            bsItens.RemoveCurrent();
                    //            bsProdutoLoc_PositionChanged(this, new EventArgs());
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Obrigatório informar quantidade para inserir item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        ((Button)sender).BackColor = Color.GreenYellow;
                    //        bsItens.RemoveCurrent();
                    //        bsProdutoLoc_PositionChanged(this, new EventArgs());
                    //        return;
                    //    }

                    //}
                    decimal saldo = decimal.Zero;
                    if (menor == 0)
                        saldo = pQtd_Item;
                    else
                        saldo = menor;
                    if (saldo < pQtd_Item)
                    {
                        MessageBox.Show("Não existe saldo para esse período informado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((Button)sender).BackColor = Color.GreenYellow;
                        return;
                    }
                }
                else
                {
                    //Verificar se patrimonio possui controle de horas
                    //if ((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).St_controlehorabool)
                    //{
                    //    //Informar Quantidade
                    //    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    //    {
                    //        fQtde.Ds_label = "QTD.Horas";
                    //        fQtde.Vl_default = (bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Qtd_horas;
                    //        if (fQtde.ShowDialog() == DialogResult.OK)
                    //        {
                    //            if (fQtde.Quantidade > decimal.Zero)
                    //            {
                    //                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_controlehorabool = true;
                    //                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasAtual = fQtde.Quantidade;
                    //                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasRetirada = fQtde.Quantidade;
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                ((Button)sender).BackColor = Color.GreenYellow;
                    //                bsItens.RemoveCurrent();
                    //                bsProdutoLoc_PositionChanged(this, new EventArgs());
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            ((Button)sender).BackColor = Color.GreenYellow;
                    //            bsItens.RemoveCurrent();
                    //            bsProdutoLoc_PositionChanged(this, new EventArgs());
                    //            return;
                    //        }

                    //    }
                    //}
                    //(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem = 1;
                }
            }
            ////Buscar Tabelas Preço
            //this.BuscarPrecoItem((bsProdutoLoc.Current as CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao).Cd_produto);
            //bsItens.ResetCurrentItem();
            //Marcar Botao
            ((Button)sender).BackColor = Color.Gray;
            //this.AddCarrinho();
            ////Selecionar Aba Itens
            //tcItens.SelectTab(tpItens);
        }

        private void TFAlterarData_Load(object sender, EventArgs e)
        {
            try
            {
                cbxAno.Text = DateTime.Now.Year.ToString();
            }
            catch
            {
                cbxAno.Text = DateTime.Now.Year.ToString();
                
            }
            try
            {
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            }
            catch
            {
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            }
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            this.DisponibilidadeProduto(date);
            this.BuscarMes();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (!string.IsNullOrEmpty(pCd_produto))
                this.DisponibilidadeProduto(date);
        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (!string.IsNullOrEmpty(pCd_produto))
                this.DisponibilidadeProduto(date);
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
            this.BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (!string.IsNullOrEmpty(pCd_produto))
                this.DisponibilidadeProduto(date);
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
            this.BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            if (!string.IsNullOrEmpty(pCd_produto))
                this.DisponibilidadeProduto(date);
        }

        private void bb_Click(object sender, EventArgs e)
        {
            #region Dia selecionado
            string dt_btn =
                (((Button)sender).Text.Length == 1 ? "0" + ((Button)sender).Text : ((Button)sender).Text) + "/" +
                                    (month < 10 ? ("0" + month).ToString() : month.ToString()) + "/" + cbxAno.Text;
            #endregion
            #region Verificações
            //Verificar se existe dia no botao selecionado
            if (string.IsNullOrEmpty((((Button)sender).Text.SoNumero())))
                return;
            //Verificar se locacao ja esta selecionada e não possui itens inserir
            //if (bsItens.Count == 0 &&
            //    !string.IsNullOrEmpty((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr.SoNumero()) &&
            //    ((Button)sender).BackColor.Equals(Color.White))
            //{
            //    MessageBox.Show("Dt.Locação já está informada, Por favor selecione um produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (bsItens.Count == 0 &&
            //    bsProdutoLoc.Count == 0 &&
            //    !string.IsNullOrEmpty((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr.SoNumero()) &&
            //    ((Button)sender).BackColor.Equals(Color.Gray))
            //{
            //    //Desmarcar Dt.Locação
            //    dt_locacao.Text = string.Empty;
            //    dt_loc.Text = string.Empty;
            //    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = string.Empty;
            //    ((Button)sender).BackColor = Color.White;
            //    return;
            //}
            #endregion
            #region Selecionar Dt.Locação
            //if (((Button)sender).BackColor.Equals(Color.White))
            //{
            //    //Verificar se dt.locação é inferior a dt.atual
            //    //if (Convert.ToDateTime(Convert.ToDateTime(dt_btn).ToString("dd/MM/yyyy")) < Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy")))
            //    //{
            //    //    MessageBox.Show("Dt.Locação não pode ser menor que data atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //    return;
            //    //}
            //    //Marcar Dt.Inicio Locacao
            //    //(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = dt_btn;
            //    //((Button)sender).BackColor = Color.Gray;
            //    //bsLocacao.ResetCurrentItem();
            //    //Inserir Início Hora da Locação
            //    using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
            //    {
            //        fQtde.Ds_label = "Hora da Locação";
            //        if (fQtde.ShowDialog() == DialogResult.OK)
            //        {
            //            if (!string.IsNullOrEmpty(fQtde.pHoras.SoNumero()))
            //            {
            //                string data = dt_locacao.Text.SoNumero();
            //                dt_locacao.Text = data += fQtde.pHoras;
            //                dt_loc.Text = dt_locacao.Text;
            //                ds_informe.Text = "DT.LOCAÇÃO: ";
            //                dt_loc.Visible = true;
            //                //Verificar se dt.locação é inferior a data e hora atual
            //                //if (Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr) <= CamadaDados.UtilData.Data_Servidor())
            //                //{
            //                //    MessageBox.Show("Dt.Locação não pode ser menor que data e hora atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                //    ((Button)sender).BackColor = Color.White;
            //                //    dt_locacao.Text = string.Empty;
            //                //    return;
            //                //}
            //                if (!dt_locacao.SoNumero().Length.Equals(12))
            //                {
            //                    MessageBox.Show("Obrigatório informar Horário da Locação corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    ((Button)sender).BackColor = Color.White;
            //                    dt_locacao.Text = string.Empty;
            //                    dt_loc.Text = string.Empty;
            //                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = string.Empty;
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Obrigatório informar Horário da Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                ((Button)sender).BackColor = Color.White;
            //                dt_locacao.Text = string.Empty;
            //                dt_loc.Text = string.Empty;
            //                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = string.Empty;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Obrigatório informar Horário da Locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            ((Button)sender).BackColor = Color.White;
            //            dt_locacao.Text = string.Empty;
            //            dt_loc.Text = string.Empty;
            //            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = string.Empty;
            //            return;
            //        }
            //    }
            //    return;
            //}

            #endregion
            #region Dia Indisponivel
            if (((Button)sender).BackColor.Equals(Color.Red))
            {
                CamadaDados.Locacao.TList_ItensLocacao lDia = new CamadaDados.Locacao.TList_ItensLocacao();
                lItensLocacao.Where(p => DateTime.Parse(dt_btn) >= p.Dt_locacao &&
                                        DateTime.Parse(dt_btn) <= (string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev >= DateTime.Now ?
                                                                   p.Dt_prevdev : string.IsNullOrEmpty(p.Dt_devolucaostr) && p.Dt_prevdev <= DateTime.Now ?
                                                                   DateTime.Now : p.Dt_devolucao)).ToList().ForEach(p =>
                                                                  lDia.Add(p));
                if (lDia.Count > 0)
                {
                    for (int i = 0; i < lDia.Count; i++)
                    {
                        MessageBox.Show("Item Nº" + pNr_Patrimonio + "-" + pDs_produto + "\r\nnão está disponivel no dia  " + dt_btn + "\r\n\r\n" +
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
                    MessageBox.Show("Item Nº" + pNr_Patrimonio + "-" + pDs_produto + "\r\nestá em MANUTENÇÃO!",
                                       "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                     "case when a.DT_Previsao is not null then convert(datetime,floor(convert(decimal(30,10),a.DT_Previsao))) " + 
                                     "else case when a.DT_Finalizada is not null then convert(datetime,floor(convert(decimal(30,10),a.DT_Finalizada))) else GETDATE() end end " +
                                     " = '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.CD_ProdutoOS",
                        vOperador = "=",
                        vVL_Busca = "'" + pCd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.ST_OS, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'CA'"
                    }
                }, 0, string.Empty, string.Empty);
                //Verificar locacao
                CamadaDados.Locacao.TList_ItensLocacao lItens =
                new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                     new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "convert(datetime,floor(convert(decimal(30,10),loc.dt_locacao)))",
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
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + pCd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = "<>",
                                vVL_Busca = pId_locacao
                            }
                        }, 0, string.Empty, false);
                if (lItens.Count > 0 || lEvol.Count > 0)
                {
                    string msg = string.Empty;
                    for (int i = 0; i < lItens.Count; i++)
                    {
                        msg += "Item Nº" + pNr_Patrimonio + "-" + pDs_produto + "\r\n" +
                             "Locação Nº" + lItens[i].Id_locacaostr + "\r\n" +
                             "LOCADO para " + lItens[i].Cd_clifor.Trim() + "-" + lItens[i].Nm_clifor + "\r\n" +
                             "Dt.Locação: " + lItens[i].Dt_locacaostr + "\r\n" +
                             (string.IsNullOrEmpty(lItens[i].Dt_devolucaostr) && lItens[i].Dt_prevdev >= DateTime.Now ? "Dt.Prev.Devolução: " + lItens[i].Dt_prevdevstr :
                             string.IsNullOrEmpty(lItens[i].Dt_devolucaostr) && lItens[i].Dt_prevdev <= DateTime.Now ? "Produto com Dt.Prev.Devolução " + lItens[i].Dt_prevdevstr + " está indisponível porque a devolução está expirada!" :
                             "Dt.Devolução: " + lItens[i].Dt_devolucaostr) + "\r\n\r\n";
                    }
                    for (int i = 0; i < lEvol.Count; i++)
                    {
                        msg += "Item Nº" + pNr_Patrimonio + "-" + pDs_produto + " em MANUTENÇÃO\r\n" +
                             "Dt.Inicio: " + lEvol[i].Dt_aberturastr + "\r\n" +
                             (string.IsNullOrEmpty(lEvol[i].Dt_finalizadastr) && lEvol[i].Dt_previsao >= DateTime.Now ? "Dt.Prev.Termino: " + lEvol[i].Dt_previsao :
                             string.IsNullOrEmpty(lEvol[i].Dt_finalizadastr) && lEvol[i].Dt_previsao <= DateTime.Now ? "Produto com Dt.Final Manutenção " + lEvol[i].Dt_previsao + " está indisponível porque a devolução está expirada!" :
                             "Dt.Final: " + lEvol[i].Dt_finalizadastr) + "\r\n\r\n";
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
                                pDt_prevdevstr = string.Empty;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar horário previsto da devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pDt_prevdevstr = string.Empty;
                            return;
                        }
                    }
                }
            }
            #endregion
            #region  Verificar se item esta indisponivel no periodo de locacao
            if (pQuantidade.Equals(1) || pQuantidade.Equals(0))
            {
                if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                     new TpBusca[]
            {
                new TpBusca()
                {
                    vNM_Campo = "loc.dt_locacao",
                    vOperador = ">=",
                    vVL_Busca = "GETDATE() or " +
                                "ISNULL(a.DT_Devolucao, a.DT_PrevDev) >= GETDATE()" 
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
                    vNM_Campo = "isnull(loc.st_registro, 'A')",
                    vOperador = "<>",
                    vVL_Busca = "'C'"
                },
                new TpBusca()
                {
                    vNM_Campo = "a.cd_produto",
                    vOperador = "=",
                    vVL_Busca = "'" + pCd_produto.Trim() + "'"
                },
                new TpBusca()
                {
                    vNM_Campo = "a.id_locacao",
                    vOperador = "<>",
                    vVL_Busca = pId_locacao
                }
            }, "1") != null)
                {
                    MessageBox.Show("Item com Nº" + pNr_Patrimonio + "-" + pDs_produto +
                            " não está disponivel no periodo informado!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pDt_prevdevstr = string.Empty;
                    return;
                }
                //Verificar se item esta indisponivel no periodo de locacao -MANUTENÇÃO 
                if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                     new TpBusca[]
                {
                    new TpBusca()
                    {
                         vNM_Campo = "a.DT_Abertura",
                        vOperador = ">=",
                        vVL_Busca = "GETDATE() or " +
                                     "ISNULL(a.dt_finalizada, case when a.dt_previsao < GETDATE() then GETDATE() ELSE a.dt_previsao end) " +
                                     " >= GETDATE()"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.DT_Abertura",
                        vOperador = "<=",
                         vVL_Busca = "'" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                     "ISNULL(a.dt_finalizada, case when a.dt_previsao < GETDATE() then GETDATE() ELSE a.dt_previsao end) " +
                                     " <= '" + Convert.ToDateTime(dt_btn).ToString("yyyyMMdd HH:mm:ss") + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.CD_ProdutoOS",
                        vOperador = "=",
                        vVL_Busca = "'" + pCd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.ST_OS, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'CA'"
                    }
                }, "1") != null)
                {
                    MessageBox.Show("Item com Nº" + pNr_Patrimonio + "-" + pDs_produto +
                            " não está disponivel no periodo informado por motivo de MANUTENÇÃO!",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pDt_prevdevstr = string.Empty;
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
                this.InserirItem(sender, dt_btn, false);
                return;
            }
            //Desmarcar Datas Dt.Prev.Devolucao e Excluir Item
            //if (((Button)sender).BackColor.Equals(Color.Gray))
            //{
            //    //Inserir Locacao em Horas no mesmo dia.
            //    if (Convert.ToDateTime(dt_btn).ToString("dd/MM/yyyy") == Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("dd/MM/yyyy"))
            //    {
            //        //Criar Item locacao
            //        this.InserirItem(sender, dt_btn, true);
            //        return;
            //    }
            //    if (bsItens.Current != null)
            //    {
            //        //Excluir Item 
            //        string dia =
            //            (((Button)sender).Text.Length == 1 ? "0" + ((Button)sender).Text : ((Button)sender).Text);
            //        if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr.SoNumero()))
            //            if (dia.Equals(Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).Day.ToString()))
            //            {
            //                if (bsItens.Current != null)
            //                    if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //                    {
            //                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItensDel.Add(
            //                            bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao);
            //                        bsItens.RemoveCurrent();
            //                        bsProdutoLoc_PositionChanged(this, new EventArgs());
            //                    }
            //            }
            //        return;
            //    }
            //}
            #endregion
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pDt_prevdevstr))
                this.DialogResult = DialogResult.OK;
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFAlterarData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                lblConfirma_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void lblConfirma_MouseEnter(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.FixedSingle;
            lblConfirma.Cursor = Cursors.Hand;
            lblConfirma.ForeColor = Color.Blue;
        }

        private void lblConfirma_MouseLeave(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.None;
            lblConfirma.Cursor = Cursors.Default;
            lblConfirma.ForeColor = Color.Black;
        }

        private void lblCancela_MouseEnter(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.FixedSingle;
            lblCancela.Cursor = Cursors.Hand;
            lblCancela.ForeColor = Color.Blue;
        }

        private void lblCancela_MouseLeave(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.None;
            lblCancela.Cursor = Cursors.Default;
            lblCancela.ForeColor = Color.Black;
        }
    }
}
