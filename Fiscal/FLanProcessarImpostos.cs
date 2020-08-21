using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Proc_Commoditties;

namespace Fiscal
{
    public partial class TFLanProcessarImpostos : Form
    {
        private decimal Vl_debito;
        private decimal Vl_credito;
        private decimal vl_saldocredor;
        private decimal vl_saldodevedor;

        public TFLanProcessarImpostos()
        {
            InitializeComponent();
            this.Vl_debito = decimal.Zero;
            this.Vl_credito = decimal.Zero;
            this.vl_saldocredor = decimal.Zero;
            this.vl_saldodevedor = decimal.Zero;
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_emp.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_emp.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_imposto.Text))
            {
                MessageBox.Show("Obrigatorio informar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_imposto.Focus();
                return;
            }
            //Buscar impostos Debitar
            //bsImpostoSaida.DataSource = CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.BuscaApurar(cd_emp.Text,
            //                                                                                            cd_imposto.Text,
            //                                                                                            "S",
            //                                                                                            new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1).ToString("dd/MM/yyyy"),
            //                                                                                            new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("dd/MM/yyyy"),
            //                                                                                            false,
            //                                                                                            null);
            //bsImpostoSaida.ResetCurrentItem();
            ////Buscar impostos creditar
            //bsImpostosEntrada.DataSource = CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.BuscaApurar(cd_emp.Text,
            //                                                                                               cd_imposto.Text,
            //                                                                                               "E",
            //                                                                                               new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, 1).ToString("dd/MM/yyyy"),
            //                                                                                               new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("dd/MM/yyyy"),
            //                                                                                               false,
            //                                                                                               null);
            //bsImpostosEntrada.ResetCurrentItem();
            //Totalizar impostos
            this.TotalizarImpostos();
        }
        
