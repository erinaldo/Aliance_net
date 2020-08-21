using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Fiscal
{
    public partial class TFLanLivroFiscal : Form
    {
        private bool Altera_Relatorio = false;
        public string Cd_empresa
        { get; set; }
        public string Dt_inicial
        { get; set; }
        public string Dt_final
        { get; set; }

        public TFLanLivroFiscal()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Dt_inicial = string.Empty;
            this.Dt_final = string.Empty;
        }

        private void NovoDebitoCreditoAvulso()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            using (TFLanctoImposto fLancto = new TFLanctoImposto())
            {
                fLancto.Cd_empresa = cd_empresa.Text;
                fLancto.St_icms = true;
                fLancto.D_c = rbEntrada.Checked ? "C" : "D";
                fLancto.Dt_lancto = Dt_final;
                if(fLancto.ShowDialog() == DialogResult.OK)
                    if (fLancto.rLancto != null)
                    {
                        CamadaNegocio.Fiscal.TCN_LanctoImposto.Gravar(fLancto.rLancto, null);
                        MessageBox.Show("Lançamento imposto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
            }
        }

        private void BuscarListaSerie()
        {
            clbSerie.Tabela = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().Buscar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_gerasintegra, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, 0, string.Empty);
            clbSerie.Display = "ds_serienf";
            clbSerie.Value = "nr_serie";
        }

        private void BuscarListaCFOP()
        {
            clbCfop.Tabela = new CamadaDados.Fiscal.TCD_CadCFOP().Buscar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "substring(a.cd_cfop, 1, 1)",
                                        vOperador = "in",
                                        vVL_Busca = rbEntrada.Checked ? "('1', '2', '3')" : "('5', '6', '7')"
                                    }
                                }, 0, "a.cd_cfop, a.cd_cfop + '-' + a.ds_cfop as ds_cfop");
            clbCfop.Display = "ds_cfop";
            clbCfop.Value = "cd_cfop";
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (DT_Inic.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Inic.Focus();
                return;
            }
            if (DT_Final.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Final.Focus();
                return;
            }
            if (string.IsNullOrEmpty(clbCfop.Vl_Busca))
            {
                MessageBox.Show("Obrigatorio selecionar CFOP.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clbCfop.Focus();
                return;
            }
            //Resumo por Uf
            bsResumoFiscal.DataSource = new CamadaDados.Fiscal.TCD_ApuracaoImpostos().SelectResumoFiscal(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_movimento",
                                                vOperador = "=",
                                                vVL_Busca = rbEntrada.Checked ? "'E'" : "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_cfop",
                                                vOperador = "in",
                                                vVL_Busca = "(" + clbCfop.Vl_Busca.Trim() + ")"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : string.Empty,
                                                vOperador = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "=" : string.Empty,
                                                vVL_Busca = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : "(a.nr_serie not in(" + clbSerie.Vl_Busca.Trim() + ") or a.tp_nota = 'T')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "ISNULL(C.ST_GERASINTEGRA, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = ">=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, '')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        });
            //Resumo por CFOP
            bsResumoCfop.DataSource = new CamadaDados.Fiscal.TCD_ApuracaoImpostos().SelectApuracaoFiscal(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_movimento",
                                                vOperador = "=",
                                                vVL_Busca = rbEntrada.Checked ? "'E'" : "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : string.Empty,
                                                vOperador = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "=" : string.Empty,
                                                vVL_Busca = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : "(a.nr_serie not in(" + clbSerie.Vl_Busca.Trim() + ") or a.tp_nota = 'T')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "ISNULL(B.ST_GERASINTEGRA, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = ">=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, '')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        });
            //Lancamento Avulso
            bsLanctoImposto.DataSource = new CamadaDados.Fiscal.TCD_LanctoImposto().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fis_imposto x "+
                                                                "where x.cd_imposto = a.cd_imposto "+
                                                                "and x.st_icms = 0)"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.dt_lancto",
                                                    vOperador = ">=",
                                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.dt_lancto",
                                                    vOperador = "<=",
                                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                                                }
                                            }, 0, string.Empty);
            //Totalizar Campos Valores
            vl_totalcontabil.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p=> p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_contabil);
            vl_totalbasecalc.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p => p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_basecalc);
            vl_totisento.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p => p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_isentas);
            vl_totoutros.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p => p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_outros);
            vl_totalicms.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p => p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_icms);
            vl_totalicmssubsttrib.Value = (bsLivroFiscal.DataSource as CamadaDados.Fiscal.TList_LivroFiscal).Where(p => p.St_registro.Trim().ToUpper() != "C").Sum(p => p.Vl_icms_subst);

            tot_credito.Value = (bsLanctoImposto.DataSource as CamadaDados.Fiscal.TList_LanctoImposto).Where(p => p.D_c.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_lancto);
            tot_debito.Value = (bsLanctoImposto.DataSource as CamadaDados.Fiscal.TList_LanctoImposto).Where(p => p.D_c.Trim().ToUpper().Equals("D")).Sum(p => p.Vl_lancto);
            tot_estorno_d.Value = (bsLanctoImposto.DataSource as CamadaDados.Fiscal.TList_LanctoImposto).Where(p => p.D_c.Trim().ToUpper().Equals("D") && p.Tp_lancto.Trim().Equals("3")).Sum(p => p.Vl_lancto);
            tot_estornoC.Value = (bsLanctoImposto.DataSource as CamadaDados.Fiscal.TList_LanctoImposto).Where(p => p.D_c.Trim().ToUpper().Equals("C") && p.Tp_lancto.Trim().Equals("1")).Sum(p => p.Vl_lancto);
        }

        private void afterPrint()
        {
            if (bsLivroFiscal.Count > 0)
            {

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsLivroFiscal;
                    Rel.Adiciona_DataSource("DTS_Resumo", bsResumoFiscal);
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIS";
                    Rel.Ident = rbEntrada.Checked ? "TFLivroFiscal_Entrada" : "TFLivroFiscal_Saida";
                    Rel.Parametros_Relatorio.Add("DATA_INI", DT_Inic.Text);
                    Rel.Parametros_Relatorio.Add("DATA_FIN", DT_Final.Text);
                    Rel.Parametros_Relatorio.Add("NRLIVROFISCAL", nr_livro.Value);
                    Rel.Parametros_Relatorio.Add("NRPAGINAINICIAL", nr_pagina.Value);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LIVRO FISCAL" + (rbEntrada.Checked ? " ENTRADA" : " SAIDA");
                    
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
                                           "RELATORIO LIVRO FISCAL" + (rbEntrada.Checked ? " ENTRADA" : " SAIDA"),
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
                                               "RELATORIO LIVRO FISCAL" + (rbEntrada.Checked ? " ENTRADA" : " SAIDA"),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void ValidarData()
        {
            if ((DT_Inic.Text.Trim() != "/  /") &&
                (DT_Final.Text.Trim() != "/  /"))
                if (DT_Inic.Data.Date > DT_Final.Data.Date)
                {
                    MessageBox.Show("Data Inicial não pode ser maior que data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DT_Inic.Clear();
                    DT_Inic.Focus();
                }
        }

        private void CorrigirNota()
        {
            if (bsLivroFiscal.Current != null)
            {
                if ((bsLivroFiscal.Current as CamadaDados.Fiscal.TRegistro_LivroFiscal).Especie.Trim().ToUpper().Equals("NFF"))
                {
                    if ((bsLivroFiscal.Current as CamadaDados.Fiscal.TRegistro_LivroFiscal).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido alterar nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        using (Proc_Commoditties.TFCorrecaoNota fCorrecao = new Proc_Commoditties.TFCorrecaoNota())
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsLivroFiscal.Current as CamadaDados.Fiscal.TRegistro_LivroFiscal).Cd_empresa,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               (bsLivroFiscal.Current as CamadaDados.Fiscal.TRegistro_LivroFiscal).Nr_lanctofiscal.ToString(),
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
                                                                                               1,
                                                                                               string.Empty,
                                                                                               null)[0];
                            if (rFat.Tp_nota.Trim().ToUpper().Equals("P") &&
                                rFat.Cd_modelo.Trim().Equals("55") &&
                                rFat.St_transmitidoNFe)
                            {
                                MessageBox.Show("Não é permitido fazer correção NF-e enviada para receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            fCorrecao.rfaturamento = rFat;
                            if (fCorrecao.ShowDialog() == DialogResult.OK)
                                if (fCorrecao.rfaturamento != null)
                                {
                                    //Processar alteracao nota
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.AlterarFaturamento(fCorrecao.rfaturamento, null);
                                    MessageBox.Show("Nota Fiscal Alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                        }
                    }
                }
            }
        }

        private void ReprocessarLivroFiscal()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Necessario informar empresa para reprocessar livro fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (DT_Inic.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Necessario informar data inicial para reprocessar livro fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Inic.Focus();
                return;
            }
            if (DT_Final.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Necessario informar data final para reprocessar livro fiscal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Final.Focus();
                return;
            }
            if(MessageBox.Show("Confirma reprocessamento do livro fiscal?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                try
                {
                    CamadaNegocio.Fiscal.TCN_LivroFiscal.ReprocessarLivroFiscal(cd_empresa.Text,
                                                                                rbEntrada.Checked ? "E" : "S",
                                                                                clbCfop.Vl_Busca,
                                                                                clbSerie.Vl_Busca,
                                                                                DT_Inic.Text,
                                                                                DT_Final.Text,
                                                                                null);
                    MessageBox.Show("Livro Fiscal Reprocessado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanLivroFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, gLivroFiscal);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bb_corrigirnf.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CORRIGIR NF", null);
            pFiltro.set_FormatZero();
            cd_empresa.Text = this.Cd_empresa;
            DT_Inic.Text = this.Dt_inicial;
            DT_Final.Text = this.Dt_final;
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.BuscarListaCFOP();
            this.BuscarListaSerie();
        }
                
        private void rbEntrada_Click(object sender, EventArgs e)
        {
            this.BuscarListaCFOP();
            cbMarcaDesmarca.Checked = false;
            bsLivroFiscal.Clear();
            bsResumoFiscal.Clear();
        }

        private void rbSaida_Click(object sender, EventArgs e)
        {
            this.BuscarListaCFOP();
            cbMarcaDesmarca.Checked = false;
            bsLivroFiscal.Clear();
            bsResumoFiscal.Clear();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanLivroFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                this.ReprocessarLivroFiscal();
            else if (e.KeyCode.Equals(Keys.F10) && bb_corrigirnf.Visible)
                this.CorrigirNota();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbMarcaDesmarca_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCfop.Items.Count; i++)
                clbCfop.SetItemChecked(i, cbMarcaDesmarca.Checked);
        }

        private void cbMarcaDesmarca_CheckedChanged(object sender, EventArgs e)
        {
            cbMarcaDesmarca.Text = cbMarcaDesmarca.Checked ? "Marcar Todos" : "Desmarcar Todos";
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_NOVO_Click(object sender, EventArgs e)
        {
            this.NovoDebitoCreditoAvulso();
        }

        private void relatorioSinteticoDeNotasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void DT_Inic_Leave(object sender, EventArgs e)
        {
            this.ValidarData();
        }

        private void DT_Final_Leave(object sender, EventArgs e)
        {
            this.ValidarData();
        }

        private void cbMarcaSerie_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbSerie.Items.Count; i++)
                clbSerie.SetItemChecked(i, cbMarcaSerie.Checked);
        }

        private void cbMarcaSerie_CheckedChanged(object sender, EventArgs e)
        {
            cbMarcaSerie.Text = cbMarcaSerie.Checked ? "Marcar Todos" : "Desmarcar Todos";
        }

        private void visualizarTodasNotasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (DT_Inic.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Inic.Focus();
                return;
            }
            if (DT_Final.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Final.Focus();
                return;
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = new CamadaDados.Fiscal.TCD_ApuracaoImpostos().SelectApuracaoFiscal(
                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : string.Empty,
                                                vOperador = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "=" : string.Empty,
                                                vVL_Busca = clbSerie.Vl_Busca.Trim().Equals(string.Empty) ? "a.nr_serie" : "(a.nr_serie not in(" + clbSerie.Vl_Busca.Trim() + ") or a.tp_nota = 'T')"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "ISNULL(B.ST_GERASINTEGRA, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = ">=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, '')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        });
            if (bs.Count > 0)
            {
                //Buscar outros debitos/creditos
                CamadaDados.Fiscal.TList_LanctoImposto lImposto =
                    new CamadaDados.Fiscal.TCD_LanctoImposto().Select(
                    new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fis_imposto x "+
                                    "where x.cd_imposto = a.cd_imposto "+
                                    "and x.st_icms = 0)"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_lancto",
                        vOperador = "<=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_lotefis",
                        vOperador = "is",
                        vVL_Busca = "null"
                    }
                }, 0, string.Empty);
                //Buscar Saldo Anterior
                CamadaDados.Fiscal.TList_LoteImposto lLoteImp =
                    new CamadaDados.Fiscal.TCD_LoteImposto().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fis_imposto x "+
                                        "where x.cd_imposto = a.cd_imposto "+
                                        "and x.st_icms = 0)"
                        }
                    }, 1, string.Empty, "a.dt_lote desc");
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;

                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIS";
                    Rel.Ident = "TFResumoFiscal";
                    Rel.Parametros_Relatorio.Add("DATA_INI", DT_Inic.Text);
                    Rel.Parametros_Relatorio.Add("DATA_FIN", DT_Final.Text);
                    Rel.Parametros_Relatorio.Add("NRLIVROFISCAL", nr_livro.Value);
                    Rel.Parametros_Relatorio.Add("NRPAGINAINICIAL", nr_pagina.Value);
                    Rel.Parametros_Relatorio.Add("VL_DEBITAR", (bs.DataSource as CamadaDados.Fiscal.TList_ApuracaoFiscal).Where(p=> p.Cd_cfop.Substring(0, 1).Equals("5") ||
                                                                                                                                    p.Cd_cfop.Substring(0, 1).Equals("6") ||
                                                                                                                                    p.Cd_cfop.Substring(0, 1).Equals("7")).Sum(p=> p.Vl_icms));
                    Rel.Parametros_Relatorio.Add("VL_CREDITAR", (bs.DataSource as CamadaDados.Fiscal.TList_ApuracaoFiscal).Where(p=> p.Cd_cfop.Substring(0, 1).Equals("1") ||
                                                                                                                                     p.Cd_cfop.Substring(0, 1).Equals("2") ||
                                                                                                                                     p.Cd_cfop.Substring(0, 1).Equals("3")).Sum(p=> p.Vl_icms));
                    if (lImposto.Count > 0)
                    {
                        Rel.Parametros_Relatorio.Add("VL_OUTROS_DEB", lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("D")).Sum(p => p.Vl_lancto));
                        Rel.Parametros_Relatorio.Add("VL_ESTORNO_DEB", lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("D") && p.Tp_lancto.Trim().Equals("3")).Sum(p => p.Vl_lancto));
                        Rel.Parametros_Relatorio.Add("VL_OUTROS_CRED", lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_lancto));
                        Rel.Parametros_Relatorio.Add("VL_ESTORNO_CRED", lImposto.Where(p => p.D_c.Trim().ToUpper().Equals("C") && p.Tp_lancto.Trim().Equals("1")).Sum(p => p.Vl_lancto));
                    }
                    if (lLoteImp.Count > 0)
                    {
                        Rel.Parametros_Relatorio.Add("VL_DEB_ANTERIOR", lLoteImp[0].Vl_debito);
                        Rel.Parametros_Relatorio.Add("VL_CRED_ANTERIOR", lLoteImp[0].Vl_credito);
                    }

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO RESUMO FISCAL";

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
                                           "RELATORIO RESUMO FISCAL",
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
                                               "RELATORIO RESUMO FISCAL",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe registro para gerar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_corrigirnf_Click(object sender, EventArgs e)
        {
            this.CorrigirNota();
        }

        private void bb_reprocessa_Click(object sender, EventArgs e)
        {
            this.ReprocessarLivroFiscal();
        }

        private void TFLanLivroFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, gLivroFiscal);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }
    }
}
