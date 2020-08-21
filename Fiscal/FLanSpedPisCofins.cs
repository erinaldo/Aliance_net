using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormBusca;
using Proc_Commoditties;

namespace Fiscal
{
    public partial class TFLanSpedPisCofins : Form
    {
        public TFLanSpedPisCofins()
        {
            InitializeComponent();
            tcCentral.TabPages.Clear();
            tcDocSemImpostos.TabPages.Clear();
            tcDoctoCSTErrada.TabPages.Clear();
            tcDoctoCSTIsenta.TabPages.Clear();
            tcDoctoCSTTribE.TabPages.Clear();
            tcDoctoTribS.TabPages.Clear();
            tcCentral.TabPages.Add(tpSped);

            //Preencher combo ano
            for (int i = -10; i < 11; i++)
                cbAno.Items.Add(DateTime.Now.Year + i);
            cbAno.Text = DateTime.Now.Year.ToString();
            //Preencher Combo Mes
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("JANEIRO", "1"));
            cbx.Add(new Utils.TDataCombo("FEVEREIRO", "2"));
            cbx.Add(new Utils.TDataCombo("MARÇO", "3"));
            cbx.Add(new Utils.TDataCombo("ABRIL", "4"));
            cbx.Add(new Utils.TDataCombo("MAIO", "5"));
            cbx.Add(new Utils.TDataCombo("JUNHO", "6"));
            cbx.Add(new Utils.TDataCombo("JULHO", "7"));
            cbx.Add(new Utils.TDataCombo("AGOSTO", "8"));
            cbx.Add(new Utils.TDataCombo("SETEMBRO", "9"));
            cbx.Add(new Utils.TDataCombo("OUTUBRO", "10"));
            cbx.Add(new Utils.TDataCombo("NOVEMBRO", "11"));
            cbx.Add(new Utils.TDataCombo("DEZEMBRO", "12"));
            cbMes.DataSource = cbx;
            cbMes.DisplayMember = "Display";
            cbMes.ValueMember = "Value";
            cbMes.SelectedValue = DateTime.Now.Month.ToString();
        }

