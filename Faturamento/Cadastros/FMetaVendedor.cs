using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.PDV;
using System.Windows.Forms.DataVisualization.Charting;

namespace Faturamento.Cadastros
{
    public partial class TFMetaVendedor : Form
    {
        private CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lItemVenda
        { get; set; }
        public TFMetaVendedor()
        {
            InitializeComponent();
            for (int i = 2008; i < 2050; i++)
            {
                cbxAnoMeta.Items.Add(i);
            }
        }

        public void ConfigChart()
        {
            for (int i = 0; 3 > i; i++)
            {
                chart1.Series.Add("Meta " + (i + 1));
                chart1.Series[i].ChartType = SeriesChartType.Column;
                chart1.Series[i].Color = Color.Blue;
                chart1.Series[i].IsValueShownAsLabel = true;
                chart1.Series[i].Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                chart1.Series[i].IsVisibleInLegend = true;
            }

            chart1.Series.Add("Vendas ");
            chart1.Series[3].ChartType = SeriesChartType.Column;
            chart1.Series[3].Color = Color.Green;
            chart1.Series[3].IsValueShownAsLabel = true;
            chart1.Series[3].Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            

            chart1.Legends[0].Title = "GRÁFICO DE VENDAS DOS ÚLTIMOS 12 MESES";
            chart1.Legends[0].Docking = Docking.Top;
        }

        public void BuscarRel()
        {
            if (bsVendedor.Current != null)
            {
                //Buscar Vendas do ultimos 12 meses
                string dt_ini = Convert.ToDateTime(new DateTime(CamadaDados.UtilData.Data_Servidor().AddMonths(-12).Year,
                                                                CamadaDados.UtilData.Data_Servidor().AddMonths(-12).Month, 1)).ToString("dd/MM/yyyy");
                string dt_fin = Convert.ToDateTime(new DateTime(CamadaDados.UtilData.Data_Servidor().AddMonths(-1).Year,
                                                                CamadaDados.UtilData.Data_Servidor().AddMonths(-1).Month,
                                                   DateTime.DaysInMonth(CamadaDados.UtilData.Data_Servidor().AddMonths(-1).Year,
                                                                       CamadaDados.UtilData.Data_Servidor().AddMonths(-1).Month), 23, 59, 59)).ToString("dd/MM/yyyy");

                //Buscar Totais Vendas por Mês
                lItemVenda =
                   new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(
                       new Utils.TpBusca[]
                       {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(cf.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + Convert.ToDateTime(dt_ini).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + Convert.ToDateTime(dt_fin).ToString("yyyyMMdd") + "'"
                            }
                       }, 0, string.Empty, "cf.dt_emissao");


                //Resumo Empresa
                TList_ResumoEmpresa lREmpresa = new TList_ResumoEmpresa();
                lItemVenda.GroupBy(p => p.Dt_emissao.Value.Month,
                    (aux, venda) =>
                    new TRegistro_ResumoEmpresa()
                    {
                        Mes = aux,
                        Vl_cupom = venda.Sum(x => x.Vl_subtotalliquido),
                        Vl_devolucao = venda.Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                        VL_TotalLiquido = venda.Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))),
                    }).ToList().ForEach(p => lREmpresa.Add(p));
                bsResumoEmpresa.DataSource = lREmpresa;

