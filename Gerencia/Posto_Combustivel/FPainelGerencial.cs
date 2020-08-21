using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerencia.Posto_Combustivel
{
    public partial class TFPainelGerencial : Form
    {
        private List<CamadaDados.PostoCombustivel.TRegistro_ConvPainel> lConv;
        private CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaMes;
        public TFPainelGerencial()
        {
            InitializeComponent();
        }

        private void VendaConvenioCombustivel()
        {
            if ((combustivel.SelectedValue != null) && (lConv != null))
            {
                decimal venda_mes = lVendaMes.Where(p => p.Cd_produto.Trim().Equals(combustivel.SelectedValue.ToString())).Sum(p => p.Volumeabastecido);
                if (venda_mes > decimal.Zero)
                {
                    List<CamadaDados.PostoCombustivel.TRegistro_ConvPainel> lConvComb = lConv.FindAll(p => p.Cd_combustivel.Trim().Equals(combustivel.SelectedValue.ToString()));
                    if (cbOrderCliente.Checked)
                        bsVendaConvCombustivel.DataSource = lConvComb.GroupBy(p => p.Nm_clifor,
                            (aux, venda) =>
                                new
                                {
                                    nm_clifor = aux,
                                    VolumeAtual = venda.Sum(x => x.VolumeAtual),
                                    VolumeAnt = venda.Sum(x => x.VolumeAnt),
                                    VolumeAntt = venda.Sum(x => x.VolumeAntt),
                                    Pc_cliente = venda.Sum(x => x.VolumeAtual) * 100 / venda_mes
                                }).OrderBy(p => p.nm_clifor);
                    else
                        bsVendaConvCombustivel.DataSource = lConvComb.GroupBy(p => p.Nm_clifor,
                            (aux, venda) =>
                                new
                                {
                                    nm_clifor = aux,
                                    VolumeAtual = venda.Sum(x => x.VolumeAtual),
                                    VolumeAnt = venda.Sum(x => x.VolumeAnt),
                                    VolumeAntt = venda.Sum(x => x.VolumeAntt),
                                    Pc_cliente = venda.Sum(x => x.VolumeAtual) * 100 / venda_mes
                                }).OrderByDescending(p => p.Pc_cliente);
                    cConvVolumeAtualComb.HeaderText = "Vendas Mês " + dt_atual.Value.Month.ToString() + "(LT)";
                    cConvVolumeAntComb.HeaderText = "Vendas Mês " + dt_atual.Value.AddMonths(-1).Month.ToString() + "(LT)";
                    cConvVolumeAnttComb.HeaderText = "Vendas Mês " + dt_atual.Value.AddMonths(-2).Month.ToString() + "(LT)";
                    lblVolGeralComb.Text = "Volume Vendas Convenio Mês " + dt_atual.Value.Month.ToString() + ":";
                    lblVendaConvComb.Text = lConvComb.Sum(p => p.VolumeAtual).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
        }

        private void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpVendas))
            {
                if (tcVenda.SelectedTab.Equals(tpVendaComb))
                {
                    if (tcVendaCombustivel.SelectedTab.Equals(tpVendaCombustivel))
                    {
                        if (postoCombustivel.SelectedValue != null)
                        {
                            //Buscar Venda Dia Combustivel
                            CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaDia =
                             CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                        postoCombustivel.SelectedValue.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        dt_atual.Value.ToString("dd/MM/yyyy") + " 00:00:00",
                                                                                        dt_atual.Value.ToString("dd/MM/yyyy") + " 23:59:59",
                                                                                        "'A','E','F'",
                                                                                        "N",
                                                                                        false,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                            var vendadiacombustivel = lVendaDia.GroupBy(p => p.Ds_abreviadaProduto,
                                                                                  (aux, venda) =>
                                                                                   new
                                                                                   {
                                                                                       ds_produto = aux,
                                                                                       qtd_vendida = Math.Round(venda.Sum(x => x.Volumeabastecido), 0)
                                                                                   }).OrderBy(p => p.ds_produto).ToList();
                            //Buscar Acumulado no Mes
                            lVendaMes = CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                                   postoCombustivel.SelectedValue.ToString(),
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   new DateTime(dt_atual.Value.Year,
                                                                                                                dt_atual.Value.Month,
                                                                                                                1).ToString("dd/MM/yyyy") + " 00:00:00",
                                                                                                   dt_atual.Value.ToString("dd/MM/yyyy") + " 23:59:59",
                                                                                                   "'A','E','F'",
                                                                                                   "N",
                                                                                                   false,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   null);
                            var acumuladoMes = lVendaMes.GroupBy(p => p.Ds_abreviadaProduto,
                                                                               (aux, venda) =>
                                                                                   new
                                                                                   {
                                                                                       ds_produto = aux,
                                                                                       qtd_vendida = Math.Round(venda.Sum(x => x.Volumeabastecido), 0),
                                                                                       qtd_tend = Math.Round(venda.Sum(x => x.Volumeabastecido) / dt_atual.Value.Day *
                                                                                                    DateTime.DaysInMonth(dt_atual.Value.Year,
                                                                                                                         dt_atual.Value.Month), 0)
                                                                                   }).OrderBy(p => p.ds_produto).ToList();
                            //Buscar venda mes Anterior
                            DateTime dt_aux = new DateTime(dt_atual.Value.Year, dt_atual.Value.Month, 1).AddMonths(-1);
                            CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaAnt =
                             CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                        postoCombustivel.SelectedValue.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        dt_aux.ToString("dd/MM/yyyy") + " 00:00:00",
                                                                                        new DateTime(dt_aux.Year, dt_aux.Month, DateTime.DaysInMonth(dt_aux.Year, dt_aux.Month)).ToString("dd/MM/yyyy") + " 23:59:59",
                                                                                        "'A','E','F'",
                                                                                        "N",
                                                                                        false,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                            var vendaMesAnt = lVendaAnt.GroupBy(p => p.Ds_abreviadaProduto,
                                                                              (aux, venda) =>
                                                                               new
                                                                               {
                                                                                   ds_produto = aux,
                                                                                   qtd_vendida = Math.Round(venda.Sum(x => x.Volumeabastecido), 0)
                                                                               }).OrderBy(p => p.ds_produto).ToList();
                            //Totalizar Venda Combustivel
                            edtVendaDiaComb.Text = lVendaDia.Sum(p => p.Volumeabastecido).ToString("N0");
                            edtVendaMesComb.Text = lVendaMes.Sum(p => p.Volumeabastecido).ToString("N0");
                            edtVendaMesAntComb.Text = lVendaAnt.Sum(p => p.Volumeabastecido).ToString("N0");
                            edtPrevVendaComb.Text = (lVendaMes.Sum(x => x.Volumeabastecido) /
                                                    dt_atual.Value.Day *
                                                    DateTime.DaysInMonth(dt_atual.Value.Year, dt_atual.Value.Month)).ToString("N0");
                            // construtor do grafico
                            #region  construcao chart
                            // CONSTRUI CHART
                            chVendaCombustivel.Series.Clear();
                            if (acumuladoMes.Count > 0 || vendaMesAnt.Count > 0 || vendadiacombustivel.Count > 0)
                            {
                                chVendaCombustivel.Series.Add("sVendaDia");
                                chVendaCombustivel.Series.Add("Acumulado Mes"); 
                                chVendaCombustivel.Series.Add("Previsto Mes");
                                chVendaCombustivel.Series.Add("Vendas mes ant.");
                                //adiciona valor ao topo da barra
                                chVendaCombustivel.Series["sVendaDia"].IsValueShownAsLabel = true;
                                chVendaCombustivel.Series["Acumulado Mes"].IsValueShownAsLabel = true;
                                chVendaCombustivel.Series["Previsto Mes"].IsValueShownAsLabel = true;
                                chVendaCombustivel.Series["Vendas mes ant."].IsValueShownAsLabel = true;
                                // transforma tudo em negrito
                                chVendaCombustivel.Series["sVendaDia"].Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                                chVendaCombustivel.Series["Acumulado Mes"].Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                                chVendaCombustivel.Series["Previsto Mes"].Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                                chVendaCombustivel.Series["Vendas mes ant."].Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                                if (vendadiacombustivel.Count < acumuladoMes.Count)
                                    acumuladoMes.ForEach(x =>
                                    {
                                    if (!vendadiacombustivel.Exists(z => z.ds_produto.Trim().ToUpper().Equals(x.ds_produto.Trim().ToUpper())))
                                        vendadiacombustivel.Add(new { ds_produto = x.ds_produto, qtd_vendida = decimal.Zero });
                                    });
                                else if(acumuladoMes.Count < vendadiacombustivel.Count)
                                    vendadiacombustivel.ForEach(x =>
                                    {
                                        if (!acumuladoMes.Exists(z => z.ds_produto.Trim().ToUpper().Equals(x.ds_produto.Trim().ToUpper())))
                                            acumuladoMes.Add(new { ds_produto = x.ds_produto, qtd_vendida = decimal.Zero, qtd_tend = decimal.Zero });
                                    });

                                if (vendadiacombustivel.Count < vendaMesAnt.Count)
                                    vendaMesAnt.ForEach(x =>
                                    {
                                        if (!vendadiacombustivel.Exists(z => z.ds_produto.Trim().ToUpper().Equals(x.ds_produto.Trim().ToUpper())))
                                            vendadiacombustivel.Add(new { ds_produto = x.ds_produto, qtd_vendida = decimal.Zero });
                                    });
                                else if (vendaMesAnt.Count < vendadiacombustivel.Count)
                                    vendadiacombustivel.ForEach(x =>
                                    {
                                        if (!vendaMesAnt.Exists(z => z.ds_produto.Trim().ToUpper().Equals(x.ds_produto.Trim().ToUpper())))
                                            vendaMesAnt.Add(new { ds_produto = x.ds_produto, qtd_vendida = decimal.Zero });
                                    });

                                if (vendadiacombustivel.Count > 0)
                                {
                                    vendadiacombustivel.OrderBy(x=> x.ds_produto).ToList().ForEach(p =>
                                    {
                                        chVendaCombustivel.Series["sVendaDia"].Points.AddXY(p.ds_produto.Trim().ToUpper(), Math.Round(p.qtd_vendida, 3, MidpointRounding.AwayFromZero));
                                    });
                                }

                                if(acumuladoMes.Count > 0)
                                {
                                    acumuladoMes.OrderBy(x=> x.ds_produto).ToList().ForEach(p =>
                                    {
                                        chVendaCombustivel.Series["Acumulado Mes"].Points.AddXY(p.ds_produto.Trim().ToUpper(), Math.Round(p.qtd_vendida, 3, MidpointRounding.AwayFromZero));
                                        chVendaCombustivel.Series["Previsto Mes"].Points.AddXY(p.ds_produto.Trim().ToUpper(), Math.Round(p.qtd_tend, 3, MidpointRounding.AwayFromZero));
                                    });
                                }

                                if (vendaMesAnt.Count > 0)
                                {
                                    vendaMesAnt.OrderBy(x=> x.ds_produto).ToList().ForEach(p =>
                                    {
                                        chVendaCombustivel.Series["Vendas mes ant."].Points.AddXY(p.ds_produto.Trim().ToUpper(), Math.Round(p.qtd_vendida, 3, MidpointRounding.AwayFromZero));
                                    });
                                }
                                chVendaCombustivel.ResetAutoValues();
                            }
                            #endregion 
                        }
                    }
                    else if (tcVendaCombustivel.SelectedTab.Equals(tpVendaConv))
                    {
                        lConv = new CamadaDados.PostoCombustivel.TCD_ConvPainel().Select(postoCombustivel.SelectedValue.ToString(), dt_atual.Value);
                        if(cbOrderCliGeral.Checked)
                            bsVendaConvenioGeral.DataSource =
                                lConv.GroupBy(p => p.Nm_clifor,
                                (aux, venda) =>
                                new
                                {
                                    nm_clifor = aux,
                                    VolumeAtual = venda.Sum(x => x.VolumeAtual),
                                    VolumeAnt = venda.Sum(x => x.VolumeAnt),
                                    VolumeAntt = venda.Sum(x => x.VolumeAntt),
                                    Pc_cliente = venda.Sum(x => x.VolumeAtual) * 100 / decimal.Parse(edtVendaMesComb.Text)
                                }).OrderBy(p => p.nm_clifor);
                        else
                            bsVendaConvenioGeral.DataSource =
                                lConv.GroupBy(p => p.Nm_clifor,
                                    (aux, venda) =>
                                    new
                                    {
                                        nm_clifor = aux,
                                        VolumeAtual = venda.Sum(x => x.VolumeAtual),
                                        VolumeAnt = venda.Sum(x => x.VolumeAnt),
                                        VolumeAntt = venda.Sum(x => x.VolumeAntt),
                                        Pc_cliente = venda.Sum(x => x.VolumeAtual) * 100 / decimal.Parse(edtVendaMesComb.Text)
                                    }).OrderByDescending(p => p.VolumeAtual);
                        cConvVolumeAtual.HeaderText = "Vendas Mês " + dt_atual.Value.Month.ToString() + "(LT)";
                        cConvVolumeAnt.HeaderText = "Vendas Mês " + dt_atual.Value.AddMonths(-1).Month.ToString() + "(LT)";
                        cConvVolumeAntt.HeaderText = "Vendas Mês " + dt_atual.Value.AddMonths(-2).Month.ToString() + "(LT)";

                        lblVolGeral.Text = "Volume Vendas Convenio Mês " + dt_atual.Value.Month.ToString() + ":";
                        lblVolumeAtual.Text = lConv.Sum(p => p.VolumeAtual).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                        //Convenio por combustivel
                        this.VendaConvenioCombustivel();
                    }
                }
                else if (tcVenda.SelectedTab.Equals(tpVendaConveniencia))
                {
                    if ((lojaConv.SelectedValue != null) || (postoCombustivel.SelectedValue != null))
                    {
                        //Acumulado do Mes
                        List<CamadaDados.PostoCombustivel.TRegistro_VendaConvPainel> lAcumulado =
                            new CamadaDados.PostoCombustivel.TCD_VendaConvPainel().Select(
                                new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (lojaConv.SelectedValue != null ? lojaConv.SelectedValue.ToString() : postoCombustivel.SelectedValue.ToString()) + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.dt_emissao",
                                vOperador = "between",
                                vVL_Busca = "'" + new DateTime(dt_atual.Value.Year, dt_atual.Value.Month, 1).ToString("yyyyMMdd") + 
                                            "' and '" + dt_atual.Value.ToString("yyyyMMdd") + " 23:59:59'"
                            }
                        });
                        decimal tot_venda = lAcumulado.Sum(p => p.Vl_venda);
                        lAcumulado.ForEach(p =>
                        {
                            p.Pc_representatividade = p.Vl_venda / tot_venda;
                            p.Vl_tend = p.Vl_venda / dt_atual.Value.Day *
                                        DateTime.DaysInMonth(dt_atual.Value.Year, dt_atual.Value.Month);
                        });
                        bsAcumuladoMesConv.DataSource = lAcumulado;
                        var acumulado = lAcumulado;
                        //Buscar venda mes Anterior
                        DateTime dt_aux = new DateTime(dt_atual.Value.Year, dt_atual.Value.Month, 1).AddMonths(-1);
                        bsVendaMesAntConv.DataSource = new CamadaDados.PostoCombustivel.TCD_VendaConvPainel().Select(
                                                        new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (lojaConv.SelectedValue != null ? lojaConv.SelectedValue.ToString() : postoCombustivel.SelectedValue.ToString()) + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.dt_emissao",
                                                        vOperador = "between",
                                                        vVL_Busca = "'" + dt_aux.ToString("yyyyMMdd") + "' and '" +
                                                                    new DateTime(dt_aux.Year, dt_aux.Month, DateTime.DaysInMonth(dt_aux.Year, dt_aux.Month)).ToString("yyyyMMdd") + " 23:59:59'"
                                                    }
                                                });
                       // var vendaMesAntConv = bsVendaMesAntConv.List;
                        //Totalizar Venda Combustivel
                        edtVendaMesConv.Text = lAcumulado.Sum(p => p.Vl_venda).ToString("N0");
                        edtVendaAntConv.Text = (bsVendaMesAntConv.List as List<CamadaDados.PostoCombustivel.TRegistro_VendaConvPainel>).Sum(p => p.Vl_venda).ToString("N0");
                        edtPrevVendaConv.Text = lAcumulado.Sum(p => p.Vl_tend).ToString("N0");
                        chVendaConveniencia.Series.Clear();
                        if (acumulado.Count > 0 || (bsVendaMesAntConv.DataSource as List<CamadaDados.PostoCombustivel.TRegistro_VendaConvPainel>).Count > 0)
                        {
                            chVendaConveniencia.Series.Add("Acumulado Mes");
                            chVendaConveniencia.Series.Add("Venda Mes Ant.");
                            chVendaConveniencia.Series.Add("Previsto Mes");
                            //adiciona valor ao topo da barra
                            chVendaConveniencia.Series["Acumulado Mes"].IsValueShownAsLabel = true;
                            chVendaConveniencia.Series["Venda Mes Ant."].IsValueShownAsLabel = true;
                            chVendaConveniencia.Series["Previsto Mes"].IsValueShownAsLabel = true;
                            // transforma tudo em negrito
                            chVendaConveniencia.Series["Acumulado Mes"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                            chVendaConveniencia.Series["Venda Mes Ant."].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                            chVendaConveniencia.Series["Previsto Mes"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                            acumulado.ForEach(p =>
                            {
                                chVendaConveniencia.Series["Acumulado Mes"].Points.AddXY(p.Grupo, Math.Round( p.Vl_venda, 3, MidpointRounding.AwayFromZero));
                                //chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                                //chVendaConveniencia.Series["Previsto Mes"].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                            });
                            acumulado.ForEach(p =>
                            {
                                chVendaConveniencia.Series["Previsto Mes"].Points.AddXY(p.Grupo, Math.Round(p.Vl_tend, 3, MidpointRounding.AwayFromZero));
                                //chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                                //chVendaConveniencia.Series["Previsto Mes"].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                            });
                            (bsVendaMesAntConv.DataSource as List<CamadaDados.PostoCombustivel.TRegistro_VendaConvPainel>).ForEach(p =>
                            {
                                chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, Math.Round(p.Vl_venda, 3, MidpointRounding.AwayFromZero));
                            });
                        }
                    }
                    

                }
                else if (tcVenda.SelectedTab.Equals(tpAbastecidas))
                {
                    if (tcAbastecidas.SelectedTab.Equals(tpDia))
                    {
                        if (postoCombustivel.SelectedValue != null)
                        {
                            bsAbastecidasDia.DataSource = new CamadaDados.PostoCombustivel.TCD_AbastecidasDia().Select(
                                                            new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + postoCombustivel.SelectedValue.ToString() + "'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), a.DT_Abastecimento)))",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + dt_atual.Value.ToString("yyyyMMdd") + "'"
                                                                }
                                                            }, "HH");
                            lblQtdAbastecidaDia.Text = (bsAbastecidasDia.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Qt_abastecida).ToString();
                            lblVolAbastecidaDia.Text = (bsAbastecidasDia.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Tot_volumeabastecido).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                            chAbastecidaDia.Series.Clear();
                            chAbastecidaDia.Series.Add("1");

                            chAbastecidaDia.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                            chAbastecidaDia.Series["1"].IsValueShownAsLabel = true;
                            chAbastecidaDia.Series["1"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                            (bsAbastecidasDia.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).ForEach(p =>
                            {
                                chAbastecidaDia.Series["1"].Points.AddXY(p.Hora,p.Qt_abastecida);
                                //chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                                //chVendaConveniencia.Series["Previsto Mes"].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                            });
                        }

                    }
                    else if (tcAbastecidas.SelectedTab.Equals(tpMes))
                    {
                        bsAbastecidaMes.DataSource = new CamadaDados.PostoCombustivel.TCD_AbastecidasDia().Select(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + postoCombustivel.SelectedValue.ToString() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "month(a.dt_abastecimento)",
                                                                vOperador = "=",
                                                                vVL_Busca = dt_atual.Value.Month.ToString()
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "year(a.dt_abastecimento)",
                                                                vOperador = "=",
                                                                vVL_Busca = dt_atual.Value.Year.ToString()
                                                            }
                                                        }, "DD");
                        lblQtdeAbastMes.Text = (bsAbastecidaMes.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Qt_abastecida).ToString();
                        lblVolAbastMes.Text = (bsAbastecidaMes.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Tot_volumeabastecido).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                    }
                    else if (tcAbastecidas.SelectedTab.Equals(tpAno))
                    {
                        bsAbastecidasAno.DataSource = new CamadaDados.PostoCombustivel.TCD_AbastecidasDia().Select(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + postoCombustivel.SelectedValue.ToString() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "year(a.dt_abastecimento)",
                                                                vOperador = "=",
                                                                vVL_Busca = dt_atual.Value.Year.ToString()
                                                            }
                                                        }, "MM");
                        lblQtdeAbastAno.Text = (bsAbastecidasAno.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Qt_abastecida).ToString();
                        lblVolAbastAno.Text = (bsAbastecidasAno.List as List<CamadaDados.PostoCombustivel.TRegistro_AbastecidasDia>).Sum(p => p.Tot_volumeabastecido).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                    }
                }
                else if (tcVenda.SelectedTab.Equals(tpEstoque))
                {
                    if (postoCombustivel.SelectedValue != null)
                    {
                        List<CamadaDados.Estoque.TRegistro_SaldoEstoque> lEstoque =
                         new CamadaDados.Estoque.TCD_LanEstoque().SelectSaldoEstoque(
                                                            new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + postoCombustivel.SelectedValue.ToString() + "'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "isnull(c.st_combustivel, 'N')",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'S'"
                                                                }
                                                            });
                        //Valor Estoque
                        tot_estoque.Value = lEstoque.Sum(p => p.Tot_saldo * p.Vl_medio);

                        lEstoque.ForEach(p =>
                        {
                            DateTime dt_aux = dt_atual.Value.AddMonths(-1);
                            object obj =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "in",
                                        vVL_Busca = "('A', 'E', 'F')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_afericao, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.dt_abastecimento",
                                        vOperador = ">=",
                                        vVL_Busca = "'" + new DateTime(dt_aux.Year, dt_aux.Month, 1).ToString("yyyyMMdd") + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.dt_abastecimento",
                                        vOperador = "<=",
                                        vVL_Busca = "'" + new DateTime(dt_aux.Year, dt_aux.Month, DateTime.DaysInMonth(dt_aux.Year, dt_aux.Month)).ToString("yyyyMMdd") + " 23:59:59'"
                                    }
                                }, "ISNULL(SUM(ISNULL(VolumeAbastecido, 0)), 0)");
                            decimal tot_venda = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
                            p.Vl_medio = tot_venda / DateTime.DaysInMonth(dt_aux.Year, dt_aux.Month);
                        });
                        bsEstoqueCombustivel.DataSource = lEstoque;
                        bsTotalEstoque.DataSource = new CamadaDados.Estoque.TCD_LanEstoque().BuscarSaldo_Estoque(
                                                            new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + postoCombustivel.SelectedValue.ToString() + "'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "isnull(c.st_combustivel, 'N')",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'S'"
                                                                }
                                                            }, 0, "'Total' as label, SUM(a.Tot_Saldo), sum(a.tot_saldo * a.vl_medio)", "a.cd_empresa");
                        chEstCombustivel.Series.Clear();
                        //lEstoque
                        chEstCombustivel.Series.Add("Estoque em litros");
                        //adiciona valor ao topo da barra
                        chEstCombustivel.Series["Estoque em litros"].IsValueShownAsLabel = true;
                        // transforma tudo em negrito
                        chEstCombustivel.Series["Estoque em litros"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                        decimal total = decimal.Zero;
                        lEstoque.ForEach(p =>
                        {
                            chEstCombustivel.Series["Estoque em litros"].Points.AddXY(p.Ds_abreviadaProduto, Math.Round(p.Tot_saldo, 3, MidpointRounding.AwayFromZero));
                        total += p.Tot_saldo;
                            //chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                        });
                        chEstCombustivel.Series["Estoque em litros"].Points.AddXY("Total", total);
                        chEstCombustivel.Series["Estoque em litros"].Points[chEstCombustivel.Series["Estoque em litros"].Points.Count -1].Color = Color.DarkRed;

                    }


                }
            }
            else if (tcCentral.SelectedTab.Equals(tpFin))
            {
                if (tcFinanceiro.SelectedTab.Equals(tpReceber))
                {
                    chContaReceber.Series.Clear();
                    if (postoCombustivel.SelectedValue != null)
                    {
                        string filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        bsContasRec.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_DupPainel().Select(filtro, "R", dt_atual.Value);
                       //lEstoque
                        List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel> lcontarec = new List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>();

                        for(int i = 0; i<= (bsContasRec.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>).Count; i++)
                        {
                            if (i < 9)
                                lcontarec.Add((bsContasRec.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>)[i]);
                        }
                        //tot_contasrec.Value = (bsContasRec.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>).Sum(p => p.Valor);
                        decimal valor = decimal.Zero;
                        chContaReceber.Series.Add("Contas receber");
                        //adiciona valor ao topo da barra
                        chContaReceber.Series["Contas receber"].IsValueShownAsLabel = true;
                        // transforma tudo em negrito
                        chContaReceber.Series["Contas receber"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                        lcontarec.ForEach(p =>
                        {
                            chContaReceber.Series["Contas receber"].Points.AddXY(p.Ds_label, Math.Round( p.Valor, 3, MidpointRounding.AwayFromZero));
                            valor += p.Valor;
                            //chVendaConveniencia.Series["Venda Mes Ant."].P-oints.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                        });
                        tot_contasrec.Value = valor;


                    }


                    //if (chContasRec.Chart != null)
                    //    chContasRec.Chart.ResetDataSources();
                }
                else if (tcFinanceiro.SelectedTab.Equals(tpPagar))
                {
                    if (postoCombustivel.SelectedValue != null)
                    {
                        string filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        bsContasPag.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_DupPainel().Select(filtro, "P", dt_atual.Value);
                        List < CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel> lContas = new List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>();

                        for (int i = 0; i <= (bsContasPag.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>).Count; i++)
                        {
                            if(i < 9)
                                lContas.Add((bsContasPag.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_DupPainel>)[i]);
                        }

                        decimal valor = decimal.Zero;
                        tot_contaspag.Value = (lContas).Sum(p =>
                        p.Valor);

                        chContaPagar.Series.Clear();
                        if (lContas.Count > 0)
                        { 
                            chContaPagar.Series.Add("Contas pagar");
                            //adiciona valor ao topo da barra
                            chContaPagar.Series["Contas pagar"].IsValueShownAsLabel = true;
                            // transforma tudo em negrito
                            chContaPagar.Series["Contas pagar"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                            lContas.ForEach(p =>
                            {
                                chContaPagar.Series["Contas pagar"].Points.AddXY(p.Ds_label, Math.Round( p.Valor, 3, MidpointRounding.AwayFromZero));
                            valor += p.Valor;
                                //chVendaConveniencia.Series["Venda Mes Ant."].Points.AddXY(p.Grupo, int.Parse(vendadiacombustivel[0].qtd_vendida.ToString()));
                            });

                           


                        }
                        tot_contaspag.Value = valor;


                    }
                    //if (chContasPag.Chart != null)
                    //    chContasPag.Chart.ResetDataSources();
                }
                else if (tcFinanceiro.SelectedTab.Equals(tpDupFaturar))
                {
                    if (postoCombustivel.SelectedValue != null)
                    {
                        string filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        bsCliforAgrupar.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().SelectCliforAgrupar(filtro);
                        tot_agrupar.Text = (bsCliforAgrupar.List as CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar).Sum(p => p.Vl_agrupar).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                    }
                }
                else if (tcFinanceiro.SelectedTab.Equals(tpChDevolvido))
                {
                    if (postoCombustivel.SelectedValue != null)
                    {
                        string filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        BS_Titulo.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "in",
                                                        vVL_Busca = "(" + filtro.Trim() + ")"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_titulo",
                                                        vOperador = "=",
                                                        vVL_Busca = "'R'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.status_compensado, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'V'"
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto desc");
                        tot_chdevolvido.Value = (BS_Titulo.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Sum(p => p.Vl_titulo);
                    }
                }
                else if (tcFinanceiro.SelectedTab.Equals(tpResultado))
                {
                    if (postoCombustivel.SelectedValue != null)
                    {
                        string filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lMov =
                            new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "a.cd_empresa in(" + filtro + ")"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(b.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'P'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo= "isnull(c.st_cartafrete, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            }
                                        }, string.Empty);
                        var caixaop = lMov.GroupBy(p => p.Ds_portador,
                                                              (aux, venda) =>
                                                               new
                                                               {
                                                                   ds_portador = aux,
                                                                   vl_caixa = venda.Sum(x => x.Vl_recebidoliq)
                                                               }).ToList();
                        //Somar Caixa Operacional
                        tot_caixaop.Value = lMov.Sum(p => p.Vl_recebidoliq);
                        // constroi grafico
                        chConta.Series.Clear();

                        if (caixaop.Count > 0)
                        {
                            chConta.Series.Add("Caixa OP");
                            chConta.Series["Caixa OP"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                            //adiciona valor ao topo da barra
                            chConta.Series["Caixa OP"].IsValueShownAsLabel = true;
                            // transforma tudo em negrito
                            chConta.Series["Caixa OP"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                            caixaop.ForEach(p =>
                            {
                                chConta.Series["Caixa OP"].Points.AddXY(p.ds_portador, Math.Round(p.vl_caixa, 3, MidpointRounding.AwayFromZero));
                        });

                            chConta.Series["Caixa OP"].Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);



                        }


                        //Caixa gerencial
                        filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        bsCaixaGer.DataSource = new CamadaDados.Financeiro.Caixa.TCD_SaldoContaGer().Select(filtro, string.Empty);
                        tot_cofre.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Where(p => !p.St_cc).Sum(p => p.Vl_saldo);
                        tot_contacorrente.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Where(p => p.St_cc).Sum(p => p.Vl_saldo);
                        tot_chemitidos.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Sum(p => p.Vl_chemitido);

                        //Cartao Credito/Debito
                        filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        bsResumoCartao.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().SelectResumo(
                                                    new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "a.cd_empresa in(" + filtro.Trim() + ")"
                                                }
                                            });
                        tot_cartao.Value = (bsResumoCartao.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_nominal);

                        //Emprestimos recebidos/concedidos
                        filtro = "'" + postoCombustivel.SelectedValue.ToString() + "'";
                        if (lojaConv.SelectedValue != null)
                            filtro += ",'" + lojaConv.SelectedValue.ToString() + "'";
                        CamadaDados.Financeiro.Emprestimos.TList_Emprestimos lEmp =
                            new CamadaDados.Financeiro.Emprestimos.TCD_Emprestimos().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + filtro.Trim() + ")"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "(a.vl_emprestimo - a.vl_quitado)",
                                    vOperador = ">",
                                    vVL_Busca = "0"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty);
                        tot_emp_concedido.Value = lEmp.Where(p => p.Tp_emprestimo.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_atual);
                        tot_emp_recebido.Value = lEmp.Where(p => p.Tp_emprestimo.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_atual);
                    }
                    //if (chCaixaOp.Chart != null)
                    //    chCaixaOp.Chart.ResetDataSources();
                }
            }
            //Resultado
            tot_resultbruto.Value = (tot_caixaop.Value +
                                    tot_cofre.Value +
                                    tot_contacorrente.Value +
                                    tot_contasrec.Value +
                                    tot_emp_concedido.Value +
                                    tot_cartao.Value) -
                                    (tot_chemitidos.Value +
                                    tot_emp_recebido.Value +
                                    tot_contaspag.Value);

            tot_resultfinal.Value = tot_resultbruto.Value + tot_estoque.Value;
        }

        private void TFPainelGerencial_Load(object sender, EventArgs e)
        {

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Data Atual Servidor
            dt_atual.Value = CamadaDados.UtilData.Data_Servidor();
            //Buscar Posto Combustivel
            postoCombustivel.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "EXISTS",
                                                    vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdc_cfgposto x "+
                                                                "where x.cd_empresa = a.cd_empresa)"
                                                }
                                            }, 0, string.Empty);
            postoCombustivel.DisplayMember = "NM_Empresa";
            postoCombustivel.ValueMember = "CD_Empresa";
            if ((postoCombustivel.DataSource as CamadaDados.Diversos.TList_CadEmpresa).Count > 0)
                postoCombustivel.SelectedIndex = 0;
            //Buscar Loja Conveniencia
            lojaConv.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "EXISTS",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "(not exists(select 1 from tb_pdc_cfgposto x " +
                                                        "where x.cd_empresa = a.cd_empresa)) or " +
                                                        "(exists(select 1 from tb_pdc_cfgposto x " +
                                                        "where x.cd_conveniencia = a.cd_empresa))"
                                        }
                                    }, 0, string.Empty);
            lojaConv.DisplayMember = "NM_Empresa";
            lojaConv.ValueMember = "CD_Empresa";
            if ((lojaConv.DataSource as CamadaDados.Diversos.TList_CadEmpresa).Count > 0)
                lojaConv.SelectedIndex = 0;
            //Buscar combustivel
            combustivel.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        }, 0, string.Empty, string.Empty, string.Empty);
            combustivel.DisplayMember = "ds_produto";
            combustivel.ValueMember = "cd_produto";
            this.afterBusca();
            ////Carregar Layout Graficos
            //chVendaCombustivel.OpenChart("C:\\Aliance.net\\Graficos\\ChartVendasCombustivel.cmk");
            //chVendaConv.OpenChart("C:\\Aliance.net\\Graficos\\ChartVendaConv.cmk");
            //chVendaCombustivel.OpenChart("C:\\Aliance.net\\Graficos\\ChartAbastecidasDia.cmk");
            //chAbastecidasMes.OpenChart("C:\\Aliance.net\\Graficos\\ChartAbastecidasMes.cmk");
            //chAbastecidasAno.OpenChart("C:\\Aliance.net\\Graficos\\ChartAbastecidasAno.cmk");
            //chEstoque.OpenChart("C:\\Aliance.net\\Graficos\\ChartEstoqueCombustivel.cmk");
            //chCaixaOp.OpenChart("C:\\Aliance.net\\Graficos\\ChartCaixaOp.cmk");
            //chContasPag.OpenChart("C:\\Aliance.net\\Graficos\\ChartContasPag.cmk");
            //chContasRec.OpenChart("C:\\Aliance.net\\Graficos\\ChartContasRec.cmk");

            //Habilitar botao designer
            tsmDesignerAbastecida.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerCaixaOp.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerContasPag.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerContasRec.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerEstoqueComb.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerVendaComb.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesignerVendaConv.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesAbastAno.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            tsmDesAbastMes.Enabled = Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
        }

        private void postoCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void lojaConv_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFPainelGerencial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmDesignerVendaComb_Click(object sender, EventArgs e)
        {
            //chVendaCombustivel.RunDesigner();
            //chVendaCombustivel.OpenChart("C:\\Aliance.net\\Graficos\\ChartVendasCombustivel.cmk");
        }

        private void tsmSalvarImgVendaComb_Click(object sender, EventArgs e)
        {
            //chVendaCombustivel.SaveAsImageDialog();
        }

        private void tsmImpVendaComb_Click(object sender, EventArgs e)
        {
            //chVendaCombustivel.PrintDialog();
        }

        private void tsmAbrirVendaComb_Click(object sender, EventArgs e)
        {
            //chVendaCombustivel.OpenDialog();
        }

        private void tsmAbrirVendaConv_Click(object sender, EventArgs e)
        {
            //chVendaConv.OpenDialog();
        }

        private void tsmPrintVendaConv_Click(object sender, EventArgs e)
        {
        }

        private void tsmSalvarImgVendaConv_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerVendaConv_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirAbastecida_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintAbastecida_Click(object sender, EventArgs e)
        {
        }

        private void tsmSalvarImgAbastecida_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerAbastecida_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirEstoqueComb_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintEstoqueComb_Click(object sender, EventArgs e)
        {
        }

        private void tsmSalvarImgEstoqueComb_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerEstoqueComb_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirCaixaOp_Click(object sender, EventArgs e)
        {
        }

        private void tsmImpCaixaOp_Click(object sender, EventArgs e)
        {
        }

        private void tsmImgCaixaOp_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerCaixaOp_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirContasRec_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintContasRec_Click(object sender, EventArgs e)
        {
        }

        private void tsmImgContasRec_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerContasRec_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirContasPag_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintContasPag_Click(object sender, EventArgs e)
        {
        }

        private void tsmImgContasPag_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesignerContasPag_Click(object sender, EventArgs e)
        {
        }

        private void tsmAbrirAbastMes_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintAbastMes_Click(object sender, EventArgs e)
        {
        }

        private void tsmSavAbastMes_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesAbastMes_Click(object sender, EventArgs e)
        {
        }

        private void tsmPrintAbastAno_Click(object sender, EventArgs e)
        {
        }

        private void tsmSavAbastAno_Click(object sender, EventArgs e)
        {
        }

        private void tsmDesAbastAno_Click(object sender, EventArgs e)
        {
        }

        private void combustivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.VendaConvenioCombustivel();
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void tcFinanceiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void tcVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void tcAbastecidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void tcVendaCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbOrderCliente_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbOrderCliGeral_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }
    }
}
