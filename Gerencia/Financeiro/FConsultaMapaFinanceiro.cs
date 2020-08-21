using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Gerencia.Financeiro
{
    public partial class TFConsultaMapaFinanceiro : Form
    {
        bool Altera_Relatorio = false;

        public TFConsultaMapaFinanceiro()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(clbEmpresa.Vl_Busca))
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            decimal valor = decimal.Zero;

            #region Contas Gerenciais
            bsCaixaGer.DataSource = new CamadaDados.Financeiro.Caixa.TCD_SaldoContaGer().Select(clbEmpresa.Vl_Busca, string.Empty);
            //Buscar cartões com saldo a quitar
            object obj = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from TB_FIN_FaturaDescontar x " +
                                        "inner join TB_FIN_DescontarFat y " +
                                        "on x.cd_empresa = y.cd_empresa " +
                                        "and x.id_lote = y.id_lote " +
                                        "where x.id_fatura = a.id_fatura " +
                                        "and isnull(y.st_registro, 'A') = 'P') "
                        }
                    }, "sum(isnull(a.Vl_nominal, 0) + isnull(a.vl_juro, 0) - isnull(a.vl_quitado, 0))");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                tot_cartaorec.Value = Convert.ToDecimal(obj.ToString());
            else
                tot_cartaorec.Value = decimal.Zero;
            //Totalizar Contas Gerenciais
            vl_saldorealizado.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Sum(p=> p.Vl_saldo);
            tot_chemitidos.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Sum(p=> p.Vl_chemitido);
            tot_chrecebidos.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Sum(p=> p.Vl_chrecebido);
            tot_saldofut.Value = (bsCaixaGer.List as List<CamadaDados.Financeiro.Caixa.TRegistro_SaldoContaGer>).Sum(p=> p.Vl_saldofuturo) + tot_cartaorec.Value;
            #endregion

            #region Contas Receber
            #region Vencidas a mais de 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencida120.Value = valor;
            #endregion

            #region Vencidas mais 90 a 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencida90.Value = valor;
            #endregion

            #region Vencidas mais de 60 a 90 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencida60.Value = valor;
            #endregion

            #region Vencidas mais 30 a 60 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencida30.Value = valor;
            #endregion

            #region Vencidas a 30 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencida.Value = valor;
            #endregion

            #region Receber hoje
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "year(a.DT_Vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "year(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "month(a.dt_vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "month(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "day(a.dt_vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "day(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_receberhoje.Value = valor;
            #endregion
            
            #region Vencer a 30 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_vencer.Value = valor;
            #endregion

            #region Vencer mais 30 a 60 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_venc30.Value = valor;
            #endregion

            #region Vencer mais 60 a 90 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_venc60.Value = valor;
            #endregion

            #region Vencer mais 90 a 120
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_venc90.Value = valor;
            #endregion

            #region Vencer mais 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'R'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.status_parcela",
                                    vOperador = "<>",
                                    vVL_Busca = "'DESCONTADO'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_rec_venc120.Value = valor;
            #endregion
            tot_receber.Value = tot_rec_vencida120.Value + 
                                tot_rec_vencida90.Value +
                                tot_rec_vencida60.Value +
                                tot_rec_vencida30.Value +
                                tot_rec_vencida.Value +
                                tot_receberhoje.Value + 
                                tot_rec_vencer.Value +
                                tot_rec_venc30.Value +
                                tot_rec_venc60.Value +
                                tot_rec_venc90.Value +
                                tot_rec_venc120.Value;
            #endregion

            #region Contas Pagar
            #region Vencidas a mais de 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencida120.Value = valor;
            #endregion

            #region Vencidas mais 90 a 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencida90.Value = valor;
            #endregion

            #region Vencidas mais de 60 a 90 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencida60.Value = valor;
            #endregion

            #region Vencidas mais 30 a 60 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencida30.Value = valor;
            #endregion

            #region Vencidas a 30 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<",
                                    vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencida.Value = valor;
            #endregion

            #region Pagar hoje
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "year(a.DT_Vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "year(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "month(a.dt_vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "month(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "day(a.dt_vencto)",
                                    vOperador = "=",
                                    vVL_Busca = "day(getdate())"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pagarhoje.Value = valor;
            #endregion

            #region Vencer a 30 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_vencer.Value = valor;
            #endregion

            #region Vencer mais 30 a 60 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_venc30.Value = valor;
            #endregion

            #region Vencer mais 60 a 90 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_venc60.Value = valor;
            #endregion

            #region Vencer mais 90 a 120
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_venc90.Value = valor;
            #endregion

            #region Vencer mais 120 dias
            decimal.TryParse(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                    vOperador = ">",
                                    vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'L'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'G'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "in",
                                    vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                }
                            }, "isnull(sum(isnull(a.Vl_CalcAtual, 0)), 0)").ToString(), out valor);
            tot_pag_venc120.Value = valor;
            #endregion
            tot_pagar.Value = tot_pag_vencida120.Value +
                                tot_pag_vencida90.Value +
                                tot_pag_vencida60.Value +
                                tot_pag_vencida30.Value +
                                tot_pag_vencida.Value +
                                tot_pagarhoje.Value +
                                tot_pag_vencer.Value +
                                tot_pag_venc30.Value +
                                tot_pag_venc60.Value +
                                tot_pag_venc90.Value +
                                tot_pag_venc120.Value;
            #endregion

            #region Adiantamentos Devolver
            decimal.TryParse(new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "in",
                                                                vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.tp_movimento",
                                                                vOperador = "=",
                                                                vVL_Busca = "'C'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "isnull(a.st_adto, 'A')",
                                                                vOperador = "<>",
                                                                vVL_Busca = "'C'"
                                                            }
                                                        }, "sum(isnull(a.vl_total_quitado, 0) - isnull(a.vl_receber, 0))").ToString(), out valor);
            tot_dev_adtocon.Value = valor;
            decimal.TryParse(new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "in",
                                                vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_movimento",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_adto, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        }, "sum(isnull(a.vl_total_quitado, 0) - isnull(a.vl_pagar, 0))").ToString(), out valor);
            tot_dev_adtorec.Value = valor;
            #endregion

            #region Emprestimos Devolver
            decimal.TryParse(new CamadaDados.Financeiro.Emprestimos.TCD_Emprestimos().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "in",
                        vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_emprestimo",
                        vOperador = "=",
                        vVL_Busca = "'C'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "sum(isnull(a.vl_atual, 0))").ToString(), out valor);
            tot_dev_empcon.Value = valor;

            decimal.TryParse(new CamadaDados.Financeiro.Emprestimos.TCD_Emprestimos().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "in",
                        vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_emprestimo",
                        vOperador = "=",
                        vVL_Busca = "'R'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "sum(isnull(a.vl_atual, 0))").ToString(), out valor);
            tot_dev_emprec.Value = valor;
            #endregion

            //Resultado Bruto
            tot_resultbruto.Value = (vl_saldorealizado.Value + tot_receber.Value + tot_dev_adtocon.Value + tot_dev_empcon.Value) -
                                    (tot_chemitidos.Value + tot_pagar.Value + tot_dev_adtorec.Value + tot_dev_emprec.Value);
            #region Valor Estoque
            vl_estoque.Value = CamadaNegocio.Estoque.TCN_LanEstoque.CustoTotalEstoque(clbEmpresa.Vl_Busca.Trim(), null);
            #endregion

            //Resultado final
            tot_resultfinal.Value = tot_resultbruto.Value + vl_estoque.Value;
        }

        private void afterPrint()
        {
            if (bsCaixaGer.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCaixaGer;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();
                    Rel.Parametros_Relatorio.Add("EMPRESAS", clbEmpresa.Vl_Busca.Trim());
                    Rel.Parametros_Relatorio.Add("DT_BASE", CamadaDados.UtilData.Data_Servidor());

                    Rel.Parametros_Relatorio.Add("REC_VENCIDA120", tot_rec_vencida120.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCIDA90", tot_rec_vencida90.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCIDA60", tot_rec_vencida60.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCIDA30", tot_rec_vencida30.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCIDA", tot_rec_vencida.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCERHOJE", tot_receberhoje.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENCER", tot_rec_vencer.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENC30", tot_rec_venc30.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENC60", tot_rec_venc60.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENC90", tot_rec_venc90.Value);
                    Rel.Parametros_Relatorio.Add("REC_VENC120", tot_rec_venc120.Value);
                    Rel.Parametros_Relatorio.Add("REC_TOTAL", tot_receber.Value);

                    Rel.Parametros_Relatorio.Add("PAG_VENCIDA120", tot_pag_vencida120.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCIDA90", tot_pag_vencida90.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCIDA60", tot_pag_vencida60.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCIDA30", tot_pag_vencida30.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCIDA", tot_pag_vencida.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCERHOJE", tot_pagarhoje.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENCER", tot_pag_vencer.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENC30", tot_pag_venc30.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENC60", tot_pag_venc60.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENC90", tot_pag_venc90.Value);
                    Rel.Parametros_Relatorio.Add("PAG_VENC120", tot_pag_venc120.Value);
                    Rel.Parametros_Relatorio.Add("PAG_TOTAL", tot_pagar.Value);

                    Rel.Parametros_Relatorio.Add("ADTO_REC", tot_dev_adtorec.Value);
                    Rel.Parametros_Relatorio.Add("ADTO_CON", tot_dev_adtocon.Value);

                    Rel.Parametros_Relatorio.Add("EMP_REC", tot_dev_emprec.Value);
                    Rel.Parametros_Relatorio.Add("EMP_CON", tot_dev_empcon.Value);
                    
                    Rel.Parametros_Relatorio.Add("SALDO_FUTURO", tot_resultbruto.Value);
                    Rel.Parametros_Relatorio.Add("VL_ESTOQUE", vl_estoque.Value);
                    Rel.Parametros_Relatorio.Add("SALDO_FINAL", tot_resultfinal.Value);

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
                                           "RELATORIO " + this.Text.Trim(),
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
                                               "RELATORIO " + this.Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void Imprime_Relatorio(CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc)
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                Relatorio.Nome_Relatorio = "TFLanContas";
                Relatorio.NM_Classe = "TFLanContas";
                Relatorio.Modulo = "FIN";
                Relatorio.Ident = "TFLanContas_Parcelas";
                BindingSource bs = new BindingSource();
                bs.DataSource = lParc;
                Relatorio.DTS_Relatorio = bs;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO CONTAS PAGAR/RECEBER";

                if (Altera_Relatorio)
                {
                    Relatorio.Gera_Relatorio(string.Empty,
                                             fImp.pSt_imprimir,
                                             fImp.pSt_visualizar,
                                             fImp.pSt_enviaremail,
                                             fImp.pSt_exportPdf,
                                             fImp.Path_exportPdf,
                                             fImp.pDestinatarios,
                                             null,
                                             "RELATORIO " + this.Text.Trim(),
                                             fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(string.Empty,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RELATORIO " + this.Text.Trim(),
                                                 fImp.pDs_mensagem);
            }
        }

        private void TFConsultaMapaFinanceiro_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCaixaGer);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Lista de Empresas
            clbEmpresa.Display = "NM_Empresa";
            clbEmpresa.Value = "CD_Empresa";
            clbEmpresa.Tabela = new CamadaDados.Diversos.TCD_CadEmpresa().Buscar(
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
                                    "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                    }
                }, 0);
        }

        private void TFConsultaMapaFinanceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFConsultaMapaFinanceiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCaixaGer);
        }

        private void bb_impR120_Click(object sender, EventArgs e)
        {
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR90_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR60_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR30_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impRMes_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impRHoje_Click(object sender, EventArgs e)
        {
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "year(a.DT_Vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "year(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "month(a.dt_vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "month(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "day(a.dt_vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "day(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR30Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR60Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR90Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impR120Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impRMais120_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'R'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.status_parcela",
                                            vOperador = "<>",
                                            vVL_Busca = "'DESCONTADO'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP120_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP90_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                         new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP60_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP30_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impPMes_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<",
                                            vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impPHoje_Click(object sender, EventArgs e)
        {
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "year(a.DT_Vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "year(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "month(a.dt_vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "month(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "day(a.dt_vencto)",
                                            vOperador = "=",
                                            vVL_Busca = "day(getdate())"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP30Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP60Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(30).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP90Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(60).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impP120Mais_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(90).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }

        private void bb_impPMais120_Click(object sender, EventArgs e)
        {
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            this.Imprime_Relatorio(new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_mov",
                                            vOperador = "=",
                                            vVL_Busca = "'P'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                            vOperador = ">",
                                            vVL_Busca = "'" + dt_atual.AddDays(120).ToString("yyyyMMdd") + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'G'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "in",
                                            vVL_Busca = "(" + clbEmpresa.Vl_Busca.Trim() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty));
        }
    }
}