        private void TotalizarImpostos()
        {
            decimal tot_retsai = decimal.Zero;
            decimal tot_substsai = decimal.Zero;
            decimal tot_impcalcsai = decimal.Zero;
            decimal tot_retent = decimal.Zero;
            decimal tot_credent = decimal.Zero;
            decimal tot_substent = decimal.Zero;
            decimal tot_outroscred = decimal.Zero;
            decimal tot_estornocred = decimal.Zero;
            decimal tot_outrosdeb = decimal.Zero;
            decimal tot_estornodeb = decimal.Zero;
            if (bsImpostoSaida.Count > 0)
            {
                tot_retsai = (bsImpostoSaida.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostoretido);
                lblImpRetSaida.Text = tot_retsai.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                tot_impcalcsai = (bsImpostoSaida.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostocalc);
                lblImpCalcSaida.Text = tot_impcalcsai.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                tot_substsai = (bsImpostoSaida.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostosubsttrib);
                lblImpSubstSaida.Text = tot_substsai.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            }
            if (bsImpostosEntrada.Count > 0)
            {
                tot_retent = (bsImpostosEntrada.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostoretido);
                lblImpRetEntrada.Text = tot_retent.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                //Somar imposto creditar
                object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_ImpostosNF().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_emp.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_imposto",
                                        vOperador = "=",
                                        vVL_Busca = cd_imposto.Text
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "(nf.dt_saient <= " + "'" + new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("yyyyMMdd") + " 23:59:59') or" +
                                                    "(ctrc.DT_SaiEnt <= " + "'" + new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("yyyyMMdd") + " 23:59:59')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_lotefis",
                                        vOperador = "is",
                                        vVL_Busca = "null"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.st_gerarcredito",
                                        vOperador = "=",
                                        vVL_Busca = "0"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "(nf.Tp_Movimento = 'E' or ctrc.tp_movimento = 'E')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_SerieNF serie " +
			                                        "where ((serie.Nr_Serie = nf.Nr_Serie and serie.cd_modelo = nf.cd_modelo) or " +
                                                    "(serie.Nr_Serie = ctrc.Nr_Serie and serie.cd_modelo = ctrc.cd_modelo)) " +
			                                        "and isnull(serie.ST_GeraSintegra, 'N') = 'S')"
                                    }
                                }, "isnull(sum(isnull(a.Vl_ImpostoCalc, 0)), 0)");
                tot_credent = obj == null ? decimal.Zero : Convert.ToDecimal(obj);
                lblImpCredEntrada.Text = tot_credent.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                lblImpCalcEntrada.Text = (bsImpostosEntrada.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostocalc).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                obj = new CamadaDados.Faturamento.NotaFiscal.TCD_ImpostosNF().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_emp.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_imposto",
                                        vOperador = "=",
                                        vVL_Busca = cd_imposto.Text
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "(nf.dt_saient <= " + "'" + new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("yyyyMMdd") + " 23:59:59') or" +
                                                    "(ctrc.DT_SaiEnt <= " + "'" + new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("yyyyMMdd") + " 23:59:59')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_lotefis",
                                        vOperador = "is",
                                        vVL_Busca = "null"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.st_gerarcredito",
                                        vOperador = "=",
                                        vVL_Busca = "1"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "(nf.Tp_Movimento = 'E' or ctrc.tp_movimento = 'E')"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_SerieNF serie " +
			                                        "where ((serie.Nr_Serie = nf.Nr_Serie and serie.cd_modelo = nf.cd_modelo) or " +
                                                    "(serie.Nr_Serie = ctrc.Nr_Serie and serie.cd_modelo = ctrc.cd_modelo)) " +
			                                        "and isnull(serie.ST_GeraSintegra, 'N') = 'S')"
                                    }
                                }, "isnull(sum(isnull(a.Vl_ImpostoCalc, 0)), 0)");
                lblImpostoNCredEntrada.Text = obj == null ? string.Empty : Convert.ToDecimal(obj.ToString()).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                tot_substent = (bsImpostosEntrada.DataSource as CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF).Sum(p => p.Vl_impostosubsttrib);
                lblImpSubstEntrada.Text = tot_substent.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            }
            //Buscar outros debitos/creditos
            CamadaDados.Fiscal.TList_LanctoImposto lImposto =
                new CamadaDados.Fiscal.TCD_LanctoImposto().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_emp.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_imposto",
                        vOperador = "=",
                        vVL_Busca = cd_imposto.Text
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_lancto",
                        vOperador = "<=",
                        vVL_Busca = "'" + new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("yyyyMMdd") + " 23:59:59'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_lotefis",
                        vOperador = "is",
                        vVL_Busca = "null"
                    }
                }, 0, string.Empty);
            if (lImposto.Count > 0)
            {
                tot_outroscred = lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_lancto);
                tot_estornocred = lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("C") && p.Tp_lancto.Trim().Equals("1")).Sum(p => p.Vl_lancto);
                tot_outrosdeb = lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("D")).Sum(p => p.Vl_lancto);
                tot_estornodeb = lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("D") && p.Tp_lancto.Trim().Equals("3")).Sum(p => p.Vl_lancto);
                tot_outroscreditos.Text = tot_outroscred.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                tot_estorno_credito.Text = tot_estornocred.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                tot_outrosdebitos.Text = tot_outrosdeb.ToString("N2", new System.Globalization.CultureInfo("en-US"));
                tot_estornodebito.Text = tot_estornodeb.ToString("N2", new System.Globalization.CultureInfo("en-US"));
            }
            else
            {
                tot_outroscreditos.Text = string.Empty;
                tot_estorno_credito.Text = string.Empty;
                tot_outrosdebitos.Text = string.Empty;
                tot_estornodebito.Text = string.Empty;
            }
            vl_saldodevedor = (tot_impcalcsai + tot_substsai + tot_outrosdeb - tot_estornodeb);
            tot_debito.Text = vl_saldodevedor.ToString("N2", new System.Globalization.CultureInfo("en-US"));
            vl_saldocredor = (tot_credent + tot_retent + this.Vl_credito + tot_outroscred - tot_estornocred);
            tot_saldocredito.Text = vl_saldocredor.ToString("N2", new System.Globalization.CultureInfo("en-US"));
            if ((vl_saldodevedor - vl_saldocredor) > 0)
                lblSaldoCredorDevedor.Text = "SALDO DEVEDOR: " + (vl_saldodevedor - vl_saldocredor).ToString("N2", new System.Globalization.CultureInfo("en-US"));
            else
                lblSaldoCredorDevedor.Text = "SALDO CREDOR: " + (vl_saldocredor - vl_saldodevedor).ToString("N2", new System.Globalization.CultureInfo("en-US"));
        }

        private void BuscarUltimoLoteFis()
        {
            if ((!string.IsNullOrEmpty(cd_emp.Text)) &&
                (!string.IsNullOrEmpty(cd_imposto.Text)))
            {
                CamadaDados.Fiscal.TList_LoteImposto lImposto =
                    new CamadaDados.Fiscal.TCD_LoteImposto().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_emp.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_imposto",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_imposto.Text.Trim() + "'"
                        }
                    }, 1, string.Empty, "a.dt_lote desc");
                if (lImposto.Count > 0)
                {
                    dt_ultimaApuracao.Text = lImposto[0].Dt_lotestr;
                    this.Vl_credito = lImposto[0].Vl_credito;
                    this.Vl_debito = lImposto[0].Vl_debito;
                    lblSaldoDevedorAnterior.Text = this.Vl_debito.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                    lblSaldoCredorAnterior.Text = this.Vl_credito.ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                }
                else
                {
                    dt_ultimaApuracao.Clear();
                    lblSaldoDevedorAnterior.Text = string.Empty;
                    lblSaldoCredorAnterior.Text = string.Empty;
                }
            }
        }

        private void DebitoCreditoAvulso()
        {
            if (string.IsNullOrEmpty(cd_emp.Text))
            {
                MessageBox.Show("Obritatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_emp.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_imposto.Text))
            {
                MessageBox.Show("Obrigatorio informar imposto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_imposto.Focus();
                return;
            }
            using (TFLanctoImposto fLancto = new TFLanctoImposto())
            {
                fLancto.Cd_empresa = cd_emp.Text;
                fLancto.Cd_imposto = cd_imposto.Text;
                fLancto.Dt_lancto = new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("dd/MM/yyyy");
                if (fLancto.ShowDialog() == DialogResult.OK)
                    if (fLancto.rLancto != null)
                    {
                        CamadaNegocio.Fiscal.TCN_LanctoImposto.Gravar(fLancto.rLancto, null);
                        MessageBox.Show("Lançamento imposto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                this.afterBusca();
            }
        }

        private void ProcessarImpostos()
        {
            if (string.IsNullOrEmpty(cd_emp.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_emp.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_imposto.Text))
            {
                MessageBox.Show("Obrigatorio informar imposto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_imposto.Focus();
                return;
            }
            using (TFProcessarImposto fProc = new TFProcessarImposto())
            {
                fProc.Cd_empresa = cd_emp.Text;
                fProc.Cd_imposto = cd_imposto.Text;
                fProc.Dt_lote = new DateTime(dtPeriodo.Value.Year, dtPeriodo.Value.Month, DateTime.DaysInMonth(dtPeriodo.Value.Year, dtPeriodo.Value.Month)).ToString("dd/MM/yyyy");
                fProc.Vl_debito = (vl_saldodevedor - vl_saldocredor) > decimal.Zero ? (vl_saldodevedor - vl_saldocredor) : decimal.Zero;
                fProc.Vl_credito = (vl_saldocredor - vl_saldodevedor) > decimal.Zero ? (vl_saldocredor - vl_saldodevedor) : decimal.Zero;
                fProc.St_lote = bsImpostoSaida.Count.Equals(0) && bsImpostosEntrada.Count.Equals(0);
                if(fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.rImp != null)
                    {
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_LoteImposto.ProcessarImposto(fProc.rImp, null);
                            MessageBox.Show("Registros fiscais processados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void CorrigirNota(bool St_saida)
        {
            if (St_saida)
            {
                if (bsImpostoSaida.Current != null)
                {
                    if ((bsImpostoSaida.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Tp_docto.Trim().ToUpper().Equals("NFF"))
                    {
                        using (TFCorrecaoNota fCorrecao = new TFCorrecaoNota())
                        {
                            //Buscar registro nota fiscal para corrigir
                            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsImpostoSaida.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
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
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
                            if (lNf.Count > 0)
                            {
                                if (lNf[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                                        lNf[0].Cd_modelo.Trim().Equals("55") &&
                                        lNf[0].St_transmitidoNFe)
                                {
                                    MessageBox.Show("Não é permitido fazer correção NF-e enviada para receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fCorrecao.rfaturamento = lNf[0];
                                if (fCorrecao.ShowDialog() == DialogResult.OK)
                                    if (fCorrecao.rfaturamento != null)
                                    {
                                        //Processar alteracao nota
                                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.AlterarFaturamento(fCorrecao.rfaturamento, null);
                                        MessageBox.Show("Documento Fiscal Alterado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                    }
                            }
                        }
                    }
                }
            }
            else
            {
                if (bsImpostosEntrada.Current != null)
                {
                    if ((bsImpostosEntrada.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Tp_docto.Trim().ToUpper().Equals("NFF"))
                    {
                        using (TFCorrecaoNota fCorrecao = new TFCorrecaoNota())
                        {
                            //Buscar registro nota fiscal para corrigir
                            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsImpostosEntrada.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
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
                                                                                              0,
                                                                                              string.Empty,
                                                                                              null);
                            if (lNf.Count > 0)
                            {
                                if (lNf[0].Tp_nota.Trim().ToUpper().Equals("P") &&
                                        lNf[0].Cd_modelo.Trim().Equals("55") &&
                                        lNf[0].St_transmitidoNFe)
                                {
                                    MessageBox.Show("Não é permitido fazer correção NF-e enviada para receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fCorrecao.rfaturamento = lNf[0];
                                if (fCorrecao.ShowDialog() == DialogResult.OK)
                                    if (fCorrecao.rfaturamento != null)
                                    {
                                        //Processar alteracao nota
                                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.AlterarFaturamento(fCorrecao.rfaturamento, null);
                                        MessageBox.Show("Documento Fiscal Alterado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.afterBusca();
                                    }
                            }
                        }
                    }
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_emp }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
            this.BuscarUltimoLoteFis();
        }

        private void cd_emp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_emp.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_emp }, new CamadaDados.Diversos.TCD_CadEmpresa());
            this.BuscarUltimoLoteFis();
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.cd_imposto|Cd. Imposto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
            this.BuscarUltimoLoteFis();
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto());
            this.BuscarUltimoLoteFis();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanProcessarImpostos_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            label1.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pResultado.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltro.set_FormatZero();
        }

        private void TFLanProcessarImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_dc_Click(object sender, EventArgs e)
        {
            this.DebitoCreditoAvulso();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.ProcessarImpostos();
        }

        private void bb_corrigirSaida_Click(object sender, EventArgs e)
        {
            this.CorrigirNota(true);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.CorrigirNota(false);
        }

        private void TFLanProcessarImpostos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