        private void GerarArquivo()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (rb_Substituto.Checked && string.IsNullOrEmpty(nr_recibo.Text))
            {
                MessageBox.Show("Obrigatorio informar recibo da escrituração que esta sendo retificada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_recibo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(path_sped.Text))
            {
                MessageBox.Show("Obrigatorio informar path para salvar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                path_sped.Focus();
                return;
            }
            //Verificar se existe NFe sem enviar para receita no periodo
            if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                        vNM_Campo = "case when a.tp_movimento = 'E' then convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) else convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) end",
                        vOperador = "between",
                        vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and '" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_nota",
                        vOperador = "=",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_transmitido_nfe, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'S'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    }
                }, "1") != null)
            {
                MessageBox.Show("Existe NFe não enviada para a receita no periodo.\r\n" +
                                "Obrigatorio excluir as mesmas e inutilizar os numeros para depois gerar o sped pis/cofins.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
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
                        vNM_Campo = "case when a.tp_movimento = 'E' then convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) else convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) end",
                        vOperador = "between",
                        vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "' and '" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_nota",
                        vOperador = "=",
                        vVL_Busca = "'P'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_transmitido_nfe, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_modelo",
                        vOperador = "=",
                        vVL_Busca = "'55'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_eventoNFe x " +
                                    "inner join tb_fat_evento y " +
                                    "on x.cd_evento = y.cd_evento " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                    "and y.tp_evento = 'CA' " +
                                    "and isnulL(x.st_registro, 'A') <> 'T')"
                    }
                }, "1") != null)
            {
                MessageBox.Show("Existe NFe com evento de cancelamento não transmitido para a receita.\r\n" +
                                "Obrigatorio enviar o evento para a receita ou excluir o mesmo para depois gerar o sped pis/cofins.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (!System.IO.Directory.Exists(path_sped.Text))
                    System.IO.Directory.CreateDirectory(path_sped.Text);
                string arq = CamadaNegocio.Fiscal.SPED_PISCOFINS.TCN_SpedPisCofins.ProcessarSpedFiscal(cbEmpresa.SelectedValue.ToString(),
                                                                                                       new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1),
                                                                                                       new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString())), 23, 59, 59),
                                                                                                       rb_Original.Checked ? "0" : rb_Substituto.Checked ? "1" : string.Empty,
                                                                                                       nr_recibo.Text);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path_sped.Text + "\\efdpiscofins" +
                                                                              cbEmpresa.SelectedValue.ToString() +
                                                                              cbMes.SelectedValue.ToString() +
                                                                              cbAno.Text + ".txt",
                                                                              false,
                                                                              Encoding.Default))
                {
                    sw.Write(arq + "\r\n");
                    sw.Close();
                    MessageBox.Show("Arquivo Sped PIS/COFINS gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AuditarMovimento()
        {
            if (cbEmpresa.SelectedValue != null)
            {
                tcCentral.TabPages.Remove(tpDoctoSemImpostos);
                tcCentral.TabPages.Remove(tpDocCSTErrada);
                tcCentral.TabPages.Remove(tpDoctoTributavelEnt);
                tcCentral.TabPages.Remove(tpDoctoTributavelSai);
                tcCentral.TabPages.Remove(tpDoctoCSTIsentaSai);
                tcDocSemImpostos.TabPages.Clear();
                tcDoctoCSTErrada.TabPages.Clear();
                tcDoctoCSTIsenta.TabPages.Clear();
                tcDoctoCSTTribE.TabPages.Clear();
                tcDoctoTribS.TabPages.Clear();

                Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio auditoria movimento SPED PIS/COFINS...");
                try
                {
                    #region Documentos Sem Impostos
                    #region Nota Fiscal
                    tEspera.Msg("Auditando NFs sem imposto PIS/COFINS...");
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_gerasintegra, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                                 vOperador = "=",
                                 vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_FAT_NotaFiscal_Item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> ''))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("NFs sem imposto PIS/COFINS: " + lNf.Count.ToString());
                    if (lNf.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoSemImpostos))
                            tcCentral.TabPages.Add(tpDoctoSemImpostos);
                        tcDocSemImpostos.TabPages.Add(tpNFSemImposto);
                    }
                    bsNfSemImposto.DataSource = lNf;
                    #endregion

                    #region Cupom Fiscal
                    tEspera.Msg("Auditando CUPONS FISCAIS sem imposto PIS/COFINS...");
                    CamadaDados.Faturamento.PDV.TList_NFCe lCf =
                        new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_nfce = a.id_nfce " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> ''))"
                            }
                        }, 0, string.Empty, string.Empty);
                    tEspera.Msg("CUPONS FISCAIS sem imposto PIS/COFINS: " + lCf.Count.ToString());
                    if (lCf.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoSemImpostos))
                            tcCentral.TabPages.Add(tpDoctoSemImpostos);
                        tcDocSemImpostos.TabPages.Add(tpCfSemImposto);
                    }
                    bsCfSemImposto.DataSource = lCf;
                    #endregion

                    #region Conhecimento Frete
                    tEspera.Msg("Auditando CTRC sem imposto PIS/COFINS...");
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtr =
                        new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from tb_fat_impostosnf x " + 
                                            "inner join tb_fis_imposto y " +
                                            "on x.cd_imposto = y.cd_imposto " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                            "and (y.st_pis = 0 or y.st_cofins = 0))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("CTRC sem imposto PIS/COFINS: " + lCtr.Count.ToString());
                    if (lCtr.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoSemImpostos))
                            tcCentral.TabPages.Add(tpDoctoSemImpostos);
                        tcDocSemImpostos.TabPages.Add(tpCtSemImposto);
                    }
                    bsCTSemImposto.DataSource = lCtr;
                    #endregion
                    #endregion

                    #region Documentos CST Errada (Entrada/Saida)
                    #region Nota Fiscal
                    tEspera.Msg("Auditando NFs com CST PIS/COFINS com tipo movimento invertido...");
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNfCSTErrada =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                                 vOperador = "=",
                                 vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and ((a.Tp_Movimento = 'E' and (x.cd_st_pis in('01', '02', '03', '04', '05', '06', '07', '08', '09', '49') or x.cd_st_cofins in('01', '02', '03', '04', '05', '06', '07', '08', '09', '49'))) or " +
                                            "(a.Tp_Movimento = 'S' and (x.CD_ST_cofins in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67', '70', '71', '72', '73', '74', '75', '98', '99') or x.CD_ST_pis in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67', '70', '71', '72', '73', '74', '75', '98', '99')))))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("NFs com CST invertido: " + lNfCSTErrada.Count.ToString());
                    if (lNfCSTErrada.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDocCSTErrada))
                            tcCentral.TabPages.Add(tpDocCSTErrada);
                        tcDoctoCSTErrada.TabPages.Add(tpNfCSTErrada);
                    }
                    bsNfCSTErrada.DataSource = lNfCSTErrada;
                    #endregion

                    #region Cupom Fiscal
                    tEspera.Msg("Auditando CUPONS FISCAIS com CST PIS/COFINS com tipo movimento invertido...");
                    CamadaDados.Faturamento.PDV.TList_NFCe lCfCSTErrada =
                        new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_nfce = a.id_nfce " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67', '70', '71', '72', '73', '74', '75', '98', '99') or x.cd_st_cofins in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67', '70', '71', '72', '73', '74', '75', '98', '99')))"
                            }
                        }, 0, string.Empty, string.Empty);
                    tEspera.Msg("CUPONS FISCAIS com CST invertida: " + lCfCSTErrada.Count.ToString());
                    if (lCfCSTErrada.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDocCSTErrada))
                            tcCentral.TabPages.Add(tpDocCSTErrada);
                        tcDoctoCSTErrada.TabPages.Add(tpCfCSTErrada);
                    }
                    bsCfCSTErrada.DataSource = lCfCSTErrada;
                    #endregion

                    #region Conhecimento Frete
                    tEspera.Msg("Auditando CTRC com CST PIS/COFINS com tipo movimento invertido...");
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrCSTErrada =
                        new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_impostosnf x " + 
                                            "inner join tb_fis_imposto y " +
                                            "on x.cd_imposto = y.cd_imposto " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                            "and (y.st_pis = 0 or y.st_cofins = 0) " +
                                            "and ((a.Tp_Movimento = 'E' and x.cd_st in('01', '02', '03', '04', '05', '06', '07', '08', '09', '49')) or " +
                                            "(a.Tp_Movimento = 'S' and x.CD_ST in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67', '70', '71', '72', '73', '74', '75', '98', '99'))))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("CTRC com CST invertida: " + lCtrCSTErrada.Count.ToString());
                    if (lCtrCSTErrada.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDocCSTErrada))
                            tcCentral.TabPages.Add(tpDocCSTErrada);
                        tcDoctoCSTErrada.TabPages.Add(tpCTCSTErrada);
                    }
                    bsCTCSTErrada.DataSource = lCtrCSTErrada;
                    #endregion
                    #endregion

                    #region Documentos Tributados sem base credito e/ou tipo credito
                    #region Nota Fiscal
                    tEspera.Msg("Auditando NFs com CST PIS/COFINS TRIBUTADO sem base de credito e/ou tipo credito...");
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNfCSTTribE =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                                 vOperador = "=",
                                 vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67') or x.cd_st_cofins in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67')) " +
                                            "and (x.id_basecreditoPIS is null or x.id_tpcredPIS is null or x.id_basecreditoCofins is null or x.id_tpcredCofins is null))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("NFs com CST TRIBUTADO sem base de credito e/ou tipo credito: " + lNfCSTTribE.Count.ToString());
                    if (lNfCSTTribE.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoTributavelEnt))
                            tcCentral.TabPages.Add(tpDoctoTributavelEnt);
                        tcDoctoCSTTribE.TabPages.Add(tpNfTribE);
                    }
                    bsNfTribE.DataSource = lNfCSTTribE;
                    #endregion

                    #region Conhecimento Frete
                    tEspera.Msg("Auditando CTRC com CST PIS/COFINS TRIBUTADO sem base de credito e/ou tipo credito...");
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrTribE =
                        new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_impostosnf x " + 
                                            "inner join tb_fis_imposto y " +
                                            "on x.cd_imposto = y.cd_imposto " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                            "and (y.st_pis = 0 or y.st_cofins = 0) " +
                                            "and x.cd_st in('50', '51', '52', '53', '54', '55', '56', '60', '61', '62', '63', '64', '65', '66', '67') " +
                                            "and (x.id_basecredito is null or x.id_tpcred is null))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("CTRC com CST TRIBUTADO sem base de credito e/ou tipo credito: " + lCtrTribE.Count.ToString());
                    if (lCtrTribE.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoTributavelEnt))
                            tcCentral.TabPages.Add(tpDoctoTributavelEnt);
                        tcDoctoCSTTribE.TabPages.Add(tpCTTribE);
                    }
                    bsCTTribE.DataSource = lCtrTribE;
                    #endregion
                    #endregion

                    #region Documento Tributados sem tipo contribuicao e/ou tipo receita
                    #region Nota Fiscal
                    tEspera.Msg("Auditando NFs com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita...");
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNfTribS =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                                 vOperador = "=",
                                 vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('01', '02', '03') or x.cd_st_cofins in('01', '02', '03')) " +
                                            "and (x.id_tpcontribuicaoPIs is null or x.id_receitaPIS is null or x.id_tpcontribuicaoCofins is null or x.id_receitaCofins is null))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("NFs com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita: " + lNfTribS.Count.ToString());
                    if (lNfTribS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoTributavelSai))
                            tcCentral.TabPages.Add(tpDoctoTributavelSai);
                        tcDoctoTribS.TabPages.Add(tpNfTribS);
                    }
                    bsNfTribS.DataSource = lNfTribS;
                    #endregion

                    #region Cupom Fiscal
                    tEspera.Msg("Auditando CUPONS FISCAIS com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita...");
                    CamadaDados.Faturamento.PDV.TList_NFCe lCfTribS =
                        new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_nfce = a.id_nfce " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('01', '02', '03') or x.cd_st_cofins in('01', '02', '03')) " +
                                            "and (x.id_tpcontribuicaopis is null or x.id_receitapis is null or x.id_tpcontribuicaocofins is null or x.id_receitacofins is null))"
                            }
                        }, 0, string.Empty, string.Empty);
                    tEspera.Msg("CUPONS FISCAIS com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita: " + lCfTribS.Count.ToString());
                    if (lCfTribS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoTributavelSai))
                            tcCentral.TabPages.Add(tpDoctoTributavelSai);
                        tcDoctoTribS.TabPages.Add(tpCFTribS);
                    }
                    bsCfTribS.DataSource = lCfTribS;
                    #endregion

                    #region Conhecimento Frete
                    tEspera.Msg("Auditando CTRC com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita...");
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrTribS =
                        new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_impostosnf x " + 
                                            "inner join tb_fis_imposto y " +
                                            "on x.cd_imposto = y.cd_imposto " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                            "and (y.st_pis = 0 or y.st_cofins = 0) " +
                                            "and x.cd_st in('01', '02', '03') " +
                                            "and (x.id_tpcontribuicao is null or x.id_receita is null))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("CTRC com CST PIS/COFINS TRIBUTADO sem tipo contribuição e/ou tipo receita: " + lCtrTribS.Count.ToString());
                    if (lCtrTribS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoTributavelSai))
                            tcCentral.TabPages.Add(tpDoctoTributavelSai);
                        tcDoctoTribS.TabPages.Add(tpCTTribS);
                    }
                    bsCTTribS.DataSource = lCtrTribS;
                    #endregion
                    #endregion

                    #region Documento Isentos na Saida
                    #region Nota Fiscal
                    tEspera.Msg("Auditando NFs com CST PIS/COFINS ISENTO sem natureza receita...");
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNfIsentaS =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(k.st_gerarspedpiscofins, 'N')",
                                 vOperador = "=",
                                 vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('04', '05', '06', '08') or x.cd_st_cofins in('04', '05', '06', '08')) " +
                                            "and (x.id_detrecisentaPIS is null or x.id_detrecisentaCofins is null))"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("NFs com CST PIS/COFINS ISENTO sem natureza receita: " + lNfIsentaS.Count.ToString());
                    if (lNfIsentaS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoCSTIsentaSai))
                            tcCentral.TabPages.Add(tpDoctoCSTIsentaSai);
                        tcDoctoCSTIsenta.TabPages.Add(tpNfCSTIsenta);
                    }
                    bsNfIsentaS.DataSource = lNfIsentaS;
                    #endregion

                    #region Cupom Fiscal
                    tEspera.Msg("Auditando CUPONS FISCAIS com CST PIS/COFINS ISENTO sem natureza receita...");
                    CamadaDados.Faturamento.PDV.TList_NFCe lCfIsentaS =
                        new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_nfce = a.id_nfce " +
                                            "and (isnull(x.CD_ST_PIS, '') <> '' or isnull(x.cd_st_cofins, '') <> '') " +
                                            "and (x.cd_st_pis in('04', '05', '06', '08') or x.cd_st_cofins in('04', '05', '06', '08')) " +
                                            "and (x.id_detrecisentapis is null or x.id_detrecisentacofins is null))"
                            }
                        }, 0, string.Empty, string.Empty);
                    tEspera.Msg("CUPONS FISCAIS com CST PIS/COFINS ISENTO sem natureza receita: " + lCfIsentaS.Count.ToString());
                    if (lCfIsentaS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoCSTIsentaSai))
                            tcCentral.TabPages.Add(tpDoctoCSTIsentaSai);
                        tcDoctoCSTIsenta.TabPages.Add(tpCFCSTIsenta);
                    }
                    bsCfIsentaS.DataSource = lCfIsentaS;
                    #endregion

                    #region Conhecimento Frete
                    tEspera.Msg("Auditando CTRC com CST PIS/COFINS ISENTO sem natureza receita...");
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCtrIsentaS =
                        new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = ">=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), 1).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_saient else a.dt_emissao end)))",
                                vOperador = "<=",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(cbAno.Text), int.Parse(cbMes.SelectedValue.ToString()))).ToString("yyyyMMdd") + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(mov.st_gerarspedpiscofins, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_impostosnf x " + 
                                            "inner join tb_fis_imposto y " +
                                            "on x.cd_imposto = y.cd_imposto " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                            "and (y.st_pis = 0 or y.st_cofins = 0) " +
                                            "and x.cd_st in('04', '05', '06', '08') " +
                                            "and x.id_detrecisenta is null)"
                            }
                        }, 0, string.Empty);
                    tEspera.Msg("CTRC com CST PIS/COFINS ISENTO sem natureza receita: " + lCtrIsentaS.Count.ToString());
                    if (lCtrIsentaS.Count > 0)
                    {
                        if (!tcCentral.TabPages.Contains(tpDoctoCSTIsentaSai))
                            tcCentral.TabPages.Add(tpDoctoCSTIsentaSai);
                        tcDoctoCSTIsenta.TabPages.Add(tpCTCSTIsenta);
                    }
                    bsCTIsentaS.DataSource = lCtrIsentaS;
                    #endregion
                    #endregion
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                }
            }
            else MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanSpedPisCofins_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
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
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            path_sped.Text = Fiscal.Properties.Settings.Default.PATH_SPEDPISCOFINS;
            rb_Original.Checked = true;
        }

        private void TFLanSpedPisCofins_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
                
        private void BB_GerarFiscal_Click(object sender, EventArgs e)
        {
            GerarArquivo();
        }

        private void TFLanSpedPisCofins_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                GerarArquivo();
        }

        private void bb_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_sped.Text = fbd.SelectedPath.Trim();
            }
        }

        private void bb_auditar_Click(object sender, EventArgs e)
        {
            AuditarMovimento();
        }

        private void bb_nfsemimposto_Click(object sender, EventArgs e)
        {
            if (bsNfSemImposto.Current != null)
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNfSemImposto.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNfSemImposto.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }
                
        private void bb_reprocessaNfErrada_Click(object sender, EventArgs e)
        {
            if(bsNfCSTErrada.Current != null)
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNfCSTErrada.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNfCSTErrada.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }

        private void bb_reprocessaNFTribE_Click(object sender, EventArgs e)
        {
            if(bsNfTribE.Current != null)
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNfTribE.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNfTribE.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }

        private void bb_reprocessaNFTribS_Click(object sender, EventArgs e)
        {
            if(bsNfTribS.Current != null)
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNfTribS.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNfTribS.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }

        private void bb_reprocessaNFIsentaS_Click(object sender, EventArgs e)
        {
            if(bsNfIsentaS.Current != null)
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNf = bsNfIsentaS.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNfIsentaS.RemoveCurrent();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }

        private void bb_reprocessaCFSemImp_Click(object sender, EventArgs e)
        {
            if (bsCfSemImposto.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNFCe = bsCfSemImposto.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(null,
                                                               null,
                                                               fReprocessa.rNFCe,
                                                               fReprocessa.rNFCe.Vl_cupom,
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCfSemImposto.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void bb_reprocessaCFErrado_Click(object sender, EventArgs e)
        {
            if (bsCfSemImposto.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNFCe = bsCfCSTErrada.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(null,
                                                               null,
                                                               fReprocessa.rNFCe,
                                                               fReprocessa.rNFCe.Vl_cupom,
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCfCSTErrada.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void bb_reprocessaCFTribS_Click(object sender, EventArgs e)
        {
            if (bsCfSemImposto.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNFCe = bsCfTribS.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(null,
                                                               null,
                                                               fReprocessa.rNFCe,
                                                               fReprocessa.rNFCe.Vl_cupom,
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCfTribS.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void bb_reprocessaCFIsentaS_Click(object sender, EventArgs e)
        {
            if (bsCfSemImposto.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    fReprocessa.rNFCe = bsCfIsentaS.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(null,
                                                               null,
                                                               fReprocessa.rNFCe,
                                                               fReprocessa.rNFCe.Vl_cupom,
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCfIsentaS.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }
    }
}
