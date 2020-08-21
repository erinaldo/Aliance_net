using CamadaDados.Faturamento.Comissao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFGerarComissao : Form
    {
        private int countComissao = 0;
        private string Nome = string.Empty;
        public TFGerarComissao()
        {
            InitializeComponent();
            for (int i = 2008; i < 2050; i++)
            {
                cbxAno.Items.Add(i);
            }
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue != null)
            {
                //Buscar Vendedor
                bsMetasVendas.DataSource =
                    new CamadaDados.Faturamento.Comissao.TCD_Metas_VendasVendedor().Select(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Mes",
                            vOperador = "=",
                            vVL_Busca = (cbxMesMeta.SelectedIndex + 1).ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.Ano",
                            vOperador = "=",
                            vVL_Busca = cbxAno.Text
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                                        "where a.cd_vendedor = x.CD_Vendedor " +
                                        "and x.CD_Empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "')"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "CONVERT(DECIMAL(15,2), ISNULL(dbo.[F_SPLIT](a.meta, ',', 1), 0))",
                            vOperador = cbxAtingido.Checked && !cbxNaoAtingido.Checked ? ">" : "=",
                            vVL_Busca = (cbxAtingido.Checked && !cbxNaoAtingido.Checked) ||
                                        (!cbxAtingido.Checked && cbxNaoAtingido.Checked) ? "0" : 
                                        "CONVERT(DECIMAL(15,2), ISNULL(dbo.[F_SPLIT](a.meta, ',', 1), 0))"
                        }
                    }, 0, string.Empty);
                bsMetasVendas.ResetCurrentItem();
                bsVendedor_PositionChanged(this, new EventArgs());
            }
        }

        private void afterGrava()
        {
            if (ProgressBar.Visible == false)
                backgroundWorker1.RunWorkerAsync();
        }

        private void GerarCommisao()
        {
            if (bsMetasVendas.Current != null)
            {
                if ((bsMetasVendas.DataSource as CamadaDados.Faturamento.Comissao.TList_Metas_VendasVendedor).Exists(p => p.St_processar))
                {
                    countComissao = int.Parse((bsMetasVendas.DataSource as CamadaDados.Faturamento.Comissao.TList_Metas_VendasVendedor)
                                    .FindAll(x => x.St_processar).Sum(x => x.lItemVenda.Count).ToString());
                    int cont = 0;
                    (bsMetasVendas.DataSource as CamadaDados.Faturamento.Comissao.TList_Metas_VendasVendedor).FindAll(p => p.St_processar).ForEach(p =>
                        {
                            try
                            {
                                Nome = "GERANDO COMISSÃO " + p.Nm_vendedor.Split(new char[] { ' ' })[0];
                                for (int i = 0; p.lItemVenda.Count > i; i++)
                                {
                                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.GerarComissaoMetas(p.lItemVenda[i], p.Pc_comissao, null);
                                    this.backgroundWorker1.ReportProgress(cont++);
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        });
                    this.backgroundWorker1.ReportProgress(countComissao);
                    MessageBox.Show("Comissões geradas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TFGerarComissao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Mes anterior
            cbxMesMeta.SelectedIndex = int.Parse(CamadaDados.UtilData.Data_Servidor().AddMonths(-1).ToString("MM")) - 1;
            cbxAno.Text = CamadaDados.UtilData.Data_Servidor().ToString("MM").Equals("01") ? 
                CamadaDados.UtilData.Data_Servidor().AddYears(-1).ToString("yyyy") :
                CamadaDados.UtilData.Data_Servidor().ToString("yyyy");
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
            //Busca
            this.afterBusca();
        }

        private void bsVendedor_PositionChanged(object sender, EventArgs e)
        {
            if (bsMetasVendas.Current != null)
            {
                //Buscar Totais Vendas por Mês
                //Buscar Itens Vendas
                (bsMetasVendas.Current as TRegistro_Metas_VendasVendedor).lItemVenda =
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
                                vNM_Campo = "a.cd_vendedor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsMetasVendas.Current as TRegistro_Metas_VendasVendedor).Cd_vendedor.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(vr.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + Convert.ToDateTime(new DateTime(int.Parse(cbxAno.Text), int.Parse((cbxMesMeta.SelectedIndex + 1).ToString()), 1)).ToString("dd/MM/yyyy") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), vr.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + Convert.ToDateTime(new DateTime(int.Parse(cbxAno.Text), int.Parse((cbxMesMeta.SelectedIndex + 1).ToString()), 
                                                  DateTime.DaysInMonth(int.Parse(cbxAno.Text), int.Parse((cbxMesMeta.SelectedIndex + 1).ToString())), 23, 59, 59)).ToString("dd/MM/yyyy") + "'"
                            }
                        }, 0, string.Empty, string.Empty);
               
                //Buscar metas
                (bsMetasVendas.Current as TRegistro_Metas_VendasVendedor).lMeta =
                CamadaNegocio.Faturamento.Cadastros.TCN_MetaVendedor.Buscar((bsMetasVendas.Current as TRegistro_Metas_VendasVendedor).Cd_vendedor,
                                                                             cbEmpresa.SelectedValue.ToString(),
                                                                             (cbxMesMeta.SelectedIndex + 1).ToString(),
                                                                             cbxAno.Text,
                                                                             null);
                //Formar Composicao da Comissão por Produto
                TList_ComposicaoComissao ListaComp = new TList_ComposicaoComissao();
                (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lComposicao.Clear();
               (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(p => p.Pc_comissao > decimal.Zero).GroupBy(p =>
                    p.Cd_produto, (aux, venda) =>
                    new CamadaDados.Faturamento.Comissao.TRegistro_ComposicaoComissao()
                    {
                        Cd_produto = aux,
                        Ds_produto = venda.ToList().Find(x => x.Cd_produto.Equals(aux)).Ds_produto,
                        Quantidade = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.Where(x => x.Cd_produto.Equals(aux)).Count(),
                        Tot_venda = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x => x.Cd_produto.Equals(aux)).Sum(x =>
                                          x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))),
                        Pc_comissao = venda.ToList().Find(x => x.Cd_produto.Equals(aux)).Pc_comissao,
                        Total_comissao =  Math.Round((bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x => x.Cd_produto.Equals(aux)).Sum(x =>
                                          x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))) *
                                          venda.ToList().Find(x => x.Cd_produto.Equals(aux)).Pc_comissao / 100, 2)
                    }).ToList().ForEach(p=> ListaComp.Add(p));

                //Buscar Composicao da Comissão por Grupo Produto
                CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_GrupoProd lGrupo =
                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Buscar((bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).Cd_vendedor,
                                                                                        string.Empty,
                                                                                        null);
                if (lGrupo.Count > decimal.Zero)
                {
                    lGrupo.ForEach(y =>
                    {
                        (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.Where(p => p.Pc_comissao.Equals(decimal.Zero) && p.Cd_grupo.Equals(y.Cd_grupo)
                        ).GroupBy(p =>
                             p.Cd_grupo, (aux, venda) =>
                             new CamadaDados.Faturamento.Comissao.TRegistro_ComposicaoComissao()
                             {
                                 Cd_grupo = aux,
                                 Ds_grupo = venda.ToList().Find(x => x.Cd_grupo.Equals(aux)).Ds_grupo,
                                 Quantidade = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.Where(x =>
                                                                                          x.Cd_grupo.Equals(aux) && x.Pc_comissao.Equals(decimal.Zero)).Count(),
                                 Tot_venda = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x =>
                                                  x.Cd_grupo.Equals(aux) && x.Pc_comissao.Equals(decimal.Zero)).Sum(x =>
                                                   x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))),
                                 Pc_comissao = y.Pc_Comissao,
                                 Total_comissao = Math.Round((bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x =>
                                             x.Cd_grupo.Equals(aux) && x.Pc_comissao.Equals(decimal.Zero)).Sum(x =>
                                             x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))) * y.Pc_Comissao / 100, 2)
                             }).ToList().ForEach(p => ListaComp.Add(p));
                    });
                }
                //Formar Composição Comissão por Metas
               
                (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.Where(p => p.Pc_comissao.Equals(decimal.Zero) && !lGrupo.Exists(x => p.Cd_grupo.Equals(x.Cd_grupo))
                        ).GroupBy(p =>
                             p.Cd_empresa, (aux, venda) =>
                             new CamadaDados.Faturamento.Comissao.TRegistro_ComposicaoComissao()
                             {
                                 Quantidade = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.Where(x =>
                                                                                          x.Pc_comissao.Equals(decimal.Zero) && !lGrupo.Exists(k => x.Cd_grupo.Equals(k.Cd_grupo))).Count(),
                                 Tot_venda = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x =>
                                                  x.Pc_comissao.Equals(decimal.Zero) && !lGrupo.Exists(k => x.Cd_grupo.Equals(k.Cd_grupo))).Sum(x =>
                                                   x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))),
                                 Pc_comissao = (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).Pc_comissao,
                                 Total_comissao = Math.Round((bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lItemVenda.FindAll(x =>
                                             x.Pc_comissao.Equals(decimal.Zero) && !lGrupo.Exists(k => x.Cd_grupo.Equals(k.Cd_grupo))).Sum(x =>
                                             x.Vl_subtotalliquido - (x.Qtd_devolvida * (x.Vl_subtotalliquido / x.Quantidade))) *
                                             (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).Pc_comissao / 100, 5)
                             }).ToList().ForEach(p => ListaComp.Add(p));

                //Agrupar
                TList_ComposicaoComissao lista = new TList_ComposicaoComissao();
                ListaComp.ForEach(p =>
                {
                    if (lista.Count.Equals(0) || !lista.Exists(x => x.Ds_grupo.Equals(p.Tipo_comissao)))
                    {
                        if (p.Tipo_comissao != "META VENDEDOR")
                        {
                            TRegistro_ComposicaoComissao r = new TRegistro_ComposicaoComissao();
                            r.Ds_grupo = p.Tipo_comissao;
                            lista.Add(r);
                        }
                    }
                    p.Ds_grupo = !string.IsNullOrEmpty(p.Ds_grupo) ? p.Ds_grupo.Trim() : 
                                 !string.IsNullOrEmpty(p.Ds_produto) ?  p.Ds_produto.Trim() : p.Tipo_comissao;
                    lista.Add(p);
                    if (p.Tipo_comissao != "META VENDEDOR")
                    {
                        lista.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo) && string.IsNullOrEmpty(x.Cd_produto)).Quantidade += p.Quantidade;
                        lista.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo) && string.IsNullOrEmpty(x.Cd_produto)).Total_comissao += p.Total_comissao;
                        lista.FindLast(x => string.IsNullOrEmpty(x.Cd_grupo) && string.IsNullOrEmpty(x.Cd_produto)).Tot_venda += p.Tot_venda;
                    }
                });
                lista.ForEach(p => (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).lComposicao.Add(p));

                //Totalizar
                tot_comissaocalc.Text =
                    ListaComp.Sum(p => p.Total_comissao).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

                bsMetasVendas.ResetCurrentItem();
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

        private void cbxMesMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFGerarComissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.GerarCommisao();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Visible = true;
            lbCompletar.Visible = true;
            decimal cem = 100;
            if (Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0) <= 100)
            {
                ProgressBar.Value = int.Parse(Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0).ToString());
                lbCompletar.Text = Nome + " " + int.Parse(Math.Round(e.ProgressPercentage / Math.Round((countComissao / cem), 2), 0).ToString()) + "%";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visible = false;
            lbCompletar.Visible = false;
        }

        private void gMetasAtingidas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(3))
                {
                    if (Convert.ToDecimal(e.Value) > 0)
                        gMetasAtingidas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gMetasAtingidas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gMetasAtingidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsMetasVendas.Current != null && e.ColumnIndex == 0)
            {
                if ((bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).Vl_metaatingida > decimal.Zero)
                {
                    (bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).St_processar =
                        !(bsMetasVendas.Current as CamadaDados.Faturamento.Comissao.TRegistro_Metas_VendasVendedor).St_processar;
                    bsMetasVendas.ResetCurrentItem();
                }
            }
        }

        private void cbxAtingido_CheckedChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbxNaoAtingido_CheckedChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFGerarComissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProgressBar.Visible == true)
            {
                MessageBox.Show("Existe um processo de gerar comissão em andamento aguarde a finalização!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void gComp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (string.IsNullOrEmpty((bsComposicao[e.RowIndex] as TRegistro_ComposicaoComissao).Cd_grupo) &&
                    string.IsNullOrEmpty((bsComposicao[e.RowIndex] as TRegistro_ComposicaoComissao).Cd_produto))
                {
                    gComp.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    gComp.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    gComp.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gComp.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
                }
            }
        }
    }
}