                #region Resumo Grupo de Produto Empresa
                TList_ResumoEmpresa lREmpresaGrupos = new TList_ResumoEmpresa();
                lREmpresa.ForEach(y =>
                {

                    lItemVenda.GroupBy(p => p.Cd_grupo,
                        (aux, venda) =>
                        new TRegistro_ResumoEmpresa()
                        {
                            Mes = y.Mes,
                            Cd_grupo = aux,
                            Ds_grupo = venda.ToList().Find(p => p.Cd_grupo.Equals(aux)).Ds_grupo.Trim(),
                            Vl_cupom = venda.ToList().FindAll(x => x.Dt_emissao.Value.Month.Equals(y.Mes)).Sum(x => x.Vl_subtotalliquido),
                            Vl_devolucao = venda.ToList().FindAll(x => x.Dt_emissao.Value.Month.Equals(y.Mes)).Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                            VL_TotalLiquido = venda.ToList().FindAll(x => x.Dt_emissao.Value.Month.Equals(y.Mes)).Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))),
                        }).Where(p=> p.VL_TotalLiquido > decimal.Zero).OrderByDescending(p => p.VL_TotalLiquido).ToList().ForEach(p => lREmpresaGrupos.Add(p));
                });

                TList_ResumoEmpresa ListaEmpresaGrupos = new TList_ResumoEmpresa();
                lREmpresaGrupos.ForEach(p =>
                {
                    if (ListaEmpresaGrupos.Count.Equals(0) || !ListaEmpresaGrupos.Exists(x => x.Ds_Mes.Equals(p.Ds_Mes)))
                    {
                        TRegistro_ResumoEmpresa r = new TRegistro_ResumoEmpresa();
                        r.Ds_grupo = p.Ds_Mes;
                        r.Mes = p.Mes;
                        ListaEmpresaGrupos.Add(r);
                    }
                    ListaEmpresaGrupos.Add(p);
                    ListaEmpresaGrupos.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo)).Vl_cupom += p.Vl_cupom;
                    ListaEmpresaGrupos.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo)).Vl_devolucao += p.Vl_devolucao;
                    ListaEmpresaGrupos.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo)).VL_TotalLiquido += p.VL_TotalLiquido;
                });
                bsResumoEmpresaGrupos.DataSource = ListaEmpresaGrupos;
                #endregion

                #region Total Vendedor Mes
                TList_ResumoVendedor lRVendedor = new TList_ResumoVendedor();
                (bsVendedor.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadClifor).ForEach(y =>
                {
                    cbxVendedor.Items.Add(y.Nm_clifor);
                    lItemVenda.GroupBy(p => p.Dt_emissao.Value.Month,
                        (aux, venda) =>
                        new TRegistro_ResumoVendedor()
                        {
                            Mes = aux,
                            Cd_vendedor = y.Cd_clifor,
                            Nm_vendedor = y.Nm_clifor,
                            Vl_cupom = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(y.Cd_clifor)).Sum(x => x.Vl_subtotalliquido),
                            Vl_devolucao = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(y.Cd_clifor)).Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                            Vl_TotalLiquido = (venda.ToList().FindAll(x => x.Cd_vendedor.Equals(y.Cd_clifor)).Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)))),
                        }).Where(p => p.Vl_TotalLiquido > decimal.Zero).ToList().ForEach(p => lRVendedor.Add(p));
                });

                TList_ResumoVendedor ListaVendedorMes = new TList_ResumoVendedor();
                lRVendedor.ForEach(p =>
                {
                    if (ListaVendedorMes.Count.Equals(0) || !ListaVendedorMes.Exists(x => x.Nm_vendedor.Equals(p.Nm_vendedor)))
                    {
                        TRegistro_ResumoVendedor r = new TRegistro_ResumoVendedor();
                        r.Nm_vendedor = p.Nm_vendedor;
                        r.Ds_Mes = p.Nm_vendedor;
                        ListaVendedorMes.Add(r);
                    }
                    ListaVendedorMes.Add(p);
                    ListaVendedorMes.FindLast(x => x.Mes == 0).Vl_cupom += p.Vl_cupom;
                    ListaVendedorMes.FindLast(x => x.Mes == 0).Vl_devolucao += p.Vl_devolucao;
                    ListaVendedorMes.FindLast(x => x.Mes == 0).Vl_TotalLiquido += p.Vl_TotalLiquido;
                });
                bsResumoVendedor.DataSource = ListaVendedorMes;
                #endregion
            }
        }

        private void afterGrava()
        {
            if (bsVendedor.Current == null)
            {
                MessageBox.Show("Selecione um Vendedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Pc_comissao.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Informe % Comissão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Vl_meta.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Informe Vl.Meta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lMeta.Exists(p => p.Vl_meta.Equals(Vl_meta.Value)))
            {
                MessageBox.Show("Já existe Vl.Meta:" + Vl_meta.Value.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + " cadastrada " +
                    "para o mês de " + cbxMesMeta.SelectedItem.ToString() + "!");
                return;
            }
            if ((bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lMeta.Exists(p => p.Pc_comissao.Equals(Pc_comissao.Value)))
            {
                MessageBox.Show("Já existe % Comissão:" + Pc_comissao.Value.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + " cadastrada " +
                    "para o mês de " + cbxMesMeta.SelectedItem.ToString() + "!");
                return;
            }
            CamadaNegocio.Faturamento.Cadastros.TCN_MetaVendedor.Gravar(
                new CamadaDados.Faturamento.Cadastros.TRegistro_MetaVendedor()
                {
                    Cd_empresa = cbEmpresa.SelectedValue.ToString(),
                    Cd_vendedor = (bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                    Mesvig = decimal.Parse(cbxMesMeta.SelectedIndex.ToString()) + 1,
                    Anovig = decimal.Parse(cbxAnoMeta.Text),
                    Vl_meta = Vl_meta.Value,
                    Pc_comissao = Pc_comissao.Value
                }, null);
            MessageBox.Show("Meta gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Pc_comissao.Value = decimal.Zero;
            Vl_meta.Value = decimal.Zero;
            bsVendedor_PositionChanged(this, new EventArgs());
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue != null)
            {
                //Buscar Vendedor
                bsVendedor.DataSource =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_vendedor, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_funcativo, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                                        "where a.CD_Clifor = x.CD_Vendedor " +
                                        "and x.CD_Empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "')"
                        }
                    }, 0, string.Empty);
                bsVendedor_PositionChanged(this, new EventArgs());
                //Buscar relatorios
                this.BuscarRel();
            }
        }

        private void TFMetaVendedor_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbxAnoMeta.Text = CamadaDados.UtilData.Data_Servidor().ToString("yyyy");
            cbxMesMeta.SelectedIndex = int.Parse(CamadaDados.UtilData.Data_Servidor().ToString("MM")) - 1;
            pFiltro.set_FormatZero();
            //Preencher lista empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            cbEmpresa.SelectedIndex = 0;
            this.afterBusca();
        }

        private void bsVendedor_PositionChanged(object sender, EventArgs e)
        {
            if (bsVendedor.Current != null)
            {
                
                //Buscar metas
                (bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lMeta =
                    CamadaNegocio.Faturamento.Cadastros.TCN_MetaVendedor.Buscar((bsVendedor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                                                 cbEmpresa.SelectedValue.ToString(),
                                                                                 (cbxMesMeta.SelectedIndex + 1).ToString(),
                                                                                 cbxAnoMeta.Text,
                                                                                 null);
                bsVendedor.ResetCurrentItem();
            }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void cbxMesMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            bsVendedor_PositionChanged(this, new EventArgs());
        }

        private void cbxAnoMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            bsVendedor_PositionChanged(this, new EventArgs());
        }

        private void TFMetaVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsResumoVendedor_PositionChanged(object sender, EventArgs e)
        {
            if (bsResumoVendedor.Current != null)
            {
                string Cd_vendedor = (bsResumoVendedor.Current as TRegistro_ResumoVendedor).Cd_vendedor;
                int mes = (bsResumoVendedor.Current as TRegistro_ResumoVendedor).Mes;
                //Resumo CLIENTE
                TList_ResumoVendedor lRCliente = new TList_ResumoVendedor();
                lItemVenda.GroupBy(p => p.Cd_clifor,
                        (aux, venda) =>
                        new TRegistro_ResumoVendedor()
                        {
                            Mes = mes,
                            Cd_clifor = aux,
                            Nm_clifor = venda.ToList().Find(p=> p.Cd_clifor.Equals(aux)).Nm_clifor,
                            Cd_vendedor = Cd_vendedor,
                            Vl_cupom = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) && x.Dt_emissao.Value.Month.Equals(mes)).Sum(x => x.Vl_subtotalliquido),
                            Vl_devolucao = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) && x.Dt_emissao.Value.Month.Equals(mes)).Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                            Vl_TotalLiquido = (venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) && x.Dt_emissao.Value.Month.Equals(mes)).Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)))),
                        }).OrderByDescending(p=> p.Vl_TotalLiquido).Where(p=> p.Vl_TotalLiquido > decimal.Zero).ToList().ForEach(p => lRCliente.Add(p));
                bsResumoCliente.DataSource = lRCliente;
                bsResumoCliente_PositionChanged(this, new EventArgs());
            }
        }

        private void bsResumoCliente_PositionChanged(object sender, EventArgs e)
        {
            if (bsResumoCliente.Current != null)
            {
                string Cd_vendedor = (bsResumoVendedor.Current as TRegistro_ResumoVendedor).Cd_vendedor;
                int mes = (bsResumoVendedor.Current as TRegistro_ResumoVendedor).Mes;
                //Resumo Vendedor
                TList_ResumoVendedor lRClienteGrupo = new TList_ResumoVendedor();
                (bsResumoCliente.DataSource as TList_ResumoVendedor).ForEach(y =>
                {
                    lItemVenda.GroupBy(p => p.Cd_grupo,
                            (aux, venda) =>
                            new TRegistro_ResumoVendedor()
                            {
                                Cd_grupo = aux,
                                Ds_grupo = venda.ToList().Find(p => p.Cd_grupo.Equals(aux)).Ds_grupo.Trim(),
                                Mes = mes,
                                Cd_clifor = y.Cd_clifor,
                                Nm_clifor = y.Nm_clifor,
                                Cd_vendedor = Cd_vendedor,
                                Vl_cupom = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) &&
                                                                  x.Dt_emissao.Value.Month.Equals(mes) &&
                                                                  x.Nm_clifor.Equals(y.Nm_clifor)).Sum(x => x.Vl_subtotalliquido),
                                Vl_devolucao = venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) &&
                                                                  x.Dt_emissao.Value.Month.Equals(mes) &&
                                                                  x.Nm_clifor.Equals(y.Nm_clifor)).Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                                Vl_TotalLiquido = (venda.ToList().FindAll(x => x.Cd_vendedor.Equals(Cd_vendedor) &&
                                                                  x.Dt_emissao.Value.Month.Equals(mes) &&
                                                                  x.Nm_clifor.Equals(y.Nm_clifor)).Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)))),
                            }).OrderByDescending(p => p.Vl_TotalLiquido).Where(p => p.Vl_TotalLiquido > decimal.Zero).ToList().ForEach(p => lRClienteGrupo.Add(p));
                });


                TList_ResumoVendedor ListaClienteGrupo = new TList_ResumoVendedor();
                lRClienteGrupo.ForEach(p =>
                {
                    if (ListaClienteGrupo.Count.Equals(0) || !ListaClienteGrupo.Exists(x => x.Ds_grupo.Equals(p.Nm_clifor)))
                    {
                        TRegistro_ResumoVendedor r = new TRegistro_ResumoVendedor();
                        r.Ds_grupo = p.Nm_clifor;
                        r.Nm_clifor = p.Nm_clifor;
                        ListaClienteGrupo.Add(r);
                    }
                    ListaClienteGrupo.Add(p);
                    ListaClienteGrupo.FindLast(x => string.IsNullOrEmpty(x.Cd_clifor)).Vl_cupom += p.Vl_cupom;
                    ListaClienteGrupo.FindLast(x => string.IsNullOrEmpty(x.Cd_clifor)).Vl_devolucao += p.Vl_devolucao;
                    ListaClienteGrupo.FindLast(x => string.IsNullOrEmpty(x.Cd_clifor)).Vl_TotalLiquido += p.Vl_TotalLiquido;
                });

                bsResumoClienteGrupos.DataSource = ListaClienteGrupo;
            }
        }

        private void gResumoEmpresaGrupos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (string.IsNullOrEmpty((bsResumoEmpresaGrupos[e.RowIndex] as TRegistro_ResumoEmpresa).Cd_grupo))
                {
                    gResumoEmpresaGrupos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    gResumoEmpresaGrupos.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    gResumoEmpresaGrupos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gResumoEmpresaGrupos.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
                }

            }
        }

        private void gResumoVendedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if ((bsResumoVendedor[e.RowIndex] as TRegistro_ResumoVendedor).Mes == 0)
                {
                    gResumoVendedor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    gResumoVendedor.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    gResumoVendedor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gResumoVendedor.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
                }

            }
        }

        private void gResumoClienteGrupo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (string.IsNullOrEmpty((bsResumoClienteGrupos[e.RowIndex] as TRegistro_ResumoVendedor).Cd_grupo))
                {
                    gResumoClienteGrupo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    gResumoClienteGrupo.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    gResumoClienteGrupo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gResumoClienteGrupo.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
                }

            }
        }

        private void cbxVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxVendedor.SelectedItem.ToString()))
            {
                TList_ResumoVendedor lRGraficoVendedor = new TList_ResumoVendedor();
                lItemVenda.GroupBy(p => p.Dt_emissao.Value.Month,
                        (aux, venda) =>
                        new TRegistro_ResumoVendedor()
                        {
                            Mes = aux,
                            Ano = venda.ToList().Find(x=> x.Dt_emissao.Value.Month.Equals(aux)).Dt_emissao.Value.Year,
                            Nm_vendedor = cbxVendedor.SelectedItem.ToString(),
                            Vl_cupom = venda.ToList().FindAll(x => x.Nm_vendedor.Equals(cbxVendedor.SelectedItem.ToString())).Sum(x => x.Vl_subtotalliquido),
                            Vl_devolucao = venda.ToList().FindAll(x => x.Nm_vendedor.Equals(cbxVendedor.SelectedItem.ToString())).Sum(x => x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)),
                            Vl_TotalLiquido = (venda.ToList().FindAll(x => x.Nm_vendedor.Equals(cbxVendedor.SelectedItem.ToString())).Sum(x => x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade)))),
                        }).Where(p => p.Vl_TotalLiquido > decimal.Zero && p.Nm_vendedor.Equals(cbxVendedor.SelectedItem.ToString())).ToList().ForEach(p => lRGraficoVendedor.Add(p));

                bsGraficoVendedorMes.DataSource = lRGraficoVendedor;



                chart1.Series.Clear();
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
               
                //Buscar Metas
               
                this.ConfigChart();
                (bsGraficoVendedorMes.DataSource as TList_ResumoVendedor).ForEach(p =>
                {
                    CamadaDados.Faturamento.Cadastros.TList_MetaVendedor lMeta =
                       new CamadaDados.Faturamento.Cadastros.TCD_MetaVendedor().Select(
                           new Utils.TpBusca[]
                           {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'",
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "b.NM_Clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cbxVendedor.SelectedItem.ToString().Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.MesVig",
                                        vOperador = "=",
                                        vVL_Busca = p.Mes.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.AnoVig",
                                        vOperador = "=",
                                        vVL_Busca = p.Ano.ToString()
                                    }
                           }, 0, string.Empty, string.Empty);
                    chart1.Series[3].Points.AddXY(p.Ds_Mes, Math.Round(p.Vl_TotalLiquido, 2));
                    for (int i = 0; i < 3; i++)
                    {
                        chart1.Series[i].Points.AddXY(p.Ds_Mes, Math.Round(lMeta.Count > 0 ? lMeta[i].Vl_meta : 0, 2));                         
                    }

                    //int cont = 1;
                    //lMeta.ForEach(x =>
                    //{
                    //    string s = "Meta " + cont++.ToString() + p.Ds_Mes;
                    //    chart1.Series.Add(s);
                    //    chart1.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    //    chart1.Series[s].Color = Color.Blue;
                    //    chart1.Series[s].IsValueShownAsLabel = true;
                    //    chart1.Series[s].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    //    chart1.Series[s].IsVisibleInLegend = true;
                    //    chart1.Series[s].Points.AddXY(p.Ds_Mes, Math.Round(x.Vl_meta, 2));
                    //});
                });
                chart1.DataBind();
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (bsMeta.Current != null)
                if (MessageBox.Show("Confirma a exclusão da meta selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_MetaVendedor.Excluir(bsMeta.Current as CamadaDados.Faturamento.Cadastros.TRegistro_MetaVendedor, null);
                        MessageBox.Show("Meta excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsVendedor_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tcMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMeta.SelectedTab.Equals(tpRel))
                tlpMeta.RowStyles[2] = new RowStyle(SizeType.Absolute, 0);
            else
                tlpMeta.RowStyles[2] = new RowStyle(SizeType.Absolute, 59);
        }
    }
}
