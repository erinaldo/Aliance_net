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
    public partial class TFPainelOnLine: Form
    {
        private static System.Timers.Timer tmpOnLine;

        public TFPainelOnLine()
        {
            InitializeComponent();
            tmpOnLine = new System.Timers.Timer();
            tmpOnLine.Interval = 500;
            tmpOnLine.SynchronizingObject = this;
            tmpOnLine.Elapsed += new System.Timers.ElapsedEventHandler(tmpOnLine_Elapsed);
        }

        void tmpOnLine_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                tmpOnLine.Stop();
                this.afterBusca();
            }
            finally
            {
                tmpOnLine.Start();
            }
        }

        private void DesativarInstrumentos()
        {
            if (tcCentral.SelectedTab.Equals(tpEstoqueOnLine))
            {
                //Estoque Tanques
                wg1.Visible = false;
                wg2.Visible = false;
                wg3.Visible = false;
                wg4.Visible = false;
                wg5.Visible = false;
                wg6.Visible = false;
            }
            else if (tcCentral.SelectedTab.Equals(tpVendasOnLine))
            {
                //Vendas dia
                wgVenda1.Visible = false;
                wgVenda2.Visible = false;
                wgVenda3.Visible = false;
                wgVenda4.Visible = false;
                wgVenda5.Visible = false;
                wgVenda6.Visible = false;
            }
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
            {
                //Fin Portador
                wgPort1.Visible = false;
                wgPort2.Visible = false;
                wgPort3.Visible = false;
                wgPort4.Visible = false;
                wgPort5.Visible = false;
                wgPort6.Visible = false;
            }
        }

        private void ConfigurarInstrumentos()
        {
            try
            {
                tmpOnLine.Stop();
                int index = 0;
                if (tcCentral.SelectedTab.Equals(tpEstoqueOnLine))
                {
                    //Configurar tanques
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_TanqueCombustivel.Buscar(string.Empty,
                                                                                          empresa.SelectedValue.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          "'A'",
                                                                                          null).OrderBy(p => p.Ds_produto).ToList().ForEach(p =>
                                                                                          {
                                                                                              if (index < 6)
                                                                                              {
                                                                                                  (flpTanques.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Visible = true;
                                                                                                  (flpTanques.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).InstrumentationStream = Utils.ResourcesUtils.Tanque;
                                                                                                  ((flpTanques.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text = p.Ds_produto;
                                                                                                  (((flpTanques.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).Maximum = Convert.ToDouble(p.Capacidadetanque);
                                                                                                  ((((flpTanques.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = 0;
                                                                                                  index++;
                                                                                              }
                                                                                          });
                    
                }
                else if (tcCentral.SelectedTab.Equals(tpVendasOnLine))
                {
                    //Configurar produtos
                    index = 0;
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 0, string.Empty, string.Empty, "a.ds_produto").ForEach(p =>
                        {
                            if (index < 6)
                            {
                                (flpVendas.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Visible = true;
                                (flpVendas.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).InstrumentationStream = Utils.ResourcesUtils.VendasDia;
                                ((flpVendas.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text = p.DS_Produto;
                                (((flpVendas.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).Maximum = 10000;
                                ((((flpVendas.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = 0;
                                index++;
                            }
                        });
                }
                else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
                {
                    //Configurar portador
                    index = 0;
                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(null, 0, string.Empty, "cd_portador").ForEach(p =>
                        {
                            if (index < 6)
                            {
                                (flpPortador.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Visible = true;
                                (flpPortador.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).InstrumentationStream = Utils.ResourcesUtils.Portador;
                                ((flpPortador.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text = p.Ds_portador;
                                (((flpPortador.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).Maximum = 10000;
                                ((((flpPortador.Controls[index] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = 0;
                                index++;
                            }
                        });
                }
            }
            finally
            {
                tmpOnLine.Start();
            }
        }

        private void afterBusca()
        {
            if (empresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa para visualizar dados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                empresa.Focus();
                return;
            }
            if (tcCentral.SelectedTab.Equals(tpEstoqueOnLine))
                //Buscar lista de tanques
                CamadaNegocio.PostoCombustivel.Cadastros.TCN_TanqueCombustivel.Buscar(string.Empty,
                                                                                      empresa.SelectedValue.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      "'A'",
                                                                                      null).OrderBy(p => p.Ds_produto).ToList().ForEach(p =>
                                                                                          {
                                                                                              for (int i = 0; i < flpTanques.Controls.Count; i++)
                                                                                              {
                                                                                                  if (i >= 6)
                                                                                                      break;
                                                                                                  if (((flpTanques.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text.Trim().ToUpper().Equals(p.Ds_produto.Trim().ToUpper()))
                                                                                                  {
                                                                                                      ((((flpTanques.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = Convert.ToDouble(p.Saldo_tanque);
                                                                                                      break;
                                                                                                  }
                                                                                              }
                                                                                          });
            else if (tcCentral.SelectedTab.Equals(tpVendasOnLine))
                //Buscar lista de vendas do dia
                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                           empresa.SelectedValue.ToString(),
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"),
                                                                           CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"),
                                                                           "'F'",
                                                                           "N",
                                                                           false,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null).GroupBy(p => p.Ds_produto,
                                                                           (aux, venda) =>
                                                                           new
                                                                           {
                                                                               ds_produto = aux,
                                                                               qtd_vendida = venda.Sum(x => x.Volumeabastecido)
                                                                           }).OrderBy(p => p.ds_produto).ToList().ForEach(p =>
                                                                           {
                                                                               for (int i = 0; i < flpVendas.Controls.Count; i++)
                                                                               {
                                                                                   if (i >= 6)
                                                                                       break;
                                                                                   if (((flpVendas.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text.Trim().ToUpper().Equals(p.ds_produto.Trim().ToUpper()))
                                                                                   {
                                                                                       ((((flpVendas.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = Convert.ToDouble(p.qtd_vendida);
                                                                                       break;
                                                                                   }
                                                                               }
                                                                           });
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixaPortador(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + empresa.SelectedValue.ToString() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.DT_Lancto",
                            vOperador = ">=",
                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.DT_Lancto",
                            vOperador = "<=",
                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + " 23:59:59'"
                        }
                    }, "a.cd_portador").ForEach(p =>
                        {
                            for (int i = 0; i < flpPortador.Controls.Count; i++)
                            {
                                if (i >= 6)
                                    break;
                                if (((flpPortador.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Rótulo1") as PerpetuumSoft.Instrumentation.Model.Label).Text.Trim().ToUpper().Equals(p.Ds_portador.Trim().ToUpper()))
                                {
                                    ((((flpPortador.Controls[i] as PerpetuumSoft.Instrumentation.Windows.Forms.Widget).Instrument.GetByName("Guide1") as PerpetuumSoft.Instrumentation.Model.Guide).GetByName("Scale1") as PerpetuumSoft.Instrumentation.Model.Scale).GetByName("Slider1") as PerpetuumSoft.Instrumentation.Model.Slider).Value = Convert.ToDouble(p.Vl_recebido);
                                    break;
                                }
                            }
                        });
        }

        private void TFPainelGerencial_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.DesativarInstrumentos();                                                                    
            empresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
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
            empresa.DisplayMember = "NM_Empresa";
            empresa.ValueMember = "CD_Empresa";
            if ((empresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).Count > 0)
            {
                empresa.SelectedIndex = 0;
                this.ConfigurarInstrumentos();
                tmpOnLine.Start();
            }
        }

        private void wg1_DoubleClick(object sender, EventArgs e)
        {
            /*using (PerpetuumSoft.Instrumentation.Windows.Forms.Design.DesignerForm form = PerpetuumSoft.Instrumentation.Model.Instrument.CreateInstrumentDesignerForm())
            {
                form.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(wg1.Instrument);
                form.ShowDialog();
                wg1.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(form.Instrument);
                Utils.SettingsUtils.Default.Tanque = wg1.InstrumentationStream;
                Utils.SettingsUtils.Default.Save();
            }*/
        }

        private void wgVenda1_DoubleClick(object sender, EventArgs e)
        {
            /*using (PerpetuumSoft.Instrumentation.Windows.Forms.Design.DesignerForm form = PerpetuumSoft.Instrumentation.Model.Instrument.CreateInstrumentDesignerForm())
            {
                form.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(wgVenda1.Instrument);
                form.ShowDialog();
                wgVenda1.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(form.Instrument);
                Utils.SettingsUtils.Default.VendasDia = wgVenda1.InstrumentationStream;
                Utils.SettingsUtils.Default.Save();
            }*/
        }

        private void TFPainelGerencial_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tmpOnLine.Stop();
            }
            catch { }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DesativarInstrumentos();
            this.ConfigurarInstrumentos();
            this.afterBusca();
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ConfigurarInstrumentos();
            this.afterBusca();
        }

        private void wgPort1_DoubleClick(object sender, EventArgs e)
        {
            /*using (PerpetuumSoft.Instrumentation.Windows.Forms.Design.DesignerForm form = PerpetuumSoft.Instrumentation.Model.Instrument.CreateInstrumentDesignerForm())
            {
                form.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(wgPort1.Instrument);
                form.ShowDialog();
                wgPort1.Instrument = (PerpetuumSoft.Instrumentation.Model.Instrument)PerpetuumSoft.Framework.Serialization.XSerializationManager.Clone(form.Instrument);
                Utils.SettingsUtils.Default.Portador = wgPort1.InstrumentationStream;
                Utils.SettingsUtils.Default.Save();
            }*/
        }
    }
}
